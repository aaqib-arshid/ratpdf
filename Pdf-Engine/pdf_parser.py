"""
Layout-aware PDF parsing using PyMuPDF (fitz).

Extracts text spans, reading order, multi-column structure, and header/footer regions.
"""

from __future__ import annotations

import re
from dataclasses import dataclass, field
from typing import Any, Dict, List, Optional, Tuple

import fitz  # PyMuPDF


# ---------------------------------------------------------------------------
# Data models
# ---------------------------------------------------------------------------

@dataclass
class TextSpan:
    text: str
    x: float
    y: float
    width: float
    height: float
    font_family: str = "Arial"
    font_size: float = 11.0
    bold: bool = False
    italic: bool = False
    color: str = "#000000"
    column: int = 0
    region: str = "body"  # body | header | footer


@dataclass
class PageLayout:
    page_num: int
    width: float
    height: float
    text_spans: List[TextSpan] = field(default_factory=list)
    column_boundaries: List[Tuple[float, float]] = field(default_factory=list)
    header_spans: List[TextSpan] = field(default_factory=list)
    footer_spans: List[TextSpan] = field(default_factory=list)
    body_spans: List[TextSpan] = field(default_factory=list)
    is_multi_column: bool = False


@dataclass
class DocumentLayout:
    pages: List[PageLayout] = field(default_factory=list)
    is_scanned: bool = False


# ---------------------------------------------------------------------------
# Helpers
# ---------------------------------------------------------------------------

def rgb_to_hex(color_value: Any) -> str:
    if color_value is None:
        return "#000000"
    if isinstance(color_value, str) and color_value.startswith("#"):
        return color_value
    if isinstance(color_value, int):
        r = (color_value >> 16) & 0xFF
        g = (color_value >> 8) & 0xFF
        b = color_value & 0xFF
        return f"#{r:02x}{g:02x}{b:02x}"
    if isinstance(color_value, (tuple, list)) and len(color_value) >= 3:
        r, g, b = color_value[0], color_value[1], color_value[2]
        if max(r, g, b) <= 1.0:
            r, g, b = int(r * 255), int(g * 255), int(b * 255)
        else:
            r, g, b = int(r), int(g), int(b)
        return f"#{r:02x}{g:02x}{b:02x}"
    return "#000000"


def normalize_font(fontname: str) -> Tuple[str, bool, bool]:
    """Return (family, bold, italic) from a PDF font name."""
    name = (fontname or "").lower()
    bold = "bold" in name or "black" in name or "heavy" in name
    italic = "italic" in name or "oblique" in name
    if "times" in name or "roman" in name:
        family = "Times New Roman"
    elif "courier" in name:
        family = "Courier New"
    elif "calibri" in name:
        family = "Calibri"
    elif "georgia" in name:
        family = "Georgia"
    elif "symbol" in name or "zapf" in name:
        family = "Symbol"
    else:
        family = "Arial"
    return family, bold, italic


def detect_columns(
    element_rects: List[Tuple[float, float, float, float]],
    page_width: float,
) -> List[Tuple[float, float]]:
    if not element_rects:
        return [(0.0, page_width)]

    left_edges = sorted({r[0] for r in element_rects})
    clusters: List[List[float]] = []
    current = [left_edges[0]]
    threshold = max(20.0, page_width * 0.04)

    for edge in left_edges[1:]:
        if edge - current[-1] <= threshold:
            current.append(edge)
        else:
            clusters.append(current)
            current = [edge]
    clusters.append(current)

    merged: List[Tuple[float, float]] = []
    prev_max: Optional[float] = None
    for cluster in clusters:
        cmin, cmax = min(cluster), max(cluster)
        if prev_max is not None and cmin - prev_max < threshold:
            merged[-1] = (merged[-1][0], cmax)
        else:
            merged.append((cmin, cmax))
        prev_max = cmax

    boundaries: List[Tuple[float, float]] = []
    prev_xmax = 0.0
    for col_min, col_max in merged:
        pad = (col_max - col_min) * 0.15
        boundaries.append((prev_xmax, col_max + pad))
        prev_xmax = col_max + pad

    if boundaries:
        boundaries[-1] = (boundaries[-1][0], page_width)
    else:
        boundaries.append((0.0, page_width))
    return boundaries


def assign_column(x: float, columns: List[Tuple[float, float]]) -> int:
    for i, (xmin, xmax) in enumerate(columns):
        if xmin <= x <= xmax:
            return i
    return min(
        range(len(columns)),
        key=lambda i: abs(x - (columns[i][0] + columns[i][1]) / 2),
    )


def reading_order_key(span: TextSpan) -> Tuple[int, float, float]:
    return (span.column, span.y, span.x)


def group_into_paragraphs(
    spans: List[TextSpan],
    line_gap_factor: float = 1.6,
) -> List[List[TextSpan]]:
    """Group spans into paragraph blocks without merging across large vertical gaps."""
    if not spans:
        return []

    ordered = sorted(spans, key=reading_order_key)
    paragraphs: List[List[TextSpan]] = []
    current: List[TextSpan] = [ordered[0]]
    prev_bottom = ordered[0].y + ordered[0].height
    prev_col = ordered[0].column
    prev_size = ordered[0].font_size or 11.0

    for span in ordered[1:]:
        gap = span.y - prev_bottom
        max_gap = prev_size * line_gap_factor
        same_col = span.column == prev_col
        if same_col and gap <= max_gap:
            current.append(span)
        else:
            paragraphs.append(current)
            current = [span]
        prev_bottom = span.y + span.height
        prev_col = span.column
        prev_size = span.font_size or prev_size

    paragraphs.append(current)
    return paragraphs


# ---------------------------------------------------------------------------
# Header / footer detection
# ---------------------------------------------------------------------------

_HEADER_RATIO = 0.10
_FOOTER_RATIO = 0.10
_MIN_REPEAT_PAGES = 2


def _normalize_header_footer_text(text: str) -> str:
    return re.sub(r"\s+", " ", text.strip().lower())


def _detect_repeated_edge_lines(
    page_edge_texts: List[List[str]],
) -> set[str]:
    """Find text strings that repeat on enough pages to be header/footer."""
    counts: Dict[str, int] = {}
    for texts in page_edge_texts:
        for t in set(texts):
            if t:
                counts[t] = counts.get(t, 0) + 1
    threshold = max(_MIN_REPEAT_PAGES, len(page_edge_texts) // 3)
    return {t for t, c in counts.items() if c >= threshold}


def classify_header_footer(
    pages_raw: List[Tuple[float, List[TextSpan]]],
) -> None:
    """Mutates spans in-place, setting region to header/footer/body."""
    header_candidates: List[List[str]] = []
    footer_candidates: List[List[str]] = []

    for height, spans in pages_raw:
        header_y = height * _HEADER_RATIO
        footer_y = height * (1.0 - _FOOTER_RATIO)
        header_candidates.append(
            [
                _normalize_header_footer_text(s.text)
                for s in spans
                if s.y < header_y and s.text.strip()
            ]
        )
        footer_candidates.append(
            [
                _normalize_header_footer_text(s.text)
                for s in spans
                if s.y + s.height > footer_y and s.text.strip()
            ]
        )

    repeated_headers = _detect_repeated_edge_lines(header_candidates)
    repeated_footers = _detect_repeated_edge_lines(footer_candidates)

    for (height, spans) in pages_raw:
        header_y = height * _HEADER_RATIO
        footer_y = height * (1.0 - _FOOTER_RATIO)
        for span in spans:
            norm = _normalize_header_footer_text(span.text)
            if span.y < header_y and norm in repeated_headers:
                span.region = "header"
            elif span.y + span.height > footer_y and norm in repeated_footers:
                span.region = "footer"
            else:
                span.region = "body"


# ---------------------------------------------------------------------------
# Scanned PDF detection
# ---------------------------------------------------------------------------

def is_scanned_pdf(pdf_path: str, min_chars_per_page: int = 30) -> bool:
    """Heuristic: few extractable characters per page implies a scanned document."""
    doc = fitz.open(pdf_path)
    try:
        if doc.page_count == 0:
            return True
        low_text_pages = 0
        for page in doc:
            chars = len(page.get_text("text").strip())
            if chars < min_chars_per_page:
                low_text_pages += 1
        return low_text_pages >= max(1, doc.page_count * 0.6)
    finally:
        doc.close()


# ---------------------------------------------------------------------------
# OCR layout extraction (Tesseract fallback)
# ---------------------------------------------------------------------------

def extract_ocr_layout(pdf_path: str, dpi: int = 300) -> DocumentLayout:
    """Render pages and OCR with bounding boxes for scanned PDFs."""
    try:
        import pytesseract
        from PIL import Image
    except ImportError as exc:
        raise RuntimeError(
            "pytesseract and Pillow are required for OCR fallback. "
            "Install with: pip install pytesseract Pillow"
        ) from exc

    doc = fitz.open(pdf_path)
    pages: List[PageLayout] = []

    try:
        for page_num, page in enumerate(doc):
            rect = page.rect
            pix = page.get_pixmap(dpi=dpi)
            img = Image.frombytes("RGB", [pix.width, pix.height], pix.samples)
            scale = rect.width / pix.width

            data = pytesseract.image_to_data(img, output_type=pytesseract.Output.DICT)
            spans: List[TextSpan] = []
            n = len(data["text"])
            for i in range(n):
                text = (data["text"][i] or "").strip()
                if not text or int(data["conf"][i]) < 40:
                    continue
                x = data["left"][i] * scale
                y = data["top"][i] * scale
                w = data["width"][i] * scale
                h = data["height"][i] * scale
                spans.append(
                    TextSpan(
                        text=text + " ",
                        x=x,
                        y=y,
                        width=w,
                        height=h,
                        font_family="Arial",
                        font_size=max(h * 0.75, 8.0),
                    )
                )

            columns = detect_columns(
                [(s.x, s.y, s.x + s.width, s.y + s.height) for s in spans],
                rect.width,
            )
            for span in spans:
                span.column = assign_column(span.x, columns)

            pages.append(
                PageLayout(
                    page_num=page_num,
                    width=rect.width,
                    height=rect.height,
                    text_spans=spans,
                    column_boundaries=columns,
                    body_spans=[s for s in spans],
                    is_multi_column=len(columns) > 1,
                )
            )
    finally:
        doc.close()

    return DocumentLayout(pages=pages, is_scanned=True)


# ---------------------------------------------------------------------------
# Main layout extraction
# ---------------------------------------------------------------------------

def extract_layout(pdf_path: str) -> DocumentLayout:
    """Extract full document layout with reading order and column structure."""
    doc = fitz.open(pdf_path)
    pages_raw: List[Tuple[float, List[TextSpan]]] = []
    page_layouts: List[PageLayout] = []

    try:
        for page_num, page in enumerate(doc):
            rect = page.rect
            spans: List[TextSpan] = []
            blocks = page.get_text("dict", flags=fitz.TEXT_PRESERVE_WHITESPACE)["blocks"]

            for block in blocks:
                if block.get("type") != 0:
                    continue
                for line in block.get("lines", []):
                    line_spans = [
                        s for s in line.get("spans", [])
                        if (s.get("text") or "").strip()
                    ]
                    if not line_spans:
                        continue
                    parts: List[str] = []
                    x0 = min(s["bbox"][0] for s in line_spans)
                    y0 = min(s["bbox"][1] for s in line_spans)
                    x1 = max(s["bbox"][2] for s in line_spans)
                    y1 = max(s["bbox"][3] for s in line_spans)
                    primary = max(line_spans, key=lambda s: len(s.get("text", "")))
                    family, bold, italic = normalize_font(primary.get("font", ""))
                    for s in line_spans:
                        parts.append(s.get("text", ""))
                    merged = "".join(parts)
                    if not merged.strip():
                        continue
                    spans.append(
                        TextSpan(
                            text=merged,
                            x=x0,
                            y=y0,
                            width=x1 - x0,
                            height=y1 - y0,
                            font_family=family,
                            font_size=primary.get("size", 11.0),
                            bold=bold,
                            italic=italic,
                            color=rgb_to_hex(primary.get("color")),
                        )
                    )

            pages_raw.append((rect.height, spans))

        if len(pages_raw) > 1:
            classify_header_footer(pages_raw)

        for page_num, ((height, spans), page) in enumerate(zip(pages_raw, doc)):
            rect = page.rect
            body = [s for s in spans if s.region == "body"]
            columns = detect_columns(
                [(s.x, s.y, s.x + s.width, s.y + s.height) for s in body],
                rect.width,
            )
            for span in spans:
                span.column = assign_column(span.x, columns)

            page_layouts.append(
                PageLayout(
                    page_num=page_num,
                    width=rect.width,
                    height=rect.height,
                    text_spans=spans,
                    column_boundaries=columns,
                    header_spans=[s for s in spans if s.region == "header"],
                    footer_spans=[s for s in spans if s.region == "footer"],
                    body_spans=body,
                    is_multi_column=len(columns) > 1,
                )
            )
    finally:
        doc.close()

    return DocumentLayout(pages=page_layouts, is_scanned=False)


def spans_excluding_regions(
    layout: DocumentLayout,
    table_bboxes_by_page: Dict[int, List[Tuple[float, float, float, float]]],
) -> DocumentLayout:
    """Remove text spans that fall inside detected table bounding boxes."""
    for page in layout.pages:
        bboxes = table_bboxes_by_page.get(page.page_num, [])
        if not bboxes:
            continue

        def inside_table(span: TextSpan) -> bool:
            sx0, sy0 = span.x, span.y
            sx1, sy1 = span.x + span.width, span.y + span.height
            for tx0, ty0, tx1, ty1 in bboxes:
                if sx0 >= tx0 and sy0 >= ty0 and sx1 <= tx1 and sy1 <= ty1:
                    return True
            return False

        page.text_spans = [s for s in page.text_spans if not inside_table(s)]
        page.body_spans = [s for s in page.body_spans if not inside_table(s)]
    return layout
