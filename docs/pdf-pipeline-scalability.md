# PDF Pipeline Scalability

## Goals

- Support PDFs up to **4 GB** (premium tier).
- Keep **constant memory** during async job processing (no full-file `byte[]` / `MemoryStream` buffering).
- Use **Azure Blob Storage** as the source of truth for job inputs and outputs.
- Target **5–10 minutes** for 4 GB conversions on a adequately sized App Service instance (depends on CPU, Python/pdf2docx, OCR).

## Architecture

```
Upload (IFormFile)
    → stream to blob (staging/{jobId}/…)
    → job queue worker
    → blob → temp file (streamed, 4 MB buffers)
    → Python / Ghostscript / iText (local path)
    → output temp file
    → UploadFromFileAsync → blob (results/{kind}/{jobId}/…)
    → client downloads via OpenReadAsync (streamed)
```

Peak RAM is bounded by **buffer size × concurrency**, not file size.

## Changes (async job path)

| Component | Before | After |
|-----------|--------|-------|
| `AzureBlobService` | `DownloadToAsync` → `MemoryStream` | `OpenReadAsync`, `DownloadToFileAsync`, chunked `UploadStreamAsync` |
| `PdfJobStorageService` | — | Stages uploads to blob; materializes to temp on demand |
| `PdfToDocxJobService` | All outputs in `byte[]`, ZIP in `MemoryStream` | Disk outputs, ZIP on disk, `UploadFromFileAsync` |
| `PdfOfficeJobService` | `ReadAllBytes` + `MemoryStream` upload | File-based conversion + `UploadFromFileAsync` |
| `PdfCompressionService` | Re-copied stream to temp | `CompressFromFileAsync` avoids duplicate copy when input already on disk |
| `PDFController` | Temp-only inputs; buffered download | Blob staging; streamed download with range requests |
| `JobQueue` | Single worker, swallowed exceptions | Configurable parallel workers + structured logging/metrics |

## Configuration (`appsettings.json`)

```json
"PdfProcessing": {
  "StreamBufferBytes": 4194304,
  "MaxConcurrentJobs": 1,
  "MaxQueuedJobs": 32
}
```

Keep `MaxConcurrentJobs` at **1** on small instances when processing multi-GB files.

## Metrics

`PdfProcessingMetrics` logs per job:

- Elapsed milliseconds
- Working set (MB) and delta
- GC heap (MB)
- Input/output bytes

Search logs for `PDF pipeline` to monitor throughput and memory.

## Expected improvements

| Scenario | Before | After |
|----------|--------|-------|
| 4 GB compress / pdf2docx job | OOM risk (output + ZIP in RAM) | ~16–32 MB buffers + one temp file at a time |
| Result download | Full blob in `MemoryStream` | Streamed from blob to client |
| Multi-file pdf2docx ZIP | Entire ZIP in RAM | ZIP built on disk, uploaded from file |
| Scale-out | Temp files local to instance | Staging blobs shared across instances |

## All PDF tools (unified job pipeline)

Every PDF tool now follows the same pattern:

1. Upload → blob staging (`staging/{jobId}/…`)
2. Background worker → disk-based processing (`PdfConversionFileOps` / Python / Ghostscript)
3. Result → blob (`{tool}/{jobId}/…`)
4. Client polls `/PDF/status/{jobId}` then downloads `/PDF/download/{jobId}`
5. **Blob deleted after download completes** via `BlobDeletingStream` (on stream dispose)

| Tool | Job kind |
|------|----------|
| Merge, Split, Watermark, Password, Sign, Rotate/Remove | `merge`, `split`, `watermark`, … |
| Compress, PDF→DOCX, Office conversions | existing async jobs |
| Images→PDF, Text→PDF, PDF→Text | `convertimages`, `texttopdf`, `pdftotext` |

Legacy sync `PdfConversionService` byte[] methods remain for internal use only; HTTP endpoints return `202 Accepted` with `jobId`.

## Blob lifecycle

- **Staging blobs** deleted when the job worker finishes (success or failure).
- **Result blobs** deleted when the download stream is fully consumed/disposed — not at download start.
- Re-downloading the same `jobId` returns 404 after the first successful download (`ClearResultBlob`).

## Operational notes

- Ensure App Service **Startup Command** runs `startup.sh` so Python/LibreOffice are available for conversions.
- Blob cleanup: `/PDF/cleanup-temp?key=…` removes blobs older than 30 minutes.
- For 4 GB / 5–10 min target: use at least **P1v3** (2 vCPU, 8 GB RAM) or higher; OCR-heavy scanned PDFs will take longer.
