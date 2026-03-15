using Microsoft.AspNetCore.Mvc;
using ratpdf.Services;

namespace ratpdf.Controllers
{
    [Route("pdf-to-txt")]
    public class PdfToTextSeoController : Controller
    {
        private readonly IWebHostEnvironment _env;

        public PdfToTextSeoController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [Route("{slug}")]
        public IActionResult PdfToTexSEOPage(string slug)
        {
            var page = PdfToTxtContentGenerator.PopulateSEOPageData(slug, _env.WebRootPath);

            if (page == null)
                return NotFound();
            return View("DynamicPdfToTxtSEO", page);
        }
    }
}
