using ratpdf.Content;

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
        ];

        /// <summary>All public URLs for sitemap.xml (path only).</summary>
        public static IReadOnlyList<string> SitemapPaths()
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
                "/Tools/ImgBackgroundRemove",
                "/Tools/WhatIsMyIP",
                "/Tools/WordCounter",
                "/Tools/QRGenerator",
                "/Calculators/LoanCalculator",
                "/PaySlip/Index",
                "/RentReceipt/Index",
                "/password-generator",
                "/qr-code-generator",
            ]);

            return paths.Distinct(StringComparer.OrdinalIgnoreCase).ToList();
        }

        public static string Canonical(string path) =>
            path.StartsWith("http") ? path : SiteUrl.TrimEnd('/') + path;
    }
}
