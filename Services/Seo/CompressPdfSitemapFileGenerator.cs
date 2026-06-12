using System.Text;
using System.Xml.Linq;
using ratpdf.Constants;
using ratpdf.Services;

namespace ratpdf.Services.Seo
{
    /// <summary>
    /// Writes compress PDF sitemap index + urlset chunks to wwwroot/sitemaps/.
    /// Run: dotnet run --project ratpdf.csproj -- --generate-compress-sitemap
    /// </summary>
    public static class CompressPdfSitemapFileGenerator
    {
        private static readonly XNamespace Ns = XNamespace.Get("http://www.sitemaps.org/schemas/sitemap/0.9");

        public static CompressPdfSitemapGenerationResult Generate(string webRootPath)
        {
            PdfCompressProgrammaticSeoGenerator.Initialize(webRootPath);
            var paths = PdfCompressProgrammaticSeoGenerator.AllSitemapPaths();
            var lastMod = PdfCompressProgrammaticSeoGenerator.SitemapLastModified;

            var sitemapDir = Path.Combine(webRootPath, "sitemaps");
            Directory.CreateDirectory(sitemapDir);

            var chunkCount = Math.Max(1, (int)Math.Ceiling(paths.Count / (double)SitemapCacheService.MaxUrlsPerSitemap));
            var chunkFiles = new List<string>();

            for (var i = 1; i <= chunkCount; i++)
            {
                var skip = (i - 1) * SitemapCacheService.MaxUrlsPerSitemap;
                var slice = paths.Skip(skip).Take(SitemapCacheService.MaxUrlsPerSitemap).ToList();
                var fileName = $"compress-pdf-{i:D3}.xml";
                var filePath = Path.Combine(sitemapDir, fileName);
                File.WriteAllText(filePath, BuildUrlSetXml(slice, lastMod), new UTF8Encoding(encoderShouldEmitUTF8Identifier: false));
                chunkFiles.Add(fileName);
            }

            var indexPath = Path.Combine(sitemapDir, "compress-pdf-index.xml");
            var chunkPaths = chunkFiles.Select(f => $"/sitemaps/{f}").ToList();
            File.WriteAllText(indexPath, BuildSitemapIndexXml(chunkPaths, lastMod), new UTF8Encoding(encoderShouldEmitUTF8Identifier: false));

            // Legacy alias used by older robots/crawler bookmarks
            var legacyPath = Path.Combine(sitemapDir, "sitemap_compress_pdf.xml");
            File.WriteAllText(legacyPath, BuildSitemapIndexXml(chunkPaths, lastMod), new UTF8Encoding(encoderShouldEmitUTF8Identifier: false));

            return new CompressPdfSitemapGenerationResult(paths.Count, chunkCount, indexPath, chunkFiles);
        }

        private static string BuildSitemapIndexXml(IReadOnlyList<string> childPaths, string lastMod)
        {
            var doc = new XDocument(
                new XDeclaration("1.0", "utf-8", null),
                new XElement(Ns + "sitemapindex",
                    childPaths.Select(p =>
                        new XElement(Ns + "sitemap",
                            new XElement(Ns + "loc", PdfToolSeo.Canonical(p)),
                            new XElement(Ns + "lastmod", lastMod)))));
            return WithXmlDeclaration(doc);
        }

        private static string WithXmlDeclaration(XDocument doc) =>
            "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n" + doc.ToString();

        private static string BuildUrlSetXml(IReadOnlyList<string> paths, string lastMod)
        {
            var doc = new XDocument(
                new XDeclaration("1.0", "utf-8", null),
                new XElement(Ns + "urlset",
                    paths.Select(u =>
                        new XElement(Ns + "url",
                            new XElement(Ns + "loc", PdfToolSeo.Canonical(u)),
                            new XElement(Ns + "lastmod", lastMod),
                            new XElement(Ns + "changefreq", GetChangeFreq(u)),
                            new XElement(Ns + "priority", GetPriority(u))))));
            return WithXmlDeclaration(doc);
        }

        private static string GetChangeFreq(string path) => path switch
        {
            "/" => "daily",
            "/pdf/compress" or "/compress-pdf" => "weekly",
            var p when p.StartsWith("/PDF/", StringComparison.OrdinalIgnoreCase) => "weekly",
            var p when IsCompressLanding(p) => "monthly",
            _ => "weekly",
        };

        private static string GetPriority(string path) => path switch
        {
            "/" => "1.0",
            "/pdf/compress" => "1.0",
            "/compress-pdf" => "0.98",
            var p when p.StartsWith("/PDF/", StringComparison.OrdinalIgnoreCase) => "0.9",
            var p when IsCompressLanding(p) => "0.75",
            _ => "0.7",
        };

        private static bool IsCompressLanding(string path) =>
            path.StartsWith("/compress-pdf", StringComparison.OrdinalIgnoreCase)
            || path.StartsWith("/pdf-under-", StringComparison.OrdinalIgnoreCase)
            || path.EndsWith("-pdf-compressor-alternative", StringComparison.OrdinalIgnoreCase)
            || path.StartsWith("/lossless-pdf", StringComparison.OrdinalIgnoreCase)
            || path is "/pdf-optimization-guide" or "/optimize-pdf-for-web";
    }

    public sealed record CompressPdfSitemapGenerationResult(
        int UrlCount,
        int ChunkCount,
        string IndexPath,
        IReadOnlyList<string> ChunkFileNames);
}
