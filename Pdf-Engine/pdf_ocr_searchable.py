#!/usr/bin/env python3
"""Add an invisible OCR text layer to scanned PDFs (page-by-page, constant memory)."""

from __future__ import annotations

import argparse
import io
import sys

import fitz

try:
    import pytesseract
    from PIL import Image
except ImportError:
    pytesseract = None
    Image = None


def _configure_tesseract() -> None:
    import os
    import shutil

    for cmd in ("/usr/bin/tesseract", "/usr/local/bin/tesseract"):
        if os.path.isfile(cmd):
            pytesseract.pytesseract.tesseract_cmd = cmd
            return
    found = shutil.which("tesseract")
    if found:
        pytesseract.pytesseract.tesseract_cmd = found


def make_searchable(input_pdf: str, output_pdf: str, dpi: int = 200) -> int:
    if pytesseract is None or Image is None:
        raise RuntimeError("pytesseract/Pillow not installed")

    _configure_tesseract()
    doc = fitz.open(input_pdf)
    zoom = dpi / 72.0
    matrix = fitz.Matrix(zoom, zoom)

    try:
        for page in doc:
            pix = page.get_pixmap(matrix=matrix, alpha=False)
            img = Image.frombytes("RGB", (pix.width, pix.height), pix.samples)
            data = pytesseract.image_to_data(img, output_type=pytesseract.Output.DICT)

            for i, word in enumerate(data["text"]):
                word = (word or "").strip()
                if not word:
                    continue
                x = data["left"][i] / zoom
                y = data["top"][i] / zoom
                w = data["width"][i] / zoom
                h = data["height"][i] / zoom
                rect = fitz.Rect(x, y, x + w, y + h)
                page.insert_textbox(
                    rect,
                    word,
                    fontsize=max(6, h * 0.8),
                    fontname="helv",
                    render_mode=3,
                )

        doc.save(output_pdf, garbage=4, deflate=True)
        return doc.page_count
    finally:
        doc.close()


def main() -> int:
    parser = argparse.ArgumentParser(description="OCR PDF to searchable PDF")
    parser.add_argument("input_pdf")
    parser.add_argument("output_pdf")
    parser.add_argument("--dpi", type=int, default=200)
    args = parser.parse_args()

    try:
        pages = make_searchable(args.input_pdf, args.output_pdf, args.dpi)
        print(f"OK: OCR applied to {pages} page(s)")
        return 0
    except Exception as exc:
        print(f"ERROR: {exc}", file=sys.stderr)
        return 1


if __name__ == "__main__":
    raise SystemExit(main())
