"""
Image extraction with position data from PyMuPDF.
"""

from __future__ import annotations

import base64
import math
from dataclasses import dataclass
from io import BytesIO
from typing import List

import fitz  # PyMuPDF


@dataclass
class ExtractedImage:
    page_num: int
    x: float
    y: float
    width: float
    height: float
    image_bytes: bytes
    mime_type: str = "image/png"
    rotation: float = 0.0
    z_index: int = 2


def _extract_image_bytes(doc: fitz.Document, xref: int) -> tuple[bytes, str]:
    """Return raw image bytes and best mime type."""
    try:
        base = doc.extract_image(xref)
        if base and base.get("image"):
            ext = base.get("ext", "png")
            mime = {
                "png": "image/png",
                "jpg": "image/jpeg",
                "jpeg": "image/jpeg",
                "gif": "image/gif",
                "bmp": "image/bmp",
                "tiff": "image/tiff",
            }.get(ext, "image/png")
            return base["image"], mime
    except Exception:
        pass
    return b"", "image/png"


def extract_images(pdf_path: str, render_fallback_dpi: int = 300) -> List[ExtractedImage]:
    """
    Extract images with placement rectangles.

    Uses embedded image streams when available; falls back to rendering the
    clipped page region for complex vector/image composites.
    """
    doc = fitz.open(pdf_path)
    images: List[ExtractedImage] = []

    try:
        for page_num, page in enumerate(doc):
            seen_rects: set[tuple[int, int, int, int]] = set()

            for img_info in page.get_images(full=True):
                xref = img_info[0]
                placements = page.get_image_rects(xref, transform=True)
                img_bytes, mime = _extract_image_bytes(doc, xref)

                for placement in placements:
                    bbox, transform = placement
                    x0, y0, x1, y1 = bbox.x0, bbox.y0, bbox.x1, bbox.y1
                    rect_key = (int(x0), int(y0), int(x1), int(y1))
                    if rect_key in seen_rects:
                        continue
                    seen_rects.add(rect_key)

                    a, b, _, _, _, _ = transform
                    rotation = math.degrees(math.atan2(b, a)) if abs(a) > 1e-6 else 0.0
                    data = img_bytes

                    if not data or len(data) < 16:
                        try:
                            pix = page.get_pixmap(
                                clip=fitz.Rect(x0, y0, x1, y1),
                                dpi=render_fallback_dpi,
                            )
                            data = pix.tobytes("png")
                            mime = "image/png"
                        except Exception:
                            continue

                    images.append(
                        ExtractedImage(
                            page_num=page_num,
                            x=x0,
                            y=y0,
                            width=x1 - x0,
                            height=y1 - y0,
                            image_bytes=data,
                            mime_type=mime,
                            rotation=rotation,
                        )
                    )
    finally:
        doc.close()

    return images


def images_by_page(images: List[ExtractedImage]) -> dict[int, List[ExtractedImage]]:
    result: dict[int, List[ExtractedImage]] = {}
    for img in images:
        result.setdefault(img.page_num, []).append(img)
    return result


def image_to_data_uri(image: ExtractedImage) -> str:
    encoded = base64.b64encode(image.image_bytes).decode("ascii")
    return f"data:{image.mime_type};base64,{encoded}"


def image_to_stream(image: ExtractedImage) -> BytesIO:
    return BytesIO(image.image_bytes)
