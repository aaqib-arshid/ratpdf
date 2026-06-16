#!/usr/bin/env python3
"""Find Wave 6 candidates from SEO audit."""
import json
import re
from collections import defaultdict
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]


def wave_slugs(path: str) -> list[str]:
    text = (ROOT / path).read_text(encoding="utf-8")
    if "SLUGS = [" in text:
        chunk = text.split("SLUGS = [")[1].split("]")[0]
        return re.findall(r'"([\w-]+)"', chunk)
    if "WORKFLOW_SLUGS" in text:
        w = re.findall(r'"([\w-]+)"', text.split("WORKFLOW_SLUGS = list")[1].split("COMPARE_SLUGS")[0])
        c = re.findall(r'"([\w-]+)"', text.split("COMPARE_SLUGS = [")[1].split("SLUGS = ")[0])
        return w + c
    return re.findall(r'"([\w-]+)"', text.split("SLUGS = ")[1].split("\n\n")[0])


w1 = wave_slugs("scripts/generate_wave1_bodies.py")
w2 = wave_slugs("scripts/generate_wave2_bodies.py")
w3 = wave_slugs("scripts/generate_wave3_bodies.py")
w4 = wave_slugs("scripts/generate_wave4_bodies.py")
w5 = wave_slugs("scripts/generate_wave5_bodies.py")
ext = re.findall(
    r'"([\w-]+)" =>',
    (ROOT / "Content/GuideBodiesExtended.cs").read_text(encoding="utf-8").split("slug switch")[1].split("_ =>")[0],
)
done = set(w1 + w2 + w3 + w4 + w5 + ext)

audit = json.loads((ROOT / "Data/seo-audit-results.json").read_text(encoding="utf-8"))
pages = audit["summary"]["top_100_upgrade"]

cands = []
for p in pages:
    slug = p.get("slug", "")
    if slug in done:
        continue
    pri = p.get("priority", "")
    wc = p.get("word_count", 9999)
    if pri in ("P0", "P1") and wc < 500:
        cands.append((p.get("upgrade_roi", 0), pri, wc, slug, p.get("cluster", "")))

cands.sort(reverse=True)
print(f"Done: {len(done)} | Remaining thin P0/P1: {len(cands)}\nTop candidates:")
for row in cands[:35]:
    print(f"  {row[0]:4.1f} {row[1]} {row[2]:4d} {row[3]:42s} [{row[4]}]")

clusters = defaultdict(list)
for row in cands:
    s = row[3]
    if s in ("images-to-pdf", "powerpoint-to-pdf", "jpg-to-pdf", "png-to-pdf"):
        clusters["convert"].append(s)
    elif "edit" in s or "organize" in s or "extract-single" in s or "add-image" in s:
        clusters["edit-organize"].append(s)
    elif s.startswith("convert-") and "pdf-to-word" in s:
        clusters["convert-word"].append(s)
    elif "pdf-tools" in s or "extract-text" in s:
        clusters["other"].append(s)
    else:
        clusters["other"].append(s)
print("\nClusters:")
for k, v in sorted(clusters.items(), key=lambda x: -len(x[1])):
    print(f"  {k}: {', '.join(v)}")
