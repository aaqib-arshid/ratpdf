namespace ratpdf.Models
{
    public sealed class VerticalPdfToolsPageModel
    {
        public required string Slug { get; init; }
        public required string Title { get; init; }
        public required string Description { get; init; }
        public required string H1 { get; init; }
        public required string Lead { get; init; }
        public required string AudienceLabel { get; init; }
        public required (string Name, string Url, string Blurb)[] FeaturedTools { get; init; }
        public required string[] UseCases { get; init; }
        public required (string Question, string Answer)[] Faqs { get; init; }

        public string Path => $"/pdf-tools-for-{Slug}";
    }
}
