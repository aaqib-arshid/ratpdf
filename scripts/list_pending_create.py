#!/usr/bin/env python3
"""List pending CREATE slugs not yet in authority layers."""
import csv
import re
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]
CONTENT = ROOT / "Content"
AUTHORITY_FILES = sorted(CONTENT.glob("GuideBodiesWave*.cs")) + [
    CONTENT / "GuideBodies.cs",
    CONTENT / "GuideBodiesExtended.cs",
    CONTENT / "GuideBodiesMedicalImageDev.cs",
]

authority: set[str] = set()
for f in AUTHORITY_FILES:
    if not f.exists():
        continue
    for m in re.finditer(r'"([a-zA-Z0-9-]+)"\s*=>', f.read_text(encoding="utf-8")):
        authority.add(m.group(1))

creates: list[tuple] = []
with open(ROOT / "Data/pdf-article-opportunities.csv", encoding="utf-8") as f:
    for row in csv.DictReader(f):
        if row["action"] != "CREATE":
            continue
        slug = row["target_url"].replace("/guides/", "").strip("/")
        done = slug in authority
        creates.append(
            (
                int(row["priority_score"]),
                int(row["id"]),
                slug,
                done,
                row["keyword"],
                row["cluster"],
            )
        )

pending = [c for c in creates if not c[3]]
pending.sort(key=lambda x: (-x[0], x[1]))
done = len(creates) - len(pending)
print(f"CREATE total={len(creates)} done={done} pending={len(pending)}")
limit = int(__import__("sys").argv[1]) if len(__import__("sys").argv) > 1 else 20
for c in pending[:limit]:
    print(f"  score={c[0]:3d} id={c[1]:4d} {c[2]:50s} | {c[4][:45]}")
