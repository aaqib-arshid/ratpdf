#!/usr/bin/env python3
"""Accurate UPGRADE audit — wave authority vs thin generated templates."""
import csv
import re
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]
CONTENT = ROOT / "Content"

# Authority layers (exclude GuideBodiesGenerated thin templates)
AUTHORITY_FILES = sorted(CONTENT.glob("GuideBodiesWave*.cs")) + [
    CONTENT / "GuideBodies.cs",
    CONTENT / "GuideBodiesExtended.cs",
    CONTENT / "GuideBodiesMedicalImageDev.cs",
]

GENERATED = CONTENT / "GuideBodiesGenerated.cs"


def collect_slugs(files: list[Path]) -> set[str]:
    slugs: set[str] = set()
    for f in files:
        if not f.exists():
            continue
        text = f.read_text(encoding="utf-8")
        for m in re.finditer(r'"([a-zA-Z0-9-]+)"\s*=>', text):
            slugs.add(m.group(1))
    return slugs


def main() -> None:
    authority = collect_slugs(AUTHORITY_FILES)
    generated = collect_slugs([GENERATED])
    thin_only = generated - authority

    upgrades: list[tuple] = []
    with open(ROOT / "Data/pdf-article-opportunities.csv", encoding="utf-8") as f:
        for row in csv.DictReader(f):
            if row["action"] != "UPGRADE":
                continue
            slug = row["existing_slug"]
            done = slug in authority
            thin = slug in thin_only
            upgrades.append(
                (
                    int(row["priority_score"]),
                    int(row["id"]),
                    slug,
                    done,
                    thin,
                    row["keyword"],
                    row["cluster"],
                    row["target_url"],
                )
            )

    pending = [u for u in upgrades if not u[3]]
    pending.sort(key=lambda x: (-x[0], x[1]))
    done_count = sum(1 for u in upgrades if u[3])

    print(f"UPGRADE total={len(upgrades)} authority={done_count} pending={len(pending)}")
    print(f"Thin generated slugs (not in authority): {len(thin_only)}")
    print(f"\nTop 40 pending UPGRADE (not in authority layers):")
    for u in pending[:40]:
        flag = " [thin template]" if u[4] else " [missing body]"
        print(f"  score={u[0]:3d} {u[2]:45s}{flag} | {u[5][:40]}")

    # Glossary breakdown
    gloss_pending = [u for u in pending if u[2].startswith("glossary-")]
    print(f"\nGlossary pending: {len(gloss_pending)}")
    for u in gloss_pending[:30]:
        print(f"  {u[2]}")

    creates = sum(1 for row in csv.DictReader(open(ROOT / "Data/pdf-article-opportunities.csv", encoding="utf-8")) if row["action"] == "CREATE")
    maintains = sum(1 for row in csv.DictReader(open(ROOT / "Data/pdf-article-opportunities.csv", encoding="utf-8")) if row["action"] == "MAINTAIN")
    print(f"\nCREATE rows: {creates} | MAINTAIN rows: {maintains}")
    print(f"Authority coverage: {done_count}/{len(upgrades)} = {100*done_count/len(upgrades):.1f}%")


if __name__ == "__main__":
    main()
