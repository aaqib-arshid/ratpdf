using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using ratpdf.Constants;
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
        public ContentResult Robots()
        {
            var sb = new StringBuilder();
            sb.AppendLine("User-agent: *");
            sb.AppendLine("Allow: /");
            sb.AppendLine("Disallow: /Account/");
            sb.AppendLine("Disallow: /InvoiceDashboard/");
            sb.AppendLine("Disallow: /Error/");
            sb.AppendLine("Disallow: /*-keywords.txt");
            sb.AppendLine($"Sitemap: {PdfToolSeo.SiteUrl}/sitemap.xml");
            sb.AppendLine($"Sitemap: {PdfToolSeo.SiteUrl}/sitemaps/compress-pdf-index.xml");
            return Content(sb.ToString(), "text/plain", Encoding.UTF8);
        }

        [HttpGet("/sitemap.xml")]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any)]
        [OutputCache(PolicyName = "Sitemap")]
        public ContentResult SitemapIndex()
        {
            var children = SitemapCatalog.AllChildPaths().ToList();
            var xml = _sitemaps.GetOrBuildSitemapIndex("sitemap:main:index", children, IndexTtl);
            return XmlContent(xml);
        }

        [HttpGet("/sitemaps/site.xml")]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any)]
        [OutputCache(PolicyName = "Sitemap")]
        public ContentResult SitemapSite() =>
            XmlContent(_sitemaps.GetOrBuildUrlSet("sitemap:site", PdfToolSeo.SitemapCorePaths, SitemapTtl));

        [HttpGet("/sitemaps/pdf-tool-landings.xml")]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any)]
        [OutputCache(PolicyName = "Sitemap")]
        public ContentResult SitemapPdfToolLandings() =>
            XmlContent(_sitemaps.GetOrBuildUrlSet("sitemap:pdf-tool-landings",
                PdfToolSeoLandingGenerator.AllLandingPaths, SitemapTtl));

        [HttpGet("/sitemaps/compress-pdf-programmatic.xml")]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any)]
        public IActionResult SitemapCompressLegacy() =>
            RedirectPermanent("/sitemaps/compress-pdf-index.xml");

        /// <summary>Static compress index + chunks in wwwroot; SeoController routes are fallback.</summary>
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
