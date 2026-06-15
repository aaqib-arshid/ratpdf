using ratpdf.Helpers;
using ratpdf.Models.ProgrammaticSeo;

namespace ratpdf.Services.Seo
{
    /// <summary>Intent-based copy for PDF-to-word, edit-PDF, and compress long-tail — no keyword injection.</summary>
    public static class VerticalIntentContentBuilder
    {
        public static string BuildDisplayTitle(PdfToolVertical vertical, string slug, string? keywordPhrase, IntentClassification intent)
        {
            if (intent.HasCompetitorNoise)
            {
                return vertical switch
                {
                    PdfToolVertical.PdfToWord => intent.Intent == SearchIntent.DeviceBased
                        ? $"PDF to Word on {intent.Device}" : "Convert PDF to Word Online",
                    PdfToolVertical.EditPdf => intent.Intent == SearchIntent.DeviceBased
                        ? $"Edit PDF on {intent.Device}" : "Edit PDF Online",
                    PdfToolVertical.CompressPdf => intent.Intent == SearchIntent.DeviceBased
                        ? $"Compress PDF on {intent.Device}" : "Compress PDF Online",
                    _ => "PDF Tool Online",
                };
            }

            var phrase = string.IsNullOrWhiteSpace(keywordPhrase) ? slug.Replace('-', ' ') : keywordPhrase.Replace('-', ' ');
            return SlugTitleHelper.FromPhrase(phrase);
        }

        public static string BuildContent(PdfToolVertical vertical, IntentClassification intent, string displayTitle, string slug, string toolHref)
        {
            var v = Math.Abs(StringComparer.Ordinal.GetHashCode(slug)) % 3;
            var product = ProductName(vertical);
            var intro = BuildIntro(vertical, intent, displayTitle, toolHref, product, v);
            var body = vertical switch
            {
                PdfToolVertical.PdfToWord => WordBody(v),
                PdfToolVertical.EditPdf => EditBody(v),
                PdfToolVertical.CompressPdf => CompressBody(v),
                _ => "",
            };
            var workflow = BuildWorkflow(vertical, intent, toolHref);
            return intro + body + workflow;
        }

        public static IReadOnlyList<(string Question, string Answer)> BuildFaqs(
            PdfToolVertical vertical, IntentClassification intent, string toolHref, string slug)
        {
            var v = Math.Abs(StringComparer.Ordinal.GetHashCode(slug)) % 2;
            return vertical switch
            {
                PdfToolVertical.PdfToWord => WordFaqs(toolHref, v),
                PdfToolVertical.EditPdf => EditFaqs(toolHref, v),
                PdfToolVertical.CompressPdf => CompressFaqs(toolHref, v),
                _ => [],
            };
        }

        private static string ProductName(PdfToolVertical v) => v switch
        {
            PdfToolVertical.PdfToWord => "PDF to Word",
            PdfToolVertical.EditPdf => "PDF Editor",
            PdfToolVertical.CompressPdf => "PDF Compressor",
            _ => "PDF tool",
        };

        private static string BuildIntro(PdfToolVertical vertical, IntentClassification intent, string title, string toolHref, string product, int v)
        {
            if (intent.Intent == SearchIntent.DeviceBased)
                return $"<p class=\"lead\"><strong>{title}</strong> on {intent.Device}: use RatPDF {product} in your browser — open <a href=\"{toolHref}\">{product}</a>, upload, and download. No app install required.</p>";

            if (intent.Intent == SearchIntent.ErrorRecovery)
                return $"<p class=\"lead\">Troubleshooting <strong>{title}</strong>: common causes include scanned PDFs, passwords, or complex layouts. RatPDF's <a href=\"{toolHref}\">{product}</a> handles most digital PDFs; scans may need <a href=\"/pdf/ocrpdf\">OCR</a> first.</p>";

            return v switch
            {
                0 => $"<p class=\"lead\">Use RatPDF for <strong>{title}</strong> — <a href=\"{toolHref}\">{product}</a> runs in your browser with HTTPS upload and automatic file deletion.</p>",
                1 => $"<p class=\"lead\"><strong>{title}</strong> with RatPDF: free tier (3 uses/day, 200 MB). Pro supports larger files and unlimited daily use.</p>",
                _ => $"<p class=\"lead\">This guide covers <strong>{title}</strong>. Start at <a href=\"{toolHref}\">{product}</a> on ratpdf.com.</p>",
            };
        }

        private static string WordBody(int v) => v switch
        {
            0 => """
                <h2>Digital vs scanned PDFs</h2>
                <p>PDFs exported from Word or Google Docs convert cleanly to editable DOCX. Scanned PDFs need <a href="/pdf/ocrpdf">OCR</a> before conversion for best results.</p>
                <h2>Use cases</h2>
                <ul>
                <li><strong>Contracts</strong> — redline clauses in Word track changes</li>
                <li><strong>Resumes</strong> — edit PDF résumés received from candidates</li>
                <li><strong>Reports</strong> — reuse charts and paragraphs in new documents</li>
                </ul>
                """,
            1 => """
                <h2>Output format</h2>
                <p>RatPDF produces DOCX (modern Word). Tables and images are preserved where possible; complex magazine layouts may need manual cleanup.</p>
                <h2>When to use plain text instead</h2>
                <p>For scripts and search, use <a href="/pdf/pdftotext">PDF to Text</a>. For spreadsheets, try <a href="/pdf/pdftoexcel">PDF to Excel</a>.</p>
                """,
            _ => """
                <h2>Quality tips</h2>
                <ul>
                <li>Unlock password-protected PDFs before upload</li>
                <li>Split files over 200 MB on free tier using <a href="/pdf/split">Split PDF</a></li>
                <li>Proofread converted tables — merge cells may shift</li>
                </ul>
                """,
        };

        private static string EditBody(int v) => v switch
        {
            0 => """
                <h2>What you can edit</h2>
                <p>Add text, images, highlights, and signatures in the browser. For form fields, click and type directly when the PDF contains interactive forms.</p>
                <h2>Common tasks</h2>
                <ul>
                <li>Fix typos on published PDFs without the source file</li>
                <li>Fill and sign intake forms</li>
                <li>Stamp “DRAFT” with <a href="/pdf/watermark">Watermark PDF</a></li>
                </ul>
                """,
            1 => """
                <h2>Scanned PDFs</h2>
                <p>Image-only scans are not directly editable — run <a href="/pdf/ocrpdf">OCR PDF</a> first to add a text layer, then edit in RatPDF.</p>
                <h2>Security</h2>
                <p>Files transfer over HTTPS and are deleted after processing. Avoid uploading material you cannot send to a third-party processor.</p>
                """,
            _ => """
                <h2>After editing</h2>
                <p>Download the updated PDF. If file size grew, use <a href="/pdf/compress">Compress PDF</a> before email. To lock values, <a href="/pdf/flattenpdf">Flatten PDF</a>.</p>
                """,
        };

        private static string CompressBody(int v) => v switch
        {
            0 => """
                <h2>How compression works</h2>
                <p>RatPDF downsamples images, subsets fonts, and removes redundant objects using Ghostscript — real size reduction, not just re-saving.</p>
                <h2>Typical targets</h2>
                <ul>
                <li><strong>Email</strong> — under 20–25 MB attachment limits</li>
                <li><strong>Government portals</strong> — 100KB–500KB caps</li>
                <li><strong>Mobile sharing</strong> — faster uploads on slow networks</li>
                </ul>
                """,
            1 => """
                <h2>Quality vs size</h2>
                <p>Higher compression reduces image DPI. For print-ready files, use moderate settings. See <a href="/compress-pdf-without-losing-quality">compress without losing quality</a>.</p>
                """,
            _ => """
                <h2>Before you compress</h2>
                <p>Merge related files with <a href="/pdf/merge">Merge PDF</a> if a portal allows one upload. Remove unused pages with <a href="/pdf/split">Split PDF</a> first.</p>
                """,
        };

        private static string BuildWorkflow(PdfToolVertical vertical, IntentClassification intent, string toolHref)
        {
            var ocr = intent.Intent is SearchIntent.ErrorRecovery or SearchIntent.TaskBased
                ? "<li>If the file is scanned, run <a href=\"/pdf/ocrpdf\">OCR PDF</a> first.</li>" : "";

            var steps = vertical switch
            {
                PdfToolVertical.PdfToWord => ("Convert", "Download the DOCX file."),
                PdfToolVertical.EditPdf => ("Save", "Download the edited PDF."),
                PdfToolVertical.CompressPdf => ("Compress", "Download the smaller PDF."),
                _ => ("Process", "Download the result."),
            };

            return $"""
                <h2>Quick workflow</h2>
                <ol>
                <li>Open <a href="{toolHref}">RatPDF {ProductName(vertical)}</a>.</li>
                <li>Upload your PDF.</li>
                {ocr}
                <li>{steps.Item1} — {steps.Item2}</li>
                </ol>
                """;
        }

        private static IReadOnlyList<(string Question, string Answer)> WordFaqs(string toolHref, int v) =>
            v == 0
                ?
                [
                    ("Is PDF to Word free?", "Yes — 3 uses/day on free tier (200 MB per file)."),
                    ("Will formatting be preserved?", "Digital PDFs convert well; complex layouts may need cleanup in Word."),
                    ("Scanned PDFs?", "Run OCR first, then convert to Word."),
                    ("Where to start?", $"Open PDF to Word at ratpdf.com{toolHref}."),
                ]
                :
                [
                    ("DOC or DOCX?", "RatPDF outputs DOCX for modern Word."),
                    ("File limits?", "Free: 200 MB. Pro: up to 4 GB."),
                    ("Privacy?", "HTTPS upload; files deleted after processing."),
                    ("Tables?", "Most tables convert; verify merged cells manually."),
                ];

        private static IReadOnlyList<(string Question, string Answer)> EditFaqs(string toolHref, int v) =>
            v == 0
                ?
                [
                    ("Can I edit PDFs free?", "Yes — browser editor on RatPDF free tier."),
                    ("Add a signature?", "Use the Sign PDF tool or editor signature block."),
                    ("Password PDFs?", "Unlock first with the password you know."),
                    ("Start editing?", $"Go to ratpdf.com{toolHref}."),
                ]
                :
                [
                    ("Mobile editing?", "Works in mobile browsers on iOS and Android."),
                    ("OCR needed?", "For image-only scans, yes — use OCR PDF first."),
                    ("Flatten edits?", "Use Flatten PDF to lock form values before sharing."),
                    ("Secure?", "Files are not stored long-term after processing."),
                ];

        private static IReadOnlyList<(string Question, string Answer)> CompressFaqs(string toolHref, int v) =>
            v == 0
                ?
                [
                    ("How much smaller?", "Often 40–90% for image-heavy PDFs; text PDFs see smaller gains."),
                    ("Is it free?", "Yes — 3 compressions/day on free tier."),
                    ("Quality loss?", "Adjust compression level; higher = smaller file, lower DPI."),
                    ("Start here?", $"Use Compress PDF at ratpdf.com{toolHref}."),
                ]
                :
                [
                    ("Email limits?", "Aim for under 20 MB for Gmail; use size-target guides for 100KB portals."),
                    ("Merge then compress?", "Yes — common workflow for multi-document uploads."),
                    ("Pro tier?", "Unlimited daily use and 4 GB uploads."),
                    ("Secure?", "HTTPS; automatic deletion after download."),
                ];
    }
}
