#!/usr/bin/env python3
"""Generate GuideBodiesWave52.cs — CREATE batch 16 (17 editorial guides)."""
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
    EDIT_CLUSTER,
    SHARED_MEGA,
    W6_1500,
    W6_1500_EXTENDED,
    W6_CLOSING,
    W6_LINE_COUNT_FIX,
    W6_SHARED_MEGA,
)
from wave7_expansions import SHARED_PILLAR
from wave12_expansions import W12_1500_TOPUP, W12_CLUSTER, W12_MEGA
from wave14_expansions import W14_1500_TOPUP, W14_CLUSTER, W14_CLOSING
from wave16_expansions import W16_GLOSSARY_CLUSTER
from wave25_expansions import W25_OCR_CLUSTER
from wave30_expansions import W30_COMPRESS_CLUSTER
from wave46_expansions import W46_ARCHIVAL_CLUSTER
from wave51_expansions import W51_DEVICE_CLUSTER
from wave52_expansions import (
    ACCESSIBILITY_CREATE_SLUGS,
    ARCHIVAL_CREATE_SLUGS,
    COMPRESS_FOR_CREATE_SLUGS,
    CONVERT_CREATE_SLUGS,
    DEVICE_CREATE_SLUGS,
    INFO_CREATE_SLUGS,
    WORKFLOW_CREATE_SLUGS,
    W52_CLOSING,
    W52_COMPRESS_FOR_CLUSTER,
    W52_COMPRESS_TOPUP,
    W52_CREATE_CLUSTER,
    W52_DATA,
    W52_DEEP,
    W52_DEVICE_CLUSTER,
    W52_SLUGS,
)

OUT = Path(__file__).resolve().parents[1] / "Content" / "GuideBodiesWave52.cs"


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
    d = W52_DATA[slug]
    lead = (
        f'<p class="lead">Pillar: <a href="{d["pillar"]}">{d["pillar_label"]}</a> · '
        f'Related: <a href="{d["related"]}">{d["related"]}</a> · '
        f'Tool page: <a href="{d["prog"]}">{d["prog"]}</a>.</p>'
    )

    if slug in COMPRESS_FOR_CREATE_SLUGS:
        cluster = W52_CREATE_CLUSTER + W52_COMPRESS_FOR_CLUSTER + W30_COMPRESS_CLUSTER + COMPRESS_CLUSTER_LINKS
        mega = COMPRESS_MEGA + COMPRESS_LONG_TAIL + SHARED_MEGA
        topup = W52_COMPRESS_TOPUP + W12_1500_TOPUP
        closing = W52_CLOSING + W5_CLOSING
    elif slug in DEVICE_CREATE_SLUGS or slug in CONVERT_CREATE_SLUGS:
        cluster = W52_CREATE_CLUSTER + W52_DEVICE_CLUSTER + W51_DEVICE_CLUSTER + W14_CLUSTER + EDIT_CLUSTER
        mega = PDF_WORD_MEGA + SHARED_MEGA + COMPRESS_MEGA
        topup = W14_1500_TOPUP + W52_COMPRESS_TOPUP
        closing = W52_CLOSING + W14_CLOSING
    elif slug in ARCHIVAL_CREATE_SLUGS:
        cluster = W52_CREATE_CLUSTER + W46_ARCHIVAL_CLUSTER + W16_GLOSSARY_CLUSTER
        mega = SHARED_MEGA + COMPLIANCE_MEGA
        topup = W12_1500_TOPUP
        closing = W52_CLOSING + W6_CLOSING
    elif slug in WORKFLOW_CREATE_SLUGS:
        cluster = W52_CREATE_CLUSTER + EDIT_CLUSTER + COMPRESS_CLUSTER_LINKS
        mega = SHARED_MEGA + COMPRESS_MEGA
        topup = W6_1500
        closing = W52_CLOSING + W6_CLOSING
    elif slug in ACCESSIBILITY_CREATE_SLUGS:
        cluster = W52_CREATE_CLUSTER + W25_OCR_CLUSTER + W16_GLOSSARY_CLUSTER
        mega = SHARED_MEGA + COMPLIANCE_MEGA
        topup = W12_1500_TOPUP
        closing = W52_CLOSING + W6_CLOSING
    elif slug in INFO_CREATE_SLUGS:
        cluster = W52_CREATE_CLUSTER + W16_GLOSSARY_CLUSTER + SHARED_PILLAR
        mega = SHARED_MEGA + COMPLIANCE_MEGA
        topup = W5_1500_TOPUP
        closing = W52_CLOSING + W5_CLOSING
    else:
        cluster = W52_CREATE_CLUSTER + COMPRESS_CLUSTER_LINKS
        mega = COMPRESS_MEGA
        topup = W52_COMPRESS_TOPUP
        closing = W52_CLOSING

    return f"""
            <h2>{d['title']}</h2>
            <p>Example: {d['example']}.</p>
            {lead}
            {shot(d['title'])}
            {W52_DEEP[slug]}
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
        "    /// <summary>Wave 52 — CREATE batch 16 (17 editorial guides).</summary>",
        "    internal static class GuideBodiesWave52",
        "    {",
        "        public static string? Get(string slug) => slug switch",
        "        {",
    ]
    for slug in W52_SLUGS:
        lines.append(f'            "{slug}" => {const_name(slug)},')
    lines.append("            _ => null")
    lines.append("        };")
    lines.append("")

    for slug in W52_SLUGS:
        content = body(slug).lstrip("\n").rstrip()
        lines += [f"        private const string {const_name(slug)} = \"\"\"", content, "            \"\"\";", ""]

    lines += ["    }", "}"]
    OUT.write_text("\n".join(lines) + "\n", encoding="utf-8")
    print(f"Wrote {OUT} ({len(W52_SLUGS)} guides)")


if __name__ == "__main__":
    main()
