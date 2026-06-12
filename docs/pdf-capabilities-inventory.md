# PDF Capabilities Inventory & Competitive Gap Analysis

## Architecture (all tools)

```
Upload → Azure Blob (staging/{jobId}/…)
      → JobQueue worker (configurable concurrency)
      → Temp-file / page-by-page processing (constant memory)
      → Result → Azure Blob ({tool}/{jobId}/…)
      → Poll /PDF/status/{jobId}
      → Stream download /PDF/download/{jobId}
      → Blob deleted after download completes
```

Limits: **200 MB** free / **4 GB** premium per file, **3** files per batch.

---

## Current tool inventory

| Tool | Route | Engine | Job kind |
|------|-------|--------|----------|
| Merge PDF | `/PDF/Merge` | iText (disk) | `merge` |
| Split PDF | `/PDF/Split` | iText | `split` |
| Compress PDF | `/PDF/Compress` | Ghostscript / iText | `compress` |
| PDF → Word | `/PDF/PdfToDoc` | Python pdf2docx + OCR | `pdf2docx` |
| Word → PDF | `/PDF/DocToPdf` | LibreOffice | `doctopdf` |
| PDF → Excel | `/PDF/PdfToExcel` | Python | `pdftoxlsx` |
| Excel → PDF | `/PDF/ExcelToPdf` | LibreOffice | `exceltopdf` |
| Edit PDF | `/PDF/EditPDF` | PyMuPDF session | sync |
| PDF → Text | `/PDF/PdfToText` | Python + iText fallback | `pdftotext` |
| Text → PDF | `/PDF/TextToPdf` | iText / HTML | `texttopdf` |
| Watermark | `/PDF/Watermark` | iText | `watermark` |
| Password protect | `/PDF/Password` | iText AES | `password` |
| Sign PDF | `/PDF/SignText` | iText | `signpdf` |
| Rotate / Remove page | `/PDF/RotateOrRemove` | iText | `rotate` |
| Images → PDF | `/PDF/ConvertImages` | iText | `convertimages` |
| **Unlock PDF** | `/PDF/UnlockPdf` | iText | `unlockpdf` |
| **Flatten PDF** | `/PDF/FlattenPdf` | iText forms | `flattenpdf` |
| **PDF → Images** | `/PDF/PdfToImages` | PyMuPDF page render | `pdftoimages` |
| **Extract images** | `/PDF/ExtractImages` | PyMuPDF | `extractimages` |
| **OCR PDF** | `/PDF/OcrPdf` | Tesseract + PyMuPDF | `ocrpdf` |
| **Page numbers** | `/PDF/PageNumbers` | iText | `pagenumbers` |
| **PDF metadata** | `/PDF/PdfMetadata` | iText | `pdfmetadata` |

Utilities (non-job): ImgToBase64, Html/Json formatters, browser OCR (`/ocr-tool`), client-side redaction placeholder.

Document generators (separate): Invoice, Payslip, Rent Receipt PDFs.

---

## Competitive gap analysis

### Implemented in this release (high value)

| Feature | Competitors | Status |
|---------|-------------|--------|
| Unlock / remove password | Adobe, Smallpdf, iLovePDF | **Added** |
| Flatten forms | Adobe, Foxit | **Added** |
| PDF → PNG ZIP | Adobe export | **Added** |
| Extract embedded images | Adobe, PDF Candy | **Added** |
| Server OCR (searchable PDF) | Adobe Scan, ABBYY | **Added** |
| Page numbering | Most suites | **Added** |
| Metadata export | Pro tools | **Added** |
| Persistent job audit (SQL) | Enterprise APIs | **Added** (`PdfJobRecords`) |
| Blob-centric 4 GB pipeline | Enterprise | **Existing + extended** |

### Still missing (future roadmap)

| Feature | Priority | Notes |
|---------|----------|-------|
| PDF → PowerPoint | High | LibreOffice / python-pptx |
| PDF → HTML (job) | High | Existing sync path only |
| Compare PDFs | High | Diff library or page hash |
| Bates numbering | Enterprise | Sequential prefix per page |
| Redact (server job) | High | `pdf_edit_engine` apply API |
| Digital signature (cert) | Enterprise | PKCS#7 / HSM |
| PDF/A conversion | Enterprise | Ghostscript `-dPDFA` |
| Repair PDF | Medium | qpdf / mutool |
| Crop / resize pages | Medium | iText page boxes |
| Batch REST API + API keys | Enterprise | Auth + webhooks |
| Webhooks on job complete | Enterprise | Queue callback |
| Redis job store | Scale-out | Replace in-memory poll |
| AI summarization / Q&A | AI products | LLM + extracted text |
| AI table extraction | AI products | Extend `table_extractor.py` |

### Legacy debt

- `PdfConversionService` still has `byte[]` APIs (ATS, ImgToBase64).
- Invoice/Payslip PDF generators use `MemoryStream` (small outputs).
- `JobResultStore` hot path is in-memory; SQL is audit trail.

---

## Database migration

Run on SQL Server to enable job audit:

```sql
CREATE TABLE [PdfJobRecords] (
    [JobId] NVARCHAR(64) NOT NULL PRIMARY KEY,
    [JobKind] NVARCHAR(64) NOT NULL,
    [Status] NVARCHAR(32) NOT NULL,
    [BlobName] NVARCHAR(512) NULL,
    [OutputFileName] NVARCHAR(256) NULL,
    [OutputMimeType] NVARCHAR(128) NULL,
    [InputBytes] BIGINT NULL,
    [OutputBytes] BIGINT NULL,
    [ErrorMessage] NVARCHAR(MAX) NULL,
    [UserId] UNIQUEIDENTIFIER NULL,
    [CreatedUtc] DATETIME2 NOT NULL,
    [UpdatedUtc] DATETIME2 NOT NULL
);
CREATE INDEX IX_PdfJobRecords_UpdatedUtc ON [PdfJobRecords]([UpdatedUtc]);
CREATE INDEX IX_PdfJobRecords_UserId ON [PdfJobRecords]([UserId]);
```

---

## Performance configuration

`appsettings.json` → `PdfProcessing`:

- `StreamBufferBytes`: 4194304 (4 MB)
- `MaxConcurrentJobs`: 1 (raise on larger App Service plans)
- `MaxQueuedJobs`: 32
