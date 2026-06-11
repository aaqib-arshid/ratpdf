namespace ratpdf.Content
{
    /// <summary>High-value HTML bodies for tool guides (AdSense-quality).</summary>
    internal static class GuideBodies
    {
        public static string? Get(string slug) => slug switch
        {
            "compress-pdf-guide" => CompressPdf,
            "merge-pdf" => MergePdf,
            "split-pdf" => SplitPdf,
            "pdf-to-word" => PdfToWord,
            "word-to-pdf" => WordToPdf,
            "pdf-to-excel" => PdfToExcel,
            "excel-to-pdf" => ExcelToPdf,
            "edit-pdf" => EditPdf,
            "pdf-txt-guide" or "pdf-to-text" => PdfToText,
            "text-to-pdf" => TextToPdf,
            "watermark-pdf" => WatermarkPdf,
            "password-protect-pdf" => PasswordPdf,
            "sign-pdf" => SignPdf,
            "rotate-pdf" => RotatePdf,
            "images-to-pdf" => ImagesToPdf,
            "background-remover" => BackgroundRemover,
            "word-counter-guide" => WordCounter,
            "ring-size-converter-guide" => RingSize,
            "my-ip-guide" => MyIp,
            "invoice-generator-guide" => InvoiceGenerator,
            _ => null
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
            <li>Scanned pages compress dramatically because photos dominate size — expect the biggest wins there.</li>
            <li>Keep an uncompressed archive copy before aggressive compression for long-term records.</li>
            </ul>
            <h2>When not to compress</h2>
            <p>Print-ready artwork, prepress PDFs, and files with embedded CAD vectors may lose subtle detail at High settings. For those, use Low or skip compression entirely.</p>
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
            <li>If one file is landscape and another portrait, rotate pages first with our <a href="/guides/rotate-pdf">rotate guide</a>.</li>
            <li>After merging a large pack, <a href="/guides/compress-pdf-guide">compress</a> for email.</li>
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
            <p>Watermarks are visual deterrents, not encryption. For sensitive data, also <a href="/guides/password-protect-pdf">password-protect</a> the file.</p>
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
            <p><a href="/PDF/Password">Protect PDF →</a></p>
            """;

        private const string SignPdf = """
            <h2>Add signature text to PDFs</h2>
            <p>Typed name, title, and date blocks formalise acceptance on quotes, SOWs, and internal approvals when wet ink is not required.</p>
            <h2>Not the same as eIDAS digital signatures</h2>
            <p>RatPDF adds visible signature <em>text</em> — suitable for many business workflows. Regulated qualified electronic signatures may need specialised providers.</p>
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
            <h2>Remove backgrounds without Photoshop</h2>
            <p>E-commerce sellers, resumé builders, and social creators need transparent PNGs fast. AI background removal works best on clear subject edges — hair and glass remain challenging.</p>
            <h2>When it works well</h2>
            <ul>
            <li>Product photos on plain white or grey</li>
            <li>Headshots with contrasting backgrounds</li>
            <li>Logos on solid colours</li>
            </ul>
            <h2>Export tips</h2>
            <p>Save as PNG for transparency. For PDF catalogues, place the cutout on a new page via <a href="/guides/images-to-pdf">Image to PDF</a>.</p>
            <p><a href="/Tools/ImgBackgroundRemove">Background remover tool →</a></p>
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
            <p><a href="/Invoice/Create">Create invoice →</a></p>
            """;
    }
}
