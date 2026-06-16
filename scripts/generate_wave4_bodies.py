#!/usr/bin/env python3
"""Generate GuideBodiesWave4.cs — premium PDF to Word workflow upgrades (no new URLs)."""
from pathlib import Path

from wave1_expansions import PDF_CLUSTER_PREMIUM, PDF_FINAL_BOOST, PDF_PAGE_PREMIUM
from wave4_expansions import (
    COMPARE_SLUG_DEEP,
    COMPARE_UNIQUE,
    PDF_WORD_1500_TOPUP,
    PDF_WORD_CLUSTER_LINKS,
    PDF_WORD_FINAL_BOOST,
    PDF_WORD_LONG_TAIL,
    PDF_WORD_MEGA,
    WORKFLOW_DATA,
    WORKFLOW_SLUG_DEEP,
    WAVE4_CLOSING,
)

OUT = Path(__file__).resolve().parents[1] / "Content" / "GuideBodiesWave4.cs"

WORKFLOW_SLUGS = list(WORKFLOW_DATA.keys())
COMPARE_SLUGS = [
    "pdf-to-word-without-word",
    "pdf-to-word-vs-google-docs",
    "pdf-to-word-vs-pdf-to-text",
    "pdf-to-word-garbled-text",
    "ocr-vs-pdf-to-text",
]
SLUGS = WORKFLOW_SLUGS + COMPARE_SLUGS

COMPARE_TOOLS = {
    "pdf-to-word-without-word": ("/pdf/pdftodoc", "PDF to Word"),
    "pdf-to-word-vs-google-docs": ("/pdf/pdftodoc", "PDF to Word"),
    "pdf-to-word-vs-pdf-to-text": ("/pdf/pdftodoc", "PDF to Word"),
    "pdf-to-word-garbled-text": ("/pdf/pdftodoc", "PDF to Word"),
    "ocr-vs-pdf-to-text": ("/pdf/ocrpdf", "OCR PDF"),
}

COMPARE_TITLES = {
    "pdf-to-word-without-word": "PDF to Word without Microsoft Word — Google Docs &amp; LibreOffice",
    "pdf-to-word-vs-google-docs": "PDF to Word vs Google Docs — when to convert first",
    "pdf-to-word-vs-pdf-to-text": "PDF to Word vs PDF to Text — which converter do you need?",
    "pdf-to-word-garbled-text": "PDF to Word garbled text — fix encoding, fonts &amp; OCR",
    "ocr-vs-pdf-to-text": "OCR vs PDF to Text — which tool do you need?",
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


def pdf_long_tail(focus: str) -> str:
    return f"""
            <h2>Understanding the PDF to Word pipeline</h2>
            <p>PDF stores text, vectors, and images in a fixed layout. Word expects flowing paragraphs and style definitions. RatPDF bridges the gap by analysing structure first — {focus}. When structure cannot be inferred, pages render as images inside DOCX so you still receive an editable container rather than broken glyphs.</p>

            {shot("RatPDF PDF to Word progress — structure extraction vs fallback")}

            <h2>Digital vs scanned — decision in 10 seconds</h2>
            <p>Open PDF, try to select a sentence. Text highlights → <a href="/pdf/pdftodoc">PDF to Word</a> directly. Picture-only page → <a href="/pdf/ocrpdf">OCR PDF</a> first — <a href="/guides/scanned-pdf-to-word">scanned PDF to Word</a>.</p>

            <h2>Real example: annual report with charts</h2>
            <p><strong>Input:</strong> 40-page investor PDF — narrative digital, three chart pages heavy.</p>
            <p><strong>Outcome:</strong> Narrative edits in Word; chart pages as images you replace with live Excel charts.</p>

            <h2>Word for Microsoft 365 vs desktop</h2>
            <p>Web Word has fewer layout tools — desktop for contract track changes. Mac: <a href="/guides/pdf-to-word-mac">PDF to Word on Mac</a>.</p>

            <h2>Formatting deep dive</h2>
            <p><a href="/guides/pdf-to-word-keep-formatting">Keep formatting guide</a> — corporate templates applied after convert beat fighting PDF styles.</p>

            <h2>Security and retention</h2>
            <p>HTTPS upload — review privacy policy. Clear Downloads on shared PCs after confidential contracts.</p>

            <h2>Alternatives comparison</h2>
            <p><a href="/compare/smallpdf-alternative">Smallpdf</a> · <a href="/compare/adobe-alternative">Adobe</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a>.</p>

            <h2>Common failure modes</h2>
            <p><strong>Garbled characters:</strong> <a href="/guides/pdf-to-word-garbled-text">garbled text guide</a>. <strong>Images only:</strong> OCR or source DOCX. <strong>Wide tables cut off:</strong> landscape section in Word.</p>

            <h2>Collaboration workflow</h2>
            <p>Track changes in Word — merge comments — export PDF via <a href="/pdf/doctopdf">Word to PDF</a> when final.</p>

            <h2>Pillar navigation</h2>
            <p>Start with <a href="/guides/pdf-to-word">PDF to Word</a> · Compare <a href="/guides/pdf-to-word-vs-pdf-to-text">Word vs Text</a> · <a href="/guides/ocr-vs-pdf-to-text">OCR vs Text</a>.</p>
            """


def workflow_supplement(d: dict) -> str:
    return f"""
            <h2>When to use alternative tools</h2>
            <p>{d['alt']}. Pillar overview: <a href="/guides/pdf-to-word">PDF to Word guide</a>.</p>

            <h2>OCR branch reminder</h2>
            <p>Image-only {d['doc']} PDFs: <a href="/pdf/ocrpdf">OCR PDF</a> then PDF to Word — full steps in <a href="/guides/scanned-pdf-to-word">scanned PDF to Word</a>.</p>

            <h2>Cross-links in this cluster</h2>
            <p>Related workflow: <a href="/guides/convert-contract-pdf-to-word">contract to Word</a> · <a href="/guides/pdf-to-word-invoice">invoice to Word</a> · <a href="/guides/pdf-to-word-vs-pdf-to-text">Word vs Text</a>.</p>

            <h2>Post-convert QA</h2>
            <ol>
            <li>Page count roughly matches source</li>
            <li>Critical numbers and dates unchanged unless intentionally edited</li>
            <li>Tables editable (not single image) on digital sources</li>
            <li>Spell-check in Word</li>
            <li>Remove comments before external send</li>
            </ol>

            <h2>Re-PDF delivery</h2>
            <p>Client expects PDF back? <a href="/pdf/doctopdf">Word to PDF</a> — compress if email rejects: <a href="/guides/compress-pdf-for-email">compress for email</a>.</p>

            <h2>Free tier and upgrades</h2>
            <p>Three uses per day per tool on free tier — migration projects need <a href="/Subscription/Plans">subscription plans</a>.</p>
            """


def body_workflow(slug: str) -> str:
    d = WORKFLOW_DATA[slug]
    return f"""
            <h2>{d['title']}</h2>
            <p>RatPDF <a href="/pdf/pdftodoc">PDF to Word</a> turns {d['doc']} PDFs into editable DOCX — no Adobe install. This guide covers real workflows, quality traps, and when to regenerate from source systems instead.</p>

            {shot(f"PDF to Word converting {d['doc']} document")}

            <h2>Real example: {d['example']}</h2>
            <ol>
            <li>Confirm text selects in PDF viewer (digital vs scan).</li>
            <li>Upload to <a href="/pdf/pdftodoc">PDF to Word</a>.</li>
            <li>Edit in Word — {d['tips']}</li>
            <li>Export PDF or send DOCX per recipient policy.</li>
            </ol>

            {WORKFLOW_SLUG_DEEP[slug]}

            {mid_cta('/pdf/pdftodoc', 'PDF to Word now', f'Convert your {d["doc"]} PDF')}

            {workflow_supplement(d)}

            {PDF_WORD_LONG_TAIL}

            {PDF_WORD_MEGA}

            {pdf_long_tail(f"workflow focus on {d['doc']} documents")}

            {PDF_CLUSTER_PREMIUM}

            {PDF_PAGE_PREMIUM}

            {PDF_WORD_1500_TOPUP}

            {PDF_FINAL_BOOST}

            {PDF_WORD_FINAL_BOOST}

            {PDF_WORD_CLUSTER_LINKS}

            {WAVE4_CLOSING}

            {end_cta('/pdf/pdftodoc', 'PDF to Word free', '<a href="/Subscription/Plans">Upgrade plans</a>')}
            """


def compare_supplement(slug: str) -> str:
    return """
            <h2>Related comparison guides</h2>
            <p><a href="/guides/pdf-to-word-vs-google-docs">PDF to Word vs Google Docs</a> · <a href="/guides/pdf-to-word-vs-pdf-to-text">Word vs PDF to Text</a> · <a href="/guides/ocr-vs-pdf-to-text">OCR vs PDF to Text</a> · <a href="/guides/pdf-to-word-without-word">Edit without Microsoft Word</a>.</p>
            <p>Research: <a href="/research/pdf-compression-benchmark">PDF compression benchmark</a> after re-exporting edited DOCX to email-sized PDF.</p>
            """


def body_compare(slug: str) -> str:
    tool, label = COMPARE_TOOLS[slug]
    extra_tool = ""
    if slug == "ocr-vs-pdf-to-text":
        extra_tool = ' · <a href="/pdf/pdftotext">PDF to Text</a> · <a href="/pdf/pdftodoc">PDF to Word</a>'
    elif slug == "pdf-to-word-vs-pdf-to-text":
        extra_tool = ' · <a href="/pdf/pdftotext">PDF to Text</a>'
    return f"""
            <h2>{COMPARE_TITLES[slug]}</h2>
            <p>Decision guide — pick the right RatPDF tool before wasting steps. Not every PDF job needs Word; not every scan needs plain text.</p>

            {shot(f"{COMPARE_TITLES[slug]} decision flowchart")}

            {COMPARE_UNIQUE[slug]}

            {COMPARE_SLUG_DEEP[slug]}

            {mid_cta(tool, label, 'Open the recommended tool')}

            <h2>Quick decision summary</h2>
            <p>If still unsure after reading: start with digital-vs-scan test, then match output format (DOCX layout vs .txt vs searchable PDF) to downstream task — edit, analyse, or archive search.</p>

            {compare_supplement(slug)}

            {PDF_WORD_LONG_TAIL}

            {PDF_WORD_MEGA}

            {pdf_long_tail(f"comparison focus for {slug}")}

            {PDF_CLUSTER_PREMIUM}

            {PDF_PAGE_PREMIUM}

            {PDF_WORD_1500_TOPUP}

            {PDF_FINAL_BOOST}

            {PDF_WORD_FINAL_BOOST}

            {PDF_WORD_CLUSTER_LINKS}

            {WAVE4_CLOSING}

            {end_cta(tool, label, f'<a href="/compare">Compare tools</a>{extra_tool}')}
            """


def main():
    lines = [
        "namespace ratpdf.Content",
        "{",
        "    /// <summary>Wave 4 premium guide bodies — PDF to Word workflow cluster (SEO audit).</summary>",
        "    internal static class GuideBodiesWave4",
        "    {",
        "        public static string? Get(string slug) => slug switch",
        "        {",
    ]
    for slug in SLUGS:
        lines.append(f'            "{slug}" => {const_name(slug)},')
    lines.append("            _ => null")
    lines.append("        };")
    lines.append("")

    for slug in SLUGS:
        body = body_workflow(slug) if slug in WORKFLOW_SLUGS else body_compare(slug)
        content = body.lstrip("\n").rstrip()
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
