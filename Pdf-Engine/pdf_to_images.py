#!/usr/bin/env python3
"""Render PDF pages to PNG or JPEG files in an output directory (streaming, page-by-page)."""

from __future__ import annotations

import argparse
import os
import sys

import fitz


def render_pages(
    pdf_path: str,
    output_dir: str,
    dpi: int = 150,
    *,
    image_format: str = "png",
    jpeg_quality: int = 90,
) -> int:
    os.makedirs(output_dir, exist_ok=True)
    fmt = (image_format or "png").lower().strip()
    if fmt in ("jpeg", "jpg"):
        ext = "jpg"
        use_jpeg = True
    else:
        ext = "png"
        use_jpeg = False
    quality = max(50, min(100, int(jpeg_quality)))

    doc = fitz.open(pdf_path)
    try:
        zoom = dpi / 72.0
        matrix = fitz.Matrix(zoom, zoom)
        count = 0
        for i, page in enumerate(doc):
            pix = page.get_pixmap(matrix=matrix, alpha=False)
            out_path = os.path.join(output_dir, f"page_{i + 1:04d}.{ext}")
            if use_jpeg:
                pix.save(out_path, jpg_quality=quality)
            else:
                pix.save(out_path)
            pix = None  # release page bitmap promptly for large PDFs
            count += 1
        return count
    finally:
        doc.close()


def main() -> int:
    parser = argparse.ArgumentParser(description="PDF pages to PNG/JPEG images")
    parser.add_argument("pdf_path")
    parser.add_argument("output_dir")
    parser.add_argument("--dpi", type=int, default=150)
    parser.add_argument("--format", default="png", help="png or jpg/jpeg")
    parser.add_argument("--quality", type=int, default=90, help="JPEG quality 50-100")
    args = parser.parse_args()

    try:
        n = render_pages(
            args.pdf_path,
            args.output_dir,
            args.dpi,
            image_format=args.format,
            jpeg_quality=args.quality,
        )
        print(f"OK: rendered {n} page(s) as {args.format}")
        return 0
    except Exception as exc:
        print(f"ERROR: {exc}", file=sys.stderr)
        return 1


if __name__ == "__main__":
    raise SystemExit(main())
