"""Wave 36 — Glossary authority final batch (10 terms) — completes UPGRADE queue."""

W36_SLUGS = [
    "glossary-type1-font",
    "glossary-unicode-mapping",
    "glossary-user-password",
    "glossary-vector-graphics",
    "glossary-wasm-pdf",
    "glossary-winansi",
    "glossary-writer-export",
    "glossary-xfa-forms",
    "glossary-xmp-metadata",
    "glossary-zugferd",
]

GLOSSARY_SLUGS = set(W36_SLUGS)

W36_DATA = {
    "glossary-type1-font": {
        "title": "What Is Type 1 Font in PDF? — PostScript Outlines (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/glossary-truetype",
        "pillar_label": "TrueType glossary",
        "related": "/guides/glossary-type0-font",
        "example": "Legacy annual report embeds Type 1 Helvetica — still renders — subset prefix ABCDEF+Helvetica",
    },
    "glossary-unicode-mapping": {
        "title": "What Is Unicode Mapping in PDF? — Glyphs to Unicode (2026)",
        "tool": "/pdf/ocrpdf",
        "label": "OCR PDF",
        "pillar": "/guides/glossary-toUnicode",
        "pillar_label": "ToUnicode glossary",
        "related": "/guides/glossary-encoding",
        "example": "Discovery search misses Cyrillic names — PDF lacks Unicode map — OCR rebuilds text layer",
    },
    "glossary-user-password": {
        "title": "What Is PDF User Password? — Open Document Passphrase (2026)",
        "tool": "/pdf/password",
        "label": "Protect PDF",
        "pillar": "/guides/pdf-encryption-aes-explained",
        "pillar_label": "PDF encryption AES",
        "related": "/guides/pdf-password-best-practices",
        "example": "HR sets user password on payslip PDF — employee must enter passphrase to open attachment",
    },
    "glossary-vector-graphics": {
        "title": "What Are Vector Graphics in PDF? — Paths vs Raster (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/glossary-raster-image",
        "pillar_label": "raster image glossary",
        "related": "/guides/beginner-what-is-a-pdf",
        "example": "Logo drawn as vector paths stays sharp at 400% zoom — PNG logo in same PDF blurs",
    },
    "glossary-wasm-pdf": {
        "title": "What Is WASM PDF Processing? — WebAssembly in Browser (2026)",
        "tool": "/guides/browser-vs-desktop-pdf-tools",
        "label": "browser vs desktop PDF",
        "pillar": "/guides/glossary-client-side-pdf",
        "pillar_label": "client-side PDF glossary",
        "related": "/guides/glossary-pdfjs",
        "example": "RatPDF runs Ghostscript port in WASM — compress in tab — file never uploaded to server",
    },
    "glossary-winansi": {
        "title": "What Is WinAnsi Encoding in PDF? — Western European Text (2026)",
        "tool": "/pdf/ocrpdf",
        "label": "OCR PDF",
        "pillar": "/guides/glossary-encoding",
        "pillar_label": "encoding glossary",
        "related": "/guides/glossary-cmap",
        "example": "French invoice PDF copies é correctly — WinAnsiEncoding — Polish ł breaks without ToUnicode",
    },
    "glossary-writer-export": {
        "title": "What Is LibreOffice Writer Export to PDF? — ODT to PDF (2026)",
        "tool": "/pdf/doctopdf",
        "label": "Word to PDF",
        "pillar": "/guides/glossary-libreoffice-headless",
        "pillar_label": "LibreOffice headless glossary",
        "related": "/guides/word-to-pdf",
        "example": "NGO exports grant proposal ODT to PDF — embed fonts checked — hyperlinks blue in output",
    },
    "glossary-xfa-forms": {
        "title": "What Are XFA Forms in PDF? — XML Forms Architecture (2026)",
        "tool": "/pdf/flattenpdf",
        "label": "Flatten PDF",
        "pillar": "/guides/glossary-acroform",
        "pillar_label": "AcroForm glossary",
        "related": "/guides/glossary-form-field",
        "example": "Government tax PDF uses XFA — free viewers show blank — flatten to AcroForm for clients",
    },
    "glossary-xmp-metadata": {
        "title": "What Is XMP Metadata in PDF? — Extensible Metadata Platform (2026)",
        "tool": "/pdf/pdfmetadata",
        "label": "PDF Metadata",
        "pillar": "/guides/glossary-metadata",
        "pillar_label": "metadata glossary",
        "related": "/guides/pdf-metadata-remove",
        "example": "Dublin Core title in XMP packet — search index picks keywords — author field leaks partner name",
    },
    "glossary-zugferd": {
        "title": "What Is ZUGFeRD? — Hybrid PDF Invoice Germany (2026)",
        "tool": "/invoice/create",
        "label": "Create Invoice",
        "pillar": "/guides/glossary-factur-x",
        "pillar_label": "Factur-X glossary",
        "related": "/guides/glossary-e-invoice",
        "example": "German B2B invoice PDF/A-3 embeds ZUGFeRD XML — accountant views PDF — ERP parses EN16931",
    },
}

W36_DEEP = {
    "glossary-type1-font": """
            <h2>Definition</h2>
            <p><strong>Type 1 fonts</strong> are PostScript outline fonts — classic PDF embed format — .pfb + metrics — still common in older print PDFs — prefix ABCDEF+FontName indicates subset.</p>
            <h2>vs TrueType and Type 0</h2>
            <ul>
            <li><strong>Type 1:</strong> Latin body text — simple embed</li>
            <li><strong>TrueType:</strong> — <a href="/guides/glossary-truetype">TrueType glossary</a></li>
            <li><strong>Type 0:</strong> CJK composite — <a href="/guides/glossary-type0-font">Type 0</a></li>
            </ul>
            <p>Subset: <a href="/guides/glossary-subset-fonts">subset fonts</a> · missing: <a href="/guides/pdf-fonts-missing">fonts missing</a> · <a href="/pdf/compress">Compress PDF</a>.</p>
            """,
    "glossary-unicode-mapping": """
            <h2>Definition</h2>
            <p><strong>Unicode mapping</strong> links PDF glyph IDs to Unicode code points — via <a href="/guides/glossary-toUnicode">ToUnicode CMap</a> or embedded cmap — enables search, copy, accessibility, and extract.</p>
            <h2>When mapping fails</h2>
            <ul>
            <li>Custom corporate font without cmap</li>
            <li>Legacy scan without text layer</li>
            <li>Broken Identity-H export</li>
            </ul>
            <p>Remediation: re-export — <a href="/guides/glossary-cmap">CMap</a> · <a href="/guides/glossary-encoding">encoding</a> · <a href="/pdf/ocrpdf">OCR PDF</a> · <a href="/pdf/pdftotext">PDF to Text</a>.</p>
            """,
    "glossary-user-password": """
            <h2>Definition</h2>
            <p>The <strong>user password</strong> (document open password) is required to decrypt and view PDF — distinct from <strong>owner password</strong> which sets print/copy permissions without blocking open in some configs.</p>
            <h2>Best practice</h2>
            <ol>
            <li>Strong unique passphrase per sensitive file</li>
            <li>Share on separate channel — <a href="/guides/password-protect-before-email">before email</a></li>
            <li>AES-256 where supported — <a href="/guides/pdf-encryption-aes-explained">AES explained</a></li>
            </ol>
            <p>Tool: <a href="/pdf/password">Protect PDF</a> · hub: <a href="/guides/pdf-password-best-practices">password best practices</a> · unlock: <a href="/guides/unlock-pdf">unlock PDF</a>.</p>
            """,
    "glossary-vector-graphics": """
            <h2>Definition</h2>
            <p><strong>Vector graphics</strong> in PDF are Bézier paths, lines, and fills — resolution-independent — logos and charts stay crisp — contrast <a href="/guides/glossary-raster-image">raster images</a> (fixed pixels).</p>
            <h2>When PDFs bloat</h2>
            <p>Designers paste PNG instead of SVG — file grows — convert to vector in source — compress helps raster not vectors much — <a href="/pdf/compress">Compress PDF</a> · <a href="/guides/why-is-pdf-file-so-large">why large</a>.</p>
            """,
    "glossary-wasm-pdf": """
            <h2>Definition</h2>
            <p><strong>WebAssembly (WASM)</strong> runs compiled code in browser at near-native speed — PDF tools port Ghostscript or parsers to WASM — processing stays client-side — privacy advantage over upload APIs.</p>
            <h2>Trade-offs</h2>
            <ul>
            <li>Initial download of WASM module</li>
            <li>Memory limits on mobile Safari</li>
            <li>Large files may still choke tab</li>
            </ul>
            <p>Compare: <a href="/guides/glossary-pdfjs">PDF.js</a> (render) vs WASM (transform) · <a href="/guides/glossary-client-side-pdf">client-side</a> · <a href="/home/security">security page</a>.</p>
            """,
    "glossary-winansi": """
            <h2>Definition</h2>
            <p><strong>WinAnsiEncoding</strong> is single-byte encoding for Western European PDF text — Windows-1252 compatible — 256 code slots — fine for English and Western EU if font has glyphs.</p>
            <h2>Limits</h2>
            <p>Polish, Turkish, Vietnamese need full Unicode embed — WinAnsi fails — use ToUnicode or CID — <a href="/guides/glossary-encoding">encoding overview</a> · <a href="/guides/glossary-toUnicode">ToUnicode</a> · OCR fallback <a href="/pdf/ocrpdf">OCR PDF</a>.</p>
            """,
    "glossary-writer-export": """
            <h2>Definition</h2>
            <p><strong>LibreOffice Writer</strong> exports documents to PDF via File → Export as PDF — controls for image compression, forms, bookmarks, tagged PDF, and font embedding.</p>
            <h2>Checklist before export</h2>
            <ol>
            <li>Embed fonts checkbox on</li>
            <li>Tagged PDF for accessibility if public</li>
            <li>Reduce image DPI for email</li>
            <li>Export PDF/A if archive required</li>
            </ol>
            <p>Server batch: <a href="/guides/glossary-libreoffice-headless">headless</a> · browser: <a href="/pdf/doctopdf">Word to PDF</a> · <a href="/guides/word-to-pdf">Word to PDF guide</a>.</p>
            """,
    "glossary-xfa-forms": """
            <h2>Definition</h2>
            <p><strong>XFA (XML Forms Architecture)</strong> is dynamic form format inside some PDFs — common in government and legacy enterprise — separate XML stream from AcroForm — many free viewers cannot display XFA.</p>
            <h2>Remediation</h2>
            <ul>
            <li>Open in Acrobat — export static PDF</li>
            <li>Print to PDF (last resort — check labels)</li>
            <li>Request AcroForm version from issuer</li>
            </ul>
            <p>Compare <a href="/guides/glossary-acroform">AcroForm</a> · <a href="/guides/glossary-form-field">form fields</a> · flatten: <a href="/pdf/flattenpdf">Flatten PDF</a>.</p>
            """,
    "glossary-xmp-metadata": """
            <h2>Definition</h2>
            <p><strong>XMP (Extensible Metadata Platform)</strong> is XML metadata packet in PDF — title, author, keywords, rights, Dublin Core — readable by DAM and search systems — separate from document info dictionary.</p>
            <h2>Privacy</h2>
            <p>Author and company fields leak on external share — strip before send — <a href="/pdf/pdfmetadata">PDF Metadata</a> · guide: <a href="/guides/pdf-metadata-remove">metadata remove</a> · not a substitute for <a href="/guides/pdf-redaction">redaction</a>.</p>
            """,
    "glossary-zugferd": """
            <h2>Definition</h2>
            <p><strong>ZUGFeRD</strong> (Germany) is hybrid invoice — PDF/A-3 visual invoice plus embedded EN16931 XML — Comfort / Basic / Extended profiles — Basis for European <a href="/guides/glossary-factur-x">Factur-X</a>.</p>
            <h2>Workflow</h2>
            <ol>
            <li>ERP generates ZUGFeRD PDF</li>
            <li>Buyer views human PDF</li>
            <li>AP system extracts XML for posting</li>
            <li>Peppol may carry same XML — <a href="/guides/glossary-peppol">Peppol</a></li>
            </ol>
            <p>Create visual PDF: <a href="/invoice/create">Create Invoice</a> · <a href="/guides/glossary-e-invoice">e-invoice</a> · India equivalent: <a href="/guides/glossary-irn">IRN</a>.</p>
            """,
}

W36_GLOSSARY_CLUSTER = """
            <h2>Glossary final batch — Wave 36</h2>
            <ul>
            <li><a href="/guides/glossary-type1-font">Type 1 font</a> · <a href="/guides/glossary-truetype">TrueType</a> · <a href="/guides/glossary-type0-font">Type 0</a></li>
            <li><a href="/guides/glossary-unicode-mapping">Unicode mapping</a> · <a href="/guides/glossary-toUnicode">ToUnicode</a> · <a href="/guides/glossary-winansi">WinAnsi</a></li>
            <li><a href="/guides/glossary-user-password">User password</a> · <a href="/guides/pdf-encryption-aes-explained">AES encryption</a></li>
            <li><a href="/guides/glossary-vector-graphics">Vector graphics</a> · <a href="/guides/glossary-raster-image">Raster image</a></li>
            <li><a href="/guides/glossary-wasm-pdf">WASM PDF</a> · <a href="/guides/glossary-pdfjs">PDF.js</a> · <a href="/guides/glossary-client-side-pdf">Client-side</a></li>
            <li><a href="/guides/glossary-writer-export">Writer export</a> · <a href="/guides/glossary-libreoffice-headless">Headless</a></li>
            <li><a href="/guides/glossary-xfa-forms">XFA forms</a> · <a href="/guides/glossary-acroform">AcroForm</a></li>
            <li><a href="/guides/glossary-xmp-metadata">XMP metadata</a> · <a href="/guides/glossary-metadata">Metadata</a></li>
            <li><a href="/guides/glossary-zugferd">ZUGFeRD</a> · <a href="/guides/glossary-factur-x">Factur-X</a> · <a href="/guides/glossary-peppol">Peppol</a></li>
            </ul>
            <p>Hub: <a href="/guides/pdf-glossary-hub">PDF glossary hub</a> — <strong>UPGRADE queue complete</strong></p>
            """

W36_GLOSSARY_TOPUP = """
            <h2>Final glossary map — fonts to e-invoice</h2>
            <ul>
            <li><strong>Fonts:</strong> Type1 → TrueType → Type0 → subset → Unicode map</li>
            <li><strong>Security:</strong> user password → AES → channel separation</li>
            <li><strong>Client tech:</strong> PDF.js render · WASM transform · no server upload</li>
            <li><strong>Forms:</strong> AcroForm (portable) vs XFA (legacy dynamic)</li>
            <li><strong>Metadata:</strong> XMP packet vs Document Info · strip before external send</li>
            <li><strong>EU invoice:</strong> ZUGFeRD → Factur-X → Peppol XML</li>
            </ul>
            """

W36_CLOSING = """
            <h2>UPGRADE complete</h2>
            <p>Wave 36 finishes the final ten glossary UPGRADE pages — all <strong>406/406</strong> priority UPGRADE slugs now have authority bodies in GuideBodiesWave* layers.</p>
            <p>Next programme phase: <strong>CREATE</strong> (450) and <strong>MAINTAIN</strong> (145) per roadmap — hub: <a href="/guides/pdf-glossary-hub">PDF glossary hub</a> · <a href="/guides/pdf-tools">PDF tools</a></p>
            """
