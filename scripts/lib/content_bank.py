#!/usr/bin/env python3
"""Load locale-native intros, FAQs, and pro tips from scripts/data/."""
from __future__ import annotations

import json
from functools import lru_cache
from pathlib import Path

from lib.category_infer import slug_hash

DATA_DIR = Path(__file__).resolve().parents[1] / "data"

LOCALE_FILE_KEY = {
    "pt-BR": "pt",
    "es": "es",
    "de": "de",
    "id": "id",
    "fr": "fr",
}


@lru_cache(maxsize=20)
def _load_json(name: str) -> dict:
    path = DATA_DIR / name
    if not path.exists():
        raise FileNotFoundError(f"Missing content bank file: {path}")
    return json.loads(path.read_text(encoding="utf-8"))


def _file_key(locale_key: str) -> str:
    return LOCALE_FILE_KEY.get(locale_key, locale_key.split("-")[0])


def load_faqs(locale_key: str) -> dict:
    return _load_json(f"faqs_{_file_key(locale_key)}.json")


def load_intros(locale_key: str) -> dict:
    return _load_json(f"intros_{_file_key(locale_key)}.json")


def load_tips(locale_key: str) -> dict:
    return _load_json(f"tips_{_file_key(locale_key)}.json")


def pick_intro(locale_key: str, slug: str, keyword: str, category: str) -> str:
    data = load_intros(locale_key)
    templates = data["templates"]
    actions = data["category_actions"].get(category, data["category_actions"]["convert"])
    action = actions[slug_hash(slug, "action") % len(actions)]
    benefits = data["benefits"]
    benefit = benefits[slug_hash(slug, "benefit") % len(benefits)]
    template = templates[slug_hash(slug, "intro") % len(templates)]
    action_cap = action[0].upper() + action[1:] if action else keyword
    return template.format(
        action=action,
        Action=action_cap,
        keyword=keyword,
        benefit=benefit,
        category=category,
    )


def pick_faqs(locale_key: str, slug: str, category: str, count: int = 3) -> list[dict]:
    bank = load_faqs(locale_key)
    pool = bank["categories"].get(category, bank["categories"]["convert"])["faqs"]
    if len(pool) <= count:
        return list(pool)
    start = slug_hash(slug, "faq") % len(pool)
    picked = []
    for i in range(count):
        picked.append(pool[(start + i) % len(pool)])
    return picked


def pick_tips(locale_key: str, slug: str, category: str, count: int = 3) -> list[str]:
    bank = load_tips(locale_key)
    pool = bank["categories"].get(category, bank["categories"]["convert"])["tips"]
    if len(pool) <= count:
        return list(pool)
    start = slug_hash(slug, "tips") % len(pool)
    return [pool[(start + i) % len(pool)] for i in range(count)]


def section_labels(locale_key: str) -> dict[str, str]:
    data = load_intros(locale_key)
    return data.get("section_labels", {})
