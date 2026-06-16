"""Wave 26 — Industry pdf-workflow hub pages + pdf-to-text platform batch 1."""

W26_SLUGS = [
    "pdf-workflow-accountants",
    "pdf-workflow-construction",
    "pdf-workflow-ecommerce",
    "pdf-workflow-freelancers",
    "pdf-workflow-healthcare-admin",
    "pdf-workflow-hr",
    "pdf-workflow-insurance",
    "pdf-workflow-lawyers",
    "pdf-workflow-marketing-agencies",
    "pdf-workflow-nonprofits",
    "pdf-workflow-real-estate",
    "pdf-workflow-recruiters",
    "pdf-workflow-students",
    "pdf-workflow-teachers",
    "pdf-to-text-for-blackboard",
    "pdf-to-text-for-canvas",
    "pdf-to-text-for-gmail",
]

WORKFLOW_SLUGS = {
    "pdf-workflow-accountants",
    "pdf-workflow-construction",
    "pdf-workflow-ecommerce",
    "pdf-workflow-freelancers",
    "pdf-workflow-healthcare-admin",
    "pdf-workflow-hr",
    "pdf-workflow-insurance",
    "pdf-workflow-lawyers",
    "pdf-workflow-marketing-agencies",
    "pdf-workflow-nonprofits",
    "pdf-workflow-real-estate",
    "pdf-workflow-recruiters",
    "pdf-workflow-students",
    "pdf-workflow-teachers",
}

TEXT_PLATFORM_SLUGS = {
    "pdf-to-text-for-blackboard",
    "pdf-to-text-for-canvas",
    "pdf-to-text-for-gmail",
}

W26_DATA = {
    "pdf-workflow-accountants": {
        "title": "PDF Workflow for Accountants — Board Packs, GST &amp; Client Delivery (2026)",
        "tool": "/guides/pdf-tools",
        "label": "PDF tools hub",
        "pillar": "/guides/pdf-tools-for-accountants",
        "pillar_label": "PDF tools for accountants",
        "related": "/guides/merge-pdf-accountants",
        "example": "Month-end: merge trial balance PDFs, compress board pack to 12 MB, password-protect draft before partner review",
    },
    "pdf-workflow-construction": {
        "title": "PDF Workflow for Construction — Permits, RFQs &amp; Site Logs (2026)",
        "tool": "/guides/pdf-tools",
        "label": "PDF tools hub",
        "pillar": "/guides/pdf-tools-construction",
        "pillar_label": "PDF tools for construction",
        "related": "/guides/compress-pdf-construction",
        "example": "PM merges permit submittal sheets, compresses for city portal, bundles weekly site photo log for owner",
    },
    "pdf-workflow-ecommerce": {
        "title": "PDF Workflow for Ecommerce — Catalogs, Invoices &amp; 3PL Onboarding (2026)",
        "tool": "/guides/pdf-tools",
        "label": "PDF tools hub",
        "pillar": "/guides/compress-pdf-ecommerce",
        "pillar_label": "compress PDF for ecommerce",
        "related": "/guides/pdf-tools-small-business",
        "example": "Ops merges supplier catalog and compliance certs, compresses 22 MB pack for 3PL email onboarding",
    },
    "pdf-workflow-freelancers": {
        "title": "PDF Workflow for Freelancers — Proposals, Contracts &amp; Invoices (2026)",
        "tool": "/guides/pdf-tools",
        "label": "PDF tools hub",
        "pillar": "/guides/compress-pdf-freelancers",
        "pillar_label": "compress PDF for freelancers",
        "related": "/guides/invoice-for-freelancers",
        "example": "Designer signs SOW PDF, compresses portfolio from 14 MB to 6 MB, emails client before kickoff call",
    },
    "pdf-workflow-healthcare-admin": {
        "title": "PDF Workflow for Healthcare Administrators — Prior Auth &amp; Credentialing (2026)",
        "tool": "/guides/pdf-tools",
        "label": "PDF tools hub",
        "pillar": "/guides/pdf-tools-healthcare-admin",
        "pillar_label": "PDF tools for healthcare admin",
        "related": "/guides/compress-pdf-healthcare-admin",
        "example": "Admin merges clinical notes and imaging reports, compresses prior-auth bundle for payer portal upload",
    },
    "pdf-workflow-hr": {
        "title": "PDF Workflow for HR — Onboarding, Policies &amp; Offer Letters (2026)",
        "tool": "/guides/pdf-tools",
        "label": "PDF tools hub",
        "pillar": "/guides/compress-pdf-hr",
        "pillar_label": "compress PDF for HR",
        "related": "/guides/secure-pdf-workflow",
        "example": "HR merges offer letter, policy handbook, and benefits PDF — compresses 28 MB onboarding pack for new hire",
    },
    "pdf-workflow-insurance": {
        "title": "PDF Workflow for Insurance — Claims, Policies &amp; Portal Uploads (2026)",
        "tool": "/guides/pdf-tools",
        "label": "PDF tools hub",
        "pillar": "/guides/pdf-tools-insurance",
        "pillar_label": "PDF tools for insurance",
        "related": "/guides/compress-pdf-insurance-claims",
        "example": "Adjuster merges damage photos, repair estimate, and police report into one claim PDF under portal cap",
    },
    "pdf-workflow-lawyers": {
        "title": "PDF Workflow for Lawyers — Merge, Redact, OCR &amp; E-File (2026)",
        "tool": "/guides/pdf-tools",
        "label": "PDF tools hub",
        "pillar": "/guides/pdf-tools-for-lawyers",
        "pillar_label": "PDF tools for lawyers",
        "related": "/guides/merge-pdf-court-filing",
        "example": "Paralegal merges exhibits, OCRs deposition scans, redacts PII, compresses for CM/ECF under 35 MB",
    },
    "pdf-workflow-marketing-agencies": {
        "title": "PDF Workflow for Marketing Agencies — Decks, Reports &amp; Client Delivery (2026)",
        "tool": "/guides/pdf-tools",
        "label": "PDF tools hub",
        "pillar": "/guides/pdf-tools-marketing-agencies",
        "pillar_label": "PDF tools for marketing agencies",
        "related": "/guides/compress-pdf-marketing-agencies",
        "example": "Account team exports Friday campaign report to PDF, compresses full-bleed deck before client inbox send",
    },
    "pdf-workflow-nonprofits": {
        "title": "PDF Workflow for Nonprofits — Grants, Board Packs &amp; Donor Reports (2026)",
        "tool": "/guides/pdf-tools",
        "label": "PDF tools hub",
        "pillar": "/guides/pdf-tools-nonprofits",
        "pillar_label": "PDF tools for nonprofits",
        "related": "/guides/compress-pdf-nonprofits",
        "example": "Grant writer merges narrative, budget, and 990 excerpt — compresses under funder portal 5 MB cap",
    },
    "pdf-workflow-real-estate": {
        "title": "PDF Workflow for Real Estate — Listings, Disclosures &amp; Leases (2026)",
        "tool": "/guides/pdf-tools",
        "label": "PDF tools hub",
        "pillar": "/guides/pdf-tools-real-estate",
        "pillar_label": "PDF tools for real estate",
        "related": "/guides/compress-pdf-real-estate",
        "example": "Agent merges disclosure pack in state order, compresses photo-heavy listing brochure for buyer email",
    },
    "pdf-workflow-recruiters": {
        "title": "PDF Workflow for Recruiters — Submittals, ATS &amp; Client Packs (2026)",
        "tool": "/guides/pdf-tools",
        "label": "PDF tools hub",
        "pillar": "/guides/pdf-tools-recruiters",
        "pillar_label": "PDF tools for recruiters",
        "related": "/guides/compress-pdf-recruiters",
        "example": "Recruiter merges CV, cover letter, and certs into one 4 MB client submittal after compress pass",
    },
    "pdf-workflow-students": {
        "title": "PDF Workflow for Students — Readings, LMS &amp; Citations (2026)",
        "tool": "/guides/pdf-tools",
        "label": "PDF tools hub",
        "pillar": "/guides/pdf-tools-for-students",
        "pillar_label": "PDF tools for students",
        "related": "/guides/merge-pdf-students",
        "example": "Undergrad merges weekly readings with numeric prefix, OCRs scanned article, compresses for Canvas upload",
    },
    "pdf-workflow-teachers": {
        "title": "PDF Workflow for Teachers — Handouts, LMS &amp; Parent Email (2026)",
        "tool": "/guides/pdf-tools",
        "label": "PDF tools hub",
        "pillar": "/guides/pdf-tools-teachers",
        "pillar_label": "PDF tools for teachers",
        "related": "/guides/compress-pdf-teachers",
        "example": "Teacher merges semester worksheet scans, compresses substitute pack and parent newsletter for Gmail",
    },
    "pdf-to-text-for-blackboard": {
        "title": "Extract Text from PDF for Blackboard — Discussion Posts &amp; Accessibility (2026)",
        "tool": "/pdf/pdftotext",
        "label": "PDF to Text",
        "pillar": "/guides/how-to-extract-text-from-pdf",
        "pillar_label": "extract text from PDF",
        "related": "/guides/compress-pdf-for-lms",
        "example": "TA extracts journal article PDF to plain text for Blackboard discussion prompt — OCR first on scan",
    },
    "pdf-to-text-for-canvas": {
        "title": "Extract Text from PDF for Canvas — Modules, Quizzes &amp; Notes (2026)",
        "tool": "/pdf/pdftotext",
        "label": "PDF to Text",
        "pillar": "/guides/how-to-extract-text-from-pdf",
        "pillar_label": "extract text from PDF",
        "related": "/guides/pdf-tools-for-students",
        "example": "Student exports chapter PDF to .txt for Canvas annotation tool — searchable after OCR on scan",
    },
    "pdf-to-text-for-gmail": {
        "title": "Extract Text from PDF for Gmail — Reply Quotes &amp; Paste to Email (2026)",
        "tool": "/pdf/pdftotext",
        "label": "PDF to Text",
        "pillar": "/guides/how-to-extract-text-from-pdf",
        "pillar_label": "extract text from PDF",
        "related": "/guides/pdf-to-text-online",
        "example": "Sales rep quotes contract clause in Gmail reply — extracts text from PDF instead of retyping",
    },
}

W26_WORKFLOW_DEEP = {
    "pdf-workflow-accountants": """
            <h2>Daily PDF workflow</h2>
            <ol>
            <li>Export reports from accounting system as PDF — verify figures at 100% zoom</li>
            <li><a href="/pdf/merge">Merge PDF</a> statements and annexures — <a href="/guides/merge-pdf-accountants">accountant merge guide</a></li>
            <li><a href="/pdf/compress">Compress PDF</a> client packs — <a href="/guides/compress-pdf-accountants">compress for accountants</a></li>
            <li>Password-protect draft board materials — <a href="/guides/password-protect-pdf">protect PDF</a></li>
            <li>Bank PDF to Excel when client needs editable figures — <a href="/pdf/pdftoexcel">PDF to Excel</a></li>
            </ol>
            <h2>Month-end checklist</h2>
            <ul>
            <li>Board pack order matches agenda index</li>
            <li>GST annexures readable after compress — no clipped decimals</li>
            <li>Filename: ClientName_Report_YYYY-MM.pdf</li>
            </ul>
            <h2>Troubleshooting</h2>
            <p>Merge fails on password PDF — <a href="/guides/unlock-pdf">unlock</a> first. Scanned bank PDFs need <a href="/pdf/ocrpdf">OCR</a> before text extract to Excel.</p>
            <p>Tool map: <a href="/guides/pdf-tools-for-accountants">PDF tools for accountants</a>.</p>
            """,
    "pdf-workflow-construction": """
            <h2>Field-to-office workflow</h2>
            <ol>
            <li>Site photos → <a href="/pdf/convertimages">Images to PDF</a> daily log</li>
            <li>Merge permit sheets in sheet-number order — <a href="/pdf/merge">Merge PDF</a></li>
            <li><a href="/guides/compress-pdf-construction">Compress for city portal</a> — Less on stamped plans</li>
            <li>RFQ package: watermark DRAFT until award — <a href="/pdf/watermark">Watermark PDF</a></li>
            </ol>
            <h2>Quality gates</h2>
            <p>Verify scale bar and sheet index after compress. Split if municipal portal rejects merged size — see <a href="/guides/compress-vs-split">compress vs split</a>.</p>
            <p>Tool map: <a href="/guides/pdf-tools-construction">construction PDF tools</a>.</p>
            """,
    "pdf-workflow-ecommerce": """
            <h2>Catalog and vendor workflow</h2>
            <ul>
            <li><strong>Supplier onboarding:</strong> merge catalog + compliance PDFs — <a href="/guides/compress-pdf-ecommerce">compress ecommerce PDF</a></li>
            <li><strong>Invoices:</strong> <a href="/invoice/create">Create Invoice</a> PDF for B2B buyers</li>
            <li><strong>Marketplace uploads:</strong> check each platform MB cap — compress before bulk upload</li>
            <li><strong>Returns evidence:</strong> <a href="/pdf/convertimages">Images to PDF</a> customer photos</li>
            </ul>
            <h2>SMB stack</h2>
            <p>Agencies and DTC brands share one browser stack — <a href="/guides/pdf-tools-small-business">small business PDF tools</a>.</p>
            """,
    "pdf-workflow-freelancers": """
            <h2>Client delivery workflow</h2>
            <ol>
            <li>Proposal in Word → <a href="/pdf/doctopdf">Word to PDF</a> final send</li>
            <li><a href="/pdf/signtext">Sign PDF</a> SOW — <a href="/guides/sign-pdf-legally">legal context</a></li>
            <li><a href="/guides/compress-pdf-freelancers">Compress portfolio PDF</a> for Gmail</li>
            <li>Invoice PDF — <a href="/guides/invoice-for-freelancers">freelancer invoicing guide</a></li>
            </ol>
            <h2>Limits</h2>
            <p>Never send editable Word for signed scope — PDF prevents silent line edits. Watermark WIP concepts before client preview.</p>
            """,
    "pdf-workflow-healthcare-admin": """
            <h2>Admin PDF stack</h2>
            <ul>
            <li><strong>Prior auth:</strong> merge clinical PDFs — <a href="/guides/compress-pdf-healthcare-admin">compress healthcare admin</a></li>
            <li><strong>Credentialing:</strong> merge license and malpractice certs — numeric filenames</li>
            <li><strong>Fax intake:</strong> <a href="/pdf/ocrpdf">OCR PDF</a> for internal search</li>
            <li><strong>Policy:</strong> follow org BAA — <a href="/guides/pdf-security-compliance-guide">compliance guide</a></li>
            </ul>
            <h2>PHI caution</h2>
            <p>Use only per organizational policy — not a substitute for certified EHR — never public Wi-Fi on member-specific PDFs.</p>
            """,
    "pdf-workflow-hr": """
            <h2>Onboarding workflow</h2>
            <ol>
            <li>Merge offer letter, handbook, benefits — <a href="/pdf/merge">Merge PDF</a></li>
            <li><a href="/guides/compress-pdf-hr">Compress HR pack</a> for new-hire email</li>
            <li>Password-protect packages with SSN scans — separate password channel</li>
            <li>Redact excess PII on reference check PDFs — <a href="/pdf-redaction">PDF Redaction</a></li>
            </ol>
            <h2>Policy distribution</h2>
            <p>Final policy PDF not editable Word — track version in filename Policy_Handbook_v3.2.pdf. Hub: <a href="/guides/secure-pdf-workflow">secure PDF workflow</a>.</p>
            """,
    "pdf-workflow-insurance": """
            <h2>Claims workflow</h2>
            <ul>
            <li>FNOL photos → <a href="/pdf/convertimages">Images to PDF</a></li>
            <li>Merge estimate + police report + dec page — <a href="/pdf/merge">Merge PDF</a></li>
            <li><a href="/guides/compress-pdf-insurance-claims">Compress insurance claims</a> for portal</li>
            <li>Verify VIN and policy number readable at 100% zoom post-compress</li>
            </ul>
            <p>Tool map: <a href="/guides/pdf-tools-insurance">insurance PDF tools</a>.</p>
            """,
    "pdf-workflow-lawyers": """
            <h2>Litigation PDF chain</h2>
            <ol>
            <li>Exhibits — <a href="/guides/merge-pdf-court-filing">merge court filing</a></li>
            <li>Scans — <a href="/pdf/ocrpdf">OCR PDF</a> + <a href="/guides/ocr-pdf-ediscovery">e-discovery OCR</a></li>
            <li>PII — <a href="/guides/pdf-redaction-permanent">permanent redaction</a></li>
            <li>Redlines — <a href="/pdf/pdftodoc">PDF to Word</a> during negotiation only</li>
            <li>E-file — compress after merge under CM/ECF cap</li>
            </ol>
            <h2>When to keep Acrobat</h2>
            <p>Bates audit trail, XFA forms — one lit support seat — daily merge/compress on RatPDF.</p>
            """,
    "pdf-workflow-marketing-agencies": """
            <h2>Client delivery workflow</h2>
            <ul>
            <li>Pitch: <a href="/pdf/ppttopdf">PowerPoint to PDF</a> — <a href="/guides/compress-pdf-marketing-agencies">compress agency deck</a></li>
            <li>Case study assets: <a href="/pdf/extractimages">Extract Images</a> from legacy PDF</li>
            <li>Friday reports: merge analytics PDFs — one compress before send</li>
            <li>Brand QA: Recommended compress before Extreme on full-bleed mockups</li>
            </ul>
            <p>Cap crunch: <a href="/guides/smallpdf-alternative">Smallpdf alternative</a> comparison.</p>
            """,
    "pdf-workflow-nonprofits": """
            <h2>Grant and board workflow</h2>
            <ol>
            <li>Follow funder exhibit index exactly — wrong order = rejection</li>
            <li>Merge narrative + budget + 990 — <a href="/guides/compress-pdf-nonprofits">compress nonprofits</a></li>
            <li>Board email blast — compress merged committee reports</li>
            <li>Program invoices — <a href="/invoice/create">Create Invoice</a></li>
            </ol>
            <p>Tool map: <a href="/guides/pdf-tools-nonprofits">nonprofit PDF tools</a>.</p>
            """,
    "pdf-workflow-real-estate": """
            <h2>Transaction workflow</h2>
            <ul>
            <li>Listing brochure — <a href="/guides/compress-pdf-real-estate">compress real estate PDF</a></li>
            <li>Disclosures merged in state-required order — <a href="/pdf/merge">Merge PDF</a></li>
            <li>Lease drafts — watermark DRAFT — flatten after e-sign export</li>
            <li>Email copy compress only — archive uncompressed master</li>
            </ul>
            <p>Tool map: <a href="/guides/pdf-tools-real-estate">real estate PDF tools</a>.</p>
            """,
    "pdf-workflow-recruiters": """
            <h2>Submittal workflow</h2>
            <ol>
            <li>Merge CV + cover + certs — <a href="/guides/compress-pdf-recruiters">compress recruiter pack</a></li>
            <li>Portal caps: <a href="/guides/compress-pdf-for-linkedin">LinkedIn</a> · <a href="/guides/compress-pdf-for-indeed">Indeed</a></li>
            <li>OCR scanned CVs before client send — ATS text layer</li>
            <li>Redact prior employer direct lines on shared submittals</li>
            </ol>
            <p>Tool map: <a href="/guides/pdf-tools-recruiters">recruiter PDF tools</a>.</p>
            """,
    "pdf-workflow-students": """
            <h2>Semester workflow</h2>
            <ul>
            <li>Readings: <a href="/guides/merge-pdf-students">merge student PDFs</a> — Week01_ prefix</li>
            <li>LMS: <a href="/guides/compress-pdf-for-lms">compress for LMS</a></li>
            <li>Scanned articles: <a href="/pdf/ocrpdf">OCR PDF</a> before cite</li>
            <li>Notes: <a href="/pdf/pdftotext">PDF to Text</a> or <a href="/pdf/pdftomarkdown">PDF to Markdown</a></li>
            </ul>
            <h2>Citation hygiene</h2>
            <p>OCR before quoting — verify page numbers against original scan.</p>
            """,
    "pdf-workflow-teachers": """
            <h2>Classroom workflow</h2>
            <ol>
            <li>Merge weekly worksheets — <a href="/guides/compress-pdf-teachers">compress teachers PDF</a></li>
            <li>Upload to LMS — <a href="/guides/compress-pdf-for-lms">LMS compress guide</a></li>
            <li>Parent newsletter — compress for school Gmail</li>
            <li>Substitute folder — one merged PDF with lesson plan + attachments</li>
            </ol>
            <h2>Scan tips</h2>
            <p>200–250 DPI grayscale for worksheets — not 600 DPI colour phone photos.</p>
            """,
}

W26_TEXT_DEEP = {
    "pdf-to-text-for-blackboard": """
            <h2>Blackboard workflow</h2>
            <ol>
            <li>Check if PDF is digital (select text works) or scan — scan needs <a href="/pdf/ocrpdf">OCR PDF</a> first</li>
            <li>Upload to <a href="/pdf/pdftotext">PDF to Text</a> — download .txt</li>
            <li>Paste excerpt into discussion prompt or Ultra document — keep citation and page ref</li>
            <li>For accessibility: prefer tagged source PDF — OCR is search aid not full remediation</li>
            </ol>
            <h2>LMS limits</h2>
            <p>Large readings — <a href="/guides/compress-pdf-for-lms">compress for LMS</a> before upload — extract text for instructor notes separately.</p>
            <h2>Troubleshooting</h2>
            <p>Empty .txt — see <a href="/guides/pdf-text-extraction-empty">empty text extraction guide</a>.</p>
            """,
    "pdf-to-text-for-canvas": """
            <h2>Canvas workflow</h2>
            <ol>
            <li>Digital chapter PDF — <a href="/pdf/pdftotext">PDF to Text</a> for study notes</li>
            <li>Scanned scan — <a href="/guides/how-to-make-pdf-searchable">make searchable</a> then extract</li>
            <li>Paste into Canvas page, discussion, or external editor — verify paragraph breaks</li>
            <li>Group project: <a href="/text-comparer">Text comparer</a> diffs two chapter extracts</li>
            </ol>
            <p>Student stack: <a href="/guides/pdf-workflow-students">PDF workflow for students</a> · <a href="/guides/pdf-tools-for-students">student PDF tools</a>.</p>
            """,
    "pdf-to-text-for-gmail": """
            <h2>Gmail quote workflow</h2>
            <ol>
            <li>Extract clause from attached contract PDF — <a href="/pdf/pdftotext">PDF to Text</a></li>
            <li>Paste quoted text into reply — add page/section reference</li>
            <li>Do not attach password in same email as protected PDF</li>
            <li>Large attachment still needs <a href="/guides/compress-pdf-for-gmail">compress for Gmail</a> — text extract is separate step</li>
            </ol>
            <h2>When not to paste</h2>
            <p>Tables and multi-column layouts lose structure in text extract — attach PDF or use <a href="/pdf/pdftodoc">PDF to Word</a> for redlines.</p>
            <p>Hub: <a href="/guides/pdf-to-text-online">PDF to text online</a>.</p>
            """,
}

W26_DEEP = {**W26_WORKFLOW_DEEP, **W26_TEXT_DEEP}

W26_WORKFLOW_CLUSTER = """
            <h2>Industry PDF workflow cluster</h2>
            <ul>
            <li><a href="/guides/pdf-workflow-accountants">Accountants</a> · <a href="/guides/pdf-workflow-lawyers">Lawyers</a></li>
            <li><a href="/guides/pdf-workflow-construction">Construction</a> · <a href="/guides/pdf-workflow-real-estate">Real estate</a></li>
            <li><a href="/guides/pdf-workflow-healthcare-admin">Healthcare admin</a> · <a href="/guides/pdf-workflow-insurance">Insurance</a></li>
            <li><a href="/guides/pdf-workflow-hr">HR</a> · <a href="/guides/pdf-workflow-recruiters">Recruiters</a></li>
            <li><a href="/guides/pdf-workflow-marketing-agencies">Marketing</a> · <a href="/guides/pdf-workflow-nonprofits">Nonprofits</a></li>
            <li><a href="/guides/pdf-workflow-ecommerce">Ecommerce</a> · <a href="/guides/pdf-workflow-freelancers">Freelancers</a></li>
            <li><a href="/guides/pdf-workflow-students">Students</a> · <a href="/guides/pdf-workflow-teachers">Teachers</a></li>
            </ul>
            <p>Government: <a href="/guides/pdf-workflow-government">government workflow</a> · Hub: <a href="/guides/pdf-tools">PDF tools</a></p>
            """

W26_TEXT_CLUSTER = """
            <h2>PDF to text — platform cluster (batch 1)</h2>
            <ul>
            <li><a href="/guides/pdf-to-text-for-blackboard">Blackboard</a></li>
            <li><a href="/guides/pdf-to-text-for-canvas">Canvas</a></li>
            <li><a href="/guides/pdf-to-text-for-gmail">Gmail</a></li>
            </ul>
            <p>Next: Outlook, LinkedIn, Indeed, Moodle — Pillar: <a href="/guides/how-to-extract-text-from-pdf">extract text from PDF</a></p>
            """

W26_WORKFLOW_TOPUP = """
            <h2>Industry workflow rollout checklist</h2>
            <ol>
            <li>Pick one high-volume task (merge, compress, or sign) as weekly default</li>
            <li>Document filename convention and compress level in team wiki</li>
            <li>Run hardest sample PDF through tool chain before mandating for juniors</li>
            <li>Link this workflow page from onboarding Notion / SharePoint</li>
            <li>Review quarterly — portal caps and e-file limits change slowly but do change</li>
            </ol>
            <h2>Compare stacks</h2>
            <p><a href="/guides/pdf-tools-small-business">SMB PDF stack</a> · <a href="/compare/adobe-acrobat-alternative">Adobe alternative</a> · <a href="/guides/choose-pdf-tool">choose PDF tool</a>.</p>
            """

W26_CLOSING = """
            <h2>Related guides</h2>
            <p>Industry workflow pages pair with role-specific PDF tool maps and compress guides — bookmark your vertical hub and the matching <a href="/guides/pdf-tools">PDF tools</a> index.</p>
            """
