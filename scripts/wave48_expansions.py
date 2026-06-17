"""Wave 48 — CREATE batch 12 (17 guides, score 74). Persona browser PDF tools cluster part 2."""

W48_SLUGS = [
    "best-browser-pdf-tools-for-developers",
    "best-browser-pdf-tools-for-ecommerce-sellers",
    "best-browser-pdf-tools-for-event-planners",
    "best-browser-pdf-tools-for-freelancers",
    "best-browser-pdf-tools-for-government-contractors",
    "best-browser-pdf-tools-for-healthcare-administrators",
    "best-browser-pdf-tools-for-hr-teams",
    "best-browser-pdf-tools-for-insurance-agents",
    "best-browser-pdf-tools-for-journalists",
    "best-browser-pdf-tools-for-lawyers",
    "best-browser-pdf-tools-for-librarians",
    "best-browser-pdf-tools-for-marketers",
    "best-browser-pdf-tools-for-nonprofits",
    "best-browser-pdf-tools-for-paralegals",
    "best-browser-pdf-tools-for-photographers",
    "best-browser-pdf-tools-for-real-estate-agents",
    "best-browser-pdf-tools-for-recruiters",
]

PERSONA_CREATE_SLUGS = set(W48_SLUGS)

W48_PERSONA_META = {
    "developers": (
        "Developers",
        "Merge API doc PDFs, compress release-note bundles, and split oversized log exports before ticket attach",
        "/pdf/merge",
        "Merge PDF",
    ),
    "ecommerce-sellers": (
        "E-Commerce Sellers",
        "Compress product spec PDFs, merge supplier invoices, and watermark wholesale catalog drafts",
        "/pdf/compress",
        "Compress PDF",
    ),
    "event-planners": (
        "Event Planners",
        "Merge vendor contract PDFs, compress floor-plan scans, and split day-of run sheets for crew email",
        "/pdf/merge",
        "Merge PDF",
    ),
    "freelancers": (
        "Freelancers",
        "Watermark proposal PDFs, merge portfolio samples, and compress deliverables under client mailbox caps",
        "/pdf/watermark",
        "Watermark PDF",
    ),
    "government-contractors": (
        "Government Contractors",
        "Redact CUI from draft PDFs, merge proposal volumes in order, and compress before SAM portal upload",
        "/pdf/redaction",
        "Redact PDF",
    ),
    "healthcare-administrators": (
        "Healthcare Administrators",
        "Redact PHI from disclosure PDFs, merge policy packs, and compress portal uploads per BAA policy",
        "/pdf/redaction",
        "Redact PDF",
    ),
    "hr-teams": (
        "HR Teams",
        "Merge onboarding PDF packs, watermark offer letters DRAFT, and password-protect compensation attachments",
        "/pdf/merge",
        "Merge PDF",
    ),
    "insurance-agents": (
        "Insurance Agents",
        "Merge policy declaration PDFs, compress claims photo scans, and flatten signed application forms",
        "/pdf/merge",
        "Merge PDF",
    ),
    "journalists": (
        "Journalists",
        "Redact confidential sources in FOI bundles, compress exhibit PDFs, and merge document dumps for review",
        "/pdf/redaction",
        "Redact PDF",
    ),
    "lawyers": (
        "Lawyers",
        "Redact privileged passages, merge exhibit PDFs in filing order, and watermark negotiation drafts",
        "/pdf/redaction",
        "Redact PDF",
    ),
    "librarians": (
        "Librarians",
        "OCR donated scan PDFs, export PDF/A access copies, and compress reading-room handouts",
        "/pdf/ocrpdf",
        "OCR PDF",
    ),
    "marketers": (
        "Marketers",
        "Compress campaign PDF decks, flatten creative proofs, and merge brand guideline annexes",
        "/pdf/compress",
        "Compress PDF",
    ),
    "nonprofits": (
        "Nonprofits",
        "Merge grant application PDFs, compress annual report scans, and publish accessible donor PDFs",
        "/pdf/merge",
        "Merge PDF",
    ),
    "paralegals": (
        "Paralegals",
        "Redact PII from discovery PDFs, merge Bates-numbered sets, and compress production volumes",
        "/pdf/redaction",
        "Redact PDF",
    ),
    "photographers": (
        "Photographers",
        "Compress portfolio PDF proofs, flatten layered lookbooks, and merge client delivery packages",
        "/pdf/compress",
        "Compress PDF",
    ),
    "real-estate-agents": (
        "Real Estate Agents",
        "Merge disclosure PDF packs, compress MLS email attachments, and watermark listing drafts",
        "/pdf/merge",
        "Merge PDF",
    ),
    "recruiters": (
        "Recruiters",
        "Compress candidate resume PDFs, merge interview packet annexes, and redact salary history before share",
        "/pdf/compress",
        "Compress PDF",
    ),
}

W48_DATA = {}

for persona, (title, example, tool, label) in W48_PERSONA_META.items():
    slug = f"best-browser-pdf-tools-for-{persona}"
    W48_DATA[slug] = {
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
    p = W48_DATA[slug].get("prog", "")
    tail = f'<p>Tool: <a href="{p}">{p}</a></p>' if p else ""
    return html + tail


def _persona_deep(slug: str) -> str:
    d = W48_DATA[slug]
    return _d(
        slug,
        f"""
            <h2>Browser PDF toolkit for {d['persona']}</h2>
            <p>Typical tasks: {d['example']}.</p>
            <ul>
            <li><a href="/pdf/merge">Merge</a> — ordered multi-file packs</li>
            <li><a href="/pdf/compress">Compress</a> — email and portal size caps</li>
            <li><a href="/pdf/redaction">Redact</a> — permanent removal before external send</li>
            <li><a href="/pdf/password">Protect</a> — password on sensitive attachments</li>
            </ul>
            <p><a href="/guides/browser-vs-desktop-pdf-tools">Browser vs desktop</a> · <a href="/compare">Compare vendors</a> · <a href="/guides/pdf-tool-security-comparison">Security comparison</a>.</p>
            """,
    )


W48_DEEP = {slug: _persona_deep(slug) for slug in W48_SLUGS}

W48_CREATE_CLUSTER = """
            <h2>CREATE batch 12 — persona guides</h2>
            <ul>
            <li>Tech &amp; commerce: <a href="/guides/best-browser-pdf-tools-for-developers">Developers</a> · <a href="/guides/best-browser-pdf-tools-for-ecommerce-sellers">E-commerce</a> · <a href="/guides/best-browser-pdf-tools-for-freelancers">Freelancers</a> · <a href="/guides/best-browser-pdf-tools-for-startups">Startups (next batch)</a></li>
            <li>Professional services: <a href="/guides/best-browser-pdf-tools-for-lawyers">Lawyers</a> · <a href="/guides/best-browser-pdf-tools-for-paralegals">Paralegals</a> · <a href="/guides/best-browser-pdf-tools-for-consultants">Consultants</a> · <a href="/guides/best-browser-pdf-tools-for-government-contractors">Gov contractors</a></li>
            <li>People ops: <a href="/guides/best-browser-pdf-tools-for-hr-teams">HR</a> · <a href="/guides/best-browser-pdf-tools-for-recruiters">Recruiters</a> · <a href="/guides/best-browser-pdf-tools-for-insurance-agents">Insurance</a></li>
            <li>Creative &amp; media: <a href="/guides/best-browser-pdf-tools-for-marketers">Marketers</a> · <a href="/guides/best-browser-pdf-tools-for-journalists">Journalists</a> · <a href="/guides/best-browser-pdf-tools-for-photographers">Photographers</a> · <a href="/guides/best-browser-pdf-tools-for-designers">Designers</a></li>
            <li>Community &amp; records: <a href="/guides/best-browser-pdf-tools-for-nonprofits">Nonprofits</a> · <a href="/guides/best-browser-pdf-tools-for-librarians">Librarians</a> · <a href="/guides/best-browser-pdf-tools-for-archivists">Archivists</a></li>
            <li>Property &amp; events: <a href="/guides/best-browser-pdf-tools-for-real-estate-agents">Real estate</a> · <a href="/guides/best-browser-pdf-tools-for-event-planners">Event planners</a> · <a href="/guides/best-browser-pdf-tools-for-construction-managers">Construction</a></li>
            <li>Regulated: <a href="/guides/best-browser-pdf-tools-for-healthcare-administrators">Healthcare admins</a></li>
            </ul>
            <p>Prior persona batch: <a href="/guides/best-browser-pdf-tools-for-accountants">Wave 47 accountants–designers</a></p>
            """

W48_PERSONA_CLUSTER = """
            <h2>Wave 48 persona hub (part 2)</h2>
            <p>Legal: <a href="/guides/best-browser-pdf-tools-for-lawyers">Lawyers</a> · <a href="/guides/best-browser-pdf-tools-for-paralegals">Paralegals</a> · <a href="/guides/best-browser-pdf-tools-for-government-contractors">Gov contractors</a></p>
            <p>People: <a href="/guides/best-browser-pdf-tools-for-hr-teams">HR</a> · <a href="/guides/best-browser-pdf-tools-for-recruiters">Recruiters</a> · <a href="/guides/best-browser-pdf-tools-for-insurance-agents">Insurance</a> · <a href="/guides/best-browser-pdf-tools-for-healthcare-administrators">Healthcare</a></p>
            <p>Creative: <a href="/guides/best-browser-pdf-tools-for-marketers">Marketers</a> · <a href="/guides/best-browser-pdf-tools-for-journalists">Journalists</a> · <a href="/guides/best-browser-pdf-tools-for-photographers">Photographers</a> · <a href="/guides/best-browser-pdf-tools-for-event-planners">Event planners</a></p>
            <p>Remaining personas: <a href="/guides/best-browser-pdf-tools-for-remote-teams">Remote teams</a> · <a href="/guides/best-browser-pdf-tools-for-students">Students</a> · <a href="/guides/best-browser-pdf-tools-for-teachers">Teachers</a> — Wave 49</p>
            """

W48_COMPRESS_TOPUP = """
            <h2>Persona toolkit checklist</h2>
            <ol>
            <li>Pick browser tool when IT blocks desktop installs</li>
            <li>Redact PHI/PII/CUI before external email — not black boxes</li>
            <li>Compress after merge if portal or mailbox cap</li>
            <li>Verify vendor retention policy for regulated PDFs</li>
            </ol>
            """

W48_CLOSING = """
            <h2>Related guides</h2>
            <p>Wave 48 completes seventeen persona-specific browser PDF tool guides — developers through recruiters — CREATE batch 12 of 450.</p>
            <p>Hub: <a href="/guides/choose-pdf-tool">buyer guide</a> · <a href="/guides/browser-vs-desktop-pdf-tools">browser vs desktop</a> · CREATE remaining: 246</p>
            """
