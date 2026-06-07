using DnsClient.Internal;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Data;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using Microsoft.AspNetCore.Mvc;
using ratpdf.Models;
using ratpdf.Services;
using ratpdf.Services.CompressPDF;
using System.Text;

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
        private const long MaxFileSizeBytes = 1024L * 1024 * 1024; // 1 GB
        public PDFController(IConfiguration config, IJobQueue jobQueue,IJobResultStore jobResultStore,IServiceScopeFactory serviceScopeFactory,PdfConversionService pdfService, PdfCompressionService compressionService, LayoutEngineProcessor processor, HtmlReconstructionService reconstructionEngine)
        {
            _pdfService = pdfService;
            _processor = processor;
            _reconstructionEngine = reconstructionEngine;
            _compressionService = compressionService;
            _config = config;
            _jobQueue = jobQueue;
            _jobResultStore = jobResultStore;
            _serviceScopeFactory = serviceScopeFactory;
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
            var html = HttpContext.Session.GetString("PdfHtml");
            var model = new HtmlRequest
            {
                Html = html ?? string.Empty
            };

            return View(model);
        }
        #endregion
        #region --POST--

        [HttpPost]
        public async Task<IActionResult> ConvertImages(ImageUploadViewModel model)
        {
            if (model.Files == null || model.Files.Count == 0)
            {
                ModelState.AddModelError("Files", "No image selected. Please select at least one image.");
                return View(model);
            }

            var pdfBytes = _pdfService.ConvertImagesToPdf(model.Files);
            Response.Cookies.Append("downloadReady", "1", new CookieOptions
            {
                Expires = DateTimeOffset.Now.AddMinutes(1),
                Path = "/"
            });
            return File(pdfBytes, "application/pdf", "images.pdf");
        }
        [HttpPost]
        public IActionResult Merge(List<IFormFile> files)
        {
            if (files == null || files.Count < 2)
            {
                ModelState.AddModelError("Files", "Please select at least 2 PDF files to merge.");
                return View();
            }
            Response.Cookies.Append("downloadReady", "1", new CookieOptions
            {
                Expires = DateTimeOffset.Now.AddMinutes(1),
                Path = "/"
            });
            try
            {
                var mergedPdf = _pdfService.MergePdfFiles(files);
                return File(mergedPdf, "application/pdf", "merged.pdf");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Error merging PDFs: " + ex.Message);
                return View();
            }
        }
        [HttpPost]
        public IActionResult Split(IFormFile file, int startPage, int endPage)
        {
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
                var splitPdf = _pdfService.SplitPdf(file, startPage, endPage);
                return File(splitPdf, "application/pdf", "split.pdf");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Error splitting PDF: " + ex.Message);
                return View();
            }
        }
        [HttpPost]
        [RequestSizeLimit(1_073_741_824)]
        [RequestFormLimits(MultipartBodyLengthLimit = 1_073_741_824)]
        public IActionResult Compress(
        IFormFile? file,
        [FromForm] string? compressionLevel)
        {
            if (file is null || file.Length == 0)
                return BadRequest(new { error = "No file uploaded." });

            if (!string.Equals(file.ContentType, "application/pdf", StringComparison.OrdinalIgnoreCase)
                && !file.FileName.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase))
                return BadRequest(new { error = "Only PDF files are accepted." });

            if (file.Length > 1_073_741_824)
                return BadRequest(new { error = "File exceeds the 1 GB limit." });

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

            _jobQueue.Queue(async ct =>
            {
                using var scope = _serviceScopeFactory.CreateScope();
                var compressionService = scope.ServiceProvider.GetRequiredService<PdfCompressionService>();
                var resultStore = scope.ServiceProvider.GetRequiredService<IJobResultStore>();

                try
                {
                    await using var inputStream = new FileStream(tempInputPath, FileMode.Open, FileAccess.Read);
                    var result = await compressionService.CompressAsync(inputStream, level, ct);

                    resultStore.SetCompleted(jobId, result.ResultFilePath, result.OriginalSize, result.CompressedSize, result.ReductionPct);
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
        [HttpGet("status/{jobId}")]
        public IActionResult GetJobStatus(string jobId)
        {
            var job = _jobResultStore.GetJob(jobId);
            if (job == null) return NotFound(new { error = "Job not found" });

            return Ok(new
            {
                jobId,
                status = job.Status,
                originalSize = job.OriginalSize,
                compressedSize = job.CompressedSize,
                reductionPercent = job.ReductionPercent,
                error = job.ErrorMessage
            });
        }

        [HttpGet("download/{jobId}")]
        public IActionResult DownloadResult(string jobId)
        {
            var job = _jobResultStore.GetJob(jobId);
            if (job == null) return NotFound();
            if (job.Status != "Completed") return BadRequest(new { error = "Compression not completed yet" });
            if (string.IsNullOrEmpty(job.FilePath) || !System.IO.File.Exists(job.FilePath))
                return NotFound(new { error = "Result file not found" });

            var originalName = "compressed.pdf"; 
            return PhysicalFile(job.FilePath, "application/pdf", originalName);
        }
        [HttpGet("cleanup-temp")]
        public IActionResult CleanupTemp([FromQuery] string key)
        {
            var expectedKey = _config["AdminCleanupSecretKey"];
            if (string.IsNullOrEmpty(key) || key != expectedKey)
                return NotFound();

            var tmpDir = Path.GetTempPath();
            var maxAge = TimeSpan.FromMinutes(30);
            var now = DateTime.UtcNow;
            int deleted = 0;
            int failed = 0;
            int skipped = 0;
            long bytesFreed = 0;
            var details = new List<string>();

            try
            {
                var files = Directory.GetFiles(tmpDir, "ratpdf_*.pdf");

                foreach (var file in files)
                {
                    try
                    {
                        var info = new FileInfo(file);
                        var age = now - info.LastWriteTimeUtc;

                        if (age > maxAge)
                        {
                            var sizeMb = info.Length / 1024.0 / 1024.0;
                            bytesFreed += info.Length;
                            info.Delete();
                            deleted++;
                            details.Add($"✅ Deleted: {info.Name} " +
                                        $"({sizeMb:F2} MB, {age.TotalMinutes:F0} mins old)");
                        }
                        else
                        {
                            skipped++;
                            details.Add($"⏭ Skipped: {Path.GetFileName(file)} " +
                                        $"({age.TotalMinutes:F1} mins old — still fresh)");
                        }
                    }
                    catch (Exception ex)
                    {
                        failed++;
                        details.Add($"❌ Failed:  {Path.GetFileName(file)} — {ex.Message}");
                    }
                }

                var html = $"""
            <!DOCTYPE html>
            <html>
            <head>
                <title>RatPDF Temp Cleanup</title>
            </head>
            <body>
                <h2>🧹 RatPDF Temp Cleanup Report</h2>
                <div class="box">
                    <p class="stat">✅ Deleted : {deleted} files</p>
                    <p class="stat">⏭ Skipped : {skipped} files (under 30 mins old)</p>
                    <p class="stat">❌ Failed  : {failed} files</p>
                    <p class="stat">💾 Freed   : {bytesFreed / 1024.0 / 1024.0:F2} MB</p>
                    <p class="stat">🕐 Run at  : {now:yyyy-MM-dd HH:mm:ss} UTC</p>
                </div>
                <hr class="sep" />
                <div class="box">
                    <strong>File Details:</strong><br/><br/>
                    {(details.Count == 0
                                ? "<span style='color:#8b949e'>No ratpdf_*.pdf files found in temp folder.</span>"
                        : string.Join("<br/>", details.Select(d => $"<p class='line'>{d}</p>")))}
                </div>
            </body>
            </html>
            """;

                return Content(html, "text/html");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Cleanup failed: {ex.Message}");
            }
        }
        [HttpPost]
        public IActionResult TextToPdf(IFormFile file, string typedText)
        {
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

                return File(pdfBytes, "application/pdf", "document.pdf");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Error converting text to PDF: " + ex.Message);
                return View();
            }
        }
        [HttpPost]
        public IActionResult PdfToText(IFormFile file)
        {
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
                // Return as downloadable text file
                return File(Encoding.UTF8.GetBytes(extractedText), "text/plain", "extracted.txt");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Error extracting text: " + ex.Message);
                return View();
            }
        }
        [HttpPost]
        public IActionResult Watermark(IFormFile file, string watermarkText)
        {
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
                return File(result, "application/pdf", "watermarked.pdf");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Error adding watermark: " + ex.Message);
                return View();
            }
        }

        [HttpPost]
        public IActionResult Password(IFormFile file, string password)
        {
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
                return File(result, "application/pdf", "protected.pdf");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Error adding password: " + ex.Message);
                return View();
            }
        }
        [HttpPost]
        public IActionResult DocToPdf(IFormFile file)
        {
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
                var pdfBytes = _pdfService.ConvertDocxToPdf(file);
                return File(pdfBytes, "application/pdf", Path.GetFileNameWithoutExtension(file.FileName) + ".pdf");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Error converting DOCX to PDF: " + ex.Message);
                return View();
            }
        }
        [HttpPost]
        public IActionResult PdfToDoc(IFormFile file)
        {
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
                var docBytes = _pdfService.ConvertPdfToDoc(file);
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
        public IActionResult SignText(IFormFile file, string name)
        {
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
                return File(signedPdf, "application/pdf", Path.GetFileNameWithoutExtension(file.FileName) + "_signed.pdf");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Error signing PDF: " + ex.Message);
                return View();
            }
        }
        [HttpPost]
        public IActionResult AddText(IFormFile file, string text, int pageNumber = 0)
        {
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
            return File(pdf, "application/pdf", "Edited.pdf");
        }

        [HttpPost]
        public IActionResult AddImage(IFormFile file, IFormFile image, int pageNumber = 0)
        {
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
            return File(pdf, "application/pdf", "Edited.pdf");
        }

        [HttpPost]
        public IActionResult RotatePage(IFormFile file, int pageNumber = 0, int degree = 90)
        {
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
                return File(pdf, "application/pdf", "Edited.pdf");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Error rotating PDF: " + ex.Message);
                return View("RotateOrRemove");
            }
        }

        [HttpPost]
        public IActionResult RemovePage(IFormFile file, int pageNumber = 0)
        {
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
            return File(pdf, "application/pdf", "Edited.pdf");
        }
        [HttpPost]
        public IActionResult PdfToExcel(IFormFile file)
        {
            if (file == null)
            {
                ModelState.AddModelError("", "Please upload a PDF file.");
                return View();
            }
            if (file.Length > 5 * 1024 * 1024)
            {
                ModelState.AddModelError("", "File is too large. Maximum allowed size is 5 MB.");
                return View();
            }
            Response.Cookies.Append("downloadReady", "1", new CookieOptions
            {
                Expires = DateTimeOffset.Now.AddMinutes(1),
                Path = "/"
            });
            try
            {
                var excelBytes = _pdfService.ConvertPdfToExcel(file);
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
        public IActionResult ExcelToPdf(IFormFile file)
        {
            if (file == null)
            {
                ModelState.AddModelError("", "Please upload an Excel file.");
                return View();
            }
            if (file.Length > 5 * 1024 * 1024)
            {
                ModelState.AddModelError("", "File is too large. Maximum allowed size is 5 MB.");
                return View();
            }
            Response.Cookies.Append("downloadReady", "1", new CookieOptions
            {
                Expires = DateTimeOffset.Now.AddMinutes(1),
                Path = "/"
            });
            try
            {
                var pdfBytes = _pdfService.ConvertExcelToPdf(file);
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
                ViewBag.Base64String = base64String;
                return View();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Error converting image: " + ex.Message);
                return View();
            }
        }
        [HttpPost]
        public async Task<IActionResult> ExportPdf([FromBody] HtmlRequest request)
        {
            //ASP.NET Core MVC
            //no database
            //simple PDF tool

            //Use:

            //Razorpay + localStorage

            //That is the fastest and simplest setup.

            //Flow:

            //User downloads 3 PDFs free
            //Browser stores count
            //4th download opens Razorpay
            //Payment success → download PDF

            //Very lightweight MVP.
            if (request == null || string.IsNullOrEmpty(request.Html))
                return BadRequest("Empty content");

            var pdfBytes = await Task.Run(() => _pdfService.ConvertHtmlToPdf(request.Html));
            return File(pdfBytes, "application/pdf", "EditedDocument.pdf");
        }
        [HttpPost]
        public async Task<IActionResult> UploadPdf(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded");
            const long maxSizeBytes = 5 * 1024 * 1024; // 5 MB
            if (file.Length > maxSizeBytes)
                return BadRequest("File size exceeds the 5 MB limit. Please upload a smaller PDF.");

            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (extension != ".pdf")
                return BadRequest("Invalid file type. Only PDF files are allowed.");

            if (!file.ContentType.Equals("application/pdf", StringComparison.OrdinalIgnoreCase))
                return BadRequest("Invalid file content type. Only PDF files are accepted.");
            try
            {
                Response.Cookies.Append("downloadReady", "1", new CookieOptions
                {
                    Expires = DateTimeOffset.Now.AddMinutes(1),
                    Path = "/"
                });
                using var stream = file.OpenReadStream();
                var header = new byte[4];
                await stream.ReadAsync(header, 0, 4);
                if (header[0] != 0x25 || header[1] != 0x50 ||
                    header[2] != 0x44 || header[3] != 0x46)
                {
                    return BadRequest("The uploaded file is not a valid PDF.");
                }
                stream.Position = 0;
                bool hasGraphics = await PdfContainsColoredRectanglesOrImages(stream);

                stream.Position = 0; // resetting again

                string html;
                if (hasGraphics)
                {
                    Console.WriteLine("PDF contains images – using layout extraction + OCR");
                    string json = await _processor.ExtractLayoutJsonAsync(stream);
                    html = _reconstructionEngine.BuildHtml(json);
                }
                else
                {
                    Console.WriteLine("No images detected – using ConvertPdfToHtml (pure text)");
                    html = await _pdfService.ConvertPdfToHtml(file);
                }
                HttpContext.Session.SetString("PdfHtml", html);
                return RedirectToAction("EditPDF", "PDF");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error:{ex.Message}, {ex.StackTrace}");
                try
                {
                    var html = await _pdfService.ConvertPdfToHtml(file);
                    HttpContext.Session.SetString("PdfHtml", html);
                    return RedirectToAction("EditPDF", "PDF");
                }
                catch
                {
                    return BadRequest("Pdf file is corrupted or contains sensitive data.");
                }
            }
        }
        #endregion
        #region private
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
