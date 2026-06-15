using Microsoft.AspNetCore.Mvc;
using ratpdf.Constants;

namespace ratpdf.Controllers
{
    [Route("learn")]
    public class LearnController : Controller
    {
        private readonly IWebHostEnvironment _env;

        public LearnController(IWebHostEnvironment env) => _env = env;

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewData["Title"] = "Video Tutorials — How to Use Every RatPDF Tool";
            ViewData["Description"] = "Step-by-step video tutorials with click guides for every RatPDF tool — PDF, medical calculators, developer utilities, and more.";
            ViewData["CanonicalUrl"] = PdfToolSeo.Canonical(ToolHowToVideo.LearningHubPath);

            var tools = ToolHowToVideos.All
                .Where(v => ToolHowToVideos.FileExists(v, _env.WebRootPath))
                .OrderBy(CategoryKey)
                .ThenBy(v => v.ToolName)
                .ToList();

            return View(tools);
        }

        [HttpGet("{slug}")]
        public IActionResult Watch(string slug)
        {
            var entry = ToolHowToVideos.All.FirstOrDefault(v =>
                v.Slug.Equals(slug, StringComparison.OrdinalIgnoreCase));
            if (entry == null || !ToolHowToVideos.FileExists(entry, _env.WebRootPath))
                return NotFound();

            ViewData["Title"] = entry.Title;
            ViewData["Description"] = $"Watch the {entry.ToolName} tutorial — step-by-step slides showing where to click.";
            ViewData["CanonicalUrl"] = PdfToolSeo.Canonical(entry.LearnPath);
            ViewData["Steps"] = ToolTutorialSteps.Get(entry.ToolUrl, entry.ToolName);
            return View(entry);
        }

        private static string CategoryKey(ToolHowToVideo v)
        {
            if (v.ToolUrl.StartsWith("/pdf/", StringComparison.OrdinalIgnoreCase) ||
                v.ToolUrl.Equals("/pdf-redaction", StringComparison.OrdinalIgnoreCase))
                return "PDF";
            if (v.ToolUrl.Contains("calculator", StringComparison.OrdinalIgnoreCase)) return "Medical";
            if (v.ToolUrl.StartsWith("/invoice", StringComparison.OrdinalIgnoreCase)) return "Business";
            return "Utilities";
        }
    }
}
