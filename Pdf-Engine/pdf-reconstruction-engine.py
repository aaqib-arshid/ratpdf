#!/usr/bin/env python3
"""
PDF Layout Reconstruction Engine
Converts a PDF page into a structured JSON layout model for pixel-perfect HTML rendering.
"""

import sys
import json
import argparse
import base64
import math
from io import BytesIO
from typing import List, Dict, Any, Tuple, Optional

import fitz  # PyMuPDF
import pdfplumber
from PIL import Image


# ----------------------------------------------------------------------
# Helper: convert (r,g,b) to hex
# ----------------------------------------------------------------------
def rgb_to_hex(color_value) -> str:
    """
    Accepts either an integer (e.g. 0x000000), a tuple/list of 1-4 floats (0-1 or 0-255),
    or a string '#rrggbb'. Returns hex color string.
    """
    if color_value is None:
        return "#000000"
    if isinstance(color_value, str) and color_value.startswith('#'):
        return color_value
    if isinstance(color_value, int):
        r = (color_value >> 16) & 0xFF
        g = (color_value >> 8) & 0xFF
        b = color_value & 0xFF
        return f"#{r:02x}{g:02x}{b:02x}"
    if isinstance(color_value, (tuple, list)):
        r, g, b = color_value[0], color_value[1], color_value[2]
        if max(r, g, b) <= 1.0:
            r, g, b = int(r * 255), int(g * 255), int(b * 255)
        else:
            r, g, b = int(r), int(g), int(b)
        return f"#{r:02x}{g:02x}{b:02x}"
    return "#000000"


# ----------------------------------------------------------------------
# Font helpers
# ----------------------------------------------------------------------
def normalize_font(fontname: str) -> Tuple[str, str]:
    """Return (family, weight) from a PDF font name."""
    font_lower = fontname.lower()
    weight = "normal"
    if "bold" in font_lower:
        weight = "bold"
    if "times" in font_lower or "roman" in font_lower:
        family = "Times New Roman"
    elif "courier" in font_lower:
        family = "Courier New"
    elif "helvetica" in font_lower or "arial" in font_lower:
        family = "Arial"
    elif "symbol" in font_lower or "zapf" in font_lower:
        family = "Symbol"
    else:
        family = "Arial"
    return family, weight


# ----------------------------------------------------------------------
# Column detection for reading order
# ----------------------------------------------------------------------
def detect_columns(element_rects: List[Tuple[float, float, float, float]],
                   page_width: float) -> List[Tuple[float, float]]:
    if not element_rects:
        return [(0, page_width)]
    left_edges = [r[0] for r in element_rects]
    left_edges = sorted(set(left_edges))
    clusters = []
    current_cluster = [left_edges[0]]
    threshold = 20.0
    for i in range(1, len(left_edges)):
        if left_edges[i] - current_cluster[-1] <= threshold:
            current_cluster.append(left_edges[i])
        else:
            clusters.append(current_cluster)
            current_cluster = [left_edges[i]]
    clusters.append(current_cluster)
    merged = []
    prev_max = None
    for cl in clusters:
        cl_min = min(cl)
        cl_max = max(cl)
        if prev_max is not None and cl_min - prev_max < 20:
            merged[-1] = (merged[-1][0], cl_max)
        else:
            merged.append((cl_min, cl_max))
        prev_max = cl_max
    col_boundaries = []
    prev_xmax = 0.0
    for col_min, col_max in merged:
        col_boundaries.append((prev_xmax, col_max + (col_max - col_min) * 0.2))
        prev_xmax = col_max + (col_max - col_min) * 0.2
    if col_boundaries:
        col_boundaries[-1] = (col_boundaries[-1][0], page_width)
    else:
        col_boundaries.append((0, page_width))
    return col_boundaries


def assign_column(x: float, columns: List[Tuple[float, float]]) -> int:
    for i, (xmin, xmax) in enumerate(columns):
        if xmin <= x <= xmax:
            return i
    return min(range(len(columns)),
               key=lambda i: abs(x - (columns[i][0] + columns[i][1]) / 2))


# ----------------------------------------------------------------------
# Main extraction function
# ----------------------------------------------------------------------
def extract_pdf_layout(pdf_path: str) -> Dict[str, Any]:
    doc = fitz.open(pdf_path)
    pages_output = []
    pdf_plumb = pdfplumber.open(pdf_path)

    for page_num, page in enumerate(doc):
        page_rect = page.rect
        width = page_rect.width
        height = page_rect.height
        elements = []

        # ---- 1. Text elements ----
        text_blocks = page.get_text("dict")["blocks"]
        raw_text_spans = []
        for block in text_blocks:
            if block["type"] == 0:
                for line in block["lines"]:
                    for span in line["spans"]:
                        x0, y0, x1, y1 = span["bbox"]
                        text = span["text"]
                        if not text.strip():
                            continue
                        font_family, weight = normalize_font(span["font"])
                        font_size = span["size"]
                        color = rgb_to_hex(span["color"])
                        rotation = 0
                        elements.append({
                            "type": "text",
                            "text": text,
                            "x": x0,
                            "y": y0,
                            "width": x1 - x0,
                            "height": y1 - y0,
                            "fontFamily": font_family,
                            "fontSize": font_size,
                            "fontWeight": weight,
                            "color": color,
                            "rotation": rotation,
                            "zIndex": 0
                        })
                        raw_text_spans.append((x0, y0, x1, y1))

        # ---- 2. Shapes: lines and rectangles ----
        drawings = page.get_drawings()
        for draw in drawings:
            for item in draw["items"]:
                if item[0] == "l":
                    p1, p2 = item[1], item[2]
                    x0 = min(p1.x, p2.x)
                    y0 = min(p1.y, p2.y)
                    x1 = max(p1.x, p2.x)
                    y1 = max(p1.y, p2.y)
                    if abs(x1 - x0) < 0.1 and abs(y1 - y0) < 0.1:
                        continue
                    color = rgb_to_hex(draw["fill"]) if draw["fill"] else "#000000"
                    elements.append({
                        "type": "line",
                        "text": "",
                        "x": x0,
                        "y": y0,
                        "width": x1 - x0,
                        "height": y1 - y0,
                        "fontFamily": "",
                        "fontSize": 0,
                        "fontWeight": "",
                        "color": color,
                        "rotation": 0,
                        "zIndex": 1
                    })
                elif item[0] == "re":
                    rect = item[1]
                    x0, y0, x1, y1 = rect.x0, rect.y0, rect.x1, rect.y1
                    color = rgb_to_hex(draw["fill"]) if draw["fill"] else "#000000"
                    elements.append({
                        "type": "rectangle",
                        "text": "",
                        "x": x0,
                        "y": y0,
                        "width": x1 - x0,
                        "height": y1 - y0,
                        "fontFamily": "",
                        "fontSize": 0,
                        "fontWeight": "",
                        "color": color,
                        "rotation": 0,
                        "zIndex": 1
                    })

              # ---- 3. Images (preserve exact colors & transparency) ----
        image_list = page.get_images(full=True)
        for img in image_list:
            xref = img[0]
            placements = page.get_image_rects(xref, transform=True)
            for placement in placements:
                bbox, transform = placement
                x0, y0, x1, y1 = bbox.x0, bbox.y0, bbox.x1, bbox.y1
                data_uri = ""
                try:
                    # Render the page region containing the image (white page background included)
                    pix = page.get_pixmap(clip=fitz.Rect(x0, y0, x1, y1), dpi=150)
                    png_bytes = pix.tobytes("png")
                    img_base64 = base64.b64encode(png_bytes).decode()
                    data_uri = f"data:image/png;base64,{img_base64}"
                except Exception as e:
                    import traceback
                    traceback.print_exc(file=sys.stderr)
                    data_uri = ""

                a, b, c, d, e, f = transform
                rotation_angle = math.degrees(math.atan2(b, a)) if abs(a) > 1e-6 else 0.0

                elements.append({
                    "type": "image",
                    "text": "",
                    "x": x0,
                    "y": y0,
                    "width": x1 - x0,
                    "height": y1 - y0,
                    "fontFamily": "",
                    "fontSize": 0,
                    "fontWeight": "",
                    "color": "",
                    "rotation": rotation_angle,
                    "zIndex": 2,
                    "imageData": data_uri
                })

        # ---- 4. Tables using pdfplumber ----
        plumb_page = pdf_plumb.pages[page_num]
        tables = plumb_page.find_tables()
        table_bboxes = []
        for table in tables:
            tb_bbox = table.bbox
            x0, top, x1, bottom = tb_bbox
            table_bboxes.append((x0, top, x1, bottom))
            rows_data = []
            for row in table.rows:
                cells_in_row = []
                for cell in row.cells:
                    if cell is not None:
                        cx0, cy0, cx1, cy1 = cell
                        cell_text = plumb_page.crop((cx0, cy0, cx1, cy1)).extract_text() or ""
                        font_family, font_size, weight, color = "Arial", 10, "normal", "#000000"
                        for elem in elements:
                            if elem["type"] == "text":
                                tx = elem["x"]
                                ty = elem["y"]
                                tw = elem["width"]
                                th = elem["height"]
                                if (tx >= cx0 and ty >= cy0 and
                                    tx + tw <= cx1 and ty + th <= cy1):
                                    font_family = elem["fontFamily"]
                                    font_size = elem["fontSize"]
                                    weight = elem["fontWeight"]
                                    color = elem["color"]
                                    break
                        cells_in_row.append({
                            "text": cell_text.strip(),
                            "x": cx0,
                            "y": cy0,
                            "width": cx1 - cx0,
                            "height": cy1 - cy0,
                            "fontFamily": font_family,
                            "fontSize": font_size,
                            "fontWeight": weight,
                            "color": color
                        })
                if cells_in_row:
                    rows_data.append(cells_in_row)
            if rows_data:
                elements.append({
                    "type": "table",
                    "text": "",
                    "x": x0,
                    "y": top,
                    "width": x1 - x0,
                    "height": bottom - top,
                    "fontFamily": "",
                    "fontSize": 0,
                    "fontWeight": "",
                    "color": "",
                    "rotation": 0,
                    "zIndex": 3,
                    "rows": rows_data
                })

        # ---- Remove text inside tables ----
        if table_bboxes:
            new_elements = []
            for elem in elements:
                if elem["type"] == "text":
                    tx, ty, tw, th = elem["x"], elem["y"], elem["width"], elem["height"]
                    inside = False
                    for tbb in table_bboxes:
                        tbx, tby, tbw, tbh = tbb[0], tbb[1], tbb[2] - tbb[0], tbb[3] - tbb[1]
                        if (tx >= tbx and ty >= tby and
                            tx + tw <= tbx + tbw and ty + th <= tby + tbh):
                            inside = True
                            break
                    if not inside:
                        new_elements.append(elem)
                else:
                    new_elements.append(elem)
            elements = new_elements

        # ---- 5. Reading order ----
        all_rects_for_cols = []
        for elem in elements:
            if elem["type"] in ("text", "table"):
                all_rects_for_cols.append((elem["x"], elem["y"], elem["width"], elem["height"]))
        columns = detect_columns([(r[0], r[1], r[0]+r[2], r[1]+r[3]) for r in all_rects_for_cols], width)

        def sort_key(elem):
            x = elem["x"]
            y = elem["y"]
            col = assign_column(x, columns)
            return (col, y, x)

        elements.sort(key=sort_key)

        pages_output.append({
            "width": width,
            "height": height,
            "elements": elements
        })

    doc.close()
    pdf_plumb.close()
    return {"pages": pages_output}


# ----------------------------------------------------------------------
# CLI
# ----------------------------------------------------------------------
def main():
    parser = argparse.ArgumentParser(
        description="PDF Layout Reconstruction – outputs strict JSON for pixel-perfect HTML"
    )
    parser.add_argument("input_pdf", help="Path to the input PDF file")
    parser.add_argument("output_json", nargs="?", help="Path to output JSON file (default: stdout)")
    args = parser.parse_args()

    layout = extract_pdf_layout(args.input_pdf)
    json_str = json.dumps(layout, indent=2, ensure_ascii=False)

    if args.output_json:
        with open(args.output_json, "w", encoding="utf-8") as f:
            f.write(json_str)
        print(f"Layout JSON written to {args.output_json}")
    else:
        print(json_str)


if __name__ == "__main__":
    main()