namespace ratpdf.Services
{
    public class PdfOfficeJobService
    {
        private readonly PdfOfficeProcessor _processor;
        private readonly IJobResultStore _jobStore;
        private readonly AzureBlobService _blobService;
        private readonly ILogger<PdfOfficeJobService> _logger;

        public PdfOfficeJobService(
            PdfOfficeProcessor processor,
            IJobResultStore jobStore,
            AzureBlobService blobService,
            ILogger<PdfOfficeJobService> logger)
        {
            _processor = processor;
            _jobStore = jobStore;
            _blobService = blobService;
            _logger = logger;
        }

        public async Task RunJobAsync(
            string jobId,
            string jobKind,
            OfficeConversionKind kind,
            string tempInputPath,
            string originalName,
            CancellationToken ct)
        {
            try
            {
                _jobStore.SetProgress(jobId, 10, "Preparing file…");

                await using var stream = new FileStream(tempInputPath, FileMode.Open, FileAccess.Read, FileShare.Read);
                var fileInfo = new FileInfo(tempInputPath);

                _jobStore.SetProgress(jobId, 25, "Running high-fidelity conversion…");
                var bytes = await _processor.ConvertAsync(kind, stream, originalName, ct);

                _jobStore.SetProgress(jobId, 85, "Uploading result…");

                var outputName = kind switch
                {
                    OfficeConversionKind.DocxToPdf => Path.GetFileNameWithoutExtension(originalName) + ".pdf",
                    OfficeConversionKind.PdfToXlsx => Path.GetFileNameWithoutExtension(originalName) + ".xlsx",
                    OfficeConversionKind.XlsxToPdf => Path.GetFileNameWithoutExtension(originalName) + ".pdf",
                    _ => "converted" + (kind == OfficeConversionKind.PdfToXlsx ? ".xlsx" : ".pdf"),
                };

                var mime = kind switch
                {
                    OfficeConversionKind.PdfToXlsx =>
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    _ => "application/pdf",
                };

                var blobName = $"{jobKind}/{jobId}/{outputName}";
                await using var upload = new MemoryStream(bytes);
                await _blobService.UploadAsync(upload, blobName, ct);

                _jobStore.SetFileJobCompleted(
                    jobId,
                    blobName,
                    mime,
                    outputName,
                    fileInfo.Length,
                    bytes.Length,
                    jobKind);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Office job {JobId} ({Kind}) failed", jobId, jobKind);
                _jobStore.SetFailed(jobId, ex.Message);
            }
            finally
            {
                try
                {
                    if (File.Exists(tempInputPath))
                        File.Delete(tempInputPath);
                }
                catch { /* best effort */ }
            }
        }
    }
}
