using Microsoft.AspNetCore.Mvc;

namespace ratpdf.Controllers
{
    public class InvoiceHomeController : Controller
    {
        public IActionResult Index()
        {
            if (User.Identity?.IsAuthenticated == true)
                return RedirectToAction("Index", "InvoiceDashboard");

            return View();
        }
    }
}
