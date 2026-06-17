"""Wave 59 — CREATE batch 23 (17 guides, score 69). Best-PDF-merger persona cluster."""

W59_SLUGS = [
    "best-pdf-merger-for-lawyers",
    "best-pdf-merger-for-students",
    "best-pdf-merger-for-accountants",
    "best-pdf-merger-for-teachers",
    "best-pdf-merger-for-freelancers",
    "best-pdf-merger-for-small-business",
    "best-pdf-merger-for-healthcare",
    "best-pdf-merger-for-real-estate-agents",
    "best-pdf-merger-for-remote-teams",
    "best-pdf-merger-for-nonprofits",
    "best-pdf-merger-for-government",
    "best-pdf-merger-for-researchers",
    "best-pdf-merger-for-designers",
    "best-pdf-merger-for-developers",
    "best-pdf-merger-for-sales-teams",
    "best-pdf-merger-for-hr-teams",
    "best-pdf-merger-for-consultants",
]

MERGER_CREATE_SLUGS = set(W59_SLUGS)

# vertical -> (audience, example, persona_browser_slug, merge_related)
W59_MERGER_META = {
    "lawyers": (
        "Lawyers",
        "Paralegal merges exhibit PDFs in filing order, then watermarks DRAFT until the brief is court-ready",
        "best-browser-pdf-tools-for-lawyers",
        "merge-pdf-for-lawyers",
    ),
    "students": (
        "Students",
        "Student merges weekly reading PDFs into one study pack before LMS upload",
        "best-browser-pdf-tools-for-students",
        "merge-pdf",
    ),
    "accountants": (
        "Accountants",
        "Staff merges bank statement and support schedule PDFs by account before partner review",
        "best-browser-pdf-tools-for-accountants",
        "merge-pdf-for-accountants",
    ),
    "teachers": (
        "Teachers",
        "Teacher merges syllabus, calendar, and policy PDFs into one orientation packet for Google Classroom",
        "best-browser-pdf-tools-for-teachers",
        "merge-pdf-for-education",
    ),
    "freelancers": (
        "Freelancers",
        "Freelancer merges mockup, spec, and invoice PDFs before the milestone email to the client",
        "best-browser-pdf-tools-for-freelancers",
        "merge-pdf-for-freelancers",
    ),
    "small-business": (
        "Small Business",
        "Owner merges invoice and contract PDFs into one client pack before portal upload",
        "best-browser-pdf-tools-for-small-business",
        "merge-pdf",
    ),
    "healthcare": (
        "Healthcare",
        "Admin merges policy and consent PDFs for a committee packet with a HIPAA upload check",
        "best-browser-pdf-tools-for-healthcare-administrators",
        "merge-pdf-for-healthcare",
    ),
    "real-estate-agents": (
        "Real Estate Agents",
        "Agent merges disclosure PDFs in MLS order before the buyer signature packet",
        "best-browser-pdf-tools-for-real-estate-agents",
        "merge-pdf-for-real-estate",
    ),
    "remote-teams": (
        "Remote Teams",
        "Distributed team merges approved annexes into one policy PDF for async review",
        "best-browser-pdf-tools-for-remote-teams",
        "merge-pdf",
    ),
    "nonprofits": (
        "Nonprofits",
        "Grant writer merges narrative, budget, and LOI PDFs before foundation portal upload",
        "best-browser-pdf-tools-for-nonprofits",
        "merge-pdf-for-nonprofits",
    ),
    "government": (
        "Government",
        "Contractor merges technical and cost volume PDFs in SAM submission order",
        "best-browser-pdf-tools-for-government-contractors",
        "merge-pdf-for-government",
    ),
    "researchers": (
        "Researchers",
        "PI merges manuscript, supplementary, and ethics PDFs for journal upload",
        "best-browser-pdf-tools-for-researchers",
        "merge-pdf-for-researchers",
    ),
    "designers": (
        "Designers",
        "Designer merges client delivery packages into one proof PDF without rasterizing vectors",
        "best-browser-pdf-tools-for-designers",
        "merge-pdf",
    ),
    "developers": (
        "Developers",
        "Developer merges API doc PDFs and release notes before wiki attachment",
        "best-browser-pdf-tools-for-developers",
        "merge-pdf",
    ),
    "sales-teams": (
        "Sales Teams",
        "AE merges quote, case study, and security FAQ PDFs before the enterprise prospect send",
        "best-browser-pdf-tools-for-consultants",
        "merge-pdf-for-sales-teams",
    ),
    "hr-teams": (
        "HR Teams",
        "HR merges offer letter, benefits, and policy PDFs into a day-one onboarding packet",
        "best-browser-pdf-tools-for-hr-teams",
        "merge-pdf-for-hr-teams",
    ),
    "consultants": (
        "Consultants",
        "Consultant merges SOW, timeline, and case study PDFs, watermarking DRAFT until sign-off",
        "best-browser-pdf-tools-for-consultants",
        "merge-pdf-for-consultants",
    ),
}

W59_DATA = {}

for key, (audience, example, persona_slug, merge_slug) in W59_MERGER_META.items():
    slug = f"best-pdf-merger-for-{key}"
    W59_DATA[slug] = {
        "title": f"Best PDF Merger for {audience} — Browser vs Desktop (2026)",
        "tool": "/pdf/merge",
        "label": "Merge PDF",
        "pillar": "/guides/merge-pdf",
        "pillar_label": "merge PDF guide",
        "related": f"/guides/{persona_slug}",
        "prog": "/pdf/merge",
        "example": example,
        "audience": audience,
        "merge_related": f"/guides/{merge_slug}",
    }


def _d(slug: str, html: str) -> str:
    p = W59_DATA[slug].get("prog", "")
    tail = f'<p>Tool: <a href="{p}">{p}</a></p>' if p else ""
    return html + tail


def _merger_deep(slug: str) -> str:
    d = W59_DATA[slug]
    return _d(
        slug,
        f"""
            <h2>PDF merger picks for {d['audience']}</h2>
            <p>Typical workflow: {d['example']}.</p>
            <ul>
            <li><a href="/pdf/merge">Merge PDF</a> — drag pages into the correct order before combining</li>
            <li><a href="/pdf/split">Split</a> or <a href="/pdf/rotateorremove">remove pages</a> to trim before merge</li>
            <li><a href="/pdf/compress">Compress</a> once after merge — avoids double-blurring scans</li>
            <li>Desktop Acrobat for batch Bates or 100+ file merges when IT allows installs</li>
            </ul>
            <p><a href="{d['related']}">Browser tools guide</a> · <a href="{d['merge_related']}">Vertical merge workflow</a> · <a href="/compare">Compare vendors</a>.</p>
            """,
    )


W59_DEEP = {}
for key in W59_MERGER_META:
    W59_DEEP[f"best-pdf-merger-for-{key}"] = _merger_deep(f"best-pdf-merger-for-{key}")

W59_CREATE_CLUSTER = """
            <h2>CREATE batch 23 — best PDF merger persona guides</h2>
            <ul>
            <li>Legal &amp; finance: <a href="/guides/best-pdf-merger-for-lawyers">Lawyers</a> · <a href="/guides/best-pdf-merger-for-accountants">Accountants</a> · <a href="/guides/best-pdf-merger-for-small-business">Small business</a></li>
            <li>Regulated: <a href="/guides/best-pdf-merger-for-healthcare">Healthcare</a> · <a href="/guides/best-pdf-merger-for-government">Government</a> · <a href="/guides/best-pdf-merger-for-nonprofits">Nonprofits</a></li>
            <li>People: <a href="/guides/best-pdf-merger-for-students">Students</a> · <a href="/guides/best-pdf-merger-for-teachers">Teachers</a> · <a href="/guides/best-pdf-merger-for-hr-teams">HR</a> · <a href="/guides/best-pdf-merger-for-remote-teams">Remote teams</a></li>
            <li>Creative &amp; tech: <a href="/guides/best-pdf-merger-for-designers">Designers</a> · <a href="/guides/best-pdf-merger-for-developers">Developers</a> · <a href="/guides/best-pdf-merger-for-researchers">Researchers</a></li>
            <li>Other: <a href="/guides/best-pdf-merger-for-freelancers">Freelancers</a> · <a href="/guides/best-pdf-merger-for-consultants">Consultants</a> · <a href="/guides/best-pdf-merger-for-sales-teams">Sales</a> · <a href="/guides/best-pdf-merger-for-real-estate-agents">Real estate</a></li>
            </ul>
            <p>Pairs with: <a href="/guides/best-pdf-compressor-for-lawyers">Compressor personas</a> · <a href="/guides/best-pdf-editor-for-lawyers">Editor personas</a></p>
            """

W59_MERGER_CLUSTER = """
            <h2>Best PDF merger hub (17 personas)</h2>
            <p>Finance: <a href="/guides/best-pdf-merger-for-accountants">Accountants</a> · <a href="/guides/best-pdf-merger-for-small-business">Small business</a> · <a href="/guides/best-pdf-merger-for-real-estate-agents">Real estate</a></p>
            <p>Legal &amp; gov: <a href="/guides/best-pdf-merger-for-lawyers">Lawyers</a> · <a href="/guides/best-pdf-merger-for-government">Government</a> · <a href="/guides/best-pdf-merger-for-healthcare">Healthcare</a></p>
            <p>People ops: <a href="/guides/best-pdf-merger-for-hr-teams">HR</a> · <a href="/guides/best-pdf-merger-for-remote-teams">Remote</a> · <a href="/guides/best-pdf-merger-for-consultants">Consultants</a> · <a href="/guides/best-pdf-merger-for-sales-teams">Sales</a></p>
            """

W59_TOPUP = """
            <h2>Merger persona checklist</h2>
            <ol>
            <li>Order pages before merging — reordering after is slower</li>
            <li>Trim blanks and duplicates with split/remove first</li>
            <li>Merge first, then a single compress pass</li>
            <li>Browser merger when IT blocks desktop installs; Acrobat for batch Bates</li>
            </ol>
            """

W59_CLOSING = """
            <h2>Related guides</h2>
            <p>Wave 59 completes the best-PDF-merger persona cluster (17/17) — CREATE batch 23 of 450.</p>
            <p>Hub: <a href="/guides/merge-pdf">Merge PDF</a> · CREATE remaining: 59</p>
            """
