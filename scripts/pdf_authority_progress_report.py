#!/usr/bin/env python3
"""PDF Authority Progress Report — run after each execution batch."""
import csv
import json
import re
from datetime import date
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]
CONTENT = ROOT / "Content"
DATA = ROOT / "Data"
REPORTS = DATA / "progress-reports"
REPORTS.mkdir(exist_ok=True)

AUTHORITY_FILES = sorted(CONTENT.glob("GuideBodiesWave*.cs")) + [
    CONTENT / "GuideBodies.cs",
    CONTENT / "GuideBodiesExtended.cs",
    CONTENT / "GuideBodiesMedicalImageDev.cs",
]


def collect_slugs(files: list[Path]) -> set[str]:
    slugs: set[str] = set()
    for f in files:
        if not f.exists():
            continue
        for m in re.finditer(r'"([a-zA-Z0-9-]+)"\s*=>', f.read_text(encoding="utf-8")):
            slugs.add(m.group(1))
    return slugs


def main() -> None:
    authority = collect_slugs(AUTHORITY_FILES)
    rows = list(csv.DictReader(open(DATA / "pdf-article-opportunities.csv", encoding="utf-8")))

    by_action: dict[str, list] = {"UPGRADE": [], "CREATE": [], "MAINTAIN": []}
    for row in rows:
        by_action[row["action"]].append(row)

    upgrade_done = sum(1 for r in by_action["UPGRADE"] if r["existing_slug"] in authority)
    upgrade_total = len(by_action["UPGRADE"])
    upgrade_pct = 100 * upgrade_done / upgrade_total if upgrade_total else 0

    pending_upgrade = [
        r for r in by_action["UPGRADE"] if r["existing_slug"] not in authority
    ]
    pending_upgrade.sort(key=lambda r: (-int(r["priority_score"]), int(r["id"])))

    # Traffic opportunity proxy: sum priority scores
    done_score = sum(int(r["priority_score"]) for r in by_action["UPGRADE"] if r["existing_slug"] in authority)
    total_score = sum(int(r["priority_score"]) for r in by_action["UPGRADE"])
    score_pct = 100 * done_score / total_score if total_score else 0

    report = {
        "generated": str(date.today()),
        "authority_slugs_in_waves": len(authority),
        "upgrade_completed": upgrade_done,
        "upgrade_total": upgrade_total,
        "upgrade_coverage_pct": round(upgrade_pct, 1),
        "priority_score_captured_pct": round(score_pct, 1),
        "create_remaining": len(by_action["CREATE"]),
        "maintain_remaining": len(by_action["MAINTAIN"]),
        "top_10_pending_upgrade": [
            {
                "slug": r["existing_slug"],
                "keyword": r["keyword"],
                "score": int(r["priority_score"]),
                "cluster": r["cluster"],
            }
            for r in pending_upgrade[:10]
        ],
    }

    out_json = REPORTS / f"pdf-authority-progress-{date.today().isoformat()}.json"
    out_json.write_text(json.dumps(report, indent=2), encoding="utf-8")

    md = f"""# PDF Authority Progress Report — {date.today()}

## Coverage snapshot

| Metric | Value |
|--------|-------|
| Authority pages (wave + pillar layers) | **{len(authority)}** |
| UPGRADE completed | **{upgrade_done} / {upgrade_total}** ({upgrade_pct:.1f}%) |
| Priority score captured (UPGRADE) | **{score_pct:.1f}%** |
| CREATE remaining | **{len(by_action['CREATE'])}** |
| MAINTAIN remaining | **{len(by_action['MAINTAIN'])}** |

## Top pending UPGRADE (next execution)

"""
    for r in pending_upgrade[:15]:
        md += f"- **{r['existing_slug']}** (score {r['priority_score']}) — {r['keyword']}\n"

    md += """
## Notes

- Authority = slug present in GuideBodiesWave* / GuideBodies / GuideBodiesExtended / MedicalImageDev (excludes thin Generated templates).
- Programmatic URLs (e.g. `/pdf-to-txt/ocr-pdf-to-text`) may differ from CSV `target_url` — upgrade canonical URL per cannibalization report.
- Success metric = ranking potential and gap closure, not raw URL count.

"""
    out_md = REPORTS / f"pdf-authority-progress-{date.today().isoformat()}.md"
    out_md.write_text(md, encoding="utf-8")
    print(out_md.read_text(encoding="utf-8"))


if __name__ == "__main__":
    main()
