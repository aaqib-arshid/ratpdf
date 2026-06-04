using Microsoft.AspNetCore.Mvc;

namespace ratpdf.Controllers
{
    public class MedicalToolsController : Controller
    {
        [HttpGet("cha2ds2-vasc-score")] public IActionResult Cha2ds2VascScore() => View();
        [HttpGet("egfr-calculator")] public IActionResult EgfrCalculator() => View();
        [HttpGet("wells-score")] public IActionResult WellsScoreCalculator() => View();
        [HttpGet("heart-score")] public IActionResult HeartScore() => View();
        [HttpGet("gcs-calculator")] public IActionResult GcsCalculator() => View();
        [HttpGet("map-calculator")] public IActionResult MapCalculator() => View();
        [HttpGet("has-bled-score")] public IActionResult HasBledScore() => View();
        [HttpGet("parkland-formula")] public IActionResult ParkLandFormula() => View();
        [HttpGet("nihss-calculator")] public IActionResult NIHSScalculator() => View();
    }
}
