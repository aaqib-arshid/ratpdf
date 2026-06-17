"""Wave 50 — CREATE batch 14 (17 guides, score 72–74). Device split, retention, merge-for verticals."""

W50_SLUGS = [
    "pdf-retention-schedule-by-type",
    "pdf-error-xfa-form",
    "split-pdf-on-ipad",
    "split-pdf-on-android",
    "split-pdf-on-chromebook",
    "split-pdf-on-linux",
    "split-pdf-on-windows-11",
    "beginner-scanned-vs-digital-pdf",
    "pdf-approval-workflow-no-adobe",
    "fix-pdf-low-contrast-text",
    "pdf-prints-grayscale-only",
    "pdf-records-management-policy",
    "pdf-to-csv",
    "merge-pdf-for-lawyers",
    "merge-pdf-for-accountants",
    "merge-pdf-for-healthcare",
    "merge-pdf-for-real-estate",
]

DEVICE_CREATE_SLUGS = {
    "split-pdf-on-ipad",
    "split-pdf-on-android",
    "split-pdf-on-chromebook",
    "split-pdf-on-linux",
    "split-pdf-on-windows-11",
}

ARCHIVAL_CREATE_SLUGS = {
    "pdf-retention-schedule-by-type",
    "pdf-records-management-policy",
}

TROUBLESHOOT_CREATE_SLUGS = {"pdf-error-xfa-form"}

WORKFLOW_CREATE_SLUGS = {"pdf-approval-workflow-no-adobe"}

INFO_CREATE_SLUGS = {"beginner-scanned-vs-digital-pdf"}

ACCESSIBILITY_CREATE_SLUGS = {"fix-pdf-low-contrast-text"}

PRINT_CREATE_SLUGS = {"pdf-prints-grayscale-only"}

CONVERT_CREATE_SLUGS = {"pdf-to-csv"}

MERGE_FOR_CREATE_SLUGS = {
    "merge-pdf-for-lawyers",
    "merge-pdf-for-accountants",
    "merge-pdf-for-healthcare",
    "merge-pdf-for-real-estate",
}

W50_DEVICE_META = {
    "ipad": ("iPad", "Safari", "Attorney extracts one exhibit page from deposition PDF on iPad before client email"),
    "android": ("Android", "Chrome", "Field tech splits warranty PDF page from manual on Android phone before WhatsApp send"),
    "chromebook": ("Chromebook", "Chrome", "Student extracts one chapter PDF from textbook scan on school Chromebook"),
    "linux": ("Linux", "Firefox", "Engineer splits drawing sheet from 200-page spec PDF on Ubuntu browser"),
    "windows-11": ("Windows 11", "Edge", "Paralegal extracts Bates range from production PDF in Edge without Acrobat"),
}

W50_MERGE_FOR_META = {
    "lawyers": (
        "Lawyers",
        "Exhibits",
        "Litigation team merges exhibit PDFs in filing order — watermark DRAFT until court-ready export",
    ),
    "accountants": (
        "Accountants",
        "Audit packs",
        "Audit team merges bank statement and support PDFs by account before partner review",
    ),
    "healthcare": (
        "Healthcare",
        "Clinical packs",
        "Admin merges policy and consent PDFs for committee packet — HIPAA upload policy check first",
    ),
    "real-estate": (
        "Real Estate",
        "Disclosure packs",
        "Agent merges disclosure PDFs in MLS order before buyer signature packet",
    ),
}

W50_DATA = {
    "pdf-retention-schedule-by-type": {
        "title": "PDF Retention Schedule by Document Type — Matrix (2026)",
        "tool": "/pdf/pdfmetadata",
        "label": "PDF Metadata",
        "pillar": "/guides/pdf-retention-policy",
        "pillar_label": "PDF retention policy",
        "related": "/guides/pdf-document-retention-periods",
        "prog": "/pdf/pdfmetadata",
        "example": "Compliance publishes matrix — tax invoice 7 years — contract 10 years — HR 5 years — legal hold overrides",
    },
    "pdf-error-xfa-form": {
        "title": "XFA PDF Form Not Supported — Fix &amp; Migrate (2026)",
        "tool": "/pdf/editpdf",
        "label": "Edit PDF",
        "pillar": "/guides/xfa-to-acroform-convert",
        "pillar_label": "XFA to AcroForm convert",
        "related": "/guides/glossary-xfa-forms",
        "prog": "/pdf/editpdf",
        "example": "Browser viewer shows XFA not supported — rebuild form as AcroForm — test in Reader before republish",
    },
    "beginner-scanned-vs-digital-pdf": {
        "title": "Scanned vs Digital PDF — How to Tell &amp; What to Do (2026)",
        "tool": "/pdf/ocrpdf",
        "label": "OCR PDF",
        "pillar": "/guides/what-is-a-pdf-file",
        "pillar_label": "what is a PDF",
        "related": "/guides/scanned-pdf-to-word",
        "prog": "/pdf/ocrpdf",
        "example": "User tries select-all on invoice PDF — no text — scan needs OCR before PDF to Word or search",
    },
    "pdf-approval-workflow-no-adobe": {
        "title": "PDF Approval Workflow Without Adobe — Browser Sign-Off (2026)",
        "tool": "/pdf/watermark",
        "label": "Watermark PDF",
        "pillar": "/guides/pdf-review-workflow",
        "pillar_label": "PDF review workflow",
        "related": "/guides/browser-vs-desktop-pdf-tools",
        "prog": "/pdf/watermark",
        "example": "SMB approves vendor SOW — watermark DRAFT — merge exhibits — flatten — e-sign in DocuSign without Acrobat license",
    },
    "fix-pdf-low-contrast-text": {
        "title": "Fix PDF Low Contrast Text — WCAG Color Fixes (2026)",
        "tool": "/pdf/ocrpdf",
        "label": "OCR PDF",
        "pillar": "/guides/pdf-ua-accessibility",
        "pillar_label": "PDF/UA accessibility",
        "related": "/guides/fix-pdf-untagged-content",
        "prog": "/pdf/ocrpdf",
        "example": "Public notice PDF fails WCAG — light gray body text on white — darken to 4.5:1 contrast — retag and republish",
    },
    "pdf-prints-grayscale-only": {
        "title": "PDF Prints Grayscale Only — Color Driver Fixes (2026)",
        "tool": "/pdf/flattenpdf",
        "label": "Flatten PDF",
        "pillar": "/guides/pdf-printing-guide",
        "pillar_label": "PDF printing guide",
        "related": "/guides/print-pdf-black-and-white",
        "prog": "/pdf/flattenpdf",
        "example": "Brochure PDF prints black and white on color MFP — disable grayscale in driver — check print in grayscale off",
    },
    "pdf-records-management-policy": {
        "title": "PDF Records Management Policy — Template &amp; Controls (2026)",
        "tool": "/pdf/pdfmetadata",
        "label": "PDF Metadata",
        "pillar": "/guides/document-retention-pdf",
        "pillar_label": "document retention PDF",
        "related": "/guides/pdf-standards-archiving-hub",
        "prog": "/pdf/pdfmetadata",
        "example": "Records officer drafts RM policy — classification schema — retention class in metadata — destruction approval workflow",
    },
    "pdf-to-csv": {
        "title": "PDF to CSV — Extract Table Data Workflow (2026)",
        "tool": "/pdf/pdftotext",
        "label": "PDF to Text",
        "pillar": "/guides/pdf-to-text-online",
        "pillar_label": "PDF to text online",
        "related": "/guides/pdf-to-word",
        "prog": "/pdf/pdftotext",
        "example": "Analyst exports invoice table PDF — text extract — paste to spreadsheet — or PDF to Excel for complex tables",
    },
}

for device, (name, browser, example) in W50_DEVICE_META.items():
    slug = f"split-pdf-on-{device}"
    W50_DATA[slug] = {
        "title": f"Split PDF on {name} — {browser} Extract Workflow (2026)",
        "tool": "/pdf/split",
        "label": "Split PDF",
        "pillar": "/guides/split-pdf-on-mac",
        "pillar_label": "split PDF on Mac (reference)",
        "related": "/guides/pdf-device-workflows-hub",
        "prog": "/pdf/split",
        "example": example,
        "device": name,
        "browser": browser,
    }

for vertical, (audience, pack_type, example) in W50_MERGE_FOR_META.items():
    slug = f"merge-pdf-for-{vertical}"
    related_map = {
        "lawyers": "/guides/best-browser-pdf-tools-for-lawyers",
        "accountants": "/guides/best-browser-pdf-tools-for-accountants",
        "healthcare": "/guides/best-browser-pdf-tools-for-healthcare-administrators",
        "real-estate": "/guides/best-browser-pdf-tools-for-real-estate-agents",
    }
    W50_DATA[slug] = {
        "title": f"Merge PDF for {audience} — {pack_type} Workflow (2026)",
        "tool": "/pdf/merge",
        "label": "Merge PDF",
        "pillar": "/guides/merge-pdf",
        "pillar_label": "merge PDF guide",
        "related": related_map[vertical],
        "prog": "/pdf/merge",
        "example": example,
        "audience": audience,
        "pack_type": pack_type,
    }


def _d(slug: str, html: str) -> str:
    p = W50_DATA[slug].get("prog", "")
    tail = f'<p>Tool: <a href="{p}">{p}</a></p>' if p else ""
    return html + tail


def _device_deep(slug: str) -> str:
    d = W50_DATA[slug]
    return _d(
        slug,
        f"""
            <h2>Split PDF on {d['device']}</h2>
            <p>Browser: {d['browser']} — extract page range without desktop install.</p>
            <ol>
            <li>Open {d['browser']} → <a href="/pdf/split">Split PDF</a></li>
            <li>Upload PDF from Files/Downloads</li>
            <li>Enter page range or extract single page</li>
            <li>Download split PDF — <a href="/pdf/compress">compress</a> if email cap</li>
            </ol>
            <p>Hub: <a href="/guides/pdf-device-workflows-hub">device workflows</a> · <a href="/guides/split-pdf">split guide</a>.</p>
            """,
    )


def _merge_for_deep(slug: str) -> str:
    d = W50_DATA[slug]
    return _d(
        slug,
        f"""
            <h2>Merge PDF for {d['audience']}</h2>
            <p>Typical pack: {d['pack_type']} — {d['example']}.</p>
            <ol>
            <li>Numeric filename prefixes before upload</li>
            <li><a href="/pdf/merge">Merge</a> in delivery order</li>
            <li><a href="/pdf/watermark">Watermark</a> DRAFT if pre-approval</li>
            <li><a href="/pdf/compress">Compress</a> if portal or email cap</li>
            </ol>
            <p><a href="/guides/merge-pdf">Merge hub</a> · vertical browser tools guide.</p>
            """,
    )


W50_DEEP = {
    "pdf-retention-schedule-by-type": _d("pdf-retention-schedule-by-type", """
            <h2>Retention by document type</h2>
            <table class="table table-sm">
            <tr><th>Type</th><th>Typical period</th></tr>
            <tr><td>Tax invoice PDF</td><td>6–7 years (jurisdiction-specific)</td></tr>
            <tr><td>Contract PDF</td><td>Life of agreement + statute</td></tr>
            <tr><td>HR personnel PDF</td><td>Employment + local labor law</td></tr>
            <tr><td>Clinical record PDF</td><td>Healthcare retention rules</td></tr>
            </table>
            <p>Legal hold pauses all types — <a href="/guides/pdf-litigation-hold-archive">litigation hold</a>.</p>
            """),
    "pdf-error-xfa-form": _d("pdf-error-xfa-form", """
            <h2>XFA not supported — fixes</h2>
            <ul>
            <li>Legacy XFA forms fail in many browser viewers</li>
            <li>Migrate to AcroForm — <a href="/guides/xfa-to-acroform-convert">conversion guide</a></li>
            <li>Open in Adobe Reader only as interim workaround</li>
            <li>Rebuild tab order and validation on migrate</li>
            </ul>
            <p><a href="/guides/glossary-xfa-forms">XFA glossary</a>.</p>
            """),
    "beginner-scanned-vs-digital-pdf": _d("beginner-scanned-vs-digital-pdf", """
            <h2>Scanned vs digital PDF</h2>
            <ul>
            <li><strong>Digital</strong> — text selects, small file, born from Word/export</li>
            <li><strong>Scanned</strong> — image pages, needs OCR for search/edit</li>
            <li>Test: try select-all copy — empty means scan</li>
            <li>Scanned path: <a href="/pdf/ocrpdf">OCR</a> before Word or text extract</li>
            </ul>
            """),
    "pdf-approval-workflow-no-adobe": _d("pdf-approval-workflow-no-adobe", """
            <h2>Approval without Acrobat</h2>
            <ol>
            <li>Browser <a href="/pdf/watermark">watermark</a> DRAFT on circulation</li>
            <li>Comment in DOCX source or export comment summary</li>
            <li>Merge approved annex — <a href="/pdf/flattenpdf">flatten</a> final</li>
            <li>E-sign in DocuSign/HelloSign — no Acrobat license</li>
            </ol>
            <p><a href="/guides/pdf-review-workflow">Review workflow</a> · <a href="/guides/browser-vs-desktop-pdf-tools">Browser vs desktop</a>.</p>
            """),
    "fix-pdf-low-contrast-text": _d("fix-pdf-low-contrast-text", """
            <h2>Low contrast remediation</h2>
            <ul>
            <li>WCAG AA — 4.5:1 body text, 3:1 large text</li>
            <li>Fix in source — re-export PDF preferred</li>
            <li>Light gray marketing text common failure</li>
            <li>Contrast checker after fix — PAC or axe</li>
            </ul>
            <p><a href="/guides/pdf-ua-accessibility">PDF/UA</a> · <a href="/guides/tagged-pdf-checklist">Tagged PDF</a>.</p>
            """),
    "pdf-prints-grayscale-only": _d("pdf-prints-grayscale-only", """
            <h2>Grayscale-only print fixes</h2>
            <ul>
            <li>Driver — disable Print in Grayscale</li>
            <li>Check PDF has CMYK or RGB not device-n only</li>
            <li>Office MFP eco mode forces mono</li>
            <li>Print color test page from OS first</li>
            </ul>
            <p><a href="/guides/pdf-colors-wrong-when-printing">Colors wrong printing</a>.</p>
            """),
    "pdf-records-management-policy": _d("pdf-records-management-policy", """
            <h2>Records management policy</h2>
            <ol>
            <li>Classification — public, internal, confidential, restricted</li>
            <li>Metadata schema — owner, retention class, destroy date</li>
            <li>Ingest controls — PDF/A for archive tier</li>
            <li>Annual policy review — counsel sign-off</li>
            </ol>
            <p><a href="/guides/pdf-retention-schedule-by-type">Retention schedule</a> · <a href="/guides/pdf-standards-archiving-hub">Standards hub</a>.</p>
            """),
    "pdf-to-csv": _d("pdf-to-csv", """
            <h2>PDF to CSV workflow</h2>
            <ol>
            <li>Simple tables — <a href="/pdf/pdftotext">PDF to text</a> then paste to sheet</li>
            <li>Complex tables — <a href="/guides/pdf-to-word">PDF to Word</a> or Excel path</li>
            <li>Scanned tables — <a href="/pdf/ocrpdf">OCR</a> first</li>
            <li>Verify numbers after extract — OCR drift on decimals</li>
            </ol>
            """),
}

for device in W50_DEVICE_META:
    W50_DEEP[f"split-pdf-on-{device}"] = _device_deep(f"split-pdf-on-{device}")

for vertical in W50_MERGE_FOR_META:
    W50_DEEP[f"merge-pdf-for-{vertical}"] = _merge_for_deep(f"merge-pdf-for-{vertical}")

W50_CREATE_CLUSTER = """
            <h2>CREATE batch 14</h2>
            <ul>
            <li>Device split: <a href="/guides/split-pdf-on-ipad">iPad</a> · <a href="/guides/split-pdf-on-android">Android</a> · <a href="/guides/split-pdf-on-chromebook">Chromebook</a> · <a href="/guides/split-pdf-on-linux">Linux</a> · <a href="/guides/split-pdf-on-windows-11">Windows 11</a></li>
            <li>Retention: <a href="/guides/pdf-retention-schedule-by-type">Schedule by type</a> · <a href="/guides/pdf-records-management-policy">RM policy</a></li>
            <li>Merge verticals: <a href="/guides/merge-pdf-for-lawyers">Lawyers</a> · <a href="/guides/merge-pdf-for-accountants">Accountants</a> · <a href="/guides/merge-pdf-for-healthcare">Healthcare</a> · <a href="/guides/merge-pdf-for-real-estate">Real estate</a></li>
            <li>Other: <a href="/guides/pdf-error-xfa-form">XFA error</a> · <a href="/guides/beginner-scanned-vs-digital-pdf">Scanned vs digital</a> · <a href="/guides/pdf-approval-workflow-no-adobe">Approval no Adobe</a> · <a href="/guides/fix-pdf-low-contrast-text">Low contrast</a> · <a href="/guides/pdf-prints-grayscale-only">Grayscale print</a> · <a href="/guides/pdf-to-csv">PDF to CSV</a></li>
            </ul>
            <p>Prior batch: <a href="/guides/best-browser-pdf-tools-for-teachers">Wave 49 persona finale</a></p>
            """

W50_DEVICE_CLUSTER = """
            <h2>Wave 50 device split hubs</h2>
            <p>Mobile: <a href="/guides/split-pdf-on-ipad">iPad</a> · <a href="/guides/split-pdf-on-android">Android</a> · <a href="/guides/split-pdf-on-iphone">iPhone</a></p>
            <p>Desktop: <a href="/guides/split-pdf-on-mac">Mac</a> · <a href="/guides/split-pdf-on-windows-11">Windows 11</a> · <a href="/guides/split-pdf-on-linux">Linux</a> · <a href="/guides/split-pdf-on-chromebook">Chromebook</a></p>
            <p>Merge device guides: <a href="/guides/merge-pdf-on-iphone">Merge iPhone</a> · <a href="/guides/pdf-device-workflows-hub">Device hub</a></p>
            """

W50_MERGE_FOR_CLUSTER = """
            <h2>Merge-for vertical workflows</h2>
            <p><a href="/guides/merge-pdf-for-lawyers">Lawyers</a> · <a href="/guides/merge-pdf-for-accountants">Accountants</a> · <a href="/guides/merge-pdf-for-healthcare">Healthcare</a> · <a href="/guides/merge-pdf-for-real-estate">Real estate</a></p>
            <p>More verticals in CREATE queue — insurance, education, government, nonprofits</p>
            """

W50_COMPRESS_TOPUP = """
            <h2>CREATE batch 14 checklist</h2>
            <ol>
            <li>Split: stable Files/Downloads path before upload</li>
            <li>Retention matrix: legal hold overrides destruction date</li>
            <li>XFA forms: migrate to AcroForm for browser support</li>
            <li>Scanned PDF: OCR before text extract or Word convert</li>
            </ol>
            """

W50_CLOSING = """
            <h2>Related guides</h2>
            <p>Wave 50 adds device split guides, retention and records policy spokes, merge-for vertical workflows, and troubleshooting for XFA, contrast, and grayscale print — CREATE batch 14 of 450.</p>
            <p>Hub: <a href="/guides/pdf-device-workflows-hub">device workflows</a> · CREATE remaining: 212</p>
            """
