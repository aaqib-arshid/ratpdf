#!/usr/bin/env python3
"""Wave 4 — PDF to Word workflow + comparison cluster expansions."""

PDF_WORD_CLUSTER_LINKS = """
            <h2>Related PDF to Word guides</h2>
            <ul>
            <li><a href="/guides/pdf-to-word">PDF to Word guide</a></li>
            <li><a href="/guides/pdf-to-word-keep-formatting">Keep formatting</a></li>
            <li><a href="/guides/scanned-pdf-to-word">Scanned PDF to Word</a></li>
            <li><a href="/guides/pdf-to-word-mac">PDF to Word on Mac</a></li>
            </ul>
            <p>Research: <a href="/research/pdf-compression-benchmark">PDF compression benchmark</a> · Compare: <a href="/compare/smallpdf-alternative">Smallpdf alternative</a></p>
            """

PDF_WORD_LONG_TAIL = """
            <h2>Digital vs scanned — 10-second test</h2>
            <p>Try selecting text in your PDF viewer. Highlight works → <a href="/pdf/pdftodoc">PDF to Word</a> directly. No selection → <a href="/pdf/ocrpdf">OCR PDF</a> first per <a href="/guides/scanned-pdf-to-word">scanned workflow</a>.</p>

            <h2>pdf2docx vs page-render fallback</h2>
            <p>RatPDF analyses structure on digital PDFs — tables and paragraphs become editable objects. When structure is missing, pages may embed as images inside DOCX — still better than retyping from scratch.</p>

            <h2>Re-export after edits</h2>
            <p>Deliverable still PDF? Use Word <em>Save as PDF</em> or <a href="/pdf/doctopdf">Word to PDF</a>. Email too large? <a href="/guides/compress-pdf-for-email">compress PDF</a>.</p>

            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Convert now</strong> <a href="/pdf/pdftodoc" class="alert-link fw-semibold">PDF to Word →</a></div>
            """

PDF_WORD_MEGA = """
            <h2>When NOT to convert PDF to Word</h2>
            <p>Signed executed contracts, filed tax acknowledgements, and official sealed transcripts — archive PDF as-is; convert only working drafts with authority to edit. Regenerate invoices from <a href="/invoice/create">Create Invoice</a> when you issued the PDF originally.</p>

            <h2>Track changes discipline</h2>
            <p>Legal and procurement reviews need Word track changes — convert digital PDF, edit in Word, return DOCX or export PDF after accept. Never edit PDF in Photoshop pretending it is redline.</p>

            <h2>ATS and recruiting</h2>
            <p>Recruiters parsing DOCX — <a href="/guides/pdf-to-word-resume">resume PDF to Word</a> keeps headings if digital; scanned CV needs OCR. Avoid text boxes that break ATS parsers.</p>

            <h2>Finance document chain</h2>
            <p>PO → receipt → invoice three-way match — editing PO PDF in Word without ERP audit trail risks payment errors. Prefer system reissue when buyer has ERP access; Word path for one-off SMB paper workflows.</p>

            <h2>Education and credentials</h2>
            <p>Transcript and diploma PDFs — add cover pages only; never alter grades. University employers may require registrar verification regardless of Word wrapper.</p>

            <h2>Compare vendors</h2>
            <p><a href="/compare/adobe-alternative">Adobe</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/smallpdf-alternative">Smallpdf</a> — evaluate table fidelity on a sample page before batch migration.</p>
            """

WORKFLOW_DATA = {
    "pdf-to-word-invoice": {
        "title": "PDF to Word for invoice — edit GST &amp; tax invoices online",
        "doc": "tax invoice",
        "example": "Client PDF invoice has wrong GSTIN — fix line description and re-send",
        "tips": "Prefer regenerating from Create Invoice if you are the issuer; convert third-party vendor PDFs only for AP notes.",
        "alt": "PDF to Excel for line extraction on digital statements",
    },
    "pdf-to-word-resume": {
        "title": "PDF to Word for resume — edit job application CV online",
        "doc": "resume/CV",
        "example": "Tailor skills section for ATS keywords before applying on Indeed",
        "tips": "Use single-column layout after convert; remove floating text boxes. Scanned CV: OCR first.",
        "alt": "Recreate from LinkedIn export if PDF is Canva image-only",
    },
    "convert-bank-statement-pdf-to-word": {
        "title": "Convert bank statement PDF to Word — mortgage &amp; broker packs",
        "doc": "bank statement",
        "example": "Broker needs cover letter wrapping 6 months statements for pre-approval",
        "tips": "Digital bank PDFs: try PDF to Excel for transactions; Word for narrative cover only.",
        "alt": "PDF to Text for grep-style search across deposits",
    },
    "convert-contract-pdf-to-word": {
        "title": "Convert contract PDF to Word — redline &amp; edit clauses",
        "doc": "contract/MSA",
        "example": "Vendor sends MSA PDF — legal marks clause 8 liability cap in track changes",
        "tips": "Digital contracts convert best; scanned signed copies need OCR before redline.",
        "alt": "Request native DOCX from counterparty when possible",
    },
    "convert-receipt-pdf-to-word": {
        "title": "Convert receipt PDF to Word — expense reports &amp; payment records",
        "doc": "receipt",
        "example": "Combine receipt image PDF with expense justification paragraph in one DOCX",
        "tips": "Thermal receipts: OCR at 300 DPI; verify amounts character by character.",
        "alt": "Photo receipts in expensify — attach PDF export only",
    },
    "convert-tax-return-pdf-to-word": {
        "title": "Convert tax return PDF to Word — draft review &amp; cover letters",
        "doc": "tax return draft",
        "example": "CA sends draft ITR PDF — client adds cover letter in Word before sign-off",
        "tips": "Never edit filed acknowledgement PDFs — only drafts pre-filing.",
        "alt": "Request editable schedule from CA software export",
    },
    "convert-proforma-invoice-pdf-to-word": {
        "title": "Convert proforma invoice PDF to Word — customs &amp; pre-payment edits",
        "doc": "proforma invoice",
        "example": "Update HS code and incoterm on proforma before bank wire",
        "tips": "Table line items usually survive on ERP-export PDFs; verify totals after edit.",
        "alt": "Regenerate from ERP proforma module if available",
    },
    "convert-credit-note-pdf-to-word": {
        "title": "Convert credit note PDF to Word — returns &amp; billing adjustments",
        "doc": "credit note",
        "example": "Fix reference invoice number on credit note before sending to AP",
        "tips": "GST credit notes need correct original invoice link — accountant should approve.",
        "alt": "Issue new credit note from billing system instead of editing PDF",
    },
    "convert-nda-pdf-to-word": {
        "title": "Convert NDA PDF to Word — edit mutual &amp; one-way agreements",
        "doc": "NDA",
        "example": "Adjust governing law and term from 2 years to 3 years before sign",
        "tips": "Carve-outs list must stay readable — avoid breaking numbered lists on convert.",
        "alt": "Use firm template DOCX for repeat NDAs",
    },
    "convert-quotation-pdf-to-word": {
        "title": "Convert quotation PDF to Word — edit pricing before send",
        "doc": "sales quotation",
        "example": "Sales adjusts 10% discount line and validity date on Friday quote",
        "tips": "Logo and pricing table on digital CRM PDF usually convert cleanly.",
        "alt": "Regenerate quote from CRM if integration exists",
    },
    "convert-purchase-order-pdf-to-word": {
        "title": "Convert purchase order PDF to Word — edit line items &amp; terms",
        "doc": "purchase order",
        "example": "Buyer changes ship-to address and qty on PO before vendor ack",
        "tips": "PO numbers must stay unchanged — edit lines only with procurement approval.",
        "alt": "Reissue PO from ERP when buyer has access",
    },
    "convert-transcript-pdf-to-word": {
        "title": "Convert transcript PDF to Word — unofficial copies &amp; cover pages",
        "doc": "academic transcript",
        "example": "Student adds cover page explaining unofficial copy for employer background check",
        "tips": "Never alter grades on official PDF — add cover only; sealed transcripts stay PDF.",
        "alt": "Order official transcript from registrar",
    },
}

COMPARE_UNIQUE = {
    "pdf-to-word-without-word": """
            <h2>Edit DOCX without Microsoft Word</h2>
            <p>RatPDF outputs standard DOCX — open in <strong>Google Docs</strong> (upload), <strong>LibreOffice Writer</strong> (free desktop), or <strong>Word Online</strong> with a Microsoft account (no subscription required for basic edit).</p>
            <h2>Real example: Chromebook student</h2>
            <ol>
            <li>Professor posts syllabus PDF — need editable notes column.</li>
            <li>Convert via <a href="/pdf/pdftodoc">PDF to Word</a> on Chromebook browser.</li>
            <li>Upload DOCX to Google Drive → Open with Google Docs.</li>
            <li>Comment and suggest edits — export PDF if submitting assignment.</li>
            </ol>
            """,
    "pdf-to-word-vs-google-docs": """
            <h2>Google Docs "Open PDF" vs convert first</h2>
            <p>Docs can import PDF but often flattens complex tables. RatPDF PDF to Word → upload DOCX to Docs preserves more table structure for procurement quotes.</p>
            <h2>Collaboration trade-off</h2>
            <p>Docs wins real-time co-editing; convert-first wins clause numbering on contracts. Hybrid: convert, upload DOCX to shared Drive folder.</p>
            """,
    "pdf-to-word-vs-pdf-to-text": """
            <h2>Layout vs plain characters</h2>
            <p><strong>PDF to Word:</strong> tables, headings, images in DOCX. <strong>PDF to Text:</strong> strips to .txt for scripts, grep, LLM ingest — no columns.</p>
            <h2>Decision tree</h2>
            <p>Need to edit formatting → Word. Need corpus search only → <a href="/pdf/pdftotext">PDF to Text</a>. Scan without OCR → neither works until <a href="/pdf/ocrpdf">OCR PDF</a>.</p>
            """,
    "pdf-to-word-garbled-text": """
            <h2>Why DOCX shows boxes or symbols</h2>
            <p>Custom font encoding, missing ToUnicode map, or wrong OCR language. Fixes: request source DOCX, embed fonts on re-export, OCR with correct language, or try different PDF generator from sender.</p>
            <h2>Real example: European invoice with CE glyphs</h2>
            <p>UTF-8 issue in subset font — OCR PDF with French language then PDF to Word often recovers readable text.</p>
            """,
    "ocr-vs-pdf-to-text": """
            <h2>OCR vs PDF to Text — different jobs</h2>
            <p><strong>OCR PDF</strong> adds searchable text layer inside PDF — still looks like scan, Ctrl+F works. <strong>PDF to Text</strong> exports .txt file — no layout, no images.</p>
            <h2>Combined workflow</h2>
            <p>Scan → OCR PDF (searchable archive) → PDF to Text (analytics) OR PDF to Word (human edit). See <a href="/guides/ocr-pdf">OCR PDF guide</a>.</p>
            """,
}

# Deep blocks per workflow slug (~350 words each) — abbreviated keys match WORKFLOW_DATA
WORKFLOW_SLUG_DEEP = {
    "pdf-to-word-invoice": """
            <h2>Issuer vs receiver workflow</h2>
            <p><strong>You issued invoice:</strong> open <a href="/invoice/create">Create Invoice</a>, fix fields, new PDF — cleaner than Word hack on old PDF. <strong>Vendor sent PDF:</strong> AP converts to Word for internal coding notes only — do not alter tax fields without vendor credit note.</p>
            <h2>GST field integrity</h2>
            <p>GSTIN, HSN, tax split must match GSTR-2B — Word edits risk typo on 15-char GSTIN. Double-check every digit after convert.</p>
            <h2>Second example: proforma vs tax invoice</h2>
            <p>Client approved proforma — regenerate as tax invoice in billing tool; converting proforma PDF in Word for tax fields is error-prone.</p>
            <h2>Table QA</h2>
            <ol><li>Line totals sum to taxable value</li><li>Tax lines match rate</li><li>Currency symbol consistent</li><li>Bank details unchanged if only description edited</li></ol>
            """,
    "pdf-to-word-resume": """
            <h2>ATS-friendly structure after convert</h2>
            <p>Use Word Heading styles for sections (Experience, Education). Remove columns if ATS parser garbles. Save as DOCX not PDF until final — some portals want DOCX upload.</p>
            <h2>Keyword tailoring</h2>
            <p>Copy job description verbs into skills section — edit in Word after convert from LinkedIn-export PDF.</p>
            <h2>Scanned CV path</h2>
            <p>OCR → PDF to Word → expect imperfect layout — consider rebuilding template in Word using OCR text as reference only.</p>
            <h2>Quality check</h2>
            <p>No text boxes overlapping; phone/email selectable; one page unless senior role warrants two.</p>

            <h2>Second example: career changer</h2>
            <p>Convert skills-based CV PDF — rewrite summary in Word — export PDF for job portal — keep master DOCX for next tailoring.</p>
            <p>Compress if portal caps upload: <a href="/guides/compress-pdf-for-job-application">compress for job application</a>.</p>
            """,
    "convert-bank-statement-pdf-to-word": """
            <h2>Mortgage broker pack</h2>
            <p>Cover letter in Word + statement PDFs as attachments often beats one merged Word doc — ask broker preference. Some lenders want original bank PDF authenticity.</p>
            <h2>Transaction tables</h2>
            <p>Word is poor for 200-row transaction grids — <a href="/guides/pdf-to-excel">PDF to Excel</a> on digital download from netbanking. Word for narrative explanation of large deposits only.</p>
            <h2>Redaction</h2>
            <p>Mask account numbers in cover letter; keep full numbers only in official bank PDF if lender requires.</p>
            """,
    "convert-contract-pdf-to-word": """
            <h2>Track changes etiquette</h2>
            <p>Send DOCX with track changes on to counterparty counsel — not silent edit on their PDF. Version filename <code>MSA-v2-redline-2026-04-01.docx</code>.</p>
            <h2>Defined terms and cross-references</h2>
            <p>After convert, verify internal references ("Section 4.2") still point correctly — Word cross-ref rebuild may be needed.</p>
            <h2>Executed copy separation</h2>
            <p>Signed PDF stays vault copy — working DOCX is negotiation only.</p>
            """,
    "convert-receipt-pdf-to-word": """
            <h2>Expense portal uploads</h2>
            <p>Some portals want PDF receipt + Word justification — convert receipt only if portal demands single DOCX bundle.</p>
            <h2>Thermal fade</h2>
            <p>Old receipt photos need high contrast scan before OCR — faded totals cause expense audit failure.</p>
            <h2>Project coding</h2>
            <p>Add project code and approver name in Word header — finance audit trail.</p>
            """,
    "convert-tax-return-pdf-to-word": """
            <h2>Draft vs filed</h2>
            <p>ITR-V acknowledgement after filing is immutable record — convert only CA draft PDFs for client review memos.</p>
            <h2>Cover letter to tax authority</h2>
            <p>Rare — most filing is portal JSON — Word cover for physical correspondence only where jurisdiction allows.</p>
            <h2>PII hygiene</h2>
            <p>PAN/Aadhaar in draft — delete local DOCX after review; encrypt email attachments.</p>
            """,
    "convert-proforma-invoice-pdf-to-word": """
            <h2>Customs and bank submission</h2>
            <p>HS codes and incoterms must match shipment — Word edit then export PDF for bank LC docs.</p>
            <h2>Proforma ≠ tax invoice</h2>
            <p>Label clearly "Proforma" — do not use for GST ITC claim until formal tax invoice issued.</p>
            """,
    "convert-credit-note-pdf-to-word": """
            <h2>Reference invoice linkage</h2>
            <p>Credit note must cite original invoice number/date — verify after Word edit; GST rules require linkage.</p>
            <h2>Partial credit</h2>
            <p>Line-level credit vs full cancel — ERP regeneration safer than manual Word math.</p>
            """,
    "convert-nda-pdf-to-word": """
            <h2>Jurisdiction and term edits</h2>
            <p>Mutual vs one-way — do not swap party obligations in Word without counsel. Governing law clause sensitive.</p>
            <h2>Carve-out lists</h2>
            <p>Numbered carve-outs break if Word reflows — use multilevel list styles.</p>
            """,
    "convert-quotation-pdf-to-word": """
            <h2>Validity date and pricing</h2>
            <p>Friday 5pm price change — convert CRM PDF, edit total line, re-export PDF before email — faster than reprint from CRM if offline.</p>
            <h2>Scope creep documentation</h2>
            <p>Add "Excludes integration testing" line in Word before client sign-off on quote.</p>
            """,
    "convert-purchase-order-pdf-to-word": """
            <h2>Ship-to and Incoterms</h2>
            <p>Buyer edits delivery address on PO PDF via Word — vendor must re-acknowledge changed PO number version.</p>
            <h2>Three-way match</h2>
            <p>PO, receipt, invoice — PO edits affect AP match — notify finance when PO version changes.</p>
            """,
    "convert-transcript-pdf-to-word": """
            <h2>Unofficial vs official</h2>
            <p>Cover page states "Unofficial copy for employer review" — registrar sealed PDF untouched.</p>
            <h2>Background check vendors</h2>
            <p>Some want direct registrar verify — Word wrapper not substitute for verification service.</p>
            <h2>International employers</h2>
            <p>GPA scale explanation paragraph in Word cover — helps US HR interpret marks.</p>
            """,
}

COMPARE_SLUG_DEEP = {
    "pdf-to-word-without-word": """
            <h2>LibreOffice on Windows/Linux</h2>
            <p>Free desktop install — opens RatPDF DOCX with fewer font substitution issues than web editors for long contracts.</p>
            <h2>Word Online free tier</h2>
            <p>Microsoft account uploads DOCX to OneDrive — basic editing without M365 subscription — sufficient for syllabus annotations.</p>
            <h2>Export back to PDF</h2>
            <p>Google Docs File → Download PDF — or RatPDF <a href="/pdf/doctopdf">Word to PDF</a> for consistent corporate fonts.</p>
            <h2>Chromebook workflow</h2>
            <p>Entire pipeline browser-only: RatPDF convert → Drive → Docs — no local install.</p>
            """,
    "pdf-to-word-vs-google-docs": """
            <h2>Table stress test</h2>
            <p>Upload same quote PDF both ways — compare cell borders in Docs. If Docs import fails, convert-first wins.</p>
            <h2>Commenting</h2>
            <p>Docs @mention colleagues on converted DOCX — faster than emailing PDF screenshots.</p>
            <h2>Offline editing</h2>
            <p>LibreOffice or desktop Word when flight has no Docs access — see <a href="/guides/pdf-to-word-without-word">without Word guide</a>.</p>
            """,
    "pdf-to-word-vs-pdf-to-text": """
            <h2>Developer pipeline</h2>
            <p>ETL jobs ingest <a href="/pdf/pdftotext">PDF to Text</a> — lawyers redline in Word — same source PDF, different tools.</p>
            <h2>Searchable PDF middle ground</h2>
            <p>OCR PDF keeps visual layout with search — neither Word nor txt — see <a href="/guides/ocr-vs-pdf-to-text">OCR vs PDF to Text</a>.</p>
            <h2>Invoice exception</h2>
            <p>AP needs table structure — Word not txt — <a href="/guides/pdf-to-word-invoice">invoice to Word</a>.</p>
            """,
    "pdf-to-word-garbled-text": """
            <h2>Font installation fix</h2>
            <p>Install missing font on PC before opening DOCX — symbols may resolve without re-convert.</p>
            <h2>Re-OCR with language pack</h2>
            <p>Arabic/Hindi scans — set Tesseract language on <a href="/pdf/ocrpdf">OCR PDF</a> before Word step.</p>
            <h2>Prevention</h2>
            <p>Ask senders for PDF/A or embedded-font exports from Word — prevents downstream garbling.</p>
            """,
    "ocr-vs-pdf-to-text": """
            <h2>Litigation discovery</h2>
            <p>Counsel wants searchable PDF for review platform — OCR. Data science wants corpus — PDF to Text export.</p>
            <h2>Archive policy</h2>
            <p>Store OCR PDF as official scan record; txt derivative for analytics — document in records schedule.</p>
            <h2>Related OCR guides</h2>
            <p>Language-specific scans: <a href="/guides/ocr-pdf-hindi">Hindi OCR</a> · <a href="/guides/ocr-pdf-arabic">Arabic OCR</a> before text export.</p>
            """,
}

PDF_WORD_1500_TOPUP = """
            <h2>Batch conversion hygiene</h2>
            <p>Folder of 30 vendor PDFs — convert one representative table-heavy file first; if quality passes, batch remainder. Log failures for OCR retry.</p>

            <h2>Version naming</h2>
            <p><code>Contract-Acme-v1-source.pdf</code> → <code>Contract-Acme-v2-redline.docx</code> → <code>Contract-Acme-v3-executed.pdf</code> — never overwrite source.</p>

            <h2>Mobile editing reality</h2>
            <p>Phone Word app edits simple typo; complex tables need desktop — convert on mobile browser OK, edit on laptop.</p>

            <h2>Integration with merge/split</h2>
            <p>200-page manual — <a href="/guides/split-pdf">split PDF</a> by chapter, convert section, recombine in Word master doc.</p>

            <h2>Password-protected PDFs</h2>
            <p>Unlock with <a href="/guides/unlock-pdf">Unlock PDF</a> before convert — encrypted files fail or produce empty DOCX.</p>

            <h2>Language and encoding</h2>
            <p>Multi-language contracts — verify each script paragraph after convert; garbled section → <a href="/guides/pdf-to-word-garbled-text">garbled text guide</a>.</p>

            <h2>Client communication</h2>
            <p>When returning redlined DOCX, email explains "converted from your PDF for track changes — not a new agreement until countersigned PDF exchanged."</p>
            """

PDF_WORD_FINAL_BOOST = """
            <h2>Stakeholder matrix</h2>
            <p>Legal owns contracts, finance owns invoices, HR owns offer letters, students own transcript covers — route DOCX to role owner before external send.</p>

            <h2>Upgrade for volume</h2>
            <p>Migration project converting legacy PDF library — <a href="/Subscription/Plans">subscription plans</a> raise daily caps.</p>

            <h2>More guides</h2>
            <p>Workflow guides (bank statements, NDAs, purchase orders) link to <a href="/guides/pdf-to-word">PDF to Word</a>. Comparison guides help you choose between Google Docs, plain text export, and OCR.</p>
            """

WAVE4_CLOSING = """
            <h2>Closing checklist</h2>
            <ol>
            <li>Source PDF archived read-only</li>
            <li>DOCX reviewed by subject owner</li>
            <li>Track changes resolved or accepted</li>
            <li>Final deliverable format confirmed (DOCX vs PDF)</li>
            <li>Local copies cleared on shared machines</li>
            </ol>
            <p>Bookmark <a href="/guides/pdf-to-word">PDF to Word hub</a> and this workflow page for your team wiki — consistent steps reduce onboarding time each quarter.</p>
            """
