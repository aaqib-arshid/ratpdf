#!/usr/bin/env python3
"""Generate GuideBodiesWave20.cs — Tools hub + edit + regional visa/bank batch 3."""
from pathlib import Path

from wave1_expansions import PDF_CLUSTER_PREMIUM, PDF_FINAL_BOOST, PDF_PAGE_PREMIUM
from wave3_expansions import (
    COMPRESS_CLUSTER_LINKS,
    COMPRESS_FINAL_BOOST,
    COMPRESS_MEGA,
    COMPRESS_LONG_TAIL,
    COMPLIANCE_CLUSTER_LINKS,
    COMPLIANCE_FINAL_BOOST,
    COMPLIANCE_MEGA,
    COMPLIANCE_UNIVERSAL,
)
from wave4_expansions import PDF_WORD_MEGA
from wave5_expansions import W5_1500_TOPUP, W5_CLOSING
from wave6_expansions import (
    COMPARE_1500_FINAL,
    COMPARE_DEEP,
    COMPARE_FINAL,
    COMPARE_MEGA,
    COMPARE_SMB,
    CONVERT_CLUSTER,
    EDIT_1500_FINAL,
    EDIT_CLUSTER,
    EDIT_FINAL,
    EDIT_MEGA,
    EDIT_UNIVERSAL,
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
from wave20_expansions import (
    BANK_SLUGS,
    EDIT_SLUGS,
    TOOLS_SLUGS,
    VISA_SLUGS,
    W20_DATA,
    W20_DEEP,
    W20_EDIT_CLUSTER,
    W20_REGIONAL_CLUSTER,
    W20_SLUGS,
    W20_TOOLS_CLUSTER,
)

OUT = Path(__file__).resolve().parents[1] / "Content" / "GuideBodiesWave20.cs"


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


def lead_block(slug: str, d: dict) -> str:
    if slug in TOOLS_SLUGS:
        return (
            f'<p class="lead">Pillar: <a href="{d["pillar"]}">{d["pillar_label"]}</a> · '
            f'Research: <a href="{d["research"]}">{d["research"]}</a>.</p>'
        )
    if slug in EDIT_SLUGS:
        return (
            f'<p class="lead">Workflow hub: <a href="{d["pillar"]}">{d["pillar_label"]}</a> · '
            f'Compare: <a href="{d["research"]}">{d["research"]}</a>.</p>'
        )
    return (
        f'<p class="lead">Main guide: <a href="{d["pillar"]}">{d["pillar_label"]}</a> · '
        f'Related: <a href="{d["research"]}">{d["research"]}</a>.</p>'
    )


def body(slug: str) -> str:
    d = W20_DATA[slug]
    lead = lead_block(slug, d)

    if slug in TOOLS_SLUGS:
        cluster = W20_TOOLS_CLUSTER
        if slug in ("compress-vs-split", "merge-vs-compress"):
            cluster = W20_TOOLS_CLUSTER + COMPRESS_CLUSTER_LINKS
        mega = COMPARE_MEGA + COMPARE_DEEP + COMPARE_SMB
        final = COMPARE_1500_FINAL + COMPARE_FINAL
    elif slug in EDIT_SLUGS:
        cluster = W20_EDIT_CLUSTER + EDIT_CLUSTER
        if slug == "pdf-to-powerpoint":
            cluster = W20_EDIT_CLUSTER + CONVERT_CLUSTER
        mega = EDIT_MEGA + EDIT_UNIVERSAL
        final = EDIT_1500_FINAL + EDIT_FINAL
    else:
        cluster = W20_REGIONAL_CLUSTER + W15B_CLUSTER
        mega = W15_MEGA + COMPRESS_MEGA
        final = COMPLIANCE_FINAL_BOOST

    return f"""
            <h2>{d['title']}</h2>
            <p>Example: {d['example']}.</p>
            {lead}
            {shot(d['title'])}
            {W20_DEEP[slug]}
            {mid_cta(d['tool'], d['label'], 'Open the primary tool')}
            {mega}
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
            {COMPLIANCE_MEGA}
            {COMPLIANCE_UNIVERSAL}
            {COMPLIANCE_CLUSTER_LINKS}
            {PDF_WORD_MEGA}
            {final}
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
        "    /// <summary>Wave 20 — Tools hub + edit guides + regional visa/bank batch 3.</summary>",
        "    internal static class GuideBodiesWave20",
        "    {",
        "        public static string? Get(string slug) => slug switch",
        "        {",
    ]
    for slug in W20_SLUGS:
        lines.append(f'            "{slug}" => {const_name(slug)},')
    lines.append("            _ => null")
    lines.append("        };")
    lines.append("")

    for slug in W20_SLUGS:
        content = body(slug).lstrip("\n").rstrip()
        lines += [f"        private const string {const_name(slug)} = \"\"\"", content, "            \"\"\";", ""]

    lines += ["    }", "}"]
    OUT.write_text("\n".join(lines) + "\n", encoding="utf-8")
    print(f"Wrote {OUT} ({len(W20_SLUGS)} guides)")


if __name__ == "__main__":
    main()
