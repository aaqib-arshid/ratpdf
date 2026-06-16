using ratpdf.Helpers;

namespace ratpdf.Services.Seo
{
    public enum ProgrammaticToolCategory
    {
        GeneralCalculator,
        PdfTool,
    }

    /// <summary>Category and copy templates for programmatic landing pages keyed by parent tool.</summary>
    public static class ProgrammaticToolMetaCatalog
    {
        public static ProgrammaticToolCategory ResolveCategory(string routePrefix, string toolUrl)
        {
            if (routePrefix.Equals("calculator-tools", StringComparison.OrdinalIgnoreCase))
                return ProgrammaticToolCategory.GeneralCalculator;

            return ProgrammaticToolCategory.PdfTool;
        }

        public static string BuildMetaDescription(
            ProgrammaticToolCategory category,
            string displayTitle,
            string toolLinkText)
        {
            return category switch
            {
                ProgrammaticToolCategory.GeneralCalculator =>
                    $"Use the free {displayTitle} on RatPDF. Instant browser-based results — no signup required.",
                _ =>
                    $"Use RatPDF's {toolLinkText} online — {displayTitle.ToLowerInvariant()}. Free: 3 uses/day, 200 MB per file. Secure HTTPS, no install.",
            };
        }

        public static string BuildOgDescription(
            ProgrammaticToolCategory category,
            string displayTitle,
            string toolLinkText) =>
            category switch
            {
                ProgrammaticToolCategory.GeneralCalculator =>
                    $"{displayTitle} — free online calculator on RatPDF with instant results.",
                _ =>
                    $"{displayTitle} with RatPDF {toolLinkText}. Secure browser upload, automatic file deletion.",
            };

        public static string SchemaApplicationCategory(ProgrammaticToolCategory category) =>
            category switch
            {
                ProgrammaticToolCategory.GeneralCalculator => "UtilitiesApplication",
                _ => "UtilitiesApplication",
            };

        public static string BuildPageTitle(string displayTitle, ProgrammaticPageType pageType)
        {
            return pageType switch
            {
                ProgrammaticPageType.Comparison =>
                    $"{displayTitle} — Feature Comparison",
                ProgrammaticPageType.Alternative =>
                    $"{displayTitle} — Free Online",
                ProgrammaticPageType.UseCase =>
                    $"{displayTitle} — Guide",
                ProgrammaticPageType.Location =>
                    $"{displayTitle} — Free & Secure",
                _ => displayTitle,
            };
        }
    }
}
