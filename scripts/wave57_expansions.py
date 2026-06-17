"""Wave 57 — CREATE batch 21 (17 guides, score 69–70). Compressor persona finale + workflow + secure-workflow start."""

W57_SLUGS = [
    "best-pdf-compressor-for-healthcare",
    "best-pdf-compressor-for-real-estate-agents",
    "best-pdf-compressor-for-remote-teams",
    "best-pdf-compressor-for-nonprofits",
    "best-pdf-compressor-for-government",
    "best-pdf-compressor-for-researchers",
    "best-pdf-compressor-for-designers",
    "best-pdf-compressor-for-developers",
    "best-pdf-compressor-for-sales-teams",
    "best-pdf-compressor-for-hr-teams",
    "best-pdf-compressor-for-consultants",
    "pdf-to-rtf",
    "pdf-to-searchable-image",
    "pdf-client-delivery-checklist",
    "pdf-checksum-verify-integrity",
    "secure-pdf-workflow-lawyers",
    "secure-pdf-workflow-accountants",
]

COMPRESSOR_CREATE_SLUGS = {
    "best-pdf-compressor-for-healthcare",
    "best-pdf-compressor-for-real-estate-agents",
    "best-pdf-compressor-for-remote-teams",
    "best-pdf-compressor-for-nonprofits",
    "best-pdf-compressor-for-government",
    "best-pdf-compressor-for-researchers",
    "best-pdf-compressor-for-designers",
    "best-pdf-compressor-for-developers",
    "best-pdf-compressor-for-sales-teams",
    "best-pdf-compressor-for-hr-teams",
    "best-pdf-compressor-for-consultants",
}

CONVERT_CREATE_SLUGS = {"pdf-to-rtf", "pdf-to-searchable-image"}

WORKFLOW_CREATE_SLUGS = {"pdf-client-delivery-checklist", "pdf-checksum-verify-integrity"}

SECURE_CREATE_SLUGS = {"secure-pdf-workflow-lawyers", "secure-pdf-workflow-accountants"}

W57_COMPRESSOR_META = {
    "healthcare": (
        "Healthcare",
        "Admin compresses policy PDF to meet patient portal 5 MB cap per BAA",
        "best-browser-pdf-tools-for-healthcare-administrators",
        "compress-pdf-for-healthcare",
    ),
    "real-estate-agents": (
        "Real Estate Agents",
        "Agent compresses disclosure pack from 18 MB to 8 MB for MLS mailbox limit",
        "best-browser-pdf-tools-for-real-estate-agents",
        "compress-pdf-for-real-estate",
    ),
    "remote-teams": (
        "Remote Teams",
        "Distributed team compresses shared policy PDF before Slack and email distribution",
        "best-browser-pdf-tools-for-remote-teams",
        "compress-pdf-guide",
    ),
    "nonprofits": (
        "Nonprofits",
        "Grant writer compresses combined exhibit PDF before foundation submission cap",
        "best-browser-pdf-tools-for-nonprofits",
        "compress-pdf-for-nonprofits",
    ),
    "government": (
        "Government",
        "Contractor compresses technical volume PDF to meet SAM upload size limit",
        "best-browser-pdf-tools-for-government-contractors",
        "compress-pdf-for-government",
    ),
    "researchers": (
        "Researchers",
        "PI compresses supplementary PDF from 15 MB to 6 MB for journal submission system",
        "best-browser-pdf-tools-for-researchers",
        "compress-pdf-for-researchers",
    ),
    "designers": (
        "Designers",
        "Designer compresses portfolio proof PDF without rasterizing vector logos",
        "best-browser-pdf-tools-for-designers",
        "compress-pdf-guide",
    ),
    "developers": (
        "Developers",
        "Developer compresses generated API doc PDF before wiki attachment cap",
        "best-browser-pdf-tools-for-developers",
        "compress-pdf-guide",
    ),
    "sales-teams": (
        "Sales Teams",
        "AE compresses proposal deck PDF before enterprise prospect email send",
        "best-browser-pdf-tools-for-consultants",
        "compress-pdf-for-sales-teams",
    ),
    "hr-teams": (
        "HR Teams",
        "HR compresses onboarding pack PDF before new-hire portal upload",
        "best-browser-pdf-tools-for-hr-teams",
        "compress-pdf-for-hr-teams",
    ),
    "consultants": (
        "Consultants",
        "Consultant compresses 30 MB strategy deck PDF to 12 MB before client portal upload",
        "best-browser-pdf-tools-for-consultants",
        "compress-pdf-for-consultants",
    ),
}

W57_SECURE_META = {
    "lawyers": (
        "Lawyers",
        "Discovery handoff",
        "Paralegal redacts privileged content, watermarks DRAFT, then password-protects production PDF before co-counsel share",
        "best-pdf-editor-for-lawyers",
    ),
    "accountants": (
        "Accountants",
        "Client tax pack",
        "Accountant redacts client TIN, password-protects return PDF, and logs version before secure portal upload",
        "best-pdf-editor-for-accountants",
    ),
}

W57_DATA = {
    "pdf-to-rtf": {
        "title": "PDF to RTF — Convert for Legacy Editors (2026)",
        "tool": "/pdf/pdftodoc",
        "label": "PDF to Word",
        "pillar": "/guides/pdf-to-word",
        "pillar_label": "PDF to Word guide",
        "related": "/guides/pdf-to-text",
        "prog": "/pdf/pdftodoc",
        "example": "Legal secretary converts PDF brief to RTF for an old case-management editor that rejects DOCX",
    },
    "pdf-to-searchable-image": {
        "title": "PDF to Searchable Image — OCR Text Layer on Scans (2026)",
        "tool": "/pdf/ocrpdf",
        "label": "OCR PDF",
        "pillar": "/guides/ocr-pdf",
        "pillar_label": "OCR PDF guide",
        "related": "/guides/make-scanned-pdf-searchable",
        "prog": "/pdf/ocrpdf",
        "example": "Archivist keeps the original scanned image but adds an invisible OCR text layer so the PDF is searchable",
    },
    "pdf-client-delivery-checklist": {
        "title": "PDF Client Delivery Checklist — Before You Send (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/pdf-review-workflow",
        "pillar_label": "PDF review workflow",
        "related": "/guides/pdf-email-attachment-checklist",
        "prog": "/pdf/compress",
        "example": "Consultant runs a 7-point check — fonts, redaction, version, size, watermark, metadata, filename — before final client send",
    },
    "pdf-checksum-verify-integrity": {
        "title": "Verify PDF Checksum &amp; Integrity — SHA-256 (2026)",
        "tool": "/pdf/pdfmetadata",
        "label": "PDF Metadata",
        "pillar": "/guides/pdf-records-management-policy",
        "pillar_label": "records management policy",
        "related": "/guides/pdf-timestamp-authority-signing",
        "prog": "/pdf/pdfmetadata",
        "example": "Records team hashes each archived PDF with SHA-256 on ingest and re-verifies annually to prove no tampering",
    },
}

for key, (audience, example, persona_slug, compress_slug) in W57_COMPRESSOR_META.items():
    slug = f"best-pdf-compressor-for-{key}"
    W57_DATA[slug] = {
        "title": f"Best PDF Compressor for {audience} — Browser vs Desktop (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/compress-pdf-guide",
        "pillar_label": "compress PDF guide",
        "related": f"/guides/{persona_slug}",
        "prog": "/pdf/compress",
        "example": example,
        "audience": audience,
        "compress_related": f"/guides/{compress_slug}",
    }

for key, (audience, use_case, example, editor_slug) in W57_SECURE_META.items():
    slug = f"secure-pdf-workflow-{key}"
    W57_DATA[slug] = {
        "title": f"Secure PDF Workflow for {audience} — Redact, Protect, Audit (2026)",
        "tool": "/pdf/redaction",
        "label": "Redact PDF",
        "pillar": "/guides/secure-pdf-workflow",
        "pillar_label": "secure PDF workflow",
        "related": f"/guides/{editor_slug}",
        "prog": "/pdf/redaction",
        "example": example,
        "audience": audience,
        "use_case": use_case,
    }


def _d(slug: str, html: str) -> str:
    p = W57_DATA[slug].get("prog", "")
    tail = f'<p>Tool: <a href="{p}">{p}</a></p>' if p else ""
    return html + tail


def _compressor_deep(slug: str) -> str:
    d = W57_DATA[slug]
    return _d(
        slug,
        f"""
            <h2>PDF compressor picks for {d['audience']}</h2>
            <p>Typical workflow: {d['example']}.</p>
            <ul>
            <li><a href="/pdf/compress">Compress PDF</a> — Medium preset first, escalate only if needed</li>
            <li><a href="/pdf/merge">Merge</a> before compress when bundling multiple files</li>
            <li><a href="/pdf/ocrpdf">OCR</a> scanned docs before compress if search is required</li>
            <li>Desktop Ghostscript batch when IT permits local installs</li>
            </ul>
            <p><a href="{d['related']}">Browser tools guide</a> · <a href="/guides/{d['compress_related']}">Vertical compress guide</a> · <a href="/compare">Compare vendors</a>.</p>
            """,
    )


def _secure_deep(slug: str) -> str:
    d = W57_DATA[slug]
    return _d(
        slug,
        f"""
            <h2>Secure PDF workflow for {d['audience']}</h2>
            <p>Use case: {d['use_case']} — {d['example']}.</p>
            <ol>
            <li><a href="/pdf/redaction">Redact</a> privileged or sensitive content — flatten so text cannot be recovered</li>
            <li><a href="/pdf/watermark">Watermark</a> DRAFT until approved for release</li>
            <li><a href="/pdf/password">Password-protect</a> with AES-256 — send passphrase on a separate channel</li>
            <li>Log version and retention class before external share</li>
            </ol>
            <p><a href="{d['related']}">Editor picks</a> · <a href="/guides/document-retention-pdf">Retention</a> · <a href="/guides/pdf-version-control-best-practices">Version control</a>.</p>
            """,
    )


W57_DEEP = {
    "pdf-to-rtf": _d("pdf-to-rtf", """
            <h2>PDF to RTF workflow</h2>
            <ol>
            <li><a href="/pdf/pdftodoc">PDF to Word</a> — export DOCX first</li>
            <li>Open DOCX in your editor — Save As → Rich Text Format (.rtf)</li>
            <li>RTF strips advanced layout — verify tables and headers</li>
            <li>Scanned source — <a href="/pdf/ocrpdf">OCR</a> before converting</li>
            </ol>
            <p><a href="/guides/pdf-to-word">PDF to Word guide</a> · <a href="/guides/pdf-to-text">PDF to text</a>.</p>
            """),
    "pdf-to-searchable-image": _d("pdf-to-searchable-image", """
            <h2>Searchable image PDF</h2>
            <ul>
            <li>Keeps the original page image — adds an invisible OCR text layer</li>
            <li><a href="/pdf/ocrpdf">OCR PDF</a> — choose "searchable image" output if prompted</li>
            <li>Best for archives that must preserve the exact visual scan</li>
            <li>Spot-check selectable text aligns with the image</li>
            </ul>
            <p><a href="/guides/make-scanned-pdf-searchable">Make scanned PDF searchable</a> · <a href="/guides/ocr-pdf">OCR guide</a>.</p>
            """),
    "pdf-client-delivery-checklist": _d("pdf-client-delivery-checklist", """
            <h2>Client delivery checklist</h2>
            <ol>
            <li>Fonts embedded — no substitution on client machines</li>
            <li>Redaction flattened — no recoverable hidden text</li>
            <li>Correct version — matches approved draft, not an old export</li>
            <li>Size under client portal or email cap</li>
            <li>Watermark removed on final (or DRAFT intentionally kept)</li>
            <li>Metadata scrubbed — author, comments, track changes</li>
            <li>Filename convention — ClientName_Document_Date.pdf</li>
            </ol>
            <p><a href="/guides/pdf-email-attachment-checklist">Email checklist</a> · <a href="/guides/pdf-review-workflow">Review workflow</a>.</p>
            """),
    "pdf-checksum-verify-integrity": _d("pdf-checksum-verify-integrity", """
            <h2>Verify PDF integrity</h2>
            <ol>
            <li>Compute SHA-256 hash on ingest — store hash alongside the file</li>
            <li>Re-compute and compare on access or annual audit</li>
            <li>Mismatch = tampering or corruption — restore from WORM copy</li>
            <li>Pair with a timestamp authority signature for legal weight</li>
            </ol>
            <p><a href="/guides/pdf-timestamp-authority-signing">TSA signing</a> · <a href="/guides/pdf-worm-storage-compliance">WORM storage</a>.</p>
            """),
}

for key in W57_COMPRESSOR_META:
    W57_DEEP[f"best-pdf-compressor-for-{key}"] = _compressor_deep(f"best-pdf-compressor-for-{key}")

for key in W57_SECURE_META:
    W57_DEEP[f"secure-pdf-workflow-{key}"] = _secure_deep(f"secure-pdf-workflow-{key}")

W57_CREATE_CLUSTER = """
            <h2>CREATE batch 21 — compressor finale, convert, secure workflow</h2>
            <ul>
            <li>Compressor personas (17/17): <a href="/guides/best-pdf-compressor-for-healthcare">Healthcare</a> · <a href="/guides/best-pdf-compressor-for-government">Government</a> · <a href="/guides/best-pdf-compressor-for-consultants">Consultants</a> · <a href="/guides/best-pdf-compressor-for-developers">Developers</a></li>
            <li>Convert: <a href="/guides/pdf-to-rtf">PDF to RTF</a> · <a href="/guides/pdf-to-searchable-image">PDF to searchable image</a></li>
            <li>Workflow: <a href="/guides/pdf-client-delivery-checklist">Client delivery checklist</a> · <a href="/guides/pdf-checksum-verify-integrity">Checksum integrity</a></li>
            <li>Secure workflow: <a href="/guides/secure-pdf-workflow-lawyers">Lawyers</a> · <a href="/guides/secure-pdf-workflow-accountants">Accountants</a></li>
            </ul>
            <p>Prior compressor batch: <a href="/guides/best-pdf-compressor-for-lawyers">Wave 56 index</a></p>
            """

W57_COMPRESSOR_CLUSTER = """
            <h2>Best PDF compressor hub (17 personas)</h2>
            <p>Regulated: <a href="/guides/best-pdf-compressor-for-healthcare">Healthcare</a> · <a href="/guides/best-pdf-compressor-for-government">Government</a> · <a href="/guides/best-pdf-compressor-for-lawyers">Lawyers</a></p>
            <p>Business: <a href="/guides/best-pdf-compressor-for-accountants">Accountants</a> · <a href="/guides/best-pdf-compressor-for-small-business">Small business</a> · <a href="/guides/best-pdf-compressor-for-consultants">Consultants</a> · <a href="/guides/best-pdf-compressor-for-sales-teams">Sales</a></p>
            <p>Teams &amp; tech: <a href="/guides/best-pdf-compressor-for-remote-teams">Remote</a> · <a href="/guides/best-pdf-compressor-for-hr-teams">HR</a> · <a href="/guides/best-pdf-compressor-for-developers">Developers</a> · <a href="/guides/best-pdf-compressor-for-designers">Designers</a></p>
            <p>Field: <a href="/guides/best-pdf-compressor-for-real-estate-agents">Real estate</a> · <a href="/guides/best-pdf-compressor-for-nonprofits">Nonprofits</a> · <a href="/guides/best-pdf-compressor-for-researchers">Researchers</a></p>
            <p>Independent: <a href="/guides/best-pdf-compressor-for-students">Students</a> · <a href="/guides/best-pdf-compressor-for-teachers">Teachers</a> · <a href="/guides/best-pdf-compressor-for-freelancers">Freelancers</a></p>
            """

W57_COMPRESS_TOPUP = """
            <h2>Compressor &amp; secure-share checklist</h2>
            <ol>
            <li>Compress digital PDFs first — split scanned packs if compression blurs signatures</li>
            <li>Merge then a single compress pass — avoids double-blurring scans</li>
            <li>Redact before compress when sharing externally</li>
            <li>Keep an uncompressed master in the matter or project folder</li>
            </ol>
            """

W57_CLOSING = """
            <h2>Related guides</h2>
            <p>Wave 57 completes the best-PDF-compressor persona cluster (17/17), adds RTF and searchable-image conversion, delivery and integrity workflows, and starts secure-PDF-workflow verticals — CREATE batch 21 of 450.</p>
            <p>Hub: <a href="/guides/compress-pdf-guide">Compress PDF</a> · CREATE remaining: 93</p>
            """
