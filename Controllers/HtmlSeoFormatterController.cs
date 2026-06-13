using Microsoft.AspNetCore.Mvc;
using ratpdf.Models;
using ratpdf.Services.HtmlSeo;
using ratpdf.Services.JwtSeo;

namespace ratpdf.Controllers
{
    [Route("html-formatter")]
    public class HtmlSeoFormatterController : Controller
    {
        private readonly IHtmlContentGenerator _contentGenerator;
        private readonly IHtmlAllowedSlugsService _allowedSlugs;
        private readonly ISchemaGenerator _schemaGenerator; 
        private readonly ICacheService _cache;

        public HtmlSeoFormatterController(IHtmlContentGenerator contentGenerator, IHtmlAllowedSlugsService allowedSlugs, ISchemaGenerator schemaGenerator, ICacheService cache)
        {
            _contentGenerator = contentGenerator;
            _allowedSlugs = allowedSlugs;
            _schemaGenerator = schemaGenerator;
            _cache = cache;
        }

        [HttpGet("{slug}")]
        public async Task<IActionResult> Index(string slug)
        {
            if (string.IsNullOrWhiteSpace(slug) || !_allowedSlugs.IsValidSlug(slug))
                return NotFound();

            var content = await _contentGenerator.GenerateAsync(slug);
            if (content == null)
                return NotFound();


            var breadcrumbSchema = GenerateBreadcrumbSchema(slug, content.HeadingH1);
            var faqSchema = _schemaGenerator.GenerateFaqSchema(content.Faqs);

            var viewModel = new HtmlFormatterViewModel
            {
                Content = content,
                BreadcrumbSchema = breadcrumbSchema,
                FaqSchema = faqSchema
            };
            return View(viewModel);
        }

        private string GenerateBreadcrumbSchema(string slug, string headingH1)
        {
            var baseUrl = ratpdf.Constants.PdfToolSeo.SiteUrl;
            var items = new[]
            {
            new { @type = "ListItem", position = 1, name = "Home", item = baseUrl },
            new { @type = "ListItem", position = 2, name = "HTML Tools", item = $"{baseUrl}/html-formatter" },
            new { @type = "ListItem", position = 3, name = headingH1, item = $"{baseUrl}/html-formatter/{slug}" }
        };
            var breadcrumb = new { @context = "https://schema.org", @type = "BreadcrumbList", itemListElement = items };
            return System.Text.Json.JsonSerializer.Serialize(breadcrumb, new System.Text.Json.JsonSerializerOptions { WriteIndented = true });
        }
    }

    public class HtmlFormatterViewModel
    {
        public HtmlPageContent Content { get; set; } = null!;
        public string BreadcrumbSchema { get; set; } = string.Empty;
        public string FaqSchema { get; set; } = string.Empty;
    }
}

