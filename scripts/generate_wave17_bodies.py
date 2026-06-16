#!/usr/bin/env python3
"""Generate GuideBodiesWave17.cs — Compare alternatives + merge/batch/compliance upgrades."""
from pathlib import Path

from wave1_expansions import PDF_CLUSTER_PREMIUM, PDF_FINAL_BOOST, PDF_PAGE_PREMIUM
from wave3_expansions import (
    COMPLIANCE_CLUSTER_LINKS,
    COMPLIANCE_FINAL_BOOST,
    COMPLIANCE_MEGA,
    COMPLIANCE_UNIVERSAL,
)
from wave4_expansions import PDF_WORD_CLUSTER_LINKS, PDF_WORD_MEGA
from wave5_expansions import W5_1500_TOPUP, W5_CLOSING
from wave6_expansions import (
    COMPARE_1500_FINAL,
    COMPARE_DEEP,
    COMPARE_FINAL,
    COMPARE_MEGA,
    COMPARE_SMB,
    SHARED_MEGA,
    W6_1500,
    W6_1500_EXTENDED,
    W6_CLOSING,
    W6_LINE_COUNT_FIX,
    W6_SHARED_MEGA,
)
from wave7_expansions import SHARED_PILLAR
from wave12_expansions import W12_1500_TOPUP, W12_CLUSTER, W12_MEGA
from wave16_expansions import W16_1500_TOPUP, W16_CLOSING
from wave17_expansions import (
    W17_ALT_CLUSTER,
    W17_DATA,
    W17_DEEP,
    W17_MERGE_CLUSTER,
    W17_SLUGS,
)

OUT = Path(__file__).resolve().parents[1] / "Content" / "GuideBodiesWave17.cs"


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
    d = W17_DATA[slug]
    compare_link = (
        f'<p class="lead">Feature comparison table: '
        f'<a href="{d["compare"]}">{d["compare"]}</a> · '
        f'Hub: <a href="{d["pillar"]}">{d["pillar_label"]}</a>.</p>'
    )
    cluster = W17_ALT_CLUSTER if slug.endswith("-alternative") else W17_MERGE_CLUSTER
    if slug in ("batch-pdf-to-word",):
        cluster = PDF_WORD_CLUSTER_LINKS
    if slug == "email-attachment-size-limits-2026":
        cluster = COMPLIANCE_CLUSTER_LINKS
    return f"""
            <h2>{d['title']}</h2>
            <p>Example: {d['example']}.</p>
            {compare_link}
            {shot(d['title'])}
            {W17_DEEP[slug]}
            {mid_cta(d['tool'], d['label'], 'Open the primary tool')}
            {COMPARE_MEGA}
            {COMPARE_DEEP}
            {COMPARE_SMB}
            {PDF_WORD_MEGA}
            {COMPLIANCE_MEGA}
            {COMPLIANCE_UNIVERSAL}
            {SHARED_MEGA}
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
            {COMPARE_1500_FINAL}
            {COMPARE_FINAL}
            {COMPLIANCE_FINAL_BOOST}
            {PDF_CLUSTER_PREMIUM}
            {PDF_PAGE_PREMIUM}
            {PDF_FINAL_BOOST}
            {W5_1500_TOPUP}
            {W16_CLOSING}
            {W6_CLOSING}
            {W5_CLOSING}
            {end_cta(d['tool'], d['label'], f'<a href="{d["pillar"]}">Pillar guide</a> · <a href="{d["compare"]}">Compare</a>')}
            """


def main() -> None:
    lines = [
        "namespace ratpdf.Content",
        "{",
        "    /// <summary>Wave 17 — Compare alternative guides + merge/batch/compliance upgrades.</summary>",
        "    internal static class GuideBodiesWave17",
        "    {",
        "        public static string? Get(string slug) => slug switch",
        "        {",
    ]
    for slug in W17_SLUGS:
        lines.append(f'            "{slug}" => {const_name(slug)},')
    lines.append("            _ => null")
    lines.append("        };")
    lines.append("")

    for slug in W17_SLUGS:
        content = body(slug).lstrip("\n").rstrip()
        lines += [f"        private const string {const_name(slug)} = \"\"\"", content, "            \"\"\";", ""]

    lines += ["    }", "}"]
    OUT.write_text("\n".join(lines) + "\n", encoding="utf-8")
    print(f"Wrote {OUT} ({len(W17_SLUGS)} guides)")


if __name__ == "__main__":
    main()
