using Microsoft.AspNetCore.Mvc;
using ratpdf.Services;

namespace ratpdf.Controllers
{
    [Route("pdf-to-word")]
    public class PdfToDocSeoController : Controller
    {
        private readonly IWebHostEnvironment _env;

        public PdfToDocSeoController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [Route("{slug}")]
        public IActionResult PdfToWordSEOPage(string slug)
        {
            var page = PdfToWordContentGenerator.PopulateSEOPageData(slug, _env.WebRootPath);

            if (page == null)
                return NotFound();
            return View("DynamicPdfToDocSEO", page);
        }
    }
}
