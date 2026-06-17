"""Wave 37 — CREATE batch 1 (17 new editorial guides, score 86–92)."""

W37_SLUGS = [
    "pdf-too-large-to-email",
    "compress-pdf-to-100kb",
    "reduce-pdf-file-size",
    "compress-pdf-for-government-portal",
    "compress-pdf-to-200kb",
    "compress-pdf-without-losing-quality",
    "compress-pdf-to-500kb",
    "make-scanned-pdf-searchable",
    "government-portal-pdf-compress",
    "ats-friendly-pdf-resume",
    "compress-pdf-under-1mb",
    "replace-text-in-pdf",
    "redact-pdf-permanently",
    "print-to-pdf-mac",
    "passport-scan-pdf-size",
    "irs-pdf-form-fill-online",
    "compare-two-pdfs",
]

COMPRESS_CREATE_SLUGS = {
    "pdf-too-large-to-email",
    "compress-pdf-to-100kb",
    "reduce-pdf-file-size",
    "compress-pdf-for-government-portal",
    "compress-pdf-to-200kb",
    "compress-pdf-without-losing-quality",
    "compress-pdf-to-500kb",
    "government-portal-pdf-compress",
    "compress-pdf-under-1mb",
}

OCR_CREATE_SLUGS = {"make-scanned-pdf-searchable"}

JOB_CREATE_SLUGS = {"ats-friendly-pdf-resume", "passport-scan-pdf-size"}

EDIT_CREATE_SLUGS = {"replace-text-in-pdf", "compare-two-pdfs"}

SECURITY_CREATE_SLUGS = {"redact-pdf-permanently"}

DEVICE_CREATE_SLUGS = {"print-to-pdf-mac"}

GOVT_CREATE_SLUGS = {"irs-pdf-form-fill-online"}

W37_DATA = {
    "pdf-too-large-to-email": {
        "title": "PDF Too Large to Email — Compress, Split &amp; Send (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/compress-pdf-guide",
        "pillar_label": "compress PDF guide",
        "related": "/guides/pdf-file-too-large-to-email",
        "prog": "/compress-pdf-for-email",
        "example": "Sales rep gets bounce-back on 28 MB proposal — compress to 19 MB safe zone then resend same day",
    },
    "compress-pdf-to-100kb": {
        "title": "Compress PDF to 100KB — Portal &amp; Form Caps (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/compress-pdf-guide",
        "pillar_label": "compress PDF guide",
        "related": "/guides/compress-pdf-to-200kb",
        "prog": "/compress-pdf-to-100kb",
        "example": "Applicant must upload passport scan under 100 KB — Extreme compress after 200 DPI grayscale scan",
    },
    "reduce-pdf-file-size": {
        "title": "Reduce PDF File Size — Step-by-Step Without Blur (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/why-is-pdf-file-so-large",
        "pillar_label": "why PDF is large",
        "related": "/guides/compress-scanned-vs-digital-pdf",
        "prog": "/compress-pdf",
        "example": "Office manager shrinks board pack from 22 MB to 8 MB — one Recommended pass on digital export",
    },
    "compress-pdf-for-government-portal": {
        "title": "Compress PDF for Government Portal — Size &amp; Quality Rules (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/compress-pdf-for-government-forms",
        "pillar_label": "government forms compress",
        "related": "/guides/government-portal-pdf-compress",
        "prog": "/compress-pdf-for-government-forms",
        "example": "Citizen uploads permit annex — portal rejects 4.2 MB — compress to 2.8 MB with stamps still readable",
    },
    "compress-pdf-to-200kb": {
        "title": "Compress PDF to 200KB — Online Forms &amp; Job Portals (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/compress-pdf-to-100kb",
        "pillar_label": "compress to 100KB",
        "related": "/guides/compress-pdf-to-500kb",
        "prog": "/compress-pdf-to-200kb",
        "example": "Job portal caps certificate at 200 KB — Less then Extreme — verify signature line at zoom",
    },
    "compress-pdf-without-losing-quality": {
        "title": "Compress PDF Without Losing Quality — Presets &amp; QA (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/compress-pdf-guide",
        "pillar_label": "compress PDF guide",
        "related": "/guides/compress-scanned-vs-digital-pdf",
        "prog": "/compress-pdf",
        "example": "Law firm compresses exhibit for e-filing — Less preset — account numbers legible at 100% zoom",
    },
    "compress-pdf-to-500kb": {
        "title": "Compress PDF to 500KB — Mid-Range Portal Targets (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/compress-pdf-to-200kb",
        "pillar_label": "compress to 200KB",
        "related": "/guides/compress-pdf-under-1mb",
        "prog": "/compress-pdf-to-500kb",
        "example": "University portal allows 500 KB per slot — transcript compress passes after Recommended",
    },
    "make-scanned-pdf-searchable": {
        "title": "Make Scanned PDF Searchable — OCR Workflow (2026)",
        "tool": "/pdf/ocrpdf",
        "label": "OCR PDF",
        "pillar": "/guides/how-to-make-pdf-searchable",
        "pillar_label": "make PDF searchable",
        "related": "/guides/how-to-ocr-a-scanned-pdf",
        "prog": "/pdf/ocrpdf",
        "example": "Paralegal OCRs 1990s discovery scan — Ctrl+F finds witness name across 800 pages",
    },
    "government-portal-pdf-compress": {
        "title": "Government Portal PDF Compress — India, US &amp; EU Caps (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/compress-pdf-for-government-portal",
        "pillar_label": "government portal compress",
        "related": "/guides/compress-pdf-digilocker",
        "prog": "/compress-pdf-for-government-forms",
        "example": "GST portal rejects 5 MB statement — compress to 3 MB — QR on invoice still scannable",
    },
    "ats-friendly-pdf-resume": {
        "title": "ATS-Friendly PDF Resume — Text, Size &amp; Format Rules (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/compress-pdf-for-job-application",
        "pillar_label": "compress for job application",
        "related": "/guides/combine-resume-cover-letter-pdf",
        "prog": "/compress-pdf-for-job-application",
        "example": "Graduate exports Word resume to PDF — single column — 450 KB — passes Workday parser test",
    },
    "compress-pdf-under-1mb": {
        "title": "Compress PDF Under 1MB — Email &amp; Portal Safe Zone (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/compress-pdf-guide",
        "pillar_label": "compress PDF guide",
        "related": "/guides/compress-pdf-to-500kb",
        "prog": "/compress-pdf-to-1mb",
        "example": "Consultant targets 900 KB for client firewall — digital PDF one Recommended pass hits 850 KB",
    },
    "replace-text-in-pdf": {
        "title": "Replace Text in PDF — Edit vs Redact vs Re-Export (2026)",
        "tool": "/pdf/editpdf",
        "label": "Edit PDF",
        "pillar": "/guides/edit-pdf-guide",
        "pillar_label": "edit PDF guide",
        "related": "/guides/pdf-to-word",
        "prog": "/pdf/editpdf",
        "example": "Ops updates price table in digital PDF — Edit PDF tool — not feasible on scanned contract",
    },
    "redact-pdf-permanently": {
        "title": "Redact PDF Permanently — True Removal Workflow (2026)",
        "tool": "/pdf-redaction",
        "label": "PDF Redaction",
        "pillar": "/guides/pdf-redaction-permanent",
        "pillar_label": "permanent redaction guide",
        "related": "/guides/pdf-redaction-vs-black-box",
        "prog": "/pdf-redaction",
        "example": "FOIA officer redacts SSN — copy-paste test empty — counsel signs production log",
    },
    "print-to-pdf-mac": {
        "title": "Print to PDF on Mac — Save as PDF Workflow (2026)",
        "tool": "/pdf/doctopdf",
        "label": "Word to PDF",
        "pillar": "/guides/password-protect-pdf-mac",
        "pillar_label": "password protect Mac",
        "related": "/guides/beginner-pdf-page-size-a4-letter",
        "prog": "/pdf/doctopdf",
        "example": "Designer uses Print → Save as PDF from Safari — then compress for email under 10 MB",
    },
    "passport-scan-pdf-size": {
        "title": "Passport Scan PDF Size — DPI &amp; KB Limits for Visas (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/compress-pdf-for-visa-application",
        "pillar_label": "compress for visa",
        "related": "/guides/visa-application-pdf-workflow-usa",
        "prog": "/compress-pdf-for-passport-application",
        "example": "Tourist visa portal wants passport bio page under 300 KB — 200 DPI crop then compress",
    },
    "irs-pdf-form-fill-online": {
        "title": "IRS PDF Form Fill Online — Fill, Flatten &amp; Submit (2026)",
        "tool": "/pdf/flattenpdf",
        "label": "Flatten PDF",
        "pillar": "/guides/irs-tax-pdf-format",
        "pillar_label": "IRS tax PDF format",
        "related": "/guides/glossary-acroform",
        "prog": "/pdf/flattenpdf",
        "example": "Taxpayer fills W-9 in browser — flattens fields — uploads 1.2 MB to payer portal",
    },
    "compare-two-pdfs": {
        "title": "Compare Two PDFs — Diff Text &amp; Spot Changes (2026)",
        "tool": "/text-comparer",
        "label": "Text comparer",
        "pillar": "/guides/pdf-tools",
        "pillar_label": "PDF tools hub",
        "related": "/guides/contract-pdf-redline-workflow",
        "prog": "/pdf/pdftotext",
        "example": "Procurement extracts text from v1 and v2 SOW PDF — text comparer highlights clause delta",
    },
}

def _deep(slug: str, body: str) -> str:
    d = W37_DATA[slug]
    prog = d.get("prog", "")
    prog_html = f'<p>Quick tool: <a href="{prog}">programmatic landing</a> · Editorial depth below.</p>' if prog else ""
    return body + prog_html

W37_DEEP = {
    "pdf-too-large-to-email": _deep("pdf-too-large-to-email", """
            <h2>Why email rejects PDFs</h2>
            <p>Gmail ~25 MB, Outlook often 20 MB — Base64 overhead adds ~33% — a 20 MB file may fail. Corporate gateways set lower caps than provider marketing pages.</p>
            <h2>Fix order</h2>
            <ol>
            <li><a href="/pdf/compress">Compress PDF</a> — Recommended on digital; Less on scans</li>
            <li>Still over? <a href="/pdf/split">Split PDF</a> — Part1of3 naming</li>
            <li>Password-protect sensitive split parts separately</li>
            </ol>
            <p>Related: <a href="/guides/pdf-file-too-large-to-email">file too large (troubleshooting)</a> · <a href="/guides/email-attachment-size-limits-2026">email limits 2026</a> · <a href="/guides/compress-vs-split">compress vs split</a>.</p>
            """),
    "compress-pdf-to-100kb": _deep("compress-pdf-to-100kb", """
            <h2>When you need 100 KB</h2>
            <p>Passport uploads, some government forms, legacy job portals — aggressive target — often requires scan hygiene first.</p>
            <h2>Workflow</h2>
            <ol>
            <li>Scan 200 DPI grayscale — crop margins</li>
            <li><a href="/pdf/compress">Compress</a> — try Less then Extreme</li>
            <li>Verify MRZ and stamps at 100% zoom</li>
            </ol>
            <p>Programmatic tool: <a href="/compress-pdf-to-100kb">/compress-pdf-to-100kb</a> · Pillar: <a href="/guides/compress-pdf-guide">compress guide</a> · <a href="/guides/passport-scan-pdf-size">passport scan size</a>.</p>
            """),
    "reduce-pdf-file-size": _deep("reduce-pdf-file-size", """
            <h2>Diagnose first</h2>
            <p>Digital Word export vs 600 DPI phone scan — different fixes — <a href="/guides/why-is-pdf-file-so-large">why large</a> · <a href="/guides/compress-scanned-vs-digital-pdf">scanned vs digital</a>.</p>
            <h2>Reduce steps</h2>
            <ul>
            <li>Re-export images at lower DPI in source app</li>
            <li>Subset fonts on export</li>
            <li>Single <a href="/pdf/compress">compress</a> pass after merge</li>
            </ul>
            <p>Avoid double-compression — <a href="/guides/compress-pdf-without-losing-quality">without losing quality</a>.</p>
            """),
    "compress-pdf-for-government-portal": _deep("compress-pdf-for-government-portal", """
            <h2>Portal patterns</h2>
            <p>Fixed MB cap, per-file slot, or per-page DPI rules — read FAQ before Extreme compress on notarized pages.</p>
            <h2>Regional hubs</h2>
            <ul>
            <li><a href="/guides/compress-pdf-incometax">Income Tax India</a></li>
            <li><a href="/guides/compress-pdf-efiling">E-filing compress</a></li>
            <li><a href="/guides/government-portal-pdf-compress">government portal compress</a></li>
            </ul>
            <p>Tool: <a href="/compress-pdf-for-government-forms">government forms landing</a> · <a href="/pdf/compress">Compress PDF</a>.</p>
            """),
    "compress-pdf-to-200kb": _deep("compress-pdf-to-200kb", """
            <h2>200 KB targets</h2>
            <p>Common for certificates and ID uploads — between 100 KB and 500 KB difficulty — start with clean scan.</p>
            <p>Landing: <a href="/compress-pdf-to-200kb">/compress-pdf-to-200kb</a> · Neighbors: <a href="/guides/compress-pdf-to-100kb">100 KB</a> · <a href="/guides/compress-pdf-to-500kb">500 KB</a> guides.</p>
            """),
    "compress-pdf-without-losing-quality": _deep("compress-pdf-without-losing-quality", """
            <h2>Quality-safe presets</h2>
            <p><strong>Less</strong> for scans with signatures — <strong>Recommended</strong> for digital text PDFs — avoid Extreme on legal exhibits without QA.</p>
            <h2>QA checklist</h2>
            <ol>
            <li>100% zoom on stamps and footnotes</li>
            <li>Ctrl+F still finds key terms on digital PDFs</li>
            <li>Compare file size before/after in ticket log</li>
            </ol>
            <p>Benchmark: <a href="/guides/ghostscript-pdf-compression">Ghostscript explained</a> · <a href="/research/pdf-compression-benchmark">research</a>.</p>
            """),
    "compress-pdf-to-500kb": _deep("compress-pdf-to-500kb", """
            <h2>500 KB use cases</h2>
            <p>University transcripts, insurance proof uploads — moderate cap — Recommended often sufficient on digital exports.</p>
            <p><a href="/compress-pdf-to-500kb">Programmatic page</a> · chain: <a href="/guides/compress-pdf-to-200kb">200 KB</a> → <a href="/guides/compress-pdf-under-1mb">under 1 MB</a>.</p>
            """),
    "make-scanned-pdf-searchable": _deep("make-scanned-pdf-searchable", """
            <h2>OCR workflow</h2>
            <ol>
            <li>300 DPI grayscale scan — deskew</li>
            <li><a href="/pdf/ocrpdf">OCR PDF</a> — correct language</li>
            <li>Test Ctrl+F and copy-paste</li>
            <li>Optional <a href="/pdf/pdftotext">PDF to Text</a> export</li>
            </ol>
            <p>How-to: <a href="/guides/how-to-make-pdf-searchable">make searchable</a> · <a href="/guides/how-to-ocr-a-scanned-pdf">OCR scanned PDF</a> · tips: <a href="/guides/ocr-accuracy-tips">OCR accuracy</a>.</p>
            """),
    "government-portal-pdf-compress": _deep("government-portal-pdf-compress", """
            <h2>By region</h2>
            <p>India DigiLocker/GST, US USCIS/IRS, EU e-government — caps differ — never one-size Extreme globally.</p>
            <h2>Workflow</h2>
            <p>Read portal FAQ → compress once → if reject, split not re-compress same file — <a href="/guides/compress-pdf-for-government-portal">government portal guide</a>.</p>
            """),
    "ats-friendly-pdf-resume": _deep("ats-friendly-pdf-resume", """
            <h2>ATS rules</h2>
            <ul>
            <li>Single column — no text boxes floating</li>
            <li>Standard fonts — embed subset</li>
            <li>Text selectable — not image-only scan</li>
            <li>Under 2 MB — <a href="/guides/compress-pdf-under-1mb">under 1 MB</a> safer</li>
            </ul>
            <p>Export from Word/Google Docs — avoid Canva image resume — merge cover letter in CREATE batch 2.</p>
            """),
    "compress-pdf-under-1mb": _deep("compress-pdf-under-1mb", """
            <h2>Why 1 MB</h2>
            <p>Safe for most email and HR portals — headroom below Gmail effective cap — digital PDFs often hit target in one pass.</p>
            <p><a href="/compress-pdf-to-1mb">1 MB landing</a> · <a href="/guides/pdf-too-large-to-email">too large for email</a> · <a href="/guides/reduce-pdf-file-size">reduce file size</a>.</p>
            """),
    "replace-text-in-pdf": _deep("replace-text-in-pdf", """
            <h2>When replace works</h2>
            <p>Born-digital PDF with real text objects — <a href="/pdf/editpdf">Edit PDF</a> — change words in place.</p>
            <h2>When it does not</h2>
            <p>Scanned pages — need OCR + Word round-trip <a href="/pdf/pdftodoc">PDF to Word</a> — or overlay white box + new text (not ideal for legal).</p>
            <p>Contracts: use <a href="/pdf/pdftodoc">PDF to Word</a> for clause edits on digital PDFs.</p>
            """),
    "redact-pdf-permanently": _deep("redact-pdf-permanently", """
            <h2>Permanent vs black box</h2>
            <p>True redaction removes content — <a href="/guides/pdf-redaction-vs-black-box">vs black box</a> — verify Ctrl+F and paste.</p>
            <h2>Workflow</h2>
            <ol>
            <li>Duplicate master</li>
            <li><a href="/pdf-redaction">PDF Redaction</a></li>
            <li>QA — log approver</li>
            </ol>
            <p>Pillar: <a href="/guides/pdf-redaction-permanent">permanent redaction</a> · GDPR: <a href="/guides/redact-pdf-gdpr">redact GDPR</a>.</p>
            """),
    "print-to-pdf-mac": _deep("print-to-pdf-mac", """
            <h2>Mac methods</h2>
            <ul>
            <li><strong>Print → Save as PDF</strong> — any app</li>
            <li>Preview Export</li>
            <li>Browser print to PDF</li>
            <li>RatPDF <a href="/pdf/doctopdf">Word to PDF</a> for DOCX</li>
            </ul>
            <p>Then <a href="/pdf/compress">compress</a> for email — encrypt: <a href="/guides/password-protect-pdf-mac">password Mac</a>.</p>
            """),
    "passport-scan-pdf-size": _deep("passport-scan-pdf-size", """
            <h2>Scan settings</h2>
            <p>Bio page only — 200–300 DPI — crop — grayscale often enough — MRZ must stay sharp.</p>
            <h2>Compress</h2>
            <p><a href="/compress-pdf-for-passport-application">passport landing</a> · <a href="/guides/compress-pdf-to-100kb">100 KB guide</a> · visa: <a href="/guides/compress-pdf-for-visa-application">visa compress</a>.</p>
            """),
    "irs-pdf-form-fill-online": _deep("irs-pdf-form-fill-online", """
            <h2>Fillable IRS PDFs</h2>
            <p>AcroForm fields — fill in Acrobat or browser — <a href="/pdf/flattenpdf">flatten</a> before archive — some portals reject editable fields.</p>
            <p>Format: <a href="/guides/irs-tax-pdf-format">IRS tax PDF format</a> · <a href="/guides/compress-pdf-for-government-portal">government portal compress</a>.</p>
            """),
    "compare-two-pdfs": _deep("compare-two-pdfs", """
            <h2>Compare workflow</h2>
            <ol>
            <li><a href="/pdf/pdftotext">PDF to Text</a> on version A and B</li>
            <li>Paste into <a href="/text-comparer">Text comparer</a></li>
            <li>Review added/removed clauses</li>
            </ol>
            <p>Visual PDF diff tools exist — text diff faster for contracts — see <a href="/guides/edit-pdf-guide">edit PDF guide</a> for change workflows.</p>
            """),
}

W37_CREATE_CLUSTER = """
            <h2>CREATE batch 1 — compress &amp; workflow guides</h2>
            <ul>
            <li><a href="/guides/pdf-too-large-to-email">PDF too large to email</a></li>
            <li><a href="/guides/compress-pdf-to-100kb">Compress to 100KB</a> · <a href="/guides/compress-pdf-to-200kb">200KB</a> · <a href="/guides/compress-pdf-to-500kb">500KB</a></li>
            <li><a href="/guides/compress-pdf-under-1mb">Under 1MB</a> · <a href="/guides/reduce-pdf-file-size">Reduce file size</a></li>
            <li><a href="/guides/compress-pdf-without-losing-quality">Without losing quality</a></li>
            <li><a href="/guides/compress-pdf-for-government-portal">Government portal</a> · <a href="/guides/government-portal-pdf-compress">portal compress</a></li>
            <li><a href="/guides/make-scanned-pdf-searchable">Make searchable</a> · <a href="/guides/ats-friendly-pdf-resume">ATS resume</a></li>
            <li><a href="/guides/passport-scan-pdf-size">Passport scan size</a> · <a href="/guides/irs-pdf-form-fill-online">IRS form fill</a></li>
            <li><a href="/guides/replace-text-in-pdf">Replace text</a> · <a href="/guides/redact-pdf-permanently">Redact permanently</a></li>
            <li><a href="/guides/compare-two-pdfs">Compare two PDFs</a> · <a href="/guides/print-to-pdf-mac">Print to PDF Mac</a></li>
            </ul>
            <p>Programmatic twins: <a href="/compress-pdf-to-100kb">/compress-pdf-to-100kb</a> · <a href="/compress-pdf">/compress-pdf</a></p>
            """

W37_COMPRESS_TOPUP = """
            <h2>CREATE compress checklist</h2>
            <ol>
            <li>Editorial guide at /guides/* — deep workflow — links to programmatic /compress-* landing</li>
            <li>One compress pass after final merge</li>
            <li>Less on scans · Recommended on digital</li>
            <li>Split if portal still rejects after QA</li>
            </ol>
            """

W37_CLOSING = """
            <h2>Related guides</h2>
            <p>Wave 37 launches CREATE batch 1 — seventeen new editorial guides for compression targets, government portals, OCR, ATS resumes, and PDF workflows — distinct from programmatic tool landings.</p>
            <p>Hub: <a href="/guides/compress-pdf-guide">compress guide</a> · <a href="/guides/pdf-tools">PDF tools</a> · CREATE remaining: 433</p>
            """
