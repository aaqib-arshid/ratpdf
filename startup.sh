#!/bin/bash
# RatPDF Azure startup — background deps + immediate dotnet (keeps health check happy).
DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
INSTALL_LOG="/home/site/ratpdf-install.log"

log() { echo "[ratpdf] $*"; }

load_env_marker() {
  local envfile="/home/site/.ratpdf-env"
  if [ -f "$envfile" ]; then
    set -a
    # shellcheck disable=SC1090
    source "$envfile"
    set +a
  fi
}

# Start apt/LibreOffice/pip install in background — blocks 5+ min if run synchronously
if [ -f "$DIR/install-python.sh" ]; then
  log "Background install started (tail -f $INSTALL_LOG)"
  nohup bash "$DIR/install-python.sh" >> "$INSTALL_LOG" 2>&1 &
fi

load_env_marker

if [ -z "${PdfToDocx__PythonExecutable:-}" ] && [ -f /home/site/.python-executable ]; then
  export PdfToDocx__PythonExecutable="$(cat /home/site/.python-executable)"
fi
if [ -z "${PdfToDocx__PythonExecutable:-}" ] && [ -x /usr/bin/python3 ]; then
  export PdfToDocx__PythonExecutable="/usr/bin/python3"
fi
if [ -z "${PdfToDocx__PythonExecutable:-}" ] && [ -x /home/site/miniforge3/bin/python ]; then
  export PdfToDocx__PythonExecutable="/home/site/miniforge3/bin/python"
fi

if [ -z "${LIBREOFFICE_PATH:-}" ]; then
  for lo in /usr/bin/soffice /usr/lib/libreoffice/program/soffice; do
    if [ -x "$lo" ]; then
      export LIBREOFFICE_PATH="$lo"
      break
    fi
  done
fi
export TESSERACT_CMD="${TESSERACT_CMD:-/usr/bin/tesseract}"
export HOME="${HOME:-/tmp}"
export SAL_USE_VCLPLUGIN="${SAL_USE_VCLPLUGIN:-svp}"
export SAL_DISABLE_OPENCL="${SAL_DISABLE_OPENCL:-1}"
unset DISPLAY 2>/dev/null || true

log "Launching dotnet python=${PdfToDocx__PythonExecutable:-unset} libreoffice=${LIBREOFFICE_PATH:-installing...}"
exec dotnet "$DIR/ratpdf.dll"
