#!/usr/bin/env python3
"""Find Wave 4 candidates from SEO audit."""
import json
import re
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]

w1_text = (ROOT / "scripts/generate_wave1_bodies.py").read_text(encoding="utf-8")
w1 = re.findall(r'"([\w-]+)"', w1_text.split("SLUGS = [")[1].split("]")[0])
w2 = [
    "merge-password-protected-pdf", "merge-pdf-custom-order", "merge-pdf-online",
    "merge-pdf-visa-application", "merge-pdf-without-quality-loss", "merge-scanned-digital-pdf",
    "ocr-pdf-arabic", "ocr-pdf-chinese", "ocr-pdf-french", "ocr-pdf-german", "ocr-pdf-hindi",
    "ocr-pdf-japanese", "ocr-pdf-korean", "ocr-pdf-poor-quality", "ocr-pdf-portuguese",
    "ocr-pdf-russian", "ocr-pdf-spanish",
]
w3_text = (ROOT / "scripts/generate_wave3_bodies.py").read_text(encoding="utf-8")
w3c = re.findall(r'"([\w-]+)"', w3_text.split("COMPRESS_SLUGS = [")[1].split("COMPLIANCE_SLUGS = [")[0])
w3m = re.findall(r'"([\w-]+)"', w3_text.split("COMPLIANCE_SLUGS = [")[1].split("SLUGS = ")[0])
ext = re.findall(
    r'"([\w-]+)" =>',
    (ROOT / "Content/GuideBodiesExtended.cs").read_text(encoding="utf-8").split("slug switch")[1].split("_ =>")[0],
)
done = set(w1 + w2 + w3c + w3m + ext)

audit = json.loads((ROOT / "Data/seo-audit-results.json").read_text(encoding="utf-8"))
pages = audit["summary"]["top_100_upgrade"]
print(f"Using top_100_upgrade ({len(pages)} pages)")

cands = []
for p in pages:
    slug = p.get("slug", "")
    if slug in done:
        continue
    pri = p.get("priority", "")
    wc = p.get("word_count", 9999)
    if pri in ("P0", "P1") and wc < 500:
        cands.append((p.get("traffic_roi", 0), pri, wc, slug, p.get("title", ""), p.get("layer", "")))

cands.sort(reverse=True)
print("\nWave 4 candidates (top 50):")
for row in cands[:50]:
    print(f"{row[0]:5.1f} {row[1]} {row[2]:4d} {row[3]:45s} {row[5]}")
print(f"\nTotal candidates: {len(cands)}")

# cluster by prefix
from collections import defaultdict
clusters = defaultdict(list)
for row in cands:
    slug = row[3]
    if "pdf-to-word" in slug or "scanned-pdf" in slug:
        clusters["pdf-to-word"].append(slug)
    elif slug.startswith("compress-"):
        clusters["compress"].append(slug)
    elif slug.startswith("invoice-"):
        clusters["invoice"].append(slug)
    elif slug.startswith("merge-"):
        clusters["merge"].append(slug)
    elif "pdftotext" in slug or "pdf-to-text" in slug:
        clusters["pdf-to-text"].append(slug)
    else:
        clusters["other"].append(slug)
print("\nClusters:")
for k, v in sorted(clusters.items(), key=lambda x: -len(x[1])):
    print(f"  {k}: {len(v)} — {', '.join(v[:8])}{'...' if len(v)>8 else ''}")
