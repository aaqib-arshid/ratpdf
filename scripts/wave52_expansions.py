"""Wave 52 — CREATE batch 16 (17 guides, score 71–72). Device convert finale, archive, compress-for part 1."""

W52_SLUGS = [
    "convert-pdf-on-mac",
    "convert-pdf-on-windows-11",
    "beginner-pdf-vs-png-for-documents",
    "pdf-to-pages",
    "pdf-email-thread-archive",
    "fix-pdf-table-headers",
    "pdf-email-archive-migration",
    "pdf-worm-storage-compliance",
    "compress-pdf-for-lawyers",
    "compress-pdf-for-accountants",
    "compress-pdf-for-healthcare",
    "compress-pdf-for-real-estate",
    "compress-pdf-for-insurance",
    "compress-pdf-for-education",
    "compress-pdf-for-nonprofits",
    "compress-pdf-for-government",
    "compress-pdf-for-freelancers",
]

DEVICE_CREATE_SLUGS = {"convert-pdf-on-mac", "convert-pdf-on-windows-11"}

INFO_CREATE_SLUGS = {"beginner-pdf-vs-png-for-documents"}

CONVERT_CREATE_SLUGS = {"pdf-to-pages"}

WORKFLOW_CREATE_SLUGS = {"pdf-email-thread-archive"}

ACCESSIBILITY_CREATE_SLUGS = {"fix-pdf-table-headers"}

ARCHIVAL_CREATE_SLUGS = {"pdf-email-archive-migration", "pdf-worm-storage-compliance"}

COMPRESS_FOR_CREATE_SLUGS = {
    "compress-pdf-for-lawyers",
    "compress-pdf-for-accountants",
    "compress-pdf-for-healthcare",
    "compress-pdf-for-real-estate",
    "compress-pdf-for-insurance",
    "compress-pdf-for-education",
    "compress-pdf-for-nonprofits",
    "compress-pdf-for-government",
    "compress-pdf-for-freelancers",
}

W52_DEVICE_META = {
    "mac": (
        "Mac",
        "Safari",
        "Consultant converts client SOW PDF to Word in Safari before redline edit in Pages",
    ),
    "windows-11": (
        "Windows 11",
        "Edge",
        "Analyst converts quarterly report PDF to DOCX in Edge without Acrobat install",
    ),
}

W52_COMPRESS_FOR_META = {
    "lawyers": (
        "Lawyers",
        "Discovery",
        "Paralegal compresses 80 MB production PDF to 15 MB before secure file share to co-counsel",
        "merge-pdf-for-lawyers",
    ),
    "accountants": (
        "Accountants",
        "Audit evidence",
        "Staff compresses scanned receipt bundle from 12 MB to 4 MB before partner review email",
        "merge-pdf-for-accountants",
    ),
    "healthcare": (
        "Healthcare",
        "Portal upload",
        "Admin compresses policy PDF to meet patient portal 5 MB attachment cap per BAA",
        "merge-pdf-for-healthcare",
    ),
    "real-estate": (
        "Real Estate",
        "MLS email",
        "Agent compresses disclosure pack from 18 MB to 8 MB for MLS mailbox limit",
        "merge-pdf-for-real-estate",
    ),
    "insurance": (
        "Insurance",
        "Claims scan",
        "Adjuster compresses photo-heavy claims PDF before carrier portal upload",
        "merge-pdf-for-insurance",
    ),
    "education": (
        "Education",
        "LMS upload",
        "Instructor compresses reading PDF from 25 MB to 10 MB for Canvas course module",
        "merge-pdf-for-education",
    ),
    "nonprofits": (
        "Nonprofits",
        "Grant portal",
        "Grant writer compresses combined exhibit PDF before foundation submission cap",
        "merge-pdf-for-nonprofits",
    ),
    "government": (
        "Government",
        "SAM portal",
        "Contractor compresses technical volume PDF to meet agency upload size limit",
        "merge-pdf-for-government",
    ),
    "freelancers": (
        "Freelancers",
        "Client email",
        "Designer compresses portfolio PDF from 22 MB to 9 MB before client Gmail attach",
        "merge-pdf-for-freelancers",
    ),
}

W52_DATA = {
    "beginner-pdf-vs-png-for-documents": {
        "title": "PDF vs PNG for Documents — When to Use Each (2026)",
        "tool": "/guides/pdf-tools",
        "label": "PDF tools hub",
        "pillar": "/guides/beginner-what-is-a-pdf",
        "pillar_label": "beginner PDF intro",
        "related": "/guides/beginner-pdf-vs-png",
        "prog": "/guides/pdf-tools",
        "example": "Marketing debates screenshot PNG vs export PDF for one-pager — PDF preserves text select and print layout",
    },
    "pdf-to-pages": {
        "title": "PDF to Pages on Mac — Import &amp; Edit Workflow (2026)",
        "tool": "/pdf/pdftodoc",
        "label": "PDF to Word",
        "pillar": "/guides/pdf-to-word-on-mac",
        "pillar_label": "PDF to Word on Mac",
        "related": "/guides/convert-pdf-on-mac",
        "prog": "/pdf/pdftodoc",
        "example": "Mac user converts brochure PDF to DOCX — opens in Pages — fixes typo — re-exports PDF for print",
    },
    "pdf-email-thread-archive": {
        "title": "Archive Email Thread as PDF — Outlook &amp; Gmail Workflow (2026)",
        "tool": "/pdf/merge",
        "label": "Merge PDF",
        "pillar": "/guides/pdf-email-attachment-checklist",
        "pillar_label": "email attachment checklist",
        "related": "/guides/pdf-workflow-checklist",
        "prog": "/pdf/merge",
        "example": "Legal saves negotiation email thread as PDF — merge with signed contract — archive in matter folder",
    },
    "fix-pdf-table-headers": {
        "title": "Fix PDF Table Headers — Accessibility TH Tags (2026)",
        "tool": "/pdf/ocrpdf",
        "label": "OCR PDF",
        "pillar": "/guides/tagged-pdf-checklist",
        "pillar_label": "tagged PDF checklist",
        "related": "/guides/fix-pdf-untagged-content",
        "prog": "/pdf/ocrpdf",
        "example": "Policy PDF table fails screen reader — mark header row TH — scope col — NVDA reads column labels",
    },
    "pdf-email-archive-migration": {
        "title": "Migrate Email Archive to PDF/A — PST Workflow (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/pdf-migration-documents-to-pdfa",
        "pillar_label": "migrate to PDF/A",
        "related": "/guides/pdf-email-thread-archive",
        "prog": "/pdf/compress",
        "example": "IT exports 10-year PST to PDF batches — PDF/A-2b access copies — ingest to records system",
    },
    "pdf-worm-storage-compliance": {
        "title": "PDF WORM Storage Compliance — Immutable Archive (2026)",
        "tool": "/pdf/pdfmetadata",
        "label": "PDF Metadata",
        "pillar": "/guides/pdf-long-term-archive-strategy",
        "pillar_label": "long-term archive strategy",
        "related": "/guides/pdf-standards-archiving-hub",
        "prog": "/pdf/pdfmetadata",
        "example": "Finance stores signed contract PDF in WORM tier — hash audit — retention class FIN-10Y in metadata",
    },
}

for device, (name, browser, example) in W52_DEVICE_META.items():
    slug = f"convert-pdf-on-{device}"
    W52_DATA[slug] = {
        "title": f"Convert PDF on {name} — {browser} Workflow (2026)",
        "tool": "/pdf/pdftodoc",
        "label": "PDF to Word",
        "pillar": "/guides/pdf-to-word-on-mac" if device == "mac" else "/guides/pdf-to-word",
        "pillar_label": "PDF to Word on Mac" if device == "mac" else "PDF to Word",
        "related": "/guides/convert-pdf-on-iphone",
        "prog": "/pdf/pdftodoc",
        "example": example,
        "device": name,
        "browser": browser,
    }

for vertical, (audience, use_case, example, merge_slug) in W52_COMPRESS_FOR_META.items():
    slug = f"compress-pdf-for-{vertical}"
    W52_DATA[slug] = {
        "title": f"Compress PDF for {audience} — {use_case} Workflow (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/compress-pdf-guide",
        "pillar_label": "compress PDF guide",
        "related": f"/guides/{merge_slug}",
        "prog": "/pdf/compress",
        "example": example,
        "audience": audience,
        "use_case": use_case,
    }


def _d(slug: str, html: str) -> str:
    p = W52_DATA[slug].get("prog", "")
    tail = f'<p>Tool: <a href="{p}">{p}</a></p>' if p else ""
    return html + tail


def _device_deep(slug: str) -> str:
    d = W52_DATA[slug]
    return _d(
        slug,
        f"""
            <h2>Convert PDF on {d['device']}</h2>
            <p>Browser: {d['browser']} — completes device convert cluster (6/6).</p>
            <ol>
            <li>Scanned PDF? — <a href="/pdf/ocrpdf">OCR</a> first</li>
            <li>{d['browser']} → <a href="/pdf/pdftodoc">PDF to Word</a></li>
            <li>Download DOCX — edit locally</li>
            <li>Re-export PDF via <a href="/pdf/doctopdf">Word to PDF</a> if needed</li>
            </ol>
            <p>Cluster: <a href="/guides/convert-pdf-on-iphone">iPhone</a> · <a href="/guides/convert-pdf-on-ipad">iPad</a> · <a href="/guides/convert-pdf-on-linux">Linux</a> · <a href="/guides/pdf-device-workflows-hub">Device hub</a>.</p>
            """,
    )


def _compress_for_deep(slug: str) -> str:
    d = W52_DATA[slug]
    return _d(
        slug,
        f"""
            <h2>Compress PDF for {d['audience']}</h2>
            <p>Use case: {d['use_case']} — {d['example']}.</p>
            <ol>
            <li>Check portal or email size cap first</li>
            <li><a href="/pdf/compress">Compress</a> — start Medium preset</li>
            <li>Verify text still selects if downstream OCR needed</li>
            <li>Keep uncompressed master in matter folder</li>
            </ol>
            <p>Pair with <a href="{d['related']}">merge workflow</a> · <a href="/guides/compress-pdf-guide">Compress hub</a>.</p>
            """,
    )


W52_DEEP = {
    "beginner-pdf-vs-png-for-documents": _d("beginner-pdf-vs-png-for-documents", """
            <h2>PDF vs PNG for documents</h2>
            <table class="table table-sm">
            <tr><th>Format</th><th>Best for</th></tr>
            <tr><td>PDF</td><td>Multi-page docs, print, forms, text select</td></tr>
            <tr><td>PNG</td><td>Single-page screenshots, transparency, web embed</td></tr>
            </table>
            <p>Use PDF when recipients need print layout — PNG for quick image share only.</p>
            """),
    "pdf-to-pages": _d("pdf-to-pages", """
            <h2>PDF to Pages on Mac</h2>
            <ol>
            <li><a href="/pdf/pdftodoc">PDF to Word</a> — export DOCX</li>
            <li>Open DOCX in Pages — fix layout drift on tables</li>
            <li>Export PDF from Pages for final deliverable</li>
            <li>Scanned PDF — <a href="/pdf/ocrpdf">OCR</a> before convert</li>
            </ol>
            <p><a href="/guides/convert-pdf-on-mac">Convert on Mac</a> · Preview limits on tables.</p>
            """),
    "pdf-email-thread-archive": _d("pdf-email-thread-archive", """
            <h2>Email thread to PDF</h2>
            <ol>
            <li>Gmail/Outlook — print or export conversation to PDF</li>
            <li>Include date headers visible on each message</li>
            <li><a href="/pdf/merge">Merge</a> with related contract PDFs</li>
            <li>Store in matter folder with version naming</li>
            </ol>
            <p><a href="/guides/pdf-email-attachment-checklist">Email checklist</a>.</p>
            """),
    "fix-pdf-table-headers": _d("fix-pdf-table-headers", """
            <h2>Table header tags</h2>
            <ul>
            <li>Mark header cells as TH not TD</li>
            <li>scope="col" or scope="row" as appropriate</li>
            <li>Repeat headers on multi-page tables if tool supports</li>
            <li>NVDA reads column title before cell value</li>
            </ul>
            <p><a href="/guides/fix-pdf-reading-order">Reading order</a> · <a href="/guides/pdf-ua-accessibility">PDF/UA</a>.</p>
            """),
    "pdf-email-archive-migration": _d("pdf-email-archive-migration", """
            <h2>Email archive migration</h2>
            <ol>
            <li>Export PST or MBOX in batches by year</li>
            <li>Convert threads to PDF — consistent naming</li>
            <li>Batch PDF/A-2b access copies</li>
            <li>Ingest to records system with retention class</li>
            </ol>
            <p><a href="/guides/pdf-migration-documents-to-pdfa">PDF/A migration</a>.</p>
            """),
    "pdf-worm-storage-compliance": _d("pdf-worm-storage-compliance", """
            <h2>WORM compliance</h2>
            <ul>
            <li>Write-once-read-many — no overwrite or delete</li>
            <li>Checksum hash on ingest — annual verify</li>
            <li>Retention metadata — destroy date when policy allows</li>
            <li>Legal hold overrides WORM delete schedule</li>
            </ul>
            <p><a href="/guides/pdf-records-management-policy">RM policy</a> · <a href="/guides/pdf-timestamp-authority-signing">TSA signing</a>.</p>
            """),
}

for device in W52_DEVICE_META:
    W52_DEEP[f"convert-pdf-on-{device}"] = _device_deep(f"convert-pdf-on-{device}")

for vertical in W52_COMPRESS_FOR_META:
    W52_DEEP[f"compress-pdf-for-{vertical}"] = _compress_for_deep(f"compress-pdf-for-{vertical}")

W52_CREATE_CLUSTER = """
            <h2>CREATE batch 16</h2>
            <ul>
            <li>Device convert finale: <a href="/guides/convert-pdf-on-mac">Mac</a> · <a href="/guides/convert-pdf-on-windows-11">Windows 11</a> — cluster 6/6 complete</li>
            <li>Archive: <a href="/guides/pdf-email-thread-archive">Email thread PDF</a> · <a href="/guides/pdf-email-archive-migration">Email to PDF/A</a> · <a href="/guides/pdf-worm-storage-compliance">WORM storage</a></li>
            <li>Compress verticals (9/17): <a href="/guides/compress-pdf-for-lawyers">Lawyers</a> · <a href="/guides/compress-pdf-for-accountants">Accountants</a> · <a href="/guides/compress-pdf-for-healthcare">Healthcare</a> · <a href="/guides/compress-pdf-for-freelancers">Freelancers</a> …</li>
            <li>Other: <a href="/guides/beginner-pdf-vs-png-for-documents">PDF vs PNG</a> · <a href="/guides/pdf-to-pages">PDF to Pages</a> · <a href="/guides/fix-pdf-table-headers">Table headers</a></li>
            </ul>
            <p>Prior: <a href="/guides/convert-pdf-on-linux">Wave 51 device convert</a></p>
            """

W52_DEVICE_CLUSTER = """
            <h2>Device convert cluster — complete (6)</h2>
            <p><a href="/guides/convert-pdf-on-iphone">iPhone</a> · <a href="/guides/convert-pdf-on-ipad">iPad</a> · <a href="/guides/convert-pdf-on-chromebook">Chromebook</a> · <a href="/guides/convert-pdf-on-linux">Linux</a> · <a href="/guides/convert-pdf-on-mac">Mac</a> · <a href="/guides/convert-pdf-on-windows-11">Windows 11</a></p>
            """

W52_COMPRESS_FOR_CLUSTER = """
            <h2>Compress-for verticals (batch 1 of 2)</h2>
            <p><a href="/guides/compress-pdf-for-lawyers">Lawyers</a> · <a href="/guides/compress-pdf-for-accountants">Accountants</a> · <a href="/guides/compress-pdf-for-healthcare">Healthcare</a> · <a href="/guides/compress-pdf-for-real-estate">Real estate</a> · <a href="/guides/compress-pdf-for-insurance">Insurance</a></p>
            <p><a href="/guides/compress-pdf-for-education">Education</a> · <a href="/guides/compress-pdf-for-nonprofits">Nonprofits</a> · <a href="/guides/compress-pdf-for-government">Government</a> · <a href="/guides/compress-pdf-for-freelancers">Freelancers</a></p>
            <p>Batch 2: consultants, architects, engineers — Wave 53</p>
            """

W52_COMPRESS_TOPUP = """
            <h2>CREATE batch 16 checklist</h2>
            <ol>
            <li>Device convert: OCR scans before PDF to Word</li>
            <li>Compress: keep master uncompressed in matter folder</li>
            <li>Email archive: include visible date headers per message</li>
            <li>WORM: checksum on ingest — legal hold overrides delete</li>
            </ol>
            """

W52_CLOSING = """
            <h2>Related guides</h2>
            <p>Wave 52 completes the six-device PDF convert cluster, adds email archive and WORM compliance guides, and launches nine compress-for industry verticals — CREATE batch 16 of 450.</p>
            <p>Hub: <a href="/guides/compress-pdf-guide">compress PDF</a> · CREATE remaining: 178</p>
            """
