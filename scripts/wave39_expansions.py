"""Wave 39 — CREATE batch 3 (17 guides, score 82–84)."""

W39_SLUGS = [
    "pdf-job-application-size-limit",
    "law-firm-pdf-discovery-workflow",
    "submit-homework-pdf-canvas",
    "compress-pdf-uscis",
    "create-fillable-pdf-form-free",
    "compress-scanned-pdf",
    "email-to-pdf",
    "pdf-blank-after-merge",
    "safari-save-webpage-as-pdf",
    "dmv-upload-pdf-size-limit",
    "insurance-claim-pdf-photos",
    "compress-pdf-dmv",
    "compress-pdf-schengen",
    "compress-pdf-for-medical-records",
    "webpage-to-pdf",
    "ocr-handwriting-pdf",
    "pdfgear-alternative",
]

JOB_CREATE_SLUGS = {"pdf-job-application-size-limit"}

LEGAL_CREATE_SLUGS = {"law-firm-pdf-discovery-workflow"}

STUDENT_CREATE_SLUGS = {"submit-homework-pdf-canvas"}

VISA_CREATE_SLUGS = {"compress-pdf-uscis", "compress-pdf-schengen"}

FORM_CREATE_SLUGS = {"create-fillable-pdf-form-free"}

COMPRESS_CREATE_SLUGS = {"compress-scanned-pdf", "compress-pdf-for-medical-records"}

CONVERT_CREATE_SLUGS = {"email-to-pdf", "webpage-to-pdf"}

TROUBLESHOOT_CREATE_SLUGS = {"pdf-blank-after-merge"}

DEVICE_CREATE_SLUGS = {"safari-save-webpage-as-pdf"}

GOVT_CREATE_SLUGS = {"dmv-upload-pdf-size-limit", "compress-pdf-dmv"}

BUSINESS_CREATE_SLUGS = {"insurance-claim-pdf-photos"}

OCR_CREATE_SLUGS = {"ocr-handwriting-pdf"}

COMPARE_CREATE_SLUGS = {"pdfgear-alternative"}

W39_DATA = {
    "pdf-job-application-size-limit": {
        "title": "PDF Job Application Size Limit — Portal &amp; Email Caps (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/compress-pdf-for-job-application",
        "pillar_label": "compress for job application",
        "related": "/guides/ats-friendly-pdf-resume",
        "prog": "/compress-pdf-for-job-application",
        "example": "Applicant shrinks 4.2 MB portfolio PDF to 1.8 MB for Workday upload slot",
    },
    "law-firm-pdf-discovery-workflow": {
        "title": "Law Firm PDF Discovery Workflow — OCR, Redact &amp; Produce (2026)",
        "tool": "/pdf/ocrpdf",
        "label": "OCR PDF",
        "pillar": "/guides/pdf-tools-for-lawyers",
        "pillar_label": "PDF tools for lawyers",
        "related": "/guides/ocr-pdf-ediscovery",
        "prog": "/pdf/ocrpdf",
        "example": "Paralegal OCRs 800-page deposition scan — keyword search — privilege redact — Bates production",
    },
    "submit-homework-pdf-canvas": {
        "title": "Submit Homework PDF on Canvas — Size &amp; Format (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/compress-pdf-students",
        "pillar_label": "compress PDF for students",
        "related": "/guides/pdf-workflow-students",
        "prog": "/compress-pdf",
        "example": "Student merges 12 lecture scans — 18 MB — compress to 8 MB before Canvas assignment upload",
    },
    "compress-pdf-uscis": {
        "title": "Compress PDF for USCIS — CEAC Upload Size Fix (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/uscis-pdf-upload-requirements",
        "pillar_label": "USCIS upload requirements",
        "related": "/guides/compress-pdf-for-visa-application",
        "prog": "/compress-pdf-for-visa-application",
        "example": "Family petition bundle — I-864 + tax returns — 9 MB — compress to 4 MB per CEAC slot",
    },
    "create-fillable-pdf-form-free": {
        "title": "Create Fillable PDF Form Free — AcroForm in Browser (2026)",
        "tool": "/pdf/editpdf",
        "label": "Edit PDF",
        "pillar": "/guides/create-fillable-pdf",
        "pillar_label": "create fillable PDF",
        "related": "/guides/glossary-acroform",
        "prog": "/pdf/editpdf",
        "example": "Nonprofit builds volunteer intake form — text fields + checkbox — share fillable PDF link",
    },
    "compress-scanned-pdf": {
        "title": "Compress Scanned PDF — DPI, Grayscale &amp; Presets (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/compress-scanned-vs-digital-pdf",
        "pillar_label": "scanned vs digital compress",
        "related": "/guides/make-scanned-pdf-searchable",
        "prog": "/compress-pdf",
        "example": "Office scan at 600 DPI color — 22 MB — re-scan 300 DPI grayscale + Less compress → 3 MB",
    },
    "email-to-pdf": {
        "title": "Email to PDF — Save Outlook &amp; Gmail Messages as PDF (2026)",
        "tool": "/pdf/doctopdf",
        "label": "Word to PDF",
        "pillar": "/guides/pdf-email-attachment-checklist",
        "pillar_label": "PDF email checklist",
        "related": "/guides/pdf-email-attachment-checklist",
        "prog": "/pdf/doctopdf",
        "example": "HR saves offer email thread — print to PDF — merge with signed offer letter for file",
    },
    "pdf-blank-after-merge": {
        "title": "PDF Blank After Merge — Fix Empty Pages &amp; Missing Content (2026)",
        "tool": "/pdf/merge",
        "label": "Merge PDF",
        "pillar": "/guides/merge-pdf-without-quality-loss",
        "pillar_label": "merge without quality loss",
        "related": "/guides/remove-blank-pages-pdf",
        "prog": "/pdf/merge",
        "example": "User merges Word-export PDF + scan — middle pages blank — wrong source file order fixed",
    },
    "safari-save-webpage-as-pdf": {
        "title": "Safari Save Webpage as PDF — Mac &amp; iOS (2026)",
        "tool": "/pdf/doctopdf",
        "label": "Save as PDF",
        "pillar": "/guides/safari-save-as-pdf",
        "pillar_label": "Safari save as PDF",
        "related": "/guides/webpage-to-pdf",
        "prog": "/pdf/doctopdf",
        "example": "Researcher exports journal article from Safari — removes headers — compress for archive",
    },
    "dmv-upload-pdf-size-limit": {
        "title": "DMV Upload PDF Size Limit — State Portal Caps (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/government-portal-pdf-compress",
        "pillar_label": "government portal compress",
        "related": "/guides/compress-pdf-dmv",
        "prog": "/compress-pdf-for-government-forms",
        "example": "Driver uploads insurance card scan — 6 MB — state DMV portal rejects — compress to 2 MB",
    },
    "insurance-claim-pdf-photos": {
        "title": "Insurance Claim PDF Photos — Merge Damage Images (2026)",
        "tool": "/pdf/convertimages",
        "label": "Images to PDF",
        "pillar": "/guides/compress-pdf-insurance-claims",
        "pillar_label": "compress insurance claims",
        "related": "/guides/how-to-combine-images-into-pdf",
        "prog": "/pdf/compress",
        "example": "Policyholder merges 8 damage photos + estimate PDF — compress for insurer portal",
    },
    "compress-pdf-dmv": {
        "title": "Compress PDF for DMV — Registration &amp; Title Uploads (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/dmv-upload-pdf-size-limit",
        "pillar_label": "DMV upload size limit",
        "related": "/guides/government-portal-pdf-compress",
        "prog": "/compress-pdf-for-government-forms",
        "example": "Title transfer scan — 5 MB — Less compress passes CA DMV online upload",
    },
    "compress-pdf-schengen": {
        "title": "Compress PDF for Schengen — VFS Upload Size Fix (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/compress-pdf-schengen-visa",
        "pillar_label": "compress Schengen visa",
        "related": "/guides/schengen-visa-pdf-merge-order",
        "prog": "/compress-pdf-for-visa-application",
        "example": "Tourist visa applicant compresses insurance + itinerary PDF — 7 MB → 3 MB for VFS slot",
    },
    "compress-pdf-for-medical-records": {
        "title": "Compress PDF for Medical Records — HIPAA-Safe Upload (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/compress-pdf-healthcare-admin",
        "pillar_label": "compress PDF healthcare admin",
        "related": "/guides/hipaa-pdf-handling",
        "prog": "/compress-pdf",
        "example": "Clinic compresses 40-page chart export for patient portal download — readable at 100% zoom",
    },
    "webpage-to-pdf": {
        "title": "Webpage to PDF — Save Any URL as PDF (2026)",
        "tool": "/pdf/doctopdf",
        "label": "Save as PDF",
        "pillar": "/guides/edge-print-to-pdf",
        "pillar_label": "Edge print to PDF",
        "related": "/guides/chrome-save-as-pdf-settings",
        "prog": "/pdf/doctopdf",
        "example": "Analyst saves competitor pricing page — Chrome print to PDF — archive with date stamp",
    },
    "ocr-handwriting-pdf": {
        "title": "OCR Handwriting PDF — Notes &amp; Forms (2026)",
        "tool": "/pdf/ocrpdf",
        "label": "OCR PDF",
        "pillar": "/guides/ocr-lecture-notes-students",
        "pillar_label": "OCR lecture notes",
        "related": "/guides/make-scanned-pdf-searchable",
        "prog": "/pdf/ocrpdf",
        "example": "Student OCRs whiteboard photo PDF — partial handwriting recognition — search key terms",
    },
    "pdfgear-alternative": {
        "title": "PDFgear Alternative — Free Desktop vs Browser (2026)",
        "tool": "/compare",
        "label": "compare hub",
        "pillar": "/compare/pdfgear-alternative",
        "pillar_label": "PDFgear alternative compare",
        "related": "/guides/choose-pdf-tool",
        "prog": "/compare",
        "example": "User switches from PDFgear desktop to browser merge/compress — no install on work laptop",
    },
}

def _d(slug: str, html: str) -> str:
    p = W39_DATA[slug].get("prog", "")
    tail = f'<p>Tool: <a href="{p}">{p}</a></p>' if p else ""
    return html + tail

W39_DEEP = {
    "pdf-job-application-size-limit": _d("pdf-job-application-size-limit", """
            <h2>Typical limits</h2>
            <ul>
            <li>Workday / Greenhouse: often 2–5 MB per file</li>
            <li>Email HR: 10–25 MB gateway dependent</li>
            <li>ATS parsers need selectable text — avoid image-only resume</li>
            </ul>
            <p><a href="/guides/combine-resume-cover-letter-pdf">Merge resume + cover letter</a> · <a href="/guides/ats-friendly-pdf-resume">ATS resume</a>.</p>
            """),
    "law-firm-pdf-discovery-workflow": _d("law-firm-pdf-discovery-workflow", """
            <h2>Discovery pipeline</h2>
            <ol>
            <li>Collect native + scan exhibits</li>
            <li><a href="/pdf/ocrpdf">OCR</a> scans for keyword search</li>
            <li>Privilege review — <a href="/guides/redact-pdf-discovery">redact discovery</a></li>
            <li>Bates number — produce PDF set</li>
            </ol>
            <p>Compress for secure client email — <a href="/guides/compress-pdf-lawyers">lawyer compress</a>.</p>
            """),
    "submit-homework-pdf-canvas": _d("submit-homework-pdf-canvas", """
            <h2>Canvas upload tips</h2>
            <ul>
            <li>Check course assignment max file size</li>
            <li>Merge multi-page homework — <a href="/pdf/merge">Merge PDF</a></li>
            <li><a href="/pdf/compress">Compress</a> phone scans before upload</li>
            <li>Filename: LastName_Assignment2.pdf</li>
            </ul>
            <p><a href="/guides/pdf-to-text-for-canvas">PDF to text for Canvas</a> · <a href="/guides/merge-pdf-students">merge for students</a>.</p>
            """),
    "compress-pdf-uscis": _d("compress-pdf-uscis", """
            <h2>USCIS compress workflow</h2>
            <p>Merge supporting docs per slot — one <a href="/pdf/compress">compress</a> pass — verify I-864 and tax fields at 100% zoom.</p>
            <p>Pillar: <a href="/guides/uscis-pdf-upload-requirements">USCIS requirements</a> · <a href="/guides/bank-statement-pdf-visa">bank statement visa</a>.</p>
            """),
    "create-fillable-pdf-form-free": _d("create-fillable-pdf-form-free", """
            <h2>Free fillable form path</h2>
            <p>Add AcroForm fields in browser editor — test fill in viewer — <a href="/pdf/flattenpdf">flatten</a> on submit.</p>
            <p>Deep guide: <a href="/guides/create-fillable-pdf">create fillable PDF</a> · <a href="/guides/glossary-form-field">form fields</a>.</p>
            """),
    "compress-scanned-pdf": _d("compress-scanned-pdf", """
            <h2>Scan compress levers</h2>
            <ol>
            <li>Lower DPI at source (200–300 for text)</li>
            <li>Grayscale for text-only docs</li>
            <li>Less preset — not double Extreme</li>
            </ol>
            <p><a href="/guides/compress-scanned-vs-digital-pdf">Scanned vs digital</a> · OCR after compress if needed.</p>
            """),
    "email-to-pdf": _d("email-to-pdf", """
            <h2>Save email as PDF</h2>
            <ul>
            <li>Outlook: File → Print → Save as PDF / Microsoft Print to PDF</li>
            <li>Gmail: Print → Save as PDF in Chrome</li>
            <li>Merge thread pages — <a href="/pdf/merge">Merge PDF</a></li>
            </ul>
            <p><a href="/guides/pdf-email-attachment-checklist">Email checklist</a> · password separate channel if sensitive.</p>
            """),
    "pdf-blank-after-merge": _d("pdf-blank-after-merge", """
            <h2>Why pages go blank</h2>
            <ul>
            <li>Corrupt source PDF in batch</li>
            <li>Password-protected file not unlocked</li>
            <li>Wrong page rotation / empty scan pages</li>
            <li>Font embedding failure on rare exports</li>
            </ul>
            <p>Fix: test each source alone — <a href="/guides/remove-blank-pages-pdf">remove blank pages</a> — re-merge.</p>
            """),
    "safari-save-webpage-as-pdf": _d("safari-save-webpage-as-pdf", """
            <h2>Safari export</h2>
            <p>Mac: File → Export as PDF or Print → PDF dropdown → Save as PDF.</p>
            <p>iOS: Share → Print → pinch zoom → Share → Save to Files as PDF.</p>
            <p>Related: <a href="/guides/safari-save-as-pdf">Safari save as PDF pillar</a> · <a href="/guides/webpage-to-pdf">webpage to PDF</a>.</p>
            """),
    "dmv-upload-pdf-size-limit": _d("dmv-upload-pdf-size-limit", """
            <h2>State DMV caps</h2>
            <p>Varies by state — often 2–10 MB — insurance card, title, registration scans.</p>
            <p>200–300 DPI crop — <a href="/guides/compress-pdf-dmv">compress for DMV</a> · <a href="/guides/government-portal-pdf-compress">government portal hub</a>.</p>
            """),
    "insurance-claim-pdf-photos": _d("insurance-claim-pdf-photos", """
            <h2>Claim photo workflow</h2>
            <ol>
            <li>Shoot damage photos — avoid duplicate angles</li>
            <li><a href="/pdf/convertimages">Images to PDF</a> — one file per incident</li>
            <li>Merge with adjuster estimate PDF</li>
            <li><a href="/pdf/compress">Compress</a> — policy # readable</li>
            </ol>
            <p><a href="/guides/compress-pdf-insurance-claims">Insurance claims compress</a>.</p>
            """),
    "compress-pdf-dmv": _d("compress-pdf-dmv", """
            <h2>DMV compress</h2>
            <p>Less on ID and insurance scans — verify VIN and policy dates after compress.</p>
            <p><a href="/guides/dmv-upload-pdf-size-limit">DMV size limits</a> · split only if stamps blur.</p>
            """),
    "compress-pdf-schengen": _d("compress-pdf-schengen", """
            <h2>Schengen VFS compress</h2>
            <p>Merge in <a href="/guides/schengen-visa-pdf-merge-order">required order</a> — one compress — bank and insurance legible.</p>
            <p>Pillar: <a href="/guides/compress-pdf-schengen-visa">Schengen visa compress</a> · regional hubs: Germany, France, Spain.</p>
            """),
    "compress-pdf-for-medical-records": _d("compress-pdf-for-medical-records", """
            <h2>Medical record compress</h2>
            <ul>
            <li>Use approved patient portal — not personal email for PHI</li>
            <li>Less on chart scans — preserve lab values at zoom</li>
            <li>Encrypt if emailing authorized recipient</li>
            </ul>
            <p><a href="/guides/hipaa-pdf-handling">HIPAA PDF handling</a> · <a href="/guides/compress-pdf-healthcare-admin">healthcare admin compress</a>.</p>
            """),
    "webpage-to-pdf": _d("webpage-to-pdf", """
            <h2>Browser save methods</h2>
            <ul>
            <li>Chrome / Edge: Ctrl+P → Save as PDF — disable headers</li>
            <li>Safari: <a href="/guides/safari-save-webpage-as-pdf">Safari guide</a></li>
            <li>Long pages: print selection or split sections</li>
            </ul>
            <p><a href="/guides/edge-print-to-pdf">Edge print to PDF</a> · <a href="/guides/chrome-save-as-pdf-settings">Chrome save as PDF</a> · compress before email archive.</p>
            """),
    "ocr-handwriting-pdf": _d("ocr-handwriting-pdf", """
            <h2>Handwriting OCR limits</h2>
            <p>Tesseract and browser OCR work best on printed text — cursive and whiteboard notes are partial.</p>
            <p>Tip: high contrast photo — crop — correct language pack — <a href="/guides/ocr-lecture-notes-students">lecture notes OCR</a>.</p>
            """),
    "pdfgear-alternative": _d("pdfgear-alternative", """
            <h2>PDFgear vs browser</h2>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>Need</th><th>PDFgear desktop</th><th>Browser (RatPDF)</th></tr></thead>
            <tbody>
            <tr><td>No install on locked PC</td><td>Requires install</td><td>Works in Chrome/Edge</td></tr>
            <tr><td>Batch folder merge</td><td>Strong</td><td>Per-session uploads</td></tr>
            <tr><td>Occasional compress/merge</td><td>Overkill</td><td>Free tier sufficient</td></tr>
            </tbody></table></div>
            <p>Compare page: <a href="/compare/pdfgear-alternative">PDFgear alternative</a> · <a href="/compare">compare hub</a>.</p>
            """),
}

W39_CREATE_CLUSTER = """
            <h2>CREATE batch 3</h2>
            <ul>
            <li><a href="/guides/pdf-job-application-size-limit">Job application size</a> · <a href="/guides/submit-homework-pdf-canvas">Canvas homework</a></li>
            <li><a href="/guides/law-firm-pdf-discovery-workflow">Discovery workflow</a> · <a href="/guides/insurance-claim-pdf-photos">Insurance claim photos</a></li>
            <li><a href="/guides/compress-pdf-uscis">USCIS compress</a> · <a href="/guides/compress-pdf-schengen">Schengen compress</a></li>
            <li><a href="/guides/dmv-upload-pdf-size-limit">DMV size limit</a> · <a href="/guides/compress-pdf-dmv">Compress DMV</a></li>
            <li><a href="/guides/compress-scanned-pdf">Compress scanned PDF</a> · <a href="/guides/compress-pdf-for-medical-records">Medical records</a></li>
            <li><a href="/guides/email-to-pdf">Email to PDF</a> · <a href="/guides/webpage-to-pdf">Webpage to PDF</a> · <a href="/guides/safari-save-webpage-as-pdf">Safari webpage PDF</a></li>
            <li><a href="/guides/pdf-blank-after-merge">Blank after merge</a> · <a href="/guides/ocr-handwriting-pdf">OCR handwriting</a></li>
            <li><a href="/guides/create-fillable-pdf-form-free">Fillable form free</a> · <a href="/guides/pdfgear-alternative">PDFgear alternative</a></li>
            </ul>
            <p>Prior batches: <a href="/guides/pdf-too-large-to-email">batch 1</a> · <a href="/guides/bank-statement-pdf-visa">batch 2</a></p>
            """

W39_STUDENT_TOPUP = """
            <h2>Student PDF checklist</h2>
            <ol>
            <li>Merge readings in syllabus order</li>
            <li>Compress before LMS upload</li>
            <li>OCR scans for Ctrl+F study notes</li>
            <li>Filename: CourseCode_Week3_Readings.pdf</li>
            </ol>
            """

W39_COMPRESS_TOPUP = """
            <h2>CREATE batch 3 compress checklist</h2>
            <ol>
            <li>Scan hygiene before compress (DPI, crop, grayscale)</li>
            <li>Merge portal bundles in filing order first</li>
            <li>One Less/Recommended pass — QA at 100% zoom</li>
            <li>Split only when stamps or MRZ blur</li>
            </ol>
            """

W39_CLOSING = """
            <h2>Related guides</h2>
            <p>Wave 39 adds job portal caps, legal discovery, Canvas homework, USCIS/DMV/Schengen compress, scan troubleshooting, and tool comparison — CREATE batch 3 of 450.</p>
            <p>Hub: <a href="/guides/pdf-tools">PDF tools</a> · CREATE remaining: 399</p>
            """
