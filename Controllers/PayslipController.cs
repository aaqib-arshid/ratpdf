using Microsoft.AspNetCore.Mvc;
using ratpdf.Models.PaySlip;
using ratpdf.Services.PaySlip;

namespace ratpdf.Controllers
{
    [Route("free-payslip-generator")]
    public class PayslipController : Controller
    {
        private readonly PayslipPdfService _pdfService;

        public PayslipController(PayslipPdfService pdfService)
        {
            _pdfService = pdfService;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("generate")]
        public IActionResult Generate(PayslipModel model)
        {
            if (model.CompanyLogo != null)
            {
                var allowed =
                    new[] { ".png", ".jpg", ".jpeg" };

                var extension =
                    Path.GetExtension(
                        model.CompanyLogo.FileName
                    ).ToLower();

                if (!allowed.Contains(extension))
                {
                    ModelState.AddModelError(
                        "",
                        "Only PNG and JPG images allowed."
                    );

                    return View("Index", model);
                }
            }
            var pdfBytes = _pdfService.GeneratePdf(model);

            return File(
                pdfBytes,
                "application/pdf",
                "payslip.pdf"
            );
        }
    }
}
