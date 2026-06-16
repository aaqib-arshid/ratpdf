"""Wave 23 — Beginner basics batch + how-to spokes + checklist + glossary batch 5."""

W23_SLUGS = [
    "beginner-pdf-basics",
    "beginner-ocr-basics",
    "beginner-pdf-compression-basics",
    "beginner-pdf-file-structure",
    "beginner-pdf-forms-basics",
    "beginner-digital-signature-basics",
    "beginner-pdf-bookmarks",
    "beginner-pdf-accessibility-basics",
    "beginner-vector-vs-raster-pdf",
    "beginner-pdf-color-space-rgb-cmyk",
    "how-to-combine-images-into-pdf",
    "how-to-split-a-pdf",
    "how-to-split-pdf-for-email",
    "pdf-email-attachment-checklist",
    "glossary-blob-storage",
    "glossary-browser-based-processing",
    "glossary-certificate-signature",
]

BEGINNER_SLUGS = {
    "beginner-pdf-basics",
    "beginner-ocr-basics",
    "beginner-pdf-compression-basics",
    "beginner-pdf-file-structure",
    "beginner-pdf-forms-basics",
    "beginner-digital-signature-basics",
    "beginner-pdf-bookmarks",
    "beginner-pdf-accessibility-basics",
    "beginner-vector-vs-raster-pdf",
    "beginner-pdf-color-space-rgb-cmyk",
}

HOWTO_SLUGS = {
    "how-to-combine-images-into-pdf",
    "how-to-split-a-pdf",
    "how-to-split-pdf-for-email",
}

CHECKLIST_SLUGS = {"pdf-email-attachment-checklist"}

GLOSSARY_SLUGS = {
    "glossary-blob-storage",
    "glossary-browser-based-processing",
    "glossary-certificate-signature",
}

W23_DATA = {
    "beginner-pdf-basics": {
        "title": "PDF Basics — What PDFs Are &amp; First Tasks (2026)",
        "tool": "/guides/pdf-tools",
        "label": "PDF tools hub",
        "pillar": "/guides/beginner-what-is-a-pdf",
        "pillar_label": "what is a PDF",
        "related": "/guides/beginner-when-to-use-pdf",
        "example": "New hire receives contract PDF — learns view, search, merge, and compress before first client send",
    },
    "beginner-ocr-basics": {
        "title": "OCR Basics — Scanned PDFs vs Digital Text (2026)",
        "tool": "/pdf/ocrpdf",
        "label": "OCR PDF",
        "pillar": "/guides/ocr-pdf",
        "pillar_label": "OCR PDF guide",
        "related": "/guides/ocr-vs-pdf-to-text",
        "example": "Student scans library chapter — OCR makes PDF searchable before highlighting quotes",
    },
    "beginner-pdf-compression-basics": {
        "title": "PDF Compression Basics — Size, Quality &amp; When to Compress (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/compress-pdf-guide",
        "pillar_label": "compress PDF guide",
        "related": "/guides/pdf-compression-benchmark",
        "example": "Freelancer shrinks 18 MB portfolio PDF to fit Gmail without blurry text",
    },
    "beginner-pdf-file-structure": {
        "title": "PDF File Structure Basics — Objects, Pages &amp; Metadata (2026)",
        "tool": "/pdf/pdfmetadata",
        "label": "PDF Metadata",
        "pillar": "/guides/beginner-pdf-metadata-explained",
        "pillar_label": "PDF metadata explained",
        "related": "/guides/glossary-embedded-files",
        "example": "Developer inspects PDF metadata JSON before publishing API documentation export",
    },
    "beginner-pdf-forms-basics": {
        "title": "PDF Forms Basics — Fillable Fields vs Flat PDFs (2026)",
        "tool": "/pdf/editpdf",
        "label": "Edit PDF",
        "pillar": "/guides/edit-pdf-forms",
        "pillar_label": "edit PDF forms guide",
        "related": "/guides/beginner-pdf-basics",
        "example": "Employee fills HR onboarding PDF in browser — discovers some government forms are flat scans",
    },
    "beginner-digital-signature-basics": {
        "title": "Digital Signature Basics — Typed, Image &amp; Qualified E-Sign (2026)",
        "tool": "/pdf/signtext",
        "label": "Sign PDF",
        "pillar": "/guides/sign-pdf-legally",
        "pillar_label": "sign PDF legally guide",
        "related": "/guides/add-signature-to-pdf",
        "example": "Consultant adds typed signature block to SOW — learns when DocuSign is required instead",
    },
    "beginner-pdf-bookmarks": {
        "title": "PDF Bookmarks Basics — Navigation Outline in Long Documents (2026)",
        "tool": "/pdf/pdfmetadata",
        "label": "PDF Metadata",
        "pillar": "/guides/glossary-bookmark",
        "pillar_label": "bookmark glossary",
        "related": "/guides/organize-pdf-pages",
        "example": "Policy reader jumps to Chapter 4 via bookmark panel instead of scrolling 200 pages",
    },
    "beginner-pdf-accessibility-basics": {
        "title": "PDF Accessibility Basics — Tags, Alt Text &amp; Screen Readers (2026)",
        "tool": "/guides/pdf-accessibility-wcag",
        "label": "PDF accessibility WCAG",
        "pillar": "/guides/glossary-accessibility",
        "pillar_label": "accessibility glossary",
        "related": "/guides/pdf-ua-accessibility",
        "example": "Designer learns why exported InDesign PDF fails university accessibility checker",
    },
    "beginner-vector-vs-raster-pdf": {
        "title": "Vector vs Raster PDF — Logos, Text &amp; Photo Quality (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/beginner-pdf-basics",
        "pillar_label": "PDF basics",
        "related": "/guides/glossary-downsampling",
        "example": "Marketing PDF logo stays sharp at zoom but hero photo pixelates after aggressive compress",
    },
    "beginner-pdf-color-space-rgb-cmyk": {
        "title": "PDF Color Space Basics — RGB vs CMYK for Screen &amp; Print (2026)",
        "tool": "/guides/pdf-x-print-standard",
        "label": "PDF/X print standard",
        "pillar": "/guides/glossary-cmyk",
        "pillar_label": "CMYK glossary",
        "related": "/guides/glossary-grayscale",
        "example": "Brand red looks dull on office printer — PDF still RGB not CMYK for press",
    },
    "how-to-combine-images-into-pdf": {
        "title": "How Do I Combine Images into PDF? — JPG &amp; PNG to One File (2026)",
        "tool": "/pdf/convertimages",
        "label": "Images to PDF",
        "pillar": "/guides/images-to-pdf",
        "pillar_label": "images to PDF guide",
        "related": "/guides/images-to-pdf-without-adobe",
        "example": "Tenant photographs 12 receipt photos on phone — combines into one expense PDF",
    },
    "how-to-split-a-pdf": {
        "title": "How Do I Split a PDF? — Extract Pages Online (2026)",
        "tool": "/pdf/split",
        "label": "Split PDF",
        "pillar": "/guides/split-pdf",
        "pillar_label": "split PDF guide",
        "related": "/guides/split-pdf-page-range",
        "example": "Homeowner extracts insurance declaration page 3 from 40-page homeowner policy PDF",
    },
    "how-to-split-pdf-for-email": {
        "title": "How Do I Split PDF for Email? — Parts Under Attachment Limits (2026)",
        "tool": "/pdf/split",
        "label": "Split PDF",
        "pillar": "/guides/compress-vs-split",
        "pillar_label": "compress vs split guide",
        "related": "/guides/email-attachment-size-limits-2026",
        "example": "Legal cannot compress scanned fine print further — splits exhibit into Part1 and Part2 for Gmail",
    },
    "pdf-email-attachment-checklist": {
        "title": "PDF Email Attachment Checklist — Before You Hit Send (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/email-attachment-size-limits-2026",
        "pillar_label": "email attachment limits 2026",
        "related": "/guides/gmail-vs-outlook-pdf-limits",
        "example": "Accountant runs five-point checklist — catches 26 MB board pack before Friday client blast",
    },
    "glossary-blob-storage": {
        "title": "What Is Blob Storage for PDFs? — Cloud Archives &amp; URLs (2026)",
        "tool": "/guides/compress-pdf-cloud-storage",
        "label": "compress for cloud storage",
        "pillar": "/guides/beginner-pdf-file-structure",
        "pillar_label": "PDF file structure basics",
        "related": "/guides/compress-pdf-cloud-storage",
        "example": "IT stores compressed PDF archive in S3 — signed URL for partner download",
    },
    "glossary-browser-based-processing": {
        "title": "What Is Browser-Based PDF Processing? — Upload, Server, Download (2026)",
        "tool": "/guides/pdf-tools",
        "label": "PDF tools hub",
        "pillar": "/guides/browser-vs-desktop-pdf-tools",
        "pillar_label": "browser vs desktop PDF tools",
        "related": "/guides/pdf-tool-security-comparison",
        "example": "Remote worker merges PDFs in Chrome without IT-approved desktop install",
    },
    "glossary-certificate-signature": {
        "title": "What Is a Certificate PDF Signature? — PKI &amp; Qualified E-Sign (2026)",
        "tool": "/guides/sign-pdf-legally",
        "label": "sign PDF legally",
        "pillar": "/guides/beginner-digital-signature-basics",
        "pillar_label": "digital signature basics",
        "related": "/guides/glossary-owner-password",
        "example": "Regulated deal requires qualified certificate signature — typed RatPDF block not sufficient",
    },
}

W23_BEGINNER_DEEP = {
    "beginner-pdf-basics": """
            <h2>What you will use PDFs for</h2>
            <ul>
            <li><strong>Read &amp; share:</strong> contracts, invoices, manuals — universal layout</li>
            <li><strong>Combine:</strong> <a href="/pdf/merge">Merge PDF</a> multiple files in order</li>
            <li><strong>Shrink:</strong> <a href="/pdf/compress">Compress PDF</a> for email and portals</li>
            <li><strong>Convert:</strong> <a href="/pdf/pdftodoc">PDF to Word</a> for edits</li>
            <li><strong>Sign:</strong> <a href="/pdf/signtext">Sign PDF</a> typed approvals</li>
            </ul>
            <h2>Digital vs scanned PDF</h2>
            <p>Digital PDFs have selectable text — copy works. Scanned PDFs are photos of pages — need <a href="/guides/beginner-ocr-basics">OCR basics</a> before search or extract.</p>
            <h2>First-week checklist</h2>
            <ol>
            <li>Bookmark <a href="/guides/pdf-tools">PDF tools hub</a></li>
            <li>Try merge on two harmless sample files</li>
            <li>Run compress — compare size before/after</li>
            <li>Read <a href="/guides/beginner-when-to-use-pdf">when to use PDF</a> vs Word</li>
            </ol>
            """,
    "beginner-ocr-basics": """
            <h2>When you need OCR</h2>
            <p>Phone scan of contract, faxed form, library book chapter — image-only pages — <a href="/pdf/ocrpdf">OCR PDF</a> adds hidden text layer for search and copy.</p>
            <h2>OCR vs PDF to Text</h2>
            <p>OCR stays inside PDF — searchable in viewer. <a href="/pdf/pdftotext">PDF to Text</a> exports .txt file — see <a href="/guides/ocr-vs-pdf-to-text">OCR vs PDF to text</a>.</p>
            <h2>Quality tips</h2>
            <ul>
            <li>300 DPI grayscale for typed forms</li>
            <li>Straighten skewed scans before upload</li>
            <li>OCR before compress on scans — not after</li>
            <li>Verify random paragraph after OCR</li>
            </ul>
            <p>Compare engines: <a href="/guides/tesseract-vs-online-ocr">Tesseract vs online OCR</a>.</p>
            """,
    "beginner-pdf-compression-basics": """
            <h2>Why PDFs get large</h2>
            <p>Embedded photos, 600 DPI scans, full-bleed marketing art — not magic ZIP — re-encodes images inside PDF structure.</p>
            <h2>Three levels (RatPDF)</h2>
            <ul>
            <li><strong>Less:</strong> signed scans, legal stamps</li>
            <li><strong>Recommended:</strong> email, LMS, most portals</li>
            <li><strong>Extreme:</strong> last resort — verify 100% zoom</li>
            </ul>
            <h2>When not to compress</h2>
            <p>Already under cap — unnecessary quality risk. Fine legal print already soft — try <a href="/guides/compress-vs-split">split</a> instead.</p>
            <p>Benchmark: <a href="/guides/pdf-compression-benchmark">compression benchmark guide</a>.</p>
            """,
    "beginner-pdf-file-structure": """
            <h2>Inside a PDF file</h2>
            <p>PDF is not one flat image — object tree: pages, fonts, images, metadata, optional attachments — ISO 32000 standard.</p>
            <h2>Key concepts</h2>
            <ul>
            <li><strong>Page object:</strong> what you see per sheet</li>
            <li><strong>Font embedding:</strong> <a href="/guides/beginner-pdf-fonts-embedding">fonts basics</a> — missing fonts break on other PCs</li>
            <li><strong>Metadata:</strong> title, author — <a href="/guides/beginner-pdf-metadata-explained">metadata explained</a></li>
            <li><strong>Attachments:</strong> <a href="/guides/glossary-attachments">embedded files</a></li>
            </ul>
            <h2>Inspect</h2>
            <p><a href="/pdf/pdfmetadata">PDF Metadata</a> tool exports properties JSON — scrub author before external share.</p>
            """,
    "beginner-pdf-forms-basics": """
            <h2>Fillable vs flat</h2>
            <p><strong>AcroForm PDF:</strong> click fields, tab between boxes — <a href="/guides/edit-pdf-forms">edit forms guide</a>. <strong>Flat scan:</strong> image of paper — type with overlay or print-sign-scan.</p>
            <h2>Workflow</h2>
            <ol>
            <li>Open in <a href="/pdf/editpdf">Edit PDF</a></li>
            <li>Click field or add text box on flat areas</li>
            <li>Save — flatten if recipient must not edit</li>
            </ol>
            <h2>Government forms</h2>
            <p>Many tax and visa PDFs are flat — browser fill works for simple boxes — complex XFA may need desktop Acrobat once.</p>
            """,
    "beginner-digital-signature-basics": """
            <h2>Signature types</h2>
            <ul>
            <li><strong>Typed block:</strong> name + date — <a href="/pdf/signtext">Sign PDF</a></li>
            <li><strong>Image signature:</strong> PNG of wet ink — Edit PDF</li>
            <li><strong>Certificate / QES:</strong> DocuSign, Adobe Sign — regulated deals</li>
            </ul>
            <h2>Legal weight</h2>
            <p>Many B2B approvals accept typed + email thread — property deeds and some EU contracts need qualified — <a href="/guides/sign-pdf-legally">sign legally guide</a>.</p>
            <h2>Do not</h2>
            <p>Flatten before counterparty edits — compress signed PDF with Less not Extreme.</p>
            """,
    "beginner-pdf-bookmarks": """
            <h2>What bookmarks do</h2>
            <p>Left-panel outline — jump to chapter — essential on 100+ page manuals and board packs — distinct from browser web bookmarks.</p>
            <h2>Create bookmarks</h2>
            <p>Many exports from Word include outline — merge preserves order — add with Acrobat or metadata tools — <a href="/guides/glossary-bookmark">bookmark glossary</a>.</p>
            <h2>Without bookmarks</h2>
            <p>Use <a href="/pdf/pagenumbers">page numbers</a> and cover sheet index — reader finds sections manually.</p>
            """,
    "beginner-pdf-accessibility-basics": """
            <h2>Accessible PDF means</h2>
            <p>Tagged structure — screen readers read in logical order — alt text on images — sufficient contrast — PDF/UA is formal standard.</p>
            <h2>Quick wins</h2>
            <ul>
            <li>Export tagged PDF from Word/InDesign when possible</li>
            <li><a href="/pdf/ocrpdf">OCR</a> scans — adds text layer</li>
            <li>Add alt text in Acrobat or axesPDF — not basic browser edit</li>
            </ul>
            <p>Hub: <a href="/guides/pdf-ua-accessibility">PDF/UA guide</a> · Glossary: <a href="/guides/glossary-alt-text">alt text</a>.</p>
            """,
    "beginner-vector-vs-raster-pdf": """
            <h2>Vector content</h2>
            <p>Text, Illustrator logos, CAD lines — math paths — zoom without pixelation — survives moderate compress well.</p>
            <h2>Raster content</h2>
            <p>Photos, phone scans, flattened slides — pixel grid — aggressive JPEG hurts — <a href="/guides/glossary-jpeg-compression">JPEG in PDF</a>.</p>
            <h2>Practical test</h2>
            <p>Zoom logo to 400% — crisp edges = vector or high-res raster — blocky squares = over-compressed photo.</p>
            <p>Compress: Less on mixed packs — see <a href="/guides/beginner-pdf-compression-basics">compression basics</a>.</p>
            """,
    "beginner-pdf-color-space-rgb-cmyk": """
            <h2>RGB for screen</h2>
            <p>Monitors emit light — PDF from web, slides, phone — RGB default — bright blues and reds.</p>
            <h2>CMYK for print</h2>
            <p>Printers use ink — CMYK conversion shifts colours — brand red may darken — send CMYK PDF to print shop — <a href="/guides/glossary-cmyk">CMYK glossary</a>.</p>
            <h2>Grayscale</h2>
            <p>Text-heavy docs — <a href="/guides/glossary-grayscale">grayscale PDF</a> — smaller file — legal exhibits often grayscale scan.</p>
            <p>Print hub: <a href="/guides/pdf-x-print-standard">PDF/X standard</a>.</p>
            """,
}

W23_HOWTO_DEEP = {
    "how-to-combine-images-into-pdf": """
            <h2>Step-by-step</h2>
            <ol>
            <li>Gather JPG or PNG files — sort chronological order</li>
            <li>Open <a href="/pdf/convertimages">Images to PDF</a></li>
            <li>Upload all images — drag to reorder if needed</li>
            <li>Download single PDF — verify page order</li>
            <li><a href="/pdf/compress">Compress</a> if email cap tight</li>
            </ol>
            <h2>Tips</h2>
            <p>Receipts for expenses — one PDF per month — filename <code>2026-03-receipts.pdf</code>. HEIC iPhone photos — convert to JPG first if tool rejects.</p>
            <p>Guide: <a href="/guides/images-to-pdf">images to PDF</a> · Without Adobe: <a href="/guides/images-to-pdf-without-adobe">images without Adobe</a>.</p>
            """,
    "how-to-split-a-pdf": """
            <h2>Step-by-step</h2>
            <ol>
            <li>Upload PDF to <a href="/pdf/split">Split PDF</a></li>
            <li>Choose page range or extract every page</li>
            <li>Download split files — name clearly</li>
            </ol>
            <h2>Common jobs</h2>
            <ul>
            <li>Extract signature page from contract</li>
            <li>Pull one chapter from manual</li>
            <li>Separate exhibits for court index</li>
            </ul>
            <p>Pillar: <a href="/guides/split-pdf">split PDF guide</a> · Range: <a href="/guides/split-pdf-page-range">split by range</a>.</p>
            """,
    "how-to-split-pdf-for-email": """
            <h2>When split beats compress</h2>
            <p>Scanned legal fine print already soft — portal allows multiple attachments — Part 1 / Part 2 naming.</p>
            <h2>Workflow</h2>
            <ol>
            <li>Check size with <a href="/pdf-size-checker">PDF size checker</a></li>
            <li>Try Recommended compress once</li>
            <li>If blur bad — <a href="/pdf/split">Split PDF</a> at logical break — e.g. pages 1–50 and 51–100</li>
            <li>Email body explains Part 2 follows</li>
            </ol>
            <p>Limits: <a href="/guides/email-attachment-size-limits-2026">email limits 2026</a> · <a href="/guides/gmail-vs-outlook-pdf-limits">Gmail vs Outlook</a>.</p>
            """,
}

W23_CHECKLIST_DEEP = {
    "pdf-email-attachment-checklist": """
            <h2>Pre-send checklist</h2>
            <ol>
            <li><strong>Size:</strong> under recipient cap — target 18 MB for Gmail external — <a href="/pdf-size-checker">size checker</a></li>
            <li><strong>Filename:</strong> <code>ClientName_DocType_2026-03.pdf</code> not <code>Document1.pdf</code></li>
            <li><strong>Zoom QA:</strong> 100% on signatures, amounts, dates</li>
            <li><strong>Right version:</strong> not draft watermark on final send</li>
            <li><strong>Password:</strong> if encrypted — send passphrase separate channel</li>
            <li><strong>Mobile preview:</strong> open on phone before exec sends from taxi</li>
            </ol>
            <h2>If too large</h2>
            <p><a href="/pdf/compress">Compress</a> → still over → <a href="/guides/how-to-split-pdf-for-email">split for email</a> → cloud link last resort.</p>
            <p>Hub: <a href="/guides/email-attachment-size-limits-2026">attachment limits 2026</a>.</p>
            """,
}

W23_GLOSSARY_DEEP = {
    "glossary-blob-storage": """
            <h2>Definition</h2>
            <p><strong>Blob storage</strong> (Azure Blob, S3, GCS) holds binary files — PDF archives — accessed via HTTPS URL or SDK — not a PDF feature but common delivery path after compress.</p>
            <h2>Workflow</h2>
            <ol>
            <li>Compress PDF locally — <a href="/guides/compress-pdf-cloud-storage">cloud storage compress guide</a></li>
            <li>Upload to bucket — set lifecycle delete rule</li>
            <li>Share signed URL — expire in 7 days</li>
            </ol>
            <p>Security: no public bucket listing — scan for malware before upload.</p>
            """,
    "glossary-browser-based-processing": """
            <h2>Definition</h2>
            <p><strong>Browser-based PDF processing</strong> uploads file to server — tool runs merge/compress/OCR — user downloads result — no desktop install.</p>
            <h2>vs desktop</h2>
            <p>Browser wins quick tasks and locked-down laptops — desktop wins batch OCR, air-gap, qualified signatures — <a href="/guides/browser-vs-desktop-pdf-tools">browser vs desktop guide</a>.</p>
            <h2>Privacy</h2>
            <p>HTTPS + auto-delete policy — see <a href="/guides/pdf-tool-security-comparison">security comparison</a>.</p>
            """,
    "glossary-certificate-signature": """
            <h2>Definition</h2>
            <p><strong>Certificate signature</strong> uses PKI digital certificate — identity bound to key — Adobe blue ribbon — eIDAS qualified — not same as typed name block.</p>
            <h2>When required</h2>
            <p>EU qualified contracts, some government filings, regulated finance — use DocuSign QES or national ID signing — RatPDF typed sign for internal approval only.</p>
            <p>Basics: <a href="/guides/beginner-digital-signature-basics">digital signature basics</a> · Legal: <a href="/guides/sign-pdf-legally">sign PDF legally</a>.</p>
            """,
}

W23_DEEP = {
    **W23_BEGINNER_DEEP,
    **W23_HOWTO_DEEP,
    **W23_CHECKLIST_DEEP,
    **W23_GLOSSARY_DEEP,
}

W23_BEGINNER_CLUSTER = """
            <h2>Beginner PDF guides</h2>
            <ul>
            <li><a href="/guides/beginner-pdf-basics">PDF basics</a> · <a href="/guides/beginner-what-is-a-pdf">What is a PDF</a></li>
            <li><a href="/guides/beginner-ocr-basics">OCR basics</a> · <a href="/guides/beginner-pdf-compression-basics">Compression basics</a></li>
            <li><a href="/guides/beginner-pdf-file-structure">File structure</a> · <a href="/guides/beginner-pdf-forms-basics">Forms basics</a></li>
            <li><a href="/guides/beginner-digital-signature-basics">Digital signature</a> · <a href="/guides/beginner-pdf-bookmarks">Bookmarks</a></li>
            <li><a href="/guides/beginner-pdf-accessibility-basics">Accessibility</a> · <a href="/guides/beginner-vector-vs-raster-pdf">Vector vs raster</a></li>
            <li><a href="/guides/beginner-pdf-color-space-rgb-cmyk">RGB vs CMYK</a> · <a href="/guides/beginner-when-to-use-pdf">When to use PDF</a></li>
            </ul>
            <p>Hub: <a href="/guides/pdf-tools">PDF tools</a></p>
            """

W23_HOWTO_CLUSTER = """
            <h2>How-to PDF workflows</h2>
            <ul>
            <li><a href="/guides/how-to-combine-images-into-pdf">Combine images into PDF</a></li>
            <li><a href="/guides/how-to-split-a-pdf">Split a PDF</a></li>
            <li><a href="/guides/how-to-split-pdf-for-email">Split PDF for email</a></li>
            <li><a href="/guides/how-to-merge-pdf-files">Merge PDF files</a></li>
            </ul>
            <p>Checklist: <a href="/guides/pdf-email-attachment-checklist">email attachment checklist</a></p>
            """

W23_GLOSSARY_CLUSTER = """
            <h2>Glossary batch 5</h2>
            <ul>
            <li><a href="/guides/glossary-blob-storage">Blob storage</a></li>
            <li><a href="/guides/glossary-browser-based-processing">Browser-based processing</a></li>
            <li><a href="/guides/glossary-certificate-signature">Certificate signature</a></li>
            <li><a href="/guides/glossary-certificate-based-signature">Certificate-based signature</a></li>
            <li><a href="/guides/glossary-cid-font">CID font</a></li>
            </ul>
            """
