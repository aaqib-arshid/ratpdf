"""Wave 10 — Conversion depth: excel, html, markdown, jpg/png spokes and pillar upgrades."""

W10_SLUGS = [
    "pdf-to-excel",
    "excel-to-pdf",
    "pdf-to-images",
    "html-to-pdf",
    "pdf-to-markdown",
    "pdf-to-jpg-without-adobe",
    "pdf-to-png-without-adobe",
    "pdf-to-excel-without-adobe",
    "excel-to-pdf-without-adobe",
    "html-to-pdf-without-adobe",
    "pdf-to-markdown-without-adobe",
    "pdf-to-jpg-online",
    "pdf-to-png-online",
    "pdf-to-excel-online",
    "pdf-conversion-guide",
    "extract-tables-from-pdf",
    "html-to-pdf-email-template",
]

W10_DATA = {
    "pdf-to-excel": {
        "title": "PDF to Excel Converter — Extract Tables to XLSX Online (2026)",
        "tool": "/pdf/pdftoexcel",
        "label": "PDF to Excel",
        "example": "Finance analyst exports bank statement PDF tables into editable spreadsheet",
    },
    "excel-to-pdf": {
        "title": "Excel to PDF — Print-Accurate Spreadsheet Export Online (2026)",
        "tool": "/pdf/exceltopdf",
        "label": "Excel to PDF",
        "example": "Controller shares read-only monthly P&amp;L PDF with board",
    },
    "pdf-to-images": {
        "title": "PDF to Images — Export Pages as PNG or JPG Online (2026)",
        "tool": "/pdf/pdftoimages",
        "label": "PDF to Images",
        "example": "Designer pulls slide deck pages as PNG for social preview crops",
    },
    "html-to-pdf": {
        "title": "HTML to PDF — Convert Web Pages &amp; Templates Online (2026)",
        "tool": "/pdf/htmltopdf",
        "label": "HTML to PDF",
        "example": "Developer renders invoice email HTML template as attachable PDF",
    },
    "pdf-to-markdown": {
        "title": "PDF to Markdown — Export Docs for Git &amp; Notion Online (2026)",
        "tool": "/pdf/pdftomarkdown",
        "label": "PDF to Markdown",
        "example": "Tech writer migrates legacy PDF handbook into Obsidian wiki",
    },
    "pdf-to-jpg-without-adobe": {
        "title": "PDF to JPG Without Adobe — Free Page Export Online",
        "tool": "/pdf/pdftoimages",
        "label": "PDF to Images",
        "example": "Student saves textbook page as JPG for annotated study notes",
    },
    "pdf-to-png-without-adobe": {
        "title": "PDF to PNG Without Adobe — Free Transparent Page Export",
        "tool": "/pdf/pdftoimages",
        "label": "PDF to Images",
        "example": "E-commerce manager exports catalog page PNG without Acrobat install",
    },
    "pdf-to-excel-without-adobe": {
        "title": "PDF to Excel Without Adobe — Free Table Extraction Online",
        "tool": "/pdf/pdftoexcel",
        "label": "PDF to Excel",
        "example": "SMB bookkeeper extracts GST summary table without Pro subscription",
    },
    "excel-to-pdf-without-adobe": {
        "title": "Excel to PDF Without Adobe — Free XLSX Export Online",
        "tool": "/pdf/exceltopdf",
        "label": "Excel to PDF",
        "example": "Freelancer sends quote spreadsheet as locked PDF from Chromebook",
    },
    "html-to-pdf-without-adobe": {
        "title": "HTML to PDF Without Adobe — Free Browser Render",
        "tool": "/pdf/htmltopdf",
        "label": "HTML to PDF",
        "example": "Marketer converts saved newsletter HTML to PDF for client archive",
    },
    "pdf-to-markdown-without-adobe": {
        "title": "PDF to Markdown Without Adobe — Free Text Export for Wikis",
        "tool": "/pdf/pdftomarkdown",
        "label": "PDF to Markdown",
        "example": "Open-source maintainer imports PDF spec into GitHub docs folder",
    },
    "pdf-to-jpg-online": {
        "title": "PDF to JPG Online — Save Pages as JPEG in Browser",
        "tool": "/pdf/pdftoimages",
        "label": "PDF to Images",
        "example": "Insurance adjuster exports damage report page as JPG for CMS upload",
    },
    "pdf-to-png-online": {
        "title": "PDF to PNG Online — High-Quality Page Export in Browser",
        "tool": "/pdf/pdftoimages",
        "label": "PDF to Images",
        "example": "Agency exports pitch deck slide 3 as PNG for LinkedIn carousel",
    },
    "pdf-to-excel-online": {
        "title": "PDF to Excel Online — Convert Tables to Spreadsheet in Browser",
        "tool": "/pdf/pdftoexcel",
        "label": "PDF to Excel",
        "example": "Ops lead copies vendor price list PDF into Excel for pivot analysis",
    },
    "pdf-conversion-guide": {
        "title": "PDF Conversion Guide — Excel, HTML, Markdown &amp; Images Hub (2026)",
        "tool": "/guides/pdf-tools",
        "label": "PDF tools hub",
        "example": "Team wiki index for choosing the right RatPDF convert tool by deliverable",
    },
    "extract-tables-from-pdf": {
        "title": "Extract Tables from PDF — Spreadsheet Workflow &amp; Limits (2026)",
        "tool": "/pdf/pdftoexcel",
        "label": "PDF to Excel",
        "example": "Accountant pulls invoice line items from digital PDF into XLSX",
    },
    "html-to-pdf-email-template": {
        "title": "HTML to PDF for Email Templates — Render &amp; QA Workflow (2026)",
        "tool": "/pdf/htmltopdf",
        "label": "HTML to PDF",
        "example": "Email ops team proofs responsive receipt HTML as PDF before ESP deploy",
    },
}

W10_DEEP = {
    "pdf-to-excel": """
            <h2>When PDF to Excel wins</h2>
            <p>Bank statements, price lists, survey tables, and invoice line items — lattice tables with visible borders convert best. Single-column pasted text from PDF is useless for analysis — structured XLSX enables pivot tables and VLOOKUP.</p>
            <h2>Digital vs scanned PDFs</h2>
            <p>Digital exports from Excel or reporting tools preserve cell boundaries. Scanned statements need <a href="/pdf/ocrpdf">OCR PDF</a> first — verify numbers manually after export.</p>
            <h2>Step-by-step</h2>
            <ol>
            <li>Confirm text selects in viewer — if not, OCR first.</li>
            <li>Upload to <a href="/pdf/pdftoexcel">PDF to Excel</a>.</li>
            <li>Open XLSX — check merged cells and header rows.</li>
            <li>Fix column types (dates as dates, not text).</li>
            </ol>
            """,
    "excel-to-pdf": """
            <h2>When Excel to PDF wins</h2>
            <p>Read-only distribution — board packs, comp bands, client quotes — PDF prevents formula tampering. LibreOffice engine honours print areas where XLSX defines them.</p>
            <h2>Pre-export checklist</h2>
            <ol>
            <li><em>Page Layout → Print Area</em> set on each sheet.</li>
            <li>Fit wide models: <em>Fit All Columns on One Page</em> or hide helper columns.</li>
            <li>Replace external links with values for archival PDF.</li>
            <li>Charts: verify legend not clipped in print preview.</li>
            </ol>
            """,
    "pdf-to-images": """
            <h2>Page render vs extract embedded images</h2>
            <p><a href="/pdf/pdftoimages">PDF to Images</a> screenshots every page — slides, scans, full layouts. For photos inside a PDF object stream use <a href="/guides/extract-images-from-pdf">Extract Images</a>.</p>
            <h2>JPG vs PNG</h2>
            <p><strong>JPG</strong> — smaller, email and web. <strong>PNG</strong> — lossless, text-heavy slides, transparency. See <a href="/guides/pdf-to-jpg-online">JPG guide</a> and <a href="/guides/pdf-to-png-online">PNG guide</a>.</p>
            <h2>DPI</h2>
            <p>150 DPI default for web — 300 DPI when print-quality grab required.</p>
            """,
    "html-to-pdf": """
            <h2>HTML to PDF use cases</h2>
            <p>Email templates, static site exports, saved web pages, internal admin reports — iText html2pdf with Unicode font support on RatPDF.</p>
            <h2>CSS pitfalls</h2>
            <ul>
            <li>External stylesheets must be reachable or embedded</li>
            <li>Web fonts need @font-face or fallbacks</li>
            <li>Flex/grid may differ from Chrome print — test output page 1</li>
            <li>See <a href="/guides/html-to-pdf-email-template">email template guide</a></li>
            </ul>
            """,
    "pdf-to-markdown": """
            <h2>Markdown export philosophy</h2>
            <p>Structure over pixel fidelity — headings, paragraphs, and page breaks become .md sections for GitHub, Obsidian, Notion import, and static site generators.</p>
            <h2>Limits</h2>
            <p>Complex multi-column magazines lose layout — use <a href="/guides/pdf-to-word">PDF to Word</a> for heavy redesign. Scanned PDFs need OCR before meaningful Markdown.</p>
            """,
    "pdf-to-jpg-without-adobe": """
            <h2>Zero install path</h2>
            <p>Chromebook, locked-down corporate PC, travel laptop — browser export beats Acrobat subscription for occasional JPG pulls.</p>
            <h2>Quality tips</h2>
            <p>Text-heavy pages — PNG may be sharper; JPG fine for photo slides. Compress JPG before email if batch export large.</p>
            """,
    "pdf-to-png-without-adobe": """
            <h2>PNG when JPG fails</h2>
            <p>Fine text on slides, UI screenshots in PDF, diagrams with sharp edges — PNG avoids JPG ringing artifacts.</p>
            <h2>File size</h2>
            <p>PNG larger than JPG — zip batch downloads — compress only if re-bundling to PDF.</p>
            """,
    "pdf-to-excel-without-adobe": """
            <h2>Acrobat Pro alternative</h2>
            <p>Export PDF tables to XLSX in browser — three free uses/day — upgrade for AP automation volume.</p>
            <h2>Accuracy expectations</h2>
            <p>Digital PDF 90%+ on simple tables — merged cells and nested headers need manual cleanup — see <a href="/guides/extract-tables-from-pdf">extract tables guide</a>.</p>
            """,
    "excel-to-pdf-without-adobe": """
            <h2>Print-to-PDF trap</h2>
            <p>Excel print driver drops hyperlinks and shifts margins — dedicated <a href="/pdf/exceltopdf">Excel to PDF</a> tool preserves layout better.</p>
            <h2>LibreOffice engine</h2>
            <p>Server-side Calc export — verify complex charts on page 1 before sending client pack.</p>
            """,
    "html-to-pdf-without-adobe": """
            <h2>vs browser Print to PDF</h2>
            <p>Print captures viewport — HTML to PDF tool renders document object with CSS page rules — better for multi-page templates.</p>
            <h2>Developer path</h2>
            <p>API scale needs Puppeteer/Gotenberg — occasional template: RatPDF browser — blog <a href="/blog/html-to-pdf-developers">HTML to PDF API alternatives</a>.</p>
            """,
    "pdf-to-markdown-without-adobe": """
            <h2>Docs-as-code workflow</h2>
            <p>PDF spec → Markdown → PR to docs repo — version control beats static PDF for internal engineering handbooks.</p>
            <h2>Post-export cleanup</h2>
            <p>Fix heading levels, code blocks, and broken lists in editor — automation rarely perfect on legacy PDFs.</p>
            """,
    "pdf-to-jpg-online": """
            <h2>JPG workflow</h2>
            <ol>
            <li>Open <a href="/pdf/pdftoimages">PDF to Images</a> — select JPG format.</li>
            <li>Upload PDF — pick DPI (150 web, 300 print grab).</li>
            <li>Download single pages or ZIP batch.</li>
            <li>Verify text legibility at 100% zoom before CMS upload.</li>
            </ol>
            """,
    "pdf-to-png-online": """
            <h2>PNG workflow</h2>
            <ol>
            <li>PDF to Images — PNG format.</li>
            <li>Prefer PNG for slides with text and UI captures.</li>
            <li>Batch ZIP for deck export — rename <code>slide-01.png</code> convention.</li>
            </ol>
            """,
    "pdf-to-excel-online": """
            <h2>Online table extraction</h2>
            <p>Same engine as <a href="/guides/pdf-to-excel">PDF to Excel guide</a> — browser upload — download XLSX — no desktop install.</p>
            <h2>Bank statement pattern</h2>
            <p>Digital statement PDF → Excel → categorize in pivot — OCR path if scan-only — proofread opening balance row.</p>
            """,
    "pdf-conversion-guide": """
            <h2>Conversion decision matrix</h2>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>Need</th><th>Tool</th><th>Guide</th></tr></thead>
            <tbody>
            <tr><td>Editable document</td><td><a href="/pdf/pdftodoc">PDF to Word</a></td><td><a href="/guides/pdf-to-word">Word guide</a></td></tr>
            <tr><td>Spreadsheet tables</td><td><a href="/pdf/pdftoexcel">PDF to Excel</a></td><td><a href="/guides/pdf-to-excel">Excel guide</a></td></tr>
            <tr><td>Plain text / AI</td><td><a href="/pdf/pdftotext">PDF to Text</a></td><td><a href="/guides/pdf-txt-guide">Text guide</a></td></tr>
            <tr><td>Wiki / Git docs</td><td><a href="/pdf/pdftomarkdown">PDF to Markdown</a></td><td><a href="/guides/pdf-to-markdown">Markdown guide</a></td></tr>
            <tr><td>Web template PDF</td><td><a href="/pdf/htmltopdf">HTML to PDF</a></td><td><a href="/guides/html-to-pdf">HTML guide</a></td></tr>
            <tr><td>Slide / page images</td><td><a href="/pdf/pdftoimages">PDF to Images</a></td><td><a href="/guides/pdf-to-images">Images guide</a></td></tr>
            <tr><td>XLSX to locked PDF</td><td><a href="/pdf/exceltopdf">Excel to PDF</a></td><td><a href="/guides/excel-to-pdf">Excel export guide</a></td></tr>
            </tbody>
            </table></div>
            """,
    "extract-tables-from-pdf": """
            <h2>Table detection limits</h2>
            <p>Lattice borders help — borderless tables inferred from whitespace — multi-page tables may split awkwardly — manual stitch in Excel.</p>
            <h2>Workflow</h2>
            <ol>
            <li>Start from digital PDF not re-scanned fax.</li>
            <li><a href="/pdf/pdftoexcel">PDF to Excel</a> — inspect row 1 headers.</li>
            <li>Delete junk rows above table.</li>
            <li>Set number formats — dates especially.</li>
            </ol>
            """,
    "html-to-pdf-email-template": """
            <h2>Email HTML specifics</h2>
            <p>Inline CSS dominates ESP templates — external sheets often blocked — embed critical styles. Table layout still common in receipts — test Outlook width 600px.</p>
            <h2>QA checklist</h2>
            <ol>
            <li>Render HTML file via <a href="/pdf/htmltopdf">HTML to PDF</a></li>
            <li>Compare to Litmus/Email on Acid screenshot if available</li>
            <li>Verify logo and totals on page 1</li>
            <li>Archive PDF alongside HTML source in git tag</li>
            </ol>
            """,
}

W10_SLUG_EXTRA = {
    "pdf-to-excel": """
            <h2>Real example: card statement</h2>
            <p>Digital Amex PDF → Excel → pivot by merchant — categorize for tax — spot-check interest row.</p>
            <h2>Real example: vendor price list</h2>
            <p>20-page catalog PDF appendix — extract table pages 18-19 — VLOOKUP in procurement sheet.</p>
            """,
    "excel-to-pdf": """
            <h2>Real example: board pack</h2>
            <p>Three-tab model — print area per sheet — Excel to PDF — merge with narrative via <a href="/guides/merge-pdf">merge guide</a>.</p>
            """,
    "pdf-to-images": """
            <h2>Real example: slide social crop</h2>
            <p>Page 5 PNG at 150 DPI — crop in Figma — LinkedIn post — faster than rebuild slide in Canva.</p>
            """,
    "html-to-pdf": """
            <h2>Real example: contract HTML</h2>
            <p>SaaS terms page saved HTML → PDF attachment for enterprise procurement portal.</p>
            """,
    "pdf-to-markdown": """
            <h2>Real example: internal runbook</h2>
            <p>Legacy PDF ops guide → Markdown → docs/ folder → team edits via PR not email attachments.</p>
            """,
    "pdf-to-jpg-without-adobe": """
            <h2>Real example: homework submit</h2>
            <p>Portal wants JPG per question — PDF homework → JPG pages 1-3 — upload slots.</p>
            """,
    "pdf-to-png-without-adobe": """
            <h2>Real example: wiki screenshot</h2>
            <p>Manual PDF page 12 UI diagram → PNG → Confluence embed — crisp text.</p>
            """,
    "pdf-to-excel-without-adobe": """
            <h2>Real example: monthly GST</h2>
            <p>GSTR summary PDF → XLSX → accountant adjusts — re-export PDF for filing copy.</p>
            """,
    "excel-to-pdf-without-adobe": """
            <h2>Real example: recruiter comp band</h2>
            <p>XLSX band sheet → PDF → candidate email — formulas hidden from view.</p>
            """,
    "html-to-pdf-without-adobe": """
            <h2>Real example: newsletter archive</h2>
            <p>Campaign HTML export → PDF — compliance archive — not live web dependency.</p>
            """,
    "pdf-to-markdown-without-adobe": """
            <h2>Real example: API spec</h2>
            <p>Vendor PDF API doc → Markdown → internal fork — diffable in git.</p>
            """,
    "pdf-to-jpg-online": """
            <h2>Real example: CMS hero</h2>
            <p>Report PDF cover page → JPG 300 DPI — WordPress featured image — compress JPG if over 500 KB.</p>
            """,
    "pdf-to-png-online": """
            <h2>Real example: app store screenshot source</h2>
            <p>Help PDF page → PNG — design team adds device frame — store listing.</p>
            """,
    "pdf-to-excel-online": """
            <h2>Real example: survey results</h2>
            <p>Published report PDF table → Excel → researcher charts in Sheets.</p>
            """,
    "pdf-conversion-guide": """
            <h2>Chain conversions</h2>
            <p>Excel → PDF → email → recipient PDF to Excel — prefer native XLSX share when edits needed — PDF for lock, Excel for analysis.</p>
            """,
    "extract-tables-from-pdf": """
            <h2>Invoice line items</h2>
            <p>Digital invoice PDF — extract table — match PO in ERP — qty column spot-check.</p>
            """,
    "html-to-pdf-email-template": """
            <h2>Receipt template</h2>
            <p>Order confirmation HTML — PDF proof for legal — matches ESP sent version — store in S3 audit bucket.</p>
            """,
}

W10_MEGA = """
            <h2>Conversion cluster authority</h2>
            <p>Conversion guides for Excel, HTML, Markdown, and images complement Word and PowerPoint workflows. Pick the tool by what you need next: edit in Word, analyze in Excel, archive a page as PDF, store docs as Markdown, or export pages as images.</p>
            <h2>Common failure modes</h2>
            <p><strong>Garbled Excel cells:</strong> scan not OCR — <a href="/guides/pdf-to-word-garbled-text">garbled text</a>. <strong>HTML missing CSS:</strong> inline critical styles. <strong>Markdown wall of text:</strong> PDF lacked headings. <strong>Blurry JPG:</strong> raise DPI or use PNG.</p>
            <h2>Security</h2>
            <p>Financial PDFs and email HTML may contain PII — review <a href="/home/privacy">privacy policy</a> — clear Downloads on shared PCs.</p>
            """

W10_CLUSTER = """
            <h2>Conversion guides</h2>
            <ul>
            <li><a href="/guides/pdf-to-excel">PDF to Excel</a> · <a href="/guides/pdf-to-excel-online">PDF to Excel online</a> · <a href="/guides/extract-tables-from-pdf">Extract tables</a></li>
            <li><a href="/guides/excel-to-pdf">Excel to PDF</a> · <a href="/guides/excel-to-pdf-without-adobe">Excel without Adobe</a></li>
            <li><a href="/guides/pdf-to-images">PDF to Images</a> · <a href="/guides/pdf-to-jpg-online">JPG</a> · <a href="/guides/pdf-to-png-online">PNG</a></li>
            <li><a href="/guides/html-to-pdf">HTML to PDF</a> · <a href="/guides/html-to-pdf-email-template">Email templates</a></li>
            <li><a href="/guides/pdf-to-markdown">PDF to Markdown</a> · <a href="/guides/pdf-to-word">PDF to Word guide</a></li>
            </ul>
            <p>Hub: <a href="/guides/pdf-conversion-guide">PDF conversion guide</a> · <a href="/guides/pdf-tools">PDF tools</a> · <a href="/guides/pdf-troubleshooting">Troubleshooting</a>.</p>
            """

W10_1500_TOPUP = """
            <h2>QA after every conversion</h2>
            <ol>
            <li>Row 1 / page 1 spot-check against source PDF</li>
            <li>Numbers and dates formatted correctly in Excel</li>
            <li>HTML PDF: logo, totals, page break where expected</li>
            <li>Markdown: heading hierarchy sensible</li>
            <li>Images: text readable at intended display size</li>
            <li>File size acceptable for email or portal</li>
            </ol>
            <h2>Without Adobe index</h2>
            <p><a href="/guides/pdf-to-excel-without-adobe">Excel extract</a> · <a href="/guides/pdf-to-jpg-without-adobe">JPG</a> · <a href="/guides/pdf-to-png-without-adobe">PNG</a> · <a href="/guides/html-to-pdf-without-adobe">HTML</a> · <a href="/guides/pdf-to-markdown-without-adobe">Markdown</a> · <a href="/compare/adobe-acrobat-alternative">Adobe alternative</a>.</p>
            """

W10_PILLAR_TOPUP = """
            <h2>Pillar cross-links</h2>
            <p>Word path: <a href="/guides/pdf-to-word">PDF to Word</a>. Compress after large image export: <a href="/guides/compress-pdf-guide">compress guide</a>. OCR scans: <a href="/guides/ocr-pdf">OCR guide</a>.</p>
            """

W10_CLOSING = """
            <h2>Related guides</h2>
            <p>In-depth conversion guides for Excel, HTML, Markdown, and JPG/PNG — plus Adobe-free alternatives — each linked to the matching RatPDF tool.</p>
            <p>Security and compliance guides (redaction, GDPR, HIPAA) — or bookmark the <a href="/guides/pdf-conversion-guide">conversion hub</a>.</p>
            """

PILLAR_SLUGS = {"pdf-to-excel", "excel-to-pdf", "pdf-to-images", "html-to-pdf", "pdf-to-markdown", "pdf-conversion-guide"}
