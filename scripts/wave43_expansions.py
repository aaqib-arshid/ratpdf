"""Wave 43 — CREATE batch 7 (17 guides, score 79–80). Bank statement Asia/Africa/MENA + forms/metadata/a11y."""

W43_SLUGS = [
    "bank-statement-pdf-workflow-turkey",
    "bank-statement-pdf-workflow-egypt",
    "bank-statement-pdf-workflow-morocco",
    "bank-statement-pdf-workflow-nigeria",
    "bank-statement-pdf-workflow-kenya",
    "bank-statement-pdf-workflow-thailand",
    "bank-statement-pdf-workflow-vietnam",
    "bank-statement-pdf-workflow-indonesia",
    "bank-statement-pdf-workflow-malaysia",
    "bank-statement-pdf-workflow-philippines",
    "bank-statement-pdf-workflow-china",
    "bank-statement-pdf-workflow-taiwan",
    "bank-statement-pdf-workflow-hong-kong",
    "pdf-form-digital-signature-field",
    "remove-metadata-from-pdf",
    "remediate-pdf-accessibility",
    "pdf-error-file-damaged",
]

BANK_CREATE_SLUGS = {
    "bank-statement-pdf-workflow-turkey",
    "bank-statement-pdf-workflow-egypt",
    "bank-statement-pdf-workflow-morocco",
    "bank-statement-pdf-workflow-nigeria",
    "bank-statement-pdf-workflow-kenya",
    "bank-statement-pdf-workflow-thailand",
    "bank-statement-pdf-workflow-vietnam",
    "bank-statement-pdf-workflow-indonesia",
    "bank-statement-pdf-workflow-malaysia",
    "bank-statement-pdf-workflow-philippines",
    "bank-statement-pdf-workflow-china",
    "bank-statement-pdf-workflow-taiwan",
    "bank-statement-pdf-workflow-hong-kong",
}

FORM_CREATE_SLUGS = {"pdf-form-digital-signature-field"}

METADATA_CREATE_SLUGS = {"remove-metadata-from-pdf"}

ACCESSIBILITY_CREATE_SLUGS = {"remediate-pdf-accessibility"}

TROUBLESHOOT_CREATE_SLUGS = {"pdf-error-file-damaged"}

W43_BANK_META = {
    "turkey": ("Turkey", "Ziraat / İş Bankası netbank", "Business visitor compresses İş Bankası statement PDF for Turkey visa invitation evidence"),
    "egypt": ("Egypt", "NBE / CIB export", "Tourist compresses CIB six-month PDF for Egypt visa funds proof"),
    "morocco": ("Morocco", "Attijariwafa / BMCE", "Applicant compresses Attijariwafa bank PDF for Morocco visa financial slot"),
    "nigeria": ("Nigeria", "GTBank / Zenith", "Student compresses Zenith sponsor statement PDF for Nigeria visa upload"),
    "kenya": ("Kenya", "Equity / KCB netbank", "Applicant compresses Equity Bank PDF for Kenya eVisa financial evidence"),
    "thailand": ("Thailand", "Bangkok Bank / Kasikorn", "Tourist compresses Kasikorn statement PDF for Thailand visa funds"),
    "vietnam": ("Vietnam", "Vietcombank / Techcombank", "Visitor compresses Vietcombank PDF for Vietnam eVisa financial proof"),
    "indonesia": ("Indonesia", "BCA / Mandiri", "Digital nomad compresses BCA export for Indonesia visa portal"),
    "malaysia": ("Malaysia", "Maybank / CIMB", "Student compresses Maybank PDF for Malaysia visa sponsor evidence"),
    "philippines": ("Philippines", "BDO / BPI", "Worker compresses BPI statement PDF for Philippines visa slot"),
    "china": ("China", "ICBC / Bank of China", "Applicant compresses bilingual Bank of China PDF for CVASC visa center"),
    "taiwan": ("Taiwan", "CTBC / Cathay United", "Researcher compresses CTBC funds PDF for Taiwan visa application"),
    "hong-kong": ("Hong Kong", "HSBC HK / Hang Seng", "Visitor compresses Hang Seng statement PDF for Hong Kong visa funds"),
}

W43_DATA = {
    "pdf-form-digital-signature-field": {
        "title": "PDF Form Digital Signature Field — Add &amp; Validate (2026)",
        "tool": "/pdf/signtext",
        "label": "Sign PDF",
        "pillar": "/guides/beginner-digital-signature-basics",
        "pillar_label": "digital signature basics",
        "related": "/guides/glossary-digital-signature",
        "prog": "/pdf/signtext",
        "example": "HR adds signature field to offer letter PDF — candidate signs in browser — flatten before archive",
    },
    "remove-metadata-from-pdf": {
        "title": "Remove Metadata from PDF — Author &amp; Hidden Paths (2026)",
        "tool": "/pdf/pdfmetadata",
        "label": "PDF Metadata",
        "pillar": "/guides/pdf-metadata-remove",
        "pillar_label": "PDF metadata remove",
        "related": "/guides/beginner-pdf-metadata-explained",
        "prog": "/pdf/pdfmetadata",
        "example": "Legal strips internal author path from draft MSA PDF before client share on procurement portal",
    },
    "remediate-pdf-accessibility": {
        "title": "Remediate PDF Accessibility — Tags &amp; Alt Text (2026)",
        "tool": "/pdf/ocrpdf",
        "label": "OCR PDF",
        "pillar": "/guides/pdf-ua-accessibility",
        "pillar_label": "PDF/UA accessibility",
        "related": "/guides/pdf-ua-compliance-guide",
        "prog": "/pdf/ocrpdf",
        "example": "Publisher adds alt text and fixes reading order on annual report PDF before government RFP submit",
    },
    "pdf-error-file-damaged": {
        "title": "PDF File Damaged — Cannot Be Repaired Fix (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/pdf-file-corrupted",
        "pillar_label": "PDF file corrupted",
        "related": "/guides/corrupted-pdf-repair",
        "prog": "/pdf/compress",
        "example": "USB copy interrupted — Acrobat says file damaged — re-download from source — compress recovers readable copy",
    },
}

for country, (name, bank_note, example) in W43_BANK_META.items():
    slug = f"bank-statement-pdf-workflow-{country}"
    W43_DATA[slug] = {
        "title": f"Bank Statement PDF Workflow {name} — Visa Evidence (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": f"/guides/visa-application-pdf-workflow-{country}",
        "pillar_label": f"{name} visa workflow",
        "related": "/guides/bank-statement-pdf-visa",
        "prog": "/compress-pdf-for-visa-application",
        "example": example,
        "country": name,
        "bank_note": bank_note,
    }


def _d(slug: str, html: str) -> str:
    p = W43_DATA[slug].get("prog", "")
    tail = f'<p>Tool: <a href="{p}">{p}</a></p>' if p else ""
    return html + tail


def _bank_deep(slug: str) -> str:
    d = W43_DATA[slug]
    return _d(
        slug,
        f"""
            <h2>{d['country']} bank PDF workflow</h2>
            <p>Official export: {d['bank_note']} — not mobile screenshot — all pages — account holder visible.</p>
            <ol>
            <li>Download netbank PDF — last 3–6 months per embassy rules</li>
            <li><a href="/pdf/compress">Compress</a> — Less on scans</li>
            <li>Verify salary credits and closing balance at 100% zoom</li>
            </ol>
            <p>Pillar: <a href="{d['pillar']}">{d['pillar_label']}</a> · <a href="/guides/bank-statement-pdf-visa">bank statement visa</a>.</p>
            """,
    )


W43_DEEP = {
    "pdf-form-digital-signature-field": _d("pdf-form-digital-signature-field", """
            <h2>Signature field types</h2>
            <ul>
            <li>Typed signature — quick internal ack</li>
            <li>Image signature — scanned sign on tablet</li>
            <li>Certificate signature — qualified e-sign platforms</li>
            </ul>
            <p><a href="/guides/glossary-digital-signature">Digital signature glossary</a> · flatten after sign for archive.</p>
            """),
    "remove-metadata-from-pdf": _d("remove-metadata-from-pdf", """
            <h2>What to strip</h2>
            <ul>
            <li>Author and creator tool paths</li>
            <li>Draft titles in subject field</li>
            <li>Embedded geolocation on phone scans (if present)</li>
            </ul>
            <p><a href="/guides/pdf-metadata-remove">Metadata remove pillar</a> · audit before FOIA or procurement send.</p>
            """),
    "remediate-pdf-accessibility": _d("remediate-pdf-accessibility", """
            <h2>Remediation steps</h2>
            <ol>
            <li>Export tagged PDF from source Word/InDesign when possible</li>
            <li>OCR scans — add structure tags manually in Acrobat if needed</li>
            <li>Alt text on charts — not color-only meaning</li>
            </ol>
            <p><a href="/guides/pdf-ua-compliance-guide">PDF/UA compliance</a> · <a href="/guides/tagged-pdf-checklist">tagged PDF checklist</a>.</p>
            """),
    "pdf-error-file-damaged": _d("pdf-error-file-damaged", """
            <h2>When repair fails</h2>
            <p>True structural damage may be unrecoverable — always re-export from source system first.</p>
            <ul>
            <li>Re-download from portal or email</li>
            <li>Try <a href="/guides/repair-pdf-online">repair PDF online</a> on partial files</li>
            <li>Split and recover page ranges if only section corrupt</li>
            </ul>
            <p><a href="/guides/pdf-file-corrupted">Corrupted file guide</a>.</p>
            """),
}

for country in W43_BANK_META:
    W43_DEEP[f"bank-statement-pdf-workflow-{country}"] = _bank_deep(f"bank-statement-pdf-workflow-{country}")

W43_CREATE_CLUSTER = """
            <h2>CREATE batch 7</h2>
            <ul>
            <li>MENA/Africa bank: <a href="/guides/bank-statement-pdf-workflow-turkey">Turkey</a> · <a href="/guides/bank-statement-pdf-workflow-egypt">Egypt</a> · <a href="/guides/bank-statement-pdf-workflow-morocco">Morocco</a></li>
            <li><a href="/guides/bank-statement-pdf-workflow-nigeria">Nigeria</a> · <a href="/guides/bank-statement-pdf-workflow-kenya">Kenya</a></li>
            <li>ASEAN bank: <a href="/guides/bank-statement-pdf-workflow-thailand">Thailand</a> · <a href="/guides/bank-statement-pdf-workflow-vietnam">Vietnam</a> · <a href="/guides/bank-statement-pdf-workflow-indonesia">Indonesia</a></li>
            <li><a href="/guides/bank-statement-pdf-workflow-malaysia">Malaysia</a> · <a href="/guides/bank-statement-pdf-workflow-philippines">Philippines</a></li>
            <li>Greater China: <a href="/guides/bank-statement-pdf-workflow-china">China</a> · <a href="/guides/bank-statement-pdf-workflow-taiwan">Taiwan</a> · <a href="/guides/bank-statement-pdf-workflow-hong-kong">Hong Kong</a></li>
            <li><a href="/guides/pdf-form-digital-signature-field">Digital signature field</a> · <a href="/guides/remove-metadata-from-pdf">Remove metadata</a></li>
            <li><a href="/guides/remediate-pdf-accessibility">Remediate accessibility</a> · <a href="/guides/pdf-error-file-damaged">File damaged error</a></li>
            </ul>
            <p>Prior bank batch: <a href="/guides/bank-statement-pdf-workflow-argentina">batch 6 Europe/Americas</a></p>
            """

W43_BANK_CLUSTER = """
            <h2>Wave 43 bank statement hubs (Asia/Africa)</h2>
            <p>ASEAN: <a href="/guides/bank-statement-pdf-workflow-thailand">Thailand</a> · <a href="/guides/bank-statement-pdf-workflow-vietnam">Vietnam</a> · <a href="/guides/bank-statement-pdf-workflow-indonesia">Indonesia</a> · <a href="/guides/bank-statement-pdf-workflow-malaysia">Malaysia</a> · <a href="/guides/bank-statement-pdf-workflow-philippines">Philippines</a></p>
            <p>Greater China: <a href="/guides/bank-statement-pdf-workflow-china">China</a> · <a href="/guides/bank-statement-pdf-workflow-taiwan">Taiwan</a> · <a href="/guides/bank-statement-pdf-workflow-hong-kong">Hong Kong</a></p>
            <p>MENA/Africa: <a href="/guides/bank-statement-pdf-workflow-turkey">Turkey</a> · <a href="/guides/bank-statement-pdf-workflow-egypt">Egypt</a> · <a href="/guides/bank-statement-pdf-workflow-morocco">Morocco</a> · <a href="/guides/bank-statement-pdf-workflow-nigeria">Nigeria</a> · <a href="/guides/bank-statement-pdf-workflow-kenya">Kenya</a></p>
            """

W43_COMPRESS_TOPUP = """
            <h2>CREATE batch 7 checklist</h2>
            <ol>
            <li>Pair bank guide with matching visa workflow hub</li>
            <li>Netbank PDF export — never screenshot for embassy</li>
            <li>Strip metadata before external draft share</li>
            <li>Remediate tags before accessibility RFP submit</li>
            </ol>
            """

W43_CLOSING = """
            <h2>Related guides</h2>
            <p>Wave 43 completes Asia-Pacific and MENA/Africa bank statement spokes plus digital signature fields, metadata removal, accessibility remediation, and damaged-file troubleshooting — CREATE batch 7 of 450.</p>
            <p>Hub: <a href="/guides/pdf-regional-workflows-hub">regional workflows</a> · CREATE remaining: 331</p>
            """
