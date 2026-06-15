using System.Text;
using ratpdf.Helpers;
using ratpdf.Models.ProgrammaticSeo;

namespace ratpdf.Services.Seo
{
    /// <summary>Layer 2 intent templates — varied copy slots, never raw slug injection.</summary>
    public static class PdfToTxtIntentContentBuilder
    {
        public static string BuildContent(
            IntentClassification intent,
            string displayTitle,
            string slug,
            string toolHref)
        {
            var variant = Math.Abs(StringComparer.Ordinal.GetHashCode(slug)) % 3;
            var sb = new StringBuilder();

            sb.Append(BuildIntro(intent, displayTitle, toolHref, variant));
            sb.Append(BuildTechnicalSection(intent, variant));
            sb.Append(BuildUseCases(intent, variant));
            sb.Append(BuildWorkflow(intent, toolHref));

            return sb.ToString();
        }

        public static IReadOnlyList<(string Question, string Answer)> BuildFaqs(
            IntentClassification intent,
            string displayTitle,
            string toolHref,
            string slug)
        {
            var variant = Math.Abs(StringComparer.Ordinal.GetHashCode(slug)) % 2;
            return intent.Intent switch
            {
                SearchIntent.DeviceBased => DeviceFaqs(intent.Device ?? "your device", toolHref),
                SearchIntent.ErrorRecovery => ErrorFaqs(toolHref),
                SearchIntent.TaskBased => TaskFaqs(displayTitle, toolHref, variant),
                _ => NavigationalFaqs(toolHref, variant),
            };
        }

        private static string BuildIntro(IntentClassification intent, string title, string toolHref, int variant)
        {
            return intent.Intent switch
            {
                SearchIntent.DeviceBased =>
                    $"<p class=\"lead\">This guide covers <strong>{title}</strong> on {intent.Device}. RatPDF runs in the browser — open <a href=\"{toolHref}\">PDF to Text</a>, upload, and download UTF-8 output without installing an app.</p>",
                SearchIntent.ErrorRecovery => variant switch
                {
                    0 => $"<p class=\"lead\"><strong>{title}</strong> usually means the PDF lacks a selectable text layer, is password-locked, or OCR quality is poor. RatPDF walks through diagnosis and the fix.</p>",
                    1 => $"<p class=\"lead\">When text extraction fails, the cause is almost always one of three issues: image-only pages, encryption, or corrupt fonts. Use <a href=\"{toolHref}\">PDF to Text</a> after fixing the underlying problem.</p>",
                    _ => $"<p class=\"lead\">Troubleshooting <strong>{title}</strong>: start by checking whether you can highlight words in a PDF viewer. If not, run <a href=\"/pdf/ocrpdf\">OCR PDF</a> before extraction.</p>",
                },
                SearchIntent.TaskBased =>
                    $"<p class=\"lead\">Follow this workflow for <strong>{title}</strong>. RatPDF's <a href=\"{toolHref}\">PDF to Text</a> tool exports plain text for editing, search, and automation — no desktop software required.</p>",
                _ => variant switch
                {
                    0 => $"<p class=\"lead\">Use RatPDF for <strong>{title}</strong> — upload a PDF to <a href=\"{toolHref}\">PDF to Text</a>, extract characters from the document's text layer, and download a .txt file.</p>",
                    1 => $"<p class=\"lead\"><strong>{title}</strong> on RatPDF: free browser extraction with HTTPS upload and automatic file deletion after processing.</p>",
                    _ => $"<p class=\"lead\">RatPDF helps with <strong>{title}</strong>. Digital PDFs extract in seconds; scanned documents need OCR first.</p>",
                },
            };
        }

        private static string BuildTechnicalSection(IntentClassification intent, int variant)
        {
            if (intent.Intent is SearchIntent.ErrorRecovery or SearchIntent.TaskBased
                && (variant == 1 || intent.Intent == SearchIntent.ErrorRecovery))
            {
                return """
                    <h2>How PDF text extraction works</h2>
                    <p>PDFs store text as drawing instructions (glyphs positioned on a page). Extraction decodes those glyphs into Unicode. Scanned PDFs skip this — pages are images until OCR adds a hidden text layer. Password-protected files block reading until unlocked.</p>
                    """;
            }

            if (variant == 0)
            {
                return """
                    <h2>Digital vs scanned PDFs</h2>
                    <p><strong>Digital PDFs</strong> (exported from Word, Google Docs, LaTeX) contain real text — extraction is fast.<br/>
                    <strong>Scanned PDFs</strong> are photos of pages — run <a href="/pdf/ocrpdf">OCR PDF</a> first, then extract.</p>
                    """;
            }

            return """
                <h2>Output format</h2>
                <p>RatPDF exports UTF-8 plain text (<code>.txt</code>). Bold, columns, and images are not preserved. For editable layout use <a href="/pdf/pdftodoc">PDF to Word</a>; for tables use <a href="/pdf/pdftoexcel">PDF to Excel</a>.</p>
                """;
        }

        private static string BuildUseCases(IntentClassification intent, int variant)
        {
            var cases = variant switch
            {
                0 => """
                    <ul>
                    <li><strong>Visa &amp; government forms</strong> — copy instructions into checklists</li>
                    <li><strong>Job applications</strong> — pull requirements from PDF job posts</li>
                    <li><strong>Banking uploads</strong> — verify numbers before retyping into portals</li>
                    </ul>
                    """,
                1 => """
                    <ul>
                    <li><strong>Research papers</strong> — quote sections without retyping</li>
                    <li><strong>Legal review</strong> — feed clauses into diff or LLM tools</li>
                    <li><strong>Data cleanup</strong> — move text into Python or Excel scripts</li>
                    </ul>
                    """,
                _ => """
                    <ul>
                    <li><strong>Accessibility</strong> — confirm OCR text layers for screen readers</li>
                    <li><strong>Archiving</strong> — store searchable plain-text copies</li>
                    <li><strong>Translation prep</strong> — export source text before CAT tools</li>
                    </ul>
                    """,
            };

            return $"<h2>Common use cases</h2>{cases}";
        }

        private static string BuildWorkflow(IntentClassification intent, string toolHref)
        {
            var ocrStep = intent.Intent is SearchIntent.ErrorRecovery or SearchIntent.TaskBased
                ? "<li>If the PDF is scanned, run <a href=\"/pdf/ocrpdf\">OCR PDF</a> first.</li>"
                : "";

            return $"""
                <h2>Quick workflow</h2>
                <ol>
                <li>Open <a href="{toolHref}">PDF to Text</a>.</li>
                <li>Upload your PDF.</li>
                {ocrStep}
                <li>Download the .txt file or copy the output.</li>
                </ol>
                """;
        }

        private static IReadOnlyList<(string Question, string Answer)> NavigationalFaqs(string toolHref, int variant) =>
            variant == 0
                ?
                [
                    ("Is PDF to Text free?", "Yes — 3 uses per tool per day on the free tier (200 MB per file)."),
                    ("Where do I start?", $"Open PDF to Text at ratpdf.com{toolHref} and upload your file."),
                    ("Is upload secure?", "Files transfer over HTTPS and are deleted after processing."),
                    ("Mobile support?", "Works in mobile browsers on iOS and Android."),
                ]
                :
                [
                    ("What file types are supported?", "Standard PDF files (.pdf). Unlock password-protected files first."),
                    ("How fast is extraction?", "Digital PDFs usually finish in seconds."),
                    ("Will layout be kept?", "Plain text only — use PDF to Word for formatting."),
                    ("Need OCR?", "Image-only scans require OCR PDF before text extraction."),
                ];

        private static IReadOnlyList<(string Question, string Answer)> TaskFaqs(string title, string toolHref, int variant) =>
            variant == 0
                ?
                [
                    ("What are the steps?", $"Upload to PDF to Text at ratpdf.com{toolHref}, extract, download .txt."),
                    ("Works on scans?", "Run OCR first if you cannot select text in a viewer."),
                    ("Free tier limits?", "3 uses/day, 200 MB per file on free tier."),
                    ("Best for tables?", "Use PDF to Excel for structured tables."),
                ]
                :
                [
                    ("Can I automate this?", "Download .txt and use in your scripts — batch API is not on free tier."),
                    ("Encoding?", "Output is UTF-8 plain text."),
                    ("Privacy?", "Do not upload confidential files you cannot send to a processor."),
                    ("Desktop required?", "No — works entirely in the browser."),
                ];

        private static IReadOnlyList<(string Question, string Answer)> DeviceFaqs(string device, string toolHref) =>
        [
            ($"Do I need an app on {device}?", "No — RatPDF runs in your browser without installing software."),
            ("How do I upload?", $"Open PDF to Text at ratpdf.com{toolHref} and pick a file from local or cloud storage."),
            ("Scanned PDFs?", "Use OCR PDF first, then extract text."),
            ("Is it secure?", "HTTPS transfer; files deleted after processing."),
        ];

        private static IReadOnlyList<(string Question, string Answer)> ErrorFaqs(string toolHref) =>
        [
            ("Why is extracted text empty?", "The PDF is likely image-only — run OCR PDF first."),
            ("Password-protected file?", "Unlock the PDF before upload."),
            ("Garbled characters?", "May indicate custom font encoding — try OCR or PDF to Word."),
            ("Where to extract?", $"Use PDF to Text at ratpdf.com{toolHref} after fixing the underlying issue."),
        ];

        /// <summary>Human display title — strips competitor tokens, never uses raw slug as sentence.</summary>
        public static string BuildDisplayTitle(string slug, string? keywordPhrase, IntentClassification intent)
        {
            if (intent.HasCompetitorNoise)
            {
                return intent.Intent switch
                {
                    SearchIntent.DeviceBased => $"PDF to Text on {intent.Device}",
                    SearchIntent.TaskBased when slug.Contains("ocr", StringComparison.Ordinal) || slug.Contains("scan", StringComparison.Ordinal)
                        => "Scanned PDF to Text",
                    SearchIntent.TaskBased => "Convert PDF to Text",
                    _ => "PDF to Text Online",
                };
            }

            var phrase = string.IsNullOrWhiteSpace(keywordPhrase)
                ? slug.Replace('-', ' ')
                : keywordPhrase.Replace('-', ' ');

            return SlugTitleHelper.FromPhrase(phrase);
        }
    }
}
