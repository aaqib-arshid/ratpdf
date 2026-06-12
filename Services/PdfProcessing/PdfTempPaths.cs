namespace ratpdf.Services.PdfProcessing;

public static class PdfTempPaths
{
    public static string NewOutput(string extension)
    {
        var ext = extension.StartsWith('.') ? extension : "." + extension;
        return Path.Combine(Path.GetTempPath(), $"ratpdf_{Guid.NewGuid():N}{ext}");
    }
}
