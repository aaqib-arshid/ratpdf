using Microsoft.AspNetCore.Mvc;

namespace ratpdf.Controllers
{
    [Route("img-background-remove")]
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
    }
}
