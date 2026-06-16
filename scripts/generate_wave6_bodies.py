#!/usr/bin/env python3
"""Generate GuideBodiesWave6.cs — Convert, Edit, Word spokes, SMB compare."""
from pathlib import Path

from wave1_expansions import PDF_CLUSTER_PREMIUM, PDF_FINAL_BOOST, PDF_PAGE_PREMIUM
from wave4_expansions import PDF_WORD_CLUSTER_LINKS, PDF_WORD_LONG_TAIL, PDF_WORD_MEGA
from wave5_expansions import (
    SPLIT_1500_TOPUP,
    SPLIT_FINAL,
    SPLIT_SLUG_EXTRA,
    SPLIT_W5_DEEP,
    SPLIT_W5_MEGA,
    SPLIT_UNIVERSAL,
    W5_1500_TOPUP,
)
from wave6_expansions import (
    COMPARE_1500_FINAL,
    COMPARE_DEEP,
    COMPARE_FINAL,
    COMPARE_MEGA,
    COMPARE_SMB,
    CONVERT_1500_TOPUP,
    CONVERT_CLUSTER,
    CONVERT_DATA,
    CONVERT_DEEP,
    CONVERT_FINAL,
    CONVERT_MEGA,
    CONVERT_SLUG_EXTRA,
    CONVERT_UNIVERSAL,
    EDIT_CLUSTER,
    EDIT_DATA,
    EDIT_DEEP,
    EDIT_FINAL,
    EDIT_MEGA,
    EDIT_1500_FINAL,
    EDIT_1500_TOPUP,
    EDIT_SLUG_EXTRA,
    EDIT_UNIVERSAL,
    SHARED_MEGA,
    W6_1500,
    W6_1500_EXTENDED,
    W6_CLOSING,
    W6_LINE_COUNT_FIX,
    W6_SHARED_MEGA,
    WORD_SLUG_EXTRA,
    WORD_W6_DATA,
    WORD_W6_DEEP,
    WORD_W6_MEGA,
    WORD_W6_TOPUP,
)

OUT = Path(__file__).resolve().parents[1] / "Content" / "GuideBodiesWave6.cs"

CONVERT_SLUGS = list(CONVERT_DATA.keys())
EDIT_SLUGS = list(EDIT_DATA.keys())
WORD_SLUGS = list(WORD_W6_DATA.keys())
COMPARE_SLUGS = ["pdf-tools-small-business"]
SLUGS = CONVERT_SLUGS + EDIT_SLUGS + WORD_SLUGS + COMPARE_SLUGS


def const_name(slug: str) -> str:
    return slug.replace("-", "_").title().replace("_", "")


def shot(caption: str) -> str:
    return (
        f'<figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small">'
        f'<figcaption><strong>Screenshot placeholder:</strong> {caption}</figcaption></figure>'
    )


def mid_cta(tool: str, label: str, text: str) -> str:
    return (
        f'<div class="rp-mid-cta alert alert-primary my-4"><strong>{text}</strong> '
        f'<a href="{tool}" class="alert-link fw-semibold">{label} →</a></div>'
    )


def end_cta(tool: str, label: str, extra: str = "") -> str:
    extra_html = f" · {extra}" if extra else ""
    return f'<p class="mt-4"><a href="{tool}" class="btn btn-primary">{label}</a>{extra_html}</p>'


def pdf_long_tail(focus: str) -> str:
    return f"""
            <h2>PDF to Word pipeline — {focus}</h2>
            <p>Digital PDF: text selects → <a href="/pdf/pdftodoc">PDF to Word</a>. Scan: <a href="/pdf/ocrpdf">OCR</a> first. Layout-critical: <a href="/guides/pdf-to-word-keep-formatting">keep formatting</a>.</p>
            {shot("PDF to Word conversion workflow")}
            <h2>Re-export and compress</h2>
            <p><a href="/pdf/doctopdf">Word to PDF</a> after edits · <a href="/guides/compress-pdf-for-email">compress</a> if email rejects.</p>
            <h2>Security</h2>
            <p>Clear Downloads on shared PC — contract DOCX is confidential.</p>
            <h2>Alternatives</h2>
            <p><a href="/compare/smallpdf-alternative">Smallpdf</a> · <a href="/compare/adobe-alternative">Adobe</a>.</p>
            <h2>Cluster links</h2>
            <p><a href="/guides/convert-contract-pdf-to-word">contract</a> · <a href="/guides/pdf-to-word-invoice">invoice</a> · <a href="/guides/pdf-to-word">main guide</a>.</p>
            """


def cluster_long(tool: str, focus: str) -> str:
    return f"""
            <h2>Workflow deep dive — {focus}</h2>
            <p>Browser workflow — no install — upload → process → download → verify in viewer before external send.</p>
            {shot(focus)}
            <h2>Mobile</h2>
            <p>Safari/Chrome on phone works — Wi-Fi for files over 15 MB — save to Files before portal upload.</p>
            <h2>Failures</h2>
            <p>Timeout: retry Wi-Fi · corrupt PDF: re-export source · password: <a href="/guides/unlock-pdf">unlock</a>.</p>
            <h2>Free tier</h2>
            <p>Three uses/day — <a href="/Subscription/Plans">plans</a> for volume.</p>
            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Open tool</strong> <a href="{tool}" class="alert-link fw-semibold">Go →</a></div>
            """


def body_convert(slug: str) -> str:
    d = CONVERT_DATA[slug]
    return f"""
            <h2>{d['title']}</h2>
            <p>RatPDF <a href="{d['tool']}">{d['label']}</a> in browser — no Adobe. {d['example']}.</p>
            {shot(d['title'])}
            {CONVERT_DEEP[slug]}
            {CONVERT_SLUG_EXTRA[slug]}
            {mid_cta(d['tool'], d['label'], 'Convert now')}
            {CONVERT_MEGA}
            {CONVERT_UNIVERSAL}
            {cluster_long(d['tool'], d['label'])}
            {CONVERT_FINAL}
            {SHARED_MEGA}
            {W6_SHARED_MEGA}
            {W6_1500}
            {W6_1500_EXTENDED}
            {CONVERT_1500_TOPUP}
            {W6_LINE_COUNT_FIX}
            {CONVERT_CLUSTER}
            {W6_CLOSING}
            {end_cta(d['tool'], d['label'], '<a href="/compare/adobe-alternative">Adobe alternative</a>')}
            """


def body_edit(slug: str) -> str:
    d = EDIT_DATA[slug]
    split_extra = ""
    if slug in ("split-pdf-page-range", "extract-single-page-pdf"):
        split_extra = (
            SPLIT_W5_MEGA + SPLIT_UNIVERSAL + SPLIT_W5_DEEP
            + SPLIT_1500_TOPUP + SPLIT_FINAL + SPLIT_SLUG_EXTRA.get(slug, "")
            + W5_1500_TOPUP
        )
    return f"""
            <h2>{d['title']}</h2>
            <p>RatPDF <a href="{d['tool']}">{d['label']}</a> — {d['example']}.</p>
            {shot(d['title'])}
            {EDIT_DEEP[slug]}
            {EDIT_SLUG_EXTRA[slug]}
            {mid_cta(d['tool'], d['label'], 'Start editing')}
            {EDIT_MEGA}
            {EDIT_UNIVERSAL}
            {cluster_long(d['tool'], d['title'])}
            {split_extra}
            {EDIT_FINAL}
            {SHARED_MEGA}
            {W6_SHARED_MEGA}
            {W6_1500}
            {W6_1500_EXTENDED}
            {EDIT_1500_TOPUP}
            {W6_LINE_COUNT_FIX}
            {EDIT_1500_FINAL}
            {EDIT_CLUSTER}
            {W6_CLOSING}
            {end_cta(d['tool'], d['label'], '<a href="/guides/ocr-pdf">OCR guide</a>')}
            """


def body_word(slug: str) -> str:
    d = WORD_W6_DATA[slug]
    tool = "/pdf/doctopdf" if slug == "word-to-pdf-without-adobe" else "/pdf/pdftodoc"
    label = "Word to PDF" if slug == "word-to-pdf-without-adobe" else "PDF to Word"
    return f"""
            <h2>{d['title']}</h2>
            <p>RatPDF <a href="{tool}">{label}</a> for {d['doc']} workflows. {d['example']}.</p>
            {shot(d['title'])}
            <ol>
            <li>Confirm digital vs scan — OCR if needed.</li>
            <li>Upload to {label}.</li>
            <li>{d['tips']}</li>
            <li>Export PDF if deliverable requires PDF.</li>
            </ol>
            {WORD_W6_DEEP[slug]}
            {WORD_SLUG_EXTRA[slug]}
            {mid_cta(tool, label, f'Convert {d["doc"]}')}
            {WORD_W6_MEGA}
            {WORD_W6_TOPUP}
            {PDF_WORD_LONG_TAIL}
            {PDF_WORD_MEGA}
            {pdf_long_tail(d['doc'])}
            {PDF_CLUSTER_PREMIUM}
            {PDF_PAGE_PREMIUM}
            {PDF_FINAL_BOOST}
            {W6_1500}
            {W6_1500_EXTENDED}
            {PDF_WORD_CLUSTER_LINKS}
            {W6_CLOSING}
            {end_cta(tool, label, '<a href="/Subscription/Plans">Upgrade</a>')}
            """


def body_compare() -> str:
    return f"""
            <h2>PDF tools for small business — merge, invoice, sign &amp; compress</h2>
            <p>Buyer guide for agencies and shops comparing browser RatPDF stack vs Adobe Acrobat subscription.</p>
            {shot("SMB PDF tools comparison checklist")}
            {COMPARE_SMB}
            {mid_cta('/compare', 'Compare tools', 'See alternatives hub')}
            {COMPARE_MEGA}
            {COMPARE_DEEP}
            {COMPARE_FINAL}
            {W6_LINE_COUNT_FIX}
            {COMPARE_1500_FINAL}
            {SHARED_MEGA}
            {W6_SHARED_MEGA}
            {W6_1500}
            {W6_1500_EXTENDED}
            {W6_CLOSING}
            {end_cta('/compare', 'Compare PDF tools', '<a href="/invoice/create">Create Invoice</a>')}
            """


def main():
    lines = [
        "namespace ratpdf.Content",
        "{",
        "    /// <summary>Wave 6 — Convert, Edit/Organize, Word spokes, SMB compare (SEO audit).</summary>",
        "    internal static class GuideBodiesWave6",
        "    {",
        "        public static string? Get(string slug) => slug switch",
        "        {",
    ]
    for slug in SLUGS:
        lines.append(f'            "{slug}" => {const_name(slug)},')
    lines.append("            _ => null")
    lines.append("        };")
    lines.append("")

    for slug in CONVERT_SLUGS:
        content = body_convert(slug).lstrip("\n").rstrip()
        lines += [f"        private const string {const_name(slug)} = \"\"\"", content, "            \"\"\";", ""]
    for slug in EDIT_SLUGS:
        content = body_edit(slug).lstrip("\n").rstrip()
        lines += [f"        private const string {const_name(slug)} = \"\"\"", content, "            \"\"\";", ""]
    for slug in WORD_SLUGS:
        content = body_word(slug).lstrip("\n").rstrip()
        lines += [f"        private const string {const_name(slug)} = \"\"\"", content, "            \"\"\";", ""]
    content = body_compare().lstrip("\n").rstrip()
    lines += [f"        private const string PdfToolsSmallBusiness = \"\"\"", content, "            \"\"\";", ""]

    lines += ["    }", "}"]
    OUT.write_text("\n".join(lines) + "\n", encoding="utf-8")
    print(f"Wrote {OUT} ({len(SLUGS)} guides)")


if __name__ == "__main__":
    main()
