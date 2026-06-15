#!/usr/bin/env python3
"""
High-fidelity office conversions using LibreOffice (primary) and Python fallbacks.

Commands:
  docx2pdf  <input.docx>  <output.pdf>
  xlsx2pdf  <input.xlsx>  <output.pdf>
  pdf2xlsx  <input.pdf>   <output.xlsx>
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
from typing import List, Optional

import fitz


def _find_soffice() -> Optional[str]:
    candidates = [
        os.environ.get("LIBREOFFICE_PATH", ""),
        "/usr/bin/soffice",
        "/usr/bin/libreoffice",
        "/usr/lib/libreoffice/program/soffice",
        r"C:\Program Files\LibreOffice\program\soffice.exe",
        r"C:\Program Files (x86)\LibreOffice\program\soffice.exe",
        "soffice",
        "libreoffice",
    ]
    for path in candidates:
        if not path:
            continue
        if os.path.isfile(path):
            return path
        found = shutil.which(path)
        if found:
            return found
    return None


# Print-accurate export filters (LibreOffice / Adobe-like fidelity).
_LO_WRITER_PDF = (
    'pdf:writer_pdf_Export:'
    '{"SelectPdfVersion":{"type":"long","value":"1"},'
    '"Quality":{"type":"long","value":"100"},'
    '"UseLosslessCompression":{"type":"boolean","value":"true"},'
    '"EmbedStandardFonts":{"type":"boolean","value":"true"},'
    '"ExportFormFields":{"type":"boolean","value":"true"},'
    '"ExportBookmarks":{"type":"boolean","value":"true"},'
    '"ExportNotes":{"type":"boolean","value":"false"},'
    '"UseTaggedPDF":{"type":"boolean","value":"true"},'
    '"ExportLinksRelativeFsys":{"type":"boolean","value":"true"},'
    '"MaxImageResolution":{"type":"long","value":"300"}}'
)
_LO_CALC_PDF = (
    'pdf:calc_pdf_Export:'
    '{"SelectPdfVersion":{"type":"long","value":"1"},'
    '"Quality":{"type":"long","value":"100"},'
    '"SinglePageSheets":{"type":"boolean","value":"false"}}'
)
_LO_IMPRESS_PDF = (
    'pdf:impress_pdf_Export:'
    '{"SelectPdfVersion":{"type":"long","value":"1"},'
    '"Quality":{"type":"long","value":"100"},'
    '"UseLosslessCompression":{"type":"boolean","value":"true"},'
    '"ExportNotesPages":{"type":"boolean","value":"false"},'
    '"ExportHiddenSlides":{"type":"boolean","value":"false"}}'
)


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
    """Scale timeout with file size — up to 1 hour for very large office files."""
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


def _libreoffice_convert(input_path: str, output_path: str, target_ext: str) -> bool:
    soffice = _find_soffice()
    if not soffice:
        print("ERROR: soffice not found — LibreOffice still installing? Check: tail /home/site/ratpdf-install.log", file=sys.stderr)
        return False

    out_dir = os.path.dirname(os.path.abspath(output_path)) or "."
    os.makedirs(out_dir, exist_ok=True)

    profile_dir = tempfile.mkdtemp(prefix="lo_profile_")
    profile_uri = "file://" + profile_dir.replace("\\", "/")
    timeout = _conversion_timeout(input_path)

    try:
        result = _run_soffice(
            [
                soffice,
                "--headless",
                "--invisible",
                "--nologo",
                "--nofirststartwizard",
                "--norestore",
                f"-env:UserInstallation={profile_uri}",
                "--convert-to",
                target_ext,
                "--outdir",
                out_dir,
                os.path.abspath(input_path),
            ],
            _lo_env(profile_dir),
            timeout,
        )
        if result.stderr and "error" in result.stderr.lower():
            print(result.stderr, file=sys.stderr)
        base = os.path.splitext(os.path.basename(input_path))[0]
        produced = os.path.join(out_dir, base + "." + target_ext.split(":")[0])
        if os.path.isfile(produced):
            if os.path.abspath(produced) != os.path.abspath(output_path):
                shutil.move(produced, output_path)
            return os.path.getsize(output_path) > 0
        print(f"ERROR: LibreOffice produced no file at {produced}", file=sys.stderr)
    except subprocess.CalledProcessError as exc:
        print(f"ERROR: soffice exit {exc.returncode}: {exc.stderr or exc.stdout}", file=sys.stderr)
    except Exception:
        traceback.print_exc(file=sys.stderr)
    finally:
        shutil.rmtree(profile_dir, ignore_errors=True)
    return False


def _docx2pdf_windows_word(input_path: str, output_path: str) -> bool:
    if sys.platform != "win32":
        return False
    try:
        import comtypes.client  # type: ignore
    except ImportError:
        try:
            from docx2pdf import convert as d2p_convert  # type: ignore
            d2p_convert(input_path, output_path)
            return os.path.isfile(output_path) and os.path.getsize(output_path) > 0
        except Exception:
            return False

    word = None
    try:
        word = comtypes.client.CreateObject("Word.Application")
        word.Visible = False
        doc = word.Documents.Open(os.path.abspath(input_path), ReadOnly=True)
        doc.ExportAsFixedFormat(os.path.abspath(output_path), 17)  # wdExportFormatPDF
        doc.Close(False)
        return os.path.isfile(output_path) and os.path.getsize(output_path) > 0
    except Exception:
        traceback.print_exc(file=sys.stderr)
        return False
    finally:
        if word is not None:
            try:
                word.Quit()
            except Exception:
                pass


def docx_to_pdf(input_path: str, output_path: str) -> None:
    if not _find_soffice():
        raise RuntimeError(
            "LibreOffice (soffice) is not installed yet. On Azure, wait 5–8 minutes after restart "
            "then check: tail /home/site/ratpdf-install.log — or run: apt-get install -y libreoffice libreoffice-writer"
        )
    if _libreoffice_convert(input_path, output_path, _LO_WRITER_PDF):
        return
    if _libreoffice_convert(input_path, output_path, "pdf:writer_pdf_Export"):
        return
    if _docx2pdf_windows_word(input_path, output_path):
        return
    raise RuntimeError(
        "DOCX to PDF failed. LibreOffice is present but conversion failed — see stderr above."
    )


def xlsx_to_pdf(input_path: str, output_path: str) -> None:
    if _libreoffice_convert(input_path, output_path, _LO_CALC_PDF):
        return
    if _libreoffice_convert(input_path, output_path, "pdf:calc_pdf_Export"):
        return
    raise RuntimeError(
        "Excel to PDF failed. Install LibreOffice on the server for print-accurate conversion."
    )


def pptx_to_pdf(input_path: str, output_path: str) -> None:
    if _libreoffice_convert(input_path, output_path, _LO_IMPRESS_PDF):
        return
    if _libreoffice_convert(input_path, output_path, "pdf:impress_pdf_Export"):
        return
    raise RuntimeError(
        "PowerPoint to PDF failed. Install LibreOffice Impress for slide-accurate export."
    )


def pdf_to_pptx(input_path: str, output_path: str) -> None:
    """PDF → PPTX: try LibreOffice import, then pixmap slides (reliable for all PDFs)."""
    if _libreoffice_convert(input_path, output_path, "pptx"):
        return
    if _libreoffice_convert(input_path, output_path, "pptx:Impress MS PowerPoint 2007 XML"):
        return
    from pdf_to_pptx import pdf_to_pptx_pixmap

    pdf_to_pptx_pixmap(input_path, output_path, dpi=150)


def _style_table_sheet(ws, row_count: int, col_count: int) -> None:
    """Apply borders and header styling like Acrobat export."""
    try:
        from openpyxl.styles import Border, Font, PatternFill, Side
    except ImportError:
        return

    thin = Side(style="thin", color="000000")
    border = Border(left=thin, right=thin, top=thin, bottom=thin)
    header_fill = PatternFill("solid", fgColor="E8EEF4")

    for r in range(1, row_count + 1):
        for c in range(1, col_count + 1):
            cell = ws.cell(row=r, column=c)
            cell.border = border
            if r == 1:
                cell.font = Font(bold=True)
                cell.fill = header_fill

    for c in range(1, col_count + 1):
        max_len = 0
        for r in range(1, row_count + 1):
            val = ws.cell(row=r, column=c).value
            if val is not None:
                max_len = max(max_len, len(str(val)))
        ws.column_dimensions[ws.cell(row=1, column=c).column_letter].width = min(max(max_len + 2, 10), 48)

    if row_count > 1:
        ws.freeze_panes = "A2"


def pdf_to_xlsx(input_path: str, output_path: str) -> None:
    """Extract tables + text into structured XLSX (pdfplumber + openpyxl)."""
    try:
        from openpyxl import Workbook
    except ImportError as exc:
        raise RuntimeError("openpyxl is required: pip install openpyxl") from exc

    from table_extractor import extract_tables

    wb = Workbook()
    wb.remove(wb.active)

    tables = extract_tables(input_path)
    if tables:
        for idx, table in enumerate(tables):
            name = f"Table_p{table.page_num + 1}_{idx + 1}"[:31]
            ws = wb.create_sheet(title=name)
            row_count = len(table.rows)
            col_count = max((len(r) for r in table.rows), default=0)
            for r_idx, row in enumerate(table.rows, start=1):
                for c_idx in range(1, col_count + 1):
                    val = row[c_idx - 1] if c_idx - 1 < len(row) else ""
                    ws.cell(row=r_idx, column=c_idx, value=val or "")
            _style_table_sheet(ws, row_count, col_count)

    doc = fitz.open(input_path)
    text_ws = wb.create_sheet(title="Text_by_page", index=0)
    text_ws.append(["Page", "Line", "Content"])
    for page_num, page in enumerate(doc):
        blocks = page.get_text("blocks", sort=True)
        line_num = 0
        for block in blocks:
            if len(block) < 7 or block[6] != 0:
                continue
            for line in (block[4] or "").splitlines():
                if line.strip():
                    line_num += 1
                    text_ws.append([page_num + 1, line_num, line.strip()])
    doc.close()
    _style_table_sheet(text_ws, text_ws.max_row, 3)

    if len(wb.sheetnames) == 0:
        ws = wb.create_sheet("Sheet1")
        ws.append(["No extractable content"])

    os.makedirs(os.path.dirname(os.path.abspath(output_path)) or ".", exist_ok=True)
    wb.save(output_path)


def main() -> int:
    parser = argparse.ArgumentParser(description="Office file converter")
    sub = parser.add_subparsers(dest="command", required=True)

    for cmd in ("docx2pdf", "xlsx2pdf", "pdf2xlsx", "pptx2pdf", "pdf2pptx"):
        p = sub.add_parser(cmd)
        p.add_argument("input_path")
        p.add_argument("output_path")

    args = parser.parse_args()
    try:
        if args.command == "docx2pdf":
            docx_to_pdf(args.input_path, args.output_path)
        elif args.command == "xlsx2pdf":
            xlsx_to_pdf(args.input_path, args.output_path)
        elif args.command == "pdf2xlsx":
            pdf_to_xlsx(args.input_path, args.output_path)
        elif args.command == "pptx2pdf":
            pptx_to_pdf(args.input_path, args.output_path)
        elif args.command == "pdf2pptx":
            pdf_to_pptx(args.input_path, args.output_path)
        print(args.output_path)
        return 0
    except Exception as exc:
        print(f"ERROR: {exc}", file=sys.stderr)
        return 1


if __name__ == "__main__":
    sys.exit(main())
