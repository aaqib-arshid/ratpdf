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
            ("PDF to PowerPoint", "/pdf/pdftoppt", "pdf to powerpoint converter"),
            ("PowerPoint to PDF", "/pdf/ppttopdf", "powerpoint to pdf converter"),
            ("Edit PDF", "/pdf/editpdf", "edit pdf online"),
            ("PDF to Text", "/pdf/pdftotext", "pdf to text converter"),
            ("PDF to Markdown", "/pdf/pdftomarkdown", "pdf to markdown converter"),
            ("Text to PDF", "/pdf/texttopdf", "text to pdf converter"),
            ("HTML to PDF", "/pdf/htmltopdf", "html to pdf converter"),
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
            ("Crop PDF", "/pdf/crop", "crop pdf online"),
            ("Organize PDF", "/pdf/organize", "organize pdf online"),
            ("Repair PDF", "/pdf/repair", "repair pdf online"),
            ("AI PDF Summarizer", "/pdf/summarize", "pdf summarizer ai"),
            ("PDF/A Converter", "/pdf/pdfa", "convert pdf to pdfa"),
            ("Compare PDFs", "/pdf/compare", "compare pdf online"),
            ("Fill PDF Form", "/pdf/fillform", "fill pdf form online"),
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
                "/subscription/plans",
                "/invoice/create",
                "/invoicehome/index",
                "/home/about",
                "/home/editorialpolicy",
                "/home/security",
                "/home/corrections",
                SiteEntity.TrustHubPath,
                SiteEntity.HelpPath,
                SiteAuthors.HubPath,
                "/home/contact",
                "/home/privacy",
                "/home/terms",
                "/home/disclaimer",
                "/compare",
                "/learn",
                "/compress-pdf",
                "/convert/pdf-to-jpg",
                "/convert/html-to-pdf",
                "/resources",
                "/tools",
                "/tools/developer",
                "/tools/calculators",
                "/tools/utilities",
                "/tools/business",
                "/pdf/htmltopdf",
                "/pdf/pdftomarkdown",
                "/invoice/invoice-generator-usa",
                "/compress-pdf-to-10mb",
                "/pdf-tools-for-lawyers",
                "/pdf-tools-for-students",
                "/pdf-tools-for-accountants",
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
                "/guides/developer-tools",
                "/pdf/imgtobase64",
                "/pdf/htmlformatter",
                "/pdf/jsonformatter",
                "/pdf/jwtdecoder",
                "/tools/imgbackgroundremove",
                "/tools/whatismyip",
                "/tools/wordcounter",
                "/qr-code-generator",
                "/tools/iplookup",
                "/tools/dnslookup",
                "/tools/ringsizeconverter",
                "/freelance-rate-calculator",
                "/gst-invoice-checker",
                "/pdf-size-checker",
                "/research/pdf-tool-market-comparison",
                "/password-generator",
                "/qr-code-generator",
                "/free-payslip-generator",
                "/rent-receipt-generator",
                "/bulk-payslip-generator",
                "/binary-to-decimal",
                "/decimal-to-binary",
                "/url-encoder",
                "/url-decoder",
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

            paths.AddRange(CategoryToolsCatalog.SitemapPaths());
            paths.AddRange(VerticalPdfToolsCatalog.SitemapPaths());

            foreach (var tutorial in ToolHowToVideos.All)
                paths.Add(tutorial.LearnPath);

            return paths
                .Where(p => !MedicalToolsRemoval.IsRemovedPath(p))
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToList();
        }

        private static readonly HashSet<string> CasePreservedPrefixes = new(StringComparer.OrdinalIgnoreCase)
        {
            "/invoicedashboard/", "/error/",
        };

        public static string OgImageForToolId(string? toolId)
        {
            if (string.IsNullOrEmpty(toolId))
                return DefaultOgImage;
            return $"{SiteUrl}/images/og/{toolId.ToLowerInvariant()}.png";
        }

        /// <summary>Apply canonical + OG image when a PDF tool id is set on the page.</summary>
        public static void ApplyToolViewData(Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary viewData, string toolId)
        {
            viewData["PdfToolId"] = toolId;
            var catalog = PdfToolSchemaCatalog.Get(toolId);
            if (catalog != null)
                viewData["CanonicalUrl"] = Canonical(catalog.ToolPath);
            viewData["OgImage"] ??= OgImageForToolId(toolId);
        }

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
