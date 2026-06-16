#!/usr/bin/env python3
"""Generate GuideBodiesWave13.cs — Printing workflows cluster (17 pages, 1500+ words)."""
from pathlib import Path

from wave1_expansions import PDF_CLUSTER_PREMIUM, PDF_FINAL_BOOST, PDF_PAGE_PREMIUM
from wave3_expansions import (
    COMPLIANCE_CLUSTER_LINKS,
    COMPLIANCE_FINAL_BOOST,
    COMPLIANCE_MEGA,
    COMPLIANCE_UNIVERSAL,
)
from wave5_expansions import W5_1500_TOPUP, W5_CLOSING
from wave6_expansions import (
    SHARED_MEGA,
    W6_1500,
    W6_1500_EXTENDED,
    W6_CLOSING,
    W6_LINE_COUNT_FIX,
    W6_SHARED_MEGA,
)
from wave7_expansions import SHARED_PILLAR
from wave13_expansions import (
    PILLAR_SLUGS,
    W13_1500_TOPUP,
    W13_CLUSTER,
    W13_CLOSING,
    W13_DATA,
    W13_DEEP,
    W13_MEGA,
    W13_SLUG_EXTRA,
    W13_SLUGS,
)

OUT = Path(__file__).resolve().parents[1] / "Content" / "GuideBodiesWave13.cs"


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
            <p>Print reliability starts at export — driver settings fix symptoms but source PDF structure prevents recurrence.</p>
            {shot(focus)}
            <h2>Verification</h2>
            <p>Always print one test page before 500-copy run — check footnotes, color bars, and form field values.</p>
            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Open tool</strong> <a href="{tool}" class="alert-link fw-semibold">Go →</a></div>
            """


def body(slug: str) -> str:
    d = W13_DATA[slug]
    pillar_note = (
        '<p>Hub: <a href="/guides/pdf-printing-guide">PDF printing guide</a> · '
        '<a href="/guides/pdf-troubleshooting">Troubleshooting hub</a>.</p>'
        if slug in PILLAR_SLUGS
        else ""
    )
    return f"""
            <h2>{d['title']}</h2>
            <p>RatPDF <a href="{d['tool']}">{d['label']}</a> — {d['example']}.</p>
            {shot(d['title'])}
            {W13_DEEP[slug]}
            {W13_SLUG_EXTRA[slug]}
            {mid_cta(d['tool'], d['label'], 'Start workflow')}
            {W13_MEGA}
            {COMPLIANCE_MEGA}
            {COMPLIANCE_UNIVERSAL}
            {cluster_long(d['tool'], d['title'])}
            {pillar_note}
            {SHARED_MEGA}
            {SHARED_PILLAR}
            {W6_SHARED_MEGA}
            {W6_1500}
            {W6_1500_EXTENDED}
            {W13_1500_TOPUP}
            {W6_LINE_COUNT_FIX}
            {COMPLIANCE_CLUSTER_LINKS}
            {W13_CLUSTER}
            {COMPLIANCE_FINAL_BOOST}
            {PDF_CLUSTER_PREMIUM}
            {PDF_PAGE_PREMIUM}
            {PDF_FINAL_BOOST}
            {W5_1500_TOPUP}
            {W13_CLOSING}
            {W6_CLOSING}
            {W5_CLOSING}
            {end_cta(d['tool'], d['label'], '<a href="/guides/pdf-printing-guide">Printing hub</a>')}
            """


def main():
    lines = [
        "namespace ratpdf.Content",
        "{",
        "    /// <summary>Wave 13 — Printing workflows (device, quality, flatten, commercial prep).</summary>",
        "    internal static class GuideBodiesWave13",
        "    {",
        "        public static string? Get(string slug) => slug switch",
        "        {",
    ]
    for slug in W13_SLUGS:
        lines.append(f'            "{slug}" => {const_name(slug)},')
    lines.append("            _ => null")
    lines.append("        };")
    lines.append("")

    for slug in W13_SLUGS:
        content = body(slug).lstrip("\n").rstrip()
        lines += [f"        private const string {const_name(slug)} = \"\"\"", content, "            \"\"\";", ""]

    lines += ["    }", "}"]
    OUT.write_text("\n".join(lines) + "\n", encoding="utf-8")
    print(f"Wrote {OUT} ({len(W13_SLUGS)} guides)")


if __name__ == "__main__":
    main()
