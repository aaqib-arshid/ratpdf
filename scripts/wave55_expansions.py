"""Wave 55 — CREATE batch 19 (17 guides, score 70–71). OCR-for vertical cluster + workflow guides."""

W55_SLUGS = [
    "fix-pdf-bookmarks-missing",
    "pdf-cloud-archive-vs-on-prem",
    "cad-to-pdf",
    "ocr-pdf-for-lawyers",
    "ocr-pdf-for-accountants",
    "ocr-pdf-for-healthcare",
    "ocr-pdf-for-real-estate",
    "ocr-pdf-for-insurance",
    "ocr-pdf-for-education",
    "ocr-pdf-for-nonprofits",
    "ocr-pdf-for-government",
    "ocr-pdf-for-freelancers",
    "ocr-pdf-for-consultants",
    "ocr-pdf-for-architects",
    "ocr-pdf-for-engineers",
    "ocr-pdf-for-researchers",
    "ocr-pdf-for-journalists",
]

WORKFLOW_CREATE_SLUGS = {
    "fix-pdf-bookmarks-missing",
    "pdf-cloud-archive-vs-on-prem",
    "cad-to-pdf",
}

OCR_FOR_CREATE_SLUGS = set(W55_SLUGS) - WORKFLOW_CREATE_SLUGS

W55_OCR_FOR_META = {
    "lawyers": (
        "Lawyers",
        "Discovery",
        "Paralegal OCRs 400-page scanned deposition PDF so counsel can search witness names in e-discovery",
        "compress-pdf-for-lawyers",
        "merge-pdf-for-lawyers",
    ),
    "accountants": (
        "Accountants",
        "Audit evidence",
        "Staff OCRs scanned vendor invoice PDF so audit team can search line items without re-keying",
        "compress-pdf-for-accountants",
        "merge-pdf-for-accountants",
    ),
    "healthcare": (
        "Healthcare",
        "Records release",
        "Admin OCRs legacy chart scan PDF before redacting PHI for patient disclosure request",
        "compress-pdf-for-healthcare",
        "merge-pdf-for-healthcare",
    ),
    "real-estate": (
        "Real Estate",
        "Disclosure search",
        "Agent OCRs scanned HOA disclosure PDF so buyer can search special assessment keywords",
        "compress-pdf-for-real-estate",
        "merge-pdf-for-real-estate",
    ),
    "insurance": (
        "Insurance",
        "Claims file",
        "Adjuster OCRs photo-heavy claims scan PDF so SIU can search policy number references",
        "compress-pdf-for-insurance",
        "merge-pdf-for-insurance",
    ),
    "education": (
        "Education",
        "Course readings",
        "Instructor OCRs scanned textbook chapter PDF so students can search terms in LMS viewer",
        "compress-pdf-for-education",
        "merge-pdf-for-education",
    ),
    "nonprofits": (
        "Nonprofits",
        "Grant archive",
        "Grant writer OCRs legacy award letter scan PDF for foundation reporting search",
        "compress-pdf-for-nonprofits",
        "merge-pdf-for-nonprofits",
    ),
    "government": (
        "Government",
        "FOIA response",
        "Clerk OCRs scanned FOIA release PDF so requester can search within 500-page bundle",
        "compress-pdf-for-government",
        "merge-pdf-for-government",
    ),
    "freelancers": (
        "Freelancers",
        "Client contract",
        "Freelancer OCRs signed SOW scan PDF so future scope disputes are searchable",
        "compress-pdf-for-freelancers",
        "merge-pdf-for-freelancers",
    ),
    "consultants": (
        "Consultants",
        "Deliverable archive",
        "Consultant OCRs client workshop notes scan PDF before merging into final report pack",
        "compress-pdf-for-consultants",
        "merge-pdf-for-consultants",
    ),
    "architects": (
        "Architects",
        "Submittal search",
        "Architect OCRs scanned spec PDF so GC can search material callouts on tablet",
        "compress-pdf-for-architects",
        "merge-pdf-for-architects",
    ),
    "engineers": (
        "Engineers",
        "Calculation report",
        "Engineer OCRs stamped calc scan PDF so reviewer can search load values",
        "compress-pdf-for-engineers",
        "merge-pdf-for-engineers",
    ),
    "researchers": (
        "Researchers",
        "Legacy supplement",
        "PI OCRs 1990s journal scan PDF so supplementary data tables become searchable",
        "compress-pdf-for-researchers",
        "merge-pdf-for-researchers",
    ),
    "journalists": (
        "Journalists",
        "FOI bundle",
        "Reporter OCRs 800-page FOI dump PDF so editors can search names before publication",
        "compress-pdf-for-journalists",
        "merge-pdf-for-journalists",
    ),
}

W55_DATA = {
    "fix-pdf-bookmarks-missing": {
        "title": "Fix PDF Bookmarks Missing — Add Navigation Outline (2026)",
        "tool": "/pdf/editpdf",
        "label": "Edit PDF",
        "pillar": "/guides/pdf-bookmarks-guide",
        "pillar_label": "PDF bookmarks guide",
        "related": "/guides/pdf-table-of-contents",
        "prog": "/pdf/editpdf",
        "example": "Analyst receives 200-page report PDF with no outline — adds chapter bookmarks before board distribution",
    },
    "pdf-cloud-archive-vs-on-prem": {
        "title": "PDF Cloud Archive vs On-Prem — Retention &amp; Cost (2026)",
        "tool": "/guides/document-retention-pdf",
        "label": "Retention guide",
        "pillar": "/guides/pdf-records-management-policy",
        "pillar_label": "records management policy",
        "related": "/guides/pdf-worm-storage-compliance",
        "prog": "/guides/pdf-records-management-policy",
        "example": "Records manager compares S3 Glacier vs on-prem WORM NAS for 10-year contract PDF archive",
    },
    "cad-to-pdf": {
        "title": "CAD to PDF — Export Drawings for Submittal (2026)",
        "tool": "/pdf/doctopdf",
        "label": "Convert to PDF",
        "pillar": "/guides/pdf-tools",
        "pillar_label": "PDF tools hub",
        "related": "/guides/merge-pdf-for-architects",
        "prog": "/pdf/doctopdf",
        "example": "Architect exports DWG sheet set to PDF via CAD plotter then merges submittal volumes in browser",
    },
}

for key, (audience, use_case, example, compress_slug, merge_slug) in W55_OCR_FOR_META.items():
    slug = f"ocr-pdf-for-{key}"
    W55_DATA[slug] = {
        "title": f"OCR PDF for {audience} — Searchable Scans (2026)",
        "tool": "/pdf/ocrpdf",
        "label": "OCR PDF",
        "pillar": "/guides/ocr-pdf",
        "pillar_label": "OCR PDF guide",
        "related": f"/guides/{compress_slug}",
        "prog": "/pdf/ocrpdf",
        "example": example,
        "audience": audience,
        "use_case": use_case,
        "merge_related": f"/guides/{merge_slug}",
    }


def _d(slug: str, html: str) -> str:
    p = W55_DATA[slug].get("prog", "")
    tail = f'<p>Tool: <a href="{p}">{p}</a></p>' if p else ""
    return html + tail


def _ocr_for_deep(slug: str) -> str:
    d = W55_DATA[slug]
    return _d(
        slug,
        f"""
            <h2>OCR PDF for {d['audience']}</h2>
            <p>Use case: {d['use_case']} — {d['example']}.</p>
            <ol>
            <li>Confirm scan is image-only — text does not select</li>
            <li><a href="/pdf/ocrpdf">OCR PDF</a> — choose language matching source</li>
            <li>Spot-check 3 random pages — numbers and names accurate</li>
            <li><a href="/pdf/compress">Compress</a> only after OCR if upload cap requires</li>
            <li>Redact PHI/PII/CUI before external share</li>
            </ol>
            <p>Pair with <a href="{d['related']}">compress workflow</a> · <a href="{d['merge_related']}">merge workflow</a> · <a href="/guides/make-scanned-pdf-searchable">Searchable scan hub</a>.</p>
            """,
    )


W55_DEEP = {
    "fix-pdf-bookmarks-missing": _d("fix-pdf-bookmarks-missing", """
            <h2>Restore PDF bookmarks</h2>
            <ol>
            <li>Open in editor — check if outline panel is empty vs hidden</li>
            <li>Recreate chapter headings as bookmark targets</li>
            <li>Nested bookmarks for sections — max 3 levels for screen readers</li>
            <li>Export and verify in Adobe Reader outline panel</li>
            </ol>
            <p><a href="/guides/pdf-bookmarks-guide">Bookmarks guide</a> · <a href="/guides/pdf-table-of-contents">TOC workflow</a>.</p>
            """),
    "pdf-cloud-archive-vs-on-prem": _d("pdf-cloud-archive-vs-on-prem", """
            <h2>Cloud vs on-prem archive</h2>
            <table class="table table-sm">
            <tr><th>Factor</th><th>Cloud (S3/Glacier)</th><th>On-prem WORM</th></tr>
            <tr><td>CapEx</td><td>Low — pay per GB</td><td>High — hardware refresh</td></tr>
            <tr><td>Compliance</td><td>Shared responsibility + BAA</td><td>Air-gap possible</td></tr>
            <tr><td>Legal hold</td><td>Object lock + lifecycle pause</td><td>Immutable NAS</td></tr>
            </table>
            <p><a href="/guides/pdf-worm-storage-compliance">WORM compliance</a> · <a href="/guides/pdf-email-archive-migration">Email archive migration</a>.</p>
            """),
    "cad-to-pdf": _d("cad-to-pdf", """
            <h2>CAD to PDF workflow</h2>
            <ol>
            <li>Plot from AutoCAD/Revit — PDF/A or high-res vector</li>
            <li>Embed fonts — check title block legibility at 100% zoom</li>
            <li><a href="/pdf/merge">Merge</a> sheet set into single submittal PDF</li>
            <li><a href="/pdf/compress">Compress</a> only if portal cap requires — avoid rasterizing vectors</li>
            </ol>
            <p><a href="/guides/merge-pdf-for-architects">Architect merge</a> · <a href="/guides/merge-pdf-for-engineers">Engineer merge</a>.</p>
            """),
}

for key in W55_OCR_FOR_META:
    W55_DEEP[f"ocr-pdf-for-{key}"] = _ocr_for_deep(f"ocr-pdf-for-{key}")

W55_CREATE_CLUSTER = """
            <h2>CREATE batch 19 — OCR vertical guides</h2>
            <ul>
            <li>Workflow: <a href="/guides/fix-pdf-bookmarks-missing">Fix bookmarks</a> · <a href="/guides/pdf-cloud-archive-vs-on-prem">Cloud vs on-prem</a> · <a href="/guides/cad-to-pdf">CAD to PDF</a></li>
            <li>Legal &amp; finance: <a href="/guides/ocr-pdf-for-lawyers">Lawyers</a> · <a href="/guides/ocr-pdf-for-accountants">Accountants</a> · <a href="/guides/ocr-pdf-for-insurance">Insurance</a></li>
            <li>Regulated: <a href="/guides/ocr-pdf-for-healthcare">Healthcare</a> · <a href="/guides/ocr-pdf-for-government">Government</a> · <a href="/guides/ocr-pdf-for-nonprofits">Nonprofits</a></li>
            <li>Built world: <a href="/guides/ocr-pdf-for-architects">Architects</a> · <a href="/guides/ocr-pdf-for-engineers">Engineers</a> · <a href="/guides/ocr-pdf-for-real-estate">Real estate</a></li>
            <li>Knowledge work: <a href="/guides/ocr-pdf-for-researchers">Researchers</a> · <a href="/guides/ocr-pdf-for-journalists">Journalists</a> · <a href="/guides/ocr-pdf-for-consultants">Consultants</a></li>
            </ul>
            <p>OCR hub: <a href="/guides/ocr-pdf">OCR PDF guide</a> · <a href="/guides/make-scanned-pdf-searchable">Make scanned PDF searchable</a></p>
            """

W55_OCR_CLUSTER = """
            <h2>OCR for industry verticals (14 personas)</h2>
            <p>Legal: <a href="/guides/ocr-pdf-for-lawyers">Lawyers</a> · <a href="/guides/ocr-pdf-for-insurance">Insurance</a> · <a href="/guides/ocr-pdf-for-government">Government</a></p>
            <p>Finance &amp; ops: <a href="/guides/ocr-pdf-for-accountants">Accountants</a> · <a href="/guides/ocr-pdf-for-freelancers">Freelancers</a> · <a href="/guides/ocr-pdf-for-consultants">Consultants</a></p>
            <p>Education &amp; research: <a href="/guides/ocr-pdf-for-education">Education</a> · <a href="/guides/ocr-pdf-for-researchers">Researchers</a> · <a href="/guides/ocr-pdf-for-journalists">Journalists</a></p>
            """

W55_COMPRESS_TOPUP = """
            <h2>OCR vertical checklist</h2>
            <ol>
            <li>OCR before compress on scanned docs — compression can blur text layer</li>
            <li>Spot-check numbers, dates, and proper nouns on 3 pages</li>
            <li>Redact before OCR when source contains PHI/PII you will not need</li>
            <li>Keep image-only master — OCR output is a derivative copy</li>
            </ol>
            """

W55_CLOSING = """
            <h2>Related guides</h2>
            <p>Wave 55 launches fourteen OCR-for-vertical guides plus bookmarks, cloud archive, and CAD-to-PDF — CREATE batch 19 of 450.</p>
            <p>Hub: <a href="/guides/ocr-pdf">OCR PDF</a> · CREATE remaining: 127</p>
            """
