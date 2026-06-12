namespace ratpdf.Services.PdfProcessing;

public sealed class PdfProcessingOptions
{
    public const string SectionName = "PdfProcessing";

    /// <summary>Stream copy / blob buffer size (default 4 MB).</summary>
    public int StreamBufferBytes { get; set; } = 4 * 1024 * 1024;

    /// <summary>Max jobs processed concurrently per instance. Keep at 1 for multi-GB PDFs.</summary>
    public int MaxConcurrentJobs { get; set; } = 1;

    /// <summary>Max queued jobs before producers block.</summary>
    public int MaxQueuedJobs { get; set; } = 32;
}
