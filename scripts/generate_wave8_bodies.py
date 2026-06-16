#!/usr/bin/env python3
"""Generate GuideBodiesWave8.cs — Edit-gap cluster (17 pages, 1500+ words)."""
from pathlib import Path

from wave1_expansions import PDF_CLUSTER_PREMIUM, PDF_FINAL_BOOST, PDF_PAGE_PREMIUM
from wave5_expansions import W5_1500_TOPUP, W5_CLOSING
from wave6_expansions import (
    EDIT_1500_FINAL,
    EDIT_1500_TOPUP,
    EDIT_CLUSTER,
    EDIT_FINAL,
    EDIT_MEGA,
    EDIT_UNIVERSAL,
    SHARED_MEGA,
    W6_1500,
    W6_1500_EXTENDED,
    W6_CLOSING,
    W6_LINE_COUNT_FIX,
    W6_SHARED_MEGA,
)
from wave8_expansions import (
    W8_1500_TOPUP,
    W8_CLUSTER,
    W8_CLOSING,
    W8_DATA,
    W8_DEEP,
    W8_MEGA,
    W8_PILLAR_TOPUP,
    W8_SLUG_EXTRA,
    W8_SLUGS,
)

OUT = Path(__file__).resolve().parents[1] / "Content" / "GuideBodiesWave8.cs"

PILLAR_SLUGS = {"edit-pdf", "rotate-pdf", "edit-pdf-without-acrobat"}


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
            <p>Browser workflow — no install — upload → process → download → verify in viewer before external send.</p>
            {shot(focus)}
            <h2>Mobile</h2>
            <p>Safari/Chrome on phone works — Wi-Fi for files over 15 MB — save to Files before portal upload.</p>
            <h2>Failures</h2>
            <p>Timeout: retry Wi-Fi · corrupt PDF: re-export source · password: <a href="/guides/unlock-pdf">unlock</a>.</p>
            <h2>Free tier</h2>
            <p>Three uses/day — <a href="/Subscription/Plans">plans</a> for volume.</p>
            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Open tool</strong> <a href="{tool}" class="alert-link fw-semibold">Go →</a></div>
            """


def body(slug: str) -> str:
    d = W8_DATA[slug]
    pillar_extra = W8_PILLAR_TOPUP if slug in PILLAR_SLUGS else ""
    return f"""
            <h2>{d['title']}</h2>
            <p>RatPDF <a href="{d['tool']}">{d['label']}</a> — {d['example']}.</p>
            {shot(d['title'])}
            {W8_DEEP[slug]}
            {W8_SLUG_EXTRA[slug]}
            {mid_cta(d['tool'], d['label'], 'Start now')}
            {EDIT_MEGA}
            {EDIT_UNIVERSAL}
            {W8_MEGA}
            {cluster_long(d['tool'], d['title'])}
            {EDIT_FINAL}
            {pillar_extra}
            {SHARED_MEGA}
            {W6_SHARED_MEGA}
            {W6_1500}
            {W6_1500_EXTENDED}
            {EDIT_1500_TOPUP}
            {W8_1500_TOPUP}
            {W6_LINE_COUNT_FIX}
            {EDIT_1500_FINAL}
            {EDIT_CLUSTER}
            {W8_CLUSTER}
            {PDF_CLUSTER_PREMIUM}
            {PDF_PAGE_PREMIUM}
            {PDF_FINAL_BOOST}
            {W5_1500_TOPUP}
            {W8_CLOSING}
            {W6_CLOSING}
            {W5_CLOSING}
            {end_cta(d['tool'], d['label'], '<a href="/guides/edit-pdf">Edit PDF hub</a>')}
            """


def main():
    lines = [
        "namespace ratpdf.Content",
        "{",
        "    /// <summary>Wave 8 — Edit-gap cluster (crop, delete, annotate, device, pillar upgrades).</summary>",
        "    internal static class GuideBodiesWave8",
        "    {",
        "        public static string? Get(string slug) => slug switch",
        "        {",
    ]
    for slug in W8_SLUGS:
        lines.append(f'            "{slug}" => {const_name(slug)},')
    lines.append("            _ => null")
    lines.append("        };")
    lines.append("")

    for slug in W8_SLUGS:
        content = body(slug).lstrip("\n").rstrip()
        lines += [f"        private const string {const_name(slug)} = \"\"\"", content, "            \"\"\";", ""]

    lines += ["    }", "}"]
    OUT.write_text("\n".join(lines) + "\n", encoding="utf-8")
    print(f"Wrote {OUT} ({len(W8_SLUGS)} guides)")


if __name__ == "__main__":
    main()
