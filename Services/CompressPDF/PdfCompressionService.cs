using iText.Kernel.Pdf;
using System.Diagnostics;

namespace ratpdf.Services.CompressPDF
{
    public enum CompressionLevel
    {
        Extreme,
        Recommended,
        Less
    }

    public class CompressionResult
    {
        public string BlobName { get; init; } = "";
        public long OriginalSize { get; init; }
        public long CompressedSize { get; init; }
        public double ReductionPct { get; init; }
        public string Method { get; init; } = "";
    }

    public class PdfCompressionService
    {
        private readonly ILogger<PdfCompressionService> _logger;
        private readonly IWebHostEnvironment _env;

        private static readonly Dictionary<CompressionLevel, string> GsSettings = new()
        {
            [CompressionLevel.Extreme] = "/screen",
            [CompressionLevel.Recommended] = "/ebook",
            [CompressionLevel.Less] = "/printer",
        };

        public PdfCompressionService(ILogger<PdfCompressionService> logger, IWebHostEnvironment env)
        {
            _logger = logger;
            _env = env;
        }

        public async Task<CompressionResult> CompressFromFileAsync(
            string inputFilePath,
            CompressionLevel level,
            string? password,
            AzureBlobService blobService,
            string jobId,
            CancellationToken ct = default)
        {
            var inFile = inputFilePath;
            var outFile = Path.Combine(Path.GetTempPath(), $"ratpdf_out_{Guid.NewGuid():N}.pdf");

            try
            {
                if (!File.Exists(inFile))
                    throw new FileNotFoundException("Input PDF not found.", inFile);

                var originalSize = new FileInfo(inFile).Length;

                // --- Ghostscript path ---
                if (IsGhostscriptAvailable())
                {
                    try
                    {
                        bool gsSuccess = await CompressWithGhostscriptFileAsync(inFile, outFile, level,password, ct);
                        if (gsSuccess && File.Exists(outFile))
                        {
                            var outInfo = new FileInfo(outFile);
                            if (outInfo.Length < originalSize)
                            {
                                var blobName = await UploadAndCleanup(
                                    blobService, outFile, jobId, ct);
                                return BuildResult(blobName, originalSize, outInfo.Length, "Ghostscript");
                            }
                            TryDelete(outFile);
                        }
                    }
                    catch { }
                }


                await CompressWithIText7FileAsync(inFile, outFile, level,password, ct);
                var fallbackInfo = new FileInfo(outFile);
                var fallbackBlob = await UploadAndCleanup(blobService, outFile, jobId, ct);
                return BuildResult(fallbackBlob, originalSize, fallbackInfo.Length, "iText7");
            }
            finally
            {
                TryDelete(outFile);
            }
        }

        public Task<CompressionResult> CompressAsync(
            Stream inputStream,
            CompressionLevel level,
            string? password,
            AzureBlobService blobService,
            string jobId,
            CancellationToken ct = default)
        {
            var inFile = Path.Combine(Path.GetTempPath(), $"ratpdf_in_{Guid.NewGuid():N}.pdf");
            return CompressFromStreamInternalAsync(
                inputStream, inFile, level, password, blobService, jobId, ct);
        }

        private async Task<CompressionResult> CompressFromStreamInternalAsync(
            Stream inputStream,
            string inFile,
            CompressionLevel level,
            string? password,
            AzureBlobService blobService,
            string jobId,
            CancellationToken ct)
        {
            try
            {
                await using (var fs = new FileStream(inFile, FileMode.Create, FileAccess.Write,
                    FileShare.None, 81920, useAsync: true))
                {
                    await inputStream.CopyToAsync(fs, 81920, ct);
                }

                return await CompressFromFileAsync(inFile, level, password, blobService, jobId, ct);
            }
            finally
            {
                TryDelete(inFile);
            }
        }

        private static async Task<string> UploadAndCleanup(
            AzureBlobService blobService, string localPath, string jobId, CancellationToken ct)
        {
            var blobName = $"ratpdf_out_{jobId}.pdf";
            await blobService.UploadFromFileAsync(localPath, blobName, ct);
            TryDelete(localPath);
            return blobName;
        }

        private static CompressionResult BuildResult(
            string blobName, long originalSize, long compressedSize, string method)
        {
            double pct = originalSize > 0
                ? (originalSize - compressedSize) / (double)originalSize * 100.0
                : 0;

            return new CompressionResult
            {
                BlobName = blobName,
                OriginalSize = originalSize,
                CompressedSize = compressedSize,
                ReductionPct = Math.Round(pct, 1),
                Method = method,
            };
        }

        private static bool IsGhostscriptAvailable()
        {
            foreach (var bin in new[] { "gs", "gswin64c", "gswin32c" }) // Uncomment For Production
            //foreach (var bin in new[] { "gswin64c", "gswin32c", "gs" }) // Uncomment For Development
            {
                try
                {
                    using var p = Process.Start(new ProcessStartInfo
                    {
                        FileName = bin,
                        Arguments = "--version",
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        CreateNoWindow = true,
                    });
                    p?.WaitForExit(2000);
                    if (p?.ExitCode == 0) return true;
                }
                catch { }
            }
            return false;
        }

        private static string GhostscriptBinary()
        {
            var bundled = Path.Combine(AppContext.BaseDirectory, "gs");
            if (File.Exists(bundled)) return bundled;

            foreach (var bin in new[] { "gs", "gswin64c" }) // Uncomment For Production
            //foreach (var bin in new[] { "gswin64c", "gswin32c", "gs" }) // Uncomment For Development
            {
                try
                {
                    using var p = Process.Start(new ProcessStartInfo
                    {
                        FileName = bin,
                        Arguments = "--version",
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        CreateNoWindow = true,
                    });
                    p?.WaitForExit(2000);
                    if (p?.ExitCode == 0) return bin;
                }
                catch { }
            }
            throw new InvalidOperationException("Ghostscript not found.");
        }


        private async Task<bool> CompressWithGhostscriptFileAsync(
            string inFile,
            string outFile,
            CompressionLevel level,
            string? password,
            CancellationToken ct)
        {
            var settings = GsSettings[level];
            var passwordArg = string.IsNullOrWhiteSpace(password)? "": $"-sPDFPassword=\"{password}\" ";
            var gsArgs =
                $"-sDEVICE=pdfwrite " +
                $"-dCompatibilityLevel=1.5 " +
                $"-dPDFSETTINGS={settings} " +
                $"-dNOPAUSE -dQUIET -dBATCH " +
                $"-dCompressPages=true " +
                $"-dOptimize=true " +
                $"-dEmbedAllFonts=true " +
                $"-dSubsetFonts=true " +
                $"-dColorImageDownsampleType=/Bicubic " +
                $"-dGrayImageDownsampleType=/Bicubic " +
                $"-dMonoImageDownsampleType=/Bicubic " +
                 passwordArg +
                $"-sOutputFile=\"{outFile}\" " +
                $"\"{inFile}\"";

            using var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = GhostscriptBinary(),
                    Arguments = gsArgs,
                    RedirectStandardError = true,
                    RedirectStandardOutput = false,
                    RedirectStandardInput = false,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                }
            };

            process.Start();

            var stderr = await process.StandardError.ReadToEndAsync(ct);
            await process.WaitForExitAsync(ct);

            if (process.ExitCode != 0)
            {
                return false;
            }

            return true;
        }


        private static readonly Dictionary<CompressionLevel, (int DpiTarget, long JpegQuality)> ITextParams = new()
        {
            [CompressionLevel.Extreme] = (72, 30),
            [CompressionLevel.Recommended] = (150, 65),
            [CompressionLevel.Less] = (300, 88),
        };

        private async Task CompressWithIText7FileAsync(
            string inFile,
            string outFile,
            CompressionLevel level,
            string? password,
            CancellationToken ct)
        {
            await Task.Run(() =>
            {
                var fileSize = new FileInfo(inFile).Length;

                bool recompressImages = fileSize < 100 * 1024 * 1024;

                if (!recompressImages)
                    _logger.LogInformation(
                        "File > 100 MB — skipping GDI+ image recompression, using object optimisation only");

                var (_, jpegQuality) = ITextParams[level];

                var writerProps = new WriterProperties()
                    .SetFullCompressionMode(true)
                    .SetCompressionLevel(CompressionConstants.BEST_COMPRESSION);

                using var reader =!string.IsNullOrWhiteSpace(password) ? new PdfReader(inFile,
                new ReaderProperties()
                .SetPassword(System.Text.Encoding.UTF8.GetBytes(password)))
               : new PdfReader(inFile);

                using var writer = new PdfWriter(outFile, writerProps);
                using var pdfDoc = new PdfDocument(reader, writer);

                pdfDoc.GetDocumentInfo().SetMoreInfo("Producer", "RatPdf");
                pdfDoc.GetDocumentInfo().SetMoreInfo("Creator", "");
                pdfDoc.GetCatalog().Remove(PdfName.Metadata);

                for (int i = 1; i <= pdfDoc.GetNumberOfPages(); i++)
                {
                    ct.ThrowIfCancellationRequested();

                    var page = pdfDoc.GetPage(i);
                    page.GetPdfObject().Remove(PdfName.Thumb);

                    if (recompressImages)
                        RecompressPageImages(page, jpegQuality);
                }

                pdfDoc.Close();

            }, ct);
        }

        private void RecompressPageImages(PdfPage page, long jpegQuality)
        {
            var resources = page.GetResources();
            if (resources == null) return;

            var xObjects = resources.GetPdfObject().GetAsDictionary(PdfName.XObject);
            if (xObjects == null) return;

            foreach (var key in xObjects.KeySet())
            {
                var xObjRef = xObjects.Get(key);
                if (xObjRef is not PdfIndirectReference indRef) continue;

                var xObj = indRef.GetRefersTo();
                if (xObj is not PdfStream stream) continue;

                var subtype = stream.GetAsName(PdfName.Subtype);
                if (!PdfName.Image.Equals(subtype)) continue;

                var colorSpace = stream.Get(PdfName.ColorSpace);
                var bitsPerComp = stream.GetAsNumber(PdfName.BitsPerComponent);
                var isMask = stream.GetAsBoolean(PdfName.ImageMask);

                if (isMask != null && isMask.GetValue()) continue;
                if (PdfName.DeviceCMYK.Equals(colorSpace)) continue;
                if (bitsPerComp != null && bitsPerComp.IntValue() == 1) continue;

                try
                {
                    var rawBytes = stream.GetBytes(true);
                    if (rawBytes == null || rawBytes.Length == 0) continue;

                    int width = stream.GetAsNumber(PdfName.Width)?.IntValue() ?? 0;
                    int height = stream.GetAsNumber(PdfName.Height)?.IntValue() ?? 0;
                    if (width == 0 || height == 0) continue;

                    var reencoded = ReencodeAsJpeg(rawBytes, width, height, jpegQuality);
                    if (reencoded == null || reencoded.Length >= rawBytes.Length) continue;

                    stream.SetData(reencoded, false);
                    stream.Put(PdfName.Filter, PdfName.DCTDecode);
                    stream.Remove(PdfName.DecodeParms);

                    _logger.LogDebug("Image recompressed: {Before} → {After} bytes",
                        rawBytes.Length, reencoded.Length);
                }
                catch (Exception ex)
                {
                    _logger.LogDebug(ex, "Skipping image recompression (unsupported format)");
                }
            }
        }

        private static byte[]? ReencodeAsJpeg(byte[] rawBytes, int width, int height, long quality)
        {
            try
            {
                using var bmp = RawBytesToBitmap(rawBytes, width, height);
                if (bmp == null) return null;

                using var outMs = new MemoryStream();
                var encoder = GetJpegEncoder();
                if (encoder == null) return null;

                var encoderParams = new System.Drawing.Imaging.EncoderParameters(1);
                encoderParams.Param[0] = new System.Drawing.Imaging.EncoderParameter(
                    System.Drawing.Imaging.Encoder.Quality, quality);

                bmp.Save(outMs, encoder, encoderParams);
                return outMs.ToArray();
            }
            catch { return null; }
        }

        private static System.Drawing.Bitmap? RawBytesToBitmap(byte[] raw, int width, int height)
        {
            int expectedRgb = width * height * 3;
            int expectedRgba = width * height * 4;

            System.Drawing.Imaging.PixelFormat fmt;
            if (raw.Length == expectedRgba) fmt = System.Drawing.Imaging.PixelFormat.Format32bppRgb;
            else if (raw.Length == expectedRgb) fmt = System.Drawing.Imaging.PixelFormat.Format24bppRgb;
            else return null;

            var bmp = new System.Drawing.Bitmap(width, height, fmt);
            var data = bmp.LockBits(
                new System.Drawing.Rectangle(0, 0, width, height),
                System.Drawing.Imaging.ImageLockMode.WriteOnly, fmt);
            System.Runtime.InteropServices.Marshal.Copy(raw, 0, data.Scan0, raw.Length);
            bmp.UnlockBits(data);
            return bmp;
        }

        private static System.Drawing.Imaging.ImageCodecInfo? GetJpegEncoder() =>
            System.Drawing.Imaging.ImageCodecInfo
                .GetImageEncoders()
                .FirstOrDefault(e => e.FormatID == System.Drawing.Imaging.ImageFormat.Jpeg.Guid);

        private static void TryDelete(string path)
        {
            try { if (File.Exists(path)) File.Delete(path); } catch { }
        }
    }
}