#!/usr/bin/env python3
"""Generate GuideBodiesWave5.cs — Compress platform, PDF to Text, Split (no new URLs)."""
from pathlib import Path

from wave3_expansions import (
    COMPRESS_MEGA, COMPRESS_UNIVERSAL, COMPRESS_FINAL_BOOST,
    COMPRESS_1500_TOPUP, COMPRESS_PREMIUM,
)
from wave5_expansions import (
    COMPRESS_PLATFORM_DATA,
    COMPRESS_PLATFORM_DEEP,
    COMPRESS_PORTAL_DATA,
    COMPRESS_PORTAL_DEEP,
    COMPRESS_SPECIAL,
    COMPRESS_W5_CLUSTER,
    COMPRESS_W5_LONG,
    SPLIT_DATA,
    SPLIT_DEEP,
    SPLIT_W5_CLUSTER,
    SPLIT_W5_MEGA,
    TEXT_DATA,
    TEXT_DEEP,
    TEXT_W5_CLUSTER,
    TEXT_W5_MEGA,
    TEXT_UNIVERSAL,
    TEXT_W5_DEEP,
    TEXT_1500_TOPUP,
    TEXT_SLUG_EXTRA,
    TEXT_FINAL,
    SPLIT_W5_MEGA,
    SPLIT_UNIVERSAL,
    SPLIT_W5_DEEP,
    SPLIT_1500_TOPUP,
    SPLIT_SLUG_EXTRA,
    SPLIT_FINAL,
    COMPRESS_W5_EXTRA,
    COMPRESS_W5_MORE,
    W5_1500_TOPUP,
    W5_CLOSING,
    W5_FINAL,
    W5_SHARED_MEGA,
)

OUT = Path(__file__).resolve().parents[1] / "Content" / "GuideBodiesWave5.cs"

PLATFORM_SLUGS = list(COMPRESS_PLATFORM_DATA.keys())
PORTAL_SLUGS = list(COMPRESS_PORTAL_DATA.keys())
COMPRESS_SLUGS = ["compress-pdf-made-it-larger", "batch-compress-pdf", "combine-then-compress-pdf"]
TEXT_SLUGS = list(TEXT_DATA.keys())
SPLIT_SLUGS = list(SPLIT_DATA.keys())
SLUGS = PLATFORM_SLUGS + PORTAL_SLUGS + COMPRESS_SLUGS + TEXT_SLUGS + SPLIT_SLUGS


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


def compress_supplement() -> str:
    return """
            <h2>Compression levels</h2>
            <p><strong>Less:</strong> signatures and stamps. <strong>Recommended:</strong> default. <strong>Extreme:</strong> last resort — verify legibility.</p>
            <h2>Pre-upload checklist</h2>
            <ol>
            <li><a href="/pdf-size-checker">PDF size checker</a> preset</li>
            <li>Rotate scans upright</li>
            <li>One compress pass after merge</li>
            <li>Keep master until upload succeeds</li>
            </ol>
            <h2>Email variants</h2>
            <p><a href="/guides/compress-pdf-for-gmail">Gmail</a> · <a href="/guides/compress-pdf-for-outlook">Outlook</a> · <a href="/guides/compress-pdf-for-whatsapp">WhatsApp</a>.</p>
            <h2>Immigration cross-links</h2>
            <p><a href="/guides/compress-pdf-for-visa-application">Visa application</a> · <a href="/guides/compress-pdf-schengen-visa">Schengen</a> · <a href="/guides/compress-pdf-digilocker">DigiLocker</a>.</p>
            <h2>Industry guides</h2>
            <p><a href="/guides/compress-pdf-lawyers">Lawyers</a> · <a href="/guides/compress-pdf-accountants">Accountants</a> · <a href="/guides/compress-pdf-efiling">E-filing</a>.</p>
            """


def text_supplement() -> str:
    return """
            <h2>OCR branch</h2>
            <p>Image-only PDF → <a href="/pdf/ocrpdf">OCR PDF</a> → <a href="/pdf/pdftotext">PDF to Text</a>. Decision: <a href="/guides/ocr-vs-pdf-to-text">OCR vs Text</a>.</p>
            <h2>Word vs Text</h2>
            <p>Need layout edit → <a href="/guides/pdf-to-word-vs-pdf-to-text">PDF to Word vs Text</a> · <a href="/pdf/pdftodoc">PDF to Word</a>.</p>
            <h2>Output hygiene</h2>
            <p>UTF-8 .txt — grep-friendly — delete files with PII after task. Do not email plain text bank exports unencrypted.</p>
            <h2>Developer note</h2>
            <p>Pipe .txt into Python, R, or LLM ingest — structure lost vs HTML table export — pick tool to downstream need.</p>
            """


def split_supplement() -> str:
    return """
            <h2>Merge after split?</h2>
            <p>Recipient can <a href="/guides/merge-pdf-online">merge PDF</a> parts locally — include page range in email body.</p>
            <h2>Compress before split?</h2>
            <p>Try <a href="/pdf/compress">Compress PDF</a> first — split only when quality cannot drop further.</p>
            <h2>Page range planning</h2>
            <p>Split at chapter boundaries not arbitrary page 50 — readers navigate parts logically.</p>
            <h2>Watermark and split</h2>
            <p>Draft watermarks on full PDF carry to each part — acceptable for internal review splits — remove watermark before external production.</p>
            <h2>Password on output</h2>
            <p>Password-protect each part if confidential — communicate password out-of-band not same email thread.</p>
            """


def compress_long_w5(focus: str) -> str:
    return f"""
            <h2>Operational deep dive — {focus}</h2>
            <p>Ghostscript compression re-encodes embedded images while vector text usually stays sharp. Phone photos and 600 DPI scans dominate file size — scan at 200–300 DPI grayscale for text proofs before compress saves more than Extreme on blurry source.</p>
            {shot(f"Compress PDF workflow — {focus}")}
            <h2>Double compression trap</h2>
            <p>Compress → merge → compress again softens text twice — <a href="/guides/compress-before-merge-pdf">merge/compress order guide</a>.</p>
            <h2>Portal rejection decode</h2>
            <p><strong>Too large:</strong> compress or <a href="/guides/split-pdf-for-email">split</a>. <strong>Unreadable:</strong> re-scan. <strong>Password:</strong> <a href="/guides/unlock-pdf">unlock</a> first.</p>
            <h2>Research</h2>
            <p><a href="/research/pdf-compression-benchmark">PDF compression benchmark</a> · <a href="/research/attachment-size-limits">Attachment size limits</a>.</p>
            <h2>Free tier</h2>
            <p>Three uses/day — high volume <a href="/Subscription/Plans">plans</a>.</p>
            <h2>Related compression guides</h2>
            <p>Portal compress: <a href="/guides/compress-pdf-gst-portal">GST portal</a> · <a href="/guides/compress-pdf-schengen-visa">Schengen</a> · <a href="/guides/compress-pdf-for-government-forms">government forms</a>.</p>
            <h2>Related Word conversion guides</h2>
            <p>After Word edit re-export: <a href="/guides/pdf-to-word-keep-formatting">keep formatting</a> — then compress for email.</p>
            """


def text_long_w5(focus: str) -> str:
    return f"""
            <h2>Text extraction pipeline — {focus}</h2>
            <p>Digital PDF exports text from embedded character maps. Scanned PDFs need OCR text layer first — export then pulls OCR text, not pixels.</p>
            {shot(f"PDF to Text export — {focus}")}
            <h2>Real workflow: grep across corpus</h2>
            <p>100 discovery PDFs → batch OCR → PDF to Text each → ripgrep privilege keyword — faster than opening each in viewer.</p>
            <h2>Second example: meta-analysis</h2>
            <p>40 journal PDFs — export abstracts to .txt — sort in spreadsheet by keyword frequency — cite from original PDF page after spot-check.</p>
            <h2>Limits</h2>
            <p>Multi-column newspaper PDF may jumble column order in .txt — manual cleanup or Word for layout-sensitive review.</p>
            <h2>Footnotes and headers</h2>
            <p>Footnotes may appear mid-paragraph in export — academic workflow keeps PDF open for page proof while .txt is note scratchpad.</p>
            <h2>Security</h2>
            <p>Transient processing — clear Downloads on shared PC — legal privilege applies to .txt same as source PDF.</p>
            <h2>Compare</h2>
            <p><a href="/compare/adobe-alternative">Adobe alternative</a> · <a href="/compare/smallpdf-alternative">Smallpdf</a> — evaluate privacy before uploading privileged PDFs.</p>
            <h2>Pillar links</h2>
            <p><a href="/guides/pdf-to-text">PDF to Text hub</a> · <a href="/guides/pdf-to-word-vs-pdf-to-text">Word vs Text</a> · <a href="/guides/ocr-vs-pdf-to-text">OCR vs Text</a>.</p>
            """


def split_long_w5(focus: str) -> str:
    return f"""
            <h2>Split workflow deep dive — {focus}</h2>
            <p>Splitting preserves per-page quality — unlike Extreme compress on legal scans. Trade-off: recipient manages multiple files.</p>
            {shot(f"Split PDF — {focus}")}
            <h2>Compress vs split decision</h2>
            <p>Try Recommended compress first — if footnotes blur at 150% zoom, revert to original and split instead.</p>
            <h2>Second example: board pack email</h2>
            <p>90 MB board PDF — compress blurs charts — split into Part 1 narrative Part 2 financials — both under 20 MB.</p>
            <h2>Password protected sources</h2>
            <p>Unlock before split — <a href="/guides/unlock-pdf">Unlock PDF</a> — encrypted files fail split queue.</p>
            <h2>Hyperlinks after split</h2>
            <p>Internal links breaking across parts — note in email "bookmarks in Part 1 only" — recipient opens full set.</p>
            <h2>Free tier</h2>
            <p>Three splits per day — board season needs <a href="/Subscription/Plans">plans</a>.</p>
            """


def body_platform(slug: str) -> str:
    d = COMPRESS_PLATFORM_DATA[slug]
    return f"""
            <h2>{d['title']}</h2>
            <p>Compress oversized PDFs on {d['device']} using {d['browser']} — no App Store or desktop install. RatPDF <a href="/pdf/compress">Compress PDF</a> runs in your mobile or desktop browser.</p>
            {shot(f"{d['device']} browser on RatPDF compress upload")}
            <h2>Real example: {d['example']}</h2>
            <ol>
            <li>Open RatPDF Compress PDF in {d['browser']}.</li>
            <li>Upload PDF from Files/Downloads.</li>
            <li>Choose Recommended — download smaller file.</li>
            <li>Attach to email or portal — verify opens correctly.</li>
            </ol>
            {COMPRESS_PLATFORM_DEEP[slug]}
            {mid_cta('/pdf/compress', 'Compress PDF', f'Compress on {d["device"]}')}
            {compress_supplement()}
            {COMPRESS_W5_LONG}
            {COMPRESS_MEGA}
            {compress_long_w5(d['device'])}
            {COMPRESS_UNIVERSAL}
            {COMPRESS_FINAL_BOOST}
            {COMPRESS_1500_TOPUP}
            {COMPRESS_PREMIUM}
            {W5_1500_TOPUP}
            {COMPRESS_W5_EXTRA}
            {COMPRESS_W5_MORE}
            {W5_SHARED_MEGA}
            {COMPRESS_W5_CLUSTER}
            {W5_FINAL}
            {W5_CLOSING}
            {end_cta('/pdf/compress', 'Compress PDF free', '<a href="/compare/smallpdf-alternative">Compare</a>')}
            """


def body_portal(slug: str) -> str:
    d = COMPRESS_PORTAL_DATA[slug]
    return f"""
            <h2>{d['title']}</h2>
            <p>Shrink PDFs for <strong>{d['portal']}</strong> uploads — typical cap {d['cap']}. RatPDF <a href="/pdf/compress">Compress PDF</a> with Ghostscript.</p>
            {shot(f"{d['portal']} upload success after compress")}
            <h2>Real example: {d['example']}</h2>
            <ol>
            <li>Scan 200 DPI grayscale if source is phone photo.</li>
            <li>Recommended compress — verify IDs readable at zoom.</li>
            <li>Upload in portal session before timeout.</li>
            </ol>
            {COMPRESS_PORTAL_DEEP[slug]}
            {mid_cta('/pdf/compress', 'Compress PDF', f'Fit {d["portal"]} cap')}
            {compress_supplement()}
            {COMPRESS_W5_LONG}
            {COMPRESS_MEGA}
            {compress_long_w5(d['portal'])}
            {COMPRESS_UNIVERSAL}
            {COMPRESS_FINAL_BOOST}
            {COMPRESS_1500_TOPUP}
            {COMPRESS_PREMIUM}
            {W5_1500_TOPUP}
            {COMPRESS_W5_EXTRA}
            {COMPRESS_W5_MORE}
            {W5_SHARED_MEGA}
            {COMPRESS_W5_CLUSTER}
            {W5_FINAL}
            {W5_CLOSING}
            {end_cta('/pdf/compress', 'Compress PDF free', '<a href="/Subscription/Plans">Upgrade</a>')}
            """


def body_compress_special(slug: str) -> str:
    tool = "/pdf/merge" if slug == "combine-then-compress-pdf" else "/pdf/compress"
    label = "Merge PDF" if slug == "combine-then-compress-pdf" else "Compress PDF"
    titles = {
        "compress-pdf-made-it-larger": "Compress PDF made it larger — why size increased &amp; what to do",
        "batch-compress-pdf": "Batch compress PDF files — workflow for multiple documents",
        "combine-then-compress-pdf": "Combine PDF then compress — merge first, shrink once",
    }
    return f"""
            <h2>{titles[slug]}</h2>
            <p>Troubleshooting and batch workflow for compress cluster — avoid wasted passes and wrong tool order.</p>
            {shot(titles[slug])}
            {COMPRESS_SPECIAL[slug]}
            {mid_cta(tool, label, 'Open primary tool')}
            {compress_supplement()}
            {COMPRESS_W5_LONG}
            {COMPRESS_MEGA}
            {compress_long_w5(slug)}
            {COMPRESS_UNIVERSAL}
            {COMPRESS_FINAL_BOOST}
            {COMPRESS_1500_TOPUP}
            {COMPRESS_PREMIUM}
            {W5_1500_TOPUP}
            {COMPRESS_W5_EXTRA}
            {COMPRESS_W5_MORE}
            {W5_SHARED_MEGA}
            {COMPRESS_W5_CLUSTER}
            {W5_FINAL}
            {W5_CLOSING}
            {end_cta(tool, label, '<a href="/pdf/compress">Compress PDF</a>' if tool == '/pdf/merge' else '<a href="/guides/batch-compress-pdf">Batch guide</a>')}
            """


def body_text(slug: str) -> str:
    d = TEXT_DATA[slug]
    return f"""
            <h2>{d['title']}</h2>
            <p>Export plain text from PDF for {d['use']} — RatPDF <a href="/pdf/pdftotext">PDF to Text</a> in browser, no Adobe.</p>
            {shot(f"PDF to Text — {d['use']}")}
            <h2>Real example: {d['example']}</h2>
            <ol>
            <li>Test if PDF text selects — if not, OCR first.</li>
            <li>Upload to PDF to Text — download .txt.</li>
            <li>Grep, cite, or import to spreadsheet pipeline.</li>
            </ol>
            {TEXT_DEEP[slug]}
            {TEXT_SLUG_EXTRA[slug]}
            {mid_cta('/pdf/pdftotext', 'PDF to Text', 'Extract text now')}
            {text_supplement()}
            {TEXT_W5_MEGA}
            {text_long_w5(d['use'])}
            {TEXT_UNIVERSAL}
            {TEXT_W5_DEEP}
            {TEXT_1500_TOPUP}
            {TEXT_FINAL}
            {W5_1500_TOPUP}
            {COMPRESS_W5_EXTRA}
            {COMPRESS_W5_MORE}
            {W5_SHARED_MEGA}
            {TEXT_W5_CLUSTER}
            {W5_FINAL}
            {W5_CLOSING}
            {end_cta('/pdf/pdftotext', 'PDF to Text free', '<a href="/compare/adobe-alternative">Adobe alternative</a>')}
            """


def body_split(slug: str) -> str:
    d = SPLIT_DATA[slug]
    return f"""
            <h2>{d['title']}</h2>
            <p>Divide oversized PDFs when compression is not enough — RatPDF <a href="/pdf/split">Split PDF</a> by page range.</p>
            {shot("Split PDF page range selector")}
            <h2>Real example: {d['example']}</h2>
            <ol>
            <li>Note total pages and target MB per part.</li>
            <li>Split at logical boundaries.</li>
            <li>Label Part 1 of N — email with index in body.</li>
            </ol>
            {SPLIT_DEEP[slug]}
            {SPLIT_SLUG_EXTRA[slug]}
            {mid_cta('/pdf/split', 'Split PDF', 'Split your PDF now')}
            {split_supplement()}
            {SPLIT_W5_MEGA}
            {split_long_w5(d['title'])}
            {SPLIT_UNIVERSAL}
            {SPLIT_W5_DEEP}
            {SPLIT_1500_TOPUP}
            {SPLIT_FINAL}
            {W5_1500_TOPUP}
            {COMPRESS_W5_EXTRA}
            {COMPRESS_W5_MORE}
            {W5_SHARED_MEGA}
            {SPLIT_W5_CLUSTER}
            {W5_FINAL}
            {W5_CLOSING}
            {end_cta('/pdf/split', 'Split PDF free', '<a href="/guides/compress-pdf-for-email">Try compress first</a>')}
            """


def main():
    lines = [
        "namespace ratpdf.Content",
        "{",
        "    /// <summary>Wave 5 — Compress platform, PDF to Text, Split clusters (SEO audit).</summary>",
        "    internal static class GuideBodiesWave5",
        "    {",
        "        public static string? Get(string slug) => slug switch",
        "        {",
    ]
    for slug in SLUGS:
        lines.append(f'            "{slug}" => {const_name(slug)},')
    lines.append("            _ => null")
    lines.append("        };")
    lines.append("")

    builders = {}
    for slug in PLATFORM_SLUGS:
        builders[slug] = body_platform(slug)
    for slug in PORTAL_SLUGS:
        builders[slug] = body_portal(slug)
    for slug in COMPRESS_SLUGS:
        builders[slug] = body_compress_special(slug)
    for slug in TEXT_SLUGS:
        builders[slug] = body_text(slug)
    for slug in SPLIT_SLUGS:
        builders[slug] = body_split(slug)

    for slug in SLUGS:
        content = builders[slug].lstrip("\n").rstrip()
        lines.append(f"        private const string {const_name(slug)} = \"\"\"")
        lines.append(content)
        lines.append("            \"\"\";")
        lines.append("")

    lines.append("    }")
    lines.append("}")
    OUT.write_text("\n".join(lines) + "\n", encoding="utf-8")
    print(f"Wrote {OUT} ({len(SLUGS)} guides)")


if __name__ == "__main__":
    main()
