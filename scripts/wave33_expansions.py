"""Wave 33 — Glossary authority batch 10 (17 terms)."""

W33_SLUGS = [
    "glossary-jbig2",
    "glossary-job-queue",
    "glossary-layers",
    "glossary-libreoffice-headless",
    "glossary-linearized",
    "glossary-linearized-pdf",
    "glossary-marked-content",
    "glossary-media-box",
    "glossary-monochrome",
    "glossary-mrc-compression",
    "glossary-object-stream",
    "glossary-opentype",
    "glossary-optical-character-recognition",
    "glossary-page-box",
    "glossary-pdf-17",
    "glossary-pdf-20",
    "glossary-pdf-package",
]

GLOSSARY_SLUGS = set(W33_SLUGS)

W33_DATA = {
    "glossary-jbig2": {
        "title": "What Is JBIG2 in PDF? — Bilevel Scan Compression (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/glossary-compression",
        "pillar_label": "compression glossary",
        "related": "/guides/glossary-flate-compression",
        "example": "Fax archive PDF shrinks 70% with JBIG2 — lossy mode blurs one stray digit on stamp",
    },
    "glossary-job-queue": {
        "title": "What Is a PDF Job Queue? — Batch Processing &amp; Server Order (2026)",
        "tool": "/guides/pdf-tools",
        "label": "PDF tools hub",
        "pillar": "/guides/glossary-ghostscript",
        "pillar_label": "Ghostscript glossary",
        "related": "/guides/glossary-libreoffice-headless",
        "example": "Ops queues 200 merge jobs overnight — FIFO order prevents OOM when compress runs parallel",
    },
    "glossary-layers": {
        "title": "What Are PDF Layers? — Optional Content Groups (OCG) (2026)",
        "tool": "/pdf/editpdf",
        "label": "Edit PDF",
        "pillar": "/guides/glossary-marked-content",
        "pillar_label": "marked content glossary",
        "related": "/guides/glossary-pdf",
        "example": "CAD export PDF — user toggles electrical layer off in Acrobat — flatten before print shop handoff",
    },
    "glossary-libreoffice-headless": {
        "title": "What Is LibreOffice Headless PDF Export? — CLI Batch Convert (2026)",
        "tool": "/pdf/doctopdf",
        "label": "Word to PDF",
        "pillar": "/guides/glossary-impress-export",
        "pillar_label": "Impress export glossary",
        "related": "/guides/glossary-ghostscript",
        "example": "Cron job runs soffice --headless --convert-to pdf on 500 ODT contracts — no GUI on Ubuntu server",
    },
    "glossary-linearized": {
        "title": "What Is Linearized PDF? — Fast Web View Hint Table (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/glossary-linearized-pdf",
        "pillar_label": "linearized PDF glossary",
        "related": "/guides/glossary-cross-reference-table",
        "example": "CDN serves 80-page handbook — linearized hint loads page 1 before full xref parse completes",
    },
    "glossary-linearized-pdf": {
        "title": "What Is a Linearized PDF File? — Web Optimized Structure (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/glossary-fast-web-view",
        "pillar_label": "fast web view glossary",
        "related": "/guides/glossary-linearized",
        "example": "Developer enables Fast Web View on export — browser inline viewer shows first page 2s faster on 4G",
    },
    "glossary-marked-content": {
        "title": "What Is Marked Content in PDF? — BMC, BDC &amp; Tagging (2026)",
        "tool": "/pdf/ocrpdf",
        "label": "OCR PDF",
        "pillar": "/guides/beginner-pdf-tags-accessibility",
        "pillar_label": "PDF tags accessibility",
        "related": "/guides/glossary-layers",
        "example": "Accessibility audit finds untagged body text — marked content sequences missing for screen reader",
    },
    "glossary-media-box": {
        "title": "What Is the Media Box in PDF? — Physical Page Size (2026)",
        "tool": "/pdf/crop",
        "label": "Crop PDF",
        "pillar": "/guides/glossary-crop-box",
        "pillar_label": "crop box glossary",
        "related": "/guides/glossary-page-box",
        "example": "Print vendor reports A4 media box but Letter crop — white strip on laser output",
    },
    "glossary-monochrome": {
        "title": "What Is Monochrome in PDF Scans? — 1-Bit &amp; Grayscale (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/glossary-dpi",
        "pillar_label": "DPI glossary",
        "related": "/guides/glossary-jbig2",
        "example": "Clerk scans text deeds as 1-bit monochrome — PDF half size of 24-bit color phone photo scan",
    },
    "glossary-mrc-compression": {
        "title": "What Is MRC Compression in PDF? — Mixed Raster Content (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/glossary-compression",
        "pillar_label": "compression glossary",
        "related": "/guides/compress-scanned-vs-digital-pdf",
        "example": "Scanner MRC splits text layer from background — compress shrinks magazine scan without blurring headlines",
    },
    "glossary-object-stream": {
        "title": "What Is a PDF Object Stream? — PDF 1.5+ Packing (2026)",
        "tool": "/pdf/repair",
        "label": "Repair PDF",
        "pillar": "/guides/glossary-cross-reference-table",
        "pillar_label": "cross-reference table glossary",
        "related": "/guides/glossary-incremental-update",
        "example": "PDF 1.7 file smaller than 1.4 sibling — objects packed in ObjStm — repair tool must decode stream",
    },
    "glossary-opentype": {
        "title": "What Is OpenType in PDF? — CFF &amp; TTF Embedding (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/glossary-font-embedding",
        "pillar_label": "font embedding glossary",
        "related": "/guides/glossary-full-embedding",
        "example": "Brand PDF uses OpenType CFF — subset embed works — recipient sees correct logo font on mobile",
    },
    "glossary-optical-character-recognition": {
        "title": "What Is Optical Character Recognition (OCR) in PDF? — Searchable Scans (2026)",
        "tool": "/pdf/ocrpdf",
        "label": "OCR PDF",
        "pillar": "/guides/glossary-ocr",
        "pillar_label": "OCR glossary",
        "related": "/guides/how-to-ocr-a-scanned-pdf",
        "example": "Legal team OCRs 1990s discovery PDFs — Ctrl+F finds witness name across 4,000 pages",
    },
    "glossary-page-box": {
        "title": "What Is a PDF Page Box? — Media, Crop, Bleed, Trim, Art (2026)",
        "tool": "/pdf/crop",
        "label": "Crop PDF",
        "pillar": "/guides/glossary-media-box",
        "pillar_label": "media box glossary",
        "related": "/guides/glossary-crop-box",
        "example": "Designer confusion — trim box for print, crop box for screen — wrong box clips footer in viewer",
    },
    "glossary-pdf-17": {
        "title": "What Is PDF 1.7? — ISO 32000-1 Standard Version (2026)",
        "tool": "/pdf/pdfmetadata",
        "label": "PDF Metadata",
        "pillar": "/guides/glossary-iso-32000",
        "pillar_label": "ISO 32000 glossary",
        "related": "/guides/glossary-pdf-20",
        "example": "Archive policy requires PDF 1.7 max — reject 2.0-only features from experimental exporter",
    },
    "glossary-pdf-20": {
        "title": "What Is PDF 2.0? — ISO 32000-2 Features &amp; Compatibility (2026)",
        "tool": "/pdf/pdfmetadata",
        "label": "PDF Metadata",
        "pillar": "/guides/glossary-pdf-17",
        "pillar_label": "PDF 1.7 glossary",
        "related": "/guides/glossary-iso-32000",
        "example": "Security spec mandates AES-256 — PDF 2.0 encryption profile — legacy readers need 1.7 fallback copy",
    },
    "glossary-pdf-package": {
        "title": "What Is a PDF Package? — Embedded Files Collection (2026)",
        "tool": "/pdf/merge",
        "label": "Merge PDF",
        "pillar": "/guides/glossary-embedded-files",
        "pillar_label": "embedded files glossary",
        "related": "/guides/glossary-pdf-portfolio",
        "example": "Engineering deliverable PDF package — drawing PDF plus BOM XLSX and spec DOCX in one envelope",
    },
}

W33_DEEP = {
    "glossary-jbig2": """
            <h2>Definition</h2>
            <p><strong>JBIG2</strong> compresses bilevel (black-and-white) images in PDF — common on fax and text-only scans — often smaller than CCITT Group 4 — supports lossy symbol matching that can swap similar glyphs.</p>
            <h2>Lossy vs lossless JBIG2</h2>
            <ul>
            <li><strong>Lossless:</strong> safe for legal stamps and account numbers</li>
            <li><strong>Lossy:</strong> smaller — risk 8 vs 6 confusion on digits — always QA critical numbers</li>
            </ul>
            <h2>Workflow</h2>
            <p>Scan monochrome 300 DPI → <a href="/pdf/compress">Compress PDF</a> — if digits blur use Less preset — compare <a href="/guides/glossary-flate-compression">flate</a> · <a href="/guides/glossary-monochrome">monochrome</a> · <a href="/guides/ghostscript-pdf-compression">Ghostscript</a>.</p>
            """,
    "glossary-job-queue": """
            <h2>Definition</h2>
            <p>A <strong>job queue</strong> orders PDF tasks — merge, OCR, compress, convert — FIFO or priority — server-side workers dequeue jobs to cap CPU and memory on batch pipelines.</p>
            <h2>Why queue instead of parallel burst</h2>
            <ul>
            <li>Prevents OOM on 500-page OCR</li>
            <li>Fair tenant limits on SaaS PDF APIs</li>
            <li>Retry failed jobs without blocking whole batch</li>
            <li>Audit log per job id for compliance</li>
            </ul>
            <h2>Browser vs server</h2>
            <p>RatPDF runs single-job in browser — no server queue — enterprise batch uses <a href="/guides/glossary-ghostscript">Ghostscript</a> · <a href="/guides/glossary-libreoffice-headless">LibreOffice headless</a> with external queue — hub: <a href="/guides/pdf-tools">PDF tools</a>.</p>
            """,
    "glossary-layers": """
            <h2>Definition</h2>
            <p><strong>PDF layers (Optional Content Groups, OCG)</strong> let viewers show/hide content — CAD disciplines, language variants, ad comps — without separate files per variant.</p>
            <h2>Flatten before print</h2>
            <p>Print shops may ignore OCG — visible layer at export time only — <a href="/pdf/flattenpdf">Flatten PDF</a> or merge visible layers in source app — accessibility: layers ≠ tags — <a href="/guides/glossary-marked-content">marked content</a>.</p>
            <h2>Related</h2>
            <p><a href="/pdf/editpdf">Edit PDF</a> for simple page work — not full CAD layer editor — <a href="/guides/glossary-pdf">PDF structure</a>.</p>
            """,
    "glossary-libreoffice-headless": """
            <h2>Definition</h2>
            <p><strong>LibreOffice headless</strong> runs <code>soffice --headless --convert-to pdf</code> without GUI — batch DOCX, ODT, ODP to PDF on Linux servers — common in CI and document automation.</p>
            <h2>Typical command</h2>
            <pre class="bg-light p-2 small"><code>soffice --headless --convert-to pdf --outdir /out /in/contract.odt</code></pre>
            <h2>Limits</h2>
            <ul>
            <li>Font substitution if server lacks desktop fonts</li>
            <li>Macro-enabled docs may need policy block</li>
            <li>Concurrent instances need RAM planning</li>
            </ul>
            <p>Slides: <a href="/guides/glossary-impress-export">Impress export</a> · Browser alt: <a href="/pdf/doctopdf">Word to PDF</a> · <a href="/pdf/ppttopdf">PowerPoint to PDF</a> · Queue: <a href="/guides/glossary-job-queue">job queue</a>.</p>
            """,
    "glossary-linearized": """
            <h2>Definition</h2>
            <p><strong>Linearization</strong> reorganises PDF so first page objects appear early in file — hint table points viewer to byte ranges — "Fast Web View" in Acrobat — faster first paint in browser.</p>
            <h2>Not the same as compress</h2>
            <p>Linearized file may be same size or larger — optimises read order not bytes — <a href="/pdf/compress">Compress</a> shrinks images — combine both for web handbooks.</p>
            <h2>Check</h2>
            <p>Acrobat Document Properties → Fast Web View: Yes — repair broken linearization — <a href="/guides/glossary-linearized-pdf">linearized PDF</a> · <a href="/guides/glossary-cross-reference-table">xref</a>.</p>
            """,
    "glossary-linearized-pdf": """
            <h2>Definition</h2>
            <p>A <strong>linearized PDF</strong> is a file structured for progressive download — first page renders while rest transfers — critical for large inline browser viewing on slow links.</p>
            <h2>When it helps</h2>
            <ul>
            <li>Employee handbook 200 MB on intranet</li>
            <li>Public policy PDF on mobile 4G</li>
            <li>CDN range-request friendly hosting</li>
            </ul>
            <h2>When it does not</h2>
            <p>Email attachment downloaded whole — linearization irrelevant — focus <a href="/pdf/compress">compress</a> — glossary: <a href="/guides/glossary-fast-web-view">fast web view</a> · <a href="/guides/glossary-linearized">linearized</a>.</p>
            """,
    "glossary-marked-content": """
            <h2>Definition</h2>
            <p><strong>Marked content</strong> wraps PDF drawing operators in BMC/BDC/EMC sequences — associates property list — foundation for tagged PDF accessibility and some layer visibility.</p>
            <h2>Tagged PDF connection</h2>
            <p>Structure tree references marked-content IDs — screen readers map MCID to paragraphs — untagged scan PDF has no marked content — needs remediation — <a href="/guides/beginner-pdf-tags-accessibility">tags basics</a>.</p>
            <h2>OCR note</h2>
            <p>OCR adds text layer but not full marked-content tags — export accessible Word then PDF for better structure — <a href="/pdf/ocrpdf">OCR PDF</a> · <a href="/guides/tagged-pdf-checklist">tagged checklist</a>.</p>
            """,
    "glossary-media-box": """
            <h2>Definition</h2>
            <p>The <strong>media box</strong> defines full physical page dimensions — largest default boundary — 612×792 pt for US Letter — parent for other page boxes.</p>
            <h2>Box hierarchy</h2>
            <p>Media ≥ bleed ≥ trim ≥ crop ≥ art — mis-set media causes pagination errors in imposition — <a href="/guides/glossary-page-box">page box overview</a> · <a href="/guides/glossary-crop-box">crop box</a> · <a href="/guides/glossary-bleed-box">bleed box</a>.</p>
            <h2>Fix skewed scans</h2>
            <p>Scan smaller than intended page — media box still A4 — white margins — <a href="/pdf/crop">Crop PDF</a> trims visual edges — re-export from layout app for print jobs.</p>
            """,
    "glossary-monochrome": """
            <h2>Definition</h2>
            <p><strong>Monochrome</strong> PDF pages use 1-bit bilevel or 8-bit grayscale — no colour channels — ideal for text documents, deeds, and forms — pairs with JBIG2 or CCITT fax encoders.</p>
            <h2>Scan setting</h2>
            <p>Scanner UI: Black &amp; White or Grayscale — avoid Colour for text-only — 300 DPI monochrome often beats 200 DPI colour for OCR — <a href="/guides/glossary-dpi">DPI guide</a> · <a href="/guides/ocr-accuracy-tips">OCR tips</a>.</p>
            <h2>Compress</h2>
            <p>Monochrome scans compress smaller — <a href="/pdf/compress">Compress PDF</a> — watch lossy JBIG2 on stamps — <a href="/guides/glossary-jbig2">JBIG2</a>.</p>
            """,
    "glossary-mrc-compression": """
            <h2>Definition</h2>
            <p><strong>MRC (Mixed Raster Content)</strong> splits page into foreground text, background, and mask layers — compresses each differently — common in modern scanner drivers and PDF optimisers.</p>
            <h2>Benefits</h2>
            <ul>
            <li>Magazine and newspaper scans — sharp text over photos</li>
            <li>Smaller than flat JPEG whole page</li>
            <li>Better than aggressive single-pass JPEG on mixed content</li>
            </ul>
            <h2>RatPDF context</h2>
            <p>Browser compress uses Ghostscript presets — MRC may already be in source scan — re-scan with MRC driver before upload — <a href="/guides/compress-scanned-vs-digital-pdf">scanned vs digital</a> · <a href="/guides/glossary-compression">compression</a>.</p>
            """,
    "glossary-object-stream": """
            <h2>Definition</h2>
            <p><strong>Object streams (ObjStm)</strong> pack multiple PDF objects into one compressed stream — PDF 1.5+ — reduces file size and xref entries — cross-reference may point into stream offsets.</p>
            <h2>Repair implications</h2>
            <p>Corrupt ObjStm breaks many objects at once — tools must inflate flate stream and parse interior — <a href="/pdf/repair">Repair PDF</a> — backup before repair.</p>
            <h2>Related</h2>
            <p><a href="/guides/glossary-cross-reference-table">xref table</a> · <a href="/guides/glossary-incremental-update">incremental update</a> · <a href="/guides/glossary-pdf-17">PDF 1.7</a>.</p>
            """,
    "glossary-opentype": """
            <h2>Definition</h2>
            <p><strong>OpenType</strong> is a font format (CFF/TrueType outlines) commonly embedded in PDF — supports large glyph sets and Unicode — subset embedding keeps PDF portable.</p>
            <h2>Embedding modes</h2>
            <ul>
            <li><strong>Subset:</strong> only used glyphs — preferred</li>
            <li><strong>Full:</strong> entire font — <a href="/guides/glossary-full-embedding">full embedding</a></li>
            <li><strong>Missing embed:</strong> recipient substitution — <a href="/guides/pdf-fonts-missing">fonts missing</a></li>
            </ul>
            <h2>Compress interaction</h2>
            <p>Compress may re-subset fonts — verify logo glyphs survive — <a href="/pdf/compress">Compress PDF</a> · <a href="/guides/glossary-font-embedding">font embedding</a>.</p>
            """,
    "glossary-optical-character-recognition": """
            <h2>Definition</h2>
            <p><strong>OCR (Optical Character Recognition)</strong> detects text in raster images — adds searchable hidden text layer to PDF — enables copy, find, and extract on scans.</p>
            <h2>Pipeline</h2>
            <ol>
            <li>Scan 300 DPI monochrome or grayscale</li>
            <li>Deskew and crop margins</li>
            <li><a href="/pdf/ocrpdf">OCR PDF</a> — pick correct language</li>
            <li>Spot-check names and numbers</li>
            <li><a href="/pdf/pdftotext">PDF to Text</a> for index export</li>
            </ol>
            <h2>Limits</h2>
            <p>Handwriting, Gothic fonts, tables — expect errors — <a href="/guides/glossary-ocr">OCR glossary</a> · <a href="/guides/tesseract-vs-online-ocr">Tesseract vs online</a> · <a href="/guides/how-to-ocr-a-scanned-pdf">how-to OCR</a>.</p>
            """,
    "glossary-page-box": """
            <h2>Definition</h2>
            <p>PDF defines five <strong>page boxes</strong> — each a rectangle in default user space — control print, view, and bleed:</p>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>Box</th><th>Role</th></tr></thead>
            <tbody>
            <tr><td>Media</td><td>Physical page size — <a href="/guides/glossary-media-box">media box</a></td></tr>
            <tr><td>Crop</td><td>Default viewer clip — <a href="/guides/glossary-crop-box">crop box</a></td></tr>
            <tr><td>Bleed</td><td>Ink beyond trim — <a href="/guides/glossary-bleed-box">bleed box</a></td></tr>
            <tr><td>Trim</td><td>Finished cut size</td></tr>
            <tr><td>Art</td><td>Meaningful content extent</td></tr>
            </tbody></table></div>
            <h2>Debug clipped footer</h2>
            <p>Compare boxes in Acrobat — fix in InDesign export — quick scan trim via <a href="/pdf/crop">Crop PDF</a>.</p>
            """,
    "glossary-pdf-17": """
            <h2>Definition</h2>
            <p><strong>PDF 1.7</strong> (ISO 32000-1:2008) is the long-running baseline — AES-256 extension, object streams, embedded files, 3D — Acrobat X era default — widely supported by viewers.</p>
            <h2>Common features</h2>
            <ul>
            <li>ObjStm and cross-ref streams — <a href="/guides/glossary-object-stream">object stream</a></li>
            <li>Embedded attachments — <a href="/guides/glossary-embedded-files">embedded files</a></li>
            <li>PDF/A-2 based on 1.7</li>
            </ul>
            <h2>Version check</h2>
            <p><a href="/pdf/pdfmetadata">PDF Metadata</a> tool — header <code>%PDF-1.7</code> — upgrade path: <a href="/guides/glossary-pdf-20">PDF 2.0</a> · spec: <a href="/guides/glossary-iso-32000">ISO 32000</a>.</p>
            """,
    "glossary-pdf-20": """
            <h2>Definition</h2>
            <p><strong>PDF 2.0</strong> (ISO 32000-2) refines security, accessibility, and deprecated legacy features — clearer encryption profiles — associated files model — not all free viewers fully implement 2.0 yet.</p>
            <h2>When to use 2.0</h2>
            <ul>
            <li>Greenfield archives mandating latest ISO</li>
            <li>AES-256 as default encryption story</li>
            <li>Strict deprecation of unsafe practices</li>
            </ul>
            <h2>Compatibility fallback</h2>
            <p>Keep PDF 1.7 copy for partners on old readers — test open in target environment — metadata: <a href="/pdf/pdfmetadata">PDF Metadata</a> · prior: <a href="/guides/glossary-pdf-17">PDF 1.7</a> · encrypt: <a href="/guides/pdf-encryption-aes-explained">AES explained</a>.</p>
            """,
    "glossary-pdf-package": """
            <h2>Definition</h2>
            <p>A <strong>PDF package</strong> collects multiple embedded files inside one PDF container — paperclip attachments — not the same as <strong>PDF Portfolio</strong> (Flash-era grid UI) — package is simpler file bundle.</p>
            <h2>Use cases</h2>
            <ul>
            <li>Deliverable ZIP alternative for clients blocking ZIP</li>
            <li>Drawing PDF + calculation spreadsheet</li>
            <li>Clinical study PDF + data CSV</li>
            </ul>
            <h2>Security</h2>
            <p>Recipients may miss hidden attachments — disclose in cover email — scan size on gateway — <a href="/guides/glossary-embedded-files">embedded files</a> · portfolio: <a href="/guides/glossary-pdf-portfolio">PDF portfolio</a> · merge visible pages: <a href="/pdf/merge">Merge PDF</a>.</p>
            """,
}

W33_GLOSSARY_CLUSTER = """
            <h2>Glossary batch 10</h2>
            <ul>
            <li><a href="/guides/glossary-jbig2">JBIG2</a> · <a href="/guides/glossary-monochrome">Monochrome</a> · <a href="/guides/glossary-mrc-compression">MRC compression</a></li>
            <li><a href="/guides/glossary-linearized">Linearized</a> · <a href="/guides/glossary-linearized-pdf">Linearized PDF</a></li>
            <li><a href="/guides/glossary-media-box">Media box</a> · <a href="/guides/glossary-page-box">Page box</a></li>
            <li><a href="/guides/glossary-layers">Layers</a> · <a href="/guides/glossary-marked-content">Marked content</a></li>
            <li><a href="/guides/glossary-object-stream">Object stream</a> · <a href="/guides/glossary-opentype">OpenType</a></li>
            <li><a href="/guides/glossary-optical-character-recognition">OCR</a> · <a href="/guides/glossary-job-queue">Job queue</a></li>
            <li><a href="/guides/glossary-libreoffice-headless">LibreOffice headless</a></li>
            <li><a href="/guides/glossary-pdf-17">PDF 1.7</a> · <a href="/guides/glossary-pdf-20">PDF 2.0</a> · <a href="/guides/glossary-pdf-package">PDF package</a></li>
            </ul>
            <p>Prior: <a href="/guides/glossary-dpi">batch 9</a> · Hub: <a href="/guides/pdf-glossary-hub">PDF glossary hub</a></p>
            """

W33_GLOSSARY_TOPUP = """
            <h2>Glossary batch 10 — concept map</h2>
            <ul>
            <li><strong>Scan compress:</strong> monochrome → JBIG2 / MRC → flate</li>
            <li><strong>Web delivery:</strong> linearized → fast first page → compress for size</li>
            <li><strong>Print geometry:</strong> page box family — media, crop, bleed, trim</li>
            <li><strong>Structure:</strong> marked content → layers → tags</li>
            <li><strong>Versions:</strong> PDF 1.7 object streams → PDF 2.0 encryption</li>
            <li><strong>Automation:</strong> job queue + LibreOffice headless CLI</li>
            </ul>
            <h2>Standards cluster</h2>
            <p><a href="/guides/glossary-iso-32000">ISO 32000</a> · <a href="/guides/glossary-pdf-a">PDF/A</a> · <a href="/guides/glossary-pdf-x">PDF/X</a> · <a href="/guides/glossary-pdf-ua">PDF/UA</a></p>
            """

W33_CLOSING = """
            <h2>Related guides</h2>
            <p>Wave 33 covers scan compression codecs, page geometry, PDF ISO versions, web linearization, OCR, server batch queues, and embedded package deliverables.</p>
            <p>Hub: <a href="/guides/pdf-glossary-hub">PDF glossary hub</a> · Next: <a href="/guides/glossary-pdf-portfolio">PDF portfolio</a> · <a href="/guides/glossary-pdfjs">PDF.js</a> · <a href="/guides/glossary-peppol">Peppol</a></p>
            """
