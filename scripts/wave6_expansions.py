"""Wave 6 — Convert, Edit/Organize, Word spokes, SMB compare."""

CONVERT_CLUSTER = """
            <h2>Related convert guides</h2>
            <ul>
            <li><a href="/guides/images-to-pdf">Images to PDF</a></li>
            <li><a href="/guides/powerpoint-to-pdf">PowerPoint to PDF</a></li>
            <li><a href="/guides/word-to-pdf">Word to PDF</a></li>
            <li><a href="/guides/excel-to-pdf">Excel to PDF</a></li>
            </ul>
            <p>Compare: <a href="/compare/adobe-alternative">Adobe alternative</a></p>
            """

EDIT_CLUSTER = """
            <h2>Related edit &amp; organize guides</h2>
            <ul>
            <li><a href="/guides/edit-scanned-pdf">Edit scanned PDF</a></li>
            <li><a href="/guides/organize-pdf-pages">Organize PDF pages</a></li>
            <li><a href="/guides/split-pdf-page-range">Split by page range</a></li>
            <li><a href="/guides/add-image-to-pdf">Add image to PDF</a></li>
            </ul>
            """

CONVERT_DATA = {
    "images-to-pdf": {"title": "Convert images to PDF — JPG, PNG &amp; WEBP online", "tool": "/pdf/convertimages", "label": "Images to PDF", "example": "Combine 12 receipt photos into one PDF for expense report"},
    "powerpoint-to-pdf": {"title": "PowerPoint to PDF — export slides for print &amp; email", "tool": "/pdf/ppttopdf", "label": "PowerPoint to PDF", "example": "Export 40-slide pitch deck to PDF for investor email"},
    "images-to-pdf-without-adobe": {"title": "Images to PDF without Adobe — free browser converter", "tool": "/pdf/convertimages", "label": "Images to PDF", "example": "Chromebook user bundles scans without Acrobat install"},
    "powerpoint-to-pdf-without-adobe": {"title": "PowerPoint to PDF without Adobe — free PPTX export", "tool": "/pdf/ppttopdf", "label": "PowerPoint to PDF", "example": "Freelancer exports client deck on laptop without Office license"},
}

EDIT_DATA = {
    "edit-scanned-pdf": {"title": "Edit scanned PDF — OCR first, then add text or sign", "tool": "/pdf/editpdf", "label": "Edit PDF", "example": "Add date and initials to scanned consent form after OCR"},
    "edit-pdf-forms": {"title": "Edit PDF forms — fill government &amp; HR forms online", "tool": "/pdf/editpdf", "label": "Edit PDF", "example": "Fill flat IRS-style PDF fields in browser before print-sign-scan"},
    "organize-pdf-pages": {"title": "Organize PDF pages — rearrange &amp; reorder online", "tool": "/pdf/merge", "label": "Merge PDF", "example": "Reorder mixed annexures A–D before visa merge upload"},
    "extract-single-page-pdf": {"title": "Extract single page from PDF — pull one page online", "tool": "/pdf/split", "label": "Split PDF", "example": "Pull signature page 7 from 40-page contract for countersign"},
    "add-image-to-pdf": {"title": "Add image to PDF — logo, photo &amp; stamp online", "tool": "/pdf/editpdf", "label": "Edit PDF", "example": "Insert company logo on proposal PDF cover before client send"},
    "split-pdf-page-range": {"title": "Split PDF by page range — extract sections online", "tool": "/pdf/split", "label": "Split PDF", "example": "Extract exhibits 3–8 from discovery production for counsel review"},
}

WORD_W6_DATA = {
    "convert-delivery-note-pdf-to-word": {"title": "Convert delivery note PDF to Word — dispatch &amp; GRN edits", "doc": "delivery note/challan", "example": "Fix qty and vehicle number on challan before GRN posting", "tips": "Verify line totals after edit; re-export PDF for warehouse stamp."},
    "convert-debit-note-pdf-to-word": {"title": "Convert debit note PDF to Word — billing adjustments", "doc": "debit note", "example": "Add freight surcharge line after original invoice sent", "tips": "Pair with credit note workflow; accountant approves tax impact."},
    "convert-sow-pdf-to-word": {"title": "Convert SOW PDF to Word — edit scope &amp; milestones", "doc": "statement of work", "example": "Shift milestone 2 date and fee in agency SOW redline", "tips": "Track changes for client; export PDF after mutual accept."},
    "convert-lease-agreement-pdf-to-word": {"title": "Convert lease agreement PDF to Word — edit rental terms", "doc": "lease agreement", "example": "Update rent escalation clause in commercial lease draft", "tips": "Scanned signed lease — OCR before convert; counsel reviews."},
    "convert-medical-record-admin-pdf-to-word": {"title": "Convert medical record admin PDF to Word — forms &amp; letters", "doc": "medical admin PDF", "example": "Edit discharge summary template paragraph before physician sign", "tips": "HIPAA — no PHI in email; secure channel only."},
    "word-to-pdf-without-adobe": {"title": "Word to PDF without Adobe — free DOCX export online", "doc": "Word document", "example": "Export contract DOCX to PDF on Mac without Acrobat", "tips": "Use RatPDF Word to PDF; embed fonts for client printers."},
}

WORD_W6_DEEP = {
    "convert-delivery-note-pdf-to-word": """
            <h2>GRN three-way match</h2>
            <p>Delivery note qty must match PO and invoice — Word edit for qty only with procurement approval — not silent PDF overlay.</p>
            <h2>Warehouse stamp</h2>
            <p>After edit export PDF — physical stamp on printed copy — digital PDF is pre-stamp draft.</p>
            """,
    "convert-debit-note-pdf-to-word": """
            <h2>GST debit note fields</h2>
            <p>Link original invoice number and date — IGST/CGST split correct — regenerate from ERP when possible.</p>
            """,
    "convert-sow-pdf-to-word": """
            <h2>MSA + SOW hierarchy</h2>
            <p>SOW changes do not override MSA liability cap — edit SOW only within master agreement framework.</p>
            """,
    "convert-lease-agreement-pdf-to-word": """
            <h2>Residential vs commercial</h2>
            <p>Deposit and notice period clauses jurisdiction-specific — counsel review after Word edit.</p>
            """,
    "convert-medical-record-admin-pdf-to-word": """
            <h2>HIPAA minimum necessary</h2>
            <p>Edit admin letters only — not clinical notes without compliance officer — BAA with vendors.</p>
            """,
    "word-to-pdf-without-adobe": """
            <h2>Font embedding</h2>
            <p>Missing fonts on recipient PC — RatPDF export embeds common sets — verify print preview.</p>
            <h2>vs print-to-PDF</h2>
            <p>Word print-to-PDF sometimes drops hyperlinks — dedicated <a href="/pdf/doctopdf">Word to PDF</a> tool preserves links better.</p>
            """,
}

CONVERT_DEEP = {
    "images-to-pdf": """
            <h2>Sort order discipline</h2>
            <p>Receipts chronological — drag sort before convert — filename prefix 01- 02- if tool lacks drag.</p>
            <h2>Compression after bundle</h2>
            <p>20 phone photos → 35 MB PDF — <a href="/guides/compress-pdf-with-images">compress with images</a> before email.</p>
            """,
    "powerpoint-to-pdf": """
            <h2>Slide size</h2>
            <p>16:9 vs 4:3 — export matches projector — wrong aspect letterboxes on print.</p>
            <h2>Font embedding</h2>
            <p>Custom brand fonts — verify PDF on recipient machine — embed in PPTX before export.</p>
            """,
    "images-to-pdf-without-adobe": """
            <h2>Chromebook workflow</h2>
            <p>Upload JPG from Files — download PDF — attach Gmail — no Play Store app required.</p>
            """,
    "powerpoint-to-pdf-without-adobe": """
            <h2>LibreOffice engine</h2>
            <p>Server-side Impress export — complex animations flatten — acceptable for static slide decks.</p>
            """,
}

EDIT_DEEP = {
    "edit-scanned-pdf": """
            <h2>OCR mandatory</h2>
            <p><a href="/pdf/ocrpdf">OCR PDF</a> then edit — text tools need layer — <a href="/guides/scanned-pdf-to-word">Word path</a> for heavy edits.</p>
            """,
    "edit-pdf-forms": """
            <h2>Flat vs fillable</h2>
            <p>Fillable AcroForm fields edit in browser — flat PDF needs text box overlay — verify alignment print.</p>
            """,
    "organize-pdf-pages": """
            <h2>Merge as organize</h2>
            <p>Reorder queue then merge once — same engine as <a href="/guides/merge-pdf-custom-order">custom order merge</a>.</p>
            """,
    "extract-single-page-pdf": """
            <h2>Range syntax</h2>
            <p>Page 7 only — split 7-7 — faster than extract tool on some workflows.</p>
            """,
    "add-image-to-pdf": """
            <h2>Logo DPI</h2>
            <p>PNG logo 300px wide sufficient for A4 — huge PNG bloats PDF — resize source first.</p>
            """,
    "split-pdf-page-range": """
            <h2>Chapter boundaries</h2>
            <p>Split 1-30, 31-60 not mid-paragraph — reader navigation matters for textbook extracts.</p>
            """,
}

SHARED_MEGA = """
            <h2>Browser vs desktop</h2>
            <p>RatPDF needs no install — IT-friendly — confidential docs review privacy policy retention window.</p>
            <h2>Chain tools</h2>
            <p>Convert → edit → compress → merge — pick order by deliverable — see the <a href="/guides/pdf-tools">PDF tools hub</a>.</p>
            <h2>Upgrade</h2>
            <p><a href="/Subscription/Plans">subscription plans</a> for daily caps on agency volume.</p>
            """

W6_1500 = """
            <h2>QA before send</h2>
            <ol><li>Page count correct</li><li>Text selects if required</li><li>Images sharp at 150% zoom</li><li>File opens in Chrome PDF viewer</li><li>Size under email/portal cap</li></ol>
            <h2>Compare vendors</h2>
            <p><a href="/compare/smallpdf-alternative">Smallpdf</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/adobe-alternative">Adobe</a>.</p>
            """

COMPARE_SMB = """
            <h2>RatPDF stack for SMB</h2>
            <p><strong>Invoice:</strong> <a href="/invoice/create">Create Invoice</a> · <strong>Merge:</strong> <a href="/pdf/merge">Merge PDF</a> · <strong>Compress:</strong> <a href="/pdf/compress">Compress</a> · <strong>Sign workflow:</strong> edit + print-sign-scan.</p>
            <h2>When Acrobat still wins</h2>
            <p>Prepress print shop CMYK soft proof — heavy JavaScript forms — offline air-gapped classified — desktop Acrobat may remain.</p>
            <h2>Cost comparison table</h2>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>Need</th><th>RatPDF</th><th>Acrobat Pro</th></tr></thead>
            <tbody>
            <tr><td>Occasional merge/compress</td><td>Free tier</td><td>Annual subscription</td></tr>
            <tr><td>Invoice PDFs</td><td>Create Invoice</td><td>Not included</td></tr>
            <tr><td>Batch OCR 500/day</td><td>Upgrade tier</td><td>Included</td></tr>
            </tbody>
            </table></div>
            <h2>Agency onboarding</h2>
            <p>One-page SOP: images → PDF → compress → email — link <a href="/guides/pdf-tools-small-business">this guide</a> in Notion wiki.</p>
            <h2>Research</h2>
            <p><a href="/research/freelancer-invoicing-statistics">Freelancer invoicing statistics</a> · <a href="/compare">compare tools</a>.</p>
            """

W6_CLOSING = """
            <h2>More guides</h2>
            <p>Image, PowerPoint, and Word conversion guides, plus editing tutorials and competitor comparisons — all in one place.</p>
            <p>Main guides: <a href="/guides/images-to-pdf">images</a> · <a href="/guides/pdf-to-word">PDF to Word</a> · <a href="/guides/split-pdf">split</a> · <a href="/compare">compare</a>.</p>
            <h2>Post-action checklist</h2>
            <ol><li>Output opens in Chrome PDF viewer</li><li>Page order matches intent</li><li>Text selects if downstream edit needed</li><li>File size under email/portal cap</li><li>Master archived before deleting source</li></ol>
            <p>Bookmark the <a href="/guides/pdf-tools">PDF tools guide</a> and <a href="/compare">compare tools</a> for team onboarding — consistent tool choice reduces wrong-output support tickets.</p>
            """

CONVERT_MEGA = """
            <h2>Images and slides — when PDF wins</h2>
            <p>Emailing 15 JPG attachments confuses recipients and blows mobile data caps. One PDF bundles evidence chronologically — expense reports, insurance claims, property inspections, and student portfolio submissions all benefit from single-file delivery.</p>
            <h2>Format matrix</h2>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>Source</th><th>Tool</th><th>After convert</th></tr></thead>
            <tbody>
            <tr><td>JPG/PNG/WEBP photos</td><td><a href="/pdf/convertimages">Images to PDF</a></td><td><a href="/guides/compress-pdf-with-images">Compress with images</a></td></tr>
            <tr><td>PPTX deck</td><td><a href="/pdf/ppttopdf">PowerPoint to PDF</a></td><td><a href="/guides/compress-pdf-for-email">Compress for email</a></td></tr>
            <tr><td>DOCX letter</td><td><a href="/pdf/doctopdf">Word to PDF</a></td><td>Merge if multi-doc pack</td></tr>
            <tr><td>Excel model</td><td><a href="/pdf/exceltopdf">Excel to PDF</a></td><td>Print area check first</td></tr>
            </tbody>
            </table></div>
            <h2>Resolution and DPI discipline</h2>
            <p>Phone photos at 4000×3000 px create 8 MB JPEGs — acceptable for archival PDF but heavy for WhatsApp. Resize to 2000 px long edge before convert when email is the bottleneck. Scanned documents: 300 DPI grayscale beats colour photo mode for text legibility and smaller PDF.</p>
            <h2>Orientation and EXIF</h2>
            <p>Some tools ignore EXIF rotation — verify thumbnail order before convert. Portrait receipts mixed with landscape invoices need manual sort — filename prefix <code>01-</code> <code>02-</code> when drag-sort unavailable.</p>
            <h2>PowerPoint animation caveat</h2>
            <p>PDF export flattens transitions — acceptable for investor email and print handouts. For interactive demos keep native PPTX — PDF is static deliverable. Speaker notes do not export to PDF by default in most engines — paste notes into appendix slides if recipients need them.</p>
            <h2>Accessibility</h2>
            <p>Image-only PDFs fail screen readers — add alt text in source slides or follow with OCR pass on final PDF if searchability required. Government accessibility audits may reject pure image bundles.</p>
            """

CONVERT_UNIVERSAL = """
            <h2>Step-by-step browser workflow</h2>
            <ol>
            <li>Gather source files in one folder — consistent naming</li>
            <li>Sort order matches narrative (date, chapter, exhibit letter)</li>
            <li>Upload to RatPDF convert tool — Wi-Fi for batches over 50 MB</li>
            <li>Download PDF — open immediately in viewer before closing tab</li>
            <li>Chain compress or merge if deliverable spec requires</li>
            </ol>
            <h2>Mobile convert path</h2>
            <p>iPhone: Photos → Share → Save to Files → Safari upload. Android: Gallery → Chrome file picker. Avoid compressing in messaging app before convert — double JPEG loss.</p>
            <h2>Failure messages</h2>
            <p><strong>Unsupported format:</strong> convert HEIC to JPG first on iOS. <strong>Timeout:</strong> reduce batch size or use desktop Wi-Fi. <strong>Blank pages:</strong> corrupt source — re-export from original app.</p>
            <h2>Adobe alternative positioning</h2>
            <p>Acrobat DC bundles convert with subscription — RatPDF free tier covers occasional images-to-PDF and PPT export — <a href="/compare/adobe-alternative">Adobe alternative</a> for agencies with 3 jobs/day cap.</p>
            <h2>Archive naming</h2>
            <p><code>ExpenseReport-2026-03-photos.pdf</code> not <code>converted.pdf</code> — AP and auditors match filename to email subject.</p>
            <h2>Chain with edit</h2>
            <p>Cover page typo after convert — <a href="/pdf/editpdf">Edit PDF</a> or <a href="/guides/add-image-to-pdf">add image</a> — do not re-convert entire batch for one logo fix.</p>
            """

CONVERT_FINAL = """
            <h2>Real example: insurance claim photo bundle</h2>
            <p>Homeowner documents hail damage — 22 phone photos + 1 contractor estimate scan. Sort chronological damage progression → Images to PDF → 28 MB output → Recommended compress → 6 MB → email to adjuster with claim number in subject.</p>
            <h2>Second example: conference slide handout</h2>
            <p>Speaker exports 35-slide PPTX to PDF for attendees — custom fonts embedded in deck — verify PDF on colleague laptop before mass email — compress only if over 20 MB.</p>
            <h2>Third example: Etsy seller shipping proof</h2>
            <p>Combine packing photo, label scan, and receipt JPG into one PDF for dispute evidence — timestamp filenames match order ID.</p>
            <h2>Education portfolio</h2>
            <p>Art student submits 12 WEBP pieces — convert to PDF for university portal single-slot upload — compress if portal cap 10 MB.</p>
            <h2>Legal exhibit photo logs</h2>
            <p>Site inspection photos as PDF exhibit — Bates label after merge with report — <a href="/guides/merge-pdf-online">merge PDF</a> inspection report first page then photo appendix.</p>
            <h2>Upgrade volume</h2>
            <p>Agency batch converting client decks daily — <a href="/Subscription/Plans">subscription plans</a> · Compare <a href="/compare/smallpdf-alternative">Smallpdf</a>.</p>
            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Convert now</strong> <a href="/pdf/convertimages" class="alert-link fw-semibold">Images to PDF →</a></div>
            """

CONVERT_SLUG_EXTRA = {
    "images-to-pdf": """
            <h2>Expense report workflow</h2>
            <p>Finance requires one PDF per trip — not 40 loose receipts. Chronological sort — meal before taxi if same evening — totals match spreadsheet.</p>
            <h2>Multi-page TIFF scans</h2>
            <p>Flatbed scanner outputs multi-page TIFF — convert each TIFF or split first — verify page count equals feeder stack.</p>
            <h2>WEBP from Android camera</h2>
            <p>Modern Android defaults WEBP — supported in browser convert — if reject convert to JPG in gallery first.</p>
            <h2>Combine with OCR</h2>
            <p>Receipt photos need searchability — <a href="/pdf/ocrpdf">OCR PDF</a> after convert for AP grep.</p>
            """,
    "powerpoint-to-pdf": """
            <h2>Investor deck hygiene</h2>
            <p>Remove hidden slides before export — appendix slides optional second PDF — main deck under 15 MB for forward-friendly email.</p>
            <h2>Print vs screen PDF</h2>
            <p>Print handout needs margins — check slide master — full-bleed marketing decks may crop on office printers.</p>
            <h2>Hyperlinks in slides</h2>
            <p>URL links on last slide — verify clickable in exported PDF — broken links frustrate due diligence reviewers.</p>
            <h2>Video embed placeholder</h2>
            <p>Embedded MP4 becomes static poster frame — add QR code slide linking to hosted video if demo matters.</p>
            """,
    "images-to-pdf-without-adobe": """
            <h2>IT policy win</h2>
            <p>No admin rights for Acrobat install — browser tool passes security review when retention policy documented.</p>
            <h2>Chromebook classroom</h2>
            <p>Teacher collects student worksheet photos — batch convert on Chromebook — upload to LMS as single PDF per student.</p>
            <h2>Linux desktop</h2>
            <p>Firefox and Chromium on Ubuntu — same workflow — no Wine Acrobat layer.</p>
            <h2>Cost comparison</h2>
            <p>Acrobat Pro annual vs 3 free converts/day — SMB with 2 jobs/month stays on free tier.</p>
            """,
    "powerpoint-to-pdf-without-adobe": """
            <h2>Office 365 not required</h2>
            <p>Upload PPTX without local PowerPoint — server-side render — verify complex SmartArt on output page 1.</p>
            <h2>Keynote export path</h2>
            <p>Mac Keynote user exports PPTX first — then RatPDF — native Keynote PDF also works but Windows recipients expect standard PDF fonts.</p>
            <h2>Google Slides migration</h2>
            <p>Download PPTX from Google Slides — convert — faster than Print to PDF from browser for multi-slide decks.</p>
            <h2>Freelancer deliverable</h2>
            <p>Client requests PDF handout — no Office license on travel laptop — browser export from hotel Wi-Fi.</p>
            """,
}

EDIT_MEGA = """
            <h2>Edit vs convert vs OCR decision tree</h2>
            <p><strong>Digital PDF minor fix:</strong> Edit PDF text overlay. <strong>Heavy rewrite:</strong> PDF to Word. <strong>Scan:</strong> OCR first. <strong>Wrong page order:</strong> Organize via merge queue. <strong>One page pull:</strong> Split PDF.</p>
            <h2>Form filling landscape</h2>
            <p>Government PDFs mix fillable AcroForm fields and flat scans. Fillable fields preserve tab order — flat forms need positioned text boxes — print-test alignment before official submit.</p>
            <h2>Scanned document edit chain</h2>
            <ol>
            <li>Scan 300 DPI grayscale upright</li>
            <li><a href="/pdf/ocrpdf">OCR PDF</a> — verify Ctrl+F finds key term</li>
            <li><a href="/pdf/editpdf">Edit PDF</a> — add date, signature image, stamp</li>
            <li>Optional <a href="/guides/compress-pdf-for-email">compress</a> before portal upload</li>
            </ol>
            <h2>Organize without desktop Acrobat</h2>
            <p>Reorder pages in merge tool — drag queue — single merge output — same engine as <a href="/guides/merge-pdf-custom-order">custom order merge</a>. Delete pages by omitting from queue not destructive edit on source.</p>
            <h2>Image overlay best practices</h2>
            <p>Logo PNG with transparency — place top-right — do not cover existing signature block. DPI 150 sufficient for screen PDF — 300 for print-bound proposals.</p>
            <h2>Security and audit</h2>
            <p>Edited PDF is new derivative — keep unedited master for legal hold — filename suffix <code>-edited-2026-04-02</code>. Flatten annotations before court filing if local rules require.</p>
            """

EDIT_UNIVERSAL = """
            <h2>Browser edit limitations</h2>
            <p>RatPDF edit covers common SMB needs — text add, image stamp, form fill — not InDesign prepress — not Photoshop pixel surgery. For marketing brochure pixel edits return to design source.</p>
            <h2>Mobile edit caution</h2>
            <p>Fine form alignment on phone is painful — desktop for government forms — mobile OK for initial and date on consent PDF.</p>
            <h2>Password-protected PDFs</h2>
            <p>Unlock first: <a href="/guides/unlock-pdf">unlock PDF</a> — edit fails on encrypted open.</p>
            <h2>Compare vendors</h2>
            <p><a href="/compare/adobe-alternative">Adobe</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/smallpdf-alternative">Smallpdf</a> — evaluate form-fill on your hardest government PDF sample.</p>
            <h2>Split and extract coordination</h2>
            <p>Extract signature page before sending for countersign — <a href="/guides/extract-single-page-pdf">extract single page</a> — merge back after scan with <a href="/pdf/merge">Merge PDF</a>.</p>
            <h2>QA print test</h2>
            <p>Government forms reject misaligned fields — print one copy — hold to light against blank form — adjust coordinates before batch.</p>
            """

EDIT_FINAL = """
            <h2>Real example: HR onboarding packet</h2>
            <p>Flat I-9 scan — OCR — add start date field — employee initials — merge with handbook acknowledgment — compress — upload to HRIS.</p>
            <h2>Second example: property manager lease initialed</h2>
            <p>Scan signed lease pages — add initialed watermark on page 4 rider — re-compress for email to tenant.</p>
            <h2>Third example: proposal logo</h2>
            <p>Sales exports proposal PDF from CRM — add partner logo top-left — send to client — no return to InDesign.</p>
            <h2>Discovery page pull</h2>
            <p>Counsel needs only exhibit G from 200-page production — split page range 142-148 — email to expert witness — index in cover note.</p>
            <h2>Medical admin form</h2>
            <p>Clinic scan intake form — OCR — nurse adds checkbox marks — print for patient sign — scan again for chart.</p>
            <h2>Upgrade path</h2>
            <p>High-volume form shop — <a href="/Subscription/Plans">plans</a> — see the <a href="/guides/edit-pdf">edit PDF hub</a>.</p>
            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Edit your PDF</strong> <a href="/pdf/editpdf" class="alert-link fw-semibold">Edit PDF →</a></div>
            """

EDIT_SLUG_EXTRA = {
    "edit-scanned-pdf": """
            <h2>OCR quality factors</h2>
            <p>Skewed scan, coffee stain, fax halftone — re-scan beats OCR-on-blur. 300 DPI grayscale for text forms — colour only when signatures must stay blue ink.</p>
            <h2>Heavy text rewrite path</h2>
            <p>More than 20 word changes — <a href="/guides/scanned-pdf-to-word">scanned PDF to Word</a> — return PDF after edit.</p>
            <h2>Signature placement</h2>
            <p>PNG signature with transparent background — size to line — do not stretch aspect ratio.</p>
            """,
    "edit-pdf-forms": """
            <h2>Tab order and accessibility</h2>
            <p>Fillable forms should tab logically — if export breaks tab order — print-fill-scan fallback.</p>
            <h2>IRS and state tax PDFs</h2>
            <p>Some require specific PDF reader version — test submission in sandbox before live file.</p>
            <h2>HR benefit elections</h2>
            <p>Open enrollment PDF — fill — save — upload to benefits portal — keep copy outside portal too.</p>
            """,
    "organize-pdf-pages": """
            <h2>Visa bundle order</h2>
            <p>Checklist order: application form, passport, bank, employment — wrong order delays officer review — organize before single merge upload.</p>
            <h2>Remove duplicate pages</h2>
            <p>Scanner duped page 12 — omit from merge queue — verify page numbers in viewer thumbnails.</p>
            <h2>Chapter reorder for textbook PDF</h2>
            <p>Instructor merges chapters 3,1,2 for syllabus order — custom merge — one PDF for students.</p>
            """,
    "extract-single-page-pdf": """
            <h2>Countersign workflow</h2>
            <p>Page 7 signature block only to CEO — extract — DocuSign alternative for SMB — merge signed scan back.</p>
            <h2>Page number verification</h2>
            <p>Viewer page index vs printed footer — off-by-one breaks split range — confirm before extract.</p>
            <h2>Email one-pager</h2>
            <p>Send summary page only to executive — full PDF to file room — reduce attachment size.</p>
            """,
    "add-image-to-pdf": """
            <h2>Watermark vs logo</h2>
            <p>CONFIDENTIAL diagonal watermark — light opacity — logo distinct top corner — do not combine both on same real estate without broker approval.</p>
            <h2>Stamp scan</h2>
            <p>Notary stamp PNG — place on executed page — legibility after compress — Less compression level.</p>
            <h2>Photo evidence insert</h2>
            <p>Damage photo on insurance claim PDF page 2 — resize before insert — huge camera RAW converted to JPG first.</p>
            """,
    "split-pdf-page-range": """
            <h2>Exhibit range for counsel</h2>
            <p>Discovery production exhibits 3–8 as one range — cover email lists Bates span — opposing counsel merges locally.</p>
            <h2>Textbook chapter extract</h2>
            <p>Pages 45–78 chapter PDF for course pack — copyright fair use limits — institution policy applies.</p>
            <h2>Overlap guard</h2>
            <p>Ranges 1-30 and 31-60 not 1-30 and 30-60 — duplicate page 30 confuses reviewers.</p>
            """,
}

WORD_W6_MEGA = """
            <h2>Operational document editing philosophy</h2>
            <p>Warehouse, billing, and contract ops receive PDFs from partners who do not send editable sources. Word conversion is a pragmatic edit path — not ideal system of record — accountant or counsel approves before re-send.</p>
            <h2>ERP vs Word edit decision</h2>
            <p>If your ERP, CRM, or lease management system can reissue the document with audit trail — prefer reissue. Word path for one-off SMB without system access or urgent field correction before cutoff time.</p>
            <h2>India GST document chain</h2>
            <p>Delivery note → tax invoice → debit/credit note — each links to predecessor — editing debit note without fixing original invoice reference breaks GSTR reconciliation — verify IRN and invoice number fields character by character.</p>
            <h2>Healthcare admin boundary</h2>
            <p>Admin letters and form templates — yes. Clinical note body — restricted — compliance officer approval — BAA with any vendor processing PHI.</p>
            <h2>Lease and SOW legal hierarchy</h2>
            <p>MSA governs liability — SOW governs scope — lease governs premises — editing SOW does not amend MSA without signed amendment — counsel reviews Word redline.</p>
            <h2>Re-export discipline</h2>
            <p>After Word edit — <a href="/pdf/doctopdf">Word to PDF</a> for external parties — track changes off in final PDF — compress if portal rejects.</p>
            """

WORD_W6_TOPUP = """
            <h2>Second example: logistics GRN mismatch</h2>
            <p>Warehouse receives 98 units — challan shows 100 — procurement approves Word edit on delivery note qty — re-export PDF — GRN posts — three-way match closes.</p>
            <h2>Third example: agency SOW milestone shift</h2>
            <p>Client delays launch — milestone 2 moves 30 days — fee unchanged — track changes in Word — client accepts — PDF export for file.</p>
            <h2>Fourth example: commercial lease escalation</h2>
            <p>Landlord sends draft lease PDF — tenant counsel edits escalation clause in Word — returns DOCX — landlord counters — executed version stays PDF scan archive.</p>
            <h2>Fifth example: hospital admin template</h2>
            <p>Discharge instruction template paragraph update — Word edit — physician review — PDF to patient portal — not email attachment with PHI.</p>
            <h2>Version naming</h2>
            <p><code>SOW-ClientX-v4-redline.docx</code> and <code>SOW-ClientX-v4-final.pdf</code> — match numbers across formats.</p>
            <h2>Compare tools</h2>
            <p><a href="/guides/pdf-to-word-without-word">without Word installed</a> · <a href="/guides/pdf-to-word-keep-formatting">keep formatting</a> · <a href="/compare/adobe-alternative">Adobe alternative</a>.</p>
            """

WORD_SLUG_EXTRA = {
    "convert-delivery-note-pdf-to-word": """
            <h2>Field-level checklist</h2>
            <p>Vehicle number, LR number, consignee, qty, SKU lines, dispatch date — each field verified against PO — totals foot.</p>
            <h2>E-way bill linkage</h2>
            <p>Qty edit may require e-way bill regeneration — do not only edit PDF silently — coordinate with logistics compliance.</p>
            <h2>Partial shipment</h2>
            <p>Split delivery note per shipment — Word edit for partial qty — second challan for balance — avoid single doc showing impossible totals.</p>
            """,
    "convert-debit-note-pdf-to-word": """
            <h2>Debit vs credit note</h2>
            <p>Debit increases buyer liability — credit decreases — edit correct document type — wrong note type breaks audit.</p>
            <h2>Original invoice reference</h2>
            <p>Mandatory link field — date and number — GST portal validation — mismatch rejects filing.</p>
            <h2>Freight surcharge scenario</h2>
            <p>Post-invoice freight — debit note line — tax rate matches original supply category — CA sign-off.</p>
            """,
    "convert-sow-pdf-to-word": """
            <h2>Milestone table fidelity</h2>
            <p>Tables often survive on digital SOW — verify deliverable dates and acceptance criteria rows — sum of fees equals SOW total.</p>
            <h2>Change order process</h2>
            <p>Material scope change — formal change order not silent Word edit — client sign on change order PDF.</p>
            <h2>IP and deliverables clause</h2>
            <p>Do not break numbered list formatting — counsel reads 3.2(a) references — check list styles after convert.</p>
            """,
    "convert-lease-agreement-pdf-to-word": """
            <h2>Commercial vs residential fields</h2>
            <p>CAM charges, rentable square footage, TI allowance — commercial only — residential focuses deposit and notice — jurisdiction templates differ.</p>
            <h2>Scanned executed lease</h2>
            <p>OCR before Word — typos in OCR propagate — proofread every clause number — counsel mandatory for executed edits.</p>
            <h2>Sublease reference</h2>
            <p>Master lease governs sublease rights — editing sublease PDF in Word does not expand permitted use — legal review.</p>
            """,
    "convert-medical-record-admin-pdf-to-word": """
            <h2>Minimum necessary standard</h2>
            <p>Edit only fields needed for admin task — remove excess PHI from Word doc before save — secure delete after task.</p>
            <h2>Patient portal delivery</h2>
            <p>Prefer portal upload over email — PDF final — Word working copy on encrypted disk.</p>
            <h2>Template vs patient-specific</h2>
            <p>Generic instruction template — OK in Word. Patient-specific clinical narrative — restricted workflow — compliance sign-off.</p>
            """,
    "word-to-pdf-without-adobe": """
            <h2>Mac without Office</h2>
            <p>Pages export DOCX — upload to RatPDF Word to PDF — verify font substitution on recipient Windows PC.</p>
            <h2>Google Docs path</h2>
            <p>Download DOCX from Docs — Word to PDF — hyperlinks in footnotes survive better than Print to PDF from browser.</p>
            <h2>Contract delivery</h2>
            <p>Final PDF locked for sign — Word working copy internal only — do not email editable DOCX to counterparty unless negotiating.</p>
            """,
}

COMPARE_MEGA = """
            <h2>SMB PDF stack evaluation framework</h2>
            <p>Score each tool: monthly job count, confidentiality policy, offline need, invoice requirement, OCR volume, and e-filing portal caps. RatPDF wins occasional browser workflows — Acrobat wins air-gapped prepress and complex JavaScript forms.</p>
            <h2>RatPDF tool map for 10-person agency</h2>
            <ul>
            <li><strong>Invoicing:</strong> <a href="/invoice/create">Create Invoice</a> — GST, VAT, multi-currency</li>
            <li><strong>Client deliverables:</strong> <a href="/pdf/merge">Merge</a>, <a href="/pdf/compress">Compress</a>, <a href="/pdf/ppttopdf">PPT to PDF</a></li>
            <li><strong>Contracts:</strong> <a href="/pdf/pdftodoc">PDF to Word</a>, <a href="/pdf/doctopdf">Word to PDF</a></li>
            <li><strong>Scans:</strong> <a href="/pdf/ocrpdf">OCR</a>, <a href="/pdf/editpdf">Edit</a></li>
            <li><strong>Research:</strong> <a href="/research/freelancer-invoicing-statistics">Freelancer invoicing statistics</a></li>
            </ul>
            <h2>Total cost of ownership table</h2>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>Scenario</th><th>RatPDF</th><th>Acrobat Pro</th><th>Smallpdf Pro</th></tr></thead>
            <tbody>
            <tr><td>5 merges/month</td><td>Free tier</td><td>Full subscription</td><td>Subscription</td></tr>
            <tr><td>Invoice PDFs</td><td>Included</td><td>Not included</td><td>Not included</td></tr>
            <tr><td>Batch OCR 200 pages</td><td>Upgrade tier</td><td>Included</td><td>Credit packs</td></tr>
            <tr><td>IT install approval</td><td>None — browser</td><td>Desktop deploy</td><td>Browser</td></tr>
            </tbody>
            </table></div>
            <h2>Hybrid strategy</h2>
            <p>Keep one Acrobat seat for print shop liaison — everyone else on RatPDF for merge, compress, invoice — reduces license count without blocking prepress.</p>
            <h2>Onboarding one-pager SOP</h2>
            <p>New hire doc: images → PDF → compress → email — link this guide in Notion — reduces Slack "which tool?" questions.</p>
            <h2>Security questionnaire answers</h2>
            <p>Browser upload — review RatPDF privacy policy retention — confidential client docs may require upgrade tier or offline desktop per client DPA.</p>
            <h2>When to escalate to specialist tools</h2>
            <p>PDF/A long-term archive, CMYK print, accessible tagged PDF publishing — outside RatPDF scope — specialist vendor or Acrobat.</p>
            """

COMPARE_DEEP = """
            <h2>Role-based tool assignment</h2>
            <p><strong>Founder:</strong> Create Invoice + compress for client send. <strong>Project manager:</strong> merge board packs + PPT to PDF. <strong>Legal:</strong> PDF to Word redline + split exhibits. <strong>Ops:</strong> images to PDF expense bundles. Document who uses which tool in onboarding wiki.</p>
            <h2>Vendor comparison workflow</h2>
            <ol>
            <li>List top 10 monthly PDF tasks from team survey</li>
            <li>Run same sample file through RatPDF and trial Acrobat</li>
            <li>Score output quality, time, and cost per seat</li>
            <li>Pilot RatPDF free tier two weeks before canceling subscriptions</li>
            <li>Keep compare page bookmarked for renewal season</li>
            </ol>
            <h2>Freelancer solo stack</h2>
            <p>Invoice clients with Create Invoice — merge contracts with statements — compress portfolio PDF for email — no Adobe tax on irregular workflow. Research: <a href="/research/freelancer-invoicing-statistics">freelancer invoicing statistics</a>.</p>
            <h2>Accounting firm stack</h2>
            <p>Compress GST annexures — split large audit workpapers — PDF to Word for engagement letter tweaks — batch month-end needs upgrade tier.</p>
            <h2>Real estate agency stack</h2>
            <p>Merge disclosure PDFs — compress for email — add brokerage logo via edit — Word to PDF for offer letter from template DOCX.</p>
            <h2>Renewal season checklist</h2>
            <p>Count seats × subscription price — estimate RatPDF upgrade if over free cap — present savings to finance — link <a href="/compare/adobe-alternative">Adobe alternative</a> and <a href="/compare/smallpdf-alternative">Smallpdf alternative</a> in decision memo.</p>
            <h2>FAQ — SMB tool choice</h2>
            <p><strong>Do we need Acrobat if we have RatPDF?</strong> Only if you need offline classified workflows or print-shop CMYK — most SMB tasks are browser-solvable.</p>
            <p><strong>Can we invoice and merge in one vendor?</strong> RatPDF includes Create Invoice plus PDF merge — fewer vendor security reviews.</p>
            <p><strong>What about e-sign?</strong> RatPDF edit + print-sign-scan covers many SMB paths — dedicated e-sign for high-volume real estate.</p>
            <h2>Migration from Adobe checklist</h2>
            <ol>
            <li>Export last 90 days task log from team</li>
            <li>Map each task to RatPDF tool URL</li>
            <li>Run parallel pilot on non-confidential samples</li>
            <li>Update IT allowlist for ratpdf.com</li>
            <li>Cancel redundant seats after pilot week 3</li>
            </ol>
            <h2>iLovePDF and Smallpdf positioning</h2>
            <p>Credit-pack models suit sporadic users — RatPDF invoice feature differentiates for billing agencies — compare table fidelity on your sample contract page before switching.</p>
            <h2>Nonprofit and NGO stack</h2>
            <p>Grant report photo annexures — images to PDF — compress for donor email — merge with narrative PDF — volunteer training via this compare page link.</p>
            <h2>E-commerce seller stack</h2>
            <p>Shipping dispute photos — return merchandise evidence — single PDF to marketplace portal — edit timestamp on scan if policy allows.</p>
            <h2>Annual vendor review template</h2>
            <p>Finance asks three questions: seats used, tasks outside RatPDF scope, data residency concerns — document answers in renewal memo with links to <a href="/compare/ilovepdf-alternative">iLovePDF alternative</a>.</p>
            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Explore alternatives</strong> <a href="/compare" class="alert-link fw-semibold">Compare hub →</a></div>
            """

W6_LINE_COUNT_FIX = """
            <h2>Team rollout notes</h2>
            <p>Pin the main tool guides in your shared wiki — compress before portal, OCR before edit on scans, Word path only when ERP cannot reissue. New hires complete one sample file in first week using browser tools only — no desktop install ticket.</p>
            <h2>Support escalation path</h2>
            <p>Step 1: re-download output and open in Chrome viewer. Step 2: retry on Wi-Fi with smaller batch. Step 3: check <a href="/pdf-size-checker">size checker</a> preset. Step 4: compare tool choice on <a href="/compare">compare tools</a> if output quality insufficient.</p>
            <h2>Record retention</h2>
            <p>Keep source PDF until recipient confirms receipt — derivatives disposable after successful upload — confidential docs deleted from Downloads on shared machines same day.</p>
            <h2>Monthly volume planning</h2>
            <p>Track daily tool usage in spreadsheet — forecast upgrade need before month-end crunch — finance approves <a href="/Subscription/Plans">subscription</a> when free tier blocks twice in one week.</p>
            <h2>Incident log template</h2>
            <p>Date, source filename, tool used, error message, resolution — patterns reveal training gaps — share quarterly with ops lead.</p>
            """

EDIT_1500_FINAL = """
            <h2>Quick reference card</h2>
            <p>Scan → OCR → Edit. Digital → Edit direct. Reorder → Merge queue. One page → Split. Logo → Add image. Forms → Fill then print-test. Archive master before any derivative edit.</p>
            <p>Bookmark <a href="/guides/edit-pdf">edit PDF guide</a> for team onboarding — reduces wrong-tool support tickets.</p>
            <p>Wrong page order voids visa bundles — verify thumbnail strip before merge submit.</p>
            """

COMPARE_1500_FINAL = """
            <h2>Decision summary</h2>
            <p>Browser-first SMB teams: RatPDF for invoice, merge, compress, convert, and occasional Word. Keep Acrobat only for prepress or air-gapped classified workflows. Revisit this compare guide at annual renewal.</p>
            <p>Share this page with finance when Adobe renewal notice arrives — pilot RatPDF two weeks first.</p>
            """

COMPARE_FINAL = """
            <h2>Quarterly stack review meeting agenda</h2>
            <p>15-minute finance + ops sync: count PDF tasks, review subscription invoices, demo one RatPDF workflow new hire struggled with, update wiki SOP link.</p>
            <h2>Tool decision one-pager template</h2>
            <p>Columns: Task, Frequency, Current tool cost, RatPDF tool URL, Risk notes, Decision. Attach sample output PDFs from pilot week.</p>
            <h2>Partner and client-facing positioning</h2>
            <p>Agencies white-label client deliverables — PDF merge and compress under client brand — invoice PDF from Create Invoice — professional without Acrobat line item on client invoice.</p>
            <h2>Volume triggers for upgrade</h2>
            <p>More than three tools per day per user — or month-end batch exceeding free cap — <a href="/Subscription/Plans">subscription plans</a> beat stacking Singlepdf credit packs.</p>
            <h2>Guide index for teams</h2>
            <p>Compression, Word conversion, split, and convert guides — bookmark the set in a shared browser folder for consistent team onboarding.</p>
            """

CONVERT_1500_TOPUP = """
            <h2>Batch convert naming SOP</h2>
            <p>Month-end photo receipts — folder per employee — convert each folder to PDF — merge into master expense PDF if policy allows — compress before finance upload.</p>
            <h2>Quality spot-check</h2>
            <p>After convert open page 1, middle, and last at 150% zoom — cropped images mean wrong sort order or corrupt source — fix before send.</p>
            <h2>HEIC and RAW edge cases</h2>
            <p>iPhone HEIC — export JPG from Photos if browser rejects — DSLR RAW never upload direct — export JPG sRGB.</p>
            <h2>Colour profile</h2>
            <p>Print-bound photo PDF — sRGB source — CMYK print shop may still request native files — PDF is proof not plate file.</p>
            <h2>Insurance and warranty claims</h2>
            <p>Carrier portal wants chronological damage photos — one PDF per room or one master — filename includes policy number — compress only if portal rejects size.</p>
            <h2>Construction site daily logs</h2>
            <p>Foreman photos plus scanned delivery ticket — convert batch nightly — project manager merges weekly — archive on shared drive with date stamp.</p>
            <h2>Legal photo exhibits</h2>
            <p>Each photo page landscape or portrait consistent — Bates after merge with narrative report — chain of custody note in email cover.</p>
            <h2>Pillar cross-links</h2>
            <p><a href="/guides/word-to-pdf">Word to PDF</a> · <a href="/guides/excel-to-pdf">Excel to PDF</a> · <a href="/guides/compress-pdf-with-images">compress with images</a> · <a href="/guides/pdf-tools">PDF tools hub</a>.</p>
            """

EDIT_1500_TOPUP = """
            <h2>Edit audit log</h2>
            <p>Log who edited which PDF derivative — timestamp — reason — matter number — supports litigation hold and SOX-style controls.</p>
            <h2>Flatten before external send</h2>
            <p>Some recipients see floating annotations differently — flatten or re-export PDF so logo and text boxes appear identical on all viewers.</p>
            <h2>Redaction before edit</h2>
            <p>Remove SSN and account numbers with <a href="/guides/pdf-redaction-permanent">permanent redaction</a> before adding new text — edit tool does not replace redaction workflow.</p>
            <h2>Training slide for staff</h2>
            <p>Three rules poster: OCR scans first — organize before merge — compress after combine — pin in Slack onboarding channel.</p>
            <h2>Department-specific examples</h2>
            <p><strong>HR:</strong> I-9 and handbook ack merge. <strong>Sales:</strong> logo on proposal. <strong>Legal:</strong> exhibit extract. <strong>Finance:</strong> initialed tax form. <strong>Ops:</strong> delivery note stamp.</p>
            <h2>Version rollback</h2>
            <p>Keep pre-edit master immutable — if client rejects edit — resend from master not undo in editor — filename version increments.</p>
            <h2>Collaboration handoff</h2>
            <p>Paralegal extracts page — attorney reviews in isolation — merge signed scan back — document handoff in matter management ticket.</p>
            <h2>Accessibility after edit</h2>
            <p>Added text may not be tagged — government accessibility filing may need tagged PDF specialist — SMB email deliverable usually exempt.</p>
            <h2>Pillar cross-links</h2>
            <p><a href="/guides/merge-pdf-online">merge PDF</a> · <a href="/guides/ocr-pdf">OCR PDF</a> · <a href="/guides/split-pdf">split hub</a> · <a href="/guides/pdf-tools">PDF tools hub</a>.</p>
            """

W6_SHARED_MEGA = """
            <h2>Cross-wave tool chain</h2>
            <p>Pick tool order by what you need to deliver. Example: photos → images PDF → OCR → edit date → compress → portal upload.</p>
            <h2>Free tier and upgrade</h2>
            <p>Three uses per day per tool on free tier — agency month-end exceeds cap — <a href="/Subscription/Plans">subscription plans</a> — predictable vs per-file credit packs.</p>
            <h2>Internal link discipline</h2>
            <p>Each guide links to related tools and comparisons so your team picks the right workflow.</p>
            <h2>Support triage</h2>
            <p>Wrong tool order causes bad output — OCR before edit on scans — compress after merge not before each file — train your team using the main tool guides.</p>
            """

W6_1500_EXTENDED = """
            <h2>Device matrix</h2>
            <p>Windows Edge, Mac Safari, iPhone Safari, Android Chrome — same account — no sync required — download to device storage before portal upload.</p>
            <h2>Retention hygiene</h2>
            <p>Clear Downloads on shared PC — contracts and medical admin PDFs are confidential — delete derivatives when task completes.</p>
            <h2>Filename and version control</h2>
            <p><code>Client-Doc-v2-edited.pdf</code> — never overwrite sent attachment — email thread references version.</p>
            <h2>Portal rejection loop</h2>
            <p>Reject → check size with <a href="/pdf-size-checker">size checker</a> → compress Less → split if still over → re-upload before session timeout.</p>
            <h2>Research links</h2>
            <p><a href="/research/attachment-size-limits">Attachment size limits</a> · <a href="/research/pdf-compression-benchmark">Compression benchmark</a> · <a href="/research/freelancer-invoicing-statistics">Invoicing statistics</a>.</p>
            <h2>Pillar bookmark set</h2>
            <p><a href="/guides/pdf-tools">PDF tools hub</a> · <a href="/guides/images-to-pdf">Images to PDF</a> · <a href="/guides/pdf-to-word">PDF to Word</a> · <a href="/guides/split-pdf">Split PDF</a> · <a href="/compare">Compare hub</a>.</p>
            """
