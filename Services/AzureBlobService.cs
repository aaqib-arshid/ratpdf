using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace ratpdf.Services;

public class AzureBlobService
{
    private const int DefaultBufferSize = 4 * 1024 * 1024;
    private const int TransferChunkSize = 8 * 1024 * 1024;

    private readonly BlobContainerClient _container;

    public AzureBlobService(IConfiguration config)
    {
        var connStr = config["AzureStorage:ConnectionString"]!;
        var containerName = config["AzureStorage:CompressContainer"]!;
        _container = new BlobContainerClient(connStr, containerName);
        _container.CreateIfNotExists(PublicAccessType.None);
    }

    private static StorageTransferOptions TransferOptions => new()
    {
        MaximumConcurrency = 4,
        InitialTransferSize = TransferChunkSize,
        MaximumTransferSize = TransferChunkSize,
    };

    /// <summary>Upload a stream using chunked block upload (no full-file buffering).</summary>
    public async Task<string> UploadStreamAsync(
        Stream stream, string blobName, CancellationToken ct = default)
    {
        var blob = _container.GetBlobClient(blobName);
        if (stream.CanSeek)
            stream.Position = 0;

        await blob.UploadAsync(stream, new BlobUploadOptions
        {
            TransferOptions = TransferOptions,
        }, ct);

        return blobName;
    }

    public Task<string> UploadAsync(Stream stream, string blobName, CancellationToken ct = default)
        => UploadStreamAsync(stream, blobName, ct);

    /// <summary>Upload from a local file path without loading the file into memory.</summary>
    public async Task<long> UploadFromFileAsync(
        string filePath, string blobName, CancellationToken ct = default)
    {
        var fileInfo = new FileInfo(filePath);
        await using var fs = new FileStream(
            filePath,
            FileMode.Open,
            FileAccess.Read,
            FileShare.Read,
            DefaultBufferSize,
            useAsync: true);

        await UploadStreamAsync(fs, blobName, ct);
        return fileInfo.Length;
    }

    /// <summary>Open a read stream from blob storage (chunked, not buffered in RAM).</summary>
    public async Task<Stream> OpenReadAsync(string blobName, CancellationToken ct = default)
    {
        var blob = _container.GetBlobClient(blobName);
        return await blob.OpenReadAsync(new BlobOpenReadOptions(allowModifications: false)
        {
            BufferSize = DefaultBufferSize,
        }, ct);
    }

    /// <summary>Stream blob content directly to a local file.</summary>
    public async Task DownloadToFileAsync(
        string blobName,
        string destinationPath,
        int bufferSize = DefaultBufferSize,
        CancellationToken ct = default)
    {
        await using var readStream = await OpenReadAsync(blobName, ct);
        await using var fileStream = new FileStream(
            destinationPath,
            FileMode.Create,
            FileAccess.Write,
            FileShare.None,
            bufferSize,
            useAsync: true);

        await readStream.CopyToAsync(fileStream, bufferSize, ct);
    }

    /// <summary>Returns a streaming read handle. Caller must dispose the stream.</summary>
    public Task<Stream> DownloadAsync(string blobName, CancellationToken ct = default)
        => OpenReadAsync(blobName, ct);

    public async Task DeleteAsync(string blobName, CancellationToken ct = default)
    {
        var blob = _container.GetBlobClient(blobName);
        await blob.DeleteIfExistsAsync(cancellationToken: ct);
    }

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
