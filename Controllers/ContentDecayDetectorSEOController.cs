using Microsoft.AspNetCore.Mvc;
using ratpdf.Services;

namespace ratpdf.Controllers
{

    [Route("content-decay-detector")]
    public class ContentDecayDetectorSEOController : Controller
    {
        private readonly IWebHostEnvironment _env;
        public ContentDecayDetectorSEOController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [Route("{slug}")]
        public IActionResult DecayDetectorSEO(string slug)
        {
            var page = ContentDecayDetectorGenerator.PopulateSEOPageData(slug, _env.WebRootPath);

            if (page == null)
                return NotFound();

            Response.Headers["X-Robots-Tag"] = "noindex, follow";
            ViewData["Robots"] = "noindex, follow";
            return View("DynamicDecayDetectorSEO", page);
        }
    }
}
