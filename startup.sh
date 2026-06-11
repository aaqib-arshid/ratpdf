#!/bin/bash
# RatPDF Azure App Service (Linux) startup script.
# Installs Python PDF conversion dependencies + LibreOffice, then starts the app.
set -euo pipefail

echo "[ratpdf] Starting dependency setup..."

export DEBIAN_FRONTEND=noninteractive
if command -v apt-get >/dev/null 2>&1; then
  apt-get update -qq
  apt-get install -y -qq \
    python3 \
    python3-pip \
    python3-venv \
    libreoffice \
    libreoffice-writer \
    libreoffice-calc \
    libreoffice-impress \
    tesseract-ocr \
    tesseract-ocr-eng \
    ghostscript \
    fonts-liberation \
    fonts-dejavu-core \
    fontconfig \
    >/dev/null 2>&1 || echo "[ratpdf] apt install warning (non-fatal)"
fi

APP_DIR="${APP_DIR:-/home/site/wwwroot}"
ENGINE_DIR="$APP_DIR/Pdf-Engine"

if [ -f "$ENGINE_DIR/requirements.txt" ]; then
  echo "[ratpdf] Installing Python packages..."
  python3 -m pip install --upgrade pip --quiet
  python3 -m pip install -r "$ENGINE_DIR/requirements.txt" --quiet
  python3 -c "import fitz, pdfplumber, pdf2docx, openpyxl; print('[ratpdf] Python OK')"
else
  echo "[ratpdf] WARNING: $ENGINE_DIR/requirements.txt not found"
fi

if command -v soffice >/dev/null 2>&1; then
  echo "[ratpdf] LibreOffice: $(soffice --version 2>/dev/null | head -1)"
else
  echo "[ratpdf] WARNING: LibreOffice (soffice) not found — Word/Excel conversion quality will suffer"
fi

export LIBREOFFICE_PATH="${LIBREOFFICE_PATH:-$(command -v soffice || true)}"
export PdfToDocx__PythonExecutable="${PdfToDocx__PythonExecutable:-python3}"

echo "[ratpdf] Launching ASP.NET Core..."
exec dotnet "$APP_DIR/ratpdf.dll"
