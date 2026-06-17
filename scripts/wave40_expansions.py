"""Wave 40 — CREATE batch 4 (17 guides, score 82). Visa regional expansion + legal/real estate/student."""

W40_SLUGS = [
    "bates-numbering-pdf",
    "real-estate-disclosure-pdf-merge",
    "student-combine-lecture-pdfs",
    "pdf-vs-word-when-to-use",
    "compress-pdf-mygov-australia",
    "visa-application-pdf-workflow-argentina",
    "visa-application-pdf-workflow-poland",
    "visa-application-pdf-workflow-sweden",
    "visa-application-pdf-workflow-norway",
    "visa-application-pdf-workflow-denmark",
    "visa-application-pdf-workflow-finland",
    "visa-application-pdf-workflow-portugal",
    "visa-application-pdf-workflow-greece",
    "visa-application-pdf-workflow-turkey",
    "visa-application-pdf-workflow-egypt",
    "visa-application-pdf-workflow-morocco",
    "visa-application-pdf-workflow-nigeria",
]

LEGAL_CREATE_SLUGS = {"bates-numbering-pdf"}

REALESTATE_CREATE_SLUGS = {"real-estate-disclosure-pdf-merge"}

STUDENT_CREATE_SLUGS = {"student-combine-lecture-pdfs"}

DECISION_CREATE_SLUGS = {"pdf-vs-word-when-to-use"}

GOVT_CREATE_SLUGS = {"compress-pdf-mygov-australia"}

VISA_CREATE_SLUGS = {
    "visa-application-pdf-workflow-argentina",
    "visa-application-pdf-workflow-poland",
    "visa-application-pdf-workflow-sweden",
    "visa-application-pdf-workflow-norway",
    "visa-application-pdf-workflow-denmark",
    "visa-application-pdf-workflow-finland",
    "visa-application-pdf-workflow-portugal",
    "visa-application-pdf-workflow-greece",
    "visa-application-pdf-workflow-turkey",
    "visa-application-pdf-workflow-egypt",
    "visa-application-pdf-workflow-morocco",
    "visa-application-pdf-workflow-nigeria",
}

W40_VISA_META = {
    "argentina": ("Argentina", "Consulate &amp; VFS Pack", False, "Applicant compresses Banco Nación statement PDF for Argentina visa appointment"),
    "poland": ("Poland", "Schengen &amp; National Visa", True, "Student merges Poland visa financials, insurance, and itinerary for VFS Warsaw"),
    "sweden": ("Sweden", "Schengen &amp; Residence Permit", True, "Worker compresses employment contract and funds PDF for Sweden migration portal"),
    "norway": ("Norway", "Schengen &amp; UDI Upload", True, "Visitor merges invitation, insurance, and bank PDF for Norway UDI evidence"),
    "denmark": ("Denmark", "Schengen &amp; SIRI Pack", True, "Applicant compresses Danish bank export and admission letter for SIRI slot"),
    "finland": ("Finland", "Schengen &amp; Migri", True, "Researcher merges Migri financial proof and passport bio PDF under cap"),
    "portugal": ("Portugal", "Schengen &amp; VFS Lisbon", True, "Digital nomad compresses funds and lease PDF for Portugal visa upload"),
    "greece": ("Greece", "Schengen &amp; VFS Athens", True, "Tourist merges Greece visa insurance and itinerary — one compress pass"),
    "turkey": ("Turkey", "e-Visa &amp; Embassy Support", False, "Business visitor compresses invitation and company registration PDF for Turkey visa"),
    "egypt": ("Egypt", "Embassy &amp; e-Visa Portal", False, "Tourist compresses hotel booking and funds PDF for Egypt visa portal"),
    "morocco": ("Morocco", "Consulate &amp; VFS", False, "Applicant merges Morocco visa financial evidence and travel insurance PDF"),
    "nigeria": ("Nigeria", "Embassy &amp; VFS Lagos", False, "Student compresses admission letter and sponsor bank PDF for Nigeria visa slot"),
}

W40_DATA = {
    "bates-numbering-pdf": {
        "title": "Bates Numbering PDF — Litigation Production Stamp (2026)",
        "tool": "/pdf/pagenumbers",
        "label": "Page Numbers",
        "pillar": "/guides/add-page-numbers",
        "pillar_label": "add page numbers",
        "related": "/guides/redact-pdf-discovery",
        "prog": "/pdf/pagenumbers",
        "example": "Paralegal stamps PROD000001–PROD012400 footer on discovery production before opposing counsel delivery",
    },
    "real-estate-disclosure-pdf-merge": {
        "title": "Real Estate Disclosure PDF Merge — State Order &amp; Closing Pack (2026)",
        "tool": "/pdf/merge",
        "label": "Merge PDF",
        "pillar": "/guides/compress-pdf-real-estate",
        "pillar_label": "compress PDF real estate",
        "related": "/guides/pdf-tools-real-estate",
        "prog": "/pdf/merge",
        "example": "Agent merges lead paint, HOA, and seller disclosure PDFs in state-required order for buyer email",
    },
    "student-combine-lecture-pdfs": {
        "title": "Student Combine Lecture PDFs — Weekly Reading Pack (2026)",
        "tool": "/pdf/merge",
        "label": "Merge PDF",
        "pillar": "/guides/merge-pdf-students",
        "pillar_label": "merge PDF for students",
        "related": "/guides/pdf-workflow-students",
        "prog": "/pdf/merge",
        "example": "Undergrad merges Week 4 sociology readings — 14 files — one 22 MB PDF then compress for offline study",
    },
    "pdf-vs-word-when-to-use": {
        "title": "PDF vs Word — When to Use Each Format (2026)",
        "tool": "/pdf/pdftodoc",
        "label": "PDF to Word",
        "pillar": "/guides/pdf-to-word-vs-pdf-to-text",
        "pillar_label": "PDF to Word vs text",
        "related": "/guides/pdf-vs-word-when-to-convert",
        "prog": "/pdf/pdftodoc",
        "example": "Legal ops keeps signed contract as PDF for clients — uses Word only for internal redline draft",
    },
    "compress-pdf-mygov-australia": {
        "title": "Compress PDF for myGov Australia — Tax &amp; Centrelink Upload (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "pillar": "/guides/compress-pdf-home-affairs-australia",
        "pillar_label": "compress Home Affairs Australia",
        "related": "/guides/government-portal-pdf-compress",
        "prog": "/compress-pdf-for-government-forms",
        "example": "Taxpayer compresses scanned deduction receipt PDF from 4 MB to 1.5 MB for myGov document upload",
    },
}

for country, (name, subtitle, schengen, example) in W40_VISA_META.items():
    slug = f"visa-application-pdf-workflow-{country}"
    W40_DATA[slug] = {
        "title": f"Visa Application PDF Workflow {name} — {subtitle} (2026)",
        "tool": "/pdf/merge" if schengen else "/pdf/compress",
        "label": "Merge PDF" if schengen else "Compress PDF",
        "pillar": "/guides/merge-pdf-visa-application",
        "pillar_label": "merge PDF for visa",
        "related": "/guides/compress-pdf-schengen" if schengen else "/guides/compress-pdf-for-visa-application",
        "prog": "/compress-pdf-for-visa-application",
        "example": example,
        "country": name,
        "schengen": schengen,
    }


def _d(slug: str, html: str) -> str:
    p = W40_DATA[slug].get("prog", "")
    tail = f'<p>Tool: <a href="{p}">{p}</a></p>' if p else ""
    return html + tail


def _visa_deep(slug: str) -> str:
    d = W40_DATA[slug]
    name = d["country"]
    schengen = d["schengen"]
    schengen_block = (
        "<p>Schengen: merge cover sheet, itinerary, insurance, bank PDF — "
        '<a href="/guides/schengen-visa-pdf-merge-order">merge order guide</a> · '
        '<a href="/guides/compress-pdf-schengen">compress Schengen</a>.</p>'
        if schengen
        else "<p>Read embassy FAQ for slot caps — official PDF exports — certified translation if required.</p>"
    )
    return _d(
        slug,
        f"""
            <h2>{name} visa PDF workflow</h2>
            <ol>
            <li>Download official bank and employment PDFs — not screenshots</li>
            <li><a href="/pdf/merge">Merge</a> in embassy/VFS order if one upload</li>
            <li><a href="/pdf/compress">Compress</a> once — Less on scans</li>
            <li>Filename: LastName_DocumentType.pdf</li>
            </ol>
            {schengen_block}
            <p>Hub: <a href="/guides/pdf-regional-workflows-hub">regional workflows</a> · financial: <a href="/guides/bank-statement-pdf-visa">bank statement visa</a>.</p>
            """,
    )


W40_DEEP = {
    "bates-numbering-pdf": _d("bates-numbering-pdf", """
            <h2>Bates numbering basics</h2>
            <p>Sequential production stamps (e.g. PROD000001) on every page — required for many e-discovery productions.</p>
            <ol>
            <li>Merge exhibits in production order first</li>
            <li><a href="/pdf/pagenumbers">Page Numbers</a> — custom Bates prefix</li>
            <li>QA first/last stamp against privilege log</li>
            </ol>
            <p><a href="/guides/law-firm-pdf-discovery-workflow">Discovery workflow</a> · <a href="/guides/add-page-numbers">page numbers guide</a>.</p>
            """),
    "real-estate-disclosure-pdf-merge": _d("real-estate-disclosure-pdf-merge", """
            <h2>Disclosure merge order</h2>
            <p>Follow state-required sequence — wrong order delays closing and can trigger rescission rights.</p>
            <ol>
            <li>Lead-based paint (if applicable)</li>
            <li>HOA / condo disclosures</li>
            <li>Seller property disclosure</li>
            <li>Inspection addenda last</li>
            </ol>
            <p><a href="/guides/compress-pdf-real-estate">Compress for buyer email</a> after merge.</p>
            """),
    "student-combine-lecture-pdfs": _d("student-combine-lecture-pdfs", """
            <h2>Weekly reading merge</h2>
            <p>Prefix filenames Week04_ before upload — merge in syllabus order — <a href="/pdf/merge">Merge PDF</a>.</p>
            <p><a href="/guides/compress-pdf-students">Compress for LMS</a> · <a href="/guides/ocr-lecture-notes-students">OCR for search</a>.</p>
            """),
    "pdf-vs-word-when-to-use": _d("pdf-vs-word-when-to-use", """
            <h2>Decision matrix</h2>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>Scenario</th><th>Use PDF</th><th>Use Word</th></tr></thead>
            <tbody>
            <tr><td>Signed contract delivery</td><td>Yes — locked layout</td><td>No — editable</td></tr>
            <tr><td>Internal redline draft</td><td>No</td><td>Yes — track changes</td></tr>
            <tr><td>Portal upload</td><td>Usually PDF</td><td>Rare</td></tr>
            <tr><td>Marketing one-pager</td><td>PDF for send</td><td>Word for template edits</td></tr>
            </tbody></table></div>
            <p><a href="/guides/pdf-to-word">PDF to Word guide</a> · <a href="/guides/pdf-vs-word-when-to-convert">when to convert</a>.</p>
            """),
    "compress-pdf-mygov-australia": _d("compress-pdf-mygov-australia", """
            <h2>myGov upload tips</h2>
            <ul>
            <li>ATO and Centrelink caps vary — read in-app message</li>
            <li>200–300 DPI scan — grayscale for receipts</li>
            <li>Separate from ImmiAccount — see <a href="/guides/compress-pdf-home-affairs-australia">Home Affairs compress</a></li>
            </ul>
            <p><a href="/guides/bank-statement-pdf-workflow-australia">Australia bank workflow</a>.</p>
            """),
}

for country in W40_VISA_META:
    W40_DEEP[f"visa-application-pdf-workflow-{country}"] = _visa_deep(f"visa-application-pdf-workflow-{country}")

W40_CREATE_CLUSTER = """
            <h2>CREATE batch 4</h2>
            <ul>
            <li><a href="/guides/bates-numbering-pdf">Bates numbering</a> · <a href="/guides/real-estate-disclosure-pdf-merge">Real estate disclosure merge</a></li>
            <li><a href="/guides/student-combine-lecture-pdfs">Combine lecture PDFs</a> · <a href="/guides/pdf-vs-word-when-to-use">PDF vs Word</a></li>
            <li><a href="/guides/compress-pdf-mygov-australia">myGov Australia compress</a></li>
            <li>Visa: <a href="/guides/visa-application-pdf-workflow-argentina">Argentina</a> · <a href="/guides/visa-application-pdf-workflow-poland">Poland</a> · <a href="/guides/visa-application-pdf-workflow-sweden">Sweden</a></li>
            <li><a href="/guides/visa-application-pdf-workflow-norway">Norway</a> · <a href="/guides/visa-application-pdf-workflow-denmark">Denmark</a> · <a href="/guides/visa-application-pdf-workflow-finland">Finland</a></li>
            <li><a href="/guides/visa-application-pdf-workflow-portugal">Portugal</a> · <a href="/guides/visa-application-pdf-workflow-greece">Greece</a> · <a href="/guides/visa-application-pdf-workflow-turkey">Turkey</a></li>
            <li><a href="/guides/visa-application-pdf-workflow-egypt">Egypt</a> · <a href="/guides/visa-application-pdf-workflow-morocco">Morocco</a> · <a href="/guides/visa-application-pdf-workflow-nigeria">Nigeria</a></li>
            </ul>
            <p>Prior: <a href="/guides/pdf-too-large-to-email">batch 1</a> · <a href="/guides/bank-statement-pdf-visa">batch 2</a> · <a href="/guides/pdf-job-application-size-limit">batch 3</a></p>
            """

W40_VISA_REGIONAL_CLUSTER = """
            <h2>Wave 40 visa regional hubs</h2>
            <p>Americas: <a href="/guides/visa-application-pdf-workflow-argentina">Argentina</a> · Africa: <a href="/guides/visa-application-pdf-workflow-egypt">Egypt</a> · <a href="/guides/visa-application-pdf-workflow-morocco">Morocco</a> · <a href="/guides/visa-application-pdf-workflow-nigeria">Nigeria</a></p>
            <p>Europe Schengen: <a href="/guides/visa-application-pdf-workflow-poland">Poland</a> · <a href="/guides/visa-application-pdf-workflow-sweden">Sweden</a> · <a href="/guides/visa-application-pdf-workflow-norway">Norway</a> · <a href="/guides/visa-application-pdf-workflow-denmark">Denmark</a> · <a href="/guides/visa-application-pdf-workflow-finland">Finland</a> · <a href="/guides/visa-application-pdf-workflow-portugal">Portugal</a> · <a href="/guides/visa-application-pdf-workflow-greece">Greece</a></p>
            <p>Also: <a href="/guides/visa-application-pdf-workflow-turkey">Turkey</a> · existing: <a href="/guides/visa-application-pdf-workflow-germany">Germany</a> · <a href="/guides/visa-application-pdf-workflow-france">France</a> · <a href="/guides/pdf-regional-workflows-hub">regional hub</a></p>
            """

W40_COMPRESS_TOPUP = """
            <h2>CREATE batch 4 checklist</h2>
            <ol>
            <li>Regional visa: read embassy/VFS FAQ before merge</li>
            <li>One compress pass after final merge order</li>
            <li>Less on scans · Recommended on digital exports</li>
            <li>Link to programmatic tool landing where distinct from editorial guide</li>
            </ol>
            """

W40_CLOSING = """
            <h2>Related guides</h2>
            <p>Wave 40 expands regional visa workflows (12 countries), Bates numbering, real estate disclosure merge, student lecture packs, PDF vs Word decision guide, and myGov Australia compress — CREATE batch 4 of 450.</p>
            <p>Hub: <a href="/guides/pdf-regional-workflows-hub">regional workflows</a> · CREATE remaining: 382</p>
            """
