using Microsoft.AspNetCore.Mvc;
using ratpdf.Content;
using ratpdf.Constants;

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
            ViewData["Description"] = "20+ step-by-step guides for every RatPDF tool: compress, merge, convert PDF to Word/Excel, invoices, OCR, and more.";
            ViewData["CanonicalUrl"] = PdfToolSeo.Canonical("/guides");
            return View(ContentLibrary.Guides.OrderBy(g => g.Category).ThenBy(g => g.Title).ToList());
        }

        [HttpGet("{slug}")]
        public IActionResult Article(string slug)
        {
            var entry = ContentLibrary.GetGuide(slug);
            if (entry == null) return NotFound();
            ViewData["Title"] = entry.Title;
            ViewData["Description"] = entry.Description;
            ViewData["CanonicalUrl"] = PdfToolSeo.Canonical(entry.Path);
            return View(entry);
        }
    }
}
