"""Build full tools manifest from C# constants (no dotnet build required)."""
import json
import re
from pathlib import Path

ROOT = Path(__file__).resolve().parent.parent / "Constants"


def slug_from_url(url: str) -> str:
    url = url.strip().rstrip("/").lower()
    if url.startswith("/pdf/"):
        return url[len("/pdf/") :].replace("/", "-")
    if url.startswith("/tools/"):
        return url[len("/tools/") :].replace("/", "-")
    return url.lstrip("/").replace("/", "-")


def add(tools: dict, name: str, url: str) -> None:
    key = url.lower().rstrip("/") or "/"
    if key in tools:
        return
    slug = slug_from_url(url)
    tools[key] = {"slug": slug, "name": name, "file": f"{slug}.mp4", "url": url}


def parse_tuple_tools(text: str, tools: dict) -> None:
    for name, url in re.findall(r'\("([^"]+)", "(/[^"]+)"', text):
        add(tools, name, url)


def parse_nav_tools(text: str, tools: dict) -> None:
    for name, url in re.findall(r'new\("([^"]+)", "(/[^"]+)"\)', text):
        add(tools, name, url)


def main() -> None:
    tools: dict[str, dict] = {}
    parse_tuple_tools((ROOT / "PdfToolSeo.cs").read_text(encoding="utf-8"), tools)
    nav = (ROOT / "SiteToolNavigation.cs").read_text(encoding="utf-8")
    parse_nav_tools(nav, tools)
    add(tools, "PDF Redaction", "/pdf-redaction")
    add(tools, "Invoice Generator", "/invoice/create")

    manifest = {"tools": sorted(tools.values(), key=lambda t: t["name"].lower())}
    out = Path(__file__).parent / "tools-manifest.json"
    out.write_text(json.dumps(manifest, indent=2), encoding="utf-8")
    print(f"Wrote {len(manifest['tools'])} tools to {out}")


if __name__ == "__main__":
    main()
