namespace ratpdf.Data.Entities;

/// <summary>Persistent audit trail for async PDF tool jobs (enterprise / scale-out).</summary>
public class PdfJobRecord
{
    public string JobId { get; set; } = "";
    public string JobKind { get; set; } = "";
    public string Status { get; set; } = "Pending";
    public string? BlobName { get; set; }
    public string? OutputFileName { get; set; }
    public string? OutputMimeType { get; set; }
    public long? InputBytes { get; set; }
    public long? OutputBytes { get; set; }
    public string? ErrorMessage { get; set; }
    public Guid? UserId { get; set; }
    public DateTime CreatedUtc { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedUtc { get; set; } = DateTime.UtcNow;
}
