namespace ratpdf.Content
{
    internal static class GuideBodiesExtended
    {
        public static string? Get(string slug) => slug switch
        {
            "pdf-to-powerpoint" => PdfToPowerPoint,
            "powerpoint-to-pdf" => PowerPointToPdf,
            "html-to-pdf" => HtmlToPdf,
            "pdf-to-markdown" => PdfToMarkdown,
            "pdf-redaction" => PdfRedaction,
            "compress-pdf-email-limits" => CompressEmailLimits,
            "pdf-tools-for-lawyers" => PdfForLawyers,
            "pdf-tools-for-accountants" => PdfForAccountants,
            "pdf-tools-for-students" => PdfForStudents,
            "choose-pdf-tool" => ChoosePdfTool,
            _ => null
        };

        private const string PdfToPowerPoint = """
            <h2>When to convert PDF to PowerPoint</h2>
            <p>Investor decks, training PDFs, and exported slide handouts often need to become editable PPTX files for your team. RatPDF maps each PDF page to a PowerPoint slide so you can reorder, annotate, or present without rebuilding from scratch.</p>
            <h2>How conversion works</h2>
            <ol>
            <li>Upload the PDF to <a href="/pdf/pdftoppt">PDF to PowerPoint</a>.</li>
            <li>RatPDF tries LibreOffice import first, then falls back to high-fidelity page images on each slide.</li>
            <li>Download PPTX and open in Microsoft PowerPoint, Google Slides, or Keynote.</li>
            </ol>
            <h2>Best results</h2>
            <ul>
            <li>Landscape PDFs match standard slide aspect ratios cleanly.</li>
            <li>Digital PDFs with vector text convert faster than 200 DPI scans.</li>
            <li>For scanned decks, run <a href="/guides/ocr-pdf">OCR PDF</a> first if you need searchable slide text.</li>
            </ul>
            <h2>Related workflows</h2>
            <p>Export slides back to PDF with <a href="/guides/powerpoint-to-pdf">PowerPoint to PDF</a>. Shrink large decks via <a href="/guides/compress-pdf-guide">Compress PDF</a> after export.</p>
            <p><a href="/pdf/pdftoppt">Convert PDF to PowerPoint →</a></p>
            """;

        private const string PowerPointToPdf = """
            <h2>Share slides as fixed-layout PDF</h2>
            <p>Clients, courts, and procurement teams often require PDF — not editable PPTX. RatPDF exports PowerPoint files with LibreOffice Impress using print-accurate settings: slide dimensions, embedded fonts, and high-quality image compression.</p>
            <h2>Before you upload</h2>
            <ul>
            <li>Embed fonts in PowerPoint (<em>File → Options → Save → Embed fonts</em>).</li>
            <li>Hide speaker notes if recipients should see slides only.</li>
            <li>Check slide size (16:9 vs 4:3) matches your brand template.</li>
            </ul>
            <h2>After export</h2>
            <p>Add a <a href="/guides/watermark-pdf">DRAFT watermark</a> during review, then <a href="/guides/password-protect-pdf">password-protect</a> the final tender pack. Large decks may need <a href="/guides/compress-pdf-guide">compression</a> before email — see our <a href="/research/attachment-size-limits">attachment limits table</a>.</p>
            <p><a href="/pdf/ppttopdf">Convert PowerPoint to PDF →</a></p>
            """;

        private const string HtmlToPdf = """
            <h2>HTML to PDF for developers and marketers</h2>
            <p>Export landing pages, email templates, receipts, and saved .html files as print-ready PDFs. RatPDF uses the <strong>iText html2pdf</strong> engine with Noto fonts for reliable Unicode (₹, €, CJK where supported).</p>
            <h2>What converts well</h2>
            <ul>
            <li>Self-contained HTML with inline or embedded CSS</li>
            <li>Invoice and receipt templates with tables</li>
            <li>Static reports exported from BI tools as HTML</li>
            </ul>
            <h2>Common pitfalls</h2>
            <ul>
            <li>External stylesheets with relative paths may not resolve — use absolute URLs or inline CSS.</li>
            <li>Web fonts must be reachable or embedded in the HTML.</li>
            <li>JavaScript-rendered content is not executed — export static HTML first.</li>
            </ul>
            <p>Compare with <a href="/guides/word-to-pdf">Word to PDF</a> for office documents and <a href="/pdf/texttopdf">Text to PDF</a> for plain notes.</p>
            <p><a href="/pdf/htmltopdf">Convert HTML to PDF →</a></p>
            """;

        private const string PdfToMarkdown = """
            <h2>PDF to Markdown for docs and dev workflows</h2>
            <p>Move documentation, research papers, and exported reports into GitHub, Notion, Obsidian, or static site generators. RatPDF extracts text page-by-page into <code>.md</code> sections with headings per page.</p>
            <h2>Ideal use cases</h2>
            <ul>
            <li>Technical manuals with a real text layer (not pure scans)</li>
            <li>Policy PDFs you want to diff in Git</li>
            <li>Blog drafts archived as PDF that need re-editing in Markdown</li>
            </ul>
            <h2>When to use other tools</h2>
            <p>Scanned PDFs need <a href="/guides/ocr-pdf">OCR PDF</a> first. Complex layouts with tables may convert cleaner via <a href="/guides/pdf-to-word">PDF to Word</a>, then paste into your editor.</p>
            <p><a href="/pdf/pdftomarkdown">Convert PDF to Markdown →</a></p>
            """;

        private const string PdfRedaction = """
            <h2>Permanent redaction vs black boxes</h2>
            <p>Drawing black rectangles in a PDF editor is <em>not</em> redaction — text often remains copyable underneath. True redaction removes content from the PDF object stream so it cannot be recovered.</p>
            <h2>When to redact</h2>
            <ul>
            <li>Disclosing contracts with third-party pricing removed</li>
            <li>FOIA-style releases with personal data stripped</li>
            <li>Medical or financial records shared with partial fields hidden</li>
            </ul>
            <h2>RatPDF redaction workflow</h2>
            <ol>
            <li>Open <a href="/pdf-redaction">PDF Redaction</a> and upload the file.</li>
            <li>Mark regions to permanently remove.</li>
            <li>Download the redacted PDF and verify with Select All / search that hidden text is gone.</li>
            </ol>
            <p>Combine with <a href="/guides/password-protect-pdf">password protection</a> for defense in depth. Read <a href="/blog/pdf-redaction-vs-password">redaction vs password</a> for the difference.</p>
            """;

        private const string CompressEmailLimits = """
            <h2>Email attachment limits in 2026</h2>
            <p>Gmail and Outlook typically cap attachments at <strong>25 MB</strong>; many corporate gateways cut lower. Government and job portals often enforce 2–10 MB. Our <a href="/research/attachment-size-limits">full reference table</a> lists official limits.</p>
            <h2>Step-by-step: fit your PDF in email</h2>
            <ol>
            <li>Check file size — aim under 20 MB for safety margin.</li>
            <li>Run <a href="/pdf/compress">Compress PDF</a> on medium; switch to high only if still over limit.</li>
            <li>If compression blurs fine print, <a href="/guides/split-pdf">split</a> into Part 1 / Part 2 instead.</li>
            <li>Use <a href="/pdf-size-checker">Will My PDF Fit?</a> to pick Gmail vs portal targets.</li>
            </ol>
            <h2>Long-tail landing pages</h2>
            <ul>
            <li><a href="/compress-pdf-for-email">Compress PDF for email</a></li>
            <li><a href="/compress-pdf-to-1mb">Compress to 1 MB</a></li>
            <li><a href="/compress-pdf-to-10mb">Compress to 10 MB</a></li>
            </ul>
            """;

        private const string PdfForLawyers = """
            <h2>PDF tools for legal workflows</h2>
            <p>Law firms handle contracts, discovery packs, court filings, and client redlines daily. RatPDF covers merge, Bates-style page numbers, redaction, password protection, and PDF to Word for markup — without Adobe seat licenses for every paralegal.</p>
            <h2>Recommended stack</h2>
            <ul>
            <li><strong>Combine exhibits</strong> — <a href="/pdf/merge">Merge PDF</a></li>
            <li><strong>Redact privileged content</strong> — <a href="/guides/pdf-redaction">PDF redaction guide</a></li>
            <li><strong>Convert for counsel review</strong> — <a href="/pdf/pdftodoc">PDF to Word</a></li>
            <li><strong>File size for e-filing</strong> — <a href="/guides/compress-pdf-email-limits">compress for portals</a></li>
            </ul>
            <p>See our curated <a href="/pdf-tools-for-lawyers">PDF tools for lawyers</a> landing page for the full toolkit.</p>
            """;

        private const string PdfForAccountants = """
            <h2>PDF tools for accountants and bookkeepers</h2>
            <p>Bank statements, GST returns, and client workpapers arrive as PDF. You need tables in Excel, read-only reports for boards, and compressed archives for email.</p>
            <h2>Core workflows</h2>
            <ul>
            <li><a href="/pdf/pdftoexcel">PDF to Excel</a> for statement tables</li>
            <li><a href="/pdf/exceltopdf">Excel to PDF</a> for board packs</li>
            <li><a href="/invoice/create">Invoice generator</a> for GST-compliant PDF invoices</li>
            <li><a href="/gst-invoice-checker">GST invoice checker</a> before sending</li>
            </ul>
            <p>Browse <a href="/pdf-tools-for-accountants">PDF tools for accountants</a> for role-specific shortcuts.</p>
            """;

        private const string PdfForStudents = """
            <h2>PDF tools for students and researchers</h2>
            <p>From lecture slides to journal PDFs, students merge readings, OCR scans, extract quotes to Word, and shrink files for submission portals.</p>
            <h2>Study toolkit</h2>
            <ul>
            <li><a href="/pdf/merge">Merge PDF</a> — combine weekly readings</li>
            <li><a href="/pdf/ocrpdf">OCR PDF</a> — searchable scans for Ctrl+F</li>
            <li><a href="/pdf/pdftodoc">PDF to Word</a> — pull quotes with citation cleanup</li>
            <li><a href="/pdf/pdftomarkdown">PDF to Markdown</a> — notes in Obsidian/Notion</li>
            </ul>
            <p>Full list: <a href="/pdf-tools-for-students">PDF tools for students</a>.</p>
            """;

        private const string ChoosePdfTool = """
            <h2>How to choose a PDF tool in 2026</h2>
            <p>Dozens of sites offer merge, compress, and convert. Pick based on <strong>free limits</strong>, <strong>file size caps</strong>, <strong>security</strong>, and whether you need one vendor or a full toolkit.</p>
            <h2>Decision checklist</h2>
            <ol>
            <li><strong>Daily volume</strong> — occasional (free tier) vs agency (Pro / API)</li>
            <li><strong>Max file size</strong> — 200 MB free vs 4 GB Pro on RatPDF</li>
            <li><strong>Install required</strong> — browser-only vs desktop (Foxit, Adobe)</li>
            <li><strong>Security</strong> — HTTPS, auto-delete, password never logged</li>
            <li><strong>Content depth</strong> — guides and compare pages vs thin tool pages</li>
            </ol>
            <h2>Vendor comparison pages</h2>
            <ul>
            <li><a href="/compare/ilovepdf-alternative">iLovePDF alternative</a></li>
            <li><a href="/compare/smallpdf-alternative">Smallpdf alternative</a></li>
            <li><a href="/compare/adobe-acrobat-alternative">Adobe Acrobat alternative</a></li>
            <li><a href="/compare/sodapdf-alternative">Soda PDF alternative</a></li>
            <li><a href="/compare/pdf-candy-alternative">PDF Candy alternative</a></li>
            </ul>
            <p>Full matrix: <a href="/compare">Compare all PDF tools</a> · Research: <a href="/research/pdf-tool-market-comparison">2026 market comparison study</a></p>
            """;
    }
}
