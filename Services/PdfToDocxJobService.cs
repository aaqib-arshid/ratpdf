using System.IO.Compression;

namespace ratpdf.Services
{
    public class PdfToDocxJobService
    {
        private readonly PdfToDocxProcessor _processor;
        private readonly IJobResultStore _jobStore;
        private readonly AzureBlobService _blobService;
        private readonly ILogger<PdfToDocxJobService> _logger;

        public PdfToDocxJobService(
            PdfToDocxProcessor processor,
            IJobResultStore jobStore,
            AzureBlobService blobService,
            ILogger<PdfToDocxJobService> logger)
        {
            _processor = processor;
            _jobStore = jobStore;
            _blobService = blobService;
            _logger = logger;
        }

        public async Task RunConversionJobAsync(
            string jobId,
            IReadOnlyList<(string TempPath, string OriginalName, long Size)> inputs,
            CancellationToken ct)
        {
            try
            {
                _jobStore.SetProgress(jobId, 5, "Preparing conversion…");
                var outputFiles = new List<(string Name, byte[] Bytes)>();
                var total = inputs.Count;

                for (var i = 0; i < total; i++)
                {
                    ct.ThrowIfCancellationRequested();
                    var (tempPath, originalName, size) = inputs[i];
                    var pct = 10 + (int)((i / (double)total) * 75);
                    _jobStore.SetProgress(jobId, pct, $"Converting {originalName} ({i + 1}/{total})…");

                    await using var stream = new FileStream(tempPath, FileMode.Open, FileAccess.Read, FileShare.Read);
                    var docxBytes = await _processor.ConvertPdfToDocxAsync(stream, originalName);
                    var outName = Path.GetFileNameWithoutExtension(originalName) + ".docx";
                    outputFiles.Add((outName, docxBytes));
                }

                _jobStore.SetProgress(jobId, 90, "Packaging result…");

                byte[] finalBytes;
                string mimeType;
                string outputName;

                if (outputFiles.Count == 1)
                {
                    finalBytes = outputFiles[0].Bytes;
                    mimeType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                    outputName = outputFiles[0].Name;
                }
                else
                {
                    using var zipMs = new MemoryStream();
                    using (var archive = new ZipArchive(zipMs, ZipArchiveMode.Create, leaveOpen: true))
                    {
                        foreach (var (name, bytes) in outputFiles)
                        {
                            var entry = archive.CreateEntry(name, CompressionLevel.Fastest);
                            await using var entryStream = entry.Open();
                            await entryStream.WriteAsync(bytes, ct);
                        }
                    }
                    finalBytes = zipMs.ToArray();
                    mimeType = "application/zip";
                    outputName = "converted-documents.zip";
                }

                var blobName = $"pdf2docx/{jobId}/{outputName}";
                await using var uploadStream = new MemoryStream(finalBytes);
                await _blobService.UploadAsync(uploadStream, blobName, ct);

                var inputSize = inputs.Sum(x => x.Size);
                _jobStore.SetFileJobCompleted(
                    jobId,
                    blobName,
                    mimeType,
                    outputName,
                    inputSize,
                    finalBytes.Length,
                    "pdf2docx");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "PDF to DOCX job {JobId} failed", jobId);
                _jobStore.SetFailed(jobId, ex.Message);
            }
            finally
            {
                foreach (var input in inputs)
                {
                    try
                    {
                        if (File.Exists(input.TempPath))
                            File.Delete(input.TempPath);
                    }
                    catch { /* best effort */ }
                }
            }
        }
    }
}
