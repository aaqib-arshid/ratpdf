#!/usr/bin/env python3
"""Generate GuideBodiesWave18.cs — Conversion guides + regional compress upgrades."""
from pathlib import Path

from wave1_expansions import PDF_CLUSTER_PREMIUM, PDF_FINAL_BOOST, PDF_PAGE_PREMIUM
from wave3_expansions import (
    COMPRESS_CLUSTER_LINKS,
    COMPRESS_FINAL_BOOST,
    COMPRESS_LONG_TAIL,
    COMPRESS_MEGA,
    COMPLIANCE_FINAL_BOOST,
)
from wave4_expansions import PDF_WORD_CLUSTER_LINKS, PDF_WORD_MEGA, PDF_WORD_LONG_TAIL
from wave5_expansions import W5_1500_TOPUP, W5_CLOSING
from wave6_expansions import W6_1500, W6_1500_EXTENDED, W6_CLOSING, W6_LINE_COUNT_FIX, W6_SHARED_MEGA
from wave7_expansions import SHARED_PILLAR
from wave12_expansions import W12_1500_TOPUP, W12_CLUSTER, W12_MEGA
from wave16_expansions import W16_1500_TOPUP, W16_CLOSING
from wave18_expansions import (
    CONVERT_SLUGS,
    W18_DATA,
    W18_DEEP,
    W18_CONVERT_CLUSTER,
    W18_REGIONAL_CLUSTER,
    W18_SLUGS,
    W18_WORD_CLUSTER,
    WORD_SLUGS,
)

OUT = Path(__file__).resolve().parents[1] / "Content" / "GuideBodiesWave18.cs"


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
    d = W18_DATA[slug]
    lead = (
        f'<p class="lead">Pillar: <a href="{d["pillar"]}">{d["pillar_label"]}</a> · '
        f'Tool page: <a href="{d["programmatic"]}">{d["programmatic"]}</a>.</p>'
    )
    if slug in CONVERT_SLUGS:
        cluster = W18_WORD_CLUSTER if slug in WORD_SLUGS else W18_CONVERT_CLUSTER
        mega = PDF_WORD_MEGA + PDF_WORD_LONG_TAIL
    else:
        cluster = W18_REGIONAL_CLUSTER if slug.startswith("compress-pdf-") else COMPRESS_CLUSTER_LINKS
        mega = COMPRESS_MEGA + COMPRESS_LONG_TAIL

    return f"""
            <h2>{d['title']}</h2>
            <p>Example: {d['example']}.</p>
            {lead}
            {shot(d['title'])}
            {W18_DEEP[slug]}
            {mid_cta(d['tool'], d['label'], 'Open the primary tool')}
            {mega}
            {SHARED_PILLAR}
            {W6_SHARED_MEGA}
            {W6_1500}
            {W6_1500_EXTENDED}
            {W12_MEGA}
            {W16_1500_TOPUP}
            {W12_1500_TOPUP}
            {W6_LINE_COUNT_FIX}
            {cluster}
            {PDF_WORD_CLUSTER_LINKS if slug in CONVERT_SLUGS else COMPRESS_CLUSTER_LINKS}
            {W12_CLUSTER}
            {COMPRESS_FINAL_BOOST}
            {COMPLIANCE_FINAL_BOOST}
            {PDF_CLUSTER_PREMIUM}
            {PDF_PAGE_PREMIUM}
            {PDF_FINAL_BOOST}
            {W5_1500_TOPUP}
            {W16_CLOSING}
            {W6_CLOSING}
            {W5_CLOSING}
            {end_cta(d['tool'], d['label'], f'<a href="{d["pillar"]}">Pillar guide</a> · <a href="{d["programmatic"]}">Related tool page</a>')}
            """


def main() -> None:
    lines = [
        "namespace ratpdf.Content",
        "{",
        "    /// <summary>Wave 18 — Conversion guides + regional compress upgrades.</summary>",
        "    internal static class GuideBodiesWave18",
        "    {",
        "        public static string? Get(string slug) => slug switch",
        "        {",
    ]
    for slug in W18_SLUGS:
        lines.append(f'            "{slug}" => {const_name(slug)},')
    lines.append("            _ => null")
    lines.append("        };")
    lines.append("")

    for slug in W18_SLUGS:
        content = body(slug).lstrip("\n").rstrip()
        lines += [f"        private const string {const_name(slug)} = \"\"\"", content, "            \"\"\";", ""]

    lines += ["    }", "}"]
    OUT.write_text("\n".join(lines) + "\n", encoding="utf-8")
    print(f"Wrote {OUT} ({len(W18_SLUGS)} guides)")


if __name__ == "__main__":
    main()
