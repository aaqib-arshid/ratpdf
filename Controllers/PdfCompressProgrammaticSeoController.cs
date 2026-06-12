using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using ratpdf.Constants;
using ratpdf.Services;
using ratpdf.Services.Seo;

namespace ratpdf.Controllers
{
    public class PdfCompressProgrammaticSeoController : Controller
    {
        private readonly CachedPdfCompressSeoService _seo;
        private readonly IWebHostEnvironment _env;

        public PdfCompressProgrammaticSeoController(CachedPdfCompressSeoService seo, IWebHostEnvironment env)
        {
            _seo = seo;
            _env = env;
        }

        [HttpGet("{slug:compressSeo}")]
        [ResponseCache(Duration = 86400, Location = ResponseCacheLocation.Any, VaryByQueryKeys = new[] { "slug" })]
        [OutputCache(PolicyName = "SeoLanding", VaryByRouteValueNames = new[] { "slug" })]
        public IActionResult Landing(string slug)
        {
            var page = _seo.GetPage(slug, _env.WebRootPath);
            if (page == null)
                return NotFound();

            ViewData["LightLayout"] = true;
            ViewData["Robots"] = "index, follow, max-image-preview:large, max-snippet:-1";
            return View("~/Views/PdfCompressSeo/CompressSeoLanding.cshtml", page);
        }
    }
}
