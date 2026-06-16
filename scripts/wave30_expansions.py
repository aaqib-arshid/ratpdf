"""Wave 30 — University application batch 2 (complete) + compress technical batch."""

W30_SLUGS = [
    "university-application-pdf-workflow-mexico",
    "university-application-pdf-workflow-netherlands",
    "university-application-pdf-workflow-new-zealand",
    "university-application-pdf-workflow-singapore",
    "university-application-pdf-workflow-south-africa",
    "university-application-pdf-workflow-south-korea",
    "university-application-pdf-workflow-spain",
    "university-application-pdf-workflow-uae",
    "university-application-pdf-workflow-uk",
    "university-application-pdf-workflow-usa",
    "irs-tax-pdf-format",
    "compress-bank-statement-pdf",
    "compress-scanned-vs-digital-pdf",
    "ghostscript-pdf-compression",
    "compress-pdf-accountants",
    "compress-pdf-lawyers",
    "why-is-pdf-file-so-large",
]

UNIVERSITY_SLUGS = {
    "university-application-pdf-workflow-mexico",
    "university-application-pdf-workflow-netherlands",
    "university-application-pdf-workflow-new-zealand",
    "university-application-pdf-workflow-singapore",
    "university-application-pdf-workflow-south-africa",
    "university-application-pdf-workflow-south-korea",
    "university-application-pdf-workflow-spain",
    "university-application-pdf-workflow-uae",
    "university-application-pdf-workflow-uk",
    "university-application-pdf-workflow-usa",
}

COMPRESS_TECH_SLUGS = {
    "irs-tax-pdf-format",
    "compress-bank-statement-pdf",
    "compress-scanned-vs-digital-pdf",
    "ghostscript-pdf-compression",
    "compress-pdf-accountants",
    "compress-pdf-lawyers",
    "why-is-pdf-file-so-large",
}

W30_UNI_META = {
    "mexico": {
        "title": "University Application PDF Workflow Mexico — SISU &amp; Histórico (2026)",
        "example": "Applicant compresses histórico escolar and ENEM resultado PDF for university portal",
        "docs": "Histórico escolar, diploma, ENEM, CURP/INE scan, passport",
        "portal": "SISU, private university portals — 2–5 MB per document",
        "related": "/guides/visa-application-pdf-workflow-mexico",
        "note": "CURP and nombre must stay legible — Less compression if digits blur",
    },
    "netherlands": {
        "title": "University Application PDF Workflow Netherlands — Studielink (2026)",
        "example": "International student merges diploma and English test PDF for Studielink upload",
        "docs": "Diploma, transcript, passport, IELTS/TOEFL, motivation letter PDF if required",
        "portal": "Studielink and individual hogeschool/universiteit portals — 2–5 MB",
        "related": "/guides/visa-application-pdf-workflow-netherlands",
        "note": "Nuffic credential evaluation PDF separate — do not merge with transcript slot",
    },
    "new-zealand": {
        "title": "University Application PDF Workflow New Zealand — NZQA &amp; Direct Apply (2026)",
        "example": "Student compresses NZQA record of achievement PDF for uni application portal",
        "docs": "NZQA transcript, passport, English test, referee forms",
        "portal": "Direct uni portals — often 10 MB still compress multi-page scans",
        "related": "/guides/visa-application-pdf-workflow-new-zealand",
        "note": "Immigration NZ visa pack separate from admission upload",
    },
    "singapore": {
        "title": "University Application PDF Workflow Singapore — NUS/NTU &amp; MOE (2026)",
        "example": "International applicant merges A-level transcript and passport PDF for direct apply",
        "docs": "Transcripts, exam results, passport, English proficiency cert",
        "portal": "NUS, NTU, SMU direct portals — 2–5 MB per slot",
        "related": "/guides/visa-application-pdf-workflow-singapore",
        "note": "MOE attestation may be separate document — read programme FAQ",
    },
    "south-africa": {
        "title": "University Application PDF Workflow South Africa — Matric &amp; CAO (2026)",
        "example": "Matriculant compresses NSC certificate and ID PDF for university application",
        "docs": "NSC matric certificate, ID book/scan, NBT results if required",
        "portal": "Direct university portals — 2–5 MB typical",
        "related": "/guides/visa-application-pdf-workflow-south-africa",
        "note": "Certified matric copy stamp must survive compress",
    },
    "south-korea": {
        "title": "University Application PDF Workflow South Korea — Direct Apply &amp; EJU (2026)",
        "example": "Applicant compresses high school transcript and EJU score PDF for Korean uni portal",
        "docs": "Transcript, graduation certificate, EJU, TOPIK, passport",
        "portal": "Individual university Korean portals — strict file naming",
        "related": "/guides/visa-application-pdf-workflow-south-korea",
        "note": "D-2 visa documents separate from admission portal upload",
    },
    "spain": {
        "title": "University Application PDF Workflow Spain — UNEDasiss &amp; Direct (2026)",
        "example": "Non-EU student merges notarized transcript and passport PDF for UNEDasiss",
        "docs": "Transcript, diploma homologación, passport, Spanish test cert",
        "portal": "UNEDasiss, universidad portals — 2–5 MB per slot",
        "related": "/guides/visa-application-pdf-workflow-spain",
        "note": "Homologación PDF often separate slot — no convenience merge",
    },
    "uae": {
        "title": "University Application PDF Workflow UAE — MOE Attestation &amp; Apply (2026)",
        "example": "Resident student merges attested degree and Emirates ID PDF for university portal",
        "docs": "Attested certificates, Emirates ID, passport, English test",
        "portal": "UAE university portals — 2–5 MB per document",
        "related": "/guides/visa-application-pdf-workflow-uae",
        "note": "MOE attestation stamp must be readable at 100% zoom after compress",
    },
    "uk": {
        "title": "University Application PDF Workflow UK — UCAS &amp; Direct (2026)",
        "example": "UCAS applicant compresses reference PDF and portfolio excerpt for supplementary upload",
        "docs": "UCAS application PDF exports, references, portfolio, passport for direct apply",
        "portal": "UCAS upload slots — <a href=\"/guides/compress-pdf-ucas\">UCAS compress guide</a> — direct uni varies",
        "related": "/guides/visa-application-pdf-workflow-uk",
        "note": "Student visa CAS documents separate from UCAS admission upload",
    },
    "usa": {
        "title": "University Application PDF Workflow USA — Common App &amp; Transcripts (2026)",
        "example": "Senior compresses portfolio PDF and supplemental materials for Common App upload",
        "docs": "Transcripts via counselor, portfolio, supplemental essays PDF, test score reports",
        "portal": "Common App — <a href=\"/guides/compress-pdf-common-app\">Common App compress</a> — Coalition and direct",
        "related": "/guides/visa-application-pdf-workflow-usa",
        "note": "F-1 visa I-20 pack separate from undergraduate admission portal",
    },
}

W30_COMPRESS_DATA = {
    "irs-tax-pdf-format": {
        "title": "IRS Tax Document PDF Format — Records, Invoices &amp; Storage (2026)",
        "tool": "/invoice/create",
        "label": "Create Invoice",
        "pillar": "/guides/tax-document-pdf-workflow-usa",
        "pillar_label": "tax document workflow USA",
        "related": "/guides/invoice-pdf-workflow-india",
        "example": "SMB archives client invoices as searchable PDF with consistent filename schema for IRS recordkeeping",
    },
    "compress-bank-statement-pdf": {
        "title": "Compress Bank Statement PDF — Email &amp; Loan Portal Upload (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/bank-statement-pdf-workflow-usa",
        "pillar_label": "bank statement workflow USA",
        "related": "/guides/compress-pdf-for-visa-application",
        "example": "Mortgage broker compresses 6-month Chase netbank PDF from 8 MB to 2 MB for lender portal",
    },
    "compress-scanned-vs-digital-pdf": {
        "title": "Compress Scanned PDF vs Digital PDF — Which Shrinks More? (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/compress-pdf-guide",
        "pillar_label": "compress PDF guide",
        "related": "/guides/why-is-pdf-file-so-large",
        "example": "Ops team compares Recommended compress on Word export vs 300 DPI scan — scan needs Less first",
    },
    "ghostscript-pdf-compression": {
        "title": "Ghostscript PDF Compression Explained — How RatPDF Shrinks Files (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/pdf-compression-benchmark",
        "pillar_label": "compression benchmark guide",
        "related": "/guides/compress-pdf-guide",
        "example": "IT documents Less vs Recommended vs Extreme on board pack before rolling out compress SOP",
    },
    "compress-pdf-accountants": {
        "title": "Compress PDF for Accountants — Client Packs &amp; Portal Uploads (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/merge-pdf-accountants",
        "pillar_label": "merge PDF for accountants",
        "related": "/guides/pdf-workflow-accountants",
        "example": "CA firm compresses quarterly trial balance PDF export from 18 MB to 9 MB for client email",
    },
    "compress-pdf-lawyers": {
        "title": "Compress PDF for Lawyers — E-Filing &amp; Discovery Uploads (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/merge-pdf-court-filing",
        "pillar_label": "merge PDF for court filing",
        "related": "/guides/pdf-workflow-lawyers",
        "example": "Paralegal compresses 42 MB exhibit PDF to 28 MB for CM/ECF upload after merge",
    },
    "why-is-pdf-file-so-large": {
        "title": "Why Is My PDF So Large? — Causes &amp; Fixes (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/compress-pdf-guide",
        "pillar_label": "compress PDF guide",
        "related": "/guides/compress-scanned-vs-digital-pdf",
        "example": "User discovers 80 MB PDF is 600 DPI phone photos — re-scan at 200 DPI then compress",
    },
}


def _uni_data(code: str) -> dict:
    m = W30_UNI_META[code]
    return {
        "title": m["title"],
        "tool": "/pdf/merge",
        "label": "Merge PDF",
        "pillar": "/guides/university-application-pdf-workflow-india",
        "pillar_label": "university application workflow India (reference)",
        "related": m["related"],
        "example": m["example"],
    }


W30_DATA = {
    **{f"university-application-pdf-workflow-{k}": _uni_data(k) for k in W30_UNI_META},
    **W30_COMPRESS_DATA,
}


def _uni_deep(code: str) -> str:
    m = W30_UNI_META[code]
    name = code.replace("-", " ").title()
    if code == "usa":
        name = "USA"
    elif code == "uk":
        name = "UK"
    elif code == "uae":
        name = "UAE"
    return f"""
            <h2>University application — {name}</h2>
            <p><strong>Typical documents:</strong> {m['docs']}.</p>
            <p><strong>Portal caps:</strong> {m['portal']}.</p>
            <p>{m['note']}.</p>
            <h2>Workflow</h2>
            <ol>
            <li>Scan 200–300 DPI — crop borders — straight edges</li>
            <li>Order per portal FAQ — ID → transcripts → tests → supporting</li>
            <li><a href="/pdf/merge">Merge PDF</a> only when portal allows one file per category</li>
            <li><a href="/pdf/compress">Compress PDF</a> — verify IDs and seals at 100% zoom</li>
            <li>Visa pack separate — <a href="{m['related']}">visa workflow</a></li>
            </ol>
            <p>Batch 1: <a href="/guides/university-application-pdf-workflow-australia">Australia</a> · <a href="/guides/university-application-pdf-workflow-canada">Canada</a> · <a href="/guides/university-application-pdf-workflow-india">India</a>.</p>
            <p>Hub: <a href="/guides/compress-pdf-for-university-application">university compress</a> · <a href="/guides/university-pdf-upload-requirements">upload requirements</a>.</p>
            """


W30_COMPRESS_DEEP = {
    "irs-tax-pdf-format": """
            <h2>IRS recordkeeping basics</h2>
            <p>IRS expects businesses to keep books and records accessible — PDF is standard for invoices, receipts, and bank statements. RatPDF does not provide tax advice — confirm retention with your CPA.</p>
            <h2>Recommended PDF workflow</h2>
            <ol>
            <li>Issue invoices via <a href="/invoice/create">Create Invoice</a> — export PDF with consistent naming</li>
            <li>Filename schema: YYYY-MM-DD_ClientName_InvoiceNumber.pdf</li>
            <li>Archive uncompressed master — compress copies for email only</li>
            <li>Searchable text — digital PDF not phone photo of paper</li>
            </ol>
            <p>Tax workflow: <a href="/guides/tax-document-pdf-workflow-usa">USA tax documents</a> · India: <a href="/guides/invoice-pdf-workflow-india">invoice workflow India</a>.</p>
            """,
    "compress-bank-statement-pdf": """
            <h2>Why bank PDFs are large</h2>
            <p>Netbanking exports multi-page statements with embedded fonts — 3–6 months can hit 5–15 MB. Lenders and visa portals cap at 2–5 MB per slot.</p>
            <h2>Workflow</h2>
            <ol>
            <li>Export official PDF from bank — not screenshot</li>
            <li>Verify account number and closing balance at 100% zoom</li>
            <li><a href="/pdf/compress">Compress PDF</a> Recommended — Less if transaction lines soften</li>
            <li>One month per slot if portal rejects merged file</li>
            </ol>
            <p>Regional: <a href="/guides/bank-statement-pdf-workflow-usa">USA</a> · <a href="/guides/bank-statement-pdf-workflow-uk">UK</a> · <a href="/guides/bank-statement-pdf-workflow-india">India</a> · <a href="/guides/compress-pdf-for-visa-application">visa compress</a>.</p>
            """,
    "compress-scanned-vs-digital-pdf": """
            <h2>Digital PDF</h2>
            <p>Born-digital from Word, Excel, or export — text and vector graphics — compresses well with Recommended — often 60–80% reduction.</p>
            <h2>Scanned PDF</h2>
            <p>Every page is a bitmap — already JPEG inside — second aggressive pass blurs text — use Less on scans — consider re-scan at 200 DPI grayscale first.</p>
            <h2>Decision tree</h2>
            <p>Ctrl+F works → digital path. No selection → scan path — <a href="/pdf/ocrpdf">OCR</a> if search needed after compress.</p>
            <p>Diagnosis: <a href="/guides/why-is-pdf-file-so-large">why PDF is large</a> · Benchmark: <a href="/guides/ghostscript-pdf-compression">Ghostscript explained</a>.</p>
            """,
    "ghostscript-pdf-compression": """
            <h2>What Ghostscript does</h2>
            <p>RatPDF uses Ghostscript presets to re-encode images, subset fonts, and remove redundant objects — same engine family as many server-side PDF tools.</p>
            <h2>Presets (RatPDF labels)</h2>
            <ul>
            <li><strong>Less:</strong> minimal quality loss — legal exhibits, signed scans</li>
            <li><strong>Recommended:</strong> default for email and portals</li>
            <li><strong>Extreme:</strong> smallest file — verify footnotes and stamps after</li>
            </ul>
            <p>Benchmark: <a href="/guides/pdf-compression-benchmark">compression benchmark guide</a> · Research: <a href="/research/pdf-compression-benchmark">benchmark data</a>.</p>
            """,
    "compress-pdf-accountants": """
            <h2>Accountant use cases</h2>
            <ul>
            <li>Quarterly TB and workpaper PDF exports — client email gateways</li>
            <li>Bank statement PDF packs — loan and GST portal annexures</li>
            <li>Board packs after <a href="/guides/merge-pdf-accountants">merge</a> — single compress pass</li>
            </ul>
            <h2>Quality rules</h2>
            <p>Figures and decimals must survive compress — verify at 100% zoom — Less on signed workpapers. Workflow: <a href="/guides/pdf-workflow-accountants">PDF workflow accountants</a>.</p>
            """,
    "compress-pdf-lawyers": """
            <h2>Legal use cases</h2>
            <ul>
            <li>Exhibit PDFs after <a href="/guides/merge-pdf-court-filing">court merge</a> — CM/ECF caps</li>
            <li>Scanned depositions — OCR before compress if search required</li>
            <li>Discovery production volumes — Less on notarized pages</li>
            </ul>
            <h2>E-filing caution</h2>
            <p>Courts reject illegible filings — never Extreme on stamped exhibits without QA. <a href="/guides/compress-pdf-efiling">E-filing compress guide</a> · <a href="/guides/pdf-workflow-lawyers">lawyer workflow</a>.</p>
            """,
    "why-is-pdf-file-so-large": """
            <h2>Common causes</h2>
            <ul>
            <li><strong>600 DPI phone scans</strong> — re-scan 200–300 DPI grayscale</li>
            <li><strong>Embedded photos</strong> — marketing PDFs and board packs</li>
            <li><strong>Unsubset fonts</strong> — full font files embedded per weight</li>
            <li><strong>Attached files</strong> — embedded Excel or source images inside PDF</li>
            </ul>
            <h2>Fix workflow</h2>
            <ol>
            <li>Identify digital vs scan — <a href="/guides/compress-scanned-vs-digital-pdf">scanned vs digital guide</a></li>
            <li>Re-export from source app if possible</li>
            <li><a href="/pdf/compress">Compress PDF</a> — one pass after merge</li>
            </ol>
            <p>Split if still over cap: <a href="/guides/compress-vs-split">compress vs split</a>.</p>
            """,
}

W30_UNI_DEEP = {f"university-application-pdf-workflow-{k}": _uni_deep(k) for k in W30_UNI_META}
W30_DEEP = {**W30_UNI_DEEP, **W30_COMPRESS_DEEP}

W30_UNI_CLUSTER = """
            <h2>University application — batch 2 (complete)</h2>
            <ul>
            <li><a href="/guides/university-application-pdf-workflow-usa">USA</a> · <a href="/guides/university-application-pdf-workflow-uk">UK</a> · <a href="/guides/university-application-pdf-workflow-canada">Canada</a></li>
            <li><a href="/guides/university-application-pdf-workflow-mexico">Mexico</a> · <a href="/guides/university-application-pdf-workflow-netherlands">Netherlands</a> · <a href="/guides/university-application-pdf-workflow-germany">Germany</a></li>
            <li><a href="/guides/university-application-pdf-workflow-singapore">Singapore</a> · <a href="/guides/university-application-pdf-workflow-uae">UAE</a> · <a href="/guides/university-application-pdf-workflow-spain">Spain</a></li>
            <li><a href="/guides/university-application-pdf-workflow-new-zealand">New Zealand</a> · <a href="/guides/university-application-pdf-workflow-south-africa">South Africa</a> · <a href="/guides/university-application-pdf-workflow-south-korea">South Korea</a></li>
            </ul>
            <p>Batch 1: <a href="/guides/university-application-pdf-workflow-australia">Australia</a> · <a href="/guides/university-application-pdf-workflow-india">India</a> · Hub: <a href="/guides/compress-pdf-for-university-application">university compress</a></p>
            """

W30_COMPRESS_CLUSTER = """
            <h2>Compression technical cluster</h2>
            <ul>
            <li><a href="/guides/why-is-pdf-file-so-large">Why PDF is large</a></li>
            <li><a href="/guides/compress-scanned-vs-digital-pdf">Scanned vs digital compress</a></li>
            <li><a href="/guides/ghostscript-pdf-compression">Ghostscript explained</a></li>
            <li><a href="/guides/compress-bank-statement-pdf">Compress bank statement</a></li>
            <li><a href="/guides/compress-pdf-accountants">Compress for accountants</a></li>
            <li><a href="/guides/compress-pdf-lawyers">Compress for lawyers</a></li>
            <li><a href="/guides/irs-tax-pdf-format">IRS tax PDF format</a></li>
            </ul>
            <p>Pillar: <a href="/guides/compress-pdf-guide">compress PDF guide</a> · <a href="/guides/pdf-compression-benchmark">benchmark</a></p>
            """

W30_UNI_TOPUP = """
            <h2>University PDF pack checklist</h2>
            <ol>
            <li>Portal FAQ — one PDF per slot vs merge allowed</li>
            <li>200–300 DPI scans — single compress after final merge</li>
            <li>IDs, seals, roll numbers readable at 100% zoom</li>
            <li>Admission PDFs separate from study visa evidence</li>
            <li>UCAS/Common App specific guides for UK and USA</li>
            </ol>
            """

W30_COMPRESS_TOPUP = """
            <h2>Compression QA checklist</h2>
            <ol>
            <li>Digital vs scan — pick Less for scans, Recommended for digital</li>
            <li>One compress pass after merge — avoid double compression</li>
            <li>Verify critical numbers and signatures at 100% zoom</li>
            <li>Archive uncompressed master — compress delivery copy only</li>
            <li>Split if portal still rejects after Recommended</li>
            </ol>
            """

W30_CLOSING = """
            <h2>Related guides</h2>
            <p>University application set is now complete across all regional workflows. Compression technical pages support bank, legal, and accountant portal uploads.</p>
            <p>Hub: <a href="/guides/pdf-regional-workflows-hub">regional workflows</a> · <a href="/guides/compress-pdf-guide">compress guide</a></p>
            """
