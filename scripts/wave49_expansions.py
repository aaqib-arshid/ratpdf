"""Wave 49 — CREATE batch 13 (17 guides, score 74). Persona finale + workflow, print, a11y, archive."""

W49_SLUGS = [
    "best-browser-pdf-tools-for-remote-teams",
    "best-browser-pdf-tools-for-researchers",
    "best-browser-pdf-tools-for-small-business",
    "best-browser-pdf-tools-for-startups",
    "best-browser-pdf-tools-for-students",
    "best-browser-pdf-tools-for-tax-preparers",
    "best-browser-pdf-tools-for-teachers",
    "pdf-overprint-printing",
    "pdf-comment-export",
    "pdf-workflow-checklist",
    "pdf-error-out-of-memory",
    "beginner-how-pdf-compression-works",
    "pdf-review-workflow-remote-team",
    "pdf-form-tab-order",
    "fix-pdf-untagged-content",
    "pdf-prints-double-sided-wrong",
    "pdf-digitization-project-plan",
]

PERSONA_CREATE_SLUGS = {
    "best-browser-pdf-tools-for-remote-teams",
    "best-browser-pdf-tools-for-researchers",
    "best-browser-pdf-tools-for-small-business",
    "best-browser-pdf-tools-for-startups",
    "best-browser-pdf-tools-for-students",
    "best-browser-pdf-tools-for-tax-preparers",
    "best-browser-pdf-tools-for-teachers",
}

PRINT_CREATE_SLUGS = {"pdf-overprint-printing", "pdf-prints-double-sided-wrong"}

WORKFLOW_CREATE_SLUGS = {
    "pdf-comment-export",
    "pdf-workflow-checklist",
    "pdf-review-workflow-remote-team",
}

TROUBLESHOOT_CREATE_SLUGS = {"pdf-error-out-of-memory"}

COMPRESS_CREATE_SLUGS = {"beginner-how-pdf-compression-works"}

FORM_CREATE_SLUGS = {"pdf-form-tab-order"}

ACCESSIBILITY_CREATE_SLUGS = {"fix-pdf-untagged-content"}

ARCHIVAL_CREATE_SLUGS = {"pdf-digitization-project-plan"}

W49_PERSONA_META = {
    "remote-teams": (
        "Remote Teams",
        "Watermark DRAFT PDFs in async review, merge annexes before sign-off, and compress for Slack and email caps",
        "/pdf/watermark",
        "Watermark PDF",
    ),
    "researchers": (
        "Researchers",
        "Merge literature PDFs, OCR scanned papers, and compress bundles before repository deposit",
        "/pdf/merge",
        "Merge PDF",
    ),
    "small-business": (
        "Small Business",
        "Merge invoice and receipt PDFs, compress for accountant email, and password-protect client quotes",
        "/pdf/merge",
        "Merge PDF",
    ),
    "startups": (
        "Startups",
        "Watermark pitch deck PDFs, merge data-room exhibits, and compress before investor DocSend upload",
        "/pdf/watermark",
        "Watermark PDF",
    ),
    "students": (
        "Students",
        "Merge assignment PDFs, compress for LMS upload, and split long reading packs by week",
        "/pdf/merge",
        "Merge PDF",
    ),
    "tax-preparers": (
        "Tax Preparers",
        "Merge W-2 and 1099 PDFs, compress client return packs, and redact SSN before external share",
        "/pdf/merge",
        "Merge PDF",
    ),
    "teachers": (
        "Teachers",
        "Merge syllabus and worksheet PDFs, compress for Google Classroom, and OCR scanned handouts",
        "/pdf/merge",
        "Merge PDF",
    ),
}

W49_DATA = {
    "pdf-overprint-printing": {
        "title": "PDF Overprint Printing — Spot &amp; Process Color (2026)",
        "tool": "/pdf/flattenpdf",
        "label": "Flatten PDF",
        "pillar": "/guides/commercial-print-pdf-handoff",
        "pillar_label": "commercial print handoff",
        "related": "/guides/pdf-x-print-standard",
        "prog": "/pdf/flattenpdf",
        "example": "Packaging designer checks overprint preview — spot Pantone plus CMYK — preflight before flexo run",
    },
    "pdf-comment-export": {
        "title": "PDF Comment Export — Review Annotations Workflow (2026)",
        "tool": "/pdf/merge",
        "label": "Merge PDF",
        "pillar": "/guides/pdf-review-workflow",
        "pillar_label": "PDF review workflow",
        "related": "/guides/contract-pdf-redline-workflow",
        "prog": "/pdf/merge",
        "example": "PM exports comment summary from Acrobat — merges clean PDF with annotation appendix for stakeholder archive",
    },
    "pdf-workflow-checklist": {
        "title": "PDF Workflow Checklist — Intake to Archive (2026)",
        "tool": "/guides/pdf-tools",
        "label": "PDF tools hub",
        "pillar": "/guides/pdf-tools",
        "pillar_label": "PDF tools hub",
        "related": "/guides/pdf-email-attachment-checklist",
        "prog": "/guides/pdf-tools",
        "example": "Ops publishes team wiki checklist — receive PDF — OCR if scan — compress — redact — merge — archive PDF/A",
    },
    "pdf-error-out-of-memory": {
        "title": "PDF Out of Memory Error — Split &amp; Optimize Fixes (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/pdf-troubleshooting",
        "pillar_label": "PDF troubleshooting",
        "related": "/guides/pdf-file-corrupted",
        "prog": "/pdf/compress",
        "example": "Viewer crashes opening 800 MB scan PDF — split by chapter — compress images — reopen under RAM cap",
    },
    "beginner-how-pdf-compression-works": {
        "title": "How PDF Compression Works — Beginner Guide (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/how-pdf-compression-works",
        "pillar_label": "how PDF compression works",
        "related": "/guides/why-is-pdf-file-so-large",
        "prog": "/compress-pdf",
        "example": "New user learns JPEG re-encode shrinks phone scan 50% while Word export PDF shrinks only 10%",
    },
    "pdf-review-workflow-remote-team": {
        "title": "PDF Review Workflow Remote Team — Async Sign-Off (2026)",
        "tool": "/pdf/watermark",
        "label": "Watermark PDF",
        "pillar": "/guides/pdf-review-workflow",
        "pillar_label": "PDF review workflow",
        "related": "/guides/best-browser-pdf-tools-for-remote-teams",
        "prog": "/pdf/watermark",
        "example": "Distributed team circulates DRAFT policy PDF — watermark — async comments — merge approved annex — flatten final",
    },
    "pdf-form-tab-order": {
        "title": "PDF Form Tab Order — Accessibility &amp; UX (2026)",
        "tool": "/pdf/editpdf",
        "label": "Edit PDF",
        "pillar": "/guides/pdf-form-accessibility-tags",
        "pillar_label": "form accessibility tags",
        "related": "/guides/create-fillable-pdf",
        "prog": "/pdf/editpdf",
        "example": "HR fixes onboarding PDF — tab order follows visual layout — screen reader matches keyboard flow",
    },
    "fix-pdf-untagged-content": {
        "title": "Fix Untagged PDF Content — Structure Remediation (2026)",
        "tool": "/pdf/ocrpdf",
        "label": "OCR PDF",
        "pillar": "/guides/tagged-pdf-checklist",
        "pillar_label": "tagged PDF checklist",
        "related": "/guides/fix-pdf-reading-order",
        "prog": "/pdf/ocrpdf",
        "example": "Public policy PDF fails PAC — auto-tagged then manual H1–H3 fix — NVDA read-through pass",
    },
    "pdf-prints-double-sided-wrong": {
        "title": "PDF Double-Sided Print Wrong Order — Duplex Fixes (2026)",
        "tool": "/pdf/flattenpdf",
        "label": "Flatten PDF",
        "pillar": "/guides/pdf-printing-guide",
        "pillar_label": "PDF printing guide",
        "related": "/guides/pdf-prints-cropped-off",
        "prog": "/pdf/flattenpdf",
        "example": "Booklet PDF prints page 2 on back of page 1 wrong — set long-edge vs short-edge duplex — reorder spreads",
    },
    "pdf-digitization-project-plan": {
        "title": "PDF Digitization Project Plan — Scope &amp; QA (2026)",
        "tool": "/pdf/ocrpdf",
        "label": "OCR PDF",
        "pillar": "/guides/digitize-paper-archive-pdf",
        "pillar_label": "digitize paper archive",
        "related": "/guides/pdf-migration-documents-to-pdfa",
        "prog": "/pdf/ocrpdf",
        "example": "County plans 50k-page deed digitization — scan spec — OCR QA sample — PDF/A ingest — migration timeline",
    },
}

for persona, (title, example, tool, label) in W49_PERSONA_META.items():
    slug = f"best-browser-pdf-tools-for-{persona}"
    W49_DATA[slug] = {
        "title": f"Best Browser PDF Tools for {title} — Workflow Picks (2026)",
        "tool": tool,
        "label": label,
        "pillar": "/guides/browser-vs-desktop-pdf-tools",
        "pillar_label": "browser vs desktop PDF tools",
        "related": "/guides/choose-pdf-tool",
        "prog": tool,
        "example": example,
        "persona": title,
    }


def _d(slug: str, html: str) -> str:
    p = W49_DATA[slug].get("prog", "")
    tail = f'<p>Tool: <a href="{p}">{p}</a></p>' if p else ""
    return html + tail


def _persona_deep(slug: str) -> str:
    d = W49_DATA[slug]
    return _d(
        slug,
        f"""
            <h2>Browser PDF toolkit for {d['persona']}</h2>
            <p>Typical tasks: {d['example']}.</p>
            <ul>
            <li><a href="/pdf/merge">Merge</a> · <a href="/pdf/compress">Compress</a> · <a href="/pdf/watermark">Watermark</a></li>
            <li><a href="/pdf/ocrpdf">OCR</a> · <a href="/pdf/redaction">Redact</a> · <a href="/pdf/password">Protect</a></li>
            </ul>
            <p>All 30 persona guides complete — <a href="/guides/choose-pdf-tool">buyer guide</a>.</p>
            """,
    )


W49_DEEP = {
    "pdf-overprint-printing": _d("pdf-overprint-printing", """
            <h2>Overprint in print PDFs</h2>
            <ul>
            <li>Spot color over CMYK — check separations preview</li>
            <li>Overprint preview in Acrobat or preflight tool</li>
            <li>Knockout vs overprint on small reverse type</li>
            <li>Flatten complex overprint for office proof only</li>
            </ul>
            <p><a href="/guides/commercial-print-pdf-checklist">Print checklist</a> · <a href="/guides/pdf-embed-fonts-for-print">Embed fonts</a>.</p>
            """),
    "pdf-comment-export": _d("pdf-comment-export", """
            <h2>Export PDF comments</h2>
            <ol>
            <li>Review round in Acrobat or browser viewer</li>
            <li>Export comment summary PDF or FDF/XFDF</li>
            <li>Merge clean final with comment appendix for archive</li>
            <li>Flatten when comments must not travel externally</li>
            </ol>
            <p><a href="/guides/pdf-review-workflow">Review workflow</a> · <a href="/guides/contract-pdf-redline-workflow">Redline</a>.</p>
            """),
    "pdf-workflow-checklist": _d("pdf-workflow-checklist", """
            <h2>End-to-end PDF checklist</h2>
            <ol>
            <li>Intake — verify valid PDF magic bytes</li>
            <li>Scan? — <a href="/pdf/ocrpdf">OCR</a> searchable layer</li>
            <li>Size cap? — <a href="/pdf/compress">Compress</a> or split</li>
            <li>PII? — <a href="/pdf/redaction">Redact</a> before external send</li>
            <li>Archive — PDF/A access copy with metadata</li>
            </ol>
            <p><a href="/guides/pdf-email-attachment-checklist">Email checklist</a> · <a href="/guides/pdf-tools">Tools hub</a>.</p>
            """),
    "pdf-error-out-of-memory": _d("pdf-error-out-of-memory", """
            <h2>Out of memory fixes</h2>
            <ul>
            <li>Split PDF into smaller parts — <a href="/pdf/split">Split PDF</a></li>
            <li>Compress images — reduce RAM on open</li>
            <li>Close other tabs and apps</li>
            <li>64-bit viewer on large engineering PDFs</li>
            </ul>
            <p><a href="/guides/pdf-won-t-open">PDF won't open</a> · <a href="/guides/why-is-pdf-file-so-large">Why PDF is large</a>.</p>
            """),
    "beginner-how-pdf-compression-works": _d("beginner-how-pdf-compression-works", """
            <h2>Compression basics</h2>
            <ul>
            <li>Images — biggest lever on scan PDFs</li>
            <li>Font subsetting — trims unused glyphs</li>
            <li>Object streams — structural cleanup</li>
            <li>Lossless vs lossy — pick preset for use case</li>
            </ul>
            <p>Deep dive: <a href="/guides/how-pdf-compression-works">full compression guide</a>.</p>
            """),
    "pdf-review-workflow-remote-team": _d("pdf-review-workflow-remote-team", """
            <h2>Remote async review</h2>
            <ol>
            <li>Watermark DRAFT on circulation PDF</li>
            <li>Version filename — <code>Policy-v3-DRAFT.pdf</code></li>
            <li>Async comment window — export summary</li>
            <li>Merge approved changes — flatten final</li>
            </ol>
            <p><a href="/guides/best-browser-pdf-tools-for-remote-teams">Remote team tools</a> · <a href="/guides/pdf-review-workflow">Review hub</a>.</p>
            """),
    "pdf-form-tab-order": _d("pdf-form-tab-order", """
            <h2>Tab order rules</h2>
            <ul>
            <li>Match visual top-to-bottom, left-to-right</li>
            <li>Group related fields — address block together</li>
            <li>Screen reader follows structure tree order</li>
            <li>Test keyboard-only fill before publish</li>
            </ul>
            <p><a href="/guides/pdf-form-accessibility-tags">Form tags</a> · <a href="/guides/pdf-form-field-validation">Validation</a>.</p>
            """),
    "fix-pdf-untagged-content": _d("fix-pdf-untagged-content", """
            <h2>Untagged PDF remediation</h2>
            <ol>
            <li>Run Auto-Tag or OCR with structure output</li>
            <li>Fix heading levels — one H1 per document</li>
            <li>Tag tables — TH for headers</li>
            <li>PAC or axe scan — NVDA spot-check</li>
            </ol>
            <p><a href="/guides/fix-pdf-reading-order">Reading order</a> · <a href="/guides/pdf-ua-accessibility">PDF/UA</a>.</p>
            """),
    "pdf-prints-double-sided-wrong": _d("pdf-prints-double-sided-wrong", """
            <h2>Duplex order fixes</h2>
            <ul>
            <li>Long-edge binding vs short-edge — flip direction</li>
            <li>Booklet imposition vs sequential pages</li>
            <li>Print odd pages first test on 4-page sample</li>
            <li>Driver duplex setting must match document intent</li>
            </ul>
            <p><a href="/guides/pdf-prints-wrong-paper-size">Paper size</a> · <a href="/guides/print-pdf-without-margins">Margins</a>.</p>
            """),
    "pdf-digitization-project-plan": _d("pdf-digitization-project-plan", """
            <h2>Digitization project plan</h2>
            <ol>
            <li>Scope — box count, page estimate, priority series</li>
            <li>Scan spec — 300 DPI, color mode, master format</li>
            <li>OCR QA — 5% sample character accuracy</li>
            <li>PDF/A ingest — metadata schema — migration calendar</li>
            </ol>
            <p><a href="/guides/digitize-paper-archive-pdf">Digitize workflow</a> · <a href="/guides/pdf-long-term-archive-strategy">Archive strategy</a>.</p>
            """),
}

for persona in W49_PERSONA_META:
    W49_DEEP[f"best-browser-pdf-tools-for-{persona}"] = _persona_deep(
        f"best-browser-pdf-tools-for-{persona}"
    )

W49_CREATE_CLUSTER = """
            <h2>CREATE batch 13</h2>
            <ul>
            <li>Persona finale: <a href="/guides/best-browser-pdf-tools-for-remote-teams">Remote teams</a> · <a href="/guides/best-browser-pdf-tools-for-researchers">Researchers</a> · <a href="/guides/best-browser-pdf-tools-for-small-business">Small business</a> · <a href="/guides/best-browser-pdf-tools-for-startups">Startups</a> · <a href="/guides/best-browser-pdf-tools-for-students">Students</a> · <a href="/guides/best-browser-pdf-tools-for-tax-preparers">Tax preparers</a> · <a href="/guides/best-browser-pdf-tools-for-teachers">Teachers</a></li>
            <li>Workflow: <a href="/guides/pdf-workflow-checklist">Workflow checklist</a> · <a href="/guides/pdf-comment-export">Comment export</a> · <a href="/guides/pdf-review-workflow-remote-team">Remote review</a></li>
            <li>Print: <a href="/guides/pdf-overprint-printing">Overprint</a> · <a href="/guides/pdf-prints-double-sided-wrong">Duplex order</a></li>
            <li>Other: <a href="/guides/pdf-error-out-of-memory">Out of memory</a> · <a href="/guides/beginner-how-pdf-compression-works">Compression beginner</a> · <a href="/guides/pdf-form-tab-order">Tab order</a> · <a href="/guides/fix-pdf-untagged-content">Untagged fix</a> · <a href="/guides/pdf-digitization-project-plan">Digitization plan</a></li>
            </ul>
            <p>Persona cluster complete (30/30) — <a href="/guides/best-browser-pdf-tools-for-accountants">Wave 47 start</a></p>
            """

W49_PERSONA_CLUSTER = """
            <h2>Persona guides — complete index (30)</h2>
            <p>Finance: <a href="/guides/best-browser-pdf-tools-for-accountants">Accountants</a> · <a href="/guides/best-browser-pdf-tools-for-bookkeepers">Bookkeepers</a> · <a href="/guides/best-browser-pdf-tools-for-tax-preparers">Tax preparers</a> · <a href="/guides/best-browser-pdf-tools-for-small-business">Small business</a></p>
            <p>Legal: <a href="/guides/best-browser-pdf-tools-for-lawyers">Lawyers</a> · <a href="/guides/best-browser-pdf-tools-for-paralegals">Paralegals</a> · <a href="/guides/best-browser-pdf-tools-for-government-contractors">Gov contractors</a></p>
            <p>People: <a href="/guides/best-browser-pdf-tools-for-hr-teams">HR</a> · <a href="/guides/best-browser-pdf-tools-for-recruiters">Recruiters</a> · <a href="/guides/best-browser-pdf-tools-for-remote-teams">Remote teams</a> · <a href="/guides/best-browser-pdf-tools-for-teachers">Teachers</a> · <a href="/guides/best-browser-pdf-tools-for-students">Students</a></p>
            <p>Creative: <a href="/guides/best-browser-pdf-tools-for-designers">Designers</a> · <a href="/guides/best-browser-pdf-tools-for-marketers">Marketers</a> · <a href="/guides/best-browser-pdf-tools-for-photographers">Photographers</a> · <a href="/guides/best-browser-pdf-tools-for-journalists">Journalists</a></p>
            """

W49_COMPRESS_TOPUP = """
            <h2>CREATE batch 13 checklist</h2>
            <ol>
            <li>Persona cluster 30/30 complete</li>
            <li>Remote review: watermark DRAFT until final sign-off</li>
            <li>Digitization: scan spec + OCR QA sample before PDF/A ingest</li>
            <li>Duplex: test 4-page sample before full print run</li>
            </ol>
            """

W49_CLOSING = """
            <h2>Related guides</h2>
            <p>Wave 49 completes the thirty persona browser-tool guides plus workflow, print, troubleshooting, accessibility, and digitization planning — CREATE batch 13 of 450.</p>
            <p>Hub: <a href="/guides/pdf-tools">PDF tools</a> · CREATE remaining: 229</p>
            """
