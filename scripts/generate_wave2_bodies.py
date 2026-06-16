#!/usr/bin/env python3
"""Generate GuideBodiesWave2.cs — premium Merge + OCR upgrades (no new URLs)."""
from pathlib import Path

from wave2_expansions import (
    MERGE_CLUSTER_LINKS,
    MERGE_LONG_TAIL,
    MERGE_MEGA,
    MERGE_VISA_EXTRA,
    MERGE_PROTECTED_EXTRA,
    MERGE_PREMIUM,
    MERGE_UNIQUE,
    OCR_CLUSTER_LINKS,
    OCR_LANG,
    OCR_LANG_EXTRA,
    OCR_LONG_TAIL,
    OCR_MEGA,
    OCR_POOR_QUALITY_EXTRA,
    OCR_PREMIUM,
    MERGE_FINAL_BOOST,
    OCR_FINAL_BOOST,
    OCR_LANG_LONG,
    OCR_EU_LONG,
    MERGE_1500_TOPUP,
    OCR_1500_TOPUP,
    WAVE2_CLOSING_MERGE,
    WAVE2_CLOSING_OCR,
)

OUT = Path(__file__).resolve().parents[1] / "Content" / "GuideBodiesWave2.cs"

MERGE_SLUGS = [
    "merge-password-protected-pdf",
    "merge-pdf-custom-order",
    "merge-pdf-online",
    "merge-pdf-visa-application",
    "merge-pdf-without-quality-loss",
    "merge-scanned-digital-pdf",
]

OCR_SLUGS = [
    "ocr-pdf-arabic",
    "ocr-pdf-chinese",
    "ocr-pdf-french",
    "ocr-pdf-german",
    "ocr-pdf-hindi",
    "ocr-pdf-japanese",
    "ocr-pdf-korean",
    "ocr-pdf-poor-quality",
    "ocr-pdf-portuguese",
    "ocr-pdf-russian",
    "ocr-pdf-spanish",
]

SLUGS = MERGE_SLUGS + OCR_SLUGS


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


def merge_supplement() -> str:
    return """
            <h2>Split alternative when merge is wrong tool</h2>
            <p>Received one PDF but need only pages 3–7? Use <a href="/guides/split-pdf">split PDF</a> instead of merge. Merge is for combining whole files — not extracting subsets.</p>

            <h2>Version control discipline</h2>
            <p>Keep unmerged source PDFs in archive — merged output is derivative. If client disputes page order, you re-merge from sources without re-scanning.</p>

            <h2>Mobile merge workflow</h2>
            <p>iOS/Android browsers work — upload from Files/Drive picker. Large scans on cellular may timeout; use Wi-Fi or compress sources first.</p>

            <h2>Post-merge delivery</h2>
            <p>Email attachment limits: <a href="/research/attachment-size-limits">attachment size limits research</a>. WhatsApp: <a href="/guides/compress-pdf-for-whatsapp">compress for WhatsApp</a> after merge.</p>

            <h2>Accountant and legal cross-links</h2>
            <p>Board packs: <a href="/guides/merge-pdf-accountants">merge for accountants</a> · Court: <a href="/guides/merge-pdf-court-filing">merge court filing</a> · Students: <a href="/guides/merge-pdf-students">merge for students</a>.</p>

            <h2>File preparation checklist</h2>
            <ol>
            <li>Every source opens without password (unlock if needed)</li>
            <li>Scans rotated upright</li>
            <li>Filenames prefixed for order</li>
            <li>Remove duplicate blank pages from Word exports</li>
            <li>Note total expected page count before merge</li>
            </ol>

            <h2>Cost comparison</h2>
            <p>Adobe Acrobat Pro costs more annually than occasional RatPDF Pro for agencies merging weekly — <a href="/compare/adobe-alternative">Adobe alternative</a> · <a href="/compare">compare tools</a>.</p>
            """


def merge_universal_tail() -> str:
    return """
            <h2>Page size and colour consistency</h2>
            <p>Merging A4 EU exports with US Letter scans produces visible size jumps — acceptable for email, problematic for print bindery. Normalize in source apps when print shop specifies single sheet size.</p>
            <p>RGB marketing PDF merged with grayscale scans — colour profile unchanged per page; print shop may flag mixed modes.</p>

            <h2>Hyperlinks and form fields after merge</h2>
            <p>Internal PDF links often break when destination page numbers shift — re-test links after merge. Form fields with same field names across files may collide — flatten forms before merge for final submissions.</p>

            <h2>Metadata and properties</h2>
            <p>Merged PDF title defaults to first file metadata — set document title in PDF properties after merge for professional delivery ("Client XYZ — Q2 2026 Board Pack").</p>

            <h2>Disaster recovery</h2>
            <p>Browser crash mid-merge loses queue — re-upload from prefixed filenames takes two minutes if sources organized. Keep merge manifest in spreadsheet during month-end close.</p>

            <h2>Training new staff</h2>
            <p>SOP one-pager: unlock → prefix → upload → verify page count → compress → send. Reduces wrong-order visa and court filings from junior staff first solo merge.</p>

            <h2>Research citations</h2>
            <p>Attachment limits after merge: <a href="/research/attachment-size-limits">attachment size limits</a> · Compression trade-offs: <a href="/research/pdf-compression-benchmark">PDF compression benchmark</a>.</p>

            <h2>Related merge guides</h2>
            <p>This guide is part of the merge cluster — cross-read <a href="/guides/merge-pdf-online">merge online</a>, <a href="/guides/merge-pdf-visa-application">visa merge</a>, and <a href="/guides/merge-password-protected-pdf">password-protected merge</a> for specialised workflows.</p>
            """


def ocr_universal_tail(name: str, script: str) -> str:
    return f"""
            <h2>Hardware scanner settings recap</h2>
            <p>Flatbed beats sheet-fed for fragile deeds. ADF OK for crisp typed pages. Clean glass prevents vertical streak false characters in {script} output.</p>

            <h2>Cloud sync of OCR outputs</h2>
            <p>Searchable PDFs in Google Drive remain searchable — index lag may take hours. Do not rely on Drive OCR if you need immediate Ctrl+F — run RatPDF OCR first.</p>

            <h2>Malware and macro paranoia</h2>
            <p>OCR output is PDF with text layer only — not executable. Still scan downloads with corporate antivirus policy like any attachment.</p>

            <h2>Second real example: litigation document dump</h2>
            <p>Opposing counsel sends 40 image PDFs on USB. Batch OCR each, merge chronologically with <a href="/guides/merge-pdf-custom-order">custom order merge</a>, deliver searchable pack to partner for keyword review.</p>

            <h2>Character confusables in {name}</h2>
            <p>Digits 0/O, 1/l/I confuse OCR in any script — manually verify ID numbers, dates, and currency amounts regardless of language.</p>

            <h2>Related PDF to Word guides</h2>
            <p>Editable output: <a href="/guides/scanned-pdf-to-word">scanned PDF to Word</a> · <a href="/guides/pdf-to-word-keep-formatting">keep formatting</a> · Mac: <a href="/guides/pdf-to-word-mac">PDF to Word on Mac</a>.</p>

            <h2>Closing discipline</h2>
            <p>OCR is not proofreading — budget human review for any {name} document that triggers legal, tax, or immigration consequences.</p>
            """


def body_merge(slug: str) -> str:
    titles = {
        "merge-pdf-online": "Merge PDF online — combine files in your browser (2026)",
        "merge-pdf-custom-order": "Merge PDF in custom order — reorder before combining",
        "merge-pdf-visa-application": "Merge PDF for visa application — document order &amp; size",
        "merge-password-protected-pdf": "Merge password-protected PDFs — unlock, combine, deliver",
        "merge-pdf-without-quality-loss": "Merge PDF without losing quality — vector preservation",
        "merge-scanned-digital-pdf": "Merge scanned and digital PDFs — mixed sources",
    }
    shots = {
        "merge-pdf-online": "Merge PDF upload zone with three files queued in order",
        "merge-pdf-custom-order": "Drag-reorder file list before merge submit",
        "merge-pdf-visa-application": "Visa document checklist beside merged PDF preview",
        "merge-password-protected-pdf": "Unlock PDF step then merge queue",
        "merge-pdf-without-quality-loss": "Side-by-side logo sharpness before and after smart merge",
        "merge-scanned-digital-pdf": "Digital letter PDF plus rotated phone scan in merge list",
    }
    extra = ""
    if slug == "merge-pdf-visa-application":
        extra = MERGE_VISA_EXTRA
    elif slug == "merge-password-protected-pdf":
        extra = MERGE_PROTECTED_EXTRA
    return f"""
            <h2>{titles[slug]}</h2>
            <p>RatPDF <a href="/pdf/merge">Merge PDF</a> combines multiple PDFs into one download — no Adobe install. This guide covers real workflows, order discipline, quality traps, and when to compress after merge.</p>

            {shot(shots[slug])}

            {MERGE_UNIQUE[slug]}

            {extra}

            {mid_cta('/pdf/merge', 'Open Merge PDF', 'Combine your PDFs now')}

            {merge_supplement()}

            {MERGE_LONG_TAIL}

            {MERGE_MEGA}

            {merge_universal_tail()}

            {MERGE_PREMIUM}

            {MERGE_CLUSTER_LINKS}

            {MERGE_FINAL_BOOST}

            {MERGE_1500_TOPUP}

            {WAVE2_CLOSING_MERGE}

            {end_cta('/pdf/merge', 'Merge PDF free', '<a href="/compare/smallpdf-alternative">Compare alternatives</a>')}
            """


def ocr_lang_body(slug: str) -> str:
    d = OCR_LANG[slug]
    peer = d["peers"]
    peer_name = peer.replace("ocr-pdf-", "").replace("-", " ").title()
    extra = OCR_POOR_QUALITY_EXTRA if slug == "ocr-pdf-poor-quality" else OCR_LANG_EXTRA.format(
        name=d["name"], script=d["script"], peer=peer, peer_name=peer_name
    )
    title = (
        "OCR PDF poor quality — fix blurry and low-DPI scans"
        if slug == "ocr-pdf-poor-quality"
        else f"OCR PDF {d['name']} — searchable {d['script']} documents online"
    )
    extra_lang = OCR_LANG_LONG.get(slug, "")
    if not extra_lang and slug in ("ocr-pdf-french", "ocr-pdf-german", "ocr-pdf-spanish", "ocr-pdf-portuguese", "ocr-pdf-russian"):
        extra_lang = OCR_EU_LONG.format(name=d["name"])
    return f"""
            <h2>{title}</h2>
            <p>Image-only PDFs are not searchable until OCR adds a text layer. RatPDF <a href="/pdf/ocrpdf">OCR PDF</a> uses Tesseract — upload scan, download searchable PDF, then export text or convert to Word.</p>
            <p>Pillar: <a href="/guides/ocr-pdf">OCR PDF guide</a> · Compare: <a href="/guides/ocr-vs-pdf-to-text">OCR vs PDF to text</a>.</p>

            {shot(f"OCR PDF progress on {d['name']} scanned document")}

            <h2>Real example: {d['example']}</h2>
            <ol>
            <li>Scan or export PDF — confirm text does <em>not</em> select (image-only).</li>
            <li>Upload to <a href="/pdf/ocrpdf">OCR PDF</a> — 300 DPI sources process best.</li>
            <li>Verify: Ctrl+F finds a known word in your viewer.</li>
            <li>Export via <a href="/pdf/pdftotext">PDF to Text</a> or <a href="/guides/scanned-pdf-to-word">scanned PDF to Word</a> if editing needed.</li>
            </ol>

            <h2>{d['name']}-specific OCR tips</h2>
            <p>{d['tips']}</p>

            {mid_cta('/pdf/ocrpdf', 'Run OCR now', f'Make {d["name"]} scans searchable')}

            {extra}

            {extra_lang}

            {OCR_LONG_TAIL}

            {OCR_MEGA.format(name=d['name'], script=d['script'])}

            {ocr_universal_tail(d['name'], d['script'])}

            {OCR_PREMIUM}

            {OCR_CLUSTER_LINKS}

            {OCR_FINAL_BOOST.format(name=d['name'])}

            {OCR_1500_TOPUP.format(name=d['name'])}

            {WAVE2_CLOSING_OCR}

            {end_cta('/pdf/ocrpdf', 'OCR PDF free', '<a href="/pdf/pdftotext">PDF to Text</a>')}
            """


def main():
    lines = [
        "namespace ratpdf.Content",
        "{",
        "    /// <summary>Wave 2 premium guide bodies — Merge PDF + OCR PDF clusters (SEO audit).</summary>",
        "    internal static class GuideBodiesWave2",
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
        body = body_merge(slug) if slug in MERGE_SLUGS else ocr_lang_body(slug)
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
