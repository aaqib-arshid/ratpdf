using DnsClient.Internal;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Data;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using Microsoft.AspNetCore.Mvc;
using ratpdf.Constants;
using ratpdf.Models;
using ratpdf.Services;
using ratpdf.Services.CompressPDF;
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
        private readonly PdfToolsAccessService _pdfToolsAccess;
        private readonly PdfEditProcessor _pdfEditProcessor;
        private readonly IPdfEditSessionStore _pdfEditSessions;
        private const long MaxFileSizeBytes = 1024L * 1024 * 1024; // 1 GB
        public PDFController(
            IConfiguration config,
            AzureBlobService azureBlobService,
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
        public IActionResult TextToPdf() => View();
        public IActionResult PdfToText() => View();
        public IActionResult Watermark() => View();
        public IActionResult Password() => View();
        public IActionResult DocToPdf() => View();
        public IActionResult PdfToDoc() => View();
        public IActionResult SignText() => View();
        public IActionResult RotateOrRemove() => View();
        public IActionResult PdfToExcel() => View();
        public IActionResult ExcelToPdf() => View();
        public IActionResult ImgToBase64() => View();
        public IActionResult HtmlFormatter() => View();
        public IActionResult JsonFormatter() => View();
        public IActionResult JwtDecoder() => View();
        public IActionResult ImageCompressor() => View();
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
        public async Task<IActionResult> ConvertImages(ImageUploadViewModel model)
        {
            var access = await _pdfToolsAccess.CheckAccessAsync(PdfToolIds.ConvertImages, 1);
            if (!access.Allowed)
            {
                AddPaywallError(access.DenyReason);
                return View(model);
            }

            if (model.Files == null || model.Files.Count == 0)
            {
                ModelState.AddModelError("Files", "No image selected. Please select at least one image.");
                return View(model);
            }

            var pdfBytes = _pdfService.ConvertImagesToPdf(model.Files);
            await _pdfToolsAccess.RecordUsageAsync(PdfToolIds.ConvertImages, 1);
            Response.Cookies.Append("downloadReady", "1", new CookieOptions
            {
                Expires = DateTimeOffset.Now.AddMinutes(1),
                Path = "/"
            });
            return File(pdfBytes, "application/pdf", "images.pdf");
        }
        [HttpPost]
        [RequestSizeLimit(PdfToolLimits.MaxUploadRequestBytes)]
        [RequestFormLimits(MultipartBodyLengthLimit = PdfToolLimits.MaxUploadRequestBytes)]
        public async Task<IActionResult> Merge(List<IFormFile> files)
        {
            if (files == null || files.Count < 2)
                return BadRequest(new { error = "Please select at least 2 PDF files to merge." });

            var validation = await ValidateJobFilesAsync(files, PdfToolIds.Merge, "PDF", ".pdf");
            if (validation.Error != null)
                return validation.Error;

            try
            {
                var mergedPdf = _pdfService.MergePdfFiles(validation.Files!);
                await _pdfToolsAccess.RecordUsageAsync(PdfToolIds.Merge, 1);
                return File(mergedPdf, "application/pdf", "merged.pdf");
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = "Error merging PDFs: " + ex.Message });
            }
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

            try
            {
                var splitPdf = _pdfService.SplitPdf(validation.Files![0], startPage, endPage);
                await _pdfToolsAccess.RecordUsageAsync(PdfToolIds.Split, 1);
                return File(splitPdf, "application/pdf", "split.pdf");
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = "Error splitting PDF: " + ex.Message });
            }
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
            var tempInputPath = Path.Combine(Path.GetTempPath(), $"ratpdf_in_{jobId}.pdf");

            using (var stream = new FileStream(tempInputPath, FileMode.Create, FileAccess.Write))
            {
                file.CopyTo(stream);
            }

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

                try
                {
                    await using var inputStream = new FileStream(
                        tempInputPath, FileMode.Open, FileAccess.Read);

                    var result = await compressionService.CompressAsync(
                        inputStream, level, password, blobService, jobId, ct);   

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
                    resultStore.SetFailed(jobId, ex.Message);
                }
                finally
                {
                    try { if (System.IO.File.Exists(tempInputPath)) System.IO.File.Delete(tempInputPath); } catch { }
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
                error = job.ErrorMessage
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
                return NotFound(new { error = "Result blob not found" });

            try
            {
                var stream = await _blobService.DownloadAsync(job.BlobName);
                _ = _blobService.DeleteAsync(job.BlobName);

                var mime = job.OutputMimeType ?? "application/pdf";
                var name = job.OutputFileName ?? job.JobKind switch
                {
                    "pdf2docx" => "converted.docx",
                    "pdftoxlsx" => "converted.xlsx",
                    "doctopdf" or "exceltopdf" => "converted.pdf",
                    _ => "compressed.pdf",
                };
                return File(stream, mime, name);
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
            var limits = await _pdfToolsAccess.GetLimitsAsync();
            return Ok(new
            {
                allowed = status.Allowed,
                isPremium = status.IsPremium,
                remaining = status.RemainingFreeUses,
                denyReason = status.DenyReason,
                maxFileSizeBytes = limits.MaxFileSizeBytes,
                maxBatchFiles = limits.MaxBatchFiles,
                maxFileSizeLabel = limits.MaxFileSizeLabel,
            });
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
            var inputs = new List<(string TempPath, string OriginalName, long Size)>();

            foreach (var file in files)
            {
                var tempPath = Path.Combine(Path.GetTempPath(), $"ratpdf_docx_in_{jobId}_{Guid.NewGuid():N}.pdf");
                await using (var fs = new FileStream(tempPath, FileMode.Create, FileAccess.Write))
                {
                    await file.CopyToAsync(fs);
                }
                inputs.Add((tempPath, file.FileName, file.Length));
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
        public async Task<IActionResult> TextToPdf(IFormFile file, string typedText)
        {
            var access = await _pdfToolsAccess.CheckAccessAsync(PdfToolIds.TextToPdf, 1);
            if (!access.Allowed)
            {
                AddPaywallError(access.DenyReason);
                return View();
            }

            if (file == null && typedText.Equals("<p><br></p>"))
            {
                ModelState.AddModelError("Text", "Please upload a text file or type some text.");
                return View();
            }
            Response.Cookies.Append("downloadReady", "1", new CookieOptions
            {
                Expires = DateTimeOffset.Now.AddMinutes(1),
                Path = "/"
            });
            try
            {
                byte[] pdfBytes;

                if (file != null)
                    pdfBytes = _pdfService.ConvertTextFileToPdf(file);
                else
                    pdfBytes = _pdfService.ConvertHtmlToPdf(typedText);

                await _pdfToolsAccess.RecordUsageAsync(PdfToolIds.TextToPdf, 1);
                return File(pdfBytes, "application/pdf", "document.pdf");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Error converting text to PDF: " + ex.Message);
                return View();
            }
        }
        [HttpPost]
        public async Task<IActionResult> PdfToText(IFormFile file)
        {
            var access = await _pdfToolsAccess.CheckAccessAsync(PdfToolIds.PdfToText, 1);
            if (!access.Allowed)
            {
                AddPaywallError(access.DenyReason);
                return View();
            }

            if (file == null)
            {
                ModelState.AddModelError("File", "Please upload a PDF file.");
                return View();
            }
            Response.Cookies.Append("downloadReady", "1", new CookieOptions
            {
                Expires = DateTimeOffset.Now.AddMinutes(1),
                Path = "/"
            });
            try
            {
                string extractedText = _pdfService.ExtractTextFromPdf(file);
                await _pdfToolsAccess.RecordUsageAsync(PdfToolIds.PdfToText, 1);
                return File(Encoding.UTF8.GetBytes(extractedText), "text/plain", "extracted.txt");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Error extracting text: " + ex.Message);
                return View();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Watermark(IFormFile file, string watermarkText)
        {
            var access = await _pdfToolsAccess.CheckAccessAsync(PdfToolIds.Watermark, 1);
            if (!access.Allowed)
            {
                AddPaywallError(access.DenyReason);
                return View();
            }

            if (file == null || string.IsNullOrWhiteSpace(watermarkText))
            {
                ModelState.AddModelError("File", "Upload PDF and provide watermark text.");
                return View();
            }
            Response.Cookies.Append("downloadReady", "1", new CookieOptions
            {
                Expires = DateTimeOffset.Now.AddMinutes(1),
                Path = "/"
            });
            try
            {
                var result = _pdfService.AddWatermark(file, watermarkText);
                await _pdfToolsAccess.RecordUsageAsync(PdfToolIds.Watermark, 1);
                return File(result, "application/pdf", "watermarked.pdf");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Error adding watermark: " + ex.Message);
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Password(IFormFile file, string password)
        {
            var access = await _pdfToolsAccess.CheckAccessAsync(PdfToolIds.Password, 1);
            if (!access.Allowed)
            {
                AddPaywallError(access.DenyReason);
                return View();
            }

            if (file == null || string.IsNullOrWhiteSpace(password))
            {
                ModelState.AddModelError("File", "Upload PDF and enter a password.");
                return View();
            }
            Response.Cookies.Append("downloadReady", "1", new CookieOptions
            {
                Expires = DateTimeOffset.Now.AddMinutes(1),
                Path = "/"
            });
            try
            {
                var result = _pdfService.AddPassword(file, password);
                await _pdfToolsAccess.RecordUsageAsync(PdfToolIds.Password, 1);
                return File(result, "application/pdf", "protected.pdf");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Error adding password: " + ex.Message);
                return View();
            }
        }
        [HttpPost]
        public async Task<IActionResult> DocToPdf(IFormFile file)
        {
            var access = await _pdfToolsAccess.CheckAccessAsync(PdfToolIds.DocToPdf, 1);
            if (!access.Allowed)
            {
                AddPaywallError(access.DenyReason);
                return View();
            }

            if (file == null)
            {
                ModelState.AddModelError("File", "Please upload a DOCX file.");
                return View();
            }
            Response.Cookies.Append("downloadReady", "1", new CookieOptions
            {
                Expires = DateTimeOffset.Now.AddMinutes(1),
                Path = "/"
            });
            try
            {
                var pdfBytes = await _pdfService.ConvertDocxToPdfAsync(file);
                await _pdfToolsAccess.RecordUsageAsync(PdfToolIds.DocToPdf, 1);
                return File(pdfBytes, "application/pdf", Path.GetFileNameWithoutExtension(file.FileName) + ".pdf");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Error converting DOCX to PDF: " + ex.Message);
                return View();
            }
        }
        [HttpPost]
        public async Task<IActionResult> PdfToDoc(IFormFile file)
        {
            var access = await _pdfToolsAccess.CheckAccessAsync(PdfToolIds.PdfToDoc, 1);
            if (!access.Allowed)
            {
                AddPaywallError(access.DenyReason);
                return View();
            }

            if (file == null)
            {
                ModelState.AddModelError("File", "Please upload a PDF file.");
                return View();
            }
            Response.Cookies.Append("downloadReady", "1", new CookieOptions
            {
                Expires = DateTimeOffset.Now.AddMinutes(1),
                Path = "/"
            });
            try
            {
                var docBytes = await _pdfService.ConvertPdfToDocAsync(file);
                await _pdfToolsAccess.RecordUsageAsync(PdfToolIds.PdfToDoc, 1);
                return File(docBytes,
                            "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                            Path.GetFileNameWithoutExtension(file.FileName) + ".docx");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Error converting PDF to DOCX: " + ex.Message);
                return View();
            }
        }
        [HttpPost]
        public async Task<IActionResult> SignText(IFormFile file, string name)
        {
            var access = await _pdfToolsAccess.CheckAccessAsync(PdfToolIds.SignPdf, 1);
            if (!access.Allowed)
            {
                AddPaywallError(access.DenyReason);
                return View();
            }

            if (file == null)
            {
                ModelState.AddModelError("File", "Please upload a PDF.");
                return View();
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                ModelState.AddModelError("Name", "Please enter a name for signature.");
                return View();
            }
            Response.Cookies.Append("downloadReady", "1", new CookieOptions
            {
                Expires = DateTimeOffset.Now.AddMinutes(1),
                Path = "/"
            });
            try
            {
                var signedPdf = _pdfService.SignPdfWithName(file, name);
                await _pdfToolsAccess.RecordUsageAsync(PdfToolIds.SignPdf, 1);
                return File(signedPdf, "application/pdf", Path.GetFileNameWithoutExtension(file.FileName) + "_signed.pdf");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Error signing PDF: " + ex.Message);
                return View();
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddText(IFormFile file, string text, int pageNumber = 0)
        {
            var access = await _pdfToolsAccess.CheckAccessAsync(PdfToolIds.EditPdf, 1);
            if (!access.Allowed)
            {
                AddPaywallError(access.DenyReason);
                return View("EditPdf");
            }

            if (file == null || string.IsNullOrWhiteSpace(text))
            {
                ModelState.AddModelError("", "PDF file or text missing.");
                return View("EditPdf");
            }
            Response.Cookies.Append("downloadReady", "1", new CookieOptions
            {
                Expires = DateTimeOffset.Now.AddMinutes(1),
                Path = "/"
            });
            var pdf = _pdfService.AddText(file, text, pageNumber);
            await _pdfToolsAccess.RecordUsageAsync(PdfToolIds.EditPdf, 1);
            return File(pdf, "application/pdf", "Edited.pdf");
        }

        [HttpPost]
        public async Task<IActionResult> AddImage(IFormFile file, IFormFile image, int pageNumber = 0)
        {
            var access = await _pdfToolsAccess.CheckAccessAsync(PdfToolIds.EditPdf, 1);
            if (!access.Allowed)
            {
                AddPaywallError(access.DenyReason);
                return View("EditPdf");
            }

            if (file == null || image == null)
            {
                ModelState.AddModelError("", "PDF or image missing.");
                return View("EditPdf");
            }
            Response.Cookies.Append("downloadReady", "1", new CookieOptions
            {
                Expires = DateTimeOffset.Now.AddMinutes(1),
                Path = "/"
            });
            var pdf = _pdfService.AddImage(file, image, pageNumber);
            await _pdfToolsAccess.RecordUsageAsync(PdfToolIds.EditPdf, 1);
            return File(pdf, "application/pdf", "Edited.pdf");
        }

        [HttpPost]
        public async Task<IActionResult> RotatePage(IFormFile file, int pageNumber = 0, int degree = 90)
        {
            var access = await _pdfToolsAccess.CheckAccessAsync(PdfToolIds.Rotate, 1);
            if (!access.Allowed)
            {
                AddPaywallError(access.DenyReason);
                return View("RotateOrRemove");
            }

            if (file == null)
            {
                ModelState.AddModelError("", "PDF missing.");
                return View("RotateOrRemove");
            }
            Response.Cookies.Append("downloadReady", "1", new CookieOptions
            {
                Expires = DateTimeOffset.Now.AddMinutes(1),
                Path = "/"
            });
            try
            {
                var pdf = _pdfService.RotatePage(file, pageNumber, degree);
                await _pdfToolsAccess.RecordUsageAsync(PdfToolIds.Rotate, 1);
                return File(pdf, "application/pdf", "Edited.pdf");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Error rotating PDF: " + ex.Message);
                return View("RotateOrRemove");
            }
        }

        [HttpPost]
        public async Task<IActionResult> RemovePage(IFormFile file, int pageNumber = 0)
        {
            var access = await _pdfToolsAccess.CheckAccessAsync(PdfToolIds.Rotate, 1);
            if (!access.Allowed)
            {
                AddPaywallError(access.DenyReason);
                return View("RotateOrRemove");
            }

            if (file == null)
            {
                ModelState.AddModelError("", "PDF missing.");
                return View("RotateOrRemove");
            }
            Response.Cookies.Append("downloadReady", "1", new CookieOptions
            {
                Expires = DateTimeOffset.Now.AddMinutes(1),
                Path = "/"
            });
            var pdf = _pdfService.RemovePage(file, pageNumber);
            await _pdfToolsAccess.RecordUsageAsync(PdfToolIds.Rotate, 1);
            return File(pdf, "application/pdf", "Edited.pdf");
        }
        [HttpPost]
        public async Task<IActionResult> PdfToExcel(IFormFile file)
        {
            var access = await _pdfToolsAccess.CheckAccessAsync(PdfToolIds.PdfToExcel, 1);
            if (!access.Allowed)
            {
                AddPaywallError(access.DenyReason);
                return View();
            }

            if (file == null)
            {
                ModelState.AddModelError("", "Please upload a PDF file.");
                return View();
            }
            var validation = await ValidateJobFilesAsync(
                new List<IFormFile> { file }, PdfToolIds.PdfToExcel, "PDF", ".pdf");
            if (validation.Error != null)
                return validation.Error;

            try
            {
                var excelBytes = await _pdfService.ConvertPdfToExcelAsync(file);
                await _pdfToolsAccess.RecordUsageAsync(PdfToolIds.PdfToExcel, 1);
                return File(excelBytes,
                            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                            Path.GetFileNameWithoutExtension(file.FileName) + ".xlsx");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error converting PDF: " + ex.Message);
                return View();
            }
        }
        [HttpPost]
        public async Task<IActionResult> ExcelToPdf(IFormFile file)
        {
            var access = await _pdfToolsAccess.CheckAccessAsync(PdfToolIds.ExcelToPdf, 1);
            if (!access.Allowed)
            {
                AddPaywallError(access.DenyReason);
                return View();
            }

            if (file == null)
            {
                ModelState.AddModelError("", "Please upload an Excel file.");
                return View();
            }
            var validation = await ValidateJobFilesAsync(
                new List<IFormFile> { file }, PdfToolIds.ExcelToPdf, "Excel", ".xlsx");
            if (validation.Error != null)
                return validation.Error;

            try
            {
                var pdfBytes = await _pdfService.ConvertExcelToPdfAsync(file);
                await _pdfToolsAccess.RecordUsageAsync(PdfToolIds.ExcelToPdf, 1);
                return File(pdfBytes,
                            "application/pdf",
                            Path.GetFileNameWithoutExtension(file.FileName) + ".pdf");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Conversion failed: " + ex.Message);
                return View();
            }
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
                ModelState.AddModelError(string.Empty, "Error converting image: " + ex.Message);
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

            var pdfBytes = await Task.Run(() => _pdfService.ConvertHtmlToPdf(request.Html));
            await _pdfToolsAccess.RecordUsageAsync(PdfToolIds.EditPdf, 1);
            return File(pdfBytes, "application/pdf", "EditedDocument.pdf");
        }

        [HttpPost("/PDF/Edit/Upload")]
        [RequestSizeLimit(PdfToolLimits.MaxFileSizeBytes)]
        [RequestFormLimits(MultipartBodyLengthLimit = PdfToolLimits.MaxFileSizeBytes)]
        public async Task<IActionResult> EditUpload(IFormFile file)
        {
            var error = await TryCreateEditSessionAsync(file);
            if (error != null)
            {
                if (error.Paywall)
                    return StatusCode(402, new { error = error.Message, paywall = true });
                return BadRequest(new { error = error.Message });
            }

            var sessionId = HttpContext.Session.GetString("PdfEditSessionId")!;
            var modelJson = HttpContext.Session.GetString("PdfEditModelJson")!;
            using var doc = JsonDocument.Parse(modelJson);
            var pageCount = doc.RootElement.TryGetProperty("pageCount", out var pc)
                ? pc.GetInt32()
                : doc.RootElement.GetProperty("pages").GetArrayLength();

            return Ok(new PdfEditUploadResponse
            {
                SessionId = sessionId,
                OriginalFileName = HttpContext.Session.GetString("PdfEditFileName") ?? "document.pdf",
                PageCount = pageCount,
                DocumentModel = JsonSerializer.Deserialize<object>(modelJson),
            });
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

        [HttpPost("/PDF/Edit/Export")]
        public async Task<IActionResult> EditExport([FromBody] PdfEditExportRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.SessionId))
                return BadRequest(new { error = "Invalid request" });

            var owned = HttpContext.Session.GetString("PdfEditSessionId");
            if (owned != request.SessionId)
                return Forbid();

            var access = await _pdfToolsAccess.CheckAccessAsync(PdfToolIds.EditPdf, 1);
            if (!access.Allowed)
                return StatusCode(402, new { error = access.DenyReason, paywall = true });

            var session = _pdfEditSessions.Get(request.SessionId);
            if (session == null || !System.IO.File.Exists(session.PdfPath))
                return NotFound(new { error = "Session expired — re-import your PDF." });

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
                var payload = JsonSerializer.Serialize(new { edits = request.Edits }, jsonOptions);
                await System.IO.File.WriteAllTextAsync(editsPath, payload);

                await _pdfEditProcessor.ApplyEditsAsync(session.PdfPath, editsPath, outputPath);
                var bytes = await System.IO.File.ReadAllBytesAsync(outputPath);
                await _pdfToolsAccess.RecordUsageAsync(PdfToolIds.EditPdf, 1);

                var downloadName = Path.GetFileNameWithoutExtension(session.OriginalFileName) + "_edited.pdf";
                return File(bytes, "application/pdf", downloadName);
            }
            finally
            {
                if (editsPath != null) try { System.IO.File.Delete(editsPath); } catch { }
                if (outputPath != null) try { System.IO.File.Delete(outputPath); } catch { }
            }
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
                    return BadRequest(error.Message);
                return BadRequest(error.Message);
            }
            return RedirectToAction(nameof(EditPDF));
        }
        #endregion
        #region private

        private sealed record EditSessionError(string Message, bool Paywall = false);
        private sealed record JobFileValidation(List<IFormFile>? Files, IActionResult? Error);

        private async Task<JobFileValidation> ValidateJobFilesAsync(
            List<IFormFile>? files,
            string toolId,
            string fileTypeLabel,
            params string[] allowedExtensions)
        {
            if (files == null || files.Count == 0)
                return new JobFileValidation(null, BadRequest(new { error = "No files uploaded." }));

            var limits = await _pdfToolsAccess.GetLimitsAsync();

            if (files.Count > limits.MaxBatchFiles)
                return new JobFileValidation(null, BadRequest(new { error = $"Maximum {limits.MaxBatchFiles} files allowed." }));

            var access = await _pdfToolsAccess.CheckAccessAsync(toolId, files.Count);
            if (!access.Allowed)
                return new JobFileValidation(null, StatusCode(402, new { error = access.DenyReason, paywall = true }));

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

        private async Task<IActionResult> QueueOfficeJobAsync(
            IFormFile file,
            string toolId,
            string jobKind,
            OfficeConversionKind kind)
        {
            var jobId = Guid.NewGuid().ToString();
            var ext = Path.GetExtension(file.FileName);
            var tempPath = Path.Combine(Path.GetTempPath(), $"ratpdf_office_in_{jobId}{ext}");

            await using (var fs = new FileStream(tempPath, FileMode.Create, FileAccess.Write))
            {
                await file.CopyToAsync(fs);
            }

            _jobResultStore.CreateJob(jobId, jobKind);
            await _pdfToolsAccess.RecordUsageAsync(toolId, 1);

            _jobQueue.Queue(async ct =>
            {
                using var scope = _serviceScopeFactory.CreateScope();
                var jobService = scope.ServiceProvider.GetRequiredService<PdfOfficeJobService>();
                await jobService.RunJobAsync(jobId, jobKind, kind, tempPath, file.FileName, ct);
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
            var limits = await _pdfToolsAccess.GetLimitsAsync();
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
                var modelJson = await _pdfEditProcessor.ExtractEditableModelJsonAsync(tempPath);
                var session = _pdfEditSessions.Create(tempPath, file.FileName, modelJson);

                HttpContext.Session.SetString("PdfEditSessionId", session.SessionId);
                HttpContext.Session.SetString("PdfEditFileName", file.FileName);
                HttpContext.Session.SetString("PdfEditModelJson", modelJson);
                return null;
            }
            catch (Exception ex)
            {
                try { System.IO.File.Delete(tempPath); } catch { }
                return new EditSessionError("Could not open PDF: " + ex.Message);
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
