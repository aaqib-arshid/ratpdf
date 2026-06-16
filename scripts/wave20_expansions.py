"""Wave 20 — Tools hub + edit guides + regional visa/bank batch 3."""

W20_SLUGS = [
    "pdf-tool-market-comparison",
    "best-free-pdf-tools-2026",
    "pdf-tool-security-comparison",
    "tesseract-vs-online-ocr",
    "choose-pdf-tool",
    "compress-vs-split",
    "merge-vs-compress",
    "pdf-to-powerpoint",
    "add-signature-to-pdf",
    "edit-pdf-mistakes-compliance",
    "edit-pdf-online-free",
    "visa-application-pdf-workflow-italy",
    "visa-application-pdf-workflow-mexico",
    "visa-application-pdf-workflow-new-zealand",
    "visa-application-pdf-workflow-south-africa",
    "visa-application-pdf-workflow-south-korea",
    "bank-statement-pdf-workflow-italy",
]

TOOLS_SLUGS = {
    "pdf-tool-market-comparison",
    "best-free-pdf-tools-2026",
    "pdf-tool-security-comparison",
    "tesseract-vs-online-ocr",
    "choose-pdf-tool",
    "compress-vs-split",
    "merge-vs-compress",
}

EDIT_SLUGS = {
    "pdf-to-powerpoint",
    "add-signature-to-pdf",
    "edit-pdf-mistakes-compliance",
    "edit-pdf-online-free",
}

VISA_SLUGS = {
    "visa-application-pdf-workflow-italy",
    "visa-application-pdf-workflow-mexico",
    "visa-application-pdf-workflow-new-zealand",
    "visa-application-pdf-workflow-south-africa",
    "visa-application-pdf-workflow-south-korea",
}

BANK_SLUGS = {"bank-statement-pdf-workflow-italy"}

W20_DATA = {
    "pdf-tool-market-comparison": {
        "title": "PDF Tool Market Comparison — Vendor Matrix for IT &amp; SMB Buyers (2026)",
        "tool": "/guides/pdf-tools",
        "label": "PDF tools hub",
        "pillar": "/guides/choose-pdf-tool",
        "pillar_label": "how to choose a PDF tool",
        "research": "/research/pdf-tool-market-comparison",
        "example": "IT manager builds vendor shortlist — merge, compress, OCR, retention policy — before renewing Acrobat site license",
    },
    "best-free-pdf-tools-2026": {
        "title": "Best Free PDF Tools in 2026 — Merge, Compress, Convert &amp; Sign Roundup",
        "tool": "/guides/pdf-tools",
        "label": "PDF tools hub",
        "pillar": "/guides/pdf-tool-alternatives",
        "pillar_label": "PDF tool alternatives hub",
        "research": "/compare",
        "example": "Freelancer compares RatPDF, Smallpdf, and iLovePDF daily caps before client crunch week",
    },
    "pdf-tool-security-comparison": {
        "title": "PDF Tool Security Comparison — Privacy, Retention &amp; Trust Claims (2026)",
        "tool": "/home/security",
        "label": "Security page",
        "pillar": "/guides/secure-pdf-workflow",
        "pillar_label": "secure PDF workflow",
        "research": "/research/pdf-tool-market-comparison",
        "example": "Legal ops reviews HIPAA-adjacent contract PDFs — rejects tool with unclear file retention",
    },
    "tesseract-vs-online-ocr": {
        "title": "Tesseract vs Online OCR — Privacy, Accuracy &amp; When to Use Each (2026)",
        "tool": "/pdf/ocrpdf",
        "label": "OCR PDF",
        "pillar": "/guides/ocr-pdf",
        "pillar_label": "OCR PDF guide",
        "research": "/research/pdf-tool-market-comparison",
        "example": "HR scans 200 employee forms — cloud OCR blocked by policy — Tesseract path on RatPDF",
    },
    "choose-pdf-tool": {
        "title": "How to Choose a PDF Tool — 2026 Buyer Guide for Teams &amp; Freelancers",
        "tool": "/compare",
        "label": "Compare vendors",
        "pillar": "/guides/pdf-tool-alternatives",
        "pillar_label": "PDF tool alternatives hub",
        "research": "/research/pdf-tool-market-comparison",
        "example": "Ops lead scores five vendors on free limits, max file size, invoice PDF, and GDPR FAQ depth",
    },
    "compress-vs-split": {
        "title": "Compress vs Split PDF — Fix Attachments Too Large (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/compress-pdf-guide",
        "pillar_label": "compress PDF guide",
        "research": "/research/pdf-compression-benchmark",
        "example": "Paralegal has 42 MB single exhibit — compress blurs footnotes — split into Part 1 and Part 2 instead",
    },
    "merge-vs-compress": {
        "title": "Merge vs Compress PDF — Which Step First? (2026)",
        "tool": "/pdf/merge",
        "label": "Merge PDF",
        "pillar": "/guides/merge-pdf",
        "pillar_label": "merge PDF guide",
        "research": "/research/pdf-compression-benchmark",
        "example": "Accountant merges twelve monthly statements then compresses once — not twelve separate compress passes",
    },
    "pdf-to-powerpoint": {
        "title": "PDF to PowerPoint — Convert Pages to Editable Slides (2026)",
        "tool": "/pdf/pdftoppt",
        "label": "PDF to PowerPoint",
        "pillar": "/guides/pdf-conversion-guide",
        "pillar_label": "PDF conversion guide",
        "research": "/compare/adobe-acrobat-alternative",
        "example": "Consultant receives client strategy PDF — needs editable PPTX for workshop slides",
    },
    "add-signature-to-pdf": {
        "title": "Add Signature to PDF — Typed, Image &amp; Approval Workflows (2026)",
        "tool": "/pdf/signtext",
        "label": "Sign PDF",
        "pillar": "/guides/sign-pdf-legally",
        "pillar_label": "sign PDF legally guide",
        "research": "/guides/pdf-tool-security-comparison",
        "example": "Sales rep adds typed signature and date to quote PDF before client countersign on DocuSign",
    },
    "edit-pdf-mistakes-compliance": {
        "title": "Edit PDF Mistakes That Break Compliance — Audit &amp; Legal Pitfalls (2026)",
        "tool": "/pdf/editpdf",
        "label": "Edit PDF",
        "pillar": "/guides/pdf-security-compliance-guide",
        "pillar_label": "PDF security compliance guide",
        "research": "/guides/pdf-redaction-permanent",
        "example": "Compliance officer finds black-box redaction on disclosure PDF — hidden text still copyable",
    },
    "edit-pdf-online-free": {
        "title": "Edit PDF Online Free — Text, Images &amp; Pages in Browser (2026)",
        "tool": "/pdf/editpdf",
        "label": "Edit PDF",
        "pillar": "/guides/edit-pdf",
        "pillar_label": "edit PDF guide",
        "research": "/compare/sejda-alternative",
        "example": "Remote worker adds company stamp and corrects typo on contract PDF without Acrobat install",
    },
    "visa-application-pdf-workflow-italy": {
        "title": "Visa Application PDF Workflow Italy — Schengen &amp; VFS Upload Pack (2026)",
        "tool": "/pdf/merge",
        "label": "Merge PDF",
        "pillar": "/guides/merge-pdf-visa-application",
        "pillar_label": "merge PDF for visa guide",
        "research": "/guides/compress-pdf-schengen-visa",
        "example": "Student merges Italy D visa financials, insurance, and itinerary PDFs for VFS appointment city",
    },
    "visa-application-pdf-workflow-mexico": {
        "title": "Visa Application PDF Workflow Mexico — Consulate &amp; VFS Document Pack (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/merge-pdf-visa-application",
        "pillar_label": "merge PDF for visa guide",
        "research": "/guides/compress-pdf-for-visa-application",
        "example": "Applicant compresses bank statements and employment letter for Mexico tourist visa portal",
    },
    "visa-application-pdf-workflow-new-zealand": {
        "title": "Visa Application PDF Workflow New Zealand — Immigration NZ Upload (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/merge-pdf-visa-application",
        "pillar_label": "merge PDF for visa guide",
        "research": "/guides/compress-pdf-for-visa-application",
        "example": "Skilled migrant compresses police certificate and funds PDF for Immigration NZ online form",
    },
    "visa-application-pdf-workflow-south-africa": {
        "title": "Visa Application PDF Workflow South Africa — VFS &amp; DHA PDF Checklist (2026)",
        "tool": "/pdf/merge",
        "label": "Merge PDF",
        "pillar": "/guides/merge-pdf-visa-application",
        "pillar_label": "merge PDF for visa guide",
        "research": "/guides/compress-pdf-for-visa-application",
        "example": "Visitor visa applicant merges invitation letter, bank proof, and passport bio PDF for VFS upload",
    },
    "visa-application-pdf-workflow-south-korea": {
        "title": "Visa Application PDF Workflow South Korea — Embassy &amp; K-ETA Support Docs (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/merge-pdf-visa-application",
        "pillar_label": "merge PDF for visa guide",
        "research": "/guides/compress-pdf-for-visa-application",
        "example": "Language student compresses admission letter and funds PDF for Korean embassy document slot",
    },
    "bank-statement-pdf-workflow-italy": {
        "title": "Bank Statement PDF Workflow Italy — Visa &amp; Rental Evidence (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/visa-application-pdf-workflow-italy",
        "pillar_label": "Italy visa workflow",
        "research": "/guides/compress-pdf-schengen-visa",
        "example": "Applicant compresses Intesa Sanpaolo netbank PDF export for Italy Schengen financial evidence",
    },
}

W20_TOOLS_DEEP = {
    "pdf-tool-market-comparison": """
            <h2>Why a market comparison matters in 2026</h2>
            <p>PDF tool vendors overlap on merge and compress but diverge on retention, max file size, OCR languages, invoice PDF, and qualified e-sign. Procurement teams need a matrix — not marketing badges — before multi-seat Acrobat renewals or shadow IT on random upload sites.</p>
            <h2>Evaluation dimensions</h2>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>Dimension</th><th>Ask vendors</th><th>RatPDF reference</th></tr></thead>
            <tbody>
            <tr><td>Free tier</td><td>Tasks per day, per tool or pooled?</td><td>3 uses per tool/day — see <a href="/compare">compare hub</a></td></tr>
            <tr><td>Max upload</td><td>Single file GB cap on free vs Pro?</td><td>Pro tier for large board packs</td></tr>
            <tr><td>Retention</td><td>Auto-delete SLA in writing?</td><td><a href="/home/security">Security page</a></td></tr>
            <tr><td>OCR engine</td><td>Cloud vs on-server Tesseract?</td><td><a href="/guides/tesseract-vs-online-ocr">Tesseract vs cloud OCR</a></td></tr>
            <tr><td>Invoice PDF</td><td>Included or separate SaaS?</td><td><a href="/invoice/create">Create Invoice</a></td></tr>
            <tr><td>Authority depth</td><td>Task-specific guides or thin landings?</td><td>600+ guides — compress for Gmail, visa merge, etc.</td></tr>
            </tbody></table></div>
            <h2>Vendor tiers (typical)</h2>
            <ul>
            <li><strong>Browser aggregators:</strong> RatPDF, iLovePDF, Smallpdf, PDF24, Sejda — fast tasks, daily caps</li>
            <li><strong>Desktop suites:</strong> Adobe Acrobat, Foxit, PDFelement — redaction audit, JavaScript forms, offline classified</li>
            <li><strong>E-sign platforms:</strong> DocuSign, Adobe Sign — qualified signatures, not merge/compress replacement</li>
            </ul>
            <h2>Migration workflow</h2>
            <ol>
            <li>Survey team: top 10 PDF tasks last quarter</li>
            <li>Score three finalists on matrix above</li>
            <li>Parallel pilot on non-confidential samples one week</li>
            <li>Keep one desktop seat for edge cases — prepress, XFA forms</li>
            <li>Publish internal wiki linking <a href="/guides/pdf-tools">PDF tools hub</a></li>
            </ol>
            <p>Full research table: <a href="/research/pdf-tool-market-comparison">PDF tool market comparison research</a> · Buyer guide: <a href="/guides/choose-pdf-tool">choose a PDF tool</a>.</p>
            <h2>Troubleshooting vendor selection</h2>
            <p><strong>Legal blocks all cloud upload:</strong> desktop-only or self-hosted OCR. <strong>Marketing needs brand templates:</strong> keep InDesign/Canva export — PDF tools handle delivery compress. <strong>Finance needs invoice + merge:</strong> RatPDF single vendor vs two subscriptions.</p>
            """,
    "best-free-pdf-tools-2026": """
            <h2>What “best free” actually means</h2>
            <p>No single free PDF site wins every task. Best depends on daily volume, max file size, whether you need invoice PDF, and if legal allows cloud processing. This roundup compares realistic free tiers — not headline “unlimited” claims that hide hourly caps.</p>
            <h2>Quick picks by job</h2>
            <ul>
            <li><strong>Merge + compress email pack:</strong> <a href="/pdf/merge">RatPDF Merge</a> + <a href="/pdf/compress">Compress</a> — 3/day per tool</li>
            <li><strong>PDF to Word redline:</strong> <a href="/pdf/pdftodoc">PDF to Word</a> — digital PDFs first</li>
            <li><strong>Scanned Hindi/English forms:</strong> <a href="/pdf/ocrpdf">OCR PDF</a> — see <a href="/guides/tesseract-vs-online-ocr">Tesseract guide</a></li>
            <li><strong>Freelancer invoice PDF:</strong> <a href="/invoice/create">Create Invoice</a> — no separate app</li>
            <li><strong>Large file merge:</strong> compare PDF24 vs RatPDF Pro caps on live pricing pages</li>
            </ul>
            <h2>Free tier comparison snapshot</h2>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>Vendor</th><th>Typical free limit</th><th>Notable gap</th></tr></thead>
            <tbody>
            <tr><td>RatPDF</td><td>3 uses/tool/day</td><td>Pro for high volume</td></tr>
            <tr><td>Smallpdf</td><td>~2 tasks/day pooled</td><td>Strong compression gated</td></tr>
            <tr><td>iLovePDF</td><td>Daily task cap</td><td>OCR/e-sign upsell</td></tr>
            <tr><td>Adobe Online</td><td>Account + low free tasks</td><td>Pushes desktop Acrobat</td></tr>
            <tr><td>PDF24</td><td>Generous merge limits</td><td>Thinner English guides</td></tr>
            </tbody></table></div>
            <p>Verify limits on vendor sites — they change. Deep dives: <a href="/guides/smallpdf-alternative">Smallpdf alternative</a> · <a href="/guides/ilovepdf-alternative">iLovePDF alternative</a> · <a href="/guides/adobe-acrobat-alternative">Adobe alternative</a>.</p>
            <h2>Safety checklist for free tools</h2>
            <ol>
            <li>HTTPS only — check padlock and privacy policy link</li>
            <li>Retention — auto-delete after download stated?</li>
            <li>No unnecessary account for one-off job</li>
            <li>Classified/PHI — use approved vendor only</li>
            </ol>
            <p>Security matrix: <a href="/guides/pdf-tool-security-comparison">PDF tool security comparison</a>.</p>
            """,
    "pdf-tool-security-comparison": """
            <h2>Security questions legal asks</h2>
            <p>Before approving a browser PDF tool, security teams ask: where files process, how long they persist, whether TLS terminates correctly, and if subprocessors list includes unknown OCR APIs. Marketing GDPR badges are not a DPA.</p>
            <h2>Comparison checklist</h2>
            <ul>
            <li><strong>Transport:</strong> TLS 1.2+ on upload and download</li>
            <li><strong>Retention:</strong> auto-delete after processing — get SLA in writing</li>
            <li><strong>OCR path:</strong> server-side Tesseract vs third-party cloud — see <a href="/guides/tesseract-vs-online-ocr">OCR comparison</a></li>
            <li><strong>Logging:</strong> are filenames/content logged to analytics?</li>
            <li><strong>Account data:</strong> email required for free tier?</li>
            <li><strong>Output integrity:</strong> watermarks on free exports?</li>
            </ul>
            <h2>When browser tools are appropriate</h2>
            <p>Routine B2B quotes, public marketing PDFs, resume compress for job portals — low sensitivity. Not appropriate: unreleased earnings, patient records, export-controlled drawings — use approved on-prem or qualified vendor with BAA.</p>
            <h2>Incident response</h2>
            <p>If employee uploaded wrong file to random PDF site — assume retention until vendor confirms purge — rotate credentials if password PDF uploaded — document in security ticket.</p>
            <p>Hub: <a href="/guides/secure-pdf-workflow">Secure PDF workflow</a> · Market context: <a href="/research/pdf-tool-market-comparison">vendor matrix research</a>.</p>
            """,
    "tesseract-vs-online-ocr": """
            <h2>Two OCR architectures</h2>
            <p><strong>Tesseract</strong> is open-source OCR running on the processing server — no separate cloud OCR API call for the text layer. <strong>Online/cloud OCR</strong> sends page images to a vendor API — often higher accuracy on messy scans but adds subprocessors and latency.</p>
            <h2>Decision tree</h2>
            <ol>
            <li>Digital PDF with copyable text? → skip OCR — use <a href="/pdf/pdftotext">PDF to Text</a></li>
            <li>Policy blocks external OCR API? → Tesseract path on <a href="/pdf/ocrpdf">OCR PDF</a></li>
            <li>Handwriting or low-contrast fax? → cloud OCR may win — legal must approve</li>
            <li>Multilingual Indian forms? → verify language pack — <a href="/guides/ocr-hindi-pdf">OCR Hindi guide</a></li>
            </ol>
            <h2>Quality factors</h2>
            <ul>
            <li>Scan at 300 DPI grayscale for typed forms</li>
            <li>Deskew and crop before OCR — browser scan apps often over-compress</li>
            <li>OCR then compress — not compress then OCR on scans</li>
            <li>Verify random paragraph after OCR — search for garbled account numbers</li>
            </ul>
            <h2>Privacy table</h2>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>Approach</th><th>Pros</th><th>Cons</th></tr></thead>
            <tbody>
            <tr><td>Tesseract on-server</td><td>Fewer subprocessors, predictable path</td><td>Weaker on handwriting</td></tr>
            <tr><td>Cloud OCR API</td><td>Layout tables, handwriting</td><td>DPA, latency, cost</td></tr>
            </tbody></table></div>
            <p>Pillar: <a href="/guides/ocr-pdf">OCR PDF guide</a> · Compare vendors: <a href="/guides/pdf-tool-market-comparison">PDF tool market comparison</a>.</p>
            """,
    "choose-pdf-tool": """
            <h2>Buyer guide framework</h2>
            <p>Choose a PDF tool by task frequency, file size, compliance tier, and whether you need invoice or e-sign in the same vendor. Avoid paying for Acrobat seats when team only merges and compresses twice weekly.</p>
            <h2>Step-by-step selection</h2>
            <ol>
            <li>List top tasks: merge, compress, Word convert, OCR, sign, invoice</li>
            <li>Note strictest file size limit — email gateway vs portal</li>
            <li>Score 3 vendors on free tier math — tasks × people × days</li>
            <li>Run hardest sample file on each — scanned table PDF, 80 MB pack</li>
            <li>Read retention policy — link <a href="/guides/pdf-tool-security-comparison">security comparison</a></li>
            <li>Document winner in onboarding wiki with deep links to guides</li>
            </ol>
            <h2>Persona shortcuts</h2>
            <ul>
            <li><strong>Freelancer:</strong> merge + invoice + compress — <a href="/guides/pdf-tools-small-business">SMB guide</a></li>
            <li><strong>Legal:</strong> OCR exhibits + merge docket — keep desktop for redaction audit</li>
            <li><strong>HR:</strong> policy PDFs + form fill — <a href="/guides/edit-pdf-forms">edit forms guide</a></li>
            <li><strong>Student:</strong> LMS compress — <a href="/guides/compress-pdf-for-lms">LMS compress guide</a></li>
            </ul>
            <p>Alternatives hub: <a href="/guides/pdf-tool-alternatives">PDF tool alternatives</a> · Research matrix: <a href="/research/pdf-tool-market-comparison">market comparison</a> · Roundup: <a href="/guides/best-free-pdf-tools-2026">best free tools 2026</a>.</p>
            """,
    "compress-vs-split": """
            <h2>Same symptom — different fix</h2>
            <p>Both compress and split solve “attachment too large.” Compress reduces bytes inside one PDF. Split creates multiple smaller PDFs. Portals that allow only one upload slot force compress; email threads that allow multiple attachments may prefer split when compression would blur fine print.</p>
            <h2>When to compress first</h2>
            <ul>
            <li>Typed digital PDF — text survives Recommended compression</li>
            <li>Court or portal requires single PDF volume</li>
            <li>Recipient expects one download link</li>
            <li>File 30 MB, cap 25 MB — moderate compress often enough</li>
            </ul>
            <h2>When to split instead</h2>
            <ul>
            <li>Scanned legal fine print softens at Extreme compression</li>
            <li>Exhibit index allows Part 1 / Part 2 naming</li>
            <li>Mixed sensitivity — send public summary split from confidential annex</li>
            <li>Already at minimum quality — split is only option</li>
            </ul>
            <h2>Workflow</h2>
            <ol>
            <li>Check recipient cap with <a href="/pdf-size-checker">PDF size checker</a></li>
            <li>Try <a href="/pdf/compress">Compress PDF</a> Recommended — verify 100% zoom</li>
            <li>If blur unacceptable → <a href="/pdf/split">Split PDF</a> by page range</li>
            <li>Label files clearly — Part1of2 filename</li>
            </ol>
            <p>Related: <a href="/guides/merge-vs-compress">merge vs compress order</a> · Benchmark: <a href="/research/pdf-compression-benchmark">compression benchmark</a>.</p>
            """,
    "merge-vs-compress": """
            <h2>Order matters for bundles</h2>
            <p>Wrong order wastes time or quality. Standard visa and board-pack workflow: prepare each PDF → merge in checklist order → OCR scans if search needed → compress once on merged output.</p>
            <h2>Merge first (usual)</h2>
            <ul>
            <li>Visa document pack — one upload slot — <a href="/guides/merge-pdf-visa-application">visa merge guide</a></li>
            <li>Board pack twelve PDFs — one email attachment</li>
            <li>Compress once on 45 MB merged file faster than twelve compress passes</li>
            </ul>
            <h2>Compress first (exceptions)</h2>
            <ul>
            <li>Each attachment must stay separate — compress individually</li>
            <li>One oversized scan would blow merge cap before others added</li>
            <li>Portal per-file cap before merge allowed — compress each slot</li>
            </ul>
            <h2>Anti-patterns</h2>
            <p>Merge uncompressed 200 DPI phone photos then wonder why compress fails — compress heavy scans before merge when each alone exceeds cap. Merge password-protected PDFs without unlock — fails silently — <a href="/guides/merge-password-protected-pdf">unlock first</a>.</p>
            <p>Hub: <a href="/guides/merge-pdf">merge PDF guide</a> · <a href="/guides/compress-pdf-guide">compress guide</a> · <a href="/guides/compress-vs-split">compress vs split</a>.</p>
            """,
}

W20_EDIT_DEEP = {
    "pdf-to-powerpoint": """
            <h2>PDF to PPTX use cases</h2>
            <p>Client sends PDF deck — you need editable slides for workshop. Investor one-pager as PDF — rebuild branding in PowerPoint. Annual report PDF — extract charts slide-by-slide for internal briefing.</p>
            <h2>Workflow</h2>
            <ol>
            <li>Upload PDF to <a href="/pdf/pdftoppt">PDF to PowerPoint</a></li>
            <li>Download PPTX — open in PowerPoint or Google Slides</li>
            <li>Fix fonts — replace missing corporate fonts</li>
            <li>Recreate charts as native objects if exported as images</li>
            <li>Export PDF again via <a href="/pdf/ppttopdf">PowerPoint to PDF</a> for final send</li>
            </ol>
            <h2>Quality expectations</h2>
            <p>Vector PDF slides convert cleanly. Flattened print PDFs become image slides — manual text overlay required. Scanned slide PDFs need <a href="/pdf/ocrpdf">OCR</a> before meaningful edit.</p>
            <h2>Troubleshooting</h2>
            <p><strong>Blank slides:</strong> PDF uses transparency — try re-export from source app. <strong>Wrong aspect:</strong> 16:9 vs 4:3 — resize slide master. <strong>Huge PPTX:</strong> image-heavy — compress images in PowerPoint before share.</p>
            <p>Reverse path: <a href="/guides/powerpoint-to-pdf">PowerPoint to PDF guide</a> · Compare: <a href="/compare/adobe-acrobat-alternative">Adobe alternative</a>.</p>
            """,
    "add-signature-to-pdf": """
            <h2>Signature types on PDFs</h2>
            <ul>
            <li><strong>Typed signature block:</strong> name + title + date — <a href="/pdf/signtext">Sign PDF</a></li>
            <li><strong>Image signature:</strong> PNG of wet ink — insert via <a href="/pdf/editpdf">Edit PDF</a></li>
            <li><strong>Qualified e-sign:</strong> DocuSign/Adobe Sign — legal weight for regulated deals</li>
            </ul>
            <h2>Workflow — typed approval</h2>
            <ol>
            <li>Final PDF quote or SOW — no draft watermark</li>
            <li>Open Sign PDF — add typed name and date block</li>
            <li>Download signed copy — email to client</li>
            <li>Archive original unsigned master separately</li>
            </ol>
            <h2>Compliance notes</h2>
            <p>Typed signatures suffice for many B2B approvals combined with email thread evidence — not for all jurisdictions or property deeds. See <a href="/guides/sign-pdf-legally">sign PDF legally guide</a>. Do not flatten before client countersign if they need to edit.</p>
            <h2>Troubleshooting</h2>
            <p><strong>Signature blurry after compress:</strong> use Less compression on signed PDF. <strong>Client needs editable fields:</strong> send Word or use e-sign platform. <strong>Password PDF:</strong> unlock before sign.</p>
            """,
    "edit-pdf-mistakes-compliance": """
            <h2>Edits that create liability</h2>
            <ul>
            <li><strong>Fake redaction:</strong> black rectangle overlay — text still in PDF stream — use <a href="/guides/pdf-redaction-permanent">permanent redaction</a></li>
            <li><strong>Metadata leak:</strong> author field shows personal Gmail on court filing — strip with metadata tool</li>
            <li><strong>Version confusion:</strong> edited PDF saved over signed original — keep WORM archive</li>
            <li><strong>Flattening too early:</strong> loses form editability for counterparty</li>
            <li><strong>OCR on redacted doc:</strong> can resurrect removed text from image layer — redact after final OCR pass</li>
            </ul>
            <h2>Audit-ready workflow</h2>
            <ol>
            <li>Identify record class — public, confidential, regulated</li>
            <li>Edit in controlled copy — suffix _DRAFT until approval</li>
            <li>Redact with burn-out tool — verify search finds zero hits</li>
            <li>Flatten only on final published version</li>
            <li>Log who exported which version — email hash optional</li>
            </ol>
            <p>Hub: <a href="/guides/pdf-security-compliance-guide">PDF security compliance</a> · <a href="/guides/secure-pdf-workflow">secure workflow</a>.</p>
            """,
    "edit-pdf-online-free": """
            <h2>Free browser edit scope</h2>
            <p>RatPDF Edit PDF covers text boxes, images, highlights, stamps, and page delete — not full InDesign layout or XFA form designer. Free tier within daily limits — no desktop install.</p>
            <h2>Step-by-step</h2>
            <ol>
            <li>Upload PDF to <a href="/pdf/editpdf">Edit PDF</a></li>
            <li>Add text for date, address fix, or clause typo on digital PDF</li>
            <li>Insert logo PNG on cover — resize handles</li>
            <li>Delete blank trailing page</li>
            <li>Download — verify fonts at 100% zoom</li>
            </ol>
            <h2>Scanned PDF path</h2>
            <p>Image-only scan — run <a href="/pdf/ocrpdf">OCR PDF</a> first or text tools fail. Heavy clause rewrite — <a href="/pdf/pdftodoc">PDF to Word</a> then back to PDF.</p>
            <h2>Limits vs Sejda/Adobe</h2>
            <p>Compare daily caps: <a href="/guides/sejda-alternative">Sejda alternative</a> · <a href="/guides/adobe-acrobat-alternative">Adobe alternative</a>. Device guides: <a href="/guides/edit-pdf-on-mac">Mac</a> · <a href="/guides/edit-pdf-on-windows">Windows</a> · <a href="/guides/edit-pdf-on-iphone">iPhone</a>.</p>
            """,
}

def _visa_deep(name: str, portal: str, cap: str, compress_slug: str, note: str, extra: str) -> str:
    return f"""
            <h2>{name} visa PDF pack</h2>
            <p>Portal: <strong>{portal}</strong> — typical cap: {cap}. {note}</p>
            <h2>Workflow</h2>
            <ol>
            <li>Download embassy checklist PDF — numeric prefix filenames 01_passport 02_funds</li>
            <li>Per-slot vs single bundle — read FAQ before <a href="/pdf/merge">Merge PDF</a></li>
            <li><a href="/guides/{compress_slug}">Compress</a> each file under cap — verify dates at 100% zoom</li>
            <li>Schengen missions: <a href="/guides/compress-pdf-schengen-visa">Schengen compress guide</a></li>
            <li>Upload on stable connection — session timeouts common on VFS</li>
            </ol>
            {extra}
            <p>Hub: <a href="/guides/pdf-regional-workflows-hub">Regional workflows hub</a> · <a href="/guides/merge-pdf-visa-application">Visa merge guide</a>.</p>
            """


W20_VISA_DEEP = {
    "visa-application-pdf-workflow-italy": _visa_deep(
        "Italy",
        "VFS Global / Italian consulate portal",
        "often 2–5 MB per slot on Schengen uploads",
        "compress-pdf-schengen-visa",
        "Financial means, insurance, accommodation, itinerary — mission-specific checklist",
        """
            <h2>Schengen Italy specifics</h2>
            <p>Book VFS slot before upload prep — some cities require separate insurance PDF slot. Bank statements as official PDF not mobile screenshot. Cover letter optional but helps officer navigation.</p>
            <h2>Troubleshooting</h2>
            <p><strong>Upload loops:</strong> filename special characters — use ASCII only. <strong>Blurry stamp:</strong> Less compression on bank PDF. <strong>Merged rejected:</strong> portal wanted separate files — split again.</p>
            """,
    ),
    "visa-application-pdf-workflow-mexico": _visa_deep(
        "Mexico",
        "Consulate / VFS Mexico appointment system",
        "varies — compress to under 3 MB safe default per slot",
        "compress-pdf-for-visa-application",
        "Financial proof, employment letter, itinerary — Spanish labels on filenames help staff",
        """
            <h2>Mexico tourist vs work</h2>
            <p>Tourist flows emphasize funds and return ticket PDF. Work visas add employer letter and HR documents — merge only if checklist allows single bundle.</p>
            """,
    ),
    "visa-application-pdf-workflow-new-zealand": _visa_deep(
        "New Zealand",
        "Immigration NZ online / RealMe login",
        "often 10 MB per file on many forms — still compress multi-hundred-page police certs",
        "compress-pdf-for-visa-application",
        "Skilled migrant, student, visitor — police certificate and medical PDF slots",
        """
            <h2>Immigration NZ tips</h2>
            <p>Police certificate PDF from issuing authority — not photo scan when official PDF available. Evidence bundle order matches online form sections — do not random merge.</p>
            """,
    ),
    "visa-application-pdf-workflow-south-africa": _visa_deep(
        "South Africa",
        "VFS / DHA supported portals",
        "often 2–5 MB per upload on visitor visa flows",
        "compress-pdf-for-visa-application",
        "Invitation letter, bank statements, yellow fever cert if applicable",
        """
            <h2>Visitor visa pack</h2>
            <p>Host invitation PDF with SA ID copy — compress separately from applicant bank PDF. Passport bio page high contrast scan.</p>
            """,
    ),
    "visa-application-pdf-workflow-south-korea": _visa_deep(
        "South Korea",
        "Embassy portal / visa.go.kr support docs",
        "mission-specific — often 2–5 MB per attachment",
        "compress-pdf-for-visa-application",
        "Admission letter, funds, family register translations — embassy checklist strict on PDF not JPG",
        """
            <h2>Student D-2/D-4</h2>
            <p>University admission PDF in English or Korean — financial sponsor statement separate slot. Do not merge if embassy FAQ lists individual uploads.</p>
            """,
    ),
}

W20_BANK_DEEP = {
    "bank-statement-pdf-workflow-italy": """
            <h2>Italian bank statement PDF</h2>
            <p>Official home banking PDF export from Intesa Sanpaolo, UniCredit, BPM — not CSV screenshot. Schengen visa officers expect name, IBAN, transaction history, closing balance legible.</p>
            <h2>Workflow</h2>
            <ol>
            <li>Export 3–6 months PDF from online banking</li>
            <li>Verify Italian/English labels and stamp if paper scan</li>
            <li><a href="/pdf/compress">Compress PDF</a> Recommended if over 2–3 MB slot</li>
            <li>Less compression if transaction lines soften</li>
            <li>Pair with <a href="/guides/visa-application-pdf-workflow-italy">Italy visa workflow</a></li>
            </ol>
            <h2>Rental applications</h2>
            <p>Milan/Rome landlords may ask last 3 payslips plus bank PDF — merge only if agency allows single file.</p>
            <p>Schengen: <a href="/guides/compress-pdf-schengen-visa">compress Schengen visa PDFs</a> · Hub: <a href="/guides/pdf-regional-workflows-hub">regional workflows</a>.</p>
            """,
}

W20_DEEP = {**W20_TOOLS_DEEP, **W20_EDIT_DEEP, **W20_VISA_DEEP, **W20_BANK_DEEP}

W20_TOOLS_CLUSTER = """
            <h2>Tools &amp; compare cluster</h2>
            <ul>
            <li><a href="/guides/pdf-tool-market-comparison">Market comparison</a></li>
            <li><a href="/guides/best-free-pdf-tools-2026">Best free tools 2026</a></li>
            <li><a href="/guides/pdf-tool-security-comparison">Security comparison</a></li>
            <li><a href="/guides/choose-pdf-tool">Choose a PDF tool</a></li>
            <li><a href="/guides/tesseract-vs-online-ocr">Tesseract vs online OCR</a></li>
            <li><a href="/guides/compress-vs-split">Compress vs split</a> · <a href="/guides/merge-vs-compress">Merge vs compress</a></li>
            </ul>
            <p>Research: <a href="/research/pdf-tool-market-comparison">vendor matrix</a> · Hub: <a href="/guides/pdf-tool-alternatives">alternatives</a> · <a href="/compare">Compare page</a></p>
            """

W20_EDIT_CLUSTER = """
            <h2>Edit &amp; convert cluster</h2>
            <ul>
            <li><a href="/guides/edit-pdf">Edit PDF hub</a></li>
            <li><a href="/guides/edit-pdf-online-free">Edit PDF online free</a></li>
            <li><a href="/guides/add-signature-to-pdf">Add signature</a></li>
            <li><a href="/guides/edit-pdf-mistakes-compliance">Edit compliance mistakes</a></li>
            <li><a href="/guides/pdf-to-powerpoint">PDF to PowerPoint</a></li>
            <li><a href="/guides/sign-pdf-legally">Sign PDF legally</a></li>
            </ul>
            <p>Compare: <a href="/compare/sejda-alternative">Sejda alternative</a></p>
            """

W20_REGIONAL_CLUSTER = """
            <h2>Regional batch 3</h2>
            <ul>
            <li><a href="/guides/visa-application-pdf-workflow-italy">Visa Italy</a></li>
            <li><a href="/guides/visa-application-pdf-workflow-mexico">Visa Mexico</a></li>
            <li><a href="/guides/visa-application-pdf-workflow-new-zealand">Visa New Zealand</a></li>
            <li><a href="/guides/visa-application-pdf-workflow-south-africa">Visa South Africa</a></li>
            <li><a href="/guides/visa-application-pdf-workflow-south-korea">Visa South Korea</a></li>
            <li><a href="/guides/bank-statement-pdf-workflow-italy">Bank Italy</a></li>
            </ul>
            <p>Batch 2: <a href="/guides/visa-application-pdf-workflow-germany">Germany</a> · <a href="/guides/visa-application-pdf-workflow-spain">Spain</a> · Hub: <a href="/guides/pdf-regional-workflows-hub">regional index</a></p>
            """
