namespace ratpdf.Constants
{
    /// <summary>Per-tool limits enforced on individual PDF tool pages (not global layout).</summary>
    public static class PdfToolLimits
    {
        public const int MaxBatchFiles = 3;
        public const long MaxFileSizeBytes = 200L * 1024 * 1024; // 200 MB free tier
        public const long MaxPremiumFileSizeBytes = 4L * 1024 * 1024 * 1024; // 4 GB subscribers
        public const int FreeUsesPerDay = 3;

        /// <summary>Max multipart request size (premium batch upload).</summary>
        public const long MaxUploadRequestBytes = MaxPremiumFileSizeBytes * MaxBatchFiles;
    }
}
