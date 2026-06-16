# PDF Topical Authority Map v3 — PDF-Only Mission

> Verified against codebase 2026-06-16: `ContentLibrary.cs`, `GuideBodiesWave1–15B.cs`,
> `PdfToolSeo.cs`, `content-roadmap.csv`, `seo-audit-results.json`.
> **Excluded:** Invoice, payslip, rent receipt, JWT/JSON/dev tools, word counter, utilities.

## Executive snapshot

| Asset | PDF-only count | Quality state |
|-------|----------------|---------------|
| Live editorial guides | **621** | **~383 thin**; **~238 wave-upgraded** |
| Core PDF tools (`/pdf/*`) | **26** | Production engines live |
| Programmatic SEO URLs | **~9,600** | Long-tail support; not authority tier |
| Compare pages | **11** (+7 compress) | Missing PDFgear, Nitro |
| Research pages (PDF-core) | **4** | Under-developed vs Adobe/iLovePDF |
| Article opportunities queued | **1001** | 406 UPGRADE · 145 MAINTAIN · 450 CREATE |

**Strategic truth:** Target **1000+ authority-grade** pages = **~551 upgraded/maintained** + **~450 net-new unique intents**.

## Wave execution status (authority upgrades)

| Wave | Cluster focus | Pages | Status |
|------|---------------|-------|--------|
| 1–6 | Compress, merge, OCR, Word, convert, edit | ~102 | ✅ Complete |
| 7 | Pillar upgrades (compress, merge, split, word, ocr) | 5 | ✅ Complete |
| 8 | Edit gaps (crop, annotate, device) | 17 | ✅ Complete |
| 9 | Troubleshooting hub | 17 | ✅ Complete |
| 10 | Conversion depth (jpg, excel, html) | 17 | ✅ Complete |
| 11 | Security & compliance | 17 | ✅ Complete |
| 12 | Standards & archiving | 17 | ✅ Complete |
| 13 | Printing workflows | 17 | ✅ Complete |
| 14 | Browser + device matrix | 17 | ✅ Complete |
| 15 | Regional workflows (batch 1+2) | 34 | ✅ Complete |
| **16** | **Glossary upgrades** | 144 | 🔲 Next |
| **17** | **Regional batch 3** (IT, MX, NZ, ZA, KR) | 9+ | 🔲 Planned |
| **18+** | Industry × task, forms, collaboration | 17/batch | 🔲 Planned |

## Layer 1 — Tools (26 core `/pdf/*`)

See `Constants/PdfToolSeo.cs`. Gaps (editorial only): crop, repair, compare PDFs, PDF/A export, certified e-sign, AI chat PDF.

## Layer 2 — Editorial clusters (27 mission clusters)

| Mission cluster | Live guides | Wave coverage | Gap vs competitors |
|-----------------|------------|---------------|-------------------|
| PDF Compression | 46 | Strong (W3,5,7) | Size variants covered; maintain |
| PDF Conversion | 71 | W4,6,10 | Depth improving; epub/csv thin |
| PDF Editing | 10+ | W6,8 | Crop/delete covered in W8; no crop tool |
| PDF OCR | 10 | W2,7 | Language variants still thin |
| PDF Security | 22 | W11 | Redaction client-side only |
| PDF Printing | 17 | W13 | **Now covered** (was gap) |
| PDF Troubleshooting | 10+ | W9 | Repair honesty; no repair engine |
| PDF Standards/Archiving | 17+ | W12 | PDF/A depth; no export tool |
| PDF Browser/Device | 17+ | W14 | **Now covered** (was gap) |
| PDF Regional | 152+ | W15 (34 upgraded) | 118 still thin templates |
| PDF Glossary | 144 | W13 partial (2) | **Major gap** — all ultra-thin |
| PDF Industry | 38 | Minimal | Adobe/iLovePDF have vertical hubs |

## Layer 3 — Programmatic SEO (~9,600 URLs)

| Generator | Pattern | Role |
|-----------|---------|------|
| Compress | `/{slug}` | Size/portal long-tail |
| PDF to Word | `/pdf-to-word/{slug}` | Document-type intents |
| PDF to Text | `/pdf-to-txt/{slug}` | Use-case intents |
| Edit PDF | `/edit-pdf/{slug}` | Task intents |
| Tool landings | `/{prefix}/{slug}` | Per-tool (mostly noindex) |

**Rule:** Programmatic ≤800 words + CTA. Editorial owns 1500–4000 word workflows.

## Layer 4 — Compare & research

### Compare (live 11 + 7 compress-specific)
Adobe, iLovePDF, Smallpdf, PDF24, Sejda, Foxit, SodaPDF, PDF Candy, PDFelement, Wondershare.

**Missing vs mission competitors:** PDFgear, Nitro PDF, PDFsam, Able2Extract.

### Research (PDF-core)
- attachment-size-limits, pdf-compression-benchmark, pdf-tool-market-comparison, document-retention-periods

**Needed:** OCR accuracy benchmark, accessibility audit study, e-filing size survey.

## Competitor gap summary

| Competitor | RatPDF gap | Priority |
|------------|-----------|----------|
| Adobe | Preflight, PDF/A export, compare PDFs, certified sign | P1 editorial |
| iLovePDF | Repair PDF, organize hub depth, mobile app guides | P0 troubleshooting |
| Smallpdf | AI PDF, team plans, scanner workflow | P2 |
| PDFgear | No compare page; AI chat PDF | P0 compare + editorial |
| Foxit | ConnectedPDF, enterprise redaction depth | P2 |
| Nitro | No compare page; SharePoint e-sign workflows | P0 compare |
| Sejda | Crop PDF (they rank); hourly limit guides | P1 (W8 covered edit) |
| PDF24 | Offline Creator, virtual printer, privacy angle | P1 editorial |

## Path to 1000+ authority articles

| Source | Count | Action |
|--------|-------|--------|
| Wave-upgraded (maintain) | ~238 | Interlink + refresh quarterly |
| Upgrade existing thin | ~406 | Rewrite 1500–4000 words |
| Net-new unique intents | ~450 | Create only when no URL exists |
| **Total queued** | **1001** | Sorted by priority_score |

**Stop condition:** PDF topical authority complete — not arbitrary URL count.
