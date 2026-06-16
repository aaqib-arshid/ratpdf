namespace ratpdf.Content
{
    /// <summary>Wave 7 — Pillar authority upgrades (compress, merge, split, pdf-to-word, ocr).</summary>
    internal static class GuideBodiesWave7
    {
        public static string? Get(string slug) => slug switch
        {
            "compress-pdf-guide" => CompressPdfGuide,
            "merge-pdf" => MergePdf,
            "split-pdf" => SplitPdf,
            "pdf-to-word" => PdfToWord,
            "ocr-pdf" => OcrPdf,
            _ => null
        };

        private const string CompressPdfGuide = """
            <h2>How to Compress PDF Online — Complete Guide (2026)</h2>
            <p>Authoritative guide for <strong>Compress PDF</strong> in your browser — no Adobe install. Updated 2026.</p>
            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> How to Compress PDF Online — Complete Guide (2026)</figcaption></figure>
            
            <h2>Why PDF file size blocks real work</h2>
            <p>Gmail caps messages around 25 MB. Outlook tenants often enforce 20 MB. Government portals reject 4.8 MB scans when the slot allows 2 MB. Job boards silently fail uploads. The fix is almost always <strong>re-encoding embedded images</strong> — not retyping the document.</p>
            <p>RatPDF <a href="/pdf/compress">Compress PDF</a> uses <strong>Ghostscript</strong> with three profiles: Less, Recommended, and Extreme.</p>
            <h2>Compression levels — when to use each</h2>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>Level</th><th>Best for</th><th>Avoid when</th></tr></thead>
            <tbody>
            <tr><td><strong>Less</strong></td><td>Signed forms, notary stamps, legal footnotes</td><td>Need maximum size drop on photo brochures</td></tr>
            <tr><td><strong>Recommended</strong></td><td>Email, LMS, most portals — default</td><td>Already-tiny digital PDF</td></tr>
            <tr><td><strong>Extreme</strong></td><td>Last resort when portal still rejects</td><td>Fine print must stay legible</td></tr>
            </tbody>
            </table></div>
            <h2>Step-by-step: compress PDF in browser</h2>
            <ol>
            <li>Check size with <a href="/pdf-size-checker">PDF size checker</a>.</li>
            <li>Open <a href="/pdf/compress">Compress PDF</a>.</li>
            <li>Start with <strong>Recommended</strong>.</li>
            <li>Verify stamps and small text at 150% zoom.</li>
            <li>Still over cap? Extreme once, or <a href="/guides/split-pdf-for-email">split for email</a>.</li>
            </ol>
            <h2>Real example: 18 MB expense scan → Gmail</h2>
            <p>40 receipts scanned → Recommended → 5.2 MB → sent with claim ID in subject.</p>
            <h2>Real example: visa bundle → VFS 5 MB cap</h2>
            <p><a href="/guides/merge-pdf-visa-application">Merge visa docs</a> first, then one Recommended compress. Verify MRZ legibility.</p>
            <h2>Scanned vs digital</h2>
            <p>Scans compress 50–70%; digital Word exports often 10–25%. <a href="/guides/compress-scanned-vs-digital-pdf">Scanned vs digital guide</a>.</p>
            <h2>When compression increases size</h2>
            <p><a href="/guides/compress-pdf-made-it-larger">Why compression made PDF larger</a>.</p>
            <h2>Device &amp; portal guides</h2>
            <ul>
            <li><a href="/guides/compress-pdf-on-mac">Mac</a> · <a href="/guides/compress-pdf-on-windows">Windows</a> · <a href="/guides/compress-pdf-on-iphone">iPhone</a></li>
            <li><a href="/guides/compress-pdf-for-gmail">Gmail</a> · <a href="/guides/compress-pdf-for-email">Email hub</a> · <a href="/guides/compress-pdf-for-visa-application">Visa</a></li>
            <li><a href="/guides/batch-compress-pdf">Batch</a> · <a href="/guides/ghostscript-pdf-compression">Ghostscript explained</a></li>
            </ul>
            <h2>FAQ — compress PDF</h2>
            <p><strong>Free?</strong> Three/day free tier. <strong>Text selectable?</strong> Yes on digital PDFs. <strong>Encrypted?</strong> <a href="/guides/unlock-pdf">Unlock first</a>.</p>
            
            <div class="rp-mid-cta alert alert-primary my-4"><strong>Open Compress PDF tool</strong> <a href="/pdf/compress" class="alert-link fw-semibold">Compress PDF →</a></div>
            
            <h2>Scan hygiene before compress</h2>
            <p>Phone photos at full resolution produce 15–40 MB single-page PDFs. Scan <strong>200–300 DPI grayscale</strong> for text proofs — colour only when stamps matter. Rotate before upload. Crop black borders from phone camera edges — empty pixels still add weight after JPEG encode.</p>

            <h2>Double-compression trap</h2>
            <p>Compress → merge → compress again softens text twice. Prefer <strong>one compression pass</strong> after final bundle is assembled. If first pass used Extreme, second pass rarely helps — re-scan or split instead.</p>

            <h2>ATS and text layer</h2>
            <p>Job PDFs must stay text-selectable after compress — avoid Extreme on vector resumes. <a href="/guides/compress-pdf-for-job-application">Job application guide</a> · <a href="/guides/compress-pdf-for-indeed">Indeed</a> · <a href="/guides/compress-pdf-for-naukri">Naukri</a>.</p>

            <h2>Portal size reference (verify live)</h2>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>Destination</th><th>Typical cap</th><th>Notes</th></tr></thead>
            <tbody>
            <tr><td>Gmail attachment</td><td>25 MB message</td><td>Base64 overhead ~33%</td></tr>
            <tr><td>Schengen VFS</td><td>2–5 MB</td><td>Merge then compress</td></tr>
            <tr><td>India govt portals</td><td>500 KB–5 MB</td><td>Per slot, not merged</td></tr>
            <tr><td>CM/ECF courts</td><td>35 MB filing</td><td>Exhibits may be lower</td></tr>
            <tr><td>Common App</td><td>~10 MB</td><td>Per document</td></tr>
            </tbody>
            </table></div>
            <p>Always confirm on the live upload widget — caps change without notice.</p>

            <h2>Ghostscript internals (plain English)</h2>
            <p>Compression re-encodes embedded raster images, removes duplicate font subsets, and strips unused objects. Vector text paths are not rasterised unless you flatten the PDF elsewhere first. That is why a 200-page text-only annual report may compress 8% while a 10-page photo brochure drops 70%.</p>

            <h2>Upgrade prompt</h2>
            <p>High daily volume: <a href="/Subscription/Plans">compare plans</a> · Compare: <a href="/compare/smallpdf-alternative">Smallpdf alternative</a> · <a href="/compare/ilovepdf-alternative">iLovePDF alternative</a>.</p>
            
            <h2>Mobile compress on iOS/Android</h2>
            <p>Safari/Chrome compress without app install — save to Files, attach to portal. <a href="/guides/compress-pdf-on-iphone">iPhone workflow</a> · Android: upload from Downloads after compress, not ephemeral chat attachment.</p>

            <h2>Post-compress QA checklist</h2>
            <ol>
            <li>Page count unchanged</li>
            <li>Text still selects (ATS/legal)</li>
            <li>Signatures/stamps legible at 150% zoom</li>
            <li>Hyperlinks work if present</li>
            <li>File size under portal preset</li>
            <li>PDF opens without password unless intended</li>
            <li>File extension .pdf not .pdf.pdf from browser quirk</li>
            </ol>

            <h2>Bandwidth and retry logic</h2>
            <p>Rural upload on 3 Mbps: 8 MB file needs ~30 seconds — do not refresh mid-upload. If portal times out, compress further or split — error rarely means server down; usually size.</p>

            <h2>Closing summary</h2>
            <p>Compress is reversible only if you kept the original — never delete masters until upload succeeds. Chain tools: merge → OCR → compress as workflow demands. Main guide: <a href="/guides/compress-pdf-guide">full compress PDF guide</a>.</p>
            
            <h2>Ghostscript compression levels explained</h2>
            <p><strong>Less:</strong> minimal image re-encoding — use for legal scans and signatures. <strong>Recommended:</strong> default for email and portals. <strong>Extreme:</strong> last resort when portal still rejects — verify text at 100% zoom.</p>

            <h2>When compression fails to help</h2>
            <p>Already-optimised digital PDFs may shrink only 5–15%. If still over cap, <a href="/guides/split-pdf">split PDF</a> or merge-then-compress workflow — <a href="/guides/compress-before-merge-pdf">decision guide</a>. Password-protected PDFs must be <a href="/guides/unlock-pdf">unlocked</a> before compress shows true size drop.</p>

            <h2>Size checker workflow</h2>
            <p>Upload to <a href="/pdf-size-checker">PDF size checker</a> with preset (Gmail 20 MB, portal 5 MB) before and after compress — avoids guesswork. Log before/after MB in ticket if helping client remotely.</p>

            <h2>Linearise for web view</h2>
            <p>Some portals re-render first page preview — very large files may timeout preview while upload succeeds — compress improves preview reliability on slow connections.</p>

            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Shrink your PDF now</strong> <a href="/pdf/compress" class="alert-link fw-semibold">Compress PDF →</a></div>
            
            <h2>Industry cross-links</h2>
            <p>Lawyers: <a href="/guides/compress-pdf-lawyers">compress for lawyers</a> · Realtors: <a href="/guides/compress-pdf-realtors">realtors</a> · Healthcare: <a href="/guides/compress-pdf-healthcare">healthcare</a> · Accountants: <a href="/guides/compress-pdf-accountants">accountants</a>.</p>

            <h2>Merge and OCR chain</h2>
            <p>OCR'd scans are larger — <a href="/guides/ocr-pdf">OCR PDF</a> then compress. Multi-file: <a href="/guides/merge-pdf-online">merge</a> then <a href="/guides/compress-before-merge-pdf">compress decision</a>.</p>
            
            <h2>Portal rejection messages decoded</h2>
            <p><strong>"File size exceeds maximum"</strong> — compress or split. <strong>"Invalid PDF"</strong> — re-export from source, not just compress corrupted file. <strong>"Password protected"</strong> — unlock first. <strong>"Scan not readable"</strong> — re-scan at 200 DPI, do not only compress blurry source.</p>

            <h2>Batch compress for accountants</h2>
            <p>Month-end: 40 vendor invoices over Gmail cap — batch compress with Recommended, verify GSTIN on each, attach individually not one zip (many portals block zip).</p>

            <h2>Encryption and compress order</h2>
            <p>Compress before password-protecting final delivery — encrypted PDFs compress poorly. Client portal wants encrypted upload? Ask if they accept compress-then-encrypt workflow.</p>

            <h2>Colour vs grayscale for government</h2>
            <p>Passport stamps in colour — grayscale may lose red ink visibility. Test one page before batch converting colour scans.</p>

            <h2>Compare tools honestly</h2>
            <p><a href="/compare/smallpdf-alternative">Smallpdf</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/adobe-alternative">Adobe</a> — RatPDF uses Ghostscript server-side; no desktop install.</p>

            <h2>Freelancer archive hygiene</h2>
            <p>Five years of contracts at 2 MB each = 10 GB — compress archive copies, keep originals for active disputes only.</p>

            <h2>Re-scan vs re-compress decision</h2>
            <p>If clerk says "illegible" not "too large" — higher DPI re-scan beats Extreme on blurry source. Compression cannot invent detail that was never captured.</p>
            
            <h2>Seasonal and deadline workflows</h2>
            <p>Tax season, college application deadlines, and court filing cutoffs create traffic spikes on compress tools. Prepare files the day before: scan at correct DPI, name files by portal slot, run compress with headroom under cap. Last-minute Extreme compression on illegible source wastes one rejection cycle you cannot afford on deadline night.</p>

            <h2>Corporate IT policy angle</h2>
            <p>Some enterprises block consumer PDF SaaS — RatPDF runs in browser without install; still verify DLP policy allows upload of client matter. Compress copies for external portal while privileged master stays on firm DMS. Log which derivative left the organisation.</p>

            <h2>Accessibility after compress</h2>
            <p>Tagged accessible PDFs remain tagged through Ghostscript compress in most cases — verify heading navigation after compress if publishing for public sector. <a href="/guides/wcag-22-pdf">WCAG 2.2 PDF guide</a>.</p>

            <h2>Split and merge decision recap</h2>
            <p>One slot: merge then compress. Many slots: compress each. Too large after Less: <a href="/guides/split-pdf">split</a>. Password blocked: <a href="/guides/unlock-pdf">unlock</a> first. Image-only scan needing search: <a href="/guides/ocr-pdf">OCR</a> then compress.</p>

            <h2>Support escalation data to collect</h2>
            <p>If upload still fails after compress: exact portal error text, cap in MB/KB, original size, compressed size, compression level used, screenshot of upload widget. Support resolves faster with that bundle than "it does not work."</p>

            <h2>Preserve evidence chain</h2>
            <p>Immigration and insurance claims sometimes audit whether PDF was altered — keep original scan plus compressed submit copy with dated filename. Hash both if organisation policy requires integrity proofs.</p>
            
            <h2>Related guides &amp; cluster links</h2>
            <ul>
            <li><a href="/guides/compress-pdf-guide">Compress PDF guide</a></li>
            <li><a href="/guides/compress-pdf-for-email">Compress for email</a></li>
            <li><a href="/guides/compress-before-merge-pdf">Compress before/after merge</a></li>
            <li><a href="/guides/compress-pdf-without-quality-loss">Compress without quality loss</a></li>
            </ul>
            <p>Research: <a href="/research/pdf-compression-benchmark">PDF compression benchmark</a> · <a href="/research/attachment-size-limits">Attachment size limits</a></p>
            
            
            <h2>Industry compression playbooks</h2>
            <h3>Legal</h3>
            <p>Exhibits with notary seals — Less only. E-filing: <a href="/guides/compress-pdf-efiling">e-filing compress</a> · <a href="/guides/compress-pdf-lawyers">lawyers guide</a>.</p>
            <h3>Healthcare admin</h3>
            <p>Payer portals — <a href="/guides/compress-pdf-healthcare-admin">healthcare compress</a> — PHI stays encrypted in transit; delete Downloads after upload.</p>
            <h3>Education</h3>
            <p>LMS caps — <a href="/guides/compress-pdf-for-lms">LMS compress</a> · <a href="/guides/compress-pdf-students">students</a> · <a href="/guides/compress-pdf-teachers">teachers</a>.</p>
            <h3>Real estate</h3>
            <p>Disclosure packs — <a href="/guides/compress-pdf-real-estate">real estate compress</a> — merge disclosures first if one attachment.</p>
            <h2>Monitoring compression ROI</h2>
            <p>Log before/after MB per document type quarterly — patterns reveal scan DPI problems vs tool choice problems. Cite <a href="/research/pdf-compression-benchmark">benchmark study</a> when training staff.</p>
            <h2>Compare compress tools</h2>
            <p><a href="/compare/smallpdf-alternative">Smallpdf</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/pdf24-alternative">PDF24</a> · <a href="/compare/adobe-acrobat-alternative">Adobe</a>.</p>
            
            
            <h2>Month-end AP batch workflow</h2>
            <p>Forty vendor invoice PDFs — compress each Recommended — verify line items legible — attach individually. Free tier three/day — prioritize largest files or upgrade.</p>
            <h2>Construction permit upload</h2>
            <p>Site photo PDF 22 MB — Less preserves stamp — portal 10 MB — split drawings if still over.</p>
            <h2>Related guides</h2>
            <p><a href="/guides/why-is-pdf-file-so-large">Why PDF so large</a> · <a href="/guides/pdf-email-attachment-checklist">Email checklist</a> · <a href="/guides/compress-pdf-cloud-storage">Cloud storage</a>.</p>
            
            
            <h2>Compression guides</h2>
            <p>This guide links every compress workflow on RatPDF. Use it as your index when training teams.</p>
            <ul>
            <li>Email: <a href="/guides/compress-pdf-for-gmail">Gmail</a>, <a href="/guides/compress-pdf-for-outlook">Outlook</a>, <a href="/guides/compress-pdf-for-yahoo-mail">Yahoo</a>, <a href="/guides/compress-pdf-for-protonmail">Proton</a>, <a href="/guides/compress-pdf-for-whatsapp">WhatsApp</a>, <a href="/guides/compress-pdf-for-telegram">Telegram</a></li>
            <li>Jobs: <a href="/guides/compress-pdf-for-indeed">Indeed</a>, <a href="/guides/compress-pdf-for-naukri">Naukri</a>, <a href="/guides/compress-pdf-for-linkedin">LinkedIn</a>, <a href="/guides/compress-pdf-for-workday">Workday</a>, <a href="/guides/compress-pdf-usajobs">USAJOBS</a></li>
            <li>Education: <a href="/guides/compress-pdf-for-lms">LMS</a>, <a href="/guides/compress-pdf-common-app">Common App</a>, <a href="/guides/compress-pdf-ucas">UCAS</a>, <a href="/guides/compress-pdf-for-university-application">University</a></li>
            <li>Immigration: <a href="/guides/compress-pdf-for-visa-application">Visa</a>, <a href="/guides/compress-pdf-schengen-visa">Schengen</a>, <a href="/guides/compress-pdf-ukvi">UKVI</a>, <a href="/guides/compress-pdf-home-affairs-australia">Australia</a>, <a href="/guides/compress-pdf-immigration-canada">Canada</a></li>
            <li>India govt: <a href="/guides/compress-pdf-incometax">Income Tax</a>, <a href="/guides/compress-pdf-gst-portal">GST</a>, <a href="/guides/compress-pdf-digilocker">DigiLocker</a>, <a href="/guides/compress-pdf-irctc">IRCTC</a>, <a href="/guides/compress-pdf-uidai">UIDAI</a></li>
            <li>Industry: <a href="/guides/compress-pdf-lawyers">Lawyers</a>, <a href="/guides/compress-pdf-accountants">Accountants</a>, <a href="/guides/compress-pdf-teachers">Teachers</a>, <a href="/guides/compress-pdf-freelancers">Freelancers</a>, <a href="/guides/compress-pdf-real-estate">Real estate</a></li>
            </ul>
            <h2>Compression decision flowchart (text)</h2>
            <p>Start → size checker → under cap? send → Recommended compress → under cap? send → Extreme once → legible? send → else split → compress each part → send with index email.</p>
            <h2>Training one-pager for IT</h2>
            <p>Allowlist ratpdf.com · block only if DPA forbids browser upload · standardize Less for legal, Recommended for email · log ticket with before/after MB · escalate to split not re-scan when Extreme blurs.</p>
            
            
            <h2>Why RatPDF for browser PDF workflows</h2>
            <p>No install, no IT ticket — upload, process, download. Free tier: three uses per tool per day. Confidential docs: review <a href="/home/privacy">privacy policy</a> and <a href="/home/security">security page</a> before uploading client contracts.</p>
            <h2>Tool chain after this task</h2>
            <p>Most PDF jobs chain tools: OCR → edit → merge → compress → sign. Start here: <a href="/guides/pdf-tools">PDF tools guide</a> · Compare vendors: <a href="/compare">compare tools</a>.</p>
            <h2>Research &amp; data</h2>
            <p><a href="/research/attachment-size-limits">Email attachment limits</a> · <a href="/research/pdf-compression-benchmark">PDF compression benchmark</a> · <a href="/research/pdf-tool-market-comparison">PDF tool market comparison</a>.</p>
            
            <p>Hub: <a href="/compress-pdf">Compress PDF landing</a> · Index of compression guides.</p>
            
            <h2>Corporate rollout checklist</h2>
            <ol><li>IT wiki tool list</li><li>Digital vs scan tree</li><li>Filename versioning</li><li>MB log for tickets</li></ol>
            <h2>Security</h2>
            <p><a href="/guides/secure-pdf-workflow">Secure PDF workflow</a> · <a href="/guides/password-protect-pdf">Password protect</a>.</p>
            
            
            <h2>Cross-wave tool chain</h2>
            <p>Pick tool order by what you need to deliver. Example: photos → images PDF → OCR → edit date → compress → portal upload.</p>
            <h2>Free tier and upgrade</h2>
            <p>Three uses per day per tool on free tier — agency month-end exceeds cap — <a href="/Subscription/Plans">subscription plans</a> — predictable vs per-file credit packs.</p>
            <h2>Internal link discipline</h2>
            <p>Each guide links to related tools and comparisons so your team picks the right workflow.</p>
            <h2>Support triage</h2>
            <p>Wrong tool order causes bad output — OCR before edit on scans — compress after merge not before each file — train your team using the main tool guides.</p>
            
            
            <h2>Failure messages</h2>
            <p><strong>Too large:</strong> compress or split. <strong>Invalid PDF:</strong> re-export source. <strong>Unreadable:</strong> re-scan don't only compress blur.</p>
            <h2>Archive discipline</h2>
            <p>Keep uncompressed master until upload or send succeeds — derivatives are disposable.</p>
            <h2>Compare tools</h2>
            <p><a href="/compare/smallpdf-alternative">Smallpdf</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/adobe-alternative">Adobe</a>.</p>
            
            
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
            
            
            <h2>Post-action checklist</h2>
            <ol><li>Output file opens in viewer</li><li>Text selects if required</li><li>Size under portal/email preset</li><li>Master archived</li><li>Correct tool used for next step (text vs Word vs OCR)</li></ol>
            <p>Bookmark the <a href="/guides/pdf-tools">PDF tools guide</a> and <a href="/compare">compare tools</a> for team onboarding — consistent tool choice reduces wrong-output support tickets.</p>
            <p>Re-run size checker after every derivative step — compress, split, or text export — before deleting the previous version from your working folder.</p>
            
            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Start now</strong> <a href="/pdf/compress" class="alert-link fw-semibold">Compress PDF →</a></div>
            <p class="mt-4"><a href="/pdf/compress" class="btn btn-primary">Compress PDF</a> · <a href="/compare">Compare PDF tools</a></p>
            """;

        private const string MergePdf = """
            <h2>Merge PDF Online — Combine Files Free in Browser (2026)</h2>
            <p>Authoritative guide for <strong>Merge PDF</strong> in your browser — no Adobe install. Updated 2026.</p>
            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> Merge PDF Online — Combine Files Free in Browser (2026)</figcaption></figure>
            
            <h2>Why merge PDF files</h2>
            <p>One attachment beats three confusing emails. RatPDF <a href="/pdf/merge">Merge PDF</a> uses iText smart mode — vectors stay sharp.</p>
            <h2>Step-by-step</h2>
            <ol>
            <li>Unlock encrypted sources.</li>
            <li>Prefix filenames <code>01-</code> <code>02-</code> in order.</li>
            <li>Upload to <a href="/pdf/merge">Merge PDF</a>.</li>
            <li>Verify page count = sum of parts.</li>
            <li><a href="/guides/compress-pdf-guide">Compress</a> if email rejects.</li>
            </ol>
            <h2>Real example: job pack</h2>
            <p>Cover + resume + portfolio → merge → compress → Indeed upload.</p>
            <h2>Real example: court exhibits</h2>
            <p><a href="/guides/merge-pdf-court-filing">Court filing merge</a> in index order — OCR scans before merge if search required.</p>
            <h2>Merge vs ZIP</h2>
            <p>One scrollable doc → merge. Separate files → ZIP. Multi-slot portal → usually do not merge.</p>
            <h2>Spokes</h2>
            <ul>
            <li><a href="/guides/merge-pdf-visa-application">Visa</a> · <a href="/guides/merge-pdf-without-quality-loss">Quality</a></li>
            <li><a href="/guides/merge-password-protected-pdf">Password-protected</a> · <a href="/guides/organize-pdf-pages">Organize pages</a></li>
            <li><a href="/guides/combine-then-compress-pdf">Merge then compress</a></li>
            </ul>
            <h2>FAQ — merge PDF</h2>
            <p><strong>Bookmarks?</strong> Often preserved. <strong>Corrupt file?</strong> Fails whole job — fix source.</p>
            
            <div class="rp-mid-cta alert alert-primary my-4"><strong>Open Merge PDF tool</strong> <a href="/pdf/merge" class="alert-link fw-semibold">Merge PDF →</a></div>
            
            <h2>Industry workflows that depend on merge order</h2>
            <h3>Accounting &amp; audit</h3>
            <p>Combine signed engagement letter, management representation, and trial balance export. Auditors reject ZIPs of random filenames — numeric prefixes survive email forwarding.</p>
            <h3>Insurance claims</h3>
            <p>Photos, repair estimates, and policy PDF — merge chronologically with date-stamped filenames. Compress before portal upload — <a href="/guides/compress-pdf-insurance-claims">insurance compress guide</a>.</p>
            <h3>Real estate closings</h3>
            <p>Disclosure → inspection → title → closing statement. Title companies often specify order — ask before merge.</p>

            <h2>Technical limits worth knowing</h2>
            <p>PDF version mismatches rarely block merge — iText normalizes on output. Corrupt source PDF fails entire job — repair source or re-export from origin app.</p>

            <h2>Merge vs zip archive</h2>
            <p>Recipients need one scrollable document → merge. Recipients need separate files → ZIP, not merge. Visa portals specifying single PDF → merge; university portals with ten upload fields → do not merge.</p>

            <h2>Accessibility after merge</h2>
            <p>Tagged PDF structure may not survive merge — screen reader order can jump. For accessible deliverables, remediate after merge or keep tagged master separate.</p>

            <h2>HowTo summary</h2>
            <ol>
            <li>Gather source PDFs — unlock encrypted files first</li>
            <li>Rename with numeric prefixes matching checklist</li>
            <li>Upload to <a href="/pdf/merge">Merge PDF</a> in order</li>
            <li>Download — verify page count and search</li>
            <li>Compress if size rejected — <a href="/pdf/compress">Compress PDF</a></li>
            <li>Email or upload to portal</li>
            </ol>

            <h2>Beginner hub</h2>
            <p>New to PDF tools? <a href="/guides/how-to-merge-pdf-files">How to merge PDF files</a> · <a href="/guides/merge-vs-compress">merge vs compress</a>.</p>

            <h2>Troubleshooting failed merges</h2>
            <p><strong>Upload stalls:</strong> compress large scans first or use Wi-Fi. <strong>Missing pages:</strong> corrupt source — re-export from Word/Excel. <strong>Wrong rotation:</strong> fix in Preview before merge, not after. <strong>Password error:</strong> unlock each file — see password-protected merge guide.</p>

            <h2>Corporate IT policies</h2>
            <p>Some enterprises block browser uploads — request IT allowlist for ratpdf.com merge path or use approved VM. Do not merge export-controlled PDFs on personal devices.</p>
            
            <h2>Enterprise merge governance</h2>
            <p>Legal ops teams document who may merge customer contracts — version control source PDFs before merge. Filename convention <code>CLIENT-MERGE-2026-04-01-v1.pdf</code> prevents accidental overwrite of executed copies.</p>

            <h2>Print shop handoff</h2>
            <p>Merged packs for bindery — embed fonts where possible; merge digital exports not "Print to PDF" chains that rasterize.</p>

            <h2>Upgrade prompt</h2>
            <p>Agencies merging daily: Pro tier raises limits — <a href="/Subscription/Plans">compare plans</a>.</p>
            
            <h2>Merge then compress decision tree</h2>
            <p><strong>One email attachment?</strong> Merge first, compress once — <a href="/guides/compress-before-merge-pdf">decision guide</a>. <strong>Per-slot portal uploads?</strong> Compress individuals before merge when each slot has its own cap.</p>

            <h2>Bookmarks and navigation</h2>
            <p>RatPDF outputs linear PDF without bookmarks. For 100+ page packs, add bookmarks in desktop editor if recipients navigate often — or split into volume parts with <a href="/guides/split-pdf">split PDF</a>.</p>

            <h2>Alternatives comparison</h2>
            <p>Compare: <a href="/compare/smallpdf-alternative">Smallpdf alternative</a> · <a href="/compare/adobe-alternative">Adobe alternative</a> · Research: <a href="/research/pdf-compression-benchmark">PDF compression benchmark</a>.</p>

            <h2>Extended FAQ</h2>
            <p><strong>Does merge change page size?</strong> Each source keeps its media box — mixed A4/Letter merges show size jumps; normalize in source apps if print shop requires.</p>
            <p><strong>Can I merge JPG as PDF?</strong> Convert images to PDF first or use image tools — Merge PDF expects PDF inputs.</p>
            <p><strong>Free tier?</strong> Three uses per tool per day — <a href="/Subscription/Plans">upgrade</a> for volume.</p>

            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Combine your files now</strong> <a href="/pdf/merge" class="alert-link fw-semibold">Merge PDF →</a></div>
            
            <h2>Related guides &amp; cluster links</h2>
            <ul>
            <li><a href="/guides/merge-pdf">Merge PDF guide</a></li>
            <li><a href="/guides/merge-pdf-without-quality-loss">Merge without quality loss</a></li>
            <li><a href="/guides/merge-pdf-custom-order">Merge in custom order</a></li>
            <li><a href="/guides/merge-scanned-digital-pdf">Merge scanned and digital PDFs</a></li>
            </ul>
            <p>Research: <a href="/research/pdf-compression-benchmark">PDF compression benchmark</a> · Compare: <a href="/compare/smallpdf-alternative">Smallpdf alternative</a></p>
            
            <h2>Stakeholder communication</h2>
            <p>When sending merged packs to clients, email body should list contents: "Attached single PDF: cover (pp. 1–2), contract (pp. 3–18), exhibits (pp. 19–40)." Reduces "missing attachment" confusion when they search for a separate file.</p>

            <h2>Long-term archival</h2>
            <p>Store merged PDF plus manifest CSV listing source filenames and SHA-256 hashes — auditors reconstruct order years later. Cloud backup: <a href="/guides/compress-pdf-cloud-storage">compress for cloud storage</a> before sync.</p>

            <h2>FAQ inline</h2>
            <p><strong>Can I merge Word files?</strong> Export DOCX to PDF first via <a href="/pdf/doctopdf">Word to PDF</a>. <strong>Does merge reduce page count?</strong> No — total pages sum unless you deduplicate sources. <strong>Merge on phone?</strong> Yes in mobile browser — same tool URL.</p>

            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Ready to merge?</strong> <a href="/pdf/merge" class="alert-link fw-semibold">Merge PDF →</a> · <a href="/Subscription/Plans">Upgrade for volume</a></div>

            <h2>Closing summary</h2>
            <p>Merge is irreversible ordering — prefix files, verify page count, compress once if needed, then deliver. RatPDF smart merge keeps digital text sharp; scans stay images until you OCR the merged pack separately.</p>
            
            <h2>Print and bindery handoff</h2>
            <p>Print shops ask for single PDF with bleed marks removed — merge first, then preflight in Acrobat alternative if colours shift. Staple-bound packets need consistent page size — resize sources before merge when binder specifies.</p>

            <h2>Litigation hold merges</h2>
            <p>When legal hold applies, merged output is discoverable — log who merged, when, and from which sources. Do not merge privileged docs with non-privileged without counsel review.</p>

            <h2>API and automation boundary</h2>
            <p>RatPDF merge is browser UI — no public merge API on free tier. Repeatable human merge with prefixed folders scales to hundreds of files per month for paralegals.</p>

            <h2>Email vs portal delivery</h2>
            <p>Law firms email merged exhibits under 20 MB; immigration portals often cap 5 MB — compress after merge QA. Subject line: "Merged exhibit bundle — 47 pages — INV-2026-041".</p>

            <h2>Checksum verification</h2>
            <p>Hash merged PDF before email — recipient confirms SHA match out-of-band for high-stakes filings. Prevents wrong-version disputes in M&amp;A data rooms.</p>

            <h2>Tool CTA reminder</h2>
            <p>Primary action: <a href="/pdf/merge">Merge PDF</a> — compress at <a href="/pdf/compress">Compress PDF</a> only if portal or email rejects size.</p>
            
            
            <h2>Bookmark and navigation after merge</h2>
            <p>Long merged packs benefit from bookmarks — RatPDF outputs linear PDF; add bookmarks in desktop editor if counsel requires. For board packs, cover page PDF with hyperlinked agenda still helps recipients.</p>
            <h2>File size planning</h2>
            <p>Sum source MB before merge — if over email cap, plan one compress pass after merge not per-file Extreme passes. <a href="/guides/merge-vs-compress">Merge vs compress</a>.</p>
            <h2>Accessibility after merge</h2>
            <p>Tagged structure may not survive — screen reader order can jump at file boundaries. For accessible deliverables, remediate after merge or deliver tagged master separately.</p>
            <h2>Industry merge playbooks</h2>
            <p>Insurance claims chronological photos — real estate disclosure order — student weekly readings numeric prefix — accountant board pack index matching filenames.</p>
            <h2>Compare merge tools</h2>
            <p><a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/smallpdf-alternative">Smallpdf</a> · <a href="/compare/adobe-acrobat-alternative">Adobe</a>.</p>
            
            
            <h2>Month-end board pack SOP</h2>
            <p>Merge CFO memo, P&amp;L, auditor letter with 01-03 prefix — compress once — upload to board portal.</p>
            <h2>Technical QA matrix</h2>
            <p>Page count = sum of sources · Ctrl+F works on digital pages · no sideways thumbnails · under size cap.</p>
            
            
            <h2>Merge guides</h2>
            <ul>
            <li><a href="/guides/merge-pdf-online">Merge PDF online</a> · <a href="/guides/how-to-merge-pdf-files">How to merge PDF files</a></li>
            <li><a href="/guides/merge-pdf-custom-order">Custom order</a> · <a href="/guides/organize-pdf-pages">Organize pages</a></li>
            <li><a href="/guides/merge-pdf-visa-application">Visa application</a> · <a href="/guides/merge-pdf-court-filing">Court filing</a></li>
            <li><a href="/guides/merge-password-protected-pdf">Password-protected</a> · <a href="/guides/merge-scanned-digital-pdf">Scanned + digital</a></li>
            <li><a href="/guides/merge-pdf-without-quality-loss">Without quality loss</a> · <a href="/guides/merge-pdf-accountants">Accountants</a> · <a href="/guides/merge-pdf-students">Students</a></li>
            <li><a href="/guides/combine-then-compress-pdf">Combine then compress</a> · <a href="/guides/merge-vs-compress">Merge vs compress</a></li>
            </ul>
            <h2>When merge fails — diagnostic table</h2>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>Symptom</th><th>Fix</th></tr></thead>
            <tbody>
            <tr><td>Password prompt</td><td><a href="/guides/unlock-pdf">Unlock PDF</a></td></tr>
            <tr><td>Missing pages</td><td>Corrupt source — re-export</td></tr>
            <tr><td>Huge output MB</td><td>Compress after merge</td></tr>
            <tr><td>Blurry logos</td><td>Avoid rasterizing merge tools — use RatPDF</td></tr>
            </tbody>
            </table></div>
            <h2>Enterprise filename standard</h2>
            <p><code>CLIENT-MATTER-MERGE-YYYYMMDD-v1.pdf</code> — litigation hold stores v1 immutable; v2 after supplemental exhibits appended via re-merge.</p>
            
            
            <h2>Why RatPDF for browser PDF workflows</h2>
            <p>No install, no IT ticket — upload, process, download. Free tier: three uses per tool per day. Confidential docs: review <a href="/home/privacy">privacy policy</a> and <a href="/home/security">security page</a> before uploading client contracts.</p>
            <h2>Tool chain after this task</h2>
            <p>Most PDF jobs chain tools: OCR → edit → merge → compress → sign. Start here: <a href="/guides/pdf-tools">PDF tools guide</a> · Compare vendors: <a href="/compare">compare tools</a>.</p>
            <h2>Research &amp; data</h2>
            <p><a href="/research/attachment-size-limits">Email attachment limits</a> · <a href="/research/pdf-compression-benchmark">PDF compression benchmark</a> · <a href="/research/pdf-tool-market-comparison">PDF tool market comparison</a>.</p>
            
            <p>After merge: <a href="/guides/compress-pdf-guide">compress guide</a> · <a href="/guides/split-pdf">split guide</a>.</p>
            
            <h2>Corporate rollout checklist</h2>
            <ol><li>IT wiki tool list</li><li>Digital vs scan tree</li><li>Filename versioning</li><li>MB log for tickets</li></ol>
            <h2>Security</h2>
            <p><a href="/guides/secure-pdf-workflow">Secure PDF workflow</a> · <a href="/guides/password-protect-pdf">Password protect</a>.</p>
            
            
            <h2>Cross-wave tool chain</h2>
            <p>Pick tool order by what you need to deliver. Example: photos → images PDF → OCR → edit date → compress → portal upload.</p>
            <h2>Free tier and upgrade</h2>
            <p>Three uses per day per tool on free tier — agency month-end exceeds cap — <a href="/Subscription/Plans">subscription plans</a> — predictable vs per-file credit packs.</p>
            <h2>Internal link discipline</h2>
            <p>Each guide links to related tools and comparisons so your team picks the right workflow.</p>
            <h2>Support triage</h2>
            <p>Wrong tool order causes bad output — OCR before edit on scans — compress after merge not before each file — train your team using the main tool guides.</p>
            
            
            <h2>Failure messages</h2>
            <p><strong>Too large:</strong> compress or split. <strong>Invalid PDF:</strong> re-export source. <strong>Unreadable:</strong> re-scan don't only compress blur.</p>
            <h2>Archive discipline</h2>
            <p>Keep uncompressed master until upload or send succeeds — derivatives are disposable.</p>
            <h2>Compare tools</h2>
            <p><a href="/compare/smallpdf-alternative">Smallpdf</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/adobe-alternative">Adobe</a>.</p>
            
            
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
            
            
            <h2>Post-action checklist</h2>
            <ol><li>Output file opens in viewer</li><li>Text selects if required</li><li>Size under portal/email preset</li><li>Master archived</li><li>Correct tool used for next step (text vs Word vs OCR)</li></ol>
            <p>Bookmark the <a href="/guides/pdf-tools">PDF tools guide</a> and <a href="/compare">compare tools</a> for team onboarding — consistent tool choice reduces wrong-output support tickets.</p>
            <p>Re-run size checker after every derivative step — compress, split, or text export — before deleting the previous version from your working folder.</p>
            
            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Start now</strong> <a href="/pdf/merge" class="alert-link fw-semibold">Merge PDF →</a></div>
            <p class="mt-4"><a href="/pdf/merge" class="btn btn-primary">Merge PDF</a> · <a href="/compare">Compare PDF tools</a></p>
            """;

        private const string SplitPdf = """
            <h2>Split PDF Online — Extract Pages &amp; Ranges (2026)</h2>
            <p>Authoritative guide for <strong>Split PDF</strong> in your browser — no Adobe install. Updated 2026.</p>
            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> Split PDF Online — Extract Pages &amp; Ranges (2026)</figcaption></figure>
            
            <h2>Why split PDF</h2>
            <p>Email caps, exhibit extracts, chapter handouts. <a href="/pdf/split">Split PDF</a> copies pages without re-scan.</p>
            <h2>Range syntax</h2>
            <p><code>7</code>, <code>1-30</code>, <code>1-2, 7, 10-12</code> — no overlapping ranges.</p>
            <h2>Step-by-step</h2>
            <ol>
            <li>Try <a href="/guides/compress-pdf-guide">compress</a> first if one attachment needed.</li>
            <li>Pick logical breaks (chapters, exhibits).</li>
            <li>Split — name <code>Part1-of-3</code> files.</li>
            <li>Index ranges in email body.</li>
            </ol>
            <h2>Real example: 120-page discovery</h2>
            <p>Three parts under 20 MB each for Gmail — Bates index in cover email.</p>
            <h2>Spokes</h2>
            <ul>
            <li><a href="/guides/split-pdf-for-email">Split for email</a> · <a href="/guides/split-pdf-by-size">By size</a></li>
            <li><a href="/guides/split-pdf-page-range">Page range</a> · <a href="/guides/extract-single-page-pdf">Single page</a></li>
            <li><a href="/guides/compress-vs-split">Compress vs split</a></li>
            </ul>
            <h2>FAQ — split PDF</h2>
            <p><strong>Quality loss?</strong> No — inherits source DPI.</p>
            
            <div class="rp-mid-cta alert alert-primary my-4"><strong>Open Split PDF tool</strong> <a href="/pdf/split" class="alert-link fw-semibold">Split PDF →</a></div>
            
            <h2>Email provider limits reference</h2>
            <p>Gmail ~25 MB message, Outlook similar, corporate gateways often 10–20 MB — Base64 adds ~33% — 18 MB PDF may bounce. Split when <a href="/guides/compress-pdf-for-email">compress</a> harms legibility.</p>

            <h2>Split planning worksheet</h2>
            <ol>
            <li>Total pages and file size</li>
            <li>Target MB per part from <a href="/pdf-size-checker">size checker</a></li>
            <li>Logical break points (chapters, exhibits)</li>
            <li>Name parts consistently</li>
            <li>Index in email body</li>
            </ol>

            <h2>Recipient experience</h2>
            <p>Part 1 of 3 without index frustrates — email table: Part A pages 1–40 financials, Part B 41–80 contracts.</p>

            <h2>Re-merge locally</h2>
            <p>Recipient uses <a href="/guides/merge-pdf-online">merge PDF</a> after download all parts — include merge hint in cover email.</p>

            <h2>Court and e-filing</h2>
            <p>Some courts reject split — compress or seek exemption motion — check local rules before splitting sealed filing.</p>
            
            <h2>Page range syntax discipline</h2>
            <p>1-40, 41-80 not off-by-one overlaps — duplicate pages confuse Bates numbering — double-check range before submit.</p>
            <h2>Blank pages</h2>
            <p>Remove intentional blank pages from source before split — orphan blank wastes portal slot.</p>
            <h2>Scan vs digital mix</h2>
            <p>Split does not change DPI — each part inherits source quality — compress part individually if one section photo-heavy.</p>
            <h2>Cloud storage upload</h2>
            <p>Upload parts to Drive folder — share one link with index doc — better than three separate email bounces.</p>
            <h2>Mobile split limits</h2>
            <p>Large split on phone may timeout — desktop Wi-Fi for 200+ page sources.</p>
            <h2>Metadata carry-over</h2>
            <p>Document title property may still say full doc name — edit PDF properties per part for professional delivery.</p>
            
            <h2>Split vs compress vs merge decision</h2>
            <p>One attachment needed → try compress. Multiple slots allowed → split. Many files one slot → merge then compress per <a href="/guides/combine-then-compress-pdf">combine then compress</a>.</p>
            <h2>Email template</h2>
            <pre class="bg-light p-3 small"><code>Subject: Quarterly report — Part 2 of 3 (pages 41–80)
            Body: Part 1 sent earlier; Part 3 follows. Total 120 pages across three files.</code></pre>
            <h2>Integrity check</h2>
            <p>After recipient merges parts — page count must equal source — spot-check first and last page of each part before sending.</p>
            <h2>Pillar and Wave links</h2>
            <p><a href="/guides/split-pdf">Split PDF hub</a> · <a href="/guides/split-pdf-page-range">page range</a> · <a href="/guides/compress-pdf-for-email">compress for email</a>.</p>
            <h2>Long-term archive</h2>
            <p>After successful delivery, store parts + index email in matter folder — recipient may request Part 2 resend months later.</p>
            <h2>Checksum optional</h2>
            <p>SHA256 each part for high-stakes filings — recipient verifies download integrity before court upload.</p>
            
            <h2>Second example: textbook PDF</h2>
            <p>400 MB digital textbook — portal max 50 MB — split by chapter PDFs — students download assigned chapter only.</p>
            <h2>Third example: medical records</h2>
            <p>HIPAA email cap — split chart by year — compress each year if still over — index lists date ranges per part.</p>
            <h2>Litigation load file</h2>
            <p>Split may break load file paths — e-discovery vendor prefers single compressed or native split with agreed numbering.</p>
            <h2>After split compress chain</h2>
            <p>Each part still over cap — <a href="/guides/batch-compress-pdf">batch compress</a> parts — last resort second split pass.</p>
            <h2>University submission</h2>
            <p>Thesis portal 50 MB — split appendices A–F separately — index lists appendix letter per file.</p>
            <h2>Print shop handoff</h2>
            <p>Print shop accepts USB — split only for email — courier uncompressed USB for plate printing.</p>
            
            <h2>Accounting month-end</h2>
            <p>Audit firm emails 80 MB workpaper PDF — split Parts 1–4 — client AP forwards to reviewers without shared drive access.</p>
            <h2>Real estate disclosure</h2>
            <p>Disclosure pack over email cap — split by property section — compress each part if still borderline — index in cover email.</p>
            <h2>Student submissions</h2>
            <p>Professor email rejects thesis — split appendices — keep main body single file under cap — label Appendix B Part 1 clearly.</p>
            <h2>Insurance claims bundles</h2>
            <p>Adjuster email rejects 45 MB photo PDF — split by damage area — Part 1 roof Part 2 interior — same claim number in each filename.</p>
            <h2>Government portal multi-upload</h2>
            <p>Five slots 5 MB each — split exhibit list evenly — do not compress if stamp legibility already marginal.</p>
            <h2>Video tutorial handoff</h2>
            <p>Train new paralegal: compress first, split second, merge third — write SOP with screenshots from this guide's workflow order.</p>
            <h2>Discovery production format</h2>
            <p>Agree with opposing counsel whether split parts need sequential Bates before production — split after numbering if required — not before.</p>
            <h2>Upgrade and compare</h2>
            <p>High-volume litigation splits — <a href="/Subscription/Plans">plans</a> · <a href="/compare/smallpdf-alternative">Smallpdf alternative</a>.</p>
            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Split your PDF</strong> <a href="/pdf/split" class="alert-link fw-semibold">Split PDF →</a></div>
            
            <h2>Related split guides</h2>
            <ul>
            <li><a href="/guides/split-pdf">Split PDF guide</a></li>
            <li><a href="/guides/split-pdf-for-email">Split for email</a></li>
            <li><a href="/guides/split-pdf-by-size">Split by size</a></li>
            <li><a href="/guides/compress-pdf-for-email">Compress for email</a></li>
            </ul>
            <p>Research: <a href="/research/attachment-size-limits">Attachment size limits</a></p>
            
            
            <h2>Bates numbering and split</h2>
            <p>Apply Bates before split if production requires sequential numbers across parts — splitting after numbering avoids duplicate ranges. Coordinate with opposing counsel on multi-part production format.</p>
            <h2>Insurance and claims splits</h2>
            <p>Adjuster rejects 45 MB photo PDF — split by damage area — Part 1 roof, Part 2 interior — same claim number in each filename.</p>
            <h2>University thesis appendices</h2>
            <p>Portal 50 MB — main body one file — appendices A–F separate uploads — index lists appendix letter per file.</p>
            <h2>Recipient merge hint</h2>
            <p>Include in email: "Merge parts with Merge PDF tool in checklist order" — reduces support calls from non-technical recipients.</p>
            <h2>Compare split tools</h2>
            <p><a href="/compare/sejda-alternative">Sejda</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/smallpdf-alternative">Smallpdf</a>.</p>
            
            
            <h2>Accounting workpaper split</h2>
            <p>80 MB audit file → Parts 1–4 under 20 MB — index email lists section titles per part.</p>
            <h2>Binary search size split</h2>
            <p>Halve page ranges until each part passes <a href="/pdf-size-checker">size checker</a> — log ranges in manifest spreadsheet.</p>
            <h2>Related split guides</h2>
            <p><a href="/guides/split-pdf-for-email">Email</a> · <a href="/guides/split-pdf-by-size">By size</a> · <a href="/guides/split-pdf-page-range">Range</a> · <a href="/guides/extract-single-page-pdf">Single page</a>.</p>
            
            
            <h2>Split guides</h2>
            <ul>
            <li><a href="/guides/split-pdf-for-email">Split for email</a> · <a href="/guides/split-pdf-by-size">Split by size</a></li>
            <li><a href="/guides/split-pdf-page-range">Page range</a> · <a href="/guides/extract-single-page-pdf">Extract single page</a></li>
            <li><a href="/guides/compress-vs-split">Compress vs split</a> · <a href="/guides/organize-pdf-pages">Organize after split</a></li>
            </ul>
            <h2>Multi-part email standard</h2>
            <p>Subject must include part number and page range. Body must index all parts. Never send Part 3 before Part 1 without explanation.</p>
            <h2>Discovery production note</h2>
            <p>Split may break load file paths — agree format with e-discovery vendor before splitting numbered production sets.</p>
            <h2>Student / faculty tip</h2>
            <p>Split weekly readings — smaller files load faster on campus Wi-Fi — combine with <a href="/guides/merge-pdf-students">merge guide</a> when syllabus requires one pack.</p>
            
            
            <h2>Why RatPDF for browser PDF workflows</h2>
            <p>No install, no IT ticket — upload, process, download. Free tier: three uses per tool per day. Confidential docs: review <a href="/home/privacy">privacy policy</a> and <a href="/home/security">security page</a> before uploading client contracts.</p>
            <h2>Tool chain after this task</h2>
            <p>Most PDF jobs chain tools: OCR → edit → merge → compress → sign. Start here: <a href="/guides/pdf-tools">PDF tools guide</a> · Compare vendors: <a href="/compare">compare tools</a>.</p>
            <h2>Research &amp; data</h2>
            <p><a href="/research/attachment-size-limits">Email attachment limits</a> · <a href="/research/pdf-compression-benchmark">PDF compression benchmark</a> · <a href="/research/pdf-tool-market-comparison">PDF tool market comparison</a>.</p>
            
            <p>Before split: <a href="/guides/compress-pdf-guide">try compress</a> · After: <a href="/guides/merge-pdf">merge guide</a>.</p>
            
            <h2>Corporate rollout checklist</h2>
            <ol><li>IT wiki tool list</li><li>Digital vs scan tree</li><li>Filename versioning</li><li>MB log for tickets</li></ol>
            <h2>Security</h2>
            <p><a href="/guides/secure-pdf-workflow">Secure PDF workflow</a> · <a href="/guides/password-protect-pdf">Password protect</a>.</p>
            
            
            <h2>Cross-wave tool chain</h2>
            <p>Pick tool order by what you need to deliver. Example: photos → images PDF → OCR → edit date → compress → portal upload.</p>
            <h2>Free tier and upgrade</h2>
            <p>Three uses per day per tool on free tier — agency month-end exceeds cap — <a href="/Subscription/Plans">subscription plans</a> — predictable vs per-file credit packs.</p>
            <h2>Internal link discipline</h2>
            <p>Each guide links to related tools and comparisons so your team picks the right workflow.</p>
            <h2>Support triage</h2>
            <p>Wrong tool order causes bad output — OCR before edit on scans — compress after merge not before each file — train your team using the main tool guides.</p>
            
            
            <h2>Failure messages</h2>
            <p><strong>Too large:</strong> compress or split. <strong>Invalid PDF:</strong> re-export source. <strong>Unreadable:</strong> re-scan don't only compress blur.</p>
            <h2>Archive discipline</h2>
            <p>Keep uncompressed master until upload or send succeeds — derivatives are disposable.</p>
            <h2>Compare tools</h2>
            <p><a href="/compare/smallpdf-alternative">Smallpdf</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/adobe-alternative">Adobe</a>.</p>
            
            
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
            
            
            <h2>Post-action checklist</h2>
            <ol><li>Output file opens in viewer</li><li>Text selects if required</li><li>Size under portal/email preset</li><li>Master archived</li><li>Correct tool used for next step (text vs Word vs OCR)</li></ol>
            <p>Bookmark the <a href="/guides/pdf-tools">PDF tools guide</a> and <a href="/compare">compare tools</a> for team onboarding — consistent tool choice reduces wrong-output support tickets.</p>
            <p>Re-run size checker after every derivative step — compress, split, or text export — before deleting the previous version from your working folder.</p>
            
            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Start now</strong> <a href="/pdf/split" class="alert-link fw-semibold">Split PDF →</a></div>
            <p class="mt-4"><a href="/pdf/split" class="btn btn-primary">Split PDF</a> · <a href="/compare">Compare PDF tools</a></p>
            """;

        private const string PdfToWord = """
            <h2>PDF to Word Converter — Edit PDFs in DOCX Online (2026)</h2>
            <p>Authoritative guide for <strong>PDF to Word</strong> in your browser — no Adobe install. Updated 2026.</p>
            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> PDF to Word Converter — Edit PDFs in DOCX Online (2026)</figcaption></figure>
            
            <h2>Why PDF to Word</h2>
            <p>Redlines, resume edits, proposal updates. <a href="/pdf/pdftodoc">PDF to Word</a> uses pdf2docx + fallbacks.</p>
            <h2>10-second test</h2>
            <p>Text selects → convert. No selection → <a href="/pdf/ocrpdf">OCR</a> first.</p>
            <h2>Step-by-step</h2>
            <ol>
            <li>Upload to <a href="/pdf/pdftodoc">PDF to Word</a>.</li>
            <li>Open DOCX — verify tables page 1.</li>
            <li>Track changes for legal edits.</li>
            <li>Re-export <a href="/pdf/doctopdf">Word to PDF</a> for delivery.</li>
            </ol>
            <h2>Real examples</h2>
            <p>Contract redline: <a href="/guides/convert-contract-pdf-to-word">contract guide</a>. Resume: <a href="/guides/pdf-to-word-resume">resume guide</a>.</p>
            <h2>Spokes</h2>
            <ul>
            <li><a href="/guides/pdf-to-word-keep-formatting">Keep formatting</a> · <a href="/guides/scanned-pdf-to-word">Scanned workflow</a></li>
            <li><a href="/guides/pdf-to-word-mac">Mac</a> · <a href="/guides/pdf-to-word-without-word">Without Word</a></li>
            <li><a href="/guides/pdf-to-word-vs-pdf-to-text">vs PDF to Text</a></li>
            </ul>
            <h2>FAQ — PDF to Word</h2>
            <p><strong>Tables?</strong> Usually on digital PDFs. <strong>Signed executed PDF?</strong> Do not convert — archive as-is.</p>
            
            <div class="rp-mid-cta alert alert-primary my-4"><strong>Open PDF to Word tool</strong> <a href="/pdf/pdftodoc" class="alert-link fw-semibold">PDF to Word →</a></div>
            
            <h2>When NOT to convert PDF to Word</h2>
            <p>Signed executed contracts, filed tax acknowledgements, and official sealed transcripts — archive PDF as-is; convert only working drafts with authority to edit. Regenerate invoices from <a href="/invoice/create">Create Invoice</a> when you issued the PDF originally.</p>

            <h2>Track changes discipline</h2>
            <p>Legal and procurement reviews need Word track changes — convert digital PDF, edit in Word, return DOCX or export PDF after accept. Never edit PDF in Photoshop pretending it is redline.</p>

            <h2>ATS and recruiting</h2>
            <p>Recruiters parsing DOCX — <a href="/guides/pdf-to-word-resume">resume PDF to Word</a> keeps headings if digital; scanned CV needs OCR. Avoid text boxes that break ATS parsers.</p>

            <h2>Finance document chain</h2>
            <p>PO → receipt → invoice three-way match — editing PO PDF in Word without ERP audit trail risks payment errors. Prefer system reissue when buyer has ERP access; Word path for one-off SMB paper workflows.</p>

            <h2>Education and credentials</h2>
            <p>Transcript and diploma PDFs — add cover pages only; never alter grades. University employers may require registrar verification regardless of Word wrapper.</p>

            <h2>Compare vendors</h2>
            <p><a href="/compare/adobe-alternative">Adobe</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/smallpdf-alternative">Smallpdf</a> — evaluate table fidelity on a sample page before batch migration.</p>
            
            <h2>Digital vs scanned — 10-second test</h2>
            <p>Try selecting text in your PDF viewer. Highlight works → <a href="/pdf/pdftodoc">PDF to Word</a> directly. No selection → <a href="/pdf/ocrpdf">OCR PDF</a> first per <a href="/guides/scanned-pdf-to-word">scanned workflow</a>.</p>

            <h2>pdf2docx vs page-render fallback</h2>
            <p>RatPDF analyses structure on digital PDFs — tables and paragraphs become editable objects. When structure is missing, pages may embed as images inside DOCX — still better than retyping from scratch.</p>

            <h2>Re-export after edits</h2>
            <p>Deliverable still PDF? Use Word <em>Save as PDF</em> or <a href="/pdf/doctopdf">Word to PDF</a>. Email too large? <a href="/guides/compress-pdf-for-email">compress PDF</a>.</p>

            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Convert now</strong> <a href="/pdf/pdftodoc" class="alert-link fw-semibold">PDF to Word →</a></div>
            
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
            
            <h2>Related PDF to Word guides</h2>
            <ul>
            <li><a href="/guides/pdf-to-word">PDF to Word guide</a></li>
            <li><a href="/guides/pdf-to-word-keep-formatting">Keep formatting</a></li>
            <li><a href="/guides/scanned-pdf-to-word">Scanned PDF to Word</a></li>
            <li><a href="/guides/pdf-to-word-mac">PDF to Word on Mac</a></li>
            </ul>
            <p>Research: <a href="/research/pdf-compression-benchmark">PDF compression benchmark</a> · Compare: <a href="/compare/smallpdf-alternative">Smallpdf alternative</a></p>
            
            
            <h2>Table and logo QA checklist</h2>
            <ol>
            <li>Row counts match source PDF</li>
            <li>Currency symbols correct encoding</li>
            <li>Logo not replaced with grey box</li>
            <li>Numbered lists 1.1, 1.2 intact</li>
            <li>Footnotes and hyperlinks tested</li>
            </ol>
            <h2>Editor paths without Office</h2>
            <p>Google Docs upload DOCX — LibreOffice Writer — Word Online free tier. <a href="/guides/pdf-to-word-without-word">Without Word guide</a>.</p>
            <h2>Batch conversion discipline</h2>
            <p>One file per session on free tier — queue overnight — OCR scans first — name outputs <code>Client-doc-v2.docx</code> immediately.</p>
            <h2>Compare conversion tools</h2>
            <p><a href="/compare/adobe-acrobat-alternative">Adobe</a> · <a href="/compare/smallpdf-alternative">Smallpdf</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a>.</p>
            
            
            <h2>Procurement quote redline</h2>
            <p>CRM quote PDF → Word → discount line track changes → export PDF for client.</p>
            <h2>Failure recovery</h2>
            <p>Garbled output — OCR first — <a href="/guides/pdf-to-word-garbled-text">garbled text fixes</a> — request native DOCX from sender.</p>
            <h2>Related conversion guides</h2>
            <p><a href="/guides/convert-nda-pdf-to-word">NDA</a> · <a href="/guides/convert-purchase-order-pdf-to-word">PO</a> · <a href="/guides/convert-bank-statement-pdf-to-word">Bank</a> · <a href="/guides/convert-transcript-pdf-to-word">Transcript</a>.</p>
            
            
            <h2>PDF to Word guides</h2>
            <ul>
            <li>Quality: <a href="/guides/pdf-to-word-keep-formatting">Keep formatting</a> · <a href="/guides/scanned-pdf-to-word">Scanned workflow</a> · <a href="/guides/pdf-to-word-garbled-text">Garbled text</a></li>
            <li>Device: <a href="/guides/pdf-to-word-mac">Mac</a> · <a href="/guides/pdf-to-word-without-word">Without Word</a> · <a href="/guides/pdf-to-word-vs-google-docs">vs Google Docs</a></li>
            <li>Compare: <a href="/guides/pdf-to-word-vs-pdf-to-text">vs PDF to Text</a> · <a href="/guides/batch-pdf-to-word">Batch workflow</a></li>
            <li>Documents: <a href="/guides/convert-contract-pdf-to-word">Contract</a> · <a href="/guides/convert-nda-pdf-to-word">NDA</a> · <a href="/guides/convert-lease-agreement-pdf-to-word">Lease</a> · <a href="/guides/convert-bank-statement-pdf-to-word">Bank</a> · <a href="/guides/convert-sow-pdf-to-word">SOW</a></li>
            <li>Career: <a href="/guides/pdf-to-word-resume">Resume</a> · <a href="/guides/convert-transcript-pdf-to-word">Transcript</a></li>
            </ul>
            <h2>Conversion pipeline diagram (text)</h2>
            <p>PDF → test select → digital? pdftodoc : OCR → pdftodoc → edit DOCX → doctopdf → compress if email rejects.</p>
            <h2>Legal redline discipline</h2>
            <p>Track changes on — never silent PDF photoshop redline — return DOCX or PDF export after accept — executed scan stays archive.</p>
            
            
            <h2>Why RatPDF for browser PDF workflows</h2>
            <p>No install, no IT ticket — upload, process, download. Free tier: three uses per tool per day. Confidential docs: review <a href="/home/privacy">privacy policy</a> and <a href="/home/security">security page</a> before uploading client contracts.</p>
            <h2>Tool chain after this task</h2>
            <p>Most PDF jobs chain tools: OCR → edit → merge → compress → sign. Start here: <a href="/guides/pdf-tools">PDF tools guide</a> · Compare vendors: <a href="/compare">compare tools</a>.</p>
            <h2>Research &amp; data</h2>
            <p><a href="/research/attachment-size-limits">Email attachment limits</a> · <a href="/research/pdf-compression-benchmark">PDF compression benchmark</a> · <a href="/research/pdf-tool-market-comparison">PDF tool market comparison</a>.</p>
            
            <p>OCR path: <a href="/guides/ocr-pdf">OCR guide</a> · Export back: <a href="/guides/word-to-pdf">Word to PDF</a>.</p>
            
            <h2>Corporate rollout checklist</h2>
            <ol><li>IT wiki tool list</li><li>Digital vs scan tree</li><li>Filename versioning</li><li>MB log for tickets</li></ol>
            <h2>Security</h2>
            <p><a href="/guides/secure-pdf-workflow">Secure PDF workflow</a> · <a href="/guides/password-protect-pdf">Password protect</a>.</p>
            
            
            <h2>Cross-wave tool chain</h2>
            <p>Pick tool order by what you need to deliver. Example: photos → images PDF → OCR → edit date → compress → portal upload.</p>
            <h2>Free tier and upgrade</h2>
            <p>Three uses per day per tool on free tier — agency month-end exceeds cap — <a href="/Subscription/Plans">subscription plans</a> — predictable vs per-file credit packs.</p>
            <h2>Internal link discipline</h2>
            <p>Each guide links to related tools and comparisons so your team picks the right workflow.</p>
            <h2>Support triage</h2>
            <p>Wrong tool order causes bad output — OCR before edit on scans — compress after merge not before each file — train your team using the main tool guides.</p>
            
            
            <h2>Failure messages</h2>
            <p><strong>Too large:</strong> compress or split. <strong>Invalid PDF:</strong> re-export source. <strong>Unreadable:</strong> re-scan don't only compress blur.</p>
            <h2>Archive discipline</h2>
            <p>Keep uncompressed master until upload or send succeeds — derivatives are disposable.</p>
            <h2>Compare tools</h2>
            <p><a href="/compare/smallpdf-alternative">Smallpdf</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/adobe-alternative">Adobe</a>.</p>
            
            
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
            
            
            <h2>Post-action checklist</h2>
            <ol><li>Output file opens in viewer</li><li>Text selects if required</li><li>Size under portal/email preset</li><li>Master archived</li><li>Correct tool used for next step (text vs Word vs OCR)</li></ol>
            <p>Bookmark the <a href="/guides/pdf-tools">PDF tools guide</a> and <a href="/compare">compare tools</a> for team onboarding — consistent tool choice reduces wrong-output support tickets.</p>
            <p>Re-run size checker after every derivative step — compress, split, or text export — before deleting the previous version from your working folder.</p>
            
            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Start now</strong> <a href="/pdf/pdftodoc" class="alert-link fw-semibold">PDF to Word →</a></div>
            <p class="mt-4"><a href="/pdf/pdftodoc" class="btn btn-primary">PDF to Word</a> · <a href="/compare">Compare PDF tools</a></p>
            """;

        private const string OcrPdf = """
            <h2>OCR PDF Online — Make Scanned PDFs Searchable (2026)</h2>
            <p>Authoritative guide for <strong>OCR PDF</strong> in your browser — no Adobe install. Updated 2026.</p>
            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> OCR PDF Online — Make Scanned PDFs Searchable (2026)</figcaption></figure>
            
            <h2>What OCR does</h2>
            <p>Adds searchable text layer to scans. <a href="/pdf/ocrpdf">OCR PDF</a> via Tesseract.</p>
            <h2>Step-by-step</h2>
            <ol>
            <li>Scan 300 DPI grayscale.</li>
            <li>Upload to <a href="/pdf/ocrpdf">OCR PDF</a>.</li>
            <li>Test Ctrl+F for known term.</li>
            <li>Then Word or Text export as needed.</li>
            </ol>
            <h2>OCR vs Text</h2>
            <p><a href="/guides/ocr-vs-pdf-to-text">OCR vs PDF to Text</a> decision tree.</p>
            <h2>Language guides</h2>
            <ul>
            <li><a href="/guides/ocr-pdf-hindi">Hindi</a> · <a href="/guides/ocr-pdf-arabic">Arabic</a> · <a href="/guides/ocr-pdf-chinese">Chinese</a></li>
            <li><a href="/guides/ocr-pdf-spanish">Spanish</a> · <a href="/guides/ocr-pdf-french">French</a> · <a href="/guides/ocr-pdf-german">German</a></li>
            </ul>
            <h2>Workflows</h2>
            <ul>
            <li><a href="/guides/scanned-pdf-to-word">Scanned to Word</a> · <a href="/guides/ocr-pdf-ediscovery">E-discovery</a></li>
            <li><a href="/guides/ocr-scanned-pdf-workflow">Full OCR workflow</a></li>
            </ul>
            <h2>FAQ — OCR</h2>
            <p><strong>Handwriting?</strong> Poor accuracy — retype critical fields.</p>
            
            <div class="rp-mid-cta alert alert-primary my-4"><strong>Open OCR PDF tool</strong> <a href="/pdf/ocrpdf" class="alert-link fw-semibold">OCR PDF →</a></div>
            
            <h2>Accuracy expectations by document type</h2>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>Type</th><th>Typical accuracy</th><th>Action</th></tr></thead>
            <tbody>
            <tr><td>Typed laser print</td><td>High</td><td>OCR + spot-check amounts</td></tr>
            <tr><td>Dot-matrix / fax</td><td>Low</td><td>Re-scan or retype critical fields</td></tr>
            <tr><td>Handwritten margin notes</td><td>Very low</td><td>Retype notes; OCR body only</td></tr>
            <tr><td>Tables with rules</td><td>Medium</td><td>Verify column alignment in export</td></tr>
            </tbody>
            </table></div>

            <h2>Downstream automation</h2>
            <p>Export OCR'd text to Python RAG pipelines — <a href="/guides/pdf-to-text-python-workflow">PDF to text Python workflow</a>. Chunk UTF-8 files; do not feed raw PDF images to LLM without OCR.</p>

            <h2>Legal and compliance</h2>
            <p>OCR output is working copy — signed scan remains evidence. For court production, confirm OCR meets local e-discovery rules — <a href="/guides/ocr-pdf-ediscovery">e-discovery OCR guide</a>.</p>

            <h2>Batch queue discipline</h2>
            <p>One PDF per OCR session on free tier — name outputs <code>doc-ocr-searchable.pdf</code> immediately; browser refresh loses in-memory state.</p>

            <h2>Compare cloud OCR vendors</h2>
            <p><a href="/guides/tesseract-vs-online-ocr">Tesseract vs online OCR</a> — privacy, cost, and accuracy trade-offs for general documents.</p>

            <h2>Compress after OCR?</h2>
            <p>OCR adds text layer — file grows. Compress after OCR succeeds, not before — <a href="/research/pdf-compression-benchmark">compression benchmark</a>.</p>

            <h2>HowTo summary</h2>
            <ol>
            <li>Scan 300 DPI grayscale (or colour for stamps)</li>
            <li>Deskew and crop in Preview/Photos if needed</li>
            <li>Upload to <a href="/pdf/ocrpdf">OCR PDF</a></li>
            <li>Verify search in viewer</li>
            <li>Export text or convert to Word</li>
            <li>Proofread Latin fields manually</li>
            </ol>

            <h2>Desktop scanner profiles</h2>
            <p>Save TWAIN profile "OCR-general-300dpi-gray" — one-click rescan when first pass fails QA. Avoid colour unless stamps or signatures need hue discrimination.</p>

            <h2>GDPR and PII</h2>
            <p>general identity documents contain PII — OCR on RatPDF over HTTPS; delete local copies after HR onboarding completes. Do not OCR passports on untrusted browser extensions.</p>
            
            <h2>Regulatory and discovery context</h2>
            <p>OCR for e-discovery prep: <a href="/guides/ocr-pdf-ediscovery">OCR PDF e-discovery</a>. Small firm productions — not Relativity replacement.</p>

            <h2>Accessibility angle</h2>
            <p>OCR helps search for screen-reader users when tags missing — see <a href="/guides/pdf-to-text-accessibility">PDF to text accessibility</a>. True WCAG compliance still needs tagging.</p>

            <h2>Upgrade prompt</h2>
            <p>High-volume OCR queues — <a href="/Subscription/Plans">compare plans</a> · Compare: <a href="/compare/ilovepdf-alternative">iLovePDF alternative</a>.</p>
            
            <h2>OCR pipeline on RatPDF</h2>
            <p>Tesseract adds invisible text layer over page images — Ctrl+F works in PDF viewers; copy/paste extracts UTF-8. Not the same as perfect transcription — always proofread legal amounts and IDs.</p>

            <h2>After OCR — next tools</h2>
            <ul>
            <li><a href="/pdf/pdftotext">PDF to Text</a> — plain .txt export</li>
            <li><a href="/guides/scanned-pdf-to-word">Scanned PDF to Word</a> — editable DOCX</li>
            <li><a href="/guides/pdf-to-text-multilingual">PDF to text multilingual</a> — Unicode tips</li>
            </ul>

            <h2>Privacy and retention</h2>
            <p>Scanned IDs and contracts contain PII — review privacy policy retention window. Clear local Downloads on shared machines.</p>

            <h2>Tesseract vs cloud OCR</h2>
            <p>Research: <a href="/guides/tesseract-vs-online-ocr">Tesseract vs online OCR</a> — RatPDF keeps processing on controlled infrastructure vs sending scans to unknown APIs.</p>

            <h2>Scan settings reference</h2>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>Document</th><th>DPI</th><th>Mode</th></tr></thead>
            <tbody>
            <tr><td>Typed contract</td><td>200–300</td><td>Grayscale</td></tr>
            <tr><td>Small print legal</td><td>300</td><td>Grayscale</td></tr>
            <tr><td>Colour stamps</td><td>300</td><td>Colour</td></tr>
            </tbody>
            </table></div>

            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Make scans searchable</strong> <a href="/pdf/ocrpdf" class="alert-link fw-semibold">OCR PDF →</a></div>

            <h2>Language pack limitations</h2>
            <p>Tesseract language packs vary by deployment — mixed {name}/English documents may need manual verification of each script block. Dense footnotes OCR poorly — treat as best-effort.</p>

            <h2>Export formats after OCR</h2>
            <p>Searchable PDF for archival · <a href="/pdf/pdftotext">.txt</a> for scripts · <a href="/guides/scanned-pdf-to-word">DOCX</a> for track-changes legal review.</p>

            <h2>Historical newspaper and book scans</h2>
            <p>Low-contrast newsprint needs aggressive contrast preprocessing before OCR — expect proper-noun errors in {name} place names; gazetteer lookup for validation.</p>
            
            <h2>Related guides &amp; cluster links</h2>
            <ul>
            <li><a href="/guides/ocr-pdf">OCR PDF guide</a></li>
            <li><a href="/guides/ocr-scanned-pdf-workflow">OCR scanned PDF workflow</a></li>
            <li><a href="/guides/ocr-pdf-poor-quality">OCR poor quality scans</a></li>
            <li><a href="/guides/scanned-pdf-to-word">Scanned PDF to Word</a></li>
            </ul>
            <p>Research: <a href="/research/pdf-compression-benchmark">PDF compression benchmark</a> · Compare: <a href="/compare/adobe-alternative">Adobe alternative</a></p>
            
            <h2>Translation and NLP after OCR</h2>
            <p>UTF-8 text exports feed Google Translate API, DeepL, or local MarianMT — OCR quality caps translation quality. Proofread {name} proper nouns before machine translation of contracts.</p>

            <h2>Redaction warning</h2>
            <p>OCR text layer may include redacted content still readable in object stream if redaction was fake black boxes — use true redaction tool before OCR for sensitive releases.</p>

            <h2>Government portal uploads</h2>
            <p>India GST notices, EU tax letters, immigration forms — searchable OCR PDF satisfies "text selectable" portal checks where specified.</p>

            <h2>FAQ inline</h2>
            <p><strong>Is OCR free?</strong> Three OCR uses per day on free tier. <strong>Handwriting?</strong> Not reliable — retype. <strong>Password PDF?</strong> <a href="/pdf/unlock">Unlock</a> first.</p>

            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Search your {name} scans</strong> <a href="/pdf/ocrpdf" class="alert-link fw-semibold">OCR PDF →</a></div>

            <h2>Closing summary</h2>
            <p>{name} OCR is scan quality in, searchable PDF out — proofread every field that moves money, crosses a border, or enters a court file. Then chain to PDF to Text or Word for editing.</p>
            <p>Bookmark this guide for your team's wiki — consistent scan settings beat trying a different OCR vendor each week.</p>
            
            <h2>Quality sampling for large jobs</h2>
            <p>OCR 500 pages? Sample 5% — if error rate above 2% on names/amounts, adjust scan settings and re-run batch. Do not spot-check only page 1.</p>

            <h2>Font and stamp overlays</h2>
            <p>Official stamps over {name} text reduce confidence — OCR may miss stamped regions. Legally critical stamped paragraphs may need manual transcription.</p>

            <h2>Seasonal backlog tips</h2>
            <p>Tax season floods firms with {name} scans — queue OCR overnight, verify mornings. Pro tier removes daily friction for backlogs.</p>

            <h2>Integration with merge cluster</h2>
            <p>OCR'd packs often merge next — <a href="/guides/merge-scanned-digital-pdf">merge scanned and digital</a> · <a href="/guides/merge-pdf-without-quality-loss">quality merge</a>.</p>

            <h2>Related invoice guides</h2>
            <p>Scanned supplier invoices in {name}: OCR → extract totals → match to <a href="/guides/invoice-generator-india">invoice workflows</a> or local ERP.</p>

            <h2>Keyboard shortcuts after OCR</h2>
            <p>In PDF viewer: Ctrl+F for QA terms. In Word after conversion: Navigation pane headings — if empty, source PDF lacked structure; OCR text still usable for search.</p>

            <h2>Compare vendors</h2>
            <p><a href="/compare/adobe-alternative">Adobe alternative</a> · <a href="/compare/smallpdf-alternative">Smallpdf alternative</a> — evaluate privacy before uploading {name} PII scans.</p>

            <h2>OCR cluster peer pages</h2>
            <p>Language guides: <a href="/guides/ocr-pdf-hindi">Hindi</a> · <a href="/guides/ocr-pdf-arabic">Arabic</a> · <a href="/guides/ocr-pdf-spanish">Spanish</a> · Quality: <a href="/guides/ocr-pdf-poor-quality">poor quality OCR</a>.</p>
            
            <h2>Plain text vs Word vs OCR PDF</h2>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>Need</th><th>Tool</th></tr></thead>
            <tbody>
            <tr><td>Edit layout</td><td><a href="/pdf/pdftodoc">PDF to Word</a></td></tr>
            <tr><td>Grep / scripts / LLM</td><td><a href="/pdf/pdftotext">PDF to Text</a></td></tr>
            <tr><td>Searchable scan archive</td><td><a href="/pdf/ocrpdf">OCR PDF</a></td></tr>
            <tr><td>Remove PII</td><td><a href="/pdf-redaction">PDF Redaction</a></td></tr>
            </tbody>
            </table></div>

            <h2>UTF-8 and encoding</h2>
            <p>Export .txt as UTF-8 — Excel import may need delimiter cleanup — strip BOM if downstream parser chokes.</p>

            <h2>Batch extraction</h2>
            <p>Research folder 80 papers — OCR batch overnight — text export each morning — build citation spreadsheet from .txt snippets not manual copy-paste.</p>

            <h2>Academic integrity</h2>
            <p>Extracted quotes still need citation — text tool does not grant reproduction rights — follow publisher fair use.</p>
            
            
            <h2>Scanner hardware profiles</h2>
            <p>Save TWAIN preset OCR-300dpi-gray — one-click rescan when QA fails. Avoid colour mode unless stamps need hue.</p>
            <h2>Batch overnight OCR</h2>
            <p>Paralegal queues 40 discovery scans — OCR each morning — grep privilege terms in viewer — open PDF only for hits.</p>
            <h2>GDPR and HIPAA</h2>
            <p>Identity docs and medical admin scans — HTTPS upload — delete local copies after HR/clinical task — enterprise AI ingest prohibited without DPA.</p>
            <h2>OCR then compress order</h2>
            <p>Always OCR before compress on scans needing search — compress after OCR adds text layer — file may grow then shrink.</p>
            <h2>Compare OCR tools</h2>
            <p><a href="/guides/tesseract-vs-online-ocr">Tesseract vs online</a> · <a href="/compare/adobe-acrobat-alternative">Adobe</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a>.</p>
            
            
            <h2>FOIA and compliance corpus</h2>
            <p>OCR policy scans — grep retention terms — cite original PDF page in findings.</p>
            <h2>Related OCR guides</h2>
            <p><a href="/guides/ocr-pdf-russian">Russian</a> · <a href="/guides/ocr-pdf-korean">Korean</a> · <a href="/guides/ocr-pdf-poor-quality">Poor quality</a> · <a href="/guides/extract-text-scanned-pdf">Extract text</a>.</p>
            
            
            <h2>OCR guides</h2>
            <ul>
            <li><a href="/guides/ocr-scanned-pdf-workflow">Full OCR workflow</a> · <a href="/guides/extract-text-scanned-pdf">Extract text from scan</a></li>
            <li><a href="/guides/ocr-vs-pdf-to-text">OCR vs PDF to Text</a> · <a href="/guides/tesseract-vs-online-ocr">Tesseract vs online</a></li>
            <li><a href="/guides/ocr-pdf-ediscovery">E-discovery</a> · <a href="/guides/pdf-to-text-accessibility">Accessibility</a></li>
            <li>Languages: <a href="/guides/ocr-pdf-hindi">Hindi</a> · <a href="/guides/ocr-pdf-arabic">Arabic</a> · <a href="/guides/ocr-pdf-chinese">Chinese</a> · <a href="/guides/ocr-pdf-spanish">Spanish</a> · <a href="/guides/ocr-pdf-french">French</a> · <a href="/guides/ocr-pdf-german">German</a></li>
            </ul>
            <h2>OCR QA sampling protocol</h2>
            <p>Random 10% page spot-check on batch jobs — if error rate high, fix scan settings before remaining 90% — log QA date in matter file.</p>
            <h2>Downstream tool order</h2>
            <p>OCR → searchable PDF archive → optional pdftotext for scripts → optional pdftodoc for human edit — never skip OCR on image-only PDF for search.</p>
            
            
            <h2>Why RatPDF for browser PDF workflows</h2>
            <p>No install, no IT ticket — upload, process, download. Free tier: three uses per tool per day. Confidential docs: review <a href="/home/privacy">privacy policy</a> and <a href="/home/security">security page</a> before uploading client contracts.</p>
            <h2>Tool chain after this task</h2>
            <p>Most PDF jobs chain tools: OCR → edit → merge → compress → sign. Start here: <a href="/guides/pdf-tools">PDF tools guide</a> · Compare vendors: <a href="/compare">compare tools</a>.</p>
            <h2>Research &amp; data</h2>
            <p><a href="/research/attachment-size-limits">Email attachment limits</a> · <a href="/research/pdf-compression-benchmark">PDF compression benchmark</a> · <a href="/research/pdf-tool-market-comparison">PDF tool market comparison</a>.</p>
            
            <p>Then: <a href="/guides/pdf-to-word">PDF to Word guide</a> · <a href="/guides/pdf-txt-guide">PDF to Text</a>.</p>
            
            <h2>Corporate rollout checklist</h2>
            <ol><li>IT wiki tool list</li><li>Digital vs scan tree</li><li>Filename versioning</li><li>MB log for tickets</li></ol>
            <h2>Security</h2>
            <p><a href="/guides/secure-pdf-workflow">Secure PDF workflow</a> · <a href="/guides/password-protect-pdf">Password protect</a>.</p>
            
            
            <h2>Cross-wave tool chain</h2>
            <p>Pick tool order by what you need to deliver. Example: photos → images PDF → OCR → edit date → compress → portal upload.</p>
            <h2>Free tier and upgrade</h2>
            <p>Three uses per day per tool on free tier — agency month-end exceeds cap — <a href="/Subscription/Plans">subscription plans</a> — predictable vs per-file credit packs.</p>
            <h2>Internal link discipline</h2>
            <p>Each guide links to related tools and comparisons so your team picks the right workflow.</p>
            <h2>Support triage</h2>
            <p>Wrong tool order causes bad output — OCR before edit on scans — compress after merge not before each file — train your team using the main tool guides.</p>
            
            
            <h2>Failure messages</h2>
            <p><strong>Too large:</strong> compress or split. <strong>Invalid PDF:</strong> re-export source. <strong>Unreadable:</strong> re-scan don't only compress blur.</p>
            <h2>Archive discipline</h2>
            <p>Keep uncompressed master until upload or send succeeds — derivatives are disposable.</p>
            <h2>Compare tools</h2>
            <p><a href="/compare/smallpdf-alternative">Smallpdf</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/adobe-alternative">Adobe</a>.</p>
            
            
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
            
            
            <h2>Post-action checklist</h2>
            <ol><li>Output file opens in viewer</li><li>Text selects if required</li><li>Size under portal/email preset</li><li>Master archived</li><li>Correct tool used for next step (text vs Word vs OCR)</li></ol>
            <p>Bookmark the <a href="/guides/pdf-tools">PDF tools guide</a> and <a href="/compare">compare tools</a> for team onboarding — consistent tool choice reduces wrong-output support tickets.</p>
            <p>Re-run size checker after every derivative step — compress, split, or text export — before deleting the previous version from your working folder.</p>
            
            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Start now</strong> <a href="/pdf/ocrpdf" class="alert-link fw-semibold">OCR PDF →</a></div>
            <p class="mt-4"><a href="/pdf/ocrpdf" class="btn btn-primary">OCR PDF</a> · <a href="/compare">Compare PDF tools</a></p>
            """;

    }
}
