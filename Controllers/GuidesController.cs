using Microsoft.AspNetCore.Mvc;

namespace ratpdf.Controllers
{
    [Route("guides")]
    public class GuidesController : Controller
    {
        [HttpGet("background-remover")]
        public IActionResult BackgroundRemoverGuide()
        {
            ViewData["Title"] = "Background Remover Guides";
            ViewData["Description"] = "Learn how to remove image backgrounds online for free, without Photoshop, using AI tools and step-by-step guides.";
            return View();
        }
        [HttpGet("compress-pdf-guide")]
        public IActionResult CompressPdfGuide() { 
            return View();
        }
        [HttpGet("ring-size-converter-guide")]
        public IActionResult RingSizeConverterGuide()
        {
            return View();
        }
        [HttpGet("word-counter-guide")]
        public IActionResult WordCounterGuide()
        {
            return View();
        }
        [HttpGet("pdf-txt-guide")]
        public IActionResult PdfToTxtGuide()
        {
            return View();
        }
        [HttpGet("my-ip-guide")]
        public IActionResult MyIpGuide()
        {
            return View();
        }
    }
}
