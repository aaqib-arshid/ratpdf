"""Wave 38 — CREATE batch 2 (17 guides, score 84–86)."""

W38_SLUGS = [
    "bank-statement-pdf-visa",
    "uscis-pdf-upload-requirements",
    "combine-resume-cover-letter-pdf",
    "contract-pdf-redline-workflow",
    "compress-pdf-incometax-india",
    "compress-pdf-made-file-larger",
    "compress-pdf-for-court-e-filing",
    "pdf-password-not-working",
    "smallpdf-vs-adobe",
    "ukvi-pdf-document-rules",
    "digilocker-pdf-upload-size",
    "compress-pdf-irs",
    "compress-pdf-gst-portal-india",
    "heic-to-pdf",
    "secure-pdf-before-email",
    "create-fillable-pdf",
    "schengen-visa-pdf-merge-order",
]

VISA_CREATE_SLUGS = {
    "bank-statement-pdf-visa",
    "uscis-pdf-upload-requirements",
    "ukvi-pdf-document-rules",
    "schengen-visa-pdf-merge-order",
}

JOB_CREATE_SLUGS = {"combine-resume-cover-letter-pdf"}

LEGAL_CREATE_SLUGS = {"contract-pdf-redline-workflow", "compress-pdf-for-court-e-filing"}

GOVT_CREATE_SLUGS = {
    "compress-pdf-incometax-india",
    "digilocker-pdf-upload-size",
    "compress-pdf-irs",
    "compress-pdf-gst-portal-india",
}

COMPRESS_CREATE_SLUGS = {"compress-pdf-made-file-larger"}

TROUBLESHOOT_CREATE_SLUGS = {"pdf-password-not-working"}

COMPARE_CREATE_SLUGS = {"smallpdf-vs-adobe"}

CONVERT_CREATE_SLUGS = {"heic-to-pdf"}

SECURITY_CREATE_SLUGS = {"secure-pdf-before-email"}

FORM_CREATE_SLUGS = {"create-fillable-pdf"}

W38_DATA = {
    "bank-statement-pdf-visa": {
        "title": "Bank Statement PDF for Visa — Compress &amp; Format (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/bank-statement-pdf-workflow-usa",
        "pillar_label": "bank statement workflow USA",
        "related": "/guides/compress-pdf-for-visa-application",
        "prog": "/compress-pdf-for-visa-application",
        "example": "Student exports 6-month netbank PDF — 12 MB — compress to 4 MB for VFS financial evidence slot",
    },
    "uscis-pdf-upload-requirements": {
        "title": "USCIS PDF Upload Requirements — Size, DPI &amp; Naming (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/visa-application-pdf-workflow-usa",
        "pillar_label": "visa workflow USA",
        "related": "/guides/bank-statement-pdf-visa",
        "prog": "/compress-pdf-for-visa-application",
        "example": "Applicant renames I-20 scan to LastName_I20.pdf — 2 MB — passes CEAC upload validator",
    },
    "combine-resume-cover-letter-pdf": {
        "title": "Combine Resume &amp; Cover Letter PDF — One Upload File (2026)",
        "tool": "/pdf/merge",
        "label": "Merge PDF",
        "pillar": "/guides/ats-friendly-pdf-resume",
        "pillar_label": "ATS-friendly resume",
        "related": "/guides/compress-pdf-for-job-application",
        "prog": "/compress-pdf-for-job-application",
        "example": "Applicant merges resume page 1 + cover letter page 2 — single 680 KB PDF for portal",
    },
    "contract-pdf-redline-workflow": {
        "title": "Contract PDF Redline Workflow — Compare, Edit &amp; Return (2026)",
        "tool": "/pdf/pdftodoc",
        "label": "PDF to Word",
        "pillar": "/guides/pdf-to-word",
        "pillar_label": "PDF to Word guide",
        "related": "/guides/compare-two-pdfs",
        "prog": "/pdf/pdftodoc",
        "example": "Legal ops exports vendor MSA to Word — tracks changes — exports clean PDF v3 for signature",
    },
    "compress-pdf-incometax-india": {
        "title": "Compress PDF for Income Tax India — ITR Portal Upload (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/compress-pdf-incometax",
        "pillar_label": "compress Income Tax portal",
        "related": "/guides/invoice-pdf-workflow-india",
        "prog": "/compress-pdf-for-government-forms",
        "example": "CA client uploads Form 16 scan — 6 MB — compress to 3.5 MB before e-filing annexure",
    },
    "compress-pdf-made-file-larger": {
        "title": "Compress PDF Made File Larger — Why &amp; Fixes (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/why-is-pdf-file-so-large",
        "pillar_label": "why PDF is large",
        "related": "/guides/compress-scanned-vs-digital-pdf",
        "prog": "/compress-pdf",
        "example": "User runs Extreme twice on scan — file grows — re-downloads original and uses Less once",
    },
    "compress-pdf-for-court-e-filing": {
        "title": "Compress PDF for Court E-Filing — CM/ECF Size Caps (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/compress-pdf-lawyers",
        "pillar_label": "compress for lawyers",
        "related": "/guides/merge-pdf-court-filing",
        "prog": "/compress-pdf",
        "example": "Paralegal compresses 38 MB exhibit set to 24 MB for CM/ECF after merge — stamps readable",
    },
    "pdf-password-not-working": {
        "title": "PDF Password Not Working — Fix Open &amp; Permission Errors (2026)",
        "tool": "/pdf/unlockpdf",
        "label": "Unlock PDF",
        "pillar": "/guides/pdf-password-best-practices",
        "pillar_label": "password best practices",
        "related": "/guides/unlock-pdf",
        "prog": "/pdf/password",
        "example": "Client types owner password in user field — Acrobat shows incorrect — separate user vs owner explained",
    },
    "smallpdf-vs-adobe": {
        "title": "Smallpdf vs Adobe — Online PDF Tools Compared (2026)",
        "tool": "/compare",
        "label": "compare hub",
        "pillar": "/compare/adobe-acrobat-alternative",
        "pillar_label": "Adobe alternative",
        "related": "/compare/smallpdf-alternative",
        "prog": "/compare",
        "example": "SMB picks browser Smallpdf for occasional merge — legal team still needs Acrobat redaction — decision matrix",
    },
    "ukvi-pdf-document-rules": {
        "title": "UKVI PDF Document Rules — UK Visa Upload Standards (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/visa-application-pdf-workflow-uk",
        "pillar_label": "visa workflow UK",
        "related": "/guides/bank-statement-pdf-workflow-uk",
        "prog": "/compress-pdf-for-visa-application",
        "example": "Skilled worker applicant compresses bank PDF — English translation merged — under UKVI slot cap",
    },
    "digilocker-pdf-upload-size": {
        "title": "DigiLocker PDF Upload Size — Aadhaar &amp; Certificate Caps (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/compress-pdf-digilocker",
        "pillar_label": "compress DigiLocker",
        "related": "/guides/government-portal-pdf-compress",
        "prog": "/compress-pdf-for-government-forms",
        "example": "Student uploads degree scan — issuer portal rejects 4.8 MB — compress to 2.1 MB",
    },
    "compress-pdf-irs": {
        "title": "Compress PDF for IRS — Tax Upload &amp; Record Size (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/irs-tax-pdf-format",
        "pillar_label": "IRS tax PDF format",
        "related": "/guides/irs-pdf-form-fill-online",
        "prog": "/compress-pdf-for-government-forms",
        "example": "Preparer compresses 1099 support PDF bundle before secure client portal upload",
    },
    "compress-pdf-gst-portal-india": {
        "title": "Compress PDF for GST Portal India — Registration &amp; Returns (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/compress-pdf-gst-portal",
        "pillar_label": "compress GST portal",
        "related": "/guides/glossary-gst-invoice",
        "prog": "/compress-pdf-for-government-forms",
        "example": "MSME uploads board resolution scan — gst.gov.in rejects — Less compress passes",
    },
    "heic-to-pdf": {
        "title": "HEIC to PDF — Convert iPhone Photos to PDF (2026)",
        "tool": "/pdf/convertimages",
        "label": "Images to PDF",
        "pillar": "/guides/how-to-combine-images-into-pdf",
        "pillar_label": "combine images into PDF",
        "related": "/guides/scan-to-pdf-phone",
        "prog": "/pdf/convertimages",
        "example": "iPhone HEIC receipt photos merged to one PDF for expense report — then compress for email",
    },
    "secure-pdf-before-email": {
        "title": "Secure PDF Before Email — Encrypt, Watermark &amp; Redact (2026)",
        "tool": "/pdf/password",
        "label": "Protect PDF",
        "pillar": "/guides/password-protect-before-email",
        "pillar_label": "password protect before email",
        "related": "/guides/how-to-protect-pdf-before-sending",
        "prog": "/pdf/password",
        "example": "HR encrypts offer letter — CONFIDENTIAL watermark on draft — password via SMS not email body",
    },
    "create-fillable-pdf": {
        "title": "Create Fillable PDF — AcroForm Fields Online (2026)",
        "tool": "/pdf/flattenpdf",
        "label": "Flatten PDF",
        "pillar": "/guides/glossary-acroform",
        "pillar_label": "AcroForm glossary",
        "related": "/guides/glossary-form-field",
        "prog": "/pdf/flattenpdf",
        "example": "Ops builds onboarding checklist PDF with text fields — recipients fill in browser — flatten on return",
    },
    "schengen-visa-pdf-merge-order": {
        "title": "Schengen Visa PDF Merge Order — Cover Letter &amp; Evidence Stack (2026)",
        "tool": "/pdf/merge",
        "label": "Merge PDF",
        "pillar": "/guides/visa-application-pdf-workflow-germany",
        "pillar_label": "visa workflow Germany",
        "related": "/guides/compress-pdf-for-visa-application",
        "prog": "/compress-pdf-for-visa-application",
        "example": "Applicant merges cover sheet, itinerary, insurance, bank PDFs in VFS-required order — one compress pass",
    },
}

def _d(slug: str, html: str) -> str:
    p = W38_DATA[slug].get("prog", "")
    tail = f'<p>Tool: <a href="{p}">{p}</a></p>' if p else ""
    return html + tail

W38_DEEP = {
    "bank-statement-pdf-visa": _d("bank-statement-pdf-visa", """
            <h2>What consulates expect</h2>
            <p>Official bank PDF export preferred over screenshot — all pages — account holder name visible — last 3–6 months per country rules.</p>
            <h2>Workflow</h2>
            <ol>
            <li>Download netbank PDF — not CSV screenshot</li>
            <li><a href="/pdf/compress">Compress</a> — Less on scans</li>
            <li>Verify balances at 100% zoom</li>
            </ol>
            <p>Regional: <a href="/guides/bank-statement-pdf-workflow-usa">USA</a> · <a href="/guides/bank-statement-pdf-workflow-uk">UK</a> · <a href="/guides/bank-statement-pdf-workflow-india">India</a>.</p>
            """),
    "uscis-pdf-upload-requirements": _d("uscis-pdf-upload-requirements", """
            <h2>Common USCIS rules</h2>
            <ul>
            <li>English or certified translation merged</li>
            <li>File size per upload slot — compress after merge</li>
            <li>Readable text — OCR if scan</li>
            <li>Descriptive filenames</li>
            </ul>
            <p>Hub: <a href="/guides/visa-application-pdf-workflow-usa">USA visa workflow</a> · <a href="/guides/uscis-pdf-upload-requirements">this guide</a> · financial: <a href="/guides/bank-statement-pdf-visa">bank statement</a>.</p>
            """),
    "combine-resume-cover-letter-pdf": _d("combine-resume-cover-letter-pdf", """
            <h2>When to merge</h2>
            <p>Portal allows one PDF only — resume first page then cover letter — keep text selectable — <a href="/pdf/merge">Merge PDF</a>.</p>
            <h2>ATS note</h2>
            <p>Some ATS want separate files — read employer instructions — <a href="/guides/ats-friendly-pdf-resume">ATS resume guide</a> · compress after merge.</p>
            """),
    "contract-pdf-redline-workflow": _d("contract-pdf-redline-workflow", """
            <h2>Redline options</h2>
            <ol>
            <li><a href="/pdf/pdftodoc">PDF to Word</a> — track changes — export PDF</li>
            <li>Compare text: <a href="/guides/compare-two-pdfs">compare two PDFs</a></li>
            <li>Comments in Acrobat for light markup</li>
            </ol>
            <p>Scanned contracts need OCR first — legal final: sign with <a href="/pdf/signtext">Sign PDF</a>.</p>
            """),
    "compress-pdf-incometax-india": _d("compress-pdf-incometax-india", """
            <h2>ITR annexures</h2>
            <p>Form 16, interest certificates, capital gains statements — portal caps — see pillar <a href="/guides/compress-pdf-incometax">compress Income Tax</a>.</p>
            <h2>QA</h2>
            <p>PAN and assessment year legible — do not Extreme on signed Form 16 — <a href="/guides/invoice-pdf-workflow-india">India invoice workflow</a>.</p>
            """),
    "compress-pdf-made-file-larger": _d("compress-pdf-made-file-larger", """
            <h2>Why size increases</h2>
            <ul>
            <li>Re-embed fonts on save</li>
            <li>Linearization overhead</li>
            <li>Double compression artifacts re-encoded larger</li>
            <li>Already-minimal JPEG rewrapped</li>
            </ul>
            <p>Fix: use original — one Less pass — <a href="/guides/compress-scanned-vs-digital-pdf">scanned vs digital</a>.</p>
            """),
    "compress-pdf-for-court-e-filing": _d("compress-pdf-for-court-e-filing", """
            <h2>E-filing caps</h2>
            <p>CM/ECF often ~35 MB per filing — merge exhibits first — single compress — <a href="/guides/merge-pdf-court-filing">court merge</a>.</p>
            <p>Stamps and exhibit numbers must survive — Less preset — <a href="/guides/compress-pdf-lawyers">lawyer compress guide</a>.</p>
            """),
    "pdf-password-not-working": _d("pdf-password-not-working", """
            <h2>Common causes</h2>
            <ul>
            <li>Caps lock / wrong keyboard layout</li>
            <li>Owner vs user password confusion</li>
            <li>Old PDF encryption vs modern reader</li>
            <li>Corrupted download — re-fetch file</li>
            </ul>
            <p>If authorized: <a href="/pdf/unlockpdf">Unlock PDF</a> · practices: <a href="/guides/pdf-password-best-practices">password best practices</a>.</p>
            """),
    "smallpdf-vs-adobe": _d("smallpdf-vs-adobe", """
            <h2>Quick comparison</h2>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>Need</th><th>Smallpdf</th><th>Adobe</th></tr></thead>
            <tbody>
            <tr><td>Occasional merge/compress</td><td>Browser OK</td><td>Overkill license</td></tr>
            <tr><td>Redaction / Bates</td><td>Limited</td><td>Strong</td></tr>
            <tr><td>Batch automation</td><td>Weak</td><td>Actions</td></tr>
            </tbody></table></div>
            <p>Also see <a href="/compare/ratpdf-vs-smallpdf">RatPDF vs Smallpdf</a> · <a href="/compare/adobe-acrobat-alternative">Adobe alternative hub</a>.</p>
            """),
    "ukvi-pdf-document-rules": _d("ukvi-pdf-document-rules", """
            <h2>UKVI evidence</h2>
            <p>Certified translations merged — chronological bank statements — TB test cert — read guidance for skilled worker vs student.</p>
            <p><a href="/guides/visa-application-pdf-workflow-uk">UK visa workflow</a> · <a href="/guides/bank-statement-pdf-workflow-uk">UK bank statement</a> · compress: <a href="/guides/compress-pdf-for-visa-application">visa compress</a>.</p>
            """),
    "digilocker-pdf-upload-size": _d("digilocker-pdf-upload-size", """
            <h2>DigiLocker limits</h2>
            <p>Issuer and pull requests vary — often 1–5 MB — pillar: <a href="/guides/compress-pdf-digilocker">compress DigiLocker</a>.</p>
            <h2>Scan tips</h2>
            <p>200–300 DPI — crop — grayscale for text certs — <a href="/guides/government-portal-pdf-compress">government portal compress</a>.</p>
            """),
    "compress-pdf-irs": _d("compress-pdf-irs", """
            <h2>IRS context</h2>
            <p>Client portals and preparer exchanges — not always direct IRS upload — keep readable W-2/1099 fields — <a href="/guides/irs-tax-pdf-format">IRS PDF format</a> · fill: <a href="/guides/irs-pdf-form-fill-online">IRS form fill</a>.</p>
            """),
    "compress-pdf-gst-portal-india": _d("compress-pdf-gst-portal-india", """
            <h2>GST portal docs</h2>
            <p>Registration annexures, board resolutions, rental agreements — <a href="/guides/compress-pdf-gst-portal">GST portal compress pillar</a>.</p>
            <p>GSTIN and signature readable after compress — <a href="/guides/glossary-gst-invoice">GST invoice glossary</a>.</p>
            """),
    "heic-to-pdf": _d("heic-to-pdf", """
            <h2>HEIC on iPhone</h2>
            <p>Export HEIC to PDF via Photos share or <a href="/pdf/convertimages">Images to PDF</a> — merge receipts — <a href="/pdf/compress">compress</a> for email.</p>
            <p>Related: <a href="/guides/scan-to-pdf-phone">scan to PDF phone</a> · <a href="/guides/how-to-combine-images-into-pdf">combine images</a>.</p>
            """),
    "secure-pdf-before-email": _d("secure-pdf-before-email", """
            <h2>Layered send</h2>
            <ol>
            <li>Redact if PII must not appear</li>
            <li><a href="/pdf/watermark">Watermark</a> DRAFT if review copy</li>
            <li><a href="/pdf/password">Encrypt</a> — password separate channel</li>
            </ol>
            <p>Deep dive: <a href="/guides/password-protect-before-email">password protect before email</a> · hub: <a href="/guides/secure-pdf-workflow">secure workflow</a>.</p>
            """),
    "create-fillable-pdf": _d("create-fillable-pdf", """
            <h2>Fillable PDF basics</h2>
            <p>AcroForm text fields, checkboxes, dropdowns — recipients fill in viewer — <a href="/pdf/flattenpdf">flatten</a> before archive.</p>
            <p>Glossary: <a href="/guides/glossary-acroform">AcroForm</a> · <a href="/guides/glossary-form-field">form fields</a> · vs XFA: <a href="/guides/glossary-xfa-forms">XFA</a>.</p>
            """),
    "schengen-visa-pdf-merge-order": _d("schengen-visa-pdf-merge-order", """
            <h2>Suggested stack order</h2>
            <ol>
            <li>Application cover / checklist</li>
            <li>Travel itinerary &amp; insurance</li>
            <li>Financial evidence — <a href="/guides/bank-statement-pdf-visa">bank PDF</a></li>
            <li>Employment / invitation letters</li>
            </ol>
            <p><a href="/pdf/merge">Merge</a> → one <a href="/pdf/compress">compress</a> — country hubs: <a href="/guides/visa-application-pdf-workflow-germany">Germany</a> · <a href="/guides/visa-application-pdf-workflow-france">France</a>.</p>
            """),
}

W38_CREATE_CLUSTER = """
            <h2>CREATE batch 2</h2>
            <ul>
            <li><a href="/guides/bank-statement-pdf-visa">Bank statement visa</a> · <a href="/guides/uscis-pdf-upload-requirements">USCIS upload</a> · <a href="/guides/ukvi-pdf-document-rules">UKVI rules</a></li>
            <li><a href="/guides/schengen-visa-pdf-merge-order">Schengen merge order</a></li>
            <li><a href="/guides/combine-resume-cover-letter-pdf">Resume + cover letter</a> · <a href="/guides/contract-pdf-redline-workflow">Contract redline</a></li>
            <li><a href="/guides/compress-pdf-incometax-india">Income Tax India</a> · <a href="/guides/digilocker-pdf-upload-size">DigiLocker size</a></li>
            <li><a href="/guides/compress-pdf-irs">IRS compress</a> · <a href="/guides/compress-pdf-gst-portal-india">GST portal India</a></li>
            <li><a href="/guides/compress-pdf-for-court-e-filing">Court e-filing</a> · <a href="/guides/compress-pdf-made-file-larger">Compress made larger</a></li>
            <li><a href="/guides/pdf-password-not-working">Password not working</a> · <a href="/guides/secure-pdf-before-email">Secure before email</a></li>
            <li><a href="/guides/heic-to-pdf">HEIC to PDF</a> · <a href="/guides/create-fillable-pdf">Fillable PDF</a></li>
            <li><a href="/guides/smallpdf-vs-adobe">Smallpdf vs Adobe</a></li>
            </ul>
            <p>Batch 1: <a href="/guides/pdf-too-large-to-email">CREATE batch 1 hub</a></p>
            """

W38_VISA_TOPUP = """
            <h2>Visa PDF checklist</h2>
            <ol>
            <li>Official PDF exports where possible</li>
            <li>Merge in embassy/VFS order</li>
            <li>One compress pass — Less on scans</li>
            <li>Filename: LastName_DocumentType.pdf</li>
            </ol>
            """

W38_COMPRESS_TOPUP = """
            <h2>CREATE batch 2 compress checklist</h2>
            <ol>
            <li>Read portal FAQ for MB cap before compress</li>
            <li>Merge exhibits in filing order first</li>
            <li>Less on scans · Recommended on digital exports</li>
            <li>QA stamps, MRZ, and account numbers at 100% zoom</li>
            </ol>
            """

W38_CLOSING = """
            <h2>Related guides</h2>
            <p>Wave 38 adds visa evidence, India government portals, court e-filing, HEIC convert, fillable forms, and tool comparison — CREATE batch 2 of 450.</p>
            <p>Hub: <a href="/guides/pdf-regional-workflows-hub">regional workflows</a> · CREATE remaining: 416</p>
            """
