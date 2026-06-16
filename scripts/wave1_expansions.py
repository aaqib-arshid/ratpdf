"""Long-form premium sections for Wave 1 guide bodies."""

COUNTRY_TOPUP = {
    "invoice-generator-france": """
            <h2>Facture proforma vs facture définitive</h2>
            <p>Proforma is not a tax document — once delivery is confirmed, reissue as définitive facture with TVA. Auto-entrepreneurs: verify franchise thresholds each year on impots.gouv.</p>
            """,
    "invoice-generator-germany": """
            <h2>Leistungszeitraum vs Rechnungsdatum</h2>
            <p>Leistungszeitraum must reflect when service occurred — important for VAT period allocation. Month-end accruals need correct period on Rechnung.</p>
            """,
    "invoice-generator-new-zealand": """
            <h2>Invoice vs tax invoice wording</h2>
            <p>Below GST registration threshold, issue "invoice" without GST line. Once registered, use "tax invoice" title for supplies over $50 where buyer claims credits.</p>
            """,
    "invoice-generator-philippines": """
            <h2>2307 certificates</h2>
            <p>Clients may withhold — your sales invoice still shows gross VATable amount; coordinate 2307 paperwork separately with accountant.</p>
            """,
    "invoice-generator-singapore": """
            <h2>Customer accounting for prescribed goods</h2>
            <p>Certain B2B supplies use customer accounting — invoice must state applicable IRAS wording; confirm with tax agent.</p>
            """,
    "invoice-generator-south-africa": """
            <h2>Tax invoice vs credit note numbering</h2>
            <p>Credit notes need separate sequence prefix (CN-) — do not reuse invoice numbers for credits.</p>
            """,
    "invoice-generator-uae": """
            <h2>Emirate-specific trade licences</h2>
            <p>Invoice address must match licence emirate — DMCC vs mainland Dubai entities differ for client VAT recovery.</p>
            """,
    "invoice-generator-uk": """
            <h2>CIS construction industry</h2>
            <p>Construction subcontractors may need CIS deduction shown — coordinate with HMRC CIS rules beyond standard VAT invoice.</p>
            """,
}

COUNTRY_EXPANSIONS = {
    "invoice-generator-australia": """
            <h2>When you must register for GST in Australia</h2>
            <p>Businesses must register for GST when turnover exceeds <strong>$75,000</strong> in a rolling 12-month period (or $150,000 for non-profit bodies). Below threshold you may still register voluntarily to claim credits on business purchases. Once registered, every tax invoice to another GST-registered business should show your <strong>ABN</strong> and a GST line at 10% unless the supply is GST-free (exports, some health/education) or input-taxed.</p>
            <p>ATO guidance: verify current thresholds on <a href="https://www.ato.gov.au/" rel="noopener noreferrer" target="_blank">ato.gov.au</a> before changing your template. Research: <a href="/research/freelancer-invoicing-statistics">freelancer invoicing statistics</a>.</p>

            <h2>B2B vs B2C tax invoices</h2>
            <p><strong>B2B:</strong> Client needs your ABN and GST amount to claim input tax credits in their BAS. Title the document "Tax Invoice" when GST applies.</p>
            <p><strong>B2C:</strong> Retail consumers rarely need a full tax invoice unless they request one within 28 days for purchases over $82.50 (GST inclusive). Freelancers billing consumers still benefit from clear PDFs for disputes.</p>

            <h2>Second example: Brisbane IT contractor — milestone billing</h2>
            <p><strong>Scenario:</strong> Fixed-price website rebuild, 40% deposit invoiced at kickoff, 60% at launch.</p>
            <ol>
            <li>Invoice #AU-2026-014 — "Milestone 1 — discovery &amp; wireframes" — $6,600 + $660 GST.</li>
            <li>Notes: "Pay within 14 days to BSB/account on file; PO #WEB-4412."</li>
            <li>At launch, Invoice #AU-2026-028 references the same PO — avoids duplicate GST reporting.</li>
            <li>Archive both PDFs for five-year ATO record-keeping.</li>
            </ol>

            <h2>Field-by-field reference</h2>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>Field</th><th>Why it matters</th></tr></thead>
            <tbody>
            <tr><td>ABN</td><td>Identifies supplier; required on tax invoices for GST credits</td></tr>
            <tr><td>Invoice date</td><td>Starts payment-term clock; BAS attribution</td></tr>
            <tr><td>Description</td><td>Must be specific enough for ATO audit — not "services"</td></tr>
            <tr><td>GST amount</td><td>Shown separately from GST-exclusive total</td></tr>
            <tr><td>Payment details</td><td>Reduces "wrong account" delays — include reference text</td></tr>
            </tbody>
            </table></div>

            <h2>BAS reconciliation workflow</h2>
            <p>Quarterly BAS filers map each issued tax invoice to <strong>G1 Total sales</strong> and <strong>1A GST on sales</strong>. Export a spreadsheet from your accounting tool (Xero, MYOB, QuickBooks) and match invoice numbers to RatPDF PDF filenames. If a client disputes GST, issue a credit note as a new PDF — do not overwrite sent invoices.</p>

            <h2>Payment terms and cash flow</h2>
            <p>Australian SMBs commonly use <strong>Net 14</strong> or <strong>Net 30</strong>. Under the <em>Payment Times Reporting Scheme</em>, large businesses report how quickly they pay small suppliers — naming clear terms on your PDF helps AP teams prioritise payment. Add: "Late payments may incur 1.5% monthly interest per contract clause 7."</p>

            <h2>Cross-border supplies from Australia</h2>
            <p>Exporting services to non-Australian clients may be GST-free if the client is outside Australia and certain conditions are met. State in Notes: "GST-free export of services — recipient outside Australia." Confirm with your tax agent — misclassification affects BAS.</p>

            <h2>After PDF generation — delivery checklist</h2>
            <ul>
            <li>Email PDF under 20 MB — if bundle is huge see <a href="/guides/compress-pdf-for-email">compress PDF for email</a></li>
            <li>Typo fix: regenerate; for client-supplied PDFs use <a href="/guides/pdf-to-word-invoice">PDF to Word for invoice</a></li>
            <li>Portal rejections: <a href="/guides/compress-gst-invoice-pdf">compress GST invoice PDF</a></li>
            </ul>

            <h2>FAQ — Australia invoicing</h2>
            <p><strong>Do I need a tax invoice for every job?</strong> Registered GST businesses need tax invoices for taxable supplies over $82.50 to other businesses claiming credits.</p>
            <p><strong>Can I invoice in USD from Australia?</strong> RatPDF supports multi-currency; GST treatment still follows Australian rules — document FX in Notes.</p>
            <p><strong>Free tier limits?</strong> Three Create Invoice uses per day — <a href="/Subscription/Plans">upgrade</a> for agency volume.</p>
            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Ready to issue your tax invoice?</strong> <a href="/invoice/create" class="alert-link fw-semibold">Create AUD invoice →</a></div>
            """,
    "invoice-generator-canada": """
            <h2>GST/HST registration thresholds in Canada</h2>
            <p>Small suppliers are generally not required to register for GST/HST until <strong>worldwide taxable supplies exceed $30,000</strong> in a single calendar quarter or over four consecutive quarters. Quebec QST has separate rules. Once registered, charge the rate for the <strong>place of supply</strong> — 5% GST in Alberta, 13% HST in Ontario, 15% in Nova Scotia, etc.</p>
            <p>CRA reference: <a href="https://www.canada.ca/en/revenue-agency.html" rel="noopener noreferrer" target="_blank">canada.ca/revenue-agency</a>.</p>

            <h2>Provincial tax on the same PDF</h2>
            <p>Some provinces use separate PST (BC, SK, MB) that may not appear on a federal GST/HST line. Note in invoice footer: "PST collected separately where applicable — confirm with provincial registry." B2B HST registrants in Ontario expect a clear HST registration number on the PDF.</p>

            <h2>Second example: Vancouver agency — bilingual client in Quebec</h2>
            <ol>
            <li>Invoice in CAD with English line items; add French service title in parentheses if contract requires.</li>
            <li>HST 13% if place of supply is Ontario client; GST 5% only for Alberta recipient.</li>
            <li>Include BN/GST number in header — client AP cannot process without it.</li>
            </ol>

            <h2>B2B ITC documentation</h2>
            <p>Buyers claiming input tax credits need supplier name, BN, invoice date, total, HST/GST amount, and your terms of payment. Missing BN is the top reason Canadian AP rejects PDFs.</p>

            <h2>Record retention</h2>
            <p>CRA requires keeping invoice records for <strong>six years</strong> from the end of the last tax year they relate to. Store RatPDF PDFs with immutable filenames; match to QuickBooks Online or Wave exports monthly.</p>

            <h2>Cross-border: billing U.S. clients from Canada</h2>
            <p>Zero-rated exports may apply for services performed for non-residents — document in Notes and confirm with accountant. See also <a href="/guides/invoice-generator-usa">invoice generator USA</a> for recipient expectations.</p>

            <h2>Payment terms</h2>
            <p>Net 30 is standard; federal <em>Prompt Payment Act</em> concepts influence large buyer behaviour. State interest on overdue accounts in Notes if your master service agreement allows.</p>

            <h2>Extended mistakes list</h2>
            <ul>
            <li>Charging Ontario HST on an Alberta place-of-supply invoice</li>
            <li>Using "estimate" header on a post-delivery bill</li>
            <li>Flattening PDF to image — breaks AP OCR ingestion</li>
            </ul>

            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Issue your CAD invoice now.</strong> <a href="/invoice/create" class="alert-link fw-semibold">Create invoice →</a></div>
            """,
    "invoice-generator-france": """
            <h2>Auto-entrepreneur vs SASU invoicing</h2>
            <p><strong>Micro-entrepreneurs</strong> under franchise en base may not charge TVA until thresholds are exceeded — state "TVA non applicable, art. 293 B du CGI" when applicable. <strong>SASU/EURL</strong> assujettis issue factures with TVA at 20% (or 10%/5.5% reduced rates for eligible supplies).</p>

            <h2>Mandatory facture fields (France)</h2>
            <p>Post-2026 reforms continue to emphasise sequential numbering, SIRET, TVA intracommunautaire for EU B2B, date of prestation, and détail des prestations. Verify on <a href="https://www.impots.gouv.fr/" rel="noopener noreferrer" target="_blank">impots.gouv.fr</a>.</p>

            <h2>Second example: Lyon consultant — EU B2B reverse charge</h2>
            <p>Client in Germany with valid USt-IdNr — invoice HT only with mention "Autoliquidation de la TVA — article 283-2 du CGI" and both TVA numbers. RatPDF Notes field carries the legal phrase; PDF remains in EUR.</p>

            <h2>Factur-X and e-invoicing horizon</h2>
            <p>France is expanding structured e-invoicing for B2B — PDF remains the human-readable copy many SMBs email today. Keep master data (SIRET, IBAN) consistent for future PDP integration.</p>

            <h2>Payment delays</h2>
            <p><em>Loi de modernisation de l'économie</em> caps B2B payment delays — state échéance clearly ("Paiement à 30 jours fin de mois"). Late penalties and indemnité forfaitaire de 40 € may apply — reference in Notes if your CGV include them.</p>

            <h2>Record keeping</h2>
            <p>Comptable expects chronological factures — no gaps in numbering. Archive PDF + journal entry each month.</p>

            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Créer une facture PDF</strong> <a href="/invoice/create" class="alert-link fw-semibold">Create EUR invoice →</a></div>
            """,
    "invoice-generator-germany": """
            <h2>Pflichtangaben auf Rechnungen (§ 14 UStG)</h2>
            <p>German invoices must include full supplier/recipient names and addresses, Steuernummer or USt-IdNr, Leistungsdatum, Leistungsbeschreibung, net and tax amounts, and Steuersatz. Kleinunternehmer under § 19 UStG omit USt but must include the statutory Hinweis.</p>

            <h2>Second example: Hamburg freelancer — §13b reverse charge Bauleistung</h2>
            <p>Construction-related services to another German business may trigger reverse charge — Rechnung ohne USt with text "Steuerschuldnerschaft des Leistungsempfängers §13b UStG." Confirm with Steuerberater before sending.</p>

            <h2>XRechnung / ZUGFeRD context</h2>
            <p>Public-sector buyers may require XRechnung XML — RatPDF PDF is the visual document SMBs use for private B2B email. Keep fields aligned for future e-invoice exports.</p>

            <h2>GoBD archiving</h2>
            <p>Tax-relevant records must be unchangeable, readable, and ordered — store PDFs with audit-proof naming; do not edit sent files.</p>

            <h2>Payment culture</h2>
            <p>Skonto (2% within 10 days) is common in Mittelstand contracts — show both Skonto and Zielbetrag in Notes if agreed.</p>

            <p>Compare tools: <a href="/compare">PDF &amp; business alternatives</a> · Research: <a href="/research/freelancer-invoicing-statistics">freelancer invoicing statistics</a>.</p>

            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Rechnung erstellen</strong> <a href="/invoice/create" class="alert-link fw-semibold">Create EUR invoice →</a></div>
            """,
    "invoice-generator-new-zealand": """
            <h2>NZ GST registration ($60,000 threshold)</h2>
            <p>Register within 21 days when turnover exceeds <strong>$60,000</strong> in 12 months. Tax invoices required for supplies over $50 when buyer claims GST credits.</p>

            <h2>IRD tax invoice requirements</h2>
            <p>Show supplier name and GST number, date, description, quantity, price, GST amount, total. IRD: <a href="https://www.ird.govt.nz/" rel="noopener noreferrer" target="_blank">ird.govt.nz</a>.</p>

            <h2>Second example: Christchurch tradie — progress claim</h2>
            <p>Residential renovation — invoice 50% materials + labour with clear GST line; attach job address in Notes for client property files.</p>

            <h2>BAS-style GST return mapping</h2>
            <p>Each PDF maps to Box 5 (sales) and Box 11 (GST collected) in myIR GST return — keep invoice numbers sequential.</p>

            <h2>Trans-Tasman billing</h2>
            <p>Services to Australian clients may be zero-rated — document recipient ABN in Notes; see <a href="/guides/invoice-generator-australia">Australia guide</a>.</p>

            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Create NZD tax invoice</strong> <a href="/invoice/create" class="alert-link fw-semibold">Create invoice →</a></div>
            """,
    "invoice-generator-philippines": """
            <h2>BIR registration and OR vs sales invoice</h2>
            <p>VAT-registered persons issue VAT sales invoices (not official receipts for goods sold on account). TIN and registered name must match BIR certificate.</p>

            <h2>Second example: Cebu BPO vendor — 12% VAT services</h2>
            <p>Monthly manpower invoice — VATable sales, VAT amount, total amount due; Notes include BIR ATP reference if applicable.</p>

            <h2>Withholding tax notes</h2>
            <p>Many B2B services trigger expanded withholding tax — state in Notes: "Subject to 2% EWT — client to withhold per BIR." Accountant confirms rate.</p>

            <h2>Record retention</h2>
            <p>Keep duplicate copies per BIR record-keeping rules — PDF archive on secure drive.</p>

            <p>BIR portal: <a href="https://www.bir.gov.ph/" rel="noopener noreferrer" target="_blank">bir.gov.ph</a>.</p>

            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Generate PHP VAT invoice PDF</strong> <a href="/invoice/create" class="alert-link fw-semibold">Create invoice →</a></div>
            """,
    "invoice-generator-singapore": """
            <h2>GST registration (S$1 million threshold)</h2>
            <p>Mandatory registration when taxable turnover exceeds <strong>S$1 million</strong> retrospectively or prospectively. Rate is 9% from 2024.</p>

            <h2>Tax invoice content (IRAS)</h2>
            <p>Invoice number, date, supplier name/UEN/GST reg no., description, GST rate and amount, total. IRAS e-tax guides apply.</p>

            <h2>Second example: fintech retainer — standard-rated services</h2>
            <p>S$8,500 monthly compliance support + S$765 GST — UEN in header; foreign client may need zero-rated treatment — confirm place of supply.</p>

            <h2>PEPPOL / InvoiceNow context</h2>
            <p>Government and large enterprise may require e-invoice networks — PDF remains common for SME B2B email.</p>

            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Create SGD invoice</strong> <a href="/invoice/create" class="alert-link fw-semibold">Create invoice →</a></div>
            """,
    "invoice-generator-south-africa": """
            <h2>VAT registration (R1 million in 12 months)</h2>
            <p>Voluntary registration above R50,000. Standard rate 15% — tax invoice required for VAT-registered vendor supplies.</p>

            <h2>SARS tax invoice fields</h2>
            <p>Supplier name/address/VAT number, serialised invoice number, date, description, value, VAT amount, total.</p>

            <h2>Second example: Cape Town dev shop — export services</h2>
            <p>UK client — zero-rated export of services may apply; Notes document foreign recipient; PDF in ZAR or USD per contract.</p>

            <h2>Payment terms and POPIA</h2>
            <p>Include client VAT number for B2B; avoid unnecessary personal data in PDF body.</p>

            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Create ZAR VAT invoice</strong> <a href="/invoice/create" class="alert-link fw-semibold">Create invoice →</a></div>
            """,
    "invoice-generator-uae": """
            <h2>UAE VAT (5%) — TRN on every B2B invoice</h2>
            <p>Tax Registration Number (TRN) mandatory for registered suppliers. FTA requires specific Arabic/English elements on tax invoices — verify latest FTA public clarifications.</p>

            <h2>Second example: Dubai consultancy — mainland client</h2>
            <p>AED 45,000 professional fees + AED 2,250 VAT — TRN, supply date, clear description of advisory scope.</p>

            <h2>Designated zones and exports</h2>
            <p>Supplies to designated zones or exports may be zero-rated — document in Notes; tax agent confirms.</p>

            <h2>Free zone vs mainland</h2>
            <p>Invoice legal entity name must match trade licence — mismatches block client VAT recovery.</p>

            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Create AED invoice</strong> <a href="/invoice/create" class="alert-link fw-semibold">Create invoice →</a></div>
            """,
    "invoice-generator-uk": """
            <h2>UK VAT registration (£90,000 threshold)</h2>
            <p>Register within 30 days of exceeding threshold. VAT invoices need unique number, time of supply, supplier/recipient details, VAT rate per line, total VAT.</p>

            <h2>Making Tax Digital (MTD)</h2>
            <p>VAT-registered businesses submit digital records to HMRC — PDF invoice is still what you email clients; accounting software holds digital links.</p>

            <h2>Second example: Manchester SaaS — reverse charge EU</h2>
            <p>B2B service to German business — may use reverse charge wording; GBP invoice with both VAT numbers in Notes.</p>

            <h2>Late payment (UK)</h2>
            <p>Late Payment of Commercial Debts interest may apply — state due date and bank sort code/account.</p>

            <p>HMRC: <a href="https://www.gov.uk/government/organisations/hm-revenue-customs" rel="noopener noreferrer" target="_blank">gov.uk/hmrc</a>.</p>

            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Create GBP VAT invoice</strong> <a href="/invoice/create" class="alert-link fw-semibold">Create invoice →</a></div>
            """,
}

BULK_GST_EXTRA = """
            <h2>Month-end automation without custom code</h2>
            <p>Finance teams often glue Tally/Zoho exports to RatPDF CSV with Excel <code>VLOOKUP</code> for GSTIN validation. Standardise invoice prefix per branch (<code>MUM-</code>, <code>BLR-</code>) so ZIP filenames sort correctly in client folders.</p>

            <h2>Error handling at scale</h2>
            <p>When one row fails GSTIN checksum, fix the row and re-run the batch — do not hand-edit PDFs. Use <a href="/gst-invoice-checker">GST invoice checker</a> on the corrected row before resending.</p>

            <h2>Credit notes and debit notes in bulk</h2>
            <p>Negative taxable values in CSV may be inappropriate — issue separate credit-note rows with new invoice numbers referencing original INV. Keeps GSTR-1 audit trail clean.</p>

            <h2>Security and client data</h2>
            <p>CSV contains GSTIN and amounts — upload over HTTPS only; delete local copies from Downloads after ZIP is archived on encrypted drive.</p>

            <h2>When bulk is wrong tool</h2>
            <p>One-off project invoices, mixed-currency clients, or e-invoice IRN-first workflows should use <a href="/invoice/create">Create Invoice</a> or NIC portal — see <a href="/guides/e-invoicing-india-pdf">e-invoicing India PDF</a>.</p>

            <h2>Extended FAQ</h2>
            <p><strong>How many PDFs per batch?</strong> Up to 100 on Business plan — split larger months into two uploads.</p>
            <p><strong>HSN mandatory?</strong> B2B supplies generally require HSN/SAC on tax invoices — bulk CSV is the right place for full codes.</p>
            <p><strong>Can I reuse last month's CSV?</strong> Yes — update dates, invoice numbers, and amounts only.</p>

            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Run your April GST batch</strong> <a href="/invoice/bulk" class="alert-link fw-semibold">Bulk GST invoices →</a></div>
            """

RECURRING_EXTRA = """
            <h2>Template discipline that saves 20 minutes per month</h2>
            <p>Save a master line-item description in Notes ("Monthly SEO retainer — [Month]") and only change the month token. Keep client legal name identical to contract — AP systems match exact strings.</p>

            <h2>Calendar reminders vs RatPDF</h2>
            <p>RatPDF does not schedule sends — use Google Calendar recurring event on billing day with link to <a href="/invoice/create">Create Invoice</a>. Copy previous PDF metadata from your ledger.</p>

            <h2>Multi-currency retainers</h2>
            <p>UK client billed in GBP, Indian GST entity billing in INR — separate templates per currency. Guides: <a href="/guides/invoice-generator-uk">UK</a> · <a href="/guides/invoice-generator-singapore">Singapore</a> · <a href="/guides/invoice-generator-australia">Australia</a>.</p>

            <h2>Escalation clauses</h2>
            <p>Annual 5% rate increases — update rate field on anniversary invoice; reference contract clause in Notes so client expects change.</p>

            <h2>Dunning without damaging relationship</h2>
            <p>Day 0: PDF invoice. Day 7: polite reminder with same PDF attached. Day 21: phone call before late fee. Never edit original PDF amounts — issue credit note if dispute.</p>

            <h2>Bulk CSV for identical retainers</h2>
            <p>48 clients at identical MRR — duplicate CSV rows, change GSTIN and amount per row — <a href="/guides/bulk-gst-invoice-generator">bulk GST guide</a>.</p>

            <h2>Research and benchmarks</h2>
            <p>Late payment costs SMBs billions annually — clear PDF terms improve collection speed (<a href="/research/freelancer-invoicing-statistics">freelancer invoicing statistics</a>).</p>

            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Bill this month's retainer</strong> <a href="/invoice/create" class="alert-link fw-semibold">Create invoice →</a></div>
            """

PDF_MAC_EXTRA = """
            <h2>Safari vs Chrome on macOS Sonoma/Ventura</h2>
            <p>Both work; Chrome sometimes handles larger uploads faster on Intel Macs. Apple Silicon Macs convert equally quickly — bottleneck is PDF complexity not chip.</p>

            <h2>Word for Mac vs Apple Pages</h2>
            <p>Word preserves more table structure from DOCX; Pages may reflow multi-column layouts. For legal edits, prefer Word track changes.</p>

            <h2>Offline airline / café workflow</h2>
            <p>Download DOCX before flight — edit offline in Word. Re-upload finished DOCX via <a href="/pdf/doctopdf">Word to PDF</a> when online.</p>

            <h2>Font substitution on Mac</h2>
            <p>Missing fonts trigger macOS substitution warnings — install corporate fonts or accept fallback for draft edits only.</p>

            <h2>Large files on MacBook</h2>
            <p>100+ page annual reports — split with <a href="/guides/split-pdf">split PDF</a> if upload times out; merge after per-section edits.</p>

            <h2>Privacy on shared Macs</h2>
            <p>Clear Downloads after sensitive contracts; RatPDF deletes server copies per retention policy — verify on privacy page.</p>

            <h2>Compare desktop apps</h2>
            <p>Adobe Acrobat subscription vs browser — <a href="/compare/adobe-alternative">Adobe alternative</a> · <a href="/compare/smallpdf-alternative">Smallpdf alternative</a>.</p>

            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Convert on Mac</strong> <a href="/pdf/pdftodoc" class="alert-link fw-semibold">PDF to Word →</a></div>
            """

PDF_FORMAT_EXTRA = """
            <h2>pdf2docx vs page-render fallback</h2>
            <p>RatPDF attempts structured extraction first — faster and preserves text as text. Fallback rasterises complex pages — you get editable image blocks instead of broken characters.</p>

            <h2>Font embedding diagnostics</h2>
            <p>In Adobe Reader: File → Properties → Fonts. "Embedded subset" with ToUnicode usually converts well; "(none)" on custom fonts may fail — ask sender for source DOCX.</p>

            <h2>Fixing tables in Word post-convert</h2>
            <ol>
            <li>Select table → Layout → AutoFit → Fixed column width</li>
            <li>Re-merge header cells that split incorrectly</li>
            <li>Reapply brand styles from corporate template</li>
            </ol>

            <h2>Headers, footers, and page numbers</h2>
            <p>Double-click header in Word — confirm section breaks match PDF page 1 start. Page numbers often land in footer — edit field codes if off-by-one.</p>

            <h2>Images and logos</h2>
            <p>Vector logos usually survive; photographed logos on scanned pages need <a href="/guides/scanned-pdf-to-word">OCR workflow</a> first.</p>

            <h2>When to ask for source file</h2>
            <p>If PDF is export of PowerPoint or InDesign, request PPTX/INDD — conversion is faster than fighting flattened PDF.</p>

            <h2>Re-export quality</h2>
            <p>After edits use <a href="/pdf/doctopdf">Word to PDF</a> — embed fonts on save for print shops.</p>

            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Convert with layout focus</strong> <a href="/pdf/pdftodoc" class="alert-link fw-semibold">PDF to Word →</a></div>
            """

PDF_SCANNED_EXTRA = """
            <h2>OCR engine and language packs</h2>
            <p>RatPDF OCR uses Tesseract — English is default; mixed-language contracts may need manual verification of accented characters.</p>

            <h2>Pre-OCR cleanup</h2>
            <p>Deskew crooked phone photos in Preview or Photos before upload — improves character confidence scores.</p>

            <h2>Multi-column newspaper scans</h2>
            <p>OCR reading order may jumble columns — expect manual paragraph reordering in Word for complex layouts.</p>

            <h2>Handwriting limits</h2>
            <p>Cursive signatures and margin notes are not reliably OCR'd — retype critical handwritten amendments.</p>

            <h2>Redacted documents</h2>
            <p>Black boxes are fine; ensure OCR runs on visible text only — redacted zones stay blank in Word.</p>

            <h2>Legal admissibility</h2>
            <p>Edited Word from signed scan is a working draft — retain original signed PDF as evidence; consult counsel for filings.</p>

            <h2>Batch scans</h2>
            <p>Combine TIFFs to PDF first — <a href="/guides/merge-pdf">merge PDF</a> — then single OCR pass.</p>

            <h2>Security</h2>
            <p>ID scans contain PII — delete local copies; use <a href="/guides/secure-pdf-workflow">secure PDF workflow</a> for sharing redacted exports.</p>

            <p>Research: <a href="/research/pdf-compression-benchmark">PDF compression benchmark</a> (OCR'd files grow — compress before email if needed).</p>

            <div class="rp-faq-cta alert alert-secondary my-4"><strong>OCR then convert</strong> <a href="/pdf/ocrpdf" class="alert-link fw-semibold">OCR PDF →</a> · <a href="/pdf/pdftodoc" class="alert-link fw-semibold">PDF to Word</a></div>
            """

BULK_GST_EXTRA_2 = """
            <h2>Tally export → RatPDF CSV mapping</h2>
            <p>Export sales register from TallyPrime with party GSTIN, taxable value, and tax split. Map column headers to RatPDF template — rename in Excel before upload. Keep invoice prefix consistent with Tally voucher numbers to simplify GSTR-1 reconciliation.</p>

            <h2>GSTR-1 filing alignment</h2>
            <p>Each PDF invoice number should appear in GSTR-1 Table 4B/6 with matching taxable value. Mismatches trigger GSTN notices — spot-check highest-value row every month.</p>

            <h2>Place of supply decision tree</h2>
            <ul>
            <li>Same state as supplier → CGST + SGST</li>
            <li>Other state (domestic) → IGST</li>
            <li>Export of services → zero-rated with LUT documentation in Notes</li>
            </ul>

            <h2>Client onboarding columns</h2>
            <p>Maintain master CSV of clients with GSTIN, place of supply, default HSN — merge into monthly billing CSV with <code>POWERQUERY</code> or VLOOKUP to reduce typos.</p>

            <h2>Post-batch client email</h2>
            <p>Do not attach 48 PDFs in one email — send one PDF per client email with invoice number in subject line "Tax Invoice INV-2026-041 — [Client Name]".</p>

            <h2>Audit trail for CAs</h2>
            <p>Store uploaded CSV + output ZIP + SHA checksum log. If client disputes HSN, you can reproduce exact PDF from archived CSV.</p>
            """

RECURRING_EXTRA_2 = """
            <h2>Stripe/PayPal vs PDF invoice</h2>
            <p>Payment links collect money; tax invoices are legal records. Even if client pays by card, issue PDF invoice for their books — reference transaction ID in Notes.</p>

            <h2>Pro-rated first month</h2>
            <p>Client starts mid-month — line item "Pro-rated retainer 14/30 April" with calculated amount; full month begins next cycle.</p>

            <h2>Pause and resume retainers</h2>
            <p>Client pauses two months — do not send zero invoices; resume numbering when work restarts to avoid gaps confusing auditors.</p>

            <h2>Agency white-label</h2>
            <p>Pro tier logo upload — invoice looks client-facing for agencies billing on behalf of brands; still show your legal entity as supplier.</p>

            <h2>Team workflow</h2>
            <p>Account manager drafts line items in shared doc; finance lead generates PDF Friday 4pm IST — separation of duties reduces billing errors.</p>
            """

PDF_MAC_EXTRA_2 = """
            <h2>macOS versions and Apple Silicon</h2>
            <p>Intel and M-series Macs use the same browser workflow. Rosetta is irrelevant — conversion is server-side.</p>

            <h2>iCloud Drive uploads</h2>
            <p>Download PDF from iCloud to local file before upload if browser sandbox blocks direct iCloud picker.</p>

            <h2>Automator and Shortcuts</h2>
            <p>Power users can Shortcut "open RatPDF PDF to Word" — still manual upload; no API on free tier.</p>

            <h2>Accessibility VoiceOver</h2>
            <p>Upload zone is keyboard-accessible; DOCX output works with VoiceOver in Word for Mac for low-vision edits.</p>

            <h2>University and EDU accounts</h2>
            <p>Students editing thesis PDFs — prefer digital PDF from publisher; scanned library chapters need OCR first.</p>
            """

PDF_FORMAT_EXTRA_2 = """
            <h2>Landscape vs portrait tables</h2>
            <p>Board packs often mix orientations — Word section breaks may need manual fix after convert.</p>

            <h2>Nested tables</h2>
            <p>ERP exports with tables inside tables — outer table converts; inner may flatten — rebuild inner in Word if critical.</p>

            <h2>Numbering and bullets</h2>
            <p>Legal clauses 1.1, 1.2 usually survive; custom bullet glyphs may map to standard discs.</p>

            <h2>Hyperlinks</h2>
            <p>Internal PDF links may become plain text URLs — re-hyperlink in Word before republishing.</p>

            <h2>Track changes workflow</h2>
            <p>Enable track changes before editing contract — legal reviewers see delta vs original PDF intent.</p>
            """

PDF_SCANNED_EXTRA_2 = """
            <h2>Fax-to-PDF legacy archives</h2>
            <p>Old fax PDFs are low resolution — re-scan originals if possible; OCR on fax artifacts produces garbled clauses.</p>

            <h2>Stamp and watermark interference</h2>
            <p>Diagonal "COPY" watermarks reduce OCR confidence — crop in Preview before OCR if legally allowed.</p>

            <h2>Password-protected scans</h2>
            <p>Remove password with <a href="/pdf/unlock">unlock PDF</a> before OCR — encrypted pages block text layer.</p>

            <h2>Comparison with Adobe Scan</h2>
            <p>Phone apps export image PDFs — same OCR pipeline applies; 300 DPI beats 72 DPI phone default.</p>

            <h2>Post-OCR full-text search</h2>
            <p>After OCR, archive searchable PDF in document management system before Word conversion — preserves search if Word version lost.</p>
            """

BULK_PREMIUM = """
            <h2>Month 1 implementation playbook</h2>
            <p>Week 1: download CSV template, map three pilot clients. Week 2: run 3-row test batch, validate with GST checker. Week 3: train AP colleague on ZIP extraction. Week 4: full client roster upload. Document lessons — wrong place_of_supply code is the most common first-month error.</p>

            <h2>HSN/SAC reference workflow</h2>
            <p>Maintain internal table: service type → SAC code → default description text. CA firms offering audit + advisory use different SAC rows — never combine on one line if rates differ.</p>

            <h2>Amendments and debit notes</h2>
            <p>Undercharged GST on sent invoice? Issue debit note row in next CSV with new invoice number — reference original in description. Do not re-upload corrected row with same invoice_no.</p>

            <h2>Client communication template</h2>
            <p>Email body: "Please find attached GST tax invoice for [month] services. Invoice number [X] for your GSTR-2B reconciliation." Reduces AP back-and-forth.</p>

            <h2>Disaster recovery</h2>
            <p>Keep CSV source of truth — if laptop dies, regenerate ZIP from same CSV. PDFs alone without CSV cannot be bulk-regenerated with identical field mapping.</p>

            <h2>RatPDF Business plan ROI</h2>
            <p>Manual invoice creation at 10 minutes × 50 clients = 500 minutes monthly. Bulk batch under 15 minutes including QA — upgrade pays for itself in first month for active CAs.</p>

            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Questions before first batch?</strong> Start with <a href="/guides/invoice-generator-india">India invoice guide</a> then <a href="/invoice/bulk" class="alert-link fw-semibold">open bulk tool →</a></div>
            """

BULK_PREMIUM_2 = """
            <h2>Row-level validation script (Excel)</h2>
            <p>Before upload, add Excel formula column: <code>=LEN(customer_gstin)=15</code> and flag FALSE rows. Second formula checks invoice_no uniqueness with <code>COUNTIF</code>. Five minutes of validation prevents hour-long client apology emails.</p>

            <h2>Mixed B2B and B2C in one month</h2>
            <p>Split into two CSV uploads — B2C rows may omit customer_gstin but need different HSN treatment. Mixing in one file causes checker failures.</p>

            <h2>Logo and branding at bulk scale</h2>
            <p>Business plan logo applies uniformly — ensure contrast works on B&amp;W client printers. Test print one PDF before mass send.</p>

            <h2>Post-upload support</h2>
            <p>If ZIP missing one PDF, re-run only failed rows in mini-CSV — do not regenerate entire month unnecessarily.</p>

            <h2>Working with auditors</h2>
            <p>Statutory auditors request invoice serial continuity — export CSV used for each batch with timestamp. Auditors match PDF GSTIN to 2B — explain any credit notes in separate memo.</p>

            <h2>Scaling beyond 100 rows</h2>
            <p>Split into two batches by client region — North vs South — so QA teams can parallelise review. Same invoice number prefix must not collide across batches.</p>

            <h2>Integration with GSTR-3B</h2>
            <p>Output tax from bulk PDFs must reconcile to 3B table 3.1 — finance lead signs off before filing. Keep CSV as source for any amendment returns.</p>
            """

RECURRING_PREMIUM_3 = """
            <h2>Template library per client tier</h2>
            <p>Enterprise clients: Net 45, PO required, GSTIN on file. SMB clients: Net 14, no PO. Maintain two Create Invoice mental templates — wrong terms slow enterprise AP.</p>

            <h2>Multi-entity suppliers</h2>
            <p>You bill from Entity A for some clients and Entity B for others — never mix on one PDF; each entity has separate invoice sequence and bank account in Notes.</p>

            <h2>Annual contracts billed monthly</h2>
            <p>12-month MSA with monthly fees — each PDF references MSA date and section 2.1; avoids "this invoice is unexpected" disputes in month 7.</p>

            <h2>KPI dashboard</h2>
            <p>Track: invoices sent on time %, average days to pay, credit notes issued. Improving on-time billing from 80% to 95% often beats chasing late payers.</p>

            <h2>Tool links</h2>
            <p><a href="/invoice/create">Create Invoice</a> · <a href="/guides/invoice-generator-india">India GST</a> · <a href="/guides/invoice-generator-guide">Pillar guide</a> · <a href="/compare">Compare alternatives</a></p>
            """

RECURRING_PREMIUM_2 = """
            <h2>Quarterly vs monthly cadence</h2>
            <p>Some clients prefer quarterly billing — invoice covers three months in one line or three sub-lines; GST returns still need correct tax period attribution per accountant advice.</p>

            <h2>Currency fluctuation clauses</h2>
            <p>USD retainer billed from India — note FX rate source and date each month; client treasury teams audit consistency.</p>

            <h2>Holiday calendar adjustments</h2>
            <p>Billing on 31st when AP is closed — send on 28th with Notes "Due Net 30 from receipt" to avoid artificial delays.</p>

            <h2>Client offboarding</h2>
            <p>Final partial month — pro-rate line, mark "Final invoice" in Notes, close PO in buyer system.</p>

            <h2>Playbook: 20 global retainers</h2>
            <p>Spreadsheet columns: Client, Currency, Tax rate, Last INV #, Next billing date. Filter due this week → generate PDFs in one session. AU/UK/SG guides for tax fields: <a href="/guides/invoice-generator-australia">Australia</a> · <a href="/guides/invoice-generator-uk">UK</a> · <a href="/guides/invoice-generator-singapore">Singapore</a>.</p>

            <h2>Failed payment follow-up</h2>
            <p>Do not reissue with new number until credit period clears — attach original PDF to reminder emails. Payment plan? Split into two invoices with explicit schedule in Notes.</p>

            <h2>Internal approval chain</h2>
            <p>Agencies: account lead approves hours → finance generates PDF → partner sends. Three-step reduces billing before delivery completes.</p>
            """

PDF_PAGE_PREMIUM = """
            <h2>Batch conversion hygiene</h2>
            <p>Converting 20 contracts? Use consistent naming <code>ClientName-contract-v1.docx</code>. Log source PDF hash if legal audit trail required.</p>

            <h2>Mobile upload caveats</h2>
            <p>Phone browsers work but large PDFs may timeout on cellular — use Wi-Fi or desktop for 50+ MB files.</p>

            <h2>Antivirus false positives</h2>
            <p>Some corporate proxies scan uploads — if blocked, try guest network or contact IT to allowlist ratpdf.com tool path.</p>

            <h2>Long-term archival</h2>
            <p>Store both source PDF and final DOCX/PDF pair — migrations sometimes need to re-edit decade-old contracts.</p>

            <h2>Regulatory and compliance edits</h2>
            <p>Privacy policies, SOC2 reports, and vendor security questionnaires arrive as PDF — convert to Word for comment, return PDF via <a href="/pdf/doctopdf">Word to PDF</a>. Legal should review material compliance wording changes.</p>

            <h2>Performance expectations</h2>
            <p>10-page digital PDF typically converts under two minutes; 200-page annual report may take longer — do not close tab during processing. Refresh only after timeout message.</p>
            """

PDF_FINAL_BOOST = """
            <h2>Document type quick reference</h2>
            <p><strong>Contracts:</strong> digital PDF, track changes in Word. <strong>Invoices:</strong> table-heavy — check sums. <strong>Scanned forms:</strong> OCR first. <strong>Marketing PDFs:</strong> expect image blocks. <strong>Manuals:</strong> headings usually survive — update TOC in Word after edits.</p>
            <p>Upgrade for volume: <a href="/Subscription/Plans">subscription plans</a>. Pillar: <a href="/guides/pdf-to-word">PDF to Word</a>.</p>

            <h2>Stakeholder sign-off matrix</h2>
            <p>Legal reviews converted contracts; finance reviews invoice PDFs edited in Word; HR reviews offer letters. Route DOCX to the right reviewer before re-PDF. Version suffix in filename (<code>-legal-reviewed</code>) prevents accidental send of draft.</p>
            <p>After major edits, compress before email if DOCX re-export exceeds mailbox limits — see <a href="/research/pdf-compression-benchmark">PDF compression benchmark</a> for quality settings.</p>
            <p>Bookmark this page for your team's wiki — consistent PDF-to-Word steps reduce support tickets when onboarding new staff each quarter.</p>
            """

RECURRING_FINAL = """
            <h2>Closing the monthly billing loop</h2>
            <p>Generate PDF → send → log payment date → reconcile bank feed → mark row paid in spreadsheet. Missing any step causes duplicate sends or missed revenue recognition. RatPDF handles PDF generation; your discipline handles the loop.</p>
            <p>Compare: <a href="/compare">alternatives</a> · Research: <a href="/research/freelancer-invoicing-statistics">freelancer invoicing statistics</a> · Tool: <a href="/invoice/create">Create Invoice</a>.</p>
            <p>High-volume retainers eventually migrate to <a href="/guides/bulk-gst-invoice-generator">bulk GST CSV</a> when Indian GST fields are required on every row — until then, single Create Invoice keeps workflow simple.</p>
            <p>Upgrade prompt: free tier covers light retainers; Pro removes daily caps — <a href="/Subscription/Plans">compare plans</a>.</p>
            <p>Document your billing SOP so substitutes can issue PDFs when you are on leave — same Create Invoice fields, same filename pattern, same AP contact every month. Consistency beats speed when tax IDs are involved.</p>
            """

RECURRING_PREMIUM = """
            <h2>SaaS-style manual billing without Stripe Invoicing</h2>
            <p>Bootstrapped SaaS on manual bank transfer still needs PDF tax invoices for buyer VAT/GST. Each month: export active subscriber list, filter by plan tier, generate one PDF per customer with MRR line item.</p>

            <h2>Seat-based expansion revenue</h2>
            <p>Client adds 5 seats mid-cycle — pro-rate with separate line "Additional seats 12–31 March" on same month's PDF or separate supplemental invoice — accountant decides.</p>

            <h2>Non-profit and grant retainers</h2>
            <p>Grant-funded projects need PO and grant ID in Notes — AP audits match grant reports to invoice PDFs years later.</p>

            <h2>Legal retainer trust accounting</h2>
            <p>Law firms split trust vs operating — this guide covers operating invoices; trust transfers follow bar rules separately.</p>

            <h2>Freelance platforms vs direct clients</h2>
            <p>Upwork/Fiverr handles some billing — direct clients still need your PDF for their books. Keep templates separate to avoid double-billing.</p>

            <h2>Automation boundary</h2>
            <p>RatPDF will not auto-email on schedule — intentional for compliance: you review each PDF before send. Pair with calendar + checklist until volume justifies bulk CSV.</p>

            <h2>Metrics to track</h2>
            <p>Days sales outstanding (DSO) per client — if Client A averages 45 days, tighten terms in renewal. Research: <a href="/research/freelancer-invoicing-statistics">freelancer invoicing statistics</a>.</p>

            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Bill retainers faster</strong> <a href="/invoice/create" class="alert-link fw-semibold">Create invoice →</a> · <a href="/guides/bulk-gst-invoice-generator">bulk GST</a></div>
            """

PDF_CLUSTER_PREMIUM = """
            <h2>Enterprise document workflows</h2>
            <p>Legal ops teams convert legacy contract PDFs during CLM migration — batch convert critical folders, prioritise active vendor agreements first. IT should approve browser upload policy for confidential docs.</p>

            <h2>Education sector</h2>
            <p>Faculty edit syllabus PDFs each semester — digital university PDFs convert cleanly; scanned course packs need OCR. Check campus IT data handling before upload.</p>

            <h2>Real estate</h2>
            <p>Lease amendments stored as PDF — convert to Word for redline, re-PDF for signature. Keep executed scan archived separately from working DOCX.</p>

            <h2>HR and offer letters</h2>
            <p>Template offer PDFs with merge fields sometimes break on convert — edit boilerplate in Word template instead of converting each hire if HRIS exports PDF.</p>

            <h2>Government RFP responses</h2>
            <p>Final submissions often must be PDF — use Word only for draft edits, export via <a href="/pdf/doctopdf">Word to PDF</a> for portal upload. Check RFP forbids track changes in submission.</p>

            <h2>Quality gates before client delivery</h2>
            <ol>
            <li>Spell-check in Word</li>
            <li>Compare page count vs source PDF</li>
            <li>Verify critical numbers (dates, amounts) unchanged</li>
            <li>Remove comments and track changes</li>
            <li>Export final PDF if deliverable format is PDF</li>
            </ol>

            <p>Pillar: <a href="/guides/pdf-to-word">PDF to Word guide</a> · Compare: <a href="/compare/smallpdf-alternative">Smallpdf alternative</a></p>
            """

