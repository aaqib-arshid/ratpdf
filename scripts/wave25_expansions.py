"""Wave 25 — Beginner page size/tags + security how-to + OCR + email 2027 + glossary batch 7."""

W25_SLUGS = [
    "beginner-pdf-page-size-a4-letter",
    "beginner-pdf-tags-accessibility",
    "email-attachment-limits-2027",
    "how-to-add-signature-pdf-free",
    "how-to-password-protect-a-pdf",
    "how-to-protect-pdf-before-sending",
    "how-to-redact-sensitive-information-pdf",
    "how-to-sign-a-pdf",
    "how-to-unlock-a-pdf",
    "how-to-watermark-a-pdf",
    "pdf-text-extraction-empty",
    "ocr-accuracy-tips",
    "ocr-historical-documents",
    "ocr-lecture-notes-students",
    "glossary-cgst",
    "glossary-client-side-pdf",
    "glossary-cmap",
]

BEGINNER_SLUGS = {
    "beginner-pdf-page-size-a4-letter",
    "beginner-pdf-tags-accessibility",
}

SECURITY_HOWTO_SLUGS = {
    "how-to-add-signature-pdf-free",
    "how-to-password-protect-a-pdf",
    "how-to-protect-pdf-before-sending",
    "how-to-redact-sensitive-information-pdf",
    "how-to-sign-a-pdf",
    "how-to-unlock-a-pdf",
    "how-to-watermark-a-pdf",
}

OCR_SLUGS = {
    "pdf-text-extraction-empty",
    "ocr-accuracy-tips",
    "ocr-historical-documents",
    "ocr-lecture-notes-students",
}

EMAIL_SLUGS = {"email-attachment-limits-2027"}

GLOSSARY_SLUGS = {
    "glossary-cgst",
    "glossary-client-side-pdf",
    "glossary-cmap",
}

W25_DATA = {
    "beginner-pdf-page-size-a4-letter": {
        "title": "PDF Page Size A4 vs Letter — US &amp; International Basics (2026)",
        "tool": "/pdf/doctopdf",
        "label": "Word to PDF",
        "pillar": "/guides/beginner-pdf-basics",
        "pillar_label": "PDF basics",
        "related": "/guides/beginner-pdf-file-structure",
        "example": "US consultant sends Letter PDF to EU client — printer crops footer on A4 default tray",
    },
    "beginner-pdf-tags-accessibility": {
        "title": "PDF Tags &amp; Accessibility Basics — Screen Readers (2026)",
        "tool": "/pdf/ocrpdf",
        "label": "OCR PDF",
        "pillar": "/guides/pdf-accessibility-wcag",
        "pillar_label": "PDF accessibility WCAG",
        "related": "/guides/tagged-pdf-checklist",
        "example": "City council publishes benefits PDF — screen reader reads pages out of order without tags",
    },
    "email-attachment-limits-2027": {
        "title": "Email Attachment Limits 2027 — PDF Size Quick Reference",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/email-attachment-size-limits-2026",
        "pillar_label": "email attachment limits 2026 (current)",
        "related": "/guides/email-attachment-limits-2026",
        "example": "IT updates internal wiki with 2027 provider caps before Q1 vendor audit",
    },
    "how-to-add-signature-pdf-free": {
        "title": "How Do I Add a Signature to PDF Free? — Typed &amp; Drawn (2026)",
        "tool": "/pdf/signtext",
        "label": "Sign PDF",
        "pillar": "/guides/sign-pdf",
        "pillar_label": "sign PDF guide",
        "related": "/guides/how-to-sign-a-pdf",
        "example": "Freelancer countersigns SOW PDF in browser before Monday kickoff — no Acrobat license",
    },
    "how-to-password-protect-a-pdf": {
        "title": "How Do I Password Protect a PDF? — Encrypt Before Send (2026)",
        "tool": "/pdf/password",
        "label": "Protect PDF",
        "pillar": "/guides/password-protect-pdf",
        "pillar_label": "password protect PDF guide",
        "related": "/guides/how-to-protect-pdf-before-sending",
        "example": "HR encrypts draft policy PDF — shares passphrase via SMS not email thread",
    },
    "how-to-protect-pdf-before-sending": {
        "title": "How Do I Protect PDF Before Sending? — Watermark, Password, Redact (2026)",
        "tool": "/guides/secure-pdf-workflow",
        "label": "secure PDF workflow",
        "pillar": "/guides/secure-pdf-workflow",
        "pillar_label": "secure PDF workflow hub",
        "related": "/guides/how-to-password-protect-a-pdf",
        "example": "Sales marks proposal DRAFT watermark then password-protects before external pilot",
    },
    "how-to-redact-sensitive-information-pdf": {
        "title": "How Do I Redact Sensitive Information in PDF? — Permanent Removal (2026)",
        "tool": "/pdf-redaction",
        "label": "PDF Redaction",
        "pillar": "/guides/pdf-redaction",
        "pillar_label": "PDF redaction guide",
        "related": "/guides/pdf-redaction-permanent",
        "example": "Paralegal redacts account numbers from discovery PDF — black box overlay failed copy-paste test",
    },
    "how-to-sign-a-pdf": {
        "title": "How Do I Sign a PDF? — Free Online Workflow (2026)",
        "tool": "/pdf/signtext",
        "label": "Sign PDF",
        "pillar": "/guides/sign-pdf-legally",
        "pillar_label": "sign PDF legally",
        "related": "/guides/how-to-add-signature-pdf-free",
        "example": "Operations lead signs vendor NDA PDF on phone before warehouse shipment release",
    },
    "how-to-unlock-a-pdf": {
        "title": "How Do I Unlock a PDF? — Remove Password When Authorized (2026)",
        "tool": "/pdf/unlockpdf",
        "label": "Unlock PDF",
        "pillar": "/guides/unlock-pdf",
        "pillar_label": "unlock PDF guide",
        "related": "/guides/remove-password-from-pdf",
        "example": "Admin unlocks archived board pack to merge with Q4 appendix before re-encrypting",
    },
    "how-to-watermark-a-pdf": {
        "title": "How Do I Watermark a PDF? — DRAFT &amp; CONFIDENTIAL (2026)",
        "tool": "/pdf/watermark",
        "label": "Watermark PDF",
        "pillar": "/guides/watermark-pdf",
        "pillar_label": "watermark PDF guide",
        "related": "/guides/watermark-vs-password-pdf",
        "example": "Product team stamps CONFIDENTIAL on roadmap PDF before investor preview",
    },
    "pdf-text-extraction-empty": {
        "title": "Empty Text Extraction from PDF — Why Copy Returns Nothing (2026)",
        "tool": "/pdf/ocrpdf",
        "label": "OCR PDF",
        "pillar": "/guides/how-to-extract-text-from-pdf",
        "pillar_label": "extract text from PDF",
        "related": "/guides/how-to-make-pdf-searchable",
        "example": "Analyst exports contract PDF to .txt — file is blank because source was scan without OCR",
    },
    "ocr-accuracy-tips": {
        "title": "OCR Accuracy Tips — DPI, Deskew &amp; Language (2026)",
        "tool": "/pdf/ocrpdf",
        "label": "OCR PDF",
        "pillar": "/guides/how-to-ocr-a-scanned-pdf",
        "pillar_label": "OCR a scanned PDF",
        "related": "/guides/tesseract-vs-online-ocr",
        "example": "Records clerk rescans 200 DPI skewed deeds at 300 DPI — name hit rate jumps from 60% to 95%",
    },
    "ocr-historical-documents": {
        "title": "OCR Historical Documents — Archives, Newspapers &amp; Old Fonts (2026)",
        "tool": "/pdf/ocrpdf",
        "label": "OCR PDF",
        "pillar": "/guides/ocr-accuracy-tips",
        "pillar_label": "OCR accuracy tips",
        "related": "/guides/ocr-pdf",
        "example": "Genealogy volunteer OCRs 1920s newspaper clipping PDF — Gothic font needs manual spot-check",
    },
    "ocr-lecture-notes-students": {
        "title": "OCR Lecture Notes for Students — Handwriting &amp; Whiteboard PDFs (2026)",
        "tool": "/pdf/ocrpdf",
        "label": "OCR PDF",
        "pillar": "/guides/beginner-ocr-basics",
        "pillar_label": "OCR basics",
        "related": "/guides/pdf-to-text-on-iphone",
        "example": "Student OCRs phone photo of whiteboard notes before exam — searches Ctrl+F for formula",
    },
    "glossary-cgst": {
        "title": "What Is CGST on an Invoice PDF? — India GST Context (2026)",
        "tool": "/pdf/exceltopdf",
        "label": "Excel to PDF",
        "pillar": "/guides/excel-to-pdf",
        "pillar_label": "Excel to PDF guide",
        "related": "/guides/glossary-gst-invoice",
        "example": "Accountant exports GST invoice from Tally to PDF — CGST line must match e-invoice schema",
    },
    "glossary-client-side-pdf": {
        "title": "What Is Client-Side PDF Processing? — Browser vs Server (2026)",
        "tool": "/guides/browser-vs-desktop-pdf-tools",
        "label": "browser vs desktop PDF tools",
        "pillar": "/home/security",
        "pillar_label": "RatPDF security",
        "related": "/guides/pdf-tool-security-comparison",
        "example": "Legal reviews vendor — RatPDF processes in browser without permanent server storage of PHI",
    },
    "glossary-cmap": {
        "title": "What Is a CMap in PDF? — Character Mapping for CJK (2026)",
        "tool": "/pdf/ocrpdf",
        "label": "OCR PDF",
        "pillar": "/guides/glossary-cid-font",
        "pillar_label": "CID font glossary",
        "related": "/guides/glossary-composite-font",
        "example": "Japanese report PDF search fails — missing CMap means glyph IDs not mapped to Unicode",
    },
}

W25_BEGINNER_DEEP = {
    "beginner-pdf-page-size-a4-letter": """
            <h2>A4 vs Letter dimensions</h2>
            <p><strong>A4:</strong> 210 × 297 mm (8.27 × 11.69 in) — ISO default in EU, Asia, Australia. <strong>US Letter:</strong> 8.5 × 11 in — North America default in Word and printers.</p>
            <h2>Why it matters in PDF</h2>
            <ul>
            <li>Footer/header cropped when wrong tray size assumed</li>
            <li>Forms designed for Letter may clip on A4 government portals</li>
            <li>Merge mixes page sizes — set explicit size in source app before export</li>
            </ul>
            <p>Structure: <a href="/guides/beginner-pdf-file-structure">PDF file structure basics</a> · Hub: <a href="/guides/beginner-pdf-basics">PDF basics</a>.</p>
            """,
    "beginner-pdf-tags-accessibility": """
            <h2>What are PDF tags?</h2>
            <p><strong>Tags</strong> are a hidden structure tree — headings, paragraphs, lists — that screen readers use for logical order. Untagged PDFs may read columns in wrong sequence.</p>
            <h2>Scans vs born-digital</h2>
            <p>Scanned PDFs have no tags until remediated — <a href="/pdf/ocrpdf">OCR PDF</a> adds text layer but not full tagging. Export accessible Word then <a href="/pdf/doctopdf">Word to PDF</a> for better structure.</p>
            <p>Checklist: <a href="/guides/tagged-pdf-checklist">tagged PDF checklist</a> · WCAG: <a href="/guides/pdf-accessibility-wcag">accessibility WCAG guide</a>.</p>
            """,
}

W25_SECURITY_DEEP = {
    "how-to-add-signature-pdf-free": """
            <h2>Free signature options</h2>
            <ol>
            <li>Upload PDF to <a href="/pdf/signtext">Sign PDF</a></li>
            <li>Type name or draw signature block on signature line</li>
            <li>Download signed PDF — flatten if recipient must not move block</li>
            </ol>
            <h2>Limits</h2>
            <p>Typed signature is visual approval — not EU qualified e-sign — see <a href="/guides/sign-pdf-legally">sign PDF legally</a>.</p>
            """,
    "how-to-password-protect-a-pdf": """
            <h2>Step-by-step</h2>
            <ol>
            <li>Upload to <a href="/pdf/password">Protect PDF</a></li>
            <li>Set user password (blocks open) and/or owner restrictions</li>
            <li>Download encrypted PDF</li>
            <li>Share password on separate channel — not email body</li>
            </ol>
            <p>Full guide: <a href="/guides/password-protect-pdf">password protect PDF</a> · Before send: <a href="/guides/how-to-protect-pdf-before-sending">protect before sending</a>.</p>
            """,
    "how-to-protect-pdf-before-sending": """
            <h2>Choose the right control</h2>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>Risk</th><th>Tool</th></tr></thead>
            <tbody>
            <tr><td>Draft leak</td><td><a href="/pdf/watermark">Watermark</a> DRAFT</td></tr>
            <tr><td>Unauthorized open</td><td><a href="/pdf/password">Password protect</a></td></tr>
            <tr><td>PII disclosure</td><td><a href="/pdf-redaction">Redaction</a></td></tr>
            </tbody></table></div>
            <p>Hub: <a href="/guides/secure-pdf-workflow">secure PDF workflow</a> · Checklist: <a href="/guides/pdf-email-attachment-checklist">email attachment checklist</a>.</p>
            """,
    "how-to-redact-sensitive-information-pdf": """
            <h2>Permanent redaction workflow</h2>
            <ol>
            <li>Duplicate master PDF — never redact only copy</li>
            <li>Mark regions in <a href="/pdf-redaction">PDF Redaction</a></li>
            <li>Export — verify with Ctrl+F and copy-paste</li>
            <li>Log approver for audit</li>
            </ol>
            <p>Black boxes fail — see <a href="/guides/blackout-text-in-pdf">blackout vs true redaction</a> · Deep: <a href="/guides/pdf-redaction-permanent">permanent redaction</a>.</p>
            """,
    "how-to-sign-a-pdf": """
            <h2>Sign in browser</h2>
            <ol>
            <li>Upload contract or NDA PDF</li>
            <li><a href="/pdf/signtext">Sign PDF</a> — place signature on line</li>
            <li>Download — email to counterparty</li>
            </ol>
            <h2>When typed is enough</h2>
            <p>Many B2B approvals — not property deeds or EU QES — <a href="/guides/sign-pdf-legally">legal context guide</a>.</p>
            """,
    "how-to-unlock-a-pdf": """
            <h2>Authorized unlock</h2>
            <p>Supply valid password at <a href="/pdf/unlockpdf">Unlock PDF</a> — RatPDF does not crack unknown passwords. Only documents you own or may decrypt.</p>
            <h2>After unlock</h2>
            <p>Merge, compress, redact — re-<a href="/guides/password-protect-pdf">protect</a> final external copy. Guide: <a href="/guides/unlock-pdf">unlock PDF guide</a>.</p>
            """,
    "how-to-watermark-a-pdf": """
            <h2>Add watermark</h2>
            <ol>
            <li>Upload PDF to <a href="/pdf/watermark">Watermark PDF</a></li>
            <li>Enter DRAFT, CONFIDENTIAL, or custom text</li>
            <li>Download — preview diagonal mark on page 1</li>
            </ol>
            <p>Watermark ≠ encryption — pair with <a href="/guides/password-protect-pdf">password</a> for sensitive externals — <a href="/guides/watermark-vs-password-pdf">watermark vs password</a>.</p>
            """,
}

W25_OCR_DEEP = {
    "pdf-text-extraction-empty": """
            <h2>Why extraction is empty</h2>
            <ul>
            <li><strong>Scanned PDF:</strong> image pages — no text objects — need <a href="/pdf/ocrpdf">OCR PDF</a> first</li>
            <li><strong>Protected PDF:</strong> copy restriction — <a href="/guides/unlock-pdf">unlock</a> if authorized</li>
            <li><strong>Garbled encoding:</strong> CJK CID fonts — see <a href="/guides/glossary-cmap">CMap glossary</a></li>
            </ul>
            <p>Workflow: <a href="/guides/how-to-extract-text-from-pdf">extract text guide</a> · <a href="/guides/how-to-make-pdf-searchable">make searchable</a>.</p>
            """,
    "ocr-accuracy-tips": """
            <h2>Scan settings</h2>
            <ul>
            <li><strong>300 DPI</strong> grayscale for text — 200 DPI misses small footnotes</li>
            <li>Deskew crooked pages before OCR</li>
            <li>Correct language pack — Hindi vs English</li>
            <li>OCR before heavy compress on scans</li>
            </ul>
            <p>Engine choice: <a href="/guides/tesseract-vs-online-ocr">Tesseract vs online OCR</a> · Steps: <a href="/guides/how-to-ocr-a-scanned-pdf">OCR scanned PDF</a>.</p>
            """,
    "ocr-historical-documents": """
            <h2>Archive challenges</h2>
            <p>Fraktur fonts, bleed-through, stains, column layouts — expect manual correction pass. Scan at 400 DPI for faint ink — crop margins — OCR one article per PDF for QA.</p>
            <h2>Workflow</h2>
            <p><a href="/pdf/ocrpdf">OCR PDF</a> → spot-check names and dates → <a href="/pdf/pdftotext">PDF to Text</a> for index. Tips: <a href="/guides/ocr-accuracy-tips">OCR accuracy tips</a>.</p>
            """,
    "ocr-lecture-notes-students": """
            <h2>Phone photo to searchable PDF</h2>
            <ol>
            <li>Photograph board straight-on — even light — fill frame</li>
            <li><a href="/pdf/convertimages">Images to PDF</a> if multiple photos</li>
            <li><a href="/pdf/ocrpdf">OCR PDF</a> — pick language</li>
            <li>Ctrl+F exam topics — <a href="/pdf/pdftotext">PDF to Text</a> for Anki import</li>
            </ol>
            <p>Handwriting OCR is imperfect — type critical formulas manually. Mobile: <a href="/guides/pdf-to-text-on-iphone">PDF to text on iPhone</a>.</p>
            """,
}

W25_EMAIL_DEEP = {
    "email-attachment-limits-2027": """
            <h2>Quick reference 2027</h2>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>Provider</th><th>Stated cap</th><th>Safe PDF target</th></tr></thead>
            <tbody>
            <tr><td>Gmail</td><td>25 MB</td><td>18–20 MB</td></tr>
            <tr><td>Outlook / M365</td><td>20–25 MB</td><td>15–18 MB</td></tr>
            <tr><td>Proton Mail</td><td>25 MB</td><td>18–20 MB</td></tr>
            </tbody></table></div>
            <p>Authoritative workflow: <a href="/guides/email-attachment-size-limits-2026">email attachment size limits 2026</a> · Quick ref: <a href="/guides/email-attachment-limits-2026">limits 2026 companion</a> · Archive: <a href="/guides/email-attachment-limits-2025">2025</a> · <a href="/guides/email-attachment-limits-2024">2024</a>.</p>
            <p>Provider caps change slowly — real bottleneck remains corporate transport rules and Base64 overhead — <a href="/guides/gmail-vs-outlook-pdf-limits">Gmail vs Outlook</a>.</p>
            """,
}

W25_GLOSSARY_DEEP = {
    "glossary-cgst": """
            <h2>Definition</h2>
            <p><strong>CGST (Central Goods and Services Tax)</strong> is the central-government component on intra-state India supplies — appears on GST invoice PDFs alongside SGST or as IGST for inter-state.</p>
            <h2>On invoice PDFs</h2>
            <p>Line items must show HSN, taxable value, CGST rate and amount — export from accounting software to PDF for e-invoice portal upload — <a href="/guides/excel-to-pdf">Excel to PDF</a> for spreadsheets.</p>
            """,
    "glossary-client-side-pdf": """
            <h2>Definition</h2>
            <p><strong>Client-side PDF processing</strong> runs in the browser (WebAssembly/JavaScript) — file may not persist on vendor servers — contrast with server upload pipelines.</p>
            <h2>When it matters</h2>
            <p>PHI, legal privilege, export-controlled drawings — review <a href="/home/security">security page</a> · Compare: <a href="/guides/browser-vs-desktop-pdf-tools">browser vs desktop</a> · <a href="/guides/pdf-tool-security-comparison">security comparison</a>.</p>
            """,
    "glossary-cmap": """
            <h2>Definition</h2>
            <p><strong>CMap (Character Map)</strong> translates character codes to Unicode glyphs in PDF — essential for <a href="/guides/glossary-cid-font">CID fonts</a> in Japanese, Chinese, Korean documents.</p>
            <h2>Symptoms of missing CMap</h2>
            <p>Copy-paste garbage, search misses, screen reader silence — fix source export or <a href="/pdf/ocrpdf">OCR PDF</a> with correct language. Related: <a href="/guides/glossary-composite-font">composite font</a>.</p>
            """,
}

W25_DEEP = {
    **W25_BEGINNER_DEEP,
    **W25_SECURITY_DEEP,
    **W25_OCR_DEEP,
    **W25_EMAIL_DEEP,
    **W25_GLOSSARY_DEEP,
}

W25_BEGINNER_CLUSTER = """
            <h2>Beginner hub — page size &amp; accessibility</h2>
            <ul>
            <li><a href="/guides/beginner-pdf-page-size-a4-letter">Page size A4 vs Letter</a></li>
            <li><a href="/guides/beginner-pdf-tags-accessibility">Tags &amp; accessibility</a></li>
            <li><a href="/guides/beginner-pdf-basics">PDF basics hub</a></li>
            </ul>
            <p>Batch 2: <a href="/guides/beginner-what-is-a-pdf">What is PDF</a> · <a href="/guides/beginner-pdf-security-basics">Security basics</a></p>
            """

W25_SECURITY_CLUSTER = """
            <h2>Security how-to cluster</h2>
            <ul>
            <li><a href="/guides/how-to-sign-a-pdf">Sign a PDF</a> · <a href="/guides/how-to-add-signature-pdf-free">Add signature free</a></li>
            <li><a href="/guides/how-to-password-protect-a-pdf">Password protect</a> · <a href="/guides/how-to-unlock-a-pdf">Unlock PDF</a></li>
            <li><a href="/guides/how-to-watermark-a-pdf">Watermark PDF</a></li>
            <li><a href="/guides/how-to-redact-sensitive-information-pdf">Redact sensitive info</a></li>
            <li><a href="/guides/how-to-protect-pdf-before-sending">Protect before sending</a></li>
            </ul>
            <p>Hubs: <a href="/guides/secure-pdf-workflow">Secure workflow</a> · <a href="/guides/sign-pdf-legally">Sign legally</a></p>
            """

W25_OCR_CLUSTER = """
            <h2>OCR &amp; text troubleshooting cluster</h2>
            <ul>
            <li><a href="/guides/pdf-text-extraction-empty">Empty text extraction</a></li>
            <li><a href="/guides/ocr-accuracy-tips">OCR accuracy tips</a></li>
            <li><a href="/guides/ocr-historical-documents">Historical documents</a></li>
            <li><a href="/guides/ocr-lecture-notes-students">Lecture notes (students)</a></li>
            </ul>
            <p>Pillar: <a href="/guides/how-to-ocr-a-scanned-pdf">OCR scanned PDF</a> · <a href="/guides/ocr-pdf">OCR PDF guide</a></p>
            """

W25_EMAIL_CLUSTER = """
            <h2>Email limits cluster</h2>
            <ul>
            <li><a href="/guides/email-attachment-size-limits-2026">Size limits 2026 (full guide)</a></li>
            <li><a href="/guides/email-attachment-limits-2027">Limits 2027 quick ref</a></li>
            <li><a href="/guides/email-attachment-limits-2026">Limits 2026 quick ref</a></li>
            <li><a href="/guides/email-attachment-limits-2025">Limits 2025 archive</a></li>
            <li><a href="/guides/gmail-vs-outlook-pdf-limits">Gmail vs Outlook</a></li>
            </ul>
            """

W25_GLOSSARY_CLUSTER = """
            <h2>Glossary batch 7</h2>
            <ul>
            <li><a href="/guides/glossary-cgst">CGST</a></li>
            <li><a href="/guides/glossary-client-side-pdf">Client-side PDF</a></li>
            <li><a href="/guides/glossary-cmap">CMap</a></li>
            <li><a href="/guides/glossary-cid-font">CID font</a></li>
            <li><a href="/guides/glossary-composite-font">Composite font</a></li>
            </ul>
            """
