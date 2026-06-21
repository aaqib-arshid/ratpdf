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
            var v = Math.Abs(StringComparer.Ordinal.GetHashCode(slug)) % 12;
            var product = ProductName(vertical);
            var intro = BuildIntro(vertical, intent, displayTitle, toolHref, product, v % 4);
            var body = vertical switch
            {
                PdfToolVertical.PdfToWord => WordBody(v % 3) + ExtraSection(vertical, slug, v),
                PdfToolVertical.EditPdf => EditBody(v % 3) + ExtraSection(vertical, slug, v),
                PdfToolVertical.CompressPdf => CompressBody(v % 3) + ExtraSection(vertical, slug, v),
                _ => "",
            };
            var workflow = BuildWorkflow(vertical, intent, toolHref);
            return intro + body + workflow;
        }

        public static IReadOnlyList<(string Question, string Answer)> BuildFaqs(
            PdfToolVertical vertical, IntentClassification intent, string toolHref, string slug)
        {
            var v = Math.Abs(StringComparer.Ordinal.GetHashCode(slug)) % 4;
            return vertical switch
            {
                PdfToolVertical.PdfToWord => WordFaqs(toolHref, v % 2),
                PdfToolVertical.EditPdf => EditFaqs(toolHref, v % 2),
                PdfToolVertical.CompressPdf => CompressFaqs(toolHref, v % 2),
                _ => [],
            };
        }

        private static string ExtraSection(PdfToolVertical vertical, string slug, int v) => (vertical, v / 3) switch
        {
            (PdfToolVertical.PdfToWord, 0) => """
                <h2>After conversion</h2>
                <p>Proofread headings and tables in Word before sending externally. For contracts, keep the original PDF archived.</p>
                """,
            (PdfToolVertical.PdfToWord, 1) => """
                <h2>File size tips</h2>
                <p>Large PDFs may need <a href="/pdf/split">Split PDF</a> on the free tier before upload. Pro supports up to 4 GB.</p>
                """,
            (PdfToolVertical.PdfToWord, 2) => """
                <h2>Related tools</h2>
                <p>Need plain text only? Use <a href="/pdf/pdftotext">PDF to Text</a>. Need spreadsheets? Try <a href="/pdf/pdftoexcel">PDF to Excel</a>.</p>
                """,
            (PdfToolVertical.PdfToWord, _) => """
                <h2>Quality check</h2>
                <p>Open the DOCX once and verify page breaks, footers, and merged cells before client delivery.</p>
                """,
            (PdfToolVertical.EditPdf, 0) => """
                <h2>Before sharing</h2>
                <p>Flatten interactive forms with <a href="/pdf/flattenpdf">Flatten PDF</a> so recipients cannot change field values.</p>
                """,
            (PdfToolVertical.EditPdf, 1) => """
                <h2>Mobile editing</h2>
                <p>RatPDF Edit PDF works in mobile Safari and Chrome — save to Files before uploading from iOS.</p>
                """,
            (PdfToolVertical.EditPdf, 2) => """
                <h2>Combine with security</h2>
                <p>Add a <a href="/pdf/watermark">watermark</a> for drafts or <a href="/pdf/password">password protect</a> before email.</p>
                """,
            (PdfToolVertical.EditPdf, _) => """
                <h2>Version control</h2>
                <p>Rename downloads with date and version (v2, v3) — browsers may overwrite files in Downloads.</p>
                """,
            (PdfToolVertical.CompressPdf, 0) => """
                <h2>Portal limits</h2>
                <p>Government and job portals often cap uploads at 100KB–2MB — see <a href="/research/attachment-size-limits">attachment size limits</a>.</p>
                """,
            (PdfToolVertical.CompressPdf, 1) => """
                <h2>When not to compress</h2>
                <p>Legal stamps and fine print may blur at High compression — try Recommended first, then split pages if still too large.</p>
                """,
            (PdfToolVertical.CompressPdf, 2) => """
                <h2>Email workflow</h2>
                <p>Compress before Gmail or Outlook upload — typical provider limits are 20–25 MB per attachment.</p>
                """,
            (PdfToolVertical.CompressPdf, _) => """
                <h2>Verify output</h2>
                <p>Zoom to 100% on signatures, MRZ lines, and table totals after compression before submitting.</p>
                """,
            _ => "",
        };

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
                2 => $"<p class=\"lead\">This guide covers <strong>{title}</strong>. Start at <a href=\"{toolHref}\">{product}</a> on ratpdf.com.</p>",
                _ => $"<p class=\"lead\"><strong>{title}</strong> — open <a href=\"{toolHref}\">{product}</a>, upload once, download in seconds. No install required.</p>",
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
