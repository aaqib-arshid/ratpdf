namespace ratpdf.Models
{
    public class PdfToolLimitsDto
    {
        public bool IsPremium { get; set; }
        public long MaxFileSizeBytes { get; set; }
        public int MaxBatchFiles { get; set; }
        public int FreeUsesPerDay { get; set; }
        public string MaxFileSizeLabel { get; set; } = "";
        /// <summary>Pro Merge PDF — max combined bytes for all files in one job.</summary>
        public long? MaxTotalBatchBytes { get; set; }
        public string? MaxTotalBatchLabel { get; set; }
    }
}
