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
            var page = PdfToTxtSeoEngine.BuildPage(slug, _env.WebRootPath);
            if (page == null)
                return NotFound();

            if (page.NoIndex)
                Response.Headers["X-Robots-Tag"] = "noindex, follow";

            return View("DynamicPdfToTxtSEO", page);
        }
    }
}
