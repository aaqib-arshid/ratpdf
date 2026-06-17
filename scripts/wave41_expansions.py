"""Wave 41 — CREATE batch 5 (17 guides, score 80–82). Asia-Pacific visa + HIPAA/forms/compress."""

W41_SLUGS = [
    "visa-application-pdf-workflow-kenya",
    "visa-application-pdf-workflow-thailand",
    "visa-application-pdf-workflow-vietnam",
    "visa-application-pdf-workflow-indonesia",
    "visa-application-pdf-workflow-malaysia",
    "visa-application-pdf-workflow-philippines",
    "visa-application-pdf-workflow-china",
    "visa-application-pdf-workflow-taiwan",
    "visa-application-pdf-workflow-hong-kong",
    "nitro-pdf-alternative",
    "healthcare-pdf-hipaa-email",
    "scan-notes-to-pdf-study",
    "pdf-error-secured-document",
    "compress-pdf-service-canada",
    "lossless-pdf-compression",
    "pdf-form-not-saving",
    "pdf-ua-compliance-guide",
]

VISA_CREATE_SLUGS = {
    "visa-application-pdf-workflow-kenya",
    "visa-application-pdf-workflow-thailand",
    "visa-application-pdf-workflow-vietnam",
    "visa-application-pdf-workflow-indonesia",
    "visa-application-pdf-workflow-malaysia",
    "visa-application-pdf-workflow-philippines",
    "visa-application-pdf-workflow-china",
    "visa-application-pdf-workflow-taiwan",
    "visa-application-pdf-workflow-hong-kong",
}

COMPARE_CREATE_SLUGS = {"nitro-pdf-alternative"}

HEALTH_CREATE_SLUGS = {"healthcare-pdf-hipaa-email"}

STUDENT_CREATE_SLUGS = {"scan-notes-to-pdf-study"}

TROUBLESHOOT_CREATE_SLUGS = {"pdf-error-secured-document", "pdf-form-not-saving"}

GOVT_CREATE_SLUGS = {"compress-pdf-service-canada"}

COMPRESS_CREATE_SLUGS = {"lossless-pdf-compression"}

ACCESSIBILITY_CREATE_SLUGS = {"pdf-ua-compliance-guide"}

W41_VISA_META = {
    "kenya": ("Kenya", "eVisa &amp; VFS Nairobi", "Applicant compresses sponsor bank PDF and invitation letter for Kenya eVisa slot"),
    "thailand": ("Thailand", "Embassy &amp; eVisa", "Tourist merges hotel booking, funds, and itinerary PDF for Thailand visa upload"),
    "vietnam": ("Vietnam", "eVisa Portal", "Business visitor compresses company letter and passport bio PDF for Vietnam eVisa"),
    "indonesia": ("Indonesia", "eVisa &amp; Embassy", "Digital nomad compresses funds and remote-work statement PDF for Indonesia visa"),
    "malaysia": ("Malaysia", "eVisa MDAC", "Student merges admission letter and sponsor bank PDF for Malaysia visa portal"),
    "philippines": ("Philippines", "Embassy &amp; eTravel", "Worker compresses employment contract and NBI clearance scan PDF"),
    "china": ("China", "Embassy &amp; CVASC", "Applicant compresses invitation letter and bank statement PDF for China visa center"),
    "taiwan": ("Taiwan", "Bureau of Consular Affairs", "Researcher merges admission and financial proof PDF for Taiwan visa"),
    "hong-kong": ("Hong Kong", "Entry Permit &amp; Visa", "Visitor compresses sponsor letter and funds PDF for Hong Kong visa application"),
}

W41_DATA = {
    "nitro-pdf-alternative": {
        "title": "Nitro PDF Alternative — Browser vs Desktop (2026)",
        "tool": "/compare",
        "label": "compare hub",
        "pillar": "/compare/foxit-alternative",
        "pillar_label": "Foxit alternative",
        "related": "/guides/choose-pdf-tool",
        "prog": "/compare",
        "example": "Legal team drops Nitro Pro renewal — uses browser merge and redaction for occasional tasks on locked laptops",
    },
    "healthcare-pdf-hipaa-email": {
        "title": "Healthcare PDF HIPAA Email — PHI Attachment Rules (2026)",
        "tool": "/pdf/password",
        "label": "Protect PDF",
        "pillar": "/guides/hipaa-pdf-handling",
        "pillar_label": "HIPAA PDF handling",
        "related": "/guides/hipaa-compliant-pdf-email",
        "prog": "/pdf/password",
        "example": "Clinic admin encrypts lab results PDF — password via phone — never in email body",
    },
    "scan-notes-to-pdf-study": {
        "title": "Scan Notes to PDF for Study — Phone to Searchable Pack (2026)",
        "tool": "/pdf/ocrpdf",
        "label": "OCR PDF",
        "pillar": "/guides/ocr-lecture-notes-students",
        "pillar_label": "OCR lecture notes",
        "related": "/guides/student-combine-lecture-pdfs",
        "prog": "/pdf/ocrpdf",
        "example": "Student OCRs 40 whiteboard photos merged to one PDF — Ctrl+F finds midterm topics",
    },
    "pdf-error-secured-document": {
        "title": "Secured PDF Cannot Be Edited — Fix Permission Errors (2026)",
        "tool": "/pdf/unlockpdf",
        "label": "Unlock PDF",
        "pillar": "/guides/pdf-password-not-working",
        "pillar_label": "PDF password not working",
        "related": "/guides/unlock-pdf",
        "prog": "/pdf/unlockpdf",
        "example": "User gets secured document error editing IRS PDF — owner password required for changes",
    },
    "compress-pdf-service-canada": {
        "title": "Compress PDF for Service Canada — GCKey Upload (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/compress-pdf-immigration-canada",
        "pillar_label": "compress IRCC Canada",
        "related": "/guides/government-portal-pdf-compress",
        "prog": "/compress-pdf-for-government-forms",
        "example": "Applicant compresses citizenship support scan from 6 MB to 3 MB for Service Canada portal",
    },
    "lossless-pdf-compression": {
        "title": "Lossless PDF Compression — When Less Preset Wins (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/compress-pdf-without-losing-quality",
        "pillar_label": "compress without losing quality",
        "related": "/guides/compress-scanned-vs-digital-pdf",
        "prog": "/compress-pdf",
        "example": "Archivist compresses digital annual report PDF 12 MB → 9 MB with Less — logos sharp at 100% zoom",
    },
    "pdf-form-not-saving": {
        "title": "PDF Form Not Saving — Fill, Flatten &amp; Fix (2026)",
        "tool": "/pdf/flattenpdf",
        "label": "Flatten PDF",
        "pillar": "/guides/fill-pdf-form-online",
        "pillar_label": "fill PDF form online",
        "related": "/guides/create-fillable-pdf",
        "prog": "/pdf/flattenpdf",
        "example": "User fills government PDF in browser — save disabled — flatten bakes values for upload",
    },
    "pdf-ua-compliance-guide": {
        "title": "PDF/UA Compliance Guide — Tagged PDF Checklist (2026)",
        "tool": "/pdf/ocrpdf",
        "label": "OCR PDF",
        "pillar": "/guides/pdf-ua-accessibility",
        "pillar_label": "PDF/UA accessibility",
        "related": "/guides/glossary-pdf-ua",
        "prog": "/pdf/ocrpdf",
        "example": "Publisher runs tagged PDF checklist before government RFP — alt text on figures — reading order QA",
    },
}

for country, (name, subtitle, example) in W41_VISA_META.items():
    slug = f"visa-application-pdf-workflow-{country}"
    merge_countries = {"thailand", "malaysia", "taiwan", "hong-kong"}
    use_merge = country in merge_countries
    W41_DATA[slug] = {
        "title": f"Visa Application PDF Workflow {name} — {subtitle} (2026)",
        "tool": "/pdf/merge" if use_merge else "/pdf/compress",
        "label": "Merge PDF" if use_merge else "Compress PDF",
        "pillar": "/guides/merge-pdf-visa-application",
        "pillar_label": "merge PDF for visa",
        "related": "/guides/compress-pdf-for-visa-application",
        "prog": "/compress-pdf-for-visa-application",
        "example": example,
        "country": name,
    }


def _d(slug: str, html: str) -> str:
    p = W41_DATA[slug].get("prog", "")
    tail = f'<p>Tool: <a href="{p}">{p}</a></p>' if p else ""
    return html + tail


def _visa_deep(slug: str) -> str:
    d = W41_DATA[slug]
    name = d["country"]
    return _d(
        slug,
        f"""
            <h2>{name} visa PDF workflow</h2>
            <ol>
            <li>Official PDF exports — bank, employment, invitation</li>
            <li><a href="/pdf/merge">Merge</a> per embassy checklist if one slot</li>
            <li><a href="/pdf/compress">Compress</a> once — Less on scans</li>
            <li>Filename: LastName_DocumentType.pdf</li>
            </ol>
            <p>Hub: <a href="/guides/pdf-regional-workflows-hub">regional workflows</a> · <a href="/guides/bank-statement-pdf-visa">bank statement visa</a> · neighbors: <a href="/guides/visa-application-pdf-workflow-south-korea">South Korea</a> · <a href="/guides/visa-application-pdf-workflow-australia">Australia</a>.</p>
            """,
    )


W41_DEEP = {
    "nitro-pdf-alternative": _d("nitro-pdf-alternative", """
            <h2>Nitro vs browser</h2>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>Need</th><th>Nitro Pro</th><th>Browser</th></tr></thead>
            <tbody>
            <tr><td>No IT install</td><td>Desktop license</td><td>Chrome/Edge OK</td></tr>
            <tr><td>Batch OCR folder</td><td>Strong</td><td>Per-file upload</td></tr>
            <tr><td>Occasional merge</td><td>Overkill</td><td>Free tier</td></tr>
            </tbody></table></div>
            <p><a href="/compare/foxit-alternative">Foxit alternative</a> · <a href="/guides/pdfgear-alternative">PDFgear guide</a>.</p>
            """),
    "healthcare-pdf-hipaa-email": _d("healthcare-pdf-hipaa-email", """
            <h2>HIPAA email rules</h2>
            <ul>
            <li>Minimum necessary PHI in attachment</li>
            <li><a href="/pdf/password">Encrypt</a> — password separate channel</li>
            <li>Business associate agreement if vendor processes files</li>
            <li>Audit log who received what</li>
            </ul>
            <p><a href="/guides/hipaa-compliant-pdf-email">HIPAA compliant email</a> · <a href="/guides/compress-pdf-healthcare-admin">healthcare compress</a>.</p>
            """),
    "scan-notes-to-pdf-study": _d("scan-notes-to-pdf-study", """
            <h2>Study notes workflow</h2>
            <ol>
            <li>Phone photos — crop — <a href="/pdf/convertimages">Images to PDF</a></li>
            <li><a href="/pdf/ocrpdf">OCR</a> for Ctrl+F before exams</li>
            <li><a href="/pdf/compress">Compress</a> before sharing study group</li>
            </ol>
            <p><a href="/guides/ocr-handwriting-pdf">OCR handwriting limits</a> · <a href="/guides/pdf-workflow-students">student workflow</a>.</p>
            """),
    "pdf-error-secured-document": _d("pdf-error-secured-document", """
            <h2>Secured document error</h2>
            <p>Owner password locks editing — user password may only allow view/print.</p>
            <ul>
            <li>Ask sender for owner password or unprotected copy</li>
            <li>If authorized: <a href="/pdf/unlockpdf">Unlock PDF</a></li>
            <li>Do not bypass DRM you do not own</li>
            </ul>
            <p><a href="/guides/pdf-password-not-working">Password troubleshooting</a>.</p>
            """),
    "compress-pdf-service-canada": _d("compress-pdf-service-canada", """
            <h2>Service Canada vs IRCC</h2>
            <p>Service Canada portals (employment insurance, passports in some flows) — separate from IRCC ImmiAccount.</p>
            <p><a href="/guides/compress-pdf-immigration-canada">IRCC compress</a> · 4 MB common cap — Less on scans.</p>
            """),
    "lossless-pdf-compression": _d("lossless-pdf-compression", """
            <h2>Lossless in practice</h2>
            <p>True lossless rare on JPEG scans — Less preset on born-digital PDFs preserves vector logos.</p>
            <p>Avoid double Extreme — <a href="/guides/compress-pdf-made-file-larger">compress made larger</a>.</p>
            """),
    "pdf-form-not-saving": _d("pdf-form-not-saving", """
            <h2>Why save fails</h2>
            <ul>
            <li>Flat scan masquerading as form — needs OCR + Word</li>
            <li>Browser viewer read-only — download and fill in Acrobat</li>
            <li>XFA legacy forms — limited browser support</li>
            </ul>
            <p><a href="/pdf/flattenpdf">Flatten</a> after fill · <a href="/guides/glossary-xfa-forms">XFA glossary</a>.</p>
            """),
    "pdf-ua-compliance-guide": _d("pdf-ua-compliance-guide", """
            <h2>PDF/UA checklist</h2>
            <ol>
            <li>Tagged structure tree — headings H1–H3</li>
            <li>Alt text on meaningful images</li>
            <li>Reading order matches visual order</li>
            <li>Forms labeled — not color-only cues</li>
            </ol>
            <p><a href="/guides/pdf-ua-accessibility">PDF/UA pillar</a> · <a href="/guides/glossary-pdf-ua">glossary PDF/UA</a>.</p>
            """),
}

for country in W41_VISA_META:
    W41_DEEP[f"visa-application-pdf-workflow-{country}"] = _visa_deep(f"visa-application-pdf-workflow-{country}")

W41_CREATE_CLUSTER = """
            <h2>CREATE batch 5</h2>
            <ul>
            <li>Asia-Pacific visa: <a href="/guides/visa-application-pdf-workflow-thailand">Thailand</a> · <a href="/guides/visa-application-pdf-workflow-vietnam">Vietnam</a> · <a href="/guides/visa-application-pdf-workflow-indonesia">Indonesia</a></li>
            <li><a href="/guides/visa-application-pdf-workflow-malaysia">Malaysia</a> · <a href="/guides/visa-application-pdf-workflow-philippines">Philippines</a> · <a href="/guides/visa-application-pdf-workflow-china">China</a></li>
            <li><a href="/guides/visa-application-pdf-workflow-taiwan">Taiwan</a> · <a href="/guides/visa-application-pdf-workflow-hong-kong">Hong Kong</a> · <a href="/guides/visa-application-pdf-workflow-kenya">Kenya</a></li>
            <li><a href="/guides/nitro-pdf-alternative">Nitro alternative</a> · <a href="/guides/healthcare-pdf-hipaa-email">HIPAA email</a> · <a href="/guides/scan-notes-to-pdf-study">Scan notes study</a></li>
            <li><a href="/guides/pdf-error-secured-document">Secured PDF error</a> · <a href="/guides/compress-pdf-service-canada">Service Canada</a></li>
            <li><a href="/guides/lossless-pdf-compression">Lossless compress</a> · <a href="/guides/pdf-form-not-saving">Form not saving</a> · <a href="/guides/pdf-ua-compliance-guide">PDF/UA compliance</a></li>
            </ul>
            <p>Prior: <a href="/guides/visa-application-pdf-workflow-argentina">batch 4 visa</a> · <a href="/guides/pdf-job-application-size-limit">batch 3</a></p>
            """

W41_ASIA_VISA_CLUSTER = """
            <h2>Asia-Pacific visa hubs (Wave 41)</h2>
            <p>ASEAN: <a href="/guides/visa-application-pdf-workflow-thailand">Thailand</a> · <a href="/guides/visa-application-pdf-workflow-vietnam">Vietnam</a> · <a href="/guides/visa-application-pdf-workflow-indonesia">Indonesia</a> · <a href="/guides/visa-application-pdf-workflow-malaysia">Malaysia</a> · <a href="/guides/visa-application-pdf-workflow-philippines">Philippines</a></p>
            <p>Greater China: <a href="/guides/visa-application-pdf-workflow-china">China</a> · <a href="/guides/visa-application-pdf-workflow-taiwan">Taiwan</a> · <a href="/guides/visa-application-pdf-workflow-hong-kong">Hong Kong</a></p>
            <p>Africa: <a href="/guides/visa-application-pdf-workflow-kenya">Kenya</a> · <a href="/guides/visa-application-pdf-workflow-nigeria">Nigeria</a> · hub: <a href="/guides/pdf-regional-workflows-hub">regional index</a></p>
            """

W41_COMPRESS_TOPUP = """
            <h2>CREATE batch 5 checklist</h2>
            <ol>
            <li>Asia visa: read eVisa portal FAQ per country</li>
            <li>Official bank PDF — not screenshot</li>
            <li>One compress after merge</li>
            <li>HIPAA: encrypt PHI — separate password channel</li>
            </ol>
            """

W41_CLOSING = """
            <h2>Related guides</h2>
            <p>Wave 41 adds nine Asia-Pacific and Kenya visa workflows plus Nitro alternative, HIPAA email, study OCR, Service Canada compress, lossless compression, form troubleshooting, and PDF/UA compliance — CREATE batch 5 of 450.</p>
            <p>Hub: <a href="/guides/pdf-regional-workflows-hub">regional workflows</a> · CREATE remaining: 365</p>
            """
