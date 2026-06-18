#!/usr/bin/env python3
"""Repair corrupt PDFs by rewriting structure with PyMuPDF garbage collection."""

from __future__ import annotations

import argparse
import os
import sys

import fitz


def repair_pdf(input_path: str, output_path: str) -> None:
    if not os.path.isfile(input_path):
        raise FileNotFoundError(f"PDF not found: {input_path}")

    doc = fitz.open(input_path)
    try:
        if doc.page_count == 0:
            raise ValueError("PDF has no readable pages.")
        doc.save(
            output_path,
            garbage=4,
            deflate=True,
            clean=True,
            pretty=False,
        )
    finally:
        doc.close()


def main() -> int:
    parser = argparse.ArgumentParser(description="Repair a PDF by rebuilding its structure")
    parser.add_argument("input_pdf")
    parser.add_argument("output_pdf")
    args = parser.parse_args()

    repair_pdf(os.path.abspath(args.input_pdf), os.path.abspath(args.output_pdf))
    print(args.output_pdf)
    return 0


if __name__ == "__main__":
    sys.exit(main())
