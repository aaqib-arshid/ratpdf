using Microsoft.AspNetCore.Mvc;
using ratpdf.Services;

namespace ratpdf.Controllers
{
    [Route("compress-pdf")]
    public class PdfCompressSeoController : Controller
    {
        private readonly IWebHostEnvironment _env;

        public PdfCompressSeoController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [Route("{slug}")]
        public IActionResult CompressSEO(string slug)
        {
            var page = PdfCompressContentGenerator.PopulateSEOPageData(slug, _env.WebRootPath);

            if (page == null)
                return NotFound();

            return View("DynamicPdfCompressSEO", page);
        }
    }
}
