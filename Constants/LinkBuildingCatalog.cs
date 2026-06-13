namespace ratpdf.Constants
{
    public enum LinkAssetType
    {
        Statistics,
        IndustryStudy,
        Calculator,
        InteractiveTool,
        ReferenceGuide,
        FreeTool,
        TemplateGallery,
    }

    public enum LinkAssetTier
    {
        P0 = 0,
        P1 = 1,
        P2 = 2,
        P3 = 3,
    }

    /// <summary>Catalog of link-worthy assets ranked by editorial backlink potential (not programmatic SEO volume).</summary>
    public static class LinkBuildingCatalog
    {
        public const string HubPath = "/resources";

        public sealed record LinkAsset(
            string Slug,
            string Title,
            string Description,
            string Path,
            LinkAssetType Type,
            LinkAssetTier Tier,
            int BacklinkScore,
            string[] LinkMagnets,
            bool IsLive,
            string? AuthorSlug = null);

        /// <summary>Score 1–100: likelihood of earning editorial/citation links in PDF/SMB niche.</summary>
        public static readonly LinkAsset[] All =
        [
            new(
                "attachment-size-limits",
                "Email & Portal PDF Attachment Size Limits (2026)",
                "Reference table of Gmail, Outlook, WhatsApp, job portal, and government upload limits — with official sources.",
                "/research/attachment-size-limits",
                LinkAssetType.Statistics,
                LinkAssetTier.P0,
                95,
                ["Reference table", "Citable canonical URL", "Interactive size checker cross-link"],
                true,
                "ethan-brooks"),
            new(
                "pdf-compression-benchmark",
                "PDF Compression Benchmark Study 2026",
                "Methodology and results for digital, scanned, and invoice PDFs at different compression quality levels.",
                "/research/pdf-compression-benchmark",
                LinkAssetType.IndustryStudy,
                LinkAssetTier.P0,
                92,
                ["Original data", "Methodology section", "Downloadable summary table"],
                true,
                "ethan-brooks"),
            new(
                "freelancer-invoicing-statistics",
                "Freelancer & SMB Invoicing Statistics 2026",
                "Payment terms, late payments, and common invoice mistakes — with sources for freelancers and SMBs.",
                "/research/freelancer-invoicing-statistics",
                LinkAssetType.Statistics,
                LinkAssetTier.P0,
                90,
                ["Industry statistics", "Cited sources", "Regional breakdown"],
                true,
                "priya-sharma"),
            new(
                "pdf-size-checker",
                "Will My PDF Fit? Size Checker",
                "Interactive tool: pick a destination (email, portal, form) and file size — instant pass/fail with compress link.",
                "/pdf-size-checker",
                LinkAssetType.InteractiveTool,
                LinkAssetTier.P0,
                88,
                ["Interactive utility", "Embeddable result", "Links to compress tool"],
                true),
            new(
                "gst-invoice-checker",
                "GST Invoice Compliance Checker (India)",
                "Interactive checklist: does your tax invoice include mandatory GST fields?",
                "/gst-invoice-checker",
                LinkAssetType.Calculator,
                LinkAssetTier.P0,
                87,
                ["Country-specific compliance", "Shareable score", "Links to invoice generator"],
                true,
                "priya-sharma"),
            new(
                "freelance-rate-calculator",
                "Freelance Hourly Rate Calculator",
                "Work out your minimum hourly rate from income goals, taxes, expenses, and billable hours.",
                "/freelance-rate-calculator",
                LinkAssetType.Calculator,
                LinkAssetTier.P1,
                85,
                ["Calculator", "Shareable result URL", "Links to invoice tool"],
                true,
                "priya-sharma"),
            new(
                "document-retention-periods",
                "Document Retention Periods by Type & Region",
                "How long to keep invoices, tax records, and contracts in India, UK, US, Australia, and Canada.",
                "/research/document-retention-periods",
                LinkAssetType.ReferenceGuide,
                LinkAssetTier.P1,
                82,
                ["Reference table", "Multi-jurisdiction", "Compliance citations"],
                true,
                "priya-sharma"),
            new(
                "compare-matrix",
                "PDF Tool Comparison Matrix 2026",
                "Feature-by-feature comparison of RatPDF vs iLovePDF, Smallpdf, Adobe, and others.",
                "/compare",
                LinkAssetType.ReferenceGuide,
                LinkAssetTier.P1,
                80,
                ["Comparison chart", "Commercial intent"],
                true),
            new(
                "pdf-toolkit",
                $"Free PDF Toolkit ({PdfToolSeo.ToolCountLabel} tools)",
                "Browse every free PDF tool: compress, merge, convert, OCR, sign, and secure workflows.",
                "/guides/pdf-tools",
                LinkAssetType.FreeTool,
                LinkAssetTier.P1,
                78,
                ["Free tools", "No signup"],
                true),
            new(
                "invoice-templates",
                "Free Invoice Template Gallery",
                "Create and download professional invoice PDFs — GST/VAT ready, 50+ currencies.",
                "/Invoice/Create",
                LinkAssetType.TemplateGallery,
                LinkAssetTier.P1,
                76,
                ["Templates", "Free download"],
                false),
            new(
                "pdf-accessibility-checker",
                "PDF Accessibility Quick-Check",
                "WCAG-oriented checks for tagged PDFs, alt text, reading order — gov/edu accessibility posts link to free checkers.",
                "/pdf-accessibility-checker",
                LinkAssetType.InteractiveTool,
                LinkAssetTier.P2,
                74,
                ["Accessibility", "Gov/edu links"],
                false),
            new(
                "vat-invoice-checker",
                "VAT Invoice Checker (UK/EU)",
                "Interactive compliance checker for VAT invoice mandatory fields.",
                "/vat-invoice-checker",
                LinkAssetType.Calculator,
                LinkAssetTier.P2,
                72,
                ["UK/EU compliance"],
                false),
            new(
                "content-decay-detector",
                "Content Decay Detector (GSC)",
                "SEO tool using Google Search Console — marketing blogs link to free GSC utilities.",
                "/tools/gscindex",
                LinkAssetType.InteractiveTool,
                LinkAssetTier.P2,
                70,
                ["SEO utility", "Original report output"],
                true),
            new(
                "ring-size-converter",
                "International Ring Size Converter",
                "Reference table + converter — jewelry and fashion blogs embed ring size charts.",
                "/tools/ringsizeconverter",
                LinkAssetType.InteractiveTool,
                LinkAssetTier.P3,
                55,
                ["Reference data", "Off-niche"],
                true),
        ];

        public static LinkAsset? Get(string slug) =>
            All.FirstOrDefault(a => a.Slug.Equals(slug, StringComparison.OrdinalIgnoreCase));

        public static IEnumerable<LinkAsset> Live => All.Where(a => a.IsLive).OrderBy(a => a.Tier).ThenByDescending(a => a.BacklinkScore);

        public static IEnumerable<LinkAsset> Planned => All.Where(a => !a.IsLive).OrderBy(a => a.Tier).ThenByDescending(a => a.BacklinkScore);

        public static IEnumerable<string> SitemapPaths() =>
            All.Where(a => a.IsLive && a.Path.StartsWith("/research", StringComparison.OrdinalIgnoreCase))
                .Select(a => a.Path)
                .Concat([
                    "/resources",
                    "/pdf-size-checker",
                    "/gst-invoice-checker",
                    "/freelance-rate-calculator",
                ])
                .Distinct(StringComparer.OrdinalIgnoreCase);
    }
}
