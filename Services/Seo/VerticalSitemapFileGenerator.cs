using System.Text;
using System.Xml.Linq;
using ratpdf.Constants;
using ratpdf.Services;

namespace ratpdf.Services.Seo
{
    /// <summary>
    /// Generates full static sitemaps for slug-based SEO verticals (replaces tiny manual subsets).
    /// Run: dotnet run -- --generate-vertical-sitemaps
    /// </summary>
    public static class VerticalSitemapFileGenerator
    {
        private static readonly XNamespace Ns = XNamespace.Get("http://www.sitemaps.org/schemas/sitemap/0.9");

        private static readonly (string FileName, string UrlPrefix, string SlugFile, bool Slugified)[] Verticals =
        [
            ("json_sitemap.xml", "/json-formatter/", "SeoData/json_keywords_slugs.txt", false),
            ("jwt_sitemap.xml", "/jwt-decode/", "SeoData/jwt_keywords_slugs.txt", false),
            ("html_sitemap.xml", "/html-formatter/", "SeoData/html_keywords_slugs.txt", false),
            ("payslip_sitemap.xml", "/salary-slip/", "SeoData/payslip_keywords_slugs.txt", false),
            ("sitemap-editpdf.xml", "/edit-pdf/", "wwwroot/edit_pdf_urls_100k.txt", true),
            ("sitemap-pdf-to-word.xml", "/pdf-to-word/", "wwwroot/pdftodocx_urls.txt", true),
            ("sitemap_pdf_to_txt.xml", "/pdf-to-txt/", "wwwroot/pdf-to-txt-keywords.txt", true),
            ("sitemap_content_decay_detector.xml", "/content-decay-detector/", "wwwroot/decay_urls.txt", true),
        ];

        public static VerticalSitemapGenerationResult Generate(string contentRoot, string webRoot)
        {
            var sitemapDir = Path.Combine(webRoot, "sitemaps");
            Directory.CreateDirectory(sitemapDir);
            var lastMod = DateTime.UtcNow.ToString("yyyy-MM-dd");
            var results = new List<(string File, int Count)>();

            foreach (var (fileName, urlPrefix, slugFile, slugified) in Verticals)
            {
                var path = Path.Combine(contentRoot, slugFile.Replace('/', Path.DirectorySeparatorChar));
                if (!File.Exists(path))
                {
                    Console.WriteLine($"  Skip {fileName}: missing {slugFile}");
                    continue;
                }

                var slugs = File.ReadAllLines(path, Encoding.UTF8)
                    .Where(l => !string.IsNullOrWhiteSpace(l))
                    .Select(l => l.Trim())
                    .Select(l => slugified ? Slugify(l) : l)
                    .Distinct(StringComparer.OrdinalIgnoreCase)
                    .ToList();

                var urls = slugs.Select(s => urlPrefix + s.TrimStart('/')).ToList();
                var outPath = Path.Combine(sitemapDir, fileName);
                File.WriteAllText(outPath, BuildUrlSetXml(urls, lastMod), new UTF8Encoding(false));
                results.Add((fileName, urls.Count));
                Console.WriteLine($"  {fileName}: {urls.Count} URLs");
            }

            var landingPaths = PdfToolSeoLandingGenerator.AllLandingPaths();
            var landingPath = Path.Combine(sitemapDir, "sitemap_pdf_tool_landings_static.xml");
            File.WriteAllText(landingPath, BuildUrlSetXml(landingPaths, lastMod), new UTF8Encoding(false));
            results.Add(("sitemap_pdf_tool_landings_static.xml", landingPaths.Count));
            Console.WriteLine($"  sitemap_pdf_tool_landings_static.xml: {landingPaths.Count} URLs");

            return new VerticalSitemapGenerationResult(results);
        }

        private static string Slugify(string keyword) =>
            PdfToolSeoLandingGenerator.GenerateSlug(keyword);

        private static string BuildUrlSetXml(IReadOnlyList<string> paths, string lastMod)
        {
            var doc = new XDocument(
                new XDeclaration("1.0", "utf-8", null),
                new XElement(Ns + "urlset",
                    paths.Select(p =>
                        new XElement(Ns + "url",
                            new XElement(Ns + "loc", PdfToolSeo.Canonical(p)),
                            new XElement(Ns + "lastmod", lastMod),
                            new XElement(Ns + "changefreq", "monthly"),
                            new XElement(Ns + "priority", "0.75")))));
            return "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n" + doc;
        }
    }

    public sealed record VerticalSitemapGenerationResult(IReadOnlyList<(string File, int Count)> Files);
}
