"""Generate minimal PDF fixtures for conversion regression tests."""

from __future__ import annotations

import os

import fitz


def ensure_fixtures(fixtures_dir: str) -> dict[str, str]:
    os.makedirs(fixtures_dir, exist_ok=True)
    paths = {
        "simple_text": os.path.join(fixtures_dir, "simple_text.pdf"),
        "table_grid": os.path.join(fixtures_dir, "table_grid.pdf"),
        "two_page": os.path.join(fixtures_dir, "two_page.pdf"),
    }
    if not os.path.isfile(paths["simple_text"]):
        _write_simple_text(paths["simple_text"])
    if not os.path.isfile(paths["table_grid"]):
        _write_table_grid(paths["table_grid"])
    if not os.path.isfile(paths["two_page"]):
        _write_two_page(paths["two_page"])
    return paths


def _write_simple_text(path: str) -> None:
    doc = fitz.open()
    page = doc.new_page(width=595, height=842)
    page.insert_text((72, 100), "RatPDF Golden Test Document", fontsize=18)
    page.insert_text((72, 140), "Line two with invoice total 1234.56 EUR.", fontsize=12)
    page.insert_text((72, 170), "Contact: qa@ratpdf.com", fontsize=11)
    doc.save(path)
    doc.close()


def _write_table_grid(path: str) -> None:
    doc = fitz.open()
    page = doc.new_page(width=595, height=842)
    headers = ["Item", "Qty", "Price"]
    rows = [
        ["Widget A", "2", "19.99"],
        ["Widget B", "1", "49.50"],
        ["Shipping", "1", "5.00"],
    ]
    x0, y0 = 72, 120
    col_w = [120, 60, 80]
    row_h = 24

    def cell_rect(r: int, c: int) -> fitz.Rect:
        x = x0 + sum(col_w[:c])
        y = y0 + r * row_h
        return fitz.Rect(x, y, x + col_w[c], y + row_h)

    for r in range(len(rows) + 1):
        for c in range(len(headers)):
            rect = cell_rect(r, c)
            page.draw_rect(rect, color=(0, 0, 0), width=0.8)
            label = headers[c] if r == 0 else rows[r - 1][c]
            page.insert_text((rect.x0 + 4, rect.y0 + 16), label, fontsize=10)

    doc.save(path)
    doc.close()


def _write_two_page(path: str) -> None:
    doc = fitz.open()
    for n in range(2):
        page = doc.new_page(width=595, height=842)
        page.insert_text((72, 72), f"Page {n + 1} of 2 — RatPDF slide test", fontsize=14)
    doc.save(path)
    doc.close()
