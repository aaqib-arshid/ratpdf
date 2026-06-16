#!/usr/bin/env python3
import re
from pathlib import Path

text = Path(__file__).resolve().parents[1] / "Content" / "GuideBodiesWave2.cs"
raw = text.read_text(encoding="utf-8")
blocks = re.findall(r'private const string \w+ = """(.*?)""";', raw, re.S)
slugs = re.findall(r'"([\w-]+)" =>', raw)
for slug, body in zip(slugs, blocks):
    plain = re.sub(r"<[^>]+>", " ", body)
    words = len(plain.split())
    print(f"{slug}: {words} words")
