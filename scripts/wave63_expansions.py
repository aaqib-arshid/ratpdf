"""Wave 63 — CREATE batch 27 (final 2 guides). Conversion stragglers."""

W63_SLUGS = [
    "pdf-to-audio",
    "pdf-to-hwp",
]

W63_DATA = {
    "pdf-to-audio": {
        "title": "PDF to Audio — Read Documents Aloud (2026)",
        "tool": "/pdf/pdftotext",
        "label": "PDF to Text",
        "pillar": "/guides/pdf-to-text",
        "pillar_label": "PDF to text guide",
        "related": "/guides/pdf-to-kindle",
        "prog": "/pdf/pdftotext",
        "example": "Commuter extracts a PDF report to clean text, then feeds it to a text-to-speech app to listen on the drive",
        "deep": """
            <h2>Turn a PDF into spoken audio</h2>
            <p>There is no single \"PDF to MP3\" button you should trust for accuracy — the reliable path is to extract clean text first, then hand it to a text-to-speech (TTS) engine.</p>
            <ol>
            <li><a href="/pdf/ocrpdf">OCR</a> the PDF first if it is a scan, or TTS reads nothing</li>
            <li><a href="/pdf/pdftotext">PDF to Text</a> — export a clean, reflowable text layer</li>
            <li>Paste the text into a TTS tool: built-in OS readers (Narrator, VoiceOver), browser read-aloud, or apps like NaturalReader/Speechify</li>
            <li>For an audio file, use a TTS app that exports MP3/M4A; for listening only, OS read-aloud is fastest and free</li>
            </ol>
            <h3>Cleanup tips for natural narration</h3>
            <ul>
            <li>Remove headers, footers, and page numbers — TTS reads them aloud mid-sentence</li>
            <li>Strip tables and figure captions or they sound like noise; keep prose paragraphs</li>
            <li>Fix hyphenated line breaks (\"manage-\\nment\" → \"management\") so words aren't split</li>
            <li>For long reports, split into chapters so you can resume listening</li>
            </ul>
            <h3>Accessibility</h3>
            <p>A clean text layer also powers screen readers (NVDA, JAWS, VoiceOver). Run <a href="/pdf/ocrpdf">OCR</a> on scans and verify reading order so assistive tech narrates the document correctly.</p>
            <p><a href="/guides/pdf-to-kindle">PDF to Kindle</a> · <a href="/guides/pdf-to-text">PDF to text guide</a> · <a href="/guides/make-scanned-pdf-searchable">Make scans searchable</a>.</p>
            """,
    },
    "pdf-to-hwp": {
        "title": "PDF to HWP — Convert for Hangul Word Processor (2026)",
        "tool": "/pdf/pdftodoc",
        "label": "PDF to Word",
        "pillar": "/guides/pdf-to-word",
        "pillar_label": "PDF to Word guide",
        "related": "/guides/pdf-to-odt",
        "prog": "/pdf/pdftodoc",
        "example": "Korean office worker converts a PDF to DOCX, then opens and saves it as HWP/HWPX in Hancom Office",
        "deep": """
            <h2>Convert a PDF to HWP / HWPX</h2>
            <p>HWP (and the newer HWPX) is the native format of Hancom Office's Hangul word processor, the standard in many Korean government and corporate offices. Few tools convert PDF directly to HWP, so the dependable route goes through DOCX.</p>
            <ol>
            <li><a href="/pdf/ocrpdf">OCR</a> first if the PDF is a Korean-language scan — choose Korean as the recognition language</li>
            <li><a href="/pdf/pdftodoc">PDF to Word</a> — export an editable DOCX that preserves layout</li>
            <li>Open the DOCX in <strong>Hancom Office Hangul</strong> (it imports DOCX natively)</li>
            <li>Save As → <strong>HWP</strong> or <strong>HWPX</strong> to get the native Hancom format</li>
            </ol>
            <h3>Why go through DOCX</h3>
            <ul>
            <li>DOCX is a well-supported interchange format both PDF converters and Hancom understand</li>
            <li>Layout, tables, and Korean text survive the round-trip better than plain text</li>
            <li>HWPX (XML-based) is more portable than legacy binary HWP — prefer it for archiving</li>
            </ul>
            <h3>Korean-language tips</h3>
            <p>Scanned Hangul needs OCR with the Korean language pack at 300 DPI; proofread names and numbers afterward. For tables, check column alignment in Hangul after import — complex grids sometimes need manual touch-up.</p>
            <p><a href="/guides/pdf-to-odt">PDF to ODT</a> · <a href="/guides/pdf-to-word">PDF to Word guide</a> · <a href="/guides/ocr-pdf">OCR PDF guide</a>.</p>
            """,
    },
}


def _d(slug: str, html: str) -> str:
    p = W63_DATA[slug].get("prog", "")
    tail = f'<p>Tool: <a href="{p}">{p}</a></p>' if p else ""
    return html + tail


W63_DEEP = {slug: _d(slug, W63_DATA[slug]["deep"]) for slug in W63_SLUGS}

W63_CREATE_CLUSTER = """
            <h2>Conversion guides</h2>
            <ul>
            <li><a href="/guides/pdf-to-word">PDF to Word</a> · <a href="/guides/pdf-to-excel">PDF to Excel</a> · <a href="/guides/pdf-to-text">PDF to Text</a></li>
            <li><a href="/guides/pdf-to-odt">PDF to ODT</a> · <a href="/guides/pdf-to-rtf">PDF to RTF</a> · <a href="/guides/pdf-to-xml">PDF to XML</a></li>
            <li><a href="/guides/pdf-to-kindle">PDF to Kindle</a> · <a href="/guides/pdf-to-notion">PDF to Notion</a> · <a href="/guides/pdf-to-audio">PDF to Audio</a> · <a href="/guides/pdf-to-hwp">PDF to HWP</a></li>
            </ul>
            <p>Always <a href="/pdf/ocrpdf">OCR</a> scans before converting, or the output is empty.</p>
            """

W63_TOPUP = """
            <h2>Conversion checklist</h2>
            <ol>
            <li>OCR scanned PDFs first — pick the correct recognition language</li>
            <li>Convert to DOCX as a bridge format when the target app lacks a direct importer</li>
            <li>Proofread numbers, names, and tables — no converter is perfect</li>
            <li>Strip headers, footers, and page numbers for clean downstream text</li>
            </ol>
            """

W63_CLOSING = """
            <h2>Related guides</h2>
            <p>Wave 63 clears the final conversion stragglers — CREATE batch 27 of 450.</p>
            <p>Hub: <a href="/guides/pdf-to-word">PDF to Word</a> · <a href="/guides/pdf-to-text">PDF to Text</a> · <a href="/guides/ocr-pdf">OCR PDF</a></p>
            """
