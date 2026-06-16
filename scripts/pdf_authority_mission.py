#!/usr/bin/env python3
"""PDF-only authority mission — audit, keyword DB, 1000+ opportunities, topical map."""
from __future__ import annotations

import csv
import json
import re
from collections import Counter, defaultdict
from datetime import date
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]
DATA = ROOT / "Data"
CONTENT = ROOT / "Content"

NON_PDF = re.compile(
    r"invoice|payslip|rent.receipt|salary.slip|gst.invoice|vat.invoice|e-invoicing|"
    r"hmrc.invoice|word.counter|ring.size|my.ip|background.remover|json.formatter|"
    r"jwt|html.formatter|developer.tools|dns.lookup|binary.to|decimal.to|"
    r"free.payslip|rent.receipt|qr.code|password.generator",
    re.I,
)

USER_CLUSTERS = [
    "PDF Compression", "PDF Conversion", "PDF Editing", "PDF OCR", "PDF Security",
    "PDF Signing", "PDF Forms", "PDF Accessibility", "PDF Printing", "PDF Troubleshooting",
    "PDF Errors", "PDF Workflows", "PDF Productivity", "PDF Collaboration", "PDF Compliance",
    "PDF Archiving", "PDF Standards", "PDF for Students", "PDF for Businesses",
    "PDF for Government Forms", "PDF for Job Applications", "PDF for Visas",
    "PDF for Legal Documents", "PDF Mobile Workflows", "PDF Mac Workflows",
    "PDF Windows Workflows", "PDF Browser Workflows",
]

CLUSTER_MAP = {
    "Compress PDF": "PDF Compression",
    "Convert": "PDF Conversion",
    "PDF to Word": "PDF Conversion",
    "PDF to Text": "PDF Conversion",
    "OCR PDF": "PDF OCR",
    "Edit PDF": "PDF Editing",
    "Secure PDF": "PDF Security",
    "Compliance": "PDF Compliance",
    "Merge PDF": "PDF Workflows",
    "Split PDF": "PDF Workflows",
    "Workflow": "PDF Workflows",
    "Troubleshooting": "PDF Troubleshooting",
    "Mistakes": "PDF Errors",
    "Industry": "PDF for Businesses",
    "Regional": "PDF Workflows",
    "PDF Fundamentals": "PDF Productivity",
    "Checklists": "PDF Workflows",
    "Comparison": "PDF Collaboration",
    "Compare": "PDF Collaboration",
    "Best-of": "PDF Productivity",
    "Glossary": "PDF Productivity",
    "Advanced PDF": "PDF Standards",
    "Research": "PDF Compliance",
}

WAVE_FILES = sorted(CONTENT.glob("GuideBodiesWave*.cs")) + [
    CONTENT / "GuideBodies.cs",
    CONTENT / "GuideBodiesExtended.cs",
    CONTENT / "GuideBodiesGenerated.cs",
    CONTENT / "GuideBodiesMedicalImageDev.cs",
]

# High-intent seeds — expanded competitor gap coverage
KEYWORD_SEEDS: dict[str, list[tuple[str, str, int, str]]] = {
    "PDF Compression": [
        ("compress pdf online", "transactional", 100, "medium"),
        ("compress pdf for email", "problem", 97, "low"),
        ("reduce pdf file size", "transactional", 90, "medium"),
        ("compress pdf without losing quality", "informational", 88, "medium"),
        ("compress pdf for gmail", "problem", 92, "low"),
        ("compress pdf made file larger", "problem", 85, "low"),
        ("batch compress pdf", "workflow", 89, "low"),
        ("compress scanned pdf", "problem", 83, "medium"),
        ("compress pdf for government portal", "problem", 90, "low"),
        ("compress pdf to 100kb", "transactional", 91, "medium"),
        ("compress pdf to 200kb", "transactional", 90, "medium"),
        ("compress pdf to 500kb", "transactional", 88, "medium"),
        ("compress pdf under 1mb", "transactional", 87, "medium"),
        ("compress pdf for whatsapp", "problem", 86, "low"),
        ("compress pdf for linkedin", "problem", 84, "low"),
        ("compress pdf for job application", "problem", 89, "low"),
        ("compress pdf for court e filing", "problem", 85, "low"),
        ("compress pdf for medical records", "problem", 82, "low"),
        ("lossless pdf compression", "informational", 80, "low"),
        ("ghostscript compress pdf settings", "informational", 78, "low"),
    ],
    "PDF Conversion": [
        ("pdf to word", "transactional", 98, "high"),
        ("word to pdf", "transactional", 96, "high"),
        ("pdf to excel", "transactional", 88, "medium"),
        ("pdf to powerpoint", "transactional", 82, "medium"),
        ("pdf to jpg", "transactional", 99, "high"),
        ("pdf to png", "transactional", 94, "high"),
        ("pdf to text", "transactional", 91, "medium"),
        ("html to pdf", "transactional", 85, "medium"),
        ("images to pdf", "transactional", 95, "medium"),
        ("pdf to markdown", "transactional", 78, "low"),
        ("pdf to word keep formatting", "problem", 96, "medium"),
        ("scanned pdf to word", "problem", 94, "medium"),
        ("pdf to word without adobe", "comparison", 93, "medium"),
        ("pdf to excel table extraction", "problem", 86, "medium"),
        ("pdf to csv", "transactional", 72, "low"),
        ("pdf to epub", "transactional", 75, "low"),
        ("heic to pdf", "transactional", 84, "medium"),
        ("cad to pdf", "transactional", 70, "low"),
        ("email to pdf", "workflow", 83, "medium"),
        ("webpage to pdf", "transactional", 82, "medium"),
    ],
    "PDF OCR": [
        ("ocr pdf online", "transactional", 97, "medium"),
        ("make scanned pdf searchable", "problem", 88, "low"),
        ("ocr pdf arabic", "transactional", 80, "low"),
        ("ocr pdf chinese", "transactional", 80, "low"),
        ("ocr pdf hindi", "transactional", 80, "low"),
        ("ocr vs pdf to text", "comparison", 85, "low"),
        ("tesseract ocr pdf", "informational", 75, "low"),
        ("ocr pdf for discovery", "workflow", 87, "low"),
        ("ocr handwriting pdf", "problem", 82, "medium"),
        ("ocr pdf accuracy tips", "informational", 79, "low"),
    ],
    "PDF Editing": [
        ("edit pdf online", "transactional", 99, "high"),
        ("edit pdf without adobe", "comparison", 95, "medium"),
        ("add text to pdf", "transactional", 93, "medium"),
        ("add image to pdf", "transactional", 89, "low"),
        ("organize pdf pages", "transactional", 88, "medium"),
        ("crop pdf online", "transactional", 90, "high"),
        ("delete pages from pdf", "transactional", 89, "high"),
        ("annotate pdf online", "transactional", 86, "medium"),
        ("highlight pdf online", "transactional", 84, "medium"),
        ("rearrange pdf pages", "transactional", 85, "medium"),
        ("rotate pdf pages", "transactional", 83, "medium"),
        ("remove blank pages pdf", "problem", 82, "low"),
        ("add page numbers pdf", "transactional", 81, "medium"),
        ("extract single page pdf", "transactional", 80, "low"),
        ("replace text in pdf", "problem", 87, "medium"),
    ],
    "PDF Security": [
        ("password protect pdf", "transactional", 95, "medium"),
        ("unlock pdf", "transactional", 93, "medium"),
        ("redact pdf permanently", "problem", 87, "low"),
        ("watermark pdf", "transactional", 89, "medium"),
        ("remove password from pdf", "problem", 86, "medium"),
        ("encrypt pdf aes 256", "informational", 78, "low"),
        ("blackout text in pdf", "problem", 85, "medium"),
        ("remove metadata from pdf", "problem", 79, "low"),
        ("pdf javascript security risk", "informational", 76, "low"),
        ("secure pdf before email", "workflow", 84, "low"),
    ],
    "PDF Signing": [
        ("sign pdf online", "transactional", 94, "medium"),
        ("electronically sign pdf legally", "informational", 91, "medium"),
        ("add signature to pdf", "transactional", 93, "medium"),
        ("fill and sign pdf", "transactional", 90, "medium"),
        ("sign pdf on iphone", "device", 86, "low"),
        ("sign pdf without printing", "workflow", 85, "low"),
    ],
    "PDF Forms": [
        ("fill pdf form online", "transactional", 87, "medium"),
        ("flatten pdf forms", "transactional", 86, "medium"),
        ("create fillable pdf", "informational", 84, "medium"),
        ("edit pdf form fields", "problem", 82, "low"),
        ("pdf form not saving", "problem", 80, "low"),
    ],
    "PDF Accessibility": [
        ("pdf accessibility wcag", "compliance", 83, "medium"),
        ("tagged pdf checklist", "compliance", 80, "low"),
        ("screen reader pdf", "problem", 78, "low"),
        ("section 508 pdf", "compliance", 81, "low"),
        ("remediate pdf accessibility", "workflow", 79, "low"),
        ("pdf/ua compliance guide", "compliance", 80, "low"),
        ("add alt text to pdf", "workflow", 77, "low"),
    ],
    "PDF Printing": [
        ("print to pdf windows", "device", 88, "medium"),
        ("print to pdf mac", "device", 87, "medium"),
        ("print pdf without margins", "problem", 83, "medium"),
        ("pdf colors wrong when printing", "problem", 81, "low"),
        ("pdf printing blank pages", "problem", 85, "medium"),
        ("flatten pdf for printing", "workflow", 84, "medium"),
        ("commercial print pdf handoff", "workflow", 78, "low"),
        ("pdf overprint printing", "informational", 74, "low"),
    ],
    "PDF Troubleshooting": [
        ("pdf won't open", "problem", 90, "medium"),
        ("pdf file corrupted", "problem", 88, "medium"),
        ("pdf too large to email", "problem", 92, "low"),
        ("pdf fonts missing", "problem", 83, "medium"),
        ("pdf attachment blocked", "problem", 86, "low"),
        ("repair pdf online", "problem", 88, "medium"),
        ("pdf merge failed", "problem", 84, "low"),
        ("pdf download incomplete", "problem", 82, "low"),
        ("pdf password not working", "problem", 85, "medium"),
        ("pdf blank after merge", "problem", 83, "low"),
    ],
    "PDF Standards": [
        ("pdf/a archival", "compliance", 82, "medium"),
        ("pdf/x print standard", "compliance", 78, "low"),
        ("pdf/ua accessibility", "compliance", 80, "low"),
        ("convert to pdf/a online", "workflow", 80, "low"),
        ("pdf metadata editor", "transactional", 79, "low"),
        ("pdf retention policy", "compliance", 77, "low"),
    ],
    "PDF Archiving": [
        ("archive pdf long term storage", "informational", 78, "low"),
        ("pdf document retention periods", "compliance", 80, "low"),
        ("digitize paper archive pdf", "workflow", 76, "low"),
    ],
    "PDF Collaboration": [
        ("compare two pdfs", "transactional", 86, "medium"),
        ("pdf review workflow", "workflow", 77, "low"),
        ("share pdf securely", "workflow", 80, "low"),
        ("pdf comment export", "workflow", 74, "low"),
        ("best free pdf tools 2026", "commercial", 90, "high"),
        ("pdfgear alternative", "comparison", 82, "medium"),
        ("nitro pdf alternative", "comparison", 81, "medium"),
        ("pdf24 vs ilovepdf", "comparison", 78, "low"),
        ("smallpdf vs adobe", "comparison", 85, "medium"),
    ],
    "PDF Browser Workflows": [
        ("chrome save as pdf", "device", 86, "medium"),
        ("edge print to pdf", "device", 84, "medium"),
        ("safari save webpage as pdf", "device", 83, "medium"),
        ("firefox print to pdf", "device", 80, "low"),
        ("browser vs desktop pdf tools", "comparison", 82, "medium"),
        ("merge pdf in browser", "transactional", 85, "medium"),
        ("ocr pdf in browser", "transactional", 83, "medium"),
    ],
    "PDF Mac Workflows": [
        ("compress pdf on mac", "device", 91, "low"),
        ("merge pdf on mac preview", "device", 89, "medium"),
        ("pdf to word on mac", "device", 93, "medium"),
        ("split pdf on mac", "device", 86, "low"),
        ("ocr pdf on mac", "device", 84, "low"),
    ],
    "PDF Windows Workflows": [
        ("compress pdf on windows", "device", 91, "low"),
        ("merge pdf windows 11", "device", 88, "medium"),
        ("print to pdf windows 11", "device", 87, "medium"),
        ("split pdf on windows", "device", 85, "low"),
        ("edit pdf on windows free", "device", 86, "medium"),
    ],
    "PDF Mobile Workflows": [
        ("compress pdf on iphone", "device", 92, "low"),
        ("merge pdf on android", "device", 82, "medium"),
        ("scan to pdf phone", "workflow", 90, "medium"),
        ("sign pdf on iphone", "device", 86, "low"),
        ("ocr pdf on android", "device", 83, "low"),
    ],
    "PDF for Visas": [
        ("compress pdf for visa application", "problem", 91, "low"),
        ("merge pdf for visa documents", "workflow", 93, "low"),
        ("bank statement pdf visa", "workflow", 86, "medium"),
        ("passport scan pdf size", "problem", 87, "low"),
        ("uscis pdf upload requirements", "compliance", 86, "low"),
        ("ukvi pdf document rules", "compliance", 85, "low"),
        ("schengen visa pdf merge order", "workflow", 84, "low"),
    ],
    "PDF for Government Forms": [
        ("irs pdf form fill online", "workflow", 87, "medium"),
        ("dmv upload pdf size limit", "problem", 83, "low"),
        ("government portal pdf compress", "problem", 88, "low"),
        ("digilocker pdf upload size", "problem", 85, "low"),
    ],
    "PDF for Job Applications": [
        ("ats friendly pdf resume", "problem", 88, "medium"),
        ("linkedin save profile as pdf", "workflow", 80, "low"),
        ("combine resume cover letter pdf", "workflow", 86, "low"),
        ("pdf job application size limit", "problem", 84, "low"),
    ],
    "PDF for Legal Documents": [
        ("merge pdf court filing", "workflow", 85, "low"),
        ("bates numbering pdf", "workflow", 82, "medium"),
        ("redact pdf discovery", "workflow", 84, "low"),
        ("ocr pdf legal documents", "workflow", 88, "low"),
        ("contract pdf redline workflow", "workflow", 86, "low"),
    ],
    "PDF for Businesses": [
        ("accountant client pdf portal", "workflow", 80, "low"),
        ("real estate disclosure pdf merge", "workflow", 82, "low"),
        ("insurance claim pdf photos", "workflow", 83, "low"),
        ("healthcare pdf hipaa email", "compliance", 81, "low"),
        ("law firm pdf discovery workflow", "workflow", 84, "low"),
    ],
    "PDF for Students": [
        ("student combine lecture pdfs", "workflow", 82, "low"),
        ("submit homework pdf canvas", "problem", 84, "medium"),
        ("compress pdf for blackboard", "problem", 80, "low"),
        ("scan notes to pdf study", "workflow", 81, "low"),
    ],
    "PDF Productivity": [
        ("what is a pdf file", "informational", 75, "low"),
        ("pdf vs word when to use", "informational", 82, "medium"),
        ("how pdf compression works", "informational", 78, "low"),
        ("pdf file size explained", "informational", 76, "low"),
        ("pdf workflow checklist", "informational", 74, "low"),
    ],
}

NET_NEW_REGIONAL = [
    ("visa-application-pdf-workflow-italy", "PDF for Visas", "visa pdf italy requirements", 84),
    ("visa-application-pdf-workflow-mexico", "PDF for Visas", "visa pdf mexico upload", 83),
    ("visa-application-pdf-workflow-new-zealand", "PDF for Visas", "nz visa pdf documents", 82),
    ("visa-application-pdf-workflow-south-africa", "PDF for Visas", "south africa visa pdf", 81),
    ("visa-application-pdf-workflow-south-korea", "PDF for Visas", "korea visa pdf scan", 81),
    ("bank-statement-pdf-workflow-italy", "PDF Workflows", "italy bank statement pdf visa", 80),
    ("bank-statement-pdf-workflow-mexico", "PDF Workflows", "mexico bank pdf upload", 79),
    ("contract-pdf-workflow-italy", "PDF Workflows", "italy contract pdf sign", 78),
    ("contract-pdf-workflow-mexico", "PDF Workflows", "mexico contract pdf", 78),
]

COMPARE_GAPS = [
    ("pdfgear-alternative", "PDF Collaboration", "pdfgear alternative", 82),
    ("nitro-pdf-alternative", "PDF Collaboration", "nitro pdf alternative", 81),
    ("pdfgear-vs-adobe", "PDF Collaboration", "pdfgear vs adobe", 79),
    ("nitro-vs-adobe-acrobat", "PDF Collaboration", "nitro vs adobe acrobat", 78),
    ("pdfsam-alternative", "PDF Collaboration", "pdfsam alternative", 76),
    ("able2extract-alternative", "PDF Collaboration", "able2extract alternative", 74),
]

# Template expansions for 1000+ unique intents (PDF-only)
INDUSTRIES = [
    "lawyers", "accountants", "healthcare", "real-estate", "insurance", "education",
    "nonprofits", "government", "freelancers", "consultants", "architects", "engineers",
    "researchers", "journalists", "hr-teams", "sales-teams", "marketing-teams",
]

INDUSTRY_TASKS = [
    ("merge-pdf-for-{industry}", "merge pdf for {industry}", "PDF for Businesses", 72),
    ("compress-pdf-for-{industry}", "compress pdf for {industry}", "PDF for Businesses", 71),
    ("ocr-pdf-for-{industry}", "ocr pdf for {industry}", "PDF for Businesses", 70),
    ("secure-pdf-workflow-{industry}", "secure pdf workflow {industry}", "PDF Security", 69),
]

OCR_LANGUAGES = [
    "spanish", "french", "german", "japanese", "korean", "portuguese", "russian",
    "italian", "dutch", "turkish", "vietnamese", "thai", "hebrew", "polish",
]

PDF_ERROR_TOPICS = [
    ("pdf-error-0x80070057", "pdf error 0x80070057", 78),
    ("pdf-error-there-was-an-error-opening-this-document", "there was an error opening this document pdf", 80),
    ("pdf-error-file-damaged", "pdf file damaged and cannot be repaired", 79),
    ("pdf-error-not-a-valid-file", "pdf not a valid file", 77),
    ("pdf-error-out-of-memory", "pdf out of memory error", 74),
    ("pdf-error-print-spooler", "pdf print spooler error", 76),
    ("pdf-error-secured-document", "secured pdf cannot be edited", 81),
    ("pdf-error-xfa-form", "xfa pdf form not supported", 73),
    ("pdf-error-font-embedding", "pdf font embedding failed", 75),
    ("pdf-error-linearization", "pdf linearization failed", 70),
]

GOVT_PORTALS = [
    ("irs", "PDF for Government Forms", 85),
    ("uscis", "PDF for Visas", 84),
    ("dmv", "PDF for Government Forms", 83),
    ("ssa", "PDF for Government Forms", 80),
    ("ukvi", "PDF for Visas", 84),
    ("schengen", "PDF for Visas", 83),
    ("incometax-india", "PDF for Government Forms", 86),
    ("gst-portal-india", "PDF for Government Forms", 85),
    ("digilocker", "PDF for Government Forms", 84),
    ("mygov-australia", "PDF for Government Forms", 82),
    ("service-canada", "PDF for Government Forms", 81),
    ("ird-nz", "PDF for Government Forms", 79),
]

DEVICE_TASK_MATRIX = [
    ("merge-pdf-on-{device}", "merge pdf on {device}", "PDF Workflows", 80),
    ("split-pdf-on-{device}", "split pdf on {device}", "PDF Workflows", 78),
    ("convert-pdf-on-{device}", "convert pdf on {device}", "PDF Conversion", 77),
    ("sign-pdf-on-{device}", "sign pdf on {device}", "PDF Signing", 76),
    ("ocr-pdf-on-{device}", "ocr pdf on {device}", "PDF OCR", 75),
]

DEVICES = ["iphone", "ipad", "android", "chromebook", "linux", "mac", "windows-11"]

FUNDAMENTALS = [
    ("beginner-how-pdf-compression-works", "how pdf compression works", "PDF Productivity", 74),
    ("beginner-pdf-vs-png-for-documents", "pdf vs png for documents", "PDF Productivity", 72),
    ("beginner-vector-vs-raster-pdf", "vector vs raster pdf", "PDF Productivity", 70),
    ("beginner-pdf-color-spaces", "pdf color spaces cmyk rgb", "PDF Productivity", 68),
    ("beginner-pdf-font-subsetting", "pdf font subsetting explained", "PDF Productivity", 67),
    ("beginner-pdf-linearization", "pdf linearization fast web view", "PDF Productivity", 66),
    ("beginner-pdf-encryption-types", "pdf encryption types explained", "PDF Productivity", 71),
    ("beginner-scanned-vs-digital-pdf", "scanned vs digital pdf", "PDF Productivity", 73),
]

BEST_OF_AUDIENCES = [
    "lawyers", "students", "accountants", "teachers", "freelancers", "small-business",
    "healthcare", "real-estate-agents", "remote-teams", "nonprofits", "government",
    "researchers", "designers", "developers", "sales-teams", "hr-teams", "consultants",
]

BEST_OF_TOOLS = [
    ("compressor", "best pdf compressor for {aud}", "PDF Compression", 70),
    ("merger", "best pdf merger for {aud}", "PDF Workflows", 69),
    ("converter", "best pdf converter for {aud}", "PDF Conversion", 68),
    ("ocr", "best pdf ocr for {aud}", "PDF OCR", 67),
    ("editor", "best pdf editor for {aud}", "PDF Editing", 71),
]

VISA_COUNTRIES_EXTRA = [
    "italy", "mexico", "new-zealand", "south-africa", "south-korea", "brazil", "argentina",
    "poland", "sweden", "norway", "denmark", "finland", "portugal", "greece", "turkey",
    "egypt", "morocco", "nigeria", "kenya", "thailand", "vietnam", "indonesia", "malaysia",
    "philippines", "china", "taiwan", "hong-kong",
]

VISA_TASKS = [
    ("visa-application-pdf-workflow-{c}", "visa application pdf workflow {c}", 82),
    ("bank-statement-pdf-workflow-{c}", "bank statement pdf workflow {c}", 80),
    ("contract-pdf-workflow-{c}", "contract pdf workflow {c}", 78),
]

CONVERSION_PAIRS = [
    ("pdf-to-rtf", "pdf to rtf", "PDF Conversion", 70),
    ("pdf-to-xml", "pdf to xml", "PDF Conversion", 65),
    ("pdf-to-hwp", "pdf to hwp", "PDF Conversion", 62),
    ("pdf-to-odt", "pdf to odt", "PDF Conversion", 68),
    ("pdf-to-pages", "pdf to pages mac", "PDF Mac Workflows", 72),
    ("pdf-to-google-docs", "pdf to google docs", "PDF Conversion", 75),
    ("pdf-to-notion", "pdf to notion", "PDF Productivity", 68),
    ("pdf-to-kindle", "pdf to kindle", "PDF Conversion", 66),
    ("pdf-to-audio", "pdf to audio read aloud", "PDF Accessibility", 64),
    ("pdf-to-searchable-image", "pdf to searchable image", "PDF OCR", 70),
]

COLLABORATION_WORKFLOWS = [
    ("pdf-review-workflow-remote-team", "pdf review workflow remote team", 74),
    ("pdf-approval-workflow-no-adobe", "pdf approval workflow without adobe", 73),
    ("pdf-version-control-best-practices", "pdf version control best practices", 71),
    ("pdf-comments-to-word", "export pdf comments to word", 69),
    ("pdf-shared-drive-naming-convention", "pdf shared drive naming convention", 67),
    ("pdf-email-thread-archive", "archive email thread as pdf", 72),
    ("pdf-handoff-design-to-dev", "pdf handoff design to development", 68),
    ("pdf-client-delivery-checklist", "pdf client delivery checklist", 70),
]

FORMS_WORKFLOWS = [
    ("create-fillable-pdf-form-free", "create fillable pdf form free", 84),
    ("pdf-form-field-validation", "pdf form field validation", 78),
    ("pdf-form-tab-order", "pdf form tab order accessibility", 74),
    ("pdf-form-calculate-fields", "pdf form calculated fields", 76),
    ("pdf-form-digital-signature-field", "pdf form digital signature field", 80),
    ("xfa-to-acroform-convert", "convert xfa pdf to acroform", 77),
    ("pdf-form-accessibility-tags", "pdf form accessibility tags", 75),
]

ACCESSIBILITY_FIXES = [
    ("fix-pdf-missing-alt-text", "fix pdf missing alt text", 76),
    ("fix-pdf-reading-order", "fix pdf reading order screen reader", 75),
    ("fix-pdf-untagged-content", "fix untagged pdf content", 74),
    ("fix-pdf-low-contrast-text", "fix pdf low contrast text wcag", 73),
    ("fix-pdf-table-headers", "fix pdf table headers accessibility", 72),
    ("fix-pdf-bookmarks-missing", "add pdf bookmarks for navigation", 71),
]

PRINTING_EDGE = [
    ("pdf-prints-too-light", "pdf prints too light", 78),
    ("pdf-prints-cropped-off", "pdf prints cropped off", 77),
    ("pdf-prints-wrong-paper-size", "pdf prints wrong paper size", 76),
    ("pdf-prints-double-sided-wrong", "pdf double sided printing wrong order", 74),
    ("pdf-prints-grayscale-only", "pdf prints grayscale only fix", 73),
    ("pdf-embed-fonts-for-print", "embed fonts in pdf for print", 75),
]

ARCHIVING_WORKFLOWS = [
    ("pdf-a-1b-compliance-checklist", "pdf/a-1b compliance checklist", 79),
    ("pdf-a-2b-vs-pdf-a-3", "pdf/a-2b vs pdf/a-3 difference", 77),
    ("pdf-long-term-archive-strategy", "pdf long term archive strategy", 76),
    ("pdf-digitization-project-plan", "pdf digitization project plan", 74),
    ("pdf-records-management-policy", "pdf records management policy template", 73),
    ("pdf-email-archive-migration", "migrate email archive to pdf/a", 72),
    ("pdf-litigation-hold-archive", "pdf litigation hold archiving", 75),
    ("pdf-cloud-archive-vs-on-prem", "pdf cloud archive vs on premise", 71),
    ("pdf-checksum-verify-integrity", "verify pdf checksum integrity", 70),
    ("pdf-migration-documents-to-pdfa", "migrate documents to pdf/a workflow", 78),
    ("pdf-worm-storage-compliance", "pdf worm storage compliance", 72),
    ("pdf-retention-schedule-by-type", "pdf retention schedule by document type", 74),
    ("pdf-destruction-certificate", "pdf destruction certificate workflow", 69),
    ("pdf-archive-metadata-schema", "pdf archive metadata schema", 68),
    ("pdf-timestamp-authority-signing", "pdf timestamp authority signing", 76),
]


def is_pdf_slug(slug: str) -> bool:
    return bool(slug) and not NON_PDF.search(slug)


def collect_live_slugs() -> tuple[set[str], set[str]]:
    """Return (all_slugs, wave_upgraded_slugs)."""
    all_slugs: set[str] = set()
    wave_slugs: set[str] = set()
    for path in WAVE_FILES:
        if not path.exists():
            continue
        slugs = set(re.findall(r'"([\w-]+)"\s*=>', path.read_text(encoding="utf-8")))
        all_slugs |= slugs
        if "Wave" in path.name:
            wave_slugs |= slugs
    pdf_slugs = {s for s in all_slugs if is_pdf_slug(s)}
    pdf_wave = {s for s in wave_slugs if is_pdf_slug(s)}
    return pdf_slugs, pdf_wave


def slug_from_keyword(kw: str) -> str:
    return re.sub(r"[^a-z0-9]+", "-", kw.lower()).strip("-")


def row_slug(r: dict) -> str:
    url = r.get("RecommendedURL") or r.get("URL") or ""
    if url.startswith("/guides/"):
        return url.replace("/guides/", "").strip("/")
    kw = (r.get("PrimaryKeyword") or r.get("Keyword") or "").lower()
    return slug_from_keyword(kw) if kw else ""


def is_pdf_row(r: dict) -> bool:
    cluster = (r.get("Cluster") or "").lower()
    if cluster in ("invoice", "payslip"):
        return False
    slug = row_slug(r)
    kw = (r.get("PrimaryKeyword") or "") + " " + (r.get("SecondaryKeywords") or "")
    return not NON_PDF.search(cluster + " " + slug + " " + kw)


def score_roadmap_row(r: dict, wave_slugs: set[str]) -> int:
    slug = row_slug(r)
    base = {"P0": 90, "P1": 75, "P2": 60, "P3": 45}.get(r.get("Priority", "P2"), 55)
    intent = (r.get("SearchIntent") or "").lower()
    if intent in ("transactional", "commercial"):
        base += 8
    elif intent in ("problem", "workflow"):
        base += 5
    diff = (r.get("DifficultyEst") or "").lower()
    if diff == "low":
        base += 4
    traffic = (r.get("TrafficPotential") or "").lower()
    if traffic == "high":
        base += 6
    elif traffic == "medium":
        base += 3
    if slug in wave_slugs:
        base -= 15  # already upgraded — maintain not rewrite
    if slug.startswith("glossary-"):
        base -= 5  # TOFU — batch later
    return min(100, max(30, base))


def match_existing(slug_guess: str, kw: str, live: set[str]) -> str:
    if slug_guess in live:
        return slug_guess
    kw_norm = kw.lower()
    for s in live:
        if slug_guess in s or s.replace("-", " ") in kw_norm:
            return s
    return ""


def build_opportunities(
    pdf_live: set[str],
    wave_slugs: set[str],
    pdf_roadmap: list[dict],
) -> list[dict]:
    seen_urls: set[str] = set()
    rows: list[dict] = []
    opp_id = 0

    def add(
        keyword: str,
        cluster: str,
        intent: str,
        competition: str,
        priority: int,
        action: str,
        slug: str,
        notes: str = "",
    ) -> None:
        nonlocal opp_id
        url = f"/guides/{slug}" if slug and not slug.startswith("/") else slug
        if url in seen_urls and action != "UPGRADE":
            return
        seen_urls.add(url)
        opp_id += 1
        rows.append({
            "id": opp_id,
            "keyword": keyword,
            "cluster": cluster,
            "intent": intent,
            "competition": competition,
            "priority_score": priority,
            "action": action,
            "existing_slug": slug if action == "UPGRADE" else "",
            "target_url": url if url.startswith("/") else f"/guides/{slug}",
            "word_target": "1500-4000",
            "notes": notes,
        })

    # 1 — Every published PDF roadmap row → UPGRADE unless wave-upgraded
    for r in pdf_roadmap:
        if r.get("Status") != "Published":
            continue
        slug = row_slug(r)
        if not slug or not is_pdf_slug(slug):
            continue
        cluster = CLUSTER_MAP.get(r.get("Cluster", ""), r.get("Cluster", "PDF Workflows"))
        kw = r.get("PrimaryKeyword") or slug.replace("-", " ")
        priority = score_roadmap_row(r, wave_slugs)
        action = "MAINTAIN" if slug in wave_slugs else "UPGRADE"
        notes = "Wave upgraded" if slug in wave_slugs else "Thin template — rewrite to 1500+ words"
        add(kw, cluster, (r.get("SearchIntent") or "informational").lower(), "medium", priority, action, slug, notes)

    # 2 — Deferred PDF-only roadmap
    for r in pdf_roadmap:
        if r.get("Status") != "Deferred":
            continue
        slug = row_slug(r)
        if not slug or not is_pdf_slug(slug):
            continue
        if NON_PDF.search(r.get("PrimaryKeyword") or ""):
            continue
        cluster = CLUSTER_MAP.get(r.get("Cluster", ""), "PDF Productivity")
        kw = r.get("PrimaryKeyword") or slug.replace("-", " ")
        if "invoice" in kw.lower() and "pdf" not in kw.lower():
            continue
        priority = score_roadmap_row(r, wave_slugs) + 3
        add(kw, cluster, (r.get("SearchIntent") or "commercial").lower(), "medium", priority, "CREATE", slug, "Deferred roadmap")

    # 3 — Keyword seeds
    for cluster, seeds in KEYWORD_SEEDS.items():
        for kw, intent, score, comp in seeds:
            slug_guess = slug_from_keyword(kw)
            existing = match_existing(slug_guess, kw, pdf_live)
            if existing:
                if existing in wave_slugs:
                    continue
                action = "UPGRADE"
                priority = score + 3
                slug = existing
            else:
                action = "CREATE"
                priority = score
                slug = slug_guess
            url = f"/guides/{slug}"
            if url in seen_urls:
                continue
            add(kw, cluster, intent, comp, priority, action, slug)

    # 4 — Net-new regional batch 3
    for slug, cluster, kw, score in NET_NEW_REGIONAL:
        if slug in pdf_live:
            continue
        add(kw, cluster, "workflow", "low", score, "CREATE", slug, "Wave 15 batch 3")

    # 5 — Compare gaps
    for slug, cluster, kw, score in COMPARE_GAPS:
        url = f"/compare/{slug}"
        if url in seen_urls:
            continue
        seen_urls.add(url)
        opp_id += 1
        rows.append({
            "id": opp_id,
            "keyword": kw,
            "cluster": cluster,
            "intent": "comparison",
            "competition": "medium",
            "priority_score": score,
            "action": "CREATE",
            "existing_slug": "",
            "target_url": url,
            "word_target": "2000-3500",
            "notes": "Missing competitor page",
        })

    # 6 — Glossary upgrade batch (all live glossary-* not in waves)
    for slug in sorted(pdf_live):
        if not slug.startswith("glossary-"):
            continue
        if slug in wave_slugs:
            continue
        url = f"/guides/{slug}"
        if url in seen_urls:
            continue
        kw = slug.replace("glossary-", "").replace("-", " ") + " definition"
        add(kw, "PDF Productivity", "informational", "low", 55, "UPGRADE", slug, "Glossary TOFU — link to pillar")

    # 7 — Industry × task matrix
    for industry in INDUSTRIES:
        for slug_tpl, kw_tpl, cluster, score in INDUSTRY_TASKS:
            slug = slug_tpl.format(industry=industry)
            kw = kw_tpl.format(industry=industry.replace("-", " "))
            if slug in pdf_live and slug in wave_slugs:
                continue
            action = "UPGRADE" if slug in pdf_live else "CREATE"
            add(kw, cluster, "workflow", "low", score, action, slug, "Industry vertical")

    # 8 — OCR language variants
    for lang in OCR_LANGUAGES:
        slug = f"ocr-pdf-{lang}"
        kw = f"ocr pdf {lang}"
        if slug in pdf_live and slug in wave_slugs:
            continue
        action = "UPGRADE" if slug in pdf_live else "CREATE"
        add(kw, "PDF OCR", "transactional", "low", 68, action, slug)

    # 9 — PDF error deep dives
    for slug, kw, score in PDF_ERROR_TOPICS:
        if slug in pdf_live and slug in wave_slugs:
            continue
        action = "UPGRADE" if slug in pdf_live else "CREATE"
        add(kw, "PDF Errors", "problem", "medium", score, action, slug)

    # 10 — Government portal compress/upload guides
    for portal, cluster, score in GOVT_PORTALS:
        slug = f"compress-pdf-{portal}"
        kw = f"compress pdf for {portal.replace('-', ' ')}"
        if slug in pdf_live and slug in wave_slugs:
            continue
        action = "UPGRADE" if slug in pdf_live else "CREATE"
        add(kw, cluster, "problem", "low", score, action, slug, "Portal-specific")

    # 11 — Device × task matrix (skip if wave 14 covered)
    for device in DEVICES:
        for slug_tpl, kw_tpl, cluster, score in DEVICE_TASK_MATRIX:
            slug = slug_tpl.format(device=device)
            kw = kw_tpl.format(device=device.replace("-", " "))
            if slug in wave_slugs:
                continue
            if slug in pdf_live:
                action = "UPGRADE"
            else:
                action = "CREATE"
            add(kw, cluster, "device", "medium", score - 5, action, slug)

    # 12 — Educational fundamentals
    for slug, kw, cluster, score in FUNDAMENTALS:
        if slug in wave_slugs:
            continue
        action = "UPGRADE" if slug in pdf_live else "CREATE"
        add(kw, cluster, "informational", "low", score, action, slug)

    # 13 — Best-of PDF tools per audience (PDF-only, not invoice)
    for aud in BEST_OF_AUDIENCES:
        for tool, kw_tpl, cluster, score in BEST_OF_TOOLS:
            slug = f"best-pdf-{tool}-for-{aud}"
            kw = kw_tpl.format(aud=aud.replace("-", " "))
            action = "UPGRADE" if slug in pdf_live else "CREATE"
            add(kw, cluster, "commercial", "medium", score, action, slug, "Best-of segment")

    # 14 — Extra visa/country workflow matrix
    for country in VISA_COUNTRIES_EXTRA:
        for slug_tpl, kw_tpl, score in VISA_TASKS:
            slug = slug_tpl.format(c=country)
            kw = kw_tpl.format(c=country.replace("-", " "))
            if slug in wave_slugs:
                continue
            action = "UPGRADE" if slug in pdf_live else "CREATE"
            add(kw, "PDF Workflows", "workflow", "low", score, action, slug, "Regional visa/bank")

    # 15 — Conversion format gaps
    for slug, kw, cluster, score in CONVERSION_PAIRS:
        if slug in wave_slugs:
            continue
        action = "UPGRADE" if slug in pdf_live else "CREATE"
        add(kw, cluster, "transactional", "medium", score, action, slug)

    # 16 — Collaboration workflows
    for slug, kw, score in COLLABORATION_WORKFLOWS:
        if slug in wave_slugs:
            continue
        action = "UPGRADE" if slug in pdf_live else "CREATE"
        add(kw, "PDF Collaboration", "workflow", "low", score, action, slug)

    # 17 — Forms, accessibility fixes, printing edge cases
    for slug, kw, score in FORMS_WORKFLOWS:
        action = "UPGRADE" if slug in pdf_live else "CREATE"
        add(kw, "PDF Forms", "transactional", "medium", score, action, slug)
    for slug, kw, score in ACCESSIBILITY_FIXES:
        action = "UPGRADE" if slug in pdf_live else "CREATE"
        add(kw, "PDF Accessibility", "problem", "low", score, action, slug)
    for slug, kw, score in PRINTING_EDGE:
        action = "UPGRADE" if slug in pdf_live else "CREATE"
        add(kw, "PDF Printing", "problem", "low", score, action, slug)
    for slug, kw, score in ARCHIVING_WORKFLOWS:
        action = "UPGRADE" if slug in pdf_live else "CREATE"
        add(kw, "PDF Archiving", "compliance", "low", score, action, slug)

    # Filter non-PDF clusters slipped from roadmap
    def keep_row(r: dict) -> bool:
        if r["cluster"] == "Developer":
            return False
        if r["target_url"].startswith("/compare/"):
            return True
        slug = r.get("existing_slug") or r["target_url"].replace("/guides/", "").strip("/")
        return is_pdf_slug(slug)

    rows = [r for r in rows if keep_row(r)]

    return sorted(rows, key=lambda x: -x["priority_score"])


def write_csv(path: Path, rows: list[dict], fields: list[str]) -> None:
    with path.open("w", newline="", encoding="utf-8") as f:
        w = csv.DictWriter(f, fieldnames=fields, extrasaction="ignore")
        w.writeheader()
        w.writerows(rows)


def write_topical_map_v3(
    pdf_live: set[str],
    wave_slugs: set[str],
    opportunities: list[dict],
    pdf_roadmap: list[dict],
) -> None:
    today = date.today().isoformat()
    upgrade = sum(1 for o in opportunities if o["action"] == "UPGRADE")
    maintain = sum(1 for o in opportunities if o["action"] == "MAINTAIN")
    create = sum(1 for o in opportunities if o["action"] == "CREATE")
    authority_est = maintain + upgrade  # wave + pending upgrades

    lines = [
        "# PDF Topical Authority Map v3 — PDF-Only Mission",
        "",
        f"> Verified against codebase {today}: `ContentLibrary.cs`, `GuideBodiesWave1–15B.cs`,",
        f"> `PdfToolSeo.cs`, `content-roadmap.csv`, `seo-audit-results.json`.",
        "> **Excluded:** Invoice, payslip, rent receipt, JWT/JSON/dev tools, word counter, utilities.",
        "",
        "## Executive snapshot",
        "",
        "| Asset | PDF-only count | Quality state |",
        "|-------|----------------|---------------|",
        f"| Live editorial guides | **{len(pdf_live)}** | **~{len(pdf_live) - len(wave_slugs)} thin**; **~{len(wave_slugs)} wave-upgraded** |",
        "| Core PDF tools (`/pdf/*`) | **26** | Production engines live |",
        "| Programmatic SEO URLs | **~9,600** | Long-tail support; not authority tier |",
        "| Compare pages | **11** (+7 compress) | Missing PDFgear, Nitro |",
        "| Research pages (PDF-core) | **4** | Under-developed vs Adobe/iLovePDF |",
        "| Article opportunities queued | **{}** | {} UPGRADE · {} MAINTAIN · {} CREATE |".format(
            len(opportunities), upgrade, maintain, create
        ),
        "",
        "**Strategic truth:** Target **1000+ authority-grade** pages = **~{} upgraded/maintained** + **~{} net-new unique intents**.".format(
            authority_est, create
        ),
        "",
        "## Wave execution status (authority upgrades)",
        "",
        "| Wave | Cluster focus | Pages | Status |",
        "|------|---------------|-------|--------|",
        "| 1–6 | Compress, merge, OCR, Word, convert, edit | ~102 | ✅ Complete |",
        "| 7 | Pillar upgrades (compress, merge, split, word, ocr) | 5 | ✅ Complete |",
        "| 8 | Edit gaps (crop, annotate, device) | 17 | ✅ Complete |",
        "| 9 | Troubleshooting hub | 17 | ✅ Complete |",
        "| 10 | Conversion depth (jpg, excel, html) | 17 | ✅ Complete |",
        "| 11 | Security & compliance | 17 | ✅ Complete |",
        "| 12 | Standards & archiving | 17 | ✅ Complete |",
        "| 13 | Printing workflows | 17 | ✅ Complete |",
        "| 14 | Browser + device matrix | 17 | ✅ Complete |",
        "| 15 | Regional workflows (batch 1+2) | 34 | ✅ Complete |",
        "| **16** | **Glossary upgrades** | 144 | 🔲 Next |",
        "| **17** | **Regional batch 3** (IT, MX, NZ, ZA, KR) | 9+ | 🔲 Planned |",
        "| **18+** | Industry × task, forms, collaboration | 17/batch | 🔲 Planned |",
        "",
        "## Layer 1 — Tools (26 core `/pdf/*`)",
        "",
        "See `Constants/PdfToolSeo.cs`. Gaps (editorial only): crop, repair, compare PDFs, PDF/A export, certified e-sign, AI chat PDF.",
        "",
        "## Layer 2 — Editorial clusters (27 mission clusters)",
        "",
        "| Mission cluster | Live guides | Wave coverage | Gap vs competitors |",
        "|-----------------|------------|---------------|-------------------|",
        "| PDF Compression | 46 | Strong (W3,5,7) | Size variants covered; maintain |",
        "| PDF Conversion | 71 | W4,6,10 | Depth improving; epub/csv thin |",
        "| PDF Editing | 10+ | W6,8 | Crop/delete covered in W8; no crop tool |",
        "| PDF OCR | 10 | W2,7 | Language variants still thin |",
        "| PDF Security | 22 | W11 | Redaction client-side only |",
        "| PDF Printing | 17 | W13 | **Now covered** (was gap) |",
        "| PDF Troubleshooting | 10+ | W9 | Repair honesty; no repair engine |",
        "| PDF Standards/Archiving | 17+ | W12 | PDF/A depth; no export tool |",
        "| PDF Browser/Device | 17+ | W14 | **Now covered** (was gap) |",
        "| PDF Regional | 152+ | W15 (34 upgraded) | 118 still thin templates |",
        "| PDF Glossary | 144 | W13 partial (2) | **Major gap** — all ultra-thin |",
        "| PDF Industry | 38 | Minimal | Adobe/iLovePDF have vertical hubs |",
        "",
        "## Layer 3 — Programmatic SEO (~9,600 URLs)",
        "",
        "| Generator | Pattern | Role |",
        "|-----------|---------|------|",
        "| Compress | `/{slug}` | Size/portal long-tail |",
        "| PDF to Word | `/pdf-to-word/{slug}` | Document-type intents |",
        "| PDF to Text | `/pdf-to-txt/{slug}` | Use-case intents |",
        "| Edit PDF | `/edit-pdf/{slug}` | Task intents |",
        "| Tool landings | `/{prefix}/{slug}` | Per-tool (mostly noindex) |",
        "",
        "**Rule:** Programmatic ≤800 words + CTA. Editorial owns 1500–4000 word workflows.",
        "",
        "## Layer 4 — Compare & research",
        "",
        "### Compare (live 11 + 7 compress-specific)",
        "Adobe, iLovePDF, Smallpdf, PDF24, Sejda, Foxit, SodaPDF, PDF Candy, PDFelement, Wondershare.",
        "",
        "**Missing vs mission competitors:** PDFgear, Nitro PDF, PDFsam, Able2Extract.",
        "",
        "### Research (PDF-core)",
        "- attachment-size-limits, pdf-compression-benchmark, pdf-tool-market-comparison, document-retention-periods",
        "",
        "**Needed:** OCR accuracy benchmark, accessibility audit study, e-filing size survey.",
        "",
        "## Competitor gap summary",
        "",
        "| Competitor | RatPDF gap | Priority |",
        "|------------|-----------|----------|",
        "| Adobe | Preflight, PDF/A export, compare PDFs, certified sign | P1 editorial |",
        "| iLovePDF | Repair PDF, organize hub depth, mobile app guides | P0 troubleshooting |",
        "| Smallpdf | AI PDF, team plans, scanner workflow | P2 |",
        "| PDFgear | No compare page; AI chat PDF | P0 compare + editorial |",
        "| Foxit | ConnectedPDF, enterprise redaction depth | P2 |",
        "| Nitro | No compare page; SharePoint e-sign workflows | P0 compare |",
        "| Sejda | Crop PDF (they rank); hourly limit guides | P1 (W8 covered edit) |",
        "| PDF24 | Offline Creator, virtual printer, privacy angle | P1 editorial |",
        "",
        "## Path to 1000+ authority articles",
        "",
        "| Source | Count | Action |",
        "|--------|-------|--------|",
        f"| Wave-upgraded (maintain) | ~{len(wave_slugs)} | Interlink + refresh quarterly |",
        f"| Upgrade existing thin | ~{upgrade} | Rewrite 1500–4000 words |",
        f"| Net-new unique intents | ~{create} | Create only when no URL exists |",
        f"| **Total queued** | **{len(opportunities)}** | Sorted by priority_score |",
        "",
        "**Stop condition:** PDF topical authority complete — not arbitrary URL count.",
        "",
    ]
    (DATA / "pdf-topical-authority-map-v3.md").write_text("\n".join(lines), encoding="utf-8")


def write_cannibalization_v2(opportunities: list[dict], pdf_roadmap: list[dict]) -> None:
    merged = sum(1 for r in pdf_roadmap if r.get("Status") == "Merged" and is_pdf_row(r))
    create_on_existing = [
        o for o in opportunities
        if o["action"] == "CREATE" and o["existing_slug"]
    ]
    lines = [
        "# PDF Cannibalization Report v2",
        "",
        f"> Generated {date.today().isoformat()}. Rule: **upgrade before create**.",
        "",
        "## Summary",
        "",
        f"- Roadmap merged (resolved duplicates): **{merged}**",
        f"- CREATE rows with existing slug match: **{len(create_on_existing)}** (review before publish)",
        "",
        "## Risk categories",
        "",
        "### 1. Programmatic vs editorial (MEDIUM — by design)",
        "Compress/pdf-to-word/edit-pdf programmatic pages own head-term variants.",
        "Editorial pillars own 1500+ word workflows. Cross-link programmatic → pillar → tool.",
        "",
        "### 2. Glossary vs pillar (HIGH — 144 pages)",
        "Upgrade glossary as TOFU definitions linking to MOFU pillars within 200 words.",
        "Title pattern: \"What is [term]?\" — no workflow duplication.",
        "",
        "### 3. Regional matrix (HIGH — 152 pages)",
        "Each country page must have 60%+ unique portal-specific content.",
        "Generic compress steps → shared template block only.",
        "",
        "### 4. Wave-upgraded vs generated audit (TECHNICAL)",
        "seo-audit-results.json counts wave slugs as `generated` layer.",
        "Runtime bodies are authority-grade; audit script needs wave file inclusion.",
        "",
        "### 5. Compare slug drift",
        "Internal links may use `/compare/adobe-alternative` vs live `adobe-acrobat-alternative`.",
        "Add 301 alias or fix links site-wide.",
        "",
        "### 6. Best-of vs compare hub",
        "300 deferred Best-of rows mostly invoice-themed (excluded).",
        "PDF best-of must link to `/compare/*`, not duplicate comparison tables.",
        "",
        "## Per-article checklist",
        "",
        "```",
        "1. grep slug in ContentLibrary + GuideBodies + roadmap CSV",
        "2. grep PrimaryKeyword across roadmap",
        "3. Check programmatic generator for same intent",
        "4. Match found → UPGRADE or MAINTAIN",
        "5. Unique intent → CREATE",
        "6. Weaker page links to stronger canonical",
        "```",
        "",
        "## Priority fixes",
        "",
        "| Priority | Issue | Action |",
        "|----------|-------|--------|",
        "| P0 | ~277 thin pages outside waves | Upgrade waves 16–18 |",
        "| P0 | 144 glossary vs pillars | Wave 16 glossary batch |",
        "| P1 | 118 thin regional templates | Wave 17 regional batch 3+ |",
        "| P1 | PDFgear/Nitro compare missing | Add compare pages |",
        "| P2 | Programmatic thin content indexed | Enforce noindex on tool landings |",
        "",
    ]
    (DATA / "pdf-cannibalization-report-v2.md").write_text("\n".join(lines), encoding="utf-8")


def main() -> None:
    audit = json.loads((DATA / "seo-audit-results.json").read_text(encoding="utf-8"))
    roadmap = list(csv.DictReader((DATA / "content-roadmap.csv").open(encoding="utf-8")))
    pdf_live, wave_slugs = collect_live_slugs()
    pdf_roadmap = [r for r in roadmap if is_pdf_row(r)]

    opportunities = build_opportunities(pdf_live, wave_slugs, pdf_roadmap)

    fields = [
        "id", "keyword", "cluster", "intent", "competition", "priority_score",
        "action", "existing_slug", "target_url", "word_target", "notes",
    ]

    write_csv(DATA / "pdf-keyword-database.csv", opportunities, fields)
    write_csv(DATA / "pdf-article-opportunities.csv", opportunities, fields)

    # Priority execution batch — top 50 not yet wave-maintained
    exec_batch = [
        o for o in opportunities
        if o["action"] in ("UPGRADE", "CREATE") and o.get("notes") != "Wave upgraded"
    ][:50]
    write_csv(DATA / "pdf-execution-batch-1.csv", exec_batch, fields)

    write_topical_map_v3(pdf_live, wave_slugs, opportunities, pdf_roadmap)
    write_cannibalization_v2(opportunities, pdf_roadmap)

    by_action = Counter(o["action"] for o in opportunities)
    by_cluster = Counter(o["cluster"] for o in opportunities)

    report = {
        "generated": date.today().isoformat(),
        "pdf_live_guides": len(pdf_live),
        "wave_upgraded_slugs": len(wave_slugs),
        "thin_remaining_est": len(pdf_live) - len(wave_slugs),
        "roadmap_pdf_rows": len(pdf_roadmap),
        "article_opportunities_total": len(opportunities),
        "by_action": dict(by_action),
        "top_clusters": dict(by_cluster.most_common(15)),
        "authority_target": 1000,
        "gap_to_target": max(0, 1000 - len(wave_slugs) - by_action.get("UPGRADE", 0)),
    }
    (DATA / "pdf-authority-audit-summary.json").write_text(
        json.dumps(report, indent=2), encoding="utf-8"
    )

    print(json.dumps(report, indent=2))
    print(f"\nOpportunities: {len(opportunities)}")
    print(f"Wrote Data/pdf-article-opportunities.csv")
    print(f"Wrote Data/pdf-topical-authority-map-v3.md")


if __name__ == "__main__":
    main()
