using Microsoft.AspNetCore.Mvc;

namespace ratpdf.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult TooManyRequests()
        {
            return View();
        }
    }
}
