using Microsoft.AspNetCore.Mvc;
using ratpdf.Constants;

namespace ratpdf.Controllers
{
    public class CalculatorsController : Controller
    {
        [HttpGet("bmi-calculator")] public IActionResult BMICalculator() => View();
        [HttpGet("age-calculator")] public IActionResult AgeCalculator() => View();
        [HttpGet("emi-calculator")] public IActionResult LoanCalculator() => View();
        [HttpGet("percentage-calculator")] public IActionResult PercentageCalculator() => View();
        [HttpGet("period-calculator")] public IActionResult PeriodCalculator() => View();

        [HttpGet("freelance-rate-calculator")]
        public IActionResult FreelanceRateCalculator()
        {
            ViewData["Title"] = "Freelance Hourly Rate Calculator — Free 2026 | RatPDF";
            ViewData["Description"] = "Calculate your minimum freelance hourly rate from target income, billable hours, taxes, and business expenses. Free calculator for consultants and creatives.";
            ViewData["CanonicalUrl"] = PdfToolSeo.Canonical("/freelance-rate-calculator");
            return View();
        }

        [HttpGet("gst-invoice-checker")]
        public IActionResult GstInvoiceChecker()
        {
            ViewData["Title"] = "GST Invoice Compliance Checker (India) — Free Online | RatPDF";
            ViewData["Description"] = "Interactive checklist: does your tax invoice meet GST mandatory fields? Score compliance and fix gaps before filing.";
            ViewData["CanonicalUrl"] = PdfToolSeo.Canonical("/gst-invoice-checker");
            return View();
        }

        [HttpGet("pdf-size-checker")]
        public IActionResult PdfSizeChecker()
        {
            ViewData["Title"] = "Will My PDF Fit? Attachment Size Checker | RatPDF";
            ViewData["Description"] = "Check if your PDF fits Gmail, Outlook, job portals, and government upload limits. Free interactive size checker with compress link.";
            ViewData["CanonicalUrl"] = PdfToolSeo.Canonical("/pdf-size-checker");
            return View();
        }
    }
}
