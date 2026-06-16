#!/usr/bin/env python3
"""Generate GuideBodiesWave11.cs — Security & compliance cluster (17 pages, 1500+ words)."""
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
from wave11_expansions import (
    PILLAR_SLUGS,
    W11_1500_TOPUP,
    W11_CLUSTER,
    W11_CLOSING,
    W11_DATA,
    W11_DEEP,
    W11_MEGA,
    W11_SLUG_EXTRA,
    W11_SLUGS,
)

OUT = Path(__file__).resolve().parents[1] / "Content" / "GuideBodiesWave11.cs"


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


def cluster_long(tool: str, focus: str) -> str:
    return f"""
            <h2>Workflow deep dive — {focus}</h2>
            <p>Security controls require verification — never assume overlay redaction or watermark equals protection.</p>
            {shot(focus)}
            <h2>Policy</h2>
            <p>Document approver and lawful basis before external send — especially GDPR DSAR and HIPAA PHI.</p>
            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Open tool</strong> <a href="{tool}" class="alert-link fw-semibold">Go →</a></div>
            """


def body(slug: str) -> str:
    d = W11_DATA[slug]
    pillar_note = (
        '<p>Pillar hub: <a href="/guides/secure-pdf-workflow">secure PDF workflow</a> · '
        '<a href="/guides/pdf-security-compliance-guide">compliance hub</a>.</p>'
        if slug in PILLAR_SLUGS
        else ""
    )
    return f"""
            <h2>{d['title']}</h2>
            <p>RatPDF <a href="{d['tool']}">{d['label']}</a> — {d['example']}.</p>
            {shot(d['title'])}
            {W11_DEEP[slug]}
            {W11_SLUG_EXTRA[slug]}
            {mid_cta(d['tool'], d['label'], 'Apply control')}
            {W11_MEGA}
            {COMPLIANCE_MEGA}
            {COMPLIANCE_UNIVERSAL}
            {cluster_long(d['tool'], d['title'])}
            {pillar_note}
            {SHARED_MEGA}
            {SHARED_PILLAR}
            {W6_SHARED_MEGA}
            {W6_1500}
            {W6_1500_EXTENDED}
            {W11_1500_TOPUP}
            {W6_LINE_COUNT_FIX}
            {COMPLIANCE_CLUSTER_LINKS}
            {W11_CLUSTER}
            {COMPLIANCE_FINAL_BOOST}
            {PDF_CLUSTER_PREMIUM}
            {PDF_PAGE_PREMIUM}
            {PDF_FINAL_BOOST}
            {W5_1500_TOPUP}
            {W11_CLOSING}
            {W6_CLOSING}
            {W5_CLOSING}
            {end_cta(d['tool'], d['label'], '<a href="/guides/pdf-security-compliance-guide">Compliance hub</a>')}
            """


def main():
    lines = [
        "namespace ratpdf.Content",
        "{",
        "    /// <summary>Wave 11 — Security & compliance (redaction, GDPR, HIPAA, WCAG, password).</summary>",
        "    internal static class GuideBodiesWave11",
        "    {",
        "        public static string? Get(string slug) => slug switch",
        "        {",
    ]
    for slug in W11_SLUGS:
        lines.append(f'            "{slug}" => {const_name(slug)},')
    lines.append("            _ => null")
    lines.append("        };")
    lines.append("")

    for slug in W11_SLUGS:
        content = body(slug).lstrip("\n").rstrip()
        lines += [f"        private const string {const_name(slug)} = \"\"\"", content, "            \"\"\";", ""]

    lines += ["    }", "}"]
    OUT.write_text("\n".join(lines) + "\n", encoding="utf-8")
    print(f"Wrote {OUT} ({len(W11_SLUGS)} guides)")


if __name__ == "__main__":
    main()
