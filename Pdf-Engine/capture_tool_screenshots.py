#!/usr/bin/env python3
"""Capture tool page screenshots for tutorial slide videos (Playwright, free)."""
from __future__ import annotations

import argparse
import json
import sys
from pathlib import Path

try:
    from playwright.sync_api import sync_playwright
except ImportError:
    print("Install: pip install playwright && playwright install chromium", file=sys.stderr)
    sys.exit(1)

VIEWPORT = {"width": 1280, "height": 900}


def capture_one(page, base_url: str, tool: dict, out_dir: Path) -> bool:
    url = tool["url"].rstrip("/")
    if not url.startswith("/"):
        url = "/" + url
    full = base_url.rstrip("/") + url
    slug = tool["slug"]
    dest = out_dir / slug
    dest.mkdir(parents=True, exist_ok=True)
    shot = dest / "page.png"
    try:
        page.goto(full, wait_until="networkidle", timeout=60000)
        page.wait_for_timeout(1500)
        page.screenshot(path=str(shot), full_page=False)
        print(f"  {slug} -> {shot}")
        return True
    except Exception as ex:
        print(f"  Failed {slug}: {ex}", file=sys.stderr)
        return False


def main() -> None:
    parser = argparse.ArgumentParser()
    parser.add_argument("--base-url", default="http://localhost:5041")
    parser.add_argument("--web-root", required=True)
    parser.add_argument("--manifest", required=True)
    parser.add_argument("--only", help="Comma-separated slugs")
    parser.add_argument("--limit", type=int)
    args = parser.parse_args()

    manifest = json.loads(Path(args.manifest).read_text(encoding="utf-8"))
    tools = manifest["tools"]
    if args.only:
        only = set(args.only.split(","))
        tools = [t for t in tools if t["slug"] in only]
    if args.limit:
        tools = tools[: args.limit]

    out_dir = Path(args.web_root) / "images" / "tutorials"
    ok = 0
    with sync_playwright() as p:
        browser = p.chromium.launch(headless=True)
        page = browser.new_page(viewport=VIEWPORT)
        for tool in tools:
            if capture_one(page, args.base_url, tool, out_dir):
                ok += 1
        browser.close()
    print(f"Captured {ok}/{len(tools)} screenshots")
    sys.exit(0 if ok == len(tools) else 1)


if __name__ == "__main__":
    main()
