using Microsoft.AspNetCore.Mvc;
using ratpdf.Models;
using ratpdf.Services.JwtSeo;

namespace ratpdf.Controllers
{
    [Route("jwt-decode")]
    public class JwtSeoController : Controller
    {
        private readonly IContentGenerator _contentGenerator;
        private readonly IAllowedSlugsService _allowedSlugs;
        private readonly ISchemaGenerator _schemaGenerator;
        private readonly ICacheService _cache;

        public JwtSeoController(IContentGenerator contentGenerator, IAllowedSlugsService allowedSlugs, ISchemaGenerator schemaGenerator, ICacheService cache)
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

            var viewModel = new JwtDecodeViewModel
            {
                Content = content,
                BreadcrumbSchema = _schemaGenerator.GenerateBreadcrumbSchema(content.Slug, content.HeadingH1),
                FaqSchema = _schemaGenerator.GenerateFaqSchema(content.Faqs),
                TechArticleSchema = _schemaGenerator.GenerateTechArticleSchema(content)
            };
            return View(viewModel);
        }
    }
    public class JwtDecodeViewModel
    {
        public JwtPageContent Content { get; set; } = null!;
        public string BreadcrumbSchema { get; set; } = string.Empty;
        public string FaqSchema { get; set; } = string.Empty;
        public string TechArticleSchema { get; set; } = string.Empty;
    }
}
