#!/usr/bin/env python3
"""Infer SEO content category from guide slug."""
from __future__ import annotations

CATEGORIES = ("compress", "merge", "split", "convert", "sign", "protect", "edit", "ocr")

_RULES: list[tuple[str, tuple[str, ...]]] = [
    ("compress", ("compress", "shrink", "reduce-size", "file-size")),
    ("merge", ("merge", "combine", "join-pdf", "bind")),
    ("split", ("split", "extract-page", "extract-pages", "separate-pdf", "divide-pdf")),
    ("convert", (
        "pdf-to-word", "word-to-pdf", "pdf-to-excel", "excel-to-pdf",
        "pdf-to-text", "pdf-to-powerpoint", "convert", "conversion",
        "doc-to", "to-doc", "to-word", "to-excel", "html-to-pdf",
        "invoice", "gst", "vat", "fatura", "factura",
    )),
    ("sign", ("sign", "signature", "esign", "e-sign")),
    ("protect", ("password", "protect", "unlock", "encrypt", "watermark", "security", "redact")),
    ("edit", ("edit", "rotate", "flatten", "annotate", "crop", "organize", "page-number")),
    ("ocr", ("ocr", "scanned", "scan-to", "extract-text", "pdftotext")),
]


def infer_category(slug: str, tool_url: str | None = None) -> str:
    s = slug.lower()
    if tool_url:
        t = tool_url.lower()
        if "compress" in t:
            return "compress"
        if "merge" in t:
            return "merge"
        if "split" in t:
            return "split"
        if any(x in t for x in ("pdftodoc", "pdftoexcel", "doctopdf", "pdftotext", "convert")):
            return "convert"
        if "sign" in t:
            return "sign"
        if any(x in t for x in ("password", "unlock", "watermark")):
            return "protect"
        if "ocr" in t:
            return "ocr"
        if any(x in t for x in ("edit", "rotate", "flatten")):
            return "edit"
    for cat, needles in _RULES:
        if any(n in s for n in needles):
            return cat
    return "convert"


def slug_hash(slug: str, salt: str = "") -> int:
    h = 0
    for ch in f"{slug}:{salt}":
        h = (h * 31 + ord(ch)) & 0x7FFFFFFF
    return h
