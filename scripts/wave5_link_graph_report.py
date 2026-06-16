#!/usr/bin/env python3
"""Link graph report for Wave 5 upgraded guides."""
import re
from pathlib import Path

from wave5_expansions import COMPRESS_PLATFORM_DATA, COMPRESS_PORTAL_DATA, TEXT_DATA, SPLIT_DATA

PLATFORM = list(COMPRESS_PLATFORM_DATA.keys())
PORTAL = list(COMPRESS_PORTAL_DATA.keys())
COMPRESS = ["compress-pdf-made-it-larger", "batch-compress-pdf", "combine-then-compress-pdf"]
TEXT = list(TEXT_DATA.keys())
SPLIT = list(SPLIT_DATA.keys())
SLUGS = PLATFORM + PORTAL + COMPRESS + TEXT + SPLIT

raw = Path(__file__).resolve().parents[1] / "Content" / "GuideBodiesWave5.cs"
text = raw.read_text(encoding="utf-8")
blocks = dict(zip(
    re.findall(r'"([\w-]+)" =>', text),
    re.findall(r'private const string \w+ = """(.*?)""";', text, re.S),
))

inbound = {s: [] for s in SLUGS}
print("# Wave 5 Link Graph Report\n")
for slug in SLUGS:
    body = blocks.get(slug, "")
    links = re.findall(r'href="(/[^"]+)"', body)
    guides = [l for l in links if l.startswith("/guides/")]
    research = [l for l in links if l.startswith("/research/")]
    compare = [l for l in links if l.startswith("/compare")]
    if slug in TEXT or slug == "extract-text-without-adobe":
        tool = "/pdf/pdftotext"
        cluster = "pdf-to-text"
    elif slug in SPLIT:
        tool = "/pdf/split"
        cluster = "split"
    elif slug == "combine-then-compress-pdf":
        tool = "/pdf/merge"
        cluster = "compress-workflow"
    else:
        tool = "/pdf/compress"
        cluster = "compress-platform" if slug in PLATFORM else "compress-portal" if slug in PORTAL else "compress"
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

print("## Inbound (Wave 5 cross-links)")
for s in SLUGS:
    print(f"- {s}: {len(inbound[s])} from {', '.join(set(inbound[s])) or 'none'}")
