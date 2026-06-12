namespace ratpdf.Models
{
    public class SEOPageModel
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        /// <summary>URL prefix for long-tail landing pages, e.g. unlock-pdf.</summary>
        public string RoutePrefix { get; set; } = string.Empty;
        public string ToolUrl { get; set; } = string.Empty;
        public string ToolLinkText { get; set; } = string.Empty;
        public string FullContentHtml { get; set; } = string.Empty; // Entire 1800-2500 words as HTML
        public List<(string Question, string Answer)> FAQ { get; set; } = new();
    }
}
