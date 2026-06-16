#!/usr/bin/env python3
"""Generate GuideBodiesWave21.cs — Regional bank/contract + India + without-Adobe + accountants."""
from pathlib import Path

from wave1_expansions import PDF_CLUSTER_PREMIUM, PDF_FINAL_BOOST, PDF_PAGE_PREMIUM
from wave3_expansions import (
    COMPRESS_CLUSTER_LINKS,
    COMPRESS_FINAL_BOOST,
    COMPRESS_LONG_TAIL,
    COMPRESS_MEGA,
    COMPRESS_UNIVERSAL,
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
    CONVERT_CLUSTER,
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
from wave15_expansions import W15_1500_TOPUP, W15_MEGA
from wave15b_expansions import W15B_CLOSING, W15B_CLUSTER
from wave16_expansions import W16_1500_TOPUP, W16_CLOSING
from wave17_expansions import W17_MERGE_CLUSTER
from wave21_expansions import (
    BANK_SLUGS,
    CONTRACT_SLUGS,
    INDIA_COMPRESS_SLUGS,
    WITHOUT_ADOBE_SLUGS,
    W21_ACCOUNTANTS_CLUSTER,
    W21_ADOBE_CLUSTER,
    W21_DATA,
    W21_DEEP,
    W21_INDIA_CLUSTER,
    W21_REGIONAL_CLUSTER,
    W21_SLUGS,
    W21_SLUG_EXTRA,
)

OUT = Path(__file__).resolve().parents[1] / "Content" / "GuideBodiesWave21.cs"


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
    d = W21_DATA[slug]
    lead = (
        f'<p class="lead">Main guide: <a href="{d["pillar"]}">{d["pillar_label"]}</a> · '
        f'Related: <a href="{d["related"]}">{d["related"]}</a>.</p>'
    )
    extra = W21_SLUG_EXTRA.get(slug, "")

    if slug in BANK_SLUGS or slug in CONTRACT_SLUGS:
        cluster = W21_REGIONAL_CLUSTER + W15B_CLUSTER
        mega = W15_MEGA + COMPRESS_MEGA + COMPRESS_UNIVERSAL
    elif slug in INDIA_COMPRESS_SLUGS:
        cluster = W21_INDIA_CLUSTER + COMPRESS_CLUSTER_LINKS
        mega = COMPRESS_MEGA + COMPRESS_LONG_TAIL
    elif slug in WITHOUT_ADOBE_SLUGS:
        cluster = W21_ADOBE_CLUSTER + CONVERT_CLUSTER
        mega = CONVERT_MEGA + COMPARE_MEGA + COMPARE_SMB
    else:
        cluster = W21_ACCOUNTANTS_CLUSTER + W17_MERGE_CLUSTER
        mega = COMPARE_MEGA + PDF_WORD_MEGA

    return f"""
            <h2>{d['title']}</h2>
            <p>Example: {d['example']}.</p>
            {lead}
            {shot(d['title'])}
            {W21_DEEP[slug]}
            {extra}
            {mid_cta(d['tool'], d['label'], 'Start workflow')}
            {mega}
            {COMPLIANCE_MEGA}
            {COMPLIANCE_UNIVERSAL}
            {SHARED_MEGA}
            {SHARED_PILLAR}
            {W6_SHARED_MEGA}
            {W6_1500}
            {W6_1500_EXTENDED}
            {W12_MEGA}
            {W15_1500_TOPUP}
            {W16_1500_TOPUP}
            {W12_1500_TOPUP}
            {W6_LINE_COUNT_FIX}
            {cluster}
            {W12_CLUSTER}
            {COMPRESS_FINAL_BOOST}
            {COMPLIANCE_CLUSTER_LINKS}
            {COMPLIANCE_FINAL_BOOST}
            {PDF_CLUSTER_PREMIUM}
            {PDF_PAGE_PREMIUM}
            {PDF_FINAL_BOOST}
            {W5_1500_TOPUP}
            {W15B_CLOSING}
            {W16_CLOSING}
            {W6_CLOSING}
            {W5_CLOSING}
            {end_cta(d['tool'], d['label'], f'<a href="{d["pillar"]}">Full guide</a>')}
            """


def main() -> None:
    lines = [
        "namespace ratpdf.Content",
        "{",
        "    /// <summary>Wave 21 — Regional bank/contract batch 4 + India compress + without-Adobe + accountants.</summary>",
        "    internal static class GuideBodiesWave21",
        "    {",
        "        public static string? Get(string slug) => slug switch",
        "        {",
    ]
    for slug in W21_SLUGS:
        lines.append(f'            "{slug}" => {const_name(slug)},')
    lines.append("            _ => null")
    lines.append("        };")
    lines.append("")

    for slug in W21_SLUGS:
        content = body(slug).lstrip("\n").rstrip()
        lines += [f"        private const string {const_name(slug)} = \"\"\"", content, "            \"\"\";", ""]

    lines += ["    }", "}"]
    OUT.write_text("\n".join(lines) + "\n", encoding="utf-8")
    print(f"Wrote {OUT} ({len(W21_SLUGS)} guides)")


if __name__ == "__main__":
    main()
