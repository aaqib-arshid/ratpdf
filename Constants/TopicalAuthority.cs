using ratpdf.Content;
using ratpdf.Models;
using ratpdf.Services;

namespace ratpdf.Constants
{
    /// <summary>Hub-and-spoke topical authority: pillars, workflow links, and editorial cross-links.</summary>
    public static class TopicalAuthority
    {
        public const string PdfToolsHubPath = "/guides/pdf-tools";
        public const string SecureWorkflowPath = "/guides/secure-pdf-workflow";
        public const string DeveloperGuidesHubPath = "/guides/developer-tools";
        public const string CompareHubPath = "/compare";
        public const string AllToolsHubPath = "/tools";
        public const string DeveloperHubPath = "/tools/developer";
        public const string CalculatorsHubPath = "/tools/calculators";
        public const string UtilitiesHubPath = "/tools/utilities";
        public const string BusinessHubPath = "/tools/business";

        public sealed record HubLink(string Label, string Path, string Description);

        public sealed record ToolGroup(string Name, string Description, (string Name, string Url, string Blurb)[] Tools);

        public static readonly HubLink[] Pillars =
        [
            new("Compress PDF", "/pdf/compress", "Reduce file size for email, portals, and storage."),
            new("Merge PDF", "/pdf/merge", "Combine multiple documents into one file."),
            new("Split PDF", "/pdf/split", "Extract pages or divide large files."),
            new("PDF to Word", "/pdf/pdftodoc", "Convert PDFs to editable DOCX."),
            new("Invoice Generator", "/invoice/create", "Create GST, VAT, and business invoices as PDF."),
            new("Edit PDF", "/pdf/editpdf", "Add text, images, and annotations in the browser."),
        ];

        public static readonly ToolGroup[] PdfToolGroups =
        [
            new("Compress & optimize", "Shrink files before email or upload.",
            [
                ("Compress PDF", "/pdf/compress", "Ghostscript compression up to 90% size reduction."),
                ("Compression hub", "/compress-pdf", "Guides for email limits and portal upload caps."),
            ]),
            new("Combine & organize", "Merge, split, rotate, and number pages.",
            [
                ("Merge PDF", "/pdf/merge", "Combine PDFs in custom order."),
                ("Split PDF", "/pdf/split", "Extract page ranges or split by size."),
                ("Rotate / remove pages", "/pdf/rotateorremove", "Fix scan orientation."),
                ("Add page numbers", "/pdf/pagenumbers", "Stamp footers on reports."),
            ]),
            new("Convert formats", "Office, image, and text conversions.",
            [
                ("PDF to Word", "/pdf/pdftodoc", "Editable DOCX from digital PDFs."),
                ("Word to PDF", "/pdf/doctopdf", "Print-ready PDF from DOCX."),
                ("PDF to Excel", "/pdf/pdftoexcel", "Extract tables to XLSX."),
                ("Excel to PDF", "/pdf/exceltopdf", "Share read-only spreadsheets."),
                ("PDF to PowerPoint", "/pdf/pdftoppt", "Slides from PDF pages."),
                ("PowerPoint to PDF", "/pdf/ppttopdf", "Share decks as PDF."),
                ("PDF to Text", "/pdf/pdftotext", "Plain text extraction."),
                ("Text to PDF", "/pdf/texttopdf", "Archive notes as PDF."),
                ("Images to PDF", "/pdf/convertimages", "Combine JPG/PNG into one PDF."),
                ("PDF to Images", "/pdf/pdftoimages", "Export pages as PNG."),
            ]),
            new("Edit & enrich", "OCR, metadata, and image extraction.",
            [
                ("Edit PDF", "/pdf/editpdf", "Quick browser edits."),
                ("OCR PDF", "/pdf/ocrpdf", "Searchable text layer on scans."),
                ("Extract images", "/pdf/extractimages", "Pull embedded photos from PDFs."),
                ("PDF metadata", "/pdf/pdfmetadata", "Inspect document properties."),
                ("Flatten PDF", "/pdf/flattenpdf", "Lock form field values."),
            ]),
            new("Secure & sign", "Protect, watermark, sign, and unlock.",
            [
                ("Sign PDF", "/pdf/signtext", "Typed signature blocks."),
                ("Watermark PDF", "/pdf/watermark", "Draft and confidential marks."),
                ("Password protect", "/pdf/password", "Encrypt before sharing."),
                ("Unlock PDF", "/pdf/unlockpdf", "Remove password when you know it."),
                ("PDF redaction", "/pdf-redaction", "Permanently hide sensitive text."),
            ]),
        ];

        public static readonly (string Name, string Url, string GuideSlug)[] SecureTools =
        [
            ("Sign PDF", "/pdf/signtext", "sign-pdf"),
            ("Watermark PDF", "/pdf/watermark", "watermark-pdf"),
            ("Password protect", "/pdf/password", "password-protect-pdf"),
            ("Unlock PDF", "/pdf/unlockpdf", "unlock-pdf"),
            ("PDF redaction", "/pdf-redaction", null!),
        ];

        public static readonly ToolGroup[] DeveloperToolGroups =
        [
            new("Format & parse", "Pretty-print payloads and inspect structured data.",
            [
                ("JSON Formatter", "/pdf/jsonformatter", "Validate and indent JSON for API debugging."),
                ("JWT Decoder", "/pdf/jwtdecoder", "Read header and payload claims from tokens."),
                ("HTML Formatter", "/pdf/htmlformatter", "Beautify HTML templates before review or export."),
            ]),
            new("Compare & encode", "Diff text and encode URL query parameters.",
            [
                ("Text Comparer", "/text-comparer", "Side-by-side diff for configs and redlines."),
                ("URL Encoder", "/url-encoder", "Percent-encode query string values."),
                ("URL Decoder", "/url-decoder", "Decode percent-encoded URLs."),
            ]),
            new("Conversion & network", "Binary math, Base64 data URIs, and DNS lookups.",
            [
                ("Binary to Decimal", "/binary-to-decimal", "Convert bit strings to decimal."),
                ("Decimal to Binary", "/decimal-to-binary", "Convert integers to binary."),
                ("Img to Base64", "/pdf/imgtobase64", "Embed small images as data URIs."),
                ("DNS Lookup", "/tools/dnslookup", "Query A, MX, TXT, and other records."),
                ("Browser OCR Tool", "/ocr-tool", "Extract text from images in the browser."),
            ]),
        ];

        private static readonly Dictionary<string, string[]> WorkflowByTool = new(StringComparer.OrdinalIgnoreCase)
        {
            ["/pdf/compress"] = ["/pdf/merge", "/pdf/split", "/invoice/create"],
            ["/pdf/merge"] = ["/pdf/compress", "/pdf/split", "/pdf/editpdf"],
            ["/pdf/split"] = ["/pdf/compress", "/pdf/merge", "/pdf/password"],
            ["/pdf/pdftodoc"] = ["/pdf/ocrpdf", "/pdf/pdftoexcel", "/pdf/editpdf"],
            ["/pdf/doctopdf"] = ["/pdf/compress", "/pdf/watermark", "/pdf/password"],
            ["/pdf/pdftoexcel"] = ["/pdf/pdftodoc", "/pdf/ocrpdf", "/pdf/compress"],
            ["/pdf/pdftoppt"] = ["/pdf/pdftodoc", "/pdf/pdftoimages", "/pdf/compress"],
            ["/pdf/ppttopdf"] = ["/pdf/compress", "/pdf/watermark", "/pdf/password"],
            ["/pdf/exceltopdf"] = ["/pdf/compress", "/pdf/merge", "/pdf/password"],
            ["/pdf/pdftotext"] = ["/pdf/ocrpdf", "/pdf/pdftodoc", "/pdf/pdftomarkdown"],
            ["/pdf/htmltopdf"] = ["/pdf/texttopdf", "/pdf/doctopdf", "/pdf/compress"],
            ["/pdf/pdftomarkdown"] = ["/pdf/pdftotext", "/pdf/pdftodoc", "/pdf/ocrpdf"],
            ["/pdf/texttopdf"] = ["/pdf/compress", "/pdf/watermark", "/pdf/merge"],
            ["/pdf/editpdf"] = ["/pdf/watermark", "/pdf/signtext", "/pdf/password"],
            ["/pdf/watermark"] = ["/pdf/password", "/pdf/signtext", "/pdf/compress"],
            ["/pdf/password"] = ["/pdf/watermark", "/pdf/unlockpdf", "/pdf/compress"],
            ["/pdf/signtext"] = ["/pdf/watermark", "/pdf/password", "/pdf/merge"],
            ["/pdf/unlockpdf"] = ["/pdf/flattenpdf", "/pdf/compress", "/pdf/merge"],
            ["/pdf/ocrpdf"] = ["/pdf/pdftodoc", "/pdf/pdftoexcel", "/pdf/pdftotext"],
            ["/pdf/flattenpdf"] = ["/pdf/password", "/pdf/compress", "/pdf/merge"],
            ["/pdf/convertimages"] = ["/pdf/compress", "/pdf/merge", "/pdf/ocrpdf"],
            ["/pdf/pdftoimages"] = ["/pdf/extractimages", "/pdf/convertimages", "/pdf/compress"],
            ["/pdf/extractimages"] = ["/pdf/pdftoimages", "/pdf/convertimages", "/pdf/compress"],
            ["/pdf/pagenumbers"] = ["/pdf/merge", "/pdf/compress", "/pdf/watermark"],
            ["/pdf/pdfmetadata"] = ["/pdf/editpdf", "/pdf/password", "/pdf/flattenpdf"],
            ["/pdf/rotateorremove"] = ["/pdf/merge", "/pdf/split", "/pdf/compress"],
            ["/invoice/create"] = ["/pdf/compress", "/pdf/merge", "/pdf/watermark"],
        };

        private static readonly Dictionary<string, string> BlogSlugByTool = new(StringComparer.OrdinalIgnoreCase)
        {
            ["/pdf/compress"] = "choose-pdf-compression-level",
            ["/pdf/merge"] = "merge-pdf-without-quality-loss",
            ["/pdf/pdftodoc"] = "pdf-vs-word-when-to-convert",
            ["/pdf/split"] = "send-large-pdf-email",
            ["/pdf/password"] = "secure-pdf-password-best-practices",
            ["/pdf/watermark"] = "secure-pdf-password-best-practices",
            ["/pdf/signtext"] = "small-business-pdf-workflow",
            ["/pdf/pdftoppt"] = "powerpoint-from-pdf-tips",
            ["/pdf/ppttopdf"] = "powerpoint-from-pdf-tips",
            ["/pdf/htmltopdf"] = "html-to-pdf-developers",
            ["/pdf/pdftomarkdown"] = "pdf-vs-word-when-to-convert",
            ["/pdf-redaction"] = "pdf-redaction-vs-password",
            ["/pdf/editpdf"] = "pdf-editing-mistakes",
            ["/invoice/create"] = "gst-invoice-pdf-checklist",
        };

        private static readonly HashSet<string> SecureToolPaths = new(StringComparer.OrdinalIgnoreCase)
        {
            "/pdf/watermark", "/pdf/password", "/pdf/signtext", "/pdf/unlockpdf", "/pdf-redaction",
        };

        public static string CanonicalHub() => PdfToolSeo.Canonical(PdfToolsHubPath);
        public static string CanonicalSecureHub() => PdfToolSeo.Canonical(SecureWorkflowPath);
        public static string CanonicalDeveloperGuidesHub() => PdfToolSeo.Canonical(DeveloperGuidesHubPath);

        public static bool IsDeveloperCategory(string? category) =>
            string.Equals(category, "Developer", StringComparison.OrdinalIgnoreCase);

        public static bool IsSecureTool(string? path) =>
            !string.IsNullOrEmpty(path) && SecureToolPaths.Contains(Normalize(path));

        public static IReadOnlyList<(string Name, string Url)> GetWorkflowLinks(string? currentPath)
        {
            currentPath = Normalize(currentPath);
            if (!WorkflowByTool.TryGetValue(currentPath, out var targets))
                return Array.Empty<(string, string)>();

            return targets
                .Select(url => (PdfToolSeo.AllTools.FirstOrDefault(t => PathsEqual(t.Url, url)).Name
                    ?? url.TrimStart('/').Replace('/', ' '), url))
                .ToList();
        }

        public static ContentEntry? GetBlogForTool(string? currentPath)
        {
            currentPath = Normalize(currentPath);
            if (!BlogSlugByTool.TryGetValue(currentPath, out var slug))
                return null;
            return ContentLibrary.GetBlog(slug);
        }

        public static string? GetClusterHubPath(string? toolPath)
        {
            toolPath = Normalize(toolPath);
            if (PathsEqual(toolPath, "/pdf/compress"))
                return "/compress-pdf";

            var categoryHub = GetCategoryHubPath(toolPath);
            if (categoryHub != null)
                return categoryHub;

            var prefix = PdfToolSeoLandingGenerator.GetRoutePrefixForToolUrl(toolPath);
            return prefix == null ? null : $"/{prefix}";
        }

        /// <summary>Category silo hub for non-PDF tools (developer, calculators, etc.).</summary>
        public static string? GetCategoryHubPath(string? toolPath)
        {
            toolPath = Normalize(toolPath);
            var category = SiteToolNavigation.InferRelatedCategory(toolPath);
            return category switch
            {
                SiteToolCategories.Developer => DeveloperHubPath,
                SiteToolCategories.Calculators => CalculatorsHubPath,
                SiteToolCategories.Utilities => UtilitiesHubPath,
                SiteToolCategories.Network => UtilitiesHubPath,
                SiteToolCategories.Business => BusinessHubPath,
                SiteToolCategories.Image => AllToolsHubPath,
                _ when PdfToolSeo.AllTools.Any(t => PathsEqual(t.Url, toolPath)) => PdfToolsHubPath,
                _ => null,
            };
        }

        public static IReadOnlyList<(string Label, string Href)> GetFeaturedClusterLinks(string? toolPath, int max = 3)
        {
            toolPath = Normalize(toolPath);
            if (PathsEqual(toolPath, "/pdf/compress"))
            {
                return new (string Label, string Href)[]
                {
                    ("Compress PDF for email", "/compress-pdf-for-email"),
                    ("Compress PDF online free", "/compress-pdf-online"),
                    ("Compress Aadhaar PDF", "/compress-aadhar-pdf"),
                }.Take(max).ToList();
            }

            var prefix = PdfToolSeoLandingGenerator.GetRoutePrefixForToolUrl(toolPath);
            if (prefix == null) return Array.Empty<(string, string)>();

            return PdfToolSeoLandingGenerator.GetSiblingClusterLinks(prefix, slug: null, max);
        }

        private static string Normalize(string path)
        {
            path = path.Trim();
            if (path.Length > 1 && path.EndsWith('/'))
                path = path.TrimEnd('/');
            return path.Length == 0 ? "/" : path;
        }

        private static bool PathsEqual(string a, string b) =>
            string.Equals(Normalize(a), Normalize(b), StringComparison.OrdinalIgnoreCase);
    }
}
