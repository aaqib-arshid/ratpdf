namespace ratpdf.Content
{
    /// <summary>Wave 8 — Edit-gap cluster (crop, delete, annotate, device, pillar upgrades).</summary>
    internal static class GuideBodiesWave8
    {
        public static string? Get(string slug) => slug switch
        {
            "crop-pdf-online" => CropPdfOnline,
            "crop-pdf-without-adobe" => CropPdfWithoutAdobe,
            "delete-pages-from-pdf" => DeletePagesFromPdf,
            "annotate-pdf-online" => AnnotatePdfOnline,
            "annotate-pdf-free" => AnnotatePdfFree,
            "highlight-pdf-online" => HighlightPdfOnline,
            "rearrange-pdf-pages" => RearrangePdfPages,
            "edit-pdf-text-online" => EditPdfTextOnline,
            "add-text-to-pdf" => AddTextToPdf,
            "fill-pdf-form-online" => FillPdfFormOnline,
            "edit-pdf-on-mac" => EditPdfOnMac,
            "edit-pdf-on-windows" => EditPdfOnWindows,
            "edit-pdf-on-iphone" => EditPdfOnIphone,
            "remove-blank-pages-pdf" => RemoveBlankPagesPdf,
            "edit-pdf" => EditPdf,
            "rotate-pdf" => RotatePdf,
            "edit-pdf-without-acrobat" => EditPdfWithoutAcrobat,
            _ => null
        };

        private const string CropPdfOnline = """
            <h2>Crop PDF online — trim margins &amp; white borders in browser</h2>
            <p>RatPDF <a href="/pdf/editpdf">Edit PDF</a> — Trim excess white border on a scanned lease before portal upload.</p>
            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> Crop PDF online — trim margins &amp; white borders in browser</figcaption></figure>
            
            <h2>What “crop PDF” usually means</h2>
            <p>Users want to remove white margins, fax headers, or scanner bed borders. True vector crop boxes (like Acrobat’s Crop tool) change the media box. Browser editors often achieve the <em>visual</em> goal by re-exporting trimmed content or overlaying on a tighter canvas.</p>
            <h2>RatPDF workflow when no dedicated crop tool</h2>
            <ol>
            <li>Open source in image editor — crop JPG/PNG scan before <a href="/guides/images-to-pdf">Images to PDF</a> if origin is photos.</li>
            <li>Digital PDF with huge margins — try <a href="/guides/pdf-to-word">PDF to Word</a> for layout edit, then <a href="/pdf/doctopdf">Word to PDF</a>.</li>
            <li>Minor border — <a href="/pdf/editpdf">Edit PDF</a> white box overlay on margins (visual trim for screen review).</li>
            <li>Print-bound crop — return to source app (Word, InDesign) when bleed matters.</li>
            </ol>
            <h2>Scanned document crop</h2>
            <p>Re-scan with smaller scan area beats cropping blurry fax edges. 300 DPI grayscale — straight on glass — crop in Preview or Photos before PDF bundle.</p>
            
            
            <h2>Real example: lease scan margins</h2>
            <p>Property manager scans 30-page lease — 2 cm bed border — crop in Photos — re-bundle Images to PDF — compress — portal upload under 5 MB.</p>
            <h2>Marketing PDF bleed</h2>
            <p>Brochure needs professional crop — return to InDesign — browser path for internal draft trim only.</p>
            
            <div class="rp-mid-cta alert alert-primary my-4"><strong>Start now</strong> <a href="/pdf/editpdf" class="alert-link fw-semibold">Edit PDF →</a></div>
            
            <h2>Edit vs convert vs OCR decision tree</h2>
            <p><strong>Digital PDF minor fix:</strong> Edit PDF text overlay. <strong>Heavy rewrite:</strong> PDF to Word. <strong>Scan:</strong> OCR first. <strong>Wrong page order:</strong> Organize via merge queue. <strong>One page pull:</strong> Split PDF.</p>
            <h2>Form filling landscape</h2>
            <p>Government PDFs mix fillable AcroForm fields and flat scans. Fillable fields preserve tab order — flat forms need positioned text boxes — print-test alignment before official submit.</p>
            <h2>Scanned document edit chain</h2>
            <ol>
            <li>Scan 300 DPI grayscale upright</li>
            <li><a href="/pdf/ocrpdf">OCR PDF</a> — verify Ctrl+F finds key term</li>
            <li><a href="/pdf/editpdf">Edit PDF</a> — add date, signature image, stamp</li>
            <li>Optional <a href="/guides/compress-pdf-for-email">compress</a> before portal upload</li>
            </ol>
            <h2>Organize without desktop Acrobat</h2>
            <p>Reorder pages in merge tool — drag queue — single merge output — same engine as <a href="/guides/merge-pdf-custom-order">custom order merge</a>. Delete pages by omitting from queue not destructive edit on source.</p>
            <h2>Image overlay best practices</h2>
            <p>Logo PNG with transparency — place top-right — do not cover existing signature block. DPI 150 sufficient for screen PDF — 300 for print-bound proposals.</p>
            <h2>Security and audit</h2>
            <p>Edited PDF is new derivative — keep unedited master for legal hold — filename suffix <code>-edited-2026-04-02</code>. Flatten annotations before court filing if local rules require.</p>
            
            
            <h2>Browser edit limitations</h2>
            <p>RatPDF edit covers common SMB needs — text add, image stamp, form fill — not InDesign prepress — not Photoshop pixel surgery. For marketing brochure pixel edits return to design source.</p>
            <h2>Mobile edit caution</h2>
            <p>Fine form alignment on phone is painful — desktop for government forms — mobile OK for initial and date on consent PDF.</p>
            <h2>Password-protected PDFs</h2>
            <p>Unlock first: <a href="/guides/unlock-pdf">unlock PDF</a> — edit fails on encrypted open.</p>
            <h2>Compare vendors</h2>
            <p><a href="/compare/adobe-alternative">Adobe</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/smallpdf-alternative">Smallpdf</a> — evaluate form-fill on your hardest government PDF sample.</p>
            <h2>Split and extract coordination</h2>
            <p>Extract signature page before sending for countersign — <a href="/guides/extract-single-page-pdf">extract single page</a> — merge back after scan with <a href="/pdf/merge">Merge PDF</a>.</p>
            <h2>QA print test</h2>
            <p>Government forms reject misaligned fields — print one copy — hold to light against blank form — adjust coordinates before batch.</p>
            
            
            <h2>Edit cluster authority map</h2>
            <p>Editing guides cover crop, delete, annotate, highlight, rearrange pages, and device workflows — plus in-depth help for <a href="/guides/edit-pdf">edit PDF</a> and <a href="/guides/rotate-pdf">rotate PDF</a>. See also merge, split, and OCR guides.</p>
            <h2>Security and compliance</h2>
            <p>Edited derivatives are new files — keep immutable master — log who edited — confidential docs cleared from Downloads on shared PCs same day. HIPAA and legal hold: counsel approves browser edit on PHI or privilege docs.</p>
            <h2>Failure triage</h2>
            <p><strong>Cannot select text:</strong> OCR first. <strong>Wrong page count after delete:</strong> off-by-one viewer index — recount. <strong>Portal rejects filled form:</strong> print-test alignment — font mismatch — try flatten. <strong>Upload timeout:</strong> Wi-Fi — compress — split.</p>
            <h2>Research links</h2>
            <p><a href="/research/attachment-size-limits">Email attachment limits</a> · <a href="/research/pdf-tool-market-comparison">PDF tool market comparison</a> · <a href="/compare">Compare hub</a>.</p>
            
            
            <h2>Workflow deep dive — Crop PDF online — trim margins &amp; white borders in browser</h2>
            <p>Browser workflow — no install — upload → process → download → verify in viewer before external send.</p>
            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> Crop PDF online — trim margins &amp; white borders in browser</figcaption></figure>
            <h2>Mobile</h2>
            <p>Safari/Chrome on phone works — Wi-Fi for files over 15 MB — save to Files before portal upload.</p>
            <h2>Failures</h2>
            <p>Timeout: retry Wi-Fi · corrupt PDF: re-export source · password: <a href="/guides/unlock-pdf">unlock</a>.</p>
            <h2>Free tier</h2>
            <p>Three uses/day — <a href="/Subscription/Plans">plans</a> for volume.</p>
            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Open tool</strong> <a href="/pdf/editpdf" class="alert-link fw-semibold">Go →</a></div>
            
            
            <h2>Real example: HR onboarding packet</h2>
            <p>Flat I-9 scan — OCR — add start date field — employee initials — merge with handbook acknowledgment — compress — upload to HRIS.</p>
            <h2>Second example: property manager lease initialed</h2>
            <p>Scan signed lease pages — add initialed watermark on page 4 rider — re-compress for email to tenant.</p>
            <h2>Third example: proposal logo</h2>
            <p>Sales exports proposal PDF from CRM — add partner logo top-left — send to client — no return to InDesign.</p>
            <h2>Discovery page pull</h2>
            <p>Counsel needs only exhibit G from 200-page production — split page range 142-148 — email to expert witness — index in cover note.</p>
            <h2>Medical admin form</h2>
            <p>Clinic scan intake form — OCR — nurse adds checkbox marks — print for patient sign — scan again for chart.</p>
            <h2>Upgrade path</h2>
            <p>High-volume form shop — <a href="/Subscription/Plans">plans</a> — see the <a href="/guides/edit-pdf">edit PDF hub</a>.</p>
            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Edit your PDF</strong> <a href="/pdf/editpdf" class="alert-link fw-semibold">Edit PDF →</a></div>
            
            
            
            <h2>Browser vs desktop</h2>
            <p>RatPDF needs no install — IT-friendly — confidential docs review privacy policy retention window.</p>
            <h2>Chain tools</h2>
            <p>Convert → edit → compress → merge — pick order by deliverable — see the <a href="/guides/pdf-tools">PDF tools hub</a>.</p>
            <h2>Upgrade</h2>
            <p><a href="/Subscription/Plans">subscription plans</a> for daily caps on agency volume.</p>
            
            
            <h2>Cross-wave tool chain</h2>
            <p>Pick tool order by what you need to deliver. Example: photos → images PDF → OCR → edit date → compress → portal upload.</p>
            <h2>Free tier and upgrade</h2>
            <p>Three uses per day per tool on free tier — agency month-end exceeds cap — <a href="/Subscription/Plans">subscription plans</a> — predictable vs per-file credit packs.</p>
            <h2>Internal link discipline</h2>
            <p>Each guide links to related tools and comparisons so your team picks the right workflow.</p>
            <h2>Support triage</h2>
            <p>Wrong tool order causes bad output — OCR before edit on scans — compress after merge not before each file — train your team using the main tool guides.</p>
            
            
            <h2>QA before send</h2>
            <ol><li>Page count correct</li><li>Text selects if required</li><li>Images sharp at 150% zoom</li><li>File opens in Chrome PDF viewer</li><li>Size under email/portal cap</li></ol>
            <h2>Compare vendors</h2>
            <p><a href="/compare/smallpdf-alternative">Smallpdf</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/adobe-alternative">Adobe</a>.</p>
            
            
            <h2>Device matrix</h2>
            <p>Windows Edge, Mac Safari, iPhone Safari, Android Chrome — same account — no sync required — download to device storage before portal upload.</p>
            <h2>Retention hygiene</h2>
            <p>Clear Downloads on shared PC — contracts and medical admin PDFs are confidential — delete derivatives when task completes.</p>
            <h2>Filename and version control</h2>
            <p><code>Client-Doc-v2-edited.pdf</code> — never overwrite sent attachment — email thread references version.</p>
            <h2>Portal rejection loop</h2>
            <p>Reject → check size with <a href="/pdf-size-checker">size checker</a> → compress Less → split if still over → re-upload before session timeout.</p>
            <h2>Research links</h2>
            <p><a href="/research/attachment-size-limits">Attachment size limits</a> · <a href="/research/pdf-compression-benchmark">Compression benchmark</a> · <a href="/research/freelancer-invoicing-statistics">Invoicing statistics</a>.</p>
            <h2>Pillar bookmark set</h2>
            <p><a href="/guides/pdf-tools">PDF tools hub</a> · <a href="/guides/images-to-pdf">Images to PDF</a> · <a href="/guides/pdf-to-word">PDF to Word</a> · <a href="/guides/split-pdf">Split PDF</a> · <a href="/compare">Compare hub</a>.</p>
            
            
            <h2>Edit audit log</h2>
            <p>Log who edited which PDF derivative — timestamp — reason — matter number — supports litigation hold and SOX-style controls.</p>
            <h2>Flatten before external send</h2>
            <p>Some recipients see floating annotations differently — flatten or re-export PDF so logo and text boxes appear identical on all viewers.</p>
            <h2>Redaction before edit</h2>
            <p>Remove SSN and account numbers with <a href="/guides/pdf-redaction-permanent">permanent redaction</a> before adding new text — edit tool does not replace redaction workflow.</p>
            <h2>Training slide for staff</h2>
            <p>Three rules poster: OCR scans first — organize before merge — compress after combine — pin in Slack onboarding channel.</p>
            <h2>Department-specific examples</h2>
            <p><strong>HR:</strong> I-9 and handbook ack merge. <strong>Sales:</strong> logo on proposal. <strong>Legal:</strong> exhibit extract. <strong>Finance:</strong> initialed tax form. <strong>Ops:</strong> delivery note stamp.</p>
            <h2>Version rollback</h2>
            <p>Keep pre-edit master immutable — if client rejects edit — resend from master not undo in editor — filename version increments.</p>
            <h2>Collaboration handoff</h2>
            <p>Paralegal extracts page — attorney reviews in isolation — merge signed scan back — document handoff in matter management ticket.</p>
            <h2>Accessibility after edit</h2>
            <p>Added text may not be tagged — government accessibility filing may need tagged PDF specialist — SMB email deliverable usually exempt.</p>
            <h2>Pillar cross-links</h2>
            <p><a href="/guides/merge-pdf-online">merge PDF</a> · <a href="/guides/ocr-pdf">OCR PDF</a> · <a href="/guides/split-pdf">split hub</a> · <a href="/guides/pdf-tools">PDF tools hub</a>.</p>
            
            
            <h2>QA checklist — edit outputs</h2>
            <ol>
            <li>Page count matches intent after delete or rearrange</li>
            <li>Orientation correct on every page at thumbnail view</li>
            <li>Added text readable at 150% zoom and in print preview</li>
            <li>Annotations visible in Chrome PDF viewer and recipient test</li>
            <li>File size under email or portal cap — compress if needed</li>
            <li>Master archived before destructive delete</li>
            </ol>
            <h2>Department playbooks</h2>
            <p><strong>Legal:</strong> annotate review copy — master untouched. <strong>Finance:</strong> fill tax PDF — print-test. <strong>HR:</strong> OCR onboarding — merge ack. <strong>Sales:</strong> logo + date on proposal. <strong>Ops:</strong> delete blank feeder pages from scan batch.</p>
            <h2>Monthly volume</h2>
            <p>Track edit/remove jobs — exceed free tier twice in one week — finance approves <a href="/Subscription/Plans">subscription</a>.</p>
            <h2>Compare alternatives</h2>
            <p><a href="/compare/adobe-acrobat-alternative">Adobe Acrobat alternative</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/smallpdf-alternative">Smallpdf</a>.</p>
            
            
            <h2>Team rollout notes</h2>
            <p>Pin the main tool guides in your shared wiki — compress before portal, OCR before edit on scans, Word path only when ERP cannot reissue. New hires complete one sample file in first week using browser tools only — no desktop install ticket.</p>
            <h2>Support escalation path</h2>
            <p>Step 1: re-download output and open in Chrome viewer. Step 2: retry on Wi-Fi with smaller batch. Step 3: check <a href="/pdf-size-checker">size checker</a> preset. Step 4: compare tool choice on <a href="/compare">compare tools</a> if output quality insufficient.</p>
            <h2>Record retention</h2>
            <p>Keep source PDF until recipient confirms receipt — derivatives disposable after successful upload — confidential docs deleted from Downloads on shared machines same day.</p>
            <h2>Monthly volume planning</h2>
            <p>Track daily tool usage in spreadsheet — forecast upgrade need before month-end crunch — finance approves <a href="/Subscription/Plans">subscription</a> when free tier blocks twice in one week.</p>
            <h2>Incident log template</h2>
            <p>Date, source filename, tool used, error message, resolution — patterns reveal training gaps — share quarterly with ops lead.</p>
            
            
            <h2>Quick reference card</h2>
            <p>Scan → OCR → Edit. Digital → Edit direct. Reorder → Merge queue. One page → Split. Logo → Add image. Forms → Fill then print-test. Archive master before any derivative edit.</p>
            <p>Bookmark <a href="/guides/edit-pdf">edit PDF guide</a> for team onboarding — reduces wrong-tool support tickets.</p>
            <p>Wrong page order voids visa bundles — verify thumbnail strip before merge submit.</p>
            
            
            <h2>Related edit &amp; organize guides</h2>
            <ul>
            <li><a href="/guides/edit-scanned-pdf">Edit scanned PDF</a></li>
            <li><a href="/guides/organize-pdf-pages">Organize PDF pages</a></li>
            <li><a href="/guides/split-pdf-page-range">Split by page range</a></li>
            <li><a href="/guides/add-image-to-pdf">Add image to PDF</a></li>
            </ul>
            
            
            <h2>Edit-gap guides</h2>
            <ul>
            <li><a href="/guides/crop-pdf-online">Crop PDF online</a> · <a href="/guides/crop-pdf-without-adobe">Crop without Adobe</a></li>
            <li><a href="/guides/delete-pages-from-pdf">Delete pages</a> · <a href="/guides/remove-blank-pages-pdf">Remove blank pages</a></li>
            <li><a href="/guides/annotate-pdf-online">Annotate online</a> · <a href="/guides/annotate-pdf-free">Annotate free</a></li>
            <li><a href="/guides/highlight-pdf-online">Highlight PDF</a> · <a href="/guides/edit-pdf-text-online">Edit text</a></li>
            <li><a href="/guides/add-text-to-pdf">Add text</a> · <a href="/guides/fill-pdf-form-online">Fill form</a></li>
            <li><a href="/guides/rearrange-pdf-pages">Rearrange pages</a> · <a href="/guides/edit-pdf-without-acrobat">Without Acrobat</a></li>
            <li><a href="/guides/edit-pdf-on-mac">Edit on Mac</a> · <a href="/guides/edit-pdf-on-windows">Windows</a> · <a href="/guides/edit-pdf-on-iphone">iPhone</a></li>
            </ul>
            <h2>Pillar and organize links</h2>
            <p><a href="/guides/edit-pdf">Edit PDF guide</a> · <a href="/guides/rotate-pdf">Rotate PDF</a> · <a href="/guides/organize-pdf-pages">Organize pages</a> · <a href="/guides/merge-pdf">Merge guide</a> · <a href="/guides/split-pdf">Split guide</a> · <a href="/guides/ocr-pdf">OCR guide</a>.</p>
            
            
            <h2>Enterprise document workflows</h2>
            <p>Legal ops teams convert legacy contract PDFs during CLM migration — batch convert critical folders, prioritise active vendor agreements first. IT should approve browser upload policy for confidential docs.</p>

            <h2>Education sector</h2>
            <p>Faculty edit syllabus PDFs each semester — digital university PDFs convert cleanly; scanned course packs need OCR. Check campus IT data handling before upload.</p>

            <h2>Real estate</h2>
            <p>Lease amendments stored as PDF — convert to Word for redline, re-PDF for signature. Keep executed scan archived separately from working DOCX.</p>

            <h2>HR and offer letters</h2>
            <p>Template offer PDFs with merge fields sometimes break on convert — edit boilerplate in Word template instead of converting each hire if HRIS exports PDF.</p>

            <h2>Government RFP responses</h2>
            <p>Final submissions often must be PDF — use Word only for draft edits, export via <a href="/pdf/doctopdf">Word to PDF</a> for portal upload. Check RFP forbids track changes in submission.</p>

            <h2>Quality gates before client delivery</h2>
            <ol>
            <li>Spell-check in Word</li>
            <li>Compare page count vs source PDF</li>
            <li>Verify critical numbers (dates, amounts) unchanged</li>
            <li>Remove comments and track changes</li>
            <li>Export final PDF if deliverable format is PDF</li>
            </ol>

            <p>Pillar: <a href="/guides/pdf-to-word">PDF to Word guide</a> · Compare: <a href="/compare/smallpdf-alternative">Smallpdf alternative</a></p>
            
            
            <h2>Batch conversion hygiene</h2>
            <p>Converting 20 contracts? Use consistent naming <code>ClientName-contract-v1.docx</code>. Log source PDF hash if legal audit trail required.</p>

            <h2>Mobile upload caveats</h2>
            <p>Phone browsers work but large PDFs may timeout on cellular — use Wi-Fi or desktop for 50+ MB files.</p>

            <h2>Antivirus false positives</h2>
            <p>Some corporate proxies scan uploads — if blocked, try guest network or contact IT to allowlist ratpdf.com tool path.</p>

            <h2>Long-term archival</h2>
            <p>Store both source PDF and final DOCX/PDF pair — migrations sometimes need to re-edit decade-old contracts.</p>

            <h2>Regulatory and compliance edits</h2>
            <p>Privacy policies, SOC2 reports, and vendor security questionnaires arrive as PDF — convert to Word for comment, return PDF via <a href="/pdf/doctopdf">Word to PDF</a>. Legal should review material compliance wording changes.</p>

            <h2>Performance expectations</h2>
            <p>10-page digital PDF typically converts under two minutes; 200-page annual report may take longer — do not close tab during processing. Refresh only after timeout message.</p>
            
            
            <h2>Document type quick reference</h2>
            <p><strong>Contracts:</strong> digital PDF, track changes in Word. <strong>Invoices:</strong> table-heavy — check sums. <strong>Scanned forms:</strong> OCR first. <strong>Marketing PDFs:</strong> expect image blocks. <strong>Manuals:</strong> headings usually survive — update TOC in Word after edits.</p>
            <p>Upgrade for volume: <a href="/Subscription/Plans">subscription plans</a>. Pillar: <a href="/guides/pdf-to-word">PDF to Word</a>.</p>

            <h2>Stakeholder sign-off matrix</h2>
            <p>Legal reviews converted contracts; finance reviews invoice PDFs edited in Word; HR reviews offer letters. Route DOCX to the right reviewer before re-PDF. Version suffix in filename (<code>-legal-reviewed</code>) prevents accidental send of draft.</p>
            <p>After major edits, compress before email if DOCX re-export exceeds mailbox limits — see <a href="/research/pdf-compression-benchmark">PDF compression benchmark</a> for quality settings.</p>
            <p>Bookmark this page for your team's wiki — consistent PDF-to-Word steps reduce support tickets when onboarding new staff each quarter.</p>
            
            
            <h2>Failure messages</h2>
            <p><strong>Too large:</strong> compress or split. <strong>Invalid PDF:</strong> re-export source. <strong>Unreadable:</strong> re-scan don't only compress blur.</p>
            <h2>Archive discipline</h2>
            <p>Keep uncompressed master until upload or send succeeds — derivatives are disposable.</p>
            <h2>Compare tools</h2>
            <p><a href="/compare/smallpdf-alternative">Smallpdf</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/adobe-alternative">Adobe</a>.</p>
            
            
            <h2>Related guides</h2>
            <p>Editing guides cover crop, delete, annotate, highlight, rearrange pages, add text, fill forms, device workflows, blank-page cleanup, and rotate — step-by-step help for each task.</p>
            <p>Next troubleshooting wave: corrupt PDF, won’t open, print errors — bookmark <a href="/guides/pdf-tools">PDF tools hub</a> for full map.</p>
            
            
            <h2>More guides</h2>
            <p>Image, PowerPoint, and Word conversion guides, plus editing tutorials and competitor comparisons — all in one place.</p>
            <p>Main guides: <a href="/guides/images-to-pdf">images</a> · <a href="/guides/pdf-to-word">PDF to Word</a> · <a href="/guides/split-pdf">split</a> · <a href="/compare">compare</a>.</p>
            <h2>Post-action checklist</h2>
            <ol><li>Output opens in Chrome PDF viewer</li><li>Page order matches intent</li><li>Text selects if downstream edit needed</li><li>File size under email/portal cap</li><li>Master archived before deleting source</li></ol>
            <p>Bookmark the <a href="/guides/pdf-tools">PDF tools guide</a> and <a href="/compare">compare tools</a> for team onboarding — consistent tool choice reduces wrong-output support tickets.</p>
            
            
            <h2>Post-action checklist</h2>
            <ol><li>Output file opens in viewer</li><li>Text selects if required</li><li>Size under portal/email preset</li><li>Master archived</li><li>Correct tool used for next step (text vs Word vs OCR)</li></ol>
            <p>Bookmark the <a href="/guides/pdf-tools">PDF tools guide</a> and <a href="/compare">compare tools</a> for team onboarding — consistent tool choice reduces wrong-output support tickets.</p>
            <p>Re-run size checker after every derivative step — compress, split, or text export — before deleting the previous version from your working folder.</p>
            
            <p class="mt-4"><a href="/pdf/editpdf" class="btn btn-primary">Edit PDF</a> · <a href="/guides/edit-pdf">Edit PDF hub</a></p>
            """;

        private const string CropPdfWithoutAdobe = """
            <h2>Crop PDF without Adobe — free browser workflow</h2>
            <p>RatPDF <a href="/pdf/editpdf">Edit PDF</a> — Chromebook user trims fax margins without Acrobat install.</p>
            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> Crop PDF without Adobe — free browser workflow</figcaption></figure>
            
            <h2>Why teams skip Acrobat for crop</h2>
            <p>Annual Pro seats for occasional margin trim fail ROI review. Browser path passes IT review when retention policy is documented.</p>
            <h2>Chromebook and Linux</h2>
            <p>No Wine layer — crop source images locally — convert — compress — same stack as Windows.</p>
            <h2>Compare vendors</h2>
            <p><a href="/compare/adobe-acrobat-alternative">Adobe alternative</a> · <a href="/compare/smallpdf-alternative">Smallpdf</a> — test hardest sample scan before switching.</p>
            
            
            <h2>IT security questionnaire</h2>
            <p>Answer: HTTPS upload, auto-delete retention, no desktop agent — link privacy and security pages.</p>
            <h2>Freelancer travel laptop</h2>
            <p>Hotel Wi-Fi crop-convert-send — no Creative Cloud license on personal Mac.</p>
            
            <div class="rp-mid-cta alert alert-primary my-4"><strong>Start now</strong> <a href="/pdf/editpdf" class="alert-link fw-semibold">Edit PDF →</a></div>
            
            <h2>Edit vs convert vs OCR decision tree</h2>
            <p><strong>Digital PDF minor fix:</strong> Edit PDF text overlay. <strong>Heavy rewrite:</strong> PDF to Word. <strong>Scan:</strong> OCR first. <strong>Wrong page order:</strong> Organize via merge queue. <strong>One page pull:</strong> Split PDF.</p>
            <h2>Form filling landscape</h2>
            <p>Government PDFs mix fillable AcroForm fields and flat scans. Fillable fields preserve tab order — flat forms need positioned text boxes — print-test alignment before official submit.</p>
            <h2>Scanned document edit chain</h2>
            <ol>
            <li>Scan 300 DPI grayscale upright</li>
            <li><a href="/pdf/ocrpdf">OCR PDF</a> — verify Ctrl+F finds key term</li>
            <li><a href="/pdf/editpdf">Edit PDF</a> — add date, signature image, stamp</li>
            <li>Optional <a href="/guides/compress-pdf-for-email">compress</a> before portal upload</li>
            </ol>
            <h2>Organize without desktop Acrobat</h2>
            <p>Reorder pages in merge tool — drag queue — single merge output — same engine as <a href="/guides/merge-pdf-custom-order">custom order merge</a>. Delete pages by omitting from queue not destructive edit on source.</p>
            <h2>Image overlay best practices</h2>
            <p>Logo PNG with transparency — place top-right — do not cover existing signature block. DPI 150 sufficient for screen PDF — 300 for print-bound proposals.</p>
            <h2>Security and audit</h2>
            <p>Edited PDF is new derivative — keep unedited master for legal hold — filename suffix <code>-edited-2026-04-02</code>. Flatten annotations before court filing if local rules require.</p>
            
            
            <h2>Browser edit limitations</h2>
            <p>RatPDF edit covers common SMB needs — text add, image stamp, form fill — not InDesign prepress — not Photoshop pixel surgery. For marketing brochure pixel edits return to design source.</p>
            <h2>Mobile edit caution</h2>
            <p>Fine form alignment on phone is painful — desktop for government forms — mobile OK for initial and date on consent PDF.</p>
            <h2>Password-protected PDFs</h2>
            <p>Unlock first: <a href="/guides/unlock-pdf">unlock PDF</a> — edit fails on encrypted open.</p>
            <h2>Compare vendors</h2>
            <p><a href="/compare/adobe-alternative">Adobe</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/smallpdf-alternative">Smallpdf</a> — evaluate form-fill on your hardest government PDF sample.</p>
            <h2>Split and extract coordination</h2>
            <p>Extract signature page before sending for countersign — <a href="/guides/extract-single-page-pdf">extract single page</a> — merge back after scan with <a href="/pdf/merge">Merge PDF</a>.</p>
            <h2>QA print test</h2>
            <p>Government forms reject misaligned fields — print one copy — hold to light against blank form — adjust coordinates before batch.</p>
            
            
            <h2>Edit cluster authority map</h2>
            <p>Editing guides cover crop, delete, annotate, highlight, rearrange pages, and device workflows — plus in-depth help for <a href="/guides/edit-pdf">edit PDF</a> and <a href="/guides/rotate-pdf">rotate PDF</a>. See also merge, split, and OCR guides.</p>
            <h2>Security and compliance</h2>
            <p>Edited derivatives are new files — keep immutable master — log who edited — confidential docs cleared from Downloads on shared PCs same day. HIPAA and legal hold: counsel approves browser edit on PHI or privilege docs.</p>
            <h2>Failure triage</h2>
            <p><strong>Cannot select text:</strong> OCR first. <strong>Wrong page count after delete:</strong> off-by-one viewer index — recount. <strong>Portal rejects filled form:</strong> print-test alignment — font mismatch — try flatten. <strong>Upload timeout:</strong> Wi-Fi — compress — split.</p>
            <h2>Research links</h2>
            <p><a href="/research/attachment-size-limits">Email attachment limits</a> · <a href="/research/pdf-tool-market-comparison">PDF tool market comparison</a> · <a href="/compare">Compare hub</a>.</p>
            
            
            <h2>Workflow deep dive — Crop PDF without Adobe — free browser workflow</h2>
            <p>Browser workflow — no install — upload → process → download → verify in viewer before external send.</p>
            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> Crop PDF without Adobe — free browser workflow</figcaption></figure>
            <h2>Mobile</h2>
            <p>Safari/Chrome on phone works — Wi-Fi for files over 15 MB — save to Files before portal upload.</p>
            <h2>Failures</h2>
            <p>Timeout: retry Wi-Fi · corrupt PDF: re-export source · password: <a href="/guides/unlock-pdf">unlock</a>.</p>
            <h2>Free tier</h2>
            <p>Three uses/day — <a href="/Subscription/Plans">plans</a> for volume.</p>
            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Open tool</strong> <a href="/pdf/editpdf" class="alert-link fw-semibold">Go →</a></div>
            
            
            <h2>Real example: HR onboarding packet</h2>
            <p>Flat I-9 scan — OCR — add start date field — employee initials — merge with handbook acknowledgment — compress — upload to HRIS.</p>
            <h2>Second example: property manager lease initialed</h2>
            <p>Scan signed lease pages — add initialed watermark on page 4 rider — re-compress for email to tenant.</p>
            <h2>Third example: proposal logo</h2>
            <p>Sales exports proposal PDF from CRM — add partner logo top-left — send to client — no return to InDesign.</p>
            <h2>Discovery page pull</h2>
            <p>Counsel needs only exhibit G from 200-page production — split page range 142-148 — email to expert witness — index in cover note.</p>
            <h2>Medical admin form</h2>
            <p>Clinic scan intake form — OCR — nurse adds checkbox marks — print for patient sign — scan again for chart.</p>
            <h2>Upgrade path</h2>
            <p>High-volume form shop — <a href="/Subscription/Plans">plans</a> — see the <a href="/guides/edit-pdf">edit PDF hub</a>.</p>
            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Edit your PDF</strong> <a href="/pdf/editpdf" class="alert-link fw-semibold">Edit PDF →</a></div>
            
            
            
            <h2>Browser vs desktop</h2>
            <p>RatPDF needs no install — IT-friendly — confidential docs review privacy policy retention window.</p>
            <h2>Chain tools</h2>
            <p>Convert → edit → compress → merge — pick order by deliverable — see the <a href="/guides/pdf-tools">PDF tools hub</a>.</p>
            <h2>Upgrade</h2>
            <p><a href="/Subscription/Plans">subscription plans</a> for daily caps on agency volume.</p>
            
            
            <h2>Cross-wave tool chain</h2>
            <p>Pick tool order by what you need to deliver. Example: photos → images PDF → OCR → edit date → compress → portal upload.</p>
            <h2>Free tier and upgrade</h2>
            <p>Three uses per day per tool on free tier — agency month-end exceeds cap — <a href="/Subscription/Plans">subscription plans</a> — predictable vs per-file credit packs.</p>
            <h2>Internal link discipline</h2>
            <p>Each guide links to related tools and comparisons so your team picks the right workflow.</p>
            <h2>Support triage</h2>
            <p>Wrong tool order causes bad output — OCR before edit on scans — compress after merge not before each file — train your team using the main tool guides.</p>
            
            
            <h2>QA before send</h2>
            <ol><li>Page count correct</li><li>Text selects if required</li><li>Images sharp at 150% zoom</li><li>File opens in Chrome PDF viewer</li><li>Size under email/portal cap</li></ol>
            <h2>Compare vendors</h2>
            <p><a href="/compare/smallpdf-alternative">Smallpdf</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/adobe-alternative">Adobe</a>.</p>
            
            
            <h2>Device matrix</h2>
            <p>Windows Edge, Mac Safari, iPhone Safari, Android Chrome — same account — no sync required — download to device storage before portal upload.</p>
            <h2>Retention hygiene</h2>
            <p>Clear Downloads on shared PC — contracts and medical admin PDFs are confidential — delete derivatives when task completes.</p>
            <h2>Filename and version control</h2>
            <p><code>Client-Doc-v2-edited.pdf</code> — never overwrite sent attachment — email thread references version.</p>
            <h2>Portal rejection loop</h2>
            <p>Reject → check size with <a href="/pdf-size-checker">size checker</a> → compress Less → split if still over → re-upload before session timeout.</p>
            <h2>Research links</h2>
            <p><a href="/research/attachment-size-limits">Attachment size limits</a> · <a href="/research/pdf-compression-benchmark">Compression benchmark</a> · <a href="/research/freelancer-invoicing-statistics">Invoicing statistics</a>.</p>
            <h2>Pillar bookmark set</h2>
            <p><a href="/guides/pdf-tools">PDF tools hub</a> · <a href="/guides/images-to-pdf">Images to PDF</a> · <a href="/guides/pdf-to-word">PDF to Word</a> · <a href="/guides/split-pdf">Split PDF</a> · <a href="/compare">Compare hub</a>.</p>
            
            
            <h2>Edit audit log</h2>
            <p>Log who edited which PDF derivative — timestamp — reason — matter number — supports litigation hold and SOX-style controls.</p>
            <h2>Flatten before external send</h2>
            <p>Some recipients see floating annotations differently — flatten or re-export PDF so logo and text boxes appear identical on all viewers.</p>
            <h2>Redaction before edit</h2>
            <p>Remove SSN and account numbers with <a href="/guides/pdf-redaction-permanent">permanent redaction</a> before adding new text — edit tool does not replace redaction workflow.</p>
            <h2>Training slide for staff</h2>
            <p>Three rules poster: OCR scans first — organize before merge — compress after combine — pin in Slack onboarding channel.</p>
            <h2>Department-specific examples</h2>
            <p><strong>HR:</strong> I-9 and handbook ack merge. <strong>Sales:</strong> logo on proposal. <strong>Legal:</strong> exhibit extract. <strong>Finance:</strong> initialed tax form. <strong>Ops:</strong> delivery note stamp.</p>
            <h2>Version rollback</h2>
            <p>Keep pre-edit master immutable — if client rejects edit — resend from master not undo in editor — filename version increments.</p>
            <h2>Collaboration handoff</h2>
            <p>Paralegal extracts page — attorney reviews in isolation — merge signed scan back — document handoff in matter management ticket.</p>
            <h2>Accessibility after edit</h2>
            <p>Added text may not be tagged — government accessibility filing may need tagged PDF specialist — SMB email deliverable usually exempt.</p>
            <h2>Pillar cross-links</h2>
            <p><a href="/guides/merge-pdf-online">merge PDF</a> · <a href="/guides/ocr-pdf">OCR PDF</a> · <a href="/guides/split-pdf">split hub</a> · <a href="/guides/pdf-tools">PDF tools hub</a>.</p>
            
            
            <h2>QA checklist — edit outputs</h2>
            <ol>
            <li>Page count matches intent after delete or rearrange</li>
            <li>Orientation correct on every page at thumbnail view</li>
            <li>Added text readable at 150% zoom and in print preview</li>
            <li>Annotations visible in Chrome PDF viewer and recipient test</li>
            <li>File size under email or portal cap — compress if needed</li>
            <li>Master archived before destructive delete</li>
            </ol>
            <h2>Department playbooks</h2>
            <p><strong>Legal:</strong> annotate review copy — master untouched. <strong>Finance:</strong> fill tax PDF — print-test. <strong>HR:</strong> OCR onboarding — merge ack. <strong>Sales:</strong> logo + date on proposal. <strong>Ops:</strong> delete blank feeder pages from scan batch.</p>
            <h2>Monthly volume</h2>
            <p>Track edit/remove jobs — exceed free tier twice in one week — finance approves <a href="/Subscription/Plans">subscription</a>.</p>
            <h2>Compare alternatives</h2>
            <p><a href="/compare/adobe-acrobat-alternative">Adobe Acrobat alternative</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/smallpdf-alternative">Smallpdf</a>.</p>
            
            
            <h2>Team rollout notes</h2>
            <p>Pin the main tool guides in your shared wiki — compress before portal, OCR before edit on scans, Word path only when ERP cannot reissue. New hires complete one sample file in first week using browser tools only — no desktop install ticket.</p>
            <h2>Support escalation path</h2>
            <p>Step 1: re-download output and open in Chrome viewer. Step 2: retry on Wi-Fi with smaller batch. Step 3: check <a href="/pdf-size-checker">size checker</a> preset. Step 4: compare tool choice on <a href="/compare">compare tools</a> if output quality insufficient.</p>
            <h2>Record retention</h2>
            <p>Keep source PDF until recipient confirms receipt — derivatives disposable after successful upload — confidential docs deleted from Downloads on shared machines same day.</p>
            <h2>Monthly volume planning</h2>
            <p>Track daily tool usage in spreadsheet — forecast upgrade need before month-end crunch — finance approves <a href="/Subscription/Plans">subscription</a> when free tier blocks twice in one week.</p>
            <h2>Incident log template</h2>
            <p>Date, source filename, tool used, error message, resolution — patterns reveal training gaps — share quarterly with ops lead.</p>
            
            
            <h2>Quick reference card</h2>
            <p>Scan → OCR → Edit. Digital → Edit direct. Reorder → Merge queue. One page → Split. Logo → Add image. Forms → Fill then print-test. Archive master before any derivative edit.</p>
            <p>Bookmark <a href="/guides/edit-pdf">edit PDF guide</a> for team onboarding — reduces wrong-tool support tickets.</p>
            <p>Wrong page order voids visa bundles — verify thumbnail strip before merge submit.</p>
            
            
            <h2>Related edit &amp; organize guides</h2>
            <ul>
            <li><a href="/guides/edit-scanned-pdf">Edit scanned PDF</a></li>
            <li><a href="/guides/organize-pdf-pages">Organize PDF pages</a></li>
            <li><a href="/guides/split-pdf-page-range">Split by page range</a></li>
            <li><a href="/guides/add-image-to-pdf">Add image to PDF</a></li>
            </ul>
            
            
            <h2>Edit-gap guides</h2>
            <ul>
            <li><a href="/guides/crop-pdf-online">Crop PDF online</a> · <a href="/guides/crop-pdf-without-adobe">Crop without Adobe</a></li>
            <li><a href="/guides/delete-pages-from-pdf">Delete pages</a> · <a href="/guides/remove-blank-pages-pdf">Remove blank pages</a></li>
            <li><a href="/guides/annotate-pdf-online">Annotate online</a> · <a href="/guides/annotate-pdf-free">Annotate free</a></li>
            <li><a href="/guides/highlight-pdf-online">Highlight PDF</a> · <a href="/guides/edit-pdf-text-online">Edit text</a></li>
            <li><a href="/guides/add-text-to-pdf">Add text</a> · <a href="/guides/fill-pdf-form-online">Fill form</a></li>
            <li><a href="/guides/rearrange-pdf-pages">Rearrange pages</a> · <a href="/guides/edit-pdf-without-acrobat">Without Acrobat</a></li>
            <li><a href="/guides/edit-pdf-on-mac">Edit on Mac</a> · <a href="/guides/edit-pdf-on-windows">Windows</a> · <a href="/guides/edit-pdf-on-iphone">iPhone</a></li>
            </ul>
            <h2>Pillar and organize links</h2>
            <p><a href="/guides/edit-pdf">Edit PDF guide</a> · <a href="/guides/rotate-pdf">Rotate PDF</a> · <a href="/guides/organize-pdf-pages">Organize pages</a> · <a href="/guides/merge-pdf">Merge guide</a> · <a href="/guides/split-pdf">Split guide</a> · <a href="/guides/ocr-pdf">OCR guide</a>.</p>
            
            
            <h2>Enterprise document workflows</h2>
            <p>Legal ops teams convert legacy contract PDFs during CLM migration — batch convert critical folders, prioritise active vendor agreements first. IT should approve browser upload policy for confidential docs.</p>

            <h2>Education sector</h2>
            <p>Faculty edit syllabus PDFs each semester — digital university PDFs convert cleanly; scanned course packs need OCR. Check campus IT data handling before upload.</p>

            <h2>Real estate</h2>
            <p>Lease amendments stored as PDF — convert to Word for redline, re-PDF for signature. Keep executed scan archived separately from working DOCX.</p>

            <h2>HR and offer letters</h2>
            <p>Template offer PDFs with merge fields sometimes break on convert — edit boilerplate in Word template instead of converting each hire if HRIS exports PDF.</p>

            <h2>Government RFP responses</h2>
            <p>Final submissions often must be PDF — use Word only for draft edits, export via <a href="/pdf/doctopdf">Word to PDF</a> for portal upload. Check RFP forbids track changes in submission.</p>

            <h2>Quality gates before client delivery</h2>
            <ol>
            <li>Spell-check in Word</li>
            <li>Compare page count vs source PDF</li>
            <li>Verify critical numbers (dates, amounts) unchanged</li>
            <li>Remove comments and track changes</li>
            <li>Export final PDF if deliverable format is PDF</li>
            </ol>

            <p>Pillar: <a href="/guides/pdf-to-word">PDF to Word guide</a> · Compare: <a href="/compare/smallpdf-alternative">Smallpdf alternative</a></p>
            
            
            <h2>Batch conversion hygiene</h2>
            <p>Converting 20 contracts? Use consistent naming <code>ClientName-contract-v1.docx</code>. Log source PDF hash if legal audit trail required.</p>

            <h2>Mobile upload caveats</h2>
            <p>Phone browsers work but large PDFs may timeout on cellular — use Wi-Fi or desktop for 50+ MB files.</p>

            <h2>Antivirus false positives</h2>
            <p>Some corporate proxies scan uploads — if blocked, try guest network or contact IT to allowlist ratpdf.com tool path.</p>

            <h2>Long-term archival</h2>
            <p>Store both source PDF and final DOCX/PDF pair — migrations sometimes need to re-edit decade-old contracts.</p>

            <h2>Regulatory and compliance edits</h2>
            <p>Privacy policies, SOC2 reports, and vendor security questionnaires arrive as PDF — convert to Word for comment, return PDF via <a href="/pdf/doctopdf">Word to PDF</a>. Legal should review material compliance wording changes.</p>

            <h2>Performance expectations</h2>
            <p>10-page digital PDF typically converts under two minutes; 200-page annual report may take longer — do not close tab during processing. Refresh only after timeout message.</p>
            
            
            <h2>Document type quick reference</h2>
            <p><strong>Contracts:</strong> digital PDF, track changes in Word. <strong>Invoices:</strong> table-heavy — check sums. <strong>Scanned forms:</strong> OCR first. <strong>Marketing PDFs:</strong> expect image blocks. <strong>Manuals:</strong> headings usually survive — update TOC in Word after edits.</p>
            <p>Upgrade for volume: <a href="/Subscription/Plans">subscription plans</a>. Pillar: <a href="/guides/pdf-to-word">PDF to Word</a>.</p>

            <h2>Stakeholder sign-off matrix</h2>
            <p>Legal reviews converted contracts; finance reviews invoice PDFs edited in Word; HR reviews offer letters. Route DOCX to the right reviewer before re-PDF. Version suffix in filename (<code>-legal-reviewed</code>) prevents accidental send of draft.</p>
            <p>After major edits, compress before email if DOCX re-export exceeds mailbox limits — see <a href="/research/pdf-compression-benchmark">PDF compression benchmark</a> for quality settings.</p>
            <p>Bookmark this page for your team's wiki — consistent PDF-to-Word steps reduce support tickets when onboarding new staff each quarter.</p>
            
            
            <h2>Failure messages</h2>
            <p><strong>Too large:</strong> compress or split. <strong>Invalid PDF:</strong> re-export source. <strong>Unreadable:</strong> re-scan don't only compress blur.</p>
            <h2>Archive discipline</h2>
            <p>Keep uncompressed master until upload or send succeeds — derivatives are disposable.</p>
            <h2>Compare tools</h2>
            <p><a href="/compare/smallpdf-alternative">Smallpdf</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/adobe-alternative">Adobe</a>.</p>
            
            
            <h2>Related guides</h2>
            <p>Editing guides cover crop, delete, annotate, highlight, rearrange pages, add text, fill forms, device workflows, blank-page cleanup, and rotate — step-by-step help for each task.</p>
            <p>Next troubleshooting wave: corrupt PDF, won’t open, print errors — bookmark <a href="/guides/pdf-tools">PDF tools hub</a> for full map.</p>
            
            
            <h2>More guides</h2>
            <p>Image, PowerPoint, and Word conversion guides, plus editing tutorials and competitor comparisons — all in one place.</p>
            <p>Main guides: <a href="/guides/images-to-pdf">images</a> · <a href="/guides/pdf-to-word">PDF to Word</a> · <a href="/guides/split-pdf">split</a> · <a href="/compare">compare</a>.</p>
            <h2>Post-action checklist</h2>
            <ol><li>Output opens in Chrome PDF viewer</li><li>Page order matches intent</li><li>Text selects if downstream edit needed</li><li>File size under email/portal cap</li><li>Master archived before deleting source</li></ol>
            <p>Bookmark the <a href="/guides/pdf-tools">PDF tools guide</a> and <a href="/compare">compare tools</a> for team onboarding — consistent tool choice reduces wrong-output support tickets.</p>
            
            
            <h2>Post-action checklist</h2>
            <ol><li>Output file opens in viewer</li><li>Text selects if required</li><li>Size under portal/email preset</li><li>Master archived</li><li>Correct tool used for next step (text vs Word vs OCR)</li></ol>
            <p>Bookmark the <a href="/guides/pdf-tools">PDF tools guide</a> and <a href="/compare">compare tools</a> for team onboarding — consistent tool choice reduces wrong-output support tickets.</p>
            <p>Re-run size checker after every derivative step — compress, split, or text export — before deleting the previous version from your working folder.</p>
            
            <p class="mt-4"><a href="/pdf/editpdf" class="btn btn-primary">Edit PDF</a> · <a href="/guides/edit-pdf">Edit PDF hub</a></p>
            """;

        private const string DeletePagesFromPdf = """
            <h2>Delete pages from PDF — remove blanks &amp; duplicates online</h2>
            <p>RatPDF <a href="/pdf/rotateorremove">Rotate / Remove Pages</a> — Drop blank page 12 and duplicate cover from merged job pack.</p>
            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> Delete pages from PDF — remove blanks &amp; duplicates online</figcaption></figure>
            
            <h2>Delete vs split vs omit-on-merge</h2>
            <p><strong>Delete/remove:</strong> permanent drop of page indices via <a href="/pdf/rotateorremove">Rotate / Remove</a>. <strong>Split:</strong> keep master, send subset. <strong>Merge queue:</strong> omit unwanted pages when rebuilding bundle.</p>
            <h2>Step-by-step delete pages</h2>
            <ol>
            <li>Open PDF in viewer — note page numbers to remove (check footer vs viewer index).</li>
            <li>Upload to Rotate / Remove — select remove mode — enter pages <code>3, 12, 15</code> or range <code>10-12</code>.</li>
            <li>Download — verify page count decreased — spot-check content at former boundaries.</li>
            <li>Archive unedited master for legal hold before destructive delete.</li>
            </ol>
            <h2>After delete</h2>
            <p>Email still too large? <a href="/guides/compress-pdf-guide">Compress guide</a>. Wrong order? <a href="/guides/rearrange-pdf-pages">Rearrange pages</a>.</p>
            
            
            <h2>Job application pack</h2>
            <p>Accidentally merged cover letter twice — delete page 1 duplicate — verify resume starts page 1 after delete.</p>
            <h2>Court exhibit hygiene</h2>
            <p>Remove privileged page before production — keep privilege log — master preserved.</p>
            
            <div class="rp-mid-cta alert alert-primary my-4"><strong>Start now</strong> <a href="/pdf/rotateorremove" class="alert-link fw-semibold">Rotate / Remove Pages →</a></div>
            
            <h2>Edit vs convert vs OCR decision tree</h2>
            <p><strong>Digital PDF minor fix:</strong> Edit PDF text overlay. <strong>Heavy rewrite:</strong> PDF to Word. <strong>Scan:</strong> OCR first. <strong>Wrong page order:</strong> Organize via merge queue. <strong>One page pull:</strong> Split PDF.</p>
            <h2>Form filling landscape</h2>
            <p>Government PDFs mix fillable AcroForm fields and flat scans. Fillable fields preserve tab order — flat forms need positioned text boxes — print-test alignment before official submit.</p>
            <h2>Scanned document edit chain</h2>
            <ol>
            <li>Scan 300 DPI grayscale upright</li>
            <li><a href="/pdf/ocrpdf">OCR PDF</a> — verify Ctrl+F finds key term</li>
            <li><a href="/pdf/editpdf">Edit PDF</a> — add date, signature image, stamp</li>
            <li>Optional <a href="/guides/compress-pdf-for-email">compress</a> before portal upload</li>
            </ol>
            <h2>Organize without desktop Acrobat</h2>
            <p>Reorder pages in merge tool — drag queue — single merge output — same engine as <a href="/guides/merge-pdf-custom-order">custom order merge</a>. Delete pages by omitting from queue not destructive edit on source.</p>
            <h2>Image overlay best practices</h2>
            <p>Logo PNG with transparency — place top-right — do not cover existing signature block. DPI 150 sufficient for screen PDF — 300 for print-bound proposals.</p>
            <h2>Security and audit</h2>
            <p>Edited PDF is new derivative — keep unedited master for legal hold — filename suffix <code>-edited-2026-04-02</code>. Flatten annotations before court filing if local rules require.</p>
            
            
            <h2>Browser edit limitations</h2>
            <p>RatPDF edit covers common SMB needs — text add, image stamp, form fill — not InDesign prepress — not Photoshop pixel surgery. For marketing brochure pixel edits return to design source.</p>
            <h2>Mobile edit caution</h2>
            <p>Fine form alignment on phone is painful — desktop for government forms — mobile OK for initial and date on consent PDF.</p>
            <h2>Password-protected PDFs</h2>
            <p>Unlock first: <a href="/guides/unlock-pdf">unlock PDF</a> — edit fails on encrypted open.</p>
            <h2>Compare vendors</h2>
            <p><a href="/compare/adobe-alternative">Adobe</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/smallpdf-alternative">Smallpdf</a> — evaluate form-fill on your hardest government PDF sample.</p>
            <h2>Split and extract coordination</h2>
            <p>Extract signature page before sending for countersign — <a href="/guides/extract-single-page-pdf">extract single page</a> — merge back after scan with <a href="/pdf/merge">Merge PDF</a>.</p>
            <h2>QA print test</h2>
            <p>Government forms reject misaligned fields — print one copy — hold to light against blank form — adjust coordinates before batch.</p>
            
            
            <h2>Edit cluster authority map</h2>
            <p>Editing guides cover crop, delete, annotate, highlight, rearrange pages, and device workflows — plus in-depth help for <a href="/guides/edit-pdf">edit PDF</a> and <a href="/guides/rotate-pdf">rotate PDF</a>. See also merge, split, and OCR guides.</p>
            <h2>Security and compliance</h2>
            <p>Edited derivatives are new files — keep immutable master — log who edited — confidential docs cleared from Downloads on shared PCs same day. HIPAA and legal hold: counsel approves browser edit on PHI or privilege docs.</p>
            <h2>Failure triage</h2>
            <p><strong>Cannot select text:</strong> OCR first. <strong>Wrong page count after delete:</strong> off-by-one viewer index — recount. <strong>Portal rejects filled form:</strong> print-test alignment — font mismatch — try flatten. <strong>Upload timeout:</strong> Wi-Fi — compress — split.</p>
            <h2>Research links</h2>
            <p><a href="/research/attachment-size-limits">Email attachment limits</a> · <a href="/research/pdf-tool-market-comparison">PDF tool market comparison</a> · <a href="/compare">Compare hub</a>.</p>
            
            
            <h2>Workflow deep dive — Delete pages from PDF — remove blanks &amp; duplicates online</h2>
            <p>Browser workflow — no install — upload → process → download → verify in viewer before external send.</p>
            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> Delete pages from PDF — remove blanks &amp; duplicates online</figcaption></figure>
            <h2>Mobile</h2>
            <p>Safari/Chrome on phone works — Wi-Fi for files over 15 MB — save to Files before portal upload.</p>
            <h2>Failures</h2>
            <p>Timeout: retry Wi-Fi · corrupt PDF: re-export source · password: <a href="/guides/unlock-pdf">unlock</a>.</p>
            <h2>Free tier</h2>
            <p>Three uses/day — <a href="/Subscription/Plans">plans</a> for volume.</p>
            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Open tool</strong> <a href="/pdf/rotateorremove" class="alert-link fw-semibold">Go →</a></div>
            
            
            <h2>Real example: HR onboarding packet</h2>
            <p>Flat I-9 scan — OCR — add start date field — employee initials — merge with handbook acknowledgment — compress — upload to HRIS.</p>
            <h2>Second example: property manager lease initialed</h2>
            <p>Scan signed lease pages — add initialed watermark on page 4 rider — re-compress for email to tenant.</p>
            <h2>Third example: proposal logo</h2>
            <p>Sales exports proposal PDF from CRM — add partner logo top-left — send to client — no return to InDesign.</p>
            <h2>Discovery page pull</h2>
            <p>Counsel needs only exhibit G from 200-page production — split page range 142-148 — email to expert witness — index in cover note.</p>
            <h2>Medical admin form</h2>
            <p>Clinic scan intake form — OCR — nurse adds checkbox marks — print for patient sign — scan again for chart.</p>
            <h2>Upgrade path</h2>
            <p>High-volume form shop — <a href="/Subscription/Plans">plans</a> — see the <a href="/guides/edit-pdf">edit PDF hub</a>.</p>
            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Edit your PDF</strong> <a href="/pdf/editpdf" class="alert-link fw-semibold">Edit PDF →</a></div>
            
            
            
            <h2>Browser vs desktop</h2>
            <p>RatPDF needs no install — IT-friendly — confidential docs review privacy policy retention window.</p>
            <h2>Chain tools</h2>
            <p>Convert → edit → compress → merge — pick order by deliverable — see the <a href="/guides/pdf-tools">PDF tools hub</a>.</p>
            <h2>Upgrade</h2>
            <p><a href="/Subscription/Plans">subscription plans</a> for daily caps on agency volume.</p>
            
            
            <h2>Cross-wave tool chain</h2>
            <p>Pick tool order by what you need to deliver. Example: photos → images PDF → OCR → edit date → compress → portal upload.</p>
            <h2>Free tier and upgrade</h2>
            <p>Three uses per day per tool on free tier — agency month-end exceeds cap — <a href="/Subscription/Plans">subscription plans</a> — predictable vs per-file credit packs.</p>
            <h2>Internal link discipline</h2>
            <p>Each guide links to related tools and comparisons so your team picks the right workflow.</p>
            <h2>Support triage</h2>
            <p>Wrong tool order causes bad output — OCR before edit on scans — compress after merge not before each file — train your team using the main tool guides.</p>
            
            
            <h2>QA before send</h2>
            <ol><li>Page count correct</li><li>Text selects if required</li><li>Images sharp at 150% zoom</li><li>File opens in Chrome PDF viewer</li><li>Size under email/portal cap</li></ol>
            <h2>Compare vendors</h2>
            <p><a href="/compare/smallpdf-alternative">Smallpdf</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/adobe-alternative">Adobe</a>.</p>
            
            
            <h2>Device matrix</h2>
            <p>Windows Edge, Mac Safari, iPhone Safari, Android Chrome — same account — no sync required — download to device storage before portal upload.</p>
            <h2>Retention hygiene</h2>
            <p>Clear Downloads on shared PC — contracts and medical admin PDFs are confidential — delete derivatives when task completes.</p>
            <h2>Filename and version control</h2>
            <p><code>Client-Doc-v2-edited.pdf</code> — never overwrite sent attachment — email thread references version.</p>
            <h2>Portal rejection loop</h2>
            <p>Reject → check size with <a href="/pdf-size-checker">size checker</a> → compress Less → split if still over → re-upload before session timeout.</p>
            <h2>Research links</h2>
            <p><a href="/research/attachment-size-limits">Attachment size limits</a> · <a href="/research/pdf-compression-benchmark">Compression benchmark</a> · <a href="/research/freelancer-invoicing-statistics">Invoicing statistics</a>.</p>
            <h2>Pillar bookmark set</h2>
            <p><a href="/guides/pdf-tools">PDF tools hub</a> · <a href="/guides/images-to-pdf">Images to PDF</a> · <a href="/guides/pdf-to-word">PDF to Word</a> · <a href="/guides/split-pdf">Split PDF</a> · <a href="/compare">Compare hub</a>.</p>
            
            
            <h2>Edit audit log</h2>
            <p>Log who edited which PDF derivative — timestamp — reason — matter number — supports litigation hold and SOX-style controls.</p>
            <h2>Flatten before external send</h2>
            <p>Some recipients see floating annotations differently — flatten or re-export PDF so logo and text boxes appear identical on all viewers.</p>
            <h2>Redaction before edit</h2>
            <p>Remove SSN and account numbers with <a href="/guides/pdf-redaction-permanent">permanent redaction</a> before adding new text — edit tool does not replace redaction workflow.</p>
            <h2>Training slide for staff</h2>
            <p>Three rules poster: OCR scans first — organize before merge — compress after combine — pin in Slack onboarding channel.</p>
            <h2>Department-specific examples</h2>
            <p><strong>HR:</strong> I-9 and handbook ack merge. <strong>Sales:</strong> logo on proposal. <strong>Legal:</strong> exhibit extract. <strong>Finance:</strong> initialed tax form. <strong>Ops:</strong> delivery note stamp.</p>
            <h2>Version rollback</h2>
            <p>Keep pre-edit master immutable — if client rejects edit — resend from master not undo in editor — filename version increments.</p>
            <h2>Collaboration handoff</h2>
            <p>Paralegal extracts page — attorney reviews in isolation — merge signed scan back — document handoff in matter management ticket.</p>
            <h2>Accessibility after edit</h2>
            <p>Added text may not be tagged — government accessibility filing may need tagged PDF specialist — SMB email deliverable usually exempt.</p>
            <h2>Pillar cross-links</h2>
            <p><a href="/guides/merge-pdf-online">merge PDF</a> · <a href="/guides/ocr-pdf">OCR PDF</a> · <a href="/guides/split-pdf">split hub</a> · <a href="/guides/pdf-tools">PDF tools hub</a>.</p>
            
            
            <h2>QA checklist — edit outputs</h2>
            <ol>
            <li>Page count matches intent after delete or rearrange</li>
            <li>Orientation correct on every page at thumbnail view</li>
            <li>Added text readable at 150% zoom and in print preview</li>
            <li>Annotations visible in Chrome PDF viewer and recipient test</li>
            <li>File size under email or portal cap — compress if needed</li>
            <li>Master archived before destructive delete</li>
            </ol>
            <h2>Department playbooks</h2>
            <p><strong>Legal:</strong> annotate review copy — master untouched. <strong>Finance:</strong> fill tax PDF — print-test. <strong>HR:</strong> OCR onboarding — merge ack. <strong>Sales:</strong> logo + date on proposal. <strong>Ops:</strong> delete blank feeder pages from scan batch.</p>
            <h2>Monthly volume</h2>
            <p>Track edit/remove jobs — exceed free tier twice in one week — finance approves <a href="/Subscription/Plans">subscription</a>.</p>
            <h2>Compare alternatives</h2>
            <p><a href="/compare/adobe-acrobat-alternative">Adobe Acrobat alternative</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/smallpdf-alternative">Smallpdf</a>.</p>
            
            
            <h2>Team rollout notes</h2>
            <p>Pin the main tool guides in your shared wiki — compress before portal, OCR before edit on scans, Word path only when ERP cannot reissue. New hires complete one sample file in first week using browser tools only — no desktop install ticket.</p>
            <h2>Support escalation path</h2>
            <p>Step 1: re-download output and open in Chrome viewer. Step 2: retry on Wi-Fi with smaller batch. Step 3: check <a href="/pdf-size-checker">size checker</a> preset. Step 4: compare tool choice on <a href="/compare">compare tools</a> if output quality insufficient.</p>
            <h2>Record retention</h2>
            <p>Keep source PDF until recipient confirms receipt — derivatives disposable after successful upload — confidential docs deleted from Downloads on shared machines same day.</p>
            <h2>Monthly volume planning</h2>
            <p>Track daily tool usage in spreadsheet — forecast upgrade need before month-end crunch — finance approves <a href="/Subscription/Plans">subscription</a> when free tier blocks twice in one week.</p>
            <h2>Incident log template</h2>
            <p>Date, source filename, tool used, error message, resolution — patterns reveal training gaps — share quarterly with ops lead.</p>
            
            
            <h2>Quick reference card</h2>
            <p>Scan → OCR → Edit. Digital → Edit direct. Reorder → Merge queue. One page → Split. Logo → Add image. Forms → Fill then print-test. Archive master before any derivative edit.</p>
            <p>Bookmark <a href="/guides/edit-pdf">edit PDF guide</a> for team onboarding — reduces wrong-tool support tickets.</p>
            <p>Wrong page order voids visa bundles — verify thumbnail strip before merge submit.</p>
            
            
            <h2>Related edit &amp; organize guides</h2>
            <ul>
            <li><a href="/guides/edit-scanned-pdf">Edit scanned PDF</a></li>
            <li><a href="/guides/organize-pdf-pages">Organize PDF pages</a></li>
            <li><a href="/guides/split-pdf-page-range">Split by page range</a></li>
            <li><a href="/guides/add-image-to-pdf">Add image to PDF</a></li>
            </ul>
            
            
            <h2>Edit-gap guides</h2>
            <ul>
            <li><a href="/guides/crop-pdf-online">Crop PDF online</a> · <a href="/guides/crop-pdf-without-adobe">Crop without Adobe</a></li>
            <li><a href="/guides/delete-pages-from-pdf">Delete pages</a> · <a href="/guides/remove-blank-pages-pdf">Remove blank pages</a></li>
            <li><a href="/guides/annotate-pdf-online">Annotate online</a> · <a href="/guides/annotate-pdf-free">Annotate free</a></li>
            <li><a href="/guides/highlight-pdf-online">Highlight PDF</a> · <a href="/guides/edit-pdf-text-online">Edit text</a></li>
            <li><a href="/guides/add-text-to-pdf">Add text</a> · <a href="/guides/fill-pdf-form-online">Fill form</a></li>
            <li><a href="/guides/rearrange-pdf-pages">Rearrange pages</a> · <a href="/guides/edit-pdf-without-acrobat">Without Acrobat</a></li>
            <li><a href="/guides/edit-pdf-on-mac">Edit on Mac</a> · <a href="/guides/edit-pdf-on-windows">Windows</a> · <a href="/guides/edit-pdf-on-iphone">iPhone</a></li>
            </ul>
            <h2>Pillar and organize links</h2>
            <p><a href="/guides/edit-pdf">Edit PDF guide</a> · <a href="/guides/rotate-pdf">Rotate PDF</a> · <a href="/guides/organize-pdf-pages">Organize pages</a> · <a href="/guides/merge-pdf">Merge guide</a> · <a href="/guides/split-pdf">Split guide</a> · <a href="/guides/ocr-pdf">OCR guide</a>.</p>
            
            
            <h2>Enterprise document workflows</h2>
            <p>Legal ops teams convert legacy contract PDFs during CLM migration — batch convert critical folders, prioritise active vendor agreements first. IT should approve browser upload policy for confidential docs.</p>

            <h2>Education sector</h2>
            <p>Faculty edit syllabus PDFs each semester — digital university PDFs convert cleanly; scanned course packs need OCR. Check campus IT data handling before upload.</p>

            <h2>Real estate</h2>
            <p>Lease amendments stored as PDF — convert to Word for redline, re-PDF for signature. Keep executed scan archived separately from working DOCX.</p>

            <h2>HR and offer letters</h2>
            <p>Template offer PDFs with merge fields sometimes break on convert — edit boilerplate in Word template instead of converting each hire if HRIS exports PDF.</p>

            <h2>Government RFP responses</h2>
            <p>Final submissions often must be PDF — use Word only for draft edits, export via <a href="/pdf/doctopdf">Word to PDF</a> for portal upload. Check RFP forbids track changes in submission.</p>

            <h2>Quality gates before client delivery</h2>
            <ol>
            <li>Spell-check in Word</li>
            <li>Compare page count vs source PDF</li>
            <li>Verify critical numbers (dates, amounts) unchanged</li>
            <li>Remove comments and track changes</li>
            <li>Export final PDF if deliverable format is PDF</li>
            </ol>

            <p>Pillar: <a href="/guides/pdf-to-word">PDF to Word guide</a> · Compare: <a href="/compare/smallpdf-alternative">Smallpdf alternative</a></p>
            
            
            <h2>Batch conversion hygiene</h2>
            <p>Converting 20 contracts? Use consistent naming <code>ClientName-contract-v1.docx</code>. Log source PDF hash if legal audit trail required.</p>

            <h2>Mobile upload caveats</h2>
            <p>Phone browsers work but large PDFs may timeout on cellular — use Wi-Fi or desktop for 50+ MB files.</p>

            <h2>Antivirus false positives</h2>
            <p>Some corporate proxies scan uploads — if blocked, try guest network or contact IT to allowlist ratpdf.com tool path.</p>

            <h2>Long-term archival</h2>
            <p>Store both source PDF and final DOCX/PDF pair — migrations sometimes need to re-edit decade-old contracts.</p>

            <h2>Regulatory and compliance edits</h2>
            <p>Privacy policies, SOC2 reports, and vendor security questionnaires arrive as PDF — convert to Word for comment, return PDF via <a href="/pdf/doctopdf">Word to PDF</a>. Legal should review material compliance wording changes.</p>

            <h2>Performance expectations</h2>
            <p>10-page digital PDF typically converts under two minutes; 200-page annual report may take longer — do not close tab during processing. Refresh only after timeout message.</p>
            
            
            <h2>Document type quick reference</h2>
            <p><strong>Contracts:</strong> digital PDF, track changes in Word. <strong>Invoices:</strong> table-heavy — check sums. <strong>Scanned forms:</strong> OCR first. <strong>Marketing PDFs:</strong> expect image blocks. <strong>Manuals:</strong> headings usually survive — update TOC in Word after edits.</p>
            <p>Upgrade for volume: <a href="/Subscription/Plans">subscription plans</a>. Pillar: <a href="/guides/pdf-to-word">PDF to Word</a>.</p>

            <h2>Stakeholder sign-off matrix</h2>
            <p>Legal reviews converted contracts; finance reviews invoice PDFs edited in Word; HR reviews offer letters. Route DOCX to the right reviewer before re-PDF. Version suffix in filename (<code>-legal-reviewed</code>) prevents accidental send of draft.</p>
            <p>After major edits, compress before email if DOCX re-export exceeds mailbox limits — see <a href="/research/pdf-compression-benchmark">PDF compression benchmark</a> for quality settings.</p>
            <p>Bookmark this page for your team's wiki — consistent PDF-to-Word steps reduce support tickets when onboarding new staff each quarter.</p>
            
            
            <h2>Failure messages</h2>
            <p><strong>Too large:</strong> compress or split. <strong>Invalid PDF:</strong> re-export source. <strong>Unreadable:</strong> re-scan don't only compress blur.</p>
            <h2>Archive discipline</h2>
            <p>Keep uncompressed master until upload or send succeeds — derivatives are disposable.</p>
            <h2>Compare tools</h2>
            <p><a href="/compare/smallpdf-alternative">Smallpdf</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/adobe-alternative">Adobe</a>.</p>
            
            
            <h2>Related guides</h2>
            <p>Editing guides cover crop, delete, annotate, highlight, rearrange pages, add text, fill forms, device workflows, blank-page cleanup, and rotate — step-by-step help for each task.</p>
            <p>Next troubleshooting wave: corrupt PDF, won’t open, print errors — bookmark <a href="/guides/pdf-tools">PDF tools hub</a> for full map.</p>
            
            
            <h2>More guides</h2>
            <p>Image, PowerPoint, and Word conversion guides, plus editing tutorials and competitor comparisons — all in one place.</p>
            <p>Main guides: <a href="/guides/images-to-pdf">images</a> · <a href="/guides/pdf-to-word">PDF to Word</a> · <a href="/guides/split-pdf">split</a> · <a href="/compare">compare</a>.</p>
            <h2>Post-action checklist</h2>
            <ol><li>Output opens in Chrome PDF viewer</li><li>Page order matches intent</li><li>Text selects if downstream edit needed</li><li>File size under email/portal cap</li><li>Master archived before deleting source</li></ol>
            <p>Bookmark the <a href="/guides/pdf-tools">PDF tools guide</a> and <a href="/compare">compare tools</a> for team onboarding — consistent tool choice reduces wrong-output support tickets.</p>
            
            
            <h2>Post-action checklist</h2>
            <ol><li>Output file opens in viewer</li><li>Text selects if required</li><li>Size under portal/email preset</li><li>Master archived</li><li>Correct tool used for next step (text vs Word vs OCR)</li></ol>
            <p>Bookmark the <a href="/guides/pdf-tools">PDF tools guide</a> and <a href="/compare">compare tools</a> for team onboarding — consistent tool choice reduces wrong-output support tickets.</p>
            <p>Re-run size checker after every derivative step — compress, split, or text export — before deleting the previous version from your working folder.</p>
            
            <p class="mt-4"><a href="/pdf/rotateorremove" class="btn btn-primary">Rotate / Remove Pages</a> · <a href="/guides/edit-pdf">Edit PDF hub</a></p>
            """;

        private const string AnnotatePdfOnline = """
            <h2>Annotate PDF online — notes, stamps &amp; markup in browser</h2>
            <p>RatPDF <a href="/pdf/editpdf">Edit PDF</a> — Mark contract clause 4.2 for legal review before countersign.</p>
            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> Annotate PDF online — notes, stamps &amp; markup in browser</figcaption></figure>
            
            <h2>Annotation types in browser</h2>
            <p>Text boxes for notes, image stamps for APPROVED/REJECTED, freehand-style markup via overlay images. Not full collaborative comment threads — sufficient for SMB review cycles.</p>
            <h2>Review workflow</h2>
            <ol>
            <li>Upload contract PDF to <a href="/pdf/editpdf">Edit PDF</a>.</li>
            <li>Add margin note on clause in question — date stamp.</li>
            <li>Export <code>-annotated-v1.pdf</code> — email to counsel — keep clean master separate.</li>
            </ol>
            <h2>Flatten before court or portal</h2>
            <p>Some systems ignore floating layers — verify recipient sees notes — <a href="/guides/flatten-pdf">flatten PDF</a> if required.</p>
            
            
            <h2>Design review</h2>
            <p>Client PDF proof — annotate “move logo 2mm left” — designer edits source — not final art in PDF editor.</p>
            <h2>Board pack</h2>
            <p>Director notes on appendix C — annotated copy to secretary — clean PDF for official minutes archive.</p>
            
            <div class="rp-mid-cta alert alert-primary my-4"><strong>Start now</strong> <a href="/pdf/editpdf" class="alert-link fw-semibold">Edit PDF →</a></div>
            
            <h2>Edit vs convert vs OCR decision tree</h2>
            <p><strong>Digital PDF minor fix:</strong> Edit PDF text overlay. <strong>Heavy rewrite:</strong> PDF to Word. <strong>Scan:</strong> OCR first. <strong>Wrong page order:</strong> Organize via merge queue. <strong>One page pull:</strong> Split PDF.</p>
            <h2>Form filling landscape</h2>
            <p>Government PDFs mix fillable AcroForm fields and flat scans. Fillable fields preserve tab order — flat forms need positioned text boxes — print-test alignment before official submit.</p>
            <h2>Scanned document edit chain</h2>
            <ol>
            <li>Scan 300 DPI grayscale upright</li>
            <li><a href="/pdf/ocrpdf">OCR PDF</a> — verify Ctrl+F finds key term</li>
            <li><a href="/pdf/editpdf">Edit PDF</a> — add date, signature image, stamp</li>
            <li>Optional <a href="/guides/compress-pdf-for-email">compress</a> before portal upload</li>
            </ol>
            <h2>Organize without desktop Acrobat</h2>
            <p>Reorder pages in merge tool — drag queue — single merge output — same engine as <a href="/guides/merge-pdf-custom-order">custom order merge</a>. Delete pages by omitting from queue not destructive edit on source.</p>
            <h2>Image overlay best practices</h2>
            <p>Logo PNG with transparency — place top-right — do not cover existing signature block. DPI 150 sufficient for screen PDF — 300 for print-bound proposals.</p>
            <h2>Security and audit</h2>
            <p>Edited PDF is new derivative — keep unedited master for legal hold — filename suffix <code>-edited-2026-04-02</code>. Flatten annotations before court filing if local rules require.</p>
            
            
            <h2>Browser edit limitations</h2>
            <p>RatPDF edit covers common SMB needs — text add, image stamp, form fill — not InDesign prepress — not Photoshop pixel surgery. For marketing brochure pixel edits return to design source.</p>
            <h2>Mobile edit caution</h2>
            <p>Fine form alignment on phone is painful — desktop for government forms — mobile OK for initial and date on consent PDF.</p>
            <h2>Password-protected PDFs</h2>
            <p>Unlock first: <a href="/guides/unlock-pdf">unlock PDF</a> — edit fails on encrypted open.</p>
            <h2>Compare vendors</h2>
            <p><a href="/compare/adobe-alternative">Adobe</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/smallpdf-alternative">Smallpdf</a> — evaluate form-fill on your hardest government PDF sample.</p>
            <h2>Split and extract coordination</h2>
            <p>Extract signature page before sending for countersign — <a href="/guides/extract-single-page-pdf">extract single page</a> — merge back after scan with <a href="/pdf/merge">Merge PDF</a>.</p>
            <h2>QA print test</h2>
            <p>Government forms reject misaligned fields — print one copy — hold to light against blank form — adjust coordinates before batch.</p>
            
            
            <h2>Edit cluster authority map</h2>
            <p>Editing guides cover crop, delete, annotate, highlight, rearrange pages, and device workflows — plus in-depth help for <a href="/guides/edit-pdf">edit PDF</a> and <a href="/guides/rotate-pdf">rotate PDF</a>. See also merge, split, and OCR guides.</p>
            <h2>Security and compliance</h2>
            <p>Edited derivatives are new files — keep immutable master — log who edited — confidential docs cleared from Downloads on shared PCs same day. HIPAA and legal hold: counsel approves browser edit on PHI or privilege docs.</p>
            <h2>Failure triage</h2>
            <p><strong>Cannot select text:</strong> OCR first. <strong>Wrong page count after delete:</strong> off-by-one viewer index — recount. <strong>Portal rejects filled form:</strong> print-test alignment — font mismatch — try flatten. <strong>Upload timeout:</strong> Wi-Fi — compress — split.</p>
            <h2>Research links</h2>
            <p><a href="/research/attachment-size-limits">Email attachment limits</a> · <a href="/research/pdf-tool-market-comparison">PDF tool market comparison</a> · <a href="/compare">Compare hub</a>.</p>
            
            
            <h2>Workflow deep dive — Annotate PDF online — notes, stamps &amp; markup in browser</h2>
            <p>Browser workflow — no install — upload → process → download → verify in viewer before external send.</p>
            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> Annotate PDF online — notes, stamps &amp; markup in browser</figcaption></figure>
            <h2>Mobile</h2>
            <p>Safari/Chrome on phone works — Wi-Fi for files over 15 MB — save to Files before portal upload.</p>
            <h2>Failures</h2>
            <p>Timeout: retry Wi-Fi · corrupt PDF: re-export source · password: <a href="/guides/unlock-pdf">unlock</a>.</p>
            <h2>Free tier</h2>
            <p>Three uses/day — <a href="/Subscription/Plans">plans</a> for volume.</p>
            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Open tool</strong> <a href="/pdf/editpdf" class="alert-link fw-semibold">Go →</a></div>
            
            
            <h2>Real example: HR onboarding packet</h2>
            <p>Flat I-9 scan — OCR — add start date field — employee initials — merge with handbook acknowledgment — compress — upload to HRIS.</p>
            <h2>Second example: property manager lease initialed</h2>
            <p>Scan signed lease pages — add initialed watermark on page 4 rider — re-compress for email to tenant.</p>
            <h2>Third example: proposal logo</h2>
            <p>Sales exports proposal PDF from CRM — add partner logo top-left — send to client — no return to InDesign.</p>
            <h2>Discovery page pull</h2>
            <p>Counsel needs only exhibit G from 200-page production — split page range 142-148 — email to expert witness — index in cover note.</p>
            <h2>Medical admin form</h2>
            <p>Clinic scan intake form — OCR — nurse adds checkbox marks — print for patient sign — scan again for chart.</p>
            <h2>Upgrade path</h2>
            <p>High-volume form shop — <a href="/Subscription/Plans">plans</a> — see the <a href="/guides/edit-pdf">edit PDF hub</a>.</p>
            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Edit your PDF</strong> <a href="/pdf/editpdf" class="alert-link fw-semibold">Edit PDF →</a></div>
            
            
            
            <h2>Browser vs desktop</h2>
            <p>RatPDF needs no install — IT-friendly — confidential docs review privacy policy retention window.</p>
            <h2>Chain tools</h2>
            <p>Convert → edit → compress → merge — pick order by deliverable — see the <a href="/guides/pdf-tools">PDF tools hub</a>.</p>
            <h2>Upgrade</h2>
            <p><a href="/Subscription/Plans">subscription plans</a> for daily caps on agency volume.</p>
            
            
            <h2>Cross-wave tool chain</h2>
            <p>Pick tool order by what you need to deliver. Example: photos → images PDF → OCR → edit date → compress → portal upload.</p>
            <h2>Free tier and upgrade</h2>
            <p>Three uses per day per tool on free tier — agency month-end exceeds cap — <a href="/Subscription/Plans">subscription plans</a> — predictable vs per-file credit packs.</p>
            <h2>Internal link discipline</h2>
            <p>Each guide links to related tools and comparisons so your team picks the right workflow.</p>
            <h2>Support triage</h2>
            <p>Wrong tool order causes bad output — OCR before edit on scans — compress after merge not before each file — train your team using the main tool guides.</p>
            
            
            <h2>QA before send</h2>
            <ol><li>Page count correct</li><li>Text selects if required</li><li>Images sharp at 150% zoom</li><li>File opens in Chrome PDF viewer</li><li>Size under email/portal cap</li></ol>
            <h2>Compare vendors</h2>
            <p><a href="/compare/smallpdf-alternative">Smallpdf</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/adobe-alternative">Adobe</a>.</p>
            
            
            <h2>Device matrix</h2>
            <p>Windows Edge, Mac Safari, iPhone Safari, Android Chrome — same account — no sync required — download to device storage before portal upload.</p>
            <h2>Retention hygiene</h2>
            <p>Clear Downloads on shared PC — contracts and medical admin PDFs are confidential — delete derivatives when task completes.</p>
            <h2>Filename and version control</h2>
            <p><code>Client-Doc-v2-edited.pdf</code> — never overwrite sent attachment — email thread references version.</p>
            <h2>Portal rejection loop</h2>
            <p>Reject → check size with <a href="/pdf-size-checker">size checker</a> → compress Less → split if still over → re-upload before session timeout.</p>
            <h2>Research links</h2>
            <p><a href="/research/attachment-size-limits">Attachment size limits</a> · <a href="/research/pdf-compression-benchmark">Compression benchmark</a> · <a href="/research/freelancer-invoicing-statistics">Invoicing statistics</a>.</p>
            <h2>Pillar bookmark set</h2>
            <p><a href="/guides/pdf-tools">PDF tools hub</a> · <a href="/guides/images-to-pdf">Images to PDF</a> · <a href="/guides/pdf-to-word">PDF to Word</a> · <a href="/guides/split-pdf">Split PDF</a> · <a href="/compare">Compare hub</a>.</p>
            
            
            <h2>Edit audit log</h2>
            <p>Log who edited which PDF derivative — timestamp — reason — matter number — supports litigation hold and SOX-style controls.</p>
            <h2>Flatten before external send</h2>
            <p>Some recipients see floating annotations differently — flatten or re-export PDF so logo and text boxes appear identical on all viewers.</p>
            <h2>Redaction before edit</h2>
            <p>Remove SSN and account numbers with <a href="/guides/pdf-redaction-permanent">permanent redaction</a> before adding new text — edit tool does not replace redaction workflow.</p>
            <h2>Training slide for staff</h2>
            <p>Three rules poster: OCR scans first — organize before merge — compress after combine — pin in Slack onboarding channel.</p>
            <h2>Department-specific examples</h2>
            <p><strong>HR:</strong> I-9 and handbook ack merge. <strong>Sales:</strong> logo on proposal. <strong>Legal:</strong> exhibit extract. <strong>Finance:</strong> initialed tax form. <strong>Ops:</strong> delivery note stamp.</p>
            <h2>Version rollback</h2>
            <p>Keep pre-edit master immutable — if client rejects edit — resend from master not undo in editor — filename version increments.</p>
            <h2>Collaboration handoff</h2>
            <p>Paralegal extracts page — attorney reviews in isolation — merge signed scan back — document handoff in matter management ticket.</p>
            <h2>Accessibility after edit</h2>
            <p>Added text may not be tagged — government accessibility filing may need tagged PDF specialist — SMB email deliverable usually exempt.</p>
            <h2>Pillar cross-links</h2>
            <p><a href="/guides/merge-pdf-online">merge PDF</a> · <a href="/guides/ocr-pdf">OCR PDF</a> · <a href="/guides/split-pdf">split hub</a> · <a href="/guides/pdf-tools">PDF tools hub</a>.</p>
            
            
            <h2>QA checklist — edit outputs</h2>
            <ol>
            <li>Page count matches intent after delete or rearrange</li>
            <li>Orientation correct on every page at thumbnail view</li>
            <li>Added text readable at 150% zoom and in print preview</li>
            <li>Annotations visible in Chrome PDF viewer and recipient test</li>
            <li>File size under email or portal cap — compress if needed</li>
            <li>Master archived before destructive delete</li>
            </ol>
            <h2>Department playbooks</h2>
            <p><strong>Legal:</strong> annotate review copy — master untouched. <strong>Finance:</strong> fill tax PDF — print-test. <strong>HR:</strong> OCR onboarding — merge ack. <strong>Sales:</strong> logo + date on proposal. <strong>Ops:</strong> delete blank feeder pages from scan batch.</p>
            <h2>Monthly volume</h2>
            <p>Track edit/remove jobs — exceed free tier twice in one week — finance approves <a href="/Subscription/Plans">subscription</a>.</p>
            <h2>Compare alternatives</h2>
            <p><a href="/compare/adobe-acrobat-alternative">Adobe Acrobat alternative</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/smallpdf-alternative">Smallpdf</a>.</p>
            
            
            <h2>Team rollout notes</h2>
            <p>Pin the main tool guides in your shared wiki — compress before portal, OCR before edit on scans, Word path only when ERP cannot reissue. New hires complete one sample file in first week using browser tools only — no desktop install ticket.</p>
            <h2>Support escalation path</h2>
            <p>Step 1: re-download output and open in Chrome viewer. Step 2: retry on Wi-Fi with smaller batch. Step 3: check <a href="/pdf-size-checker">size checker</a> preset. Step 4: compare tool choice on <a href="/compare">compare tools</a> if output quality insufficient.</p>
            <h2>Record retention</h2>
            <p>Keep source PDF until recipient confirms receipt — derivatives disposable after successful upload — confidential docs deleted from Downloads on shared machines same day.</p>
            <h2>Monthly volume planning</h2>
            <p>Track daily tool usage in spreadsheet — forecast upgrade need before month-end crunch — finance approves <a href="/Subscription/Plans">subscription</a> when free tier blocks twice in one week.</p>
            <h2>Incident log template</h2>
            <p>Date, source filename, tool used, error message, resolution — patterns reveal training gaps — share quarterly with ops lead.</p>
            
            
            <h2>Quick reference card</h2>
            <p>Scan → OCR → Edit. Digital → Edit direct. Reorder → Merge queue. One page → Split. Logo → Add image. Forms → Fill then print-test. Archive master before any derivative edit.</p>
            <p>Bookmark <a href="/guides/edit-pdf">edit PDF guide</a> for team onboarding — reduces wrong-tool support tickets.</p>
            <p>Wrong page order voids visa bundles — verify thumbnail strip before merge submit.</p>
            
            
            <h2>Related edit &amp; organize guides</h2>
            <ul>
            <li><a href="/guides/edit-scanned-pdf">Edit scanned PDF</a></li>
            <li><a href="/guides/organize-pdf-pages">Organize PDF pages</a></li>
            <li><a href="/guides/split-pdf-page-range">Split by page range</a></li>
            <li><a href="/guides/add-image-to-pdf">Add image to PDF</a></li>
            </ul>
            
            
            <h2>Edit-gap guides</h2>
            <ul>
            <li><a href="/guides/crop-pdf-online">Crop PDF online</a> · <a href="/guides/crop-pdf-without-adobe">Crop without Adobe</a></li>
            <li><a href="/guides/delete-pages-from-pdf">Delete pages</a> · <a href="/guides/remove-blank-pages-pdf">Remove blank pages</a></li>
            <li><a href="/guides/annotate-pdf-online">Annotate online</a> · <a href="/guides/annotate-pdf-free">Annotate free</a></li>
            <li><a href="/guides/highlight-pdf-online">Highlight PDF</a> · <a href="/guides/edit-pdf-text-online">Edit text</a></li>
            <li><a href="/guides/add-text-to-pdf">Add text</a> · <a href="/guides/fill-pdf-form-online">Fill form</a></li>
            <li><a href="/guides/rearrange-pdf-pages">Rearrange pages</a> · <a href="/guides/edit-pdf-without-acrobat">Without Acrobat</a></li>
            <li><a href="/guides/edit-pdf-on-mac">Edit on Mac</a> · <a href="/guides/edit-pdf-on-windows">Windows</a> · <a href="/guides/edit-pdf-on-iphone">iPhone</a></li>
            </ul>
            <h2>Pillar and organize links</h2>
            <p><a href="/guides/edit-pdf">Edit PDF guide</a> · <a href="/guides/rotate-pdf">Rotate PDF</a> · <a href="/guides/organize-pdf-pages">Organize pages</a> · <a href="/guides/merge-pdf">Merge guide</a> · <a href="/guides/split-pdf">Split guide</a> · <a href="/guides/ocr-pdf">OCR guide</a>.</p>
            
            
            <h2>Enterprise document workflows</h2>
            <p>Legal ops teams convert legacy contract PDFs during CLM migration — batch convert critical folders, prioritise active vendor agreements first. IT should approve browser upload policy for confidential docs.</p>

            <h2>Education sector</h2>
            <p>Faculty edit syllabus PDFs each semester — digital university PDFs convert cleanly; scanned course packs need OCR. Check campus IT data handling before upload.</p>

            <h2>Real estate</h2>
            <p>Lease amendments stored as PDF — convert to Word for redline, re-PDF for signature. Keep executed scan archived separately from working DOCX.</p>

            <h2>HR and offer letters</h2>
            <p>Template offer PDFs with merge fields sometimes break on convert — edit boilerplate in Word template instead of converting each hire if HRIS exports PDF.</p>

            <h2>Government RFP responses</h2>
            <p>Final submissions often must be PDF — use Word only for draft edits, export via <a href="/pdf/doctopdf">Word to PDF</a> for portal upload. Check RFP forbids track changes in submission.</p>

            <h2>Quality gates before client delivery</h2>
            <ol>
            <li>Spell-check in Word</li>
            <li>Compare page count vs source PDF</li>
            <li>Verify critical numbers (dates, amounts) unchanged</li>
            <li>Remove comments and track changes</li>
            <li>Export final PDF if deliverable format is PDF</li>
            </ol>

            <p>Pillar: <a href="/guides/pdf-to-word">PDF to Word guide</a> · Compare: <a href="/compare/smallpdf-alternative">Smallpdf alternative</a></p>
            
            
            <h2>Batch conversion hygiene</h2>
            <p>Converting 20 contracts? Use consistent naming <code>ClientName-contract-v1.docx</code>. Log source PDF hash if legal audit trail required.</p>

            <h2>Mobile upload caveats</h2>
            <p>Phone browsers work but large PDFs may timeout on cellular — use Wi-Fi or desktop for 50+ MB files.</p>

            <h2>Antivirus false positives</h2>
            <p>Some corporate proxies scan uploads — if blocked, try guest network or contact IT to allowlist ratpdf.com tool path.</p>

            <h2>Long-term archival</h2>
            <p>Store both source PDF and final DOCX/PDF pair — migrations sometimes need to re-edit decade-old contracts.</p>

            <h2>Regulatory and compliance edits</h2>
            <p>Privacy policies, SOC2 reports, and vendor security questionnaires arrive as PDF — convert to Word for comment, return PDF via <a href="/pdf/doctopdf">Word to PDF</a>. Legal should review material compliance wording changes.</p>

            <h2>Performance expectations</h2>
            <p>10-page digital PDF typically converts under two minutes; 200-page annual report may take longer — do not close tab during processing. Refresh only after timeout message.</p>
            
            
            <h2>Document type quick reference</h2>
            <p><strong>Contracts:</strong> digital PDF, track changes in Word. <strong>Invoices:</strong> table-heavy — check sums. <strong>Scanned forms:</strong> OCR first. <strong>Marketing PDFs:</strong> expect image blocks. <strong>Manuals:</strong> headings usually survive — update TOC in Word after edits.</p>
            <p>Upgrade for volume: <a href="/Subscription/Plans">subscription plans</a>. Pillar: <a href="/guides/pdf-to-word">PDF to Word</a>.</p>

            <h2>Stakeholder sign-off matrix</h2>
            <p>Legal reviews converted contracts; finance reviews invoice PDFs edited in Word; HR reviews offer letters. Route DOCX to the right reviewer before re-PDF. Version suffix in filename (<code>-legal-reviewed</code>) prevents accidental send of draft.</p>
            <p>After major edits, compress before email if DOCX re-export exceeds mailbox limits — see <a href="/research/pdf-compression-benchmark">PDF compression benchmark</a> for quality settings.</p>
            <p>Bookmark this page for your team's wiki — consistent PDF-to-Word steps reduce support tickets when onboarding new staff each quarter.</p>
            
            
            <h2>Failure messages</h2>
            <p><strong>Too large:</strong> compress or split. <strong>Invalid PDF:</strong> re-export source. <strong>Unreadable:</strong> re-scan don't only compress blur.</p>
            <h2>Archive discipline</h2>
            <p>Keep uncompressed master until upload or send succeeds — derivatives are disposable.</p>
            <h2>Compare tools</h2>
            <p><a href="/compare/smallpdf-alternative">Smallpdf</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/adobe-alternative">Adobe</a>.</p>
            
            
            <h2>Related guides</h2>
            <p>Editing guides cover crop, delete, annotate, highlight, rearrange pages, add text, fill forms, device workflows, blank-page cleanup, and rotate — step-by-step help for each task.</p>
            <p>Next troubleshooting wave: corrupt PDF, won’t open, print errors — bookmark <a href="/guides/pdf-tools">PDF tools hub</a> for full map.</p>
            
            
            <h2>More guides</h2>
            <p>Image, PowerPoint, and Word conversion guides, plus editing tutorials and competitor comparisons — all in one place.</p>
            <p>Main guides: <a href="/guides/images-to-pdf">images</a> · <a href="/guides/pdf-to-word">PDF to Word</a> · <a href="/guides/split-pdf">split</a> · <a href="/compare">compare</a>.</p>
            <h2>Post-action checklist</h2>
            <ol><li>Output opens in Chrome PDF viewer</li><li>Page order matches intent</li><li>Text selects if downstream edit needed</li><li>File size under email/portal cap</li><li>Master archived before deleting source</li></ol>
            <p>Bookmark the <a href="/guides/pdf-tools">PDF tools guide</a> and <a href="/compare">compare tools</a> for team onboarding — consistent tool choice reduces wrong-output support tickets.</p>
            
            
            <h2>Post-action checklist</h2>
            <ol><li>Output file opens in viewer</li><li>Text selects if required</li><li>Size under portal/email preset</li><li>Master archived</li><li>Correct tool used for next step (text vs Word vs OCR)</li></ol>
            <p>Bookmark the <a href="/guides/pdf-tools">PDF tools guide</a> and <a href="/compare">compare tools</a> for team onboarding — consistent tool choice reduces wrong-output support tickets.</p>
            <p>Re-run size checker after every derivative step — compress, split, or text export — before deleting the previous version from your working folder.</p>
            
            <p class="mt-4"><a href="/pdf/editpdf" class="btn btn-primary">Edit PDF</a> · <a href="/guides/edit-pdf">Edit PDF hub</a></p>
            """;

        private const string AnnotatePdfFree = """
            <h2>Annotate PDF free — browser markup without subscription</h2>
            <p>RatPDF <a href="/pdf/editpdf">Edit PDF</a> — Student highlights readings and adds margin notes for study group.</p>
            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> Annotate PDF free — browser markup without subscription</figcaption></figure>
            
            <h2>Free tier limits</h2>
            <p>Three uses per tool per day on free tier — batch annotate board pack pages in one session — <a href="/Subscription/Plans">plans</a> for daily volume.</p>
            <h2>Student and nonprofit use</h2>
            <p>Highlight readings — share annotated PDF with study group — respect copyright on course packs.</p>
            <h2>Privacy</h2>
            <p>Review <a href="/home/privacy">privacy policy</a> before uploading client contracts — auto-delete after processing.</p>
            
            
            <h2>Teacher feedback</h2>
            <p>Essay PDF returned with margin comments — student opens on Chromebook — no software purchase.</p>
            <h2>Volunteer NGO</h2>
            <p>Grant PDF markup — free tier sufficient for monthly review cycle.</p>
            
            <div class="rp-mid-cta alert alert-primary my-4"><strong>Start now</strong> <a href="/pdf/editpdf" class="alert-link fw-semibold">Edit PDF →</a></div>
            
            <h2>Edit vs convert vs OCR decision tree</h2>
            <p><strong>Digital PDF minor fix:</strong> Edit PDF text overlay. <strong>Heavy rewrite:</strong> PDF to Word. <strong>Scan:</strong> OCR first. <strong>Wrong page order:</strong> Organize via merge queue. <strong>One page pull:</strong> Split PDF.</p>
            <h2>Form filling landscape</h2>
            <p>Government PDFs mix fillable AcroForm fields and flat scans. Fillable fields preserve tab order — flat forms need positioned text boxes — print-test alignment before official submit.</p>
            <h2>Scanned document edit chain</h2>
            <ol>
            <li>Scan 300 DPI grayscale upright</li>
            <li><a href="/pdf/ocrpdf">OCR PDF</a> — verify Ctrl+F finds key term</li>
            <li><a href="/pdf/editpdf">Edit PDF</a> — add date, signature image, stamp</li>
            <li>Optional <a href="/guides/compress-pdf-for-email">compress</a> before portal upload</li>
            </ol>
            <h2>Organize without desktop Acrobat</h2>
            <p>Reorder pages in merge tool — drag queue — single merge output — same engine as <a href="/guides/merge-pdf-custom-order">custom order merge</a>. Delete pages by omitting from queue not destructive edit on source.</p>
            <h2>Image overlay best practices</h2>
            <p>Logo PNG with transparency — place top-right — do not cover existing signature block. DPI 150 sufficient for screen PDF — 300 for print-bound proposals.</p>
            <h2>Security and audit</h2>
            <p>Edited PDF is new derivative — keep unedited master for legal hold — filename suffix <code>-edited-2026-04-02</code>. Flatten annotations before court filing if local rules require.</p>
            
            
            <h2>Browser edit limitations</h2>
            <p>RatPDF edit covers common SMB needs — text add, image stamp, form fill — not InDesign prepress — not Photoshop pixel surgery. For marketing brochure pixel edits return to design source.</p>
            <h2>Mobile edit caution</h2>
            <p>Fine form alignment on phone is painful — desktop for government forms — mobile OK for initial and date on consent PDF.</p>
            <h2>Password-protected PDFs</h2>
            <p>Unlock first: <a href="/guides/unlock-pdf">unlock PDF</a> — edit fails on encrypted open.</p>
            <h2>Compare vendors</h2>
            <p><a href="/compare/adobe-alternative">Adobe</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/smallpdf-alternative">Smallpdf</a> — evaluate form-fill on your hardest government PDF sample.</p>
            <h2>Split and extract coordination</h2>
            <p>Extract signature page before sending for countersign — <a href="/guides/extract-single-page-pdf">extract single page</a> — merge back after scan with <a href="/pdf/merge">Merge PDF</a>.</p>
            <h2>QA print test</h2>
            <p>Government forms reject misaligned fields — print one copy — hold to light against blank form — adjust coordinates before batch.</p>
            
            
            <h2>Edit cluster authority map</h2>
            <p>Editing guides cover crop, delete, annotate, highlight, rearrange pages, and device workflows — plus in-depth help for <a href="/guides/edit-pdf">edit PDF</a> and <a href="/guides/rotate-pdf">rotate PDF</a>. See also merge, split, and OCR guides.</p>
            <h2>Security and compliance</h2>
            <p>Edited derivatives are new files — keep immutable master — log who edited — confidential docs cleared from Downloads on shared PCs same day. HIPAA and legal hold: counsel approves browser edit on PHI or privilege docs.</p>
            <h2>Failure triage</h2>
            <p><strong>Cannot select text:</strong> OCR first. <strong>Wrong page count after delete:</strong> off-by-one viewer index — recount. <strong>Portal rejects filled form:</strong> print-test alignment — font mismatch — try flatten. <strong>Upload timeout:</strong> Wi-Fi — compress — split.</p>
            <h2>Research links</h2>
            <p><a href="/research/attachment-size-limits">Email attachment limits</a> · <a href="/research/pdf-tool-market-comparison">PDF tool market comparison</a> · <a href="/compare">Compare hub</a>.</p>
            
            
            <h2>Workflow deep dive — Annotate PDF free — browser markup without subscription</h2>
            <p>Browser workflow — no install — upload → process → download → verify in viewer before external send.</p>
            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> Annotate PDF free — browser markup without subscription</figcaption></figure>
            <h2>Mobile</h2>
            <p>Safari/Chrome on phone works — Wi-Fi for files over 15 MB — save to Files before portal upload.</p>
            <h2>Failures</h2>
            <p>Timeout: retry Wi-Fi · corrupt PDF: re-export source · password: <a href="/guides/unlock-pdf">unlock</a>.</p>
            <h2>Free tier</h2>
            <p>Three uses/day — <a href="/Subscription/Plans">plans</a> for volume.</p>
            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Open tool</strong> <a href="/pdf/editpdf" class="alert-link fw-semibold">Go →</a></div>
            
            
            <h2>Real example: HR onboarding packet</h2>
            <p>Flat I-9 scan — OCR — add start date field — employee initials — merge with handbook acknowledgment — compress — upload to HRIS.</p>
            <h2>Second example: property manager lease initialed</h2>
            <p>Scan signed lease pages — add initialed watermark on page 4 rider — re-compress for email to tenant.</p>
            <h2>Third example: proposal logo</h2>
            <p>Sales exports proposal PDF from CRM — add partner logo top-left — send to client — no return to InDesign.</p>
            <h2>Discovery page pull</h2>
            <p>Counsel needs only exhibit G from 200-page production — split page range 142-148 — email to expert witness — index in cover note.</p>
            <h2>Medical admin form</h2>
            <p>Clinic scan intake form — OCR — nurse adds checkbox marks — print for patient sign — scan again for chart.</p>
            <h2>Upgrade path</h2>
            <p>High-volume form shop — <a href="/Subscription/Plans">plans</a> — see the <a href="/guides/edit-pdf">edit PDF hub</a>.</p>
            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Edit your PDF</strong> <a href="/pdf/editpdf" class="alert-link fw-semibold">Edit PDF →</a></div>
            
            
            
            <h2>Browser vs desktop</h2>
            <p>RatPDF needs no install — IT-friendly — confidential docs review privacy policy retention window.</p>
            <h2>Chain tools</h2>
            <p>Convert → edit → compress → merge — pick order by deliverable — see the <a href="/guides/pdf-tools">PDF tools hub</a>.</p>
            <h2>Upgrade</h2>
            <p><a href="/Subscription/Plans">subscription plans</a> for daily caps on agency volume.</p>
            
            
            <h2>Cross-wave tool chain</h2>
            <p>Pick tool order by what you need to deliver. Example: photos → images PDF → OCR → edit date → compress → portal upload.</p>
            <h2>Free tier and upgrade</h2>
            <p>Three uses per day per tool on free tier — agency month-end exceeds cap — <a href="/Subscription/Plans">subscription plans</a> — predictable vs per-file credit packs.</p>
            <h2>Internal link discipline</h2>
            <p>Each guide links to related tools and comparisons so your team picks the right workflow.</p>
            <h2>Support triage</h2>
            <p>Wrong tool order causes bad output — OCR before edit on scans — compress after merge not before each file — train your team using the main tool guides.</p>
            
            
            <h2>QA before send</h2>
            <ol><li>Page count correct</li><li>Text selects if required</li><li>Images sharp at 150% zoom</li><li>File opens in Chrome PDF viewer</li><li>Size under email/portal cap</li></ol>
            <h2>Compare vendors</h2>
            <p><a href="/compare/smallpdf-alternative">Smallpdf</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/adobe-alternative">Adobe</a>.</p>
            
            
            <h2>Device matrix</h2>
            <p>Windows Edge, Mac Safari, iPhone Safari, Android Chrome — same account — no sync required — download to device storage before portal upload.</p>
            <h2>Retention hygiene</h2>
            <p>Clear Downloads on shared PC — contracts and medical admin PDFs are confidential — delete derivatives when task completes.</p>
            <h2>Filename and version control</h2>
            <p><code>Client-Doc-v2-edited.pdf</code> — never overwrite sent attachment — email thread references version.</p>
            <h2>Portal rejection loop</h2>
            <p>Reject → check size with <a href="/pdf-size-checker">size checker</a> → compress Less → split if still over → re-upload before session timeout.</p>
            <h2>Research links</h2>
            <p><a href="/research/attachment-size-limits">Attachment size limits</a> · <a href="/research/pdf-compression-benchmark">Compression benchmark</a> · <a href="/research/freelancer-invoicing-statistics">Invoicing statistics</a>.</p>
            <h2>Pillar bookmark set</h2>
            <p><a href="/guides/pdf-tools">PDF tools hub</a> · <a href="/guides/images-to-pdf">Images to PDF</a> · <a href="/guides/pdf-to-word">PDF to Word</a> · <a href="/guides/split-pdf">Split PDF</a> · <a href="/compare">Compare hub</a>.</p>
            
            
            <h2>Edit audit log</h2>
            <p>Log who edited which PDF derivative — timestamp — reason — matter number — supports litigation hold and SOX-style controls.</p>
            <h2>Flatten before external send</h2>
            <p>Some recipients see floating annotations differently — flatten or re-export PDF so logo and text boxes appear identical on all viewers.</p>
            <h2>Redaction before edit</h2>
            <p>Remove SSN and account numbers with <a href="/guides/pdf-redaction-permanent">permanent redaction</a> before adding new text — edit tool does not replace redaction workflow.</p>
            <h2>Training slide for staff</h2>
            <p>Three rules poster: OCR scans first — organize before merge — compress after combine — pin in Slack onboarding channel.</p>
            <h2>Department-specific examples</h2>
            <p><strong>HR:</strong> I-9 and handbook ack merge. <strong>Sales:</strong> logo on proposal. <strong>Legal:</strong> exhibit extract. <strong>Finance:</strong> initialed tax form. <strong>Ops:</strong> delivery note stamp.</p>
            <h2>Version rollback</h2>
            <p>Keep pre-edit master immutable — if client rejects edit — resend from master not undo in editor — filename version increments.</p>
            <h2>Collaboration handoff</h2>
            <p>Paralegal extracts page — attorney reviews in isolation — merge signed scan back — document handoff in matter management ticket.</p>
            <h2>Accessibility after edit</h2>
            <p>Added text may not be tagged — government accessibility filing may need tagged PDF specialist — SMB email deliverable usually exempt.</p>
            <h2>Pillar cross-links</h2>
            <p><a href="/guides/merge-pdf-online">merge PDF</a> · <a href="/guides/ocr-pdf">OCR PDF</a> · <a href="/guides/split-pdf">split hub</a> · <a href="/guides/pdf-tools">PDF tools hub</a>.</p>
            
            
            <h2>QA checklist — edit outputs</h2>
            <ol>
            <li>Page count matches intent after delete or rearrange</li>
            <li>Orientation correct on every page at thumbnail view</li>
            <li>Added text readable at 150% zoom and in print preview</li>
            <li>Annotations visible in Chrome PDF viewer and recipient test</li>
            <li>File size under email or portal cap — compress if needed</li>
            <li>Master archived before destructive delete</li>
            </ol>
            <h2>Department playbooks</h2>
            <p><strong>Legal:</strong> annotate review copy — master untouched. <strong>Finance:</strong> fill tax PDF — print-test. <strong>HR:</strong> OCR onboarding — merge ack. <strong>Sales:</strong> logo + date on proposal. <strong>Ops:</strong> delete blank feeder pages from scan batch.</p>
            <h2>Monthly volume</h2>
            <p>Track edit/remove jobs — exceed free tier twice in one week — finance approves <a href="/Subscription/Plans">subscription</a>.</p>
            <h2>Compare alternatives</h2>
            <p><a href="/compare/adobe-acrobat-alternative">Adobe Acrobat alternative</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/smallpdf-alternative">Smallpdf</a>.</p>
            
            
            <h2>Team rollout notes</h2>
            <p>Pin the main tool guides in your shared wiki — compress before portal, OCR before edit on scans, Word path only when ERP cannot reissue. New hires complete one sample file in first week using browser tools only — no desktop install ticket.</p>
            <h2>Support escalation path</h2>
            <p>Step 1: re-download output and open in Chrome viewer. Step 2: retry on Wi-Fi with smaller batch. Step 3: check <a href="/pdf-size-checker">size checker</a> preset. Step 4: compare tool choice on <a href="/compare">compare tools</a> if output quality insufficient.</p>
            <h2>Record retention</h2>
            <p>Keep source PDF until recipient confirms receipt — derivatives disposable after successful upload — confidential docs deleted from Downloads on shared machines same day.</p>
            <h2>Monthly volume planning</h2>
            <p>Track daily tool usage in spreadsheet — forecast upgrade need before month-end crunch — finance approves <a href="/Subscription/Plans">subscription</a> when free tier blocks twice in one week.</p>
            <h2>Incident log template</h2>
            <p>Date, source filename, tool used, error message, resolution — patterns reveal training gaps — share quarterly with ops lead.</p>
            
            
            <h2>Quick reference card</h2>
            <p>Scan → OCR → Edit. Digital → Edit direct. Reorder → Merge queue. One page → Split. Logo → Add image. Forms → Fill then print-test. Archive master before any derivative edit.</p>
            <p>Bookmark <a href="/guides/edit-pdf">edit PDF guide</a> for team onboarding — reduces wrong-tool support tickets.</p>
            <p>Wrong page order voids visa bundles — verify thumbnail strip before merge submit.</p>
            
            
            <h2>Related edit &amp; organize guides</h2>
            <ul>
            <li><a href="/guides/edit-scanned-pdf">Edit scanned PDF</a></li>
            <li><a href="/guides/organize-pdf-pages">Organize PDF pages</a></li>
            <li><a href="/guides/split-pdf-page-range">Split by page range</a></li>
            <li><a href="/guides/add-image-to-pdf">Add image to PDF</a></li>
            </ul>
            
            
            <h2>Edit-gap guides</h2>
            <ul>
            <li><a href="/guides/crop-pdf-online">Crop PDF online</a> · <a href="/guides/crop-pdf-without-adobe">Crop without Adobe</a></li>
            <li><a href="/guides/delete-pages-from-pdf">Delete pages</a> · <a href="/guides/remove-blank-pages-pdf">Remove blank pages</a></li>
            <li><a href="/guides/annotate-pdf-online">Annotate online</a> · <a href="/guides/annotate-pdf-free">Annotate free</a></li>
            <li><a href="/guides/highlight-pdf-online">Highlight PDF</a> · <a href="/guides/edit-pdf-text-online">Edit text</a></li>
            <li><a href="/guides/add-text-to-pdf">Add text</a> · <a href="/guides/fill-pdf-form-online">Fill form</a></li>
            <li><a href="/guides/rearrange-pdf-pages">Rearrange pages</a> · <a href="/guides/edit-pdf-without-acrobat">Without Acrobat</a></li>
            <li><a href="/guides/edit-pdf-on-mac">Edit on Mac</a> · <a href="/guides/edit-pdf-on-windows">Windows</a> · <a href="/guides/edit-pdf-on-iphone">iPhone</a></li>
            </ul>
            <h2>Pillar and organize links</h2>
            <p><a href="/guides/edit-pdf">Edit PDF guide</a> · <a href="/guides/rotate-pdf">Rotate PDF</a> · <a href="/guides/organize-pdf-pages">Organize pages</a> · <a href="/guides/merge-pdf">Merge guide</a> · <a href="/guides/split-pdf">Split guide</a> · <a href="/guides/ocr-pdf">OCR guide</a>.</p>
            
            
            <h2>Enterprise document workflows</h2>
            <p>Legal ops teams convert legacy contract PDFs during CLM migration — batch convert critical folders, prioritise active vendor agreements first. IT should approve browser upload policy for confidential docs.</p>

            <h2>Education sector</h2>
            <p>Faculty edit syllabus PDFs each semester — digital university PDFs convert cleanly; scanned course packs need OCR. Check campus IT data handling before upload.</p>

            <h2>Real estate</h2>
            <p>Lease amendments stored as PDF — convert to Word for redline, re-PDF for signature. Keep executed scan archived separately from working DOCX.</p>

            <h2>HR and offer letters</h2>
            <p>Template offer PDFs with merge fields sometimes break on convert — edit boilerplate in Word template instead of converting each hire if HRIS exports PDF.</p>

            <h2>Government RFP responses</h2>
            <p>Final submissions often must be PDF — use Word only for draft edits, export via <a href="/pdf/doctopdf">Word to PDF</a> for portal upload. Check RFP forbids track changes in submission.</p>

            <h2>Quality gates before client delivery</h2>
            <ol>
            <li>Spell-check in Word</li>
            <li>Compare page count vs source PDF</li>
            <li>Verify critical numbers (dates, amounts) unchanged</li>
            <li>Remove comments and track changes</li>
            <li>Export final PDF if deliverable format is PDF</li>
            </ol>

            <p>Pillar: <a href="/guides/pdf-to-word">PDF to Word guide</a> · Compare: <a href="/compare/smallpdf-alternative">Smallpdf alternative</a></p>
            
            
            <h2>Batch conversion hygiene</h2>
            <p>Converting 20 contracts? Use consistent naming <code>ClientName-contract-v1.docx</code>. Log source PDF hash if legal audit trail required.</p>

            <h2>Mobile upload caveats</h2>
            <p>Phone browsers work but large PDFs may timeout on cellular — use Wi-Fi or desktop for 50+ MB files.</p>

            <h2>Antivirus false positives</h2>
            <p>Some corporate proxies scan uploads — if blocked, try guest network or contact IT to allowlist ratpdf.com tool path.</p>

            <h2>Long-term archival</h2>
            <p>Store both source PDF and final DOCX/PDF pair — migrations sometimes need to re-edit decade-old contracts.</p>

            <h2>Regulatory and compliance edits</h2>
            <p>Privacy policies, SOC2 reports, and vendor security questionnaires arrive as PDF — convert to Word for comment, return PDF via <a href="/pdf/doctopdf">Word to PDF</a>. Legal should review material compliance wording changes.</p>

            <h2>Performance expectations</h2>
            <p>10-page digital PDF typically converts under two minutes; 200-page annual report may take longer — do not close tab during processing. Refresh only after timeout message.</p>
            
            
            <h2>Document type quick reference</h2>
            <p><strong>Contracts:</strong> digital PDF, track changes in Word. <strong>Invoices:</strong> table-heavy — check sums. <strong>Scanned forms:</strong> OCR first. <strong>Marketing PDFs:</strong> expect image blocks. <strong>Manuals:</strong> headings usually survive — update TOC in Word after edits.</p>
            <p>Upgrade for volume: <a href="/Subscription/Plans">subscription plans</a>. Pillar: <a href="/guides/pdf-to-word">PDF to Word</a>.</p>

            <h2>Stakeholder sign-off matrix</h2>
            <p>Legal reviews converted contracts; finance reviews invoice PDFs edited in Word; HR reviews offer letters. Route DOCX to the right reviewer before re-PDF. Version suffix in filename (<code>-legal-reviewed</code>) prevents accidental send of draft.</p>
            <p>After major edits, compress before email if DOCX re-export exceeds mailbox limits — see <a href="/research/pdf-compression-benchmark">PDF compression benchmark</a> for quality settings.</p>
            <p>Bookmark this page for your team's wiki — consistent PDF-to-Word steps reduce support tickets when onboarding new staff each quarter.</p>
            
            
            <h2>Failure messages</h2>
            <p><strong>Too large:</strong> compress or split. <strong>Invalid PDF:</strong> re-export source. <strong>Unreadable:</strong> re-scan don't only compress blur.</p>
            <h2>Archive discipline</h2>
            <p>Keep uncompressed master until upload or send succeeds — derivatives are disposable.</p>
            <h2>Compare tools</h2>
            <p><a href="/compare/smallpdf-alternative">Smallpdf</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/adobe-alternative">Adobe</a>.</p>
            
            
            <h2>Related guides</h2>
            <p>Editing guides cover crop, delete, annotate, highlight, rearrange pages, add text, fill forms, device workflows, blank-page cleanup, and rotate — step-by-step help for each task.</p>
            <p>Next troubleshooting wave: corrupt PDF, won’t open, print errors — bookmark <a href="/guides/pdf-tools">PDF tools hub</a> for full map.</p>
            
            
            <h2>More guides</h2>
            <p>Image, PowerPoint, and Word conversion guides, plus editing tutorials and competitor comparisons — all in one place.</p>
            <p>Main guides: <a href="/guides/images-to-pdf">images</a> · <a href="/guides/pdf-to-word">PDF to Word</a> · <a href="/guides/split-pdf">split</a> · <a href="/compare">compare</a>.</p>
            <h2>Post-action checklist</h2>
            <ol><li>Output opens in Chrome PDF viewer</li><li>Page order matches intent</li><li>Text selects if downstream edit needed</li><li>File size under email/portal cap</li><li>Master archived before deleting source</li></ol>
            <p>Bookmark the <a href="/guides/pdf-tools">PDF tools guide</a> and <a href="/compare">compare tools</a> for team onboarding — consistent tool choice reduces wrong-output support tickets.</p>
            
            
            <h2>Post-action checklist</h2>
            <ol><li>Output file opens in viewer</li><li>Text selects if required</li><li>Size under portal/email preset</li><li>Master archived</li><li>Correct tool used for next step (text vs Word vs OCR)</li></ol>
            <p>Bookmark the <a href="/guides/pdf-tools">PDF tools guide</a> and <a href="/compare">compare tools</a> for team onboarding — consistent tool choice reduces wrong-output support tickets.</p>
            <p>Re-run size checker after every derivative step — compress, split, or text export — before deleting the previous version from your working folder.</p>
            
            <p class="mt-4"><a href="/pdf/editpdf" class="btn btn-primary">Edit PDF</a> · <a href="/guides/edit-pdf">Edit PDF hub</a></p>
            """;

        private const string HighlightPdfOnline = """
            <h2>Highlight PDF online — emphasize text &amp; passages</h2>
            <p>RatPDF <a href="/pdf/editpdf">Edit PDF</a> — Highlight policy exceptions in 80-page vendor agreement.</p>
            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> Highlight PDF online — emphasize text &amp; passages</figcaption></figure>
            
            <h2>Highlight vs underline</h2>
            <p>True text highlight needs text layer — run <a href="/pdf/ocrpdf">OCR PDF</a> on scans first. Digital PDFs highlight via semi-transparent color boxes aligned to lines.</p>
            <h2>Long document strategy</h2>
            <p>80-page agreement — highlight only exception clauses — export summary email listing page numbers — do not highlight entire pages (bloats visual noise).</p>
            <h2>Accessibility note</h2>
            <p>Color-only highlight fails some accessibility audits — add text note beside highlight for government filings.</p>
            
            
            <h2>Legal due diligence</h2>
            <p>Highlight indemnity and limitation clauses — export list of page numbers in cover email to partner.</p>
            <h2>Insurance policy review</h2>
            <p>Highlight exclusion section — share with broker — OCR scan first if search needed.</p>
            
            <div class="rp-mid-cta alert alert-primary my-4"><strong>Start now</strong> <a href="/pdf/editpdf" class="alert-link fw-semibold">Edit PDF →</a></div>
            
            <h2>Edit vs convert vs OCR decision tree</h2>
            <p><strong>Digital PDF minor fix:</strong> Edit PDF text overlay. <strong>Heavy rewrite:</strong> PDF to Word. <strong>Scan:</strong> OCR first. <strong>Wrong page order:</strong> Organize via merge queue. <strong>One page pull:</strong> Split PDF.</p>
            <h2>Form filling landscape</h2>
            <p>Government PDFs mix fillable AcroForm fields and flat scans. Fillable fields preserve tab order — flat forms need positioned text boxes — print-test alignment before official submit.</p>
            <h2>Scanned document edit chain</h2>
            <ol>
            <li>Scan 300 DPI grayscale upright</li>
            <li><a href="/pdf/ocrpdf">OCR PDF</a> — verify Ctrl+F finds key term</li>
            <li><a href="/pdf/editpdf">Edit PDF</a> — add date, signature image, stamp</li>
            <li>Optional <a href="/guides/compress-pdf-for-email">compress</a> before portal upload</li>
            </ol>
            <h2>Organize without desktop Acrobat</h2>
            <p>Reorder pages in merge tool — drag queue — single merge output — same engine as <a href="/guides/merge-pdf-custom-order">custom order merge</a>. Delete pages by omitting from queue not destructive edit on source.</p>
            <h2>Image overlay best practices</h2>
            <p>Logo PNG with transparency — place top-right — do not cover existing signature block. DPI 150 sufficient for screen PDF — 300 for print-bound proposals.</p>
            <h2>Security and audit</h2>
            <p>Edited PDF is new derivative — keep unedited master for legal hold — filename suffix <code>-edited-2026-04-02</code>. Flatten annotations before court filing if local rules require.</p>
            
            
            <h2>Browser edit limitations</h2>
            <p>RatPDF edit covers common SMB needs — text add, image stamp, form fill — not InDesign prepress — not Photoshop pixel surgery. For marketing brochure pixel edits return to design source.</p>
            <h2>Mobile edit caution</h2>
            <p>Fine form alignment on phone is painful — desktop for government forms — mobile OK for initial and date on consent PDF.</p>
            <h2>Password-protected PDFs</h2>
            <p>Unlock first: <a href="/guides/unlock-pdf">unlock PDF</a> — edit fails on encrypted open.</p>
            <h2>Compare vendors</h2>
            <p><a href="/compare/adobe-alternative">Adobe</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/smallpdf-alternative">Smallpdf</a> — evaluate form-fill on your hardest government PDF sample.</p>
            <h2>Split and extract coordination</h2>
            <p>Extract signature page before sending for countersign — <a href="/guides/extract-single-page-pdf">extract single page</a> — merge back after scan with <a href="/pdf/merge">Merge PDF</a>.</p>
            <h2>QA print test</h2>
            <p>Government forms reject misaligned fields — print one copy — hold to light against blank form — adjust coordinates before batch.</p>
            
            
            <h2>Edit cluster authority map</h2>
            <p>Editing guides cover crop, delete, annotate, highlight, rearrange pages, and device workflows — plus in-depth help for <a href="/guides/edit-pdf">edit PDF</a> and <a href="/guides/rotate-pdf">rotate PDF</a>. See also merge, split, and OCR guides.</p>
            <h2>Security and compliance</h2>
            <p>Edited derivatives are new files — keep immutable master — log who edited — confidential docs cleared from Downloads on shared PCs same day. HIPAA and legal hold: counsel approves browser edit on PHI or privilege docs.</p>
            <h2>Failure triage</h2>
            <p><strong>Cannot select text:</strong> OCR first. <strong>Wrong page count after delete:</strong> off-by-one viewer index — recount. <strong>Portal rejects filled form:</strong> print-test alignment — font mismatch — try flatten. <strong>Upload timeout:</strong> Wi-Fi — compress — split.</p>
            <h2>Research links</h2>
            <p><a href="/research/attachment-size-limits">Email attachment limits</a> · <a href="/research/pdf-tool-market-comparison">PDF tool market comparison</a> · <a href="/compare">Compare hub</a>.</p>
            
            
            <h2>Workflow deep dive — Highlight PDF online — emphasize text &amp; passages</h2>
            <p>Browser workflow — no install — upload → process → download → verify in viewer before external send.</p>
            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> Highlight PDF online — emphasize text &amp; passages</figcaption></figure>
            <h2>Mobile</h2>
            <p>Safari/Chrome on phone works — Wi-Fi for files over 15 MB — save to Files before portal upload.</p>
            <h2>Failures</h2>
            <p>Timeout: retry Wi-Fi · corrupt PDF: re-export source · password: <a href="/guides/unlock-pdf">unlock</a>.</p>
            <h2>Free tier</h2>
            <p>Three uses/day — <a href="/Subscription/Plans">plans</a> for volume.</p>
            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Open tool</strong> <a href="/pdf/editpdf" class="alert-link fw-semibold">Go →</a></div>
            
            
            <h2>Real example: HR onboarding packet</h2>
            <p>Flat I-9 scan — OCR — add start date field — employee initials — merge with handbook acknowledgment — compress — upload to HRIS.</p>
            <h2>Second example: property manager lease initialed</h2>
            <p>Scan signed lease pages — add initialed watermark on page 4 rider — re-compress for email to tenant.</p>
            <h2>Third example: proposal logo</h2>
            <p>Sales exports proposal PDF from CRM — add partner logo top-left — send to client — no return to InDesign.</p>
            <h2>Discovery page pull</h2>
            <p>Counsel needs only exhibit G from 200-page production — split page range 142-148 — email to expert witness — index in cover note.</p>
            <h2>Medical admin form</h2>
            <p>Clinic scan intake form — OCR — nurse adds checkbox marks — print for patient sign — scan again for chart.</p>
            <h2>Upgrade path</h2>
            <p>High-volume form shop — <a href="/Subscription/Plans">plans</a> — see the <a href="/guides/edit-pdf">edit PDF hub</a>.</p>
            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Edit your PDF</strong> <a href="/pdf/editpdf" class="alert-link fw-semibold">Edit PDF →</a></div>
            
            
            
            <h2>Browser vs desktop</h2>
            <p>RatPDF needs no install — IT-friendly — confidential docs review privacy policy retention window.</p>
            <h2>Chain tools</h2>
            <p>Convert → edit → compress → merge — pick order by deliverable — see the <a href="/guides/pdf-tools">PDF tools hub</a>.</p>
            <h2>Upgrade</h2>
            <p><a href="/Subscription/Plans">subscription plans</a> for daily caps on agency volume.</p>
            
            
            <h2>Cross-wave tool chain</h2>
            <p>Pick tool order by what you need to deliver. Example: photos → images PDF → OCR → edit date → compress → portal upload.</p>
            <h2>Free tier and upgrade</h2>
            <p>Three uses per day per tool on free tier — agency month-end exceeds cap — <a href="/Subscription/Plans">subscription plans</a> — predictable vs per-file credit packs.</p>
            <h2>Internal link discipline</h2>
            <p>Each guide links to related tools and comparisons so your team picks the right workflow.</p>
            <h2>Support triage</h2>
            <p>Wrong tool order causes bad output — OCR before edit on scans — compress after merge not before each file — train your team using the main tool guides.</p>
            
            
            <h2>QA before send</h2>
            <ol><li>Page count correct</li><li>Text selects if required</li><li>Images sharp at 150% zoom</li><li>File opens in Chrome PDF viewer</li><li>Size under email/portal cap</li></ol>
            <h2>Compare vendors</h2>
            <p><a href="/compare/smallpdf-alternative">Smallpdf</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/adobe-alternative">Adobe</a>.</p>
            
            
            <h2>Device matrix</h2>
            <p>Windows Edge, Mac Safari, iPhone Safari, Android Chrome — same account — no sync required — download to device storage before portal upload.</p>
            <h2>Retention hygiene</h2>
            <p>Clear Downloads on shared PC — contracts and medical admin PDFs are confidential — delete derivatives when task completes.</p>
            <h2>Filename and version control</h2>
            <p><code>Client-Doc-v2-edited.pdf</code> — never overwrite sent attachment — email thread references version.</p>
            <h2>Portal rejection loop</h2>
            <p>Reject → check size with <a href="/pdf-size-checker">size checker</a> → compress Less → split if still over → re-upload before session timeout.</p>
            <h2>Research links</h2>
            <p><a href="/research/attachment-size-limits">Attachment size limits</a> · <a href="/research/pdf-compression-benchmark">Compression benchmark</a> · <a href="/research/freelancer-invoicing-statistics">Invoicing statistics</a>.</p>
            <h2>Pillar bookmark set</h2>
            <p><a href="/guides/pdf-tools">PDF tools hub</a> · <a href="/guides/images-to-pdf">Images to PDF</a> · <a href="/guides/pdf-to-word">PDF to Word</a> · <a href="/guides/split-pdf">Split PDF</a> · <a href="/compare">Compare hub</a>.</p>
            
            
            <h2>Edit audit log</h2>
            <p>Log who edited which PDF derivative — timestamp — reason — matter number — supports litigation hold and SOX-style controls.</p>
            <h2>Flatten before external send</h2>
            <p>Some recipients see floating annotations differently — flatten or re-export PDF so logo and text boxes appear identical on all viewers.</p>
            <h2>Redaction before edit</h2>
            <p>Remove SSN and account numbers with <a href="/guides/pdf-redaction-permanent">permanent redaction</a> before adding new text — edit tool does not replace redaction workflow.</p>
            <h2>Training slide for staff</h2>
            <p>Three rules poster: OCR scans first — organize before merge — compress after combine — pin in Slack onboarding channel.</p>
            <h2>Department-specific examples</h2>
            <p><strong>HR:</strong> I-9 and handbook ack merge. <strong>Sales:</strong> logo on proposal. <strong>Legal:</strong> exhibit extract. <strong>Finance:</strong> initialed tax form. <strong>Ops:</strong> delivery note stamp.</p>
            <h2>Version rollback</h2>
            <p>Keep pre-edit master immutable — if client rejects edit — resend from master not undo in editor — filename version increments.</p>
            <h2>Collaboration handoff</h2>
            <p>Paralegal extracts page — attorney reviews in isolation — merge signed scan back — document handoff in matter management ticket.</p>
            <h2>Accessibility after edit</h2>
            <p>Added text may not be tagged — government accessibility filing may need tagged PDF specialist — SMB email deliverable usually exempt.</p>
            <h2>Pillar cross-links</h2>
            <p><a href="/guides/merge-pdf-online">merge PDF</a> · <a href="/guides/ocr-pdf">OCR PDF</a> · <a href="/guides/split-pdf">split hub</a> · <a href="/guides/pdf-tools">PDF tools hub</a>.</p>
            
            
            <h2>QA checklist — edit outputs</h2>
            <ol>
            <li>Page count matches intent after delete or rearrange</li>
            <li>Orientation correct on every page at thumbnail view</li>
            <li>Added text readable at 150% zoom and in print preview</li>
            <li>Annotations visible in Chrome PDF viewer and recipient test</li>
            <li>File size under email or portal cap — compress if needed</li>
            <li>Master archived before destructive delete</li>
            </ol>
            <h2>Department playbooks</h2>
            <p><strong>Legal:</strong> annotate review copy — master untouched. <strong>Finance:</strong> fill tax PDF — print-test. <strong>HR:</strong> OCR onboarding — merge ack. <strong>Sales:</strong> logo + date on proposal. <strong>Ops:</strong> delete blank feeder pages from scan batch.</p>
            <h2>Monthly volume</h2>
            <p>Track edit/remove jobs — exceed free tier twice in one week — finance approves <a href="/Subscription/Plans">subscription</a>.</p>
            <h2>Compare alternatives</h2>
            <p><a href="/compare/adobe-acrobat-alternative">Adobe Acrobat alternative</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/smallpdf-alternative">Smallpdf</a>.</p>
            
            
            <h2>Team rollout notes</h2>
            <p>Pin the main tool guides in your shared wiki — compress before portal, OCR before edit on scans, Word path only when ERP cannot reissue. New hires complete one sample file in first week using browser tools only — no desktop install ticket.</p>
            <h2>Support escalation path</h2>
            <p>Step 1: re-download output and open in Chrome viewer. Step 2: retry on Wi-Fi with smaller batch. Step 3: check <a href="/pdf-size-checker">size checker</a> preset. Step 4: compare tool choice on <a href="/compare">compare tools</a> if output quality insufficient.</p>
            <h2>Record retention</h2>
            <p>Keep source PDF until recipient confirms receipt — derivatives disposable after successful upload — confidential docs deleted from Downloads on shared machines same day.</p>
            <h2>Monthly volume planning</h2>
            <p>Track daily tool usage in spreadsheet — forecast upgrade need before month-end crunch — finance approves <a href="/Subscription/Plans">subscription</a> when free tier blocks twice in one week.</p>
            <h2>Incident log template</h2>
            <p>Date, source filename, tool used, error message, resolution — patterns reveal training gaps — share quarterly with ops lead.</p>
            
            
            <h2>Quick reference card</h2>
            <p>Scan → OCR → Edit. Digital → Edit direct. Reorder → Merge queue. One page → Split. Logo → Add image. Forms → Fill then print-test. Archive master before any derivative edit.</p>
            <p>Bookmark <a href="/guides/edit-pdf">edit PDF guide</a> for team onboarding — reduces wrong-tool support tickets.</p>
            <p>Wrong page order voids visa bundles — verify thumbnail strip before merge submit.</p>
            
            
            <h2>Related edit &amp; organize guides</h2>
            <ul>
            <li><a href="/guides/edit-scanned-pdf">Edit scanned PDF</a></li>
            <li><a href="/guides/organize-pdf-pages">Organize PDF pages</a></li>
            <li><a href="/guides/split-pdf-page-range">Split by page range</a></li>
            <li><a href="/guides/add-image-to-pdf">Add image to PDF</a></li>
            </ul>
            
            
            <h2>Edit-gap guides</h2>
            <ul>
            <li><a href="/guides/crop-pdf-online">Crop PDF online</a> · <a href="/guides/crop-pdf-without-adobe">Crop without Adobe</a></li>
            <li><a href="/guides/delete-pages-from-pdf">Delete pages</a> · <a href="/guides/remove-blank-pages-pdf">Remove blank pages</a></li>
            <li><a href="/guides/annotate-pdf-online">Annotate online</a> · <a href="/guides/annotate-pdf-free">Annotate free</a></li>
            <li><a href="/guides/highlight-pdf-online">Highlight PDF</a> · <a href="/guides/edit-pdf-text-online">Edit text</a></li>
            <li><a href="/guides/add-text-to-pdf">Add text</a> · <a href="/guides/fill-pdf-form-online">Fill form</a></li>
            <li><a href="/guides/rearrange-pdf-pages">Rearrange pages</a> · <a href="/guides/edit-pdf-without-acrobat">Without Acrobat</a></li>
            <li><a href="/guides/edit-pdf-on-mac">Edit on Mac</a> · <a href="/guides/edit-pdf-on-windows">Windows</a> · <a href="/guides/edit-pdf-on-iphone">iPhone</a></li>
            </ul>
            <h2>Pillar and organize links</h2>
            <p><a href="/guides/edit-pdf">Edit PDF guide</a> · <a href="/guides/rotate-pdf">Rotate PDF</a> · <a href="/guides/organize-pdf-pages">Organize pages</a> · <a href="/guides/merge-pdf">Merge guide</a> · <a href="/guides/split-pdf">Split guide</a> · <a href="/guides/ocr-pdf">OCR guide</a>.</p>
            
            
            <h2>Enterprise document workflows</h2>
            <p>Legal ops teams convert legacy contract PDFs during CLM migration — batch convert critical folders, prioritise active vendor agreements first. IT should approve browser upload policy for confidential docs.</p>

            <h2>Education sector</h2>
            <p>Faculty edit syllabus PDFs each semester — digital university PDFs convert cleanly; scanned course packs need OCR. Check campus IT data handling before upload.</p>

            <h2>Real estate</h2>
            <p>Lease amendments stored as PDF — convert to Word for redline, re-PDF for signature. Keep executed scan archived separately from working DOCX.</p>

            <h2>HR and offer letters</h2>
            <p>Template offer PDFs with merge fields sometimes break on convert — edit boilerplate in Word template instead of converting each hire if HRIS exports PDF.</p>

            <h2>Government RFP responses</h2>
            <p>Final submissions often must be PDF — use Word only for draft edits, export via <a href="/pdf/doctopdf">Word to PDF</a> for portal upload. Check RFP forbids track changes in submission.</p>

            <h2>Quality gates before client delivery</h2>
            <ol>
            <li>Spell-check in Word</li>
            <li>Compare page count vs source PDF</li>
            <li>Verify critical numbers (dates, amounts) unchanged</li>
            <li>Remove comments and track changes</li>
            <li>Export final PDF if deliverable format is PDF</li>
            </ol>

            <p>Pillar: <a href="/guides/pdf-to-word">PDF to Word guide</a> · Compare: <a href="/compare/smallpdf-alternative">Smallpdf alternative</a></p>
            
            
            <h2>Batch conversion hygiene</h2>
            <p>Converting 20 contracts? Use consistent naming <code>ClientName-contract-v1.docx</code>. Log source PDF hash if legal audit trail required.</p>

            <h2>Mobile upload caveats</h2>
            <p>Phone browsers work but large PDFs may timeout on cellular — use Wi-Fi or desktop for 50+ MB files.</p>

            <h2>Antivirus false positives</h2>
            <p>Some corporate proxies scan uploads — if blocked, try guest network or contact IT to allowlist ratpdf.com tool path.</p>

            <h2>Long-term archival</h2>
            <p>Store both source PDF and final DOCX/PDF pair — migrations sometimes need to re-edit decade-old contracts.</p>

            <h2>Regulatory and compliance edits</h2>
            <p>Privacy policies, SOC2 reports, and vendor security questionnaires arrive as PDF — convert to Word for comment, return PDF via <a href="/pdf/doctopdf">Word to PDF</a>. Legal should review material compliance wording changes.</p>

            <h2>Performance expectations</h2>
            <p>10-page digital PDF typically converts under two minutes; 200-page annual report may take longer — do not close tab during processing. Refresh only after timeout message.</p>
            
            
            <h2>Document type quick reference</h2>
            <p><strong>Contracts:</strong> digital PDF, track changes in Word. <strong>Invoices:</strong> table-heavy — check sums. <strong>Scanned forms:</strong> OCR first. <strong>Marketing PDFs:</strong> expect image blocks. <strong>Manuals:</strong> headings usually survive — update TOC in Word after edits.</p>
            <p>Upgrade for volume: <a href="/Subscription/Plans">subscription plans</a>. Pillar: <a href="/guides/pdf-to-word">PDF to Word</a>.</p>

            <h2>Stakeholder sign-off matrix</h2>
            <p>Legal reviews converted contracts; finance reviews invoice PDFs edited in Word; HR reviews offer letters. Route DOCX to the right reviewer before re-PDF. Version suffix in filename (<code>-legal-reviewed</code>) prevents accidental send of draft.</p>
            <p>After major edits, compress before email if DOCX re-export exceeds mailbox limits — see <a href="/research/pdf-compression-benchmark">PDF compression benchmark</a> for quality settings.</p>
            <p>Bookmark this page for your team's wiki — consistent PDF-to-Word steps reduce support tickets when onboarding new staff each quarter.</p>
            
            
            <h2>Failure messages</h2>
            <p><strong>Too large:</strong> compress or split. <strong>Invalid PDF:</strong> re-export source. <strong>Unreadable:</strong> re-scan don't only compress blur.</p>
            <h2>Archive discipline</h2>
            <p>Keep uncompressed master until upload or send succeeds — derivatives are disposable.</p>
            <h2>Compare tools</h2>
            <p><a href="/compare/smallpdf-alternative">Smallpdf</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/adobe-alternative">Adobe</a>.</p>
            
            
            <h2>Related guides</h2>
            <p>Editing guides cover crop, delete, annotate, highlight, rearrange pages, add text, fill forms, device workflows, blank-page cleanup, and rotate — step-by-step help for each task.</p>
            <p>Next troubleshooting wave: corrupt PDF, won’t open, print errors — bookmark <a href="/guides/pdf-tools">PDF tools hub</a> for full map.</p>
            
            
            <h2>More guides</h2>
            <p>Image, PowerPoint, and Word conversion guides, plus editing tutorials and competitor comparisons — all in one place.</p>
            <p>Main guides: <a href="/guides/images-to-pdf">images</a> · <a href="/guides/pdf-to-word">PDF to Word</a> · <a href="/guides/split-pdf">split</a> · <a href="/compare">compare</a>.</p>
            <h2>Post-action checklist</h2>
            <ol><li>Output opens in Chrome PDF viewer</li><li>Page order matches intent</li><li>Text selects if downstream edit needed</li><li>File size under email/portal cap</li><li>Master archived before deleting source</li></ol>
            <p>Bookmark the <a href="/guides/pdf-tools">PDF tools guide</a> and <a href="/compare">compare tools</a> for team onboarding — consistent tool choice reduces wrong-output support tickets.</p>
            
            
            <h2>Post-action checklist</h2>
            <ol><li>Output file opens in viewer</li><li>Text selects if required</li><li>Size under portal/email preset</li><li>Master archived</li><li>Correct tool used for next step (text vs Word vs OCR)</li></ol>
            <p>Bookmark the <a href="/guides/pdf-tools">PDF tools guide</a> and <a href="/compare">compare tools</a> for team onboarding — consistent tool choice reduces wrong-output support tickets.</p>
            <p>Re-run size checker after every derivative step — compress, split, or text export — before deleting the previous version from your working folder.</p>
            
            <p class="mt-4"><a href="/pdf/editpdf" class="btn btn-primary">Edit PDF</a> · <a href="/guides/edit-pdf">Edit PDF hub</a></p>
            """;

        private const string RearrangePdfPages = """
            <h2>Rearrange PDF pages — reorder &amp; combine online</h2>
            <p>RatPDF <a href="/pdf/merge">Merge PDF</a> — Reorder visa annexures A–D before single-bundle upload.</p>
            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> Rearrange PDF pages — reorder &amp; combine online</figcaption></figure>
            
            <h2>Rearrange = merge queue discipline</h2>
            <p>Export each section as PDF or split first — upload to <a href="/pdf/merge">Merge PDF</a> in desired order — drag queue before merge — single output.</p>
            <h2>Visa and permit bundles</h2>
            <p>Officer expects checklist order — application, passport, employment, bank — wrong order delays review — thumbnail strip verification mandatory.</p>
            <h2>Related organize guides</h2>
            <p><a href="/guides/organize-pdf-pages">Organize PDF pages</a> · <a href="/guides/merge-pdf-custom-order">Custom order merge</a> · <a href="/guides/merge-pdf">Merge guide</a>.</p>
            
            
            <h2>Textbook custom syllabus</h2>
            <p>Instructor merges chapters 3, 1, 2 — one PDF for students — copyright policy applies.</p>
            <h2>Discovery production reorder</h2>
            <p>Chronological narrative — rearrange exhibits before merge — Bates after final order set.</p>
            
            <div class="rp-mid-cta alert alert-primary my-4"><strong>Start now</strong> <a href="/pdf/merge" class="alert-link fw-semibold">Merge PDF →</a></div>
            
            <h2>Edit vs convert vs OCR decision tree</h2>
            <p><strong>Digital PDF minor fix:</strong> Edit PDF text overlay. <strong>Heavy rewrite:</strong> PDF to Word. <strong>Scan:</strong> OCR first. <strong>Wrong page order:</strong> Organize via merge queue. <strong>One page pull:</strong> Split PDF.</p>
            <h2>Form filling landscape</h2>
            <p>Government PDFs mix fillable AcroForm fields and flat scans. Fillable fields preserve tab order — flat forms need positioned text boxes — print-test alignment before official submit.</p>
            <h2>Scanned document edit chain</h2>
            <ol>
            <li>Scan 300 DPI grayscale upright</li>
            <li><a href="/pdf/ocrpdf">OCR PDF</a> — verify Ctrl+F finds key term</li>
            <li><a href="/pdf/editpdf">Edit PDF</a> — add date, signature image, stamp</li>
            <li>Optional <a href="/guides/compress-pdf-for-email">compress</a> before portal upload</li>
            </ol>
            <h2>Organize without desktop Acrobat</h2>
            <p>Reorder pages in merge tool — drag queue — single merge output — same engine as <a href="/guides/merge-pdf-custom-order">custom order merge</a>. Delete pages by omitting from queue not destructive edit on source.</p>
            <h2>Image overlay best practices</h2>
            <p>Logo PNG with transparency — place top-right — do not cover existing signature block. DPI 150 sufficient for screen PDF — 300 for print-bound proposals.</p>
            <h2>Security and audit</h2>
            <p>Edited PDF is new derivative — keep unedited master for legal hold — filename suffix <code>-edited-2026-04-02</code>. Flatten annotations before court filing if local rules require.</p>
            
            
            <h2>Browser edit limitations</h2>
            <p>RatPDF edit covers common SMB needs — text add, image stamp, form fill — not InDesign prepress — not Photoshop pixel surgery. For marketing brochure pixel edits return to design source.</p>
            <h2>Mobile edit caution</h2>
            <p>Fine form alignment on phone is painful — desktop for government forms — mobile OK for initial and date on consent PDF.</p>
            <h2>Password-protected PDFs</h2>
            <p>Unlock first: <a href="/guides/unlock-pdf">unlock PDF</a> — edit fails on encrypted open.</p>
            <h2>Compare vendors</h2>
            <p><a href="/compare/adobe-alternative">Adobe</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/smallpdf-alternative">Smallpdf</a> — evaluate form-fill on your hardest government PDF sample.</p>
            <h2>Split and extract coordination</h2>
            <p>Extract signature page before sending for countersign — <a href="/guides/extract-single-page-pdf">extract single page</a> — merge back after scan with <a href="/pdf/merge">Merge PDF</a>.</p>
            <h2>QA print test</h2>
            <p>Government forms reject misaligned fields — print one copy — hold to light against blank form — adjust coordinates before batch.</p>
            
            
            <h2>Edit cluster authority map</h2>
            <p>Editing guides cover crop, delete, annotate, highlight, rearrange pages, and device workflows — plus in-depth help for <a href="/guides/edit-pdf">edit PDF</a> and <a href="/guides/rotate-pdf">rotate PDF</a>. See also merge, split, and OCR guides.</p>
            <h2>Security and compliance</h2>
            <p>Edited derivatives are new files — keep immutable master — log who edited — confidential docs cleared from Downloads on shared PCs same day. HIPAA and legal hold: counsel approves browser edit on PHI or privilege docs.</p>
            <h2>Failure triage</h2>
            <p><strong>Cannot select text:</strong> OCR first. <strong>Wrong page count after delete:</strong> off-by-one viewer index — recount. <strong>Portal rejects filled form:</strong> print-test alignment — font mismatch — try flatten. <strong>Upload timeout:</strong> Wi-Fi — compress — split.</p>
            <h2>Research links</h2>
            <p><a href="/research/attachment-size-limits">Email attachment limits</a> · <a href="/research/pdf-tool-market-comparison">PDF tool market comparison</a> · <a href="/compare">Compare hub</a>.</p>
            
            
            <h2>Workflow deep dive — Rearrange PDF pages — reorder &amp; combine online</h2>
            <p>Browser workflow — no install — upload → process → download → verify in viewer before external send.</p>
            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> Rearrange PDF pages — reorder &amp; combine online</figcaption></figure>
            <h2>Mobile</h2>
            <p>Safari/Chrome on phone works — Wi-Fi for files over 15 MB — save to Files before portal upload.</p>
            <h2>Failures</h2>
            <p>Timeout: retry Wi-Fi · corrupt PDF: re-export source · password: <a href="/guides/unlock-pdf">unlock</a>.</p>
            <h2>Free tier</h2>
            <p>Three uses/day — <a href="/Subscription/Plans">plans</a> for volume.</p>
            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Open tool</strong> <a href="/pdf/merge" class="alert-link fw-semibold">Go →</a></div>
            
            
            <h2>Real example: HR onboarding packet</h2>
            <p>Flat I-9 scan — OCR — add start date field — employee initials — merge with handbook acknowledgment — compress — upload to HRIS.</p>
            <h2>Second example: property manager lease initialed</h2>
            <p>Scan signed lease pages — add initialed watermark on page 4 rider — re-compress for email to tenant.</p>
            <h2>Third example: proposal logo</h2>
            <p>Sales exports proposal PDF from CRM — add partner logo top-left — send to client — no return to InDesign.</p>
            <h2>Discovery page pull</h2>
            <p>Counsel needs only exhibit G from 200-page production — split page range 142-148 — email to expert witness — index in cover note.</p>
            <h2>Medical admin form</h2>
            <p>Clinic scan intake form — OCR — nurse adds checkbox marks — print for patient sign — scan again for chart.</p>
            <h2>Upgrade path</h2>
            <p>High-volume form shop — <a href="/Subscription/Plans">plans</a> — see the <a href="/guides/edit-pdf">edit PDF hub</a>.</p>
            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Edit your PDF</strong> <a href="/pdf/editpdf" class="alert-link fw-semibold">Edit PDF →</a></div>
            
            
            
            <h2>Browser vs desktop</h2>
            <p>RatPDF needs no install — IT-friendly — confidential docs review privacy policy retention window.</p>
            <h2>Chain tools</h2>
            <p>Convert → edit → compress → merge — pick order by deliverable — see the <a href="/guides/pdf-tools">PDF tools hub</a>.</p>
            <h2>Upgrade</h2>
            <p><a href="/Subscription/Plans">subscription plans</a> for daily caps on agency volume.</p>
            
            
            <h2>Cross-wave tool chain</h2>
            <p>Pick tool order by what you need to deliver. Example: photos → images PDF → OCR → edit date → compress → portal upload.</p>
            <h2>Free tier and upgrade</h2>
            <p>Three uses per day per tool on free tier — agency month-end exceeds cap — <a href="/Subscription/Plans">subscription plans</a> — predictable vs per-file credit packs.</p>
            <h2>Internal link discipline</h2>
            <p>Each guide links to related tools and comparisons so your team picks the right workflow.</p>
            <h2>Support triage</h2>
            <p>Wrong tool order causes bad output — OCR before edit on scans — compress after merge not before each file — train your team using the main tool guides.</p>
            
            
            <h2>QA before send</h2>
            <ol><li>Page count correct</li><li>Text selects if required</li><li>Images sharp at 150% zoom</li><li>File opens in Chrome PDF viewer</li><li>Size under email/portal cap</li></ol>
            <h2>Compare vendors</h2>
            <p><a href="/compare/smallpdf-alternative">Smallpdf</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/adobe-alternative">Adobe</a>.</p>
            
            
            <h2>Device matrix</h2>
            <p>Windows Edge, Mac Safari, iPhone Safari, Android Chrome — same account — no sync required — download to device storage before portal upload.</p>
            <h2>Retention hygiene</h2>
            <p>Clear Downloads on shared PC — contracts and medical admin PDFs are confidential — delete derivatives when task completes.</p>
            <h2>Filename and version control</h2>
            <p><code>Client-Doc-v2-edited.pdf</code> — never overwrite sent attachment — email thread references version.</p>
            <h2>Portal rejection loop</h2>
            <p>Reject → check size with <a href="/pdf-size-checker">size checker</a> → compress Less → split if still over → re-upload before session timeout.</p>
            <h2>Research links</h2>
            <p><a href="/research/attachment-size-limits">Attachment size limits</a> · <a href="/research/pdf-compression-benchmark">Compression benchmark</a> · <a href="/research/freelancer-invoicing-statistics">Invoicing statistics</a>.</p>
            <h2>Pillar bookmark set</h2>
            <p><a href="/guides/pdf-tools">PDF tools hub</a> · <a href="/guides/images-to-pdf">Images to PDF</a> · <a href="/guides/pdf-to-word">PDF to Word</a> · <a href="/guides/split-pdf">Split PDF</a> · <a href="/compare">Compare hub</a>.</p>
            
            
            <h2>Edit audit log</h2>
            <p>Log who edited which PDF derivative — timestamp — reason — matter number — supports litigation hold and SOX-style controls.</p>
            <h2>Flatten before external send</h2>
            <p>Some recipients see floating annotations differently — flatten or re-export PDF so logo and text boxes appear identical on all viewers.</p>
            <h2>Redaction before edit</h2>
            <p>Remove SSN and account numbers with <a href="/guides/pdf-redaction-permanent">permanent redaction</a> before adding new text — edit tool does not replace redaction workflow.</p>
            <h2>Training slide for staff</h2>
            <p>Three rules poster: OCR scans first — organize before merge — compress after combine — pin in Slack onboarding channel.</p>
            <h2>Department-specific examples</h2>
            <p><strong>HR:</strong> I-9 and handbook ack merge. <strong>Sales:</strong> logo on proposal. <strong>Legal:</strong> exhibit extract. <strong>Finance:</strong> initialed tax form. <strong>Ops:</strong> delivery note stamp.</p>
            <h2>Version rollback</h2>
            <p>Keep pre-edit master immutable — if client rejects edit — resend from master not undo in editor — filename version increments.</p>
            <h2>Collaboration handoff</h2>
            <p>Paralegal extracts page — attorney reviews in isolation — merge signed scan back — document handoff in matter management ticket.</p>
            <h2>Accessibility after edit</h2>
            <p>Added text may not be tagged — government accessibility filing may need tagged PDF specialist — SMB email deliverable usually exempt.</p>
            <h2>Pillar cross-links</h2>
            <p><a href="/guides/merge-pdf-online">merge PDF</a> · <a href="/guides/ocr-pdf">OCR PDF</a> · <a href="/guides/split-pdf">split hub</a> · <a href="/guides/pdf-tools">PDF tools hub</a>.</p>
            
            
            <h2>QA checklist — edit outputs</h2>
            <ol>
            <li>Page count matches intent after delete or rearrange</li>
            <li>Orientation correct on every page at thumbnail view</li>
            <li>Added text readable at 150% zoom and in print preview</li>
            <li>Annotations visible in Chrome PDF viewer and recipient test</li>
            <li>File size under email or portal cap — compress if needed</li>
            <li>Master archived before destructive delete</li>
            </ol>
            <h2>Department playbooks</h2>
            <p><strong>Legal:</strong> annotate review copy — master untouched. <strong>Finance:</strong> fill tax PDF — print-test. <strong>HR:</strong> OCR onboarding — merge ack. <strong>Sales:</strong> logo + date on proposal. <strong>Ops:</strong> delete blank feeder pages from scan batch.</p>
            <h2>Monthly volume</h2>
            <p>Track edit/remove jobs — exceed free tier twice in one week — finance approves <a href="/Subscription/Plans">subscription</a>.</p>
            <h2>Compare alternatives</h2>
            <p><a href="/compare/adobe-acrobat-alternative">Adobe Acrobat alternative</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/smallpdf-alternative">Smallpdf</a>.</p>
            
            
            <h2>Team rollout notes</h2>
            <p>Pin the main tool guides in your shared wiki — compress before portal, OCR before edit on scans, Word path only when ERP cannot reissue. New hires complete one sample file in first week using browser tools only — no desktop install ticket.</p>
            <h2>Support escalation path</h2>
            <p>Step 1: re-download output and open in Chrome viewer. Step 2: retry on Wi-Fi with smaller batch. Step 3: check <a href="/pdf-size-checker">size checker</a> preset. Step 4: compare tool choice on <a href="/compare">compare tools</a> if output quality insufficient.</p>
            <h2>Record retention</h2>
            <p>Keep source PDF until recipient confirms receipt — derivatives disposable after successful upload — confidential docs deleted from Downloads on shared machines same day.</p>
            <h2>Monthly volume planning</h2>
            <p>Track daily tool usage in spreadsheet — forecast upgrade need before month-end crunch — finance approves <a href="/Subscription/Plans">subscription</a> when free tier blocks twice in one week.</p>
            <h2>Incident log template</h2>
            <p>Date, source filename, tool used, error message, resolution — patterns reveal training gaps — share quarterly with ops lead.</p>
            
            
            <h2>Quick reference card</h2>
            <p>Scan → OCR → Edit. Digital → Edit direct. Reorder → Merge queue. One page → Split. Logo → Add image. Forms → Fill then print-test. Archive master before any derivative edit.</p>
            <p>Bookmark <a href="/guides/edit-pdf">edit PDF guide</a> for team onboarding — reduces wrong-tool support tickets.</p>
            <p>Wrong page order voids visa bundles — verify thumbnail strip before merge submit.</p>
            
            
            <h2>Related edit &amp; organize guides</h2>
            <ul>
            <li><a href="/guides/edit-scanned-pdf">Edit scanned PDF</a></li>
            <li><a href="/guides/organize-pdf-pages">Organize PDF pages</a></li>
            <li><a href="/guides/split-pdf-page-range">Split by page range</a></li>
            <li><a href="/guides/add-image-to-pdf">Add image to PDF</a></li>
            </ul>
            
            
            <h2>Edit-gap guides</h2>
            <ul>
            <li><a href="/guides/crop-pdf-online">Crop PDF online</a> · <a href="/guides/crop-pdf-without-adobe">Crop without Adobe</a></li>
            <li><a href="/guides/delete-pages-from-pdf">Delete pages</a> · <a href="/guides/remove-blank-pages-pdf">Remove blank pages</a></li>
            <li><a href="/guides/annotate-pdf-online">Annotate online</a> · <a href="/guides/annotate-pdf-free">Annotate free</a></li>
            <li><a href="/guides/highlight-pdf-online">Highlight PDF</a> · <a href="/guides/edit-pdf-text-online">Edit text</a></li>
            <li><a href="/guides/add-text-to-pdf">Add text</a> · <a href="/guides/fill-pdf-form-online">Fill form</a></li>
            <li><a href="/guides/rearrange-pdf-pages">Rearrange pages</a> · <a href="/guides/edit-pdf-without-acrobat">Without Acrobat</a></li>
            <li><a href="/guides/edit-pdf-on-mac">Edit on Mac</a> · <a href="/guides/edit-pdf-on-windows">Windows</a> · <a href="/guides/edit-pdf-on-iphone">iPhone</a></li>
            </ul>
            <h2>Pillar and organize links</h2>
            <p><a href="/guides/edit-pdf">Edit PDF guide</a> · <a href="/guides/rotate-pdf">Rotate PDF</a> · <a href="/guides/organize-pdf-pages">Organize pages</a> · <a href="/guides/merge-pdf">Merge guide</a> · <a href="/guides/split-pdf">Split guide</a> · <a href="/guides/ocr-pdf">OCR guide</a>.</p>
            
            
            <h2>Enterprise document workflows</h2>
            <p>Legal ops teams convert legacy contract PDFs during CLM migration — batch convert critical folders, prioritise active vendor agreements first. IT should approve browser upload policy for confidential docs.</p>

            <h2>Education sector</h2>
            <p>Faculty edit syllabus PDFs each semester — digital university PDFs convert cleanly; scanned course packs need OCR. Check campus IT data handling before upload.</p>

            <h2>Real estate</h2>
            <p>Lease amendments stored as PDF — convert to Word for redline, re-PDF for signature. Keep executed scan archived separately from working DOCX.</p>

            <h2>HR and offer letters</h2>
            <p>Template offer PDFs with merge fields sometimes break on convert — edit boilerplate in Word template instead of converting each hire if HRIS exports PDF.</p>

            <h2>Government RFP responses</h2>
            <p>Final submissions often must be PDF — use Word only for draft edits, export via <a href="/pdf/doctopdf">Word to PDF</a> for portal upload. Check RFP forbids track changes in submission.</p>

            <h2>Quality gates before client delivery</h2>
            <ol>
            <li>Spell-check in Word</li>
            <li>Compare page count vs source PDF</li>
            <li>Verify critical numbers (dates, amounts) unchanged</li>
            <li>Remove comments and track changes</li>
            <li>Export final PDF if deliverable format is PDF</li>
            </ol>

            <p>Pillar: <a href="/guides/pdf-to-word">PDF to Word guide</a> · Compare: <a href="/compare/smallpdf-alternative">Smallpdf alternative</a></p>
            
            
            <h2>Batch conversion hygiene</h2>
            <p>Converting 20 contracts? Use consistent naming <code>ClientName-contract-v1.docx</code>. Log source PDF hash if legal audit trail required.</p>

            <h2>Mobile upload caveats</h2>
            <p>Phone browsers work but large PDFs may timeout on cellular — use Wi-Fi or desktop for 50+ MB files.</p>

            <h2>Antivirus false positives</h2>
            <p>Some corporate proxies scan uploads — if blocked, try guest network or contact IT to allowlist ratpdf.com tool path.</p>

            <h2>Long-term archival</h2>
            <p>Store both source PDF and final DOCX/PDF pair — migrations sometimes need to re-edit decade-old contracts.</p>

            <h2>Regulatory and compliance edits</h2>
            <p>Privacy policies, SOC2 reports, and vendor security questionnaires arrive as PDF — convert to Word for comment, return PDF via <a href="/pdf/doctopdf">Word to PDF</a>. Legal should review material compliance wording changes.</p>

            <h2>Performance expectations</h2>
            <p>10-page digital PDF typically converts under two minutes; 200-page annual report may take longer — do not close tab during processing. Refresh only after timeout message.</p>
            
            
            <h2>Document type quick reference</h2>
            <p><strong>Contracts:</strong> digital PDF, track changes in Word. <strong>Invoices:</strong> table-heavy — check sums. <strong>Scanned forms:</strong> OCR first. <strong>Marketing PDFs:</strong> expect image blocks. <strong>Manuals:</strong> headings usually survive — update TOC in Word after edits.</p>
            <p>Upgrade for volume: <a href="/Subscription/Plans">subscription plans</a>. Pillar: <a href="/guides/pdf-to-word">PDF to Word</a>.</p>

            <h2>Stakeholder sign-off matrix</h2>
            <p>Legal reviews converted contracts; finance reviews invoice PDFs edited in Word; HR reviews offer letters. Route DOCX to the right reviewer before re-PDF. Version suffix in filename (<code>-legal-reviewed</code>) prevents accidental send of draft.</p>
            <p>After major edits, compress before email if DOCX re-export exceeds mailbox limits — see <a href="/research/pdf-compression-benchmark">PDF compression benchmark</a> for quality settings.</p>
            <p>Bookmark this page for your team's wiki — consistent PDF-to-Word steps reduce support tickets when onboarding new staff each quarter.</p>
            
            
            <h2>Failure messages</h2>
            <p><strong>Too large:</strong> compress or split. <strong>Invalid PDF:</strong> re-export source. <strong>Unreadable:</strong> re-scan don't only compress blur.</p>
            <h2>Archive discipline</h2>
            <p>Keep uncompressed master until upload or send succeeds — derivatives are disposable.</p>
            <h2>Compare tools</h2>
            <p><a href="/compare/smallpdf-alternative">Smallpdf</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/adobe-alternative">Adobe</a>.</p>
            
            
            <h2>Related guides</h2>
            <p>Editing guides cover crop, delete, annotate, highlight, rearrange pages, add text, fill forms, device workflows, blank-page cleanup, and rotate — step-by-step help for each task.</p>
            <p>Next troubleshooting wave: corrupt PDF, won’t open, print errors — bookmark <a href="/guides/pdf-tools">PDF tools hub</a> for full map.</p>
            
            
            <h2>More guides</h2>
            <p>Image, PowerPoint, and Word conversion guides, plus editing tutorials and competitor comparisons — all in one place.</p>
            <p>Main guides: <a href="/guides/images-to-pdf">images</a> · <a href="/guides/pdf-to-word">PDF to Word</a> · <a href="/guides/split-pdf">split</a> · <a href="/compare">compare</a>.</p>
            <h2>Post-action checklist</h2>
            <ol><li>Output opens in Chrome PDF viewer</li><li>Page order matches intent</li><li>Text selects if downstream edit needed</li><li>File size under email/portal cap</li><li>Master archived before deleting source</li></ol>
            <p>Bookmark the <a href="/guides/pdf-tools">PDF tools guide</a> and <a href="/compare">compare tools</a> for team onboarding — consistent tool choice reduces wrong-output support tickets.</p>
            
            
            <h2>Post-action checklist</h2>
            <ol><li>Output file opens in viewer</li><li>Text selects if required</li><li>Size under portal/email preset</li><li>Master archived</li><li>Correct tool used for next step (text vs Word vs OCR)</li></ol>
            <p>Bookmark the <a href="/guides/pdf-tools">PDF tools guide</a> and <a href="/compare">compare tools</a> for team onboarding — consistent tool choice reduces wrong-output support tickets.</p>
            <p>Re-run size checker after every derivative step — compress, split, or text export — before deleting the previous version from your working folder.</p>
            
            <p class="mt-4"><a href="/pdf/merge" class="btn btn-primary">Merge PDF</a> · <a href="/guides/edit-pdf">Edit PDF hub</a></p>
            """;

        private const string EditPdfTextOnline = """
            <h2>Edit PDF text online — add &amp; correct wording in browser</h2>
            <p>RatPDF <a href="/pdf/editpdf">Edit PDF</a> — Fix typo in proposal date field before client send.</p>
            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> Edit PDF text online — add &amp; correct wording in browser</figcaption></figure>
            
            <h2>When text overlay works</h2>
            <p>Short corrections — date, SKU, one-line label — overlay text box on digital PDF. Heavy paragraph rewrite — <a href="/guides/pdf-to-word">PDF to Word</a> path.</p>
            <h2>Font and alignment</h2>
            <p>Match surrounding font size — print-test government forms — misalignment rejects portal upload.</p>
            <h2>Scanned PDFs</h2>
            <p>OCR mandatory — <a href="/guides/edit-scanned-pdf">edit scanned PDF guide</a> — proofread numbers manually.</p>
            
            
            <h2>Invoice field fix</h2>
            <p>Wrong PO number on PDF invoice — text overlay correction — re-send — ERP reissue preferred when available.</p>
            <h2>Certificate typo</h2>
            <p>Training certificate name typo — overlay fix for draft — reissue from source for official record.</p>
            
            <div class="rp-mid-cta alert alert-primary my-4"><strong>Start now</strong> <a href="/pdf/editpdf" class="alert-link fw-semibold">Edit PDF →</a></div>
            
            <h2>Edit vs convert vs OCR decision tree</h2>
            <p><strong>Digital PDF minor fix:</strong> Edit PDF text overlay. <strong>Heavy rewrite:</strong> PDF to Word. <strong>Scan:</strong> OCR first. <strong>Wrong page order:</strong> Organize via merge queue. <strong>One page pull:</strong> Split PDF.</p>
            <h2>Form filling landscape</h2>
            <p>Government PDFs mix fillable AcroForm fields and flat scans. Fillable fields preserve tab order — flat forms need positioned text boxes — print-test alignment before official submit.</p>
            <h2>Scanned document edit chain</h2>
            <ol>
            <li>Scan 300 DPI grayscale upright</li>
            <li><a href="/pdf/ocrpdf">OCR PDF</a> — verify Ctrl+F finds key term</li>
            <li><a href="/pdf/editpdf">Edit PDF</a> — add date, signature image, stamp</li>
            <li>Optional <a href="/guides/compress-pdf-for-email">compress</a> before portal upload</li>
            </ol>
            <h2>Organize without desktop Acrobat</h2>
            <p>Reorder pages in merge tool — drag queue — single merge output — same engine as <a href="/guides/merge-pdf-custom-order">custom order merge</a>. Delete pages by omitting from queue not destructive edit on source.</p>
            <h2>Image overlay best practices</h2>
            <p>Logo PNG with transparency — place top-right — do not cover existing signature block. DPI 150 sufficient for screen PDF — 300 for print-bound proposals.</p>
            <h2>Security and audit</h2>
            <p>Edited PDF is new derivative — keep unedited master for legal hold — filename suffix <code>-edited-2026-04-02</code>. Flatten annotations before court filing if local rules require.</p>
            
            
            <h2>Browser edit limitations</h2>
            <p>RatPDF edit covers common SMB needs — text add, image stamp, form fill — not InDesign prepress — not Photoshop pixel surgery. For marketing brochure pixel edits return to design source.</p>
            <h2>Mobile edit caution</h2>
            <p>Fine form alignment on phone is painful — desktop for government forms — mobile OK for initial and date on consent PDF.</p>
            <h2>Password-protected PDFs</h2>
            <p>Unlock first: <a href="/guides/unlock-pdf">unlock PDF</a> — edit fails on encrypted open.</p>
            <h2>Compare vendors</h2>
            <p><a href="/compare/adobe-alternative">Adobe</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/smallpdf-alternative">Smallpdf</a> — evaluate form-fill on your hardest government PDF sample.</p>
            <h2>Split and extract coordination</h2>
            <p>Extract signature page before sending for countersign — <a href="/guides/extract-single-page-pdf">extract single page</a> — merge back after scan with <a href="/pdf/merge">Merge PDF</a>.</p>
            <h2>QA print test</h2>
            <p>Government forms reject misaligned fields — print one copy — hold to light against blank form — adjust coordinates before batch.</p>
            
            
            <h2>Edit cluster authority map</h2>
            <p>Editing guides cover crop, delete, annotate, highlight, rearrange pages, and device workflows — plus in-depth help for <a href="/guides/edit-pdf">edit PDF</a> and <a href="/guides/rotate-pdf">rotate PDF</a>. See also merge, split, and OCR guides.</p>
            <h2>Security and compliance</h2>
            <p>Edited derivatives are new files — keep immutable master — log who edited — confidential docs cleared from Downloads on shared PCs same day. HIPAA and legal hold: counsel approves browser edit on PHI or privilege docs.</p>
            <h2>Failure triage</h2>
            <p><strong>Cannot select text:</strong> OCR first. <strong>Wrong page count after delete:</strong> off-by-one viewer index — recount. <strong>Portal rejects filled form:</strong> print-test alignment — font mismatch — try flatten. <strong>Upload timeout:</strong> Wi-Fi — compress — split.</p>
            <h2>Research links</h2>
            <p><a href="/research/attachment-size-limits">Email attachment limits</a> · <a href="/research/pdf-tool-market-comparison">PDF tool market comparison</a> · <a href="/compare">Compare hub</a>.</p>
            
            
            <h2>Workflow deep dive — Edit PDF text online — add &amp; correct wording in browser</h2>
            <p>Browser workflow — no install — upload → process → download → verify in viewer before external send.</p>
            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> Edit PDF text online — add &amp; correct wording in browser</figcaption></figure>
            <h2>Mobile</h2>
            <p>Safari/Chrome on phone works — Wi-Fi for files over 15 MB — save to Files before portal upload.</p>
            <h2>Failures</h2>
            <p>Timeout: retry Wi-Fi · corrupt PDF: re-export source · password: <a href="/guides/unlock-pdf">unlock</a>.</p>
            <h2>Free tier</h2>
            <p>Three uses/day — <a href="/Subscription/Plans">plans</a> for volume.</p>
            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Open tool</strong> <a href="/pdf/editpdf" class="alert-link fw-semibold">Go →</a></div>
            
            
            <h2>Real example: HR onboarding packet</h2>
            <p>Flat I-9 scan — OCR — add start date field — employee initials — merge with handbook acknowledgment — compress — upload to HRIS.</p>
            <h2>Second example: property manager lease initialed</h2>
            <p>Scan signed lease pages — add initialed watermark on page 4 rider — re-compress for email to tenant.</p>
            <h2>Third example: proposal logo</h2>
            <p>Sales exports proposal PDF from CRM — add partner logo top-left — send to client — no return to InDesign.</p>
            <h2>Discovery page pull</h2>
            <p>Counsel needs only exhibit G from 200-page production — split page range 142-148 — email to expert witness — index in cover note.</p>
            <h2>Medical admin form</h2>
            <p>Clinic scan intake form — OCR — nurse adds checkbox marks — print for patient sign — scan again for chart.</p>
            <h2>Upgrade path</h2>
            <p>High-volume form shop — <a href="/Subscription/Plans">plans</a> — see the <a href="/guides/edit-pdf">edit PDF hub</a>.</p>
            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Edit your PDF</strong> <a href="/pdf/editpdf" class="alert-link fw-semibold">Edit PDF →</a></div>
            
            
            
            <h2>Browser vs desktop</h2>
            <p>RatPDF needs no install — IT-friendly — confidential docs review privacy policy retention window.</p>
            <h2>Chain tools</h2>
            <p>Convert → edit → compress → merge — pick order by deliverable — see the <a href="/guides/pdf-tools">PDF tools hub</a>.</p>
            <h2>Upgrade</h2>
            <p><a href="/Subscription/Plans">subscription plans</a> for daily caps on agency volume.</p>
            
            
            <h2>Cross-wave tool chain</h2>
            <p>Pick tool order by what you need to deliver. Example: photos → images PDF → OCR → edit date → compress → portal upload.</p>
            <h2>Free tier and upgrade</h2>
            <p>Three uses per day per tool on free tier — agency month-end exceeds cap — <a href="/Subscription/Plans">subscription plans</a> — predictable vs per-file credit packs.</p>
            <h2>Internal link discipline</h2>
            <p>Each guide links to related tools and comparisons so your team picks the right workflow.</p>
            <h2>Support triage</h2>
            <p>Wrong tool order causes bad output — OCR before edit on scans — compress after merge not before each file — train your team using the main tool guides.</p>
            
            
            <h2>QA before send</h2>
            <ol><li>Page count correct</li><li>Text selects if required</li><li>Images sharp at 150% zoom</li><li>File opens in Chrome PDF viewer</li><li>Size under email/portal cap</li></ol>
            <h2>Compare vendors</h2>
            <p><a href="/compare/smallpdf-alternative">Smallpdf</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/adobe-alternative">Adobe</a>.</p>
            
            
            <h2>Device matrix</h2>
            <p>Windows Edge, Mac Safari, iPhone Safari, Android Chrome — same account — no sync required — download to device storage before portal upload.</p>
            <h2>Retention hygiene</h2>
            <p>Clear Downloads on shared PC — contracts and medical admin PDFs are confidential — delete derivatives when task completes.</p>
            <h2>Filename and version control</h2>
            <p><code>Client-Doc-v2-edited.pdf</code> — never overwrite sent attachment — email thread references version.</p>
            <h2>Portal rejection loop</h2>
            <p>Reject → check size with <a href="/pdf-size-checker">size checker</a> → compress Less → split if still over → re-upload before session timeout.</p>
            <h2>Research links</h2>
            <p><a href="/research/attachment-size-limits">Attachment size limits</a> · <a href="/research/pdf-compression-benchmark">Compression benchmark</a> · <a href="/research/freelancer-invoicing-statistics">Invoicing statistics</a>.</p>
            <h2>Pillar bookmark set</h2>
            <p><a href="/guides/pdf-tools">PDF tools hub</a> · <a href="/guides/images-to-pdf">Images to PDF</a> · <a href="/guides/pdf-to-word">PDF to Word</a> · <a href="/guides/split-pdf">Split PDF</a> · <a href="/compare">Compare hub</a>.</p>
            
            
            <h2>Edit audit log</h2>
            <p>Log who edited which PDF derivative — timestamp — reason — matter number — supports litigation hold and SOX-style controls.</p>
            <h2>Flatten before external send</h2>
            <p>Some recipients see floating annotations differently — flatten or re-export PDF so logo and text boxes appear identical on all viewers.</p>
            <h2>Redaction before edit</h2>
            <p>Remove SSN and account numbers with <a href="/guides/pdf-redaction-permanent">permanent redaction</a> before adding new text — edit tool does not replace redaction workflow.</p>
            <h2>Training slide for staff</h2>
            <p>Three rules poster: OCR scans first — organize before merge — compress after combine — pin in Slack onboarding channel.</p>
            <h2>Department-specific examples</h2>
            <p><strong>HR:</strong> I-9 and handbook ack merge. <strong>Sales:</strong> logo on proposal. <strong>Legal:</strong> exhibit extract. <strong>Finance:</strong> initialed tax form. <strong>Ops:</strong> delivery note stamp.</p>
            <h2>Version rollback</h2>
            <p>Keep pre-edit master immutable — if client rejects edit — resend from master not undo in editor — filename version increments.</p>
            <h2>Collaboration handoff</h2>
            <p>Paralegal extracts page — attorney reviews in isolation — merge signed scan back — document handoff in matter management ticket.</p>
            <h2>Accessibility after edit</h2>
            <p>Added text may not be tagged — government accessibility filing may need tagged PDF specialist — SMB email deliverable usually exempt.</p>
            <h2>Pillar cross-links</h2>
            <p><a href="/guides/merge-pdf-online">merge PDF</a> · <a href="/guides/ocr-pdf">OCR PDF</a> · <a href="/guides/split-pdf">split hub</a> · <a href="/guides/pdf-tools">PDF tools hub</a>.</p>
            
            
            <h2>QA checklist — edit outputs</h2>
            <ol>
            <li>Page count matches intent after delete or rearrange</li>
            <li>Orientation correct on every page at thumbnail view</li>
            <li>Added text readable at 150% zoom and in print preview</li>
            <li>Annotations visible in Chrome PDF viewer and recipient test</li>
            <li>File size under email or portal cap — compress if needed</li>
            <li>Master archived before destructive delete</li>
            </ol>
            <h2>Department playbooks</h2>
            <p><strong>Legal:</strong> annotate review copy — master untouched. <strong>Finance:</strong> fill tax PDF — print-test. <strong>HR:</strong> OCR onboarding — merge ack. <strong>Sales:</strong> logo + date on proposal. <strong>Ops:</strong> delete blank feeder pages from scan batch.</p>
            <h2>Monthly volume</h2>
            <p>Track edit/remove jobs — exceed free tier twice in one week — finance approves <a href="/Subscription/Plans">subscription</a>.</p>
            <h2>Compare alternatives</h2>
            <p><a href="/compare/adobe-acrobat-alternative">Adobe Acrobat alternative</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/smallpdf-alternative">Smallpdf</a>.</p>
            
            
            <h2>Team rollout notes</h2>
            <p>Pin the main tool guides in your shared wiki — compress before portal, OCR before edit on scans, Word path only when ERP cannot reissue. New hires complete one sample file in first week using browser tools only — no desktop install ticket.</p>
            <h2>Support escalation path</h2>
            <p>Step 1: re-download output and open in Chrome viewer. Step 2: retry on Wi-Fi with smaller batch. Step 3: check <a href="/pdf-size-checker">size checker</a> preset. Step 4: compare tool choice on <a href="/compare">compare tools</a> if output quality insufficient.</p>
            <h2>Record retention</h2>
            <p>Keep source PDF until recipient confirms receipt — derivatives disposable after successful upload — confidential docs deleted from Downloads on shared machines same day.</p>
            <h2>Monthly volume planning</h2>
            <p>Track daily tool usage in spreadsheet — forecast upgrade need before month-end crunch — finance approves <a href="/Subscription/Plans">subscription</a> when free tier blocks twice in one week.</p>
            <h2>Incident log template</h2>
            <p>Date, source filename, tool used, error message, resolution — patterns reveal training gaps — share quarterly with ops lead.</p>
            
            
            <h2>Quick reference card</h2>
            <p>Scan → OCR → Edit. Digital → Edit direct. Reorder → Merge queue. One page → Split. Logo → Add image. Forms → Fill then print-test. Archive master before any derivative edit.</p>
            <p>Bookmark <a href="/guides/edit-pdf">edit PDF guide</a> for team onboarding — reduces wrong-tool support tickets.</p>
            <p>Wrong page order voids visa bundles — verify thumbnail strip before merge submit.</p>
            
            
            <h2>Related edit &amp; organize guides</h2>
            <ul>
            <li><a href="/guides/edit-scanned-pdf">Edit scanned PDF</a></li>
            <li><a href="/guides/organize-pdf-pages">Organize PDF pages</a></li>
            <li><a href="/guides/split-pdf-page-range">Split by page range</a></li>
            <li><a href="/guides/add-image-to-pdf">Add image to PDF</a></li>
            </ul>
            
            
            <h2>Edit-gap guides</h2>
            <ul>
            <li><a href="/guides/crop-pdf-online">Crop PDF online</a> · <a href="/guides/crop-pdf-without-adobe">Crop without Adobe</a></li>
            <li><a href="/guides/delete-pages-from-pdf">Delete pages</a> · <a href="/guides/remove-blank-pages-pdf">Remove blank pages</a></li>
            <li><a href="/guides/annotate-pdf-online">Annotate online</a> · <a href="/guides/annotate-pdf-free">Annotate free</a></li>
            <li><a href="/guides/highlight-pdf-online">Highlight PDF</a> · <a href="/guides/edit-pdf-text-online">Edit text</a></li>
            <li><a href="/guides/add-text-to-pdf">Add text</a> · <a href="/guides/fill-pdf-form-online">Fill form</a></li>
            <li><a href="/guides/rearrange-pdf-pages">Rearrange pages</a> · <a href="/guides/edit-pdf-without-acrobat">Without Acrobat</a></li>
            <li><a href="/guides/edit-pdf-on-mac">Edit on Mac</a> · <a href="/guides/edit-pdf-on-windows">Windows</a> · <a href="/guides/edit-pdf-on-iphone">iPhone</a></li>
            </ul>
            <h2>Pillar and organize links</h2>
            <p><a href="/guides/edit-pdf">Edit PDF guide</a> · <a href="/guides/rotate-pdf">Rotate PDF</a> · <a href="/guides/organize-pdf-pages">Organize pages</a> · <a href="/guides/merge-pdf">Merge guide</a> · <a href="/guides/split-pdf">Split guide</a> · <a href="/guides/ocr-pdf">OCR guide</a>.</p>
            
            
            <h2>Enterprise document workflows</h2>
            <p>Legal ops teams convert legacy contract PDFs during CLM migration — batch convert critical folders, prioritise active vendor agreements first. IT should approve browser upload policy for confidential docs.</p>

            <h2>Education sector</h2>
            <p>Faculty edit syllabus PDFs each semester — digital university PDFs convert cleanly; scanned course packs need OCR. Check campus IT data handling before upload.</p>

            <h2>Real estate</h2>
            <p>Lease amendments stored as PDF — convert to Word for redline, re-PDF for signature. Keep executed scan archived separately from working DOCX.</p>

            <h2>HR and offer letters</h2>
            <p>Template offer PDFs with merge fields sometimes break on convert — edit boilerplate in Word template instead of converting each hire if HRIS exports PDF.</p>

            <h2>Government RFP responses</h2>
            <p>Final submissions often must be PDF — use Word only for draft edits, export via <a href="/pdf/doctopdf">Word to PDF</a> for portal upload. Check RFP forbids track changes in submission.</p>

            <h2>Quality gates before client delivery</h2>
            <ol>
            <li>Spell-check in Word</li>
            <li>Compare page count vs source PDF</li>
            <li>Verify critical numbers (dates, amounts) unchanged</li>
            <li>Remove comments and track changes</li>
            <li>Export final PDF if deliverable format is PDF</li>
            </ol>

            <p>Pillar: <a href="/guides/pdf-to-word">PDF to Word guide</a> · Compare: <a href="/compare/smallpdf-alternative">Smallpdf alternative</a></p>
            
            
            <h2>Batch conversion hygiene</h2>
            <p>Converting 20 contracts? Use consistent naming <code>ClientName-contract-v1.docx</code>. Log source PDF hash if legal audit trail required.</p>

            <h2>Mobile upload caveats</h2>
            <p>Phone browsers work but large PDFs may timeout on cellular — use Wi-Fi or desktop for 50+ MB files.</p>

            <h2>Antivirus false positives</h2>
            <p>Some corporate proxies scan uploads — if blocked, try guest network or contact IT to allowlist ratpdf.com tool path.</p>

            <h2>Long-term archival</h2>
            <p>Store both source PDF and final DOCX/PDF pair — migrations sometimes need to re-edit decade-old contracts.</p>

            <h2>Regulatory and compliance edits</h2>
            <p>Privacy policies, SOC2 reports, and vendor security questionnaires arrive as PDF — convert to Word for comment, return PDF via <a href="/pdf/doctopdf">Word to PDF</a>. Legal should review material compliance wording changes.</p>

            <h2>Performance expectations</h2>
            <p>10-page digital PDF typically converts under two minutes; 200-page annual report may take longer — do not close tab during processing. Refresh only after timeout message.</p>
            
            
            <h2>Document type quick reference</h2>
            <p><strong>Contracts:</strong> digital PDF, track changes in Word. <strong>Invoices:</strong> table-heavy — check sums. <strong>Scanned forms:</strong> OCR first. <strong>Marketing PDFs:</strong> expect image blocks. <strong>Manuals:</strong> headings usually survive — update TOC in Word after edits.</p>
            <p>Upgrade for volume: <a href="/Subscription/Plans">subscription plans</a>. Pillar: <a href="/guides/pdf-to-word">PDF to Word</a>.</p>

            <h2>Stakeholder sign-off matrix</h2>
            <p>Legal reviews converted contracts; finance reviews invoice PDFs edited in Word; HR reviews offer letters. Route DOCX to the right reviewer before re-PDF. Version suffix in filename (<code>-legal-reviewed</code>) prevents accidental send of draft.</p>
            <p>After major edits, compress before email if DOCX re-export exceeds mailbox limits — see <a href="/research/pdf-compression-benchmark">PDF compression benchmark</a> for quality settings.</p>
            <p>Bookmark this page for your team's wiki — consistent PDF-to-Word steps reduce support tickets when onboarding new staff each quarter.</p>
            
            
            <h2>Failure messages</h2>
            <p><strong>Too large:</strong> compress or split. <strong>Invalid PDF:</strong> re-export source. <strong>Unreadable:</strong> re-scan don't only compress blur.</p>
            <h2>Archive discipline</h2>
            <p>Keep uncompressed master until upload or send succeeds — derivatives are disposable.</p>
            <h2>Compare tools</h2>
            <p><a href="/compare/smallpdf-alternative">Smallpdf</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/adobe-alternative">Adobe</a>.</p>
            
            
            <h2>Related guides</h2>
            <p>Editing guides cover crop, delete, annotate, highlight, rearrange pages, add text, fill forms, device workflows, blank-page cleanup, and rotate — step-by-step help for each task.</p>
            <p>Next troubleshooting wave: corrupt PDF, won’t open, print errors — bookmark <a href="/guides/pdf-tools">PDF tools hub</a> for full map.</p>
            
            
            <h2>More guides</h2>
            <p>Image, PowerPoint, and Word conversion guides, plus editing tutorials and competitor comparisons — all in one place.</p>
            <p>Main guides: <a href="/guides/images-to-pdf">images</a> · <a href="/guides/pdf-to-word">PDF to Word</a> · <a href="/guides/split-pdf">split</a> · <a href="/compare">compare</a>.</p>
            <h2>Post-action checklist</h2>
            <ol><li>Output opens in Chrome PDF viewer</li><li>Page order matches intent</li><li>Text selects if downstream edit needed</li><li>File size under email/portal cap</li><li>Master archived before deleting source</li></ol>
            <p>Bookmark the <a href="/guides/pdf-tools">PDF tools guide</a> and <a href="/compare">compare tools</a> for team onboarding — consistent tool choice reduces wrong-output support tickets.</p>
            
            
            <h2>Post-action checklist</h2>
            <ol><li>Output file opens in viewer</li><li>Text selects if required</li><li>Size under portal/email preset</li><li>Master archived</li><li>Correct tool used for next step (text vs Word vs OCR)</li></ol>
            <p>Bookmark the <a href="/guides/pdf-tools">PDF tools guide</a> and <a href="/compare">compare tools</a> for team onboarding — consistent tool choice reduces wrong-output support tickets.</p>
            <p>Re-run size checker after every derivative step — compress, split, or text export — before deleting the previous version from your working folder.</p>
            
            <p class="mt-4"><a href="/pdf/editpdf" class="btn btn-primary">Edit PDF</a> · <a href="/guides/edit-pdf">Edit PDF hub</a></p>
            """;

        private const string AddTextToPdf = """
            <h2>Add text to PDF — labels, dates &amp; captions online</h2>
            <p>RatPDF <a href="/pdf/editpdf">Edit PDF</a> — Add DRAFT label and revision date on board pack PDF.</p>
            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> Add text to PDF — labels, dates &amp; captions online</figcaption></figure>
            
            <h2>Common text additions</h2>
            <p>DRAFT watermark text, revision date, page label, missing address line, exhibit title on scan.</p>
            <h2>Combine with image</h2>
            <p>Logo plus text header — <a href="/guides/add-image-to-pdf">add image</a> first — text below — compress after if email rejects.</p>
            <h2>Version naming</h2>
            <p><code>Proposal-ClientX-v3-textadded.pdf</code> — never overwrite sent attachment.</p>
            
            
            <h2>CONFIDENTIAL header</h2>
            <p>Text box top margin on draft board pack — pair with <a href="/guides/watermark-pdf">watermark guide</a> for diagonal label.</p>
            <h2>Exhibit cover sheet</h2>
            <p>Add exhibit letter and title page before merge into main brief.</p>
            
            <div class="rp-mid-cta alert alert-primary my-4"><strong>Start now</strong> <a href="/pdf/editpdf" class="alert-link fw-semibold">Edit PDF →</a></div>
            
            <h2>Edit vs convert vs OCR decision tree</h2>
            <p><strong>Digital PDF minor fix:</strong> Edit PDF text overlay. <strong>Heavy rewrite:</strong> PDF to Word. <strong>Scan:</strong> OCR first. <strong>Wrong page order:</strong> Organize via merge queue. <strong>One page pull:</strong> Split PDF.</p>
            <h2>Form filling landscape</h2>
            <p>Government PDFs mix fillable AcroForm fields and flat scans. Fillable fields preserve tab order — flat forms need positioned text boxes — print-test alignment before official submit.</p>
            <h2>Scanned document edit chain</h2>
            <ol>
            <li>Scan 300 DPI grayscale upright</li>
            <li><a href="/pdf/ocrpdf">OCR PDF</a> — verify Ctrl+F finds key term</li>
            <li><a href="/pdf/editpdf">Edit PDF</a> — add date, signature image, stamp</li>
            <li>Optional <a href="/guides/compress-pdf-for-email">compress</a> before portal upload</li>
            </ol>
            <h2>Organize without desktop Acrobat</h2>
            <p>Reorder pages in merge tool — drag queue — single merge output — same engine as <a href="/guides/merge-pdf-custom-order">custom order merge</a>. Delete pages by omitting from queue not destructive edit on source.</p>
            <h2>Image overlay best practices</h2>
            <p>Logo PNG with transparency — place top-right — do not cover existing signature block. DPI 150 sufficient for screen PDF — 300 for print-bound proposals.</p>
            <h2>Security and audit</h2>
            <p>Edited PDF is new derivative — keep unedited master for legal hold — filename suffix <code>-edited-2026-04-02</code>. Flatten annotations before court filing if local rules require.</p>
            
            
            <h2>Browser edit limitations</h2>
            <p>RatPDF edit covers common SMB needs — text add, image stamp, form fill — not InDesign prepress — not Photoshop pixel surgery. For marketing brochure pixel edits return to design source.</p>
            <h2>Mobile edit caution</h2>
            <p>Fine form alignment on phone is painful — desktop for government forms — mobile OK for initial and date on consent PDF.</p>
            <h2>Password-protected PDFs</h2>
            <p>Unlock first: <a href="/guides/unlock-pdf">unlock PDF</a> — edit fails on encrypted open.</p>
            <h2>Compare vendors</h2>
            <p><a href="/compare/adobe-alternative">Adobe</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/smallpdf-alternative">Smallpdf</a> — evaluate form-fill on your hardest government PDF sample.</p>
            <h2>Split and extract coordination</h2>
            <p>Extract signature page before sending for countersign — <a href="/guides/extract-single-page-pdf">extract single page</a> — merge back after scan with <a href="/pdf/merge">Merge PDF</a>.</p>
            <h2>QA print test</h2>
            <p>Government forms reject misaligned fields — print one copy — hold to light against blank form — adjust coordinates before batch.</p>
            
            
            <h2>Edit cluster authority map</h2>
            <p>Editing guides cover crop, delete, annotate, highlight, rearrange pages, and device workflows — plus in-depth help for <a href="/guides/edit-pdf">edit PDF</a> and <a href="/guides/rotate-pdf">rotate PDF</a>. See also merge, split, and OCR guides.</p>
            <h2>Security and compliance</h2>
            <p>Edited derivatives are new files — keep immutable master — log who edited — confidential docs cleared from Downloads on shared PCs same day. HIPAA and legal hold: counsel approves browser edit on PHI or privilege docs.</p>
            <h2>Failure triage</h2>
            <p><strong>Cannot select text:</strong> OCR first. <strong>Wrong page count after delete:</strong> off-by-one viewer index — recount. <strong>Portal rejects filled form:</strong> print-test alignment — font mismatch — try flatten. <strong>Upload timeout:</strong> Wi-Fi — compress — split.</p>
            <h2>Research links</h2>
            <p><a href="/research/attachment-size-limits">Email attachment limits</a> · <a href="/research/pdf-tool-market-comparison">PDF tool market comparison</a> · <a href="/compare">Compare hub</a>.</p>
            
            
            <h2>Workflow deep dive — Add text to PDF — labels, dates &amp; captions online</h2>
            <p>Browser workflow — no install — upload → process → download → verify in viewer before external send.</p>
            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> Add text to PDF — labels, dates &amp; captions online</figcaption></figure>
            <h2>Mobile</h2>
            <p>Safari/Chrome on phone works — Wi-Fi for files over 15 MB — save to Files before portal upload.</p>
            <h2>Failures</h2>
            <p>Timeout: retry Wi-Fi · corrupt PDF: re-export source · password: <a href="/guides/unlock-pdf">unlock</a>.</p>
            <h2>Free tier</h2>
            <p>Three uses/day — <a href="/Subscription/Plans">plans</a> for volume.</p>
            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Open tool</strong> <a href="/pdf/editpdf" class="alert-link fw-semibold">Go →</a></div>
            
            
            <h2>Real example: HR onboarding packet</h2>
            <p>Flat I-9 scan — OCR — add start date field — employee initials — merge with handbook acknowledgment — compress — upload to HRIS.</p>
            <h2>Second example: property manager lease initialed</h2>
            <p>Scan signed lease pages — add initialed watermark on page 4 rider — re-compress for email to tenant.</p>
            <h2>Third example: proposal logo</h2>
            <p>Sales exports proposal PDF from CRM — add partner logo top-left — send to client — no return to InDesign.</p>
            <h2>Discovery page pull</h2>
            <p>Counsel needs only exhibit G from 200-page production — split page range 142-148 — email to expert witness — index in cover note.</p>
            <h2>Medical admin form</h2>
            <p>Clinic scan intake form — OCR — nurse adds checkbox marks — print for patient sign — scan again for chart.</p>
            <h2>Upgrade path</h2>
            <p>High-volume form shop — <a href="/Subscription/Plans">plans</a> — see the <a href="/guides/edit-pdf">edit PDF hub</a>.</p>
            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Edit your PDF</strong> <a href="/pdf/editpdf" class="alert-link fw-semibold">Edit PDF →</a></div>
            
            
            
            <h2>Browser vs desktop</h2>
            <p>RatPDF needs no install — IT-friendly — confidential docs review privacy policy retention window.</p>
            <h2>Chain tools</h2>
            <p>Convert → edit → compress → merge — pick order by deliverable — see the <a href="/guides/pdf-tools">PDF tools hub</a>.</p>
            <h2>Upgrade</h2>
            <p><a href="/Subscription/Plans">subscription plans</a> for daily caps on agency volume.</p>
            
            
            <h2>Cross-wave tool chain</h2>
            <p>Pick tool order by what you need to deliver. Example: photos → images PDF → OCR → edit date → compress → portal upload.</p>
            <h2>Free tier and upgrade</h2>
            <p>Three uses per day per tool on free tier — agency month-end exceeds cap — <a href="/Subscription/Plans">subscription plans</a> — predictable vs per-file credit packs.</p>
            <h2>Internal link discipline</h2>
            <p>Each guide links to related tools and comparisons so your team picks the right workflow.</p>
            <h2>Support triage</h2>
            <p>Wrong tool order causes bad output — OCR before edit on scans — compress after merge not before each file — train your team using the main tool guides.</p>
            
            
            <h2>QA before send</h2>
            <ol><li>Page count correct</li><li>Text selects if required</li><li>Images sharp at 150% zoom</li><li>File opens in Chrome PDF viewer</li><li>Size under email/portal cap</li></ol>
            <h2>Compare vendors</h2>
            <p><a href="/compare/smallpdf-alternative">Smallpdf</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/adobe-alternative">Adobe</a>.</p>
            
            
            <h2>Device matrix</h2>
            <p>Windows Edge, Mac Safari, iPhone Safari, Android Chrome — same account — no sync required — download to device storage before portal upload.</p>
            <h2>Retention hygiene</h2>
            <p>Clear Downloads on shared PC — contracts and medical admin PDFs are confidential — delete derivatives when task completes.</p>
            <h2>Filename and version control</h2>
            <p><code>Client-Doc-v2-edited.pdf</code> — never overwrite sent attachment — email thread references version.</p>
            <h2>Portal rejection loop</h2>
            <p>Reject → check size with <a href="/pdf-size-checker">size checker</a> → compress Less → split if still over → re-upload before session timeout.</p>
            <h2>Research links</h2>
            <p><a href="/research/attachment-size-limits">Attachment size limits</a> · <a href="/research/pdf-compression-benchmark">Compression benchmark</a> · <a href="/research/freelancer-invoicing-statistics">Invoicing statistics</a>.</p>
            <h2>Pillar bookmark set</h2>
            <p><a href="/guides/pdf-tools">PDF tools hub</a> · <a href="/guides/images-to-pdf">Images to PDF</a> · <a href="/guides/pdf-to-word">PDF to Word</a> · <a href="/guides/split-pdf">Split PDF</a> · <a href="/compare">Compare hub</a>.</p>
            
            
            <h2>Edit audit log</h2>
            <p>Log who edited which PDF derivative — timestamp — reason — matter number — supports litigation hold and SOX-style controls.</p>
            <h2>Flatten before external send</h2>
            <p>Some recipients see floating annotations differently — flatten or re-export PDF so logo and text boxes appear identical on all viewers.</p>
            <h2>Redaction before edit</h2>
            <p>Remove SSN and account numbers with <a href="/guides/pdf-redaction-permanent">permanent redaction</a> before adding new text — edit tool does not replace redaction workflow.</p>
            <h2>Training slide for staff</h2>
            <p>Three rules poster: OCR scans first — organize before merge — compress after combine — pin in Slack onboarding channel.</p>
            <h2>Department-specific examples</h2>
            <p><strong>HR:</strong> I-9 and handbook ack merge. <strong>Sales:</strong> logo on proposal. <strong>Legal:</strong> exhibit extract. <strong>Finance:</strong> initialed tax form. <strong>Ops:</strong> delivery note stamp.</p>
            <h2>Version rollback</h2>
            <p>Keep pre-edit master immutable — if client rejects edit — resend from master not undo in editor — filename version increments.</p>
            <h2>Collaboration handoff</h2>
            <p>Paralegal extracts page — attorney reviews in isolation — merge signed scan back — document handoff in matter management ticket.</p>
            <h2>Accessibility after edit</h2>
            <p>Added text may not be tagged — government accessibility filing may need tagged PDF specialist — SMB email deliverable usually exempt.</p>
            <h2>Pillar cross-links</h2>
            <p><a href="/guides/merge-pdf-online">merge PDF</a> · <a href="/guides/ocr-pdf">OCR PDF</a> · <a href="/guides/split-pdf">split hub</a> · <a href="/guides/pdf-tools">PDF tools hub</a>.</p>
            
            
            <h2>QA checklist — edit outputs</h2>
            <ol>
            <li>Page count matches intent after delete or rearrange</li>
            <li>Orientation correct on every page at thumbnail view</li>
            <li>Added text readable at 150% zoom and in print preview</li>
            <li>Annotations visible in Chrome PDF viewer and recipient test</li>
            <li>File size under email or portal cap — compress if needed</li>
            <li>Master archived before destructive delete</li>
            </ol>
            <h2>Department playbooks</h2>
            <p><strong>Legal:</strong> annotate review copy — master untouched. <strong>Finance:</strong> fill tax PDF — print-test. <strong>HR:</strong> OCR onboarding — merge ack. <strong>Sales:</strong> logo + date on proposal. <strong>Ops:</strong> delete blank feeder pages from scan batch.</p>
            <h2>Monthly volume</h2>
            <p>Track edit/remove jobs — exceed free tier twice in one week — finance approves <a href="/Subscription/Plans">subscription</a>.</p>
            <h2>Compare alternatives</h2>
            <p><a href="/compare/adobe-acrobat-alternative">Adobe Acrobat alternative</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/smallpdf-alternative">Smallpdf</a>.</p>
            
            
            <h2>Team rollout notes</h2>
            <p>Pin the main tool guides in your shared wiki — compress before portal, OCR before edit on scans, Word path only when ERP cannot reissue. New hires complete one sample file in first week using browser tools only — no desktop install ticket.</p>
            <h2>Support escalation path</h2>
            <p>Step 1: re-download output and open in Chrome viewer. Step 2: retry on Wi-Fi with smaller batch. Step 3: check <a href="/pdf-size-checker">size checker</a> preset. Step 4: compare tool choice on <a href="/compare">compare tools</a> if output quality insufficient.</p>
            <h2>Record retention</h2>
            <p>Keep source PDF until recipient confirms receipt — derivatives disposable after successful upload — confidential docs deleted from Downloads on shared machines same day.</p>
            <h2>Monthly volume planning</h2>
            <p>Track daily tool usage in spreadsheet — forecast upgrade need before month-end crunch — finance approves <a href="/Subscription/Plans">subscription</a> when free tier blocks twice in one week.</p>
            <h2>Incident log template</h2>
            <p>Date, source filename, tool used, error message, resolution — patterns reveal training gaps — share quarterly with ops lead.</p>
            
            
            <h2>Quick reference card</h2>
            <p>Scan → OCR → Edit. Digital → Edit direct. Reorder → Merge queue. One page → Split. Logo → Add image. Forms → Fill then print-test. Archive master before any derivative edit.</p>
            <p>Bookmark <a href="/guides/edit-pdf">edit PDF guide</a> for team onboarding — reduces wrong-tool support tickets.</p>
            <p>Wrong page order voids visa bundles — verify thumbnail strip before merge submit.</p>
            
            
            <h2>Related edit &amp; organize guides</h2>
            <ul>
            <li><a href="/guides/edit-scanned-pdf">Edit scanned PDF</a></li>
            <li><a href="/guides/organize-pdf-pages">Organize PDF pages</a></li>
            <li><a href="/guides/split-pdf-page-range">Split by page range</a></li>
            <li><a href="/guides/add-image-to-pdf">Add image to PDF</a></li>
            </ul>
            
            
            <h2>Edit-gap guides</h2>
            <ul>
            <li><a href="/guides/crop-pdf-online">Crop PDF online</a> · <a href="/guides/crop-pdf-without-adobe">Crop without Adobe</a></li>
            <li><a href="/guides/delete-pages-from-pdf">Delete pages</a> · <a href="/guides/remove-blank-pages-pdf">Remove blank pages</a></li>
            <li><a href="/guides/annotate-pdf-online">Annotate online</a> · <a href="/guides/annotate-pdf-free">Annotate free</a></li>
            <li><a href="/guides/highlight-pdf-online">Highlight PDF</a> · <a href="/guides/edit-pdf-text-online">Edit text</a></li>
            <li><a href="/guides/add-text-to-pdf">Add text</a> · <a href="/guides/fill-pdf-form-online">Fill form</a></li>
            <li><a href="/guides/rearrange-pdf-pages">Rearrange pages</a> · <a href="/guides/edit-pdf-without-acrobat">Without Acrobat</a></li>
            <li><a href="/guides/edit-pdf-on-mac">Edit on Mac</a> · <a href="/guides/edit-pdf-on-windows">Windows</a> · <a href="/guides/edit-pdf-on-iphone">iPhone</a></li>
            </ul>
            <h2>Pillar and organize links</h2>
            <p><a href="/guides/edit-pdf">Edit PDF guide</a> · <a href="/guides/rotate-pdf">Rotate PDF</a> · <a href="/guides/organize-pdf-pages">Organize pages</a> · <a href="/guides/merge-pdf">Merge guide</a> · <a href="/guides/split-pdf">Split guide</a> · <a href="/guides/ocr-pdf">OCR guide</a>.</p>
            
            
            <h2>Enterprise document workflows</h2>
            <p>Legal ops teams convert legacy contract PDFs during CLM migration — batch convert critical folders, prioritise active vendor agreements first. IT should approve browser upload policy for confidential docs.</p>

            <h2>Education sector</h2>
            <p>Faculty edit syllabus PDFs each semester — digital university PDFs convert cleanly; scanned course packs need OCR. Check campus IT data handling before upload.</p>

            <h2>Real estate</h2>
            <p>Lease amendments stored as PDF — convert to Word for redline, re-PDF for signature. Keep executed scan archived separately from working DOCX.</p>

            <h2>HR and offer letters</h2>
            <p>Template offer PDFs with merge fields sometimes break on convert — edit boilerplate in Word template instead of converting each hire if HRIS exports PDF.</p>

            <h2>Government RFP responses</h2>
            <p>Final submissions often must be PDF — use Word only for draft edits, export via <a href="/pdf/doctopdf">Word to PDF</a> for portal upload. Check RFP forbids track changes in submission.</p>

            <h2>Quality gates before client delivery</h2>
            <ol>
            <li>Spell-check in Word</li>
            <li>Compare page count vs source PDF</li>
            <li>Verify critical numbers (dates, amounts) unchanged</li>
            <li>Remove comments and track changes</li>
            <li>Export final PDF if deliverable format is PDF</li>
            </ol>

            <p>Pillar: <a href="/guides/pdf-to-word">PDF to Word guide</a> · Compare: <a href="/compare/smallpdf-alternative">Smallpdf alternative</a></p>
            
            
            <h2>Batch conversion hygiene</h2>
            <p>Converting 20 contracts? Use consistent naming <code>ClientName-contract-v1.docx</code>. Log source PDF hash if legal audit trail required.</p>

            <h2>Mobile upload caveats</h2>
            <p>Phone browsers work but large PDFs may timeout on cellular — use Wi-Fi or desktop for 50+ MB files.</p>

            <h2>Antivirus false positives</h2>
            <p>Some corporate proxies scan uploads — if blocked, try guest network or contact IT to allowlist ratpdf.com tool path.</p>

            <h2>Long-term archival</h2>
            <p>Store both source PDF and final DOCX/PDF pair — migrations sometimes need to re-edit decade-old contracts.</p>

            <h2>Regulatory and compliance edits</h2>
            <p>Privacy policies, SOC2 reports, and vendor security questionnaires arrive as PDF — convert to Word for comment, return PDF via <a href="/pdf/doctopdf">Word to PDF</a>. Legal should review material compliance wording changes.</p>

            <h2>Performance expectations</h2>
            <p>10-page digital PDF typically converts under two minutes; 200-page annual report may take longer — do not close tab during processing. Refresh only after timeout message.</p>
            
            
            <h2>Document type quick reference</h2>
            <p><strong>Contracts:</strong> digital PDF, track changes in Word. <strong>Invoices:</strong> table-heavy — check sums. <strong>Scanned forms:</strong> OCR first. <strong>Marketing PDFs:</strong> expect image blocks. <strong>Manuals:</strong> headings usually survive — update TOC in Word after edits.</p>
            <p>Upgrade for volume: <a href="/Subscription/Plans">subscription plans</a>. Pillar: <a href="/guides/pdf-to-word">PDF to Word</a>.</p>

            <h2>Stakeholder sign-off matrix</h2>
            <p>Legal reviews converted contracts; finance reviews invoice PDFs edited in Word; HR reviews offer letters. Route DOCX to the right reviewer before re-PDF. Version suffix in filename (<code>-legal-reviewed</code>) prevents accidental send of draft.</p>
            <p>After major edits, compress before email if DOCX re-export exceeds mailbox limits — see <a href="/research/pdf-compression-benchmark">PDF compression benchmark</a> for quality settings.</p>
            <p>Bookmark this page for your team's wiki — consistent PDF-to-Word steps reduce support tickets when onboarding new staff each quarter.</p>
            
            
            <h2>Failure messages</h2>
            <p><strong>Too large:</strong> compress or split. <strong>Invalid PDF:</strong> re-export source. <strong>Unreadable:</strong> re-scan don't only compress blur.</p>
            <h2>Archive discipline</h2>
            <p>Keep uncompressed master until upload or send succeeds — derivatives are disposable.</p>
            <h2>Compare tools</h2>
            <p><a href="/compare/smallpdf-alternative">Smallpdf</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/adobe-alternative">Adobe</a>.</p>
            
            
            <h2>Related guides</h2>
            <p>Editing guides cover crop, delete, annotate, highlight, rearrange pages, add text, fill forms, device workflows, blank-page cleanup, and rotate — step-by-step help for each task.</p>
            <p>Next troubleshooting wave: corrupt PDF, won’t open, print errors — bookmark <a href="/guides/pdf-tools">PDF tools hub</a> for full map.</p>
            
            
            <h2>More guides</h2>
            <p>Image, PowerPoint, and Word conversion guides, plus editing tutorials and competitor comparisons — all in one place.</p>
            <p>Main guides: <a href="/guides/images-to-pdf">images</a> · <a href="/guides/pdf-to-word">PDF to Word</a> · <a href="/guides/split-pdf">split</a> · <a href="/compare">compare</a>.</p>
            <h2>Post-action checklist</h2>
            <ol><li>Output opens in Chrome PDF viewer</li><li>Page order matches intent</li><li>Text selects if downstream edit needed</li><li>File size under email/portal cap</li><li>Master archived before deleting source</li></ol>
            <p>Bookmark the <a href="/guides/pdf-tools">PDF tools guide</a> and <a href="/compare">compare tools</a> for team onboarding — consistent tool choice reduces wrong-output support tickets.</p>
            
            
            <h2>Post-action checklist</h2>
            <ol><li>Output file opens in viewer</li><li>Text selects if required</li><li>Size under portal/email preset</li><li>Master archived</li><li>Correct tool used for next step (text vs Word vs OCR)</li></ol>
            <p>Bookmark the <a href="/guides/pdf-tools">PDF tools guide</a> and <a href="/compare">compare tools</a> for team onboarding — consistent tool choice reduces wrong-output support tickets.</p>
            <p>Re-run size checker after every derivative step — compress, split, or text export — before deleting the previous version from your working folder.</p>
            
            <p class="mt-4"><a href="/pdf/editpdf" class="btn btn-primary">Edit PDF</a> · <a href="/guides/edit-pdf">Edit PDF hub</a></p>
            """;

        private const string FillPdfFormOnline = """
            <h2>Fill PDF form online — government &amp; HR forms in browser</h2>
            <p>RatPDF <a href="/pdf/editpdf">Edit PDF</a> — Complete flat tax PDF fields and save filled copy for records.</p>
            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> Fill PDF form online — government &amp; HR forms in browser</figcaption></figure>
            
            <h2>Fillable vs flat forms</h2>
            <p>AcroForm fields preserve tab order when supported. Flat scans need positioned text — print alignment test before official submit.</p>
            <h2>Government portal rejection</h2>
            <p>Some portals reject changed fonts — test draft upload — keep blank template master.</p>
            <h2>HR and tax</h2>
            <p>Open enrollment and state tax PDFs — save filled copy outside portal — <a href="/guides/edit-pdf-forms">edit PDF forms guide</a>.</p>
            
            
            <h2>Immigration forms</h2>
            <p>Flat PDF — OCR if scan — fill — print-sign-scan upload where e-submit unavailable.</p>
            <h2>Vendor W-9</h2>
            <p>Fill — save — attach to ERP vendor record — encrypt email discouraged — portal preferred.</p>
            
            <div class="rp-mid-cta alert alert-primary my-4"><strong>Start now</strong> <a href="/pdf/editpdf" class="alert-link fw-semibold">Edit PDF →</a></div>
            
            <h2>Edit vs convert vs OCR decision tree</h2>
            <p><strong>Digital PDF minor fix:</strong> Edit PDF text overlay. <strong>Heavy rewrite:</strong> PDF to Word. <strong>Scan:</strong> OCR first. <strong>Wrong page order:</strong> Organize via merge queue. <strong>One page pull:</strong> Split PDF.</p>
            <h2>Form filling landscape</h2>
            <p>Government PDFs mix fillable AcroForm fields and flat scans. Fillable fields preserve tab order — flat forms need positioned text boxes — print-test alignment before official submit.</p>
            <h2>Scanned document edit chain</h2>
            <ol>
            <li>Scan 300 DPI grayscale upright</li>
            <li><a href="/pdf/ocrpdf">OCR PDF</a> — verify Ctrl+F finds key term</li>
            <li><a href="/pdf/editpdf">Edit PDF</a> — add date, signature image, stamp</li>
            <li>Optional <a href="/guides/compress-pdf-for-email">compress</a> before portal upload</li>
            </ol>
            <h2>Organize without desktop Acrobat</h2>
            <p>Reorder pages in merge tool — drag queue — single merge output — same engine as <a href="/guides/merge-pdf-custom-order">custom order merge</a>. Delete pages by omitting from queue not destructive edit on source.</p>
            <h2>Image overlay best practices</h2>
            <p>Logo PNG with transparency — place top-right — do not cover existing signature block. DPI 150 sufficient for screen PDF — 300 for print-bound proposals.</p>
            <h2>Security and audit</h2>
            <p>Edited PDF is new derivative — keep unedited master for legal hold — filename suffix <code>-edited-2026-04-02</code>. Flatten annotations before court filing if local rules require.</p>
            
            
            <h2>Browser edit limitations</h2>
            <p>RatPDF edit covers common SMB needs — text add, image stamp, form fill — not InDesign prepress — not Photoshop pixel surgery. For marketing brochure pixel edits return to design source.</p>
            <h2>Mobile edit caution</h2>
            <p>Fine form alignment on phone is painful — desktop for government forms — mobile OK for initial and date on consent PDF.</p>
            <h2>Password-protected PDFs</h2>
            <p>Unlock first: <a href="/guides/unlock-pdf">unlock PDF</a> — edit fails on encrypted open.</p>
            <h2>Compare vendors</h2>
            <p><a href="/compare/adobe-alternative">Adobe</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/smallpdf-alternative">Smallpdf</a> — evaluate form-fill on your hardest government PDF sample.</p>
            <h2>Split and extract coordination</h2>
            <p>Extract signature page before sending for countersign — <a href="/guides/extract-single-page-pdf">extract single page</a> — merge back after scan with <a href="/pdf/merge">Merge PDF</a>.</p>
            <h2>QA print test</h2>
            <p>Government forms reject misaligned fields — print one copy — hold to light against blank form — adjust coordinates before batch.</p>
            
            
            <h2>Edit cluster authority map</h2>
            <p>Editing guides cover crop, delete, annotate, highlight, rearrange pages, and device workflows — plus in-depth help for <a href="/guides/edit-pdf">edit PDF</a> and <a href="/guides/rotate-pdf">rotate PDF</a>. See also merge, split, and OCR guides.</p>
            <h2>Security and compliance</h2>
            <p>Edited derivatives are new files — keep immutable master — log who edited — confidential docs cleared from Downloads on shared PCs same day. HIPAA and legal hold: counsel approves browser edit on PHI or privilege docs.</p>
            <h2>Failure triage</h2>
            <p><strong>Cannot select text:</strong> OCR first. <strong>Wrong page count after delete:</strong> off-by-one viewer index — recount. <strong>Portal rejects filled form:</strong> print-test alignment — font mismatch — try flatten. <strong>Upload timeout:</strong> Wi-Fi — compress — split.</p>
            <h2>Research links</h2>
            <p><a href="/research/attachment-size-limits">Email attachment limits</a> · <a href="/research/pdf-tool-market-comparison">PDF tool market comparison</a> · <a href="/compare">Compare hub</a>.</p>
            
            
            <h2>Workflow deep dive — Fill PDF form online — government &amp; HR forms in browser</h2>
            <p>Browser workflow — no install — upload → process → download → verify in viewer before external send.</p>
            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> Fill PDF form online — government &amp; HR forms in browser</figcaption></figure>
            <h2>Mobile</h2>
            <p>Safari/Chrome on phone works — Wi-Fi for files over 15 MB — save to Files before portal upload.</p>
            <h2>Failures</h2>
            <p>Timeout: retry Wi-Fi · corrupt PDF: re-export source · password: <a href="/guides/unlock-pdf">unlock</a>.</p>
            <h2>Free tier</h2>
            <p>Three uses/day — <a href="/Subscription/Plans">plans</a> for volume.</p>
            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Open tool</strong> <a href="/pdf/editpdf" class="alert-link fw-semibold">Go →</a></div>
            
            
            <h2>Real example: HR onboarding packet</h2>
            <p>Flat I-9 scan — OCR — add start date field — employee initials — merge with handbook acknowledgment — compress — upload to HRIS.</p>
            <h2>Second example: property manager lease initialed</h2>
            <p>Scan signed lease pages — add initialed watermark on page 4 rider — re-compress for email to tenant.</p>
            <h2>Third example: proposal logo</h2>
            <p>Sales exports proposal PDF from CRM — add partner logo top-left — send to client — no return to InDesign.</p>
            <h2>Discovery page pull</h2>
            <p>Counsel needs only exhibit G from 200-page production — split page range 142-148 — email to expert witness — index in cover note.</p>
            <h2>Medical admin form</h2>
            <p>Clinic scan intake form — OCR — nurse adds checkbox marks — print for patient sign — scan again for chart.</p>
            <h2>Upgrade path</h2>
            <p>High-volume form shop — <a href="/Subscription/Plans">plans</a> — see the <a href="/guides/edit-pdf">edit PDF hub</a>.</p>
            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Edit your PDF</strong> <a href="/pdf/editpdf" class="alert-link fw-semibold">Edit PDF →</a></div>
            
            
            
            <h2>Browser vs desktop</h2>
            <p>RatPDF needs no install — IT-friendly — confidential docs review privacy policy retention window.</p>
            <h2>Chain tools</h2>
            <p>Convert → edit → compress → merge — pick order by deliverable — see the <a href="/guides/pdf-tools">PDF tools hub</a>.</p>
            <h2>Upgrade</h2>
            <p><a href="/Subscription/Plans">subscription plans</a> for daily caps on agency volume.</p>
            
            
            <h2>Cross-wave tool chain</h2>
            <p>Pick tool order by what you need to deliver. Example: photos → images PDF → OCR → edit date → compress → portal upload.</p>
            <h2>Free tier and upgrade</h2>
            <p>Three uses per day per tool on free tier — agency month-end exceeds cap — <a href="/Subscription/Plans">subscription plans</a> — predictable vs per-file credit packs.</p>
            <h2>Internal link discipline</h2>
            <p>Each guide links to related tools and comparisons so your team picks the right workflow.</p>
            <h2>Support triage</h2>
            <p>Wrong tool order causes bad output — OCR before edit on scans — compress after merge not before each file — train your team using the main tool guides.</p>
            
            
            <h2>QA before send</h2>
            <ol><li>Page count correct</li><li>Text selects if required</li><li>Images sharp at 150% zoom</li><li>File opens in Chrome PDF viewer</li><li>Size under email/portal cap</li></ol>
            <h2>Compare vendors</h2>
            <p><a href="/compare/smallpdf-alternative">Smallpdf</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/adobe-alternative">Adobe</a>.</p>
            
            
            <h2>Device matrix</h2>
            <p>Windows Edge, Mac Safari, iPhone Safari, Android Chrome — same account — no sync required — download to device storage before portal upload.</p>
            <h2>Retention hygiene</h2>
            <p>Clear Downloads on shared PC — contracts and medical admin PDFs are confidential — delete derivatives when task completes.</p>
            <h2>Filename and version control</h2>
            <p><code>Client-Doc-v2-edited.pdf</code> — never overwrite sent attachment — email thread references version.</p>
            <h2>Portal rejection loop</h2>
            <p>Reject → check size with <a href="/pdf-size-checker">size checker</a> → compress Less → split if still over → re-upload before session timeout.</p>
            <h2>Research links</h2>
            <p><a href="/research/attachment-size-limits">Attachment size limits</a> · <a href="/research/pdf-compression-benchmark">Compression benchmark</a> · <a href="/research/freelancer-invoicing-statistics">Invoicing statistics</a>.</p>
            <h2>Pillar bookmark set</h2>
            <p><a href="/guides/pdf-tools">PDF tools hub</a> · <a href="/guides/images-to-pdf">Images to PDF</a> · <a href="/guides/pdf-to-word">PDF to Word</a> · <a href="/guides/split-pdf">Split PDF</a> · <a href="/compare">Compare hub</a>.</p>
            
            
            <h2>Edit audit log</h2>
            <p>Log who edited which PDF derivative — timestamp — reason — matter number — supports litigation hold and SOX-style controls.</p>
            <h2>Flatten before external send</h2>
            <p>Some recipients see floating annotations differently — flatten or re-export PDF so logo and text boxes appear identical on all viewers.</p>
            <h2>Redaction before edit</h2>
            <p>Remove SSN and account numbers with <a href="/guides/pdf-redaction-permanent">permanent redaction</a> before adding new text — edit tool does not replace redaction workflow.</p>
            <h2>Training slide for staff</h2>
            <p>Three rules poster: OCR scans first — organize before merge — compress after combine — pin in Slack onboarding channel.</p>
            <h2>Department-specific examples</h2>
            <p><strong>HR:</strong> I-9 and handbook ack merge. <strong>Sales:</strong> logo on proposal. <strong>Legal:</strong> exhibit extract. <strong>Finance:</strong> initialed tax form. <strong>Ops:</strong> delivery note stamp.</p>
            <h2>Version rollback</h2>
            <p>Keep pre-edit master immutable — if client rejects edit — resend from master not undo in editor — filename version increments.</p>
            <h2>Collaboration handoff</h2>
            <p>Paralegal extracts page — attorney reviews in isolation — merge signed scan back — document handoff in matter management ticket.</p>
            <h2>Accessibility after edit</h2>
            <p>Added text may not be tagged — government accessibility filing may need tagged PDF specialist — SMB email deliverable usually exempt.</p>
            <h2>Pillar cross-links</h2>
            <p><a href="/guides/merge-pdf-online">merge PDF</a> · <a href="/guides/ocr-pdf">OCR PDF</a> · <a href="/guides/split-pdf">split hub</a> · <a href="/guides/pdf-tools">PDF tools hub</a>.</p>
            
            
            <h2>QA checklist — edit outputs</h2>
            <ol>
            <li>Page count matches intent after delete or rearrange</li>
            <li>Orientation correct on every page at thumbnail view</li>
            <li>Added text readable at 150% zoom and in print preview</li>
            <li>Annotations visible in Chrome PDF viewer and recipient test</li>
            <li>File size under email or portal cap — compress if needed</li>
            <li>Master archived before destructive delete</li>
            </ol>
            <h2>Department playbooks</h2>
            <p><strong>Legal:</strong> annotate review copy — master untouched. <strong>Finance:</strong> fill tax PDF — print-test. <strong>HR:</strong> OCR onboarding — merge ack. <strong>Sales:</strong> logo + date on proposal. <strong>Ops:</strong> delete blank feeder pages from scan batch.</p>
            <h2>Monthly volume</h2>
            <p>Track edit/remove jobs — exceed free tier twice in one week — finance approves <a href="/Subscription/Plans">subscription</a>.</p>
            <h2>Compare alternatives</h2>
            <p><a href="/compare/adobe-acrobat-alternative">Adobe Acrobat alternative</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/smallpdf-alternative">Smallpdf</a>.</p>
            
            
            <h2>Team rollout notes</h2>
            <p>Pin the main tool guides in your shared wiki — compress before portal, OCR before edit on scans, Word path only when ERP cannot reissue. New hires complete one sample file in first week using browser tools only — no desktop install ticket.</p>
            <h2>Support escalation path</h2>
            <p>Step 1: re-download output and open in Chrome viewer. Step 2: retry on Wi-Fi with smaller batch. Step 3: check <a href="/pdf-size-checker">size checker</a> preset. Step 4: compare tool choice on <a href="/compare">compare tools</a> if output quality insufficient.</p>
            <h2>Record retention</h2>
            <p>Keep source PDF until recipient confirms receipt — derivatives disposable after successful upload — confidential docs deleted from Downloads on shared machines same day.</p>
            <h2>Monthly volume planning</h2>
            <p>Track daily tool usage in spreadsheet — forecast upgrade need before month-end crunch — finance approves <a href="/Subscription/Plans">subscription</a> when free tier blocks twice in one week.</p>
            <h2>Incident log template</h2>
            <p>Date, source filename, tool used, error message, resolution — patterns reveal training gaps — share quarterly with ops lead.</p>
            
            
            <h2>Quick reference card</h2>
            <p>Scan → OCR → Edit. Digital → Edit direct. Reorder → Merge queue. One page → Split. Logo → Add image. Forms → Fill then print-test. Archive master before any derivative edit.</p>
            <p>Bookmark <a href="/guides/edit-pdf">edit PDF guide</a> for team onboarding — reduces wrong-tool support tickets.</p>
            <p>Wrong page order voids visa bundles — verify thumbnail strip before merge submit.</p>
            
            
            <h2>Related edit &amp; organize guides</h2>
            <ul>
            <li><a href="/guides/edit-scanned-pdf">Edit scanned PDF</a></li>
            <li><a href="/guides/organize-pdf-pages">Organize PDF pages</a></li>
            <li><a href="/guides/split-pdf-page-range">Split by page range</a></li>
            <li><a href="/guides/add-image-to-pdf">Add image to PDF</a></li>
            </ul>
            
            
            <h2>Edit-gap guides</h2>
            <ul>
            <li><a href="/guides/crop-pdf-online">Crop PDF online</a> · <a href="/guides/crop-pdf-without-adobe">Crop without Adobe</a></li>
            <li><a href="/guides/delete-pages-from-pdf">Delete pages</a> · <a href="/guides/remove-blank-pages-pdf">Remove blank pages</a></li>
            <li><a href="/guides/annotate-pdf-online">Annotate online</a> · <a href="/guides/annotate-pdf-free">Annotate free</a></li>
            <li><a href="/guides/highlight-pdf-online">Highlight PDF</a> · <a href="/guides/edit-pdf-text-online">Edit text</a></li>
            <li><a href="/guides/add-text-to-pdf">Add text</a> · <a href="/guides/fill-pdf-form-online">Fill form</a></li>
            <li><a href="/guides/rearrange-pdf-pages">Rearrange pages</a> · <a href="/guides/edit-pdf-without-acrobat">Without Acrobat</a></li>
            <li><a href="/guides/edit-pdf-on-mac">Edit on Mac</a> · <a href="/guides/edit-pdf-on-windows">Windows</a> · <a href="/guides/edit-pdf-on-iphone">iPhone</a></li>
            </ul>
            <h2>Pillar and organize links</h2>
            <p><a href="/guides/edit-pdf">Edit PDF guide</a> · <a href="/guides/rotate-pdf">Rotate PDF</a> · <a href="/guides/organize-pdf-pages">Organize pages</a> · <a href="/guides/merge-pdf">Merge guide</a> · <a href="/guides/split-pdf">Split guide</a> · <a href="/guides/ocr-pdf">OCR guide</a>.</p>
            
            
            <h2>Enterprise document workflows</h2>
            <p>Legal ops teams convert legacy contract PDFs during CLM migration — batch convert critical folders, prioritise active vendor agreements first. IT should approve browser upload policy for confidential docs.</p>

            <h2>Education sector</h2>
            <p>Faculty edit syllabus PDFs each semester — digital university PDFs convert cleanly; scanned course packs need OCR. Check campus IT data handling before upload.</p>

            <h2>Real estate</h2>
            <p>Lease amendments stored as PDF — convert to Word for redline, re-PDF for signature. Keep executed scan archived separately from working DOCX.</p>

            <h2>HR and offer letters</h2>
            <p>Template offer PDFs with merge fields sometimes break on convert — edit boilerplate in Word template instead of converting each hire if HRIS exports PDF.</p>

            <h2>Government RFP responses</h2>
            <p>Final submissions often must be PDF — use Word only for draft edits, export via <a href="/pdf/doctopdf">Word to PDF</a> for portal upload. Check RFP forbids track changes in submission.</p>

            <h2>Quality gates before client delivery</h2>
            <ol>
            <li>Spell-check in Word</li>
            <li>Compare page count vs source PDF</li>
            <li>Verify critical numbers (dates, amounts) unchanged</li>
            <li>Remove comments and track changes</li>
            <li>Export final PDF if deliverable format is PDF</li>
            </ol>

            <p>Pillar: <a href="/guides/pdf-to-word">PDF to Word guide</a> · Compare: <a href="/compare/smallpdf-alternative">Smallpdf alternative</a></p>
            
            
            <h2>Batch conversion hygiene</h2>
            <p>Converting 20 contracts? Use consistent naming <code>ClientName-contract-v1.docx</code>. Log source PDF hash if legal audit trail required.</p>

            <h2>Mobile upload caveats</h2>
            <p>Phone browsers work but large PDFs may timeout on cellular — use Wi-Fi or desktop for 50+ MB files.</p>

            <h2>Antivirus false positives</h2>
            <p>Some corporate proxies scan uploads — if blocked, try guest network or contact IT to allowlist ratpdf.com tool path.</p>

            <h2>Long-term archival</h2>
            <p>Store both source PDF and final DOCX/PDF pair — migrations sometimes need to re-edit decade-old contracts.</p>

            <h2>Regulatory and compliance edits</h2>
            <p>Privacy policies, SOC2 reports, and vendor security questionnaires arrive as PDF — convert to Word for comment, return PDF via <a href="/pdf/doctopdf">Word to PDF</a>. Legal should review material compliance wording changes.</p>

            <h2>Performance expectations</h2>
            <p>10-page digital PDF typically converts under two minutes; 200-page annual report may take longer — do not close tab during processing. Refresh only after timeout message.</p>
            
            
            <h2>Document type quick reference</h2>
            <p><strong>Contracts:</strong> digital PDF, track changes in Word. <strong>Invoices:</strong> table-heavy — check sums. <strong>Scanned forms:</strong> OCR first. <strong>Marketing PDFs:</strong> expect image blocks. <strong>Manuals:</strong> headings usually survive — update TOC in Word after edits.</p>
            <p>Upgrade for volume: <a href="/Subscription/Plans">subscription plans</a>. Pillar: <a href="/guides/pdf-to-word">PDF to Word</a>.</p>

            <h2>Stakeholder sign-off matrix</h2>
            <p>Legal reviews converted contracts; finance reviews invoice PDFs edited in Word; HR reviews offer letters. Route DOCX to the right reviewer before re-PDF. Version suffix in filename (<code>-legal-reviewed</code>) prevents accidental send of draft.</p>
            <p>After major edits, compress before email if DOCX re-export exceeds mailbox limits — see <a href="/research/pdf-compression-benchmark">PDF compression benchmark</a> for quality settings.</p>
            <p>Bookmark this page for your team's wiki — consistent PDF-to-Word steps reduce support tickets when onboarding new staff each quarter.</p>
            
            
            <h2>Failure messages</h2>
            <p><strong>Too large:</strong> compress or split. <strong>Invalid PDF:</strong> re-export source. <strong>Unreadable:</strong> re-scan don't only compress blur.</p>
            <h2>Archive discipline</h2>
            <p>Keep uncompressed master until upload or send succeeds — derivatives are disposable.</p>
            <h2>Compare tools</h2>
            <p><a href="/compare/smallpdf-alternative">Smallpdf</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/adobe-alternative">Adobe</a>.</p>
            
            
            <h2>Related guides</h2>
            <p>Editing guides cover crop, delete, annotate, highlight, rearrange pages, add text, fill forms, device workflows, blank-page cleanup, and rotate — step-by-step help for each task.</p>
            <p>Next troubleshooting wave: corrupt PDF, won’t open, print errors — bookmark <a href="/guides/pdf-tools">PDF tools hub</a> for full map.</p>
            
            
            <h2>More guides</h2>
            <p>Image, PowerPoint, and Word conversion guides, plus editing tutorials and competitor comparisons — all in one place.</p>
            <p>Main guides: <a href="/guides/images-to-pdf">images</a> · <a href="/guides/pdf-to-word">PDF to Word</a> · <a href="/guides/split-pdf">split</a> · <a href="/compare">compare</a>.</p>
            <h2>Post-action checklist</h2>
            <ol><li>Output opens in Chrome PDF viewer</li><li>Page order matches intent</li><li>Text selects if downstream edit needed</li><li>File size under email/portal cap</li><li>Master archived before deleting source</li></ol>
            <p>Bookmark the <a href="/guides/pdf-tools">PDF tools guide</a> and <a href="/compare">compare tools</a> for team onboarding — consistent tool choice reduces wrong-output support tickets.</p>
            
            
            <h2>Post-action checklist</h2>
            <ol><li>Output file opens in viewer</li><li>Text selects if required</li><li>Size under portal/email preset</li><li>Master archived</li><li>Correct tool used for next step (text vs Word vs OCR)</li></ol>
            <p>Bookmark the <a href="/guides/pdf-tools">PDF tools guide</a> and <a href="/compare">compare tools</a> for team onboarding — consistent tool choice reduces wrong-output support tickets.</p>
            <p>Re-run size checker after every derivative step — compress, split, or text export — before deleting the previous version from your working folder.</p>
            
            <p class="mt-4"><a href="/pdf/editpdf" class="btn btn-primary">Edit PDF</a> · <a href="/guides/edit-pdf">Edit PDF hub</a></p>
            """;

        private const string EditPdfOnMac = """
            <h2>Edit PDF on Mac — Safari workflow without Acrobat</h2>
            <p>RatPDF <a href="/pdf/editpdf">Edit PDF</a> — MacBook user adds initials to NDA in Safari before AirDrop to counsel.</p>
            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> Edit PDF on Mac — Safari workflow without Acrobat</figcaption></figure>
            
            <h2>Safari vs Chrome on Mac</h2>
            <p>Both work — Wi-Fi for files over 15 MB — save to Downloads then Files before portal upload from iCloud.</p>
            <h2>Preview.app limitation</h2>
            <p>Preview markup is local — RatPDF for consistent team workflow and invoice-adjacent PDF stack.</p>
            <h2>Handoff to iPhone</h2>
            <p>Start on Mac — AirDrop partial to phone for signature image insert — see <a href="/guides/edit-pdf-on-iphone">iPhone edit guide</a>.</p>
            
            
            <h2>Apple Silicon performance</h2>
            <p>M-series Mac handles 50 MB PDF smoothly — fan noise normal on OCR chain — edit after OCR completes.</p>
            <h2>iCloud Downloads</h2>
            <p>Save edited PDF to iCloud Drive — share link — not Mail for confidential docs.</p>
            
            <div class="rp-mid-cta alert alert-primary my-4"><strong>Start now</strong> <a href="/pdf/editpdf" class="alert-link fw-semibold">Edit PDF →</a></div>
            
            <h2>Edit vs convert vs OCR decision tree</h2>
            <p><strong>Digital PDF minor fix:</strong> Edit PDF text overlay. <strong>Heavy rewrite:</strong> PDF to Word. <strong>Scan:</strong> OCR first. <strong>Wrong page order:</strong> Organize via merge queue. <strong>One page pull:</strong> Split PDF.</p>
            <h2>Form filling landscape</h2>
            <p>Government PDFs mix fillable AcroForm fields and flat scans. Fillable fields preserve tab order — flat forms need positioned text boxes — print-test alignment before official submit.</p>
            <h2>Scanned document edit chain</h2>
            <ol>
            <li>Scan 300 DPI grayscale upright</li>
            <li><a href="/pdf/ocrpdf">OCR PDF</a> — verify Ctrl+F finds key term</li>
            <li><a href="/pdf/editpdf">Edit PDF</a> — add date, signature image, stamp</li>
            <li>Optional <a href="/guides/compress-pdf-for-email">compress</a> before portal upload</li>
            </ol>
            <h2>Organize without desktop Acrobat</h2>
            <p>Reorder pages in merge tool — drag queue — single merge output — same engine as <a href="/guides/merge-pdf-custom-order">custom order merge</a>. Delete pages by omitting from queue not destructive edit on source.</p>
            <h2>Image overlay best practices</h2>
            <p>Logo PNG with transparency — place top-right — do not cover existing signature block. DPI 150 sufficient for screen PDF — 300 for print-bound proposals.</p>
            <h2>Security and audit</h2>
            <p>Edited PDF is new derivative — keep unedited master for legal hold — filename suffix <code>-edited-2026-04-02</code>. Flatten annotations before court filing if local rules require.</p>
            
            
            <h2>Browser edit limitations</h2>
            <p>RatPDF edit covers common SMB needs — text add, image stamp, form fill — not InDesign prepress — not Photoshop pixel surgery. For marketing brochure pixel edits return to design source.</p>
            <h2>Mobile edit caution</h2>
            <p>Fine form alignment on phone is painful — desktop for government forms — mobile OK for initial and date on consent PDF.</p>
            <h2>Password-protected PDFs</h2>
            <p>Unlock first: <a href="/guides/unlock-pdf">unlock PDF</a> — edit fails on encrypted open.</p>
            <h2>Compare vendors</h2>
            <p><a href="/compare/adobe-alternative">Adobe</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/smallpdf-alternative">Smallpdf</a> — evaluate form-fill on your hardest government PDF sample.</p>
            <h2>Split and extract coordination</h2>
            <p>Extract signature page before sending for countersign — <a href="/guides/extract-single-page-pdf">extract single page</a> — merge back after scan with <a href="/pdf/merge">Merge PDF</a>.</p>
            <h2>QA print test</h2>
            <p>Government forms reject misaligned fields — print one copy — hold to light against blank form — adjust coordinates before batch.</p>
            
            
            <h2>Edit cluster authority map</h2>
            <p>Editing guides cover crop, delete, annotate, highlight, rearrange pages, and device workflows — plus in-depth help for <a href="/guides/edit-pdf">edit PDF</a> and <a href="/guides/rotate-pdf">rotate PDF</a>. See also merge, split, and OCR guides.</p>
            <h2>Security and compliance</h2>
            <p>Edited derivatives are new files — keep immutable master — log who edited — confidential docs cleared from Downloads on shared PCs same day. HIPAA and legal hold: counsel approves browser edit on PHI or privilege docs.</p>
            <h2>Failure triage</h2>
            <p><strong>Cannot select text:</strong> OCR first. <strong>Wrong page count after delete:</strong> off-by-one viewer index — recount. <strong>Portal rejects filled form:</strong> print-test alignment — font mismatch — try flatten. <strong>Upload timeout:</strong> Wi-Fi — compress — split.</p>
            <h2>Research links</h2>
            <p><a href="/research/attachment-size-limits">Email attachment limits</a> · <a href="/research/pdf-tool-market-comparison">PDF tool market comparison</a> · <a href="/compare">Compare hub</a>.</p>
            
            
            <h2>Workflow deep dive — Edit PDF on Mac — Safari workflow without Acrobat</h2>
            <p>Browser workflow — no install — upload → process → download → verify in viewer before external send.</p>
            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> Edit PDF on Mac — Safari workflow without Acrobat</figcaption></figure>
            <h2>Mobile</h2>
            <p>Safari/Chrome on phone works — Wi-Fi for files over 15 MB — save to Files before portal upload.</p>
            <h2>Failures</h2>
            <p>Timeout: retry Wi-Fi · corrupt PDF: re-export source · password: <a href="/guides/unlock-pdf">unlock</a>.</p>
            <h2>Free tier</h2>
            <p>Three uses/day — <a href="/Subscription/Plans">plans</a> for volume.</p>
            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Open tool</strong> <a href="/pdf/editpdf" class="alert-link fw-semibold">Go →</a></div>
            
            
            <h2>Real example: HR onboarding packet</h2>
            <p>Flat I-9 scan — OCR — add start date field — employee initials — merge with handbook acknowledgment — compress — upload to HRIS.</p>
            <h2>Second example: property manager lease initialed</h2>
            <p>Scan signed lease pages — add initialed watermark on page 4 rider — re-compress for email to tenant.</p>
            <h2>Third example: proposal logo</h2>
            <p>Sales exports proposal PDF from CRM — add partner logo top-left — send to client — no return to InDesign.</p>
            <h2>Discovery page pull</h2>
            <p>Counsel needs only exhibit G from 200-page production — split page range 142-148 — email to expert witness — index in cover note.</p>
            <h2>Medical admin form</h2>
            <p>Clinic scan intake form — OCR — nurse adds checkbox marks — print for patient sign — scan again for chart.</p>
            <h2>Upgrade path</h2>
            <p>High-volume form shop — <a href="/Subscription/Plans">plans</a> — see the <a href="/guides/edit-pdf">edit PDF hub</a>.</p>
            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Edit your PDF</strong> <a href="/pdf/editpdf" class="alert-link fw-semibold">Edit PDF →</a></div>
            
            
            
            <h2>Browser vs desktop</h2>
            <p>RatPDF needs no install — IT-friendly — confidential docs review privacy policy retention window.</p>
            <h2>Chain tools</h2>
            <p>Convert → edit → compress → merge — pick order by deliverable — see the <a href="/guides/pdf-tools">PDF tools hub</a>.</p>
            <h2>Upgrade</h2>
            <p><a href="/Subscription/Plans">subscription plans</a> for daily caps on agency volume.</p>
            
            
            <h2>Cross-wave tool chain</h2>
            <p>Pick tool order by what you need to deliver. Example: photos → images PDF → OCR → edit date → compress → portal upload.</p>
            <h2>Free tier and upgrade</h2>
            <p>Three uses per day per tool on free tier — agency month-end exceeds cap — <a href="/Subscription/Plans">subscription plans</a> — predictable vs per-file credit packs.</p>
            <h2>Internal link discipline</h2>
            <p>Each guide links to related tools and comparisons so your team picks the right workflow.</p>
            <h2>Support triage</h2>
            <p>Wrong tool order causes bad output — OCR before edit on scans — compress after merge not before each file — train your team using the main tool guides.</p>
            
            
            <h2>QA before send</h2>
            <ol><li>Page count correct</li><li>Text selects if required</li><li>Images sharp at 150% zoom</li><li>File opens in Chrome PDF viewer</li><li>Size under email/portal cap</li></ol>
            <h2>Compare vendors</h2>
            <p><a href="/compare/smallpdf-alternative">Smallpdf</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/adobe-alternative">Adobe</a>.</p>
            
            
            <h2>Device matrix</h2>
            <p>Windows Edge, Mac Safari, iPhone Safari, Android Chrome — same account — no sync required — download to device storage before portal upload.</p>
            <h2>Retention hygiene</h2>
            <p>Clear Downloads on shared PC — contracts and medical admin PDFs are confidential — delete derivatives when task completes.</p>
            <h2>Filename and version control</h2>
            <p><code>Client-Doc-v2-edited.pdf</code> — never overwrite sent attachment — email thread references version.</p>
            <h2>Portal rejection loop</h2>
            <p>Reject → check size with <a href="/pdf-size-checker">size checker</a> → compress Less → split if still over → re-upload before session timeout.</p>
            <h2>Research links</h2>
            <p><a href="/research/attachment-size-limits">Attachment size limits</a> · <a href="/research/pdf-compression-benchmark">Compression benchmark</a> · <a href="/research/freelancer-invoicing-statistics">Invoicing statistics</a>.</p>
            <h2>Pillar bookmark set</h2>
            <p><a href="/guides/pdf-tools">PDF tools hub</a> · <a href="/guides/images-to-pdf">Images to PDF</a> · <a href="/guides/pdf-to-word">PDF to Word</a> · <a href="/guides/split-pdf">Split PDF</a> · <a href="/compare">Compare hub</a>.</p>
            
            
            <h2>Edit audit log</h2>
            <p>Log who edited which PDF derivative — timestamp — reason — matter number — supports litigation hold and SOX-style controls.</p>
            <h2>Flatten before external send</h2>
            <p>Some recipients see floating annotations differently — flatten or re-export PDF so logo and text boxes appear identical on all viewers.</p>
            <h2>Redaction before edit</h2>
            <p>Remove SSN and account numbers with <a href="/guides/pdf-redaction-permanent">permanent redaction</a> before adding new text — edit tool does not replace redaction workflow.</p>
            <h2>Training slide for staff</h2>
            <p>Three rules poster: OCR scans first — organize before merge — compress after combine — pin in Slack onboarding channel.</p>
            <h2>Department-specific examples</h2>
            <p><strong>HR:</strong> I-9 and handbook ack merge. <strong>Sales:</strong> logo on proposal. <strong>Legal:</strong> exhibit extract. <strong>Finance:</strong> initialed tax form. <strong>Ops:</strong> delivery note stamp.</p>
            <h2>Version rollback</h2>
            <p>Keep pre-edit master immutable — if client rejects edit — resend from master not undo in editor — filename version increments.</p>
            <h2>Collaboration handoff</h2>
            <p>Paralegal extracts page — attorney reviews in isolation — merge signed scan back — document handoff in matter management ticket.</p>
            <h2>Accessibility after edit</h2>
            <p>Added text may not be tagged — government accessibility filing may need tagged PDF specialist — SMB email deliverable usually exempt.</p>
            <h2>Pillar cross-links</h2>
            <p><a href="/guides/merge-pdf-online">merge PDF</a> · <a href="/guides/ocr-pdf">OCR PDF</a> · <a href="/guides/split-pdf">split hub</a> · <a href="/guides/pdf-tools">PDF tools hub</a>.</p>
            
            
            <h2>QA checklist — edit outputs</h2>
            <ol>
            <li>Page count matches intent after delete or rearrange</li>
            <li>Orientation correct on every page at thumbnail view</li>
            <li>Added text readable at 150% zoom and in print preview</li>
            <li>Annotations visible in Chrome PDF viewer and recipient test</li>
            <li>File size under email or portal cap — compress if needed</li>
            <li>Master archived before destructive delete</li>
            </ol>
            <h2>Department playbooks</h2>
            <p><strong>Legal:</strong> annotate review copy — master untouched. <strong>Finance:</strong> fill tax PDF — print-test. <strong>HR:</strong> OCR onboarding — merge ack. <strong>Sales:</strong> logo + date on proposal. <strong>Ops:</strong> delete blank feeder pages from scan batch.</p>
            <h2>Monthly volume</h2>
            <p>Track edit/remove jobs — exceed free tier twice in one week — finance approves <a href="/Subscription/Plans">subscription</a>.</p>
            <h2>Compare alternatives</h2>
            <p><a href="/compare/adobe-acrobat-alternative">Adobe Acrobat alternative</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/smallpdf-alternative">Smallpdf</a>.</p>
            
            
            <h2>Team rollout notes</h2>
            <p>Pin the main tool guides in your shared wiki — compress before portal, OCR before edit on scans, Word path only when ERP cannot reissue. New hires complete one sample file in first week using browser tools only — no desktop install ticket.</p>
            <h2>Support escalation path</h2>
            <p>Step 1: re-download output and open in Chrome viewer. Step 2: retry on Wi-Fi with smaller batch. Step 3: check <a href="/pdf-size-checker">size checker</a> preset. Step 4: compare tool choice on <a href="/compare">compare tools</a> if output quality insufficient.</p>
            <h2>Record retention</h2>
            <p>Keep source PDF until recipient confirms receipt — derivatives disposable after successful upload — confidential docs deleted from Downloads on shared machines same day.</p>
            <h2>Monthly volume planning</h2>
            <p>Track daily tool usage in spreadsheet — forecast upgrade need before month-end crunch — finance approves <a href="/Subscription/Plans">subscription</a> when free tier blocks twice in one week.</p>
            <h2>Incident log template</h2>
            <p>Date, source filename, tool used, error message, resolution — patterns reveal training gaps — share quarterly with ops lead.</p>
            
            
            <h2>Quick reference card</h2>
            <p>Scan → OCR → Edit. Digital → Edit direct. Reorder → Merge queue. One page → Split. Logo → Add image. Forms → Fill then print-test. Archive master before any derivative edit.</p>
            <p>Bookmark <a href="/guides/edit-pdf">edit PDF guide</a> for team onboarding — reduces wrong-tool support tickets.</p>
            <p>Wrong page order voids visa bundles — verify thumbnail strip before merge submit.</p>
            
            
            <h2>Related edit &amp; organize guides</h2>
            <ul>
            <li><a href="/guides/edit-scanned-pdf">Edit scanned PDF</a></li>
            <li><a href="/guides/organize-pdf-pages">Organize PDF pages</a></li>
            <li><a href="/guides/split-pdf-page-range">Split by page range</a></li>
            <li><a href="/guides/add-image-to-pdf">Add image to PDF</a></li>
            </ul>
            
            
            <h2>Edit-gap guides</h2>
            <ul>
            <li><a href="/guides/crop-pdf-online">Crop PDF online</a> · <a href="/guides/crop-pdf-without-adobe">Crop without Adobe</a></li>
            <li><a href="/guides/delete-pages-from-pdf">Delete pages</a> · <a href="/guides/remove-blank-pages-pdf">Remove blank pages</a></li>
            <li><a href="/guides/annotate-pdf-online">Annotate online</a> · <a href="/guides/annotate-pdf-free">Annotate free</a></li>
            <li><a href="/guides/highlight-pdf-online">Highlight PDF</a> · <a href="/guides/edit-pdf-text-online">Edit text</a></li>
            <li><a href="/guides/add-text-to-pdf">Add text</a> · <a href="/guides/fill-pdf-form-online">Fill form</a></li>
            <li><a href="/guides/rearrange-pdf-pages">Rearrange pages</a> · <a href="/guides/edit-pdf-without-acrobat">Without Acrobat</a></li>
            <li><a href="/guides/edit-pdf-on-mac">Edit on Mac</a> · <a href="/guides/edit-pdf-on-windows">Windows</a> · <a href="/guides/edit-pdf-on-iphone">iPhone</a></li>
            </ul>
            <h2>Pillar and organize links</h2>
            <p><a href="/guides/edit-pdf">Edit PDF guide</a> · <a href="/guides/rotate-pdf">Rotate PDF</a> · <a href="/guides/organize-pdf-pages">Organize pages</a> · <a href="/guides/merge-pdf">Merge guide</a> · <a href="/guides/split-pdf">Split guide</a> · <a href="/guides/ocr-pdf">OCR guide</a>.</p>
            
            
            <h2>Enterprise document workflows</h2>
            <p>Legal ops teams convert legacy contract PDFs during CLM migration — batch convert critical folders, prioritise active vendor agreements first. IT should approve browser upload policy for confidential docs.</p>

            <h2>Education sector</h2>
            <p>Faculty edit syllabus PDFs each semester — digital university PDFs convert cleanly; scanned course packs need OCR. Check campus IT data handling before upload.</p>

            <h2>Real estate</h2>
            <p>Lease amendments stored as PDF — convert to Word for redline, re-PDF for signature. Keep executed scan archived separately from working DOCX.</p>

            <h2>HR and offer letters</h2>
            <p>Template offer PDFs with merge fields sometimes break on convert — edit boilerplate in Word template instead of converting each hire if HRIS exports PDF.</p>

            <h2>Government RFP responses</h2>
            <p>Final submissions often must be PDF — use Word only for draft edits, export via <a href="/pdf/doctopdf">Word to PDF</a> for portal upload. Check RFP forbids track changes in submission.</p>

            <h2>Quality gates before client delivery</h2>
            <ol>
            <li>Spell-check in Word</li>
            <li>Compare page count vs source PDF</li>
            <li>Verify critical numbers (dates, amounts) unchanged</li>
            <li>Remove comments and track changes</li>
            <li>Export final PDF if deliverable format is PDF</li>
            </ol>

            <p>Pillar: <a href="/guides/pdf-to-word">PDF to Word guide</a> · Compare: <a href="/compare/smallpdf-alternative">Smallpdf alternative</a></p>
            
            
            <h2>Batch conversion hygiene</h2>
            <p>Converting 20 contracts? Use consistent naming <code>ClientName-contract-v1.docx</code>. Log source PDF hash if legal audit trail required.</p>

            <h2>Mobile upload caveats</h2>
            <p>Phone browsers work but large PDFs may timeout on cellular — use Wi-Fi or desktop for 50+ MB files.</p>

            <h2>Antivirus false positives</h2>
            <p>Some corporate proxies scan uploads — if blocked, try guest network or contact IT to allowlist ratpdf.com tool path.</p>

            <h2>Long-term archival</h2>
            <p>Store both source PDF and final DOCX/PDF pair — migrations sometimes need to re-edit decade-old contracts.</p>

            <h2>Regulatory and compliance edits</h2>
            <p>Privacy policies, SOC2 reports, and vendor security questionnaires arrive as PDF — convert to Word for comment, return PDF via <a href="/pdf/doctopdf">Word to PDF</a>. Legal should review material compliance wording changes.</p>

            <h2>Performance expectations</h2>
            <p>10-page digital PDF typically converts under two minutes; 200-page annual report may take longer — do not close tab during processing. Refresh only after timeout message.</p>
            
            
            <h2>Document type quick reference</h2>
            <p><strong>Contracts:</strong> digital PDF, track changes in Word. <strong>Invoices:</strong> table-heavy — check sums. <strong>Scanned forms:</strong> OCR first. <strong>Marketing PDFs:</strong> expect image blocks. <strong>Manuals:</strong> headings usually survive — update TOC in Word after edits.</p>
            <p>Upgrade for volume: <a href="/Subscription/Plans">subscription plans</a>. Pillar: <a href="/guides/pdf-to-word">PDF to Word</a>.</p>

            <h2>Stakeholder sign-off matrix</h2>
            <p>Legal reviews converted contracts; finance reviews invoice PDFs edited in Word; HR reviews offer letters. Route DOCX to the right reviewer before re-PDF. Version suffix in filename (<code>-legal-reviewed</code>) prevents accidental send of draft.</p>
            <p>After major edits, compress before email if DOCX re-export exceeds mailbox limits — see <a href="/research/pdf-compression-benchmark">PDF compression benchmark</a> for quality settings.</p>
            <p>Bookmark this page for your team's wiki — consistent PDF-to-Word steps reduce support tickets when onboarding new staff each quarter.</p>
            
            
            <h2>Failure messages</h2>
            <p><strong>Too large:</strong> compress or split. <strong>Invalid PDF:</strong> re-export source. <strong>Unreadable:</strong> re-scan don't only compress blur.</p>
            <h2>Archive discipline</h2>
            <p>Keep uncompressed master until upload or send succeeds — derivatives are disposable.</p>
            <h2>Compare tools</h2>
            <p><a href="/compare/smallpdf-alternative">Smallpdf</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/adobe-alternative">Adobe</a>.</p>
            
            
            <h2>Related guides</h2>
            <p>Editing guides cover crop, delete, annotate, highlight, rearrange pages, add text, fill forms, device workflows, blank-page cleanup, and rotate — step-by-step help for each task.</p>
            <p>Next troubleshooting wave: corrupt PDF, won’t open, print errors — bookmark <a href="/guides/pdf-tools">PDF tools hub</a> for full map.</p>
            
            
            <h2>More guides</h2>
            <p>Image, PowerPoint, and Word conversion guides, plus editing tutorials and competitor comparisons — all in one place.</p>
            <p>Main guides: <a href="/guides/images-to-pdf">images</a> · <a href="/guides/pdf-to-word">PDF to Word</a> · <a href="/guides/split-pdf">split</a> · <a href="/compare">compare</a>.</p>
            <h2>Post-action checklist</h2>
            <ol><li>Output opens in Chrome PDF viewer</li><li>Page order matches intent</li><li>Text selects if downstream edit needed</li><li>File size under email/portal cap</li><li>Master archived before deleting source</li></ol>
            <p>Bookmark the <a href="/guides/pdf-tools">PDF tools guide</a> and <a href="/compare">compare tools</a> for team onboarding — consistent tool choice reduces wrong-output support tickets.</p>
            
            
            <h2>Post-action checklist</h2>
            <ol><li>Output file opens in viewer</li><li>Text selects if required</li><li>Size under portal/email preset</li><li>Master archived</li><li>Correct tool used for next step (text vs Word vs OCR)</li></ol>
            <p>Bookmark the <a href="/guides/pdf-tools">PDF tools guide</a> and <a href="/compare">compare tools</a> for team onboarding — consistent tool choice reduces wrong-output support tickets.</p>
            <p>Re-run size checker after every derivative step — compress, split, or text export — before deleting the previous version from your working folder.</p>
            
            <p class="mt-4"><a href="/pdf/editpdf" class="btn btn-primary">Edit PDF</a> · <a href="/guides/edit-pdf">Edit PDF hub</a></p>
            """;

        private const string EditPdfOnWindows = """
            <h2>Edit PDF on Windows — Edge &amp; Chrome browser editor</h2>
            <p>RatPDF <a href="/pdf/editpdf">Edit PDF</a> — Windows 11 user stamps approved on PO PDF without IT install ticket.</p>
            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> Edit PDF on Windows — Edge &amp; Chrome browser editor</figcaption></figure>
            
            <h2>Edge and Chrome</h2>
            <p>Corporate Edge policy may block uploads — IT allowlist ratpdf.com — same workflow as Chrome.</p>
            <h2>No Acrobat install ticket</h2>
            <p>IT-friendly browser path — document in security questionnaire — HTTPS and retention policy links.</p>
            <h2>Print to PDF trap</h2>
            <p>Word print-to-PDF loses links — use <a href="/pdf/doctopdf">Word to PDF</a> then edit — not print driver for proposals.</p>
            
            
            <h2>Windows 10 EOL planning</h2>
            <p>Browser editor survives OS upgrade — no legacy Acrobat XI compatibility issues.</p>
            <h2>Dual monitor</h2>
            <p>Form fill on one screen — reference data on other — reduces typo rate on long tax PDFs.</p>
            
            <div class="rp-mid-cta alert alert-primary my-4"><strong>Start now</strong> <a href="/pdf/editpdf" class="alert-link fw-semibold">Edit PDF →</a></div>
            
            <h2>Edit vs convert vs OCR decision tree</h2>
            <p><strong>Digital PDF minor fix:</strong> Edit PDF text overlay. <strong>Heavy rewrite:</strong> PDF to Word. <strong>Scan:</strong> OCR first. <strong>Wrong page order:</strong> Organize via merge queue. <strong>One page pull:</strong> Split PDF.</p>
            <h2>Form filling landscape</h2>
            <p>Government PDFs mix fillable AcroForm fields and flat scans. Fillable fields preserve tab order — flat forms need positioned text boxes — print-test alignment before official submit.</p>
            <h2>Scanned document edit chain</h2>
            <ol>
            <li>Scan 300 DPI grayscale upright</li>
            <li><a href="/pdf/ocrpdf">OCR PDF</a> — verify Ctrl+F finds key term</li>
            <li><a href="/pdf/editpdf">Edit PDF</a> — add date, signature image, stamp</li>
            <li>Optional <a href="/guides/compress-pdf-for-email">compress</a> before portal upload</li>
            </ol>
            <h2>Organize without desktop Acrobat</h2>
            <p>Reorder pages in merge tool — drag queue — single merge output — same engine as <a href="/guides/merge-pdf-custom-order">custom order merge</a>. Delete pages by omitting from queue not destructive edit on source.</p>
            <h2>Image overlay best practices</h2>
            <p>Logo PNG with transparency — place top-right — do not cover existing signature block. DPI 150 sufficient for screen PDF — 300 for print-bound proposals.</p>
            <h2>Security and audit</h2>
            <p>Edited PDF is new derivative — keep unedited master for legal hold — filename suffix <code>-edited-2026-04-02</code>. Flatten annotations before court filing if local rules require.</p>
            
            
            <h2>Browser edit limitations</h2>
            <p>RatPDF edit covers common SMB needs — text add, image stamp, form fill — not InDesign prepress — not Photoshop pixel surgery. For marketing brochure pixel edits return to design source.</p>
            <h2>Mobile edit caution</h2>
            <p>Fine form alignment on phone is painful — desktop for government forms — mobile OK for initial and date on consent PDF.</p>
            <h2>Password-protected PDFs</h2>
            <p>Unlock first: <a href="/guides/unlock-pdf">unlock PDF</a> — edit fails on encrypted open.</p>
            <h2>Compare vendors</h2>
            <p><a href="/compare/adobe-alternative">Adobe</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/smallpdf-alternative">Smallpdf</a> — evaluate form-fill on your hardest government PDF sample.</p>
            <h2>Split and extract coordination</h2>
            <p>Extract signature page before sending for countersign — <a href="/guides/extract-single-page-pdf">extract single page</a> — merge back after scan with <a href="/pdf/merge">Merge PDF</a>.</p>
            <h2>QA print test</h2>
            <p>Government forms reject misaligned fields — print one copy — hold to light against blank form — adjust coordinates before batch.</p>
            
            
            <h2>Edit cluster authority map</h2>
            <p>Editing guides cover crop, delete, annotate, highlight, rearrange pages, and device workflows — plus in-depth help for <a href="/guides/edit-pdf">edit PDF</a> and <a href="/guides/rotate-pdf">rotate PDF</a>. See also merge, split, and OCR guides.</p>
            <h2>Security and compliance</h2>
            <p>Edited derivatives are new files — keep immutable master — log who edited — confidential docs cleared from Downloads on shared PCs same day. HIPAA and legal hold: counsel approves browser edit on PHI or privilege docs.</p>
            <h2>Failure triage</h2>
            <p><strong>Cannot select text:</strong> OCR first. <strong>Wrong page count after delete:</strong> off-by-one viewer index — recount. <strong>Portal rejects filled form:</strong> print-test alignment — font mismatch — try flatten. <strong>Upload timeout:</strong> Wi-Fi — compress — split.</p>
            <h2>Research links</h2>
            <p><a href="/research/attachment-size-limits">Email attachment limits</a> · <a href="/research/pdf-tool-market-comparison">PDF tool market comparison</a> · <a href="/compare">Compare hub</a>.</p>
            
            
            <h2>Workflow deep dive — Edit PDF on Windows — Edge &amp; Chrome browser editor</h2>
            <p>Browser workflow — no install — upload → process → download → verify in viewer before external send.</p>
            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> Edit PDF on Windows — Edge &amp; Chrome browser editor</figcaption></figure>
            <h2>Mobile</h2>
            <p>Safari/Chrome on phone works — Wi-Fi for files over 15 MB — save to Files before portal upload.</p>
            <h2>Failures</h2>
            <p>Timeout: retry Wi-Fi · corrupt PDF: re-export source · password: <a href="/guides/unlock-pdf">unlock</a>.</p>
            <h2>Free tier</h2>
            <p>Three uses/day — <a href="/Subscription/Plans">plans</a> for volume.</p>
            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Open tool</strong> <a href="/pdf/editpdf" class="alert-link fw-semibold">Go →</a></div>
            
            
            <h2>Real example: HR onboarding packet</h2>
            <p>Flat I-9 scan — OCR — add start date field — employee initials — merge with handbook acknowledgment — compress — upload to HRIS.</p>
            <h2>Second example: property manager lease initialed</h2>
            <p>Scan signed lease pages — add initialed watermark on page 4 rider — re-compress for email to tenant.</p>
            <h2>Third example: proposal logo</h2>
            <p>Sales exports proposal PDF from CRM — add partner logo top-left — send to client — no return to InDesign.</p>
            <h2>Discovery page pull</h2>
            <p>Counsel needs only exhibit G from 200-page production — split page range 142-148 — email to expert witness — index in cover note.</p>
            <h2>Medical admin form</h2>
            <p>Clinic scan intake form — OCR — nurse adds checkbox marks — print for patient sign — scan again for chart.</p>
            <h2>Upgrade path</h2>
            <p>High-volume form shop — <a href="/Subscription/Plans">plans</a> — see the <a href="/guides/edit-pdf">edit PDF hub</a>.</p>
            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Edit your PDF</strong> <a href="/pdf/editpdf" class="alert-link fw-semibold">Edit PDF →</a></div>
            
            
            
            <h2>Browser vs desktop</h2>
            <p>RatPDF needs no install — IT-friendly — confidential docs review privacy policy retention window.</p>
            <h2>Chain tools</h2>
            <p>Convert → edit → compress → merge — pick order by deliverable — see the <a href="/guides/pdf-tools">PDF tools hub</a>.</p>
            <h2>Upgrade</h2>
            <p><a href="/Subscription/Plans">subscription plans</a> for daily caps on agency volume.</p>
            
            
            <h2>Cross-wave tool chain</h2>
            <p>Pick tool order by what you need to deliver. Example: photos → images PDF → OCR → edit date → compress → portal upload.</p>
            <h2>Free tier and upgrade</h2>
            <p>Three uses per day per tool on free tier — agency month-end exceeds cap — <a href="/Subscription/Plans">subscription plans</a> — predictable vs per-file credit packs.</p>
            <h2>Internal link discipline</h2>
            <p>Each guide links to related tools and comparisons so your team picks the right workflow.</p>
            <h2>Support triage</h2>
            <p>Wrong tool order causes bad output — OCR before edit on scans — compress after merge not before each file — train your team using the main tool guides.</p>
            
            
            <h2>QA before send</h2>
            <ol><li>Page count correct</li><li>Text selects if required</li><li>Images sharp at 150% zoom</li><li>File opens in Chrome PDF viewer</li><li>Size under email/portal cap</li></ol>
            <h2>Compare vendors</h2>
            <p><a href="/compare/smallpdf-alternative">Smallpdf</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/adobe-alternative">Adobe</a>.</p>
            
            
            <h2>Device matrix</h2>
            <p>Windows Edge, Mac Safari, iPhone Safari, Android Chrome — same account — no sync required — download to device storage before portal upload.</p>
            <h2>Retention hygiene</h2>
            <p>Clear Downloads on shared PC — contracts and medical admin PDFs are confidential — delete derivatives when task completes.</p>
            <h2>Filename and version control</h2>
            <p><code>Client-Doc-v2-edited.pdf</code> — never overwrite sent attachment — email thread references version.</p>
            <h2>Portal rejection loop</h2>
            <p>Reject → check size with <a href="/pdf-size-checker">size checker</a> → compress Less → split if still over → re-upload before session timeout.</p>
            <h2>Research links</h2>
            <p><a href="/research/attachment-size-limits">Attachment size limits</a> · <a href="/research/pdf-compression-benchmark">Compression benchmark</a> · <a href="/research/freelancer-invoicing-statistics">Invoicing statistics</a>.</p>
            <h2>Pillar bookmark set</h2>
            <p><a href="/guides/pdf-tools">PDF tools hub</a> · <a href="/guides/images-to-pdf">Images to PDF</a> · <a href="/guides/pdf-to-word">PDF to Word</a> · <a href="/guides/split-pdf">Split PDF</a> · <a href="/compare">Compare hub</a>.</p>
            
            
            <h2>Edit audit log</h2>
            <p>Log who edited which PDF derivative — timestamp — reason — matter number — supports litigation hold and SOX-style controls.</p>
            <h2>Flatten before external send</h2>
            <p>Some recipients see floating annotations differently — flatten or re-export PDF so logo and text boxes appear identical on all viewers.</p>
            <h2>Redaction before edit</h2>
            <p>Remove SSN and account numbers with <a href="/guides/pdf-redaction-permanent">permanent redaction</a> before adding new text — edit tool does not replace redaction workflow.</p>
            <h2>Training slide for staff</h2>
            <p>Three rules poster: OCR scans first — organize before merge — compress after combine — pin in Slack onboarding channel.</p>
            <h2>Department-specific examples</h2>
            <p><strong>HR:</strong> I-9 and handbook ack merge. <strong>Sales:</strong> logo on proposal. <strong>Legal:</strong> exhibit extract. <strong>Finance:</strong> initialed tax form. <strong>Ops:</strong> delivery note stamp.</p>
            <h2>Version rollback</h2>
            <p>Keep pre-edit master immutable — if client rejects edit — resend from master not undo in editor — filename version increments.</p>
            <h2>Collaboration handoff</h2>
            <p>Paralegal extracts page — attorney reviews in isolation — merge signed scan back — document handoff in matter management ticket.</p>
            <h2>Accessibility after edit</h2>
            <p>Added text may not be tagged — government accessibility filing may need tagged PDF specialist — SMB email deliverable usually exempt.</p>
            <h2>Pillar cross-links</h2>
            <p><a href="/guides/merge-pdf-online">merge PDF</a> · <a href="/guides/ocr-pdf">OCR PDF</a> · <a href="/guides/split-pdf">split hub</a> · <a href="/guides/pdf-tools">PDF tools hub</a>.</p>
            
            
            <h2>QA checklist — edit outputs</h2>
            <ol>
            <li>Page count matches intent after delete or rearrange</li>
            <li>Orientation correct on every page at thumbnail view</li>
            <li>Added text readable at 150% zoom and in print preview</li>
            <li>Annotations visible in Chrome PDF viewer and recipient test</li>
            <li>File size under email or portal cap — compress if needed</li>
            <li>Master archived before destructive delete</li>
            </ol>
            <h2>Department playbooks</h2>
            <p><strong>Legal:</strong> annotate review copy — master untouched. <strong>Finance:</strong> fill tax PDF — print-test. <strong>HR:</strong> OCR onboarding — merge ack. <strong>Sales:</strong> logo + date on proposal. <strong>Ops:</strong> delete blank feeder pages from scan batch.</p>
            <h2>Monthly volume</h2>
            <p>Track edit/remove jobs — exceed free tier twice in one week — finance approves <a href="/Subscription/Plans">subscription</a>.</p>
            <h2>Compare alternatives</h2>
            <p><a href="/compare/adobe-acrobat-alternative">Adobe Acrobat alternative</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/smallpdf-alternative">Smallpdf</a>.</p>
            
            
            <h2>Team rollout notes</h2>
            <p>Pin the main tool guides in your shared wiki — compress before portal, OCR before edit on scans, Word path only when ERP cannot reissue. New hires complete one sample file in first week using browser tools only — no desktop install ticket.</p>
            <h2>Support escalation path</h2>
            <p>Step 1: re-download output and open in Chrome viewer. Step 2: retry on Wi-Fi with smaller batch. Step 3: check <a href="/pdf-size-checker">size checker</a> preset. Step 4: compare tool choice on <a href="/compare">compare tools</a> if output quality insufficient.</p>
            <h2>Record retention</h2>
            <p>Keep source PDF until recipient confirms receipt — derivatives disposable after successful upload — confidential docs deleted from Downloads on shared machines same day.</p>
            <h2>Monthly volume planning</h2>
            <p>Track daily tool usage in spreadsheet — forecast upgrade need before month-end crunch — finance approves <a href="/Subscription/Plans">subscription</a> when free tier blocks twice in one week.</p>
            <h2>Incident log template</h2>
            <p>Date, source filename, tool used, error message, resolution — patterns reveal training gaps — share quarterly with ops lead.</p>
            
            
            <h2>Quick reference card</h2>
            <p>Scan → OCR → Edit. Digital → Edit direct. Reorder → Merge queue. One page → Split. Logo → Add image. Forms → Fill then print-test. Archive master before any derivative edit.</p>
            <p>Bookmark <a href="/guides/edit-pdf">edit PDF guide</a> for team onboarding — reduces wrong-tool support tickets.</p>
            <p>Wrong page order voids visa bundles — verify thumbnail strip before merge submit.</p>
            
            
            <h2>Related edit &amp; organize guides</h2>
            <ul>
            <li><a href="/guides/edit-scanned-pdf">Edit scanned PDF</a></li>
            <li><a href="/guides/organize-pdf-pages">Organize PDF pages</a></li>
            <li><a href="/guides/split-pdf-page-range">Split by page range</a></li>
            <li><a href="/guides/add-image-to-pdf">Add image to PDF</a></li>
            </ul>
            
            
            <h2>Edit-gap guides</h2>
            <ul>
            <li><a href="/guides/crop-pdf-online">Crop PDF online</a> · <a href="/guides/crop-pdf-without-adobe">Crop without Adobe</a></li>
            <li><a href="/guides/delete-pages-from-pdf">Delete pages</a> · <a href="/guides/remove-blank-pages-pdf">Remove blank pages</a></li>
            <li><a href="/guides/annotate-pdf-online">Annotate online</a> · <a href="/guides/annotate-pdf-free">Annotate free</a></li>
            <li><a href="/guides/highlight-pdf-online">Highlight PDF</a> · <a href="/guides/edit-pdf-text-online">Edit text</a></li>
            <li><a href="/guides/add-text-to-pdf">Add text</a> · <a href="/guides/fill-pdf-form-online">Fill form</a></li>
            <li><a href="/guides/rearrange-pdf-pages">Rearrange pages</a> · <a href="/guides/edit-pdf-without-acrobat">Without Acrobat</a></li>
            <li><a href="/guides/edit-pdf-on-mac">Edit on Mac</a> · <a href="/guides/edit-pdf-on-windows">Windows</a> · <a href="/guides/edit-pdf-on-iphone">iPhone</a></li>
            </ul>
            <h2>Pillar and organize links</h2>
            <p><a href="/guides/edit-pdf">Edit PDF guide</a> · <a href="/guides/rotate-pdf">Rotate PDF</a> · <a href="/guides/organize-pdf-pages">Organize pages</a> · <a href="/guides/merge-pdf">Merge guide</a> · <a href="/guides/split-pdf">Split guide</a> · <a href="/guides/ocr-pdf">OCR guide</a>.</p>
            
            
            <h2>Enterprise document workflows</h2>
            <p>Legal ops teams convert legacy contract PDFs during CLM migration — batch convert critical folders, prioritise active vendor agreements first. IT should approve browser upload policy for confidential docs.</p>

            <h2>Education sector</h2>
            <p>Faculty edit syllabus PDFs each semester — digital university PDFs convert cleanly; scanned course packs need OCR. Check campus IT data handling before upload.</p>

            <h2>Real estate</h2>
            <p>Lease amendments stored as PDF — convert to Word for redline, re-PDF for signature. Keep executed scan archived separately from working DOCX.</p>

            <h2>HR and offer letters</h2>
            <p>Template offer PDFs with merge fields sometimes break on convert — edit boilerplate in Word template instead of converting each hire if HRIS exports PDF.</p>

            <h2>Government RFP responses</h2>
            <p>Final submissions often must be PDF — use Word only for draft edits, export via <a href="/pdf/doctopdf">Word to PDF</a> for portal upload. Check RFP forbids track changes in submission.</p>

            <h2>Quality gates before client delivery</h2>
            <ol>
            <li>Spell-check in Word</li>
            <li>Compare page count vs source PDF</li>
            <li>Verify critical numbers (dates, amounts) unchanged</li>
            <li>Remove comments and track changes</li>
            <li>Export final PDF if deliverable format is PDF</li>
            </ol>

            <p>Pillar: <a href="/guides/pdf-to-word">PDF to Word guide</a> · Compare: <a href="/compare/smallpdf-alternative">Smallpdf alternative</a></p>
            
            
            <h2>Batch conversion hygiene</h2>
            <p>Converting 20 contracts? Use consistent naming <code>ClientName-contract-v1.docx</code>. Log source PDF hash if legal audit trail required.</p>

            <h2>Mobile upload caveats</h2>
            <p>Phone browsers work but large PDFs may timeout on cellular — use Wi-Fi or desktop for 50+ MB files.</p>

            <h2>Antivirus false positives</h2>
            <p>Some corporate proxies scan uploads — if blocked, try guest network or contact IT to allowlist ratpdf.com tool path.</p>

            <h2>Long-term archival</h2>
            <p>Store both source PDF and final DOCX/PDF pair — migrations sometimes need to re-edit decade-old contracts.</p>

            <h2>Regulatory and compliance edits</h2>
            <p>Privacy policies, SOC2 reports, and vendor security questionnaires arrive as PDF — convert to Word for comment, return PDF via <a href="/pdf/doctopdf">Word to PDF</a>. Legal should review material compliance wording changes.</p>

            <h2>Performance expectations</h2>
            <p>10-page digital PDF typically converts under two minutes; 200-page annual report may take longer — do not close tab during processing. Refresh only after timeout message.</p>
            
            
            <h2>Document type quick reference</h2>
            <p><strong>Contracts:</strong> digital PDF, track changes in Word. <strong>Invoices:</strong> table-heavy — check sums. <strong>Scanned forms:</strong> OCR first. <strong>Marketing PDFs:</strong> expect image blocks. <strong>Manuals:</strong> headings usually survive — update TOC in Word after edits.</p>
            <p>Upgrade for volume: <a href="/Subscription/Plans">subscription plans</a>. Pillar: <a href="/guides/pdf-to-word">PDF to Word</a>.</p>

            <h2>Stakeholder sign-off matrix</h2>
            <p>Legal reviews converted contracts; finance reviews invoice PDFs edited in Word; HR reviews offer letters. Route DOCX to the right reviewer before re-PDF. Version suffix in filename (<code>-legal-reviewed</code>) prevents accidental send of draft.</p>
            <p>After major edits, compress before email if DOCX re-export exceeds mailbox limits — see <a href="/research/pdf-compression-benchmark">PDF compression benchmark</a> for quality settings.</p>
            <p>Bookmark this page for your team's wiki — consistent PDF-to-Word steps reduce support tickets when onboarding new staff each quarter.</p>
            
            
            <h2>Failure messages</h2>
            <p><strong>Too large:</strong> compress or split. <strong>Invalid PDF:</strong> re-export source. <strong>Unreadable:</strong> re-scan don't only compress blur.</p>
            <h2>Archive discipline</h2>
            <p>Keep uncompressed master until upload or send succeeds — derivatives are disposable.</p>
            <h2>Compare tools</h2>
            <p><a href="/compare/smallpdf-alternative">Smallpdf</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/adobe-alternative">Adobe</a>.</p>
            
            
            <h2>Related guides</h2>
            <p>Editing guides cover crop, delete, annotate, highlight, rearrange pages, add text, fill forms, device workflows, blank-page cleanup, and rotate — step-by-step help for each task.</p>
            <p>Next troubleshooting wave: corrupt PDF, won’t open, print errors — bookmark <a href="/guides/pdf-tools">PDF tools hub</a> for full map.</p>
            
            
            <h2>More guides</h2>
            <p>Image, PowerPoint, and Word conversion guides, plus editing tutorials and competitor comparisons — all in one place.</p>
            <p>Main guides: <a href="/guides/images-to-pdf">images</a> · <a href="/guides/pdf-to-word">PDF to Word</a> · <a href="/guides/split-pdf">split</a> · <a href="/compare">compare</a>.</p>
            <h2>Post-action checklist</h2>
            <ol><li>Output opens in Chrome PDF viewer</li><li>Page order matches intent</li><li>Text selects if downstream edit needed</li><li>File size under email/portal cap</li><li>Master archived before deleting source</li></ol>
            <p>Bookmark the <a href="/guides/pdf-tools">PDF tools guide</a> and <a href="/compare">compare tools</a> for team onboarding — consistent tool choice reduces wrong-output support tickets.</p>
            
            
            <h2>Post-action checklist</h2>
            <ol><li>Output file opens in viewer</li><li>Text selects if required</li><li>Size under portal/email preset</li><li>Master archived</li><li>Correct tool used for next step (text vs Word vs OCR)</li></ol>
            <p>Bookmark the <a href="/guides/pdf-tools">PDF tools guide</a> and <a href="/compare">compare tools</a> for team onboarding — consistent tool choice reduces wrong-output support tickets.</p>
            <p>Re-run size checker after every derivative step — compress, split, or text export — before deleting the previous version from your working folder.</p>
            
            <p class="mt-4"><a href="/pdf/editpdf" class="btn btn-primary">Edit PDF</a> · <a href="/guides/edit-pdf">Edit PDF hub</a></p>
            """;

        private const string EditPdfOnIphone = """
            <h2>Edit PDF on iPhone — mobile annotate &amp; sign workflow</h2>
            <p>RatPDF <a href="/pdf/editpdf">Edit PDF</a> — Sales rep adds date and signature image on iPhone between meetings.</p>
            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> Edit PDF on iPhone — mobile annotate &amp; sign workflow</figcaption></figure>
            
            <h2>Mobile edit limits</h2>
            <p>Fine form alignment painful on phone — OK for date, initials, signature PNG — desktop for IRS-style forms.</p>
            <h2>Workflow</h2>
            <p>Mail attachment → Open in Safari → Edit PDF → save to Files → upload to portal from Files app.</p>
            <h2>File size</h2>
            <p>Cellular upload of 25 MB scan — use Wi-Fi — <a href="/guides/compress-pdf-on-iphone">compress on iPhone</a> if portal rejects.</p>
            
            
            <h2>Signature PNG from Photos</h2>
            <p>Sign on paper — photo — crop in Photos — insert in Edit PDF — transparent background preferred.</p>
            <h2>Field sales</h2>
            <p>Quote PDF — add approved stamp between meetings — compress before email on cellular.</p>
            
            <div class="rp-mid-cta alert alert-primary my-4"><strong>Start now</strong> <a href="/pdf/editpdf" class="alert-link fw-semibold">Edit PDF →</a></div>
            
            <h2>Edit vs convert vs OCR decision tree</h2>
            <p><strong>Digital PDF minor fix:</strong> Edit PDF text overlay. <strong>Heavy rewrite:</strong> PDF to Word. <strong>Scan:</strong> OCR first. <strong>Wrong page order:</strong> Organize via merge queue. <strong>One page pull:</strong> Split PDF.</p>
            <h2>Form filling landscape</h2>
            <p>Government PDFs mix fillable AcroForm fields and flat scans. Fillable fields preserve tab order — flat forms need positioned text boxes — print-test alignment before official submit.</p>
            <h2>Scanned document edit chain</h2>
            <ol>
            <li>Scan 300 DPI grayscale upright</li>
            <li><a href="/pdf/ocrpdf">OCR PDF</a> — verify Ctrl+F finds key term</li>
            <li><a href="/pdf/editpdf">Edit PDF</a> — add date, signature image, stamp</li>
            <li>Optional <a href="/guides/compress-pdf-for-email">compress</a> before portal upload</li>
            </ol>
            <h2>Organize without desktop Acrobat</h2>
            <p>Reorder pages in merge tool — drag queue — single merge output — same engine as <a href="/guides/merge-pdf-custom-order">custom order merge</a>. Delete pages by omitting from queue not destructive edit on source.</p>
            <h2>Image overlay best practices</h2>
            <p>Logo PNG with transparency — place top-right — do not cover existing signature block. DPI 150 sufficient for screen PDF — 300 for print-bound proposals.</p>
            <h2>Security and audit</h2>
            <p>Edited PDF is new derivative — keep unedited master for legal hold — filename suffix <code>-edited-2026-04-02</code>. Flatten annotations before court filing if local rules require.</p>
            
            
            <h2>Browser edit limitations</h2>
            <p>RatPDF edit covers common SMB needs — text add, image stamp, form fill — not InDesign prepress — not Photoshop pixel surgery. For marketing brochure pixel edits return to design source.</p>
            <h2>Mobile edit caution</h2>
            <p>Fine form alignment on phone is painful — desktop for government forms — mobile OK for initial and date on consent PDF.</p>
            <h2>Password-protected PDFs</h2>
            <p>Unlock first: <a href="/guides/unlock-pdf">unlock PDF</a> — edit fails on encrypted open.</p>
            <h2>Compare vendors</h2>
            <p><a href="/compare/adobe-alternative">Adobe</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/smallpdf-alternative">Smallpdf</a> — evaluate form-fill on your hardest government PDF sample.</p>
            <h2>Split and extract coordination</h2>
            <p>Extract signature page before sending for countersign — <a href="/guides/extract-single-page-pdf">extract single page</a> — merge back after scan with <a href="/pdf/merge">Merge PDF</a>.</p>
            <h2>QA print test</h2>
            <p>Government forms reject misaligned fields — print one copy — hold to light against blank form — adjust coordinates before batch.</p>
            
            
            <h2>Edit cluster authority map</h2>
            <p>Editing guides cover crop, delete, annotate, highlight, rearrange pages, and device workflows — plus in-depth help for <a href="/guides/edit-pdf">edit PDF</a> and <a href="/guides/rotate-pdf">rotate PDF</a>. See also merge, split, and OCR guides.</p>
            <h2>Security and compliance</h2>
            <p>Edited derivatives are new files — keep immutable master — log who edited — confidential docs cleared from Downloads on shared PCs same day. HIPAA and legal hold: counsel approves browser edit on PHI or privilege docs.</p>
            <h2>Failure triage</h2>
            <p><strong>Cannot select text:</strong> OCR first. <strong>Wrong page count after delete:</strong> off-by-one viewer index — recount. <strong>Portal rejects filled form:</strong> print-test alignment — font mismatch — try flatten. <strong>Upload timeout:</strong> Wi-Fi — compress — split.</p>
            <h2>Research links</h2>
            <p><a href="/research/attachment-size-limits">Email attachment limits</a> · <a href="/research/pdf-tool-market-comparison">PDF tool market comparison</a> · <a href="/compare">Compare hub</a>.</p>
            
            
            <h2>Workflow deep dive — Edit PDF on iPhone — mobile annotate &amp; sign workflow</h2>
            <p>Browser workflow — no install — upload → process → download → verify in viewer before external send.</p>
            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> Edit PDF on iPhone — mobile annotate &amp; sign workflow</figcaption></figure>
            <h2>Mobile</h2>
            <p>Safari/Chrome on phone works — Wi-Fi for files over 15 MB — save to Files before portal upload.</p>
            <h2>Failures</h2>
            <p>Timeout: retry Wi-Fi · corrupt PDF: re-export source · password: <a href="/guides/unlock-pdf">unlock</a>.</p>
            <h2>Free tier</h2>
            <p>Three uses/day — <a href="/Subscription/Plans">plans</a> for volume.</p>
            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Open tool</strong> <a href="/pdf/editpdf" class="alert-link fw-semibold">Go →</a></div>
            
            
            <h2>Real example: HR onboarding packet</h2>
            <p>Flat I-9 scan — OCR — add start date field — employee initials — merge with handbook acknowledgment — compress — upload to HRIS.</p>
            <h2>Second example: property manager lease initialed</h2>
            <p>Scan signed lease pages — add initialed watermark on page 4 rider — re-compress for email to tenant.</p>
            <h2>Third example: proposal logo</h2>
            <p>Sales exports proposal PDF from CRM — add partner logo top-left — send to client — no return to InDesign.</p>
            <h2>Discovery page pull</h2>
            <p>Counsel needs only exhibit G from 200-page production — split page range 142-148 — email to expert witness — index in cover note.</p>
            <h2>Medical admin form</h2>
            <p>Clinic scan intake form — OCR — nurse adds checkbox marks — print for patient sign — scan again for chart.</p>
            <h2>Upgrade path</h2>
            <p>High-volume form shop — <a href="/Subscription/Plans">plans</a> — see the <a href="/guides/edit-pdf">edit PDF hub</a>.</p>
            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Edit your PDF</strong> <a href="/pdf/editpdf" class="alert-link fw-semibold">Edit PDF →</a></div>
            
            
            
            <h2>Browser vs desktop</h2>
            <p>RatPDF needs no install — IT-friendly — confidential docs review privacy policy retention window.</p>
            <h2>Chain tools</h2>
            <p>Convert → edit → compress → merge — pick order by deliverable — see the <a href="/guides/pdf-tools">PDF tools hub</a>.</p>
            <h2>Upgrade</h2>
            <p><a href="/Subscription/Plans">subscription plans</a> for daily caps on agency volume.</p>
            
            
            <h2>Cross-wave tool chain</h2>
            <p>Pick tool order by what you need to deliver. Example: photos → images PDF → OCR → edit date → compress → portal upload.</p>
            <h2>Free tier and upgrade</h2>
            <p>Three uses per day per tool on free tier — agency month-end exceeds cap — <a href="/Subscription/Plans">subscription plans</a> — predictable vs per-file credit packs.</p>
            <h2>Internal link discipline</h2>
            <p>Each guide links to related tools and comparisons so your team picks the right workflow.</p>
            <h2>Support triage</h2>
            <p>Wrong tool order causes bad output — OCR before edit on scans — compress after merge not before each file — train your team using the main tool guides.</p>
            
            
            <h2>QA before send</h2>
            <ol><li>Page count correct</li><li>Text selects if required</li><li>Images sharp at 150% zoom</li><li>File opens in Chrome PDF viewer</li><li>Size under email/portal cap</li></ol>
            <h2>Compare vendors</h2>
            <p><a href="/compare/smallpdf-alternative">Smallpdf</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/adobe-alternative">Adobe</a>.</p>
            
            
            <h2>Device matrix</h2>
            <p>Windows Edge, Mac Safari, iPhone Safari, Android Chrome — same account — no sync required — download to device storage before portal upload.</p>
            <h2>Retention hygiene</h2>
            <p>Clear Downloads on shared PC — contracts and medical admin PDFs are confidential — delete derivatives when task completes.</p>
            <h2>Filename and version control</h2>
            <p><code>Client-Doc-v2-edited.pdf</code> — never overwrite sent attachment — email thread references version.</p>
            <h2>Portal rejection loop</h2>
            <p>Reject → check size with <a href="/pdf-size-checker">size checker</a> → compress Less → split if still over → re-upload before session timeout.</p>
            <h2>Research links</h2>
            <p><a href="/research/attachment-size-limits">Attachment size limits</a> · <a href="/research/pdf-compression-benchmark">Compression benchmark</a> · <a href="/research/freelancer-invoicing-statistics">Invoicing statistics</a>.</p>
            <h2>Pillar bookmark set</h2>
            <p><a href="/guides/pdf-tools">PDF tools hub</a> · <a href="/guides/images-to-pdf">Images to PDF</a> · <a href="/guides/pdf-to-word">PDF to Word</a> · <a href="/guides/split-pdf">Split PDF</a> · <a href="/compare">Compare hub</a>.</p>
            
            
            <h2>Edit audit log</h2>
            <p>Log who edited which PDF derivative — timestamp — reason — matter number — supports litigation hold and SOX-style controls.</p>
            <h2>Flatten before external send</h2>
            <p>Some recipients see floating annotations differently — flatten or re-export PDF so logo and text boxes appear identical on all viewers.</p>
            <h2>Redaction before edit</h2>
            <p>Remove SSN and account numbers with <a href="/guides/pdf-redaction-permanent">permanent redaction</a> before adding new text — edit tool does not replace redaction workflow.</p>
            <h2>Training slide for staff</h2>
            <p>Three rules poster: OCR scans first — organize before merge — compress after combine — pin in Slack onboarding channel.</p>
            <h2>Department-specific examples</h2>
            <p><strong>HR:</strong> I-9 and handbook ack merge. <strong>Sales:</strong> logo on proposal. <strong>Legal:</strong> exhibit extract. <strong>Finance:</strong> initialed tax form. <strong>Ops:</strong> delivery note stamp.</p>
            <h2>Version rollback</h2>
            <p>Keep pre-edit master immutable — if client rejects edit — resend from master not undo in editor — filename version increments.</p>
            <h2>Collaboration handoff</h2>
            <p>Paralegal extracts page — attorney reviews in isolation — merge signed scan back — document handoff in matter management ticket.</p>
            <h2>Accessibility after edit</h2>
            <p>Added text may not be tagged — government accessibility filing may need tagged PDF specialist — SMB email deliverable usually exempt.</p>
            <h2>Pillar cross-links</h2>
            <p><a href="/guides/merge-pdf-online">merge PDF</a> · <a href="/guides/ocr-pdf">OCR PDF</a> · <a href="/guides/split-pdf">split hub</a> · <a href="/guides/pdf-tools">PDF tools hub</a>.</p>
            
            
            <h2>QA checklist — edit outputs</h2>
            <ol>
            <li>Page count matches intent after delete or rearrange</li>
            <li>Orientation correct on every page at thumbnail view</li>
            <li>Added text readable at 150% zoom and in print preview</li>
            <li>Annotations visible in Chrome PDF viewer and recipient test</li>
            <li>File size under email or portal cap — compress if needed</li>
            <li>Master archived before destructive delete</li>
            </ol>
            <h2>Department playbooks</h2>
            <p><strong>Legal:</strong> annotate review copy — master untouched. <strong>Finance:</strong> fill tax PDF — print-test. <strong>HR:</strong> OCR onboarding — merge ack. <strong>Sales:</strong> logo + date on proposal. <strong>Ops:</strong> delete blank feeder pages from scan batch.</p>
            <h2>Monthly volume</h2>
            <p>Track edit/remove jobs — exceed free tier twice in one week — finance approves <a href="/Subscription/Plans">subscription</a>.</p>
            <h2>Compare alternatives</h2>
            <p><a href="/compare/adobe-acrobat-alternative">Adobe Acrobat alternative</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/smallpdf-alternative">Smallpdf</a>.</p>
            
            
            <h2>Team rollout notes</h2>
            <p>Pin the main tool guides in your shared wiki — compress before portal, OCR before edit on scans, Word path only when ERP cannot reissue. New hires complete one sample file in first week using browser tools only — no desktop install ticket.</p>
            <h2>Support escalation path</h2>
            <p>Step 1: re-download output and open in Chrome viewer. Step 2: retry on Wi-Fi with smaller batch. Step 3: check <a href="/pdf-size-checker">size checker</a> preset. Step 4: compare tool choice on <a href="/compare">compare tools</a> if output quality insufficient.</p>
            <h2>Record retention</h2>
            <p>Keep source PDF until recipient confirms receipt — derivatives disposable after successful upload — confidential docs deleted from Downloads on shared machines same day.</p>
            <h2>Monthly volume planning</h2>
            <p>Track daily tool usage in spreadsheet — forecast upgrade need before month-end crunch — finance approves <a href="/Subscription/Plans">subscription</a> when free tier blocks twice in one week.</p>
            <h2>Incident log template</h2>
            <p>Date, source filename, tool used, error message, resolution — patterns reveal training gaps — share quarterly with ops lead.</p>
            
            
            <h2>Quick reference card</h2>
            <p>Scan → OCR → Edit. Digital → Edit direct. Reorder → Merge queue. One page → Split. Logo → Add image. Forms → Fill then print-test. Archive master before any derivative edit.</p>
            <p>Bookmark <a href="/guides/edit-pdf">edit PDF guide</a> for team onboarding — reduces wrong-tool support tickets.</p>
            <p>Wrong page order voids visa bundles — verify thumbnail strip before merge submit.</p>
            
            
            <h2>Related edit &amp; organize guides</h2>
            <ul>
            <li><a href="/guides/edit-scanned-pdf">Edit scanned PDF</a></li>
            <li><a href="/guides/organize-pdf-pages">Organize PDF pages</a></li>
            <li><a href="/guides/split-pdf-page-range">Split by page range</a></li>
            <li><a href="/guides/add-image-to-pdf">Add image to PDF</a></li>
            </ul>
            
            
            <h2>Edit-gap guides</h2>
            <ul>
            <li><a href="/guides/crop-pdf-online">Crop PDF online</a> · <a href="/guides/crop-pdf-without-adobe">Crop without Adobe</a></li>
            <li><a href="/guides/delete-pages-from-pdf">Delete pages</a> · <a href="/guides/remove-blank-pages-pdf">Remove blank pages</a></li>
            <li><a href="/guides/annotate-pdf-online">Annotate online</a> · <a href="/guides/annotate-pdf-free">Annotate free</a></li>
            <li><a href="/guides/highlight-pdf-online">Highlight PDF</a> · <a href="/guides/edit-pdf-text-online">Edit text</a></li>
            <li><a href="/guides/add-text-to-pdf">Add text</a> · <a href="/guides/fill-pdf-form-online">Fill form</a></li>
            <li><a href="/guides/rearrange-pdf-pages">Rearrange pages</a> · <a href="/guides/edit-pdf-without-acrobat">Without Acrobat</a></li>
            <li><a href="/guides/edit-pdf-on-mac">Edit on Mac</a> · <a href="/guides/edit-pdf-on-windows">Windows</a> · <a href="/guides/edit-pdf-on-iphone">iPhone</a></li>
            </ul>
            <h2>Pillar and organize links</h2>
            <p><a href="/guides/edit-pdf">Edit PDF guide</a> · <a href="/guides/rotate-pdf">Rotate PDF</a> · <a href="/guides/organize-pdf-pages">Organize pages</a> · <a href="/guides/merge-pdf">Merge guide</a> · <a href="/guides/split-pdf">Split guide</a> · <a href="/guides/ocr-pdf">OCR guide</a>.</p>
            
            
            <h2>Enterprise document workflows</h2>
            <p>Legal ops teams convert legacy contract PDFs during CLM migration — batch convert critical folders, prioritise active vendor agreements first. IT should approve browser upload policy for confidential docs.</p>

            <h2>Education sector</h2>
            <p>Faculty edit syllabus PDFs each semester — digital university PDFs convert cleanly; scanned course packs need OCR. Check campus IT data handling before upload.</p>

            <h2>Real estate</h2>
            <p>Lease amendments stored as PDF — convert to Word for redline, re-PDF for signature. Keep executed scan archived separately from working DOCX.</p>

            <h2>HR and offer letters</h2>
            <p>Template offer PDFs with merge fields sometimes break on convert — edit boilerplate in Word template instead of converting each hire if HRIS exports PDF.</p>

            <h2>Government RFP responses</h2>
            <p>Final submissions often must be PDF — use Word only for draft edits, export via <a href="/pdf/doctopdf">Word to PDF</a> for portal upload. Check RFP forbids track changes in submission.</p>

            <h2>Quality gates before client delivery</h2>
            <ol>
            <li>Spell-check in Word</li>
            <li>Compare page count vs source PDF</li>
            <li>Verify critical numbers (dates, amounts) unchanged</li>
            <li>Remove comments and track changes</li>
            <li>Export final PDF if deliverable format is PDF</li>
            </ol>

            <p>Pillar: <a href="/guides/pdf-to-word">PDF to Word guide</a> · Compare: <a href="/compare/smallpdf-alternative">Smallpdf alternative</a></p>
            
            
            <h2>Batch conversion hygiene</h2>
            <p>Converting 20 contracts? Use consistent naming <code>ClientName-contract-v1.docx</code>. Log source PDF hash if legal audit trail required.</p>

            <h2>Mobile upload caveats</h2>
            <p>Phone browsers work but large PDFs may timeout on cellular — use Wi-Fi or desktop for 50+ MB files.</p>

            <h2>Antivirus false positives</h2>
            <p>Some corporate proxies scan uploads — if blocked, try guest network or contact IT to allowlist ratpdf.com tool path.</p>

            <h2>Long-term archival</h2>
            <p>Store both source PDF and final DOCX/PDF pair — migrations sometimes need to re-edit decade-old contracts.</p>

            <h2>Regulatory and compliance edits</h2>
            <p>Privacy policies, SOC2 reports, and vendor security questionnaires arrive as PDF — convert to Word for comment, return PDF via <a href="/pdf/doctopdf">Word to PDF</a>. Legal should review material compliance wording changes.</p>

            <h2>Performance expectations</h2>
            <p>10-page digital PDF typically converts under two minutes; 200-page annual report may take longer — do not close tab during processing. Refresh only after timeout message.</p>
            
            
            <h2>Document type quick reference</h2>
            <p><strong>Contracts:</strong> digital PDF, track changes in Word. <strong>Invoices:</strong> table-heavy — check sums. <strong>Scanned forms:</strong> OCR first. <strong>Marketing PDFs:</strong> expect image blocks. <strong>Manuals:</strong> headings usually survive — update TOC in Word after edits.</p>
            <p>Upgrade for volume: <a href="/Subscription/Plans">subscription plans</a>. Pillar: <a href="/guides/pdf-to-word">PDF to Word</a>.</p>

            <h2>Stakeholder sign-off matrix</h2>
            <p>Legal reviews converted contracts; finance reviews invoice PDFs edited in Word; HR reviews offer letters. Route DOCX to the right reviewer before re-PDF. Version suffix in filename (<code>-legal-reviewed</code>) prevents accidental send of draft.</p>
            <p>After major edits, compress before email if DOCX re-export exceeds mailbox limits — see <a href="/research/pdf-compression-benchmark">PDF compression benchmark</a> for quality settings.</p>
            <p>Bookmark this page for your team's wiki — consistent PDF-to-Word steps reduce support tickets when onboarding new staff each quarter.</p>
            
            
            <h2>Failure messages</h2>
            <p><strong>Too large:</strong> compress or split. <strong>Invalid PDF:</strong> re-export source. <strong>Unreadable:</strong> re-scan don't only compress blur.</p>
            <h2>Archive discipline</h2>
            <p>Keep uncompressed master until upload or send succeeds — derivatives are disposable.</p>
            <h2>Compare tools</h2>
            <p><a href="/compare/smallpdf-alternative">Smallpdf</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/adobe-alternative">Adobe</a>.</p>
            
            
            <h2>Related guides</h2>
            <p>Editing guides cover crop, delete, annotate, highlight, rearrange pages, add text, fill forms, device workflows, blank-page cleanup, and rotate — step-by-step help for each task.</p>
            <p>Next troubleshooting wave: corrupt PDF, won’t open, print errors — bookmark <a href="/guides/pdf-tools">PDF tools hub</a> for full map.</p>
            
            
            <h2>More guides</h2>
            <p>Image, PowerPoint, and Word conversion guides, plus editing tutorials and competitor comparisons — all in one place.</p>
            <p>Main guides: <a href="/guides/images-to-pdf">images</a> · <a href="/guides/pdf-to-word">PDF to Word</a> · <a href="/guides/split-pdf">split</a> · <a href="/compare">compare</a>.</p>
            <h2>Post-action checklist</h2>
            <ol><li>Output opens in Chrome PDF viewer</li><li>Page order matches intent</li><li>Text selects if downstream edit needed</li><li>File size under email/portal cap</li><li>Master archived before deleting source</li></ol>
            <p>Bookmark the <a href="/guides/pdf-tools">PDF tools guide</a> and <a href="/compare">compare tools</a> for team onboarding — consistent tool choice reduces wrong-output support tickets.</p>
            
            
            <h2>Post-action checklist</h2>
            <ol><li>Output file opens in viewer</li><li>Text selects if required</li><li>Size under portal/email preset</li><li>Master archived</li><li>Correct tool used for next step (text vs Word vs OCR)</li></ol>
            <p>Bookmark the <a href="/guides/pdf-tools">PDF tools guide</a> and <a href="/compare">compare tools</a> for team onboarding — consistent tool choice reduces wrong-output support tickets.</p>
            <p>Re-run size checker after every derivative step — compress, split, or text export — before deleting the previous version from your working folder.</p>
            
            <p class="mt-4"><a href="/pdf/editpdf" class="btn btn-primary">Edit PDF</a> · <a href="/guides/edit-pdf">Edit PDF hub</a></p>
            """;

        private const string RemoveBlankPagesPdf = """
            <h2>Remove blank pages from PDF — clean merged scans online</h2>
            <p>RatPDF <a href="/pdf/rotateorremove">Rotate / Remove Pages</a> — Strip feeder blank pages from 40-page scanned contract.</p>
            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> Remove blank pages from PDF — clean merged scans online</figcaption></figure>
            
            <h2>Why blank pages appear</h2>
            <p>Scanner feeder double-feed blank, Word export trailing page, merge appended empty PDF, fax cover duplicated.</p>
            <h2>Find blanks fast</h2>
            <p>Thumbnail view — scroll — note indices — batch remove <code>2, 5, 8, 11</code> in one job if tool supports list.</p>
            <h2>Prevent recurrence</h2>
            <p>Deselect “scan empty page” on copier — remove trailing Word page break — merge queue omit blanks.</p>
            
            
            <h2>Word export artifact</h2>
            <p>Trailing blank page from page break — delete last page — verify footer page count matches content.</p>
            <h2>Merge accident</h2>
            <p>Empty PDF in merge queue — remove pages from output — fix queue for next month’s merge.</p>
            
            <div class="rp-mid-cta alert alert-primary my-4"><strong>Start now</strong> <a href="/pdf/rotateorremove" class="alert-link fw-semibold">Rotate / Remove Pages →</a></div>
            
            <h2>Edit vs convert vs OCR decision tree</h2>
            <p><strong>Digital PDF minor fix:</strong> Edit PDF text overlay. <strong>Heavy rewrite:</strong> PDF to Word. <strong>Scan:</strong> OCR first. <strong>Wrong page order:</strong> Organize via merge queue. <strong>One page pull:</strong> Split PDF.</p>
            <h2>Form filling landscape</h2>
            <p>Government PDFs mix fillable AcroForm fields and flat scans. Fillable fields preserve tab order — flat forms need positioned text boxes — print-test alignment before official submit.</p>
            <h2>Scanned document edit chain</h2>
            <ol>
            <li>Scan 300 DPI grayscale upright</li>
            <li><a href="/pdf/ocrpdf">OCR PDF</a> — verify Ctrl+F finds key term</li>
            <li><a href="/pdf/editpdf">Edit PDF</a> — add date, signature image, stamp</li>
            <li>Optional <a href="/guides/compress-pdf-for-email">compress</a> before portal upload</li>
            </ol>
            <h2>Organize without desktop Acrobat</h2>
            <p>Reorder pages in merge tool — drag queue — single merge output — same engine as <a href="/guides/merge-pdf-custom-order">custom order merge</a>. Delete pages by omitting from queue not destructive edit on source.</p>
            <h2>Image overlay best practices</h2>
            <p>Logo PNG with transparency — place top-right — do not cover existing signature block. DPI 150 sufficient for screen PDF — 300 for print-bound proposals.</p>
            <h2>Security and audit</h2>
            <p>Edited PDF is new derivative — keep unedited master for legal hold — filename suffix <code>-edited-2026-04-02</code>. Flatten annotations before court filing if local rules require.</p>
            
            
            <h2>Browser edit limitations</h2>
            <p>RatPDF edit covers common SMB needs — text add, image stamp, form fill — not InDesign prepress — not Photoshop pixel surgery. For marketing brochure pixel edits return to design source.</p>
            <h2>Mobile edit caution</h2>
            <p>Fine form alignment on phone is painful — desktop for government forms — mobile OK for initial and date on consent PDF.</p>
            <h2>Password-protected PDFs</h2>
            <p>Unlock first: <a href="/guides/unlock-pdf">unlock PDF</a> — edit fails on encrypted open.</p>
            <h2>Compare vendors</h2>
            <p><a href="/compare/adobe-alternative">Adobe</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/smallpdf-alternative">Smallpdf</a> — evaluate form-fill on your hardest government PDF sample.</p>
            <h2>Split and extract coordination</h2>
            <p>Extract signature page before sending for countersign — <a href="/guides/extract-single-page-pdf">extract single page</a> — merge back after scan with <a href="/pdf/merge">Merge PDF</a>.</p>
            <h2>QA print test</h2>
            <p>Government forms reject misaligned fields — print one copy — hold to light against blank form — adjust coordinates before batch.</p>
            
            
            <h2>Edit cluster authority map</h2>
            <p>Editing guides cover crop, delete, annotate, highlight, rearrange pages, and device workflows — plus in-depth help for <a href="/guides/edit-pdf">edit PDF</a> and <a href="/guides/rotate-pdf">rotate PDF</a>. See also merge, split, and OCR guides.</p>
            <h2>Security and compliance</h2>
            <p>Edited derivatives are new files — keep immutable master — log who edited — confidential docs cleared from Downloads on shared PCs same day. HIPAA and legal hold: counsel approves browser edit on PHI or privilege docs.</p>
            <h2>Failure triage</h2>
            <p><strong>Cannot select text:</strong> OCR first. <strong>Wrong page count after delete:</strong> off-by-one viewer index — recount. <strong>Portal rejects filled form:</strong> print-test alignment — font mismatch — try flatten. <strong>Upload timeout:</strong> Wi-Fi — compress — split.</p>
            <h2>Research links</h2>
            <p><a href="/research/attachment-size-limits">Email attachment limits</a> · <a href="/research/pdf-tool-market-comparison">PDF tool market comparison</a> · <a href="/compare">Compare hub</a>.</p>
            
            
            <h2>Workflow deep dive — Remove blank pages from PDF — clean merged scans online</h2>
            <p>Browser workflow — no install — upload → process → download → verify in viewer before external send.</p>
            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> Remove blank pages from PDF — clean merged scans online</figcaption></figure>
            <h2>Mobile</h2>
            <p>Safari/Chrome on phone works — Wi-Fi for files over 15 MB — save to Files before portal upload.</p>
            <h2>Failures</h2>
            <p>Timeout: retry Wi-Fi · corrupt PDF: re-export source · password: <a href="/guides/unlock-pdf">unlock</a>.</p>
            <h2>Free tier</h2>
            <p>Three uses/day — <a href="/Subscription/Plans">plans</a> for volume.</p>
            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Open tool</strong> <a href="/pdf/rotateorremove" class="alert-link fw-semibold">Go →</a></div>
            
            
            <h2>Real example: HR onboarding packet</h2>
            <p>Flat I-9 scan — OCR — add start date field — employee initials — merge with handbook acknowledgment — compress — upload to HRIS.</p>
            <h2>Second example: property manager lease initialed</h2>
            <p>Scan signed lease pages — add initialed watermark on page 4 rider — re-compress for email to tenant.</p>
            <h2>Third example: proposal logo</h2>
            <p>Sales exports proposal PDF from CRM — add partner logo top-left — send to client — no return to InDesign.</p>
            <h2>Discovery page pull</h2>
            <p>Counsel needs only exhibit G from 200-page production — split page range 142-148 — email to expert witness — index in cover note.</p>
            <h2>Medical admin form</h2>
            <p>Clinic scan intake form — OCR — nurse adds checkbox marks — print for patient sign — scan again for chart.</p>
            <h2>Upgrade path</h2>
            <p>High-volume form shop — <a href="/Subscription/Plans">plans</a> — see the <a href="/guides/edit-pdf">edit PDF hub</a>.</p>
            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Edit your PDF</strong> <a href="/pdf/editpdf" class="alert-link fw-semibold">Edit PDF →</a></div>
            
            
            
            <h2>Browser vs desktop</h2>
            <p>RatPDF needs no install — IT-friendly — confidential docs review privacy policy retention window.</p>
            <h2>Chain tools</h2>
            <p>Convert → edit → compress → merge — pick order by deliverable — see the <a href="/guides/pdf-tools">PDF tools hub</a>.</p>
            <h2>Upgrade</h2>
            <p><a href="/Subscription/Plans">subscription plans</a> for daily caps on agency volume.</p>
            
            
            <h2>Cross-wave tool chain</h2>
            <p>Pick tool order by what you need to deliver. Example: photos → images PDF → OCR → edit date → compress → portal upload.</p>
            <h2>Free tier and upgrade</h2>
            <p>Three uses per day per tool on free tier — agency month-end exceeds cap — <a href="/Subscription/Plans">subscription plans</a> — predictable vs per-file credit packs.</p>
            <h2>Internal link discipline</h2>
            <p>Each guide links to related tools and comparisons so your team picks the right workflow.</p>
            <h2>Support triage</h2>
            <p>Wrong tool order causes bad output — OCR before edit on scans — compress after merge not before each file — train your team using the main tool guides.</p>
            
            
            <h2>QA before send</h2>
            <ol><li>Page count correct</li><li>Text selects if required</li><li>Images sharp at 150% zoom</li><li>File opens in Chrome PDF viewer</li><li>Size under email/portal cap</li></ol>
            <h2>Compare vendors</h2>
            <p><a href="/compare/smallpdf-alternative">Smallpdf</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/adobe-alternative">Adobe</a>.</p>
            
            
            <h2>Device matrix</h2>
            <p>Windows Edge, Mac Safari, iPhone Safari, Android Chrome — same account — no sync required — download to device storage before portal upload.</p>
            <h2>Retention hygiene</h2>
            <p>Clear Downloads on shared PC — contracts and medical admin PDFs are confidential — delete derivatives when task completes.</p>
            <h2>Filename and version control</h2>
            <p><code>Client-Doc-v2-edited.pdf</code> — never overwrite sent attachment — email thread references version.</p>
            <h2>Portal rejection loop</h2>
            <p>Reject → check size with <a href="/pdf-size-checker">size checker</a> → compress Less → split if still over → re-upload before session timeout.</p>
            <h2>Research links</h2>
            <p><a href="/research/attachment-size-limits">Attachment size limits</a> · <a href="/research/pdf-compression-benchmark">Compression benchmark</a> · <a href="/research/freelancer-invoicing-statistics">Invoicing statistics</a>.</p>
            <h2>Pillar bookmark set</h2>
            <p><a href="/guides/pdf-tools">PDF tools hub</a> · <a href="/guides/images-to-pdf">Images to PDF</a> · <a href="/guides/pdf-to-word">PDF to Word</a> · <a href="/guides/split-pdf">Split PDF</a> · <a href="/compare">Compare hub</a>.</p>
            
            
            <h2>Edit audit log</h2>
            <p>Log who edited which PDF derivative — timestamp — reason — matter number — supports litigation hold and SOX-style controls.</p>
            <h2>Flatten before external send</h2>
            <p>Some recipients see floating annotations differently — flatten or re-export PDF so logo and text boxes appear identical on all viewers.</p>
            <h2>Redaction before edit</h2>
            <p>Remove SSN and account numbers with <a href="/guides/pdf-redaction-permanent">permanent redaction</a> before adding new text — edit tool does not replace redaction workflow.</p>
            <h2>Training slide for staff</h2>
            <p>Three rules poster: OCR scans first — organize before merge — compress after combine — pin in Slack onboarding channel.</p>
            <h2>Department-specific examples</h2>
            <p><strong>HR:</strong> I-9 and handbook ack merge. <strong>Sales:</strong> logo on proposal. <strong>Legal:</strong> exhibit extract. <strong>Finance:</strong> initialed tax form. <strong>Ops:</strong> delivery note stamp.</p>
            <h2>Version rollback</h2>
            <p>Keep pre-edit master immutable — if client rejects edit — resend from master not undo in editor — filename version increments.</p>
            <h2>Collaboration handoff</h2>
            <p>Paralegal extracts page — attorney reviews in isolation — merge signed scan back — document handoff in matter management ticket.</p>
            <h2>Accessibility after edit</h2>
            <p>Added text may not be tagged — government accessibility filing may need tagged PDF specialist — SMB email deliverable usually exempt.</p>
            <h2>Pillar cross-links</h2>
            <p><a href="/guides/merge-pdf-online">merge PDF</a> · <a href="/guides/ocr-pdf">OCR PDF</a> · <a href="/guides/split-pdf">split hub</a> · <a href="/guides/pdf-tools">PDF tools hub</a>.</p>
            
            
            <h2>QA checklist — edit outputs</h2>
            <ol>
            <li>Page count matches intent after delete or rearrange</li>
            <li>Orientation correct on every page at thumbnail view</li>
            <li>Added text readable at 150% zoom and in print preview</li>
            <li>Annotations visible in Chrome PDF viewer and recipient test</li>
            <li>File size under email or portal cap — compress if needed</li>
            <li>Master archived before destructive delete</li>
            </ol>
            <h2>Department playbooks</h2>
            <p><strong>Legal:</strong> annotate review copy — master untouched. <strong>Finance:</strong> fill tax PDF — print-test. <strong>HR:</strong> OCR onboarding — merge ack. <strong>Sales:</strong> logo + date on proposal. <strong>Ops:</strong> delete blank feeder pages from scan batch.</p>
            <h2>Monthly volume</h2>
            <p>Track edit/remove jobs — exceed free tier twice in one week — finance approves <a href="/Subscription/Plans">subscription</a>.</p>
            <h2>Compare alternatives</h2>
            <p><a href="/compare/adobe-acrobat-alternative">Adobe Acrobat alternative</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/smallpdf-alternative">Smallpdf</a>.</p>
            
            
            <h2>Team rollout notes</h2>
            <p>Pin the main tool guides in your shared wiki — compress before portal, OCR before edit on scans, Word path only when ERP cannot reissue. New hires complete one sample file in first week using browser tools only — no desktop install ticket.</p>
            <h2>Support escalation path</h2>
            <p>Step 1: re-download output and open in Chrome viewer. Step 2: retry on Wi-Fi with smaller batch. Step 3: check <a href="/pdf-size-checker">size checker</a> preset. Step 4: compare tool choice on <a href="/compare">compare tools</a> if output quality insufficient.</p>
            <h2>Record retention</h2>
            <p>Keep source PDF until recipient confirms receipt — derivatives disposable after successful upload — confidential docs deleted from Downloads on shared machines same day.</p>
            <h2>Monthly volume planning</h2>
            <p>Track daily tool usage in spreadsheet — forecast upgrade need before month-end crunch — finance approves <a href="/Subscription/Plans">subscription</a> when free tier blocks twice in one week.</p>
            <h2>Incident log template</h2>
            <p>Date, source filename, tool used, error message, resolution — patterns reveal training gaps — share quarterly with ops lead.</p>
            
            
            <h2>Quick reference card</h2>
            <p>Scan → OCR → Edit. Digital → Edit direct. Reorder → Merge queue. One page → Split. Logo → Add image. Forms → Fill then print-test. Archive master before any derivative edit.</p>
            <p>Bookmark <a href="/guides/edit-pdf">edit PDF guide</a> for team onboarding — reduces wrong-tool support tickets.</p>
            <p>Wrong page order voids visa bundles — verify thumbnail strip before merge submit.</p>
            
            
            <h2>Related edit &amp; organize guides</h2>
            <ul>
            <li><a href="/guides/edit-scanned-pdf">Edit scanned PDF</a></li>
            <li><a href="/guides/organize-pdf-pages">Organize PDF pages</a></li>
            <li><a href="/guides/split-pdf-page-range">Split by page range</a></li>
            <li><a href="/guides/add-image-to-pdf">Add image to PDF</a></li>
            </ul>
            
            
            <h2>Edit-gap guides</h2>
            <ul>
            <li><a href="/guides/crop-pdf-online">Crop PDF online</a> · <a href="/guides/crop-pdf-without-adobe">Crop without Adobe</a></li>
            <li><a href="/guides/delete-pages-from-pdf">Delete pages</a> · <a href="/guides/remove-blank-pages-pdf">Remove blank pages</a></li>
            <li><a href="/guides/annotate-pdf-online">Annotate online</a> · <a href="/guides/annotate-pdf-free">Annotate free</a></li>
            <li><a href="/guides/highlight-pdf-online">Highlight PDF</a> · <a href="/guides/edit-pdf-text-online">Edit text</a></li>
            <li><a href="/guides/add-text-to-pdf">Add text</a> · <a href="/guides/fill-pdf-form-online">Fill form</a></li>
            <li><a href="/guides/rearrange-pdf-pages">Rearrange pages</a> · <a href="/guides/edit-pdf-without-acrobat">Without Acrobat</a></li>
            <li><a href="/guides/edit-pdf-on-mac">Edit on Mac</a> · <a href="/guides/edit-pdf-on-windows">Windows</a> · <a href="/guides/edit-pdf-on-iphone">iPhone</a></li>
            </ul>
            <h2>Pillar and organize links</h2>
            <p><a href="/guides/edit-pdf">Edit PDF guide</a> · <a href="/guides/rotate-pdf">Rotate PDF</a> · <a href="/guides/organize-pdf-pages">Organize pages</a> · <a href="/guides/merge-pdf">Merge guide</a> · <a href="/guides/split-pdf">Split guide</a> · <a href="/guides/ocr-pdf">OCR guide</a>.</p>
            
            
            <h2>Enterprise document workflows</h2>
            <p>Legal ops teams convert legacy contract PDFs during CLM migration — batch convert critical folders, prioritise active vendor agreements first. IT should approve browser upload policy for confidential docs.</p>

            <h2>Education sector</h2>
            <p>Faculty edit syllabus PDFs each semester — digital university PDFs convert cleanly; scanned course packs need OCR. Check campus IT data handling before upload.</p>

            <h2>Real estate</h2>
            <p>Lease amendments stored as PDF — convert to Word for redline, re-PDF for signature. Keep executed scan archived separately from working DOCX.</p>

            <h2>HR and offer letters</h2>
            <p>Template offer PDFs with merge fields sometimes break on convert — edit boilerplate in Word template instead of converting each hire if HRIS exports PDF.</p>

            <h2>Government RFP responses</h2>
            <p>Final submissions often must be PDF — use Word only for draft edits, export via <a href="/pdf/doctopdf">Word to PDF</a> for portal upload. Check RFP forbids track changes in submission.</p>

            <h2>Quality gates before client delivery</h2>
            <ol>
            <li>Spell-check in Word</li>
            <li>Compare page count vs source PDF</li>
            <li>Verify critical numbers (dates, amounts) unchanged</li>
            <li>Remove comments and track changes</li>
            <li>Export final PDF if deliverable format is PDF</li>
            </ol>

            <p>Pillar: <a href="/guides/pdf-to-word">PDF to Word guide</a> · Compare: <a href="/compare/smallpdf-alternative">Smallpdf alternative</a></p>
            
            
            <h2>Batch conversion hygiene</h2>
            <p>Converting 20 contracts? Use consistent naming <code>ClientName-contract-v1.docx</code>. Log source PDF hash if legal audit trail required.</p>

            <h2>Mobile upload caveats</h2>
            <p>Phone browsers work but large PDFs may timeout on cellular — use Wi-Fi or desktop for 50+ MB files.</p>

            <h2>Antivirus false positives</h2>
            <p>Some corporate proxies scan uploads — if blocked, try guest network or contact IT to allowlist ratpdf.com tool path.</p>

            <h2>Long-term archival</h2>
            <p>Store both source PDF and final DOCX/PDF pair — migrations sometimes need to re-edit decade-old contracts.</p>

            <h2>Regulatory and compliance edits</h2>
            <p>Privacy policies, SOC2 reports, and vendor security questionnaires arrive as PDF — convert to Word for comment, return PDF via <a href="/pdf/doctopdf">Word to PDF</a>. Legal should review material compliance wording changes.</p>

            <h2>Performance expectations</h2>
            <p>10-page digital PDF typically converts under two minutes; 200-page annual report may take longer — do not close tab during processing. Refresh only after timeout message.</p>
            
            
            <h2>Document type quick reference</h2>
            <p><strong>Contracts:</strong> digital PDF, track changes in Word. <strong>Invoices:</strong> table-heavy — check sums. <strong>Scanned forms:</strong> OCR first. <strong>Marketing PDFs:</strong> expect image blocks. <strong>Manuals:</strong> headings usually survive — update TOC in Word after edits.</p>
            <p>Upgrade for volume: <a href="/Subscription/Plans">subscription plans</a>. Pillar: <a href="/guides/pdf-to-word">PDF to Word</a>.</p>

            <h2>Stakeholder sign-off matrix</h2>
            <p>Legal reviews converted contracts; finance reviews invoice PDFs edited in Word; HR reviews offer letters. Route DOCX to the right reviewer before re-PDF. Version suffix in filename (<code>-legal-reviewed</code>) prevents accidental send of draft.</p>
            <p>After major edits, compress before email if DOCX re-export exceeds mailbox limits — see <a href="/research/pdf-compression-benchmark">PDF compression benchmark</a> for quality settings.</p>
            <p>Bookmark this page for your team's wiki — consistent PDF-to-Word steps reduce support tickets when onboarding new staff each quarter.</p>
            
            
            <h2>Failure messages</h2>
            <p><strong>Too large:</strong> compress or split. <strong>Invalid PDF:</strong> re-export source. <strong>Unreadable:</strong> re-scan don't only compress blur.</p>
            <h2>Archive discipline</h2>
            <p>Keep uncompressed master until upload or send succeeds — derivatives are disposable.</p>
            <h2>Compare tools</h2>
            <p><a href="/compare/smallpdf-alternative">Smallpdf</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/adobe-alternative">Adobe</a>.</p>
            
            
            <h2>Related guides</h2>
            <p>Editing guides cover crop, delete, annotate, highlight, rearrange pages, add text, fill forms, device workflows, blank-page cleanup, and rotate — step-by-step help for each task.</p>
            <p>Next troubleshooting wave: corrupt PDF, won’t open, print errors — bookmark <a href="/guides/pdf-tools">PDF tools hub</a> for full map.</p>
            
            
            <h2>More guides</h2>
            <p>Image, PowerPoint, and Word conversion guides, plus editing tutorials and competitor comparisons — all in one place.</p>
            <p>Main guides: <a href="/guides/images-to-pdf">images</a> · <a href="/guides/pdf-to-word">PDF to Word</a> · <a href="/guides/split-pdf">split</a> · <a href="/compare">compare</a>.</p>
            <h2>Post-action checklist</h2>
            <ol><li>Output opens in Chrome PDF viewer</li><li>Page order matches intent</li><li>Text selects if downstream edit needed</li><li>File size under email/portal cap</li><li>Master archived before deleting source</li></ol>
            <p>Bookmark the <a href="/guides/pdf-tools">PDF tools guide</a> and <a href="/compare">compare tools</a> for team onboarding — consistent tool choice reduces wrong-output support tickets.</p>
            
            
            <h2>Post-action checklist</h2>
            <ol><li>Output file opens in viewer</li><li>Text selects if required</li><li>Size under portal/email preset</li><li>Master archived</li><li>Correct tool used for next step (text vs Word vs OCR)</li></ol>
            <p>Bookmark the <a href="/guides/pdf-tools">PDF tools guide</a> and <a href="/compare">compare tools</a> for team onboarding — consistent tool choice reduces wrong-output support tickets.</p>
            <p>Re-run size checker after every derivative step — compress, split, or text export — before deleting the previous version from your working folder.</p>
            
            <p class="mt-4"><a href="/pdf/rotateorremove" class="btn btn-primary">Rotate / Remove Pages</a> · <a href="/guides/edit-pdf">Edit PDF hub</a></p>
            """;

        private const string EditPdf = """
            <h2>Edit PDF online — complete browser editing guide (2026)</h2>
            <p>RatPDF <a href="/pdf/editpdf">Edit PDF</a> — SMB hub for text, images, forms, and annotations without desktop install.</p>
            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> Edit PDF online — complete browser editing guide (2026)</figcaption></figure>
            
            <h2>Edit PDF — decision tree</h2>
            <p><strong>Digital minor fix:</strong> Edit PDF direct. <strong>Scan:</strong> OCR first. <strong>Heavy rewrite:</strong> PDF to Word. <strong>Reorder:</strong> Merge queue. <strong>Delete page:</strong> Rotate / Remove. <strong>Rotate:</strong> <a href="/guides/rotate-pdf">Rotate guide</a>.</p>
            <h2>Tool matrix</h2>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>Task</th><th>Tool</th><th>Guide</th></tr></thead>
            <tbody>
            <tr><td>Add text / annotate</td><td><a href="/pdf/editpdf">Edit PDF</a></td><td><a href="/guides/add-text-to-pdf">Add text</a></td></tr>
            <tr><td>Highlight / markup</td><td>Edit PDF</td><td><a href="/guides/highlight-pdf-online">Highlight</a></td></tr>
            <tr><td>Fill forms</td><td>Edit PDF</td><td><a href="/guides/fill-pdf-form-online">Fill form</a></td></tr>
            <tr><td>Logo / image</td><td>Edit PDF</td><td><a href="/guides/add-image-to-pdf">Add image</a></td></tr>
            <tr><td>Delete pages</td><td><a href="/pdf/rotateorremove">Rotate / Remove</a></td><td><a href="/guides/delete-pages-from-pdf">Delete pages</a></td></tr>
            <tr><td>Reorder</td><td><a href="/pdf/merge">Merge PDF</a></td><td><a href="/guides/rearrange-pdf-pages">Rearrange</a></td></tr>
            </tbody>
            </table></div>
            <h2>When browser edit is enough</h2>
            <p>Last-minute labels, stamps, form fill, logo on proposal — not InDesign prepress — not CMYK print shop proofing.</p>
            
            
            <h2>Real example: sales proposal</h2>
            <p>CRM exports PDF — add partner logo — add text revision date — compress — client email — no InDesign round trip.</p>
            <h2>Real example: HR onboarding</h2>
            <p>OCR I-9 — fill fields — merge handbook ack — compress — HRIS upload.</p>
            <h2>Related editing guides</h2>
            <ul>
            <li><a href="/guides/crop-pdf-online">Crop PDF</a> · <a href="/guides/delete-pages-from-pdf">Delete pages</a></li>
            <li><a href="/guides/annotate-pdf-online">Annotate</a> · <a href="/guides/highlight-pdf-online">Highlight</a></li>
            <li><a href="/guides/rearrange-pdf-pages">Rearrange</a> · <a href="/guides/add-text-to-pdf">Add text</a></li>
            <li><a href="/guides/edit-pdf-on-mac">Mac</a> · <a href="/guides/edit-pdf-on-windows">Windows</a> · <a href="/guides/edit-pdf-on-iphone">iPhone</a></li>
            </ul>
            
            <div class="rp-mid-cta alert alert-primary my-4"><strong>Start now</strong> <a href="/pdf/editpdf" class="alert-link fw-semibold">Edit PDF →</a></div>
            
            <h2>Edit vs convert vs OCR decision tree</h2>
            <p><strong>Digital PDF minor fix:</strong> Edit PDF text overlay. <strong>Heavy rewrite:</strong> PDF to Word. <strong>Scan:</strong> OCR first. <strong>Wrong page order:</strong> Organize via merge queue. <strong>One page pull:</strong> Split PDF.</p>
            <h2>Form filling landscape</h2>
            <p>Government PDFs mix fillable AcroForm fields and flat scans. Fillable fields preserve tab order — flat forms need positioned text boxes — print-test alignment before official submit.</p>
            <h2>Scanned document edit chain</h2>
            <ol>
            <li>Scan 300 DPI grayscale upright</li>
            <li><a href="/pdf/ocrpdf">OCR PDF</a> — verify Ctrl+F finds key term</li>
            <li><a href="/pdf/editpdf">Edit PDF</a> — add date, signature image, stamp</li>
            <li>Optional <a href="/guides/compress-pdf-for-email">compress</a> before portal upload</li>
            </ol>
            <h2>Organize without desktop Acrobat</h2>
            <p>Reorder pages in merge tool — drag queue — single merge output — same engine as <a href="/guides/merge-pdf-custom-order">custom order merge</a>. Delete pages by omitting from queue not destructive edit on source.</p>
            <h2>Image overlay best practices</h2>
            <p>Logo PNG with transparency — place top-right — do not cover existing signature block. DPI 150 sufficient for screen PDF — 300 for print-bound proposals.</p>
            <h2>Security and audit</h2>
            <p>Edited PDF is new derivative — keep unedited master for legal hold — filename suffix <code>-edited-2026-04-02</code>. Flatten annotations before court filing if local rules require.</p>
            
            
            <h2>Browser edit limitations</h2>
            <p>RatPDF edit covers common SMB needs — text add, image stamp, form fill — not InDesign prepress — not Photoshop pixel surgery. For marketing brochure pixel edits return to design source.</p>
            <h2>Mobile edit caution</h2>
            <p>Fine form alignment on phone is painful — desktop for government forms — mobile OK for initial and date on consent PDF.</p>
            <h2>Password-protected PDFs</h2>
            <p>Unlock first: <a href="/guides/unlock-pdf">unlock PDF</a> — edit fails on encrypted open.</p>
            <h2>Compare vendors</h2>
            <p><a href="/compare/adobe-alternative">Adobe</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/smallpdf-alternative">Smallpdf</a> — evaluate form-fill on your hardest government PDF sample.</p>
            <h2>Split and extract coordination</h2>
            <p>Extract signature page before sending for countersign — <a href="/guides/extract-single-page-pdf">extract single page</a> — merge back after scan with <a href="/pdf/merge">Merge PDF</a>.</p>
            <h2>QA print test</h2>
            <p>Government forms reject misaligned fields — print one copy — hold to light against blank form — adjust coordinates before batch.</p>
            
            
            <h2>Edit cluster authority map</h2>
            <p>Editing guides cover crop, delete, annotate, highlight, rearrange pages, and device workflows — plus in-depth help for <a href="/guides/edit-pdf">edit PDF</a> and <a href="/guides/rotate-pdf">rotate PDF</a>. See also merge, split, and OCR guides.</p>
            <h2>Security and compliance</h2>
            <p>Edited derivatives are new files — keep immutable master — log who edited — confidential docs cleared from Downloads on shared PCs same day. HIPAA and legal hold: counsel approves browser edit on PHI or privilege docs.</p>
            <h2>Failure triage</h2>
            <p><strong>Cannot select text:</strong> OCR first. <strong>Wrong page count after delete:</strong> off-by-one viewer index — recount. <strong>Portal rejects filled form:</strong> print-test alignment — font mismatch — try flatten. <strong>Upload timeout:</strong> Wi-Fi — compress — split.</p>
            <h2>Research links</h2>
            <p><a href="/research/attachment-size-limits">Email attachment limits</a> · <a href="/research/pdf-tool-market-comparison">PDF tool market comparison</a> · <a href="/compare">Compare hub</a>.</p>
            
            
            <h2>Workflow deep dive — Edit PDF online — complete browser editing guide (2026)</h2>
            <p>Browser workflow — no install — upload → process → download → verify in viewer before external send.</p>
            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> Edit PDF online — complete browser editing guide (2026)</figcaption></figure>
            <h2>Mobile</h2>
            <p>Safari/Chrome on phone works — Wi-Fi for files over 15 MB — save to Files before portal upload.</p>
            <h2>Failures</h2>
            <p>Timeout: retry Wi-Fi · corrupt PDF: re-export source · password: <a href="/guides/unlock-pdf">unlock</a>.</p>
            <h2>Free tier</h2>
            <p>Three uses/day — <a href="/Subscription/Plans">plans</a> for volume.</p>
            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Open tool</strong> <a href="/pdf/editpdf" class="alert-link fw-semibold">Go →</a></div>
            
            
            <h2>Real example: HR onboarding packet</h2>
            <p>Flat I-9 scan — OCR — add start date field — employee initials — merge with handbook acknowledgment — compress — upload to HRIS.</p>
            <h2>Second example: property manager lease initialed</h2>
            <p>Scan signed lease pages — add initialed watermark on page 4 rider — re-compress for email to tenant.</p>
            <h2>Third example: proposal logo</h2>
            <p>Sales exports proposal PDF from CRM — add partner logo top-left — send to client — no return to InDesign.</p>
            <h2>Discovery page pull</h2>
            <p>Counsel needs only exhibit G from 200-page production — split page range 142-148 — email to expert witness — index in cover note.</p>
            <h2>Medical admin form</h2>
            <p>Clinic scan intake form — OCR — nurse adds checkbox marks — print for patient sign — scan again for chart.</p>
            <h2>Upgrade path</h2>
            <p>High-volume form shop — <a href="/Subscription/Plans">plans</a> — see the <a href="/guides/edit-pdf">edit PDF hub</a>.</p>
            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Edit your PDF</strong> <a href="/pdf/editpdf" class="alert-link fw-semibold">Edit PDF →</a></div>
            
            
            <h2>Authority hub cross-links</h2>
            <p>Compress before portal: <a href="/guides/compress-pdf-guide">compress guide</a>. Scan pipeline: <a href="/guides/ocr-pdf">OCR guide</a>. Heavy rewrite: <a href="/guides/pdf-to-word">PDF to Word</a>. Tool index: <a href="/guides/pdf-tools">PDF tools hub</a>.</p>
            <h2>Onboarding one-pager</h2>
            <p>Scan → OCR → edit. Digital → edit. Wrong order → rearrange. Sideways → rotate. Blank → delete. Too big → compress. Pin this guide in your team wiki.</p>
            
            
            <h2>Browser vs desktop</h2>
            <p>RatPDF needs no install — IT-friendly — confidential docs review privacy policy retention window.</p>
            <h2>Chain tools</h2>
            <p>Convert → edit → compress → merge — pick order by deliverable — see the <a href="/guides/pdf-tools">PDF tools hub</a>.</p>
            <h2>Upgrade</h2>
            <p><a href="/Subscription/Plans">subscription plans</a> for daily caps on agency volume.</p>
            
            
            <h2>Cross-wave tool chain</h2>
            <p>Pick tool order by what you need to deliver. Example: photos → images PDF → OCR → edit date → compress → portal upload.</p>
            <h2>Free tier and upgrade</h2>
            <p>Three uses per day per tool on free tier — agency month-end exceeds cap — <a href="/Subscription/Plans">subscription plans</a> — predictable vs per-file credit packs.</p>
            <h2>Internal link discipline</h2>
            <p>Each guide links to related tools and comparisons so your team picks the right workflow.</p>
            <h2>Support triage</h2>
            <p>Wrong tool order causes bad output — OCR before edit on scans — compress after merge not before each file — train your team using the main tool guides.</p>
            
            
            <h2>QA before send</h2>
            <ol><li>Page count correct</li><li>Text selects if required</li><li>Images sharp at 150% zoom</li><li>File opens in Chrome PDF viewer</li><li>Size under email/portal cap</li></ol>
            <h2>Compare vendors</h2>
            <p><a href="/compare/smallpdf-alternative">Smallpdf</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/adobe-alternative">Adobe</a>.</p>
            
            
            <h2>Device matrix</h2>
            <p>Windows Edge, Mac Safari, iPhone Safari, Android Chrome — same account — no sync required — download to device storage before portal upload.</p>
            <h2>Retention hygiene</h2>
            <p>Clear Downloads on shared PC — contracts and medical admin PDFs are confidential — delete derivatives when task completes.</p>
            <h2>Filename and version control</h2>
            <p><code>Client-Doc-v2-edited.pdf</code> — never overwrite sent attachment — email thread references version.</p>
            <h2>Portal rejection loop</h2>
            <p>Reject → check size with <a href="/pdf-size-checker">size checker</a> → compress Less → split if still over → re-upload before session timeout.</p>
            <h2>Research links</h2>
            <p><a href="/research/attachment-size-limits">Attachment size limits</a> · <a href="/research/pdf-compression-benchmark">Compression benchmark</a> · <a href="/research/freelancer-invoicing-statistics">Invoicing statistics</a>.</p>
            <h2>Pillar bookmark set</h2>
            <p><a href="/guides/pdf-tools">PDF tools hub</a> · <a href="/guides/images-to-pdf">Images to PDF</a> · <a href="/guides/pdf-to-word">PDF to Word</a> · <a href="/guides/split-pdf">Split PDF</a> · <a href="/compare">Compare hub</a>.</p>
            
            
            <h2>Edit audit log</h2>
            <p>Log who edited which PDF derivative — timestamp — reason — matter number — supports litigation hold and SOX-style controls.</p>
            <h2>Flatten before external send</h2>
            <p>Some recipients see floating annotations differently — flatten or re-export PDF so logo and text boxes appear identical on all viewers.</p>
            <h2>Redaction before edit</h2>
            <p>Remove SSN and account numbers with <a href="/guides/pdf-redaction-permanent">permanent redaction</a> before adding new text — edit tool does not replace redaction workflow.</p>
            <h2>Training slide for staff</h2>
            <p>Three rules poster: OCR scans first — organize before merge — compress after combine — pin in Slack onboarding channel.</p>
            <h2>Department-specific examples</h2>
            <p><strong>HR:</strong> I-9 and handbook ack merge. <strong>Sales:</strong> logo on proposal. <strong>Legal:</strong> exhibit extract. <strong>Finance:</strong> initialed tax form. <strong>Ops:</strong> delivery note stamp.</p>
            <h2>Version rollback</h2>
            <p>Keep pre-edit master immutable — if client rejects edit — resend from master not undo in editor — filename version increments.</p>
            <h2>Collaboration handoff</h2>
            <p>Paralegal extracts page — attorney reviews in isolation — merge signed scan back — document handoff in matter management ticket.</p>
            <h2>Accessibility after edit</h2>
            <p>Added text may not be tagged — government accessibility filing may need tagged PDF specialist — SMB email deliverable usually exempt.</p>
            <h2>Pillar cross-links</h2>
            <p><a href="/guides/merge-pdf-online">merge PDF</a> · <a href="/guides/ocr-pdf">OCR PDF</a> · <a href="/guides/split-pdf">split hub</a> · <a href="/guides/pdf-tools">PDF tools hub</a>.</p>
            
            
            <h2>QA checklist — edit outputs</h2>
            <ol>
            <li>Page count matches intent after delete or rearrange</li>
            <li>Orientation correct on every page at thumbnail view</li>
            <li>Added text readable at 150% zoom and in print preview</li>
            <li>Annotations visible in Chrome PDF viewer and recipient test</li>
            <li>File size under email or portal cap — compress if needed</li>
            <li>Master archived before destructive delete</li>
            </ol>
            <h2>Department playbooks</h2>
            <p><strong>Legal:</strong> annotate review copy — master untouched. <strong>Finance:</strong> fill tax PDF — print-test. <strong>HR:</strong> OCR onboarding — merge ack. <strong>Sales:</strong> logo + date on proposal. <strong>Ops:</strong> delete blank feeder pages from scan batch.</p>
            <h2>Monthly volume</h2>
            <p>Track edit/remove jobs — exceed free tier twice in one week — finance approves <a href="/Subscription/Plans">subscription</a>.</p>
            <h2>Compare alternatives</h2>
            <p><a href="/compare/adobe-acrobat-alternative">Adobe Acrobat alternative</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/smallpdf-alternative">Smallpdf</a>.</p>
            
            
            <h2>Team rollout notes</h2>
            <p>Pin the main tool guides in your shared wiki — compress before portal, OCR before edit on scans, Word path only when ERP cannot reissue. New hires complete one sample file in first week using browser tools only — no desktop install ticket.</p>
            <h2>Support escalation path</h2>
            <p>Step 1: re-download output and open in Chrome viewer. Step 2: retry on Wi-Fi with smaller batch. Step 3: check <a href="/pdf-size-checker">size checker</a> preset. Step 4: compare tool choice on <a href="/compare">compare tools</a> if output quality insufficient.</p>
            <h2>Record retention</h2>
            <p>Keep source PDF until recipient confirms receipt — derivatives disposable after successful upload — confidential docs deleted from Downloads on shared machines same day.</p>
            <h2>Monthly volume planning</h2>
            <p>Track daily tool usage in spreadsheet — forecast upgrade need before month-end crunch — finance approves <a href="/Subscription/Plans">subscription</a> when free tier blocks twice in one week.</p>
            <h2>Incident log template</h2>
            <p>Date, source filename, tool used, error message, resolution — patterns reveal training gaps — share quarterly with ops lead.</p>
            
            
            <h2>Quick reference card</h2>
            <p>Scan → OCR → Edit. Digital → Edit direct. Reorder → Merge queue. One page → Split. Logo → Add image. Forms → Fill then print-test. Archive master before any derivative edit.</p>
            <p>Bookmark <a href="/guides/edit-pdf">edit PDF guide</a> for team onboarding — reduces wrong-tool support tickets.</p>
            <p>Wrong page order voids visa bundles — verify thumbnail strip before merge submit.</p>
            
            
            <h2>Related edit &amp; organize guides</h2>
            <ul>
            <li><a href="/guides/edit-scanned-pdf">Edit scanned PDF</a></li>
            <li><a href="/guides/organize-pdf-pages">Organize PDF pages</a></li>
            <li><a href="/guides/split-pdf-page-range">Split by page range</a></li>
            <li><a href="/guides/add-image-to-pdf">Add image to PDF</a></li>
            </ul>
            
            
            <h2>Edit-gap guides</h2>
            <ul>
            <li><a href="/guides/crop-pdf-online">Crop PDF online</a> · <a href="/guides/crop-pdf-without-adobe">Crop without Adobe</a></li>
            <li><a href="/guides/delete-pages-from-pdf">Delete pages</a> · <a href="/guides/remove-blank-pages-pdf">Remove blank pages</a></li>
            <li><a href="/guides/annotate-pdf-online">Annotate online</a> · <a href="/guides/annotate-pdf-free">Annotate free</a></li>
            <li><a href="/guides/highlight-pdf-online">Highlight PDF</a> · <a href="/guides/edit-pdf-text-online">Edit text</a></li>
            <li><a href="/guides/add-text-to-pdf">Add text</a> · <a href="/guides/fill-pdf-form-online">Fill form</a></li>
            <li><a href="/guides/rearrange-pdf-pages">Rearrange pages</a> · <a href="/guides/edit-pdf-without-acrobat">Without Acrobat</a></li>
            <li><a href="/guides/edit-pdf-on-mac">Edit on Mac</a> · <a href="/guides/edit-pdf-on-windows">Windows</a> · <a href="/guides/edit-pdf-on-iphone">iPhone</a></li>
            </ul>
            <h2>Pillar and organize links</h2>
            <p><a href="/guides/edit-pdf">Edit PDF guide</a> · <a href="/guides/rotate-pdf">Rotate PDF</a> · <a href="/guides/organize-pdf-pages">Organize pages</a> · <a href="/guides/merge-pdf">Merge guide</a> · <a href="/guides/split-pdf">Split guide</a> · <a href="/guides/ocr-pdf">OCR guide</a>.</p>
            
            
            <h2>Enterprise document workflows</h2>
            <p>Legal ops teams convert legacy contract PDFs during CLM migration — batch convert critical folders, prioritise active vendor agreements first. IT should approve browser upload policy for confidential docs.</p>

            <h2>Education sector</h2>
            <p>Faculty edit syllabus PDFs each semester — digital university PDFs convert cleanly; scanned course packs need OCR. Check campus IT data handling before upload.</p>

            <h2>Real estate</h2>
            <p>Lease amendments stored as PDF — convert to Word for redline, re-PDF for signature. Keep executed scan archived separately from working DOCX.</p>

            <h2>HR and offer letters</h2>
            <p>Template offer PDFs with merge fields sometimes break on convert — edit boilerplate in Word template instead of converting each hire if HRIS exports PDF.</p>

            <h2>Government RFP responses</h2>
            <p>Final submissions often must be PDF — use Word only for draft edits, export via <a href="/pdf/doctopdf">Word to PDF</a> for portal upload. Check RFP forbids track changes in submission.</p>

            <h2>Quality gates before client delivery</h2>
            <ol>
            <li>Spell-check in Word</li>
            <li>Compare page count vs source PDF</li>
            <li>Verify critical numbers (dates, amounts) unchanged</li>
            <li>Remove comments and track changes</li>
            <li>Export final PDF if deliverable format is PDF</li>
            </ol>

            <p>Pillar: <a href="/guides/pdf-to-word">PDF to Word guide</a> · Compare: <a href="/compare/smallpdf-alternative">Smallpdf alternative</a></p>
            
            
            <h2>Batch conversion hygiene</h2>
            <p>Converting 20 contracts? Use consistent naming <code>ClientName-contract-v1.docx</code>. Log source PDF hash if legal audit trail required.</p>

            <h2>Mobile upload caveats</h2>
            <p>Phone browsers work but large PDFs may timeout on cellular — use Wi-Fi or desktop for 50+ MB files.</p>

            <h2>Antivirus false positives</h2>
            <p>Some corporate proxies scan uploads — if blocked, try guest network or contact IT to allowlist ratpdf.com tool path.</p>

            <h2>Long-term archival</h2>
            <p>Store both source PDF and final DOCX/PDF pair — migrations sometimes need to re-edit decade-old contracts.</p>

            <h2>Regulatory and compliance edits</h2>
            <p>Privacy policies, SOC2 reports, and vendor security questionnaires arrive as PDF — convert to Word for comment, return PDF via <a href="/pdf/doctopdf">Word to PDF</a>. Legal should review material compliance wording changes.</p>

            <h2>Performance expectations</h2>
            <p>10-page digital PDF typically converts under two minutes; 200-page annual report may take longer — do not close tab during processing. Refresh only after timeout message.</p>
            
            
            <h2>Document type quick reference</h2>
            <p><strong>Contracts:</strong> digital PDF, track changes in Word. <strong>Invoices:</strong> table-heavy — check sums. <strong>Scanned forms:</strong> OCR first. <strong>Marketing PDFs:</strong> expect image blocks. <strong>Manuals:</strong> headings usually survive — update TOC in Word after edits.</p>
            <p>Upgrade for volume: <a href="/Subscription/Plans">subscription plans</a>. Pillar: <a href="/guides/pdf-to-word">PDF to Word</a>.</p>

            <h2>Stakeholder sign-off matrix</h2>
            <p>Legal reviews converted contracts; finance reviews invoice PDFs edited in Word; HR reviews offer letters. Route DOCX to the right reviewer before re-PDF. Version suffix in filename (<code>-legal-reviewed</code>) prevents accidental send of draft.</p>
            <p>After major edits, compress before email if DOCX re-export exceeds mailbox limits — see <a href="/research/pdf-compression-benchmark">PDF compression benchmark</a> for quality settings.</p>
            <p>Bookmark this page for your team's wiki — consistent PDF-to-Word steps reduce support tickets when onboarding new staff each quarter.</p>
            
            
            <h2>Failure messages</h2>
            <p><strong>Too large:</strong> compress or split. <strong>Invalid PDF:</strong> re-export source. <strong>Unreadable:</strong> re-scan don't only compress blur.</p>
            <h2>Archive discipline</h2>
            <p>Keep uncompressed master until upload or send succeeds — derivatives are disposable.</p>
            <h2>Compare tools</h2>
            <p><a href="/compare/smallpdf-alternative">Smallpdf</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/adobe-alternative">Adobe</a>.</p>
            
            
            <h2>Related guides</h2>
            <p>Editing guides cover crop, delete, annotate, highlight, rearrange pages, add text, fill forms, device workflows, blank-page cleanup, and rotate — step-by-step help for each task.</p>
            <p>Next troubleshooting wave: corrupt PDF, won’t open, print errors — bookmark <a href="/guides/pdf-tools">PDF tools hub</a> for full map.</p>
            
            
            <h2>More guides</h2>
            <p>Image, PowerPoint, and Word conversion guides, plus editing tutorials and competitor comparisons — all in one place.</p>
            <p>Main guides: <a href="/guides/images-to-pdf">images</a> · <a href="/guides/pdf-to-word">PDF to Word</a> · <a href="/guides/split-pdf">split</a> · <a href="/compare">compare</a>.</p>
            <h2>Post-action checklist</h2>
            <ol><li>Output opens in Chrome PDF viewer</li><li>Page order matches intent</li><li>Text selects if downstream edit needed</li><li>File size under email/portal cap</li><li>Master archived before deleting source</li></ol>
            <p>Bookmark the <a href="/guides/pdf-tools">PDF tools guide</a> and <a href="/compare">compare tools</a> for team onboarding — consistent tool choice reduces wrong-output support tickets.</p>
            
            
            <h2>Post-action checklist</h2>
            <ol><li>Output file opens in viewer</li><li>Text selects if required</li><li>Size under portal/email preset</li><li>Master archived</li><li>Correct tool used for next step (text vs Word vs OCR)</li></ol>
            <p>Bookmark the <a href="/guides/pdf-tools">PDF tools guide</a> and <a href="/compare">compare tools</a> for team onboarding — consistent tool choice reduces wrong-output support tickets.</p>
            <p>Re-run size checker after every derivative step — compress, split, or text export — before deleting the previous version from your working folder.</p>
            
            <p class="mt-4"><a href="/pdf/editpdf" class="btn btn-primary">Edit PDF</a> · <a href="/guides/edit-pdf">Edit PDF hub</a></p>
            """;

        private const string RotatePdf = """
            <h2>Rotate PDF pages — fix scan orientation online (2026)</h2>
            <p>RatPDF <a href="/pdf/rotateorremove">Rotate / Remove Pages</a> — Fix sideways phone scans and mixed landscape pages before merge.</p>
            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> Rotate PDF pages — fix scan orientation online (2026)</figcaption></figure>
            
            <h2>Rotate 90°, 180°, 270°</h2>
            <p>Phone scans arrive sideways — fax landscape — mixed merge orientation — <a href="/pdf/rotateorremove">Rotate / Remove</a> fixes without re-scan.</p>
            <h2>Step-by-step</h2>
            <ol>
            <li>Identify wrong pages in thumbnail view — all or subset.</li>
            <li>Upload — rotate clockwise per page or batch — preview before download.</li>
            <li>Merge with other PDFs only after orientation consistent — <a href="/guides/merge-pdf">merge guide</a>.</li>
            </ol>
            <h2>Rotate vs delete</h2>
            <p>Content correct but sideways → rotate. Blank or duplicate → remove — same tool — see <a href="/guides/delete-pages-from-pdf">delete pages</a>.</p>
            
            
            <h2>Real example: expense receipts</h2>
            <p>12 phone photos merged sideways — rotate all 90° — then compress for finance email.</p>
            <h2>Real example: textbook scan</h2>
            <p>Chapter PDF mix portrait and landscape — rotate landscape pages — consistent reading on tablet.</p>
            
            <div class="rp-mid-cta alert alert-primary my-4"><strong>Start now</strong> <a href="/pdf/rotateorremove" class="alert-link fw-semibold">Rotate / Remove Pages →</a></div>
            
            <h2>Edit vs convert vs OCR decision tree</h2>
            <p><strong>Digital PDF minor fix:</strong> Edit PDF text overlay. <strong>Heavy rewrite:</strong> PDF to Word. <strong>Scan:</strong> OCR first. <strong>Wrong page order:</strong> Organize via merge queue. <strong>One page pull:</strong> Split PDF.</p>
            <h2>Form filling landscape</h2>
            <p>Government PDFs mix fillable AcroForm fields and flat scans. Fillable fields preserve tab order — flat forms need positioned text boxes — print-test alignment before official submit.</p>
            <h2>Scanned document edit chain</h2>
            <ol>
            <li>Scan 300 DPI grayscale upright</li>
            <li><a href="/pdf/ocrpdf">OCR PDF</a> — verify Ctrl+F finds key term</li>
            <li><a href="/pdf/editpdf">Edit PDF</a> — add date, signature image, stamp</li>
            <li>Optional <a href="/guides/compress-pdf-for-email">compress</a> before portal upload</li>
            </ol>
            <h2>Organize without desktop Acrobat</h2>
            <p>Reorder pages in merge tool — drag queue — single merge output — same engine as <a href="/guides/merge-pdf-custom-order">custom order merge</a>. Delete pages by omitting from queue not destructive edit on source.</p>
            <h2>Image overlay best practices</h2>
            <p>Logo PNG with transparency — place top-right — do not cover existing signature block. DPI 150 sufficient for screen PDF — 300 for print-bound proposals.</p>
            <h2>Security and audit</h2>
            <p>Edited PDF is new derivative — keep unedited master for legal hold — filename suffix <code>-edited-2026-04-02</code>. Flatten annotations before court filing if local rules require.</p>
            
            
            <h2>Browser edit limitations</h2>
            <p>RatPDF edit covers common SMB needs — text add, image stamp, form fill — not InDesign prepress — not Photoshop pixel surgery. For marketing brochure pixel edits return to design source.</p>
            <h2>Mobile edit caution</h2>
            <p>Fine form alignment on phone is painful — desktop for government forms — mobile OK for initial and date on consent PDF.</p>
            <h2>Password-protected PDFs</h2>
            <p>Unlock first: <a href="/guides/unlock-pdf">unlock PDF</a> — edit fails on encrypted open.</p>
            <h2>Compare vendors</h2>
            <p><a href="/compare/adobe-alternative">Adobe</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/smallpdf-alternative">Smallpdf</a> — evaluate form-fill on your hardest government PDF sample.</p>
            <h2>Split and extract coordination</h2>
            <p>Extract signature page before sending for countersign — <a href="/guides/extract-single-page-pdf">extract single page</a> — merge back after scan with <a href="/pdf/merge">Merge PDF</a>.</p>
            <h2>QA print test</h2>
            <p>Government forms reject misaligned fields — print one copy — hold to light against blank form — adjust coordinates before batch.</p>
            
            
            <h2>Edit cluster authority map</h2>
            <p>Editing guides cover crop, delete, annotate, highlight, rearrange pages, and device workflows — plus in-depth help for <a href="/guides/edit-pdf">edit PDF</a> and <a href="/guides/rotate-pdf">rotate PDF</a>. See also merge, split, and OCR guides.</p>
            <h2>Security and compliance</h2>
            <p>Edited derivatives are new files — keep immutable master — log who edited — confidential docs cleared from Downloads on shared PCs same day. HIPAA and legal hold: counsel approves browser edit on PHI or privilege docs.</p>
            <h2>Failure triage</h2>
            <p><strong>Cannot select text:</strong> OCR first. <strong>Wrong page count after delete:</strong> off-by-one viewer index — recount. <strong>Portal rejects filled form:</strong> print-test alignment — font mismatch — try flatten. <strong>Upload timeout:</strong> Wi-Fi — compress — split.</p>
            <h2>Research links</h2>
            <p><a href="/research/attachment-size-limits">Email attachment limits</a> · <a href="/research/pdf-tool-market-comparison">PDF tool market comparison</a> · <a href="/compare">Compare hub</a>.</p>
            
            
            <h2>Workflow deep dive — Rotate PDF pages — fix scan orientation online (2026)</h2>
            <p>Browser workflow — no install — upload → process → download → verify in viewer before external send.</p>
            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> Rotate PDF pages — fix scan orientation online (2026)</figcaption></figure>
            <h2>Mobile</h2>
            <p>Safari/Chrome on phone works — Wi-Fi for files over 15 MB — save to Files before portal upload.</p>
            <h2>Failures</h2>
            <p>Timeout: retry Wi-Fi · corrupt PDF: re-export source · password: <a href="/guides/unlock-pdf">unlock</a>.</p>
            <h2>Free tier</h2>
            <p>Three uses/day — <a href="/Subscription/Plans">plans</a> for volume.</p>
            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Open tool</strong> <a href="/pdf/rotateorremove" class="alert-link fw-semibold">Go →</a></div>
            
            
            <h2>Real example: HR onboarding packet</h2>
            <p>Flat I-9 scan — OCR — add start date field — employee initials — merge with handbook acknowledgment — compress — upload to HRIS.</p>
            <h2>Second example: property manager lease initialed</h2>
            <p>Scan signed lease pages — add initialed watermark on page 4 rider — re-compress for email to tenant.</p>
            <h2>Third example: proposal logo</h2>
            <p>Sales exports proposal PDF from CRM — add partner logo top-left — send to client — no return to InDesign.</p>
            <h2>Discovery page pull</h2>
            <p>Counsel needs only exhibit G from 200-page production — split page range 142-148 — email to expert witness — index in cover note.</p>
            <h2>Medical admin form</h2>
            <p>Clinic scan intake form — OCR — nurse adds checkbox marks — print for patient sign — scan again for chart.</p>
            <h2>Upgrade path</h2>
            <p>High-volume form shop — <a href="/Subscription/Plans">plans</a> — see the <a href="/guides/edit-pdf">edit PDF hub</a>.</p>
            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Edit your PDF</strong> <a href="/pdf/editpdf" class="alert-link fw-semibold">Edit PDF →</a></div>
            
            
            <h2>Authority hub cross-links</h2>
            <p>Compress before portal: <a href="/guides/compress-pdf-guide">compress guide</a>. Scan pipeline: <a href="/guides/ocr-pdf">OCR guide</a>. Heavy rewrite: <a href="/guides/pdf-to-word">PDF to Word</a>. Tool index: <a href="/guides/pdf-tools">PDF tools hub</a>.</p>
            <h2>Onboarding one-pager</h2>
            <p>Scan → OCR → edit. Digital → edit. Wrong order → rearrange. Sideways → rotate. Blank → delete. Too big → compress. Pin this guide in your team wiki.</p>
            
            
            <h2>Browser vs desktop</h2>
            <p>RatPDF needs no install — IT-friendly — confidential docs review privacy policy retention window.</p>
            <h2>Chain tools</h2>
            <p>Convert → edit → compress → merge — pick order by deliverable — see the <a href="/guides/pdf-tools">PDF tools hub</a>.</p>
            <h2>Upgrade</h2>
            <p><a href="/Subscription/Plans">subscription plans</a> for daily caps on agency volume.</p>
            
            
            <h2>Cross-wave tool chain</h2>
            <p>Pick tool order by what you need to deliver. Example: photos → images PDF → OCR → edit date → compress → portal upload.</p>
            <h2>Free tier and upgrade</h2>
            <p>Three uses per day per tool on free tier — agency month-end exceeds cap — <a href="/Subscription/Plans">subscription plans</a> — predictable vs per-file credit packs.</p>
            <h2>Internal link discipline</h2>
            <p>Each guide links to related tools and comparisons so your team picks the right workflow.</p>
            <h2>Support triage</h2>
            <p>Wrong tool order causes bad output — OCR before edit on scans — compress after merge not before each file — train your team using the main tool guides.</p>
            
            
            <h2>QA before send</h2>
            <ol><li>Page count correct</li><li>Text selects if required</li><li>Images sharp at 150% zoom</li><li>File opens in Chrome PDF viewer</li><li>Size under email/portal cap</li></ol>
            <h2>Compare vendors</h2>
            <p><a href="/compare/smallpdf-alternative">Smallpdf</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/adobe-alternative">Adobe</a>.</p>
            
            
            <h2>Device matrix</h2>
            <p>Windows Edge, Mac Safari, iPhone Safari, Android Chrome — same account — no sync required — download to device storage before portal upload.</p>
            <h2>Retention hygiene</h2>
            <p>Clear Downloads on shared PC — contracts and medical admin PDFs are confidential — delete derivatives when task completes.</p>
            <h2>Filename and version control</h2>
            <p><code>Client-Doc-v2-edited.pdf</code> — never overwrite sent attachment — email thread references version.</p>
            <h2>Portal rejection loop</h2>
            <p>Reject → check size with <a href="/pdf-size-checker">size checker</a> → compress Less → split if still over → re-upload before session timeout.</p>
            <h2>Research links</h2>
            <p><a href="/research/attachment-size-limits">Attachment size limits</a> · <a href="/research/pdf-compression-benchmark">Compression benchmark</a> · <a href="/research/freelancer-invoicing-statistics">Invoicing statistics</a>.</p>
            <h2>Pillar bookmark set</h2>
            <p><a href="/guides/pdf-tools">PDF tools hub</a> · <a href="/guides/images-to-pdf">Images to PDF</a> · <a href="/guides/pdf-to-word">PDF to Word</a> · <a href="/guides/split-pdf">Split PDF</a> · <a href="/compare">Compare hub</a>.</p>
            
            
            <h2>Edit audit log</h2>
            <p>Log who edited which PDF derivative — timestamp — reason — matter number — supports litigation hold and SOX-style controls.</p>
            <h2>Flatten before external send</h2>
            <p>Some recipients see floating annotations differently — flatten or re-export PDF so logo and text boxes appear identical on all viewers.</p>
            <h2>Redaction before edit</h2>
            <p>Remove SSN and account numbers with <a href="/guides/pdf-redaction-permanent">permanent redaction</a> before adding new text — edit tool does not replace redaction workflow.</p>
            <h2>Training slide for staff</h2>
            <p>Three rules poster: OCR scans first — organize before merge — compress after combine — pin in Slack onboarding channel.</p>
            <h2>Department-specific examples</h2>
            <p><strong>HR:</strong> I-9 and handbook ack merge. <strong>Sales:</strong> logo on proposal. <strong>Legal:</strong> exhibit extract. <strong>Finance:</strong> initialed tax form. <strong>Ops:</strong> delivery note stamp.</p>
            <h2>Version rollback</h2>
            <p>Keep pre-edit master immutable — if client rejects edit — resend from master not undo in editor — filename version increments.</p>
            <h2>Collaboration handoff</h2>
            <p>Paralegal extracts page — attorney reviews in isolation — merge signed scan back — document handoff in matter management ticket.</p>
            <h2>Accessibility after edit</h2>
            <p>Added text may not be tagged — government accessibility filing may need tagged PDF specialist — SMB email deliverable usually exempt.</p>
            <h2>Pillar cross-links</h2>
            <p><a href="/guides/merge-pdf-online">merge PDF</a> · <a href="/guides/ocr-pdf">OCR PDF</a> · <a href="/guides/split-pdf">split hub</a> · <a href="/guides/pdf-tools">PDF tools hub</a>.</p>
            
            
            <h2>QA checklist — edit outputs</h2>
            <ol>
            <li>Page count matches intent after delete or rearrange</li>
            <li>Orientation correct on every page at thumbnail view</li>
            <li>Added text readable at 150% zoom and in print preview</li>
            <li>Annotations visible in Chrome PDF viewer and recipient test</li>
            <li>File size under email or portal cap — compress if needed</li>
            <li>Master archived before destructive delete</li>
            </ol>
            <h2>Department playbooks</h2>
            <p><strong>Legal:</strong> annotate review copy — master untouched. <strong>Finance:</strong> fill tax PDF — print-test. <strong>HR:</strong> OCR onboarding — merge ack. <strong>Sales:</strong> logo + date on proposal. <strong>Ops:</strong> delete blank feeder pages from scan batch.</p>
            <h2>Monthly volume</h2>
            <p>Track edit/remove jobs — exceed free tier twice in one week — finance approves <a href="/Subscription/Plans">subscription</a>.</p>
            <h2>Compare alternatives</h2>
            <p><a href="/compare/adobe-acrobat-alternative">Adobe Acrobat alternative</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/smallpdf-alternative">Smallpdf</a>.</p>
            
            
            <h2>Team rollout notes</h2>
            <p>Pin the main tool guides in your shared wiki — compress before portal, OCR before edit on scans, Word path only when ERP cannot reissue. New hires complete one sample file in first week using browser tools only — no desktop install ticket.</p>
            <h2>Support escalation path</h2>
            <p>Step 1: re-download output and open in Chrome viewer. Step 2: retry on Wi-Fi with smaller batch. Step 3: check <a href="/pdf-size-checker">size checker</a> preset. Step 4: compare tool choice on <a href="/compare">compare tools</a> if output quality insufficient.</p>
            <h2>Record retention</h2>
            <p>Keep source PDF until recipient confirms receipt — derivatives disposable after successful upload — confidential docs deleted from Downloads on shared machines same day.</p>
            <h2>Monthly volume planning</h2>
            <p>Track daily tool usage in spreadsheet — forecast upgrade need before month-end crunch — finance approves <a href="/Subscription/Plans">subscription</a> when free tier blocks twice in one week.</p>
            <h2>Incident log template</h2>
            <p>Date, source filename, tool used, error message, resolution — patterns reveal training gaps — share quarterly with ops lead.</p>
            
            
            <h2>Quick reference card</h2>
            <p>Scan → OCR → Edit. Digital → Edit direct. Reorder → Merge queue. One page → Split. Logo → Add image. Forms → Fill then print-test. Archive master before any derivative edit.</p>
            <p>Bookmark <a href="/guides/edit-pdf">edit PDF guide</a> for team onboarding — reduces wrong-tool support tickets.</p>
            <p>Wrong page order voids visa bundles — verify thumbnail strip before merge submit.</p>
            
            
            <h2>Related edit &amp; organize guides</h2>
            <ul>
            <li><a href="/guides/edit-scanned-pdf">Edit scanned PDF</a></li>
            <li><a href="/guides/organize-pdf-pages">Organize PDF pages</a></li>
            <li><a href="/guides/split-pdf-page-range">Split by page range</a></li>
            <li><a href="/guides/add-image-to-pdf">Add image to PDF</a></li>
            </ul>
            
            
            <h2>Edit-gap guides</h2>
            <ul>
            <li><a href="/guides/crop-pdf-online">Crop PDF online</a> · <a href="/guides/crop-pdf-without-adobe">Crop without Adobe</a></li>
            <li><a href="/guides/delete-pages-from-pdf">Delete pages</a> · <a href="/guides/remove-blank-pages-pdf">Remove blank pages</a></li>
            <li><a href="/guides/annotate-pdf-online">Annotate online</a> · <a href="/guides/annotate-pdf-free">Annotate free</a></li>
            <li><a href="/guides/highlight-pdf-online">Highlight PDF</a> · <a href="/guides/edit-pdf-text-online">Edit text</a></li>
            <li><a href="/guides/add-text-to-pdf">Add text</a> · <a href="/guides/fill-pdf-form-online">Fill form</a></li>
            <li><a href="/guides/rearrange-pdf-pages">Rearrange pages</a> · <a href="/guides/edit-pdf-without-acrobat">Without Acrobat</a></li>
            <li><a href="/guides/edit-pdf-on-mac">Edit on Mac</a> · <a href="/guides/edit-pdf-on-windows">Windows</a> · <a href="/guides/edit-pdf-on-iphone">iPhone</a></li>
            </ul>
            <h2>Pillar and organize links</h2>
            <p><a href="/guides/edit-pdf">Edit PDF guide</a> · <a href="/guides/rotate-pdf">Rotate PDF</a> · <a href="/guides/organize-pdf-pages">Organize pages</a> · <a href="/guides/merge-pdf">Merge guide</a> · <a href="/guides/split-pdf">Split guide</a> · <a href="/guides/ocr-pdf">OCR guide</a>.</p>
            
            
            <h2>Enterprise document workflows</h2>
            <p>Legal ops teams convert legacy contract PDFs during CLM migration — batch convert critical folders, prioritise active vendor agreements first. IT should approve browser upload policy for confidential docs.</p>

            <h2>Education sector</h2>
            <p>Faculty edit syllabus PDFs each semester — digital university PDFs convert cleanly; scanned course packs need OCR. Check campus IT data handling before upload.</p>

            <h2>Real estate</h2>
            <p>Lease amendments stored as PDF — convert to Word for redline, re-PDF for signature. Keep executed scan archived separately from working DOCX.</p>

            <h2>HR and offer letters</h2>
            <p>Template offer PDFs with merge fields sometimes break on convert — edit boilerplate in Word template instead of converting each hire if HRIS exports PDF.</p>

            <h2>Government RFP responses</h2>
            <p>Final submissions often must be PDF — use Word only for draft edits, export via <a href="/pdf/doctopdf">Word to PDF</a> for portal upload. Check RFP forbids track changes in submission.</p>

            <h2>Quality gates before client delivery</h2>
            <ol>
            <li>Spell-check in Word</li>
            <li>Compare page count vs source PDF</li>
            <li>Verify critical numbers (dates, amounts) unchanged</li>
            <li>Remove comments and track changes</li>
            <li>Export final PDF if deliverable format is PDF</li>
            </ol>

            <p>Pillar: <a href="/guides/pdf-to-word">PDF to Word guide</a> · Compare: <a href="/compare/smallpdf-alternative">Smallpdf alternative</a></p>
            
            
            <h2>Batch conversion hygiene</h2>
            <p>Converting 20 contracts? Use consistent naming <code>ClientName-contract-v1.docx</code>. Log source PDF hash if legal audit trail required.</p>

            <h2>Mobile upload caveats</h2>
            <p>Phone browsers work but large PDFs may timeout on cellular — use Wi-Fi or desktop for 50+ MB files.</p>

            <h2>Antivirus false positives</h2>
            <p>Some corporate proxies scan uploads — if blocked, try guest network or contact IT to allowlist ratpdf.com tool path.</p>

            <h2>Long-term archival</h2>
            <p>Store both source PDF and final DOCX/PDF pair — migrations sometimes need to re-edit decade-old contracts.</p>

            <h2>Regulatory and compliance edits</h2>
            <p>Privacy policies, SOC2 reports, and vendor security questionnaires arrive as PDF — convert to Word for comment, return PDF via <a href="/pdf/doctopdf">Word to PDF</a>. Legal should review material compliance wording changes.</p>

            <h2>Performance expectations</h2>
            <p>10-page digital PDF typically converts under two minutes; 200-page annual report may take longer — do not close tab during processing. Refresh only after timeout message.</p>
            
            
            <h2>Document type quick reference</h2>
            <p><strong>Contracts:</strong> digital PDF, track changes in Word. <strong>Invoices:</strong> table-heavy — check sums. <strong>Scanned forms:</strong> OCR first. <strong>Marketing PDFs:</strong> expect image blocks. <strong>Manuals:</strong> headings usually survive — update TOC in Word after edits.</p>
            <p>Upgrade for volume: <a href="/Subscription/Plans">subscription plans</a>. Pillar: <a href="/guides/pdf-to-word">PDF to Word</a>.</p>

            <h2>Stakeholder sign-off matrix</h2>
            <p>Legal reviews converted contracts; finance reviews invoice PDFs edited in Word; HR reviews offer letters. Route DOCX to the right reviewer before re-PDF. Version suffix in filename (<code>-legal-reviewed</code>) prevents accidental send of draft.</p>
            <p>After major edits, compress before email if DOCX re-export exceeds mailbox limits — see <a href="/research/pdf-compression-benchmark">PDF compression benchmark</a> for quality settings.</p>
            <p>Bookmark this page for your team's wiki — consistent PDF-to-Word steps reduce support tickets when onboarding new staff each quarter.</p>
            
            
            <h2>Failure messages</h2>
            <p><strong>Too large:</strong> compress or split. <strong>Invalid PDF:</strong> re-export source. <strong>Unreadable:</strong> re-scan don't only compress blur.</p>
            <h2>Archive discipline</h2>
            <p>Keep uncompressed master until upload or send succeeds — derivatives are disposable.</p>
            <h2>Compare tools</h2>
            <p><a href="/compare/smallpdf-alternative">Smallpdf</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/adobe-alternative">Adobe</a>.</p>
            
            
            <h2>Related guides</h2>
            <p>Editing guides cover crop, delete, annotate, highlight, rearrange pages, add text, fill forms, device workflows, blank-page cleanup, and rotate — step-by-step help for each task.</p>
            <p>Next troubleshooting wave: corrupt PDF, won’t open, print errors — bookmark <a href="/guides/pdf-tools">PDF tools hub</a> for full map.</p>
            
            
            <h2>More guides</h2>
            <p>Image, PowerPoint, and Word conversion guides, plus editing tutorials and competitor comparisons — all in one place.</p>
            <p>Main guides: <a href="/guides/images-to-pdf">images</a> · <a href="/guides/pdf-to-word">PDF to Word</a> · <a href="/guides/split-pdf">split</a> · <a href="/compare">compare</a>.</p>
            <h2>Post-action checklist</h2>
            <ol><li>Output opens in Chrome PDF viewer</li><li>Page order matches intent</li><li>Text selects if downstream edit needed</li><li>File size under email/portal cap</li><li>Master archived before deleting source</li></ol>
            <p>Bookmark the <a href="/guides/pdf-tools">PDF tools guide</a> and <a href="/compare">compare tools</a> for team onboarding — consistent tool choice reduces wrong-output support tickets.</p>
            
            
            <h2>Post-action checklist</h2>
            <ol><li>Output file opens in viewer</li><li>Text selects if required</li><li>Size under portal/email preset</li><li>Master archived</li><li>Correct tool used for next step (text vs Word vs OCR)</li></ol>
            <p>Bookmark the <a href="/guides/pdf-tools">PDF tools guide</a> and <a href="/compare">compare tools</a> for team onboarding — consistent tool choice reduces wrong-output support tickets.</p>
            <p>Re-run size checker after every derivative step — compress, split, or text export — before deleting the previous version from your working folder.</p>
            
            <p class="mt-4"><a href="/pdf/rotateorremove" class="btn btn-primary">Rotate / Remove Pages</a> · <a href="/guides/edit-pdf">Edit PDF hub</a></p>
            """;

        private const string EditPdfWithoutAcrobat = """
            <h2>Edit PDF without Adobe — free browser alternative (2026)</h2>
            <p>RatPDF <a href="/pdf/editpdf">Edit PDF</a> — Agency replaces occasional Acrobat seat with RatPDF browser stack.</p>
            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> Edit PDF without Adobe — free browser alternative (2026)</figcaption></figure>
            
            <h2>Acrobat vs browser stack</h2>
            <p>Acrobat Pro wins on prepress, batch redaction, JavaScript forms, offline classified. RatPDF wins on zero install, invoice-adjacent workflow, and predictable free tier for 3 jobs/day.</p>
            <h2>Migration checklist</h2>
            <ol>
            <li>List top 10 PDF tasks team performs monthly.</li>
            <li>Pilot RatPDF two weeks on non-critical files.</li>
            <li>Keep one Acrobat seat only if prepress or redaction required.</li>
            <li>Pin <a href="/guides/edit-pdf">edit guide</a> in wiki.</li>
            </ol>
            <h2>Cost table</h2>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>Need</th><th>RatPDF</th><th>Acrobat Pro</th></tr></thead>
            <tbody>
            <tr><td>Occasional annotate</td><td>Free tier</td><td>Annual subscription</td></tr>
            <tr><td>Merge + compress chain</td><td>Browser tools</td><td>Included</td></tr>
            <tr><td>CMYK prepress</td><td>Not target</td><td>Desktop</td></tr>
            </tbody>
            </table></div>
            
            
            <h2>Agency pilot result</h2>
            <p>12-seat creative shop — 2 Acrobat retained for print — 10 users on RatPDF merge/edit/compress — $8k annual savings documented.</p>
            <h2>When to keep Acrobat</h2>
            <p>Preflight PDF/X — batch redaction — accessibility tagging — classified offline — desktop remains.</p>
            
            <div class="rp-mid-cta alert alert-primary my-4"><strong>Start now</strong> <a href="/pdf/editpdf" class="alert-link fw-semibold">Edit PDF →</a></div>
            
            <h2>Edit vs convert vs OCR decision tree</h2>
            <p><strong>Digital PDF minor fix:</strong> Edit PDF text overlay. <strong>Heavy rewrite:</strong> PDF to Word. <strong>Scan:</strong> OCR first. <strong>Wrong page order:</strong> Organize via merge queue. <strong>One page pull:</strong> Split PDF.</p>
            <h2>Form filling landscape</h2>
            <p>Government PDFs mix fillable AcroForm fields and flat scans. Fillable fields preserve tab order — flat forms need positioned text boxes — print-test alignment before official submit.</p>
            <h2>Scanned document edit chain</h2>
            <ol>
            <li>Scan 300 DPI grayscale upright</li>
            <li><a href="/pdf/ocrpdf">OCR PDF</a> — verify Ctrl+F finds key term</li>
            <li><a href="/pdf/editpdf">Edit PDF</a> — add date, signature image, stamp</li>
            <li>Optional <a href="/guides/compress-pdf-for-email">compress</a> before portal upload</li>
            </ol>
            <h2>Organize without desktop Acrobat</h2>
            <p>Reorder pages in merge tool — drag queue — single merge output — same engine as <a href="/guides/merge-pdf-custom-order">custom order merge</a>. Delete pages by omitting from queue not destructive edit on source.</p>
            <h2>Image overlay best practices</h2>
            <p>Logo PNG with transparency — place top-right — do not cover existing signature block. DPI 150 sufficient for screen PDF — 300 for print-bound proposals.</p>
            <h2>Security and audit</h2>
            <p>Edited PDF is new derivative — keep unedited master for legal hold — filename suffix <code>-edited-2026-04-02</code>. Flatten annotations before court filing if local rules require.</p>
            
            
            <h2>Browser edit limitations</h2>
            <p>RatPDF edit covers common SMB needs — text add, image stamp, form fill — not InDesign prepress — not Photoshop pixel surgery. For marketing brochure pixel edits return to design source.</p>
            <h2>Mobile edit caution</h2>
            <p>Fine form alignment on phone is painful — desktop for government forms — mobile OK for initial and date on consent PDF.</p>
            <h2>Password-protected PDFs</h2>
            <p>Unlock first: <a href="/guides/unlock-pdf">unlock PDF</a> — edit fails on encrypted open.</p>
            <h2>Compare vendors</h2>
            <p><a href="/compare/adobe-alternative">Adobe</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/smallpdf-alternative">Smallpdf</a> — evaluate form-fill on your hardest government PDF sample.</p>
            <h2>Split and extract coordination</h2>
            <p>Extract signature page before sending for countersign — <a href="/guides/extract-single-page-pdf">extract single page</a> — merge back after scan with <a href="/pdf/merge">Merge PDF</a>.</p>
            <h2>QA print test</h2>
            <p>Government forms reject misaligned fields — print one copy — hold to light against blank form — adjust coordinates before batch.</p>
            
            
            <h2>Edit cluster authority map</h2>
            <p>Editing guides cover crop, delete, annotate, highlight, rearrange pages, and device workflows — plus in-depth help for <a href="/guides/edit-pdf">edit PDF</a> and <a href="/guides/rotate-pdf">rotate PDF</a>. See also merge, split, and OCR guides.</p>
            <h2>Security and compliance</h2>
            <p>Edited derivatives are new files — keep immutable master — log who edited — confidential docs cleared from Downloads on shared PCs same day. HIPAA and legal hold: counsel approves browser edit on PHI or privilege docs.</p>
            <h2>Failure triage</h2>
            <p><strong>Cannot select text:</strong> OCR first. <strong>Wrong page count after delete:</strong> off-by-one viewer index — recount. <strong>Portal rejects filled form:</strong> print-test alignment — font mismatch — try flatten. <strong>Upload timeout:</strong> Wi-Fi — compress — split.</p>
            <h2>Research links</h2>
            <p><a href="/research/attachment-size-limits">Email attachment limits</a> · <a href="/research/pdf-tool-market-comparison">PDF tool market comparison</a> · <a href="/compare">Compare hub</a>.</p>
            
            
            <h2>Workflow deep dive — Edit PDF without Adobe — free browser alternative (2026)</h2>
            <p>Browser workflow — no install — upload → process → download → verify in viewer before external send.</p>
            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> Edit PDF without Adobe — free browser alternative (2026)</figcaption></figure>
            <h2>Mobile</h2>
            <p>Safari/Chrome on phone works — Wi-Fi for files over 15 MB — save to Files before portal upload.</p>
            <h2>Failures</h2>
            <p>Timeout: retry Wi-Fi · corrupt PDF: re-export source · password: <a href="/guides/unlock-pdf">unlock</a>.</p>
            <h2>Free tier</h2>
            <p>Three uses/day — <a href="/Subscription/Plans">plans</a> for volume.</p>
            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Open tool</strong> <a href="/pdf/editpdf" class="alert-link fw-semibold">Go →</a></div>
            
            
            <h2>Real example: HR onboarding packet</h2>
            <p>Flat I-9 scan — OCR — add start date field — employee initials — merge with handbook acknowledgment — compress — upload to HRIS.</p>
            <h2>Second example: property manager lease initialed</h2>
            <p>Scan signed lease pages — add initialed watermark on page 4 rider — re-compress for email to tenant.</p>
            <h2>Third example: proposal logo</h2>
            <p>Sales exports proposal PDF from CRM — add partner logo top-left — send to client — no return to InDesign.</p>
            <h2>Discovery page pull</h2>
            <p>Counsel needs only exhibit G from 200-page production — split page range 142-148 — email to expert witness — index in cover note.</p>
            <h2>Medical admin form</h2>
            <p>Clinic scan intake form — OCR — nurse adds checkbox marks — print for patient sign — scan again for chart.</p>
            <h2>Upgrade path</h2>
            <p>High-volume form shop — <a href="/Subscription/Plans">plans</a> — see the <a href="/guides/edit-pdf">edit PDF hub</a>.</p>
            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Edit your PDF</strong> <a href="/pdf/editpdf" class="alert-link fw-semibold">Edit PDF →</a></div>
            
            
            <h2>Authority hub cross-links</h2>
            <p>Compress before portal: <a href="/guides/compress-pdf-guide">compress guide</a>. Scan pipeline: <a href="/guides/ocr-pdf">OCR guide</a>. Heavy rewrite: <a href="/guides/pdf-to-word">PDF to Word</a>. Tool index: <a href="/guides/pdf-tools">PDF tools hub</a>.</p>
            <h2>Onboarding one-pager</h2>
            <p>Scan → OCR → edit. Digital → edit. Wrong order → rearrange. Sideways → rotate. Blank → delete. Too big → compress. Pin this guide in your team wiki.</p>
            
            
            <h2>Browser vs desktop</h2>
            <p>RatPDF needs no install — IT-friendly — confidential docs review privacy policy retention window.</p>
            <h2>Chain tools</h2>
            <p>Convert → edit → compress → merge — pick order by deliverable — see the <a href="/guides/pdf-tools">PDF tools hub</a>.</p>
            <h2>Upgrade</h2>
            <p><a href="/Subscription/Plans">subscription plans</a> for daily caps on agency volume.</p>
            
            
            <h2>Cross-wave tool chain</h2>
            <p>Pick tool order by what you need to deliver. Example: photos → images PDF → OCR → edit date → compress → portal upload.</p>
            <h2>Free tier and upgrade</h2>
            <p>Three uses per day per tool on free tier — agency month-end exceeds cap — <a href="/Subscription/Plans">subscription plans</a> — predictable vs per-file credit packs.</p>
            <h2>Internal link discipline</h2>
            <p>Each guide links to related tools and comparisons so your team picks the right workflow.</p>
            <h2>Support triage</h2>
            <p>Wrong tool order causes bad output — OCR before edit on scans — compress after merge not before each file — train your team using the main tool guides.</p>
            
            
            <h2>QA before send</h2>
            <ol><li>Page count correct</li><li>Text selects if required</li><li>Images sharp at 150% zoom</li><li>File opens in Chrome PDF viewer</li><li>Size under email/portal cap</li></ol>
            <h2>Compare vendors</h2>
            <p><a href="/compare/smallpdf-alternative">Smallpdf</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/adobe-alternative">Adobe</a>.</p>
            
            
            <h2>Device matrix</h2>
            <p>Windows Edge, Mac Safari, iPhone Safari, Android Chrome — same account — no sync required — download to device storage before portal upload.</p>
            <h2>Retention hygiene</h2>
            <p>Clear Downloads on shared PC — contracts and medical admin PDFs are confidential — delete derivatives when task completes.</p>
            <h2>Filename and version control</h2>
            <p><code>Client-Doc-v2-edited.pdf</code> — never overwrite sent attachment — email thread references version.</p>
            <h2>Portal rejection loop</h2>
            <p>Reject → check size with <a href="/pdf-size-checker">size checker</a> → compress Less → split if still over → re-upload before session timeout.</p>
            <h2>Research links</h2>
            <p><a href="/research/attachment-size-limits">Attachment size limits</a> · <a href="/research/pdf-compression-benchmark">Compression benchmark</a> · <a href="/research/freelancer-invoicing-statistics">Invoicing statistics</a>.</p>
            <h2>Pillar bookmark set</h2>
            <p><a href="/guides/pdf-tools">PDF tools hub</a> · <a href="/guides/images-to-pdf">Images to PDF</a> · <a href="/guides/pdf-to-word">PDF to Word</a> · <a href="/guides/split-pdf">Split PDF</a> · <a href="/compare">Compare hub</a>.</p>
            
            
            <h2>Edit audit log</h2>
            <p>Log who edited which PDF derivative — timestamp — reason — matter number — supports litigation hold and SOX-style controls.</p>
            <h2>Flatten before external send</h2>
            <p>Some recipients see floating annotations differently — flatten or re-export PDF so logo and text boxes appear identical on all viewers.</p>
            <h2>Redaction before edit</h2>
            <p>Remove SSN and account numbers with <a href="/guides/pdf-redaction-permanent">permanent redaction</a> before adding new text — edit tool does not replace redaction workflow.</p>
            <h2>Training slide for staff</h2>
            <p>Three rules poster: OCR scans first — organize before merge — compress after combine — pin in Slack onboarding channel.</p>
            <h2>Department-specific examples</h2>
            <p><strong>HR:</strong> I-9 and handbook ack merge. <strong>Sales:</strong> logo on proposal. <strong>Legal:</strong> exhibit extract. <strong>Finance:</strong> initialed tax form. <strong>Ops:</strong> delivery note stamp.</p>
            <h2>Version rollback</h2>
            <p>Keep pre-edit master immutable — if client rejects edit — resend from master not undo in editor — filename version increments.</p>
            <h2>Collaboration handoff</h2>
            <p>Paralegal extracts page — attorney reviews in isolation — merge signed scan back — document handoff in matter management ticket.</p>
            <h2>Accessibility after edit</h2>
            <p>Added text may not be tagged — government accessibility filing may need tagged PDF specialist — SMB email deliverable usually exempt.</p>
            <h2>Pillar cross-links</h2>
            <p><a href="/guides/merge-pdf-online">merge PDF</a> · <a href="/guides/ocr-pdf">OCR PDF</a> · <a href="/guides/split-pdf">split hub</a> · <a href="/guides/pdf-tools">PDF tools hub</a>.</p>
            
            
            <h2>QA checklist — edit outputs</h2>
            <ol>
            <li>Page count matches intent after delete or rearrange</li>
            <li>Orientation correct on every page at thumbnail view</li>
            <li>Added text readable at 150% zoom and in print preview</li>
            <li>Annotations visible in Chrome PDF viewer and recipient test</li>
            <li>File size under email or portal cap — compress if needed</li>
            <li>Master archived before destructive delete</li>
            </ol>
            <h2>Department playbooks</h2>
            <p><strong>Legal:</strong> annotate review copy — master untouched. <strong>Finance:</strong> fill tax PDF — print-test. <strong>HR:</strong> OCR onboarding — merge ack. <strong>Sales:</strong> logo + date on proposal. <strong>Ops:</strong> delete blank feeder pages from scan batch.</p>
            <h2>Monthly volume</h2>
            <p>Track edit/remove jobs — exceed free tier twice in one week — finance approves <a href="/Subscription/Plans">subscription</a>.</p>
            <h2>Compare alternatives</h2>
            <p><a href="/compare/adobe-acrobat-alternative">Adobe Acrobat alternative</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/smallpdf-alternative">Smallpdf</a>.</p>
            
            
            <h2>Team rollout notes</h2>
            <p>Pin the main tool guides in your shared wiki — compress before portal, OCR before edit on scans, Word path only when ERP cannot reissue. New hires complete one sample file in first week using browser tools only — no desktop install ticket.</p>
            <h2>Support escalation path</h2>
            <p>Step 1: re-download output and open in Chrome viewer. Step 2: retry on Wi-Fi with smaller batch. Step 3: check <a href="/pdf-size-checker">size checker</a> preset. Step 4: compare tool choice on <a href="/compare">compare tools</a> if output quality insufficient.</p>
            <h2>Record retention</h2>
            <p>Keep source PDF until recipient confirms receipt — derivatives disposable after successful upload — confidential docs deleted from Downloads on shared machines same day.</p>
            <h2>Monthly volume planning</h2>
            <p>Track daily tool usage in spreadsheet — forecast upgrade need before month-end crunch — finance approves <a href="/Subscription/Plans">subscription</a> when free tier blocks twice in one week.</p>
            <h2>Incident log template</h2>
            <p>Date, source filename, tool used, error message, resolution — patterns reveal training gaps — share quarterly with ops lead.</p>
            
            
            <h2>Quick reference card</h2>
            <p>Scan → OCR → Edit. Digital → Edit direct. Reorder → Merge queue. One page → Split. Logo → Add image. Forms → Fill then print-test. Archive master before any derivative edit.</p>
            <p>Bookmark <a href="/guides/edit-pdf">edit PDF guide</a> for team onboarding — reduces wrong-tool support tickets.</p>
            <p>Wrong page order voids visa bundles — verify thumbnail strip before merge submit.</p>
            
            
            <h2>Related edit &amp; organize guides</h2>
            <ul>
            <li><a href="/guides/edit-scanned-pdf">Edit scanned PDF</a></li>
            <li><a href="/guides/organize-pdf-pages">Organize PDF pages</a></li>
            <li><a href="/guides/split-pdf-page-range">Split by page range</a></li>
            <li><a href="/guides/add-image-to-pdf">Add image to PDF</a></li>
            </ul>
            
            
            <h2>Edit-gap guides</h2>
            <ul>
            <li><a href="/guides/crop-pdf-online">Crop PDF online</a> · <a href="/guides/crop-pdf-without-adobe">Crop without Adobe</a></li>
            <li><a href="/guides/delete-pages-from-pdf">Delete pages</a> · <a href="/guides/remove-blank-pages-pdf">Remove blank pages</a></li>
            <li><a href="/guides/annotate-pdf-online">Annotate online</a> · <a href="/guides/annotate-pdf-free">Annotate free</a></li>
            <li><a href="/guides/highlight-pdf-online">Highlight PDF</a> · <a href="/guides/edit-pdf-text-online">Edit text</a></li>
            <li><a href="/guides/add-text-to-pdf">Add text</a> · <a href="/guides/fill-pdf-form-online">Fill form</a></li>
            <li><a href="/guides/rearrange-pdf-pages">Rearrange pages</a> · <a href="/guides/edit-pdf-without-acrobat">Without Acrobat</a></li>
            <li><a href="/guides/edit-pdf-on-mac">Edit on Mac</a> · <a href="/guides/edit-pdf-on-windows">Windows</a> · <a href="/guides/edit-pdf-on-iphone">iPhone</a></li>
            </ul>
            <h2>Pillar and organize links</h2>
            <p><a href="/guides/edit-pdf">Edit PDF guide</a> · <a href="/guides/rotate-pdf">Rotate PDF</a> · <a href="/guides/organize-pdf-pages">Organize pages</a> · <a href="/guides/merge-pdf">Merge guide</a> · <a href="/guides/split-pdf">Split guide</a> · <a href="/guides/ocr-pdf">OCR guide</a>.</p>
            
            
            <h2>Enterprise document workflows</h2>
            <p>Legal ops teams convert legacy contract PDFs during CLM migration — batch convert critical folders, prioritise active vendor agreements first. IT should approve browser upload policy for confidential docs.</p>

            <h2>Education sector</h2>
            <p>Faculty edit syllabus PDFs each semester — digital university PDFs convert cleanly; scanned course packs need OCR. Check campus IT data handling before upload.</p>

            <h2>Real estate</h2>
            <p>Lease amendments stored as PDF — convert to Word for redline, re-PDF for signature. Keep executed scan archived separately from working DOCX.</p>

            <h2>HR and offer letters</h2>
            <p>Template offer PDFs with merge fields sometimes break on convert — edit boilerplate in Word template instead of converting each hire if HRIS exports PDF.</p>

            <h2>Government RFP responses</h2>
            <p>Final submissions often must be PDF — use Word only for draft edits, export via <a href="/pdf/doctopdf">Word to PDF</a> for portal upload. Check RFP forbids track changes in submission.</p>

            <h2>Quality gates before client delivery</h2>
            <ol>
            <li>Spell-check in Word</li>
            <li>Compare page count vs source PDF</li>
            <li>Verify critical numbers (dates, amounts) unchanged</li>
            <li>Remove comments and track changes</li>
            <li>Export final PDF if deliverable format is PDF</li>
            </ol>

            <p>Pillar: <a href="/guides/pdf-to-word">PDF to Word guide</a> · Compare: <a href="/compare/smallpdf-alternative">Smallpdf alternative</a></p>
            
            
            <h2>Batch conversion hygiene</h2>
            <p>Converting 20 contracts? Use consistent naming <code>ClientName-contract-v1.docx</code>. Log source PDF hash if legal audit trail required.</p>

            <h2>Mobile upload caveats</h2>
            <p>Phone browsers work but large PDFs may timeout on cellular — use Wi-Fi or desktop for 50+ MB files.</p>

            <h2>Antivirus false positives</h2>
            <p>Some corporate proxies scan uploads — if blocked, try guest network or contact IT to allowlist ratpdf.com tool path.</p>

            <h2>Long-term archival</h2>
            <p>Store both source PDF and final DOCX/PDF pair — migrations sometimes need to re-edit decade-old contracts.</p>

            <h2>Regulatory and compliance edits</h2>
            <p>Privacy policies, SOC2 reports, and vendor security questionnaires arrive as PDF — convert to Word for comment, return PDF via <a href="/pdf/doctopdf">Word to PDF</a>. Legal should review material compliance wording changes.</p>

            <h2>Performance expectations</h2>
            <p>10-page digital PDF typically converts under two minutes; 200-page annual report may take longer — do not close tab during processing. Refresh only after timeout message.</p>
            
            
            <h2>Document type quick reference</h2>
            <p><strong>Contracts:</strong> digital PDF, track changes in Word. <strong>Invoices:</strong> table-heavy — check sums. <strong>Scanned forms:</strong> OCR first. <strong>Marketing PDFs:</strong> expect image blocks. <strong>Manuals:</strong> headings usually survive — update TOC in Word after edits.</p>
            <p>Upgrade for volume: <a href="/Subscription/Plans">subscription plans</a>. Pillar: <a href="/guides/pdf-to-word">PDF to Word</a>.</p>

            <h2>Stakeholder sign-off matrix</h2>
            <p>Legal reviews converted contracts; finance reviews invoice PDFs edited in Word; HR reviews offer letters. Route DOCX to the right reviewer before re-PDF. Version suffix in filename (<code>-legal-reviewed</code>) prevents accidental send of draft.</p>
            <p>After major edits, compress before email if DOCX re-export exceeds mailbox limits — see <a href="/research/pdf-compression-benchmark">PDF compression benchmark</a> for quality settings.</p>
            <p>Bookmark this page for your team's wiki — consistent PDF-to-Word steps reduce support tickets when onboarding new staff each quarter.</p>
            
            
            <h2>Failure messages</h2>
            <p><strong>Too large:</strong> compress or split. <strong>Invalid PDF:</strong> re-export source. <strong>Unreadable:</strong> re-scan don't only compress blur.</p>
            <h2>Archive discipline</h2>
            <p>Keep uncompressed master until upload or send succeeds — derivatives are disposable.</p>
            <h2>Compare tools</h2>
            <p><a href="/compare/smallpdf-alternative">Smallpdf</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/adobe-alternative">Adobe</a>.</p>
            
            
            <h2>Related guides</h2>
            <p>Editing guides cover crop, delete, annotate, highlight, rearrange pages, add text, fill forms, device workflows, blank-page cleanup, and rotate — step-by-step help for each task.</p>
            <p>Next troubleshooting wave: corrupt PDF, won’t open, print errors — bookmark <a href="/guides/pdf-tools">PDF tools hub</a> for full map.</p>
            
            
            <h2>More guides</h2>
            <p>Image, PowerPoint, and Word conversion guides, plus editing tutorials and competitor comparisons — all in one place.</p>
            <p>Main guides: <a href="/guides/images-to-pdf">images</a> · <a href="/guides/pdf-to-word">PDF to Word</a> · <a href="/guides/split-pdf">split</a> · <a href="/compare">compare</a>.</p>
            <h2>Post-action checklist</h2>
            <ol><li>Output opens in Chrome PDF viewer</li><li>Page order matches intent</li><li>Text selects if downstream edit needed</li><li>File size under email/portal cap</li><li>Master archived before deleting source</li></ol>
            <p>Bookmark the <a href="/guides/pdf-tools">PDF tools guide</a> and <a href="/compare">compare tools</a> for team onboarding — consistent tool choice reduces wrong-output support tickets.</p>
            
            
            <h2>Post-action checklist</h2>
            <ol><li>Output file opens in viewer</li><li>Text selects if required</li><li>Size under portal/email preset</li><li>Master archived</li><li>Correct tool used for next step (text vs Word vs OCR)</li></ol>
            <p>Bookmark the <a href="/guides/pdf-tools">PDF tools guide</a> and <a href="/compare">compare tools</a> for team onboarding — consistent tool choice reduces wrong-output support tickets.</p>
            <p>Re-run size checker after every derivative step — compress, split, or text export — before deleting the previous version from your working folder.</p>
            
            <p class="mt-4"><a href="/pdf/editpdf" class="btn btn-primary">Edit PDF</a> · <a href="/guides/edit-pdf">Edit PDF hub</a></p>
            """;

    }
}
