using ratpdf.Content;
using ratpdf.Models;

namespace ratpdf.Content
{
    public static class ContentLibrary
    {
        private static readonly Lazy<IReadOnlyList<ContentEntry>> Cache = new(BuildAll);

        public static IReadOnlyList<ContentEntry> All => Cache.Value;
        public static IEnumerable<ContentEntry> Guides => All.Where(e => e.Kind == ContentKind.Guide);
        public static IEnumerable<ContentEntry> Blogs => All.Where(e => e.Kind == ContentKind.Blog);

        public static ContentEntry? GetGuide(string slug) =>
            Guides.FirstOrDefault(g => g.Slug.Equals(slug, StringComparison.OrdinalIgnoreCase));

        public static ContentEntry? GetBlog(string slug) =>
            Blogs.FirstOrDefault(b => b.Slug.Equals(slug, StringComparison.OrdinalIgnoreCase));

        public static ContentEntry? GetGuideForToolUrl(string? toolUrl) =>
            string.IsNullOrEmpty(toolUrl)
                ? null
                : Guides.FirstOrDefault(g => string.Equals(g.ToolUrl, toolUrl, StringComparison.OrdinalIgnoreCase));

        public static IReadOnlyList<string> AllContentPaths() =>
            All.Select(e => e.Path).Distinct(StringComparer.OrdinalIgnoreCase).ToList();

        private static IReadOnlyList<ContentEntry> BuildAll()
        {
            var entries = new List<ContentEntry>();
            entries.AddRange(BuildGuides());
            entries.AddRange(BuildBlogs());
            return entries;
        }

        private static IEnumerable<ContentEntry> BuildGuides()
        {
            var meta = new (string Slug, string Title, string Desc, string Cat, string? Tool, string[]? Fq, string[]? Fa)[]
            {
                ("compress-pdf-guide", "How to Compress PDF Online Without Losing Quality", "Step-by-step PDF compression: Ghostscript levels, DPI trade-offs, email size limits, and when to merge before compressing.", "PDF", "/PDF/Compress",
                    ["What compression level should I use?", "Will compression remove text?"],
                    ["Medium for most email; Low for legal PDFs; High for strict portal caps.", "No — text stays vector; images are re-encoded."]),
                ("merge-pdf", "How to Merge PDF Files Online — Complete Guide", "Combine multiple PDFs in order without blurring logos. iText smart merge, reorder tips, and post-merge compression.", "PDF", "/PDF/Merge", null, null),
                ("split-pdf", "How to Split PDF Pages — Extract Ranges Online", "Extract pages by range, split scans into receipts, and share only signature pages from long contracts.", "PDF", "/PDF/Split", null, null),
                ("pdf-to-word", "PDF to Word Conversion Guide — Keep Tables & Logos", "Why converters fail on invoices and scans. pdf2docx, OCR, and page-render fallbacks explained.", "PDF", "/PDF/PdfToDoc",
                    ["Can scanned PDFs become editable Word?", "Will tables survive conversion?"],
                    ["Scanned PDFs become high-res page images or OCR text depending on the file.", "Digital PDFs with real tables usually convert; flat scans may need manual cleanup."]),
                ("word-to-pdf", "Word to PDF — Preserve Fonts, Tables & Print Layout", "Export DOCX to print-ready PDF with LibreOffice. Embed fonts, print areas, and tender submission tips.", "PDF", "/PDF/DocToPdf", null, null),
                ("pdf-to-excel", "PDF to Excel — Extract Tables to Spreadsheets", "Pull bank statements and GST tables into Excel. Lattice detection vs scanned PDF limitations.", "PDF", "/PDF/PdfToExcel", null, null),
                ("excel-to-pdf", "Excel to PDF — Print-Accurate Spreadsheet Export", "Share read-only financial PDFs. Print areas, wide sheet scaling, and chart preservation.", "PDF", "/PDF/ExcelToPdf", null, null),
                ("edit-pdf", "Edit PDF Online — Add Text, Images & Annotations", "Quick browser edits without Acrobat. Best use cases and when to use watermark or password tools instead.", "PDF", "/PDF/EditPDF", null, null),
                ("pdf-txt-guide", "Extract Text from PDF — OCR & Digital PDFs", "Get clean text from digital PDFs and scans. UTF-8 output, OCR limits, and when to use PDF to Word.", "PDF", "/PDF/PdfToText", null, null),
                ("text-to-pdf", "Text to PDF — Convert Plain Notes to PDF", "Archive memos and meeting notes as PDF. Formatting tips and watermarking drafts.", "PDF", "/PDF/TextToPdf", null, null),
                ("watermark-pdf", "Add Watermark to PDF — Draft & Confidential Marks", "Diagonal watermarks for drafts, samples, and confidential packs. Combine with password protection.", "PDF", "/PDF/Watermark", null, null),
                ("password-protect-pdf", "Password Protect PDF — Encryption Guide", "Encrypt sensitive PDFs before email. Password length, sharing hygiene, and recovery limits.", "PDF", "/PDF/Password", null, null),
                ("sign-pdf", "Sign PDF with Text — Business Approval Workflow", "Add typed signature blocks to quotes and SOWs. Difference vs qualified e-signatures.", "PDF", "/PDF/SignText", null, null),
                ("rotate-pdf", "Rotate PDF Pages — Fix Scan Orientation", "Fix 90°/180° scans without re-scanning. Rotate vs remove blank pages.", "PDF", "/PDF/RotateOrRemove", null, null),
                ("images-to-pdf", "Convert Images to PDF — JPG, PNG, WEBP", "Combine receipts and photos into one PDF. Sort order, compression, and margin tips.", "PDF", "/PDF/ConvertImages", null, null),
                ("background-remover", "Remove Image Background Online — Free Guide", "AI cutouts for e-commerce and headshots. When it works, PNG export, and catalogue PDFs.", "Image", "/Tools/ImgBackgroundRemove", null, null),
                ("word-counter-guide", "Word Counter Guide — SEO, Essays & Reading Time", "Count words and characters for meta tags, academic limits, and content depth.", "Writing", "/Tools/WordCounter", null, null),
                ("ring-size-converter-guide", "Ring Size Conversion — US, UK, EU & India", "Measure finger size at home and convert international ring sizes before buying online.", "Lifestyle", "/Tools/RingSizeConverter", null, null),
                ("my-ip-guide", "What Is My IP Address? — Public IP Explained", "Find public IPv4/IPv6, whitelist office IPs, and troubleshoot VPN visibility.", "Network", "/Tools/WhatIsMyIP", null, null),
                ("invoice-generator-guide", "Free Invoice Generator — GST, PDF & Templates", "Create professional tax invoices with line items, logos, and instant PDF download.", "Business", "/Invoice/Create", null, null),
                ("unlock-pdf", "Unlock PDF Online — Remove Password Protection", "Remove PDF passwords when you know the passphrase. Owner vs user locks, legal use, and post-unlock workflows.", "PDF", "/PDF/UnlockPdf",
                    ["Can I unlock a PDF without the password?", "Will unlocking reduce quality?"],
                    ["No — RatPDF requires the correct password; we do not crack encryption.", "No — only the encryption wrapper is removed; page content stays identical."]),
                ("flatten-pdf", "Flatten PDF Forms — Lock Field Values", "Merge fillable form fields and annotations into flat page content before portal uploads.", "PDF", "/PDF/FlattenPdf", null, null),
                ("pdf-to-images", "PDF to PNG — Export Pages as Images", "Render PDF pages to PNG at 150–300 DPI. ZIP download for slides, thumbnails, and design handoffs.", "PDF", "/PDF/PdfToImages", null, null),
                ("extract-images-from-pdf", "Extract Images from PDF — Embedded Photos", "Pull embedded bitmaps (logos, product shots) from PDFs without full-page screenshots.", "PDF", "/PDF/ExtractImages", null, null),
                ("ocr-pdf", "OCR PDF — Make Scanned Documents Searchable", "Add a Tesseract text layer to image PDFs. Scan tips, accuracy, and follow-up conversion tools.", "PDF", "/PDF/OcrPdf", null, null),
                ("add-page-numbers", "Add Page Numbers to PDF — Footer Format", "Stamp Page {page} of {total} footers on reports and manuals. Tokens, margins, and merge-first tips.", "PDF", "/PDF/PageNumbers", null, null),
                ("pdf-metadata", "PDF Metadata Viewer — Document Properties", "Inspect title, author, dates, and page count. JSON export for audits and ECM migration.", "PDF", "/PDF/PdfMetadata", null, null),
            };

            foreach (var m in meta)
            {
                var body = GuideBodies.Get(m.Slug);
                if (body == null) continue;
                yield return new ContentEntry
                {
                    Slug = m.Slug,
                    Title = m.Title,
                    Description = m.Desc,
                    Category = m.Cat,
                    ToolUrl = m.Tool,
                    BodyHtml = body,
                    Published = new DateTime(2025, 6, 1),
                    Kind = ContentKind.Guide,
                    FaqQuestions = m.Fq,
                    FaqAnswers = m.Fa,
                };
            }
        }

        private static IEnumerable<ContentEntry> BuildBlogs()
        {
            var meta = new (string Slug, string Title, string Desc, string Cat)[]
            {
                ("send-large-pdf-email", "How to Email Large PDF Files (Over 25 MB)", "Compress, split, or restructure PDFs when email providers reject oversized attachments.", "PDF"),
                ("pdf-vs-word-when-to-convert", "PDF vs Word: When to Convert (and When Not To)", "Decide whether recipients need editable DOCX or locked PDF for contracts and marketing.", "PDF"),
                ("small-business-pdf-workflow", "PDF Workflow for Small Business — No IT Team Needed", "Invoice, merge, compress, and protect — a minimal toolchain for freelancers and SMBs.", "Business"),
                ("scanned-documents-office-tips", "Scanning Documents for the Office — DPI & OCR Tips", "Capture settings that reduce file size and improve OCR before PDF to Word.", "PDF"),
                ("gst-invoice-pdf-checklist", "GST Invoice PDF Checklist for Indian Businesses", "Mandatory fields, ITC requirements, and archival practices for compliant PDF invoices.", "Business"),
                ("secure-pdf-password-best-practices", "PDF Password Security — Do's and Don'ts", "Strong passphrases, channel separation, and limits of visual watermarks.", "Security"),
                ("choose-pdf-compression-level", "Which PDF Compression Level Should You Choose?", "Low vs medium vs high — decision tree for legal, email, and portal uploads.", "PDF"),
                ("merge-pdf-without-quality-loss", "Merge PDF Without Losing Quality", "Why some merge tools blur logos and how vector-preserving merge works.", "PDF"),
            };

            var published = new DateTime(2025, 5, 15);
            foreach (var m in meta)
            {
                var body = BlogBodies.Get(m.Slug);
                if (body == null) continue;
                yield return new ContentEntry
                {
                    Slug = m.Slug,
                    Title = m.Title,
                    Description = m.Desc,
                    Category = m.Cat,
                    ToolUrl = null,
                    BodyHtml = body,
                    Published = published,
                    Kind = ContentKind.Blog,
                };
                published = published.AddDays(4);
            }
        }
    }
}
