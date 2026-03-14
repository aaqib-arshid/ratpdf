namespace ratpdf.Models
{
    public class SEOPageModel
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string FullContentHtml { get; set; } = string.Empty; // Entire 1800-2500 words as HTML
        public List<(string Question, string Answer)> FAQ { get; set; } = new();
    }
}
