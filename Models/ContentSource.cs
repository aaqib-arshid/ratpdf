namespace ratpdf.Models
{
    /// <summary>External reference cited in guides and trust content.</summary>
    public sealed record ContentSource(string Title, string Url, string? Publisher = null, string? AccessNote = null);
}
