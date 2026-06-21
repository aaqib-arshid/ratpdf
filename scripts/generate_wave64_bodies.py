#!/usr/bin/env python3
"""Generate GuideBodiesWave64.cs — Glossary batch 2 + hand_core pillar upgrades."""
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
from wave12_expansions import W12_1500_TOPUP, W12_CLUSTER, W12_MEGA
from wave16_expansions import W16_1500_TOPUP, W16_GLOSSARY_CLUSTER, W16_MEGA
from wave64_expansions import (
    W64_CLOSING,
    W64_DATA,
    W64_GLOSSARY_DEEP,
    W64_HAND_CORE_CLUSTER,
    W64_HAND_CORE_DEEP,
    W64_INVOICE_GLOSSARY_CLUSTER,
    W64_SLUGS,
)

OUT = Path(__file__).resolve().parents[1] / "Content" / "GuideBodiesWave64.cs"


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


def deep_for(slug: str) -> str:
    if slug in W64_GLOSSARY_DEEP:
        return W64_GLOSSARY_DEEP[slug]
    return W64_HAND_CORE_DEEP[slug]


def cluster_for(slug: str) -> str:
    if W64_DATA[slug]["kind"] == "glossary":
        return W64_INVOICE_GLOSSARY_CLUSTER + W16_GLOSSARY_CLUSTER
    return W64_HAND_CORE_CLUSTER


def body(slug: str) -> str:
    d = W64_DATA[slug]
    pillar_link = (
        f'<p class="lead">Main workflow guide: '
        f'<a href="{d["pillar"]}">{d["pillar_label"]}</a>.</p>'
    )
    return f"""
            <h2>{d['title']}</h2>
            <p>Example: {d['example']}.</p>
            {pillar_link}
            {shot(d['title'])}
            {deep_for(slug)}
            {mid_cta(d['tool'], d['label'], 'Try the related tool')}
            {W16_MEGA}
            {W12_MEGA}
            {COMPLIANCE_MEGA}
            {COMPLIANCE_UNIVERSAL}
            {SHARED_MEGA}
            {SHARED_PILLAR}
            {W6_SHARED_MEGA}
            {W6_1500}
            {W6_1500_EXTENDED}
            {W16_1500_TOPUP}
            {W12_1500_TOPUP}
            {W6_LINE_COUNT_FIX}
            {COMPLIANCE_CLUSTER_LINKS}
            {cluster_for(slug)}
            {W12_CLUSTER}
            {COMPLIANCE_FINAL_BOOST}
            {PDF_CLUSTER_PREMIUM}
            {PDF_PAGE_PREMIUM}
            {PDF_FINAL_BOOST}
            {W5_1500_TOPUP}
            {W64_CLOSING}
            {W6_CLOSING}
            {W5_CLOSING}
            {end_cta(d['tool'], d['label'], f'<a href="{d["pillar"]}">Full guide</a>')}
            """


def main() -> None:
    lines = [
        "namespace ratpdf.Content",
        "{",
        "    /// <summary>Wave 64 — Glossary batch 2 (invoice/payslip) + hand_core pillar upgrades.</summary>",
        "    internal static class GuideBodiesWave64",
        "    {",
        "        public static string? Get(string slug) => slug switch",
        "        {",
    ]
    for slug in W64_SLUGS:
        lines.append(f'            "{slug}" => {const_name(slug)},')
    lines.append("            _ => null")
    lines.append("        };")
    lines.append("")

    for slug in W64_SLUGS:
        content = body(slug).lstrip("\n").rstrip()
        lines += [f"        private const string {const_name(slug)} = \"\"\"", content, "            \"\"\";", ""]

    lines += ["    }", "}"]
    OUT.write_text("\n".join(lines) + "\n", encoding="utf-8")
    print(f"Wrote {OUT} ({len(W64_SLUGS)} guides: 9 glossary + 15 hand_core)")


if __name__ == "__main__":
    main()
