using ratpdf.Models.CompressPdfSeo;
using System.Text.Json;

namespace ratpdf.Helpers
{
    public class SchemaHelper
    {
        public static string BuildFaqLdJson(List<FaqItem> faqs)
        {
            var schema = new
            {
                @context = "https://schema.org",
                @type = "FAQPage",
                mainEntity = faqs.ConvertAll(f => new
                {
                    @type = "Question",
                    name = f.Question,
                    acceptedAnswer = new
                    {
                        @type = "Answer",
                        text = f.Answer
                    }
                })
            };
            return JsonSerializer.Serialize(schema);
        }

        public static string BuildRatingLdJson(AggregateRating rating, string productName, string canonicalUrl)
        {
            var schema = new Dictionary<string, object>
            {
                ["@context"] = "https://schema.org",
                ["@type"] = "SoftwareApplication",
                ["name"] = productName,
                ["applicationCategory"] = "UtilityApplication",
                ["operatingSystem"] = "Web",
                ["url"] = canonicalUrl,
                ["image"] = "https://ratpdf.com/images/ratpdf-logo.png",
                ["aggregateRating"] = new Dictionary<string, object>
                {
                    ["@type"] = "AggregateRating",
                    ["ratingValue"] = rating.RatingValue,
                    ["reviewCount"] = rating.ReviewCount,
                    ["bestRating"] = "5",
                    ["worstRating"] = "1"
                }
            };
            return JsonSerializer.Serialize(schema);
        }
        public static string BuildBreadcrumbLdJson(List<BreadcrumbItem> breadcrumbs)
        {
            if (breadcrumbs == null || breadcrumbs.Count < 2) return null; // Breadcrumb needs at least home + current

            var items = breadcrumbs.Select((bc, index) => new
            {
                @type = "ListItem",
                position = index + 1,
                name = bc.Name,
                item = bc.Url
            }).ToList();

            var schema = new
            {
                @context = "https://schema.org",
                @type = "BreadcrumbList",
                itemListElement = items
            };
            return JsonSerializer.Serialize(schema);
        }

        public static string BuildOrganizationLdJson(Organization org)
        {
            if (org == null) return null;

            var schema = new
            {
                @context = "https://schema.org",
                @type = "Organization",
                name = org.Name,
                url = org.Url,
                logo = org.Logo,
                description = org.Description,
                email = org.Email,
                telephone = org.Telephone,
                sameAs = org.SameAs?.Split(',').Select(s => s.Trim()).ToList() ?? new List<string>()
            };
            return JsonSerializer.Serialize(schema);
        }

        public static string BuildWebSiteLdJson(WebSite site)
        {
            if (site == null) return null;

            var schema = new
            {
                @context = "https://schema.org",
                @type = "WebSite",
                name = site.Name,
                url = site.Url,
                potentialAction = !string.IsNullOrEmpty(site.PotentialActionQuery) ? new
                {
                    @type = "SearchAction",
                    target = $"{site.PotentialActionQuery}",
                    query_input = "required name='q'"
                } : null
            };
            return JsonSerializer.Serialize(schema, new JsonSerializerOptions { IgnoreNullValues = true });
        }

        public static string BuildHowToLdJson(string name, string description,
            IReadOnlyList<(string Name, string Text)> steps, string canonicalUrl)
        {
            if (steps == null || steps.Count == 0) return null;

            var schema = new
            {
                @context = "https://schema.org",
                @type = "HowTo",
                name,
                description,
                totalTime = "PT2M",
                tool = new[]
                {
                    new { @type = "HowToTool", name = "Web browser" }
                },
                step = steps.Select((s, i) => new
                {
                    @type = "HowToStep",
                    position = i + 1,
                    name = s.Name,
                    text = s.Text,
                    url = $"{canonicalUrl}#step-{i + 1}"
                }).ToList()
            };
            return JsonSerializer.Serialize(schema);
        }
    }
}

