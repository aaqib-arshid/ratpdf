"""Wave 29 — Tax document batch 2 (complete) + university application batch 1."""

W29_SLUGS = [
    "tax-document-pdf-workflow-netherlands",
    "tax-document-pdf-workflow-new-zealand",
    "tax-document-pdf-workflow-singapore",
    "tax-document-pdf-workflow-south-africa",
    "tax-document-pdf-workflow-south-korea",
    "tax-document-pdf-workflow-spain",
    "tax-document-pdf-workflow-uae",
    "tax-document-pdf-workflow-uk",
    "tax-document-pdf-workflow-usa",
    "university-application-pdf-workflow-australia",
    "university-application-pdf-workflow-brazil",
    "university-application-pdf-workflow-canada",
    "university-application-pdf-workflow-france",
    "university-application-pdf-workflow-germany",
    "university-application-pdf-workflow-ireland",
    "university-application-pdf-workflow-italy",
    "university-application-pdf-workflow-japan",
]

TAX_SLUGS = {
    "tax-document-pdf-workflow-netherlands",
    "tax-document-pdf-workflow-new-zealand",
    "tax-document-pdf-workflow-singapore",
    "tax-document-pdf-workflow-south-africa",
    "tax-document-pdf-workflow-south-korea",
    "tax-document-pdf-workflow-spain",
    "tax-document-pdf-workflow-uae",
    "tax-document-pdf-workflow-uk",
    "tax-document-pdf-workflow-usa",
}

UNIVERSITY_SLUGS = {
    "university-application-pdf-workflow-australia",
    "university-application-pdf-workflow-brazil",
    "university-application-pdf-workflow-canada",
    "university-application-pdf-workflow-france",
    "university-application-pdf-workflow-germany",
    "university-application-pdf-workflow-ireland",
    "university-application-pdf-workflow-italy",
    "university-application-pdf-workflow-japan",
}

W29_TAX_META = {
    "netherlands": {
        "title": "Tax Document PDF Workflow Netherlands — Belastingdienst &amp; Aangifte (2026)",
        "example": "Renter compresses aangifte inkomstenbelasting PDF for rental agent dossier",
        "forms": "Aangifte inkomstenbelasting, jaaropgave PDF from Belastingdienst/Mijn Belastingdienst",
        "portal": "Rental, mortgage, IND supporting docs — 2–5 MB typical",
        "related": "/guides/visa-application-pdf-workflow-netherlands",
    },
    "new-zealand": {
        "title": "Tax Document PDF Workflow New Zealand — IRD myIR (2026)",
        "example": "Skilled migrant compresses IRD summary of earnings PDF for Immigration NZ evidence",
        "forms": "Summary of earnings, income tax assessment PDF from IRD myIR",
        "portal": "Immigration NZ, bank loan, rental — often 10 MB per file still compress large exports",
        "related": "/guides/visa-application-pdf-workflow-new-zealand",
    },
    "singapore": {
        "title": "Tax Document PDF Workflow Singapore — IRAS myTax Portal (2026)",
        "example": "EP applicant compresses IRAS notice of assessment PDF for MOM supporting upload",
        "forms": "Notice of assessment, IR8A, tax clearance PDF from IRAS",
        "portal": "MOM EPOL, rental, bank KYC — 2–5 MB per slot",
        "related": "/guides/visa-application-pdf-workflow-singapore",
    },
    "south-africa": {
        "title": "Tax Document PDF Workflow South Africa — SARS eFiling (2026)",
        "example": "Tenant compresses SARS ITA34 assessment PDF for landlord agent portal",
        "forms": "ITA34, IRP5, tax compliance status PDF from SARS eFiling",
        "portal": "Rental, VFS visa, bank loan — 2–5 MB typical",
        "related": "/guides/visa-application-pdf-workflow-south-africa",
    },
    "south-korea": {
        "title": "Tax Document PDF Workflow South Korea — Hometax &amp; NTIS (2026)",
        "example": "D-2 student compresses income tax payment certificate PDF for embassy funds evidence",
        "forms": "Income tax payment certificate, withholding receipt PDF from Hometax",
        "portal": "Embassy, rental guarantor, bank — Korean or English export",
        "related": "/guides/visa-application-pdf-workflow-south-korea",
    },
    "spain": {
        "title": "Tax Document PDF Workflow Spain — AEAT &amp; Renta (2026)",
        "example": "Applicant compresses borrador renta PDF for rental contract dossier",
        "forms": "Renta declaration, certificado fiscal PDF from AEAT/Sede electrónica",
        "portal": "Affitto, BLS Schengen financial proof, bank KYC",
        "related": "/guides/visa-application-pdf-workflow-spain",
    },
    "uae": {
        "title": "Tax Document PDF Workflow UAE — FTA &amp; Corporate Tax (2026)",
        "example": "PRO compresses corporate tax registration PDF for free-zone compliance upload",
        "forms": "FTA registration certificate, VAT return PDF where applicable — many individuals use salary certificates",
        "portal": "ICP, employer PRO, bank KYC — 2–5 MB per slot",
        "related": "/guides/visa-application-pdf-workflow-uae",
    },
    "uk": {
        "title": "Tax Document PDF Workflow UK — HMRC &amp; Self Assessment (2026)",
        "example": "Renter compresses HMRC SA302 tax calculation PDF for letting agent portal",
        "forms": "SA302, tax year overview, P60 PDF from HMRC online account",
        "portal": "Rental, mortgage, visa financial evidence — verify NI number readable",
        "related": "/guides/visa-application-pdf-workflow-uk",
    },
    "usa": {
        "title": "Tax Document PDF Workflow USA — IRS Transcript &amp; Return PDF (2026)",
        "example": "Mortgage applicant compresses IRS wage and income transcript PDF for lender portal",
        "forms": "IRS transcript, Form 1040 PDF from tax prep software — not altered scans",
        "portal": "Lender KYC, visa financial sponsor evidence, rental — see irs-tax-pdf-format guide",
        "related": "/guides/visa-application-pdf-workflow-usa",
    },
}

W29_UNI_META = {
    "australia": {
        "title": "University Application PDF Workflow Australia — ATAR &amp; Transcripts (2026)",
        "example": "International student merges transcripts and English test PDF for direct uni portal upload",
        "docs": "Academic transcripts, ATAR statement, passport, English test (IELTS/PTE)",
        "portal": "StudyLink and individual university portals — often 5–10 MB per slot",
        "related": "/guides/visa-application-pdf-workflow-australia",
        "note": "Separate slots for transcript vs ID — merge only if portal FAQ allows single bundle",
    },
    "brazil": {
        "title": "University Application PDF Workflow Brazil — Histórico &amp; ENEM (2026)",
        "example": "Applicant compresses histórico escolar and ENEM score PDF for SISU portal slot",
        "docs": "Histórico escolar, diploma, ENEM resultado, RG/CPF scan",
        "portal": "SISU and private university portals — 2–5 MB per document typical",
        "related": "/guides/visa-application-pdf-workflow-brazil",
        "note": "Portuguese filenames help admissions staff — verify CPF legible after compress",
    },
    "canada": {
        "title": "University Application PDF Workflow Canada — Transcripts &amp; Study Permit Pack (2026)",
        "example": "UG applicant merges high school transcript and LOA PDF for OUAC direct upload",
        "docs": "Transcripts, LOA, passport bio page, study permit support letters",
        "portal": "OUAC, ApplyAlberta, direct uni portals — 2–4 MB per slot common",
        "related": "/guides/visa-application-pdf-workflow-canada",
        "note": "Study permit PDF pack separate from admission portal — do not merge visa docs into transcript upload",
    },
    "france": {
        "title": "University Application PDF Workflow France — Campus France &amp; Parcoursup (2026)",
        "example": "Student compresses relevé de notes and passport PDF for Campus France dossier",
        "docs": "Relevés de notes, diplôme, passport, Campus France forms",
        "portal": "Campus France, Parcoursup, individual école portals — 2–5 MB per slot",
        "related": "/guides/visa-application-pdf-workflow-france",
        "note": "French baccalauréat results need readable mention and série after compress",
    },
    "germany": {
        "title": "University Application PDF Workflow Germany — uni-assist &amp; NC (2026)",
        "example": "Non-EU applicant merges Zeugnis translations and APS certificate PDF for uni-assist",
        "docs": "Abitur/Zeugnis, certified translations, APS for China/India/Vietnam, passport",
        "portal": "uni-assist, Hochschulstart, direct uni portals — strict one-PDF-per-document rules",
        "related": "/guides/visa-application-pdf-workflow-germany",
        "note": "Certified translation stamp must survive compress — use Less if seal blurs",
    },
    "ireland": {
        "title": "University Application PDF Workflow Ireland — CAO &amp; QQI (2026)",
        "example": "Leaving Cert student compresses results PDF and passport for CAO supporting upload",
        "docs": "Leaving Certificate results, QQI transcripts, passport, English test",
        "portal": "CAO, direct uni portals — often 2–5 MB per slot",
        "related": "/guides/visa-application-pdf-workflow-ireland",
        "note": "CAO vs direct application — different PDF slot rules — read live FAQ",
    },
    "italy": {
        "title": "University Application PDF Workflow Italy — Universitaly &amp; Pre-enrollment (2026)",
        "example": "Non-EU student merges diploma translation and passport PDF for Universitaly pre-enrollment",
        "docs": "Diploma, CIMEA/DOV statement, passport, Italian language cert if required",
        "portal": "Universitaly, individual uni portals — 2–5 MB typical",
        "related": "/guides/visa-application-pdf-workflow-italy",
        "note": "Declaration of value process may need separate PDF per document — no convenience merges",
    },
    "japan": {
        "title": "University Application PDF Workflow Japan — EJU &amp; Certificate of Admission (2026)",
        "example": "Applicant compresses EJU score report and graduation certificate PDF for uni portal",
        "docs": "EJU scores, graduation certificate (卒業証明), passport, Japanese/English translations",
        "portal": "Individual university portals — embassy COE pack is separate workflow",
        "related": "/guides/visa-application-pdf-workflow-japan",
        "note": "Japanese official stamps must stay readable — OCR not substitute for certified scan",
    },
}


def _tax_data(code: str) -> dict:
    m = W29_TAX_META[code]
    return {
        "title": m["title"],
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/tax-document-pdf-workflow-india",
        "pillar_label": "tax document workflow India (reference)",
        "related": m["related"],
        "example": m["example"],
    }


def _uni_data(code: str) -> dict:
    m = W29_UNI_META[code]
    return {
        "title": m["title"],
        "tool": "/pdf/merge",
        "label": "Merge PDF",
        "pillar": "/guides/university-application-pdf-workflow-india",
        "pillar_label": "university application workflow India (reference)",
        "related": m["related"],
        "example": m["example"],
    }


W29_DATA = {
    **{f"tax-document-pdf-workflow-{k}": _tax_data(k) for k in W29_TAX_META},
    **{f"university-application-pdf-workflow-{k}": _uni_data(k) for k in W29_UNI_META},
}


def _tax_deep(code: str) -> str:
    m = W29_TAX_META[code]
    name = code.replace("-", " ").title()
    if code == "uae":
        name = "UAE"
    elif code == "usa":
        name = "USA"
    elif code == "uk":
        name = "UK"
    return f"""
            <h2>Tax documents — {name}</h2>
            <p><strong>Common PDFs:</strong> {m['forms']}.</p>
            <p><strong>Typical use:</strong> {m['portal']}.</p>
            <h2>Workflow</h2>
            <ol>
            <li>Download official PDF from tax authority portal — not edited screenshots</li>
            <li>Verify name, tax ID, and assessment year at 100% zoom</li>
            <li><a href="/pdf/merge">Merge PDF</a> only if portal allows single bundle</li>
            <li><a href="/pdf/compress">Compress PDF</a> Recommended if over cap — Less if figures blur</li>
            <li>Never alter tax figures — fraud risk and automatic rejection</li>
            </ol>
            <p>Batch 1: <a href="/guides/tax-document-pdf-workflow-australia">Australia</a> · <a href="/guides/tax-document-pdf-workflow-canada">Canada</a> · <a href="/guides/tax-document-pdf-workflow-india">India</a>.</p>
            <p>Visa: <a href="{m['related']}">{m['related'].split('/')[-1].replace('-', ' ')}</a>.</p>
            """


def _uni_deep(code: str) -> str:
    m = W29_UNI_META[code]
    name = code.replace("-", " ").title()
    return f"""
            <h2>University application — {name}</h2>
            <p><strong>Typical documents:</strong> {m['docs']}.</p>
            <p><strong>Portal caps:</strong> {m['portal']}.</p>
            <p>{m['note']}.</p>
            <h2>Workflow</h2>
            <ol>
            <li>Scan certificates 200–300 DPI — straight edges — crop phone borders</li>
            <li>Order per portal FAQ — ID → transcripts → test scores → supporting certs</li>
            <li><a href="/pdf/merge">Merge PDF</a> only when portal allows one file per category</li>
            <li><a href="/pdf/compress">Compress PDF</a> — verify roll numbers and seals at 100% zoom</li>
            <li>Study visa PDF pack is separate — <a href="{m['related']}">visa workflow</a></li>
            </ol>
            <p>Hub: <a href="/guides/compress-pdf-for-university-application">university compress guide</a> · <a href="/guides/university-pdf-upload-requirements">upload requirements research</a>.</p>
            <p>India reference: <a href="/guides/university-application-pdf-workflow-india">university workflow India</a>.</p>
            """


W29_TAX_DEEP = {f"tax-document-pdf-workflow-{k}": _tax_deep(k) for k in W29_TAX_META}
W29_UNI_DEEP = {f"university-application-pdf-workflow-{k}": _uni_deep(k) for k in W29_UNI_META}
W29_DEEP = {**W29_TAX_DEEP, **W29_UNI_DEEP}

W29_TAX_CLUSTER = """
            <h2>Tax document workflow — batch 2 (complete set)</h2>
            <ul>
            <li><a href="/guides/tax-document-pdf-workflow-netherlands">Netherlands</a> · <a href="/guides/tax-document-pdf-workflow-uk">UK</a> · <a href="/guides/tax-document-pdf-workflow-usa">USA</a></li>
            <li><a href="/guides/tax-document-pdf-workflow-singapore">Singapore</a> · <a href="/guides/tax-document-pdf-workflow-uae">UAE</a> · <a href="/guides/tax-document-pdf-workflow-spain">Spain</a></li>
            <li><a href="/guides/tax-document-pdf-workflow-new-zealand">New Zealand</a> · <a href="/guides/tax-document-pdf-workflow-south-africa">South Africa</a> · <a href="/guides/tax-document-pdf-workflow-south-korea">South Korea</a></li>
            </ul>
            <p>Batch 1: <a href="/guides/tax-document-pdf-workflow-australia">Australia</a> · <a href="/guides/tax-document-pdf-workflow-germany">Germany</a> · <a href="/guides/tax-document-pdf-workflow-india">India</a></p>
            """

W29_UNI_CLUSTER = """
            <h2>University application workflow — batch 1</h2>
            <ul>
            <li><a href="/guides/university-application-pdf-workflow-australia">Australia</a> · <a href="/guides/university-application-pdf-workflow-canada">Canada</a> · <a href="/guides/university-application-pdf-workflow-usa">USA</a></li>
            <li><a href="/guides/university-application-pdf-workflow-uk">UK</a> · <a href="/guides/university-application-pdf-workflow-germany">Germany</a> · <a href="/guides/university-application-pdf-workflow-france">France</a></li>
            <li><a href="/guides/university-application-pdf-workflow-ireland">Ireland</a> · <a href="/guides/university-application-pdf-workflow-italy">Italy</a> · <a href="/guides/university-application-pdf-workflow-japan">Japan</a></li>
            <li><a href="/guides/university-application-pdf-workflow-brazil">Brazil</a> · <a href="/guides/university-application-pdf-workflow-india">India</a></li>
            </ul>
            <p>Compress: <a href="/guides/compress-pdf-for-university-application">university application</a> · <a href="/guides/compress-pdf-common-app">Common App</a> · <a href="/guides/compress-pdf-ucas">UCAS</a></p>
            """

W29_TAX_TOPUP = """
            <h2>Tax PDF evidence checklist</h2>
            <ol>
            <li>Official portal export — not mobile photo of screen</li>
            <li>Assessment year and taxpayer name match application</li>
            <li>Tax ID readable after compress</li>
            <li>One document per portal slot unless merge explicitly allowed</li>
            <li>Never edit amounts — re-download from authority if wrong file</li>
            </ol>
            """

W29_UNI_TOPUP = """
            <h2>University PDF pack checklist</h2>
            <ol>
            <li>Read portal FAQ — one PDF per slot vs merge allowed</li>
            <li>200–300 DPI scans — not 600 DPI colour phone photos</li>
            <li>Roll numbers, seals, and signatures readable at 100% zoom</li>
            <li>Single compress pass after final merge — avoid double compression</li>
            <li>Admission PDFs separate from study visa evidence pack</li>
            </ol>
            """

W29_CLOSING = """
            <h2>Related guides</h2>
            <p>Tax and university workflow pages prepare PDFs for portals — RatPDF does not submit applications or provide tax/legal advice. Verify live portal caps before deadline day.</p>
            <p>Hub: <a href="/guides/pdf-regional-workflows-hub">regional workflows index</a></p>
            """
