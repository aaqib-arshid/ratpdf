using System.Text;
using ratpdf.Constants;
using ratpdf.Models;

namespace ratpdf.Services
{
    /// <summary>Long-tail SEO landing pages for new PDF tools.</summary>
    public static class PdfToolSeoLandingGenerator
    {
        public sealed record LandingConfig(
            string RoutePrefix,
            string ToolUrl,
            string ToolLinkText,
            string VerbPhrase,
            string[] Keywords);

        private static readonly LandingConfig[] Configs =
        [
            new("unlock-pdf", "/PDF/UnlockPdf", "Unlock PDF tool", "unlock a password-protected PDF",
            [
                "unlock pdf online",
                "remove pdf password",
                "decrypt pdf online",
                "pdf password remover free",
                "unlock protected pdf",
                "remove pdf encryption",
                "pdf unlock without software",
                "open password protected pdf",
                "strip pdf password",
                "pdf decryption online free",
                "unlock pdf for printing",
                "remove owner password pdf",
                "unlock pdf file online free",
                "how to unlock pdf password",
                "pdf password unlock tool",
            ]),
            new("flatten-pdf", "/PDF/FlattenPdf", "Flatten PDF tool", "flatten a PDF form",
            [
                "flatten pdf online",
                "flatten pdf forms",
                "merge form fields pdf",
                "make pdf non editable",
                "flatten annotations pdf",
                "pdf flatten tool free",
                "flatten fillable pdf",
                "lock pdf form fields",
                "flatten pdf for submission",
                "flatten interactive pdf",
                "pdf form flatten online",
                "flatten signed pdf",
                "flatten pdf acrobat alternative",
                "flatten pdf before email",
                "how to flatten a pdf form",
            ]),
            new("pdf-to-images", "/PDF/PdfToImages", "PDF to Images tool", "convert PDF pages to PNG images",
            [
                "pdf to png online",
                "convert pdf to images",
                "pdf to jpg converter free",
                "export pdf pages as images",
                "pdf to image converter online",
                "save pdf as png",
                "pdf page to image",
                "pdf to pictures online",
                "convert pdf to png zip",
                "pdf to image free no signup",
                "pdf to high resolution images",
                "pdf to png 300 dpi",
                "extract pdf pages as images",
                "pdf to image batch",
                "pdf to png converter online free",
            ]),
            new("extract-images-from-pdf", "/PDF/ExtractImages", "Extract Images from PDF tool", "extract images from a PDF",
            [
                "extract images from pdf",
                "get pictures from pdf",
                "pdf image extractor online",
                "save images from pdf",
                "pull photos out of pdf",
                "extract embedded images pdf",
                "pdf photo extractor free",
                "download images from pdf online",
                "extract all images pdf zip",
                "pdf to images embedded",
                "grab images from pdf file",
                "extract logos from pdf",
                "pdf image ripper online",
                "export images from pdf free",
                "how to extract pictures from pdf",
            ]),
            new("ocr-pdf", "/PDF/OcrPdf", "OCR PDF tool", "OCR a scanned PDF",
            [
                "ocr pdf online",
                "make pdf searchable",
                "ocr scanned pdf free",
                "pdf ocr converter",
                "searchable pdf online",
                "ocr pdf to text layer",
                "tesseract pdf ocr online",
                "ocr image pdf",
                "scan pdf ocr free",
                "add text layer to pdf",
                "ocr pdf document online",
                "make scanned pdf searchable free",
                "pdf ocr no download",
                "ocr pdf english online",
                "convert scanned pdf searchable",
            ]),
            new("add-page-numbers-to-pdf", "/PDF/PageNumbers", "Add Page Numbers tool", "add page numbers to a PDF",
            [
                "add page numbers to pdf",
                "number pdf pages online",
                "pdf page numbering tool",
                "insert page numbers pdf free",
                "pdf footer page numbers",
                "paginate pdf online",
                "add page number footer pdf",
                "number pages in pdf document",
                "pdf bates numbering alternative",
                "page numbers pdf online free",
                "stamp page numbers pdf",
                "add page count to pdf",
                "pdf pagination online",
                "how to number pdf pages",
                "add page numbers pdf without acrobat",
            ]),
            new("pdf-metadata", "/PDF/PdfMetadata", "PDF Metadata Viewer", "view PDF metadata",
            [
                "pdf metadata viewer",
                "read pdf properties online",
                "pdf document info extractor",
                "check pdf author and title",
                "pdf metadata extractor",
                "view pdf file information",
                "pdf properties viewer online",
                "extract pdf metadata json",
                "pdf info reader free",
                "see pdf creation date",
                "pdf document details online",
                "inspect pdf metadata",
                "pdf xmp viewer online",
                "pdf file info tool",
                "how to view pdf metadata",
            ]),
        ];

        private static readonly Dictionary<string, LandingConfig> ByPrefix =
            Configs.ToDictionary(c => c.RoutePrefix, StringComparer.OrdinalIgnoreCase);

        public static IReadOnlyList<string> AllLandingPaths()
        {
            var paths = new List<string>();
            foreach (var cfg in Configs)
            {
                foreach (var kw in cfg.Keywords)
                    paths.Add($"/{cfg.RoutePrefix}/{GenerateSlug(kw)}");
            }
            return paths;
        }

        public static SEOPageModel? Populate(string routePrefix, string slug)
        {
            if (!ByPrefix.TryGetValue(routePrefix, out var cfg))
                return null;

            var keyword = cfg.Keywords.FirstOrDefault(k => GenerateSlug(k) == slug);
            if (keyword == null)
                return null;

            return GeneratePage(cfg, keyword);
        }

        public static string GenerateSlug(string keyword) =>
            keyword.ToLowerInvariant()
                .Replace("&", "and", StringComparison.Ordinal)
                .Replace("'", "", StringComparison.Ordinal)
                .Replace(",", "", StringComparison.Ordinal)
                .Replace("?", "", StringComparison.Ordinal)
                .Replace(" ", "-", StringComparison.Ordinal);

        private static SEOPageModel GeneratePage(LandingConfig cfg, string keyword)
        {
            var title = keyword switch
            {
                var k when k.Contains("free", StringComparison.OrdinalIgnoreCase) =>
                    $"{Capitalize(k)} — Free Online Tool | RatPDF",
                var k when k.StartsWith("how to", StringComparison.OrdinalIgnoreCase) =>
                    $"{Capitalize(k)} — Step-by-Step Guide | RatPDF",
                _ => $"{Capitalize(keyword)} Online — Fast & Secure | RatPDF",
            };

            var toolHref = PdfToolSeo.Canonical(cfg.ToolUrl);
            var toolLink = $"<a href=\"{toolHref}\">{cfg.ToolLinkText}</a>";

            var sb = new StringBuilder();
            sb.Append($"""
                <p>Need to <strong>{keyword}</strong>? RatPDF's {toolLink} runs on production-grade engines with HTTPS upload, automatic file deletion, and generous free limits. No desktop install, no watermarks on output.</p>
                <h2>Why {keyword} online?</h2>
                <p>Browser-based tools save time when you are on a locked-down work laptop, a phone, or a shared kiosk. Upload once, process on our servers, download the result. Free users get 3 conversions per tool per day (200 MB per file); <a href="/Subscription/Plans">Pro</a> supports 4 GB files and unlimited daily use.</p>
                <h2>How to {cfg.VerbPhrase}</h2>
                <ol>
                <li>Open the {toolLink} on ratpdf.com.</li>
                <li>Drag your PDF into the upload area or click to browse.</li>
                <li>Adjust any tool-specific options (password, DPI, page format, etc.).</li>
                <li>Click the action button and wait for the progress bar — large files run as background jobs.</li>
                <li>Download the finished file when the job completes.</li>
                </ol>
                <h2>Who uses this workflow?</h2>
                <ul>
                <li><strong>Finance &amp; legal</strong> — prepare filings, contracts, and audit packs</li>
                <li><strong>HR &amp; operations</strong> — forms, onboarding PDFs, numbered SOPs</li>
                <li><strong>Marketing &amp; design</strong> — extract assets, export slide pages as images</li>
                <li><strong>Students &amp; researchers</strong> — OCR scans, unlock course PDFs you own</li>
                </ul>
                <h2>Related RatPDF tools</h2>
                <p>After you {keyword}, you may also need <a href="/PDF/Compress">Compress PDF</a>, <a href="/PDF/Merge">Merge PDF</a>, <a href="/PDF/Password">Password Protect PDF</a>, or <a href="/PDF/PdfToDoc">PDF to Word</a>. Browse <a href="/guides">step-by-step guides</a> for every major tool.</p>
                <h2>Security &amp; privacy</h2>
                <p>Files are transferred over TLS, processed in isolated jobs, and removed after download. We do not sell document content or use uploads to train models.</p>
                """);

            return new SEOPageModel
            {
                Title = title,
                Description = $"Learn how to {keyword} with RatPDF. Secure online PDF processing — free tier available, Pro up to 4 GB.",
                Slug = GenerateSlug(keyword),
                RoutePrefix = cfg.RoutePrefix,
                ToolUrl = cfg.ToolUrl,
                ToolLinkText = cfg.ToolLinkText,
                FullContentHtml = sb.ToString(),
                FAQ =
                [
                    ($"How do I {keyword}?", $"Open the {cfg.ToolLinkText} at ratpdf.com{cfg.ToolUrl}, upload your PDF, and follow the on-screen steps. Results download when processing finishes."),
                    ($"Is it free to {keyword}?", "Yes — free users get 3 uses per tool per day with 200 MB per file. Pro plans add unlimited use and 4 GB uploads."),
                    ("Are my files kept private?", "Uploads use HTTPS and temporary server storage. Files are deleted after you download the result."),
                    ("What file size is supported?", "Free tier: 200 MB per PDF. Pro subscribers can upload up to 4 GB per file."),
                ],
            };
        }

        private static string Capitalize(string kword)
        {
            if (string.IsNullOrEmpty(kword)) return kword;
            return char.ToUpperInvariant(kword[0]) + kword[1..];
        }
    }
}
