"""Wave 9 — PDF Troubleshooting hub: won't open, corrupt, repair, print, portal errors."""

W9_SLUGS = [
    "pdf-won-t-open",
    "pdf-file-corrupted",
    "repair-pdf-online",
    "pdf-attachment-blocked",
    "pdf-printing-blank-pages",
    "print-pdf-without-margins",
    "pdf-colors-wrong-when-printing",
    "pdf-troubleshooting",
    "corrupted-pdf-repair",
    "pdf-blank-pages-after-merge",
    "pdf-file-too-large-to-email",
    "pdf-fonts-missing",
    "pdf-text-not-selectable",
    "pdf-upload-failed-portal",
    "pdf-wont-open-password-unknown",
    "pdf-merge-failed-error",
    "pdf-download-incomplete",
]

W9_DATA = {
    "pdf-won-t-open": {
        "title": "PDF Won't Open — Fix Viewer, Download &amp; Format Errors (2026)",
        "tool": "/guides/pdf-tools",
        "label": "PDF tools hub",
        "example": "Chrome shows blank screen or 'Failed to load PDF document' on emailed contract",
    },
    "pdf-file-corrupted": {
        "title": "PDF File Corrupted — Diagnose Damage &amp; Recover Content (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "example": "Merge job fails midway — viewer says file is damaged or has no pages",
    },
    "repair-pdf-online": {
        "title": "Repair PDF Online — Honest Limits &amp; Browser Workarounds (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "example": "User searches repair after partial download from flaky hotel Wi-Fi",
    },
    "pdf-attachment-blocked": {
        "title": "PDF Attachment Blocked — Email Security &amp; Size Fixes (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "example": "Outlook blocks 22 MB scan — recipient never receives claim PDF",
    },
    "pdf-printing-blank-pages": {
        "title": "PDF Printing Blank Pages — Driver, Layer &amp; Font Fixes (2026)",
        "tool": "/pdf/flatten",
        "label": "Flatten PDF",
        "example": "Contract prints fine on screen but paper comes out blank from office laser",
    },
    "print-pdf-without-margins": {
        "title": "Print PDF Without Margins — Fit to Page &amp; Crop Workarounds (2026)",
        "tool": "/guides/pdf-tools",
        "label": "PDF tools hub",
        "example": "Architect wants full-bleed site plan without white letterbox margins",
    },
    "pdf-colors-wrong-when-printing": {
        "title": "PDF Colors Wrong When Printing — RGB vs CMYK &amp; Printer Profiles (2026)",
        "tool": "/guides/pdf-tools",
        "label": "PDF tools hub",
        "example": "Brand red logo prints orange on office MFP — screen preview looked correct",
    },
    "pdf-troubleshooting": {
        "title": "PDF Troubleshooting Hub — Won't Open, Corrupt, Print &amp; Upload Fixes (2026)",
        "tool": "/guides/pdf-tools",
        "label": "PDF tools hub",
        "example": "IT helpdesk index for most common PDF failure modes and RatPDF workarounds",
    },
    "corrupted-pdf-repair": {
        "title": "Corrupted PDF Repair — Re-export, Compress &amp; Split Recovery (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "example": "USB copy interrupted — Acrobat reports damaged file structure",
    },
    "pdf-blank-pages-after-merge": {
        "title": "PDF Blank Pages After Merge — Feeder Dupes &amp; Empty Sources (2026)",
        "tool": "/pdf/rotateorremove",
        "label": "Rotate / Remove Pages",
        "example": "Merged visa pack shows blank pages 4 and 9 from scanner feeder",
    },
    "pdf-file-too-large-to-email": {
        "title": "PDF File Too Large to Email — Compress or Split Under Caps (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "example": "18 MB expense bundle rejected by Gmail 25 MB cap after photos merged",
    },
    "pdf-fonts-missing": {
        "title": "PDF Fonts Missing — Substitution, Embedding &amp; Print Fixes (2026)",
        "tool": "/pdf/doctopdf",
        "label": "Word to PDF",
        "example": "Recipient sees squares instead of company brand font on proposal PDF",
    },
    "pdf-text-not-selectable": {
        "title": "PDF Text Not Selectable — OCR &amp; Scan vs Digital Diagnosis (2026)",
        "tool": "/pdf/ocrpdf",
        "label": "OCR PDF",
        "example": "Cannot copy quote text from vendor PDF — turns out it is phone photo scan",
    },
    "pdf-upload-failed-portal": {
        "title": "PDF Upload Failed on Portal — Size, Format &amp; Validation Fixes (2026)",
        "tool": "/pdf/compress",
        "label": "Compress PDF",
        "example": "Government visa portal rejects PDF with generic 'invalid document' error",
    },
    "pdf-wont-open-password-unknown": {
        "title": "PDF Won't Open — Password Unknown &amp; Unlock Limits (2026)",
        "tool": "/pdf/unlockpdf",
        "label": "Unlock PDF",
        "example": "Inherited archive PDF prompts password — no one remembers owner password",
    },
    "pdf-merge-failed-error": {
        "title": "PDF Merge Failed — Corrupt Source, Password &amp; Size Errors (2026)",
        "tool": "/pdf/merge",
        "label": "Merge PDF",
        "example": "Job pack merge aborts when one resume PDF is encrypted or truncated",
    },
    "pdf-download-incomplete": {
        "title": "PDF Download Incomplete — Truncated Files &amp; Recovery Steps (2026)",
        "tool": "/guides/pdf-tools",
        "label": "PDF tools hub",
        "example": "Browser download stops at 80% — opened file says corrupted or zero pages",
    },
}

W9_DEEP = {
    "pdf-won-t-open": """
            <h2>Symptom checklist</h2>
            <ul>
            <li><strong>Blank viewer</strong> — Chrome/Edge built-in PDF tab empty</li>
            <li><strong>Failed to load PDF</strong> — download truncated or wrong MIME type</li>
            <li><strong>Not a valid PDF</strong> — renamed .docx or HTML saved as .pdf</li>
            <li><strong>Password prompt</strong> — see <a href="/guides/pdf-wont-open-password-unknown">password unknown guide</a></li>
            </ul>
            <h2>Fix order — try in sequence</h2>
            <ol>
            <li>Re-download from source — compare file size to sender's stated KB/MB.</li>
            <li>Open in different viewer — Adobe Reader, Firefox, local app vs browser.</li>
            <li>Check extension — true PDF starts with <code>%PDF-</code> in hex editor or rename mistake.</li>
            <li>Run through <a href="/pdf/compress">Compress PDF</a> — sometimes rewrites broken xref table.</li>
            <li>Ask sender for new export from Word/Excel — not forwarded attachment chain.</li>
            </ol>
            """,
    "pdf-file-corrupted": """
            <h2>How PDFs get corrupted</h2>
            <p>Interrupted download, USB eject mid-copy, email scanner quarantine truncating file, bad merge of encrypted partial, disk full during save.</p>
            <h2>Diagnose severity</h2>
            <p><strong>Opens but missing pages:</strong> partial write — try <a href="/pdf/split">Split PDF</a> on readable ranges. <strong>Won't open at all:</strong> re-obtain source. <strong>One bad file in merge:</strong> isolate — see <a href="/guides/pdf-merge-failed-error">merge failed guide</a>.</p>
            <h2>Recovery ladder</h2>
            <ol>
            <li>Original app re-export</li>
            <li><a href="/pdf/compress">Compress</a> re-save pass</li>
            <li>Extract readable pages via split</li>
            <li>Professional recovery only for legal-critical uniques</li>
            </ol>
            """,
    "repair-pdf-online": """
            <h2>Honest limit — no magic repair button</h2>
            <p>RatPDF does not offer forensic PDF reconstruction. Online "repair" tools often re-wrap readable streams or discard damaged objects. Success depends on whether bytes are truncated vs structurally invalid.</p>
            <h2>What sometimes works in browser</h2>
            <ol>
            <li><a href="/pdf/compress">Compress PDF</a> — Ghostscript rewrite may open file other viewers reject.</li>
            <li><a href="/pdf/split">Split PDF</a> — salvage pages before corruption offset.</li>
            <li><a href="/pdf/merge">Merge PDF</a> — recombine good extracts only.</li>
            <li>Re-download or re-scan — fastest fix when source available.</li>
            </ol>
            <h2>When repair cannot help</h2>
            <p>File is 0 bytes, HTML error page saved as PDF, ransomware encryption — no online repair replaces legitimate source.</p>
            """,
    "pdf-attachment-blocked": """
            <h2>Why email blocks PDF attachments</h2>
            <p>Size over tenant limit (often 20–35 MB), security policy on executable-like MIME, macro-embedded PDF rare block, sender domain reputation, DLP keyword scan delay.</p>
            <h2>Fix path</h2>
            <ol>
            <li><a href="/pdf-size-checker">PDF size checker</a> — compare to <a href="/research/attachment-size-limits">attachment limits research</a>.</li>
            <li><a href="/guides/compress-pdf-guide">Compress guide</a> — Recommended first.</li>
            <li>Still blocked? <a href="/guides/split-pdf-for-email">Split for email</a> or cloud link with auth.</li>
            <li>ZIP rarely helps size — compress PDF itself not archive wrapper.</li>
            </ol>
            """,
    "pdf-printing-blank-pages": """
            <h2>Common causes</h2>
            <ul>
            <li>Annotations or form fields print as invisible until <a href="/pdf/flatten">Flatten PDF</a></li>
            <li>White text on white background in layered PDF</li>
            <li>Printer driver "print as image" off — toggle in advanced dialog</li>
            <li>Corrupt font embedding — see <a href="/guides/pdf-fonts-missing">fonts missing guide</a></li>
            </ul>
            <h2>Print test sequence</h2>
            <ol>
            <li>Print page 1 only from Adobe/Edge</li>
            <li>Enable "Print as image" in driver advanced</li>
            <li>Flatten then print</li>
            <li>Export new PDF via <a href="/pdf/compress">Compress</a> Less profile</li>
            </ol>
            """,
    "print-pdf-without-margins": """
            <h2>Margin sources</h2>
            <p>Printer hardware non-printable area, PDF media box smaller than paper, "Fit" scaling leaving letterbox, Word export default margins baked in.</p>
            <h2>Workarounds</h2>
            <ol>
            <li>Printer dialog: borderless if hardware supports (photo printers)</li>
            <li>Scale 110% custom — watch crop on opposite edge</li>
            <li>Re-export from source with bleed if professional print</li>
            <li>Browser PDF editors cannot change true print bleed — return to InDesign/Word for plate-ready</li>
            </ol>
            """,
    "pdf-colors-wrong-when-printing": """
            <h2>RGB vs CMYK mismatch</h2>
            <p>Screen RGB vivid — office laser approximates — commercial print needs CMYK separations from design source.</p>
            <h2>Fix attempts</h2>
            <ul>
            <li>Print from Adobe with color management on</li>
            <li>Disable "Economode" toner save on HP devices</li>
            <li>Request CMYK PDF from designer — not filtered through three email forwards</li>
            <li>Brand colors: verify Pantone in source — PDF is delivery not color authority</li>
            </ul>
            """,
    "pdf-troubleshooting": """
            <h2>Troubleshooting decision tree</h2>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>Symptom</th><th>First guide</th><th>Tool</th></tr></thead>
            <tbody>
            <tr><td>Won't open</td><td><a href="/guides/pdf-won-t-open">Won't open</a></td><td>Re-download / compress</td></tr>
            <tr><td>Corrupted</td><td><a href="/guides/pdf-file-corrupted">Corrupted</a></td><td><a href="/pdf/compress">Compress</a></td></tr>
            <tr><td>Password unknown</td><td><a href="/guides/pdf-wont-open-password-unknown">Password</a></td><td><a href="/pdf/unlockpdf">Unlock</a></td></tr>
            <tr><td>Too large email</td><td><a href="/guides/pdf-file-too-large-to-email">Too large</a></td><td><a href="/pdf/compress">Compress</a></td></tr>
            <tr><td>Portal upload fail</td><td><a href="/guides/pdf-upload-failed-portal">Upload failed</a></td><td>Compress / split</td></tr>
            <tr><td>Blank print</td><td><a href="/guides/pdf-printing-blank-pages">Blank print</a></td><td><a href="/pdf/flatten">Flatten</a></td></tr>
            <tr><td>No selectable text</td><td><a href="/guides/pdf-text-not-selectable">Not selectable</a></td><td><a href="/pdf/ocrpdf">OCR</a></td></tr>
            <tr><td>Merge failed</td><td><a href="/guides/pdf-merge-failed-error">Merge failed</a></td><td><a href="/pdf/merge">Merge</a></td></tr>
            </tbody>
            </table></div>
            """,
    "corrupted-pdf-repair": """
            <h2>Compress as lightweight repair pass</h2>
            <p>Ghostscript rebuilds PDF structure on output — not guaranteed but worth one attempt before abandoning file. Use <strong>Less</strong> profile to minimize recompression artifacts on scans.</p>
            <h2>Split salvage</h2>
            <p>If pages 1–20 open but 21+ crash viewer — split 1-20 — use partial production while requesting re-send.</p>
            """,
    "pdf-blank-pages-after-merge": """
            <h2>Root causes after merge</h2>
            <ul>
            <li>Empty PDF in merge queue</li>
            <li>Scanner feeder blank dupes</li>
            <li>Word exported trailing blank page per part</li>
            </ul>
            <h2>Fix</h2>
            <p><a href="/pdf/rotateorremove">Rotate / Remove</a> — delete blank indices — <a href="/guides/remove-blank-pages-pdf">remove blank pages guide</a>. Prevent: thumbnail review before merge submit.</p>
            """,
    "pdf-file-too-large-to-email": """
            <h2>Size caps reference</h2>
            <p>Gmail ~25 MB message, Outlook tenants 20–35 MB, mobile carriers choke earlier — see <a href="/research/attachment-size-limits">attachment limits</a>.</p>
            <h2>Compress then split</h2>
            <ol>
            <li><a href="/guides/compress-pdf-guide">Compress guide</a> Recommended</li>
            <li>Still over? <a href="/guides/split-pdf-for-email">Split for email</a></li>
            <li>Label parts Part 1 of 3 in subject line</li>
            </ol>
            """,
    "pdf-fonts-missing": """
            <h2>Missing font symptoms</h2>
            <p>Tofu squares, wrong weight, line breaks shift, print differs from screen.</p>
            <h2>Fix path</h2>
            <ol>
            <li>Obtain PDF with embedded fonts from sender</li>
            <li>Re-export from Word with embed fonts on — <a href="/pdf/doctopdf">Word to PDF</a></li>
            <li>Substitute font in Word then re-export — proof on recipient PC</li>
            </ol>
            """,
    "pdf-text-not-selectable": """
            <h2>Scan vs digital test</h2>
            <p>Ctrl+F in viewer — no hits on known word → image-only page → <a href="/pdf/ocrpdf">OCR PDF</a> required.</p>
            <h2>After OCR</h2>
            <p>Proofread numbers — extract via <a href="/guides/pdf-txt-guide">PDF to Text</a> — heavy edit via <a href="/guides/pdf-to-word">PDF to Word</a>.</p>
            """,
    "pdf-upload-failed-portal": """
            <h2>Portal rejection reasons</h2>
            <ul>
            <li>File size over slot MB cap</li>
            <li>PDF version too new or too old</li>
            <li>Encrypted or password protected</li>
            <li>Required PDF/A not met</li>
            <li>JavaScript or embedded files blocked</li>
            </ul>
            <h2>Fix loop</h2>
            <ol>
            <li>Size checker → compress → retry</li>
            <li><a href="/guides/unlock-pdf">Unlock</a> if encrypted</li>
            <li>Flatten annotations — <a href="/pdf/flatten">Flatten PDF</a></li>
            <li>Re-export from source without portfolio embeds</li>
            </ol>
            """,
    "pdf-wont-open-password-unknown": """
            <h2>Owner vs user password</h2>
            <p>User password blocks open — owner restricts print/copy. Without password recovery is not feasible for strong encryption.</p>
            <h2>Legitimate paths</h2>
            <ol>
            <li>Contact document author for unlocked copy</li>
            <li>Check password manager / shared vault for client portal creds</li>
            <li>If you know password: <a href="/pdf/unlockpdf">Unlock PDF</a> — RatPDF cannot crack unknown passwords</li>
            </ol>
            <h2>Compliance note</h2>
            <p>Do not use crack tools on third-party confidential PDFs — legal and policy risk.</p>
            """,
    "pdf-merge-failed-error": """
            <h2>Merge failure causes</h2>
            <ul>
            <li>One corrupt PDF in batch</li>
            <li>Password on any input</li>
            <li>Upload timeout on cellular</li>
            <li>Unsupported portfolio PDF</li>
            </ul>
            <h2>Isolate bad file</h2>
            <ol>
            <li>Merge pairs — binary search which file fails</li>
            <li>Unlock or re-download failing file</li>
            <li>Compress individual large scan then merge</li>
            </ol>
            """,
    "pdf-download-incomplete": """
            <h2>Incomplete download signs</h2>
            <p>File size smaller than expected, viewer immediate error, progress bar stopped before 100%, ZIP conflation with PDF name.</p>
            <h2>Recovery</h2>
            <ol>
            <li>Hard refresh — re-download on stable Wi-Fi</li>
            <li>Do not open partial — delete truncated file first</li>
            <li>Compare checksum if sender provided SHA256</li>
            <li>Cloud drive "available offline" sync incomplete — wait for green check</li>
            </ol>
            """,
}

W9_SLUG_EXTRA = {
    "pdf-won-t-open": """
            <h2>Real example: forwarded contract</h2>
            <p>Third-forward Outlook MSG saved wrong — recipient gets 12 KB HTML not PDF — re-request direct PDF attachment from counsel.</p>
            <h2>Real example: mobile download</h2>
            <p>iPhone Safari tab closed early — 2 MB of 9 MB — re-download on Wi-Fi — opens clean.</p>
            """,
    "pdf-file-corrupted": """
            <h2>Real example: merge abort</h2>
            <p>Five PDFs merge — job fails — file 3 corrupt USB copy — re-copy from NAS — merge succeeds.</p>
            """,
    "repair-pdf-online": """
            <h2>Manage expectations</h2>
            <p>Marketing "100% repair" claims oversell — document recovery rate honest in IT tickets — re-source beats repair when possible.</p>
            """,
    "pdf-attachment-blocked": """
            <h2>Real example: hospital DLP</h2>
            <p>Clinical admin PDF blocked by keyword scanner — compress and rename per IT ticket — or secure portal upload.</p>
            """,
    "pdf-printing-blank-pages": """
            <h2>Real example: form fields</h2>
            <p>Filled government PDF prints blank — flatten — reprint — fields visible on paper.</p>
            """,
    "print-pdf-without-margins": """
            <h2>Real example: poster print</h2>
            <p>Student wants A4 edge-to-edge — home inkjet borderless mode — office laser cannot — shop print for true bleed.</p>
            """,
    "pdf-colors-wrong-when-printing": """
            <h2>Real example: brand deck</h2>
            <p>Agency RGB PDF — client office print dull — supply CMYK export from InDesign for print run.</p>
            """,
    "pdf-troubleshooting": """
            <h2>Helpdesk macro replies</h2>
            <p>Link won't open → pdf-won-t-open. Too big → file-too-large-to-email. Portal → upload-failed. Blank print → printing-blank-pages. Standardize tier-1 responses.</p>
            """,
    "corrupted-pdf-repair": """
            <h2>Compress Less success story</h2>
            <p>xref warning in log — Less compress — opens in Chrome — business continues while awaiting re-send from vendor.</p>
            """,
    "pdf-blank-pages-after-merge": """
            <h2>Visa bundle</h2>
            <p>Blank page 6 after merge — officer confusion — remove page 6 — re-upload before appointment.</p>
            """,
    "pdf-file-too-large-to-email": """
            <h2>Job application</h2>
            <p>Portfolio 28 MB — compress to 8 MB — Indeed upload succeeds — master uncompressed archived locally.</p>
            """,
    "pdf-fonts-missing": """
            <h2>Proposal embarrassment</h2>
            <p>Custom display font not embedded — client sees Arial fallback breaking layout — re-export embed all fonts.</p>
            """,
    "pdf-text-not-selectable": """
            <h2>AP automation blocked</h2>
            <p>Invoice scan not selectable — OCR — AP script reads totals — manual spot-check first month.</p>
            """,
    "pdf-upload-failed-portal": """
            <h2>Visa portal</h2>
            <p>4.9 MB over 4 MB cap — compress Recommended — 3.2 MB — upload green check.</p>
            """,
    "pdf-wont-open-password-unknown": """
            <h2>Estate archive</h2>
            <p>Old tax PDF password unknown — contact preparer firm — no legitimate crack — obtain copy from IRS transcript process.</p>
            """,
    "pdf-merge-failed-error": """
            <h2>Board pack</h2>
            <p>Q3 report PDF encrypted — unlock — merge 12 parts — compress — email to directors.</p>
            """,
    "pdf-download-incomplete": """
            <h2>Cloud sync</h2>
            <p>OneDrive placeholder not hydrated — open shows corrupt — right-click always keep on device — retry.</p>
            """,
}

W9_MEGA = """
            <h2>PDF failure modes — systems view</h2>
            <p>Most "broken PDF" tickets are transfer problems (truncated download), permission problems (password), or expectation problems (scan treated as editable text). Tool problems (merge one bad file) rank fourth. Train users to check file size and re-download before escalating to repair mythology.</p>
            <h2>RatPDF tools in recovery chain</h2>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>Goal</th><th>Tool</th></tr></thead>
            <tbody>
            <tr><td>Rewrite structure</td><td><a href="/pdf/compress">Compress PDF</a></td></tr>
            <tr><td>Salvage pages</td><td><a href="/pdf/split">Split PDF</a></td></tr>
            <tr><td>Remove bad pages</td><td><a href="/pdf/rotateorremove">Rotate / Remove</a></td></tr>
            <tr><td>Combine good parts</td><td><a href="/pdf/merge">Merge PDF</a></td></tr>
            <tr><td>Add text layer to scan</td><td><a href="/pdf/ocrpdf">OCR PDF</a></td></tr>
            <tr><td>Remove encryption</td><td><a href="/pdf/unlockpdf">Unlock PDF</a> (password required)</td></tr>
            <tr><td>Flatten for print</td><td><a href="/pdf/flatten">Flatten PDF</a></td></tr>
            </tbody>
            </table></div>
            <h2>When to stop troubleshooting online</h2>
            <p>Legal evidence chain, classified data, prepress color contract, or courtroom exhibit — involve specialist and preserve original bytes with hash log.</p>
            """

W9_CLUSTER = """
            <h2>Troubleshooting guides</h2>
            <ul>
            <li><a href="/guides/pdf-won-t-open">PDF won't open</a> · <a href="/guides/pdf-file-corrupted">File corrupted</a></li>
            <li><a href="/guides/repair-pdf-online">Repair PDF online</a> · <a href="/guides/corrupted-pdf-repair">Corrupted repair</a></li>
            <li><a href="/guides/pdf-attachment-blocked">Attachment blocked</a> · <a href="/guides/pdf-file-too-large-to-email">Too large for email</a></li>
            <li><a href="/guides/pdf-upload-failed-portal">Upload failed portal</a> · <a href="/guides/pdf-download-incomplete">Download incomplete</a></li>
            <li><a href="/guides/pdf-printing-blank-pages">Printing blank</a> · <a href="/guides/print-pdf-without-margins">Print without margins</a></li>
            <li><a href="/guides/pdf-colors-wrong-when-printing">Colors wrong printing</a></li>
            <li><a href="/guides/pdf-fonts-missing">Fonts missing</a> · <a href="/guides/pdf-text-not-selectable">Text not selectable</a></li>
            <li><a href="/guides/pdf-blank-pages-after-merge">Blank after merge</a> · <a href="/guides/pdf-merge-failed-error">Merge failed</a></li>
            <li><a href="/guides/pdf-wont-open-password-unknown">Password unknown</a></li>
            </ul>
            <p>Hub: <a href="/guides/pdf-troubleshooting">PDF troubleshooting guide</a> · <a href="/guides/pdf-tools">PDF tools</a> · <a href="/guides/compress-pdf-guide">Compress guide</a>.</p>
            """

W9_1500_TOPUP = """
            <h2>Tier-1 support script</h2>
            <ol>
            <li>Confirm file size matches sender claim</li>
            <li>Re-download on Wi-Fi</li>
            <li>Try second viewer</li>
            <li>Compress Less pass if won't open</li>
            <li>Check password / unlock if prompted</li>
            <li>Compress or split if size or portal error</li>
            <li>OCR if text not selectable</li>
            <li>Flatten if print blank</li>
            <li>Escalate with hash + sample page screenshot</li>
            </ol>
            <h2>Document incident template</h2>
            <p>Filename, size bytes, error exact text, tool tried, outcome, source re-requested Y/N — quarterly pattern review reduces repeat tickets.</p>
            <h2>Related problem guides (prior waves)</h2>
            <p><a href="/guides/compress-pdf-made-it-larger">Compress made larger</a> · <a href="/guides/ocr-pdf-poor-quality">OCR poor quality</a> · <a href="/guides/pdf-to-word-garbled-text">Garbled Word export</a> · <a href="/guides/remove-blank-pages-pdf">Remove blank pages</a>.</p>
            """

W9_CLOSING = """
            <h2>Related guides</h2>
            <p>Troubleshooting guides cover files that won't open, corruption, repair limits, email and portal blocks, print failures, and merge/download errors — with links to RatPDF tools where a workaround exists.</p>
            <p>More conversion guides (PDF to JPG, Excel, HTML) — bookmark the <a href="/guides/pdf-troubleshooting">PDF troubleshooting guide</a> for your helpdesk.</p>
            """
