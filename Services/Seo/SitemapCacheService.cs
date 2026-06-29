using System.Reflection;
using System.Xml.Linq;
using Microsoft.Extensions.Caching.Memory;
using ratpdf.Constants;
using ratpdf.Content;
using ratpdf.Models;
using ratpdf.Services;

namespace ratpdf.Services.Seo
{
    public sealed record SitemapEntrySpec(
        string Path,
        double Priority,
        string ChangeFreq,
        string? LastMod = null,
        IReadOnlyList<HreflangAlternate>? Hreflang = null);

    /// <summary>Caches generated sitemap XML for the nine-child index (~7,906 URLs).</summary>
    public sealed class SitemapCacheService
    {
        private static readonly XNamespace Ns = XNamespace.Get("http://www.sitemaps.org/schemas/sitemap/0.9");
        private static readonly XNamespace XhtmlNs = XNamespace.Get("http://www.w3.org/1999/xhtml");
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

        public string GetOrBuildCoreSitemap(TimeSpan ttl) =>
            GetOrBuildTypedUrlSet("sitemap:core:v2", () =>
                SitemapCoreCatalog.Entries
                    .Select(e => new SitemapEntrySpec(e.Path, e.Priority, "weekly"))
                    .ToList(), ttl);

        public string GetOrBuildToolsSitemap(TimeSpan ttl)
        {
            var lastMod = GetAssemblyLastMod();
            return GetOrBuildTypedUrlSet("sitemap:tools:v2", () =>
                PdfToolSeo.AllTools
                    .Select(t => new SitemapEntrySpec(t.Url, 0.9, "weekly", lastMod))
                    .ToList(), ttl);
        }

        public string GetOrBuildBlogSitemap(TimeSpan ttl) =>
            GetOrBuildTypedUrlSet("sitemap:blog:v2", () =>
                ContentLibrary.Blogs
                    .Select(b => new SitemapEntrySpec(b.Path, 0.7, "monthly"))
                    .ToList(), ttl);

        public string GetOrBuildProgrammaticSitemap(TimeSpan ttl) =>
            GetOrBuildTypedUrlSet("sitemap:programmatic:v2", () =>
                SitemapProgrammaticCatalog.Paths()
                    .Select(p => new SitemapEntrySpec(p, 0.8, "monthly"))
                    .ToList(), ttl);

        public string GetOrBuildGuideLocaleSitemap(string localeUrlPrefix, TimeSpan ttl)
        {
            var cacheKey = $"sitemap:guides:{localeUrlPrefix ?? "en"}:v2";
            return _cache.GetOrCreate(cacheKey, entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = ttl;
                var specs = GuideHreflangHelper.BuildGuideLocaleEntries(localeUrlPrefix)
                    .Select(e => new SitemapEntrySpec(
                        e.Path,
                        0.8,
                        "monthly",
                        Hreflang: e.Alternates))
                    .ToList();
                return BuildTypedUrlSetXml(specs, includeHreflang: true);
            })!;
        }

        public string GetOrBuildTypedUrlSet(
            string cacheKey,
            Func<IReadOnlyList<SitemapEntrySpec>> specFactory,
            TimeSpan ttl)
        {
            return _cache.GetOrCreate(cacheKey, entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = ttl;
                return BuildTypedUrlSetXml(specFactory());
            })!;
        }

        private string BuildTypedUrlSetXml(
            IReadOnlyList<SitemapEntrySpec> entries,
            bool includeHreflang = false)
        {
            var lastModDefault = DateTime.UtcNow.ToString("yyyy-MM-dd");
            var urlset = new XElement(Ns + "urlset");
            if (includeHreflang)
                urlset.Add(new XAttribute(XNamespace.Xmlns + "xhtml", XhtmlNs));

            foreach (var spec in entries)
            {
                if (SitemapExclusion.IsExcluded(spec.Path))
                    continue;

                var priority = SitemapUrlMetadata.FormatPriority(spec.Priority);
                var lastMod = spec.LastMod ?? lastModDefault;
                var url = new XElement(Ns + "url",
                    new XElement(Ns + "loc", PdfToolSeo.Canonical(spec.Path)),
                    new XElement(Ns + "lastmod", lastMod),
                    new XElement(Ns + "changefreq", spec.ChangeFreq),
                    new XElement(Ns + "priority", priority));

                if (spec.Hreflang is { Count: > 0 })
                {
                    foreach (var alt in spec.Hreflang)
                    {
                        url.Add(new XElement(XhtmlNs + "link",
                            new XAttribute("rel", "alternate"),
                            new XAttribute("hreflang", alt.Hreflang),
                            new XAttribute("href", PdfToolSeo.Canonical(alt.Path))));
                    }
                }

                urlset.Add(url);
            }

            return new XDocument(new XDeclaration("1.0", "utf-8", null), urlset).ToString();
        }

        private static string GetAssemblyLastMod()
        {
            try
            {
                var location = Assembly.GetExecutingAssembly().Location;
                if (!string.IsNullOrEmpty(location) && File.Exists(location))
                    return File.GetLastWriteTimeUtc(location).ToString("yyyy-MM-dd");
            }
            catch
            {
                // fall through
            }

            return DateTime.UtcNow.ToString("yyyy-MM-dd");
        }
    }
}
