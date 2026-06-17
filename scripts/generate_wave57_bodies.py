#!/usr/bin/env python3
"""Generate GuideBodiesWave57.cs — CREATE batch 21 (17 editorial guides)."""
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
from wave12_expansions import W12_1500_TOPUP, W12_CLUSTER, W12_MEGA
from wave16_expansions import W16_GLOSSARY_CLUSTER
from wave25_expansions import W25_OCR_CLUSTER
from wave30_expansions import W30_COMPRESS_CLUSTER
from wave48_expansions import W48_PERSONA_CLUSTER
from wave52_expansions import W52_COMPRESS_FOR_CLUSTER
from wave56_expansions import W56_COMPRESSOR_CLUSTER
from wave57_expansions import (
    COMPRESSOR_CREATE_SLUGS,
    CONVERT_CREATE_SLUGS,
    SECURE_CREATE_SLUGS,
    WORKFLOW_CREATE_SLUGS,
    W57_CLOSING,
    W57_COMPRESSOR_CLUSTER,
    W57_COMPRESS_TOPUP,
    W57_CREATE_CLUSTER,
    W57_DATA,
    W57_DEEP,
    W57_SLUGS,
)

OUT = Path(__file__).resolve().parents[1] / "Content" / "GuideBodiesWave57.cs"


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
    d = W57_DATA[slug]
    lead = (
        f'<p class="lead">Pillar: <a href="{d["pillar"]}">{d["pillar_label"]}</a> · '
        f'Related: <a href="{d["related"]}">{d["related"]}</a> · '
        f'Tool page: <a href="{d["prog"]}">{d["prog"]}</a>.</p>'
    )

    if slug in COMPRESSOR_CREATE_SLUGS:
        cluster = (
            W57_CREATE_CLUSTER
            + W57_COMPRESSOR_CLUSTER
            + W56_COMPRESSOR_CLUSTER
            + W48_PERSONA_CLUSTER
            + W30_COMPRESS_CLUSTER
            + W52_COMPRESS_FOR_CLUSTER
            + COMPRESS_CLUSTER_LINKS
        )
        mega = COMPRESS_MEGA + COMPRESS_LONG_TAIL + COMPARE_MEGA + COMPARE_SMB + COMPARE_DEEP + SHARED_MEGA
        topup = W6_1500 + W57_COMPRESS_TOPUP
        closing = W57_CLOSING + W6_CLOSING
    elif slug in CONVERT_CREATE_SLUGS:
        cluster = W57_CREATE_CLUSTER + W25_OCR_CLUSTER + EDIT_CLUSTER + COMPRESS_CLUSTER_LINKS
        mega = SHARED_MEGA + COMPRESS_MEGA + COMPLIANCE_MEGA
        topup = W6_1500
        closing = W57_CLOSING + W6_CLOSING
    elif slug in WORKFLOW_CREATE_SLUGS:
        cluster = W57_CREATE_CLUSTER + W16_GLOSSARY_CLUSTER + COMPRESS_CLUSTER_LINKS
        mega = SHARED_MEGA + COMPLIANCE_MEGA
        topup = W6_1500 + W57_COMPRESS_TOPUP
        closing = W57_CLOSING + W6_CLOSING
    elif slug in SECURE_CREATE_SLUGS:
        cluster = W57_CREATE_CLUSTER + W48_PERSONA_CLUSTER + EDIT_CLUSTER + COMPRESS_CLUSTER_LINKS
        mega = COMPLIANCE_MEGA + SHARED_MEGA + COMPARE_MEGA
        topup = W6_1500 + W57_COMPRESS_TOPUP
        closing = W57_CLOSING + W6_CLOSING
    else:
        cluster = W57_CREATE_CLUSTER + COMPRESS_CLUSTER_LINKS
        mega = COMPRESS_MEGA
        topup = W57_COMPRESS_TOPUP
        closing = W57_CLOSING

    return f"""
            <h2>{d['title']}</h2>
            <p>Example: {d['example']}.</p>
            {lead}
            {shot(d['title'])}
            {W57_DEEP[slug]}
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
        "    /// <summary>Wave 57 — CREATE batch 21 (17 editorial guides).</summary>",
        "    internal static class GuideBodiesWave57",
        "    {",
        "        public static string? Get(string slug) => slug switch",
        "        {",
    ]
    for slug in W57_SLUGS:
        lines.append(f'            "{slug}" => {const_name(slug)},')
    lines.append("            _ => null")
    lines.append("        };")
    lines.append("")

    for slug in W57_SLUGS:
        content = body(slug).lstrip("\n").rstrip()
        lines += [f"        private const string {const_name(slug)} = \"\"\"", content, "            \"\"\";", ""]

    lines += ["    }", "}"]
    OUT.write_text("\n".join(lines) + "\n", encoding="utf-8")
    print(f"Wrote {OUT} ({len(W57_SLUGS)} guides)")


if __name__ == "__main__":
    main()
