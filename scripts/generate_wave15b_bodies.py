#!/usr/bin/env python3
"""Generate GuideBodiesWave15B.cs — Regional workflows batch 2 (17 pages)."""
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
from wave15_expansions import W15_1500_TOPUP, W15_MEGA
from wave15b_expansions import (
    W15B_CLUSTER,
    W15B_CLOSING,
    W15B_DATA,
    W15B_DEEP,
    W15B_SLUG_EXTRA,
    W15B_SLUGS,
)

OUT = Path(__file__).resolve().parents[1] / "Content" / "GuideBodiesWave15B.cs"


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
            <p>Embassy portals change caps without notice — compress copy, keep lossless original until visa decision.</p>
            {shot(focus)}
            <h2>Schengen note</h2>
            <p>Germany, France, Spain, Netherlands share Schengen compress patterns — UK and Ireland are separate systems.</p>
            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Open tool</strong> <a href="{tool}" class="alert-link fw-semibold">Go →</a></div>
            """


def body(slug: str) -> str:
    d = W15B_DATA[slug]
    return f"""
            <h2>{d['title']}</h2>
            <p>RatPDF <a href="{d['tool']}">{d['label']}</a> — {d['example']}.</p>
            {shot(d['title'])}
            {W15B_DEEP[slug]}
            {W15B_SLUG_EXTRA[slug]}
            {mid_cta(d['tool'], d['label'], 'Start workflow')}
            {W15_MEGA}
            {COMPRESS_MEGA}
            {COMPRESS_UNIVERSAL}
            {COMPLIANCE_MEGA}
            {COMPLIANCE_UNIVERSAL}
            {cluster_long(d['tool'], d['title'])}
            {SHARED_MEGA}
            {SHARED_PILLAR}
            {W6_SHARED_MEGA}
            {W6_1500}
            {W6_1500_EXTENDED}
            {W15_1500_TOPUP}
            {W6_LINE_COUNT_FIX}
            {COMPRESS_CLUSTER_LINKS}
            {COMPLIANCE_CLUSTER_LINKS}
            {W15B_CLUSTER}
            {COMPRESS_FINAL_BOOST}
            {COMPLIANCE_FINAL_BOOST}
            {PDF_CLUSTER_PREMIUM}
            {PDF_PAGE_PREMIUM}
            {PDF_FINAL_BOOST}
            {W5_1500_TOPUP}
            {W15B_CLOSING}
            {W6_CLOSING}
            {W5_CLOSING}
            {end_cta(d['tool'], d['label'], '<a href="/guides/pdf-regional-workflows-hub">Regional hub</a>')}
            """


def main():
    lines = [
        "namespace ratpdf.Content",
        "{",
        "    /// <summary>Wave 15 batch 2 — Regional PDF workflows (Schengen, Gulf, Asia-Pacific).</summary>",
        "    internal static class GuideBodiesWave15B",
        "    {",
        "        public static string? Get(string slug) => slug switch",
        "        {",
    ]
    for slug in W15B_SLUGS:
        lines.append(f'            "{slug}" => {const_name(slug)},')
    lines.append("            _ => null")
    lines.append("        };")
    lines.append("")

    for slug in W15B_SLUGS:
        content = body(slug).lstrip("\n").rstrip()
        lines += [f"        private const string {const_name(slug)} = \"\"\"", content, "            \"\"\";", ""]

    lines += ["    }", "}"]
    OUT.write_text("\n".join(lines) + "\n", encoding="utf-8")
    print(f"Wrote {OUT} ({len(W15B_SLUGS)} guides)")


if __name__ == "__main__":
    main()
