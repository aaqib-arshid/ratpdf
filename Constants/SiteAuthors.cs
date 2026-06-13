using ratpdf.Models;

namespace ratpdf.Constants
{
    public sealed record SiteAuthor(
        string Slug,
        string Name,
        string JobTitle,
        string Bio,
        string[] Expertise,
        string[] KnowsAbout,
        string? Email = null);

    /// <summary>Editorial team for E-E-A-T author pages and article bylines.</summary>
    public static class SiteAuthors
    {
        public const string HubPath = "/authors";
        public const string DefaultAuthorSlug = "ethan-brooks";
        public const string DefaultReviewerSlug = "james-cole";

        public static readonly SiteAuthor[] All =
        [
            new(
                "ethan-brooks",
                "Ethan Brooks",
                "Editor-in-Chief & Product Lead",
                "Ethan leads RatPDF editorial and tests PDF merge, compress, and Office conversion workflows on real client documents. He documents engine behavior (Ghostscript, pdf2docx, LibreOffice) so guides reflect actual tool output.",
                ["PDF conversion", "Document automation", "Programmatic SEO", "Small business workflows"],
                ["PDF compression", "PDF merge", "PDF to Word", "Online PDF tools"],
                SiteEntity.ContactEmail),
            new(
                "priya-sharma",
                "Priya Sharma",
                "Senior Editor — PDF & Business Documents",
                "Priya specializes in GST invoices, payslip PDFs, and India/UK business document compliance. She reviews conversion accuracy on financial PDFs and writes guides for accountants and freelancers.",
                ["GST invoicing", "PDF for business", "Financial document PDFs", "India tax compliance"],
                ["GST invoice PDF", "Invoice generator", "PDF to Excel", "Business PDF workflow"],
                "priya@ratpdf.com"),
            new(
                "james-cole",
                "James Cole",
                "Security & Compliance Editor",
                "James reviews password protection, watermarking, signature, and privacy claims against RatPDF behavior and industry guidance. He fact-checks security comparisons and editorial corrections.",
                ["PDF encryption", "Data privacy", "Document security", "Compliance writing"],
                ["PDF password protection", "PDF watermark", "PDF signatures", "GDPR-aware file handling"],
                "james@ratpdf.com"),
        ];

        private static readonly Dictionary<string, SiteAuthor> BySlug =
            All.ToDictionary(a => a.Slug, StringComparer.OrdinalIgnoreCase);

        public static SiteAuthor? Get(string? slug) =>
            string.IsNullOrEmpty(slug) ? null : BySlug.GetValueOrDefault(slug);

        public static SiteAuthor GetRequired(string slug) =>
            Get(slug) ?? throw new KeyNotFoundException($"Author not found: {slug}");

        public static string PersonId(string slug) => $"{SiteEntity.SiteUrl}/authors/{slug}#person";

        public static string ProfileUrl(string slug) => PdfToolSeo.Canonical($"{HubPath}/{slug}");

        public static (string AuthorSlug, string ReviewerSlug) ResolveForContent(string slug, string category)
        {
            slug = slug.ToLowerInvariant();
            if (slug.Contains("gst") || slug.Contains("invoice") || category.Equals("Business", StringComparison.OrdinalIgnoreCase))
                return ("priya-sharma", "ethan-brooks");
            if (slug.Contains("password") || slug.Contains("watermark") || slug.Contains("sign-pdf")
                || slug.Contains("secure") || category.Equals("Security", StringComparison.OrdinalIgnoreCase))
                return ("james-cole", "ethan-brooks");
            if (slug.Contains("ocr") || slug.Contains("pdf-to-word") || slug.Contains("compress"))
                return ("ethan-brooks", "james-cole");
            return (DefaultAuthorSlug, DefaultReviewerSlug);
        }

        public static IReadOnlyList<ContentEntry> FilterByAuthor(IEnumerable<ContentEntry> entries, string authorSlug) =>
            entries.Where(e => string.Equals(e.AuthorSlug, authorSlug, StringComparison.OrdinalIgnoreCase)).ToList();
    }
}
