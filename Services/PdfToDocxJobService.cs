using System.IO.Compression;
using ratpdf.Services.PdfProcessing;

namespace ratpdf.Services
{
    public class PdfToDocxJobService
    {
        private readonly PdfToDocxProcessor _processor;
        private readonly IJobResultStore _jobStore;
        private readonly AzureBlobService _blobService;
        private readonly PdfJobStorageService _jobStorage;
        private readonly ILogger<PdfToDocxJobService> _logger;

        public PdfToDocxJobService(
            PdfToDocxProcessor processor,
            IJobResultStore jobStore,
            AzureBlobService blobService,
            PdfJobStorageService jobStorage,
            ILogger<PdfToDocxJobService> logger)
        {
            _processor = processor;
            _jobStore = jobStore;
            _blobService = blobService;
            _jobStorage = jobStorage;
            _logger = logger;
        }

        public async Task RunConversionJobAsync(
            string jobId,
            IReadOnlyList<(string StagingBlobName, string OriginalName, long Size)> inputs,
            CancellationToken ct)
        {
            using var metrics = PdfProcessingMetrics.Start(_logger, "pdf2docx-job", jobId);
            var outputPaths = new List<(string Name, string Path, long Size)>();
            string? packagePath = null;

            try
            {
                _jobStore.SetProgress(jobId, 5, "Preparing conversion…");
                var total = inputs.Count;
                var inputSize = inputs.Sum(x => x.Size);
                metrics.Checkpoint("inputs-staged", inputSize);

                for (var i = 0; i < total; i++)
                {
                    ct.ThrowIfCancellationRequested();
                    var (stagingBlob, originalName, _) = inputs[i];
                    var pct = 10 + (int)((i / (double)total) * 75);
                    _jobStore.SetProgress(jobId, pct, $"Converting {originalName} ({i + 1}/{total})…");

                    string? tempPdf = null;
                    string? tempDocx = null;
                    try
                    {
                        tempPdf = await _jobStorage.MaterializeToTempFileAsync(stagingBlob, ".pdf", ct);
                        tempDocx = Path.Combine(Path.GetTempPath(), $"ratpdf_{Guid.NewGuid():N}.docx");

                        var result = await _processor.ConvertPdfFileToDocxAsync(
                            tempPdf, tempDocx, originalName, ct);

                        var outName = Path.GetFileNameWithoutExtension(originalName) + ".docx";
                        outputPaths.Add((outName, result.FilePath, result.SizeBytes));
                        tempDocx = null;
                    }
                    finally
                    {
                        PdfJobStorageService.TryDeleteLocalFile(tempPdf);
                        PdfJobStorageService.TryDeleteLocalFile(tempDocx);
                    }
                }

                _jobStore.SetProgress(jobId, 90, "Uploading result…");

                string blobName;
                string mimeType;
                string outputName;
                long outputSize;
                if (outputPaths.Count == 1)
                {
                    var single = outputPaths[0];
                    outputName = single.Name;
                    mimeType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                    blobName = $"pdf2docx/{jobId}/{outputName}";
                    outputSize = await _blobService.UploadFromFileAsync(single.Path, blobName, ct);
                }
                else
                {
                    outputName = "converted-documents.zip";
                    mimeType = "application/zip";
                    packagePath = Path.Combine(Path.GetTempPath(), $"ratpdf_{jobId}.zip");
                    await CreateZipOnDiskAsync(outputPaths, packagePath, ct);
                    blobName = $"pdf2docx/{jobId}/{outputName}";
                    outputSize = await _blobService.UploadFromFileAsync(packagePath, blobName, ct);
                }

                metrics.Checkpoint("uploaded", inputSize, outputSize);

                _jobStore.SetFileJobCompleted(
                    jobId,
                    blobName,
                    mimeType,
                    outputName,
                    inputSize,
                    outputSize,
                    "pdf2docx");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "PDF to DOCX job {JobId} failed", jobId);
                _jobStore.SetFailed(jobId, ex.Message);
            }
            finally
            {
                PdfJobStorageService.TryDeleteLocalFile(packagePath);

                foreach (var (_, path, _) in outputPaths)
                    PdfJobStorageService.TryDeleteLocalFile(path);

                foreach (var input in inputs)
                {
                    try { await _jobStorage.DeleteStagingAsync(input.StagingBlobName, ct); }
                    catch { /* best effort */ }
                }
            }
        }

        private static async Task CreateZipOnDiskAsync(
            IReadOnlyList<(string Name, string Path, long Size)> files,
            string zipPath,
            CancellationToken ct)
        {
            if (File.Exists(zipPath))
                File.Delete(zipPath);

            await using var zipStream = new FileStream(
                zipPath, FileMode.CreateNew, FileAccess.ReadWrite, FileShare.None, 65536, useAsync: true);
            using var archive = new ZipArchive(zipStream, ZipArchiveMode.Create, leaveOpen: true);

            foreach (var (name, path, _) in files)
            {
                ct.ThrowIfCancellationRequested();
                var entry = archive.CreateEntry(name, CompressionLevel.Fastest);
                await using var entryStream = entry.Open();
                await using var source = new FileStream(
                    path, FileMode.Open, FileAccess.Read, FileShare.Read, 65536, useAsync: true);
                await source.CopyToAsync(entryStream, 65536, ct);
            }
        }
    }
}
