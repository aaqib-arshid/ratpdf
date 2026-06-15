using ratpdf.Models;

namespace ratpdf.Constants
{
    public static class VerticalPdfToolsCatalog
    {
        private static readonly Dictionary<string, VerticalPdfToolsPageModel> BySlug =
            Build().ToDictionary(p => p.Slug, StringComparer.OrdinalIgnoreCase);

        public static VerticalPdfToolsPageModel? Get(string slug) =>
            BySlug.GetValueOrDefault(slug);

        public static IEnumerable<VerticalPdfToolsPageModel> All => BySlug.Values;

        public static IEnumerable<string> SitemapPaths() =>
            BySlug.Values.Select(p => p.Path);

        private static IEnumerable<VerticalPdfToolsPageModel> Build()
        {
            yield return Page(
                "lawyers",
                "PDF Tools for Lawyers — Merge, Redact & Sign | RatPDF",
                "Free PDF tools for law firms: merge briefs, compress exhibits, password-protect discovery, add page numbers, and export to Word.",
                "PDF Tools for Lawyers",
                "Prepare court filings, client packets, and discovery exports without desktop software.",
                "Legal professionals",
                [
                    ("Merge PDF", "/pdf/merge", "Combine exhibits, appendices, and briefs in docket order."),
                    ("Protect PDF", "/pdf/password", "Encrypt privileged documents before email or portal upload."),
                    ("Sign PDF", "/pdf/signtext", "Add typed approval signatures to engagement letters."),
                    ("PDF to Word", "/pdf/pdftodoc", "Convert digital contracts to editable DOCX for markup."),
                    ("Add Page Numbers", "/pdf/pagenumbers", "Stamp bates-style footers on long record PDFs."),
                    ("Compress PDF", "/pdf/compress", "Meet e-filing and portal size limits."),
                ],
                [
                    "Merge multi-part briefs before e-filing",
                    "Password-protect discovery packets shared externally",
                    "Compress scanned exhibits under portal caps",
                    "Convert digital contracts to Word for redlines",
                ],
                [
                    ("Are these PDF tools secure for legal documents?", "Files upload over TLS, process on our servers, and temporary copies are deleted after download. See our trust center for retention details."),
                    ("Can I merge PDFs without losing bookmark structure?", "RatPDF uses smart merge that preserves vector text and embedded fonts in most digital PDFs."),
                    ("Is there a page limit on the free tier?", "Free users get 3 uses per tool per day with 200 MB per file. Pro supports 4 GB uploads and unlimited daily use."),
                ]);

            yield return Page(
                "students",
                "PDF Tools for Students — Merge Notes, Compress & Convert | RatPDF",
                "Free PDF tools for students: merge lecture slides, compress scans for LMS upload, convert PDF to Word, and OCR handwritten notes.",
                "PDF Tools for Students",
                "Submit assignments, combine readings, and shrink scans — all in the browser.",
                "Students & researchers",
                [
                    ("Merge PDF", "/pdf/merge", "Combine readings and assignment PDFs in one file."),
                    ("Compress PDF", "/pdf/compress", "Hit LMS and email upload limits."),
                    ("PDF to Word", "/pdf/pdftodoc", "Pull quotes from digital textbooks into essays."),
                    ("OCR PDF", "/pdf/ocrpdf", "Make scanned notes searchable."),
                    ("Split PDF", "/pdf/split", "Extract one chapter from a course pack."),
                    ("Images to PDF", "/pdf/convertimages", "Turn phone photos of notes into one PDF."),
                ],
                [
                    "Merge weekly readings before printing",
                    "Compress thesis chapters for university portals",
                    "OCR scanned lecture notes for search",
                    "Split one required chapter from a course pack",
                ],
                [
                    ("Is RatPDF free for students?", "Yes — 3 uses per tool per day on the free tier. No credit card required."),
                    ("Can I compress a PDF for Moodle or Canvas?", "Use Compress PDF with Medium or High presets to hit typical 20–50 MB LMS limits."),
                    ("Will PDF to Word work on scanned textbooks?", "Scanned pages become images in DOCX; run OCR PDF first for searchable text."),
                ]);

            yield return Page(
                "accountants",
                "PDF Tools for Accountants — Excel, Merge & Protect | RatPDF",
                "Free PDF tools for accountants: PDF to Excel for bank statements, merge audit workpapers, password-protect client files, and invoice PDFs.",
                "PDF Tools for Accountants",
                "Extract tables, bundle workpapers, and deliver client-ready PDFs securely.",
                "Accountants & bookkeepers",
                [
                    ("PDF to Excel", "/pdf/pdftoexcel", "Pull bank statement tables into spreadsheets."),
                    ("Merge PDF", "/pdf/merge", "Bundle workpapers and supporting schedules."),
                    ("Protect PDF", "/pdf/password", "Encrypt client financials before email."),
                    ("Invoice Generator", "/invoice/create", "Create GST and tax invoices with PDF export."),
                    ("Compress PDF", "/pdf/compress", "Email large audit PDFs reliably."),
                    ("PDF to Text", "/pdf/pdftotext", "Extract figures for reconciliation scripts."),
                ],
                [
                    "Convert bank PDF statements to Excel",
                    "Merge signed engagement letters with schedules",
                    "Password-protect year-end packages for clients",
                    "Generate GST invoices with instant PDF download",
                ],
                [
                    ("Can RatPDF extract tables from bank PDFs?", "Digital PDFs with lattice tables convert well; flat scans may need cleanup."),
                    ("Is there an invoice tool for GST?", "Yes — use our invoice generator at /invoice/create with India GST support."),
                    ("Are client files stored permanently?", "No — uploads are processed temporarily and deleted after download."),
                ]);
        }

        private static VerticalPdfToolsPageModel Page(
            string slug, string title, string description, string h1, string lead, string audience,
            (string, string, string)[] tools, string[] useCases, (string, string)[] faqs) =>
            new()
            {
                Slug = slug,
                Title = title,
                Description = description,
                H1 = h1,
                Lead = lead,
                AudienceLabel = audience,
                FeaturedTools = tools.Select(t => (t.Item1, t.Item2, t.Item3)).ToArray(),
                UseCases = useCases,
                Faqs = faqs,
            };
    }
}
