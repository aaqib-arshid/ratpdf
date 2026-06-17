"""Wave 56 — CREATE batch 20 (17 guides, score 70). OCR finale + device OCR + compressor personas."""

W56_SLUGS = [
    "ocr-pdf-for-hr-teams",
    "ocr-pdf-for-sales-teams",
    "ocr-pdf-for-marketing-teams",
    "pdf-error-linearization",
    "ocr-pdf-on-iphone",
    "ocr-pdf-on-ipad",
    "ocr-pdf-on-android",
    "ocr-pdf-on-chromebook",
    "ocr-pdf-on-linux",
    "ocr-pdf-on-mac",
    "ocr-pdf-on-windows-11",
    "best-pdf-compressor-for-lawyers",
    "best-pdf-compressor-for-students",
    "best-pdf-compressor-for-accountants",
    "best-pdf-compressor-for-teachers",
    "best-pdf-compressor-for-freelancers",
    "best-pdf-compressor-for-small-business",
]

OCR_FOR_CREATE_SLUGS = {
    "ocr-pdf-for-hr-teams",
    "ocr-pdf-for-sales-teams",
    "ocr-pdf-for-marketing-teams",
}

TROUBLESHOOT_CREATE_SLUGS = {"pdf-error-linearization"}

DEVICE_OCR_CREATE_SLUGS = {
    "ocr-pdf-on-iphone",
    "ocr-pdf-on-ipad",
    "ocr-pdf-on-android",
    "ocr-pdf-on-chromebook",
    "ocr-pdf-on-linux",
    "ocr-pdf-on-mac",
    "ocr-pdf-on-windows-11",
}

COMPRESSOR_CREATE_SLUGS = {
    "best-pdf-compressor-for-lawyers",
    "best-pdf-compressor-for-students",
    "best-pdf-compressor-for-accountants",
    "best-pdf-compressor-for-teachers",
    "best-pdf-compressor-for-freelancers",
    "best-pdf-compressor-for-small-business",
}

W56_OCR_FOR_META = {
    "hr-teams": (
        "HR Teams",
        "Onboarding pack",
        "HR OCRs scanned I-9 PDF so compliance can search employee names without re-keying",
        "compress-pdf-for-hr-teams",
        "merge-pdf-for-hr-teams",
    ),
    "sales-teams": (
        "Sales Teams",
        "Proposal archive",
        "AE OCRs legacy proposal scan PDF so team can search pricing terms before renewal",
        "compress-pdf-for-sales-teams",
        "merge-pdf-for-sales-teams",
    ),
    "marketing-teams": (
        "Marketing Teams",
        "Brand guidelines",
        "Marketer OCRs old brand guidelines scan PDF so team searches logo usage rules",
        "compress-pdf-for-marketing-teams",
        "merge-pdf-for-marketing-teams",
    ),
}

W56_DEVICE_OCR_META = {
    "iphone": ("iPhone", "Safari", "Field rep OCRs receipt scan PDF on iPhone Safari before expense report"),
    "ipad": ("iPad", "Safari", "Teacher OCRs worksheet scan on iPad Safari for searchable classroom pack"),
    "android": ("Android", "Chrome", "Contractor OCRs site photo log scan on Android Chrome in field"),
    "chromebook": ("Chromebook", "Chrome", "Student OCRs handout scan on school Chromebook before study"),
    "linux": ("Linux", "Firefox", "Dev OCRs legacy API doc scan on Ubuntu Firefox for wiki search"),
    "mac": ("Mac", "Safari", "Designer OCRs client proof scan in Safari without desktop OCR license"),
    "windows-11": ("Windows 11", "Edge", "Analyst OCRs scanned quarterly report in Edge on corporate laptop"),
}

W56_COMPRESSOR_META = {
    "lawyers": (
        "Lawyers",
        "Paralegal compresses 80 MB discovery PDF to 15 MB before secure file share to co-counsel",
        "best-browser-pdf-tools-for-lawyers",
        "compress-pdf-for-lawyers",
    ),
    "students": (
        "Students",
        "Student compresses 25 MB textbook scan PDF to 10 MB before LMS upload cap",
        "best-browser-pdf-tools-for-students",
        "compress-pdf-for-students",
    ),
    "accountants": (
        "Accountants",
        "Staff compresses scanned receipt bundle from 12 MB to 4 MB before partner review email",
        "best-browser-pdf-tools-for-accountants",
        "compress-pdf-for-accountants",
    ),
    "teachers": (
        "Teachers",
        "Instructor compresses reading PDF from 25 MB to 10 MB for Canvas course module",
        "best-browser-pdf-tools-for-teachers",
        "compress-pdf-for-education",
    ),
    "freelancers": (
        "Freelancers",
        "Designer compresses portfolio PDF from 22 MB to 9 MB before client Gmail attach",
        "best-browser-pdf-tools-for-freelancers",
        "compress-pdf-for-freelancers",
    ),
    "small-business": (
        "Small Business",
        "Owner compresses invoice and contract pack from 18 MB to 8 MB before client portal upload",
        "best-browser-pdf-tools-for-small-business",
        "compress-pdf-for-small-business",
    ),
}

W56_DATA = {
    "pdf-error-linearization": {
        "title": "PDF Linearization Failed — Fix Fast Web View (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/glossary-linearization",
        "pillar_label": "linearization glossary",
        "related": "/guides/compress-pdf-guide",
        "prog": "/pdf/compress",
        "example": "DevOps sees linearization failed on 200 MB manual PDF on CDN — re-export with Fast Web View before re-upload",
    },
}

for key, (audience, use_case, example, compress_slug, merge_slug) in W56_OCR_FOR_META.items():
    slug = f"ocr-pdf-for-{key}"
    W56_DATA[slug] = {
        "title": f"OCR PDF for {audience} — Searchable Scans (2026)",
        "tool": "/pdf/ocrpdf",
        "label": "OCR PDF",
        "pillar": "/guides/ocr-pdf",
        "pillar_label": "OCR PDF guide",
        "related": f"/guides/{compress_slug}",
        "prog": "/pdf/ocrpdf",
        "example": example,
        "audience": audience,
        "use_case": use_case,
        "merge_related": f"/guides/{merge_slug}",
    }

for device, (name, browser, example) in W56_DEVICE_OCR_META.items():
    slug = f"ocr-pdf-on-{device}"
    W56_DATA[slug] = {
        "title": f"OCR PDF on {name} — {browser} Workflow (2026)",
        "tool": "/pdf/ocrpdf",
        "label": "OCR PDF",
        "pillar": "/guides/ocr-pdf",
        "pillar_label": "OCR PDF guide",
        "related": "/guides/pdf-device-workflows-hub",
        "prog": "/pdf/ocrpdf",
        "example": example,
        "device": name,
        "browser": browser,
    }

for key, (audience, example, persona_slug, compress_slug) in W56_COMPRESSOR_META.items():
    slug = f"best-pdf-compressor-for-{key}"
    W56_DATA[slug] = {
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


def _d(slug: str, html: str) -> str:
    p = W56_DATA[slug].get("prog", "")
    tail = f'<p>Tool: <a href="{p}">{p}</a></p>' if p else ""
    return html + tail


def _ocr_for_deep(slug: str) -> str:
    d = W56_DATA[slug]
    return _d(
        slug,
        f"""
            <h2>OCR PDF for {d['audience']}</h2>
            <p>Use case: {d['use_case']} — {d['example']}.</p>
            <ol>
            <li>Confirm scan is image-only — text does not select</li>
            <li><a href="/pdf/ocrpdf">OCR PDF</a> — match language to source</li>
            <li>Spot-check names and numbers on 3 pages</li>
            <li>Redact sensitive fields before external share</li>
            </ol>
            <p>Pair with <a href="{d['related']}">compress workflow</a> · <a href="{d['merge_related']}">merge workflow</a> — <strong>17/17 OCR-for complete</strong>.</p>
            """,
    )


def _device_ocr_deep(slug: str) -> str:
    d = W56_DATA[slug]
    return _d(
        slug,
        f"""
            <h2>OCR PDF on {d['device']}</h2>
            <p>Browser: {d['browser']} — no app install required.</p>
            <ol>
            <li>Open {d['browser']} → <a href="/pdf/ocrpdf">OCR PDF</a></li>
            <li>Upload scan from Files/Downloads</li>
            <li>Choose OCR language — wait for text layer</li>
            <li>Download searchable PDF — delete from Downloads on shared devices</li>
            </ol>
            <p><a href="/guides/ocr-pdf-on-phone">OCR on phone hub</a> · <a href="/guides/pdf-device-workflows-hub">Device hub</a>.</p>
            """,
    )


def _compressor_deep(slug: str) -> str:
    d = W56_DATA[slug]
    return _d(
        slug,
        f"""
            <h2>PDF compressor picks for {d['audience']}</h2>
            <p>Typical workflow: {d['example']}.</p>
            <ul>
            <li><a href="/pdf/compress">Compress PDF</a> — Medium preset first</li>
            <li><a href="/pdf/merge">Merge</a> before compress when bundling scans</li>
            <li><a href="/pdf/ocrpdf">OCR</a> scanned docs before compress if search needed</li>
            <li>Desktop Ghostscript batch when IT allows local installs</li>
            </ul>
            <p><a href="{d['related']}">Browser tools guide</a> · <a href="{d['compress_related']}">Vertical compress guide</a> · <a href="/compare">Compare vendors</a>.</p>
            """,
    )


W56_DEEP = {
    "pdf-error-linearization": _d("pdf-error-linearization", """
            <h2>Fix linearization / Fast Web View</h2>
            <ol>
            <li>Check File → Properties → Fast Web View: Yes in Acrobat</li>
            <li>Re-save with linearization enabled — not all tools preserve it</li>
            <li>Large scans may fail linearization — compress copy for web, keep master archival</li>
            <li>CDN cache may serve old non-linearized file — purge after re-upload</li>
            </ol>
            <p><a href="/guides/glossary-linearization">Linearization glossary</a> · <a href="/guides/compress-pdf-guide">Compress guide</a>.</p>
            """),
}

for key in W56_OCR_FOR_META:
    W56_DEEP[f"ocr-pdf-for-{key}"] = _ocr_for_deep(f"ocr-pdf-for-{key}")

for device in W56_DEVICE_OCR_META:
    W56_DEEP[f"ocr-pdf-on-{device}"] = _device_ocr_deep(f"ocr-pdf-on-{device}")

for key in W56_COMPRESSOR_META:
    W56_DEEP[f"best-pdf-compressor-for-{key}"] = _compressor_deep(f"best-pdf-compressor-for-{key}")

W56_CREATE_CLUSTER = """
            <h2>CREATE batch 20 — OCR finale, device OCR, compressor personas</h2>
            <ul>
            <li>OCR vertical finale: <a href="/guides/ocr-pdf-for-hr-teams">HR</a> · <a href="/guides/ocr-pdf-for-sales-teams">Sales</a> · <a href="/guides/ocr-pdf-for-marketing-teams">Marketing</a> — <strong>17/17</strong></li>
            <li>Device OCR (7): <a href="/guides/ocr-pdf-on-iphone">iPhone</a> · <a href="/guides/ocr-pdf-on-mac">Mac</a> · <a href="/guides/ocr-pdf-on-windows-11">Windows 11</a> · <a href="/guides/pdf-device-workflows-hub">Device hub</a></li>
            <li>Compressor personas (6/17): <a href="/guides/best-pdf-compressor-for-lawyers">Lawyers</a> · <a href="/guides/best-pdf-compressor-for-students">Students</a> · <a href="/guides/best-pdf-compressor-for-accountants">Accountants</a></li>
            <li>Troubleshoot: <a href="/guides/pdf-error-linearization">Linearization failed</a> · <a href="/guides/glossary-linearization">Glossary</a></li>
            </ul>
            <p>Prior OCR batch: <a href="/guides/ocr-pdf-for-lawyers">Wave 55 index</a></p>
            """

W56_OCR_CLUSTER = """
            <h2>OCR-for vertical hub (17 personas)</h2>
            <p>People ops: <a href="/guides/ocr-pdf-for-hr-teams">HR</a> · <a href="/guides/ocr-pdf-for-sales-teams">Sales</a> · <a href="/guides/ocr-pdf-for-marketing-teams">Marketing</a></p>
            <p>Legal: <a href="/guides/ocr-pdf-for-lawyers">Lawyers</a> · <a href="/guides/ocr-pdf-for-insurance">Insurance</a> · <a href="/guides/ocr-pdf-for-government">Government</a></p>
            <p>Built world: <a href="/guides/ocr-pdf-for-architects">Architects</a> · <a href="/guides/ocr-pdf-for-engineers">Engineers</a> · <a href="/guides/ocr-pdf-for-real-estate">Real estate</a></p>
            """

W56_DEVICE_CLUSTER = """
            <h2>OCR on every device (7 platforms)</h2>
            <p>Mobile: <a href="/guides/ocr-pdf-on-iphone">iPhone</a> · <a href="/guides/ocr-pdf-on-ipad">iPad</a> · <a href="/guides/ocr-pdf-on-android">Android</a></p>
            <p>Desktop: <a href="/guides/ocr-pdf-on-mac">Mac</a> · <a href="/guides/ocr-pdf-on-windows-11">Windows 11</a> · <a href="/guides/ocr-pdf-on-linux">Linux</a> · <a href="/guides/ocr-pdf-on-chromebook">Chromebook</a></p>
            """

W56_COMPRESSOR_CLUSTER = """
            <h2>Best PDF compressor hub (6 personas — Wave 56)</h2>
            <p>Professional: <a href="/guides/best-pdf-compressor-for-lawyers">Lawyers</a> · <a href="/guides/best-pdf-compressor-for-accountants">Accountants</a> · <a href="/guides/best-pdf-compressor-for-teachers">Teachers</a></p>
            <p>Independent: <a href="/guides/best-pdf-compressor-for-students">Students</a> · <a href="/guides/best-pdf-compressor-for-freelancers">Freelancers</a> · <a href="/guides/best-pdf-compressor-for-small-business">Small business</a></p>
            """

W56_COMPRESS_TOPUP = """
            <h2>Device OCR &amp; compressor checklist</h2>
            <ol>
            <li>OCR on Wi-Fi for large scans — cellular may timeout</li>
            <li>Compress after OCR when upload cap requires — not before</li>
            <li>Browser compressor when IT blocks desktop Ghostscript</li>
            <li>Spot-check searchable text on 3 pages before client send</li>
            </ol>
            """

W56_CLOSING = """
            <h2>Related guides</h2>
            <p>Wave 56 completes the OCR-for vertical cluster (17/17), launches seven device OCR guides, and starts the best-PDF-compressor persona series — CREATE batch 20 of 450.</p>
            <p>Hub: <a href="/guides/ocr-pdf">OCR PDF</a> · CREATE remaining: 110</p>
            """
