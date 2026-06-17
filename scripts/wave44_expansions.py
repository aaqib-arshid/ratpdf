"""Wave 44 — CREATE batch 8 (17 guides, score 78–79). IRD NZ, PDF/A, Ghostscript, contracts Europe."""

W44_SLUGS = [
    "compress-pdf-ird-nz",
    "pdf-a-1b-compliance-checklist",
    "ghostscript-compress-pdf-settings",
    "encrypt-pdf-aes-256",
    "screen-reader-pdf",
    "commercial-print-pdf-handoff",
    "archive-pdf-long-term-storage",
    "pdf24-vs-ilovepdf",
    "how-pdf-compression-works",
    "pdf-error-0x80070057",
    "contract-pdf-workflow-argentina",
    "contract-pdf-workflow-poland",
    "contract-pdf-workflow-sweden",
    "contract-pdf-workflow-norway",
    "contract-pdf-workflow-denmark",
    "contract-pdf-workflow-finland",
    "contract-pdf-workflow-portugal",
]

GOVT_CREATE_SLUGS = {"compress-pdf-ird-nz"}

ARCHIVAL_CREATE_SLUGS = {"pdf-a-1b-compliance-checklist", "archive-pdf-long-term-storage"}

COMPRESS_CREATE_SLUGS = {"ghostscript-compress-pdf-settings", "how-pdf-compression-works"}

SECURITY_CREATE_SLUGS = {"encrypt-pdf-aes-256"}

ACCESSIBILITY_CREATE_SLUGS = {"screen-reader-pdf"}

PRINT_CREATE_SLUGS = {"commercial-print-pdf-handoff"}

COMPARE_CREATE_SLUGS = {"pdf24-vs-ilovepdf"}

TROUBLESHOOT_CREATE_SLUGS = {"pdf-error-0x80070057"}

CONTRACT_CREATE_SLUGS = {
    "contract-pdf-workflow-argentina",
    "contract-pdf-workflow-poland",
    "contract-pdf-workflow-sweden",
    "contract-pdf-workflow-norway",
    "contract-pdf-workflow-denmark",
    "contract-pdf-workflow-finland",
    "contract-pdf-workflow-portugal",
}

W44_CONTRACT_META = {
    "argentina": ("Argentina", "Contrato de prestación de servicios", "Agency merges MSA and anexo PDFs before Argentina client signature"),
    "poland": ("Poland", "Umowa B2B", "SaaS vendor merges umowa ramowa and GDPR DPA exhibit for Poland enterprise deal"),
    "sweden": ("Sweden", "Avtal B2B", "Consultant merges huvudavtal and bilaga PDFs — watermark DRAFT until sign"),
    "norway": ("Norway", "Kontrakt B2B", "Supplier merges framework agreement and SLA PDF for Norway public sector tender"),
    "denmark": ("Denmark", "Kontrakt &amp; bilag", "Startup merges hovedkontrakt and databehandleraftale before Danish client review"),
    "finland": ("Finland", "Sopimus B2B", "Exporter merges master sopimus and English translation PDF for Finland distributor"),
    "portugal": ("Portugal", "Contrato B2B", "MSME merges contrato-quadro and anexos PDF for Portugal services agreement"),
}

W44_DATA = {
    "compress-pdf-ird-nz": {
        "title": "Compress PDF for IRD NZ — myIR Upload Size (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/invoice-generator-new-zealand",
        "pillar_label": "invoice generator New Zealand",
        "related": "/guides/government-portal-pdf-compress",
        "prog": "/compress-pdf-for-government-forms",
        "example": "NZ taxpayer compresses deduction receipt scan from 5 MB to 2 MB for myIR document upload",
    },
    "pdf-a-1b-compliance-checklist": {
        "title": "PDF/A-1b Compliance Checklist — Archive Validation (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/convert-to-pdf-a",
        "pillar_label": "convert to PDF/A",
        "related": "/guides/glossary-pdf-a",
        "prog": "/pdf/compress",
        "example": "Records manager runs PDF/A-1b checklist before county clerk ingests scanned deed PDF",
    },
    "ghostscript-compress-pdf-settings": {
        "title": "Ghostscript Compress PDF Settings — Profiles Explained (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/ghostscript-pdf-compression",
        "pillar_label": "Ghostscript compression",
        "related": "/guides/glossary-ghostscript",
        "prog": "/compress-pdf",
        "example": "IT admin maps RatPDF Less preset to Ghostscript /ebook vs /printer profile expectations",
    },
    "encrypt-pdf-aes-256": {
        "title": "Encrypt PDF AES-256 — Password Protection (2026)",
        "tool": "/pdf/password",
        "label": "Protect PDF",
        "pillar": "/guides/pdf-password-best-practices",
        "pillar_label": "password best practices",
        "related": "/guides/secure-pdf-before-email",
        "prog": "/pdf/password",
        "example": "Legal encrypts M&A diligence PDF AES-256 — owner password for firm — user password for buyer",
    },
    "screen-reader-pdf": {
        "title": "Screen Reader PDF — Tagged Structure &amp; QA (2026)",
        "tool": "/pdf/ocrpdf",
        "label": "OCR PDF",
        "pillar": "/guides/pdf-ua-accessibility",
        "pillar_label": "PDF/UA accessibility",
        "related": "/guides/tagged-pdf-checklist",
        "prog": "/pdf/ocrpdf",
        "example": "Accessibility tester verifies H1–H3 tags and table headers with NVDA on policy PDF",
    },
    "commercial-print-pdf-handoff": {
        "title": "Commercial Print PDF Handoff — Prepress Pack (2026)",
        "tool": "/pdf/flattenpdf",
        "label": "Flatten PDF",
        "pillar": "/guides/commercial-print-pdf-checklist",
        "pillar_label": "commercial print checklist",
        "related": "/guides/pdf-x-print-standard",
        "prog": "/pdf/flattenpdf",
        "example": "Designer exports PDF/X-1a brochure — flatten fonts — 3 mm bleed — sends to commercial printer",
    },
    "archive-pdf-long-term-storage": {
        "title": "Archive PDF Long-Term Storage — Tiers &amp; Migration (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/long-term-pdf-storage",
        "pillar_label": "long-term PDF storage",
        "related": "/guides/pdf-a-archival",
        "prog": "/pdf/compress",
        "example": "Archivist stores PDF/A access copy in warm tier — keeps master in records system — migration plan 2030",
    },
    "pdf24-vs-ilovepdf": {
        "title": "PDF24 vs iLovePDF — Online Tools Compared (2026)",
        "tool": "/compare",
        "label": "compare hub",
        "pillar": "/compare/ilovepdf-alternative",
        "pillar_label": "iLovePDF alternative",
        "related": "/compare/pdf24-alternative",
        "prog": "/compare",
        "example": "SMB compares PDF24 Creator desktop vs iLovePDF browser for weekly merge/compress volume",
    },
    "how-pdf-compression-works": {
        "title": "How PDF Compression Works — Images, Fonts &amp; Linearization (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/why-is-pdf-file-so-large",
        "pillar_label": "why PDF is large",
        "related": "/guides/ghostscript-pdf-compression",
        "prog": "/compress-pdf",
        "example": "User learns JPEG re-encode shrinks scan 40% while digital Word export shrinks 15% only",
    },
    "pdf-error-0x80070057": {
        "title": "PDF Error 0x80070057 — Windows Parameter Fix (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/pdf-troubleshooting",
        "pillar_label": "PDF troubleshooting",
        "related": "/guides/pdf-won-t-open",
        "prog": "/pdf/compress",
        "example": "Windows Print to PDF fails 0x80070057 — invalid page size — reset to A4 — retry export",
    },
}

for country, (name, contract_type, example) in W44_CONTRACT_META.items():
    slug = f"contract-pdf-workflow-{country}"
    W44_DATA[slug] = {
        "title": f"Contract PDF Workflow {name} — B2B Pack (2026)",
        "tool": "/pdf/merge",
        "label": "Merge PDF",
        "pillar": "/guides/contract-pdf-workflow-germany",
        "pillar_label": "contract workflow Germany (reference)",
        "related": "/guides/contract-pdf-redline-workflow",
        "prog": "/pdf/merge",
        "example": example,
        "country": name,
        "contract_type": contract_type,
    }


def _d(slug: str, html: str) -> str:
    p = W44_DATA[slug].get("prog", "")
    tail = f'<p>Tool: <a href="{p}">{p}</a></p>' if p else ""
    return html + tail


def _contract_deep(slug: str) -> str:
    d = W44_DATA[slug]
    return _d(
        slug,
        f"""
            <h2>{d['country']} contract PDF workflow</h2>
            <p>Typical pack: {d['contract_type']} — merge master then numbered exhibits.</p>
            <ol>
            <li><a href="/pdf/merge">Merge</a> in signature order — master first</li>
            <li><a href="/pdf/watermark">Watermark</a> DRAFT on negotiation copies</li>
            <li>Flatten after sign — <a href="/pdf/flattenpdf">Flatten PDF</a></li>
            </ol>
            <p><a href="/guides/contract-pdf-redline-workflow">Redline workflow</a> · GDPR DPA exhibit if EU data processing.</p>
            """,
    )


W44_DEEP = {
    "compress-pdf-ird-nz": _d("compress-pdf-ird-nz", """
            <h2>IRD / myIR uploads</h2>
            <p>Tax supporting documents — read myIR in-app size message — separate from Immigration NZ ImmiAccount.</p>
            <p><a href="/guides/bank-statement-pdf-workflow-new-zealand">NZ bank workflow</a> · <a href="/guides/compress-pdf-home-affairs-australia">Australia contrast</a>.</p>
            """),
    "pdf-a-1b-compliance-checklist": _d("pdf-a-1b-compliance-checklist", """
            <h2>PDF/A-1b checks</h2>
            <ul>
            <li>Fonts embedded</li>
            <li>No audio/video attachments</li>
            <li>Transparency flattened if required</li>
            <li>Validate with veraPDF or preflight tool</li>
            </ul>
            <p><a href="/guides/convert-to-pdf-a-online">PDF/A online</a> · <a href="/guides/pdf-a-archival">archival pillar</a>.</p>
            """),
    "ghostscript-compress-pdf-settings": _d("ghostscript-compress-pdf-settings", """
            <h2>Common Ghostscript profiles</h2>
            <ul>
            <li>/screen — lowest quality, smallest</li>
            <li>/ebook — balanced — maps to Recommended</li>
            <li>/printer — higher JPEG quality — maps to Less</li>
            </ul>
            <p><a href="/guides/ghostscript-pdf-compression">Ghostscript explained</a>.</p>
            """),
    "encrypt-pdf-aes-256": _d("encrypt-pdf-aes-256", """
            <h2>AES-256 in practice</h2>
            <p>Modern PDF encryption uses AES-256 — separate owner vs user passwords — never email password in body.</p>
            <p><a href="/guides/pdf-password-not-working">Password troubleshooting</a>.</p>
            """),
    "screen-reader-pdf": _d("screen-reader-pdf", """
            <h2>Screen reader QA</h2>
            <ol>
            <li>Document language set</li>
            <li>Heading tags not fake bold only</li>
            <li>Table TH cells for column headers</li>
            <li>Test with NVDA or VoiceOver</li>
            </ol>
            <p><a href="/guides/remediate-pdf-accessibility">Remediation guide</a>.</p>
            """),
    "commercial-print-pdf-handoff": _d("commercial-print-pdf-handoff", """
            <h2>Handoff pack</h2>
            <ul>
            <li>PDF/X export from InDesign when possible</li>
            <li>3 mm bleed on full-bleed jobs</li>
            <li>Outline fonts or embed all</li>
            <li>CMYK separations note for printer</li>
            </ul>
            <p><a href="/guides/commercial-print-pdf-checklist">Print checklist</a>.</p>
            """),
    "archive-pdf-long-term-storage": _d("archive-pdf-long-term-storage", """
            <h2>Storage tiers</h2>
            <p>Hot access copies — warm compliance archive — cold tape — encrypt at rest — migration when PDF/A subset obsolete.</p>
            <p><a href="/guides/document-retention-pdf">Retention</a> · <a href="/guides/pdf-document-retention-periods">retention periods</a>.</p>
            """),
    "pdf24-vs-ilovepdf": _d("pdf24-vs-ilovepdf", """
            <h2>Quick comparison</h2>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>Factor</th><th>PDF24</th><th>iLovePDF</th></tr></thead>
            <tbody>
            <tr><td>Desktop option</td><td>PDF24 Creator</td><td>Browser-first</td></tr>
            <tr><td>Free tier</td><td>Generous local tools</td><td>Daily browser caps</td></tr>
            <tr><td>Merge/compress</td><td>Both strong</td><td>Both strong</td></tr>
            </tbody></table></div>
            <p><a href="/compare/pdf24-alternative">PDF24 alternative</a> · <a href="/compare/ilovepdf-alternative">iLovePDF alternative</a>.</p>
            """),
    "how-pdf-compression-works": _d("how-pdf-compression-works", """
            <h2>What actually shrinks</h2>
            <ul>
            <li>JPEG re-encode on images — biggest win on scans</li>
            <li>Font subsetting on digital PDFs</li>
            <li>Remove unused objects — modest gain</li>
            <li>Linearization — can add bytes on small files</li>
            </ul>
            <p><a href="/guides/compress-scanned-vs-digital-pdf">Scanned vs digital</a>.</p>
            """),
    "pdf-error-0x80070057": _d("pdf-error-0x80070057", """
            <h2>0x80070057 on Windows</h2>
            <p>Invalid parameter — often custom paper size or corrupted print driver — reset to A4/Letter — update Microsoft Print to PDF.</p>
            <p><a href="/guides/print-to-pdf-windows">Print to PDF Windows</a>.</p>
            """),
}

for country in W44_CONTRACT_META:
    W44_DEEP[f"contract-pdf-workflow-{country}"] = _contract_deep(f"contract-pdf-workflow-{country}")

W44_CREATE_CLUSTER = """
            <h2>CREATE batch 8</h2>
            <ul>
            <li><a href="/guides/compress-pdf-ird-nz">IRD NZ compress</a> · <a href="/guides/pdf-a-1b-compliance-checklist">PDF/A-1b checklist</a></li>
            <li><a href="/guides/ghostscript-compress-pdf-settings">Ghostscript settings</a> · <a href="/guides/how-pdf-compression-works">How compression works</a></li>
            <li><a href="/guides/encrypt-pdf-aes-256">AES-256 encrypt</a> · <a href="/guides/screen-reader-pdf">Screen reader PDF</a></li>
            <li><a href="/guides/commercial-print-pdf-handoff">Print handoff</a> · <a href="/guides/archive-pdf-long-term-storage">Archive storage</a></li>
            <li><a href="/guides/pdf24-vs-ilovepdf">PDF24 vs iLovePDF</a> · <a href="/guides/pdf-error-0x80070057">Error 0x80070057</a></li>
            <li>Contract: <a href="/guides/contract-pdf-workflow-argentina">Argentina</a> · <a href="/guides/contract-pdf-workflow-poland">Poland</a> · <a href="/guides/contract-pdf-workflow-sweden">Sweden</a></li>
            <li><a href="/guides/contract-pdf-workflow-norway">Norway</a> · <a href="/guides/contract-pdf-workflow-denmark">Denmark</a> · <a href="/guides/contract-pdf-workflow-finland">Finland</a> · <a href="/guides/contract-pdf-workflow-portugal">Portugal</a></li>
            </ul>
            <p>Prior: <a href="/guides/bank-statement-pdf-workflow-turkey">batch 7 bank</a> · <a href="/guides/visa-application-pdf-workflow-argentina">batch 4 visa</a></p>
            """

W44_CONTRACT_CLUSTER = """
            <h2>Wave 44 contract regional hubs</h2>
            <p>Europe: <a href="/guides/contract-pdf-workflow-poland">Poland</a> · <a href="/guides/contract-pdf-workflow-sweden">Sweden</a> · <a href="/guides/contract-pdf-workflow-norway">Norway</a> · <a href="/guides/contract-pdf-workflow-denmark">Denmark</a> · <a href="/guides/contract-pdf-workflow-finland">Finland</a> · <a href="/guides/contract-pdf-workflow-portugal">Portugal</a></p>
            <p>Americas: <a href="/guides/contract-pdf-workflow-argentina">Argentina</a> · existing: <a href="/guides/contract-pdf-workflow-mexico">Mexico</a> · <a href="/guides/contract-pdf-workflow-germany">Germany</a></p>
            """

W44_COMPRESS_TOPUP = """
            <h2>CREATE batch 8 checklist</h2>
            <ol>
            <li>Government portal: read FAQ before compress</li>
            <li>PDF/A: validate when archive compliance required</li>
            <li>Contract merge: master then numbered exhibits</li>
            <li>Compare tools on limits — not marketing badges alone</li>
            </ol>
            """

W44_CLOSING = """
            <h2>Related guides</h2>
            <p>Wave 44 adds IRD NZ compress, PDF/A-1b checklist, Ghostscript settings, AES encryption, screen reader QA, print handoff, archive storage, PDF24 vs iLovePDF, compression explainer, Windows error fix, and seven contract regional workflows — CREATE batch 8 of 450.</p>
            <p>Hub: <a href="/guides/pdf-tools">PDF tools</a> · CREATE remaining: 314</p>
            """
