#!/usr/bin/env python3
"""Render PDF pages to PNG files in an output directory (streaming, page-by-page)."""

from __future__ import annotations

import argparse
import sys

import fitz


def render_pages(pdf_path: str, output_dir: str, dpi: int = 150) -> int:
    import os

    os.makedirs(output_dir, exist_ok=True)
    doc = fitz.open(pdf_path)
    try:
        zoom = dpi / 72.0
        matrix = fitz.Matrix(zoom, zoom)
        count = 0
        for i, page in enumerate(doc):
            pix = page.get_pixmap(matrix=matrix, alpha=False)
            out_path = os.path.join(output_dir, f"page_{i + 1:04d}.png")
            pix.save(out_path)
            count += 1
        return count
    finally:
        doc.close()


def main() -> int:
    parser = argparse.ArgumentParser(description="PDF pages to PNG images")
    parser.add_argument("pdf_path")
    parser.add_argument("output_dir")
    parser.add_argument("--dpi", type=int, default=150)
    args = parser.parse_args()

    try:
        n = render_pages(args.pdf_path, args.output_dir, args.dpi)
        print(f"OK: rendered {n} page(s)")
        return 0
    except Exception as exc:
        print(f"ERROR: {exc}", file=sys.stderr)
        return 1


if __name__ == "__main__":
    raise SystemExit(main())
