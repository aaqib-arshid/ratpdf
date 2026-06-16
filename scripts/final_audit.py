#!/usr/bin/env python3
import csv, re
from pathlib import Path
from collections import Counter

ROOT = Path(__file__).resolve().parents[1]
hand = set()
for f in ["GuideBodies.cs", "GuideBodiesExtended.cs", "GuideBodiesMedicalImageDev.cs", "GuideBodiesGenerated.cs"]:
    for m in re.finditer(r'"([^"]+)"\s*=>', (ROOT / "Content" / f).read_text(encoding="utf-8")):
        hand.add(m.group(1))
hand_lower = {s.lower() for s in hand}

rows = list(csv.DictReader((ROOT / "Data" / "content-roadmap.csv").open(encoding="utf-8-sig")))
guide_missing = []
non_guide = []
for r in rows:
    if r["Status"] in ("Merged", "Deferred"):
        continue
    u = r["RecommendedURL"]
    if u.startswith("/guides/"):
        slug = u.replace("/guides/", "")
        if slug.lower() not in hand_lower:
            guide_missing.append((r["Priority"], r["Status"], slug))
    elif u.startswith("/blog/"):
        pass
    elif u.startswith("/compare/"):
        pass
    else:
        non_guide.append((r["Priority"], r["Status"], u))

print("Live guide bodies:", len(hand))
print("Roadmap /guides/ missing body:", len(guide_missing))
for g in guide_missing[:20]:
    print(" ", g)
print("Non-/guides/ editorial (need separate routes):", len(non_guide))
print("By priority:", dict(Counter(x[0] for x in non_guide)))
for n in non_guide[:15]:
    print(" ", n)
print("Roadmap status:", dict(Counter(r["Status"] for r in rows)))
