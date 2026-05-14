namespace ratpdf.Services.Invoice.Contract
{
    public interface ILogoStorageService
    {
        Task<byte[]?> GetLogoBytesAsync(string logoUrl);
        Task<string> UploadLogoAsync(Guid userId, Stream content, string fileName);
    }
}
