#!/usr/bin/env python3
"""Link graph report for Wave 3 upgraded guides."""
import re
from pathlib import Path

COMPRESS = [
    "compress-before-merge-pdf", "compress-pdf-cloud-storage", "compress-pdf-for-printing",
    "compress-pdf-with-images", "compress-pdf-without-quality-loss", "compress-pdf-common-app",
    "compress-pdf-digilocker", "compress-pdf-gst-portal", "compress-pdf-schengen-visa",
    "compress-pdf-insurance-claims", "compress-pdf-efiling", "compress-pdf-for-government-forms",
]
COMPLIANCE = [
    "gst-invoice-format-india", "e-invoicing-india-pdf", "pdf-redaction-permanent",
    "wcag-22-pdf", "gdpr-pdf-redaction",
]
SLUGS = COMPRESS + COMPLIANCE

raw = Path(__file__).resolve().parents[1] / "Content" / "GuideBodiesWave3.cs"
text = raw.read_text(encoding="utf-8")
blocks = dict(zip(
    re.findall(r'"([\w-]+)" =>', text),
    re.findall(r'private const string \w+ = """(.*?)""";', text, re.S),
))

inbound = {s: [] for s in SLUGS}
print("# Wave 3 Link Graph Report\n")
for slug in SLUGS:
    body = blocks.get(slug, "")
    links = re.findall(r'href="(/[^"]+)"', body)
    guides = [l for l in links if l.startswith("/guides/")]
    research = [l for l in links if l.startswith("/research/")]
    compare = [l for l in links if l.startswith("/compare")]
    if slug in COMPRESS:
        tool = "/pdf/compress"
        cluster = "compress"
    elif slug in ("gst-invoice-format-india",):
        tool = "/invoice/create"
        cluster = "compliance/gst"
    elif slug == "e-invoicing-india-pdf":
        tool = "/invoice/bulk"
        cluster = "compliance/e-invoice"
    elif slug == "wcag-22-pdf":
        tool = "/pdf/pdftotext"
        cluster = "compliance/wcag"
    else:
        tool = "/pdf-redaction"
        cluster = "compliance/redaction"
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

print("## Inbound (Wave 3 cross-links)")
for s in SLUGS:
    print(f"- {s}: {len(inbound[s])} from {', '.join(set(inbound[s])) or 'none'}")
