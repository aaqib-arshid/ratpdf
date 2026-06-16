"""Wave 24 — Beginner batch 2 + how-to text/OCR + email limits + glossary batch 6."""

W24_SLUGS = [
    "beginner-what-is-a-pdf",
    "beginner-when-to-use-pdf",
    "beginner-pdf-hyperlinks",
    "beginner-pdf-fonts-embedding",
    "beginner-pdf-security-basics",
    "beginner-pdf-vs-docx",
    "beginner-pdf-vs-png",
    "how-to-extract-text-from-pdf",
    "how-to-make-pdf-searchable",
    "how-to-ocr-a-scanned-pdf",
    "how-to-compare-two-text-files",
    "email-attachment-limits-2024",
    "email-attachment-limits-2025",
    "email-attachment-limits-2026",
    "glossary-calc-export",
    "glossary-certificate-based-signature",
    "glossary-cid-font",
]

BEGINNER_SLUGS = {
    "beginner-what-is-a-pdf",
    "beginner-when-to-use-pdf",
    "beginner-pdf-hyperlinks",
    "beginner-pdf-fonts-embedding",
    "beginner-pdf-security-basics",
    "beginner-pdf-vs-docx",
    "beginner-pdf-vs-png",
}

HOWTO_SLUGS = {
    "how-to-extract-text-from-pdf",
    "how-to-make-pdf-searchable",
    "how-to-ocr-a-scanned-pdf",
    "how-to-compare-two-text-files",
}

EMAIL_SLUGS = {
    "email-attachment-limits-2024",
    "email-attachment-limits-2025",
    "email-attachment-limits-2026",
}

GLOSSARY_SLUGS = {
    "glossary-calc-export",
    "glossary-certificate-based-signature",
    "glossary-cid-font",
}

W24_DATA = {
    "beginner-what-is-a-pdf": {
        "title": "What Is a PDF? — Portable Document Format Explained (2026)",
        "tool": "/guides/pdf-tools",
        "label": "PDF tools hub",
        "pillar": "/guides/beginner-pdf-basics",
        "pillar_label": "PDF basics",
        "related": "/guides/beginner-when-to-use-pdf",
        "example": "Intern receives first client contract PDF — learns why layout stays fixed unlike Word",
    },
    "beginner-when-to-use-pdf": {
        "title": "When to Use PDF — vs Word, Excel, PNG &amp; Email Body (2026)",
        "tool": "/guides/pdf-tools",
        "label": "PDF tools hub",
        "pillar": "/guides/beginner-what-is-a-pdf",
        "pillar_label": "what is a PDF",
        "related": "/guides/beginner-pdf-vs-docx",
        "example": "Freelancer sends invoice as PDF not DOCX so client cannot silently edit line items",
    },
    "beginner-pdf-hyperlinks": {
        "title": "PDF Hyperlinks Basics — Clickable Links &amp; Broken TOC (2026)",
        "tool": "/pdf/editpdf",
        "label": "Edit PDF",
        "pillar": "/guides/glossary-hyperlink",
        "pillar_label": "hyperlink glossary",
        "related": "/guides/beginner-pdf-bookmarks",
        "example": "Annual report TOC link to page 47 dead after print-to-PDF from browser",
    },
    "beginner-pdf-fonts-embedding": {
        "title": "PDF Fonts &amp; Embedding Basics — Missing Font Boxes (2026)",
        "tool": "/pdf/doctopdf",
        "label": "Word to PDF",
        "pillar": "/guides/beginner-pdf-file-structure",
        "pillar_label": "PDF file structure basics",
        "related": "/guides/embed-fonts-before-printing",
        "example": "Proposal PDF shows square boxes on client PC — custom brand font not embedded",
    },
    "beginner-pdf-security-basics": {
        "title": "PDF Security Basics — Password, Redaction &amp; Watermark (2026)",
        "tool": "/pdf/password",
        "label": "Protect PDF",
        "pillar": "/guides/secure-pdf-workflow",
        "pillar_label": "secure PDF workflow",
        "related": "/guides/beginner-digital-signature-basics",
        "example": "HR shares draft policy PDF — password protect before external pilot group",
    },
    "beginner-pdf-vs-docx": {
        "title": "PDF vs DOCX — When to Send Word vs PDF (2026)",
        "tool": "/pdf/pdftodoc",
        "label": "PDF to Word",
        "pillar": "/guides/pdf-to-word-vs-pdf-to-text",
        "pillar_label": "PDF to Word vs Text",
        "related": "/guides/beginner-when-to-use-pdf",
        "example": "Legal sends final signed contract as PDF — redlines happen in Word only during negotiation",
    },
    "beginner-pdf-vs-png": {
        "title": "PDF vs PNG — Documents vs Single Images (2026)",
        "tool": "/pdf/pdftoimages",
        "label": "PDF to Images",
        "pillar": "/guides/beginner-vector-vs-raster-pdf",
        "pillar_label": "vector vs raster PDF",
        "related": "/guides/pdf-to-images",
        "example": "Designer exports logo as PNG for web but delivers multi-page brand guide as PDF",
    },
    "how-to-extract-text-from-pdf": {
        "title": "How Do I Extract Text from PDF? — Copy, Export &amp; .txt (2026)",
        "tool": "/pdf/pdftotext",
        "label": "PDF to Text",
        "pillar": "/guides/extract-text-scanned-pdf",
        "pillar_label": "extract text from scanned PDF",
        "related": "/guides/pdf-to-text-online",
        "example": "Analyst pulls contract clauses to .txt for Python keyword search script",
    },
    "how-to-make-pdf-searchable": {
        "title": "How Do I Make a PDF Searchable? — OCR Workflow (2026)",
        "tool": "/pdf/ocrpdf",
        "label": "OCR PDF",
        "pillar": "/guides/beginner-ocr-basics",
        "pillar_label": "OCR basics",
        "related": "/guides/ocr-pdf",
        "example": "Paralegal OCRs 400-page scanned deposition so Ctrl+F finds witness name",
    },
    "how-to-ocr-a-scanned-pdf": {
        "title": "How Do I OCR a Scanned PDF? — Step-by-Step (2026)",
        "tool": "/pdf/ocrpdf",
        "label": "OCR PDF",
        "pillar": "/guides/ocr-pdf",
        "pillar_label": "OCR PDF guide",
        "related": "/guides/how-to-make-pdf-searchable",
        "example": "Clerk OCRs incoming fax PDF before archiving in searchable DMS",
    },
    "how-to-compare-two-text-files": {
        "title": "How Do I Compare Two Text Files? — Diff After PDF Extract (2026)",
        "tool": "/text-comparer",
        "label": "Text comparer",
        "pillar": "/guides/text-comparer-guide",
        "pillar_label": "text comparer guide",
        "related": "/guides/how-to-extract-text-from-pdf",
        "example": "Developer diffs policy PDF text extract v1 vs v2 before publishing",
    },
    "email-attachment-limits-2024": {
        "title": "Email Attachment Limits 2024 — PDF Size Reference (Archive)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/email-attachment-size-limits-2026",
        "pillar_label": "email attachment limits 2026 (current)",
        "related": "/research/attachment-size-limits",
        "example": "IT audits 2024 helpdesk tickets — most rejects were 22–28 MB PDF board packs",
    },
    "email-attachment-limits-2025": {
        "title": "Email Attachment Limits 2025 — PDF Size Reference (Archive)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/email-attachment-size-limits-2026",
        "pillar_label": "email attachment limits 2026 (current)",
        "related": "/guides/gmail-vs-outlook-pdf-limits",
        "example": "Ops documents 2025 provider caps before updating internal wiki to 2026 edition",
    },
    "email-attachment-limits-2026": {
        "title": "Email Attachment Limits 2026 — PDF Size Quick Reference",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/email-attachment-size-limits-2026",
        "pillar_label": "full email limits guide (size-limits slug)",
        "related": "/guides/pdf-email-attachment-checklist",
        "example": "Sales checks quick-reference table before sending 24 MB proposal PDF",
    },
    "glossary-calc-export": {
        "title": "What Is Calc Export to PDF? — LibreOffice Spreadsheets (2026)",
        "tool": "/pdf/exceltopdf",
        "label": "Excel to PDF",
        "pillar": "/guides/excel-to-pdf",
        "pillar_label": "Excel to PDF guide",
        "related": "/guides/excel-to-pdf",
        "example": "Analyst exports LibreOffice Calc budget to PDF for board email — fonts must embed",
    },
    "glossary-certificate-based-signature": {
        "title": "What Is a Certificate-Based PDF Signature? — PKI Details (2026)",
        "tool": "/guides/sign-pdf-legally",
        "label": "sign PDF legally",
        "pillar": "/guides/glossary-certificate-signature",
        "pillar_label": "certificate signature glossary",
        "related": "/guides/beginner-digital-signature-basics",
        "example": "EU procurement requires certificate-based signature — RatPDF typed block not accepted",
    },
    "glossary-cid-font": {
        "title": "What Is a CID Font in PDF? — CJK &amp; Composite Fonts (2026)",
        "tool": "/pdf/ocrpdf",
        "label": "OCR PDF",
        "pillar": "/guides/ocr-hindi-pdf",
        "pillar_label": "OCR Hindi PDF guide",
        "related": "/guides/glossary-composite-font",
        "example": "Japanese annual report PDF uses CID font — copy-paste shows garbage without proper encoding",
    },
}

W24_BEGINNER_DEEP = {
    "beginner-what-is-a-pdf": """
            <h2>Definition</h2>
            <p><strong>PDF (Portable Document Format)</strong> packages text, images, fonts, and vector graphics into one file that looks the same on Windows, Mac, phone, and print — created by Adobe, standardized as ISO 32000.</p>
            <h2>Why PDF won</h2>
            <ul>
            <li>Layout locked — WYSIWYG for recipients</li>
            <li>Universal — no “buy Office” barrier for readers</li>
            <li>Signable, compressible, mergeable — full document workflow</li>
            </ul>
            <h2>First tools to try</h2>
            <p><a href="/pdf/merge">Merge</a> · <a href="/pdf/compress">Compress</a> · <a href="/pdf/pdftodoc">PDF to Word</a> · Hub: <a href="/guides/beginner-pdf-basics">PDF basics</a>.</p>
            """,
    "beginner-when-to-use-pdf": """
            <h2>Send PDF when</h2>
            <ul>
            <li>Final version must not be edited — invoices, signed contracts</li>
            <li>Recipient only needs to view/print — no collaboration</li>
            <li>Multiple pages + photos in one attachment</li>
            <li>Portal requires PDF upload slot</li>
            </ul>
            <h2>Send Word/Excel when</h2>
            <p>Active redlines, collaborative budget edits, template reuse — export PDF only at milestone.</p>
            <p>Compare: <a href="/guides/beginner-pdf-vs-docx">PDF vs DOCX</a> · <a href="/guides/beginner-pdf-vs-png">PDF vs PNG</a>.</p>
            """,
    "beginner-pdf-hyperlinks": """
            <h2>Internal vs external links</h2>
            <p><strong>External:</strong> https URL opens browser. <strong>Internal:</strong> jump to page or named destination in same PDF.</p>
            <h2>Broken links</h2>
            <p>Print-to-PDF from browser often strips links — export from source app — verify click before send.</p>
            <p>Glossary: <a href="/guides/glossary-hyperlink">hyperlink</a> · Bookmarks: <a href="/guides/beginner-pdf-bookmarks">bookmarks basics</a>.</p>
            """,
    "beginner-pdf-fonts-embedding": """
            <h2>Embedded vs referenced fonts</h2>
            <p><strong>Embedded:</strong> font file inside PDF — displays everywhere. <strong>Referenced:</strong> uses local font on viewer PC — missing font → tofu boxes.</p>
            <h2>Fix missing fonts</h2>
            <ol>
            <li>Re-export from Word with embed fonts option</li>
            <li><a href="/pdf/doctopdf">Word to PDF</a> on RatPDF embeds common sets</li>
            <li>Substitute standard font before export</li>
            </ol>
            <p>Print: <a href="/guides/embed-fonts-before-printing">embed fonts before printing</a>.</p>
            """,
    "beginner-pdf-security-basics": """
            <h2>Three layers beginners use</h2>
            <ul>
            <li><strong>Password:</strong> <a href="/pdf/password">Protect PDF</a> — block open or restrict print</li>
            <li><strong>Watermark:</strong> DRAFT / CONFIDENTIAL visible mark</li>
            <li><strong>Redaction:</strong> burn out secrets — not black boxes — <a href="/guides/pdf-redaction-permanent">permanent redaction</a></li>
            </ul>
            <h2>Not security</h2>
            <p>Security through obscurity filename — password in same email — fake redaction overlay.</p>
            <p>Hub: <a href="/guides/secure-pdf-workflow">secure PDF workflow</a>.</p>
            """,
    "beginner-pdf-vs-docx": """
            <h2>PDF strengths</h2>
            <p>Fixed layout, universal view, smaller for final send, digital signatures visible.</p>
            <h2>DOCX strengths</h2>
            <p>Track changes, edit tables, template fields, collaboration in Word/Google Docs.</p>
            <h2>Round trip</h2>
            <p>Negotiate in <a href="/pdf/pdftodoc">PDF to Word</a> — finalize with <a href="/pdf/doctopdf">Word to PDF</a> — see <a href="/guides/pdf-to-word-vs-pdf-to-text">Word vs Text guide</a>.</p>
            """,
    "beginner-pdf-vs-png": """
            <h2>PNG is one image</h2>
            <p>Single page, raster pixels — great for web logos and slides — no multi-page narrative.</p>
            <h2>PDF is document</h2>
            <p>Many pages, text select, merge, compress, sign — deliver report not screenshot stack.</p>
            <h2>Convert</h2>
            <p>Page to PNG: <a href="/pdf/pdftoimages">PDF to Images</a> · Images to doc: <a href="/pdf/convertimages">Images to PDF</a>.</p>
            """,
}

W24_HOWTO_DEEP = {
    "how-to-extract-text-from-pdf": """
            <h2>Digital PDF path</h2>
            <ol>
            <li>Try select text in viewer — if works, digital PDF</li>
            <li>Upload to <a href="/pdf/pdftotext">PDF to Text</a></li>
            <li>Download .txt — grep, LLM, or paste to editor</li>
            </ol>
            <h2>Scanned PDF path</h2>
            <p>No selection — <a href="/pdf/ocrpdf">OCR PDF</a> first — then PDF to Text — see <a href="/guides/how-to-ocr-a-scanned-pdf">OCR scanned guide</a>.</p>
            <p>Pillar: <a href="/guides/extract-text-scanned-pdf">extract text scanned PDF</a>.</p>
            """,
    "how-to-make-pdf-searchable": """
            <h2>Searchable = text layer exists</h2>
            <p>Ctrl+F works — copy works — DMS index works — scans need OCR to add hidden text layer.</p>
            <h2>Workflow</h2>
            <ol>
            <li>Upload scan to <a href="/pdf/ocrpdf">OCR PDF</a></li>
            <li>Download searchable PDF</li>
            <li>Test search for known word on page 1</li>
            </ol>
            <p>Basics: <a href="/guides/beginner-ocr-basics">OCR basics</a> · Engine: <a href="/guides/tesseract-vs-online-ocr">Tesseract vs cloud</a>.</p>
            """,
    "how-to-ocr-a-scanned-pdf": """
            <h2>Step-by-step</h2>
            <ol>
            <li>Scan 300 DPI grayscale — or use existing scan PDF</li>
            <li>Upload <a href="/pdf/ocrpdf">OCR PDF</a></li>
            <li>Pick language if prompted — Hindi, English, etc.</li>
            <li>Download — verify random paragraph</li>
            <li>Optional: <a href="/pdf/pdftotext">PDF to Text</a> for plain export</li>
            </ol>
            <h2>Quality tips</h2>
            <p>Deskew crooked pages — crop margins — OCR before compress on scans.</p>
            """,
    "how-to-compare-two-text-files": """
            <h2>PDF diff workflow</h2>
            <ol>
            <li>Extract both PDFs to text — <a href="/guides/how-to-extract-text-from-pdf">extract text guide</a></li>
            <li>Paste into <a href="/text-comparer">Text comparer</a></li>
            <li>Review added/removed lines</li>
            </ol>
            <h2>Limits</h2>
            <p>Layout-heavy PDFs lose tables in text extract — use PDF to Word for clause redlines instead.</p>
            <p>Guide: <a href="/guides/text-comparer-guide">text comparer guide</a>.</p>
            """,
}

W24_EMAIL_DEEP = {
    "email-attachment-limits-2024": """
            <h2>2024 reference snapshot</h2>
            <p>Gmail 25 MB · Outlook ~20–25 MB · Yahoo 25 MB — corporate gateways often lower — archive page for historical IT tickets.</p>
            <p><strong>Current guide:</strong> <a href="/guides/email-attachment-size-limits-2026">email attachment size limits 2026</a> (authoritative workflow).</p>
            <h2>Still-valid tactics</h2>
            <p>Target 18 MB safety margin · compress before split · password separate channel — unchanged year to year.</p>
            """,
    "email-attachment-limits-2025": """
            <h2>2025 reference snapshot</h2>
            <p>Provider stated caps stable — real bottleneck remains Exchange transport rules and Base64 overhead — see <a href="/guides/gmail-vs-outlook-pdf-limits">Gmail vs Outlook</a>.</p>
            <p>Upgrade path: read <a href="/guides/email-attachment-size-limits-2026">2026 full guide</a> for checklist and compress workflow.</p>
            """,
    "email-attachment-limits-2026": """
            <h2>Quick reference 2026</h2>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>Provider</th><th>Stated cap</th><th>Safe PDF target</th></tr></thead>
            <tbody>
            <tr><td>Gmail</td><td>25 MB</td><td>18–20 MB</td></tr>
            <tr><td>Outlook / M365</td><td>20–25 MB</td><td>15–18 MB</td></tr>
            <tr><td>Proton Mail</td><td>25 MB</td><td>18–20 MB</td></tr>
            </tbody></table></div>
            <p>Full workflow: <a href="/guides/email-attachment-size-limits-2026">email attachment size limits 2026</a> · Checklist: <a href="/guides/pdf-email-attachment-checklist">pre-send checklist</a> · Research: <a href="/research/attachment-size-limits">attachment limits research</a>.</p>
            <p>Note: canonical long-form guide uses slug <code>email-attachment-size-limits-2026</code> — this page is quick-reference companion.</p>
            """,
}

W24_GLOSSARY_DEEP = {
    "glossary-calc-export": """
            <h2>Definition</h2>
            <p><strong>Calc export</strong> means saving LibreOffice Calc spreadsheet as PDF — print ranges, grid lines, and font embedding matter for readable financial PDFs.</p>
            <h2>vs Excel export</h2>
            <p>Excel <a href="/pdf/exceltopdf">Excel to PDF</a> on RatPDF for .xlsx — Calc users export PDF from LibreOffice or upload xlsx after conversion.</p>
            <p>Guide: <a href="/guides/excel-to-pdf">Excel to PDF guide</a>.</p>
            """,
    "glossary-certificate-based-signature": """
            <h2>Definition</h2>
            <p><strong>Certificate-based signature</strong> cryptographically binds signer identity to PDF using X.509 certificate — validates in Acrobat with trust chain — eIDAS qualified signatures in EU.</p>
            <h2>vs typed signature</h2>
            <p>RatPDF <a href="/pdf/signtext">Sign PDF</a> typed block is visual approval — not certificate — see <a href="/guides/glossary-certificate-signature">certificate signature glossary</a>.</p>
            """,
    "glossary-cid-font": """
            <h2>Definition</h2>
            <p><strong>CID (Character ID) fonts</strong> map glyph IDs for CJK and complex scripts — common in Japanese, Chinese, Korean PDFs — require proper CMap for copy and search.</p>
            <h2>OCR path</h2>
            <p>When copy garbles — <a href="/pdf/ocrpdf">OCR PDF</a> with correct language — <a href="/guides/ocr-hindi-pdf">multilingual OCR guides</a>.</p>
            <p>Related: <a href="/guides/glossary-composite-font">composite font</a> · <a href="/guides/glossary-cmap">CMap</a> (when published).</p>
            """,
}

W24_DEEP = {
    **W24_BEGINNER_DEEP,
    **W24_HOWTO_DEEP,
    **W24_EMAIL_DEEP,
    **W24_GLOSSARY_DEEP,
}

W24_BEGINNER_CLUSTER = """
            <h2>Beginner hub — batch 2</h2>
            <ul>
            <li><a href="/guides/beginner-what-is-a-pdf">What is a PDF</a> · <a href="/guides/beginner-when-to-use-pdf">When to use PDF</a></li>
            <li><a href="/guides/beginner-pdf-hyperlinks">Hyperlinks</a> · <a href="/guides/beginner-pdf-fonts-embedding">Fonts &amp; embedding</a></li>
            <li><a href="/guides/beginner-pdf-security-basics">Security basics</a> · <a href="/guides/beginner-pdf-tags-accessibility">Tags accessibility</a></li>
            <li><a href="/guides/beginner-pdf-vs-docx">PDF vs DOCX</a> · <a href="/guides/beginner-pdf-vs-png">PDF vs PNG</a></li>
            </ul>
            <p>Batch 1: <a href="/guides/beginner-pdf-basics">PDF basics</a> · Hub: <a href="/guides/pdf-tools">PDF tools</a></p>
            """

W24_TEXT_CLUSTER = """
            <h2>Text &amp; OCR how-to cluster</h2>
            <ul>
            <li><a href="/guides/how-to-extract-text-from-pdf">Extract text from PDF</a></li>
            <li><a href="/guides/how-to-make-pdf-searchable">Make PDF searchable</a></li>
            <li><a href="/guides/how-to-ocr-a-scanned-pdf">OCR a scanned PDF</a></li>
            <li><a href="/guides/how-to-compare-two-text-files">Compare two text files</a></li>
            </ul>
            <p>Pillar: <a href="/guides/ocr-pdf">OCR PDF guide</a> · <a href="/guides/pdf-to-text-online">PDF to text online</a></p>
            """

W24_EMAIL_CLUSTER = """
            <h2>Email limits cluster</h2>
            <ul>
            <li><a href="/guides/email-attachment-size-limits-2026">Size limits 2026 (full guide)</a></li>
            <li><a href="/guides/email-attachment-limits-2026">Limits 2026 quick ref</a></li>
            <li><a href="/guides/email-attachment-limits-2025">Limits 2025 archive</a></li>
            <li><a href="/guides/email-attachment-limits-2024">Limits 2024 archive</a></li>
            <li><a href="/guides/gmail-vs-outlook-pdf-limits">Gmail vs Outlook</a></li>
            </ul>
            """

W24_GLOSSARY_CLUSTER = """
            <h2>Glossary batch 6</h2>
            <ul>
            <li><a href="/guides/glossary-calc-export">Calc export</a></li>
            <li><a href="/guides/glossary-certificate-based-signature">Certificate-based signature</a></li>
            <li><a href="/guides/glossary-cid-font">CID font</a></li>
            <li><a href="/guides/glossary-composite-font">Composite font</a></li>
            <li><a href="/guides/glossary-cmap">CMap</a></li>
            </ul>
            """
