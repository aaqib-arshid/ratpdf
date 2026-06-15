using ratpdf.Constants;

namespace ratpdf.Services
{
    public class PdfEditExportJobService
    {
        private readonly PdfEditProcessor _pdfEditProcessor;
        private readonly AzureBlobService _blobService;
        private readonly IJobResultStore _jobStore;
        private readonly ILogger<PdfEditExportJobService> _logger;

        public PdfEditExportJobService(
            PdfEditProcessor pdfEditProcessor,
            AzureBlobService blobService,
            IJobResultStore jobStore,
            ILogger<PdfEditExportJobService> logger)
        {
            _pdfEditProcessor = pdfEditProcessor;
            _blobService = blobService;
            _jobStore = jobStore;
            _logger = logger;
        }

        public async Task RunExportJobAsync(
            string jobId,
            string pdfPath,
            string editsJsonPath,
            string outputFileName,
            CancellationToken ct = default)
        {
            var outputPath = Path.GetTempFileName() + ".pdf";
            try
            {
                _jobStore.SetProgress(jobId, 15, "Applying page changes…");
                _jobStore.SetProgress(jobId, 35, "Rendering edits…");
                await _pdfEditProcessor.ApplyEditsAsync(pdfPath, editsJsonPath, outputPath, ct);

                var inputSize = new FileInfo(pdfPath).Length;
                var outputSize = new FileInfo(outputPath).Length;

                _jobStore.SetProgress(jobId, 80, "Uploading PDF…");
                var blobName = $"editpdf/{jobId}/{outputFileName}";
                await _blobService.UploadFromFileAsync(outputPath, blobName, ct);

                _jobStore.SetFileJobCompleted(
                    jobId, blobName, "application/pdf", outputFileName,
                    inputSize, outputSize, PdfToolIds.EditPdf);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Edit export job {JobId} failed", jobId);
                _jobStore.SetFailed(jobId, UserFacingErrorMapper.FromException(ex));
                throw;
            }
            finally
            {
                PdfProcessing.PdfJobStorageService.TryDeleteLocalFile(outputPath);
            }
        }
    }
}
