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
    # Fallback: slugs with escaped quotes in description that broke TITLE_DESC_RE
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


def tool_link(tool: str | None) -> str:
    if not tool:
        return '<a href="/guides/pdf-tools">PDF tools hub</a>'
    t = tool.lower()
    if not t.startswith("/"):
        t = "/" + t
    return f'<a href="{t}">{t.strip("/").split("/")[-1].replace("-", " ").title()}</a>'


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
    if any(x in slug for x in ("invoice", "gst", "vat", "hmrc", "ato", "cra", "irs", "e-invoicing")):
        return "compliance"
    return "general"


def glossary_body(slug: str, meta: dict) -> str:
    term = slug.replace("glossary-", "").replace("-", " ")
    title_term = term.title()
    return f"""
            <h2>What is {title_term}?</h2>
            <p>{meta['desc']}</p>
            <p>In PDF workflows on RatPDF, understanding <strong>{title_term}</strong> helps you choose the right tool and avoid compliance mistakes. This glossary entry explains the concept in plain language for office workers, developers, and admins — not legal advice.</p>

            <h2>Why {title_term} matters for PDF users</h2>
            <p>PDF is both a visual format and a structured file format. Terms like {title_term} appear in Acrobat dialogs, developer docs, accessibility checkers, and security settings. Knowing the definition saves time when debugging failed uploads, OCR output, or encrypted attachments.</p>

            <h2>Practical example</h2>
            <p>When you <a href="/pdf/compress">compress a PDF</a>, <a href="/pdf/merge">merge documents</a>, or <a href="/pdf/ocrpdf">run OCR</a>, software may reference related concepts (compression, object streams, text layers). Map unfamiliar labels back to this glossary when vendor help pages assume desktop Acrobat expertise.</p>

            <h2>Related RatPDF tools</h2>
            <ul>
            <li><a href="/guides/pdf-tools">PDF tools hub</a></li>
            <li><a href="/guides/compress-pdf-guide">Compress PDF</a></li>
            <li><a href="/guides/merge-pdf">Merge PDF</a></li>
            <li><a href="/guides/ocr-pdf">OCR PDF</a></li>
            <li><a href="/guides/secure-pdf-workflow">Secure PDF workflow</a></li>
            </ul>

            <h2>Further reading</h2>
            <p>Adobe PDF Reference and ISO 32000 define formal specifications. For workflow help: <a href="/guides/choose-pdf-tool">choose a PDF tool</a> · <a href="/compare">compare PDF apps</a>.</p>"""


def compress_body(slug: str, meta: dict, steps: list[str], links: list[str]) -> str:
    topic = slug.replace("compress-pdf-", "").replace("compress-", "").replace("-", " ")
    step_html = "".join(f"<li>{s}</li>" for s in steps) or (
        "<li>Check size on <a href=\"/pdf-size-checker\">PDF size checker</a>.</li>"
        "<li>Upload to <a href=\"/pdf/compress\">Compress PDF</a> → Recommended.</li>"
        "<li>Verify at 100% zoom; download and submit.</li>"
    )
    extra_links = "".join(f'<li><a href="{l}">{l.split("/")[-1]}</a></li>' for l in links[:6])
    return f"""
            <h2>{meta['title']}</h2>
            <p>{meta['desc']}</p>
            <p>Ghostscript presets (Less, Recommended, Extreme) on <a href="/pdf/compress">Compress PDF</a>. Topic: <strong>{topic}</strong>. Pillar: <a href="/guides/compress-pdf-guide">compress PDF guide</a>.</p>
            <h2>Step-by-step</h2>
            <ol>{step_html}</ol>
            <h2>Compression levels</h2>
            <ul>
            <li><strong>Less</strong> — fine print, stamps, legal exhibits</li>
            <li><strong>Recommended</strong> — default for portals and email</li>
            <li><strong>Extreme</strong> — last resort; verify readability</li>
            </ul>
            <h2>Related</h2>
            <ul>
            <li><a href="/guides/compress-pdf-for-email">Email hub</a></li>
            <li><a href="/research/attachment-size-limits">Size limits</a></li>
            {extra_links}
            </ul>
            <p><a href="/pdf/compress">Compress PDF free</a></p>"""


def invoice_country_body(slug: str, meta: dict, steps: list[str], links: list[str]) -> str:
    country = slug.replace("invoice-generator-", "").replace("invoice-for-", "").replace("-", " ").title()
    step_html = "".join(f"<li>{s}</li>" for s in steps) or (
        f"<li>Open <a href=\"/invoice/create\">Create Invoice</a>.</li>"
        f"<li>Fill {country} business and client details.</li>"
        f"<li>Add line items and tax; download PDF.</li>"
    )
    return f"""
            <h2>PDF invoices for {country}</h2>
            <p>{meta['desc']}</p>
            <p><a href="/invoice/create">Create Invoice</a> · Hub: <a href="/guides/invoice-generator-guide">invoice generator guide</a>.</p>
            <h2>Step-by-step</h2>
            <ol>{step_html}</ol>
            <h2>Related</h2>
            <ul>
            <li><a href="/guides/invoice-generator-india">India</a> · <a href="/guides/invoice-generator-usa">USA</a> · <a href="/guides/invoice-generator-uk">UK</a></li>
            <li><a href="/guides/invoice-for-freelancers">Freelancers</a></li>
            </ul>
            <p><a href="/invoice/create">Create invoice →</a></p>"""


def ocr_lang_body(slug: str, meta: dict, steps: list[str], links: list[str]) -> str:
    lang = slug.replace("ocr-pdf-", "").replace("-", " ").title()
    step_html = "".join(f"<li>{s}</li>" for s in steps) or (
        "<li>Scan at 300 DPI.</li><li><a href=\"/pdf/ocrpdf\">OCR PDF</a>.</li>"
        "<li>Verify search; export via <a href=\"/guides/pdf-to-text\">PDF to Text</a>.</li>"
    )
    return f"""
            <h2>OCR {lang} PDFs</h2>
            <p>{meta['desc']}</p>
            <p><a href="/pdf/ocrpdf">OCR PDF</a> · <a href="/guides/ocr-pdf">OCR hub</a> · <a href="/guides/ocr-vs-pdf-to-text">OCR vs PDF to Text</a>.</p>
            <h2>Step-by-step</h2>
            <ol>{step_html}</ol>
            <p><a href="/pdf/ocrpdf">OCR PDF free</a></p>"""


def merge_body(slug: str, meta: dict, steps: list[str], links: list[str]) -> str:
    step_html = "".join(f"<li>{s}</li>" for s in steps) or (
        "<li>Order files; upload to <a href=\"/pdf/merge\">Merge PDF</a>.</li>"
        "<li>Verify page count; compress if needed.</li>"
    )
    return f"""
            <h2>{meta['title']}</h2>
            <p>{meta['desc']}</p>
            <p><a href="/pdf/merge">Merge PDF</a> · <a href="/guides/merge-pdf">merge guide</a>.</p>
            <h2>Step-by-step</h2>
            <ol>{step_html}</ol>
            <p><a href="/pdf/merge">Merge PDF free</a></p>"""


def pdf_to_word_body(slug: str, meta: dict, steps: list[str], links: list[str]) -> str:
    step_html = "".join(f"<li>{s}</li>" for s in steps) or (
        "<li>OCR scans if needed.</li><li><a href=\"/pdf/pdftodoc\">PDF to Word</a>.</li><li>Verify tables in DOCX.</li>"
    )
    return f"""
            <h2>{meta['title']}</h2>
            <p>{meta['desc']}</p>
            <p><a href="/pdf/pdftodoc">PDF to Word</a> · <a href="/guides/pdf-to-word">conversion guide</a>.</p>
            <h2>Step-by-step</h2>
            <ol>{step_html}</ol>"""


def compliance_body(slug: str, meta: dict, steps: list[str], links: list[str]) -> str:
    step_html = "".join(f"<li>{s}</li>" for s in steps) or (
        "<li>Review mandatory fields for your jurisdiction.</li>"
        "<li>Create PDF on <a href=\"/invoice/create\">Create Invoice</a>.</li>"
        "<li>Archive and validate before sending.</li>"
    )
    return f"""
            <h2>{meta['title']}</h2>
            <p>{meta['desc']}</p>
            <p>Confirm requirements with your accountant. Tool: <a href="/invoice/create">Create Invoice</a> · Hub: <a href="/guides/invoice-generator-guide">invoice generator guide</a>.</p>
            <h2>Checklist</h2>
            <ol>{step_html}</ol>
            <h2>Related</h2>
            <ul>
            <li><a href="/guides/gst-invoice-format-india">GST format India</a></li>
            <li><a href="/guides/vat-invoice-eu-requirements">EU VAT</a></li>
            <li><a href="/guides/hmrc-invoice-requirements">HMRC UK</a></li>
            </ul>"""


def general_body(slug: str, meta: dict, steps: list[str], links: list[str]) -> str:
    tl = tool_link(meta.get("tool"))
    step_html = "".join(f"<li>{s}</li>" for s in steps) or f"<li>Use {tl} per on-screen steps.</li><li>Verify output; archive original.</li>"
    extra = "".join(f'<li><a href="{l}">{l}</a></li>' for l in links[:5])
    return f"""
            <h2>{meta['title']}</h2>
            <p>{meta['desc']}</p>
            <p>Practical RatPDF workflow using {tl}. See <a href="/guides/pdf-tools">PDF tools</a> · <a href="/compare">compare</a>.</p>
            <h2>Step-by-step</h2>
            <ol>{step_html}</ol>
            <h2>Related</h2>
            <ul>{extra}</ul>"""


def generate_body(slug: str, meta: dict, steps: list[str], links: list[str]) -> str:
    c = cluster_for(slug)
    if c == "glossary":
        return glossary_body(slug, meta)
    if c == "compress":
        return compress_body(slug, meta, steps, links)
    if c == "invoice_country":
        return invoice_country_body(slug, meta, steps, links)
    if c == "ocr_lang":
        return ocr_lang_body(slug, meta, steps, links)
    if c == "merge":
        return merge_body(slug, meta, steps, links)
    if c == "pdf_to_word":
        return pdf_to_word_body(slug, meta, steps, links)
    if c == "compliance":
        return compliance_body(slug, meta, steps, links)
    return general_body(slug, meta, steps, links)


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
    # Only skip slugs with hand-written GUIDE bodies (not blog-only bodies)
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
