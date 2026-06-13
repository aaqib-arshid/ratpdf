using Microsoft.AspNetCore.Mvc;
using ratpdf.Services;

namespace ratpdf.Controllers
{
    public class PdfToolSeoLandingController : Controller
    {
        [HttpGet("unlock-pdf/{slug}")]
        public IActionResult UnlockPdf(string slug) => Render("unlock-pdf", slug);

        [HttpGet("flatten-pdf/{slug}")]
        public IActionResult FlattenPdf(string slug) => Render("flatten-pdf", slug);

        [HttpGet("pdf-to-images/{slug}")]
        public IActionResult PdfToImages(string slug) => Render("pdf-to-images", slug);

        [HttpGet("extract-images-from-pdf/{slug}")]
        public IActionResult ExtractImages(string slug) => Render("extract-images-from-pdf", slug);

        [HttpGet("ocr-pdf/{slug}")]
        public IActionResult OcrPdf(string slug) => Render("ocr-pdf", slug);

        [HttpGet("add-page-numbers-to-pdf/{slug}")]
        public IActionResult PageNumbers(string slug) => Render("add-page-numbers-to-pdf", slug);

        [HttpGet("pdf-metadata/{slug}")]
        public IActionResult PdfMetadata(string slug) => Render("pdf-metadata", slug);

        [HttpGet("merge-pdf/{slug}")]
        public IActionResult MergePdf(string slug) => Render("merge-pdf", slug);

        [HttpGet("split-pdf/{slug}")]
        public IActionResult SplitPdf(string slug) => Render("split-pdf", slug);

        [HttpGet("word-to-pdf/{slug}")]
        public IActionResult WordToPdf(string slug) => Render("word-to-pdf", slug);

        [HttpGet("pdf-to-excel/{slug}")]
        public IActionResult PdfToExcel(string slug) => Render("pdf-to-excel", slug);

        [HttpGet("sign-pdf/{slug}")]
        public IActionResult SignPdf(string slug) => Render("sign-pdf", slug);

        [HttpGet("watermark-pdf/{slug}")]
        public IActionResult WatermarkPdf(string slug) => Render("watermark-pdf", slug);

        private IActionResult Render(string routePrefix, string slug)
        {
            var page = PdfToolSeoLandingGenerator.Populate(routePrefix, slug);
            if (page == null)
                return NotFound();
            return View("DynamicToolSeo", page);
        }
    }
}
