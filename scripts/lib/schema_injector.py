#!/usr/bin/env python3
"""Build HowTo + FAQPage JSON-LD for localized guides."""
from __future__ import annotations

import json


def build_schema_graph(
    *,
    title: str,
    description: str,
    canonical_url: str,
    steps: list[str],
    faqs: list[dict],
    locale: str,
) -> list[dict]:
    step_label = {
        "pt": "Passo",
        "es": "Paso",
        "de": "Schritt",
        "id": "Langkah",
        "fr": "Étape",
    }
    prefix = locale.split("-")[0]
    label = step_label.get(prefix, "Step")

    graph: list[dict] = []

    if steps:
        graph.append(
            {
                "@type": "HowTo",
                "name": title,
                "description": description,
                "inLanguage": locale,
                "step": [
                    {
                        "@type": "HowToStep",
                        "position": i + 1,
                        "name": f"{label} {i + 1}",
                        "text": step,
                    }
                    for i, step in enumerate(steps)
                ],
            }
        )

    if faqs:
        graph.append(
            {
                "@type": "FAQPage",
                "inLanguage": locale,
                "mainEntity": [
                    {
                        "@type": "Question",
                        "name": faq["question"],
                        "acceptedAnswer": {
                            "@type": "Answer",
                            "text": faq["answer"],
                        },
                    }
                    for faq in faqs
                ],
            }
        )

    return graph


def render_schema_script(graph: list[dict], canonical_url: str) -> str:
    if not graph:
        return ""
    payload = {
        "@context": "https://schema.org",
        "@graph": graph,
    }
    return (
        '\n<script type="application/ld+json">'
        + json.dumps(payload, ensure_ascii=False, separators=(",", ":"))
        + "</script>"
    )
