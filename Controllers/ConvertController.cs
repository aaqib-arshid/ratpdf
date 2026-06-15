using Microsoft.AspNetCore.Mvc;
using ratpdf.Constants;

namespace ratpdf.Controllers
{
    [Route("convert")]
    public class ConvertController : Controller
    {
        [HttpGet("pdf-to-jpg")]
        public IActionResult PdfToJpg()
        {
            ViewData["Title"] = "PDF to JPG Converter Online Free — Export Pages as Images | RatPDF";
            ViewData["Description"] = "Convert PDF pages to JPG images online. High-quality export, ZIP download, free 200 MB uploads. Same engine as our PDF to Images tool.";
            ViewData["CanonicalUrl"] = PdfToolSeo.Canonical("/convert/pdf-to-jpg");
            ViewData["PdfToolId"] = "pdftoimages";
            ViewData["OgImage"] = PdfToolSeo.OgImageForToolId("pdftoimages");
            ViewData["SeoH1"] = "PDF to JPG — Convert PDF Pages to JPEG Images";
            ViewData["SeoLead"] = "Export every page as a JPG image. Use our free online converter — no signup, secure processing, download as ZIP.";
            return View();
        }

        [HttpGet("html-to-pdf")]
        public IActionResult HtmlToPdfLanding()
        {
            ViewData["Title"] = "HTML to PDF Converter Online Free | RatPDF";
            ViewData["Description"] = "Convert HTML files and web page markup to PDF online. Free, secure, no install.";
            ViewData["CanonicalUrl"] = PdfToolSeo.Canonical("/convert/html-to-pdf");
            ViewData["PdfToolId"] = "htmltopdf";
            ViewData["OgImage"] = PdfToolSeo.OgImageForToolId("htmltopdf");
            ViewData["SeoH1"] = "HTML to PDF — Convert Web Pages Online";
            ViewData["SeoLead"] = "Turn HTML snippets or .html files into print-ready PDFs with one click.";
            return View("HtmlToPdfLanding");
        }
    }
}
