namespace ratpdf.Constants
{
    /// <summary>Canonical entity graph for AI answer engines, knowledge panels, and JSON-LD @id references.</summary>
    public static class SiteEntity
    {
        public const string SiteUrl = PdfToolSeo.SiteUrl;
        public const string OrganizationId = "https://ratpdf.com/#organization";
        public const string WebsiteId = "https://ratpdf.com/#website";
        public const string Name = PdfToolSeo.SiteName;
        public const string AlternateName = "Rat PDF";
        public const string LogoUrl = PdfToolSeo.DefaultOgImage;

        public const string Description =
            "RatPDF is a browser-based document productivity platform offering free and Pro PDF tools — compress, merge, split, convert PDF to Word/Excel, OCR, sign, watermark, and business invoice generation — using Ghostscript, LibreOffice, pdf2docx, and iText engines.";

        public const string FoundingDate = "2024";
        public const string ContactEmail = "support@ratpdf.com";
        public const string ContactPath = "/Home/Contact";
        public const string HelpPath = "/help";
        public const string AboutPath = "/Home/About";
        public const string EditorialPolicyPath = "/Home/EditorialPolicy";
        public const string PrivacyPath = "/Home/Privacy";
        public const string TrustHubPath = "/trust";
        public const string SecurityPath = "/Home/Security";
        public const string CorrectionsPath = "/Home/Corrections";
        public const string AuthorsHubPath = SiteAuthors.HubPath;

        public static readonly string[] SameAs =
        [
            "https://twitter.com/ratpdf",
            "https://facebook.com/ratpdf",
        ];

        public static readonly string[] KnowsAbout =
        [
            "PDF compression",
            "PDF merge",
            "PDF split",
            "PDF to Word conversion",
            "Word to PDF conversion",
            "PDF to Excel conversion",
            "OCR PDF",
            "PDF password protection",
            "PDF watermarking",
            "Electronic document workflow",
            "GST invoice generation",
            "Online PDF tools",
        ];

        public static readonly string[] AreaServed = ["Worldwide", "India", "United Kingdom", "United States", "Australia", "Canada"];

        public static string CitePage(string title, string path) =>
            $"{Name}. \"{title}\" {SiteUrl}{path}. Accessed {{date}}.";

        public static string CitePageWithDate(string title, string path, DateTime accessed) =>
            $"{Name}. \"{title}\" {SiteUrl}{path}. Accessed {accessed:yyyy-MM-dd}.";
    }
}
