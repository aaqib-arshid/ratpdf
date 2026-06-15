namespace ratpdf.Constants
{
    public sealed record SiteNavTool(string Name, string Url);

    public static class SiteToolCategories
    {
        public const string Medical = "medical";
        public const string Calculators = "calculators";
        public const string Image = "image";
        public const string Developer = "developer";
        public const string Utilities = "utilities";
        public const string Network = "network";
        public const string Business = "business";
    }

    /// <summary>Site-wide tool lists for navbar, footer, and related-tool blocks.</summary>
    public static class SiteToolNavigation
    {
        public static readonly SiteNavTool[] PdfEditTools =
        [
            new("Edit PDF", "/pdf/editpdf"),
            new("Compress PDF", "/pdf/compress"),
            new("Merge PDF", "/pdf/merge"),
            new("Split PDF", "/pdf/split"),
            new("Unlock PDF", "/pdf/unlockpdf"),
            new("Flatten PDF", "/pdf/flattenpdf"),
            new("OCR PDF", "/pdf/ocrpdf"),
            new("PDF to Images", "/pdf/pdftoimages"),
            new("Extract Images", "/pdf/extractimages"),
            new("Page Numbers", "/pdf/pagenumbers"),
            new("PDF Metadata", "/pdf/pdfmetadata"),
            new("PDF Redaction", "/pdf-redaction"),
            new("Add Watermark", "/pdf/watermark"),
            new("Protect PDF", "/pdf/password"),
            new("Sign PDF", "/pdf/signtext"),
            new("Rotate / Remove Pages", "/pdf/rotateorremove"),
        ];

        public static readonly SiteNavTool[] PdfConvertTools =
        [
            new("Image to PDF", "/pdf/convertimages"),
            new("Word to PDF", "/pdf/doctopdf"),
            new("PDF to Word", "/pdf/pdftodoc"),
            new("PDF to Excel", "/pdf/pdftoexcel"),
            new("Excel to PDF", "/pdf/exceltopdf"),
            new("PDF to PowerPoint", "/pdf/pdftoppt"),
            new("PowerPoint to PDF", "/pdf/ppttopdf"),
            new("HTML to PDF", "/pdf/htmltopdf"),
            new("PDF to Markdown", "/pdf/pdftomarkdown"),
            new("Text to PDF", "/pdf/texttopdf"),
            new("PDF to Text", "/pdf/pdftotext"),
            new("Img to Base64", "/pdf/imgtobase64"),
        ];

        public static readonly SiteNavTool[] ImageTools =
        [
            new("Background Remover", "/tools/imgbackgroundremove"),
            new("Compress Image", "/pdf/imagecompressor"),
            new("Bulk Image Compressor", "/bulk-image-compressor"),
            new("Image Resizer", "/image-resizer"),
            new("Image Format Converter", "/image-format-converter"),
            new("Favicon Generator", "/favicon-generator"),
        ];

        public static readonly SiteNavTool[] MedicalTools =
        [
            new("BMI Calculator", "/bmi-calculator"),
            new("HEART Score", "/heart-score"),
            new("eGFR Calculator", "/egfr-calculator"),
            new("CHA₂DS₂-VASc Score", "/cha2ds2-vasc-score"),
            new("Wells Score (DVT/PE)", "/wells-score"),
            new("GCS Calculator", "/gcs-calculator"),
            new("MAP Calculator", "/map-calculator"),
            new("HAS-BLED Score", "/has-bled-score"),
            new("Parkland Formula", "/parkland-formula"),
            new("NIHSS Calculator", "/nihss-calculator"),
        ];

        public static readonly SiteNavTool[] Calculators =
        [
            new("BMI Calculator", "/bmi-calculator"),
            new("Age Calculator", "/age-calculator"),
            new("EMI Calculator", "/emi-calculator"),
            new("Percentage Calculator", "/percentage-calculator"),
            new("Period Calculator", "/period-calculator"),
        ];

        public static readonly SiteNavTool[] DeveloperTools =
        [
            new("HTML Formatter", "/pdf/htmlformatter"),
            new("JSON Formatter", "/pdf/jsonformatter"),
            new("JWT Decoder", "/pdf/jwtdecoder"),
            new("Img to Base64", "/pdf/imgtobase64"),
            new("Browser OCR Tool", "/ocr-tool"),
            new("Binary to Decimal", "/binary-to-decimal"),
            new("Decimal to Binary", "/decimal-to-binary"),
            new("URL Encoder", "/url-encoder"),
            new("URL Decoder", "/url-decoder"),
            new("Text Comparer", "/text-comparer"),
            new("DNS Lookup", "/tools/dnslookup"),
        ];

        public static readonly SiteNavTool[] NetworkTools =
        [
            new("What Is My IP", "/tools/whatismyip"),
            new("IP Lookup", "/tools/iplookup"),
            new("DNS Lookup", "/tools/dnslookup"),
        ];

        public static readonly SiteNavTool[] Utilities =
        [
            new("Word Counter", "/tools/wordcounter"),
            new("QR Code Generator", "/qr-code-generator"),
            new("Password Generator", "/password-generator"),
            new("Ring Size Converter", "/tools/ringsizeconverter"),
        ];

        public static readonly SiteNavTool[] BusinessTools =
        [
            new("Invoice Generator", "/invoice/create"),
            new("Payslip Generator", "/free-payslip-generator"),
            new("Bulk Payslip Generator", "/bulk-payslip-generator"),
            new("Rent Receipt Generator", "/rent-receipt-generator"),
        ];

        public static IReadOnlyList<SiteNavTool> GetRelatedTools(string category, string currentPath, int max = 8)
        {
            var tools = GetCategoryTools(category);
            return tools
                .Where(t => !PathsEqual(t.Url, currentPath))
                .Take(max)
                .ToList();
        }

        public static IReadOnlyList<SiteNavTool> GetCategoryTools(string category) => category switch
        {
            SiteToolCategories.Medical => MedicalTools,
            SiteToolCategories.Calculators => Calculators,
            SiteToolCategories.Image => ImageTools,
            SiteToolCategories.Developer => DeveloperTools,
            SiteToolCategories.Utilities => Utilities,
            SiteToolCategories.Network => NetworkTools,
            SiteToolCategories.Business => BusinessTools,
            _ => Array.Empty<SiteNavTool>(),
        };

        public static string? InferRelatedCategory(string? path)
        {
            if (string.IsNullOrWhiteSpace(path)) return null;
            path = NormalizePath(path);

            if (PdfToolSeo.AllTools.Any(t => PathsEqual(t.Url, path)))
                return null;

            if (ContainsPath(MedicalTools, path)) return SiteToolCategories.Medical;
            if (ContainsPath(Calculators, path)) return SiteToolCategories.Calculators;
            if (ContainsPath(ImageTools, path)) return SiteToolCategories.Image;
            if (ContainsPath(DeveloperTools, path)) return SiteToolCategories.Developer;
            if (ContainsPath(NetworkTools, path)) return SiteToolCategories.Network;
            if (ContainsPath(Utilities, path)) return SiteToolCategories.Utilities;
            if (ContainsPath(BusinessTools, path)) return SiteToolCategories.Business;

            return null;
        }

        public static string CategoryHeading(string category) => category switch
        {
            SiteToolCategories.Medical => "Related medical calculators",
            SiteToolCategories.Calculators => "Related calculators",
            SiteToolCategories.Image => "Related image tools",
            SiteToolCategories.Developer => "Related developer tools",
            SiteToolCategories.Network => "Related network tools",
            SiteToolCategories.Utilities => "Related utilities",
            SiteToolCategories.Business => "Related business tools",
            _ => "Related tools",
        };

        private static bool ContainsPath(IEnumerable<SiteNavTool> tools, string path) =>
            tools.Any(t => PathsEqual(t.Url, path));

        private static bool PathsEqual(string a, string b) =>
            string.Equals(NormalizePath(a), NormalizePath(b), StringComparison.OrdinalIgnoreCase);

        private static string NormalizePath(string path)
        {
            path = path.Trim();
            if (path.Length > 1 && path.EndsWith('/'))
                path = path.TrimEnd('/');
            return path.Length == 0 ? "/" : path;
        }
    }
}
