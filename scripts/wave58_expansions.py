"""Wave 58 — CREATE batch 22 (17 guides, score 69). Secure-PDF-workflow vertical finale + workflow guides."""

W58_SLUGS = [
    "secure-pdf-workflow-healthcare",
    "secure-pdf-workflow-real-estate",
    "secure-pdf-workflow-insurance",
    "secure-pdf-workflow-education",
    "secure-pdf-workflow-nonprofits",
    "secure-pdf-workflow-government",
    "secure-pdf-workflow-freelancers",
    "secure-pdf-workflow-consultants",
    "secure-pdf-workflow-architects",
    "secure-pdf-workflow-engineers",
    "secure-pdf-workflow-researchers",
    "secure-pdf-workflow-journalists",
    "secure-pdf-workflow-hr-teams",
    "secure-pdf-workflow-sales-teams",
    "secure-pdf-workflow-marketing-teams",
    "pdf-comments-to-word",
    "pdf-destruction-certificate",
]

SECURE_CREATE_SLUGS = {
    "secure-pdf-workflow-healthcare",
    "secure-pdf-workflow-real-estate",
    "secure-pdf-workflow-insurance",
    "secure-pdf-workflow-education",
    "secure-pdf-workflow-nonprofits",
    "secure-pdf-workflow-government",
    "secure-pdf-workflow-freelancers",
    "secure-pdf-workflow-consultants",
    "secure-pdf-workflow-architects",
    "secure-pdf-workflow-engineers",
    "secure-pdf-workflow-researchers",
    "secure-pdf-workflow-journalists",
    "secure-pdf-workflow-hr-teams",
    "secure-pdf-workflow-sales-teams",
    "secure-pdf-workflow-marketing-teams",
}

WORKFLOW_CREATE_SLUGS = {"pdf-comments-to-word", "pdf-destruction-certificate"}

W58_SECURE_META = {
    "healthcare": (
        "Healthcare",
        "Records release",
        "Admin redacts PHI from chart PDF, password-protects the disclosure, and logs the release per BAA before patient portal upload",
        "compress-pdf-for-healthcare",
    ),
    "real-estate": (
        "Real Estate",
        "Disclosure handoff",
        "Agent redacts seller SSN from disclosure PDF, watermarks DRAFT, and protects the pack before buyer share",
        "compress-pdf-for-real-estate",
    ),
    "insurance": (
        "Insurance",
        "Claims file",
        "Adjuster redacts claimant bank details, protects the claims PDF, and logs version before SIU handoff",
        "compress-pdf-for-insurance",
    ),
    "education": (
        "Education",
        "Student records",
        "Registrar redacts FERPA-protected IDs from transcript PDF and password-protects before emailing the family",
        "compress-pdf-for-education",
    ),
    "nonprofits": (
        "Nonprofits",
        "Donor records",
        "Development lead redacts donor card numbers from receipt PDF and protects the pack before board review",
        "compress-pdf-for-nonprofits",
    ),
    "government": (
        "Government",
        "FOIA / CUI",
        "Clerk redacts CUI from release PDF, watermarks DRAFT, and protects the volume before SAM upload",
        "compress-pdf-for-government",
    ),
    "freelancers": (
        "Freelancers",
        "Contract handoff",
        "Freelancer redacts personal address from signed SOW, watermarks DRAFT on revisions, and protects the deliverable",
        "compress-pdf-for-freelancers",
    ),
    "consultants": (
        "Consultants",
        "Client deliverable",
        "Consultant redacts client names from a case study PDF, watermarks DRAFT, and protects the strategy deck before send",
        "compress-pdf-for-consultants",
    ),
    "architects": (
        "Architects",
        "Submittal set",
        "Architect redacts owner contact info from spec PDF, watermarks NOT FOR CONSTRUCTION, and protects the submittal",
        "compress-pdf-for-architects",
    ),
    "engineers": (
        "Engineers",
        "Stamped calcs",
        "Engineer protects a stamped calculation PDF, watermarks PRELIMINARY on drafts, and logs version before city review",
        "compress-pdf-for-engineers",
    ),
    "researchers": (
        "Researchers",
        "Participant data",
        "PI redacts participant identifiers from a supplementary PDF and protects the dataset before journal submission",
        "compress-pdf-for-researchers",
    ),
    "journalists": (
        "Journalists",
        "Source protection",
        "Reporter redacts source names from an FOI bundle, protects the PDF, and logs the version before editor handoff",
        "compress-pdf-for-journalists",
    ),
    "hr-teams": (
        "HR Teams",
        "Employee records",
        "HR redacts SSN from an offer PDF, password-protects compensation docs, and logs version before manager share",
        "compress-pdf-for-hr-teams",
    ),
    "sales-teams": (
        "Sales Teams",
        "Pricing control",
        "AE watermarks DRAFT on a proposal PDF, redacts internal margin notes, and protects pricing before prospect send",
        "compress-pdf-for-sales-teams",
    ),
    "marketing-teams": (
        "Marketing Teams",
        "Embargoed assets",
        "Marketer watermarks CONFIDENTIAL on an embargoed campaign PDF and protects it before partner preview",
        "compress-pdf-for-marketing-teams",
    ),
}

W58_DATA = {
    "pdf-comments-to-word": {
        "title": "Export PDF Comments to Word — Review Summary (2026)",
        "tool": "/pdf/pdftodoc",
        "label": "PDF to Word",
        "pillar": "/guides/pdf-review-workflow",
        "pillar_label": "PDF review workflow",
        "related": "/guides/pdf-client-delivery-checklist",
        "prog": "/pdf/pdftodoc",
        "example": "Editor exports all PDF sticky-note comments into a Word summary so authors can action feedback in one list",
    },
    "pdf-destruction-certificate": {
        "title": "PDF Destruction Certificate Workflow — Proof of Disposal (2026)",
        "tool": "/guides/document-retention-pdf",
        "label": "Retention guide",
        "pillar": "/guides/pdf-records-management-policy",
        "pillar_label": "records management policy",
        "related": "/guides/pdf-checksum-verify-integrity",
        "prog": "/guides/pdf-records-management-policy",
        "example": "Records team issues a signed destruction certificate logging hash, date, and approver when a PDF reaches end of retention",
    },
}

for key, (audience, use_case, example, compress_slug) in W58_SECURE_META.items():
    slug = f"secure-pdf-workflow-{key}"
    W58_DATA[slug] = {
        "title": f"Secure PDF Workflow for {audience} — Redact, Protect, Audit (2026)",
        "tool": "/pdf/redaction",
        "label": "Redact PDF",
        "pillar": "/guides/secure-pdf-workflow",
        "pillar_label": "secure PDF workflow",
        "related": f"/guides/{compress_slug}",
        "prog": "/pdf/redaction",
        "example": example,
        "audience": audience,
        "use_case": use_case,
    }


def _d(slug: str, html: str) -> str:
    p = W58_DATA[slug].get("prog", "")
    tail = f'<p>Tool: <a href="{p}">{p}</a></p>' if p else ""
    return html + tail


def _secure_deep(slug: str) -> str:
    d = W58_DATA[slug]
    return _d(
        slug,
        f"""
            <h2>Secure PDF workflow for {d['audience']}</h2>
            <p>Use case: {d['use_case']} — {d['example']}.</p>
            <ol>
            <li><a href="/pdf/redaction">Redact</a> sensitive content — flatten so hidden text cannot be recovered</li>
            <li><a href="/pdf/watermark">Watermark</a> DRAFT or CONFIDENTIAL until cleared for release</li>
            <li><a href="/pdf/password">Password-protect</a> with AES-256 — share the passphrase on a separate channel</li>
            <li>Log version and retention class before external share</li>
            </ol>
            <p><a href="{d['related']}">Compress workflow</a> · <a href="/guides/document-retention-pdf">Retention</a> · <a href="/guides/pdf-version-control-best-practices">Version control</a>.</p>
            """,
    )


W58_DEEP = {
    "pdf-comments-to-word": _d("pdf-comments-to-word", """
            <h2>Export PDF comments</h2>
            <ol>
            <li>In Acrobat: Comments panel → Options → Export to Word (or print comment summary)</li>
            <li>Browser route: <a href="/pdf/pdftodoc">PDF to Word</a> then collate margin notes</li>
            <li>Group by page and reviewer for a clean action list</li>
            <li>Send the summary alongside the marked-up PDF</li>
            </ol>
            <p><a href="/guides/pdf-review-workflow">Review workflow</a> · <a href="/guides/pdf-client-delivery-checklist">Delivery checklist</a>.</p>
            """),
    "pdf-destruction-certificate": _d("pdf-destruction-certificate", """
            <h2>Destruction certificate</h2>
            <ol>
            <li>Confirm the PDF has reached end of its retention class</li>
            <li>Check no legal hold is active — holds override destruction</li>
            <li>Record SHA-256 hash, destruction date, method, and approver</li>
            <li>Store the signed certificate in the records log (not with the deleted file)</li>
            </ol>
            <p><a href="/guides/pdf-records-management-policy">RM policy</a> · <a href="/guides/pdf-checksum-verify-integrity">Checksum integrity</a> · <a href="/guides/document-retention-pdf">Retention</a>.</p>
            """),
}

for key in W58_SECURE_META:
    W58_DEEP[f"secure-pdf-workflow-{key}"] = _secure_deep(f"secure-pdf-workflow-{key}")

W58_CREATE_CLUSTER = """
            <h2>CREATE batch 22 — secure workflow finale + records</h2>
            <ul>
            <li>Regulated: <a href="/guides/secure-pdf-workflow-healthcare">Healthcare</a> · <a href="/guides/secure-pdf-workflow-government">Government</a> · <a href="/guides/secure-pdf-workflow-insurance">Insurance</a> · <a href="/guides/secure-pdf-workflow-education">Education</a></li>
            <li>Business: <a href="/guides/secure-pdf-workflow-consultants">Consultants</a> · <a href="/guides/secure-pdf-workflow-freelancers">Freelancers</a> · <a href="/guides/secure-pdf-workflow-sales-teams">Sales</a> · <a href="/guides/secure-pdf-workflow-hr-teams">HR</a></li>
            <li>Built world: <a href="/guides/secure-pdf-workflow-architects">Architects</a> · <a href="/guides/secure-pdf-workflow-engineers">Engineers</a> · <a href="/guides/secure-pdf-workflow-real-estate">Real estate</a></li>
            <li>Knowledge: <a href="/guides/secure-pdf-workflow-researchers">Researchers</a> · <a href="/guides/secure-pdf-workflow-journalists">Journalists</a> · <a href="/guides/secure-pdf-workflow-nonprofits">Nonprofits</a> · <a href="/guides/secure-pdf-workflow-marketing-teams">Marketing</a></li>
            <li>Records: <a href="/guides/pdf-comments-to-word">Comments to Word</a> · <a href="/guides/pdf-destruction-certificate">Destruction certificate</a></li>
            </ul>
            <p>Started in <a href="/guides/secure-pdf-workflow-lawyers">Wave 57</a> (lawyers, accountants)</p>
            """

W58_SECURE_CLUSTER = """
            <h2>Secure PDF workflow hub (17 verticals)</h2>
            <p>Legal &amp; finance: <a href="/guides/secure-pdf-workflow-lawyers">Lawyers</a> · <a href="/guides/secure-pdf-workflow-accountants">Accountants</a> · <a href="/guides/secure-pdf-workflow-insurance">Insurance</a></p>
            <p>Regulated: <a href="/guides/secure-pdf-workflow-healthcare">Healthcare</a> · <a href="/guides/secure-pdf-workflow-government">Government</a> · <a href="/guides/secure-pdf-workflow-education">Education</a></p>
            <p>Teams: <a href="/guides/secure-pdf-workflow-hr-teams">HR</a> · <a href="/guides/secure-pdf-workflow-sales-teams">Sales</a> · <a href="/guides/secure-pdf-workflow-marketing-teams">Marketing</a> · <a href="/guides/secure-pdf-workflow-consultants">Consultants</a></p>
            <p>Core tools: <a href="/pdf/redaction">Redact</a> · <a href="/pdf/watermark">Watermark</a> · <a href="/pdf/password">Protect</a> · <a href="/pdf/signtext">Sign</a></p>
            """

W58_COMPRESS_TOPUP = """
            <h2>Secure-share checklist</h2>
            <ol>
            <li>Redact and flatten before any external share — hidden layers leak data</li>
            <li>Watermark DRAFT/CONFIDENTIAL until release is approved</li>
            <li>AES-256 password — never email the passphrase with the file</li>
            <li>Log version, approver, and retention class for the audit trail</li>
            </ol>
            """

W58_CLOSING = """
            <h2>Related guides</h2>
            <p>Wave 58 completes the secure-PDF-workflow vertical cluster (17/17) and adds comments-to-Word and destruction-certificate records workflows — CREATE batch 22 of 450.</p>
            <p>Hub: <a href="/guides/secure-pdf-workflow">Secure PDF workflow</a> · CREATE remaining: 76</p>
            """
