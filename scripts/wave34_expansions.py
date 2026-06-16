"""Wave 34 — Glossary authority batch 11 (17 terms)."""

W34_SLUGS = [
    "glossary-pdf-portfolio",
    "glossary-pdf-vt",
    "glossary-pdfjs",
    "glossary-pdf-ua-1",
    "glossary-pdf-ua-2",
    "glossary-pdf-x-1a",
    "glossary-pdf-x-3",
    "glossary-pdf-x-4",
    "glossary-pdf2docx",
    "glossary-pdf-lib",
    "glossary-pdfpig",
    "glossary-peppol",
    "glossary-portable-document-format",
    "glossary-portfolio",
    "glossary-preflight",
    "glossary-raster-image",
    "glossary-reading-order",
]

GLOSSARY_SLUGS = set(W34_SLUGS)

W34_DATA = {
    "glossary-pdf-portfolio": {
        "title": "What Is a PDF Portfolio? — Multi-File Grid Viewer (2026)",
        "tool": "/pdf/merge",
        "label": "Merge PDF",
        "pillar": "/guides/glossary-pdf-package",
        "pillar_label": "PDF package glossary",
        "related": "/guides/glossary-portfolio",
        "example": "Agency sends PDF Portfolio with brand PDF, font ZIP, and brief DOCX — client opens grid in Acrobat",
    },
    "glossary-pdf-vt": {
        "title": "What Is PDF/VT? — Variable Data Print Standard (2026)",
        "tool": "/pdf/merge",
        "label": "Merge PDF",
        "pillar": "/guides/glossary-pdf-x",
        "pillar_label": "PDF/X glossary",
        "related": "/guides/glossary-pdf-x-1a",
        "example": "Print shop runs million-piece mail merge — PDF/VT-1 carries record metadata per recipient block",
    },
    "glossary-pdfjs": {
        "title": "What Is PDF.js? — Mozilla Browser PDF Renderer (2026)",
        "tool": "/guides/browser-vs-desktop-pdf-tools",
        "label": "browser vs desktop PDF",
        "pillar": "/guides/glossary-wasm-pdf",
        "pillar_label": "WASM PDF glossary",
        "related": "/guides/glossary-client-side-pdf",
        "example": "Firefox renders inline PDF without plugin — PDF.js parses xref and draws canvas in tab",
    },
    "glossary-pdf-ua-1": {
        "title": "What Is PDF/UA-1? — ISO 14289 Accessibility Standard (2026)",
        "tool": "/pdf/ocrpdf",
        "label": "OCR PDF",
        "pillar": "/guides/glossary-pdf-ua",
        "pillar_label": "PDF/UA glossary",
        "related": "/guides/pdf-accessibility-wcag",
        "example": "Government RFP requires PDF/UA-1 — bidder remediates tags before submission deadline",
    },
    "glossary-pdf-ua-2": {
        "title": "What Is PDF/UA-2? — Updated Accessibility Rules (2026)",
        "tool": "/pdf/ocrpdf",
        "label": "OCR PDF",
        "pillar": "/guides/glossary-pdf-ua-1",
        "pillar_label": "PDF/UA-1 glossary",
        "related": "/guides/wcag-22-pdf",
        "example": "Publisher migrates back catalogue from PDF/UA-1 to UA-2 for WCAG 2.2 alignment",
    },
    "glossary-pdf-x-1a": {
        "title": "What Is PDF/X-1a? — CMYK Print Standard (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/glossary-pdf-x",
        "pillar_label": "PDF/X glossary",
        "related": "/guides/glossary-color-profile",
        "example": "Printer rejects brochure — RGB images and missing output intent — needs PDF/X-1a export",
    },
    "glossary-pdf-x-3": {
        "title": "What Is PDF/X-3? — CMYK + ICC Color Managed Print (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/glossary-pdf-x-1a",
        "pillar_label": "PDF/X-1a glossary",
        "related": "/guides/glossary-cmyk",
        "example": "Catalogue retains ICC profile chain — PDF/X-3 passes preflight where X-1a clipped gamut",
    },
    "glossary-pdf-x-4": {
        "title": "What Is PDF/X-4? — PDF 1.6 Transparency Print Standard (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/glossary-pdf-x-3",
        "pillar_label": "PDF/X-3 glossary",
        "related": "/guides/glossary-transparency",
        "example": "Packaging PDF with live transparency — PDF/X-4 allowed — X-1a would flatten incorrectly",
    },
    "glossary-pdf2docx": {
        "title": "What Is pdf2docx? — Python PDF to Word Library (2026)",
        "tool": "/pdf/pdftodoc",
        "label": "PDF to Word",
        "pillar": "/guides/glossary-pdf-to-word-converter",
        "pillar_label": "PDF to Word converter glossary",
        "related": "/guides/pdf-to-word",
        "example": "Developer prototypes table extraction with pdf2docx — layout breaks on multi-column annual report",
    },
    "glossary-pdf-lib": {
        "title": "What Is pdf-lib? — JavaScript PDF Create &amp; Edit Library (2026)",
        "tool": "/pdf/editpdf",
        "label": "Edit PDF",
        "pillar": "/guides/glossary-client-side-pdf",
        "pillar_label": "client-side PDF glossary",
        "related": "/guides/glossary-pdfjs",
        "example": "SaaS app stamps footer on generated invoice PDF in Node — pdf-lib merges pages server-side",
    },
    "glossary-pdfpig": {
        "title": "What Is PdfPig? — .NET PDF Parsing Library (2026)",
        "tool": "/pdf/pdftotext",
        "label": "PDF to Text",
        "pillar": "/guides/glossary-extract",
        "pillar_label": "extract glossary",
        "related": "/guides/glossary-pdf-lib",
        "example": "C# microservice extracts invoice line text with PdfPig — faster than OCR on digital PDF",
    },
    "glossary-peppol": {
        "title": "What Is Peppol? — E-Invoice Network &amp; BIS Billing (2026)",
        "tool": "/invoice/create",
        "label": "Create Invoice",
        "pillar": "/guides/glossary-e-invoice",
        "pillar_label": "e-invoice glossary",
        "related": "/guides/glossary-factur-x",
        "example": "EU supplier sends Peppol BIS Billing 3.0 — buyer AP auto-ingests — human PDF optional companion",
    },
    "glossary-portable-document-format": {
        "title": "What Is Portable Document Format (PDF)? — Definition &amp; History (2026)",
        "tool": "/guides/beginner-what-is-a-pdf",
        "label": "what is a PDF",
        "pillar": "/guides/glossary-pdf",
        "pillar_label": "PDF glossary",
        "related": "/guides/glossary-iso-32000",
        "example": "New hire asks why contracts are PDF not DOCX — fixed layout and print fidelity across devices",
    },
    "glossary-portfolio": {
        "title": "What Is a Portfolio in PDF Context? — Bundled Deliverables (2026)",
        "tool": "/pdf/merge",
        "label": "Merge PDF",
        "pillar": "/guides/glossary-pdf-portfolio",
        "pillar_label": "PDF portfolio glossary",
        "related": "/guides/glossary-pdf-package",
        "example": "Freelancer delivers logo PDF portfolio folder — client confuses with PDF Portfolio Acrobat feature",
    },
    "glossary-preflight": {
        "title": "What Is PDF Preflight? — Pre-Print Validation (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/glossary-pdf-x-1a",
        "pillar_label": "PDF/X-1a glossary",
        "related": "/guides/glossary-color-profile",
        "example": "Print operator runs preflight — 12 errors on font embedding and RGB — job held until fix",
    },
    "glossary-raster-image": {
        "title": "What Is a Raster Image in PDF? — Bitmap vs Vector (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/glossary-vector-graphics",
        "pillar_label": "vector graphics glossary",
        "related": "/guides/glossary-dpi",
        "example": "Logo pasted as PNG in PDF — raster blurs on zoom — vector SVG would stay sharp",
    },
    "glossary-reading-order": {
        "title": "What Is PDF Reading Order? — Tags &amp; Screen Reader Flow (2026)",
        "tool": "/pdf/ocrpdf",
        "label": "OCR PDF",
        "pillar": "/guides/glossary-tagged-pdf",
        "pillar_label": "tagged PDF glossary",
        "related": "/guides/glossary-structure-tree",
        "example": "Two-column newsletter PDF — screen reader reads across columns — wrong reading order in tags",
    },
}

W34_DEEP = {
    "glossary-pdf-portfolio": """
            <h2>Definition</h2>
            <p><strong>PDF Portfolio</strong> (Acrobat collection) presents multiple files in one PDF wrapper with grid or cover sheet UI — can include non-PDF types — distinct from merging pages into single linear document.</p>
            <h2>vs merge vs package</h2>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>Format</th><th>Behaviour</th></tr></thead>
            <tbody>
            <tr><td>Merge PDF</td><td>One page stream — <a href="/pdf/merge">Merge PDF</a></td></tr>
            <tr><td>PDF package</td><td>Attachments — <a href="/guides/glossary-pdf-package">package</a></td></tr>
            <tr><td>PDF Portfolio</td><td>Acrobat collection UI — may need Acrobat to navigate</td></tr>
            </tbody></table></div>
            <h2>When to avoid portfolio</h2>
            <p>Recipients on mobile or free viewers — merge or zip — <a href="/guides/glossary-portfolio">portfolio term</a>.</p>
            """,
    "glossary-pdf-vt": """
            <h2>Definition</h2>
            <p><strong>PDF/VT</strong> (ISO 16612) standardises variable and transactional print — merges data records with template — PDF/VT-1, VT-2, VT-3 levels for transparency and layers.</p>
            <h2>Use cases</h2>
            <ul>
            <li>Personalised direct mail — name and offer vary per row</li>
            <li>Transactional bills — account block per customer</li>
            <li>High-volume inkjet workflows</li>
            </ul>
            <h2>RatPDF context</h2>
            <p>RatPDF merge/compress for simpler jobs — VT is RIP/print-vendor domain — related print: <a href="/guides/glossary-pdf-x">PDF/X</a> · <a href="/guides/glossary-pdf-x-4">PDF/X-4</a>.</p>
            """,
    "glossary-pdfjs": """
            <h2>Definition</h2>
            <p><strong>PDF.js</strong> is Mozilla's JavaScript PDF renderer — parses PDF structure in browser — draws to canvas — powers Firefox built-in viewer and many embeds.</p>
            <h2>Implications for publishers</h2>
            <ul>
            <li>Linearized PDF loads faster — <a href="/guides/glossary-linearized-pdf">linearized</a></li>
            <li>Broken fonts show substitution — embed subsets</li>
            <li>Forms may differ from Acrobat behaviour</li>
            </ul>
            <h2>vs server render</h2>
            <p>Client-side — no upload — compare <a href="/guides/glossary-client-side-pdf">client-side PDF</a> · <a href="/guides/glossary-wasm-pdf">WASM PDF</a> · <a href="/guides/browser-vs-desktop-pdf-tools">browser vs desktop</a>.</p>
            """,
    "glossary-pdf-ua-1": """
            <h2>Definition</h2>
            <p><strong>PDF/UA-1</strong> (ISO 14289-1) requires logically tagged structure, alt text, correct reading order — machine-testable accessibility — mandatory for many government procurements.</p>
            <h2>Key requirements</h2>
            <ol>
            <li>Tagged structure tree — not scan-only</li>
            <li>Meaningful alt on figures</li>
            <li>No reliance on colour alone</li>
            <li>Metadata title set</li>
            </ol>
            <p>Remediate: export from accessible Word — OCR not sufficient alone — <a href="/guides/tagged-pdf-checklist">tagged checklist</a> · hub: <a href="/guides/glossary-pdf-ua">PDF/UA</a> · <a href="/guides/pdf-accessibility-wcag">WCAG</a>.</p>
            """,
    "glossary-pdf-ua-2": """
            <h2>Definition</h2>
            <p><strong>PDF/UA-2</strong> (ISO 14289-2) updates rules for PDF 2.0 alignment — stricter structure semantics — harmonises with WCAG 2.2 expectations — supersedes UA-1 for new projects where specified.</p>
            <h2>Migration</h2>
            <ul>
            <li>Re-export from modern InDesign/Word tagged pipeline</li>
            <li>Re-test with PAC and screen readers</li>
            <li>Archive UA-1 files remain valid until contract renews</li>
            </ul>
            <p>Prior: <a href="/guides/glossary-pdf-ua-1">PDF/UA-1</a> · <a href="/guides/wcag-22-pdf">WCAG 2.2 PDF</a> · <a href="/guides/glossary-reading-order">reading order</a>.</p>
            """,
    "glossary-pdf-x-1a": """
            <h2>Definition</h2>
            <p><strong>PDF/X-1a</strong> is strictest common print standard — CMYK or spot only — all RGB forbidden — fonts embedded — trapping optional — output intent required.</p>
            <h2>Preflight failures</h2>
            <ul>
            <li>RGB image on page</li>
            <li>Missing output intent ICC</li>
            <li>Non-embedded font</li>
            <li>OPI linked high-res missing</li>
            </ul>
            <p>Fix in design app — <a href="/guides/glossary-preflight">preflight</a> · colour: <a href="/guides/glossary-color-profile">color profile</a> · hub: <a href="/guides/glossary-pdf-x">PDF/X</a>.</p>
            """,
    "glossary-pdf-x-3": """
            <h2>Definition</h2>
            <p><strong>PDF/X-3</strong> allows CMYK plus colour-managed RGB with ICC profiles — more flexible than X-1a for marketing PDFs — still requires output intent.</p>
            <h2>When printers ask for X-3</h2>
            <p>Catalogue with photographer RGB images — printer converts with agreed profile — not for naive RGB without ICC — compare <a href="/guides/glossary-pdf-x-1a">PDF/X-1a</a> · <a href="/guides/glossary-cmyk">CMYK</a>.</p>
            """,
    "glossary-pdf-x-4": """
            <h2>Definition</h2>
            <p><strong>PDF/X-4</strong> based on PDF 1.6 — allows live transparency — no mandatory flattening — layers may remain — common for modern packaging art.</p>
            <h2>vs X-1a</h2>
            <p>X-1a flattens transparency to CMYK — X-4 preserves — RIP must handle transparency correctly — <a href="/guides/glossary-transparency">transparency glossary</a> · <a href="/guides/glossary-layers">layers</a>.</p>
            """,
    "glossary-pdf2docx": """
            <h2>Definition</h2>
            <p><strong>pdf2docx</strong> is an open-source Python library converting PDF layout to DOCX — detects paragraphs and tables — works best on born-digital single-column PDFs.</p>
            <h2>Limits</h2>
            <ul>
            <li>Scanned PDF needs OCR first — <a href="/pdf/ocrpdf">OCR PDF</a></li>
            <li>Multi-column magazines lose order</li>
            <li>Complex tables need manual cleanup</li>
            </ul>
            <p>Browser alt: <a href="/pdf/pdftodoc">PDF to Word</a> · glossary: <a href="/guides/glossary-pdf-to-word-converter">converter term</a> · <a href="/guides/scanned-pdf-to-word">scanned to Word</a>.</p>
            """,
    "glossary-pdf-lib": """
            <h2>Definition</h2>
            <p><strong>pdf-lib</strong> is a TypeScript/JavaScript library to create and modify PDFs — add pages, draw text, embed fonts, fill forms — runs in Node or browser with bundler.</p>
            <h2>Typical uses</h2>
            <ul>
            <li>Dynamic certificate generation</li>
            <li>Stamp watermark server-side</li>
            <li>Merge programmatically</li>
            </ul>
            <p>No GUI — compare end-user <a href="/pdf/editpdf">Edit PDF</a> · parse: <a href="/guides/glossary-pdfpig">PdfPig</a> · render: <a href="/guides/glossary-pdfjs">PDF.js</a>.</p>
            """,
    "glossary-pdfpig": """
            <h2>Definition</h2>
            <p><strong>PdfPig</strong> is a .NET library to read PDF text and geometry — extract words with bounding boxes — no render — useful for invoice parsing pipelines.</p>
            <h2>vs OCR</h2>
            <p>Digital PDF with text operators — PdfPig fast — scan image only — need <a href="/pdf/ocrpdf">OCR</a> — export: <a href="/pdf/pdftotext">PDF to Text</a> · <a href="/guides/glossary-extract">extract glossary</a>.</p>
            """,
    "glossary-peppol": """
            <h2>Definition</h2>
            <p><strong>Peppol</strong> is a network and document standard for cross-border e-procurement — BIS Billing 3.0 XML — Access Points route between buyer and supplier ERPs — PDF human copy optional.</p>
            <h2>Relation to hybrid PDF</h2>
            <p>France Factur-X and Germany ZUGFeRD embed XML in PDF — Peppol often pure XML — <a href="/guides/glossary-factur-x">Factur-X</a> · <a href="/guides/glossary-e-invoice">e-invoice</a> · <a href="/invoice/create">Create Invoice</a>.</p>
            """,
    "glossary-portable-document-format": """
            <h2>Definition</h2>
            <p><strong>PDF (Portable Document Format)</strong> created by Adobe 1993 — open standard ISO 32000 — fixed layout document — text, vector, raster, fonts, forms, encryption — ubiquitous for contracts, invoices, and archives.</p>
            <h2>Why PDF persists</h2>
            <ul>
            <li>Print-identical across OS</li>
            <li>Digital signature and encryption built-in</li>
            <li>Long-term archiving with PDF/A</li>
            <li>Universal viewer support</li>
            </ul>
            <p>Beginner: <a href="/guides/beginner-what-is-a-pdf">what is a PDF</a> · spec: <a href="/guides/glossary-iso-32000">ISO 32000</a> · structure: <a href="/guides/glossary-pdf">PDF glossary</a>.</p>
            """,
    "glossary-portfolio": """
            <h2>Definition</h2>
            <p>In general use, a <strong>portfolio</strong> is a curated collection of work samples — designer PDFs, case studies — often multiple files — may be folder, zip, or merged PDF — not necessarily Acrobat PDF Portfolio format.</p>
            <h2>Delivery options</h2>
            <ol>
            <li>Single merged PDF — <a href="/pdf/merge">Merge PDF</a> — best universal view</li>
            <li>ZIP of assets — IT may block</li>
            <li>Acrobat <a href="/guides/glossary-pdf-portfolio">PDF Portfolio</a> — rich but viewer-dependent</li>
            </ol>
            <p>Compress for email — <a href="/guides/compress-pdf-portfolio">compress portfolio guide</a>.</p>
            """,
    "glossary-preflight": """
            <h2>Definition</h2>
            <p><strong>Preflight</strong> validates PDF against print or compliance profile before plates — checks colour space, fonts, resolution, transparency, bleed — reports errors and warnings.</p>
            <h2>Common profiles</h2>
            <ul>
            <li>PDF/X-1a — <a href="/guides/glossary-pdf-x-1a">PDF/X-1a</a></li>
            <li>PDF/X-4 packaging</li>
            <li>PDF/UA accessibility</li>
            </ul>
            <h2>After failures</h2>
            <p>Fix in source InDesign — not one-click in compress — <a href="/pdf/compress">Compress</a> only after colour-correct export — <a href="/guides/glossary-color-profile">profiles</a>.</p>
            """,
    "glossary-raster-image": """
            <h2>Definition</h2>
            <p>A <strong>raster image</strong> in PDF is a sampled bitmap (JPEG, PNG, TIFF) — fixed pixels — blurs when zoomed — unlike vector paths that scale infinitely.</p>
            <h2>Size impact</h2>
            <p>600 DPI phone photos inflate PDF — scan 300 DPI monochrome for text — <a href="/guides/glossary-dpi">DPI</a> · compress: <a href="/pdf/compress">Compress PDF</a> · compare <a href="/guides/glossary-vector-graphics">vector graphics</a> · <a href="/guides/why-is-pdf-file-so-large">why large</a>.</p>
            """,
    "glossary-reading-order": """
            <h2>Definition</h2>
            <p><strong>Reading order</strong> is sequence assistive technology reads tagged PDF content — may differ from visual layout — multi-column and sidebars need explicit tag order.</p>
            <h2>Fix workflow</h2>
            <ol>
            <li>Export tagged PDF from Word</li>
            <li>Acrobat Reading Order tool for fixes</li>
            <li>VoiceOver/NVDA spot-check</li>
            <li>OCR alone does not set order — <a href="/pdf/ocrpdf">OCR PDF</a></li>
            </ol>
            <p>Related: <a href="/guides/glossary-structure-tree">structure tree</a> · <a href="/guides/glossary-tagged-pdf">tagged PDF</a> · <a href="/guides/glossary-marked-content">marked content</a> · <a href="/guides/beginner-pdf-tags-accessibility">tags basics</a>.</p>
            """,
}

W34_GLOSSARY_CLUSTER = """
            <h2>Glossary batch 11</h2>
            <ul>
            <li><a href="/guides/glossary-pdf-portfolio">PDF Portfolio</a> · <a href="/guides/glossary-portfolio">Portfolio</a> · <a href="/guides/glossary-pdf-package">PDF package</a></li>
            <li><a href="/guides/glossary-pdf-vt">PDF/VT</a> · <a href="/guides/glossary-preflight">Preflight</a></li>
            <li><a href="/guides/glossary-pdf-x-1a">PDF/X-1a</a> · <a href="/guides/glossary-pdf-x-3">PDF/X-3</a> · <a href="/guides/glossary-pdf-x-4">PDF/X-4</a></li>
            <li><a href="/guides/glossary-pdf-ua-1">PDF/UA-1</a> · <a href="/guides/glossary-pdf-ua-2">PDF/UA-2</a></li>
            <li><a href="/guides/glossary-pdfjs">PDF.js</a> · <a href="/guides/glossary-pdf-lib">pdf-lib</a> · <a href="/guides/glossary-pdfpig">PdfPig</a> · <a href="/guides/glossary-pdf2docx">pdf2docx</a></li>
            <li><a href="/guides/glossary-peppol">Peppol</a> · <a href="/guides/glossary-portable-document-format">Portable Document Format</a></li>
            <li><a href="/guides/glossary-raster-image">Raster image</a> · <a href="/guides/glossary-reading-order">Reading order</a></li>
            </ul>
            <p>Prior: <a href="/guides/glossary-jbig2">batch 10</a> · Hub: <a href="/guides/pdf-glossary-hub">PDF glossary hub</a></p>
            """

W34_GLOSSARY_TOPUP = """
            <h2>Glossary batch 11 — concept map</h2>
            <ul>
            <li><strong>Print standards:</strong> PDF/X-1a → X-3 → X-4 → preflight → PDF/VT</li>
            <li><strong>Accessibility:</strong> reading order → PDF/UA-1 → PDF/UA-2 → WCAG</li>
            <li><strong>Dev stack:</strong> PDF.js render · pdf-lib create · PdfPig parse · pdf2docx convert</li>
            <li><strong>E-invoice:</strong> Peppol XML · Factur-X hybrid PDF</li>
            <li><strong>Deliverables:</strong> merge vs package vs portfolio</li>
            </ul>
            <h2>Standards hub</h2>
            <p><a href="/guides/pdf-standards-archiving-hub">Standards hub</a> · <a href="/guides/glossary-pdf-a">PDF/A</a> · <a href="/guides/glossary-pdf-ua">PDF/UA</a> · <a href="/guides/glossary-pdf-x">PDF/X</a></p>
            """

W34_CLOSING = """
            <h2>Related guides</h2>
            <p>Wave 34 upgrades print standards (PDF/X, PDF/VT), accessibility (PDF/UA), developer libraries, Peppol e-invoice, and core PDF terminology.</p>
            <p>Hub: <a href="/guides/pdf-glossary-hub">PDF glossary hub</a> · Next: <a href="/guides/glossary-rgb">RGB</a> · <a href="/guides/glossary-sac-code">SAC code</a> · <a href="/guides/glossary-tagged-pdf">tagged PDF</a></p>
            """
