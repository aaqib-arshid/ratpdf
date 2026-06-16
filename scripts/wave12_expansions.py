"""Wave 12 — PDF standards & archiving: PDF/A, PDF/UA, PDF/X, metadata, retention."""

W12_SLUGS = [
    "pdf-metadata",
    "add-page-numbers",
    "sox-pdf-retention",
    "beginner-pdf-metadata-explained",
    "pdf-a-archival",
    "convert-to-pdf-a",
    "pdf-a-conversion-online",
    "pdf-ua-accessibility",
    "pdf-x-print-standard",
    "pdf-standards-guide",
    "document-retention-pdf",
    "pdf-archival-best-practices",
    "xmp-metadata-pdf",
    "pdf-version-compatibility",
    "long-term-pdf-storage",
    "pdf-metadata-audit",
    "pdf-standards-archiving-hub",
]

W12_DATA = {
    "pdf-metadata": {
        "title": "PDF Metadata Viewer — Document Properties &amp; Audit Export (2026)",
        "tool": "/pdf/pdfmetadata",
        "label": "PDF Metadata",
        "example": "Records manager exports JSON properties before ECM migration",
    },
    "add-page-numbers": {
        "title": "Add Page Numbers to PDF — Footer Format &amp; Bates Prep (2026)",
        "tool": "/pdf/pagenumbers",
        "label": "Add Page Numbers",
        "example": "Paralegal stamps Page 1 of 120 before court exhibit merge",
    },
    "sox-pdf-retention": {
        "title": "SOX PDF Retention — Finance Records &amp; Immutable Archives (2026)",
        "tool": "/guides/pdf-tools",
        "label": "PDF tools hub",
        "example": "Controller archives quarterly financial PDFs with retention calendar",
    },
    "beginner-pdf-metadata-explained": {
        "title": "PDF Metadata Explained — Title, Author, XMP &amp; Hidden Fields (2026)",
        "tool": "/pdf/pdfmetadata",
        "label": "PDF Metadata",
        "example": "New hire learns why author field leaks on external contract share",
    },
    "pdf-a-archival": {
        "title": "PDF/A Archival — Long-Term Preservation Standard Explained (2026)",
        "tool": "/guides/pdf-tools",
        "label": "PDF tools hub",
        "example": "County clerk plans deed PDF archive meeting PDF/A-1b requirements",
    },
    "convert-to-pdf-a": {
        "title": "Convert to PDF/A — Workflow &amp; Honest Tool Limits (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "example": "IT evaluates whether browser compress pass suffices before dedicated PDF/A server",
    },
    "pdf-a-conversion-online": {
        "title": "PDF/A Conversion Online — When Browser Tools Help vs Specialist Apps (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "example": "Archivist searches online PDF/A after scan backlog from legacy TIFF",
    },
    "pdf-ua-accessibility": {
        "title": "PDF/UA Accessibility — Universal Access ISO Standard (2026)",
        "tool": "/pdf/ocrpdf",
        "label": "OCR PDF",
        "example": "Publisher targets PDF/UA-1 for government RFP accessible deliverable",
    },
    "pdf-x-print-standard": {
        "title": "PDF/X Print Standard — Prepress &amp; Commercial Print Workflow (2026)",
        "tool": "/guides/pdf-tools",
        "label": "PDF tools hub",
        "example": "Print shop rejects marketing PDF missing PDF/X-1a output intent",
    },
    "pdf-standards-guide": {
        "title": "PDF Standards Guide — PDF/A, PDF/UA, PDF/X Decision Matrix (2026)",
        "tool": "/guides/pdf-tools",
        "label": "PDF tools hub",
        "example": "Solution architect picks standard per deliverable type in enterprise wiki",
    },
    "document-retention-pdf": {
        "title": "Document Retention for PDFs — Legal Holds &amp; Destruction Dates (2026)",
        "tool": "/guides/pdf-tools",
        "label": "PDF tools hub",
        "example": "Legal ops maps invoice PDF 7-year retention vs marketing draft 2-year",
    },
    "pdf-archival-best-practices": {
        "title": "PDF Archival Best Practices — Masters, Derivatives &amp; Checksums (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "example": "Museum digitization project stores uncompressed master plus access copy",
    },
    "xmp-metadata-pdf": {
        "title": "XMP Metadata in PDF — Dublin Core &amp; Custom Properties (2026)",
        "tool": "/pdf/pdfmetadata",
        "label": "PDF Metadata",
        "example": "DAM team audits XMP rights field on licensed stock PDF insert",
    },
    "pdf-version-compatibility": {
        "title": "PDF Version Compatibility — 1.4 vs 1.7 vs 2.0 Viewer Issues (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "example": "Portal rejects PDF 2.0 — re-export as PDF 1.7 from source app",
    },
    "long-term-pdf-storage": {
        "title": "Long-Term PDF Storage — Cloud, Tape &amp; Format Migration (2026)",
        "tool": "/guides/pdf-tools",
        "label": "PDF tools hub",
        "example": "Nonprofit plans 10-year grant PDF archive with format migration review",
    },
    "pdf-metadata-audit": {
        "title": "PDF Metadata Audit — Pre-Share &amp; Compliance Checklist (2026)",
        "tool": "/pdf/pdfmetadata",
        "label": "PDF Metadata",
        "example": "Procurement scrubs creator path metadata before vendor RFP publish",
    },
    "pdf-standards-archiving-hub": {
        "title": "PDF Standards &amp; Archiving Hub — Retention, PDF/A &amp; Metadata (2026)",
        "tool": "/guides/pdf-tools",
        "label": "PDF tools hub",
        "example": "Records management team landing page for RatPDF archival workflows",
    },
}

W12_DEEP = {
    "pdf-metadata": """
            <h2>What metadata contains</h2>
            <p>Title, author, subject, keywords, creator application, creation/modification dates, page count — embedded in PDF Info dictionary and XMP packet.</p>
            <h2>Audit workflow</h2>
            <ol>
            <li>Upload to <a href="/pdf/pdfmetadata">PDF Metadata</a> viewer</li>
            <li>Export JSON for ECM or ticketing system</li>
            <li>Compare against records policy — scrub before external share</li>
            <li>See <a href="/guides/pdf-metadata-remove">metadata remove guide</a> for privacy</li>
            </ol>
            """,
    "add-page-numbers": """
            <h2>Format tokens</h2>
            <p><code>{page}</code> and <code>{total}</code> — e.g. <code>Page {page} of {total}</code> or Bates <code>EXHIBIT {page}</code>.</p>
            <h2>Merge first</h2>
            <p>Multi-part PDF — <a href="/guides/merge-pdf">merge</a> in final order — then number once — avoids duplicate page 1 sequences.</p>
            """,
    "sox-pdf-retention": """
            <h2>SOX and immutable records</h2>
            <p>Financial PDFs supporting audits — retain 7 years typical — WORM storage or checksum log — not casual Drive delete.</p>
            <h2>RatPDF role</h2>
            <p>Compress delivery copies — metadata audit — merge board packs — not SOX control by itself — policy + IT systems.</p>
            <p>Research: <a href="/research/document-retention-periods">document retention periods</a>.</p>
            """,
    "beginner-pdf-metadata-explained": """
            <h2>Info dictionary vs XMP</h2>
            <p>Classic PDF Info fields vs extensible XMP metadata — both may exist — viewer shows merged picture — audit both.</p>
            <h2>Why beginners care</h2>
            <p>Author leaks partner name — Created date proves draft timing — Subject field embarrasses on court filing.</p>
            """,
    "pdf-a-archival": """
            <h2>PDF/A purpose</h2>
            <p>ISO 19005 — self-contained archival — embedded fonts — no external dependencies — color profiles defined — prohibits encryption on some subsets.</p>
            <h2>Subtypes</h2>
            <p><strong>PDF/A-1b</strong> visual fidelity — <strong>PDF/A-2u</strong> Unicode text — <strong>PDF/A-3</strong> embedded files allowed — pick per archive policy.</p>
            <h2>RatPDF limit</h2>
            <p>No certified PDF/A export — use source app (Word save as PDF/A, Acrobat preflight, dedicated server) — RatPDF for compress delivery copy and metadata QA.</p>
            """,
    "convert-to-pdf-a": """
            <h2>Conversion paths</h2>
            <ol>
            <li>Word/LibreOffice export PDF/A directly from source</li>
            <li>Acrobat Preflight convert to PDF/A</li>
            <li>veraPDF validate after conversion</li>
            <li>RatPDF <a href="/pdf/compress">compress</a> for access copy only — not PDF/A certification</li>
            </ol>
            """,
    "pdf-a-conversion-online": """
            <h2>Online converter caution</h2>
            <p>Claimed PDF/A online tools vary — always validate with veraPDF — institutional archives need audit trail not anonymous upload.</p>
            <h2>When browser enough</h2>
            <p>Internal draft archive with policy accepting PDF 1.7 + embedded fonts — not court-mandated PDF/A-1a.</p>
            """,
    "pdf-ua-accessibility": """
            <h2>PDF/UA (ISO 14289)</h2>
            <p>Machine-readable tagged PDF for assistive technology — stricter than casual WCAG checklist — government RFPs cite PDF/UA-1.</p>
            <h2>Remediation path</h2>
            <p>Author accessible Word → export tagged PDF — scans need OCR + manual tag repair — see <a href="/guides/tagged-pdf-checklist">tagged PDF checklist</a>.</p>
            """,
    "pdf-x-print-standard": """
            <h2>PDF/X for print</h2>
            <p>PDF/X-1a and PDF/X-4 — embed fonts — define output intent — trim/bleed boxes — no RGB-only surprises at press.</p>
            <h2>RatPDF role</h2>
            <p>Marketing team exports PDF/X from InDesign — RatPDF compresses email proof — not prepress replacement.</p>
            """,
    "pdf-standards-guide": """
            <h2>Which standard when</h2>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>Need</th><th>Standard</th><th>Guide</th></tr></thead>
            <tbody>
            <tr><td>Archive 20+ years</td><td>PDF/A</td><td><a href="/guides/pdf-a-archival">PDF/A archival</a></td></tr>
            <tr><td>Screen reader access</td><td>PDF/UA, WCAG</td><td><a href="/guides/pdf-ua-accessibility">PDF/UA</a></td></tr>
            <tr><td>Commercial print</td><td>PDF/X</td><td><a href="/guides/pdf-x-print-standard">PDF/X</a></td></tr>
            <tr><td>Email delivery</td><td>Regular PDF 1.7</td><td><a href="/guides/compress-pdf-guide">Compress</a></td></tr>
            </tbody>
            </table></div>
            """,
    "document-retention-pdf": """
            <h2>Retention by document type</h2>
            <p>Tax invoices 6-7 years — contracts life+ — HR 3-7 — marketing drafts 2 — legal hold pauses destruction — map in records schedule.</p>
            <h2>PDF-specific</h2>
            <p>Keep master uncompressed — derivatives disposable — hash log on immutable copies — <a href="/research/document-retention-periods">retention research</a>.</p>
            """,
    "pdf-archival-best-practices": """
            <h2>3-2-1 for PDF archives</h2>
            <p>Three copies — two media types — one offsite — checksum SHA-256 on ingest — annual open test sample.</p>
            <h2>Format migration</h2>
            <p>Review PDF/A migration every 5 years — technology change — budget specialist validation.</p>
            """,
    "xmp-metadata-pdf": """
            <h2>XMP packet</h2>
            <p>XML embedded in PDF — Dublin Core fields — rights, creator tool, custom namespaces — visible in <a href="/pdf/pdfmetadata">metadata viewer</a>.</p>
            <h2>Rights management</h2>
            <p>Stock photo PDF — verify XMP license field — mismatch risks copyright claim.</p>
            """,
    "pdf-version-compatibility": """
            <h2>Version symptoms</h2>
            <p>Old reader won't open PDF 2.0 — transparency groups — portals mandate 1.4 — save as compatible down-level in source.</p>
            <h2>Compress rewrite</h2>
            <p>Sometimes <a href="/pdf/compress">compress</a> normalizes version — verify on target viewer before bulk.</p>
            """,
    "long-term-pdf-storage": """
            <h2>Storage tiers</h2>
            <p>Hot SSD for active — warm cloud for 1-5 year — cold glacier for legal retention — tape for air-gapped.</p>
            <h2>Encryption at rest</h2>
            <p>Separate from PDF password — bucket encryption — key rotation — not substitute for redaction.</p>
            """,
    "pdf-metadata-audit": """
            <h2>Pre-share checklist</h2>
            <ol>
            <li>Author field acceptable?</li>
            <li>Title meaningful not path?</li>
            <li>Creator shows internal tool name?</li>
            <li>Custom XMP PII?</li>
            <li>Modification date expected?</li>
            </ol>
            """,
    "pdf-standards-archiving-hub": """
            <h2>Hub index</h2>
            <ul>
            <li><a href="/guides/pdf-standards-guide">Standards matrix</a></li>
            <li><a href="/guides/pdf-a-archival">PDF/A</a> · <a href="/guides/pdf-ua-accessibility">PDF/UA</a> · <a href="/guides/pdf-x-print-standard">PDF/X</a></li>
            <li><a href="/guides/document-retention-pdf">Retention</a> · <a href="/guides/sox-pdf-retention">SOX</a></li>
            <li><a href="/guides/pdf-metadata">Metadata</a> · <a href="/guides/pdf-metadata-audit">Metadata audit</a></li>
            <li><a href="/guides/pdf-archival-best-practices">Archival best practices</a></li>
            </ul>
            """,
}

W12_SLUG_EXTRA = {
    "pdf-metadata": """
            <h2>ECM migration</h2>
            <p>Export JSON batch — map to SharePoint columns — title field drives search.</p>
            """,
    "add-page-numbers": """
            <h2>Court filing</h2>
            <p>Local rules specify position — bottom center common — verify on page 1 exhibit cover.</p>
            """,
    "sox-pdf-retention": """
            <h2>Audit request</h2>
            <p>Auditor asks Q3 2024 board PDF — retrieve from WORM — metadata proves creation date.</p>
            """,
    "beginner-pdf-metadata-explained": """
            <h2>Embarrassing leak</h2>
            <p>Title still "Draft_v3_INTERNAL_do_not_send.pdf" on client PDF — metadata audit prevents.</p>
            """,
    "pdf-a-archival": """
            <h2>County records</h2>
            <p>Deed scan PDF/A-1b — veraPDF pass — ingest to archive system.</p>
            """,
    "convert-to-pdf-a": """
            <h2>Batch backlog</h2>
            <p>10k legacy PDFs — script Acrobat action wizard — sample 1% veraPDF — not manual one-by-one.</p>
            """,
    "pdf-a-conversion-online": """
            <h2>Vendor due diligence</h2>
            <p>Ask SOC2 — retention — validate sample output — not just marketing badge.</p>
            """,
    "pdf-ua-accessibility": """
            <h2>RFP win</h2>
            <p>Accessible annual report PDF/UA — beats competitor scan-only submission.</p>
            """,
    "pdf-x-print-standard": """
            <h2>Brochure reject</h2>
            <p>Printer preflight fails RGB — designer re-exports PDF/X-1a — job proceeds.</p>
            """,
    "pdf-standards-guide": """
            <h2>Enterprise wiki</h2>
            <p>One matrix ends marketing vs legal vs print arguments — link from onboarding.</p>
            """,
    "document-retention-pdf": """
            <h2>Legal hold</h2>
            <p>Litigation freeze — suspend auto-delete on matter PDFs — hold log documents scope.</p>
            """,
    "pdf-archival-best-practices": """
            <h2>Museum scan</h2>
            <p>Master TIFF preserved — PDF access copy for public — checksum both.</p>
            """,
    "xmp-metadata-pdf": """
            <h2>Agency photo</h2>
            <p>XMP credit line required in license — missing on PDF brochure — fix before print.</p>
            """,
    "pdf-version-compatibility": """
            <h2>Government portal</h2>
            <p>PDF 1.4 only — save down-level — upload succeeds.</p>
            """,
    "long-term-pdf-storage": """
            <h2>Grant archive</h2>
            <p>10-year funder requirement — glacier tier — annual restore test one file.</p>
            """,
    "pdf-metadata-audit": """
            <h2>RFP publish</h2>
            <p>Scrub internal author — set public title — procurement portal upload.</p>
            """,
    "pdf-standards-archiving-hub": """
            <h2>Records team</h2>
            <p>Single bookmark for RM staff — standards + retention + metadata tools.</p>
            """,
}

W12_MEGA = """
            <h2>Standards vs everyday PDF</h2>
            <p>Most email PDFs are generic ISO 32000 — fine for sharing. Archives, accessible publication, and commercial print need PDF/A, PDF/UA, or PDF/X — validated by specialist tools — not assumed from browser export.</p>
            <h2>RatPDF in archival chain</h2>
            <p><a href="/pdf/pdfmetadata">Metadata</a> audit · <a href="/pdf/pagenumbers">Page numbers</a> · <a href="/pdf/compress">Compress</a> access copies · <a href="/guides/merge-pdf">Merge</a> record bundles · <a href="/pdf/ocrpdf">OCR</a> for searchability — complement source-app PDF/A export.</p>
            <h2>Honest gaps</h2>
            <p>RatPDF does not certify PDF/A, PDF/UA, or PDF/X — plan veraPDF or prepress validation after source conversion.</p>
            """

W12_CLUSTER = """
            <h2>Standards &amp; archiving guides</h2>
            <ul>
            <li><a href="/guides/pdf-a-archival">PDF/A archival</a> · <a href="/guides/convert-to-pdf-a">Convert to PDF/A</a> · <a href="/guides/pdf-a-conversion-online">PDF/A online</a></li>
            <li><a href="/guides/pdf-ua-accessibility">PDF/UA</a> · <a href="/guides/pdf-x-print-standard">PDF/X print</a> · <a href="/guides/pdf-standards-guide">Standards matrix</a></li>
            <li><a href="/guides/pdf-metadata">Metadata viewer</a> · <a href="/guides/xmp-metadata-pdf">XMP</a> · <a href="/guides/pdf-metadata-audit">Metadata audit</a></li>
            <li><a href="/guides/document-retention-pdf">Retention</a> · <a href="/guides/sox-pdf-retention">SOX</a> · <a href="/guides/long-term-pdf-storage">Long-term storage</a></li>
            <li><a href="/guides/pdf-archival-best-practices">Archival best practices</a> · <a href="/guides/pdf-version-compatibility">Version compatibility</a></li>
            <li><a href="/guides/add-page-numbers">Page numbers</a> · <a href="/guides/beginner-pdf-metadata-explained">Metadata explained</a></li>
            </ul>
            <p>Hub: <a href="/guides/pdf-standards-archiving-hub">Standards &amp; archiving hub</a> · <a href="/guides/pdf-security-compliance-guide">Security compliance</a>.</p>
            """

W12_1500_TOPUP = """
            <h2>Archival QA checklist</h2>
            <ol>
            <li>Right standard selected for use case</li>
            <li>veraPDF or prepress validation if required</li>
            <li>Metadata scrubbed before external publish</li>
            <li>Checksum logged on ingest</li>
            <li>Retention class assigned in records system</li>
            <li>Sample open test scheduled annually</li>
            </ol>
            <h2>Research</h2>
            <p><a href="/research/document-retention-periods">Document retention periods</a> · <a href="/guides/pdf-troubleshooting">Troubleshooting</a> · <a href="/guides/pdf-conversion-guide">Conversion hub</a>.</p>
            """

W12_CLOSING = """
            <h2>Related guides</h2>
            <p>Standards and archiving guides cover PDF/A, PDF/UA, PDF/X, metadata, retention, and storage — with honest notes on what RatPDF can and cannot do.</p>
            <p>Printing workflow guides — bookmark the <a href="/guides/pdf-standards-archiving-hub">standards hub</a>.</p>
            """

PILLAR_SLUGS = {"pdf-metadata", "pdf-standards-guide", "pdf-standards-archiving-hub"}
