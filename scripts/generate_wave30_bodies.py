#!/usr/bin/env python3
"""Generate GuideBodiesWave30.cs — University batch 2 + compress technical batch."""
from pathlib import Path

from wave1_expansions import PDF_CLUSTER_PREMIUM, PDF_FINAL_BOOST, PDF_PAGE_PREMIUM
from wave3_expansions import (
    COMPRESS_CLUSTER_LINKS,
    COMPRESS_FINAL_BOOST,
    COMPRESS_LONG_TAIL,
    COMPRESS_MEGA,
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
from wave12_expansions import W12_1500_TOPUP, W12_CLUSTER, W12_MEGA
from wave21_expansions import W21_REGIONAL_CLUSTER
from wave29_expansions import W29_UNI_CLUSTER
from wave30_expansions import (
    COMPRESS_TECH_SLUGS,
    UNIVERSITY_SLUGS,
    W30_CLOSING,
    W30_COMPRESS_CLUSTER,
    W30_COMPRESS_TOPUP,
    W30_DATA,
    W30_DEEP,
    W30_SLUGS,
    W30_UNI_CLUSTER,
    W30_UNI_TOPUP,
)

OUT = Path(__file__).resolve().parents[1] / "Content" / "GuideBodiesWave30.cs"


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
    d = W30_DATA[slug]
    lead = (
        f'<p class="lead">Pillar: <a href="{d["pillar"]}">{d["pillar_label"]}</a> · '
        f'Related: <a href="{d["related"]}">{d["related"]}</a>.</p>'
    )

    if slug in UNIVERSITY_SLUGS:
        cluster = W30_UNI_CLUSTER + W29_UNI_CLUSTER + W21_REGIONAL_CLUSTER
        mega = SHARED_MEGA + COMPRESS_MEGA
        topup = W30_UNI_TOPUP
    else:
        cluster = W30_COMPRESS_CLUSTER + COMPRESS_CLUSTER_LINKS
        mega = COMPRESS_MEGA + COMPRESS_LONG_TAIL + COMPLIANCE_MEGA
        topup = W30_COMPRESS_TOPUP

    return f"""
            <h2>{d['title']}</h2>
            <p>Example: {d['example']}.</p>
            {lead}
            {shot(d['title'])}
            {W30_DEEP[slug]}
            {mid_cta(d['tool'], d['label'], 'Start workflow')}
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
            {W30_CLOSING}
            {W6_CLOSING}
            {W5_CLOSING}
            {end_cta(d['tool'], d['label'], f'<a href="{d["pillar"]}">Full guide</a>')}
            """


def main() -> None:
    lines = [
        "namespace ratpdf.Content",
        "{",
        "    /// <summary>Wave 30 — University application batch 2 + compress technical batch.</summary>",
        "    internal static class GuideBodiesWave30",
        "    {",
        "        public static string? Get(string slug) => slug switch",
        "        {",
    ]
    for slug in W30_SLUGS:
        lines.append(f'            "{slug}" => {const_name(slug)},')
    lines.append("            _ => null")
    lines.append("        };")
    lines.append("")

    for slug in W30_SLUGS:
        content = body(slug).lstrip("\n").rstrip()
        lines += [f"        private const string {const_name(slug)} = \"\"\"", content, "            \"\"\";", ""]

    lines += ["    }", "}"]
    OUT.write_text("\n".join(lines) + "\n", encoding="utf-8")
    print(f"Wrote {OUT} ({len(W30_SLUGS)} guides)")


if __name__ == "__main__":
    main()
