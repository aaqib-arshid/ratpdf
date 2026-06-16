#!/usr/bin/env python3
"""Count visible words in Wave 13 guide bodies."""
import re
from pathlib import Path

from wave13_expansions import W13_SLUGS
from generate_wave13_bodies import body

TAG_RE = re.compile(r"<[^>]+>")
WS_RE = re.compile(r"\s+")


def visible_words(html: str) -> int:
    text = TAG_RE.sub(" ", html)
    return len(WS_RE.split(text.strip()))


def main():
    fails = []
    for slug in W13_SLUGS:
        n = visible_words(body(slug))
        status = "OK" if n >= 1500 else "LOW"
        print(f"{status:4} {n:5}  {slug}")
        if n < 1500:
            fails.append(slug)
    if fails:
        print(f"\nFAIL: {len(fails)} below 1500 words")
        raise SystemExit(1)
    print(f"\nAll {len(W13_SLUGS)} guides >= 1500 words")


if __name__ == "__main__":
    main()
