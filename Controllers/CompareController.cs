using Microsoft.AspNetCore.Mvc;
using ratpdf.Constants;
using ratpdf.Helpers;

namespace ratpdf.Controllers
{
    [Route("compare")]
    public class CompareController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            ViewData["Title"] = "PDF Tool Comparisons — RatPDF vs iLovePDF, Smallpdf & Adobe";
            ViewData["Description"] = "Compare RatPDF with iLovePDF, Smallpdf, PDF24, Adobe Acrobat, Sejda, and Foxit. Feature tables, keyword coverage, and free alternative workflows.";
            ViewData["CanonicalUrl"] = PdfToolSeo.Canonical(CompetitiveSeoCatalog.CompareHubPath);
            return View(CompetitiveSeoCatalog.ComparePages);
        }

        [HttpGet("{slug}")]
        public IActionResult Alternative(string slug)
        {
            var profession = InvoiceProfessionCompareCatalog.GetPage(slug);
            if (profession != null)
            {
                ViewData["Title"] = profession.Title;
                ViewData["Description"] = profession.Description;
                ViewData["CanonicalUrl"] = PdfToolSeo.Canonical($"{CompetitiveSeoCatalog.CompareHubPath}/{profession.Slug}");
                ViewData["LightLayout"] = true;
                return View("ProfessionCompare", profession);
            }

            var page = CompetitiveSeoCatalog.GetComparePage(slug);
            if (page == null) return NotFound();

            ViewData["Title"] = page.Title;
            ViewData["Description"] = page.Description;
            ViewData["CanonicalUrl"] = PdfToolSeo.Canonical($"{CompetitiveSeoCatalog.CompareHubPath}/{page.Slug}");
            ViewData["LightLayout"] = true;
            return View(page);
        }
    }
}
