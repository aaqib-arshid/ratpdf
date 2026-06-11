#!/usr/bin/env python3
"""
High-fidelity PDF text extraction with reading order (PyMuPDF blocks).
"""

from __future__ import annotations

import argparse
import os
import sys

import fitz


def extract_text(pdf_path: str) -> str:
    if not os.path.isfile(pdf_path):
        raise FileNotFoundError(f"PDF not found: {pdf_path}")

    doc = fitz.open(pdf_path)
    parts: list[str] = []
    try:
        for page_num, page in enumerate(doc, start=1):
            parts.append(f"--- Page {page_num} ---")
            blocks = page.get_text("blocks", sort=True)
            for block in blocks:
                if len(block) < 7 or block[6] != 0:
                    continue
                text = (block[4] or "").strip()
                if text:
                    parts.append(text)
            parts.append("")
    finally:
        doc.close()

    return "\n".join(parts).strip() + "\n"


def main() -> int:
    parser = argparse.ArgumentParser(description="Extract PDF text with reading order")
    parser.add_argument("input_pdf")
    parser.add_argument("output_txt", nargs="?")
    args = parser.parse_args()

    text = extract_text(os.path.abspath(args.input_pdf))
    if args.output_txt:
        out = os.path.abspath(args.output_txt)
        os.makedirs(os.path.dirname(out) or ".", exist_ok=True)
        with open(out, "w", encoding="utf-8") as f:
            f.write(text)
        print(out)
    else:
        sys.stdout.write(text)
    return 0


if __name__ == "__main__":
    sys.exit(main())
