"""Wave 27 — pdf-to-text platform batch 2 + regional bank statements batch 5 + Canada contract."""

W27_SLUGS = [
    "pdf-to-text-for-indeed",
    "pdf-to-text-for-linkedin",
    "pdf-to-text-for-moodle",
    "pdf-to-text-for-naukri",
    "pdf-to-text-for-outlook",
    "pdf-to-text-for-protonmail",
    "pdf-to-text-for-telegram",
    "pdf-to-text-for-whatsapp",
    "pdf-to-text-for-workday",
    "pdf-to-text-for-yahoo-mail",
    "bank-statement-pdf-workflow-france",
    "bank-statement-pdf-workflow-ireland",
    "bank-statement-pdf-workflow-japan",
    "bank-statement-pdf-workflow-netherlands",
    "bank-statement-pdf-workflow-spain",
    "bank-statement-pdf-workflow-uae",
    "contract-pdf-workflow-canada",
]

TEXT_PLATFORM_SLUGS = {
    "pdf-to-text-for-indeed",
    "pdf-to-text-for-linkedin",
    "pdf-to-text-for-moodle",
    "pdf-to-text-for-naukri",
    "pdf-to-text-for-outlook",
    "pdf-to-text-for-protonmail",
    "pdf-to-text-for-telegram",
    "pdf-to-text-for-whatsapp",
    "pdf-to-text-for-workday",
    "pdf-to-text-for-yahoo-mail",
}

BANK_SLUGS = {
    "bank-statement-pdf-workflow-france",
    "bank-statement-pdf-workflow-ireland",
    "bank-statement-pdf-workflow-japan",
    "bank-statement-pdf-workflow-netherlands",
    "bank-statement-pdf-workflow-spain",
    "bank-statement-pdf-workflow-uae",
}

CONTRACT_SLUGS = {"contract-pdf-workflow-canada"}

W27_COUNTRY = {
    "france": {
        "name": "France",
        "cap": "often 2–5 MB per slot on France-Visas and rental dossiers",
        "visa_slug": "visa-application-pdf-workflow-france",
        "bank_note": "BNP Paribas, Société Générale, Crédit Agricole — relevé de compte PDF from netbanking",
    },
    "ireland": {
        "name": "Ireland",
        "cap": "often 2–10 MB on AVATS and rental agent portals",
        "visa_slug": "visa-application-pdf-workflow-ireland",
        "bank_note": "AIB, Bank of Ireland, PTSB official statement PDF export",
    },
    "japan": {
        "name": "Japan",
        "cap": "embassy and COE slots often 2–5 MB per file",
        "visa_slug": "visa-application-pdf-workflow-japan",
        "bank_note": "MUFG, SMBC, Mizuho netbank PDF — Japanese or English statement export",
    },
    "netherlands": {
        "name": "Netherlands",
        "cap": "IND and rental portals often 2–5 MB per upload",
        "visa_slug": "visa-application-pdf-workflow-netherlands",
        "bank_note": "ING, ABN AMRO, Rabobank internet banking PDF statement",
    },
    "spain": {
        "name": "Spain",
        "cap": "BLS Schengen and extranjería often 2–5 MB per document",
        "visa_slug": "visa-application-pdf-workflow-spain",
        "bank_note": "CaixaBank, Santander, BBVA España netbank PDF export",
    },
    "uae": {
        "name": "UAE",
        "cap": "ICP, PRO, and employer portals often 2–5 MB per slot",
        "visa_slug": "visa-application-pdf-workflow-uae",
        "bank_note": "Emirates NBD, ADCB, FAB official account statement PDF",
    },
    "canada": {
        "name": "Canada",
        "contract_note": "MSA, SOW, and NDA — PIPEDA-aware handling — bilingual Quebec deals may need FR exhibit",
    },
}

W27_DATA = {
    "pdf-to-text-for-indeed": {
        "title": "Extract Text from PDF for Indeed — Job Post &amp; Résumé Quotes (2026)",
        "tool": "/pdf/pdftotext",
        "label": "PDF to Text",
        "pillar": "/guides/how-to-extract-text-from-pdf",
        "pillar_label": "extract text from PDF",
        "related": "/guides/compress-pdf-for-indeed",
        "example": "Recruiter copies skills bullet from candidate PDF into Indeed employer reply without retyping",
    },
    "pdf-to-text-for-linkedin": {
        "title": "Extract Text from PDF for LinkedIn — Posts &amp; InMail Quotes (2026)",
        "tool": "/pdf/pdftotext",
        "label": "PDF to Text",
        "pillar": "/guides/how-to-extract-text-from-pdf",
        "pillar_label": "extract text from PDF",
        "related": "/guides/compress-pdf-for-linkedin",
        "example": "Founder quotes one paragraph from whitepaper PDF into LinkedIn post with attribution",
    },
    "pdf-to-text-for-moodle": {
        "title": "Extract Text from PDF for Moodle — Forums &amp; Assignment Text (2026)",
        "tool": "/pdf/pdftotext",
        "label": "PDF to Text",
        "pillar": "/guides/how-to-extract-text-from-pdf",
        "pillar_label": "extract text from PDF",
        "related": "/guides/compress-pdf-for-lms",
        "example": "Instructor pastes journal excerpt from PDF into Moodle forum prompt after OCR on scan",
    },
    "pdf-to-text-for-naukri": {
        "title": "Extract Text from PDF for Naukri — India Job Portal Text (2026)",
        "tool": "/pdf/pdftotext",
        "label": "PDF to Text",
        "pillar": "/guides/how-to-extract-text-from-pdf",
        "pillar_label": "extract text from PDF",
        "related": "/guides/compress-pdf-for-naukri",
        "example": "HR copies experience line from Naukri-downloaded résumé PDF into screening notes",
    },
    "pdf-to-text-for-outlook": {
        "title": "Extract Text from PDF for Outlook — Reply Quotes &amp; M365 Paste (2026)",
        "tool": "/pdf/pdftotext",
        "label": "PDF to Text",
        "pillar": "/guides/how-to-extract-text-from-pdf",
        "pillar_label": "extract text from PDF",
        "related": "/guides/compress-pdf-for-outlook",
        "example": "Procurement quotes SOW clause from PDF attachment into Outlook reply to vendor",
    },
    "pdf-to-text-for-protonmail": {
        "title": "Extract Text from PDF for Proton Mail — Secure Email Quotes (2026)",
        "tool": "/pdf/pdftotext",
        "label": "PDF to Text",
        "pillar": "/guides/how-to-extract-text-from-pdf",
        "pillar_label": "extract text from PDF",
        "related": "/guides/compress-pdf-for-protonmail",
        "example": "Journalist quotes redacted source PDF line into Proton Mail reply — text only in body",
    },
    "pdf-to-text-for-telegram": {
        "title": "Extract Text from PDF for Telegram — Chat Paste &amp; Captions (2026)",
        "tool": "/pdf/pdftotext",
        "label": "PDF to Text",
        "pillar": "/guides/how-to-extract-text-from-pdf",
        "pillar_label": "extract text from PDF",
        "related": "/guides/compress-pdf-for-telegram",
        "example": "Community admin pastes policy bullet from PDF into Telegram announcement — PDF sent separately",
    },
    "pdf-to-text-for-whatsapp": {
        "title": "Extract Text from PDF for WhatsApp — Mobile Paste &amp; Quotes (2026)",
        "tool": "/pdf/pdftotext",
        "label": "PDF to Text",
        "pillar": "/guides/how-to-extract-text-from-pdf",
        "pillar_label": "extract text from PDF",
        "related": "/guides/compress-pdf-for-whatsapp",
        "example": "Field supervisor copies inspection checklist line from PDF into WhatsApp group update",
    },
    "pdf-to-text-for-workday": {
        "title": "Extract Text from PDF for Workday — HR Notes &amp; Ticket Paste (2026)",
        "tool": "/pdf/pdftotext",
        "label": "PDF to Text",
        "pillar": "/guides/how-to-extract-text-from-pdf",
        "pillar_label": "extract text from PDF",
        "related": "/guides/compress-pdf-for-workday",
        "example": "HRBP extracts policy clause from PDF handbook into Workday case comment",
    },
    "pdf-to-text-for-yahoo-mail": {
        "title": "Extract Text from PDF for Yahoo Mail — Reply Quotes (2026)",
        "tool": "/pdf/pdftotext",
        "label": "PDF to Text",
        "pillar": "/guides/how-to-extract-text-from-pdf",
        "pillar_label": "extract text from PDF",
        "related": "/guides/compress-pdf-for-yahoo-mail",
        "example": "Small business owner quotes invoice terms from PDF into Yahoo Mail client reply",
    },
    "bank-statement-pdf-workflow-france": {
        "title": "Bank Statement PDF Workflow France — Visa &amp; Rental Dossier (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/visa-application-pdf-workflow-france",
        "pillar_label": "France visa workflow",
        "related": "/guides/compress-pdf-for-visa-application",
        "example": "Student compresses BNP relevé PDF for France-Visas financial evidence slot",
    },
    "bank-statement-pdf-workflow-ireland": {
        "title": "Bank Statement PDF Workflow Ireland — AVATS &amp; Rental (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/visa-application-pdf-workflow-ireland",
        "pillar_label": "Ireland visa workflow",
        "related": "/guides/compress-pdf-for-visa-application",
        "example": "Tenant compresses AIB six-month statement PDF for Dublin letting agent portal",
    },
    "bank-statement-pdf-workflow-japan": {
        "title": "Bank Statement PDF Workflow Japan — Embassy &amp; COE Evidence (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/visa-application-pdf-workflow-japan",
        "pillar_label": "Japan visa workflow",
        "related": "/guides/compress-pdf-for-visa-application",
        "example": "Student compresses MUFG balance certificate PDF for embassy funds evidence",
    },
    "bank-statement-pdf-workflow-netherlands": {
        "title": "Bank Statement PDF Workflow Netherlands — IND &amp; Rental (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/visa-application-pdf-workflow-netherlands",
        "pillar_label": "Netherlands visa workflow",
        "related": "/guides/compress-pdf-for-visa-application",
        "example": "Knowledge migrant compresses ING statement PDF for IND MVV supporting docs",
    },
    "bank-statement-pdf-workflow-spain": {
        "title": "Bank Statement PDF Workflow Spain — Schengen &amp; Rental (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/visa-application-pdf-workflow-spain",
        "pillar_label": "Spain visa workflow",
        "related": "/guides/compress-pdf-for-visa-application",
        "example": "Applicant compresses Santander extracto PDF for BLS Schengen financial slot",
    },
    "bank-statement-pdf-workflow-uae": {
        "title": "Bank Statement PDF Workflow UAE — Employment &amp; Residence (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/visa-application-pdf-workflow-uae",
        "pillar_label": "UAE visa workflow",
        "related": "/guides/compress-pdf-for-visa-application",
        "example": "PRO compresses Emirates NBD statement PDF for ICP residence visa financial evidence",
    },
    "contract-pdf-workflow-canada": {
        "title": "Contract PDF Workflow Canada — MSA, SOW &amp; PIPEDA Pack (2026)",
        "tool": "/pdf/merge",
        "label": "Merge PDF",
        "pillar": "/guides/contract-pdf-workflow-usa",
        "pillar_label": "contract PDF workflow (USA reference)",
        "related": "/guides/visa-application-pdf-workflow-canada",
        "example": "Toronto SaaS vendor merges MSA and SOW PDFs — watermarks DRAFT before client legal review",
    },
}


def _text_deep(platform: str, workflow: str, compress_slug: str, extra: str = "") -> str:
    extra_html = f"<p>{extra}</p>" if extra else ""
    return f"""
            <h2>{platform} workflow</h2>
            <ol>
            <li>Digital PDF — try select text; scan needs <a href="/pdf/ocrpdf">OCR PDF</a> first</li>
            <li><a href="/pdf/pdftotext">PDF to Text</a> — download .txt</li>
            <li>{workflow}</li>
            <li>Keep PDF attached when tables or signatures matter — text paste is for quotes only</li>
            </ol>
            <h2>Attachment size</h2>
            <p>Separate step from text extract — <a href="/guides/{compress_slug}">compress guide</a> if {platform} rejects large PDF.</p>
            <h2>Troubleshooting</h2>
            <p>Empty extract — <a href="/guides/pdf-text-extraction-empty">empty text extraction guide</a>. Batch 1: <a href="/guides/pdf-to-text-for-gmail">Gmail</a> · <a href="/guides/pdf-to-text-for-canvas">Canvas</a>.</p>
            {extra_html}
            """


def _bank_deep(code: str) -> str:
    c = W27_COUNTRY[code]
    return f"""
            <h2>Bank statement PDF — {c['name']}</h2>
            <p>{c['bank_note']}. Typical portal cap: {c['cap']}.</p>
            <h2>Workflow</h2>
            <ol>
            <li>Export 3–6 months from official netbanking — PDF not screenshot</li>
            <li>Verify account holder name, IBAN/account number, closing balance at 100% zoom</li>
            <li><a href="/pdf/compress">Compress PDF</a> Recommended if over cap</li>
            <li>Less compression if transaction lines soften — amounts must stay readable</li>
            <li>Pair with <a href="/guides/{c['visa_slug']}">visa workflow</a> when immigration evidence</li>
            </ol>
            <h2>Rental and loan portals</h2>
            <p>Landlords want name match on ID — three months typical — do not edit balances.</p>
            <h2>Troubleshooting</h2>
            <p><strong>Screenshot rejected:</strong> re-export PDF from bank. <strong>Merge rejected:</strong> portal wanted one month per slot — split again.</p>
            """


def _contract_canada_deep() -> str:
    c = W27_COUNTRY["canada"]
    return f"""
            <h2>Contract PDF — {c['name']}</h2>
            <p>{c['contract_note']}. Watermark negotiation drafts — flatten only after mutual sign.</p>
            <h2>Workflow</h2>
            <ol>
            <li>Export each part from Word or e-sign tool — consistent Letter page size</li>
            <li><a href="/pdf/merge">Merge PDF</a> — master agreement first, schedules numbered</li>
            <li><a href="/pdf/watermark">Watermark</a> DRAFT on negotiation email copies</li>
            <li>After countersign — <a href="/pdf/flatten">Flatten</a> — compress email copy if over cap</li>
            <li>PIPEDA-sensitive schedules — <a href="/guides/password-protect-pdf">password protect</a> separate channel</li>
            </ol>
            <h2>Cross-border</h2>
            <p>US parent + Canadian subsidiary — see <a href="/guides/contract-pdf-workflow-usa">USA contract workflow</a> · Immigration packs: <a href="/guides/visa-application-pdf-workflow-canada">Canada visa workflow</a>.</p>
            """


W27_TEXT_DEEP = {
    "pdf-to-text-for-indeed": _text_deep(
        "Indeed",
        "Paste quote into employer reply or internal screening doc — link original PDF résumé on Indeed",
        "compress-pdf-for-indeed",
        "OCR scanned CV before extract — ATS needs text layer.",
    ),
    "pdf-to-text-for-linkedin": _text_deep(
        "LinkedIn",
        "Paste excerpt into post, article draft, or InMail — cite source PDF page",
        "compress-pdf-for-linkedin",
    ),
    "pdf-to-text-for-moodle": _text_deep(
        "Moodle",
        "Paste into forum, Page resource, or assignment brief — OCR scans first",
        "compress-pdf-for-lms",
        "Open-source LMS — same extract path as <a href=\"/guides/pdf-to-text-for-canvas\">Canvas guide</a>.",
    ),
    "pdf-to-text-for-naukri": _text_deep(
        "Naukri",
        "Copy experience or education lines into recruiter CRM notes",
        "compress-pdf-for-naukri",
        "India portal — pair with <a href=\"/guides/india-job-portal-pdf-limits\">India job portal limits</a>.",
    ),
    "pdf-to-text-for-outlook": _text_deep(
        "Outlook",
        "Paste clause into reply — M365 desktop or web — keep section reference",
        "compress-pdf-for-outlook",
        "Corporate transport rules may block large PDF — compress attachment separately.",
    ),
    "pdf-to-text-for-protonmail": _text_deep(
        "Proton Mail",
        "Paste quoted text in encrypted body — attach PDF only when formatting required",
        "compress-pdf-for-protonmail",
    ),
    "pdf-to-text-for-telegram": _text_deep(
        "Telegram",
        "Short quote in chat — send full PDF as separate document if under compress cap",
        "compress-pdf-for-telegram",
        "Mobile paste — verify line breaks on phone before send.",
    ),
    "pdf-to-text-for-whatsapp": _text_deep(
        "WhatsApp",
        "Copy bullet into group chat on mobile — PDF doc attachment separate from quote text",
        "compress-pdf-for-whatsapp",
    ),
    "pdf-to-text-for-workday": _text_deep(
        "Workday",
        "Paste policy excerpt into case comment or onboarding checklist — not a file upload replacement",
        "compress-pdf-for-workday",
        "HRIS attachments still need portal-specific compress — extract is for notes field.",
    ),
    "pdf-to-text-for-yahoo-mail": _text_deep(
        "Yahoo Mail",
        "Quote terms in reply compose — Yahoo 25 MB cap on PDF attach — compress if needed",
        "compress-pdf-for-yahoo-mail",
    ),
}

W27_BANK_DEEP = {
    "bank-statement-pdf-workflow-france": _bank_deep("france"),
    "bank-statement-pdf-workflow-ireland": _bank_deep("ireland"),
    "bank-statement-pdf-workflow-japan": _bank_deep("japan"),
    "bank-statement-pdf-workflow-netherlands": _bank_deep("netherlands"),
    "bank-statement-pdf-workflow-spain": _bank_deep("spain"),
    "bank-statement-pdf-workflow-uae": _bank_deep("uae"),
}

W27_CONTRACT_DEEP = {
    "contract-pdf-workflow-canada": _contract_canada_deep(),
}

W27_DEEP = {**W27_TEXT_DEEP, **W27_BANK_DEEP, **W27_CONTRACT_DEEP}

W27_TEXT_CLUSTER = """
            <h2>PDF to text — platform cluster (batch 2)</h2>
            <ul>
            <li><a href="/guides/pdf-to-text-for-indeed">Indeed</a> · <a href="/guides/pdf-to-text-for-linkedin">LinkedIn</a> · <a href="/guides/pdf-to-text-for-naukri">Naukri</a></li>
            <li><a href="/guides/pdf-to-text-for-outlook">Outlook</a> · <a href="/guides/pdf-to-text-for-yahoo-mail">Yahoo Mail</a> · <a href="/guides/pdf-to-text-for-protonmail">Proton Mail</a></li>
            <li><a href="/guides/pdf-to-text-for-moodle">Moodle</a> · <a href="/guides/pdf-to-text-for-workday">Workday</a></li>
            <li><a href="/guides/pdf-to-text-for-telegram">Telegram</a> · <a href="/guides/pdf-to-text-for-whatsapp">WhatsApp</a></li>
            </ul>
            <p>Batch 1: <a href="/guides/pdf-to-text-for-gmail">Gmail</a> · <a href="/guides/pdf-to-text-for-canvas">Canvas</a> · <a href="/guides/pdf-to-text-for-blackboard">Blackboard</a></p>
            <p>Pillar: <a href="/guides/how-to-extract-text-from-pdf">extract text from PDF</a> · <a href="/guides/pdf-to-text-online">PDF to text online</a></p>
            """

W27_BANK_CLUSTER = """
            <h2>Regional bank statement batch 5</h2>
            <ul>
            <li><a href="/guides/bank-statement-pdf-workflow-france">France</a> · <a href="/guides/bank-statement-pdf-workflow-spain">Spain</a> · <a href="/guides/bank-statement-pdf-workflow-netherlands">Netherlands</a></li>
            <li><a href="/guides/bank-statement-pdf-workflow-ireland">Ireland</a> · <a href="/guides/bank-statement-pdf-workflow-japan">Japan</a> · <a href="/guides/bank-statement-pdf-workflow-uae">UAE</a></li>
            </ul>
            <p>Batch 4: <a href="/guides/bank-statement-pdf-workflow-mexico">Mexico</a> · <a href="/guides/bank-statement-pdf-workflow-brazil">Brazil</a> · <a href="/guides/bank-statement-pdf-workflow-italy">Italy</a></p>
            <p>Hub: <a href="/guides/pdf-regional-workflows-hub">regional workflows index</a> · <a href="/guides/compress-pdf-for-visa-application">visa compress guide</a></p>
            """

W27_CONTRACT_CLUSTER = """
            <h2>Regional contract workflows</h2>
            <ul>
            <li><a href="/guides/contract-pdf-workflow-canada">Canada</a> · <a href="/guides/contract-pdf-workflow-usa">USA</a> · <a href="/guides/contract-pdf-workflow-uk">UK</a></li>
            <li><a href="/guides/contract-pdf-workflow-australia">Australia</a> · <a href="/guides/contract-pdf-workflow-germany">Germany</a></li>
            <li><a href="/guides/contract-pdf-workflow-italy">Italy</a> · <a href="/guides/contract-pdf-workflow-mexico">Mexico</a></li>
            </ul>
            """

W27_BANK_TOPUP = """
            <h2>Bank PDF evidence checklist</h2>
            <ol>
            <li>Official netbank PDF export — not mobile screenshot</li>
            <li>Name matches passport and application form</li>
            <li>Closing balance and salary credits visible at 100% zoom after compress</li>
            <li>One file per portal slot unless merge explicitly allowed</li>
            <li>Never edit balances — re-export from bank if wrong account</li>
            </ol>
            """

W27_CLOSING = """
            <h2>Related guides</h2>
            <p>Platform text-extract pages complement compress-for-platform guides — use both when emailing or uploading PDFs. Regional bank pages pair with matching visa workflow guides.</p>
            """
