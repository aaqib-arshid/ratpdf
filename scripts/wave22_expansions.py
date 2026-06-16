"""Wave 22 — Industry PDF tools + research guides + glossary batch 4."""

W22_SLUGS = [
    "pdf-tools-construction",
    "pdf-tools-healthcare-admin",
    "pdf-tools-insurance",
    "pdf-tools-for-lawyers",
    "pdf-tools-marketing-agencies",
    "pdf-tools-nonprofits",
    "pdf-tools-real-estate",
    "pdf-tools-recruiters",
    "pdf-tools-for-students",
    "pdf-tools-teachers",
    "pdf-compression-benchmark",
    "gmail-vs-outlook-pdf-limits",
    "freelancer-invoicing-statistics",
    "university-pdf-upload-requirements",
    "glossary-attachments",
    "glossary-batch-processing",
    "glossary-bleed-box",
]

INDUSTRY_SLUGS = {
    "pdf-tools-construction",
    "pdf-tools-healthcare-admin",
    "pdf-tools-insurance",
    "pdf-tools-for-lawyers",
    "pdf-tools-marketing-agencies",
    "pdf-tools-nonprofits",
    "pdf-tools-real-estate",
    "pdf-tools-recruiters",
    "pdf-tools-for-students",
    "pdf-tools-teachers",
}

RESEARCH_SLUGS = {
    "pdf-compression-benchmark",
    "gmail-vs-outlook-pdf-limits",
    "freelancer-invoicing-statistics",
    "university-pdf-upload-requirements",
}

GLOSSARY_SLUGS = {
    "glossary-attachments",
    "glossary-batch-processing",
    "glossary-bleed-box",
}

W22_DATA = {
    "pdf-tools-construction": {
        "title": "PDF Tools for Construction — Permits, RFQs &amp; Site Logs (2026)",
        "tool": "/guides/pdf-tools",
        "label": "PDF tools hub",
        "pillar": "/guides/compress-pdf-construction",
        "pillar_label": "compress PDF for construction",
        "related": "/guides/merge-pdf",
        "example": "GC merges permit submittal PDFs, compresses for city portal, bundles site photo log for owner weekly report",
    },
    "pdf-tools-healthcare-admin": {
        "title": "PDF Tools for Healthcare Administrators — Portals &amp; Prior Auth (2026)",
        "tool": "/guides/pdf-tools",
        "label": "PDF tools hub",
        "pillar": "/guides/compress-pdf-healthcare-admin",
        "pillar_label": "compress PDF for healthcare admin",
        "related": "/guides/pdf-security-compliance-guide",
        "example": "Admin merges prior-auth scans, compresses for payer portal, OCRs for internal search",
    },
    "pdf-tools-insurance": {
        "title": "PDF Tools for Insurance — Claims, Estimates &amp; Policy Docs (2026)",
        "tool": "/guides/pdf-tools",
        "label": "PDF tools hub",
        "pillar": "/guides/compress-pdf-insurance-claims",
        "pillar_label": "compress PDF for insurance claims",
        "related": "/guides/merge-pdf",
        "example": "Adjuster merges photos, repair estimate, and police report into one claim PDF under portal cap",
    },
    "pdf-tools-for-lawyers": {
        "title": "PDF Tools for Lawyers — Merge, Redact, Convert &amp; E-File (2026)",
        "tool": "/guides/pdf-tools",
        "label": "PDF tools hub",
        "pillar": "/guides/merge-pdf-court-filing",
        "pillar_label": "merge PDF for court filing",
        "related": "/guides/pdf-redaction-permanent",
        "example": "Paralegal merges exhibits, OCRs scans, redacts PII, compresses for CM/ECF under 35 MB",
    },
    "pdf-tools-marketing-agencies": {
        "title": "PDF Tools for Marketing Agencies — Decks, Case Studies &amp; Delivery (2026)",
        "tool": "/guides/pdf-tools",
        "label": "PDF tools hub",
        "pillar": "/guides/compress-pdf-marketing-agencies",
        "pillar_label": "compress PDF for marketing agencies",
        "related": "/guides/powerpoint-to-pdf",
        "example": "Agency exports pitch deck to PDF, compresses for client inbox, extracts brand assets from old case study",
    },
    "pdf-tools-nonprofits": {
        "title": "PDF Tools for Nonprofits — Grants, Board Packs &amp; Donor Reports (2026)",
        "tool": "/guides/pdf-tools",
        "label": "PDF tools hub",
        "pillar": "/guides/compress-pdf-nonprofits",
        "pillar_label": "compress PDF for nonprofits",
        "related": "/guides/merge-pdf",
        "example": "Grant writer merges budget, 990 excerpt, and program narrative for funder portal upload",
    },
    "pdf-tools-real-estate": {
        "title": "PDF Tools for Real Estate — Listings, Disclosures &amp; Leases (2026)",
        "tool": "/guides/pdf-tools",
        "label": "PDF tools hub",
        "pillar": "/guides/compress-pdf-real-estate",
        "pillar_label": "compress PDF for real estate",
        "related": "/guides/merge-pdf",
        "example": "Agent merges disclosure pack and compresses photo-heavy listing brochure for buyer email",
    },
    "pdf-tools-recruiters": {
        "title": "PDF Tools for Recruiters — Résumé Packs &amp; ATS Uploads (2026)",
        "tool": "/guides/pdf-tools",
        "label": "PDF tools hub",
        "pillar": "/guides/compress-pdf-recruiters",
        "pillar_label": "compress PDF for recruiters",
        "related": "/guides/compress-pdf-for-linkedin",
        "example": "Recruiter compresses candidate CV and certificates into one client submittal under 5 MB",
    },
    "pdf-tools-for-students": {
        "title": "PDF Tools for Students — Readings, OCR &amp; Citations (2026)",
        "tool": "/guides/pdf-tools",
        "label": "PDF tools hub",
        "pillar": "/guides/merge-pdf-students",
        "pillar_label": "merge PDF for students",
        "related": "/guides/compress-pdf-for-lms",
        "example": "Undergrad merges weekly readings, OCRs scanned article, compresses for Canvas upload",
    },
    "pdf-tools-teachers": {
        "title": "PDF Tools for Teachers — Handouts, LMS &amp; Parent Email (2026)",
        "tool": "/guides/pdf-tools",
        "label": "PDF tools hub",
        "pillar": "/guides/compress-pdf-teachers",
        "pillar_label": "compress PDF for teachers",
        "related": "/guides/compress-pdf-for-lms",
        "example": "Teacher merges semester worksheet scans, compresses for Google Classroom parent newsletter",
    },
    "pdf-compression-benchmark": {
        "title": "PDF Compression Benchmark — Ghostscript Levels &amp; Quality Tests (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/compress-pdf-guide",
        "pillar_label": "compress PDF guide",
        "related": "/research/pdf-compression-benchmark",
        "example": "Ops team tests Less vs Recommended vs Extreme on 80 MB board pack before rolling out compress SOP",
    },
    "gmail-vs-outlook-pdf-limits": {
        "title": "Gmail vs Outlook PDF Attachment Limits — Provider Comparison (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/email-attachment-size-limits-2026",
        "pillar_label": "email attachment limits 2026",
        "related": "/research/attachment-size-limits",
        "example": "Sales sends 22 MB proposal — Gmail accepts but recipient Exchange gateway blocks at 20 MB effective",
    },
    "freelancer-invoicing-statistics": {
        "title": "Freelancer Invoicing Statistics — PDF Invoices &amp; Payment Trends (2026)",
        "tool": "/invoice/create",
        "label": "Create Invoice",
        "pillar": "/guides/invoice-for-freelancers",
        "pillar_label": "invoice for freelancers",
        "related": "/research/freelancer-invoicing-statistics",
        "example": "Solo consultant cites industry data in pricing page — ships PDF invoices same day via RatPDF generator",
    },
    "university-pdf-upload-requirements": {
        "title": "University PDF Upload Requirements — Portals, Portfolios &amp; Transcripts (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/compress-pdf-for-university-application",
        "pillar_label": "compress PDF for university application",
        "related": "/guides/compress-pdf-common-app",
        "example": "Applicant compresses portfolio PDF and transcript scan for Common App and UCAS slots",
    },
    "glossary-attachments": {
        "title": "What Are PDF Attachments? — Embedded Files &amp; Portfolios (2026)",
        "tool": "/pdf/merge",
        "label": "Merge PDF",
        "pillar": "/guides/beginner-pdf-file-structure",
        "pillar_label": "PDF file structure basics",
        "related": "/guides/glossary-embedded-files",
        "example": "Engineering PDF embeds Excel BOM — recipient extracts attachment without separate email",
    },
    "glossary-batch-processing": {
        "title": "What Is PDF Batch Processing? — Queues, Scripts &amp; Browser Limits (2026)",
        "tool": "/guides/batch-compress-pdf",
        "label": "batch compress guide",
        "pillar": "/guides/pdf-tools",
        "pillar_label": "PDF tools hub",
        "related": "/guides/batch-pdf-to-word",
        "example": "AP team queues forty invoice PDFs — one compress session per file — naming convention 01_inv_042",
    },
    "glossary-bleed-box": {
        "title": "What Is the PDF Bleed Box? — Print Trim &amp; Prepress (2026)",
        "tool": "/guides/pdf-x-print-standard",
        "label": "PDF/X print standard",
        "pillar": "/guides/glossary-crop-box",
        "pillar_label": "crop box glossary",
        "related": "/guides/glossary-overprint",
        "example": "Brochure background extends past trim — bleed box defines ink area beyond cut line",
    },
}

W22_INDUSTRY_DEEP = {
    "pdf-tools-construction": """
            <h2>Construction PDF task map</h2>
            <ul>
            <li><strong>Permit submittals:</strong> <a href="/pdf/merge">Merge PDF</a> sheets in order — <a href="/guides/compress-pdf-construction">compress for city portal</a></li>
            <li><strong>RFQ / bid packages:</strong> merge specs + addenda — watermark DRAFT until award</li>
            <li><strong>Site photo logs:</strong> <a href="/pdf/convertimages">Images to PDF</a> daily — compress weekly owner report</li>
            <li><strong>Subcontractor COIs:</strong> merge insurance certs — verify expiration dates at zoom</li>
            </ul>
            <h2>Quality on drawings</h2>
            <p>Use Less compression on stamped plan sets — verify scale bar and sheet number after compress. Split if municipal portal rejects merged file size.</p>
            <h2>Rollout</h2>
            <p>Field tablets bookmark merge + compress — PM office keeps Acrobat only for CAD export QA if needed.</p>
            """,
    "pdf-tools-healthcare-admin": """
            <h2>Healthcare admin PDF stack</h2>
            <ul>
            <li><strong>Prior auth:</strong> merge clinical notes + imaging reports — <a href="/guides/compress-pdf-healthcare-admin">compress for payer portal</a></li>
            <li><strong>Credentialing:</strong> merge license, DEA, malpractice PDFs — numeric filenames</li>
            <li><strong>Search:</strong> <a href="/pdf/ocrpdf">OCR PDF</a> on incoming faxes for internal lookup</li>
            <li><strong>Compliance:</strong> follow org BAA — see <a href="/guides/pdf-security-compliance-guide">security compliance guide</a></li>
            </ul>
            <h2>PHI caution</h2>
            <p>RatPDF is not a HIPAA-certified EHR — use only per policy on de-identified or approved workflows — never public Wi-Fi on member-specific PDFs.</p>
            """,
    "pdf-tools-insurance": """
            <h2>Insurance PDF workflows</h2>
            <ul>
            <li><strong>First notice of loss:</strong> <a href="/pdf/convertimages">Images to PDF</a> damage photos — geotag in filename</li>
            <li><strong>Claim bundle:</strong> <a href="/pdf/merge">Merge PDF</a> estimate + police report + policy dec page</li>
            <li><strong>Portal upload:</strong> <a href="/guides/compress-pdf-insurance-claims">compress insurance claims</a></li>
            <li><strong>Policy delivery:</strong> compress email copy — archive uncompressed master</li>
            </ul>
            <h2>Readability</h2>
            <p>VIN, policy number, and claimant name must survive compression — verify at 100% zoom before submit.</p>
            """,
    "pdf-tools-for-lawyers": """
            <h2>Legal PDF toolkit</h2>
            <ul>
            <li><strong>Exhibits:</strong> <a href="/guides/merge-pdf-court-filing">merge for court filing</a></li>
            <li><strong>Redaction:</strong> <a href="/guides/pdf-redaction-permanent">permanent redaction</a> — not black boxes</li>
            <li><strong>Redlines:</strong> <a href="/pdf/pdftodoc">PDF to Word</a> + track changes</li>
            <li><strong>Discovery:</strong> <a href="/guides/ocr-pdf-ediscovery">OCR for e-discovery</a></li>
            <li><strong>E-file size:</strong> compress after merge — CM/ECF caps near 35 MB</li>
            </ul>
            <h2>When to keep Acrobat</h2>
            <p>Bates numbering audit trail, XFA forms, air-gapped review — one litigation support seat — daily merge/compress on RatPDF.</p>
            """,
    "pdf-tools-marketing-agencies": """
            <h2>Agency PDF delivery</h2>
            <ul>
            <li><strong>Pitch decks:</strong> <a href="/pdf/ppttopdf">PowerPoint to PDF</a> — <a href="/guides/compress-pdf-marketing-agencies">compress for client email</a></li>
            <li><strong>Case studies:</strong> extract hero images — <a href="/pdf/extractimages">Extract Images</a></li>
            <li><strong>Campaign reports:</strong> merge analytics PDFs — compress before Friday client send</li>
            <li><strong>Brand PDFs:</strong> verify full-bleed mockups at Recommended before Extreme</li>
            </ul>
            <p>Compare limits: <a href="/guides/smallpdf-alternative">Smallpdf alternative</a> when daily cap hits pitch crunch.</p>
            """,
    "pdf-tools-nonprofits": """
            <h2>Nonprofit PDF workflows</h2>
            <ul>
            <li><strong>Grant applications:</strong> merge narrative + budget + 990 excerpt — <a href="/guides/compress-pdf-nonprofits">compress for funder portal</a></li>
            <li><strong>Board packs:</strong> merge committee reports — compress before board email blast</li>
            <li><strong>Donor reports:</strong> <a href="/pdf/compress">Compress PDF</a> impact PDF with photos</li>
            <li><strong>Invoices:</strong> <a href="/invoice/create">Create Invoice</a> for program fees</li>
            </ul>
            <h2>Funder order</h2>
            <p>Follow RFP exhibit index exactly — wrong merge order causes automatic rejection on some portals.</p>
            """,
    "pdf-tools-real-estate": """
            <h2>Real estate PDF stack</h2>
            <ul>
            <li><strong>Listing brochures:</strong> photo-heavy — <a href="/guides/compress-pdf-real-estate">compress real estate PDF</a></li>
            <li><strong>Disclosure packs:</strong> <a href="/pdf/merge">Merge PDF</a> lead paint, HOA, inspection in state order</li>
            <li><strong>Lease PDFs:</strong> watermark DRAFT during negotiation — flatten after sign</li>
            <li><strong>E-sign handoff:</strong> export signed PDF from DocuSign — compress email copy only</li>
            </ul>
            """,
    "pdf-tools-recruiters": """
            <h2>Recruiter PDF workflows</h2>
            <ul>
            <li><strong>Submittals:</strong> merge CV + cover + certs — <a href="/guides/compress-pdf-recruiters">compress recruiter pack</a></li>
            <li><strong>LinkedIn / Indeed:</strong> <a href="/guides/compress-pdf-for-linkedin">LinkedIn compress</a> · <a href="/guides/compress-pdf-for-indeed">Indeed compress</a></li>
            <li><strong>ATS text layer:</strong> digital CV PDF — OCR scans before client send</li>
            <li><strong>Redact:</strong> remove prior employer contact info on shared submittals</li>
            </ul>
            """,
    "pdf-tools-for-students": """
            <h2>Student PDF toolkit</h2>
            <ul>
            <li><strong>Readings:</strong> <a href="/guides/merge-pdf-students">merge lecture PDFs</a> — numeric week prefix</li>
            <li><strong>LMS submit:</strong> <a href="/guides/compress-pdf-for-lms">compress for LMS</a></li>
            <li><strong>Scanned articles:</strong> <a href="/pdf/ocrpdf">OCR PDF</a> for search and cite</li>
            <li><strong>Essays:</strong> <a href="/pdf/pdftodoc">PDF to Word</a> or <a href="/pdf/pdftomarkdown">PDF to Markdown</a> for notes</li>
            </ul>
            <h2>Citation hygiene</h2>
            <p>OCR before quoting — garbled page numbers break academic integrity checks — verify against original scan.</p>
            """,
    "pdf-tools-teachers": """
            <h2>Teacher PDF workflows</h2>
            <ul>
            <li><strong>Handouts:</strong> merge weekly worksheets — <a href="/guides/compress-pdf-teachers">compress for LMS</a></li>
            <li><strong>Parent email:</strong> compress newsletter PDF — school Gmail caps</li>
            <li><strong>Scan hygiene:</strong> 200–250 DPI grayscale for worksheets — not 600 DPI colour phone photos</li>
            <li><strong>Substitute packs:</strong> merge lesson plan + attachments one PDF for sub folder</li>
            </ul>
            """,
}

W22_RESEARCH_DEEP = {
    "pdf-compression-benchmark": """
            <h2>Benchmark methodology</h2>
            <p>Test each compression level on representative files: typed memo, 300 DPI scan, photo-heavy marketing PDF, and merged board pack. Record file size, visual QA at 100% zoom, and text selectability after OCR path.</p>
            <h2>Ghostscript presets (RatPDF)</h2>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>Level</th><th>Typical size reduction</th><th>Best for</th></tr></thead>
            <tbody>
            <tr><td>Less</td><td>10–30%</td><td>Signed scans, legal exhibits, stamps</td></tr>
            <tr><td>Recommended</td><td>30–60%</td><td>Email, LMS, most portals</td></tr>
            <tr><td>Extreme</td><td>60–85%</td><td>Last resort portal reject — verify footnotes</td></tr>
            </tbody></table></div>
            <p>Full data tables: <a href="/research/pdf-compression-benchmark">research benchmark page</a> · Workflow: <a href="/guides/compress-pdf-guide">compress guide</a>.</p>
            <h2>Anti-patterns</h2>
            <p>Compress then OCR on scans — wrong order. Double compress after merge — blurs twice. Extreme on text-only PDF rarely needed — Recommended usually enough.</p>
            """,
    "gmail-vs-outlook-pdf-limits": """
            <h2>Provider caps vs effective caps</h2>
            <p>Gmail advertises 25 MB per message — Outlook desktop similar — but corporate Exchange transport rules often enforce 10–20 MB effective. Always target 18 MB raw PDF on external sends for safety margin.</p>
            <h2>Comparison table</h2>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>Provider</th><th>Stated cap</th><th>Practical target</th></tr></thead>
            <tbody>
            <tr><td>Gmail</td><td>25 MB</td><td>18–20 MB PDF</td></tr>
            <tr><td>Outlook / M365</td><td>20–25 MB varies</td><td>15–18 MB if Exchange gateway unknown</td></tr>
            <tr><td>Yahoo / AOL</td><td>25 MB</td><td>18–20 MB</td></tr>
            <tr><td>Proton Mail</td><td>25 MB</td><td>18–20 MB encrypted attach</td></tr>
            </tbody></table></div>
            <p>Base64 overhead adds ~33% on wire — <a href="/guides/email-attachment-size-limits-2026">full 2026 limits guide</a> · Research: <a href="/research/attachment-size-limits">attachment size limits research</a>.</p>
            <h2>Fix workflow</h2>
            <ol>
            <li>Check size with <a href="/pdf-size-checker">PDF size checker</a></li>
            <li><a href="/pdf/compress">Compress PDF</a> Recommended</li>
            <li>If still over — <a href="/guides/compress-vs-split">split vs compress decision</a></li>
            <li>Cloud link fallback when quality cannot drop</li>
            </ol>
            """,
    "freelancer-invoicing-statistics": """
            <h2>Why PDF invoices still dominate</h2>
            <p>Freelancers and micro-agencies overwhelmingly deliver PDF invoices — universal view on mobile, harder to tamper than raw Word, and archive-friendly for tax season. Late payment and format friction remain top ops complaints in industry surveys.</p>
            <h2>Operational stats teams cite</h2>
            <ul>
            <li>Majority of SMB freelancers send PDF not paper — email primary channel</li>
            <li>Payment terms Net 15 / Net 30 most common on solo consultant invoices</li>
            <li>Multi-currency PDF rising with remote client base — USD/EUR/GBP on same tool</li>
            <li>Chasing payment costs more admin time than invoice creation — automate PDF generation</li>
            </ul>
            <p>Deep dive data: <a href="/research/freelancer-invoicing-statistics">freelancer invoicing statistics research</a>.</p>
            <h2>RatPDF workflow</h2>
            <ol>
            <li><a href="/invoice/create">Create Invoice</a> — line items, tax, currency</li>
            <li>Download PDF — compress if client mailbox tight</li>
            <li>Store copy with date prefix — <code>ClientName_Invoice_2026-03.pdf</code></li>
            </ol>
            <p>Guide: <a href="/guides/invoice-for-freelancers">invoice for freelancers</a> · Compare: <a href="/guides/pdf-tools-small-business">SMB PDF stack</a>.</p>
            """,
    "university-pdf-upload-requirements": """
            <h2>Common portal constraints</h2>
            <p>University admission systems cap per-file size and file count — Common App, UCAS, and direct uni portals differ. Portfolio PDFs for art and architecture programs often hit limits first — compress after export from InDesign or Behance print-to-PDF.</p>
            <h2>Document checklist</h2>
            <ul>
            <li>Transcript PDF — official seal readable — <a href="/guides/compress-pdf-for-university-application">university compress guide</a></li>
            <li>Recommendation letters — one PDF per recommender slot unless portal merges</li>
            <li>Portfolio — RGB screen DPI — Extreme only if portal still rejects</li>
            <li>ID scan — Less compression on passport bio page</li>
            </ul>
            <h2>Regional links</h2>
            <p>US: <a href="/guides/compress-pdf-common-app">Common App compress</a> · UK: <a href="/guides/compress-pdf-ucas">UCAS compress</a> · General: <a href="/guides/merge-pdf-students">student merge guide</a>.</p>
            <h2>Troubleshooting</h2>
            <p><strong>Upload spinner forever:</strong> file over cap — compress. <strong>Wrong doc in slot:</strong> portals rarely allow delete — contact admissions before re-upload. <strong>Scanned transcript blur:</strong> re-scan at 300 DPI grayscale.</p>
            """,
}

W22_GLOSSARY_DEEP = {
    "glossary-attachments": """
            <h2>Definition</h2>
            <p><strong>PDF attachments</strong> are files embedded inside a PDF container — spreadsheets, source images, XML — opened via attachment panel in Acrobat — distinct from page content streams.</p>
            <h2>vs portfolio PDF</h2>
            <p>PDF portfolios bundle multiple files with navigation UI — attachments are simpler embedded blobs — merge workflow often replaces need for portfolio on email sends.</p>
            <h2>Workflow</h2>
            <p>When recipient needs editable source — attach XLSX before flatten — after flatten attachments may strip — keep master with attachments for internal archive.</p>
            <p>Related: <a href="/guides/glossary-embedded-files">embedded files glossary</a> · <a href="/guides/beginner-pdf-file-structure">PDF structure basics</a>.</p>
            """,
    "glossary-batch-processing": """
            <h2>Definition</h2>
            <p><strong>Batch processing</strong> runs the same PDF operation on many files — compress folder, OCR queue, convert all invoices — desktop tools automate with folders; browser tools use repeatable session workflow.</p>
            <h2>RatPDF batch pattern</h2>
            <ol>
            <li>Numeric prefix filenames — <code>01_</code> through <code>40_</code></li>
            <li>One tool session per file on free tier — spreadsheet tick-off column</li>
            <li>Merge related outputs when recipient needs single bundle</li>
            </ol>
            <p>Guides: <a href="/guides/batch-compress-pdf">batch compress</a> · <a href="/guides/batch-pdf-to-word">batch PDF to Word</a>.</p>
            """,
    "glossary-bleed-box": """
            <h2>Definition</h2>
            <p>The <strong>bleed box</strong> defines the region including bleed area beyond trim — background colour and images extend to bleed edge — printer trims to crop box — prevents white sliver on full-bleed brochures.</p>
            <h2>Related boxes</h2>
            <ul>
            <li><strong>Media box:</strong> full page dimensions</li>
            <li><strong>Crop box:</strong> visible region in viewer</li>
            <li><strong>Trim box:</strong> final cut size</li>
            <li><strong>Bleed box:</strong> includes extra ink beyond trim — typically 3 mm</li>
            </ul>
            <p>Print hub: <a href="/guides/pdf-x-print-standard">PDF/X standard</a> · <a href="/guides/glossary-overprint">overprint glossary</a> · <a href="/guides/commercial-print-pdf-checklist">commercial print checklist</a>.</p>
            """,
}

W22_DEEP = {**W22_INDUSTRY_DEEP, **W22_RESEARCH_DEEP, **W22_GLOSSARY_DEEP}

W22_INDUSTRY_CLUSTER = """
            <h2>Industry PDF tools cluster</h2>
            <ul>
            <li><a href="/guides/pdf-tools-construction">Construction</a> · <a href="/guides/pdf-tools-real-estate">Real estate</a></li>
            <li><a href="/guides/pdf-tools-healthcare-admin">Healthcare admin</a> · <a href="/guides/pdf-tools-insurance">Insurance</a></li>
            <li><a href="/guides/pdf-tools-for-lawyers">Lawyers</a> · <a href="/guides/pdf-tools-for-accountants">Accountants</a></li>
            <li><a href="/guides/pdf-tools-marketing-agencies">Marketing</a> · <a href="/guides/pdf-tools-nonprofits">Nonprofits</a></li>
            <li><a href="/guides/pdf-tools-recruiters">Recruiters</a> · <a href="/guides/pdf-tools-for-students">Students</a> · <a href="/guides/pdf-tools-teachers">Teachers</a></li>
            </ul>
            <p>Hub: <a href="/guides/pdf-tools">PDF tools</a> · SMB: <a href="/guides/pdf-tools-small-business">small business stack</a></p>
            """

W22_RESEARCH_CLUSTER = """
            <h2>Research &amp; compliance cluster</h2>
            <ul>
            <li><a href="/guides/pdf-compression-benchmark">Compression benchmark guide</a></li>
            <li><a href="/guides/gmail-vs-outlook-pdf-limits">Gmail vs Outlook limits</a></li>
            <li><a href="/guides/freelancer-invoicing-statistics">Freelancer invoicing stats</a></li>
            <li><a href="/guides/university-pdf-upload-requirements">University upload requirements</a></li>
            <li><a href="/guides/email-attachment-size-limits-2026">Email limits 2026</a></li>
            </ul>
            <p>Research: <a href="/research/pdf-compression-benchmark">benchmark data</a> · <a href="/research/attachment-size-limits">attachment limits</a></p>
            """

W22_GLOSSARY_CLUSTER = """
            <h2>Glossary batch 4</h2>
            <ul>
            <li><a href="/guides/glossary-attachments">Attachments</a></li>
            <li><a href="/guides/glossary-batch-processing">Batch processing</a></li>
            <li><a href="/guides/glossary-bleed-box">Bleed box</a></li>
            <li><a href="/guides/glossary-crop-box">Crop box</a></li>
            <li><a href="/guides/glossary-embedded-files">Embedded files</a></li>
            </ul>
            <p>Hub: <a href="/guides/pdf-tools">PDF tools glossary index</a></p>
            """
