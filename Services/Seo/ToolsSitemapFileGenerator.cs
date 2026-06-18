using System.Text;
using System.Xml.Linq;
using ratpdf.Constants;
using ratpdf.Content;

namespace ratpdf.Services.Seo;

/// <summary>Regenerates wwwroot/sitemaps/sitemaptools.xml from live tool catalogs.</summary>
public static class ToolsSitemapFileGenerator
{
    private static readonly XNamespace Ns = XNamespace.Get("http://www.sitemaps.org/schemas/sitemap/0.9");

    private static readonly string[] SupplementalPaths =
    [
        "/",
        "/guides",
        "/blog",
        "/compress-pdf",
        "/guides/pdf-tools",
        "/guides/secure-pdf-workflow",
        "/compare",
        "/learn",
        "/tools",
        "/invoice/create",
        "/invoicehome/index",
        "/free-payslip-generator",
        "/rent-receipt-generator",
        "/bulk-payslip-generator",
        "/pdf-redaction",
        "/ocr-tool",
        "/text-comparer",
        "/image-resizer",
        "/image-format-converter",
        "/bulk-image-compressor",
        "/favicon-generator",
        "/qr-code-generator",
        "/password-generator",
        "/binary-to-decimal",
        "/decimal-to-binary",
        "/url-encoder",
        "/url-decoder",
        "/age-calculator",
        "/emi-calculator",
        "/percentage-calculator",
        "/period-calculator",
        "/home/about",
        "/home/privacy",
        "/home/terms",
        "/home/contact",
        "/home/disclaimer",
    ];

    public static ToolsSitemapGenerationResult Generate(string webRootPath)
    {
        var paths = CollectPaths();
        var lastMod = DateTime.UtcNow.ToString("yyyy-MM-dd");
        var sitemapDir = Path.Combine(webRootPath, "sitemaps");
        Directory.CreateDirectory(sitemapDir);

        var filePath = Path.Combine(sitemapDir, "sitemaptools.xml");
        File.WriteAllText(filePath, BuildUrlSetXml(paths, lastMod), new UTF8Encoding(encoderShouldEmitUTF8Identifier: false));

        return new ToolsSitemapGenerationResult(paths.Count, filePath);
    }

    public static IReadOnlyList<string> CollectPaths()
    {
        var paths = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        foreach (var tool in PdfToolSeo.AllTools)
            paths.Add(PdfToolSeo.NormalizePath(tool.Url));

        foreach (var p in SupplementalPaths)
            paths.Add(PdfToolSeo.NormalizePath(p));

        foreach (var nav in new[]
        {
            SiteToolNavigation.ImageTools,
            SiteToolNavigation.DeveloperTools,
            SiteToolNavigation.Utilities,
            SiteToolNavigation.NetworkTools,
            SiteToolNavigation.BusinessTools,
            SiteToolNavigation.Calculators,
        })
        {
            foreach (var tool in nav)
                paths.Add(PdfToolSeo.NormalizePath(tool.Url));
        }

        foreach (var guide in ContentLibrary.Guides)
        {
            if (!string.IsNullOrEmpty(guide.ToolUrl))
                paths.Add(PdfToolSeo.NormalizePath(guide.ToolUrl));
        }

        return paths.OrderBy(p => p, StringComparer.OrdinalIgnoreCase).ToList();
    }

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
        return "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n" + doc.ToString();
    }
}

public sealed record ToolsSitemapGenerationResult(int UrlCount, string FilePath);
