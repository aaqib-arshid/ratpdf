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

        [HttpGet("/sitemaps/site.xml")]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any)]
        [OutputCache(PolicyName = "Sitemap")]
        public ContentResult SitemapSite() =>
            XmlContent(_sitemaps.GetOrBuildUrlSet("sitemap:site", PdfToolSeo.SitemapCorePaths, SitemapTtl));

        [HttpGet("/sitemaps/guides.xml")]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any)]
        [OutputCache(PolicyName = "Sitemap")]
        public ContentResult SitemapGuides() =>
            XmlContent(_sitemaps.GetOrBuildUrlSet("sitemap:guides",
                () => ContentLibrary.Guides.Select(g => g.Path).ToList(), SitemapTtl));

        [HttpGet("/sitemaps/blog.xml")]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any)]
        [OutputCache(PolicyName = "Sitemap")]
        public ContentResult SitemapBlog() =>
            XmlContent(_sitemaps.GetOrBuildUrlSet("sitemap:blog",
                () => ContentLibrary.Blogs.Select(b => b.Path).ToList(), SitemapTtl));

        [HttpGet("/sitemaps/pdf-tool-landings.xml")]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any)]
        [OutputCache(PolicyName = "Sitemap")]
        public ContentResult SitemapPdfToolLandings() =>
            XmlContent(_sitemaps.GetOrBuildUrlSet("sitemap:pdf-tool-landings",
                PdfToolSeoLandingGenerator.AllLandingPaths, SitemapTtl));

        [HttpGet("/sitemaps/category-tool-landings.xml")]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any)]
        [OutputCache(PolicyName = "Sitemap")]
        public ContentResult SitemapCategoryToolLandings() =>
            XmlContent(_sitemaps.GetOrBuildUrlSet("sitemap:category-tool-landings",
                ToolCategorySeoLandingGenerator.AllLandingPaths, SitemapTtl));

        [HttpGet("/sitemaps/compress-pdf-programmatic.xml")]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any)]
        public IActionResult SitemapCompressLegacy() =>
            RedirectPermanent("/sitemaps/compress-pdf-index.xml");

        /// <summary>Standalone compress index (optional direct URL). Not referenced by /sitemap.xml — avoids nested sitemap indexes.</summary>
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

        private ContentResult XmlContent(string xml) =>
            Content(xml, "application/xml", Encoding.UTF8);

        private ContentResult NotFoundContent()
        {
            Response.StatusCode = StatusCodes.Status404NotFound;
            return Content(string.Empty, "application/xml", Encoding.UTF8);
        }
    }
}
