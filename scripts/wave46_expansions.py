"""Wave 46 — CREATE batch 10 (17 guides, score 75–77). Retention, review, errors, forms, print, archive, epub."""

W46_SLUGS = [
    "pdf-retention-policy",
    "pdf-review-workflow",
    "pdf-error-not-a-valid-file",
    "xfa-to-acroform-convert",
    "pdf-prints-cropped-off",
    "pdf-a-2b-vs-pdf-a-3",
    "pdf-javascript-security-risk",
    "digitize-paper-archive-pdf",
    "pdf-file-size-explained",
    "pdf-error-print-spooler",
    "pdf-form-calculate-fields",
    "fix-pdf-missing-alt-text",
    "pdf-prints-wrong-paper-size",
    "pdf-long-term-archive-strategy",
    "pdf-timestamp-authority-signing",
    "pdf-to-epub",
    "what-is-a-pdf-file",
]

ARCHIVAL_CREATE_SLUGS = {
    "pdf-retention-policy",
    "pdf-a-2b-vs-pdf-a-3",
    "digitize-paper-archive-pdf",
    "pdf-long-term-archive-strategy",
    "pdf-timestamp-authority-signing",
}

WORKFLOW_CREATE_SLUGS = {"pdf-review-workflow"}

TROUBLESHOOT_CREATE_SLUGS = {"pdf-error-not-a-valid-file", "pdf-error-print-spooler"}

FORM_CREATE_SLUGS = {"xfa-to-acroform-convert", "pdf-form-calculate-fields"}

PRINT_CREATE_SLUGS = {"pdf-prints-cropped-off", "pdf-prints-wrong-paper-size"}

SECURITY_CREATE_SLUGS = {"pdf-javascript-security-risk"}

COMPRESS_CREATE_SLUGS = {"pdf-file-size-explained"}

ACCESSIBILITY_CREATE_SLUGS = {"fix-pdf-missing-alt-text"}

CONVERT_CREATE_SLUGS = {"pdf-to-epub"}

INFO_CREATE_SLUGS = {"what-is-a-pdf-file"}

W46_DATA = {
    "pdf-retention-policy": {
        "title": "PDF Retention Policy — Schedules &amp; Legal Hold (2026)",
        "tool": "/pdf/pdfmetadata",
        "label": "PDF Metadata",
        "pillar": "/guides/document-retention-pdf",
        "pillar_label": "document retention PDF",
        "related": "/guides/pdf-document-retention-periods",
        "prog": "/pdf/pdfmetadata",
        "example": "Compliance maps invoice PDF 7-year retention — contract 10-year — legal hold pauses destruction on litigation matter",
    },
    "pdf-review-workflow": {
        "title": "PDF Review Workflow — Comments, Versions &amp; Sign-Off (2026)",
        "tool": "/pdf/merge",
        "label": "Merge PDF",
        "pillar": "/guides/pdf-tools",
        "pillar_label": "PDF tools hub",
        "related": "/guides/contract-pdf-redline-workflow",
        "prog": "/pdf/merge",
        "example": "Agency circulates DRAFT policy PDF — watermark — merge approved annex — flatten final for board sign-off",
    },
    "pdf-error-not-a-valid-file": {
        "title": "PDF Not a Valid File — Download &amp; Extension Fixes (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/pdf-troubleshooting",
        "pillar_label": "PDF troubleshooting",
        "related": "/guides/pdf-file-corrupted",
        "prog": "/pdf/compress",
        "example": "User opens attachment — not a valid PDF — file was HTML error page saved as .pdf — re-download from source",
    },
    "xfa-to-acroform-convert": {
        "title": "Convert XFA PDF to AcroForm — Migration Workflow (2026)",
        "tool": "/pdf/editpdf",
        "label": "Edit PDF",
        "pillar": "/guides/create-fillable-pdf",
        "pillar_label": "create fillable PDF",
        "related": "/guides/glossary-xfa-forms",
        "prog": "/pdf/editpdf",
        "example": "HR migrates legacy XFA onboarding pack — rebuild fields in AcroForm — test in Adobe Reader and browser",
    },
    "pdf-prints-cropped-off": {
        "title": "PDF Prints Cropped Off — Margins &amp; Scale Fixes (2026)",
        "tool": "/pdf/flattenpdf",
        "label": "Flatten PDF",
        "pillar": "/guides/print-pdf-without-margins",
        "pillar_label": "print without margins",
        "related": "/guides/pdf-prints-too-light",
        "prog": "/pdf/flattenpdf",
        "example": "Brochure PDF crops at edges on office MFP — disable fit-to-page — set 100% scale — check bleed box",
    },
    "pdf-a-2b-vs-pdf-a-3": {
        "title": "PDF/A-2b vs PDF/A-3 — Which Archive Format? (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/convert-to-pdf-a",
        "pillar_label": "convert to PDF/A",
        "related": "/guides/pdf-a-1b-compliance-checklist",
        "prog": "/pdf/compress",
        "example": "Records team picks PDF/A-2b for deed scans — PDF/A-3 when embedding source XML invoice alongside access copy",
    },
    "pdf-javascript-security-risk": {
        "title": "PDF JavaScript Security Risk — Disable &amp; Audit (2026)",
        "tool": "/pdf/password",
        "label": "Protect PDF",
        "pillar": "/guides/pdf-password-best-practices",
        "pillar_label": "password best practices",
        "related": "/guides/secure-pdf-before-email",
        "prog": "/pdf/password",
        "example": "IT blocks JavaScript actions in inbound vendor PDFs — flatten interactive layers — scan with enterprise AV",
    },
    "digitize-paper-archive-pdf": {
        "title": "Digitize Paper Archive to PDF — Scanning Workflow (2026)",
        "tool": "/pdf/ocrpdf",
        "label": "OCR PDF",
        "pillar": "/guides/archive-pdf-long-term-storage",
        "pillar_label": "archive PDF long-term",
        "related": "/guides/pdf-migration-documents-to-pdfa",
        "prog": "/pdf/ocrpdf",
        "example": "County clerk scans 40k deed pages — 300 DPI TIFF masters — PDF/A-2b access copies — index metadata",
    },
    "pdf-file-size-explained": {
        "title": "PDF File Size Explained — Images, Fonts &amp; Objects (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/why-is-pdf-file-so-large",
        "pillar_label": "why PDF is large",
        "related": "/guides/how-pdf-compression-works",
        "prog": "/compress-pdf",
        "example": "Designer learns 12 MB brochure is mostly embedded photos — compress images — subset fonts — drops to 2 MB",
    },
    "pdf-error-print-spooler": {
        "title": "PDF Print Spooler Error — Windows Driver Fixes (2026)",
        "tool": "/pdf/flattenpdf",
        "label": "Flatten PDF",
        "pillar": "/guides/pdf-troubleshooting",
        "pillar_label": "PDF troubleshooting",
        "related": "/guides/pdf-printing-blank-pages",
        "prog": "/pdf/flattenpdf",
        "example": "Windows spooler crashes on complex PDF — flatten layers — print as image — restart Print Spooler service",
    },
    "pdf-form-calculate-fields": {
        "title": "PDF Form Calculated Fields — Totals &amp; Formulas (2026)",
        "tool": "/pdf/editpdf",
        "label": "Edit PDF",
        "pillar": "/guides/create-fillable-pdf",
        "pillar_label": "create fillable PDF",
        "related": "/guides/pdf-form-field-validation",
        "prog": "/pdf/editpdf",
        "example": "Finance builds invoice PDF — line totals sum to grand total field — test in Reader before client send",
    },
    "fix-pdf-missing-alt-text": {
        "title": "Fix PDF Missing Alt Text — Images &amp; Figures (2026)",
        "tool": "/pdf/ocrpdf",
        "label": "OCR PDF",
        "pillar": "/guides/pdf-ua-accessibility",
        "pillar_label": "PDF/UA accessibility",
        "related": "/guides/tagged-pdf-checklist",
        "prog": "/pdf/ocrpdf",
        "example": "Marketing PDF fails accessibility audit — add alt text on hero image — retag figure — NVDA spot-check",
    },
    "pdf-prints-wrong-paper-size": {
        "title": "PDF Prints Wrong Paper Size — A4 vs Letter Fix (2026)",
        "tool": "/pdf/flattenpdf",
        "label": "Flatten PDF",
        "pillar": "/guides/print-pdf-without-margins",
        "pillar_label": "print without margins",
        "related": "/guides/pdf-prints-cropped-off",
        "prog": "/pdf/flattenpdf",
        "example": "US Letter PDF shrinks on A4 tray — set paper size in print dialog — or resize page in preflight",
    },
    "pdf-long-term-archive-strategy": {
        "title": "PDF Long-Term Archive Strategy — Tiers &amp; Migration (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/long-term-pdf-storage",
        "pillar_label": "long-term PDF storage",
        "related": "/guides/archive-pdf-long-term-storage",
        "prog": "/pdf/compress",
        "example": "Enterprise defines warm PDF/A access tier — cold tape for masters — 5-year format migration review",
    },
    "pdf-timestamp-authority-signing": {
        "title": "PDF Timestamp Authority Signing — TSA &amp; Long-Term Validation (2026)",
        "tool": "/pdf/signpdf",
        "label": "Sign PDF",
        "pillar": "/guides/pdf-standards-archiving-hub",
        "pillar_label": "PDF standards hub",
        "related": "/guides/glossary-digital-signature",
        "prog": "/pdf/signpdf",
        "example": "Legal applies PAdES signature with RFC 3161 timestamp — LTV chain embedded — archive for 10+ years",
    },
    "pdf-to-epub": {
        "title": "PDF to EPUB — E-Book Conversion Workflow (2026)",
        "tool": "/pdf/pdftodoc",
        "label": "PDF to Word",
        "pillar": "/guides/pdf-to-word",
        "pillar_label": "PDF to Word",
        "related": "/guides/beginner-what-is-a-pdf",
        "prog": "/pdf/pdftodoc",
        "example": "Publisher converts reflowable chapter PDF — Word cleanup — export EPUB — validate in Calibre",
    },
    "what-is-a-pdf-file": {
        "title": "What Is a PDF File? — Format, ISO &amp; Use Cases (2026)",
        "tool": "/guides/pdf-tools",
        "label": "PDF tools hub",
        "pillar": "/guides/beginner-what-is-a-pdf",
        "pillar_label": "beginner PDF intro",
        "related": "/guides/glossary-pdf",
        "prog": "/guides/pdf-tools",
        "example": "New hire learns PDF preserves layout across devices — ISO 32000 — when to use PDF vs DOCX vs HTML",
    },
}


def _d(slug: str, html: str) -> str:
    p = W46_DATA[slug].get("prog", "")
    tail = f'<p>Tool: <a href="{p}">{p}</a></p>' if p else ""
    return html + tail


W46_DEEP = {
    "pdf-retention-policy": _d("pdf-retention-policy", """
            <h2>Retention policy framework</h2>
            <ol>
            <li>Classify PDF types — tax, contract, HR, clinical</li>
            <li>Assign retention period per regulation and counsel guidance</li>
            <li>Legal hold overrides destruction schedule</li>
            <li>Audit metadata — created date, matter ID, retention class</li>
            </ol>
            <p><a href="/guides/sox-pdf-retention">SOX retention</a> · <a href="/guides/pdf-litigation-hold-archive">litigation hold</a>.</p>
            """),
    "pdf-review-workflow": _d("pdf-review-workflow", """
            <h2>Review stages</h2>
            <ol>
            <li>Draft — <a href="/pdf/watermark">watermark</a> DRAFT on circulation copy</li>
            <li>Comment round — track changes in source DOCX; export clean PDF per round</li>
            <li>Approval — merge exhibits — <a href="/pdf/flattenpdf">flatten</a> final</li>
            <li>Archive signed PDF with version log</li>
            </ol>
            <p><a href="/guides/contract-pdf-redline-workflow">Redline workflow</a> · remote teams: async PDF comment tools.</p>
            """),
    "pdf-error-not-a-valid-file": _d("pdf-error-not-a-valid-file", """
            <h2>Not a valid PDF — causes</h2>
            <ul>
            <li>Download interrupted — truncated file</li>
            <li>HTML error page saved with .pdf extension</li>
            <li>Wrong format renamed — DOCX or ZIP as PDF</li>
            <li>Corrupted transfer — re-download or request resend</li>
            </ul>
            <p><a href="/guides/pdf-won-t-open">PDF won't open</a> · <a href="/guides/pdf-file-corrupted">File corrupted</a>.</p>
            """),
    "xfa-to-acroform-convert": _d("xfa-to-acroform-convert", """
            <h2>XFA to AcroForm migration</h2>
            <ol>
            <li>Inventory XFA forms still in production</li>
            <li>Export field list and validation rules</li>
            <li>Rebuild in AcroForm editor — match tab order</li>
            <li>QA in Adobe Reader, Foxit, and browser viewers</li>
            </ol>
            <p><a href="/guides/glossary-xfa-forms">XFA glossary</a> · <a href="/guides/pdf-form-field-validation">Field validation</a>.</p>
            """),
    "pdf-prints-cropped-off": _d("pdf-prints-cropped-off", """
            <h2>Cropped print fixes</h2>
            <ul>
            <li>Disable fit-to-page — use 100% scale</li>
            <li>Check MediaBox vs CropBox in preflight</li>
            <li>Flatten transparency before print</li>
            <li>Commercial print: confirm bleed and trim marks</li>
            </ul>
            <p><a href="/guides/commercial-print-pdf-handoff">Commercial print handoff</a>.</p>
            """),
    "pdf-a-2b-vs-pdf-a-3": _d("pdf-a-2b-vs-pdf-a-3", """
            <h2>PDF/A-2b vs PDF/A-3</h2>
            <table class="table table-sm">
            <tr><th>Format</th><th>Best for</th></tr>
            <tr><td>PDF/A-2b</td><td>Scanned deeds, policies, general access copies</td></tr>
            <tr><td>PDF/A-3</td><td>Embedding source XML, CAD, or audit files in archive</td></tr>
            </table>
            <p><a href="/guides/pdf-migration-documents-to-pdfa">Migration workflow</a> · validate with veraPDF.</p>
            """),
    "pdf-javascript-security-risk": _d("pdf-javascript-security-risk", """
            <h2>JavaScript in PDF — risks</h2>
            <ul>
            <li>Auto-open URLs or launch actions on open</li>
            <li>Form submit to external endpoints</li>
            <li>Enterprise policy: disable JS in Acrobat and browsers</li>
            <li>Flatten or rasterize untrusted inbound PDFs</li>
            </ul>
            <p><a href="/guides/encrypt-pdf-aes-256">AES-256 encrypt</a> · <a href="/guides/secure-pdf-before-email">Secure before email</a>.</p>
            """),
    "digitize-paper-archive-pdf": _d("digitize-paper-archive-pdf", """
            <h2>Digitization pipeline</h2>
            <ol>
            <li>Prep — remove staples, batch by box</li>
            <li>Scan 300 DPI minimum — TIFF or PNG masters</li>
            <li>OCR searchable text layer — <a href="/pdf/ocrpdf">OCR PDF</a></li>
            <li>Export PDF/A-2b access copy — index metadata</li>
            </ol>
            <p><a href="/guides/pdf-migration-documents-to-pdfa">PDF/A migration</a> · chain of custody log.</p>
            """),
    "pdf-file-size-explained": _d("pdf-file-size-explained", """
            <h2>What drives PDF size</h2>
            <ul>
            <li>Embedded images — often 60–80% of scan PDFs</li>
            <li>Full font embedding vs subsetting</li>
            <li>Duplicate objects and uncompressed streams</li>
            <li>Attachments and layered artwork</li>
            </ul>
            <p><a href="/guides/how-pdf-compression-works">How compression works</a> · <a href="/pdf/compress">Compress PDF</a>.</p>
            """),
    "pdf-error-print-spooler": _d("pdf-error-print-spooler", """
            <h2>Print spooler errors</h2>
            <ol>
            <li>Restart Windows Print Spooler service</li>
            <li>Update or reinstall printer driver</li>
            <li>Flatten PDF — print as image</li>
            <li>Try another viewer — Adobe vs Edge print engine</li>
            </ol>
            <p><a href="/guides/pdf-printing-blank-pages">Blank pages</a> · <a href="/guides/pdf-prints-too-light">Prints too light</a>.</p>
            """),
    "pdf-form-calculate-fields": _d("pdf-form-calculate-fields", """
            <h2>Calculated fields</h2>
            <ul>
            <li>Sum line items into subtotal and grand total</li>
            <li>Simple arithmetic — not spreadsheet-grade formulas</li>
            <li>Field naming must match calculation script</li>
            <li>Test all combinations before publish</li>
            </ul>
            <p><a href="/guides/pdf-form-field-validation">Field validation</a> · AcroForm only — XFA uses different engine.</p>
            """),
    "fix-pdf-missing-alt-text": _d("fix-pdf-missing-alt-text", """
            <h2>Alt text remediation</h2>
            <ol>
            <li>Run accessibility checker — flag Figures without alt</li>
            <li>Write concise alt — purpose not decoration</li>
            <li>Retag reading order if images break flow</li>
            <li>NVDA or VoiceOver spot-check</li>
            </ol>
            <p><a href="/guides/screen-reader-pdf">Screen reader PDF</a> · <a href="/guides/tagged-pdf-checklist">Tagged PDF checklist</a>.</p>
            """),
    "pdf-prints-wrong-paper-size": _d("pdf-prints-wrong-paper-size", """
            <h2>Paper size mismatch</h2>
            <ul>
            <li>US Letter (8.5×11) vs A4 (210×297 mm)</li>
            <li>Set tray and print dialog to match PDF MediaBox</li>
            <li>Scale to fit causes margin drift — prefer native size</li>
            <li>Resize page in preflight for mixed fleets</li>
            </ul>
            <p><a href="/guides/pdf-prints-cropped-off">Prints cropped off</a> · <a href="/guides/print-pdf-without-margins">Print without margins</a>.</p>
            """),
    "pdf-long-term-archive-strategy": _d("pdf-long-term-archive-strategy", """
            <h2>Archive strategy tiers</h2>
            <ol>
            <li>Hot — active matter PDFs on primary storage</li>
            <li>Warm — PDF/A access copies with checksum audit</li>
            <li>Cold — tape or glacier for masters</li>
            <li>Migration review every 5 years — format obsolescence</li>
            </ol>
            <p><a href="/guides/archive-pdf-long-term-storage">Archive storage guide</a> · <a href="/guides/pdf-a-2b-vs-pdf-a-3">PDF/A format pick</a>.</p>
            """),
    "pdf-timestamp-authority-signing": _d("pdf-timestamp-authority-signing", """
            <h2>TSA signing workflow</h2>
            <ol>
            <li>Sign with qualified certificate</li>
            <li>Embed RFC 3161 timestamp from TSA</li>
            <li>Build LTV — OCSP/CRL for long-term validation</li>
            <li>Store in WORM or immutable archive tier</li>
            </ol>
            <p><a href="/guides/glossary-digital-signature">Digital signature glossary</a> · counsel for qualified trust lists.</p>
            """),
    "pdf-to-epub": _d("pdf-to-epub", """
            <h2>PDF to EPUB path</h2>
            <ol>
            <li>Digital PDF — <a href="/pdf/pdftodoc">PDF to Word</a> for structure cleanup</li>
            <li>Remove fixed-layout elements unsuitable for reflow</li>
            <li>Export EPUB from Word or dedicated converter</li>
            <li>Validate in Calibre — fix TOC and CSS</li>
            </ol>
            <p>Scanned PDFs need <a href="/pdf/ocrpdf">OCR</a> first — layout-heavy books may stay PDF.</p>
            """),
    "what-is-a-pdf-file": _d("what-is-a-pdf-file", """
            <h2>PDF basics</h2>
            <ul>
            <li>Portable Document Format — ISO 32000 family</li>
            <li>Fixed layout — looks same on phone, print, and desktop</li>
            <li>Supports text, vector, raster, forms, signatures</li>
            <li>PDF/A for archive — PDF/UA for accessibility — PDF/X for print</li>
            </ul>
            <p><a href="/guides/glossary-pdf">PDF glossary</a> · <a href="/guides/pdf-tools">Tools hub</a>.</p>
            """),
}

W46_CREATE_CLUSTER = """
            <h2>CREATE batch 10</h2>
            <ul>
            <li>Compliance: <a href="/guides/pdf-retention-policy">Retention policy</a> · <a href="/guides/pdf-long-term-archive-strategy">Archive strategy</a> · <a href="/guides/pdf-a-2b-vs-pdf-a-3">PDF/A-2b vs 3</a> · <a href="/guides/pdf-timestamp-authority-signing">TSA signing</a></li>
            <li>Workflow: <a href="/guides/pdf-review-workflow">Review workflow</a> · <a href="/guides/digitize-paper-archive-pdf">Digitize paper</a></li>
            <li>Forms: <a href="/guides/xfa-to-acroform-convert">XFA to AcroForm</a> · <a href="/guides/pdf-form-calculate-fields">Calculated fields</a></li>
            <li>Print: <a href="/guides/pdf-prints-cropped-off">Cropped off</a> · <a href="/guides/pdf-prints-wrong-paper-size">Wrong paper size</a></li>
            <li>Troubleshoot: <a href="/guides/pdf-error-not-a-valid-file">Not valid file</a> · <a href="/guides/pdf-error-print-spooler">Print spooler</a></li>
            <li>Other: <a href="/guides/pdf-javascript-security-risk">JavaScript risk</a> · <a href="/guides/pdf-file-size-explained">File size</a> · <a href="/guides/fix-pdf-missing-alt-text">Missing alt text</a> · <a href="/guides/pdf-to-epub">PDF to EPUB</a> · <a href="/guides/what-is-a-pdf-file">What is PDF</a></li>
            </ul>
            <p>Prior batch: <a href="/guides/contract-pdf-workflow-greece">Wave 45 contract Asia/MENA</a></p>
            """

W46_ARCHIVAL_CLUSTER = """
            <h2>Wave 46 archive &amp; compliance hubs</h2>
            <p>Retention: <a href="/guides/pdf-retention-policy">retention policy</a> · <a href="/guides/document-retention-pdf">document retention</a> · <a href="/guides/pdf-document-retention-periods">retention periods</a></p>
            <p>PDF/A: <a href="/guides/pdf-a-2b-vs-pdf-a-3">PDF/A-2b vs 3</a> · <a href="/guides/pdf-migration-documents-to-pdfa">migration</a> · <a href="/guides/pdf-a-1b-compliance-checklist">PDF/A-1b checklist</a></p>
            <p>Strategy: <a href="/guides/pdf-long-term-archive-strategy">long-term strategy</a> · <a href="/guides/archive-pdf-long-term-storage">archive storage</a> · <a href="/guides/digitize-paper-archive-pdf">digitize paper</a></p>
            """

W46_PRINT_CLUSTER = """
            <h2>Wave 46 print troubleshooting</h2>
            <p><a href="/guides/pdf-prints-cropped-off">Cropped off</a> · <a href="/guides/pdf-prints-wrong-paper-size">Wrong paper size</a> · <a href="/guides/pdf-prints-too-light">Too light</a> · <a href="/guides/pdf-printing-blank-pages">Blank pages</a></p>
            <p><a href="/guides/pdf-error-print-spooler">Print spooler error</a> · <a href="/guides/commercial-print-pdf-handoff">Commercial handoff</a></p>
            """

W46_FORM_CLUSTER = """
            <h2>Wave 46 form hubs</h2>
            <p><a href="/guides/xfa-to-acroform-convert">XFA to AcroForm</a> · <a href="/guides/pdf-form-calculate-fields">Calculated fields</a> · <a href="/guides/pdf-form-field-validation">Field validation</a> · <a href="/guides/create-fillable-pdf">Create fillable PDF</a></p>
            """

W46_COMPRESS_TOPUP = """
            <h2>CREATE batch 10 checklist</h2>
            <ol>
            <li>Retention policy: classify PDFs and assign destruction dates</li>
            <li>Review workflow: watermark DRAFT until final sign-off</li>
            <li>Archive: pick PDF/A-2b vs 3 before batch migration</li>
            <li>Print QA: match paper size before fit-to-page</li>
            </ol>
            """

W46_CLOSING = """
            <h2>Related guides</h2>
            <p>Wave 46 covers retention policy, review workflow, archive strategy, form migration, print troubleshooting, security, accessibility, and foundational PDF literacy — CREATE batch 10 of 450.</p>
            <p>Hub: <a href="/guides/pdf-standards-archiving-hub">standards &amp; archiving</a> · CREATE remaining: 280</p>
            """
