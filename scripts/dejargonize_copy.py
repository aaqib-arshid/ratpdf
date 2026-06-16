"""Replace SEO jargon in user-facing guide copy and generator templates."""
import re
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]

REPLACEMENTS = [
    (
        "MOFU pages link pillars — pillars link tools — compare hub links alternatives — strengthens crawl paths without new URLs.",
        "Each guide links to related tools and comparisons so your team picks the right workflow.",
    ),
    (
        "train team on decision trees in pillar guides",
        "train your team using the main tool guides",
    ),
    (
        "Pin pillar guides in shared wiki",
        "Pin the main tool guides in your shared wiki",
    ),
    (
        "Bookmark pillar guide and",
        'Bookmark the <a href="/guides/pdf-tools">PDF tools guide</a> and',
    ),
    (
        "Convert (images, PPT, Word export), edit/organize spokes, remaining Word workflow pages, and SMB compare hub — complete MOFU without new URLs.",
        "Image, PowerPoint, and Word conversion guides, plus editing tutorials and competitor comparisons — all in one place.",
    ),
    (
        "Security &amp; compliance MOFU — password, watermark, unlock, redaction, GDPR/HIPAA workflows, Section 508 and WCAG accessibility — 17 authority guides with honest tool limits.",
        "Security and compliance guides cover password protection, watermarks, unlock, redaction, GDPR/HIPAA workflows, and accessibility — with honest limits on what each tool can do.",
    ),
    (
        "<h2>Compare MOFU</h2>",
        "<h2>Compare tools</h2>",
    ),
    (
        "Compress spokes feed pillar <a href=\"/guides/compress-pdf-guide\">compress PDF guide</a>. Compliance spokes link GST, e-invoice, redaction, and accessibility hubs — strengthen topical authority without new URLs.",
        "Compression guides link to our <a href=\"/guides/compress-pdf-guide\">compress PDF guide</a>. Compliance guides cover GST, e-invoice, redaction, and accessibility.",
    ),
    (
        'Hub: <a href="/guides/pdf-to-word">PDF to Word</a> · MOFU: <a href="/guides/pdf-to-word-vs-pdf-to-text">Word vs Text</a> · <a href="/guides/ocr-vs-pdf-to-text">OCR vs Text</a>.',
        'Start with <a href="/guides/pdf-to-word">PDF to Word</a> · Compare <a href="/guides/pdf-to-word-vs-pdf-to-text">Word vs Text</a> · <a href="/guides/ocr-vs-pdf-to-text">OCR vs Text</a>.',
    ),
    (
        "Workflow spokes (bank statement, NDA, PO) feed pillar <a href=\"/guides/pdf-to-word\">PDF to Word</a>. Comparison spokes (vs Google Docs, vs PDF to Text, OCR vs text) capture MOFU decision queries without new URLs.",
        "Workflow guides (bank statements, NDAs, purchase orders) link to <a href=\"/guides/pdf-to-word\">PDF to Word</a>. Comparison guides help you choose between Google Docs, plain text export, and OCR.",
    ),
    (
        "Platform compress (Mac/Windows/mobile), portal compress (tax/immigration), PDF to Text spokes, and split-for-email complete the operational MOFU layer around existing pillars — no new URLs.",
        "Platform-specific compression (Mac, Windows, mobile), portal upload limits, PDF to Text export, and split-for-email guides round out the compression workflow.",
    ),
    (
        "Edit-gap MOFU: crop, delete, annotate, highlight, rearrange, text, forms, device workflows, blank-page cleanup, and upgraded edit/rotate pillars — 17 authority-grade guides without cannibalizing Wave 6 organize spokes.",
        "Editing guides cover crop, delete, annotate, highlight, rearrange pages, add text, fill forms, device workflows, blank-page cleanup, and rotate — step-by-step help for each task.",
    ),
    (
        "Troubleshooting MOFU hub — won't open, corrupt, repair honesty, email/portal blocks, print failures, merge/download errors — 17 authority guides linking to real RatPDF tools where workarounds exist.",
        "Troubleshooting guides cover files that won't open, corruption, repair limits, email and portal blocks, print failures, and merge/download errors — with links to RatPDF tools where a workaround exists.",
    ),
    (
        "Wave 10 deepens Excel, HTML, Markdown, and image export MOFU — complements Wave 7 Word pillar and Wave 6 images/PPT convert spokes. Pick tool by downstream deliverable: edit → Word, analyze → Excel, archive web → HTML to PDF, docs repo → Markdown, pixels → Images.",
        "Conversion guides for Excel, HTML, Markdown, and images complement Word and PowerPoint workflows. Pick the tool by what you need next: edit in Word, analyze in Excel, archive a page as PDF, store docs as Markdown, or export pages as images.",
    ),
    (
        "Conversion depth MOFU — Excel, HTML, Markdown, JPG/PNG pillars and without-Adobe spokes — 17 authority guides linking to real RatPDF convert tools.",
        "In-depth conversion guides for Excel, HTML, Markdown, and JPG/PNG — plus Adobe-free alternatives — each linked to the matching RatPDF tool.",
    ),
    (
        "Standards &amp; archiving MOFU — PDF/A, PDF/UA, PDF/X, metadata depth, retention, storage — 17 authority guides with honest RatPDF tool limits.",
        "Standards and archiving guides cover PDF/A, PDF/UA, PDF/X, metadata, retention, and storage — with honest notes on what RatPDF can and cannot do.",
    ),
    (
        "Printing workflows MOFU — device print-to-PDF, quality settings, flatten, commercial handoff — 17 authority guides linking Wave 9 troubleshooting and PDF/X standards.",
        "Printing workflow guides cover print-to-PDF on any device, quality settings, flattening forms, and commercial print handoff — plus links to troubleshooting and PDF/X standards.",
    ),
    (
        "Browser &amp; device MOFU — merge, split, convert, OCR, scan, and browser export on Mac, Windows, mobile, Chromebook, Linux — 17 authority guides cross-linking Waves 5, 8, and 13.",
        "Browser and device guides for merge, split, convert, OCR, scan, and export on Mac, Windows, mobile, Chromebook, and Linux — with links to related compression, editing, and printing help.",
    ),
    (
        "Regional MOFU — visa, bank, contract, India tax/job/university, government applicant workflows — 17 authority guides with portal compress cross-links.",
        "Regional guides for visa, bank, and contract PDFs, plus India tax, job, university, and government applicant workflows — with compression tips for portal upload limits.",
    ),
    (
        "Regional MOFU — Schengen, Gulf, Asia-Pacific visa, bank, contract, India payslip/rent — 17 more authority guides.",
        "More regional guides for Schengen, Gulf, and Asia-Pacific visa, bank, and contract PDFs, plus India payslip and rent receipt workflows.",
    ),
    ("— pillar <a", "— see the <a"),
    ("<h2>Device &amp; portal spokes</h2>", "<h2>Device &amp; portal guides</h2>"),
    ("This pillar links every compress workflow", "This guide links every compress workflow"),
    ("Pillar for all compress spokes.", "Index of compression guides."),
    ("<a href=\"/guides/compress-pdf-guide\">compress pillar</a>", '<a href="/guides/compress-pdf-guide">compress guide</a>'),
    ("<a href=\"/guides/split-pdf\">split pillar</a>", '<a href="/guides/split-pdf">split guide</a>'),
    ("<a href=\"/guides/merge-pdf\">merge pillar</a>", '<a href="/guides/merge-pdf">merge guide</a>'),
    ("<a href=\"/guides/ocr-pdf\">OCR pillar</a>", '<a href="/guides/ocr-pdf">OCR guide</a>'),
    ("PDF to Word pillar guide", "PDF to Word guide"),
    ("Invoice generator pillar", "invoice generator guide"),
    (" (pillar)", ""),
    ("<h2>Long-tail guides</h2>", "<h2>More guides</h2>"),
    ("<h2>Long-tail pages</h2>", "<h2>Related guides</h2>"),
    (" · Long-tail: ", " · See also: "),
    (
        "RatPDF's developer hub covers JSON formatting, JWT decoding, HTML beautification, text diff, URL encoding, binary conversion, DNS lookup, and Base64 image encoding — plus thousands of long-tail SEO pages for specific debugging scenarios.",
        "RatPDF's developer hub covers JSON formatting, JWT decoding, HTML beautification, text diff, URL encoding, binary conversion, DNS lookup, and Base64 image encoding — plus focused guides for common debugging tasks.",
    ),
    (
        "See programmatic guides like ",
        "See also ",
    ),
    (
        "Long-tail guides for email limits and portal caps.",
        "Guides for email limits and portal upload caps.",
    ),
    (
        "pillar links",
        "related guides",
    ),
    ("<h2>Compare MOFU guides</h2>", "<h2>Compare tools</h2>"),
    (
        "Wave 10: conversion depth spokes (pdf-to-jpg, excel, html) — bookmark <a href=\"/guides/pdf-troubleshooting\">troubleshooting hub</a> for helpdesk.",
        "More conversion guides (PDF to JPG, Excel, HTML) — bookmark the <a href=\"/guides/pdf-troubleshooting\">troubleshooting hub</a> for your helpdesk.",
    ),
    ("Portal compress spokes:", "Portal compression guides:"),
    ("<h2>Language spokes</h2>", "<h2>Language guides</h2>"),
    (
        "Wave 8 closes competitor gaps on crop, delete, annotate, highlight, rearrange, device edit, and pillar upgrades for <a href=\"/guides/edit-pdf\">edit PDF</a> and <a href=\"/guides/rotate-pdf\">rotate PDF</a>. Chain with Wave 6 organize spokes and Wave 7 merge/split/OCR pillars.",
        "Editing guides cover crop, delete, annotate, highlight, rearrange pages, and device workflows — plus in-depth help for <a href=\"/guides/edit-pdf\">edit PDF</a> and <a href=\"/guides/rotate-pdf\">rotate PDF</a>. See also merge, split, and OCR guides.",
    ),
    (
        "Wave 3 compress — Wave 4 Word — Wave 5 text/split — Wave 6 convert/edit — pick order by deliverable. Example: photos → images PDF → OCR → edit date → compress → portal upload.",
        "Pick tool order by what you need to deliver. Example: photos → images PDF → OCR → edit date → compress → portal upload.",
    ),
    (
        "Wave 11: security &amp; compliance (redaction, GDPR, HIPAA) — bookmark <a href=\"/guides/pdf-conversion-guide\">conversion hub</a>.",
        "Security and compliance guides (redaction, GDPR, HIPAA) — or bookmark the <a href=\"/guides/pdf-conversion-guide\">conversion hub</a>.",
    ),
    (
        "Wave 12: standards &amp; archiving (PDF/A, retention, metadata depth) — bookmark <a href=\"/guides/pdf-security-compliance-guide\">compliance hub</a>.",
        "Standards and archiving guides (PDF/A, retention, metadata) — bookmark the <a href=\"/guides/pdf-security-compliance-guide\">compliance hub</a>.",
    ),
    (
        "Wave 13: printing workflows — bookmark <a href=\"/guides/pdf-standards-archiving-hub\">standards hub</a>.",
        "Printing workflow guides — bookmark the <a href=\"/guides/pdf-standards-archiving-hub\">standards hub</a>.",
    ),
    (
        "Wave 14: browser + device matrix — bookmark <a href=\"/guides/pdf-printing-guide\">printing hub</a>.",
        "Browser and device guides — bookmark the <a href=\"/guides/pdf-printing-guide\">printing hub</a>.",
    ),
    (
        "Wave 15: regional workflow upgrades — bookmark <a href=\"/guides/pdf-device-workflows-hub\">device hub</a>.",
        "Regional workflow guides — bookmark the <a href=\"/guides/pdf-device-workflows-hub\">device hub</a>.",
    ),
    ("<h2>Wave 3 cross-link</h2>", "<h2>Related compression guides</h2>"),
    ("<h2>Wave 4 cross-link</h2>", "<h2>Related Word conversion guides</h2>"),
    ("<h2>Wave 5 cluster map</h2>", "<h2>Related guides</h2>"),
    (
        "OCR → compress → merge → split — pick order by portal rules. Wave 3: <a href=\"/guides/compress-before-merge-pdf\">compress/merge decision</a>. Wave 4: <a href=\"/guides/pdf-to-word-vs-pdf-to-text\">Word vs Text</a>.",
        "OCR → compress → merge → split — pick order by portal rules. See <a href=\"/guides/compress-before-merge-pdf\">compress vs merge</a> and <a href=\"/guides/pdf-to-word-vs-pdf-to-text\">Word vs Text</a>.",
    ),
    ("Pillar reference:", "Main guide:"),
    ("Merge online (BOFU):", "Merge online:"),
    ("Master hub:", "Start here:"),
    (">compare hub</a>", ">compare tools</a>"),
    (" on <a href=\"/compare\">compare hub</a>", " on <a href=\"/compare\">compare tools</a>"),
    (" and <a href=\"/compare\">compare hub</a>", " and <a href=\"/compare\">compare tools</a>"),
    (". Pillars:", ". See also:"),
    ("Pillars:", "Main guides:"),
    ("<h2>Wave 2 merge cluster map</h2>", "<h2>Related merge guides</h2>"),
    ("<h2>Wave 2 OCR cluster</h2>", "<h2>Related OCR guides</h2>"),
    ("<h2>Wave 1 cross-link: PDF to Word</h2>", "<h2>Related PDF to Word guides</h2>"),
    ("<h2>Wave 1 invoice cross-link</h2>", "<h2>Related invoice guides</h2>"),
    ("<h2>Wave guide index for teams</h2>", "<h2>Guide index for teams</h2>"),
    ("<h2>Wave 8 spoke index</h2>", "<h2>Related editing guides</h2>"),
    ("<h2>Pillar spoke index</h2>", "<h2>Related guides</h2>"),
    ("<h2>Complete compress spoke library</h2>", "<h2>Compression guides</h2>"),
    ("<h2>Complete merge spoke library</h2>", "<h2>Merge guides</h2>"),
    ("<h2>Split spoke index</h2>", "<h2>Related split guides</h2>"),
    ("<h2>Complete split spoke library</h2>", "<h2>Split guides</h2>"),
    ("<h2>Document spoke index</h2>", "<h2>Related conversion guides</h2>"),
    ("<h2>Complete PDF to Word spoke library</h2>", "<h2>PDF to Word guides</h2>"),
    ("<h2>OCR spoke index</h2>", "<h2>Related OCR guides</h2>"),
    ("<h2>Complete OCR spoke library</h2>", "<h2>OCR guides</h2>"),
    ("<h2>Pillar and spoke navigation</h2>", "<h2>Related guides</h2>"),
    ("<h2>Edit PDF pillar — decision tree</h2>", "<h2>Edit PDF — decision tree</h2>"),
    ("Pin this pillar in team wiki.", "Pin this guide in your team wiki."),
    (
        "This page is the hub for email-sized PDF workflows. Platform-specific steps live in spoke guides — link here first, then drill down:",
        "This page covers email-sized PDF workflows. Platform-specific steps are in the linked guides below:",
    ),
    ("Compress PDF pillar guide", "compress PDF guide"),
    ("Merge + compress + convert silo", "Merge, compress, and convert tools"),
    ("/compare hub", "/compare page"),
    ("compare hub", "compare page"),
    ("PDF troubleshooting pillar", "PDF troubleshooting guide"),
    ("Compression pillar", "Compression guide"),
    ("Compress pillar", "Compress guide"),
    ("edit PDF pillar", "edit PDF guide"),
    (" · Hub: ", " · Guide: "),
    ("<h2>Batch 1 complete</h2>", "<h2>More regional guides</h2>"),
    ("<h2>Batch 2 complete</h2>", "<h2>More regional guides</h2>"),
    ("<h2>Regional guides (batch 2)</h2>", "<h2>Regional guides</h2>"),
    (
        "Wave 15 batch 2: remaining country templates — bookmark <a href=\"/guides/pdf-regional-workflows-hub\">regional hub</a>.",
        "More country-specific guides — bookmark the <a href=\"/guides/pdf-regional-workflows-hub\">regional workflows index</a>.",
    ),
    (
        "Wave 15 batch 3: remaining countries (IT, MX, NZ, ZA, KR) — bookmark <a href=\"/guides/pdf-regional-workflows-hub\">regional hub</a>.",
        "Guides for Italy, Mexico, New Zealand, South Africa, and South Korea — bookmark the <a href=\"/guides/pdf-regional-workflows-hub\">regional workflows index</a>.",
    ),
    (
        "Wave 5 upgraded <a href=\"/guides/compress-pdf-on-mac\">compress on Mac/Windows/iPhone/Android</a>. Wave 8 covers <a href=\"/guides/edit-pdf-on-mac\">edit on Mac/Windows/iPhone</a>. Wave 13 covers print-to-PDF. Wave 14 adds merge, split, convert, OCR, and browser export depth.",
        "See also <a href=\"/guides/compress-pdf-on-mac\">compress on Mac/Windows/iPhone/Android</a>, <a href=\"/guides/edit-pdf-on-mac\">edit on Mac/Windows/iPhone</a>, and print-to-PDF guides — plus merge, split, convert, OCR, and browser export help on this page.",
    ),
    (
        "Regional workflow guides — bookmark the <a href=\"/guides/pdf-device-workflows-hub\">device hub</a>.",
        "Regional workflow guides — bookmark the <a href=\"/guides/pdf-device-workflows-hub\">device workflows index</a>.",
    ),
    (
        "Blank pages, wrong margins, and color shifts: <a href=\"/guides/pdf-troubleshooting\">troubleshooting hub</a> — Wave 9 depth guides.",
        "Blank pages, wrong margins, and color shifts: see the <a href=\"/guides/pdf-troubleshooting\">PDF troubleshooting guide</a>.",
    ),
    (
        "Pin hub link — reduces repeat tickets on blank print and margin questions — links Wave 9 troubleshooting.",
        "Bookmark the troubleshooting guide — it covers blank print and margin questions.",
    ),
    (
        "Compress Wave 3–5 · Word Wave 4–6 · Split Wave 5–6 · Convert Wave 6 — bookmark set in shared browser folder for consistent onboarding.",
        "Compression, Word conversion, split, and convert guides — bookmark the set in a shared browser folder for consistent team onboarding.",
    ),
    ('">pillar</a>', '">main guide</a>'),
    (">troubleshooting hub</a>", ">PDF troubleshooting guide</a>"),
    (">regional hub</a>", ">regional workflows index</a>"),
    (">device hub</a>", ">device workflows index</a>"),
]

LINK_PILLAR_RE = re.compile(r">([^<]+) pillar</a>")

WAVE_HEADING_REPLACEMENTS = [
    (re.compile(r"<h2>Wave \d+ complete</h2>"), "<h2>Related guides</h2>"),
    (re.compile(r"<h2>Wave \d+ cluster complete</h2>"), "<h2>Related guides</h2>"),
    (re.compile(r"<h2>Wave \d+ cluster map</h2>"), "<h2>More guides</h2>"),
    (
        re.compile(r"<h2>Wave \d+ ([^<]+)</h2>"),
        lambda m: f"<h2>{m.group(1)[0].upper()}{m.group(1)[1:]}</h2>",
    ),
]

GLOB_PATTERNS = [
    "Content/GuideBodies*.cs",
    "Content/ContentLibrary.cs",
    "scripts/wave*_expansions.py",
    "scripts/generate_wave*_bodies.py",
    "Constants/TopicalAuthority.cs",
    "Views/**/*.cshtml",
]


def dejargonize(text: str) -> str:
    for old, new in REPLACEMENTS:
        text = text.replace(old, new)
    for pattern, repl in WAVE_HEADING_REPLACEMENTS:
        text = pattern.sub(repl, text)
    text = LINK_PILLAR_RE.sub(lambda m: f">{m.group(1)} guide</a>", text)
    return text


def main() -> None:
    changed_files = 0
    for pattern in GLOB_PATTERNS:
        for path in sorted(ROOT.glob(pattern)):
            text = path.read_text(encoding="utf-8")
            updated = dejargonize(text)
            if updated != text:
                path.write_text(updated, encoding="utf-8", newline="\n")
                changed_files += 1
    print(f"Updated {changed_files} files.")


if __name__ == "__main__":
    main()
