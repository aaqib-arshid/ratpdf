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
            return View("DynamicRingSizerSEO",page);
        }
    }
}
