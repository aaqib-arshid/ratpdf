#!/usr/bin/env python3
"""Link graph report for Wave 1 upgraded guides."""
import re
from pathlib import Path

SLUGS = [
    "invoice-generator-australia", "invoice-generator-canada", "invoice-generator-france",
    "invoice-generator-germany", "invoice-generator-new-zealand", "invoice-generator-philippines",
    "invoice-generator-singapore", "invoice-generator-south-africa", "invoice-generator-uae",
    "invoice-generator-uk", "bulk-gst-invoice-generator", "recurring-invoice-generator",
    "pdf-to-word-mac", "pdf-to-word-keep-formatting", "scanned-pdf-to-word",
]

CLUSTER_GUIDES = {
    "invoice": {
        "invoice-generator-guide", "invoice-generator-india", "invoice-generator-usa",
        "recurring-invoice-generator", "bulk-gst-invoice-generator",
        "invoice-generator-australia", "invoice-generator-canada", "invoice-generator-france",
        "invoice-generator-germany", "invoice-generator-new-zealand", "invoice-generator-philippines",
        "invoice-generator-singapore", "invoice-generator-south-africa", "invoice-generator-uae",
        "invoice-generator-uk",
    },
    "pdf-to-word": {
        "pdf-to-word", "pdf-to-word-mac", "pdf-to-word-keep-formatting", "scanned-pdf-to-word",
    },
}

TOOL_CTA = {
    "invoice-generator-australia": "/invoice/create",
    "invoice-generator-canada": "/invoice/create",
    "invoice-generator-france": "/invoice/create",
    "invoice-generator-germany": "/invoice/create",
    "invoice-generator-new-zealand": "/invoice/create",
    "invoice-generator-philippines": "/invoice/create",
    "invoice-generator-singapore": "/invoice/create",
    "invoice-generator-south-africa": "/invoice/create",
    "invoice-generator-uae": "/invoice/create",
    "invoice-generator-uk": "/invoice/create",
    "bulk-gst-invoice-generator": "/invoice/bulk",
    "recurring-invoice-generator": "/invoice/create",
    "pdf-to-word-mac": "/pdf/pdftodoc",
    "pdf-to-word-keep-formatting": "/pdf/pdftodoc",
    "scanned-pdf-to-word": "/pdf/pdftodoc",
}


def slug_cluster(slug: str) -> str:
    if slug.startswith("invoice") or slug in ("bulk-gst-invoice-generator", "recurring-invoice-generator"):
        return "invoice"
    return "pdf-to-word"


def main():
    raw = Path(__file__).resolve().parents[1] / "Content" / "GuideBodiesWave1.cs"
    text = raw.read_text(encoding="utf-8")
    blocks = dict(zip(
        re.findall(r'"([\w-]+)" =>', text),
        re.findall(r'private const string \w+ = """(.*?)""";', text, re.S),
    ))

    inbound: dict[str, list[str]] = {s: [] for s in SLUGS}
    print("# Wave 1 Link Graph Report\n")

    for slug in SLUGS:
        body = blocks.get(slug, "")
        links = re.findall(r'href="(/[^"]+)"', body)
        guide_links = [l for l in links if l.startswith("/guides/")]
        research = [l for l in links if l.startswith("/research/")]
        compare = [l for l in links if l.startswith("/compare")]
        tools = [l for l in links if l.startswith("/pdf/") or l.startswith("/invoice/")]

        cluster = slug_cluster(slug)
        cluster_set = CLUSTER_GUIDES[cluster]
        same_cluster = [l for l in guide_links if l.replace("/guides/", "") in cluster_set and l != f"/guides/{slug}"]

        for gl in guide_links:
            target = gl.replace("/guides/", "")
            if target in SLUGS and target != slug:
                inbound[target].append(slug)

        print(f"## {slug}")
        print(f"- Outbound total: {len(links)}")
        print(f"- Same-cluster guide links: {len(same_cluster)} — {', '.join(same_cluster[:6])}")
        print(f"- Research links: {len(research)} — {', '.join(set(research))}")
        print(f"- Compare links: {len(compare)} — {', '.join(set(compare))}")
        print(f"- Tool CTAs: {TOOL_CTA[slug]} (refs in body: {sum(1 for t in tools if t == TOOL_CTA[slug])})")
        print(f"- Mid/end/FAQ CTAs: mid={('rp-mid-cta' in body)}, end btn={('btn btn-primary' in body)}, faq={('rp-faq-cta' in body)}")
        print()

    print("## Inbound links (from other Wave 1 pages)")
    for slug in SLUGS:
        print(f"- {slug}: {len(inbound[slug])} inbound — from {', '.join(inbound[slug]) or 'none'}")

    print("\n## Cluster coverage")
    for cluster, members in CLUSTER_GUIDES.items():
        wave = [m for m in members if m in SLUGS]
        print(f"- {cluster}: {len(wave)} Wave 1 pages cross-linked in bodies")


if __name__ == "__main__":
    main()
