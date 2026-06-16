"""Wave 14 — Browser + device matrix: merge, split, convert, OCR on Mac/Windows/mobile."""

W14_SLUGS = [
    "pdf-device-workflows-hub",
    "merge-pdf-on-mac",
    "merge-pdf-windows-11",
    "merge-pdf-on-android",
    "pdf-to-word-on-mac",
    "scan-to-pdf-phone",
    "split-pdf-on-mac",
    "split-pdf-on-windows",
    "ocr-pdf-on-phone",
    "safari-save-as-pdf",
    "firefox-save-as-pdf",
    "browser-vs-desktop-pdf-tools",
    "pdf-tools-on-chromebook",
    "pdf-workflow-on-ipad",
    "split-pdf-on-iphone",
    "convert-pdf-on-android",
    "linux-pdf-tools-browser",
]

W14_DATA = {
    "pdf-device-workflows-hub": {
        "title": "PDF Device Workflows Hub — Mac, Windows, Mobile &amp; Browser Index (2026)",
        "tool": "/guides/pdf-tools",
        "label": "PDF tools hub",
        "example": "IT wiki landing page linking merge, split, convert, and OCR paths per device",
    },
    "merge-pdf-on-mac": {
        "title": "Merge PDF on Mac — Preview vs Browser Workflow (2026)",
        "tool": "/pdf/merge",
        "label": "Merge PDF",
        "example": "Paralegal combines exhibit PDFs in Finder order via browser merge — not Preview drag",
    },
    "merge-pdf-windows-11": {
        "title": "Merge PDF on Windows 11 — Edge Browser Combine Workflow (2026)",
        "tool": "/pdf/merge",
        "label": "Merge PDF",
        "example": "HR merges offer letter, policy, and benefits PDFs in Edge without Acrobat install",
    },
    "merge-pdf-on-android": {
        "title": "Merge PDF on Android — Chrome Mobile Combine Workflow (2026)",
        "tool": "/pdf/merge",
        "label": "Merge PDF",
        "example": "Student merges weekly reading PDFs on phone before LMS upload from Downloads",
    },
    "pdf-to-word-on-mac": {
        "title": "PDF to Word on Mac — Safari Export Without Acrobat (2026)",
        "tool": "/pdf/pdftodoc",
        "label": "PDF to Word",
        "example": "Consultant converts client contract PDF to DOCX for redlines in Word for Mac",
    },
    "scan-to-pdf-phone": {
        "title": "Scan to PDF on Phone — Camera, Notes &amp; Compress Chain (2026)",
        "tool": "/pdf/convertimages",
        "label": "Images to PDF",
        "example": "Field tech scans equipment nameplate photos into one PDF for ticket attachment",
    },
    "split-pdf-on-mac": {
        "title": "Split PDF on Mac — Extract Pages in Safari (2026)",
        "tool": "/pdf/split",
        "label": "Split PDF",
        "example": "Accountant splits 200-page audit PDF into quarterly sections for partner review",
    },
    "split-pdf-on-windows": {
        "title": "Split PDF on Windows — Page Range in Edge (2026)",
        "tool": "/pdf/split",
        "label": "Split PDF",
        "example": "Admin splits employee handbook by department chapters for intranet upload",
    },
    "ocr-pdf-on-phone": {
        "title": "OCR PDF on Phone — Make Scans Searchable on Mobile (2026)",
        "tool": "/pdf/ocrpdf",
        "label": "OCR PDF",
        "example": "Insurance adjuster OCRs scene photos PDF on iPhone before email to claims desk",
    },
    "safari-save-as-pdf": {
        "title": "Safari Save as PDF — Mac &amp; iOS Export Settings (2026)",
        "tool": "/guides/pdf-tools",
        "label": "PDF tools hub",
        "example": "Researcher saves journal article page as PDF from Safari Reader view on MacBook",
    },
    "firefox-save-as-pdf": {
        "title": "Firefox Save as PDF — Print Dialog &amp; Privacy Workflow (2026)",
        "tool": "/guides/pdf-tools",
        "label": "PDF tools hub",
        "example": "Privacy-conscious user exports government form instructions as PDF in Firefox",
    },
    "browser-vs-desktop-pdf-tools": {
        "title": "Browser vs Desktop PDF Tools — Privacy, Speed &amp; Compliance (2026)",
        "tool": "/compare",
        "label": "Compare hub",
        "example": "SMB IT evaluates RatPDF browser stack vs Acrobat for 40-seat hybrid workforce",
    },
    "pdf-tools-on-chromebook": {
        "title": "PDF Tools on Chromebook — Chrome OS Browser Workflow (2026)",
        "tool": "/guides/pdf-tools",
        "label": "PDF tools hub",
        "example": "School district students merge and compress assignment PDFs on district Chromebooks",
    },
    "pdf-workflow-on-ipad": {
        "title": "PDF Workflow on iPad — Files, Split Screen &amp; Pencil Markup (2026)",
        "tool": "/guides/pdf-tools",
        "label": "PDF tools hub",
        "example": "Architect reviews spec PDF on iPad Pro — split screen with email — merge markups on desktop",
    },
    "split-pdf-on-iphone": {
        "title": "Split PDF on iPhone — Extract Pages on Mobile Safari (2026)",
        "tool": "/pdf/split",
        "label": "Split PDF",
        "example": "Traveler splits e-ticket PDF — keeps boarding pass page — deletes itinerary pages",
    },
    "convert-pdf-on-android": {
        "title": "Convert PDF on Android — Word, Excel &amp; Images in Chrome (2026)",
        "tool": "/pdf/pdftodoc",
        "label": "PDF to Word",
        "example": "Sales rep converts brochure PDF to DOCX on tablet for quick client customization",
    },
    "linux-pdf-tools-browser": {
        "title": "Linux PDF Tools in Browser — No apt Install Workflow (2026)",
        "tool": "/guides/pdf-tools",
        "label": "PDF tools hub",
        "example": "Ubuntu developer merges API doc PDFs in Firefox without local poppler install",
    },
}

W14_DEEP = {
    "pdf-device-workflows-hub": """
            <h2>Hub index</h2>
            <ul>
            <li><a href="/guides/merge-pdf-on-mac">Merge Mac</a> · <a href="/guides/merge-pdf-windows-11">Merge Windows</a> · <a href="/guides/merge-pdf-on-android">Merge Android</a></li>
            <li><a href="/guides/split-pdf-on-mac">Split Mac</a> · <a href="/guides/split-pdf-on-windows">Split Windows</a> · <a href="/guides/split-pdf-on-iphone">Split iPhone</a></li>
            <li><a href="/guides/pdf-to-word-on-mac">PDF to Word Mac</a> · <a href="/guides/convert-pdf-on-android">Convert Android</a></li>
            <li><a href="/guides/scan-to-pdf-phone">Scan to PDF phone</a> · <a href="/guides/ocr-pdf-on-phone">OCR on phone</a></li>
            <li><a href="/guides/safari-save-as-pdf">Safari save PDF</a> · <a href="/guides/firefox-save-as-pdf">Firefox save PDF</a> · <a href="/guides/chrome-save-as-pdf-settings">Chrome settings</a></li>
            <li><a href="/guides/compress-pdf-on-mac">Compress Mac</a> · <a href="/guides/compress-pdf-on-windows">Compress Windows</a> · <a href="/guides/compress-pdf-on-iphone">Compress iPhone</a></li>
            <li><a href="/guides/edit-pdf-on-mac">Edit Mac</a> · <a href="/guides/edit-pdf-on-windows">Edit Windows</a> · <a href="/guides/edit-pdf-on-iphone">Edit iPhone</a></li>
            <li><a href="/guides/pdf-tools-on-chromebook">Chromebook</a> · <a href="/guides/linux-pdf-tools-browser">Linux browser</a> · <a href="/guides/pdf-workflow-on-ipad">iPad workflow</a></li>
            <li><a href="/guides/browser-vs-desktop-pdf-tools">Browser vs desktop</a> · <a href="/guides/pdf-printing-guide">Printing hub</a></li>
            </ul>
            """,
    "merge-pdf-on-mac": """
            <h2>Preview limits</h2>
            <p>Preview can combine PDFs but order control is awkward — no batch queue — browser <a href="/pdf/merge">Merge PDF</a> shows thumbnail order before export.</p>
            <h2>Mac workflow</h2>
            <ol>
            <li>Rename files <code>01_cover.pdf</code>, <code>02_body.pdf</code> in Finder</li>
            <li>Open Safari → RatPDF Merge PDF</li>
            <li>Drag files in order — verify thumbnails</li>
            <li>Download to Downloads — move to iCloud if needed</li>
            <li><a href="/pdf/compress">Compress</a> if email cap exceeded</li>
            </ol>
            <p>Pillar: <a href="/guides/merge-pdf">merge PDF guide</a> · Preview alternative: drag to Merge queue only when 2 files.</p>
            """,
    "merge-pdf-windows-11": """
            <h2>Why browser on Windows 11</h2>
            <p>IT blocks Acrobat install — Edge and Chrome run RatPDF merge without admin rights — same engine as Mac.</p>
            <h2>Workflow</h2>
            <ol>
            <li>Select PDFs in File Explorer — note numeric order</li>
            <li>Edge → Merge PDF — upload queue</li>
            <li>Reorder with drag — merge — save to Documents</li>
            <li>Attach in Outlook — compress if over 20 MB</li>
            </ol>
            <p>Windows print-to-PDF: <a href="/guides/print-to-pdf-windows">print to PDF guide</a>.</p>
            """,
    "merge-pdf-on-android": """
            <h2>Mobile merge cautions</h2>
            <p>Do not merge from WhatsApp preview paths — ephemeral cache — save each PDF to Downloads or Files first.</p>
            <h2>Android steps</h2>
            <ol>
            <li>Chrome → Merge PDF</li>
            <li>Upload from Downloads — order by filename prefix</li>
            <li>Download merged file — share to Gmail or Drive</li>
            </ol>
            <p>Large packs: merge on desktop if Chrome tab crashes — split source first.</p>
            """,
    "pdf-to-word-on-mac": """
            <h2>Preview is not Word export</h2>
            <p>Preview exports PDF but does not produce editable DOCX with tables — use <a href="/pdf/pdftodoc">PDF to Word</a> in Safari.</p>
            <h2>Scanned PDFs</h2>
            <p>Run <a href="/pdf/ocrpdf">OCR PDF</a> first — then PDF to Word — see <a href="/guides/scanned-pdf-to-word">scanned PDF to Word</a>.</p>
            <h2>Workflow</h2>
            <ol>
            <li>Upload PDF in Safari</li>
            <li>Download DOCX — open in Word for Mac</li>
            <li>Track changes for redlines — export PDF when done</li>
            </ol>
            """,
    "scan-to-pdf-phone": """
            <h2>Phone scan paths</h2>
            <ul>
            <li><strong>iOS Notes</strong> — scan document — share PDF — optional <a href="/pdf/compress">compress</a></li>
            <li><strong>Google Drive scan</strong> — Android — export PDF</li>
            <li><strong>Camera photos</strong> — <a href="/pdf/convertimages">Images to PDF</a> multi-page</li>
            </ul>
            <h2>Quality</h2>
            <p>200–300 DPI equivalent — flat surface — avoid shadow — OCR after if search needed.</p>
            """,
    "split-pdf-on-mac": """
            <h2>Preview split limits</h2>
            <p>Preview can delete pages manually — tedious on 100+ pages — <a href="/pdf/split">Split PDF</a> by range is faster.</p>
            <h2>Workflow</h2>
            <ol>
            <li>Note page ranges per section</li>
            <li>Split PDF tool — extract range — download</li>
            <li>Label <code>Q1_audit.pdf</code> etc.</li>
            </ol>
            <p>Pillar: <a href="/guides/split-pdf">split PDF guide</a>.</p>
            """,
    "split-pdf-on-windows": """
            <h2>Edge workflow</h2>
            <p>No built-in split in Windows — browser Split PDF — page range or every N pages.</p>
            <h2>Email parts</h2>
            <p>Split before attach if over gateway limit — see <a href="/guides/split-pdf-for-email">split for email</a>.</p>
            """,
    "ocr-pdf-on-phone": """
            <h2>When mobile OCR works</h2>
            <p>Single receipt or 5-page scan — upload to <a href="/pdf/ocrpdf">OCR PDF</a> in mobile Safari/Chrome — download searchable PDF.</p>
            <h2>When wait for desktop</h2>
            <p>100+ page discovery — Wi-Fi stability — batch on laptop — phone for urgent 1–3 page field capture.</p>
            <h2>Chain</h2>
            <p>OCR → <a href="/pdf/pdftodoc">PDF to Word</a> or <a href="/pdf/pdftotext">PDF to Text</a> as needed.</p>
            """,
    "safari-save-as-pdf": """
            <h2>Mac Safari</h2>
            <p>File → Export as PDF — or Print → PDF → Save as PDF — Reader view for clean article capture.</p>
            <h2>iOS Safari</h2>
            <p>Share → Options → PDF — full page or visible portion — saves to Files.</p>
            <h2>vs Chrome</h2>
            <p>Compare <a href="/guides/chrome-save-as-pdf-settings">Chrome save as PDF settings</a> — background graphics differ.</p>
            """,
    "firefox-save-as-pdf": """
            <h2>Firefox print to PDF</h2>
            <p>Ctrl+P → Save to PDF — scale and margins — disable headers for clean export.</p>
            <h2>Privacy angle</h2>
            <p>Firefox containers isolate sessions — export sensitive intranet page from correct container profile.</p>
            <h2>Linux</h2>
            <p>Primary browser for many Linux users — pairs with <a href="/guides/linux-pdf-tools-browser">Linux PDF tools guide</a>.</p>
            """,
    "browser-vs-desktop-pdf-tools": """
            <h2>Decision matrix</h2>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>Factor</th><th>Browser (RatPDF)</th><th>Desktop (Acrobat/Foxit)</th></tr></thead>
            <tbody>
            <tr><td>Install</td><td>None — Edge/Safari</td><td>IT deploy + license</td></tr>
            <tr><td>PII upload</td><td>HTTPS + auto-delete policy</td><td>Offline option</td></tr>
            <tr><td>PDF/X prepress</td><td>No</td><td>Yes</td></tr>
            <tr><td>Batch OCR</td><td>Per file</td><td>Actions wizard</td></tr>
            <tr><td>Merge/split daily</td><td>Free tier sufficient SMB</td><td>Overkill cost</td></tr>
            </tbody>
            </table></div>
            <p>Hybrid: browser for 90% tasks — desktop for regulated batch — see <a href="/compare">compare tools</a>.</p>
            """,
    "pdf-tools-on-chromebook": """
            <h2>Chrome OS reality</h2>
            <p>No native Acrobat — Play Store PDF apps vary — RatPDF in Chrome covers merge, split, compress, convert.</p>
            <h2>School workflow</h2>
            <ol>
            <li>Save Google Classroom PDFs to Files</li>
            <li>Merge weekly readings in browser</li>
            <li>Compress if LMS rejects size</li>
            </ol>
            <p>Same URLs as <a href="/guides/compress-pdf-on-windows">Windows Chrome</a> workflow.</p>
            """,
    "pdf-workflow-on-ipad": """
            <h2>iPad multitasking</h2>
            <p>Split View — Safari RatPDF tool + Mail — drag PDF from Files — download result to iCloud Drive.</p>
            <h2>Apple Pencil</h2>
            <p>Markup in Files/Preview — for formal sign use <a href="/guides/edit-pdf-on-iphone">edit workflow</a> or desktop flatten.</p>
            <h2>Keyboard</h2>
            <p>Magic Keyboard — desktop-class Safari — prefer iPad for review — Mac for 50-file merge queue.</p>
            """,
    "split-pdf-on-iphone": """
            <h2>Travel use case</h2>
            <p>Extract single boarding pass page — delete rest — smaller attachment for expense report.</p>
            <h2>Steps</h2>
            <ol>
            <li>Safari → Split PDF</li>
            <li>Enter page number or range</li>
            <li>Download — save to Files — AirDrop to Mac if needed</li>
            </ol>
            """,
    "convert-pdf-on-android": """
            <h2>Convert tools on mobile</h2>
            <p><a href="/pdf/pdftodoc">PDF to Word</a> · <a href="/pdf/pdftoexcel">PDF to Excel</a> · <a href="/pdf/pdftoimages">PDF to Images</a> — same Chrome UI as desktop.</p>
            <h2>Table PDFs</h2>
            <p>Excel export for numeric tables — Word for narrative — OCR scans first.</p>
            <h2>Download path</h2>
            <p>Save to Downloads — open in Google Docs optional — not required for RatPDF flow.</p>
            """,
    "linux-pdf-tools-browser": """
            <h2>Why browser on Linux</h2>
            <p>Corporate Ubuntu may block apt installs — Firefox/Chrome RatPDF needs no poppler,qpdf local packages.</p>
            <h2>Dev workflow</h2>
            <p>Merge release note PDFs — extract text for changelog — <a href="/pdf/pdftotext">PDF to Text</a> — CI still uses pdftotext on server when allowed.</p>
            <h2>Firefox + Flatpak</h2>
            <p>Sandboxed browser — upload still HTTPS — review <a href="/home/privacy">privacy policy</a> for client docs.</p>
            """,
}

W14_SLUG_EXTRA = {
    "pdf-device-workflows-hub": """
            <h2>Onboarding</h2>
            <p>New hire wiki — pick device section — reduces "which tool on Mac?" Slack questions.</p>
            """,
    "merge-pdf-on-mac": """
            <h2>Finder Quick Action trap</h2>
            <p>Quick Actions create PDF but not ordered merge — use explicit Merge tool for 5+ files.</p>
            """,
    "merge-pdf-windows-11": """
            <h2>Teams share</h2>
            <p>Merge policy PDFs — single attachment in Teams channel — compress if over tenant limit.</p>
            """,
    "merge-pdf-on-android": """
            <h2>Naukri upload</h2>
            <p>Merge resume + certificates — verify order — compress — upload from Downloads not chat.</p>
            """,
    "pdf-to-word-on-mac": """
            <h2>Contract redline</h2>
            <p>PDF to Word — track changes — export PDF — never edit signed PDF in place.</p>
            """,
    "scan-to-pdf-phone": """
            <h2>Warranty claim</h2>
            <p>Three angle photos → Images to PDF → compress → upload portal same day.</p>
            """,
    "split-pdf-on-mac": """
            <h2>Quarterly audit</h2>
            <p>Split 400-page PDF into Q1–Q4 — email partners one section each.</p>
            """,
    "split-pdf-on-windows": """
            <h2>Handbook chapters</h2>
            <p>Split by page map HR provided — upload each to SharePoint library.</p>
            """,
    "ocr-pdf-on-phone": """
            <h2>Receipt field</h2>
            <p>Photo scan → OCR in browser → searchable for expense keyword before desktop merge.</p>
            """,
    "safari-save-as-pdf": """
            <h2>Paywalled article</h2>
            <p>Save institutional access page you are entitled to — not circumvention — policy applies.</p>
            """,
    "firefox-save-as-pdf": """
            <h2>Intranet SOP</h2>
            <p>Export procedure page from Firefox container — attach to ticket — metadata shows export date.</p>
            """,
    "browser-vs-desktop-pdf-tools": """
            <h2>CFO approval</h2>
            <p>Document $12k Acrobat renewal vs browser stack — hybrid saves 8 seats.</p>
            """,
    "pdf-tools-on-chromebook": """
            <h2>District policy</h2>
            <p>Only browser extensions allowed — RatPDF domain allowlisted — merge works class-wide.</p>
            """,
    "pdf-workflow-on-ipad": """
            <h2>Client markup</h2>
            <p>Markup on iPad — flatten on Mac morning — send final PDF before standup.</p>
            """,
    "split-pdf-on-iphone": """
            <h2>Hotel Wi-Fi</h2>
            <p>Split large itinerary — email only boarding pass — saves attachment rejection.</p>
            """,
    "convert-pdf-on-android": """
            <h2>Brochure tweak</h2>
            <p>PDF to Word on tablet — change one pricing line — Word to PDF — email client before flight.</p>
            """,
    "linux-pdf-tools-browser": """
            <h2>CI laptop</h2>
            <p>No root on build agent laptop — browser merge release PDFs — same as developer docs.</p>
            """,
}

W14_MEGA = """
            <h2>One engine, every device</h2>
            <p>RatPDF tools run in the browser — Safari, Edge, Chrome, Firefox — Mac, Windows, Chromebook, Linux, iOS, Android. No separate app builds — bookmark <a href="/guides/pdf-tools">PDF tools hub</a> on each device.</p>
            <h2>Device vs compress cluster</h2>
            <p>See also <a href="/guides/compress-pdf-on-mac">compress on Mac/Windows/iPhone/Android</a>, <a href="/guides/edit-pdf-on-mac">edit on Mac/Windows/iPhone</a>, and print-to-PDF guides — plus merge, split, convert, OCR, and browser export help on this page.</p>
            <h2>Upload hygiene</h2>
            <p>Save to Files/Downloads before upload — not chat preview — stable path — delete sensitive outputs from Downloads on shared devices same day.</p>
            """

W14_CLUSTER = """
            <h2>Browser &amp; device guides</h2>
            <ul>
            <li><a href="/guides/merge-pdf-on-mac">Merge Mac</a> · <a href="/guides/merge-pdf-windows-11">Merge Windows 11</a> · <a href="/guides/merge-pdf-on-android">Merge Android</a></li>
            <li><a href="/guides/split-pdf-on-mac">Split Mac</a> · <a href="/guides/split-pdf-on-windows">Split Windows</a> · <a href="/guides/split-pdf-on-iphone">Split iPhone</a></li>
            <li><a href="/guides/pdf-to-word-on-mac">PDF to Word Mac</a> · <a href="/guides/convert-pdf-on-android">Convert Android</a> · <a href="/guides/ocr-pdf-on-phone">OCR phone</a></li>
            <li><a href="/guides/scan-to-pdf-phone">Scan to PDF phone</a> · <a href="/guides/pdf-workflow-on-ipad">iPad workflow</a></li>
            <li><a href="/guides/safari-save-as-pdf">Safari PDF</a> · <a href="/guides/firefox-save-as-pdf">Firefox PDF</a> · <a href="/guides/chrome-save-as-pdf-settings">Chrome PDF</a></li>
            <li><a href="/guides/pdf-tools-on-chromebook">Chromebook</a> · <a href="/guides/linux-pdf-tools-browser">Linux browser</a></li>
            <li><a href="/guides/browser-vs-desktop-pdf-tools">Browser vs desktop</a></li>
            </ul>
            <p>Hub: <a href="/guides/pdf-device-workflows-hub">Device workflows hub</a> · Compress: <a href="/guides/compress-pdf-on-windows">Windows</a> · Print: <a href="/guides/pdf-printing-guide">printing hub</a>.</p>
            """

W14_1500_TOPUP = """
            <h2>Device workflow checklist</h2>
            <ol>
            <li>Correct browser (Safari/Edge/Chrome) for your OS</li>
            <li>Files saved to stable Downloads/Files path</li>
            <li>Numeric filename prefixes before merge</li>
            <li>OCR before PDF to Word on scans</li>
            <li>Compress after merge if portal/email cap</li>
            <li>Clear Downloads on shared devices</li>
            </ol>
            <h2>Pillars</h2>
            <p><a href="/guides/merge-pdf">Merge</a> · <a href="/guides/split-pdf">Split</a> · <a href="/guides/pdf-to-word">PDF to Word</a> · <a href="/guides/ocr-pdf">OCR</a> · <a href="/compare">Compare</a>.</p>
            """

W14_CLOSING = """
            <h2>Related guides</h2>
            <p>Browser and device guides for merge, split, convert, OCR, scan, and export on Mac, Windows, mobile, Chromebook, and Linux — with links to related compression, editing, and printing help.</p>
            <p>Regional workflow guides — bookmark the <a href="/guides/pdf-device-workflows-hub">device workflows index</a>.</p>
            """

PILLAR_SLUGS = {"pdf-device-workflows-hub"}
