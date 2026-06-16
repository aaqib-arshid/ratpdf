#!/usr/bin/env python3
"""Generate GuideBodiesWave10.cs — Conversion depth cluster (17 pages, 1500+ words)."""
from pathlib import Path

from wave1_expansions import PDF_CLUSTER_PREMIUM, PDF_FINAL_BOOST, PDF_PAGE_PREMIUM
from wave4_expansions import PDF_WORD_CLUSTER_LINKS, PDF_WORD_LONG_TAIL, PDF_WORD_MEGA
from wave5_expansions import W5_1500_TOPUP, W5_CLOSING
from wave6_expansions import (
    CONVERT_1500_TOPUP,
    CONVERT_CLUSTER,
    CONVERT_MEGA,
    CONVERT_UNIVERSAL,
    SHARED_MEGA,
    W6_1500,
    W6_1500_EXTENDED,
    W6_CLOSING,
    W6_LINE_COUNT_FIX,
    W6_SHARED_MEGA,
)
from wave7_expansions import SHARED_PILLAR
from wave10_expansions import (
    PILLAR_SLUGS,
    W10_1500_TOPUP,
    W10_CLUSTER,
    W10_CLOSING,
    W10_DATA,
    W10_DEEP,
    W10_MEGA,
    W10_PILLAR_TOPUP,
    W10_SLUG_EXTRA,
    W10_SLUGS,
)

OUT = Path(__file__).resolve().parents[1] / "Content" / "GuideBodiesWave10.cs"


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


def cluster_long(tool: str, focus: str) -> str:
    return f"""
            <h2>Workflow deep dive — {focus}</h2>
            <p>Upload → convert → download → verify sample rows or pages before production batch.</p>
            {shot(focus)}
            <h2>Mobile</h2>
            <p>Phone works for small PDFs — Wi-Fi for large spreadsheets and multi-page exports.</p>
            <h2>Failures</h2>
            <p>Timeout: smaller file or Wi-Fi · scan tables: OCR first · HTML: inline CSS.</p>
            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Convert</strong> <a href="{tool}" class="alert-link fw-semibold">Go →</a></div>
            """


def excel_extra(slug: str) -> str:
    if "excel" not in slug and "tables" not in slug:
        return ""
    return PDF_WORD_LONG_TAIL + PDF_WORD_MEGA


def body(slug: str) -> str:
    d = W10_DATA[slug]
    pillar_extra = W10_PILLAR_TOPUP if slug in PILLAR_SLUGS else ""
    return f"""
            <h2>{d['title']}</h2>
            <p>RatPDF <a href="{d['tool']}">{d['label']}</a> — {d['example']}.</p>
            {shot(d['title'])}
            {W10_DEEP[slug]}
            {W10_SLUG_EXTRA[slug]}
            {mid_cta(d['tool'], d['label'], 'Convert now')}
            {CONVERT_MEGA}
            {CONVERT_UNIVERSAL}
            {W10_MEGA}
            {cluster_long(d['tool'], d['title'])}
            {excel_extra(slug)}
            {pillar_extra}
            {SHARED_MEGA}
            {SHARED_PILLAR}
            {W6_SHARED_MEGA}
            {W6_1500}
            {W6_1500_EXTENDED}
            {CONVERT_1500_TOPUP}
            {W10_1500_TOPUP}
            {W6_LINE_COUNT_FIX}
            {CONVERT_CLUSTER}
            {W10_CLUSTER}
            {PDF_CLUSTER_PREMIUM}
            {PDF_PAGE_PREMIUM}
            {PDF_FINAL_BOOST}
            {PDF_WORD_CLUSTER_LINKS}
            {W5_1500_TOPUP}
            {W10_CLOSING}
            {W6_CLOSING}
            {W5_CLOSING}
            {end_cta(d['tool'], d['label'], '<a href="/guides/pdf-conversion-guide">Conversion hub</a>')}
            """


def main():
    lines = [
        "namespace ratpdf.Content",
        "{",
        "    /// <summary>Wave 10 — Conversion depth (excel, html, markdown, jpg/png).</summary>",
        "    internal static class GuideBodiesWave10",
        "    {",
        "        public static string? Get(string slug) => slug switch",
        "        {",
    ]
    for slug in W10_SLUGS:
        lines.append(f'            "{slug}" => {const_name(slug)},')
    lines.append("            _ => null")
    lines.append("        };")
    lines.append("")

    for slug in W10_SLUGS:
        content = body(slug).lstrip("\n").rstrip()
        lines += [f"        private const string {const_name(slug)} = \"\"\"", content, "            \"\"\";", ""]

    lines += ["    }", "}"]
    OUT.write_text("\n".join(lines) + "\n", encoding="utf-8")
    print(f"Wrote {OUT} ({len(W10_SLUGS)} guides)")


if __name__ == "__main__":
    main()
