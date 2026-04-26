namespace ratpdf.Models
{
    public class GlobalSeoPageModel
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;

        public string FullContentHtml { get; set; } = string.Empty; //5000 words least

    }
}
