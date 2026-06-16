#!/usr/bin/env python3
"""Generate GuideBodiesWave15.cs — Regional workflows batch 1 (17 pages, 1500+ words)."""
from pathlib import Path

from wave1_expansions import PDF_CLUSTER_PREMIUM, PDF_FINAL_BOOST, PDF_PAGE_PREMIUM
from wave3_expansions import (
    COMPRESS_CLUSTER_LINKS,
    COMPRESS_FINAL_BOOST,
    COMPRESS_MEGA,
    COMPRESS_UNIVERSAL,
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
from wave15_expansions import (
    PILLAR_SLUGS,
    W15_1500_TOPUP,
    W15_CLUSTER,
    W15_CLOSING,
    W15_DATA,
    W15_DEEP,
    W15_MEGA,
    W15_SLUG_EXTRA,
    W15_SLUGS,
)

OUT = Path(__file__).resolve().parents[1] / "Content" / "GuideBodiesWave15.cs"


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
            <p>Regional portals punish wrong file size more often than wrong font — compress and merge discipline saves deadline panic.</p>
            {shot(focus)}
            <h2>Compliance note</h2>
            <p>Never alter amounts, dates, or MRZ data in compress — if illegible after compress, re-export from source bank or portal.</p>
            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Open tool</strong> <a href="{tool}" class="alert-link fw-semibold">Go →</a></div>
            """


def body(slug: str) -> str:
    d = W15_DATA[slug]
    pillar_note = (
        '<p>Hub: <a href="/guides/pdf-regional-workflows-hub">Regional workflows hub</a> · '
        '<a href="/guides/compress-pdf-for-visa-application">Visa compress hub</a>.</p>'
        if slug in PILLAR_SLUGS
        else ""
    )
    return f"""
            <h2>{d['title']}</h2>
            <p>RatPDF <a href="{d['tool']}">{d['label']}</a> — {d['example']}.</p>
            {shot(d['title'])}
            {W15_DEEP[slug]}
            {W15_SLUG_EXTRA[slug]}
            {mid_cta(d['tool'], d['label'], 'Start workflow')}
            {W15_MEGA}
            {COMPRESS_MEGA}
            {COMPRESS_UNIVERSAL}
            {COMPLIANCE_MEGA}
            {COMPLIANCE_UNIVERSAL}
            {cluster_long(d['tool'], d['title'])}
            {pillar_note}
            {SHARED_MEGA}
            {SHARED_PILLAR}
            {W6_SHARED_MEGA}
            {W6_1500}
            {W6_1500_EXTENDED}
            {W15_1500_TOPUP}
            {W6_LINE_COUNT_FIX}
            {COMPRESS_CLUSTER_LINKS}
            {COMPLIANCE_CLUSTER_LINKS}
            {W15_CLUSTER}
            {COMPRESS_FINAL_BOOST}
            {COMPLIANCE_FINAL_BOOST}
            {PDF_CLUSTER_PREMIUM}
            {PDF_PAGE_PREMIUM}
            {PDF_FINAL_BOOST}
            {W5_1500_TOPUP}
            {W15_CLOSING}
            {W6_CLOSING}
            {W5_CLOSING}
            {end_cta(d['tool'], d['label'], '<a href="/guides/pdf-regional-workflows-hub">Regional hub</a>')}
            """


def main():
    lines = [
        "namespace ratpdf.Content",
        "{",
        "    /// <summary>Wave 15 — Regional PDF workflows (visa, bank, India portals) batch 1.</summary>",
        "    internal static class GuideBodiesWave15",
        "    {",
        "        public static string? Get(string slug) => slug switch",
        "        {",
    ]
    for slug in W15_SLUGS:
        lines.append(f'            "{slug}" => {const_name(slug)},')
    lines.append("            _ => null")
    lines.append("        };")
    lines.append("")

    for slug in W15_SLUGS:
        content = body(slug).lstrip("\n").rstrip()
        lines += [f"        private const string {const_name(slug)} = \"\"\"", content, "            \"\"\";", ""]

    lines += ["    }", "}"]
    OUT.write_text("\n".join(lines) + "\n", encoding="utf-8")
    print(f"Wrote {OUT} ({len(W15_SLUGS)} guides)")


if __name__ == "__main__":
    main()
