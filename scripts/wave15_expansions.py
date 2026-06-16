"""Wave 15 — Regional PDF workflows: visa, bank, contract, India portals (batch 1)."""

W15_SLUGS = [
    "pdf-regional-workflows-hub",
    "visa-application-pdf-workflow-usa",
    "visa-application-pdf-workflow-uk",
    "visa-application-pdf-workflow-canada",
    "visa-application-pdf-workflow-australia",
    "visa-application-pdf-workflow-india",
    "bank-statement-pdf-workflow-usa",
    "bank-statement-pdf-workflow-uk",
    "bank-statement-pdf-workflow-india",
    "contract-pdf-workflow-usa",
    "contract-pdf-workflow-uk",
    "invoice-pdf-workflow-india",
    "tax-document-pdf-workflow-india",
    "university-application-pdf-workflow-india",
    "india-job-portal-pdf-limits",
    "pdf-workflow-government",
    "pdf-tools-government-applicants",
]

COUNTRY = {
    "usa": {
        "name": "United States",
        "portal": "USCIS / embassy portal",
        "cap": "varies by form — often 6–12 MB per upload",
        "compress_slug": "compress-pdf-for-visa-application",
        "visa_note": "DS-160 confirmation, I-20, financials — separate uploads unless portal allows bundle",
    },
    "uk": {
        "name": "United Kingdom",
        "portal": "UKVI / VFS Global",
        "cap": "often 6 MB per document slot",
        "compress_slug": "compress-pdf-ukvi",
        "visa_note": "CAS, bank statements, TB test — check UKVI document list for your visa type",
    },
    "canada": {
        "name": "Canada",
        "portal": "IRCC secure account",
        "cap": "4 MB per file typical on IRCC upload",
        "compress_slug": "compress-pdf-immigration-canada",
        "visa_note": "LOA, proof of funds, police certificate — IRCC rejects oversize silently sometimes",
    },
    "australia": {
        "name": "Australia",
        "portal": "ImmiAccount / Department of Home Affairs",
        "cap": "5 MB per attachment common on ImmiAccount",
        "compress_slug": "compress-pdf-home-affairs-australia",
        "visa_note": "GTE statement, OSHC, financial evidence — ImmiAccount logs upload errors in message centre",
    },
    "india": {
        "name": "India",
        "portal": "embassy / VFS / national portals",
        "cap": "500 KB–5 MB per slot on many e-governance portals",
        "compress_slug": "compress-pdf-for-visa-application",
        "visa_note": "Passport, IT returns, bank statements — DigiLocker exports may need compress",
    },
}

W15_DATA = {
    "pdf-regional-workflows-hub": {
        "title": "PDF Regional Workflows Hub — Visa, Bank &amp; Government by Country (2026)",
        "tool": "/guides/pdf-tools",
        "label": "PDF tools hub",
        "example": "Immigration consultant index linking country visa PDF packs and portal compress guides",
    },
    "visa-application-pdf-workflow-usa": {
        "title": "Visa Application PDF Workflow USA — USCIS &amp; Embassy Uploads (2026)",
        "tool": "/pdf/merge",
        "label": "Merge PDF",
        "example": "F-1 applicant merges financial PDFs then compresses before VFS upload slot",
    },
    "visa-application-pdf-workflow-uk": {
        "title": "Visa Application PDF Workflow UK — UKVI Document Pack (2026)",
        "tool": "/pdf/merge",
        "label": "Merge PDF",
        "example": "Student visa applicant orders CAS, funds, and passport scans for UKVI upload",
    },
    "visa-application-pdf-workflow-canada": {
        "title": "Visa Application PDF Workflow Canada — IRCC PDF Checklist (2026)",
        "tool": "/pdf/merge",
        "label": "Merge PDF",
        "example": "Study permit applicant compresses 4 MB bank PDF to pass IRCC per-file cap",
    },
    "visa-application-pdf-workflow-australia": {
        "title": "Visa Application PDF Workflow Australia — ImmiAccount PDF Steps (2026)",
        "tool": "/pdf/merge",
        "label": "Merge PDF",
        "example": "Subclass 500 applicant uploads GTE and financials under ImmiAccount 5 MB limit",
    },
    "visa-application-pdf-workflow-india": {
        "title": "Visa Application PDF Workflow India — Outbound &amp; Portal PDF Prep (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "example": "Tourist visa applicant compresses 3 MB salary slips for Schengen VFS slot",
    },
    "bank-statement-pdf-workflow-usa": {
        "title": "Bank Statement PDF Workflow USA — Mortgage &amp; Visa Evidence (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "example": "Mortgage broker compresses 6-month Chase PDF export for lender portal",
    },
    "bank-statement-pdf-workflow-uk": {
        "title": "Bank Statement PDF Workflow UK — Visa &amp; Rental Applications (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "example": "Tenant compresses Barclays PDF statements for letting agent upload",
    },
    "bank-statement-pdf-workflow-india": {
        "title": "Bank Statement PDF Workflow India — Loan &amp; Visa KYC (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "example": "Home loan applicant compresses netbanking PDF under 2 MB portal cap",
    },
    "contract-pdf-workflow-usa": {
        "title": "Contract PDF Workflow USA — Sign, Merge &amp; Email Packs (2026)",
        "tool": "/pdf/merge",
        "label": "Merge PDF",
        "example": "SMB merges MSA, SOW, and NDA PDFs for client DocuSign replacement email pack",
    },
    "contract-pdf-workflow-uk": {
        "title": "Contract PDF Workflow UK — SME Contract PDF Handling (2026)",
        "tool": "/pdf/merge",
        "label": "Merge PDF",
        "example": "Agency merges engagement letter and schedule of rates before client send",
    },
    "invoice-pdf-workflow-india": {
        "title": "Invoice PDF Workflow India — GST, E-Invoice &amp; Client Email (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "example": "CA firm compresses monthly GST invoice PDF batch for client ZIP email",
    },
    "tax-document-pdf-workflow-india": {
        "title": "Tax Document PDF Workflow India — ITR, Form 16 &amp; Portal Upload (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "example": "Salaried employee compresses Form 16 scan for home loan KYC portal",
    },
    "university-application-pdf-workflow-india": {
        "title": "University Application PDF Workflow India — UG &amp; PG Admissions (2026)",
        "tool": "/pdf/merge",
        "label": "Merge PDF",
        "example": "Student merges marksheets and certificates for common admission portal upload",
    },
    "india-job-portal-pdf-limits": {
        "title": "India Job Portal PDF Limits — Naukri, Indeed &amp; Government Jobs (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "example": "Applicant compresses resume+certificates PDF for SSC portal 2 MB cap",
    },
    "pdf-workflow-government": {
        "title": "PDF Workflow for Government — Applicants &amp; Filers (2026)",
        "tool": "/guides/pdf-tools",
        "label": "PDF tools hub",
        "example": "Citizen services desk SOP for compress, merge, and flatten before portal upload",
    },
    "pdf-tools-government-applicants": {
        "title": "PDF Tools for Government Applicants — Free Browser Checklist (2026)",
        "tool": "/guides/pdf-tools",
        "label": "PDF tools hub",
        "example": "Library poster linking RatPDF compress and merge for passport and tax filers",
    },
}


def _visa_deep(code: str) -> str:
    c = COUNTRY[code]
    return f"""
            <h2>{c['name']} visa PDF pack</h2>
            <p>Typical portal: <strong>{c['portal']}</strong> — cap: {c['cap']}. {c['visa_note']}.</p>
            <h2>Workflow</h2>
            <ol>
            <li>Gather PDFs — passport bio page, financials, invitation — numeric prefix filenames</li>
            <li>If portal allows <strong>one</strong> file: <a href="/guides/merge-pdf-visa-application">merge visa pack</a> then <a href="/guides/{c['compress_slug']}">compress</a></li>
            <li>If <strong>per-slot</strong> uploads: compress each PDF separately — do not merge</li>
            <li>Verify MRZ, dates, and amounts at 100% zoom after compress</li>
            <li>Upload on stable Wi-Fi — do not refresh mid-transfer</li>
            </ol>
            <p>Hub: <a href="/guides/compress-pdf-for-visa-application">visa compress guide</a> · <a href="/guides/pdf-troubleshooting">troubleshooting</a>.</p>
            """


def _bank_deep(code: str) -> str:
    c = COUNTRY[code]
    return f"""
            <h2>Bank statement PDF in {c['name']}</h2>
            <p>Lenders, landlords, and visa officers expect <strong>official PDF exports</strong> from netbanking — not phone photos unless specified.</p>
            <h2>Workflow</h2>
            <ol>
            <li>Download 3–6 month statement PDF from bank portal</li>
            <li>Check account holder name and closing balance visible at 100% zoom</li>
            <li><a href="/pdf/compress">Compress PDF</a> with Recommended if over portal cap ({c['cap']})</li>
            <li>Use Less if fine transaction lines soften — re-export from bank if possible</li>
            <li>Password-protect if emailing — share password separately</li>
            </ol>
            <p>Visa tie-in: <a href="/guides/visa-application-pdf-workflow-{code}">visa workflow {code}</a>.</p>
            """


def _contract_deep(code: str) -> str:
    name = COUNTRY[code]["name"]
    return f"""
            <h2>Contract PDF handling in {name}</h2>
            <p>MSA + SOW + exhibits — merge in signature order — watermark DRAFT until execution — flatten after sign.</p>
            <h2>Workflow</h2>
            <ol>
            <li>Export each contract part as PDF from Word or e-sign platform</li>
            <li><a href="/pdf/merge">Merge PDF</a> in execution order — cover page first</li>
            <li><a href="/pdf/watermark">Watermark</a> DRAFT on negotiation copies</li>
            <li>After sign: <a href="/pdf/flatten">Flatten PDF</a> — optional <a href="/pdf/password">password protect</a></li>
            <li>Email: <a href="/pdf/compress">compress</a> if over 20 MB — see <a href="/research/attachment-size-limits">attachment limits</a></li>
            </ol>
            """


W15_DEEP = {
    "pdf-regional-workflows-hub": """
            <h2>Regional index</h2>
            <ul>
            <li><strong>Visa:</strong> <a href="/guides/visa-application-pdf-workflow-usa">USA</a> · <a href="/guides/visa-application-pdf-workflow-uk">UK</a> · <a href="/guides/visa-application-pdf-workflow-canada">Canada</a> · <a href="/guides/visa-application-pdf-workflow-australia">Australia</a> · <a href="/guides/visa-application-pdf-workflow-india">India</a></li>
            <li><strong>Bank statements:</strong> <a href="/guides/bank-statement-pdf-workflow-usa">USA</a> · <a href="/guides/bank-statement-pdf-workflow-uk">UK</a> · <a href="/guides/bank-statement-pdf-workflow-india">India</a></li>
            <li><strong>Contracts:</strong> <a href="/guides/contract-pdf-workflow-usa">USA</a> · <a href="/guides/contract-pdf-workflow-uk">UK</a></li>
            <li><strong>India:</strong> <a href="/guides/invoice-pdf-workflow-india">Invoice</a> · <a href="/guides/tax-document-pdf-workflow-india">Tax</a> · <a href="/guides/university-application-pdf-workflow-india">University</a> · <a href="/guides/india-job-portal-pdf-limits">Job portals</a></li>
            <li><strong>Government:</strong> <a href="/guides/pdf-workflow-government">Government workflow</a> · <a href="/guides/pdf-tools-government-applicants">Applicant tools</a></li>
            </ul>
            <p>Portal compression guides: <a href="/guides/compress-pdf-ukvi">UKVI</a> · <a href="/guides/compress-pdf-schengen-visa">Schengen</a> · <a href="/guides/compress-pdf-gst-portal">GST portal</a> · <a href="/guides/compress-pdf-digilocker">DigiLocker</a>.</p>
            """,
    "visa-application-pdf-workflow-usa": _visa_deep("usa"),
    "visa-application-pdf-workflow-uk": _visa_deep("uk"),
    "visa-application-pdf-workflow-canada": _visa_deep("canada"),
    "visa-application-pdf-workflow-australia": _visa_deep("australia"),
    "visa-application-pdf-workflow-india": _visa_deep("india"),
    "bank-statement-pdf-workflow-usa": _bank_deep("usa"),
    "bank-statement-pdf-workflow-uk": _bank_deep("uk"),
    "bank-statement-pdf-workflow-india": _bank_deep("india"),
    "contract-pdf-workflow-usa": _contract_deep("usa"),
    "contract-pdf-workflow-uk": _contract_deep("uk"),
    "invoice-pdf-workflow-india": """
            <h2>GST invoice PDF chain</h2>
            <p>E-invoice IRN from NIC — PDF with QR for clients — RatPDF compress for email not IRN generation.</p>
            <h2>Workflow</h2>
            <ol>
            <li>Issue GST invoice PDF from billing tool or <a href="/guides/gst-invoice-format-india">GST format guide</a></li>
            <li>Verify GSTIN, HSN, tax split legible at 100% zoom</li>
            <li><a href="/pdf/compress">Compress</a> for client email or <a href="/guides/compress-pdf-gst-portal">GST portal</a> annexure</li>
            <li>Archive uncompressed master for 6+ year retention</li>
            </ol>
            <p>See <a href="/guides/e-invoicing-india-pdf">e-invoicing India PDF</a>.</p>
            """,
    "tax-document-pdf-workflow-india": """
            <h2>ITR and Form 16 PDFs</h2>
            <p>Download acknowledgement and Form 16 from TRACES/income tax portal — compress for loan KYC not alter figures.</p>
            <h2>Workflow</h2>
            <ol>
            <li>Export ITR-V or acknowledgement PDF from portal</li>
            <li>Merge with Form 16 if lender requests single file — <a href="/pdf/merge">Merge PDF</a></li>
            <li>Compress each under 1–2 MB typical KYC cap</li>
            <li>Never edit tax PDF content — provide original portal export</li>
            </ol>
            """,
    "university-application-pdf-workflow-india": """
            <h2>Admission PDF pack</h2>
            <p>UG/PG portals — marksheets, degree, ID — often 2–5 MB per slot — merge only if portal allows single upload.</p>
            <h2>Workflow</h2>
            <ol>
            <li>Scan certificates 200–300 DPI — straight edges</li>
            <li>Order: ID → marksheets → degree → category cert if applicable</li>
            <li><a href="/pdf/merge">Merge</a> or upload separately per portal FAQ</li>
            <li><a href="/pdf/compress">Compress</a> — verify roll numbers readable</li>
            </ol>
            <p><a href="/guides/compress-pdf-for-university-application">University compress guide</a>.</p>
            """,
    "india-job-portal-pdf-limits": """
            <h2>Portal caps (verify live)</h2>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>Portal</th><th>Typical cap</th><th>Tip</th></tr></thead>
            <tbody>
            <tr><td>Naukri / Indeed</td><td>2–5 MB resume</td><td>One PDF resume — compress scan-heavy CV</td></tr>
            <tr><td>SSC / UPSC</td><td>1–2 MB per doc</td><td>Per-slot compress — Less for signatures</td></tr>
            <tr><td>LinkedIn</td><td>~100 MB (generous)</td><td>Still compress multi-page portfolio</td></tr>
            </tbody>
            </table></div>
            <h2>Workflow</h2>
            <ol>
            <li>Export resume PDF from Word — embed fonts</li>
            <li>Merge certificates only if portal allows one attachment</li>
            <li><a href="/guides/compress-pdf-for-indeed">Indeed compress</a> · <a href="/guides/compress-pdf-for-naukri">Naukri compress</a></li>
            </ol>
            """,
    "pdf-workflow-government": """
            <h2>Government applicant SOP</h2>
            <p>Passport, tax, visa, benefits — common pattern: correct scan → compress to cap → flatten forms → upload.</p>
            <h2>Tool matrix</h2>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>Task</th><th>Tool</th></tr></thead>
            <tbody>
            <tr><td>Over size cap</td><td><a href="/pdf/compress">Compress PDF</a></td></tr>
            <tr><td>Multiple PDFs one slot</td><td><a href="/pdf/merge">Merge PDF</a></td></tr>
            <tr><td>Filled form print blank</td><td><a href="/pdf/flatten">Flatten PDF</a></td></tr>
            <tr><td>Scanned form search</td><td><a href="/pdf/ocrpdf">OCR PDF</a></td></tr>
            </tbody>
            </table></div>
            <p>India: <a href="/guides/compress-pdf-for-government-forms">government forms compress</a> · <a href="/guides/compress-pdf-digilocker">DigiLocker</a>.</p>
            """,
    "pdf-tools-government-applicants": """
            <h2>Free tools checklist</h2>
            <ul>
            <li><a href="/pdf/compress">Compress PDF</a> — portal size errors</li>
            <li><a href="/pdf/merge">Merge PDF</a> — single-slot packs</li>
            <li><a href="/pdf/split">Split PDF</a> — oversized downloads</li>
            <li><a href="/pdf/flatten">Flatten PDF</a> — government PDF forms</li>
            <li><a href="/pdf/rotateorremove">Rotate / remove pages</a> — skewed scans</li>
            </ul>
            <h2>Privacy</h2>
            <p>HTTPS upload — auto-delete after processing — see <a href="/home/privacy">privacy policy</a> — do not use public café PCs for passport uploads without clearing Downloads.</p>
            """,
}

W15_SLUG_EXTRA = {
    "pdf-regional-workflows-hub": """
            <h2>Consultant use</h2>
            <p>Immigration firm intranet links country hub — reduces repeated portal cap support tickets.</p>
            """,
    "visa-application-pdf-workflow-usa": """
            <h2>F-1 pack</h2>
            <p>I-20 + financials + passport — merge if VFS allows one financial PDF — separate if per-bank statement slots.</p>
            """,
    "visa-application-pdf-workflow-uk": """
            <h2>Student route</h2>
            <p>CAS PDF + 28-day funds rule statements — dates on statements must align — compress not crop.</p>
            """,
    "visa-application-pdf-workflow-canada": """
            <h2>Study permit</h2>
            <p>LOA PDF from DLI — IRCC 4 MB fail — compress Recommended — verify school name legible.</p>
            """,
    "visa-application-pdf-workflow-australia": """
            <h2>GTE</h2>
            <p>Genuine Temporary Entrant PDF — word export to PDF — compress — ImmiAccount character limits separate from file size.</p>
            """,
    "visa-application-pdf-workflow-india": """
            <h2>Schengen from India</h2>
            <p>VFS India — <a href="/guides/compress-pdf-schengen-visa">Schengen compress</a> — itinerary + insurance + bank — per-country checklist.</p>
            """,
    "bank-statement-pdf-workflow-usa": """
            <h2>Mortgage</h2>
            <p>Chase 6-month PDF 8 MB — compress to 3 MB — loan officer portal accepts — balances still readable.</p>
            """,
    "bank-statement-pdf-workflow-uk": """
            <h2>Rental</h2>
            <p>Three months PDF — letting agent portal 5 MB — compress once — name match passport.</p>
            """,
    "bank-statement-pdf-workflow-india": """
            <h2>Home loan</h2>
            <p>HDFC netbanking PDF 3.2 MB — portal 2 MB — Recommended — EMI table still sharp.</p>
            """,
    "contract-pdf-workflow-usa": """
            <h2>MSA + SOW</h2>
            <p>Merge for client review — watermark DRAFT — separate executed copies archived per party.</p>
            """,
    "contract-pdf-workflow-uk": """
            <h2>Engagement letter</h2>
            <p>Solicitor merges terms and schedule — flatten after sign — email compress under Outlook cap.</p>
            """,
    "invoice-pdf-workflow-india": """
            <h2>Month-end</h2>
            <p>40 client GST PDFs — batch compress — ZIP only if client accepts — many portals block zip.</p>
            """,
    "tax-document-pdf-workflow-india": """
            <h2>Home loan KYC</h2>
            <p>Form 16 Part A+B merged — compress under 1 MB — bank portal green tick.</p>
            """,
    "university-application-pdf-workflow-india": """
            <h2>CUET PG</h2>
            <p>Marksheet + degree merge — 4.8 MB — compress to 2 MB — registration completes.</p>
            """,
    "india-job-portal-pdf-limits": """
            <h2>SSC upload</h2>
            <p>Photo+signature PDF 1.5 MB cap — Less compression — biometrics not blurred.</p>
            """,
    "pdf-workflow-government": """
            <h2>Library class</h2>
            <p>One-hour citizen clinic — compress + flatten demo on sample passport form PDF.</p>
            """,
    "pdf-tools-government-applicants": """
            <h2>Poster</h2>
            <p>QR to tools hub in waiting room — reduces counter "PDF too large" questions.</p>
            """,
}

W15_MEGA = """
            <h2>Regional vs generic guides</h2>
            <p>Portal caps change — always read the red error text on failed upload. Country guides describe typical workflows — verify live FAQ before deadline day.</p>
            <h2>RatPDF chain for applicants</h2>
            <p><a href="/pdf/compress">Compress</a> → <a href="/pdf/merge">Merge</a> → <a href="/pdf/flatten">Flatten</a> → <a href="/pdf/ocrpdf">OCR</a> if scan search needed. See also: <a href="/guides/compress-pdf-guide">compress</a> · <a href="/guides/merge-pdf">merge</a> · <a href="/guides/pdf-troubleshooting">troubleshooting</a>.</p>
            <h2>Honest limits</h2>
            <p>RatPDF does not submit to government portals — prepares PDFs only. No legal immigration advice — consult licensed adviser for visa strategy.</p>
            """

W15_CLUSTER = """
            <h2>Regional workflow guides (batch 1)</h2>
            <ul>
            <li><a href="/guides/visa-application-pdf-workflow-usa">Visa USA</a> · <a href="/guides/visa-application-pdf-workflow-uk">Visa UK</a> · <a href="/guides/visa-application-pdf-workflow-canada">Visa Canada</a></li>
            <li><a href="/guides/visa-application-pdf-workflow-australia">Visa Australia</a> · <a href="/guides/visa-application-pdf-workflow-india">Visa India</a></li>
            <li><a href="/guides/bank-statement-pdf-workflow-usa">Bank USA</a> · <a href="/guides/bank-statement-pdf-workflow-uk">Bank UK</a> · <a href="/guides/bank-statement-pdf-workflow-india">Bank India</a></li>
            <li><a href="/guides/contract-pdf-workflow-usa">Contract USA</a> · <a href="/guides/contract-pdf-workflow-uk">Contract UK</a></li>
            <li><a href="/guides/invoice-pdf-workflow-india">Invoice India</a> · <a href="/guides/tax-document-pdf-workflow-india">Tax India</a> · <a href="/guides/university-application-pdf-workflow-india">University India</a></li>
            <li><a href="/guides/india-job-portal-pdf-limits">India job portals</a> · <a href="/guides/pdf-workflow-government">Government workflow</a></li>
            </ul>
            <p>Hub: <a href="/guides/pdf-regional-workflows-hub">Regional workflows hub</a> · Device: <a href="/guides/pdf-device-workflows-hub">device workflows index</a>.</p>
            """

W15_1500_TOPUP = """
            <h2>Regional upload checklist</h2>
            <ol>
            <li>Read portal FAQ for MB limit and per-slot rules</li>
            <li>Official PDF export not screenshot when possible</li>
            <li>Compress copy — keep original archive</li>
            <li>Verify critical numbers at 100% zoom</li>
            <li>Stable connection — no refresh mid-upload</li>
            <li>Flatten interactive government forms before upload</li>
            </ol>
            <h2>Research</h2>
            <p><a href="/research/attachment-size-limits">Attachment size limits</a> · <a href="/guides/compress-pdf-for-visa-application">Visa compress hub</a>.</p>
            """

W15_CLOSING = """
            <h2>More regional guides</h2>
            <p>Regional guides for visa, bank, and contract PDFs, plus India tax, job, university, and government applicant workflows — with compression tips for portal upload limits.</p>
            <p>More country-specific guides — bookmark the <a href="/guides/pdf-regional-workflows-hub">regional workflows index</a>.</p>
            """

PILLAR_SLUGS = {"pdf-regional-workflows-hub"}
