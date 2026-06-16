"""Wave 32 — Glossary authority batch 9 (17 terms)."""

W32_SLUGS = [
    "glossary-dpi",
    "glossary-embedded-files",
    "glossary-encoding",
    "glossary-extract",
    "glossary-factur-x",
    "glossary-flate-compression",
    "glossary-form-field",
    "glossary-full-embedding",
    "glossary-hra-receipt",
    "glossary-hsn-code",
    "glossary-html-to-pdf-converter",
    "glossary-identity-h",
    "glossary-igst",
    "glossary-impress-export",
    "glossary-incremental-update",
    "glossary-irn",
    "glossary-javascript-in-pdf",
]

GLOSSARY_SLUGS = set(W32_SLUGS)

W32_DATA = {
    "glossary-dpi": {
        "title": "What Is DPI in PDF? — Dots Per Inch for Scans &amp; Print (2026)",
        "tool": "/pdf/ocrpdf",
        "label": "OCR PDF",
        "pillar": "/guides/ocr-accuracy-tips",
        "pillar_label": "OCR accuracy tips",
        "related": "/guides/glossary-compression",
        "example": "Records clerk rescans deeds at 300 DPI — OCR name hit rate jumps from 60% to 95%",
    },
    "glossary-embedded-files": {
        "title": "What Are Embedded Files in PDF? — Attachments &amp; Hidden Payload (2026)",
        "tool": "/pdf/pdfmetadata",
        "label": "PDF Metadata",
        "pillar": "/guides/glossary-pdf",
        "pillar_label": "PDF glossary",
        "related": "/guides/glossary-pdf-package",
        "example": "Security audit finds 40 MB Excel workbook embedded inside 2 MB summary PDF — email cap blown on extract",
    },
    "glossary-encoding": {
        "title": "What Is PDF Text Encoding? — WinAnsi, UTF-8 &amp; ToUnicode (2026)",
        "tool": "/pdf/ocrpdf",
        "label": "OCR PDF",
        "pillar": "/guides/glossary-cmap",
        "pillar_label": "CMap glossary",
        "related": "/guides/pdf-text-extraction-empty",
        "example": "Developer exports API doc PDF — copy-paste returns mojibake because ToUnicode CMap missing",
    },
    "glossary-extract": {
        "title": "What Is PDF Text Extract? — Copy, Export &amp; Parser Limits (2026)",
        "tool": "/pdf/pdftotext",
        "label": "PDF to Text",
        "pillar": "/guides/glossary-pdf-to-text-extractor",
        "pillar_label": "PDF to text extractor glossary",
        "related": "/guides/how-to-extract-text-from-pdf",
        "example": "Analyst runs extract on scanned lease PDF — empty .txt until OCR adds searchable layer",
    },
    "glossary-factur-x": {
        "title": "What Is Factur-X? — Hybrid PDF + XML E-Invoice (2026)",
        "tool": "/invoice/create",
        "label": "Create Invoice",
        "pillar": "/guides/glossary-e-invoice",
        "pillar_label": "e-invoice glossary",
        "related": "/guides/glossary-zugferd",
        "example": "French supplier sends Factur-X PDF — human-readable invoice plus embedded CII XML for Peppol",
    },
    "glossary-flate-compression": {
        "title": "What Is Flate Compression in PDF? — zlib &amp; Stream Size (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/glossary-compression",
        "pillar_label": "compression glossary",
        "related": "/guides/glossary-jbig2",
        "example": "IT explains why re-saving PDF shrinks file — flate re-encodes content streams on export",
    },
    "glossary-form-field": {
        "title": "What Is a PDF Form Field? — AcroForm &amp; Fillable Boxes (2026)",
        "tool": "/pdf/flattenpdf",
        "label": "Flatten PDF",
        "pillar": "/guides/glossary-acroform",
        "pillar_label": "AcroForm glossary",
        "related": "/guides/flatten-pdf",
        "example": "HR sends fillable onboarding PDF — recipient must flatten before upload portal rejects editable fields",
    },
    "glossary-full-embedding": {
        "title": "What Is Full Font Embedding in PDF? — Subset vs Complete (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/glossary-font-embedding",
        "pillar_label": "font embedding glossary",
        "related": "/guides/pdf-fonts-missing",
        "example": "Designer embeds full Roboto family — PDF bloats to 18 MB — subsetting on export fixes email send",
    },
    "glossary-hra-receipt": {
        "title": "What Is an HRA Receipt PDF? — India House Rent Allowance Proof (2026)",
        "tool": "/invoice/create",
        "label": "Create Invoice",
        "pillar": "/guides/rent-receipt-pdf-workflow-india",
        "pillar_label": "rent receipt workflow India",
        "related": "/guides/glossary-rent-receipt",
        "example": "Employee submits landlord rent receipt PDF for HRA exemption — PAN of landlord required above threshold",
    },
    "glossary-hsn-code": {
        "title": "What Is HSN Code on Invoice PDF? — India GST Classification (2026)",
        "tool": "/invoice/create",
        "label": "Create Invoice",
        "pillar": "/guides/glossary-gst-invoice",
        "pillar_label": "GST invoice glossary",
        "related": "/guides/glossary-sac-code",
        "example": "CA audits B2B invoice PDF — line HSN 8471 must match GSTR-1 filing and e-invoice schema",
    },
    "glossary-html-to-pdf-converter": {
        "title": "What Is an HTML to PDF Converter? — Render Pages for Archive (2026)",
        "tool": "/pdf/htmltopdf",
        "label": "HTML to PDF",
        "pillar": "/guides/html-to-pdf",
        "pillar_label": "HTML to PDF guide",
        "related": "/guides/glossary-html-to-pdf",
        "example": "Marketing archives campaign landing page as PDF for compliance snapshot before copy changes",
    },
    "glossary-identity-h": {
        "title": "What Is Identity-H Encoding in PDF? — CJK Unicode Mapping (2026)",
        "tool": "/pdf/ocrpdf",
        "label": "OCR PDF",
        "pillar": "/guides/glossary-composite-font",
        "pillar_label": "composite font glossary",
        "related": "/guides/glossary-cid-font",
        "example": "Korean contract PDF search fails — Identity-H without ToUnicode — OCR fallback for discovery",
    },
    "glossary-igst": {
        "title": "What Is IGST on Invoice PDF? — India Inter-State GST (2026)",
        "tool": "/invoice/create",
        "label": "Create Invoice",
        "pillar": "/guides/glossary-cgst",
        "pillar_label": "CGST glossary",
        "related": "/guides/glossary-gst-invoice",
        "example": "Mumbai vendor ships to Bangalore — invoice PDF shows IGST only — no CGST/SGST split on inter-state B2B",
    },
    "glossary-impress-export": {
        "title": "What Is LibreOffice Impress Export to PDF? — Slides &amp; Handouts (2026)",
        "tool": "/pdf/ppttopdf",
        "label": "PowerPoint to PDF",
        "pillar": "/guides/powerpoint-to-pdf",
        "pillar_label": "PowerPoint to PDF guide",
        "related": "/guides/glossary-libreoffice-headless",
        "example": "Nonprofit exports ODP deck to PDF handout — fonts substitute on recipient PC without embedding",
    },
    "glossary-incremental-update": {
        "title": "What Is Incremental PDF Update? — Append-Only Saves (2026)",
        "tool": "/pdf/repair",
        "label": "Repair PDF",
        "pillar": "/guides/glossary-pdf",
        "pillar_label": "PDF glossary",
        "related": "/guides/glossary-object-stream",
        "example": "Signed PDF grows after each annotation save — incremental updates append revisions — full save shrinks",
    },
    "glossary-irn": {
        "title": "What Is IRN on India E-Invoice PDF? — Invoice Reference Number (2026)",
        "tool": "/invoice/create",
        "label": "Create Invoice",
        "pillar": "/guides/glossary-e-invoice",
        "pillar_label": "e-invoice glossary",
        "related": "/guides/invoice-pdf-workflow-india",
        "example": "GST portal returns IRN and QR code — must appear on B2B invoice PDF before customer accepts goods",
    },
    "glossary-javascript-in-pdf": {
        "title": "What Is JavaScript in PDF? — Actions, Risks &amp; Flattening (2026)",
        "tool": "/pdf/flattenpdf",
        "label": "Flatten PDF",
        "pillar": "/guides/glossary-acroform",
        "pillar_label": "AcroForm glossary",
        "related": "/guides/pdf-security-compliance-guide",
        "example": "Bank blocks PDF with auto-open JavaScript — security policy requires flattened static copy for archive",
    },
}

W32_DEEP = {
    "glossary-dpi": """
            <h2>Definition</h2>
            <p><strong>DPI (dots per inch)</strong> measures how many pixels sample each inch of a scanned or rasterised page. Higher DPI preserves fine text and stamps; lower DPI shrinks file size but blurs small glyphs.</p>
            <h2>Practical targets</h2>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>Use case</th><th>DPI</th><th>Notes</th></tr></thead>
            <tbody>
            <tr><td>Office text OCR</td><td>300</td><td>Default sweet spot — <a href="/guides/ocr-accuracy-tips">OCR tips</a></td></tr>
            <tr><td>Phone photo scan</td><td>200–300 after crop</td><td>Deskew first</td></tr>
            <tr><td>Archive maps / faint ink</td><td>400–600</td><td>Large files — compress after</td></tr>
            <tr><td>Email attachment</td><td>200 grayscale</td><td>If legibility OK at zoom</td></tr>
            </tbody></table></div>
            <h2>DPI vs PDF "image resolution"</h2>
            <p>PDF stores bitmaps with pixel dimensions and optional DPI metadata — viewer zoom does not add detail — re-scan source if OCR fails — workflow: <a href="/pdf/ocrpdf">OCR PDF</a> → <a href="/pdf/compress">Compress</a> once.</p>
            <p>Related: <a href="/guides/glossary-compression">compression</a> · <a href="/guides/glossary-jbig2">JBIG2</a> · <a href="/guides/why-is-pdf-file-so-large">why PDF is large</a>.</p>
            """,
    "glossary-embedded-files": """
            <h2>Definition</h2>
            <p><strong>Embedded files</strong> (PDF attachments) are arbitrary files stored inside the PDF envelope — spreadsheets, ZIP archives, source images — listed in the Names tree — user may open via paperclip icon in Acrobat.</p>
            <h2>Why they matter</h2>
            <ul>
            <li>Hidden file size — 2 MB PDF contains 50 MB XLSX</li>
            <li>Malware vector — some orgs strip attachments on ingress</li>
            <li>Compliance — embedded PHI not obvious from page view</li>
            <li>Email still counts total bytes when gateway unpacks</li>
            </ul>
            <h2>Inspect and remediate</h2>
            <p>Check <a href="/pdf/pdfmetadata">PDF Metadata</a> and Acrobat Attachments panel — remove unnecessary embeds before external send — export flat PDF without portfolio — <a href="/guides/glossary-pdf-package">PDF package</a> vs single file.</p>
            """,
    "glossary-encoding": """
            <h2>Definition</h2>
            <p><strong>Text encoding</strong> in PDF maps character codes in content streams to glyphs — WinAnsi for Western Latin — <strong>Identity-H</strong> for Unicode CID fonts — requires <strong>ToUnicode CMap</strong> for correct copy-paste.</p>
            <h2>Symptoms of bad encoding</h2>
            <ul>
            <li>Copy-paste produces â€" or squares</li>
            <li>Search misses obvious words</li>
            <li>Screen reader mispronounces</li>
            <li>Extract returns empty — <a href="/guides/pdf-text-extraction-empty">empty extraction guide</a></li>
            </ul>
            <h2>Fix paths</h2>
            <p>Re-export from source with embed fonts — for CJK see <a href="/guides/glossary-cmap">CMap</a> · <a href="/guides/glossary-identity-h">Identity-H</a> — last resort <a href="/pdf/ocrpdf">OCR PDF</a> with correct language.</p>
            """,
    "glossary-extract": """
            <h2>Definition</h2>
            <p><strong>Text extract</strong> reads character operators from PDF content streams — or OCR text layer on scans — into plain text, CSV, or search index — distinct from "Save as PDF" from browser.</p>
            <h2>Extract vs OCR</h2>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>Source</th><th>Method</th></tr></thead>
            <tbody>
            <tr><td>Born-digital Word export</td><td><a href="/pdf/pdftotext">PDF to Text</a> direct</td></tr>
            <tr><td>Scanned pages</td><td><a href="/pdf/ocrpdf">OCR PDF</a> first</td></tr>
            <tr><td>Tables</td><td><a href="/pdf/pdftoexcel">PDF to Excel</a> — layout dependent</td></tr>
            </tbody></table></div>
            <h2>Limits</h2>
            <p>Multi-column newsletters lose order — headers/footers duplicate — password blocks extract until <a href="/guides/unlock-pdf">unlock</a> — glossary: <a href="/guides/glossary-pdf-to-text-extractor">PDF to text extractor</a>.</p>
            """,
    "glossary-factur-x": """
            <h2>Definition</h2>
            <p><strong>Factur-X</strong> (France, FNFE-MPE) is a <strong>hybrid PDF invoice</strong> — human-readable PDF/A-3 pages plus embedded XML (CII or UBL) machine-readable payload — successor branding to ZUGFeRD in French market.</p>
            <h2>Who uses it</h2>
            <p>B2B and B2G suppliers in France — Peppol access points — ERP exports combined file — auditor views PDF — AP system parses XML.</p>
            <h2>RatPDF context</h2>
            <p>RatPDF creates visual invoice PDF — full Factur-X XML embedding may require ERP — compare <a href="/guides/glossary-zugferd">ZUGFeRD</a> · <a href="/guides/glossary-e-invoice">e-invoice</a> · India: <a href="/guides/glossary-irn">IRN</a>.</p>
            <p>Create PDF: <a href="/invoice/create">Create Invoice</a> · <a href="/guides/excel-to-pdf">Excel to PDF</a> for spreadsheet source.</p>
            """,
    "glossary-flate-compression": """
            <h2>Definition</h2>
            <p><strong>Flate compression</strong> (zlib/DEFLATE) losslessly compresses PDF streams — text operators, metadata, some images — filter name <code>/FlateDecode</code> in object dictionary.</p>
            <h2>vs image compression</h2>
            <p>Flate shrinks repetitive text and vector paths — JPEG inside PDF uses DCT not flate — scans dominated by JPEG/JBIG2 — <a href="/guides/glossary-jbig2">JBIG2</a> for bilevel fax.</p>
            <h2>Re-save effect</h2>
            <p>Opening and re-exporting PDF re-flates streams — may reduce size — <a href="/pdf/compress">Compress PDF</a> applies Ghostscript pipeline — see <a href="/guides/glossary-compression">compression glossary</a> · <a href="/guides/ghostscript-pdf-compression">Ghostscript explained</a>.</p>
            """,
    "glossary-form-field": """
            <h2>Definition</h2>
            <p><strong>Form fields</strong> are interactive widgets — text boxes, checkboxes, radio groups, dropdowns, signature fields — defined in <strong>AcroForm</strong> dictionary — user fills in Acrobat or browser viewer.</p>
            <h2>Common workflows</h2>
            <ol>
            <li>Download government or HR PDF form</li>
            <li>Fill fields in viewer</li>
            <li><a href="/pdf/flattenpdf">Flatten PDF</a> — bake values to static content</li>
            <li>Upload to portal that rejects editable PDFs</li>
            </ol>
            <h2>Security note</h2>
            <p>JavaScript tied to fields can run on open — orgs may require flatten — <a href="/guides/glossary-javascript-in-pdf">JavaScript in PDF</a> · <a href="/guides/glossary-acroform">AcroForm</a>.</p>
            """,
    "glossary-full-embedding": """
            <h2>Definition</h2>
            <p><strong>Full embedding</strong> includes entire font file (all glyphs and weights) in PDF — guarantees display on any PC — dramatically increases size vs <strong>subset embedding</strong> (only used glyphs).</p>
            <h2>When full embed happens</h2>
            <ul>
            <li>Designer forgot subset checkbox on export</li>
            <li>Licensing requires full embed</li>
            <li>Multiple language scripts in one family</li>
            </ul>
            <h2>Remediation</h2>
            <p>Re-export with subset fonts — <a href="/pdf/compress">Compress PDF</a> subsets on some pipelines — if recipient sees missing glyphs — <a href="/guides/pdf-fonts-missing">fonts missing guide</a> — glossary: <a href="/guides/glossary-font-embedding">font embedding</a>.</p>
            """,
    "glossary-hra-receipt": """
            <h2>Definition</h2>
            <p><strong>HRA (House Rent Allowance) receipt</strong> is landlord acknowledgement of rent paid — employee submits PDF to employer for tax exemption under India Income Tax Act — often monthly or annual consolidated.</p>
            <h2>Typical PDF fields</h2>
            <ul>
            <li>Tenant and landlord name, address</li>
            <li>Rent amount, period, payment mode</li>
            <li>Landlord PAN if rent exceeds ₹1 lakh/year</li>
            <li>Revenue stamp scan where required by state</li>
            </ul>
            <h2>Workflow</h2>
            <p>Landlord signs → scan 300 DPI → <a href="/pdf/ocrpdf">OCR</a> optional → <a href="/pdf/compress">compress</a> for HR portal — regional: <a href="/guides/rent-receipt-pdf-workflow-india">rent receipt workflow India</a> · <a href="/guides/glossary-rent-receipt">rent receipt glossary</a>.</p>
            """,
    "glossary-hsn-code": """
            <h2>Definition</h2>
            <p><strong>HSN (Harmonized System of Nomenclature)</strong> classifies goods for GST — numeric code on each invoice line — B2B invoices require HSN on PDF export per turnover slab rules.</p>
            <h2>On invoice PDF</h2>
            <ul>
            <li>Line-level HSN (4/6/8 digits per notification)</li>
            <li>Matches GSTR-1 Table 12 and e-invoice JSON</li>
            <li>Wrong HSN → buyer ITC dispute — audit risk</li>
            </ul>
            <h2>Services</h2>
            <p>SAC codes for services — <a href="/guides/glossary-sac-code">SAC glossary</a> — export from Tally/ERP → PDF — <a href="/invoice/create">Create Invoice</a> · <a href="/guides/glossary-gst-invoice">GST invoice</a> · <a href="/guides/glossary-irn">IRN</a>.</p>
            """,
    "glossary-html-to-pdf-converter": """
            <h2>Definition</h2>
            <p>An <strong>HTML to PDF converter</strong> renders HTML/CSS (and often web fonts) into paginated PDF — used for receipts, reports, email archives, and compliance snapshots of web content.</p>
            <h2>Browser vs server</h2>
            <ul>
            <li><strong>Headless Chrome / wkhtmltopdf:</strong> server render — consistent fonts</li>
            <li><strong>Browser print to PDF:</strong> quick — margins vary</li>
            <li><strong>RatPDF <a href="/pdf/htmltopdf">HTML to PDF</a>:</strong> paste markup or URL — no desktop install</li>
            </ul>
            <h2>Quality tips</h2>
            <p>Embed web fonts — set @page size — test page breaks — email templates: <a href="/guides/html-to-pdf-email-template">HTML email template guide</a> · Pillar: <a href="/guides/html-to-pdf">HTML to PDF guide</a>.</p>
            """,
    "glossary-identity-h": """
            <h2>Definition</h2>
            <p><strong>Identity-H</strong> is a PDF encoding name meaning glyph codes map directly to CIDs in horizontal writing — common for <strong>CJK composite fonts</strong> — paired with Unicode CMap for extract.</p>
            <h2>Without ToUnicode</h2>
            <p>Copy-paste garbage — full-text search in e-discovery fails — accessibility tools skip text — fix in source export or <a href="/pdf/ocrpdf">OCR PDF</a>.</p>
            <h2>Related encoding</h2>
            <p><a href="/guides/glossary-composite-font">Composite font</a> · <a href="/guides/glossary-cid-font">CID font</a> · <a href="/guides/glossary-cmap">CMap</a> · <a href="/guides/glossary-encoding">encoding overview</a>.</p>
            """,
    "glossary-igst": """
            <h2>Definition</h2>
            <p><strong>IGST (Integrated GST)</strong> applies to <strong>inter-state</strong> supplies in India — single IGST line replaces CGST+SGST — appears on B2B invoice PDF when supplier and buyer are in different states.</p>
            <h2>Invoice PDF example</h2>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>Supply type</th><th>Tax lines on PDF</th></tr></thead>
            <tbody>
            <tr><td>Intra-state (same state)</td><td>CGST + SGST — <a href="/guides/glossary-cgst">CGST</a></td></tr>
            <tr><td>Inter-state</td><td>IGST only</td></tr>
            <tr><td>Export</td><td>Zero-rated / LUT — consult CA</td></tr>
            </tbody></table></div>
            <h2>E-invoice</h2>
            <p>IGST amount in JSON must match PDF line — <a href="/guides/glossary-irn">IRN</a> QR on PDF — workflow: <a href="/guides/invoice-pdf-workflow-india">invoice PDF India</a>.</p>
            """,
    "glossary-impress-export": """
            <h2>Definition</h2>
            <p><strong>LibreOffice Impress</strong> exports presentations (.odp) to PDF — slides, handouts (2–6 per page), or notes — File → Export as PDF — font embedding and image compression options in dialog.</p>
            <h2>Common issues</h2>
            <ul>
            <li>Missing fonts on recipient PC — enable embed fonts</li>
            <li>Huge file from 4K slide images — compress images in Impress first</li>
            <li>Animation lost — PDF is static — video links may break</li>
            </ul>
            <h2>Alternatives</h2>
            <p>Microsoft PPTX → <a href="/pdf/ppttopdf">PowerPoint to PDF</a> — batch: <a href="/guides/glossary-libreoffice-headless">LibreOffice headless</a> — email cap: <a href="/pdf/compress">Compress PDF</a>.</p>
            """,
    "glossary-incremental-update": """
            <h2>Definition</h2>
            <p><strong>Incremental update</strong> appends revised PDF objects and new xref section to end of file — original bytes preserved — faster save after small edits — file grows until "Save As" full rewrite.</p>
            <h2>When you see it</h2>
            <ul>
            <li>Digital signatures — earlier revision preserved</li>
            <li>Repeated annotation saves in Acrobat</li>
            <li>Redaction tools writing new generation</li>
            </ul>
            <h2>Implications</h2>
            <p>Deleted content may remain recoverable in earlier revision — secure redaction requires full save — corrupted incremental chain needs <a href="/pdf/repair">Repair PDF</a> — <a href="/guides/glossary-cross-reference-table">xref table</a> · <a href="/guides/glossary-object-stream">object stream</a>.</p>
            """,
    "glossary-irn": """
            <h2>Definition</h2>
            <p><strong>IRN (Invoice Reference Number)</strong> is a unique hash returned by India GST <strong>e-Invoice</strong> portal (NIC IRP) — paired with signed QR code — must print on B2B invoice PDF for valid tax credit chain.</p>
            <h2>Workflow</h2>
            <ol>
            <li>ERP generates invoice JSON</li>
            <li>Upload to IRP — receive IRN + QR</li>
            <li>Embed QR and IRN text on PDF template</li>
            <li>Email PDF to buyer — match GSTR-2A/2B</li>
            </ol>
            <h2>PDF QA</h2>
            <p>QR scannable at print size — IRN matches portal — cancel/amend within window — <a href="/guides/glossary-e-invoice">e-invoice glossary</a> · <a href="/guides/invoice-pdf-workflow-india">India invoice workflow</a> · <a href="/invoice/create">Create Invoice</a>.</p>
            """,
    "glossary-javascript-in-pdf": """
            <h2>Definition</h2>
            <p><strong>JavaScript in PDF</strong> runs via Acrobat JavaScript API on open, close, or field events — calculate form totals, validate fields, launch URLs — powerful and historically abused as malware vector.</p>
            <h2>Enterprise policy</h2>
            <ul>
            <li>Disable JS in Acrobat Reader enterprise setting</li>
            <li>Strip on email gateway</li>
            <li>Require <a href="/pdf/flattenpdf">flattened</a> PDF for archive</li>
            </ul>
            <h2>Legitimate uses</h2>
            <p>Interactive tax forms, dynamic invoices — for static distribution flatten first — security hub: <a href="/guides/pdf-security-compliance-guide">compliance guide</a> · forms: <a href="/guides/glossary-acroform">AcroForm</a> · <a href="/guides/glossary-form-field">form fields</a>.</p>
            """,
}

W32_GLOSSARY_CLUSTER = """
            <h2>Glossary batch 9</h2>
            <ul>
            <li><a href="/guides/glossary-dpi">DPI</a> · <a href="/guides/glossary-encoding">Encoding</a> · <a href="/guides/glossary-extract">Extract</a></li>
            <li><a href="/guides/glossary-embedded-files">Embedded files</a> · <a href="/guides/glossary-flate-compression">Flate compression</a></li>
            <li><a href="/guides/glossary-form-field">Form field</a> · <a href="/guides/glossary-full-embedding">Full embedding</a></li>
            <li><a href="/guides/glossary-factur-x">Factur-X</a> · <a href="/guides/glossary-irn">IRN</a> · <a href="/guides/glossary-igst">IGST</a></li>
            <li><a href="/guides/glossary-hsn-code">HSN code</a> · <a href="/guides/glossary-hra-receipt">HRA receipt</a></li>
            <li><a href="/guides/glossary-html-to-pdf-converter">HTML to PDF converter</a> · <a href="/guides/glossary-impress-export">Impress export</a></li>
            <li><a href="/guides/glossary-identity-h">Identity-H</a> · <a href="/guides/glossary-incremental-update">Incremental update</a></li>
            <li><a href="/guides/glossary-javascript-in-pdf">JavaScript in PDF</a></li>
            </ul>
            <p>Prior: <a href="/guides/glossary-color-profile">batch 8</a> · Hub: <a href="/guides/pdf-glossary-hub">PDF glossary hub</a></p>
            """

W32_GLOSSARY_TOPUP = """
            <h2>Glossary batch 9 — study map</h2>
            <ul>
            <li><strong>Scan pipeline:</strong> DPI → OCR → flate/JPEG compress</li>
            <li><strong>Text pipeline:</strong> encoding → Identity-H/CMap → extract</li>
            <li><strong>India tax PDF:</strong> HSN → IGST → IRN QR on invoice</li>
            <li><strong>Forms &amp; risk:</strong> AcroForm fields → JavaScript → flatten</li>
            <li><strong>Structure:</strong> embedded files → incremental update → repair</li>
            </ul>
            <h2>Invoice &amp; e-invoice cluster</h2>
            <p><a href="/guides/glossary-e-invoice">E-invoice</a> · <a href="/guides/glossary-zugferd">ZUGFeRD</a> · <a href="/guides/glossary-factur-x">Factur-X</a> · <a href="/guides/glossary-gst-invoice">GST invoice</a></p>
            """

W32_CLOSING = """
            <h2>Related guides</h2>
            <p>Wave 32 upgrades seventeen core PDF terminology pages — scan DPI, compression, encoding, India GST fields, HTML render, and interactive PDF risks — with internal links to tools and regional workflows.</p>
            <p>Hub: <a href="/guides/pdf-glossary-hub">PDF glossary hub</a> · Next batch: <a href="/guides/glossary-jbig2">JBIG2</a> · <a href="/guides/glossary-job-queue">job queue</a> · <a href="/guides/glossary-layers">layers</a></p>
            """
