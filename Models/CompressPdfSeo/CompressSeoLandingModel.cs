namespace ratpdf.Models.CompressPdfSeo
{
    /// <summary>Rich landing page model for programmatic PDF compression SEO pages.</summary>
    public class CompressSeoLandingModel : SeoPageModel
    {
        public string H1 { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string HubPath { get; set; } = "/compress-pdf";
        public string ToolPath { get; set; } = "/pdf/compress";
        public string PageCategory { get; set; } = string.Empty;
        public List<(string Label, string Path)> RelatedPages { get; set; } = new();
        public List<(string Name, string Text)> HowToSteps { get; set; } = new();
        public List<(string Name, string Url)> RelatedTools { get; set; } = new();
    }
}
