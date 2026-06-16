using Microsoft.AspNetCore.Mvc;
using ratpdf.Services;
using ratpdf.Services.Seo;

namespace ratpdf.Controllers
{
    public class ToolCategorySeoLandingController : Controller
    {
        [HttpGet("calculator-tools/{slug}")]
        public IActionResult CalculatorTools(string slug) => Render("calculator-tools", slug);

        private IActionResult Render(string routePrefix, string slug)
        {
            var page = ToolCategorySeoLandingGenerator.Populate(routePrefix, slug);
            if (page == null)
                return NotFound();

            Response.Headers["X-Robots-Tag"] = "noindex, follow";
            ViewData["Robots"] = "noindex, follow";
            ViewData["Description"] = page.Description;
            ViewData["OgDescription"] = ProgrammaticToolMetaCatalog.BuildOgDescription(
                page.Category, page.DisplayTitle, page.ToolLinkText);

            return View("~/Views/CategorySeo/DynamicCategorySeo.cshtml", page);
        }
    }
}
