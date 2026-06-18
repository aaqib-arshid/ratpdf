#!/usr/bin/env python3
"""Extract text from two PDFs and compute similarity + diff-friendly output."""

from __future__ import annotations

import argparse
import difflib
import json
import os
import re
import sys

import fitz


def extract_plain_text(pdf_path: str) -> tuple[str, int]:
    doc = fitz.open(pdf_path)
    parts: list[str] = []
    try:
        page_count = doc.page_count
        for page in doc:
            text = (page.get_text("text") or "").strip()
            if text:
                parts.append(text)
    finally:
        doc.close()
    return "\n\n".join(parts), page_count


def normalize_lines(text: str) -> list[str]:
    lines: list[str] = []
    for raw in text.splitlines():
        line = re.sub(r"\s+", " ", raw).strip()
        if line:
            lines.append(line)
    return lines


def similarity_ratio(a: str, b: str) -> float:
    if not a and not b:
        return 100.0
    if not a or not b:
        return 0.0
    return round(difflib.SequenceMatcher(None, a, b).ratio() * 100, 1)


def main() -> int:
    parser = argparse.ArgumentParser(description="Compare two PDFs by extracted text")
    parser.add_argument("pdf_a")
    parser.add_argument("pdf_b")
    parser.add_argument("output_json")
    args = parser.parse_args()

    path_a = os.path.abspath(args.pdf_a)
    path_b = os.path.abspath(args.pdf_b)
    output_path = os.path.abspath(args.output_json)

    text_a, pages_a = extract_plain_text(path_a)
    text_b, pages_b = extract_plain_text(path_b)

    lines_a = normalize_lines(text_a)
    lines_b = normalize_lines(text_b)

    matcher = difflib.SequenceMatcher(None, lines_a, lines_b)
    added = removed = changed = 0
    for tag, i1, i2, j1, j2 in matcher.get_opcodes():
        if tag == "insert":
            added += j2 - j1
        elif tag == "delete":
            removed += i2 - i1
        elif tag == "replace":
            changed += max(i2 - i1, j2 - j1)

    unified = list(
        difflib.unified_diff(
            lines_a,
            lines_b,
            fromfile="Original",
            tofile="Revised",
            lineterm="",
        )
    )

    payload = {
        "similarityPercent": similarity_ratio(text_a, text_b),
        "textA": text_a,
        "textB": text_b,
        "pagesA": pages_a,
        "pagesB": pages_b,
        "wordCountA": len(text_a.split()),
        "wordCountB": len(text_b.split()),
        "linesAdded": added,
        "linesRemoved": removed,
        "linesChanged": changed,
        "unifiedDiff": unified[:500],
        "truncatedDiff": len(unified) > 500,
    }

    os.makedirs(os.path.dirname(output_path) or ".", exist_ok=True)
    with open(output_path, "w", encoding="utf-8") as f:
        json.dump(payload, f, ensure_ascii=False, indent=2)
    print(output_path)
    return 0


if __name__ == "__main__":
    sys.exit(main())
