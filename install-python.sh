#!/bin/bash
# Installs system + Python dependencies for Pdf-Engine.
# Azure does not persist apt packages — must run on every container boot.
set -uo pipefail

log() { echo "[ratpdf] $(date -u +%H:%M:%S) $*"; }

APP_DIR="${APP_DIR:-/home/site/wwwroot}"
ENGINE_DIR="$APP_DIR/Pdf-Engine"
MARKER="/home/site/.python-executable"
LOCK="/home/site/.python-install.lock"
MINIFORGE="/home/site/miniforge3"

APT_PACKAGES=(
  python3 python3-pip python3-venv curl
  ghostscript
  libreoffice libreoffice-writer libreoffice-calc libreoffice-impress
  tesseract-ocr tesseract-ocr-eng
  libgdiplus fontconfig fonts-liberation fonts-dejavu-core
)

find_soffice() {
  for candidate in /usr/bin/soffice /usr/lib/libreoffice/program/soffice /usr/bin/libreoffice; do
    if [ -x "$candidate" ]; then
      echo "$candidate"
      return 0
    fi
  done
  command -v soffice 2>/dev/null || true
}

find_system_python() {
  local candidate
  for candidate in /usr/bin/python3 /usr/local/bin/python3; do
    if [ -x "$candidate" ]; then
      echo "$candidate"
      return 0
    fi
  done
  if [ -x "$MINIFORGE/bin/python" ]; then
    echo "$MINIFORGE/bin/python"
    return 0
  fi
  command -v python3 2>/dev/null || true
}

install_miniforge() {
  if [ -x "$MINIFORGE/bin/python" ]; then
    echo "$MINIFORGE/bin/python"
    return 0
  fi
  log "Installing Miniforge fallback..."
  local installer="/tmp/miniforge.sh"
  curl -fsSL \
    "https://github.com/conda-forge/miniforge/releases/latest/download/Miniforge3-Linux-x86_64.sh" \
    -o "$installer" || return 1
  bash "$installer" -b -p "$MINIFORGE" || { rm -f "$installer"; return 1; }
  rm -f "$installer"
  echo "$MINIFORGE/bin/python"
}

install_apt_packages() {
  if ! command -v apt-get >/dev/null 2>&1; then
    log "apt-get not available"
    return 0
  fi
  log "Installing system packages (LibreOffice ~3-5 min on first boot)..."
  export DEBIAN_FRONTEND=noninteractive
  apt-get update -qq 2>&1 | tail -3 || true
  apt-get install -y -qq "${APT_PACKAGES[@]}" 2>&1 | tail -20 || log "apt-get warnings"
  log "apt-get done"
}

write_python_marker() {
  echo "$1" > "$MARKER"
  echo "$1" > "$APP_DIR/.python-executable" 2>/dev/null || true
}

python_packages_ok() {
  local py="$1"
  [ -n "$py" ] && [ -x "$py" ] && "$py" -c "import fitz, pdfplumber, pdf2docx, openpyxl, pytesseract" 2>/dev/null
}

install_pip_packages() {
  local py="$1"
  log "Installing pip packages for $py..."
  "$py" -m pip install --upgrade pip --break-system-packages 2>&1 | tail -2 || true
  if [ -f "$ENGINE_DIR/requirements.txt" ]; then
    "$py" -m pip install -r "$ENGINE_DIR/requirements.txt" --break-system-packages 2>&1 | tail -12 || true
  else
    "$py" -m pip install --break-system-packages \
      PyMuPDF pdfplumber python-docx pdf2docx Pillow pytesseract openpyxl 2>&1 | tail -8 || true
  fi
  "$py" -c "import fitz, pdfplumber, pdf2docx, openpyxl, pytesseract; print('[ratpdf] Python packages OK')" \
    || log "WARNING: pip import check failed"
}

write_env_marker() {
  local py="$1"
  local lo="$2"
  local envfile="/home/site/.ratpdf-env"
  {
    echo "PdfToDocx__PythonExecutable=$py"
    [ -n "$lo" ] && echo "LIBREOFFICE_PATH=$lo"
    echo "TESSERACT_CMD=/usr/bin/tesseract"
  } > "$envfile"
}

# Single installer instance
exec 200>"$LOCK"
if ! flock -n 200; then
  log "Install already running — exit"
  exit 0
fi

log "install-python.sh starting (APP_DIR=$APP_DIR)"

# ALWAYS install apt packages first (LibreOffice is required for DOCX→PDF)
install_apt_packages

PY="$(find_system_python)"
if [ -z "$PY" ] || [ ! -x "$PY" ]; then
  PY="$(install_miniforge || true)"
fi
if [ -z "$PY" ] || [ ! -x "$PY" ]; then
  log "ERROR: no Python found"
  exit 1
fi

if ! python_packages_ok "$PY"; then
  install_pip_packages "$PY"
fi

write_python_marker "$PY"

SOFFICE="$(find_soffice)"
if [ -n "$SOFFICE" ]; then
  log "LibreOffice: $SOFFICE ($($SOFFICE --version 2>/dev/null | head -1))"
else
  log "ERROR: LibreOffice (soffice) not found after apt install"
fi

if command -v tesseract >/dev/null 2>&1; then
  log "Tesseract: $(tesseract --version 2>/dev/null | head -1)"
else
  log "WARNING: tesseract not found"
fi

write_env_marker "$PY" "$SOFFICE"
log "Python=$PY LibreOffice=${SOFFICE:-MISSING}"
log "install-python.sh done"
exit 0
