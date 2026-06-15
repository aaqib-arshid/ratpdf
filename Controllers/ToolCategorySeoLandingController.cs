using Microsoft.AspNetCore.Mvc;
using ratpdf.Services;

namespace ratpdf.Controllers
{
    public class ToolCategorySeoLandingController : Controller
    {
        [HttpGet("medical-tools/{slug}")]
        public IActionResult MedicalTools(string slug) => Render("medical-tools", slug);

        [HttpGet("calculator-tools/{slug}")]
        public IActionResult CalculatorTools(string slug) => Render("calculator-tools", slug);

        private IActionResult Render(string routePrefix, string slug)
        {
            var page = ToolCategorySeoLandingGenerator.Populate(routePrefix, slug);
            if (page == null)
                return NotFound();
            return View("~/Views/CategorySeo/DynamicCategorySeo.cshtml", page);
        }
    }
}
