using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using ratpdf.Constants;
using ratpdf.Content;
using ratpdf.Services;
using ratpdf.Services.Seo;

namespace ratpdf.Controllers
{
    public class SeoController : Controller
    {
        private static readonly TimeSpan SitemapTtl = TimeSpan.FromHours(1);
        private static readonly TimeSpan IndexTtl = TimeSpan.FromHours(6);

        private readonly SitemapCacheService _sitemaps;

        public SeoController(SitemapCacheService sitemaps) => _sitemaps = sitemaps;

        [HttpGet("/robots.txt")]
        [ResponseCache(Duration = 86400, Location = ResponseCacheLocation.Any)]
        public ContentResult Robots() =>
            Content(RobotsTxtBuilder.Build(), "text/plain", Encoding.UTF8);

        [HttpGet("/sitemap.xml")]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any)]
        [OutputCache(PolicyName = "Sitemap")]
        public ContentResult SitemapIndex()
        {
            var compressChunks = _sitemaps.GetCompressSitemapChunks();
            var children = SitemapCatalog.BuildMainIndexChildren(compressChunks);
            var cacheKey = $"sitemap:main:index:c{compressChunks.Count}";
            var xml = _sitemaps.GetOrBuildSitemapIndex(cacheKey, children, IndexTtl);
            return XmlContent(xml);
        }

        // ── Core segmented sitemaps ──

        [HttpGet("/sitemaps/sitemap-core.xml")]
        [HttpGet("/sitemaps/site.xml")]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any)]
        [OutputCache(PolicyName = "Sitemap")]
        public ContentResult SitemapCore() =>
            XmlContent(_sitemaps.GetOrBuildUrlSet("sitemap:core", PdfToolSeo.SitemapCorePaths, SitemapTtl));

        [HttpGet("/sitemaps/sitemap-guides.xml")]
        [HttpGet("/sitemaps/guides.xml")]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any)]
        [OutputCache(PolicyName = "Sitemap")]
        public ContentResult SitemapGuides() =>
            XmlContent(_sitemaps.GetOrBuildUrlSet("sitemap:guides",
                () => ContentLibrary.Guides.Select(g => g.Path).ToList(), SitemapTtl));

        [HttpGet("/sitemaps/sitemap-blog.xml")]
        [HttpGet("/sitemaps/blog.xml")]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any)]
        [OutputCache(PolicyName = "Sitemap")]
        public ContentResult SitemapBlog() =>
            XmlContent(_sitemaps.GetOrBuildUrlSet("sitemap:blog",
                () => ContentLibrary.Blogs.Select(b => b.Path).ToList(), SitemapTtl));

        [HttpGet("/sitemaps/sitemap-compare.xml")]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any)]
        [OutputCache(PolicyName = "Sitemap")]
        public ContentResult SitemapCompare() =>
            XmlContent(_sitemaps.GetOrBuildUrlSet("sitemap:compare",
                CompetitiveSeoCatalog.AllComparePaths, SitemapTtl));

        // ── Compress programmatic (indexed, curated SEO engine) ──

        [HttpGet("/sitemaps/sitemap-compress-seo.xml")]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any)]
        [OutputCache(PolicyName = "Sitemap")]
        public ContentResult SitemapCompressSeo() =>
            SitemapCompressChunk(1);

        [HttpGet("/sitemaps/compress-pdf-programmatic.xml")]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any)]
        public IActionResult SitemapCompressLegacy() =>
            RedirectPermanent("/sitemaps/sitemap-compress-seo.xml");

        [HttpGet("/sitemaps/compress-pdf-index.xml")]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any)]
        [OutputCache(PolicyName = "Sitemap")]
        public ContentResult SitemapCompressIndex()
        {
            var chunks = _sitemaps.GetCompressSitemapChunks();
            var xml = _sitemaps.GetOrBuildSitemapIndex("sitemap:compress:index", chunks, IndexTtl);
            return XmlContent(xml);
        }

        [HttpGet("/sitemaps/compress-pdf-{chunk:int}.xml")]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any)]
        [OutputCache(PolicyName = "Sitemap")]
        public ContentResult SitemapCompressChunk(int chunk)
        {
            var chunks = _sitemaps.GetCompressSitemapChunks();
            if (chunk < 1 || chunk > chunks.Count)
                return NotFoundContent();

            var xml = _sitemaps.GetCompressChunkXml(chunk);
            return string.IsNullOrEmpty(xml) ? NotFoundContent() : XmlContent(xml);
        }

        // ── Deprecated: noindex thin landings removed from index (410 Gone) ──

        [HttpGet("/sitemaps/pdf-tool-landings.xml")]
        [HttpGet("/sitemaps/category-tool-landings.xml")]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any)]
        public ContentResult SitemapRemovedThinLandings()
        {
            Response.StatusCode = StatusCodes.Status410Gone;
            return Content(string.Empty, "application/xml", Encoding.UTF8);
        }

        [HttpGet("/sitemaps/sitemap_pdf_to_txt.xml")]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any)]
        public IActionResult SitemapPdfToTxtLegacy() =>
            RedirectPermanent("/sitemaps/sitemap-pdftotxt-seo.xml");

        private ContentResult XmlContent(string xml) =>
            Content(xml, "application/xml", Encoding.UTF8);

        private ContentResult NotFoundContent()
        {
            Response.StatusCode = StatusCodes.Status404NotFound;
            return Content(string.Empty, "application/xml", Encoding.UTF8);
        }
    }
}
