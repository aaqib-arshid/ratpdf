using Microsoft.AspNetCore.Mvc;
using ratpdf.Services;

namespace ratpdf.Controllers
{
    [Route("my-ip")]
    public class WhatIsMyIpSEOController : Controller
    {
        [HttpGet("{slug}")]
        public IActionResult Page(string slug)
        {
            var pages = MyIpService.GeneratePages();

            var page = pages.FirstOrDefault(x => x.Slug == slug);

            if (page == null)
                return NotFound();

            return View("GlobalSeoPage", page);
        }
    }
}
