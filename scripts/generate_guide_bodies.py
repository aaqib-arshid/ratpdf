#!/usr/bin/env python3
"""Generate GuideBodiesGenerated.cs for all guide slugs (ContentLibrary + roadmap)."""
import csv
import re
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]
LIB = ROOT / "Content" / "ContentLibrary.cs"
HOWTO = ROOT / "Content" / "GuideHowToSteps.cs"
ROADMAP = ROOT / "Data" / "content-roadmap.csv"
OUT = ROOT / "Content" / "GuideBodiesGenerated.cs"

HAND_WRITTEN_FILES = [
    ROOT / "Content" / "GuideBodies.cs",
    ROOT / "Content" / "GuideBodiesExtended.cs",
    ROOT / "Content" / "GuideBodiesMedicalImageDev.cs",
]

SLUG_LINE_RE = re.compile(r'^\s+\("([a-z0-9-]+)",', re.M)
TITLE_DESC_RE = re.compile(r'^\s+\("([a-z0-9-]+)",\s*"((?:[^"\\]|\\.)*)"\s*,\s*"((?:[^"\\]|\\.)*)"', re.M)
HOWTO_RE = re.compile(r'\["([a-z0-9-]+)"\]\s*=\s*\[([^\]]+)\]', re.DOTALL)
STEP_RE = re.compile(r'"([^"]+)"')
SWITCH_SLUG_RE = re.compile(r'"([a-z0-9-]+)"\s*=>')
BLOG_ONLY_MARKER = "private static IEnumerable<ContentEntry> BuildBlogs"


def variant(slug: str, n: int) -> int:
    return (hash(slug) & 0x7FFFFFFF) % n


def parse_blog_slugs() -> set[str]:
    text = LIB.read_text(encoding="utf-8")
    if BLOG_ONLY_MARKER not in text:
        return set()
    text = text.split(BLOG_ONLY_MARKER, 1)[1]
    return set(SLUG_LINE_RE.findall(text))


def unescape_cs(s: str) -> str:
    return s.replace('\\"', '"').replace("\\n", "\n")


def load_hand_written_slugs() -> set[str]:
    slugs: set[str] = set()
    for path in HAND_WRITTEN_FILES:
        slugs.update(SWITCH_SLUG_RE.findall(path.read_text(encoding="utf-8")))
    return slugs


def parse_library() -> dict[str, dict]:
    text = LIB.read_text(encoding="utf-8")
    marker = "private static IEnumerable<ContentEntry> BuildBlogs"
    text = text.split(marker)[0] if marker in text else text
    entries: dict[str, dict] = {}
    for m in TITLE_DESC_RE.finditer(text):
        slug, title, desc = m.groups()
        entries[slug] = {
            "title": unescape_cs(title),
            "desc": unescape_cs(desc),
            "cat": "PDF",
            "tool": None,
            "source": "library",
        }
    for m in SLUG_LINE_RE.finditer(text):
        slug = m.group(1)
        if slug in entries:
            continue
        entries[slug] = {
            "title": slug.replace("-", " ").title(),
            "desc": f"RatPDF guide: {slug.replace('-', ' ')}. Step-by-step workflow using real product features.",
            "cat": "PDF",
            "tool": None,
            "source": "library",
        }
    return entries


def parse_roadmap() -> dict[str, dict]:
    entries: dict[str, dict] = {}
    if not ROADMAP.exists():
        return entries
    with ROADMAP.open(encoding="utf-8-sig") as f:
        for row in csv.DictReader(f):
            url = row.get("RecommendedURL", "")
            if not url.startswith("/guides/"):
                continue
            slug = url.replace("/guides/", "").strip()
            if not slug or slug.startswith("ratpdf-vs-"):
                continue
            if row.get("Status") in ("Merged", "Deferred"):
                continue
            kw = row.get("PrimaryKeyword", slug.replace("-", " ")).strip()
            title = kw[0].upper() + kw[1:] if kw else slug
            entries[slug] = {
                "title": title,
                "desc": f"Practical guide: {kw}. Uses RatPDF tools documented in our product — step-by-step workflow, limits, and related guides.",
                "cat": cluster_to_cat(row.get("Cluster", "")),
                "tool": row.get("ToolURL") or None,
                "source": "roadmap",
                "priority": row.get("Priority", "P2"),
            }
    return entries


def cluster_to_cat(cluster: str) -> str:
    c = cluster.lower()
    if "invoice" in c or "business" in c:
        return "Business"
    if "developer" in c:
        return "Developer"
    return "PDF"


def parse_howto() -> dict[str, list[str]]:
    text = HOWTO.read_text(encoding="utf-8")
    result: dict[str, list[str]] = {}
    for m in HOWTO_RE.finditer(text):
        slug = m.group(1)
        steps = STEP_RE.findall(m.group(2))
        if steps:
            result[slug] = steps
    return result


def parse_roadmap_links() -> dict[str, list[str]]:
    links: dict[str, list[str]] = {}
    if not ROADMAP.exists():
        return links
    with ROADMAP.open(encoding="utf-8-sig") as f:
        for row in csv.DictReader(f):
            url = row.get("RecommendedURL", "")
            if not url.startswith("/guides/"):
                continue
            slug = url.replace("/guides/", "")
            for part in row.get("InternalLinks", "").split(";"):
                part = part.strip()
                if part.startswith("/guides/"):
                    links.setdefault(slug, []).append(part)
    return links


def tool_link(tool: str | None) -> tuple[str, str, str]:
    if not tool:
        return ("/guides/pdf-tools", "PDF tools hub", "PDF tools")
    t = tool.lower()
    if not t.startswith("/"):
        t = "/" + t
    label = t.strip("/").split("/")[-1].replace("-", " ").title()
    return (t, label, label)


def cluster_for(slug: str) -> str:
    if slug.startswith("glossary-"):
        return "glossary"
    if slug.startswith("compress-"):
        return "compress"
    if slug.startswith("invoice-generator-") or slug.startswith("invoice-for-"):
        return "invoice_country"
    if slug.startswith("ocr-pdf-"):
        return "ocr_lang"
    if slug.startswith("merge-"):
        return "merge"
    if "pdf-to-word" in slug or (slug.startswith("convert-") and slug.endswith("-pdf-to-word")):
        return "pdf_to_word"
    if slug.startswith("pdf-to-text") or slug.startswith("extract-text"):
        return "pdf_to_text"
    if "payslip" in slug or "salary-slip" in slug or "pay-slip" in slug:
        return "payslip"
    if any(x in slug for x in ("invoice", "gst", "vat", "hmrc", "ato", "cra", "irs", "e-invoicing", "proforma", "rent-receipt")):
        return "compliance"
    return "general"


def steps_html(steps: list[str], fallback: list[str]) -> str:
    items = steps or fallback
    return "".join(f"<li>{s}</li>" for s in items)


def links_html(links: list[str], defaults: list[tuple[str, str]], limit: int = 8) -> str:
    seen: set[str] = set()
    rows: list[str] = []
    for href, label in defaults:
        if href not in seen:
            rows.append(f'<li><a href="{href}">{label}</a></li>')
            seen.add(href)
    for raw in links:
        if raw in seen or not raw.startswith("/guides/"):
            continue
        label = raw.split("/")[-1].replace("-", " ").title()
        rows.append(f'<li><a href="{raw}">{label}</a></li>')
        seen.add(raw)
        if len(rows) >= limit:
            break
    return "\n".join(rows)


def mid_cta(href: str, label: str) -> str:
    return f"""
            <div class="rp-mid-cta alert alert-primary my-4"><strong>Try it now</strong> — <a href="{href}" class="alert-link fw-semibold">{label} →</a></div>"""


def research_block() -> str:
    return """
            <h2>Research &amp; reference data</h2>
            <p>RatPDF publishes source-linked research pages you can cite in internal wiki or client FAQs:</p>
            <ul>
            <li><a href="/research/attachment-size-limits">Email &amp; portal attachment size limits (2026)</a></li>
            <li><a href="/research/pdf-compression-benchmark">PDF compression benchmark by document type</a></li>
            <li><a href="/research/freelancer-invoicing-statistics">Freelancer invoicing statistics</a></li>
            <li><a href="/research/pdf-tool-market-comparison">PDF tool market comparison</a></li>
            </ul>"""


def tool_chain_block() -> str:
    return """
            <h2>Typical PDF toolchain order</h2>
            <p>Most real jobs chain several browser tools — order matters:</p>
            <ol>
            <li><strong>Scanned input?</strong> Run <a href="/pdf/ocrpdf">OCR PDF</a> first so text is selectable.</li>
            <li><strong>Need edits?</strong> Convert with <a href="/pdf/pdftodoc">PDF to Word</a> or use <a href="/guides/edit-pdf">Edit PDF</a>.</li>
            <li><strong>Multiple files?</strong> <a href="/pdf/merge">Merge PDF</a> in the correct page order before upload.</li>
            <li><strong>Size cap?</strong> <a href="/pdf/compress">Compress PDF</a> last — compressing twice rarely helps.</li>
            <li><strong>Delivery?</strong> Sign, watermark, or password-protect only on the final copy.</li>
            </ol>
            <p>Hub: <a href="/guides/pdf-tools">PDF tools guide</a> · Compare vendors: <a href="/compare">compare PDF apps</a>.</p>"""


def honest_limits_block(href: str, label: str) -> str:
    return f"""
            <h2>Honest limits (browser vs desktop)</h2>
            <p>RatPDF runs in the browser — no IT install ticket. Free tier: three uses per tool per day; Pro raises file-size and daily caps. {label} is not a full Acrobat replacement for prepress PDF/X, certified PDF/A, or enterprise PKI signing.</p>
            <p>Confidential documents: read the <a href="/Home/Privacy">privacy policy</a> retention window before uploading client contracts. Upgrade paths: <a href="/Subscription/Plans">subscription plans</a>.</p>
            <p>When {label} is not enough, compare desktop options on <a href="/compare">tool comparisons</a> — then return to RatPDF for quick one-off jobs via <a href="{href}">{label}</a>.</p>"""


def mistakes_block(cluster: str, slug: str) -> str:
    v = variant(slug, 4)
    pools = {
        "compliance": [
            "<li>Reusing last month's invoice number instead of issuing a new sequential ID</li><li>Mixing CGST/SGST lines on an inter-state IGST sale</li><li>Emailing a draft PDF before IRN/e-invoice validation (India B2B)</li><li>Storing only the email thread — not the signed PDF archive</li>",
            "<li>Missing supplier GSTIN/VAT ID on B2B tax invoices</li><li>Wrong HSN/SAC code on service lines</li><li>PDF looks fine but JSON/e-invoice payload was never filed</li><li>Using proforma PDF as final tax invoice without reissue</li>",
            "<li>Currency symbol correct but tax rate from wrong jurisdiction</li><li>Client legal name typo — breaks input-tax credit claims</li><li>Scan-only invoice with no searchable text for audit search</li><li>Flattening before accountant review — loses editable backup</li>",
            "<li>Backdating invoice PDF without matching supply date in ERP</li><li>QR code present but IRN cancelled in portal</li><li>Rent receipt without landlord PAN when required</li><li>Payslip PDF missing employer registration fields</li>",
        ],
        "compress": [
            "<li>Running Extreme compression on signed legal exhibits — blurs stamps</li><li>Compressing before merge — then merging uncompressed appendices and blowing the cap again</li><li>Trusting file size in explorer without Base64 email overhead (~33%)</li><li>Deleting the uncompressed master before verifying portal acceptance</li>",
        ],
        "general": [
            "<li>Uploading password-locked PDFs without unlocking first</li><li>Assuming copy-paste works on scans — need OCR first</li><li>Merging files in wrong order for visa or loan bundles</li><li>Using black highlight instead of true redaction on PII</li>",
        ],
    }
    items = pools.get(cluster, pools["general"])[v % len(pools.get(cluster, pools["general"]))]
    return f"""
            <h2>Common mistakes to avoid</h2>
            <ul>{items}</ul>
            <p>Operational guides only — confirm tax and legal rules with your accountant or counsel.</p>"""


def summary_section(title: str) -> str:
    return f"""
            <h2>Summary &amp; next steps</h2>
            <p>This guide covered <strong>{title}</strong> with RatPDF browser tools — no desktop install. Bookmark the linked pillar pages for repeat workflows; use <a href="/guides/pdf-tools">PDF tools hub</a> when you are unsure which tool to open first.</p>
            <p>Compare alternatives: <a href="/compare">compare PDF &amp; invoice tools</a> · Upgrade for volume: <a href="/Subscription/Plans">plans</a>.</p>"""


def jurisdiction_from_slug(slug: str) -> tuple[str, str, str]:
    """Return (region label, country guide slug, tax authority hint)."""
    s = slug.lower()
    if "india" in s or "gst" in s or "cgst" in s or "hsn" in s or "irn" in s:
        return ("India", "/guides/invoice-generator-india", "GST / CBIC")
    if "uk" in s or "hmrc" in s or "vat" in s and "eu" not in s:
        return ("United Kingdom", "/guides/invoice-generator-uk", "HMRC")
    if "usa" in s or "irs" in s or "1099" in s:
        return ("United States", "/guides/invoice-generator-usa", "IRS")
    if "australia" in s or "ato" in s:
        return ("Australia", "/guides/invoice-generator-australia", "ATO")
    if "canada" in s or "cra" in s:
        return ("Canada", "/guides/invoice-generator-canada", "CRA")
    if "eu" in s or "e-invoic" in s:
        return ("European Union", "/guides/vat-invoice-eu-requirements", "EU VAT / Peppol")
    return ("your jurisdiction", "/guides/invoice-generator-guide", "local tax authority")


def glossary_body(slug: str, meta: dict) -> str:
    term = slug.replace("glossary-", "").replace("-", " ")
    title_term = term.title()
    v = variant(slug, 3)
    intros = [
        f"In PDF and business workflows, <strong>{title_term}</strong> shows up in vendor dialogs, tax portals, and HR packs. This glossary entry defines the term in plain language — not legal or tax advice.",
        f"Teams new to PDF tooling often confuse <strong>{title_term}</strong> with nearby concepts (compression vs flattening, OCR vs extract). Below is a practical definition tied to RatPDF tools.",
        f"<strong>{title_term}</strong> appears in compliance checklists, Acrobat help, and accounting exports. Understanding it helps you pick the right RatPDF tool and avoid rework.",
    ]
    return f"""
            <h2>What is {title_term}?</h2>
            <p>{meta['title']} — {intros[v]}</p>
            <p class="lead">{meta['desc'].split('—')[0].strip()} — see linked pillar guides for click-by-click workflows.</p>

            <h2>Definition in plain language</h2>
            <p><strong>{title_term}</strong> refers to a concept or document type used when creating, sharing, or archiving PDFs. Glossary pages explain <em>what it means</em>; pillar guides show <em>how to execute</em> with RatPDF.</p>
            <p>Glossary vs how-to: start here for vocabulary, then open the workflow guide when you need numbered steps.</p>

            <h2>Why {title_term} matters</h2>
            <p>PDF is both a visual format and a structured file. Mislabeling document types (proforma vs tax invoice, payslip vs contract) causes payment delays, rejected portal uploads, and audit findings. Map unfamiliar labels back to this entry when help docs assume desktop Acrobat expertise.</p>

            <h2>Practical example</h2>
            <p>When you <a href="/pdf/compress">compress a PDF</a>, <a href="/pdf/merge">merge documents</a>, or <a href="/pdf/ocrpdf">run OCR</a>, related terms appear in compression dialogs, metadata panels, and tax PDF footers. Cross-check definitions before sending client-facing files.</p>

            <h2>When this term applies vs when it does not</h2>
            <ul>
            <li><strong>Applies</strong> — naming files, training staff, mapping ERP export labels to PDF deliverables</li>
            <li><strong>Does not replace</strong> — statutory filing (e-invoice JSON, VAT return), certified PDF/A, or legal review</li>
            </ul>

            {mid_cta("/guides/pdf-tools", "PDF tools hub")}

            <h2>Related RatPDF tools</h2>
            <ul>
            <li><a href="/guides/pdf-tools">PDF tools hub</a></li>
            <li><a href="/guides/compress-pdf-guide">Compress PDF guide</a></li>
            <li><a href="/guides/merge-pdf">Merge PDF guide</a></li>
            <li><a href="/guides/ocr-pdf">OCR PDF guide</a></li>
            <li><a href="/guides/invoice-generator-guide">Invoice generator guide</a></li>
            <li><a href="/guides/secure-pdf-workflow">Secure PDF workflow</a></li>
            </ul>

            <h2>Related glossary terms</h2>
            <ul>
            <li><a href="/guides/glossary-pdf">What is PDF</a> · <a href="/guides/glossary-compression">Compression</a> · <a href="/guides/glossary-merge">Merge</a></li>
            <li><a href="/guides/glossary-ocr">OCR</a> · <a href="/guides/glossary-metadata">Metadata</a> · <a href="/guides/glossary-tax-invoice">Tax invoice</a></li>
            <li><a href="/guides/glossary-proforma-invoice">Proforma invoice</a> · <a href="/guides/glossary-e-invoice">E-invoice</a></li>
            </ul>

            {tool_chain_block()}
            {research_block()}
            {honest_limits_block("/guides/pdf-tools", "PDF tools hub")}
            {summary_section(title_term)}"""


def compress_body(slug: str, meta: dict, steps: list[str], links: list[str]) -> str:
    topic = slug.replace("compress-pdf-", "").replace("compress-", "").replace("-", " ")
    step_html = steps_html(
        steps,
        [
            "Check current size on the <a href=\"/pdf-size-checker\">PDF size checker</a> — pick your email or portal preset.",
            "Open <a href=\"/pdf/compress\">Compress PDF</a> and upload the file (free tier: 50 MB; Pro: 100 MB+).",
            "Start with <strong>Recommended</strong> compression — verify text and stamps at 100% zoom.",
            "If still over cap, try Extreme once; if quality suffers, <a href=\"/guides/split-pdf-for-email\">split the PDF</a> instead.",
            "Download, re-check size, attach or upload to the portal.",
        ],
    )
    related = links_html(
        links,
        [
            ("/guides/compress-pdf-guide", "Compress PDF pillar guide"),
            ("/guides/compress-pdf-for-email", "Compress PDF for email"),
            ("/research/attachment-size-limits", "Attachment size limits research"),
            ("/guides/compress-vs-split", "Compress vs split decision guide"),
        ],
    )
    return f"""
            <h2>{meta['title']}</h2>
            <p>{meta['desc']}</p>
            <p>Focus: <strong>{topic}</strong>. RatPDF uses Ghostscript presets on <a href="/pdf/compress">Compress PDF</a> — same engine family many print shops use for distilling PDFs.</p>

            <h2>Why file size blocks {topic}</h2>
            <p>Portals and email gateways measure encoded message size, not just raw PDF bytes. Base64 attachment encoding adds roughly 33% overhead. A 20 MB PDF can exceed a 25 MB Gmail cap before signatures and HTML body are counted.</p>
            <p>Corporate SMTP gateways often enforce 10–20 MB even when consumer mail allows more. Compression is usually faster than re-scanning at lower DPI — start with Recommended, not Extreme.</p>

            <h2>Step-by-step workflow</h2>
            <ol>{step_html}</ol>

            <h2>Choosing a compression level</h2>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>Preset</th><th>Typical savings</th><th>Use when</th></tr></thead>
            <tbody>
            <tr><td><strong>Less</strong></td><td>10–30%</td><td>Legal exhibits, fine print, brand decks</td></tr>
            <tr><td><strong>Recommended</strong></td><td>40–65%</td><td>Default for email and most portals</td></tr>
            <tr><td><strong>Extreme</strong></td><td>70–90%</td><td>Last resort — verify readability after</td></tr>
            </tbody></table></div>
            <p>Benchmark by document type: <a href="/research/pdf-compression-benchmark">PDF compression benchmark</a>.</p>

            {mid_cta("/pdf/compress", "Compress PDF free")}

            <h2>Compress vs split vs cloud link</h2>
            <p>If Recommended compression still misses your target, compare strategies before over-compressing:</p>
            <ul>
            <li><strong>Split</strong> — long scanned bundles; preserves quality per part — <a href="/guides/split-pdf-for-email">split PDF for email</a></li>
            <li><strong>Cloud link</strong> — photo-heavy portfolios where quality is non-negotiable</li>
            <li><strong>Second Extreme pass</strong> — rarely helps on already-compressed scans</li>
            </ul>
            <p>Decision guide: <a href="/guides/compress-vs-split">compress vs split</a> · Size presets: <a href="/pdf-size-checker">PDF size checker</a>.</p>

            {mistakes_block("compress", slug)}

            <h2>Related guides</h2>
            <ul>
            {related}
            </ul>

            {tool_chain_block()}
            {research_block()}
            {summary_section(meta['title'])}"""


def invoice_country_body(slug: str, meta: dict, steps: list[str], links: list[str]) -> str:
    country = slug.replace("invoice-generator-", "").replace("invoice-for-", "").replace("-", " ").title()
    region, country_guide, authority = jurisdiction_from_slug(slug)
    step_html = steps_html(
        steps,
        [
            f"Open <a href=\"/invoice/create\">Create Invoice</a> and pick a template suited to {country}.",
            f"Enter supplier and client legal names, tax IDs, and addresses required in {region}.",
            "Add line items with quantity, unit price, and correct tax rate per line.",
            "Set invoice number, issue date, and payment terms; preview the PDF layout.",
            "Download PDF; store a copy and send via email or client portal.",
        ],
    )
    related = links_html(
        links,
        [
            (country_guide, f"Invoice generator {country}"),
            ("/guides/invoice-generator-guide", "Invoice generator hub"),
            ("/guides/invoice-for-freelancers", "Invoices for freelancers"),
            ("/compare/invoice-generators-freelancers", "Best invoice tools for freelancers"),
        ],
    )
    return f"""
            <h2>PDF invoices for {country}</h2>
            <p>{meta['desc']}</p>
            <p>Create compliant-looking PDF invoices in the browser with <a href="/invoice/create">Create Invoice</a> — confirm mandatory fields with your accountant for {authority} rules.</p>

            <h2>Mandatory fields checklist ({region})</h2>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>Field</th><th>Why it matters</th></tr></thead>
            <tbody>
            <tr><td>Unique invoice number</td><td>Sequential audit trail; duplicates trigger rejection</td></tr>
            <tr><td>Issue / supply date</td><td>Tax period and payment-term calculations</td></tr>
            <tr><td>Supplier legal name &amp; tax ID</td><td>B2B buyers need this for input tax credits</td></tr>
            <tr><td>Client legal name &amp; address</td><td>Dispute resolution and delivery evidence</td></tr>
            <tr><td>Line descriptions + amounts</td><td>HSN/SAC or product codes where required</td></tr>
            <tr><td>Tax rate and tax amount</td><td>Must match jurisdiction — IGST vs CGST/SGST in India</td></tr>
            <tr><td>Total payable</td><td>Match bank transfer amount to the penny</td></tr>
            </tbody></table></div>

            <h2>Step-by-step: create the invoice PDF</h2>
            <ol>{step_html}</ol>

            {mid_cta("/invoice/create", "Create Invoice")}

            {mistakes_block("compliance", slug)}

            <h2>After download — quality checks</h2>
            <ul>
            <li>Open PDF at 100% zoom — logo and table borders render correctly</li>
            <li>Search for invoice number — scans need <a href="/pdf/ocrpdf">OCR PDF</a> first</li>
            <li>If portal caps size, <a href="/pdf/compress">compress a copy</a> — keep archival master uncompressed</li>
            <li>Filename convention: <code>INV-2026-0142-ClientName.pdf</code></li>
            </ul>

            <h2>Freelancer &amp; trade billing tips</h2>
            <p>Independent {country} operators often invoice per project, retainer, or milestone. Show payment terms (Net 14/30), late-fee policy in Notes, and PO number when enterprise clients require it. For recurring clients, duplicate last invoice in <a href="/invoice/create">Create Invoice</a> and increment the invoice number — do not reuse PDFs.</p>
            <p>Compare profession-specific tools: <a href="/compare">invoice generator comparisons</a> · MOFU hub: <a href="/guides/invoice-for-freelancers">invoices for freelancers</a>.</p>

            <h2>Related invoice guides</h2>
            <ul>
            {related}
            </ul>

            {research_block()}
            {honest_limits_block("/invoice/create", "Create Invoice")}
            {summary_section(f"invoices for {country}")}"""


def ocr_lang_body(slug: str, meta: dict, steps: list[str], links: list[str]) -> str:
    lang = slug.replace("ocr-pdf-", "").replace("-", " ").title()
    step_html = steps_html(
        steps,
        [
            "Scan or export source pages at 300 DPI minimum — skewed pages reduce accuracy.",
            f"Open <a href=\"/pdf/ocrpdf\">OCR PDF</a> and upload; select language matching {lang} content.",
            "Review first page — spot-check numbers, dates, and names before batch trust.",
            "Search inside the PDF (Ctrl+F) to confirm hidden text layer exists.",
            "Export text via <a href=\"/guides/pdf-to-text\">PDF to Text</a> or convert to Word if editing layout.",
        ],
    )
    return f"""
            <h2>OCR for {lang} PDFs</h2>
            <p>{meta['desc']}</p>
            <p>Scanned PDFs are images until OCR adds a searchable text layer. RatPDF uses Tesseract-family OCR on <a href="/pdf/ocrpdf">OCR PDF</a> — set the correct language pack for {lang}.</p>

            <h2>OCR vs PDF to Text</h2>
            <p><a href="/guides/ocr-vs-pdf-to-text">OCR vs PDF to Text</a>: extraction reads existing text encoding; OCR interprets pixels on scans. If copy-paste returns nothing, you need OCR first.</p>

            <h2>Accuracy factors</h2>
            <ul>
            <li>300 DPI minimum for small type; 400 DPI for fax-quality sources</li>
            <li>Correct language model — mixed scripts may need multiple passes</li>
            <li>Multi-column layouts — reading order may need cleanup in Word after export</li>
            <li>Handwriting and decorative fonts — expect manual correction</li>
            </ul>

            <h2>Step-by-step workflow</h2>
            <ol>{step_html}</ol>

            {mid_cta("/pdf/ocrpdf", "OCR PDF free")}

            {mistakes_block("general", slug)}

            <h2>After OCR — next steps</h2>
            <ul>
            <li><strong>Edit layout</strong> — <a href="/pdf/pdftodoc">PDF to Word</a> after OCR for contracts</li>
            <li><strong>Search-only archive</strong> — store OCR'd PDF; extract with <a href="/pdf/pdftotext">PDF to Text</a></li>
            <li><strong>Smaller upload</strong> — <a href="/pdf/compress">compress</a> after OCR if portal cap tight</li>
            <li><strong>Bundle scans</strong> — <a href="/pdf/merge">merge PDF</a> then OCR once on combined file (order varies by tool)</li>
            </ul>

            <h2>Related guides</h2>
            <ul>
            <li><a href="/guides/ocr-pdf">OCR PDF hub</a></li>
            <li><a href="/guides/ocr-accuracy-tips">OCR accuracy tips</a></li>
            <li><a href="/pdf/pdftodoc">PDF to Word</a> after OCR for editable layout</li>
            <li><a href="/guides/glossary-ocr">OCR glossary</a> · <a href="/guides/glossary-tesseract">Tesseract glossary</a></li>
            </ul>

            {tool_chain_block()}
            {research_block()}
            {honest_limits_block("/pdf/ocrpdf", "OCR PDF")}
            {summary_section(f"OCR for {lang}")}"""


def merge_body(slug: str, meta: dict, steps: list[str], links: list[str]) -> str:
    step_html = steps_html(
        steps,
        [
            "Collect all PDFs; rename files so sort order matches desired page order.",
            "Rotate sideways pages with <a href=\"/pdf/rotateorremove\">Rotate PDF</a> before merging.",
            "Upload to <a href=\"/pdf/merge\">Merge PDF</a> in correct sequence — cover letter first for visa bundles.",
            "Verify total page count equals sum of inputs; spot-check first and last pages.",
            "If combined size exceeds portal cap, <a href=\"/pdf/compress\">compress</a> after merge.",
        ],
    )
    return f"""
            <h2>{meta['title']}</h2>
            <p>{meta['desc']}</p>
            <p>Merge combines multiple PDFs into one upload-friendly file — common for visa applications, loan packets, and board packs.</p>

            <h2>Before you merge</h2>
            <ul>
            <li>OCR scans first if reviewers need search (<a href="/pdf/ocrpdf">OCR PDF</a>)</li>
            <li>Remove blank trailing pages from individual scans</li>
            <li>Compress oversized scans only if total will exceed cap — see <a href="/guides/compress-before-merge-pdf">compress before or after merge</a></li>
            </ul>

            <h2>Step-by-step workflow</h2>
            <ol>{step_html}</ol>

            {mid_cta("/pdf/merge", "Merge PDF free")}

            {mistakes_block("general", slug)}

            <h2>Merge then compress — ordering</h2>
            <p>Combine first, then <a href="/pdf/compress">compress once</a> on the merged output. Compressing each input separately then merging often wastes time and still misses the combined cap. See <a href="/guides/compress-before-merge-pdf">compress before or after merge</a>.</p>

            <h2>Password-protected inputs</h2>
            <p>Unlock PDFs with permission before merge — locked files fail or merge without visible pages. Guide: <a href="/guides/merge-password-protected-pdf">merge password-protected PDF</a> · <a href="/guides/unlock-pdf">unlock PDF</a>.</p>

            <h2>Related guides</h2>
            <ul>
            <li><a href="/guides/merge-pdf">Merge PDF pillar guide</a></li>
            <li><a href="/guides/merge-pdf-visa-application">Merge PDF for visa</a></li>
            <li><a href="/guides/merge-vs-compress">Merge vs compress</a></li>
            <li><a href="/guides/split-pdf">Split PDF</a> — reverse operation when bundle too large</li>
            </ul>

            {tool_chain_block()}
            {research_block()}
            {honest_limits_block("/pdf/merge", "Merge PDF")}
            {summary_section(meta['title'])}"""


def pdf_to_word_body(slug: str, meta: dict, steps: list[str], links: list[str]) -> str:
    step_html = steps_html(
        steps,
        [
            "Confirm text is selectable — if not, <a href=\"/pdf/ocrpdf\">OCR PDF</a> first.",
            "Upload to <a href=\"/pdf/pdftodoc\">PDF to Word</a>; wait for conversion on large files.",
            "Open DOCX in Word, Google Docs, or Pages — verify tables and headings.",
            "Edit content; track changes if collaborating with legal or clients.",
            "Export fresh PDF when delivery format must remain PDF.",
        ],
    )
    return f"""
            <h2>{meta['title']}</h2>
            <p>{meta['desc']}</p>
            <p>PDF to Word rebuilds page content as editable DOCX. Quality depends on source: Word-exported PDFs convert best; scans need OCR first.</p>

            <h2>Output expectations by source type</h2>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>Source PDF</th><th>Typical DOCX quality</th></tr></thead>
            <tbody>
            <tr><td>Word / Google Docs export</td><td>Excellent — headings and tables often preserved</td></tr>
            <tr><td>PowerPoint or Canva PDF</td><td>Moderate — text boxes may fragment</td></tr>
            <tr><td>Scanned contract</td><td>Poor without OCR — run OCR PDF first</td></tr>
            </tbody></table></div>

            <h2>Step-by-step workflow</h2>
            <ol>{step_html}</ol>

            {mid_cta("/pdf/pdftodoc", "PDF to Word")}

            {mistakes_block("general", slug)}

            <h2>After conversion — verify these elements</h2>
            <ul>
            <li>Table cell alignment and merged cells</li>
            <li>Header/footer page numbers vs body content</li>
            <li>Bulleted lists and numbered clauses in contracts</li>
            <li>Images and logos — may need re-insertion from source PDF</li>
            </ul>
            <p>Resume-specific tips: <a href="/guides/pdf-to-word-for-resume">PDF to Word for resume</a> · Mac workflow: <a href="/guides/pdf-to-word-mac">PDF to Word on Mac</a>.</p>

            <h2>Related guides</h2>
            <ul>
            <li><a href="/guides/pdf-to-word">PDF to Word pillar guide</a></li>
            <li><a href="/guides/pdf-to-word-vs-pdf-to-text">Word vs plain text export</a></li>
            <li><a href="/guides/ocr-pdf">OCR PDF for scans</a></li>
            <li><a href="/guides/glossary-pdf-to-word-converter">PDF to Word converter glossary</a></li>
            </ul>

            {tool_chain_block()}
            {research_block()}
            {honest_limits_block("/pdf/pdftodoc", "PDF to Word")}
            {summary_section(meta['title'])}"""


def pdf_to_text_body(slug: str, meta: dict, steps: list[str], links: list[str]) -> str:
    step_html = steps_html(
        steps,
        [
            "Test copy-paste from page 1 — if empty, use <a href=\"/pdf/ocrpdf\">OCR PDF</a> instead of extract.",
            "Upload digital PDF to <a href=\"/pdf/pdftotext\">PDF to Text</a> or follow <a href=\"/guides/pdf-to-text\">PDF to Text guide</a>.",
            "Download plain TXT; import to spreadsheet, CMS, or search index.",
            "Spot-check numbers, currency symbols, and hyphenation on financial PDFs.",
            "For formatted editing, convert to Word after extraction or OCR.",
        ],
    )
    return f"""
            <h2>{meta['title']}</h2>
            <p>{meta['desc']}</p>
            <p>PDF to Text pulls encoded characters into plain TXT — faster than Word conversion when you only need words for search, scripts, or LLM ingestion.</p>

            <h2>Extractor vs OCR</h2>
            <p>Extraction reads the PDF text layer. OCR creates that layer on scans. Scanned pages return garbage or empty extraction — always OCR first.</p>

            <h2>Common use cases</h2>
            <ul>
            <li>Log and report analysis from exported PDFs</li>
            <li>Compliance keyword scans before redaction</li>
            <li>Recovering email body text from archived message PDFs</li>
            <li>Building CI search indexes from documentation PDFs</li>
            </ul>

            <h2>Step-by-step workflow</h2>
            <ol>{step_html}</ol>

            {mid_cta("/pdf/pdftotext", "PDF to Text")}

            <h2>Troubleshooting empty extraction</h2>
            <ul>
            <li><strong>Blank output</strong> — page is image-only; run <a href="/pdf/ocrpdf">OCR PDF</a> then extract again</li>
            <li><strong>Garbled Unicode</strong> — custom embedded fonts; try OCR or export from source app</li>
            <li><strong>Columns out of order</strong> — use Word conversion for layout-aware editing</li>
            <li><strong>Password locked</strong> — unlock with permission before extract</li>
            </ul>
            <p>Deep dive: <a href="/guides/ocr-vs-pdf-to-text">OCR vs PDF to Text</a> · Developer path: <a href="/guides/pdf-to-text">PDF to Text pillar</a>.</p>

            <h2>Scanned PDF workflow (recommended order)</h2>
            <ol>
            <li>Re-scan at 300 DPI if source is fax-quality or phone photo</li>
            <li>Deskew and crop in scan app when possible — improves OCR accuracy</li>
            <li><a href="/pdf/ocrpdf">OCR PDF</a> with correct language pack</li>
            <li>Verify search (Ctrl+F) on invoice numbers and dates</li>
            <li>Extract plain text or convert to Word for editing</li>
            </ol>
            <p>OCR tips: <a href="/guides/ocr-accuracy-tips">OCR accuracy tips</a> · Scanned contracts: <a href="/guides/ocr-pdf">OCR PDF hub</a>.</p>

            <h2>Related guides</h2>
            <ul>
            <li><a href="/guides/pdf-txt-guide">PDF to Text hub</a></li>
            <li><a href="/guides/extract-text-from-pdf">Extract text workflow</a></li>
            <li><a href="/guides/ocr-vs-pdf-to-text">OCR vs PDF to Text</a></li>
            </ul>

            {tool_chain_block()}
            {research_block()}
            {honest_limits_block("/pdf/pdftotext", "PDF to Text")}
            {summary_section(meta['title'])}"""


def compliance_body(slug: str, meta: dict, steps: list[str], links: list[str]) -> str:
    region, country_guide, authority = jurisdiction_from_slug(slug)
    topic = slug.replace("-", " ").title()
    step_html = steps_html(
        steps,
        [
            f"Confirm mandatory fields for {region} with your accountant — rules change via {authority} notifications.",
            "Open <a href=\"/invoice/create\">Create Invoice</a> (or payslip generator if applicable) and enter legal entity details.",
            "Add line items with correct tax codes (HSN/SAC in India, VAT categories in EU/UK).",
            "Preview PDF — verify totals, tax breakdown, and client details at 100% zoom.",
            "Download PDF; archive immutably; send via email or portal; file e-invoice JSON if required separately.",
        ],
    )
    related = links_html(
        links,
        [
            (country_guide, f"Invoice generator ({region})"),
            ("/guides/gst-invoice-format-india", "GST invoice format India"),
            ("/guides/vat-invoice-eu-requirements", "EU VAT invoice requirements"),
            ("/guides/hmrc-invoice-requirements", "HMRC invoice requirements"),
            ("/guides/glossary-e-invoice", "E-invoice glossary"),
            ("/guides/glossary-tax-invoice", "Tax invoice glossary"),
        ],
    )
    v = variant(slug, 3)
    context = [
        f"Businesses in {region} must issue PDF invoices that satisfy {authority} field requirements — this guide maps workflow steps to RatPDF tools, not legal advice.",
        f"Tax auditors search for sequential invoice numbers, correct tax lines, and immutable PDF archives. {topic} workflows start in browser tools, finish in your ERP and accountant review.",
        f"Portal rejection often comes from missing tax IDs or wrong IGST/CGST split — not from PDF software. Use this checklist before uploading {topic} deliverables.",
    ][v]
    return f"""
            <h2>{meta['title']}</h2>
            <p>{meta['desc']}</p>
            <p>{context}</p>

            <h2>Compliance checklist ({region})</h2>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>Requirement</th><th>Practical check</th></tr></thead>
            <tbody>
            <tr><td>Unique invoice / document number</td><td>No duplicates in FY; credit notes reference original</td></tr>
            <tr><td>Supplier tax registration</td><td>GSTIN / VAT ID / ABN visible on PDF</td></tr>
            <tr><td>Buyer details (B2B)</td><td>Legal name + billing address match PO</td></tr>
            <tr><td>Tax rate per line</td><td>IGST inter-state vs CGST+SGST intra-state (India)</td></tr>
            <tr><td>HSN/SAC or product codes</td><td>Match ERP master data</td></tr>
            <tr><td>E-invoice / IRN (if mandated)</td><td>JSON + QR validated in portal — PDF alone insufficient</td></tr>
            <tr><td>Immutable archive</td><td>Store approved PDF; do not edit in place</td></tr>
            </tbody></table></div>
            <p>Confirm current rules with {authority} publications — not legal advice.</p>

            <h2>Step-by-step workflow</h2>
            <ol>{step_html}</ol>

            {mid_cta("/invoice/create", "Create Invoice")}

            {mistakes_block("compliance", slug)}

            <h2>PDF quality before send</h2>
            <ul>
            <li>Searchable text — OCR scans with <a href="/pdf/ocrpdf">OCR PDF</a> if clients search attachments</li>
            <li>Size caps — <a href="/pdf/compress">compress a copy</a> for email; keep master uncompressed</li>
            <li>Redact unrelated PII on shared copies — <a href="/guides/pdf-redaction">PDF redaction guide</a></li>
            <li>Metadata scrub internal author names on external RFP PDFs — <a href="/pdf/pdfmetadata">PDF Metadata</a></li>
            <li>Version suffix in filename when reissuing corrected tax PDFs</li>
            </ul>

            <h2>Related compliance guides</h2>
            <ul>
            {related}
            </ul>

            {research_block()}
            {honest_limits_block("/invoice/create", "Create Invoice")}
            {summary_section(topic)}"""


def payslip_body(slug: str, meta: dict, steps: list[str], links: list[str]) -> str:
    region, country_guide, authority = jurisdiction_from_slug(slug)
    topic = slug.replace("-", " ").title()
    step_html = steps_html(
        steps,
        [
            "Gather pay period, employee ID, gross/net amounts, and statutory deductions from payroll export.",
            "Open payslip generator or <a href=\"/invoice/create\">Create Invoice</a> for contractor-style payslips where applicable.",
            f"Enter employer registration fields required in {region} ({authority} context).",
            "Preview PDF layout — verify YTD totals, deduction labels, and currency formatting.",
            "Download PDF; distribute via secure channel (not personal WhatsApp for PII); archive per HR retention policy.",
        ],
    )
    related = links_html(
        links,
        [
            ("/guides/glossary-payslip", "Payslip glossary"),
            ("/guides/glossary-salary-slip", "Salary slip glossary"),
            (country_guide, f"Invoice / business docs ({region})"),
            ("/guides/invoice-generator-guide", "Invoice generator hub"),
        ],
    )
    return f"""
            <h2>{meta['title']}</h2>
            <p>{meta['desc']}</p>
            <p>Payslip PDFs must be readable, searchable, and stored under HR retention rules in {region}. RatPDF helps generate, merge, and compress payslip PDFs — payroll calculation stays in your HRIS, spreadsheet, or accountant workflow.</p>

            <h2>Fields employees expect on payslip PDFs</h2>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>Field</th><th>Notes</th></tr></thead>
            <tbody>
            <tr><td>Employer legal name &amp; registration</td><td>Matches employment contract entity</td></tr>
            <tr><td>Employee name &amp; ID</td><td>Consistent with HRIS — typos break loan verification</td></tr>
            <tr><td>Pay period &amp; payment date</td><td>Clear frequency (monthly, bi-weekly)</td></tr>
            <tr><td>Gross, deductions, net pay</td><td>Labels match local statutory names (PF, HRA, PAYE, etc.)</td></tr>
            <tr><td>YTD totals</td><td>Reduces year-end support tickets and tax filing errors</td></tr>
            <tr><td>Bank / payment reference (if shown)</td><td>Mask account numbers on employee copies when policy requires</td></tr>
            </tbody></table></div>

            <h2>Step-by-step workflow</h2>
            <ol>{step_html}</ol>

            {mid_cta("/guides/invoice-generator-guide", "Invoice &amp; payslip tools")}

            {mistakes_block("compliance", slug)}

            <h2>Distribution &amp; privacy</h2>
            <ul>
            <li>Send payslip PDFs over encrypted email or HR portal — not open chat apps</li>
            <li>Batch monthly PDFs? <a href="/pdf/merge">Merge PDF</a> for HR review copy only — employees get individual files</li>
            <li>Email size caps? <a href="/pdf/compress">Compress PDF</a> on copies — keep HRIS export uncompressed</li>
            <li>Scanned legacy payslips? <a href="/pdf/ocrpdf">OCR PDF</a> for search during audits</li>
            </ul>

            <h2>Related guides</h2>
            <ul>
            {related}
            </ul>

            {tool_chain_block()}
            {research_block()}
            {honest_limits_block("/guides/invoice-generator-guide", "Invoice &amp; payslip tools")}
            {summary_section(topic)}"""


def general_body(slug: str, meta: dict, steps: list[str], links: list[str]) -> str:
    href, label, _ = tool_link(meta.get("tool"))
    v = variant(slug, 4)
    step_html = steps_html(
        steps,
        [
            f"Open <a href=\"{href}\">{label}</a> in your browser — no install required.",
            "Upload source file(s); wait for processing on large documents.",
            "Review output at 100% zoom — page count, tables, and images.",
            "Download result; keep original archived separately.",
            "Chain next tool if needed (OCR → edit → merge → compress).",
        ],
    )
    related = links_html(
        links,
        [
            ("/guides/pdf-tools", "PDF tools hub"),
            ("/guides/choose-pdf-tool", "Choose a PDF tool"),
            ("/compare", "Compare PDF tools"),
            (href, label),
        ],
    )
    intros = [
        f"This guide walks through <strong>{meta['title']}</strong> using RatPDF browser tools — practical steps for office workers and freelancers.",
        f"Use this page when you need a dependable workflow for {meta['title']} without installing desktop software.",
        f"RatPDF documents real product limits — this guide covers {meta['title']} with honest expectations and linked pillar pages.",
        f"Teams bookmark task-specific guides like this one to reduce wrong-tool support tickets for {meta['title']}.",
    ]
    return f"""
            <h2>{meta['title']}</h2>
            <p>{intros[v]}</p>
            <p>{meta['desc']}</p>

            <h2>When to use this workflow</h2>
            <ul>
            <li>One-off jobs where Acrobat licensing is overkill</li>
            <li>Remote workers on locked-down laptops — browser-only tools</li>
            <li>Quick client deliverables with download-and-delete privacy model</li>
            </ul>

            <h2>Step-by-step workflow</h2>
            <ol>{step_html}</ol>

            {mid_cta(href, label)}

            {mistakes_block("general", slug)}

            <h2>Best practices</h2>
            <ul>
            <li>Work on copies — never overwrite the only signed master PDF</li>
            <li>OCR scans before Word conversion or text extraction</li>
            <li>Compress last in the toolchain — after merge and edit steps</li>
            <li>Name files with version suffix: <code>-v2-APPROVED.pdf</code></li>
            </ul>

            <h2>Related guides</h2>
            <ul>
            {related}
            </ul>

            {tool_chain_block()}
            {research_block()}
            {honest_limits_block(href, label)}

            <h2>Questions before you start</h2>
            <p><strong>Is the source PDF digital or scanned?</strong> Scans need OCR. <strong>Is layout critical?</strong> Prefer Word conversion over plain text. <strong>Is this the final deliverable?</strong> Compress and sign only on the approved copy. <strong>Need a audit trail?</strong> Keep versioned filenames and store originals outside email threads.</p>

            {summary_section(meta['title'])}"""


def generate_body(slug: str, meta: dict, steps: list[str], links: list[str]) -> str:
    c = cluster_for(slug)
    builders = {
        "glossary": lambda: glossary_body(slug, meta),
        "compress": lambda: compress_body(slug, meta, steps, links),
        "invoice_country": lambda: invoice_country_body(slug, meta, steps, links),
        "ocr_lang": lambda: ocr_lang_body(slug, meta, steps, links),
        "merge": lambda: merge_body(slug, meta, steps, links),
        "pdf_to_word": lambda: pdf_to_word_body(slug, meta, steps, links),
        "pdf_to_text": lambda: pdf_to_text_body(slug, meta, steps, links),
        "compliance": lambda: compliance_body(slug, meta, steps, links),
        "payslip": lambda: payslip_body(slug, meta, steps, links),
    }
    return builders.get(c, lambda: general_body(slug, meta, steps, links))()


def cs_string_literal(html: str) -> str:
    lines = [ln.strip() for ln in html.strip().splitlines() if ln.strip()]
    body = "\n".join("            " + ln for ln in lines)
    return f'"""\n{body}\n            """'


def main():
    hand = load_hand_written_slugs()
    lib = parse_library()
    road = parse_roadmap()
    all_meta = {**road, **lib}
    howto = parse_howto()
    roadmap_links = parse_roadmap_links()

    blog_only = parse_blog_slugs() - set(lib.keys())
    guide_slugs = {s for s in all_meta if s not in blog_only}
    missing = sorted(s for s in guide_slugs if s not in hand)

    print(f"Library parsed: {len(lib)}, Roadmap extras: {len(road)}, Hand-written: {len(hand)}, Generate: {len(missing)}")

    cases, constants = [], []
    for slug in missing:
        meta = all_meta[slug]
        steps = howto.get(slug, [])
        links = roadmap_links.get(slug, [])
        const_name = "G_" + re.sub(r"[^a-zA-Z0-9]", "_", slug)
        body = generate_body(slug, meta, steps, links)
        constants.append(f"        private const string {const_name} = {cs_string_literal(body)};")
        cases.append(f'            "{slug}" => {const_name},')

    header = """namespace ratpdf.Content
{
    /// <summary>Auto-generated guide bodies (Scripts/generate_guide_bodies.py).</summary>
    internal static class GuideBodiesGenerated
    {
        public static string? Get(string slug) => slug switch
        {
"""
    footer = """            _ => null
        };

"""
    out_text = header + "\n".join(cases) + footer + "\n".join(constants) + "\n    }\n}\n"
    OUT.write_text(out_text, encoding="utf-8")
    print(f"Wrote {OUT} ({len(missing)} articles)")


if __name__ == "__main__":
    main()
