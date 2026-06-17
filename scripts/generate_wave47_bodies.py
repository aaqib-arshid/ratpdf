#!/usr/bin/env python3
"""Generate GuideBodiesWave47.cs — CREATE batch 11 (17 new editorial guides)."""
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
from wave4_expansions import PDF_WORD_MEGA
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
from wave14_expansions import W14_1500_TOPUP, W14_CLUSTER, W14_CLOSING
from wave16_expansions import W16_GLOSSARY_CLUSTER
from wave25_expansions import W25_OCR_CLUSTER
from wave30_expansions import W30_COMPRESS_CLUSTER
from wave46_expansions import W46_ARCHIVAL_CLUSTER, W46_CREATE_CLUSTER
from wave47_expansions import (
    ACCESSIBILITY_CREATE_SLUGS,
    ARCHIVAL_CREATE_SLUGS,
    CONVERT_CREATE_SLUGS,
    DEVICE_CREATE_SLUGS,
    FORM_CREATE_SLUGS,
    PERSONA_CREATE_SLUGS,
    PRINT_CREATE_SLUGS,
    TROUBLESHOOT_CREATE_SLUGS,
    W47_CLOSING,
    W47_COMPRESS_TOPUP,
    W47_CREATE_CLUSTER,
    W47_DATA,
    W47_DEEP,
    W47_DEVICE_CLUSTER,
    W47_PERSONA_CLUSTER,
    W47_SLUGS,
)

OUT = Path(__file__).resolve().parents[1] / "Content" / "GuideBodiesWave47.cs"


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
    d = W47_DATA[slug]
    lead = (
        f'<p class="lead">Pillar: <a href="{d["pillar"]}">{d["pillar_label"]}</a> · '
        f'Related: <a href="{d["related"]}">{d["related"]}</a> · '
        f'Tool page: <a href="{d["prog"]}">{d["prog"]}</a>.</p>'
    )

    if slug in DEVICE_CREATE_SLUGS:
        cluster = W47_CREATE_CLUSTER + W47_DEVICE_CLUSTER + W14_CLUSTER + EDIT_CLUSTER + COMPRESS_CLUSTER_LINKS
        mega = SHARED_MEGA + COMPRESS_MEGA
        topup = W14_1500_TOPUP + W47_COMPRESS_TOPUP
        closing = W47_CLOSING + W14_CLOSING
    elif slug in PERSONA_CREATE_SLUGS:
        cluster = W47_CREATE_CLUSTER + W47_PERSONA_CLUSTER + COMPRESS_CLUSTER_LINKS + EDIT_CLUSTER
        mega = COMPARE_MEGA + COMPARE_SMB + COMPARE_DEEP + SHARED_MEGA
        topup = W6_1500
        closing = W47_CLOSING + W6_CLOSING
    elif slug in ARCHIVAL_CREATE_SLUGS:
        cluster = W47_CREATE_CLUSTER + W46_ARCHIVAL_CLUSTER + W46_CREATE_CLUSTER + W16_GLOSSARY_CLUSTER
        mega = SHARED_MEGA + COMPLIANCE_MEGA
        topup = W12_1500_TOPUP
        closing = W47_CLOSING + W6_CLOSING
    elif slug in TROUBLESHOOT_CREATE_SLUGS or slug in PRINT_CREATE_SLUGS:
        cluster = W47_CREATE_CLUSTER + EDIT_CLUSTER + COMPRESS_CLUSTER_LINKS
        mega = SHARED_MEGA + COMPRESS_MEGA
        topup = W6_1500
        closing = W47_CLOSING + W6_CLOSING
    elif slug in CONVERT_CREATE_SLUGS:
        cluster = W47_CREATE_CLUSTER + EDIT_CLUSTER + COMPRESS_CLUSTER_LINKS
        mega = PDF_WORD_MEGA + SHARED_MEGA
        topup = W6_1500
        closing = W47_CLOSING + W6_CLOSING
    elif slug in FORM_CREATE_SLUGS or slug in ACCESSIBILITY_CREATE_SLUGS:
        cluster = W47_CREATE_CLUSTER + W25_OCR_CLUSTER + W16_GLOSSARY_CLUSTER + EDIT_CLUSTER
        mega = SHARED_MEGA + COMPLIANCE_MEGA
        topup = W12_1500_TOPUP
        closing = W47_CLOSING + W6_CLOSING
    else:
        cluster = W47_CREATE_CLUSTER + COMPRESS_CLUSTER_LINKS
        mega = COMPRESS_MEGA
        topup = W47_COMPRESS_TOPUP
        closing = W47_CLOSING

    return f"""
            <h2>{d['title']}</h2>
            <p>Example: {d['example']}.</p>
            {lead}
            {shot(d['title'])}
            {W47_DEEP[slug]}
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
        "    /// <summary>Wave 47 — CREATE batch 11 (17 new editorial guides).</summary>",
        "    internal static class GuideBodiesWave47",
        "    {",
        "        public static string? Get(string slug) => slug switch",
        "        {",
    ]
    for slug in W47_SLUGS:
        lines.append(f'            "{slug}" => {const_name(slug)},')
    lines.append("            _ => null")
    lines.append("        };")
    lines.append("")

    for slug in W47_SLUGS:
        content = body(slug).lstrip("\n").rstrip()
        lines += [f"        private const string {const_name(slug)} = \"\"\"", content, "            \"\"\";", ""]

    lines += ["    }", "}"]
    OUT.write_text("\n".join(lines) + "\n", encoding="utf-8")
    print(f"Wrote {OUT} ({len(W47_SLUGS)} guides)")


if __name__ == "__main__":
    main()
