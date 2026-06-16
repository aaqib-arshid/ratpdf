# PDF Cannibalization Report v2

> Generated 2026-06-16. Rule: **upgrade before create**.

## Summary

- Roadmap merged (resolved duplicates): **378**
- CREATE rows with existing slug match: **0** (review before publish)

## Risk categories

### 1. Programmatic vs editorial (MEDIUM — by design)
Compress/pdf-to-word/edit-pdf programmatic pages own head-term variants.
Editorial pillars own 1500+ word workflows. Cross-link programmatic → pillar → tool.

### 2. Glossary vs pillar (HIGH — 144 pages)
Upgrade glossary as TOFU definitions linking to MOFU pillars within 200 words.
Title pattern: "What is [term]?" — no workflow duplication.

### 3. Regional matrix (HIGH — 152 pages)
Each country page must have 60%+ unique portal-specific content.
Generic compress steps → shared template block only.

### 4. Wave-upgraded vs generated audit (TECHNICAL)
seo-audit-results.json counts wave slugs as `generated` layer.
Runtime bodies are authority-grade; audit script needs wave file inclusion.

### 5. Compare slug drift
Internal links may use `/compare/adobe-alternative` vs live `adobe-acrobat-alternative`.
Add 301 alias or fix links site-wide.

### 6. Best-of vs compare hub
300 deferred Best-of rows mostly invoice-themed (excluded).
PDF best-of must link to `/compare/*`, not duplicate comparison tables.

## Per-article checklist

```
1. grep slug in ContentLibrary + GuideBodies + roadmap CSV
2. grep PrimaryKeyword across roadmap
3. Check programmatic generator for same intent
4. Match found → UPGRADE or MAINTAIN
5. Unique intent → CREATE
6. Weaker page links to stronger canonical
```

## Priority fixes

| Priority | Issue | Action |
|----------|-------|--------|
| P0 | ~277 thin pages outside waves | Upgrade waves 16–18 |
| P0 | 144 glossary vs pillars | Wave 16 glossary batch |
| P1 | 118 thin regional templates | Wave 17 regional batch 3+ |
| P1 | PDFgear/Nitro compare missing | Add compare pages |
| P2 | Programmatic thin content indexed | Enforce noindex on tool landings |
