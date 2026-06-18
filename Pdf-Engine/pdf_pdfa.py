#!/usr/bin/env python3
"""Convert PDF to PDF/A-1b or PDF/A-2b — PyMuPDF rebuild with PDF/A XMP metadata."""

from __future__ import annotations

import argparse
import os
import shutil
import subprocess
import sys

import fitz

_PDFA_XMP = """<?xpacket begin="" id="W5M0MpCehiHzreSzNTczkc9d"?>
<x:xmpmeta xmlns:x="adobe:ns:meta/">
 <rdf:RDF xmlns:rdf="http://www.w3.org/1999/02/22-rdf-syntax-ns#">
  <rdf:Description rdf:about="" xmlns:pdfaid="http://www.aiim.org/pdfa/ns/id/">
   <pdfaid:part>{part}</pdfaid:part>
   <pdfaid:conformance>B</pdfaid:conformance>
  </rdf:Description>
 </rdf:RDF>
</x:xmpmeta>
<?xpacket end="w"?>"""


def _ghostscript_bin() -> str | None:
    for name in ("gs", "gswin64c", "gswin32c"):
        path = shutil.which(name)
        if path:
            return path
    return None


def convert_ghostscript(input_path: str, output_path: str, pdfa_level: int) -> bool:
    """Best-effort Ghostscript PDF/A — returns False on failure (caller falls back)."""
    gs = _ghostscript_bin()
    if not gs:
        return False

    pdfa = 1 if pdfa_level <= 1 else 2
    args = [
        gs,
        f"-dPDFA={pdfa}",
        "-dBATCH",
        "-dNOPAUSE",
        "-sProcessColorModel=DeviceRGB",
        "-sDEVICE=pdfwrite",
        "-sPDFACompatibilityPolicy=1",
        "-dEmbedAllFonts=true",
        f"-sOutputFile={output_path}",
        input_path,
    ]
    result = subprocess.run(args, capture_output=True, text=True)
    if result.returncode != 0:
        return False
    return os.path.isfile(output_path) and os.path.getsize(output_path) > 0


def convert_pymupdf(input_path: str, output_path: str, pdfa_level: int) -> None:
    doc = fitz.open(input_path)
    try:
        if doc.page_count == 0:
            raise ValueError("PDF has no readable pages.")
        part = "2" if pdfa_level > 1 else "1"
        try:
            doc.set_xml_metadata(_PDFA_XMP.format(part=part))
        except Exception:
            pass
        doc.save(output_path, garbage=4, deflate=True, clean=True)
    finally:
        doc.close()


def main() -> int:
    parser = argparse.ArgumentParser(description="Convert PDF to PDF/A")
    parser.add_argument("input_pdf")
    parser.add_argument("output_pdf")
    parser.add_argument("--level", choices=("1", "2", "1b", "2b"), default="1b")
    args = parser.parse_args()

    input_path = os.path.abspath(args.input_pdf)
    output_path = os.path.abspath(args.output_pdf)
    level_num = 1 if args.level.startswith("1") else 2

    if not os.path.isfile(input_path):
        raise FileNotFoundError(f"PDF not found: {input_path}")

    os.makedirs(os.path.dirname(output_path) or ".", exist_ok=True)

    if convert_ghostscript(input_path, output_path, level_num):
        print(output_path)
        return 0

    convert_pymupdf(input_path, output_path, level_num)
    if not os.path.isfile(output_path) or os.path.getsize(output_path) == 0:
        raise RuntimeError("PDF/A conversion produced an empty file.")
    print(output_path)
    return 0


if __name__ == "__main__":
    sys.exit(main())
