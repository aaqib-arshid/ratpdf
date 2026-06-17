"""Wave 60 — CREATE batch 24 (17 guides, score 62–68). OCR languages + conversion + beginner + workflow."""

W60_SLUGS = [
    "ocr-pdf-italian",
    "ocr-pdf-dutch",
    "ocr-pdf-turkish",
    "ocr-pdf-vietnamese",
    "ocr-pdf-thai",
    "ocr-pdf-hebrew",
    "ocr-pdf-polish",
    "pdf-to-odt",
    "pdf-to-notion",
    "pdf-to-kindle",
    "pdf-to-xml",
    "beginner-pdf-color-spaces",
    "beginner-pdf-font-subsetting",
    "beginner-pdf-linearization",
    "pdf-handoff-design-to-dev",
    "pdf-archive-metadata-schema",
    "pdf-shared-drive-naming-convention",
]

OCR_LANG_CREATE_SLUGS = {
    "ocr-pdf-italian",
    "ocr-pdf-dutch",
    "ocr-pdf-turkish",
    "ocr-pdf-vietnamese",
    "ocr-pdf-thai",
    "ocr-pdf-hebrew",
    "ocr-pdf-polish",
}

CONVERT_CREATE_SLUGS = {"pdf-to-odt", "pdf-to-notion", "pdf-to-kindle", "pdf-to-xml"}

INFO_CREATE_SLUGS = {
    "beginner-pdf-color-spaces",
    "beginner-pdf-font-subsetting",
    "beginner-pdf-linearization",
}

WORKFLOW_CREATE_SLUGS = {
    "pdf-handoff-design-to-dev",
    "pdf-archive-metadata-schema",
    "pdf-shared-drive-naming-convention",
}

W60_OCR_LANG_META = {
    "italian": (
        "Italian",
        "Latin + accents",
        "Rome supplier invoice scan with à, è, é, ì, ò, ù amounts",
        "Grave and acute accents matter on legal terms — proofread totals and partita IVA after OCR.",
    ),
    "dutch": (
        "Dutch",
        "Latin + ij digraph",
        "Amsterdam vendor contract scan with ij and diaeresis (ë, ï)",
        "The ij digraph and trema can mis-split — search the viewer for key nouns and verify BTW/IBAN fields.",
    ),
    "turkish": (
        "Turkish",
        "Latin + dotted/dotless i",
        "Istanbul lease scan with ı, i, ş, ç, ğ, ö, ü",
        "Dotted i (i) vs dotless i (ı) is a common OCR error — proofread names and the vergi numarası carefully.",
    ),
    "vietnamese": (
        "Vietnamese",
        "Latin + tone marks",
        "Hanoi business license scan with stacked diacritics and tone marks",
        "Multiple diacritics per vowel raise error rates — verify names and figures at 300 DPI, proofread tone marks.",
    ),
    "thai": (
        "Thai",
        "Thai script (no word spaces)",
        "Bangkok rental agreement scan in continuous Thai script",
        "Thai has no spaces between words, so line breaks may shift — expect manual reflow; use PDF to Word for layout edits.",
    ),
    "hebrew": (
        "Hebrew",
        "Hebrew RTL",
        "Tel Aviv employment contract scan with Hebrew and English clauses",
        "RTL reading order can shuffle in plain .txt export — keep PDF to Word output for mixed Hebrew/English layout.",
    ),
    "polish": (
        "Polish",
        "Latin + ogonek/stroke",
        "Warsaw invoice scan with ł, ą, ę, ż, ź, ć, ń, ś",
        "Diacritics like ł and ż are easily dropped — proofread the NIP number and beneficiary names after OCR.",
    ),
}

W60_DATA = {
    "pdf-to-odt": {
        "title": "PDF to ODT — Convert for LibreOffice &amp; OpenOffice (2026)",
        "tool": "/pdf/pdftodoc",
        "label": "PDF to Word",
        "pillar": "/guides/pdf-to-word",
        "pillar_label": "PDF to Word guide",
        "related": "/guides/pdf-to-rtf",
        "prog": "/pdf/pdftodoc",
        "example": "Open-source team converts a PDF report to ODT so it opens cleanly in LibreOffice Writer without Microsoft Word",
    },
    "pdf-to-notion": {
        "title": "PDF to Notion — Import Docs into Your Workspace (2026)",
        "tool": "/pdf/pdftomarkdown",
        "label": "PDF to Markdown",
        "pillar": "/guides/pdf-to-text",
        "pillar_label": "PDF to text guide",
        "related": "/guides/pdf-to-word",
        "prog": "/pdf/pdftomarkdown",
        "example": "Product manager converts a PDF spec to Markdown, then pastes it into a Notion page so the team can edit inline",
    },
    "pdf-to-kindle": {
        "title": "PDF to Kindle — Send Documents to Your E-Reader (2026)",
        "tool": "/pdf/pdftodoc",
        "label": "PDF to Word",
        "pillar": "/guides/pdf-to-text",
        "pillar_label": "PDF to text guide",
        "related": "/guides/pdf-to-epub",
        "prog": "/pdf/pdftodoc",
        "example": "Reader reflows a fixed-layout PDF to EPUB/DOCX before Send-to-Kindle so text scales on a small e-ink screen",
    },
    "pdf-to-xml": {
        "title": "PDF to XML — Extract Structured Data (2026)",
        "tool": "/pdf/pdftotext",
        "label": "PDF to Text",
        "pillar": "/guides/pdf-to-text",
        "pillar_label": "PDF to text guide",
        "related": "/guides/pdf-to-excel",
        "prog": "/pdf/pdftotext",
        "example": "Developer extracts invoice fields from PDFs into XML for an ERP import after a text-layer or OCR pass",
    },
    "beginner-pdf-color-spaces": {
        "title": "PDF Color Spaces Explained — CMYK vs RGB (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/pdf-tools",
        "pillar_label": "PDF tools hub",
        "related": "/guides/beginner-pdf-vs-png-for-documents",
        "prog": "/pdf/compress",
        "example": "Designer learns why an RGB screen proof shifts color on a CMYK press and converts before print handoff",
    },
    "beginner-pdf-font-subsetting": {
        "title": "PDF Font Subsetting Explained — Smaller, Portable Files (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/pdf-tools",
        "pillar_label": "PDF tools hub",
        "related": "/guides/pdf-error-font-embedding",
        "prog": "/pdf/compress",
        "example": "Publisher subsets embedded fonts so a brochure PDF shrinks without breaking glyphs on other machines",
    },
    "beginner-pdf-linearization": {
        "title": "PDF Linearization Explained — Fast Web View (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/glossary-linearization",
        "pillar_label": "linearization glossary",
        "related": "/guides/pdf-error-linearization",
        "prog": "/pdf/compress",
        "example": "Web team linearizes a large catalog PDF so the first page renders while the rest streams from the CDN",
    },
    "pdf-handoff-design-to-dev": {
        "title": "PDF Handoff Design to Development — Specs &amp; Assets (2026)",
        "tool": "/pdf/flattenpdf",
        "label": "Flatten PDF",
        "pillar": "/guides/pdf-review-workflow",
        "pillar_label": "PDF review workflow",
        "related": "/guides/best-pdf-editor-for-designers",
        "prog": "/pdf/flattenpdf",
        "example": "Designer flattens a spec PDF, embeds fonts, and annotates measurements before handing it to the dev team",
    },
    "pdf-archive-metadata-schema": {
        "title": "PDF Archive Metadata Schema — Consistent Records (2026)",
        "tool": "/pdf/pdfmetadata",
        "label": "PDF Metadata",
        "pillar": "/guides/pdf-records-management-policy",
        "pillar_label": "records management policy",
        "related": "/guides/pdf-archive-folder-structure",
        "prog": "/pdf/pdfmetadata",
        "example": "Records team standardizes title, author, subject, and retention-class metadata fields across an archive",
    },
    "pdf-shared-drive-naming-convention": {
        "title": "PDF Shared Drive Naming Convention — Findable Files (2026)",
        "tool": "/pdf/merge",
        "label": "Merge PDF",
        "pillar": "/guides/pdf-records-management-policy",
        "pillar_label": "records management policy",
        "related": "/guides/pdf-version-control-best-practices",
        "prog": "/pdf/merge",
        "example": "Ops lead rolls out a ClientName_DocType_YYYY-MM-DD_vN convention so shared-drive PDFs sort and search cleanly",
    },
}

for key, (name, script, example, tips) in W60_OCR_LANG_META.items():
    slug = f"ocr-pdf-{key}"
    W60_DATA[slug] = {
        "title": f"OCR PDF in {name} — Searchable {name} Scans (2026)",
        "tool": "/pdf/ocrpdf",
        "label": "OCR PDF",
        "pillar": "/guides/ocr-pdf",
        "pillar_label": "OCR PDF guide",
        "related": "/guides/make-scanned-pdf-searchable",
        "prog": "/pdf/ocrpdf",
        "example": example,
        "name": name,
        "script": script,
        "tips": tips,
    }


def _d(slug: str, html: str) -> str:
    p = W60_DATA[slug].get("prog", "")
    tail = f'<p>Tool: <a href="{p}">{p}</a></p>' if p else ""
    return html + tail


def _ocr_lang_deep(slug: str) -> str:
    d = W60_DATA[slug]
    return _d(
        slug,
        f"""
            <h2>OCR PDF in {d['name']}</h2>
            <p>Script: {d['script']}. Example: {d['example']}.</p>
            <ol>
            <li>Scan at 300 DPI grayscale — low DPI is the top cause of {d['name']} OCR errors</li>
            <li><a href="/pdf/ocrpdf">OCR PDF</a> — select {d['name']} as the recognition language</li>
            <li>{d['tips']}</li>
            <li>Need layout edits? <a href="/pdf/pdftodoc">PDF to Word</a> preserves structure better than plain text</li>
            </ol>
            <p>More languages: <a href="/guides/ocr-pdf-spanish">Spanish</a> · <a href="/guides/ocr-pdf-french">French</a> · <a href="/guides/ocr-pdf-arabic">Arabic</a> · <a href="/guides/ocr-pdf-poor-quality">Poor-quality scans</a>.</p>
            """,
    )


W60_DEEP = {
    "pdf-to-odt": _d("pdf-to-odt", """
            <h2>PDF to ODT workflow</h2>
            <ol>
            <li><a href="/pdf/pdftodoc">PDF to Word</a> — export DOCX first</li>
            <li>Open the DOCX in LibreOffice Writer → Save As → ODF Text (.odt)</li>
            <li>Check tables and headings — complex layouts may need light cleanup</li>
            <li>Scanned source? <a href="/pdf/ocrpdf">OCR</a> before converting</li>
            </ol>
            <p><a href="/guides/pdf-to-word">PDF to Word</a> · <a href="/guides/pdf-to-rtf">PDF to RTF</a>.</p>
            """),
    "pdf-to-notion": _d("pdf-to-notion", """
            <h2>PDF into Notion</h2>
            <ol>
            <li><a href="/pdf/pdftomarkdown">PDF to Markdown</a> — keeps headings and lists</li>
            <li>In Notion: paste Markdown, or use Import → Markdown</li>
            <li>Re-link images — Markdown export references them separately</li>
            <li>Scanned PDF? <a href="/pdf/ocrpdf">OCR</a> first so text is selectable</li>
            </ol>
            <p><a href="/guides/pdf-to-text">PDF to text</a> · <a href="/guides/pdf-to-word">PDF to Word</a>.</p>
            """),
    "pdf-to-kindle": _d("pdf-to-kindle", """
            <h2>PDF to Kindle</h2>
            <ol>
            <li>Fixed-layout PDFs do not reflow — convert first for small screens</li>
            <li><a href="/pdf/pdftodoc">PDF to Word</a> or EPUB, then Send-to-Kindle</li>
            <li>Email the file to your @kindle.com address, or use the Send-to-Kindle app</li>
            <li>Scanned books — <a href="/pdf/ocrpdf">OCR</a> so Kindle can render selectable text</li>
            </ol>
            <p><a href="/guides/pdf-to-epub">PDF to EPUB</a> · <a href="/guides/pdf-to-text">PDF to text</a>.</p>
            """),
    "pdf-to-xml": _d("pdf-to-xml", """
            <h2>PDF to XML</h2>
            <ol>
            <li><a href="/pdf/pdftotext">PDF to Text</a> for raw content, or OCR scans first</li>
            <li>Map repeating fields (invoice no, date, line items) to XML tags</li>
            <li>Validate against your schema (XSD) before ERP import</li>
            <li>Tabular data? <a href="/pdf/pdftoexcel">PDF to Excel</a> then export XML</li>
            </ol>
            <p><a href="/guides/pdf-to-excel">PDF to Excel</a> · <a href="/guides/pdf-to-text">PDF to text</a>.</p>
            """),
    "beginner-pdf-color-spaces": _d("beginner-pdf-color-spaces", """
            <h2>PDF color spaces</h2>
            <table class="table table-sm">
            <tr><th>Space</th><th>Use for</th></tr>
            <tr><td>RGB</td><td>Screen, web, email preview</td></tr>
            <tr><td>CMYK</td><td>Commercial print — match press profile</td></tr>
            <tr><td>Grayscale</td><td>Scanned text, smaller files, B/W print</td></tr>
            </table>
            <p>Convert RGB to CMYK before print handoff to avoid color shift. <a href="/guides/beginner-pdf-vs-png-for-documents">PDF vs PNG</a>.</p>
            """),
    "beginner-pdf-font-subsetting": _d("beginner-pdf-font-subsetting", """
            <h2>Font subsetting</h2>
            <ul>
            <li>Subsetting embeds only the glyphs the document actually uses</li>
            <li>Smaller files and consistent rendering on other machines</li>
            <li>Full embedding is safer for documents that will be edited later</li>
            <li>Subset + flatten before print to lock appearance</li>
            </ul>
            <p><a href="/guides/pdf-error-font-embedding">Font embedding errors</a> · <a href="/guides/pdf-embed-fonts-for-print">Embed fonts for print</a>.</p>
            """),
    "beginner-pdf-linearization": _d("beginner-pdf-linearization", """
            <h2>Linearization (Fast Web View)</h2>
            <ul>
            <li>Restructures a PDF so the first page renders before the full file downloads</li>
            <li>Improves perceived load time for large PDFs served over the web</li>
            <li>Check File → Properties → Fast Web View: Yes in Acrobat</li>
            <li>Some re-saves drop linearization — re-enable before CDN upload</li>
            </ul>
            <p><a href="/guides/glossary-linearization">Glossary</a> · <a href="/guides/pdf-error-linearization">Fix linearization failed</a>.</p>
            """),
    "pdf-handoff-design-to-dev": _d("pdf-handoff-design-to-dev", """
            <h2>Design-to-dev handoff</h2>
            <ol>
            <li><a href="/pdf/flattenpdf">Flatten</a> the proof so layers do not shift on the dev machine</li>
            <li>Embed fonts and annotate spacing, colors (hex), and asset names</li>
            <li>Export assets separately — PDF is the spec, not the asset source</li>
            <li>Version the spec PDF so devs build against the approved revision</li>
            </ol>
            <p><a href="/guides/best-pdf-editor-for-designers">Designer editor picks</a> · <a href="/guides/pdf-review-workflow">Review workflow</a>.</p>
            """),
    "pdf-archive-metadata-schema": _d("pdf-archive-metadata-schema", """
            <h2>Archive metadata schema</h2>
            <ol>
            <li>Define required fields: Title, Author, Subject, Keywords, retention class</li>
            <li>Use consistent controlled vocabulary — not free text per person</li>
            <li>Set fields with <a href="/pdf/pdfmetadata">PDF Metadata</a> on ingest</li>
            <li>Pair with a destruction date so retention automation can act</li>
            </ol>
            <p><a href="/guides/pdf-records-management-policy">RM policy</a> · <a href="/guides/pdf-archive-folder-structure">Folder structure</a>.</p>
            """),
    "pdf-shared-drive-naming-convention": _d("pdf-shared-drive-naming-convention", """
            <h2>Naming convention</h2>
            <ol>
            <li>Pattern: <code>ClientName_DocType_YYYY-MM-DD_vN.pdf</code></li>
            <li>ISO dates (YYYY-MM-DD) sort chronologically in any file browser</li>
            <li>No spaces or special characters that break links and scripts</li>
            <li>Version suffix (v1, v2, FINAL) — pair with a version log</li>
            </ol>
            <p><a href="/guides/pdf-version-control-best-practices">Version control</a> · <a href="/guides/pdf-archive-folder-structure">Folder structure</a>.</p>
            """),
}

for key in W60_OCR_LANG_META:
    W60_DEEP[f"ocr-pdf-{key}"] = _ocr_lang_deep(f"ocr-pdf-{key}")

W60_CREATE_CLUSTER = """
            <h2>CREATE batch 24 — languages, conversion, fundamentals</h2>
            <ul>
            <li>OCR languages: <a href="/guides/ocr-pdf-italian">Italian</a> · <a href="/guides/ocr-pdf-dutch">Dutch</a> · <a href="/guides/ocr-pdf-turkish">Turkish</a> · <a href="/guides/ocr-pdf-vietnamese">Vietnamese</a> · <a href="/guides/ocr-pdf-thai">Thai</a> · <a href="/guides/ocr-pdf-hebrew">Hebrew</a> · <a href="/guides/ocr-pdf-polish">Polish</a></li>
            <li>Conversion: <a href="/guides/pdf-to-odt">PDF to ODT</a> · <a href="/guides/pdf-to-notion">PDF to Notion</a> · <a href="/guides/pdf-to-kindle">PDF to Kindle</a> · <a href="/guides/pdf-to-xml">PDF to XML</a></li>
            <li>Fundamentals: <a href="/guides/beginner-pdf-color-spaces">Color spaces</a> · <a href="/guides/beginner-pdf-font-subsetting">Font subsetting</a> · <a href="/guides/beginner-pdf-linearization">Linearization</a></li>
            <li>Workflow: <a href="/guides/pdf-handoff-design-to-dev">Design-to-dev handoff</a> · <a href="/guides/pdf-archive-metadata-schema">Archive metadata</a> · <a href="/guides/pdf-shared-drive-naming-convention">Naming convention</a></li>
            </ul>
            <p>OCR hub: <a href="/guides/ocr-pdf">OCR PDF guide</a> · <a href="/guides/make-scanned-pdf-searchable">Make scanned PDF searchable</a></p>
            """

W60_LANG_CLUSTER = """
            <h2>OCR language guides</h2>
            <p>Europe: <a href="/guides/ocr-pdf-italian">Italian</a> · <a href="/guides/ocr-pdf-dutch">Dutch</a> · <a href="/guides/ocr-pdf-polish">Polish</a> · <a href="/guides/ocr-pdf-german">German</a> · <a href="/guides/ocr-pdf-french">French</a></p>
            <p>Asia &amp; MENA: <a href="/guides/ocr-pdf-turkish">Turkish</a> · <a href="/guides/ocr-pdf-vietnamese">Vietnamese</a> · <a href="/guides/ocr-pdf-thai">Thai</a> · <a href="/guides/ocr-pdf-hebrew">Hebrew</a> · <a href="/guides/ocr-pdf-arabic">Arabic</a></p>
            <p>Tips: <a href="/guides/ocr-pdf-poor-quality">Poor-quality scans</a> · <a href="/guides/make-scanned-pdf-searchable">Make searchable</a></p>
            """

W60_TOPUP = """
            <h2>Language &amp; conversion checklist</h2>
            <ol>
            <li>Scan at 300 DPI grayscale before OCR — the single biggest accuracy factor</li>
            <li>Select the correct recognition language — wrong language wrecks accuracy</li>
            <li>Proofread numbers, IDs, and names — diacritics and scripts cause most errors</li>
            <li>Use PDF to Word for layout-sensitive conversions; plain text for data extraction</li>
            </ol>
            """

W60_CLOSING = """
            <h2>Related guides</h2>
            <p>Wave 60 adds seven OCR language guides, four conversion targets, three PDF fundamentals, and three records workflows — CREATE batch 24 of 450.</p>
            <p>Hub: <a href="/guides/ocr-pdf">OCR PDF</a> · CREATE remaining: 42</p>
            """
