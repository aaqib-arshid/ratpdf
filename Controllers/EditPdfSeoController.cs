using Microsoft.AspNetCore.Mvc;
using ratpdf.Services;

namespace ratpdf.Controllers
{
    [Route("edit-pdf")]
    public class EditPdfSeoController : Controller
    {
        private readonly IWebHostEnvironment _env;
        public EditPdfSeoController(IWebHostEnvironment env) => _env = env;

        [Route("{slug}")]
        public IActionResult EditPdfSeOPage(string slug)
        {
            var page = EditPdfSeoEngine.BuildPage(slug, _env.WebRootPath);
            if (page == null) return NotFound();
            if (page.NoIndex) Response.Headers["X-Robots-Tag"] = "noindex, follow";
            return View("DynamicEditPdfSEO", page);
        }
    }
}
