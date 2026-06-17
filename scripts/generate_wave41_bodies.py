#!/usr/bin/env python3
"""Generate GuideBodiesWave41.cs — CREATE batch 5 (17 new editorial guides)."""
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
    COMPARE_DEEP,
    COMPARE_MEGA,
    COMPARE_SMB,
    EDIT_CLUSTER,
    SHARED_MEGA,
    W6_1500,
    W6_1500_EXTENDED,
    W6_CLOSING,
    W6_LINE_COUNT_FIX,
    W6_SHARED_MEGA,
)
from wave7_expansions import SHARED_PILLAR
from wave11_expansions import W11_1500_TOPUP, W11_CLUSTER, W11_CLOSING, W11_MEGA
from wave12_expansions import W12_1500_TOPUP, W12_CLUSTER, W12_MEGA
from wave16_expansions import W16_GLOSSARY_CLUSTER
from wave21_expansions import W21_REGIONAL_CLUSTER
from wave25_expansions import W25_OCR_CLUSTER
from wave30_expansions import W30_COMPRESS_CLUSTER
from wave38_expansions import W38_CREATE_CLUSTER, W38_VISA_TOPUP
from wave39_expansions import W39_CREATE_CLUSTER
from wave40_expansions import W40_CREATE_CLUSTER, W40_VISA_REGIONAL_CLUSTER
from wave41_expansions import (
    ACCESSIBILITY_CREATE_SLUGS,
    COMPARE_CREATE_SLUGS,
    COMPRESS_CREATE_SLUGS,
    GOVT_CREATE_SLUGS,
    HEALTH_CREATE_SLUGS,
    STUDENT_CREATE_SLUGS,
    TROUBLESHOOT_CREATE_SLUGS,
    VISA_CREATE_SLUGS,
    W41_ASIA_VISA_CLUSTER,
    W41_CLOSING,
    W41_COMPRESS_TOPUP,
    W41_CREATE_CLUSTER,
    W41_DATA,
    W41_DEEP,
    W41_SLUGS,
)

OUT = Path(__file__).resolve().parents[1] / "Content" / "GuideBodiesWave41.cs"


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
    d = W41_DATA[slug]
    lead = (
        f'<p class="lead">Pillar: <a href="{d["pillar"]}">{d["pillar_label"]}</a> · '
        f'Related: <a href="{d["related"]}">{d["related"]}</a> · '
        f'Tool page: <a href="{d["prog"]}">{d["prog"]}</a>.</p>'
    )

    if slug in VISA_CREATE_SLUGS:
        cluster = (
            W41_CREATE_CLUSTER
            + W41_ASIA_VISA_CLUSTER
            + W40_VISA_REGIONAL_CLUSTER
            + W40_CREATE_CLUSTER
            + W39_CREATE_CLUSTER
            + W38_CREATE_CLUSTER
            + W38_VISA_TOPUP
            + W21_REGIONAL_CLUSTER
            + COMPRESS_CLUSTER_LINKS
        )
        mega = COMPRESS_MEGA + COMPRESS_LONG_TAIL + COMPLIANCE_MEGA
        topup = W41_COMPRESS_TOPUP + W12_1500_TOPUP
        closing = W41_CLOSING + W5_CLOSING
    elif slug in GOVT_CREATE_SLUGS or slug in COMPRESS_CREATE_SLUGS:
        cluster = W41_CREATE_CLUSTER + W30_COMPRESS_CLUSTER + COMPRESS_CLUSTER_LINKS
        mega = COMPRESS_MEGA + COMPRESS_LONG_TAIL + COMPLIANCE_MEGA
        topup = W41_COMPRESS_TOPUP + W12_1500_TOPUP
        closing = W41_CLOSING + W5_CLOSING
    elif slug in COMPARE_CREATE_SLUGS:
        cluster = W41_CREATE_CLUSTER + W12_CLUSTER + COMPRESS_CLUSTER_LINKS
        mega = COMPARE_MEGA + COMPARE_SMB + COMPARE_DEEP + SHARED_MEGA
        topup = W12_1500_TOPUP
        closing = W41_CLOSING + W6_CLOSING
    elif slug in HEALTH_CREATE_SLUGS:
        cluster = W41_CREATE_CLUSTER + W11_CLUSTER
        mega = W11_MEGA + COMPLIANCE_MEGA
        topup = W11_1500_TOPUP
        closing = W41_CLOSING + W11_CLOSING
    elif slug in STUDENT_CREATE_SLUGS or slug in ACCESSIBILITY_CREATE_SLUGS:
        cluster = W41_CREATE_CLUSTER + W25_OCR_CLUSTER + W16_GLOSSARY_CLUSTER + EDIT_CLUSTER
        mega = SHARED_MEGA + COMPLIANCE_MEGA
        topup = W12_1500_TOPUP
        closing = W41_CLOSING + W6_CLOSING
    elif slug in TROUBLESHOOT_CREATE_SLUGS:
        cluster = W41_CREATE_CLUSTER + EDIT_CLUSTER + W11_CLUSTER
        mega = SHARED_MEGA + W11_MEGA
        topup = W11_1500_TOPUP + W6_1500
        closing = W41_CLOSING + W11_CLOSING
    else:
        cluster = W41_CREATE_CLUSTER + COMPRESS_CLUSTER_LINKS
        mega = COMPRESS_MEGA
        topup = W41_COMPRESS_TOPUP
        closing = W41_CLOSING

    return f"""
            <h2>{d['title']}</h2>
            <p>Example: {d['example']}.</p>
            {lead}
            {shot(d['title'])}
            {W41_DEEP[slug]}
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
            {closing}
            {W6_CLOSING}
            {W5_CLOSING}
            {end_cta(d['tool'], d['label'], f'<a href="{d["pillar"]}">Full guide</a>')}
            """


def main() -> None:
    lines = [
        "namespace ratpdf.Content",
        "{",
        "    /// <summary>Wave 41 — CREATE batch 5 (17 new editorial guides).</summary>",
        "    internal static class GuideBodiesWave41",
        "    {",
        "        public static string? Get(string slug) => slug switch",
        "        {",
    ]
    for slug in W41_SLUGS:
        lines.append(f'            "{slug}" => {const_name(slug)},')
    lines.append("            _ => null")
    lines.append("        };")
    lines.append("")

    for slug in W41_SLUGS:
        content = body(slug).lstrip("\n").rstrip()
        lines += [f"        private const string {const_name(slug)} = \"\"\"", content, "            \"\"\";", ""]

    lines += ["    }", "}"]
    OUT.write_text("\n".join(lines) + "\n", encoding="utf-8")
    print(f"Wrote {OUT} ({len(W41_SLUGS)} guides)")


if __name__ == "__main__":
    main()
