#!/usr/bin/env python3
"""Generate GuideBodiesWave3.cs — premium Compress + Compliance upgrades (no new URLs)."""
from pathlib import Path

from wave3_expansions import (
    COMPRESS_CLUSTER_LINKS,
    COMPRESS_LONG_TAIL,
    COMPRESS_MEGA,
    COMPRESS_PREMIUM,
    COMPRESS_UNIQUE,
    COMPRESS_UNIVERSAL,
    COMPRESS_1500_TOPUP,
    COMPRESS_SLUG_DEEP,
    COMPLIANCE_CLUSTER_LINKS,
    COMPLIANCE_MEGA,
    COMPLIANCE_PREMIUM,
    COMPLIANCE_TOOLS,
    COMPLIANCE_UNIQUE,
    COMPLIANCE_UNIVERSAL,
    COMPLIANCE_1500_TOPUP,
    COMPLIANCE_SLUG_DEEP,
    WAVE3_CLOSING,
    COMPRESS_FINAL_BOOST,
    COMPLIANCE_FINAL_BOOST,
    COMPLIANCE_CLOSING_EXTRA,
)

OUT = Path(__file__).resolve().parents[1] / "Content" / "GuideBodiesWave3.cs"

COMPRESS_SLUGS = [
    "compress-before-merge-pdf",
    "compress-pdf-cloud-storage",
    "compress-pdf-for-printing",
    "compress-pdf-with-images",
    "compress-pdf-without-quality-loss",
    "compress-pdf-common-app",
    "compress-pdf-digilocker",
    "compress-pdf-gst-portal",
    "compress-pdf-schengen-visa",
    "compress-pdf-insurance-claims",
    "compress-pdf-efiling",
    "compress-pdf-for-government-forms",
]

COMPLIANCE_SLUGS = [
    "gst-invoice-format-india",
    "e-invoicing-india-pdf",
    "pdf-redaction-permanent",
    "wcag-22-pdf",
    "gdpr-pdf-redaction",
]

SLUGS = COMPRESS_SLUGS + COMPLIANCE_SLUGS

COMPRESS_TITLES = {
    "compress-before-merge-pdf": "Compress PDF before or after merge — decision guide (2026)",
    "compress-pdf-cloud-storage": "Compress PDF for cloud storage — Drive, Dropbox &amp; OneDrive quota",
    "compress-pdf-for-printing": "Compress PDF for printing — quality vs file size",
    "compress-pdf-with-images": "Compress PDF with images — photos, scans &amp; brochures",
    "compress-pdf-without-quality-loss": "Compress PDF without losing quality — when Less is enough",
    "compress-pdf-common-app": "Compress PDF for Common App — college application upload limits",
    "compress-pdf-digilocker": "Compress PDF for DigiLocker — Aadhaar, PAN &amp; certificates",
    "compress-pdf-gst-portal": "Compress PDF for GST portal — registration &amp; annexure uploads",
    "compress-pdf-schengen-visa": "Compress PDF for Schengen visa — VFS upload size fix",
    "compress-pdf-insurance-claims": "Compress PDF for insurance claims — portal upload limits",
    "compress-pdf-efiling": "Compress PDF for e-filing — court &amp; portal size limits",
    "compress-pdf-for-government-forms": "Compress PDF for government forms — India e-governance uploads",
}

COMPLIANCE_TITLES = {
    "gst-invoice-format-india": "GST invoice format India (2026) — mandatory fields &amp; PDF template",
    "e-invoicing-india-pdf": "E-invoicing India PDF — IRN, QR code &amp; GST portal workflow",
    "pdf-redaction-permanent": "Permanent PDF redaction — remove text so it cannot be recovered",
    "wcag-22-pdf": "WCAG 2.2 PDF requirements — accessible documents checklist",
    "gdpr-pdf-redaction": "GDPR PDF redaction requirements — personal data in documents",
}

COMPRESS_SHOTS = {
    "compress-before-merge-pdf": "Merge queue with compress-after-merge workflow diagram",
    "compress-pdf-cloud-storage": "Drive quota before/after compressing PDF archive folder",
    "compress-pdf-for-printing": "Print shop email with compressed proof PDF attachment",
    "compress-pdf-with-images": "Brochure PDF file size drop after Recommended compression",
    "compress-pdf-without-quality-loss": "Signature stamp legibility at 150% zoom after Less compression",
    "compress-pdf-common-app": "Common App upload widget showing under-10 MB PDF accepted",
    "compress-pdf-digilocker": "DigiLocker certificate upload success after compress",
    "compress-pdf-gst-portal": "GST portal annexure slot with compressed board resolution PDF",
    "compress-pdf-schengen-visa": "VFS Schengen upload with merged financial pack under cap",
    "compress-pdf-insurance-claims": "Insurer claim portal with compressed photo evidence PDF",
    "compress-pdf-efiling": "Court e-filing exhibit list with compressed PDF sizes",
    "compress-pdf-for-government-forms": "Passport Seva upload slot with compressed Aadhaar proof",
}


def const_name(slug: str) -> str:
    return slug.replace("-", "_").title().replace("_", "")


def shot(caption: str) -> str:
    return (
        f'<figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small">'
        f'<figcaption><strong>Screenshot placeholder:</strong> {caption}</figcaption></figure>'
    )


def mid_cta(tool: str, label: str, text: str) -> str:
    return (
        f'<div class="rp-mid-cta alert alert-primary my-4"><strong>{text}</strong> '
        f'<a href="{tool}" class="alert-link fw-semibold">{label} →</a></div>'
    )


def end_cta(tool: str, label: str, extra: str = "") -> str:
    extra_html = f" · {extra}" if extra else ""
    return f'<p class="mt-4"><a href="{tool}" class="btn btn-primary">{label}</a>{extra_html}</p>'


def compress_supplement() -> str:
    return """
            <h2>Compression levels on RatPDF</h2>
            <p><strong>Less (Low):</strong> minimal image re-encoding — legal scans, signatures, stamps. <strong>Recommended (Medium):</strong> default for email and most portals. <strong>Extreme (High):</strong> last resort — verify footnotes and seals after.</p>

            <h2>When split beats compress</h2>
            <p>Already-optimised digital PDFs may not shrink enough — <a href="/guides/split-pdf">split PDF</a> or <a href="/guides/split-pdf-for-email">split for email</a> when portal allows multiple files.</p>

            <h2>Pre-upload checklist</h2>
            <ol>
            <li>Check portal cap with <a href="/pdf-size-checker">PDF size checker</a></li>
            <li>Rotate scans upright before compress</li>
            <li>One compression pass after final merge</li>
            <li>Keep uncompressed master until upload succeeds</li>
            <li>Verify text selects for ATS/legal docs</li>
            </ol>

            <h2>Email and messaging after compress</h2>
            <p>Gmail: <a href="/guides/compress-pdf-for-gmail">Gmail compress</a> · Outlook: <a href="/guides/compress-pdf-for-outlook">Outlook</a> · WhatsApp: <a href="/guides/compress-pdf-for-whatsapp">WhatsApp</a> · Telegram: <a href="/guides/compress-pdf-for-telegram">Telegram</a>.</p>

            <h2>Visa and immigration variants</h2>
            <p><a href="/guides/compress-pdf-for-visa-application">Visa application</a> · <a href="/guides/compress-pdf-ukvi">UKVI</a> · <a href="/guides/compress-pdf-home-affairs-australia">Australia Home Affairs</a> · <a href="/guides/compress-pdf-immigration-canada">Canada immigration</a> · <a href="/guides/compress-pdf-schengen-visa">Schengen</a>.</p>

            <h2>Industry-specific compress guides</h2>
            <p>Accountants closing month-end: <a href="/guides/compress-pdf-accountants">accountants</a>. Law firms on ECF deadline: <a href="/guides/compress-pdf-lawyers">lawyers</a> and <a href="/guides/compress-pdf-efiling">e-filing</a>. Students on LMS: <a href="/guides/compress-pdf-for-lms">LMS uploads</a>.</p>

            <h2>File naming for portal sanity</h2>
            <p>Use <code>Lastname_Passport_2026.pdf</code> not <code>scan0003.pdf</code> — officers match documents faster; you track which compress level you applied per filename suffix if needed (<code>_rec.pdf</code>).</p>

            <h2>Browser and device tips</h2>
            <p>Chrome and Edge handle large uploads better than some mobile WebViews. If mobile upload fails, retry desktop Wi-Fi. Clear cache if upload stalls at 99% — rare service worker glitch.</p>
            """


def body_compress(slug: str) -> str:
    return f"""
            <h2>{COMPRESS_TITLES[slug]}</h2>
            <p>RatPDF <a href="/pdf/compress">Compress PDF</a> shrinks oversized files with Ghostscript — no Adobe install. This guide covers real portal workflows, compression levels, quality traps, and when to merge or split instead.</p>
            <p>Pillar: <a href="/guides/compress-pdf-guide">Compress PDF guide</a> · Compare: <a href="/compare/smallpdf-alternative">Smallpdf alternative</a>.</p>

            {shot(COMPRESS_SHOTS[slug])}

            {COMPRESS_UNIQUE[slug]}

            {COMPRESS_SLUG_DEEP[slug]}

            {mid_cta('/pdf/compress', 'Compress PDF now', 'Shrink your PDF for this workflow')}

            {compress_supplement()}

            {COMPRESS_LONG_TAIL}

            {COMPRESS_MEGA}

            {COMPRESS_UNIVERSAL}

            {COMPRESS_PREMIUM}

            {COMPRESS_CLUSTER_LINKS}

            {COMPRESS_1500_TOPUP}

            {COMPRESS_FINAL_BOOST}

            {WAVE3_CLOSING}

            {end_cta('/pdf/compress', 'Compress PDF free', '<a href="/Subscription/Plans">Upgrade plans</a>')}
            """


def compliance_supplement() -> str:
    return """
            <h2>PDF as legal artefact vs working copy</h2>
            <p>Signed JSON e-invoice is authoritative for GST network; PDF is human-readable mirror. Redacted PDF is disclosure artefact; CRM export is source. WCAG-tagged PDF is publication artefact; Word source is editable master. Know which copy wins in dispute.</p>

            <h2>Internal review gates</h2>
            <ol>
            <li>Draft generated by operations</li>
            <li>Peer review for field completeness</li>
            <li>Legal/tax sign-off for external send</li>
            <li>Version stamped APPROVED in filename</li>
            <li>Distribution log who received which hash</li>
            </ol>

            <h2>Software export settings</h2>
            <p>Word to PDF: enable document structure tags for accessibility. Excel to PDF: repeat header rows on multi-page tables. ERP invoice PDF: embed fonts for GSTIN clarity on low-quality office printers.</p>

            <h2>Cross-tool workflows on RatPDF</h2>
            <p>Invoice PDF too large for email: <a href="/pdf/compress">Compress PDF</a>. Scanned supplier bill before redaction: <a href="/guides/ocr-pdf">OCR PDF</a>. Bundle exhibits: <a href="/guides/merge-pdf-online">Merge PDF</a>. Extract table for audit: <a href="/pdf/pdftotext">PDF to Text</a>.</p>

            <h2>FAQ alignment</h2>
            <p>This guide's FAQ schema answers common how-to questions — expand with country-specific professional advice when your facts differ from examples (export, SEZ, reverse charge).</p>

            <h2>Month-end and audit season</h2>
            <p>Accounts payable floods finance with supplier PDFs — validate GST fields before GSTR-3B reconciliation. Legal receives DSAR spike post-media coverage — redaction templates ready. Accessibility statements due on annual report publish — WCAG check before press release.</p>

            <h2>Stakeholder communication</h2>
            <p>When sending redacted PDF, email body lists what categories were removed (third-party PII, trade secret annex) without revealing content. Invoice email includes IRN in body text even when QR on PDF — dual confirmation for AP clerk.</p>

            <h2>Archival formats</h2>
            <p>PDF/A for long-term invoice archive — export from ERP if required. Redacted disclosures may use standard PDF if recipient does not require archival profile — confirm regulator preference.</p>
            """


def body_compliance(slug: str) -> str:
    tool, label = COMPLIANCE_TOOLS[slug]
    return f"""
            <h2>{COMPLIANCE_TITLES[slug]}</h2>
            <p>Operational guide for compliant PDF workflows — not legal or tax advice. Use RatPDF tools linked below alongside professional review where stakes are high.</p>

            {shot(f"{COMPLIANCE_TITLES[slug]} workflow screenshot")}

            {COMPLIANCE_UNIQUE[slug]}

            {COMPLIANCE_SLUG_DEEP[slug]}

            {mid_cta(tool, label, 'Open the right RatPDF tool')}

            {COMPLIANCE_MEGA}

            {compliance_supplement()}

            {COMPLIANCE_UNIVERSAL}

            {COMPLIANCE_PREMIUM}

            {COMPLIANCE_CLUSTER_LINKS}

            {COMPLIANCE_1500_TOPUP}

            {COMPLIANCE_FINAL_BOOST}

            {COMPLIANCE_CLOSING_EXTRA}

            {WAVE3_CLOSING}

            {end_cta(tool, label, '<a href="/compare">Compare tools</a>')}
            """


def main():
    lines = [
        "namespace ratpdf.Content",
        "{",
        "    /// <summary>Wave 3 premium guide bodies — Compress PDF + Compliance clusters (SEO audit).</summary>",
        "    internal static class GuideBodiesWave3",
        "    {",
        "        public static string? Get(string slug) => slug switch",
        "        {",
    ]
    for slug in SLUGS:
        lines.append(f'            "{slug}" => {const_name(slug)},')
    lines.append("            _ => null")
    lines.append("        };")
    lines.append("")

    for slug in SLUGS:
        body = body_compress(slug) if slug in COMPRESS_SLUGS else body_compliance(slug)
        content = body.lstrip("\n").rstrip()
        lines.append(f"        private const string {const_name(slug)} = \"\"\"")
        lines.append(content)
        lines.append("            \"\"\";")
        lines.append("")

    lines.append("    }")
    lines.append("}")
    OUT.write_text("\n".join(lines) + "\n", encoding="utf-8")
    print(f"Wrote {OUT} ({len(SLUGS)} guides)")


if __name__ == "__main__":
    main()
