using ratpdf.Models.ProgrammaticSeo;

namespace ratpdf.Models
{
    public class SEOPageModel
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string DisplayTitle { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string RoutePrefix { get; set; } = string.Empty;
        public string ToolUrl { get; set; } = string.Empty;
        public string ToolLinkText { get; set; } = string.Empty;
        public string HubPath { get; set; } = string.Empty;
        public string CanonicalUrl { get; set; } = string.Empty;
        public string FullContentHtml { get; set; } = string.Empty;
        public List<(string Question, string Answer)> FAQ { get; set; } = new();
        public List<(string Label, string Path)> RelatedPages { get; set; } = new();
        public List<(string Name, string Url)> RelatedTools { get; set; } = new();
        public List<(string Name, string Text)> HowToSteps { get; set; } = new();
        public ratpdf.Services.Seo.ProgrammaticToolCategory Category { get; set; }
        public SearchIntent Intent { get; set; }
        public double IntentConfidence { get; set; }
        public bool IsPillar { get; set; }
        public bool NoIndex { get; set; } = true;
        public string SchemaApplicationCategory { get; set; } = "UtilitiesApplication";
    }
}
