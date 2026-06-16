#!/usr/bin/env python3
"""Generate GuideBodiesWave1.cs — premium Wave 1 upgrades (no new URLs)."""
from pathlib import Path

from wave1_expansions import (
    BULK_GST_EXTRA,
    BULK_GST_EXTRA_2,
    COUNTRY_EXPANSIONS,
    COUNTRY_TOPUP,
    PDF_FORMAT_EXTRA,
    PDF_FORMAT_EXTRA_2,
    PDF_MAC_EXTRA,
    PDF_MAC_EXTRA_2,
    PDF_SCANNED_EXTRA,
    PDF_SCANNED_EXTRA_2,
    RECURRING_EXTRA,
    RECURRING_EXTRA_2,
    BULK_PREMIUM,
    RECURRING_PREMIUM,
    PDF_CLUSTER_PREMIUM,
    BULK_PREMIUM_2,
    RECURRING_PREMIUM_2,
    RECURRING_PREMIUM_3,
    PDF_PAGE_PREMIUM,
    PDF_FINAL_BOOST,
    RECURRING_FINAL,
)

OUT = Path(__file__).resolve().parents[1] / "Content" / "GuideBodiesWave1.cs"

SLUGS = [
    "invoice-generator-australia", "invoice-generator-canada", "invoice-generator-france",
    "invoice-generator-germany", "invoice-generator-new-zealand", "invoice-generator-philippines",
    "invoice-generator-singapore", "invoice-generator-south-africa", "invoice-generator-uae",
    "invoice-generator-uk", "bulk-gst-invoice-generator", "recurring-invoice-generator",
    "pdf-to-word-mac", "pdf-to-word-keep-formatting", "scanned-pdf-to-word",
]

def const_name(slug: str) -> str:
    return slug.replace("-", "_").title().replace("_", "")


def shot(caption: str) -> str:
    return f'<figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> {caption}</figcaption></figure>'


def mid_cta(tool: str, label: str, text: str) -> str:
    return f'<div class="rp-mid-cta alert alert-primary my-4"><strong>{text}</strong> <a href="{tool}" class="alert-link fw-semibold">{label} →</a></div>'


def end_cta(tool: str, label: str, extra: str = "") -> str:
    extra_html = f" · {extra}" if extra else ""
    return f'<p class="mt-4"><a href="{tool}" class="btn btn-primary">{label}</a>{extra_html}</p>'


def link_graph_invoice(country_slug: str, country_name: str) -> str:
    return f"""
            <h2>Related guides &amp; cluster links</h2>
            <ul>
            <li><a href="/guides/invoice-generator-guide">Invoice generator guide</a></li>
            <li><a href="/guides/invoice-generator-india">Invoice generator India</a></li>
            <li><a href="/guides/invoice-generator-usa">Invoice generator USA</a></li>
            <li><a href="/guides/recurring-invoice-generator">Recurring invoice generator</a></li>
            </ul>
            <p>Research: <a href="/research/freelancer-invoicing-statistics">Freelancer invoicing statistics</a> · Compare: <a href="/compare">PDF &amp; business tool alternatives</a></p>"""


def link_graph_pdf_word() -> str:
    return """
            <h2>Related guides &amp; cluster links</h2>
            <ul>
            <li><a href="/guides/pdf-to-word">PDF to Word conversion guide</a></li>
            <li><a href="/guides/pdf-to-word-keep-formatting">Keep formatting in Word</a></li>
            <li><a href="/guides/scanned-pdf-to-word">Scanned PDF to Word</a></li>
            <li><a href="/guides/pdf-to-word-mac">PDF to Word on Mac</a></li>
            </ul>
            <p>Research: <a href="/research/pdf-compression-benchmark">PDF compression benchmark</a> · Compare: <a href="/compare/smallpdf-alternative">Smallpdf alternative</a></p>"""


COUNTRY_DATA = {
    "invoice-generator-australia": {
        "name": "Australia", "currency": "AUD", "tax": "GST 10%", "id": "ABN",
        "reg": "ATO", "reg_url": "https://www.ato.gov.au/",
        "example": "Sydney design studio billing a Melbourne client $4,400 AUD + GST",
        "fields": "ABN, invoice date, description, GST amount, seller identity",
        "peers": "invoice-generator-new-zealand",
    },
    "invoice-generator-canada": {
        "name": "Canada", "currency": "CAD", "tax": "GST/HST (5–15% by province)", "id": "BN/GST number",
        "reg": "CRA", "reg_url": "https://www.canada.ca/en/revenue-agency.html",
        "example": "Toronto consultant invoicing an Alberta client in CAD with 5% GST",
        "fields": "Business number, HST/GST line, place of supply, bilingual labels if Quebec",
        "peers": "invoice-generator-usa",
    },
    "invoice-generator-france": {
        "name": "France", "currency": "EUR", "tax": "TVA 20%", "id": "SIRET / TVA intracommunautaire",
        "reg": "impots.gouv", "reg_url": "https://www.impots.gouv.fr/",
        "example": "Paris freelance developer billing a Lyon SASU €2,800 HT + TVA",
        "fields": "SIRET, TVA number, date, prestation description, TVA breakdown",
        "peers": "invoice-generator-germany",
    },
    "invoice-generator-germany": {
        "name": "Germany", "currency": "EUR", "tax": "USt 19% (7% reduced)", "id": "USt-IdNr / Steuernummer",
        "reg": "BMF", "reg_url": "https://www.bundesfinanzministerium.de/",
        "example": "Berlin GmbH subcontractor billing Hamburg client €1,650 net + 19% USt",
        "fields": "Rechnungsnummer, Leistungsdatum, USt-Ausweis, Kleinunternehmer note if applicable",
        "peers": "invoice-generator-france",
    },
    "invoice-generator-new-zealand": {
        "name": "New Zealand", "currency": "NZD", "tax": "GST 15%", "id": "IRD/GST number",
        "reg": "IRD", "reg_url": "https://www.ird.govt.nz/",
        "example": "Auckland contractor billing Wellington SMB $3,200 NZD + GST",
        "fields": "GST number, tax invoice wording, line items, total GST",
        "peers": "invoice-generator-australia",
    },
    "invoice-generator-philippines": {
        "name": "Philippines", "currency": "PHP", "tax": "VAT 12%", "id": "TIN",
        "reg": "BIR", "reg_url": "https://www.bir.gov.ph/",
        "example": "Manila agency billing Cebu client ₱85,000 + 12% VAT",
        "fields": "TIN, registered name, VATable sales, VAT amount",
        "peers": "invoice-generator-singapore",
    },
    "invoice-generator-singapore": {
        "name": "Singapore", "currency": "SGD", "tax": "GST 9%", "id": "UEN",
        "reg": "IRAS", "reg_url": "https://www.iras.gov.sg/",
        "example": "Singapore SaaS vendor billing regional client S$6,500 + GST",
        "fields": "UEN, GST registration number, tax invoice label, GST amount",
        "peers": "invoice-generator-philippines",
    },
    "invoice-generator-south-africa": {
        "name": "South Africa", "currency": "ZAR", "tax": "VAT 15%", "id": "VAT vendor number",
        "reg": "SARS", "reg_url": "https://www.sars.gov.za/",
        "example": "Cape Town supplier billing Johannesburg buyer R42,000 + VAT",
        "fields": "VAT number, tax invoice, exclusive/inclusive amounts",
        "peers": "invoice-generator-uae",
    },
    "invoice-generator-uae": {
        "name": "UAE", "currency": "AED", "tax": "VAT 5%", "id": "TRN",
        "reg": "FTA", "reg_url": "https://tax.gov.ae/",
        "example": "Dubai consultancy billing Abu Dhabi mainland client AED 18,000 + 5% VAT",
        "fields": "TRN, supply date, VAT amount, Arabic/English business names if required",
        "peers": "invoice-generator-south-africa",
    },
    "invoice-generator-uk": {
        "name": "United Kingdom", "currency": "GBP", "tax": "VAT 20%", "id": "VAT registration number",
        "reg": "HMRC", "reg_url": "https://www.gov.uk/government/organisations/hm-revenue-customs",
        "example": "London Ltd billing Manchester Ltd £2,150 + VAT",
        "fields": "Unique invoice number, time of supply, VAT rate, VAT amount",
        "peers": "invoice-generator-ireland" if False else "invoice-generator-germany",
    },
}


def invoice_long_tail(d: dict, slug: str) -> str:
    peer = d.get("peers", "invoice-generator-guide")
    peer_name = peer.replace("invoice-generator-", "").replace("-", " ").title()
    return f"""
            <h2>Choosing invoice layout for {d['name']} clients</h2>
            <p>Accounts payable teams in {d['name']} reject PDFs that look like marketing flyers. Use a single-column layout: legal names at top, line items in a table, tax breakdown before total, payment instructions in Notes. RatPDF's default PDF is optimised for printing and email — not screen-only quotes.</p>
            <p>If your client uses SAP, Oracle, or Xero AP automation, they may OCR your PDF — keep {d['id']} in plain text (not inside a logo image) so extraction succeeds.</p>

            {shot(f"Printed {d['currency']} tax invoice with {d['tax']} breakdown and {d['id']} in header")}

            <h2>Third example: mixed tax rates on one invoice</h2>
            <p><strong>Scenario:</strong> You bill consulting ({d['tax']}) plus reimbursable travel (often zero-rated or out of scope depending on rules).</p>
            <ol>
            <li>Line 1 — "Strategy workshop" — taxable at standard rate.</li>
            <li>Line 2 — "Client-approved airfare reimbursement" — separate line, zero tax if documented as disbursement per {d['reg']} guidance.</li>
            <li>Notes cite client approval email date — protects you in audit.</li>
            <li>Total shows tax only on taxable lines — client can reconcile to contract.</li>
            </ol>
            <p>When unsure, ask your accountant before sending — amended invoices waste AP time.</p>

            <h2>Freelancer vs registered company letterhead</h2>
            <p><strong>Sole traders</strong> use personal trading name + {d['id']} where applicable. <strong>Companies</strong> use registered legal entity (Ltd/GmbH/SASU) — mismatch with bank account name delays payment. Match the name on your RatPDF "From" block to the account clients pay.</p>

            <h2>Currency and FX ({d['currency']})</h2>
            <p>Domestic clients expect {d['currency']}. If contract is USD/EUR but you are {d['name']}-registered, show {d['currency']} equivalent in Notes with FX rate and date source ("ECB rate 2026-04-01") so finance can verify.</p>
            <p>Cross-reference: <a href="/guides/invoice-generator-usa">USA invoices</a> · <a href="/guides/invoice-generator-india">India GST invoices</a> · <a href="/guides/{peer}">{peer_name} invoices</a>.</p>

            <h2>Deposit and progress invoices</h2>
            <p>Large projects split across multiple PDFs — each needs unique invoice number and clear scope reference ("Phase 2 of 4 — API integration"). Never duplicate invoice numbers; {d['reg']} audits trace sequences.</p>
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
            <p>Export folder of PDFs by tax year; your accountant ties each to bank deposits. Missing {d['id']} on B2B PDFs is a common reason year-end adjustments get delayed.</p>

            <h2>RatPDF vs desktop invoice software</h2>
            <p>Desktop tools need installs and licence seats. RatPDF runs in browser — three free uses per tool per day, Pro for agencies. Compare: <a href="/compare">tool alternatives</a>. Research: <a href="/research/freelancer-invoicing-statistics">freelancer invoicing statistics</a>.</p>

            <h2>Pre-send checklist ({d['name']})</h2>
            <ol>
            <li>{d['id']} visible and correct</li>
            <li>Tax rate matches supply type ({d['tax']})</li>
            <li>Client legal name matches contract</li>
            <li>Invoice number unique and sequential</li>
            <li>Payment terms and bank details in Notes</li>
            <li>PDF opens and prints — not a flattened phone photo</li>
            </ol>

            <h2>Local compliance reminders ({d['reg']})</h2>
            <p>Tax law changes — digital service reporting, e-invoicing pilots, and reverse-charge categories — can alter what must appear on your PDF. Bookmark <a href="{d['reg_url']}" rel="noopener noreferrer" target="_blank">{d['reg']}</a> and review templates each financial year. Your accountant should approve wording for reverse charge, export, and exempt supplies before you bulk-send to enterprise clients.</p>
            <p>Peer guide for neighbouring workflows: <a href="/guides/{peer}">{peer_name}</a>. Pillar: <a href="/guides/invoice-generator-guide">invoice generator guide</a>.</p>

            <h2>Disputes and chargebacks</h2>
            <p>When a client disputes hours or deliverables, your PDF invoice is the billing record — not Slack threads. Keep scope references in line descriptions so dispute resolution references the same text AP already approved. Reissue credit notes rather than editing sent PDFs.</p>

            <h2>Archiving PDFs for audits</h2>
            <p>Use immutable filenames: <code>YYYY-MM-DD_INV-number_client.pdf</code>. Store on encrypted backup; {d['reg']} may request invoices years after issuance. RatPDF does not replace accounting ledgers — export totals to your GL monthly.</p>
            """


def invoice_universal_supplement(d: dict) -> str:
    return f"""
            <h2>Payment method block on PDF</h2>
            <p>Include BSB/routing/IBAN, account name, and reference text ("Quote invoice number"). Clients paying via wire need exact match to your bank KYC name — a common delay when freelancers use trading names on invoice but personal name on account.</p>

            <h2>Purchase order matching</h2>
            <p>Enterprise AP matches PO line to invoice line. Copy PO number from buyer portal into Notes; if PO shows quantity 1 at $5,000 do not split across two lines unless PO allows.</p>

            <h2>Sales tax vs withholding</h2>
            <p>{d['tax']} on invoice is not the same as income tax withholding. Cross-border B2B may have treaty withholding — accountant handles; invoice shows gross fee per contract.</p>

            <h2>Recurring vs milestone billing</h2>
            <p>Retainers use same description monthly (<a href="/guides/recurring-invoice-generator">recurring guide</a>). Projects use milestone labels — do not mix on one PDF.</p>

            <h2>White-label and agency billing</h2>
            <p>Agencies billing end-client through intermediary still show supplier as your legal entity — Pro logo is cosmetic; tax ID remains yours.</p>

            <h2>PDF accessibility</h2>
            <p>Vector PDFs from RatPDF are searchable — clients with document management systems index {d['id']} and totals automatically. Flattened JPEG invoices break OCR AP pipelines.</p>

            <h2>Version control</h2>
            <p>Filename suffix <code>-v2</code> only for drafts never sent. Sent invoices get new numbers, not version bumps.</p>

            <h2>Integration checklist with accountant</h2>
            <ol>
            <li>Confirm tax rate list for your supplies</li>
            <li>Approve invoice number format before first send</li>
            <li>Map RatPDF PDF folder to GL import monthly</li>
            <li>Review one sample PDF before bulk client rollout</li>
            </ol>
            """


def body_invoice_country(slug: str) -> str:
    d = COUNTRY_DATA[slug]
    return f"""
            <h2>{d['name']} tax invoices for freelancers and SMBs</h2>
            <p>Businesses in {d['name']} need clear PDF tax invoices that clients and accountants can file without rework. RatPDF's <a href="/invoice/create">Create Invoice</a> tool produces print-ready PDFs in <strong>{d['currency']}</strong> with configurable tax lines — no desktop software install.</p>
            <p>This guide covers mandatory fields per {d['reg']} expectations, a real-world example, and how to avoid the template mistakes that delay payment.</p>

            {shot(f"RatPDF Create Invoice form with {d['currency']} currency and {d['tax']} line items")}

            <h2>Real example: {d['example']}</h2>
            <p><strong>Scenario:</strong> You delivered a fixed-scope project. The client needs a PDF tax invoice before accounts payable runs Friday.</p>
            <ol>
            <li>Open <a href="/invoice/create">Create Invoice</a> — set currency to <strong>{d['currency']}</strong>.</li>
            <li><strong>From:</strong> legal business name, address, {d['id']} in the header block.</li>
            <li><strong>Bill to:</strong> client legal name and address (add their tax ID for B2B).</li>
            <li><strong>Line items:</strong> "Phase 1 — design delivery" · qty 1 · rate matching contract.</li>
            <li><strong>Tax:</strong> set tax name to GST/VAT/TVA/USt as applicable — rate <strong>{d['tax']}</strong> when registered.</li>
            <li><strong>Notes:</strong> payment terms (Net 14), bank details, PO number if provided.</li>
            <li>Click <strong>Generate PDF</strong> — email the PDF; archive a copy for {d['reg']} records.</li>
            </ol>

            {mid_cta('/invoice/create', 'Create invoice free', f'Issue your next {d["currency"]} invoice in under two minutes')}

            <h2>Mandatory fields checklist ({d['reg']})</h2>
            <p>Tax invoice requirements evolve — verify on <a href="{d['reg_url']}" rel="noopener noreferrer" target="_blank">{d['reg']}</a> before changing templates. Commonly required:</p>
            <ul>
            <li>{d['fields']}</li>
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
            <li>Missing {d['id']} on B2B invoices — client cannot reclaim tax</li>
            <li>Wrong tax rate for mixed supplies — split line items when rates differ</li>
            <li>PDF only in image form (flattened scan) — always send the vector PDF from RatPDF</li>
            </ul>

            <h2>Upgrade prompt</h2>
            <p>Free tier: 3 uses per tool per day. High-volume {d['name']} agencies upgrade to Pro for logo upload, larger files, and unlimited daily use — <a href="/Subscription/Plans">compare plans</a> · <a href="/compare">tool alternatives</a>.</p>

            {COUNTRY_EXPANSIONS.get(slug, "")}

            {COUNTRY_TOPUP.get(slug, "")}

            {invoice_long_tail(d, slug)}

            {invoice_universal_supplement(d)}

            {link_graph_invoice(slug, d['name'])}
            {end_cta('/invoice/create', 'Create ' + d['currency'] + ' invoice')}
            """


def body_bulk_gst() -> str:
    return f"""
            <h2>Bulk GST invoice PDF generation for CA firms and finance teams</h2>
            <p>Indian B2B billing at scale means dozens of GST tax invoices each month — each with GSTIN, HSN/SAC, place of supply, and CGST/SGST or IGST split. RatPDF's <a href="/invoice/bulk">Bulk GST Invoice Generator</a> turns a CSV row per invoice into a ZIP of compliant PDFs.</p>
            <p>Parent guides: <a href="/guides/invoice-generator-india">Invoice generator India</a> · <a href="/guides/invoice-generator-guide">invoice generator guide</a>.</p>

            {shot("Bulk invoice CSV upload screen with GSTIN and HSN columns preview")}

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

            {mid_cta('/invoice/bulk', 'Open bulk GST invoices', 'Generate up to 100 GST invoice PDFs per batch')}

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
            {BULK_GST_EXTRA}
            {BULK_GST_EXTRA_2}
            {bulk_long_tail()}
            {BULK_PREMIUM}
            {BULK_PREMIUM_2}

            <h2>Year-one bulk maturity model</h2>
            <p>Month 1–3: manual CSV with heavy QA. Month 4–6: Excel macros pull from Tally. Month 7+: optional API export from billing system into CSV template. Each stage reduces error rate — jumping to month 7 workflow without month 1 discipline causes GSTN mismatches.</p>
            <p>Compare: <a href="/compare">business tool alternatives</a> · Single invoice fallback: <a href="/invoice/create">Create Invoice</a>.</p>

            <h2>Client FAQ after bulk send</h2>
            <p><strong>Wrong GSTIN on one PDF?</strong> Issue credit note row next batch — never resend same invoice number. <strong>Missing HSN?</strong> Regenerate row from CSV after fix. <strong>ZIP too large?</strong> Use secure share link instead of email attachment.</p>

            <h2>GST compliance officer handoff</h2>
            <p>Provide compliance team: CSV upload log, ZIP SHA-256, sample PDF set, and GSTR-1 draft screenshot. Bulk workflow succeeds when finance and compliance share the same invoice number authority — document who owns the master CSV.</p>

            <p>End-to-end path: <a href="/guides/invoice-generator-india">India guide</a> → CSV prep → <a href="/invoice/bulk">bulk tool</a> → client email → GSTR-1. Research: <a href="/research/freelancer-invoicing-statistics">freelancer invoicing statistics</a>. Compare: <a href="/compare">tool alternatives</a>. Upgrade: <a href="/Subscription/Plans">Business plan</a> for bulk batches.</p>

            {end_cta('/invoice/bulk', 'Start bulk GST batch', '<a href="/invoice/create">Single invoice</a>')}
            """


def body_recurring() -> str:
    return f"""
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

            {RECURRING_EXTRA}
            {RECURRING_EXTRA_2}
            {recurring_long_tail()}
            {RECURRING_PREMIUM}
            {RECURRING_PREMIUM_2}
            {RECURRING_PREMIUM_3}

            <h2>Summary: recurring PDF discipline</h2>
            <p>Successful recurring billing is repetition without sloppiness — same tax IDs, incremented invoice numbers, updated dates, and PDF sent from the same email identity clients trust. RatPDF keeps generation fast; your ledger keeps finance honest.</p>
            <p>Mid-article reminder: <a href="/invoice/create">Create Invoice</a> · End-of-month bulk: <a href="/guides/bulk-gst-invoice-generator">bulk GST guide</a>.</p>

            <h2>Recurring billing anti-patterns</h2>
            <p>Avoid: copying last month's PDF in Photoshop (breaks text search); skipping months then double-billing; changing tax rate without client email notice; using personal name when contract shows company. Each creates AP rejection or audit noise.</p>

            <h2>Annual review of retainer templates</h2>
            <p>Each January, verify tax rates, your legal name, bank details, and client GSTIN/VAT IDs still match government registries. One hour prevents twelve months of rejected PDFs. Update <a href="/guides/invoice-generator-india">India</a>, <a href="/guides/invoice-generator-uk">UK</a>, or <a href="/guides/invoice-generator-australia">Australia</a> guides when local rules change.</p>

            {RECURRING_FINAL}

            <h2>Related guides</h2>
            <ul>
            <li><a href="/guides/invoice-generator-india">Invoice generator India</a></li>
            <li><a href="/guides/bulk-gst-invoice-generator">Bulk GST invoice generator</a></li>
            <li><a href="/guides/invoice-for-freelancers">Invoice for freelancers</a></li>
            </ul>
            <p><a href="/invoice/create" class="btn btn-primary">Create recurring invoice PDF</a> · <a href="/Subscription/Plans">Upgrade for volume</a></p>
            """


def pdf_long_tail(focus: str) -> str:
    return f"""
            <h2>Understanding the PDF to Word pipeline</h2>
            <p>PDF stores text, vectors, and images in a fixed layout. Word expects flowing paragraphs and style definitions. RatPDF bridges the gap by analysing structure first — {focus}. When structure cannot be inferred, pages render as images inside DOCX so you still receive an editable container rather than broken glyphs.</p>

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
            <p>This page focuses on {focus}. Start at <a href="/guides/pdf-to-word">PDF to Word hub</a> for tool overview, then return here for specialised workflow.</p>
            """


def bulk_long_tail() -> str:
    return """
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
            """


def recurring_long_tail() -> str:
    return """
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
            """


def body_pdf_mac() -> str:
    return f"""
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

            {PDF_MAC_EXTRA}
            {PDF_MAC_EXTRA_2}
            {pdf_long_tail("optimised for Safari uploads on macOS")}
            {PDF_CLUSTER_PREMIUM}
            {PDF_PAGE_PREMIUM}
            {PDF_FINAL_BOOST}

            <h2>Closing workflow summary</h2>
            <p>Pick the right path: digital PDF → PDF to Word; scan → OCR → PDF to Word; layout-critical → verify tables in Word before delivery. Mac users stay in Safari; enterprise users compare <a href="/compare/adobe-alternative">Adobe alternative</a> before buying seats.</p>
            <p>Research citation: <a href="/research/pdf-compression-benchmark">PDF compression benchmark</a> — relevant when re-exporting large edited DOCX to email-sized PDFs.</p>

            """ + link_graph_pdf_word() + """
            <p><a href="/pdf/pdftodoc" class="btn btn-primary">PDF to Word on Mac</a> · <a href="/compare/ilovepdf-alternative">iLovePDF alternative</a></p>
            """


def body_keep_formatting() -> str:
    return f"""
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
            {PDF_FORMAT_EXTRA}
            {PDF_FORMAT_EXTRA_2}
            {pdf_long_tail("prioritising table and logo preservation via pdf2docx")}
            {PDF_CLUSTER_PREMIUM}
            {PDF_PAGE_PREMIUM}
            {PDF_FINAL_BOOST}

            <h2>When to escalate to source files</h2>
            <p>If two conversion attempts produce poor tables, stop — request native DOCX/XLSX from issuer. Conversion is for unavoidable PDF-only workflows, not lazy data exchange.</p>
            <p>Tool CTA: <a href="/pdf/pdftodoc">PDF to Word</a> · Research: <a href="/research/pdf-compression-benchmark">PDF compression benchmark</a>.</p>

            """ + link_graph_pdf_word() + """
            <p><a href="/pdf/pdftodoc" class="btn btn-primary">Convert with layout focus</a></p>
            """


def body_scanned() -> str:
    return f"""
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
            {PDF_SCANNED_EXTRA}
            {PDF_SCANNED_EXTRA_2}
            {pdf_long_tail("OCR-first for image-only scans before Word conversion")}
            {PDF_CLUSTER_PREMIUM}
            {PDF_PAGE_PREMIUM}
            {PDF_FINAL_BOOST}

            <h2>OCR + Word handoff checklist</h2>
            <p>After OCR, search for a known phrase before Word step. After Word, search same phrase — if missing, OCR language or scan DPI was insufficient. Rescan at 300 DPI before blaming converter.</p>
            <p>Primary tools: <a href="/pdf/ocrpdf">OCR PDF</a> and <a href="/pdf/pdftodoc">PDF to Word</a> — compare <a href="/compare/smallpdf-alternative">Smallpdf alternative</a> if evaluating vendors.</p>

            <h2>Quality gate before client delivery</h2>
            <p>Run spell-check in Word, verify page count matches source, and confirm critical dates and amounts survived OCR. Remove reviewer comments before exporting final PDF for filing. Archive the searchable OCR PDF alongside the Word draft.</p>

            """ + link_graph_pdf_word() + """
            <p><a href="/pdf/ocrpdf" class="btn btn-primary">Start with OCR</a> · <a href="/compare/adobe-alternative">Adobe alternative</a></p>
            """


BODY_BUILDERS = {
    "bulk-gst-invoice-generator": body_bulk_gst,
    "recurring-invoice-generator": body_recurring,
    "pdf-to-word-mac": body_pdf_mac,
    "pdf-to-word-keep-formatting": body_keep_formatting,
    "scanned-pdf-to-word": body_scanned,
}


def main():
    lines = [
        "namespace ratpdf.Content",
        "{",
        "    /// <summary>Wave 1 premium guide bodies — manual upgrade tier (SEO audit).</summary>",
        "    internal static class GuideBodiesWave1",
        "    {",
        "        public static string? Get(string slug) => slug switch",
        "        {",
    ]
    for slug in SLUGS:
        cn = const_name(slug)
        if slug.startswith("invoice-generator-"):
            lines.append(f'            "{slug}" => {cn},')
        else:
            lines.append(f'            "{slug}" => {cn},')
    lines.append("            _ => null")
    lines.append("        };")
    lines.append("")

    for slug in SLUGS:
        cn = const_name(slug)
        if slug in BODY_BUILDERS:
            body = BODY_BUILDERS[slug]()
        elif slug in COUNTRY_DATA:
            body = body_invoice_country(slug)
        else:
            body = f"<p>Upgrade pending for {slug}</p>"
        content = body.lstrip("\n").rstrip()
        lines.append(f"        private const string {cn} = \"\"\"")
        lines.append(content)
        lines.append("            \"\"\";")
        lines.append("")

    lines.append("    }")
    lines.append("}")
    OUT.write_text("\n".join(lines) + "\n", encoding="utf-8")
    print(f"Wrote {OUT} ({len(SLUGS)} guides)")


if __name__ == "__main__":
    main()
