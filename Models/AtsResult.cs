namespace ratpdf.Models
{
    public class AtsResult
    {
        public double Score { get; set; }
        public double StructureScore { get; set; }
        public double ContentScore { get; set; }
        public double SemanticScore { get; set; }
        public double FormattingScore { get; set; }
    }
}
