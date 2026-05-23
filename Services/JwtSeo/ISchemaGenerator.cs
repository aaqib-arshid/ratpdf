using ratpdf.Models;
using System.Text.Json;

namespace ratpdf.Services.JwtSeo
{
    public interface ISchemaGenerator
    {
        string GenerateFaqSchema(List<FaqItem> faqs);
        string GenerateBreadcrumbSchema(string slug, string headingH1);
        string GenerateTechArticleSchema(JwtPageContent content);
    }
    public class SchemaGenerator : ISchemaGenerator
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SchemaGenerator(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GenerateFaqSchema(List<FaqItem> faqs)
        {
            if (faqs == null || faqs.Count == 0)
                return "";

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

        public string GenerateBreadcrumbSchema(string slug, string headingH1)
        {
            var request = _httpContextAccessor.HttpContext?.Request;
            if (request == null) return "";

            var baseUrl = $"{request.Scheme}://{request.Host}";
            var items = new[]
            {
            new { @type = "ListItem", position = 1, name = "Home", item = baseUrl },
            new { @type = "ListItem", position = 2, name = "JWT Tools", item = $"{baseUrl}/jwt-decode" },
            new { @type = "ListItem", position = 3, name = headingH1, item = $"{baseUrl}/jwt-decode/{slug}" }
        };

            var breadcrumb = new
            {
                @context = "https://schema.org",
                @type = "BreadcrumbList",
                itemListElement = items
            };
            return JsonSerializer.Serialize(breadcrumb, new JsonSerializerOptions { WriteIndented = true });
        }

        public string GenerateTechArticleSchema(JwtPageContent content)
        {
            var request = _httpContextAccessor.HttpContext?.Request;
            if (request == null) return "";

            var baseUrl = $"{request.Scheme}://{request.Host}";
            var article = new
            {
                @context = "https://schema.org",
                @type = "TechArticle",
                headline = content.MetaTitle,
                description = content.MetaDescription,
                url = $"{baseUrl}/jwt-decode/{content.Slug}",
                datePublished = content.UpdatedAt.ToString("yyyy-MM-ddTHH:mm:ssZ"),
                dateModified = content.UpdatedAt.ToString("yyyy-MM-ddTHH:mm:ssZ"),
                author = new { @type = "Organization", name = "ratpdf.com" }
            };
            return JsonSerializer.Serialize(article, new JsonSerializerOptions { WriteIndented = true });
        }
    }
}
