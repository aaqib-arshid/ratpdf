namespace ratpdf.Models
{
    public enum ContentKind { Guide, Blog }

    public sealed class ContentEntry
    {
        public required string Slug { get; init; }
        public required string Title { get; init; }
        public required string Description { get; init; }
        public required string Category { get; init; }
        public string? ToolUrl { get; init; }
        public string? Cluster { get; init; }
        public required string BodyHtml { get; init; }
        public DateTime Published { get; init; }
        public DateTime? LastReviewed { get; init; }
        public ContentKind Kind { get; init; }
        public string? AuthorSlug { get; init; }
        public string? ReviewerSlug { get; init; }
        public ContentSource[]? Sources { get; init; }
        public string[]? FaqQuestions { get; init; }
        public string[]? FaqAnswers { get; init; }
        public string[]? HowToSteps { get; init; }

        /// <summary>When set (e.g. "pt"), <see cref="Path"/> uses /{prefix}/guides/{slug}.</summary>
        public string? LocalePrefix { get; init; }
        public string? ToolCtaLabelOverride { get; init; }

        public string Path => LocalePrefix != null
            ? $"/{LocalePrefix.Trim('/')}/guides/{Slug}"
            : Kind == ContentKind.Blog ? $"/blog/{Slug}" : $"/guides/{Slug}";

        public string ToolCtaLabel =>
            ToolCtaLabelOverride ?? (ToolUrl == null ? "Browse PDF tools" : "Use free tool →");
    }
}
