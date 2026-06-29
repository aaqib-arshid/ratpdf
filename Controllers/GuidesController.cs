using Microsoft.AspNetCore.Mvc;
using ratpdf.Content;
using ratpdf.Constants;
using ratpdf.Services;
using ratpdf.Services.Seo;

namespace ratpdf.Controllers
{
    [Route("guides")]
    public class GuidesController : Controller
    {
        [HttpGet("")]
        [HttpGet("index")]
        public IActionResult Index()
        {
            ViewData["Title"] = "PDF & Document Guides — Free Tutorials | RatPDF";
            ViewData["Description"] = $"{PdfToolSeo.ToolCountLabel} step-by-step guides for every RatPDF tool: compress, merge, convert PDF to Word/Excel, invoices, OCR, repair, PDF/A, and more.";
            ViewData["CanonicalUrl"] = PdfToolSeo.Canonical("/guides");
            return View(ContentLibrary.Guides.OrderBy(g => g.Category).ThenBy(g => g.Title).ToList());
        }

        [HttpGet("pdf-tools")]
        public IActionResult PdfTools()
        {
            ViewData["Title"] = "All PDF Tools Online — Complete Hub | RatPDF";
            ViewData["Description"] = "Browse every RatPDF tool by workflow: compress, merge, convert, edit, OCR, and secure PDFs. Free tier + Pro up to 4 GB.";
            ViewData["CanonicalUrl"] = TopicalAuthority.CanonicalHub();
            return View();
        }

        [HttpGet("secure-pdf-workflow")]
        public IActionResult SecurePdfWorkflow()
        {
            ViewData["Title"] = "Secure PDF Workflow — Sign, Watermark & Encrypt | RatPDF";
            ViewData["Description"] = "Protect PDFs before sharing: watermark drafts, password encrypt, sign approvals, and unlock when needed. Step-by-step guides included.";
            ViewData["CanonicalUrl"] = TopicalAuthority.CanonicalSecureHub();
            return View();
        }

        [HttpGet("developer-tools")]
        public IActionResult DeveloperTools()
        {
            ViewData["Title"] = "Developer Tool Guides — JSON, JWT, HTML & DNS | RatPDF";
            ViewData["Description"] = "Tutorials for JSON formatting, JWT decoding, HTML beautification, text diff, URL encoding, binary conversion, and DNS lookup.";
            ViewData["CanonicalUrl"] = TopicalAuthority.CanonicalDeveloperGuidesHub();
            return View(ContentLibrary.Guides.Where(g => g.Category == "Developer").OrderBy(g => g.Title).ToList());
        }

        [HttpGet("{slug}")]
        public IActionResult Article(string slug)
        {
            var entry = ContentLibrary.GetGuide(slug);
            if (entry == null) return NotFound();
            ViewData["Title"] = entry.Title;
            ViewData["Description"] = entry.Description;
            ViewData["CanonicalUrl"] = PdfToolSeo.Canonical(entry.Path);
            GuideHreflangHelper.ApplyToViewData(ViewData, entry.Slug);
            return View(entry);
        }
    }
}
