#!/usr/bin/env python3
"""Generate GuideBodiesWave60.cs — CREATE batch 24 (17 editorial guides)."""
from pathlib import Path

from wave1_expansions import PDF_CLUSTER_PREMIUM, PDF_FINAL_BOOST, PDF_PAGE_PREMIUM
from wave2_expansions import OCR_CLUSTER_LINKS, OCR_LANG_EXTRA
from wave3_expansions import (
    COMPRESS_CLUSTER_LINKS,
    COMPRESS_FINAL_BOOST,
    COMPRESS_MEGA,
    COMPLIANCE_FINAL_BOOST,
    COMPLIANCE_MEGA,
    COMPLIANCE_UNIVERSAL,
)
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
from wave16_expansions import W16_GLOSSARY_CLUSTER
from wave25_expansions import W25_OCR_CLUSTER
from wave60_expansions import (
    CONVERT_CREATE_SLUGS,
    INFO_CREATE_SLUGS,
    OCR_LANG_CREATE_SLUGS,
    WORKFLOW_CREATE_SLUGS,
    W60_CLOSING,
    W60_CREATE_CLUSTER,
    W60_DATA,
    W60_DEEP,
    W60_LANG_CLUSTER,
    W60_SLUGS,
    W60_TOPUP,
)

OUT = Path(__file__).resolve().parents[1] / "Content" / "GuideBodiesWave60.cs"


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
    d = W60_DATA[slug]
    lead = (
        f'<p class="lead">Pillar: <a href="{d["pillar"]}">{d["pillar_label"]}</a> · '
        f'Related: <a href="{d["related"]}">{d["related"]}</a> · '
        f'Tool page: <a href="{d["prog"]}">{d["prog"]}</a>.</p>'
    )

    if slug in OCR_LANG_CREATE_SLUGS:
        cluster = W60_CREATE_CLUSTER + W60_LANG_CLUSTER + W25_OCR_CLUSTER + OCR_CLUSTER_LINKS
        mega = OCR_LANG_EXTRA + SHARED_MEGA + COMPRESS_MEGA
        topup = W6_1500 + W60_TOPUP
        closing = W60_CLOSING + W6_CLOSING
    elif slug in CONVERT_CREATE_SLUGS:
        cluster = W60_CREATE_CLUSTER + W25_OCR_CLUSTER + EDIT_CLUSTER + COMPRESS_CLUSTER_LINKS
        mega = SHARED_MEGA + COMPRESS_MEGA + COMPLIANCE_MEGA
        topup = W6_1500 + W60_TOPUP
        closing = W60_CLOSING + W6_CLOSING
    elif slug in INFO_CREATE_SLUGS:
        cluster = W60_CREATE_CLUSTER + W16_GLOSSARY_CLUSTER + COMPRESS_CLUSTER_LINKS
        mega = COMPRESS_MEGA + SHARED_MEGA
        topup = W6_1500 + W60_TOPUP
        closing = W60_CLOSING + W6_CLOSING
    elif slug in WORKFLOW_CREATE_SLUGS:
        cluster = W60_CREATE_CLUSTER + W16_GLOSSARY_CLUSTER + EDIT_CLUSTER + COMPRESS_CLUSTER_LINKS
        mega = SHARED_MEGA + COMPLIANCE_MEGA
        topup = W6_1500 + W60_TOPUP
        closing = W60_CLOSING + W6_CLOSING
    else:
        cluster = W60_CREATE_CLUSTER + COMPRESS_CLUSTER_LINKS
        mega = COMPRESS_MEGA
        topup = W60_TOPUP
        closing = W60_CLOSING

    return f"""
            <h2>{d['title']}</h2>
            <p>Example: {d['example']}.</p>
            {lead}
            {shot(d['title'])}
            {W60_DEEP[slug]}
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
        "    /// <summary>Wave 60 — CREATE batch 24 (17 editorial guides).</summary>",
        "    internal static class GuideBodiesWave60",
        "    {",
        "        public static string? Get(string slug) => slug switch",
        "        {",
    ]
    for slug in W60_SLUGS:
        lines.append(f'            "{slug}" => {const_name(slug)},')
    lines.append("            _ => null")
    lines.append("        };")
    lines.append("")

    for slug in W60_SLUGS:
        content = body(slug).lstrip("\n").rstrip()
        lines += [f"        private const string {const_name(slug)} = \"\"\"", content, "            \"\"\";", ""]

    lines += ["    }", "}"]
    OUT.write_text("\n".join(lines) + "\n", encoding="utf-8")
    print(f"Wrote {OUT} ({len(W60_SLUGS)} guides)")


if __name__ == "__main__":
    main()
