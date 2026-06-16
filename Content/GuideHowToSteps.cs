namespace ratpdf.Content
{
    /// <summary>HowTo schema steps for guide articles (slug → steps).</summary>
    public static class GuideHowToSteps
    {
        private static readonly Dictionary<string, string[]> BySlug = new(StringComparer.OrdinalIgnoreCase)
        {
            ["compress-pdf-guide"] =
            [
                "Open the Compress PDF tool and upload your document.",
                "Choose Low, Medium, or High compression based on your quality needs.",
                "Start processing and wait for the optimized file.",
                "Download the result and verify file size before emailing or uploading.",
            ],
            ["merge-pdf"] =
            [
                "Open Merge PDF and upload two or more PDF files.",
                "Drag files to reorder the final document sequence.",
                "Click Merge and wait for processing to finish.",
                "Download the combined PDF and spot-check page order.",
            ],
            ["split-pdf"] =
            [
                "Upload the PDF you want to split.",
                "Enter page ranges or choose split options for each section.",
                "Run the split job and wait for output files.",
                "Download individual PDFs or a ZIP archive.",
            ],
            ["pdf-to-word"] =
            [
                "Upload a digital PDF (scanned files may need OCR first).",
                "Choose conversion mode if prompted for complex layouts.",
                "Wait for pdf2docx processing to complete.",
                "Download DOCX and review tables and headings in Word.",
            ],
            ["word-to-pdf"] =
            [
                "Upload a DOCX file from your device.",
                "Wait for LibreOffice export to finish.",
                "Download the print-ready PDF.",
                "Open once to confirm fonts, margins, and page breaks.",
            ],
            ["watermark-pdf"] =
            [
                "Upload the PDF that needs a draft or confidential mark.",
                "Enter watermark text (e.g. DRAFT or CONFIDENTIAL).",
                "Apply the watermark and download the marked PDF.",
                "Share the watermarked copy for review cycles.",
            ],
            ["password-protect-pdf"] =
            [
                "Upload the PDF you want to encrypt.",
                "Enter a strong password (share it on a separate channel).",
                "Apply encryption and download the protected file.",
                "Test opening the PDF with the password before sending externally.",
            ],
            ["sign-pdf"] =
            [
                "Upload the PDF requiring approval.",
                "Place a typed signature block on the signature line.",
                "Download the signed PDF for your records.",
                "Email the signed copy or archive it in your document system.",
            ],
            ["pdf-to-images"] =
            [
                "Upload the PDF you want to export as images.",
                "Select DPI if the tool offers quality options.",
                "Run export and wait for page rendering.",
                "Download the ZIP of JPG/PNG page images.",
            ],
            ["ocr-pdf"] =
            [
                "Upload a scanned image PDF.",
                "Run OCR to add a searchable text layer.",
                "Download the searchable PDF.",
                "Test search (Ctrl+F) to confirm text is findable.",
            ],
            ["invoice-generator-guide"] =
            [
                "Open the invoice generator and enter your business details.",
                "Add line items, tax rates, and payment terms.",
                "Preview the invoice layout on screen.",
                "Download the PDF invoice and send it to your client.",
            ],
            ["pdf-to-powerpoint"] =
            [
                "Upload the PDF presentation or report.",
                "Wait for slide conversion (one slide per page).",
                "Download the PPTX file.",
                "Open in PowerPoint and adjust speaker notes or order.",
            ],
            ["powerpoint-to-pdf"] =
            [
                "Upload your PPTX or PPT file.",
                "Wait for LibreOffice Impress export.",
                "Download the print-ready PDF.",
                "Verify slide layout and compress if emailing.",
            ],
            ["html-to-pdf"] =
            [
                "Paste HTML or upload an .html file.",
                "Review markup in the editor if needed.",
                "Click Convert HTML to PDF.",
                "Download and spot-check fonts and page breaks.",
            ],
            ["pdf-to-markdown"] =
            [
                "Upload a digital or OCR-processed PDF.",
                "Run text extraction per page.",
                "Download the .md file.",
                "Edit headings and links in your Markdown editor.",
            ],
            ["pdf-redaction"] =
            [
                "Upload the PDF containing sensitive content.",
                "Mark regions for permanent removal.",
                "Apply redaction and download the file.",
                "Search the PDF to confirm hidden text is gone.",
            ],
            ["compress-pdf-email-limits"] =
            [
                "Check your PDF size against the destination limit.",
                "Run medium compression on the Compress PDF tool.",
                "Re-check size with the PDF size checker if needed.",
                "Split into parts only if compression is insufficient.",
            ],
            ["compress-pdf-for-gmail"] =
            [
                "Check PDF size — aim under 20 MB for Gmail's 25 MB cap.",
                "Open Compress PDF and upload your file.",
                "Use Recommended compression; retry with Extreme if still too large.",
                "Verify with the PDF size checker (Gmail preset), then attach in Gmail.",
            ],
            ["compress-pdf-for-outlook"] =
            [
                "Confirm your org attachment limit (often 10–20 MB on Exchange).",
                "Compress the PDF with Recommended or target 10 MB.",
                "Verify size with the PDF size checker.",
                "Attach in Outlook desktop or web — avoid raw OneDrive auto-link if attachment required.",
            ],
            ["ocr-scanned-pdf-workflow"] =
            [
                "Confirm the PDF has no selectable text (scanned/image PDF).",
                "Improve scan quality: 300 DPI, straight pages, high contrast.",
                "Run OCR PDF and download the searchable PDF.",
                "Verify with search, then extract text or convert to Word as needed.",
            ],
            ["pdf-to-text-research"] =
            [
                "Identify whether the paper is digital or scanned.",
                "For scans, OCR the PDF first.",
                "Extract text with PDF to Text and save as .txt.",
                "Quote with proper citation to the original publication.",
            ],
            ["gst-invoice-format-india"] =
            [
                "Confirm mandatory GST fields for your B2B or B2C sale.",
                "Choose web form or bulk CSV depending on GSTIN/HSN needs.",
                "Enter line items, tax split (CGST/SGST or IGST), and totals.",
                "Export PDF and validate with the GST invoice checker before sending.",
            ],
            ["vat-invoice-eu-requirements"] =
            [
                "Open Create Invoice and set the currency to EUR or local.",
                "Enter supplier and customer details with both VAT numbers for B2B.",
                "Add line items with net price and the correct VAT rate (or 0% reverse charge).",
                "Add reverse charge wording in Notes if applicable, then download the PDF.",
            ],
            ["hmrc-invoice-requirements"] =
            [
                "Open Create Invoice and set the currency to GBP.",
                "Add your business name, address, and VAT registration number in From.",
                "Enter line items with net prices and the correct VAT rate.",
                "Check the VAT and gross totals, then download the PDF.",
            ],
            ["ato-invoice-requirements"] =
            [
                "Open Create Invoice and set the currency to AUD.",
                "Add your business name and ABN; title the document a Tax invoice.",
                "Enter line items and set GST at 10% when registered.",
                "Add buyer details for sales of A$1,000+, then download the PDF.",
            ],
            ["cra-invoice-requirements"] =
            [
                "Open Create Invoice and set the currency to CAD.",
                "Add your business name and GST/HST Business Number in From.",
                "Enter line items and set the GST/HST rate for the province.",
                "Add buyer details for sales of $150+, then download the PDF.",
            ],
            ["irs-tax-pdf-format"] =
            [
                "Generate or scan each invoice and receipt as a PDF.",
                "Name files consistently and store them by tax year.",
                "Compress large scans so archives stay manageable.",
                "Back up to a second location and password-protect sensitive files.",
            ],
            ["e-invoicing-india-pdf"] =
            [
                "Confirm whether your turnover requires e-invoice under current GST notifications.",
                "Generate IRN via NIC-registered billing software or ERP.",
                "Export PDF with IRN and QR for the buyer.",
                "Use RatPDF bulk CSV for PDF batches or compress for email delivery.",
            ],
            ["gdpr-pdf-redaction"] =
            [
                "Identify personal data to remove before disclosure.",
                "Use permanent PDF redaction — not visual black boxes alone.",
                "Export and verify text cannot be copied from redacted areas.",
                "Log approver and retain redacted copy for audit trail.",
            ],
            ["hipaa-pdf-handling"] =
            [
                "Confirm org policy and BAA before using online tools on PHI.",
                "Strip minimum necessary identifiers when possible.",
                "Compress or convert only when policy allows browser processing.",
                "Download promptly and store in access-controlled archive.",
            ],
            ["section-508-pdf"] =
            [
                "OCR scanned PDFs to add searchable text layer.",
                "Add tags, headings, and alt text in a remediation editor.",
                "Run PAC or Adobe Accessibility Checker.",
                "Fix failures and re-test before publishing.",
            ],
            ["sox-pdf-retention"] =
            [
                "Store financial PDFs in immutable or versioned archive.",
                "Name files by fiscal period and document type.",
                "Compress cold-year copies only; keep signed originals uncompressed.",
                "Maintain access logs for audit retrieval.",
            ],
            ["wcag-22-pdf"] =
            [
                "OCR scan-only PDFs first.",
                "Tag headings, lists, and tables in logical reading order.",
                "Add alt text to meaningful images.",
                "Test with accessibility checker for AA conformance gaps.",
            ],
            ["compress-bank-statement-pdf"] =
            [
                "Download bank PDF or scan at 200–300 DPI grayscale.",
                "Upload to Compress PDF and choose Recommended.",
                "Verify account numbers and balances at 100% zoom.",
                "Check file size on PDF size checker before portal upload.",
            ],
            ["compress-gst-invoice-pdf"] =
            [
                "Export GST invoice PDF from generator or ERP.",
                "Compress with Recommended setting.",
                "Verify GSTIN, totals, and QR code after compression.",
                "Email delivery copy; archive uncompressed original.",
            ],
            ["compress-pan-card-pdf"] =
            [
                "Scan PAN card cropped to card edges at 200 DPI.",
                "Upload to Compress PDF — Recommended level.",
                "Verify 10-digit PAN readable at full zoom.",
                "Upload to KYC portal if under size cap.",
            ],
            ["compress-scanned-vs-digital-pdf"] =
            [
                "Identify whether PDF is scan (photo pages) or digital (selectable text).",
                "Expect large savings on scans; digital may not shrink much.",
                "Compress scans with Recommended; skip if already under limit.",
                "Re-scan at lower DPI if compression is insufficient.",
            ],
            ["ghostscript-pdf-compression"] =
            [
                "Upload PDF to RatPDF Compress tool (Ghostscript engine).",
                "Choose Low for legal, Recommended for email, High for strict caps.",
                "Download and compare file size to original.",
                "Keep uncompressed master before aggressive compression.",
            ],
            ["why-is-pdf-file-so-large"] =
            [
                "Check size per page — over 500 KB/page suggests scans.",
                "Re-export from Word/Excel if source is available.",
                "Re-scan at lower DPI or compress once from best master.",
                "Split PDF if still over email or portal limit.",
            ],
            ["compress-pdf-accountants"] =
            [
                "Keep uncompressed master in DMS.",
                "Compress bank and GST delivery copies with Recommended.",
                "Use Low compression on signed engagement letters.",
                "Merge year-end packs then compress once.",
            ],
            ["compress-pdf-lawyers"] =
            [
                "Redact privileged and PII permanently before production.",
                "Bates-number if required by court rules.",
                "Compress with Low on text exhibits; Recommended on scans.",
                "Verify stamps and signatures before e-filing upload.",
            ],
            ["excel-to-pdf-without-adobe"] = ["Upload XLSX to Excel to PDF.", "Wait for LibreOffice export.", "Download PDF and verify layout."],
            ["extract-images-from-pdf-without-adobe"] = ["Upload PDF to Extract Images.", "Run extraction job.", "Download ZIP of images."],
            ["html-to-pdf-without-adobe"] = ["Upload HTML file or snippet.", "Render to PDF in browser.", "Download and check CSS layout."],
            ["images-to-pdf-without-adobe"] = ["Upload JPG/PNG files in order.", "Reorder if needed.", "Download combined PDF."],
            ["pdf-to-excel-without-adobe"] = ["Upload digital PDF with tables.", "OCR first if scan-only.", "Download XLSX and verify columns."],
            ["pdf-to-jpg-without-adobe"] = ["Open PDF to Images.", "Choose JPG format.", "Download pages or ZIP."],
            ["pdf-to-markdown-without-adobe"] = ["Upload PDF.", "Convert to Markdown.", "Edit output in your editor."],
            ["pdf-to-png-without-adobe"] = ["Open PDF to Images.", "Choose PNG format.", "Download pages or ZIP."],
            ["pdf-to-powerpoint-without-adobe"] = ["Upload PDF slides.", "Convert to PPTX.", "Edit in PowerPoint."],
            ["powerpoint-to-pdf-without-adobe"] = ["Upload PPTX.", "Export to PDF.", "Share or compress if needed."],
            ["text-to-pdf-without-adobe"] = ["Upload or paste plain text.", "Generate PDF.", "Download result."],
            ["word-to-pdf-without-adobe"] = ["Upload DOCX.", "Convert to PDF.", "Download and compress for email if large."],
            ["merge-pdf-visa-application"] =
            [
                "Gather embassy checklist and scan each document to PDF.",
                "Merge files in checklist order with Merge PDF.",
                "Check total size against portal limit.",
                "Compress if needed, verify legibility, then upload.",
            ],
            ["pdf-redaction-permanent"] =
            [
                "Duplicate the source PDF — never redact your only original.",
                "Mark all sensitive regions in PDF Redaction.",
                "Export and search the file for redacted names and numbers.",
                "Password-protect the final disclosure pack if required.",
            ],
            ["best-free-pdf-tools-2026"] =
            [
                "List your tasks: merge, compress, convert, sign, invoice.",
                "Compare free daily limits and file size caps on /compare.",
                "Test one representative file on your shortlisted tool.",
                "Upgrade to Pro if you hit daily caps in production work.",
            ],
            ["compress-pdf-passport-india"] =
            [
                "Scan at 200–300 DPI grayscale or export existing PDF.",
                "Note the Passport Seva or portal size cap for that upload slot.",
                "Compress with Recommended; target 500 KB–1 MB if needed.",
                "Verify signatures at 100% zoom, then re-upload.",
            ],
            ["extract-text-scanned-pdf"] =
            [
                "Confirm text cannot be selected (image-only PDF).",
                "Run OCR PDF and verify search works on a known word.",
                "Extract plain text with PDF to Text.",
                "Proofread numbers and fix layout in Word if needed.",
            ],
            ["invoice-for-freelancers"] =
            [
                "Open the invoice generator and enter your business and client details.",
                "Add line items with clear deliverable descriptions.",
                "Set currency, tax, due date, and payment instructions.",
                "Download PDF and email to client with a clear subject line.",
            ],
            ["ocr-vs-pdf-to-text"] =
            [
                "Try to select text in the PDF — if nothing highlights, you need OCR.",
                "Run OCR PDF on scanned or image-only files.",
                "Run PDF to Text on digital PDFs or on the OCR'd searchable PDF.",
                "Proofread numbers; use PDF to Word if you need editable layout.",
            ],
            ["compress-pdf-efiling"] =
            [
                "Confirm your court or portal MB limit from local rules.",
                "Merge exhibits and OCR scans before compression if searchability is required.",
                "Compress with Recommended; target 10 MB or lower if needed.",
                "Verify stamps and footnotes at 100% zoom, then file.",
            ],
            ["pdf-to-word-vs-pdf-to-text"] =
            [
                "Decide if you need editable layout (Word) or plain text only.",
                "For scans, run OCR PDF before either converter.",
                "Upload to PDF to Word or PDF to Text accordingly.",
                "Proofread tables and numbers; archive the source PDF.",
            ],
            ["merge-pdf-court-filing"] =
            [
                "Confirm local rules for exhibit order and single vs multiple PDFs.",
                "Rotate, unlock, and redact exhibits before merging.",
                "Merge in index order; OCR scans if searchability is required.",
                "Compress if over portal limit, then file on the docket.",
            ],
            ["batch-compress-pdf"] =
            [
                "Sort PDFs by size; choose per-file vs merge-then-compress strategy.",
                "Compress each file with Recommended (or Less for legal docs).",
                "Spot-check quality; rename outputs with a clear suffix.",
                "Use size checker presets before email or portal upload.",
            ],
            ["merge-password-protected-pdf"] =
            [
                "Identify which PDFs in the bundle are password-protected.",
                "Unlock each file with Unlock PDF using the known password.",
                "Merge decrypted PDFs in order with Merge PDF.",
                "Optionally password-protect or compress the merged output.",
            ],
            ["compress-pdf-incometax"] =
            [
                "Export or scan the ITR annexure as PDF; note portal size error.",
                "Compress with Recommended; target 1 MB if still rejected.",
                "Verify PAN, account numbers, and stamps at 100% zoom.",
                "Re-upload on incometax.gov.in.",
            ],
            ["compress-pdf-digilocker"] =
            [
                "Scan document flat at 200–300 DPI or use issuer digital PDF.",
                "Compress with Recommended on Compress PDF.",
                "Target 1 MB or 500 KB if upload still fails.",
                "Verify ID numbers and seals, then upload to DigiLocker.",
            ],
            ["invoice-generator-india"] =
            [
                "Open Create Invoice or bulk CSV for full GST B2B fields.",
                "Enter line items, GST rate, and payment instructions.",
                "Validate with GST invoice checker for B2B compliance.",
                "Download PDF, email client, and archive for statutory retention.",
            ],
            ["invoice-generator-usa"] =
            [
                "Open Create Invoice and set currency to USD.",
                "Add line items and sales tax rate if applicable.",
                "Add payment instructions in Notes.",
                "Download PDF and archive for bookkeeping.",
            ],
            ["invoice-generator-uk"] =
            [
                "Set GBP and enter business details including VAT number.",
                "Add line items with VAT rate when registered.",
                "Add bank details and payment terms in Notes.",
                "Download PDF and send to client.",
            ],
            ["invoice-generator-australia"] =
            [
                "Set AUD and include ABN in From details.",
                "Add line items with GST 10% when registered.",
                "Add BSB/account or PayID in Notes.",
                "Download PDF and retain for BAS records.",
            ],
            ["invoice-generator-canada"] =
            [
                "Set CAD and enter GST/HST number in From.",
                "Add line items with province-appropriate tax rate.",
                "Add EFT payment details in Notes.",
                "Download PDF and archive for CRA retention.",
            ],
            ["invoice-generator-france"] =
            [
                "Set EUR and enter SIRET in From details.",
                "Add line items with TVA rate when registered.",
                "Add IBAN and payment terms in Notes.",
                "Download PDF and archive for comptabilité.",
            ],
            ["invoice-generator-germany"] =
            [
                "Set EUR and enter USt-IdNr. in From when applicable.",
                "Add line items with USt rate (commonly 19%).",
                "Add IBAN and payment terms in Notes.",
                "Download PDF and retain for GoBD records.",
            ],
            ["invoice-generator-singapore"] =
            [
                "Set SGD and include UEN plus GST reg in From.",
                "Add line items with GST 9% when registered.",
                "Add PayNow or bank details in Notes.",
                "Download PDF and retain for GST F5 records.",
            ],
            ["invoice-generator-uae"] =
            [
                "Set AED and enter TRN in From details.",
                "Add line items with 5% VAT when registered.",
                "Add bank IBAN and payment terms in Notes.",
                "Download PDF and retain for VAT return support.",
            ],
            ["invoice-generator-philippines"] =
            [
                "Set PHP and enter TIN in From details.",
                "Add line items with VAT 12% if registered.",
                "Add bank or GCash payment details in Notes.",
                "Download PDF and file for BIR records.",
            ],
            ["invoice-generator-new-zealand"] =
            [
                "Set NZD and enter GST number in From details.",
                "Add line items with GST 15% when registered.",
                "Add bank account and payment reference in Notes.",
                "Download PDF and retain for GST return records.",
            ],
            ["invoice-generator-south-africa"] =
            [
                "Set ZAR and enter VAT registration number in From.",
                "Add line items with VAT 15% when registered.",
                "Add EFT bank details and payment terms in Notes.",
                "Download PDF and retain for VAT201 support.",
            ],
            ["pdf-to-text-legal"] =
            [
                "Confirm whether the contract is digital or scanned.",
                "OCR scanned agreements before text extraction.",
                "Run PDF to Text and save UTF-8 output for search.",
                "Verify critical clauses against the signed PDF original.",
            ],
            ["compress-pdf-gst-portal"] =
            [
                "Use digital issuer PDF when available; note portal size cap.",
                "Compress with Recommended; target 1 MB if rejected.",
                "Verify GSTIN, PAN, and stamps at 100% zoom.",
                "Re-upload on gst.gov.in.",
            ],
            ["merge-scanned-digital-pdf"] =
            [
                "Rotate and unlock source PDFs; label files in merge order.",
                "Merge digital and scanned PDFs with Merge PDF.",
                "OCR merged file if searchability is required.",
                "Compress if over portal or email size limit.",
            ],
            ["pdf-to-text-bank-statements"] =
            [
                "Download digital statement PDF or OCR scanned passbook.",
                "Unlock password-protected bank PDF if needed.",
                "Run PDF to Text or PDF to Excel based on your goal.",
                "Reconcile extracted totals against the PDF balances.",
            ],
            ["pdf-to-word-resume"] =
            [
                "Confirm the resume PDF has selectable text (or OCR first).",
                "Convert with PDF to Word and download DOCX.",
                "Edit keywords and formatting in Word or Google Docs.",
                "Export a fresh PDF for job submission when required.",
            ],
            ["compress-pdf-for-lms"] =
            [
                "Check the assignment page for the LMS file size limit.",
                "Compress with Recommended; re-scan scans at lower DPI if needed.",
                "Verify figures and handwriting at 100% zoom.",
                "Upload to Canvas, Blackboard, or Moodle.",
            ],
            ["merge-pdf-custom-order"] =
            [
                "Rename files with numeric prefixes (01_, 02_) or upload in order.",
                "Unlock any password-protected PDFs before merge.",
                "Merge PDFs and verify first page is the cover or title.",
                "Compress if the combined file exceeds portal limits.",
            ],
            ["pdf-to-text-python-workflow"] =
            [
                "OCR scanned PDFs if text is not selectable.",
                "Export UTF-8 .txt via PDF to Text.",
                "Load in Python with encoding=utf-8 and parse lines.",
                "Validate entities and numbers against the source PDF.",
            ],
            ["pdf-to-word-keep-formatting"] =
            [
                "Use the original digital PDF (not a re-scan) and unlock if password-protected.",
                "Upload to PDF to Word and download the DOCX.",
                "Check page 1 logo, tables, and footers at 100% zoom.",
                "Fix column breaks in Word; export PDF when edits are complete.",
            ],
            ["pdf-to-word-invoice"] =
            [
                "Confirm invoice text is selectable in the PDF viewer.",
                "Convert with PDF to Word and open the DOCX.",
                "Edit line items, PO numbers, or dates as needed.",
                "Recalculate tax manually and export PDF for re-send or ERP upload.",
            ],
            ["compress-pdf-insurance-claims"] =
            [
                "Check the insurer portal max file size for claim uploads.",
                "Merge receipts and photos into one PDF if the portal allows.",
                "Compress with Recommended; target 5–10 MB via size checker.",
                "Verify claim numbers and dollar amounts at 100% zoom before submit.",
            ],
            ["merge-pdf-without-quality-loss"] =
            [
                "Upload digital PDFs in the desired order (unlock encrypted files first).",
                "Merge with RatPDF smart merge — avoid raster-only merge tools.",
                "Zoom logos to 200% and confirm text is still selectable.",
                "Compress only if email or portal size limits require it.",
            ],
            ["pdf-to-text-multilingual"] =
            [
                "Test whether text selects in your PDF viewer (digital vs scan).",
                "Run OCR first on scanned Hindi, Arabic, or CJK pages if needed.",
                "Export UTF-8 plain text via PDF to Text.",
                "Open in a UTF-8 editor and proofread diacritics and RTL order.",
            ],
            ["scanned-pdf-to-word"] =
            [
                "Confirm the PDF is image-only (text does not highlight).",
                "Run OCR PDF to add a searchable text layer.",
                "Convert the OCR'd PDF with PDF to Word.",
                "Proofread names, dates, and numbers in the DOCX before re-exporting PDF.",
            ],
            ["pdf-to-word-mac"] =
            [
                "Open RatPDF in Safari or Chrome on your Mac.",
                "Upload the PDF to PDF to Word (OCR scans first if needed).",
                "Download DOCX and open in Pages, Word for Mac, or Google Docs.",
                "Edit and export a fresh PDF when finished.",
            ],
            ["pdf-to-word-without-word"] =
            [
                "Convert the PDF to DOCX with RatPDF PDF to Word.",
                "Upload the DOCX to Google Drive or open in LibreOffice Writer.",
                "Edit content in the free editor.",
                "Download or export PDF for sharing.",
            ],
            ["pdf-to-text-accessibility"] =
            [
                "Test whether text selects in the PDF — if not, OCR is required.",
                "Run OCR PDF on scanned documents at 300 DPI where possible.",
                "Verify Ctrl+F finds body text in the OCR'd PDF.",
                "Optionally export plain UTF-8 text for accessible HTML or wiki paste.",
            ],
            ["ocr-pdf-ediscovery"] =
            [
                "Inventory production volumes and unlock password-protected PDFs.",
                "OCR each scanned volume and QA with Ctrl+F on sample Bates pages.",
                "Merge or load searchable PDFs into your review workflow.",
                "Redact and cite Bates-stamped PDFs — not text exports alone.",
            ],
            ["batch-pdf-to-word"] =
            [
                "Sort PDFs with numeric prefixes and separate Input/Output folders.",
                "OCR scanned files first, then convert one PDF per session.",
                "Download and rename each DOCX consistently before the next file.",
                "Spot-check tables and logos on a sample before archiving originals.",
            ],
            ["pdf-to-word-vs-google-docs"] =
            [
                "Convert PDF to DOCX with RatPDF PDF to Word.",
                "Upload the DOCX to Google Drive.",
                "Open with Google Docs for collaborative editing.",
                "Download or export PDF when edits are complete.",
            ],
            ["recurring-invoice-generator"] =
            [
                "Create a master invoice on Create Invoice with client and line items.",
                "Save client details and rates in your own spreadsheet or notes.",
                "Each billing period: update date and invoice number, regenerate PDF.",
                "Validate GST fields for India B2B before emailing the client.",
            ],
            ["compress-pdf-for-job-application"] =
            [
                "Check the employer portal max PDF file size.",
                "Merge resume and annexures only if one upload is required.",
                "Compress with Recommended; verify text still selects in the PDF.",
                "Confirm name and contact info readable at 100% zoom before submit.",
            ],
            ["merge-pdf-accountants"] =
            [
                "Export financial schedules from Excel with print areas set.",
                "Name files with numeric prefixes in board pack order.",
                "Merge PDFs and verify tables and logos at 100% zoom.",
                "Compress and password-protect before emailing the board pack.",
            ],
            ["compress-pdf-for-indeed"] =
            [
                "Export a digital PDF resume (not a photo scan) from Word or Docs.",
                "Check file size against Indeed or employer upload limits.",
                "Compress with Recommended and verify text still selects.",
                "Upload with a professional filename on Indeed.",
            ],
            ["compress-pdf-for-university-application"] =
            [
                "Check each portal upload field for its max PDF size.",
                "Scan documents at 200–300 DPI; one PDF per required slot.",
                "Compress with Recommended; target 2–5 MB if needed.",
                "Verify names, roll numbers, and stamps at 100% zoom before submit.",
            ],
            ["compress-pdf-common-app"] =
            [
                "Confirm max size on the Common App upload widget.",
                "Use digital school exports instead of phone photos when possible.",
                "Compress with Recommended; check size with the PDF size checker.",
                "Keep an uncompressed original for your records.",
            ],
            ["compress-before-merge-pdf"] =
            [
                "Decide if the destination needs separate files or one bundle.",
                "For one attachment: merge PDFs first without pre-compressing.",
                "Run a single Recommended compression pass on the merged file.",
                "QA logos and table text before sending or uploading.",
            ],
            ["combine-then-compress-pdf"] =
            [
                "Rename PDFs with numeric prefixes in final order.",
                "Merge PDFs and verify cover page and page count.",
                "Check merged size with the PDF size checker.",
                "Compress once with Recommended if over email or portal limit.",
            ],
            ["extract-single-page-pdf"] =
            [
                "Upload the multi-page PDF to Split PDF.",
                "Enter the single page number (e.g. 7).",
                "Download the one-page output file.",
                "Rename and share the extracted page.",
            ],
            ["organize-pdf-pages"] =
            [
                "Plan final page order (cover, body, appendix).",
                "Split misplaced sections from large PDFs if needed.",
                "Upload files in order with 01_, 02_ filename prefixes.",
                "Merge and compress if the organized pack exceeds limits.",
            ],
            ["split-pdf-page-range"] =
            [
                "Identify page ranges to extract (e.g. exhibit 1-5).",
                "Upload PDF to Split and enter the range.",
                "Download and verify page count in the output.",
                "Repeat for other sections or merge parts as needed.",
            ],
            ["split-pdf-for-email"] =
            [
                "Try Recommended compression first on the full PDF.",
                "If still over limit, split into logical parts by page range.",
                "Compress each part lightly if needed.",
                "Email as Part 1 of N in the same thread.",
            ],
            ["split-pdf-by-size"] =
            [
                "Note total pages and file size; set target MB per chunk.",
                "Estimate pages per chunk (divide total pages by number of parts).",
                "Split first chunk by page range (e.g. 1-50).",
                "Verify chunk size on PDF size checker; adjust and repeat.",
            ],
            ["extract-text-without-adobe"] =
            [
                "Try selecting text in the PDF — digital or scan?",
                "Digital PDF: open PDF to Text and download .txt.",
                "Scan: run OCR PDF first, then PDF to Text.",
                "Proofread numbers and names in financial or legal extracts.",
            ],
            ["tesseract-vs-online-ocr"] =
            [
                "Assess scan quality — 300 DPI straight pages OCR best.",
                "For privacy-sensitive docs, prefer Tesseract (RatPDF OCR PDF).",
                "Run OCR PDF and test Ctrl+F on a known word.",
                "Export text via PDF to Text or Word for editing.",
            ],
            ["edit-pdf-without-acrobat"] =
            [
                "Open Edit PDF in browser — no Acrobat install.",
                "Upload PDF; unlock if password-protected.",
                "Add text, image, or signature as needed.",
                "Download edited copy; archive original separately.",
            ],
            ["edit-scanned-pdf"] =
            [
                "Rotate skewed scan pages if needed.",
                "Run OCR PDF on the scanned file.",
                "Verify text search works in the viewer.",
                "Edit PDF for light changes or PDF to Word for heavy edits.",
            ],
            ["add-image-to-pdf"] =
            [
                "Prepare PNG/JPG logo at appropriate DPI.",
                "Upload PDF to Edit PDF.",
                "Insert and position image on target page.",
                "Download and verify sharpness at 100% zoom.",
            ],
            ["edit-pdf-forms"] =
            [
                "Download official blank form from agency site.",
                "OCR if the form is a flat scan.",
                "Fill fields in Edit PDF with consistent font size.",
                "Sign and compress if portal has size limits.",
            ],
            ["pdf-tool-security-comparison"] =
            [
                "List data sensitivity — PII, legal, medical?",
                "Check vendor HTTPS, retention, and privacy policy.",
                "Compare free tier limits and account requirements.",
                "Choose browser vs desktop based on compliance needs.",
            ],
            ["pdf-tools-small-business"] =
            [
                "Map workflows: invoice, merge, compress, edit, sign.",
                "Test RatPDF free tier on typical file sizes.",
                "Review security guide before uploading payroll PDFs.",
                "Upgrade Pro only if daily limits block operations.",
            ],
            ["browser-vs-desktop-pdf-tools"] =
            [
                "List data sensitivity — PII, legal, medical, export-control?",
                "Estimate daily PDF task volume and max file sizes.",
                "Compare browser retention policy vs desktop offline processing.",
                "Pick hybrid: browser for daily tasks, desktop for regulated batch work.",
            ],
            ["pdf-email-attachment-checklist"] =
            [
                "Check PDF size against recipient provider cap.",
                "Verify filename, page order, and 100% zoom readability.",
                "Compress or split if over limit; password in separate channel.",
                "Preview on mobile before Send.",
            ],
            ["merge-vs-compress"] =
            [
                "Decide: one attachment from many files, or shrink one file?",
                "If many files → merge in order, then compress once.",
                "If separate portal slots → compress each file individually.",
                "Use size checker; split if compress blurs scans.",
            ],
            ["compress-vs-split"] =
            [
                "Check file size and type — digital vs scanned.",
                "Try Recommended compress; inspect signatures at 100% zoom.",
                "If scans blur or still over cap → split by page range.",
                "Label parts clearly in email subject and body.",
            ],
            ["merge-pdf-students"] =
            [
                "Download readings and rename with week numbers (01_, 02_).",
                "OCR scanned chapters if you need unified search.",
                "Merge PDFs in syllabus-to-final-week order.",
                "Compress if the pack exceeds LMS or email limits.",
            ],
            ["compress-pdf-for-whatsapp"] =
            [
                "Check PDF size on your phone — large files send slowly on mobile data.",
                "Compress with Recommended in your mobile browser.",
                "Save the compressed PDF to Downloads.",
                "Attach via WhatsApp Document (not Gallery) to preserve PDF format.",
            ],
            ["compress-pdf-for-visa-application"] =
            [
                "Merge visa documents in embassy checklist order first.",
                "Check the portal max upload size on the live site.",
                "Compress with Recommended; verify bank figures and passport text.",
                "Keep an uncompressed original for the interview.",
            ],
            ["compress-pdf-for-government-forms"] =
            [
                "Scan at 200–300 DPI grayscale unless color is required.",
                "Use one PDF per portal upload slot when separate fields exist.",
                "Compress with Recommended; target 500 KB–2 MB if needed.",
                "Verify ID numbers and seals at 100% zoom before submit.",
            ],
            ["merge-pdf-online"] =
            [
                "Open Merge PDF in your browser — no install required.",
                "Upload PDFs in order; unlock encrypted files first.",
                "Download the combined PDF and verify page order.",
                "Compress once if the merged file exceeds email or portal limits.",
            ],
            ["bulk-gst-invoice-generator"] =
            [
                "Download the bulk GST CSV template from Bulk Invoice.",
                "Fill GSTIN, HSN/SAC, tax split, and line items per row.",
                "Upload CSV and download the ZIP of PDF invoices.",
                "Validate sample PDFs with the GST invoice checker before sending.",
            ],
            ["compress-pdf-for-email"] =
            [
                "Check PDF size against your email provider limit (aim under 20 MB for Gmail).",
                "Compress with Recommended on RatPDF.",
                "Verify with the PDF size checker preset for your provider.",
                "Split into parts only if compression would blur fine print.",
            ],
            ["compress-pdf-irctc"] =
            [
                "Scan documents at 200–300 DPI grayscale in document mode.",
                "Compress with Recommended on RatPDF.",
                "Target 500 KB–1 MB if the portal still rejects the upload.",
                "Verify certificate numbers and stamps at 100% zoom before submit.",
            ],
            ["compress-pdf-for-linkedin"] =
            [
                "Export a digital PDF resume from Word or Google Docs.",
                "Compress with Recommended if over ~2 MB.",
                "Confirm text still selects in the PDF viewer.",
                "Upload to LinkedIn with a professional filename.",
            ],
            ["ocr-pdf-hindi"] =
            [
                "Scan Hindi documents at 300 DPI with straight alignment.",
                "Run OCR PDF on the scanned file.",
                "Verify Devanagari search with Ctrl+F in the viewer.",
                "Export UTF-8 text via PDF to Text and proofread matras.",
            ],
            ["ocr-pdf-arabic"] =
            [
                "Confirm the PDF is image-only and scan at 300 DPI.",
                "Run OCR PDF on the Arabic or Urdu scan.",
                "Verify connected letters via search in the PDF viewer.",
                "Export UTF-8 text or PDF to Word; proofread RTL content manually.",
            ],
            ["compress-pdf-for-telegram"] =
            [
                "Check PDF size — aim under 15 MB for fast mobile sends.",
                "Compress with Recommended on RatPDF.",
                "Download and attach as File/Document in Telegram (not photo album).",
                "Verify signatures and fine print at 100% zoom before forwarding.",
            ],
            ["compress-pdf-for-naukri"] =
            [
                "Export a digital PDF resume from Word or Google Docs.",
                "Compress with Recommended if over ~2 MB.",
                "Confirm text still selects in the PDF viewer.",
                "Upload to Naukri with a professional filename.",
            ],
            ["compress-pdf-cloud-storage"] =
            [
                "Keep an uncompressed master copy locally for legal records.",
                "Compress scan-heavy PDFs with Recommended on RatPDF.",
                "Upload compressed copies to Drive, Dropbox, or OneDrive.",
                "Spot-check stamps and account numbers before sharing links.",
            ],
            ["compress-pdf-for-printing"] =
            [
                "Duplicate the PDF — keep an uncompressed print master.",
                "Compress the copy with Less (photo-heavy) or Recommended (text).",
                "Print one test page and verify logos and fine type.",
                "Email or upload the compressed copy; retain master for reprints.",
            ],
            ["compress-pdf-for-protonmail"] =
            [
                "Aim under 20 MB for Proton Mail's 25 MB attachment cap.",
                "Compress with Recommended on RatPDF.",
                "Verify size with the PDF size checker.",
                "Attach in Proton Mail; spot-check signatures before send.",
            ],
            ["compress-pdf-for-yahoo-mail"] =
            [
                "Target under 20 MB before Yahoo Mail attach.",
                "Compress with Recommended on RatPDF.",
                "Save to Downloads on mobile, then attach as File.",
                "Split into parts only if compression would blur fine print.",
            ],
            ["compress-pdf-for-workday"] =
            [
                "Read each Workday upload field's max size on the live form.",
                "Export a digital PDF resume; compress with Recommended if over cap.",
                "Confirm text still selects in the PDF viewer.",
                "Upload one PDF per field with a clear filename.",
            ],
            ["compress-pdf-schengen-visa"] =
            [
                "Check VFS/consulate max size on your live booking page.",
                "Merge documents in checklist order, then compress with Recommended.",
                "Scan at 200–300 DPI; verify passport MRZ and bank balances at 100% zoom.",
                "Keep uncompressed originals for the appointment.",
            ],
            ["compress-pdf-ukvi"] =
            [
                "Note each GOV.UK upload field's max size for your visa route.",
                "Scan at 200–300 DPI grayscale; one PDF per slot when required.",
                "Compress with Recommended on RatPDF.",
                "Verify passport MRZ and CAS/bank references before submit.",
            ],
            ["compress-pdf-home-affairs-australia"] =
            [
                "Check ImmiAccount max size per attachment field.",
                "Scan at 200–300 DPI; compress with Recommended.",
                "Upload one document type per PDF when slots are separate.",
                "Verify passport MRZ and policy dates at 100% zoom.",
            ],
            ["compress-pdf-immigration-canada"] =
            [
                "Read IRCC file size notes on each upload button.",
                "Scan at 200–300 DPI; merge only when checklist allows.",
                "Compress with Recommended after merge.",
                "Verify UCI, passport number, and balances before submit.",
            ],
            ["ocr-pdf-spanish"] =
            [
                "Scan Spanish documents at 300 DPI with straight alignment.",
                "Run OCR PDF on the scanned file.",
                "Verify accented words via search in the PDF viewer.",
                "Export UTF-8 text via PDF to Text and proofread IDs manually.",
            ],
            ["compress-pdf-ucas"] =
            [
                "Check max file size on the UCAS or university upload field.",
                "Export digital PDF; compress with Recommended if over cap.",
                "Verify portfolio or reference text at 100% zoom.",
                "Upload one PDF per field unless instructions allow a bundle.",
            ],
            ["compress-pdf-uidai"] =
            [
                "Scan address/ID proof at 200–300 DPI grayscale.",
                "Compress with Recommended on RatPDF.",
                "Target 500 KB–1 MB if the portal rejects again.",
                "Verify name, address, and ID numbers at 100% zoom.",
            ],
            ["compress-pdf-for-passport-application"] =
            [
                "Check per-document size limit on the live passport portal.",
                "Scan at 200–300 DPI; one document per PDF when required.",
                "Compress with Recommended; use Less on signed affidavits.",
                "Verify MRZ, photo, and stamps at 100% zoom before upload.",
            ],
            ["ocr-pdf-chinese"] =
            [
                "Scan Chinese documents at 300 DPI with high contrast.",
                "Run OCR PDF on the image-only scan.",
                "Verify search for known characters in the PDF viewer.",
                "Export UTF-8 text via PDF to Text; proofread amounts manually.",
            ],
            ["ocr-pdf-french"] =
            [
                "Confirm the PDF is image-only and scan at 300 DPI.",
                "Run OCR PDF on the French scan.",
                "Verify accented words via search in the PDF viewer.",
                "Export UTF-8 text or PDF to Word; proofread names and amounts.",
            ],
            ["ocr-pdf-german"] =
            [
                "Scan German documents at 300 DPI with straight alignment.",
                "Run OCR PDF on the scanned file.",
                "Verify umlauts via search in the PDF viewer.",
                "Export UTF-8 text via PDF to Text; proofread IBANs and VAT IDs.",
            ],
            ["ocr-pdf-japanese"] =
            [
                "Scan at 300 DPI; crop margins and avoid shadows.",
                "Run OCR PDF on the Japanese scan.",
                "Test search for known kanji or katakana.",
                "Export UTF-8 text; proofread names and account numbers manually.",
            ],
            ["ocr-pdf-russian"] =
            [
                "Confirm image-only pages and scan at 300 DPI.",
                "Run OCR PDF on the Cyrillic scan.",
                "Verify search for Russian words in the viewer.",
                "Export UTF-8 text; proofread INN and amounts manually.",
            ],
            ["compress-pdf-usajobs"] =
            [
                "Read the USAJOBS announcement attachment size limit.",
                "Export federal resume PDF; compress with Recommended if over cap.",
                "Confirm text still selects in the PDF viewer.",
                "Upload with a clear LastName_FirstName_Resume.pdf filename.",
            ],
            ["ocr-pdf-poor-quality"] =
            [
                "Re-scan at 300 DPI with straight alignment if OCR text is garbled.",
                "Rotate skewed pages before OCR.",
                "Run OCR PDF on the improved scan.",
                "Compress only after OCR if upload size requires it.",
            ],
            ["ocr-pdf-korean"] =
            [
                "Scan Korean documents at 300 DPI with straight alignment.",
                "Run OCR PDF on the image-only scan.",
                "Verify Hangul via search in the PDF viewer.",
                "Export UTF-8 text via PDF to Text; proofread IDs manually.",
            ],
            ["ocr-pdf-portuguese"] =
            [
                "Scan Portuguese documents at 300 DPI grayscale.",
                "Run OCR PDF on the scanned file.",
                "Verify accented words via search in the viewer.",
                "Export UTF-8 text; proofread tax IDs and amounts.",
            ],
            ["compress-pdf-on-iphone"] =
            [
                "Open Compress PDF in Safari or Chrome on iPhone/iPad.",
                "Upload PDF from Files; use Recommended compression.",
                "Save compressed PDF to the Files app.",
                "Attach from Files in Mail, WhatsApp, or portal upload.",
            ],
            ["compress-pdf-on-android"] =
            [
                "Open Compress PDF in Chrome on Android.",
                "Upload PDF from Downloads or Drive.",
                "Compress with Recommended and download.",
                "Share via Gmail, WhatsApp document, or portal upload.",
            ],
            ["mistakes-pdf-to-word-for-scanned-tables"] =
            [
                "Diagnose: if text does not select, the PDF is a scan.",
                "Run OCR PDF before PDF to Word on scanned tables.",
                "Use PDF to Excel for numeric tables when possible.",
                "Avoid compressing before OCR on fine-print scans.",
            ],
            ["compress-pdf-on-mac"] =
            [
                "Open Compress PDF in Safari or Chrome on macOS.",
                "Upload PDF from Finder; choose Recommended compression.",
                "Download to Downloads; verify size in Get Info.",
                "Attach via Mail or upload to portal from compressed copy.",
            ],
            ["compress-pdf-on-windows"] =
            [
                "Open Compress PDF in Edge or Chrome on Windows.",
                "Upload PDF from File Explorer or drag onto the page.",
                "Use Recommended compression and download.",
                "Attach in Outlook or upload to SharePoint from Downloads.",
            ],
            ["compress-pdf-with-images"] =
            [
                "Check current PDF size in properties or size checker.",
                "Upload image-heavy PDF to Compress PDF.",
                "Start with Recommended; inspect photos at 100% zoom.",
                "Try High only on a copy if portal still rejects.",
            ],
            ["compress-pdf-without-quality-loss"] =
            [
                "Archive an uncompressed master copy first.",
                "Run Low or Recommended compression on a working copy.",
                "Inspect signatures and fine print at full zoom.",
                "Split or re-scan instead of High if quality fails.",
            ],
            ["compress-pdf-made-it-larger"] =
            [
                "Check original size and whether the PDF is scan-heavy or text-only.",
                "Compress a copy — compare output size to the original.",
                "If size grew, try Recommended on image PDFs or split instead.",
                "Re-scan at lower DPI or share a cloud link if still over cap.",
            ],
            ["pdf-to-word-garbled-text"] =
            [
                "Test text selection in the PDF viewer — garbled copy means OCR needed.",
                "Run OCR PDF on scans at 300 DPI before PDF to Word.",
                "Re-convert and search DOCX for a known word.",
                "Use PDF to Text UTF-8 or request original DOCX if still broken.",
            ],
            ["convert-contract-pdf-to-word"] =
            [
                "Confirm contract text selects in the PDF viewer.",
                "OCR signed scans at 300 DPI before PDF to Word.",
                "Convert to DOCX and enable Track Changes in Word.",
                "Export PDF for counterparty review when edits are complete.",
            ],
            ["convert-nda-pdf-to-word"] =
            [
                "Check if NDA text is digital or scan-only.",
                "Run OCR on one-page scanned NDAs if needed.",
                "Convert with PDF to Word and edit defined terms.",
                "Export PDF for countersignature; keep executed PDF archived.",
            ],
            ["convert-lease-agreement-pdf-to-word"] =
            [
                "Unlock password-protected lease PDFs if required.",
                "OCR scanned leases before PDF to Word.",
                "Edit rent, deposit, and term fields in Word.",
                "Export PDF for both parties to sign; archive original.",
            ],
            ["convert-bank-statement-pdf-to-word"] =
            [
                "Download digital statement PDF from the bank portal.",
                "Unlock with bank password if the file is protected.",
                "Convert with PDF to Word; verify balances against PDF.",
                "Use PDF to Excel instead if you need transaction columns.",
            ],
            ["convert-sow-pdf-to-word"] =
            [
                "Confirm SOW text selects in the PDF viewer.",
                "Convert with PDF to Word and download DOCX.",
                "Edit scope, milestones, and fee tables in Word.",
                "Recalculate totals manually and export PDF for sign-off.",
            ],
            ["convert-purchase-order-pdf-to-word"] =
            [
                "Confirm PO line items are selectable in the PDF viewer.",
                "Convert with PDF to Word; open DOCX.",
                "Edit quantities, dates, and ship-to fields.",
                "Verify totals manually and export PDF for the vendor.",
            ],
            ["convert-quotation-pdf-to-word"] =
            [
                "Use digital quote PDF from CRM or export tool.",
                "Convert with PDF to Word and download DOCX.",
                "Edit pricing, validity date, and terms in Word.",
                "Export PDF and send to the client or attach to CRM.",
            ],
            ["convert-proforma-invoice-pdf-to-word"] =
            [
                "Confirm product lines select in the proforma PDF.",
                "Convert with PDF to Word; edit HS codes and prices.",
                "Verify total and incoterms against shipment docs.",
                "Export PDF for bank, customs, or buyer approval.",
            ],
            ["convert-receipt-pdf-to-word"] =
            [
                "OCR phone-photo receipt PDFs before PDF to Word.",
                "Convert and add expense category or project code in Word.",
                "Verify amount and date against the original receipt.",
                "Export PDF for expense portal or merge into monthly pack.",
            ],
            ["convert-credit-note-pdf-to-word"] =
            [
                "Match credit note to original invoice reference number.",
                "Convert digital credit note PDF to DOCX.",
                "Edit allowed fields; recalculate credit total manually.",
                "Export PDF and attach to ERP or email AP team.",
            ],
            ["convert-debit-note-pdf-to-word"] =
            [
                "Link debit note to the original invoice number.",
                "Convert digital debit note PDF to DOCX.",
                "Edit allowed line items; recalculate debit total manually.",
                "Export PDF and route through ERP approval.",
            ],
            ["convert-delivery-note-pdf-to-word"] =
            [
                "Confirm delivery line items select in the PDF viewer.",
                "Convert with PDF to Word; edit qty and vehicle reference.",
                "Match against PO and goods receipt in ERP.",
                "Export PDF and attach to GRN or logistics email.",
            ],
            ["convert-tax-return-pdf-to-word"] =
            [
                "Confirm PDF is a draft — not filed acknowledgement.",
                "Convert draft digital return PDF to DOCX.",
                "Add cover letter or review notes in Word.",
                "Export PDF for client pack; never alter filed return numbers.",
            ],
            ["convert-transcript-pdf-to-word"] =
            [
                "Use unofficial transcript PDF only — not sealed official copy.",
                "OCR scanned transcripts if text does not select.",
                "Add cover page in Word if evaluator requires it.",
                "Submit official PDF per university portal rules.",
            ],
            ["compress-pdf-students"] =
            [
                "Check LMS or email upload size limit.",
                "Merge readings if needed, then open Compress PDF.",
                "Use Recommended; preview diagrams at 100% zoom.",
                "Upload compressed copy; keep original archived.",
            ],
            ["compress-pdf-freelancers"] =
            [
                "Generate digital invoice PDF when possible.",
                "Compress with Recommended if over client email cap.",
                "Rename file clearly before sending.",
                "Attach via email or WhatsApp document.",
            ],
            ["how-to-merge-pdf-files"] =
            [
                "Unlock password-protected PDFs before merge.",
                "Upload PDFs to Merge PDF in desired order.",
                "Reorder with drag handles or numeric filenames.",
                "Download merged PDF and verify page 1.",
            ],
            ["glossary-compress-pdf-online"] =
            [
                "Understand: compress shrinks images inside the PDF.",
                "Choose Medium (Recommended) as default level.",
                "Use for email, portal, or WhatsApp size limits.",
                "Keep an uncompressed master for legal records.",
            ],
            ["glossary-pdf-to-word-converter"] =
            [
                "Check if PDF text selects — if not, OCR first.",
                "Upload to PDF to Word for DOCX export.",
                "Open in Word, Google Docs, or LibreOffice.",
                "Use PDF to Text instead if you only need quotes.",
            ],
            ["compress-pdf-teachers"] =
            [
                "Scan or export handouts at 200–250 DPI when possible.",
                "Merge weekly PDFs in syllabus order if needed.",
                "Compress with Recommended in browser.",
                "Upload to LMS or email parents from compressed copy.",
            ],
            ["compress-pdf-recruiters"] =
            [
                "Merge candidate pack in CV-first order.",
                "Check size against client email or ATS limit.",
                "Compress with Recommended if over ~10 MB.",
                "Send compressed copy; retain original per policy.",
            ],
            ["compress-pdf-hr"] =
            [
                "Export digital offer PDF from HRIS when possible.",
                "Merge offer, benefits, and policy PDFs in order.",
                "Compress with Recommended if over email cap.",
                "Verify signatures before Workday or candidate upload.",
            ],
            ["compress-pdf-government"] =
            [
                "Check live portal size limit before upload.",
                "Scan IDs at 300 DPI straight; crop margins.",
                "Merge only if checklist allows one combined file.",
                "Compress Recommended; inspect ID numbers at full zoom.",
            ],
            ["glossary-pdf-to-text-extractor"] =
            [
                "Confirm text selects in PDF reader — else OCR first.",
                "Upload to PDF to Text for UTF-8 export.",
                "Open .txt in editor with UTF-8 encoding.",
                "Use PDF to Word if you need editable layout.",
            ],
            ["compress-pdf-ecommerce"] =
            [
                "Export catalog at web resolution when possible.",
                "Check marketplace or email size limit.",
                "Compress with Recommended in browser.",
                "Verify barcodes and SKU text at 100% zoom.",
            ],
            ["compress-pdf-real-estate"] =
            [
                "Merge disclosure pack in checklist order.",
                "Compress with Recommended for brochures.",
                "Use Low on fine-print inspection reports.",
                "Send compressed copy; archive original in TMS.",
            ],
            ["compress-pdf-nonprofits"] =
            [
                "Read funder portal file-size rule.",
                "Merge grant PDF in required order.",
                "Compress Recommended; verify budget and EIN.",
                "Keep uncompressed master for audit trail.",
            ],
            ["compress-pdf-construction"] =
            [
                "Scan drawings straight; merge submittal in order.",
                "Check municipal portal size cap.",
                "Use Recommended; Low on stamped CAD sheets.",
                "Upload compressed copy; retain full-res in project drive.",
            ],
            ["compress-pdf-marketing-agencies"] =
            [
                "Export deck at screen DPI from design tool.",
                "Compress Recommended if over ~15 MB.",
                "Spot-check hero creative and disclaimer text.",
                "Deliver via email or client portal.",
            ],
            ["background-remover"] =
            [
                "Open the background remover tool in your browser.",
                "Select or drag a JPG, PNG, WEBP, or BMP image — it stays on your device.",
                "Wait for on-device AI segmentation to finish.",
                "Download the transparent PNG at the same resolution as your original.",
            ],
            ["json-formatter-guide"] =
            [
                "Paste minified JSON into the formatter.",
                "Review pretty-printed output and syntax errors.",
                "Fix any highlighted issues in your source.",
                "Copy formatted JSON or compare with text comparer.",
            ],
            ["jwt-decoder-guide"] =
            [
                "Paste the JWT token (header.payload.signature).",
                "Inspect decoded header and payload JSON.",
                "Check exp, iss, aud, and scope claims.",
                "Verify signatures in your backend — decoding alone is not verification.",
            ],
            ["developer-tools-guide"] =
            [
                "Browse the developer tools hub for your task.",
                "Open JSON formatter, JWT decoder, or HTML formatter as needed.",
                "Use text comparer to diff before/after output.",
                "Bookmark frequently used utilities for daily debugging.",
            ],
            ["html-formatter-guide"] = ["Paste minified HTML.", "Review indented markup.", "Diff with text comparer if needed."],
            ["dns-lookup-guide"] = ["Enter domain name.", "Select record type (A, MX, TXT).", "Review results for migration or verification."],
            ["text-comparer-guide"] = ["Paste original text in left pane.", "Paste revised text in right pane.", "Review highlighted diffs."],
            ["url-encoder-guide"] = ["Paste string to encode or decode.", "Copy percent-encoded output.", "Use in OAuth or API URLs."],
            ["img-to-base64-guide"] = ["Upload small image.", "Copy Base64 or data URI.", "Embed only for tiny assets."],
            ["binary-converter-guide"] = ["Enter binary or decimal value.", "Read converted output.", "Verify bit boundaries for networking."],
        };

        public static IReadOnlyList<string>? Get(string slug) =>
            BySlug.TryGetValue(slug, out var steps) ? steps : null;
    }
}
