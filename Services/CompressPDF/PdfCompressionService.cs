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
        public byte[] Data { get; init; } = [];
        public long OriginalSize { get; init; }
        public long CompressedSize { get; init; }
        public double ReductionPct { get; init; }
        public string Method { get; init; } = "";
    }
    public class PdfCompressionService
    {
        private readonly ILogger<PdfCompressionService> _logger;
        private readonly IWebHostEnvironment _env;

        // Ghostscript PDF settings strings per level
        private static readonly Dictionary<CompressionLevel, string> GsSettings = new()
        {
            [CompressionLevel.Extreme] = "/screen",     // 72 dpi — maximum compression
            [CompressionLevel.Recommended] = "/ebook",      // 150 dpi — good balance
            [CompressionLevel.Less] = "/printer",    // 300 dpi — near-print quality
        };

        public PdfCompressionService(ILogger<PdfCompressionService> logger, IWebHostEnvironment env)
        {
            _logger = logger;
            _env = env;
        }

        /// <summary>
        /// Compresses a PDF. Tries Ghostscript first (best results), falls back to iText7.
        /// </summary>
        public async Task<CompressionResult> CompressAsync(
            Stream inputStream,
            CompressionLevel level,
            CancellationToken ct = default)
        {
            // Read input into memory once
            using var ms = new MemoryStream();
            await inputStream.CopyToAsync(ms, ct);
            var inputBytes = ms.ToArray();
            long originalSize = inputBytes.Length;

            // --- Attempt Ghostscript ---
            if (IsGhostscriptAvailable())
            {
                try
                {
                    var gsResult = await CompressWithGhostscriptAsync(inputBytes, level, ct);
                    if (gsResult is not null && gsResult.Length < originalSize)
                    {
                        return BuildResult(inputBytes, gsResult, "Ghostscript");
                    }
                }
                catch (Exception ex)
                {
                }
            }
            else
            {
            }

            var iTextResult = CompressWithIText7(inputBytes, level);
            return BuildResult(inputBytes, iTextResult, "iText7");
        }


        private static bool IsGhostscriptAvailable()
        {
            foreach (var bin in new[] { "gs", "gswin64c", "gswin32c" })
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
                catch {  }
            }
            return false;
        }

        private static string GhostscriptBinary()
        {
            var bundled = Path.Combine(AppContext.BaseDirectory, "gs");
            if (File.Exists(bundled)) return bundled;

            foreach (var bin in new[] { "gs", "gswin64c" })
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

        private async Task<byte[]?> CompressWithGhostscriptAsync(
            byte[] inputBytes,
            CompressionLevel level,
            CancellationToken ct)
        {
            var tmpDir = Path.GetTempPath();
            var inFile = Path.Combine(tmpDir, $"ratpdf_in_{Guid.NewGuid():N}.pdf");
            var outFile = Path.Combine(tmpDir, $"ratpdf_out_{Guid.NewGuid():N}.pdf");

            try
            {
                await File.WriteAllBytesAsync(inFile, inputBytes, ct);

                var settings = GsSettings[level];
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
                    $"-sOutputFile=\"{outFile}\" " +
                    $"\"{inFile}\"";

                using var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = GhostscriptBinary(),
                        Arguments = gsArgs,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        CreateNoWindow = true,
                    }
                };

                process.Start();

                // Read stderr for diagnostics
                var stderr = await process.StandardError.ReadToEndAsync(ct);

                await process.WaitForExitAsync(ct);

                if (process.ExitCode != 0)
                {
                    return null;
                }

                if (!File.Exists(outFile))
                {
                    return null;
                }

                return await File.ReadAllBytesAsync(outFile, ct);
            }
            finally
            {
                try { if (File.Exists(inFile)) File.Delete(inFile); } catch { }
                try { if (File.Exists(outFile)) File.Delete(outFile); } catch { }
            }
        }

        // ────────────────────────────────────────────────────────────────────────
        // iText7 fallback
        // Recompresses image XObjects, enables object streams, removes metadata bloat
        // ────────────────────────────────────────────────────────────────────────

        private static readonly Dictionary<CompressionLevel, (int DpiTarget, long JpegQuality)> ITextParams = new()
        {
            [CompressionLevel.Extreme] = (72, 30),
            [CompressionLevel.Recommended] = (150, 65),
            [CompressionLevel.Less] = (300, 88),
        };

        private byte[] CompressWithIText7(byte[] inputBytes, CompressionLevel level)
        {
            var (dpiTarget, jpegQuality) = ITextParams[level];

            using var input = new MemoryStream(inputBytes);
            using var output = new MemoryStream();

            var readerProps = new ReaderProperties();
            var writerProps = new WriterProperties()
                .SetFullCompressionMode(true)          
                .SetCompressionLevel(CompressionConstants.BEST_COMPRESSION);

            using var reader = new PdfReader(input, readerProps);
            using var writer = new PdfWriter(output, writerProps);
            using var pdfDoc = new PdfDocument(reader, writer);

            pdfDoc.GetDocumentInfo().SetMoreInfo("Producer", "RatPdf");
            pdfDoc.GetDocumentInfo().SetMoreInfo("Creator", "");

            var catalog = pdfDoc.GetCatalog();

            catalog.Remove(PdfName.Metadata);

            int numPages = pdfDoc.GetNumberOfPages();
            for (int i = 1; i <= numPages; i++)
            {
                var page = pdfDoc.GetPage(i);

                page.GetPdfObject().Remove(PdfName.Thumb);

                RecompressPageImages(page, jpegQuality);
            }

            pdfDoc.Close();
            return output.ToArray();
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

                // Skip masks, CMYK, 1-bit images — recompressing these causes artifacts
                var isMask = stream.GetAsBoolean(PdfName.ImageMask);
                if (isMask != null && isMask.GetValue()) continue;
                if (PdfName.DeviceCMYK.Equals(colorSpace)) continue;
                if (bitsPerComp != null && bitsPerComp.IntValue() == 1) continue;

                try
                {
                    // Decode the image bytes using iText7's built-in decoder
                    var rawBytes = stream.GetBytes(true); // true = decode filters
                    if (rawBytes == null || rawBytes.Length == 0) continue;

                    int width = stream.GetAsNumber(PdfName.Width)?.IntValue() ?? 0;
                    int height = stream.GetAsNumber(PdfName.Height)?.IntValue() ?? 0;
                    if (width == 0 || height == 0) continue;

                    // Re-encode as JPEG using System.Drawing
                    var reencoded = ReencodeAsJpeg(rawBytes, width, height, jpegQuality);
                    if (reencoded == null || reencoded.Length >= rawBytes.Length) continue;

                    // Replace the stream with the re-encoded JPEG bytes
                    stream.SetData(reencoded, false);
                    stream.Put(PdfName.Filter, PdfName.DCTDecode);
                    stream.Remove(PdfName.DecodeParms);

                    _logger.LogDebug(
                        "Image recompressed: {Before} → {After} bytes",
                        rawBytes.Length, reencoded.Length);
                }
                catch (Exception ex)
                {
                    _logger.LogDebug(ex, "Skipping image recompression (unsupported format)");
                }
            }
        }

        /// <summary>
        /// Re-encodes raw RGB/RGBA pixel bytes as JPEG.
        /// Returns null if re-encoding is not possible or wouldn't help.
        /// </summary>
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
            catch
            {
                return null;
            }
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
                System.Drawing.Imaging.ImageLockMode.WriteOnly,
                fmt);
            System.Runtime.InteropServices.Marshal.Copy(raw, 0, data.Scan0, raw.Length);
            bmp.UnlockBits(data);
            return bmp;
        }

        private static System.Drawing.Imaging.ImageCodecInfo? GetJpegEncoder() =>
            System.Drawing.Imaging.ImageCodecInfo
                .GetImageEncoders()
                .FirstOrDefault(e => e.FormatID == System.Drawing.Imaging.ImageFormat.Jpeg.Guid);


        private static CompressionResult BuildResult(byte[] input, byte[] output, string method)
        {
            long orig = input.Length;
            long compressed = output.Length;
            double pct = orig > 0 ? (orig - compressed) / (double)orig * 100.0 : 0;
            return new CompressionResult
            {
                Data = output,
                OriginalSize = orig,
                CompressedSize = compressed,
                ReductionPct = Math.Round(pct, 1),
                Method = method,
            };
        }
    }
}
