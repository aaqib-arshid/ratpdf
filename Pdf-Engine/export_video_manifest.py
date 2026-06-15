"""Export tool manifest for generate_tool_videos.py (mirrors ToolHowToVideos catalog)."""
import json
import sys
from pathlib import Path

# Minimal mirror of C# catalog — run via: python export_video_manifest.py > manifest.json
TOOLS = []

def add(url, name):
    slug = url.strip("/").lower()
    if slug.startswith("pdf/"):
        slug = slug[4:].replace("/", "-")
    elif slug.startswith("tools/"):
        slug = slug[6:].replace("/", "-")
    else:
        slug = slug.replace("/", "-")
    TOOLS.append({"slug": slug, "name": name, "file": f"{slug}.mp4", "url": url})

# PDF tools (from PdfToolSeo.AllTools — load from a static list file if needed)
PDF = [
    ("Compress PDF", "/pdf/compress"), ("Merge PDF", "/pdf/merge"), ("Split PDF", "/pdf/split"),
    ("PDF to Word", "/pdf/pdftodoc"), ("Word to PDF", "/pdf/doctopdf"), ("PDF to Excel", "/pdf/pdftoexcel"),
    ("Excel to PDF", "/pdf/exceltopdf"), ("PDF to PowerPoint", "/pdf/pdftoppt"), ("PowerPoint to PDF", "/pdf/ppttopdf"),
    ("PDF to Text", "/pdf/pdftotext"), ("Text to PDF", "/pdf/texttopdf"), ("HTML to PDF", "/pdf/htmltopdf"),
    ("PDF to Markdown", "/pdf/pdftomarkdown"), ("Images to PDF", "/pdf/convertimages"), ("PDF to Images", "/pdf/pdftoimages"),
    ("Edit PDF", "/pdf/editpdf"), ("OCR PDF", "/pdf/ocrpdf"), ("Extract Images", "/pdf/extractimages"),
    ("PDF Metadata", "/pdf/pdfmetadata"), ("Flatten PDF", "/pdf/flattenpdf"), ("Sign PDF", "/pdf/signtext"),
    ("Watermark PDF", "/pdf/watermark"), ("Password protect", "/pdf/password"), ("Unlock PDF", "/pdf/unlockpdf"),
    ("Rotate / remove pages", "/pdf/rotateorremove"), ("Add page numbers", "/pdf/pagenumbers"),
    ("Compress Image", "/pdf/imagecompressor"), ("Img to Base64", "/pdf/imgtobase64"),
    ("JSON Formatter", "/pdf/jsonformatter"), ("JWT Decoder", "/pdf/jwtdecoder"), ("HTML Formatter", "/pdf/htmlformatter"),
]
for name, url in PDF:
    add(url, name)

add("/pdf-redaction", "PDF Redaction")
add("/invoice/create", "Invoice Generator")
add("/tools/imgbackgroundremove", "Background Remover")

# Medical / dev / utilities from SiteToolNavigation — read from json export if present
extra_path = Path(__file__).parent / "tool_video_manifest_extra.json"
if extra_path.is_file():
    extra = json.loads(extra_path.read_text(encoding="utf-8"))
    for t in extra.get("tools", []):
        TOOLS.append(t)

seen = set()
unique = []
for t in TOOLS:
    if t["slug"] not in seen:
        seen.add(t["slug"])
        unique.append(t)

print(json.dumps({"tools": unique}, indent=2))
