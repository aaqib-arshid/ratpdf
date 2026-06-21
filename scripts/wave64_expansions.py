"""Wave 64 — Glossary batch 2 (invoice/payslip terms) + hand_core pillar upgrades."""

W64_GLOSSARY_SLUGS = [
    "glossary-digital-signature-invoice",
    "glossary-e-invoice",
    "glossary-gst-invoice",
    "glossary-payslip",
    "glossary-proforma-invoice",
    "glossary-qr-code-invoice",
    "glossary-rent-receipt",
    "glossary-salary-slip",
    "glossary-tax-invoice",
]

W64_HAND_CORE_SLUGS = [
    "word-to-pdf",
    "text-to-pdf",
    "sign-pdf",
    "images-to-pdf",
    "background-remover",
    "word-counter-guide",
    "ring-size-converter-guide",
    "my-ip-guide",
    "invoice-generator-guide",
    "extract-images-from-pdf",
    "pdf-tool-alternatives",
    "watermark-vs-password-pdf",
    "sign-pdf-legally",
    "pdf-txt-guide",
    "pdf-to-text",
]

W64_SLUGS = W64_GLOSSARY_SLUGS + W64_HAND_CORE_SLUGS

W64_DATA = {
    "glossary-digital-signature-invoice": {
        "title": "What Is a Digital Signature on an Invoice? — Typed, Drawn &amp; PKI (2026)",
        "tool": "/pdf/signtext",
        "label": "Sign PDF",
        "pillar": "/guides/sign-pdf",
        "pillar_label": "sign PDF guide",
        "example": "Freelancer adds typed approval on PDF invoice before client payment — distinct from GST IRN signing",
        "kind": "glossary",
    },
    "glossary-e-invoice": {
        "title": "What Is E-Invoicing? — IRN, Peppol, JSON &amp; PDF (2026)",
        "tool": "/invoice/create",
        "label": "Create Invoice",
        "pillar": "/guides/e-invoicing-india-pdf",
        "pillar_label": "e-invoicing India guide",
        "example": "B2B supplier in India must file IRN in portal — PDF alone does not satisfy mandate",
        "kind": "glossary",
    },
    "glossary-gst-invoice": {
        "title": "What Is a GST Tax Invoice? — CGST, SGST, IGST &amp; HSN (2026)",
        "tool": "/invoice/create",
        "label": "Create Invoice",
        "pillar": "/guides/gst-invoice-format-india",
        "pillar_label": "GST invoice format India",
        "example": "Bangalore B2B sale shows CGST 9% + SGST 9% on PDF — inter-state needs IGST line",
        "kind": "glossary",
    },
    "glossary-payslip": {
        "title": "What Is a Payslip PDF? — Salary Slip vs Invoice (2026)",
        "tool": "/guides/invoice-generator-guide",
        "label": "Invoice &amp; payslip tools",
        "pillar": "/guides/how-to-export-payslip-pdf",
        "pillar_label": "export payslip PDF guide",
        "example": "HR sends monthly payslip PDF with gross, PF, TDS, and net pay — employee uses it for loan KYC",
        "kind": "glossary",
    },
    "glossary-proforma-invoice": {
        "title": "What Is a Proforma Invoice? — Quote vs Tax Invoice (2026)",
        "tool": "/invoice/create",
        "label": "Create Invoice",
        "pillar": "/guides/how-to-create-proforma-invoice",
        "pillar_label": "create proforma invoice guide",
        "example": "Exporter sends proforma for customs valuation — reissues tax invoice after shipment",
        "kind": "glossary",
    },
    "glossary-qr-code-invoice": {
        "title": "What Is a QR Code on an Invoice? — IRN, B2B India &amp; Scan Checks (2026)",
        "tool": "/invoice/create",
        "label": "Create Invoice",
        "pillar": "/guides/e-invoicing-india-pdf",
        "pillar_label": "e-invoicing India guide",
        "example": "Buyer scans QR on GST invoice — IRN hash must match NIC portal record",
        "kind": "glossary",
    },
    "glossary-rent-receipt": {
        "title": "What Is a Rent Receipt PDF? — HRA, Landlord PAN &amp; Stamp (2026)",
        "tool": "/invoice/create",
        "label": "Create Invoice",
        "pillar": "/guides/how-to-create-rent-receipt-pdf",
        "pillar_label": "rent receipt PDF guide",
        "example": "Tenant claims HRA — needs landlord PAN on receipt when rent exceeds threshold",
        "kind": "glossary",
    },
    "glossary-salary-slip": {
        "title": "What Is a Salary Slip? — Payslip PDF Fields Explained (2026)",
        "tool": "/guides/invoice-generator-guide",
        "label": "Invoice &amp; payslip tools",
        "pillar": "/guides/glossary-payslip",
        "pillar_label": "payslip glossary",
        "example": "Payroll exports salary slip PDF with YTD totals — employee verifies TDS before ITR filing",
        "kind": "glossary",
    },
    "glossary-tax-invoice": {
        "title": "What Is a Tax Invoice? — B2B VAT/GST vs Retail Receipt (2026)",
        "tool": "/invoice/create",
        "label": "Create Invoice",
        "pillar": "/guides/invoice-generator-guide",
        "pillar_label": "invoice generator guide",
        "example": "Registered dealer issues tax invoice so buyer claims input tax credit — retail bill is not enough",
        "kind": "glossary",
    },
    "word-to-pdf": {
        "title": "Word to PDF Online — Embed Fonts, Print Layout &amp; LibreOffice Export (2026)",
        "tool": "/pdf/doctopdf",
        "label": "Word to PDF",
        "pillar": "/guides/word-to-pdf",
        "pillar_label": "Word to PDF guide",
        "example": "Consultant exports proposal DOCX to PDF so client cannot edit pricing tables",
        "kind": "hand_core",
    },
    "text-to-pdf": {
        "title": "Text to PDF Online — Plain Notes to Archival PDF (2026)",
        "tool": "/pdf/texttopdf",
        "label": "Text to PDF",
        "pillar": "/guides/text-to-pdf",
        "pillar_label": "text to PDF guide",
        "example": "Developer archives meeting notes TXT as PDF for immutable audit folder",
        "kind": "hand_core",
    },
    "sign-pdf": {
        "title": "Sign PDF Online — Typed, Drawn &amp; Approval Blocks (2026)",
        "tool": "/pdf/signtext",
        "label": "Sign PDF",
        "pillar": "/guides/sign-pdf",
        "pillar_label": "sign PDF guide",
        "example": "Agency adds typed signature block to SOW PDF before client countersign",
        "kind": "hand_core",
    },
    "images-to-pdf": {
        "title": "Images to PDF — Combine JPG, PNG &amp; Receipt Scans (2026)",
        "tool": "/pdf/convertimages",
        "label": "Images to PDF",
        "pillar": "/guides/images-to-pdf",
        "pillar_label": "images to PDF guide",
        "example": "Contractor merges 12 site photos into one PDF for insurance claim upload",
        "kind": "hand_core",
    },
    "background-remover": {
        "title": "AI Background Remover — 100% Browser, No Upload (2026)",
        "tool": "/tools/imgbackgroundremove",
        "label": "Background remover",
        "pillar": "/guides/background-remover-guide",
        "pillar_label": "background remover guide",
        "example": "Seller cuts product out of white backdrop for catalogue PDF — image never leaves device",
        "kind": "hand_core",
    },
    "word-counter-guide": {
        "title": "Word Counter Guide — Essays, SEO Meta &amp; Reading Time (2026)",
        "tool": "/tools/wordcounter",
        "label": "Word counter",
        "pillar": "/guides/word-counter-guide",
        "pillar_label": "word counter guide",
        "example": "Editor checks 1,500-word article limit before journal submission portal upload",
        "kind": "hand_core",
    },
    "ring-size-converter-guide": {
        "title": "Ring Size Converter — US, UK, EU &amp; India Sizing (2026)",
        "tool": "/tools/ringsizeconverter",
        "label": "Ring size converter",
        "pillar": "/guides/ring-size-converter-guide",
        "pillar_label": "ring size converter guide",
        "example": "Buyer converts US size 7 to EU 54 before ordering wedding band online",
        "kind": "hand_core",
    },
    "my-ip-guide": {
        "title": "What Is My IP Address? — Public IPv4, IPv6 &amp; VPN Checks (2026)",
        "tool": "/tools/whatismyip",
        "label": "What is my IP",
        "pillar": "/guides/my-ip-guide",
        "pillar_label": "my IP guide",
        "example": "Admin whitelists office public IP in SaaS firewall — home VPN shows different address",
        "kind": "hand_core",
    },
    "invoice-generator-guide": {
        "title": "Free Invoice Generator — PDF Invoices, GST/VAT &amp; 50+ Currencies (2026)",
        "tool": "/invoice/create",
        "label": "Create Invoice",
        "pillar": "/guides/invoice-generator-guide",
        "pillar_label": "invoice generator guide",
        "example": "Freelancer issues GST PDF invoice with HSN lines — downloads without watermark on Pro",
        "kind": "hand_core",
    },
    "extract-images-from-pdf": {
        "title": "Extract Images from PDF — Save Embedded Photos &amp; Logos (2026)",
        "tool": "/pdf/extractimages",
        "label": "Extract images",
        "pillar": "/guides/extract-images-from-pdf",
        "pillar_label": "extract images guide",
        "example": "Designer pulls logo PNG from client brand PDF for slide deck reuse",
        "kind": "hand_core",
    },
    "pdf-tool-alternatives": {
        "title": "PDF Tool Alternatives — Browser vs Adobe, Smallpdf &amp; iLovePDF (2026)",
        "tool": "/compare",
        "label": "Compare PDF tools",
        "pillar": "/guides/pdf-tool-alternatives",
        "pillar_label": "PDF tool alternatives guide",
        "example": "Startup compares Acrobat subscription cost vs RatPDF Pro for 20 compressions/day",
        "kind": "hand_core",
    },
    "watermark-vs-password-pdf": {
        "title": "Watermark vs Password PDF — Deterrent vs Encryption (2026)",
        "tool": "/pdf/watermark",
        "label": "Watermark PDF",
        "pillar": "/guides/watermark-vs-password-pdf",
        "pillar_label": "watermark vs password guide",
        "example": "Legal marks DRAFT watermark on review PDF — encrypts final signed copy separately",
        "kind": "hand_core",
    },
    "sign-pdf-legally": {
        "title": "Sign PDF Legally — ESIGN, eIDAS &amp; Typed Signatures (2026)",
        "tool": "/pdf/signtext",
        "label": "Sign PDF",
        "pillar": "/guides/sign-pdf-legally",
        "pillar_label": "sign PDF legally guide",
        "example": "US remote hire signs offer letter PDF with consent email thread — not qualified PKI",
        "kind": "hand_core",
    },
    "pdf-txt-guide": {
        "title": "PDF to Text Guide — Extract, OCR &amp; Plain TXT Workflows (2026)",
        "tool": "/pdf/pdftotext",
        "label": "PDF to Text",
        "pillar": "/guides/pdf-txt-guide",
        "pillar_label": "PDF to Text guide",
        "example": "Analyst exports quarterly report PDF to TXT for keyword compliance scan",
        "kind": "hand_core",
    },
    "pdf-to-text": {
        "title": "PDF to Text Guide — Extract, OCR &amp; Plain TXT Workflows (2026)",
        "tool": "/pdf/pdftotext",
        "label": "PDF to Text",
        "pillar": "/guides/pdf-to-text",
        "pillar_label": "PDF to Text guide",
        "example": "Analyst exports quarterly report PDF to TXT for keyword compliance scan",
        "kind": "hand_core",
    },
}

W64_GLOSSARY_DEEP = {
    "glossary-digital-signature-invoice": """
            <h2>Definition</h2>
            <p>A <strong>digital signature on an invoice PDF</strong> can mean three different things: (1) a visible typed or drawn approval block, (2) a cryptographic PKI signature binding identity to document hash, or (3) a government e-invoice signing step in a tax portal — they are not interchangeable.</p>
            <p>Workflow: <a href="/guides/sign-pdf">sign PDF guide</a> · Legal context: <a href="/guides/sign-pdf-legally">sign PDF legally</a> · PKI glossary: <a href="/guides/glossary-digital-signature">digital signature glossary</a>.</p>
            <h2>Typed vs certificate signatures on invoices</h2>
            <table class="table table-sm"><thead><tr><th>Type</th><th>Typical use on invoices</th></tr></thead>
            <tbody>
            <tr><td>Typed / drawn on PDF</td><td>Internal approval, freelancer SOW acceptance, scan-and-email workflows</td></tr>
            <tr><td>PKI / qualified</td><td>Regulated B2G, some EU eIDAS qualified flows — DocuSign, Adobe Sign, national trust providers</td></tr>
            <tr><td>Tax portal IRN</td><td>India e-invoice — signing happens in NIC ecosystem — PDF QR reflects IRN, not Acrobat stamp</td></tr>
            </tbody></table>
            <h2>RatPDF capability</h2>
            <p><a href="/pdf/signtext">Sign PDF</a> adds visible typed or drawn signatures — suitable for many business invoices — not Adobe-approved certificate signing. Generate invoice first on <a href="/invoice/create">Create Invoice</a>, then sign the downloaded PDF if needed.</p>
            """,
    "glossary-e-invoice": """
            <h2>Definition</h2>
            <p><strong>E-invoicing</strong> means structured electronic invoice data exchanged between supplier ERP and buyer systems — often JSON or XML — validated by a tax network before a human-readable PDF is issued.</p>
            <p>India: <a href="/guides/e-invoicing-india-pdf">e-invoicing India guide</a> · EU: <a href="/guides/vat-invoice-eu-requirements">EU VAT requirements</a> · ZUGFeRD: <a href="/guides/glossary-zugferd">ZUGFeRD glossary</a>.</p>
            <h2>PDF vs e-invoice payload</h2>
            <ul>
            <li><strong>PDF alone</strong> — visual document for humans — insufficient for India B2B IRN mandate</li>
            <li><strong>IRN + QR</strong> — India — JSON filed to IRP — PDF displays QR linking to validated record</li>
            <li><strong>Peppol / UBL</strong> — EU B2G — XML on network — PDF optional attachment</li>
            <li><strong>Factur-X / ZUGFeRD</strong> — hybrid PDF with embedded XML — France/Germany workflows</li>
            </ul>
            <h2>RatPDF role</h2>
            <p><a href="/invoice/create">Create Invoice</a> produces compliant-looking PDF layouts — ERP integration for IRN/Peppol filing stays in your accounting stack — use RatPDF for PDF generation, compress, and email delivery after portal validation.</p>
            """,
    "glossary-gst-invoice": """
            <h2>Definition</h2>
            <p>A <strong>GST tax invoice</strong> is a statutory document for registered suppliers in India showing CGST/SGST or IGST per line, supplier GSTIN, HSN/SAC codes, and sequential invoice number — required for buyer input tax credit.</p>
            <p>Format guide: <a href="/guides/gst-invoice-format-india">GST invoice format India</a> · CGST/IGST: <a href="/guides/cgst-sgst-igst-invoice">CGST SGST IGST invoice</a>.</p>
            <h2>Mandatory PDF fields (India)</h2>
            <ul>
            <li>Supplier GSTIN and legal name</li>
            <li>Invoice number and date — sequential per FY</li>
            <li>Buyer GSTIN for B2B (when registered)</li>
            <li>HSN/SAC per line — 4/6/8 digit per turnover slab</li>
            <li>Taxable value, tax rate, tax amount — CGST+SGST intra-state or IGST inter-state</li>
            <li>Place of supply when IGST applies</li>
            </ul>
            <h2>Common errors</h2>
            <p>Wrong tax split (IGST on intra-state sale), missing HSN, reusing invoice numbers, treating proforma as final tax invoice — see <a href="/guides/glossary-proforma-invoice">proforma glossary</a>.</p>
            """,
    "glossary-payslip": """
            <h2>Definition</h2>
            <p>A <strong>payslip PDF</strong> (salary slip) documents gross pay, statutory deductions, and net pay for an employee for a pay period — distinct from a tax invoice or contractor invoice.</p>
            <p>Export workflow: <a href="/guides/how-to-export-payslip-pdf">export payslip PDF</a> · Salary slip terms: <a href="/guides/glossary-salary-slip">salary slip glossary</a>.</p>
            <h2>Payslip vs invoice</h2>
            <table class="table table-sm"><thead><tr><th>Document</th><th>Direction</th><th>Typical fields</th></tr></thead>
            <tbody>
            <tr><td>Tax invoice</td><td>Seller → buyer</td><td>Line items, GST/VAT, payment terms</td></tr>
            <tr><td>Payslip</td><td>Employer → employee</td><td>Basic, HRA, PF, TDS, net pay, YTD</td></tr>
            <tr><td>Contractor invoice</td><td>Freelancer → client</td><td>Services, GST if registered, bank details</td></tr>
            </tbody></table>
            <h2>Distribution hygiene</h2>
            <p>Send payslip PDFs over secure HR portal or encrypted email — compress copies with <a href="/pdf/compress">Compress PDF</a> if size cap applies — never mix with client invoice folders.</p>
            """,
    "glossary-proforma-invoice": """
            <h2>Definition</h2>
            <p>A <strong>proforma invoice</strong> is a preliminary quotation formatted like an invoice — used for customs, import licenses, and client approval — not a substitute for a tax invoice after supply occurs.</p>
            <p>How-to: <a href="/guides/how-to-create-proforma-invoice">create proforma invoice</a> · Tax invoice: <a href="/guides/glossary-tax-invoice">tax invoice glossary</a>.</p>
            <h2>When to use proforma</h2>
            <ul>
            <li>Export customs valuation before shipment</li>
            <li>Client budget approval before PO issuance</li>
            <li>Advance payment request with line-item detail</li>
            </ul>
            <h2>After approval</h2>
            <p>Issue new sequential <strong>tax invoice</strong> with correct tax date and IRN (if applicable) — do not edit proforma PDF in place — credit/debit notes for corrections per <a href="/guides/glossary-credit-note">credit note glossary</a>.</p>
            """,
    "glossary-qr-code-invoice": """
            <h2>Definition</h2>
            <p>A <strong>QR code on a GST invoice PDF</strong> encodes IRN-related data so buyers and tax officers scan to verify the invoice was registered on the Invoice Registration Portal — the QR must match live portal status.</p>
            <p>India workflow: <a href="/guides/e-invoicing-india-pdf">e-invoicing India PDF</a> · IRN: <a href="/guides/glossary-irn">IRN glossary</a>.</p>
            <h2>Scan failures</h2>
            <ul>
            <li>IRN cancelled in portal but old PDF still emailed</li>
            <li>QR too small on print — minimum size for reliable scan</li>
            <li>PDF recompressed blur — verify after <a href="/pdf/compress">compress</a></li>
            <li>Fake QR pasted without IRN filing — criminal fraud risk</li>
            </ul>
            <h2>RatPDF note</h2>
            <p>Visual QR on PDF layout from <a href="/invoice/create">Create Invoice</a> does not replace ERP IRN API filing — accountant must reconcile JSON response with PDF output.</p>
            """,
    "glossary-rent-receipt": """
            <h2>Definition</h2>
            <p>A <strong>rent receipt PDF</strong> documents rent paid to a landlord — used for HRA tax exemption claims in India and general tenancy records elsewhere — may require landlord PAN above statutory threshold.</p>
            <p>How-to: <a href="/guides/how-to-create-rent-receipt-pdf">rent receipt PDF guide</a> · HRA: common payroll topic — keep receipts with lease agreement.</p>
            <h2>Fields tenants need</h2>
            <ul>
            <li>Landlord name, address, PAN (when required)</li>
            <li>Tenant name and property address</li>
            <li>Rent amount, period covered, payment mode</li>
            <li>Landlord signature or digital acceptance</li>
            <li>Revenue stamp rules where applicable (physical workflows)</li>
            </ul>
            <h2>Not a tax invoice</h2>
            <p>Rent receipt is not GST tax invoice unless landlord is registered supplier charging GST on commercial rent — consult CA for classification.</p>
            """,
    "glossary-salary-slip": """
            <h2>Definition</h2>
            <p>A <strong>salary slip</strong> is the employee-facing payslip document showing earnings and deductions for one pay cycle — synonym for payslip in HR systems.</p>
            <p>Related: <a href="/guides/glossary-payslip">payslip glossary</a> · PF line items: <a href="/guides/payslip-pf-explained">payslip PF explained</a>.</p>
            <h2>Key components</h2>
            <ul>
            <li>Earnings: basic, HRA, allowances, bonus</li>
            <li>Deductions: PF, ESI, professional tax, TDS</li>
            <li>Net pay and YTD totals</li>
            <li>Employer registration IDs on header</li>
            </ul>
            <h2>PDF quality</h2>
            <p>Searchable text helps audit — OCR legacy scans with <a href="/pdf/ocrpdf">OCR PDF</a> — compress email copies via <a href="/pdf/compress">Compress PDF</a>.</p>
            """,
    "glossary-tax-invoice": """
            <h2>Definition</h2>
            <p>A <strong>tax invoice</strong> is the formal VAT/GST document that allows B2B buyers to claim input tax credits — stricter than retail bill or cash memo — fields vary by jurisdiction.</p>
            <p>Hub: <a href="/guides/invoice-generator-guide">invoice generator guide</a> · India GST: <a href="/guides/glossary-gst-invoice">GST invoice glossary</a> · EU: <a href="/guides/vat-invoice-eu-requirements">EU VAT</a>.</p>
            <h2>Tax invoice vs other documents</h2>
            <table class="table table-sm"><thead><tr><th>Document</th><th>Tax credit?</th></tr></thead>
            <tbody>
            <tr><td>Tax invoice</td><td>Yes — when valid and registered</td></tr>
            <tr><td>Proforma</td><td>No — reissue tax invoice after supply</td></tr>
            <tr><td>Bill of supply</td><td>India — composition scheme — no tax charge</td></tr>
            <tr><td>Receipt / payment voucher</td><td>Not substitute for B2B tax invoice</td></tr>
            </tbody></table>
            <h2>Archive discipline</h2>
            <p>Store immutable PDF plus ERP JSON where e-invoice mandated — filename with invoice number and FY — <a href="/invoice/create">Create Invoice</a> for PDF generation layer.</p>
            """,
}

W64_HAND_CORE_DEEP = {
    "word-to-pdf": """
            <h2>Why LibreOffice export beats “Print to PDF”</h2>
            <p>Word’s print driver can shift margins and drop embedded fonts. RatPDF routes DOCX through <strong>LibreOffice headless</strong> — closer to what recipients see in Word on Windows and Mac.</p>
            <h2>Pre-export checklist</h2>
            <ol>
            <li><strong>Embed fonts</strong> — File → Options → Save → embed fonts in file</li>
            <li><strong>Fix broken image links</strong> — embed images, not linked paths</li>
            <li><strong>Set print area</strong> for wide tables — avoid clipped columns</li>
            <li><strong>Remove track changes</strong> or accept all before client PDF</li>
            </ol>
            <h2>After export</h2>
            <p>Chain tools: <a href="/pdf/compress">compress</a> for email · <a href="/pdf/password">password-protect</a> confidential packs · <a href="/pdf/watermark">watermark</a> drafts · Compare: <a href="/compare">PDF tools</a>.</p>
            """,
    "text-to-pdf": """
            <h2>When plain text to PDF helps</h2>
            <p>Meeting notes, code snippets, log excerpts, and API docs convert to immutable PDF for audit folders where DOCX editing is undesirable.</p>
            <h2>Formatting limits</h2>
            <p>Monospace layout preserves line breaks — no rich headings. For branded letters use <a href="/guides/word-to-pdf">Word to PDF</a> instead.</p>
            <h2>Workflow</h2>
            <ol>
            <li>Paste UTF-8 text — verify special characters render</li>
            <li>Generate PDF and spot-check page breaks</li>
            <li>Optional: <a href="/guides/watermark-pdf">watermark DRAFT</a> before review</li>
            </ol>
            """,
    "sign-pdf": """
            <h2>Visible signature blocks</h2>
            <p>Add typed name, title, and date for quotes, SOWs, and internal approvals — faster than print-sign-scan when wet ink is not required.</p>
            <h2>Not PKI qualified signing</h2>
            <p>Regulated qualified signatures need trust service providers — read <a href="/guides/sign-pdf-legally">sign PDF legally</a> · Compare PKI: <a href="/guides/glossary-digital-signature">digital signature glossary</a>.</p>
            <h2>After signing</h2>
            <p><a href="/guides/flatten-pdf">Flatten PDF</a> before archive so signature fields cannot drift · <a href="/pdf/compress">compress</a> for email delivery.</p>
            """,
    "images-to-pdf": """
            <h2>Ordering and quality</h2>
            <p>Prefix filenames 01-, 02- before upload — RatPDF merges in upload order. Phone photos: shoot straight, good light — reduces OCR need later.</p>
            <h2>Common bundles</h2>
            <ul>
            <li>Expense receipts for reimbursement PDF</li>
            <li>Site inspection photos for insurance</li>
            <li>ID scans for KYC packets — redact before share</li>
            </ul>
            <h2>Next steps</h2>
            <p>Large photo PDFs: <a href="/guides/compress-pdf-guide">compress PDF</a> · Multi-doc: <a href="/guides/merge-pdf">merge</a> with cover letter · Visa: <a href="/guides/merge-pdf-visa-application">merge for visa</a>.</p>
            """,
    "background-remover": """
            <h2>Privacy-first AI cutout</h2>
            <p>Inference runs <strong>in your browser</strong> — images are not uploaded to RatPDF servers — suitable for headshots and unreleased product shots under NDA.</p>
            <h2>Best results</h2>
            <ul>
            <li>Plain white/grey backdrop, high contrast subject</li>
            <li>PNG output preserves transparency for slide decks</li>
            <li>Place cutout in proposal via <a href="/guides/images-to-pdf">Images to PDF</a></li>
            </ul>
            <h2>Limits</h2>
            <p>Fine hair, glass, and busy backgrounds need manual touch-up in Photoshop — not unique to browser AI.</p>
            """,
    "word-counter-guide": """
            <h2>Words, characters, reading time</h2>
            <p>Academic limits use <strong>word count</strong> — meta descriptions use <strong>characters</strong> — blogs show <strong>reading time</strong> (~200 wpm).</p>
            <h2>SEO reality</h2>
            <p>Google does not rank by count alone — thin &lt;300-word pages rarely satisfy informational intent — depth beats padding — see <a href="/research/freelancer-invoicing-statistics">research hub</a> for sourced stats style.</p>
            <h2>Workflow</h2>
            <p>Paste draft → check limits → export final as PDF via <a href="/guides/text-to-pdf">Text to PDF</a> or <a href="/guides/word-to-pdf">Word to PDF</a>.</p>
            """,
    "ring-size-converter-guide": """
            <h2>US, UK, EU, India scales</h2>
            <p>Online jewellers list different scales — converting prevents costly returns — especially gifts where finger cannot be measured in store.</p>
            <h2>Measure at home</h2>
            <ol>
            <li>Non-stretch string around finger joint — not knuckle alone</li>
            <li>Mark overlap, measure mm on ruler</li>
            <li>Convert in tool — repeat twice, end of day when fingers warm</li>
            </ol>
            <p>Wide bands need slightly larger size — ask seller policy.</p>
            """,
    "my-ip-guide": """
            <h2>Public vs private IP</h2>
            <p>Websites see your <strong>public</strong> router IP — not 192.168.x.x on your LAN. VPN exit node shows provider IP instead of office.</p>
            <h2>Common tasks</h2>
            <ul>
            <li>SaaS admin IP whitelist</li>
            <li>Debug VPN split tunnel</li>
            <li>Share with IT for firewall ticket</li>
            </ul>
            <h2>IPv4 vs IPv6</h2>
            <p>Legacy portals may accept IPv4 only — note both if your ISP assigns dual stack.</p>
            """,
    "invoice-generator-guide": """
            <h2>Core invoice fields</h2>
            <p>Unique number, dates, legal names, tax IDs, line items, tax per line, payment terms, bank/UPI — jurisdiction-specific — confirm with accountant.</p>
            <h2>Country hubs</h2>
            <p><a href="/guides/invoice-generator-india">India GST</a> · <a href="/guides/invoice-generator-uk">UK VAT</a> · <a href="/guides/invoice-generator-usa">USA</a> · <a href="/guides/invoice-generator-australia">Australia</a> · <a href="/compare/invoice-generators-freelancers">best for freelancers</a>.</p>
            <h2>After PDF download</h2>
            <p>Compress email copy · OCR if scan · E-invoice JSON filing separate from PDF layout — <a href="/guides/glossary-e-invoice">e-invoice glossary</a>.</p>
            """,
    "extract-images-from-pdf": """
            <h2>Embedded vs scanned pages</h2>
            <p>Extractor pulls embedded JPEG/PNG objects — full-page scans return one image per page — not individual icons from scan.</p>
            <h2>Use cases</h2>
            <ul>
            <li>Reuse logo from brand PDF in deck</li>
            <li>Recover chart PNG from report export</li>
            <li>Build asset library from catalogue PDFs</li>
            </ul>
            <h2>Related</h2>
            <p><a href="/guides/pdf-to-images">PDF to images</a> · <a href="/guides/compress-pdf-with-images">compress image-heavy PDF</a> · <a href="/compare">compare extract tools</a>.</p>
            """,
    "pdf-tool-alternatives": """
            <h2>Browser vs desktop PDF stacks</h2>
            <p>Adobe Acrobat — full prepress, PDF/A certify, enterprise PKI. RatPDF — quick browser jobs: compress, merge, OCR, invoice PDF — no install ticket.</p>
            <h2>When to pick RatPDF</h2>
            <ul>
            <li>One-off compress for Gmail cap</li>
            <li>Freelancer invoice PDF without QuickBooks</li>
            <li>Locked-down laptop — no admin install</li>
            </ul>
            <h2>Compare matrix</h2>
            <p>Full table: <a href="/compare">compare PDF tools</a> · Market data: <a href="/research/pdf-tool-market-comparison">PDF tool market comparison</a>.</p>
            """,
    "watermark-vs-password-pdf": """
            <h2>Visual deterrent vs encryption</h2>
            <p><strong>Watermark</strong> — marks DRAFT/CONFIDENTIAL — deters casual sharing — does not stop copy-paste. <strong>Password</strong> — encrypts file — recipient needs passphrase.</p>
            <h2>Decision table</h2>
            <table class="table table-sm"><thead><tr><th>Need</th><th>Use</th></tr></thead>
            <tbody>
            <tr><td>Review cycle labeling</td><td><a href="/pdf/watermark">Watermark</a></td></tr>
            <tr><td>Payslip email attachment</td><td><a href="/pdf/password">Password protect</a></td></tr>
            <tr><td>Both</td><td>Watermark draft → encrypt final</td></tr>
            </tbody></table>
            """,
    "sign-pdf-legally": """
            <h2>Jurisdiction snapshot (not legal advice)</h2>
            <p><strong>US ESIGN/UETA</strong> — intent + consent — typed signatures often valid for commercial contracts. <strong>EU eIDAS</strong> — simple vs advanced vs qualified — qualified needs trust provider.</p>
            <h2>RatPDF scope</h2>
            <p>Visible typed/drawn signatures on <a href="/pdf/signtext">Sign PDF</a> — not qualified PKI — use DocuSign/Adobe Sign for regulated QES workflows.</p>
            <h2>Audit trail tips</h2>
            <p>Keep email consent thread, document version hash, timestamp — filename <code>Contract-v3-SIGNED.pdf</code>.</p>
            """,
    "pdf-txt-guide": """
            <h2>Extract vs OCR</h2>
            <p>Digital PDFs — fast extract via <a href="/pdf/pdftotext">PDF to Text</a>. Scans — <a href="/pdf/ocrpdf">OCR PDF</a> first — see <a href="/guides/ocr-vs-pdf-to-text">OCR vs PDF to Text</a>.</p>
            <h2>Use cases</h2>
            <ul>
            <li>Compliance keyword scan before redaction</li>
            <li>Pull logs from exported report PDFs</li>
            <li>Feed plain text to search index or LLM pipeline</li>
            </ul>
            <h2>Quality checks</h2>
            <p>Verify currency symbols and table numbers manually — OCR confuses 0/O on bank PDFs.</p>
            """,
    "pdf-to-text": """
            <h2>Extract vs OCR</h2>
            <p>Digital PDFs — fast extract via <a href="/pdf/pdftotext">PDF to Text</a>. Scans — <a href="/pdf/ocrpdf">OCR PDF</a> first — see <a href="/guides/ocr-vs-pdf-to-text">OCR vs PDF to Text</a>.</p>
            <h2>Use cases</h2>
            <ul>
            <li>Compliance keyword scan before redaction</li>
            <li>Pull logs from exported report PDFs</li>
            <li>Feed plain text to search index or LLM pipeline</li>
            </ul>
            <h2>Quality checks</h2>
            <p>Verify currency symbols and table numbers manually — OCR confuses 0/O on bank PDFs.</p>
            """,
}

W64_INVOICE_GLOSSARY_CLUSTER = """
            <h2>Related invoice &amp; payslip glossary</h2>
            <ul>
            <li><a href="/guides/glossary-tax-invoice">Tax invoice</a> · <a href="/guides/glossary-gst-invoice">GST invoice</a> · <a href="/guides/glossary-proforma-invoice">Proforma invoice</a></li>
            <li><a href="/guides/glossary-e-invoice">E-invoice</a> · <a href="/guides/glossary-qr-code-invoice">QR code invoice</a> · <a href="/guides/glossary-irn">IRN</a></li>
            <li><a href="/guides/glossary-payslip">Payslip</a> · <a href="/guides/glossary-salary-slip">Salary slip</a> · <a href="/guides/glossary-rent-receipt">Rent receipt</a></li>
            <li><a href="/guides/glossary-digital-signature-invoice">Digital signature on invoice</a> · <a href="/guides/glossary-digital-signature">Digital signature (PDF)</a></li>
            </ul>
            <p>Pillar: <a href="/guides/invoice-generator-guide">invoice generator guide</a> · Tool: <a href="/invoice/create">Create Invoice</a> · Compare: <a href="/compare">compare tools</a>.</p>
            """

W64_HAND_CORE_CLUSTER = """
            <h2>Related RatPDF pillar guides</h2>
            <ul>
            <li><a href="/guides/pdf-tools">PDF tools hub</a> · <a href="/guides/choose-pdf-tool">Choose a PDF tool</a></li>
            <li><a href="/guides/compress-pdf-guide">Compress PDF</a> · <a href="/guides/merge-pdf">Merge PDF</a> · <a href="/guides/ocr-pdf">OCR PDF</a></li>
            <li><a href="/guides/invoice-generator-guide">Invoice generator</a> · <a href="/guides/pdf-to-word">PDF to Word</a></li>
            </ul>
            <p>Research: <a href="/research/attachment-size-limits">attachment limits</a> · <a href="/research/pdf-compression-benchmark">compression benchmark</a>.</p>
            """

W64_CLOSING = """
            <h2>Summary &amp; next steps</h2>
            <p>Bookmark this page for vocabulary and workflow entry points — execute step-by-step tasks in the linked pillar guides. Upgrade volume limits: <a href="/Subscription/Plans">subscription plans</a>.</p>
            """
