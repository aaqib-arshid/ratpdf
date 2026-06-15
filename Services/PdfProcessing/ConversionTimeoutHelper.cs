namespace ratpdf.Services.PdfProcessing;

/// <summary>Size-aware conversion timeouts shared by Python office/image/OCR processors.</summary>
public static class ConversionTimeoutHelper
{
    /// <summary>
    /// Scales timeout with input file size (45 s/MB, min base, max 1 hour).
    /// Matches Pdf-Engine Python <c>_conversion_timeout</c> and <see cref="PdfToDocxProcessor"/>.
    /// </summary>
    public static int ResolveSeconds(string? inputPath, int baseTimeoutSeconds)
    {
        if (string.IsNullOrWhiteSpace(inputPath) || !File.Exists(inputPath))
            return baseTimeoutSeconds;

        try
        {
            var sizeMb = Math.Max(1, (int)(new FileInfo(inputPath).Length / (1024 * 1024)));
            return Math.Min(3600, Math.Max(baseTimeoutSeconds, sizeMb * 45));
        }
        catch
        {
            return baseTimeoutSeconds;
        }
    }
}
