namespace ratpdf.Services.PdfProcessing;

public static class PdfStreamCopy
{
    public static async Task<long> CopyToFileAsync(
        Stream source,
        string destinationPath,
        int bufferSize,
        CancellationToken ct = default)
    {
        await using var dest = new FileStream(
            destinationPath,
            FileMode.Create,
            FileAccess.Write,
            FileShare.None,
            bufferSize,
            useAsync: true);

        if (source.CanSeek)
            source.Position = 0;

        await source.CopyToAsync(dest, bufferSize, ct);
        return dest.Length;
    }
}
