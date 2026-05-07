using Microsoft.AspNetCore.Mvc;
using ratpdf.Services;

namespace ratpdf.Controllers
{
    [Route("edit-pdf")]
    public class EditPdfSeoController : Controller
    {

        private readonly IWebHostEnvironment _env;

        public EditPdfSeoController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [Route("{slug}")]
        public IActionResult PdfToWordSEOPage(string slug)
        {
            var page = EditPdfContentGenerator.PopulateSEOPageData(slug, _env.WebRootPath);

            if (page == null)
                return NotFound();
            return View("DynamicEditPdfSEO", page);
        }
    }
}
