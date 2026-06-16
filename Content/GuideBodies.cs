namespace ratpdf.Content
{
    /// <summary>High-value HTML bodies for tool guides (AdSense-quality).</summary>
    internal static class GuideBodies
    {
        public static string? Get(string slug) => slug switch
        {
            "compress-pdf-guide" or "merge-pdf" or "split-pdf" or "pdf-to-word" or "ocr-pdf"
                => GuideBodiesWave7.Get(slug),
            "edit-pdf" or "rotate-pdf"
                => GuideBodiesWave8.Get(slug),
            "pdf-to-excel" or "excel-to-pdf" or "pdf-to-images"
                => GuideBodiesWave10.Get(slug),
            "password-protect-pdf" or "unlock-pdf" or "watermark-pdf"
                => GuideBodiesWave11.Get(slug),
            "pdf-metadata" or "add-page-numbers"
                => GuideBodiesWave12.Get(slug),
            "compress-pdf-for-printing" or "flatten-pdf"
                => GuideBodiesWave13.Get(slug),
            "browser-vs-desktop-pdf-tools"
                => GuideBodiesWave14.Get(slug),
            "word-to-pdf" => WordToPdf,
            "pdf-txt-guide" or "pdf-to-text" => PdfToText,
            "text-to-pdf" => TextToPdf,
            "sign-pdf" => SignPdf,
            "images-to-pdf" => ImagesToPdf,
            "background-remover" => BackgroundRemover,
            "word-counter-guide" => WordCounter,
            "ring-size-converter-guide" => RingSize,
            "my-ip-guide" => MyIp,
            "invoice-generator-guide" => InvoiceGenerator,
            "extract-images-from-pdf" => ExtractImages,
            "watermark-vs-password-pdf" => WatermarkVsPassword,
            "sign-pdf-legally" => SignPdfLegally,
            "pdf-tool-alternatives" => PdfToolAlternatives,
            _ => GuideBodiesExtended.Get(slug)
        };

        private const string CompressPdf = """
            <h2>Why PDF file size matters</h2>
            <p>Email providers, government portals, and job-application sites often cap attachments at 5–25 MB. A single scanned contract or photo-heavy brochure can exceed that limit. Compression reduces bytes by re-encoding images and removing redundant objects — without necessarily making text unreadable.</p>
            <h2>How RatPDF compression works</h2>
            <p>RatPDF uses <strong>Ghostscript</strong> with three profiles:</p>
            <ul>
            <li><strong>Low</strong> — minimal visual change; best for legal PDFs and forms with fine print.</li>
            <li><strong>Medium</strong> — typical 40–70% reduction on image-heavy files; good default for email.</li>
            <li><strong>High</strong> — smallest size; ideal for previews, mobile sharing, or portal uploads with strict caps.</li>
            </ul>
            <h2>Step-by-step: compress online</h2>
            <ol>
            <li>Open the <a href="/PDF/Compress">Compress PDF tool</a>.</li>
            <li>Drag your file into the upload zone (up to 200 MB free; 4 GB on Pro).</li>
            <li>Select compression level and start — watch the progress bar for large files.</li>
            <li>Download the result and compare file size in your file manager.</li>
            </ol>
            <h2>Best practices</h2>
            <ul>
            <li>Start with <em>Medium</em>; only use High if the portal still rejects the file.</li>
            <li>For multi-document bundles, <a href="/guides/merge-pdf">merge PDFs first</a>, then compress once.</li>
            <li>Court e-filing: <a href="/guides/compress-pdf-efiling">compress PDF for e-filing</a>.</li>
            <li>LMS submissions: <a href="/guides/compress-pdf-for-lms">compress PDF for LMS</a>.</li>
            <li>Insurance claim uploads: <a href="/guides/compress-pdf-insurance-claims">compress PDF for insurance claims</a>.</li>
            <li>Job applications: <a href="/guides/compress-pdf-for-job-application">compress PDF for job application</a>.</li>
            <li>Indeed uploads: <a href="/guides/compress-pdf-for-indeed">compress PDF for Indeed</a>.</li>
            <li>LinkedIn resumes: <a href="/guides/compress-pdf-for-linkedin">compress PDF for LinkedIn</a>.</li>
            <li>University applications: <a href="/guides/compress-pdf-for-university-application">compress PDF for university application</a>.</li>
            <li>WhatsApp sharing: <a href="/guides/compress-pdf-for-whatsapp">compress PDF for WhatsApp</a>.</li>
            <li>Telegram sharing: <a href="/guides/compress-pdf-for-telegram">compress PDF for Telegram</a>.</li>
            <li>Naukri resumes: <a href="/guides/compress-pdf-for-naukri">compress PDF for Naukri</a>.</li>
            <li>Cloud storage quota: <a href="/guides/compress-pdf-cloud-storage">compress PDF for cloud storage</a>.</li>
            <li>Print workflows: <a href="/guides/compress-pdf-for-printing">compress PDF for printing</a>.</li>
            <li>Workday apply: <a href="/guides/compress-pdf-for-workday">compress PDF for Workday</a>.</li>
            <li>USAJOBS: <a href="/guides/compress-pdf-usajobs">compress PDF for USAJOBS</a>.</li>
            <li>iPhone/iPad: <a href="/guides/compress-pdf-on-iphone">compress PDF on iPhone</a>.</li>
            <li>Android: <a href="/guides/compress-pdf-on-android">compress PDF on Android</a>.</li>
            <li>Mac: <a href="/guides/compress-pdf-on-mac">compress PDF on Mac</a>.</li>
            <li>Windows / Chromebook: <a href="/guides/compress-pdf-on-windows">compress PDF on Windows</a>.</li>
            <li>Image-heavy PDFs: <a href="/guides/compress-pdf-with-images">compress PDF with images</a>.</li>
            <li>Quality preservation: <a href="/guides/compress-pdf-without-quality-loss">compress without quality loss</a>.</li>
            <li>Students / LMS: <a href="/guides/compress-pdf-students">compress PDF for students</a>.</li>
            <li>Freelancers / client delivery: <a href="/guides/compress-pdf-freelancers">compress PDF for freelancers</a>.</li>
            <li>Teachers / LMS handouts: <a href="/guides/compress-pdf-teachers">compress PDF for teachers</a>.</li>
            <li>Recruiters / candidate packs: <a href="/guides/compress-pdf-recruiters">compress PDF for recruiters</a>.</li>
            <li>HR / onboarding: <a href="/guides/compress-pdf-hr">compress PDF for HR</a>.</li>
            <li>Government portals: <a href="/guides/compress-pdf-government">compress PDF for government</a>.</li>
            <li>Ecommerce / catalogs: <a href="/guides/compress-pdf-ecommerce">compress PDF for ecommerce</a>.</li>
            <li>Real estate listings: <a href="/guides/compress-pdf-real-estate">compress PDF for real estate</a>.</li>
            <li>Nonprofits / grants: <a href="/guides/compress-pdf-nonprofits">compress PDF for nonprofits</a>.</li>
            <li>Construction / permits: <a href="/guides/compress-pdf-construction">compress PDF for construction</a>.</li>
            <li>Marketing agencies: <a href="/guides/compress-pdf-marketing-agencies">compress PDF for marketing agencies</a>.</li>
            <li>Healthcare / payer portals: <a href="/guides/compress-pdf-healthcare-admin">compress PDF for healthcare administrators</a>.</li>
            <li>Proton Mail: <a href="/guides/compress-pdf-for-protonmail">compress PDF for Proton Mail</a>.</li>
            <li>Yahoo Mail: <a href="/guides/compress-pdf-for-yahoo-mail">compress PDF for Yahoo Mail</a>.</li>
            <li>Visa uploads: <a href="/guides/compress-pdf-for-visa-application">compress PDF for visa application</a>.</li>
            <li>Schengen VFS: <a href="/guides/compress-pdf-schengen-visa">compress PDF for Schengen visa</a>.</li>
            <li>UKVI: <a href="/guides/compress-pdf-ukvi">compress PDF for UKVI</a>.</li>
            <li>Australia ImmiAccount: <a href="/guides/compress-pdf-home-affairs-australia">compress PDF for Home Affairs Australia</a>.</li>
            <li>Canada IRCC: <a href="/guides/compress-pdf-immigration-canada">compress PDF for immigration Canada</a>.</li>
            <li>UCAS (UK): <a href="/guides/compress-pdf-ucas">compress PDF for UCAS</a>.</li>
            <li>UIDAI / Aadhaar: <a href="/guides/compress-pdf-uidai">compress PDF for UIDAI</a>.</li>
            <li>Passport applications: <a href="/guides/compress-pdf-for-passport-application">compress PDF for passport application</a>.</li>
            <li>Government portals: <a href="/guides/compress-pdf-for-government-forms">compress PDF for government forms</a>.</li>
            <li>Email (all providers): <a href="/guides/compress-pdf-for-email">compress PDF for email</a>.</li>
            <li>LinkedIn resumes: <a href="/guides/compress-pdf-for-linkedin">compress PDF for LinkedIn</a>.</li>
            <li>IRCTC uploads: <a href="/guides/compress-pdf-irctc">compress PDF for IRCTC</a>.</li>
            <li>Merge then compress: <a href="/guides/compress-before-merge-pdf">compress before or after merge</a> · <a href="/guides/combine-then-compress-pdf">combine then compress workflow</a> · <a href="/guides/merge-vs-compress">merge vs compress</a> · <a href="/guides/compress-vs-split">compress vs split</a>.</li>
            <li>Before email: <a href="/guides/pdf-email-attachment-checklist">PDF email attachment checklist</a>.</li>
            <li>Scanned pages compress dramatically because photos dominate size — expect the biggest wins there.</li>
            <li>Keep an uncompressed archive copy before aggressive compression for long-term records.</li>
            <li>Size grew after compress? <a href="/guides/compress-pdf-made-it-larger">why compression made PDF larger</a></li>
            <li>Why so big? <a href="/guides/why-is-pdf-file-so-large">why is my PDF so large</a></li>
            <li>Scanned vs digital: <a href="/guides/compress-scanned-vs-digital-pdf">compress scanned vs digital PDF</a></li>
            <li>Engine: <a href="/guides/ghostscript-pdf-compression">Ghostscript compression explained</a></li>
            <li>Bank statements: <a href="/guides/compress-bank-statement-pdf">compress bank statement PDF</a></li>
            <li>GST invoices: <a href="/guides/compress-gst-invoice-pdf">compress GST invoice PDF</a></li>
            <li>PAN card: <a href="/guides/compress-pan-card-pdf">compress PAN card PDF</a></li>
            <li>Accountants: <a href="/guides/compress-pdf-accountants">compress PDF for accountants</a></li>
            <li>Lawyers: <a href="/guides/compress-pdf-lawyers">compress PDF for lawyers</a></li>
            </ul>
            <h2>When not to compress</h2>
            <p>Print-ready artwork, prepress PDFs, and files with embedded CAD vectors may lose subtle detail at High settings. For those, use Low or skip compression entirely. See <a href="/guides/compress-pdf-for-printing">compress PDF for printing</a> and <a href="/guides/compress-pdf-without-quality-loss">compress without quality loss</a> for print-shop and legal workflows. New to compression? <a href="/guides/glossary-compress-pdf-online">What is compress PDF online?</a></p>
            """;

        private const string MergePdf = """
            <h2>When merging PDFs saves time</h2>
            <p>Accountants attach invoices to payment proofs. Recruiters bundle CV, cover letter, and certificates. Landlords combine lease, inventory, and ID copies. Merging avoids sending three separate emails and keeps page order under your control.</p>
            <h2>How RatPDF merge preserves quality</h2>
            <p>Unlike tools that rasterize every page to JPEG, RatPDF appends pages with <strong>iText smart mode</strong> — vector text, fonts, and logos stay sharp. Bookmarks from source files are preserved when the PDF structure allows it.</p>
            <h2>Step-by-step</h2>
            <ol>
            <li>Go to <a href="/PDF/Merge">Merge PDF</a>.</li>
            <li>Upload two or more PDFs (drag to reorder if the UI supports it).</li>
            <li>Submit and download the combined document.</li>
            </ol>
            <h2>Tips for clean results</h2>
            <ul>
            <li>Merge in logical order: cover letter → resume → portfolio.</li>
            <li>Custom order tips: <a href="/guides/merge-pdf-custom-order">merge PDF in custom order</a>.</li>
            <li>If one file is landscape and another portrait, rotate pages first with our <a href="/guides/rotate-pdf">rotate guide</a>.</li>
            <li>After merging a large pack, <a href="/guides/compress-pdf-guide">compress</a> for email.</li>
            <li>Password-protected sources: <a href="/guides/merge-password-protected-pdf">merge password-protected PDFs</a>.</li>
            <li>Visa applicants: see <a href="/guides/merge-pdf-visa-application">merge PDF for visa application</a>.</li>
            <li>Court filing: <a href="/guides/merge-pdf-court-filing">merge PDF for court filing</a>.</li>
            <li>Mixed scans + digital: <a href="/guides/merge-scanned-digital-pdf">merge scanned and digital PDFs</a>.</li>
            <li>Quality preservation: <a href="/guides/merge-pdf-without-quality-loss">merge PDF without losing quality</a>.</li>
            <li>Accountants / board packs: <a href="/guides/merge-pdf-accountants">merge PDF for accountants</a>.</li>
            <li>Students / readings: <a href="/guides/merge-pdf-students">merge PDF for students</a>.</li>
            <li>Beginner tutorial: <a href="/guides/how-to-merge-pdf-files">how to merge PDF files</a>.</li>
            <li>Merge online: <a href="/guides/merge-pdf-online">merge PDF online</a>.</li>
            <li>Organize / reorder pages: <a href="/guides/organize-pdf-pages">organize PDF pages online</a>.</li>
            <li>Combine then compress: <a href="/guides/combine-then-compress-pdf">merge first, compress once</a> · <a href="/guides/merge-vs-compress">merge vs compress decision guide</a>.</li>
            </ul>
            """;

        private const string SplitPdf = """
            <h2>Extract pages without Adobe Acrobat</h2>
            <p>Splitting lets you share only page 7 (the signed sheet) from a 40-page agreement, or break a batch scan into individual receipts. RatPDF copies page content directly — no re-scanning.</p>
            <h2>Range syntax</h2>
            <p>Use formats like <code>1-3</code>, <code>5</code>, or <code>1-2, 7, 10-12</code> to pull specific pages into a new PDF. For one file per page, choose the “every page separate” option if available.</p>
            <h2>Common workflows</h2>
            <ul>
            <li><strong>Legal</strong> — extract exhibits and schedules from a master contract.</li>
            <li><strong>Finance</strong> — split multi-month bank PDFs by statement period.</li>
            <li><strong>Education</strong> — pull one chapter for students without sharing the full textbook scan.</li>
            </ul>
            <h2>Split workflow guides</h2>
            <ul>
            <li><a href="/guides/split-pdf-page-range">Split PDF by page range</a></li>
            <li><a href="/guides/extract-single-page-pdf">Extract single page from PDF</a></li>
            <li><a href="/guides/split-pdf-for-email">Split PDF for email</a> (when compress is not enough)</li>
            <li><a href="/guides/split-pdf-by-size">Split PDF by size</a> (MB-limited chunks)</li>
            <li><a href="/guides/organize-pdf-pages">Organize PDF pages</a> (reorder after split)</li>
            </ul>
            <p>Try it now: <a href="/PDF/Split">Split PDF</a>.</p>
            """;

        private const string PdfToWord = """
            <h2>Why most PDF→Word converters fail</h2>
            <p>Free tools often dump plain text and destroy tables, logos, and multi-column layouts. Real business PDFs — GST invoices, agency decks, scanned brochures — need a <strong>multi-engine pipeline</strong>.</p>
            <h2>RatPDF conversion strategy</h2>
            <ol>
            <li><strong>pdf2docx</strong> reconstructs editable text, tables, and images.</li>
            <li><strong>Page-render fallback</strong> embeds each page at 200 DPI when graphics would break (common on scans).</li>
            <li><strong>OCR</strong> extracts text when no digital text layer exists.</li>
            <li><strong>LibreOffice</strong> provides an additional pass on servers where installed.</li>
            </ol>
            <h2>Document types we handle well</h2>
            <ul>
            <li>Invoices with line-item tables and company logos</li>
            <li>Marketing PDFs with full-bleed images</li>
            <li>Scanned office letters and forms</li>
            <li>Multi-column reports and proposals</li>
            </ul>
            <h2>Tips for best results</h2>
            <ul>
            <li>Use the original digital PDF when possible — not a photocopy re-scan.</li>
            <li>Unlock password-protected files before upload.</li>
            <li>Image-heavy scans may produce Word with page images — visually identical, ideal for printing.</li>
            <li>Resume editing: <a href="/guides/pdf-to-word-resume">PDF to Word for resume</a></li>
            <li>Keep tables and logos: <a href="/guides/pdf-to-word-keep-formatting">PDF to Word keep formatting</a></li>
            <li>Invoice edits: <a href="/guides/pdf-to-word-invoice">PDF to Word for invoice</a></li>
            <li>Scanned documents: <a href="/guides/scanned-pdf-to-word">scanned PDF to Word</a></li>
            <li>Mac users: <a href="/guides/pdf-to-word-mac">PDF to Word on Mac</a></li>
            <li>No Office license: <a href="/guides/pdf-to-word-without-word">PDF to Word without Microsoft Word</a></li>
            <li>Google Docs workflow: <a href="/guides/pdf-to-word-vs-google-docs">PDF to Word vs Google Docs</a></li>
            <li>Many files: <a href="/guides/batch-pdf-to-word">batch PDF to Word workflow</a></li>
            <li>Word vs plain text: <a href="/guides/pdf-to-word-vs-pdf-to-text">PDF to Word vs PDF to Text</a></li>
            <li>Beginner definition: <a href="/guides/glossary-pdf-to-word-converter">what is a PDF to Word converter?</a></li>
            <li>Garbled symbols or boxes: <a href="/guides/pdf-to-word-garbled-text">PDF to Word garbled text fixes</a></li>
            </ul>
            <h2>Document-type workflows</h2>
            <ul>
            <li><a href="/guides/convert-contract-pdf-to-word">Convert contract PDF to Word</a></li>
            <li><a href="/guides/convert-nda-pdf-to-word">Convert NDA PDF to Word</a></li>
            <li><a href="/guides/convert-lease-agreement-pdf-to-word">Convert lease agreement PDF to Word</a></li>
            <li><a href="/guides/convert-bank-statement-pdf-to-word">Convert bank statement PDF to Word</a></li>
            <li><a href="/guides/convert-sow-pdf-to-word">Convert SOW PDF to Word</a></li>
            <li><a href="/guides/convert-purchase-order-pdf-to-word">Convert purchase order PDF to Word</a></li>
            <li><a href="/guides/convert-quotation-pdf-to-word">Convert quotation PDF to Word</a></li>
            <li><a href="/guides/convert-proforma-invoice-pdf-to-word">Convert proforma invoice PDF to Word</a></li>
            <li><a href="/guides/convert-receipt-pdf-to-word">Convert receipt PDF to Word</a></li>
            <li><a href="/guides/convert-credit-note-pdf-to-word">Convert credit note PDF to Word</a></li>
            <li><a href="/guides/convert-debit-note-pdf-to-word">Convert debit note PDF to Word</a></li>
            <li><a href="/guides/convert-delivery-note-pdf-to-word">Convert delivery note PDF to Word</a></li>
            <li><a href="/guides/convert-tax-return-pdf-to-word">Convert tax return PDF to Word</a></li>
            <li><a href="/guides/convert-transcript-pdf-to-word">Convert transcript PDF to Word</a></li>
            </ul>
            <h2>Programmatic guides</h2>
            <ul>
            <li><a href="/pdf-to-word/pdf-to-word">PDF to Word online</a></li>
            <li><a href="/pdf-to-word/how-to-convert-pdf-to-word">How to convert PDF to Word</a></li>
            <li><a href="/pdf-to-word/convert-pdf-to-word">Convert PDF to Word</a></li>
            <li><a href="/pdf-to-word/pdf-to-word-iphone">PDF to Word on iPhone</a></li>
            </ul>
            <p><a href="/PDF/PdfToDoc">Convert PDF to Word now →</a></p>
            """;

        private const string WordToPdf = """
            <h2>When you need print-accurate PDFs</h2>
            <p>Sharing DOCX invites unwanted edits. PDF locks layout for clients, courts, and print shops. Word’s built-in export sometimes shifts margins or drops fonts — RatPDF routes files through <strong>LibreOffice headless</strong> for Acrobat-class output.</p>
            <h2>Before you convert</h2>
            <ul>
            <li>Embed fonts in Word (<em>File → Options → Save → Embed fonts</em>).</li>
            <li>Prefer DOCX over legacy DOC for reliable tables.</li>
            <li>Set print area for wide spreadsheets converted via our Excel path.</li>
            </ul>
            <h2>Use cases</h2>
            <p>Client proposals, HR policy packs, academic submissions, and branded letters all benefit from locked PDF delivery. After export, <a href="/guides/compress-pdf-guide">compress</a> or <a href="/guides/password-protect-pdf">password-protect</a> as needed.</p>
            <p><a href="/PDF/DocToPdf">Word to PDF converter →</a></p>
            """;

        private const string PdfToExcel = """
            <h2>Tables, not a single column of text</h2>
            <p>Pasting from PDF into Excel often destroys cell boundaries. RatPDF detects <strong>lattice and stream tables</strong>, rebuilds borders where possible, and structures output for spreadsheets.</p>
            <h2>Works best with</h2>
            <ul>
            <li>Bank and card statements exported as PDF</li>
            <li>GST / VAT summaries on invoices</li>
            <li>Price lists inside report PDFs</li>
            <li>Survey tables in appendix pages</li>
            </ul>
            <h2>If the PDF is scanned</h2>
            <p>Flattened scans may need <a href="/guides/pdf-to-word">PDF to Word with OCR</a> first, then copy tables. Always start from the original digital export when available.</p>
            <p><a href="/PDF/PdfToExcel">PDF to Excel tool →</a></p>
            """;

        private const string ExcelToPdf = """
            <h2>Publish spreadsheets readers cannot edit</h2>
            <p>Finance teams share monthly P&amp;L PDFs with leadership. Recruiters send read-only comp bands. RatPDF honours sheet scale, print areas, and charts where the XLSX defines them.</p>
            <h2>Excel checklist</h2>
            <ol>
            <li>Define <em>Page Layout → Print Area</em> to avoid blank pages.</li>
            <li>Fit wide models to one page width for external sharing.</li>
            <li>Replace external links with values for archival PDFs.</li>
            </ol>
            <p><a href="/PDF/ExcelToPdf">Excel to PDF →</a></p>
            """;

        private const string EditPdf = """
            <h2>Lightweight PDF editing in the browser</h2>
            <p>Not every task needs Adobe Acrobat. RatPDF’s editor lets you add text, images, and annotations for quick fixes — mark up a contract, stamp “DRAFT”, or insert a missing signature block.</p>
            <h2>What browser editing is good for</h2>
            <ul>
            <li>Last-minute label corrections</li>
            <li>Adding notes before client review</li>
            <li>Inserting a logo on a generated PDF</li>
            </ul>
            <h2>Limitations</h2>
            <p>Complex prepress, CMYK colour proofing, and heavy form redesign still belong in desktop tools. For watermarks and passwords, use dedicated <a href="/guides/watermark-pdf">watermark</a> and <a href="/guides/password-protect-pdf">protect</a> tools.</p>
            <h2>Edit PDF workflow guides</h2>
            <ul>
            <li><a href="/guides/edit-pdf-without-acrobat">Edit PDF without Adobe</a></li>
            <li><a href="/guides/edit-scanned-pdf">Edit scanned PDF</a> (OCR first)</li>
            <li><a href="/guides/add-image-to-pdf">Add image to PDF</a></li>
            <li><a href="/guides/edit-pdf-forms">Edit PDF forms</a></li>
            <li><a href="/guides/add-page-numbers">Add page numbers</a></li>
            <li><a href="/guides/rotate-pdf">Rotate PDF pages</a></li>
            <li><a href="/edit-pdf/edit-pdf-free">Edit PDF free</a> · <a href="/edit-pdf/edit-pdf-add-text">Add text</a> · <a href="/edit-pdf/edit-pdf-add-signature">Add signature</a></li>
            <li><a href="/blog/pdf-editing-mistakes">PDF editing mistakes</a></li>
            </ul>
            <p><a href="/PDF/EditPDF">Open PDF editor →</a></p>
            """;

        private const string PdfToText = """
            <h2>Plain text for search, quotes, and automation</h2>
            <p>Extracting text lets you paste into CMS fields, translation tools, or AI workflows without retyping. Digital PDFs yield clean Unicode; scanned pages need OCR when Tesseract is available on the server.</p>
            <h2>Digital vs scanned PDFs</h2>
            <p>A PDF from Word or Excel has a real text layer — extraction is fast and accurate. A phone photo saved as PDF is really images — OCR reads pixels and may misread faint text or multi-column magazines.</p>
            <h2>Workflow tips</h2>
            <ul>
            <li>For editable layout, prefer <a href="/guides/pdf-to-word">PDF to Word</a>.</li>
            <li>Clean scans (straight, good lighting) OCR better.</li>
            <li>Check numbers in financial extracts manually — OCR can confuse 0/O and 1/l.</li>
            <li>Research workflow: <a href="/guides/pdf-to-text-research">PDF to text for research papers</a></li>
            <li>Scanned PDFs: <a href="/guides/extract-text-scanned-pdf">extract text from scanned PDF</a></li>
            <li>Without Adobe: <a href="/guides/extract-text-without-adobe">extract text from PDF without Adobe</a></li>
            <li>Which tool first: <a href="/guides/ocr-vs-pdf-to-text">OCR vs PDF to Text</a></li>
            <li>Tesseract vs cloud OCR: <a href="/guides/tesseract-vs-online-ocr">Tesseract vs online OCR</a></li>
            <li>Word vs text export: <a href="/guides/pdf-to-word-vs-pdf-to-text">PDF to Word vs PDF to Text</a></li>
            <li>Bank statements: <a href="/guides/pdf-to-text-bank-statements">PDF to text for bank statements</a></li>
            <li>Multilingual UTF-8: <a href="/guides/pdf-to-text-multilingual">PDF to text multilingual</a></li>
            <li>Hindi OCR: <a href="/guides/ocr-pdf-hindi">OCR PDF Hindi</a></li>
            <li>Arabic OCR: <a href="/guides/ocr-pdf-arabic">OCR PDF Arabic</a></li>
            <li>Spanish OCR: <a href="/guides/ocr-pdf-spanish">OCR PDF Spanish</a></li>
            <li>Chinese OCR: <a href="/guides/ocr-pdf-chinese">OCR PDF Chinese</a></li>
            <li>French OCR: <a href="/guides/ocr-pdf-french">OCR PDF French</a></li>
            <li>German OCR: <a href="/guides/ocr-pdf-german">OCR PDF German</a></li>
            <li>Japanese OCR: <a href="/guides/ocr-pdf-japanese">OCR PDF Japanese</a></li>
            <li>Russian OCR: <a href="/guides/ocr-pdf-russian">OCR PDF Russian</a></li>
            <li>Korean OCR: <a href="/guides/ocr-pdf-korean">OCR PDF Korean</a></li>
            <li>Portuguese OCR: <a href="/guides/ocr-pdf-portuguese">OCR PDF Portuguese</a></li>
            <li>OCR quality fixes: <a href="/guides/ocr-pdf-poor-quality">OCR poor quality</a></li>
            <li>Accessibility / screen readers: <a href="/guides/pdf-to-text-accessibility">PDF to text accessibility</a></li>
            <li>Beginner definition: <a href="/guides/glossary-pdf-to-text-extractor">what is a PDF to text extractor?</a></li>
            </ul>
            <h2>Programmatic guides</h2>
            <ul>
            <li><a href="/pdf-to-txt/pdf-to-text-online">PDF to text online</a></li>
            <li><a href="/pdf-to-txt/how-do-i-convert-pdf-to-text">How to convert PDF to text</a></li>
            <li><a href="/pdf-to-txt/ocr-pdf-to-text">OCR PDF to text</a></li>
            <li><a href="/pdf-to-txt/how-scanned-pdf-to-text">Scanned PDF to text</a></li>
            <li><a href="/pdf-to-txt/pdf-to-text-iphone">PDF to text on iPhone</a> · <a href="/pdf-to-txt/pdf-to-text-android">Android</a></li>
            </ul>
            <p><a href="/PDF/PdfToText">PDF to Text tool →</a></p>
            """;

        private const string TextToPdf = """
            <h2>Turn notes into shareable PDFs</h2>
            <p>Plain-text memos, code snippets, and meeting notes convert to PDF for archiving, printing, or attaching where DOCX is not allowed.</p>
            <h2>Formatting tips</h2>
            <ul>
            <li>Use blank lines between sections — they become paragraph breaks.</li>
            <li>For rich layout, write in Word and use <a href="/guides/word-to-pdf">Word to PDF</a> instead.</li>
            <li>After creation, <a href="/guides/watermark-pdf">add a watermark</a> for draft status.</li>
            </ul>
            <p><a href="/PDF/TextToPdf">Text to PDF →</a></p>
            """;

        private const string WatermarkPdf = """
            <h2>Mark drafts and confidential copies</h2>
            <p>Watermarks deter casual sharing of draft contracts, internal pricing, and unreleased creative. RatPDF applies diagonal text across every page while keeping the underlying content readable.</p>
            <h2>Common labels</h2>
            <ul>
            <li>DRAFT — legal and finance review cycles</li>
            <li>CONFIDENTIAL — board packs</li>
            <li>SAMPLE — agency concept PDFs</li>
            <li>Company name — brand protection on leaks</li>
            </ul>
            <h2>Combine with protection</h2>
            <p>Watermarks are visual deterrents, not encryption. For sensitive data, also <a href="/guides/password-protect-pdf">password-protect</a> the file. Not sure which to use first? Read our <a href="/guides/watermark-vs-password-pdf">watermark vs password guide</a>.</p>
            <p><a href="/PDF/Watermark">Add watermark →</a></p>
            """;

        private const string PasswordPdf = """
            <h2>Encrypt PDFs before email</h2>
            <p>Password protection uses PDF encryption so only recipients with the passphrase open the file. Use it for payslips, medical records, and client financials.</p>
            <h2>Password hygiene</h2>
            <ul>
            <li>Use 12+ characters — share via a separate channel (SMS, password manager).</li>
            <li>Do not reuse banking passwords for document encryption.</li>
            <li>Remind recipients they cannot recover the file if they lose the password.</li>
            </ul>
            <p>Watermarks and passwords solve different problems — see <a href="/guides/watermark-vs-password-pdf">when to watermark vs encrypt</a>.</p>
            <p><a href="/PDF/Password">Protect PDF →</a></p>
            """;

        private const string SignPdf = """
            <h2>Add signature text to PDFs</h2>
            <p>Typed name, title, and date blocks formalise acceptance on quotes, SOWs, and internal approvals when wet ink is not required.</p>
            <h2>Not the same as eIDAS digital signatures</h2>
            <p>RatPDF adds visible signature <em>text</em> — suitable for many business workflows. Regulated qualified electronic signatures may need specialised providers. For jurisdiction-specific rules, read <a href="/guides/sign-pdf-legally">sign PDF legally</a>.</p>
            <p><a href="/PDF/SignText">Sign PDF →</a></p>
            """;

        private const string RotatePdf = """
            <h2>Fix sideways scans and mixed orientations</h2>
            <p>Phone scans and faxed pages often arrive rotated 90° or 180°. Rotating in the browser avoids re-scanning physical paper.</p>
            <h2>Rotate vs remove pages</h2>
            <p>Use rotate when content is correct but orientation is wrong. Use remove when blank pages or duplicates slipped into a merged file — both live in our <a href="/PDF/RotateOrRemove">Rotate &amp; Remove tool</a>.</p>
            """;

        private const string ImagesToPdf = """
            <h2>Combine JPG, PNG, WEBP into one PDF</h2>
            <p>Receipts, site photos, and scanned IDs are easier to archive as a single PDF than a folder of images. RatPDF orders files as uploaded and avoids trailing blank pages.</p>
            <h2>Tips</h2>
            <ul>
            <li>Rename files with numeric prefixes (01-, 02-) before upload for sort order.</li>
            <li>For heavy photo packs, <a href="/guides/compress-pdf-guide">compress</a> the resulting PDF.</li>
            <li>Portrait photos on A4 — expect margins; crop in an image editor first if needed.</li>
            </ul>
            <p><a href="/PDF/ConvertImages">Image to PDF →</a></p>
            """;

        private const string BackgroundRemover = """
            <h2>100% browser-based — your images never upload</h2>
            <p>RatPDF's <a href="/tools/imgbackgroundremove">AI background remover</a> runs entirely in your browser using on-device inference. Your photos are <strong>not sent to our servers</strong> — ideal for headshots, product shots, and confidential assets where privacy matters.</p>
            <h2>How it works</h2>
            <ol>
            <li>Open the tool and select a JPG, PNG, WEBP, or BMP file (drag-and-drop supported).</li>
            <li>AI segmentation runs locally in the browser — processing time depends on your device GPU/CPU.</li>
            <li>Download a transparent PNG with the <strong>same width and height</strong> as your original image.</li>
            </ol>
            <h2>When it works well</h2>
            <ul>
            <li>Product photos on plain white or grey backgrounds</li>
            <li>Headshots with clear subject/background contrast</li>
            <li>Logos on solid colours</li>
            </ul>
            <h2>Limitations</h2>
            <p>Fine hair, glass, and busy backgrounds remain challenging for any AI cutout. For catalogue PDFs, place PNG cutouts via <a href="/guides/images-to-pdf">Image to PDF</a>. Compress large PNGs with the <a href="/guides/image-compressor-guide">image compressor guide</a>.</p>
            <p>More image tools: <a href="/tools">all tools</a> · SEO hub: <a href="/background-remover">background remover landing</a></p>
            <p><a href="/tools/imgbackgroundremove">Open background remover →</a></p>
            """;

        private const string WordCounter = """
            <h2>Why word count still matters</h2>
            <p>Essays, meta descriptions, AdSense articles, and social posts all have implicit length targets. Accurate counts prevent rejected journal submissions and truncated SEO snippets.</p>
            <h2>What to measure</h2>
            <ul>
            <li><strong>Words</strong> — editorial and academic limits</li>
            <li><strong>Characters</strong> — Twitter/X and meta title/description fields</li>
            <li><strong>Reading time</strong> — blog UX (~200 wpm average)</li>
            </ul>
            <h2>SEO note</h2>
            <p>Google does not rank by word count alone — but thin pages under 300 words rarely satisfy informational queries. Aim for depth, not padding.</p>
            <p><a href="/Tools/WordCounter">Word counter tool →</a></p>
            """;

        private const string RingSize = """
            <h2>International ring sizes explained</h2>
            <p>US, UK, EU, and Indian sizing scales differ. Buying online without measuring leads to costly returns — especially for gift purchases.</p>
            <h2>Measure at home</h2>
            <ol>
            <li>Wrap non-stretch string around the finger joint.</li>
            <li>Mark overlap, measure mm length on a ruler.</li>
            <li>Convert via our <a href="/Tools/RingSizeConverter">ring size converter</a>.</li>
            </ol>
            <p>Measure when fingers are warm, end of day — they swell slightly. Repeat twice.</p>
            """;

        private const string MyIp = """
            <h2>What is a public IP address?</h2>
            <p>Your public IP is how websites and services on the internet see your network — usually your router’s address, not your laptop’s local 192.168.x.x.</p>
            <h2>Common uses</h2>
            <ul>
            <li>Whitelist an office IP for SaaS admin panels</li>
            <li>Debug VPN connect/disconnect</li>
            <li>Share with IT support for firewall rules</li>
            </ul>
            <h2>IPv4 vs IPv6</h2>
            <p>Many ISPs now assign IPv6. Some legacy systems only accept IPv4 — check which your portal requires.</p>
            <p><a href="/Tools/WhatIsMyIP">What is my IP tool →</a></p>
            """;

        private const string InvoiceGenerator = """
            <h2>Professional invoices in minutes</h2>
            <p>Freelancers and small businesses need GST/VAT-ready PDFs with line items, tax breakdowns, and payment details. RatPDF’s invoice generator supports 50+ currencies and instant PDF download.</p>
            <h2>What to include</h2>
            <ul>
            <li>Legal business name, address, tax ID</li>
            <li>Unique invoice number and issue date</li>
            <li>Itemised description, quantity, rate, tax per line</li>
            <li>Payment terms and bank/UPI details</li>
            </ul>
            <h2>Pro features</h2>
            <p>Remove watermarks, save reusable templates, and add your logo on Pro plans. See <a href="/Subscription/Plans">pricing</a>.</p>
            <h2>Country guides</h2>
            <ul>
            <li><a href="/guides/invoice-generator-india">Invoice generator India (GST)</a></li>
            <li><a href="/guides/invoice-generator-usa">Invoice generator USA</a></li>
            <li><a href="/guides/invoice-generator-uk">Invoice generator UK (VAT)</a></li>
            <li><a href="/guides/invoice-generator-australia">Invoice generator Australia (GST)</a></li>
            <li><a href="/guides/invoice-generator-canada">Invoice generator Canada (GST/HST)</a></li>
            <li><a href="/guides/invoice-generator-france">Invoice generator France (TVA)</a></li>
            <li><a href="/guides/invoice-generator-germany">Invoice generator Germany (USt)</a></li>
            <li><a href="/guides/invoice-generator-singapore">Invoice generator Singapore (GST)</a></li>
            <li><a href="/guides/invoice-generator-uae">Invoice generator UAE (VAT)</a></li>
            <li><a href="/guides/invoice-generator-philippines">Invoice generator Philippines (VAT)</a></li>
            <li><a href="/guides/invoice-generator-new-zealand">Invoice generator New Zealand (GST)</a></li>
            <li><a href="/guides/invoice-generator-south-africa">Invoice generator South Africa (VAT)</a></li>
            <li><a href="/guides/invoice-for-freelancers">Invoice for freelancers</a></li>
            <li>No account required: <a href="/invoice/free-invoice-no-signup">free invoice without signup</a></li>
            </ul>
            <h2>Tax &amp; compliance requirements</h2>
            <ul>
            <li><a href="/guides/gst-invoice-format-india">GST invoice format India</a></li>
            <li><a href="/guides/vat-invoice-eu-requirements">EU VAT invoice requirements</a></li>
            <li><a href="/guides/hmrc-invoice-requirements">UK HMRC invoice requirements</a></li>
            <li><a href="/guides/ato-invoice-requirements">Australia ATO tax invoice requirements</a></li>
            <li><a href="/guides/cra-invoice-requirements">Canada CRA invoice requirements</a></li>
            <li><a href="/guides/irs-tax-pdf-format">IRS tax document PDF format</a></li>
            <li><a href="/guides/e-invoicing-india-pdf">E-invoicing India PDF</a></li>
            </ul>
            <h2>Privacy, accessibility &amp; retention</h2>
            <ul>
            <li><a href="/guides/gdpr-pdf-redaction">GDPR PDF redaction</a></li>
            <li><a href="/guides/hipaa-pdf-handling">HIPAA PDF handling</a></li>
            <li><a href="/guides/section-508-pdf">Section 508 PDF accessibility</a></li>
            <li><a href="/guides/wcag-22-pdf">WCAG 2.2 PDF requirements</a></li>
            <li><a href="/guides/sox-pdf-retention">SOX document retention PDF</a></li>
            </ul>
            <p><a href="/Invoice/Create">Create invoice →</a></p>
            """;

        private const string UnlockPdf = """
            <h2>Why unlock a PDF?</h2>
            <p>Encryption blocks printing, copying, or opening without a password. When you <strong>own the document</strong> and know the passphrase, removing protection lets you merge, compress, or archive an unrestricted copy.</p>
            <h2>Step-by-step</h2>
            <ol>
            <li>Open the <a href="/PDF/UnlockPdf">Unlock PDF tool</a>.</li>
            <li>Upload the protected file and enter the password.</li>
            <li>Download the decrypted PDF when the job completes.</li>
            </ol>
            <p>RatPDF never bypasses unknown passwords. Use only on files you are authorized to access.</p>
            <p>Next step: <a href="/guides/merge-password-protected-pdf">merge unlocked PDFs</a>.</p>
            """;

        private const string PdfToImages = """
            <h2>Page renders vs embedded images</h2>
            <p><a href="/PDF/PdfToImages">PDF to Images</a> renders <em>every page</em> as PNG — ideal for slide decks, scanned books, and social previews. For photos embedded inside a layout PDF, try <a href="/PDF/ExtractImages">Extract Images</a> instead.</p>
            <h2>DPI guide</h2>
            <ul>
            <li><strong>150 DPI</strong> — web and email (default)</li>
            <li><strong>300 DPI</strong> — print-quality grabs</li>
            </ul>
            """;

        private const string ExtractImages = """
            <h2>Embedded bitmaps</h2>
            <p>This tool exports image objects stored in the PDF structure — product photos, chart PNGs, logos. It does not screenshot vector text.</p>
            <h2>When to use</h2>
            <ul>
            <li>E-commerce catalog PDFs with many SKUs</li>
            <li>Marketing brochures with separate hero images</li>
            </ul>
            <p><a href="/PDF/ExtractImages">Extract Images tool →</a></p>
            """;

        private const string OcrPdf = """
            <h2>Searchable scans</h2>
            <p>Scanned PDFs are pictures of pages. <a href="/PDF/OcrPdf">OCR PDF</a> adds an invisible text layer so you can search and copy content in any viewer.</p>
            <h2>Best results</h2>
            <ul>
            <li>Scan at 300 DPI, straight pages</li>
            <li>Grayscale for text forms</li>
            <li>Follow with <a href="/PDF/PdfToDoc">PDF to Word</a> if you need editable layout</li>
            <li>Full workflow: <a href="/guides/ocr-scanned-pdf-workflow">OCR scanned PDF guide</a></li>
            <li>Extract text: <a href="/guides/extract-text-scanned-pdf">extract text from scanned PDF</a></li>
            </ul>
            """;

        private const string PageNumbers = """
            <h2>Footer numbering</h2>
            <p>Use <code>{page}</code> and <code>{total}</code> in the format field — e.g. <code>Page {page} of {total}</code>. RatPDF stamps every page consistently.</p>
            <h2>Tip</h2>
            <p><a href="/PDF/Merge">Merge</a> chapters first if your document comes from multiple PDFs, then run <a href="/PDF/PageNumbers">Add Page Numbers</a>.</p>
            """;

        private const string PdfMetadata = """
            <h2>Document properties</h2>
            <p>PDFs store title, author, creator app, dates, and page count in metadata — critical for legal filings and archive migration.</p>
            <h2>Export</h2>
            <p>The <a href="/PDF/PdfMetadata">PDF Metadata Viewer</a> returns JSON you can save or feed into audit scripts.</p>
            """;

        private const string WatermarkVsPassword = """
            <h2>Two different security layers</h2>
            <p>A <strong>watermark</strong> is visible text or imagery stamped on every page — it tells the reader the document is a draft, confidential sample, or not for redistribution. A <strong>password</strong> encrypts the PDF so the file cannot be opened without the passphrase. They solve different problems and are often used together in a sensible order: watermark for status, password for access control.</p>
            <h2>When a watermark is enough</h2>
            <ul>
            <li><strong>Internal review</strong> — mark packs DRAFT or FOR DISCUSSION before the board sees a final version.</li>
            <li><strong>Agency concepts</strong> — SAMPLE or agency name on pitch PDFs discourages reuse without replacing encryption overhead.</li>
            <li><strong>Low-risk external sharing</strong> — sending a pricing PDF to a prospect where the main risk is misunderstanding, not data theft.</li>
            <li><strong>Already-public content</strong> — whitepapers or brochures where you only need to show version status.</li>
            </ul>
            <p>Watermarks do <em>not</em> stop someone from opening, copying, or removing the mark with editing software. Treat them as communication and deterrence, not encryption.</p>
            <h2>When you need a password</h2>
            <ul>
            <li><strong>Personal data</strong> — payslips, medical summaries, tax returns, bank statements.</li>
            <li><strong>Regulated industries</strong> — client financials, legal discovery packs, HR disciplinary files.</li>
            <li><strong>Email exposure</strong> — any PDF that would cause harm if the wrong inbox received it.</li>
            <li><strong>Portal uploads</strong> — some government and tender systems expect encrypted attachments.</li>
            </ul>
            <p>Use our <a href="/PDF/Password">Password Protect PDF tool</a> and share the passphrase on a separate channel (SMS, password manager, phone call).</p>
            <h2>Recommended workflow: both</h2>
            <ol>
            <li>Finalize content in Word or your <a href="/invoice/create">invoice generator</a>, export to PDF.</li>
            <li><a href="/PDF/Watermark">Add a watermark</a> while the file is still in draft review (DRAFT, CONFIDENTIAL).</li>
            <li>After approval, remove or replace the watermark if needed, then <a href="/PDF/Password">password-protect</a> the final PDF.</li>
            <li><a href="/guides/compress-pdf-guide">Compress</a> if the encrypted file exceeds email limits.</li>
            </ol>
            <h2>Quick decision table</h2>
            <ul>
            <li><strong>Draft only, trusted recipients</strong> → watermark</li>
            <li><strong>Final file, sensitive content</strong> → password</li>
            <li><strong>Draft + sensitive</strong> → watermark first, password before external send</li>
            <li><strong>Public marketing PDF</strong> → usually neither; use <a href="/guides/compress-pdf-guide">compression</a> instead</li>
            </ul>
            <h2>Related guides</h2>
            <p>Deeper dives: <a href="/guides/watermark-pdf">watermark PDF guide</a>, <a href="/guides/password-protect-pdf">password protect PDF guide</a>, and the full <a href="/guides/secure-pdf-workflow">secure PDF workflow hub</a>.</p>
            """;

        private const string SignPdfLegally = """
            <h2>What “signing a PDF” can mean</h2>
            <p>Colloquially, signing a PDF means showing that someone approved the document — often with a handwritten scan, a typed name and date, or a platform like DocuSign. Legally, the weight of that signature depends on <strong>local law</strong>, <strong>document type</strong>, and <strong>signature technology</strong>, not on the PDF format alone.</p>
            <h2>Typed signatures (what RatPDF provides)</h2>
            <p>RatPDF’s <a href="/PDF/SignText">Sign PDF tool</a> adds a visible block — typically name, title, and date — to a fixed page. This matches everyday business practice for:</p>
            <ul>
            <li>Internal approvals (purchase orders, expense sign-off)</li>
            <li>Freelancer quotes and statements of work</li>
            <li>HR offer letters where local law accepts simple electronic consent</li>
            <li>Vendor acknowledgements and change requests</li>
            </ul>
            <p>A typed block proves <em>intent to approve</em> in many jurisdictions when combined with email threads, audit logs, or contract management records. It is not the same as a cryptographically sealed qualified signature.</p>
            <h2>Simple e-sign vs qualified e-signatures</h2>
            <ul>
            <li><strong>Simple / advanced electronic signatures</strong> — common in US (ESIGN, UETA), UK, India, Australia, and EU for many B2B contracts. Often satisfied by click-to-accept, typed name, or drawn signature on a reputable platform.</li>
            <li><strong>Qualified electronic signatures (QES)</strong> — required for some EU public-sector and regulated transactions under eIDAS. Uses certificate-based crypto and identity verification from a trusted provider.</li>
            <li><strong>Wet ink</strong> — still required for some property transfers, wills, and notarized documents depending on country and state law.</li>
            </ul>
            <p>When in doubt on high-value or regulated deals (real estate, lending, healthcare consent), consult local counsel — do not rely on a free browser tool alone.</p>
            <h2>When RatPDF typed signatures are appropriate</h2>
            <ul>
            <li>Low-to-medium value B2B agreements with existing business relationship</li>
            <li>PDFs that already went through negotiation via email</li>
            <li>Documents where your jurisdiction treats PDF + identity evidence as sufficient</li>
            <li>Internal policies where HR/legal has approved electronic acceptance</li>
            </ul>
            <h2>When to use a dedicated e-sign platform</h2>
            <ul>
            <li>Multi-party signing order and reminders</li>
            <li>Tamper-evident audit trail with signer IP, timestamp, and certificate</li>
            <li>Regulated QES or identity-verified signing</li>
            <li>Consumer contracts where local law mandates specific disclosure steps</li>
            </ul>
            <h2>Practical workflow on RatPDF</h2>
            <ol>
            <li>Export or <a href="/PDF/Merge">merge</a> the final contract PDF.</li>
            <li>Optional: <a href="/PDF/Watermark">watermark</a> as DRAFT until all parties agree.</li>
            <li>Open <a href="/PDF/SignText">Sign PDF</a>, place name, title, and date on the signature line.</li>
            <li><a href="/PDF/Password">Password-protect</a> before email if the file contains personal or financial data.</li>
            <li>Keep the signing email thread and download record as supporting evidence.</li>
            </ol>
            <h2>India, UK, and US quick notes</h2>
            <p><strong>India</strong> — the IT Act recognises electronic signatures for many commercial documents; stamp duty and specific statutes may still require physical execution for some instruments.</p>
            <p><strong>United Kingdom</strong> — electronic signatures are generally valid for contracts under the Electronic Communications Act and common law, subject to document type.</p>
            <p><strong>United States</strong> — ESIGN and state UETA frameworks support electronic records for most commercial agreements; real estate, UCC goods over certain thresholds, and wills often have exceptions.</p>
            <p>This is general information, not legal advice.</p>
            <h2>Related reading</h2>
            <p>Tool walkthrough: <a href="/guides/sign-pdf">sign PDF guide</a>. Security layer: <a href="/guides/watermark-vs-password-pdf">watermark vs password</a>. Full hub: <a href="/guides/secure-pdf-workflow">secure PDF workflow</a>.</p>
            <p><a href="/PDF/SignText">Sign PDF now →</a></p>
            """;

        private const string PdfToolAlternatives = """
            <h2>Why PDF tool alternatives matter</h2>
            <p>iLovePDF, Smallpdf, PDF24, Adobe Acrobat Online, Sejda, and Foxit dominate head terms like <em>merge pdf</em>, <em>compress pdf</em>, and <em>pdf to word</em>. RatPDF targets the same jobs with transparent free limits, production engines, and editorial guides — not thin single-purpose landings.</p>
            <h2>Quick comparison matrix</h2>
            <div class="table-responsive"><table class="table table-bordered">
            <thead><tr><th>Vendor</th><th>Free tier pain point</th><th>RatPDF angle</th></tr></thead>
            <tbody>
            <tr><td><a href="/compare/ilovepdf-alternative">iLovePDF</a></td><td>Daily limits; Pro for OCR/e-sign</td><td>22+ tools + guides on one domain</td></tr>
            <tr><td><a href="/compare/smallpdf-alternative">Smallpdf</a></td><td>2 tasks/day across all tools</td><td>3 uses per tool/day; 4 GB Pro uploads</td></tr>
            <tr><td><a href="/compare/pdf24-alternative">PDF24</a></td><td>Dated UX; desktop upsell</td><td>Modern hub + invoice PDF workflow</td></tr>
            <tr><td><a href="/compare/adobe-acrobat-alternative">Adobe Acrobat</a></td><td>Account + very limited free</td><td>No install; free tier without Adobe ID</td></tr>
            <tr><td><a href="/compare/sejda-alternative">Sejda</a></td><td>3 tasks/hour; page caps</td><td>Merge, compress, and convert tools</td></tr>
            <tr><td><a href="/compare/foxit-alternative">Foxit</a></td><td>Desktop-first funnel</td><td>Browser-first SMB workflow</td></tr>
            <tr><td><a href="/compare/sodapdf-alternative">Soda PDF</a></td><td>Watermark; subscription push</td><td>Transparent free tier + guides</td></tr>
            <tr><td><a href="/compare/pdf-candy-alternative">PDF Candy</a></td><td>Fragmented tool pages</td><td>Unified hub + invoice workflow</td></tr>
            </tbody></table></div>
            <h2>Keyword gaps we cover</h2>
            <ul>
            <li><strong>Organize / combine PDF</strong> — <a href="/pdf/merge">Merge PDF</a> + <a href="/guides/merge-pdf">guide</a></li>
            <li><strong>Compress to 100KB / 1MB</strong> — <a href="/compress-pdf-to-100kb">100KB landing</a>, <a href="/compress-pdf-to-1mb">1MB landing</a></li>
            <li><strong>PDF to JPG</strong> — <a href="/pdf/pdftoimages">PDF to Images</a></li>
            <li><strong>Alternative queries</strong> — dedicated <a href="/compare">comparison hub</a></li>
            <li><strong>Business PDFs</strong> — <a href="/invoice/create">Invoice generator</a> → compress → email</li>
            </ul>
            <h2>Convert without Adobe</h2>
            <ul>
            <li><a href="/guides/word-to-pdf-without-adobe">Word to PDF without Adobe</a></li>
            <li><a href="/guides/excel-to-pdf-without-adobe">Excel to PDF without Adobe</a></li>
            <li><a href="/guides/pdf-to-excel-without-adobe">PDF to Excel without Adobe</a></li>
            <li><a href="/guides/extract-text-without-adobe">Extract text without Adobe</a></li>
            <li><a href="/guides/extract-images-from-pdf-without-adobe">Extract images without Adobe</a></li>
            <li><a href="/guides/html-to-pdf-without-adobe">HTML to PDF without Adobe</a></li>
            </ul>
            <h2>Migration checklist</h2>
            <ol>
            <li>Bookmark <a href="/guides/pdf-tools">PDF tools hub</a> and your top 3 tools.</li>
            <li>Run one representative file on the free tier (size, scans, forms).</li>
            <li>Read the relevant <a href="/compare">comparison page</a> for your old vendor.</li>
            <li>Upgrade to Pro if you hit daily limits or need 4 GB uploads.</li>
            </ol>
            <h2>Compare PDF tools</h2>
            <p>See feature tables and FAQs for RatPDF vs iLovePDF, Smallpdf, Adobe, and others at <a href="/compare">ratpdf.com/compare</a>.</p>
            <p><a href="/guides/pdf-tools">Browse all PDF tools →</a></p>
            """;
    }
}
