"""Wave 21 — Regional bank/contract batch 4 + India compress + without-Adobe + accountants."""

W21_SLUGS = [
    "bank-statement-pdf-workflow-mexico",
    "bank-statement-pdf-workflow-new-zealand",
    "bank-statement-pdf-workflow-south-africa",
    "bank-statement-pdf-workflow-south-korea",
    "bank-statement-pdf-workflow-brazil",
    "contract-pdf-workflow-italy",
    "contract-pdf-workflow-mexico",
    "contract-pdf-workflow-new-zealand",
    "contract-pdf-workflow-south-africa",
    "contract-pdf-workflow-south-korea",
    "contract-pdf-workflow-brazil",
    "compress-aadhaar-pdf",
    "compress-pan-card-pdf",
    "pdf-to-powerpoint-without-adobe",
    "extract-images-from-pdf-without-adobe",
    "text-to-pdf-without-adobe",
    "pdf-tools-for-accountants",
]

BANK_SLUGS = {
    "bank-statement-pdf-workflow-mexico",
    "bank-statement-pdf-workflow-new-zealand",
    "bank-statement-pdf-workflow-south-africa",
    "bank-statement-pdf-workflow-south-korea",
    "bank-statement-pdf-workflow-brazil",
}

CONTRACT_SLUGS = {
    "contract-pdf-workflow-italy",
    "contract-pdf-workflow-mexico",
    "contract-pdf-workflow-new-zealand",
    "contract-pdf-workflow-south-africa",
    "contract-pdf-workflow-south-korea",
    "contract-pdf-workflow-brazil",
}

INDIA_COMPRESS_SLUGS = {"compress-aadhaar-pdf", "compress-pan-card-pdf"}

WITHOUT_ADOBE_SLUGS = {
    "pdf-to-powerpoint-without-adobe",
    "extract-images-from-pdf-without-adobe",
    "text-to-pdf-without-adobe",
}

W21_COUNTRY = {
    "mexico": {
        "name": "Mexico",
        "cap": "often 2–5 MB per slot on consulate and VFS uploads",
        "visa_slug": "visa-application-pdf-workflow-mexico",
        "bank_note": "BBVA, Banorte, Citibanamex netbank PDF export — not mobile screenshot",
        "contract_note": "Contrato de prestación de servicios — merge exhibits — CFDI invoice PDF separate",
    },
    "new-zealand": {
        "name": "New Zealand",
        "cap": "often 10 MB per file on Immigration NZ — still compress large police certs",
        "visa_slug": "visa-application-pdf-workflow-new-zealand",
        "bank_note": "ANZ, ASB, BNZ official statement PDF from internet banking",
        "contract_note": "NZ employment agreement and construction contract — Fair Trading Act aware",
    },
    "south-africa": {
        "name": "South Africa",
        "cap": "often 2–5 MB per upload on VFS and rental portals",
        "visa_slug": "visa-application-pdf-workflow-south-africa",
        "bank_note": "FNB, Standard Bank, Absa netbank PDF — salary credits visible",
        "contract_note": "B2B agreement pack — POPIA data processing addendum often separate PDF",
    },
    "south-korea": {
        "name": "South Korea",
        "cap": "embassy-specific — often 2–5 MB per attachment",
        "visa_slug": "visa-application-pdf-workflow-south-korea",
        "bank_note": "KB, Shinhan, Woori bank statement PDF export in Korean or English",
        "contract_note": "B2B supply agreement — merge Korean and English versions if bilingual deal",
    },
    "brazil": {
        "name": "Brazil",
        "cap": "compress to under 3 MB safe default on consulate portals",
        "visa_slug": "visa-application-pdf-workflow-brazil",
        "bank_note": "Itaú, Bradesco, Nubank official PDF — Portuguese labels on filenames help",
        "contract_note": "Contrato B2B — CNPJ on header — watermark DRAFT until assinatura",
    },
    "italy": {
        "name": "Italy",
        "cap": "Schengen 2–5 MB typical on financial evidence slots",
        "visa_slug": "visa-application-pdf-workflow-italy",
        "bank_note": "Intesa, UniCredit home banking PDF",
        "contract_note": "Contratto B2B — GDPR DPA exhibit — merge order: master then allegati",
    },
}

W21_DATA = {
    "bank-statement-pdf-workflow-mexico": {
        "title": "Bank Statement PDF Workflow Mexico — Visa &amp; Rental Evidence (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/visa-application-pdf-workflow-mexico",
        "pillar_label": "Mexico visa workflow",
        "related": "/guides/compress-pdf-for-visa-application",
        "example": "Applicant compresses Banorte netbank PDF export for Mexico tourist visa financial slot",
    },
    "bank-statement-pdf-workflow-new-zealand": {
        "title": "Bank Statement PDF Workflow New Zealand — Immigration &amp; Rental (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/visa-application-pdf-workflow-new-zealand",
        "pillar_label": "New Zealand visa workflow",
        "related": "/guides/compress-pdf-for-visa-application",
        "example": "Skilled migrant compresses ANZ six-month statement PDF for Immigration NZ evidence",
    },
    "bank-statement-pdf-workflow-south-africa": {
        "title": "Bank Statement PDF Workflow South Africa — Visa &amp; Rental (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/visa-application-pdf-workflow-south-africa",
        "pillar_label": "South Africa visa workflow",
        "related": "/guides/compress-pdf-for-visa-application",
        "example": "Tenant compresses FNB statement PDF for landlord agent portal under 2 MB cap",
    },
    "bank-statement-pdf-workflow-south-korea": {
        "title": "Bank Statement PDF Workflow South Korea — Embassy &amp; Rental (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/visa-application-pdf-workflow-south-korea",
        "pillar_label": "South Korea visa workflow",
        "related": "/guides/compress-pdf-for-visa-application",
        "example": "D-2 student compresses Shinhan bank PDF for embassy funds evidence slot",
    },
    "bank-statement-pdf-workflow-brazil": {
        "title": "Bank Statement PDF Workflow Brazil — Visa &amp; Consulate Evidence (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/visa-application-pdf-workflow-brazil",
        "pillar_label": "Brazil visa workflow",
        "related": "/guides/compress-pdf-for-visa-application",
        "example": "Applicant compresses Itaú extrato PDF for VFS Brazil under 3 MB cap",
    },
    "contract-pdf-workflow-italy": {
        "title": "Contract PDF Workflow Italy — B2B Contratto Merge &amp; Archive (2026)",
        "tool": "/pdf/merge",
        "label": "Merge PDF",
        "pillar": "/guides/contract-pdf-workflow-germany",
        "pillar_label": "contract PDF workflow (Germany reference)",
        "related": "/guides/pdf-security-compliance-guide",
        "example": "SRL merges contratto quadro and GDPR allegato PDFs for client legal review",
    },
    "contract-pdf-workflow-mexico": {
        "title": "Contract PDF Workflow Mexico — B2B Contrato Pack (2026)",
        "tool": "/pdf/merge",
        "label": "Merge PDF",
        "pillar": "/guides/contract-pdf-workflow-australia",
        "pillar_label": "contract PDF workflow hub",
        "related": "/guides/edit-pdf-mistakes-compliance",
        "example": "Agency merges MSA and anexo PDFs before client signature on DocuSign",
    },
    "contract-pdf-workflow-new-zealand": {
        "title": "Contract PDF Workflow New Zealand — SME Agreement PDF (2026)",
        "tool": "/pdf/merge",
        "label": "Merge PDF",
        "pillar": "/guides/contract-pdf-workflow-australia",
        "pillar_label": "contract PDF workflow hub",
        "related": "/guides/merge-pdf",
        "example": "Construction SME merges head contract and specification PDF for subcontractor tender",
    },
    "contract-pdf-workflow-south-africa": {
        "title": "Contract PDF Workflow South Africa — B2B Agreement Pack (2026)",
        "tool": "/pdf/merge",
        "label": "Merge PDF",
        "pillar": "/guides/contract-pdf-workflow-australia",
        "pillar_label": "contract PDF workflow hub",
        "related": "/guides/pdf-redaction-permanent",
        "example": "Vendor merges MSA and POPIA processing addendum before enterprise client sign-off",
    },
    "contract-pdf-workflow-south-korea": {
        "title": "Contract PDF Workflow South Korea — B2B Supply Agreement PDF (2026)",
        "tool": "/pdf/merge",
        "label": "Merge PDF",
        "pillar": "/guides/contract-pdf-workflow-australia",
        "pillar_label": "contract PDF workflow hub",
        "related": "/guides/sign-pdf-legally",
        "example": "Exporter merges Korean master contract and English translation PDF for buyer review",
    },
    "contract-pdf-workflow-brazil": {
        "title": "Contract PDF Workflow Brazil — Contrato B2B Merge &amp; Email (2026)",
        "tool": "/pdf/merge",
        "label": "Merge PDF",
        "pillar": "/guides/contract-pdf-workflow-australia",
        "pillar_label": "contract PDF workflow hub",
        "related": "/guides/compress-pdf-for-email",
        "example": "Ltda merges contrato social excerpt and commercial agreement PDF for partner onboarding",
    },
    "compress-aadhaar-pdf": {
        "title": "Compress Aadhaar PDF — UIDAI &amp; Portal Upload Size Fix (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/compress-pdf-uidai",
        "pillar_label": "compress PDF for UIDAI",
        "related": "/guides/compress-pdf-digilocker",
        "example": "User compresses Aadhaar address proof scan from 4.2 MB to 800 KB for uidai.gov.in slot",
    },
    "compress-pan-card-pdf": {
        "title": "Compress PAN Card PDF — KYC &amp; Loan Portal Upload (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/compress-pdf-digilocker",
        "pillar_label": "compress PDF for DigiLocker",
        "related": "/guides/compress-pdf-incometax",
        "example": "Home loan applicant shrinks PAN card scan PDF while keeping 10-digit number readable",
    },
    "pdf-to-powerpoint-without-adobe": {
        "title": "PDF to PowerPoint Without Adobe — Free PPTX Export (2026)",
        "tool": "/pdf/pdftoppt",
        "label": "PDF to PowerPoint",
        "pillar": "/guides/pdf-to-powerpoint",
        "pillar_label": "PDF to PowerPoint guide",
        "related": "/compare/adobe-acrobat-alternative",
        "example": "Consultant converts client strategy PDF to editable slides without Acrobat subscription",
    },
    "extract-images-from-pdf-without-adobe": {
        "title": "Extract Images from PDF Without Adobe — Free Online (2026)",
        "tool": "/pdf/extractimages",
        "label": "Extract images",
        "pillar": "/guides/extract-images-from-pdf",
        "pillar_label": "extract images from PDF guide",
        "related": "/compare/adobe-acrobat-alternative",
        "example": "Designer pulls product photos embedded in supplier catalogue PDF without Acrobat Pro",
    },
    "text-to-pdf-without-adobe": {
        "title": "Text to PDF Without Adobe — Free Plain Text Export (2026)",
        "tool": "/pdf/texttopdf",
        "label": "Text to PDF",
        "pillar": "/guides/pdf-conversion-guide",
        "pillar_label": "PDF conversion guide",
        "related": "/compare/adobe-acrobat-alternative",
        "example": "Developer converts README.txt to shareable PDF for client who blocks .txt attachments",
    },
    "pdf-tools-for-accountants": {
        "title": "PDF Tools for Accountants — Statements, GST &amp; Board Packs (2026)",
        "tool": "/guides/pdf-tools",
        "label": "PDF tools hub",
        "pillar": "/guides/merge-pdf-accountants",
        "pillar_label": "merge PDF for accountants",
        "related": "/guides/best-free-pdf-tools-2026",
        "example": "CA practice merges quarterly board pack, compresses for email, exports bank PDF to Excel for reconciliation",
    },
}


def _bank_deep(code: str) -> str:
    c = W21_COUNTRY[code]
    return f"""
            <h2>Bank statement PDF — {c['name']}</h2>
            <p>{c['bank_note']}. Typical portal cap: {c['cap']}.</p>
            <h2>Workflow</h2>
            <ol>
            <li>Export 3–6 months from official netbanking — PDF not CSV for visa evidence</li>
            <li>Verify account holder name, account number, closing balance at 100% zoom</li>
            <li><a href="/pdf/compress">Compress PDF</a> Recommended if over cap</li>
            <li>Less compression if transaction lines soften — clerks reject unreadable amounts</li>
            <li>Pair with <a href="/guides/{c['visa_slug']}">visa workflow</a> when immigration evidence</li>
            </ol>
            <h2>Rental and loan portals</h2>
            <p>Landlords and lenders often want same bank PDF — three months typical — match name on ID document. Do not edit balances — fraud risk and rejection.</p>
            <h2>Troubleshooting</h2>
            <p><strong>Screenshot rejected:</strong> re-export PDF from bank. <strong>Wrong currency display:</strong> use statement in required currency if dual accounts. <strong>Merge rejected:</strong> portal wanted one month per slot — split again.</p>
            """


def _contract_deep(code: str) -> str:
    c = W21_COUNTRY[code]
    return f"""
            <h2>Contract PDF — {c['name']}</h2>
            <p>{c['contract_note']}. Watermark negotiation drafts — flatten only after mutual sign.</p>
            <h2>Workflow</h2>
            <ol>
            <li>Export each part from Word or e-sign tool — consistent page size</li>
            <li><a href="/pdf/merge">Merge PDF</a> in execution order — master agreement first, exhibits numbered</li>
            <li><a href="/pdf/watermark">Watermark</a> DRAFT on negotiation copies sent by email</li>
            <li>After countersign — <a href="/pdf/flatten">Flatten</a> and archive master — compress email copy if over cap</li>
            <li>Confidential deals — <a href="/guides/password-protect-pdf">password protect</a> separate from password in body</li>
            </ol>
            <h2>Compliance</h2>
            <p>Do not merge unrelated client contracts into one file for convenience — privilege and data-minimisation rules apply. See <a href="/guides/edit-pdf-mistakes-compliance">edit compliance mistakes</a>.</p>
            """


W21_DEEP = {
    "bank-statement-pdf-workflow-mexico": _bank_deep("mexico"),
    "bank-statement-pdf-workflow-new-zealand": _bank_deep("new-zealand"),
    "bank-statement-pdf-workflow-south-africa": _bank_deep("south-africa"),
    "bank-statement-pdf-workflow-south-korea": _bank_deep("south-korea"),
    "bank-statement-pdf-workflow-brazil": _bank_deep("brazil"),
    "contract-pdf-workflow-italy": _contract_deep("italy"),
    "contract-pdf-workflow-mexico": _contract_deep("mexico"),
    "contract-pdf-workflow-new-zealand": _contract_deep("new-zealand"),
    "contract-pdf-workflow-south-africa": _contract_deep("south-africa"),
    "contract-pdf-workflow-south-korea": _contract_deep("south-korea"),
    "contract-pdf-workflow-brazil": _contract_deep("brazil"),
    "compress-aadhaar-pdf": """
            <h2>Aadhaar PDF size limits</h2>
            <p>UIDAI update and enrolment portals often reject phone camera scans over 1–2 MB. e-Aadhaar PDF from myAadhaar is usually smaller than multi-page colour scans — download official PDF first when possible.</p>
            <h2>Workflow</h2>
            <ol>
            <li>Prefer e-Aadhaar PDF from uidai.gov.in over raw scan</li>
            <li>If scanning physical copy — 200–300 DPI grayscale — crop to card edges</li>
            <li><a href="/pdf/compress">Compress PDF</a> Recommended — target 500 KB–1 MB on tight slots</li>
            <li>Verify 12-digit Aadhaar number and name legible at 100% zoom after compress</li>
            <li>Upload to DigiLocker or portal — see <a href="/guides/compress-pdf-digilocker">DigiLocker compress guide</a></li>
            </ol>
            <h2>Privacy</h2>
            <p>Mask Aadhaar in public submissions when rules allow — last four digits only on some forms. Never email uncompressed Aadhaar PDF over personal Gmail for convenience.</p>
            <p>Related: <a href="/guides/compress-pdf-uidai">UIDAI compress guide</a> · <a href="/guides/compress-pdf-for-government-forms">government forms hub</a>.</p>
            """,
    "compress-pan-card-pdf": """
            <h2>PAN card PDF for KYC</h2>
            <p>Banks, brokers, and HR portals reject oversized PAN scans. The 10-digit PAN and photograph must stay readable — aggressive compression blurs digits and causes KYC failure.</p>
            <h2>Workflow</h2>
            <ol>
            <li>Scan PAN at 200–300 DPI — colour or grayscale — crop to card</li>
            <li>Or use IT Department PAN PDF if issued digitally</li>
            <li><a href="/pdf/compress">Compress PDF</a> Less or Recommended — verify PAN at 100% zoom</li>
            <li>Target 200 KB–1 MB typical loan portal cap</li>
            <li>Pair with Aadhaar compress — <a href="/guides/compress-aadhaar-pdf">Aadhaar guide</a></li>
            </ol>
            <h2>Common mistakes</h2>
            <p><strong>Extreme compression:</strong> digit 8 looks like 3 — KYC manual review delay. <strong>Two-sided merge:</strong> some portals want front-only PDF. <strong>Screenshot:</strong> rejected — use PDF scan.</p>
            <p>Tax portal: <a href="/guides/compress-pdf-incometax">Income Tax compress guide</a>.</p>
            """,
    "pdf-to-powerpoint-without-adobe": """
            <h2>Why skip Acrobat</h2>
            <p>Acrobat Pro subscription for occasional PDF-to-slide conversion is hard to justify. RatPDF runs browser conversion — no MSI install, no Adobe ID for basic export.</p>
            <h2>Workflow</h2>
            <ol>
            <li>Upload PDF deck to <a href="/pdf/pdftoppt">PDF to PowerPoint</a></li>
            <li>Download PPTX — open in PowerPoint or Google Slides</li>
            <li>Fix fonts and rebuild charts exported as images</li>
            <li>Compare output with <a href="/guides/pdf-to-powerpoint">full PDF to PowerPoint guide</a></li>
            </ol>
            <h2>Limits vs Acrobat</h2>
            <p>Complex vector art may flatten to images — same on most online converters. Batch 40-deck conversion — queue one file per session on free tier.</p>
            <p>Compare: <a href="/compare/adobe-acrobat-alternative">Adobe alternative</a> · Reverse: <a href="/guides/powerpoint-to-pdf-without-adobe">PPT to PDF without Adobe</a>.</p>
            """,
    "extract-images-from-pdf-without-adobe": """
            <h2>Extract embedded images</h2>
            <p>Acrobat Pro “Export all images” is overkill for pulling a logo or product photo from a supplier PDF. RatPDF Extract Images pulls embedded bitmaps without full-page screenshot blur.</p>
            <h2>Workflow</h2>
            <ol>
            <li>Upload PDF to <a href="/pdf/extractimages">Extract Images</a></li>
            <li>Download ZIP of embedded JPG/PNG assets</li>
            <li>Pick highest resolution file — not thumbnail preview</li>
            <li>Re-use in CMS or slide deck — respect copyright on supplier catalogues</li>
            </ol>
            <h2>When extraction fails</h2>
            <p>Page is flat image — no separate embedded objects — use <a href="/pdf/pdftoimages">PDF to Images</a> at 300 DPI then crop. Vector logos may not extract — request native AI/EPS from vendor.</p>
            <p>Pillar: <a href="/guides/extract-images-from-pdf">extract images guide</a> · Compare: <a href="/compare/adobe-acrobat-alternative">Adobe alternative</a>.</p>
            """,
    "text-to-pdf-without-adobe": """
            <h2>Plain text to PDF</h2>
            <p>Clients block .txt attachments — PDF is universal. Acrobat Distiller is unnecessary for notes, logs, and README files.</p>
            <h2>Workflow</h2>
            <ol>
            <li>Paste or upload .txt to <a href="/pdf/texttopdf">Text to PDF</a></li>
            <li>Download PDF — verify line wraps and monospace if code log</li>
            <li><a href="/pdf/compress">Compress</a> if email cap tight — text PDFs compress well</li>
            <li>For formatted docs use <a href="/pdf/doctopdf">Word to PDF</a> instead</li>
            </ol>
            <h2>Use cases</h2>
            <p>Support ticket logs, API response dumps, meeting notes, legal exhibit text extracts — pair with <a href="/guides/pdf-to-text-online">PDF to text</a> for round-trip workflows.</p>
            <p>Hub: <a href="/guides/pdf-conversion-guide">PDF conversion guide</a>.</p>
            """,
    "pdf-tools-for-accountants": """
            <h2>Accountant PDF stack</h2>
            <p>Modern CA and bookkeeping practices need merge, compress, PDF to Excel, invoice PDF, and secure email — not necessarily full Acrobat seats for every staff member.</p>
            <h2>Task map</h2>
            <ul>
            <li><strong>Board packs:</strong> <a href="/guides/merge-pdf-accountants">merge for accountants</a> + <a href="/guides/compress-pdf-for-email">compress for email</a></li>
            <li><strong>Bank rec:</strong> <a href="/pdf/pdftoexcel">PDF to Excel</a> on digital bank exports</li>
            <li><strong>Client invoices:</strong> <a href="/invoice/create">Create Invoice</a> + PDF download</li>
            <li><strong>GST returns:</strong> <a href="/guides/compress-pdf-gst-portal">GST portal compress</a> · <a href="/guides/invoice-generator-india">India invoice generator</a></li>
            <li><strong>Workpaper OCR:</strong> <a href="/pdf/ocrpdf">OCR PDF</a> on scanned client docs</li>
            <li><strong>Redacted client send:</strong> <a href="/guides/pdf-redaction-permanent">permanent redaction</a></li>
            </ul>
            <h2>Team rollout</h2>
            <ol>
            <li>Survey which tasks each role runs weekly</li>
            <li>Bookmark RatPDF URLs in firm wiki — merge, compress, PDF to Excel</li>
            <li>Keep one Acrobat seat for complex XFA and prepress if needed</li>
            <li>Train juniors on Less vs Recommended compression for signed workpapers</li>
            </ol>
            <p>Compare tools: <a href="/guides/best-free-pdf-tools-2026">best free PDF tools 2026</a> · Security: <a href="/guides/pdf-tool-security-comparison">security comparison</a>.</p>
            """,
}

W21_SLUG_EXTRA = {
    "bank-statement-pdf-workflow-mexico": """
            <h2>BBVA export tip</h2>
            <p>Spanish UI export still produces valid PDF — filename in English helps VFS staff.</p>
            """,
    "bank-statement-pdf-workflow-brazil": """
            <h2>Extrato bancário</h2>
            <p>Portuguese month labels must stay readable — Less compression if needed.</p>
            """,
    "contract-pdf-workflow-italy": """
            <h2>GDPR allegato</h2>
            <p>DPA as separate numbered exhibit — do not bury inside main contratto PDF without index.</p>
            """,
    "contract-pdf-workflow-south-africa": """
            <h2>POPIA</h2>
            <p>Operator agreement PDF separate from commercial terms — merge only for internal review copy.</p>
            """,
}

W21_REGIONAL_CLUSTER = """
            <h2>Regional batch 4 — bank &amp; contract</h2>
            <ul>
            <li><a href="/guides/bank-statement-pdf-workflow-mexico">Bank Mexico</a> · <a href="/guides/bank-statement-pdf-workflow-brazil">Bank Brazil</a></li>
            <li><a href="/guides/bank-statement-pdf-workflow-new-zealand">Bank NZ</a> · <a href="/guides/bank-statement-pdf-workflow-south-africa">Bank South Africa</a> · <a href="/guides/bank-statement-pdf-workflow-south-korea">Bank Korea</a></li>
            <li><a href="/guides/contract-pdf-workflow-italy">Contract Italy</a> · <a href="/guides/contract-pdf-workflow-mexico">Contract Mexico</a></li>
            <li><a href="/guides/contract-pdf-workflow-new-zealand">Contract NZ</a> · <a href="/guides/contract-pdf-workflow-south-africa">Contract South Africa</a></li>
            <li><a href="/guides/contract-pdf-workflow-south-korea">Contract Korea</a> · <a href="/guides/contract-pdf-workflow-brazil">Contract Brazil</a></li>
            </ul>
            <p>Batch 3: <a href="/guides/visa-application-pdf-workflow-italy">Visa Italy</a> · <a href="/guides/bank-statement-pdf-workflow-italy">Bank Italy</a> · Hub: <a href="/guides/pdf-regional-workflows-hub">regional index</a></p>
            """

W21_INDIA_CLUSTER = """
            <h2>India identity PDF cluster</h2>
            <ul>
            <li><a href="/guides/compress-aadhaar-pdf">Compress Aadhaar</a></li>
            <li><a href="/guides/compress-pan-card-pdf">Compress PAN card</a></li>
            <li><a href="/guides/compress-pdf-uidai">UIDAI guide</a></li>
            <li><a href="/guides/compress-pdf-digilocker">DigiLocker compress</a></li>
            <li><a href="/guides/compress-pdf-incometax">Income Tax portal</a></li>
            </ul>
            """

W21_ADOBE_CLUSTER = """
            <h2>Without Adobe cluster</h2>
            <ul>
            <li><a href="/guides/pdf-to-powerpoint-without-adobe">PDF to PPT without Adobe</a></li>
            <li><a href="/guides/extract-images-from-pdf-without-adobe">Extract images without Adobe</a></li>
            <li><a href="/guides/text-to-pdf-without-adobe">Text to PDF without Adobe</a></li>
            <li><a href="/guides/edit-pdf-without-acrobat">Edit without Acrobat</a></li>
            <li><a href="/guides/images-to-pdf-without-adobe">Images to PDF without Adobe</a></li>
            </ul>
            <p>Compare: <a href="/compare/adobe-acrobat-alternative">Adobe alternative</a></p>
            """

W21_ACCOUNTANTS_CLUSTER = """
            <h2>Professional PDF workflows</h2>
            <ul>
            <li><a href="/guides/merge-pdf-accountants">Merge for accountants</a></li>
            <li><a href="/guides/pdf-tools-for-lawyers">PDF tools for lawyers</a></li>
            <li><a href="/guides/pdf-tools-small-business">SMB PDF stack</a></li>
            <li><a href="/guides/batch-pdf-to-word">Batch PDF to Word</a></li>
            </ul>
            """
