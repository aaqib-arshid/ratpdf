"""Wave 54 — CREATE batch 18 (17 guides, score 71). Best PDF editor persona cluster + version control."""

W54_SLUGS = [
    "best-pdf-editor-for-students",
    "best-pdf-editor-for-accountants",
    "best-pdf-editor-for-teachers",
    "best-pdf-editor-for-freelancers",
    "best-pdf-editor-for-small-business",
    "best-pdf-editor-for-healthcare",
    "best-pdf-editor-for-real-estate-agents",
    "best-pdf-editor-for-remote-teams",
    "best-pdf-editor-for-nonprofits",
    "best-pdf-editor-for-government",
    "best-pdf-editor-for-researchers",
    "best-pdf-editor-for-designers",
    "best-pdf-editor-for-developers",
    "best-pdf-editor-for-sales-teams",
    "best-pdf-editor-for-hr-teams",
    "best-pdf-editor-for-consultants",
    "pdf-version-control-best-practices",
]

EDITOR_CREATE_SLUGS = set(W54_SLUGS) - {"pdf-version-control-best-practices"}

WORKFLOW_CREATE_SLUGS = {"pdf-version-control-best-practices"}

W54_EDITOR_META = {
    "students": (
        "Students",
        "Student merges weekly readings, annotates lecture PDFs, and compresses assignments for LMS upload in browser",
        "best-browser-pdf-tools-for-students",
    ),
    "accountants": (
        "Accountants",
        "Accountant redacts client TIN from tax PDF, merges support schedules, and exports clean pack for partner review",
        "best-browser-pdf-tools-for-accountants",
    ),
    "teachers": (
        "Teachers",
        "Teacher splits chapter PDF, OCRs scanned worksheet, and merges syllabus pack for Google Classroom",
        "best-browser-pdf-tools-for-teachers",
    ),
    "freelancers": (
        "Freelancers",
        "Freelancer watermarks proposal PDF, edits client feedback pages, and compresses deliverable before invoice send",
        "best-browser-pdf-tools-for-freelancers",
    ),
    "small-business": (
        "Small Business",
        "Owner merges invoice and contract PDFs, edits quote typos, and password-protects pricing before client email",
        "best-browser-pdf-tools-for-small-business",
    ),
    "healthcare": (
        "Healthcare",
        "Admin redacts PHI from disclosure PDF and edits policy headers — BAA-checked browser tool only",
        "best-browser-pdf-tools-for-healthcare-administrators",
    ),
    "real-estate-agents": (
        "Real Estate Agents",
        "Agent merges disclosure PDFs, edits listing typo, and compresses pack for MLS email cap",
        "best-browser-pdf-tools-for-real-estate-agents",
    ),
    "remote-teams": (
        "Remote Teams",
        "Distributed team watermarks DRAFT policy PDF, comments in source DOCX, merges approved annex in browser",
        "best-browser-pdf-tools-for-remote-teams",
    ),
    "nonprofits": (
        "Nonprofits",
        "Grant writer edits narrative PDF exhibit, merges budget annex, and compresses before foundation portal",
        "best-browser-pdf-tools-for-nonprofits",
    ),
    "government": (
        "Government",
        "Contract specialist redacts CUI from draft PDF, merges RFP volumes, and compresses for SAM upload",
        "best-browser-pdf-tools-for-government-contractors",
    ),
    "researchers": (
        "Researchers",
        "PI splits supplementary PDF, OCRs legacy scan, and merges ethics approval for journal resubmit",
        "best-browser-pdf-tools-for-researchers",
    ),
    "designers": (
        "Designers",
        "Designer flattens proof PDF, embeds fonts check, and exports print handoff without desktop preflight license",
        "best-browser-pdf-tools-for-designers",
    ),
    "developers": (
        "Developers",
        "Developer merges API doc PDFs, extracts pages from release notes, and compresses for wiki attach",
        "best-browser-pdf-tools-for-developers",
    ),
    "sales-teams": (
        "Sales Teams",
        "AE edits proposal PDF pricing page, merges case study annex, and compresses before enterprise prospect send",
        "best-browser-pdf-tools-for-consultants",
    ),
    "hr-teams": (
        "HR Teams",
        "HR merges onboarding PDF pack, redacts salary on sample offer, and password-protects compensation docs",
        "best-browser-pdf-tools-for-hr-teams",
    ),
    "consultants": (
        "Consultants",
        "Consultant watermarks DRAFT deliverable, edits exhibit PDF, and merges final pack for client sign-off",
        "best-browser-pdf-tools-for-consultants",
    ),
}

W54_DATA = {
    "pdf-version-control-best-practices": {
        "title": "PDF Version Control Best Practices — Naming &amp; Audit (2026)",
        "tool": "/pdf/merge",
        "label": "Merge PDF",
        "pillar": "/guides/pdf-review-workflow",
        "pillar_label": "PDF review workflow",
        "related": "/guides/pdf-workflow-checklist",
        "prog": "/pdf/merge",
        "example": "Legal team adopts v3-APPROVED filename convention — matter folder log — legal hold pauses destruction on v2 drafts",
    },
}

for key, (audience, example, persona_slug) in W54_EDITOR_META.items():
    slug = f"best-pdf-editor-for-{key}"
    W54_DATA[slug] = {
        "title": f"Best PDF Editor for {audience} — Browser vs Desktop (2026)",
        "tool": "/pdf/editpdf",
        "label": "Edit PDF",
        "pillar": "/guides/browser-vs-desktop-pdf-tools",
        "pillar_label": "browser vs desktop PDF tools",
        "related": f"/guides/{persona_slug}",
        "prog": "/pdf/editpdf",
        "example": example,
        "audience": audience,
    }


def _d(slug: str, html: str) -> str:
    p = W54_DATA[slug].get("prog", "")
    tail = f'<p>Tool: <a href="{p}">{p}</a></p>' if p else ""
    return html + tail


def _editor_deep(slug: str) -> str:
    d = W54_DATA[slug]
    return _d(
        slug,
        f"""
            <h2>PDF editor picks for {d['audience']}</h2>
            <p>Typical workflow: {d['example']}.</p>
            <ul>
            <li><a href="/pdf/editpdf">Edit PDF</a> — page text and layout fixes</li>
            <li><a href="/pdf/merge">Merge</a> · <a href="/pdf/split">Split</a> · <a href="/pdf/compress">Compress</a></li>
            <li><a href="/pdf/redaction">Redact</a> · <a href="/pdf/watermark">Watermark</a> · <a href="/pdf/password">Protect</a></li>
            </ul>
            <p><a href="{d['related']}">Browser tools guide</a> · <a href="/guides/best-pdf-editor-for-lawyers">Lawyers (reference)</a> · <a href="/compare">Compare vendors</a>.</p>
            """,
    )


W54_DEEP = {
    "pdf-version-control-best-practices": _d("pdf-version-control-best-practices", """
            <h2>PDF version control</h2>
            <ol>
            <li>Filename convention — <code>DocName-v3-APPROVED.pdf</code></li>
            <li>Single source of truth folder — no email attachment as master</li>
            <li>Watermark DRAFT on circulation — remove on final only</li>
            <li>Legal hold pauses delete on all versions in matter scope</li>
            </ol>
            <p><a href="/guides/pdf-review-workflow">Review workflow</a> · <a href="/guides/document-retention-pdf">Retention</a>.</p>
            """),
}

for key in W54_EDITOR_META:
    W54_DEEP[f"best-pdf-editor-for-{key}"] = _editor_deep(f"best-pdf-editor-for-{key}")

W54_CREATE_CLUSTER = """
            <h2>CREATE batch 18 — best PDF editor persona guides</h2>
            <ul>
            <li>People: <a href="/guides/best-pdf-editor-for-students">Students</a> · <a href="/guides/best-pdf-editor-for-teachers">Teachers</a> · <a href="/guides/best-pdf-editor-for-hr-teams">HR</a> · <a href="/guides/best-pdf-editor-for-remote-teams">Remote teams</a></li>
            <li>Business: <a href="/guides/best-pdf-editor-for-accountants">Accountants</a> · <a href="/guides/best-pdf-editor-for-small-business">Small business</a> · <a href="/guides/best-pdf-editor-for-consultants">Consultants</a> · <a href="/guides/best-pdf-editor-for-sales-teams">Sales</a></li>
            <li>Regulated: <a href="/guides/best-pdf-editor-for-healthcare">Healthcare</a> · <a href="/guides/best-pdf-editor-for-government">Government</a> · <a href="/guides/best-pdf-editor-for-lawyers">Lawyers</a></li>
            <li>Creative &amp; tech: <a href="/guides/best-pdf-editor-for-designers">Designers</a> · <a href="/guides/best-pdf-editor-for-developers">Developers</a> · <a href="/guides/best-pdf-editor-for-researchers">Researchers</a></li>
            <li>Other: <a href="/guides/best-pdf-editor-for-real-estate-agents">Real estate</a> · <a href="/guides/best-pdf-editor-for-nonprofits">Nonprofits</a> · <a href="/guides/pdf-version-control-best-practices">Version control</a></li>
            </ul>
            <p>Persona browser tools: <a href="/guides/best-browser-pdf-tools-for-accountants">Wave 47–49 index</a></p>
            """

W54_EDITOR_CLUSTER = """
            <h2>Best PDF editor hub (17 personas)</h2>
            <p>Finance: <a href="/guides/best-pdf-editor-for-accountants">Accountants</a> · <a href="/guides/best-pdf-editor-for-small-business">Small business</a> · <a href="/guides/best-pdf-editor-for-real-estate-agents">Real estate</a></p>
            <p>Legal &amp; gov: <a href="/guides/best-pdf-editor-for-lawyers">Lawyers</a> · <a href="/guides/best-pdf-editor-for-government">Government</a> · <a href="/guides/best-pdf-editor-for-healthcare">Healthcare</a></p>
            <p>People ops: <a href="/guides/best-pdf-editor-for-hr-teams">HR</a> · <a href="/guides/best-pdf-editor-for-remote-teams">Remote</a> · <a href="/guides/best-pdf-editor-for-consultants">Consultants</a> · <a href="/guides/best-pdf-editor-for-sales-teams">Sales</a></p>
            """

W54_COMPRESS_TOPUP = """
            <h2>Editor persona checklist</h2>
            <ol>
            <li>Browser editor when IT blocks desktop installs</li>
            <li>Redact PHI/PII/CUI before external upload</li>
            <li>Version filename — never overwrite final without log</li>
            <li>Desktop Acrobat for batch Bates and air-gapped matters</li>
            </ol>
            """

W54_CLOSING = """
            <h2>Related guides</h2>
            <p>Wave 54 completes sixteen best-PDF-editor persona guides plus version control best practices — CREATE batch 18 of 450.</p>
            <p>Hub: <a href="/guides/browser-vs-desktop-pdf-tools">browser vs desktop</a> · CREATE remaining: 144</p>
            """
