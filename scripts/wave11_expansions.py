"""Wave 11 — Security & compliance: redaction, GDPR, HIPAA, WCAG, password, watermark."""

W11_SLUGS = [
    "password-protect-pdf",
    "unlock-pdf",
    "watermark-pdf",
    "pdf-redaction",
    "hipaa-pdf-handling",
    "section-508-pdf",
    "secure-pdf-workflow",
    "blackout-text-in-pdf",
    "remove-password-from-pdf",
    "pdf-accessibility-wcag",
    "gdpr-pdf-redaction-workflow",
    "hipaa-compliant-pdf-email",
    "pdf-accessibility-checker",
    "tagged-pdf-checklist",
    "redact-pdf-discovery",
    "pdf-metadata-remove",
    "pdf-security-compliance-guide",
]

W11_DATA = {
    "password-protect-pdf": {
        "title": "Password Protect PDF — Encrypt Before Email &amp; Portal Upload (2026)",
        "tool": "/pdf/password",
        "label": "Protect PDF",
        "example": "HR sends encrypted payslip PDF — password shared via separate SMS",
    },
    "unlock-pdf": {
        "title": "Unlock PDF — Remove Password When You Know the Passphrase (2026)",
        "tool": "/pdf/unlockpdf",
        "label": "Unlock PDF",
        "example": "Archive team decrypts legacy board pack for merge and compress chain",
    },
    "watermark-pdf": {
        "title": "Watermark PDF — DRAFT &amp; CONFIDENTIAL Labels Online (2026)",
        "tool": "/pdf/watermark",
        "label": "Watermark PDF",
        "example": "Legal marks draft contract CONFIDENTIAL before partner review",
    },
    "pdf-redaction": {
        "title": "PDF Redaction — Permanently Remove Sensitive Text Online (2026)",
        "tool": "/pdf-redaction",
        "label": "PDF Redaction",
        "example": "Paralegal redacts SSN and account numbers before discovery production",
    },
    "hipaa-pdf-handling": {
        "title": "HIPAA PDF Handling — PHI in Attachments &amp; Redaction Workflow (2026)",
        "tool": "/pdf/password",
        "label": "Protect PDF",
        "example": "Clinic admin encrypts discharge summary PDF before portal upload",
    },
    "section-508-pdf": {
        "title": "Section 508 PDF — Federal Accessibility Requirements Checklist (2026)",
        "tool": "/pdf/ocrpdf",
        "label": "OCR PDF",
        "example": "Agency comms team remediates annual report PDF for federal publication",
    },
    "secure-pdf-workflow": {
        "title": "Secure PDF Workflow Hub — Protect, Watermark, Redact &amp; Unlock (2026)",
        "tool": "/guides/pdf-tools",
        "label": "PDF tools hub",
        "example": "IT security one-pager for which RatPDF control applies to each risk",
    },
    "blackout-text-in-pdf": {
        "title": "Blackout Text in PDF — True Redaction vs Fake Black Boxes (2026)",
        "tool": "/pdf-redaction",
        "label": "PDF Redaction",
        "example": "FOIA officer removes witness names — must not be recoverable via copy-paste",
    },
    "remove-password-from-pdf": {
        "title": "Remove Password from PDF — Decrypt When Authorized (2026)",
        "tool": "/pdf/unlockpdf",
        "label": "Unlock PDF",
        "example": "Operations removes owner password to enable merge before re-encrypting final pack",
    },
    "pdf-accessibility-wcag": {
        "title": "PDF Accessibility WCAG — Tags, Alt Text &amp; Reading Order (2026)",
        "tool": "/pdf/ocrpdf",
        "label": "OCR PDF",
        "example": "University publishes course pack PDF meeting WCAG 2.2 contrast and structure",
    },
    "gdpr-pdf-redaction-workflow": {
        "title": "GDPR PDF Redaction Workflow — DSAR &amp; Minimisation Steps (2026)",
        "tool": "/pdf-redaction",
        "label": "PDF Redaction",
        "example": "DPO team redacts third-party names from contract PDF for data subject access response",
    },
    "hipaa-compliant-pdf-email": {
        "title": "HIPAA Compliant PDF Email — PHI Attachment Controls (2026)",
        "tool": "/pdf/password",
        "label": "Protect PDF",
        "example": "Billing sends encrypted statement PDF — never password in same email thread",
    },
    "pdf-accessibility-checker": {
        "title": "PDF Accessibility Checker — Manual QA &amp; Tool Limits (2026)",
        "tool": "/pdf/ocrpdf",
        "label": "OCR PDF",
        "example": "Comms runs checklist before publishing public benefits PDF",
    },
    "tagged-pdf-checklist": {
        "title": "Tagged PDF Checklist — Structure Tree &amp; Screen Reader QA (2026)",
        "tool": "/pdf/ocrpdf",
        "label": "OCR PDF",
        "example": "Publisher verifies heading tags before government RFP submission",
    },
    "redact-pdf-discovery": {
        "title": "Redact PDF for Discovery — Privilege &amp; PII in Litigation (2026)",
        "tool": "/pdf-redaction",
        "label": "PDF Redaction",
        "example": "Law firm produces Bates-stamped PDF set with privilege log for redacted segments",
    },
    "pdf-metadata-remove": {
        "title": "PDF Metadata Remove — Author, Title &amp; Hidden Properties (2026)",
        "tool": "/pdf/pdfmetadata",
        "label": "PDF Metadata",
        "example": "Anonymise author field on external-share draft before client send",
    },
    "pdf-security-compliance-guide": {
        "title": "PDF Security &amp; Compliance Hub — GDPR, HIPAA, 508, Redaction (2026)",
        "tool": "/guides/pdf-tools",
        "label": "PDF tools hub",
        "example": "Compliance officer index linking security tools to regulatory frameworks",
    },
}

W11_DEEP = {
    "password-protect-pdf": """
            <h2>User vs owner password</h2>
            <p><strong>User password</strong> blocks opening. <strong>Owner password</strong> restricts print/copy even when open. Choose based on recipient workflow — merge chains need decrypt first via <a href="/guides/unlock-pdf">unlock guide</a>.</p>
            <h2>Password hygiene</h2>
            <ol>
            <li>12+ character passphrase — not reused from banking</li>
            <li>Share password on separate channel — SMS or password manager share</li>
            <li>Document who received which password in ticket system</li>
            <li>Compress before encrypt if size matters — encrypted PDFs compress poorly</li>
            </ol>
            """,
    "unlock-pdf": """
            <h2>Authorized unlock only</h2>
            <p>RatPDF removes encryption when you supply the valid password — no cracking unknown passwords. Legal and policy: only documents you own or are authorized to decrypt.</p>
            <h2>After unlock</h2>
            <p>Chain <a href="/guides/merge-pdf">merge</a>, <a href="/guides/compress-pdf-guide">compress</a>, <a href="/guides/pdf-redaction">redact</a> — re-<a href="/guides/password-protect-pdf">protect</a> final external copy.</p>
            """,
    "watermark-pdf": """
            <h2>Watermark is not encryption</h2>
            <p>Diagonal DRAFT or CONFIDENTIAL text deters casual sharing — does not stop opening. Pair with <a href="/guides/password-protect-pdf">password protect</a> for sensitive externals — see <a href="/guides/watermark-vs-password-pdf">watermark vs password</a>.</p>
            <h2>Common labels</h2>
            <p>DRAFT, CONFIDENTIAL, SAMPLE, internal use only, company name on leaked concepts.</p>
            """,
    "pdf-redaction": """
            <h2>True redaction vs black boxes</h2>
            <p>Overlay rectangles leave copyable text underneath — <a href="/pdf-redaction">PDF Redaction</a> removes content from object streams. Verify with Ctrl+F and copy-paste after export.</p>
            <h2>Workflow</h2>
            <ol>
            <li>Duplicate master — never redact only copy</li>
            <li>Mark all regions — overlapping names and account numbers</li>
            <li>Export — search redacted strings</li>
            <li>Log approver for audit trail</li>
            </ol>
            <p>Deep dive: <a href="/guides/pdf-redaction-permanent">permanent redaction guide</a>.</p>
            """,
    "hipaa-pdf-handling": """
            <h2>Minimum necessary</h2>
            <p>Attach only PHI required for task — not full chart when appointment slip suffices. Prefer patient portal over email when available.</p>
            <h2>Technical safeguards</h2>
            <ul>
            <li><a href="/guides/password-protect-pdf">Encrypt PDF</a> before email</li>
            <li><a href="/guides/pdf-redaction">Redact</a> excess identifiers on admin letters</li>
            <li>BAA with vendors processing PHI</li>
            <li>No PHI in email subject lines</li>
            </ul>
            """,
    "section-508-pdf": """
            <h2>Section 508 basics</h2>
            <p>Federal ICT must be accessible — PDFs need tags, logical reading order, alt text on figures, sufficient contrast. Scans alone fail — export from accessible Word or remediate with specialist tools.</p>
            <h2>RatPDF role</h2>
            <p><a href="/pdf/ocrpdf">OCR PDF</a> adds text layer for search — not full tagging. See <a href="/guides/wcag-22-pdf">WCAG 2.2 guide</a> and <a href="/guides/tagged-pdf-checklist">tagged PDF checklist</a>.</p>
            """,
    "secure-pdf-workflow": """
            <h2>Control selection matrix</h2>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>Risk</th><th>Control</th><th>Guide</th></tr></thead>
            <tbody>
            <tr><td>Casual leak of draft</td><td>Watermark</td><td><a href="/guides/watermark-pdf">Watermark</a></td></tr>
            <tr><td>Unauthorized open</td><td>Password</td><td><a href="/guides/password-protect-pdf">Protect</a></td></tr>
            <tr><td>Disclosure of PII</td><td>Redaction</td><td><a href="/guides/pdf-redaction">Redaction</a></td></tr>
            <tr><td>Merge blocked</td><td>Unlock</td><td><a href="/guides/unlock-pdf">Unlock</a></td></tr>
            <tr><td>Public accessibility</td><td>Tagged PDF + OCR</td><td><a href="/guides/pdf-accessibility-wcag">WCAG</a></td></tr>
            </tbody>
            </table></div>
            """,
    "blackout-text-in-pdf": """
            <h2>Why black boxes fail</h2>
            <p>Word export with black highlight, screenshot blackout, or draw rectangle in viewer — text often still extractable. FOIA and GDPR disclosures require permanent removal.</p>
            <h2>Fix</h2>
            <p>Use <a href="/pdf-redaction">PDF Redaction</a> — verify — see <a href="/guides/blackout-text-in-pdf">this guide</a> and <a href="/guides/pdf-redaction-permanent">permanent redaction</a>.</p>
            """,
    "remove-password-from-pdf": """
            <h2>Same as unlock — authorized only</h2>
            <p>When you know password and need unencrypted copy for merge, redaction, or archival system that rejects encryption — <a href="/pdf/unlockpdf">Unlock PDF</a>.</p>
            <h2>Re-protect</h2>
            <p>Decrypt working copy on secure workstation — delete after task — re-encrypt external send.</p>
            """,
    "pdf-accessibility-wcag": """
            <h2>WCAG 2.2 PDF essentials</h2>
            <ul>
            <li>Tagged structure (headings H1-H3)</li>
            <li>Alt text on meaningful images</li>
            <li>Logical reading order — not visual layout order only</li>
            <li>Contrast 4.5:1 body text minimum</li>
            <li>Not image-only scan for public docs</li>
            </ul>
            <p>Detail: <a href="/guides/wcag-22-pdf">WCAG 2.2 PDF guide</a>.</p>
            """,
    "gdpr-pdf-redaction-workflow": """
            <h2>DSAR timeline pressure</h2>
            <p>One-month response — identify personal data in PDF bundle — redact third parties — verify search — deliver encrypted if email — log decision.</p>
            <h2>Art. 5 minimisation</h2>
            <p>Do not send full contract when paragraph answers request — redact unrelated clauses — <a href="/guides/gdpr-pdf-redaction">GDPR redaction requirements</a>.</p>
            """,
    "hipaa-compliant-pdf-email": """
            <h2>Email is risky for PHI</h2>
            <p>Prefer patient portal. If email required: encrypt PDF, separate password channel, minimum necessary attachment, no PHI in subject.</p>
            <h2>Checklist</h2>
            <ol>
            <li>Confirm recipient address twice</li>
            <li><a href="/pdf/password">Protect PDF</a></li>
            <li>Password via phone or secure message — not reply thread</li>
            <li>Retention per policy — delete local copy</li>
            </ol>
            """,
    "pdf-accessibility-checker": """
            <h2>Automated vs manual</h2>
            <p>PAC, axe, Adobe checker catch many issues — manual screen reader test still required — NVDA/VoiceOver through sample pages.</p>
            <h2>Quick manual checks</h2>
            <ol>
            <li>Tab through links in order</li>
            <li>Heading navigation in tagged PDF</li>
            <li>Alt text read aloud on chart page</li>
            <li>Contrast sample on colored callout boxes</li>
            </ol>
            """,
    "tagged-pdf-checklist": """
            <h2>Tag tree QA</h2>
            <ol>
            <li>Document language set</li>
            <li>Title metadata meaningful</li>
            <li>H1 once per document</li>
            <li>Tables tagged as tables not paragraphs</li>
            <li>Figures have Figure tags + alt</li>
            </ol>
            """,
    "redact-pdf-discovery": """
            <h2>Privilege log</h2>
            <p>Every redaction entry: Bates range, basis (privilege/work product), author, date. Redacted PDF is production — not native format alone.</p>
            <h2>Bates and OCR</h2>
            <p>OCR before redaction if search required — apply Bates after final redaction set — compress for portal if needed.</p>
            """,
    "pdf-metadata-remove": """
            <h2>Hidden metadata risk</h2>
            <p>Author, company, edit history, embedded paths — leak in external share. <a href="/pdf/pdfmetadata">PDF Metadata</a> tool view and clean before send.</p>
            <h2>Not a redaction substitute</h2>
            <p>Metadata clean does not remove body text PII — use <a href="/guides/pdf-redaction">redaction</a> for content.</p>
            """,
    "pdf-security-compliance-guide": """
            <h2>Framework map</h2>
            <ul>
            <li><strong>GDPR:</strong> <a href="/guides/gdpr-pdf-redaction-workflow">redaction workflow</a> · <a href="/guides/gdpr-pdf-redaction">requirements</a></li>
            <li><strong>HIPAA:</strong> <a href="/guides/hipaa-pdf-handling">handling</a> · <a href="/guides/hipaa-compliant-pdf-email">email</a></li>
            <li><strong>US Federal:</strong> <a href="/guides/section-508-pdf">Section 508</a> · <a href="/guides/wcag-22-pdf">WCAG 2.2</a></li>
            <li><strong>Security controls:</strong> <a href="/guides/secure-pdf-workflow">workflow hub</a></li>
            </ul>
            """,
}

W11_SLUG_EXTRA = {
    "password-protect-pdf": """
            <h2>Real example: payroll</h2>
            <p>Monthly payslip PDF — encrypt — password SMS to employee — never same email as attachment.</p>
            """,
    "unlock-pdf": """
            <h2>Real example: merge chain</h2>
            <p>Three encrypted exhibits — unlock each — merge — compress — re-protect final board pack.</p>
            """,
    "watermark-pdf": """
            <h2>Real example: agency concept</h2>
            <p>SAMPLE watermark on pitch PDF — client preview — remove watermark on award — protect final SOW.</p>
            """,
    "pdf-redaction": """
            <h2>Real example: HR investigation</h2>
            <p>Redact witness B name from report PDF — verify copy-paste empty — counsel approves.</p>
            """,
    "hipaa-pdf-handling": """
            <h2>Real example: billing dispute</h2>
            <p>Redact diagnosis detail — keep line items only — encrypt — portal upload not email.</p>
            """,
    "section-508-pdf": """
            <h2>Real example: benefits guide</h2>
            <p>Remediate tagged PDF — alt text on icons — PAC pass — publish on .gov subdomain.</p>
            """,
    "secure-pdf-workflow": """
            <h2>Onboarding poster</h2>
            <p>Pin matrix in IT wiki — reduces wrong-tool tickets — watermark vs password confusion drops.</p>
            """,
    "blackout-text-in-pdf": """
            <h2>FOIA lesson</h2>
            <p>Press copied blacked-out budget figure from overlay PDF — true redaction prevents headline leak.</p>
            """,
    "remove-password-from-pdf": """
            <h2>Archive ingest</h2>
            <p>DMS rejects encrypted PDF — unlock — ingest — delete decrypted copy from Downloads.</p>
            """,
    "pdf-accessibility-wcag": """
            <h2>University syllabus</h2>
            <p>Tagged export from Word — OCR not needed on digital — student screen reader navigates headings.</p>
            """,
    "gdpr-pdf-redaction-workflow": """
            <h2>DSAR bundle</h2>
            <p>47-page HR PDF — redact colleague salaries — deliver in 22 days — DPO signs log.</p>
            """,
    "hipaa-compliant-pdf-email": """
            <h2>Billing statement</h2>
            <p>Encrypt PDF — call patient with password — no account number in subject — portal preferred next time.</p>
            """,
    "pdf-accessibility-checker": """
            <h2>Pre-publish gate</h2>
            <p>Comms checklist blocks publish until tagged PDF + manual VoiceOver pass on page 1 and TOC.</p>
            """,
    "tagged-pdf-checklist": """
            <h2>RFP compliance</h2>
            <p>Tagged PDF attachment required — checklist signed by accessibility lead — bid submitted.</p>
            """,
    "redact-pdf-discovery": """
            <h2>Privilege segment</h2>
            <p>Attorney-client email thread pages 44-46 redacted — privilege log entry 17 — Bates DEF_000044.</p>
            """,
    "pdf-metadata-remove": """
            <h2>External draft</h2>
            <p>Strip author metadata showing partner name — watermark DRAFT — client review PDF.</p>
            """,
    "pdf-security-compliance-guide": """
            <h2>Annual training</h2>
            <p>Compliance links this hub in LMS — quiz on watermark vs password vs redaction — 15 min module.</p>
            """,
}

W11_MEGA = """
            <h2>Security vs compliance</h2>
            <p><strong>Security controls</strong> (password, watermark, unlock) limit who sees content. <strong>Compliance</strong> (GDPR, HIPAA, 508) defines what you may share and in what form. Redaction serves both — permanent removal for legal disclosure and privacy law.</p>
            <h2>RatPDF tool chain</h2>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>Tool</th><th>URL</th></tr></thead>
            <tbody>
            <tr><td>Protect PDF</td><td><a href="/pdf/password">/pdf/password</a></td></tr>
            <tr><td>Unlock PDF</td><td><a href="/pdf/unlockpdf">/pdf/unlockpdf</a></td></tr>
            <tr><td>Watermark</td><td><a href="/pdf/watermark">/pdf/watermark</a></td></tr>
            <tr><td>Redaction</td><td><a href="/pdf-redaction">/pdf-redaction</a></td></tr>
            <tr><td>Metadata</td><td><a href="/pdf/pdfmetadata">/pdf/pdfmetadata</a></td></tr>
            <tr><td>OCR (accessibility aid)</td><td><a href="/pdf/ocrpdf">/pdf/ocrpdf</a></td></tr>
            </tbody>
            </table></div>
            <h2>Processor due diligence</h2>
            <p>Before uploading client PII or PHI to any online PDF tool, review <a href="/home/privacy">privacy policy</a>, retention, and subprocessors. Organisational lawful basis and DPA remain your responsibility under GDPR.</p>
            """

W11_CLUSTER = """
            <h2>Security &amp; compliance guides</h2>
            <ul>
            <li><a href="/guides/password-protect-pdf">Password protect</a> · <a href="/guides/unlock-pdf">Unlock</a> · <a href="/guides/remove-password-from-pdf">Remove password</a></li>
            <li><a href="/guides/watermark-pdf">Watermark</a> · <a href="/guides/watermark-vs-password-pdf">Watermark vs password</a></li>
            <li><a href="/guides/pdf-redaction">Redaction</a> · <a href="/guides/blackout-text-in-pdf">Blackout text</a> · <a href="/guides/redact-pdf-discovery">Discovery redaction</a></li>
            <li><a href="/guides/gdpr-pdf-redaction-workflow">GDPR workflow</a> · <a href="/guides/gdpr-pdf-redaction">GDPR requirements</a></li>
            <li><a href="/guides/hipaa-pdf-handling">HIPAA handling</a> · <a href="/guides/hipaa-compliant-pdf-email">HIPAA email</a></li>
            <li><a href="/guides/section-508-pdf">Section 508</a> · <a href="/guides/pdf-accessibility-wcag">WCAG</a> · <a href="/guides/wcag-22-pdf">WCAG 2.2</a></li>
            <li><a href="/guides/tagged-pdf-checklist">Tagged PDF</a> · <a href="/guides/pdf-accessibility-checker">Accessibility checker</a></li>
            <li><a href="/guides/pdf-metadata-remove">Metadata remove</a></li>
            </ul>
            <p>Hubs: <a href="/guides/secure-pdf-workflow">Secure workflow</a> · <a href="/guides/pdf-security-compliance-guide">Compliance hub</a> · <a href="/guides/pdf-redaction-permanent">Permanent redaction</a>.</p>
            """

W11_1500_TOPUP = """
            <h2>Pre-send security checklist</h2>
            <ol>
            <li>Right control: watermark vs password vs redaction</li>
            <li>Redaction verified with search and copy-paste</li>
            <li>Password not in same channel as file</li>
            <li>Metadata stripped if external draft</li>
            <li>Accessibility spot-check for public PDFs</li>
            <li>Incident log for GDPR/HIPAA disclosures</li>
            </ol>
            <h2>Compare vendors</h2>
            <p><a href="/compare/adobe-acrobat-alternative">Adobe alternative</a> · <a href="/guides/pdf-tool-security-comparison">Security comparison</a> · <a href="/home/security">RatPDF security page</a>.</p>
            """

W11_CLOSING = """
            <h2>Related guides</h2>
            <p>Security and compliance guides cover password protection, watermarks, unlock, redaction, GDPR/HIPAA workflows, and accessibility — with honest limits on what each tool can do.</p>
            <p>Standards and archiving guides (PDF/A, retention, metadata) — bookmark the <a href="/guides/pdf-security-compliance-guide">compliance hub</a>.</p>
            """

PILLAR_SLUGS = {"password-protect-pdf", "unlock-pdf", "watermark-pdf", "pdf-redaction", "secure-pdf-workflow", "pdf-security-compliance-guide"}
