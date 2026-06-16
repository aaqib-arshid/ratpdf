#!/usr/bin/env python3
"""Mark roadmap rows Published when guide slug has a live body."""
import csv
import re
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]
ROADMAP = ROOT / "Data" / "content-roadmap.csv"

hand = set()
for f in ["GuideBodies.cs", "GuideBodiesExtended.cs", "GuideBodiesMedicalImageDev.cs", "GuideBodiesGenerated.cs"]:
    hand.update(re.findall(r'"([a-z0-9-]+)"\s*=>', (ROOT / "Content" / f).read_text(encoding="utf-8")))

rows = list(csv.DictReader(ROADMAP.open(encoding="utf-8-sig")))
fieldnames = rows[0].keys()
updated = 0
for row in rows:
    url = row.get("RecommendedURL", "")
    if not url.startswith("/guides/"):
        continue
    slug = url.replace("/guides/", "")
    if slug in hand and row.get("Status") in ("Planned", "Published"):
        if row["Status"] != "Published":
            row["Status"] = "Published"
            updated += 1

with ROADMAP.open("w", encoding="utf-8", newline="") as f:
    w = csv.DictWriter(f, fieldnames=fieldnames, quoting=csv.QUOTE_ALL)
    w.writeheader()
    w.writerows(rows)

print(f"Updated {updated} rows to Published. Live guide bodies: {len(hand)}")
