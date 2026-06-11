using System.Text;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using ratpdf.Constants;

namespace ratpdf.Controllers
{
    public class SeoController : Controller
    {
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

        [HttpGet("/sitemap.xml")]
        [ResponseCache(Duration = 3600)]
        public ContentResult Sitemap()
        {
            var ns = XNamespace.Get("http://www.sitemaps.org/schemas/sitemap/0.9");
            var now = DateTime.UtcNow.ToString("yyyy-MM-dd");

            var doc = new XDocument(
                new XDeclaration("1.0", "utf-8", null),
                new XElement(ns + "urlset",
                    PdfToolSeo.SitemapPaths().Select(u =>
                        new XElement(ns + "url",
                            new XElement(ns + "loc", PdfToolSeo.Canonical(u)),
                            new XElement(ns + "lastmod", now),
                            new XElement(ns + "changefreq", GetChangeFreq(u)),
                            new XElement(ns + "priority", GetPriority(u))
                        )
                    )
                )
            );

            return Content(doc.ToString(), "application/xml", Encoding.UTF8);
        }

        private static string GetChangeFreq(string path) => path switch
        {
            "/" => "daily",
            var p when p.StartsWith("/PDF/", StringComparison.OrdinalIgnoreCase) => "weekly",
            var p when p.StartsWith("/guides", StringComparison.OrdinalIgnoreCase) => "monthly",
            _ => "weekly"
        };

        private static string GetPriority(string path) => path switch
        {
            "/" => "1.0",
            "/Subscription/Plans" => "0.9",
            var p when p.StartsWith("/PDF/", StringComparison.OrdinalIgnoreCase) => "0.9",
            var p when p.StartsWith("/guides", StringComparison.OrdinalIgnoreCase) => "0.8",
            "/Home/About" or "/Home/Privacy" => "0.6",
            _ => "0.7"
        };
    }
}
