"""Premium expansion blocks for Wave 2 — Merge PDF + OCR PDF clusters."""

MERGE_UNIQUE = {
    "merge-pdf-online": """
            <h2>When browser merge beats desktop Acrobat</h2>
            <p>Occasional merge tasks do not justify a $20/month subscription. RatPDF <a href="/pdf/merge">Merge PDF</a> runs in Chrome, Edge, or Safari — upload two or more files, download one combined PDF. No installer, no registry keys on locked corporate laptops.</p>
            <p>Parent hub: <a href="/guides/merge-pdf">merge PDF guide</a>. Quality deep-dive: <a href="/guides/merge-pdf-without-quality-loss">merge without quality loss</a>.</p>

            <h2>Real example: quarterly board pack from three exports</h2>
            <p><strong>Input:</strong> Cover memo (Word → PDF), P&amp;L (Excel → PDF), auditor letter (email PDF attachment).</p>
            <ol>
            <li>Rename files <code>01-cover.pdf</code>, <code>02-pl.pdf</code>, <code>03-auditor.pdf</code>.</li>
            <li>Open Merge PDF — upload in numeric order.</li>
            <li>Download merged PDF — 48 pages, vector text intact on digital exports.</li>
            <li>If email rejects size, one pass <a href="/pdf/compress">Compress PDF</a> after merge.</li>
            </ol>

            <h2>File count and size limits</h2>
            <p>Free tier allows multiple files per merge session — check current limits on the tool page. Very large scans may timeout on slow connections; compress individuals first if upload stalls.</p>

            <h2>Security hygiene for online merge</h2>
            <ul>
            <li>Redact account numbers on bank PDFs before upload if policy requires</li>
            <li>Clear Downloads folder on shared PCs after confidential merges</li>
            <li>Do not merge classified material on consumer browser tools</li>
            </ul>
            """,
    "merge-pdf-custom-order": """
            <h2>Why merge order is not reversible without rework</h2>
            <p>Merge PDF appends entire files in upload sequence — page 1 of file 2 follows last page of file 1. Wrong order means re-merge or split/rebuild. Prefix filenames <code>01_</code>, <code>02_</code> before drag-upload.</p>

            <h2>Real example: litigation exhibit bundle</h2>
            <p><strong>Scenario:</strong> Exhibits A–F must precede appendix; court rejects misordered packets.</p>
            <ol>
            <li>List exhibits on cover sheet index matching file prefixes.</li>
            <li>Upload <code>00-index.pdf</code> through <code>06-appendix.pdf</code> to Merge PDF.</li>
            <li>Spot-check page 1 of each exhibit in merged viewer before e-filing.</li>
            <li>Optional: add bookmarks in Acrobat alternative workflow — RatPDF outputs linear PDF.</li>
            </ol>

            <h2>Page-level reorder vs file-level merge</h2>
            <p>Need page 3 from file A before page 1 of file B? <a href="/guides/split-pdf">Split PDF</a> first, export single pages, merge micro-files. Slower but precise.</p>

            <h2>Naming convention table</h2>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>Prefix</th><th>Use</th></tr></thead>
            <tbody>
            <tr><td>00_</td><td>Cover / index</td></tr>
            <tr><td>01–09_</td><td>Primary documents</td></tr>
            <tr><td>90_</td><td>Appendix / reserves</td></tr>
            </tbody>
            </table></div>
            """,
    "merge-pdf-visa-application": """
            <h2>Embassy checklist drives merge order — not convenience</h2>
            <p>Each country publishes document sequence: application form, passport bio, financials, employment, insurance. Deviation causes VFS rejection even when every page is present.</p>
            <p>Compress after merge: <a href="/guides/compress-pdf-for-visa-application">compress PDF for visa</a> · Schengen: <a href="/guides/compress-pdf-schengen-visa">Schengen compress guide</a>.</p>

            <h2>Real example: UK visitor visa single upload slot</h2>
            <ol>
            <li>Passport scan 300 DPI — bio page only if checklist says so.</li>
            <li>Bank statements last 6 months — digital PDF preferred over phone photos.</li>
            <li>Employment letter on letterhead PDF.</li>
            <li>Merge in UKVI checklist order — verify against gov.uk list for your visa type.</li>
            <li>Compress to under 6 MB if portal rejects — <a href="/guides/compress-pdf-ukvi">UKVI compress guide</a>.</li>
            </ol>

            <h2>Common visa merge mistakes</h2>
            <ul>
            <li>Passport photo page buried after bank statements</li>
            <li>Landscape scans not rotated — merge sideways pages</li>
            <li>Mixing unrelated family members in one PDF when slots are per applicant</li>
            <li>Merged 40 MB pack without compression — portal hard cap at 5 MB</li>
            </ul>

            <h2>When not to merge</h2>
            <p>Some portals require separate uploads per document type — read live instructions. Merge only when the form shows one combined PDF field.</p>
            """,
    "merge-password-protected-pdf": """
            <h2>Encryption blocks merge until you unlock</h2>
            <p>Password-protected PDFs cannot append — RatPDF needs decrypted bytes. Use <a href="/pdf/unlock">Unlock PDF</a> with the known password, download unrestricted copy, then merge.</p>

            <h2>Real example: bank statements + contract for loan application</h2>
            <ol>
            <li>Bank PDF password from email — unlock each statement PDF.</li>
            <li>Contract PDF unprotected — ready to merge.</li>
            <li>Merge statements chronologically, contract last as supporting exhibit.</li>
            <li>Do not re-password merged file unless lender requires — many reject encrypted uploads.</li>
            </ol>

            <h2>Owner vs user password</h2>
            <p><strong>User password</strong> blocks opening — you need it to view. <strong>Owner password</strong> may block editing/printing — unlock still required before merge. If password unknown, merge is impossible without issuer cooperation.</p>

            <h2>Security note</h2>
            <p>Decrypted PDFs in Downloads are plaintext-equivalent — delete after send. Never share unlock passwords in same email as merged attachment.</p>
            """,
    "merge-pdf-without-quality-loss": """
            <h2>Rasterizing merge destroys vector text</h2>
            <p>Cheap merge tools flatten every page to JPEG — logos blur, small print softens, file size balloons. RatPDF uses <strong>iText smart merge</strong> — digital pages append as objects when structure allows.</p>

            <h2>Real example: brand guidelines PDF + pricing sheet</h2>
            <p><strong>Bad merge:</strong> Logo edges fuzzy, blue becomes navy block. <strong>Smart merge:</strong> Vector logo sharp at 200% zoom, text still selectable.</p>
            <ol>
            <li>Confirm both sources are digital PDFs (text selects).</li>
            <li>Merge PDF — avoid "print to PDF" intermediate steps that rasterize.</li>
            <li>QA: Ctrl+F search brand name; zoom logo to 150%.</li>
            <li>Compress only if size requires — <a href="/guides/compress-before-merge-pdf">compress before or after merge</a>.</li>
            </ol>

            <h2>When quality loss is inevitable</h2>
            <ul>
            <li>Phone photo scans merged with digital PDFs — scans stay image-based</li>
            <li>Already rasterized marketing PDFs from Canva export</li>
            <li>Extreme compression after merge — re-encode images</li>
            </ul>

            <h2>QA checklist after merge</h2>
            <ol>
            <li>Page count equals sum of inputs minus duplicates</li>
            <li>Search finds known phrase from each source file</li>
            <li>Print preview — no cropped margins</li>
            </ol>
            """,
    "merge-scanned-digital-pdf": """
            <h2>Mixed sources create uneven file weight</h2>
            <p>Digital PDFs are lightweight; 300 DPI scans are megabytes per page. Merged pack may be 95% image data — compress after merge or scan at 200 DPI grayscale for balance.</p>

            <h2>Real example: HR onboarding packet</h2>
            <ol>
            <li>Offer letter — digital PDF from HRIS.</li>
            <li>Signed I-9 scan — phone photo PDF, rotate upright.</li>
            <li>Policy handbook — digital export.</li>
            <li>Merge: offer → I-9 → handbook.</li>
            <li>Optional <a href="/pdf/ocrpdf">OCR PDF</a> on merged file for HR full-text search.</li>
            </ol>

            <h2>Orientation and DPI normalization</h2>
            <p>Rotate landscape scans before merge. Match DPI where possible — 300 DPI scan beside 72 DPI screen capture looks unprofessional in one packet.</p>

            <h2>OCR before or after merge?</h2>
            <p><strong>After merge:</strong> one OCR pass for whole packet — simpler. <strong>Before merge:</strong> when only one scanned file needs search while others stay image-only exhibits.</p>
            """,
}

OCR_LANG = {
    "ocr-pdf-hindi": {
        "name": "Hindi", "script": "Devanagari", "example": "GST demand notice scan from Indian tax portal",
        "tips": "Matras and conjuncts (क्ष, त्र) confuse OCR — proofread amounts and GSTIN. Use 300 DPI grayscale for government notices.",
        "peers": "ocr-pdf-arabic",
    },
    "ocr-pdf-arabic": {
        "name": "Arabic", "script": "Arabic RTL", "example": "UAE employment contract scan with Arabic and English clauses",
        "tips": "Connected letter forms vary by position — RTL reading order may shuffle in plain .txt export; use PDF to Word for layout edits.",
        "peers": "ocr-pdf-hindi",
    },
    "ocr-pdf-chinese": {
        "name": "Chinese", "script": "Simplified & Traditional CJK", "example": "Supplier invoice scan from Shanghai factory",
        "tips": "Dense hanzi increase error rate — verify totals manually. Mixed English SKU lines usually OCR better than pure character blocks.",
        "peers": "ocr-pdf-japanese",
    },
    "ocr-pdf-french": {
        "name": "French", "script": "Latin + accents", "example": "Paris lease agreement scan with é, è, ç amounts",
        "tips": "Accents preserved in UTF-8 export — proofread œ and ligatures in legal terms.",
        "peers": "ocr-pdf-german",
    },
    "ocr-pdf-german": {
        "name": "German", "script": "Latin + umlauts", "example": "Berlin vendor contract scan with ä, ö, ü, ß",
        "tips": "Long compound words may split incorrectly — search viewer for key nouns after OCR.",
        "peers": "ocr-pdf-french",
    },
    "ocr-pdf-spanish": {
        "name": "Spanish", "script": "Latin + accents", "example": "Madrid freelancer invoice scan with ñ and inverted punctuation",
        "tips": "Inverted ¿ ¡ often survive; verify VAT IDs and IBAN spacing.",
        "peers": "ocr-pdf-portuguese",
    },
    "ocr-pdf-portuguese": {
        "name": "Portuguese", "script": "Latin + cedilla", "example": "Lisbon rental contract PT-PT scan",
        "tips": "ã, õ, ç critical for names — proofread beneficiary fields on bank forms.",
        "peers": "ocr-pdf-spanish",
    },
    "ocr-pdf-japanese": {
        "name": "Japanese", "script": "Kanji + kana", "example": "Tokyo office registration scan with vertical layout",
        "tips": "Vertical text breaks line order — expect manual reorder in Word. 300 DPI minimum for small kanji.",
        "peers": "ocr-pdf-chinese",
    },
    "ocr-pdf-korean": {
        "name": "Korean", "script": "Hangul", "example": "Seoul tax document scan with Hangul and numbers",
        "tips": "Hangul syllable blocks OCR moderately well — verify resident registration numbers digit-by-digit.",
        "peers": "ocr-pdf-japanese",
    },
    "ocr-pdf-russian": {
        "name": "Russian", "script": "Cyrillic", "example": "Moscow subcontract with Cyrillic party names",
        "tips": "Cyrillic confusable with Latin in mixed docs — proofread passport transliterations.",
        "peers": "ocr-pdf-german",
    },
    "ocr-pdf-poor-quality": {
        "name": "Poor quality", "script": "Any", "example": "Fax-era contract at 150 DPI with coffee stain shadow",
        "tips": "Re-scan beats re-OCR when original paper exists. Deskew, crop margins, increase contrast before second OCR pass.",
        "peers": "ocr-pdf-hindi",
    },
}

MERGE_LONG_TAIL = """
            <h2>Merge then compress decision tree</h2>
            <p><strong>One email attachment?</strong> Merge first, compress once — <a href="/guides/compress-before-merge-pdf">decision guide</a>. <strong>Per-slot portal uploads?</strong> Compress individuals before merge when each slot has its own cap.</p>

            <h2>Bookmarks and navigation</h2>
            <p>RatPDF outputs linear PDF without bookmarks. For 100+ page packs, add bookmarks in desktop editor if recipients navigate often — or split into volume parts with <a href="/guides/split-pdf">split PDF</a>.</p>

            <h2>Alternatives comparison</h2>
            <p>Compare: <a href="/compare/smallpdf-alternative">Smallpdf alternative</a> · <a href="/compare/adobe-alternative">Adobe alternative</a> · Research: <a href="/research/pdf-compression-benchmark">PDF compression benchmark</a>.</p>

            <h2>Extended FAQ</h2>
            <p><strong>Does merge change page size?</strong> Each source keeps its media box — mixed A4/Letter merges show size jumps; normalize in source apps if print shop requires.</p>
            <p><strong>Can I merge JPG as PDF?</strong> Convert images to PDF first or use image tools — Merge PDF expects PDF inputs.</p>
            <p><strong>Free tier?</strong> Three uses per tool per day — <a href="/Subscription/Plans">upgrade</a> for volume.</p>

            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Combine your files now</strong> <a href="/pdf/merge" class="alert-link fw-semibold">Merge PDF →</a></div>
            """

MERGE_CLUSTER_LINKS = """
            <h2>Related guides &amp; cluster links</h2>
            <ul>
            <li><a href="/guides/merge-pdf">Merge PDF guide</a></li>
            <li><a href="/guides/merge-pdf-without-quality-loss">Merge without quality loss</a></li>
            <li><a href="/guides/merge-pdf-custom-order">Merge in custom order</a></li>
            <li><a href="/guides/merge-scanned-digital-pdf">Merge scanned and digital PDFs</a></li>
            </ul>
            <p>Research: <a href="/research/pdf-compression-benchmark">PDF compression benchmark</a> · Compare: <a href="/compare/smallpdf-alternative">Smallpdf alternative</a></p>
            """

OCR_LONG_TAIL = """
            <h2>OCR pipeline on RatPDF</h2>
            <p>Tesseract adds invisible text layer over page images — Ctrl+F works in PDF viewers; copy/paste extracts UTF-8. Not the same as perfect transcription — always proofread legal amounts and IDs.</p>

            <h2>After OCR — next tools</h2>
            <ul>
            <li><a href="/pdf/pdftotext">PDF to Text</a> — plain .txt export</li>
            <li><a href="/guides/scanned-pdf-to-word">Scanned PDF to Word</a> — editable DOCX</li>
            <li><a href="/guides/pdf-to-text-multilingual">PDF to text multilingual</a> — Unicode tips</li>
            </ul>

            <h2>Privacy and retention</h2>
            <p>Scanned IDs and contracts contain PII — review privacy policy retention window. Clear local Downloads on shared machines.</p>

            <h2>Tesseract vs cloud OCR</h2>
            <p>Research: <a href="/guides/tesseract-vs-online-ocr">Tesseract vs online OCR</a> — RatPDF keeps processing on controlled infrastructure vs sending scans to unknown APIs.</p>

            <h2>Scan settings reference</h2>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>Document</th><th>DPI</th><th>Mode</th></tr></thead>
            <tbody>
            <tr><td>Typed contract</td><td>200–300</td><td>Grayscale</td></tr>
            <tr><td>Small print legal</td><td>300</td><td>Grayscale</td></tr>
            <tr><td>Colour stamps</td><td>300</td><td>Colour</td></tr>
            </tbody>
            </table></div>

            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Make scans searchable</strong> <a href="/pdf/ocrpdf" class="alert-link fw-semibold">OCR PDF →</a></div>

            <h2>Language pack limitations</h2>
            <p>Tesseract language packs vary by deployment — mixed {name}/English documents may need manual verification of each script block. Dense footnotes OCR poorly — treat as best-effort.</p>

            <h2>Export formats after OCR</h2>
            <p>Searchable PDF for archival · <a href="/pdf/pdftotext">.txt</a> for scripts · <a href="/guides/scanned-pdf-to-word">DOCX</a> for track-changes legal review.</p>

            <h2>Historical newspaper and book scans</h2>
            <p>Low-contrast newsprint needs aggressive contrast preprocessing before OCR — expect proper-noun errors in {name} place names; gazetteer lookup for validation.</p>
            """

OCR_CLUSTER_LINKS = """
            <h2>Related guides &amp; cluster links</h2>
            <ul>
            <li><a href="/guides/ocr-pdf">OCR PDF guide</a></li>
            <li><a href="/guides/ocr-scanned-pdf-workflow">OCR scanned PDF workflow</a></li>
            <li><a href="/guides/ocr-pdf-poor-quality">OCR poor quality scans</a></li>
            <li><a href="/guides/scanned-pdf-to-word">Scanned PDF to Word</a></li>
            </ul>
            <p>Research: <a href="/research/pdf-compression-benchmark">PDF compression benchmark</a> · Compare: <a href="/compare/adobe-alternative">Adobe alternative</a></p>
            """

MERGE_PREMIUM = """
            <h2>Enterprise merge governance</h2>
            <p>Legal ops teams document who may merge customer contracts — version control source PDFs before merge. Filename convention <code>CLIENT-MERGE-2026-04-01-v1.pdf</code> prevents accidental overwrite of executed copies.</p>

            <h2>Print shop handoff</h2>
            <p>Merged packs for bindery — embed fonts where possible; merge digital exports not "Print to PDF" chains that rasterize.</p>

            <h2>Upgrade prompt</h2>
            <p>Agencies merging daily: Pro tier raises limits — <a href="/Subscription/Plans">compare plans</a>.</p>
            """

MERGE_MEGA = """
            <h2>Industry workflows that depend on merge order</h2>
            <h3>Accounting &amp; audit</h3>
            <p>Combine signed engagement letter, management representation, and trial balance export. Auditors reject ZIPs of random filenames — numeric prefixes survive email forwarding.</p>
            <h3>Insurance claims</h3>
            <p>Photos, repair estimates, and policy PDF — merge chronologically with date-stamped filenames. Compress before portal upload — <a href="/guides/compress-pdf-insurance-claims">insurance compress guide</a>.</p>
            <h3>Real estate closings</h3>
            <p>Disclosure → inspection → title → closing statement. Title companies often specify order — ask before merge.</p>

            <h2>Technical limits worth knowing</h2>
            <p>PDF version mismatches rarely block merge — iText normalizes on output. Corrupt source PDF fails entire job — repair source or re-export from origin app.</p>

            <h2>Merge vs zip archive</h2>
            <p>Recipients need one scrollable document → merge. Recipients need separate files → ZIP, not merge. Visa portals specifying single PDF → merge; university portals with ten upload fields → do not merge.</p>

            <h2>Accessibility after merge</h2>
            <p>Tagged PDF structure may not survive merge — screen reader order can jump. For accessible deliverables, remediate after merge or keep tagged master separate.</p>

            <h2>HowTo summary</h2>
            <ol>
            <li>Gather source PDFs — unlock encrypted files first</li>
            <li>Rename with numeric prefixes matching checklist</li>
            <li>Upload to <a href="/pdf/merge">Merge PDF</a> in order</li>
            <li>Download — verify page count and search</li>
            <li>Compress if size rejected — <a href="/pdf/compress">Compress PDF</a></li>
            <li>Email or upload to portal</li>
            </ol>

            <h2>Beginner hub</h2>
            <p>New to PDF tools? <a href="/guides/how-to-merge-pdf-files">How to merge PDF files</a> · <a href="/guides/merge-vs-compress">merge vs compress</a>.</p>

            <h2>Troubleshooting failed merges</h2>
            <p><strong>Upload stalls:</strong> compress large scans first or use Wi-Fi. <strong>Missing pages:</strong> corrupt source — re-export from Word/Excel. <strong>Wrong rotation:</strong> fix in Preview before merge, not after. <strong>Password error:</strong> unlock each file — see password-protected merge guide.</p>

            <h2>Corporate IT policies</h2>
            <p>Some enterprises block browser uploads — request IT allowlist for ratpdf.com merge path or use approved VM. Do not merge export-controlled PDFs on personal devices.</p>
            """

MERGE_VISA_EXTRA = """
            <h2>Country-specific merge notes</h2>
            <p><strong>Schengen:</strong> <a href="/guides/compress-pdf-schengen-visa">Schengen compress</a> · <strong>UK:</strong> <a href="/guides/compress-pdf-ukvi">UKVI compress</a> · <strong>Australia:</strong> <a href="/guides/compress-pdf-home-affairs-australia">Home Affairs compress</a> · <strong>Canada:</strong> <a href="/guides/compress-pdf-immigration-canada">IRCC compress</a>.</p>
            <p>Financial evidence order: some embassies want oldest statement first, others newest — read live checklist PDF from consulate site.</p>
            """

MERGE_PROTECTED_EXTRA = """
            <h2>Re-protecting merged output</h2>
            <p>If recipient requires password on final pack, use Protect PDF after merge — separate step. Owner password for print restrictions is different from user open password.</p>
            <p>Loan brokers: never send unlock passwords in same thread as merged bank statements — use phone handoff for passwords.</p>
            """

OCR_MEGA = """
            <h2>Accuracy expectations by document type</h2>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>Type</th><th>Typical accuracy</th><th>Action</th></tr></thead>
            <tbody>
            <tr><td>Typed laser print</td><td>High</td><td>OCR + spot-check amounts</td></tr>
            <tr><td>Dot-matrix / fax</td><td>Low</td><td>Re-scan or retype critical fields</td></tr>
            <tr><td>Handwritten margin notes</td><td>Very low</td><td>Retype notes; OCR body only</td></tr>
            <tr><td>Tables with rules</td><td>Medium</td><td>Verify column alignment in export</td></tr>
            </tbody>
            </table></div>

            <h2>Downstream automation</h2>
            <p>Export OCR'd text to Python RAG pipelines — <a href="/guides/pdf-to-text-python-workflow">PDF to text Python workflow</a>. Chunk UTF-8 files; do not feed raw PDF images to LLM without OCR.</p>

            <h2>Legal and compliance</h2>
            <p>OCR output is working copy — signed scan remains evidence. For court production, confirm OCR meets local e-discovery rules — <a href="/guides/ocr-pdf-ediscovery">e-discovery OCR guide</a>.</p>

            <h2>Batch queue discipline</h2>
            <p>One PDF per OCR session on free tier — name outputs <code>doc-ocr-searchable.pdf</code> immediately; browser refresh loses in-memory state.</p>

            <h2>Compare cloud OCR vendors</h2>
            <p><a href="/guides/tesseract-vs-online-ocr">Tesseract vs online OCR</a> — privacy, cost, and accuracy trade-offs for {name} documents.</p>

            <h2>Compress after OCR?</h2>
            <p>OCR adds text layer — file grows. Compress after OCR succeeds, not before — <a href="/research/pdf-compression-benchmark">compression benchmark</a>.</p>

            <h2>HowTo summary</h2>
            <ol>
            <li>Scan 300 DPI grayscale (or colour for stamps)</li>
            <li>Deskew and crop in Preview/Photos if needed</li>
            <li>Upload to <a href="/pdf/ocrpdf">OCR PDF</a></li>
            <li>Verify search in viewer</li>
            <li>Export text or convert to Word</li>
            <li>Proofread {script} fields manually</li>
            </ol>

            <h2>Desktop scanner profiles</h2>
            <p>Save TWAIN profile "OCR-{name}-300dpi-gray" — one-click rescan when first pass fails QA. Avoid colour unless stamps or signatures need hue discrimination.</p>

            <h2>GDPR and PII</h2>
            <p>{name} identity documents contain PII — OCR on RatPDF over HTTPS; delete local copies after HR onboarding completes. Do not OCR passports on untrusted browser extensions.</p>
            """

OCR_PREMIUM = """
            <h2>Regulatory and discovery context</h2>
            <p>OCR for e-discovery prep: <a href="/guides/ocr-pdf-ediscovery">OCR PDF e-discovery</a>. Small firm productions — not Relativity replacement.</p>

            <h2>Accessibility angle</h2>
            <p>OCR helps search for screen-reader users when tags missing — see <a href="/guides/pdf-to-text-accessibility">PDF to text accessibility</a>. True WCAG compliance still needs tagging.</p>

            <h2>Upgrade prompt</h2>
            <p>High-volume OCR queues — <a href="/Subscription/Plans">compare plans</a> · Compare: <a href="/compare/ilovepdf-alternative">iLovePDF alternative</a>.</p>
            """

OCR_LANG_EXTRA = """
            <h2>Mixed-language pages</h2>
            <p>English headers with {name} body text — OCR may favour Latin script. Proofread {script} sections manually; split pages if accuracy diverges.</p>

            <h2>Export and encoding</h2>
            <p>RatPDF exports UTF-8 — Excel, Python, and Google Docs accept output. Garbled text means wrong encoding in downstream app — not OCR export.</p>

            <h2>Second example: archive digitization</h2>
            <p>Box of 1998 {name} contracts — batch scan 300 DPI, OCR each PDF, merge volumes with <a href="/guides/merge-pdf-online">merge PDF online</a> for chronological archive ZIP.</p>

            <h2>Proofreading workflow</h2>
            <ol>
            <li>OCR PDF — download searchable copy</li>
            <li>Ctrl+F three known terms (date, party name, amount)</li>
            <li>Export sample page to <a href="/pdf/pdftotext">PDF to Text</a> — compare character accuracy</li>
            <li>Flag pages below 95% confidence for human retype</li>
            <li>Archive both image-only source and OCR output</li>
            </ol>

            <h2>Mobile and browser notes</h2>
            <p>Phone photo PDFs OCR worse than flatbed scans — rescan when quality matters. Safari and Chrome both supported; keep tab open until download completes.</p>

            <h2>Invoice and receipt {name} scans</h2>
            <p>Thermal receipts fade — OCR within weeks of purchase. VAT totals and supplier names need manual verification against accounting system.</p>

            <h2>Peer language guide</h2>
            <p>Related: <a href="/guides/{peer}">OCR PDF {peer_name}</a> · Pillar: <a href="/guides/ocr-pdf">OCR PDF hub</a> · Compare: <a href="/compare/ilovepdf-alternative">iLovePDF alternative</a>.</p>

            <h2>Subscription and limits</h2>
            <p>Free tier: three OCR uses per tool per day. Agencies digitizing backlogs upgrade to Pro — <a href="/Subscription/Plans">compare plans</a>.</p>
            """

OCR_POOR_QUALITY_EXTRA = """
            <h2>Diagnose before re-OCR</h2>
            <p>Zoom to 400% — if letters are smooth curves, DPI may suffice; if blocky pixels, re-scan. Coffee stains and fold shadows need crop or re-scan, not second OCR pass.</p>

            <h2>Enhancement order</h2>
            <ol>
            <li>Deskew rotation</li>
            <li>Crop margins</li>
            <li>Increase contrast (not blur-sharpen filters)</li>
            <li>OCR at 300 DPI equivalent</li>
            <li>Compress only after OCR succeeds</li>
            </ol>

            <h2>Fax and phone photo sources</h2>
            <p>Fax PDFs are ~200 DPI with horizontal lines — remove moiré with grayscale rescan when possible. Phone photos need flat surface and even lighting — avoid flash glare.</p>
            """

MERGE_FINAL_BOOST = """
            <h2>Stakeholder communication</h2>
            <p>When sending merged packs to clients, email body should list contents: "Attached single PDF: cover (pp. 1–2), contract (pp. 3–18), exhibits (pp. 19–40)." Reduces "missing attachment" confusion when they search for a separate file.</p>

            <h2>Long-term archival</h2>
            <p>Store merged PDF plus manifest CSV listing source filenames and SHA-256 hashes — auditors reconstruct order years later. Cloud backup: <a href="/guides/compress-pdf-cloud-storage">compress for cloud storage</a> before sync.</p>

            <h2>FAQ inline</h2>
            <p><strong>Can I merge Word files?</strong> Export DOCX to PDF first via <a href="/pdf/doctopdf">Word to PDF</a>. <strong>Does merge reduce page count?</strong> No — total pages sum unless you deduplicate sources. <strong>Merge on phone?</strong> Yes in mobile browser — same tool URL.</p>

            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Ready to merge?</strong> <a href="/pdf/merge" class="alert-link fw-semibold">Merge PDF →</a> · <a href="/Subscription/Plans">Upgrade for volume</a></div>

            <h2>Closing summary</h2>
            <p>Merge is irreversible ordering — prefix files, verify page count, compress once if needed, then deliver. RatPDF smart merge keeps digital text sharp; scans stay images until you OCR the merged pack separately.</p>
            """

OCR_FINAL_BOOST = """
            <h2>Translation and NLP after OCR</h2>
            <p>UTF-8 text exports feed Google Translate API, DeepL, or local MarianMT — OCR quality caps translation quality. Proofread {name} proper nouns before machine translation of contracts.</p>

            <h2>Redaction warning</h2>
            <p>OCR text layer may include redacted content still readable in object stream if redaction was fake black boxes — use true redaction tool before OCR for sensitive releases.</p>

            <h2>Government portal uploads</h2>
            <p>India GST notices, EU tax letters, immigration forms — searchable OCR PDF satisfies "text selectable" portal checks where specified.</p>

            <h2>FAQ inline</h2>
            <p><strong>Is OCR free?</strong> Three OCR uses per day on free tier. <strong>Handwriting?</strong> Not reliable — retype. <strong>Password PDF?</strong> <a href="/pdf/unlock">Unlock</a> first.</p>

            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Search your {name} scans</strong> <a href="/pdf/ocrpdf" class="alert-link fw-semibold">OCR PDF →</a></div>

            <h2>Closing summary</h2>
            <p>{name} OCR is scan quality in, searchable PDF out — proofread every field that moves money, crosses a border, or enters a court file. Then chain to PDF to Text or Word for editing.</p>
            <p>Bookmark this guide for your team's wiki — consistent scan settings beat trying a different OCR vendor each week.</p>
            """

OCR_LANG_LONG = {
    "ocr-pdf-hindi": """
            <h2>India-specific use cases</h2>
            <p>GST notices, income tax intimation, and state registration letters often arrive as Hindi scans. OCR enables grep across thousands of archived notices for GSTIN and assessment year.</p>
            <p>Pair with <a href="/guides/pdf-to-text-multilingual">multilingual PDF to text</a> and <a href="/guides/compress-pdf-gst-portal">GST portal compress</a> when re-uploading compressed copies.</p>
            """,
    "ocr-pdf-arabic": """
            <h2>RTL layout in Word export</h2>
            <p>After OCR, <a href="/guides/scanned-pdf-to-word">PDF to Word</a> may need manual RTL paragraph direction in Word for Arabic body text. Plain .txt export is fine for search indexing, not for publishing.</p>
            """,
    "ocr-pdf-chinese": """
            <h2>Simplified vs traditional</h2>
            <p>Mainland contracts use simplified characters; Taiwan/HK may use traditional — OCR accuracy differs. Specify source region when proofreading party names on bilingual contracts.</p>
            """,
    "ocr-pdf-japanese": """
            <h2>Vertical document handling</h2>
            <p>Manga-style vertical contracts need horizontal rescan when possible. If vertical is mandatory, expect column-order errors — budget manual cleanup time.</p>
            """,
    "ocr-pdf-korean": """
            <h2>Hangul business registration</h2>
            <p>Corporate registration extracts mix Hangul and digits — verify business registration numbers character-by-character against government portal lookup.</p>
            """,
    "ocr-pdf-poor-quality": """
            <h2>When to abandon OCR</h2>
            <p>If three OCR passes with preprocessing still produce garbage, human transcription is cheaper than attorney time fixing errors in court filings.</p>

            <h2>Professional restoration services</h2>
            <p>Museum-grade document restoration exceeds browser OCR scope — for one-of-a-kind deeds, use conservation lab before scanning.</p>

            <h2>Iterative enhancement loop</h2>
            <p>Run OCR → export text sample → if garbage, adjust DPI/contrast → re-OCR — max three iterations before rescanning source paper. Document each attempt in case file for court.</p>

            <h2>Software preprocessing tools</h2>
            <p>Preview auto-enhance, GIMP levels, or scanner driver "text mode" before upload — RatPDF OCR cannot fix 72 DPI phone photos of wall posters.</p>

            <h2>Benchmark your fixes</h2>
            <p>Before/after OCR: search for same 10-word phrase — if character error rate drops below 5%, ship; else rescan. Log DPI and filter settings that worked for repeat batches.</p>
            """,
}

# Default filler for European languages
OCR_EU_LONG = """
            <h2>EU contract and invoice scans</h2>
            <p>Cross-border B2B paperwork often mixes English summaries with {name} body text. OCR both sections; verify VAT IDs and IBANs in Latin charset even when body is {name}.</p>
            <p>EDGAR and Companies House filings downloaded as PDF may already be digital — skip OCR if text selects.</p>
            """

MERGE_1500_TOPUP = """
            <h2>Print and bindery handoff</h2>
            <p>Print shops ask for single PDF with bleed marks removed — merge first, then preflight in Acrobat alternative if colours shift. Staple-bound packets need consistent page size — resize sources before merge when binder specifies.</p>

            <h2>Litigation hold merges</h2>
            <p>When legal hold applies, merged output is discoverable — log who merged, when, and from which sources. Do not merge privileged docs with non-privileged without counsel review.</p>

            <h2>API and automation boundary</h2>
            <p>RatPDF merge is browser UI — no public merge API on free tier. Repeatable human merge with prefixed folders scales to hundreds of files per month for paralegals.</p>

            <h2>Email vs portal delivery</h2>
            <p>Law firms email merged exhibits under 20 MB; immigration portals often cap 5 MB — compress after merge QA. Subject line: "Merged exhibit bundle — 47 pages — INV-2026-041".</p>

            <h2>Checksum verification</h2>
            <p>Hash merged PDF before email — recipient confirms SHA match out-of-band for high-stakes filings. Prevents wrong-version disputes in M&amp;A data rooms.</p>

            <h2>Tool CTA reminder</h2>
            <p>Primary action: <a href="/pdf/merge">Merge PDF</a> — compress at <a href="/pdf/compress">Compress PDF</a> only if portal or email rejects size.</p>
            """

WAVE2_CLOSING_MERGE = """
            <h2>Document lifecycle after merge</h2>
            <p>Treat merged PDF as published artifact — version it, log recipients, and retain sources. If downstream signer needs only appendix, split back out rather than re-sending full 200-page pack.</p>
            <p>Compare tools before committing workflow: <a href="/compare">compare tools</a> · Research: <a href="/research/pdf-compression-benchmark">compression benchmark</a>.</p>
            <p>Need editable text after merge? OCR the merged scan pack or convert digital sections with <a href="/guides/scanned-pdf-to-word">scanned PDF to Word</a>.</p>
            """

WAVE2_CLOSING_OCR = """
            <h2>Document lifecycle after OCR</h2>
            <p>Archive image-only source unchanged — OCR PDF is derivative. For retention policies, keep both; for GDPR erasure requests, delete both layers from all backups.</p>
            <p>Research: <a href="/research/pdf-compression-benchmark">compression benchmark</a> if archiving terabytes of OCR'd scans.</p>
            <p>Primary tool: <a href="/pdf/ocrpdf">OCR PDF</a> · Text export: <a href="/pdf/pdftotext">PDF to Text</a> · Upgrade: <a href="/Subscription/Plans">plans</a>.</p>
            <p>Re-run OCR after any rotate/crop edit to image-only PDF — text layer from prior pass no longer aligns with pixels.</p>
            """


OCR_1500_TOPUP = """
            <h2>Quality sampling for large jobs</h2>
            <p>OCR 500 pages? Sample 5% — if error rate above 2% on names/amounts, adjust scan settings and re-run batch. Do not spot-check only page 1.</p>

            <h2>Font and stamp overlays</h2>
            <p>Official stamps over {name} text reduce confidence — OCR may miss stamped regions. Legally critical stamped paragraphs may need manual transcription.</p>

            <h2>Seasonal backlog tips</h2>
            <p>Tax season floods firms with {name} scans — queue OCR overnight, verify mornings. Pro tier removes daily friction for backlogs.</p>

            <h2>Integration with merge cluster</h2>
            <p>OCR'd packs often merge next — <a href="/guides/merge-scanned-digital-pdf">merge scanned and digital</a> · <a href="/guides/merge-pdf-without-quality-loss">quality merge</a>.</p>

            <h2>Related invoice guides</h2>
            <p>Scanned supplier invoices in {name}: OCR → extract totals → match to <a href="/guides/invoice-generator-india">invoice workflows</a> or local ERP.</p>

            <h2>Keyboard shortcuts after OCR</h2>
            <p>In PDF viewer: Ctrl+F for QA terms. In Word after conversion: Navigation pane headings — if empty, source PDF lacked structure; OCR text still usable for search.</p>

            <h2>Compare vendors</h2>
            <p><a href="/compare/adobe-alternative">Adobe alternative</a> · <a href="/compare/smallpdf-alternative">Smallpdf alternative</a> — evaluate privacy before uploading {name} PII scans.</p>

            <h2>OCR cluster peer pages</h2>
            <p>Language guides: <a href="/guides/ocr-pdf-hindi">Hindi</a> · <a href="/guides/ocr-pdf-arabic">Arabic</a> · <a href="/guides/ocr-pdf-spanish">Spanish</a> · Quality: <a href="/guides/ocr-pdf-poor-quality">poor quality OCR</a>.</p>
            """

