#!/usr/bin/env python3
"""
High-fidelity PDF → DOCX converter.

Strategy (Windows-safe, no multiprocessing pickle issues):
  1. Scanned PDFs → page pixmap embed or OCR hybrid
  2. pdf2docx single-thread passes (early exit on good result)
  3. LibreOffice headless (Azure-safe)
  4. Pixmap fallback for stubborn image-heavy files
"""

from __future__ import annotations

import argparse
import os
import re
import shutil
import subprocess
import sys
import tempfile
import traceback
from typing import Optional

import fitz

from docx_builder import build
from image_extractor import extract_images
from page_fidelity_docx import (
    build_pixmap_docx,
    count_docx_images,
    count_pdf_images,
    docx_has_content,
    docx_text_length,
    visual_fidelity_ok,
)
from pdf_parser import (
    DocumentLayout,
    extract_layout,
    extract_ocr_layout,
    is_scanned_pdf,
    spans_excluding_regions,
)
from table_extractor import extract_tables, table_bboxes_by_page

# Never use multi_processing on Windows — causes SwigPyObject pickle errors.
_PDF2DOCX_SAFE = {
    "clip_image_res_ratio": 4.0,
    "parse_lattice_table": True,
    "parse_stream_table": True,
    "extract_stream_table": True,
    "delete_end_line_hyphen": False,
    "ignore_page_error": True,
    "multi_processing": False,
    "min_section_height": 8.0,
    "connected_border_tolerance": 0.4,
    "max_border_width": 12.0,
    "line_overlap_threshold": 0.9,
    "list_not_table": True,
    "page_margin_factor_top": 0.25,
    "page_margin_factor_bottom": 0.25,
    "float_image_ignorable_gap": 2.0,
}

_PDF2DOCX_LOW_IMG = {
    **_PDF2DOCX_SAFE,
    "clip_image_res_ratio": 1.5,
    "parse_lattice_table": False,
    "extract_stream_table": False,
}

_PDF2DOCX_TABLES = {
    **_PDF2DOCX_SAFE,
    "list_not_table": False,
    "clip_image_res_ratio": 3.0,
}


def _find_soffice() -> Optional[str]:
    for path in [
        os.environ.get("LIBREOFFICE_PATH", ""),
        "/usr/bin/soffice",
        "/usr/bin/libreoffice",
        "/usr/lib/libreoffice/program/soffice",
        r"C:\Program Files\LibreOffice\program\soffice.exe",
        r"C:\Program Files (x86)\LibreOffice\program\soffice.exe",
        "soffice",
        "libreoffice",
    ]:
        if not path:
            continue
        if os.path.isfile(path):
            return path
        found = shutil.which(path)
        if found:
            return found
    return None


def _lo_env(profile_dir: str) -> dict:
    """Headless LibreOffice on Azure/Linux — no X11 display."""
    env = os.environ.copy()
    env["HOME"] = "/tmp"
    env["TMPDIR"] = "/tmp"
    env["SAL_USE_VCLPLUGIN"] = "svp"
    env["SAL_DISABLE_OPENCL"] = "1"
    env["LANG"] = "C.UTF-8"
    env.pop("DISPLAY", None)
    env["LIBO_CONFIG_HOME"] = profile_dir
    return env


def _conversion_timeout(input_path: str) -> int:
    try:
        size_mb = max(1, os.path.getsize(input_path) // (1024 * 1024))
    except OSError:
        size_mb = 1
    return min(3600, max(120, size_mb * 45))


def _run_soffice(args: list[str], env: dict, timeout: int) -> subprocess.CompletedProcess:
    xvfb = shutil.which("xvfb-run")
    if xvfb:
        return subprocess.run(
            [xvfb, "-a", "-s", "-screen 0 1280x1024x24"] + args,
            check=True,
            timeout=timeout,
            capture_output=True,
            text=True,
            env=env,
        )
    return subprocess.run(
        args,
        check=True,
        timeout=timeout,
        capture_output=True,
        text=True,
        env=env,
    )


def _libreoffice_pdf_to_docx(pdf_path: str, output_docx_path: str) -> bool:
    soffice = _find_soffice()
    if not soffice:
        return False
    out_dir = os.path.dirname(os.path.abspath(output_docx_path)) or "."
    os.makedirs(out_dir, exist_ok=True)

    profile_dir = tempfile.mkdtemp(prefix="lo_profile_")
    profile_uri = "file://" + profile_dir.replace("\\", "/")
    timeout = _conversion_timeout(pdf_path)

    try:
        _run_soffice(
            [
                soffice,
                "--headless",
                "--invisible",
                "--nologo",
                "--nofirststartwizard",
                "--norestore",
                f"-env:UserInstallation={profile_uri}",
                "--convert-to",
                "docx",
                "--outdir",
                out_dir,
                os.path.abspath(pdf_path),
            ],
            _lo_env(profile_dir),
            timeout,
        )
        base = os.path.splitext(os.path.basename(pdf_path))[0]
        produced = os.path.join(out_dir, base + ".docx")
        if os.path.isfile(produced):
            if os.path.abspath(produced) != os.path.abspath(output_docx_path):
                shutil.move(produced, output_docx_path)
            return docx_has_content(output_docx_path)
    except Exception:
        traceback.print_exc(file=sys.stderr)
    finally:
        shutil.rmtree(profile_dir, ignore_errors=True)
    return False


def _pdf_text_length(pdf_path: str) -> int:
    doc = fitz.open(pdf_path)
    try:
        return sum(len(page.get_text("text").strip()) for page in doc)
    finally:
        doc.close()


def _text_fidelity_ok(pdf_path: str, docx_path: str) -> bool:
    if not docx_has_content(docx_path):
        return False
    pdf_len = _pdf_text_length(pdf_path)
    docx_len = docx_text_length(docx_path)
    if pdf_len < 80:
        return docx_len >= 5 or count_docx_images(docx_path) > 0
    return (docx_len / max(pdf_len, 1)) >= 0.4


def _accept_docx_result(pdf_path: str, docx_path: str, *, require_visual: bool = False) -> bool:
    """True when DOCX has usable editable text or faithful page images."""
    if not docx_has_content(docx_path):
        return False
    text_ok = _text_fidelity_ok(pdf_path, docx_path)
    visual_ok = visual_fidelity_ok(pdf_path, docx_path)
    if require_visual:
        return text_ok and visual_ok
    if text_ok:
        return True
    if docx_text_length(docx_path) >= 30:
        return True
    return visual_ok and count_docx_images(docx_path) > 0


def _try_pdf2docx(pdf_path: str, output_docx_path: str, settings: dict) -> bool:
    try:
        from pdf2docx import Converter
    except ImportError:
        return False
    try:
        if os.path.isfile(output_docx_path):
            os.remove(output_docx_path)
        converter = Converter(pdf_path)
        converter.convert(output_docx_path, **settings)
        converter.close()
        return docx_has_content(output_docx_path)
    except Exception:
        traceback.print_exc(file=sys.stderr)
        if os.path.isfile(output_docx_path):
            try:
                os.remove(output_docx_path)
            except OSError:
                pass
        return False


def _hybrid_convert(pdf_path: str, output_docx_path: str, layout: DocumentLayout) -> str:
    tables = extract_tables(pdf_path)
    images = extract_images(pdf_path, render_fallback_dpi=200)
    bboxes = table_bboxes_by_page(tables)
    layout = spans_excluding_regions(layout, bboxes)
    build(layout, tables, images, output_docx_path)
    return output_docx_path


def _is_image_heavy(pdf_path: str) -> bool:
    doc = fitz.open(pdf_path)
    try:
        text_len = sum(len(p.get_text("text").strip()) for p in doc)
        img_count = sum(len(p.get_images(full=True)) for p in doc)
        return img_count >= 4 and text_len < 120
    finally:
        doc.close()


def _cleanup_temp(paths: list[str], keep: str | None = None) -> None:
    keep_abs = os.path.abspath(keep) if keep else None
    for path in paths:
        try:
            if keep_abs and os.path.abspath(path) == keep_abs:
                continue
            if os.path.isfile(path):
                os.remove(path)
        except OSError:
            pass


def convert(pdf_path: str, output_docx_path: str) -> str:
    if not os.path.isfile(pdf_path):
        raise FileNotFoundError(f"PDF not found: {pdf_path}")

    os.makedirs(os.path.dirname(os.path.abspath(output_docx_path)) or ".", exist_ok=True)
    errors: list[str] = []
    scanned = is_scanned_pdf(pdf_path)
    image_heavy = _is_image_heavy(pdf_path)
    base_dir = os.path.dirname(os.path.abspath(output_docx_path)) or "."

    def _temp_out(suffix: str) -> str:
        return os.path.join(base_dir, f".ratpdf_{suffix}.docx")

    temp_files: list[str] = []

    # --- Pass A: True scans → pixmap first (no extractable text) ---
    if scanned:
        try:
            build_pixmap_docx(pdf_path, output_docx_path, dpi=200)
            return output_docx_path
        except Exception as exc:
            errors.append(f"Pixmap (scanned): {exc}")

    # --- Pass B: pdf2docx single-thread (Windows-safe) — exit early on good result ---
    candidates: list[tuple[str, str]] = []
    for label, settings in (
        ("pdf2docx safe", _PDF2DOCX_SAFE),
        ("pdf2docx tables", _PDF2DOCX_TABLES),
        ("pdf2docx low-img", _PDF2DOCX_LOW_IMG),
    ):
        tmp = _temp_out(label.replace(" ", "_"))
        temp_files.append(tmp)
        if _try_pdf2docx(pdf_path, tmp, settings):
            require_visual = image_heavy and not scanned
            if _accept_docx_result(pdf_path, tmp, require_visual=require_visual):
                shutil.move(tmp, output_docx_path)
                _cleanup_temp(temp_files, keep=output_docx_path)
                return output_docx_path
            candidates.append((label, tmp))
        else:
            errors.append(f"{label}: conversion failed")

    # --- Pass C: LibreOffice (headless, Azure-safe) ---
    lo_tmp = _temp_out("libreoffice")
    temp_files.append(lo_tmp)
    if _libreoffice_pdf_to_docx(pdf_path, lo_tmp):
        if _accept_docx_result(pdf_path, lo_tmp):
            shutil.move(lo_tmp, output_docx_path)
            _cleanup_temp(temp_files, keep=output_docx_path)
            return output_docx_path
        candidates.append(("LibreOffice", lo_tmp))
    else:
        errors.append("LibreOffice: unavailable or failed")

    # Pick best partial result
    if candidates:
        has_images = count_pdf_images(pdf_path) > 0

        def score(item: tuple[str, str]) -> float:
            _, path = item
            v = 1.0 if visual_fidelity_ok(pdf_path, path) else 0.0
            t = 1.0 if _text_fidelity_ok(pdf_path, path) else 0.0
            text_len = docx_text_length(path)
            return (v * 0.65 + t * 0.35) if has_images else (t * 0.75 + v * 0.25 + min(text_len / 500, 0.2))

        candidates.sort(key=score, reverse=True)
        if score(candidates[0]) >= 0.25:
            shutil.copy2(candidates[0][1], output_docx_path)
            _cleanup_temp(temp_files, keep=output_docx_path)
            return output_docx_path

    # --- Pass D: pixmap fallback (image-heavy or stubborn files) ---
    if image_heavy or scanned:
        try:
            build_pixmap_docx(pdf_path, output_docx_path, dpi=200)
            _cleanup_temp(temp_files)
            return output_docx_path
        except Exception as exc:
            errors.append(f"Pixmap fallback: {exc}")

    # --- Pass E: OCR for scanned ---
    if scanned:
        try:
            layout = extract_ocr_layout(pdf_path)
            _hybrid_convert(pdf_path, output_docx_path, layout)
            if docx_has_content(output_docx_path):
                _cleanup_temp(temp_files)
                return output_docx_path
            errors.append("OCR hybrid: empty output")
        except Exception as exc:
            errors.append(f"OCR hybrid: {exc}")

    _cleanup_temp(temp_files)

    raise RuntimeError(
        "PDF to DOCX conversion failed. Attempts:\n- " + "\n- ".join(errors)
    )


def main(argv: Optional[list[str]] = None) -> int:
    parser = argparse.ArgumentParser(description="High-fidelity PDF to DOCX converter")
    parser.add_argument("input_pdf")
    parser.add_argument("output_docx", nargs="?")
    args = parser.parse_args(argv)

    input_pdf = os.path.abspath(args.input_pdf)
    output_docx = (
        os.path.abspath(args.output_docx)
        if args.output_docx
        else os.path.splitext(input_pdf)[0] + ".docx"
    )

    try:
        print(convert(input_pdf, output_docx))
        return 0
    except Exception as exc:
        msg = re.sub(r"\x1b\[[0-9;]*m", "", str(exc))
        print(f"ERROR: {msg}", file=sys.stderr)
        return 1


if __name__ == "__main__":
    sys.exit(main())
