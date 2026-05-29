namespace ratpdf.Models.PaySlipSEO
{
    public class PayslipPageContent
    {
        public string Slug { get; set; } = string.Empty;
        public string MetaTitle { get; set; } = string.Empty;
        public string MetaDescription { get; set; } = string.Empty;
        public string HeadingH1 { get; set; } = string.Empty;
        public string IntroductionHtml { get; set; } = string.Empty;
        public List<ContentSection> Sections { get; set; } = new();
        public List<FaqItem> Faqs { get; set; } = new();
        public string SamplePayslipHtml { get; set; } = string.Empty;  
        public DateTime UpdatedAt { get; set; }
        public List<string> RelatedSlugs { get; set; } = new();
    }
}
