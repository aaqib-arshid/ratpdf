using Microsoft.AspNetCore.Mvc;
using ratpdf.Constants;

namespace ratpdf.Controllers
{
    [Route("help")]
    public class HelpController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            ViewData["Title"] = "Help Center — PDF Tools Support & FAQs | RatPDF";
            ViewData["Description"] = "Get help with RatPDF PDF tools: upload limits, conversion errors, file privacy, Pro subscriptions, and step-by-step guides for every tool.";
            ViewData["CanonicalUrl"] = PdfToolSeo.Canonical(SiteEntity.HelpPath);
            return View();
        }
    }
}
