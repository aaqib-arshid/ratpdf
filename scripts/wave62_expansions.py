"""Wave 62 — CREATE batch 26 (17 guides, score 67). Best-PDF-OCR persona cluster."""

W62_SLUGS = [
    "best-pdf-ocr-for-lawyers",
    "best-pdf-ocr-for-students",
    "best-pdf-ocr-for-accountants",
    "best-pdf-ocr-for-teachers",
    "best-pdf-ocr-for-freelancers",
    "best-pdf-ocr-for-small-business",
    "best-pdf-ocr-for-healthcare",
    "best-pdf-ocr-for-real-estate-agents",
    "best-pdf-ocr-for-remote-teams",
    "best-pdf-ocr-for-nonprofits",
    "best-pdf-ocr-for-government",
    "best-pdf-ocr-for-researchers",
    "best-pdf-ocr-for-designers",
    "best-pdf-ocr-for-developers",
    "best-pdf-ocr-for-sales-teams",
    "best-pdf-ocr-for-hr-teams",
    "best-pdf-ocr-for-consultants",
]

OCR_PERSONA_CREATE_SLUGS = set(W62_SLUGS)

# vertical -> (audience, example, persona_browser_slug, ocr_related)
W62_OCR_META = {
    "lawyers": (
        "Lawyers",
        "Paralegal OCRs a scanned exhibit so the brief is searchable and clauses can be copied for redlining",
        "best-browser-pdf-tools-for-lawyers",
        "ocr-pdf-for-legal-documents",
    ),
    "students": (
        "Students",
        "Student OCRs a scanned textbook chapter so passages become searchable and quotable for citations",
        "best-browser-pdf-tools-for-students",
        "ocr-pdf-for-students",
    ),
    "accountants": (
        "Accountants",
        "Staff OCRs a scanned receipt batch so amounts are searchable before export to the ledger",
        "best-browser-pdf-tools-for-accountants",
        "ocr-pdf-for-accountants",
    ),
    "teachers": (
        "Teachers",
        "Teacher OCRs an old scanned worksheet so it becomes editable and searchable before reuse",
        "best-browser-pdf-tools-for-teachers",
        "ocr-pdf-for-teachers",
    ),
    "freelancers": (
        "Freelancers",
        "Freelancer OCRs a scanned client contract so terms are searchable before quoting",
        "best-browser-pdf-tools-for-freelancers",
        "ocr-pdf-for-freelancers",
    ),
    "small-business": (
        "Small Business",
        "Owner OCRs scanned supplier invoices so totals are searchable for bookkeeping",
        "best-browser-pdf-tools-for-small-business",
        "ocr-pdf-for-small-business",
    ),
    "healthcare": (
        "Healthcare",
        "Admin OCRs scanned intake forms so records are searchable using a BAA-checked tool",
        "best-browser-pdf-tools-for-healthcare-administrators",
        "ocr-pdf-for-healthcare",
    ),
    "real-estate-agents": (
        "Real Estate Agents",
        "Agent OCRs a scanned disclosure packet so clauses are searchable before closing",
        "best-browser-pdf-tools-for-real-estate-agents",
        "ocr-pdf-for-real-estate",
    ),
    "remote-teams": (
        "Remote Teams",
        "Distributed team OCRs scanned docs so the whole archive is searchable in the cloud",
        "best-browser-pdf-tools-for-remote-teams",
        "make-scanned-pdf-searchable",
    ),
    "nonprofits": (
        "Nonprofits",
        "Coordinator OCRs scanned receipts and reports so grant records stay searchable for audits",
        "best-browser-pdf-tools-for-nonprofits",
        "ocr-pdf-for-nonprofits",
    ),
    "government": (
        "Government",
        "Records clerk OCRs scanned filings so public records become searchable and accessible",
        "best-browser-pdf-tools-for-government-contractors",
        "ocr-pdf-for-government",
    ),
    "researchers": (
        "Researchers",
        "PI OCRs scanned archival papers and tables so data becomes searchable and extractable",
        "best-browser-pdf-tools-for-researchers",
        "ocr-pdf-for-researchers",
    ),
    "designers": (
        "Designers",
        "Designer OCRs a scanned brand spec so text is selectable for reuse without retyping",
        "best-browser-pdf-tools-for-designers",
        "make-scanned-pdf-searchable",
    ),
    "developers": (
        "Developers",
        "Developer OCRs scanned docs in a pipeline so a downstream parser can extract fields",
        "best-browser-pdf-tools-for-developers",
        "make-scanned-pdf-searchable",
    ),
    "sales-teams": (
        "Sales Teams",
        "AE OCRs a scanned signed order so terms are searchable in the CRM record",
        "best-browser-pdf-tools-for-consultants",
        "make-scanned-pdf-searchable",
    ),
    "hr-teams": (
        "HR Teams",
        "HR OCRs scanned employee forms so the personnel file is searchable for audits",
        "best-browser-pdf-tools-for-hr-teams",
        "ocr-pdf-for-hr",
    ),
    "consultants": (
        "Consultants",
        "Consultant OCRs a scanned client report so findings are searchable for the deliverable",
        "best-browser-pdf-tools-for-consultants",
        "ocr-pdf-for-consultants",
    ),
}

W62_DATA = {}

for key, (audience, example, persona_slug, ocr_related) in W62_OCR_META.items():
    slug = f"best-pdf-ocr-for-{key}"
    W62_DATA[slug] = {
        "title": f"Best PDF OCR for {audience} — Browser vs Desktop (2026)",
        "tool": "/pdf/ocrpdf",
        "label": "OCR PDF",
        "pillar": "/guides/ocr-pdf",
        "pillar_label": "OCR PDF guide",
        "related": f"/guides/{persona_slug}",
        "prog": "/pdf/ocrpdf",
        "example": example,
        "audience": audience,
        "ocr_related": f"/guides/{ocr_related}",
    }


def _d(slug: str, html: str) -> str:
    p = W62_DATA[slug].get("prog", "")
    tail = f'<p>Tool: <a href="{p}">{p}</a></p>' if p else ""
    return html + tail


def _ocr_deep(slug: str) -> str:
    d = W62_DATA[slug]
    return _d(
        slug,
        f"""
            <h2>PDF OCR picks for {d['audience']}</h2>
            <p>Typical workflow: {d['example']}.</p>
            <ul>
            <li><a href="/pdf/ocrpdf">OCR PDF</a> — scan at 300 DPI grayscale for best accuracy</li>
            <li><a href="/pdf/pdftodoc">PDF to Word</a> after OCR when you need to edit layout</li>
            <li><a href="/pdf/compress">Compress</a> the searchable output before archiving or emailing</li>
            <li>Desktop Acrobat/ABBYY for high-volume batch OCR when IT permits installs</li>
            </ul>
            <p><a href="{d['related']}">Browser tools guide</a> · <a href="{d['ocr_related']}">OCR workflow</a> · <a href="/compare">Compare vendors</a>.</p>
            """,
    )


W62_DEEP = {}
for key in W62_OCR_META:
    W62_DEEP[f"best-pdf-ocr-for-{key}"] = _ocr_deep(f"best-pdf-ocr-for-{key}")

W62_CREATE_CLUSTER = """
            <h2>CREATE batch 26 — best PDF OCR persona guides</h2>
            <ul>
            <li>Legal &amp; finance: <a href="/guides/best-pdf-ocr-for-lawyers">Lawyers</a> · <a href="/guides/best-pdf-ocr-for-accountants">Accountants</a> · <a href="/guides/best-pdf-ocr-for-small-business">Small business</a></li>
            <li>Regulated: <a href="/guides/best-pdf-ocr-for-healthcare">Healthcare</a> · <a href="/guides/best-pdf-ocr-for-government">Government</a> · <a href="/guides/best-pdf-ocr-for-nonprofits">Nonprofits</a></li>
            <li>People: <a href="/guides/best-pdf-ocr-for-students">Students</a> · <a href="/guides/best-pdf-ocr-for-teachers">Teachers</a> · <a href="/guides/best-pdf-ocr-for-hr-teams">HR</a> · <a href="/guides/best-pdf-ocr-for-remote-teams">Remote teams</a></li>
            <li>Creative &amp; tech: <a href="/guides/best-pdf-ocr-for-designers">Designers</a> · <a href="/guides/best-pdf-ocr-for-developers">Developers</a> · <a href="/guides/best-pdf-ocr-for-researchers">Researchers</a></li>
            <li>Other: <a href="/guides/best-pdf-ocr-for-freelancers">Freelancers</a> · <a href="/guides/best-pdf-ocr-for-consultants">Consultants</a> · <a href="/guides/best-pdf-ocr-for-sales-teams">Sales</a> · <a href="/guides/best-pdf-ocr-for-real-estate-agents">Real estate</a></li>
            </ul>
            <p>Pairs with: <a href="/guides/best-pdf-converter-for-lawyers">Converter personas</a> · <a href="/guides/best-pdf-merger-for-lawyers">Merger personas</a> · <a href="/guides/best-pdf-compressor-for-lawyers">Compressor personas</a> · <a href="/guides/best-pdf-editor-for-lawyers">Editor personas</a></p>
            """

W62_OCR_CLUSTER = """
            <h2>Best PDF OCR hub (17 personas)</h2>
            <p>Finance: <a href="/guides/best-pdf-ocr-for-accountants">Accountants</a> · <a href="/guides/best-pdf-ocr-for-small-business">Small business</a> · <a href="/guides/best-pdf-ocr-for-real-estate-agents">Real estate</a></p>
            <p>Legal &amp; gov: <a href="/guides/best-pdf-ocr-for-lawyers">Lawyers</a> · <a href="/guides/best-pdf-ocr-for-government">Government</a> · <a href="/guides/best-pdf-ocr-for-healthcare">Healthcare</a></p>
            <p>People ops: <a href="/guides/best-pdf-ocr-for-hr-teams">HR</a> · <a href="/guides/best-pdf-ocr-for-remote-teams">Remote</a> · <a href="/guides/best-pdf-ocr-for-consultants">Consultants</a> · <a href="/guides/best-pdf-ocr-for-sales-teams">Sales</a></p>
            <p>OCR tools: <a href="/pdf/ocrpdf">OCR PDF</a> · <a href="/pdf/pdftodoc">PDF to Word</a> · <a href="/pdf/pdftotext">PDF to Text</a> · <a href="/pdf/compress">Compress</a></p>
            """

W62_TOPUP = """
            <h2>OCR persona checklist</h2>
            <ol>
            <li>Scan at 300 DPI grayscale — low DPI is the top cause of OCR errors</li>
            <li>Pick the correct recognition language before running OCR</li>
            <li>Proofread numbers, names, and IDs — no OCR engine is perfect</li>
            <li>Compress the searchable output before archiving or emailing</li>
            </ol>
            """

W62_CLOSING = """
            <h2>Related guides</h2>
            <p>Wave 62 completes the best-PDF-OCR persona cluster (17/17) — CREATE batch 26 of 450.</p>
            <p>Hub: <a href="/guides/ocr-pdf">OCR PDF</a> · CREATE remaining: 8</p>
            """
