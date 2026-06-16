#!/usr/bin/env python3
"""Generate GuideBodiesWave19.cs — Industry compress + glossary batch 3 + mistakes guide."""
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
from wave16_expansions import W16_1500_TOPUP, W16_CLOSING, W16_GLOSSARY_CLUSTER, W16_MEGA
from wave19_expansions import (
    GLOSSARY_SLUGS,
    INDUSTRY_SLUGS,
    W19_DATA,
    W19_DEEP,
    W19_GLOSSARY_CLUSTER,
    W19_INDUSTRY_CLUSTER,
    W19_SLUGS,
)

OUT = Path(__file__).resolve().parents[1] / "Content" / "GuideBodiesWave19.cs"


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
    d = W19_DATA[slug]
    pillar_link = (
        f'<p class="lead">Main workflow guide: '
        f'<a href="{d["pillar"]}">{d["pillar_label"]}</a>.</p>'
    )

    if slug in GLOSSARY_SLUGS:
        cluster = W19_GLOSSARY_CLUSTER + W16_GLOSSARY_CLUSTER
        mega = W16_MEGA
        extra_blocks = ""
    elif slug == "mistakes-pdf-to-word-for-scanned-tables":
        cluster = PDF_WORD_CLUSTER_LINKS
        mega = PDF_WORD_MEGA + PDF_WORD_LONG_TAIL
        extra_blocks = ""
    else:
        cluster = W19_INDUSTRY_CLUSTER + COMPRESS_CLUSTER_LINKS
        mega = COMPRESS_MEGA + COMPRESS_LONG_TAIL
        extra_blocks = ""

    return f"""
            <h2>{d['title']}</h2>
            <p>Example: {d['example']}.</p>
            {pillar_link}
            {shot(d['title'])}
            {W19_DEEP[slug]}
            {mid_cta(d['tool'], d['label'], 'Try the related tool')}
            {mega}
            {extra_blocks}
            {SHARED_PILLAR}
            {W6_SHARED_MEGA}
            {W6_1500}
            {W6_1500_EXTENDED}
            {W12_MEGA}
            {W16_1500_TOPUP}
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
            {W16_CLOSING}
            {W6_CLOSING}
            {W5_CLOSING}
            {end_cta(d['tool'], d['label'], f'<a href="{d["pillar"]}">Full guide</a>')}
            """


def main() -> None:
    lines = [
        "namespace ratpdf.Content",
        "{",
        "    /// <summary>Wave 19 — Industry compress + glossary batch 3 + scanned-table mistakes.</summary>",
        "    internal static class GuideBodiesWave19",
        "    {",
        "        public static string? Get(string slug) => slug switch",
        "        {",
    ]
    for slug in W19_SLUGS:
        lines.append(f'            "{slug}" => {const_name(slug)},')
    lines.append("            _ => null")
    lines.append("        };")
    lines.append("")

    for slug in W19_SLUGS:
        content = body(slug).lstrip("\n").rstrip()
        lines += [f"        private const string {const_name(slug)} = \"\"\"", content, "            \"\"\";", ""]

    lines += ["    }", "}"]
    OUT.write_text("\n".join(lines) + "\n", encoding="utf-8")
    print(f"Wrote {OUT} ({len(W19_SLUGS)} guides)")


if __name__ == "__main__":
    main()
