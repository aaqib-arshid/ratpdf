#!/usr/bin/env python3
"""Generate GuideBodiesWave25.cs — Beginner page size/tags + security how-to + OCR + email 2027 + glossary 7."""
from pathlib import Path

from wave1_expansions import PDF_CLUSTER_PREMIUM, PDF_FINAL_BOOST, PDF_PAGE_PREMIUM
from wave3_expansions import (
    COMPRESS_CLUSTER_LINKS,
    COMPRESS_FINAL_BOOST,
    COMPRESS_LONG_TAIL,
    COMPRESS_MEGA,
    COMPLIANCE_CLUSTER_LINKS,
    COMPLIANCE_FINAL_BOOST,
    COMPLIANCE_MEGA,
    COMPLIANCE_UNIVERSAL,
)
from wave4_expansions import PDF_WORD_MEGA
from wave5_expansions import W5_1500_TOPUP, W5_CLOSING
from wave6_expansions import (
    CONVERT_MEGA,
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
from wave16_expansions import W16_1500_TOPUP, W16_CLOSING, W16_GLOSSARY_CLUSTER, W16_MEGA
from wave23_expansions import W23_BEGINNER_CLUSTER
from wave24_expansions import W24_BEGINNER_CLUSTER, W24_EMAIL_CLUSTER, W24_GLOSSARY_CLUSTER, W24_TEXT_CLUSTER
from wave25_expansions import (
    BEGINNER_SLUGS,
    EMAIL_SLUGS,
    GLOSSARY_SLUGS,
    OCR_SLUGS,
    SECURITY_HOWTO_SLUGS,
    W25_BEGINNER_CLUSTER,
    W25_DATA,
    W25_DEEP,
    W25_EMAIL_CLUSTER,
    W25_GLOSSARY_CLUSTER,
    W25_OCR_CLUSTER,
    W25_SECURITY_CLUSTER,
    W25_SLUGS,
)

OUT = Path(__file__).resolve().parents[1] / "Content" / "GuideBodiesWave25.cs"


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
    d = W25_DATA[slug]
    lead = (
        f'<p class="lead">Learn more: <a href="{d["pillar"]}">{d["pillar_label"]}</a> · '
        f'Related: <a href="{d["related"]}">{d["related"]}</a>.</p>'
    )

    if slug in BEGINNER_SLUGS:
        cluster = W25_BEGINNER_CLUSTER + W24_BEGINNER_CLUSTER + W23_BEGINNER_CLUSTER
        mega = COMPLIANCE_MEGA + SHARED_MEGA
        topup = W16_1500_TOPUP
        closing = W16_CLOSING
    elif slug in SECURITY_HOWTO_SLUGS:
        cluster = W25_SECURITY_CLUSTER + W11_CLUSTER
        mega = W11_MEGA + COMPLIANCE_MEGA
        topup = W11_1500_TOPUP
        closing = W11_CLOSING
    elif slug in OCR_SLUGS:
        cluster = W25_OCR_CLUSTER + W24_TEXT_CLUSTER + EDIT_CLUSTER
        mega = CONVERT_MEGA + PDF_WORD_MEGA + COMPRESS_MEGA
        topup = W16_1500_TOPUP
        closing = W6_CLOSING
    elif slug in EMAIL_SLUGS:
        cluster = W25_EMAIL_CLUSTER + W24_EMAIL_CLUSTER + COMPLIANCE_CLUSTER_LINKS + COMPRESS_CLUSTER_LINKS
        mega = COMPRESS_MEGA + COMPRESS_LONG_TAIL + COMPLIANCE_MEGA
        topup = W12_1500_TOPUP
        closing = W5_CLOSING
    else:
        cluster = W25_GLOSSARY_CLUSTER + W24_GLOSSARY_CLUSTER + W16_GLOSSARY_CLUSTER
        mega = W16_MEGA
        topup = W16_1500_TOPUP
        closing = W16_CLOSING

    return f"""
            <h2>{d['title']}</h2>
            <p>Example: {d['example']}.</p>
            {lead}
            {shot(d['title'])}
            {W25_DEEP[slug]}
            {mid_cta(d['tool'], d['label'], 'Try the tool')}
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
        "    /// <summary>Wave 25 — Beginner page size/tags + security how-to + OCR + email 2027 + glossary 7.</summary>",
        "    internal static class GuideBodiesWave25",
        "    {",
        "        public static string? Get(string slug) => slug switch",
        "        {",
    ]
    for slug in W25_SLUGS:
        lines.append(f'            "{slug}" => {const_name(slug)},')
    lines.append("            _ => null")
    lines.append("        };")
    lines.append("")

    for slug in W25_SLUGS:
        content = body(slug).lstrip("\n").rstrip()
        lines += [f"        private const string {const_name(slug)} = \"\"\"", content, "            \"\"\";", ""]

    lines += ["    }", "}"]
    OUT.write_text("\n".join(lines) + "\n", encoding="utf-8")
    print(f"Wrote {OUT} ({len(W25_SLUGS)} guides)")


if __name__ == "__main__":
    main()
