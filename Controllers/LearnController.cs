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
            ViewData["Title"] = "PDF Video Tutorials — How to Use RatPDF Tools";
            ViewData["Description"] = "Step-by-step video tutorials for every RatPDF PDF tool — merge, compress, convert, sign, and protect documents online.";
            ViewData["CanonicalUrl"] = PdfToolSeo.Canonical(ToolHowToVideo.LearningHubPath);

            var tools = PdfTutorials()
                .Where(v => ToolHowToVideos.FileExists(v, _env.WebRootPath))
                .OrderBy(v => v.ToolName)
                .ToList();

            return View(tools);
        }

        [HttpGet("{slug}")]
        public IActionResult Watch(string slug)
        {
            if (MedicalToolsRemoval.IsRemovedLearnSlug(slug))
                return NotFound();

            var entry = PdfTutorials().FirstOrDefault(v =>
                v.Slug.Equals(slug, StringComparison.OrdinalIgnoreCase));
            if (entry == null || !ToolHowToVideos.FileExists(entry, _env.WebRootPath))
                return NotFound();

            ViewData["Title"] = entry.Title;
            ViewData["Description"] = $"Watch the {entry.ToolName} tutorial — step-by-step slides showing where to click.";
            ViewData["CanonicalUrl"] = PdfToolSeo.Canonical(entry.LearnPath);
            ViewData["Steps"] = ToolTutorialSteps.Get(entry.ToolUrl, entry.ToolName);
            return View(entry);
        }

        private static IEnumerable<ToolHowToVideo> PdfTutorials() =>
            ToolHowToVideos.All.Where(IsPdfTutorial);

        private static bool IsPdfTutorial(ToolHowToVideo v) =>
            v.ToolUrl.StartsWith("/pdf/", StringComparison.OrdinalIgnoreCase) ||
            v.ToolUrl.Equals("/pdf-redaction", StringComparison.OrdinalIgnoreCase);
    }
}
