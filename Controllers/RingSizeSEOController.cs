using Microsoft.AspNetCore.Mvc;
using ratpdf.Services;

namespace ratpdf.Controllers
{
    [Route("ring-size")]
    public class RingSizeSEOController : Controller
    {

        [Route("{slug}")]
        public IActionResult RingSizeSEOPage(string slug)
        {
            var pages = RingSizeSeoPageService.GeneratePages();

            var page = pages.FirstOrDefault(x => x.Slug == slug);

            if (page == null)
                return NotFound();

            Response.Headers["X-Robots-Tag"] = "noindex, follow";
            ViewData["Robots"] = "noindex, follow";
            return View("DynamicRingSizerSEO",page);
        }
    }
}
