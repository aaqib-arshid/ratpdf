"""Wave 45 — CREATE batch 9 (17 guides, score 78). Contract regional Asia/MENA/Europe + forms/print/PDF/A."""

W45_SLUGS = [
    "contract-pdf-workflow-greece",
    "contract-pdf-workflow-turkey",
    "contract-pdf-workflow-egypt",
    "contract-pdf-workflow-morocco",
    "contract-pdf-workflow-nigeria",
    "contract-pdf-workflow-kenya",
    "contract-pdf-workflow-thailand",
    "contract-pdf-workflow-vietnam",
    "contract-pdf-workflow-indonesia",
    "contract-pdf-workflow-malaysia",
    "contract-pdf-workflow-philippines",
    "contract-pdf-workflow-china",
    "contract-pdf-workflow-taiwan",
    "contract-pdf-workflow-hong-kong",
    "pdf-form-field-validation",
    "pdf-prints-too-light",
    "pdf-migration-documents-to-pdfa",
]

CONTRACT_CREATE_SLUGS = {
    "contract-pdf-workflow-greece",
    "contract-pdf-workflow-turkey",
    "contract-pdf-workflow-egypt",
    "contract-pdf-workflow-morocco",
    "contract-pdf-workflow-nigeria",
    "contract-pdf-workflow-kenya",
    "contract-pdf-workflow-thailand",
    "contract-pdf-workflow-vietnam",
    "contract-pdf-workflow-indonesia",
    "contract-pdf-workflow-malaysia",
    "contract-pdf-workflow-philippines",
    "contract-pdf-workflow-china",
    "contract-pdf-workflow-taiwan",
    "contract-pdf-workflow-hong-kong",
}

FORM_CREATE_SLUGS = {"pdf-form-field-validation"}

PRINT_CREATE_SLUGS = {"pdf-prints-too-light"}

ARCHIVAL_CREATE_SLUGS = {"pdf-migration-documents-to-pdfa"}

W45_CONTRACT_META = {
    "greece": ("Greece", "Symvasi B2B", "Consultant merges master symvasi and parartima PDFs for Greece client sign-off"),
    "turkey": ("Turkey", "Sözleşme B2B", "Vendor merges çerçeve sözleşme and ek PDFs before Turkey enterprise signature"),
    "egypt": ("Egypt", "Contract B2B", "Agency merges English contract and Arabic translation PDF for Egypt client pack"),
    "morocco": ("Morocco", "Contrat B2B", "MSME merges contrat-cadre and annexes PDF for Morocco services deal"),
    "nigeria": ("Nigeria", "Contract B2B", "Startup merges MSA and data processing addendum for Nigeria fintech client"),
    "kenya": ("Kenya", "Contract B2B", "SaaS merges master agreement and SLA PDF for Kenya enterprise onboarding"),
    "thailand": ("Thailand", "Contract B2B", "Exporter merges head contract and specification PDF for Thailand distributor"),
    "vietnam": ("Vietnam", "Hợp đồng B2B", "Factory merges hợp đồng khung and phụ lục PDF for Vietnam buyer review"),
    "indonesia": ("Indonesia", "Kontrak B2B", "Agency merges perjanjian induk and lampiran PDF for Indonesia client"),
    "malaysia": ("Malaysia", "Contract B2B", "Consultant merges master contract and SOW PDF for Malaysia SME deal"),
    "philippines": ("Philippines", "Contract B2B", "BPO merges MSA and DPA PDF before Philippines client DocuSign"),
    "china": ("China", "合同 B2B", "JV merges master 合同 and bilingual exhibit PDF for China partner review"),
    "taiwan": ("Taiwan", "合約 B2B", "OEM merges master 合約 and specification PDF for Taiwan manufacturer deal"),
    "hong-kong": ("Hong Kong", "Contract B2B", "Fund merges English agreement and schedule PDF for Hong Kong LP subscription"),
}

W45_DATA = {
    "pdf-form-field-validation": {
        "title": "PDF Form Field Validation — Required &amp; Format Rules (2026)",
        "tool": "/pdf/editpdf",
        "label": "Edit PDF",
        "pillar": "/guides/create-fillable-pdf",
        "pillar_label": "create fillable PDF",
        "related": "/guides/glossary-form-field",
        "prog": "/pdf/editpdf",
        "example": "Ops sets required email field and date format on onboarding PDF — test fill rejects blank submit",
    },
    "pdf-prints-too-light": {
        "title": "PDF Prints Too Light — Toner &amp; Layer Fixes (2026)",
        "tool": "/pdf/flattenpdf",
        "label": "Flatten PDF",
        "pillar": "/guides/pdf-colors-wrong-when-printing",
        "pillar_label": "PDF colors wrong printing",
        "related": "/guides/pdf-printing-blank-pages",
        "prog": "/pdf/flattenpdf",
        "example": "Office MFP prints contract PDF faded — flatten transparency — print as image — toner density normal",
    },
    "pdf-migration-documents-to-pdfa": {
        "title": "Migrate Documents to PDF/A — Workflow (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/convert-to-pdf-a",
        "pillar_label": "convert to PDF/A",
        "related": "/guides/archive-pdf-long-term-storage",
        "prog": "/pdf/compress",
        "example": "Records team batches 10k legacy PDFs — export PDF/A-2b access copies — veraPDF spot-check sample",
    },
}

for country, (name, contract_type, example) in W45_CONTRACT_META.items():
    slug = f"contract-pdf-workflow-{country}"
    W45_DATA[slug] = {
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
    p = W45_DATA[slug].get("prog", "")
    tail = f'<p>Tool: <a href="{p}">{p}</a></p>' if p else ""
    return html + tail


def _contract_deep(slug: str) -> str:
    d = W45_DATA[slug]
    return _d(
        slug,
        f"""
            <h2>{d['country']} contract PDF workflow</h2>
            <p>Typical pack: {d['contract_type']} — merge master then numbered exhibits.</p>
            <ol>
            <li><a href="/pdf/merge">Merge</a> in signature order</li>
            <li><a href="/pdf/watermark">Watermark</a> DRAFT on negotiation copies</li>
            <li><a href="/pdf/flattenpdf">Flatten</a> after sign</li>
            </ol>
            <p><a href="/guides/contract-pdf-redline-workflow">Redline workflow</a> · local counsel review before external send.</p>
            """,
    )


W45_DEEP = {
    "pdf-form-field-validation": _d("pdf-form-field-validation", """
            <h2>Validation rules</h2>
            <ul>
            <li>Required fields block submit when empty</li>
            <li>Email and phone format masks</li>
            <li>Date fields — ISO or locale format</li>
            <li>Dropdown allowed values only</li>
            </ul>
            <p><a href="/guides/pdf-form-not-saving">Form not saving</a> · <a href="/guides/glossary-xfa-forms">XFA limits</a>.</p>
            """),
    "pdf-prints-too-light": _d("pdf-prints-too-light", """
            <h2>Light print fixes</h2>
            <ul>
            <li>Flatten transparency layers</li>
            <li>Print as image in driver advanced settings</li>
            <li>Increase toner density on MFP</li>
            <li>Check eco-toner-save mode off</li>
            </ul>
            <p><a href="/guides/print-pdf-black-and-white">Print black and white</a>.</p>
            """),
    "pdf-migration-documents-to-pdfa": _d("pdf-migration-documents-to-pdfa", """
            <h2>Migration pipeline</h2>
            <ol>
            <li>Inventory legacy PDF versions</li>
            <li>Batch convert access copies to PDF/A-2b</li>
            <li>veraPDF or preflight sample validation</li>
            <li>Keep masters in records system — migrate on schedule</li>
            </ol>
            <p><a href="/guides/pdf-a-1b-compliance-checklist">PDF/A-1b checklist</a> · <a href="/guides/long-term-pdf-storage">long-term storage</a>.</p>
            """),
}

for country in W45_CONTRACT_META:
    W45_DEEP[f"contract-pdf-workflow-{country}"] = _contract_deep(f"contract-pdf-workflow-{country}")

W45_CREATE_CLUSTER = """
            <h2>CREATE batch 9</h2>
            <ul>
            <li>Contract Europe/MENA: <a href="/guides/contract-pdf-workflow-greece">Greece</a> · <a href="/guides/contract-pdf-workflow-turkey">Turkey</a> · <a href="/guides/contract-pdf-workflow-egypt">Egypt</a> · <a href="/guides/contract-pdf-workflow-morocco">Morocco</a></li>
            <li>Africa: <a href="/guides/contract-pdf-workflow-nigeria">Nigeria</a> · <a href="/guides/contract-pdf-workflow-kenya">Kenya</a></li>
            <li>ASEAN: <a href="/guides/contract-pdf-workflow-thailand">Thailand</a> · <a href="/guides/contract-pdf-workflow-vietnam">Vietnam</a> · <a href="/guides/contract-pdf-workflow-indonesia">Indonesia</a> · <a href="/guides/contract-pdf-workflow-malaysia">Malaysia</a> · <a href="/guides/contract-pdf-workflow-philippines">Philippines</a></li>
            <li>Greater China: <a href="/guides/contract-pdf-workflow-china">China</a> · <a href="/guides/contract-pdf-workflow-taiwan">Taiwan</a> · <a href="/guides/contract-pdf-workflow-hong-kong">Hong Kong</a></li>
            <li><a href="/guides/pdf-form-field-validation">Form validation</a> · <a href="/guides/pdf-prints-too-light">Prints too light</a> · <a href="/guides/pdf-migration-documents-to-pdfa">Migrate to PDF/A</a></li>
            </ul>
            <p>Prior contract batch: <a href="/guides/contract-pdf-workflow-argentina">batch 8 Europe/Americas</a></p>
            """

W45_CONTRACT_CLUSTER = """
            <h2>Wave 45 contract hubs (Asia/Africa/MENA)</h2>
            <p>ASEAN: <a href="/guides/contract-pdf-workflow-thailand">Thailand</a> · <a href="/guides/contract-pdf-workflow-vietnam">Vietnam</a> · <a href="/guides/contract-pdf-workflow-indonesia">Indonesia</a> · <a href="/guides/contract-pdf-workflow-malaysia">Malaysia</a> · <a href="/guides/contract-pdf-workflow-philippines">Philippines</a></p>
            <p>Greater China: <a href="/guides/contract-pdf-workflow-china">China</a> · <a href="/guides/contract-pdf-workflow-taiwan">Taiwan</a> · <a href="/guides/contract-pdf-workflow-hong-kong">Hong Kong</a></p>
            <p>MENA/Africa/Europe: <a href="/guides/contract-pdf-workflow-greece">Greece</a> · <a href="/guides/contract-pdf-workflow-turkey">Turkey</a> · <a href="/guides/contract-pdf-workflow-egypt">Egypt</a> · <a href="/guides/contract-pdf-workflow-morocco">Morocco</a> · <a href="/guides/contract-pdf-workflow-nigeria">Nigeria</a> · <a href="/guides/contract-pdf-workflow-kenya">Kenya</a></p>
            """

W45_COMPRESS_TOPUP = """
            <h2>CREATE batch 9 checklist</h2>
            <ol>
            <li>Contract merge: master then numbered exhibits</li>
            <li>Watermark DRAFT until countersignature</li>
            <li>Form validation QA before publish</li>
            <li>PDF/A migration: validate sample with veraPDF</li>
            </ol>
            """

W45_CLOSING = """
            <h2>Related guides</h2>
            <p>Wave 45 completes Asia-Pacific and MENA contract regional spokes plus form validation, light-print troubleshooting, and PDF/A migration workflow — CREATE batch 9 of 450.</p>
            <p>Hub: <a href="/guides/pdf-regional-workflows-hub">regional workflows</a> · CREATE remaining: 297</p>
            """
