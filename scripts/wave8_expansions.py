"""Wave 8 — Edit-gap cluster: crop, delete, annotate, highlight, device workflows, pillar upgrades."""

W8_SLUGS = [
    "crop-pdf-online",
    "crop-pdf-without-adobe",
    "delete-pages-from-pdf",
    "annotate-pdf-online",
    "annotate-pdf-free",
    "highlight-pdf-online",
    "rearrange-pdf-pages",
    "edit-pdf-text-online",
    "add-text-to-pdf",
    "fill-pdf-form-online",
    "edit-pdf-on-mac",
    "edit-pdf-on-windows",
    "edit-pdf-on-iphone",
    "remove-blank-pages-pdf",
    "edit-pdf",
    "rotate-pdf",
    "edit-pdf-without-acrobat",
]

W8_DATA = {
    "crop-pdf-online": {
        "title": "Crop PDF online — trim margins &amp; white borders in browser",
        "tool": "/pdf/editpdf",
        "label": "Edit PDF",
        "example": "Trim excess white border on a scanned lease before portal upload",
    },
    "crop-pdf-without-adobe": {
        "title": "Crop PDF without Adobe — free browser workflow",
        "tool": "/pdf/editpdf",
        "label": "Edit PDF",
        "example": "Chromebook user trims fax margins without Acrobat install",
    },
    "delete-pages-from-pdf": {
        "title": "Delete pages from PDF — remove blanks &amp; duplicates online",
        "tool": "/pdf/rotateorremove",
        "label": "Rotate / Remove Pages",
        "example": "Drop blank page 12 and duplicate cover from merged job pack",
    },
    "annotate-pdf-online": {
        "title": "Annotate PDF online — notes, stamps &amp; markup in browser",
        "tool": "/pdf/editpdf",
        "label": "Edit PDF",
        "example": "Mark contract clause 4.2 for legal review before countersign",
    },
    "annotate-pdf-free": {
        "title": "Annotate PDF free — browser markup without subscription",
        "tool": "/pdf/editpdf",
        "label": "Edit PDF",
        "example": "Student highlights readings and adds margin notes for study group",
    },
    "highlight-pdf-online": {
        "title": "Highlight PDF online — emphasize text &amp; passages",
        "tool": "/pdf/editpdf",
        "label": "Edit PDF",
        "example": "Highlight policy exceptions in 80-page vendor agreement",
    },
    "rearrange-pdf-pages": {
        "title": "Rearrange PDF pages — reorder &amp; combine online",
        "tool": "/pdf/merge",
        "label": "Merge PDF",
        "example": "Reorder visa annexures A–D before single-bundle upload",
    },
    "edit-pdf-text-online": {
        "title": "Edit PDF text online — add &amp; correct wording in browser",
        "tool": "/pdf/editpdf",
        "label": "Edit PDF",
        "example": "Fix typo in proposal date field before client send",
    },
    "add-text-to-pdf": {
        "title": "Add text to PDF — labels, dates &amp; captions online",
        "tool": "/pdf/editpdf",
        "label": "Edit PDF",
        "example": "Add DRAFT label and revision date on board pack PDF",
    },
    "fill-pdf-form-online": {
        "title": "Fill PDF form online — government &amp; HR forms in browser",
        "tool": "/pdf/editpdf",
        "label": "Edit PDF",
        "example": "Complete flat tax PDF fields and save filled copy for records",
    },
    "edit-pdf-on-mac": {
        "title": "Edit PDF on Mac — Safari workflow without Acrobat",
        "tool": "/pdf/editpdf",
        "label": "Edit PDF",
        "example": "MacBook user adds initials to NDA in Safari before AirDrop to counsel",
    },
    "edit-pdf-on-windows": {
        "title": "Edit PDF on Windows — Edge &amp; Chrome browser editor",
        "tool": "/pdf/editpdf",
        "label": "Edit PDF",
        "example": "Windows 11 user stamps approved on PO PDF without IT install ticket",
    },
    "edit-pdf-on-iphone": {
        "title": "Edit PDF on iPhone — mobile annotate &amp; sign workflow",
        "tool": "/pdf/editpdf",
        "label": "Edit PDF",
        "example": "Sales rep adds date and signature image on iPhone between meetings",
    },
    "remove-blank-pages-pdf": {
        "title": "Remove blank pages from PDF — clean merged scans online",
        "tool": "/pdf/rotateorremove",
        "label": "Rotate / Remove Pages",
        "example": "Strip feeder blank pages from 40-page scanned contract",
    },
    "edit-pdf": {
        "title": "Edit PDF online — complete browser editing guide (2026)",
        "tool": "/pdf/editpdf",
        "label": "Edit PDF",
        "example": "SMB hub for text, images, forms, and annotations without desktop install",
    },
    "rotate-pdf": {
        "title": "Rotate PDF pages — fix scan orientation online (2026)",
        "tool": "/pdf/rotateorremove",
        "label": "Rotate / Remove Pages",
        "example": "Fix sideways phone scans and mixed landscape pages before merge",
    },
    "edit-pdf-without-acrobat": {
        "title": "Edit PDF without Adobe — free browser alternative (2026)",
        "tool": "/pdf/editpdf",
        "label": "Edit PDF",
        "example": "Agency replaces occasional Acrobat seat with RatPDF browser stack",
    },
}

W8_DEEP = {
    "crop-pdf-online": """
            <h2>What “crop PDF” usually means</h2>
            <p>Users want to remove white margins, fax headers, or scanner bed borders. True vector crop boxes (like Acrobat’s Crop tool) change the media box. Browser editors often achieve the <em>visual</em> goal by re-exporting trimmed content or overlaying on a tighter canvas.</p>
            <h2>RatPDF workflow when no dedicated crop tool</h2>
            <ol>
            <li>Open source in image editor — crop JPG/PNG scan before <a href="/guides/images-to-pdf">Images to PDF</a> if origin is photos.</li>
            <li>Digital PDF with huge margins — try <a href="/guides/pdf-to-word">PDF to Word</a> for layout edit, then <a href="/pdf/doctopdf">Word to PDF</a>.</li>
            <li>Minor border — <a href="/pdf/editpdf">Edit PDF</a> white box overlay on margins (visual trim for screen review).</li>
            <li>Print-bound crop — return to source app (Word, InDesign) when bleed matters.</li>
            </ol>
            <h2>Scanned document crop</h2>
            <p>Re-scan with smaller scan area beats cropping blurry fax edges. 300 DPI grayscale — straight on glass — crop in Preview or Photos before PDF bundle.</p>
            """,
    "crop-pdf-without-adobe": """
            <h2>Why teams skip Acrobat for crop</h2>
            <p>Annual Pro seats for occasional margin trim fail ROI review. Browser path passes IT review when retention policy is documented.</p>
            <h2>Chromebook and Linux</h2>
            <p>No Wine layer — crop source images locally — convert — compress — same stack as Windows.</p>
            <h2>Compare vendors</h2>
            <p><a href="/compare/adobe-acrobat-alternative">Adobe alternative</a> · <a href="/compare/smallpdf-alternative">Smallpdf</a> — test hardest sample scan before switching.</p>
            """,
    "delete-pages-from-pdf": """
            <h2>Delete vs split vs omit-on-merge</h2>
            <p><strong>Delete/remove:</strong> permanent drop of page indices via <a href="/pdf/rotateorremove">Rotate / Remove</a>. <strong>Split:</strong> keep master, send subset. <strong>Merge queue:</strong> omit unwanted pages when rebuilding bundle.</p>
            <h2>Step-by-step delete pages</h2>
            <ol>
            <li>Open PDF in viewer — note page numbers to remove (check footer vs viewer index).</li>
            <li>Upload to Rotate / Remove — select remove mode — enter pages <code>3, 12, 15</code> or range <code>10-12</code>.</li>
            <li>Download — verify page count decreased — spot-check content at former boundaries.</li>
            <li>Archive unedited master for legal hold before destructive delete.</li>
            </ol>
            <h2>After delete</h2>
            <p>Email still too large? <a href="/guides/compress-pdf-guide">Compress guide</a>. Wrong order? <a href="/guides/rearrange-pdf-pages">Rearrange pages</a>.</p>
            """,
    "annotate-pdf-online": """
            <h2>Annotation types in browser</h2>
            <p>Text boxes for notes, image stamps for APPROVED/REJECTED, freehand-style markup via overlay images. Not full collaborative comment threads — sufficient for SMB review cycles.</p>
            <h2>Review workflow</h2>
            <ol>
            <li>Upload contract PDF to <a href="/pdf/editpdf">Edit PDF</a>.</li>
            <li>Add margin note on clause in question — date stamp.</li>
            <li>Export <code>-annotated-v1.pdf</code> — email to counsel — keep clean master separate.</li>
            </ol>
            <h2>Flatten before court or portal</h2>
            <p>Some systems ignore floating layers — verify recipient sees notes — <a href="/guides/flatten-pdf">flatten PDF</a> if required.</p>
            """,
    "annotate-pdf-free": """
            <h2>Free tier limits</h2>
            <p>Three uses per tool per day on free tier — batch annotate board pack pages in one session — <a href="/Subscription/Plans">plans</a> for daily volume.</p>
            <h2>Student and nonprofit use</h2>
            <p>Highlight readings — share annotated PDF with study group — respect copyright on course packs.</p>
            <h2>Privacy</h2>
            <p>Review <a href="/home/privacy">privacy policy</a> before uploading client contracts — auto-delete after processing.</p>
            """,
    "highlight-pdf-online": """
            <h2>Highlight vs underline</h2>
            <p>True text highlight needs text layer — run <a href="/pdf/ocrpdf">OCR PDF</a> on scans first. Digital PDFs highlight via semi-transparent color boxes aligned to lines.</p>
            <h2>Long document strategy</h2>
            <p>80-page agreement — highlight only exception clauses — export summary email listing page numbers — do not highlight entire pages (bloats visual noise).</p>
            <h2>Accessibility note</h2>
            <p>Color-only highlight fails some accessibility audits — add text note beside highlight for government filings.</p>
            """,
    "rearrange-pdf-pages": """
            <h2>Rearrange = merge queue discipline</h2>
            <p>Export each section as PDF or split first — upload to <a href="/pdf/merge">Merge PDF</a> in desired order — drag queue before merge — single output.</p>
            <h2>Visa and permit bundles</h2>
            <p>Officer expects checklist order — application, passport, employment, bank — wrong order delays review — thumbnail strip verification mandatory.</p>
            <h2>Related organize guides</h2>
            <p><a href="/guides/organize-pdf-pages">Organize PDF pages</a> · <a href="/guides/merge-pdf-custom-order">Custom order merge</a> · <a href="/guides/merge-pdf">Merge guide</a>.</p>
            """,
    "edit-pdf-text-online": """
            <h2>When text overlay works</h2>
            <p>Short corrections — date, SKU, one-line label — overlay text box on digital PDF. Heavy paragraph rewrite — <a href="/guides/pdf-to-word">PDF to Word</a> path.</p>
            <h2>Font and alignment</h2>
            <p>Match surrounding font size — print-test government forms — misalignment rejects portal upload.</p>
            <h2>Scanned PDFs</h2>
            <p>OCR mandatory — <a href="/guides/edit-scanned-pdf">edit scanned PDF guide</a> — proofread numbers manually.</p>
            """,
    "add-text-to-pdf": """
            <h2>Common text additions</h2>
            <p>DRAFT watermark text, revision date, page label, missing address line, exhibit title on scan.</p>
            <h2>Combine with image</h2>
            <p>Logo plus text header — <a href="/guides/add-image-to-pdf">add image</a> first — text below — compress after if email rejects.</p>
            <h2>Version naming</h2>
            <p><code>Proposal-ClientX-v3-textadded.pdf</code> — never overwrite sent attachment.</p>
            """,
    "fill-pdf-form-online": """
            <h2>Fillable vs flat forms</h2>
            <p>AcroForm fields preserve tab order when supported. Flat scans need positioned text — print alignment test before official submit.</p>
            <h2>Government portal rejection</h2>
            <p>Some portals reject changed fonts — test draft upload — keep blank template master.</p>
            <h2>HR and tax</h2>
            <p>Open enrollment and state tax PDFs — save filled copy outside portal — <a href="/guides/edit-pdf-forms">edit PDF forms guide</a>.</p>
            """,
    "edit-pdf-on-mac": """
            <h2>Safari vs Chrome on Mac</h2>
            <p>Both work — Wi-Fi for files over 15 MB — save to Downloads then Files before portal upload from iCloud.</p>
            <h2>Preview.app limitation</h2>
            <p>Preview markup is local — RatPDF for consistent team workflow and invoice-adjacent PDF stack.</p>
            <h2>Handoff to iPhone</h2>
            <p>Start on Mac — AirDrop partial to phone for signature image insert — see <a href="/guides/edit-pdf-on-iphone">iPhone edit guide</a>.</p>
            """,
    "edit-pdf-on-windows": """
            <h2>Edge and Chrome</h2>
            <p>Corporate Edge policy may block uploads — IT allowlist ratpdf.com — same workflow as Chrome.</p>
            <h2>No Acrobat install ticket</h2>
            <p>IT-friendly browser path — document in security questionnaire — HTTPS and retention policy links.</p>
            <h2>Print to PDF trap</h2>
            <p>Word print-to-PDF loses links — use <a href="/pdf/doctopdf">Word to PDF</a> then edit — not print driver for proposals.</p>
            """,
    "edit-pdf-on-iphone": """
            <h2>Mobile edit limits</h2>
            <p>Fine form alignment painful on phone — OK for date, initials, signature PNG — desktop for IRS-style forms.</p>
            <h2>Workflow</h2>
            <p>Mail attachment → Open in Safari → Edit PDF → save to Files → upload to portal from Files app.</p>
            <h2>File size</h2>
            <p>Cellular upload of 25 MB scan — use Wi-Fi — <a href="/guides/compress-pdf-on-iphone">compress on iPhone</a> if portal rejects.</p>
            """,
    "remove-blank-pages-pdf": """
            <h2>Why blank pages appear</h2>
            <p>Scanner feeder double-feed blank, Word export trailing page, merge appended empty PDF, fax cover duplicated.</p>
            <h2>Find blanks fast</h2>
            <p>Thumbnail view — scroll — note indices — batch remove <code>2, 5, 8, 11</code> in one job if tool supports list.</p>
            <h2>Prevent recurrence</h2>
            <p>Deselect “scan empty page” on copier — remove trailing Word page break — merge queue omit blanks.</p>
            """,
    "edit-pdf": """
            <h2>Edit PDF — decision tree</h2>
            <p><strong>Digital minor fix:</strong> Edit PDF direct. <strong>Scan:</strong> OCR first. <strong>Heavy rewrite:</strong> PDF to Word. <strong>Reorder:</strong> Merge queue. <strong>Delete page:</strong> Rotate / Remove. <strong>Rotate:</strong> <a href="/guides/rotate-pdf">Rotate guide</a>.</p>
            <h2>Tool matrix</h2>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>Task</th><th>Tool</th><th>Guide</th></tr></thead>
            <tbody>
            <tr><td>Add text / annotate</td><td><a href="/pdf/editpdf">Edit PDF</a></td><td><a href="/guides/add-text-to-pdf">Add text</a></td></tr>
            <tr><td>Highlight / markup</td><td>Edit PDF</td><td><a href="/guides/highlight-pdf-online">Highlight</a></td></tr>
            <tr><td>Fill forms</td><td>Edit PDF</td><td><a href="/guides/fill-pdf-form-online">Fill form</a></td></tr>
            <tr><td>Logo / image</td><td>Edit PDF</td><td><a href="/guides/add-image-to-pdf">Add image</a></td></tr>
            <tr><td>Delete pages</td><td><a href="/pdf/rotateorremove">Rotate / Remove</a></td><td><a href="/guides/delete-pages-from-pdf">Delete pages</a></td></tr>
            <tr><td>Reorder</td><td><a href="/pdf/merge">Merge PDF</a></td><td><a href="/guides/rearrange-pdf-pages">Rearrange</a></td></tr>
            </tbody>
            </table></div>
            <h2>When browser edit is enough</h2>
            <p>Last-minute labels, stamps, form fill, logo on proposal — not InDesign prepress — not CMYK print shop proofing.</p>
            """,
    "rotate-pdf": """
            <h2>Rotate 90°, 180°, 270°</h2>
            <p>Phone scans arrive sideways — fax landscape — mixed merge orientation — <a href="/pdf/rotateorremove">Rotate / Remove</a> fixes without re-scan.</p>
            <h2>Step-by-step</h2>
            <ol>
            <li>Identify wrong pages in thumbnail view — all or subset.</li>
            <li>Upload — rotate clockwise per page or batch — preview before download.</li>
            <li>Merge with other PDFs only after orientation consistent — <a href="/guides/merge-pdf">merge guide</a>.</li>
            </ol>
            <h2>Rotate vs delete</h2>
            <p>Content correct but sideways → rotate. Blank or duplicate → remove — same tool — see <a href="/guides/delete-pages-from-pdf">delete pages</a>.</p>
            """,
    "edit-pdf-without-acrobat": """
            <h2>Acrobat vs browser stack</h2>
            <p>Acrobat Pro wins on prepress, batch redaction, JavaScript forms, offline classified. RatPDF wins on zero install, invoice-adjacent workflow, and predictable free tier for 3 jobs/day.</p>
            <h2>Migration checklist</h2>
            <ol>
            <li>List top 10 PDF tasks team performs monthly.</li>
            <li>Pilot RatPDF two weeks on non-critical files.</li>
            <li>Keep one Acrobat seat only if prepress or redaction required.</li>
            <li>Pin <a href="/guides/edit-pdf">edit guide</a> in wiki.</li>
            </ol>
            <h2>Cost table</h2>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>Need</th><th>RatPDF</th><th>Acrobat Pro</th></tr></thead>
            <tbody>
            <tr><td>Occasional annotate</td><td>Free tier</td><td>Annual subscription</td></tr>
            <tr><td>Merge + compress chain</td><td>Browser tools</td><td>Included</td></tr>
            <tr><td>CMYK prepress</td><td>Not target</td><td>Desktop</td></tr>
            </tbody>
            </table></div>
            """,
}

W8_SLUG_EXTRA = {
    "crop-pdf-online": """
            <h2>Real example: lease scan margins</h2>
            <p>Property manager scans 30-page lease — 2 cm bed border — crop in Photos — re-bundle Images to PDF — compress — portal upload under 5 MB.</p>
            <h2>Marketing PDF bleed</h2>
            <p>Brochure needs professional crop — return to InDesign — browser path for internal draft trim only.</p>
            """,
    "crop-pdf-without-adobe": """
            <h2>IT security questionnaire</h2>
            <p>Answer: HTTPS upload, auto-delete retention, no desktop agent — link privacy and security pages.</p>
            <h2>Freelancer travel laptop</h2>
            <p>Hotel Wi-Fi crop-convert-send — no Creative Cloud license on personal Mac.</p>
            """,
    "delete-pages-from-pdf": """
            <h2>Job application pack</h2>
            <p>Accidentally merged cover letter twice — delete page 1 duplicate — verify resume starts page 1 after delete.</p>
            <h2>Court exhibit hygiene</h2>
            <p>Remove privileged page before production — keep privilege log — master preserved.</p>
            """,
    "annotate-pdf-online": """
            <h2>Design review</h2>
            <p>Client PDF proof — annotate “move logo 2mm left” — designer edits source — not final art in PDF editor.</p>
            <h2>Board pack</h2>
            <p>Director notes on appendix C — annotated copy to secretary — clean PDF for official minutes archive.</p>
            """,
    "annotate-pdf-free": """
            <h2>Teacher feedback</h2>
            <p>Essay PDF returned with margin comments — student opens on Chromebook — no software purchase.</p>
            <h2>Volunteer NGO</h2>
            <p>Grant PDF markup — free tier sufficient for monthly review cycle.</p>
            """,
    "highlight-pdf-online": """
            <h2>Legal due diligence</h2>
            <p>Highlight indemnity and limitation clauses — export list of page numbers in cover email to partner.</p>
            <h2>Insurance policy review</h2>
            <p>Highlight exclusion section — share with broker — OCR scan first if search needed.</p>
            """,
    "rearrange-pdf-pages": """
            <h2>Textbook custom syllabus</h2>
            <p>Instructor merges chapters 3, 1, 2 — one PDF for students — copyright policy applies.</p>
            <h2>Discovery production reorder</h2>
            <p>Chronological narrative — rearrange exhibits before merge — Bates after final order set.</p>
            """,
    "edit-pdf-text-online": """
            <h2>Invoice field fix</h2>
            <p>Wrong PO number on PDF invoice — text overlay correction — re-send — ERP reissue preferred when available.</p>
            <h2>Certificate typo</h2>
            <p>Training certificate name typo — overlay fix for draft — reissue from source for official record.</p>
            """,
    "add-text-to-pdf": """
            <h2>CONFIDENTIAL header</h2>
            <p>Text box top margin on draft board pack — pair with <a href="/guides/watermark-pdf">watermark guide</a> for diagonal label.</p>
            <h2>Exhibit cover sheet</h2>
            <p>Add exhibit letter and title page before merge into main brief.</p>
            """,
    "fill-pdf-form-online": """
            <h2>Immigration forms</h2>
            <p>Flat PDF — OCR if scan — fill — print-sign-scan upload where e-submit unavailable.</p>
            <h2>Vendor W-9</h2>
            <p>Fill — save — attach to ERP vendor record — encrypt email discouraged — portal preferred.</p>
            """,
    "edit-pdf-on-mac": """
            <h2>Apple Silicon performance</h2>
            <p>M-series Mac handles 50 MB PDF smoothly — fan noise normal on OCR chain — edit after OCR completes.</p>
            <h2>iCloud Downloads</h2>
            <p>Save edited PDF to iCloud Drive — share link — not Mail for confidential docs.</p>
            """,
    "edit-pdf-on-windows": """
            <h2>Windows 10 EOL planning</h2>
            <p>Browser editor survives OS upgrade — no legacy Acrobat XI compatibility issues.</p>
            <h2>Dual monitor</h2>
            <p>Form fill on one screen — reference data on other — reduces typo rate on long tax PDFs.</p>
            """,
    "edit-pdf-on-iphone": """
            <h2>Signature PNG from Photos</h2>
            <p>Sign on paper — photo — crop in Photos — insert in Edit PDF — transparent background preferred.</p>
            <h2>Field sales</h2>
            <p>Quote PDF — add approved stamp between meetings — compress before email on cellular.</p>
            """,
    "remove-blank-pages-pdf": """
            <h2>Word export artifact</h2>
            <p>Trailing blank page from page break — delete last page — verify footer page count matches content.</p>
            <h2>Merge accident</h2>
            <p>Empty PDF in merge queue — remove pages from output — fix queue for next month’s merge.</p>
            """,
    "edit-pdf": """
            <h2>Real example: sales proposal</h2>
            <p>CRM exports PDF — add partner logo — add text revision date — compress — client email — no InDesign round trip.</p>
            <h2>Real example: HR onboarding</h2>
            <p>OCR I-9 — fill fields — merge handbook ack — compress — HRIS upload.</p>
            <h2>Related editing guides</h2>
            <ul>
            <li><a href="/guides/crop-pdf-online">Crop PDF</a> · <a href="/guides/delete-pages-from-pdf">Delete pages</a></li>
            <li><a href="/guides/annotate-pdf-online">Annotate</a> · <a href="/guides/highlight-pdf-online">Highlight</a></li>
            <li><a href="/guides/rearrange-pdf-pages">Rearrange</a> · <a href="/guides/add-text-to-pdf">Add text</a></li>
            <li><a href="/guides/edit-pdf-on-mac">Mac</a> · <a href="/guides/edit-pdf-on-windows">Windows</a> · <a href="/guides/edit-pdf-on-iphone">iPhone</a></li>
            </ul>
            """,
    "rotate-pdf": """
            <h2>Real example: expense receipts</h2>
            <p>12 phone photos merged sideways — rotate all 90° — then compress for finance email.</p>
            <h2>Real example: textbook scan</h2>
            <p>Chapter PDF mix portrait and landscape — rotate landscape pages — consistent reading on tablet.</p>
            """,
    "edit-pdf-without-acrobat": """
            <h2>Agency pilot result</h2>
            <p>12-seat creative shop — 2 Acrobat retained for print — 10 users on RatPDF merge/edit/compress — $8k annual savings documented.</p>
            <h2>When to keep Acrobat</h2>
            <p>Preflight PDF/X — batch redaction — accessibility tagging — classified offline — desktop remains.</p>
            """,
}

W8_MEGA = """
            <h2>Edit cluster authority map</h2>
            <p>Editing guides cover crop, delete, annotate, highlight, rearrange pages, and device workflows — plus in-depth help for <a href="/guides/edit-pdf">edit PDF</a> and <a href="/guides/rotate-pdf">rotate PDF</a>. See also merge, split, and OCR guides.</p>
            <h2>Security and compliance</h2>
            <p>Edited derivatives are new files — keep immutable master — log who edited — confidential docs cleared from Downloads on shared PCs same day. HIPAA and legal hold: counsel approves browser edit on PHI or privilege docs.</p>
            <h2>Failure triage</h2>
            <p><strong>Cannot select text:</strong> OCR first. <strong>Wrong page count after delete:</strong> off-by-one viewer index — recount. <strong>Portal rejects filled form:</strong> print-test alignment — font mismatch — try flatten. <strong>Upload timeout:</strong> Wi-Fi — compress — split.</p>
            <h2>Research links</h2>
            <p><a href="/research/attachment-size-limits">Email attachment limits</a> · <a href="/research/pdf-tool-market-comparison">PDF tool market comparison</a> · <a href="/compare">Compare hub</a>.</p>
            """

W8_CLUSTER = """
            <h2>Edit-gap guides</h2>
            <ul>
            <li><a href="/guides/crop-pdf-online">Crop PDF online</a> · <a href="/guides/crop-pdf-without-adobe">Crop without Adobe</a></li>
            <li><a href="/guides/delete-pages-from-pdf">Delete pages</a> · <a href="/guides/remove-blank-pages-pdf">Remove blank pages</a></li>
            <li><a href="/guides/annotate-pdf-online">Annotate online</a> · <a href="/guides/annotate-pdf-free">Annotate free</a></li>
            <li><a href="/guides/highlight-pdf-online">Highlight PDF</a> · <a href="/guides/edit-pdf-text-online">Edit text</a></li>
            <li><a href="/guides/add-text-to-pdf">Add text</a> · <a href="/guides/fill-pdf-form-online">Fill form</a></li>
            <li><a href="/guides/rearrange-pdf-pages">Rearrange pages</a> · <a href="/guides/edit-pdf-without-acrobat">Without Acrobat</a></li>
            <li><a href="/guides/edit-pdf-on-mac">Edit on Mac</a> · <a href="/guides/edit-pdf-on-windows">Windows</a> · <a href="/guides/edit-pdf-on-iphone">iPhone</a></li>
            </ul>
            <h2>Pillar and organize links</h2>
            <p><a href="/guides/edit-pdf">Edit PDF guide</a> · <a href="/guides/rotate-pdf">Rotate PDF</a> · <a href="/guides/organize-pdf-pages">Organize pages</a> · <a href="/guides/merge-pdf">Merge guide</a> · <a href="/guides/split-pdf">Split guide</a> · <a href="/guides/ocr-pdf">OCR guide</a>.</p>
            """

W8_1500_TOPUP = """
            <h2>QA checklist — edit outputs</h2>
            <ol>
            <li>Page count matches intent after delete or rearrange</li>
            <li>Orientation correct on every page at thumbnail view</li>
            <li>Added text readable at 150% zoom and in print preview</li>
            <li>Annotations visible in Chrome PDF viewer and recipient test</li>
            <li>File size under email or portal cap — compress if needed</li>
            <li>Master archived before destructive delete</li>
            </ol>
            <h2>Department playbooks</h2>
            <p><strong>Legal:</strong> annotate review copy — master untouched. <strong>Finance:</strong> fill tax PDF — print-test. <strong>HR:</strong> OCR onboarding — merge ack. <strong>Sales:</strong> logo + date on proposal. <strong>Ops:</strong> delete blank feeder pages from scan batch.</p>
            <h2>Monthly volume</h2>
            <p>Track edit/remove jobs — exceed free tier twice in one week — finance approves <a href="/Subscription/Plans">subscription</a>.</p>
            <h2>Compare alternatives</h2>
            <p><a href="/compare/adobe-acrobat-alternative">Adobe Acrobat alternative</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/smallpdf-alternative">Smallpdf</a>.</p>
            """

W8_PILLAR_TOPUP = """
            <h2>Authority hub cross-links</h2>
            <p>Compress before portal: <a href="/guides/compress-pdf-guide">compress guide</a>. Scan pipeline: <a href="/guides/ocr-pdf">OCR guide</a>. Heavy rewrite: <a href="/guides/pdf-to-word">PDF to Word</a>. Tool index: <a href="/guides/pdf-tools">PDF tools hub</a>.</p>
            <h2>Onboarding one-pager</h2>
            <p>Scan → OCR → edit. Digital → edit. Wrong order → rearrange. Sideways → rotate. Blank → delete. Too big → compress. Pin this guide in your team wiki.</p>
            """

W8_CLOSING = """
            <h2>Related guides</h2>
            <p>Editing guides cover crop, delete, annotate, highlight, rearrange pages, add text, fill forms, device workflows, blank-page cleanup, and rotate — step-by-step help for each task.</p>
            <p>Next troubleshooting wave: corrupt PDF, won’t open, print errors — bookmark <a href="/guides/pdf-tools">PDF tools hub</a> for full map.</p>
            """
