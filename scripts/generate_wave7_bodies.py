#!/usr/bin/env python3
"""Generate GuideBodiesWave7.cs — 5 pillar authority upgrades (2500+ words)."""
from pathlib import Path

from wave1_expansions import PDF_CLUSTER_PREMIUM, PDF_FINAL_BOOST, PDF_PAGE_PREMIUM
from wave2_expansions import (
    MERGE_1500_TOPUP,
    MERGE_CLUSTER_LINKS,
    MERGE_FINAL_BOOST,
    MERGE_LONG_TAIL,
    MERGE_MEGA,
    MERGE_PREMIUM,
    OCR_1500_TOPUP,
    OCR_CLUSTER_LINKS,
    OCR_FINAL_BOOST,
    OCR_LONG_TAIL,
    OCR_MEGA,
    OCR_PREMIUM,
)
from wave3_expansions import (
    COMPRESS_1500_TOPUP,
    COMPRESS_CLUSTER_LINKS,
    COMPRESS_FINAL_BOOST,
    COMPRESS_LONG_TAIL,
    COMPRESS_MEGA,
    COMPRESS_PREMIUM,
    COMPRESS_UNIVERSAL,
)
from wave4_expansions import PDF_WORD_CLUSTER_LINKS, PDF_WORD_LONG_TAIL, PDF_WORD_MEGA
from wave5_expansions import (
    SPLIT_1500_TOPUP,
    SPLIT_FINAL,
    SPLIT_W5_CLUSTER,
    SPLIT_W5_DEEP,
    SPLIT_W5_MEGA,
    SPLIT_UNIVERSAL,
    TEXT_W5_MEGA,
    W5_1500_TOPUP,
    W5_CLOSING,
)
from wave6_expansions import W6_LINE_COUNT_FIX, W6_SHARED_MEGA
from wave7_expansions import (
    PILLAR_DEEP,
    PILLAR_FINAL,
    PILLAR_META,
    PILLAR_SLUGS,
    PILLAR_FINAL,
    PILLAR_SUPPLEMENT,
    SHARED_PILLAR,
    W7_2500_TOPUP,
    W7_AUTHORITY,
)

OUT = Path(__file__).resolve().parents[1] / "Content" / "GuideBodiesWave7.cs"

EXTRA = {
    "compress-pdf-guide": (
        COMPRESS_MEGA + COMPRESS_UNIVERSAL + COMPRESS_LONG_TAIL
        + COMPRESS_PREMIUM + COMPRESS_1500_TOPUP + COMPRESS_FINAL_BOOST
        + COMPRESS_CLUSTER_LINKS
    ),
    "merge-pdf": (
        MERGE_MEGA + MERGE_PREMIUM + MERGE_LONG_TAIL
        + MERGE_CLUSTER_LINKS + MERGE_FINAL_BOOST + MERGE_1500_TOPUP
    ),
    "split-pdf": (
        SPLIT_W5_MEGA + SPLIT_UNIVERSAL + SPLIT_W5_DEEP
        + SPLIT_1500_TOPUP + SPLIT_FINAL + SPLIT_W5_CLUSTER
    ),
    "pdf-to-word": (
        PDF_WORD_MEGA + PDF_WORD_LONG_TAIL + PDF_CLUSTER_PREMIUM
        + PDF_PAGE_PREMIUM + PDF_FINAL_BOOST + PDF_WORD_CLUSTER_LINKS
    ),
    "ocr-pdf": (
        OCR_MEGA.format(name="general", script="Latin")
        + OCR_PREMIUM + OCR_LONG_TAIL + OCR_CLUSTER_LINKS
        + OCR_FINAL_BOOST + OCR_1500_TOPUP + TEXT_W5_MEGA
    ),
}


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
    m = PILLAR_META[slug]
    cross = ""
    if slug == "compress-pdf-guide":
        cross = '<p>Hub: <a href="/compress-pdf">Compress PDF landing</a> · Index of compression guides.</p>'
    elif slug == "merge-pdf":
        cross = '<p>After merge: <a href="/guides/compress-pdf-guide">compress guide</a> · <a href="/guides/split-pdf">split guide</a>.</p>'
    elif slug == "split-pdf":
        cross = '<p>Before split: <a href="/guides/compress-pdf-guide">try compress</a> · After: <a href="/guides/merge-pdf">merge guide</a>.</p>'
    elif slug == "pdf-to-word":
        cross = '<p>OCR path: <a href="/guides/ocr-pdf">OCR guide</a> · Export back: <a href="/guides/word-to-pdf">Word to PDF</a>.</p>'
    elif slug == "ocr-pdf":
        cross = '<p>Then: <a href="/guides/pdf-to-word">PDF to Word guide</a> · <a href="/guides/pdf-txt-guide">PDF to Text</a>.</p>'
    return f"""
            <h2>{m['title']}</h2>
            <p>Authoritative guide for <strong>{m['label']}</strong> in your browser — no Adobe install. Updated 2026.</p>
            {shot(m['title'])}
            {PILLAR_DEEP[slug]}
            {mid_cta(m['tool'], m['label'], f'Open {m["label"]} tool')}
            {EXTRA[slug]}
            {PILLAR_SUPPLEMENT[slug]}
            {PILLAR_FINAL[slug]}
            {W7_AUTHORITY[slug]}
            {SHARED_PILLAR}
            {cross}
            {W7_2500_TOPUP}
            {W6_SHARED_MEGA}
            {W5_1500_TOPUP}
            {W6_LINE_COUNT_FIX}
            {W5_CLOSING}
            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Start now</strong> <a href="{m['tool']}" class="alert-link fw-semibold">{m['label']} →</a></div>
            {end_cta(m['tool'], m['label'], '<a href="/compare">Compare PDF tools</a>')}
            """


def main():
    lines = [
        "namespace ratpdf.Content",
        "{",
        "    /// <summary>Wave 7 — Pillar authority upgrades (compress, merge, split, pdf-to-word, ocr).</summary>",
        "    internal static class GuideBodiesWave7",
        "    {",
        "        public static string? Get(string slug) => slug switch",
        "        {",
    ]
    for slug in PILLAR_SLUGS:
        lines.append(f'            "{slug}" => {const_name(slug)},')
    lines.append("            _ => null")
    lines.append("        };")
    lines.append("")

    for slug in PILLAR_SLUGS:
        content = body(slug).lstrip("\n").rstrip()
        lines += [f"        private const string {const_name(slug)} = \"\"\"", content, "            \"\"\";", ""]

    lines += ["    }", "}"]
    OUT.write_text("\n".join(lines) + "\n", encoding="utf-8")
    print(f"Wrote {OUT} ({len(PILLAR_SLUGS)} pillars)")


if __name__ == "__main__":
    main()
