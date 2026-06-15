namespace ratpdf.Constants
{
    /// <summary>Per-tool limits enforced on individual PDF tool pages (not global layout).</summary>
    public static class PdfToolLimits
    {
        /// <summary>Max files per job for Compress, PDF to Word, Images to PDF, etc.</summary>
        public const int MaxBatchFiles = 3;

        /// <summary>Only Merge PDF allows more than <see cref="MaxBatchFiles"/> files in one job.</summary>
        public const int MergeMaxBatchFiles = 30;

        public const long MaxFileSizeBytes = 50L * 1024 * 1024; // 50 MB free tier
        public const long MaxPremiumFileSizeBytes = 100L * 1024 * 1024; // 100 MB Pro (Edit PDF and most tools)

        /// <summary>Pro/Business Merge PDF — combined size of all files in one merge job.</summary>
        public const long MergeMaxTotalBatchBytesPremium = 4L * 1024 * 1024 * 1024;

        public const int FreeUsesPerDay = 3;

        /// <summary>Max multipart request size (premium multi-file tools, e.g. 3 × 4 GB).</summary>
        public const long MaxUploadRequestBytes = MaxPremiumFileSizeBytes * MaxBatchFiles;

        /// <summary>Max request body for Merge PDF (Pro combined batch cap + multipart overhead).</summary>
        public const long MergeMaxUploadRequestBytes = MergeMaxTotalBatchBytesPremium + (64L * 1024 * 1024);

        /// <summary>Show “may take some time” UX when any upload exceeds this size.</summary>
        public const long LargeFileWarningBytes = 10L * 1024 * 1024;

        public const string LargeFileWarningMessage =
            "This file is greater than 10 MB and may take some time to process. Please keep this tab open.";

        public static int ResolveMaxBatchFiles(string toolId)
        {
            if (string.Equals(toolId, PdfToolIds.Merge, StringComparison.OrdinalIgnoreCase))
                return MergeMaxBatchFiles;

            if (IsMultiFileTool(toolId))
                return MaxBatchFiles;

            return 1;
        }

        public static bool IsMultiFileTool(string toolId) =>
            string.Equals(toolId, PdfToolIds.PdfToDoc, StringComparison.OrdinalIgnoreCase)
            || string.Equals(toolId, PdfToolIds.Compress, StringComparison.OrdinalIgnoreCase)
            || string.Equals(toolId, PdfToolIds.ConvertImages, StringComparison.OrdinalIgnoreCase);
    }
}
