using ratpdf.Helpers;

namespace ratpdf.Services.Seo
{
    public enum ProgrammaticToolCategory
    {
        MedicalCalculator,
        GeneralCalculator,
        PdfTool,
    }

    /// <summary>Category and copy templates for programmatic landing pages keyed by parent tool.</summary>
    public static class ProgrammaticToolMetaCatalog
    {
        public static ProgrammaticToolCategory ResolveCategory(string routePrefix, string toolUrl)
        {
            if (routePrefix.StartsWith("medical", StringComparison.OrdinalIgnoreCase))
                return ProgrammaticToolCategory.MedicalCalculator;

            if (routePrefix.Equals("calculator-tools", StringComparison.OrdinalIgnoreCase))
                return ProgrammaticToolCategory.GeneralCalculator;

            var path = toolUrl.Trim().TrimEnd('/').ToLowerInvariant();
            if (path is "/bmi-calculator" or "/egfr-calculator" or "/heart-score"
                or "/cha2ds2-vasc-score" or "/wells-score" or "/has-bled-score"
                or "/nihss-calculator" or "/gcs-calculator" or "/map-calculator"
                or "/parkland-formula")
                return ProgrammaticToolCategory.MedicalCalculator;

            return ProgrammaticToolCategory.PdfTool;
        }

        public static string BuildMetaDescription(
            ProgrammaticToolCategory category,
            string displayTitle,
            string toolLinkText)
        {
            return category switch
            {
                ProgrammaticToolCategory.MedicalCalculator =>
                    $"Use the free {displayTitle} on RatPDF. Browser-based clinical calculator — no signup, no patient data stored. For educational use only.",
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
                ProgrammaticToolCategory.MedicalCalculator =>
                    $"{displayTitle} — free educational clinical calculator on RatPDF. No patient identifiers stored.",
                ProgrammaticToolCategory.GeneralCalculator =>
                    $"{displayTitle} — free online calculator on RatPDF with instant results.",
                _ =>
                    $"{displayTitle} with RatPDF {toolLinkText}. Secure browser upload, automatic file deletion.",
            };

        public static string SchemaApplicationCategory(ProgrammaticToolCategory category) =>
            category switch
            {
                ProgrammaticToolCategory.MedicalCalculator => "MedicalApplication",
                ProgrammaticToolCategory.GeneralCalculator => "UtilitiesApplication",
                _ => "UtilitiesApplication",
            };

        public static string ClinicalFormulaHint(string toolUrl)
        {
            var path = toolUrl.Trim().TrimEnd('/').ToLowerInvariant();
            return path switch
            {
                "/bmi-calculator" => "standard BMI formula (weight ÷ height²)",
                "/egfr-calculator" => "CKD-EPI / MDRD eGFR equations",
                "/heart-score" => "HEART score for chest pain (Six AJ et al.)",
                "/cha2ds2-vasc-score" => "CHA₂DS₂-VASc stroke risk score",
                "/wells-score" => "Wells criteria for DVT/PE",
                _ => "published clinical scoring method",
            };
        }

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
