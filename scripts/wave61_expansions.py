"""Wave 61 — CREATE batch 25 (17 guides, score 68). Best-PDF-converter persona cluster."""

W61_SLUGS = [
    "best-pdf-converter-for-lawyers",
    "best-pdf-converter-for-students",
    "best-pdf-converter-for-accountants",
    "best-pdf-converter-for-teachers",
    "best-pdf-converter-for-freelancers",
    "best-pdf-converter-for-small-business",
    "best-pdf-converter-for-healthcare",
    "best-pdf-converter-for-real-estate-agents",
    "best-pdf-converter-for-remote-teams",
    "best-pdf-converter-for-nonprofits",
    "best-pdf-converter-for-government",
    "best-pdf-converter-for-researchers",
    "best-pdf-converter-for-designers",
    "best-pdf-converter-for-developers",
    "best-pdf-converter-for-sales-teams",
    "best-pdf-converter-for-hr-teams",
    "best-pdf-converter-for-consultants",
]

CONVERTER_CREATE_SLUGS = set(W61_SLUGS)

# vertical -> (audience, example, persona_browser_slug, convert_related, convert_label)
W61_CONVERTER_META = {
    "lawyers": (
        "Lawyers",
        "Paralegal converts a PDF brief to Word to redline clauses, then re-exports a clean filing PDF",
        "best-browser-pdf-tools-for-lawyers",
        "pdf-to-word",
    ),
    "students": (
        "Students",
        "Student converts a lecture PDF to Word to add notes, and a reading scan to text for citations",
        "best-browser-pdf-tools-for-students",
        "pdf-to-word",
    ),
    "accountants": (
        "Accountants",
        "Staff converts a PDF bank statement to Excel to reconcile line items at month-end",
        "best-browser-pdf-tools-for-accountants",
        "pdf-to-excel",
    ),
    "teachers": (
        "Teachers",
        "Teacher converts a PDF worksheet to Word to edit questions before reprinting for class",
        "best-browser-pdf-tools-for-teachers",
        "pdf-to-word",
    ),
    "freelancers": (
        "Freelancers",
        "Freelancer converts a client PDF brief to Word to mark up scope before quoting",
        "best-browser-pdf-tools-for-freelancers",
        "pdf-to-word",
    ),
    "small-business": (
        "Small Business",
        "Owner converts a PDF supplier price list to Excel to compare costs across vendors",
        "best-browser-pdf-tools-for-small-business",
        "pdf-to-excel",
    ),
    "healthcare": (
        "Healthcare",
        "Admin converts a PDF policy to Word for the annual review with a BAA-checked tool",
        "best-browser-pdf-tools-for-healthcare-administrators",
        "pdf-to-word",
    ),
    "real-estate-agents": (
        "Real Estate Agents",
        "Agent converts a PDF disclosure to Word to update boilerplate before the next listing",
        "best-browser-pdf-tools-for-real-estate-agents",
        "pdf-to-word",
    ),
    "remote-teams": (
        "Remote Teams",
        "Distributed team converts PDF docs to Word so they can edit collaboratively in the cloud",
        "best-browser-pdf-tools-for-remote-teams",
        "pdf-to-word",
    ),
    "nonprofits": (
        "Nonprofits",
        "Grant writer converts a PDF narrative to Word to repurpose text for the next application",
        "best-browser-pdf-tools-for-nonprofits",
        "pdf-to-word",
    ),
    "government": (
        "Government",
        "Specialist converts a PDF RFP to Word to draft a compliant proposal response",
        "best-browser-pdf-tools-for-government-contractors",
        "pdf-to-word",
    ),
    "researchers": (
        "Researchers",
        "PI converts a PDF data table to Excel for reanalysis, OCRing scanned tables first",
        "best-browser-pdf-tools-for-researchers",
        "pdf-to-excel",
    ),
    "designers": (
        "Designers",
        "Designer converts a PDF proof to images for a moodboard without a desktop license",
        "best-browser-pdf-tools-for-designers",
        "pdf-to-word",
    ),
    "developers": (
        "Developers",
        "Developer converts a PDF spec to text/Markdown to seed docs and extract code blocks",
        "best-browser-pdf-tools-for-developers",
        "pdf-to-text",
    ),
    "sales-teams": (
        "Sales Teams",
        "AE converts a PDF proposal to Word to tailor pricing for each enterprise prospect",
        "best-browser-pdf-tools-for-consultants",
        "pdf-to-word",
    ),
    "hr-teams": (
        "HR Teams",
        "HR converts a PDF policy to Word to update the handbook each review cycle",
        "best-browser-pdf-tools-for-hr-teams",
        "pdf-to-word",
    ),
    "consultants": (
        "Consultants",
        "Consultant converts a PDF deck to Word to repurpose findings into a client report",
        "best-browser-pdf-tools-for-consultants",
        "pdf-to-word",
    ),
}

W61_DATA = {}

for key, (audience, example, persona_slug, convert_slug) in W61_CONVERTER_META.items():
    slug = f"best-pdf-converter-for-{key}"
    W61_DATA[slug] = {
        "title": f"Best PDF Converter for {audience} — Browser vs Desktop (2026)",
        "tool": "/pdf/pdftodoc",
        "label": "PDF to Word",
        "pillar": "/guides/pdf-to-word",
        "pillar_label": "PDF to Word guide",
        "related": f"/guides/{persona_slug}",
        "prog": "/pdf/pdftodoc",
        "example": example,
        "audience": audience,
        "convert_related": f"/guides/{convert_slug}",
    }


def _d(slug: str, html: str) -> str:
    p = W61_DATA[slug].get("prog", "")
    tail = f'<p>Tool: <a href="{p}">{p}</a></p>' if p else ""
    return html + tail


def _converter_deep(slug: str) -> str:
    d = W61_DATA[slug]
    return _d(
        slug,
        f"""
            <h2>PDF converter picks for {d['audience']}</h2>
            <p>Typical workflow: {d['example']}.</p>
            <ul>
            <li><a href="/pdf/pdftodoc">PDF to Word</a> — best for layout-faithful editing</li>
            <li><a href="/pdf/pdftoexcel">PDF to Excel</a> for tables · <a href="/pdf/pdftotext">PDF to Text</a> for raw data</li>
            <li><a href="/pdf/ocrpdf">OCR</a> scanned PDFs first or conversion returns empty text</li>
            <li>Desktop Acrobat for batch conversion when IT permits installs</li>
            </ul>
            <p><a href="{d['related']}">Browser tools guide</a> · <a href="{d['convert_related']}">Conversion workflow</a> · <a href="/compare">Compare vendors</a>.</p>
            """,
    )


W61_DEEP = {}
for key in W61_CONVERTER_META:
    W61_DEEP[f"best-pdf-converter-for-{key}"] = _converter_deep(f"best-pdf-converter-for-{key}")

W61_CREATE_CLUSTER = """
            <h2>CREATE batch 25 — best PDF converter persona guides</h2>
            <ul>
            <li>Legal &amp; finance: <a href="/guides/best-pdf-converter-for-lawyers">Lawyers</a> · <a href="/guides/best-pdf-converter-for-accountants">Accountants</a> · <a href="/guides/best-pdf-converter-for-small-business">Small business</a></li>
            <li>Regulated: <a href="/guides/best-pdf-converter-for-healthcare">Healthcare</a> · <a href="/guides/best-pdf-converter-for-government">Government</a> · <a href="/guides/best-pdf-converter-for-nonprofits">Nonprofits</a></li>
            <li>People: <a href="/guides/best-pdf-converter-for-students">Students</a> · <a href="/guides/best-pdf-converter-for-teachers">Teachers</a> · <a href="/guides/best-pdf-converter-for-hr-teams">HR</a> · <a href="/guides/best-pdf-converter-for-remote-teams">Remote teams</a></li>
            <li>Creative &amp; tech: <a href="/guides/best-pdf-converter-for-designers">Designers</a> · <a href="/guides/best-pdf-converter-for-developers">Developers</a> · <a href="/guides/best-pdf-converter-for-researchers">Researchers</a></li>
            <li>Other: <a href="/guides/best-pdf-converter-for-freelancers">Freelancers</a> · <a href="/guides/best-pdf-converter-for-consultants">Consultants</a> · <a href="/guides/best-pdf-converter-for-sales-teams">Sales</a> · <a href="/guides/best-pdf-converter-for-real-estate-agents">Real estate</a></li>
            </ul>
            <p>Pairs with: <a href="/guides/best-pdf-merger-for-lawyers">Merger personas</a> · <a href="/guides/best-pdf-compressor-for-lawyers">Compressor personas</a> · <a href="/guides/best-pdf-editor-for-lawyers">Editor personas</a></p>
            """

W61_CONVERTER_CLUSTER = """
            <h2>Best PDF converter hub (17 personas)</h2>
            <p>Finance: <a href="/guides/best-pdf-converter-for-accountants">Accountants</a> · <a href="/guides/best-pdf-converter-for-small-business">Small business</a> · <a href="/guides/best-pdf-converter-for-real-estate-agents">Real estate</a></p>
            <p>Legal &amp; gov: <a href="/guides/best-pdf-converter-for-lawyers">Lawyers</a> · <a href="/guides/best-pdf-converter-for-government">Government</a> · <a href="/guides/best-pdf-converter-for-healthcare">Healthcare</a></p>
            <p>People ops: <a href="/guides/best-pdf-converter-for-hr-teams">HR</a> · <a href="/guides/best-pdf-converter-for-remote-teams">Remote</a> · <a href="/guides/best-pdf-converter-for-consultants">Consultants</a> · <a href="/guides/best-pdf-converter-for-sales-teams">Sales</a></p>
            <p>Conversion tools: <a href="/pdf/pdftodoc">PDF to Word</a> · <a href="/pdf/pdftoexcel">PDF to Excel</a> · <a href="/pdf/pdftotext">PDF to Text</a> · <a href="/pdf/ocrpdf">OCR</a></p>
            """

W61_TOPUP = """
            <h2>Converter persona checklist</h2>
            <ol>
            <li>OCR scanned PDFs before converting or you get empty text</li>
            <li>PDF to Word for layout-faithful editing; PDF to Excel for tables</li>
            <li>Proofread numbers and tables after conversion — no engine is perfect</li>
            <li>Browser converter when IT blocks installs; Acrobat for batch jobs</li>
            </ol>
            """

W61_CLOSING = """
            <h2>Related guides</h2>
            <p>Wave 61 completes the best-PDF-converter persona cluster (17/17) — CREATE batch 25 of 450.</p>
            <p>Hub: <a href="/guides/pdf-to-word">PDF to Word</a> · CREATE remaining: 25</p>
            """
