"""Wave 51 — CREATE batch 15 (17 guides, score 72). Merge-for vertical finale + device convert."""

W51_SLUGS = [
    "merge-pdf-for-insurance",
    "merge-pdf-for-education",
    "merge-pdf-for-nonprofits",
    "merge-pdf-for-government",
    "merge-pdf-for-freelancers",
    "merge-pdf-for-consultants",
    "merge-pdf-for-architects",
    "merge-pdf-for-engineers",
    "merge-pdf-for-researchers",
    "merge-pdf-for-journalists",
    "merge-pdf-for-hr-teams",
    "merge-pdf-for-sales-teams",
    "merge-pdf-for-marketing-teams",
    "convert-pdf-on-iphone",
    "convert-pdf-on-ipad",
    "convert-pdf-on-chromebook",
    "convert-pdf-on-linux",
]

MERGE_FOR_CREATE_SLUGS = {
    "merge-pdf-for-insurance",
    "merge-pdf-for-education",
    "merge-pdf-for-nonprofits",
    "merge-pdf-for-government",
    "merge-pdf-for-freelancers",
    "merge-pdf-for-consultants",
    "merge-pdf-for-architects",
    "merge-pdf-for-engineers",
    "merge-pdf-for-researchers",
    "merge-pdf-for-journalists",
    "merge-pdf-for-hr-teams",
    "merge-pdf-for-sales-teams",
    "merge-pdf-for-marketing-teams",
}

DEVICE_CREATE_SLUGS = {
    "convert-pdf-on-iphone",
    "convert-pdf-on-ipad",
    "convert-pdf-on-chromebook",
    "convert-pdf-on-linux",
}

W51_MERGE_FOR_META = {
    "insurance": (
        "Insurance",
        "Policy packs",
        "Agent merges declaration, endorsement, and ID card PDFs before client binder delivery",
        "best-browser-pdf-tools-for-insurance-agents",
    ),
    "education": (
        "Education",
        "Course packs",
        "Registrar merges syllabus, calendar, and policy PDFs for student orientation packet",
        "best-browser-pdf-tools-for-teachers",
    ),
    "nonprofits": (
        "Nonprofits",
        "Grant packs",
        "Program lead merges narrative, budget, and LOI PDFs before foundation portal upload",
        "best-browser-pdf-tools-for-nonprofits",
    ),
    "government": (
        "Government",
        "RFP volumes",
        "Contractor merges technical and cost volume PDFs in SAM submission order",
        "best-browser-pdf-tools-for-government-contractors",
    ),
    "freelancers": (
        "Freelancers",
        "Client deliverables",
        "Designer merges mockup, spec, and invoice PDFs before milestone email to client",
        "best-browser-pdf-tools-for-freelancers",
    ),
    "consultants": (
        "Consultants",
        "Engagement packs",
        "Consultant merges SOW, timeline, and case study PDFs — watermark DRAFT until sign",
        "best-browser-pdf-tools-for-consultants",
    ),
    "architects": (
        "Architects",
        "Submittal sets",
        "Architect merges drawing index, spec section, and product data PDFs for GC review",
        "best-browser-pdf-tools-for-construction-managers",
    ),
    "engineers": (
        "Engineers",
        "Spec bundles",
        "Engineer merges calculation, drawing, and test report PDFs for permit submittal",
        "best-browser-pdf-tools-for-developers",
    ),
    "researchers": (
        "Researchers",
        "Publication packs",
        "PI merges manuscript, supplementary, and ethics approval PDFs for journal upload",
        "best-browser-pdf-tools-for-researchers",
    ),
    "journalists": (
        "Journalists",
        "FOI bundles",
        "Reporter merges redacted FOI pages and source exhibit PDFs for editor review",
        "best-browser-pdf-tools-for-journalists",
    ),
    "hr-teams": (
        "HR Teams",
        "Onboarding packs",
        "HR merges offer letter, benefits, and policy PDFs before new hire day-one packet",
        "best-browser-pdf-tools-for-hr-teams",
    ),
    "sales-teams": (
        "Sales Teams",
        "Proposal packs",
        "AE merges quote, case study, and security FAQ PDFs before enterprise prospect send",
        "best-browser-pdf-tools-for-consultants",
    ),
    "marketing-teams": (
        "Marketing Teams",
        "Campaign packs",
        "PM merges creative brief, media plan, and brand PDFs for stakeholder sign-off",
        "best-browser-pdf-tools-for-marketers",
    ),
}

W51_DEVICE_META = {
    "iphone": (
        "iPhone",
        "Safari",
        "Sales rep converts one-page spec PDF to Word on iPhone before quick client edit",
    ),
    "ipad": (
        "iPad",
        "Safari",
        "Teacher converts scanned worksheet PDF to Word on iPad for classroom edit in Split View",
    ),
    "chromebook": (
        "Chromebook",
        "Chrome",
        "Student converts chapter PDF to DOCX on school Chromebook for essay quotes",
    ),
    "linux": (
        "Linux",
        "Firefox",
        "Analyst converts report PDF to Word on Ubuntu workstation without desktop Acrobat",
    ),
}

W51_DATA = {}

for vertical, (audience, pack_type, example, persona_slug) in W51_MERGE_FOR_META.items():
    slug = f"merge-pdf-for-{vertical}"
    W51_DATA[slug] = {
        "title": f"Merge PDF for {audience} — {pack_type} Workflow (2026)",
        "tool": "/pdf/merge",
        "label": "Merge PDF",
        "pillar": "/guides/merge-pdf",
        "pillar_label": "merge PDF guide",
        "related": f"/guides/{persona_slug}",
        "prog": "/pdf/merge",
        "example": example,
        "audience": audience,
        "pack_type": pack_type,
    }

for device, (name, browser, example) in W51_DEVICE_META.items():
    slug = f"convert-pdf-on-{device}"
    W51_DATA[slug] = {
        "title": f"Convert PDF on {name} — {browser} Workflow (2026)",
        "tool": "/pdf/pdftodoc",
        "label": "PDF to Word",
        "pillar": "/guides/pdf-to-word-on-mac",
        "pillar_label": "PDF to Word on Mac (reference)",
        "related": "/guides/convert-pdf-on-android",
        "prog": "/pdf/pdftodoc",
        "example": example,
        "device": name,
        "browser": browser,
    }


def _d(slug: str, html: str) -> str:
    p = W51_DATA[slug].get("prog", "")
    tail = f'<p>Tool: <a href="{p}">{p}</a></p>' if p else ""
    return html + tail


def _merge_for_deep(slug: str) -> str:
    d = W51_DATA[slug]
    return _d(
        slug,
        f"""
            <h2>Merge PDF for {d['audience']}</h2>
            <p>Typical pack: {d['pack_type']} — {d['example']}.</p>
            <ol>
            <li>Numeric filename prefixes — <code>01_</code>, <code>02_</code></li>
            <li><a href="/pdf/merge">Merge</a> in delivery order</li>
            <li><a href="/pdf/watermark">Watermark</a> DRAFT if pre-approval</li>
            <li><a href="/pdf/compress">Compress</a> if email or portal cap</li>
            </ol>
            <p><a href="/guides/merge-pdf">Merge hub</a> · Wave 50 verticals: <a href="/guides/merge-pdf-for-lawyers">lawyers</a> · <a href="/guides/merge-pdf-for-accountants">accountants</a>.</p>
            """,
    )


def _device_deep(slug: str) -> str:
    d = W51_DATA[slug]
    return _d(
        slug,
        f"""
            <h2>Convert PDF on {d['device']}</h2>
            <p>Browser: {d['browser']} — PDF to Word without app install.</p>
            <ol>
            <li>Scanned PDF? — <a href="/pdf/ocrpdf">OCR</a> first</li>
            <li>Open {d['browser']} → <a href="/pdf/pdftodoc">PDF to Word</a></li>
            <li>Upload from Files/Downloads — download DOCX</li>
            <li>Edit in Word, Google Docs, or LibreOffice</li>
            </ol>
            <p>Hub: <a href="/guides/pdf-device-workflows-hub">device workflows</a> · <a href="/guides/pdf-to-word">PDF to Word</a>.</p>
            """,
    )


W51_DEEP = {}

for vertical in W51_MERGE_FOR_META:
    W51_DEEP[f"merge-pdf-for-{vertical}"] = _merge_for_deep(f"merge-pdf-for-{vertical}")

for device in W51_DEVICE_META:
    W51_DEEP[f"convert-pdf-on-{device}"] = _device_deep(f"convert-pdf-on-{device}")

W51_CREATE_CLUSTER = """
            <h2>CREATE batch 15</h2>
            <ul>
            <li>Merge verticals: <a href="/guides/merge-pdf-for-insurance">Insurance</a> · <a href="/guides/merge-pdf-for-education">Education</a> · <a href="/guides/merge-pdf-for-government">Government</a> · <a href="/guides/merge-pdf-for-engineers">Engineers</a> · <a href="/guides/merge-pdf-for-marketing-teams">Marketing</a> — <strong>17/17 vertical cluster complete</strong></li>
            <li>Device convert: <a href="/guides/convert-pdf-on-iphone">iPhone</a> · <a href="/guides/convert-pdf-on-ipad">iPad</a> · <a href="/guides/convert-pdf-on-chromebook">Chromebook</a> · <a href="/guides/convert-pdf-on-linux">Linux</a></li>
            </ul>
            <p>Prior: <a href="/guides/merge-pdf-for-lawyers">Wave 50 merge verticals</a> · <a href="/guides/merge-pdf-on-iphone">Wave 47 merge devices</a></p>
            """

W51_MERGE_FOR_CLUSTER = """
            <h2>Merge-for vertical index (17 industries)</h2>
            <p>Legal &amp; finance: <a href="/guides/merge-pdf-for-lawyers">Lawyers</a> · <a href="/guides/merge-pdf-for-accountants">Accountants</a> · <a href="/guides/merge-pdf-for-insurance">Insurance</a> · <a href="/guides/merge-pdf-for-real-estate">Real estate</a></p>
            <p>Public &amp; org: <a href="/guides/merge-pdf-for-government">Government</a> · <a href="/guides/merge-pdf-for-nonprofits">Nonprofits</a> · <a href="/guides/merge-pdf-for-education">Education</a> · <a href="/guides/merge-pdf-for-healthcare">Healthcare</a></p>
            <p>Professional: <a href="/guides/merge-pdf-for-consultants">Consultants</a> · <a href="/guides/merge-pdf-for-freelancers">Freelancers</a> · <a href="/guides/merge-pdf-for-architects">Architects</a> · <a href="/guides/merge-pdf-for-engineers">Engineers</a></p>
            <p>Content &amp; people: <a href="/guides/merge-pdf-for-researchers">Researchers</a> · <a href="/guides/merge-pdf-for-journalists">Journalists</a> · <a href="/guides/merge-pdf-for-hr-teams">HR</a> · <a href="/guides/merge-pdf-for-sales-teams">Sales</a> · <a href="/guides/merge-pdf-for-marketing-teams">Marketing</a></p>
            """

W51_DEVICE_CLUSTER = """
            <h2>Wave 51 device convert hubs</h2>
            <p>Mobile: <a href="/guides/convert-pdf-on-iphone">iPhone</a> · <a href="/guides/convert-pdf-on-ipad">iPad</a> · <a href="/guides/convert-pdf-on-android">Android</a></p>
            <p>Desktop: <a href="/guides/convert-pdf-on-mac">Mac</a> · <a href="/guides/convert-pdf-on-windows-11">Windows 11</a> · <a href="/guides/convert-pdf-on-linux">Linux</a> · <a href="/guides/convert-pdf-on-chromebook">Chromebook</a></p>
            """

W51_COMPRESS_TOPUP = """
            <h2>CREATE batch 15 checklist</h2>
            <ol>
            <li>Merge vertical: numeric prefixes before upload queue</li>
            <li>Watermark DRAFT on pre-approval client packs</li>
            <li>Convert on mobile: OCR scans before PDF to Word</li>
            <li>Compress merged pack if portal or mailbox cap</li>
            </ol>
            """

W51_CLOSING = """
            <h2>Related guides</h2>
            <p>Wave 51 completes all seventeen merge-for industry verticals and adds four device PDF-to-Word convert guides — CREATE batch 15 of 450.</p>
            <p>Hub: <a href="/guides/merge-pdf">merge PDF</a> · <a href="/guides/pdf-device-workflows-hub">device workflows</a> · CREATE remaining: 195</p>
            """
