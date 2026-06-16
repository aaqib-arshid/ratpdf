#!/usr/bin/env python3
"""Link graph report for Wave 6 upgraded guides."""
import re
from pathlib import Path

from wave6_expansions import CONVERT_DATA, EDIT_DATA, WORD_W6_DATA

CONVERT = list(CONVERT_DATA.keys())
EDIT = list(EDIT_DATA.keys())
WORD = list(WORD_W6_DATA.keys())
COMPARE = ["pdf-tools-small-business"]
SLUGS = CONVERT + EDIT + WORD + COMPARE

raw = Path(__file__).resolve().parents[1] / "Content" / "GuideBodiesWave6.cs"
text = raw.read_text(encoding="utf-8")
blocks = dict(zip(
    re.findall(r'"([\w-]+)" =>', text),
    re.findall(r'private const string \w+ = """(.*?)""";', text, re.S),
))

inbound = {s: [] for s in SLUGS}
print("# Wave 6 Link Graph Report\n")
for slug in SLUGS:
    body = blocks.get(slug, "")
    links = re.findall(r'href="(/[^"]+)"', body)
    guides = [l for l in links if l.startswith("/guides/")]
    research = [l for l in links if l.startswith("/research/")]
    compare = [l for l in links if l.startswith("/compare")]
    if slug in CONVERT:
        tool = CONVERT_DATA[slug]["tool"]
        cluster = "convert"
    elif slug in EDIT:
        tool = EDIT_DATA[slug]["tool"]
        cluster = "edit-organize"
    elif slug in WORD:
        tool = "/pdf/doctopdf" if slug == "word-to-pdf-without-adobe" else "/pdf/pdftodoc"
        cluster = "pdf-to-word"
    else:
        tool = "/compare"
        cluster = "compare-smb"
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

print("## Inbound (Wave 6 cross-links)")
for s in SLUGS:
    print(f"- {s}: {len(inbound[s])} from {', '.join(set(inbound[s])) or 'none'}")
