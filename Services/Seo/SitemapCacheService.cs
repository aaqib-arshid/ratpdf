using System.Xml.Linq;
using Microsoft.Extensions.Caching.Memory;
using ratpdf.Constants;
using ratpdf.Services;

namespace ratpdf.Services.Seo
{
    /// <summary>Caches generated compress PDF sitemap XML.</summary>
    public sealed class SitemapCacheService
    {
        private static readonly XNamespace Ns = XNamespace.Get("http://www.sitemaps.org/schemas/sitemap/0.9");
        public const int MaxUrlsPerSitemap = 10_000;

        private readonly IMemoryCache _cache;
        private readonly IWebHostEnvironment _env;

        public SitemapCacheService(IMemoryCache cache, IWebHostEnvironment env)
        {
            _cache = cache;
            _env = env;
        }

        public string GetOrBuildSitemapIndex(string cacheKey, IReadOnlyList<string> childSitemapPaths, TimeSpan ttl)
        {
            return _cache.GetOrCreate(cacheKey, entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = ttl;
                var now = DateTime.UtcNow.ToString("yyyy-MM-dd");
                var doc = new XDocument(
                    new XDeclaration("1.0", "utf-8", null),
                    new XElement(Ns + "sitemapindex",
                        childSitemapPaths.Select(p =>
                            new XElement(Ns + "sitemap",
                                new XElement(Ns + "loc", PdfToolSeo.Canonical(p)),
                                new XElement(Ns + "lastmod", now)))));
                return doc.ToString();
            })!;
        }

        public string GetOrBuildUrlSet(string cacheKey, Func<IReadOnlyList<string>> pathFactory, TimeSpan ttl)
        {
            return _cache.GetOrCreate(cacheKey, entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = ttl;
                return BuildUrlSetXml(pathFactory());
            })!;
        }

        public IReadOnlyList<string> GetCompressSitemapChunks() =>
            BuildChunkPaths("compress-pdf", () =>
            {
                PdfCompressProgrammaticSeoGenerator.Initialize(_env.WebRootPath);
                return PdfCompressProgrammaticSeoGenerator.AllSitemapPaths();
            });

        public string GetCompressChunkXml(int chunkIndex) =>
            BuildChunkXml("compress-pdf", chunkIndex, () =>
            {
                PdfCompressProgrammaticSeoGenerator.Initialize(_env.WebRootPath);
                return PdfCompressProgrammaticSeoGenerator.AllSitemapPaths();
            });

        private IReadOnlyList<string> BuildChunkPaths(string id, Func<IReadOnlyList<string>> pathFactory)
        {
            var cacheKey = $"sitemap:{id}:chunks";
            return _cache.GetOrCreate(cacheKey, entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(6);
                var count = pathFactory().Count;
                var chunkCount = Math.Max(1, (int)Math.Ceiling(count / (double)MaxUrlsPerSitemap));
                return Enumerable.Range(1, chunkCount)
                    .Select(i => $"/sitemaps/{id}-{i:D3}.xml")
                    .ToList();
            })!;
        }

        private string BuildChunkXml(string id, int chunkIndex, Func<IReadOnlyList<string>> pathFactory)
        {
            if (chunkIndex < 1) return string.Empty;

            var cacheKey = $"sitemap:{id}:chunk:{chunkIndex}";
            return _cache.GetOrCreate(cacheKey, entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1);
                var all = pathFactory();
                var skip = (chunkIndex - 1) * MaxUrlsPerSitemap;
                if (skip >= all.Count) return string.Empty;
                var slice = all.Skip(skip).Take(MaxUrlsPerSitemap).ToList();
                var lastMod = id == "compress-pdf"
                    ? PdfCompressProgrammaticSeoGenerator.SitemapLastModified
                    : null;
                return BuildUrlSetXml(slice, lastMod);
            })!;
        }

        private string BuildUrlSetXml(IReadOnlyList<string> paths, string? lastModOverride = null)
        {
            var lastMod = lastModOverride ?? DateTime.UtcNow.ToString("yyyy-MM-dd");
            var doc = new XDocument(
                new XDeclaration("1.0", "utf-8", null),
                new XElement(Ns + "urlset",
                    paths.Select(u =>
                        new XElement(Ns + "url",
                            new XElement(Ns + "loc", PdfToolSeo.Canonical(u)),
                            new XElement(Ns + "lastmod", lastMod),
                            new XElement(Ns + "changefreq", SitemapUrlMetadata.GetChangeFreq(u)),
                            new XElement(Ns + "priority", SitemapUrlMetadata.GetPriority(u))))));
            return doc.ToString();
        }
    }
}
