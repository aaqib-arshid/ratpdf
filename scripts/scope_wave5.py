#!/usr/bin/env python3
"""Find next wave candidates from SEO audit (excludes Waves 1-4 + Extended)."""
import json
import re
from collections import defaultdict
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]


def wave_slugs(path: str, marker: str, end: str | None = None) -> list[str]:
    text = (ROOT / path).read_text(encoding="utf-8")
    chunk = text.split(marker)[1]
    if end:
        chunk = chunk.split(end)[0]
    return re.findall(r'"([\w-]+)"', chunk)


w1 = wave_slugs("scripts/generate_wave1_bodies.py", "SLUGS = [", "]")
w2 = wave_slugs("scripts/generate_wave2_bodies.py", "SLUGS = [", "]")
w3 = wave_slugs("scripts/generate_wave3_bodies.py", "SLUGS = [", "]")
w4 = wave_slugs("scripts/generate_wave4_bodies.py", "SLUGS = [", "]")
ext = re.findall(
    r'"([\w-]+)" =>',
    (ROOT / "Content/GuideBodiesExtended.cs").read_text(encoding="utf-8").split("slug switch")[1].split("_ =>")[0],
)
done = set(w1 + w2 + w3 + w4 + ext)

audit = json.loads((ROOT / "Data/seo-audit-results.json").read_text(encoding="utf-8"))
pages = audit["summary"]["top_100_upgrade"]

cands = []
for p in pages:
    slug = p.get("slug", "")
    if slug in done:
        continue
    pri = p.get("priority", "")
    wc = p.get("word_count", 9999)
    cluster = p.get("cluster", "")
    if pri in ("P0", "P1") and wc < 500:
        cands.append((p.get("upgrade_roi", 0), p.get("traffic_roi", 0), pri, wc, slug, cluster))

cands.sort(reverse=True)
print(f"Done slugs: {len(done)} | Remaining P0/P1 thin in top_100: {len(cands)}\n")
print("Top 50 candidates:")
for row in cands[:50]:
    print(f"  roi={row[0]:4.1f} traffic={row[1]:4.1f} {row[2]} {row[3]:4d} {row[4]:40s} [{row[5]}]")

clusters = defaultdict(list)
for row in cands:
    slug = row[4]
    if slug.startswith("compress-"):
        clusters["compress"].append(slug)
    elif "pdf-to-text" in slug or slug.startswith("pdf-to-text"):
        clusters["pdf-to-text"].append(slug)
    elif slug.startswith("split-") or "organize-pdf" in slug or "extract-" in slug:
        clusters["split-edit"].append(slug)
    elif "combine-then-compress" in slug or slug == "batch-compress-pdf":
        clusters["compress-workflow"].append(slug)
    else:
        clusters["other"].append(slug)

print("\nClusters:")
for k, v in sorted(clusters.items(), key=lambda x: -len(x[1])):
    print(f"  {k}: {len(v)}")
    for s in v:
        print(f"    - {s}")
