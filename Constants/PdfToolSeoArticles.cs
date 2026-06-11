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
            "compress" => Compress,
            "merge" => Merge,
            "split" => Split,
            "pdftotext" => PdfToText,
            _ => null
        };

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
    }
}
