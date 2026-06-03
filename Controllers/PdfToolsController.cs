using Microsoft.AspNetCore.Mvc;

namespace ratpdf.Controllers
{
    public class PdfToolsController : Controller
    {
        [HttpGet("ocr-tool")] public IActionResult OCRTextExtractor() => View();
        [HttpGet("pdf-redaction")] public IActionResult PdfRedaction() => View();
    }
}
