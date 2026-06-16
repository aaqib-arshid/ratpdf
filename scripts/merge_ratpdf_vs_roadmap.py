#!/usr/bin/env python3
"""Mark ratpdf-vs-* roadmap entries as Merged (compare pages own those URLs)."""
import csv
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]
ROADMAP = ROOT / "Data" / "content-roadmap.csv"

rows = list(csv.DictReader(ROADMAP.open(encoding="utf-8-sig")))
fieldnames = rows[0].keys()
n = 0
for row in rows:
    url = row.get("RecommendedURL", "")
    if "/guides/ratpdf-vs-" in url:
        if row["Status"] != "Merged":
            row["Status"] = "Merged"
            n += 1

with ROADMAP.open("w", encoding="utf-8", newline="") as f:
    w = csv.DictWriter(f, fieldnames=fieldnames, quoting=csv.QUOTE_ALL)
    w.writeheader()
    w.writerows(rows)
print(f"Merged {n} ratpdf-vs-* rows")
