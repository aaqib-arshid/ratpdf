using DnsClient.Internal;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Data;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ratpdf.Constants;
using ratpdf.Models;
using ratpdf.Services;
using ratpdf.Services.CompressPDF;
using ratpdf.Services.PdfProcessing;
using ratpdf.Services.PdfTools;
using System.Text;
using System.Text.Json;

namespace ratpdf.Controllers
{
    public class PDFController : Controller
    {
        private readonly PdfConversionService _pdfService;
        private readonly LayoutEngineProcessor _processor;
        private readonly HtmlReconstructionService _reconstructionEngine;
        private readonly PdfCompressionService _compressionService;
        private readonly IConfiguration _config;
        private readonly IJobQueue _jobQueue;
        private readonly IJobResultStore _jobResultStore;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly AzureBlobService _blobService;
        private readonly PdfJobStorageService _jobStorage;
        private readonly PdfConversionFileOps _fileOps;
        private readonly PdfToolsAccessService _pdfToolsAccess;
        private readonly PdfEditProcessor _pdfEditProcessor;
        private readonly IPdfEditSessionStore _pdfEditSessions;
        private const long MaxFileSizeBytes = 1024L * 1024 * 1024; // 1 GB
        public PDFController(
            IConfiguration config,
            AzureBlobService azureBlobService,
            PdfJobStorageService jobStorage,
            PdfConversionFileOps fileOps,
            IJobQueue jobQueue,
            IJobResultStore jobResultStore,
            IServiceScopeFactory serviceScopeFactory,
            PdfConversionService pdfService,
            PdfCompressionService compressionService,
            LayoutEngineProcessor processor,
            HtmlReconstructionService reconstructionEngine,
            PdfToolsAccessService pdfToolsAccess,
            PdfEditProcessor pdfEditProcessor,
            IPdfEditSessionStore pdfEditSessions)
        {
            _pdfService = pdfService;
            _processor = processor;
            _reconstructionEngine = reconstructionEngine;
            _compressionService = compressionService;
            _config = config;
            _jobQueue = jobQueue;
            _jobResultStore = jobResultStore;
            _serviceScopeFactory = serviceScopeFactory;
            _blobService = azureBlobService;
            _jobStorage = jobStorage;
            _fileOps = fileOps;
            _pdfToolsAccess = pdfToolsAccess;
            _pdfEditProcessor = pdfEditProcessor;
            _pdfEditSessions = pdfEditSessions;
        }
        #region --GET METHODS--
        public IActionResult ConvertImages()
        {
            var model = new ImageUploadViewModel();
            return View(model);
        }
        public IActionResult Merge() => View();
        public IActionResult Split() => View();
        public IActionResult Compress() => View();

        /// <summary>SEO-friendly canonical URL for the hero PDF compressor tool.</summary>
        [HttpGet("/pdf/compress")]
        public IActionResult CompressCanonical()
        {
            ViewData["CanonicalUrl"] = PdfToolSeo.Canonical("/pdf/compress");
            return View("Compress");
        }

        public IActionResult TextToPdf() => View();

        [HttpGet("/pdf/htmltopdf")]
        public IActionResult HtmlToPdf()
        {
            ViewData["CanonicalUrl"] = PdfToolSeo.Canonical("/pdf/htmltopdf");
            return View();
        }

        public IActionResult PdfToText() => View();

        [HttpGet("/pdf/pdftomarkdown")]
        public IActionResult PdfToMarkdown()
        {
            ViewData["CanonicalUrl"] = PdfToolSeo.Canonical("/pdf/pdftomarkdown");
            return View();
        }

        public IActionResult Watermark() => View();
        public IActionResult Password() => View();
        public IActionResult DocToPdf() => View();
        public IActionResult PdfToDoc() => View();
        public IActionResult SignText() => View();
        public IActionResult RotateOrRemove() => View();
        [HttpGet]
        public IActionResult UnlockPdf() => View();
        [HttpGet]
        public IActionResult FlattenPdf() => View();
        [HttpGet]
        public IActionResult PdfToImages() => View();
        [HttpGet]
        public IActionResult ExtractImages() => View();
        [HttpGet]
        public IActionResult OcrPdf() => View();
        [HttpGet]
        public IActionResult PageNumbers() => View();
        [HttpGet]
        public IActionResult PdfMetadata() => View();
        public IActionResult PdfToExcel() => View();
        public IActionResult ExcelToPdf() => View();
        public IActionResult PdfToPpt() => View();
        public IActionResult PptToPdf() => View();
        public IActionResult ImgToBase64() => View();
        public IActionResult HtmlFormatter() => View();
        public IActionResult JsonFormatter() => View();
        public IActionResult JwtDecoder() => View();
        public IActionResult ImageCompressor() => View();
        /// <summary>SEO-friendly canonical URL for the PDF editor studio.</summary>
        [HttpGet("/pdf/editpdf")]
        public IActionResult EditPDF()
        {
            return View(new PdfEditViewModel
            {
                SessionId = HttpContext.Session.GetString("PdfEditSessionId"),
                OriginalFileName = HttpContext.Session.GetString("PdfEditFileName"),
            });
        }
        #endregion
        #region --POST--

        [HttpPost]
        [RequestSizeLimit(PdfToolLimits.MaxUploadRequestBytes)]
        [RequestFormLimits(MultipartBodyLengthLimit = PdfToolLimits.MaxUploadRequestBytes)]
        public async Task<IActionResult> ConvertImages([FromForm] List<IFormFile> files)
        {
            if (files == null || files.Count == 0)
                return BadRequest(new { error = "No image selected. Please select at least one image." });

            var validation = await ValidateJobFilesAsync(files, PdfToolIds.ConvertImages, "image", ".jpg", ".jpeg", ".png", ".gif", ".webp", ".bmp");
            if (validation.Error != null)
                return validation.Error;

            var jobId = Guid.NewGuid().ToString();
            var inputs = new List<(string StagingBlobName, string OriginalName, long Size)>();
            foreach (var file in validation.Files!)
            {
                var blob = await _jobStorage.StageFormFileAsync(file, jobId);
                inputs.Add((blob, file.FileName, file.Length));
            }

            return await QueueItextJobAsync(jobId, PdfToolIds.ConvertImages, "convertimages", inputs, async (svc, ct) =>
                await svc.RunConvertImagesJobAsync(jobId, inputs, ct));
        }

        [HttpPost]
        [RequestSizeLimit(PdfToolLimits.MergeMaxUploadRequestBytes)]
        [RequestFormLimits(MultipartBodyLengthLimit = PdfToolLimits.MergeMaxUploadRequestBytes)]
        public async Task<IActionResult> Merge([FromForm] List<IFormFile> files)
        {
            if (files == null || files.Count < 2)
                return BadRequest(new { error = "Please select at least 2 PDF files to merge." });

            var validation = await ValidateJobFilesAsync(files, PdfToolIds.Merge, "PDF", ".pdf");
            if (validation.Error != null)
                return validation.Error;

            var jobId = Guid.NewGuid().ToString();
            var inputs = new List<(string StagingBlobName, string OriginalName, long Size)>();
            foreach (var file in validation.Files!)
            {
                var blob = await _jobStorage.StageFormFileAsync(file, jobId);
                inputs.Add((blob, file.FileName, file.Length));
            }

            return await QueueItextJobAsync(jobId, PdfToolIds.Merge, "merge", inputs, async (svc, ct) =>
                await svc.RunMergeJobAsync(jobId, inputs, ct));
        }

        [HttpPost]
        [RequestSizeLimit(PdfToolLimits.MaxUploadRequestBytes)]
        [RequestFormLimits(MultipartBodyLengthLimit = PdfToolLimits.MaxUploadRequestBytes)]
        public async Task<IActionResult> Split(IFormFile file, int startPage, int endPage)
        {
            var validation = await ValidateJobFilesAsync(
                file == null ? null : new List<IFormFile> { file },
                PdfToolIds.Split,
                "PDF",
                ".pdf");
            if (validation.Error != null)
                return validation.Error;

            file = validation.Files![0];
            var jobId = Guid.NewGuid().ToString();
            var stagingBlob = await _jobStorage.StageFormFileAsync(file, jobId);

            return await QueueItextJobAsync(jobId, PdfToolIds.Split, "split",
                new[] { (stagingBlob, file.FileName, file.Length) },
                async (svc, ct) => await svc.RunSplitJobAsync(
                    jobId, stagingBlob, file.FileName, file.Length, startPage, endPage, ct));
        }
        [HttpPost]
        [RequestSizeLimit(PdfToolLimits.MaxUploadRequestBytes)]
        [RequestFormLimits(MultipartBodyLengthLimit = PdfToolLimits.MaxUploadRequestBytes)]
        public async Task<IActionResult> Compress(
        IFormFile? file,
        [FromForm] string? compressionLevel, [FromForm] string? password)
        {
            var validation = await ValidateJobFilesAsync(
                file == null ? null : new List<IFormFile> { file },
                PdfToolIds.Compress,
                "PDF",
                ".pdf");
            if (validation.Error != null)
                return validation.Error;

            file = validation.Files![0];

            var jobId = Guid.NewGuid().ToString();
            var stagingBlob = await _jobStorage.StageFormFileAsync(file, jobId);

            var level = compressionLevel?.ToLowerInvariant() switch
            {
                "extreme" => CompressionLevel.Extreme,
                "less" => CompressionLevel.Less,
                _ => CompressionLevel.Recommended,
            };
            _jobResultStore.CreateJob(jobId);
            await _pdfToolsAccess.RecordUsageAsync(PdfToolIds.Compress, 1);

            _jobQueue.Queue(async ct =>
            {
                using var scope = _serviceScopeFactory.CreateScope();
                var compressionService = scope.ServiceProvider
                    .GetRequiredService<PdfCompressionService>();
                var resultStore = scope.ServiceProvider
                    .GetRequiredService<IJobResultStore>();
                var blobService = scope.ServiceProvider       
                    .GetRequiredService<AzureBlobService>();

                string? tempInputPath = null;
                try
                {
                    var jobStorage = scope.ServiceProvider.GetRequiredService<PdfJobStorageService>();
                    tempInputPath = await jobStorage.MaterializeToTempFileAsync(stagingBlob, ".pdf", ct);

                    var result = await compressionService.CompressFromFileAsync(
                        tempInputPath, level, password, blobService, jobId, ct);

                    resultStore.SetCompleted(jobId, result.BlobName,
                        result.OriginalSize, result.CompressedSize, result.ReductionPct);
                }
                catch (UnauthorizedAccessException)
                {
                    resultStore.SetFailed(jobId,
                        "Incorrect PDF password.");
                }
                catch (Exception ex)
                {
                    scope.ServiceProvider.GetRequiredService<ILogger<PDFController>>()
                        .LogError(ex, "Compress job {JobId} failed", jobId);
                    resultStore.SetFailed(jobId, UserFacingErrorMapper.FromException(ex));
                }
                finally
                {
                    PdfJobStorageService.TryDeleteLocalFile(tempInputPath);
                    try { await scope.ServiceProvider.GetRequiredService<PdfJobStorageService>().DeleteStagingAsync(stagingBlob, ct); }
                    catch { }
                }
            });

            return Accepted(new
            {
                jobId,
                statusUrl = Url.Action(nameof(GetJobStatus), new { jobId }),
                downloadUrl = Url.Action(nameof(DownloadResult), new { jobId })
            });
        }
        [HttpGet("/PDF/status/{jobId}")]
        public IActionResult GetJobStatus(string jobId)
        {
            var job = _jobResultStore.GetJob(jobId);
            if (job == null) return NotFound(new { error = "Job not found" });

            return Ok(new
            {
                jobId,
                status = job.Status,
                jobKind = job.JobKind,
                progressPercent = job.ProgressPercent,
                progressMessage = job.ProgressMessage,
                originalSize = job.OriginalSize,
                compressedSize = job.CompressedSize,
                reductionPercent = job.ReductionPercent,
                outputFileName = job.OutputFileName,
                outputMimeType = job.OutputMimeType,
                error = UserFacingErrorMapper.Sanitize(job.ErrorMessage)
            });
        }

        [HttpGet("/PDF/download/{jobId}")]
        public async Task<IActionResult> DownloadResult(string jobId)
        {
            var job = _jobResultStore.GetJob(jobId);
            if (job == null) return NotFound();
            if (job.Status != "Completed")
                return BadRequest(new { error = "Job not completed yet" });
            if (string.IsNullOrEmpty(job.BlobName))
                return NotFound(new { error = "Result already downloaded or not found" });

            try
            {
                var blobName = job.BlobName;
                _jobResultStore.ClearResultBlob(jobId);

                var inner = await _blobService.OpenReadAsync(blobName);
                var stream = new BlobDeletingStream(inner, async () =>
                {
                    await _blobService.DeleteAsync(blobName);
                });

                var mime = job.OutputMimeType ?? "application/pdf";
                var name = job.OutputFileName ?? job.JobKind switch
                {
                    "pdf2docx" => "converted.docx",
                    "pdftoxlsx" => "converted.xlsx",
                    "pdf2pptx" => "converted.pptx",
                    "doctopdf" or "exceltopdf" or "ppttopdf" => "converted.pdf",
                    "pdftotext" => "extracted.txt",
                    "merge" => "merged.pdf",
                    "split" => "split.pdf",
                    "watermark" => "watermarked.pdf",
                    "password" => "protected.pdf",
                    "signpdf" => "signed.pdf",
                    "rotate" => "edited.pdf",
                    "convertimages" => "images.pdf",
                    "texttopdf" => "document.pdf",
                    "unlockpdf" => "unlocked.pdf",
                    "flattenpdf" => "flattened.pdf",
                    "pdftoimages" => "pages.zip",
                    "extractimages" => "images.zip",
                    "ocrpdf" => "searchable.pdf",
                    "pagenumbers" => "numbered.pdf",
                    "pdfmetadata" => "metadata.json",
                    "editpdf" => "edited.pdf",
                    _ => "compressed.pdf",
                };
                return File(stream, mime, name, enableRangeProcessing: true);
            }
            catch
            {
                return NotFound(new { error = "Result file could not be retrieved from storage" });
            }
        }

        [HttpGet("/PDF/tool-access")]
        public async Task<IActionResult> ToolAccess([FromQuery] string tool)
        {
            if (string.IsNullOrWhiteSpace(tool))
                return BadRequest(new { error = "Tool id required" });

            var status = await _pdfToolsAccess.GetStatusAsync(tool);
            var limits = await _pdfToolsAccess.GetLimitsForToolAsync(tool);
            return Ok(new
            {
                allowed = status.Allowed,
                isPremium = status.IsPremium,
                remaining = status.RemainingFreeUses,
                usedToday = status.UsedToday,
                emailCaptured = status.EmailCaptured,
                emailDismissed = status.EmailDismissed,
                emailCaptureAfter = PdfToolsAccessService.EmailCaptureAfterUses,
                denyReason = status.DenyReason,
                maxFileSizeBytes = limits.MaxFileSizeBytes,
                maxBatchFiles = limits.MaxBatchFiles,
                maxFileSizeLabel = limits.MaxFileSizeLabel,
                maxTotalBatchBytes = limits.MaxTotalBatchBytes,
                maxTotalBatchLabel = limits.MaxTotalBatchLabel,
            });
        }

        [HttpPost("/pdf/tool-lead")]
        public IActionResult SaveToolLead([FromForm] string email)
        {
            if (!_pdfToolsAccess.SaveLeadEmail(email))
                return BadRequest(new { error = "Please enter a valid email address." });
            return Ok(new { ok = true });
        }

        [HttpPost("/pdf/tool-lead/dismiss")]
        public IActionResult DismissToolLead()
        {
            _pdfToolsAccess.DismissEmailCapture();
            return Ok(new { ok = true });
        }

        [HttpPost("/PDF/PdfToDoc/convert")]
        [RequestSizeLimit(PdfToolLimits.MaxUploadRequestBytes)]
        [RequestFormLimits(MultipartBodyLengthLimit = PdfToolLimits.MaxUploadRequestBytes)]
        public async Task<IActionResult> PdfToDocConvert([FromForm] List<IFormFile> files)
        {
            var validation = await ValidateJobFilesAsync(files, PdfToolIds.PdfToDoc, "PDF", ".pdf");
            if (validation.Error != null) return validation.Error;
            files = validation.Files!;

            var jobId = Guid.NewGuid().ToString();
            var inputs = new List<(string StagingBlobName, string OriginalName, long Size)>();

            foreach (var file in files)
            {
                var stagingBlob = await _jobStorage.StageFormFileAsync(file, jobId);
                inputs.Add((stagingBlob, file.FileName, file.Length));
            }

            _jobResultStore.CreateJob(jobId, "pdf2docx");
            await _pdfToolsAccess.RecordUsageAsync(PdfToolIds.PdfToDoc, files.Count);

            _jobQueue.Queue(async ct =>
            {
                using var scope = _serviceScopeFactory.CreateScope();
                var jobService = scope.ServiceProvider.GetRequiredService<PdfToDocxJobService>();
                await jobService.RunConversionJobAsync(jobId, inputs, ct);
            });

            return Accepted(new
            {
                jobId,
                statusUrl = Url.Action(nameof(GetJobStatus), new { jobId }),
                downloadUrl = Url.Action(nameof(DownloadResult), new { jobId })
            });
        }

        [HttpPost("/PDF/DocToPdf/convert")]
        [RequestSizeLimit(PdfToolLimits.MaxUploadRequestBytes)]
        [RequestFormLimits(MultipartBodyLengthLimit = PdfToolLimits.MaxUploadRequestBytes)]
        public async Task<IActionResult> DocToPdfConvert([FromForm] IFormFile file)
        {
            var validation = await ValidateJobFilesAsync(
                file == null ? null : new List<IFormFile> { file },
                PdfToolIds.DocToPdf, "Word DOCX", ".docx");
            if (validation.Error != null) return validation.Error;

            return await QueueOfficeJobAsync(
                validation.Files![0],
                PdfToolIds.DocToPdf,
                "doctopdf",
                OfficeConversionKind.DocxToPdf);
        }

        [HttpPost("/PDF/PdfToExcel/convert")]
        [RequestSizeLimit(PdfToolLimits.MaxUploadRequestBytes)]
        [RequestFormLimits(MultipartBodyLengthLimit = PdfToolLimits.MaxUploadRequestBytes)]
        public async Task<IActionResult> PdfToExcelConvert([FromForm] IFormFile file)
        {
            var validation = await ValidateJobFilesAsync(
                file == null ? null : new List<IFormFile> { file },
                PdfToolIds.PdfToExcel, "PDF", ".pdf");
            if (validation.Error != null) return validation.Error;

            return await QueueOfficeJobAsync(
                validation.Files![0],
                PdfToolIds.PdfToExcel,
                "pdftoxlsx",
                OfficeConversionKind.PdfToXlsx);
        }

        [HttpPost("/PDF/PdfToPpt/convert")]
        [RequestSizeLimit(PdfToolLimits.MaxUploadRequestBytes)]
        [RequestFormLimits(MultipartBodyLengthLimit = PdfToolLimits.MaxUploadRequestBytes)]
        public async Task<IActionResult> PdfToPptConvert([FromForm] IFormFile file)
        {
            var validation = await ValidateJobFilesAsync(
                file == null ? null : new List<IFormFile> { file },
                PdfToolIds.PdfToPpt, "PDF", ".pdf");
            if (validation.Error != null) return validation.Error;

            return await QueueOfficeJobAsync(
                validation.Files![0],
                PdfToolIds.PdfToPpt,
                "pdf2pptx",
                OfficeConversionKind.PdfToPptx);
        }

        [HttpPost("/PDF/PptToPdf/convert")]
        [RequestSizeLimit(PdfToolLimits.MaxUploadRequestBytes)]
        [RequestFormLimits(MultipartBodyLengthLimit = PdfToolLimits.MaxUploadRequestBytes)]
        public async Task<IActionResult> PptToPdfConvert([FromForm] IFormFile file)
        {
            var validation = await ValidateJobFilesAsync(
                file == null ? null : new List<IFormFile> { file },
                PdfToolIds.PptToPdf, "PowerPoint", ".pptx", ".ppt");
            if (validation.Error != null) return validation.Error;

            return await QueueOfficeJobAsync(
                validation.Files![0],
                PdfToolIds.PptToPdf,
                "ppttopdf",
                OfficeConversionKind.PptxToPdf);
        }

        [HttpPost("/PDF/ExcelToPdf/convert")]
        [RequestSizeLimit(PdfToolLimits.MaxUploadRequestBytes)]
        [RequestFormLimits(MultipartBodyLengthLimit = PdfToolLimits.MaxUploadRequestBytes)]
        public async Task<IActionResult> ExcelToPdfConvert([FromForm] IFormFile file)
        {
            var validation = await ValidateJobFilesAsync(
                file == null ? null : new List<IFormFile> { file },
                PdfToolIds.ExcelToPdf, "Excel", ".xlsx", ".xls");
            if (validation.Error != null) return validation.Error;

            return await QueueOfficeJobAsync(
                validation.Files![0],
                PdfToolIds.ExcelToPdf,
                "exceltopdf",
                OfficeConversionKind.XlsxToPdf);
        }

        [HttpGet("/PDF/cleanup-temp")]
        public async Task<IActionResult> CleanupTemp([FromQuery] string key)
        {
            var expectedKey = _config["AdminCleanupSecretKey"];
            if (string.IsNullOrEmpty(key) || key != expectedKey)
                return NotFound();

            var maxAge = TimeSpan.FromMinutes(30);
            var (deleted, failed, bytesFreed) = await _blobService
                .CleanupOldBlobsAsync(maxAge);

            var html = $"""
        <!DOCTYPE html>
        <html>
        <head><title>RatPDF Blob Cleanup</title></head>
        <body>
            <h2>🧹 RatPDF Blob Storage Cleanup</h2>
            <p>✅ Deleted : {deleted} blobs</p>
            <p>❌ Failed  : {failed} blobs</p>
            <p>💾 Freed   : {bytesFreed / 1024.0 / 1024.0:F2} MB</p>
            <p>🕐 Run at  : {DateTime.UtcNow:yyyy-MM-dd HH:mm:ss} UTC</p>
        </body>
        </html>
        """;

            return Content(html, "text/html");
        }
        [HttpPost]
        [RequestSizeLimit(PdfToolLimits.MaxUploadRequestBytes)]
        [RequestFormLimits(MultipartBodyLengthLimit = PdfToolLimits.MaxUploadRequestBytes)]
        public async Task<IActionResult> TextToPdf(IFormFile? file, string? typedText)
        {
            var access = await _pdfToolsAccess.CheckAccessAsync(PdfToolIds.TextToPdf, 1);
            if (!access.Allowed)
                return StatusCode(402, new { error = access.DenyReason, paywall = true });

            if (file != null && file.Length == 0)
                file = null;

            if (file == null && (string.IsNullOrWhiteSpace(typedText) || typedText.Equals("<p><br></p>", StringComparison.OrdinalIgnoreCase)))
                return BadRequest(new { error = "Please upload a text file or type some text." });

            var jobId = Guid.NewGuid().ToString();
            string? stagingBlob = null;
            long inputSize = 0;

            if (file != null)
            {
                if (file.Length > (await _pdfToolsAccess.GetLimitsForToolAsync(PdfToolIds.TextToPdf)).MaxFileSizeBytes)
                    return BadRequest(new { error = "File exceeds size limit." });
                stagingBlob = await _jobStorage.StageFormFileAsync(file, jobId);
                inputSize = file.Length;
            }

            var html = typedText;
            return await QueueItextJobAsync(jobId, PdfToolIds.TextToPdf, "texttopdf",
                stagingBlob == null ? Array.Empty<(string, string, long)>() : new[] { (stagingBlob, file!.FileName, file.Length) },
                async (svc, ct) => await svc.RunTextToPdfJobAsync(jobId, stagingBlob, inputSize, html, ct));
        }

        [HttpPost("/pdf/htmltopdf")]
        [RequestSizeLimit(PdfToolLimits.MaxUploadRequestBytes)]
        [RequestFormLimits(MultipartBodyLengthLimit = PdfToolLimits.MaxUploadRequestBytes)]
        public async Task<IActionResult> HtmlToPdf(IFormFile? file, string? htmlContent)
        {
            var access = await _pdfToolsAccess.CheckAccessAsync(PdfToolIds.HtmlToPdf, 1);
            if (!access.Allowed)
                return StatusCode(402, new { error = access.DenyReason, paywall = true });

            if (file != null && file.Length == 0)
                file = null;

            if (file == null && (string.IsNullOrWhiteSpace(htmlContent) || htmlContent.Equals("<p><br></p>", StringComparison.OrdinalIgnoreCase)))
                return BadRequest(new { error = "Please upload an HTML file or paste HTML content." });

            var jobId = Guid.NewGuid().ToString();
            string? stagingBlob = null;
            long inputSize = 0;

            if (file != null)
            {
                if (file.Length > (await _pdfToolsAccess.GetLimitsForToolAsync(PdfToolIds.HtmlToPdf)).MaxFileSizeBytes)
                    return BadRequest(new { error = "File exceeds size limit." });
                stagingBlob = await _jobStorage.StageFormFileAsync(file, jobId);
                inputSize = file.Length;
            }
            else
            {
                inputSize = Encoding.UTF8.GetByteCount(htmlContent!);
            }

            return await QueueItextJobAsync(jobId, PdfToolIds.HtmlToPdf, "htmltopdf",
                stagingBlob == null ? Array.Empty<(string, string, long)>() : new[] { (stagingBlob, file!.FileName, file.Length) },
                async (svc, ct) => await svc.RunHtmlToPdfJobAsync(jobId, stagingBlob, inputSize, htmlContent, ct));
        }

        [HttpPost]
        [RequestSizeLimit(PdfToolLimits.MaxUploadRequestBytes)]
        [RequestFormLimits(MultipartBodyLengthLimit = PdfToolLimits.MaxUploadRequestBytes)]
        public async Task<IActionResult> PdfToText(IFormFile file)
        {
            var validation = await ValidateJobFilesAsync(
                file == null ? null : new List<IFormFile> { file },
                PdfToolIds.PdfToText, "PDF", ".pdf");
            if (validation.Error != null)
                return validation.Error;

            file = validation.Files![0];
            var jobId = Guid.NewGuid().ToString();
            var stagingBlob = await _jobStorage.StageFormFileAsync(file, jobId);

            return await QueueItextJobAsync(jobId, PdfToolIds.PdfToText, "pdftotext",
                new[] { (stagingBlob, file.FileName, file.Length) },
                async (svc, ct) => await svc.RunPdfToTextJobAsync(jobId, stagingBlob, file.FileName, file.Length, ct));
        }

        [HttpPost]
        [RequestSizeLimit(PdfToolLimits.MaxUploadRequestBytes)]
        [RequestFormLimits(MultipartBodyLengthLimit = PdfToolLimits.MaxUploadRequestBytes)]
        public async Task<IActionResult> PdfToMarkdown(IFormFile file)
        {
            var validation = await ValidateJobFilesAsync(
                file == null ? null : new List<IFormFile> { file },
                PdfToolIds.PdfToMarkdown, "PDF", ".pdf");
            if (validation.Error != null)
                return validation.Error;

            file = validation.Files![0];
            var jobId = Guid.NewGuid().ToString();
            var stagingBlob = await _jobStorage.StageFormFileAsync(file, jobId);

            return await QueueItextJobAsync(jobId, PdfToolIds.PdfToMarkdown, "pdftomarkdown",
                new[] { (stagingBlob, file.FileName, file.Length) },
                async (svc, ct) => await svc.RunPdfToMarkdownJobAsync(jobId, stagingBlob, file.FileName, file.Length, ct));
        }

        [HttpPost]
        [RequestSizeLimit(PdfToolLimits.MaxUploadRequestBytes)]
        [RequestFormLimits(MultipartBodyLengthLimit = PdfToolLimits.MaxUploadRequestBytes)]
        public async Task<IActionResult> Watermark(IFormFile file, string watermarkText)
        {
            if (file == null || string.IsNullOrWhiteSpace(watermarkText))
                return BadRequest(new { error = "Upload PDF and provide watermark text." });

            var validation = await ValidateJobFilesAsync(new List<IFormFile> { file }, PdfToolIds.Watermark, "PDF", ".pdf");
            if (validation.Error != null)
                return validation.Error;

            file = validation.Files![0];
            var jobId = Guid.NewGuid().ToString();
            var stagingBlob = await _jobStorage.StageFormFileAsync(file, jobId);
            var text = watermarkText;

            return await QueueItextJobAsync(jobId, PdfToolIds.Watermark, "watermark",
                new[] { (stagingBlob, file.FileName, file.Length) },
                async (svc, ct) => await svc.RunWatermarkJobAsync(
                    jobId, stagingBlob, file.FileName, file.Length, text, ct));
        }

        [HttpPost]
        [RequestSizeLimit(PdfToolLimits.MaxUploadRequestBytes)]
        [RequestFormLimits(MultipartBodyLengthLimit = PdfToolLimits.MaxUploadRequestBytes)]
        public async Task<IActionResult> Password(IFormFile file, string password)
        {
            if (file == null || string.IsNullOrWhiteSpace(password))
                return BadRequest(new { error = "Upload PDF and enter a password." });

            var validation = await ValidateJobFilesAsync(new List<IFormFile> { file }, PdfToolIds.Password, "PDF", ".pdf");
            if (validation.Error != null)
                return validation.Error;

            file = validation.Files![0];
            var jobId = Guid.NewGuid().ToString();
            var stagingBlob = await _jobStorage.StageFormFileAsync(file, jobId);
            var pwd = password;

            return await QueueItextJobAsync(jobId, PdfToolIds.Password, "password",
                new[] { (stagingBlob, file.FileName, file.Length) },
                async (svc, ct) => await svc.RunPasswordJobAsync(jobId, stagingBlob, file.Length, pwd, ct));
        }

        [HttpPost]
        [RequestSizeLimit(PdfToolLimits.MaxUploadRequestBytes)]
        [RequestFormLimits(MultipartBodyLengthLimit = PdfToolLimits.MaxUploadRequestBytes)]
        public Task<IActionResult> DocToPdf(IFormFile file) =>
            DocToPdfConvert(file);

        [HttpPost]
        [RequestSizeLimit(PdfToolLimits.MaxUploadRequestBytes)]
        [RequestFormLimits(MultipartBodyLengthLimit = PdfToolLimits.MaxUploadRequestBytes)]
        public Task<IActionResult> PdfToDoc([FromForm] List<IFormFile> files) =>
            PdfToDocConvert(files);

        [HttpPost]
        [RequestSizeLimit(PdfToolLimits.MaxUploadRequestBytes)]
        [RequestFormLimits(MultipartBodyLengthLimit = PdfToolLimits.MaxUploadRequestBytes)]
        public async Task<IActionResult> SignText(IFormFile file, string name)
        {
            if (file == null)
                return BadRequest(new { error = "Please upload a PDF." });
            if (string.IsNullOrWhiteSpace(name))
                return BadRequest(new { error = "Please enter a name for signature." });

            var validation = await ValidateJobFilesAsync(new List<IFormFile> { file }, PdfToolIds.SignPdf, "PDF", ".pdf");
            if (validation.Error != null)
                return validation.Error;

            file = validation.Files![0];
            var jobId = Guid.NewGuid().ToString();
            var stagingBlob = await _jobStorage.StageFormFileAsync(file, jobId);
            var signerName = name;

            return await QueueItextJobAsync(jobId, PdfToolIds.SignPdf, "signpdf",
                new[] { (stagingBlob, file.FileName, file.Length) },
                async (svc, ct) => await svc.RunSignJobAsync(jobId, stagingBlob, file.Length, signerName, ct));
        }
        [HttpPost]
        public async Task<IActionResult> AddText(IFormFile file, string text, int pageNumber = 0)
        {
            var access = await _pdfToolsAccess.CheckAccessAsync(PdfToolIds.EditPdf, 1);
            if (!access.Allowed)
            {
                AddPaywallError(access.DenyReason);
                return RedirectToAction(nameof(EditPDF));
            }

            if (file == null || string.IsNullOrWhiteSpace(text))
            {
                ModelState.AddModelError("", "PDF file or text missing.");
                return RedirectToAction(nameof(EditPDF));
            }
            return await RunInlinePdfEditAsync(file, PdfToolIds.EditPdf, async (pdfPath, ct) =>
            {
                await Task.CompletedTask;
                return _fileOps.AddTextFromPath(pdfPath, text, pageNumber);
            });
        }

        [HttpPost]
        public async Task<IActionResult> AddImage(IFormFile file, IFormFile image, int pageNumber = 0)
        {
            var access = await _pdfToolsAccess.CheckAccessAsync(PdfToolIds.EditPdf, 1);
            if (!access.Allowed)
            {
                AddPaywallError(access.DenyReason);
                return RedirectToAction(nameof(EditPDF));
            }

            if (file == null || image == null)
            {
                ModelState.AddModelError("", "PDF or image missing.");
                return RedirectToAction(nameof(EditPDF));
            }

            return await RunInlinePdfEditAsync(file, PdfToolIds.EditPdf, async (pdfPath, ct) =>
            {
                var imagePath = PdfTempPaths.NewOutput(Path.GetExtension(image.FileName));
                await using (var fs = new FileStream(imagePath, FileMode.Create))
                    await image.CopyToAsync(fs, ct);
                try
                {
                    return _fileOps.AddImageFromPath(pdfPath, imagePath, pageNumber);
                }
                finally
                {
                    PdfJobStorageService.TryDeleteLocalFile(imagePath);
                }
            });
        }

        [HttpPost]
        [RequestSizeLimit(PdfToolLimits.MaxUploadRequestBytes)]
        [RequestFormLimits(MultipartBodyLengthLimit = PdfToolLimits.MaxUploadRequestBytes)]
        public async Task<IActionResult> RotatePage(IFormFile file, int pageNumber = 0, int degree = 90)
        {
            if (file == null)
                return BadRequest(new { error = "PDF missing." });

            var validation = await ValidateJobFilesAsync(new List<IFormFile> { file }, PdfToolIds.Rotate, "PDF", ".pdf");
            if (validation.Error != null)
                return validation.Error;

            file = validation.Files![0];
            var jobId = Guid.NewGuid().ToString();
            var stagingBlob = await _jobStorage.StageFormFileAsync(file, jobId);

            return await QueueItextJobAsync(jobId, PdfToolIds.Rotate, "rotate",
                new[] { (stagingBlob, file.FileName, file.Length) },
                async (svc, ct) => await svc.RunRotateJobAsync(
                    jobId, stagingBlob, file.Length, pageNumber, degree, ct));
        }

        [HttpPost]
        [RequestSizeLimit(PdfToolLimits.MaxUploadRequestBytes)]
        [RequestFormLimits(MultipartBodyLengthLimit = PdfToolLimits.MaxUploadRequestBytes)]
        public async Task<IActionResult> RemovePage(IFormFile file, int pageNumber = 0)
        {
            if (file == null)
                return BadRequest(new { error = "PDF missing." });

            var validation = await ValidateJobFilesAsync(new List<IFormFile> { file }, PdfToolIds.Rotate, "PDF", ".pdf");
            if (validation.Error != null)
                return validation.Error;

            file = validation.Files![0];
            var jobId = Guid.NewGuid().ToString();
            var stagingBlob = await _jobStorage.StageFormFileAsync(file, jobId);

            return await QueueItextJobAsync(jobId, PdfToolIds.Rotate, "rotate",
                new[] { (stagingBlob, file.FileName, file.Length) },
                async (svc, ct) => await svc.RunRemovePageJobAsync(
                    jobId, stagingBlob, file.Length, pageNumber, ct));
        }

        [HttpPost]
        [RequestSizeLimit(PdfToolLimits.MaxUploadRequestBytes)]
        [RequestFormLimits(MultipartBodyLengthLimit = PdfToolLimits.MaxUploadRequestBytes)]
        public Task<IActionResult> PdfToExcel(IFormFile file) =>
            PdfToExcelConvert(file);

        [HttpPost]
        [RequestSizeLimit(PdfToolLimits.MaxUploadRequestBytes)]
        [RequestFormLimits(MultipartBodyLengthLimit = PdfToolLimits.MaxUploadRequestBytes)]
        public Task<IActionResult> ExcelToPdf(IFormFile file) =>
            ExcelToPdfConvert(file);

        [HttpPost]
        [RequestSizeLimit(PdfToolLimits.MaxUploadRequestBytes)]
        [RequestFormLimits(MultipartBodyLengthLimit = PdfToolLimits.MaxUploadRequestBytes)]
        public Task<IActionResult> PdfToPpt(IFormFile file) =>
            PdfToPptConvert(file);

        [HttpPost]
        [RequestSizeLimit(PdfToolLimits.MaxUploadRequestBytes)]
        [RequestFormLimits(MultipartBodyLengthLimit = PdfToolLimits.MaxUploadRequestBytes)]
        public Task<IActionResult> PptToPdf(IFormFile file) =>
            PptToPdfConvert(file);

        [HttpPost]
        [RequestSizeLimit(PdfToolLimits.MaxUploadRequestBytes)]
        [RequestFormLimits(MultipartBodyLengthLimit = PdfToolLimits.MaxUploadRequestBytes)]
        public async Task<IActionResult> UnlockPdf(IFormFile file, string? password)
        {
            var validation = await ValidateJobFilesAsync(
                file == null ? null : new List<IFormFile> { file }, PdfToolIds.UnlockPdf, "PDF", ".pdf");
            if (validation.Error != null) return validation.Error;
            file = validation.Files![0];
            var jobId = Guid.NewGuid().ToString();
            var stagingBlob = await _jobStorage.StageFormFileAsync(file, jobId);
            var pwd = password;
            return await QueueExtendedJobAsync(jobId, PdfToolIds.UnlockPdf, "unlockpdf",
                new[] { (stagingBlob, file.FileName, file.Length) },
                async (svc, ct) => await svc.RunUnlockJobAsync(jobId, stagingBlob, file.Length, pwd, ct));
        }

        [HttpPost]
        [RequestSizeLimit(PdfToolLimits.MaxUploadRequestBytes)]
        [RequestFormLimits(MultipartBodyLengthLimit = PdfToolLimits.MaxUploadRequestBytes)]
        [HttpPost]
        public async Task<IActionResult> FlattenPdf(IFormFile file)
        {
            var validation = await ValidateJobFilesAsync(
                file == null ? null : new List<IFormFile> { file }, PdfToolIds.FlattenPdf, "PDF", ".pdf");
            if (validation.Error != null) return validation.Error;
            file = validation.Files![0];
            var jobId = Guid.NewGuid().ToString();
            var stagingBlob = await _jobStorage.StageFormFileAsync(file, jobId);
            return await QueueExtendedJobAsync(jobId, PdfToolIds.FlattenPdf, "flattenpdf",
                new[] { (stagingBlob, file.FileName, file.Length) },
                async (svc, ct) => await svc.RunFlattenJobAsync(jobId, stagingBlob, file.Length, ct));
        }

        [HttpPost]
        [RequestSizeLimit(PdfToolLimits.MaxUploadRequestBytes)]
        [RequestFormLimits(MultipartBodyLengthLimit = PdfToolLimits.MaxUploadRequestBytes)]
        [HttpPost]
        public async Task<IActionResult> PdfToImages(IFormFile file, int dpi = 150, string format = "jpg", int quality = 90)
        {
            var validation = await ValidateJobFilesAsync(
                file == null ? null : new List<IFormFile> { file }, PdfToolIds.PdfToImages, "PDF", ".pdf");
            if (validation.Error != null) return validation.Error;
            file = validation.Files![0];
            var jobId = Guid.NewGuid().ToString();
            var stagingBlob = await _jobStorage.StageFormFileAsync(file, jobId);
            dpi = Math.Clamp(dpi, 72, 300);
            format = format?.Equals("png", StringComparison.OrdinalIgnoreCase) == true ? "png" : "jpg";
            quality = Math.Clamp(quality, 50, 100);
            return await QueueExtendedJobAsync(jobId, PdfToolIds.PdfToImages, "pdftoimages",
                new[] { (stagingBlob, file.FileName, file.Length) },
                async (svc, ct) => await svc.RunPdfToImagesJobAsync(
                    jobId, stagingBlob, file.Length, dpi, format, quality, ct));
        }

        [HttpPost]
        [RequestSizeLimit(PdfToolLimits.MaxUploadRequestBytes)]
        [RequestFormLimits(MultipartBodyLengthLimit = PdfToolLimits.MaxUploadRequestBytes)]
        [HttpPost]
        public async Task<IActionResult> ExtractImages(IFormFile file)
        {
            var validation = await ValidateJobFilesAsync(
                file == null ? null : new List<IFormFile> { file }, PdfToolIds.ExtractImages, "PDF", ".pdf");
            if (validation.Error != null) return validation.Error;
            file = validation.Files![0];
            var jobId = Guid.NewGuid().ToString();
            var stagingBlob = await _jobStorage.StageFormFileAsync(file, jobId);
            return await QueueExtendedJobAsync(jobId, PdfToolIds.ExtractImages, "extractimages",
                new[] { (stagingBlob, file.FileName, file.Length) },
                async (svc, ct) => await svc.RunExtractImagesJobAsync(jobId, stagingBlob, file.Length, ct));
        }

        [HttpPost]
        [RequestSizeLimit(PdfToolLimits.MaxUploadRequestBytes)]
        [RequestFormLimits(MultipartBodyLengthLimit = PdfToolLimits.MaxUploadRequestBytes)]
        [HttpPost]
        public async Task<IActionResult> OcrPdf(IFormFile file)
        {
            var validation = await ValidateJobFilesAsync(
                file == null ? null : new List<IFormFile> { file }, PdfToolIds.OcrPdf, "PDF", ".pdf");
            if (validation.Error != null) return validation.Error;
            file = validation.Files![0];
            var jobId = Guid.NewGuid().ToString();
            var stagingBlob = await _jobStorage.StageFormFileAsync(file, jobId);
            return await QueueExtendedJobAsync(jobId, PdfToolIds.OcrPdf, "ocrpdf",
                new[] { (stagingBlob, file.FileName, file.Length) },
                async (svc, ct) => await svc.RunOcrJobAsync(jobId, stagingBlob, file.Length, ct));
        }

        [HttpPost]
        [RequestSizeLimit(PdfToolLimits.MaxUploadRequestBytes)]
        [RequestFormLimits(MultipartBodyLengthLimit = PdfToolLimits.MaxUploadRequestBytes)]
        [HttpPost]
        public async Task<IActionResult> PageNumbers(IFormFile file, string? format = "{page}")
        {
            var validation = await ValidateJobFilesAsync(
                file == null ? null : new List<IFormFile> { file }, PdfToolIds.PageNumbers, "PDF", ".pdf");
            if (validation.Error != null) return validation.Error;
            file = validation.Files![0];
            var jobId = Guid.NewGuid().ToString();
            var stagingBlob = await _jobStorage.StageFormFileAsync(file, jobId);
            var fmt = string.IsNullOrWhiteSpace(format) ? "{page}" : format;
            return await QueueExtendedJobAsync(jobId, PdfToolIds.PageNumbers, "pagenumbers",
                new[] { (stagingBlob, file.FileName, file.Length) },
                async (svc, ct) => await svc.RunPageNumbersJobAsync(jobId, stagingBlob, file.Length, fmt, ct));
        }

        [HttpPost]
        [RequestSizeLimit(PdfToolLimits.MaxUploadRequestBytes)]
        [RequestFormLimits(MultipartBodyLengthLimit = PdfToolLimits.MaxUploadRequestBytes)]
        [HttpPost]
        public async Task<IActionResult> PdfMetadata(IFormFile file)
        {
            var validation = await ValidateJobFilesAsync(
                file == null ? null : new List<IFormFile> { file }, PdfToolIds.PdfMetadata, "PDF", ".pdf");
            if (validation.Error != null) return validation.Error;
            file = validation.Files![0];
            var jobId = Guid.NewGuid().ToString();
            var stagingBlob = await _jobStorage.StageFormFileAsync(file, jobId);
            return await QueueExtendedJobAsync(jobId, PdfToolIds.PdfMetadata, "pdfmetadata",
                new[] { (stagingBlob, file.FileName, file.Length) },
                async (svc, ct) => await svc.RunMetadataJobAsync(jobId, stagingBlob, file.Length, ct));
        }

        [HttpPost]
        public async Task<IActionResult> ImgToBase64(IFormFile file)
        {
            var access = await _pdfToolsAccess.CheckAccessAsync(PdfToolIds.ImgToBase64, 1);
            if (!access.Allowed)
            {
                AddPaywallError(access.DenyReason);
                return View();
            }

            if (file == null || file.Length == 0)
            {
                ModelState.AddModelError("File", "Please upload an image file.");
                return View();
            }
            if (file.Length > 5 * 1024 * 1024)
            {
                ModelState.AddModelError("File", "Maximum file size is 5MB.");
                return View();
            }
            try
            {
                var base64String = await _pdfService.ConvertImageToBase64(file);
                await _pdfToolsAccess.RecordUsageAsync(PdfToolIds.ImgToBase64, 1);
                ViewBag.Base64String = base64String;
                return View();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, UserFacingErrorMapper.ImageConversionFailed);
                return View();
            }
        }
        /// <summary>Legacy HTML export — superseded by Edit/Export object-level pipeline.</summary>
        [HttpPost]
        public async Task<IActionResult> ExportPdf([FromBody] HtmlRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.Html))
                return BadRequest("Empty content");

            var access = await _pdfToolsAccess.CheckAccessAsync(PdfToolIds.EditPdf, 1);
            if (!access.Allowed)
                return StatusCode(402, new { error = access.DenyReason, paywall = true });

            var result = await Task.Run(() => _fileOps.ConvertHtmlToPdfFile(request.Html));
            await _pdfToolsAccess.RecordUsageAsync(PdfToolIds.EditPdf, 1);
            return TempFileDownload(result.FilePath, "application/pdf", "EditedDocument.pdf");
        }

        [HttpPost("/PDF/Edit/Upload")]
        [RequestSizeLimit(PdfToolLimits.MaxPremiumFileSizeBytes)]
        [RequestFormLimits(MultipartBodyLengthLimit = PdfToolLimits.MaxPremiumFileSizeBytes)]
        public async Task<IActionResult> EditUpload(IFormFile file)
        {
            var error = await TryCreateEditSessionAsync(file);
            if (error != null)
            {
                if (error.Paywall)
                    return StatusCode(402, new { error = UserFacingErrorMapper.Sanitize(error.Message), paywall = true });
                return BadRequest(new { error = UserFacingErrorMapper.Sanitize(error.Message) });
            }

            await _pdfToolsAccess.RecordUsageAsync(PdfToolIds.EditPdf, 1);

            var sessionId = HttpContext.Session.GetString("PdfEditSessionId")!;
            var session = _pdfEditSessions.Get(sessionId);
            if (session == null)
                return NotFound(new { error = "Session expired — re-import your PDF." });

            return Ok(BuildUploadResponse(session));
        }

        [HttpGet("/PDF/Edit/{sessionId}/model")]
        public IActionResult EditGetModel(string sessionId, int? page, bool summary = false)
        {
            var owned = HttpContext.Session.GetString("PdfEditSessionId");
            if (string.IsNullOrEmpty(owned) || owned != sessionId)
                return Forbid();

            var session = _pdfEditSessions.Get(sessionId);
            if (session == null)
                return NotFound(new { error = "Session expired — re-import your PDF." });

            using var doc = JsonDocument.Parse(session.DocumentModelJson);
            var root = doc.RootElement;

            if (summary)
            {
                var pages = new List<PdfEditPageSummary>();
                if (root.TryGetProperty("pages", out var pagesEl) && pagesEl.ValueKind == JsonValueKind.Array)
                {
                    foreach (var pg in pagesEl.EnumerateArray())
                    {
                        pages.Add(new PdfEditPageSummary
                        {
                            PageNum = pg.TryGetProperty("pageNum", out var pn) ? pn.GetInt32() : pages.Count,
                            Width = pg.TryGetProperty("width", out var w) ? w.GetDouble() : 612,
                            Height = pg.TryGetProperty("height", out var h) ? h.GetDouble() : 792,
                            SpanCount = pg.TryGetProperty("spanCount", out var sc)
                                ? sc.GetInt32()
                                : (pg.TryGetProperty("spans", out var sp) ? sp.GetArrayLength() : 0),
                            SpansTruncated = pg.TryGetProperty("spansTruncated", out var st) && st.GetBoolean(),
                        });
                    }
                }

                return Ok(new
                {
                    pageCount = root.TryGetProperty("pageCount", out var pc) ? pc.GetInt32() : pages.Count,
                    totalSpans = root.TryGetProperty("totalSpans", out var ts) ? ts.GetInt32() : 0,
                    pages,
                });
            }

            if (page.HasValue)
            {
                if (!root.TryGetProperty("pages", out var pagesEl) || pagesEl.ValueKind != JsonValueKind.Array)
                    return NotFound(new { error = "Page not found." });

                var idx = page.Value;
                if (idx < 0 || idx >= pagesEl.GetArrayLength())
                    return NotFound(new { error = "Page not found." });

                return Content(pagesEl[idx].GetRawText(), "application/json");
            }

            return Content(session.DocumentModelJson, "application/json");
        }

        [HttpGet("/PDF/Edit/{sessionId}/file")]
        public IActionResult EditGetPdfFile(string sessionId)
        {
            var owned = HttpContext.Session.GetString("PdfEditSessionId");
            if (string.IsNullOrEmpty(owned) || owned != sessionId)
                return Forbid();

            var session = _pdfEditSessions.Get(sessionId);
            if (session == null || !System.IO.File.Exists(session.PdfPath))
                return NotFound();

            return PhysicalFile(session.PdfPath, "application/pdf", enableRangeProcessing: true);
        }

        [HttpPost("/PDF/Edit/Asset")]
        [RequestSizeLimit(10 * 1024 * 1024)]
        public async Task<IActionResult> EditUploadAsset([FromForm] string sessionId, IFormFile file)
        {
            if (string.IsNullOrEmpty(sessionId) || file == null || file.Length == 0)
                return BadRequest(new { error = "Invalid image upload." });

            var owned = HttpContext.Session.GetString("PdfEditSessionId");
            if (owned != sessionId)
                return Forbid();

            var session = _pdfEditSessions.Get(sessionId);
            if (session == null)
                return NotFound(new { error = "Session expired — re-import your PDF." });

            if (string.IsNullOrEmpty(session.AssetsDir))
            {
                session.AssetsDir = Path.Combine(Path.GetDirectoryName(session.PdfPath)!, sessionId + "_assets");
                Directory.CreateDirectory(session.AssetsDir);
            }

            var ext = Path.GetExtension(file.FileName);
            if (string.IsNullOrEmpty(ext))
                ext = ".png";
            var allowed = new[] { ".png", ".jpg", ".jpeg", ".webp", ".gif" };
            if (!allowed.Any(e => ext.Equals(e, StringComparison.OrdinalIgnoreCase)))
                return BadRequest(new { error = "Only PNG, JPG, WebP, or GIF images are supported." });

            if (file.Length > 5 * 1024 * 1024)
                return BadRequest(new { error = "Image must be under 5 MB." });

            var assetId = Guid.NewGuid().ToString("N");
            var dest = Path.Combine(session.AssetsDir, assetId + ext.ToLowerInvariant());
            await using (var stream = System.IO.File.Create(dest))
                await file.CopyToAsync(stream);

            return Ok(new { assetId });
        }

        [HttpPost("/PDF/Edit/Export")]
        public async Task<IActionResult> EditExport([FromBody] PdfEditExportRequest request)
        {
            var validation = await ValidateEditExportRequestAsync(request);
            if (validation.Error != null)
                return validation.Error;

            var session = validation.Session!;
            string? editsPath = null;
            string? outputPath = null;
            try
            {
                editsPath = Path.GetTempFileName() + ".json";
                outputPath = Path.GetTempFileName() + ".pdf";
                var jsonOptions = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                };
                ResolveImageAssets(request, session);
                var pageOps = BuildPageOps(request);
                var payload = JsonSerializer.Serialize(new { edits = request.Edits, pageOps }, jsonOptions);
                await System.IO.File.WriteAllTextAsync(editsPath, payload);

                await _pdfEditProcessor.ApplyEditsAsync(session.PdfPath, editsPath, outputPath);
                await _pdfToolsAccess.RecordUsageAsync(PdfToolIds.EditPdf, 1);

                var downloadName = Path.GetFileNameWithoutExtension(session.OriginalFileName) + "_edited.pdf";
                var stream = new FileStream(
                    outputPath,
                    FileMode.Open,
                    FileAccess.Read,
                    FileShare.Read,
                    65536,
                    FileOptions.DeleteOnClose | FileOptions.Asynchronous);
                return File(stream, "application/pdf", downloadName, enableRangeProcessing: true);
            }
            catch (Exception ex)
            {
                HttpContext.RequestServices
                    .GetRequiredService<ILogger<PDFController>>()
                    .LogError(ex, "PDF edit export failed for session {SessionId}", request.SessionId);
                return BadRequest(new { error = UserFacingErrorMapper.ProcessingFailed });
            }
            finally
            {
                if (editsPath != null) try { System.IO.File.Delete(editsPath); } catch { }
            }
        }

        [HttpPost("/PDF/Edit/Export/Async")]
        [RequestSizeLimit(PdfToolLimits.MaxFileSizeBytes)]
        public async Task<IActionResult> EditExportAsync([FromBody] PdfEditExportRequest request)
        {
            var validation = await ValidateEditExportRequestAsync(request);
            if (validation.Error != null)
                return validation.Error;

            var session = validation.Session!;
            var jobId = Guid.NewGuid().ToString("N");
            var downloadName = Path.GetFileNameWithoutExtension(session.OriginalFileName) + "_edited.pdf";
            var editsPath = Path.GetTempFileName() + ".json";

            var jsonOptions = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            ResolveImageAssets(request, session);
            var pageOps = BuildPageOps(request);
            var payload = JsonSerializer.Serialize(new { edits = request.Edits, pageOps }, jsonOptions);
            await System.IO.File.WriteAllTextAsync(editsPath, payload);

            _jobResultStore.CreateJob(jobId, PdfToolIds.EditPdf);

            var pdfPath = session.PdfPath;
            _jobQueue.Queue(async ct =>
            {
                using var scope = _serviceScopeFactory.CreateScope();
                var exportJob = scope.ServiceProvider.GetRequiredService<PdfEditExportJobService>();
                try
                {
                    await exportJob.RunExportJobAsync(jobId, pdfPath, editsPath, downloadName, ct);
                    await scope.ServiceProvider.GetRequiredService<PdfToolsAccessService>()
                        .RecordUsageAsync(PdfToolIds.EditPdf, 1);
                }
                catch (Exception ex)
                {
                    scope.ServiceProvider.GetRequiredService<ILogger<PDFController>>()
                        .LogError(ex, "Async edit export job {JobId} failed", jobId);
                }
                finally
                {
                    try { System.IO.File.Delete(editsPath); } catch { }
                }
            });

            return Accepted(new
            {
                jobId,
                statusUrl = Url.Action(nameof(GetJobStatus), new { jobId }),
                downloadUrl = Url.Action(nameof(DownloadResult), new { jobId }),
                outputFileName = downloadName,
            });
        }

        [HttpPost]
        [RequestSizeLimit(PdfToolLimits.MaxFileSizeBytes)]
        [RequestFormLimits(MultipartBodyLengthLimit = PdfToolLimits.MaxFileSizeBytes)]
        public async Task<IActionResult> UploadPdf(IFormFile file)
        {
            var error = await TryCreateEditSessionAsync(file);
            if (error != null)
            {
                if (error.Paywall)
                    return BadRequest(new { error = UserFacingErrorMapper.Sanitize(error.Message) });
                return BadRequest(new { error = UserFacingErrorMapper.Sanitize(error.Message) });
            }
            return RedirectToAction(nameof(EditPDF));
        }
        #endregion
        #region private

        private sealed record EditSessionError(string Message, bool Paywall = false);
        private sealed record EditExportValidation(PdfEditSession? Session, IActionResult? Error);

        private async Task<EditExportValidation> ValidateEditExportRequestAsync(PdfEditExportRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.SessionId))
                return new EditExportValidation(null, BadRequest(new { error = "Invalid request" }));

            var owned = HttpContext.Session.GetString("PdfEditSessionId");
            if (owned != request.SessionId)
                return new EditExportValidation(null, Forbid());

            var access = await _pdfToolsAccess.CheckAccessAsync(PdfToolIds.EditPdf, 1);
            if (!access.Allowed)
                return new EditExportValidation(null, StatusCode(402, new { error = access.DenyReason, paywall = true }));

            var session = _pdfEditSessions.Get(request.SessionId);
            if (session == null || !System.IO.File.Exists(session.PdfPath))
                return new EditExportValidation(null, NotFound(new { error = "Session expired — re-import your PDF." }));

            return new EditExportValidation(session, null);
        }

        private static List<PdfEditPageOperation> BuildPageOps(PdfEditExportRequest request)
        {
            var ops = new List<PdfEditPageOperation>(request.PageOps);
            if (request.PageOrder is { Count: > 0 })
            {
                ops.Add(new PdfEditPageOperation
                {
                    Type = "reorder_pages",
                    Order = request.PageOrder,
                });
            }
            return ops;
        }

        private static PdfEditUploadResponse BuildUploadResponse(PdfEditSession session)
        {
            using var doc = JsonDocument.Parse(session.DocumentModelJson);
            var root = doc.RootElement;
            var pages = new List<PdfEditPageSummary>();

            if (root.TryGetProperty("pages", out var pagesEl) && pagesEl.ValueKind == JsonValueKind.Array)
            {
                foreach (var pg in pagesEl.EnumerateArray())
                {
                    pages.Add(new PdfEditPageSummary
                    {
                        PageNum = pg.TryGetProperty("pageNum", out var pn) ? pn.GetInt32() : pages.Count,
                        Width = pg.TryGetProperty("width", out var w) ? w.GetDouble() : 612,
                        Height = pg.TryGetProperty("height", out var h) ? h.GetDouble() : 792,
                        SpanCount = pg.TryGetProperty("spanCount", out var sc)
                            ? sc.GetInt32()
                            : (pg.TryGetProperty("spans", out var sp) ? sp.GetArrayLength() : 0),
                        SpansTruncated = pg.TryGetProperty("spansTruncated", out var st) && st.GetBoolean(),
                    });
                }
            }

            var pageCount = root.TryGetProperty("pageCount", out var pc) ? pc.GetInt32() : pages.Count;

            return new PdfEditUploadResponse
            {
                SessionId = session.SessionId,
                OriginalFileName = session.OriginalFileName,
                PageCount = pageCount,
                TotalSpans = root.TryGetProperty("totalSpans", out var ts) ? ts.GetInt32() : 0,
                // Omit per-page details for large documents; client loads via /model?summary=1
                Pages = pageCount > 50 ? new List<PdfEditPageSummary>() : pages,
            };
        }

        private static void ResolveImageAssets(PdfEditExportRequest request, PdfEditSession session)
        {
            if (string.IsNullOrEmpty(session.AssetsDir) || !Directory.Exists(session.AssetsDir))
                return;

            foreach (var edit in request.Edits.Where(e =>
                string.Equals(e.Type, "image", StringComparison.OrdinalIgnoreCase)
                && !string.IsNullOrEmpty(e.ImageAssetId)
                && string.IsNullOrEmpty(e.ImageBase64)))
            {
                var matches = Directory.GetFiles(session.AssetsDir, edit.ImageAssetId + ".*");
                if (matches.Length == 0)
                    throw new InvalidOperationException("Image asset not found for export.");

                var path = matches[0];
                var bytes = System.IO.File.ReadAllBytes(path);
                var ext = Path.GetExtension(path).ToLowerInvariant();
                var mime = ext switch
                {
                    ".png" => "image/png",
                    ".jpg" or ".jpeg" => "image/jpeg",
                    ".webp" => "image/webp",
                    ".gif" => "image/gif",
                    _ => "application/octet-stream",
                };
                edit.ImageBase64 = $"data:{mime};base64,{Convert.ToBase64String(bytes)}";
            }
        }

        private sealed record JobFileValidation(List<IFormFile>? Files, IActionResult? Error);

        private async Task<JobFileValidation> ValidateJobFilesAsync(
            List<IFormFile>? files,
            string toolId,
            string fileTypeLabel,
            params string[] allowedExtensions)
        {
            if (files == null || files.Count == 0)
                return new JobFileValidation(null, BadRequest(new { error = "No files uploaded." }));

            var limits = await _pdfToolsAccess.GetLimitsForToolAsync(toolId);

            if (files.Count > limits.MaxBatchFiles)
                return new JobFileValidation(null, BadRequest(new { error = $"Maximum {limits.MaxBatchFiles} files allowed." }));

            var access = await _pdfToolsAccess.CheckAccessAsync(toolId, files.Count);
            if (!access.Allowed)
                return new JobFileValidation(null, StatusCode(402, new { error = access.DenyReason, paywall = true }));

            if (limits.MaxTotalBatchBytes is long totalCap)
            {
                var combined = files.Sum(f => f.Length);
                if (combined > totalCap)
                {
                    return new JobFileValidation(null, BadRequest(new
                    {
                        error = $"Combined file size must be under {limits.MaxTotalBatchLabel ?? "4 GB"} for Merge PDF on Pro.",
                    }));
                }
            }

            foreach (var file in files)
            {
                if (file.Length == 0)
                    return new JobFileValidation(null, BadRequest(new { error = "Empty file detected." }));
                if (file.Length > limits.MaxFileSizeBytes)
                    return new JobFileValidation(null, BadRequest(new
                    {
                        error = $"Each file must be under {limits.MaxFileSizeLabel}. Subscribe for up to 4 GB per file.",
                    }));
                var ext = Path.GetExtension(file.FileName);
                if (!allowedExtensions.Any(e => ext.Equals(e, StringComparison.OrdinalIgnoreCase)))
                    return new JobFileValidation(null, BadRequest(new { error = $"Only {fileTypeLabel} files are accepted." }));
            }

            return new JobFileValidation(files, null);
        }

        private async Task<IActionResult> RunInlinePdfEditAsync(
            IFormFile file,
            string toolId,
            Func<string, CancellationToken, Task<PdfConversionFileResult>> work)
        {
            var validation = await ValidateJobFilesAsync(new List<IFormFile> { file }, toolId, "PDF", ".pdf");
            if (validation.Error != null)
                return validation.Error;

            file = validation.Files![0];
            var jobId = Guid.NewGuid().ToString();
            var stagingBlob = await _jobStorage.StageFormFileAsync(file, jobId);
            string? tempPdf = null;
            string? outputPath = null;

            try
            {
                tempPdf = await _jobStorage.MaterializeToTempFileAsync(stagingBlob, ".pdf");
                var result = await work(tempPdf, HttpContext.RequestAborted);
                outputPath = result.FilePath;
                await _pdfToolsAccess.RecordUsageAsync(toolId, 1);
                return TempFileDownload(result.FilePath, "application/pdf", "Edited.pdf");
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = UserFacingErrorMapper.FromException(ex) });
            }
            finally
            {
                PdfJobStorageService.TryDeleteLocalFile(tempPdf);
                if (outputPath != null && System.IO.File.Exists(outputPath))
                {
                    // TempFileDownload owns outputPath via DeleteOnClose
                }
                try { await _jobStorage.DeleteStagingAsync(stagingBlob); } catch { }
            }
        }

        private static IActionResult TempFileDownload(string path, string mime, string downloadName)
        {
            var stream = new FileStream(
                path,
                FileMode.Open,
                FileAccess.Read,
                FileShare.Read,
                65536,
                FileOptions.DeleteOnClose | FileOptions.Asynchronous);
            return new FileStreamResult(stream, mime) { FileDownloadName = downloadName, EnableRangeProcessing = true };
        }

        private async Task<IActionResult> QueueExtendedJobAsync(
            string jobId,
            string toolId,
            string jobKind,
            IReadOnlyList<(string StagingBlobName, string OriginalName, long Size)> inputs,
            Func<PdfExtendedToolJobService, CancellationToken, Task> work)
        {
            _jobResultStore.CreateJob(jobId, jobKind);
            await _pdfToolsAccess.RecordUsageAsync(toolId, Math.Max(1, inputs.Count));

            _jobQueue.Queue(async ct =>
            {
                using var scope = _serviceScopeFactory.CreateScope();
                var jobService = scope.ServiceProvider.GetRequiredService<PdfExtendedToolJobService>();
                await work(jobService, ct);
            });

            return Accepted(new
            {
                jobId,
                statusUrl = Url.Action(nameof(GetJobStatus), new { jobId }),
                downloadUrl = Url.Action(nameof(DownloadResult), new { jobId }),
            });
        }

        private async Task<IActionResult> QueueItextJobAsync(
            string jobId,
            string toolId,
            string jobKind,
            IReadOnlyList<(string StagingBlobName, string OriginalName, long Size)> inputs,
            Func<PdfItextToolJobService, CancellationToken, Task> work)
        {
            _jobResultStore.CreateJob(jobId, jobKind);
            await _pdfToolsAccess.RecordUsageAsync(toolId, Math.Max(1, inputs.Count));

            _jobQueue.Queue(async ct =>
            {
                using var scope = _serviceScopeFactory.CreateScope();
                var jobService = scope.ServiceProvider.GetRequiredService<PdfItextToolJobService>();
                await work(jobService, ct);
            });

            return Accepted(new
            {
                jobId,
                statusUrl = Url.Action(nameof(GetJobStatus), new { jobId }),
                downloadUrl = Url.Action(nameof(DownloadResult), new { jobId }),
            });
        }

        private async Task<IActionResult> QueueOfficeJobAsync(
            IFormFile file,
            string toolId,
            string jobKind,
            OfficeConversionKind kind)
        {
            var jobId = Guid.NewGuid().ToString();
            var stagingBlob = await _jobStorage.StageFormFileAsync(file, jobId);

            _jobResultStore.CreateJob(jobId, jobKind);
            await _pdfToolsAccess.RecordUsageAsync(toolId, 1);

            _jobQueue.Queue(async ct =>
            {
                using var scope = _serviceScopeFactory.CreateScope();
                var jobService = scope.ServiceProvider.GetRequiredService<PdfOfficeJobService>();
                await jobService.RunJobAsync(
                    jobId, jobKind, kind, stagingBlob, file.FileName, file.Length, ct);
            });

            return Accepted(new
            {
                jobId,
                statusUrl = Url.Action(nameof(GetJobStatus), new { jobId }),
                downloadUrl = Url.Action(nameof(DownloadResult), new { jobId }),
            });
        }

        private IActionResult? PaywallJson(PdfToolAccessResult access)
        {
            if (access.Allowed) return null;
            return StatusCode(402, new { error = access.DenyReason, paywall = true });
        }

        private void AddPaywallError(string? reason)
        {
            ModelState.AddModelError(string.Empty,
                reason ?? $"Free limit reached ({PdfToolLimits.FreeUsesPerDay}/day). Subscribe for unlimited access.");
            ViewBag.ShowPaywall = true;
        }

        private async Task<EditSessionError?> TryCreateEditSessionAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return new EditSessionError("No file uploaded");
            var limits = await _pdfToolsAccess.GetLimitsForToolAsync(PdfToolIds.EditPdf);
            if (file.Length > limits.MaxFileSizeBytes)
                return new EditSessionError($"File exceeds {limits.MaxFileSizeLabel} limit.");

            if (!file.FileName.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase))
                return new EditSessionError("Only PDF files are allowed.");

            var access = await _pdfToolsAccess.CheckAccessAsync(PdfToolIds.EditPdf, 1);
            if (!access.Allowed)
                return new EditSessionError(access.DenyReason ?? "Subscription required.", Paywall: true);

            using var stream = file.OpenReadStream();
            var header = new byte[4];
            await stream.ReadAsync(header.AsMemory(0, 4));
            if (header[0] != 0x25 || header[1] != 0x50 || header[2] != 0x44 || header[3] != 0x46)
                return new EditSessionError("Invalid PDF file.");

            var tempPath = Path.Combine(Path.GetTempPath(), $"ratpdf_edit_{Guid.NewGuid():N}.pdf");
            await using (var fs = new FileStream(tempPath, FileMode.Create, FileAccess.Write))
            {
                stream.Position = 0;
                await stream.CopyToAsync(fs);
            }

            try
            {
                var oldSessionId = HttpContext.Session.GetString("PdfEditSessionId");
                if (!string.IsNullOrEmpty(oldSessionId))
                    _pdfEditSessions.Remove(oldSessionId);

                var modelJson = await _pdfEditProcessor.ExtractEditableModelJsonAsync(tempPath);
                var session = _pdfEditSessions.Create(tempPath, file.FileName, modelJson);

                HttpContext.Session.SetString("PdfEditSessionId", session.SessionId);
                HttpContext.Session.SetString("PdfEditFileName", file.FileName);
                return null;
            }
            catch (Exception ex)
            {
                try { System.IO.File.Delete(tempPath); } catch { }
                return new EditSessionError(UserFacingErrorMapper.PdfUnreadable);
            }
        }

        private async Task<bool> PdfContainsColoredRectanglesOrImages(Stream pdfStream)
        {
            pdfStream.Position = 0;

            using var ms = new MemoryStream();
            await pdfStream.CopyToAsync(ms);

            ms.Position = 0;
            pdfStream.Position = 0;

            try
            {
                using var pdfReader = new PdfReader(ms);
                using var pdfDoc = new PdfDocument(pdfReader);

                for (int pageNum = 1; pageNum <= pdfDoc.GetNumberOfPages(); pageNum++)
                {
                    var page = pdfDoc.GetPage(pageNum);

                    var listener = new GraphicsDetectionListener();

                    var processor = new PdfCanvasProcessor(listener);

                    processor.ProcessPageContent(page);

                    if (listener.HasImages ||
                        listener.HasColoredRectangles)
                    {
                        return true;
                    }
                }

                return false;
            }
            catch
            {
                return true;
            }
        }
        #endregion
    }
    public class GraphicsDetectionListener : IEventListener
    {
        public bool HasImages { get; private set; }

        public bool HasColoredRectangles { get; private set; }

        public void EventOccurred(IEventData data, EventType type)
        {
            switch (type)
            {
                case EventType.RENDER_IMAGE:
                    HasImages = true;
                    break;

                case EventType.RENDER_PATH:
                    {
                        var pathData = (PathRenderInfo)data;

                        bool isFilled =
                            pathData.GetOperation() ==
                            PathRenderInfo.FILL
                            ||
                            pathData.GetOperation() ==
                            PathRenderInfo.STROKE;

                        if (isFilled)
                        {
                            var color = pathData.GetFillColor();

                            if (color != null)
                            {
                                HasColoredRectangles = true;
                            }
                        }

                        break;
                    }
            }
        }

        public ICollection<EventType> GetSupportedEvents()
        {
            return new HashSet<EventType>
        {
            EventType.RENDER_IMAGE,
            EventType.RENDER_PATH
        };
        }
    }
}
