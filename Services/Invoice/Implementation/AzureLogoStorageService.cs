using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using ratpdf.Services.Invoice.Contract;

namespace ratpdf.Services.Invoice.Implementation
{
    public class AzureLogoStorageService: ILogoStorageService
    {
        private readonly BlobContainerClient _container;
        private readonly string _cdnBaseUrl;

        public AzureLogoStorageService(IConfiguration config)
        {
            var connString = config["AzureStorage:ConnectionString"];
            var containerName = config["AzureStorage:LogoContainer"] ?? "brand-logos";
            _container = new BlobContainerClient(connString, containerName);
            _container.CreateIfNotExists(PublicAccessType.None);
            _cdnBaseUrl = config["AzureStorage:CdnBaseUrl"] ?? _container.Uri.AbsoluteUri;
        }
        public async Task<byte[]?> GetLogoBytesAsync(string logoUrl)
        {
            var uri = new Uri(logoUrl);

            var path = uri.AbsolutePath.TrimStart('/');

            var containerName = _container.Name;

            if (path.StartsWith(containerName + "/"))
            {
                path = path.Substring(containerName.Length + 1);
            }

            var blob = _container.GetBlobClient(path);

            var exists = await blob.ExistsAsync();
            if (!exists) return null;

            var download = await blob.DownloadContentAsync();
            return download.Value.Content.ToArray();
        }

        public async Task<string> UploadLogoAsync(Guid userId, Stream content, string fileName)
        {
            var blobName = $"{userId}/{Guid.NewGuid()}_{fileName}";
            var blob = _container.GetBlobClient(blobName);
            await blob.UploadAsync(content, new BlobHttpHeaders { ContentType = GetContentType(fileName) });
            return $"{_cdnBaseUrl}/{blobName}";
        }

        private static string GetContentType(string fileName) => Path.GetExtension(fileName).ToLower() switch
        {
            ".png" => "image/png",
            ".jpg" or ".jpeg" => "image/jpeg",
            _ => "application/octet-stream"
        };
    }
}

