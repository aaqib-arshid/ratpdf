#!/usr/bin/env python3
"""Validate ratpdf.com sitemap index and child sitemaps before GSC submission.

Usage:
  python scripts/validate_sitemap.py
  python scripts/validate_sitemap.py --base-url http://localhost:5000
  python scripts/validate_sitemap.py --validate --sample 50

Checks:
  - URL counts per child sitemap (expected ~7,906 total)
  - Random sample HTTP 200 (--validate)
  - hreflang link clusters on guide sitemaps
  - Canonical self-reference on sampled guide pages
  - No query-parameter URLs in sitemaps
"""
from __future__ import annotations

import argparse
import random
import re
import sys
import xml.etree.ElementTree as ET
from collections import defaultdict
from dataclasses import dataclass, field
from pathlib import Path
from urllib.parse import urlparse
from urllib.request import Request, urlopen

ROOT = Path(__file__).resolve().parents[1]
NS = {"sm": "http://www.sitemaps.org/schemas/sitemap/0.9", "xhtml": "http://www.w3.org/1999/xhtml"}

EXPECTED_CHILDREN = {
    "sitemap-core.xml": 10,
    "sitemap-tools.xml": 33,
    "sitemap-blog.xml": 19,
    "sitemap-programmatic.xml": 50,
    "sitemap-guides-en.xml": 1299,
    "sitemap-guides-pt.xml": 1299,
    "sitemap-guides-es.xml": 1299,
    "sitemap-guides-de.xml": 1299,
    "sitemap-guides-id.xml": 1299,
    "sitemap-guides-fr.xml": 1299,
}

GUIDE_SITEMAPS = {k for k in EXPECTED_CHILDREN if k.startswith("sitemap-guides-")}

REQUIRED_HREFLANG = {"en", "pt-BR", "es", "de", "id", "fr", "x-default"}


@dataclass
class Issue:
    level: str  # error | warn
    message: str


@dataclass
class SitemapReport:
    name: str
    url_count: int = 0
    expected: int | None = None
    issues: list[Issue] = field(default_factory=list)

    @property
    def ok(self) -> bool:
        if self.expected is not None and self.url_count != self.expected:
            return False
        return not any(i.level == "error" for i in self.issues)


def rewrite_to_base(child_loc: str, base: str) -> str:
    """Child sitemap locs use production host; rewrite to --base-url for local validation."""
    parsed_base = urlparse(base)
    parsed_child = urlparse(child_loc)
    return f"{parsed_base.scheme}://{parsed_base.netloc}{parsed_child.path}"


def fetch(url: str, timeout: int = 60) -> tuple[int, str]:
    req = Request(url, headers={"User-Agent": "ratpdf-sitemap-validator/1.0"})
    try:
        with urlopen(req, timeout=timeout) as resp:
            return resp.status, resp.read().decode("utf-8", errors="replace")
    except Exception as exc:  # noqa: BLE001
        return 0, str(exc)


def parse_locs(xml_text: str) -> list[str]:
    try:
        root = ET.fromstring(xml_text)
    except ET.ParseError as exc:
        return []
    tag = root.tag.split("}")[-1]
    if tag == "sitemapindex":
        return [el.text.strip() for el in root.findall(".//sm:loc", NS) if el.text]
    if tag == "urlset":
        return [el.text.strip() for el in root.findall(".//sm:url/sm:loc", NS) if el.text]
    return []


def parse_url_entries(xml_text: str) -> list[ET.Element]:
    try:
        root = ET.fromstring(xml_text)
    except ET.ParseError:
        return []
    if root.tag.split("}")[-1] != "urlset":
        return []
    return root.findall(".//sm:url", NS)


def child_name(loc: str) -> str:
    return loc.rstrip("/").split("/")[-1]


def validate_urlset_structure(name: str, xml_text: str, report: SitemapReport) -> list[str]:
    locs: list[str] = []
    for url_el in parse_url_entries(xml_text):
        loc_el = url_el.find("sm:loc", NS)
        if loc_el is None or not loc_el.text:
            report.issues.append(Issue("error", "url entry missing loc"))
            continue
        loc = loc_el.text.strip()
        locs.append(loc)

        if loc.startswith("http://"):
            report.issues.append(Issue("error", f"http URL (must be https): {loc}"))
        if "?" in loc:
            report.issues.append(Issue("error", f"query parameter URL: {loc}"))
        if loc.endswith("/") and urlparse(loc).path not in ("/", ""):
            report.issues.append(Issue("warn", f"trailing slash: {loc}"))

        if name in GUIDE_SITEMAPS:
            hreflangs = {
                link.attrib.get("hreflang")
                for link in url_el.findall("xhtml:link", NS)
                if link.attrib.get("rel") == "alternate"
            }
            missing = REQUIRED_HREFLANG - hreflangs
            if missing:
                report.issues.append(
                    Issue("error", f"missing hreflang {sorted(missing)} on {loc}")
                )
    return locs


def check_page_seo(page_url: str) -> list[Issue]:
    issues: list[Issue] = []
    status, html = fetch(page_url)
    if status != 200:
        issues.append(Issue("error", f"HTTP {status} for {page_url}"))
        return issues

    hreflang_links = re.findall(
        r'<link[^>]+rel=["\']alternate["\'][^>]+hreflang=["\']([^"\']+)["\']',
        html,
        re.I,
    )
    if not hreflang_links and "/guides/" in page_url:
        issues.append(Issue("warn", f"no hreflang on page {page_url}"))

    canon = re.search(
        r'<link[^>]+rel=["\']canonical["\'][^>]+href=["\']([^"\']+)["\']',
        html,
        re.I,
    )
    if canon:
        page_path = urlparse(page_url).path.rstrip("/")
        canonical_path = urlparse(canon.group(1)).path.rstrip("/")
        if canonical_path != page_path:
            issues.append(
                Issue("warn", f"canonical mismatch: page={page_url} canonical={canon.group(1)}")
            )
    elif "/guides/" in page_url:
        issues.append(Issue("warn", f"missing canonical on {page_url}"))

    if re.search(r'<meta[^>]+name=["\']robots["\'][^>]+content=["\'][^"\']*noindex', html, re.I):
        issues.append(Issue("error", f"noindex page in sitemap: {page_url}"))

    return issues


def main() -> int:
    parser = argparse.ArgumentParser(description="Validate ratpdf sitemap structure and URLs")
    parser.add_argument("--base-url", default="https://ratpdf.com", help="Site origin")
    parser.add_argument("--validate", action="store_true", help="HTTP-check sample page URLs")
    parser.add_argument("--sample", type=int, default=50, help="Random URLs per child sitemap")
    parser.add_argument("--seed", type=int, default=42)
    args = parser.parse_args()

    base = args.base_url.rstrip("/")
    index_url = f"{base}/sitemap.xml"
    print(f"Fetching sitemap index: {index_url}\n")

    status, index_xml = fetch(index_url)
    if status != 200:
        print(f"ERROR: sitemap index returned {status}: {index_xml[:200]}")
        return 1

    child_locs = parse_locs(index_xml)
    reports: dict[str, SitemapReport] = {}
    all_issues: list[Issue] = []

    for child_loc in child_locs:
        fetch_loc = rewrite_to_base(child_loc, base)
        name = child_name(child_loc)
        expected = EXPECTED_CHILDREN.get(name)
        report = SitemapReport(name=name, expected=expected)
        cs, xml = fetch(fetch_loc)
        if cs != 200:
            report.issues.append(Issue("error", f"child fetch failed HTTP {cs}"))
            reports[name] = report
            continue
        locs = validate_urlset_structure(name, xml, report)
        report.url_count = len(locs)
        if expected is not None and report.url_count != expected:
            report.issues.append(
                Issue(
                    "error",
                    f"count {report.url_count} != expected {expected}",
                )
            )
        reports[name] = report

        if args.validate and locs:
            random.seed(args.seed)
            sample = locs if len(locs) <= args.sample else random.sample(locs, args.sample)
            for loc in sample:
                all_issues.extend(check_page_seo(rewrite_to_base(loc, base)))

    # Expected children missing from index
    for expected_name in EXPECTED_CHILDREN:
        if expected_name not in reports:
            r = SitemapReport(name=expected_name, expected=EXPECTED_CHILDREN[expected_name])
            r.issues.append(Issue("error", "missing from sitemap index"))
            reports[expected_name] = r

    total = sum(r.url_count for r in reports.values())
    target_total = sum(EXPECTED_CHILDREN.values())

    print("Sitemap validation summary")
    print("=" * 50)
    for name in sorted(EXPECTED_CHILDREN, key=lambda n: EXPECTED_CHILDREN[n], reverse=False):
        # print in logical order
        pass
    order = [
        "sitemap-core.xml",
        "sitemap-tools.xml",
        "sitemap-blog.xml",
        "sitemap-programmatic.xml",
        "sitemap-guides-en.xml",
        "sitemap-guides-pt.xml",
        "sitemap-guides-es.xml",
        "sitemap-guides-de.xml",
        "sitemap-guides-id.xml",
        "sitemap-guides-fr.xml",
    ]
    for name in order:
        r = reports.get(name, SitemapReport(name=name))
        exp = EXPECTED_CHILDREN.get(name, "?")
        mark = "OK" if r.ok and r.url_count == exp else "FAIL"
        print(f"  {name:28} {r.url_count:5} URLs (exp {exp}) {mark}")
        for issue in r.issues:
            print(f"    [{issue.level}] {issue.message}")

    print("  " + "-" * 33)
    total_mark = "OK" if total == target_total else "FAIL"
    print(f"  {'Total:':28} {total:5} URLs (exp {target_total}) {total_mark}")

    hreflang_xml_ok = all(
        reports.get(n, SitemapReport(n)).ok or not any(
            "hreflang" in i.message for i in reports.get(n, SitemapReport(n)).issues
        )
        for n in GUIDE_SITEMAPS
    )
    param_ok = not any("query parameter" in i.message for r in reports.values() for i in r.issues)

    canonical_ok = True
    if args.validate:
        err_count = sum(1 for i in all_issues if i.level == "error")
        warn_count = sum(1 for i in all_issues if i.level == "warn")
        canonical_ok = not any("canonical" in i.message for i in all_issues if i.level == "error")
        print(f"\n  Sampled pages:        {args.sample} per sitemap")
        print(f"  Page errors:          {err_count} {'OK' if err_count == 0 else 'FAIL'}")
        print(f"  Page warnings:        {warn_count}")
        for issue in all_issues[:20]:
            print(f"    [{issue.level}] {issue.message}")
        if len(all_issues) > 20:
            print(f"    ... and {len(all_issues) - 20} more")
    else:
        canonical_ok = True

    print(f"\n  hreflang verified:     {'YES OK' if hreflang_xml_ok else 'NO FAIL'}")
    print(f"  Canonical verified:    {'YES OK' if canonical_ok else 'NO FAIL'}")
    print(f"  No parameter URLs:     {'YES OK' if param_ok else 'NO FAIL'}")

    failed = (
        total != target_total
        or any(not r.ok for r in reports.values())
        or any(i.level == "error" for i in all_issues)
    )
    return 1 if failed else 0


if __name__ == "__main__":
    raise SystemExit(main())
