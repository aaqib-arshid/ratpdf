#!/usr/bin/env python3
"""Snapshot: authority guides, generated fallbacks, blog, CSV programme rows."""
import csv
import re
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]
CONTENT = ROOT / "Content"


def slugs_in(files: list[Path]) -> set[str]:
    s: set[str] = set()
    for f in files:
        if not f.exists():
            continue
        for m in re.finditer(r'"([a-zA-Z0-9-]+)"\s*=>', f.read_text(encoding="utf-8")):
            s.add(m.group(1))
    return s


def main() -> None:
    authority = slugs_in(
        sorted(CONTENT.glob("GuideBodiesWave*.cs"))
        + [
            CONTENT / "GuideBodies.cs",
            CONTENT / "GuideBodiesExtended.cs",
            CONTENT / "GuideBodiesMedicalImageDev.cs",
        ]
    )
    generated = slugs_in([CONTENT / "GuideBodiesGenerated.cs"])
    blog = slugs_in([CONTENT / "BlogBodies.cs", CONTENT / "BlogBodiesExtended.cs"])

    rows = list(csv.DictReader(open(ROOT / "Data/pdf-article-opportunities.csv", encoding="utf-8")))
    by_action: dict[str, list[str]] = {}
    for r in rows:
        by_action.setdefault(r["action"], []).append(r["existing_slug"])

    thin_only = generated - authority
    upgrade_in_auth = sum(1 for s in by_action.get("UPGRADE", []) if s in authority)

    print(f"authority_pages={len(authority)}")
    print(f"generated_guide_slugs={len(generated)}")
    print(f"thin_generated_fallbacks={len(thin_only)}")
    print(f"guide_urls_with_body={len(authority | generated)}")
    print(f"blog_articles={len(blog)}")
    print(f"csv_programme_total={len(rows)}")
    print(f"csv_upgrade={len(by_action.get('UPGRADE', []))} (in_authority={upgrade_in_auth})")
    print(f"csv_create={len(by_action.get('CREATE', []))}")
    print(f"csv_maintain={len(by_action.get('MAINTAIN', []))}")


if __name__ == "__main__":
    main()
