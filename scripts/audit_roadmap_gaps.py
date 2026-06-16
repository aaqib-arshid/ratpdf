#!/usr/bin/env python3
import csv, re
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]
lib = set(re.findall(r'\("([a-z0-9-]+)"', (ROOT / "Content" / "ContentLibrary.cs").read_text(encoding="utf-8")))

road = list(csv.DictReader((ROOT / "Data" / "content-roadmap.csv").open(encoding="utf-8-sig")))
planned_guides = []
for r in road:
    url = r["RecommendedURL"]
    if not url.startswith("/guides/"):
        continue
    slug = url.replace("/guides/", "")
    if slug in lib:
        continue
    if r["Status"] in ("Merged", "Deferred"):
        continue
    planned_guides.append(r)

from collections import Counter
print("Planned/ Published roadmap guides NOT in ContentLibrary (excl merged/deferred):", len(planned_guides))
print("By priority:", dict(Counter(r["Priority"] for r in planned_guides)))
print("By status:", dict(Counter(r["Status"] for r in planned_guides)))
print("Sample:")
for r in planned_guides[:20]:
    print(f"  {r['Priority']} {r['Status']} {r['RecommendedURL']} | {r['PrimaryKeyword']}")

# Guide slugs in lib - verify all have bodies via GuideBodies chain
guide_meta = (ROOT / "Content" / "ContentLibrary.cs").read_text(encoding="utf-8")
# count only BuildGuides section - approximate: blogs are at end
blog_slugs = set(re.findall(r'\("([a-z0-9-]+)", "[^"]+", "[^"]+", "(?:PDF|Business|Security|Developer|Image|Writing|Lifestyle|Network)"', 
    (ROOT / "Content" / "ContentLibrary.cs").read_text(encoding="utf-8").split("BuildBlogs")[0]))
hand = set()
for f in ["GuideBodies.cs", "GuideBodiesExtended.cs", "GuideBodiesMedicalImageDev.cs", "GuideBodiesGenerated.cs"]:
    hand.update(re.findall(r'"([a-z0-9-]+)" =>', (ROOT / "Content" / f).read_text(encoding="utf-8")))
missing_guide_bodies = sorted(s for s in lib if s not in blog_slugs and s not in hand)
print("\nGuide slugs (excl blogs) in lib:", len(lib - blog_slugs))
print("Missing guide bodies:", len(missing_guide_bodies), missing_guide_bodies)
