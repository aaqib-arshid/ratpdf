#!/usr/bin/env python3
import csv, re
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]
lib = set(re.findall(r'\("([a-z0-9-]+)"', (ROOT / "Content" / "ContentLibrary.cs").read_text(encoding="utf-8")))
hand = set()
for f in ["GuideBodies.cs", "GuideBodiesExtended.cs", "GuideBodiesMedicalImageDev.cs", "GuideBodiesGenerated.cs"]:
    hand.update(re.findall(r'"([a-z0-9-]+)" =>', (ROOT / "Content" / f).read_text(encoding="utf-8")))
gen = set(re.findall(r'"([a-z0-9-]+)" =>', (ROOT / "Content" / "GuideBodiesGenerated.cs").read_text(encoding="utf-8")))

no_body = sorted(s for s in lib if s not in hand and s not in gen)
print("ContentLibrary slugs:", len(lib))
print("Guide bodies total:", len(hand | gen))
print("Guides without body:", len(no_body))
if no_body:
    print("  ", no_body[:20])

road = list(csv.DictReader((ROOT / "Data" / "content-roadmap.csv").open(encoding="utf-8-sig")))
guide_road = [r for r in road if r["RecommendedURL"].startswith("/guides/")]
road_slugs = {r["RecommendedURL"].replace("/guides/", ""): r for r in guide_road}
missing_lib = sorted(s for s in road_slugs if s not in lib)
print("Roadmap /guides/ entries:", len(road_slugs))
print("Roadmap slugs NOT in ContentLibrary:", len(missing_lib))
if missing_lib:
    print("  sample:", missing_lib[:15])

from collections import Counter
print("Roadmap status:", dict(Counter(r["Status"] for r in road)))
print("P0 without lib entry:", sum(1 for r in road if r["Priority"]=="P0" and r["RecommendedURL"].startswith("/guides/") and r["RecommendedURL"].replace("/guides/","") not in lib))
