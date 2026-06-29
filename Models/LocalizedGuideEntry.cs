using ratpdf.Constants;

namespace ratpdf.Models
{
    /// <summary>JSON-backed localized guide loaded from Content/LocalizedGuides/{locale}/{slug}.json.</summary>
    public sealed class LocalizedGuideEntry
    {
        public required string Slug { get; set; }
        public required string SourceSlug { get; set; }
        public required string Locale { get; set; }
        public required string UrlPrefix { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string PrimaryKeyword { get; set; }
        public required string Category { get; set; }
        public string? ToolUrl { get; set; }
        public string? ToolCtaLabel { get; set; }
        public required string BodyHtml { get; set; }
        public string[]? FaqQuestions { get; set; }
        public string[]? FaqAnswers { get; set; }
        public string[]? HowToSteps { get; set; }
        public int SearchScore { get; set; }
        public DateTime? GeneratedAt { get; set; }

        public string Path => GuideLocales.LocalizedGuidePath(UrlPrefix, Slug);

        public string ToolCtaText =>
            !string.IsNullOrWhiteSpace(ToolCtaLabel)
                ? ToolCtaLabel
                : ToolUrl == null
                    ? "Browse PDF tools"
                    : "Use free tool →";

        public ContentEntry ToContentEntry() => new()
        {
            Slug = Slug,
            Title = Title,
            Description = Description,
            Category = Category,
            ToolUrl = ToolUrl,
            BodyHtml = BodyHtml,
            Published = GeneratedAt ?? new DateTime(2026, 6, 1),
            LastReviewed = GeneratedAt,
            Kind = ContentKind.Guide,
            FaqQuestions = FaqQuestions,
            FaqAnswers = FaqAnswers,
            HowToSteps = HowToSteps,
            LocalePrefix = UrlPrefix,
            ToolCtaLabelOverride = ToolCtaLabel,
        };
    }
}
