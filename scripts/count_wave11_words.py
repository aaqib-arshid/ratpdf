#!/usr/bin/env python3
"""Count words in Wave 11 guide bodies."""
import re
import sys
from pathlib import Path

sys.path.insert(0, str(Path(__file__).resolve().parent))

from wave11_expansions import W11_SLUGS

CS = Path(__file__).resolve().parents[1] / "Content" / "GuideBodiesWave11.cs"
text = CS.read_text(encoding="utf-8")

for slug in W11_SLUGS:
    const = slug.replace("-", "_").title().replace("_", "")
    m = re.search(
        rf'private const string {const} = """\s*(.*?)\s*""";',
        text,
        re.DOTALL,
    )
    if not m:
        print(f"{slug}: MISSING")
        continue
    body = re.sub(r"<[^>]+>", " ", m.group(1))
    words = len(body.split())
    ok = "OK" if words >= 1500 else "LOW"
    print(f"{slug}: {words} {ok}")
