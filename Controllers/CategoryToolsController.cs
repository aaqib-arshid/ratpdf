using Microsoft.AspNetCore.Mvc;
using ratpdf.Constants;
using ratpdf.Helpers;

namespace ratpdf.Controllers
{
    public class CategoryToolsController : Controller
    {
        [HttpGet("/tools")]
        public IActionResult AllTools() => Render("all-tools");

        [HttpGet("/tools/developer")]
        public IActionResult Developer() => Render("developer");

        [HttpGet("/tools/calculators")]
        public IActionResult Calculators() => Render("calculators");

        [HttpGet("/tools/utilities")]
        public IActionResult Utilities() => Render("utilities");

        [HttpGet("/tools/business")]
        public IActionResult Business() => Render("business");

        private IActionResult Render(string slug)
        {
            var page = CategoryToolsCatalog.Get(slug);
            if (page == null) return NotFound();

            ViewData["Title"] = page.Title;
            ViewData["Description"] = page.Description;
            ViewData["CanonicalUrl"] = PdfToolSeo.Canonical(page.Path);
            ViewData["Keywords"] = $"{page.H1.ToLowerInvariant()}, free online tools, {slug} calculators";
            return View("Hub", page);
        }
    }
}
