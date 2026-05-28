using Microsoft.AspNetCore.Mvc;
using ratpdf.Models.RentReceipt;
using ratpdf.Services.RentReceipt;

namespace ratpdf.Controllers
{
    [Route("rent-receipt-generator")]
    public class RentReceiptController : Controller
    {
        private readonly RentReceiptPdfService _pdf;

        public RentReceiptController(RentReceiptPdfService pdf)
        {
            _pdf = pdf;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("generate")]
        public IActionResult Generate(RentReceiptModel model)
        {
            var pdf = _pdf.Generate(model);

            return File(pdf, "application/pdf", "rent-receipt.pdf");
        }
    }
}
