#!/usr/bin/env python3
"""PDF-only authority audit — tools, guides, gaps, keywords, cannibalization."""
import csv
import json
import re
from collections import Counter, defaultdict
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]
DATA = ROOT / "Data"

NON_PDF = re.compile(
    r"invoice|payslip|rent.receipt|salary.slip|gst.invoice|vat.invoice|e-invoicing|"
    r"hmrc.invoice|word.counter|ring.size|my.ip|background.remover|json.formatter|"
    r"jwt|html.formatter|developer.tools|dns.lookup|calculator|bulk.payslip|"
    r"free.payslip|rent.receipt",
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

COMPETITOR_TOPICS = {
    "Adobe Acrobat": [
        "edit pdf", "ocr pdf", "compare pdf", "redact pdf", "fill sign", "pdf accessibility",
        "pdf standards pdf/a", "acrobat reader vs pro", "batch processing", "preflight print",
        "action wizard", "bates numbering", "portfolio pdf", "3d pdf", "measurement tools",
    ],
    "iLovePDF": [
        "merge split compress convert", "pdf to jpg", "repair pdf", "organize pdf",
        "remove pages", "crop pdf", "add page numbers", "watermark", "sign pdf",
        "unlock pdf", "rotate pdf", "pdf to word excel ppt", "html to pdf", "compress pdf",
        "mobile app workflows", "desktop app",
    ],
    "Smallpdf": [
        "compress merge split convert", "esign", "ai pdf", "pdf reader", "pdf scanner",
        "team plans", "gdpr compliance", "browser extension", "desktop app",
        "pdf to word quality", "delete pages", "extract pages",
    ],
    "PDFgear": [
        "free adobe alternative", "ai chat pdf", "annotate pdf", "edit text in pdf",
        "convert pdf", "ocr", "merge split", "windows mac ios android",
    ],
    "Foxit": [
        "pdf editor business", "connectedpdf", "esign", "redaction", "accessibility",
        "pdf/a compliance", "legal discovery", "batch ocr", "plugin integrations",
    ],
    "Nitro PDF": [
        "business pdf editor", "esign workflows", "batch conversion", "ocr",
        "redaction", "forms", "sharepoint integration", "compliance",
    ],
    "Sejda": [
        "online pdf tasks", "hourly limits", "crop pdf", "fill form", "sign",
        "compress", "merge split", "desktop pro", "privacy focused",
    ],
    "PDF24": [
        "free pdf creator", "virtual printer", "fax send", "merge split compress",
        "ocr", "creator desktop", "no upload privacy", "offline tools",
    ],
}

KEYWORD_SEEDS = {
    "PDF Compression": [
        ("compress pdf online", "transactional", 95, "medium"),
        ("compress pdf for email", "problem", 92, "low"),
        ("reduce pdf file size", "transactional", 90, "medium"),
        ("compress pdf without losing quality", "informational", 88, "medium"),
        ("compress pdf for gmail", "problem", 87, "low"),
        ("compress pdf made file larger", "problem", 85, "low"),
        ("batch compress pdf", "workflow", 84, "low"),
        ("compress scanned pdf", "problem", 83, "medium"),
        ("compress pdf for government portal", "problem", 90, "low"),
        ("ghostscript compress pdf", "informational", 78, "low"),
    ],
    "PDF Conversion": [
        ("pdf to word", "transactional", 98, "high"),
        ("word to pdf", "transactional", 96, "high"),
        ("pdf to excel", "transactional", 88, "medium"),
        ("pdf to powerpoint", "transactional", 82, "medium"),
        ("pdf to jpg", "transactional", 94, "high"),
        ("pdf to text", "transactional", 86, "medium"),
        ("html to pdf", "transactional", 85, "medium"),
        ("images to pdf", "transactional", 90, "medium"),
        ("pdf to word keep formatting", "problem", 91, "medium"),
        ("scanned pdf to word", "problem", 89, "medium"),
    ],
    "PDF OCR": [
        ("ocr pdf online", "transactional", 92, "medium"),
        ("make scanned pdf searchable", "problem", 88, "low"),
        ("ocr pdf hindi", "transactional", 80, "low"),
        ("ocr vs pdf to text", "comparison", 79, "low"),
        ("tesseract ocr pdf", "informational", 75, "low"),
        ("ocr pdf for discovery", "workflow", 82, "low"),
    ],
    "PDF Editing": [
        ("edit pdf online", "transactional", 94, "high"),
        ("edit pdf without adobe", "comparison", 90, "medium"),
        ("add text to pdf", "transactional", 88, "medium"),
        ("add image to pdf", "transactional", 84, "low"),
        ("organize pdf pages", "transactional", 83, "medium"),
        ("crop pdf online", "transactional", 86, "high"),
        ("delete pages from pdf", "transactional", 85, "high"),
        ("annotate pdf online", "transactional", 82, "medium"),
    ],
    "PDF Security": [
        ("password protect pdf", "transactional", 90, "medium"),
        ("unlock pdf", "transactional", 88, "medium"),
        ("redact pdf permanently", "problem", 87, "low"),
        ("watermark pdf", "transactional", 84, "medium"),
        ("remove password from pdf", "problem", 86, "medium"),
        ("encrypt pdf aes", "informational", 78, "low"),
    ],
    "PDF Signing": [
        ("sign pdf online", "transactional", 89, "medium"),
        ("electronically sign pdf legally", "informational", 86, "medium"),
        ("add signature to pdf", "transactional", 88, "medium"),
        ("fill and sign pdf", "transactional", 85, "medium"),
    ],
    "PDF Forms": [
        ("fill pdf form online", "transactional", 87, "medium"),
        ("flatten pdf forms", "transactional", 80, "low"),
        ("create fillable pdf", "informational", 84, "medium"),
        ("edit pdf form fields", "problem", 82, "low"),
    ],
    "PDF Accessibility": [
        ("pdf accessibility wcag", "compliance", 83, "medium"),
        ("tagged pdf checklist", "compliance", 80, "low"),
        ("screen reader pdf", "problem", 78, "low"),
        ("section 508 pdf", "compliance", 81, "low"),
        ("remediate pdf accessibility", "workflow", 79, "low"),
    ],
    "PDF Troubleshooting": [
        ("pdf won't open", "problem", 90, "medium"),
        ("pdf file corrupted", "problem", 88, "medium"),
        ("pdf too large to email", "problem", 92, "low"),
        ("pdf printing blank pages", "problem", 85, "medium"),
        ("pdf fonts missing", "problem", 83, "medium"),
        ("pdf attachment blocked", "problem", 86, "low"),
    ],
    "PDF Standards": [
        ("pdf/a archival", "compliance", 82, "medium"),
        ("pdf/x print standard", "compliance", 76, "low"),
        ("pdf/ua accessibility", "compliance", 78, "low"),
        ("convert to pdf/a", "workflow", 80, "low"),
    ],
    "PDF for Visas": [
        ("compress pdf for visa application", "problem", 91, "low"),
        ("merge pdf for visa documents", "workflow", 88, "low"),
        ("bank statement pdf visa", "workflow", 86, "medium"),
        ("passport scan pdf size", "problem", 87, "low"),
    ],
    "PDF for Legal Documents": [
        ("merge pdf court filing", "workflow", 85, "low"),
        ("bates numbering pdf", "workflow", 82, "medium"),
        ("redact pdf discovery", "workflow", 84, "low"),
        ("ocr pdf legal documents", "workflow", 83, "low"),
    ],
    "PDF Mac Workflows": [
        ("compress pdf on mac", "device", 86, "low"),
        ("merge pdf on mac preview", "device", 84, "medium"),
        ("pdf to word on mac", "device", 88, "medium"),
    ],
    "PDF Windows Workflows": [
        ("compress pdf on windows", "device", 86, "low"),
        ("merge pdf windows 11", "device", 83, "medium"),
        ("print to pdf windows", "device", 85, "medium"),
    ],
    "PDF Mobile Workflows": [
        ("compress pdf on iphone", "device", 87, "low"),
        ("merge pdf on android", "device", 82, "medium"),
        ("scan to pdf phone", "workflow", 90, "medium"),
    ],
}


def is_pdf_slug(slug: str) -> bool:
    return bool(slug) and not NON_PDF.search(slug)


def slug_from_url(url: str) -> str:
    return url.replace("/guides/", "").strip("/")


def main():
    audit = json.loads((DATA / "seo-audit-results.json").read_text(encoding="utf-8"))
    roadmap = list(csv.DictReader((DATA / "content-roadmap.csv").open(encoding="utf-8")))

    def row_slug(r):
        url = r.get("RecommendedURL") or r.get("URL") or ""
        if url.startswith("/guides/"):
            return slug_from_url(url)
        # best-of etc. map to slug from keyword
        kw = (r.get("PrimaryKeyword") or r.get("Keyword") or "").lower()
        return re.sub(r"[^a-z0-9]+", "-", kw).strip("-") if kw else ""

    def is_pdf_row(r):
        cluster = (r.get("Cluster") or "").lower()
        if cluster in ("invoice", "payslip"):
            return False
        slug = row_slug(r)
        kw = (r.get("PrimaryKeyword") or "") + " " + (r.get("SecondaryKeywords") or "")
        return not NON_PDF.search(cluster + " " + slug + " " + kw)

    # Live guides from all body files
    live = set()
    for name in ["GuideBodies.cs", "GuideBodiesExtended.cs", "GuideBodiesGenerated.cs"] + [
        f"GuideBodiesWave{i}.cs" for i in range(1, 7)
    ] + ["GuideBodiesMedicalImageDev.cs"]:
        p = ROOT / "Content" / name
        if p.exists():
            live.update(re.findall(r'"([\w-]+)" =>', p.read_text(encoding="utf-8")))

    pdf_live = sorted(s for s in live if is_pdf_slug(s))
    print(f"PDF live guides: {len(pdf_live)} / {len(live)} total")

    # Roadmap analysis
    by_status = Counter(r.get("Status") for r in roadmap)
    pdf_roadmap = [r for r in roadmap if is_pdf_row(r)]
    cluster_counts = Counter(r.get("Cluster") for r in pdf_roadmap)

    # Map to user clusters
    user_cluster_coverage = Counter()
    for r in pdf_roadmap:
        c = r.get("Cluster", "")
        user_cluster_coverage[CLUSTER_MAP.get(c, "Other")] += 1

    # Thin content from audit cluster_gaps (PDF only)
    gaps = audit["summary"].get("cluster_gaps", {})
    pdf_gaps = {k: v for k, v in gaps.items() if k not in ("Invoice", "Payslip")}

    # Build keyword rows
    kw_rows = []
    opp_id = 0
    live_set = set(pdf_live)
    roadmap_by_slug = {}
    for r in pdf_roadmap:
        s = row_slug(r)
        if s:
            roadmap_by_slug[s] = r

    for cluster, seeds in KEYWORD_SEEDS.items():
        for kw, intent, score, comp in seeds:
            opp_id += 1
            slug_guess = re.sub(r"[^a-z0-9]+", "-", kw.lower()).strip("-")
            existing = None
            action = "CREATE"
            for s in live_set:
                if slug_guess in s or s.replace("-", " ") in kw:
                    existing = s
                    action = "UPGRADE"
                    break
            if slug_guess in roadmap_by_slug:
                existing = slug_guess
                st = roadmap_by_slug[slug_guess].get("Status")
                action = "UPGRADE" if st == "Published" else "PLANNED"
            priority = score
            if action == "UPGRADE":
                priority += 5  # fix thin before new
            kw_rows.append({
                "id": opp_id,
                "keyword": kw,
                "cluster": cluster,
                "intent": intent,
                "competition": comp,
                "priority_score": priority,
                "existing_slug": existing or "",
                "action": action,
                "target_url": f"/guides/{existing}" if existing else f"/guides/{slug_guess}",
            })

    # Expand to 200+ opportunity rows from roadmap deferred + gap topics
    gap_topics = [
        ("repair pdf online", "PDF Troubleshooting", "problem", 88, "medium"),
        ("crop pdf online", "PDF Editing", "transactional", 90, "high"),
        ("delete pages from pdf", "PDF Editing", "transactional", 89, "high"),
        ("pdf to epub", "PDF Conversion", "transactional", 75, "low"),
        ("pdf to csv", "PDF Conversion", "transactional", 72, "low"),
        ("annotate pdf free", "PDF Editing", "transactional", 84, "medium"),
        ("highlight pdf online", "PDF Editing", "transactional", 80, "medium"),
        ("compare two pdfs", "PDF Collaboration", "transactional", 86, "medium"),
        ("blackout text in pdf", "PDF Security", "problem", 85, "medium"),
        ("remove watermark from pdf", "PDF Security", "problem", 82, "high"),
        ("print pdf without margins", "PDF Printing", "problem", 83, "medium"),
        ("pdf colors wrong when printing", "PDF Printing", "problem", 81, "low"),
        ("save email as pdf", "PDF Workflows", "workflow", 84, "medium"),
        ("combine pdf and word", "PDF Workflows", "workflow", 78, "low"),
        ("pdf portfolio merge", "PDF Workflows", "workflow", 74, "low"),
        ("pdf/a conversion online", "PDF Standards", "compliance", 80, "low"),
        ("pdf accessibility checker", "PDF Accessibility", "compliance", 82, "medium"),
        ("hipaa compliant pdf email", "PDF Compliance", "compliance", 79, "low"),
        ("gdpr pdf redaction workflow", "PDF Compliance", "compliance", 81, "low"),
        ("chrome save as pdf settings", "PDF Browser Workflows", "device", 80, "low"),
        ("edge print to pdf", "PDF Browser Workflows", "device", 79, "low"),
        ("pdfgear vs adobe", "PDF Collaboration", "comparison", 77, "low"),
        ("nitro pdf alternative", "PDF Collaboration", "comparison", 76, "low"),
        ("sejda vs ilovepdf", "PDF Collaboration", "comparison", 75, "low"),
        ("pdf24 creator alternative", "PDF Collaboration", "comparison", 74, "low"),
        ("student combine lecture pdfs", "PDF for Students", "workflow", 82, "low"),
        ("submit homework pdf canvas", "PDF for Students", "problem", 84, "medium"),
        ("ats friendly pdf resume", "PDF for Job Applications", "problem", 88, "medium"),
        ("linkedin save profile as pdf", "PDF for Job Applications", "workflow", 80, "low"),
        ("uscis pdf upload requirements", "PDF for Visas", "compliance", 86, "low"),
        ("ukvi pdf document rules", "PDF for Visas", "compliance", 85, "low"),
        ("schengen visa pdf merge order", "PDF for Visas", "workflow", 84, "low"),
        ("irs pdf form fill online", "PDF for Government Forms", "workflow", 87, "medium"),
        ("dmv upload pdf size limit", "PDF for Government Forms", "problem", 83, "low"),
        ("contract pdf redline workflow", "PDF for Legal Documents", "workflow", 86, "low"),
        ("discovery pdf bates stamp", "PDF for Legal Documents", "workflow", 85, "low"),
        ("accountant client pdf portal", "PDF for Businesses", "workflow", 80, "low"),
        ("real estate disclosure pdf merge", "PDF for Businesses", "workflow", 82, "low"),
        ("insurance claim pdf photos", "PDF for Businesses", "workflow", 83, "low"),
        ("archive pdf long term storage", "PDF Archiving", "informational", 78, "low"),
        ("pdf metadata remove", "PDF Security", "problem", 79, "low"),
        ("pdf javascript security risk", "PDF Security", "informational", 76, "low"),
        ("collaborate pdf review comments", "PDF Collaboration", "workflow", 77, "low"),
        ("pdf comment export", "PDF Collaboration", "workflow", 74, "low"),
    ]
    for kw, cluster, intent, score, comp in gap_topics:
        opp_id += 1
        slug_guess = re.sub(r"[^a-z0-9]+", "-", kw.lower()).strip("-")
        existing = next((s for s in live_set if slug_guess in s), "")
        action = "UPGRADE" if existing else "CREATE"
        kw_rows.append({
            "id": opp_id,
            "keyword": kw,
            "cluster": cluster,
            "intent": intent,
            "competition": comp,
            "priority_score": score + (5 if action == "UPGRADE" else 0),
            "existing_slug": existing,
            "action": action,
            "target_url": f"/guides/{existing}" if existing else f"/guides/{slug_guess}",
        })

    # Write keyword database
    out_csv = DATA / "pdf-keyword-database.csv"
    fields = ["id", "keyword", "cluster", "intent", "competition", "priority_score",
              "action", "existing_slug", "target_url"]
    with out_csv.open("w", newline="", encoding="utf-8") as f:
        w = csv.DictWriter(f, fieldnames=fields)
        w.writeheader()
        w.writerows(sorted(kw_rows, key=lambda x: -x["priority_score"]))

    # Cannibalization: roadmap merged + duplicate intents
    merged = [r for r in pdf_roadmap if r.get("Status") == "Merged"]
    published = [r for r in pdf_roadmap if r.get("Status") == "Published"]
    deferred = [r for r in pdf_roadmap if r.get("Status") == "Deferred"]

    cannibal = []
    kw_index = defaultdict(list)
    for r in published + deferred:
        kw = (r.get("PrimaryKeyword") or r.get("Keyword") or "").lower().strip()
        url = r.get("RecommendedURL") or r.get("URL") or ""
        if kw:
            kw_index[kw].append(url)
    for kw, urls in kw_index.items():
        if len(urls) > 1:
            cannibal.append({"keyword": kw, "urls": urls, "risk": "high"})

    # Article opportunities to reach 1000+ (count unique intents in roadmap + gaps)
    unique_intents = len(pdf_roadmap) + len([k for k in kw_rows if k["action"] == "CREATE"])

    report = {
        "pdf_live_guides": len(pdf_live),
        "roadmap_pdf_rows": len(pdf_roadmap),
        "published_pdf_roadmap": len(published),
        "deferred_pdf": len(deferred),
        "merged_pdf": len(merged),
        "thin_cluster_gaps": pdf_gaps,
        "user_cluster_coverage": dict(user_cluster_coverage),
        "keyword_opportunities": len(kw_rows),
        "cannibalization_risks": len(cannibal),
        "unique_editorial_potential": unique_intents,
    }
    (DATA / "pdf-authority-audit-summary.json").write_text(
        json.dumps(report, indent=2), encoding="utf-8"
    )

    # Opportunities CSV — top 100 priority
    opp_csv = DATA / "pdf-article-opportunities.csv"
    with opp_csv.open("w", newline="", encoding="utf-8") as f:
        w = csv.DictWriter(f, fieldnames=fields)
        w.writeheader()
        for row in sorted(kw_rows, key=lambda x: -x["priority_score"])[:200]:
            w.writerow(row)

    print(json.dumps(report, indent=2))
    print(f"\nWrote {out_csv}")
    print(f"Wrote {opp_csv}")
    print(f"Wrote {DATA / 'pdf-authority-audit-summary.json'}")


if __name__ == "__main__":
    main()
