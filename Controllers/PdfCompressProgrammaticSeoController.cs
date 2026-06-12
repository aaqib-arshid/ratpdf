using Microsoft.AspNetCore.Mvc;
using ratpdf.Services;

namespace ratpdf.Controllers
{
    /// <summary>Programmatic PDF compression SEO landing pages (5,000+ slugs).</summary>
    public class PdfCompressProgrammaticSeoController : Controller
    {
        private readonly IWebHostEnvironment _env;

        public PdfCompressProgrammaticSeoController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [HttpGet("{slug:compressSeo}")]
        public IActionResult Landing(string slug)
        {
            var page = PdfCompressProgrammaticSeoGenerator.GetPage(slug, _env.WebRootPath);
            if (page == null)
                return NotFound();

            return View("~/Views/PdfCompressSeo/CompressSeoLanding.cshtml", page);
        }
    }
}
