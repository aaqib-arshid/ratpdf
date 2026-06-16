#!/usr/bin/env python3
"""Generate GuideBodiesWave26.cs — Industry pdf-workflow + pdf-to-text platform batch 1."""
from pathlib import Path

from wave1_expansions import PDF_CLUSTER_PREMIUM, PDF_FINAL_BOOST, PDF_PAGE_PREMIUM
from wave3_expansions import (
    COMPRESS_CLUSTER_LINKS,
    COMPRESS_FINAL_BOOST,
    COMPRESS_LONG_TAIL,
    COMPRESS_MEGA,
    COMPLIANCE_CLUSTER_LINKS,
    COMPLIANCE_FINAL_BOOST,
    COMPLIANCE_MEGA,
    COMPLIANCE_UNIVERSAL,
)
from wave4_expansions import PDF_WORD_MEGA
from wave5_expansions import W5_1500_TOPUP, W5_CLOSING
from wave6_expansions import (
    COMPARE_MEGA,
    COMPARE_SMB,
    CONVERT_MEGA,
    SHARED_MEGA,
    W6_1500,
    W6_1500_EXTENDED,
    W6_CLOSING,
    W6_LINE_COUNT_FIX,
    W6_SHARED_MEGA,
)
from wave7_expansions import SHARED_PILLAR
from wave12_expansions import W12_1500_TOPUP, W12_CLUSTER, W12_MEGA
from wave16_expansions import W16_1500_TOPUP, W16_CLOSING, W16_MEGA
from wave19_expansions import W19_INDUSTRY_CLUSTER
from wave22_expansions import W22_INDUSTRY_CLUSTER
from wave24_expansions import W24_TEXT_CLUSTER
from wave26_expansions import (
    TEXT_PLATFORM_SLUGS,
    W26_CLOSING,
    W26_DATA,
    W26_DEEP,
    W26_SLUGS,
    W26_TEXT_CLUSTER,
    W26_WORKFLOW_CLUSTER,
    W26_WORKFLOW_TOPUP,
    WORKFLOW_SLUGS,
)

OUT = Path(__file__).resolve().parents[1] / "Content" / "GuideBodiesWave26.cs"


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


def body(slug: str) -> str:
    d = W26_DATA[slug]
    lead = (
        f'<p class="lead">Pillar: <a href="{d["pillar"]}">{d["pillar_label"]}</a> · '
        f'Related: <a href="{d["related"]}">{d["related"]}</a>.</p>'
    )

    if slug in WORKFLOW_SLUGS:
        cluster = W26_WORKFLOW_CLUSTER + W22_INDUSTRY_CLUSTER + W19_INDUSTRY_CLUSTER
        mega = COMPARE_MEGA + COMPARE_SMB + COMPRESS_MEGA + SHARED_MEGA
        topup = W26_WORKFLOW_TOPUP
        closing = W26_CLOSING
    else:
        cluster = W26_TEXT_CLUSTER + W24_TEXT_CLUSTER + COMPLIANCE_CLUSTER_LINKS
        mega = CONVERT_MEGA + PDF_WORD_MEGA + COMPRESS_MEGA
        topup = W16_1500_TOPUP
        closing = W6_CLOSING

    return f"""
            <h2>{d['title']}</h2>
            <p>Example: {d['example']}.</p>
            {lead}
            {shot(d['title'])}
            {W26_DEEP[slug]}
            {mid_cta(d['tool'], d['label'], 'Open workflow hub')}
            {mega}
            {COMPLIANCE_UNIVERSAL}
            {SHARED_PILLAR}
            {W6_SHARED_MEGA}
            {W6_1500}
            {W6_1500_EXTENDED}
            {W12_MEGA}
            {topup}
            {W12_1500_TOPUP}
            {W6_LINE_COUNT_FIX}
            {cluster}
            {W12_CLUSTER}
            {COMPRESS_FINAL_BOOST}
            {COMPLIANCE_FINAL_BOOST}
            {PDF_CLUSTER_PREMIUM}
            {PDF_PAGE_PREMIUM}
            {PDF_FINAL_BOOST}
            {W5_1500_TOPUP}
            {closing}
            {W6_CLOSING}
            {W5_CLOSING}
            {end_cta(d['tool'], d['label'], f'<a href="{d["pillar"]}">Full guide</a>')}
            """


def main() -> None:
    lines = [
        "namespace ratpdf.Content",
        "{",
        "    /// <summary>Wave 26 — Industry pdf-workflow hubs + pdf-to-text platform batch 1.</summary>",
        "    internal static class GuideBodiesWave26",
        "    {",
        "        public static string? Get(string slug) => slug switch",
        "        {",
    ]
    for slug in W26_SLUGS:
        lines.append(f'            "{slug}" => {const_name(slug)},')
    lines.append("            _ => null")
    lines.append("        };")
    lines.append("")

    for slug in W26_SLUGS:
        content = body(slug).lstrip("\n").rstrip()
        lines += [f"        private const string {const_name(slug)} = \"\"\"", content, "            \"\"\";", ""]

    lines += ["    }", "}"]
    OUT.write_text("\n".join(lines) + "\n", encoding="utf-8")
    print(f"Wrote {OUT} ({len(W26_SLUGS)} guides)")


if __name__ == "__main__":
    main()
