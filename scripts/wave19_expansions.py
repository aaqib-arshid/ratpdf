"""Wave 19 — Industry compress upgrades + glossary batch 3 + scanned-table mistakes."""

W19_SLUGS = [
    "compress-pdf-construction",
    "compress-pdf-ecommerce",
    "compress-pdf-freelancers",
    "compress-pdf-government",
    "compress-pdf-healthcare-admin",
    "compress-pdf-hr",
    "compress-pdf-marketing-agencies",
    "compress-pdf-nonprofits",
    "compress-pdf-real-estate",
    "compress-pdf-recruiters",
    "compress-pdf-students",
    "compress-pdf-teachers",
    "mistakes-pdf-to-word-for-scanned-tables",
    "glossary-128-bit-encryption",
    "glossary-256-bit-aes-encryption",
    "glossary-accessibility",
    "glossary-alt-text",
]

INDUSTRY_SLUGS = {
    "compress-pdf-construction",
    "compress-pdf-ecommerce",
    "compress-pdf-freelancers",
    "compress-pdf-government",
    "compress-pdf-healthcare-admin",
    "compress-pdf-hr",
    "compress-pdf-marketing-agencies",
    "compress-pdf-nonprofits",
    "compress-pdf-real-estate",
    "compress-pdf-recruiters",
    "compress-pdf-students",
    "compress-pdf-teachers",
}

GLOSSARY_SLUGS = {
    "glossary-128-bit-encryption",
    "glossary-256-bit-aes-encryption",
    "glossary-accessibility",
    "glossary-alt-text",
}

W19_DATA = {
    "compress-pdf-construction": {
        "title": "Compress PDF for Construction — Permits, RFQs &amp; Site Photo Logs (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/compress-pdf-guide",
        "pillar_label": "compress PDF guide",
        "example": "GC shrinks 45 MB permit submittal with site photos to 8 MB for city portal upload",
    },
    "compress-pdf-ecommerce": {
        "title": "Compress PDF for Ecommerce — Catalogs, Invoices &amp; Marketplace Uploads (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/compress-pdf-guide",
        "pillar_label": "compress PDF guide",
        "example": "Seller compresses 22 MB supplier catalog PDF before emailing 3PL onboarding team",
    },
    "compress-pdf-freelancers": {
        "title": "Compress PDF for Freelancers — Proposals, Contracts &amp; Client Delivery (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/compress-pdf-guide",
        "pillar_label": "compress PDF guide",
        "example": "Designer sends 6 MB portfolio PDF to client Gmail after compressing from 14 MB",
    },
    "compress-pdf-government": {
        "title": "Compress PDF for Government Forms — Portal Upload Limits (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/compress-pdf-guide",
        "pillar_label": "compress PDF guide",
        "example": "Citizen compresses passport scan and address proof for 2 MB government slot",
    },
    "compress-pdf-healthcare-admin": {
        "title": "Compress PDF for Healthcare Administrators — Portals &amp; Prior Auth (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/compress-pdf-guide",
        "pillar_label": "compress PDF guide",
        "example": "Admin compresses prior-auth bundle with member ID scans for payer portal",
    },
    "compress-pdf-hr": {
        "title": "Compress PDF for HR — Offer Letters, Policies &amp; Onboarding (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/compress-pdf-guide",
        "pillar_label": "compress PDF guide",
        "example": "HR shrinks merged onboarding pack from 28 MB to 12 MB for new hire email",
    },
    "compress-pdf-marketing-agencies": {
        "title": "Compress PDF for Marketing Agencies — Decks, Case Studies &amp; Client Delivery (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/compress-pdf-guide",
        "pillar_label": "compress PDF guide",
        "example": "Agency compresses full-bleed pitch deck PDF before client inbox delivery",
    },
    "compress-pdf-nonprofits": {
        "title": "Compress PDF for Nonprofits — Grants, Board Packs &amp; Donor Reports (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/compress-pdf-guide",
        "pillar_label": "compress PDF guide",
        "example": "Grant writer fits impact report PDF under funder portal 5 MB cap",
    },
    "compress-pdf-real-estate": {
        "title": "Compress PDF for Real Estate — Listings, Disclosures &amp; Leases (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/compress-pdf-guide",
        "pillar_label": "compress PDF guide",
        "example": "Agent compresses photo-heavy listing brochure before MLS email blast",
    },
    "compress-pdf-recruiters": {
        "title": "Compress PDF for Recruiters — Candidate Packs &amp; ATS Uploads (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/compress-pdf-for-job-application",
        "pillar_label": "job application compress guide",
        "example": "Recruiter compresses 5-candidate PDF bundle for hiring manager review",
    },
    "compress-pdf-students": {
        "title": "Compress PDF for Students — LMS &amp; Submission Upload Limits (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/compress-pdf-for-lms",
        "pillar_label": "LMS compress guide",
        "example": "Student shrinks merged reading pack from 40 MB to 15 MB for Canvas upload",
    },
    "compress-pdf-teachers": {
        "title": "Compress PDF for Teachers — LMS Handouts &amp; Parent Email (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/compress-pdf-for-lms",
        "pillar_label": "LMS compress guide",
        "example": "Teacher compresses semester worksheet scan pack for Google Classroom",
    },
    "mistakes-pdf-to-word-for-scanned-tables": {
        "title": "PDF to Word for Scanned Tables — Common Mistakes to Avoid (2026)",
        "tool": "/pdf/pdftodoc",
        "label": "PDF to Word",
        "pillar": "/guides/pdf-to-word",
        "pillar_label": "PDF to Word guide",
        "example": "Analyst learns scanned bank statement table needs Excel path not Word after failed convert",
    },
    "glossary-128-bit-encryption": {
        "title": "What Is 128-Bit PDF Encryption? — RC4 &amp; Legacy Security Explained (2026)",
        "tool": "/pdf/password",
        "label": "Protect PDF",
        "pillar": "/guides/password-protect-pdf",
        "pillar_label": "password protect PDF guide",
        "example": "IT audit flags legacy 128-bit encrypted PDFs in vendor archive — migration plan needed",
    },
    "glossary-256-bit-aes-encryption": {
        "title": "What Is 256-Bit AES PDF Encryption? — Modern PDF Security (2026)",
        "tool": "/pdf/password",
        "label": "Protect PDF",
        "pillar": "/guides/password-protect-pdf",
        "pillar_label": "password protect PDF guide",
        "example": "Legal sets AES-256 owner password on contract PDF before external share",
    },
    "glossary-accessibility": {
        "title": "What Is PDF Accessibility? — Tags, OCR &amp; WCAG Explained (2026)",
        "tool": "/pdf/ocrpdf",
        "label": "OCR PDF",
        "pillar": "/guides/pdf-ua-accessibility",
        "pillar_label": "PDF/UA accessibility guide",
        "example": "University checks whether course PDF is accessible or scan-only before publishing",
    },
    "glossary-alt-text": {
        "title": "What Is Alt Text in PDF? — Figure Descriptions for Screen Readers (2026)",
        "tool": "/pdf/pdfmetadata",
        "label": "PDF Metadata",
        "pillar": "/guides/pdf-ua-accessibility",
        "pillar_label": "PDF/UA accessibility guide",
        "example": "Comms team adds alt text to chart figures in annual report PDF for WCAG audit",
    },
}

W19_INDUSTRY_DEEP = {
    "compress-pdf-construction": """
            <h2>Construction PDF types that blow size caps</h2>
            <ul>
            <li>Site photo logs — phone cameras at full resolution</li>
            <li>Stamped drawing PDFs from CAD export</li>
            <li>RFQ packages merging specs + insurance certs</li>
            <li>Permit submittals with material data sheets</li>
            </ul>
            <h2>Portal workflow</h2>
            <ol>
            <li>Merge submittal in checklist order — <a href="/guides/merge-pdf-online">merge PDF</a></li>
            <li>Check municipal portal cap — often 10–25 MB</li>
            <li>Compress with Recommended — Less on stamped sheets with fine dimensions</li>
            <li>Verify stamp and scale bar legibility at 150% zoom</li>
            <li>Archive full-res in project drive — upload compressed copy only</li>
            </ol>
            <h2>Photo-heavy vs CAD vector</h2>
            <p>Photo logs compress 60–80%. Vector CAD sheets may shrink only 10% — if still over cap, split exhibits or reduce embedded raster underlays in source CAD.</p>
            <h2>Common mistakes</h2>
            <p><strong>Extreme on blueprints:</strong> dimension text blurs. <strong>Double compress:</strong> field photo PDF compressed twice before merge. <strong>Wrong file to inspector:</strong> compressed copy missing appendix — verify page count.</p>
            """,
    "compress-pdf-ecommerce": """
            <h2>Ecommerce PDF workflows</h2>
            <ul>
            <li>Supplier spec sheets and compliance certs for marketplace onboarding</li>
            <li>Wholesale catalog PDFs for B2B buyers</li>
            <li>Packing slip + invoice bundles for 3PL email</li>
            <li>Return merchandise authorization scans</li>
            </ul>
            <h2>Catalog compression</h2>
            <p>Full-bleed product photography dominates bytes — Recommended compression usually sufficient. For print-ready catalog masters, compress a <strong>web/email copy</strong> only — keep CMYK master uncompressed.</p>
            <h2>Marketplace limits</h2>
            <p>Amazon Seller Central, Shopify apps, and freight forwarders often cap 5–10 MB — compress before ticket attachment. Pair with <a href="/invoice/create">Create Invoice</a> for PDF invoices under separate size rules.</p>
            """,
    "compress-pdf-freelancers": """
            <h2>Freelancer delivery checklist</h2>
            <ol>
            <li>Export proposal from Google Docs or Canva as PDF</li>
            <li>Check size — Gmail safe target under 20 MB</li>
            <li>Compress with Recommended if over 5 MB</li>
            <li>Verify portfolio images still sharp</li>
            <li>Filename: <code>ClientName_Proposal_2026-06.pdf</code></li>
            </ol>
            <h2>Contract and SOW packs</h2>
            <p>Merge SOW + insurance cert + W-9 with <a href="/guides/merge-pdf-online">merge PDF</a> then one compress pass. Password-protect confidential drafts — <a href="/guides/password-protect-pdf">protect PDF guide</a>.</p>
            <h2>WhatsApp and mobile clients</h2>
            <p>Compress for faster mobile open — <a href="/guides/compress-pdf-for-whatsapp">WhatsApp compress guide</a>. Invoice PDFs: <a href="/invoice/create">Create Invoice</a>.</p>
            """,
    "compress-pdf-government": """
            <h2>Government portal reality</h2>
            <p>India Passport Seva, UIDAI, GST, Income Tax, USCIS, and HMRC each use different per-slot caps — often <strong>500 KB–5 MB</strong>. One compressed file never fits all portals — maintain per-portal exports.</p>
            <h2>Scan settings</h2>
            <p>200–300 DPI grayscale for text proofs. Colour only when stamp colour is legally required. Flat phone photos — no curved page shadow.</p>
            <h2>Regional guides</h2>
            <p><a href="/guides/compress-pdf-uidai">UIDAI</a> · <a href="/guides/compress-pdf-passport-india">Passport Seva</a> · <a href="/guides/compress-pdf-gst-portal">GST portal</a> · <a href="/guides/compress-pdf-usajobs">USAJOBS</a> · <a href="/guides/compress-pdf-ukvi">UKVI</a>.</p>
            """,
    "compress-pdf-healthcare-admin": """
            <h2>Healthcare admin use cases</h2>
            <ul>
            <li>Prior authorization clinical notes + imaging reports</li>
            <li>Credentialing packet PDFs for payer enrollment</li>
            <li>Member ID and insurance card scans</li>
            <li>Appeals documentation bundles</li>
            </ul>
            <h2>PHI handling</h2>
            <p>Compress copies for portal upload — keep access-controlled originals in EHR. RatPDF auto-deletes after processing — verify BAA if required — see <a href="/guides/hipaa-pdf-handling">HIPAA PDF handling</a>.</p>
            <h2>Member ID legibility</h2>
            <p>Use Less compression on ID card scans — verify policy number digits after compress. OCR if payer portal requires searchable PDF.</p>
            """,
    "compress-pdf-hr": """
            <h2>HR document types</h2>
            <ul>
            <li>Offer letter + benefits summary + I-9 instructions</li>
            <li>Employee handbook PDFs (100+ pages)</li>
            <li>Policy acknowledgment forms</li>
            <li>Exit documentation and COBRA notices</li>
            </ul>
            <h2>Onboarding email workflow</h2>
            <p>Compress each PDF separately if total attachment exceeds Exchange limit — or merge handbook sections then compress once. Workday uploads: <a href="/guides/compress-pdf-for-workday">Workday compress guide</a>.</p>
            <h2>ATS and text layer</h2>
            <p>Offer letters exported from Word stay text-selectable after Recommended compress — verify for internal search archives.</p>
            """,
    "compress-pdf-marketing-agencies": """
            <h2>Agency PDF pain points</h2>
            <p>Pitch decks with full-bleed photography, case study PDFs from InDesign, and campaign recap exports often exceed 20 MB — client inboxes and WeTransfer limits block delivery.</p>
            <h2>Creative vs delivery copy</h2>
            <p>Keep uncompressed master in DAM — generate <strong>client delivery PDF</strong> with Recommended compression. Presentations going to print shop: do not compress — send original.</p>
            <h2>Version control</h2>
            <p>Filename: <code>BrandX_Q3_Campaign_Recap_v3_compressed.pdf</code> — avoid client opening v2 while you send v3.</p>
            """,
    "compress-pdf-nonprofits": """
            <h2>Nonprofit PDF scenarios</h2>
            <ul>
            <li>Grant applications with budget appendices and 990 excerpts</li>
            <li>Board packs — financials + minutes + committee reports</li>
            <li>Donor impact reports with photography</li>
            <li>Volunteer onboarding forms</li>
            </ul>
            <h2>Funder portal caps</h2>
            <p>Foundations often cap uploads at 2–10 MB per attachment — read RFP instructions literally. Merge only when allowed — many grants want separate budget PDF.</p>
            <h2>Board email</h2>
            <p>Merge board materials in order — compress after merge — password-protect if confidential — <a href="/guides/merge-pdf-accountants">similar to accountant board pack workflow</a>.</p>
            """,
    "compress-pdf-real-estate": """
            <h2>Real estate PDF types</h2>
            <ul>
            <li>Listing brochures with property photography</li>
            <li>Disclosure packages (10–80 pages)</li>
            <li>Lease and addendum scans</li>
            <li>HOA document bundles for buyers</li>
            </ul>
            <h2>MLS and email delivery</h2>
            <p>Photo-heavy brochures compress 50–70% at Recommended — verify hero image quality. Disclosure packs: merge in disclosure order, compress once, verify page count matches checklist.</p>
            <h2>Signatures and initials</h2>
            <p>Signed disclosure scans — use Less not Extreme — initials on page margins must stay readable for compliance file.</p>
            """,
    "compress-pdf-recruiters": """
            <h2>Recruiter workflows</h2>
            <ul>
            <li>Candidate resume + cover letter + cert scans in one pack</li>
            <li>Redacted resume for client submittal</li>
            <li>Background check document bundles</li>
            <li>Bulk submittal to hiring manager email</li>
            </ul>
            <h2>ATS-safe compression</h2>
            <p>Digital resume PDFs must stay text-selectable — Recommended not Extreme. Verify after compress on Indeed/Workday test upload — <a href="/guides/compress-pdf-for-indeed">Indeed guide</a> · <a href="/guides/compress-pdf-for-workday">Workday</a>.</p>
            <h2>Redaction before send</h2>
            <p>Remove candidate phone/email from client copy — <a href="/guides/pdf-redaction">redaction guide</a> — then compress — not the reverse.</p>
            """,
    "compress-pdf-students": """
            <h2>Student compression scenarios</h2>
            <ul>
            <li>Merged weekly reading PDFs for offline study</li>
            <li>Homework scan submissions on Canvas/Moodle</li>
            <li>Portfolio PDFs for internship applications</li>
            <li>Group project combined reports</li>
            </ul>
            <h2>LMS limits</h2>
            <p>Canvas often allows 100 MB but professors set lower — compress to under 10 MB for safety — <a href="/guides/compress-pdf-for-lms">LMS compress guide</a>. Merge readings: <a href="/guides/merge-pdf-students">merge for students</a>.</p>
            <h2>Scan quality vs size</h2>
            <p>Handwritten homework — Less compression preserves pencil marks. Typed essays exported as PDF — moderate shrink only.</p>
            """,
    "compress-pdf-teachers": """
            <h2>Teacher PDF workflows</h2>
            <ul>
            <li>Worksheet scan packs for Google Classroom</li>
            <li>Semester syllabus + policy PDFs</li>
            <li>Parent newsletter PDFs with photos</li>
            <li>Substitute teacher emergency binders</li>
            </ul>
            <h2>Classroom distribution</h2>
            <p>Compress before upload to LMS — students on mobile data thank you. OCR scanned worksheets if students need search — <a href="/guides/ocr-lecture-notes-students">OCR lecture notes</a>.</p>
            <h2>Copyright note</h2>
            <p>Compress only materials you have rights to distribute — merged textbook chapters may violate copyright even if compressed.</p>
            """,
}

W19_MISTAKES_DEEP = """
            <h2>Mistake 1: Converting scan without OCR</h2>
            <p>Scanned table PDFs are images — PDF to Word embeds each page as a picture grid. You cannot edit cells. Fix: <a href="/pdf/ocrpdf">OCR PDF</a> first, then convert — or use <a href="/pdf/pdftoexcel">PDF to Excel</a> on digital tables.</p>
            <h2>Mistake 2: Expecting perfect table reconstruction</h2>
            <p>Even after OCR, merged cells and nested headers break in Word. For numeric data, Excel extraction beats Word. For legal tables, manual cleanup in Word may still take hours.</p>
            <h2>Mistake 3: Compressing before OCR</h2>
            <p>Aggressive compression on fine-print scans before OCR increases character errors — OCR first on full-quality scan, compress only the final deliverable PDF.</p>
            <h2>Mistake 4: Fighting layout instead of retyping</h2>
            <p>Small 5×5 tables — retyping in Excel is faster than fixing Word conversion artifacts. Decision tree: digital PDF with real tables → Word or Excel. Scan → OCR → Excel if numeric.</p>
            <h2>Decision matrix</h2>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>Source</th><th>Best tool</th></tr></thead>
            <tbody>
            <tr><td>Digital PDF table</td><td><a href="/pdf/pdftoexcel">PDF to Excel</a> or <a href="/pdf/pdftodoc">PDF to Word</a></td></tr>
            <tr><td>Scanned table</td><td>OCR → Excel</td></tr>
            <tr><td>Plain text need</td><td><a href="/pdf/pdftotext">PDF to Text</a></td></tr>
            </tbody></table></div>
            <p>Related: <a href="/guides/scanned-pdf-to-word">scanned PDF to Word</a> · <a href="/guides/pdf-to-word-keep-formatting">keep formatting</a> · Compare: <a href="/compare/adobe-acrobat-alternative">Adobe alternative</a>.</p>
            """

W19_GLOSSARY_DEEP = {
    "glossary-128-bit-encryption": """
            <h2>Definition</h2>
            <p><strong>128-bit encryption</strong> in PDF historically referred to RC4-based security (PDF 1.4–1.6 era). It is weaker than modern AES-256 and should not be used for new confidential documents.</p>
            <p>Security hub: <a href="/guides/password-protect-pdf">password protect PDF guide</a> · Compare: <a href="/guides/pdf-tool-security-comparison">PDF tool security comparison</a>.</p>
            <h2>Legacy file migration</h2>
            <p>Unlock with known password → re-save with AES-256 in Acrobat or re-protect with RatPDF <a href="/pdf/password">Protect PDF</a> if policy allows browser workflow.</p>
            <h2>Compliance note</h2>
            <p>Many enterprise policies now require AES-256 minimum — audit archives for 128-bit PDFs during SOC2 or ISO reviews.</p>
            """,
    "glossary-256-bit-aes-encryption": """
            <h2>Definition</h2>
            <p><strong>AES-256 encryption</strong> is the current standard for PDF password protection — symmetric encryption with 256-bit keys defined in PDF 2.0 and ISO 32000 security handlers.</p>
            <h2>User vs owner password</h2>
            <ul>
            <li><strong>User (open) password</strong> — required to open file</li>
            <li><strong>Owner password</strong> — controls print/copy/edit permissions</li>
            </ul>
            <p>Term: <a href="/guides/glossary-owner-password">owner password glossary</a> · Tool: <a href="/pdf/password">Protect PDF</a>.</p>
            <h2>Limits</h2>
            <p>Password protection is not redaction — hidden text may still exist under black boxes. For true removal use <a href="/guides/pdf-redaction">PDF redaction</a>.</p>
            """,
    "glossary-accessibility": """
            <h2>Definition</h2>
            <p><strong>PDF accessibility</strong> means people with disabilities can perceive, navigate, and understand document content — via screen readers, keyboard navigation, reflow, and sufficient contrast.</p>
            <p>Standards: <a href="/guides/pdf-ua-accessibility">PDF/UA</a> · <a href="/guides/wcag-22-pdf">WCAG 2.2 PDF</a> · <a href="/guides/section-508-pdf">Section 508</a>.</p>
            <h2>OCR is not full accessibility</h2>
            <p>OCR adds searchable text but not tags, headings, or alt text — interim fix only. Full remediation requires tagged PDF structure.</p>
            <h2>RatPDF role</h2>
            <p><a href="/pdf/ocrpdf">OCR PDF</a> for scans · <a href="/pdf/pdftotext">PDF to Text</a> for alt-format export · Metadata via <a href="/pdf/pdfmetadata">PDF Metadata</a> — not full tag authoring.</p>
            """,
    "glossary-alt-text": """
            <h2>Definition</h2>
            <p><strong>Alt text (alternative text)</strong> in PDF is a text description attached to figures, charts, and images so screen readers convey meaning beyond "image on page 4."</p>
            <p>Workflow: <a href="/guides/pdf-ua-accessibility">PDF/UA guide</a> · Checklist: <a href="/guides/tagged-pdf-checklist">tagged PDF checklist</a>.</p>
            <h2>Good vs bad alt text</h2>
            <ul>
            <li><strong>Bad:</strong> "Chart" or "Image001.png"</li>
            <li><strong>Good:</strong> "Bar chart: Q1 revenue up 12% to $4.2M vs Q1 prior year $3.7M"</li>
            </ul>
            <h2>Decorative images</h2>
            <p>Mark purely decorative graphics as artifacts so screen readers skip them — requires tag editor in Acrobat or axesPDF — not available in basic browser tools.</p>
            """,
}

W19_INDUSTRY_CLUSTER = """
            <h2>Industry compress guides</h2>
            <ul>
            <li><a href="/guides/compress-pdf-construction">Construction</a></li>
            <li><a href="/guides/compress-pdf-freelancers">Freelancers</a></li>
            <li><a href="/guides/compress-pdf-hr">HR</a></li>
            <li><a href="/guides/compress-pdf-real-estate">Real estate</a></li>
            <li><a href="/guides/compress-pdf-healthcare-admin">Healthcare admin</a></li>
            <li><a href="/guides/small-business-pdf-workflow">Small business workflow</a></li>
            </ul>
            <p>Research: <a href="/research/pdf-compression-benchmark">compression benchmark</a> · Compare: <a href="/compare/smallpdf-alternative">Smallpdf alternative</a></p>
            """

W19_GLOSSARY_CLUSTER = """
            <h2>Related glossary terms</h2>
            <ul>
            <li><a href="/guides/glossary-256-bit-aes-encryption">256-bit AES encryption</a></li>
            <li><a href="/guides/glossary-owner-password">Owner password</a></li>
            <li><a href="/guides/glossary-accessibility">Accessibility</a></li>
            <li><a href="/guides/glossary-alt-text">Alt text</a></li>
            <li><a href="/guides/glossary-pdf-ua">PDF/UA</a></li>
            </ul>
            <p>Hub: <a href="/guides/pdf-tools">PDF tools</a> · Security: <a href="/guides/secure-pdf-workflow">secure PDF workflow</a></p>
            """

W19_DEEP = {**W19_INDUSTRY_DEEP, **W19_GLOSSARY_DEEP}
W19_DEEP["mistakes-pdf-to-word-for-scanned-tables"] = W19_MISTAKES_DEEP
