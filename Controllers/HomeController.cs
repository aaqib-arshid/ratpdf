using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ratpdf.Constants;

namespace ratpdf.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var exceptionFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            return View(exceptionFeature);
            //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Terms()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult ThankyouContact()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }

        [HttpGet("/about")]
        public IActionResult AboutCanonical() => View("About");

        public IActionResult EditorialPolicy()
        {
            return View();
        }

        public IActionResult Security()
        {
            ViewData["Title"] = "Security & File Handling — RatPDF";
            ViewData["Description"] = "How RatPDF secures file uploads: TLS encryption, temporary storage, automatic deletion, Azure hosting, and what we do not do with your documents.";
            ViewData["CanonicalUrl"] = PdfToolSeo.Canonical(SiteEntity.SecurityPath);
            return View();
        }

        public IActionResult Corrections()
        {
            ViewData["Title"] = "Corrections Policy — RatPDF";
            ViewData["Description"] = "How to report factual errors in RatPDF guides and comparisons. Our correction process, update cadence, and last-reviewed dates.";
            ViewData["CanonicalUrl"] = PdfToolSeo.Canonical(SiteEntity.CorrectionsPath);
            return View();
        }

        public IActionResult Disclaimer()
        {
            return View();
        }
    }
}
