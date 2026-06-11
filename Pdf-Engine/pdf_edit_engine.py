#!/usr/bin/env python3
"""
Adobe-style PDF editing engine using PyMuPDF.

- extract_editable_model: text spans with exact PDF coordinates
- apply_edits: redactions, text replacement, new text, images on the original PDF
"""

from __future__ import annotations

import argparse
import base64
import json
import sys
from typing import Any, Dict, List, Tuple

import fitz  # PyMuPDF

from pdf_parser import normalize_font, rgb_to_hex


FONT_MAP = {
    "arial": "helv",
    "helvetica": "helv",
    "times new roman": "tiro",
    "times": "tiro",
    "courier new": "cour",
    "courier": "cour",
    "georgia": "tiro",
    "calibri": "helv",
    "verdana": "helv",
}


def _pdf_font(family: str, bold: bool = False, italic: bool = False) -> str:
    """Map to PyMuPDF Base-14 font names."""
    key = (family or "Arial").lower()
    if "courier" in key:
        if bold and italic:
            return "cobi"
        if bold:
            return "cobo"
        if italic:
            return "coit"
        return "cour"
    if "times" in key or "roman" in key or "georgia" in key:
        if bold and italic:
            return "tibi"
        if bold:
            return "tibo"
        if italic:
            return "tiit"
        return "tiro"
    # Helvetica / Arial default
    if bold and italic:
        return "hebi"
    if bold:
        return "hebo"
    if italic:
        return "heit"
    return "helv"


def _hex_to_rgb(hex_color: str) -> Tuple[float, float, float]:
    if not hex_color or not hex_color.startswith("#") or len(hex_color) < 7:
        return (0.0, 0.0, 0.0)
    try:
        r = int(hex_color[1:3], 16) / 255.0
        g = int(hex_color[3:5], 16) / 255.0
        b = int(hex_color[5:7], 16) / 255.0
        return (r, g, b)
    except ValueError:
        return (0.0, 0.0, 0.0)


def extract_editable_model(pdf_path: str) -> Dict[str, Any]:
    """Extract per-page text spans for in-place overlay editing."""
    doc = fitz.open(pdf_path)
    pages_out: List[Dict[str, Any]] = []

    try:
        for page_num, page in enumerate(doc):
            rect = page.rect
            spans: List[Dict[str, Any]] = []
            data = page.get_text("dict", flags=fitz.TEXT_PRESERVE_WHITESPACE)

            for block in data.get("blocks", []):
                if block.get("type") != 0:
                    continue
                for line in block.get("lines", []):
                    line_spans = [
                        s for s in line.get("spans", [])
                        if (s.get("text") or "").strip()
                    ]
                    if not line_spans:
                        continue

                    # Merge all spans on one line into a single hit region to avoid
                    # dozens of overlapping HTML layers on top of the canvas text.
                    parts: List[str] = []
                    x0 = min(s["bbox"][0] for s in line_spans)
                    y0 = min(s["bbox"][1] for s in line_spans)
                    x1 = max(s["bbox"][2] for s in line_spans)
                    y1 = max(s["bbox"][3] for s in line_spans)
                    primary = max(line_spans, key=lambda s: len(s.get("text", "")))
                    family, bold, italic = normalize_font(primary.get("font", ""))
                    font_size = round(primary.get("size", 11), 1)
                    color = rgb_to_hex(primary.get("color"))

                    for s in line_spans:
                        parts.append(s.get("text", ""))

                    merged_text = "".join(parts)
                    if not merged_text.strip():
                        continue

                    spans.append({
                        "id": f"p{page_num}s{len(spans)}",
                        "text": merged_text,
                        "x": round(x0, 2),
                        "y": round(y0, 2),
                        "width": round(x1 - x0, 2),
                        "height": round(y1 - y0, 2),
                        "fontSize": font_size,
                        "fontFamily": family,
                        "bold": bold,
                        "italic": italic,
                        "color": color,
                    })

            pages_out.append({
                "pageNum": page_num,
                "width": round(rect.width, 2),
                "height": round(rect.height, 2),
                "spans": spans,
            })
    finally:
        doc.close()

    return {
        "pageCount": len(pages_out),
        "pages": pages_out,
    }


def _edit_val(edit: Dict[str, Any], key: str, default: Any = None) -> Any:
    """Read edit field supporting camelCase (from C#) or PascalCase."""
    if key in edit:
        return edit[key]
    pascal = key[0].upper() + key[1:] if key else key
    if pascal in edit:
        return edit[pascal]
    return default


def apply_edits(pdf_path: str, output_path: str, edits: List[Dict[str, Any]]) -> None:
    """
    Apply annotation edits directly on the PDF object structure.

    Edit types:
      - whiteout: permanent white redaction
      - text_replace: redact region + insert new text (in-place edit)
      - text_add: insert new text box
      - image: insert image at rectangle
      - highlight: semi-transparent yellow highlight rectangle
    """
    doc = fitz.open(pdf_path)

    try:
        redact_by_page: Dict[int, List[fitz.Rect]] = {i: [] for i in range(doc.page_count)}
        text_ops: List[Dict[str, Any]] = []
        image_ops: List[Dict[str, Any]] = []
        highlight_ops: List[Dict[str, Any]] = []

        for raw in edits:
            page_idx = int(_edit_val(raw, "page", 0))
            if page_idx < 0 or page_idx >= doc.page_count:
                continue

            etype = str(_edit_val(raw, "type", "") or "")
            pad = 2.0 if etype == "text_replace" else 0.0
            x = float(_edit_val(raw, "x", 0)) - pad
            y = float(_edit_val(raw, "y", 0)) - pad
            w = float(_edit_val(raw, "width", 0)) + pad * 2
            h = float(_edit_val(raw, "height", 0)) + pad * 2
            rect = fitz.Rect(x, y, x + max(w, 1), y + max(h, 1))

            op = {**raw, "_rect": rect}
            if etype in ("whiteout", "text_replace"):
                redact_by_page[page_idx].append(rect)
                if etype == "text_replace":
                    text_ops.append(op)
            elif etype == "text_add":
                text_ops.append(op)
            elif etype == "image":
                image_ops.append(op)
            elif etype == "highlight":
                highlight_ops.append(op)

        # Phase 1: redactions (whiteout + text replacement areas)
        for page_idx, rects in redact_by_page.items():
            if not rects:
                continue
            page = doc[page_idx]
            for rect in rects:
                page.add_redact_annot(rect, fill=(1, 1, 1))
            page.apply_redactions(images=fitz.PDF_REDACT_IMAGE_NONE)

        # Phase 2: highlights (drawn under new text)
        for edit in highlight_ops:
            page = doc[int(_edit_val(edit, "page", 0))]
            color = _hex_to_rgb(str(_edit_val(edit, "color", "#ffff00") or "#ffff00"))
            shape = page.new_shape()
            shape.draw_rect(edit["_rect"])
            shape.finish(color=color, fill=color, fill_opacity=0.35)
            shape.commit()

        # Phase 3: images
        for edit in image_ops:
            page = doc[int(_edit_val(edit, "page", 0))]
            b64 = str(_edit_val(edit, "imageBase64", "") or "")
            if b64.startswith("data:"):
                b64 = b64.split(",", 1)[-1]
            try:
                img_bytes = base64.b64decode(b64)
                if img_bytes:
                    page.insert_image(edit["_rect"], stream=img_bytes, keep_proportion=True)
            except Exception:
                pass

        # Phase 4: text insertions
        for edit in text_ops:
            page_idx = int(_edit_val(edit, "page", 0))
            page = doc[page_idx]
            text = str(_edit_val(edit, "text", "") or "")
            if not text.strip():
                continue

            font_size = float(_edit_val(edit, "fontSize", 12) or 12)
            family = str(_edit_val(edit, "fontFamily", "Arial") or "Arial")
            bold = bool(_edit_val(edit, "bold", False))
            italic = bool(_edit_val(edit, "italic", False))
            color = _hex_to_rgb(str(_edit_val(edit, "color", "#000000") or "#000000"))
            fontname = _pdf_font(family, bold, italic)
            rect = edit["_rect"]

            box = fitz.Rect(
                rect.x0, rect.y0, rect.x1,
                max(rect.y1, rect.y0 + font_size * 4),
            )
            overflow = page.insert_textbox(
                box,
                text,
                fontname=fontname,
                fontsize=font_size,
                color=color,
                align=fitz.TEXT_ALIGN_LEFT,
            )
            if overflow < 0:
                baseline_y = rect.y0 + font_size * 0.85
                page.insert_text(
                    (rect.x0, baseline_y),
                    text,
                    fontname=fontname,
                    fontsize=font_size,
                    color=color,
                )

        doc.save(output_path, garbage=4, deflate=True)
    finally:
        doc.close()


def main() -> int:
    parser = argparse.ArgumentParser(description="PDF edit engine")
    sub = parser.add_subparsers(dest="command", required=True)

    extract_p = sub.add_parser("extract", help="Extract editable text model JSON")
    extract_p.add_argument("pdf_path")
    extract_p.add_argument("output_json", nargs="?")

    apply_p = sub.add_parser("apply", help="Apply edits JSON to PDF")
    apply_p.add_argument("pdf_path")
    apply_p.add_argument("edits_json_path")
    apply_p.add_argument("output_pdf")

    args = parser.parse_args()

    if args.command == "extract":
        model = extract_editable_model(args.pdf_path)
        out = json.dumps(model, ensure_ascii=False, indent=2)
        if args.output_json:
            with open(args.output_json, "w", encoding="utf-8") as f:
                f.write(out)
        else:
            print(out)
        return 0

    if args.command == "apply":
        with open(args.edits_json_path, "r", encoding="utf-8") as f:
            payload = json.load(f)
        edits = payload.get("edits", payload if isinstance(payload, list) else [])
        apply_edits(args.pdf_path, args.output_pdf, edits)
        print(args.output_pdf)
        return 0

    return 1


if __name__ == "__main__":
    sys.exit(main())
