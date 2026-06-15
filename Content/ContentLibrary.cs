using ratpdf.Content;
using ratpdf.Constants;
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
                ("sign-pdf-legally", "Sign PDF Legally — Typed Signatures, E-Sign & Compliance", "When typed PDF signatures are enough for business, and when you need qualified e-signatures under eIDAS, ESIGN, or local law.", "PDF", "/PDF/SignText",
                    ["Is a typed name on a PDF legally binding?", "Do I need DocuSign instead of RatPDF?"],
                    ["Often yes for routine B2B contracts when combined with email evidence — but high-value or regulated deals may need qualified e-signatures or wet ink.", "Use dedicated platforms for audit trails and QES; RatPDF typed signatures suit internal approvals and many freelancer workflows."]),
                ("watermark-vs-password-pdf", "Watermark vs Password on PDF — When to Use Each", "Watermarks mark status visually; passwords encrypt content. Learn when to use DRAFT labels, encryption, or both.", "PDF", null,
                    ["Can a watermark replace a password?", "Should I watermark and password the same PDF?"],
                    ["No — watermarks are visible only and do not encrypt. Anyone who opens the file can still copy content.", "Yes for sensitive drafts: watermark for status during review, then password-protect the final before external sharing."]),
                ("rotate-pdf", "Rotate PDF Pages — Fix Scan Orientation", "Fix 90°/180° scans without re-scanning. Rotate vs remove blank pages.", "PDF", "/PDF/RotateOrRemove", null, null),
                ("images-to-pdf", "Convert Images to PDF — JPG, PNG, WEBP", "Combine receipts and photos into one PDF. Sort order, compression, and margin tips.", "PDF", "/PDF/ConvertImages", null, null),
                ("background-remover", "Remove Image Background in Browser — No Upload, 100% Private", "AI background removal runs entirely in your browser with ONNX — images never leave your device. Transparent PNG export at full resolution.", "Image", "/tools/imgbackgroundremove",
                    ["Does the background remover upload my photos?", "Does it work offline?"],
                    ["No — segmentation runs locally in your browser; files are not sent to RatPDF servers.", "You need an internet connection once to load the page and model; processing happens on-device after that."]),
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
                ("pdf-tool-alternatives", "Best PDF Tool Alternatives — iLovePDF, Smallpdf & Adobe Compared", "Honest comparison of top PDF sites vs RatPDF: free limits, security, schema-rich guides, and migration checklist.", "PDF", null,
                    ["What is the best iLovePDF alternative?", "Is RatPDF better than Smallpdf for daily use?"],
                    ["RatPDF — one site for merge, compress, convert, sign, and invoice PDFs with transparent free limits.", "Smallpdf limits free users to 2 tasks/day; RatPDF offers 3 uses per tool with a full comparison at /compare."]),
                ("pdf-to-powerpoint", "PDF to PowerPoint — Convert Pages to Editable Slides", "Turn PDF decks and reports into PPTX slides. Page-to-slide mapping, LibreOffice import, and presentation tips.", "PDF", "/pdf/pdftoppt",
                    ["Can I edit text after PDF to PPT?", "Will slide aspect ratio match my PDF?"],
                    ["Image-heavy PDFs become one slide per page — ideal for presenting archived decks; digital PDFs may import as editable objects via LibreOffice.", "RatPDF preserves page aspect ratio when building slides."]),
                ("powerpoint-to-pdf", "PowerPoint to PDF — Export Slides for Print & Email", "Convert PPTX to print-ready PDF with LibreOffice Impress. Font embedding, slide size, and tender submission tips.", "PDF", "/pdf/ppttopdf", null, null),
                ("html-to-pdf", "HTML to PDF — Convert Web Pages & Templates", "Render HTML, email templates, and saved .html files as PDF with iText html2pdf and Unicode font support.", "PDF", "/pdf/htmltopdf", null, null),
                ("pdf-to-markdown", "PDF to Markdown — Export Docs for Git & Notion", "Extract PDF text into .md files with page sections for GitHub, Obsidian, and static site workflows.", "PDF", "/pdf/pdftomarkdown", null, null),
                ("pdf-redaction", "PDF Redaction — Permanently Remove Sensitive Text", "True redaction vs black boxes. When to redact, legal disclosure workflows, and verification steps.", "PDF", "/pdf-redaction",
                    ["Is black marker redaction secure?", "Can redacted PDFs be recovered?"],
                    ["No — visual black boxes often leave copyable text underneath. Use permanent redaction.", "Proper redaction removes content from the PDF object stream; always verify with search after export."]),
                ("compress-pdf-email-limits", "Compress PDF for Email — Attachment Size Guide", "Fit PDFs under Gmail, Outlook, and portal limits. Compression levels, split fallback, and size checker tool.", "PDF", "/pdf/compress", null, null),
                ("pdf-tools-for-lawyers", "PDF Tools for Lawyers — Merge, Redact, Convert & File", "Curated legal PDF workflow: exhibit merge, redaction, e-filing compression, and PDF to Word for redlines.", "PDF", "/pdf-tools-for-lawyers", null, null),
                ("pdf-tools-for-accountants", "PDF Tools for Accountants — Statements, GST & Reports", "Bank PDF to Excel, invoice PDFs, board pack export, and GST compliance checkers for finance teams.", "PDF", "/pdf-tools-for-accountants", null, null),
                ("pdf-tools-for-students", "PDF Tools for Students — Merge Readings, OCR & Citations", "Merge lecture PDFs, OCR scans for search, PDF to Word/Markdown for essays and research notes.", "PDF", "/pdf-tools-for-students", null, null),
                ("choose-pdf-tool", "How to Choose a PDF Tool — 2026 Buyer Guide", "Compare free limits, file caps, security, and toolkit breadth. Links to RatPDF vs iLovePDF, Smallpdf, Adobe, and more.", "PDF", "/compare",
                    ["What is the best free PDF tool?", "RatPDF vs Adobe Acrobat Online?"],
                    ["Depends on daily volume and file size — see our comparison hub for feature tables.", "RatPDF is browser-only with 3 free uses per tool; Adobe requires account and has stricter free limits."]),
                // Medical calculators
                ("bmi-calculator-guide", "BMI Calculator Guide — WHO Categories & Clinical Use", "Calculate body mass index from height and weight. WHO categories, limitations for athletes, and when to use BMI in screening.", "Medical", "/bmi-calculator", null, null),
                ("egfr-calculator-guide", "eGFR Calculator Guide — CKD Staging & Kidney Function", "Estimate glomerular filtration rate from creatinine, age, and sex. CKD staging bands and clinical correlation tips.", "Medical", "/egfr-calculator", null, null),
                ("heart-score-guide", "HEART Score Guide — Chest Pain Risk Stratification", "Calculate HEART score for emergency chest pain patients. Components, MACE risk bands, and shared decision-making.", "Medical", "/heart-score", null, null),
                ("cha2ds2-vasc-guide", "CHA₂DS₂-VASc Guide — Stroke Risk in Atrial Fibrillation", "Score stroke risk in AF patients for anticoagulation discussions. Pair with HAS-BLED for bleeding risk.", "Medical", "/cha2ds2-vasc-score", null, null),
                ("wells-score-guide", "Wells Score Guide — DVT and PE Pre-Test Probability", "Calculate Wells criteria for deep vein thrombosis and pulmonary embolism. Low vs high risk pathways.", "Medical", "/wells-score", null, null),
                ("medical-calculators-guide", "Medical Calculators Hub — Free Clinical Scores Online", "BMI, eGFR, HEART, CHA₂DS₂-VASc, Wells, GCS, MAP, and more — browser-based calculators for education and documentation.", "Medical", "/tools/medical", null, null),
                // Image tools
                ("image-compressor-guide", "Image Compressor Guide — Reduce JPG & PNG Size", "Compress images for web, email, and PDF workflows. Quality trade-offs and when to compress after background removal.", "Image", "/pdf/imagecompressor", null, null),
                ("image-resizer-guide", "Image Resizer Guide — Scale Photos to Exact Pixels", "Resize JPG, PNG, and WEBP without desktop software. Aspect ratio, downscaling, and social crop tips.", "Image", "/image-resizer", null, null),
                ("image-format-converter-guide", "Image Format Converter — JPG, PNG, WEBP", "Convert between common image formats for CMS uploads, email attachments, and transparent PNG workflows.", "Image", "/image-format-converter", null, null),
                ("bulk-image-compressor-guide", "Bulk Image Compressor — Compress Many Photos at Once", "Batch-compress product photos and documentation images. QA tips and catalogue PDF workflows.", "Image", "/bulk-image-compressor", null, null),
                // Developer tools
                ("json-formatter-guide", "JSON Formatter Guide — Pretty-Print & Validate JSON", "Format API responses and config files. Spot syntax errors before deploy and pair with text diff tools.", "Developer", "/pdf/jsonformatter", null, null),
                ("jwt-decoder-guide", "JWT Decoder Guide — Inspect Token Claims Safely", "Decode JSON Web Token header and payload. exp, iss, aud claims and why decoding is not verification.", "Developer", "/pdf/jwtdecoder", null, null),
                ("html-formatter-guide", "HTML Formatter Guide — Beautify Markup for Review", "Indent HTML templates and CMS fragments for readable diffs before HTML-to-PDF export.", "Developer", "/pdf/htmlformatter", null, null),
                ("text-comparer-guide", "Text Comparer Guide — Diff Two Text Blocks Online", "Side-by-side text diff for config changes, contract redlines, and JSON before/after formatting.", "Developer", "/text-comparer", null, null),
                ("url-encoder-guide", "URL Encoder Guide — Percent-Encoding Query Strings", "Encode and decode URL parameters safely for OAuth redirects, analytics tags, and API links.", "Developer", "/url-encoder", null, null),
                ("binary-converter-guide", "Binary Converter Guide — Binary ↔ Decimal", "Convert between binary and decimal for networking homework, subnet masks, and embedded register docs.", "Developer", "/binary-to-decimal", null, null),
                ("dns-lookup-guide", "DNS Lookup Guide — A, MX, TXT Records", "Query DNS for email migration, domain verification, and CDN cutover troubleshooting.", "Developer", "/tools/dnslookup", null, null),
                ("img-to-base64-guide", "Image to Base64 Guide — Data URLs for HTML & APIs", "Convert small images to Base64 data URIs for HTML email and JSON payloads. Size inflation warnings.", "Developer", "/pdf/imgtobase64", null, null),
                ("developer-tools-guide", "Developer Tools Hub — JSON, JWT, HTML & DNS Utilities", "Free browser utilities for JSON formatting, JWT decoding, HTML beautification, text diff, URL encoding, and DNS lookup.", "Developer", "/tools/developer", null, null),
            };

            foreach (var m in meta)
            {
                var body = GuideBodies.Get(m.Slug);
                if (body == null) continue;
                var (author, reviewer) = SiteAuthors.ResolveForContent(m.Slug, m.Cat);
                yield return new ContentEntry
                {
                    Slug = m.Slug,
                    Title = m.Title,
                    Description = m.Desc,
                    Category = m.Cat,
                    ToolUrl = m.Tool,
                    BodyHtml = body,
                    Published = new DateTime(2025, 6, 1),
                    LastReviewed = new DateTime(2026, 1, 15),
                    Kind = ContentKind.Guide,
                    AuthorSlug = author,
                    ReviewerSlug = reviewer,
                    Sources = ContentSourcesCatalog.GetForSlug(m.Slug),
                    FaqQuestions = m.Fq,
                    FaqAnswers = m.Fa,
                    HowToSteps = GuideHowToSteps.Get(m.Slug)?.ToArray(),
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
                ("free-vs-paid-pdf-tools-2026", "Free vs Paid PDF Tools — When to Upgrade in 2026", "Daily limits, file size caps, and ROI of Pro tiers for agencies and legal teams.", "PDF"),
                ("pdf-editing-mistakes", "5 PDF Editing Mistakes That Cause Compliance Problems", "Scanned PDF edits, fake redaction, and losing source files — avoid these errors.", "PDF"),
                ("remote-work-pdf-security", "Remote Work PDF Security — Policies That Actually Work", "Password hygiene, watermark review cycles, and safe sharing from home offices.", "Security"),
                ("powerpoint-from-pdf-tips", "PDF to PowerPoint — Tips for Editable Slide Decks", "Page-as-slide expectations, OCR for scans, and round-trip PDF export.", "PDF"),
                ("html-to-pdf-developers", "HTML to PDF for Developers — CSS & Font Pitfalls", "Inline CSS, @page rules, and when to use browser tools vs server libraries.", "Developer"),
                ("pdf-redaction-vs-password", "PDF Redaction vs Password — Which Control Do You Need?", "Encryption, watermarks, and permanent redaction explained for legal and HR teams.", "Security"),
                ("accountant-pdf-workflow", "Accountant PDF Workflow — Month-End Close Checklist", "Statement extraction, board packs, merge, and email-safe compression.", "Business"),
                ("ilovepdf-vs-smallpdf-vs-ratpdf", "iLovePDF vs Smallpdf vs RatPDF — 2026 Comparison", "Three-way feature table: free limits, uploads, invoice tools, and compare depth.", "PDF"),
                ("browser-background-remover-privacy", "Browser Background Remover — Why On-Device AI Matters", "How client-side ONNX segmentation keeps product photos and headshots off third-party servers.", "Image"),
                ("json-formatter-api-debugging", "JSON Formatter for API Debugging — Workflow Tips", "Pretty-print webhook payloads, compare diffs, and validate config before production deploys.", "Developer"),
                ("jwt-decoder-oauth-integration", "JWT Decoder for OAuth Integration — Claims Checklist", "Inspect exp, iss, aud, and scope claims during SSO and API token debugging.", "Developer"),
                ("medical-calculator-clinical-documentation", "Medical Calculators in Clinical Documentation", "When to document BMI, eGFR, and risk scores in notes — educational use and disclaimer boundaries.", "Medical"),
            };

            var published = new DateTime(2025, 5, 15);
            foreach (var m in meta)
            {
                var body = BlogBodies.Get(m.Slug);
                if (body == null) continue;
                var (author, reviewer) = SiteAuthors.ResolveForContent(m.Slug, m.Cat);
                yield return new ContentEntry
                {
                    Slug = m.Slug,
                    Title = m.Title,
                    Description = m.Desc,
                    Category = m.Cat,
                    ToolUrl = null,
                    BodyHtml = body,
                    Published = published,
                    LastReviewed = new DateTime(2026, 1, 15),
                    Kind = ContentKind.Blog,
                    AuthorSlug = author,
                    ReviewerSlug = reviewer,
                    Sources = ContentSourcesCatalog.GetForSlug(m.Slug),
                };
                published = published.AddDays(4);
            }
        }
    }
}
