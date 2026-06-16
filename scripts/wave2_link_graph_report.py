#!/usr/bin/env python3
"""Link graph report for Wave 2 upgraded guides."""
import re
from pathlib import Path

MERGE = [
    "merge-password-protected-pdf", "merge-pdf-custom-order", "merge-pdf-online",
    "merge-pdf-visa-application", "merge-pdf-without-quality-loss", "merge-scanned-digital-pdf",
]
OCR = [
    "ocr-pdf-arabic", "ocr-pdf-chinese", "ocr-pdf-french", "ocr-pdf-german", "ocr-pdf-hindi",
    "ocr-pdf-japanese", "ocr-pdf-korean", "ocr-pdf-poor-quality", "ocr-pdf-portuguese",
    "ocr-pdf-russian", "ocr-pdf-spanish",
]
SLUGS = MERGE + OCR

raw = Path(__file__).resolve().parents[1] / "Content" / "GuideBodiesWave2.cs"
text = raw.read_text(encoding="utf-8")
blocks = dict(zip(
    re.findall(r'"([\w-]+)" =>', text),
    re.findall(r'private const string \w+ = """(.*?)""";', text, re.S),
))

inbound = {s: [] for s in SLUGS}
print("# Wave 2 Link Graph Report\n")
for slug in SLUGS:
    body = blocks.get(slug, "")
    links = re.findall(r'href="(/[^"]+)"', body)
    guides = [l for l in links if l.startswith("/guides/")]
    research = [l for l in links if l.startswith("/research/")]
    compare = [l for l in links if l.startswith("/compare")]
    tool = "/pdf/merge" if slug in MERGE else "/pdf/ocrpdf"
    cluster = "merge" if slug in MERGE else "ocr"
    print(f"## {slug}")
    print(f"- Outbound: {len(links)} | Research: {len(set(research))} | Compare: {len(set(compare))}")
    print(f"- Tool CTA: {tool} ({sum(1 for l in links if l == tool)} refs)")
    print(f"- CTAs: mid={('rp-mid-cta' in body)} end={('btn btn-primary' in body)} faq={('rp-faq-cta' in body)}")
    for gl in guides:
        t = gl.replace("/guides/", "")
        if t in SLUGS and t != slug:
            inbound[t].append(slug)
    print()

print("## Inbound (Wave 2 cross-links)")
for s in SLUGS:
    print(f"- {s}: {len(inbound[s])} from {', '.join(set(inbound[s])) or 'none'}")
