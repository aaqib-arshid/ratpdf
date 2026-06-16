"""Wave 17 — Compare alternative guides (P0) + merge/batch/compliance upgrades."""

W17_SLUGS = [
    "adobe-acrobat-alternative",
    "foxit-alternative",
    "ilovepdf-alternative",
    "pdf-candy-alternative",
    "pdf24-alternative",
    "pdfelement-alternative",
    "sejda-alternative",
    "smallpdf-alternative",
    "sodapdf-alternative",
    "wondershare-alternative",
    "merge-pdf-accountants",
    "merge-pdf-court-filing",
    "merge-pdf-students",
    "batch-pdf-to-word",
    "email-attachment-size-limits-2026",
    "how-to-merge-pdf-files",
    "ocr-pdf-ediscovery",
]

W17_DATA = {
    "adobe-acrobat-alternative": {
        "title": "Best Adobe Acrobat Alternative — Free Browser PDF Tools (2026)",
        "tool": "/guides/pdf-tools",
        "label": "PDF tools hub",
        "pillar": "/guides/pdf-tool-alternatives",
        "pillar_label": "PDF tool alternatives hub",
        "compare": "/compare/adobe-acrobat-alternative",
        "example": "Finance team drops Acrobat Pro seats — merge, compress, and invoice in RatPDF browser tools",
    },
    "foxit-alternative": {
        "title": "Best Foxit Alternative — Online PDF Tools Without Desktop Install (2026)",
        "tool": "/guides/pdf-tools",
        "label": "PDF tools hub",
        "pillar": "/guides/pdf-tool-alternatives",
        "pillar_label": "PDF tool alternatives hub",
        "compare": "/compare/foxit-alternative",
        "example": "Remote contractor needs merge and redact without Foxit IT approval ticket",
    },
    "ilovepdf-alternative": {
        "title": "Best iLovePDF Alternative — Merge, Compress & Convert Online (2026)",
        "tool": "/pdf/merge",
        "label": "Merge PDF",
        "pillar": "/guides/pdf-tool-alternatives",
        "pillar_label": "PDF tool alternatives hub",
        "compare": "/compare/ilovepdf-alternative",
        "example": "Agency hits iLovePDF daily cap mid client deliverable — switches to RatPDF merge + compress",
    },
    "pdf-candy-alternative": {
        "title": "Best PDF Candy Alternative — Unified PDF Toolkit (2026)",
        "tool": "/guides/pdf-tools",
        "label": "PDF tools hub",
        "pillar": "/guides/pdf-tool-alternatives",
        "pillar_label": "PDF tool alternatives hub",
        "compare": "/compare/pdf-candy-alternative",
        "example": "User tired of PDF Candy's 40 separate tool pages — bookmarks one RatPDF hub",
    },
    "pdf24-alternative": {
        "title": "Best PDF24 Alternative — Browser PDF Tools With Clear Limits (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/pdf-tool-alternatives",
        "pillar_label": "PDF tool alternatives hub",
        "compare": "/compare/pdf24-alternative",
        "example": "German SMB wants large-file merge online without PDF24 Creator desktop install",
    },
    "pdfelement-alternative": {
        "title": "Best PDFelement Alternative — Edit & Convert Without Wondershare Install (2026)",
        "tool": "/pdf/pdftodoc",
        "label": "PDF to Word",
        "pillar": "/guides/pdf-tool-alternatives",
        "pillar_label": "PDF tool alternatives hub",
        "compare": "/compare/pdfelement-alternative",
        "example": "Freelancer edits contract PDF in browser — no PDFelement watermark on export",
    },
    "sejda-alternative": {
        "title": "Best Sejda Alternative — Page-Level PDF Edits Online (2026)",
        "tool": "/pdf/editpdf",
        "label": "Edit PDF",
        "pillar": "/guides/pdf-tool-alternatives",
        "pillar_label": "PDF tool alternatives hub",
        "compare": "/compare/sejda-alternative",
        "example": "Ops team splits and crops PDFs — Sejda hourly cap blocks batch — RatPDF queue workflow",
    },
    "smallpdf-alternative": {
        "title": "Best Smallpdf Alternative — More Free Tasks & Invoice PDFs (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/pdf-tool-alternatives",
        "pillar_label": "PDF tool alternatives hub",
        "compare": "/compare/smallpdf-alternative",
        "example": "Recruiter exceeds Smallpdf 2/day limit — compresses resume pack on RatPDF free tier",
    },
    "sodapdf-alternative": {
        "title": "Best Soda PDF Alternative — Web PDF Tools Without Desktop Upsell (2026)",
        "tool": "/pdf/merge",
        "label": "Merge PDF",
        "pillar": "/guides/pdf-tool-alternatives",
        "pillar_label": "PDF tool alternatives hub",
        "compare": "/compare/sodapdf-alternative",
        "example": "Marketing merges campaign PDFs — avoids Soda PDF subscription watermark on export",
    },
    "wondershare-alternative": {
        "title": "Best Wondershare PDF Alternative — Browser Tools vs PDFelement Suite (2026)",
        "tool": "/guides/pdf-tools",
        "label": "PDF tools hub",
        "pillar": "/guides/pdf-tool-alternatives",
        "pillar_label": "PDF tool alternatives hub",
        "compare": "/compare/wondershare-alternative",
        "example": "Startup consolidates Wondershare PDFelement + invoice tool into RatPDF single vendor",
    },
    "merge-pdf-accountants": {
        "title": "Merge PDF for Accountants — Board Packs, Workpapers & Client Deliverables (2026)",
        "tool": "/pdf/merge",
        "label": "Merge PDF",
        "pillar": "/guides/merge-pdf",
        "pillar_label": "merge PDF guide",
        "compare": "/compare/smallpdf-alternative",
        "example": "CA firm combines P&amp;L, balance sheet, and audit notes into one board email attachment",
    },
    "merge-pdf-court-filing": {
        "title": "Merge PDF for Court Filing — Exhibits, Bookmarks & E-Filing Limits (2026)",
        "tool": "/pdf/merge",
        "label": "Merge PDF",
        "pillar": "/guides/merge-pdf",
        "pillar_label": "merge PDF guide",
        "compare": "/compare/adobe-acrobat-alternative",
        "example": "Paralegal merges motion + declaration + Exhibit A–F for CM/ECF upload under 35 MB cap",
    },
    "merge-pdf-students": {
        "title": "Merge PDF for Students — Readings, Assignments & LMS Submissions (2026)",
        "tool": "/pdf/merge",
        "label": "Merge PDF",
        "pillar": "/guides/merge-pdf",
        "pillar_label": "merge PDF guide",
        "compare": "/compare/ilovepdf-alternative",
        "example": "Grad student bundles Week 1–12 lecture PDFs into one searchable study pack",
    },
    "batch-pdf-to-word": {
        "title": "Batch PDF to Word — Multi-File Conversion Queue Workflow (2026)",
        "tool": "/pdf/pdftodoc",
        "label": "PDF to Word",
        "pillar": "/guides/pdf-to-word",
        "pillar_label": "PDF to Word guide",
        "compare": "/compare/adobe-acrobat-alternative",
        "example": "AP clerk converts 40 vendor invoice PDFs to DOCX for month-end markup — one file per session queue",
    },
    "email-attachment-size-limits-2026": {
        "title": "Email Attachment Size Limits 2026 — Gmail, Outlook &amp; Gateway Caps",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/compress-pdf-for-email",
        "pillar_label": "compress PDF for email guide",
        "compare": "/research/pdf-compression-benchmark",
        "example": "Legal sends 28 MB discovery PDF — Outlook rejects — compress to 18 MB safety margin",
    },
    "how-to-merge-pdf-files": {
        "title": "How Do I Merge PDF Files? — Step-by-Step Browser Guide (2026)",
        "tool": "/pdf/merge",
        "label": "Merge PDF",
        "pillar": "/guides/merge-pdf",
        "pillar_label": "merge PDF guide",
        "compare": "/compare/ilovepdf-alternative",
        "example": "Homeowner combines insurance quotes + photos into one claim PDF for adjuster email",
    },
    "ocr-pdf-ediscovery": {
        "title": "OCR PDF for E-Discovery — Searchable Productions for Small Firms (2026)",
        "tool": "/pdf/ocrpdf",
        "label": "OCR PDF",
        "pillar": "/guides/ocr-pdf",
        "pillar_label": "OCR PDF guide",
        "compare": "/compare/adobe-acrobat-alternative",
        "example": "Boutique firm OCRs 800-page scanned production before Relativity keyword pass",
    },
}

W17_ALT_DEEP = {
    "adobe-acrobat-alternative": """
            <h2>Why teams leave Adobe Acrobat</h2>
            <p>Acrobat Pro costs per seat, requires Adobe ID, and pushes desktop installs through IT. Most daily tasks — merge board packs, compress for email, convert contracts to Word — do not need prepress JavaScript or certified signatures. RatPDF covers those in the browser with Ghostscript compression and pdf2docx conversion.</p>
            <h2>Adobe vs RatPDF — task matrix</h2>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>Task</th><th>Acrobat Online</th><th>RatPDF</th></tr></thead>
            <tbody>
            <tr><td>Merge 12 PDFs</td><td>1–2 free tasks, account required</td><td><a href="/pdf/merge">Merge PDF</a> — 3/day free</td></tr>
            <tr><td>Compress for Gmail</td><td>Limited free compression</td><td><a href="/guides/compress-pdf-for-gmail">Gmail compress guide</a></td></tr>
            <tr><td>PDF to Word redline</td><td>Convert on paid tiers</td><td><a href="/pdf/pdftodoc">PDF to Word</a> + <a href="/guides/pdf-to-word">workflow guide</a></td></tr>
            <tr><td>Invoice PDF</td><td>Not included</td><td><a href="/invoice/create">Create Invoice</a></td></tr>
            <tr><td>CMYK print proof</td><td>Acrobat wins</td><td>Use print shop liaison seat</td></tr>
            </tbody></table></div>
            <h2>Migration checklist from Acrobat</h2>
            <ol>
            <li>Export last 30 days Acrobat task log from team survey</li>
            <li>Map each task to RatPDF URL — bookmark shared wiki page</li>
            <li>Run parallel pilot on non-confidential samples for one week</li>
            <li>Keep one Acrobat seat for prepress and complex forms only</li>
            <li>Review renewal memo with <a href="/compare/adobe-acrobat-alternative">feature comparison table</a></li>
            </ol>
            <h2>Enterprise security questions</h2>
            <p>Legal asks about data residency — RatPDF processes on server with auto-delete after download. Classified or HIPAA PHI may need client DPA review — see <a href="/guides/pdf-tool-security-comparison">security comparison</a> and <a href="/home/security">security page</a>.</p>
            <h2>Troubleshooting switchers</h2>
            <p><strong>Form XFA fails in browser:</strong> flatten in Acrobat once, then merge in RatPDF. <strong>Digital certificate signature:</strong> RatPDF typed signatures differ from PKI — use qualified e-sign vendor for regulated deals. <strong>Batch OCR 500 pages:</strong> upgrade tier or split volumes.</p>
            """,
    "foxit-alternative": """
            <h2>Foxit vs browser-first PDF tools</h2>
            <p>Foxit targets enterprise desktop editors with compliance marketing. Online tools exist but the funnel pushes Foxit PDF Editor install. RatPDF is browser-only — no MSI deployment, ideal for contractors and BYOD laptops blocked from admin installs.</p>
            <h2>When Foxit still wins</h2>
            <p>Redaction audit trails, JavaScript form testing, and bulk Bates numbering on air-gapped machines — keep Foxit for litigation support lead. Everyone else merges, compresses, and signs typed approvals in RatPDF.</p>
            <h2>Contractor onboarding SOP</h2>
            <p>Send link to <a href="/guides/pdf-tools">PDF tools hub</a> — merge NDA + SOW + insurance cert — compress under 10 MB for client gateway — no Foxit license procurement.</p>
            <h2>Compare table</h2>
            <p>Full side-by-side: <a href="/compare/foxit-alternative">RatPDF vs Foxit</a> · Research: <a href="/research/pdf-tool-market-comparison">PDF tool market comparison</a>.</p>
            """,
    "ilovepdf-alternative": """
            <h2>iLovePDF limits that push users to alternatives</h2>
            <p>iLovePDF caps free tasks and upsells OCR, e-sign, and strong compression. Brand recognition is high — but agencies hitting merge limits during client crunch need predictable caps. RatPDF offers 3 uses per tool per day with transparent Pro upgrade.</p>
            <h2>Workflow parity map</h2>
            <ul>
            <li>iLovePDF Merge → <a href="/pdf/merge">RatPDF Merge</a> · <a href="/guides/merge-pdf-online">merge online guide</a></li>
            <li>iLovePDF Compress → <a href="/pdf/compress">Compress PDF</a> · <a href="/guides/compress-pdf-guide">compression guide</a></li>
            <li>iLovePDF PDF to Word → <a href="/pdf/pdftodoc">PDF to Word</a></li>
            <li>iLovePDF Organize → <a href="/guides/organize-pdf-pages">organize pages</a></li>
            </ul>
            <h2>Quality test before switching</h2>
            <p>Run your hardest sample — scanned table PDF, 80 MB board pack, password-protected exhibit — through both tools. Compare text selectability and file size. Document results in renewal memo linking <a href="/compare/ilovepdf-alternative">iLovePDF comparison</a>.</p>
            """,
    "pdf-candy-alternative": """
            <h2>PDF Candy's SEO fragmentation problem</h2>
            <p>PDF Candy publishes 40+ single-purpose landing pages — great for Google long-tail, confusing for users who forget which URL they used last week. RatPDF centralizes merge, compress, convert, sign, and invoice under one navigation and shared account limits.</p>
            <h2>Tool mapping</h2>
            <p>PDF Candy JPG to PDF → <a href="/pdf/convertimages">Images to PDF</a>. PDF Candy Split → <a href="/pdf/split">Split PDF</a>. PDF Candy Unlock → <a href="/pdf/unlockpdf">Unlock PDF</a>. One bookmark replaces a folder of Candy links.</p>
            <h2>Free tier comparison</h2>
            <p>Both cap daily tasks — verify current limits on live sites. RatPDF adds <a href="/invoice/create">invoice PDF</a> without a separate vendor — fewer security questionnaires for SMB finance.</p>
            <p>Compare: <a href="/compare/pdf-candy-alternative">PDF Candy vs RatPDF table</a>.</p>
            """,
    "pdf24-alternative": """
            <h2>PDF24 strengths and where RatPDF differs</h2>
            <p>PDF24 offers generous free limits and large file merges — strong in DACH market. UI feels dated; English content marketing is thinner. RatPDF targets global English workflows with schema-rich guides per task — compress for Gmail, merge for visa, OCR for Hindi scans.</p>
            <h2>Large file workflow</h2>
            <p>Both handle big merges — verify Pro tier on RatPDF for 4 GB uploads. Compress after merge for email: <a href="/guides/compress-before-merge-pdf">compress before or after merge</a>.</p>
            <h2>Offline vs online</h2>
            <p>PDF24 Creator desktop app wins offline classified rooms. RatPDF wins quick browser tasks on Chromebook and locked-down corporate laptops without install rights.</p>
            <p>Compare: <a href="/compare/pdf24-alternative">PDF24 alternative page</a>.</p>
            """,
    "pdfelement-alternative": """
            <h2>PDFelement watermark and subscription friction</h2>
            <p>Wondershare PDFelement pushes desktop install with free exports sometimes watermarked. Browser users want edit + convert without 200 MB installer. RatPDF Edit PDF handles text boxes, images, and stamps; PDF to Word covers redline workflows.</p>
            <h2>Edit workflow without PDFelement</h2>
            <ol>
            <li>Digital PDF needing clause edit → <a href="/pdf/pdftodoc">PDF to Word</a></li>
            <li>Quick stamp and date → <a href="/pdf/editpdf">Edit PDF</a></li>
            <li>Scanned form → <a href="/pdf/ocrpdf">OCR</a> then edit</li>
            <li>Return PDF → <a href="/pdf/doctopdf">Word to PDF</a></li>
            </ol>
            <h2>Form recognition gap</h2>
            <p>PDFelement Pro auto-detects form fields on scans — RatPDF expects existing AcroForm or flat PDF. For heavy form recognition, keep one PDFelement seat; daily merge/compress on RatPDF.</p>
            <p>Compare: <a href="/compare/pdfelement-alternative">PDFelement comparison</a>.</p>
            """,
    "sejda-alternative": """
            <h2>Sejda hourly limits vs daily caps</h2>
            <p>Sejda resets three tasks per hour — painful for paralegal splitting 20 exhibits before filing deadline. RatPDF uses per-tool daily limits — batch your queue once per morning instead of waiting hourly.</p>
            <h2>Page-level edits Sejda users expect</h2>
            <p>Sejda excels at crop, split by pages, and rotate — RatPDF covers <a href="/pdf/split">Split PDF</a>, <a href="/pdf/rotateorremove">Rotate PDF</a>, and <a href="/guides/extract-single-page-pdf">extract single page</a>. Merge exhibits after individual prep.</p>
            <h2>Watermark on free exports</h2>
            <p>Some Sejda free tasks watermark — verify before client send. RatPDF free tier within daily limits does not add vendor watermark on standard tools — confirm on current plans page.</p>
            <p>Compare: <a href="/compare/sejda-alternative">Sejda alternative</a>.</p>
            """,
    "smallpdf-alternative": """
            <h2>Smallpdf 2 tasks/day pain point</h2>
            <p>Smallpdf free tier allows 2 tasks per day across all tools combined — one merge + one compress and you are done until tomorrow. RatPDF allocates 3 uses per tool per day — merge and compress independently.</p>
            <h2>Strong compression upsell</h2>
            <p>Smallpdf gates aggressive compression behind Pro. RatPDF Ghostscript levels include Extreme for portal caps — see <a href="/guides/compress-pdf-to-100kb">compress to 100 KB guide</a> and <a href="/research/pdf-compression-benchmark">compression benchmark research</a>.</p>
            <h2>Trust badges vs guides depth</h2>
            <p>Smallpdf markets GDPR and ISO badges. RatPDF pairs tools with 600+ step-by-step guides — compress for Indeed, merge for visa, OCR Hindi — each an authority page linking back to tools.</p>
            <p>Compare: <a href="/compare/smallpdf-alternative">Smallpdf comparison table</a> · Hub: <a href="/guides/pdf-tool-alternatives">all alternatives</a>.</p>
            """,
    "sodapdf-alternative": """
            <h2>Soda PDF desktop funnel</h2>
            <p>Soda PDF advertises web + desktop bundle with OCR and e-sign on paid tiers. Free web exports may carry watermark. Users who only need merge + compress for email avoid subscription push with RatPDF browser tools.</p>
            <h2>PowerPoint and convert parity</h2>
            <p>Soda PDF to PowerPoint → <a href="/pdf/pdftoppt">PDF to PowerPoint</a>. Word round-trip → <a href="/guides/pdf-to-word">PDF to Word guide</a>.</p>
            <h2>Hybrid team strategy</h2>
            <p>Marketing keeps Soda for desktop OCR batch; operations uses RatPDF for daily merge/compress — document in IT asset register to avoid duplicate Pro subscriptions.</p>
            <p>Compare: <a href="/compare/sodapdf-alternative">Soda PDF alternative</a>.</p>
            """,
    "wondershare-alternative": """
            <h2>Wondershare product confusion</h2>
            <p>Wondershare sells PDFelement, UniConverter, and broader creative suite — PDF features buried in account dashboard. RatPDF is PDF-only — merge, compress, invoice, sign — one sitemap, one support surface.</p>
            <h2>Asia market vs global guides</h2>
            <p>Wondershare strong in APAC video tutorial ecosystem. RatPDF English guides cover India GST invoice PDF, UCAS compress, and US court merge — regional workflow depth Smallpdf/iLovePDF often lack.</p>
            <h2>Cost consolidation</h2>
            <p>Finance line items: PDFelement + separate invoice SaaS + compress tool — RatPDF bundles <a href="/invoice/create">Create Invoice</a> with PDF stack — single vendor review for SMB.</p>
            <p>Compare: <a href="/compare/wondershare-alternative">Wondershare comparison</a> · Also: <a href="/compare/pdfelement-alternative">PDFelement page</a>.</p>
            """,
}

W17_MERGE_DEEP = {
    "merge-pdf-accountants": """
            <h2>Board pack order checklist</h2>
            <ol>
            <li>Cover memo and agenda (01_cover.pdf)</li>
            <li>Executive summary / MD&amp;A (02_summary.pdf)</li>
            <li>P&amp;L, balance sheet, cash flow (03–05)</li>
            <li>Notes to accounts and auditor report (06–07)</li>
            <li>Appendices — contracts, KPI dashboards (08+)</li>
            </ol>
            <p>Numeric prefixes prevent wrong order in merge UI — verify page 1 is cover at 100% zoom.</p>
            <h2>Excel export hygiene</h2>
            <p>Set print areas before PDF export — wide sheets split across pages break board readability. Use landscape for 12-month P&amp;L. Embed fonts if sending to directors on Mac.</p>
            <h2>Post-merge compress and encrypt</h2>
            <p>Merged packs often exceed 25 MB — <a href="/guides/compress-pdf-for-email">compress for email</a> once, not per schedule. Confidential packs: <a href="/guides/password-protect-pdf">password protect</a> after QA — separate password channel from email body.</p>
            <h2>Common accountant mistakes</h2>
            <p><strong>Double compression:</strong> compress each Excel PDF then merge then compress again — blurs stamps. <strong>Wrong version:</strong> draft P&amp;L merged with final cover — hash filenames with date. <strong>Scanned signatures:</strong> merge before compress to preserve stamp clarity — use Less compression.</p>
            """,
    "merge-pdf-court-filing": """
            <h2>CM/ECF and state portal limits</h2>
            <p>Federal CM/ECF often caps near 35 MB per PDF — state courts vary 10–50 MB. Merge all exhibits into one filing PDF when rules allow — otherwise separate docket entries per exhibit set.</p>
            <h2>Exhibit preparation before merge</h2>
            <ol>
            <li>Rotate sideways scans upright</li>
            <li><a href="/guides/unlock-pdf">Unlock</a> password exhibits if you have passphrase</li>
            <li><a href="/guides/pdf-redaction">Redact</a> unrelated PII from composite exhibits</li>
            <li>OCR if court requires searchable filings — <a href="/guides/ocr-pdf">OCR guide</a></li>
            <li>Merge in index order — cover sheet first</li>
            </ol>
            <h2>Bookmarks and pagination</h2>
            <p>RatPDF merge preserves source page order — add <a href="/pdf/pagenumbers">page numbers</a> after merge if local rules require consecutive pagination across exhibits.</p>
            <h2>Rejection troubleshooting</h2>
            <p><strong>Oversized:</strong> one compress pass after merge. <strong>Corrupt PDF:</strong> re-export from Word, do not re-save broken file. <strong>Searchability fail:</strong> OCR scans before merge. <strong>Wrong PDF version:</strong> flatten forms first.</p>
            """,
    "merge-pdf-students": """
            <h2>LMS submission order</h2>
            <p>Canvas and Moodle often want one PDF per assignment — merge cover sheet + essay + bibliography + appendix figures. Check rubric: some professors ban merged appendices.</p>
            <h2>Weekly reading pack workflow</h2>
            <ol>
            <li>Download PDFs from library portal</li>
            <li>Rename <code>Week03_Article1.pdf</code> etc.</li>
            <li>Merge in syllabus order</li>
            <li>OCR scanned chapters for Ctrl+F during exam prep</li>
            <li>Compress if LMS rejects — <a href="/guides/compress-pdf-for-lms">LMS compress guide</a></li>
            </ol>
            <h2>Mobile merge tips</h2>
            <p>Safari on iPhone works — upload from Files app — Wi-Fi for packs over 15 MB. Save merged output back to Files before deadline — do not rely on browser tab memory.</p>
            <h2>Academic integrity</h2>
            <p>Merge your own submissions only — do not combine copyrighted coursepacks for redistribution. Personal study packs for offline reading are generally fair use for enrolled students — consult campus policy.</p>
            """,
    "how-to-merge-pdf-files": """
            <h2>Merge PDF files in 4 steps</h2>
            <ol>
            <li>Open <a href="/pdf/merge">Merge PDF</a> in Chrome, Edge, or Safari</li>
            <li>Upload two or more PDFs — drag to reorder if needed</li>
            <li>Click merge and wait for processing</li>
            <li>Download combined PDF — open locally and verify page 1 and total page count</li>
            </ol>
            <h2>Before you merge</h2>
            <p>Unlock password PDFs first. Rotate sideways scans. Decide cover page — first file in list becomes early pages unless reordered.</p>
            <h2>After merge</h2>
            <p>Email too large? <a href="/guides/compress-pdf-for-email">Compress for email</a>. Need one exhibit only? <a href="/guides/split-pdf">Split PDF</a> instead of re-merge.</p>
            <h2>Merge vs other tools</h2>
            <p><strong>Print to PDF from browser:</strong> loses bookmarks, may rasterize text. <strong>Word insert object:</strong> breaks vector quality. <strong>Dedicated merge:</strong> preserves digital text on vector PDFs — see <a href="/guides/merge-pdf-without-quality-loss">quality guide</a>.</p>
            """,
}

W17_BATCH_DEEP = """
            <h2>Why true batch zip export is rare online</h2>
            <p>Server-side batch PDF to Word requires queue infrastructure and virus scanning per file — most browser tools process one PDF per session. RatPDF batch workflow is operational: repeatable queue with naming convention, not one-click zip.</p>
            <h2>Queue SOP for 40-file AP month-end</h2>
            <ol>
            <li>Folder <code>2026-03-vendors/</code> with source PDFs only</li>
            <li>Sort alphabetically — process A→Z for audit trail</li>
            <li>Digital PDF → <a href="/pdf/pdftodoc">PDF to Word</a> — save as <code>VendorName_2026-03.docx</code></li>
            <li>Scanned invoice → <a href="/pdf/ocrpdf">OCR</a> first, then Word</li>
            <li>Log failures in spreadsheet — re-export from ERP instead of forcing bad scan</li>
            </ol>
            <h2>OCR-first rule</h2>
            <p>Batch converting scans without OCR yields image-only DOCX pages — useless for line edit. OCR adds 30–60 seconds per file — still faster than retyping.</p>
            <h2>When merge beats batch Word</h2>
            <p>Review-only pack — merge PDFs and annotate — skip Word entirely. Legal hold — keep PDF archive; Word is working copy only.</p>
            """

W17_EMAIL_DEEP = """
            <h2>2026 provider limits reference</h2>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>Provider</th><th>Published cap</th><th>Safe PDF target</th><th>Guide</th></tr></thead>
            <tbody>
            <tr><td>Gmail</td><td>25 MB</td><td>18–20 MB raw</td><td><a href="/guides/compress-pdf-for-gmail">Gmail guide</a></td></tr>
            <tr><td>Outlook / M365</td><td>20–34 MB</td><td>15–18 MB</td><td><a href="/guides/compress-pdf-for-outlook">Outlook guide</a></td></tr>
            <tr><td>Yahoo Mail</td><td>25 MB</td><td>18–20 MB</td><td><a href="/guides/compress-pdf-for-yahoo-mail">Yahoo guide</a></td></tr>
            <tr><td>Proton Mail</td><td>25 MB</td><td>18–20 MB</td><td><a href="/guides/compress-pdf-for-protonmail">Proton guide</a></td></tr>
            <tr><td>Corporate Exchange</td><td>Often 10–20 MB</td><td>10–12 MB</td><td><a href="/guides/compress-pdf-for-email">email compress hub</a></td></tr>
            </tbody></table></div>
            <h2>Base64 overhead math</h2>
            <p>Email encodes attachments ~33% larger than raw file size. A 20 MB PDF can present as 26 MB on the wire — aim lower than published cap.</p>
            <h2>Compress vs split vs cloud link</h2>
            <p><strong>Compress first</strong> when text must stay in body. <strong>Split</strong> when legal fine print would blur at Extreme compression. <strong>Drive/OneDrive link</strong> when recipient accepts link — not for courts or banks requiring attachment.</p>
            <h2>Gateway bounce troubleshooting</h2>
            <p>NDR "message size exceeds maximum" without size — recipient gateway stricter than sender — target 10 MB for law firms and banks.</p>
            """

W17_OCR_EDISCOVERY_DEEP = """
            <h2>E-discovery OCR scope for boutique firms</h2>
            <p>Enterprise Relativity and Nuix handle OCR at ingest — firms under 5,000 pages often manual-export from client, OCR in RatPDF, re-import searchable PDFs. Not replacement for chain-of-custody tooling — supplement for searchable productions.</p>
            <h2>Production workflow</h2>
            <ol>
            <li>Receive native + scan mix on encrypted drive</li>
            <li>Separate image-only PDFs — OCR each volume</li>
            <li>Verify search hits on known custodian name</li>
            <li>Merge volumes if review platform expects one load file</li>
            <li>Log OCR date and settings for privilege log metadata</li>
            </ol>
            <h2>Quality controls</h2>
            <p>Spot-check 10 random pages post-OCR — currency amounts and dates — OCR confuses 8/B and 1/l. Non-English docs need language-appropriate OCR — see <a href="/guides/ocr-pdf-hindi">Hindi OCR guide</a>.</p>
            <h2>When not to OCR in browser</h2>
            <p>Million-page tobacco litigation — use vendor. Privileged material — air-gapped desktop OCR under counsel supervision.</p>
            """

W17_ALT_CLUSTER = """
            <h2>Compare all PDF tool alternatives</h2>
            <ul>
            <li><a href="/guides/adobe-acrobat-alternative">Adobe Acrobat alternative</a></li>
            <li><a href="/guides/smallpdf-alternative">Smallpdf alternative</a></li>
            <li><a href="/guides/ilovepdf-alternative">iLovePDF alternative</a></li>
            <li><a href="/guides/pdf24-alternative">PDF24 alternative</a></li>
            <li><a href="/guides/sejda-alternative">Sejda alternative</a></li>
            <li><a href="/guides/foxit-alternative">Foxit alternative</a></li>
            <li><a href="/guides/pdf-tool-alternatives">Full alternatives hub</a></li>
            </ul>
            <p>Feature tables: <a href="/compare">Compare hub</a> · Research: <a href="/research/pdf-tool-market-comparison">market comparison</a></p>
            """

W17_MERGE_CLUSTER = """
            <h2>Related merge guides</h2>
            <ul>
            <li><a href="/guides/merge-pdf">Merge PDF pillar</a></li>
            <li><a href="/guides/merge-pdf-accountants">Accountants</a></li>
            <li><a href="/guides/merge-pdf-court-filing">Court filing</a></li>
            <li><a href="/guides/merge-pdf-students">Students</a></li>
            <li><a href="/guides/how-to-merge-pdf-files">How to merge PDF files</a></li>
            </ul>
            """

W17_DEEP = {}
for slug in W17_SLUGS[:10]:
    W17_DEEP[slug] = W17_ALT_DEEP[slug]
W17_DEEP["merge-pdf-accountants"] = W17_MERGE_DEEP["merge-pdf-accountants"]
W17_DEEP["merge-pdf-court-filing"] = W17_MERGE_DEEP["merge-pdf-court-filing"]
W17_DEEP["merge-pdf-students"] = W17_MERGE_DEEP["merge-pdf-students"]
W17_DEEP["how-to-merge-pdf-files"] = W17_MERGE_DEEP["how-to-merge-pdf-files"]
W17_DEEP["batch-pdf-to-word"] = W17_BATCH_DEEP
W17_DEEP["email-attachment-size-limits-2026"] = W17_EMAIL_DEEP
W17_DEEP["ocr-pdf-ediscovery"] = W17_OCR_EDISCOVERY_DEEP
