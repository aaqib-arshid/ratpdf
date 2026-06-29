#!/usr/bin/env python3
"""Measure text similarity between localized and source content."""
from __future__ import annotations

import re
from difflib import SequenceMatcher
from html import unescape


def strip_html(html: str) -> str:
    text = re.sub(r"<script[^>]*>.*?</script>", " ", html, flags=re.I | re.S)
    text = re.sub(r"<style[^>]*>.*?</style>", " ", text, flags=re.I | re.S)
    text = re.sub(r"<[^>]+>", " ", text)
    text = unescape(text)
    return re.sub(r"\s+", " ", text).strip().lower()


def similarity_ratio(a: str, b: str) -> float:
    if not a or not b:
        return 0.0
    return SequenceMatcher(None, a, b).ratio()


def word_count(html: str) -> int:
    text = strip_html(html)
    return len(text.split()) if text else 0


def check_uniqueness(
    localized_html: str,
    english_html: str,
    other_locale_htmls: dict[str, str] | None = None,
    *,
    warn_threshold: float = 0.60,
    target_english: float = 0.40,
) -> dict:
    loc_text = strip_html(localized_html)
    en_text = strip_html(english_html)
    en_sim = similarity_ratio(loc_text, en_text)

    locale_sims: dict[str, float] = {}
    flags: list[str] = []

    if en_sim > warn_threshold:
        flags.append(f"english_similarity_high:{en_sim:.2f}")
    elif en_sim > target_english:
        flags.append(f"english_similarity_warn:{en_sim:.2f}")

    for locale, html in (other_locale_htmls or {}).items():
        sim = similarity_ratio(loc_text, strip_html(html))
        locale_sims[locale] = sim
        if sim > warn_threshold:
            flags.append(f"locale_{locale}_similarity_high:{sim:.2f}")

    return {
        "englishSimilarity": round(en_sim, 4),
        "localeSimilarities": {k: round(v, 4) for k, v in locale_sims.items()},
        "wordCount": word_count(localized_html),
        "flags": flags,
        "passed": not flags,
    }
