"""
Table extraction with pdfplumber (primary) and camelot (fallback).
"""

from __future__ import annotations

from dataclasses import dataclass, field
from typing import List, Optional, Tuple

import pdfplumber


@dataclass
class TableCell:
    text: str
    row: int
    col: int
    x: float
    y: float
    width: float
    height: float
    font_family: str = "Arial"
    font_size: float = 10.0
    bold: bool = False
    color: str = "#000000"


@dataclass
class ExtractedTable:
    page_num: int
    x: float
    y: float
    width: float
    height: float
    rows: List[List[str]] = field(default_factory=list)
    cells: List[TableCell] = field(default_factory=list)
    source: str = "pdfplumber"


def _bbox_overlap(
    a: Tuple[float, float, float, float],
    b: Tuple[float, float, float, float],
    tolerance: float = 5.0,
) -> bool:
    ax0, ay0, ax1, ay1 = a
    bx0, by0, bx1, by1 = b
    return not (
        ax1 + tolerance < bx0
        or ax0 - tolerance > bx1
        or ay1 + tolerance < by0
        or ay0 - tolerance > by1
    )


_TABLE_SETTINGS = [
    {
        "vertical_strategy": "lines_strict",
        "horizontal_strategy": "lines_strict",
        "snap_tolerance": 4,
        "join_tolerance": 4,
        "edge_min_length": 5,
        "intersection_tolerance": 5,
    },
    {
        "vertical_strategy": "lines",
        "horizontal_strategy": "lines",
        "snap_tolerance": 5,
        "join_tolerance": 5,
        "edge_min_length": 8,
    },
    {
        "vertical_strategy": "text",
        "horizontal_strategy": "text",
        "snap_tolerance": 6,
        "join_tolerance": 6,
    },
]


def _find_page_tables(page) -> list:
    found: list = []
    seen_bboxes: set[tuple] = set()
    for settings in _TABLE_SETTINGS:
        try:
            candidates = page.find_tables(table_settings=settings)
        except Exception:
            continue
        for table in candidates:
            key = tuple(round(v, 1) for v in table.bbox)
            if key in seen_bboxes:
                continue
            seen_bboxes.add(key)
            found.append(table)
    return found


def _extract_with_pdfplumber(pdf_path: str) -> List[ExtractedTable]:
    tables: List[ExtractedTable] = []
    with pdfplumber.open(pdf_path) as pdf:
        for page_num, page in enumerate(pdf.pages):
            for table in _find_page_tables(page):
                x0, top, x1, bottom = table.bbox
                rows_data: List[List[str]] = []
                cells: List[TableCell] = []

                for row_idx, row in enumerate(table.rows):
                    row_texts: List[str] = []
                    for col_idx, cell in enumerate(row.cells):
                        if cell is None:
                            row_texts.append("")
                            continue
                        cx0, cy0, cx1, cy1 = cell
                        cell_text = page.crop((cx0, cy0, cx1, cy1)).extract_text() or ""
                        cell_text = cell_text.strip()
                        row_texts.append(cell_text)
                        cells.append(
                            TableCell(
                                text=cell_text,
                                row=row_idx,
                                col=col_idx,
                                x=cx0,
                                y=cy0,
                                width=cx1 - cx0,
                                height=cy1 - cy0,
                            )
                        )
                    if any(t.strip() for t in row_texts):
                        rows_data.append(row_texts)

                if rows_data:
                    tables.append(
                        ExtractedTable(
                            page_num=page_num,
                            x=x0,
                            y=top,
                            width=x1 - x0,
                            height=bottom - top,
                            rows=rows_data,
                            cells=cells,
                            source="pdfplumber",
                        )
                    )
    return tables


def _extract_with_camelot(
    pdf_path: str,
    existing: List[ExtractedTable],
) -> List[ExtractedTable]:
    """Fallback using camelot for pages where pdfplumber found no tables."""
    try:
        import camelot
    except ImportError:
        return existing

    pages_with_tables = {t.page_num for t in existing}
    extra: List[ExtractedTable] = []

    try:
        with pdfplumber.open(pdf_path) as pdf:
            page_count = len(pdf.pages)
    except Exception:
        return existing

    for page_num in range(page_count):
        if page_num in pages_with_tables:
            continue
        page_label = str(page_num + 1)
        camelot_tables = []
        for flavor in ("lattice", "stream"):
            try:
                camelot_tables = camelot.read_pdf(
                    pdf_path,
                    pages=page_label,
                    flavor=flavor,
                )
                if camelot_tables and len(camelot_tables) > 0:
                    break
            except Exception:
                continue

        for ct in camelot_tables or []:
            x0, y0, x1, y1 = ct._bbox  # noqa: SLF001 — camelot internal bbox
            # camelot bbox is bottom-left origin; pdfplumber uses top-left
            with pdfplumber.open(pdf_path) as pdf:
                page = pdf.pages[page_num]
                ph = page.height
                top = ph - y1
                bottom = ph - y0

            rows_data = ct.df.fillna("").values.tolist()
            rows_data = [[str(c).strip() for c in row] for row in rows_data]
            if not any(any(c for c in row) for row in rows_data):
                continue

            cells: List[TableCell] = []
            row_count = len(rows_data)
            col_count = max(len(r) for r in rows_data) if rows_data else 0
            cell_w = (x1 - x0) / max(col_count, 1)
            cell_h = (bottom - top) / max(row_count, 1)

            for r_idx, row in enumerate(rows_data):
                for c_idx, text in enumerate(row):
                    cells.append(
                        TableCell(
                            text=text,
                            row=r_idx,
                            col=c_idx,
                            x=x0 + c_idx * cell_w,
                            y=top + r_idx * cell_h,
                            width=cell_w,
                            height=cell_h,
                        )
                    )

            candidate = ExtractedTable(
                page_num=page_num,
                x=x0,
                y=top,
                width=x1 - x0,
                height=bottom - top,
                rows=rows_data,
                cells=cells,
                source="camelot",
            )

            duplicate = any(
                t.page_num == page_num
                and _bbox_overlap(
                    (t.x, t.y, t.x + t.width, t.y + t.height),
                    (candidate.x, candidate.y, candidate.x + candidate.width, candidate.y + candidate.height),
                )
                for t in existing + extra
            )
            if not duplicate:
                extra.append(candidate)

    return existing + extra


def extract_tables(pdf_path: str) -> List[ExtractedTable]:
    """Extract tables using pdfplumber, with camelot fallback for missed tables."""
    tables = _extract_with_pdfplumber(pdf_path)
    return _extract_with_camelot(pdf_path, tables)


def tables_by_page(tables: List[ExtractedTable]) -> dict[int, List[ExtractedTable]]:
    result: dict[int, List[ExtractedTable]] = {}
    for table in tables:
        result.setdefault(table.page_num, []).append(table)
    return result


def table_bboxes_by_page(tables: List[ExtractedTable]) -> dict[int, List[Tuple[float, float, float, float]]]:
    result: dict[int, List[Tuple[float, float, float, float]]] = {}
    for table in tables:
        result.setdefault(table.page_num, []).append(
            (table.x, table.y, table.x + table.width, table.y + table.height)
        )
    return result
