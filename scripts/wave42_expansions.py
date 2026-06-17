"""Wave 42 — CREATE batch 6 (17 guides, score 80). PDF/A, retention, security + bank statement regional."""

W42_SLUGS = [
    "convert-to-pdf-a-online",
    "pdf-document-retention-periods",
    "share-pdf-securely",
    "firefox-print-to-pdf",
    "linkedin-save-profile-as-pdf",
    "accountant-client-pdf-portal",
    "compress-pdf-for-blackboard",
    "pdf-error-there-was-an-error-opening-this-document",
    "compress-pdf-ssa",
    "bank-statement-pdf-workflow-argentina",
    "bank-statement-pdf-workflow-poland",
    "bank-statement-pdf-workflow-sweden",
    "bank-statement-pdf-workflow-norway",
    "bank-statement-pdf-workflow-denmark",
    "bank-statement-pdf-workflow-finland",
    "bank-statement-pdf-workflow-portugal",
    "bank-statement-pdf-workflow-greece",
]

ARCHIVAL_CREATE_SLUGS = {"convert-to-pdf-a-online"}

RETENTION_CREATE_SLUGS = {"pdf-document-retention-periods"}

SECURITY_CREATE_SLUGS = {"share-pdf-securely"}

DEVICE_CREATE_SLUGS = {"firefox-print-to-pdf", "linkedin-save-profile-as-pdf"}

ACCOUNTANT_CREATE_SLUGS = {"accountant-client-pdf-portal"}

STUDENT_CREATE_SLUGS = {"compress-pdf-for-blackboard"}

TROUBLESHOOT_CREATE_SLUGS = {"pdf-error-there-was-an-error-opening-this-document"}

GOVT_CREATE_SLUGS = {"compress-pdf-ssa"}

BANK_CREATE_SLUGS = {
    "bank-statement-pdf-workflow-argentina",
    "bank-statement-pdf-workflow-poland",
    "bank-statement-pdf-workflow-sweden",
    "bank-statement-pdf-workflow-norway",
    "bank-statement-pdf-workflow-denmark",
    "bank-statement-pdf-workflow-finland",
    "bank-statement-pdf-workflow-portugal",
    "bank-statement-pdf-workflow-greece",
}

W42_BANK_META = {
    "argentina": ("Argentina", "Banco Nación / Galicia netbank", "Applicant compresses Banco Galicia six-month PDF for Argentina visa financial slot"),
    "poland": ("Poland", "PKO BP / mBank export", "Student compresses mBank statement PDF for Poland Schengen visa evidence"),
    "sweden": ("Sweden", "Swedbank / Nordea PDF", "Worker compresses Swedbank export for Sweden migration funds proof"),
    "norway": ("Norway", "DNB / SpareBank PDF", "Visitor compresses DNB statement PDF for Norway UDI upload"),
    "denmark": ("Denmark", "Danske Bank / Nordea", "Applicant compresses Danske Bank PDF for SIRI financial evidence"),
    "finland": ("Finland", "OP / Nordea Finland", "Researcher compresses OP Financial Group statement for Migri slot"),
    "portugal": ("Portugal", "Millennium BCP / Caixa", "Digital nomad compresses Millennium BCP PDF for Portugal visa"),
    "greece": ("Greece", "National Bank of Greece", "Tourist compresses NBG netbank PDF for Greece Schengen financial proof"),
}

W42_DATA = {
    "convert-to-pdf-a-online": {
        "title": "Convert to PDF/A Online — Archival Workflow (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/convert-to-pdf-a",
        "pillar_label": "convert to PDF/A",
        "related": "/guides/pdf-a-archival",
        "prog": "/pdf/compress",
        "example": "Records clerk validates PDF/A-1b export from Word before county archive ingest",
    },
    "pdf-document-retention-periods": {
        "title": "PDF Document Retention Periods — Legal Holds &amp; Destruction (2026)",
        "tool": "/pdf/pdfmetadata",
        "label": "PDF Metadata",
        "pillar": "/guides/document-retention-pdf",
        "pillar_label": "document retention PDF",
        "related": "/guides/sox-pdf-retention",
        "prog": "/pdf/pdfmetadata",
        "example": "Compliance maps invoice PDF 7-year retention vs contract 10-year — legal hold pauses purge job",
    },
    "share-pdf-securely": {
        "title": "Share PDF Securely — Encrypt, Link &amp; Redact (2026)",
        "tool": "/pdf/password",
        "label": "Protect PDF",
        "pillar": "/guides/secure-pdf-workflow",
        "pillar_label": "secure PDF workflow",
        "related": "/guides/secure-pdf-before-email",
        "prog": "/pdf/password",
        "example": "Consultant encrypts proposal PDF — password via SMS — watermark DRAFT on review copy",
    },
    "firefox-print-to-pdf": {
        "title": "Firefox Print to PDF — Save Web Pages (2026)",
        "tool": "/pdf/doctopdf",
        "label": "Save as PDF",
        "pillar": "/guides/edge-print-to-pdf",
        "pillar_label": "Edge print to PDF",
        "related": "/guides/webpage-to-pdf",
        "prog": "/pdf/doctopdf",
        "example": "Researcher saves Firefox print-to-PDF of policy page — disables headers — archives with date",
    },
    "linkedin-save-profile-as-pdf": {
        "title": "LinkedIn Save Profile as PDF — Recruiter Export (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/compress-pdf-for-linkedin",
        "pillar_label": "compress for LinkedIn",
        "related": "/guides/pdf-job-application-size-limit",
        "prog": "/compress-pdf-for-job-application",
        "example": "Recruiter saves candidate LinkedIn profile PDF — compress before ATS upload under 2 MB cap",
    },
    "accountant-client-pdf-portal": {
        "title": "Accountant Client PDF Portal — Secure Exchange (2026)",
        "tool": "/pdf/password",
        "label": "Protect PDF",
        "pillar": "/guides/pdf-tools-for-accountants",
        "pillar_label": "PDF tools for accountants",
        "related": "/guides/invoice-pdf-workflow-india",
        "prog": "/pdf/password",
        "example": "CA firm encrypts Form 16 bundle PDF per client — separate portal password — audit log download",
    },
    "compress-pdf-for-blackboard": {
        "title": "Compress PDF for Blackboard — LMS Upload (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/compress-pdf-for-lms",
        "pillar_label": "compress for LMS",
        "related": "/guides/submit-homework-pdf-canvas",
        "prog": "/compress-pdf",
        "example": "Professor uploads 15 MB syllabus scan — compress to 6 MB before Blackboard course shell",
    },
    "pdf-error-there-was-an-error-opening-this-document": {
        "title": "PDF Error Opening Document — Fix Corrupt &amp; Unsupported Files (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/pdf-troubleshooting",
        "pillar_label": "PDF troubleshooting",
        "related": "/guides/pdf-file-corrupted",
        "prog": "/pdf/compress",
        "example": "User re-downloads bank PDF — still fails — repair tool recovers xref table — opens in Acrobat",
    },
    "compress-pdf-ssa": {
        "title": "Compress PDF for SSA — Social Security Upload (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/government-portal-pdf-compress",
        "pillar_label": "government portal compress",
        "related": "/guides/compress-pdf-irs",
        "prog": "/compress-pdf-for-government-forms",
        "example": "Claimant compresses medical records PDF support doc for SSA online disability upload",
    },
}

for country, (name, bank_note, example) in W42_BANK_META.items():
    slug = f"bank-statement-pdf-workflow-{country}"
    W42_DATA[slug] = {
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
    p = W42_DATA[slug].get("prog", "")
    tail = f'<p>Tool: <a href="{p}">{p}</a></p>' if p else ""
    return html + tail


def _bank_deep(slug: str) -> str:
    d = W42_DATA[slug]
    return _d(
        slug,
        f"""
            <h2>{d['country']} bank PDF workflow</h2>
            <p>Official export: {d['bank_note']} — not mobile screenshot — all pages — account holder visible.</p>
            <ol>
            <li>Download netbank PDF — last 3–6 months per visa rules</li>
            <li><a href="/pdf/compress">Compress</a> — Less on scans</li>
            <li>Verify balances and salary credits at 100% zoom</li>
            </ol>
            <p>Pillar: <a href="{d['pillar']}">{d['pillar_label']}</a> · <a href="/guides/bank-statement-pdf-visa">bank statement visa</a>.</p>
            """,
    )


W42_DEEP = {
    "convert-to-pdf-a-online": _d("convert-to-pdf-a-online", """
            <h2>PDF/A online limits</h2>
            <p>Browser tools help access copies — true PDF/A often needs source-app export or preflight.</p>
            <p><a href="/guides/pdf-a-archival">PDF/A archival</a> · <a href="/guides/glossary-pdf-a">PDF/A glossary</a> · validate with veraPDF when required.</p>
            """),
    "pdf-document-retention-periods": _d("pdf-document-retention-periods", """
            <h2>Retention by document type</h2>
            <ul>
            <li>Tax invoices: often 5–7 years — jurisdiction dependent</li>
            <li>Contracts: life of agreement + statute of limitations</li>
            <li>HR personnel files: hire date + 7+ years</li>
            </ul>
            <p><a href="/guides/document-retention-pdf">Retention pillar</a> · legal hold pauses automated deletion.</p>
            """),
    "share-pdf-securely": _d("share-pdf-securely", """
            <h2>Secure share layers</h2>
            <ol>
            <li>Redact if PII must not appear</li>
            <li><a href="/pdf/password">Encrypt</a> — password out-of-band</li>
            <li>Watermark DRAFT on review copies</li>
            </ol>
            <p><a href="/guides/how-to-protect-pdf-before-sending">Protect before sending</a>.</p>
            """),
    "firefox-print-to-pdf": _d("firefox-print-to-pdf", """
            <h2>Firefox export</h2>
            <p>Ctrl+P → Print to PDF → Save — disable headers in print settings.</p>
            <p><a href="/guides/edge-print-to-pdf">Edge guide</a> · <a href="/guides/chrome-save-as-pdf-settings">Chrome settings</a>.</p>
            """),
    "linkedin-save-profile-as-pdf": _d("linkedin-save-profile-as-pdf", """
            <h2>LinkedIn profile PDF</h2>
            <p>More → Save to PDF on profile — compress before email or ATS — keep text selectable.</p>
            <p><a href="/guides/compress-pdf-for-linkedin">LinkedIn compress</a> · <a href="/guides/ats-friendly-pdf-resume">ATS resume</a>.</p>
            """),
    "accountant-client-pdf-portal": _d("accountant-client-pdf-portal", """
            <h2>Client portal exchange</h2>
            <ul>
            <li>Encrypt client-specific PDF bundles</li>
            <li>Never email passwords in same thread</li>
            <li>Version filenames: ClientName_Form16_FY2025.pdf</li>
            </ul>
            <p><a href="/guides/pdf-tools-for-accountants">Accountant tools hub</a>.</p>
            """),
    "compress-pdf-for-blackboard": _d("compress-pdf-for-blackboard", """
            <h2>Blackboard upload</h2>
            <p>Course content and assignment caps vary — compress scans — <a href="/guides/compress-pdf-for-lms">LMS compress guide</a>.</p>
            <p>Also: <a href="/guides/compress-pdf-students">student compress</a> · merge readings first.</p>
            """),
    "pdf-error-there-was-an-error-opening-this-document": _d("pdf-error-there-was-an-error-opening-this-document", """
            <h2>Common causes</h2>
            <ul>
            <li>Incomplete download — re-fetch file</li>
            <li>Corrupt xref / truncated upload</li>
            <li>Wrong extension (.pdf renamed from .doc)</li>
            <li>Unsupported PDF version for old reader</li>
            </ul>
            <p>Try re-download · <a href="/guides/repair-pdf-online">Repair PDF online</a> · <a href="/guides/corrupted-pdf-repair">Corrupted repair</a> · <a href="/guides/pdf-won-t-open">PDF won't open</a>.</p>
            """),
    "compress-pdf-ssa": _d("compress-pdf-ssa", """
            <h2>SSA upload tips</h2>
            <p>Medical and supporting PDFs — read SSA.gov upload FAQ — Less on scans — dates legible.</p>
            <p><a href="/guides/compress-pdf-irs">IRS compress</a> · <a href="/guides/government-portal-pdf-compress">government hub</a>.</p>
            """),
}

for country in W42_BANK_META:
    W42_DEEP[f"bank-statement-pdf-workflow-{country}"] = _bank_deep(f"bank-statement-pdf-workflow-{country}")

W42_CREATE_CLUSTER = """
            <h2>CREATE batch 6</h2>
            <ul>
            <li><a href="/guides/convert-to-pdf-a-online">PDF/A online</a> · <a href="/guides/pdf-document-retention-periods">Retention periods</a> · <a href="/guides/share-pdf-securely">Share securely</a></li>
            <li><a href="/guides/firefox-print-to-pdf">Firefox print PDF</a> · <a href="/guides/linkedin-save-profile-as-pdf">LinkedIn profile PDF</a></li>
            <li><a href="/guides/accountant-client-pdf-portal">Accountant portal</a> · <a href="/guides/compress-pdf-for-blackboard">Blackboard compress</a></li>
            <li><a href="/guides/pdf-error-there-was-an-error-opening-this-document">PDF open error</a> · <a href="/guides/compress-pdf-ssa">SSA compress</a></li>
            <li>Bank: <a href="/guides/bank-statement-pdf-workflow-argentina">Argentina</a> · <a href="/guides/bank-statement-pdf-workflow-poland">Poland</a> · <a href="/guides/bank-statement-pdf-workflow-sweden">Sweden</a></li>
            <li><a href="/guides/bank-statement-pdf-workflow-norway">Norway</a> · <a href="/guides/bank-statement-pdf-workflow-denmark">Denmark</a> · <a href="/guides/bank-statement-pdf-workflow-finland">Finland</a></li>
            <li><a href="/guides/bank-statement-pdf-workflow-portugal">Portugal</a> · <a href="/guides/bank-statement-pdf-workflow-greece">Greece</a></li>
            </ul>
            <p>Prior: <a href="/guides/visa-application-pdf-workflow-thailand">batch 5 visa</a> · <a href="/guides/bates-numbering-pdf">batch 4</a></p>
            """

W42_BANK_CLUSTER = """
            <h2>Wave 42 bank statement hubs</h2>
            <p>Europe: <a href="/guides/bank-statement-pdf-workflow-poland">Poland</a> · <a href="/guides/bank-statement-pdf-workflow-sweden">Sweden</a> · <a href="/guides/bank-statement-pdf-workflow-norway">Norway</a> · <a href="/guides/bank-statement-pdf-workflow-denmark">Denmark</a> · <a href="/guides/bank-statement-pdf-workflow-finland">Finland</a> · <a href="/guides/bank-statement-pdf-workflow-portugal">Portugal</a> · <a href="/guides/bank-statement-pdf-workflow-greece">Greece</a></p>
            <p>Americas: <a href="/guides/bank-statement-pdf-workflow-argentina">Argentina</a> · existing: <a href="/guides/bank-statement-pdf-workflow-usa">USA</a> · <a href="/guides/bank-statement-pdf-workflow-mexico">Mexico</a></p>
            """

W42_COMPRESS_TOPUP = """
            <h2>CREATE batch 6 checklist</h2>
            <ol>
            <li>Bank PDF: official netbank export — not screenshot</li>
            <li>Compress once after merge — Less on scans</li>
            <li>Secure share: encrypt + password separate channel</li>
            <li>PDF/A: validate when archive compliance required</li>
            </ol>
            """

W42_CLOSING = """
            <h2>Related guides</h2>
            <p>Wave 42 adds PDF/A online, retention periods, secure sharing, browser export, accountant portal, Blackboard compress, SSA compress, open-error fixes, and eight regional bank statement workflows — CREATE batch 6 of 450.</p>
            <p>Hub: <a href="/guides/pdf-regional-workflows-hub">regional workflows</a> · CREATE remaining: 348</p>
            """
