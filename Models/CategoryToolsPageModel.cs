namespace ratpdf.Models
{
    public sealed class CategoryToolsPageModel
    {
        public required string Slug { get; init; }
        public required string Path { get; init; }
        public required string Title { get; init; }
        public required string Description { get; init; }
        public required string H1 { get; init; }
        public required string Lead { get; init; }
        public required string CategoryLabel { get; init; }
        public required (string Name, string Url, string Blurb)[] FeaturedTools { get; init; }
        public required string[] UseCases { get; init; }
        public required (string Question, string Answer)[] Faqs { get; init; }
        public string? HubBreadcrumbLabel { get; init; }
        public string? HubBreadcrumbPath { get; init; }
    }
}
