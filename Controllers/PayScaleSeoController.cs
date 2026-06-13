using Microsoft.AspNetCore.Mvc;
using ratpdf.Models;
using ratpdf.Models.PaySlipSEO;
using ratpdf.Services.PayslipSeo;
using System.Text.Json;

namespace ratpdf.Controllers
{
    [Route("salary-slip")]
    public class PayScaleSeoController : Controller
    {
        private readonly IPayslipContentGenerator _contentGenerator;
        private readonly IPayslipAllowedSlugsService _slugService;

        public PayScaleSeoController(IPayslipContentGenerator contentGenerator, IPayslipAllowedSlugsService slugService)
        {
            _contentGenerator = contentGenerator;
            _slugService = slugService;
        }

        [HttpGet("{slug}")]
        public async Task<IActionResult> Index(string slug)
        {
            if (string.IsNullOrWhiteSpace(slug) || !_slugService.IsValidSlug(slug))
                return NotFound();

            var content = await _contentGenerator.GenerateAsync(slug);
            if (content == null)
                return NotFound();

            var viewModel = new PayslipSeoViewModel
            {
                Content = content,
                BreadcrumbSchema = GenerateBreadcrumbSchema(slug, content.HeadingH1),
                FaqSchema = GenerateFaqSchema(content.Faqs)
            };
            return View("PayslipSeo", viewModel);
        }

        private string GenerateBreadcrumbSchema(string slug, string headingH1)
        {
            var baseUrl = ratpdf.Constants.PdfToolSeo.SiteUrl;
            var items = new[]
            {
                new { @type = "ListItem", position = 1, name = "Home", item = baseUrl },
                new { @type = "ListItem", position = 2, name = "Pay Slip Tools", item = $"{baseUrl}/free-payslip-generator" },
                new { @type = "ListItem", position = 3, name = headingH1, item = $"{baseUrl}/free-payslip-generator/{slug}" }
            };
            var breadcrumb = new { @context = "https://schema.org", @type = "BreadcrumbList", itemListElement = items };
            return JsonSerializer.Serialize(breadcrumb, new JsonSerializerOptions { WriteIndented = true });
        }

        private string GenerateFaqSchema(List<FaqItem> faqs)
        {
            if (faqs == null || !faqs.Any()) return "";
            var faqSchema = new
            {
                @context = "https://schema.org",
                @type = "FAQPage",
                mainEntity = faqs.Select(f => new
                {
                    @type = "Question",
                    name = f.Question,
                    acceptedAnswer = new { @type = "Answer", text = f.Answer }
                })
            };
            return JsonSerializer.Serialize(faqSchema, new JsonSerializerOptions { WriteIndented = true });
        }
    }

    public class PayslipSeoViewModel
    {
        public PayslipPageContent Content { get; set; } = null!;
        public string BreadcrumbSchema { get; set; } = string.Empty;
        public string FaqSchema { get; set; } = string.Empty;
    }
}

