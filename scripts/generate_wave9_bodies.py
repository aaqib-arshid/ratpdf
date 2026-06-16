#!/usr/bin/env python3
"""Generate GuideBodiesWave9.cs — Troubleshooting cluster (17 pages, 1500+ words)."""
from pathlib import Path

from wave1_expansions import PDF_CLUSTER_PREMIUM, PDF_FINAL_BOOST, PDF_PAGE_PREMIUM
from wave3_expansions import COMPRESS_UNIVERSAL, COMPRESS_FINAL_BOOST, COMPRESS_MEGA
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
from wave9_expansions import (
    W9_1500_TOPUP,
    W9_CLUSTER,
    W9_CLOSING,
    W9_DATA,
    W9_DEEP,
    W9_MEGA,
    W9_SLUG_EXTRA,
    W9_SLUGS,
)

OUT = Path(__file__).resolve().parents[1] / "Content" / "GuideBodiesWave9.cs"


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
            <p>Diagnose before tool chain — wrong fix wastes time and can damage evidence files.</p>
            {shot(focus)}
            <h2>Escalation</h2>
            <p>Re-source from author beats endless repair — document attempts in ticket.</p>
            <h2>Privacy</h2>
            <p>Confidential PDFs — review <a href="/home/privacy">privacy policy</a> before upload.</p>
            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Next step</strong> <a href="{tool}" class="alert-link fw-semibold">Go →</a></div>
            """


def body(slug: str) -> str:
    d = W9_DATA[slug]
    compress_extra = ""
    if "compress" in d["tool"] or slug in (
        "pdf-file-corrupted",
        "repair-pdf-online",
        "corrupted-pdf-repair",
        "pdf-file-too-large-to-email",
        "pdf-attachment-blocked",
        "pdf-upload-failed-portal",
    ):
        compress_extra = COMPRESS_MEGA + COMPRESS_UNIVERSAL + COMPRESS_FINAL_BOOST
    return f"""
            <h2>{d['title']}</h2>
            <p>{d['example']} — practical fixes with RatPDF tools where they apply.</p>
            {shot(d['title'])}
            {W9_DEEP[slug]}
            {W9_SLUG_EXTRA[slug]}
            {mid_cta(d['tool'], d['label'], 'Try fix')}
            {W9_MEGA}
            {cluster_long(d['tool'], d['title'])}
            {compress_extra}
            {SHARED_MEGA}
            {SHARED_PILLAR}
            {W6_SHARED_MEGA}
            {W6_1500}
            {W6_1500_EXTENDED}
            {W9_1500_TOPUP}
            {W6_LINE_COUNT_FIX}
            {W9_CLUSTER}
            {PDF_CLUSTER_PREMIUM}
            {PDF_PAGE_PREMIUM}
            {PDF_FINAL_BOOST}
            {W5_1500_TOPUP}
            {W9_CLOSING}
            {W6_CLOSING}
            {W5_CLOSING}
            {end_cta(d['tool'], d['label'], '<a href="/guides/pdf-troubleshooting">Troubleshooting hub</a>')}
            """


def main():
    lines = [
        "namespace ratpdf.Content",
        "{",
        "    /// <summary>Wave 9 — PDF Troubleshooting hub (won't open, corrupt, print, portal).</summary>",
        "    internal static class GuideBodiesWave9",
        "    {",
        "        public static string? Get(string slug) => slug switch",
        "        {",
    ]
    for slug in W9_SLUGS:
        lines.append(f'            "{slug}" => {const_name(slug)},')
    lines.append("            _ => null")
    lines.append("        };")
    lines.append("")

    for slug in W9_SLUGS:
        content = body(slug).lstrip("\n").rstrip()
        lines += [f"        private const string {const_name(slug)} = \"\"\"", content, "            \"\"\";", ""]

    lines += ["    }", "}"]
    OUT.write_text("\n".join(lines) + "\n", encoding="utf-8")
    print(f"Wrote {OUT} ({len(W9_SLUGS)} guides)")


if __name__ == "__main__":
    main()
