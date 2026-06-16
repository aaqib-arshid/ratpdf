"""Wave 35 — Glossary authority batch 12 (17 terms)."""

W35_SLUGS = [
    "glossary-rgb",
    "glossary-sac-code",
    "glossary-screen-reader",
    "glossary-server-side-pdf",
    "glossary-sgst",
    "glossary-split",
    "glossary-structure-tree",
    "glossary-subsampling",
    "glossary-subset",
    "glossary-subset-fonts",
    "glossary-tagged-pdf",
    "glossary-tds",
    "glossary-toUnicode",
    "glossary-transparency",
    "glossary-trim-box",
    "glossary-truetype",
    "glossary-type0-font",
]

GLOSSARY_SLUGS = set(W35_SLUGS)

W35_DATA = {
    "glossary-rgb": {
        "title": "What Is RGB in PDF? — Screen Colour vs Print CMYK (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/glossary-cmyk",
        "pillar_label": "CMYK glossary",
        "related": "/guides/glossary-color-profile",
        "example": "Marketing PDF looks vivid on monitor — printer converts RGB blue to muddy CMYK without profile",
    },
    "glossary-sac-code": {
        "title": "What Is SAC Code on Invoice PDF? — India GST Services (2026)",
        "tool": "/invoice/create",
        "label": "Create Invoice",
        "pillar": "/guides/glossary-hsn-code",
        "pillar_label": "HSN code glossary",
        "related": "/guides/glossary-gst-invoice",
        "example": "Consulting firm invoices with SAC 998314 — must match e-invoice JSON and PDF line",
    },
    "glossary-screen-reader": {
        "title": "What Is a Screen Reader for PDF? — NVDA, VoiceOver &amp; Tags (2026)",
        "tool": "/pdf/ocrpdf",
        "label": "OCR PDF",
        "pillar": "/guides/pdf-accessibility-wcag",
        "pillar_label": "PDF accessibility WCAG",
        "related": "/guides/glossary-tagged-pdf",
        "example": "Blind student hears table read as paragraph soup — untagged syllabus PDF fails VoiceOver test",
    },
    "glossary-server-side-pdf": {
        "title": "What Is Server-Side PDF Processing? — Upload Pipelines (2026)",
        "tool": "/guides/browser-vs-desktop-pdf-tools",
        "label": "browser vs desktop PDF",
        "pillar": "/guides/glossary-client-side-pdf",
        "pillar_label": "client-side PDF glossary",
        "related": "/guides/pdf-tool-security-comparison",
        "example": "Legal reviews vendor — files upload to AWS Lambda for OCR — retention policy is critical",
    },
    "glossary-sgst": {
        "title": "What Is SGST on Invoice PDF? — India State GST Component (2026)",
        "tool": "/invoice/create",
        "label": "Create Invoice",
        "pillar": "/guides/glossary-cgst",
        "pillar_label": "CGST glossary",
        "related": "/guides/glossary-igst",
        "example": "Bangalore B2B sale within Karnataka — invoice PDF shows CGST 9% + SGST 9% — no IGST line",
    },
    "glossary-split": {
        "title": "What Is PDF Split? — Divide Pages Into Separate Files (2026)",
        "tool": "/pdf/split",
        "label": "Split PDF",
        "pillar": "/guides/split-pdf",
        "pillar_label": "split PDF guide",
        "related": "/guides/compress-vs-split",
        "example": "Paralegal splits 400-page deposition PDF into 50-page chunks for email after compress still over cap",
    },
    "glossary-structure-tree": {
        "title": "What Is the PDF Structure Tree? — Tags for Accessibility (2026)",
        "tool": "/pdf/ocrpdf",
        "label": "OCR PDF",
        "pillar": "/guides/glossary-tagged-pdf",
        "pillar_label": "tagged PDF glossary",
        "related": "/guides/glossary-reading-order",
        "example": "Accessibility checker reports missing H1 in structure tree — headings styled bold only in visual layer",
    },
    "glossary-subsampling": {
        "title": "What Is Image Subsampling in PDF? — Downscale on Compress (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/glossary-compression",
        "pillar_label": "compression glossary",
        "related": "/guides/glossary-dpi",
        "example": "Compress downsamples 600 DPI cover image to 150 DPI — file halves — fine print on chart blurs",
    },
    "glossary-subset": {
        "title": "What Is Font Subsetting in PDF? — Glyphs Embedded (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/glossary-subset-fonts",
        "pillar_label": "subset fonts glossary",
        "related": "/guides/glossary-font-embedding",
        "example": "Invoice PDF embeds subset of Roboto — only digits and A–Z — 40 KB not 2 MB full font",
    },
    "glossary-subset-fonts": {
        "title": "What Are Subset Fonts in PDF? — Partial Embed Explained (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/glossary-full-embedding",
        "pillar_label": "full embedding glossary",
        "related": "/guides/glossary-opentype",
        "example": "Viewer shows 'ABCDEF+Roboto' prefix — indicator only subset characters shipped in PDF",
    },
    "glossary-tagged-pdf": {
        "title": "What Is Tagged PDF? — Structure for Accessibility (2026)",
        "tool": "/pdf/ocrpdf",
        "label": "OCR PDF",
        "pillar": "/guides/tagged-pdf-checklist",
        "pillar_label": "tagged PDF checklist",
        "related": "/guides/glossary-pdf-ua-1",
        "example": "City publishes benefits PDF — tagged export from Word passes PAC — screen reader navigates headings",
    },
    "glossary-tds": {
        "title": "What Is TDS on Invoice PDF? — India Tax Deducted at Source (2026)",
        "tool": "/invoice/create",
        "label": "Create Invoice",
        "pillar": "/guides/glossary-gst-invoice",
        "pillar_label": "GST invoice glossary",
        "related": "/guides/invoice-pdf-workflow-india",
        "example": "Client withholds 10% TDS on professional fee — vendor invoice PDF notes TDS section 194J line",
    },
    "glossary-toUnicode": {
        "title": "What Is ToUnicode CMap in PDF? — Copy-Paste Mapping (2026)",
        "tool": "/pdf/ocrpdf",
        "label": "OCR PDF",
        "pillar": "/guides/glossary-cmap",
        "pillar_label": "CMap glossary",
        "related": "/guides/glossary-unicode-mapping",
        "example": "Japanese report copy-paste returns boxes — missing ToUnicode — search and extract fail in discovery",
    },
    "glossary-transparency": {
        "title": "What Is PDF Transparency? — Alpha, Blend Modes &amp; Flatten (2026)",
        "tool": "/pdf/flattenpdf",
        "label": "Flatten PDF",
        "pillar": "/guides/glossary-pdf-x-4",
        "pillar_label": "PDF/X-4 glossary",
        "related": "/guides/glossary-layers",
        "example": "Logo with soft drop shadow uses transparency — old RIP requires flatten — PDF/X-1a preflight fails",
    },
    "glossary-trim-box": {
        "title": "What Is the Trim Box in PDF? — Finished Cut Size (2026)",
        "tool": "/pdf/crop",
        "label": "Crop PDF",
        "pillar": "/guides/glossary-page-box",
        "pillar_label": "page box glossary",
        "related": "/guides/glossary-bleed-box",
        "example": "Printer trims to trim box — artwork past bleed OK — text outside trim box gets cut off",
    },
    "glossary-truetype": {
        "title": "What Is TrueType in PDF? — TTF Embedding (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/glossary-opentype",
        "pillar_label": "OpenType glossary",
        "related": "/guides/glossary-font-embedding",
        "example": "Word export embeds TrueType Arial subset — displays on Mac without installing Arial",
    },
    "glossary-type0-font": {
        "title": "What Is Type 0 Font in PDF? — Composite CID Font (2026)",
        "tool": "/pdf/ocrpdf",
        "label": "OCR PDF",
        "pillar": "/guides/glossary-composite-font",
        "pillar_label": "composite font glossary",
        "related": "/guides/glossary-type1-font",
        "example": "Korean PDF uses Type 0 composite — Type 1 Helvetica on same page for English body text",
    },
}

W35_DEEP = {
    "glossary-rgb": """
            <h2>Definition</h2>
            <p><strong>RGB (Red Green Blue)</strong> is additive screen colour — PDFs from PowerPoint and web exports often RGB — commercial offset print expects CMYK — mismatch causes colour shift.</p>
            <h2>Workflow</h2>
            <ul>
            <li>Design for print — convert to CMYK with ICC in InDesign</li>
            <li>Office RGB PDF — printer converts at RIP — surprise results</li>
            <li>PDF/X-1a forbids RGB — <a href="/guides/glossary-pdf-x-1a">PDF/X-1a</a></li>
            </ul>
            <p>Profiles: <a href="/guides/glossary-color-profile">color profile</a> · <a href="/guides/glossary-cmyk">CMYK</a> · compress does not fix colour space — <a href="/pdf/compress">Compress PDF</a> after correct export.</p>
            """,
    "glossary-sac-code": """
            <h2>Definition</h2>
            <p><strong>SAC (Services Accounting Code)</strong> classifies services for India GST — numeric code on invoice PDF lines — counterpart to <a href="/guides/glossary-hsn-code">HSN</a> for goods.</p>
            <h2>On invoice PDF</h2>
            <ul>
            <li>Service description + SAC per line</li>
            <li>Must match GSTR-1 and e-invoice schema</li>
            <li>Wrong SAC → ITC dispute and penalty risk</li>
            </ul>
            <p>Export: <a href="/invoice/create">Create Invoice</a> · <a href="/guides/glossary-gst-invoice">GST invoice</a> · <a href="/guides/glossary-irn">IRN</a>.</p>
            """,
    "glossary-screen-reader": """
            <h2>Definition</h2>
            <p>A <strong>screen reader</strong> (NVDA, JAWS, VoiceOver) speaks tagged PDF structure — headings, lists, tables — untagged PDF may read visual order wrong or skip images without alt text.</p>
            <h2>Tagged PDF requirement</h2>
            <ol>
            <li>Export tagged PDF from accessible source</li>
            <li>Set alt text on figures</li>
            <li>Fix <a href="/guides/glossary-reading-order">reading order</a></li>
            <li>Manual listen test on page 1 and TOC</li>
            </ol>
            <p>Standards: <a href="/guides/glossary-tagged-pdf">tagged PDF</a> · <a href="/guides/glossary-pdf-ua-1">PDF/UA-1</a> · <a href="/guides/pdf-accessibility-wcag">WCAG guide</a>.</p>
            """,
    "glossary-server-side-pdf": """
            <h2>Definition</h2>
            <p><strong>Server-side PDF processing</strong> uploads file to remote API — OCR, merge, convert on cloud VM — contrast with <a href="/guides/glossary-client-side-pdf">client-side</a> browser WASM.</p>
            <h2>Due diligence</h2>
            <ul>
            <li>Retention period and purge SLA</li>
            <li>Region and subprocessor list</li>
            <li>Encryption in transit and at rest</li>
            <li>PHI/legal privilege policy</li>
            </ul>
            <p>Compare: <a href="/guides/pdf-tool-security-comparison">security comparison</a> · <a href="/guides/browser-vs-desktop-pdf-tools">browser vs desktop</a> · <a href="/home/security">RatPDF security</a>.</p>
            """,
    "glossary-sgst": """
            <h2>Definition</h2>
            <p><strong>SGST (State Goods and Services Tax)</strong> is state share on intra-state India supplies — always paired with <a href="/guides/glossary-cgst">CGST</a> on same-state B2B invoice PDF.</p>
            <h2>Invoice layout</h2>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>Scenario</th><th>Tax lines</th></tr></thead>
            <tbody>
            <tr><td>Same state B2B</td><td>CGST + SGST</td></tr>
            <tr><td>Inter-state</td><td><a href="/guides/glossary-igst">IGST</a> only</td></tr>
            </tbody></table></div>
            <p>E-invoice JSON must match PDF — <a href="/invoice/create">Create Invoice</a> · workflow: <a href="/guides/invoice-pdf-workflow-india">India invoice</a>.</p>
            """,
    "glossary-split": """
            <h2>Definition</h2>
            <p><strong>PDF split</strong> divides one file into multiple PDFs by page range, size cap, or bookmark — opposite of <a href="/pdf/merge">merge</a> — used when email or portal rejects single large attachment.</p>
            <h2>When to split vs compress</h2>
            <ul>
            <li>Compress first on digital PDFs — <a href="/guides/compress-vs-split">compress vs split</a></li>
            <li>Split scanned depositions if compress blurs signatures</li>
            <li>Name parts logically — Deposition_Part1of4.pdf</li>
            </ul>
            <p>Tool: <a href="/pdf/split">Split PDF</a> · guide: <a href="/guides/split-pdf">split PDF guide</a> · <a href="/guides/split-pdf-by-size">split by size</a>.</p>
            """,
    "glossary-structure-tree": """
            <h2>Definition</h2>
            <p>The <strong>structure tree</strong> is hierarchical tag graph in tagged PDF — Document → Sect → H1 → P → Table — screen readers and reflow tools traverse it — distinct from visual z-order.</p>
            <h2>Common defects</h2>
            <ul>
            <li>Headings tagged as Span</li>
            <li>Table cells not TH/TD</li>
            <li>Artifact noise in tree</li>
            <li>Empty container nodes</li>
            </ul>
            <p>Fix: remediate in Acrobat or source export — <a href="/guides/glossary-tagged-pdf">tagged PDF</a> · <a href="/guides/glossary-marked-content">marked content</a> · checklist: <a href="/guides/tagged-pdf-checklist">tagged checklist</a>.</p>
            """,
    "glossary-subsampling": """
            <h2>Definition</h2>
            <p><strong>Subsampling</strong> reduces image resolution during PDF save or compress — e.g. 300 DPI → 150 DPI — fewer pixels — smaller file — may soften fine text in raster scans.</p>
            <h2>QA after subsample</h2>
            <p>Zoom 100% on stamps and footnotes — if illegible use Less compress preset — scan higher DPI first — <a href="/guides/glossary-dpi">DPI</a> · <a href="/guides/glossary-compression">compression</a> · <a href="/pdf/compress">Compress PDF</a>.</p>
            """,
    "glossary-subset": """
            <h2>Definition</h2>
            <p><strong>Subset</strong> (font context) embeds only glyphs used in document — "ABCDEF+FontName" prefix in Acrobat — minimises PDF size vs <a href="/guides/glossary-full-embedding">full embedding</a>.</p>
            <h2>Risk</h2>
            <p>If later edit adds character not in subset — tofu box — re-export with expanded subset — <a href="/guides/glossary-subset-fonts">subset fonts</a> · <a href="/guides/pdf-fonts-missing">fonts missing</a>.</p>
            """,
    "glossary-subset-fonts": """
            <h2>Definition</h2>
            <p><strong>Subset fonts</strong> are partial font programs embedded in PDF — only codepoints appearing in text show in font file — standard for web and email PDFs.</p>
            <h2>Formats</h2>
            <p>TrueType, OpenType, Type1 all support subset — CID fonts subset per glyph collections — <a href="/guides/glossary-truetype">TrueType</a> · <a href="/guides/glossary-opentype">OpenType</a> · embed: <a href="/guides/glossary-font-embedding">font embedding</a>.</p>
            """,
    "glossary-tagged-pdf": """
            <h2>Definition</h2>
            <p><strong>Tagged PDF</strong> includes structure tree mapping content to semantic roles — H1, P, L, Table — required for <a href="/guides/glossary-pdf-ua-1">PDF/UA</a> and Section 508 compliance — not automatic on scan.</p>
            <h2>How to create</h2>
            <ol>
            <li>Accessible Word → Save as PDF (tagged)</li>
            <li>InDesign export tagged PDF</li>
            <li>Do not rely on OCR alone for tags</li>
            <li>Validate with PAC or checkerlist</li>
            </ol>
            <p>OCR: <a href="/pdf/ocrpdf">OCR PDF</a> adds text not tags — <a href="/guides/beginner-pdf-tags-accessibility">tags basics</a> · <a href="/guides/glossary-structure-tree">structure tree</a>.</p>
            """,
    "glossary-tds": """
            <h2>Definition</h2>
            <p><strong>TDS (Tax Deducted at Source)</strong> is income tax withheld at payment — shown on vendor invoice PDF and Form 16A — separate from GST lines — contractor invoices often note TDS section.</p>
            <h2>PDF fields</h2>
            <ul>
            <li>Gross fee, TDS rate, net payable</li>
            <li>PAN of deductee and deductor</li>
            <li>Not confused with CGST/SGST — <a href="/guides/glossary-cgst">CGST</a></li>
            </ul>
            <p>India workflow: <a href="/guides/invoice-pdf-workflow-india">invoice PDF India</a> · <a href="/invoice/create">Create Invoice</a>.</p>
            """,
    "glossary-toUnicode": """
            <h2>Definition</h2>
            <p><strong>ToUnicode CMap</strong> maps font character codes to Unicode scalar values — enables correct copy-paste, search, and extract — essential for <a href="/guides/glossary-identity-h">Identity-H</a> CJK fonts.</p>
            <h2>Missing ToUnicode symptoms</h2>
            <ul>
            <li>Copy-paste garbage or empty</li>
            <li>Ctrl+F misses visible text</li>
            <li>pdftotext drops lines</li>
            </ul>
            <p>Fix: re-export from source — OCR fallback — <a href="/guides/glossary-cmap">CMap</a> · <a href="/guides/glossary-unicode-mapping">unicode mapping</a> · <a href="/guides/glossary-encoding">encoding</a> · <a href="/pdf/ocrpdf">OCR PDF</a>.</p>
            """,
    "glossary-transparency": """
            <h2>Definition</h2>
            <p><strong>PDF transparency</strong> uses alpha channels and blend modes — soft shadows, glass effects — older print workflows require <strong>flattening</strong> to opaque CMYK — <a href="/guides/glossary-pdf-x-4">PDF/X-4</a> allows live transparency.</p>
            <h2>Flatten when</h2>
            <ul>
            <li>Printer demands PDF/X-1a</li>
            <li>Unexpected colour on RIP proof</li>
            <li>Simplify for archive stamp</li>
            </ul>
            <p><a href="/pdf/flattenpdf">Flatten PDF</a> · <a href="/guides/glossary-layers">layers</a> · preflight: <a href="/guides/glossary-preflight">preflight</a>.</p>
            """,
    "glossary-trim-box": """
            <h2>Definition</h2>
            <p><strong>Trim box</strong> defines intended final cut dimensions after print — artwork in bleed extends past trim — text must stay inside trim — printer cuts to trim box.</p>
            <h2>Box family</h2>
            <p>Media ≥ bleed ≥ <strong>trim</strong> ≥ crop — misalignment causes white sliver or clipped text — <a href="/guides/glossary-page-box">page box</a> · <a href="/guides/glossary-bleed-box">bleed box</a> · <a href="/guides/glossary-crop-box">crop box</a>.</p>
            """,
    "glossary-truetype": """
            <h2>Definition</h2>
            <p><strong>TrueType (TTF)</strong> is outline font format common in Windows and macOS — PDF embeds TTF as font descriptor + font file or subset — widely supported by viewers.</p>
            <h2>vs Type1 and OpenType</h2>
            <p>Type1 older PostScript — OpenType superset — PDF may embed any — missing embed → substitution — <a href="/guides/glossary-type1-font">Type1</a> · <a href="/guides/glossary-opentype">OpenType</a> · <a href="/guides/glossary-subset-fonts">subset fonts</a>.</p>
            """,
    "glossary-type0-font": """
            <h2>Definition</h2>
            <p><strong>Type 0 font</strong> is PDF composite font — combines CID-keyed descendants for CJK — uses <a href="/guides/glossary-composite-font">composite font</a> and CMap — not used for simple Latin body text.</p>
            <h2>vs Type1</h2>
            <p>English paragraph → Type1 or TrueType — Japanese inline → Type0 — extract needs ToUnicode — <a href="/guides/glossary-type1-font">Type1 font</a> · <a href="/guides/glossary-cid-font">CID font</a> · <a href="/pdf/ocrpdf">OCR PDF</a> fallback.</p>
            """,
}

W35_GLOSSARY_CLUSTER = """
            <h2>Glossary batch 12</h2>
            <ul>
            <li><a href="/guides/glossary-rgb">RGB</a> · <a href="/guides/glossary-transparency">Transparency</a> · <a href="/guides/glossary-trim-box">Trim box</a></li>
            <li><a href="/guides/glossary-sac-code">SAC code</a> · <a href="/guides/glossary-sgst">SGST</a> · <a href="/guides/glossary-tds">TDS</a></li>
            <li><a href="/guides/glossary-screen-reader">Screen reader</a> · <a href="/guides/glossary-tagged-pdf">Tagged PDF</a> · <a href="/guides/glossary-structure-tree">Structure tree</a></li>
            <li><a href="/guides/glossary-server-side-pdf">Server-side PDF</a> · <a href="/guides/glossary-split">Split</a></li>
            <li><a href="/guides/glossary-subsampling">Subsampling</a> · <a href="/guides/glossary-subset">Subset</a> · <a href="/guides/glossary-subset-fonts">Subset fonts</a></li>
            <li><a href="/guides/glossary-toUnicode">ToUnicode</a> · <a href="/guides/glossary-truetype">TrueType</a> · <a href="/guides/glossary-type0-font">Type 0 font</a></li>
            </ul>
            <p>Prior: <a href="/guides/glossary-pdf-x-1a">batch 11</a> · Hub: <a href="/guides/pdf-glossary-hub">PDF glossary hub</a></p>
            """

W35_GLOSSARY_TOPUP = """
            <h2>Glossary batch 12 — concept map</h2>
            <ul>
            <li><strong>Colour &amp; print:</strong> RGB → CMYK · transparency → flatten · trim box</li>
            <li><strong>India tax PDF:</strong> SAC services · SGST + CGST · TDS withholding</li>
            <li><strong>Accessibility:</strong> tagged PDF → structure tree → screen reader</li>
            <li><strong>Fonts:</strong> subset → TrueType/Type0 → ToUnicode mapping</li>
            <li><strong>Ops:</strong> server-side vs client · split vs compress</li>
            </ul>
            """

W35_CLOSING = """
            <h2>Related guides</h2>
            <p>Wave 35 upgrades colour, India tax, accessibility structure, font embedding, transparency, and PDF split terminology — ten glossary terms remain for Wave 36 to complete UPGRADE.</p>
            <p>Hub: <a href="/guides/pdf-glossary-hub">PDF glossary hub</a> · Final batch: <a href="/guides/glossary-type1-font">Type1</a> · <a href="/guides/glossary-zugferd">ZUGFeRD</a> · <a href="/guides/glossary-xmp-metadata">XMP</a></p>
            """
