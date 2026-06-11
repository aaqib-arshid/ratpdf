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
        public required string BodyHtml { get; init; }
        public DateTime Published { get; init; }
        public ContentKind Kind { get; init; }
        public string[]? FaqQuestions { get; init; }
        public string[]? FaqAnswers { get; init; }

        public string Path => Kind == ContentKind.Blog ? $"/blog/{Slug}" : $"/guides/{Slug}";

        public string ToolCtaLabel =>
            ToolUrl == null ? "Browse PDF tools" : "Use free tool →";
    }
}
