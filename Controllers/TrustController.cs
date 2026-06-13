using Microsoft.AspNetCore.Mvc;
using ratpdf.Constants;

namespace ratpdf.Controllers
{
    [Route("trust")]
    public class TrustController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            ViewData["Title"] = "Trust Center — Security, Privacy & Editorial Standards | RatPDF";
            ViewData["Description"] = "How RatPDF protects uploaded files, reviews content for accuracy, handles corrections, and publishes transparent editorial policies.";
            ViewData["CanonicalUrl"] = PdfToolSeo.Canonical(SiteEntity.TrustHubPath);
            return View();
        }
    }
}
