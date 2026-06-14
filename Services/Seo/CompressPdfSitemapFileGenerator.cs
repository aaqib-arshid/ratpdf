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
                            new XElement(Ns + "changefreq", SitemapUrlMetadata.GetChangeFreq(u)),
                            new XElement(Ns + "priority", SitemapUrlMetadata.GetPriority(u))))));
            return WithXmlDeclaration(doc);
        }
    }

    public sealed record CompressPdfSitemapGenerationResult(
        int UrlCount,
        int ChunkCount,
        string IndexPath,
        IReadOnlyList<string> ChunkFileNames);
}
