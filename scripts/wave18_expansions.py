"""Wave 18 — PDF conversion guides + regional compress upgrades."""

W18_SLUGS = [
    "ocr-pdf-to-text",
    "pdf-to-text-online",
    "how-to-convert-pdf-to-word",
    "pdf-to-word-converter",
    "how-to-convert-pdf-to-text",
    "scanned-pdf-to-text",
    "pdf-to-text-on-android",
    "pdf-to-text-on-iphone",
    "pdf-to-text-accessibility",
    "compress-pdf-ucas",
    "compress-pdf-uidai",
    "compress-pdf-ukvi",
    "compress-pdf-usajobs",
    "compress-pdf-for-passport-application",
    "compress-pdf-for-university-application",
    "pdf-to-text-python-workflow",
    "pdf-to-text-multilingual",
]

W18_DATA = {
    "ocr-pdf-to-text": {
        "title": "OCR PDF to Text — Full Workflow for Scanned Documents (2026)",
        "tool": "/pdf/ocrpdf",
        "label": "OCR PDF",
        "pillar": "/guides/pdf-txt-guide",
        "pillar_label": "PDF to Text guide",
        "programmatic": "/pdf-to-txt/ocr-pdf-to-text",
        "example": "Paralegal OCRs 200-page scanned deposition, then exports UTF-8 text for keyword review",
    },
    "pdf-to-text-online": {
        "title": "PDF to Text Online — Extract Plain Text in Your Browser (2026)",
        "tool": "/pdf/pdftotext",
        "label": "PDF to Text",
        "pillar": "/guides/pdf-txt-guide",
        "pillar_label": "PDF to Text guide",
        "programmatic": "/pdf-to-txt/pdf-to-text-online",
        "example": "Researcher pulls quotes from digital journal PDF into Obsidian without retyping",
    },
    "how-to-convert-pdf-to-word": {
        "title": "How to Convert PDF to Word — Step-by-Step Tutorial (2026)",
        "tool": "/pdf/pdftodoc",
        "label": "PDF to Word",
        "pillar": "/guides/pdf-to-word",
        "pillar_label": "PDF to Word guide",
        "programmatic": "/pdf-to-word/how-to-convert-pdf-to-word",
        "example": "HR edits offer letter PDF exported from legacy system — Word redlines before countersign",
    },
    "pdf-to-word-converter": {
        "title": "PDF to Word Converter — Digital vs Scanned, Limits &amp; Best Tools (2026)",
        "tool": "/pdf/pdftodoc",
        "label": "PDF to Word",
        "pillar": "/guides/pdf-to-word",
        "pillar_label": "PDF to Word guide",
        "programmatic": "/pdf-to-word/convert-pdf-to-word",
        "example": "Freelancer converts client SOW PDF to DOCX for milestone table edits",
    },
    "how-to-convert-pdf-to-text": {
        "title": "How to Convert PDF to Text — Digital &amp; Scanned Workflows (2026)",
        "tool": "/pdf/pdftotext",
        "label": "PDF to Text",
        "pillar": "/guides/pdf-txt-guide",
        "pillar_label": "PDF to Text guide",
        "programmatic": "/pdf-to-txt/how-do-i-convert-pdf-to-text",
        "example": "Developer exports API spec PDF to .txt for grep and CI documentation search",
    },
    "scanned-pdf-to-text": {
        "title": "Scanned PDF to Text — OCR Pipeline &amp; Quality Checks (2026)",
        "tool": "/pdf/ocrpdf",
        "label": "OCR PDF",
        "pillar": "/guides/ocr-pdf",
        "pillar_label": "OCR PDF guide",
        "programmatic": "/pdf-to-txt/how-scanned-pdf-to-text",
        "example": "Clinic digitizes paper intake forms — OCR then text export for EHR indexing",
    },
    "pdf-to-text-on-android": {
        "title": "PDF to Text on Android — Chrome, Drive &amp; Mobile Workflow (2026)",
        "tool": "/pdf/pdftotext",
        "label": "PDF to Text",
        "pillar": "/guides/pdf-txt-guide",
        "pillar_label": "PDF to Text guide",
        "programmatic": "/pdf-to-txt/pdf-to-text-android",
        "example": "Field auditor extracts clause text from vendor PDF on phone before site visit",
    },
    "pdf-to-text-on-iphone": {
        "title": "PDF to Text on iPhone — Safari, Files &amp; iOS Workflow (2026)",
        "tool": "/pdf/pdftotext",
        "label": "PDF to Text",
        "pillar": "/guides/pdf-txt-guide",
        "pillar_label": "PDF to Text guide",
        "programmatic": "/pdf-to-txt/pdf-to-text-iphone",
        "example": "Consultant copies meeting notes from client PDF on iPad during flight",
    },
    "pdf-to-text-accessibility": {
        "title": "PDF to Text for Accessibility — Screen Readers &amp; Searchable OCR (2026)",
        "tool": "/pdf/ocrpdf",
        "label": "OCR PDF",
        "pillar": "/guides/pdf-ua-accessibility",
        "pillar_label": "PDF/UA accessibility guide",
        "programmatic": "/pdf-to-txt/pdf-to-text-online",
        "example": "University disability office OCRs scanned course packs so VoiceOver can read content",
    },
    "compress-pdf-ucas": {
        "title": "Compress PDF for UCAS — UK University Application Upload Fix (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/compress-pdf-guide",
        "pillar_label": "compress PDF guide",
        "programmatic": "/guides/compress-pdf-ucas",
        "example": "A-level student shrinks reference letter PDF from 8 MB to 1.2 MB for UCAS reference upload",
    },
    "compress-pdf-uidai": {
        "title": "Compress PDF for UIDAI — Aadhaar Update &amp; Enrolment Upload Fix (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/compress-pdf-guide",
        "pillar_label": "compress PDF guide",
        "programmatic": "/compress-aadhar-pdf",
        "example": "Resident compresses address proof scan from 4 MB phone photo to 900 KB for uidai.gov.in",
    },
    "compress-pdf-ukvi": {
        "title": "Compress PDF for UKVI — UK Visa Document Upload Fix (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/compress-pdf-for-visa-application",
        "pillar_label": "visa application compress guide",
        "programmatic": "/guides/compress-pdf-ukvi",
        "example": "Skilled worker applicant fits bank statement PDF under 6 MB UKVI slot",
    },
    "compress-pdf-usajobs": {
        "title": "Compress PDF for USAJOBS — Federal Resume Upload Fix (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/compress-pdf-for-job-application",
        "pillar_label": "job application compress guide",
        "programmatic": "/guides/compress-pdf-usajobs",
        "example": "Federal applicant compresses 5 MB resume PDF to 2 MB for USAJOBS attachment field",
    },
    "compress-pdf-for-passport-application": {
        "title": "Compress PDF for Passport Application — Global Portal Size Fix (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/compress-pdf-guide",
        "pillar_label": "compress PDF guide",
        "programmatic": "/guides/compress-pdf-passport-india",
        "example": "Applicant compresses affidavit scan for Passport Seva without blurring MRZ zone",
    },
    "compress-pdf-for-university-application": {
        "title": "Compress PDF for University Application — Portal Upload Guide (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/compress-pdf-common-app",
        "pillar_label": "Common App compress guide",
        "programmatic": "/guides/compress-pdf-for-university-application",
        "example": "International student compresses transcript PDF for 3 MB portal cap",
    },
    "pdf-to-text-python-workflow": {
        "title": "PDF to Text Python Workflow — Export, Parse &amp; Automate (2026)",
        "tool": "/pdf/pdftotext",
        "label": "PDF to Text",
        "pillar": "/guides/pdf-txt-guide",
        "pillar_label": "PDF to Text guide",
        "programmatic": "/pdf-to-txt/extract-text-from-pdf",
        "example": "Data team exports quarterly report PDFs to UTF-8 .txt then chunks for RAG pipeline",
    },
    "pdf-to-text-multilingual": {
        "title": "PDF to Text Multilingual — Hindi, Arabic, UTF-8 &amp; OCR (2026)",
        "tool": "/pdf/pdftotext",
        "label": "PDF to Text",
        "pillar": "/guides/pdf-txt-guide",
        "pillar_label": "PDF to Text guide",
        "programmatic": "/pdf-to-txt/pdf-to-text-online",
        "example": "Compliance officer extracts Hindi GST notice text after OCR for translation review",
    },
}

W18_CONVERT_DEEP = {
    "ocr-pdf-to-text": """
            <h2>Two-step pipeline explained</h2>
            <p>Image-only PDFs have no text layer — <strong>OCR PDF to Text</strong> always means:</p>
            <ol>
            <li><a href="/pdf/ocrpdf">OCR PDF</a> — adds hidden searchable Unicode text under each page image.</li>
            <li><a href="/pdf/pdftotext">PDF to Text</a> — reads that layer and exports UTF-8 <code>.txt</code>.</li>
            </ol>
            <p>Quick tool page: <a href="/pdf-to-txt/ocr-pdf-to-text">OCR PDF to Text landing</a>.</p>
            <h2>Scan settings for best OCR</h2>
            <p>300 DPI grayscale, straight alignment, no shadow from phone camera. Skew above 5° increases character errors on account numbers. Crop black borders before upload.</p>
            <h2>Proofread checklist</h2>
            <ul>
            <li>Currency amounts and dates — OCR confuses 8/B, 1/l, 0/O</li>
            <li>Proper names and addresses on visa/KYC docs</li>
            <li>Multi-column layouts — text may merge columns in .txt output</li>
            </ul>
            <h2>After text export</h2>
            <p>Need editable layout? <a href="/guides/scanned-pdf-to-word">Scanned PDF to Word</a>. Need tables? <a href="/pdf/pdftoexcel">PDF to Excel</a> on digital exports. E-discovery: <a href="/guides/ocr-pdf-ediscovery">OCR for e-discovery</a>.</p>
            """,
    "pdf-to-text-online": """
            <h2>Digital vs scanned — 10-second test</h2>
            <p>Try selecting a sentence in your PDF viewer. Highlight works → upload to <a href="/pdf/pdftotext">PDF to Text</a>. No selection → <a href="/guides/ocr-pdf-to-text">OCR PDF to Text workflow</a> first.</p>
            <h2>What you get</h2>
            <p>Plain UTF-8 text — no bold, tables, or images. Best for search, scripting, LLM prompts, and paste into email. For formatted edits use <a href="/pdf/pdftodoc">PDF to Word</a>.</p>
            <h2>Online limits (2026)</h2>
            <p>Free tier: 3 uses per tool per day, 200 MB per file. Pro: higher volume and 4 GB uploads. Files deleted after processing — see privacy policy for retention.</p>
            <h2>Use cases</h2>
            <ul>
            <li>Pull job description bullets into cover letter draft</li>
            <li>Extract visa form field labels into checklist</li>
            <li>Grep bank statement text for duplicate transactions</li>
            <li>Quote research paper passages into Zotero notes</li>
            </ul>
            <p>Tool landing: <a href="/pdf-to-txt/pdf-to-text-online">PDF to Text online</a>.</p>
            """,
    "how-to-convert-pdf-to-word": """
            <h2>Step-by-step (digital PDF)</h2>
            <ol>
            <li>Open <a href="/pdf/pdftodoc">PDF to Word</a> in Chrome, Safari, or Edge.</li>
            <li>Upload PDF — unlock password-protected files first.</li>
            <li>Download DOCX when processing completes.</li>
            <li>Open in Word or Google Docs — verify page 1 tables and headers.</li>
            <li>After edits, <a href="/pdf/doctopdf">Word to PDF</a> for delivery.</li>
            </ol>
            <h2>Scanned PDF path</h2>
            <p>Run <a href="/pdf/ocrpdf">OCR PDF</a> first — then PDF to Word. Without OCR, pages become images inside DOCX.</p>
            <h2>Quality expectations</h2>
            <p>Digital contracts and reports convert well. Canva-style design PDFs may embed pages as images — keep original PDF for print. See <a href="/guides/pdf-to-word-keep-formatting">keep formatting guide</a>.</p>
            <p>Tutorial landing: <a href="/pdf-to-word/how-to-convert-pdf-to-word">How to convert PDF to Word</a>.</p>
            """,
    "pdf-to-word-converter": """
            <h2>What a PDF to Word converter does</h2>
            <p>Reads PDF structure (paragraphs, tables, fonts) and rebuilds an editable DOCX. RatPDF uses pdf2docx on digital PDFs with page-render fallback when structure is missing.</p>
            <h2>Converter vs copy-paste</h2>
            <p>Copy-paste from PDF viewer loses table structure and line breaks. Converter preserves rows on digital invoices and contracts — still proofread totals.</p>
            <h2>When not to convert</h2>
            <ul>
            <li>Signed executed contracts — archive PDF; convert draft only</li>
            <li>Official transcripts — registrar verification may require original PDF</li>
            <li>Invoices you issued — regenerate from <a href="/invoice/create">Create Invoice</a></li>
            </ul>
            <p>Beginner definition: <a href="/guides/glossary-pdf-to-word-converter">what is a PDF to Word converter?</a> · Compare: <a href="/compare/adobe-acrobat-alternative">Adobe alternative</a>.</p>
            """,
    "how-to-convert-pdf-to-text": """
            <h2>Digital PDF workflow</h2>
            <ol>
            <li>Confirm text selects in viewer.</li>
            <li>Upload to <a href="/pdf/pdftotext">PDF to Text</a>.</li>
            <li>Download <code>.txt</code> or copy preview.</li>
            </ol>
            <h2>Scanned PDF workflow</h2>
            <ol>
            <li><a href="/pdf/ocrpdf">OCR PDF</a> on the scan.</li>
            <li>Download searchable PDF.</li>
            <li>Upload to PDF to Text.</li>
            <li>Proofread numbers and names.</li>
            </ol>
            <h2>Word vs Text decision</h2>
            <p>Need headings and tables editable? <a href="/guides/how-to-convert-pdf-to-word">PDF to Word tutorial</a>. Need grep/LLM/search only? Plain text wins. Compare: <a href="/guides/pdf-to-word-vs-pdf-to-text">Word vs Text</a>.</p>
            """,
    "scanned-pdf-to-text": """
            <h2>Why scans fail direct text extraction</h2>
            <p>Phone and flatbed scans store pages as JPEG/PNG inside PDF — no character data exists until OCR runs. Uploading directly to PDF to Text returns empty or garbage output.</p>
            <h2>Recommended pipeline</h2>
            <ol>
            <li>Scan 200–300 DPI grayscale (colour only if stamps matter).</li>
            <li>OCR with <a href="/pdf/ocrpdf">OCR PDF</a>.</li>
            <li>Test search for a known word in the OCR'd PDF.</li>
            <li>Extract with <a href="/pdf/pdftotext">PDF to Text</a>.</li>
            </ol>
            <h2>Fax and photo PDFs</h2>
            <p>Multi-page phone photos merged to PDF — OCR each page; low contrast fax headers often misread dates. Re-scan if critical field fails search test.</p>
            <p>Related: <a href="/pdf-to-txt/how-scanned-pdf-to-text">scanned PDF to text landing</a> · <a href="/guides/ocr-scanned-pdf-workflow">OCR scanned workflow</a>.</p>
            """,
    "pdf-to-text-on-android": """
            <h2>Android browser workflow</h2>
            <ol>
            <li>Open RatPDF in Chrome on Android.</li>
            <li>Tap PDF to Text — upload from Files, Drive, or Downloads.</li>
            <li>Wait for processing — use Wi-Fi for files over 15 MB.</li>
            <li>Download .txt to Downloads or share to Notes app.</li>
            </ol>
            <h2>Scans on Android</h2>
            <p>Google Drive scan app → PDF → OCR PDF in browser → PDF to Text. Direct camera PDF without OCR will not extract text.</p>
            <h2>Limits on mobile data</h2>
            <p>Large legal PDFs on cellular may timeout — switch to Wi-Fi or split with <a href="/pdf/split">Split PDF</a> first.</p>
            """,
    "pdf-to-text-on-iphone": """
            <h2>iPhone and iPad workflow</h2>
            <ol>
            <li>Safari → <a href="/pdf/pdftotext">PDF to Text</a>.</li>
            <li>Upload from Files, iCloud Drive, or email attachment save.</li>
            <li>Download .txt to Files — open in Notes or Bear.</li>
            </ol>
            <h2>Scans from iOS Notes</h2>
            <p>Notes document scan → Share as PDF → OCR PDF → PDF to Text. Preview app cannot export editable text from scans.</p>
            <h2>Privacy on shared iPad</h2>
            <p>Clear Safari downloads after confidential client PDFs — use private relay Wi-Fi on sensitive matter.</p>
            """,
    "pdf-to-text-accessibility": """
            <h2>OCR vs true accessible PDF</h2>
            <p>OCR adds searchable text for many assistive tools but does not replace <strong>tagged PDF</strong> structure required for full WCAG/ Section 508 compliance. See <a href="/guides/pdf-ua-accessibility">PDF/UA guide</a> and <a href="/guides/section-508-pdf">Section 508 PDF</a>.</p>
            <h2>When OCR helps accessibility</h2>
            <ul>
            <li>Legacy scan archives with no tags — VoiceOver/NVDA can read OCR text layer</li>
            <li>Course packs scanned by professors — interim fix before remediation</li>
            <li>Public records requests — searchable text for citizens using screen readers</li>
            </ul>
            <h2>Workflow</h2>
            <p>OCR PDF → verify read-aloud in Acrobat or PAC checker → export text for alt-text audit log. For publishing, plan full tagging remediation.</p>
            <h2>Plain text export role</h2>
            <p>Offer .txt alternative format alongside PDF when policy allows — some users prefer Notepad/VoiceOver on plain UTF-8.</p>
            """,
    "pdf-to-text-python-workflow": """
            <h2>Export then parse pattern</h2>
            <p>RatPDF browser export produces UTF-8 <code>.txt</code> — automate download in CI or manual batch, then:</p>
            <pre><code>from pathlib import Path
            text = Path("report.txt").read_text(encoding="utf-8")
            chunks = text.split("\\n\\n")  # naive paragraph split</code></pre>
            <h2>OCR before Python on scans</h2>
            <p>Never feed raw image PDF bytes to text parsers — OCR in browser first, download searchable PDF, then PDF to Text export.</p>
            <h2>RAG and NLP tips</h2>
            <ul>
            <li>Chunk by page markers if export includes form feeds</li>
            <li>Strip headers/footers repeated on every page before embedding</li>
            <li>Log source PDF hash alongside .txt for audit trail</li>
            </ul>
            <p>Related: <a href="/guides/pdf-to-text-bank-statements">bank statement text</a> · <a href="/guides/pdf-to-text-research">research extraction</a>.</p>
            """,
    "pdf-to-text-multilingual": """
            <h2>Unicode and embedded fonts</h2>
            <p>Digital PDFs with embedded Unicode fonts extract Hindi, Arabic, and European characters cleanly to UTF-8 .txt. Missing font embedding causes tofu boxes — OCR the rendered page instead.</p>
            <h2>RTL scripts (Arabic, Urdu)</h2>
            <p>Plain .txt may display RTL order incorrectly in Notepad — use Word export for layout editing. Search still works on extracted UTF-8 in tools that handle bidi.</p>
            <h2>OCR by language</h2>
            <p>Scanned Devanagari: <a href="/guides/ocr-pdf-hindi">OCR Hindi guide</a>. Arabic: <a href="/guides/ocr-pdf-arabic">OCR Arabic</a>. Chinese: <a href="/guides/ocr-pdf-chinese">OCR Chinese</a>. Always proofread matras and diacritics.</p>
            <h2>GST and India compliance text</h2>
            <p>Extract notice text for CA review — pair with <a href="/guides/compress-pdf-gst-portal">GST portal compress</a> when re-uploading compressed copies.</p>
            """,
}

W18_COMPRESS_DEEP = {
    "compress-pdf-ucas": """
            <h2>UCAS and direct uni portal caps</h2>
            <p>UCAS reference and application uploads vary by institution — many fields cap <strong>1–5 MB</strong>. Read the live widget before compressing — Oxford/Cambridge supplementary forms may differ from UCAS hub.</p>
            <h2>Document-specific tips</h2>
            <ul>
            <li><strong>Reference letters</strong> — digital PDF from Word usually compresses 20–40% at Recommended</li>
            <li><strong>Transcripts</strong> — Less compression if small stamp text must stay sharp</li>
            <li><strong>Portfolio PDFs</strong> — image-heavy; Extreme only as last resort — verify art detail</li>
            </ul>
            <h2>Workflow</h2>
            <ol>
            <li>Export one PDF per UCAS field unless bundle explicitly allowed</li>
            <li>Compress with Recommended — target 2 MB headroom under cap</li>
            <li>Verify at 100% zoom — upload</li>
            </ol>
            <p>Also: <a href="/guides/compress-pdf-for-university-application">university application compress</a> · <a href="/guides/compress-pdf-ukvi">UKVI</a> (visa ≠ UCAS).</p>
            """,
    "compress-pdf-uidai": """
            <h2>UIDAI upload rejection causes</h2>
            <p>Phone camera scans at full 12 MP resolution produce 3–8 MB single-page PDFs — uidai.gov.in slots often want <strong>500 KB–2 MB</strong>. Compress does not fix blur — re-scan at 200 DPI if unreadable.</p>
            <h2>Scan hygiene</h2>
            <p>Grayscale address proof — colour only if stamp colour legally required. Flat document on contrasting surface — no curved page shadow.</p>
            <h2>Compression levels</h2>
            <p>Start Recommended — if still rejected, Extreme once — verify Aadhaar number digits legible. Do not compress same file three times.</p>
            <p>Related: <a href="/compress-aadhar-pdf">compress Aadhaar PDF</a> · <a href="/guides/compress-pdf-digilocker">DigiLocker</a> · <a href="/guides/compress-pdf-passport-india">Passport Seva</a>.</p>
            """,
    "compress-pdf-ukvi": """
            <h2>UKVI online upload limits</h2>
            <p>UK Visas and Immigration applications commonly cap near <strong>6 MB per PDF</strong> — confirm on gov.uk for your visa category (Skilled Worker, Student, Family).</p>
            <h2>Financial evidence</h2>
            <p>Bank statements — merge multi-month PDFs only if form allows single file. Compress after merge — one pass. MRZ on passport bio page — use Less not Extreme.</p>
            <h2>TB test, English cert, COS</h2>
            <p>Each certificate often separate slot — do not merge unless checklist says combined PDF. Name on PDF must match application exactly after compress.</p>
            <p>Hub: <a href="/guides/compress-pdf-for-visa-application">visa compress guide</a> · Schengen differs: <a href="/guides/compress-pdf-schengen-visa">Schengen VFS</a>.</p>
            """,
    "compress-pdf-usajobs": """
            <h2>USAJOBS attachment reality</h2>
            <p>USAJOBS and agency portals often limit resume PDFs to <strong>2–5 MB</strong>. Federal resume format runs longer than private sector — compress after export from Word, not before drafting.</p>
            <h2>ATS-safe compression</h2>
            <p>Digital federal resume PDF must stay text-selectable — Recommended not Extreme on vector exports. Verify job series and grade still select after compress.</p>
            <h2>Supporting documents</h2>
            <p>SF-50, transcripts, DD-214 scans — OCR if search needed, then compress. Separate attachment per USAJOBS field — read announcement instructions.</p>
            <p>Related: <a href="/guides/compress-pdf-for-job-application">job application compress</a> · <a href="/guides/compress-pdf-for-workday">Workday</a>.</p>
            """,
    "compress-pdf-for-passport-application": """
            <h2>Global passport portal caps</h2>
            <p>Passport Seva (India), HMPO (UK), State Dept (US), and VFS partners use different per-slot limits — often <strong>500 KB–5 MB</strong>. Never assume one compressed file works for all countries.</p>
            <h2>Photo and MRZ zone</h2>
            <p>Bio page compress with Less — Extreme softens machine-readable zone. Affidavits and annexures can use Recommended.</p>
            <h2>Merge policy</h2>
            <p>Most passport systems want <strong>one PDF per document type</strong> — do not merge birth cert + marriage cert unless portal explicitly allows bundle.</p>
            <p>India: <a href="/guides/compress-pdf-passport-india">Passport Seva compress</a> · Visa overlap: <a href="/guides/compress-pdf-for-visa-application">visa guide</a>.</p>
            """,
    "compress-pdf-for-university-application": """
            <h2>US vs UK vs EU portal differences</h2>
            <p>Common App ~10 MB per doc — <a href="/guides/compress-pdf-common-app">Common App guide</a>. UCAS often tighter — <a href="/guides/compress-pdf-ucas">UCAS guide</a>. EU uni portals vary 2–10 MB — read upload field error message.</p>
            <h2>Transcript and portfolio</h2>
            <p>Official transcript PDF from registrar — Less compression. Art portfolio — compress images inside PDF may need Extreme — check thumbnail legibility.</p>
            <h2>One file per slot rule</h2>
            <p>Admissions systems reject merged bundles when they expect separate transcript, test score, and ID uploads — follow each field label literally.</p>
            """,
}

W18_CONVERT_CLUSTER = """
            <h2>PDF to Text cluster</h2>
            <ul>
            <li><a href="/guides/pdf-txt-guide">PDF to Text pillar</a></li>
            <li><a href="/guides/ocr-pdf-to-text">OCR PDF to Text</a></li>
            <li><a href="/guides/pdf-to-text-online">PDF to Text online</a></li>
            <li><a href="/guides/scanned-pdf-to-text">Scanned PDF to Text</a></li>
            <li><a href="/guides/pdf-to-word-vs-pdf-to-text">Word vs Text</a></li>
            </ul>
            <p>Compare: <a href="/compare/smallpdf-alternative">Smallpdf alternative</a> · Research: <a href="/research/pdf-compression-benchmark">compression benchmark</a></p>
            """

W18_WORD_CLUSTER = """
            <h2>PDF to Word cluster</h2>
            <ul>
            <li><a href="/guides/pdf-to-word">PDF to Word pillar</a></li>
            <li><a href="/guides/how-to-convert-pdf-to-word">How to convert PDF to Word</a></li>
            <li><a href="/guides/scanned-pdf-to-word">Scanned PDF to Word</a></li>
            <li><a href="/guides/pdf-to-word-keep-formatting">Keep formatting</a></li>
            </ul>
            <p>Compare: <a href="/compare/adobe-acrobat-alternative">Adobe alternative</a></p>
            """

W18_REGIONAL_CLUSTER = """
            <h2>Regional compress cluster</h2>
            <ul>
            <li><a href="/guides/compress-pdf-ucas">UCAS</a></li>
            <li><a href="/guides/compress-pdf-uidai">UIDAI</a></li>
            <li><a href="/guides/compress-pdf-ukvi">UKVI</a></li>
            <li><a href="/guides/compress-pdf-usajobs">USAJOBS</a></li>
            <li><a href="/guides/compress-pdf-for-passport-application">Passport applications</a></li>
            </ul>
            <p>Hub: <a href="/guides/pdf-regional-workflows-hub">regional PDF workflows</a></p>
            """

W18_DEEP = {**W18_CONVERT_DEEP, **W18_COMPRESS_DEEP}

CONVERT_SLUGS = {
    "ocr-pdf-to-text", "pdf-to-text-online", "how-to-convert-pdf-to-word", "pdf-to-word-converter",
    "how-to-convert-pdf-to-text", "scanned-pdf-to-text", "pdf-to-text-on-android", "pdf-to-text-on-iphone",
    "pdf-to-text-accessibility", "pdf-to-text-python-workflow", "pdf-to-text-multilingual",
}

WORD_SLUGS = {"how-to-convert-pdf-to-word", "pdf-to-word-converter"}
