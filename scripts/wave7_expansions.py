"""Wave 7 — Pillar authority upgrades (2500+ words each)."""

PILLAR_SLUGS = [
    "compress-pdf-guide",
    "merge-pdf",
    "split-pdf",
    "pdf-to-word",
    "ocr-pdf",
]

PILLAR_META = {
    "compress-pdf-guide": {
        "title": "How to Compress PDF Online — Complete Guide (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
    },
    "merge-pdf": {
        "title": "Merge PDF Online — Combine Files Free in Browser (2026)",
        "tool": "/pdf/merge",
        "label": "Merge PDF",
    },
    "split-pdf": {
        "title": "Split PDF Online — Extract Pages &amp; Ranges (2026)",
        "tool": "/pdf/split",
        "label": "Split PDF",
    },
    "pdf-to-word": {
        "title": "PDF to Word Converter — Edit PDFs in DOCX Online (2026)",
        "tool": "/pdf/pdftodoc",
        "label": "PDF to Word",
    },
    "ocr-pdf": {
        "title": "OCR PDF Online — Make Scanned PDFs Searchable (2026)",
        "tool": "/pdf/ocrpdf",
        "label": "OCR PDF",
    },
}

SHARED_PILLAR = """
            <h2>Why RatPDF for browser PDF workflows</h2>
            <p>No install, no IT ticket — upload, process, download. Free tier: three uses per tool per day. Confidential docs: review <a href="/home/privacy">privacy policy</a> and <a href="/home/security">security page</a> before uploading client contracts.</p>
            <h2>Tool chain after this task</h2>
            <p>Most PDF jobs chain tools: OCR → edit → merge → compress → sign. Start here: <a href="/guides/pdf-tools">PDF tools guide</a> · Compare vendors: <a href="/compare">compare tools</a>.</p>
            <h2>Research &amp; data</h2>
            <p><a href="/research/attachment-size-limits">Email attachment limits</a> · <a href="/research/pdf-compression-benchmark">PDF compression benchmark</a> · <a href="/research/pdf-tool-market-comparison">PDF tool market comparison</a>.</p>
            """

COMPRESS_PILLAR = """
            <h2>Why PDF file size blocks real work</h2>
            <p>Gmail caps messages around 25 MB. Outlook tenants often enforce 20 MB. Government portals reject 4.8 MB scans when the slot allows 2 MB. Job boards silently fail uploads. The fix is almost always <strong>re-encoding embedded images</strong> — not retyping the document.</p>
            <p>RatPDF <a href="/pdf/compress">Compress PDF</a> uses <strong>Ghostscript</strong> with three profiles: Less, Recommended, and Extreme.</p>
            <h2>Compression levels — when to use each</h2>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>Level</th><th>Best for</th><th>Avoid when</th></tr></thead>
            <tbody>
            <tr><td><strong>Less</strong></td><td>Signed forms, notary stamps, legal footnotes</td><td>Need maximum size drop on photo brochures</td></tr>
            <tr><td><strong>Recommended</strong></td><td>Email, LMS, most portals — default</td><td>Already-tiny digital PDF</td></tr>
            <tr><td><strong>Extreme</strong></td><td>Last resort when portal still rejects</td><td>Fine print must stay legible</td></tr>
            </tbody>
            </table></div>
            <h2>Step-by-step: compress PDF in browser</h2>
            <ol>
            <li>Check size with <a href="/pdf-size-checker">PDF size checker</a>.</li>
            <li>Open <a href="/pdf/compress">Compress PDF</a>.</li>
            <li>Start with <strong>Recommended</strong>.</li>
            <li>Verify stamps and small text at 150% zoom.</li>
            <li>Still over cap? Extreme once, or <a href="/guides/split-pdf-for-email">split for email</a>.</li>
            </ol>
            <h2>Real example: 18 MB expense scan → Gmail</h2>
            <p>40 receipts scanned → Recommended → 5.2 MB → sent with claim ID in subject.</p>
            <h2>Real example: visa bundle → VFS 5 MB cap</h2>
            <p><a href="/guides/merge-pdf-visa-application">Merge visa docs</a> first, then one Recommended compress. Verify MRZ legibility.</p>
            <h2>Scanned vs digital</h2>
            <p>Scans compress 50–70%; digital Word exports often 10–25%. <a href="/guides/compress-scanned-vs-digital-pdf">Scanned vs digital guide</a>.</p>
            <h2>When compression increases size</h2>
            <p><a href="/guides/compress-pdf-made-it-larger">Why compression made PDF larger</a>.</p>
            <h2>Device &amp; portal guides</h2>
            <ul>
            <li><a href="/guides/compress-pdf-on-mac">Mac</a> · <a href="/guides/compress-pdf-on-windows">Windows</a> · <a href="/guides/compress-pdf-on-iphone">iPhone</a></li>
            <li><a href="/guides/compress-pdf-for-gmail">Gmail</a> · <a href="/guides/compress-pdf-for-email">Email hub</a> · <a href="/guides/compress-pdf-for-visa-application">Visa</a></li>
            <li><a href="/guides/batch-compress-pdf">Batch</a> · <a href="/guides/ghostscript-pdf-compression">Ghostscript explained</a></li>
            </ul>
            <h2>FAQ — compress PDF</h2>
            <p><strong>Free?</strong> Three/day free tier. <strong>Text selectable?</strong> Yes on digital PDFs. <strong>Encrypted?</strong> <a href="/guides/unlock-pdf">Unlock first</a>.</p>
            """

MERGE_PILLAR = """
            <h2>Why merge PDF files</h2>
            <p>One attachment beats three confusing emails. RatPDF <a href="/pdf/merge">Merge PDF</a> uses iText smart mode — vectors stay sharp.</p>
            <h2>Step-by-step</h2>
            <ol>
            <li>Unlock encrypted sources.</li>
            <li>Prefix filenames <code>01-</code> <code>02-</code> in order.</li>
            <li>Upload to <a href="/pdf/merge">Merge PDF</a>.</li>
            <li>Verify page count = sum of parts.</li>
            <li><a href="/guides/compress-pdf-guide">Compress</a> if email rejects.</li>
            </ol>
            <h2>Real example: job pack</h2>
            <p>Cover + resume + portfolio → merge → compress → Indeed upload.</p>
            <h2>Real example: court exhibits</h2>
            <p><a href="/guides/merge-pdf-court-filing">Court filing merge</a> in index order — OCR scans before merge if search required.</p>
            <h2>Merge vs ZIP</h2>
            <p>One scrollable doc → merge. Separate files → ZIP. Multi-slot portal → usually do not merge.</p>
            <h2>Spokes</h2>
            <ul>
            <li><a href="/guides/merge-pdf-visa-application">Visa</a> · <a href="/guides/merge-pdf-without-quality-loss">Quality</a></li>
            <li><a href="/guides/merge-password-protected-pdf">Password-protected</a> · <a href="/guides/organize-pdf-pages">Organize pages</a></li>
            <li><a href="/guides/combine-then-compress-pdf">Merge then compress</a></li>
            </ul>
            <h2>FAQ — merge PDF</h2>
            <p><strong>Bookmarks?</strong> Often preserved. <strong>Corrupt file?</strong> Fails whole job — fix source.</p>
            """

SPLIT_PILLAR = """
            <h2>Why split PDF</h2>
            <p>Email caps, exhibit extracts, chapter handouts. <a href="/pdf/split">Split PDF</a> copies pages without re-scan.</p>
            <h2>Range syntax</h2>
            <p><code>7</code>, <code>1-30</code>, <code>1-2, 7, 10-12</code> — no overlapping ranges.</p>
            <h2>Step-by-step</h2>
            <ol>
            <li>Try <a href="/guides/compress-pdf-guide">compress</a> first if one attachment needed.</li>
            <li>Pick logical breaks (chapters, exhibits).</li>
            <li>Split — name <code>Part1-of-3</code> files.</li>
            <li>Index ranges in email body.</li>
            </ol>
            <h2>Real example: 120-page discovery</h2>
            <p>Three parts under 20 MB each for Gmail — Bates index in cover email.</p>
            <h2>Spokes</h2>
            <ul>
            <li><a href="/guides/split-pdf-for-email">Split for email</a> · <a href="/guides/split-pdf-by-size">By size</a></li>
            <li><a href="/guides/split-pdf-page-range">Page range</a> · <a href="/guides/extract-single-page-pdf">Single page</a></li>
            <li><a href="/guides/compress-vs-split">Compress vs split</a></li>
            </ul>
            <h2>FAQ — split PDF</h2>
            <p><strong>Quality loss?</strong> No — inherits source DPI.</p>
            """

WORD_PILLAR = """
            <h2>Why PDF to Word</h2>
            <p>Redlines, resume edits, proposal updates. <a href="/pdf/pdftodoc">PDF to Word</a> uses pdf2docx + fallbacks.</p>
            <h2>10-second test</h2>
            <p>Text selects → convert. No selection → <a href="/pdf/ocrpdf">OCR</a> first.</p>
            <h2>Step-by-step</h2>
            <ol>
            <li>Upload to <a href="/pdf/pdftodoc">PDF to Word</a>.</li>
            <li>Open DOCX — verify tables page 1.</li>
            <li>Track changes for legal edits.</li>
            <li>Re-export <a href="/pdf/doctopdf">Word to PDF</a> for delivery.</li>
            </ol>
            <h2>Real examples</h2>
            <p>Contract redline: <a href="/guides/convert-contract-pdf-to-word">contract guide</a>. Resume: <a href="/guides/pdf-to-word-resume">resume guide</a>.</p>
            <h2>Spokes</h2>
            <ul>
            <li><a href="/guides/pdf-to-word-keep-formatting">Keep formatting</a> · <a href="/guides/scanned-pdf-to-word">Scanned workflow</a></li>
            <li><a href="/guides/pdf-to-word-mac">Mac</a> · <a href="/guides/pdf-to-word-without-word">Without Word</a></li>
            <li><a href="/guides/pdf-to-word-vs-pdf-to-text">vs PDF to Text</a></li>
            </ul>
            <h2>FAQ — PDF to Word</h2>
            <p><strong>Tables?</strong> Usually on digital PDFs. <strong>Signed executed PDF?</strong> Do not convert — archive as-is.</p>
            """

OCR_PILLAR = """
            <h2>What OCR does</h2>
            <p>Adds searchable text layer to scans. <a href="/pdf/ocrpdf">OCR PDF</a> via Tesseract.</p>
            <h2>Step-by-step</h2>
            <ol>
            <li>Scan 300 DPI grayscale.</li>
            <li>Upload to <a href="/pdf/ocrpdf">OCR PDF</a>.</li>
            <li>Test Ctrl+F for known term.</li>
            <li>Then Word or Text export as needed.</li>
            </ol>
            <h2>OCR vs Text</h2>
            <p><a href="/guides/ocr-vs-pdf-to-text">OCR vs PDF to Text</a> decision tree.</p>
            <h2>Language guides</h2>
            <ul>
            <li><a href="/guides/ocr-pdf-hindi">Hindi</a> · <a href="/guides/ocr-pdf-arabic">Arabic</a> · <a href="/guides/ocr-pdf-chinese">Chinese</a></li>
            <li><a href="/guides/ocr-pdf-spanish">Spanish</a> · <a href="/guides/ocr-pdf-french">French</a> · <a href="/guides/ocr-pdf-german">German</a></li>
            </ul>
            <h2>Workflows</h2>
            <ul>
            <li><a href="/guides/scanned-pdf-to-word">Scanned to Word</a> · <a href="/guides/ocr-pdf-ediscovery">E-discovery</a></li>
            <li><a href="/guides/ocr-scanned-pdf-workflow">Full OCR workflow</a></li>
            </ul>
            <h2>FAQ — OCR</h2>
            <p><strong>Handwriting?</strong> Poor accuracy — retype critical fields.</p>
            """

PILLAR_DEEP = {
    "compress-pdf-guide": COMPRESS_PILLAR,
    "merge-pdf": MERGE_PILLAR,
    "split-pdf": SPLIT_PILLAR,
    "pdf-to-word": WORD_PILLAR,
    "ocr-pdf": OCR_PILLAR,
}

W7_2500_TOPUP = """
            <h2>Corporate rollout checklist</h2>
            <ol><li>IT wiki tool list</li><li>Digital vs scan tree</li><li>Filename versioning</li><li>MB log for tickets</li></ol>
            <h2>Security</h2>
            <p><a href="/guides/secure-pdf-workflow">Secure PDF workflow</a> · <a href="/guides/password-protect-pdf">Password protect</a>.</p>
            """

PILLAR_SUPPLEMENT = {
    "compress-pdf-guide": """
            <h2>Industry compression playbooks</h2>
            <h3>Legal</h3>
            <p>Exhibits with notary seals — Less only. E-filing: <a href="/guides/compress-pdf-efiling">e-filing compress</a> · <a href="/guides/compress-pdf-lawyers">lawyers guide</a>.</p>
            <h3>Healthcare admin</h3>
            <p>Payer portals — <a href="/guides/compress-pdf-healthcare-admin">healthcare compress</a> — PHI stays encrypted in transit; delete Downloads after upload.</p>
            <h3>Education</h3>
            <p>LMS caps — <a href="/guides/compress-pdf-for-lms">LMS compress</a> · <a href="/guides/compress-pdf-students">students</a> · <a href="/guides/compress-pdf-teachers">teachers</a>.</p>
            <h3>Real estate</h3>
            <p>Disclosure packs — <a href="/guides/compress-pdf-real-estate">real estate compress</a> — merge disclosures first if one attachment.</p>
            <h2>Monitoring compression ROI</h2>
            <p>Log before/after MB per document type quarterly — patterns reveal scan DPI problems vs tool choice problems. Cite <a href="/research/pdf-compression-benchmark">benchmark study</a> when training staff.</p>
            <h2>Compare compress tools</h2>
            <p><a href="/compare/smallpdf-alternative">Smallpdf</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/pdf24-alternative">PDF24</a> · <a href="/compare/adobe-acrobat-alternative">Adobe</a>.</p>
            """,
    "merge-pdf": """
            <h2>Bookmark and navigation after merge</h2>
            <p>Long merged packs benefit from bookmarks — RatPDF outputs linear PDF; add bookmarks in desktop editor if counsel requires. For board packs, cover page PDF with hyperlinked agenda still helps recipients.</p>
            <h2>File size planning</h2>
            <p>Sum source MB before merge — if over email cap, plan one compress pass after merge not per-file Extreme passes. <a href="/guides/merge-vs-compress">Merge vs compress</a>.</p>
            <h2>Accessibility after merge</h2>
            <p>Tagged structure may not survive — screen reader order can jump at file boundaries. For accessible deliverables, remediate after merge or deliver tagged master separately.</p>
            <h2>Industry merge playbooks</h2>
            <p>Insurance claims chronological photos — real estate disclosure order — student weekly readings numeric prefix — accountant board pack index matching filenames.</p>
            <h2>Compare merge tools</h2>
            <p><a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/smallpdf-alternative">Smallpdf</a> · <a href="/compare/adobe-acrobat-alternative">Adobe</a>.</p>
            """,
    "split-pdf": """
            <h2>Bates numbering and split</h2>
            <p>Apply Bates before split if production requires sequential numbers across parts — splitting after numbering avoids duplicate ranges. Coordinate with opposing counsel on multi-part production format.</p>
            <h2>Insurance and claims splits</h2>
            <p>Adjuster rejects 45 MB photo PDF — split by damage area — Part 1 roof, Part 2 interior — same claim number in each filename.</p>
            <h2>University thesis appendices</h2>
            <p>Portal 50 MB — main body one file — appendices A–F separate uploads — index lists appendix letter per file.</p>
            <h2>Recipient merge hint</h2>
            <p>Include in email: "Merge parts with Merge PDF tool in checklist order" — reduces support calls from non-technical recipients.</p>
            <h2>Compare split tools</h2>
            <p><a href="/compare/sejda-alternative">Sejda</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/smallpdf-alternative">Smallpdf</a>.</p>
            """,
    "pdf-to-word": """
            <h2>Table and logo QA checklist</h2>
            <ol>
            <li>Row counts match source PDF</li>
            <li>Currency symbols correct encoding</li>
            <li>Logo not replaced with grey box</li>
            <li>Numbered lists 1.1, 1.2 intact</li>
            <li>Footnotes and hyperlinks tested</li>
            </ol>
            <h2>Editor paths without Office</h2>
            <p>Google Docs upload DOCX — LibreOffice Writer — Word Online free tier. <a href="/guides/pdf-to-word-without-word">Without Word guide</a>.</p>
            <h2>Batch conversion discipline</h2>
            <p>One file per session on free tier — queue overnight — OCR scans first — name outputs <code>Client-doc-v2.docx</code> immediately.</p>
            <h2>Compare conversion tools</h2>
            <p><a href="/compare/adobe-acrobat-alternative">Adobe</a> · <a href="/compare/smallpdf-alternative">Smallpdf</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a>.</p>
            """,
    "ocr-pdf": """
            <h2>Scanner hardware profiles</h2>
            <p>Save TWAIN preset OCR-300dpi-gray — one-click rescan when QA fails. Avoid colour mode unless stamps need hue.</p>
            <h2>Batch overnight OCR</h2>
            <p>Paralegal queues 40 discovery scans — OCR each morning — grep privilege terms in viewer — open PDF only for hits.</p>
            <h2>GDPR and HIPAA</h2>
            <p>Identity docs and medical admin scans — HTTPS upload — delete local copies after HR/clinical task — enterprise AI ingest prohibited without DPA.</p>
            <h2>OCR then compress order</h2>
            <p>Always OCR before compress on scans needing search — compress after OCR adds text layer — file may grow then shrink.</p>
            <h2>Compare OCR tools</h2>
            <p><a href="/guides/tesseract-vs-online-ocr">Tesseract vs online</a> · <a href="/compare/adobe-acrobat-alternative">Adobe</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a>.</p>
            """,
}

PILLAR_FINAL = {
    "compress-pdf-guide": """
            <h2>Month-end AP batch workflow</h2>
            <p>Forty vendor invoice PDFs — compress each Recommended — verify line items legible — attach individually. Free tier three/day — prioritize largest files or upgrade.</p>
            <h2>Construction permit upload</h2>
            <p>Site photo PDF 22 MB — Less preserves stamp — portal 10 MB — split drawings if still over.</p>
            <h2>Related guides</h2>
            <p><a href="/guides/why-is-pdf-file-so-large">Why PDF so large</a> · <a href="/guides/pdf-email-attachment-checklist">Email checklist</a> · <a href="/guides/compress-pdf-cloud-storage">Cloud storage</a>.</p>
            """,
    "merge-pdf": """
            <h2>Month-end board pack SOP</h2>
            <p>Merge CFO memo, P&amp;L, auditor letter with 01-03 prefix — compress once — upload to board portal.</p>
            <h2>Technical QA matrix</h2>
            <p>Page count = sum of sources · Ctrl+F works on digital pages · no sideways thumbnails · under size cap.</p>
            """,
    "split-pdf": """
            <h2>Accounting workpaper split</h2>
            <p>80 MB audit file → Parts 1–4 under 20 MB — index email lists section titles per part.</p>
            <h2>Binary search size split</h2>
            <p>Halve page ranges until each part passes <a href="/pdf-size-checker">size checker</a> — log ranges in manifest spreadsheet.</p>
            <h2>Related split guides</h2>
            <p><a href="/guides/split-pdf-for-email">Email</a> · <a href="/guides/split-pdf-by-size">By size</a> · <a href="/guides/split-pdf-page-range">Range</a> · <a href="/guides/extract-single-page-pdf">Single page</a>.</p>
            """,
    "pdf-to-word": """
            <h2>Procurement quote redline</h2>
            <p>CRM quote PDF → Word → discount line track changes → export PDF for client.</p>
            <h2>Failure recovery</h2>
            <p>Garbled output — OCR first — <a href="/guides/pdf-to-word-garbled-text">garbled text fixes</a> — request native DOCX from sender.</p>
            <h2>Related conversion guides</h2>
            <p><a href="/guides/convert-nda-pdf-to-word">NDA</a> · <a href="/guides/convert-purchase-order-pdf-to-word">PO</a> · <a href="/guides/convert-bank-statement-pdf-to-word">Bank</a> · <a href="/guides/convert-transcript-pdf-to-word">Transcript</a>.</p>
            """,
    "ocr-pdf": """
            <h2>FOIA and compliance corpus</h2>
            <p>OCR policy scans — grep retention terms — cite original PDF page in findings.</p>
            <h2>Related OCR guides</h2>
            <p><a href="/guides/ocr-pdf-russian">Russian</a> · <a href="/guides/ocr-pdf-korean">Korean</a> · <a href="/guides/ocr-pdf-poor-quality">Poor quality</a> · <a href="/guides/extract-text-scanned-pdf">Extract text</a>.</p>
            """,
}

W7_AUTHORITY = {
    "compress-pdf-guide": """
            <h2>Compression guides</h2>
            <p>This guide links every compress workflow on RatPDF. Use it as your index when training teams.</p>
            <ul>
            <li>Email: <a href="/guides/compress-pdf-for-gmail">Gmail</a>, <a href="/guides/compress-pdf-for-outlook">Outlook</a>, <a href="/guides/compress-pdf-for-yahoo-mail">Yahoo</a>, <a href="/guides/compress-pdf-for-protonmail">Proton</a>, <a href="/guides/compress-pdf-for-whatsapp">WhatsApp</a>, <a href="/guides/compress-pdf-for-telegram">Telegram</a></li>
            <li>Jobs: <a href="/guides/compress-pdf-for-indeed">Indeed</a>, <a href="/guides/compress-pdf-for-naukri">Naukri</a>, <a href="/guides/compress-pdf-for-linkedin">LinkedIn</a>, <a href="/guides/compress-pdf-for-workday">Workday</a>, <a href="/guides/compress-pdf-usajobs">USAJOBS</a></li>
            <li>Education: <a href="/guides/compress-pdf-for-lms">LMS</a>, <a href="/guides/compress-pdf-common-app">Common App</a>, <a href="/guides/compress-pdf-ucas">UCAS</a>, <a href="/guides/compress-pdf-for-university-application">University</a></li>
            <li>Immigration: <a href="/guides/compress-pdf-for-visa-application">Visa</a>, <a href="/guides/compress-pdf-schengen-visa">Schengen</a>, <a href="/guides/compress-pdf-ukvi">UKVI</a>, <a href="/guides/compress-pdf-home-affairs-australia">Australia</a>, <a href="/guides/compress-pdf-immigration-canada">Canada</a></li>
            <li>India govt: <a href="/guides/compress-pdf-incometax">Income Tax</a>, <a href="/guides/compress-pdf-gst-portal">GST</a>, <a href="/guides/compress-pdf-digilocker">DigiLocker</a>, <a href="/guides/compress-pdf-irctc">IRCTC</a>, <a href="/guides/compress-pdf-uidai">UIDAI</a></li>
            <li>Industry: <a href="/guides/compress-pdf-lawyers">Lawyers</a>, <a href="/guides/compress-pdf-accountants">Accountants</a>, <a href="/guides/compress-pdf-teachers">Teachers</a>, <a href="/guides/compress-pdf-freelancers">Freelancers</a>, <a href="/guides/compress-pdf-real-estate">Real estate</a></li>
            </ul>
            <h2>Compression decision flowchart (text)</h2>
            <p>Start → size checker → under cap? send → Recommended compress → under cap? send → Extreme once → legible? send → else split → compress each part → send with index email.</p>
            <h2>Training one-pager for IT</h2>
            <p>Allowlist ratpdf.com · block only if DPA forbids browser upload · standardize Less for legal, Recommended for email · log ticket with before/after MB · escalate to split not re-scan when Extreme blurs.</p>
            """,
    "merge-pdf": """
            <h2>Merge guides</h2>
            <ul>
            <li><a href="/guides/merge-pdf-online">Merge PDF online</a> · <a href="/guides/how-to-merge-pdf-files">How to merge PDF files</a></li>
            <li><a href="/guides/merge-pdf-custom-order">Custom order</a> · <a href="/guides/organize-pdf-pages">Organize pages</a></li>
            <li><a href="/guides/merge-pdf-visa-application">Visa application</a> · <a href="/guides/merge-pdf-court-filing">Court filing</a></li>
            <li><a href="/guides/merge-password-protected-pdf">Password-protected</a> · <a href="/guides/merge-scanned-digital-pdf">Scanned + digital</a></li>
            <li><a href="/guides/merge-pdf-without-quality-loss">Without quality loss</a> · <a href="/guides/merge-pdf-accountants">Accountants</a> · <a href="/guides/merge-pdf-students">Students</a></li>
            <li><a href="/guides/combine-then-compress-pdf">Combine then compress</a> · <a href="/guides/merge-vs-compress">Merge vs compress</a></li>
            </ul>
            <h2>When merge fails — diagnostic table</h2>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>Symptom</th><th>Fix</th></tr></thead>
            <tbody>
            <tr><td>Password prompt</td><td><a href="/guides/unlock-pdf">Unlock PDF</a></td></tr>
            <tr><td>Missing pages</td><td>Corrupt source — re-export</td></tr>
            <tr><td>Huge output MB</td><td>Compress after merge</td></tr>
            <tr><td>Blurry logos</td><td>Avoid rasterizing merge tools — use RatPDF</td></tr>
            </tbody>
            </table></div>
            <h2>Enterprise filename standard</h2>
            <p><code>CLIENT-MATTER-MERGE-YYYYMMDD-v1.pdf</code> — litigation hold stores v1 immutable; v2 after supplemental exhibits appended via re-merge.</p>
            """,
    "split-pdf": """
            <h2>Split guides</h2>
            <ul>
            <li><a href="/guides/split-pdf-for-email">Split for email</a> · <a href="/guides/split-pdf-by-size">Split by size</a></li>
            <li><a href="/guides/split-pdf-page-range">Page range</a> · <a href="/guides/extract-single-page-pdf">Extract single page</a></li>
            <li><a href="/guides/compress-vs-split">Compress vs split</a> · <a href="/guides/organize-pdf-pages">Organize after split</a></li>
            </ul>
            <h2>Multi-part email standard</h2>
            <p>Subject must include part number and page range. Body must index all parts. Never send Part 3 before Part 1 without explanation.</p>
            <h2>Discovery production note</h2>
            <p>Split may break load file paths — agree format with e-discovery vendor before splitting numbered production sets.</p>
            <h2>Student / faculty tip</h2>
            <p>Split weekly readings — smaller files load faster on campus Wi-Fi — combine with <a href="/guides/merge-pdf-students">merge guide</a> when syllabus requires one pack.</p>
            """,
    "pdf-to-word": """
            <h2>PDF to Word guides</h2>
            <ul>
            <li>Quality: <a href="/guides/pdf-to-word-keep-formatting">Keep formatting</a> · <a href="/guides/scanned-pdf-to-word">Scanned workflow</a> · <a href="/guides/pdf-to-word-garbled-text">Garbled text</a></li>
            <li>Device: <a href="/guides/pdf-to-word-mac">Mac</a> · <a href="/guides/pdf-to-word-without-word">Without Word</a> · <a href="/guides/pdf-to-word-vs-google-docs">vs Google Docs</a></li>
            <li>Compare: <a href="/guides/pdf-to-word-vs-pdf-to-text">vs PDF to Text</a> · <a href="/guides/batch-pdf-to-word">Batch workflow</a></li>
            <li>Documents: <a href="/guides/convert-contract-pdf-to-word">Contract</a> · <a href="/guides/convert-nda-pdf-to-word">NDA</a> · <a href="/guides/convert-lease-agreement-pdf-to-word">Lease</a> · <a href="/guides/convert-bank-statement-pdf-to-word">Bank</a> · <a href="/guides/convert-sow-pdf-to-word">SOW</a></li>
            <li>Career: <a href="/guides/pdf-to-word-resume">Resume</a> · <a href="/guides/convert-transcript-pdf-to-word">Transcript</a></li>
            </ul>
            <h2>Conversion pipeline diagram (text)</h2>
            <p>PDF → test select → digital? pdftodoc : OCR → pdftodoc → edit DOCX → doctopdf → compress if email rejects.</p>
            <h2>Legal redline discipline</h2>
            <p>Track changes on — never silent PDF photoshop redline — return DOCX or PDF export after accept — executed scan stays archive.</p>
            """,
    "ocr-pdf": """
            <h2>OCR guides</h2>
            <ul>
            <li><a href="/guides/ocr-scanned-pdf-workflow">Full OCR workflow</a> · <a href="/guides/extract-text-scanned-pdf">Extract text from scan</a></li>
            <li><a href="/guides/ocr-vs-pdf-to-text">OCR vs PDF to Text</a> · <a href="/guides/tesseract-vs-online-ocr">Tesseract vs online</a></li>
            <li><a href="/guides/ocr-pdf-ediscovery">E-discovery</a> · <a href="/guides/pdf-to-text-accessibility">Accessibility</a></li>
            <li>Languages: <a href="/guides/ocr-pdf-hindi">Hindi</a> · <a href="/guides/ocr-pdf-arabic">Arabic</a> · <a href="/guides/ocr-pdf-chinese">Chinese</a> · <a href="/guides/ocr-pdf-spanish">Spanish</a> · <a href="/guides/ocr-pdf-french">French</a> · <a href="/guides/ocr-pdf-german">German</a></li>
            </ul>
            <h2>OCR QA sampling protocol</h2>
            <p>Random 10% page spot-check on batch jobs — if error rate high, fix scan settings before remaining 90% — log QA date in matter file.</p>
            <h2>Downstream tool order</h2>
            <p>OCR → searchable PDF archive → optional pdftotext for scripts → optional pdftodoc for human edit — never skip OCR on image-only PDF for search.</p>
            """,
}
