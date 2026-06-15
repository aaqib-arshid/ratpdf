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
import re
import sys
from html.parser import HTMLParser
from typing import Any, Dict, List, Optional, Tuple

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


def _css_color_to_hex(value: str) -> Optional[str]:
    if not value:
        return None
    value = value.strip().lower()
    if value.startswith("#") and len(value) >= 7:
        return value[:7]
    m = re.match(r"rgb\s*\(\s*(\d+)\s*,\s*(\d+)\s*,\s*(\d+)", value)
    if m:
        r, g, b = int(m.group(1)), int(m.group(2)), int(m.group(3))
        return f"#{r:02x}{g:02x}{b:02x}"
    named = {
        "blue": "#2563eb", "red": "#ff0000", "black": "#000000",
        "white": "#ffffff", "yellow": "#ffff00", "green": "#008000",
    }
    return named.get(value)


def _parse_style_attr(style: str) -> Dict[str, str]:
    out: Dict[str, str] = {}
    for part in (style or "").split(";"):
        if ":" not in part:
            continue
        k, v = part.split(":", 1)
        out[k.strip().lower()] = v.strip()
    return out


class _RichHtmlParser(HTMLParser):
    """Parse editor rich HTML into styled text runs."""

    def __init__(self, base: Dict[str, Any]):
        super().__init__()
        self.base = base
        self.stack: List[Dict[str, Any]] = [dict(base)]
        self.runs: List[Dict[str, Any]] = []

    def _cur(self) -> Dict[str, Any]:
        return self.stack[-1]

    def handle_starttag(self, tag: str, attrs: List[Tuple[str, Optional[str]]]) -> None:
        tag = tag.lower()
        amap = {k.lower(): (v or "") for k, v in attrs}
        style = dict(self._cur())
        if tag in ("b", "strong"):
            style["bold"] = True
        elif tag in ("i", "em"):
            style["italic"] = True
        elif tag == "u":
            style["underline"] = True
        elif tag == "a":
            style["url"] = amap.get("href", "")
            style["color"] = style.get("color") or "#2563eb"
            style["underline"] = True
        elif tag == "span":
            css = _parse_style_attr(amap.get("style", ""))
            if "color" in css:
                hx = _css_color_to_hex(css["color"])
                if hx:
                    style["color"] = hx
            if "background-color" in css:
                hx = _css_color_to_hex(css["background-color"])
                if hx:
                    style["bgColor"] = hx
            if "font-family" in css:
                fam = css["font-family"].split(",")[0].strip().strip('"\'')
                if fam:
                    style["fontFamily"] = fam
            if "font-size" in css:
                m = re.search(r"([\d.]+)", css["font-size"])
                if m:
                    style["fontSize"] = float(m.group(1))
            if "font-weight" in css and css["font-weight"] in ("bold", "700", "800", "900"):
                style["bold"] = True
            if "font-style" in css and css["font-style"] == "italic":
                style["italic"] = True
        elif tag == "font":
            if amap.get("color"):
                hx = _css_color_to_hex(amap["color"])
                if hx:
                    style["color"] = hx
        self.stack.append(style)

    def handle_endtag(self, tag: str) -> None:
        if len(self.stack) > 1:
            self.stack.pop()

    def handle_data(self, data: str) -> None:
        if data:
            self.runs.append({**self._cur(), "text": data})


def _parse_rich_html(html: str, base: Dict[str, Any]) -> List[Dict[str, Any]]:
    if not html or not str(html).strip():
        return []
    parser = _RichHtmlParser(base)
    try:
        parser.feed(str(html))
        parser.close()
    except Exception:
        plain = re.sub(r"<[^>]+>", "", html)
        return [{**base, "text": plain}] if plain else []
    runs = [r for r in parser.runs if r.get("text")]
    if not runs and html:
        plain = re.sub(r"<[^>]+>", "", html)
        if plain:
            runs = [{**base, "text": plain}]
    return runs


def _run_width(fontname: str, text: str, fontsize: float) -> float:
    try:
        return float(fitz.get_text_length(text, fontname=fontname, fontsize=fontsize))
    except Exception:
        return len(text) * fontsize * 0.55


def _run_width_font(font: fitz.Font, text: str, fontsize: float) -> float:
    try:
        return float(font.text_length(text, fontsize=fontsize))
    except Exception:
        return _run_width("helv", text, fontsize)


def _resolve_embedded_font(page, doc, pdf_font_name: str, bold: bool, italic: bool) -> Optional[fitz.Font]:
    if not pdf_font_name or not _should_use_embedded_font(pdf_font_name, bold, italic):
        return None
    needle = pdf_font_name.lower()
    if "+" in needle:
        needle = needle.split("+", 1)[1]
    keywords = [w for w in re.split(r"[^a-z0-9]+", needle) if len(w) > 2]
    for xref, _ext, _typ, basefont, name, _enc in page.get_fonts():
        labels = {str(x or "").lower() for x in (basefont, name)}
        label_text = " ".join(labels)
        if needle in label_text or any(kw in label_text for kw in keywords):
            try:
                extracted = doc.extract_font(xref)
                if extracted and len(extracted) >= 4 and extracted[3]:
                    return fitz.Font(fontbuffer=extracted[3])
            except Exception:
                pass
    return None


def _sample_fill_color(page, rect: fitz.Rect) -> Tuple[float, float, float]:
    """Sample background color under a region for seamless redaction."""
    try:
        clip = fitz.Rect(
            max(page.rect.x0, rect.x0),
            max(page.rect.y0, rect.y0),
            min(page.rect.x1, rect.x1),
            min(page.rect.y1, rect.y1),
        )
        if clip.is_empty or clip.width < 1 or clip.height < 1:
            return (1.0, 1.0, 1.0)
        pix = page.get_pixmap(matrix=fitz.Matrix(1, 1), clip=clip, alpha=False)
        if pix.width < 1 or pix.height < 1:
            return (1.0, 1.0, 1.0)
        samples = pix.samples
        n = pix.n
        count = pix.width * pix.height
        rs = gs = bs = 0
        step = max(1, count // 64)
        taken = 0
        for i in range(0, count, step):
            idx = i * n
            if idx + 2 >= len(samples):
                break
            rs += samples[idx]
            gs += samples[idx + 1]
            bs += samples[idx + 2]
            taken += 1
        if taken:
            return (rs / taken / 255.0, gs / taken / 255.0, bs / taken / 255.0)
    except Exception:
        pass
    return (1.0, 1.0, 1.0)


def _edit_runs(edit: Dict[str, Any]) -> List[Dict[str, Any]]:
    rich_html = str(_edit_val(edit, "richHtml", "") or "")
    plain = str(_edit_val(edit, "text", "") or "")
    font_size = float(_edit_val(edit, "fontSize", 12) or 12)
    family = str(_edit_val(edit, "fontFamily", "Arial") or "Arial")
    default_color = str(_edit_val(edit, "color", "#000000") or "#000000")
    has_rich = bool(rich_html.strip())
    base = {
        "fontSize": font_size,
        "fontFamily": family,
        "color": default_color,
        "bold": False if has_rich else bool(_edit_val(edit, "bold", False)),
        "italic": False if has_rich else bool(_edit_val(edit, "italic", False)),
        "bgColor": "",
        "url": "",
        "underline": False,
    }
    if has_rich:
        runs = _parse_rich_html(rich_html, base)
        if runs:
            return runs
    return [{**base, "text": plain}] if plain else []


def _measure_runs_width(runs: List[Dict[str, Any]]) -> float:
    total = 0.0
    for run in runs:
        text = str(run.get("text", "") or "")
        if not text:
            continue
        fs = float(run.get("fontSize") or 12)
        fam = str(run.get("fontFamily") or "Arial")
        fontname = _pdf_font(fam, bool(run.get("bold")), bool(run.get("italic")))
        total += _run_width(fontname, text, fs)
    return total


def _tokenize_runs(runs: List[Dict[str, Any]]) -> List[Dict[str, Any]]:
    tokens: List[Dict[str, Any]] = []
    for run in runs:
        text = str(run.get("text", "") or "")
        if not text:
            continue
        for part in re.split(r"(\s+)", text):
            if part:
                tokens.append({**run, "text": part})
    return tokens


def _wrap_runs_into_lines(runs: List[Dict[str, Any]], max_width: float) -> List[List[Dict[str, Any]]]:
    if max_width <= 0:
        return [runs]
    tokens = _tokenize_runs(runs)
    if not tokens:
        return []
    lines: List[List[Dict[str, Any]]] = [[]]
    line_width = 0.0

    for tok in tokens:
        text = tok["text"]
        fs = float(tok.get("fontSize") or 12)
        fam = str(tok.get("fontFamily") or "Arial")
        fontname = _pdf_font(fam, bool(tok.get("bold")), bool(tok.get("italic")))
        w = _run_width(fontname, text, fs)
        if line_width + w > max_width and lines[-1] and not text.isspace():
            lines.append([])
            line_width = 0.0
        lines[-1].append(tok)
        line_width += w
    return lines


def _expand_text_rect(page, edit: Dict[str, Any], rect: fitz.Rect) -> fitz.Rect:
    runs = _edit_runs(edit)
    if not runs:
        return rect
    orig_w = float(_edit_val(edit, "width", rect.width) or rect.width)
    orig_h = float(_edit_val(edit, "height", rect.height) or rect.height)
    font_size = float(_edit_val(edit, "fontSize", 12) or 12)
    content_w = _measure_runs_width(runs)
    max_w = max(orig_w, min(content_w + 4, page.rect.width - rect.x0 - 4))
    lines = _wrap_runs_into_lines(runs, max_w)
    line_h = font_size * 1.28
    needed_h = max(orig_h, len(lines) * line_h + font_size * 0.2)
    if max_w <= orig_w + 1 and needed_h <= orig_h + 1:
        return rect
    return fitz.Rect(rect.x0, rect.y0, rect.x0 + max_w + 2, rect.y0 + needed_h)


def _insert_run_text(
    page,
    x: float,
    baseline_y: float,
    text: str,
    font_size: float,
    color: Tuple[float, float, float],
    fontname: str,
    embedded: Optional[fitz.Font] = None,
) -> float:
    if embedded:
        try:
            tw = fitz.TextWriter(page.rect)
            tw.append((x, baseline_y), text, font=embedded, fontsize=font_size)
            tw.write_text(page, color=color)
            return _run_width_font(embedded, text, font_size)
        except Exception:
            pass
    try:
        page.insert_text((x, baseline_y), text, fontname=fontname, fontsize=font_size, color=color)
    except Exception:
        page.insert_text((x, baseline_y), text, fontname="helv", fontsize=font_size, color=color)
    return _run_width(fontname, text, font_size)


def _insert_rich_text_op(page, doc, edit: Dict[str, Any]) -> None:
    """Redact region and rewrite text run-by-run preserving mixed formatting."""
    rich_html = str(_edit_val(edit, "richHtml", "") or "")
    plain = str(_edit_val(edit, "text", "") or "")
    if not rich_html and not plain.strip():
        return

    font_size = float(_edit_val(edit, "fontSize", 12) or 12)
    family = str(_edit_val(edit, "fontFamily", "Arial") or "Arial")
    default_color = str(_edit_val(edit, "color", "#000000") or "#000000")
    pdf_font_name = str(_edit_val(edit, "pdfFontName", "") or "")
    rect = edit["_rect"]
    etype = str(_edit_val(edit, "type", "") or "")

    has_rich = bool(rich_html.strip())
    base = {
        "fontSize": font_size,
        "fontFamily": family,
        "color": default_color,
        "bold": False if has_rich else bool(_edit_val(edit, "bold", False)),
        "italic": False if has_rich else bool(_edit_val(edit, "italic", False)),
        "bgColor": "",
        "url": "",
        "underline": False,
    }
    runs = _parse_rich_html(rich_html, base) if has_rich else [{**base, "text": plain}]
    if not runs:
        return

    if etype == "text_add":
        pad_rect = fitz.Rect(rect.x0 - 1, rect.y0 - 1, rect.x1 + 1, rect.y1 + 1)
        shape = page.new_shape()
        shape.draw_rect(pad_rect)
        shape.finish(color=(1, 1, 1), fill=(1, 1, 1))
        shape.commit()

    max_width = max(rect.width - 2, font_size * 2)
    lines = _wrap_runs_into_lines(runs, max_width)
    line_height = font_size * 1.28
    link_rects: List[Tuple[fitz.Rect, str]] = []

    for line_idx, line_runs in enumerate(lines):
        baseline_y = rect.y0 + font_size * 0.82 + line_idx * line_height
        x = rect.x0

        for run in line_runs:
            text = str(run.get("text", "") or "")
            if not text:
                continue
            fs = float(run.get("fontSize") or font_size)
            fam = str(run.get("fontFamily") or family)
            bold = bool(run.get("bold"))
            italic = bool(run.get("italic"))
            color = _hex_to_rgb(str(run.get("color") or default_color))
            bg = str(run.get("bgColor") or "")
            url = str(run.get("url") or "")
            fontname = _pdf_font(fam, bold, italic)
            embedded = _resolve_embedded_font(page, doc, pdf_font_name, bold, italic)
            if embedded:
                width = _run_width_font(embedded, text, fs)
            else:
                width = _run_width(fontname, text, fs)

            if bg:
                bg_rgb = _hex_to_rgb(bg)
                bg_rect = fitz.Rect(
                    x, rect.y0 + line_idx * line_height,
                    x + width + 1, rect.y0 + line_idx * line_height + fs * 1.15,
                )
                shape = page.new_shape()
                shape.draw_rect(bg_rect)
                shape.finish(color=bg_rgb, fill=bg_rgb, fill_opacity=0.92)
                shape.commit()

            _insert_run_text(page, x, baseline_y, text, fs, color, fontname, embedded)

            if run.get("underline") or url:
                uy = baseline_y + 1.2
                page.draw_line((x, uy), (x + width, uy), color=color, width=max(0.4, fs * 0.04))

            if url:
                link_rects.append((
                    fitz.Rect(x, rect.y0 + line_idx * line_height, x + width + 1, rect.y0 + line_idx * line_height + fs * 1.2),
                    url,
                ))
            x += width

    for link_rect, url in link_rects:
        try:
            page.insert_link({"kind": fitz.LINK_URI, "from": link_rect, "uri": url})
        except Exception as exc:
            print(f"WARN: inline link failed: {exc}", file=sys.stderr)


MAX_SPANS_PER_PAGE = 800


def extract_editable_model(pdf_path: str) -> Dict[str, Any]:
    """Extract per-page text spans for in-place overlay editing."""
    doc = fitz.open(pdf_path)
    pages_out: List[Dict[str, Any]] = []
    total_spans = 0

    try:
        for page_num, page in enumerate(doc):
            rect = page.rect
            spans: List[Dict[str, Any]] = []
            data = page.get_text("dict", flags=fitz.TEXT_PRESERVE_WHITESPACE)

            for block_idx, block in enumerate(data.get("blocks", [])):
                if block.get("type") != 0:
                    continue
                for line_idx, line in enumerate(block.get("lines", [])):
                    line_id = f"p{page_num}b{block_idx}l{line_idx}"
                    for s in line.get("spans", []):
                        text = s.get("text") or ""
                        if not text.strip():
                            continue

                        x0, y0, x1, y1 = s["bbox"]
                        family, bold, italic = normalize_font(s.get("font", ""))
                        font_size = round(float(s.get("size", 11)), 1)
                        color = rgb_to_hex(s.get("color"))

                        spans.append({
                            "id": f"p{page_num}s{len(spans)}",
                            "lineId": line_id,
                            "text": text,
                            "x": round(x0, 2),
                            "y": round(y0, 2),
                            "width": round(max(x1 - x0, 1), 2),
                            "height": round(max(y1 - y0, 1), 2),
                            "fontSize": font_size,
                            "fontFamily": family,
                            "pdfFontName": s.get("font", ""),
                            "bold": bold,
                            "italic": italic,
                            "color": color,
                        })

            span_count = len(spans)
            total_spans += span_count
            spans_truncated = span_count > MAX_SPANS_PER_PAGE
            if spans_truncated:
                spans = spans[:MAX_SPANS_PER_PAGE]

            pages_out.append({
                "pageNum": page_num,
                "width": round(rect.width, 2),
                "height": round(rect.height, 2),
                "spans": spans,
                "spanCount": span_count,
                "spansTruncated": spans_truncated,
            })
    finally:
        doc.close()

    return {
        "pageCount": len(pages_out),
        "totalSpans": total_spans,
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


def _apply_page_ops(doc, page_ops: List[Dict[str, Any]]) -> None:
    """Rotate or delete pages before annotation edits (uses original page indices)."""
    if not page_ops:
        return

    rotations = [op for op in page_ops if str(_edit_val(op, "type", "") or "") == "rotate_page"]
    deletes = [op for op in page_ops if str(_edit_val(op, "type", "") or "") == "delete_page"]

    for op in rotations:
        idx = int(_edit_val(op, "page", 0))
        angle = int(_edit_val(op, "angle", 90) or 90)
        if 0 <= idx < doc.page_count:
            page = doc[idx]
            page.set_rotation((int(page.rotation) + angle) % 360)

    for op in sorted(deletes, key=lambda o: int(_edit_val(o, "page", 0)), reverse=True):
        idx = int(_edit_val(op, "page", 0))
        if 0 <= idx < doc.page_count:
            doc.delete_page(idx)

    reorders = [op for op in page_ops if str(_edit_val(op, "type", "") or "") == "reorder_pages"]
    for op in reorders:
        order = _edit_val(op, "order", None) or _edit_val(op, "Order", None)
        if isinstance(order, list) and order:
            _apply_page_reorder(doc, [int(x) for x in order])


def _apply_page_reorder(doc, page_order: List[int]) -> None:
    """Reorder pages; page_order lists original page indices in desired final order."""
    if not page_order or len(page_order) != doc.page_count:
        return
    # After deletes, remaining pages sit in ascending original-index order.
    current = sorted(page_order)
    for target in range(len(page_order)):
        want_orig = page_order[target]
        src = current.index(want_orig)
        if src != target:
            doc.move_page(src, target)
            item = current.pop(src)
            current.insert(target, item)


def apply_edits(pdf_path: str, output_path: str, edits: List[Dict[str, Any]], page_ops: Optional[List[Dict[str, Any]]] = None) -> None:
    """
    Apply annotation edits directly on the PDF object structure.

    Edit types:
      - whiteout: permanent white redaction
      - text_replace: redact region + insert new text (in-place edit)
      - text_add: insert new text box
      - image: insert image at rectangle
      - highlight: semi-transparent highlight rectangle
      - link: URI hyperlink annotation
    """
    doc = fitz.open(pdf_path)

    try:
        _apply_page_ops(doc, page_ops or [])

        redact_ops: List[Tuple[int, fitz.Rect, Tuple[float, float, float]]] = []
        text_ops: List[Dict[str, Any]] = []
        image_ops: List[Dict[str, Any]] = []
        highlight_ops: List[Dict[str, Any]] = []
        link_ops: List[Dict[str, Any]] = []

        for raw in edits:
            page_idx = int(_edit_val(raw, "page", 0))
            if page_idx < 0 or page_idx >= doc.page_count:
                continue

            etype = str(_edit_val(raw, "type", "") or "")
            if etype == "text_replace":
                text = str(_edit_val(raw, "text", "") or "")
                rich = str(_edit_val(raw, "richHtml", "") or "")
                if not text.strip() and not rich.strip():
                    continue

            pad = 1.0 if etype == "text_replace" else 0.0
            x = float(_edit_val(raw, "x", 0)) - pad
            y = float(_edit_val(raw, "y", 0)) - pad
            w = float(_edit_val(raw, "width", 0)) + pad * 2
            h = float(_edit_val(raw, "height", 0)) + pad * 2
            rect = fitz.Rect(x, y, x + max(w, 1), y + max(h, 1))
            sample_rect = fitz.Rect(
                float(_edit_val(raw, "x", 0)),
                float(_edit_val(raw, "y", 0)),
                float(_edit_val(raw, "x", 0)) + max(float(_edit_val(raw, "width", 0)), 1),
                float(_edit_val(raw, "y", 0)) + max(float(_edit_val(raw, "height", 0)), 1),
            )

            op = {**raw, "_rect": rect, "_sample_rect": sample_rect}

            if etype == "text_replace":
                page = doc[page_idx]
                expanded = _expand_text_rect(page, op, rect)
                op["_rect"] = expanded
                fill = (1.0, 1.0, 1.0)
                redact_ops.append((page_idx, expanded, fill))
                text_ops.append(op)
            elif etype == "whiteout":
                redact_ops.append((page_idx, rect, (1.0, 1.0, 1.0)))
            elif etype == "text_add":
                text_ops.append(op)
            elif etype == "image":
                image_ops.append(op)
            elif etype == "highlight":
                highlight_ops.append(op)
            elif etype == "link":
                link_ops.append(op)

        # Phase 1: redactions (whiteout + text replacement areas)
        redact_by_page: Dict[int, List[Tuple[fitz.Rect, Tuple[float, float, float]]]] = {}
        for page_idx, rect, fill in redact_ops:
            redact_by_page.setdefault(page_idx, []).append((rect, fill))

        for page_idx, items in redact_by_page.items():
            page = doc[page_idx]
            for rect, fill in items:
                page.add_redact_annot(rect, fill=fill)
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
                    page.insert_image(edit["_rect"], stream=img_bytes, keep_proportion=True, overlay=True)
            except Exception as exc:
                print(f"WARN: image insert failed: {exc}", file=sys.stderr)

        # Phase 4: text insertions
        for edit in text_ops:
            page_idx = int(_edit_val(edit, "page", 0))
            _insert_text_op(doc[page_idx], doc, edit)

        # Phase 5: hyperlinks
        for edit in link_ops:
            page = doc[int(_edit_val(edit, "page", 0))]
            url = str(_edit_val(edit, "url", "") or "").strip()
            if not url:
                continue
            rect = edit["_rect"]
            try:
                page.insert_link({
                    "kind": fitz.LINK_URI,
                    "from": rect,
                    "uri": url,
                })
            except Exception as exc:
                print(f"WARN: link insert failed: {exc}", file=sys.stderr)

        doc.save(output_path, garbage=4, deflate=True)
    finally:
        doc.close()


def _is_base14_font_name(pdf_font_name: str) -> bool:
    n = (pdf_font_name or "").lower()
    return any(x in n for x in ("helvetica", "arial", "times", "courier", "symbol", "zapf"))


def _should_use_embedded_font(pdf_font_name: str, bold: bool, italic: bool) -> bool:
    """Use embedded font when style matches the PDF font name."""
    if not pdf_font_name:
        return False
    # Custom / subset / Type3 fonts (Poppins, etc.) — prefer embedded extraction
    if not _is_base14_font_name(pdf_font_name):
        return not bold and not italic
    name = pdf_font_name.lower()
    if bold and "bold" not in name and "black" not in name and "heavy" not in name:
        return False
    if italic and "italic" not in name and "oblique" not in name:
        return False
    if not bold and ("bold" in name or "black" in name):
        return False
    if not italic and ("italic" in name or "oblique" in name):
        return False
    return True


def _insert_text_op(page, doc, edit: Dict[str, Any]) -> None:
    """Insert replacement/addition text — rich HTML or plain styled text."""
    rich_html = str(_edit_val(edit, "richHtml", "") or "")
    bold = bool(_edit_val(edit, "bold", False))
    italic = bool(_edit_val(edit, "italic", False))
    if rich_html.strip() and ("<" in rich_html or bold or italic):
        _insert_rich_text_op(page, doc, edit)
        return

    text = str(_edit_val(edit, "text", "") or "")
    if not text.strip():
        return

    font_size = float(_edit_val(edit, "fontSize", 12) or 12)
    family = str(_edit_val(edit, "fontFamily", "Arial") or "Arial")
    bold = bool(_edit_val(edit, "bold", False))
    italic = bool(_edit_val(edit, "italic", False))
    color = _hex_to_rgb(str(_edit_val(edit, "color", "#000000") or "#000000"))
    pdf_font_name = str(_edit_val(edit, "pdfFontName", "") or "")
    rect = edit["_rect"]
    etype = str(_edit_val(edit, "type", "") or "")

    if etype == "text_add":
        pad_rect = fitz.Rect(rect.x0 - 1, rect.y0 - 1, rect.x1 + 1, rect.y1 + 1)
        shape = page.new_shape()
        shape.draw_rect(pad_rect)
        shape.finish(color=(1, 1, 1), fill=(1, 1, 1))
        shape.commit()

    fontname = _pdf_font(family, bold, italic)
    embedded = _resolve_embedded_font(page, doc, pdf_font_name, bold, italic)

    if embedded and not bold and not italic:
        tw = fitz.TextWriter(page.rect)
        baseline_y = rect.y0 + font_size * 0.82
        lines = _wrap_runs_into_lines(_edit_runs(edit), max(rect.width - 2, font_size * 2))
        line_height = font_size * 1.28
        for line_idx, line_runs in enumerate(lines):
            y = rect.y0 + font_size * 0.82 + line_idx * line_height
            x = rect.x0
            for run in line_runs:
                text = str(run.get("text", "") or "")
                if not text:
                    continue
                fs = float(run.get("fontSize") or font_size)
                try:
                    tw.append((x, y), text, font=embedded, fontsize=fs)
                except Exception:
                    pass
                x += _run_width_font(embedded, text, fs)
        try:
            tw.write_text(page, color=color)
            return
        except Exception:
            pass

    box = fitz.Rect(rect.x0, rect.y0, rect.x1, max(rect.y1, rect.y0 + font_size * 3))
    rc = page.insert_textbox(
        box, text,
        fontname=fontname,
        fontsize=font_size,
        color=color,
        align=fitz.TEXT_ALIGN_LEFT,
    )
    if rc < 0:
        baseline_y = rect.y0 + font_size * 0.82
        page.insert_text(
            (rect.x0, baseline_y), text,
            fontname=fontname,
            fontsize=font_size,
            color=color,
        )


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
        with open(args.edits_json_path, "r", encoding="utf-8-sig") as f:
            payload = json.load(f)
        if isinstance(payload, list):
            edits = payload
            page_ops: List[Dict[str, Any]] = []
        else:
            edits = payload.get("edits", [])
            page_ops = payload.get("pageOps") or payload.get("page_ops") or []
        apply_edits(args.pdf_path, args.output_pdf, edits, page_ops)
        print(args.output_pdf)
        return 0

    return 1


if __name__ == "__main__":
    sys.exit(main())
