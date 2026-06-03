using Microsoft.AspNetCore.Mvc;

namespace ratpdf.Controllers
{
    public class ImgBgRemoveSeoController : Controller
    {
        [HttpGet("background-remover")] public IActionResult BackgroundRemover() => View();
        [HttpGet("remove-background-from-image")] public IActionResult RemoveBackgroundFromImage() => View();
        [HttpGet("how-to-remove-background-from-image-online-free")] public IActionResult HowToRemoveBackgroundFromImageOnlineFree() => View();
        [HttpGet("image-background-remover-free")] public IActionResult ImageBackgroundRemoverFree() => View();
        [HttpGet("how-to-remove-background-from-photo-without-photoshop")] public IActionResult HowToRemoveBackgroundFromPhotoWithoutPhotoshop() => View();
        [HttpGet("how-to-make-image-background-transparent-online")] public IActionResult HowToMakeImageBackgroundTransparentOnline() => View();
        [HttpGet("how-to-remove-white-background-from-image")] public IActionResult HowToRemoveWhiteBackgroundFromImage() => View();
        [HttpGet("how-to-cut-out-background-from-photo-easily")] public IActionResult HowToCutOutBackgroundFromPhotoEasily() => View();
        [HttpGet("how-to-remove-background-from-product-images-for-ecommerce")] public IActionResult HowToRemoveBackgroundFromProductImagesForEcommerce() => View();
        [HttpGet("how-to-remove-background-from-portrait-photo-online")] public IActionResult HowToRemoveBackgroundFromPortraitPhotoOnline() => View();
        [HttpGet("how-to-erase-background-from-image-automatically-using-ai")] public IActionResult HowToEraseBackgroundFromImageAutomaticallyUsingAI() => View();
        [HttpGet("how-to-remove-background-no-watermark")]
        public IActionResult RemoveBackgroundNoWatermark()
        {
            ViewData["Title"] = "How to Remove Background Without Watermark (Free Methods)";
            ViewData["Description"] = "Learn how to remove background from images without watermark using free online tools, AI, and step-by-step methods.";
            return View();
        }
        [HttpGet("remove-background-without-losing-quality-free")]
        public IActionResult RemoveBackgroundWithoutLosingQualityFree()
        {
            ViewData["Title"] = "How to Remove Background from Image Without Losing Quality (Free Guide)";
            ViewData["Description"] = "Learn how to remove background from images without losing quality using free tools, AI methods, and step-by-step techniques.";
            return View();
        }
    }
}
