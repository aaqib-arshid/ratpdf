using Microsoft.AspNetCore.Mvc;
using ratpdf.Constants;
using ratpdf.Helpers;

namespace ratpdf.Controllers
{
    public class VerticalPdfToolsController : Controller
    {
        [HttpGet("/pdf-tools-for-lawyers")]
        public IActionResult Lawyers() => Render("lawyers");

        [HttpGet("/pdf-tools-for-students")]
        public IActionResult Students() => Render("students");

        [HttpGet("/pdf-tools-for-accountants")]
        public IActionResult Accountants() => Render("accountants");

        private IActionResult Render(string slug)
        {
            var page = VerticalPdfToolsCatalog.Get(slug);
            if (page == null) return NotFound();

            ViewData["Title"] = page.Title;
            ViewData["Description"] = page.Description;
            ViewData["CanonicalUrl"] = PdfToolSeo.Canonical(page.Path);
            ViewData["Keywords"] = $"{page.H1.ToLowerInvariant()}, free pdf tools, {slug} pdf online";
            return View("Landing", page);
        }
    }
}
