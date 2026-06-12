using Microsoft.Extensions.Caching.Memory;
using ratpdf.Models.CompressPdfSeo;

namespace ratpdf.Services.Seo
{
    /// <summary>Memory-cached wrapper for programmatic compress SEO page generation.</summary>
    public sealed class CachedPdfCompressSeoService
    {
        private static readonly TimeSpan PageTtl = TimeSpan.FromHours(24);
        private readonly IMemoryCache _cache;

        public CachedPdfCompressSeoService(IMemoryCache cache) => _cache = cache;

        public CompressSeoLandingModel? GetPage(string slug, string webRootPath)
        {
            var cacheKey = $"compress-seo:{slug}";
            if (_cache.TryGetValue(cacheKey, out CompressSeoLandingModel? cached))
                return cached;

            var page = PdfCompressProgrammaticSeoGenerator.GetPage(slug, webRootPath);
            if (page == null) return null;

            _cache.Set(cacheKey, page, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = PageTtl,
            });
            return page;
        }

        public void WarmCuratedPages(string webRootPath)
        {
            PdfCompressProgrammaticSeoGenerator.Initialize(webRootPath);
            foreach (var (_, path) in PdfCompressProgrammaticSeoGenerator.HubSpokeLinks())
            {
                var slug = path.TrimStart('/');
                if (PdfCompressProgrammaticSeoGenerator.IsKnownSlug(slug))
                    GetPage(slug, webRootPath);
            }
        }
    }
}
