# PDF Topical Authority Map v2 — PDF-Only Mission

> Verified against codebase: `ContentLibrary.cs`, `GuideBodies*.cs`, `PdfToolSeo.cs`, `content-roadmap.csv`, `seo-audit-results.json` (June 2026).
> **Excluded from scope:** Invoice, payslip, rent receipt, JWT/JSON/HTML dev tools, word counter, utilities.

---

## Executive snapshot

| Asset | PDF-only count | Quality state |
|-------|----------------|---------------|
| Live editorial guides | **535** | **~97% thin** (<1500 words); ~100 upgraded in Waves 1–6 |
| Core PDF tools (`/pdf/*`) | **26** | Built and indexable |
| Programmatic SEO URLs | **~15,000** | Intent templates; support editorial, not replace |
| Compare pages | **11** | Adobe, iLovePDF, Smallpdf, PDF24, Sejda, Foxit, SodaPDF, PDF Candy, PDFelement, Wondershare |
| Research pages | **5** (3 PDF-core) | Under-developed vs competitors |
| PDF roadmap rows | **943** | 535 published, 30 deferred, 378 merged |

**Strategic truth:** You do not need 1000 new URLs. You need **~535 upgrades** + **~465 net-new unique-intent articles** to exceed 1000 **authority-grade** PDF pages.

---

## Layer 1 — Tools (BOFU)

| Cluster | Tool URL | Engine | Editorial hub |
|---------|----------|--------|---------------|
| Compression | `/pdf/compress` | Ghostscript | `/guides/compress-pdf-guide`, `/compress-pdf` |
| Merge | `/pdf/merge` | iText | `/guides/merge-pdf` |
| Split | `/pdf/split` | iText | `/guides/split-pdf` |
| PDF→Word | `/pdf/pdftodoc` | pdf2docx | `/guides/pdf-to-word` |
| Word→PDF | `/pdf/doctopdf` | Python | `/guides/word-to-pdf` |
| PDF→Excel | `/pdf/pdftoexcel` | pdf2xlsx | `/guides/pdf-to-excel` |
| Excel→PDF | `/pdf/exceltopdf` | Python | `/guides/excel-to-pdf` |
| PDF→PPT | `/pdf/pdftoppt` | Python | `/guides/pdf-to-powerpoint` |
| PPT→PDF | `/pdf/ppttopdf` | Python | `/guides/powerpoint-to-pdf` |
| PDF→Text | `/pdf/pdftotext` | iText | `/guides/pdf-txt-guide` |
| PDF→MD | `/pdf/pdftomarkdown` | Python | `/guides/pdf-to-markdown` |
| Text→PDF | `/pdf/texttopdf` | iText | `/guides/text-to-pdf` |
| HTML→PDF | `/pdf/htmltopdf` | iText | `/guides/html-to-pdf` |
| Images→PDF | `/pdf/convertimages` | iText | `/guides/images-to-pdf` |
| PDF→Images | `/pdf/pdftoimages` | Python | `/guides/pdf-to-images` |
| Extract images | `/pdf/extractimages` | Python | `/guides/extract-images-from-pdf` |
| Edit | `/pdf/editpdf` | PyMuPDF | `/guides/edit-pdf` |
| OCR | `/pdf/ocrpdf` | Tesseract | `/guides/ocr-pdf` |
| Watermark | `/pdf/watermark` | iText | `/guides/watermark-pdf` |
| Password | `/pdf/password` | iText | `/guides/password-protect-pdf` |
| Sign (typed) | `/pdf/signtext` | iText | `/guides/sign-pdf` |
| Unlock | `/pdf/unlockpdf` | iText | `/guides/unlock-pdf` |
| Flatten | `/pdf/flattenpdf` | iText | `/guides/flatten-pdf` |
| Rotate/remove | `/pdf/rotateorremove` | iText | `/guides/rotate-pdf` |
| Page numbers | `/pdf/pagenumbers` | iText | `/guides/add-page-numbers` |
| Metadata | `/pdf/pdfmetadata` | iText | `/guides/pdf-metadata` |
| Redaction | `/pdf-redaction` | pdf-lib (client) | `/guides/pdf-redaction` |
| Size checker | `/pdf-size-checker` | UI | links to compress |

**Tool gaps (no built tool — editorial + workaround only):** crop PDF, repair PDF, delete pages (split/rotate partial), compare two PDFs, PDF/A export, native e-sign certificates, AI chat PDF.

---

## Layer 2 — Editorial clusters (27 mission clusters)

| Mission cluster | Roadmap rows | Live (est.) | Thin % | Authority grade |
|-----------------|-------------|-------------|--------|-----------------|
| PDF Compression | 84 | 46 | 70% | **Strong hub**; waves 3–5 upgraded ~40 spokes |
| PDF Conversion | 71 | 45 | 95% | Pillars thin; waves 4–6 upgraded ~30 |
| PDF OCR | 10 | 10 | 100% | Wave 2 partial; language variants thin |
| PDF Editing | 10 | 6 | 100% | Wave 6 upgraded 6; **crop/annotate missing** |
| PDF Security | 25 | 22 | 91% | Redaction/watermark/password exist; shallow |
| PDF Signing | (in Secure) | 3 | 100% | Typed sign only; legal depth thin |
| PDF Forms | (in Edit/Flatten) | 4 | 100% | Flatten exists; fillable creation missing |
| PDF Accessibility | 12 | 11 | 100% | WCAG/508 guides exist; **checker not built** |
| PDF Printing | 0 | 0 | — | **Major gap** vs competitors |
| PDF Troubleshooting | 10 | 10 | 100% | Scattered mistakes; no repair hub |
| PDF Errors | 20 | 1 | 100% | Mistakes cluster barely live |
| PDF Workflows | 183 | 65 | 94% | Regional 152 all ultra-thin |
| PDF Productivity | 397 | 350+ | 99% | Glossary 144 + Best-of 300 templates |
| PDF Collaboration | 61 | 15 | 93% | Compare hub weak vs editorial depth |
| PDF Compliance | 17 | 11 | 100% | GDPR/HIPAA/SOX exist; need depth |
| PDF Archiving | 0 | 0 | — | **Gap** (PDF/A, retention) |
| PDF Standards | 10 | 4 | 100% | Advanced PDF cluster thin |
| PDF for Students | (Industry) | 5 | 100% | Persona landing exists |
| PDF for Businesses | 40 | 38 | 100% | Industry verticals all thin |
| PDF for Government | (in Compress) | 15 | 70% | Portal compress strong |
| PDF for Job Applications | (in Compress) | 6 | 80% | Partial |
| PDF for Visas | (in Compress/Merge) | 8 | 75% | Partial |
| PDF for Legal | (Industry/Merge) | 12 | 90% | Court/merge spokes upgraded |
| PDF Mobile Workflows | (Wave 5) | 4 | 0%* | iPhone/Android compress upgraded |
| PDF Mac Workflows | (Wave 5) | 2 | 0%* | Mac compress upgraded |
| PDF Windows Workflows | (Wave 5) | 2 | 0%* | Windows compress upgraded |
| PDF Browser Workflows | 0 | 0 | — | **Gap** |

\*Upgraded in Wave 5 only for compress cluster.

---

## Layer 3 — Programmatic SEO (supporting)

| Generator | Pattern | Role |
|-----------|---------|------|
| Compress programmatic | `/{slug}` from keyword file | Long-tail size/portal intents |
| Tool landings | `/{prefix}/{slug}` | Per-tool long-tail |
| PDF to Word | `/pdf-to-word/{slug}` | Document-type intents |
| PDF to Text | `/pdf-to-txt/{slug}` | Use-case intents |
| Edit PDF | `/edit-pdf/{slug}` | Task intents |

**Rule:** Programmatic owns head-term variants; editorial owns 1500+ word workflows. Cross-link programmatic → pillar → tool.

---

## Layer 4 — Compare & research

### Compare (commercial MOFU)
Live: 10 alternatives + hub. **Missing competitors:** PDFgear, Nitro PDF (named in mission; not in catalog).

### Research (E-E-A-T)
| Slug | PDF relevance |
|------|---------------|
| `attachment-size-limits` | Core |
| `pdf-compression-benchmark` | Core |
| `pdf-tool-market-comparison` | Core |
| `document-retention-periods` | Archiving/compliance |
| `freelancer-invoicing-statistics` | **Out of scope** |

**Needed research:** OCR accuracy benchmark, PDF accessibility audit data, court e-filing size survey, mobile PDF workflow study.

---

## Internal linking hierarchy

```
Research → Pillar guide → Cluster spoke → Tool CTA
                ↓
         Compare (commercial)
                ↓
    Programmatic long-tail (support)
```

Every authority article: 1 tool CTA + 1 pillar + 2 same-cluster spokes + 1 research/compare link.

---

## Path to 1000+ authority articles

| Source | Count | Action |
|--------|-------|--------|
| Upgrade existing thin live | 435 | Rewrite to 1500–4000 words (priority) |
| Already upgraded (Waves 1–6) | ~100 | Maintain + interlink |
| Deferred roadmap | 30 | Publish with full quality |
| Net-new unique intents | ~465 | Create only when no URL exists |
| **Total authority-grade target** | **~1030** | |

### Net-new intent buckets (~465 articles)

1. **Printing & display** (40): margins, color, blank pages, font embedding
2. **Troubleshooting & repair** (50): won't open, corrupted, repair, recovery
3. **Edit gaps** (45): crop, delete pages, annotate, highlight, compare PDFs
4. **Standards & archiving** (40): PDF/A, PDF/X, PDF/UA, long-term storage
5. **Browser/device** (60): Chrome/Edge/Safari save-as-PDF, Linux, iPad
6. **Industry × task** (80): legal, healthcare, RE, insurance, education
7. **Government × country** (70): IRS, USCIS, UKVI, Schengen, India portals
8. **Competitor comparisons** (25): PDFgear, Nitro, X vs Y tool pairs
9. **Educational fundamentals** (40): how PDF works, fonts, compression theory
10. **Collaboration** (25): review, comments, share, team workflows
11. **Accessibility remediation** (35): WCAG fix workflows per issue type

---

## Execution waves (PDF-only)

| Wave | Focus | Pages | Priority |
|------|-------|-------|----------|
| **7** | Upgrade thin **pillars** (compress, merge, split, pdf-to-word, ocr) | 5 | P0 |
| **8** | **Edit gaps**: crop, delete pages, annotate, organize (upgrade + new) | 17 | P0 |
| **9** | **Troubleshooting hub**: won't open, corrupt, repair, print errors | 17 | P0 |
| **10** | **Conversion depth**: pdf-to-jpg/png, excel, html, markdown spokes | 17 | P0 |
| **11** | **Security & compliance**: redaction, GDPR, HIPAA, 508 deep dives | 17 | P1 |
| **12** | **Standards & archiving**: PDF/A, retention, metadata | 17 | P1 |
| **13** | **Printing workflows** | 17 | P1 |
| **14** | **Browser + device** matrix (non-compress tools) | 17 | P1 |
| **15** | **Regional workflow upgrades** (152 templates → authority) | 17/batch | P2 |
| **16** | **Glossary upgrades** (144 → 1500+ word definitional guides) | 17/batch | P2 |
| **17+** | Industry, visa, legal, job, student spokes | 17/batch | P2 |

Continue until topical authority complete — not until arbitrary count.
