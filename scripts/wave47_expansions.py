"""Wave 47 — CREATE batch 11 (17 guides, score 74–75). Device merge, errors, a11y, persona tools."""

W47_SLUGS = [
    "pdf-error-font-embedding",
    "merge-pdf-on-iphone",
    "merge-pdf-on-ipad",
    "merge-pdf-on-chromebook",
    "merge-pdf-on-linux",
    "merge-pdf-on-windows-11",
    "pdf-to-google-docs",
    "pdf-form-accessibility-tags",
    "fix-pdf-reading-order",
    "pdf-embed-fonts-for-print",
    "pdf-litigation-hold-archive",
    "best-browser-pdf-tools-for-accountants",
    "best-browser-pdf-tools-for-archivists",
    "best-browser-pdf-tools-for-bookkeepers",
    "best-browser-pdf-tools-for-construction-managers",
    "best-browser-pdf-tools-for-consultants",
    "best-browser-pdf-tools-for-designers",
]

DEVICE_CREATE_SLUGS = {
    "merge-pdf-on-iphone",
    "merge-pdf-on-ipad",
    "merge-pdf-on-chromebook",
    "merge-pdf-on-linux",
    "merge-pdf-on-windows-11",
}

TROUBLESHOOT_CREATE_SLUGS = {"pdf-error-font-embedding"}

CONVERT_CREATE_SLUGS = {"pdf-to-google-docs"}

FORM_CREATE_SLUGS = {"pdf-form-accessibility-tags"}

ACCESSIBILITY_CREATE_SLUGS = {"fix-pdf-reading-order"}

PRINT_CREATE_SLUGS = {"pdf-embed-fonts-for-print"}

ARCHIVAL_CREATE_SLUGS = {"pdf-litigation-hold-archive"}

PERSONA_CREATE_SLUGS = {
    "best-browser-pdf-tools-for-accountants",
    "best-browser-pdf-tools-for-archivists",
    "best-browser-pdf-tools-for-bookkeepers",
    "best-browser-pdf-tools-for-construction-managers",
    "best-browser-pdf-tools-for-consultants",
    "best-browser-pdf-tools-for-designers",
}

W47_DEVICE_META = {
    "iphone": (
        "iPhone",
        "Safari",
        "Field rep merges site inspection PDFs from Files app before email to PM",
    ),
    "ipad": (
        "iPad",
        "Safari",
        "Consultant merges slide deck and appendix PDFs in Split View before client meeting",
    ),
    "chromebook": (
        "Chromebook",
        "Chrome",
        "Student merges lab report PDFs in school Chromebook browser without Play Store install",
    ),
    "linux": (
        "Linux",
        "Firefox",
        "Developer merges release notes PDFs on Ubuntu workstation via browser merge",
    ),
    "windows-11": (
        "Windows 11",
        "Edge",
        "HR merges offer letter, policy, and benefits PDFs in Edge without Acrobat install",
    ),
}

W47_PERSONA_META = {
    "accountants": (
        "Accountants",
        "Merge bank statement PDFs, compress audit evidence packs, and check invoice metadata before close",
        "/pdf/merge",
        "Merge PDF",
    ),
    "archivists": (
        "Archivists",
        "OCR legacy scans, export PDF/A access copies, and audit metadata before ingesting records",
        "/pdf/ocrpdf",
        "OCR PDF",
    ),
    "bookkeepers": (
        "Bookkeepers",
        "Merge monthly receipt PDFs, split vendor statements, and compress before client portal upload",
        "/pdf/merge",
        "Merge PDF",
    ),
    "construction-managers": (
        "Construction Managers",
        "Merge RFI and submittal PDFs, flatten markups, and compress site photo bundles for owner review",
        "/pdf/merge",
        "Merge PDF",
    ),
    "consultants": (
        "Consultants",
        "Watermark DRAFT deliverables, merge exhibits, and redact client identifiers before external send",
        "/pdf/watermark",
        "Watermark PDF",
    ),
    "designers": (
        "Designers",
        "Flatten transparency, embed fonts, and hand off print-ready PDF/X packs to commercial printer",
        "/pdf/flattenpdf",
        "Flatten PDF",
    ),
}

W47_DATA = {
    "pdf-error-font-embedding": {
        "title": "PDF Font Embedding Failed — Fix &amp; Preflight (2026)",
        "tool": "/pdf/flattenpdf",
        "label": "Flatten PDF",
        "pillar": "/guides/pdf-troubleshooting",
        "pillar_label": "PDF troubleshooting",
        "related": "/guides/commercial-print-pdf-handoff",
        "prog": "/pdf/flattenpdf",
        "example": "Designer export fails font embedding — subset missing glyph — flatten or outline fonts before print handoff",
    },
    "pdf-to-google-docs": {
        "title": "PDF to Google Docs — Upload &amp; Edit Workflow (2026)",
        "tool": "/pdf/pdftodoc",
        "label": "PDF to Word",
        "pillar": "/guides/pdf-to-word-vs-google-docs",
        "pillar_label": "PDF to Word vs Google Docs",
        "related": "/guides/pdf-to-word",
        "prog": "/pdf/pdftodoc",
        "example": "Teacher converts syllabus PDF to DOCX — uploads to Google Docs — fixes table formatting for LMS link",
    },
    "pdf-form-accessibility-tags": {
        "title": "PDF Form Accessibility Tags — Labels &amp; Tab Order (2026)",
        "tool": "/pdf/editpdf",
        "label": "Edit PDF",
        "pillar": "/guides/create-fillable-pdf",
        "pillar_label": "create fillable PDF",
        "related": "/guides/pdf-form-field-validation",
        "prog": "/pdf/editpdf",
        "example": "Gov portal form PDF — each field gets visible label tag — logical tab order — PAC checker pass",
    },
    "fix-pdf-reading-order": {
        "title": "Fix PDF Reading Order — Screen Reader Flow (2026)",
        "tool": "/pdf/ocrpdf",
        "label": "OCR PDF",
        "pillar": "/guides/pdf-ua-accessibility",
        "pillar_label": "PDF/UA accessibility",
        "related": "/guides/tagged-pdf-checklist",
        "prog": "/pdf/ocrpdf",
        "example": "Policy PDF fails NVDA — columns read out of order — retag structure tree — verify H1–H3 sequence",
    },
    "pdf-embed-fonts-for-print": {
        "title": "Embed Fonts in PDF for Print — Subset &amp; Outline (2026)",
        "tool": "/pdf/flattenpdf",
        "label": "Flatten PDF",
        "pillar": "/guides/commercial-print-pdf-handoff",
        "pillar_label": "commercial print handoff",
        "related": "/guides/pdf-x-print-standard",
        "prog": "/pdf/flattenpdf",
        "example": "Brand brochure uses custom OTF — embed subset on export — preflight confirms 100% fonts embedded",
    },
    "pdf-litigation-hold-archive": {
        "title": "PDF Litigation Hold Archiving — Preserve &amp; Suspend Delete (2026)",
        "tool": "/pdf/pdfmetadata",
        "label": "PDF Metadata",
        "pillar": "/guides/pdf-retention-policy",
        "pillar_label": "PDF retention policy",
        "related": "/guides/document-retention-pdf",
        "prog": "/pdf/pdfmetadata",
        "example": "Legal issues hold on matter PDFs — destruction schedule paused — custodian log tracks every export copy",
    },
}

for device, (name, browser, example) in W47_DEVICE_META.items():
    slug = f"merge-pdf-on-{device}"
    pillar = "/guides/merge-pdf-windows-11" if device == "windows-11" else "/guides/pdf-device-workflows-hub"
    pillar_label = "merge Windows 11 (reference)" if device == "windows-11" else "device workflows hub"
    W47_DATA[slug] = {
        "title": f"Merge PDF on {name} — {browser} Browser Workflow (2026)",
        "tool": "/pdf/merge",
        "label": "Merge PDF",
        "pillar": pillar,
        "pillar_label": pillar_label,
        "related": "/guides/merge-pdf-on-mac",
        "prog": "/pdf/merge",
        "example": example,
        "device": name,
        "browser": browser,
    }

for persona, (title, example, tool, label) in W47_PERSONA_META.items():
    slug = f"best-browser-pdf-tools-for-{persona}"
    W47_DATA[slug] = {
        "title": f"Best Browser PDF Tools for {title} — Workflow Picks (2026)",
        "tool": tool,
        "label": label,
        "pillar": "/guides/browser-vs-desktop-pdf-tools",
        "pillar_label": "browser vs desktop PDF tools",
        "related": "/guides/choose-pdf-tool",
        "prog": tool,
        "example": example,
        "persona": title,
    }


def _d(slug: str, html: str) -> str:
    p = W47_DATA[slug].get("prog", "")
    tail = f'<p>Tool: <a href="{p}">{p}</a></p>' if p else ""
    return html + tail


def _device_deep(slug: str) -> str:
    d = W47_DATA[slug]
    return _d(
        slug,
        f"""
            <h2>Merge PDF on {d['device']}</h2>
            <p>Browser: {d['browser']} — no app install required.</p>
            <ol>
            <li>Save PDFs to Files/Downloads — numeric prefixes <code>01_</code>, <code>02_</code></li>
            <li>Open {d['browser']} → <a href="/pdf/merge">Merge PDF</a></li>
            <li>Upload queue — drag to correct order — merge</li>
            <li><a href="/pdf/compress">Compress</a> if email or portal cap exceeded</li>
            </ol>
            <p>Hub: <a href="/guides/pdf-device-workflows-hub">device workflows</a> · <a href="/guides/merge-pdf">merge guide</a>.</p>
            """,
    )


def _persona_deep(slug: str) -> str:
    d = W47_DATA[slug]
    return _d(
        slug,
        f"""
            <h2>Browser PDF toolkit for {d['persona']}</h2>
            <p>Typical tasks: {d['example']}.</p>
            <ul>
            <li><a href="/pdf/merge">Merge</a> — combine multi-file deliverables</li>
            <li><a href="/pdf/compress">Compress</a> — meet email and portal size caps</li>
            <li><a href="/pdf/ocrpdf">OCR</a> — searchable scans before archive</li>
            <li><a href="/pdf/password">Protect</a> — password before external share</li>
            </ul>
            <p><a href="/guides/browser-vs-desktop-pdf-tools">Browser vs desktop</a> · <a href="/compare">Compare vendors</a>.</p>
            """,
    )


W47_DEEP = {
    "pdf-error-font-embedding": _d("pdf-error-font-embedding", """
            <h2>Font embedding failures</h2>
            <ul>
            <li>Font not licensed for embedding — swap or outline</li>
            <li>Subset missing special characters — full embed or flatten</li>
            <li>Corrupt font cache — re-export from source app</li>
            <li>Print shop rejects — run preflight embed check</li>
            </ul>
            <p><a href="/guides/pdf-embed-fonts-for-print">Embed fonts guide</a> · <a href="/pdf/flattenpdf">Flatten PDF</a>.</p>
            """),
    "pdf-to-google-docs": _d("pdf-to-google-docs", """
            <h2>PDF to Google Docs path</h2>
            <ol>
            <li>Digital PDF — <a href="/pdf/pdftodoc">PDF to Word</a> first for best structure</li>
            <li>Upload DOCX to Google Drive → Open with Google Docs</li>
            <li>Scanned PDF — <a href="/pdf/ocrpdf">OCR</a> before convert</li>
            <li>Fix tables and headers in Docs — export PDF if needed</li>
            </ol>
            <p><a href="/guides/pdf-to-word-vs-google-docs">Word vs Docs comparison</a>.</p>
            """),
    "pdf-form-accessibility-tags": _d("pdf-form-accessibility-tags", """
            <h2>Accessible form tags</h2>
            <ul>
            <li>Every field needs visible label linked in tag tree</li>
            <li>Logical tab order matches visual layout</li>
            <li>Required fields announced to screen readers</li>
            <li>Error messages associated with fields</li>
            </ul>
            <p><a href="/guides/pdf-form-field-validation">Field validation</a> · <a href="/guides/pdf-ua-accessibility">PDF/UA</a>.</p>
            """),
    "fix-pdf-reading-order": _d("fix-pdf-reading-order", """
            <h2>Reading order fixes</h2>
            <ol>
            <li>Tag PDF — identify multi-column and sidebar blocks</li>
            <li>Reorder structure tree — title before body</li>
            <li>Mark decorative images as artifacts</li>
            <li>NVDA or VoiceOver read-through test</li>
            </ol>
            <p><a href="/guides/fix-pdf-missing-alt-text">Missing alt text</a> · <a href="/guides/screen-reader-pdf">Screen reader QA</a>.</p>
            """),
    "pdf-embed-fonts-for-print": _d("pdf-embed-fonts-for-print", """
            <h2>Font embed for print</h2>
            <ul>
            <li>Subset embed — smaller file, common for body text</li>
            <li>Full embed — required for rare glyphs</li>
            <li>Outline fonts — last resort, no text select</li>
            <li>Preflight: 100% fonts embedded before send</li>
            </ul>
            <p><a href="/guides/pdf-x-print-standard">PDF/X standard</a> · <a href="/guides/commercial-print-pdf-checklist">Print checklist</a>.</p>
            """),
    "pdf-litigation-hold-archive": _d("pdf-litigation-hold-archive", """
            <h2>Litigation hold on PDF archive</h2>
            <ol>
            <li>Counsel issues hold notice — scope by matter ID and date range</li>
            <li>Suspend automated destruction on matching PDFs</li>
            <li>Custodian log — who exported, when, why</li>
            <li>Immutable copy in WORM or legal hold vault</li>
            </ol>
            <p><a href="/guides/pdf-retention-policy">Retention policy</a> · <a href="/guides/document-retention-pdf">Document retention</a>.</p>
            """),
}

for device in W47_DEVICE_META:
    W47_DEEP[f"merge-pdf-on-{device}"] = _device_deep(f"merge-pdf-on-{device}")

for persona in W47_PERSONA_META:
    W47_DEEP[f"best-browser-pdf-tools-for-{persona}"] = _persona_deep(
        f"best-browser-pdf-tools-for-{persona}"
    )

W47_CREATE_CLUSTER = """
            <h2>CREATE batch 11</h2>
            <ul>
            <li>Device merge: <a href="/guides/merge-pdf-on-iphone">iPhone</a> · <a href="/guides/merge-pdf-on-ipad">iPad</a> · <a href="/guides/merge-pdf-on-chromebook">Chromebook</a> · <a href="/guides/merge-pdf-on-linux">Linux</a> · <a href="/guides/merge-pdf-on-windows-11">Windows 11</a></li>
            <li>Errors &amp; print: <a href="/guides/pdf-error-font-embedding">Font embedding</a> · <a href="/guides/pdf-embed-fonts-for-print">Embed fonts</a></li>
            <li>Convert &amp; a11y: <a href="/guides/pdf-to-google-docs">Google Docs</a> · <a href="/guides/pdf-form-accessibility-tags">Form tags</a> · <a href="/guides/fix-pdf-reading-order">Reading order</a></li>
            <li>Archive: <a href="/guides/pdf-litigation-hold-archive">Litigation hold</a></li>
            <li>Persona: <a href="/guides/best-browser-pdf-tools-for-accountants">Accountants</a> · <a href="/guides/best-browser-pdf-tools-for-archivists">Archivists</a> · <a href="/guides/best-browser-pdf-tools-for-bookkeepers">Bookkeepers</a> · <a href="/guides/best-browser-pdf-tools-for-construction-managers">Construction</a> · <a href="/guides/best-browser-pdf-tools-for-consultants">Consultants</a> · <a href="/guides/best-browser-pdf-tools-for-designers">Designers</a></li>
            </ul>
            <p>Prior batch: <a href="/guides/pdf-retention-policy">Wave 46 retention &amp; archive</a></p>
            """

W47_DEVICE_CLUSTER = """
            <h2>Wave 47 device merge hubs</h2>
            <p>Mobile: <a href="/guides/merge-pdf-on-iphone">iPhone</a> · <a href="/guides/merge-pdf-on-ipad">iPad</a> · <a href="/guides/merge-pdf-on-android">Android</a></p>
            <p>Desktop: <a href="/guides/merge-pdf-on-mac">Mac</a> · <a href="/guides/merge-pdf-on-windows-11">Windows 11</a> · <a href="/guides/merge-pdf-on-linux">Linux</a> · <a href="/guides/merge-pdf-on-chromebook">Chromebook</a></p>
            <p>Hub: <a href="/guides/pdf-device-workflows-hub">device workflows index</a></p>
            """

W47_PERSONA_CLUSTER = """
            <h2>Wave 47 persona tool guides</h2>
            <p>Finance: <a href="/guides/best-browser-pdf-tools-for-accountants">Accountants</a> · <a href="/guides/best-browser-pdf-tools-for-bookkeepers">Bookkeepers</a></p>
            <p>Records: <a href="/guides/best-browser-pdf-tools-for-archivists">Archivists</a></p>
            <p>Professional: <a href="/guides/best-browser-pdf-tools-for-consultants">Consultants</a> · <a href="/guides/best-browser-pdf-tools-for-construction-managers">Construction managers</a> · <a href="/guides/best-browser-pdf-tools-for-designers">Designers</a></p>
            <p>More personas in CREATE queue — <a href="/guides/choose-pdf-tool">buyer guide</a></p>
            """

W47_COMPRESS_TOPUP = """
            <h2>CREATE batch 11 checklist</h2>
            <ol>
            <li>Device merge: numeric filename prefixes before upload</li>
            <li>Font errors: flatten or outline before print handoff</li>
            <li>Google Docs: OCR scans before PDF to Word</li>
            <li>Litigation hold: pause destruction — log custodian exports</li>
            </ol>
            """

W47_CLOSING = """
            <h2>Related guides</h2>
            <p>Wave 47 expands device merge coverage, font and print troubleshooting, Google Docs conversion, form accessibility, litigation hold archiving, and first persona browser-tool guides — CREATE batch 11 of 450.</p>
            <p>Hub: <a href="/guides/pdf-device-workflows-hub">device workflows</a> · CREATE remaining: 263</p>
            """
