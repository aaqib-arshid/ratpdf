#!/usr/bin/env python3
"""Extract embedded images from a PDF into an output directory."""

from __future__ import annotations

import argparse
import os
import sys

from image_extractor import extract_images


def main() -> int:
    parser = argparse.ArgumentParser(description="Extract images from PDF")
    parser.add_argument("pdf_path")
    parser.add_argument("output_dir")
    args = parser.parse_args()

    try:
        os.makedirs(args.output_dir, exist_ok=True)
        images = extract_images(args.pdf_path)
        if not images:
            print("ERROR: No images found in PDF", file=sys.stderr)
            return 1

        for idx, img in enumerate(images, start=1):
            ext = "png" if "png" in img.mime_type else "jpg"
            path = os.path.join(args.output_dir, f"image_p{img.page_num + 1}_{idx:04d}.{ext}")
            with open(path, "wb") as f:
                f.write(img.image_bytes)

        print(f"OK: extracted {len(images)} image(s)")
        return 0
    except Exception as exc:
        print(f"ERROR: {exc}", file=sys.stderr)
        return 1


if __name__ == "__main__":
    raise SystemExit(main())
