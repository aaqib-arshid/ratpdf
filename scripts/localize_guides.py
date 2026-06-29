#!/usr/bin/env python3
"""Generate unique localized guides — dictionary engine v2, no external APIs.

Usage:
  python scripts/localize_guides.py --week 1
  python scripts/localize_guides.py --locale pt-BR --limit 50 --priority-only
  python scripts/localize_guides.py --status
  python scripts/localize_guides.py --import-dir ./handoff/pt --locale pt-BR
"""
from __future__ import annotations

import argparse
import json
import shutil
import sys
from datetime import datetime, timezone
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]
sys.path.insert(0, str(ROOT / "scripts"))

from lib.guide_catalog import export_manifest, load_guides  # noqa: E402
from lib.guide_localizer import localize_guide  # noqa: E402
from lib.uniqueness_checker import check_uniqueness  # noqa: E402
from localization_locales import LOCALES  # noqa: E402

OUT_ROOT = ROOT / "Content" / "LocalizedGuides"
LOG_PATH = ROOT / "Data" / "localization-log.jsonl"

# Rollout plan: submit high-priority pages to GSC in waves
WEEK_PLANS: dict[int, dict] = {
    1: {"locales": ["pt-BR"], "limit": 50, "offset": 0},
    2: {"locales": ["es", "id"], "limit": 50, "offset": 0},
    3: {"locales": ["de", "fr"], "limit": 50, "offset": 0},
    4: {"locales": ["pt-BR", "es", "de", "id", "fr"], "limit": 100, "offset": 50},
}


def output_path(locale_key: str, slug: str) -> Path:
    prefix = LOCALES[locale_key]["url_prefix"]
    return OUT_ROOT / prefix / f"{slug}.json"


def read_guide_body(locale_key: str, slug: str) -> str | None:
    path = output_path(locale_key, slug)
    if not path.exists():
        return None
    try:
        return json.loads(path.read_text(encoding="utf-8")).get("bodyHtml", "")
    except (json.JSONDecodeError, OSError):
        return None


def is_localized(locale_key: str, slug: str) -> bool:
    body = read_guide_body(locale_key, slug)
    return bool(body and body.strip())


def append_log(entry: dict) -> None:
    LOG_PATH.parent.mkdir(parents=True, exist_ok=True)
    with LOG_PATH.open("a", encoding="utf-8") as f:
        f.write(json.dumps(entry, ensure_ascii=False) + "\n")


def write_guide(result: dict, locale_key: str) -> Path:
    out = output_path(locale_key, result["slug"])
    out.parent.mkdir(parents=True, exist_ok=True)
    out.write_text(json.dumps(result, ensure_ascii=False, indent=2) + "\n", encoding="utf-8")
    return out


def select_guides(guides: list[dict], offset: int, limit: int, priority_only: bool) -> list[dict]:
    if priority_only:
        guides = [g for g in guides if g.get("searchScore", 0) >= 6]
    guides = sorted(guides, key=lambda g: (-g.get("searchScore", 0), g["slug"]))
    if offset:
        guides = guides[offset:]
    if limit:
        guides = guides[:limit]
    return guides


def localize_one(
    guide: dict,
    locale_key: str,
    all_guides: list[dict],
    dry_run: bool,
    force: bool,
) -> str:
    slug = guide["slug"]
    out = output_path(locale_key, slug)
    if not force and is_localized(locale_key, slug):
        return "skip"

    if dry_run:
        print(f"[dry-run] {locale_key} {slug} -> {out}")
        return "dry-run"

    try:
        result = localize_guide(guide, locale_key, all_guides)

        other_bodies: dict[str, str] = {}
        for other_locale in LOCALES:
            if other_locale == locale_key:
                continue
            body = read_guide_body(other_locale, slug)
            if body:
                other_bodies[other_locale] = body

        uniqueness = check_uniqueness(
            result["bodyHtml"],
            guide.get("bodyHtml", ""),
            other_bodies,
        )
        if uniqueness.get("englishSimilarity", 0) > 0.55:
            from lib.slug_paragraphs import build_slug_paragraphs
            from lib.guide_localizer import pad_to_min_words, infer_keyword
            from lib.category_infer import infer_category

            cat = infer_category(slug, guide.get("toolUrl"))
            kw = infer_keyword(slug, locale_key)
            extra = build_slug_paragraphs(locale_key, slug, cat, kw, count=6)
            extra_html = "".join(f"<p>{p}</p>" for p in extra)
            result["bodyHtml"] = pad_to_min_words(
                result["bodyHtml"] + "<h2>Mais detalhes</h2>" + extra_html,
                locale_key,
                cat,
                slug,
                kw,
            )
            uniqueness = check_uniqueness(
                result["bodyHtml"],
                guide.get("bodyHtml", ""),
                other_bodies,
            )

        result["uniqueness"] = uniqueness
        result["wordCount"] = uniqueness.get("wordCount", result.get("wordCount", 0))

        write_guide(result, locale_key)
        log_entry = {
            "ts": datetime.now(timezone.utc).isoformat(),
            "slug": slug,
            "locale": locale_key,
            "status": "ok",
            "path": str(out.relative_to(ROOT)),
            "generator": result.get("generator"),
            "wordCount": result.get("wordCount"),
            "englishSimilarity": uniqueness["englishSimilarity"],
            "flags": uniqueness["flags"],
        }
        append_log(log_entry)
        if uniqueness["flags"]:
            print(f"FLAG {slug} ({locale_key}): {', '.join(uniqueness['flags'])}", file=sys.stderr)
        return "ok"
    except Exception as exc:  # noqa: BLE001
        append_log(
            {
                "ts": datetime.now(timezone.utc).isoformat(),
                "slug": slug,
                "locale": locale_key,
                "status": "error",
                "error": str(exc),
            }
        )
        print(f"ERROR {slug} ({locale_key}): {exc}", file=sys.stderr)
        return "error"


def import_from_dir(import_dir: Path, locale_key: str, force: bool) -> int:
    prefix = LOCALES[locale_key]["url_prefix"]
    count = 0
    for src in sorted(import_dir.glob("*.json")):
        slug = src.stem
        if not force and is_localized(locale_key, slug):
            continue
        dest = output_path(locale_key, slug)
        dest.parent.mkdir(parents=True, exist_ok=True)
        shutil.copy2(src, dest)
        count += 1
    print(f"Imported {count} guides -> Content/LocalizedGuides/{prefix}/")
    return count


def print_status() -> None:
    guides = load_guides()
    total = len(guides)
    print(f"English guides: {total}\n")
    for locale_key, loc in LOCALES.items():
        done = sum(1 for g in guides if is_localized(locale_key, g["slug"]))
        pct = (done / total * 100) if total else 0
        print(f"  {locale_key:6} ({loc['url_prefix']}): {done:4}/{total} ({pct:.1f}%)")


def main() -> int:
    parser = argparse.ArgumentParser(description="Localize RatPDF guides (unique dictionary engine)")
    parser.add_argument("--locale", choices=list(LOCALES.keys()))
    parser.add_argument("--all-locales", action="store_true")
    parser.add_argument("--week", type=int, choices=sorted(WEEK_PLANS.keys()), help="Rollout week (1-4)")
    parser.add_argument("--slug")
    parser.add_argument("--limit", type=int, default=0)
    parser.add_argument("--offset", type=int, default=0)
    parser.add_argument("--priority-only", action="store_true")
    parser.add_argument("--force", action="store_true")
    parser.add_argument("--dry-run", action="store_true")
    parser.add_argument("--export-manifest", action="store_true")
    parser.add_argument("--status", action="store_true")
    parser.add_argument("--import-dir", type=Path)
    args = parser.parse_args()

    if args.status:
        print_status()
        return 0

    if args.import_dir:
        if not args.locale:
            parser.error("--import-dir requires --locale")
        import_from_dir(args.import_dir, args.locale, args.force)
        return 0

    locales: list[str]
    limit = args.limit
    offset = args.offset

    if args.week:
        plan = WEEK_PLANS[args.week]
        locales = plan["locales"]
        limit = limit or plan["limit"]
        offset = offset or plan["offset"]
        print(f"Week {args.week}: locales={locales} limit={limit} offset={offset}")
    elif args.all_locales:
        locales = list(LOCALES.keys())
    elif args.locale:
        locales = [args.locale]
    else:
        parser.error("Specify --week, --locale, --all-locales, --status, or --import-dir")

    if args.export_manifest:
        export_manifest()

    all_guides = load_guides()
    guides = select_guides(all_guides, offset, 0 if args.slug else limit, args.priority_only)
    if args.slug:
        guides = [g for g in all_guides if g["slug"] == args.slug]
        if not guides:
            print(f"Slug not found: {args.slug}", file=sys.stderr)
            return 1

    totals: dict[str, int] = {}
    for locale_key in locales:
        for guide in guides:
            status = localize_one(guide, locale_key, all_guides, args.dry_run, args.force)
            totals[status] = totals.get(status, 0) + 1

    print(
        f"Done — ok: {totals.get('ok', 0)}, skipped: {totals.get('skip', 0)}, "
        f"errors: {totals.get('error', 0)}, dry-run: {totals.get('dry-run', 0)}"
    )
    return 0 if totals.get("error", 0) == 0 else 1


if __name__ == "__main__":
    raise SystemExit(main())
