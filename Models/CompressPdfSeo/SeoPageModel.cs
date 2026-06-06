using Google.Apis.SearchConsole.v1.Data;

namespace ratpdf.Models.CompressPdfSeo
{
    public class SeoPageModel
    {
        public string Title { get; set; } = string.Empty;
        public string MetaDescription { get; set; } = string.Empty;
        public string CanonicalUrl { get; set; } = string.Empty;
        public string ContentHtml { get; set; } = string.Empty;

        public string LdJson { get; set; } = string.Empty;

        public List<FaqItem> FaqItems { get; set; }

        public AggregateRating Rating { get; set; }
        public List<BreadcrumbItem> Breadcrumbs { get; set; }
        public Organization Organization { get; set; }

        public WebSite WebSite { get; set; }
    }
    public class FaqItem
    {
        public string Question { get; set; } = string.Empty;
        public string Answer { get; set; } = string.Empty;
    }

    public class AggregateRating
    {
        public double RatingValue { get; set; }  
        public int ReviewCount { get; set; }
    }
    public class BreadcrumbItem
    {
        public string Name { get; set; } = string.Empty;     // e.g., "Home", "PDF Tools"
        public string Url { get; set; } = string.Empty;     // absolute URL
    }

    public class Organization
    {
        public string Name { get; set; } = string.Empty;          // "ratpdf.com"
        public string Url { get; set; } = string.Empty;         // "https://ratpdf.com"
        public string Logo { get; set; } = string.Empty;         // URL to logo image
        public string SameAs { get; set; } = string.Empty;       // Comma-separated or List<string> for social profiles
        public string Description { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telephone { get; set; } = string.Empty;
    }

    public class WebSite
    {
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string PotentialActionQuery { get; set; } = string.Empty;   // e.g., "https://ratpdf.com/search?q={query}"
    }
}
