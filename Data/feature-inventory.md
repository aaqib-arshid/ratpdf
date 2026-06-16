# RatPDF Feature Inventory (Code-Verified)

> Generated from codebase analysis. Only features that exist in routes, controllers, or services.
> **Excluded:** Medical calculators (HTTP 410), background remover API (throws), ATS dashboard (throws), VAT invoice checker (not built), PDF accessibility checker (not built).

---

## Product Purpose

RatPDF is a browser-based **PDF toolkit + business document generator** for freelancers, SMBs, students, and office workers. Core value: free PDF operations in the browser with optional Pro/Business subscriptions for higher limits, branding, and bulk invoicing.

---

## Core PDF Tools (26) — `/pdf/*`

| Tool | Route | Engine | Output |
|------|-------|--------|--------|
| Merge PDF | `/pdf/merge` | iText | PDF (2–30 files) |
| Split PDF | `/pdf/split` | iText | PDF (page range) |
| Compress PDF | `/pdf/compress` | Ghostscript + iText fallback | PDF (Extreme/Recommended/Less) |
| Image to PDF | `/pdf/convertimages` | iText | PDF |
| Text to PDF | `/pdf/texttopdf` | iText HTML | PDF |
| HTML to PDF | `/pdf/htmltopdf` | iText | PDF |
| PDF to Text | `/pdf/pdftotext` | iText | TXT |
| PDF to Markdown | `/pdf/pdftomarkdown` | iText + converter | MD |
| PDF to Word | `/pdf/pdftodoc` | Python pdf2docx | DOCX / ZIP |
| Word to PDF | `/pdf/doctopdf` | Python | PDF |
| PDF to Excel | `/pdf/pdftoexcel` | Python pdf2xlsx | XLSX |
| Excel to PDF | `/pdf/exceltopdf` | Python | PDF |
| PDF to PowerPoint | `/pdf/pdftoppt` | Python | PPTX |
| PowerPoint to PDF | `/pdf/ppttopdf` | Python | PDF |
| Edit PDF | `/pdf/editpdf` | PyMuPDF session editor | PDF |
| Watermark PDF | `/pdf/watermark` | iText | PDF |
| Password Protect | `/pdf/password` | iText encryption | PDF |
| Sign PDF (typed) | `/pdf/signtext` | iText | PDF |
| Rotate / Remove Pages | `/pdf/rotateorremove` | iText | PDF |
| Unlock PDF | `/pdf/unlockpdf` | iText (requires password) | PDF |
| Flatten PDF | `/pdf/flattenpdf` | iText | PDF |
| PDF to Images | `/pdf/pdftoimages` | Python | ZIP (JPG/PNG) |
| Extract Images | `/pdf/extractimages` | Python | ZIP |
| OCR PDF (server) | `/pdf/ocrpdf` | Python Tesseract | Searchable PDF |
| Page Numbers | `/pdf/pagenumbers` | iText | PDF |
| PDF Metadata | `/pdf/pdfmetadata` | iText | JSON |

**Client-only PDF tools:**
- PDF Redaction — `/pdf-redaction` (pdf-lib, browser)
- Browser OCR — `/ocr-tool` (Tesseract.js, browser)

---

## Invoice System — `/invoice/*`

| Feature | Route | Notes |
|---------|-------|-------|
| Invoice generator | `/invoice/create` | 90+ currencies; tax name/rate; line items |
| PDF export | POST `/invoice/generatepdf` | PDF only; guest = no DB save |
| GST fields in PDF | Entity + InvoicePdfService | CGST/SGST/IGST split when data present |
| Bulk CSV invoices | `/invoice/bulk` | Business tier; max 100 rows; INR; ZIP output |
| Saved templates | `/templates/*` | Pro: 1; Business: unlimited |
| Branding | `/branding/edit` | Logo, colors, UPI QR; Pro/Business |
| Dashboard | `/invoicedashboard` | Auth; paginated history |
| GST checker | `/gst-invoice-checker` | Interactive compliance checklist |
| SEO landings | 40+ `/invoice/*` slugs | Same generator; country/profession variants |

**Not on main form:** GSTIN, HSN/SAC, place of supply (bulk CSV only).

---

## Payslip & Receipts

| Feature | Route | Output |
|---------|-------|--------|
| Free payslip | `/free-payslip-generator` | PDF |
| Bulk payslip | `/bulk-payslip-generator` | ZIP; paid (₹499/999) |
| Rent receipt | `/rent-receipt-generator` | PDF |
| Payslip SEO | `/salary-slip/{slug}` | ~1,718 programmatic pages |

---

## Image Tools

| Tool | Route | Implementation |
|------|-------|----------------|
| Image Compressor | `/pdf/imagecompressor` | Client canvas |
| Bulk Image Compressor | `/bulk-image-compressor` | Client |
| Image Resizer | `/image-resizer` | Client |
| Format Converter | `/image-format-converter` | Client |
| Favicon Generator | `/favicon-generator` | Client |
| Background Remover | `/tools/imgbackgroundremove` | **Disabled** (POST throws) |

---

## Developer & Utility Tools

| Tool | Route |
|------|-------|
| JSON Formatter | `/pdf/jsonformatter` |
| JWT Decoder | `/pdf/jwtdecoder` |
| HTML Formatter | `/pdf/htmlformatter` |
| Img to Base64 | `/pdf/imgtobase64` |
| Text Comparer | `/text-comparer` |
| URL Encoder/Decoder | `/url-encoder`, `/url-decoder` |
| Binary ↔ Decimal | `/binary-to-decimal`, `/decimal-to-binary` |
| DNS Lookup | `/tools/dnslookup` |
| IP Lookup / What Is My IP | `/tools/iplookup`, `/tools/whatismyip` |
| Word Counter | `/tools/wordcounter` |
| QR Code Generator | `/qr-code-generator` |
| Password Generator | `/password-generator` |
| Ring Size Converter | `/tools/ringsizeconverter` |

---

## Calculators & Checkers

| Tool | Route |
|------|-------|
| Age Calculator | `/age-calculator` |
| EMI Calculator | `/emi-calculator` |
| Percentage Calculator | `/percentage-calculator` |
| Period Calculator | `/period-calculator` |
| Freelance Rate Calculator | `/freelance-rate-calculator` |
| PDF Size Checker | `/pdf-size-checker` |
| GSC Content Decay Tool | `/tools/gscindex` |

---

## Subscription Tiers

| Tier | PDF limits | Invoice |
|------|------------|---------|
| Free | 3 uses/tool/day; 50 MB/file | Watermarked PDF |
| Pro ($8.99/mo) | Unlimited; 100 MB/file | Branding; 1 template |
| Business ($35.99/mo) | Same as Pro | Bulk CSV; unlimited templates |

---

## Research / Link Assets (Live)

| Page | Path |
|------|------|
| Attachment size limits | `/research/attachment-size-limits` |
| PDF compression benchmark | `/research/pdf-compression-benchmark` |
| Freelancer invoicing stats | `/research/freelancer-invoicing-statistics` |
| Document retention periods | `/research/document-retention-periods` |
| PDF tool market comparison | `/research/pdf-tool-market-comparison` |
| Resources hub | `/resources` |

---

## Editorial Content (Published)

- **47 guides** at `/guides/{slug}`
- **19 blogs** at `/blog/{slug}`
- **3 vertical landings:** lawyers, accountants, students
- **8 compare pages** + hub at `/compare`
- **21 SEO pillars** (pdf-to-txt, pdf-to-word, edit-pdf)
- **45 curated compress spokes** + ~2,500 programmatic compress URLs (intent-filtered)

---

## Supported Industries (Explicit in Code)

Lawyers, accountants, students, freelancers, Indian GST businesses, global invoicing (12+ country SEO pages), HR/payroll (India), landlords (rent receipts), developers, ecommerce product photos (bg remove — disabled).

---

## Export Formats

PDF, DOCX, XLSX, PPTX, TXT, MD, JSON, ZIP (multi-file/images), JPG/PNG (in ZIP or client download).
