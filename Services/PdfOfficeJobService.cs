using ratpdf.Constants;
using ratpdf.Services.PdfProcessing;

namespace ratpdf.Services
{
    public class PdfOfficeJobService
    {
        private readonly PdfOfficeProcessor _processor;
        private readonly IJobResultStore _jobStore;
        private readonly AzureBlobService _blobService;
        private readonly PdfJobStorageService _jobStorage;
        private readonly ILogger<PdfOfficeJobService> _logger;

        public PdfOfficeJobService(
            PdfOfficeProcessor processor,
            IJobResultStore jobStore,
            AzureBlobService blobService,
            PdfJobStorageService jobStorage,
            ILogger<PdfOfficeJobService> logger)
        {
            _processor = processor;
            _jobStore = jobStore;
            _blobService = blobService;
            _jobStorage = jobStorage;
            _logger = logger;
        }

        public async Task RunJobAsync(
            string jobId,
            string jobKind,
            OfficeConversionKind kind,
            string stagingBlobName,
            string originalName,
            long inputSize,
            CancellationToken ct)
        {
            using var metrics = PdfProcessingMetrics.Start(_logger, jobKind, jobId);
            string? tempInput = null;
            string? tempOutput = null;

            try
            {
                _jobStore.SetProgress(jobId, 10, "Preparing file…");
                metrics.Checkpoint("staging-read", inputSize);

                var progressMsg = inputSize >= PdfToolLimits.LargeFileWarningBytes
                    ? PdfToolLimits.LargeFileWarningMessage
                    : "Running high-fidelity conversion…";

                var inputExt = kind switch
                {
                    OfficeConversionKind.DocxToPdf => ".docx",
                    OfficeConversionKind.PdfToXlsx => ".pdf",
                    OfficeConversionKind.XlsxToPdf => ".xlsx",
                    _ => ".bin",
                };

                var outputExt = kind switch
                {
                    OfficeConversionKind.PdfToXlsx => ".xlsx",
                    _ => ".pdf",
                };

                tempInput = await _jobStorage.MaterializeToTempFileAsync(stagingBlobName, inputExt, ct);
                tempOutput = Path.Combine(Path.GetTempPath(), $"ratpdf_office_{Guid.NewGuid():N}{outputExt}");

                _jobStore.SetProgress(jobId, 25, progressMsg);
                var result = await _processor.ConvertFileAsync(
                    kind, tempInput, tempOutput, originalName, ct);

                _jobStore.SetProgress(jobId, 85, "Uploading result…");

                var outputName = kind switch
                {
                    OfficeConversionKind.DocxToPdf => Path.GetFileNameWithoutExtension(originalName) + ".pdf",
                    OfficeConversionKind.PdfToXlsx => Path.GetFileNameWithoutExtension(originalName) + ".xlsx",
                    OfficeConversionKind.XlsxToPdf => Path.GetFileNameWithoutExtension(originalName) + ".pdf",
                    _ => "converted" + outputExt,
                };

                var mime = kind switch
                {
                    OfficeConversionKind.PdfToXlsx =>
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    _ => "application/pdf",
                };

                var blobName = $"{jobKind}/{jobId}/{outputName}";
                var outputSize = await _blobService.UploadFromFileAsync(result.FilePath, blobName, ct);
                metrics.Checkpoint("uploaded", inputSize, outputSize);

                _jobStore.SetFileJobCompleted(
                    jobId,
                    blobName,
                    mime,
                    outputName,
                    inputSize,
                    outputSize,
                    jobKind);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Office job {JobId} ({Kind}) failed", jobId, jobKind);
                _jobStore.SetFailed(jobId, UserFacingErrorMapper.FromException(ex));
            }
            finally
            {
                PdfJobStorageService.TryDeleteLocalFile(tempInput);
                PdfJobStorageService.TryDeleteLocalFile(tempOutput);

                try { await _jobStorage.DeleteStagingAsync(stagingBlobName, ct); }
                catch { /* best effort */ }
            }
        }
    }
}
