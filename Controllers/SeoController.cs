using System.Text;

using System.Xml.Linq;

using Microsoft.AspNetCore.Mvc;

using ratpdf.Constants;
using ratpdf.Services;



namespace ratpdf.Controllers

{

    public class SeoController : Controller

    {

        private static readonly XNamespace Ns = XNamespace.Get("http://www.sitemaps.org/schemas/sitemap/0.9");



        [HttpGet("/robots.txt")]

        [ResponseCache(Duration = 86400)]

        public ContentResult Robots()

        {

            var sb = new StringBuilder();

            sb.AppendLine("User-agent: *");

            sb.AppendLine("Allow: /");

            sb.AppendLine("Disallow: /Account/");

            sb.AppendLine("Disallow: /InvoiceDashboard/");

            sb.AppendLine("Disallow: /Error/");

            sb.AppendLine($"Sitemap: {PdfToolSeo.SiteUrl}/sitemap.xml");

            return Content(sb.ToString(), "text/plain", Encoding.UTF8);

        }



        /// <summary>Sitemap index — references core, landing, and legacy child sitemaps.</summary>

        [HttpGet("/sitemap.xml")]

        [ResponseCache(Duration = 3600)]

        public ContentResult SitemapIndex()

        {

            var now = DateTime.UtcNow.ToString("yyyy-MM-dd");

            var doc = new XDocument(

                new XDeclaration("1.0", "utf-8", null),

                new XElement(Ns + "sitemapindex",

                    SitemapCatalog.AllChildPaths().Select(path =>

                        new XElement(Ns + "sitemap",

                            new XElement(Ns + "loc", PdfToolSeo.Canonical(path)),

                            new XElement(Ns + "lastmod", now)

                        )

                    )

                )

            );

            return Xml(doc);

        }



        /// <summary>Core pages: tools, guides, blog, utilities (no long-tail slugs).</summary>

        [HttpGet("/sitemaps/site.xml")]

        [ResponseCache(Duration = 3600)]

        public ContentResult SitemapSite() =>

            Xml(BuildUrlSet(PdfToolSeo.SitemapCorePaths()));



        /// <summary>Long-tail SEO landing pages for new PDF tools.</summary>

        [HttpGet("/sitemaps/pdf-tool-landings.xml")]

        [ResponseCache(Duration = 3600)]

        public ContentResult SitemapPdfToolLandings() =>

            Xml(BuildUrlSet(PdfToolSeoLandingGenerator.AllLandingPaths()));



        /// <summary>Programmatic PDF compression SEO landing pages (curated + keyword file).</summary>

        [HttpGet("/sitemaps/compress-pdf-programmatic.xml")]

        [ResponseCache(Duration = 3600)]

        public ContentResult SitemapCompressPdfProgrammatic()

        {

            var paths = PdfCompressProgrammaticSeoGenerator.AllLandingPaths();

            var hub = new List<string> { "/compress-pdf", "/pdf/compress" };

            return Xml(BuildUrlSet(hub.Concat(paths).Distinct(StringComparer.OrdinalIgnoreCase).ToList()));

        }



        private static XDocument BuildUrlSet(IReadOnlyList<string> paths)

        {

            var now = DateTime.UtcNow.ToString("yyyy-MM-dd");

            return new XDocument(

                new XDeclaration("1.0", "utf-8", null),

                new XElement(Ns + "urlset",

                    paths.Select(u =>

                        new XElement(Ns + "url",

                            new XElement(Ns + "loc", PdfToolSeo.Canonical(u)),

                            new XElement(Ns + "lastmod", now),

                            new XElement(Ns + "changefreq", GetChangeFreq(u)),

                            new XElement(Ns + "priority", GetPriority(u))

                        )

                    )

                )

            );

        }



        private ContentResult Xml(XDocument doc) =>
            Content(doc.ToString(), "application/xml", Encoding.UTF8);



        private static string GetChangeFreq(string path) => path switch

        {

            "/" => "daily",

            var p when p.StartsWith("/PDF/", StringComparison.OrdinalIgnoreCase) => "weekly",

            var p when IsToolLandingPath(p) => "monthly",

            var p when p.StartsWith("/guides", StringComparison.OrdinalIgnoreCase) => "monthly",

            var p when p.StartsWith("/blog", StringComparison.OrdinalIgnoreCase) => "weekly",

            _ => "weekly"

        };



        private static string GetPriority(string path) => path switch

        {

            "/" => "1.0",

            "/Subscription/Plans" => "0.9",

            var p when p.StartsWith("/PDF/", StringComparison.OrdinalIgnoreCase) => "0.9",

            var p when IsToolLandingPath(p) => "0.75",

            var p when p.StartsWith("/guides", StringComparison.OrdinalIgnoreCase) => "0.8",

            var p when p.StartsWith("/blog", StringComparison.OrdinalIgnoreCase) => "0.7",

            "/Home/About" or "/Home/Privacy" => "0.6",

            _ => "0.7"

        };



        private static bool IsToolLandingPath(string path) =>

            path.StartsWith("/unlock-pdf/", StringComparison.OrdinalIgnoreCase)

            || path.StartsWith("/flatten-pdf/", StringComparison.OrdinalIgnoreCase)

            || path.StartsWith("/pdf-to-images/", StringComparison.OrdinalIgnoreCase)

            || path.StartsWith("/extract-images-from-pdf/", StringComparison.OrdinalIgnoreCase)

            || path.StartsWith("/ocr-pdf/", StringComparison.OrdinalIgnoreCase)

            || path.StartsWith("/add-page-numbers-to-pdf/", StringComparison.OrdinalIgnoreCase)

            || path.StartsWith("/pdf-metadata/", StringComparison.OrdinalIgnoreCase)

            || path.StartsWith("/compress-pdf-", StringComparison.OrdinalIgnoreCase)

            || path.StartsWith("/pdf-under-", StringComparison.OrdinalIgnoreCase)

            || path.EndsWith("-pdf-compressor-alternative", StringComparison.OrdinalIgnoreCase)

            || path.StartsWith("/compress-pdf-vs-", StringComparison.OrdinalIgnoreCase)

            || path is "/lossless-pdf-compression" or "/pdf-optimization-guide" or "/optimize-pdf-for-web";

    }

}
