using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Disclaimer()
        {
            return View();
        }
    }
}
