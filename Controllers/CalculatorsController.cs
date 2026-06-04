using Microsoft.AspNetCore.Mvc;

namespace ratpdf.Controllers
{
    public class CalculatorsController : Controller
    {
        [HttpGet("bmi-calculator")] public IActionResult BMICalculator() => View();
        [HttpGet("age-calculator")] public IActionResult AgeCalculator() => View();
        [HttpGet("emi-calculator")] public IActionResult LoanCalculator() => View();
        [HttpGet("percentage-calculator")] public IActionResult PercentageCalculator() => View();
        [HttpGet("period-calculator")] public IActionResult PeriodCalculator() => View();
    }
}
