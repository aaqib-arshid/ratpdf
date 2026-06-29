#!/usr/bin/env python3
"""Load published English guides for the localization pipeline."""
from __future__ import annotations

import csv
import json
import re
import subprocess
import sys
from html import unescape
from pathlib import Path

ROOT = Path(__file__).resolve().parents[2]
CONTENT = ROOT / "Content"
DATA = ROOT / "Data"
LIB = CONTENT / "ContentLibrary.cs"
ROADMAP = DATA / "content-roadmap.csv"
MANIFEST = DATA / "guides-manifest.json"

SWITCH_CASE_RE = re.compile(
    r'"([a-z0-9-]+)"(?:\s+or\s+"([a-z0-9-]+)")?\s*=>\s*([A-Za-z0-9_]+)'
)
BODY_CONST_RE = re.compile(
    r'private const string ([A-Za-z0-9_]+)\s*=\s*"""(.*?)"""',
    re.DOTALL,
)
LIB_META_RE = re.compile(
    r'\("([a-z0-9-]+)",\s*"((?:[^"\\]|\\.)*)"\s*,\s*"((?:[^"\\]|\\.)*)"\s*,\s*"([^"]*)"\s*,\s*([^,\n]+)',
)
FAQ_BLOCK_RE = re.compile(
    r'\("([a-z0-9-]+)"[\s\S]*?\[([\s\S]*?)\],\s*\[([\s\S]*?)\]\s*\)',
    re.MULTILINE,
)
STEP_RE = re.compile(r'"([^"\\]*(?:\\.[^"\\]*)*)"')

TRAFFIC_SCORE = {"High": 3, "Medium": 2, "Low": 1, "": 1}
PRIORITY_SCORE = {"P0": 3, "P1": 2, "P2": 1, "": 1}


def unescape_cs(value: str) -> str:
    return value.replace('\\"', '"').replace("\\n", "\n")


def parse_switch_slugs(path: Path) -> dict[str, str]:
    text = path.read_text(encoding="utf-8")
    if "=> slug switch" not in text:
        return {}
    switch_part = text.split("=> slug switch", 1)[-1].split("_ =>")[0]
    mapping: dict[str, str] = {}
    for segment in switch_part.split(","):
        if "=>" not in segment:
            continue
        lhs, rhs = segment.split("=>", 1)
        rhs = rhs.strip()
        if ".Get(" in rhs:
            continue
        const = rhs.split("(")[0].strip()
        if const in ("Get", "null"):
            continue
        for slug_m in re.finditer(r'"([a-z0-9-]+)"', lhs):
            mapping[slug_m.group(1)] = const
    return mapping


def parse_const_bodies(path: Path) -> dict[str, str]:
    return {m.group(1): m.group(2) for m in BODY_CONST_RE.finditer(path.read_text(encoding="utf-8"))}


def parse_bodies() -> dict[str, str]:
    layer_rank = {"generated": 0, "wave": 2, "hand_extended": 3, "hand_core": 4}
    bodies: dict[str, dict] = {}
    layers: list[tuple[str, Path]] = [("generated", CONTENT / "GuideBodiesGenerated.cs")]
    layers.extend(("wave", p) for p in sorted(CONTENT.glob("GuideBodiesWave*.cs")))
    layers.extend(
        [
            ("hand_extended", CONTENT / "GuideBodiesExtended.cs"),
            ("hand_core", CONTENT / "GuideBodies.cs"),
        ]
    )
    for layer, path in layers:
        if not path.exists():
            continue
        slug_to_const = parse_switch_slugs(path)
        const_to_html = parse_const_bodies(path)
        for slug, const in slug_to_const.items():
            html = const_to_html.get(const, "")
            if not html.strip():
                continue
            if slug in bodies and layer_rank.get(bodies[slug]["layer"], 0) >= layer_rank[layer]:
                continue
            bodies[slug] = {"layer": layer, "html": html}
    return {slug: data["html"] for slug, data in bodies.items()}


def parse_library_meta() -> dict[str, dict]:
    text = LIB.read_text(encoding="utf-8").split("BuildBlogs")[0]
    meta: dict[str, dict] = {}
    for m in LIB_META_RE.finditer(text):
        slug, title, desc, cat, tool = m.groups()
        tool = tool.strip().strip('"')
        if tool == "null":
            tool = None
        meta[slug] = {
            "title": unescape_cs(title),
            "description": unescape_cs(desc),
            "category": cat,
            "toolUrl": tool,
        }

    for m in FAQ_BLOCK_RE.finditer(text):
        slug = m.group(1)
        if slug not in meta:
            continue
        meta[slug]["faqQuestions"] = [unescape_cs(s) for s in STEP_RE.findall(m.group(2))]
        meta[slug]["faqAnswers"] = [unescape_cs(s) for s in STEP_RE.findall(m.group(3))]
    return meta


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
            if not slug or row.get("Status") in ("Merged", "Deferred"):
                continue
            rows[slug] = {
                "cluster": row.get("Cluster", ""),
                "primaryKeyword": row.get("PrimaryKeyword", slug.replace("-", " ")),
                "trafficPotential": row.get("TrafficPotential", ""),
                "priority": row.get("Priority", ""),
                "toolUrl": row.get("ToolURL") or None,
            }
    return rows


def search_score(slug: str, roadmap: dict[str, dict]) -> int:
    row = roadmap.get(slug, {})
    traffic = TRAFFIC_SCORE.get(row.get("trafficPotential", ""), 1)
    priority = PRIORITY_SCORE.get(row.get("priority", ""), 1)
    return traffic * priority


def normalize_manifest_guide(raw: dict) -> dict:
    """Map C# PascalCase manifest fields to pipeline snake_case."""
    return {
        "slug": raw.get("slug") or raw.get("Slug", ""),
        "title": raw.get("title") or raw.get("Title", ""),
        "description": raw.get("description") or raw.get("Description", ""),
        "category": raw.get("category") or raw.get("Category", "PDF"),
        "toolUrl": raw.get("toolUrl") or raw.get("ToolUrl"),
        "cluster": raw.get("cluster") or raw.get("Cluster"),
        "primaryKeyword": raw.get("primaryKeyword") or raw.get("PrimaryKeyword", ""),
        "trafficPotential": raw.get("trafficPotential") or raw.get("TrafficPotential"),
        "priority": raw.get("priority") or raw.get("Priority"),
        "searchScore": raw.get("searchScore") or raw.get("SearchScore", 1),
        "bodyHtml": raw.get("bodyHtml") or raw.get("BodyHtml", ""),
        "faqQuestions": raw.get("faqQuestions") or raw.get("FaqQuestions"),
        "faqAnswers": raw.get("faqAnswers") or raw.get("FaqAnswers"),
        "howToSteps": raw.get("howToSteps") or raw.get("HowToSteps"),
    }


def load_manifest(force_export: bool = False) -> list[dict]:
    if force_export or not MANIFEST.exists():
        export_manifest()
    data = json.loads(MANIFEST.read_text(encoding="utf-8"))
    guides = data.get("guides") or data.get("Guides") or []
    return [normalize_manifest_guide(g) for g in guides]


def export_manifest() -> Path:
    cmd = ["dotnet", "run", "--no-launch-profile", "--", "--export-guides-manifest", str(MANIFEST)]
    subprocess.run(cmd, cwd=ROOT, check=True)
    return MANIFEST


def load_guides(prefer_manifest: bool = True) -> list[dict]:
    if prefer_manifest and MANIFEST.exists():
        return load_manifest()

    bodies = parse_bodies()
    lib = parse_library_meta()
    roadmap = parse_roadmap()
    guides: list[dict] = []
    for slug, html in bodies.items():
        if slug not in lib:
            continue
        lm = lib[slug]
        rm = roadmap.get(slug, {})
        guides.append(
            {
                "slug": slug,
                "title": lm["title"],
                "description": lm["description"],
                "category": lm["category"],
                "toolUrl": lm.get("toolUrl") or rm.get("toolUrl"),
                "cluster": rm.get("cluster"),
                "primaryKeyword": rm.get("primaryKeyword", lm["title"]),
                "trafficPotential": rm.get("trafficPotential"),
                "priority": rm.get("priority"),
                "searchScore": search_score(slug, roadmap),
                "bodyHtml": html,
                "faqQuestions": lm.get("faqQuestions"),
                "faqAnswers": lm.get("faqAnswers"),
            }
        )
    guides.sort(key=lambda g: (-g["searchScore"], g["slug"]))
    return guides


if __name__ == "__main__":
    guides = load_guides()
    print(f"Loaded {len(guides)} guides", file=sys.stderr)
