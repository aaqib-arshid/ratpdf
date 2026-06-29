#!/usr/bin/env python3
"""Find related guides in the same category for internal linking."""
from __future__ import annotations

from lib.category_infer import infer_category, slug_hash


def build_category_index(guides: list[dict]) -> dict[str, list[dict]]:
    index: dict[str, list[dict]] = {}
    for g in guides:
        cat = infer_category(g["slug"], g.get("toolUrl"))
        index.setdefault(cat, []).append(g)
    for cat in index:
        index[cat].sort(key=lambda x: (-x.get("searchScore", 0), x["slug"]))
    return index


def find_related(
    guide: dict,
    all_guides: list[dict],
    count: int = 3,
) -> list[dict]:
    cat = infer_category(guide["slug"], guide.get("toolUrl"))
    index = build_category_index(all_guides)
    pool = [g for g in index.get(cat, []) if g["slug"] != guide["slug"]]
    if len(pool) < count:
        extras = [
            g for g in all_guides
            if g["slug"] != guide["slug"] and g not in pool
        ]
        extras.sort(key=lambda x: (-x.get("searchScore", 0), x["slug"]))
        pool.extend(extras)
    if not pool:
        return []
    start = slug_hash(guide["slug"], "related") % len(pool)
    picked = []
    for i in range(min(count, len(pool))):
        picked.append(pool[(start + i) % len(pool)])
    return picked


def localized_href(url_prefix: str, slug: str) -> str:
    return f"/{url_prefix}/guides/{slug}"
