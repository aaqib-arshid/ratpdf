namespace ratpdf.Content
{
    /// <summary>Wave 1 premium guide bodies — manual upgrade tier (SEO audit).</summary>
    internal static class GuideBodiesWave1
    {
        public static string? Get(string slug) => slug switch
        {
            "invoice-generator-australia" => InvoiceGeneratorAustralia,
            "invoice-generator-canada" => InvoiceGeneratorCanada,
            "invoice-generator-france" => InvoiceGeneratorFrance,
            "invoice-generator-germany" => InvoiceGeneratorGermany,
            "invoice-generator-new-zealand" => InvoiceGeneratorNewZealand,
            "invoice-generator-philippines" => InvoiceGeneratorPhilippines,
            "invoice-generator-singapore" => InvoiceGeneratorSingapore,
            "invoice-generator-south-africa" => InvoiceGeneratorSouthAfrica,
            "invoice-generator-uae" => InvoiceGeneratorUae,
            "invoice-generator-uk" => InvoiceGeneratorUk,
            "bulk-gst-invoice-generator" => BulkGstInvoiceGenerator,
            "recurring-invoice-generator" => RecurringInvoiceGenerator,
            "pdf-to-word-mac" => PdfToWordMac,
            "pdf-to-word-keep-formatting" => PdfToWordKeepFormatting,
            "scanned-pdf-to-word" => ScannedPdfToWord,
            _ => null
        };

        private const string InvoiceGeneratorAustralia = """
            <h2>Australia tax invoices for freelancers and SMBs</h2>
            <p>Businesses in Australia need clear PDF tax invoices that clients and accountants can file without rework. RatPDF's <a href="/invoice/create">Create Invoice</a> tool produces print-ready PDFs in <strong>AUD</strong> with configurable tax lines — no desktop software install.</p>
            <p>This guide covers mandatory fields per ATO expectations, a real-world example, and how to avoid the template mistakes that delay payment.</p>

            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> RatPDF Create Invoice form with AUD currency and GST 10% line items</figcaption></figure>

            <h2>Real example: Sydney design studio billing a Melbourne client $4,400 AUD + GST</h2>
            <p><strong>Scenario:</strong> You delivered a fixed-scope project. The client needs a PDF tax invoice before accounts payable runs Friday.</p>
            <ol>
            <li>Open <a href="/invoice/create">Create Invoice</a> — set currency to <strong>AUD</strong>.</li>
            <li><strong>From:</strong> legal business name, address, ABN in the header block.</li>
            <li><strong>Bill to:</strong> client legal name and address (add their tax ID for B2B).</li>
            <li><strong>Line items:</strong> "Phase 1 — design delivery" · qty 1 · rate matching contract.</li>
            <li><strong>Tax:</strong> set tax name to GST/VAT/TVA/USt as applicable — rate <strong>GST 10%</strong> when registered.</li>
            <li><strong>Notes:</strong> payment terms (Net 14), bank details, PO number if provided.</li>
            <li>Click <strong>Generate PDF</strong> — email the PDF; archive a copy for ATO records.</li>
            </ol>

            <div class="rp-mid-cta alert alert-primary my-4"><strong>Issue your next AUD invoice in under two minutes</strong> <a href="/invoice/create" class="alert-link fw-semibold">Create invoice free →</a></div>

            <h2>Mandatory fields checklist (ATO)</h2>
            <p>Tax invoice requirements evolve — verify on <a href="https://www.ato.gov.au/" rel="noopener noreferrer" target="_blank">ATO</a> before changing templates. Commonly required:</p>
            <ul>
            <li>ABN, invoice date, description, GST amount, seller identity</li>
            <li>Unique sequential invoice number (no gaps if your regime requires continuity)</li>
            <li>Clear description of goods or services supplied</li>
            <li>Taxable amount and tax charged separately</li>
            <li>Supplier identity sufficient for the client to claim input credits</li>
            </ul>

            <h2>When to use bulk CSV instead</h2>
            <p>Issuing more than ~10 similar invoices per month? Use <a href="/invoice/bulk">Bulk GST Invoice Generator</a> (Business plan) with GSTIN/HSN-style columns adapted for your jurisdiction — or continue single invoices if volume is low.</p>
            <p>India-specific bulk workflow: <a href="/guides/bulk-gst-invoice-generator">bulk GST invoice guide</a>. Global recurring retainers: <a href="/guides/recurring-invoice-generator">recurring invoice generator</a>.</p>

            <h2>After you generate the PDF</h2>
            <ul>
            <li><strong>Email size limits</strong> — rare for invoices, but if over 25 MB see <a href="/research/attachment-size-limits">attachment size limits research</a>.</li>
            <li><strong>Edit a typo</strong> — regenerate from source data; for client PDFs use <a href="/guides/pdf-to-word-invoice">PDF to Word for invoice</a>.</li>
            <li><strong>Compress before portal upload</strong> — <a href="/guides/compress-gst-invoice-pdf">compress GST invoice PDF</a> if a government portal rejects size.</li>
            </ul>

            <h2>Common mistakes</h2>
            <ul>
            <li>Using a quote layout instead of a tax invoice title when registered for VAT/GST</li>
            <li>Missing ABN on B2B invoices — client cannot reclaim tax</li>
            <li>Wrong tax rate for mixed supplies — split line items when rates differ</li>
            <li>PDF only in image form (flattened scan) — always send the vector PDF from RatPDF</li>
            </ul>

            <h2>Upgrade prompt</h2>
            <p>Free tier: 3 uses per tool per day. High-volume Australia agencies upgrade to Pro for logo upload, larger files, and unlimited daily use — <a href="/Subscription/Plans">compare plans</a> · <a href="/compare">tool alternatives</a>.</p>

            
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
            

            

            
            <h2>Choosing invoice layout for Australia clients</h2>
            <p>Accounts payable teams in Australia reject PDFs that look like marketing flyers. Use a single-column layout: legal names at top, line items in a table, tax breakdown before total, payment instructions in Notes. RatPDF's default PDF is optimised for printing and email — not screen-only quotes.</p>
            <p>If your client uses SAP, Oracle, or Xero AP automation, they may OCR your PDF — keep ABN in plain text (not inside a logo image) so extraction succeeds.</p>

            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> Printed AUD tax invoice with GST 10% breakdown and ABN in header</figcaption></figure>

            <h2>Third example: mixed tax rates on one invoice</h2>
            <p><strong>Scenario:</strong> You bill consulting (GST 10%) plus reimbursable travel (often zero-rated or out of scope depending on rules).</p>
            <ol>
            <li>Line 1 — "Strategy workshop" — taxable at standard rate.</li>
            <li>Line 2 — "Client-approved airfare reimbursement" — separate line, zero tax if documented as disbursement per ATO guidance.</li>
            <li>Notes cite client approval email date — protects you in audit.</li>
            <li>Total shows tax only on taxable lines — client can reconcile to contract.</li>
            </ol>
            <p>When unsure, ask your accountant before sending — amended invoices waste AP time.</p>

            <h2>Freelancer vs registered company letterhead</h2>
            <p><strong>Sole traders</strong> use personal trading name + ABN where applicable. <strong>Companies</strong> use registered legal entity (Ltd/GmbH/SASU) — mismatch with bank account name delays payment. Match the name on your RatPDF "From" block to the account clients pay.</p>

            <h2>Currency and FX (AUD)</h2>
            <p>Domestic clients expect AUD. If contract is USD/EUR but you are Australia-registered, show AUD equivalent in Notes with FX rate and date source ("ECB rate 2026-04-01") so finance can verify.</p>
            <p>Cross-reference: <a href="/guides/invoice-generator-usa">USA invoices</a> · <a href="/guides/invoice-generator-india">India GST invoices</a> · <a href="/guides/invoice-generator-new-zealand">New Zealand invoices</a>.</p>

            <h2>Deposit and progress invoices</h2>
            <p>Large projects split across multiple PDFs — each needs unique invoice number and clear scope reference ("Phase 2 of 4 — API integration"). Never duplicate invoice numbers; ATO audits trace sequences.</p>
            <p>For retainers duplicated monthly see <a href="/guides/recurring-invoice-generator">recurring invoice generator</a>.</p>

            <h2>Credit notes and refunds</h2>
            <p>Issue a new PDF credit note referencing original invoice number — negative amounts or explicit "Credit" title per local practice. Do not edit a PDF already booked in client ERP.</p>

            <h2>Email delivery and size</h2>
            <p>Vector PDFs from RatPDF are usually under 500 KB. Bundling 20 invoices? Zip locally or use bulk workflow. Over 25 MB combined triggers <a href="/research/attachment-size-limits">email attachment limits</a> — rare for single invoices.</p>

            <h2>Editing after send</h2>
            <p>Typo in description? Regenerate corrected PDF with new number if original was already accepted. For third-party PDFs use <a href="/guides/pdf-to-word-invoice">PDF to Word for invoice</a> — not ideal for tax fields; prefer reissue from Create Invoice.</p>

            <h2>Industry notes</h2>
            <h3>Creative agencies</h3>
            <p>Bill concepts and revisions as separate lines — avoids "one line for everything" disputes.</p>
            <h3>IT contractors</h3>
            <p>Reference SOW ticket IDs in description — client procurement matches PO lines.</p>
            <h3>Trades and field services</h3>
            <p>Include job site or project code in Notes — residential clients file by property address.</p>

            <h2>Year-end and accountant handoff</h2>
            <p>Export folder of PDFs by tax year; your accountant ties each to bank deposits. Missing ABN on B2B PDFs is a common reason year-end adjustments get delayed.</p>

            <h2>RatPDF vs desktop invoice software</h2>
            <p>Desktop tools need installs and licence seats. RatPDF runs in browser — three free uses per tool per day, Pro for agencies. Compare: <a href="/compare">tool alternatives</a>. Research: <a href="/research/freelancer-invoicing-statistics">freelancer invoicing statistics</a>.</p>

            <h2>Pre-send checklist (Australia)</h2>
            <ol>
            <li>ABN visible and correct</li>
            <li>Tax rate matches supply type (GST 10%)</li>
            <li>Client legal name matches contract</li>
            <li>Invoice number unique and sequential</li>
            <li>Payment terms and bank details in Notes</li>
            <li>PDF opens and prints — not a flattened phone photo</li>
            </ol>

            <h2>Local compliance reminders (ATO)</h2>
            <p>Tax law changes — digital service reporting, e-invoicing pilots, and reverse-charge categories — can alter what must appear on your PDF. Bookmark <a href="https://www.ato.gov.au/" rel="noopener noreferrer" target="_blank">ATO</a> and review templates each financial year. Your accountant should approve wording for reverse charge, export, and exempt supplies before you bulk-send to enterprise clients.</p>
            <p>Peer guide for neighbouring workflows: <a href="/guides/invoice-generator-new-zealand">New Zealand</a>. Pillar: <a href="/guides/invoice-generator-guide">invoice generator guide</a>.</p>

            <h2>Disputes and chargebacks</h2>
            <p>When a client disputes hours or deliverables, your PDF invoice is the billing record — not Slack threads. Keep scope references in line descriptions so dispute resolution references the same text AP already approved. Reissue credit notes rather than editing sent PDFs.</p>

            <h2>Archiving PDFs for audits</h2>
            <p>Use immutable filenames: <code>YYYY-MM-DD_INV-number_client.pdf</code>. Store on encrypted backup; ATO may request invoices years after issuance. RatPDF does not replace accounting ledgers — export totals to your GL monthly.</p>
            

            
            <h2>Payment method block on PDF</h2>
            <p>Include BSB/routing/IBAN, account name, and reference text ("Quote invoice number"). Clients paying via wire need exact match to your bank KYC name — a common delay when freelancers use trading names on invoice but personal name on account.</p>

            <h2>Purchase order matching</h2>
            <p>Enterprise AP matches PO line to invoice line. Copy PO number from buyer portal into Notes; if PO shows quantity 1 at $5,000 do not split across two lines unless PO allows.</p>

            <h2>Sales tax vs withholding</h2>
            <p>GST 10% on invoice is not the same as income tax withholding. Cross-border B2B may have treaty withholding — accountant handles; invoice shows gross fee per contract.</p>

            <h2>Recurring vs milestone billing</h2>
            <p>Retainers use same description monthly (<a href="/guides/recurring-invoice-generator">recurring guide</a>). Projects use milestone labels — do not mix on one PDF.</p>

            <h2>White-label and agency billing</h2>
            <p>Agencies billing end-client through intermediary still show supplier as your legal entity — Pro logo is cosmetic; tax ID remains yours.</p>

            <h2>PDF accessibility</h2>
            <p>Vector PDFs from RatPDF are searchable — clients with document management systems index ABN and totals automatically. Flattened JPEG invoices break OCR AP pipelines.</p>

            <h2>Version control</h2>
            <p>Filename suffix <code>-v2</code> only for drafts never sent. Sent invoices get new numbers, not version bumps.</p>

            <h2>Integration checklist with accountant</h2>
            <ol>
            <li>Confirm tax rate list for your supplies</li>
            <li>Approve invoice number format before first send</li>
            <li>Map RatPDF PDF folder to GL import monthly</li>
            <li>Review one sample PDF before bulk client rollout</li>
            </ol>
            

            
            <h2>Related guides &amp; cluster links</h2>
            <ul>
            <li><a href="/guides/invoice-generator-guide">Invoice generator guide</a></li>
            <li><a href="/guides/invoice-generator-india">Invoice generator India</a></li>
            <li><a href="/guides/invoice-generator-usa">Invoice generator USA</a></li>
            <li><a href="/guides/recurring-invoice-generator">Recurring invoice generator</a></li>
            </ul>
            <p>Research: <a href="/research/freelancer-invoicing-statistics">Freelancer invoicing statistics</a> · Compare: <a href="/compare">PDF &amp; business tool alternatives</a></p>
            <p class="mt-4"><a href="/invoice/create" class="btn btn-primary">Create AUD invoice</a></p>
            """;

        private const string InvoiceGeneratorCanada = """
            <h2>Canada tax invoices for freelancers and SMBs</h2>
            <p>Businesses in Canada need clear PDF tax invoices that clients and accountants can file without rework. RatPDF's <a href="/invoice/create">Create Invoice</a> tool produces print-ready PDFs in <strong>CAD</strong> with configurable tax lines — no desktop software install.</p>
            <p>This guide covers mandatory fields per CRA expectations, a real-world example, and how to avoid the template mistakes that delay payment.</p>

            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> RatPDF Create Invoice form with CAD currency and GST/HST (5–15% by province) line items</figcaption></figure>

            <h2>Real example: Toronto consultant invoicing an Alberta client in CAD with 5% GST</h2>
            <p><strong>Scenario:</strong> You delivered a fixed-scope project. The client needs a PDF tax invoice before accounts payable runs Friday.</p>
            <ol>
            <li>Open <a href="/invoice/create">Create Invoice</a> — set currency to <strong>CAD</strong>.</li>
            <li><strong>From:</strong> legal business name, address, BN/GST number in the header block.</li>
            <li><strong>Bill to:</strong> client legal name and address (add their tax ID for B2B).</li>
            <li><strong>Line items:</strong> "Phase 1 — design delivery" · qty 1 · rate matching contract.</li>
            <li><strong>Tax:</strong> set tax name to GST/VAT/TVA/USt as applicable — rate <strong>GST/HST (5–15% by province)</strong> when registered.</li>
            <li><strong>Notes:</strong> payment terms (Net 14), bank details, PO number if provided.</li>
            <li>Click <strong>Generate PDF</strong> — email the PDF; archive a copy for CRA records.</li>
            </ol>

            <div class="rp-mid-cta alert alert-primary my-4"><strong>Issue your next CAD invoice in under two minutes</strong> <a href="/invoice/create" class="alert-link fw-semibold">Create invoice free →</a></div>

            <h2>Mandatory fields checklist (CRA)</h2>
            <p>Tax invoice requirements evolve — verify on <a href="https://www.canada.ca/en/revenue-agency.html" rel="noopener noreferrer" target="_blank">CRA</a> before changing templates. Commonly required:</p>
            <ul>
            <li>Business number, HST/GST line, place of supply, bilingual labels if Quebec</li>
            <li>Unique sequential invoice number (no gaps if your regime requires continuity)</li>
            <li>Clear description of goods or services supplied</li>
            <li>Taxable amount and tax charged separately</li>
            <li>Supplier identity sufficient for the client to claim input credits</li>
            </ul>

            <h2>When to use bulk CSV instead</h2>
            <p>Issuing more than ~10 similar invoices per month? Use <a href="/invoice/bulk">Bulk GST Invoice Generator</a> (Business plan) with GSTIN/HSN-style columns adapted for your jurisdiction — or continue single invoices if volume is low.</p>
            <p>India-specific bulk workflow: <a href="/guides/bulk-gst-invoice-generator">bulk GST invoice guide</a>. Global recurring retainers: <a href="/guides/recurring-invoice-generator">recurring invoice generator</a>.</p>

            <h2>After you generate the PDF</h2>
            <ul>
            <li><strong>Email size limits</strong> — rare for invoices, but if over 25 MB see <a href="/research/attachment-size-limits">attachment size limits research</a>.</li>
            <li><strong>Edit a typo</strong> — regenerate from source data; for client PDFs use <a href="/guides/pdf-to-word-invoice">PDF to Word for invoice</a>.</li>
            <li><strong>Compress before portal upload</strong> — <a href="/guides/compress-gst-invoice-pdf">compress GST invoice PDF</a> if a government portal rejects size.</li>
            </ul>

            <h2>Common mistakes</h2>
            <ul>
            <li>Using a quote layout instead of a tax invoice title when registered for VAT/GST</li>
            <li>Missing BN/GST number on B2B invoices — client cannot reclaim tax</li>
            <li>Wrong tax rate for mixed supplies — split line items when rates differ</li>
            <li>PDF only in image form (flattened scan) — always send the vector PDF from RatPDF</li>
            </ul>

            <h2>Upgrade prompt</h2>
            <p>Free tier: 3 uses per tool per day. High-volume Canada agencies upgrade to Pro for logo upload, larger files, and unlimited daily use — <a href="/Subscription/Plans">compare plans</a> · <a href="/compare">tool alternatives</a>.</p>

            
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
            

            

            
            <h2>Choosing invoice layout for Canada clients</h2>
            <p>Accounts payable teams in Canada reject PDFs that look like marketing flyers. Use a single-column layout: legal names at top, line items in a table, tax breakdown before total, payment instructions in Notes. RatPDF's default PDF is optimised for printing and email — not screen-only quotes.</p>
            <p>If your client uses SAP, Oracle, or Xero AP automation, they may OCR your PDF — keep BN/GST number in plain text (not inside a logo image) so extraction succeeds.</p>

            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> Printed CAD tax invoice with GST/HST (5–15% by province) breakdown and BN/GST number in header</figcaption></figure>

            <h2>Third example: mixed tax rates on one invoice</h2>
            <p><strong>Scenario:</strong> You bill consulting (GST/HST (5–15% by province)) plus reimbursable travel (often zero-rated or out of scope depending on rules).</p>
            <ol>
            <li>Line 1 — "Strategy workshop" — taxable at standard rate.</li>
            <li>Line 2 — "Client-approved airfare reimbursement" — separate line, zero tax if documented as disbursement per CRA guidance.</li>
            <li>Notes cite client approval email date — protects you in audit.</li>
            <li>Total shows tax only on taxable lines — client can reconcile to contract.</li>
            </ol>
            <p>When unsure, ask your accountant before sending — amended invoices waste AP time.</p>

            <h2>Freelancer vs registered company letterhead</h2>
            <p><strong>Sole traders</strong> use personal trading name + BN/GST number where applicable. <strong>Companies</strong> use registered legal entity (Ltd/GmbH/SASU) — mismatch with bank account name delays payment. Match the name on your RatPDF "From" block to the account clients pay.</p>

            <h2>Currency and FX (CAD)</h2>
            <p>Domestic clients expect CAD. If contract is USD/EUR but you are Canada-registered, show CAD equivalent in Notes with FX rate and date source ("ECB rate 2026-04-01") so finance can verify.</p>
            <p>Cross-reference: <a href="/guides/invoice-generator-usa">USA invoices</a> · <a href="/guides/invoice-generator-india">India GST invoices</a> · <a href="/guides/invoice-generator-usa">Usa invoices</a>.</p>

            <h2>Deposit and progress invoices</h2>
            <p>Large projects split across multiple PDFs — each needs unique invoice number and clear scope reference ("Phase 2 of 4 — API integration"). Never duplicate invoice numbers; CRA audits trace sequences.</p>
            <p>For retainers duplicated monthly see <a href="/guides/recurring-invoice-generator">recurring invoice generator</a>.</p>

            <h2>Credit notes and refunds</h2>
            <p>Issue a new PDF credit note referencing original invoice number — negative amounts or explicit "Credit" title per local practice. Do not edit a PDF already booked in client ERP.</p>

            <h2>Email delivery and size</h2>
            <p>Vector PDFs from RatPDF are usually under 500 KB. Bundling 20 invoices? Zip locally or use bulk workflow. Over 25 MB combined triggers <a href="/research/attachment-size-limits">email attachment limits</a> — rare for single invoices.</p>

            <h2>Editing after send</h2>
            <p>Typo in description? Regenerate corrected PDF with new number if original was already accepted. For third-party PDFs use <a href="/guides/pdf-to-word-invoice">PDF to Word for invoice</a> — not ideal for tax fields; prefer reissue from Create Invoice.</p>

            <h2>Industry notes</h2>
            <h3>Creative agencies</h3>
            <p>Bill concepts and revisions as separate lines — avoids "one line for everything" disputes.</p>
            <h3>IT contractors</h3>
            <p>Reference SOW ticket IDs in description — client procurement matches PO lines.</p>
            <h3>Trades and field services</h3>
            <p>Include job site or project code in Notes — residential clients file by property address.</p>

            <h2>Year-end and accountant handoff</h2>
            <p>Export folder of PDFs by tax year; your accountant ties each to bank deposits. Missing BN/GST number on B2B PDFs is a common reason year-end adjustments get delayed.</p>

            <h2>RatPDF vs desktop invoice software</h2>
            <p>Desktop tools need installs and licence seats. RatPDF runs in browser — three free uses per tool per day, Pro for agencies. Compare: <a href="/compare">tool alternatives</a>. Research: <a href="/research/freelancer-invoicing-statistics">freelancer invoicing statistics</a>.</p>

            <h2>Pre-send checklist (Canada)</h2>
            <ol>
            <li>BN/GST number visible and correct</li>
            <li>Tax rate matches supply type (GST/HST (5–15% by province))</li>
            <li>Client legal name matches contract</li>
            <li>Invoice number unique and sequential</li>
            <li>Payment terms and bank details in Notes</li>
            <li>PDF opens and prints — not a flattened phone photo</li>
            </ol>

            <h2>Local compliance reminders (CRA)</h2>
            <p>Tax law changes — digital service reporting, e-invoicing pilots, and reverse-charge categories — can alter what must appear on your PDF. Bookmark <a href="https://www.canada.ca/en/revenue-agency.html" rel="noopener noreferrer" target="_blank">CRA</a> and review templates each financial year. Your accountant should approve wording for reverse charge, export, and exempt supplies before you bulk-send to enterprise clients.</p>
            <p>Peer guide for neighbouring workflows: <a href="/guides/invoice-generator-usa">Usa</a>. Pillar: <a href="/guides/invoice-generator-guide">invoice generator guide</a>.</p>

            <h2>Disputes and chargebacks</h2>
            <p>When a client disputes hours or deliverables, your PDF invoice is the billing record — not Slack threads. Keep scope references in line descriptions so dispute resolution references the same text AP already approved. Reissue credit notes rather than editing sent PDFs.</p>

            <h2>Archiving PDFs for audits</h2>
            <p>Use immutable filenames: <code>YYYY-MM-DD_INV-number_client.pdf</code>. Store on encrypted backup; CRA may request invoices years after issuance. RatPDF does not replace accounting ledgers — export totals to your GL monthly.</p>
            

            
            <h2>Payment method block on PDF</h2>
            <p>Include BSB/routing/IBAN, account name, and reference text ("Quote invoice number"). Clients paying via wire need exact match to your bank KYC name — a common delay when freelancers use trading names on invoice but personal name on account.</p>

            <h2>Purchase order matching</h2>
            <p>Enterprise AP matches PO line to invoice line. Copy PO number from buyer portal into Notes; if PO shows quantity 1 at $5,000 do not split across two lines unless PO allows.</p>

            <h2>Sales tax vs withholding</h2>
            <p>GST/HST (5–15% by province) on invoice is not the same as income tax withholding. Cross-border B2B may have treaty withholding — accountant handles; invoice shows gross fee per contract.</p>

            <h2>Recurring vs milestone billing</h2>
            <p>Retainers use same description monthly (<a href="/guides/recurring-invoice-generator">recurring guide</a>). Projects use milestone labels — do not mix on one PDF.</p>

            <h2>White-label and agency billing</h2>
            <p>Agencies billing end-client through intermediary still show supplier as your legal entity — Pro logo is cosmetic; tax ID remains yours.</p>

            <h2>PDF accessibility</h2>
            <p>Vector PDFs from RatPDF are searchable — clients with document management systems index BN/GST number and totals automatically. Flattened JPEG invoices break OCR AP pipelines.</p>

            <h2>Version control</h2>
            <p>Filename suffix <code>-v2</code> only for drafts never sent. Sent invoices get new numbers, not version bumps.</p>

            <h2>Integration checklist with accountant</h2>
            <ol>
            <li>Confirm tax rate list for your supplies</li>
            <li>Approve invoice number format before first send</li>
            <li>Map RatPDF PDF folder to GL import monthly</li>
            <li>Review one sample PDF before bulk client rollout</li>
            </ol>
            

            
            <h2>Related guides &amp; cluster links</h2>
            <ul>
            <li><a href="/guides/invoice-generator-guide">Invoice generator guide</a></li>
            <li><a href="/guides/invoice-generator-india">Invoice generator India</a></li>
            <li><a href="/guides/invoice-generator-usa">Invoice generator USA</a></li>
            <li><a href="/guides/recurring-invoice-generator">Recurring invoice generator</a></li>
            </ul>
            <p>Research: <a href="/research/freelancer-invoicing-statistics">Freelancer invoicing statistics</a> · Compare: <a href="/compare">PDF &amp; business tool alternatives</a></p>
            <p class="mt-4"><a href="/invoice/create" class="btn btn-primary">Create CAD invoice</a></p>
            """;

        private const string InvoiceGeneratorFrance = """
            <h2>France tax invoices for freelancers and SMBs</h2>
            <p>Businesses in France need clear PDF tax invoices that clients and accountants can file without rework. RatPDF's <a href="/invoice/create">Create Invoice</a> tool produces print-ready PDFs in <strong>EUR</strong> with configurable tax lines — no desktop software install.</p>
            <p>This guide covers mandatory fields per impots.gouv expectations, a real-world example, and how to avoid the template mistakes that delay payment.</p>

            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> RatPDF Create Invoice form with EUR currency and TVA 20% line items</figcaption></figure>

            <h2>Real example: Paris freelance developer billing a Lyon SASU €2,800 HT + TVA</h2>
            <p><strong>Scenario:</strong> You delivered a fixed-scope project. The client needs a PDF tax invoice before accounts payable runs Friday.</p>
            <ol>
            <li>Open <a href="/invoice/create">Create Invoice</a> — set currency to <strong>EUR</strong>.</li>
            <li><strong>From:</strong> legal business name, address, SIRET / TVA intracommunautaire in the header block.</li>
            <li><strong>Bill to:</strong> client legal name and address (add their tax ID for B2B).</li>
            <li><strong>Line items:</strong> "Phase 1 — design delivery" · qty 1 · rate matching contract.</li>
            <li><strong>Tax:</strong> set tax name to GST/VAT/TVA/USt as applicable — rate <strong>TVA 20%</strong> when registered.</li>
            <li><strong>Notes:</strong> payment terms (Net 14), bank details, PO number if provided.</li>
            <li>Click <strong>Generate PDF</strong> — email the PDF; archive a copy for impots.gouv records.</li>
            </ol>

            <div class="rp-mid-cta alert alert-primary my-4"><strong>Issue your next EUR invoice in under two minutes</strong> <a href="/invoice/create" class="alert-link fw-semibold">Create invoice free →</a></div>

            <h2>Mandatory fields checklist (impots.gouv)</h2>
            <p>Tax invoice requirements evolve — verify on <a href="https://www.impots.gouv.fr/" rel="noopener noreferrer" target="_blank">impots.gouv</a> before changing templates. Commonly required:</p>
            <ul>
            <li>SIRET, TVA number, date, prestation description, TVA breakdown</li>
            <li>Unique sequential invoice number (no gaps if your regime requires continuity)</li>
            <li>Clear description of goods or services supplied</li>
            <li>Taxable amount and tax charged separately</li>
            <li>Supplier identity sufficient for the client to claim input credits</li>
            </ul>

            <h2>When to use bulk CSV instead</h2>
            <p>Issuing more than ~10 similar invoices per month? Use <a href="/invoice/bulk">Bulk GST Invoice Generator</a> (Business plan) with GSTIN/HSN-style columns adapted for your jurisdiction — or continue single invoices if volume is low.</p>
            <p>India-specific bulk workflow: <a href="/guides/bulk-gst-invoice-generator">bulk GST invoice guide</a>. Global recurring retainers: <a href="/guides/recurring-invoice-generator">recurring invoice generator</a>.</p>

            <h2>After you generate the PDF</h2>
            <ul>
            <li><strong>Email size limits</strong> — rare for invoices, but if over 25 MB see <a href="/research/attachment-size-limits">attachment size limits research</a>.</li>
            <li><strong>Edit a typo</strong> — regenerate from source data; for client PDFs use <a href="/guides/pdf-to-word-invoice">PDF to Word for invoice</a>.</li>
            <li><strong>Compress before portal upload</strong> — <a href="/guides/compress-gst-invoice-pdf">compress GST invoice PDF</a> if a government portal rejects size.</li>
            </ul>

            <h2>Common mistakes</h2>
            <ul>
            <li>Using a quote layout instead of a tax invoice title when registered for VAT/GST</li>
            <li>Missing SIRET / TVA intracommunautaire on B2B invoices — client cannot reclaim tax</li>
            <li>Wrong tax rate for mixed supplies — split line items when rates differ</li>
            <li>PDF only in image form (flattened scan) — always send the vector PDF from RatPDF</li>
            </ul>

            <h2>Upgrade prompt</h2>
            <p>Free tier: 3 uses per tool per day. High-volume France agencies upgrade to Pro for logo upload, larger files, and unlimited daily use — <a href="/Subscription/Plans">compare plans</a> · <a href="/compare">tool alternatives</a>.</p>

            
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
            

            
            <h2>Facture proforma vs facture définitive</h2>
            <p>Proforma is not a tax document — once delivery is confirmed, reissue as définitive facture with TVA. Auto-entrepreneurs: verify franchise thresholds each year on impots.gouv.</p>
            

            
            <h2>Choosing invoice layout for France clients</h2>
            <p>Accounts payable teams in France reject PDFs that look like marketing flyers. Use a single-column layout: legal names at top, line items in a table, tax breakdown before total, payment instructions in Notes. RatPDF's default PDF is optimised for printing and email — not screen-only quotes.</p>
            <p>If your client uses SAP, Oracle, or Xero AP automation, they may OCR your PDF — keep SIRET / TVA intracommunautaire in plain text (not inside a logo image) so extraction succeeds.</p>

            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> Printed EUR tax invoice with TVA 20% breakdown and SIRET / TVA intracommunautaire in header</figcaption></figure>

            <h2>Third example: mixed tax rates on one invoice</h2>
            <p><strong>Scenario:</strong> You bill consulting (TVA 20%) plus reimbursable travel (often zero-rated or out of scope depending on rules).</p>
            <ol>
            <li>Line 1 — "Strategy workshop" — taxable at standard rate.</li>
            <li>Line 2 — "Client-approved airfare reimbursement" — separate line, zero tax if documented as disbursement per impots.gouv guidance.</li>
            <li>Notes cite client approval email date — protects you in audit.</li>
            <li>Total shows tax only on taxable lines — client can reconcile to contract.</li>
            </ol>
            <p>When unsure, ask your accountant before sending — amended invoices waste AP time.</p>

            <h2>Freelancer vs registered company letterhead</h2>
            <p><strong>Sole traders</strong> use personal trading name + SIRET / TVA intracommunautaire where applicable. <strong>Companies</strong> use registered legal entity (Ltd/GmbH/SASU) — mismatch with bank account name delays payment. Match the name on your RatPDF "From" block to the account clients pay.</p>

            <h2>Currency and FX (EUR)</h2>
            <p>Domestic clients expect EUR. If contract is USD/EUR but you are France-registered, show EUR equivalent in Notes with FX rate and date source ("ECB rate 2026-04-01") so finance can verify.</p>
            <p>Cross-reference: <a href="/guides/invoice-generator-usa">USA invoices</a> · <a href="/guides/invoice-generator-india">India GST invoices</a> · <a href="/guides/invoice-generator-germany">Germany invoices</a>.</p>

            <h2>Deposit and progress invoices</h2>
            <p>Large projects split across multiple PDFs — each needs unique invoice number and clear scope reference ("Phase 2 of 4 — API integration"). Never duplicate invoice numbers; impots.gouv audits trace sequences.</p>
            <p>For retainers duplicated monthly see <a href="/guides/recurring-invoice-generator">recurring invoice generator</a>.</p>

            <h2>Credit notes and refunds</h2>
            <p>Issue a new PDF credit note referencing original invoice number — negative amounts or explicit "Credit" title per local practice. Do not edit a PDF already booked in client ERP.</p>

            <h2>Email delivery and size</h2>
            <p>Vector PDFs from RatPDF are usually under 500 KB. Bundling 20 invoices? Zip locally or use bulk workflow. Over 25 MB combined triggers <a href="/research/attachment-size-limits">email attachment limits</a> — rare for single invoices.</p>

            <h2>Editing after send</h2>
            <p>Typo in description? Regenerate corrected PDF with new number if original was already accepted. For third-party PDFs use <a href="/guides/pdf-to-word-invoice">PDF to Word for invoice</a> — not ideal for tax fields; prefer reissue from Create Invoice.</p>

            <h2>Industry notes</h2>
            <h3>Creative agencies</h3>
            <p>Bill concepts and revisions as separate lines — avoids "one line for everything" disputes.</p>
            <h3>IT contractors</h3>
            <p>Reference SOW ticket IDs in description — client procurement matches PO lines.</p>
            <h3>Trades and field services</h3>
            <p>Include job site or project code in Notes — residential clients file by property address.</p>

            <h2>Year-end and accountant handoff</h2>
            <p>Export folder of PDFs by tax year; your accountant ties each to bank deposits. Missing SIRET / TVA intracommunautaire on B2B PDFs is a common reason year-end adjustments get delayed.</p>

            <h2>RatPDF vs desktop invoice software</h2>
            <p>Desktop tools need installs and licence seats. RatPDF runs in browser — three free uses per tool per day, Pro for agencies. Compare: <a href="/compare">tool alternatives</a>. Research: <a href="/research/freelancer-invoicing-statistics">freelancer invoicing statistics</a>.</p>

            <h2>Pre-send checklist (France)</h2>
            <ol>
            <li>SIRET / TVA intracommunautaire visible and correct</li>
            <li>Tax rate matches supply type (TVA 20%)</li>
            <li>Client legal name matches contract</li>
            <li>Invoice number unique and sequential</li>
            <li>Payment terms and bank details in Notes</li>
            <li>PDF opens and prints — not a flattened phone photo</li>
            </ol>

            <h2>Local compliance reminders (impots.gouv)</h2>
            <p>Tax law changes — digital service reporting, e-invoicing pilots, and reverse-charge categories — can alter what must appear on your PDF. Bookmark <a href="https://www.impots.gouv.fr/" rel="noopener noreferrer" target="_blank">impots.gouv</a> and review templates each financial year. Your accountant should approve wording for reverse charge, export, and exempt supplies before you bulk-send to enterprise clients.</p>
            <p>Peer guide for neighbouring workflows: <a href="/guides/invoice-generator-germany">Germany</a>. Pillar: <a href="/guides/invoice-generator-guide">invoice generator guide</a>.</p>

            <h2>Disputes and chargebacks</h2>
            <p>When a client disputes hours or deliverables, your PDF invoice is the billing record — not Slack threads. Keep scope references in line descriptions so dispute resolution references the same text AP already approved. Reissue credit notes rather than editing sent PDFs.</p>

            <h2>Archiving PDFs for audits</h2>
            <p>Use immutable filenames: <code>YYYY-MM-DD_INV-number_client.pdf</code>. Store on encrypted backup; impots.gouv may request invoices years after issuance. RatPDF does not replace accounting ledgers — export totals to your GL monthly.</p>
            

            
            <h2>Payment method block on PDF</h2>
            <p>Include BSB/routing/IBAN, account name, and reference text ("Quote invoice number"). Clients paying via wire need exact match to your bank KYC name — a common delay when freelancers use trading names on invoice but personal name on account.</p>

            <h2>Purchase order matching</h2>
            <p>Enterprise AP matches PO line to invoice line. Copy PO number from buyer portal into Notes; if PO shows quantity 1 at $5,000 do not split across two lines unless PO allows.</p>

            <h2>Sales tax vs withholding</h2>
            <p>TVA 20% on invoice is not the same as income tax withholding. Cross-border B2B may have treaty withholding — accountant handles; invoice shows gross fee per contract.</p>

            <h2>Recurring vs milestone billing</h2>
            <p>Retainers use same description monthly (<a href="/guides/recurring-invoice-generator">recurring guide</a>). Projects use milestone labels — do not mix on one PDF.</p>

            <h2>White-label and agency billing</h2>
            <p>Agencies billing end-client through intermediary still show supplier as your legal entity — Pro logo is cosmetic; tax ID remains yours.</p>

            <h2>PDF accessibility</h2>
            <p>Vector PDFs from RatPDF are searchable — clients with document management systems index SIRET / TVA intracommunautaire and totals automatically. Flattened JPEG invoices break OCR AP pipelines.</p>

            <h2>Version control</h2>
            <p>Filename suffix <code>-v2</code> only for drafts never sent. Sent invoices get new numbers, not version bumps.</p>

            <h2>Integration checklist with accountant</h2>
            <ol>
            <li>Confirm tax rate list for your supplies</li>
            <li>Approve invoice number format before first send</li>
            <li>Map RatPDF PDF folder to GL import monthly</li>
            <li>Review one sample PDF before bulk client rollout</li>
            </ol>
            

            
            <h2>Related guides &amp; cluster links</h2>
            <ul>
            <li><a href="/guides/invoice-generator-guide">Invoice generator guide</a></li>
            <li><a href="/guides/invoice-generator-india">Invoice generator India</a></li>
            <li><a href="/guides/invoice-generator-usa">Invoice generator USA</a></li>
            <li><a href="/guides/recurring-invoice-generator">Recurring invoice generator</a></li>
            </ul>
            <p>Research: <a href="/research/freelancer-invoicing-statistics">Freelancer invoicing statistics</a> · Compare: <a href="/compare">PDF &amp; business tool alternatives</a></p>
            <p class="mt-4"><a href="/invoice/create" class="btn btn-primary">Create EUR invoice</a></p>
            """;

        private const string InvoiceGeneratorGermany = """
            <h2>Germany tax invoices for freelancers and SMBs</h2>
            <p>Businesses in Germany need clear PDF tax invoices that clients and accountants can file without rework. RatPDF's <a href="/invoice/create">Create Invoice</a> tool produces print-ready PDFs in <strong>EUR</strong> with configurable tax lines — no desktop software install.</p>
            <p>This guide covers mandatory fields per BMF expectations, a real-world example, and how to avoid the template mistakes that delay payment.</p>

            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> RatPDF Create Invoice form with EUR currency and USt 19% (7% reduced) line items</figcaption></figure>

            <h2>Real example: Berlin GmbH subcontractor billing Hamburg client €1,650 net + 19% USt</h2>
            <p><strong>Scenario:</strong> You delivered a fixed-scope project. The client needs a PDF tax invoice before accounts payable runs Friday.</p>
            <ol>
            <li>Open <a href="/invoice/create">Create Invoice</a> — set currency to <strong>EUR</strong>.</li>
            <li><strong>From:</strong> legal business name, address, USt-IdNr / Steuernummer in the header block.</li>
            <li><strong>Bill to:</strong> client legal name and address (add their tax ID for B2B).</li>
            <li><strong>Line items:</strong> "Phase 1 — design delivery" · qty 1 · rate matching contract.</li>
            <li><strong>Tax:</strong> set tax name to GST/VAT/TVA/USt as applicable — rate <strong>USt 19% (7% reduced)</strong> when registered.</li>
            <li><strong>Notes:</strong> payment terms (Net 14), bank details, PO number if provided.</li>
            <li>Click <strong>Generate PDF</strong> — email the PDF; archive a copy for BMF records.</li>
            </ol>

            <div class="rp-mid-cta alert alert-primary my-4"><strong>Issue your next EUR invoice in under two minutes</strong> <a href="/invoice/create" class="alert-link fw-semibold">Create invoice free →</a></div>

            <h2>Mandatory fields checklist (BMF)</h2>
            <p>Tax invoice requirements evolve — verify on <a href="https://www.bundesfinanzministerium.de/" rel="noopener noreferrer" target="_blank">BMF</a> before changing templates. Commonly required:</p>
            <ul>
            <li>Rechnungsnummer, Leistungsdatum, USt-Ausweis, Kleinunternehmer note if applicable</li>
            <li>Unique sequential invoice number (no gaps if your regime requires continuity)</li>
            <li>Clear description of goods or services supplied</li>
            <li>Taxable amount and tax charged separately</li>
            <li>Supplier identity sufficient for the client to claim input credits</li>
            </ul>

            <h2>When to use bulk CSV instead</h2>
            <p>Issuing more than ~10 similar invoices per month? Use <a href="/invoice/bulk">Bulk GST Invoice Generator</a> (Business plan) with GSTIN/HSN-style columns adapted for your jurisdiction — or continue single invoices if volume is low.</p>
            <p>India-specific bulk workflow: <a href="/guides/bulk-gst-invoice-generator">bulk GST invoice guide</a>. Global recurring retainers: <a href="/guides/recurring-invoice-generator">recurring invoice generator</a>.</p>

            <h2>After you generate the PDF</h2>
            <ul>
            <li><strong>Email size limits</strong> — rare for invoices, but if over 25 MB see <a href="/research/attachment-size-limits">attachment size limits research</a>.</li>
            <li><strong>Edit a typo</strong> — regenerate from source data; for client PDFs use <a href="/guides/pdf-to-word-invoice">PDF to Word for invoice</a>.</li>
            <li><strong>Compress before portal upload</strong> — <a href="/guides/compress-gst-invoice-pdf">compress GST invoice PDF</a> if a government portal rejects size.</li>
            </ul>

            <h2>Common mistakes</h2>
            <ul>
            <li>Using a quote layout instead of a tax invoice title when registered for VAT/GST</li>
            <li>Missing USt-IdNr / Steuernummer on B2B invoices — client cannot reclaim tax</li>
            <li>Wrong tax rate for mixed supplies — split line items when rates differ</li>
            <li>PDF only in image form (flattened scan) — always send the vector PDF from RatPDF</li>
            </ul>

            <h2>Upgrade prompt</h2>
            <p>Free tier: 3 uses per tool per day. High-volume Germany agencies upgrade to Pro for logo upload, larger files, and unlimited daily use — <a href="/Subscription/Plans">compare plans</a> · <a href="/compare">tool alternatives</a>.</p>

            
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
            

            
            <h2>Leistungszeitraum vs Rechnungsdatum</h2>
            <p>Leistungszeitraum must reflect when service occurred — important for VAT period allocation. Month-end accruals need correct period on Rechnung.</p>
            

            
            <h2>Choosing invoice layout for Germany clients</h2>
            <p>Accounts payable teams in Germany reject PDFs that look like marketing flyers. Use a single-column layout: legal names at top, line items in a table, tax breakdown before total, payment instructions in Notes. RatPDF's default PDF is optimised for printing and email — not screen-only quotes.</p>
            <p>If your client uses SAP, Oracle, or Xero AP automation, they may OCR your PDF — keep USt-IdNr / Steuernummer in plain text (not inside a logo image) so extraction succeeds.</p>

            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> Printed EUR tax invoice with USt 19% (7% reduced) breakdown and USt-IdNr / Steuernummer in header</figcaption></figure>

            <h2>Third example: mixed tax rates on one invoice</h2>
            <p><strong>Scenario:</strong> You bill consulting (USt 19% (7% reduced)) plus reimbursable travel (often zero-rated or out of scope depending on rules).</p>
            <ol>
            <li>Line 1 — "Strategy workshop" — taxable at standard rate.</li>
            <li>Line 2 — "Client-approved airfare reimbursement" — separate line, zero tax if documented as disbursement per BMF guidance.</li>
            <li>Notes cite client approval email date — protects you in audit.</li>
            <li>Total shows tax only on taxable lines — client can reconcile to contract.</li>
            </ol>
            <p>When unsure, ask your accountant before sending — amended invoices waste AP time.</p>

            <h2>Freelancer vs registered company letterhead</h2>
            <p><strong>Sole traders</strong> use personal trading name + USt-IdNr / Steuernummer where applicable. <strong>Companies</strong> use registered legal entity (Ltd/GmbH/SASU) — mismatch with bank account name delays payment. Match the name on your RatPDF "From" block to the account clients pay.</p>

            <h2>Currency and FX (EUR)</h2>
            <p>Domestic clients expect EUR. If contract is USD/EUR but you are Germany-registered, show EUR equivalent in Notes with FX rate and date source ("ECB rate 2026-04-01") so finance can verify.</p>
            <p>Cross-reference: <a href="/guides/invoice-generator-usa">USA invoices</a> · <a href="/guides/invoice-generator-india">India GST invoices</a> · <a href="/guides/invoice-generator-france">France invoices</a>.</p>

            <h2>Deposit and progress invoices</h2>
            <p>Large projects split across multiple PDFs — each needs unique invoice number and clear scope reference ("Phase 2 of 4 — API integration"). Never duplicate invoice numbers; BMF audits trace sequences.</p>
            <p>For retainers duplicated monthly see <a href="/guides/recurring-invoice-generator">recurring invoice generator</a>.</p>

            <h2>Credit notes and refunds</h2>
            <p>Issue a new PDF credit note referencing original invoice number — negative amounts or explicit "Credit" title per local practice. Do not edit a PDF already booked in client ERP.</p>

            <h2>Email delivery and size</h2>
            <p>Vector PDFs from RatPDF are usually under 500 KB. Bundling 20 invoices? Zip locally or use bulk workflow. Over 25 MB combined triggers <a href="/research/attachment-size-limits">email attachment limits</a> — rare for single invoices.</p>

            <h2>Editing after send</h2>
            <p>Typo in description? Regenerate corrected PDF with new number if original was already accepted. For third-party PDFs use <a href="/guides/pdf-to-word-invoice">PDF to Word for invoice</a> — not ideal for tax fields; prefer reissue from Create Invoice.</p>

            <h2>Industry notes</h2>
            <h3>Creative agencies</h3>
            <p>Bill concepts and revisions as separate lines — avoids "one line for everything" disputes.</p>
            <h3>IT contractors</h3>
            <p>Reference SOW ticket IDs in description — client procurement matches PO lines.</p>
            <h3>Trades and field services</h3>
            <p>Include job site or project code in Notes — residential clients file by property address.</p>

            <h2>Year-end and accountant handoff</h2>
            <p>Export folder of PDFs by tax year; your accountant ties each to bank deposits. Missing USt-IdNr / Steuernummer on B2B PDFs is a common reason year-end adjustments get delayed.</p>

            <h2>RatPDF vs desktop invoice software</h2>
            <p>Desktop tools need installs and licence seats. RatPDF runs in browser — three free uses per tool per day, Pro for agencies. Compare: <a href="/compare">tool alternatives</a>. Research: <a href="/research/freelancer-invoicing-statistics">freelancer invoicing statistics</a>.</p>

            <h2>Pre-send checklist (Germany)</h2>
            <ol>
            <li>USt-IdNr / Steuernummer visible and correct</li>
            <li>Tax rate matches supply type (USt 19% (7% reduced))</li>
            <li>Client legal name matches contract</li>
            <li>Invoice number unique and sequential</li>
            <li>Payment terms and bank details in Notes</li>
            <li>PDF opens and prints — not a flattened phone photo</li>
            </ol>

            <h2>Local compliance reminders (BMF)</h2>
            <p>Tax law changes — digital service reporting, e-invoicing pilots, and reverse-charge categories — can alter what must appear on your PDF. Bookmark <a href="https://www.bundesfinanzministerium.de/" rel="noopener noreferrer" target="_blank">BMF</a> and review templates each financial year. Your accountant should approve wording for reverse charge, export, and exempt supplies before you bulk-send to enterprise clients.</p>
            <p>Peer guide for neighbouring workflows: <a href="/guides/invoice-generator-france">France</a>. Pillar: <a href="/guides/invoice-generator-guide">invoice generator guide</a>.</p>

            <h2>Disputes and chargebacks</h2>
            <p>When a client disputes hours or deliverables, your PDF invoice is the billing record — not Slack threads. Keep scope references in line descriptions so dispute resolution references the same text AP already approved. Reissue credit notes rather than editing sent PDFs.</p>

            <h2>Archiving PDFs for audits</h2>
            <p>Use immutable filenames: <code>YYYY-MM-DD_INV-number_client.pdf</code>. Store on encrypted backup; BMF may request invoices years after issuance. RatPDF does not replace accounting ledgers — export totals to your GL monthly.</p>
            

            
            <h2>Payment method block on PDF</h2>
            <p>Include BSB/routing/IBAN, account name, and reference text ("Quote invoice number"). Clients paying via wire need exact match to your bank KYC name — a common delay when freelancers use trading names on invoice but personal name on account.</p>

            <h2>Purchase order matching</h2>
            <p>Enterprise AP matches PO line to invoice line. Copy PO number from buyer portal into Notes; if PO shows quantity 1 at $5,000 do not split across two lines unless PO allows.</p>

            <h2>Sales tax vs withholding</h2>
            <p>USt 19% (7% reduced) on invoice is not the same as income tax withholding. Cross-border B2B may have treaty withholding — accountant handles; invoice shows gross fee per contract.</p>

            <h2>Recurring vs milestone billing</h2>
            <p>Retainers use same description monthly (<a href="/guides/recurring-invoice-generator">recurring guide</a>). Projects use milestone labels — do not mix on one PDF.</p>

            <h2>White-label and agency billing</h2>
            <p>Agencies billing end-client through intermediary still show supplier as your legal entity — Pro logo is cosmetic; tax ID remains yours.</p>

            <h2>PDF accessibility</h2>
            <p>Vector PDFs from RatPDF are searchable — clients with document management systems index USt-IdNr / Steuernummer and totals automatically. Flattened JPEG invoices break OCR AP pipelines.</p>

            <h2>Version control</h2>
            <p>Filename suffix <code>-v2</code> only for drafts never sent. Sent invoices get new numbers, not version bumps.</p>

            <h2>Integration checklist with accountant</h2>
            <ol>
            <li>Confirm tax rate list for your supplies</li>
            <li>Approve invoice number format before first send</li>
            <li>Map RatPDF PDF folder to GL import monthly</li>
            <li>Review one sample PDF before bulk client rollout</li>
            </ol>
            

            
            <h2>Related guides &amp; cluster links</h2>
            <ul>
            <li><a href="/guides/invoice-generator-guide">Invoice generator guide</a></li>
            <li><a href="/guides/invoice-generator-india">Invoice generator India</a></li>
            <li><a href="/guides/invoice-generator-usa">Invoice generator USA</a></li>
            <li><a href="/guides/recurring-invoice-generator">Recurring invoice generator</a></li>
            </ul>
            <p>Research: <a href="/research/freelancer-invoicing-statistics">Freelancer invoicing statistics</a> · Compare: <a href="/compare">PDF &amp; business tool alternatives</a></p>
            <p class="mt-4"><a href="/invoice/create" class="btn btn-primary">Create EUR invoice</a></p>
            """;

        private const string InvoiceGeneratorNewZealand = """
            <h2>New Zealand tax invoices for freelancers and SMBs</h2>
            <p>Businesses in New Zealand need clear PDF tax invoices that clients and accountants can file without rework. RatPDF's <a href="/invoice/create">Create Invoice</a> tool produces print-ready PDFs in <strong>NZD</strong> with configurable tax lines — no desktop software install.</p>
            <p>This guide covers mandatory fields per IRD expectations, a real-world example, and how to avoid the template mistakes that delay payment.</p>

            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> RatPDF Create Invoice form with NZD currency and GST 15% line items</figcaption></figure>

            <h2>Real example: Auckland contractor billing Wellington SMB $3,200 NZD + GST</h2>
            <p><strong>Scenario:</strong> You delivered a fixed-scope project. The client needs a PDF tax invoice before accounts payable runs Friday.</p>
            <ol>
            <li>Open <a href="/invoice/create">Create Invoice</a> — set currency to <strong>NZD</strong>.</li>
            <li><strong>From:</strong> legal business name, address, IRD/GST number in the header block.</li>
            <li><strong>Bill to:</strong> client legal name and address (add their tax ID for B2B).</li>
            <li><strong>Line items:</strong> "Phase 1 — design delivery" · qty 1 · rate matching contract.</li>
            <li><strong>Tax:</strong> set tax name to GST/VAT/TVA/USt as applicable — rate <strong>GST 15%</strong> when registered.</li>
            <li><strong>Notes:</strong> payment terms (Net 14), bank details, PO number if provided.</li>
            <li>Click <strong>Generate PDF</strong> — email the PDF; archive a copy for IRD records.</li>
            </ol>

            <div class="rp-mid-cta alert alert-primary my-4"><strong>Issue your next NZD invoice in under two minutes</strong> <a href="/invoice/create" class="alert-link fw-semibold">Create invoice free →</a></div>

            <h2>Mandatory fields checklist (IRD)</h2>
            <p>Tax invoice requirements evolve — verify on <a href="https://www.ird.govt.nz/" rel="noopener noreferrer" target="_blank">IRD</a> before changing templates. Commonly required:</p>
            <ul>
            <li>GST number, tax invoice wording, line items, total GST</li>
            <li>Unique sequential invoice number (no gaps if your regime requires continuity)</li>
            <li>Clear description of goods or services supplied</li>
            <li>Taxable amount and tax charged separately</li>
            <li>Supplier identity sufficient for the client to claim input credits</li>
            </ul>

            <h2>When to use bulk CSV instead</h2>
            <p>Issuing more than ~10 similar invoices per month? Use <a href="/invoice/bulk">Bulk GST Invoice Generator</a> (Business plan) with GSTIN/HSN-style columns adapted for your jurisdiction — or continue single invoices if volume is low.</p>
            <p>India-specific bulk workflow: <a href="/guides/bulk-gst-invoice-generator">bulk GST invoice guide</a>. Global recurring retainers: <a href="/guides/recurring-invoice-generator">recurring invoice generator</a>.</p>

            <h2>After you generate the PDF</h2>
            <ul>
            <li><strong>Email size limits</strong> — rare for invoices, but if over 25 MB see <a href="/research/attachment-size-limits">attachment size limits research</a>.</li>
            <li><strong>Edit a typo</strong> — regenerate from source data; for client PDFs use <a href="/guides/pdf-to-word-invoice">PDF to Word for invoice</a>.</li>
            <li><strong>Compress before portal upload</strong> — <a href="/guides/compress-gst-invoice-pdf">compress GST invoice PDF</a> if a government portal rejects size.</li>
            </ul>

            <h2>Common mistakes</h2>
            <ul>
            <li>Using a quote layout instead of a tax invoice title when registered for VAT/GST</li>
            <li>Missing IRD/GST number on B2B invoices — client cannot reclaim tax</li>
            <li>Wrong tax rate for mixed supplies — split line items when rates differ</li>
            <li>PDF only in image form (flattened scan) — always send the vector PDF from RatPDF</li>
            </ul>

            <h2>Upgrade prompt</h2>
            <p>Free tier: 3 uses per tool per day. High-volume New Zealand agencies upgrade to Pro for logo upload, larger files, and unlimited daily use — <a href="/Subscription/Plans">compare plans</a> · <a href="/compare">tool alternatives</a>.</p>

            
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
            

            
            <h2>Invoice vs tax invoice wording</h2>
            <p>Below GST registration threshold, issue "invoice" without GST line. Once registered, use "tax invoice" title for supplies over $50 where buyer claims credits.</p>
            

            
            <h2>Choosing invoice layout for New Zealand clients</h2>
            <p>Accounts payable teams in New Zealand reject PDFs that look like marketing flyers. Use a single-column layout: legal names at top, line items in a table, tax breakdown before total, payment instructions in Notes. RatPDF's default PDF is optimised for printing and email — not screen-only quotes.</p>
            <p>If your client uses SAP, Oracle, or Xero AP automation, they may OCR your PDF — keep IRD/GST number in plain text (not inside a logo image) so extraction succeeds.</p>

            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> Printed NZD tax invoice with GST 15% breakdown and IRD/GST number in header</figcaption></figure>

            <h2>Third example: mixed tax rates on one invoice</h2>
            <p><strong>Scenario:</strong> You bill consulting (GST 15%) plus reimbursable travel (often zero-rated or out of scope depending on rules).</p>
            <ol>
            <li>Line 1 — "Strategy workshop" — taxable at standard rate.</li>
            <li>Line 2 — "Client-approved airfare reimbursement" — separate line, zero tax if documented as disbursement per IRD guidance.</li>
            <li>Notes cite client approval email date — protects you in audit.</li>
            <li>Total shows tax only on taxable lines — client can reconcile to contract.</li>
            </ol>
            <p>When unsure, ask your accountant before sending — amended invoices waste AP time.</p>

            <h2>Freelancer vs registered company letterhead</h2>
            <p><strong>Sole traders</strong> use personal trading name + IRD/GST number where applicable. <strong>Companies</strong> use registered legal entity (Ltd/GmbH/SASU) — mismatch with bank account name delays payment. Match the name on your RatPDF "From" block to the account clients pay.</p>

            <h2>Currency and FX (NZD)</h2>
            <p>Domestic clients expect NZD. If contract is USD/EUR but you are New Zealand-registered, show NZD equivalent in Notes with FX rate and date source ("ECB rate 2026-04-01") so finance can verify.</p>
            <p>Cross-reference: <a href="/guides/invoice-generator-usa">USA invoices</a> · <a href="/guides/invoice-generator-india">India GST invoices</a> · <a href="/guides/invoice-generator-australia">Australia invoices</a>.</p>

            <h2>Deposit and progress invoices</h2>
            <p>Large projects split across multiple PDFs — each needs unique invoice number and clear scope reference ("Phase 2 of 4 — API integration"). Never duplicate invoice numbers; IRD audits trace sequences.</p>
            <p>For retainers duplicated monthly see <a href="/guides/recurring-invoice-generator">recurring invoice generator</a>.</p>

            <h2>Credit notes and refunds</h2>
            <p>Issue a new PDF credit note referencing original invoice number — negative amounts or explicit "Credit" title per local practice. Do not edit a PDF already booked in client ERP.</p>

            <h2>Email delivery and size</h2>
            <p>Vector PDFs from RatPDF are usually under 500 KB. Bundling 20 invoices? Zip locally or use bulk workflow. Over 25 MB combined triggers <a href="/research/attachment-size-limits">email attachment limits</a> — rare for single invoices.</p>

            <h2>Editing after send</h2>
            <p>Typo in description? Regenerate corrected PDF with new number if original was already accepted. For third-party PDFs use <a href="/guides/pdf-to-word-invoice">PDF to Word for invoice</a> — not ideal for tax fields; prefer reissue from Create Invoice.</p>

            <h2>Industry notes</h2>
            <h3>Creative agencies</h3>
            <p>Bill concepts and revisions as separate lines — avoids "one line for everything" disputes.</p>
            <h3>IT contractors</h3>
            <p>Reference SOW ticket IDs in description — client procurement matches PO lines.</p>
            <h3>Trades and field services</h3>
            <p>Include job site or project code in Notes — residential clients file by property address.</p>

            <h2>Year-end and accountant handoff</h2>
            <p>Export folder of PDFs by tax year; your accountant ties each to bank deposits. Missing IRD/GST number on B2B PDFs is a common reason year-end adjustments get delayed.</p>

            <h2>RatPDF vs desktop invoice software</h2>
            <p>Desktop tools need installs and licence seats. RatPDF runs in browser — three free uses per tool per day, Pro for agencies. Compare: <a href="/compare">tool alternatives</a>. Research: <a href="/research/freelancer-invoicing-statistics">freelancer invoicing statistics</a>.</p>

            <h2>Pre-send checklist (New Zealand)</h2>
            <ol>
            <li>IRD/GST number visible and correct</li>
            <li>Tax rate matches supply type (GST 15%)</li>
            <li>Client legal name matches contract</li>
            <li>Invoice number unique and sequential</li>
            <li>Payment terms and bank details in Notes</li>
            <li>PDF opens and prints — not a flattened phone photo</li>
            </ol>

            <h2>Local compliance reminders (IRD)</h2>
            <p>Tax law changes — digital service reporting, e-invoicing pilots, and reverse-charge categories — can alter what must appear on your PDF. Bookmark <a href="https://www.ird.govt.nz/" rel="noopener noreferrer" target="_blank">IRD</a> and review templates each financial year. Your accountant should approve wording for reverse charge, export, and exempt supplies before you bulk-send to enterprise clients.</p>
            <p>Peer guide for neighbouring workflows: <a href="/guides/invoice-generator-australia">Australia</a>. Pillar: <a href="/guides/invoice-generator-guide">invoice generator guide</a>.</p>

            <h2>Disputes and chargebacks</h2>
            <p>When a client disputes hours or deliverables, your PDF invoice is the billing record — not Slack threads. Keep scope references in line descriptions so dispute resolution references the same text AP already approved. Reissue credit notes rather than editing sent PDFs.</p>

            <h2>Archiving PDFs for audits</h2>
            <p>Use immutable filenames: <code>YYYY-MM-DD_INV-number_client.pdf</code>. Store on encrypted backup; IRD may request invoices years after issuance. RatPDF does not replace accounting ledgers — export totals to your GL monthly.</p>
            

            
            <h2>Payment method block on PDF</h2>
            <p>Include BSB/routing/IBAN, account name, and reference text ("Quote invoice number"). Clients paying via wire need exact match to your bank KYC name — a common delay when freelancers use trading names on invoice but personal name on account.</p>

            <h2>Purchase order matching</h2>
            <p>Enterprise AP matches PO line to invoice line. Copy PO number from buyer portal into Notes; if PO shows quantity 1 at $5,000 do not split across two lines unless PO allows.</p>

            <h2>Sales tax vs withholding</h2>
            <p>GST 15% on invoice is not the same as income tax withholding. Cross-border B2B may have treaty withholding — accountant handles; invoice shows gross fee per contract.</p>

            <h2>Recurring vs milestone billing</h2>
            <p>Retainers use same description monthly (<a href="/guides/recurring-invoice-generator">recurring guide</a>). Projects use milestone labels — do not mix on one PDF.</p>

            <h2>White-label and agency billing</h2>
            <p>Agencies billing end-client through intermediary still show supplier as your legal entity — Pro logo is cosmetic; tax ID remains yours.</p>

            <h2>PDF accessibility</h2>
            <p>Vector PDFs from RatPDF are searchable — clients with document management systems index IRD/GST number and totals automatically. Flattened JPEG invoices break OCR AP pipelines.</p>

            <h2>Version control</h2>
            <p>Filename suffix <code>-v2</code> only for drafts never sent. Sent invoices get new numbers, not version bumps.</p>

            <h2>Integration checklist with accountant</h2>
            <ol>
            <li>Confirm tax rate list for your supplies</li>
            <li>Approve invoice number format before first send</li>
            <li>Map RatPDF PDF folder to GL import monthly</li>
            <li>Review one sample PDF before bulk client rollout</li>
            </ol>
            

            
            <h2>Related guides &amp; cluster links</h2>
            <ul>
            <li><a href="/guides/invoice-generator-guide">Invoice generator guide</a></li>
            <li><a href="/guides/invoice-generator-india">Invoice generator India</a></li>
            <li><a href="/guides/invoice-generator-usa">Invoice generator USA</a></li>
            <li><a href="/guides/recurring-invoice-generator">Recurring invoice generator</a></li>
            </ul>
            <p>Research: <a href="/research/freelancer-invoicing-statistics">Freelancer invoicing statistics</a> · Compare: <a href="/compare">PDF &amp; business tool alternatives</a></p>
            <p class="mt-4"><a href="/invoice/create" class="btn btn-primary">Create NZD invoice</a></p>
            """;

        private const string InvoiceGeneratorPhilippines = """
            <h2>Philippines tax invoices for freelancers and SMBs</h2>
            <p>Businesses in Philippines need clear PDF tax invoices that clients and accountants can file without rework. RatPDF's <a href="/invoice/create">Create Invoice</a> tool produces print-ready PDFs in <strong>PHP</strong> with configurable tax lines — no desktop software install.</p>
            <p>This guide covers mandatory fields per BIR expectations, a real-world example, and how to avoid the template mistakes that delay payment.</p>

            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> RatPDF Create Invoice form with PHP currency and VAT 12% line items</figcaption></figure>

            <h2>Real example: Manila agency billing Cebu client ₱85,000 + 12% VAT</h2>
            <p><strong>Scenario:</strong> You delivered a fixed-scope project. The client needs a PDF tax invoice before accounts payable runs Friday.</p>
            <ol>
            <li>Open <a href="/invoice/create">Create Invoice</a> — set currency to <strong>PHP</strong>.</li>
            <li><strong>From:</strong> legal business name, address, TIN in the header block.</li>
            <li><strong>Bill to:</strong> client legal name and address (add their tax ID for B2B).</li>
            <li><strong>Line items:</strong> "Phase 1 — design delivery" · qty 1 · rate matching contract.</li>
            <li><strong>Tax:</strong> set tax name to GST/VAT/TVA/USt as applicable — rate <strong>VAT 12%</strong> when registered.</li>
            <li><strong>Notes:</strong> payment terms (Net 14), bank details, PO number if provided.</li>
            <li>Click <strong>Generate PDF</strong> — email the PDF; archive a copy for BIR records.</li>
            </ol>

            <div class="rp-mid-cta alert alert-primary my-4"><strong>Issue your next PHP invoice in under two minutes</strong> <a href="/invoice/create" class="alert-link fw-semibold">Create invoice free →</a></div>

            <h2>Mandatory fields checklist (BIR)</h2>
            <p>Tax invoice requirements evolve — verify on <a href="https://www.bir.gov.ph/" rel="noopener noreferrer" target="_blank">BIR</a> before changing templates. Commonly required:</p>
            <ul>
            <li>TIN, registered name, VATable sales, VAT amount</li>
            <li>Unique sequential invoice number (no gaps if your regime requires continuity)</li>
            <li>Clear description of goods or services supplied</li>
            <li>Taxable amount and tax charged separately</li>
            <li>Supplier identity sufficient for the client to claim input credits</li>
            </ul>

            <h2>When to use bulk CSV instead</h2>
            <p>Issuing more than ~10 similar invoices per month? Use <a href="/invoice/bulk">Bulk GST Invoice Generator</a> (Business plan) with GSTIN/HSN-style columns adapted for your jurisdiction — or continue single invoices if volume is low.</p>
            <p>India-specific bulk workflow: <a href="/guides/bulk-gst-invoice-generator">bulk GST invoice guide</a>. Global recurring retainers: <a href="/guides/recurring-invoice-generator">recurring invoice generator</a>.</p>

            <h2>After you generate the PDF</h2>
            <ul>
            <li><strong>Email size limits</strong> — rare for invoices, but if over 25 MB see <a href="/research/attachment-size-limits">attachment size limits research</a>.</li>
            <li><strong>Edit a typo</strong> — regenerate from source data; for client PDFs use <a href="/guides/pdf-to-word-invoice">PDF to Word for invoice</a>.</li>
            <li><strong>Compress before portal upload</strong> — <a href="/guides/compress-gst-invoice-pdf">compress GST invoice PDF</a> if a government portal rejects size.</li>
            </ul>

            <h2>Common mistakes</h2>
            <ul>
            <li>Using a quote layout instead of a tax invoice title when registered for VAT/GST</li>
            <li>Missing TIN on B2B invoices — client cannot reclaim tax</li>
            <li>Wrong tax rate for mixed supplies — split line items when rates differ</li>
            <li>PDF only in image form (flattened scan) — always send the vector PDF from RatPDF</li>
            </ul>

            <h2>Upgrade prompt</h2>
            <p>Free tier: 3 uses per tool per day. High-volume Philippines agencies upgrade to Pro for logo upload, larger files, and unlimited daily use — <a href="/Subscription/Plans">compare plans</a> · <a href="/compare">tool alternatives</a>.</p>

            
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
            

            
            <h2>2307 certificates</h2>
            <p>Clients may withhold — your sales invoice still shows gross VATable amount; coordinate 2307 paperwork separately with accountant.</p>
            

            
            <h2>Choosing invoice layout for Philippines clients</h2>
            <p>Accounts payable teams in Philippines reject PDFs that look like marketing flyers. Use a single-column layout: legal names at top, line items in a table, tax breakdown before total, payment instructions in Notes. RatPDF's default PDF is optimised for printing and email — not screen-only quotes.</p>
            <p>If your client uses SAP, Oracle, or Xero AP automation, they may OCR your PDF — keep TIN in plain text (not inside a logo image) so extraction succeeds.</p>

            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> Printed PHP tax invoice with VAT 12% breakdown and TIN in header</figcaption></figure>

            <h2>Third example: mixed tax rates on one invoice</h2>
            <p><strong>Scenario:</strong> You bill consulting (VAT 12%) plus reimbursable travel (often zero-rated or out of scope depending on rules).</p>
            <ol>
            <li>Line 1 — "Strategy workshop" — taxable at standard rate.</li>
            <li>Line 2 — "Client-approved airfare reimbursement" — separate line, zero tax if documented as disbursement per BIR guidance.</li>
            <li>Notes cite client approval email date — protects you in audit.</li>
            <li>Total shows tax only on taxable lines — client can reconcile to contract.</li>
            </ol>
            <p>When unsure, ask your accountant before sending — amended invoices waste AP time.</p>

            <h2>Freelancer vs registered company letterhead</h2>
            <p><strong>Sole traders</strong> use personal trading name + TIN where applicable. <strong>Companies</strong> use registered legal entity (Ltd/GmbH/SASU) — mismatch with bank account name delays payment. Match the name on your RatPDF "From" block to the account clients pay.</p>

            <h2>Currency and FX (PHP)</h2>
            <p>Domestic clients expect PHP. If contract is USD/EUR but you are Philippines-registered, show PHP equivalent in Notes with FX rate and date source ("ECB rate 2026-04-01") so finance can verify.</p>
            <p>Cross-reference: <a href="/guides/invoice-generator-usa">USA invoices</a> · <a href="/guides/invoice-generator-india">India GST invoices</a> · <a href="/guides/invoice-generator-singapore">Singapore invoices</a>.</p>

            <h2>Deposit and progress invoices</h2>
            <p>Large projects split across multiple PDFs — each needs unique invoice number and clear scope reference ("Phase 2 of 4 — API integration"). Never duplicate invoice numbers; BIR audits trace sequences.</p>
            <p>For retainers duplicated monthly see <a href="/guides/recurring-invoice-generator">recurring invoice generator</a>.</p>

            <h2>Credit notes and refunds</h2>
            <p>Issue a new PDF credit note referencing original invoice number — negative amounts or explicit "Credit" title per local practice. Do not edit a PDF already booked in client ERP.</p>

            <h2>Email delivery and size</h2>
            <p>Vector PDFs from RatPDF are usually under 500 KB. Bundling 20 invoices? Zip locally or use bulk workflow. Over 25 MB combined triggers <a href="/research/attachment-size-limits">email attachment limits</a> — rare for single invoices.</p>

            <h2>Editing after send</h2>
            <p>Typo in description? Regenerate corrected PDF with new number if original was already accepted. For third-party PDFs use <a href="/guides/pdf-to-word-invoice">PDF to Word for invoice</a> — not ideal for tax fields; prefer reissue from Create Invoice.</p>

            <h2>Industry notes</h2>
            <h3>Creative agencies</h3>
            <p>Bill concepts and revisions as separate lines — avoids "one line for everything" disputes.</p>
            <h3>IT contractors</h3>
            <p>Reference SOW ticket IDs in description — client procurement matches PO lines.</p>
            <h3>Trades and field services</h3>
            <p>Include job site or project code in Notes — residential clients file by property address.</p>

            <h2>Year-end and accountant handoff</h2>
            <p>Export folder of PDFs by tax year; your accountant ties each to bank deposits. Missing TIN on B2B PDFs is a common reason year-end adjustments get delayed.</p>

            <h2>RatPDF vs desktop invoice software</h2>
            <p>Desktop tools need installs and licence seats. RatPDF runs in browser — three free uses per tool per day, Pro for agencies. Compare: <a href="/compare">tool alternatives</a>. Research: <a href="/research/freelancer-invoicing-statistics">freelancer invoicing statistics</a>.</p>

            <h2>Pre-send checklist (Philippines)</h2>
            <ol>
            <li>TIN visible and correct</li>
            <li>Tax rate matches supply type (VAT 12%)</li>
            <li>Client legal name matches contract</li>
            <li>Invoice number unique and sequential</li>
            <li>Payment terms and bank details in Notes</li>
            <li>PDF opens and prints — not a flattened phone photo</li>
            </ol>

            <h2>Local compliance reminders (BIR)</h2>
            <p>Tax law changes — digital service reporting, e-invoicing pilots, and reverse-charge categories — can alter what must appear on your PDF. Bookmark <a href="https://www.bir.gov.ph/" rel="noopener noreferrer" target="_blank">BIR</a> and review templates each financial year. Your accountant should approve wording for reverse charge, export, and exempt supplies before you bulk-send to enterprise clients.</p>
            <p>Peer guide for neighbouring workflows: <a href="/guides/invoice-generator-singapore">Singapore</a>. Pillar: <a href="/guides/invoice-generator-guide">invoice generator guide</a>.</p>

            <h2>Disputes and chargebacks</h2>
            <p>When a client disputes hours or deliverables, your PDF invoice is the billing record — not Slack threads. Keep scope references in line descriptions so dispute resolution references the same text AP already approved. Reissue credit notes rather than editing sent PDFs.</p>

            <h2>Archiving PDFs for audits</h2>
            <p>Use immutable filenames: <code>YYYY-MM-DD_INV-number_client.pdf</code>. Store on encrypted backup; BIR may request invoices years after issuance. RatPDF does not replace accounting ledgers — export totals to your GL monthly.</p>
            

            
            <h2>Payment method block on PDF</h2>
            <p>Include BSB/routing/IBAN, account name, and reference text ("Quote invoice number"). Clients paying via wire need exact match to your bank KYC name — a common delay when freelancers use trading names on invoice but personal name on account.</p>

            <h2>Purchase order matching</h2>
            <p>Enterprise AP matches PO line to invoice line. Copy PO number from buyer portal into Notes; if PO shows quantity 1 at $5,000 do not split across two lines unless PO allows.</p>

            <h2>Sales tax vs withholding</h2>
            <p>VAT 12% on invoice is not the same as income tax withholding. Cross-border B2B may have treaty withholding — accountant handles; invoice shows gross fee per contract.</p>

            <h2>Recurring vs milestone billing</h2>
            <p>Retainers use same description monthly (<a href="/guides/recurring-invoice-generator">recurring guide</a>). Projects use milestone labels — do not mix on one PDF.</p>

            <h2>White-label and agency billing</h2>
            <p>Agencies billing end-client through intermediary still show supplier as your legal entity — Pro logo is cosmetic; tax ID remains yours.</p>

            <h2>PDF accessibility</h2>
            <p>Vector PDFs from RatPDF are searchable — clients with document management systems index TIN and totals automatically. Flattened JPEG invoices break OCR AP pipelines.</p>

            <h2>Version control</h2>
            <p>Filename suffix <code>-v2</code> only for drafts never sent. Sent invoices get new numbers, not version bumps.</p>

            <h2>Integration checklist with accountant</h2>
            <ol>
            <li>Confirm tax rate list for your supplies</li>
            <li>Approve invoice number format before first send</li>
            <li>Map RatPDF PDF folder to GL import monthly</li>
            <li>Review one sample PDF before bulk client rollout</li>
            </ol>
            

            
            <h2>Related guides &amp; cluster links</h2>
            <ul>
            <li><a href="/guides/invoice-generator-guide">Invoice generator guide</a></li>
            <li><a href="/guides/invoice-generator-india">Invoice generator India</a></li>
            <li><a href="/guides/invoice-generator-usa">Invoice generator USA</a></li>
            <li><a href="/guides/recurring-invoice-generator">Recurring invoice generator</a></li>
            </ul>
            <p>Research: <a href="/research/freelancer-invoicing-statistics">Freelancer invoicing statistics</a> · Compare: <a href="/compare">PDF &amp; business tool alternatives</a></p>
            <p class="mt-4"><a href="/invoice/create" class="btn btn-primary">Create PHP invoice</a></p>
            """;

        private const string InvoiceGeneratorSingapore = """
            <h2>Singapore tax invoices for freelancers and SMBs</h2>
            <p>Businesses in Singapore need clear PDF tax invoices that clients and accountants can file without rework. RatPDF's <a href="/invoice/create">Create Invoice</a> tool produces print-ready PDFs in <strong>SGD</strong> with configurable tax lines — no desktop software install.</p>
            <p>This guide covers mandatory fields per IRAS expectations, a real-world example, and how to avoid the template mistakes that delay payment.</p>

            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> RatPDF Create Invoice form with SGD currency and GST 9% line items</figcaption></figure>

            <h2>Real example: Singapore SaaS vendor billing regional client S$6,500 + GST</h2>
            <p><strong>Scenario:</strong> You delivered a fixed-scope project. The client needs a PDF tax invoice before accounts payable runs Friday.</p>
            <ol>
            <li>Open <a href="/invoice/create">Create Invoice</a> — set currency to <strong>SGD</strong>.</li>
            <li><strong>From:</strong> legal business name, address, UEN in the header block.</li>
            <li><strong>Bill to:</strong> client legal name and address (add their tax ID for B2B).</li>
            <li><strong>Line items:</strong> "Phase 1 — design delivery" · qty 1 · rate matching contract.</li>
            <li><strong>Tax:</strong> set tax name to GST/VAT/TVA/USt as applicable — rate <strong>GST 9%</strong> when registered.</li>
            <li><strong>Notes:</strong> payment terms (Net 14), bank details, PO number if provided.</li>
            <li>Click <strong>Generate PDF</strong> — email the PDF; archive a copy for IRAS records.</li>
            </ol>

            <div class="rp-mid-cta alert alert-primary my-4"><strong>Issue your next SGD invoice in under two minutes</strong> <a href="/invoice/create" class="alert-link fw-semibold">Create invoice free →</a></div>

            <h2>Mandatory fields checklist (IRAS)</h2>
            <p>Tax invoice requirements evolve — verify on <a href="https://www.iras.gov.sg/" rel="noopener noreferrer" target="_blank">IRAS</a> before changing templates. Commonly required:</p>
            <ul>
            <li>UEN, GST registration number, tax invoice label, GST amount</li>
            <li>Unique sequential invoice number (no gaps if your regime requires continuity)</li>
            <li>Clear description of goods or services supplied</li>
            <li>Taxable amount and tax charged separately</li>
            <li>Supplier identity sufficient for the client to claim input credits</li>
            </ul>

            <h2>When to use bulk CSV instead</h2>
            <p>Issuing more than ~10 similar invoices per month? Use <a href="/invoice/bulk">Bulk GST Invoice Generator</a> (Business plan) with GSTIN/HSN-style columns adapted for your jurisdiction — or continue single invoices if volume is low.</p>
            <p>India-specific bulk workflow: <a href="/guides/bulk-gst-invoice-generator">bulk GST invoice guide</a>. Global recurring retainers: <a href="/guides/recurring-invoice-generator">recurring invoice generator</a>.</p>

            <h2>After you generate the PDF</h2>
            <ul>
            <li><strong>Email size limits</strong> — rare for invoices, but if over 25 MB see <a href="/research/attachment-size-limits">attachment size limits research</a>.</li>
            <li><strong>Edit a typo</strong> — regenerate from source data; for client PDFs use <a href="/guides/pdf-to-word-invoice">PDF to Word for invoice</a>.</li>
            <li><strong>Compress before portal upload</strong> — <a href="/guides/compress-gst-invoice-pdf">compress GST invoice PDF</a> if a government portal rejects size.</li>
            </ul>

            <h2>Common mistakes</h2>
            <ul>
            <li>Using a quote layout instead of a tax invoice title when registered for VAT/GST</li>
            <li>Missing UEN on B2B invoices — client cannot reclaim tax</li>
            <li>Wrong tax rate for mixed supplies — split line items when rates differ</li>
            <li>PDF only in image form (flattened scan) — always send the vector PDF from RatPDF</li>
            </ul>

            <h2>Upgrade prompt</h2>
            <p>Free tier: 3 uses per tool per day. High-volume Singapore agencies upgrade to Pro for logo upload, larger files, and unlimited daily use — <a href="/Subscription/Plans">compare plans</a> · <a href="/compare">tool alternatives</a>.</p>

            
            <h2>GST registration (S$1 million threshold)</h2>
            <p>Mandatory registration when taxable turnover exceeds <strong>S$1 million</strong> retrospectively or prospectively. Rate is 9% from 2024.</p>

            <h2>Tax invoice content (IRAS)</h2>
            <p>Invoice number, date, supplier name/UEN/GST reg no., description, GST rate and amount, total. IRAS e-tax guides apply.</p>

            <h2>Second example: fintech retainer — standard-rated services</h2>
            <p>S$8,500 monthly compliance support + S$765 GST — UEN in header; foreign client may need zero-rated treatment — confirm place of supply.</p>

            <h2>PEPPOL / InvoiceNow context</h2>
            <p>Government and large enterprise may require e-invoice networks — PDF remains common for SME B2B email.</p>

            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Create SGD invoice</strong> <a href="/invoice/create" class="alert-link fw-semibold">Create invoice →</a></div>
            

            
            <h2>Customer accounting for prescribed goods</h2>
            <p>Certain B2B supplies use customer accounting — invoice must state applicable IRAS wording; confirm with tax agent.</p>
            

            
            <h2>Choosing invoice layout for Singapore clients</h2>
            <p>Accounts payable teams in Singapore reject PDFs that look like marketing flyers. Use a single-column layout: legal names at top, line items in a table, tax breakdown before total, payment instructions in Notes. RatPDF's default PDF is optimised for printing and email — not screen-only quotes.</p>
            <p>If your client uses SAP, Oracle, or Xero AP automation, they may OCR your PDF — keep UEN in plain text (not inside a logo image) so extraction succeeds.</p>

            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> Printed SGD tax invoice with GST 9% breakdown and UEN in header</figcaption></figure>

            <h2>Third example: mixed tax rates on one invoice</h2>
            <p><strong>Scenario:</strong> You bill consulting (GST 9%) plus reimbursable travel (often zero-rated or out of scope depending on rules).</p>
            <ol>
            <li>Line 1 — "Strategy workshop" — taxable at standard rate.</li>
            <li>Line 2 — "Client-approved airfare reimbursement" — separate line, zero tax if documented as disbursement per IRAS guidance.</li>
            <li>Notes cite client approval email date — protects you in audit.</li>
            <li>Total shows tax only on taxable lines — client can reconcile to contract.</li>
            </ol>
            <p>When unsure, ask your accountant before sending — amended invoices waste AP time.</p>

            <h2>Freelancer vs registered company letterhead</h2>
            <p><strong>Sole traders</strong> use personal trading name + UEN where applicable. <strong>Companies</strong> use registered legal entity (Ltd/GmbH/SASU) — mismatch with bank account name delays payment. Match the name on your RatPDF "From" block to the account clients pay.</p>

            <h2>Currency and FX (SGD)</h2>
            <p>Domestic clients expect SGD. If contract is USD/EUR but you are Singapore-registered, show SGD equivalent in Notes with FX rate and date source ("ECB rate 2026-04-01") so finance can verify.</p>
            <p>Cross-reference: <a href="/guides/invoice-generator-usa">USA invoices</a> · <a href="/guides/invoice-generator-india">India GST invoices</a> · <a href="/guides/invoice-generator-philippines">Philippines invoices</a>.</p>

            <h2>Deposit and progress invoices</h2>
            <p>Large projects split across multiple PDFs — each needs unique invoice number and clear scope reference ("Phase 2 of 4 — API integration"). Never duplicate invoice numbers; IRAS audits trace sequences.</p>
            <p>For retainers duplicated monthly see <a href="/guides/recurring-invoice-generator">recurring invoice generator</a>.</p>

            <h2>Credit notes and refunds</h2>
            <p>Issue a new PDF credit note referencing original invoice number — negative amounts or explicit "Credit" title per local practice. Do not edit a PDF already booked in client ERP.</p>

            <h2>Email delivery and size</h2>
            <p>Vector PDFs from RatPDF are usually under 500 KB. Bundling 20 invoices? Zip locally or use bulk workflow. Over 25 MB combined triggers <a href="/research/attachment-size-limits">email attachment limits</a> — rare for single invoices.</p>

            <h2>Editing after send</h2>
            <p>Typo in description? Regenerate corrected PDF with new number if original was already accepted. For third-party PDFs use <a href="/guides/pdf-to-word-invoice">PDF to Word for invoice</a> — not ideal for tax fields; prefer reissue from Create Invoice.</p>

            <h2>Industry notes</h2>
            <h3>Creative agencies</h3>
            <p>Bill concepts and revisions as separate lines — avoids "one line for everything" disputes.</p>
            <h3>IT contractors</h3>
            <p>Reference SOW ticket IDs in description — client procurement matches PO lines.</p>
            <h3>Trades and field services</h3>
            <p>Include job site or project code in Notes — residential clients file by property address.</p>

            <h2>Year-end and accountant handoff</h2>
            <p>Export folder of PDFs by tax year; your accountant ties each to bank deposits. Missing UEN on B2B PDFs is a common reason year-end adjustments get delayed.</p>

            <h2>RatPDF vs desktop invoice software</h2>
            <p>Desktop tools need installs and licence seats. RatPDF runs in browser — three free uses per tool per day, Pro for agencies. Compare: <a href="/compare">tool alternatives</a>. Research: <a href="/research/freelancer-invoicing-statistics">freelancer invoicing statistics</a>.</p>

            <h2>Pre-send checklist (Singapore)</h2>
            <ol>
            <li>UEN visible and correct</li>
            <li>Tax rate matches supply type (GST 9%)</li>
            <li>Client legal name matches contract</li>
            <li>Invoice number unique and sequential</li>
            <li>Payment terms and bank details in Notes</li>
            <li>PDF opens and prints — not a flattened phone photo</li>
            </ol>

            <h2>Local compliance reminders (IRAS)</h2>
            <p>Tax law changes — digital service reporting, e-invoicing pilots, and reverse-charge categories — can alter what must appear on your PDF. Bookmark <a href="https://www.iras.gov.sg/" rel="noopener noreferrer" target="_blank">IRAS</a> and review templates each financial year. Your accountant should approve wording for reverse charge, export, and exempt supplies before you bulk-send to enterprise clients.</p>
            <p>Peer guide for neighbouring workflows: <a href="/guides/invoice-generator-philippines">Philippines</a>. Pillar: <a href="/guides/invoice-generator-guide">invoice generator guide</a>.</p>

            <h2>Disputes and chargebacks</h2>
            <p>When a client disputes hours or deliverables, your PDF invoice is the billing record — not Slack threads. Keep scope references in line descriptions so dispute resolution references the same text AP already approved. Reissue credit notes rather than editing sent PDFs.</p>

            <h2>Archiving PDFs for audits</h2>
            <p>Use immutable filenames: <code>YYYY-MM-DD_INV-number_client.pdf</code>. Store on encrypted backup; IRAS may request invoices years after issuance. RatPDF does not replace accounting ledgers — export totals to your GL monthly.</p>
            

            
            <h2>Payment method block on PDF</h2>
            <p>Include BSB/routing/IBAN, account name, and reference text ("Quote invoice number"). Clients paying via wire need exact match to your bank KYC name — a common delay when freelancers use trading names on invoice but personal name on account.</p>

            <h2>Purchase order matching</h2>
            <p>Enterprise AP matches PO line to invoice line. Copy PO number from buyer portal into Notes; if PO shows quantity 1 at $5,000 do not split across two lines unless PO allows.</p>

            <h2>Sales tax vs withholding</h2>
            <p>GST 9% on invoice is not the same as income tax withholding. Cross-border B2B may have treaty withholding — accountant handles; invoice shows gross fee per contract.</p>

            <h2>Recurring vs milestone billing</h2>
            <p>Retainers use same description monthly (<a href="/guides/recurring-invoice-generator">recurring guide</a>). Projects use milestone labels — do not mix on one PDF.</p>

            <h2>White-label and agency billing</h2>
            <p>Agencies billing end-client through intermediary still show supplier as your legal entity — Pro logo is cosmetic; tax ID remains yours.</p>

            <h2>PDF accessibility</h2>
            <p>Vector PDFs from RatPDF are searchable — clients with document management systems index UEN and totals automatically. Flattened JPEG invoices break OCR AP pipelines.</p>

            <h2>Version control</h2>
            <p>Filename suffix <code>-v2</code> only for drafts never sent. Sent invoices get new numbers, not version bumps.</p>

            <h2>Integration checklist with accountant</h2>
            <ol>
            <li>Confirm tax rate list for your supplies</li>
            <li>Approve invoice number format before first send</li>
            <li>Map RatPDF PDF folder to GL import monthly</li>
            <li>Review one sample PDF before bulk client rollout</li>
            </ol>
            

            
            <h2>Related guides &amp; cluster links</h2>
            <ul>
            <li><a href="/guides/invoice-generator-guide">Invoice generator guide</a></li>
            <li><a href="/guides/invoice-generator-india">Invoice generator India</a></li>
            <li><a href="/guides/invoice-generator-usa">Invoice generator USA</a></li>
            <li><a href="/guides/recurring-invoice-generator">Recurring invoice generator</a></li>
            </ul>
            <p>Research: <a href="/research/freelancer-invoicing-statistics">Freelancer invoicing statistics</a> · Compare: <a href="/compare">PDF &amp; business tool alternatives</a></p>
            <p class="mt-4"><a href="/invoice/create" class="btn btn-primary">Create SGD invoice</a></p>
            """;

        private const string InvoiceGeneratorSouthAfrica = """
            <h2>South Africa tax invoices for freelancers and SMBs</h2>
            <p>Businesses in South Africa need clear PDF tax invoices that clients and accountants can file without rework. RatPDF's <a href="/invoice/create">Create Invoice</a> tool produces print-ready PDFs in <strong>ZAR</strong> with configurable tax lines — no desktop software install.</p>
            <p>This guide covers mandatory fields per SARS expectations, a real-world example, and how to avoid the template mistakes that delay payment.</p>

            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> RatPDF Create Invoice form with ZAR currency and VAT 15% line items</figcaption></figure>

            <h2>Real example: Cape Town supplier billing Johannesburg buyer R42,000 + VAT</h2>
            <p><strong>Scenario:</strong> You delivered a fixed-scope project. The client needs a PDF tax invoice before accounts payable runs Friday.</p>
            <ol>
            <li>Open <a href="/invoice/create">Create Invoice</a> — set currency to <strong>ZAR</strong>.</li>
            <li><strong>From:</strong> legal business name, address, VAT vendor number in the header block.</li>
            <li><strong>Bill to:</strong> client legal name and address (add their tax ID for B2B).</li>
            <li><strong>Line items:</strong> "Phase 1 — design delivery" · qty 1 · rate matching contract.</li>
            <li><strong>Tax:</strong> set tax name to GST/VAT/TVA/USt as applicable — rate <strong>VAT 15%</strong> when registered.</li>
            <li><strong>Notes:</strong> payment terms (Net 14), bank details, PO number if provided.</li>
            <li>Click <strong>Generate PDF</strong> — email the PDF; archive a copy for SARS records.</li>
            </ol>

            <div class="rp-mid-cta alert alert-primary my-4"><strong>Issue your next ZAR invoice in under two minutes</strong> <a href="/invoice/create" class="alert-link fw-semibold">Create invoice free →</a></div>

            <h2>Mandatory fields checklist (SARS)</h2>
            <p>Tax invoice requirements evolve — verify on <a href="https://www.sars.gov.za/" rel="noopener noreferrer" target="_blank">SARS</a> before changing templates. Commonly required:</p>
            <ul>
            <li>VAT number, tax invoice, exclusive/inclusive amounts</li>
            <li>Unique sequential invoice number (no gaps if your regime requires continuity)</li>
            <li>Clear description of goods or services supplied</li>
            <li>Taxable amount and tax charged separately</li>
            <li>Supplier identity sufficient for the client to claim input credits</li>
            </ul>

            <h2>When to use bulk CSV instead</h2>
            <p>Issuing more than ~10 similar invoices per month? Use <a href="/invoice/bulk">Bulk GST Invoice Generator</a> (Business plan) with GSTIN/HSN-style columns adapted for your jurisdiction — or continue single invoices if volume is low.</p>
            <p>India-specific bulk workflow: <a href="/guides/bulk-gst-invoice-generator">bulk GST invoice guide</a>. Global recurring retainers: <a href="/guides/recurring-invoice-generator">recurring invoice generator</a>.</p>

            <h2>After you generate the PDF</h2>
            <ul>
            <li><strong>Email size limits</strong> — rare for invoices, but if over 25 MB see <a href="/research/attachment-size-limits">attachment size limits research</a>.</li>
            <li><strong>Edit a typo</strong> — regenerate from source data; for client PDFs use <a href="/guides/pdf-to-word-invoice">PDF to Word for invoice</a>.</li>
            <li><strong>Compress before portal upload</strong> — <a href="/guides/compress-gst-invoice-pdf">compress GST invoice PDF</a> if a government portal rejects size.</li>
            </ul>

            <h2>Common mistakes</h2>
            <ul>
            <li>Using a quote layout instead of a tax invoice title when registered for VAT/GST</li>
            <li>Missing VAT vendor number on B2B invoices — client cannot reclaim tax</li>
            <li>Wrong tax rate for mixed supplies — split line items when rates differ</li>
            <li>PDF only in image form (flattened scan) — always send the vector PDF from RatPDF</li>
            </ul>

            <h2>Upgrade prompt</h2>
            <p>Free tier: 3 uses per tool per day. High-volume South Africa agencies upgrade to Pro for logo upload, larger files, and unlimited daily use — <a href="/Subscription/Plans">compare plans</a> · <a href="/compare">tool alternatives</a>.</p>

            
            <h2>VAT registration (R1 million in 12 months)</h2>
            <p>Voluntary registration above R50,000. Standard rate 15% — tax invoice required for VAT-registered vendor supplies.</p>

            <h2>SARS tax invoice fields</h2>
            <p>Supplier name/address/VAT number, serialised invoice number, date, description, value, VAT amount, total.</p>

            <h2>Second example: Cape Town dev shop — export services</h2>
            <p>UK client — zero-rated export of services may apply; Notes document foreign recipient; PDF in ZAR or USD per contract.</p>

            <h2>Payment terms and POPIA</h2>
            <p>Include client VAT number for B2B; avoid unnecessary personal data in PDF body.</p>

            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Create ZAR VAT invoice</strong> <a href="/invoice/create" class="alert-link fw-semibold">Create invoice →</a></div>
            

            
            <h2>Tax invoice vs credit note numbering</h2>
            <p>Credit notes need separate sequence prefix (CN-) — do not reuse invoice numbers for credits.</p>
            

            
            <h2>Choosing invoice layout for South Africa clients</h2>
            <p>Accounts payable teams in South Africa reject PDFs that look like marketing flyers. Use a single-column layout: legal names at top, line items in a table, tax breakdown before total, payment instructions in Notes. RatPDF's default PDF is optimised for printing and email — not screen-only quotes.</p>
            <p>If your client uses SAP, Oracle, or Xero AP automation, they may OCR your PDF — keep VAT vendor number in plain text (not inside a logo image) so extraction succeeds.</p>

            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> Printed ZAR tax invoice with VAT 15% breakdown and VAT vendor number in header</figcaption></figure>

            <h2>Third example: mixed tax rates on one invoice</h2>
            <p><strong>Scenario:</strong> You bill consulting (VAT 15%) plus reimbursable travel (often zero-rated or out of scope depending on rules).</p>
            <ol>
            <li>Line 1 — "Strategy workshop" — taxable at standard rate.</li>
            <li>Line 2 — "Client-approved airfare reimbursement" — separate line, zero tax if documented as disbursement per SARS guidance.</li>
            <li>Notes cite client approval email date — protects you in audit.</li>
            <li>Total shows tax only on taxable lines — client can reconcile to contract.</li>
            </ol>
            <p>When unsure, ask your accountant before sending — amended invoices waste AP time.</p>

            <h2>Freelancer vs registered company letterhead</h2>
            <p><strong>Sole traders</strong> use personal trading name + VAT vendor number where applicable. <strong>Companies</strong> use registered legal entity (Ltd/GmbH/SASU) — mismatch with bank account name delays payment. Match the name on your RatPDF "From" block to the account clients pay.</p>

            <h2>Currency and FX (ZAR)</h2>
            <p>Domestic clients expect ZAR. If contract is USD/EUR but you are South Africa-registered, show ZAR equivalent in Notes with FX rate and date source ("ECB rate 2026-04-01") so finance can verify.</p>
            <p>Cross-reference: <a href="/guides/invoice-generator-usa">USA invoices</a> · <a href="/guides/invoice-generator-india">India GST invoices</a> · <a href="/guides/invoice-generator-uae">Uae invoices</a>.</p>

            <h2>Deposit and progress invoices</h2>
            <p>Large projects split across multiple PDFs — each needs unique invoice number and clear scope reference ("Phase 2 of 4 — API integration"). Never duplicate invoice numbers; SARS audits trace sequences.</p>
            <p>For retainers duplicated monthly see <a href="/guides/recurring-invoice-generator">recurring invoice generator</a>.</p>

            <h2>Credit notes and refunds</h2>
            <p>Issue a new PDF credit note referencing original invoice number — negative amounts or explicit "Credit" title per local practice. Do not edit a PDF already booked in client ERP.</p>

            <h2>Email delivery and size</h2>
            <p>Vector PDFs from RatPDF are usually under 500 KB. Bundling 20 invoices? Zip locally or use bulk workflow. Over 25 MB combined triggers <a href="/research/attachment-size-limits">email attachment limits</a> — rare for single invoices.</p>

            <h2>Editing after send</h2>
            <p>Typo in description? Regenerate corrected PDF with new number if original was already accepted. For third-party PDFs use <a href="/guides/pdf-to-word-invoice">PDF to Word for invoice</a> — not ideal for tax fields; prefer reissue from Create Invoice.</p>

            <h2>Industry notes</h2>
            <h3>Creative agencies</h3>
            <p>Bill concepts and revisions as separate lines — avoids "one line for everything" disputes.</p>
            <h3>IT contractors</h3>
            <p>Reference SOW ticket IDs in description — client procurement matches PO lines.</p>
            <h3>Trades and field services</h3>
            <p>Include job site or project code in Notes — residential clients file by property address.</p>

            <h2>Year-end and accountant handoff</h2>
            <p>Export folder of PDFs by tax year; your accountant ties each to bank deposits. Missing VAT vendor number on B2B PDFs is a common reason year-end adjustments get delayed.</p>

            <h2>RatPDF vs desktop invoice software</h2>
            <p>Desktop tools need installs and licence seats. RatPDF runs in browser — three free uses per tool per day, Pro for agencies. Compare: <a href="/compare">tool alternatives</a>. Research: <a href="/research/freelancer-invoicing-statistics">freelancer invoicing statistics</a>.</p>

            <h2>Pre-send checklist (South Africa)</h2>
            <ol>
            <li>VAT vendor number visible and correct</li>
            <li>Tax rate matches supply type (VAT 15%)</li>
            <li>Client legal name matches contract</li>
            <li>Invoice number unique and sequential</li>
            <li>Payment terms and bank details in Notes</li>
            <li>PDF opens and prints — not a flattened phone photo</li>
            </ol>

            <h2>Local compliance reminders (SARS)</h2>
            <p>Tax law changes — digital service reporting, e-invoicing pilots, and reverse-charge categories — can alter what must appear on your PDF. Bookmark <a href="https://www.sars.gov.za/" rel="noopener noreferrer" target="_blank">SARS</a> and review templates each financial year. Your accountant should approve wording for reverse charge, export, and exempt supplies before you bulk-send to enterprise clients.</p>
            <p>Peer guide for neighbouring workflows: <a href="/guides/invoice-generator-uae">Uae</a>. Pillar: <a href="/guides/invoice-generator-guide">invoice generator guide</a>.</p>

            <h2>Disputes and chargebacks</h2>
            <p>When a client disputes hours or deliverables, your PDF invoice is the billing record — not Slack threads. Keep scope references in line descriptions so dispute resolution references the same text AP already approved. Reissue credit notes rather than editing sent PDFs.</p>

            <h2>Archiving PDFs for audits</h2>
            <p>Use immutable filenames: <code>YYYY-MM-DD_INV-number_client.pdf</code>. Store on encrypted backup; SARS may request invoices years after issuance. RatPDF does not replace accounting ledgers — export totals to your GL monthly.</p>
            

            
            <h2>Payment method block on PDF</h2>
            <p>Include BSB/routing/IBAN, account name, and reference text ("Quote invoice number"). Clients paying via wire need exact match to your bank KYC name — a common delay when freelancers use trading names on invoice but personal name on account.</p>

            <h2>Purchase order matching</h2>
            <p>Enterprise AP matches PO line to invoice line. Copy PO number from buyer portal into Notes; if PO shows quantity 1 at $5,000 do not split across two lines unless PO allows.</p>

            <h2>Sales tax vs withholding</h2>
            <p>VAT 15% on invoice is not the same as income tax withholding. Cross-border B2B may have treaty withholding — accountant handles; invoice shows gross fee per contract.</p>

            <h2>Recurring vs milestone billing</h2>
            <p>Retainers use same description monthly (<a href="/guides/recurring-invoice-generator">recurring guide</a>). Projects use milestone labels — do not mix on one PDF.</p>

            <h2>White-label and agency billing</h2>
            <p>Agencies billing end-client through intermediary still show supplier as your legal entity — Pro logo is cosmetic; tax ID remains yours.</p>

            <h2>PDF accessibility</h2>
            <p>Vector PDFs from RatPDF are searchable — clients with document management systems index VAT vendor number and totals automatically. Flattened JPEG invoices break OCR AP pipelines.</p>

            <h2>Version control</h2>
            <p>Filename suffix <code>-v2</code> only for drafts never sent. Sent invoices get new numbers, not version bumps.</p>

            <h2>Integration checklist with accountant</h2>
            <ol>
            <li>Confirm tax rate list for your supplies</li>
            <li>Approve invoice number format before first send</li>
            <li>Map RatPDF PDF folder to GL import monthly</li>
            <li>Review one sample PDF before bulk client rollout</li>
            </ol>
            

            
            <h2>Related guides &amp; cluster links</h2>
            <ul>
            <li><a href="/guides/invoice-generator-guide">Invoice generator guide</a></li>
            <li><a href="/guides/invoice-generator-india">Invoice generator India</a></li>
            <li><a href="/guides/invoice-generator-usa">Invoice generator USA</a></li>
            <li><a href="/guides/recurring-invoice-generator">Recurring invoice generator</a></li>
            </ul>
            <p>Research: <a href="/research/freelancer-invoicing-statistics">Freelancer invoicing statistics</a> · Compare: <a href="/compare">PDF &amp; business tool alternatives</a></p>
            <p class="mt-4"><a href="/invoice/create" class="btn btn-primary">Create ZAR invoice</a></p>
            """;

        private const string InvoiceGeneratorUae = """
            <h2>UAE tax invoices for freelancers and SMBs</h2>
            <p>Businesses in UAE need clear PDF tax invoices that clients and accountants can file without rework. RatPDF's <a href="/invoice/create">Create Invoice</a> tool produces print-ready PDFs in <strong>AED</strong> with configurable tax lines — no desktop software install.</p>
            <p>This guide covers mandatory fields per FTA expectations, a real-world example, and how to avoid the template mistakes that delay payment.</p>

            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> RatPDF Create Invoice form with AED currency and VAT 5% line items</figcaption></figure>

            <h2>Real example: Dubai consultancy billing Abu Dhabi mainland client AED 18,000 + 5% VAT</h2>
            <p><strong>Scenario:</strong> You delivered a fixed-scope project. The client needs a PDF tax invoice before accounts payable runs Friday.</p>
            <ol>
            <li>Open <a href="/invoice/create">Create Invoice</a> — set currency to <strong>AED</strong>.</li>
            <li><strong>From:</strong> legal business name, address, TRN in the header block.</li>
            <li><strong>Bill to:</strong> client legal name and address (add their tax ID for B2B).</li>
            <li><strong>Line items:</strong> "Phase 1 — design delivery" · qty 1 · rate matching contract.</li>
            <li><strong>Tax:</strong> set tax name to GST/VAT/TVA/USt as applicable — rate <strong>VAT 5%</strong> when registered.</li>
            <li><strong>Notes:</strong> payment terms (Net 14), bank details, PO number if provided.</li>
            <li>Click <strong>Generate PDF</strong> — email the PDF; archive a copy for FTA records.</li>
            </ol>

            <div class="rp-mid-cta alert alert-primary my-4"><strong>Issue your next AED invoice in under two minutes</strong> <a href="/invoice/create" class="alert-link fw-semibold">Create invoice free →</a></div>

            <h2>Mandatory fields checklist (FTA)</h2>
            <p>Tax invoice requirements evolve — verify on <a href="https://tax.gov.ae/" rel="noopener noreferrer" target="_blank">FTA</a> before changing templates. Commonly required:</p>
            <ul>
            <li>TRN, supply date, VAT amount, Arabic/English business names if required</li>
            <li>Unique sequential invoice number (no gaps if your regime requires continuity)</li>
            <li>Clear description of goods or services supplied</li>
            <li>Taxable amount and tax charged separately</li>
            <li>Supplier identity sufficient for the client to claim input credits</li>
            </ul>

            <h2>When to use bulk CSV instead</h2>
            <p>Issuing more than ~10 similar invoices per month? Use <a href="/invoice/bulk">Bulk GST Invoice Generator</a> (Business plan) with GSTIN/HSN-style columns adapted for your jurisdiction — or continue single invoices if volume is low.</p>
            <p>India-specific bulk workflow: <a href="/guides/bulk-gst-invoice-generator">bulk GST invoice guide</a>. Global recurring retainers: <a href="/guides/recurring-invoice-generator">recurring invoice generator</a>.</p>

            <h2>After you generate the PDF</h2>
            <ul>
            <li><strong>Email size limits</strong> — rare for invoices, but if over 25 MB see <a href="/research/attachment-size-limits">attachment size limits research</a>.</li>
            <li><strong>Edit a typo</strong> — regenerate from source data; for client PDFs use <a href="/guides/pdf-to-word-invoice">PDF to Word for invoice</a>.</li>
            <li><strong>Compress before portal upload</strong> — <a href="/guides/compress-gst-invoice-pdf">compress GST invoice PDF</a> if a government portal rejects size.</li>
            </ul>

            <h2>Common mistakes</h2>
            <ul>
            <li>Using a quote layout instead of a tax invoice title when registered for VAT/GST</li>
            <li>Missing TRN on B2B invoices — client cannot reclaim tax</li>
            <li>Wrong tax rate for mixed supplies — split line items when rates differ</li>
            <li>PDF only in image form (flattened scan) — always send the vector PDF from RatPDF</li>
            </ul>

            <h2>Upgrade prompt</h2>
            <p>Free tier: 3 uses per tool per day. High-volume UAE agencies upgrade to Pro for logo upload, larger files, and unlimited daily use — <a href="/Subscription/Plans">compare plans</a> · <a href="/compare">tool alternatives</a>.</p>

            
            <h2>UAE VAT (5%) — TRN on every B2B invoice</h2>
            <p>Tax Registration Number (TRN) mandatory for registered suppliers. FTA requires specific Arabic/English elements on tax invoices — verify latest FTA public clarifications.</p>

            <h2>Second example: Dubai consultancy — mainland client</h2>
            <p>AED 45,000 professional fees + AED 2,250 VAT — TRN, supply date, clear description of advisory scope.</p>

            <h2>Designated zones and exports</h2>
            <p>Supplies to designated zones or exports may be zero-rated — document in Notes; tax agent confirms.</p>

            <h2>Free zone vs mainland</h2>
            <p>Invoice legal entity name must match trade licence — mismatches block client VAT recovery.</p>

            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Create AED invoice</strong> <a href="/invoice/create" class="alert-link fw-semibold">Create invoice →</a></div>
            

            
            <h2>Emirate-specific trade licences</h2>
            <p>Invoice address must match licence emirate — DMCC vs mainland Dubai entities differ for client VAT recovery.</p>
            

            
            <h2>Choosing invoice layout for UAE clients</h2>
            <p>Accounts payable teams in UAE reject PDFs that look like marketing flyers. Use a single-column layout: legal names at top, line items in a table, tax breakdown before total, payment instructions in Notes. RatPDF's default PDF is optimised for printing and email — not screen-only quotes.</p>
            <p>If your client uses SAP, Oracle, or Xero AP automation, they may OCR your PDF — keep TRN in plain text (not inside a logo image) so extraction succeeds.</p>

            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> Printed AED tax invoice with VAT 5% breakdown and TRN in header</figcaption></figure>

            <h2>Third example: mixed tax rates on one invoice</h2>
            <p><strong>Scenario:</strong> You bill consulting (VAT 5%) plus reimbursable travel (often zero-rated or out of scope depending on rules).</p>
            <ol>
            <li>Line 1 — "Strategy workshop" — taxable at standard rate.</li>
            <li>Line 2 — "Client-approved airfare reimbursement" — separate line, zero tax if documented as disbursement per FTA guidance.</li>
            <li>Notes cite client approval email date — protects you in audit.</li>
            <li>Total shows tax only on taxable lines — client can reconcile to contract.</li>
            </ol>
            <p>When unsure, ask your accountant before sending — amended invoices waste AP time.</p>

            <h2>Freelancer vs registered company letterhead</h2>
            <p><strong>Sole traders</strong> use personal trading name + TRN where applicable. <strong>Companies</strong> use registered legal entity (Ltd/GmbH/SASU) — mismatch with bank account name delays payment. Match the name on your RatPDF "From" block to the account clients pay.</p>

            <h2>Currency and FX (AED)</h2>
            <p>Domestic clients expect AED. If contract is USD/EUR but you are UAE-registered, show AED equivalent in Notes with FX rate and date source ("ECB rate 2026-04-01") so finance can verify.</p>
            <p>Cross-reference: <a href="/guides/invoice-generator-usa">USA invoices</a> · <a href="/guides/invoice-generator-india">India GST invoices</a> · <a href="/guides/invoice-generator-south-africa">South Africa invoices</a>.</p>

            <h2>Deposit and progress invoices</h2>
            <p>Large projects split across multiple PDFs — each needs unique invoice number and clear scope reference ("Phase 2 of 4 — API integration"). Never duplicate invoice numbers; FTA audits trace sequences.</p>
            <p>For retainers duplicated monthly see <a href="/guides/recurring-invoice-generator">recurring invoice generator</a>.</p>

            <h2>Credit notes and refunds</h2>
            <p>Issue a new PDF credit note referencing original invoice number — negative amounts or explicit "Credit" title per local practice. Do not edit a PDF already booked in client ERP.</p>

            <h2>Email delivery and size</h2>
            <p>Vector PDFs from RatPDF are usually under 500 KB. Bundling 20 invoices? Zip locally or use bulk workflow. Over 25 MB combined triggers <a href="/research/attachment-size-limits">email attachment limits</a> — rare for single invoices.</p>

            <h2>Editing after send</h2>
            <p>Typo in description? Regenerate corrected PDF with new number if original was already accepted. For third-party PDFs use <a href="/guides/pdf-to-word-invoice">PDF to Word for invoice</a> — not ideal for tax fields; prefer reissue from Create Invoice.</p>

            <h2>Industry notes</h2>
            <h3>Creative agencies</h3>
            <p>Bill concepts and revisions as separate lines — avoids "one line for everything" disputes.</p>
            <h3>IT contractors</h3>
            <p>Reference SOW ticket IDs in description — client procurement matches PO lines.</p>
            <h3>Trades and field services</h3>
            <p>Include job site or project code in Notes — residential clients file by property address.</p>

            <h2>Year-end and accountant handoff</h2>
            <p>Export folder of PDFs by tax year; your accountant ties each to bank deposits. Missing TRN on B2B PDFs is a common reason year-end adjustments get delayed.</p>

            <h2>RatPDF vs desktop invoice software</h2>
            <p>Desktop tools need installs and licence seats. RatPDF runs in browser — three free uses per tool per day, Pro for agencies. Compare: <a href="/compare">tool alternatives</a>. Research: <a href="/research/freelancer-invoicing-statistics">freelancer invoicing statistics</a>.</p>

            <h2>Pre-send checklist (UAE)</h2>
            <ol>
            <li>TRN visible and correct</li>
            <li>Tax rate matches supply type (VAT 5%)</li>
            <li>Client legal name matches contract</li>
            <li>Invoice number unique and sequential</li>
            <li>Payment terms and bank details in Notes</li>
            <li>PDF opens and prints — not a flattened phone photo</li>
            </ol>

            <h2>Local compliance reminders (FTA)</h2>
            <p>Tax law changes — digital service reporting, e-invoicing pilots, and reverse-charge categories — can alter what must appear on your PDF. Bookmark <a href="https://tax.gov.ae/" rel="noopener noreferrer" target="_blank">FTA</a> and review templates each financial year. Your accountant should approve wording for reverse charge, export, and exempt supplies before you bulk-send to enterprise clients.</p>
            <p>Peer guide for neighbouring workflows: <a href="/guides/invoice-generator-south-africa">South Africa</a>. Pillar: <a href="/guides/invoice-generator-guide">invoice generator guide</a>.</p>

            <h2>Disputes and chargebacks</h2>
            <p>When a client disputes hours or deliverables, your PDF invoice is the billing record — not Slack threads. Keep scope references in line descriptions so dispute resolution references the same text AP already approved. Reissue credit notes rather than editing sent PDFs.</p>

            <h2>Archiving PDFs for audits</h2>
            <p>Use immutable filenames: <code>YYYY-MM-DD_INV-number_client.pdf</code>. Store on encrypted backup; FTA may request invoices years after issuance. RatPDF does not replace accounting ledgers — export totals to your GL monthly.</p>
            

            
            <h2>Payment method block on PDF</h2>
            <p>Include BSB/routing/IBAN, account name, and reference text ("Quote invoice number"). Clients paying via wire need exact match to your bank KYC name — a common delay when freelancers use trading names on invoice but personal name on account.</p>

            <h2>Purchase order matching</h2>
            <p>Enterprise AP matches PO line to invoice line. Copy PO number from buyer portal into Notes; if PO shows quantity 1 at $5,000 do not split across two lines unless PO allows.</p>

            <h2>Sales tax vs withholding</h2>
            <p>VAT 5% on invoice is not the same as income tax withholding. Cross-border B2B may have treaty withholding — accountant handles; invoice shows gross fee per contract.</p>

            <h2>Recurring vs milestone billing</h2>
            <p>Retainers use same description monthly (<a href="/guides/recurring-invoice-generator">recurring guide</a>). Projects use milestone labels — do not mix on one PDF.</p>

            <h2>White-label and agency billing</h2>
            <p>Agencies billing end-client through intermediary still show supplier as your legal entity — Pro logo is cosmetic; tax ID remains yours.</p>

            <h2>PDF accessibility</h2>
            <p>Vector PDFs from RatPDF are searchable — clients with document management systems index TRN and totals automatically. Flattened JPEG invoices break OCR AP pipelines.</p>

            <h2>Version control</h2>
            <p>Filename suffix <code>-v2</code> only for drafts never sent. Sent invoices get new numbers, not version bumps.</p>

            <h2>Integration checklist with accountant</h2>
            <ol>
            <li>Confirm tax rate list for your supplies</li>
            <li>Approve invoice number format before first send</li>
            <li>Map RatPDF PDF folder to GL import monthly</li>
            <li>Review one sample PDF before bulk client rollout</li>
            </ol>
            

            
            <h2>Related guides &amp; cluster links</h2>
            <ul>
            <li><a href="/guides/invoice-generator-guide">Invoice generator guide</a></li>
            <li><a href="/guides/invoice-generator-india">Invoice generator India</a></li>
            <li><a href="/guides/invoice-generator-usa">Invoice generator USA</a></li>
            <li><a href="/guides/recurring-invoice-generator">Recurring invoice generator</a></li>
            </ul>
            <p>Research: <a href="/research/freelancer-invoicing-statistics">Freelancer invoicing statistics</a> · Compare: <a href="/compare">PDF &amp; business tool alternatives</a></p>
            <p class="mt-4"><a href="/invoice/create" class="btn btn-primary">Create AED invoice</a></p>
            """;

        private const string InvoiceGeneratorUk = """
            <h2>United Kingdom tax invoices for freelancers and SMBs</h2>
            <p>Businesses in United Kingdom need clear PDF tax invoices that clients and accountants can file without rework. RatPDF's <a href="/invoice/create">Create Invoice</a> tool produces print-ready PDFs in <strong>GBP</strong> with configurable tax lines — no desktop software install.</p>
            <p>This guide covers mandatory fields per HMRC expectations, a real-world example, and how to avoid the template mistakes that delay payment.</p>

            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> RatPDF Create Invoice form with GBP currency and VAT 20% line items</figcaption></figure>

            <h2>Real example: London Ltd billing Manchester Ltd £2,150 + VAT</h2>
            <p><strong>Scenario:</strong> You delivered a fixed-scope project. The client needs a PDF tax invoice before accounts payable runs Friday.</p>
            <ol>
            <li>Open <a href="/invoice/create">Create Invoice</a> — set currency to <strong>GBP</strong>.</li>
            <li><strong>From:</strong> legal business name, address, VAT registration number in the header block.</li>
            <li><strong>Bill to:</strong> client legal name and address (add their tax ID for B2B).</li>
            <li><strong>Line items:</strong> "Phase 1 — design delivery" · qty 1 · rate matching contract.</li>
            <li><strong>Tax:</strong> set tax name to GST/VAT/TVA/USt as applicable — rate <strong>VAT 20%</strong> when registered.</li>
            <li><strong>Notes:</strong> payment terms (Net 14), bank details, PO number if provided.</li>
            <li>Click <strong>Generate PDF</strong> — email the PDF; archive a copy for HMRC records.</li>
            </ol>

            <div class="rp-mid-cta alert alert-primary my-4"><strong>Issue your next GBP invoice in under two minutes</strong> <a href="/invoice/create" class="alert-link fw-semibold">Create invoice free →</a></div>

            <h2>Mandatory fields checklist (HMRC)</h2>
            <p>Tax invoice requirements evolve — verify on <a href="https://www.gov.uk/government/organisations/hm-revenue-customs" rel="noopener noreferrer" target="_blank">HMRC</a> before changing templates. Commonly required:</p>
            <ul>
            <li>Unique invoice number, time of supply, VAT rate, VAT amount</li>
            <li>Unique sequential invoice number (no gaps if your regime requires continuity)</li>
            <li>Clear description of goods or services supplied</li>
            <li>Taxable amount and tax charged separately</li>
            <li>Supplier identity sufficient for the client to claim input credits</li>
            </ul>

            <h2>When to use bulk CSV instead</h2>
            <p>Issuing more than ~10 similar invoices per month? Use <a href="/invoice/bulk">Bulk GST Invoice Generator</a> (Business plan) with GSTIN/HSN-style columns adapted for your jurisdiction — or continue single invoices if volume is low.</p>
            <p>India-specific bulk workflow: <a href="/guides/bulk-gst-invoice-generator">bulk GST invoice guide</a>. Global recurring retainers: <a href="/guides/recurring-invoice-generator">recurring invoice generator</a>.</p>

            <h2>After you generate the PDF</h2>
            <ul>
            <li><strong>Email size limits</strong> — rare for invoices, but if over 25 MB see <a href="/research/attachment-size-limits">attachment size limits research</a>.</li>
            <li><strong>Edit a typo</strong> — regenerate from source data; for client PDFs use <a href="/guides/pdf-to-word-invoice">PDF to Word for invoice</a>.</li>
            <li><strong>Compress before portal upload</strong> — <a href="/guides/compress-gst-invoice-pdf">compress GST invoice PDF</a> if a government portal rejects size.</li>
            </ul>

            <h2>Common mistakes</h2>
            <ul>
            <li>Using a quote layout instead of a tax invoice title when registered for VAT/GST</li>
            <li>Missing VAT registration number on B2B invoices — client cannot reclaim tax</li>
            <li>Wrong tax rate for mixed supplies — split line items when rates differ</li>
            <li>PDF only in image form (flattened scan) — always send the vector PDF from RatPDF</li>
            </ul>

            <h2>Upgrade prompt</h2>
            <p>Free tier: 3 uses per tool per day. High-volume United Kingdom agencies upgrade to Pro for logo upload, larger files, and unlimited daily use — <a href="/Subscription/Plans">compare plans</a> · <a href="/compare">tool alternatives</a>.</p>

            
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
            

            
            <h2>CIS construction industry</h2>
            <p>Construction subcontractors may need CIS deduction shown — coordinate with HMRC CIS rules beyond standard VAT invoice.</p>
            

            
            <h2>Choosing invoice layout for United Kingdom clients</h2>
            <p>Accounts payable teams in United Kingdom reject PDFs that look like marketing flyers. Use a single-column layout: legal names at top, line items in a table, tax breakdown before total, payment instructions in Notes. RatPDF's default PDF is optimised for printing and email — not screen-only quotes.</p>
            <p>If your client uses SAP, Oracle, or Xero AP automation, they may OCR your PDF — keep VAT registration number in plain text (not inside a logo image) so extraction succeeds.</p>

            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> Printed GBP tax invoice with VAT 20% breakdown and VAT registration number in header</figcaption></figure>

            <h2>Third example: mixed tax rates on one invoice</h2>
            <p><strong>Scenario:</strong> You bill consulting (VAT 20%) plus reimbursable travel (often zero-rated or out of scope depending on rules).</p>
            <ol>
            <li>Line 1 — "Strategy workshop" — taxable at standard rate.</li>
            <li>Line 2 — "Client-approved airfare reimbursement" — separate line, zero tax if documented as disbursement per HMRC guidance.</li>
            <li>Notes cite client approval email date — protects you in audit.</li>
            <li>Total shows tax only on taxable lines — client can reconcile to contract.</li>
            </ol>
            <p>When unsure, ask your accountant before sending — amended invoices waste AP time.</p>

            <h2>Freelancer vs registered company letterhead</h2>
            <p><strong>Sole traders</strong> use personal trading name + VAT registration number where applicable. <strong>Companies</strong> use registered legal entity (Ltd/GmbH/SASU) — mismatch with bank account name delays payment. Match the name on your RatPDF "From" block to the account clients pay.</p>

            <h2>Currency and FX (GBP)</h2>
            <p>Domestic clients expect GBP. If contract is USD/EUR but you are United Kingdom-registered, show GBP equivalent in Notes with FX rate and date source ("ECB rate 2026-04-01") so finance can verify.</p>
            <p>Cross-reference: <a href="/guides/invoice-generator-usa">USA invoices</a> · <a href="/guides/invoice-generator-india">India GST invoices</a> · <a href="/guides/invoice-generator-germany">Germany invoices</a>.</p>

            <h2>Deposit and progress invoices</h2>
            <p>Large projects split across multiple PDFs — each needs unique invoice number and clear scope reference ("Phase 2 of 4 — API integration"). Never duplicate invoice numbers; HMRC audits trace sequences.</p>
            <p>For retainers duplicated monthly see <a href="/guides/recurring-invoice-generator">recurring invoice generator</a>.</p>

            <h2>Credit notes and refunds</h2>
            <p>Issue a new PDF credit note referencing original invoice number — negative amounts or explicit "Credit" title per local practice. Do not edit a PDF already booked in client ERP.</p>

            <h2>Email delivery and size</h2>
            <p>Vector PDFs from RatPDF are usually under 500 KB. Bundling 20 invoices? Zip locally or use bulk workflow. Over 25 MB combined triggers <a href="/research/attachment-size-limits">email attachment limits</a> — rare for single invoices.</p>

            <h2>Editing after send</h2>
            <p>Typo in description? Regenerate corrected PDF with new number if original was already accepted. For third-party PDFs use <a href="/guides/pdf-to-word-invoice">PDF to Word for invoice</a> — not ideal for tax fields; prefer reissue from Create Invoice.</p>

            <h2>Industry notes</h2>
            <h3>Creative agencies</h3>
            <p>Bill concepts and revisions as separate lines — avoids "one line for everything" disputes.</p>
            <h3>IT contractors</h3>
            <p>Reference SOW ticket IDs in description — client procurement matches PO lines.</p>
            <h3>Trades and field services</h3>
            <p>Include job site or project code in Notes — residential clients file by property address.</p>

            <h2>Year-end and accountant handoff</h2>
            <p>Export folder of PDFs by tax year; your accountant ties each to bank deposits. Missing VAT registration number on B2B PDFs is a common reason year-end adjustments get delayed.</p>

            <h2>RatPDF vs desktop invoice software</h2>
            <p>Desktop tools need installs and licence seats. RatPDF runs in browser — three free uses per tool per day, Pro for agencies. Compare: <a href="/compare">tool alternatives</a>. Research: <a href="/research/freelancer-invoicing-statistics">freelancer invoicing statistics</a>.</p>

            <h2>Pre-send checklist (United Kingdom)</h2>
            <ol>
            <li>VAT registration number visible and correct</li>
            <li>Tax rate matches supply type (VAT 20%)</li>
            <li>Client legal name matches contract</li>
            <li>Invoice number unique and sequential</li>
            <li>Payment terms and bank details in Notes</li>
            <li>PDF opens and prints — not a flattened phone photo</li>
            </ol>

            <h2>Local compliance reminders (HMRC)</h2>
            <p>Tax law changes — digital service reporting, e-invoicing pilots, and reverse-charge categories — can alter what must appear on your PDF. Bookmark <a href="https://www.gov.uk/government/organisations/hm-revenue-customs" rel="noopener noreferrer" target="_blank">HMRC</a> and review templates each financial year. Your accountant should approve wording for reverse charge, export, and exempt supplies before you bulk-send to enterprise clients.</p>
            <p>Peer guide for neighbouring workflows: <a href="/guides/invoice-generator-germany">Germany</a>. Pillar: <a href="/guides/invoice-generator-guide">invoice generator guide</a>.</p>

            <h2>Disputes and chargebacks</h2>
            <p>When a client disputes hours or deliverables, your PDF invoice is the billing record — not Slack threads. Keep scope references in line descriptions so dispute resolution references the same text AP already approved. Reissue credit notes rather than editing sent PDFs.</p>

            <h2>Archiving PDFs for audits</h2>
            <p>Use immutable filenames: <code>YYYY-MM-DD_INV-number_client.pdf</code>. Store on encrypted backup; HMRC may request invoices years after issuance. RatPDF does not replace accounting ledgers — export totals to your GL monthly.</p>
            

            
            <h2>Payment method block on PDF</h2>
            <p>Include BSB/routing/IBAN, account name, and reference text ("Quote invoice number"). Clients paying via wire need exact match to your bank KYC name — a common delay when freelancers use trading names on invoice but personal name on account.</p>

            <h2>Purchase order matching</h2>
            <p>Enterprise AP matches PO line to invoice line. Copy PO number from buyer portal into Notes; if PO shows quantity 1 at $5,000 do not split across two lines unless PO allows.</p>

            <h2>Sales tax vs withholding</h2>
            <p>VAT 20% on invoice is not the same as income tax withholding. Cross-border B2B may have treaty withholding — accountant handles; invoice shows gross fee per contract.</p>

            <h2>Recurring vs milestone billing</h2>
            <p>Retainers use same description monthly (<a href="/guides/recurring-invoice-generator">recurring guide</a>). Projects use milestone labels — do not mix on one PDF.</p>

            <h2>White-label and agency billing</h2>
            <p>Agencies billing end-client through intermediary still show supplier as your legal entity — Pro logo is cosmetic; tax ID remains yours.</p>

            <h2>PDF accessibility</h2>
            <p>Vector PDFs from RatPDF are searchable — clients with document management systems index VAT registration number and totals automatically. Flattened JPEG invoices break OCR AP pipelines.</p>

            <h2>Version control</h2>
            <p>Filename suffix <code>-v2</code> only for drafts never sent. Sent invoices get new numbers, not version bumps.</p>

            <h2>Integration checklist with accountant</h2>
            <ol>
            <li>Confirm tax rate list for your supplies</li>
            <li>Approve invoice number format before first send</li>
            <li>Map RatPDF PDF folder to GL import monthly</li>
            <li>Review one sample PDF before bulk client rollout</li>
            </ol>
            

            
            <h2>Related guides &amp; cluster links</h2>
            <ul>
            <li><a href="/guides/invoice-generator-guide">Invoice generator guide</a></li>
            <li><a href="/guides/invoice-generator-india">Invoice generator India</a></li>
            <li><a href="/guides/invoice-generator-usa">Invoice generator USA</a></li>
            <li><a href="/guides/recurring-invoice-generator">Recurring invoice generator</a></li>
            </ul>
            <p>Research: <a href="/research/freelancer-invoicing-statistics">Freelancer invoicing statistics</a> · Compare: <a href="/compare">PDF &amp; business tool alternatives</a></p>
            <p class="mt-4"><a href="/invoice/create" class="btn btn-primary">Create GBP invoice</a></p>
            """;

        private const string BulkGstInvoiceGenerator = """
            <h2>Bulk GST invoice PDF generation for CA firms and finance teams</h2>
            <p>Indian B2B billing at scale means dozens of GST tax invoices each month — each with GSTIN, HSN/SAC, place of supply, and CGST/SGST or IGST split. RatPDF's <a href="/invoice/bulk">Bulk GST Invoice Generator</a> turns a CSV row per invoice into a ZIP of compliant PDFs.</p>
            <p>Parent guides: <a href="/guides/invoice-generator-india">Invoice generator India</a> · <a href="/guides/invoice-generator-guide">invoice generator guide</a>.</p>

            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> Bulk invoice CSV upload screen with GSTIN and HSN columns preview</figcaption></figure>

            <h2>Real example: CA firm month-end client billing</h2>
            <p><strong>Scenario:</strong> A Pune CA firm bills 48 retainer clients on the 1st — same service description, different GSTIN and amounts.</p>
            <ol>
            <li>Export client master from Tally/Excel with GSTIN, place of supply, fee, IGST flag.</li>
            <li>Map columns to RatPDF CSV template (download from bulk invoice page).</li>
            <li>Validate GSTIN format with <a href="/gst-invoice-checker">GST invoice checker</a> on 3 sample rows.</li>
            <li>Upload CSV on <a href="/invoice/bulk">Bulk GST Invoice Generator</a> (Business plan).</li>
            <li>Download ZIP — filenames like <code>INV-2026-04-ClientName.pdf</code>.</li>
            <li>Email each PDF from your mail client; archive ZIP on secure drive for 6+ years.</li>
            </ol>

            <div class="rp-mid-cta alert alert-primary my-4"><strong>Generate up to 100 GST invoice PDFs per batch</strong> <a href="/invoice/bulk" class="alert-link fw-semibold">Open bulk GST invoices →</a></div>

            <h2>CSV column reference</h2>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>Column</th><th>Purpose</th></tr></thead>
            <tbody>
            <tr><td>supplier_gstin</td><td>Your 15-character GSTIN</td></tr>
            <tr><td>customer_gstin</td><td>Client GSTIN for B2B ITC</td></tr>
            <tr><td>hsn_sac</td><td>HSN for goods / SAC for services</td></tr>
            <tr><td>place_of_supply</td><td>State code — drives CGST/SGST vs IGST</td></tr>
            <tr><td>taxable_value / cgst / sgst / igst</td><td>Split per row</td></tr>
            <tr><td>invoice_no / invoice_date</td><td>Sequential numbering discipline</td></tr>
            </tbody>
            </table></div>
            <p>Official reference: <a href="https://www.gst.gov.in/" rel="noopener noreferrer" target="_blank">GST Portal</a>. Research: <a href="/research/freelancer-invoicing-statistics">freelancer invoicing statistics</a>.</p>

            <h2>Single invoice vs bulk — decision tree</h2>
            <ul>
            <li><strong>1–5 invoices/month</strong> → <a href="/invoice/create">Create Invoice</a> form (free tier).</li>
            <li><strong>10–100/month</strong> → bulk CSV on Business plan.</li>
            <li><strong>E-invoice IRN required</strong> → generate IRN on NIC portal; RatPDF PDF is human-readable copy — see <a href="/guides/e-invoicing-india-pdf">e-invoicing India PDF</a>.</li>
            </ul>

            <h2>QA before sending to clients</h2>
            <ul>
            <li>Spot-check 3 PDFs: GSTIN, HSN, tax math, spelling of legal names</li>
            <li>Confirm place of supply matches IGST vs CGST/SGST on each row</li>
            <li>Run <a href="/gst-invoice-checker">GST invoice checker</a> on worst-case row (highest value)</li>
            </ul>

            <h2>Related cluster links</h2>
            <ul>
            <li><a href="/guides/invoice-generator-india">Invoice generator India</a></li>
            <li><a href="/guides/gst-invoice-format-india">GST invoice format India</a></li>
            <li><a href="/guides/recurring-invoice-generator">Recurring invoice generator</a></li>
            </ul>
            <p>Compare: <a href="/compare">business tool alternatives</a></p>
            
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
            
            
            <h2>Sample CSV row (illustrative)</h2>
            <pre class="bg-light p-3 small"><code>supplier_gstin,customer_gstin,invoice_no,invoice_date,description,hsn_sac,taxable_value,igst,invoice_value
            27AAAAA0000A1Z5,29BBBBB1111B1Z6,INV-2026-100,2026-04-01,Retainer April,998314,100000,18000,118000</code></pre>
            <p>Adapt columns to your practice — template on bulk invoice page is authoritative.</p>

            <h2>Reconciliation with GSTR-2B</h2>
            <p>Clients match your GSTIN and invoice number to their 2B — typos block ITC. Double-check customer_gstin column before upload.</p>

            <h2>E-invoice threshold watch</h2>
            <p>Businesses above notified turnover must generate IRN on NIC portal — RatPDF PDF complements IRN QR invoice; see <a href="/guides/e-invoicing-india-pdf">e-invoicing India PDF</a>.</p>

            <h2>Multi-branch firms</h2>
            <p>Separate supplier_gstin per branch row — never mix states in one GSTIN column.</p>

            <h2>Compression before email</h2>
            <p>Large ZIP of 100 PDFs may exceed email limits — use secure file share; individual PDFs rarely need <a href="/guides/compress-gst-invoice-pdf">compression</a>.</p>

            <h2>Training junior staff</h2>
            <p>Document your CSV mapping in a one-page SOP — which Tally export column maps to supplier_gstin, who approves upload, where ZIP is stored. Reduces month-end errors when seniors are on leave.</p>

            <h2>International clients on Indian GST invoices</h2>
            <p>Export of services may be zero-rated — separate CSV template row with LUT reference in Notes; confirm with CA before mixing domestic and export rows in one batch.</p>
            
            
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
            

            <h2>Year-one bulk maturity model</h2>
            <p>Month 1–3: manual CSV with heavy QA. Month 4–6: Excel macros pull from Tally. Month 7+: optional API export from billing system into CSV template. Each stage reduces error rate — jumping to month 7 workflow without month 1 discipline causes GSTN mismatches.</p>
            <p>Compare: <a href="/compare">business tool alternatives</a> · Single invoice fallback: <a href="/invoice/create">Create Invoice</a>.</p>

            <h2>Client FAQ after bulk send</h2>
            <p><strong>Wrong GSTIN on one PDF?</strong> Issue credit note row next batch — never resend same invoice number. <strong>Missing HSN?</strong> Regenerate row from CSV after fix. <strong>ZIP too large?</strong> Use secure share link instead of email attachment.</p>

            <h2>GST compliance officer handoff</h2>
            <p>Provide compliance team: CSV upload log, ZIP SHA-256, sample PDF set, and GSTR-1 draft screenshot. Bulk workflow succeeds when finance and compliance share the same invoice number authority — document who owns the master CSV.</p>

            <p>End-to-end path: <a href="/guides/invoice-generator-india">India guide</a> → CSV prep → <a href="/invoice/bulk">bulk tool</a> → client email → GSTR-1. Research: <a href="/research/freelancer-invoicing-statistics">freelancer invoicing statistics</a>. Compare: <a href="/compare">tool alternatives</a>. Upgrade: <a href="/Subscription/Plans">Business plan</a> for bulk batches.</p>

            <p class="mt-4"><a href="/invoice/bulk" class="btn btn-primary">Start bulk GST batch</a> · <a href="/invoice/create">Single invoice</a></p>
            """;

        private const string RecurringInvoiceGenerator = """
            <h2>Recurring invoices for retainers, subscriptions, and GST billing</h2>
            <p>RatPDF does not auto-charge cards or send scheduled emails — you control each billing period. This guide shows a repeatable workflow for monthly retainers in India (GST) and globally using <a href="/invoice/create">Create Invoice</a> and optional <a href="/invoice/bulk">bulk CSV</a>.</p>

            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> Create Invoice with saved client block and updated invoice date</figcaption></figure>

            <h2>Real example: ₹1.2L monthly retainer (India B2B)</h2>
            <ol>
            <li>Day 1: duplicate last month's line items in Create Invoice — update invoice date and number.</li>
            <li>Verify GST rate unchanged; adjust if scope changed mid-month.</li>
            <li>Generate PDF — send before 11:00 IST so client AP runs same day.</li>
            <li>Archive PDF path: <code>2026/04/ClientName-INV-042.pdf</code></li>
            <li>Log in spreadsheet for GSTR-1 reconciliation.</li>
            </ol>

            <div class="rp-mid-cta alert alert-primary my-4"><strong>Generate this month's retainer PDF now.</strong> <a href="/invoice/create" class="alert-link fw-semibold">Create invoice →</a></div>

            <h2>Global recurring patterns</h2>
            <h3>USD/EUR freelance retainer</h3>
            <p>Set currency per contract; note "Services for [Month Year]" in description. Wire details in Notes. Guides: <a href="/guides/invoice-generator-usa">USA</a> · <a href="/guides/invoice-generator-uk">UK</a> · <a href="/guides/invoice-generator-germany">Germany</a>.</p>
            <h3>12 identical seats (SaaS-style manual billing)</h3>
            <p>Use bulk CSV with one row per customer if amounts differ; same template row duplicated if identical — Business plan.</p>

            <h2>GST-specific recurring tips (India)</h2>
            <ul>
            <li>Same HSN/SAC each month unless service category changed</li>
            <li>Place of supply fixed per client — wrong split blocks client ITC</li>
            <li>Credit notes for partial months — separate PDF, do not edit sent invoice PDF</li>
            </ul>
            <p>Research: <a href="/research/freelancer-invoicing-statistics">Freelancer invoicing statistics</a> · Compare: <a href="/compare">RatPDF vs alternatives</a></p>

            
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
            
            
            <h2>Contract clause → PDF fields mapping</h2>
            <p>Master service agreement defines rate, currency, tax, payment days — mirror exactly on PDF. Drift between contract and invoice triggers disputes.</p>

            <h2>Indexation and CPI increases</h2>
            <p>Annual uplift — update rate on anniversary invoice; cite clause in Notes ("Year 2 rate per MSA §4.2").</p>

            <h2>Time-tracking integration</h2>
            <p>Export Harvest/Toggl hours to line items — manual but transparent for T&amp;M retainers.</p>

            <h2>Collections sequence template</h2>
            <ol>
            <li>Day 0 — PDF invoice email</li>
            <li>Day 7 — reminder with same PDF</li>
            <li>Day 14 — call AP contact</li>
            <li>Day 30 — formal notice per contract</li>
            </ol>

            <h2>Volume upgrade path</h2>
            <p>More than 15 retainers monthly — evaluate <a href="/invoice/bulk">bulk CSV</a> or Pro unlimited tier.</p>

            <h2>Tax period alignment</h2>
            <p>India GST: invoice date drives return period — do not back-date without CA approval. UK VAT: align with tax point rules on <a href="/guides/invoice-generator-uk">UK invoice guide</a>.</p>

            <h2>Client portal uploads</h2>
            <p>Some enterprises require PDF + PO match in Ariba/Coupa — paste PO in Notes exactly as buyer system shows.</p>
            
            
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
            

            <h2>Summary: recurring PDF discipline</h2>
            <p>Successful recurring billing is repetition without sloppiness — same tax IDs, incremented invoice numbers, updated dates, and PDF sent from the same email identity clients trust. RatPDF keeps generation fast; your ledger keeps finance honest.</p>
            <p>Mid-article reminder: <a href="/invoice/create">Create Invoice</a> · End-of-month bulk: <a href="/guides/bulk-gst-invoice-generator">bulk GST guide</a>.</p>

            <h2>Recurring billing anti-patterns</h2>
            <p>Avoid: copying last month's PDF in Photoshop (breaks text search); skipping months then double-billing; changing tax rate without client email notice; using personal name when contract shows company. Each creates AP rejection or audit noise.</p>

            <h2>Annual review of retainer templates</h2>
            <p>Each January, verify tax rates, your legal name, bank details, and client GSTIN/VAT IDs still match government registries. One hour prevents twelve months of rejected PDFs. Update <a href="/guides/invoice-generator-india">India</a>, <a href="/guides/invoice-generator-uk">UK</a>, or <a href="/guides/invoice-generator-australia">Australia</a> guides when local rules change.</p>

            
            <h2>Closing the monthly billing loop</h2>
            <p>Generate PDF → send → log payment date → reconcile bank feed → mark row paid in spreadsheet. Missing any step causes duplicate sends or missed revenue recognition. RatPDF handles PDF generation; your discipline handles the loop.</p>
            <p>Compare: <a href="/compare">alternatives</a> · Research: <a href="/research/freelancer-invoicing-statistics">freelancer invoicing statistics</a> · Tool: <a href="/invoice/create">Create Invoice</a>.</p>
            <p>High-volume retainers eventually migrate to <a href="/guides/bulk-gst-invoice-generator">bulk GST CSV</a> when Indian GST fields are required on every row — until then, single Create Invoice keeps workflow simple.</p>
            <p>Upgrade prompt: free tier covers light retainers; Pro removes daily caps — <a href="/Subscription/Plans">compare plans</a>.</p>
            <p>Document your billing SOP so substitutes can issue PDFs when you are on leave — same Create Invoice fields, same filename pattern, same AP contact every month. Consistency beats speed when tax IDs are involved.</p>
            

            <h2>Related guides</h2>
            <ul>
            <li><a href="/guides/invoice-generator-india">Invoice generator India</a></li>
            <li><a href="/guides/bulk-gst-invoice-generator">Bulk GST invoice generator</a></li>
            <li><a href="/guides/invoice-for-freelancers">Invoice for freelancers</a></li>
            </ul>
            <p><a href="/invoice/create" class="btn btn-primary">Create recurring invoice PDF</a> · <a href="/Subscription/Plans">Upgrade for volume</a></p>
            """;

        private const string PdfToWordMac = """
            <h2>Convert PDF to Word on Mac — Safari workflow without Adobe</h2>
            <p>Mac users often try Preview copy-paste or paid Acrobat subscriptions. RatPDF runs in <strong>Safari or Chrome</strong>: upload PDF, download DOCX, edit in Word for Mac or Pages.</p>

            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> Safari on macOS with RatPDF PDF to Word upload zone</figcaption></figure>

            <h2>Real example: edit a vendor contract on MacBook Air</h2>
            <ol>
            <li>Receive 12-page vendor PDF via email — need to change payment terms in clause 4.</li>
            <li>Open <a href="/pdf/pdftodoc">PDF to Word</a> in Safari (files stay on RatPDF servers during conversion — see privacy policy).</li>
            <li>Upload PDF — digital PDF with selectable text converts in ~30–90 seconds.</li>
            <li>Download DOCX to Downloads — open in Microsoft Word or Pages.</li>
            <li>Edit clause 4 — export PDF again via Word <em>Save as PDF</em> or <a href="/pdf/doctopdf">Word to PDF</a>.</li>
            </ol>

            <div class="rp-mid-cta alert alert-primary my-4"><strong>Convert on Mac now — no install.</strong> <a href="/pdf/pdftodoc" class="alert-link fw-semibold">PDF to Word →</a></div>

            <h2>Preview limitations on macOS</h2>
            <p>Preview displays PDFs well but does not export structured DOCX. Copy-paste loses tables and headers. For résumés and contracts, always use PDF to Word on digital PDFs.</p>

            <h2>Scanned PDFs on Mac</h2>
            <p>Phone scans via Notes app produce image PDFs — run <a href="/guides/scanned-pdf-to-word">scanned PDF to Word</a> workflow: <a href="/pdf/ocrpdf">OCR PDF</a> first, then PDF to Word.</p>

            <h2>Formatting expectations</h2>
            <p>See <a href="/guides/pdf-to-word-keep-formatting">keep formatting guide</a>. Digital invoices and reports usually keep tables; Canva-designed résumés may become image pages.</p>

            
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
            
            
            <h2>Understanding the PDF to Word pipeline</h2>
            <p>PDF stores text, vectors, and images in a fixed layout. Word expects flowing paragraphs and style definitions. RatPDF bridges the gap by analysing structure first — optimised for Safari uploads on macOS. When structure cannot be inferred, pages render as images inside DOCX so you still receive an editable container rather than broken glyphs.</p>

            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> RatPDF PDF to Word progress — structure extraction vs fallback indicator</figcaption></figure>

            <h2>Digital vs scanned — decision in 10 seconds</h2>
            <p>Open PDF, try to select a sentence with the cursor. If text highlights, use <a href="/pdf/pdftodoc">PDF to Word</a> directly. If the page behaves like a picture, run <a href="/pdf/ocrpdf">OCR PDF</a> first — full workflow in <a href="/guides/scanned-pdf-to-word">scanned PDF to Word</a>.</p>

            <h2>Real example: annual report with charts</h2>
            <p><strong>Input:</strong> 40-page investor PDF — narrative pages digital, three pages chart-heavy.</p>
            <p><strong>Outcome:</strong> Narrative and tables edit in Word; chart pages appear as images you can replace with live Excel charts. Faster than retyping 40 pages.</p>

            <h2>Word for Microsoft 365 vs desktop</h2>
            <p>Both open RatPDF DOCX. Web Word has fewer layout tools — use desktop for complex contract track changes. Mac users: <a href="/guides/pdf-to-word-mac">PDF to Word on Mac</a>.</p>

            <h2>Formatting deep dive</h2>
            <p>See <a href="/guides/pdf-to-word-keep-formatting">keep formatting guide</a> for table survival rates. Corporate templates applied after convert beat fighting PDF styles.</p>

            <h2>Security and retention</h2>
            <p>Files process on RatPDF infrastructure over HTTPS — review privacy policy for retention window. Clear Downloads on shared PCs after confidential contracts.</p>

            <h2>Alternatives comparison</h2>
            <p>Desktop Acrobat is costly for occasional edits. Browser tools vary on table fidelity. Compare: <a href="/compare/smallpdf-alternative">Smallpdf alternative</a> · <a href="/compare/adobe-alternative">Adobe alternative</a> · <a href="/compare/ilovepdf-alternative">iLovePDF alternative</a>.</p>

            <h2>Research</h2>
            <p>File size and quality trade-offs after re-export: <a href="/research/pdf-compression-benchmark">PDF compression benchmark</a>.</p>

            <h2>Related cluster</h2>
            <ul>
            <li><a href="/guides/pdf-to-word">PDF to Word guide</a></li>
            <li><a href="/guides/pdf-to-word-keep-formatting">Keep formatting</a></li>
            <li><a href="/guides/scanned-pdf-to-word">Scanned PDF to Word</a></li>
            <li><a href="/guides/pdf-to-word-mac">PDF to Word on Mac</a></li>
            </ul>

            <h2>Extended workflow FAQ</h2>
            <p><strong>Will my fonts match?</strong> Install corporate fonts before opening DOCX or accept substitution warnings.</p>
            <p><strong>Can I convert back to PDF?</strong> Yes — <a href="/pdf/doctopdf">Word to PDF</a> after edits.</p>
            <p><strong>Page limit?</strong> Very large files may need <a href="/guides/split-pdf">split PDF</a> first.</p>
            <p><strong>Free tier?</strong> Three conversions per day — <a href="/Subscription/Plans">upgrade</a> for volume.</p>

            <div class="rp-mid-cta alert alert-primary my-4"><strong>Start converting.</strong> <a href="/pdf/pdftodoc" class="alert-link fw-semibold">PDF to Word →</a></div>

            <h2>Common failure modes and fixes</h2>
            <p><strong>Garbled characters:</strong> PDF used custom encoding — request source DOCX from sender.</p>
            <p><strong>Missing pages:</strong> Upload timed out — split file or upgrade tier for larger limits.</p>
            <p><strong>Wide tables cut off:</strong> Switch Word to landscape section for that page.</p>
            <p><strong>Images only output:</strong> PDF was flattened — try OCR if scan, or obtain digital export.</p>

            <h2>Collaboration workflow</h2>
            <p>Send DOCX via tracked changes — reviewers comment in Word; owner merges and exports final PDF. Avoid emailing editable DOCX without password if contract is confidential — use secure share links.</p>

            <h2>Related guides</h2>
            <p>This page focuses on optimised for Safari uploads on macOS. Start at <a href="/guides/pdf-to-word">PDF to Word hub</a> for tool overview, then return here for specialised workflow.</p>
            
            
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
            
            
            <h2>Document type quick reference</h2>
            <p><strong>Contracts:</strong> digital PDF, track changes in Word. <strong>Invoices:</strong> table-heavy — check sums. <strong>Scanned forms:</strong> OCR first. <strong>Marketing PDFs:</strong> expect image blocks. <strong>Manuals:</strong> headings usually survive — update TOC in Word after edits.</p>
            <p>Upgrade for volume: <a href="/Subscription/Plans">subscription plans</a>. Pillar: <a href="/guides/pdf-to-word">PDF to Word</a>.</p>

            <h2>Stakeholder sign-off matrix</h2>
            <p>Legal reviews converted contracts; finance reviews invoice PDFs edited in Word; HR reviews offer letters. Route DOCX to the right reviewer before re-PDF. Version suffix in filename (<code>-legal-reviewed</code>) prevents accidental send of draft.</p>
            <p>After major edits, compress before email if DOCX re-export exceeds mailbox limits — see <a href="/research/pdf-compression-benchmark">PDF compression benchmark</a> for quality settings.</p>
            <p>Bookmark this page for your team's wiki — consistent PDF-to-Word steps reduce support tickets when onboarding new staff each quarter.</p>
            

            <h2>Closing workflow summary</h2>
            <p>Pick the right path: digital PDF → PDF to Word; scan → OCR → PDF to Word; layout-critical → verify tables in Word before delivery. Mac users stay in Safari; enterprise users compare <a href="/compare/adobe-alternative">Adobe alternative</a> before buying seats.</p>
            <p>Research citation: <a href="/research/pdf-compression-benchmark">PDF compression benchmark</a> — relevant when re-exporting large edited DOCX to email-sized PDFs.</p>

            
            <h2>Related guides &amp; cluster links</h2>
            <ul>
            <li><a href="/guides/pdf-to-word">PDF to Word conversion guide</a></li>
            <li><a href="/guides/pdf-to-word-keep-formatting">Keep formatting in Word</a></li>
            <li><a href="/guides/scanned-pdf-to-word">Scanned PDF to Word</a></li>
            <li><a href="/guides/pdf-to-word-mac">PDF to Word on Mac</a></li>
            </ul>
            <p>Research: <a href="/research/pdf-compression-benchmark">PDF compression benchmark</a> · Compare: <a href="/compare/smallpdf-alternative">Smallpdf alternative</a></p>
            <p><a href="/pdf/pdftodoc" class="btn btn-primary">PDF to Word on Mac</a> · <a href="/compare/ilovepdf-alternative">iLovePDF alternative</a></p>
            """;

        private const string PdfToWordKeepFormatting = """
            <h2>Keep tables, logos, and layout when converting PDF to Word</h2>
            <p>Layout loss is the #1 complaint about PDF converters. RatPDF uses <strong>pdf2docx</strong> on digital PDFs first, then page-render fallback only when needed.</p>

            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> Side-by-side PDF table and reconstructed Word table after conversion</figcaption></figure>

            <h2>Real example: quarterly board pack with financial tables</h2>
            <p><strong>Input:</strong> 24-page PDF exported from Excel and Word — mixed landscape tables, company logo on cover.</p>
            <p><strong>Result:</strong> 22 pages convert as editable objects; 2 complex chart pages may render as images — acceptable for board review edits.</p>
            <ol>
            <li>Confirm text selects in PDF viewer — if yes, digital pipeline applies.</li>
            <li>Upload to <a href="/pdf/pdftodoc">PDF to Word</a>.</li>
            <li>In Word: turn on <em>View gridlines</em> for table edits; check merged cells manually.</li>
            <li>Re-export PDF via <a href="/pdf/doctopdf">Word to PDF</a> when edits complete.</li>
            </ol>

            <div class="rp-mid-cta alert alert-primary my-4"><strong>Preserve your tables — convert now.</strong> <a href="/pdf/pdftodoc" class="alert-link fw-semibold">PDF to Word →</a></div>

            <h2>What usually survives conversion</h2>
            <ul>
            <li>Line-item tables from ERP/accounting PDF exports</li>
            <li>Headers/footers with page numbers</li>
            <li>Embedded vector logos on digital marketing PDFs</li>
            <li>Multi-column text when encoded as real text (not flattened)</li>
            </ul>

            <h2>What often becomes images</h2>
            <ul>
            <li>Full-bleed InDesign brochures</li>
            <li>Scanned contracts (use <a href="/guides/scanned-pdf-to-word">OCR workflow</a>)</li>
            <li>PDFs where fonts are subset without ToUnicode mapping</li>
            </ul>

            <h2>QA checklist after download</h2>
            <ol>
            <li>Spot-check sum formulas in tables (Word does not always recreate Excel logic)</li>
            <li>Compare logo sharpness at 150% zoom</li>
            <li>Print preview before sending to print shop</li>
            </ol>
            <p>Research: <a href="/research/pdf-compression-benchmark">PDF compression benchmark</a> (file size vs quality trade-offs post-edit).</p>
            
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
            
            
            <h2>Understanding the PDF to Word pipeline</h2>
            <p>PDF stores text, vectors, and images in a fixed layout. Word expects flowing paragraphs and style definitions. RatPDF bridges the gap by analysing structure first — prioritising table and logo preservation via pdf2docx. When structure cannot be inferred, pages render as images inside DOCX so you still receive an editable container rather than broken glyphs.</p>

            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> RatPDF PDF to Word progress — structure extraction vs fallback indicator</figcaption></figure>

            <h2>Digital vs scanned — decision in 10 seconds</h2>
            <p>Open PDF, try to select a sentence with the cursor. If text highlights, use <a href="/pdf/pdftodoc">PDF to Word</a> directly. If the page behaves like a picture, run <a href="/pdf/ocrpdf">OCR PDF</a> first — full workflow in <a href="/guides/scanned-pdf-to-word">scanned PDF to Word</a>.</p>

            <h2>Real example: annual report with charts</h2>
            <p><strong>Input:</strong> 40-page investor PDF — narrative pages digital, three pages chart-heavy.</p>
            <p><strong>Outcome:</strong> Narrative and tables edit in Word; chart pages appear as images you can replace with live Excel charts. Faster than retyping 40 pages.</p>

            <h2>Word for Microsoft 365 vs desktop</h2>
            <p>Both open RatPDF DOCX. Web Word has fewer layout tools — use desktop for complex contract track changes. Mac users: <a href="/guides/pdf-to-word-mac">PDF to Word on Mac</a>.</p>

            <h2>Formatting deep dive</h2>
            <p>See <a href="/guides/pdf-to-word-keep-formatting">keep formatting guide</a> for table survival rates. Corporate templates applied after convert beat fighting PDF styles.</p>

            <h2>Security and retention</h2>
            <p>Files process on RatPDF infrastructure over HTTPS — review privacy policy for retention window. Clear Downloads on shared PCs after confidential contracts.</p>

            <h2>Alternatives comparison</h2>
            <p>Desktop Acrobat is costly for occasional edits. Browser tools vary on table fidelity. Compare: <a href="/compare/smallpdf-alternative">Smallpdf alternative</a> · <a href="/compare/adobe-alternative">Adobe alternative</a> · <a href="/compare/ilovepdf-alternative">iLovePDF alternative</a>.</p>

            <h2>Research</h2>
            <p>File size and quality trade-offs after re-export: <a href="/research/pdf-compression-benchmark">PDF compression benchmark</a>.</p>

            <h2>Related cluster</h2>
            <ul>
            <li><a href="/guides/pdf-to-word">PDF to Word guide</a></li>
            <li><a href="/guides/pdf-to-word-keep-formatting">Keep formatting</a></li>
            <li><a href="/guides/scanned-pdf-to-word">Scanned PDF to Word</a></li>
            <li><a href="/guides/pdf-to-word-mac">PDF to Word on Mac</a></li>
            </ul>

            <h2>Extended workflow FAQ</h2>
            <p><strong>Will my fonts match?</strong> Install corporate fonts before opening DOCX or accept substitution warnings.</p>
            <p><strong>Can I convert back to PDF?</strong> Yes — <a href="/pdf/doctopdf">Word to PDF</a> after edits.</p>
            <p><strong>Page limit?</strong> Very large files may need <a href="/guides/split-pdf">split PDF</a> first.</p>
            <p><strong>Free tier?</strong> Three conversions per day — <a href="/Subscription/Plans">upgrade</a> for volume.</p>

            <div class="rp-mid-cta alert alert-primary my-4"><strong>Start converting.</strong> <a href="/pdf/pdftodoc" class="alert-link fw-semibold">PDF to Word →</a></div>

            <h2>Common failure modes and fixes</h2>
            <p><strong>Garbled characters:</strong> PDF used custom encoding — request source DOCX from sender.</p>
            <p><strong>Missing pages:</strong> Upload timed out — split file or upgrade tier for larger limits.</p>
            <p><strong>Wide tables cut off:</strong> Switch Word to landscape section for that page.</p>
            <p><strong>Images only output:</strong> PDF was flattened — try OCR if scan, or obtain digital export.</p>

            <h2>Collaboration workflow</h2>
            <p>Send DOCX via tracked changes — reviewers comment in Word; owner merges and exports final PDF. Avoid emailing editable DOCX without password if contract is confidential — use secure share links.</p>

            <h2>Related guides</h2>
            <p>This page focuses on prioritising table and logo preservation via pdf2docx. Start at <a href="/guides/pdf-to-word">PDF to Word hub</a> for tool overview, then return here for specialised workflow.</p>
            
            
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
            
            
            <h2>Document type quick reference</h2>
            <p><strong>Contracts:</strong> digital PDF, track changes in Word. <strong>Invoices:</strong> table-heavy — check sums. <strong>Scanned forms:</strong> OCR first. <strong>Marketing PDFs:</strong> expect image blocks. <strong>Manuals:</strong> headings usually survive — update TOC in Word after edits.</p>
            <p>Upgrade for volume: <a href="/Subscription/Plans">subscription plans</a>. Pillar: <a href="/guides/pdf-to-word">PDF to Word</a>.</p>

            <h2>Stakeholder sign-off matrix</h2>
            <p>Legal reviews converted contracts; finance reviews invoice PDFs edited in Word; HR reviews offer letters. Route DOCX to the right reviewer before re-PDF. Version suffix in filename (<code>-legal-reviewed</code>) prevents accidental send of draft.</p>
            <p>After major edits, compress before email if DOCX re-export exceeds mailbox limits — see <a href="/research/pdf-compression-benchmark">PDF compression benchmark</a> for quality settings.</p>
            <p>Bookmark this page for your team's wiki — consistent PDF-to-Word steps reduce support tickets when onboarding new staff each quarter.</p>
            

            <h2>When to escalate to source files</h2>
            <p>If two conversion attempts produce poor tables, stop — request native DOCX/XLSX from issuer. Conversion is for unavoidable PDF-only workflows, not lazy data exchange.</p>
            <p>Tool CTA: <a href="/pdf/pdftodoc">PDF to Word</a> · Research: <a href="/research/pdf-compression-benchmark">PDF compression benchmark</a>.</p>

            
            <h2>Related guides &amp; cluster links</h2>
            <ul>
            <li><a href="/guides/pdf-to-word">PDF to Word conversion guide</a></li>
            <li><a href="/guides/pdf-to-word-keep-formatting">Keep formatting in Word</a></li>
            <li><a href="/guides/scanned-pdf-to-word">Scanned PDF to Word</a></li>
            <li><a href="/guides/pdf-to-word-mac">PDF to Word on Mac</a></li>
            </ul>
            <p>Research: <a href="/research/pdf-compression-benchmark">PDF compression benchmark</a> · Compare: <a href="/compare/smallpdf-alternative">Smallpdf alternative</a></p>
            <p><a href="/pdf/pdftodoc" class="btn btn-primary">Convert with layout focus</a></p>
            """;

        private const string ScannedPdfToWord = """
            <h2>Scanned PDF to Word — OCR then convert for editable DOCX</h2>
            <p>Image-only PDFs from scanners, phone cameras, or fax lines have no text layer — Word cannot edit pixels. Pipeline: <strong>OCR PDF</strong> → <strong>PDF to Word</strong>.</p>

            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> OCR progress bar then Word document with searchable text</figcaption></figure>

            <h2>Real example: signed lease scan to editable draft</h2>
            <ol>
            <li>Scan signed lease at <strong>300 DPI grayscale</strong> (not colour photo mode).</li>
            <li>Upload to <a href="/pdf/ocrpdf">OCR PDF</a> — adds Tesseract text layer.</li>
            <li>Verify: Ctrl+F finds "Tenant" in your PDF viewer.</li>
            <li>Upload OCR'd PDF to <a href="/pdf/pdftodoc">PDF to Word</a>.</li>
            <li>Edit redlined clauses in Word — keep original signed PDF archived separately.</li>
            </ol>

            <div class="rp-mid-cta alert alert-primary my-4"><strong>Make your scan editable.</strong> <a href="/pdf/ocrpdf" class="alert-link fw-semibold">OCR PDF →</a> then <a href="/pdf/pdftodoc" class="alert-link fw-semibold">PDF to Word</a></div>

            <h2>Scan quality settings</h2>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>Document</th><th>DPI</th><th>Mode</th></tr></thead>
            <tbody>
            <tr><td>Typed contract</td><td>200–300</td><td>Grayscale</td></tr>
            <tr><td>Handwritten notes</td><td>300</td><td>Grayscale, high contrast</td></tr>
            <tr><td>Colour ID + stamps</td><td>300</td><td>Colour</td></tr>
            </tbody>
            </table></div>

            <h2>Table limits on scans</h2>
            <p>OCR tables rarely reconstruct perfect Word tables — expect text in approximate columns. For bank statements use <a href="/guides/pdf-to-excel">PDF to Excel</a> on digital exports instead.</p>

            <h2>Mac and Windows</h2>
            <p>Browser workflow identical — <a href="/guides/pdf-to-word-mac">PDF to Word on Mac</a> · formatting tips: <a href="/guides/pdf-to-word-keep-formatting">keep formatting</a>.</p>
            
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
            
            
            <h2>Understanding the PDF to Word pipeline</h2>
            <p>PDF stores text, vectors, and images in a fixed layout. Word expects flowing paragraphs and style definitions. RatPDF bridges the gap by analysing structure first — OCR-first for image-only scans before Word conversion. When structure cannot be inferred, pages render as images inside DOCX so you still receive an editable container rather than broken glyphs.</p>

            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> RatPDF PDF to Word progress — structure extraction vs fallback indicator</figcaption></figure>

            <h2>Digital vs scanned — decision in 10 seconds</h2>
            <p>Open PDF, try to select a sentence with the cursor. If text highlights, use <a href="/pdf/pdftodoc">PDF to Word</a> directly. If the page behaves like a picture, run <a href="/pdf/ocrpdf">OCR PDF</a> first — full workflow in <a href="/guides/scanned-pdf-to-word">scanned PDF to Word</a>.</p>

            <h2>Real example: annual report with charts</h2>
            <p><strong>Input:</strong> 40-page investor PDF — narrative pages digital, three pages chart-heavy.</p>
            <p><strong>Outcome:</strong> Narrative and tables edit in Word; chart pages appear as images you can replace with live Excel charts. Faster than retyping 40 pages.</p>

            <h2>Word for Microsoft 365 vs desktop</h2>
            <p>Both open RatPDF DOCX. Web Word has fewer layout tools — use desktop for complex contract track changes. Mac users: <a href="/guides/pdf-to-word-mac">PDF to Word on Mac</a>.</p>

            <h2>Formatting deep dive</h2>
            <p>See <a href="/guides/pdf-to-word-keep-formatting">keep formatting guide</a> for table survival rates. Corporate templates applied after convert beat fighting PDF styles.</p>

            <h2>Security and retention</h2>
            <p>Files process on RatPDF infrastructure over HTTPS — review privacy policy for retention window. Clear Downloads on shared PCs after confidential contracts.</p>

            <h2>Alternatives comparison</h2>
            <p>Desktop Acrobat is costly for occasional edits. Browser tools vary on table fidelity. Compare: <a href="/compare/smallpdf-alternative">Smallpdf alternative</a> · <a href="/compare/adobe-alternative">Adobe alternative</a> · <a href="/compare/ilovepdf-alternative">iLovePDF alternative</a>.</p>

            <h2>Research</h2>
            <p>File size and quality trade-offs after re-export: <a href="/research/pdf-compression-benchmark">PDF compression benchmark</a>.</p>

            <h2>Related cluster</h2>
            <ul>
            <li><a href="/guides/pdf-to-word">PDF to Word guide</a></li>
            <li><a href="/guides/pdf-to-word-keep-formatting">Keep formatting</a></li>
            <li><a href="/guides/scanned-pdf-to-word">Scanned PDF to Word</a></li>
            <li><a href="/guides/pdf-to-word-mac">PDF to Word on Mac</a></li>
            </ul>

            <h2>Extended workflow FAQ</h2>
            <p><strong>Will my fonts match?</strong> Install corporate fonts before opening DOCX or accept substitution warnings.</p>
            <p><strong>Can I convert back to PDF?</strong> Yes — <a href="/pdf/doctopdf">Word to PDF</a> after edits.</p>
            <p><strong>Page limit?</strong> Very large files may need <a href="/guides/split-pdf">split PDF</a> first.</p>
            <p><strong>Free tier?</strong> Three conversions per day — <a href="/Subscription/Plans">upgrade</a> for volume.</p>

            <div class="rp-mid-cta alert alert-primary my-4"><strong>Start converting.</strong> <a href="/pdf/pdftodoc" class="alert-link fw-semibold">PDF to Word →</a></div>

            <h2>Common failure modes and fixes</h2>
            <p><strong>Garbled characters:</strong> PDF used custom encoding — request source DOCX from sender.</p>
            <p><strong>Missing pages:</strong> Upload timed out — split file or upgrade tier for larger limits.</p>
            <p><strong>Wide tables cut off:</strong> Switch Word to landscape section for that page.</p>
            <p><strong>Images only output:</strong> PDF was flattened — try OCR if scan, or obtain digital export.</p>

            <h2>Collaboration workflow</h2>
            <p>Send DOCX via tracked changes — reviewers comment in Word; owner merges and exports final PDF. Avoid emailing editable DOCX without password if contract is confidential — use secure share links.</p>

            <h2>Related guides</h2>
            <p>This page focuses on OCR-first for image-only scans before Word conversion. Start at <a href="/guides/pdf-to-word">PDF to Word hub</a> for tool overview, then return here for specialised workflow.</p>
            
            
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
            
            
            <h2>Document type quick reference</h2>
            <p><strong>Contracts:</strong> digital PDF, track changes in Word. <strong>Invoices:</strong> table-heavy — check sums. <strong>Scanned forms:</strong> OCR first. <strong>Marketing PDFs:</strong> expect image blocks. <strong>Manuals:</strong> headings usually survive — update TOC in Word after edits.</p>
            <p>Upgrade for volume: <a href="/Subscription/Plans">subscription plans</a>. Pillar: <a href="/guides/pdf-to-word">PDF to Word</a>.</p>

            <h2>Stakeholder sign-off matrix</h2>
            <p>Legal reviews converted contracts; finance reviews invoice PDFs edited in Word; HR reviews offer letters. Route DOCX to the right reviewer before re-PDF. Version suffix in filename (<code>-legal-reviewed</code>) prevents accidental send of draft.</p>
            <p>After major edits, compress before email if DOCX re-export exceeds mailbox limits — see <a href="/research/pdf-compression-benchmark">PDF compression benchmark</a> for quality settings.</p>
            <p>Bookmark this page for your team's wiki — consistent PDF-to-Word steps reduce support tickets when onboarding new staff each quarter.</p>
            

            <h2>OCR + Word handoff checklist</h2>
            <p>After OCR, search for a known phrase before Word step. After Word, search same phrase — if missing, OCR language or scan DPI was insufficient. Rescan at 300 DPI before blaming converter.</p>
            <p>Primary tools: <a href="/pdf/ocrpdf">OCR PDF</a> and <a href="/pdf/pdftodoc">PDF to Word</a> — compare <a href="/compare/smallpdf-alternative">Smallpdf alternative</a> if evaluating vendors.</p>

            <h2>Quality gate before client delivery</h2>
            <p>Run spell-check in Word, verify page count matches source, and confirm critical dates and amounts survived OCR. Remove reviewer comments before exporting final PDF for filing. Archive the searchable OCR PDF alongside the Word draft.</p>

            
            <h2>Related guides &amp; cluster links</h2>
            <ul>
            <li><a href="/guides/pdf-to-word">PDF to Word conversion guide</a></li>
            <li><a href="/guides/pdf-to-word-keep-formatting">Keep formatting in Word</a></li>
            <li><a href="/guides/scanned-pdf-to-word">Scanned PDF to Word</a></li>
            <li><a href="/guides/pdf-to-word-mac">PDF to Word on Mac</a></li>
            </ul>
            <p>Research: <a href="/research/pdf-compression-benchmark">PDF compression benchmark</a> · Compare: <a href="/compare/smallpdf-alternative">Smallpdf alternative</a></p>
            <p><a href="/pdf/ocrpdf" class="btn btn-primary">Start with OCR</a> · <a href="/compare/adobe-alternative">Adobe alternative</a></p>
            """;

    }
}
