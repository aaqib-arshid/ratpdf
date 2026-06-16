#!/usr/bin/env python3
"""Mark remaining Planned roadmap rows Published when route type is non-guide but implemented."""
import csv
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]
ROADMAP = ROOT / "Data" / "content-roadmap.csv"

# Routes that exist outside /guides/ (programmatic, blog, research, vertical landings)
IMPLEMENTED_PREFIXES = (
    "/blog/", "/research/", "/compare/", "/invoice/", "/compress-",
    "/pdf-to-txt/", "/pdf-to-word/", "/edit-pdf/", "/bulk-payslip-generator",
    "/free-payslip-generator", "/pdf-tools-for-", "/compress-aadhar-pdf",
)

rows = list(csv.DictReader(ROADMAP.open(encoding="utf-8-sig")))
fieldnames = rows[0].keys()
n = 0
for row in rows:
    if row.get("Status") != "Planned":
        continue
    url = row.get("RecommendedURL", "")
    if url.startswith("/guides/glossary-toUnicode"):
        row["Status"] = "Published"
        n += 1
        continue
    if any(url.startswith(p) for p in IMPLEMENTED_PREFIXES):
        row["Status"] = "Published"
        n += 1

with ROADMAP.open("w", encoding="utf-8", newline="") as f:
    w = csv.DictWriter(f, fieldnames=fieldnames, quoting=csv.QUOTE_ALL)
    w.writeheader()
    w.writerows(rows)
print(f"Marked {n} Planned rows as Published")
