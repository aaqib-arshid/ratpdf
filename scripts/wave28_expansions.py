"""Wave 28 — Regional contract batch 6 + tax document workflow batch 1."""

W28_SLUGS = [
    "contract-pdf-workflow-france",
    "contract-pdf-workflow-india",
    "contract-pdf-workflow-ireland",
    "contract-pdf-workflow-japan",
    "contract-pdf-workflow-netherlands",
    "contract-pdf-workflow-singapore",
    "contract-pdf-workflow-spain",
    "contract-pdf-workflow-uae",
    "tax-document-pdf-workflow-australia",
    "tax-document-pdf-workflow-brazil",
    "tax-document-pdf-workflow-canada",
    "tax-document-pdf-workflow-france",
    "tax-document-pdf-workflow-germany",
    "tax-document-pdf-workflow-ireland",
    "tax-document-pdf-workflow-italy",
    "tax-document-pdf-workflow-japan",
    "tax-document-pdf-workflow-mexico",
]

CONTRACT_SLUGS = {
    "contract-pdf-workflow-france",
    "contract-pdf-workflow-india",
    "contract-pdf-workflow-ireland",
    "contract-pdf-workflow-japan",
    "contract-pdf-workflow-netherlands",
    "contract-pdf-workflow-singapore",
    "contract-pdf-workflow-spain",
    "contract-pdf-workflow-uae",
}

TAX_SLUGS = {
    "tax-document-pdf-workflow-australia",
    "tax-document-pdf-workflow-brazil",
    "tax-document-pdf-workflow-canada",
    "tax-document-pdf-workflow-france",
    "tax-document-pdf-workflow-germany",
    "tax-document-pdf-workflow-ireland",
    "tax-document-pdf-workflow-italy",
    "tax-document-pdf-workflow-japan",
    "tax-document-pdf-workflow-mexico",
}

W28_CONTRACT_META = {
    "france": {
        "title": "Contract PDF Workflow France — B2B Contrat &amp; RGPD Pack (2026)",
        "example": "Paris SaaS vendor merges contrat cadre and RGPD annexe PDFs — watermarks DRAFT before client legal review",
        "pillar": "/guides/contract-pdf-workflow-germany",
        "pillar_label": "contract PDF workflow (Germany reference)",
        "related": "/guides/visa-application-pdf-workflow-france",
        "note": "Contrat cadre + annexes RGPD — merge order: master then numbered allegati — eIDAS context for qualified sign",
    },
    "india": {
        "title": "Contract PDF Workflow India — MSA, SOW &amp; GST Annex (2026)",
        "example": "Bangalore IT firm merges MSA, SOW, and GST registration annex PDF before enterprise client sign-off",
        "pillar": "/guides/contract-pdf-workflow-usa",
        "pillar_label": "contract PDF workflow (USA reference)",
        "related": "/guides/invoice-pdf-workflow-india",
        "note": "MSA + SOW + DPA if needed — GSTIN on commercial invoices separate — watermark negotiation drafts",
    },
    "ireland": {
        "title": "Contract PDF Workflow Ireland — SME Agreement &amp; GDPR Pack (2026)",
        "example": "Dublin agency merges services agreement and GDPR processing schedule PDF for client review",
        "pillar": "/guides/contract-pdf-workflow-uk",
        "pillar_label": "contract PDF workflow UK",
        "related": "/guides/visa-application-pdf-workflow-ireland",
        "note": "Heads of terms then full agreement — GDPR Article 28 processor terms as numbered exhibit",
    },
    "japan": {
        "title": "Contract PDF Workflow Japan — B2B Keiyaku &amp; Bilingual Pack (2026)",
        "example": "Exporter merges Japanese master keiyaku and English translation PDF for overseas buyer countersign",
        "pillar": "/guides/contract-pdf-workflow-usa",
        "pillar_label": "contract PDF workflow hub",
        "related": "/guides/visa-application-pdf-workflow-japan",
        "note": "Hanko/stamp culture — digital PDF sign via e-sign platform — bilingual deals need both language exhibits",
    },
    "netherlands": {
        "title": "Contract PDF Workflow Netherlands — B2B Overeenkomst Pack (2026)",
        "example": "Amsterdam startup merges overeenkomst and AVV GDPR bijlage PDF before investor pilot",
        "pillar": "/guides/contract-pdf-workflow-germany",
        "pillar_label": "contract PDF workflow Germany",
        "related": "/guides/visa-application-pdf-workflow-netherlands",
        "note": "AVG/GDPR processor agreement — merge master first — Dutch or English per counterparty",
    },
    "singapore": {
        "title": "Contract PDF Workflow Singapore — MSA &amp; PDPA Pack (2026)",
        "example": "Fintech merges MSA and PDPA data processing addendum PDF for MAS-regulated client onboarding",
        "pillar": "/guides/contract-pdf-workflow-australia",
        "pillar_label": "contract PDF workflow Australia",
        "related": "/guides/visa-application-pdf-workflow-singapore",
        "note": "PDPA schedule separate exhibit — merge for internal review — compress email copy under 20 MB",
    },
    "spain": {
        "title": "Contract PDF Workflow Spain — Contrato B2B &amp; RGPD Anexo (2026)",
        "example": "Barcelona consultancy merges contrato marco and anexo RGPD PDF before cliente firma",
        "pillar": "/guides/contract-pdf-workflow-italy",
        "pillar_label": "contract PDF workflow Italy",
        "related": "/guides/visa-application-pdf-workflow-spain",
        "note": "LOPDGDD data processing annex — watermark borrador on negotiation copies",
    },
    "uae": {
        "title": "Contract PDF Workflow UAE — Commercial Contract &amp; PRO Pack (2026)",
        "example": "Dubai free-zone company merges commercial agreement and attested trade licence PDF for PRO filing",
        "pillar": "/guides/contract-pdf-workflow-usa",
        "pillar_label": "contract PDF workflow hub",
        "related": "/guides/visa-application-pdf-workflow-uae",
        "note": "Arabic translation may be required for certain filings — merge English master + translation exhibit",
    },
}

W28_TAX_META = {
    "australia": {
        "title": "Tax Document PDF Workflow Australia — ATO &amp; myGov Upload (2026)",
        "example": "Mortgage applicant compresses ATO notice of assessment PDF for lender KYC portal",
        "forms": "Notice of assessment, payment summary, BAS PDF exports from myGov/ATO",
        "portal": "Lender KYC, rental agent, visa financial evidence — often 2–5 MB per slot",
        "related": "/guides/visa-application-pdf-workflow-australia",
    },
    "brazil": {
        "title": "Tax Document PDF Workflow Brazil — IRPF &amp; Receita Federal (2026)",
        "example": "Applicant compresses IRPF recibo PDF for consulate financial evidence upload",
        "forms": "IRPF declaração, recibo de entrega, Informe de Rendimentos from Receita",
        "portal": "Consulate, bank loan, rental — compress under 3 MB safe default",
        "related": "/guides/visa-application-pdf-workflow-brazil",
    },
    "canada": {
        "title": "Tax Document PDF Workflow Canada — CRA My Account &amp; NOA (2026)",
        "example": "Express Entry applicant compresses CRA notice of assessment PDF for IRCC proof of funds workflow",
        "forms": "Notice of assessment (NOA), T4, tax return PDF from CRA My Account",
        "portal": "IRCC, mortgage broker, provincial rental — 2–4 MB typical",
        "related": "/guides/visa-application-pdf-workflow-canada",
    },
    "france": {
        "title": "Tax Document PDF Workflow France — Avis d'Imposition &amp; impots.gouv (2026)",
        "example": "Tenant compresses avis d'imposition PDF for dossier locatif under 2 MB cap",
        "forms": "Avis d'imposition, déclaration PDF from impots.gouv — not altered scans",
        "portal": "Rental dossier, visa financial proof, loan KYC",
        "related": "/guides/visa-application-pdf-workflow-france",
    },
    "germany": {
        "title": "Tax Document PDF Workflow Germany — Steuerbescheid &amp; Elster (2026)",
        "example": "Applicant compresses Finanzamt Steuerbescheid PDF for visa blocked-account evidence bundle",
        "forms": "Steuerbescheid, Lohnsteuerbescheinigung PDF from Elster or employer",
        "portal": "Visa, rental, mortgage — verify Finanzamt stamp readable after compress",
        "related": "/guides/visa-application-pdf-workflow-germany",
    },
    "ireland": {
        "title": "Tax Document PDF Workflow Ireland — Revenue ROS &amp; P60 (2026)",
        "example": "Renter compresses Revenue tax summary PDF for landlord agent portal",
        "forms": "P60, tax clearance certificate, ROS statement PDF",
        "portal": "Rental, mortgage, AVATS supporting docs",
        "related": "/guides/visa-application-pdf-workflow-ireland",
    },
    "italy": {
        "title": "Tax Document PDF Workflow Italy — CU &amp; Agenzia Entrate (2026)",
        "example": "Worker compresses Certificazione Unica PDF for rental contract dossier",
        "forms": "CU, dichiarazione dei redditi PDF from Agenzia Entrate",
        "portal": "Affitto, visa Schengen financial evidence, bank loan",
        "related": "/guides/visa-application-pdf-workflow-italy",
    },
    "japan": {
        "title": "Tax Document PDF Workflow Japan — e-Tax &amp; Gensen Choshu (2026)",
        "example": "Visa applicant compresses kazei shomeisho tax certificate PDF for embassy slot",
        "forms": "Gensen choshu hyo, e-Tax PDF, municipal tax certificate",
        "portal": "Embassy, COE, rental guarantor — Japanese or English export",
        "related": "/guides/visa-application-pdf-workflow-japan",
    },
    "mexico": {
        "title": "Tax Document PDF Workflow Mexico — SAT &amp; Declaración PDF (2026)",
        "example": "Loan applicant compresses SAT constancia de situación fiscal PDF for bank portal",
        "forms": "Constancia de situación fiscal, declaración anual PDF from SAT",
        "portal": "Bank KYC, consulate, rental — RFC visible at 100% zoom",
        "related": "/guides/visa-application-pdf-workflow-mexico",
    },
}


def _contract_data(code: str) -> dict:
    m = W28_CONTRACT_META[code]
    return {
        "title": m["title"],
        "tool": "/pdf/merge",
        "label": "Merge PDF",
        "pillar": m["pillar"],
        "pillar_label": m["pillar_label"],
        "related": m["related"],
        "example": m["example"],
    }


def _tax_data(code: str) -> dict:
    m = W28_TAX_META[code]
    return {
        "title": m["title"],
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/tax-document-pdf-workflow-india",
        "pillar_label": "tax document workflow India (reference)",
        "related": m["related"],
        "example": m["example"],
    }


W28_DATA = {
    **{f"contract-pdf-workflow-{k}": _contract_data(k) for k in W28_CONTRACT_META},
    **{f"tax-document-pdf-workflow-{k}": _tax_data(k) for k in W28_TAX_META},
}


def _contract_deep(code: str) -> str:
    m = W28_CONTRACT_META[code]
    return f"""
            <h2>Contract PDF — {code.replace('-', ' ').title() if code != 'uae' else 'UAE'}</h2>
            <p>{m['note']}. Watermark negotiation drafts — flatten only after mutual sign.</p>
            <h2>Workflow</h2>
            <ol>
            <li>Export each part from Word or e-sign tool — consistent page size</li>
            <li><a href="/pdf/merge">Merge PDF</a> — master agreement first, exhibits numbered</li>
            <li><a href="/pdf/watermark">Watermark</a> DRAFT on negotiation email copies</li>
            <li>After countersign — <a href="/pdf/flatten">Flatten</a> — <a href="/pdf/compress">compress</a> email copy if over cap</li>
            <li>Confidential schedules — <a href="/guides/password-protect-pdf">password protect</a> — separate channel</li>
            </ol>
            <h2>Compliance</h2>
            <p>Do not merge unrelated client contracts — data minimisation applies. See <a href="/guides/edit-pdf-mistakes-compliance">edit compliance mistakes</a>.</p>
            <p>Regional: <a href="{m['related']}">{m['related'].split('/')[-1].replace('-', ' ')}</a>.</p>
            """


def _tax_deep(code: str) -> str:
    m = W28_TAX_META[code]
    return f"""
            <h2>Tax documents — {code.replace('-', ' ').title()}</h2>
            <p><strong>Common PDFs:</strong> {m['forms']}.</p>
            <p><strong>Typical use:</strong> {m['portal']}.</p>
            <h2>Workflow</h2>
            <ol>
            <li>Download official PDF from tax authority portal — not edited screenshots</li>
            <li>Verify name, tax ID, and assessment year at 100% zoom</li>
            <li><a href="/pdf/merge">Merge PDF</a> only if portal allows single bundle — else one file per slot</li>
            <li><a href="/pdf/compress">Compress PDF</a> Recommended if over cap — Less if figures blur</li>
            <li>Never alter tax figures — fraud risk and automatic rejection</li>
            </ol>
            <h2>Loan and visa KYC</h2>
            <p>Pair with <a href="{m['related']}">visa workflow</a> when immigration evidence. India reference: <a href="/guides/tax-document-pdf-workflow-india">tax workflow India</a>.</p>
            <h2>Troubleshooting</h2>
            <p><strong>Password-protected portal PDF:</strong> unlock only if you set password — re-export unprotected if portal allows. <strong>Scan instead of export:</strong> re-download from authority site.</p>
            """


W28_CONTRACT_DEEP = {f"contract-pdf-workflow-{k}": _contract_deep(k) for k in W28_CONTRACT_META}
W28_TAX_DEEP = {f"tax-document-pdf-workflow-{k}": _tax_deep(k) for k in W28_TAX_META}
W28_DEEP = {**W28_CONTRACT_DEEP, **W28_TAX_DEEP}

W28_CONTRACT_CLUSTER = """
            <h2>Regional contract workflow batch 6</h2>
            <ul>
            <li><a href="/guides/contract-pdf-workflow-france">France</a> · <a href="/guides/contract-pdf-workflow-spain">Spain</a> · <a href="/guides/contract-pdf-workflow-netherlands">Netherlands</a></li>
            <li><a href="/guides/contract-pdf-workflow-ireland">Ireland</a> · <a href="/guides/contract-pdf-workflow-india">India</a> · <a href="/guides/contract-pdf-workflow-japan">Japan</a></li>
            <li><a href="/guides/contract-pdf-workflow-singapore">Singapore</a> · <a href="/guides/contract-pdf-workflow-uae">UAE</a></li>
            </ul>
            <p>Prior batches: <a href="/guides/contract-pdf-workflow-canada">Canada</a> · <a href="/guides/contract-pdf-workflow-usa">USA</a> · <a href="/guides/contract-pdf-workflow-uk">UK</a> · <a href="/guides/contract-pdf-workflow-italy">Italy</a></p>
            <p>Hub: <a href="/guides/pdf-regional-workflows-hub">regional workflows index</a></p>
            """

W28_TAX_CLUSTER = """
            <h2>Tax document workflow batch 1</h2>
            <ul>
            <li><a href="/guides/tax-document-pdf-workflow-australia">Australia</a> · <a href="/guides/tax-document-pdf-workflow-canada">Canada</a> · <a href="/guides/tax-document-pdf-workflow-usa">USA</a></li>
            <li><a href="/guides/tax-document-pdf-workflow-uk">UK</a> · <a href="/guides/tax-document-pdf-workflow-germany">Germany</a> · <a href="/guides/tax-document-pdf-workflow-france">France</a></li>
            <li><a href="/guides/tax-document-pdf-workflow-italy">Italy</a> · <a href="/guides/tax-document-pdf-workflow-spain">Spain</a> · <a href="/guides/tax-document-pdf-workflow-ireland">Ireland</a></li>
            <li><a href="/guides/tax-document-pdf-workflow-japan">Japan</a> · <a href="/guides/tax-document-pdf-workflow-mexico">Mexico</a> · <a href="/guides/tax-document-pdf-workflow-brazil">Brazil</a></li>
            </ul>
            <p>India (reference): <a href="/guides/tax-document-pdf-workflow-india">tax workflow India</a> · Hub: <a href="/guides/pdf-regional-workflows-hub">regional index</a></p>
            """

W28_CONTRACT_TOPUP = """
            <h2>Contract PDF rollout checklist</h2>
            <ol>
            <li>Master agreement before exhibits — numbered index page if long pack</li>
            <li>Watermark DRAFT on negotiation copies only — not final signed vault copy</li>
            <li>Flatten after all parties sign — prevents moving signature blocks</li>
            <li>Password-protect confidential schedules — never password in same email</li>
            <li>Archive uncompressed signed master — compress email copies only</li>
            </ol>
            """

W28_TAX_TOPUP = """
            <h2>Tax PDF evidence checklist</h2>
            <ol>
            <li>Official portal export — not mobile photo of screen</li>
            <li>Assessment year and taxpayer name match application</li>
            <li>Tax ID / reference number readable after compress</li>
            <li>One document per portal slot unless merge explicitly allowed</li>
            <li>Never edit amounts — re-download from authority if wrong file</li>
            </ol>
            <p>Compress guides: <a href="/guides/compress-pdf-for-email">email</a> · <a href="/guides/compress-pdf-for-visa-application">visa application</a>.</p>
            """

W28_CLOSING = """
            <h2>Related guides</h2>
            <p>Regional contract and tax workflow pages prepare PDFs for portals — RatPDF does not file taxes or provide legal advice. Verify live portal caps before deadline day.</p>
            """
