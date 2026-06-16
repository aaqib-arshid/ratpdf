"""Wave 16 batch 1 — Glossary authority upgrades (17 core PDF terms, 1500+ words each)."""

W16_SLUGS = [
    "glossary-compress-pdf-online",
    "glossary-pdf-to-word-converter",
    "glossary-pdf-to-text-extractor",
    "glossary-compression",
    "glossary-ocr",
    "glossary-pdf-a",
    "glossary-pdf-ua",
    "glossary-pdf-x",
    "glossary-digital-signature",
    "glossary-acroform",
    "glossary-ghostscript",
    "glossary-tesseract",
    "glossary-metadata",
    "glossary-merge",
    "glossary-pdf",
    "glossary-font-embedding",
    "glossary-redaction",
]

W16_DATA = {
    "glossary-compress-pdf-online": {
        "title": "What Is Compress PDF Online? — Definition &amp; When to Use a Browser Tool (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/compress-pdf-guide",
        "pillar_label": "compress PDF guide",
        "example": "Recruiter shrinks a 12 MB portfolio PDF to under Gmail's 25 MB limit before sending",
    },
    "glossary-pdf-to-word-converter": {
        "title": "What Is a PDF to Word Converter? — Definition, Limits &amp; Best Use Cases (2026)",
        "tool": "/pdf/pdftodoc",
        "label": "PDF to Word",
        "pillar": "/guides/pdf-to-word",
        "pillar_label": "PDF to Word guide",
        "example": "Paralegal converts a digital contract PDF to DOCX for clause redlines — not a scanned lease",
    },
    "glossary-pdf-to-text-extractor": {
        "title": "What Is a PDF to Text Extractor? — Plain Text vs OCR Explained (2026)",
        "tool": "/pdf/pdftotext",
        "label": "PDF to Text",
        "pillar": "/guides/pdf-txt-guide",
        "pillar_label": "PDF to Text guide",
        "example": "Developer pulls API documentation text from a digital PDF into a CI search index",
    },
    "glossary-compression": {
        "title": "What Is PDF Compression? — Lossy vs Lossless Explained (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/compress-pdf-guide",
        "pillar_label": "compress PDF guide",
        "example": "Finance team reduces quarterly report from 8 MB to 900 KB for board email",
    },
    "glossary-ocr": {
        "title": "What Is OCR for PDF? — Searchable Scans &amp; Text Layers (2026)",
        "tool": "/pdf/ocrpdf",
        "label": "OCR PDF",
        "pillar": "/guides/ocr-pdf",
        "pillar_label": "OCR PDF guide",
        "example": "Clinic digitizes paper intake forms — OCR adds selectable text for EHR search",
    },
    "glossary-pdf-a": {
        "title": "What Is PDF/A? — Archival PDF Standard Explained (2026)",
        "tool": "/pdf/pdfmetadata",
        "label": "PDF Metadata",
        "pillar": "/guides/pdf-a-archival",
        "pillar_label": "PDF/A archival guide",
        "example": "Records manager validates 7-year tax PDF bundle meets PDF/A-1b before glacier upload",
    },
    "glossary-pdf-ua": {
        "title": "What Is PDF/UA? — Universal Accessibility Standard for PDF (2026)",
        "tool": "/pdf/pdfmetadata",
        "label": "PDF Metadata",
        "pillar": "/guides/pdf-ua-accessibility",
        "pillar_label": "PDF/UA accessibility guide",
        "example": "University publishes course pack — PDF/UA required for screen reader students",
    },
    "glossary-pdf-x": {
        "title": "What Is PDF/X? — Print-Ready PDF Standard Explained (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/pdf-x-print-standard",
        "pillar_label": "PDF/X print standard guide",
        "example": "Agency exports brochure PDF/X-1a — printer rejects RGB-only file without output intent",
    },
    "glossary-digital-signature": {
        "title": "What Is a Digital PDF Signature? — Typed, Drawn &amp; Certificate Signatures (2026)",
        "tool": "/pdf/signtext",
        "label": "Sign PDF",
        "pillar": "/guides/sign-pdf",
        "pillar_label": "sign PDF guide",
        "example": "Freelancer adds typed signature to SOW — client needs visible approval, not PKI certificate",
    },
    "glossary-acroform": {
        "title": "What Is AcroForm? — Interactive PDF Forms Explained (2026)",
        "tool": "/pdf/flattenpdf",
        "label": "Flatten PDF",
        "pillar": "/guides/flatten-pdf",
        "pillar_label": "flatten PDF guide",
        "example": "HR sends fillable onboarding PDF — AcroForm fields must flatten before archive",
    },
    "glossary-ghostscript": {
        "title": "What Is Ghostscript? — PDF Compression &amp; Conversion Engine (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/compress-pdf-guide",
        "pillar_label": "compress PDF guide",
        "example": "IT admin compares Ghostscript /ebook vs /printer settings for invoice batch compression",
    },
    "glossary-tesseract": {
        "title": "What Is Tesseract OCR? — Open-Source PDF Text Recognition (2026)",
        "tool": "/pdf/ocrpdf",
        "label": "OCR PDF",
        "pillar": "/guides/ocr-pdf",
        "pillar_label": "OCR PDF guide",
        "example": "Archivist OCRs 1990s scanned newsletters — Tesseract language pack set to English",
    },
    "glossary-metadata": {
        "title": "What Is PDF Metadata? — Title, Author, XMP &amp; Properties (2026)",
        "tool": "/pdf/pdfmetadata",
        "label": "PDF Metadata",
        "pillar": "/guides/pdf-metadata",
        "pillar_label": "PDF metadata guide",
        "example": "Procurement scrubs internal author name from RFP PDF before public portal upload",
    },
    "glossary-merge": {
        "title": "What Does Merge PDF Mean? — Combine Files Without Reordering Mistakes (2026)",
        "tool": "/pdf/merge",
        "label": "Merge PDF",
        "pillar": "/guides/merge-pdf",
        "pillar_label": "merge PDF guide",
        "example": "Applicant merges passport, bank statement, and cover letter into one visa upload PDF",
    },
    "glossary-pdf": {
        "title": "What Is a PDF File? — Portable Document Format Basics (2026)",
        "tool": "/guides/pdf-tools",
        "label": "PDF tools hub",
        "pillar": "/guides/beginner-what-is-a-pdf",
        "pillar_label": "what is a PDF beginner guide",
        "example": "New hire receives policy PDF — needs to know why it opens the same on Mac and Windows",
    },
    "glossary-font-embedding": {
        "title": "What Is PDF Font Embedding? — Missing Font &amp; Print Fixes (2026)",
        "tool": "/pdf/doctopdf",
        "label": "Word to PDF",
        "pillar": "/guides/embed-fonts-before-printing",
        "pillar_label": "embed fonts before printing guide",
        "example": "Proposal PDF prints with substituted font — re-export from Word with embed fonts enabled",
    },
    "glossary-redaction": {
        "title": "What Is PDF Redaction? — Permanent Removal vs Black Boxes (2026)",
        "tool": "/pdf-redaction",
        "label": "PDF Redaction",
        "pillar": "/guides/pdf-redaction",
        "pillar_label": "PDF redaction guide",
        "example": "Legal team redacts SSNs from discovery PDF — black highlight alone leaves text under layer",
    },
}

W16_DEEP = {
    "glossary-compress-pdf-online": """
            <h2>Definition</h2>
            <p><strong>Compress PDF online</strong> means reducing file size through a browser upload to a server-side engine — typically Ghostscript — without installing desktop software. It targets email caps, portal upload limits, and mobile share constraints.</p>
            <p>For step-by-step workflows (Gmail, visa portals, government forms), see the <a href="/guides/compress-pdf-guide">compress PDF guide</a> — this page defines the term and when compression helps vs hurts.</p>
            <h2>When online compression helps</h2>
            <ul>
            <li>Digital PDFs with embedded photos or high-DPI scans</li>
            <li>Multi-page reports where text is vector but images dominate bytes</li>
            <li>One-off jobs where installing Acrobat is overkill</li>
            </ul>
            <h2>When it may fail</h2>
            <ul>
            <li>Already heavily compressed scans — second pass barely shrinks or adds artifacts</li>
            <li>Password-locked PDFs — unlock first with permission</li>
            <li>Print-master files with 300 DPI assets — compress a copy, not the archive</li>
            </ul>
            <h2>RatPDF approach</h2>
            <p><a href="/pdf/compress">Compress PDF</a> uses Ghostscript presets (Less / Recommended / More) — free tier 200 MB upload — Pro 4 GB. Files delete after download per <a href="/Home/Privacy">privacy policy</a>.</p>
            """,
    "glossary-pdf-to-word-converter": """
            <h2>Definition</h2>
            <p>A <strong>PDF to Word converter</strong> rebuilds PDF page content as an editable DOCX file. Quality depends on whether the PDF is digital (born-digital text) or scanned (image-only pages).</p>
            <p>Full workflow: <a href="/guides/pdf-to-word">PDF to Word guide</a>. Scanned documents need <a href="/guides/ocr-pdf">OCR</a> first — converters cannot invent text from pixels.</p>
            <h2>Output expectations</h2>
            <table class="table table-sm"><thead><tr><th>Source PDF</th><th>Typical DOCX quality</th></tr></thead>
            <tbody>
            <tr><td>Word-exported PDF</td><td>Excellent — headings, tables often preserved</td></tr>
            <tr><td>PowerPoint PDF</td><td>Moderate — text boxes may fragment</td></tr>
            <tr><td>Scanned contract</td><td>Poor without OCR — run OCR PDF first</td></tr>
            </tbody></table>
            <h2>RatPDF engine</h2>
            <p><a href="/pdf/pdftodoc">PDF to Word</a> uses pdf2docx for digital PDFs — honest limits on complex layouts — compare with <a href="/guides/pdf-to-word-vs-pdf-to-text">Word vs plain text export</a>.</p>
            """,
    "glossary-pdf-to-text-extractor": """
            <h2>Definition</h2>
            <p>A <strong>PDF to text extractor</strong> pulls encoded character data from a PDF into plain TXT — no formatting, no images. It is faster than Word conversion when you only need words for search, scripts, or LLM ingestion.</p>
            <p>Workflow hub: <a href="/guides/pdf-txt-guide">PDF to Text guide</a>.</p>
            <h2>Extractor vs OCR</h2>
            <p>Extraction reads the PDF text layer — OCR creates a text layer on scans. If copy-paste returns garbage or nothing, the page is image-only — use <a href="/pdf/ocrpdf">OCR PDF</a> instead.</p>
            <h2>Common uses</h2>
            <ul>
            <li>Log analysis from exported report PDFs</li>
            <li>Email body recovery from archived message PDFs</li>
            <li>Compliance keyword scan before redaction</li>
            </ul>
            <h2>Tool</h2>
            <p><a href="/pdf/pdftotext">PDF to Text</a> — batch-friendly for digital PDFs — pair with <a href="/guides/extract-text-from-pdf">extract text workflow</a>.</p>
            """,
    "glossary-compression": """
            <h2>Definition</h2>
            <p><strong>PDF compression</strong> reduces file size by downsampling images, subsetting fonts, removing redundant objects, or re-encoding streams. It is not the same as <a href="/guides/glossary-flattened-pdf">flattening</a> (which merges form fields into static content).</p>
            <h2>Lossy vs lossless</h2>
            <ul>
            <li><strong>Lossy</strong> — JPEG recompression, lower DPI — big size wins, visible blur on photos if pushed too far</li>
            <li><strong>Lossless</strong> — structure cleanup, duplicate removal — modest savings on text-heavy PDFs</li>
            </ul>
            <p>Deep dive: <a href="/guides/compress-pdf-guide">compress PDF guide</a> · Research: <a href="/research/pdf-compression-benchmark">compression benchmark</a>.</p>
            <h2>Quality check</h2>
            <p>Always open compressed output at 100% zoom — verify footnotes, stamps, and signatures remain legible before deleting the master.</p>
            """,
    "glossary-ocr": """
            <h2>Definition</h2>
            <p><strong>OCR (optical character recognition)</strong> on PDF means running image analysis on page pixels to produce a hidden text layer — making scans searchable and selectable.</p>
            <p>Full guide: <a href="/guides/ocr-pdf">OCR PDF guide</a> · Compare: <a href="/guides/ocr-vs-pdf-to-text">OCR vs PDF to Text</a>.</p>
            <h2>Accuracy factors</h2>
            <ul>
            <li>Scan DPI — 300 DPI minimum for small type</li>
            <li>Skew and noise — deskew before OCR if possible</li>
            <li>Language — set correct Tesseract language pack</li>
            <li>Multi-column layouts — reading order may need manual fix in Word after export</li>
            </ul>
            <h2>RatPDF</h2>
            <p><a href="/pdf/ocrpdf">OCR PDF</a> adds searchable text — does not guarantee perfect table reconstruction — follow with <a href="/pdf/pdftodoc">PDF to Word</a> if you need editable layout.</p>
            """,
    "glossary-pdf-a": """
            <h2>Definition</h2>
            <p><strong>PDF/A</strong> is an ISO standard subset of PDF for long-term archiving — fonts embedded, forbidden features like encryption that break future rendering, and conformance levels (PDF/A-1b, PDF/A-2u, PDF/A-3).</p>
            <p>Implementation guide: <a href="/guides/pdf-a-archival">PDF/A archival guide</a> · Hub: <a href="/guides/pdf-standards-archiving-hub">standards &amp; archiving hub</a>.</p>
            <h2>RatPDF limits</h2>
            <p>RatPDF does not certify PDF/A — export from source app (Word, LibreOffice, Acrobat) then validate with veraPDF or similar — use RatPDF for metadata check, OCR, merge, and access-copy compression.</p>
            <h2>When PDF/A is required</h2>
            <ul>
            <li>Government records management</li>
            <li>Legal hold and audit archives</li>
            <li>Some EU public sector publication mandates</li>
            </ul>
            """,
    "glossary-pdf-ua": """
            <h2>Definition</h2>
            <p><strong>PDF/UA (Universal Accessibility)</strong> is the ISO standard for accessible PDF — tagged structure, logical reading order, alt text on figures, and proper headings for assistive technology.</p>
            <p>Workflow: <a href="/guides/pdf-ua-accessibility">PDF/UA accessibility guide</a> · Checklist: <a href="/guides/tagged-pdf-checklist">tagged PDF checklist</a>.</p>
            <h2>Not the same as WCAG</h2>
            <p>WCAG applies to web content — PDF/UA is the PDF-specific profile — Section 508 references both — see <a href="/guides/section-508-pdf">Section 508 PDF</a>.</p>
            <h2>Remediation reality</h2>
            <p>Browser tools can view tags via <a href="/pdf/pdfmetadata">PDF Metadata</a> — full remediation usually needs Acrobat, axesPDF, or PAC — plan budget for high-stakes public documents.</p>
            """,
    "glossary-pdf-x": """
            <h2>Definition</h2>
            <p><strong>PDF/X</strong> is a family of ISO standards for reliable commercial print — requires output intent (CMYK profile), font embedding rules, and forbids RGB-only jobs that fail on press.</p>
            <p>Handoff guide: <a href="/guides/pdf-x-print-standard">PDF/X print standard guide</a> · Checklist: <a href="/guides/commercial-print-pdf-checklist">commercial print checklist</a>.</p>
            <h2>Common variants</h2>
            <ul>
            <li><strong>PDF/X-1a</strong> — CMYK and spot only — legacy offset</li>
            <li><strong>PDF/X-4</strong> — allows transparency and ICC profiles — modern workflows</li>
            </ul>
            <h2>Office PDF vs PDF/X</h2>
            <p>Word export is RGB — not print-ready — designer must preflight in InDesign — RatPDF <a href="/pdf/compress">compress</a> is for proof email only.</p>
            """,
    "glossary-digital-signature": """
            <h2>Definition</h2>
            <p>A <strong>digital signature</strong> on PDF cryptographically binds identity to document hash — PKI certificate — distinct from a <strong>electronic signature</strong> (typed name, drawn stroke, or image) which shows intent but may not use certificates.</p>
            <p>How-to: <a href="/guides/sign-pdf">sign PDF guide</a> · Legal context: <a href="/guides/electronically-sign-pdf-legally">electronically sign PDF legally</a>.</p>
            <h2>RatPDF capability</h2>
            <p><a href="/pdf/signtext">Sign PDF</a> adds typed or drawn signatures on page — not Adobe-approved certificate signing — use DocuSign or Adobe Sign for regulated PKI workflows.</p>
            <h2>Choose the right type</h2>
            <table class="table table-sm"><thead><tr><th>Need</th><th>Approach</th></tr></thead>
            <tbody>
            <tr><td>Internal approval</td><td>Typed sign in RatPDF</td></tr>
            <tr><td>EU eIDAS qualified</td><td>Qualified trust service provider</td></tr>
            <tr><td>US ESIGN consent</td><td>Audit trail + intent — typed often sufficient</td></tr>
            </tbody></table>
            """,
    "glossary-acroform": """
            <h2>Definition</h2>
            <p><strong>AcroForm</strong> is Adobe's interactive form technology in PDF — text fields, checkboxes, radio buttons, and digital signature fields stored as PDF objects — distinct from XFA (legacy XML forms).</p>
            <p>After fill: <a href="/guides/flatten-pdf">flatten PDF guide</a> · Definition: <a href="/guides/glossary-flattened-pdf">flattened PDF glossary</a>.</p>
            <h2>Lifecycle</h2>
            <ol>
            <li>Receive fillable PDF from sender</li>
            <li>Complete fields in Acrobat, Preview, or browser viewer</li>
            <li>Flatten before print or archive so values cannot change</li>
            <li>Compress copy if portal size cap applies</li>
            </ol>
            <h2>Tool</h2>
            <p><a href="/pdf/flattenpdf">Flatten PDF</a> — verify with select tool — field text should not highlight as separate widget.</p>
            """,
    "glossary-ghostscript": """
            <h2>Definition</h2>
            <p><strong>Ghostscript</strong> is an open-source interpreter for PostScript and PDF — powers many server-side compress, convert, and rasterize pipelines — including RatPDF compression.</p>
            <p>Compression workflows: <a href="/guides/compress-pdf-guide">compress PDF guide</a> · Benchmark: <a href="/research/pdf-compression-benchmark">PDF compression benchmark</a>.</p>
            <h2>Common settings</h2>
            <ul>
            <li><code>/ebook</code> — balanced screen quality</li>
            <li><code>/printer</code> — higher quality print handoff</li>
            <li><code>/screen</code> — aggressive — use only for low-stakes previews</li>
            </ul>
            <h2>What Ghostscript does not fix</h2>
            <p>Corrupt PDF structure, missing fonts in source, or wrong page rotation — fix upstream or use <a href="/guides/pdf-troubleshooting">PDF troubleshooting guide</a>.</p>
            """,
    "glossary-tesseract": """
            <h2>Definition</h2>
            <p><strong>Tesseract</strong> is Google's open-source OCR engine — supports 100+ languages — used by RatPDF and many desktop tools to add text layers to scanned PDFs.</p>
            <p>OCR workflow: <a href="/guides/ocr-pdf">OCR PDF guide</a> · Tips: <a href="/guides/ocr-accuracy-tips">OCR accuracy tips</a>.</p>
            <h2>Language packs</h2>
            <p>Mixed English + Hindi invoices need appropriate models — wrong language produces gibberish text layer — always spot-check first page after OCR.</p>
            <h2>Limits</h2>
            <p>Handwriting, faint fax, and decorative fonts reduce accuracy — rescan at 300 DPI before OCR — not all errors are fixable in post.</p>
            """,
    "glossary-metadata": """
            <h2>Definition</h2>
            <p><strong>PDF metadata</strong> is document properties stored in the file — title, author, subject, keywords, creation date — plus optional XMP packets for rich descriptive fields.</p>
            <p>Viewer tool: <a href="/guides/pdf-metadata">PDF metadata guide</a> · Audit: <a href="/guides/pdf-metadata-audit">metadata audit workflow</a>.</p>
            <h2>Why metadata matters</h2>
            <ul>
            <li>Search in DAM and email archives</li>
            <li>Privacy — author field may leak employee name on external RFP</li>
            <li>Records — creation date supports retention class</li>
            </ul>
            <h2>RatPDF</h2>
            <p><a href="/pdf/pdfmetadata">PDF Metadata</a> viewer — read-only — scrub sensitive author in source app before publish — RatPDF does not rewrite XMP in free tier.</p>
            """,
    "glossary-merge": """
            <h2>Definition</h2>
            <p><strong>Merge PDF</strong> combines multiple PDF files into one document in a defined page order — appendices after main body, supporting evidence after cover letter.</p>
            <p>Step-by-step: <a href="/guides/merge-pdf">merge PDF guide</a> · Visa example: <a href="/guides/merge-pdf-visa-application">merge PDF for visa</a>.</p>
            <h2>Before you merge</h2>
            <ul>
            <li>Rotate sideways pages with <a href="/pdf/rotateorremove">Rotate PDF</a></li>
            <li>Compress oversized scans first if total exceeds portal cap</li>
            <li>OCR scans if downstream reviewer needs search</li>
            </ul>
            <h2>Tool</h2>
            <p><a href="/pdf/merge">Merge PDF</a> — drag order in UI — download single combined file — verify page count matches sum of inputs.</p>
            """,
    "glossary-pdf": """
            <h2>Definition</h2>
            <p><strong>PDF (Portable Document Format)</strong> is a fixed-layout document standard by Adobe, now ISO 32000 — preserves fonts, vectors, and images so the file renders the same across devices and printers.</p>
            <p>Beginner path: <a href="/guides/beginner-what-is-a-pdf">what is a PDF</a> · Tool index: <a href="/guides/pdf-tools">PDF tools hub</a>.</p>
            <h2>PDF vs other formats</h2>
            <ul>
            <li><strong>Word DOCX</strong> — reflows — better for editing — worse for final delivery</li>
            <li><strong>PNG/JPG</strong> — one page per image — no multi-page structure</li>
            <li><strong>HTML</strong> — responsive — not print-stable without conversion</li>
            </ul>
            <h2>When to use PDF</h2>
            <p>Contracts, invoices, forms, portfolios, and government submissions — anywhere layout fidelity matters — convert back to Word only when you need heavy editing.</p>
            """,
    "glossary-font-embedding": """
            <h2>Definition</h2>
            <p><strong>Font embedding</strong> stores font files (full or subset) inside the PDF so readers and printers render glyphs without installing the typeface locally.</p>
            <p>Print fix: <a href="/guides/embed-fonts-before-printing">embed fonts before printing</a> · Export: <a href="/pdf/doctopdf">Word to PDF</a>.</p>
            <h2>Symptoms of missing embed</h2>
            <ul>
            <li>Layout shifts on colleague's laptop</li>
            <li>Printer substitutes Arial for brand face</li>
            <li>Special characters become tofu boxes</li>
            </ul>
            <h2>Subset vs full embed</h2>
            <p>Subset embeds only glyphs used — smaller file — sufficient for most jobs — full embed needed for later edit-in-Acrobat workflows.</p>
            """,
    "glossary-redaction": """
            <h2>Definition</h2>
            <p><strong>PDF redaction</strong> permanently removes content — text and metadata — not just a black rectangle overlay. True redaction deletes underlying objects so copy-paste and search cannot recover secrets.</p>
            <p>Workflow: <a href="/guides/pdf-redaction">PDF redaction guide</a> · GDPR: <a href="/guides/gdpr-pdf-redaction">GDPR PDF redaction</a>.</p>
            <h2>Fake redaction risk</h2>
            <p>Black highlight in comment tools leaves text in file — FOIA and GDPR incidents from this mistake — use dedicated redaction tool — verify with select-all search for SSN pattern after export.</p>
            <h2>RatPDF</h2>
            <p><a href="/pdf-redaction">PDF Redaction</a> runs client-side in browser — suitable for quick jobs — legal teams may require audited enterprise redaction for high-volume discovery.</p>
            """,
}

W16_MEGA = """
            <h2>Glossary vs how-to guides</h2>
            <p>This page explains <strong>what the term means</strong> and when it applies. Step-by-step workflows live in linked pillar guides — start there when you need click-by-click help.</p>
            <h2>PDF toolchain on RatPDF</h2>
            <p>Most jobs chain tools: OCR → edit → merge → compress → sign. Pick order by deliverable — portal upload cap → compress last — editable contract → Word conversion before sign.</p>
            <h2>Honest tool limits</h2>
            <p>RatPDF focuses on browser workflows with Ghostscript, pdf2docx, LibreOffice, Tesseract, and iText — not full Acrobat replacement — compare features on <a href="/compare">tool comparisons</a>.</p>
            """

W16_GLOSSARY_CLUSTER = """
            <h2>Related glossary terms</h2>
            <ul>
            <li><a href="/guides/glossary-pdf">What is PDF</a> · <a href="/guides/glossary-compression">Compression</a> · <a href="/guides/glossary-merge">Merge</a></li>
            <li><a href="/guides/glossary-ocr">OCR</a> · <a href="/guides/glossary-metadata">Metadata</a> · <a href="/guides/glossary-font-embedding">Font embedding</a></li>
            <li><a href="/guides/glossary-pdf-a">PDF/A</a> · <a href="/guides/glossary-pdf-ua">PDF/UA</a> · <a href="/guides/glossary-pdf-x">PDF/X</a></li>
            <li><a href="/guides/glossary-digital-signature">Digital signature</a> · <a href="/guides/glossary-acroform">AcroForm</a> · <a href="/guides/glossary-redaction">Redaction</a></li>
            <li><a href="/guides/glossary-ghostscript">Ghostscript</a> · <a href="/guides/glossary-tesseract">Tesseract</a></li>
            <li><a href="/guides/glossary-compress-pdf-online">Compress PDF online</a> · <a href="/guides/glossary-pdf-to-word-converter">PDF to Word converter</a> · <a href="/guides/glossary-pdf-to-text-extractor">PDF to Text extractor</a></li>
            </ul>
            <p>Index: <a href="/guides/pdf-tools">PDF tools hub</a> · <a href="/guides/pdf-troubleshooting">Troubleshooting</a> · <a href="/research/attachment-size-limits">Email size limits research</a>.</p>
            """

W16_1500_TOPUP = """
            <h2>Quick decision tree</h2>
            <ol>
            <li>Is the PDF digital or scanned? — scan → OCR path</li>
            <li>Need edit or plain text? — edit → Word · analyze → Text</li>
            <li>Portal rejected upload? — check <a href="/pdf-size-checker">PDF size checker</a> then compress</li>
            <li>Legal or archive requirement? — check PDF/A, PDF/UA, PDF/X guides</li>
            <li>Sharing externally? — metadata scrub + redaction if PII present</li>
            </ol>
            <h2>Training note for teams</h2>
            <p>Pin pillar guides in shared wiki — consistent tool choice reduces wrong-output support tickets — bookmark <a href="/guides/pdf-tools">PDF tools guide</a> and <a href="/compare">compare tools</a> for onboarding.</p>
            <h2>Sources</h2>
            <p>ISO 32000 PDF specification · Adobe PDF reference · Ghostscript documentation · W3C WCAG 2.2 · PAC (PDF Accessibility Checker) materials.</p>
            """

W16_CLOSING = """
            <h2>More guides</h2>
            <p>Glossary pages define terms — pillar guides show how to execute workflows with RatPDF tools. Pick the linked guide above for step-by-step help.</p>
            <p>Standards and archiving: <a href="/guides/pdf-standards-archiving-hub">standards hub</a> · Security: <a href="/guides/pdf-security-compliance-guide">compliance hub</a>.</p>
            """

PILLAR_SLUGS = set()  # glossary pages are TOFU — no pillar hub pages in this batch
