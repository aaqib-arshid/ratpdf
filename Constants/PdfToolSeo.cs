using ratpdf.Content;
using ratpdf.Services;

namespace ratpdf.Constants
{
    /// <summary>SEO metadata, internal links, and sitemap URLs.</summary>
    public static class PdfToolSeo
    {
        public const string SiteUrl = "https://ratpdf.com";
        public const string SiteName = "RatPDF";
        public const string DefaultOgImage = "https://ratpdf.com/images/ratpdf-logo.png";

        public static readonly (string Name, string Url, string Keyword)[] AllTools =
        [
            ("Merge PDF", "/pdf/merge", "merge pdf online"),
            ("Split PDF", "/pdf/split", "split pdf online"),
            ("Compress PDF", "/pdf/compress", "compress pdf online"),
            ("PDF to Word", "/pdf/pdftodoc", "pdf to word converter"),
            ("Word to PDF", "/pdf/doctopdf", "word to pdf converter"),
            ("PDF to Excel", "/pdf/pdftoexcel", "pdf to excel converter"),
            ("Excel to PDF", "/pdf/exceltopdf", "excel to pdf converter"),
            ("Edit PDF", "/pdf/editpdf", "edit pdf online"),
            ("PDF to Text", "/pdf/pdftotext", "pdf to text converter"),
            ("Text to PDF", "/pdf/texttopdf", "text to pdf converter"),
            ("Watermark PDF", "/pdf/watermark", "add watermark to pdf"),
            ("Protect PDF", "/pdf/password", "password protect pdf"),
            ("Sign PDF", "/pdf/signtext", "sign pdf online"),
            ("Rotate PDF", "/pdf/rotateorremove", "rotate pdf pages"),
            ("Images to PDF", "/pdf/convertimages", "convert images to pdf"),
            ("Unlock PDF", "/pdf/unlockpdf", "unlock pdf remove password"),
            ("Flatten PDF", "/pdf/flattenpdf", "flatten pdf forms"),
            ("PDF to Images", "/pdf/pdftoimages", "pdf to png images"),
            ("Extract Images", "/pdf/extractimages", "extract images from pdf"),
            ("OCR PDF", "/pdf/ocrpdf", "ocr pdf searchable"),
            ("Page Numbers", "/pdf/pagenumbers", "add page numbers pdf"),
            ("PDF Metadata", "/pdf/pdfmetadata", "pdf metadata viewer"),
        ];

        /// <summary>Number of core PDF tools in <see cref="AllTools"/> (display as e.g. "22+").</summary>
        public static int ToolCount => AllTools.Length;

        public static string ToolCountLabel => $"{ToolCount}+";

        /// <summary>All public URLs (path only), including long-tail landing pages.</summary>
        public static IReadOnlyList<string> SitemapPaths() =>
            SitemapCorePaths()
                .Concat(PdfToolSeoLandingGenerator.AllLandingPaths())
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToList();

        /// <summary>Core site URLs for /sitemaps/site.xml (excludes SEO landing slugs).</summary>
        public static IReadOnlyList<string> SitemapCorePaths()
        {
            var paths = new List<string>
            {
                "/",
                "/guides",
                "/blog",
                "/Subscription/Plans",
                "/Invoice/Create",
                "/InvoiceHome/Index",
                "/Home/About",
                "/Home/EditorialPolicy",
                "/Home/Security",
                "/Home/Corrections",
                SiteEntity.TrustHubPath,
                SiteAuthors.HubPath,
                "/Home/Contact",
                "/Home/Privacy",
                "/Home/Terms",
                "/Home/Disclaimer",
            };

            foreach (var author in SiteAuthors.All)
                paths.Add($"{SiteAuthors.HubPath}/{author.Slug}");

            foreach (var tool in AllTools)
                paths.Add(tool.Url);

            paths.AddRange(ContentLibrary.AllContentPaths());

            paths.AddRange(CompetitiveSeoCatalog.AllComparePaths());

            paths.AddRange(LinkBuildingCatalog.SitemapPaths());

            paths.AddRange([
                "/compress-pdf",
                "/compare",
                "/guides/pdf-tools",
                "/guides/secure-pdf-workflow",
                "/pdf/imgtobase64",
                "/pdf/htmlformatter",
                "/pdf/jsonformatter",
                "/pdf/jwtdecoder",
                "/tools/imgbackgroundremove",
                "/tools/whatismyip",
                "/tools/wordcounter",
                "/tools/qrgenerator",
                "/tools/iplookup",
                "/tools/dnslookup",
                "/calculators/loancalculator",
                "/payslip/index",
                "/rentreceipt/index",
                "/password-generator",
                "/qr-code-generator",
                "/free-payslip-generator",
                "/rent-receipt-generator",
                "/bulk-payslip-generator",
                "/binary-to-decimal",
                "/decimal-to-binary",
                "/url-encoder",
                "/url-decoder",
                "/bmi-calculator",
                "/age-calculator",
                "/emi-calculator",
                "/percentage-calculator",
                "/ocr-tool",
                "/pdf-redaction",
                "/image-format-converter",
                "/bulk-image-compressor",
                "/image-resizer",
                "/text-comparer",
                "/favicon-generator",
                "/period-calculator",
                "/tools/gscindex",
            ]);

            return paths.Distinct(StringComparer.OrdinalIgnoreCase).ToList();
        }

        private static readonly HashSet<string> CasePreservedPrefixes = new(StringComparer.OrdinalIgnoreCase)
        {
            "/account/", "/invoice/", "/invoicedashboard/", "/subscription/", "/error/",
        };

        public static string Canonical(string path)
        {
            if (path.StartsWith("http", StringComparison.OrdinalIgnoreCase))
                return path;

            if (!path.StartsWith('/'))
                path = "/" + path;

            return SiteUrl.TrimEnd('/') + NormalizePath(path);
        }

        /// <summary>Lowercase path segments to match SeoUrlNormalizationMiddleware (preserves exempt prefixes).</summary>
        public static string NormalizePath(string path)
        {
            if (CasePreservedPrefixes.Any(p => path.StartsWith(p, StringComparison.OrdinalIgnoreCase)))
                return path;

            return path.ToLowerInvariant();
        }
    }
}
