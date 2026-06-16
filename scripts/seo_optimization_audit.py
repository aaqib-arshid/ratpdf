#!/usr/bin/env python3
"""Comprehensive SEO optimization audit — no content generation."""
import csv
import json
import re
from collections import Counter, defaultdict
from html import unescape
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]
CONTENT = ROOT / "Content"
DATA = ROOT / "Data"
OUT = ROOT / "Data" / "seo-audit-results.json"

BODY_FILES = {
    "hand_core": CONTENT / "GuideBodies.cs",
    "hand_extended": CONTENT / "GuideBodiesExtended.cs",
    "hand_medical": CONTENT / "GuideBodiesMedicalImageDev.cs",
    "generated": CONTENT / "GuideBodiesGenerated.cs",
}
LIB = CONTENT / "ContentLibrary.cs"
ROADMAP = DATA / "content-roadmap.csv"

SWITCH_CASE_RE = re.compile(
    r'"([a-z0-9-]+)"(?:\s+or\s+"([a-z0-9-]+)")?\s*=>\s*([A-Za-z0-9_]+)'
)
BODY_CONST_RE = re.compile(
    r'private const string ([A-Za-z0-9_]+)\s*=\s*"""(.*?)"""',
    re.DOTALL,
)
LIB_SLUG_FAQ_RE = re.compile(
    r'\("([a-z0-9-]+)"[\s\S]*?\[[\s\S]*?"[\s\S]*?\],\s*\[[\s\S]*?"[\s\S]*?\]\s*\)',
)
LINK_RE = re.compile(r'href="(/[^"#?]+)"', re.I)
H2_RE = re.compile(r"<h2[^>]*>(.*?)</h2>", re.I | re.S)

TEMPLATE_MARKERS = {
    "general_open": re.compile(r"Practical guide:.*Uses RatPDF tools documented", re.I),
    "general_steps": re.compile(r"Use .* per on-screen steps", re.I),
    "verify_archive": re.compile(r"Verify output; archive original", re.I),
    "raw_path_anchor": re.compile(r'<a href="/guides/[^"]+">/guides/', re.I),
    "compress_levels": re.compile(r"Recommended.*Low.*High.*Maximum", re.I | re.S),
    "topic_inject": re.compile(r"Topic: ", re.I),
}

TRAFFIC_SCORE = {"High": 3, "Medium": 2, "Low": 1, "": 1}
PRIORITY_SCORE = {"P0": 3, "P1": 2, "P2": 1, "": 1}
FUNNEL_SCORE = {"BOFU": 3, "MOFU": 2, "TOFU": 1, "": 1}
INTENT_SCORE = {"Transactional": 3, "Commercial": 2.5, "Informational": 1.5, "": 1}


def parse_switch_slugs(path: Path) -> dict[str, str]:
    """Map slug -> const name from switch expression."""
    text = path.read_text(encoding="utf-8")
    mapping: dict[str, str] = {}
    for m in SWITCH_CASE_RE.finditer(text):
        slug1, slug2, const = m.groups()
        if const in ("Get", "GuideBodiesExtended", "GuideBodiesGenerated"):
            continue
        mapping[slug1] = const
        if slug2:
            mapping[slug2] = const
    return mapping


def parse_const_bodies(path: Path) -> dict[str, str]:
    text = path.read_text(encoding="utf-8")
    return {m.group(1): m.group(2) for m in BODY_CONST_RE.finditer(text)}


def parse_bodies() -> dict[str, dict]:
    layers = [
        ("hand_core", BODY_FILES["hand_core"]),
        ("hand_extended", BODY_FILES["hand_extended"]),
        ("hand_medical", BODY_FILES["hand_medical"]),
        ("generated", BODY_FILES["generated"]),
    ]
    layer_rank = {"generated": 0, "hand_extended": 1, "hand_core": 2}
    bodies: dict[str, dict] = {}
    for layer, path in layers:
        if not path.exists():
            continue
        slug_to_const = parse_switch_slugs(path)
        const_to_html = parse_const_bodies(path)
        for slug, const in slug_to_const.items():
            html = const_to_html.get(const, "")
            if layer == "hand_medical":
                continue
            if slug in bodies and layer_rank.get(bodies[slug]["layer"], 0) >= layer_rank[layer]:
                continue
            bodies[slug] = {"layer": layer, "html": html}
    return bodies


def parse_library_meta() -> dict[str, dict]:
    text = LIB.read_text(encoding="utf-8").split("BuildBlogs")[0]
    meta: dict[str, dict] = {}
    faq_slugs = set(LIB_SLUG_FAQ_RE.findall(text))
    for m in re.finditer(
        r'\("([a-z0-9-]+)",\s*"((?:[^"\\]|\\.)*)"\s*,\s*"((?:[^"\\]|\\.)*)"\s*,\s*"([^"]*)"\s*,\s*([^,\n]+)',
        text,
    ):
        slug, title, desc, cat, tool = m.groups()
        tool = tool.strip().strip('"')
        if tool == "null":
            tool = None
        meta[slug] = {
            "title": title.replace('\\"', '"'),
            "desc": desc.replace('\\"', '"'),
            "cat": cat,
            "tool": tool,
            "has_faq": slug in faq_slugs,
        }
    return meta


def strip_html(html: str) -> str:
    text = re.sub(r"<script[^>]*>.*?</script>", " ", html, flags=re.I | re.S)
    text = re.sub(r"<style[^>]*>.*?</style>", " ", text, flags=re.I | re.S)
    text = re.sub(r"<[^>]+>", " ", text)
    text = unescape(text)
    text = re.sub(r"\s+", " ", text).strip()
    return text


def word_count(html: str) -> int:
    text = strip_html(html)
    return len(text.split()) if text else 0


def parse_roadmap() -> dict[str, dict]:
    rows: dict[str, dict] = {}
    if not ROADMAP.exists():
        return rows
    with ROADMAP.open(encoding="utf-8-sig") as f:
        for row in csv.DictReader(f):
            url = row.get("RecommendedURL", "")
            if not url.startswith("/guides/"):
                continue
            slug = url.replace("/guides/", "").strip()
            if not slug:
                continue
            rows[slug] = {
                "cluster": row.get("Cluster", ""),
                "keyword": row.get("PrimaryKeyword", ""),
                "intent": row.get("SearchIntent", ""),
                "audience": row.get("Audience", ""),
                "funnel": row.get("FunnelStage", ""),
                "traffic": row.get("TrafficPotential", ""),
                "priority": row.get("Priority", ""),
                "status": row.get("Status", ""),
                "tool_url": row.get("ToolURL", ""),
                "internal_links": [
                    x.strip()
                    for x in row.get("InternalLinks", "").split(";")
                    if x.strip()
                ],
                "word_target": row.get("WordCountTarget", ""),
            }
    return rows


def template_score(html: str) -> int:
    return sum(1 for rx in TEMPLATE_MARKERS.values() if rx.search(html))


def has_section(html: str, keywords: list[str]) -> bool:
    h2s = [strip_html(h).lower() for h in H2_RE.findall(html)]
    joined = " ".join(h2s)
    return any(k in joined for k in keywords)


def audit_guides(bodies, lib_meta, roadmap):
    records = []
    all_outbound = Counter()
    inbound = Counter()

    for slug, body in bodies.items():
        html = body["html"]
        wc = word_count(html)
        links = LINK_RE.findall(html)
        for l in links:
            all_outbound[l] += 1
            inbound[l] += 1

        rm = roadmap.get(slug, {})
        lm = lib_meta.get(slug, {})
        tpl = template_score(html)
        layer = body["layer"]

        target = rm.get("word_target", "")
        target_min = 0
        if target and "-" in target:
            try:
                target_min = int(target.split("-")[0].replace(",", ""))
            except ValueError:
                pass

        issues = []
        if layer == "generated" and wc < 500:
            issues.append("thin")
        if tpl >= 3:
            issues.append("template_footprint")
        if tpl >= 1 and layer == "generated":
            issues.append("low_value_template")
        if not lm.get("has_faq") and not rm:
            issues.append("missing_faq")
        elif not lm.get("has_faq"):
            issues.append("missing_faq")
        if wc < 300:
            issues.append("ultra_thin")
        if not has_section(html, ["faq", "question"]):
            issues.append("no_faq_in_body")
        if not has_section(html, ["related", "next step", "checklist", "summary", "conclusion"]):
            issues.append("weak_conclusion")
        if not links:
            issues.append("no_internal_links")
        if not any(l.startswith("/pdf") or l.startswith("/PDF") or l.startswith("/invoice") for l in links):
            if lm.get("tool") or rm.get("tool_url"):
                issues.append("missing_tool_link")
        if not any("/research/" in l for l in links):
            if "compress" in slug or rm.get("cluster", "").lower().find("compress") >= 0:
                issues.append("missing_research_cite")
        if not any("/compare" in l for l in links):
            if rm.get("intent") == "Commercial" or "alternative" in slug:
                issues.append("missing_compare_link")
        if target_min and wc < target_min * 0.4:
            issues.append("below_word_target")

        intro_text = strip_html(html[:800]) if html else ""
        if len(intro_text.split()) < 40 and layer == "generated":
            issues.append("weak_intro")

        traffic = TRAFFIC_SCORE.get(rm.get("traffic", ""), 1)
        priority = PRIORITY_SCORE.get(rm.get("priority", ""), 1)
        funnel = FUNNEL_SCORE.get(rm.get("funnel", ""), 1)
        intent = INTENT_SCORE.get(rm.get("intent", ""), 1)
        has_tool = 1 if (lm.get("tool") or rm.get("tool_url")) else 0
        hand_bonus = 2 if layer != "generated" else 0

        traffic_roi = round(
            traffic * 2 + priority * 2 + funnel * 1.5 + intent + has_tool + hand_bonus, 2
        )
        convert_roi = round(
            funnel * 3 + intent * 2 + has_tool * 2 + priority + (1 if "invoice" in slug else 0), 2
        )
        upgrade_roi = round(
            traffic_roi
            + (3 if "thin" in issues or "ultra_thin" in issues else 0)
            + (2 if "template_footprint" in issues else 0)
            + (2 if "missing_faq" in issues else 0)
            + (1 if layer == "generated" else 0),
            2,
        )

        records.append(
            {
                "slug": slug,
                "layer": layer,
                "word_count": wc,
                "link_count": len(links),
                "template_score": tpl,
                "cluster": rm.get("cluster", lm.get("cat", "")),
                "priority": rm.get("priority", ""),
                "traffic": rm.get("traffic", ""),
                "funnel": rm.get("funnel", ""),
                "intent": rm.get("intent", ""),
                "tool": lm.get("tool") or rm.get("tool_url"),
                "has_faq": lm.get("has_faq", False),
                "issues": issues,
                "traffic_roi": traffic_roi,
                "convert_roi": convert_roi,
                "upgrade_roi": upgrade_roi,
                "title": lm.get("title") or rm.get("keyword", slug),
                "internal_links_roadmap": rm.get("internal_links", []),
                "outbound_links": links[:20],
            }
        )

    live_slugs = {r["slug"] for r in records}
    orphan_candidates = []
    for r in records:
        path = f"/guides/{r['slug']}"
        if inbound[path] <= 1 and r["link_count"] <= 2:
            orphan_candidates.append(
                {"slug": r["slug"], "inbound": inbound[path], "outbound": r["link_count"]}
            )

    return records, orphan_candidates, dict(inbound), dict(all_outbound)


def summarize(records, orphan_candidates, inbound):
    thin = [r for r in records if "thin" in r["issues"] or "ultra_thin" in r["issues"]]
    template = [r for r in records if "template_footprint" in r["issues"]]
    no_faq = [r for r in records if "missing_faq" in r["issues"]]
    no_tool = [r for r in records if "missing_tool_link" in r["issues"]]
    weak_intro = [r for r in records if "weak_intro" in r["issues"]]
    weak_conclusion = [r for r in records if "weak_conclusion" in r["issues"]]

    by_layer = Counter(r["layer"] for r in records)
    wc_by_layer = defaultdict(list)
    for r in records:
        wc_by_layer[r["layer"]].append(r["word_count"])

    top_traffic = sorted(records, key=lambda x: (-x["traffic_roi"], -x["word_count"]))[:50]
    top_convert = sorted(records, key=lambda x: (-x["convert_roi"], -x["traffic_roi"]))[:50]
    top_upgrade = sorted(records, key=lambda x: (-x["upgrade_roi"], -x["traffic_roi"]))[:100]

    cluster_gaps = defaultdict(lambda: {"count": 0, "thin": 0, "no_faq": 0})
    for r in records:
        c = r["cluster"] or "unknown"
        cluster_gaps[c]["count"] += 1
        if "thin" in r["issues"] or "ultra_thin" in r["issues"]:
            cluster_gaps[c]["thin"] += 1
        if "missing_faq" in r["issues"]:
            cluster_gaps[c]["no_faq"] += 1

    return {
        "totals": {
            "live_guides": len(records),
            "by_layer": dict(by_layer),
            "median_word_count": {
                k: sorted(v)[len(v) // 2] if v else 0 for k, v in wc_by_layer.items()
            },
            "thin_pages": len(thin),
            "template_footprint_pages": len(template),
            "missing_faq_pages": len(no_faq),
            "missing_tool_link_pages": len(no_tool),
            "weak_intro_pages": len(weak_intro),
            "weak_conclusion_pages": len(weak_conclusion),
            "orphan_candidates": len(orphan_candidates),
        },
        "top_50_traffic": [
            {k: r[k] for k in ("slug", "title", "traffic_roi", "priority", "traffic", "layer", "word_count")}
            for r in top_traffic
        ],
        "top_50_convert": [
            {k: r[k] for k in ("slug", "title", "convert_roi", "tool", "funnel", "intent", "layer")}
            for r in top_convert
        ],
        "top_100_upgrade": [
            {
                k: r[k]
                for k in (
                    "slug",
                    "title",
                    "upgrade_roi",
                    "traffic_roi",
                    "convert_roi",
                    "layer",
                    "word_count",
                    "issues",
                    "priority",
                    "cluster",
                )
            }
            for r in top_upgrade
        ],
        "cluster_gaps": dict(cluster_gaps),
        "orphan_candidates": sorted(orphan_candidates, key=lambda x: x["inbound"])[:80],
        "issue_samples": {
            "thin": [r["slug"] for r in sorted(thin, key=lambda x: x["word_count"])[:30]],
            "template": [r["slug"] for r in sorted(template, key=lambda x: -x["template_score"])[:30]],
            "no_faq": [r["slug"] for r in no_faq[:30]],
        },
        "most_linked_paths": sorted(inbound.items(), key=lambda x: -x[1])[:30],
    }


def audit_programmatic():
    keyword_files = {
        "compress": ROOT / "wwwroot" / "compress-pdf-keywords.txt",
        "pdf_to_word": ROOT / "wwwroot" / "pdftodocx_urls.txt",
        "edit_pdf": ROOT / "wwwroot" / "edit_pdf_urls_100k.txt",
        "pdf_to_txt": ROOT / "wwwroot" / "pdf-to-txt-keywords.txt",
        "decay": ROOT / "wwwroot" / "decay_urls.txt",
        "payslip": ROOT / "SeoData" / "payslip_keywords_slugs.txt",
        "jwt": ROOT / "SeoData" / "jwt_keywords_slugs.txt",
        "json": ROOT / "SeoData" / "json_keywords_slugs.txt",
        "html": ROOT / "SeoData" / "html_keywords_slugs.txt",
    }
    counts = {}
    for name, path in keyword_files.items():
        if path.exists():
            lines = [ln.strip() for ln in path.read_text(encoding="utf-8").splitlines() if ln.strip()]
            counts[name] = len(lines)
    return {
        "keyword_corpus_counts": counts,
        "estimated_programmatic_urls": sum(counts.values()),
        "risks": [
            "Intent verticals share 2-3 body variants across thousands of slugs (VerticalIntentContentBuilder hash rotation)",
            "Competitor alternatives triple-stacked: /compare/* vs compress curated vs noindex tool landings",
            "Compress size-target clusters (/compress-pdf-to-100kb vs /compress-pdf-under-100kb) near-duplicate workflows",
            "Template tool landings (~250+) share identical FAQ/how-to; noindex but crawl budget cost",
            "FAQ schema suppressed on noindex pages — thin landings lack rich results",
            "PDF-to-word vs /guides/pdf-to-word vs /pdf/pdftodoc — pillar overlap",
        ],
        "fix_recommendations": [
            "Expand curated compress pillar set; canonical near-duplicate size slugs to strongest URL",
            "Add unique stat blocks to top 100 indexed programmatic slugs by search volume proxy",
            "Strengthen cross-links from /compress-pdf hub to editorial spokes",
            "Consolidate compare ownership: /compare/* owns competitor names; noindex duplicate alternatives",
            "Increase VerticalIntentContentBuilder variant pool from 3 to 12+ for indexed tiers",
            "Add FAQ uniqueness per intent subclass (device, error, task) not just global hash",
        ],
    }


def audit_eeat(records, lib_meta):
    hand = [r for r in records if r["layer"] != "generated"]
    gen = [r for r in records if r["layer"] == "generated"]
    commercial = [
        r
        for r in records
        if r["intent"] in ("Commercial", "Transactional")
        or r["funnel"] == "BOFU"
        or r["tool"]
    ]
    return {
        "global_signals": {
            "author_byline": "All guides via _AuthorByline.cshtml (SiteAuthors.ResolveForContent)",
            "last_reviewed": "Static 2026-01-15 for all guides — freshness gap",
            "sources_catalog": "ContentSourcesCatalog per slug; defaults to Adobe+Ghostscript",
            "howto_schema": "GuideHowToSteps.cs — partial slug coverage",
            "expert_review_notes": "Not implemented at page level",
            "screenshots": "No screenshot assets in guide bodies",
        },
        "faq_coverage": {
            "guides_with_faq_schema": sum(1 for r in records if r["has_faq"]),
            "guides_without_faq": sum(1 for r in records if not r["has_faq"]),
            "pct_without_faq": round(
                100 * sum(1 for r in records if not r["has_faq"]) / max(len(records), 1), 1
            ),
        },
        "hand_written_count": len(hand),
        "generated_count": len(gen),
        "commercial_pages": len(commercial),
        "priority_commercial_upgrades": [
            r["slug"]
            for r in sorted(commercial, key=lambda x: -x["convert_roi"])[:40]
            if r["layer"] == "generated" or not r["has_faq"]
        ],
    }


def audit_conversion(records):
    high_traffic = sorted(records, key=lambda x: -x["traffic_roi"])[:80]
    gaps = []
    for r in high_traffic:
        missing = []
        if not r["tool"]:
            missing.append("no_tool_mapping")
        if "missing_tool_link" in r["issues"]:
            missing.append("no_tool_cta_in_body")
        if not r["has_faq"]:
            missing.append("no_faq_schema")
        if r["layer"] == "generated":
            missing.append("template_body")
        if r["word_count"] < 800:
            missing.append("thin_content")
        if missing:
            gaps.append({"slug": r["slug"], "title": r["title"], "gaps": missing, "convert_roi": r["convert_roi"]})
    return {
        "high_traffic_guides_audited": len(high_traffic),
        "guides_with_conversion_gaps": len(gaps),
        "top_gaps": gaps[:40],
        "recommendations": [
            "Ensure _ToolTryCta fires: every BOFU guide needs ToolUrl in ContentLibrary",
            "Add mid-article CTA blocks on compress/invoice clusters (not just footer link)",
            "Add lead magnets: size checker, GST checker links on compliance guides",
            "FAQ answers should end with tool deep-link (currently generic on generated pages)",
            "Compare hub CTA on pdf-tool-alternatives-style pages — already strong; replicate pattern",
        ],
    }


def audit_backlinks():
    return {
        "existing_data_assets": [
            {"path": "/research/attachment-size-limits", "type": "citable data", "priority": "P0"},
            {"path": "/research/pdf-compression-benchmark", "type": "benchmark study", "priority": "P0"},
            {"path": "/research/freelancer-invoicing-statistics", "type": "statistics", "priority": "P1"},
            {"path": "/research/document-retention-periods", "type": "compliance reference", "priority": "P1"},
            {"path": "/research/pdf-tool-market-comparison", "type": "market data", "priority": "P0"},
            {"path": "/compare/*", "type": "commercial comparison", "priority": "P0"},
            {"path": "/guides/pdf-tool-alternatives", "type": "editorial roundup", "priority": "P1"},
        ],
        "codebase_data_to_publish": [
            "Ghostscript compression level benchmarks (already in compress-pdf-guide prose)",
            "Gmail/Outlook/portal attachment limits table (compress-pdf-for-gmail extended)",
            "CompetitiveSeoCatalog keyword gap matrix",
            "IntentClassifier corpus stats (indexed vs noindex ratio)",
            "Invoice GST field validation rules from invoice tool",
            "PDF tool usage limits (3/day) as transparency study",
        ],
        "expansion_priorities": [
            {"topic": "Email attachment limits by provider (2026)", "action": "Expand attachment-size-limits with changelog"},
            {"topic": "PDF compression ratio by file type", "action": "Add dataset to pdf-compression-benchmark"},
            {"topic": "Freelancer invoice payment terms survey", "action": "Expand freelancer-invoicing-statistics"},
            {"topic": "PDF tool pricing comparison", "action": "Sync pdf-tool-market-comparison with live competitor pricing"},
            {"topic": "Government portal PDF size limits", "action": "New section in attachment-size-limits (no new URL)"},
        ],
    }


def main():
    bodies = parse_bodies()
    lib_meta = parse_library_meta()
    roadmap = parse_roadmap()
    records, orphan_candidates, inbound, _ = audit_guides(bodies, lib_meta, roadmap)
    summary = summarize(records, orphan_candidates, inbound)

    result = {
        "summary": summary,
        "programmatic": audit_programmatic(),
        "eeat": audit_eeat(records, lib_meta),
        "conversion": audit_conversion(records),
        "backlinks": audit_backlinks(),
        "internal_linking": {
            "orphan_count": summary["totals"]["orphan_candidates"],
            "design_targets": [
                "Wire ContentRoadmapMeta InternalLinks into _ContentArticle sidebar",
                "Cluster-based related guides (not category-only)",
                "Every compress spoke → /research/attachment-size-limits",
                "Every commercial guide → relevant /compare/* page",
                "Glossary mesh: link related glossary terms (currently hub-only)",
                "Regional workflows: cross-link country + doc-type matrix",
                "Programmatic compress hub → top 50 editorial spokes",
            ],
            "hub_pages": [
                "/guides/pdf-tools",
                "/compress-pdf",
                "/guides/secure-pdf-workflow",
                "/guides/developer-tools",
                "/resources",
                "/compare",
            ],
        },
    }
    OUT.write_text(json.dumps(result, indent=2), encoding="utf-8")
    print(json.dumps(summary["totals"], indent=2))
    print(f"Wrote {OUT}")


if __name__ == "__main__":
    main()
