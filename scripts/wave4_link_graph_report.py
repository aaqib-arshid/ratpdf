#!/usr/bin/env python3
"""Link graph report for Wave 4 upgraded guides."""
import re
from pathlib import Path

from wave4_expansions import WORKFLOW_DATA

WORKFLOW = list(WORKFLOW_DATA.keys())
COMPARE = [
    "pdf-to-word-without-word", "pdf-to-word-vs-google-docs", "pdf-to-word-vs-pdf-to-text",
    "pdf-to-word-garbled-text", "ocr-vs-pdf-to-text",
]
SLUGS = WORKFLOW + COMPARE

raw = Path(__file__).resolve().parents[1] / "Content" / "GuideBodiesWave4.cs"
text = raw.read_text(encoding="utf-8")
blocks = dict(zip(
    re.findall(r'"([\w-]+)" =>', text),
    re.findall(r'private const string \w+ = """(.*?)""";', text, re.S),
))

inbound = {s: [] for s in SLUGS}
print("# Wave 4 Link Graph Report\n")
for slug in SLUGS:
    body = blocks.get(slug, "")
    links = re.findall(r'href="(/[^"]+)"', body)
    guides = [l for l in links if l.startswith("/guides/")]
    research = [l for l in links if l.startswith("/research/")]
    compare = [l for l in links if l.startswith("/compare")]
    tool = "/pdf/ocrpdf" if slug == "ocr-vs-pdf-to-text" else "/pdf/pdftodoc"
    cluster = "pdf-to-word/compare" if slug in COMPARE else "pdf-to-word/workflow"
    print(f"## {slug}")
    print(f"- Cluster: {cluster}")
    print(f"- Outbound: {len(links)} | Research: {len(set(research))} | Compare: {len(set(compare))}")
    print(f"- Tool CTA: {tool} ({sum(1 for l in links if l == tool)} refs)")
    print(f"- CTAs: mid={('rp-mid-cta' in body)} end={('btn btn-primary' in body)} faq={('rp-faq-cta' in body)}")
    for gl in guides:
        t = gl.replace("/guides/", "")
        if t in SLUGS and t != slug:
            inbound[t].append(slug)
    print()

print("## Inbound (Wave 4 cross-links)")
for s in SLUGS:
    print(f"- {s}: {len(inbound[s])} from {', '.join(set(inbound[s])) or 'none'}")
