#!/usr/bin/env python3
"""Audit legacy sitemap surface area being removed from the new 7,906-URL index.

Compares old wwwroot/sitemaps/*.xml and compress programmatic chunks against
the new clean child sitemap catalog.

Usage:
  python scripts/audit_old_sitemap.py
  python scripts/audit_old_sitemap.py --base-url https://ratpdf.com
"""
from __future__ import annotations

import argparse
import xml.etree.ElementTree as ET
from pathlib import Path
from urllib.parse import urlparse
from urllib.request import Request, urlopen

ROOT = Path(__file__).resolve().parents[1]
WWW_SITEMAPS = ROOT / "wwwroot" / "sitemaps"
NS = {"sm": "http://www.sitemaps.org/schemas/sitemap/0.9"}

NEW_CHILDREN = {
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
}


def fetch(url: str) -> str:
    req = Request(url, headers={"User-Agent": "ratpdf-sitemap-audit/1.0"})
    with urlopen(req, timeout=30) as resp:
        return resp.read().decode("utf-8", errors="replace")


def parse_locs(xml_text: str) -> list[str]:
    try:
        root = ET.fromstring(xml_text)
    except ET.ParseError:
        return []
    tag = root.tag.split("}")[-1]
    if tag == "sitemapindex":
        return [e.text.strip() for e in root.findall(".//sm:loc", NS) if e.text]
    if tag == "urlset":
        return [e.text.strip() for e in root.findall(".//sm:url/sm:loc", NS) if e.text]
    return []


def count_local_file(path: Path) -> int:
    if not path.exists():
        return 0
    return len(parse_locs(path.read_text(encoding="utf-8", errors="replace")))


def main() -> int:
    parser = argparse.ArgumentParser()
    parser.add_argument("--base-url", default="https://ratpdf.com")
    args = parser.parse_args()
    base = args.base_url.rstrip("/")

    print("RatPDF sitemap migration audit")
    print("=" * 60)

    # Local static files
    local_total = 0
    local_files: list[tuple[str, int]] = []
    if WWW_SITEMAPS.exists():
        for path in sorted(WWW_SITEMAPS.glob("*.xml")):
            n = count_local_file(path)
            local_total += n
            local_files.append((path.name, n))

    print(f"\nLocal wwwroot/sitemaps/*.xml: {len(local_files)} files, {local_total:,} URLs")
    for name, n in sorted(local_files, key=lambda x: -x[1])[:15]:
        print(f"  {name:40} {n:6,}")
    if len(local_files) > 15:
        print(f"  ... and {len(local_files) - 15} more files")

    # Live index children (if reachable)
    print(f"\nLive index: {base}/sitemap.xml")
    try:
        index_xml = fetch(f"{base}/sitemap.xml")
        children = parse_locs(index_xml)
        print(f"  Index children: {len(children)}")
        old_children = [c for c in children if child_name(c) not in NEW_CHILDREN]
        for c in children:
            mark = "NEW" if child_name(c) in NEW_CHILDREN else "OLD"
            print(f"    [{mark}] {c}")
        if old_children:
            print(f"\n  Legacy children still in index: {len(old_children)}")
    except Exception as exc:  # noqa: BLE001
        print(f"  (could not fetch live index: {exc})")

    # Compress programmatic estimate from keywords file
    kw_file = ROOT / "wwwroot" / "compress-pdf-keywords.txt"
    kw_count = 0
    if kw_file.exists():
        kw_count = sum(1 for line in kw_file.open(encoding="utf-8") if line.strip())
    print(f"\nCompress keyword slugs (excluded from new index): ~{kw_count:,}")
    print(f"Curated programmatic retained in new index: 50 URLs")

    new_total = 10 + 33 + 19 + 50 + 1299 * 6
    removed_estimate = local_total + kw_count - new_total
    print("\n" + "-" * 60)
    print(f"New clean index target:     {new_total:,} URLs across {len(NEW_CHILDREN)} children")
    print(f"Old static + keyword est.:  ~{local_total + kw_count:,} URLs")
    print(f"Estimated URLs removed:     ~{max(0, removed_estimate):,}")
    print("\nExcluded from new index:")
    print("  - compress-pdf-*.xml chunks (~27k parameter/long-tail landings)")
    print("  - invoice/html/json/jwt vertical sitemaps")
    print("  - sitemap-compare.xml, sitemap-guides-localized.xml")
    print("  - duplicate guides.xml / site.xml aliases (301 to new names)")
    return 0


def child_name(loc: str) -> str:
    return urlparse(loc).path.rstrip("/").split("/")[-1]


if __name__ == "__main__":
    raise SystemExit(main())
