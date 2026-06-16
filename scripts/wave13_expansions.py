"""Wave 13 — Printing workflows: device print-to-PDF, quality, flatten, commercial prep."""

W13_SLUGS = [
    "compress-pdf-for-printing",
    "flatten-pdf",
    "print-to-pdf-windows",
    "edge-print-to-pdf",
    "chrome-save-as-pdf-settings",
    "glossary-overprint",
    "glossary-flattened-pdf",
    "pdf-printing-guide",
    "print-pdf-double-sided",
    "print-pdf-black-and-white",
    "pdf-fit-to-page-printing",
    "embed-fonts-before-printing",
    "print-to-pdf-vs-save-as-pdf",
    "mac-print-to-pdf",
    "print-pdf-from-ipad",
    "commercial-print-pdf-checklist",
    "pdf-print-as-image",
]

W13_DATA = {
    "compress-pdf-for-printing": {
        "title": "Compress PDF for Printing — Quality vs File Size (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "example": "Print shop requests under 20 MB email attachment — compress copy, keep lossless master for plates",
    },
    "flatten-pdf": {
        "title": "Flatten PDF Forms — Lock Field Values Before Print &amp; Portal Upload (2026)",
        "tool": "/pdf/flatten",
        "label": "Flatten PDF",
        "example": "Tax form prints blank until annotations merge into page content via flatten",
    },
    "print-to-pdf-windows": {
        "title": "Print to PDF on Windows — Microsoft Print to PDF Setup (2026)",
        "tool": "/guides/pdf-tools",
        "label": "PDF tools hub",
        "example": "Office worker exports spreadsheet to PDF without Acrobat using built-in Windows driver",
    },
    "edge-print-to-pdf": {
        "title": "Edge Print to PDF — Save Web Pages &amp; Settings (2026)",
        "tool": "/guides/pdf-tools",
        "label": "PDF tools hub",
        "example": "Procurement saves vendor portal quote page as PDF for audit trail",
    },
    "chrome-save-as-pdf-settings": {
        "title": "Chrome Save as PDF Settings — Headers, Margins &amp; Background (2026)",
        "tool": "/guides/pdf-tools",
        "label": "PDF tools hub",
        "example": "Designer exports landing page PDF with background graphics enabled for client mockup",
    },
    "glossary-overprint": {
        "title": "What Is Overprint? — PDF Print Term for Designers &amp; Prepress (2026)",
        "tool": "/guides/pdf-x-print-standard",
        "label": "PDF/X print standard",
        "example": "Brand black knocks out incorrectly — overprint preview shows unintended ink stack",
    },
    "glossary-flattened-pdf": {
        "title": "What Is a Flattened PDF? — Forms, Annotations &amp; Print Reliability (2026)",
        "tool": "/pdf/flatten",
        "label": "Flatten PDF",
        "example": "HR onboarding pack must not remain editable after candidate signs — flatten before archive",
    },
    "pdf-printing-guide": {
        "title": "PDF Printing Guide Hub — Device, Quality &amp; Troubleshooting Index (2026)",
        "tool": "/guides/pdf-tools",
        "label": "PDF tools hub",
        "example": "IT helpdesk bookmark linking blank-page, margin, color, and flatten fixes in one hub",
    },
    "print-pdf-double-sided": {
        "title": "Print PDF Double-Sided — Duplex Settings &amp; Page Order (2026)",
        "tool": "/guides/pdf-tools",
        "label": "PDF tools hub",
        "example": "Facilities prints employee handbook duplex — odd pages flip on long-edge binding",
    },
    "print-pdf-black-and-white": {
        "title": "Print PDF Black and White — Grayscale &amp; Toner Save (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "example": "Legal team prints 400-page discovery index in grayscale to cut toner cost",
    },
    "pdf-fit-to-page-printing": {
        "title": "PDF Fit to Page When Printing — Scale vs Actual Size (2026)",
        "tool": "/guides/pdf-tools",
        "label": "PDF tools hub",
        "example": "Architect scales A3 site plan to letter paper without cropping critical dimensions",
    },
    "embed-fonts-before-printing": {
        "title": "Embed Fonts Before Printing PDF — Missing Glyph &amp; Substitution Fixes (2026)",
        "tool": "/pdf/doctopdf",
        "label": "Word to PDF",
        "example": "Proposal prints with wrong font on conference room MFP — re-export with embedded fonts",
    },
    "print-to-pdf-vs-save-as-pdf": {
        "title": "Print to PDF vs Save as PDF — Which Method Preserves Links &amp; Layout (2026)",
        "tool": "/pdf/doctopdf",
        "label": "Word to PDF",
        "example": "Analyst compares Word export paths — save-as keeps hyperlinks print-to-PDF drops",
    },
    "mac-print-to-pdf": {
        "title": "Mac Print to PDF — Save as PDF from Any App (2026)",
        "tool": "/guides/pdf-tools",
        "label": "PDF tools hub",
        "example": "Consultant saves Keynote deck as PDF from macOS print dialog for client email",
    },
    "print-pdf-from-ipad": {
        "title": "Print PDF from iPad — AirPrint, Markup &amp; Share Sheet (2026)",
        "tool": "/guides/pdf-tools",
        "label": "PDF tools hub",
        "example": "Field inspector AirPrints annotated site photo PDF from iPad before leaving job site",
    },
    "commercial-print-pdf-checklist": {
        "title": "Commercial Print PDF Checklist — Bleed, CMYK &amp; PDF/X Handoff (2026)",
        "tool": "/guides/pdf-x-print-standard",
        "label": "PDF/X print standard",
        "example": "Marketing ships brochure PDF/X-1a to offset printer — preflight passes first time",
    },
    "pdf-print-as-image": {
        "title": "PDF Print as Image — Driver Fix for Blank or Garbled Pages (2026)",
        "tool": "/pdf/flatten",
        "label": "Flatten PDF",
        "example": "Complex CAD overlay PDF prints garbage until print-as-image rasterizes each page",
    },
}

W13_DEEP = {
    "compress-pdf-for-printing": """
            <h2>When compression is safe before print</h2>
            <p>Compress a <strong>copy</strong> for email-to-print-shop transfer — keep uncompressed master on disk for plate printing and reprints. Ghostscript Less preserves fine type; Recommended suits mixed text and photos.</p>
            <h2>Step-by-step</h2>
            <ol>
            <li>Duplicate PDF — label master <code>_PRINT_MASTER</code></li>
            <li>Upload copy to <a href="/pdf/compress">Compress PDF</a> — choose Less for legal exhibits</li>
            <li>Print one test page — verify logos and 8pt footnotes</li>
            <li>Email compressed copy — retain master for production</li>
            </ol>
            <p>Pillar: <a href="/guides/compress-pdf-guide">compress PDF guide</a> · <a href="/guides/pdf-x-print-standard">PDF/X for commercial print</a>.</p>
            """,
    "flatten-pdf": """
            <h2>Why flatten before print</h2>
            <p>Form fields, comments, and markup layers may render on screen but print invisible — driver skips optional content groups. Flatten merges values into static page content.</p>
            <h2>Portal uploads</h2>
            <p>Government and court portals often reject editable PDFs — flatten after fill — then <a href="/pdf/compress">compress</a> if size cap applies.</p>
            <h2>Workflow</h2>
            <ol>
            <li>Complete all form fields in viewer</li>
            <li>Upload to <a href="/pdf/flatten">Flatten PDF</a></li>
            <li>Download flat copy — verify fields visible at 100% zoom</li>
            <li>Print test page before bulk run</li>
            </ol>
            """,
    "print-to-pdf-windows": """
            <h2>Microsoft Print to PDF</h2>
            <p>Built-in virtual printer on Windows 10/11 — File → Print → <strong>Microsoft Print to PDF</strong> — saves vector PDF without Acrobat.</p>
            <h2>Settings that matter</h2>
            <ul>
            <li><strong>Page range</strong> — export section not whole 200-page workbook</li>
            <li><strong>Orientation</strong> — landscape for wide tables</li>
            <li><strong>Print quality</strong> — higher DPI for scans embedded in source</li>
            </ul>
            <h2>Limits</h2>
            <p>Print driver may drop hyperlinks — for Word documents use <a href="/pdf/doctopdf">Word to PDF</a> when links must survive.</p>
            """,
    "edge-print-to-pdf": """
            <h2>Edge save as PDF</h2>
            <p>Ctrl+P → Printer <strong>Microsoft Print to PDF</strong> or <strong>Save as PDF</strong> (Edge-specific) — choose paper size and margins.</p>
            <h2>Web page captures</h2>
            <p>Enable <strong>Background graphics</strong> for branded pages — disable headers/footers with URL and date for client-facing exports.</p>
            <h2>Enterprise</h2>
            <p>IT may restrict print-to-PDF — use <a href="/pdf/htmltopdf">HTML to PDF</a> for controlled server render when allowed.</p>
            """,
    "chrome-save-as-pdf-settings": """
            <h2>Chrome print dialog</h2>
            <p>Destination <strong>Save as PDF</strong> — More settings → margins, scale, background graphics, headers/footers off for clean export.</p>
            <h2>Scale pitfalls</h2>
            <p>Default shrink-to-fit may make 12px UI text illegible — set Custom scale 100% when page width matches paper.</p>
            <h2>Long pages</h2>
            <p>Single-page web apps may paginate oddly — consider <a href="/pdf/htmltopdf">HTML to PDF</a> for multi-page reports.</p>
            """,
    "glossary-overprint": """
            <h2>Definition</h2>
            <p><strong>Overprint</strong> tells the press to print one ink on top of another instead of knocking out — essential for rich black (C+M+Y+K) and spot varnish.</p>
            <h2>PDF symptom</h2>
            <p>Wrong overprint settings make brand colors shift — white text disappears on colored background — fix in InDesign/Acrobat prepress — not browser tools.</p>
            <h2>Related</h2>
            <p>Commercial handoff uses <a href="/guides/pdf-x-print-standard">PDF/X</a> with output intent — office laser ignores overprint flags.</p>
            """,
    "glossary-flattened-pdf": """
            <h2>Definition</h2>
            <p>A <strong>flattened PDF</strong> has form field values and annotations baked into page content — no longer editable — reliable for print and archive.</p>
            <h2>Not the same as compress</h2>
            <p>Compression shrinks bytes — flatten changes structure — run flatten after fill — compress copy for email if needed.</p>
            <h2>Tool</h2>
            <p><a href="/pdf/flatten">Flatten PDF</a> in browser — verify with copy-paste test — field text should not select as separate widget.</p>
            """,
    "pdf-printing-guide": """
            <h2>Hub index</h2>
            <ul>
            <li><a href="/guides/compress-pdf-for-printing">Compress for printing</a> · <a href="/guides/flatten-pdf">Flatten PDF</a></li>
            <li><a href="/guides/print-to-pdf-windows">Windows print to PDF</a> · <a href="/guides/mac-print-to-pdf">Mac print to PDF</a></li>
            <li><a href="/guides/edge-print-to-pdf">Edge print to PDF</a> · <a href="/guides/chrome-save-as-pdf-settings">Chrome save as PDF</a></li>
            <li><a href="/guides/print-pdf-double-sided">Double-sided</a> · <a href="/guides/print-pdf-black-and-white">Black and white</a></li>
            <li><a href="/guides/pdf-fit-to-page-printing">Fit to page</a> · <a href="/guides/embed-fonts-before-printing">Embed fonts</a></li>
            <li><a href="/guides/commercial-print-pdf-checklist">Commercial print checklist</a> · <a href="/guides/pdf-x-print-standard">PDF/X</a></li>
            <li><a href="/guides/pdf-printing-blank-pages">Blank pages fix</a> · <a href="/guides/print-pdf-without-margins">Margins</a> · <a href="/guides/pdf-colors-wrong-when-printing">Colors wrong</a></li>
            </ul>
            """,
    "print-pdf-double-sided": """
            <h2>Duplex modes</h2>
            <p><strong>Long-edge binding</strong> — book-style flip on long side — <strong>Short-edge</strong> — calendar flip — pick to match how reader opens document.</p>
            <h2>Page order</h2>
            <p>Some drivers print reverse — test 4-page sample — odd/even alignment on booklet imposition needs source app not RatPDF.</p>
            <h2>Large jobs</h2>
            <p>Split oversized PDF with <a href="/guides/split-pdf">Split PDF</a> if MFP memory errors on 500+ page duplex run.</p>
            """,
    "print-pdf-black-and-white": """
            <h2>Grayscale print</h2>
            <p>Printer dialog → Color → Grayscale or Black &amp; White — saves toner on text-heavy legal and policy PDFs.</p>
            <h2>Color PDF content</h2>
            <p>Charts may lose meaning in gray — print color cover separately — body in B&amp;W — or compress color copy for digital only.</p>
            <h2>Accessibility</h2>
            <p>Do not rely on color alone in source PDF — see <a href="/guides/pdf-accessibility-wcag">WCAG PDF guide</a>.</p>
            """,
    "pdf-fit-to-page-printing": """
            <h2>Actual size vs fit</h2>
            <p><strong>Actual size</strong> — 100% — respects PDF media box — <strong>Fit to page</strong> — scales down — may shrink blueprints illegibly.</p>
            <h2>Custom scale</h2>
            <p>Try 90–95% when printer adds unprintable margin — avoids clipping footer page numbers.</p>
            <h2>Professional bleed</h2>
            <p>True full-bleed needs source app trim box — browser tools cannot add bleed — see <a href="/guides/commercial-print-pdf-checklist">commercial checklist</a>.</p>
            """,
    "embed-fonts-before-printing": """
            <h2>Missing font symptom</h2>
            <p>Screen uses system font substitute — printer uses different metric — layout reflows — bullets misalign.</p>
            <h2>Fix at source</h2>
            <p>Word → Options → Save → embed fonts — export via <a href="/pdf/doctopdf">Word to PDF</a> — or print-to-PDF after embedding.</p>
            <h2>Scanned PDFs</h2>
            <p>No font issue — text is image — <a href="/pdf/ocrpdf">OCR PDF</a> if you need selectable text after print scan-back.</p>
            """,
    "print-to-pdf-vs-save-as-pdf": """
            <h2>Save as PDF (export)</h2>
            <p>Native export from Word, Excel, PowerPoint — preserves hyperlinks, bookmarks, and structure better than generic print driver.</p>
            <h2>Print to PDF</h2>
            <p>Rasterizes through driver stack — fine for quick capture — may flatten layers unpredictably — links often lost.</p>
            <h2>RatPDF path</h2>
            <p>Use <a href="/pdf/doctopdf">Word to PDF</a> / <a href="/pdf/exceltopdf">Excel to PDF</a> for office files — <a href="/pdf/htmltopdf">HTML to PDF</a> for web — not print dialog alone.</p>
            """,
    "mac-print-to-pdf": """
            <h2>macOS Save as PDF</h2>
            <p>File → Print → PDF dropdown → <strong>Save as PDF</strong> — Quartz vector PDF on every Mac app.</p>
            <h2>Preview app</h2>
            <p>Open PDF in Preview → File → Export — adjust Quartz filter for reduced file size — test print before bulk.</p>
            <h2>Handoff to RatPDF</h2>
            <p><a href="/pdf/compress">Compress</a> large exports · <a href="/pdf/merge">Merge</a> appendices · <a href="/pdf/flatten">Flatten</a> filled forms.</p>
            """,
    "print-pdf-from-ipad": """
            <h2>AirPrint</h2>
            <p>Share sheet → Print → select AirPrint MFP — check double-sided and range before tap Print.</p>
            <h2>Markup</h2>
            <p>Apple Markup annotations may not print on all drivers — flatten on desktop if recipient needs static copy.</p>
            <h2>Large files</h2>
            <p>Compress on desktop first if AirPrint stalls — <a href="/guides/compress-pdf-for-printing">compress for printing guide</a>.</p>
            """,
    "commercial-print-pdf-checklist": """
            <h2>Prepress checklist</h2>
            <ol>
            <li>CMYK or spot colors defined — not RGB-only for offset</li>
            <li>3mm bleed and crop marks in source app</li>
            <li>Fonts embedded or outlined</li>
            <li>Images 300 DPI at final print size</li>
            <li>Export <a href="/guides/pdf-x-print-standard">PDF/X-1a or PDF/X-4</a></li>
            <li>Preflight report attached to job ticket</li>
            </ol>
            <h2>RatPDF role</h2>
            <p>Email proof compression only — not prepress replacement — designer owns InDesign export.</p>
            """,
    "pdf-print-as-image": """
            <h2>When to enable</h2>
            <p>Printer advanced dialog → <strong>Print as image</strong> — rasterizes page — fixes blank output from bad transparency or corrupt font cache.</p>
            <h2>Trade-offs</h2>
            <p>File spools larger — text slightly softer — use for problem jobs not everyday letter PDFs.</p>
            <h2>Try first</h2>
            <p><a href="/pdf/flatten">Flatten PDF</a> — update printer driver — then print-as-image if still blank — see <a href="/guides/pdf-printing-blank-pages">blank pages guide</a>.</p>
            """,
}

W13_SLUG_EXTRA = {
    "compress-pdf-for-printing": """
            <h2>Print shop email</h2>
            <p>Vendor portal rejects 45 MB brochure — Less compression on copy hits 18 MB — plate master stays lossless on designer machine.</p>
            """,
    "flatten-pdf": """
            <h2>Court e-filing</h2>
            <p>CM/ECF rejects interactive form — flatten — page numbers via <a href="/guides/add-page-numbers">Add Page Numbers</a> — upload succeeds.</p>
            """,
    "print-to-pdf-windows": """
            <h2>Excel wide sheet</h2>
            <p>Landscape + fit all columns — one PDF for auditor — then <a href="/guides/merge-pdf">merge</a> with cover memo.</p>
            """,
    "edge-print-to-pdf": """
            <h2>Procurement audit</h2>
            <p>Save dated quote page PDF — metadata shows print time — attach to PO record.</p>
            """,
    "chrome-save-as-pdf-settings": """
            <h2>Marketing landing page</h2>
            <p>Background graphics on — headers off — client-ready PDF mockup without browser chrome.</p>
            """,
    "glossary-overprint": """
            <h2>Rich black</h2>
            <p>100% K alone looks gray on press — 40C 30M 30Y 100K with overprint — designer verifies in Acrobat Output Preview.</p>
            """,
    "glossary-flattened-pdf": """
            <h2>Signature field</h2>
            <p>After sign — flatten — signature becomes image — cannot be moved — required for recorded deed PDF package.</p>
            """,
    "pdf-printing-guide": """
            <h2>Helpdesk poster</h2>
            <p>Bookmark the troubleshooting guide — it covers blank print and margin questions.</p>
            """,
    "print-pdf-double-sided": """
            <h2>Handbook bindery</h2>
            <p>Long-edge duplex — fold — staple — verify page 1 is cover not blank separator sheet.</p>
            """,
    "print-pdf-black-and-white": """
            <h2>Discovery index</h2>
            <p>400 pages grayscale — 60% toner saving — color exhibits printed separately as exhibit binders.</p>
            """,
    "pdf-fit-to-page-printing": """
            <h2>A3 to letter</h2>
            <p>Custom 72% scale — dimension labels still readable — full bleed not possible without source re-export.</p>
            """,
    "embed-fonts-before-printing": """
            <h2>RFP body font</h2>
            <p>Calibri embed — MFP matches laptop — table alignment preserved — evaluators see professional layout.</p>
            """,
    "print-to-pdf-vs-save-as-pdf": """
            <h2>Hyperlink RFP</h2>
            <p>Save-as keeps TOC links — print-to-PDF flattens to static — compliance team chooses export path deliberately.</p>
            """,
    "mac-print-to-pdf": """
            <h2>Keynote client deck</h2>
            <p>Save as PDF — compress for email — links to appendix via <a href="/guides/merge-pdf">merge</a>.</p>
            """,
    "print-pdf-from-ipad": """
            <h2>Site inspection</h2>
            <p>Markup photo PDF on iPad — AirPrint to site office — flatten on desktop for permanent record.</p>
            """,
    "commercial-print-pdf-checklist": """
            <h2>First-time reject</h2>
            <p>Printer returns RGB-only PDF — designer re-exports PDF/X-1a — job passes preflight — reprint avoided.</p>
            """,
    "pdf-print-as-image": """
            <h2>CAD overlay</h2>
            <p>Vector transparency stack breaks driver — print-as-image — pages emerge readable — archive flattened copy.</p>
            """,
}

W13_MEGA = """
            <h2>Screen vs paper</h2>
            <p>PDFs optimized for screen (RGB, thin fonts, interactive layers) often fail on office lasers and commercial presses. Printing workflows separate <strong>proof</strong> (email PDF) from <strong>production</strong> (PDF/X, uncompressed master).</p>
            <h2>RatPDF print chain</h2>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>Step</th><th>Tool</th></tr></thead>
            <tbody>
            <tr><td>Flatten forms before print</td><td><a href="/pdf/flatten">Flatten PDF</a></td></tr>
            <tr><td>Compress email-to-shop copy</td><td><a href="/pdf/compress">Compress PDF</a></td></tr>
            <tr><td>Office export with fonts</td><td><a href="/pdf/doctopdf">Word to PDF</a></td></tr>
            <tr><td>Commercial standard</td><td><a href="/guides/pdf-x-print-standard">PDF/X guide</a></td></tr>
            </tbody>
            </table></div>
            <h2>Troubleshooting cross-link</h2>
            <p>Blank pages, wrong margins, and color shifts: see the <a href="/guides/pdf-troubleshooting">PDF troubleshooting guide</a>.</p>
            """

W13_CLUSTER = """
            <h2>Printing workflow guides</h2>
            <ul>
            <li><a href="/guides/compress-pdf-for-printing">Compress for printing</a> · <a href="/guides/flatten-pdf">Flatten PDF</a> · <a href="/guides/glossary-flattened-pdf">Flattened PDF glossary</a></li>
            <li><a href="/guides/print-to-pdf-windows">Windows print to PDF</a> · <a href="/guides/mac-print-to-pdf">Mac print to PDF</a> · <a href="/guides/print-pdf-from-ipad">iPad print</a></li>
            <li><a href="/guides/edge-print-to-pdf">Edge print to PDF</a> · <a href="/guides/chrome-save-as-pdf-settings">Chrome save as PDF</a></li>
            <li><a href="/guides/print-to-pdf-vs-save-as-pdf">Print vs save as PDF</a> · <a href="/guides/embed-fonts-before-printing">Embed fonts</a></li>
            <li><a href="/guides/print-pdf-double-sided">Double-sided</a> · <a href="/guides/print-pdf-black-and-white">Black and white</a> · <a href="/guides/pdf-fit-to-page-printing">Fit to page</a></li>
            <li><a href="/guides/pdf-print-as-image">Print as image</a> · <a href="/guides/commercial-print-pdf-checklist">Commercial print checklist</a></li>
            <li><a href="/guides/glossary-overprint">Overprint glossary</a> · <a href="/guides/pdf-x-print-standard">PDF/X</a></li>
            <li><a href="/guides/pdf-printing-blank-pages">Blank pages</a> · <a href="/guides/print-pdf-without-margins">Margins</a> · <a href="/guides/pdf-colors-wrong-when-printing">Colors wrong</a></li>
            </ul>
            <p>Hub: <a href="/guides/pdf-printing-guide">PDF printing guide</a> · <a href="/guides/pdf-standards-archiving-hub">Standards hub</a>.</p>
            """

W13_1500_TOPUP = """
            <h2>Print QA checklist</h2>
            <ol>
            <li>Master copy archived uncompressed</li>
            <li>Form fields flattened if printing or filing</li>
            <li>Fonts embedded or outlined in source</li>
            <li>Test page printed at actual size</li>
            <li>Color intent matches job (office RGB vs press CMYK)</li>
            <li>Commercial jobs use PDF/X preflight</li>
            </ol>
            <h2>Research</h2>
            <p><a href="/guides/pdf-troubleshooting">Troubleshooting</a> · <a href="/guides/pdf-x-print-standard">PDF/X</a> · <a href="/guides/compress-pdf-guide">Compression guide</a>.</p>
            """

W13_CLOSING = """
            <h2>Related guides</h2>
            <p>Printing workflow guides cover print-to-PDF on any device, quality settings, flattening forms, and commercial print handoff — plus links to troubleshooting and PDF/X standards.</p>
            <p>Browser and device guides — bookmark the <a href="/guides/pdf-printing-guide">printing hub</a>.</p>
            """

PILLAR_SLUGS = {"pdf-printing-guide"}
