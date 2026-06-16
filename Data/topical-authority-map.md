# Topical Authority Map — RatPDF

## Architecture: Hub → Cluster → Spoke → Tool

```
                    ┌─────────────────┐
                    │  ratpdf.com /   │
                    │  guides/pdf-tools│  ← MASTER HUB (26 tools)
                    └────────┬────────┘
         ┌───────────────────┼───────────────────┐
         ▼                   ▼                   ▼
  ┌─────────────┐    ┌─────────────┐    ┌─────────────┐
  │  /resources │    │  /compare   │    │  /learn     │
  │  (research) │    │  (commercial)│    │  (video)    │
  └──────┬──────┘    └──────┬──────┘    └─────────────┘
         │                  │
    5 research studies   8 competitor alts
```

## 12 Primary Topic Clusters (1,239 editorial articles planned)

| # | Cluster | Hub URL | Tool | Articles | E-E-A-T lever |
|---|---------|---------|------|----------|---------------|
| 1 | **Compress PDF** | `/compress-pdf` | `/pdf/compress` | ~180 | Benchmark study + size checker |
| 2 | **PDF to Text & OCR** | `/pdf-to-txt/pdf-to-text-online` | `/pdf/pdftotext`, `/pdf/ocrpdf` | ~120 | 13 pillars + OCR guide |
| 3 | **PDF to Word** | `/guides/pdf-to-word` | `/pdf/pdftodoc` | ~80 | Conversion limits honesty |
| 4 | **Merge & Split** | `/guides/merge-pdf` | `/pdf/merge`, `/pdf/split` | ~80 | Vector preservation |
| 5 | **Secure PDF** | `/guides/secure-pdf-workflow` | password/watermark/sign/redact | ~90 | James Cole reviewer |
| 6 | **Edit PDF** | `/guides/edit-pdf` | `/pdf/editpdf` | ~60 | Compliance mistakes blog |
| 7 | **Convert Formats** | `/guides/pdf-tools` | office/html/md/image tools | ~100 | Multi-format workflows |
| 8 | **Invoice & GST** | `/guides/invoice-generator-guide` | `/invoice/create` | ~200 | Priya Sharma + GST checker |
| 9 | **Payslip & Payroll** | `/free-payslip-generator` | payslip/bulk/rent | ~70 | India compliance |
| 10 | **Compare & Buy** | `/compare` | `/compare/*` | ~80 | Market comparison research |
| 11 | **Industry Verticals** | persona landings | mixed | ~120 | Lawyers/accountants/students + 15 new |
| 12 | **Developer Tools** | `/guides/developer-tools` | json/jwt/html/dns | ~60 | API debugging blogs |

## Adjacent Clusters (supporting authority)

| Cluster | Articles | Purpose |
|---------|----------|---------|
| PDF Fundamentals (beginner) | ~20 | TOFU; links to tools |
| Glossary | ~120 | Definition SERPs; internal link hub |
| Troubleshooting | ~40 | Problem-solving intent |
| Compliance (GST/VAT/GDPR/508) | ~30 | YMYL-adjacent; cite research |
| Checklists | ~10 | Linkable assets |
| Regional workflows | ~144 | Country × document matrix |
| Best-of listicles | ~300 | Commercial investigation |
| X vs Y comparisons | ~50 | Decision content |
| Common mistakes | ~28 | E-E-A-T experience signals |
| Research & data | ~30 | Backlink magnets |

## Cannibalization Rules

1. **One primary URL per primary keyword** — check `content-roadmap.csv` before publishing
2. **Programmatic ≠ Editorial** — `/compress-pdf-to-100kb` (programmatic) vs `/guides/compress-pdf-to-100kb` (editorial deep dive) must differ: programmatic = intent template; editorial = 2500+ word guide
3. **Pillars win over long-tail** — link long-tail TO pillars, not vice versa
4. **Compare pages own competitor names** — editorial mentions link to `/compare/{competitor}-alternative`
5. **Research pages own statistics** — editorial cites `/research/*`, never duplicates tables
6. **No medical YMYL** — cluster removed (410)

## Internal Linking Hierarchy

```
Research (cite) → Guide (how-to) → Pillar (authority) → Tool (convert)
                     ↓
              Vertical landing (persona)
                     ↓
              Compare (commercial)
```

Every article must link to:
- 1× tool page (BOFU)
- 1× cluster hub
- 2× related guides in same cluster
- 1× research or compare page where relevant

## Content Types by Funnel

| Stage | Intent | Content type | Example |
|-------|--------|--------------|---------|
| TOFU | Informational | Glossary, beginner, mistakes | "what is OCR" |
| MOFU | Problem-solving | How-to, checklist, workflow | "pdf too large for email" |
| BOFU | Transactional | Tool guide, comparison | "compress pdf for gmail" |
| Retention | Advanced | Technical deep dives | "ghostscript parameters" |

## Existing vs Planned

| Status | Count |
|--------|-------|
| Published guides | 47 |
| Published blogs | 19 |
| Programmatic URLs (intent-filtered) | ~15,000 |
| **Planned editorial (roadmap)** | **1,239** |
| SEO pillars (L1) | 21 |

## Priority Tiers

- **P0 (Weeks 1–8):** Compress, PDF-to-text, OCR, invoice India, top comparisons — high traffic + tools exist
- **P1 (Weeks 9–16):** Merge/split, secure PDF, verticals, compliance
- **P2 (Weeks 17+):** Glossary, regional, profession invoice templates, best-of listicles

See `content-priority-batch-1.csv` for first 50 P0 articles.
