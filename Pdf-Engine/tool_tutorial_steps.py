"""Step definitions + click markers for tutorial slide videos."""
from __future__ import annotations

from dataclasses import dataclass


@dataclass
class Step:
    text: str
    marker_x: float | None = None
    marker_y: float | None = None
    click_label: str | None = None


def _pdf_upload(name: str) -> list[Step]:
    return [
        Step(f"Open {name} on RatPDF — no install needed."),
        Step("Drag your file into the upload box, or click to browse.", 0.50, 0.40, "Upload here"),
        Step("Click the main button to start processing.", 0.50, 0.68, "Click to process"),
        Step("Download your finished file when processing completes.", 0.50, 0.84, "Download"),
    ]


def _calculator(name: str) -> list[Step]:
    return [
        Step(f"Open {name} on RatPDF."),
        Step("Enter your values in the form fields.", 0.50, 0.45, "Enter values"),
        Step("Click Calculate to see the result.", 0.50, 0.72, "Calculate"),
        Step("Read the score or result on screen.", 0.50, 0.55, "Result"),
    ]


_OVERRIDES: dict[str, list[Step]] = {
    "compress": [
        Step("Open Compress PDF on RatPDF."),
        Step("Upload your PDF — drag and drop or click the upload zone.", 0.50, 0.38, "Upload PDF"),
        Step("Choose Low, Medium, or High compression.", 0.50, 0.55, "Compression level"),
        Step("Click Compress PDF, then download the smaller file.", 0.50, 0.72, "Compress button"),
    ],
    "merge": [
        Step("Open Merge PDF."),
        Step("Upload two or more PDF files.", 0.50, 0.40, "Upload files"),
        Step("Drag files to reorder if needed.", 0.50, 0.52, "Reorder list"),
        Step("Click Merge PDF and download the combined file.", 0.50, 0.72, "Merge button"),
    ],
    "htmltopdf": [
        Step("Open HTML to PDF."),
        Step("Paste HTML or upload an .html file.", 0.50, 0.42, "HTML editor"),
        Step("Click Convert HTML to PDF.", 0.50, 0.72, "Convert button"),
        Step("Download your PDF.", 0.50, 0.84, "Download"),
    ],
}


def get_steps(tool: dict) -> list[Step]:
    slug = tool["slug"]
    name = tool["name"]
    url = tool.get("url", "")

    if slug in _OVERRIDES:
        return _OVERRIDES[slug]

    if url.startswith("/pdf/") or url == "/pdf-redaction":
        return _pdf_upload(name)

    if "calculator" in slug or "calculator" in url or slug in (
        "heart-score", "wells-score", "has-bled-score", "parkland-formula", "nihss-calculator"
    ):
        return _calculator(name)

    if url.startswith("/invoice") or "payslip" in slug or "receipt" in slug:
        return [
            Step(f"Open {name}."),
            Step("Fill in the form fields.", 0.50, 0.42, "Form fields"),
            Step("Click Generate or Create.", 0.50, 0.70, "Generate PDF"),
            Step("Download your PDF.", 0.50, 0.82, "Download PDF"),
        ]

    if slug in ("jsonformatter", "jwtdecoder", "htmlformatter", "text-comparer", "url-encoder", "url-decoder"):
        return [
            Step(f"Open {name}."),
            Step("Paste or type your content in the editor.", 0.50, 0.45, "Paste here"),
            Step("Click the format or decode button.", 0.50, 0.68, "Run tool"),
            Step("Copy the output from the result panel.", 0.50, 0.55, "Output"),
        ]

    return _pdf_upload(name)
