using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using ratpdf.Constants;
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
            var children = SitemapCatalog.BuildMainIndexChildren();
            var cacheKey = $"sitemap:main:index:v2:{children.Count}";
            var xml = _sitemaps.GetOrBuildSitemapIndex(cacheKey, children, IndexTtl);
            return XmlContent(xml);
        }

        [HttpGet("/sitemaps/sitemap-core.xml")]
        [HttpGet("/sitemaps/site.xml")]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any)]
        [OutputCache(PolicyName = "Sitemap")]
        public ContentResult SitemapCore() =>
            XmlContent(_sitemaps.GetOrBuildCoreSitemap(SitemapTtl));

        [HttpGet("/sitemaps/sitemap-tools.xml")]
        [HttpGet("/sitemaps/sitemaptools.xml")]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any)]
        [OutputCache(PolicyName = "Sitemap")]
        public ContentResult SitemapTools() =>
            XmlContent(_sitemaps.GetOrBuildToolsSitemap(SitemapTtl));

        [HttpGet("/sitemaps/sitemap-blog.xml")]
        [HttpGet("/sitemaps/blog.xml")]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any)]
        [OutputCache(PolicyName = "Sitemap")]
        public ContentResult SitemapBlog() =>
            XmlContent(_sitemaps.GetOrBuildBlogSitemap(SitemapTtl));

        [HttpGet("/sitemaps/sitemap-programmatic.xml")]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any)]
        [OutputCache(PolicyName = "Sitemap")]
        public ContentResult SitemapProgrammatic() =>
            XmlContent(_sitemaps.GetOrBuildProgrammaticSitemap(SitemapTtl));

        [HttpGet("/sitemaps/sitemap-guides-en.xml")]
        [HttpGet("/sitemaps/sitemap-guides.xml")]
        [HttpGet("/sitemaps/guides.xml")]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any)]
        [OutputCache(PolicyName = "Sitemap")]
        public ContentResult SitemapGuidesEn() =>
            XmlContent(_sitemaps.GetOrBuildGuideLocaleSitemap(null, SitemapTtl));

        [HttpGet("/sitemaps/sitemap-guides-pt.xml")]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any)]
        [OutputCache(PolicyName = "Sitemap")]
        public ContentResult SitemapGuidesPt() =>
            XmlContent(_sitemaps.GetOrBuildGuideLocaleSitemap("pt", SitemapTtl));

        [HttpGet("/sitemaps/sitemap-guides-es.xml")]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any)]
        [OutputCache(PolicyName = "Sitemap")]
        public ContentResult SitemapGuidesEs() =>
            XmlContent(_sitemaps.GetOrBuildGuideLocaleSitemap("es", SitemapTtl));

        [HttpGet("/sitemaps/sitemap-guides-de.xml")]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any)]
        [OutputCache(PolicyName = "Sitemap")]
        public ContentResult SitemapGuidesDe() =>
            XmlContent(_sitemaps.GetOrBuildGuideLocaleSitemap("de", SitemapTtl));

        [HttpGet("/sitemaps/sitemap-guides-id.xml")]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any)]
        [OutputCache(PolicyName = "Sitemap")]
        public ContentResult SitemapGuidesId() =>
            XmlContent(_sitemaps.GetOrBuildGuideLocaleSitemap("id", SitemapTtl));

        [HttpGet("/sitemaps/sitemap-guides-fr.xml")]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any)]
        [OutputCache(PolicyName = "Sitemap")]
        public ContentResult SitemapGuidesFr() =>
            XmlContent(_sitemaps.GetOrBuildGuideLocaleSitemap("fr", SitemapTtl));

        [HttpGet("/sitemaps/sitemap-guides-localized.xml")]
        [HttpGet("/sitemaps/guides-localized.xml")]
        [HttpGet("/sitemaps/guides-localized-{chunk:int}.xml")]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any)]
        public ContentResult SitemapGuidesLocalizedRemoved()
        {
            Response.StatusCode = StatusCodes.Status410Gone;
            return Content(string.Empty, "application/xml", Encoding.UTF8);
        }

        [HttpGet("/sitemaps/sitemap-compare.xml")]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any)]
        public IActionResult SitemapCompareLegacy() =>
            RedirectPermanent("/sitemaps/sitemap-core.xml");

        [HttpGet("/sitemaps/sitemap-compress-seo.xml")]
        [HttpGet("/sitemaps/compress-pdf-programmatic.xml")]
        [HttpGet("/sitemaps/compress-pdf-index.xml")]
        [HttpGet("/sitemaps/compress-pdf-{chunk:int}.xml")]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any)]
        public ContentResult SitemapCompressRemoved()
        {
            Response.StatusCode = StatusCodes.Status410Gone;
            return Content(string.Empty, "application/xml", Encoding.UTF8);
        }

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
        public ContentResult SitemapPdfToTxtLegacy()
        {
            Response.StatusCode = StatusCodes.Status410Gone;
            return Content(string.Empty, "application/xml", Encoding.UTF8);
        }

        private ContentResult XmlContent(string xml) =>
            Content(xml, "application/xml", Encoding.UTF8);
    }
}
