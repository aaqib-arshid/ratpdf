"""Wave 15 batch 2 — Regional PDF workflows: remaining visa, bank, contract, India receipts."""

from wave15_expansions import (
    W15_1500_TOPUP,
    W15_MEGA,
)

W15B_SLUGS = [
    "visa-application-pdf-workflow-germany",
    "visa-application-pdf-workflow-france",
    "visa-application-pdf-workflow-uae",
    "visa-application-pdf-workflow-singapore",
    "visa-application-pdf-workflow-japan",
    "visa-application-pdf-workflow-brazil",
    "visa-application-pdf-workflow-netherlands",
    "visa-application-pdf-workflow-spain",
    "visa-application-pdf-workflow-ireland",
    "bank-statement-pdf-workflow-germany",
    "bank-statement-pdf-workflow-canada",
    "bank-statement-pdf-workflow-australia",
    "bank-statement-pdf-workflow-singapore",
    "contract-pdf-workflow-germany",
    "contract-pdf-workflow-australia",
    "payslip-pdf-workflow-india",
    "rent-receipt-pdf-workflow-india",
]

COUNTRY = {
    "germany": {
        "name": "Germany",
        "portal": "Ausländerbehörde / VFS / embassy portal",
        "cap": "often 2–5 MB per slot on VFS Schengen uploads",
        "compress_slug": "compress-pdf-schengen-visa",
        "visa_note": "Blocked account proof, travel insurance, itinerary — Schengen checklist by mission",
    },
    "france": {
        "name": "France",
        "portal": "France-Visas / VFS",
        "cap": "typically 2–4 MB per document on France-Visas",
        "compress_slug": "compress-pdf-schengen-visa",
        "visa_note": "Attestation d'accueil, insurance, funds — French mission may request French labels on filenames",
    },
    "uae": {
        "name": "United Arab Emirates",
        "portal": "ICP / GDRFA / employer PRO portal",
        "cap": "varies — often 2–5 MB per attachment",
        "compress_slug": "compress-pdf-for-visa-application",
        "visa_note": "Employment contract, attested degree, passport — PRO often merges before government upload",
    },
    "singapore": {
        "name": "Singapore",
        "portal": "MOM EPOL / ICA",
        "cap": "often 2 MB per file on employment pass portals",
        "compress_slug": "compress-pdf-for-visa-application",
        "visa_note": "IPA letter, passport, qualifications — EPOL rejects oversize without clear message",
    },
    "japan": {
        "name": "Japan",
        "portal": "embassy / COE online systems",
        "cap": "mission-specific — often 2–5 MB",
        "compress_slug": "compress-pdf-for-visa-application",
        "visa_note": "COE, company registry, itinerary — embassy may require separate PDFs not merged",
    },
    "brazil": {
        "name": "Brazil",
        "portal": "VFS / consulate portal",
        "cap": "varies by consulate — compress to under 3 MB safe default",
        "compress_slug": "compress-pdf-for-visa-application",
        "visa_note": "Police certificate, proof of funds — Portuguese labels help consulate staff",
    },
    "netherlands": {
        "name": "Netherlands",
        "portal": "IND / VFS",
        "cap": "often 2–4 MB per upload on MVV applications",
        "compress_slug": "compress-pdf-schengen-visa",
        "visa_note": "MVV, sponsor documents, TB test if required — IND checklist strict on file type PDF",
    },
    "spain": {
        "name": "Spain",
        "portal": "BLS / embassy appointment system",
        "cap": "Schengen typical 2–5 MB per slot",
        "compress_slug": "compress-pdf-schengen-visa",
        "visa_note": "Travel insurance, funds, accommodation — BLS appointment cities differ in cap text",
    },
    "ireland": {
        "name": "Ireland",
        "portal": "Irish Immigration / AVATS",
        "cap": "often 10 MB per file on online applications",
        "compress_slug": "compress-pdf-for-visa-application",
        "visa_note": "Stamp duty docs, employment permit, funds — AVATS session timeout on slow uploads",
    },
    "canada": {
        "name": "Canada",
        "portal": "IRCC / lender portals",
        "cap": "4 MB per file typical IRCC",
        "compress_slug": "compress-pdf-immigration-canada",
        "visa_note": "Official bank PDF — 3–6 months statements",
    },
    "australia": {
        "name": "Australia",
        "portal": "lender / rental / ImmiAccount",
        "cap": "5 MB common",
        "compress_slug": "compress-pdf-home-affairs-australia",
        "visa_note": "Netbank PDF export preferred",
    },
}

W15B_DATA = {
    "visa-application-pdf-workflow-germany": {
        "title": "Visa Application PDF Workflow Germany — Schengen &amp; National Visa (2026)",
        "tool": "/pdf/merge",
        "label": "Merge PDF",
        "example": "Applicant compresses blocked-account PDF under VFS 3 MB slot before appointment",
    },
    "visa-application-pdf-workflow-france": {
        "title": "Visa Application PDF Workflow France — France-Visas Upload Pack (2026)",
        "tool": "/pdf/merge",
        "label": "Merge PDF",
        "example": "Tourist visa applicant orders insurance, funds, and passport scans for France-Visas",
    },
    "visa-application-pdf-workflow-uae": {
        "title": "Visa Application PDF Workflow UAE — Employment &amp; Residence PDF Prep (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "example": "PRO compresses attested degree PDF for ICP upload under 2 MB cap",
    },
    "visa-application-pdf-workflow-singapore": {
        "title": "Visa Application PDF Workflow Singapore — EPOL &amp; ICA PDF Steps (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "example": "HR compresses employment contract PDF for MOM EPOL attachment",
    },
    "visa-application-pdf-workflow-japan": {
        "title": "Visa Application PDF Workflow Japan — COE &amp; Embassy Documents (2026)",
        "tool": "/pdf/merge",
        "label": "Merge PDF",
        "example": "Engineer merges company registry and assignment letter for COE supporting pack",
    },
    "visa-application-pdf-workflow-brazil": {
        "title": "Visa Application PDF Workflow Brazil — Consulate PDF Checklist (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "example": "Applicant compresses police certificate scan for VFS Brazil upload",
    },
    "visa-application-pdf-workflow-netherlands": {
        "title": "Visa Application PDF Workflow Netherlands — IND &amp; MVV PDF Pack (2026)",
        "tool": "/pdf/merge",
        "label": "Merge PDF",
        "example": "Knowledge migrant merges sponsor letter and passport for MVV slot",
    },
    "visa-application-pdf-workflow-spain": {
        "title": "Visa Application PDF Workflow Spain — Schengen BLS Upload Workflow (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "example": "Student compresses admission letter PDF for BLS Schengen appointment",
    },
    "visa-application-pdf-workflow-ireland": {
        "title": "Visa Application PDF Workflow Ireland — AVATS &amp; Stamp PDF Prep (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "example": "Critical skills applicant compresses employment permit PDF for AVATS",
    },
    "bank-statement-pdf-workflow-germany": {
        "title": "Bank Statement PDF Workflow Germany — Visa &amp; Rental Sperrkonto (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "example": "Student compresses Sparkasse statement PDF for Ausländerbehörde evidence",
    },
    "bank-statement-pdf-workflow-canada": {
        "title": "Bank Statement PDF Workflow Canada — IRCC &amp; Mortgage PDF (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "example": "PR applicant compresses RBC PDF export under IRCC 4 MB limit",
    },
    "bank-statement-pdf-workflow-australia": {
        "title": "Bank Statement PDF Workflow Australia — ImmiAccount &amp; Lender PDF (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "example": "Visa applicant compresses CBA netbank PDF for financial evidence",
    },
    "bank-statement-pdf-workflow-singapore": {
        "title": "Bank Statement PDF Workflow Singapore — EP &amp; Rental Applications (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "example": "Tenant compresses DBS PDF statement for landlord agent portal",
    },
    "contract-pdf-workflow-germany": {
        "title": "Contract PDF Workflow Germany — B2B Vertrag Merge &amp; Archive (2026)",
        "tool": "/pdf/merge",
        "label": "Merge PDF",
        "example": "GmbH merges Rahmenvertrag and Anlage PDFs for customer signature pack",
    },
    "contract-pdf-workflow-australia": {
        "title": "Contract PDF Workflow Australia — SME Agreement PDF Handling (2026)",
        "tool": "/pdf/merge",
        "label": "Merge PDF",
        "example": "Startup merges MSA and SOW for enterprise client legal review",
    },
    "payslip-pdf-workflow-india": {
        "title": "Payslip PDF Workflow India — Loan, Visa &amp; HR Portal Upload (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "example": "Employee compresses three months payslip PDFs for home loan KYC",
    },
    "rent-receipt-pdf-workflow-india": {
        "title": "Rent Receipt PDF Workflow India — HRA Claim &amp; Landlord Sign (2026)",
        "tool": "/pdf/merge",
        "label": "Merge PDF",
        "example": "Tenant merges monthly rent receipt PDFs for employer HRA reimbursement",
    },
}


def _visa_deep(code: str) -> str:
    c = COUNTRY[code]
    return f"""
            <h2>{c['name']} visa PDF pack</h2>
            <p>Portal: <strong>{c['portal']}</strong> — typical cap: {c['cap']}. {c['visa_note']}.</p>
            <h2>Workflow</h2>
            <ol>
            <li>Download checklist from embassy — numeric prefix filenames</li>
            <li>Per-slot vs single bundle — read FAQ before <a href="/pdf/merge">Merge PDF</a></li>
            <li><a href="/guides/{c['compress_slug']}">Compress</a> each file under cap — verify dates at 100% zoom</li>
            <li>Schengen missions: <a href="/guides/compress-pdf-schengen-visa">Schengen compress guide</a></li>
            <li>Upload on stable connection — AVATS/VFS sessions expire</li>
            </ol>
            <p>Hub: <a href="/guides/pdf-regional-workflows-hub">Regional workflows hub</a> · <a href="/guides/merge-pdf-visa-application">Visa merge guide</a>.</p>
            """


def _bank_deep(code: str) -> str:
    c = COUNTRY[code]
    return f"""
            <h2>Bank statement PDF — {c['name']}</h2>
            <p>Official netbanking PDF — not mobile screenshot — {c['cap']} typical portal limit.</p>
            <h2>Workflow</h2>
            <ol>
            <li>Export 3–6 months from bank portal</li>
            <li>Verify name, IBAN/account number, closing balance legible</li>
            <li><a href="/pdf/compress">Compress PDF</a> Recommended if over cap</li>
            <li>Less compression if transaction lines soften</li>
            <li>Pair with <a href="/guides/visa-application-pdf-workflow-{code}">visa workflow</a> if immigration evidence</li>
            </ol>
            """


def _contract_deep(code: str) -> str:
    name = COUNTRY[code]["name"]
    return f"""
            <h2>Contract PDF — {name}</h2>
            <p>B2B agreements — merge exhibits — watermark negotiation drafts — flatten after sign.</p>
            <h2>Workflow</h2>
            <ol>
            <li>Export each part PDF from Word or e-sign tool</li>
            <li><a href="/pdf/merge">Merge PDF</a> in execution order</li>
            <li><a href="/pdf/watermark">Watermark</a> DRAFT until countersigned</li>
            <li><a href="/pdf/flatten">Flatten</a> and archive — <a href="/pdf/compress">compress</a> email copy if needed</li>
            </ol>
            """


W15B_DEEP = {
    "visa-application-pdf-workflow-germany": _visa_deep("germany"),
    "visa-application-pdf-workflow-france": _visa_deep("france"),
    "visa-application-pdf-workflow-uae": _visa_deep("uae"),
    "visa-application-pdf-workflow-singapore": _visa_deep("singapore"),
    "visa-application-pdf-workflow-japan": _visa_deep("japan"),
    "visa-application-pdf-workflow-brazil": _visa_deep("brazil"),
    "visa-application-pdf-workflow-netherlands": _visa_deep("netherlands"),
    "visa-application-pdf-workflow-spain": _visa_deep("spain"),
    "visa-application-pdf-workflow-ireland": _visa_deep("ireland"),
    "bank-statement-pdf-workflow-germany": _bank_deep("germany"),
    "bank-statement-pdf-workflow-canada": _bank_deep("canada"),
    "bank-statement-pdf-workflow-australia": _bank_deep("australia"),
    "bank-statement-pdf-workflow-singapore": """
            <h2>Singapore bank PDF</h2>
            <p>DBS, OCBC, UOB netbanking PDF — EPOL and rental agents — often 2 MB cap.</p>
            <h2>Workflow</h2>
            <ol>
            <li>Download statement PDF — not CSV for evidence uploads</li>
            <li>Compress under EPOL or agent portal cap</li>
            <li>Salary credits visible — matches payslip if both required</li>
            </ol>
            """,
    "contract-pdf-workflow-germany": _contract_deep("germany"),
    "contract-pdf-workflow-australia": _contract_deep("australia"),
    "payslip-pdf-workflow-india": """
            <h2>Payslip PDF chain</h2>
            <p>HR portal PDF or email attachment — loan KYC, visa funds, rental — often 1–2 MB per month file.</p>
            <h2>Workflow</h2>
            <ol>
            <li>Export last 3–6 months payslip PDFs from HRMS</li>
            <li>Merge if lender allows single file — else compress each</li>
            <li>Verify employer name, PAN, net pay legible — do not edit amounts</li>
            <li><a href="/pdf/compress">Compress</a> — pair with <a href="/guides/bank-statement-pdf-workflow-india">bank statement guide</a></li>
            </ol>
            """,
    "rent-receipt-pdf-workflow-india": """
            <h2>Rent receipt PDF for HRA</h2>
            <p>Landlord-signed receipts — merge monthly PDFs for employer FY claim — PAN of landlord if rent &gt; ₹1 lakh/year.</p>
            <h2>Workflow</h2>
            <ol>
            <li>Scan or generate monthly receipt PDFs — consistent landlord letterhead</li>
            <li><a href="/pdf/merge">Merge PDF</a> Apr–Mar in order for employer upload</li>
            <li><a href="/pdf/compress">Compress</a> if HR portal cap — verify amounts and dates</li>
            <li>Not a substitute for registered lease — employer policy varies</li>
            </ol>
            <p>See <a href="/guides/tax-document-pdf-workflow-india">tax document workflow India</a>.</p>
            """,
}

W15B_SLUG_EXTRA = {
    "visa-application-pdf-workflow-germany": """
            <h2>Blocked account</h2>
            <p>Sperrkonto confirmation PDF — compress — appointment city VFS may scan again — bring original.</p>
            """,
    "visa-application-pdf-workflow-france": """
            <h2>Attestation</h2>
            <p>University admission PDF in French or English — insurance PDF separate slot — do not merge if portal forbids.</p>
            """,
    "visa-application-pdf-workflow-uae": """
            <h2>Golden visa</h2>
            <p>Property title PDF + funds — multiple slots — compress each — PRO handles ICP not applicant sometimes.</p>
            """,
    "visa-application-pdf-workflow-singapore": """
            <h2>EP renewal</h2>
            <p>Updated payslip PDF + IPA — EPOL 2 MB — compress both before HR submit.</p>
            """,
    "visa-application-pdf-workflow-japan": """
            <h2>COE wait</h2>
            <p>Employer submits COE — applicant uploads passport PDF only after COE issued — timing matters not merge order.</p>
            """,
    "visa-application-pdf-workflow-brazil": """
            <h2>Police cert</h2>
            <p>Federal police PDF scan — Portuguese header must stay readable after compress.</p>
            """,
    "visa-application-pdf-workflow-netherlands": """
            <h2>Highly skilled</h2>
            <p>IND sponsor forms PDF + passport — MVV appointment — compress sponsor pack under 3 MB.</p>
            """,
    "visa-application-pdf-workflow-spain": """
            <h2>Student visa</h2>
            <p>Admission + funds + insurance — BLS city checklist PDF — three separate compress passes.</p>
            """,
    "visa-application-pdf-workflow-ireland": """
            <h2>Stamp 4</h2>
            <p>Employment permit PDF — AVATS 10 MB generous — still compress multi-hundred-page permits for mobile upload.</p>
            """,
    "bank-statement-pdf-workflow-germany": """
            <h2>Sperrkonto vs current</h2>
            <p>Blocked account opening PDF ≠ monthly statement — upload correct document type per checklist.</p>
            """,
    "bank-statement-pdf-workflow-canada": """
            <h2>Express Entry</h2>
            <p>Proof of funds letter + statements — IRCC may want both — separate slots.</p>
            """,
    "bank-statement-pdf-workflow-australia": """
            <h2>Genuine funds</h2>
            <p>Combine with payslips if student visa — ImmiAccount financial section — consistent names.</p>
            """,
    "bank-statement-pdf-workflow-singapore": """
            <h2>EP salary</h2>
            <p>Bank credits must match declared salary — compress after verify not before blur.</p>
            """,
    "contract-pdf-workflow-germany": """
            <h2>AGB attachment</h2>
            <p>Terms PDF as Anlage — merge after main Vertrag — page numbers via <a href="/guides/add-page-numbers">page numbers</a>.</p>
            """,
    "contract-pdf-workflow-australia": """
            <h2>Fair Work</h2>
            <p>Employment contract PDF separate from contractor MSA — wrong merge confuses legal review.</p>
            """,
    "payslip-pdf-workflow-india": """
            <h2>Home loan</h2>
            <p>Three months payslip PDF merged 2.1 MB — HDFC portal accepts — names match Form 16.</p>
            """,
    "rent-receipt-pdf-workflow-india": """
            <h2>HRA FY</h2>
            <p>12 monthly receipts merged — employer HRMS upload — landlord PAN page if required.</p>
            """,
}

W15B_CLUSTER = """
            <h2>Regional guides</h2>
            <ul>
            <li><a href="/guides/visa-application-pdf-workflow-germany">Visa Germany</a> · <a href="/guides/visa-application-pdf-workflow-france">France</a> · <a href="/guides/visa-application-pdf-workflow-spain">Spain</a></li>
            <li><a href="/guides/visa-application-pdf-workflow-netherlands">Netherlands</a> · <a href="/guides/visa-application-pdf-workflow-ireland">Ireland</a> · <a href="/guides/visa-application-pdf-workflow-uae">UAE</a></li>
            <li><a href="/guides/visa-application-pdf-workflow-singapore">Singapore</a> · <a href="/guides/visa-application-pdf-workflow-japan">Japan</a> · <a href="/guides/visa-application-pdf-workflow-brazil">Brazil</a></li>
            <li><a href="/guides/bank-statement-pdf-workflow-germany">Bank Germany</a> · <a href="/guides/bank-statement-pdf-workflow-canada">Canada</a> · <a href="/guides/bank-statement-pdf-workflow-australia">Australia</a> · <a href="/guides/bank-statement-pdf-workflow-singapore">Singapore</a></li>
            <li><a href="/guides/contract-pdf-workflow-germany">Contract Germany</a> · <a href="/guides/contract-pdf-workflow-australia">Australia</a></li>
            <li><a href="/guides/payslip-pdf-workflow-india">Payslip India</a> · <a href="/guides/rent-receipt-pdf-workflow-india">Rent receipt India</a></li>
            </ul>
            <p>Batch 1: <a href="/guides/pdf-regional-workflows-hub">Regional hub</a> · <a href="/guides/visa-application-pdf-workflow-usa">Visa USA</a> · <a href="/guides/visa-application-pdf-workflow-uk">UK</a>.</p>
            """

W15B_CLOSING = """
            <h2>More regional guides</h2>
            <p>More regional guides for Schengen, Gulf, and Asia-Pacific visa, bank, and contract PDFs, plus India payslip and rent receipt workflows.</p>
            <p>Guides for Italy, Mexico, New Zealand, South Africa, and South Korea — bookmark the <a href="/guides/pdf-regional-workflows-hub">regional workflows index</a>.</p>
            """
