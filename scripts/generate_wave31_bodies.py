#!/usr/bin/env python3
"""Generate GuideBodiesWave31.cs — PDF security authority batch + glossary batch 8."""
from pathlib import Path

from wave1_expansions import PDF_CLUSTER_PREMIUM, PDF_FINAL_BOOST, PDF_PAGE_PREMIUM
from wave3_expansions import (
    COMPLIANCE_CLUSTER_LINKS,
    COMPLIANCE_FINAL_BOOST,
    COMPLIANCE_MEGA,
    COMPLIANCE_UNIVERSAL,
)
from wave5_expansions import W5_1500_TOPUP, W5_CLOSING
from wave6_expansions import (
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
from wave25_expansions import W25_GLOSSARY_CLUSTER, W25_SECURITY_CLUSTER
from wave31_expansions import (
    GLOSSARY_SLUGS,
    SECURITY_SLUGS,
    W31_CLOSING,
    W31_DATA,
    W31_DEEP,
    W31_GLOSSARY_CLUSTER,
    W31_GLOSSARY_TOPUP,
    W31_SECURITY_CLUSTER,
    W31_SECURITY_TOPUP,
    W31_SLUGS,
)

OUT = Path(__file__).resolve().parents[1] / "Content" / "GuideBodiesWave31.cs"


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
    d = W31_DATA[slug]
    lead = (
        f'<p class="lead">Pillar: <a href="{d["pillar"]}">{d["pillar_label"]}</a> · '
        f'Related: <a href="{d["related"]}">{d["related"]}</a>.</p>'
    )

    if slug in SECURITY_SLUGS:
        cluster = W31_SECURITY_CLUSTER + W25_SECURITY_CLUSTER + W11_CLUSTER + COMPLIANCE_CLUSTER_LINKS
        mega = W11_MEGA + COMPLIANCE_MEGA + SHARED_MEGA
        topup = W11_1500_TOPUP + W31_SECURITY_TOPUP
        closing = W11_CLOSING + W31_CLOSING
    else:
        cluster = W31_GLOSSARY_CLUSTER + W25_GLOSSARY_CLUSTER + W16_GLOSSARY_CLUSTER
        mega = W16_MEGA + SHARED_MEGA
        topup = W16_1500_TOPUP + W31_GLOSSARY_TOPUP
        closing = W16_CLOSING + W31_CLOSING

    return f"""
            <h2>{d['title']}</h2>
            <p>Example: {d['example']}.</p>
            {lead}
            {shot(d['title'])}
            {W31_DEEP[slug]}
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
        "    /// <summary>Wave 31 — PDF security authority batch + glossary batch 8.</summary>",
        "    internal static class GuideBodiesWave31",
        "    {",
        "        public static string? Get(string slug) => slug switch",
        "        {",
    ]
    for slug in W31_SLUGS:
        lines.append(f'            "{slug}" => {const_name(slug)},')
    lines.append("            _ => null")
    lines.append("        };")
    lines.append("")

    for slug in W31_SLUGS:
        content = body(slug).lstrip("\n").rstrip()
        lines += [f"        private const string {const_name(slug)} = \"\"\"", content, "            \"\"\";", ""]

    lines += ["    }", "}"]
    OUT.write_text("\n".join(lines) + "\n", encoding="utf-8")
    print(f"Wrote {OUT} ({len(W31_SLUGS)} guides)")


if __name__ == "__main__":
    main()
