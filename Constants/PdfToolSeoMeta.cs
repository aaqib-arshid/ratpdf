using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace ratpdf.Constants
{
    /// <summary>Title, description, H1, lead, and FAQ schema data per PDF tool.</summary>
    public sealed record PdfToolSeoMetaEntry(
        string ToolId,
        string Title,
        string Description,
        string H1,
        string Lead,
        string ToolPath,
        string AppName,
        string AppDescription,
        (string Question, string Answer)[] Faqs);

    public static class PdfToolSeoMeta
    {
        private static readonly Dictionary<string, PdfToolSeoMetaEntry> ById =
            new(StringComparer.OrdinalIgnoreCase)
            {
                [PdfToolIds.UnlockPdf] = new(
                    PdfToolIds.UnlockPdf,
                    "Unlock PDF Online Free — Remove Password Protection",
                    "Remove PDF password protection online. Decrypt owner and user passwords securely. Free 200 MB, Pro 4 GB. No software install.",
                    "Unlock PDF Online — Remove Password Protection",
                    "Decrypt password-protected PDFs in your browser. Enter the known password and download an unlocked copy — content, fonts, and layout preserved.",
                    "/pdf/unlockpdf",
                    "Unlock PDF",
                    "Remove PDF password protection online. Decrypt protected PDFs securely with RatPDF.",
                    [
                        ("How do I unlock a password-protected PDF online?",
                            "Upload the PDF, enter the correct password, and click Unlock PDF. The decrypted file downloads when processing completes."),
                        ("Can I unlock a PDF without knowing the password?",
                            "No. RatPDF only removes protection when you supply the valid password. We do not crack or bypass encryption."),
                        ("Is unlocking PDFs free?",
                            "Yes — free users get 3 unlocks per day up to 200 MB per file. Pro supports unlimited use and 4 GB uploads."),
                        ("Will unlocking change PDF quality?",
                            "No. Unlocking removes encryption wrappers only; pages, images, and vector text stay identical."),
                    ]),

                [PdfToolIds.FlattenPdf] = new(
                    PdfToolIds.FlattenPdf,
                    "Flatten PDF Online Free — Merge Form Fields & Annotations",
                    "Flatten PDF forms and annotations into non-editable page content. Ideal for contracts, tax forms, and signed submissions. Up to 4 GB on Pro.",
                    "Flatten PDF Online — Lock Form Fields & Annotations",
                    "Merge interactive form fields, signatures, and markup into the page layer so recipients cannot edit fields after submission.",
                    "/PDF/FlattenPdf",
                    "Flatten PDF",
                    "Flatten PDF forms and annotations into a non-editable document online.",
                    [
                        ("What does flattening a PDF do?",
                            "Flattening burns form field values and annotations into the page content so they cannot be changed in Acrobat or browser viewers."),
                        ("When should I flatten a PDF?",
                            "Before sending completed tax forms, signed applications, or HR packets where field values must not be altered."),
                        ("Does flattening reduce file size?",
                            "Sometimes slightly, because interactive form structures are removed. Visual appearance stays the same."),
                        ("Is flatten PDF free?",
                            "Yes on the free tier (3 uses/day, 200 MB). Pro removes daily limits and supports 4 GB files."),
                    ]),

                [PdfToolIds.SignPdf] = new(
                    PdfToolIds.SignPdf,
                    "Sign PDF Online Free — Type, Draw, or Upload Signature",
                    "Sign PDF documents online. Type your name, draw on canvas, or upload a signature image. Choose page and position. Free 200 MB.",
                    "Sign PDF Online — Type, Draw, or Upload",
                    "Add a visual signature to contracts, forms, and agreements. Pick last page, first page, or all pages — with optional date stamp.",
                    "/pdf/signtext",
                    "Sign PDF",
                    "Sign PDF documents online by typing, drawing, or uploading your signature image.",
                    [
                        ("How do I sign a PDF online for free?",
                            "Upload your PDF, choose Type, Draw, or Upload image, set page and position, then click Sign PDF to download."),
                        ("Is this a legal digital signature?",
                            "RatPDF adds a visual signature block — not a certificate-based digital signature with audit trail. Many informal agreements accept typed or drawn signatures."),
                        ("Can I sign on mobile?",
                            "Yes — use the Draw tab with your finger or stylus on phones and tablets."),
                        ("Can I add a date with my signature?",
                            "Yes — enable Add date below signature before processing."),
                    ]),

                [PdfToolIds.Watermark] = new(
                    PdfToolIds.Watermark,
                    "Watermark PDF Online Free — Text or Image Overlay",
                    "Add text or image watermarks to PDF pages. Adjust opacity, rotation, tiled layout, and page range. DRAFT and CONFIDENTIAL presets.",
                    "Watermark PDF — Text or Logo Overlay",
                    "Mark drafts, confidential reports, and brand documents with diagonal text or a logo watermark. Control opacity and which pages are stamped.",
                    "/pdf/watermark",
                    "Watermark PDF",
                    "Add customizable text or image watermarks to PDF documents online.",
                    [
                        ("How do I watermark a PDF online?",
                            "Upload the PDF, enter text or upload a logo, adjust opacity and layout, then click Add Watermark."),
                        ("Can I watermark only some pages?",
                            "Yes — choose first page only or enter a custom page range."),
                        ("Can I use my company logo as a watermark?",
                            "Yes — switch to Image / logo and upload a PNG or JPG with adjustable opacity."),
                        ("Will the watermark block reading the PDF?",
                            "Default opacity is light enough to read content underneath. Increase opacity for stronger DRAFT or CONFIDENTIAL marks."),
                    ]),

                [PdfToolIds.PdfToImages] = new(
                    PdfToolIds.PdfToImages,
                    "PDF to PNG Online Free — Export PDF Pages as Images",
                    "Convert PDF pages to high-quality PNG images. Download all pages as a ZIP archive. Adjustable DPI. Free 200 MB, Pro 4 GB.",
                    "PDF to Images — Export Every Page as PNG",
                    "Render each PDF page to a crisp PNG and download them in one ZIP — perfect for slides, thumbnails, social posts, and design handoffs.",
                    "/PDF/PdfToImages",
                    "PDF to Images",
                    "Convert PDF pages to PNG images and download as ZIP online.",
                    [
                        ("How do I convert PDF to PNG online?",
                            "Upload your PDF, choose DPI if prompted, and click Export Images. Pages are rendered server-side and packaged into a ZIP."),
                        ("What image format is used?",
                            "RatPDF exports PNG files — lossless quality ideal for diagrams, screenshots, and text-heavy pages."),
                        ("Can I convert a large PDF to images?",
                            "Free tier supports 200 MB files; Pro supports up to 4 GB with background job processing."),
                        ("What DPI should I use?",
                            "150 DPI is fine for web and email; use 300 DPI for print-quality archival exports."),
                    ]),

                [PdfToolIds.ExtractImages] = new(
                    PdfToolIds.ExtractImages,
                    "Extract Images from PDF Online Free — Download Embedded Photos",
                    "Extract embedded images from PDF files into a ZIP download. Photos, logos, and diagrams preserved. Large-file safe pipeline.",
                    "Extract Images from PDF — Download Embedded Photos",
                    "Pull every embedded bitmap out of a PDF — logos, product photos, scanned figures — without re-screenshotting pages.",
                    "/PDF/ExtractImages",
                    "Extract Images from PDF",
                    "Extract embedded images from PDF files into a ZIP download online.",
                    [
                        ("How do I extract pictures from a PDF?",
                            "Upload the PDF and click Extract Images. RatPDF finds embedded image objects and returns them in a ZIP archive."),
                        ("Will extracted images match original quality?",
                            "Yes when the PDF stores full-resolution embeds. Heavily compressed PDFs may contain downscaled images."),
                        ("Does this work on scanned PDFs?",
                            "Scanned pages are usually one image per page — use PDF to Images if you need page renders instead of raw embeds."),
                        ("Is image extraction free?",
                            "Yes — 3 extractions per day on free tier; Pro adds unlimited use and 4 GB uploads."),
                    ]),

                [PdfToolIds.OcrPdf] = new(
                    PdfToolIds.OcrPdf,
                    "OCR PDF Online Free — Make Scanned PDFs Searchable",
                    "OCR scanned PDFs and add a searchable text layer with Tesseract. Find words in image-based documents. Pro supports 4 GB files.",
                    "OCR PDF Online — Add Searchable Text to Scans",
                    "Turn image-only PDFs into searchable documents. Copy text, find keywords, and pass accessibility checks without re-scanning.",
                    "/PDF/OcrPdf",
                    "OCR PDF",
                    "OCR scanned PDFs and add a searchable text layer online with Tesseract.",
                    [
                        ("What is PDF OCR?",
                            "OCR (Optical Character Recognition) reads text in scanned images and adds an invisible searchable text layer behind the page."),
                        ("Will OCR change how my PDF looks?",
                            "No — the visual page stays the same. Only a hidden text layer is added for search and copy."),
                        ("What languages does OCR support?",
                            "Tesseract supports dozens of languages; accuracy is best on clean 300 DPI scans with horizontal text."),
                        ("Can I OCR a PDF before converting to Word?",
                            "Yes — OCR first for searchable PDFs, then use PDF to Word for editable DOCX output."),
                    ]),

                [PdfToolIds.PageNumbers] = new(
                    PdfToolIds.PageNumbers,
                    "Add Page Numbers to PDF Online Free — Footer Numbering",
                    "Add page numbers to PDF footers with custom format. Use {page} and {total} placeholders. Free online, Pro 4 GB.",
                    "Add Page Numbers to PDF — Custom Footer Format",
                    "Stamp consistent footer numbering on reports, manuals, and court filings. Customize the label with {page} and {total} tokens.",
                    "/PDF/PageNumbers",
                    "Add Page Numbers to PDF",
                    "Add page numbers to PDF documents online with custom footer format.",
                    [
                        ("How do I add page numbers to a PDF?",
                            "Upload the PDF, set a format like Page {page} of {total}, and click Add Numbers. Footer text is applied to every page."),
                        ("Can I change the numbering format?",
                            "Yes — edit the format field. {page} is the current page; {total} is the page count."),
                        ("Will numbering overlap existing footer text?",
                            "Numbers are placed in the footer margin. Review the output if your PDF already has bottom-edge content."),
                        ("Is adding page numbers free?",
                            "Yes on the free tier (3/day, 200 MB). Pro supports unlimited numbering on files up to 4 GB."),
                    ]),

                [PdfToolIds.PdfMetadata] = new(
                    PdfToolIds.PdfMetadata,
                    "PDF Metadata Viewer Online — Title, Author, Page Count",
                    "View PDF metadata: title, author, creator, page count, and document properties. JSON export via secure job pipeline.",
                    "PDF Metadata Viewer — Inspect Document Properties",
                    "Audit PDF document info before archiving or compliance review. Export title, author, dates, and page count as JSON.",
                    "/PDF/PdfMetadata",
                    "PDF Metadata Viewer",
                    "View PDF metadata including title, author, page count, and document properties online.",
                    [
                        ("What PDF metadata can I see?",
                            "Title, author, subject, creator application, creation and modification dates, page count, and common document flags."),
                        ("Why check PDF metadata?",
                            "Verify authorship before legal submission, strip sensitive creator fields, or confirm page counts in batch archives."),
                        ("Is metadata extraction secure?",
                            "Files upload over HTTPS, process on our servers, and temporary copies are deleted after download."),
                        ("Can I export metadata as JSON?",
                            "Yes — the tool returns structured JSON you can save or pipe into audit scripts."),
                    ]),

                [PdfToolIds.RepairPdf] = new(
                    PdfToolIds.RepairPdf,
                    "Repair PDF Online Free — Fix Corrupt & Unreadable Files",
                    "Repair damaged PDF files online. Rebuild broken structure when Acrobat or browsers won't open the document. Free 200 MB, Pro 4 GB.",
                    "Repair PDF Online — Fix Corrupt Files",
                    "Upload a PDF that won't open, shows blank pages, or throws xref errors. We rebuild the file structure and return a readable copy when recovery is possible.",
                    "/pdf/repair",
                    "Repair PDF",
                    "Repair corrupt or damaged PDF files online with RatPDF.",
                    [
                        ("What kinds of PDF damage can be repaired?",
                            "Common xref table errors, truncated downloads, and structural corruption that still leaves page data recoverable."),
                        ("Will repair always work?",
                            "No. Severely corrupted files or encrypted PDFs without passwords may not be recoverable. Try Unlock PDF first if password protection is the issue."),
                        ("Is repair the same as compress?",
                            "No. Repair focuses on readability, not file size. Use Compress PDF after repair if you need a smaller file."),
                        ("Is repair PDF free?",
                            "Yes — free users get 3 repairs per day up to 200 MB per file. Pro supports unlimited use and 4 GB uploads."),
                    ]),

                [PdfToolIds.SummarizePdf] = new(
                    PdfToolIds.SummarizePdf,
                    "AI PDF Summarizer Online Free — Summarize Any PDF",
                    "Summarize PDF documents online. Extract key points from reports, papers, and contracts. Free up to 50 pages, Pro 200 pages.",
                    "AI PDF Summarizer — Key Points in Seconds",
                    "Upload a text-based PDF and get an extractive summary of the most important sentences. Ideal for long reports, research papers, and policy documents.",
                    "/pdf/summarize",
                    "AI PDF Summarizer",
                    "Summarize PDF documents online and extract key points with RatPDF.",
                    [
                        ("How does the PDF summarizer work?",
                            "We extract text from your PDF and rank sentences by importance using on-server extractive summarization — no ChatGPT API key required."),
                        ("Can it summarize scanned PDFs?",
                            "Only if the PDF already has selectable text. Run OCR PDF first on scanned documents, then summarize the searchable output."),
                        ("What is the page limit?",
                            "Free accounts can summarize PDFs up to 50 pages. Pro supports up to 200 pages per document."),
                        ("Can I choose summary length?",
                            "Yes — pick brief (~8 points), standard (~15 sentences), or detailed (~25 sentences) before processing."),
                    ]),

                [PdfToolIds.PdfA] = new(
                    PdfToolIds.PdfA,
                    "Convert to PDF/A Online Free — Archival PDF/A-1b & PDF/A-2b",
                    "Convert PDF to PDF/A online for long-term archiving. PDF/A-1b free, PDF/A-2b on Pro. Up to 4 GB on Pro.",
                    "Convert to PDF/A — Archival Format",
                    "Create PDF/A output for records retention and compliance workflows. PDF/A-1b for broad compatibility; PDF/A-2b on Pro for transparency support.",
                    "/pdf/pdfa",
                    "PDF/A Converter",
                    "Convert PDF to PDF/A archival format online with RatPDF.",
                    [
                        ("What is PDF/A?",
                            "PDF/A is an ISO standard subset of PDF designed for long-term preservation — embedded fonts, self-contained, no external dependencies."),
                        ("Is output certified PDF/A?",
                            "We produce PDF/A-structured files. Regulated archives may require validation with veraPDF or similar tools before submission."),
                        ("What is the difference between PDF/A-1b and PDF/A-2b?",
                            "PDF/A-1b is the most widely accepted baseline. PDF/A-2b adds features like transparency and is available on Pro."),
                        ("Is PDF/A conversion free?",
                            "Yes — PDF/A-1b is on the free tier (3 uses/day, 200 MB). Pro unlocks PDF/A-2b and 4 GB files."),
                    ]),

                [PdfToolIds.ComparePdf] = new(
                    PdfToolIds.ComparePdf,
                    "Compare PDFs Online Free — Text Diff Two Versions",
                    "Compare two PDF files online. See similarity percentage and highlighted text differences. Free 200 MB per file.",
                    "Compare PDFs — Find What Changed",
                    "Upload an original and revised PDF to diff extracted text side by side. Ideal for contracts, policies, and specification reviews.",
                    "/pdf/compare",
                    "Compare PDFs",
                    "Compare two PDF documents online and highlight text differences.",
                    [
                        ("How does PDF comparison work?",
                            "We extract text from both PDFs and compute a similarity score plus inline diff highlights."),
                        ("Can I compare scanned PDFs?",
                            "Only if the PDF already contains selectable text. Run OCR PDF first on scanned documents."),
                        ("Is this a visual pixel diff?",
                            "No — this is a text diff. Layout changes with identical text may not appear as changes."),
                        ("Is compare PDF free?",
                            "Yes — free users get 3 comparisons per day. Each file can be up to 200 MB (4 GB on Pro)."),
                    ]),

                [PdfToolIds.FillForm] = new(
                    PdfToolIds.FillForm,
                    "Fill PDF Form Online Free — Complete AcroForm Fields",
                    "Fill PDF forms online. Detect AcroForm fields, enter values, and download — optionally flatten. Free 200 MB, Pro 4 GB.",
                    "Fill PDF Form Online",
                    "Upload government, tax, or HR PDF forms with fillable fields. We detect field names, you enter values, and download a completed PDF.",
                    "/pdf/fillform",
                    "Fill PDF Form",
                    "Fill AcroForm PDF forms online and download completed documents.",
                    [
                        ("What form types are supported?",
                            "Standard AcroForm text fields and checkboxes. XFA-only dynamic forms may not display fields."),
                        ("Should I flatten after filling?",
                            "Flatten when submitting final forms so recipients cannot change your entries — same as printing and scanning."),
                        ("Can I fill password-protected forms?",
                            "Unlock the PDF first with Unlock PDF if you have the password."),
                        ("Is fill PDF form free?",
                            "Yes — field scan is free; filling counts toward your daily free tool uses (3/day, 200 MB per file)."),
                    ]),
            };

        public static PdfToolSeoMetaEntry? Get(string? toolId) =>
            toolId != null && ById.TryGetValue(toolId, out var entry) ? entry : null;

        public static void ApplyToViewData(string toolId, ViewDataDictionary viewData)
        {
            var meta = Get(toolId);
            if (meta == null) return;
            viewData["Title"] = meta.Title;
            viewData["Description"] = meta.Description;
            viewData["CanonicalUrl"] = PdfToolSeo.Canonical(meta.ToolPath);
            viewData["PdfToolId"] = meta.ToolId;
            viewData["OgImage"] = PdfToolSeo.OgImageForToolId(meta.ToolId);
            viewData["SeoH1"] = meta.H1;
            viewData["SeoLead"] = meta.Lead;
            viewData["SchemaAppName"] = meta.AppName;
            viewData["SchemaAppDescription"] = meta.AppDescription;
            viewData["SchemaAppUrl"] = PdfToolSeo.Canonical(meta.ToolPath);
            viewData["SchemaFaqs"] = meta.Faqs;
        }
    }
}
