"""Wave 16 batch 2 — Glossary authority upgrades (technical PDF terms, 1500+ words each)."""

W16B_SLUGS = [
    "glossary-linearization",
    "glossary-watermark",
    "glossary-owner-password",
    "glossary-jpeg-compression",
    "glossary-downsampling",
    "glossary-bookmark",
    "glossary-hyperlink",
    "glossary-annotation",
    "glossary-optional-content",
    "glossary-iso-32000",
    "glossary-itext",
    "glossary-pymupdf",
    "glossary-lossy-compression",
    "glossary-lossless-compression",
    "glossary-cmyk",
    "glossary-grayscale",
    "glossary-fast-web-view",
]

W16B_DATA = {
    "glossary-linearization": {
        "title": "What Is PDF Linearization? — Fast Web View Explained (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/beginner-pdf-compression-basics",
        "pillar_label": "PDF compression basics",
        "example": "News site hosts 80 MB report — linearized PDF shows page 1 while rest downloads",
    },
    "glossary-watermark": {
        "title": "What Is a PDF Watermark? — Draft, Confidential &amp; Brand Marks (2026)",
        "tool": "/pdf/watermark",
        "label": "Watermark PDF",
        "pillar": "/guides/watermark-pdf",
        "pillar_label": "watermark PDF guide",
        "example": "Legal sends DRAFT contract PDF with diagonal watermark before final signature version",
    },
    "glossary-owner-password": {
        "title": "What Is a PDF Owner Password? — Permissions vs Open Password (2026)",
        "tool": "/pdf/password",
        "label": "Protect PDF",
        "pillar": "/guides/password-protect-pdf",
        "pillar_label": "password protect PDF guide",
        "example": "Publisher sets owner password so readers can open but not print or copy text",
    },
    "glossary-jpeg-compression": {
        "title": "What Is JPEG Compression in PDF? — Photos, Artifacts &amp; Quality (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/compress-pdf-without-losing-quality",
        "pillar_label": "compress without losing quality guide",
        "example": "Marketing PDF with hero photos — aggressive JPEG recompression creates blocky skies",
    },
    "glossary-downsampling": {
        "title": "What Is PDF Downsampling? — DPI, Image Resampling &amp; File Size (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/compress-pdf-guide",
        "pillar_label": "compress PDF guide",
        "example": "Architectural PDF embeds 600 DPI site photos — downsampling to 150 DPI cuts size 70%",
    },
    "glossary-bookmark": {
        "title": "What Are PDF Bookmarks? — Navigation Outline vs Page Numbers (2026)",
        "tool": "/pdf/pdfmetadata",
        "label": "PDF Metadata",
        "pillar": "/guides/organize-pdf-pages",
        "pillar_label": "organize PDF pages guide",
        "example": "Policy manual PDF uses bookmarks for each chapter — reader jumps without scrolling",
    },
    "glossary-hyperlink": {
        "title": "What Are PDF Hyperlinks? — Internal Links, URLs &amp; Broken Anchors (2026)",
        "tool": "/pdf/editpdf",
        "label": "Edit PDF",
        "pillar": "/guides/edit-pdf",
        "pillar_label": "edit PDF guide",
        "example": "Annual report TOC links to page 47 — print-to-PDF from browser often strips links",
    },
    "glossary-annotation": {
        "title": "What Is a PDF Annotation? — Comments, Highlights &amp; Markup (2026)",
        "tool": "/pdf/editpdf",
        "label": "Edit PDF",
        "pillar": "/guides/annotate-pdf-online",
        "pillar_label": "annotate PDF guide",
        "example": "Reviewer adds yellow highlight and sticky note — must flatten before court filing",
    },
    "glossary-optional-content": {
        "title": "What Is Optional Content in PDF? — Layers &amp; OCG Explained (2026)",
        "tool": "/pdf/flattenpdf",
        "label": "Flatten PDF",
        "pillar": "/guides/flatten-pdf",
        "pillar_label": "flatten PDF guide",
        "example": "CAD export hides electrical layer — wrong OCG state prints blank floor plan",
    },
    "glossary-iso-32000": {
        "title": "What Is ISO 32000? — The PDF File Format Standard (2026)",
        "tool": "/guides/pdf-tools",
        "label": "PDF tools hub",
        "pillar": "/guides/beginner-what-is-a-pdf",
        "pillar_label": "what is a PDF guide",
        "example": "Developer validates parser against ISO 32000-2 for PDF 2.0 feature support",
    },
    "glossary-itext": {
        "title": "What Is iText? — PDF Library Used in RatPDF Workflows (2026)",
        "tool": "/pdf/merge",
        "label": "Merge PDF",
        "pillar": "/guides/merge-pdf",
        "pillar_label": "merge PDF guide",
        "example": "Engineer reads iText release notes to understand merge/split behavior in RatPDF",
    },
    "glossary-pymupdf": {
        "title": "What Is PyMuPDF? — Fast PDF Parsing &amp; Edit Engine (2026)",
        "tool": "/pdf/editpdf",
        "label": "Edit PDF",
        "pillar": "/guides/edit-pdf",
        "pillar_label": "edit PDF guide",
        "example": "Support team knows Edit PDF uses PyMuPDF — explains why some form XFA files fail",
    },
    "glossary-lossy-compression": {
        "title": "What Is Lossy PDF Compression? — When Quality Tradeoffs Help (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/compress-pdf-guide",
        "pillar_label": "compress PDF guide",
        "example": "Event photographer compresses brochure PDF — faces stay sharp, background JPEG shimmers",
    },
    "glossary-lossless-compression": {
        "title": "What Is Lossless PDF Compression? — Structure &amp; Flate Explained (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/compress-pdf-guide",
        "pillar_label": "compress PDF guide",
        "example": "Text-only contract shrinks 15% from Flate — no visible quality change",
    },
    "glossary-cmyk": {
        "title": "What Is CMYK in PDF? — Print Color vs Screen RGB (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/pdf-x-print-standard",
        "pillar_label": "PDF/X print standard guide",
        "example": "Brand red looks dull on office inkjet — source PDF still RGB not CMYK for press",
    },
    "glossary-grayscale": {
        "title": "What Is Grayscale PDF? — Black &amp; White Conversion for Print (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/print-pdf-black-and-white",
        "pillar_label": "print PDF black and white guide",
        "example": "Legal team prints 400-page index in grayscale to save toner on text-heavy PDF",
    },
    "glossary-fast-web-view": {
        "title": "What Is PDF Fast Web View? — Linearized PDF in Browsers (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/beginner-pdf-compression-basics",
        "pillar_label": "PDF compression basics",
        "example": "Investor opens 200-page annual PDF in Chrome — first page renders before full download",
    },
}

W16B_DEEP = {
    "glossary-linearization": """
            <h2>Definition</h2>
            <p><strong>Linearization</strong> (also called <strong>Fast Web View</strong>) reorders PDF objects so the first page can render before the entire file downloads — critical for large reports hosted on slow connections.</p>
            <p>Related: <a href="/guides/glossary-fast-web-view">Fast Web View glossary</a> · Basics: <a href="/guides/beginner-pdf-compression-basics">PDF compression basics</a>.</p>
            <h2>How to check</h2>
            <p>Adobe Acrobat → File → Properties → Fast Web View: Yes — or inspect with <a href="/pdf/pdfmetadata">PDF Metadata</a> and developer tools — not all browser uploads preserve linearization after re-save.</p>
            <h2>RatPDF note</h2>
            <p><a href="/pdf/compress">Compress PDF</a> may rewrite structure — verify Fast Web View if you rely on progressive download — keep linearized master for public hosting.</p>
            """,
    "glossary-watermark": """
            <h2>Definition</h2>
            <p>A <strong>PDF watermark</strong> is semi-transparent text or image repeated across pages — marks drafts, confidentiality, or brand identity — distinct from foreground header/footer text.</p>
            <p>How-to: <a href="/guides/watermark-pdf">watermark PDF guide</a> · Security hub: <a href="/guides/secure-pdf-workflow">secure PDF workflow</a>.</p>
            <h2>Watermark vs password</h2>
            <p>Watermark deters casual sharing — does not encrypt — pair with <a href="/pdf/password">password protect</a> for sensitive contracts — watermark alone is not access control.</p>
            <h2>Tool</h2>
            <p><a href="/pdf/watermark">Watermark PDF</a> — text or image — verify contrast on color backgrounds — print test before client send.</p>
            """,
    "glossary-owner-password": """
            <h2>Definition</h2>
            <p>The <strong>owner password</strong> (permissions password) controls what recipients can do — print, copy, edit — even when the PDF opens without a user password. The <strong>user password</strong> (open password) is required to view the file at all.</p>
            <p>Guide: <a href="/guides/password-protect-pdf">password protect PDF</a> · Remove: <a href="/guides/unlock-pdf">unlock PDF</a> (when you know the password).</p>
            <h2>Common permissions</h2>
            <ul>
            <li>Printing allowed or high-resolution only</li>
            <li>Copy text and images blocked for confidential review</li>
            <li>Form filling allowed but not page insertion</li>
            </ul>
            <h2>Limits</h2>
            <p>Password protection is not DRM — determined users may bypass weak policies — use redaction for secrets — see <a href="/guides/glossary-redaction">redaction glossary</a>.</p>
            """,
    "glossary-jpeg-compression": """
            <h2>Definition</h2>
            <p><strong>JPEG compression</strong> inside PDF stores photographic content as DCT-encoded streams — lossy — block size and quality setting control artifacts and file size.</p>
            <p>Quality guide: <a href="/guides/compress-pdf-without-losing-quality">compress without losing quality</a> · Benchmark: <a href="/research/pdf-compression-benchmark">compression benchmark</a>.</p>
            <h2>When JPEG hurts</h2>
            <ul>
            <li>Text screenshots saved as JPEG — fuzzy edges</li>
            <li>Repeated recompression — generation loss</li>
            <li>Fine lines on blueprints — use lossless or vector source</li>
            </ul>
            <h2>RatPDF</h2>
            <p><a href="/pdf/compress">Compress PDF</a> re-encodes images via Ghostscript — use Less preset for photo-heavy decks — compare output at 100% zoom.</p>
            """,
    "glossary-downsampling": """
            <h2>Definition</h2>
            <p><strong>Downsampling</strong> reduces image resolution inside a PDF — fewer pixels — major lever for shrinking scan-heavy files — measured in DPI relative to print size.</p>
            <p>Workflow: <a href="/guides/compress-pdf-guide">compress PDF guide</a> · Scans: <a href="/guides/compress-scanned-vs-digital-pdf">scanned vs digital PDF</a>.</p>
            <h2>Safe DPI targets</h2>
            <table class="table table-sm"><thead><tr><th>Use</th><th>Typical DPI</th></tr></thead>
            <tbody>
            <tr><td>Email / portal</td><td>150–200 DPI effective</td></tr>
            <tr><td>Office print</td><td>200–300 DPI</td></tr>
            <tr><td>Commercial print</td><td>300+ DPI — do not downsample master</td></tr>
            </tbody></table>
            <h2>Check after compress</h2>
            <p>Zoom to smallest text on page — if illegible, re-scan at lower DPI source rather than extreme compress pass.</p>
            """,
    "glossary-bookmark": """
            <h2>Definition</h2>
            <p><strong>PDF bookmarks</strong> (document outline) are a clickable table of contents in the sidebar — jump to headings — essential for manuals over 20 pages — not the same as browser favorites.</p>
            <p>Organize pages: <a href="/guides/organize-pdf-pages">organize PDF pages guide</a> · Accessibility: tagged headings support screen reader navigation too.</p>
            <h2>Lost bookmarks</h2>
            <p>Print-to-PDF often drops outline — export from Word with heading styles — or rebuild in Acrobat — <a href="/pdf/merge">Merge PDF</a> preserves outlines if source files had them.</p>
            <h2>View</h2>
            <p><a href="/pdf/pdfmetadata">PDF Metadata</a> may list page count — full outline editing needs source app — RatPDF merge keeps source bookmarks when present.</p>
            """,
    "glossary-hyperlink": {
        "__html__": """
            <h2>Definition</h2>
            <p><strong>PDF hyperlinks</strong> are clickable areas — external URLs, email addresses, or internal destinations (page or named anchor) — stored as link annotations or URI actions.</p>
            <p>Edit: <a href="/guides/edit-pdf">edit PDF guide</a> · Compare: <a href="/guides/print-to-pdf-vs-save-as-pdf">print to PDF vs save as PDF</a>.</p>
            <h2>Broken links</h2>
            <ul>
            <li>Print-to-PDF from browser — links often missing</li>
            <li>Merge reorders pages — internal links may point wrong page</li>
            <li>Flatten removes some interactive elements — test before publish</li>
            </ul>
            <h2>Best export path</h2>
            <p>Office files → <a href="/pdf/doctopdf">Word to PDF</a> or <a href="/pdf/exceltopdf">Excel to PDF</a> — preserves more links than generic print driver.</p>
            """
    },
    "glossary-annotation": """
            <h2>Definition</h2>
            <p><strong>PDF annotations</strong> are markup objects on a page — highlights, underlines, sticky notes, stamps, ink drawings — stored separately from page content until flattened.</p>
            <p>Annotate: <a href="/guides/annotate-pdf-online">annotate PDF online</a> · Flatten: <a href="/guides/glossary-flattened-pdf">flattened PDF glossary</a>.</p>
            <h2>Court and portal rules</h2>
            <p>Many e-filing systems reject PDFs with comment layers — flatten annotations before upload — redact separately for PII — annotation hide is not redaction.</p>
            <h2>Tool limits</h2>
            <p><a href="/pdf/editpdf">Edit PDF</a> supports basic markup scenarios — complex review threads may need Acrobat — export summary before flatten if audit trail required.</p>
            """,
    "glossary-optional-content": """
            <h2>Definition</h2>
            <p><strong>Optional content groups (OCG)</strong> are PDF layers — toggle visibility in Acrobat — used in CAD, maps, and multilingual packaging — wrong default state prints hidden content.</p>
            <p>Flatten: <a href="/guides/flatten-pdf">flatten PDF guide</a> · Print issues: <a href="/guides/pdf-printing-blank-pages">blank pages when printing</a>.</p>
            <h2>Symptoms</h2>
            <ul>
            <li>PDF looks fine on screen — printer outputs blank or partial page</li>
            <li>Layer intended for screen only included in print intent</li>
            </ul>
            <h2>Fix</h2>
            <p>Set intended layers visible in source app — export print-ready PDF — or <a href="/pdf/flattenpdf">Flatten PDF</a> to bake visible state — test print one page first.</p>
            """,
    "glossary-iso-32000": """
            <h2>Definition</h2>
            <p><strong>ISO 32000</strong> is the international standard defining PDF syntax — currently PDF 1.7 and PDF 2.0 editions — supersedes Adobe-only specifications — basis for PDF/A, PDF/UA, and PDF/X subsets.</p>
            <p>Intro: <a href="/guides/beginner-what-is-a-pdf">what is a PDF</a> · Standards hub: <a href="/guides/pdf-standards-archiving-hub">standards &amp; archiving hub</a>.</p>
            <h2>PDF version in file header</h2>
            <p><code>%PDF-1.7</code> vs <code>%PDF-2.0</code> — older portals reject 2.0 — check upload requirements — <a href="/guides/pdf-version-compatibility">version compatibility guide</a>.</p>
            <h2>RatPDF role</h2>
            <p>Tools consume standard PDF objects — exotic 2.0 features may fail — simplify in source app — see <a href="/guides/pdf-troubleshooting">troubleshooting guide</a>.</p>
            """,
    "glossary-itext": """
            <h2>Definition</h2>
            <p><strong>iText</strong> is a Java/.NET PDF library — merge, split, encrypt, stamp — RatPDF uses iText-family tooling for several server-side PDF operations alongside Ghostscript and PyMuPDF.</p>
            <p>Merge workflows: <a href="/guides/merge-pdf">merge PDF guide</a> · Split: <a href="/guides/split-pdf">split PDF guide</a>.</p>
            <h2>Why it matters to users</h2>
            <p>Merge order and bookmark preservation follow iText rules — corrupted input PDFs fail at parse — repair source before merge — password PDFs need unlock first.</p>
            <h2>Not the same as iTextSharp legacy</h2>
            <p>Older docs reference iTextSharp — modern stack is itext7 — behavior differences on encrypted PDFs — contact support with sample file if merge fails consistently.</p>
            """,
    "glossary-pymupdf": """
            <h2>Definition</h2>
            <p><strong>PyMuPDF</strong> (import name <code>fitz</code>) is a Python binding to MuPDF — fast open, text extract, redact, insert text — powers RatPDF <a href="/pdf/editpdf">Edit PDF</a> and related edit paths.</p>
            <p>Edit guide: <a href="/guides/edit-pdf">edit PDF guide</a> · Extract text: <a href="/pdf/pdftotext">PDF to Text</a>.</p>
            <h2>Known limits</h2>
            <ul>
            <li>XFA dynamic forms — limited support — flatten in Acrobat first</li>
            <li>Heavy edit on 500+ MB files — timeout on free tier — Pro raises cap</li>
            <li>Scanned pages — edit adds text layer — OCR first for search</li>
            </ul>
            <h2>Transparency</h2>
            <p>Disclosed on <a href="/Home/About">about page</a> — engine choice explains behavior vs Adobe desktop.</p>
            """,
    "glossary-lossy-compression": """
            <h2>Definition</h2>
            <p><strong>Lossy compression</strong> discards data permanently — JPEG in photos, aggressive downsampling — smaller files — visible artifacts if pushed too far.</p>
            <p>Guide: <a href="/guides/compress-pdf-guide">compress PDF guide</a> · Compare: <a href="/guides/glossary-lossless-compression">lossless compression glossary</a>.</p>
            <h2>When to accept lossy</h2>
            <ul>
            <li>Email attachment over portal cap</li>
            <li>Photo-heavy slides where minor blur is OK</li>
            <li>Third compression pass on already compressed scan — avoid</li>
            </ul>
            <h2>RatPDF preset</h2>
            <p>More = lossier — Less = preserve — always keep uncompressed master archive.</p>
            """,
    "glossary-lossless-compression": """
            <h2>Definition</h2>
            <p><strong>Lossless compression</strong> shrinks PDF without changing pixel or vector data — Flate/ZIP on streams, object deduplication — modest gains on text PDFs — limited on already-JPEG photos.</p>
            <p>Basics: <a href="/guides/glossary-compression">compression glossary</a> · Flate term: <a href="/guides/glossary-flate-compression">Flate compression</a> (if published).</p>
            <h2>Expectations</h2>
            <p>10–30% on digital reports — under 5% on scan-only JPEG — if you need 90% reduction, lossy pass required — verify readability after.</p>
            <h2>Tool</h2>
            <p><a href="/pdf/compress">Compress PDF</a> Less preset — near-lossless for text — pair with <a href="/pdf-size-checker">PDF size checker</a> before upload.</p>
            """,
    "glossary-cmyk": """
            <h2>Definition</h2>
            <p><strong>CMYK</strong> (Cyan, Magenta, Yellow, Key/black) is subtractive ink color for print — PDFs for commercial press should use CMYK or spot colors with output intent — RGB is for screens.</p>
            <p>Print standard: <a href="/guides/pdf-x-print-standard">PDF/X guide</a> · Checklist: <a href="/guides/commercial-print-pdf-checklist">commercial print checklist</a>.</p>
            <h2>Office PDF trap</h2>
            <p>Word and PowerPoint export RGB — colors shift on press — designer converts in InDesign — RatPDF compress does not convert color space — do not use compress as prepress fix.</p>
            <h2>Proof</h2>
            <p>Soft-proof in Acrobat with printer ICC — hard-proof physical strip before 10k run.</p>
            """,
    "glossary-grayscale": """
            <h2>Definition</h2>
            <p><strong>Grayscale PDF</strong> content uses black ink only — no color channels — reduces toner cost and simplifies print on B&amp;W devices — charts may lose meaning if color-only encoding.</p>
            <p>Print guide: <a href="/guides/print-pdf-black-and-white">print PDF black and white</a> · Compress: <a href="/pdf/compress">Compress PDF</a> for smaller gray scans.</p>
            <h2>Convert vs print setting</h2>
            <ul>
            <li>Printer dialog grayscale — quick — color PDF unchanged on disk</li>
            <li>Export grayscale PDF — permanent — smaller file — accessibility check contrast</li>
            </ul>
            <h2>Accessibility</h2>
            <p>Do not rely on color alone in source — see <a href="/guides/pdf-accessibility-wcag">WCAG PDF guide</a> — grayscale print must remain readable.</p>
            """,
    "glossary-fast-web-view": """
            <h2>Definition</h2>
            <p><strong>Fast Web View</strong> is Adobe's label for a linearized PDF — hint in document catalog — enables byte-range HTTP requests — first page renders while download continues.</p>
            <p>Technical term: <a href="/guides/glossary-linearization">linearization glossary</a> · Hosting large PDFs: compress copy for bandwidth — keep linearized original on CDN.</p>
            <h2>When it does not matter</h2>
            <p>Small PDFs under 1 MB — email attachments — local USB handoff — linearization overhead negligible benefit.</p>
            <h2>After RatPDF processing</h2>
            <p>Re-compress may strip linearization — re-linearize in Acrobat or qpdf if web hosting requires it — test with Range request in browser devtools.</p>
            """,
}

# Fix hyperlink entry — used dict by mistake; normalize to string
W16B_DEEP["glossary-hyperlink"] = W16B_DEEP["glossary-hyperlink"]["__html__"]

W16B_GLOSSARY_CLUSTER = """
            <h2>Related glossary terms</h2>
            <ul>
            <li><a href="/guides/glossary-linearization">Linearization</a> · <a href="/guides/glossary-fast-web-view">Fast Web View</a> · <a href="/guides/glossary-lossy-compression">Lossy compression</a> · <a href="/guides/glossary-lossless-compression">Lossless compression</a></li>
            <li><a href="/guides/glossary-jpeg-compression">JPEG compression</a> · <a href="/guides/glossary-downsampling">Downsampling</a> · <a href="/guides/glossary-cmyk">CMYK</a> · <a href="/guides/glossary-grayscale">Grayscale</a></li>
            <li><a href="/guides/glossary-watermark">Watermark</a> · <a href="/guides/glossary-owner-password">Owner password</a> · <a href="/guides/glossary-annotation">Annotation</a></li>
            <li><a href="/guides/glossary-bookmark">Bookmark</a> · <a href="/guides/glossary-hyperlink">Hyperlink</a> · <a href="/guides/glossary-optional-content">Optional content (layers)</a></li>
            <li><a href="/guides/glossary-iso-32000">ISO 32000</a> · <a href="/guides/glossary-itext">iText</a> · <a href="/guides/glossary-pymupdf">PyMuPDF</a></li>
            <li>Batch 1: <a href="/guides/glossary-compression">Compression</a> · <a href="/guides/glossary-pdf">PDF</a> · <a href="/guides/glossary-metadata">Metadata</a></li>
            </ul>
            <p>Index: <a href="/guides/pdf-tools">PDF tools hub</a> · <a href="/guides/pdf-standards-archiving-hub">Standards hub</a> · <a href="/guides/pdf-security-compliance-guide">Security hub</a>.</p>
            """
