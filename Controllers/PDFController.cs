using Microsoft.AspNetCore.Mvc;
using ratpdf.Models;
using ratpdf.Services;
using System.Text;

namespace ratpdf.Controllers
{
    public class PDFController : Controller
    {
        private readonly PdfConversionService _pdfService;

        public PDFController(PdfConversionService pdfService)
        {
            _pdfService = pdfService;
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
        public IActionResult Compress(IFormFile file)
        {
            if (file == null)
            {
                ModelState.AddModelError("File", "Please upload a PDF file to compress.");
                return View();
            }
            Response.Cookies.Append("downloadReady", "1", new CookieOptions
            {
                Expires = DateTimeOffset.Now.AddMinutes(1),
                Path = "/"
            });
            try
            {
                var compressedPdf = _pdfService.CompressPdf(file);
                return File(compressedPdf, "application/pdf", "compressed.pdf");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Error compressing PDF: " + ex.Message);
                return View();
            }
        }
        [HttpPost]
        public IActionResult TextToPdf(IFormFile file, string typedText)
        {
            if (file == null && string.IsNullOrWhiteSpace(typedText))
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
                    pdfBytes = _pdfService.ConvertTextToPdf(typedText);

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
            }catch(Exception ex)
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
        #endregion
    }
}
