using Microsoft.Extensions.Caching.Memory;
using ratpdf.Constants;

namespace ratpdf.Services.Seo
{
    /// <summary>Cached navigation and tool metadata for layout/footer rendering.</summary>
    public sealed class NavigationMetadataService
    {
        private static readonly TimeSpan Ttl = TimeSpan.FromHours(12);
        private readonly IMemoryCache _cache;

        public NavigationMetadataService(IMemoryCache cache) => _cache = cache;

        public IReadOnlyList<(string Name, string Url)> GetPdfTools() =>
            _cache.GetOrCreate("nav:pdf-tools", e =>
            {
                e.AbsoluteExpirationRelativeToNow = Ttl;
                return PdfToolSeo.AllTools.Select(t => (t.Name, t.Url)).ToList();
            })!;

        public IReadOnlyList<(string Label, string Path)> GetCompressHubLinks() =>
            _cache.GetOrCreate("nav:compress-hub", e =>
            {
                e.AbsoluteExpirationRelativeToNow = Ttl;
                return PdfCompressProgrammaticSeoGenerator.HubSpokeLinks();
            })!;

        public IReadOnlyList<(string Name, string Url)> GetRelatedPdfTools() =>
            _cache.GetOrCreate("nav:related-tools", e =>
            {
                e.AbsoluteExpirationRelativeToNow = Ttl;
                return new List<(string, string)>
                {
                    ("Merge PDF", "/PDF/Merge"),
                    ("Split PDF", "/PDF/Split"),
                    ("PDF to Word", "/PDF/PdfToDoc"),
                    ("Protect PDF", "/PDF/Password"),
                };
            })!;
    }
}
