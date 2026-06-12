using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace ratpdf.Services.PdfProcessing;

/// <summary>
/// Stages job inputs in blob storage and materializes them to temp files for tools that need local paths.
/// Blob storage is the source of truth; disk is a short-lived processing scratch space.
/// </summary>
public sealed class PdfJobStorageService
{
    private readonly AzureBlobService _blob;
    private readonly PdfProcessingOptions _options;
    private readonly ILogger<PdfJobStorageService> _logger;

    public PdfJobStorageService(
        AzureBlobService blob,
        IOptions<PdfProcessingOptions> options,
        ILogger<PdfJobStorageService> logger)
    {
        _blob = blob;
        _options = options.Value;
        _logger = logger;
    }

    public int BufferSize => _options.StreamBufferBytes;

    public async Task<string> StageFormFileAsync(
        IFormFile file, string jobId, CancellationToken ct = default)
    {
        await using var stream = file.OpenReadStream();
        return await StageStreamAsync(stream, jobId, file.FileName, ct);
    }

    public async Task<string> StageStreamAsync(
        Stream source, string jobId, string fileName, CancellationToken ct = default)
    {
        var safeName = SanitizeFileName(fileName);
        var blobName = $"staging/{jobId}/{safeName}";
        await _blob.UploadStreamAsync(source, blobName, ct);
        _logger.LogDebug("Staged {FileName} to blob {BlobName}", fileName, blobName);
        return blobName;
    }

    public async Task<string> MaterializeToTempFileAsync(
        string stagingBlobName, string extension, CancellationToken ct = default)
    {
        var ext = extension.StartsWith('.') ? extension : "." + extension;
        var tempPath = Path.Combine(Path.GetTempPath(), $"ratpdf_{Guid.NewGuid():N}{ext}");
        await _blob.DownloadToFileAsync(stagingBlobName, tempPath, BufferSize, ct);
        return tempPath;
    }

    public Task DeleteStagingAsync(string stagingBlobName, CancellationToken ct = default)
        => _blob.DeleteAsync(stagingBlobName, ct);

    public static void TryDeleteLocalFile(string? path)
    {
        if (string.IsNullOrEmpty(path)) return;
        try
        {
            if (File.Exists(path))
                File.Delete(path);
        }
        catch { /* best effort */ }
    }

    private static string SanitizeFileName(string fileName)
    {
        var name = Path.GetFileName(fileName);
        if (string.IsNullOrWhiteSpace(name))
            return "input.bin";

        var invalid = Path.GetInvalidFileNameChars();
        var chars = name.Select(c => invalid.Contains(c) ? '_' : c).ToArray();
        return new string(chars);
    }
}
