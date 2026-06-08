using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace ratpdf.Services;

public class AzureBlobService
{
    private readonly BlobContainerClient _container;

    public AzureBlobService(IConfiguration config)
    {
        var connStr = config["AzureStorage:ConnectionString"]!;
        var containerName = config["AzureStorage:CompressContainer"]!;
        _container = new BlobContainerClient(connStr, containerName);
        _container.CreateIfNotExists(PublicAccessType.None);
    }

    // Upload a stream; returns the blob name
    public async Task<string> UploadAsync(Stream stream, string blobName, CancellationToken ct = default)
    {
        var blob = _container.GetBlobClient(blobName);
        stream.Position = 0;
        await blob.UploadAsync(stream, overwrite: true, ct);
        return blobName;
    }

    // Upload from a local file path
    public async Task<string> UploadFromFileAsync(string filePath, string blobName, CancellationToken ct = default)
    {
        await using var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
        return await UploadAsync(fs, blobName, ct);
    }

    // Download blob into a MemoryStream
    public async Task<MemoryStream> DownloadAsync(string blobName, CancellationToken ct = default)
    {
        var blob = _container.GetBlobClient(blobName);
        var ms = new MemoryStream();
        await blob.DownloadToAsync(ms, ct);
        ms.Position = 0;
        return ms;
    }

    // Delete a blob (silently ignore if not found)
    public async Task DeleteAsync(string blobName, CancellationToken ct = default)
    {
        var blob = _container.GetBlobClient(blobName);
        await blob.DeleteIfExistsAsync(cancellationToken: ct);
    }

    // Delete all blobs older than maxAge (for cleanup)
    public async Task<(int deleted, int failed, long bytesFreed)> CleanupOldBlobsAsync(
        TimeSpan maxAge, CancellationToken ct = default)
    {
        int deleted = 0, failed = 0;
        long bytesFreed = 0;
        var cutoff = DateTimeOffset.UtcNow - maxAge;

        await foreach (var item in _container.GetBlobsAsync(cancellationToken: ct))
        {
            if (item.Properties.LastModified < cutoff)
            {
                try
                {
                    await _container.DeleteBlobAsync(item.Name, cancellationToken: ct);
                    bytesFreed += item.Properties.ContentLength ?? 0;
                    deleted++;
                }
                catch { failed++; }
            }
        }
        return (deleted, failed, bytesFreed);
    }
}