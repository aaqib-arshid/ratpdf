namespace ratpdf.Constants
{
    /// <summary>Unique long-form SEO sections per tool (AdSense-quality, non-duplicated).</summary>
    public static class PdfToolSeoArticles
    {
        public static string? ForTool(string? toolId) => toolId?.ToLowerInvariant() switch
        {
            "doctopdf" => DocToPdf,
            "pdftoexcel" => PdfToExcel,
            "exceltopdf" => ExcelToPdf,
            "pdftoppt" => PdfToPpt,
            "ppttopdf" => PptToPdf,
            "compress" => Compress,
            "merge" => Merge,
            "split" => Split,
            "pdftotext" => PdfToText,
            "unlockpdf" => UnlockPdf,
            "flattenpdf" => FlattenPdf,
            "pdftoimages" => PdfToImages,
            "extractimages" => ExtractImages,
            "ocrpdf" => OcrPdf,
            "pagenumbers" => PageNumbers,
            "pdfmetadata" => PdfMetadata,
            "signpdf" => SignPdf,
            "watermark" => Watermark,
            "htmltopdf" => HtmlToPdf,
            "pdftomarkdown" => PdfToMarkdown,
            _ => null
        };

        private const string PdfToMarkdown = """
            <h2 class='h4 fw-semibold mt-4'>When PDF to Markdown helps</h2>
            <p>Move documentation, research papers, and exported reports into GitHub, Notion, or static site generators. RatPDF extracts text page-by-page into <code>.md</code> sections.</p>
            <h2 class='h4 fw-semibold mt-4'>Best results</h2>
            <ul>
            <li>Digital PDFs with a real text layer convert cleanly.</li>
            <li>Run <strong>OCR PDF</strong> first on scanned documents.</li>
            <li>Complex layouts may need manual heading cleanup after export.</li>
            </ul>
            """;

        private const string HtmlToPdf = """
            <h2 class='h4 fw-semibold mt-4'>When to use HTML to PDF</h2>
            <p>Export email templates, landing-page snippets, or saved .html files as PDFs for client sign-off, archival, or print. RatPDF uses the <strong>iText html2pdf</strong> engine with embedded Noto fonts for reliable Unicode rendering.</p>
            <h2 class='h4 fw-semibold mt-4'>Tips for clean output</h2>
            <ul>
            <li>Include a full HTML document with <code>&lt;html&gt;</code> and <code>&lt;body&gt;</code> for complex CSS.</li>
            <li>Use inline or embedded CSS — external stylesheets may not resolve unless paths are absolute.</li>
            <li>For invoices or reports, test once with your brand colors before batch conversion.</li>
            </ul>
            """;

        private const string DocToPdf = """
            <h2 class='h4 fw-semibold mt-4'>When Word to PDF goes wrong</h2>
            <p>Exporting from Microsoft Word often shifts margins, drops embedded fonts, or rasterizes tables. RatPDF routes DOCX through <strong>LibreOffice headless</strong> — the same class of engine used in enterprise document servers — so page breaks, header graphics, and numbered lists survive the trip to PDF.</p>
            <h2 class='h4 fw-semibold mt-4'>Best practices before you convert</h2>
            <ul>
            <li>Embed fonts in Word (<em>File → Options → Save → Embed fonts</em>) when sharing brand templates.</li>
            <li>Use DOCX, not legacy DOC, for the most reliable table and image handling.</li>
            <li>Flatten complex SmartArt only if the PDF preview looks wrong — most diagrams convert cleanly.</li>
            <li>For court filings or tenders, open the PDF once and confirm pagination before submitting.</li>
            </ul>
            <h2 class='h4 fw-semibold mt-4'>Typical use cases</h2>
            <div class='row g-3 mt-2'>
            <div class='col-md-6'><div class='p-3 bg-light rounded-3 h-100'><strong>Client proposals</strong><br><span class='text-muted small'>Lock layout so reviewers see exactly what you designed</span></div></div>
            <div class='col-md-6'><div class='p-3 bg-light rounded-3 h-100'><strong>Invoices &amp; letters</strong><br><span class='text-muted small'>Company letterhead and tables stay aligned</span></div></div>
            <div class='col-md-6'><div class='p-3 bg-light rounded-3 h-100'><strong>HR policies</strong><br><span class='text-muted small'>Long documents with styles and TOC</span></div></div>
            <div class='col-md-6'><div class='p-3 bg-light rounded-3 h-100'><strong>Academic submissions</strong><br><span class='text-muted small'>Figures and captions preserved for review</span></div></div>
            </div>
            """;

        private const string PdfToExcel = """
            <h2 class='h4 fw-semibold mt-4'>Extract tables, not just text</h2>
            <p>Spreadsheet exports from basic PDF tools paste values into a single column. RatPDF detects <strong>lattice and stream tables</strong>, rebuilds cell borders where possible, and falls back to structured CSV-style output when a PDF was scanned or flattened.</p>
            <h2 class='h4 fw-semibold mt-4'>Works well for</h2>
            <ul>
            <li>Bank statements and transaction grids</li>
            <li>GST / VAT summary tables from invoices</li>
            <li>Price lists and inventory sheets embedded in PDF reports</li>
            <li>Survey results published as PDF appendices</li>
            </ul>
            <h2 class='h4 fw-semibold mt-4'>Tips for cleaner Excel output</h2>
            <ol>
            <li>Start from the <strong>original digital PDF</strong> (exported from Excel or accounting software) rather than a print-to-PDF copy.</li>
            <li>If the PDF is a scan, expect image-based pages — use <a href='/PDF/PdfToDoc'>PDF to Word</a> with OCR first, then copy tables.</li>
            <li>Merge multi-part statements with <a href='/PDF/Merge'>Merge PDF</a> before converting so row order stays intact.</li>
            </ol>
            """;

        private const string ExcelToPdf = """
            <h2 class='h4 fw-semibold mt-4'>Spreadsheets that print correctly</h2>
            <p>RatPDF converts XLSX to PDF using LibreOffice print layout rules: sheet scale, print areas, repeated header rows, and chart objects are honoured where the source file defines them. This is ideal when recipients must not edit figures.</p>
            <h2 class='h4 fw-semibold mt-4'>Before you upload</h2>
            <ul>
            <li>Set print area in Excel (<em>Page Layout → Print Area</em>) to avoid blank pages.</li>
            <li>Fit wide sheets to one page width if you share financial models externally.</li>
            <li>Replace external links with values if the PDF is archived long-term.</li>
            </ul>
            <h2 class='h4 fw-semibold mt-4'>Common workflows</h2>
            <p>Finance teams publish monthly P&amp;L PDFs for leadership, recruiters share read-only compensation bands, and operations attach equipment checklists to work orders. After PDF export, <a href='/PDF/Compress'>compress</a> large workbooks or <a href='/PDF/Password'>password-protect</a> sensitive packs.</p>
            """;

        private const string PdfToPpt = """
            <h2 class='h4 fw-semibold mt-4'>When PDF to PowerPoint helps</h2>
            <p>Reuse content from PDF reports, pitch decks, and training materials in editable slides. RatPDF converts each PDF page into a PowerPoint slide so you can annotate, reorder, or present without rebuilding from scratch.</p>
            <h2 class='h4 fw-semibold mt-4'>Best results</h2>
            <ul>
            <li>Landscape PDFs map cleanly to standard slide dimensions.</li>
            <li>Digital PDFs with vector text convert faster than heavy scan files.</li>
            <li>For scanned decks, run <a href='/pdf/ocrpdf'>OCR PDF</a> first if you need searchable text on slides.</li>
            </ul>
            """;

        private const string PptToPdf = """
            <h2 class='h4 fw-semibold mt-4'>Share slides as fixed-layout PDF</h2>
            <p>RatPDF exports PPTX to PDF using LibreOffice Impress with high-quality image compression and preserved slide aspect ratio — ideal for client email, print handouts, and tender submissions.</p>
            <h2 class='h4 fw-semibold mt-4'>Before you upload</h2>
            <ul>
            <li>Embed fonts in PowerPoint (<em>File → Options → Save → Embed fonts</em>) for consistent PDF typography.</li>
            <li>Hide speaker notes if you only want slide content in the PDF.</li>
            <li>Compress the result with <a href='/pdf/compress'>Compress PDF</a> for email attachments.</li>
            </ul>
            """;

        private const string Compress = """
            <h2 class='h4 fw-semibold mt-4'>How RatPDF compression works</h2>
            <p>We run <strong>Ghostscript</strong> with tuned DPI and image recompression profiles. You pick a level — lighter passes keep text crisp for archiving; stronger passes target email attachments under provider size caps.</p>
            <h2 class='h4 fw-semibold mt-4'>Choose the right level</h2>
            <ul>
            <li><strong>Low</strong> — minimal quality loss; good for contracts and forms.</li>
            <li><strong>Medium</strong> — balanced; typical 40–70% reduction on image-heavy PDFs.</li>
            <li><strong>High</strong> — smallest files; best for previews and mobile sharing.</li>
            </ul>
            <p>Scanned documents compress dramatically because photos of pages dominate file size. For multi-file bundles, <a href='/PDF/Merge'>merge</a> first, then compress once.</p>
            """;

        private const string Merge = """
            <h2 class='h4 fw-semibold mt-4'>Combine PDFs without re-encoding everything</h2>
            <p>RatPDF merges using <strong>iText smart mode</strong> so pages are appended in order without rasterizing vector content. Bookmarks from source files are preserved when possible.</p>
            <h2 class='h4 fw-semibold mt-4'>Practical scenarios</h2>
            <ul>
            <li>Append signed signature pages to a contract pack</li>
            <li>Bundle invoice + delivery note + payment proof for accounting</li>
            <li>Join lecture slides exported as separate PDFs</li>
            </ul>
            <p>Need the opposite? Use <a href='/PDF/Split'>Split PDF</a> to extract chapters before merging a custom order.</p>
            """;

        private const string Split = """
            <h2 class='h4 fw-semibold mt-4'>Extract exactly the pages you need</h2>
            <p>Split by range (<code>1-3, 7, 10-12</code>) or pull every page into its own file. RatPDF copies page content directly — fonts and vector graphics stay sharp.</p>
            <h2 class='h4 fw-semibold mt-4'>When splitting helps</h2>
            <ul>
            <li>Share only the signature page from a 40-page agreement</li>
            <li>Pull exhibits out of a regulatory filing</li>
            <li>Break scanned batch scans into separate receipts</li>
            </ul>
            """;

        private const string PdfToText = """
            <h2 class='h4 fw-semibold mt-4'>Plain text for search, quotes, and AI workflows</h2>
            <p>RatPDF extracts Unicode text from digital PDFs and applies OCR on scanned pages when Tesseract is available on the server. Output is clean UTF-8 text you can paste into editors, CMS fields, or translation tools.</p>
            <h2 class='h4 fw-semibold mt-4'>Limitations to know</h2>
            <p>Multi-column magazines and footnotes may need manual cleanup. For editable layout, use <a href='/PDF/PdfToDoc'>PDF to Word</a> instead of raw text.</p>
            """;

        private const string UnlockPdf = """
            <h2 class='h4 fw-semibold mt-4'>When you need to unlock a PDF</h2>
            <p>Password-protected PDFs block printing, copying, or opening without a passphrase. If you <strong>know the password</strong> but need an unencrypted copy for archiving, email, or downstream tools, RatPDF removes the encryption layer with iText — without re-rasterizing pages.</p>
            <h2 class='h4 fw-semibold mt-4'>Owner vs user passwords</h2>
            <ul>
            <li><strong>User password</strong> — required to open the file.</li>
            <li><strong>Owner password</strong> — restricts editing/printing even when the file opens.</li>
            </ul>
            <p>Enter whichever password the PDF prompts for. After unlocking, use <a href='/PDF/Compress'>Compress PDF</a> or <a href='/PDF/Merge'>Merge PDF</a> on the decrypted file.</p>
            <h2 class='h4 fw-semibold mt-4'>Legal &amp; ethical use</h2>
            <p>Only unlock documents you own or are authorized to access. RatPDF does not bypass unknown passwords or crack encryption.</p>
            """;

        private const string FlattenPdf = """
            <h2 class='h4 fw-semibold mt-4'>Why flatten interactive PDFs</h2>
            <p>Fillable PDF forms keep field values in a separate layer — recipients can still tab between boxes or change answers. <strong>Flattening</strong> merges those values into the page so the document behaves like a flat scan.</p>
            <h2 class='h4 fw-semibold mt-4'>Common workflows</h2>
            <ul>
            <li>IRS/tax forms after data entry</li>
            <li>HR onboarding packets with typed signatures</li>
            <li>Insurance claims before portal upload</li>
            <li>Design proofs with approval stamps</li>
            </ul>
            <p>Pair with <a href='/PDF/Password'>Password Protect PDF</a> after flattening if the final pack must stay read-only.</p>
            """;

        private const string PdfToImages = """
            <h2 class='h4 fw-semibold mt-4'>PDF pages as PNG images</h2>
            <p>RatPDF renders each page with <strong>PyMuPDF</strong> at your chosen DPI. PNG output preserves sharp text and UI screenshots — better than lossy JPEG for diagrams and slides.</p>
            <h2 class='h4 fw-semibold mt-4'>Choose the right DPI</h2>
            <ul>
            <li><strong>96–120 DPI</strong> — thumbnails, Slack previews</li>
            <li><strong>150 DPI</strong> — default; good for web articles and decks</li>
            <li><strong>300 DPI</strong> — print inserts and archival page grabs</li>
            </ul>
            <p>Need editable text instead of pictures? Try <a href='/PDF/OcrPdf'>OCR PDF</a> or <a href='/PDF/PdfToDoc'>PDF to Word</a>.</p>
            """;

        private const string ExtractImages = """
            <h2 class='h4 fw-semibold mt-4'>Embedded images vs page screenshots</h2>
            <p>This tool pulls <strong>image objects stored inside</strong> the PDF — product photos, chart bitmaps, logos — not full-page renders. For slide decks exported as vector PDFs, you get the original raster assets when they were embedded.</p>
            <h2 class='h4 fw-semibold mt-4'>When extraction beats PDF to Images</h2>
            <ul>
            <li>Catalog PDFs with hundreds of product shots</li>
            <li>Marketing brochures with separate hero images</li>
            <li>Technical manuals with diagram PNGs</li>
            </ul>
            <p>For scanned books where each page is one bitmap, use <a href='/PDF/PdfToImages'>PDF to Images</a> instead.</p>
            """;

        private const string OcrPdf = """
            <h2 class='h4 fw-semibold mt-4'>Make scans searchable</h2>
            <p>Image-only PDFs look fine to humans but contain no selectable text. RatPDF runs <strong>Tesseract OCR</strong> server-side and adds an invisible text layer so you can search, copy, and highlight content in any PDF viewer.</p>
            <h2 class='h4 fw-semibold mt-4'>Scan quality tips</h2>
            <ol>
            <li>Scan at 300 DPI, black-and-white or grayscale for text forms</li>
            <li>Straighten pages — skew hurts recognition accuracy</li>
            <li>For multi-language docs, OCR works best when one dominant language is present</li>
            </ol>
            <p>After OCR, convert to Word with <a href='/PDF/PdfToDoc'>PDF to Word</a> or extract plain text with <a href='/PDF/PdfToText'>PDF to Text</a>.</p>
            """;

        private const string PageNumbers = """
            <h2 class='h4 fw-semibold mt-4'>Professional footer numbering</h2>
            <p>Reports, SOPs, and legal bundles often need consistent page labels. RatPDF stamps a footer on every page using your format string — <code>Page {page} of {total}</code> by default.</p>
            <h2 class='h4 fw-semibold mt-4'>Format tokens</h2>
            <ul>
            <li><code>{page}</code> — current page number (1-based)</li>
            <li><code>{total}</code> — total page count</li>
            </ul>
            <p>Combine with <a href='/PDF/Merge'>Merge PDF</a> before numbering if you are assembling chapters from multiple sources.</p>
            """;

        private const string PdfMetadata = """
            <h2 class='h4 fw-semibold mt-4'>What lives in PDF metadata</h2>
            <p>Every PDF carries a document information dictionary: title, author, subject, keywords, creator application, and timestamps. This data drives search indexes, DAM systems, and compliance audits.</p>
            <h2 class='h4 fw-semibold mt-4'>Practical checks</h2>
            <ul>
            <li>Confirm page count before court e-filing</li>
            <li>Verify author/creator fields before public release</li>
            <li>Batch-inspect archives before migration to ECM</li>
            </ul>
            <p>Export is JSON for scripting. For content edits, use <a href='/PDF/EditPDF'>Edit PDF</a> or conversion tools.</p>
            """;

        private const string SignPdf = """
            <h2 class='h4 fw-semibold mt-4'>Three ways to sign</h2>
            <p>Competitors like iLovePDF and Smallpdf offer type, draw, and upload flows — RatPDF matches that pattern. Pick the method that fits your device: keyboard for desktop, finger draw on mobile, or a scanned signature PNG.</p>
            <h2 class='h4 fw-semibold mt-4'>Placement options</h2>
            <ul>
            <li><strong>Last page</strong> — default for contracts and offer letters</li>
            <li><strong>All pages</strong> — initial every page of a short NDA</li>
            <li><strong>Bottom right / left / center</strong> — matches common signature blocks</li>
            </ul>
            <p>For password-protected PDFs, <a href='/pdf/unlockpdf'>Unlock PDF</a> first. To lock filled forms after signing, use <a href='/PDF/FlattenPdf'>Flatten PDF</a>.</p>
            """;

        private const string Watermark = """
            <h2 class='h4 fw-semibold mt-4'>Text vs image watermarks</h2>
            <p>Use diagonal text for DRAFT and CONFIDENTIAL labels. Upload a logo when you need brand presence without obscuring content — typical for photography proofs and internal reports.</p>
            <h2 class='h4 fw-semibold mt-4'>Opacity and layout</h2>
            <ul>
            <li><strong>Center diagonal</strong> — classic draft stamp across the page</li>
            <li><strong>Tiled repeat</strong> — harder to crop out on shared samples</li>
            <li><strong>Page range</strong> — watermark only the cover or appendix</li>
            </ul>
            <p>Watermarks are a deterrent, not encryption. For access control, combine with <a href='/PDF/Password'>Password Protect PDF</a>.</p>
            """;
    }
}
