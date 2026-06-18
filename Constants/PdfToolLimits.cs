namespace ratpdf.Constants
{
    /// <summary>Per-tool limits enforced on individual PDF tool pages (not global layout).</summary>
    public static class PdfToolLimits
    {
        /// <summary>Max files per job for Compress, PDF to Word, Images to PDF, etc.</summary>
        public const int MaxBatchFiles = 3;

        /// <summary>General PDF tools — free tier per-file cap.</summary>
        public const long MaxFileSizeBytes = 200L * 1024 * 1024; // 200 MB

        /// <summary>General PDF tools — Pro/Business per-file cap.</summary>
        public const long MaxPremiumFileSizeBytes = 4L * 1024 * 1024 * 1024; // 4 GB

        /// <summary>Edit PDF — free tier per-file cap.</summary>
        public const long EditPdfMaxFileSizeBytes = 10L * 1024 * 1024; // 10 MB

        /// <summary>Edit PDF — Pro/Business per-file cap.</summary>
        public const long EditPdfMaxPremiumFileSizeBytes = 50L * 1024 * 1024; // 50 MB

        /// <summary>All image tools — same cap on Free and Pro.</summary>
        public const long ImageMaxFileSizeBytes = 5L * 1024 * 1024; // 5 MB

        /// <summary>Merge PDF — free tier max files per job.</summary>
        public const int MergeMaxBatchFiles = 10;

        /// <summary>Merge PDF — Pro/Business max files per job.</summary>
        public const int MergeMaxBatchFilesPremium = 40;

        /// <summary>Merge PDF — free tier per-file cap.</summary>
        public const long MergeMaxFileSizeBytes = 10L * 1024 * 1024; // 10 MB

        /// <summary>Merge PDF — Pro/Business per-file cap.</summary>
        public const long MergeMaxPremiumFileSizeBytes = 100L * 1024 * 1024; // 100 MB

        /// <summary>Merge PDF — free tier combined batch cap (10 × 10 MB).</summary>
        public const long MergeMaxTotalBatchBytesFree = 100L * 1024 * 1024;

        /// <summary>Merge PDF — Pro/Business combined batch cap.</summary>
        public const long MergeMaxTotalBatchBytesPremium = 4L * 1024 * 1024 * 1024;

        public const int FreeUsesPerDay = 3;

        /// <summary>Max multipart request size (premium multi-file tools, e.g. 3 × 4 GB).</summary>
        public const long MaxUploadRequestBytes = MaxPremiumFileSizeBytes * MaxBatchFiles;

        /// <summary>Max request body for Merge PDF (Pro combined batch cap + multipart overhead).</summary>
        public const long MergeMaxUploadRequestBytes = MergeMaxTotalBatchBytesPremium + (64L * 1024 * 1024);

        /// <summary>Kestrel / multipart cap — largest upload endpoint limit.</summary>
        public const long GlobalMaxUploadRequestBytes =
            MaxUploadRequestBytes > MergeMaxUploadRequestBytes
                ? MaxUploadRequestBytes
                : MergeMaxUploadRequestBytes;

        /// <summary>Show “may take some time” UX when any upload exceeds this size.</summary>
        public const long LargeFileWarningBytes = 10L * 1024 * 1024;

        public const string LargeFileWarningMessage =
            "This file is greater than 10 MB and may take some time to process. Please keep this tab open.";

        public static bool IsImageTool(string toolId) =>
            string.Equals(toolId, ImageToolIds.Compress, StringComparison.OrdinalIgnoreCase)
            || string.Equals(toolId, ImageToolIds.BackgroundRemove, StringComparison.OrdinalIgnoreCase)
            || string.Equals(toolId, ImageToolIds.Resizer, StringComparison.OrdinalIgnoreCase)
            || string.Equals(toolId, ImageToolIds.BulkCompress, StringComparison.OrdinalIgnoreCase)
            || string.Equals(toolId, ImageToolIds.FormatConverter, StringComparison.OrdinalIgnoreCase);

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
