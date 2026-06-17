"""Wave 53 — CREATE batch 17 (17 guides, score 71). Compress-for finale + device sign cluster."""

W53_SLUGS = [
    "compress-pdf-for-consultants",
    "compress-pdf-for-architects",
    "compress-pdf-for-engineers",
    "compress-pdf-for-researchers",
    "compress-pdf-for-journalists",
    "compress-pdf-for-hr-teams",
    "compress-pdf-for-sales-teams",
    "compress-pdf-for-marketing-teams",
    "sign-pdf-on-iphone",
    "sign-pdf-on-ipad",
    "sign-pdf-on-android",
    "sign-pdf-on-chromebook",
    "sign-pdf-on-linux",
    "sign-pdf-on-mac",
    "sign-pdf-on-windows-11",
    "beginner-pdf-encryption-types",
    "best-pdf-editor-for-lawyers",
]

COMPRESS_FOR_CREATE_SLUGS = {
    "compress-pdf-for-consultants",
    "compress-pdf-for-architects",
    "compress-pdf-for-engineers",
    "compress-pdf-for-researchers",
    "compress-pdf-for-journalists",
    "compress-pdf-for-hr-teams",
    "compress-pdf-for-sales-teams",
    "compress-pdf-for-marketing-teams",
}

DEVICE_CREATE_SLUGS = {
    "sign-pdf-on-iphone",
    "sign-pdf-on-ipad",
    "sign-pdf-on-android",
    "sign-pdf-on-chromebook",
    "sign-pdf-on-linux",
    "sign-pdf-on-mac",
    "sign-pdf-on-windows-11",
}

INFO_CREATE_SLUGS = {"beginner-pdf-encryption-types"}

EDITOR_CREATE_SLUGS = {"best-pdf-editor-for-lawyers"}

W53_COMPRESS_FOR_META = {
    "consultants": (
        "Consultants",
        "Client deliverable",
        "Consultant compresses 30 MB strategy deck PDF to 12 MB before client portal upload",
        "merge-pdf-for-consultants",
    ),
    "architects": (
        "Architects",
        "Submittal set",
        "Architect compresses drawing spec PDF from 45 MB to 18 MB for GC email",
        "merge-pdf-for-architects",
    ),
    "engineers": (
        "Engineers",
        "Permit submittal",
        "Engineer compresses calculation report PDF before city portal 20 MB cap",
        "merge-pdf-for-engineers",
    ),
    "researchers": (
        "Researchers",
        "Journal upload",
        "PI compresses supplementary PDF from 15 MB to 6 MB for journal system",
        "merge-pdf-for-researchers",
    ),
    "journalists": (
        "Journalists",
        "FOI bundle",
        "Reporter compresses 50 MB FOI dump PDF before editor secure share",
        "merge-pdf-for-journalists",
    ),
    "hr-teams": (
        "HR Teams",
        "Onboarding pack",
        "HR compresses benefits guide PDF from 14 MB to 6 MB for new hire email",
        "merge-pdf-for-hr-teams",
    ),
    "sales-teams": (
        "Sales Teams",
        "Proposal send",
        "AE compresses enterprise proposal PDF from 28 MB to 11 MB before prospect attach",
        "merge-pdf-for-sales-teams",
    ),
    "marketing-teams": (
        "Marketing Teams",
        "Campaign deck",
        "PM compresses creative brief PDF from 20 MB to 8 MB for stakeholder review",
        "merge-pdf-for-marketing-teams",
    ),
}

W53_DEVICE_META = {
    "iphone": ("iPhone", "Safari", "Sales rep signs NDA PDF on iPhone Safari before client meeting"),
    "ipad": ("iPad", "Safari", "Principal signs school form PDF on iPad with Apple Pencil-style typed block"),
    "android": ("Android", "Chrome", "Contractor signs change order PDF on Android Chrome in field"),
    "chromebook": ("Chromebook", "Chrome", "Student signs permission slip PDF on school Chromebook"),
    "linux": ("Linux", "Firefox", "Remote worker signs offer letter PDF on Ubuntu Firefox"),
    "mac": ("Mac", "Safari", "Founder signs investor SAFE PDF in Safari without Acrobat install"),
    "windows-11": ("Windows 11", "Edge", "Manager signs performance review PDF in Edge on corporate laptop"),
}

W53_DATA = {
    "beginner-pdf-encryption-types": {
        "title": "PDF Encryption Types Explained — Password &amp; Certificate (2026)",
        "tool": "/pdf/password",
        "label": "Protect PDF",
        "pillar": "/guides/pdf-password-best-practices",
        "pillar_label": "password best practices",
        "related": "/guides/encrypt-pdf-aes-256",
        "prog": "/pdf/password",
        "example": "IT explains user password vs owner password — AES-256 on contract PDF before external share",
    },
    "best-pdf-editor-for-lawyers": {
        "title": "Best PDF Editor for Lawyers — Browser vs Desktop (2026)",
        "tool": "/pdf/editpdf",
        "label": "Edit PDF",
        "pillar": "/guides/browser-vs-desktop-pdf-tools",
        "pillar_label": "browser vs desktop",
        "related": "/guides/best-browser-pdf-tools-for-lawyers",
        "prog": "/pdf/editpdf",
        "example": "Boutique firm picks browser merge/redact for occasional edits — Acrobat on litigation lead machine only",
    },
}

for vertical, (audience, use_case, example, merge_slug) in W53_COMPRESS_FOR_META.items():
    slug = f"compress-pdf-for-{vertical}"
    W53_DATA[slug] = {
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

for device, (name, browser, example) in W53_DEVICE_META.items():
    slug = f"sign-pdf-on-{device}"
    W53_DATA[slug] = {
        "title": f"Sign PDF on {name} — {browser} Workflow (2026)",
        "tool": "/pdf/signtext",
        "label": "Sign PDF",
        "pillar": "/guides/how-to-sign-a-pdf",
        "pillar_label": "how to sign a PDF",
        "related": "/guides/sign-pdf-legally",
        "prog": "/pdf/signtext",
        "example": example,
        "device": name,
        "browser": browser,
    }


def _d(slug: str, html: str) -> str:
    p = W53_DATA[slug].get("prog", "")
    tail = f'<p>Tool: <a href="{p}">{p}</a></p>' if p else ""
    return html + tail


def _compress_for_deep(slug: str) -> str:
    d = W53_DATA[slug]
    return _d(
        slug,
        f"""
            <h2>Compress PDF for {d['audience']}</h2>
            <p>Use case: {d['use_case']} — {d['example']}.</p>
            <ol>
            <li>Confirm email or portal size cap</li>
            <li><a href="/pdf/compress">Compress</a> — Medium preset first</li>
            <li>Verify readability — do not over-compress text tables</li>
            <li>Archive uncompressed master in matter folder</li>
            </ol>
            <p>Pair with <a href="{d['related']}">merge workflow</a> — <strong>17/17 compress-for complete</strong>.</p>
            """,
    )


def _device_deep(slug: str) -> str:
    d = W53_DATA[slug]
    return _d(
        slug,
        f"""
            <h2>Sign PDF on {d['device']}</h2>
            <p>Browser: {d['browser']} — typed signature block without app install.</p>
            <ol>
            <li>Open {d['browser']} → <a href="/pdf/signtext">Sign PDF</a></li>
            <li>Upload PDF from Files/Downloads</li>
            <li>Place signature block on signature line</li>
            <li>Download signed PDF — delete from Downloads on shared devices</li>
            </ol>
            <p><a href="/guides/sign-pdf-legally">Legal context</a> · <a href="/guides/pdf-device-workflows-hub">Device hub</a>.</p>
            """,
    )


W53_DEEP = {
    "beginner-pdf-encryption-types": _d("beginner-pdf-encryption-types", """
            <h2>PDF encryption types</h2>
            <ul>
            <li><strong>User password</strong> — required to open document</li>
            <li><strong>Owner password</strong> — restricts print/copy/edit</li>
            <li><strong>AES-256</strong> — current standard for sensitive PDFs</li>
            <li><strong>Certificate</strong> — PKI and qualified signatures for legal archive</li>
            </ul>
            <p><a href="/guides/encrypt-pdf-aes-256">AES-256 guide</a> · send password on separate channel.</p>
            """),
    "best-pdf-editor-for-lawyers": _d("best-pdf-editor-for-lawyers", """
            <h2>PDF editor picks for lawyers</h2>
            <ul>
            <li>Browser: merge, redact, compress, sign — no IT install</li>
            <li>Desktop: batch Bates, advanced redaction audit, air-gapped matters</li>
            <li>Hybrid: browser for routine — Acrobat on lead lit machine</li>
            <li>Evaluate retention policy before uploading privileged PDFs</li>
            </ul>
            <p><a href="/guides/best-browser-pdf-tools-for-lawyers">Browser tools for lawyers</a>.</p>
            """),
}

for vertical in W53_COMPRESS_FOR_META:
    W53_DEEP[f"compress-pdf-for-{vertical}"] = _compress_for_deep(f"compress-pdf-for-{vertical}")

for device in W53_DEVICE_META:
    W53_DEEP[f"sign-pdf-on-{device}"] = _device_deep(f"sign-pdf-on-{device}")

W53_CREATE_CLUSTER = """
            <h2>CREATE batch 17</h2>
            <ul>
            <li>Compress verticals finale (8): <a href="/guides/compress-pdf-for-consultants">Consultants</a> … <a href="/guides/compress-pdf-for-marketing-teams">Marketing</a> — <strong>17/17 complete</strong></li>
            <li>Device sign (7): <a href="/guides/sign-pdf-on-iphone">iPhone</a> · <a href="/guides/sign-pdf-on-ipad">iPad</a> · <a href="/guides/sign-pdf-on-mac">Mac</a> · <a href="/guides/sign-pdf-on-windows-11">Windows 11</a> …</li>
            <li>Security &amp; editor: <a href="/guides/beginner-pdf-encryption-types">Encryption types</a> · <a href="/guides/best-pdf-editor-for-lawyers">Editor for lawyers</a></li>
            </ul>
            <p>Prior compress batch: <a href="/guides/compress-pdf-for-lawyers">Wave 52</a></p>
            """

W53_COMPRESS_FOR_CLUSTER = """
            <h2>Compress-for vertical index (17/17 complete)</h2>
            <p>Legal &amp; finance: <a href="/guides/compress-pdf-for-lawyers">Lawyers</a> · <a href="/guides/compress-pdf-for-accountants">Accountants</a> · <a href="/guides/compress-pdf-for-insurance">Insurance</a> · <a href="/guides/compress-pdf-for-real-estate">Real estate</a></p>
            <p>Org: <a href="/guides/compress-pdf-for-government">Government</a> · <a href="/guides/compress-pdf-for-nonprofits">Nonprofits</a> · <a href="/guides/compress-pdf-for-education">Education</a> · <a href="/guides/compress-pdf-for-healthcare">Healthcare</a></p>
            <p>Professional: <a href="/guides/compress-pdf-for-consultants">Consultants</a> · <a href="/guides/compress-pdf-for-freelancers">Freelancers</a> · <a href="/guides/compress-pdf-for-architects">Architects</a> · <a href="/guides/compress-pdf-for-engineers">Engineers</a></p>
            <p>Content &amp; people: <a href="/guides/compress-pdf-for-researchers">Researchers</a> · <a href="/guides/compress-pdf-for-journalists">Journalists</a> · <a href="/guides/compress-pdf-for-hr-teams">HR</a> · <a href="/guides/compress-pdf-for-sales-teams">Sales</a> · <a href="/guides/compress-pdf-for-marketing-teams">Marketing</a></p>
            """

W53_DEVICE_CLUSTER = """
            <h2>Wave 53 device sign hubs (7)</h2>
            <p>Mobile: <a href="/guides/sign-pdf-on-iphone">iPhone</a> · <a href="/guides/sign-pdf-on-ipad">iPad</a> · <a href="/guides/sign-pdf-on-android">Android</a></p>
            <p>Desktop: <a href="/guides/sign-pdf-on-mac">Mac</a> · <a href="/guides/sign-pdf-on-windows-11">Windows 11</a> · <a href="/guides/sign-pdf-on-linux">Linux</a> · <a href="/guides/sign-pdf-on-chromebook">Chromebook</a></p>
            """

W53_COMPRESS_TOPUP = """
            <h2>CREATE batch 17 checklist</h2>
            <ol>
            <li>Compress-for cluster 17/17 — pair with merge-for vertical</li>
            <li>Sign on mobile: clear Downloads after sensitive PDF</li>
            <li>Typed signature — not a substitute for qualified e-sign on all matters</li>
            <li>AES-256 for confidential PDFs — password separate channel</li>
            </ol>
            """

W53_CLOSING = """
            <h2>Related guides</h2>
            <p>Wave 53 completes all seventeen compress-for industry verticals, launches seven device sign guides, and adds encryption primer plus lawyer editor comparison — CREATE batch 17 of 450.</p>
            <p>Hub: <a href="/guides/compress-pdf-guide">compress PDF</a> · <a href="/guides/how-to-sign-a-pdf">sign PDF</a> · CREATE remaining: 161</p>
            """
