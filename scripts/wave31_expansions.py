"""Wave 31 — PDF security authority batch (11) + glossary batch 8 (6)."""

W31_SLUGS = [
    "password-protect-before-email",
    "password-protect-pdf-mac",
    "pdf-encryption-aes-explained",
    "pdf-password-best-practices",
    "pdf-redaction-vs-black-box",
    "pdf-security-lawyers",
    "redact-pdf-gdpr",
    "secure-pdf-remote-work",
    "share-confidential-pdf",
    "sign-pdf-without-docusign",
    "watermark-pdf-draft",
    "glossary-color-profile",
    "glossary-composite-font",
    "glossary-credit-note",
    "glossary-crop-box",
    "glossary-cross-reference-table",
    "glossary-debit-note",
]

SECURITY_SLUGS = {
    "password-protect-before-email",
    "password-protect-pdf-mac",
    "pdf-encryption-aes-explained",
    "pdf-password-best-practices",
    "pdf-redaction-vs-black-box",
    "pdf-security-lawyers",
    "redact-pdf-gdpr",
    "secure-pdf-remote-work",
    "share-confidential-pdf",
    "sign-pdf-without-docusign",
    "watermark-pdf-draft",
}

GLOSSARY_SLUGS = {
    "glossary-color-profile",
    "glossary-composite-font",
    "glossary-credit-note",
    "glossary-crop-box",
    "glossary-cross-reference-table",
    "glossary-debit-note",
}

W31_DATA = {
    "password-protect-before-email": {
        "title": "Password Protect PDF Before Email — Encrypt Attachments (2026)",
        "tool": "/pdf/password",
        "label": "Protect PDF",
        "pillar": "/guides/password-protect-pdf",
        "pillar_label": "password protect PDF guide",
        "related": "/guides/how-to-password-protect-a-pdf",
        "example": "HR encrypts payslip PDF — shares passphrase via SMS, never in the same email thread as the attachment",
    },
    "password-protect-pdf-mac": {
        "title": "Password Protect PDF on Mac — Preview vs Browser Workflow (2026)",
        "tool": "/pdf/password",
        "label": "Protect PDF",
        "pillar": "/guides/password-protect-pdf",
        "pillar_label": "password protect PDF guide",
        "related": "/guides/how-to-password-protect-a-pdf",
        "example": "Consultant on MacBook Air encrypts contract PDF in browser — no Preview export quirks on Big Sur",
    },
    "pdf-encryption-aes-explained": {
        "title": "PDF Encryption AES Explained — 128 vs 256-Bit &amp; PDF Versions (2026)",
        "tool": "/pdf/password",
        "label": "Protect PDF",
        "pillar": "/guides/password-protect-pdf",
        "pillar_label": "password protect PDF guide",
        "related": "/guides/pdf-password-best-practices",
        "example": "IT security reviews vendor questionnaire — asks whether PDF encryption uses AES-256 and PDF 2.0",
    },
    "pdf-password-best-practices": {
        "title": "PDF Password Best Practices — Passphrases, Channels &amp; Recovery (2026)",
        "tool": "/pdf/password",
        "label": "Protect PDF",
        "pillar": "/guides/secure-pdf-workflow",
        "pillar_label": "secure PDF workflow hub",
        "related": "/blog/secure-pdf-password-best-practices",
        "example": "Finance team adopts 16+ character passphrases — password manager entry — separate Slack DM for each client PDF",
    },
    "pdf-redaction-vs-black-box": {
        "title": "PDF Redaction vs Black Box — Why Overlays Fail Disclosure (2026)",
        "tool": "/pdf-redaction",
        "label": "PDF Redaction",
        "pillar": "/guides/blackout-text-in-pdf",
        "pillar_label": "blackout text in PDF",
        "related": "/guides/pdf-redaction-permanent",
        "example": "FOIA journalist copies redacted budget figure from highlight overlay — true redaction removes object stream text",
    },
    "pdf-security-lawyers": {
        "title": "PDF Security for Lawyers — Privilege, Redaction &amp; Client Packs (2026)",
        "tool": "/pdf/password",
        "label": "Protect PDF",
        "pillar": "/guides/pdf-workflow-lawyers",
        "pillar_label": "PDF workflow for lawyers",
        "related": "/guides/redact-pdf-discovery",
        "example": "Associate encrypts draft settlement PDF — watermarks DRAFT — redacts third-party names before opposing counsel production",
    },
    "redact-pdf-gdpr": {
        "title": "Redact PDF for GDPR — DSAR, Minimisation &amp; Verification (2026)",
        "tool": "/pdf-redaction",
        "label": "PDF Redaction",
        "pillar": "/guides/gdpr-pdf-redaction-workflow",
        "pillar_label": "GDPR PDF redaction workflow",
        "related": "/guides/gdpr-pdf-redaction",
        "example": "DPO redacts colleague salary lines from HR contract PDF in data subject access response — logs approver",
    },
    "secure-pdf-remote-work": {
        "title": "Secure PDF Remote Work — Home Office, VPN &amp; BYOD Controls (2026)",
        "tool": "/guides/secure-pdf-workflow",
        "label": "secure PDF workflow",
        "pillar": "/guides/secure-pdf-workflow",
        "pillar_label": "secure PDF workflow hub",
        "related": "/guides/share-confidential-pdf",
        "example": "Distributed legal team standardises encrypt-before-Slack-upload — no client PDF in personal Downloads overnight",
    },
    "share-confidential-pdf": {
        "title": "Share Confidential PDF — Watermark, Encrypt &amp; Channel Hygiene (2026)",
        "tool": "/pdf/password",
        "label": "Protect PDF",
        "pillar": "/guides/secure-pdf-workflow",
        "pillar_label": "secure PDF workflow hub",
        "related": "/guides/how-to-protect-pdf-before-sending",
        "example": "Agency sends investor deck PDF — CONFIDENTIAL watermark plus password — link in email, passphrase in call",
    },
    "sign-pdf-without-docusign": {
        "title": "Sign PDF Without DocuSign — Free Browser Signature Workflow (2026)",
        "tool": "/pdf/signtext",
        "label": "Sign PDF",
        "pillar": "/guides/sign-pdf-legally",
        "pillar_label": "sign PDF legally",
        "related": "/guides/how-to-sign-a-pdf",
        "example": "SMB countersigns vendor NDA in RatPDF — typed signature on line — no per-envelope SaaS fee",
    },
    "watermark-pdf-draft": {
        "title": "Watermark PDF as DRAFT — Status Labels Before External Share (2026)",
        "tool": "/pdf/watermark",
        "label": "Watermark PDF",
        "pillar": "/guides/watermark-pdf",
        "pillar_label": "watermark PDF guide",
        "related": "/guides/watermark-vs-password-pdf",
        "example": "Product manager stamps DRAFT on roadmap PDF for pilot customer — removes watermark on GA release",
    },
    "glossary-color-profile": {
        "title": "What Is a Color Profile in PDF? — ICC, sRGB &amp; Print Mismatch (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/glossary-pdf-x",
        "pillar_label": "PDF/X glossary",
        "related": "/guides/glossary-cmyk",
        "example": "Designer exports brochure PDF — printer rejects because RGB sRGB profile missing output intent for PDF/X",
    },
    "glossary-composite-font": {
        "title": "What Is a Composite Font in PDF? — CID &amp; CJK Encoding (2026)",
        "tool": "/pdf/ocrpdf",
        "label": "OCR PDF",
        "pillar": "/guides/glossary-cid-font",
        "pillar_label": "CID font glossary",
        "related": "/guides/glossary-cmap",
        "example": "Japanese annual report PDF search fails — composite font without proper CMap yields garbage copy-paste",
    },
    "glossary-credit-note": {
        "title": "What Is a Credit Note on a PDF Invoice? — AR &amp; GST Context (2026)",
        "tool": "/invoice/create",
        "label": "Create Invoice",
        "pillar": "/guides/glossary-debit-note",
        "pillar_label": "debit note glossary",
        "related": "/guides/glossary-gst-invoice",
        "example": "Accountant issues credit note PDF after partial return — must reference original invoice number and GST line",
    },
    "glossary-crop-box": {
        "title": "What Is the Crop Box in PDF? — Page Boundaries Explained (2026)",
        "tool": "/pdf/crop",
        "label": "Crop PDF",
        "pillar": "/guides/glossary-media-box",
        "pillar_label": "media box glossary",
        "related": "/guides/glossary-bleed-box",
        "example": "Print shop crops PDF to crop box — footer clipped because bleed box was never set in InDesign export",
    },
    "glossary-cross-reference-table": {
        "title": "What Is a Cross-Reference Table in PDF? — xref &amp; Repair (2026)",
        "tool": "/pdf/repair",
        "label": "Repair PDF",
        "pillar": "/guides/glossary-pdf",
        "pillar_label": "PDF glossary",
        "related": "/guides/glossary-linearized",
        "example": "Corrupted PDF won't open — broken xref table after bad email transfer — repair rebuilds object offsets",
    },
    "glossary-debit-note": {
        "title": "What Is a Debit Note on a PDF Invoice? — B2B &amp; Tax Context (2026)",
        "tool": "/invoice/create",
        "label": "Create Invoice",
        "pillar": "/guides/glossary-credit-note",
        "pillar_label": "credit note glossary",
        "related": "/guides/glossary-gst-invoice",
        "example": "Supplier sends debit note PDF for extra freight charge — buyer matches to PO before payment run",
    },
}

W31_SECURITY_DEEP = {
    "password-protect-before-email": """
            <h2>Why encrypt before email</h2>
            <p>Email is not end-to-end encrypted by default — SMTP hops, backups, and compromised inboxes expose attachments. <strong>Password-protected PDF</strong> adds a second gate: even if the message is forwarded, the file stays locked without the passphrase.</p>
            <h2>Step-by-step workflow</h2>
            <ol>
            <li>Finalise PDF — merge exhibits first, compress once after</li>
            <li>Upload to <a href="/pdf/password">Protect PDF</a> — set user password (required to open)</li>
            <li>Optional owner password — restrict print/copy if policy requires</li>
            <li>Download encrypted PDF — attach to email</li>
            <li>Share password on <strong>separate channel</strong> — SMS, phone, or secure chat — never subject line</li>
            </ol>
            <h2>Common mistakes</h2>
            <ul>
            <li>Password in same email thread as attachment</li>
            <li>Weak passwords — use passphrase 12+ characters</li>
            <li>Watermark only — visible mark does not encrypt — see <a href="/guides/watermark-vs-password-pdf">watermark vs password</a></li>
            <li>Encrypting wrong version — keep unencrypted master in secure archive</li>
            </ul>
            <h2>Provider limits still apply</h2>
            <p>Encryption does not shrink file size — compress first if over Gmail 25 MB — <a href="/guides/email-attachment-size-limits-2026">email limits guide</a> · Checklist: <a href="/guides/pdf-email-attachment-checklist">pre-send checklist</a>.</p>
            <h2>When password is not enough</h2>
            <p>PII that must not appear at all — use <a href="/pdf-redaction">redaction</a> before encrypt. Public drafts — <a href="/pdf/watermark">watermark</a> DRAFT. Hub: <a href="/guides/secure-pdf-workflow">secure PDF workflow</a>.</p>
            """,
    "password-protect-pdf-mac": """
            <h2>Mac options compared</h2>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>Method</th><th>Pros</th><th>Cons</th></tr></thead>
            <tbody>
            <tr><td>Preview → Export → Encrypt</td><td>Offline, no upload</td><td>PDF 1.4 only on older macOS — AES options limited</td></tr>
            <tr><td>Adobe Acrobat</td><td>Full control</td><td>License cost — updates lag on Apple Silicon</td></tr>
            <tr><td>RatPDF browser</td><td>AES presets — no install</td><td>Requires HTTPS — review <a href="/home/security">security page</a></td></tr>
            </tbody></table></div>
            <h2>Browser workflow on Mac</h2>
            <ol>
            <li>Safari or Chrome — open <a href="/pdf/password">Protect PDF</a></li>
            <li>Drag PDF from Finder — set user password</li>
            <li>Download to Downloads — move to encrypted disk image if policy requires</li>
            </ol>
            <h2>Apple Silicon and iCloud</h2>
            <p>iCloud-synced Downloads may replicate decrypted copies — disable sync for client folders or use FileVault. After unlock for merge, delete plaintext from Downloads — <a href="/guides/unlock-pdf">unlock guide</a>.</p>
            <h2>Shortcuts automation</h2>
            <p>Automator/Shortcuts can batch-rename but rarely apply strong AES — manual password per client is safer for legal packs. Pair with <a href="/guides/pdf-password-best-practices">password best practices</a>.</p>
            """,
    "pdf-encryption-aes-explained": """
            <h2>What AES means in PDF</h2>
            <p><strong>AES (Advanced Encryption Standard)</strong> encrypts PDF content streams and strings. PDF 1.6+ supports AES-128; PDF 1.7 extension level 3 and PDF 2.0 support AES-256. Older RC4-40/128-bit encryption is obsolete — do not use for new files.</p>
            <h2>User vs owner password</h2>
            <ul>
            <li><strong>User password:</strong> required to open document</li>
            <li><strong>Owner password:</strong> controls permissions (print, copy, modify) — can open without user password if permissions dict allows</li>
            </ul>
            <p>Best practice: set both — strong user passphrase for recipients — owner password for your records — <a href="/guides/pdf-password-best-practices">best practices guide</a>.</p>
            <h2>PDF version matrix</h2>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>Encryption</th><th>Typical PDF version</th><th>Notes</th></tr></thead>
            <tbody>
            <tr><td>RC4-128</td><td>1.4–1.5</td><td>Legacy — avoid for new sensitive docs</td></tr>
            <tr><td>AES-128</td><td>1.6+</td><td>Widely compatible</td></tr>
            <tr><td>AES-256</td><td>1.7 ext 3 / 2.0</td><td>Preferred for new legal/finance packs</td></tr>
            </tbody></table></div>
            <h2>Limits of encryption</h2>
            <p>Encryption protects confidentiality at rest and in transit — it does <strong>not</strong> remove text from the file. Redact PII before encrypt. Watermarks are not encryption. Compare: <a href="/guides/pdf-redaction-vs-password">redaction vs password</a>.</p>
            <h2>RatPDF implementation</h2>
            <p>Protect PDF applies modern AES presets compatible with Acrobat and Preview — verify recipient can open before deleting master — <a href="/guides/how-to-password-protect-a-pdf">how-to guide</a>.</p>
            """,
    "pdf-password-best-practices": """
            <h2>Passphrase rules</h2>
            <ul>
            <li><strong>Length over complexity theatre:</strong> 16+ character passphrase beats short symbols</li>
            <li><strong>Unique per document</strong> for high-sensitivity — not one firm-wide password</li>
            <li><strong>Password manager</strong> generates and stores — share via secure link or vault</li>
            <li><strong>No dictionary words</strong> alone — combine unrelated words or use generated strings</li>
            </ul>
            <h2>Channel separation</h2>
            <p>File in email — password in SMS or phone call. Never subject line hints ("password is Q4report"). For teams — use encrypted chat or client portal — <a href="/guides/share-confidential-pdf">share confidential PDF</a>.</p>
            <h2>Recovery and rotation</h2>
            <p>Store owner password in secure vault — if employee leaves, rotate client passphrases on recurring sends. Lost password = unrecoverable without backup — keep unencrypted master in access-controlled archive only.</p>
            <h2>Watermarks are not passwords</h2>
            <p>DRAFT diagonal text deters casual sharing — anyone with the file can still copy — pair watermark with encryption for externals — <a href="/guides/watermark-vs-password-pdf">comparison guide</a> · Blog deep dive: <a href="/blog/secure-pdf-password-best-practices">password security blog</a>.</p>
            <h2>Organisational policy</h2>
            <p>Document in IT acceptable-use: when to encrypt (payroll, medical, legal privilege), approved tools, retention — <a href="/guides/pdf-tool-security-comparison">vendor comparison</a> · <a href="/guides/pdf-security-compliance-guide">compliance hub</a>.</p>
            """,
    "pdf-redaction-vs-black-box": """
            <h2>Fake black boxes fail</h2>
            <p>Highlight tool black rectangles, annotation overlays, and image stamps sit <strong>above</strong> text — underlying characters remain in PDF object stream. Copy-paste, search, and "Select All" recover secrets — FOIA and GDPR regulators treat this as breach.</p>
            <h2>True redaction</h2>
            <p>Permanent redaction removes text and image objects — rewrites content stream — pixels replaced with neutral fill — no hidden layer. Verify with:</p>
            <ol>
            <li>Ctrl+F for redacted term — zero hits</li>
            <li>Select region — paste to Notepad — empty</li>
            <li>Open in second viewer — no flash of text on zoom</li>
            </ol>
            <p>Tool: <a href="/pdf-redaction">PDF Redaction</a> · Deep: <a href="/guides/pdf-redaction-permanent">permanent redaction</a> · Compare: <a href="/guides/blackout-text-in-pdf">blackout text guide</a>.</p>
            <h2>When each approach is used</h2>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>Need</th><th>Black overlay</th><th>True redaction</th></tr></thead>
            <tbody>
            <tr><td>Internal mock-up</td><td>Sometimes OK</td><td>Overkill</td></tr>
            <tr><td>FOIA / DSAR / discovery</td><td>Never</td><td>Required</td></tr>
            <tr><td>Client send with PII removed</td><td>Never</td><td>Required</td></tr>
            </tbody></table></div>
            <h2>Workflow with encryption</h2>
            <p>Redact first — encrypt second — watermark optional for draft status. Wrong order: encrypting then trying to redact may require decrypt — <a href="/guides/gdpr-pdf-redaction-workflow">GDPR workflow</a>.</p>
            """,
    "pdf-security-lawyers": """
            <h2>Threat model for legal PDFs</h2>
            <ul>
            <li><strong>Privilege leak:</strong> draft strategy in metadata or track changes — strip metadata — <a href="/guides/pdf-metadata-remove">metadata remove</a></li>
            <li><strong>Discovery production:</strong> PII and privilege — true redaction — <a href="/guides/redact-pdf-discovery">discovery redaction</a></li>
            <li><strong>Client portal upload:</strong> encrypt before external share</li>
            <li><strong>Court e-filing:</strong> often must be unencrypted — check local rules — compress instead</li>
            </ul>
            <h2>Standard pack chain</h2>
            <ol>
            <li>Merge exhibits — <a href="/guides/merge-pdf-court-filing">court merge guide</a></li>
            <li>OCR if search required</li>
            <li>Redact third-party PII</li>
            <li>Compress for portal cap — <a href="/guides/compress-pdf-lawyers">compress for lawyers</a></li>
            <li>Encrypt for client email — password separate channel</li>
            </ol>
            <h2>Watermark for drafts</h2>
            <p>DRAFT on settlement term sheet — partner review — remove watermark on execution version — sign with <a href="/pdf/signtext">Sign PDF</a> — final encrypt to client.</p>
            <h2>Vendor due diligence</h2>
            <p>Browser PDF tools and privilege — review retention — <a href="/guides/pdf-tool-security-comparison">security comparison</a> · Remote associates: <a href="/guides/secure-pdf-remote-work">remote work guide</a>.</p>
            """,
    "redact-pdf-gdpr": """
            <h2>GDPR and document disclosure</h2>
            <p>Data subject access requests (DSAR), third-party data in contracts, and employee records often require <strong>redacting other people's personal data</strong> before PDF delivery — Art. 15 access is not a licence to expose colleagues' salaries.</p>
            <h2>Redaction workflow</h2>
            <ol>
            <li>Identify lawful basis and scope — DPO sign-off</li>
            <li>Export source PDF — duplicate — never redact sole master</li>
            <li>Mark all third-party PII in <a href="/pdf-redaction">PDF Redaction</a></li>
            <li>Export production copy — verification pass</li>
            <li>Log: date, approver, Bates or page refs, delivery method</li>
            <li>Retain log per retention schedule — not necessarily redacted file forever</li>
            </ol>
            <h2>Fake redaction = personal data breach</h2>
            <p>ICO and EU DPAs sanction recoverable black boxes — see <a href="/guides/pdf-redaction-vs-black-box">redaction vs black box</a> · Requirements: <a href="/guides/gdpr-pdf-redaction">GDPR redaction requirements</a>.</p>
            <h2>Encryption after redaction</h2>
            <p>Encrypt DSAR response PDF — password via separate channel — portal preferred — <a href="/guides/password-protect-before-email">encrypt before email</a>. Minimisation: do not attach unrelated annexes.</p>
            """,
    "secure-pdf-remote-work": """
            <h2>Remote work PDF risks</h2>
            <ul>
            <li>Personal laptop Downloads folder — client PDF overnight</li>
            <li>Shared household Wi-Fi — unencrypted email attachment sniffing on compromised router</li>
            <li>Shadow IT — random "free PDF" sites with unknown retention</li>
            <li>Screen share leak — DRAFT watermark missing during Zoom review</li>
            </ul>
            <h2>Baseline controls</h2>
            <ol>
            <li>Approved tool list — RatPDF with <a href="/home/security">documented retention</a></li>
            <li>Encrypt before Slack/Teams upload — <a href="/pdf/password">Protect PDF</a></li>
            <li>DRAFT watermark on any external screen share — <a href="/guides/watermark-pdf-draft">watermark draft guide</a></li>
            <li>VPN for firm network drives — do not sync privilege docs to personal cloud</li>
            <li>Clear Downloads after session — FileVault on Mac, BitLocker on Windows</li>
            </ol>
            <h2>BYOD policy</h2>
            <p>If personal devices access client PDFs — MDM container or ban local save — browser-only workflow reduces persistence — compare <a href="/guides/browser-vs-desktop-pdf-tools">browser vs desktop</a>.</p>
            <h2>Incident response</h2>
            <p>Wrong file uploaded to public converter — assume retention until vendor confirms purge — notify DPO per GDPR — rotate credentials if encrypted payroll PDF exposed — document ticket.</p>
            """,
    "share-confidential-pdf": """
            <h2>Layers of protection</h2>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>Control</th><th>Stops</th><th>Does not stop</th></tr></thead>
            <tbody>
            <tr><td>CONFIDENTIAL watermark</td><td>Casual resharing confusion</td><td>Determined copy</td></tr>
            <tr><td>Password encryption</td><td>Open without passphrase</td><td>Screen photo after open</td></tr>
            <tr><td>Redaction</td><td>Disclosed secrets in body</td><td>Metadata author field</td></tr>
            </tbody></table></div>
            <h2>Recommended external send</h2>
            <ol>
            <li>Redact if third-party PII present</li>
            <li><a href="/pdf/watermark">Watermark</a> CONFIDENTIAL if draft or sensitive status</li>
            <li><a href="/pdf/password">Encrypt</a> with unique passphrase</li>
            <li>Email file — password via phone/SMS</li>
            <li>Prefer client portal over attachment when available</li>
            </ol>
            <h2>Filename hygiene</h2>
            <p>ClientName_DocumentType_2026-06.pdf — not Confidential_Final_v3_REAL.pdf — subject lines must not name deal codenames — <a href="/guides/pdf-email-attachment-checklist">email checklist</a>.</p>
            <h2>Internal vs external</h2>
            <p>Intranet wiki may need only watermark — customer pack needs encrypt — hub: <a href="/guides/how-to-protect-pdf-before-sending">protect before sending</a>.</p>
            """,
    "sign-pdf-without-docusign": """
            <h2>DocuSign vs browser sign</h2>
            <p><strong>DocuSign/Adobe Sign:</strong> audit trail, multi-party routing, qualified signatures in enterprise tiers — per-envelope cost. <strong>RatPDF Sign PDF:</strong> typed or drawn signature on line — free tier — suitable for many B2B approvals and internal sign-offs.</p>
            <h2>When browser sign is enough</h2>
            <ul>
            <li>Vendor NDAs and SOW under $50k</li>
            <li>Internal policy acknowledgements</li>
            <li>Contractor statements of work</li>
            <li>Counterparty already has relationship — not statutory deed</li>
            </ul>
            <h2>When you need QES or wet ink</h2>
            <p>EU eIDAS qualified signatures, property transfers, some government forms — consult <a href="/guides/sign-pdf-legally">sign PDF legally</a> — not replaceable by typed signature alone.</p>
            <h2>Workflow</h2>
            <ol>
            <li>Final PDF — no DRAFT watermark on execution copy</li>
            <li><a href="/pdf/signtext">Sign PDF</a> — place block on signature line</li>
            <li>Download — email to counterparty — they sign their copy or return countersigned</li>
            <li>Optional: <a href="/pdf/password">encrypt</a> before email</li>
            </ol>
            <p>Compare: <a href="/compare/docusign-alternative">DocuSign alternative</a> · How-to: <a href="/guides/how-to-sign-a-pdf">sign a PDF</a> · <a href="/guides/how-to-add-signature-pdf-free">add signature free</a>.</p>
            """,
    "watermark-pdf-draft": """
            <h2>When to watermark DRAFT</h2>
            <p>Investor previews, pilot customers, board circulation before vote, RFP responses in progress — diagonal DRAFT reduces mistaken reliance on non-final terms.</p>
            <h2>How to apply</h2>
            <ol>
            <li>Upload PDF to <a href="/pdf/watermark">Watermark PDF</a></li>
            <li>Enter DRAFT or custom status text</li>
            <li>Preview page 1 — ensure signature blocks still readable</li>
            <li>Download — distribute for review only</li>
            </ol>
            <h2>Watermark is not encryption</h2>
            <p>Recipient can copy text and forward file — for sensitive drafts add <a href="/pdf/password">password</a> — comparison: <a href="/guides/watermark-vs-password-pdf">watermark vs password</a>.</p>
            <h2>Remove on final</h2>
            <p>Re-export from source Word/InDesign without watermark for execution version — do not rely on recipient ignoring DRAFT mark — sign with <a href="/pdf/signtext">Sign PDF</a> on clean final.</p>
            <h2>Pair with metadata clean</h2>
            <p>Strip author metadata on external DRAFT — <a href="/guides/pdf-metadata-remove">metadata remove</a> — partner name in Properties panel leaks deal identity.</p>
            """,
}

W31_GLOSSARY_DEEP = {
    "glossary-color-profile": """
            <h2>Definition</h2>
            <p>A <strong>color profile</strong> (ICC profile) describes how RGB or CMYK values map to real-world color. PDFs embed profiles so displays and printers interpret blues and skin tones consistently.</p>
            <h2>Common profiles</h2>
            <ul>
            <li><strong>sRGB:</strong> screen and office inkjet default</li>
            <li><strong>ISO Coated v2 (FOGRA39):</strong> European sheetfed offset</li>
            <li><strong>US Web Coated SWOP:</strong> US commercial print</li>
            </ul>
            <h2>Symptoms of mismatch</h2>
            <p>Neon on screen, muddy in print — missing or wrong output intent — PDF/X rejects file — fix in InDesign export not in compress — <a href="/guides/glossary-pdf-x">PDF/X glossary</a> · <a href="/guides/glossary-cmyk">CMYK</a>.</p>
            <h2>PDF tools</h2>
            <p>Compress does not fix profile — convert RGB marketing PDF to CMYK in design app before print handoff — <a href="/pdf/compress">Compress PDF</a> only after colour-correct export.</p>
            """,
    "glossary-composite-font": """
            <h2>Definition</h2>
            <p><strong>Composite font</strong> bundles multiple CID-keyed subfonts for CJK scripts — one logical font resource with glyph collections per language component — paired with <a href="/guides/glossary-cmap">CMap</a> for Unicode mapping.</p>
            <h2>vs simple font</h2>
            <p>Latin PDFs use single-byte TrueType — composite handles thousands of kanji without embedding full Unicode plane per weight.</p>
            <h2>Troubleshooting</h2>
            <ul>
            <li>Copy-paste tofu boxes — missing CMap — re-export from source</li>
            <li>Search misses Japanese names — encoding not ToUnicode — <a href="/pdf/ocrpdf">OCR PDF</a> fallback</li>
            <li>Screen reader silence — needs tagged PDF remediation</li>
            </ul>
            <p>Related: <a href="/guides/glossary-cid-font">CID font</a> · <a href="/guides/glossary-identity-h">Identity-H</a> · <a href="/guides/glossary-font-embedding">font embedding</a>.</p>
            """,
    "glossary-credit-note": """
            <h2>Definition</h2>
            <p>A <strong>credit note</strong> (credit memo) is a commercial document reducing amount owed — issued after invoice — partial return, pricing error, or goodwill discount — exported as PDF for buyer AP and tax audit.</p>
            <h2>On PDF invoices</h2>
            <ul>
            <li>References original invoice number and date</li>
            <li>Negative line amounts or explicit credit total</li>
            <li>GST/VAT lines reversed where applicable — India: <a href="/guides/glossary-cgst">CGST</a> / <a href="/guides/glossary-igst">IGST</a></li>
            </ul>
            <h2>Workflow</h2>
            <p>Issue from accounting system → PDF → email to buyer → match in ERP — pair with <a href="/guides/glossary-debit-note">debit note</a> when supplier increases charge — create: <a href="/invoice/create">Create Invoice</a>.</p>
            """,
    "glossary-crop-box": """
            <h2>Definition</h2>
            <p>The <strong>crop box</strong> defines visible page boundaries in viewers — what you see when opening PDF — may be smaller than physical media box after trim.</p>
            <h2>PDF box family</h2>
            <ul>
            <li><strong>Media box:</strong> full physical page</li>
            <li><strong>Crop box:</strong> default view clip</li>
            <li><strong>Bleed box:</strong> print bleed extent — <a href="/guides/glossary-bleed-box">bleed box</a></li>
            <li><strong>Trim box:</strong> finished trim size</li>
            </ul>
            <h2>Practical issues</h2>
            <p>Footer clipped in viewer — crop box set wrong in export — white margins on print — crop box smaller than trim — fix in source layout app — <a href="/pdf/crop">Crop PDF</a> for quick margin trim on scans only.</p>
            <p>Related: <a href="/guides/glossary-media-box">media box</a> · <a href="/guides/glossary-art-box">art box</a>.</p>
            """,
    "glossary-cross-reference-table": """
            <h2>Definition</h2>
            <p>The <strong>cross-reference table (xref)</strong> indexes byte offsets of PDF objects — parser jumps to catalog, pages, fonts without scanning entire file — critical for fast open and integrity.</p>
            <h2>Linearized PDF</h2>
            <p>Web-optimized PDFs add hint table for first-page fast view — xref still required for full load — <a href="/guides/glossary-linearized">linearized PDF</a>.</p>
            <h2>Corruption symptoms</h2>
            <ul>
            <li>"Cannot open" after incomplete download</li>
            <li>Email gateway truncated attachment</li>
            <li>Manual hex edit broke offsets</li>
            </ul>
            <p>Repair rebuilds xref — <a href="/pdf/repair">Repair PDF</a> — always re-download source before repair — backup master — structure: <a href="/guides/glossary-pdf">PDF glossary</a>.</p>
            """,
    "glossary-debit-note": """
            <h2>Definition</h2>
            <p>A <strong>debit note</strong> notifies buyer of additional charges — freight surcharge, price adjustment, missing line on original invoice — formalises increased AP liability — sent as PDF to accounts payable.</p>
            <h2>vs credit note</h2>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>Document</th><th>Effect on balance</th></tr></thead>
            <tbody>
            <tr><td>Debit note</td><td>Increases amount buyer owes</td></tr>
            <tr><td>Credit note</td><td>Decreases amount buyer owes</td></tr>
            </tbody></table></div>
            <h2>PDF fields</h2>
            <p>PO reference, original invoice link, tax lines, authorised signatory — GST registered firms need sequential debit note numbering per statute — export: <a href="/invoice/create">Create Invoice</a> · Related: <a href="/guides/glossary-credit-note">credit note</a> · <a href="/guides/glossary-gst-invoice">GST invoice</a>.</p>
            """,
}

W31_DEEP = {**W31_SECURITY_DEEP, **W31_GLOSSARY_DEEP}

W31_SECURITY_CLUSTER = """
            <h2>PDF security authority cluster — Wave 31</h2>
            <ul>
            <li><a href="/guides/password-protect-before-email">Password protect before email</a></li>
            <li><a href="/guides/password-protect-pdf-mac">Password protect on Mac</a></li>
            <li><a href="/guides/pdf-encryption-aes-explained">PDF encryption AES explained</a></li>
            <li><a href="/guides/pdf-password-best-practices">PDF password best practices</a></li>
            <li><a href="/guides/pdf-redaction-vs-black-box">Redaction vs black box</a></li>
            <li><a href="/guides/pdf-security-lawyers">PDF security for lawyers</a></li>
            <li><a href="/guides/redact-pdf-gdpr">Redact PDF GDPR</a></li>
            <li><a href="/guides/secure-pdf-remote-work">Secure PDF remote work</a></li>
            <li><a href="/guides/share-confidential-pdf">Share confidential PDF</a></li>
            <li><a href="/guides/sign-pdf-without-docusign">Sign without DocuSign</a></li>
            <li><a href="/guides/watermark-pdf-draft">Watermark PDF draft</a></li>
            </ul>
            <p>How-to batch: <a href="/guides/how-to-password-protect-a-pdf">password how-to</a> · Hubs: <a href="/guides/secure-pdf-workflow">secure workflow</a> · <a href="/guides/pdf-security-compliance-guide">compliance</a></p>
            """

W31_GLOSSARY_CLUSTER = """
            <h2>Glossary batch 8</h2>
            <ul>
            <li><a href="/guides/glossary-color-profile">Color profile</a></li>
            <li><a href="/guides/glossary-composite-font">Composite font</a></li>
            <li><a href="/guides/glossary-credit-note">Credit note</a></li>
            <li><a href="/guides/glossary-crop-box">Crop box</a></li>
            <li><a href="/guides/glossary-cross-reference-table">Cross-reference table</a></li>
            <li><a href="/guides/glossary-debit-note">Debit note</a></li>
            </ul>
            <p>Prior: <a href="/guides/glossary-cmap">CMap</a> · <a href="/guides/glossary-cgst">CGST</a> · Hub: <a href="/guides/pdf-glossary-hub">PDF glossary hub</a></p>
            """

W31_SECURITY_TOPUP = """
            <h2>Security incident checklist</h2>
            <ol>
            <li>Identify if overlay redaction or weak password caused exposure</li>
            <li>Notify DPO / counsel per policy — GDPR 72-hour clock if personal data</li>
            <li>Revoke shared links — rotate passphrases on recurring sends</li>
            <li>Vendor purge ticket if wrong cloud tool used</li>
            <li>Retrain on <a href="/guides/pdf-redaction-vs-black-box">true redaction</a> vs black box</li>
            </ol>
            <h2>Law firm remote pack</h2>
            <p>Encrypt client PDF before Teams upload — DRAFT watermark on screen share — approved browser tools only — <a href="/guides/pdf-security-lawyers">lawyer security guide</a>.</p>
            """

W31_GLOSSARY_TOPUP = """
            <h2>Glossary study tips</h2>
            <ul>
            <li>Print terms: crop box vs bleed box vs media box — draw diagram once</li>
            <li>Invoice terms: credit note reduces AR — debit note increases</li>
            <li>CJK issues: composite font + CMap + OCR fallback chain</li>
            <li>Colour: profile mismatch is export fix — not compress fix</li>
            </ul>
            """

W31_CLOSING = """
            <h2>Related guides</h2>
            <p>Wave 31 completes the score-63 PDF security UPGRADE batch — encryption, redaction, remote work, and confidential sharing — plus glossary batch 8 for print, CJK, and invoice terminology.</p>
            <p>Hub: <a href="/guides/secure-pdf-workflow">secure PDF workflow</a> · <a href="/guides/pdf-glossary-hub">glossary hub</a> · Compare: <a href="/guides/pdf-tool-security-comparison">tool security</a></p>
            """
