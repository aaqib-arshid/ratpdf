#!/usr/bin/env python3
"""Extract PDF text and produce an extractive summary (no external API)."""

from __future__ import annotations

import argparse
import json
import os
import re
import sys

import fitz

_STOP_WORDS = frozenset(
    "the a an and or but in on at to for of is are was were be been being with as by from "
    "that this it its not you your we they their our can will would should may might".split()
)


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


def summarize_text(text: str, max_sentences: int) -> str:
    text = re.sub(r"\s+", " ", text).strip()
    if not text:
        return (
            "No extractable text was found in this PDF. "
            "It may be a scanned document — try the OCR PDF tool first, then summarize again."
        )

    sentences = re.split(r"(?<=[.!?])\s+", text)
    sentences = [s.strip() for s in sentences if len(s.strip()) >= 20]
    if not sentences:
        return text[:4000] + ("…" if len(text) > 4000 else "")
    if len(sentences) <= max_sentences:
        return " ".join(sentences)

    words = re.findall(r"\w+", text.lower())
    freq: dict[str, int] = {}
    for word in words:
        if len(word) > 3 and word not in _STOP_WORDS:
            freq[word] = freq.get(word, 0) + 1

    def score(sentence: str) -> int:
        return sum(freq.get(w.lower(), 0) for w in re.findall(r"\w+", sentence))

    top = sorted(sentences, key=score, reverse=True)[:max_sentences]
    order = {s: i for i, s in enumerate(sentences)}
    top.sort(key=lambda s: order[s])
    return " ".join(top)


def main() -> int:
    parser = argparse.ArgumentParser(description="Summarize PDF text extractively")
    parser.add_argument("input_pdf")
    parser.add_argument("output_json")
    parser.add_argument("--sentences", type=int, default=15)
    parser.add_argument("--max-pages", type=int, default=200)
    args = parser.parse_args()

    input_path = os.path.abspath(args.input_pdf)
    output_path = os.path.abspath(args.output_json)

    doc = fitz.open(input_path)
    page_count = doc.page_count
    doc.close()

    if page_count > args.max_pages:
        raise ValueError(
            f"PDF has {page_count} pages; maximum is {args.max_pages}. "
            "Upgrade to Pro or split the document first."
        )

    text, pages = extract_plain_text(input_path)
    word_count = len(text.split())
    summary = summarize_text(text, max(3, args.sentences))

    payload = {
        "summary": summary,
        "pageCount": pages,
        "wordCount": word_count,
        "sentenceTarget": args.sentences,
        "markdown": (
            f"# PDF Summary\n\n{summary}\n\n---\n*{pages} pages · {word_count:,} words extracted*"
        ),
    }

    os.makedirs(os.path.dirname(output_path) or ".", exist_ok=True)
    with open(output_path, "w", encoding="utf-8") as f:
        json.dump(payload, f, ensure_ascii=False, indent=2)
    print(output_path)
    return 0


if __name__ == "__main__":
    sys.exit(main())
