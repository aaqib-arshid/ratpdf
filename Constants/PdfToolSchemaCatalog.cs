namespace ratpdf.Constants
{
    /// <summary>Unified JSON-LD metadata for PDF tool pages (matches competitor FAQ + HowTo depth).</summary>
    public static class PdfToolSchemaCatalog
    {
        public sealed record ToolSchema(
            string ToolId,
            string ToolName,
            string ToolPath,
            string[] HowToSteps,
            (string Question, string Answer)[] Faqs);

        private static readonly Dictionary<string, ToolSchema> ById = Build().ToDictionary(t => t.ToolId, StringComparer.OrdinalIgnoreCase);

        public static ToolSchema? Get(string? toolId)
        {
            if (string.IsNullOrEmpty(toolId)) return null;
            if (ById.TryGetValue(toolId, out var direct)) return direct;
            return toolId switch
            {
                "signpdf" => ById.GetValueOrDefault("signtext"),
                "rotate" => ById.GetValueOrDefault("rotateorremove"),
                _ => null,
            };
        }

        public static ToolSchema? GetByPath(string? path)
        {
            if (string.IsNullOrEmpty(path)) return null;
            path = path.Trim().TrimEnd('/');
            return ById.Values.FirstOrDefault(t =>
                string.Equals(t.ToolPath, path, StringComparison.OrdinalIgnoreCase));
        }

        public static IEnumerable<string> AllToolIds() => ById.Keys;

        private static IEnumerable<ToolSchema> Build()
        {
            yield return Schema("compress", "Compress PDF", "/pdf/compress",
                ["Open Compress PDF and upload your file.", "Choose Low, Medium, or High compression.", "Start processing and wait for completion.", "Download the smaller PDF."],
                Faqs("compress PDF", "Ghostscript re-encodes images; text stays vector in most files."));

            yield return Schema("merge", "Merge PDF", "/pdf/merge",
                ["Upload two or more PDF files.", "Drag to reorder if needed.", "Click Merge and download the combined PDF."],
                Faqs("merge PDF files", "iText smart merge preserves vector text and logos."));

            yield return Schema("split", "Split PDF", "/pdf/split",
                ["Upload the PDF.", "Enter page ranges or split options.", "Download ZIP or individual PDFs."],
                Faqs("split a PDF", "Extract only the pages you need for email or archiving."));

            yield return Schema("pdftodoc", "PDF to Word", "/pdf/pdftodoc",
                ["Upload a digital or scanned PDF.", "Choose conversion mode if prompted.", "Download editable DOCX."],
                Faqs("convert PDF to Word", "pdf2docx handles tables on digital PDFs; scans may need OCR first."));

            yield return Schema("doctopdf", "Word to PDF", "/pdf/doctopdf",
                ["Upload DOCX.", "Wait for LibreOffice export.", "Download print-ready PDF."],
                Faqs("convert Word to PDF", "Fonts and print layout are preserved for tender submissions."));

            yield return Schema("pdftoexcel", "PDF to Excel", "/pdf/pdftoexcel",
                ["Upload a PDF with tables.", "Run conversion.", "Download XLSX spreadsheet."],
                Faqs("convert PDF to Excel", "Lattice detection works on digital bank statements and invoices."));

            yield return Schema("pdftoppt", "PDF to PowerPoint", "/pdf/pdftoppt",
                ["Upload a PDF presentation or report.", "Run conversion.", "Download editable PPTX slides."],
                Faqs("convert PDF to PowerPoint", "Each PDF page becomes a slide with layout preserved for editing."));

            yield return Schema("ppttopdf", "PowerPoint to PDF", "/pdf/ppttopdf",
                ["Upload PPTX or PPT.", "Wait for LibreOffice Impress export.", "Download print-ready PDF."],
                Faqs("convert PowerPoint to PDF", "Slide dimensions and fonts are preserved for sharing and print."));

            yield return Schema("editpdf", "Edit PDF", "/pdf/editpdf",
                ["Upload PDF.", "Add text, images, or annotations.", "Download edited PDF."],
                Faqs("edit a PDF online", "Best for quick markups; heavy redesign belongs in desktop tools."));

            yield return Schema("ocrpdf", "OCR PDF", "/pdf/ocrpdf",
                ["Upload scanned PDF.", "Run OCR.", "Download searchable PDF with text layer."],
                Faqs("OCR a PDF", "Tesseract adds a searchable text layer to image PDFs."));

            yield return Schema("signtext", "Sign PDF", "/pdf/signtext",
                ["Upload PDF.", "Place typed signature block.", "Download signed PDF."],
                Faqs("sign a PDF", "Typed signatures suit business approvals; qualified e-sign may need dedicated providers."));

            yield return Schema("password", "Protect PDF", "/pdf/password",
                ["Upload PDF.", "Enter encryption password.", "Download protected PDF."],
                Faqs("password protect a PDF", "Share passwords on a separate channel from the file."));

            yield return Schema("watermark", "Watermark PDF", "/pdf/watermark",
                ["Upload PDF.", "Enter watermark text.", "Download watermarked PDF."],
                Faqs("watermark a PDF", "Use DRAFT or CONFIDENTIAL for review cycles."));

            yield return Schema("unlockpdf", "Unlock PDF", "/pdf/unlockpdf",
                ["Upload password-protected PDF.", "Enter the known password.", "Download unlocked PDF."],
                Faqs("unlock a PDF", "You must know the correct password; we do not crack encryption."));

            yield return Schema("rotateorremove", "Rotate PDF", "/pdf/rotateorremove",
                ["Upload PDF.", "Select pages to rotate or remove.", "Download updated PDF."],
                Faqs("rotate PDF pages", "Fix 90°/180° scans without rescanning."));

            yield return Schema("convertimages", "Images to PDF", "/pdf/convertimages",
                ["Upload JPG, PNG, or WEBP images.", "Confirm order.", "Download combined PDF."],
                Faqs("convert images to PDF", "Combine receipts and photos into one archive PDF."));

            yield return Schema("pdftoimages", "PDF to Images", "/pdf/pdftoimages",
                ["Upload PDF.", "Choose DPI if available.", "Download PNG ZIP."],
                Faqs("convert PDF to JPG or PNG", "Export pages as images for slides and thumbnails."));

            yield return Schema("pdftotext", "PDF to Text", "/pdf/pdftotext",
                ["Upload PDF.", "Extract text.", "Download UTF-8 text file."],
                Faqs("extract text from PDF", "Digital PDFs yield clean text; scans need OCR."));

            yield return Schema("texttopdf", "Text to PDF", "/pdf/texttopdf",
                ["Paste or upload plain text.", "Generate PDF.", "Download archive PDF."],
                Faqs("convert text to PDF", "Archive memos and notes as PDF."));

            yield return Schema("htmltopdf", "HTML to PDF", "/pdf/htmltopdf",
                ["Paste HTML or upload an .html file.", "Preview markup in the editor if needed.", "Click Convert HTML to PDF.", "Download the rendered PDF."],
                Faqs("convert HTML to PDF", "iText html2pdf renders CSS and tags into a print-ready PDF."));

            yield return Schema("pdftomarkdown", "PDF to Markdown", "/pdf/pdftomarkdown",
                ["Upload a digital or OCR PDF.", "Extract text per page.", "Download a .md file with page sections.", "Edit in any Markdown editor."],
                Faqs("convert PDF to Markdown", "Best for text-heavy digital PDFs; scans need OCR first for clean output."));

            yield return Schema("flattenpdf", "Flatten PDF", "/pdf/flattenpdf",
                ["Upload fillable PDF.", "Flatten form fields.", "Download flat PDF."],
                Faqs("flatten a PDF form", "Lock field values before portal upload."));

            yield return Schema("extractimages", "Extract Images from PDF", "/pdf/extractimages",
                ["Upload PDF.", "Extract embedded images.", "Download ZIP of images."],
                Faqs("extract images from PDF", "Pull logos and photos without full-page screenshots."));

            yield return Schema("pagenumbers", "Add Page Numbers", "/pdf/pagenumbers",
                ["Upload PDF.", "Set footer format.", "Download numbered PDF."],
                Faqs("add page numbers to PDF", "Use Page {page} of {total} tokens in footers."));

            yield return Schema("pdfmetadata", "PDF Metadata Viewer", "/pdf/pdfmetadata",
                ["Upload PDF.", "View properties.", "Copy JSON export if needed."],
                Faqs("view PDF metadata", "Inspect title, author, dates, and page count."));

            yield return Schema("crop", "Crop PDF", "/pdf/crop",
                ["Upload your PDF.", "Set margin trim in points or use inch presets.", "Download the cropped PDF."],
                Faqs("crop a PDF online", "Removes blank scanner borders and excess white space from every page."));

            yield return Schema("organize", "Organize PDF", "/pdf/organize",
                ["Upload a PDF.", "Drag pages to reorder or remove unwanted pages.", "Export the organized PDF."],
                Faqs("organize PDF pages", "Reorder and delete pages in one document without merging separate files."));

            yield return Schema("repairpdf", "Repair PDF", "/pdf/repair",
                ["Upload a damaged or unreadable PDF.", "We rebuild the document structure.", "Download the repaired PDF."],
                Faqs("repair a corrupt PDF", "Rebuilds xref tables and page streams when viewers refuse to open the file."));

            yield return Schema("summarizepdf", "AI PDF Summarizer", "/pdf/summarize",
                ["Upload a text-based PDF.", "Choose brief, standard, or detailed length.", "Read the summary and download JSON."],
                Faqs("summarize a PDF", "Extracts text and highlights the most important sentences — no account API key required."));

            yield return Schema("pdfa", "PDF/A Converter", "/pdf/pdfa",
                ["Upload your PDF.", "Choose PDF/A-1b or PDF/A-2b.", "Download the archival PDF and validate if required."],
                Faqs("convert PDF to PDF/A", "Creates PDF/A output for long-term archiving — validate with veraPDF for certified submissions."));

            yield return Schema("comparepdf", "Compare PDFs", "/pdf/compare",
                ["Upload original and revised PDFs.", "We extract text from both.", "Review highlighted differences and similarity score."],
                Faqs("compare two PDFs", "Text diff for digital PDFs — scanned documents need OCR first."));

            yield return Schema("fillform", "Fill PDF Form", "/pdf/fillform",
                ["Upload a fillable AcroForm PDF.", "Enter values in detected fields.", "Download filled PDF — optionally flatten."],
                Faqs("fill a PDF form online", "Works with standard AcroForm fields — XFA-only forms may not be supported."));

            yield return Schema("exceltopdf", "Excel to PDF", "/pdf/exceltopdf",
                ["Upload XLSX or XLS.", "Wait for LibreOffice export.", "Download print-ready PDF."],
                Faqs("convert Excel to PDF", "Preserves sheet layout for finance and reporting."));

            yield return Schema("imgtobase64", "Image to Base64", "/pdf/imgtobase64",
                ["Upload an image.", "Copy Base64 output.", "Use in HTML, CSS, or APIs."],
                Faqs("convert image to Base64", "Encode PNG or JPG for inline data URIs."));
        }

        private static ToolSchema Schema(string id, string name, string path, string[] steps, (string, string)[] faqs) =>
            new(id, name, path, steps, faqs);

        private static (string, string)[] Faqs(string task, string extraAnswer) =>
        [
            ($"How do I {task} online?", $"Open the tool on ratpdf.com, upload your file, follow the on-screen steps, and download the result."),
            ("Is it free?", "Yes — 3 uses per tool per day on the free tier (200 MB/file). Pro adds unlimited use and 4 GB uploads."),
            ("Are my files secure?", "Uploads use HTTPS/TLS. Files are processed temporarily and deleted after download."),
            ($"How does RatPDF compare to iLovePDF or Smallpdf for {task}?", extraAnswer + " See our /compare pages for full feature tables."),
        ];
    }
}
