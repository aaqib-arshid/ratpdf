# PDF Cannibalization Report

> Goal: one primary URL per unique search intent. Upgrade before create.

---

## Risk categories

### 1. Programmatic vs editorial (MEDIUM risk — by design)

| Intent | Programmatic URL | Editorial URL | Resolution |
|--------|------------------|---------------|------------|
| compress pdf to 100kb | `/compress-pdf-to-100kb` | `/guides/compress-pdf-guide` | Programmatic = tool landing; editorial = workflow guide. Link programmatic → guide. |
| pdf to word online | `/pdf-to-word/{slug}` | `/guides/pdf-to-word` | Pillar owns "pdf to word"; programmatic owns document-type variants. |
| merge pdf online | `/merge-pdf/{slug}` | `/guides/merge-pdf` | Same pattern. |

**Rule:** Never duplicate 1500+ word body on programmatic page. Programmatic max ~800 words + CTA.

---

### 2. Glossary vs pillar (HIGH risk — 144 pages)

| Example conflict | URLs | Action |
|------------------|------|--------|
| "compress pdf online" | `glossary-compress-pdf-online` vs `compress-pdf-guide` | **Upgrade glossary** as definition TOFU; pillar remains MOFU hub. Glossary must link up, not compete. |
| "pdf to text extractor" | `glossary-pdf-to-text-extractor` vs `pdf-txt-guide` | Consolidate keyword targeting: glossary = "what is", pillar = "how to". |

**Bulk issue:** 144 glossary pages are ultra-thin (median ~62 words). They risk cannibalizing pillars if titles overlap.

**Fix:** Batch-upgrade glossary with canonical intent split:
- Title pattern: "What is [term]? Definition & when to use RatPDF [tool]"
- First H2: link to pillar within 200 words
- No tool workflow duplication

---

### 3. Regional workflow matrix (HIGH risk — 152 pages)

Pattern: `bank-statement-pdf-workflow-{country}`

Overlaps with:
- `compress-pdf-for-visa-application`
- `convert-bank-statement-pdf-to-word`
- Country invoice guides (out of scope)

**Action:** Regional pages must target **country-specific procedural intent** (portal names, MB limits, language). If content is generic "convert bank PDF", merge into global spoke.

---

### 4. Best-of listicles (MEDIUM risk — 300 deferred)

Roadmap has 300 `Best-of` rows; only **2 live**. Many were invoice-themed (excluded). Remaining should target:
- "best pdf compressor for lawyers"
- "best free pdf merger 2026"

**Cannibalization with:** `/compare`, `/guides/choose-pdf-tool`, `/guides/best-free-pdf-tools-2026`

**Rule:** One best-of per audience segment. Link all to `/compare/{competitor}-alternative`, not duplicate comparison tables.

---

### 5. Without-Adobe variants (LOW risk — intentional)

Pattern: `{tool}-without-adobe` vs core pillar

Examples: `images-to-pdf-without-adobe` vs `images-to-pdf`

**Valid:** Different SERP intent (commercial alternative). Cross-link both ways; shared tool CTA.

---

### 6. Compress portal vs government guides (MEDIUM risk)

Multiple URLs target Indian government uploads:
- `compress-pdf-incometax`
- `compress-pdf-gst-portal`
- `compress-pdf-for-government-forms`
- `compress-pdf-digilocker`

**Valid** if each page covers **distinct portal mechanics**. Invalid if body repeats same 5-step compress instructions.

**Action:** Shared compress workflow block (template) + unique portal section (60%+ unique words).

---

### 7. Compare page slug drift (TECHNICAL — broken links)

Wave bodies link `/compare/adobe-alternative` but catalog slug is `adobe-acrobat-alternative`.

**Action:** 301 alias or fix internal links site-wide.

---

### 8. Merged roadmap entries (378 — resolved)

`content-roadmap.csv` Status=Merged documents past dedup decisions (e.g. ratpdf-vs-* → /compare/*).

**Before new URL:** grep roadmap for Merged status and merge reason.

---

## Cannibalization check workflow (per article)

```
1. grep slug in ContentLibrary + GuideBodies + roadmap CSV
2. grep PrimaryKeyword across roadmap
3. Check programmatic generator for same intent
4. If match found → UPGRADE existing
5. If intent unique → CREATE with new slug
6. Add canonical internal link from weaker page to stronger
```

---

## Priority cannibalization fixes

| Priority | Issue | Fix |
|----------|-------|-----|
| P0 | 435 thin pages competing with pillars | Upgrade waves 7–17 |
| P0 | Glossary vs pillar keyword overlap | Retitle + restructure glossary batch |
| P1 | Regional generic duplicates | Audit 152 slugs; merge or differentiate |
| P1 | Compare URL drift | Fix internal links |
| P2 | Best-of vs compare hub | Defer best-of until compare guides upgraded |
