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
            ("Merge PDF", "/PDF/Merge", "merge pdf online"),
            ("Split PDF", "/PDF/Split", "split pdf online"),
            ("Compress PDF", "/PDF/Compress", "compress pdf online"),
            ("PDF to Word", "/PDF/PdfToDoc", "pdf to word converter"),
            ("Word to PDF", "/PDF/DocToPdf", "word to pdf converter"),
            ("PDF to Excel", "/PDF/PdfToExcel", "pdf to excel converter"),
            ("Excel to PDF", "/PDF/ExcelToPdf", "excel to pdf converter"),
            ("Edit PDF", "/PDF/EditPDF", "edit pdf online"),
            ("PDF to Text", "/PDF/PdfToText", "pdf to text converter"),
            ("Text to PDF", "/PDF/TextToPdf", "text to pdf converter"),
            ("Watermark PDF", "/PDF/Watermark", "add watermark to pdf"),
            ("Protect PDF", "/PDF/Password", "password protect pdf"),
            ("Sign PDF", "/PDF/SignText", "sign pdf online"),
            ("Rotate PDF", "/PDF/RotateOrRemove", "rotate pdf pages"),
            ("Images to PDF", "/PDF/ConvertImages", "convert images to pdf"),
            ("Unlock PDF", "/PDF/UnlockPdf", "unlock pdf remove password"),
            ("Flatten PDF", "/PDF/FlattenPdf", "flatten pdf forms"),
            ("PDF to Images", "/PDF/PdfToImages", "pdf to png images"),
            ("Extract Images", "/PDF/ExtractImages", "extract images from pdf"),
            ("OCR PDF", "/PDF/OcrPdf", "ocr pdf searchable"),
            ("Page Numbers", "/PDF/PageNumbers", "add page numbers pdf"),
            ("PDF Metadata", "/PDF/PdfMetadata", "pdf metadata viewer"),
        ];

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
                "/Home/Contact",
                "/Home/Privacy",
                "/Home/Terms",
                "/Home/Disclaimer",
            };

            foreach (var tool in AllTools)
                paths.Add(tool.Url);

            paths.AddRange(ContentLibrary.AllContentPaths());

            paths.AddRange([
                "/PDF/ImageCompressor",
                "/PDF/ImgToBase64",
                "/PDF/HtmlFormatter",
                "/PDF/JsonFormatter",
                "/PDF/JwtDecoder",
                "/Tools/ImgBackgroundRemove",
                "/Tools/WhatIsMyIP",
                "/Tools/WordCounter",
                "/Tools/QRGenerator",
                "/Tools/IpLookup",
                "/Tools/DnsLookup",
                "/Calculators/LoanCalculator",
                "/PaySlip/Index",
                "/RentReceipt/Index",
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

        public static string Canonical(string path) =>
            path.StartsWith("http") ? path : SiteUrl.TrimEnd('/') + path;
    }
}
