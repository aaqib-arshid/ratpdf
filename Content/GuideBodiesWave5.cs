namespace ratpdf.Content
{
    /// <summary>Wave 5 — Compress platform, PDF to Text, Split clusters (SEO audit).</summary>
    internal static class GuideBodiesWave5
    {
        public static string? Get(string slug) => slug switch
        {
            "compress-pdf-on-mac" => CompressPdfOnMac,
            "compress-pdf-on-windows" => CompressPdfOnWindows,
            "compress-pdf-on-iphone" => CompressPdfOnIphone,
            "compress-pdf-on-android" => CompressPdfOnAndroid,
            "compress-pdf-incometax" => CompressPdfIncometax,
            "compress-pdf-irctc" => CompressPdfIrctc,
            "compress-pdf-home-affairs-australia" => CompressPdfHomeAffairsAustralia,
            "compress-pdf-immigration-canada" => CompressPdfImmigrationCanada,
            "compress-pdf-made-it-larger" => CompressPdfMadeItLarger,
            "batch-compress-pdf" => BatchCompressPdf,
            "combine-then-compress-pdf" => CombineThenCompressPdf,
            "pdf-to-text-research" => PdfToTextResearch,
            "pdf-to-text-legal" => PdfToTextLegal,
            "pdf-to-text-bank-statements" => PdfToTextBankStatements,
            "extract-text-without-adobe" => ExtractTextWithoutAdobe,
            "split-pdf-for-email" => SplitPdfForEmail,
            "split-pdf-by-size" => SplitPdfBySize,
            _ => null
        };

        private const string CompressPdfOnMac = """
            <h2>Compress PDF on Mac — Safari &amp; Chrome workflow</h2>
            <p>Compress oversized PDFs on Mac using Safari or Chrome — no App Store or desktop install. RatPDF <a href="/pdf/compress">Compress PDF</a> runs in your mobile or desktop browser.</p>
            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> Mac browser on RatPDF compress upload</figcaption></figure>
            <h2>Real example: MacBook user shrinks 18 MB scan before AirDrop to colleague</h2>
            <ol>
            <li>Open RatPDF Compress PDF in Safari or Chrome.</li>
            <li>Upload PDF from Files/Downloads.</li>
            <li>Choose Recommended — download smaller file.</li>
            <li>Attach to email or portal — verify opens correctly.</li>
            </ol>
            
            <h2>macOS-specific tips</h2>
            <p>Preview does not compress — use RatPDF in Safari. Save to Downloads or iCloud Drive — attach from Files in Mail. Apple Mail Base64 overhead ~33% on top of file size.</p>
            <h2>Second example: dissertation PDF</h2>
            <p>80 MB thesis — Recommended → 22 MB — supervisor email accepts. Keep original on external SSD for print submission.</p>
            <h2>Mac + iPhone handoff</h2>
            <p>Compress on Mac — AirDrop to iPhone for portal upload — <a href="/guides/compress-pdf-on-iphone">iPhone compress guide</a> if only mobile available.</p>
            
            <div class="rp-mid-cta alert alert-primary my-4"><strong>Compress on Mac</strong> <a href="/pdf/compress" class="alert-link fw-semibold">Compress PDF →</a></div>
            
            <h2>Compression levels</h2>
            <p><strong>Less:</strong> signatures and stamps. <strong>Recommended:</strong> default. <strong>Extreme:</strong> last resort — verify legibility.</p>
            <h2>Pre-upload checklist</h2>
            <ol>
            <li><a href="/pdf-size-checker">PDF size checker</a> preset</li>
            <li>Rotate scans upright</li>
            <li>One compress pass after merge</li>
            <li>Keep master until upload succeeds</li>
            </ol>
            <h2>Email variants</h2>
            <p><a href="/guides/compress-pdf-for-gmail">Gmail</a> · <a href="/guides/compress-pdf-for-outlook">Outlook</a> · <a href="/guides/compress-pdf-for-whatsapp">WhatsApp</a>.</p>
            <h2>Immigration cross-links</h2>
            <p><a href="/guides/compress-pdf-for-visa-application">Visa application</a> · <a href="/guides/compress-pdf-schengen-visa">Schengen</a> · <a href="/guides/compress-pdf-digilocker">DigiLocker</a>.</p>
            <h2>Industry guides</h2>
            <p><a href="/guides/compress-pdf-lawyers">Lawyers</a> · <a href="/guides/compress-pdf-accountants">Accountants</a> · <a href="/guides/compress-pdf-efiling">E-filing</a>.</p>
            
            
            <h2>Ghostscript levels recap</h2>
            <p><strong>Less:</strong> legal scans and signatures. <strong>Recommended:</strong> email and portals. <strong>Extreme:</strong> last resort — verify text at 100% zoom.</p>
            <h2>Size checker</h2>
            <p><a href="/pdf-size-checker">PDF size checker</a> presets before/after compress — Gmail 20 MB, portal 5 MB.</p>
            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Compress now</strong> <a href="/pdf/compress" class="alert-link fw-semibold">Compress PDF →</a></div>
            
            
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
            
            
            <h2>Operational deep dive — Mac</h2>
            <p>Ghostscript compression re-encodes embedded images while vector text usually stays sharp. Phone photos and 600 DPI scans dominate file size — scan at 200–300 DPI grayscale for text proofs before compress saves more than Extreme on blurry source.</p>
            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> Compress PDF workflow — Mac</figcaption></figure>
            <h2>Double compression trap</h2>
            <p>Compress → merge → compress again softens text twice — <a href="/guides/compress-before-merge-pdf">merge/compress order guide</a>.</p>
            <h2>Portal rejection decode</h2>
            <p><strong>Too large:</strong> compress or <a href="/guides/split-pdf-for-email">split</a>. <strong>Unreadable:</strong> re-scan. <strong>Password:</strong> <a href="/guides/unlock-pdf">unlock</a> first.</p>
            <h2>Research</h2>
            <p><a href="/research/pdf-compression-benchmark">PDF compression benchmark</a> · <a href="/research/attachment-size-limits">Attachment size limits</a>.</p>
            <h2>Free tier</h2>
            <p>Three uses/day — high volume <a href="/Subscription/Plans">plans</a>.</p>
            <h2>Related compression guides</h2>
            <p>Portal compress: <a href="/guides/compress-pdf-gst-portal">GST portal</a> · <a href="/guides/compress-pdf-schengen-visa">Schengen</a> · <a href="/guides/compress-pdf-for-government-forms">government forms</a>.</p>
            <h2>Related Word conversion guides</h2>
            <p>After Word edit re-export: <a href="/guides/pdf-to-word-keep-formatting">keep formatting</a> — then compress for email.</p>
            
            
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
            
            
            <h2>Industry cross-links</h2>
            <p>Lawyers: <a href="/guides/compress-pdf-lawyers">compress for lawyers</a> · Realtors: <a href="/guides/compress-pdf-realtors">realtors</a> · Healthcare: <a href="/guides/compress-pdf-healthcare">healthcare</a> · Accountants: <a href="/guides/compress-pdf-accountants">accountants</a>.</p>

            <h2>Merge and OCR chain</h2>
            <p>OCR'd scans are larger — <a href="/guides/ocr-pdf">OCR PDF</a> then compress. Multi-file: <a href="/guides/merge-pdf-online">merge</a> then <a href="/guides/compress-before-merge-pdf">compress decision</a>.</p>
            
            
            <h2>Failure messages</h2>
            <p><strong>Too large:</strong> compress or split. <strong>Invalid PDF:</strong> re-export source. <strong>Unreadable:</strong> re-scan don't only compress blur.</p>
            <h2>Archive discipline</h2>
            <p>Keep uncompressed master until upload or send succeeds — derivatives are disposable.</p>
            <h2>Compare tools</h2>
            <p><a href="/compare/smallpdf-alternative">Smallpdf</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/adobe-alternative">Adobe</a>.</p>
            
            
            <h2>Device sync workflows</h2>
            <p>Compress on desktop — save to cloud — open on mobile for portal upload — same file hash verify across devices.</p>
            <h2>Antivirus false positives</h2>
            <p>Rare corporate AV blocks download — whitelist ratpdf.com — retry Edge if Chrome extension interferes.</p>
            <h2>Colour stamp preservation</h2>
            <p>Immigration stamps — Less not Extreme — verify red ink visible after compress on portal preview.</p>
            <h2>Wi-Fi vs cellular</h2>
            <p>Large upload on train — may timeout — finish compress download on Wi-Fi before switching to mobile data for portal.</p>
            <h2>Filename discipline</h2>
            <p><code>Passport-Compressed-2026.pdf</code> not <code>document(1).pdf</code> — immigration officers match checklist labels.</p>
            
            
            <h2>Quarterly tool check</h2>
            <p>Portal caps change — re-read upload widget each filing season — compress level that worked last year may need Less this year if portal tightens legibility checks.</p>
            <h2>Handoff to split</h2>
            <p>If still over cap after Less — <a href="/guides/split-pdf-for-email">split for email</a> before giving up on digital submission.</p>
            <h2>Batch naming for accountants</h2>
            <p><code>Client-YYYY-MM-invoice-compressed.pdf</code> — batch compress folder sorts chronologically in AP import.</p>
            <h2>Merge-then-compress SOP</h2>
            <p>Month-end board pack: merge in agenda order → single compress → one email attachment — log final MB in board portal.</p>
            
            
            <h2>Tool chain map</h2>
            <p>OCR → compress → merge → split — pick order by portal rules. See <a href="/guides/compress-before-merge-pdf">compress vs merge</a> and <a href="/guides/pdf-to-word-vs-pdf-to-text">Word vs Text</a>.</p>
            <h2>Upgrade volume</h2>
            <p>Migration and month-end batches: <a href="/Subscription/Plans">subscription plans</a>.</p>
            
            
            <h2>Related compress guides</h2>
            <ul>
            <li><a href="/guides/compress-pdf-guide">Compress PDF guide</a></li>
            <li><a href="/guides/compress-before-merge-pdf">Compress before/after merge</a></li>
            <li><a href="/guides/batch-compress-pdf">Batch compress PDF</a></li>
            <li><a href="/guides/compress-pdf-made-it-larger">Compress made it larger</a></li>
            </ul>
            <p>Research: <a href="/research/attachment-size-limits">Attachment size limits</a> · <a href="/research/pdf-compression-benchmark">PDF compression benchmark</a></p>
            
            
            <h2>Related guides</h2>
            <p>Platform-specific compression (Mac, Windows, mobile), portal upload limits, PDF to Text export, and split-for-email guides round out the compression workflow.</p>
            
            
            <h2>Post-action checklist</h2>
            <ol><li>Output file opens in viewer</li><li>Text selects if required</li><li>Size under portal/email preset</li><li>Master archived</li><li>Correct tool used for next step (text vs Word vs OCR)</li></ol>
            <p>Bookmark the <a href="/guides/pdf-tools">PDF tools guide</a> and <a href="/compare">compare tools</a> for team onboarding — consistent tool choice reduces wrong-output support tickets.</p>
            <p>Re-run size checker after every derivative step — compress, split, or text export — before deleting the previous version from your working folder.</p>
            
            <p class="mt-4"><a href="/pdf/compress" class="btn btn-primary">Compress PDF free</a> · <a href="/compare/smallpdf-alternative">Compare</a></p>
            """;

        private const string CompressPdfOnWindows = """
            <h2>Compress PDF on Windows — Edge &amp; Chrome workflow</h2>
            <p>Compress oversized PDFs on Windows PC using Edge or Chrome — no App Store or desktop install. RatPDF <a href="/pdf/compress">Compress PDF</a> runs in your mobile or desktop browser.</p>
            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> Windows PC browser on RatPDF compress upload</figcaption></figure>
            <h2>Real example: Windows 11 user compresses court exhibit before e-filing upload</h2>
            <ol>
            <li>Open RatPDF Compress PDF in Edge or Chrome.</li>
            <li>Upload PDF from Files/Downloads.</li>
            <li>Choose Recommended — download smaller file.</li>
            <li>Attach to email or portal — verify opens correctly.</li>
            </ol>
            
            <h2>Windows-specific tips</h2>
            <p>Edge and Chrome work — no Microsoft Store PDF app required. Save from Downloads — attach in Outlook desktop. Corporate Defender may scan upload — allow ratpdf.com if IT policy blocks.</p>
            <h2>Second example: discovery ZIP extract</h2>
            <p>Single 45 MB exhibit — compress → 12 MB — Outlook internal gateway accepts.</p>
            
            <div class="rp-mid-cta alert alert-primary my-4"><strong>Compress on Windows PC</strong> <a href="/pdf/compress" class="alert-link fw-semibold">Compress PDF →</a></div>
            
            <h2>Compression levels</h2>
            <p><strong>Less:</strong> signatures and stamps. <strong>Recommended:</strong> default. <strong>Extreme:</strong> last resort — verify legibility.</p>
            <h2>Pre-upload checklist</h2>
            <ol>
            <li><a href="/pdf-size-checker">PDF size checker</a> preset</li>
            <li>Rotate scans upright</li>
            <li>One compress pass after merge</li>
            <li>Keep master until upload succeeds</li>
            </ol>
            <h2>Email variants</h2>
            <p><a href="/guides/compress-pdf-for-gmail">Gmail</a> · <a href="/guides/compress-pdf-for-outlook">Outlook</a> · <a href="/guides/compress-pdf-for-whatsapp">WhatsApp</a>.</p>
            <h2>Immigration cross-links</h2>
            <p><a href="/guides/compress-pdf-for-visa-application">Visa application</a> · <a href="/guides/compress-pdf-schengen-visa">Schengen</a> · <a href="/guides/compress-pdf-digilocker">DigiLocker</a>.</p>
            <h2>Industry guides</h2>
            <p><a href="/guides/compress-pdf-lawyers">Lawyers</a> · <a href="/guides/compress-pdf-accountants">Accountants</a> · <a href="/guides/compress-pdf-efiling">E-filing</a>.</p>
            
            
            <h2>Ghostscript levels recap</h2>
            <p><strong>Less:</strong> legal scans and signatures. <strong>Recommended:</strong> email and portals. <strong>Extreme:</strong> last resort — verify text at 100% zoom.</p>
            <h2>Size checker</h2>
            <p><a href="/pdf-size-checker">PDF size checker</a> presets before/after compress — Gmail 20 MB, portal 5 MB.</p>
            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Compress now</strong> <a href="/pdf/compress" class="alert-link fw-semibold">Compress PDF →</a></div>
            
            
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
            
            
            <h2>Operational deep dive — Windows PC</h2>
            <p>Ghostscript compression re-encodes embedded images while vector text usually stays sharp. Phone photos and 600 DPI scans dominate file size — scan at 200–300 DPI grayscale for text proofs before compress saves more than Extreme on blurry source.</p>
            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> Compress PDF workflow — Windows PC</figcaption></figure>
            <h2>Double compression trap</h2>
            <p>Compress → merge → compress again softens text twice — <a href="/guides/compress-before-merge-pdf">merge/compress order guide</a>.</p>
            <h2>Portal rejection decode</h2>
            <p><strong>Too large:</strong> compress or <a href="/guides/split-pdf-for-email">split</a>. <strong>Unreadable:</strong> re-scan. <strong>Password:</strong> <a href="/guides/unlock-pdf">unlock</a> first.</p>
            <h2>Research</h2>
            <p><a href="/research/pdf-compression-benchmark">PDF compression benchmark</a> · <a href="/research/attachment-size-limits">Attachment size limits</a>.</p>
            <h2>Free tier</h2>
            <p>Three uses/day — high volume <a href="/Subscription/Plans">plans</a>.</p>
            <h2>Related compression guides</h2>
            <p>Portal compress: <a href="/guides/compress-pdf-gst-portal">GST portal</a> · <a href="/guides/compress-pdf-schengen-visa">Schengen</a> · <a href="/guides/compress-pdf-for-government-forms">government forms</a>.</p>
            <h2>Related Word conversion guides</h2>
            <p>After Word edit re-export: <a href="/guides/pdf-to-word-keep-formatting">keep formatting</a> — then compress for email.</p>
            
            
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
            
            
            <h2>Industry cross-links</h2>
            <p>Lawyers: <a href="/guides/compress-pdf-lawyers">compress for lawyers</a> · Realtors: <a href="/guides/compress-pdf-realtors">realtors</a> · Healthcare: <a href="/guides/compress-pdf-healthcare">healthcare</a> · Accountants: <a href="/guides/compress-pdf-accountants">accountants</a>.</p>

            <h2>Merge and OCR chain</h2>
            <p>OCR'd scans are larger — <a href="/guides/ocr-pdf">OCR PDF</a> then compress. Multi-file: <a href="/guides/merge-pdf-online">merge</a> then <a href="/guides/compress-before-merge-pdf">compress decision</a>.</p>
            
            
            <h2>Failure messages</h2>
            <p><strong>Too large:</strong> compress or split. <strong>Invalid PDF:</strong> re-export source. <strong>Unreadable:</strong> re-scan don't only compress blur.</p>
            <h2>Archive discipline</h2>
            <p>Keep uncompressed master until upload or send succeeds — derivatives are disposable.</p>
            <h2>Compare tools</h2>
            <p><a href="/compare/smallpdf-alternative">Smallpdf</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/adobe-alternative">Adobe</a>.</p>
            
            
            <h2>Device sync workflows</h2>
            <p>Compress on desktop — save to cloud — open on mobile for portal upload — same file hash verify across devices.</p>
            <h2>Antivirus false positives</h2>
            <p>Rare corporate AV blocks download — whitelist ratpdf.com — retry Edge if Chrome extension interferes.</p>
            <h2>Colour stamp preservation</h2>
            <p>Immigration stamps — Less not Extreme — verify red ink visible after compress on portal preview.</p>
            <h2>Wi-Fi vs cellular</h2>
            <p>Large upload on train — may timeout — finish compress download on Wi-Fi before switching to mobile data for portal.</p>
            <h2>Filename discipline</h2>
            <p><code>Passport-Compressed-2026.pdf</code> not <code>document(1).pdf</code> — immigration officers match checklist labels.</p>
            
            
            <h2>Quarterly tool check</h2>
            <p>Portal caps change — re-read upload widget each filing season — compress level that worked last year may need Less this year if portal tightens legibility checks.</p>
            <h2>Handoff to split</h2>
            <p>If still over cap after Less — <a href="/guides/split-pdf-for-email">split for email</a> before giving up on digital submission.</p>
            <h2>Batch naming for accountants</h2>
            <p><code>Client-YYYY-MM-invoice-compressed.pdf</code> — batch compress folder sorts chronologically in AP import.</p>
            <h2>Merge-then-compress SOP</h2>
            <p>Month-end board pack: merge in agenda order → single compress → one email attachment — log final MB in board portal.</p>
            
            
            <h2>Tool chain map</h2>
            <p>OCR → compress → merge → split — pick order by portal rules. See <a href="/guides/compress-before-merge-pdf">compress vs merge</a> and <a href="/guides/pdf-to-word-vs-pdf-to-text">Word vs Text</a>.</p>
            <h2>Upgrade volume</h2>
            <p>Migration and month-end batches: <a href="/Subscription/Plans">subscription plans</a>.</p>
            
            
            <h2>Related compress guides</h2>
            <ul>
            <li><a href="/guides/compress-pdf-guide">Compress PDF guide</a></li>
            <li><a href="/guides/compress-before-merge-pdf">Compress before/after merge</a></li>
            <li><a href="/guides/batch-compress-pdf">Batch compress PDF</a></li>
            <li><a href="/guides/compress-pdf-made-it-larger">Compress made it larger</a></li>
            </ul>
            <p>Research: <a href="/research/attachment-size-limits">Attachment size limits</a> · <a href="/research/pdf-compression-benchmark">PDF compression benchmark</a></p>
            
            
            <h2>Related guides</h2>
            <p>Platform-specific compression (Mac, Windows, mobile), portal upload limits, PDF to Text export, and split-for-email guides round out the compression workflow.</p>
            
            
            <h2>Post-action checklist</h2>
            <ol><li>Output file opens in viewer</li><li>Text selects if required</li><li>Size under portal/email preset</li><li>Master archived</li><li>Correct tool used for next step (text vs Word vs OCR)</li></ol>
            <p>Bookmark the <a href="/guides/pdf-tools">PDF tools guide</a> and <a href="/compare">compare tools</a> for team onboarding — consistent tool choice reduces wrong-output support tickets.</p>
            <p>Re-run size checker after every derivative step — compress, split, or text export — before deleting the previous version from your working folder.</p>
            
            <p class="mt-4"><a href="/pdf/compress" class="btn btn-primary">Compress PDF free</a> · <a href="/compare/smallpdf-alternative">Compare</a></p>
            """;

        private const string CompressPdfOnIphone = """
            <h2>Compress PDF on iPhone — mobile Safari workflow</h2>
            <p>Compress oversized PDFs on iPhone using Safari — no App Store or desktop install. RatPDF <a href="/pdf/compress">Compress PDF</a> runs in your mobile or desktop browser.</p>
            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> iPhone browser on RatPDF compress upload</figcaption></figure>
            <h2>Real example: Compress passport scan on iPhone before WhatsApp send</h2>
            <ol>
            <li>Open RatPDF Compress PDF in Safari.</li>
            <li>Upload PDF from Files/Downloads.</li>
            <li>Choose Recommended — download smaller file.</li>
            <li>Attach to email or portal — verify opens correctly.</li>
            </ol>
            
            <h2>iOS workflow</h2>
            <p>Safari upload from Files app — not iMessage inline preview. After compress, tap Share → Mail or portal Safari tab. Low Power Mode may slow upload — use Wi-Fi.</p>
            <h2>Second example: visa document on phone</h2>
            <p>Hotel booking PDF 8 MB — compress → 2 MB — VFS mobile upload succeeds.</p>
            
            <div class="rp-mid-cta alert alert-primary my-4"><strong>Compress on iPhone</strong> <a href="/pdf/compress" class="alert-link fw-semibold">Compress PDF →</a></div>
            
            <h2>Compression levels</h2>
            <p><strong>Less:</strong> signatures and stamps. <strong>Recommended:</strong> default. <strong>Extreme:</strong> last resort — verify legibility.</p>
            <h2>Pre-upload checklist</h2>
            <ol>
            <li><a href="/pdf-size-checker">PDF size checker</a> preset</li>
            <li>Rotate scans upright</li>
            <li>One compress pass after merge</li>
            <li>Keep master until upload succeeds</li>
            </ol>
            <h2>Email variants</h2>
            <p><a href="/guides/compress-pdf-for-gmail">Gmail</a> · <a href="/guides/compress-pdf-for-outlook">Outlook</a> · <a href="/guides/compress-pdf-for-whatsapp">WhatsApp</a>.</p>
            <h2>Immigration cross-links</h2>
            <p><a href="/guides/compress-pdf-for-visa-application">Visa application</a> · <a href="/guides/compress-pdf-schengen-visa">Schengen</a> · <a href="/guides/compress-pdf-digilocker">DigiLocker</a>.</p>
            <h2>Industry guides</h2>
            <p><a href="/guides/compress-pdf-lawyers">Lawyers</a> · <a href="/guides/compress-pdf-accountants">Accountants</a> · <a href="/guides/compress-pdf-efiling">E-filing</a>.</p>
            
            
            <h2>Ghostscript levels recap</h2>
            <p><strong>Less:</strong> legal scans and signatures. <strong>Recommended:</strong> email and portals. <strong>Extreme:</strong> last resort — verify text at 100% zoom.</p>
            <h2>Size checker</h2>
            <p><a href="/pdf-size-checker">PDF size checker</a> presets before/after compress — Gmail 20 MB, portal 5 MB.</p>
            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Compress now</strong> <a href="/pdf/compress" class="alert-link fw-semibold">Compress PDF →</a></div>
            
            
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
            
            
            <h2>Operational deep dive — iPhone</h2>
            <p>Ghostscript compression re-encodes embedded images while vector text usually stays sharp. Phone photos and 600 DPI scans dominate file size — scan at 200–300 DPI grayscale for text proofs before compress saves more than Extreme on blurry source.</p>
            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> Compress PDF workflow — iPhone</figcaption></figure>
            <h2>Double compression trap</h2>
            <p>Compress → merge → compress again softens text twice — <a href="/guides/compress-before-merge-pdf">merge/compress order guide</a>.</p>
            <h2>Portal rejection decode</h2>
            <p><strong>Too large:</strong> compress or <a href="/guides/split-pdf-for-email">split</a>. <strong>Unreadable:</strong> re-scan. <strong>Password:</strong> <a href="/guides/unlock-pdf">unlock</a> first.</p>
            <h2>Research</h2>
            <p><a href="/research/pdf-compression-benchmark">PDF compression benchmark</a> · <a href="/research/attachment-size-limits">Attachment size limits</a>.</p>
            <h2>Free tier</h2>
            <p>Three uses/day — high volume <a href="/Subscription/Plans">plans</a>.</p>
            <h2>Related compression guides</h2>
            <p>Portal compress: <a href="/guides/compress-pdf-gst-portal">GST portal</a> · <a href="/guides/compress-pdf-schengen-visa">Schengen</a> · <a href="/guides/compress-pdf-for-government-forms">government forms</a>.</p>
            <h2>Related Word conversion guides</h2>
            <p>After Word edit re-export: <a href="/guides/pdf-to-word-keep-formatting">keep formatting</a> — then compress for email.</p>
            
            
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
            
            
            <h2>Industry cross-links</h2>
            <p>Lawyers: <a href="/guides/compress-pdf-lawyers">compress for lawyers</a> · Realtors: <a href="/guides/compress-pdf-realtors">realtors</a> · Healthcare: <a href="/guides/compress-pdf-healthcare">healthcare</a> · Accountants: <a href="/guides/compress-pdf-accountants">accountants</a>.</p>

            <h2>Merge and OCR chain</h2>
            <p>OCR'd scans are larger — <a href="/guides/ocr-pdf">OCR PDF</a> then compress. Multi-file: <a href="/guides/merge-pdf-online">merge</a> then <a href="/guides/compress-before-merge-pdf">compress decision</a>.</p>
            
            
            <h2>Failure messages</h2>
            <p><strong>Too large:</strong> compress or split. <strong>Invalid PDF:</strong> re-export source. <strong>Unreadable:</strong> re-scan don't only compress blur.</p>
            <h2>Archive discipline</h2>
            <p>Keep uncompressed master until upload or send succeeds — derivatives are disposable.</p>
            <h2>Compare tools</h2>
            <p><a href="/compare/smallpdf-alternative">Smallpdf</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/adobe-alternative">Adobe</a>.</p>
            
            
            <h2>Device sync workflows</h2>
            <p>Compress on desktop — save to cloud — open on mobile for portal upload — same file hash verify across devices.</p>
            <h2>Antivirus false positives</h2>
            <p>Rare corporate AV blocks download — whitelist ratpdf.com — retry Edge if Chrome extension interferes.</p>
            <h2>Colour stamp preservation</h2>
            <p>Immigration stamps — Less not Extreme — verify red ink visible after compress on portal preview.</p>
            <h2>Wi-Fi vs cellular</h2>
            <p>Large upload on train — may timeout — finish compress download on Wi-Fi before switching to mobile data for portal.</p>
            <h2>Filename discipline</h2>
            <p><code>Passport-Compressed-2026.pdf</code> not <code>document(1).pdf</code> — immigration officers match checklist labels.</p>
            
            
            <h2>Quarterly tool check</h2>
            <p>Portal caps change — re-read upload widget each filing season — compress level that worked last year may need Less this year if portal tightens legibility checks.</p>
            <h2>Handoff to split</h2>
            <p>If still over cap after Less — <a href="/guides/split-pdf-for-email">split for email</a> before giving up on digital submission.</p>
            <h2>Batch naming for accountants</h2>
            <p><code>Client-YYYY-MM-invoice-compressed.pdf</code> — batch compress folder sorts chronologically in AP import.</p>
            <h2>Merge-then-compress SOP</h2>
            <p>Month-end board pack: merge in agenda order → single compress → one email attachment — log final MB in board portal.</p>
            
            
            <h2>Tool chain map</h2>
            <p>OCR → compress → merge → split — pick order by portal rules. See <a href="/guides/compress-before-merge-pdf">compress vs merge</a> and <a href="/guides/pdf-to-word-vs-pdf-to-text">Word vs Text</a>.</p>
            <h2>Upgrade volume</h2>
            <p>Migration and month-end batches: <a href="/Subscription/Plans">subscription plans</a>.</p>
            
            
            <h2>Related compress guides</h2>
            <ul>
            <li><a href="/guides/compress-pdf-guide">Compress PDF guide</a></li>
            <li><a href="/guides/compress-before-merge-pdf">Compress before/after merge</a></li>
            <li><a href="/guides/batch-compress-pdf">Batch compress PDF</a></li>
            <li><a href="/guides/compress-pdf-made-it-larger">Compress made it larger</a></li>
            </ul>
            <p>Research: <a href="/research/attachment-size-limits">Attachment size limits</a> · <a href="/research/pdf-compression-benchmark">PDF compression benchmark</a></p>
            
            
            <h2>Related guides</h2>
            <p>Platform-specific compression (Mac, Windows, mobile), portal upload limits, PDF to Text export, and split-for-email guides round out the compression workflow.</p>
            
            
            <h2>Post-action checklist</h2>
            <ol><li>Output file opens in viewer</li><li>Text selects if required</li><li>Size under portal/email preset</li><li>Master archived</li><li>Correct tool used for next step (text vs Word vs OCR)</li></ol>
            <p>Bookmark the <a href="/guides/pdf-tools">PDF tools guide</a> and <a href="/compare">compare tools</a> for team onboarding — consistent tool choice reduces wrong-output support tickets.</p>
            <p>Re-run size checker after every derivative step — compress, split, or text export — before deleting the previous version from your working folder.</p>
            
            <p class="mt-4"><a href="/pdf/compress" class="btn btn-primary">Compress PDF free</a> · <a href="/compare/smallpdf-alternative">Compare</a></p>
            """;

        private const string CompressPdfOnAndroid = """
            <h2>Compress PDF on Android — Chrome mobile workflow</h2>
            <p>Compress oversized PDFs on Android phone using Chrome — no App Store or desktop install. RatPDF <a href="/pdf/compress">Compress PDF</a> runs in your mobile or desktop browser.</p>
            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> Android phone browser on RatPDF compress upload</figcaption></figure>
            <h2>Real example: Compress job application PDF on Android before Naukri upload</h2>
            <ol>
            <li>Open RatPDF Compress PDF in Chrome.</li>
            <li>Upload PDF from Files/Downloads.</li>
            <li>Choose Recommended — download smaller file.</li>
            <li>Attach to email or portal — verify opens correctly.</li>
            </ol>
            
            <h2>Android workflow</h2>
            <p>Chrome → upload from Downloads or Google Drive picker. Samsung Internet also works. Share sheet to Gmail after download.</p>
            <h2>Second example: college form</h2>
            <p>Marksheet scan 6 MB — compress → 1.5 MB — state PSC portal accepts.</p>
            
            <div class="rp-mid-cta alert alert-primary my-4"><strong>Compress on Android phone</strong> <a href="/pdf/compress" class="alert-link fw-semibold">Compress PDF →</a></div>
            
            <h2>Compression levels</h2>
            <p><strong>Less:</strong> signatures and stamps. <strong>Recommended:</strong> default. <strong>Extreme:</strong> last resort — verify legibility.</p>
            <h2>Pre-upload checklist</h2>
            <ol>
            <li><a href="/pdf-size-checker">PDF size checker</a> preset</li>
            <li>Rotate scans upright</li>
            <li>One compress pass after merge</li>
            <li>Keep master until upload succeeds</li>
            </ol>
            <h2>Email variants</h2>
            <p><a href="/guides/compress-pdf-for-gmail">Gmail</a> · <a href="/guides/compress-pdf-for-outlook">Outlook</a> · <a href="/guides/compress-pdf-for-whatsapp">WhatsApp</a>.</p>
            <h2>Immigration cross-links</h2>
            <p><a href="/guides/compress-pdf-for-visa-application">Visa application</a> · <a href="/guides/compress-pdf-schengen-visa">Schengen</a> · <a href="/guides/compress-pdf-digilocker">DigiLocker</a>.</p>
            <h2>Industry guides</h2>
            <p><a href="/guides/compress-pdf-lawyers">Lawyers</a> · <a href="/guides/compress-pdf-accountants">Accountants</a> · <a href="/guides/compress-pdf-efiling">E-filing</a>.</p>
            
            
            <h2>Ghostscript levels recap</h2>
            <p><strong>Less:</strong> legal scans and signatures. <strong>Recommended:</strong> email and portals. <strong>Extreme:</strong> last resort — verify text at 100% zoom.</p>
            <h2>Size checker</h2>
            <p><a href="/pdf-size-checker">PDF size checker</a> presets before/after compress — Gmail 20 MB, portal 5 MB.</p>
            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Compress now</strong> <a href="/pdf/compress" class="alert-link fw-semibold">Compress PDF →</a></div>
            
            
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
            
            
            <h2>Operational deep dive — Android phone</h2>
            <p>Ghostscript compression re-encodes embedded images while vector text usually stays sharp. Phone photos and 600 DPI scans dominate file size — scan at 200–300 DPI grayscale for text proofs before compress saves more than Extreme on blurry source.</p>
            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> Compress PDF workflow — Android phone</figcaption></figure>
            <h2>Double compression trap</h2>
            <p>Compress → merge → compress again softens text twice — <a href="/guides/compress-before-merge-pdf">merge/compress order guide</a>.</p>
            <h2>Portal rejection decode</h2>
            <p><strong>Too large:</strong> compress or <a href="/guides/split-pdf-for-email">split</a>. <strong>Unreadable:</strong> re-scan. <strong>Password:</strong> <a href="/guides/unlock-pdf">unlock</a> first.</p>
            <h2>Research</h2>
            <p><a href="/research/pdf-compression-benchmark">PDF compression benchmark</a> · <a href="/research/attachment-size-limits">Attachment size limits</a>.</p>
            <h2>Free tier</h2>
            <p>Three uses/day — high volume <a href="/Subscription/Plans">plans</a>.</p>
            <h2>Related compression guides</h2>
            <p>Portal compress: <a href="/guides/compress-pdf-gst-portal">GST portal</a> · <a href="/guides/compress-pdf-schengen-visa">Schengen</a> · <a href="/guides/compress-pdf-for-government-forms">government forms</a>.</p>
            <h2>Related Word conversion guides</h2>
            <p>After Word edit re-export: <a href="/guides/pdf-to-word-keep-formatting">keep formatting</a> — then compress for email.</p>
            
            
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
            
            
            <h2>Industry cross-links</h2>
            <p>Lawyers: <a href="/guides/compress-pdf-lawyers">compress for lawyers</a> · Realtors: <a href="/guides/compress-pdf-realtors">realtors</a> · Healthcare: <a href="/guides/compress-pdf-healthcare">healthcare</a> · Accountants: <a href="/guides/compress-pdf-accountants">accountants</a>.</p>

            <h2>Merge and OCR chain</h2>
            <p>OCR'd scans are larger — <a href="/guides/ocr-pdf">OCR PDF</a> then compress. Multi-file: <a href="/guides/merge-pdf-online">merge</a> then <a href="/guides/compress-before-merge-pdf">compress decision</a>.</p>
            
            
            <h2>Failure messages</h2>
            <p><strong>Too large:</strong> compress or split. <strong>Invalid PDF:</strong> re-export source. <strong>Unreadable:</strong> re-scan don't only compress blur.</p>
            <h2>Archive discipline</h2>
            <p>Keep uncompressed master until upload or send succeeds — derivatives are disposable.</p>
            <h2>Compare tools</h2>
            <p><a href="/compare/smallpdf-alternative">Smallpdf</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/adobe-alternative">Adobe</a>.</p>
            
            
            <h2>Device sync workflows</h2>
            <p>Compress on desktop — save to cloud — open on mobile for portal upload — same file hash verify across devices.</p>
            <h2>Antivirus false positives</h2>
            <p>Rare corporate AV blocks download — whitelist ratpdf.com — retry Edge if Chrome extension interferes.</p>
            <h2>Colour stamp preservation</h2>
            <p>Immigration stamps — Less not Extreme — verify red ink visible after compress on portal preview.</p>
            <h2>Wi-Fi vs cellular</h2>
            <p>Large upload on train — may timeout — finish compress download on Wi-Fi before switching to mobile data for portal.</p>
            <h2>Filename discipline</h2>
            <p><code>Passport-Compressed-2026.pdf</code> not <code>document(1).pdf</code> — immigration officers match checklist labels.</p>
            
            
            <h2>Quarterly tool check</h2>
            <p>Portal caps change — re-read upload widget each filing season — compress level that worked last year may need Less this year if portal tightens legibility checks.</p>
            <h2>Handoff to split</h2>
            <p>If still over cap after Less — <a href="/guides/split-pdf-for-email">split for email</a> before giving up on digital submission.</p>
            <h2>Batch naming for accountants</h2>
            <p><code>Client-YYYY-MM-invoice-compressed.pdf</code> — batch compress folder sorts chronologically in AP import.</p>
            <h2>Merge-then-compress SOP</h2>
            <p>Month-end board pack: merge in agenda order → single compress → one email attachment — log final MB in board portal.</p>
            
            
            <h2>Tool chain map</h2>
            <p>OCR → compress → merge → split — pick order by portal rules. See <a href="/guides/compress-before-merge-pdf">compress vs merge</a> and <a href="/guides/pdf-to-word-vs-pdf-to-text">Word vs Text</a>.</p>
            <h2>Upgrade volume</h2>
            <p>Migration and month-end batches: <a href="/Subscription/Plans">subscription plans</a>.</p>
            
            
            <h2>Related compress guides</h2>
            <ul>
            <li><a href="/guides/compress-pdf-guide">Compress PDF guide</a></li>
            <li><a href="/guides/compress-before-merge-pdf">Compress before/after merge</a></li>
            <li><a href="/guides/batch-compress-pdf">Batch compress PDF</a></li>
            <li><a href="/guides/compress-pdf-made-it-larger">Compress made it larger</a></li>
            </ul>
            <p>Research: <a href="/research/attachment-size-limits">Attachment size limits</a> · <a href="/research/pdf-compression-benchmark">PDF compression benchmark</a></p>
            
            
            <h2>Related guides</h2>
            <p>Platform-specific compression (Mac, Windows, mobile), portal upload limits, PDF to Text export, and split-for-email guides round out the compression workflow.</p>
            
            
            <h2>Post-action checklist</h2>
            <ol><li>Output file opens in viewer</li><li>Text selects if required</li><li>Size under portal/email preset</li><li>Master archived</li><li>Correct tool used for next step (text vs Word vs OCR)</li></ol>
            <p>Bookmark the <a href="/guides/pdf-tools">PDF tools guide</a> and <a href="/compare">compare tools</a> for team onboarding — consistent tool choice reduces wrong-output support tickets.</p>
            <p>Re-run size checker after every derivative step — compress, split, or text export — before deleting the previous version from your working folder.</p>
            
            <p class="mt-4"><a href="/pdf/compress" class="btn btn-primary">Compress PDF free</a> · <a href="/compare/smallpdf-alternative">Compare</a></p>
            """;

        private const string CompressPdfIncometax = """
            <h2>Compress PDF for Income Tax portal — ITR upload fix</h2>
            <p>Shrink PDFs for <strong>Income Tax e-filing (India)</strong> uploads — typical cap 500 KB–5 MB per annexure. RatPDF <a href="/pdf/compress">Compress PDF</a> with Ghostscript.</p>
            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> Income Tax e-filing (India) upload success after compress</figcaption></figure>
            <h2>Real example: Form 16 scan 4.8 MB → Recommended → 1.2 MB</h2>
            <ol>
            <li>Scan 200 DPI grayscale if source is phone photo.</li>
            <li>Recommended compress — verify IDs readable at zoom.</li>
            <li>Upload in portal session before timeout.</li>
            </ol>
            
            <h2>ITR annexure types</h2>
            <p>Form 16, interest certificates, capital gains schedules — each slot separate — compress per file not one merged unless utility allows.</p>
            <h2>Verification before submit</h2>
            <p>PAN and assessment year readable at zoom — Less compression on signed Form 16.</p>
            <p>Govt forms: <a href="/guides/compress-pdf-for-government-forms">government forms compress</a>.</p>
            
            <div class="rp-mid-cta alert alert-primary my-4"><strong>Fit Income Tax e-filing (India) cap</strong> <a href="/pdf/compress" class="alert-link fw-semibold">Compress PDF →</a></div>
            
            <h2>Compression levels</h2>
            <p><strong>Less:</strong> signatures and stamps. <strong>Recommended:</strong> default. <strong>Extreme:</strong> last resort — verify legibility.</p>
            <h2>Pre-upload checklist</h2>
            <ol>
            <li><a href="/pdf-size-checker">PDF size checker</a> preset</li>
            <li>Rotate scans upright</li>
            <li>One compress pass after merge</li>
            <li>Keep master until upload succeeds</li>
            </ol>
            <h2>Email variants</h2>
            <p><a href="/guides/compress-pdf-for-gmail">Gmail</a> · <a href="/guides/compress-pdf-for-outlook">Outlook</a> · <a href="/guides/compress-pdf-for-whatsapp">WhatsApp</a>.</p>
            <h2>Immigration cross-links</h2>
            <p><a href="/guides/compress-pdf-for-visa-application">Visa application</a> · <a href="/guides/compress-pdf-schengen-visa">Schengen</a> · <a href="/guides/compress-pdf-digilocker">DigiLocker</a>.</p>
            <h2>Industry guides</h2>
            <p><a href="/guides/compress-pdf-lawyers">Lawyers</a> · <a href="/guides/compress-pdf-accountants">Accountants</a> · <a href="/guides/compress-pdf-efiling">E-filing</a>.</p>
            
            
            <h2>Ghostscript levels recap</h2>
            <p><strong>Less:</strong> legal scans and signatures. <strong>Recommended:</strong> email and portals. <strong>Extreme:</strong> last resort — verify text at 100% zoom.</p>
            <h2>Size checker</h2>
            <p><a href="/pdf-size-checker">PDF size checker</a> presets before/after compress — Gmail 20 MB, portal 5 MB.</p>
            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Compress now</strong> <a href="/pdf/compress" class="alert-link fw-semibold">Compress PDF →</a></div>
            
            
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
            
            
            <h2>Operational deep dive — Income Tax e-filing (India)</h2>
            <p>Ghostscript compression re-encodes embedded images while vector text usually stays sharp. Phone photos and 600 DPI scans dominate file size — scan at 200–300 DPI grayscale for text proofs before compress saves more than Extreme on blurry source.</p>
            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> Compress PDF workflow — Income Tax e-filing (India)</figcaption></figure>
            <h2>Double compression trap</h2>
            <p>Compress → merge → compress again softens text twice — <a href="/guides/compress-before-merge-pdf">merge/compress order guide</a>.</p>
            <h2>Portal rejection decode</h2>
            <p><strong>Too large:</strong> compress or <a href="/guides/split-pdf-for-email">split</a>. <strong>Unreadable:</strong> re-scan. <strong>Password:</strong> <a href="/guides/unlock-pdf">unlock</a> first.</p>
            <h2>Research</h2>
            <p><a href="/research/pdf-compression-benchmark">PDF compression benchmark</a> · <a href="/research/attachment-size-limits">Attachment size limits</a>.</p>
            <h2>Free tier</h2>
            <p>Three uses/day — high volume <a href="/Subscription/Plans">plans</a>.</p>
            <h2>Related compression guides</h2>
            <p>Portal compress: <a href="/guides/compress-pdf-gst-portal">GST portal</a> · <a href="/guides/compress-pdf-schengen-visa">Schengen</a> · <a href="/guides/compress-pdf-for-government-forms">government forms</a>.</p>
            <h2>Related Word conversion guides</h2>
            <p>After Word edit re-export: <a href="/guides/pdf-to-word-keep-formatting">keep formatting</a> — then compress for email.</p>
            
            
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
            
            
            <h2>Industry cross-links</h2>
            <p>Lawyers: <a href="/guides/compress-pdf-lawyers">compress for lawyers</a> · Realtors: <a href="/guides/compress-pdf-realtors">realtors</a> · Healthcare: <a href="/guides/compress-pdf-healthcare">healthcare</a> · Accountants: <a href="/guides/compress-pdf-accountants">accountants</a>.</p>

            <h2>Merge and OCR chain</h2>
            <p>OCR'd scans are larger — <a href="/guides/ocr-pdf">OCR PDF</a> then compress. Multi-file: <a href="/guides/merge-pdf-online">merge</a> then <a href="/guides/compress-before-merge-pdf">compress decision</a>.</p>
            
            
            <h2>Failure messages</h2>
            <p><strong>Too large:</strong> compress or split. <strong>Invalid PDF:</strong> re-export source. <strong>Unreadable:</strong> re-scan don't only compress blur.</p>
            <h2>Archive discipline</h2>
            <p>Keep uncompressed master until upload or send succeeds — derivatives are disposable.</p>
            <h2>Compare tools</h2>
            <p><a href="/compare/smallpdf-alternative">Smallpdf</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/adobe-alternative">Adobe</a>.</p>
            
            
            <h2>Device sync workflows</h2>
            <p>Compress on desktop — save to cloud — open on mobile for portal upload — same file hash verify across devices.</p>
            <h2>Antivirus false positives</h2>
            <p>Rare corporate AV blocks download — whitelist ratpdf.com — retry Edge if Chrome extension interferes.</p>
            <h2>Colour stamp preservation</h2>
            <p>Immigration stamps — Less not Extreme — verify red ink visible after compress on portal preview.</p>
            <h2>Wi-Fi vs cellular</h2>
            <p>Large upload on train — may timeout — finish compress download on Wi-Fi before switching to mobile data for portal.</p>
            <h2>Filename discipline</h2>
            <p><code>Passport-Compressed-2026.pdf</code> not <code>document(1).pdf</code> — immigration officers match checklist labels.</p>
            
            
            <h2>Quarterly tool check</h2>
            <p>Portal caps change — re-read upload widget each filing season — compress level that worked last year may need Less this year if portal tightens legibility checks.</p>
            <h2>Handoff to split</h2>
            <p>If still over cap after Less — <a href="/guides/split-pdf-for-email">split for email</a> before giving up on digital submission.</p>
            <h2>Batch naming for accountants</h2>
            <p><code>Client-YYYY-MM-invoice-compressed.pdf</code> — batch compress folder sorts chronologically in AP import.</p>
            <h2>Merge-then-compress SOP</h2>
            <p>Month-end board pack: merge in agenda order → single compress → one email attachment — log final MB in board portal.</p>
            
            
            <h2>Tool chain map</h2>
            <p>OCR → compress → merge → split — pick order by portal rules. See <a href="/guides/compress-before-merge-pdf">compress vs merge</a> and <a href="/guides/pdf-to-word-vs-pdf-to-text">Word vs Text</a>.</p>
            <h2>Upgrade volume</h2>
            <p>Migration and month-end batches: <a href="/Subscription/Plans">subscription plans</a>.</p>
            
            
            <h2>Related compress guides</h2>
            <ul>
            <li><a href="/guides/compress-pdf-guide">Compress PDF guide</a></li>
            <li><a href="/guides/compress-before-merge-pdf">Compress before/after merge</a></li>
            <li><a href="/guides/batch-compress-pdf">Batch compress PDF</a></li>
            <li><a href="/guides/compress-pdf-made-it-larger">Compress made it larger</a></li>
            </ul>
            <p>Research: <a href="/research/attachment-size-limits">Attachment size limits</a> · <a href="/research/pdf-compression-benchmark">PDF compression benchmark</a></p>
            
            
            <h2>Related guides</h2>
            <p>Platform-specific compression (Mac, Windows, mobile), portal upload limits, PDF to Text export, and split-for-email guides round out the compression workflow.</p>
            
            
            <h2>Post-action checklist</h2>
            <ol><li>Output file opens in viewer</li><li>Text selects if required</li><li>Size under portal/email preset</li><li>Master archived</li><li>Correct tool used for next step (text vs Word vs OCR)</li></ol>
            <p>Bookmark the <a href="/guides/pdf-tools">PDF tools guide</a> and <a href="/compare">compare tools</a> for team onboarding — consistent tool choice reduces wrong-output support tickets.</p>
            <p>Re-run size checker after every derivative step — compress, split, or text export — before deleting the previous version from your working folder.</p>
            
            <p class="mt-4"><a href="/pdf/compress" class="btn btn-primary">Compress PDF free</a> · <a href="/Subscription/Plans">Upgrade</a></p>
            """;

        private const string CompressPdfIrctc = """
            <h2>Compress PDF for IRCTC — train booking document upload</h2>
            <p>Shrink PDFs for <strong>IRCTC / rail concession</strong> uploads — typical cap ~1–2 MB ID proofs. RatPDF <a href="/pdf/compress">Compress PDF</a> with Ghostscript.</p>
            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> IRCTC / rail concession upload success after compress</figcaption></figure>
            <h2>Real example: Senior citizen card scan fits upload slot after compress</h2>
            <ol>
            <li>Scan 200 DPI grayscale if source is phone photo.</li>
            <li>Recommended compress — verify IDs readable at zoom.</li>
            <li>Upload in portal session before timeout.</li>
            </ol>
            
            <h2>IRCTC document slots</h2>
            <p>Concession cards, ID proofs — often strict size — phone photo scans need 200 DPI grayscale before compress.</p>
            <h2>Booking session timeout</h2>
            <p>Prepare compressed PDFs before opening tatkal window — upload fails mid-payment if you compress live.</p>
            
            <div class="rp-mid-cta alert alert-primary my-4"><strong>Fit IRCTC / rail concession cap</strong> <a href="/pdf/compress" class="alert-link fw-semibold">Compress PDF →</a></div>
            
            <h2>Compression levels</h2>
            <p><strong>Less:</strong> signatures and stamps. <strong>Recommended:</strong> default. <strong>Extreme:</strong> last resort — verify legibility.</p>
            <h2>Pre-upload checklist</h2>
            <ol>
            <li><a href="/pdf-size-checker">PDF size checker</a> preset</li>
            <li>Rotate scans upright</li>
            <li>One compress pass after merge</li>
            <li>Keep master until upload succeeds</li>
            </ol>
            <h2>Email variants</h2>
            <p><a href="/guides/compress-pdf-for-gmail">Gmail</a> · <a href="/guides/compress-pdf-for-outlook">Outlook</a> · <a href="/guides/compress-pdf-for-whatsapp">WhatsApp</a>.</p>
            <h2>Immigration cross-links</h2>
            <p><a href="/guides/compress-pdf-for-visa-application">Visa application</a> · <a href="/guides/compress-pdf-schengen-visa">Schengen</a> · <a href="/guides/compress-pdf-digilocker">DigiLocker</a>.</p>
            <h2>Industry guides</h2>
            <p><a href="/guides/compress-pdf-lawyers">Lawyers</a> · <a href="/guides/compress-pdf-accountants">Accountants</a> · <a href="/guides/compress-pdf-efiling">E-filing</a>.</p>
            
            
            <h2>Ghostscript levels recap</h2>
            <p><strong>Less:</strong> legal scans and signatures. <strong>Recommended:</strong> email and portals. <strong>Extreme:</strong> last resort — verify text at 100% zoom.</p>
            <h2>Size checker</h2>
            <p><a href="/pdf-size-checker">PDF size checker</a> presets before/after compress — Gmail 20 MB, portal 5 MB.</p>
            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Compress now</strong> <a href="/pdf/compress" class="alert-link fw-semibold">Compress PDF →</a></div>
            
            
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
            
            
            <h2>Operational deep dive — IRCTC / rail concession</h2>
            <p>Ghostscript compression re-encodes embedded images while vector text usually stays sharp. Phone photos and 600 DPI scans dominate file size — scan at 200–300 DPI grayscale for text proofs before compress saves more than Extreme on blurry source.</p>
            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> Compress PDF workflow — IRCTC / rail concession</figcaption></figure>
            <h2>Double compression trap</h2>
            <p>Compress → merge → compress again softens text twice — <a href="/guides/compress-before-merge-pdf">merge/compress order guide</a>.</p>
            <h2>Portal rejection decode</h2>
            <p><strong>Too large:</strong> compress or <a href="/guides/split-pdf-for-email">split</a>. <strong>Unreadable:</strong> re-scan. <strong>Password:</strong> <a href="/guides/unlock-pdf">unlock</a> first.</p>
            <h2>Research</h2>
            <p><a href="/research/pdf-compression-benchmark">PDF compression benchmark</a> · <a href="/research/attachment-size-limits">Attachment size limits</a>.</p>
            <h2>Free tier</h2>
            <p>Three uses/day — high volume <a href="/Subscription/Plans">plans</a>.</p>
            <h2>Related compression guides</h2>
            <p>Portal compress: <a href="/guides/compress-pdf-gst-portal">GST portal</a> · <a href="/guides/compress-pdf-schengen-visa">Schengen</a> · <a href="/guides/compress-pdf-for-government-forms">government forms</a>.</p>
            <h2>Related Word conversion guides</h2>
            <p>After Word edit re-export: <a href="/guides/pdf-to-word-keep-formatting">keep formatting</a> — then compress for email.</p>
            
            
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
            
            
            <h2>Industry cross-links</h2>
            <p>Lawyers: <a href="/guides/compress-pdf-lawyers">compress for lawyers</a> · Realtors: <a href="/guides/compress-pdf-realtors">realtors</a> · Healthcare: <a href="/guides/compress-pdf-healthcare">healthcare</a> · Accountants: <a href="/guides/compress-pdf-accountants">accountants</a>.</p>

            <h2>Merge and OCR chain</h2>
            <p>OCR'd scans are larger — <a href="/guides/ocr-pdf">OCR PDF</a> then compress. Multi-file: <a href="/guides/merge-pdf-online">merge</a> then <a href="/guides/compress-before-merge-pdf">compress decision</a>.</p>
            
            
            <h2>Failure messages</h2>
            <p><strong>Too large:</strong> compress or split. <strong>Invalid PDF:</strong> re-export source. <strong>Unreadable:</strong> re-scan don't only compress blur.</p>
            <h2>Archive discipline</h2>
            <p>Keep uncompressed master until upload or send succeeds — derivatives are disposable.</p>
            <h2>Compare tools</h2>
            <p><a href="/compare/smallpdf-alternative">Smallpdf</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/adobe-alternative">Adobe</a>.</p>
            
            
            <h2>Device sync workflows</h2>
            <p>Compress on desktop — save to cloud — open on mobile for portal upload — same file hash verify across devices.</p>
            <h2>Antivirus false positives</h2>
            <p>Rare corporate AV blocks download — whitelist ratpdf.com — retry Edge if Chrome extension interferes.</p>
            <h2>Colour stamp preservation</h2>
            <p>Immigration stamps — Less not Extreme — verify red ink visible after compress on portal preview.</p>
            <h2>Wi-Fi vs cellular</h2>
            <p>Large upload on train — may timeout — finish compress download on Wi-Fi before switching to mobile data for portal.</p>
            <h2>Filename discipline</h2>
            <p><code>Passport-Compressed-2026.pdf</code> not <code>document(1).pdf</code> — immigration officers match checklist labels.</p>
            
            
            <h2>Quarterly tool check</h2>
            <p>Portal caps change — re-read upload widget each filing season — compress level that worked last year may need Less this year if portal tightens legibility checks.</p>
            <h2>Handoff to split</h2>
            <p>If still over cap after Less — <a href="/guides/split-pdf-for-email">split for email</a> before giving up on digital submission.</p>
            <h2>Batch naming for accountants</h2>
            <p><code>Client-YYYY-MM-invoice-compressed.pdf</code> — batch compress folder sorts chronologically in AP import.</p>
            <h2>Merge-then-compress SOP</h2>
            <p>Month-end board pack: merge in agenda order → single compress → one email attachment — log final MB in board portal.</p>
            
            
            <h2>Tool chain map</h2>
            <p>OCR → compress → merge → split — pick order by portal rules. See <a href="/guides/compress-before-merge-pdf">compress vs merge</a> and <a href="/guides/pdf-to-word-vs-pdf-to-text">Word vs Text</a>.</p>
            <h2>Upgrade volume</h2>
            <p>Migration and month-end batches: <a href="/Subscription/Plans">subscription plans</a>.</p>
            
            
            <h2>Related compress guides</h2>
            <ul>
            <li><a href="/guides/compress-pdf-guide">Compress PDF guide</a></li>
            <li><a href="/guides/compress-before-merge-pdf">Compress before/after merge</a></li>
            <li><a href="/guides/batch-compress-pdf">Batch compress PDF</a></li>
            <li><a href="/guides/compress-pdf-made-it-larger">Compress made it larger</a></li>
            </ul>
            <p>Research: <a href="/research/attachment-size-limits">Attachment size limits</a> · <a href="/research/pdf-compression-benchmark">PDF compression benchmark</a></p>
            
            
            <h2>Related guides</h2>
            <p>Platform-specific compression (Mac, Windows, mobile), portal upload limits, PDF to Text export, and split-for-email guides round out the compression workflow.</p>
            
            
            <h2>Post-action checklist</h2>
            <ol><li>Output file opens in viewer</li><li>Text selects if required</li><li>Size under portal/email preset</li><li>Master archived</li><li>Correct tool used for next step (text vs Word vs OCR)</li></ol>
            <p>Bookmark the <a href="/guides/pdf-tools">PDF tools guide</a> and <a href="/compare">compare tools</a> for team onboarding — consistent tool choice reduces wrong-output support tickets.</p>
            <p>Re-run size checker after every derivative step — compress, split, or text export — before deleting the previous version from your working folder.</p>
            
            <p class="mt-4"><a href="/pdf/compress" class="btn btn-primary">Compress PDF free</a> · <a href="/Subscription/Plans">Upgrade</a></p>
            """;

        private const string CompressPdfHomeAffairsAustralia = """
            <h2>Compress PDF for Australian Home Affairs — ImmiAccount upload</h2>
            <p>Shrink PDFs for <strong>ImmiAccount</strong> uploads — typical cap ~5 MB per file typical. RatPDF <a href="/pdf/compress">Compress PDF</a> with Ghostscript.</p>
            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> ImmiAccount upload success after compress</figcaption></figure>
            <h2>Real example: Partner visa police certificate bundle under cap</h2>
            <ol>
            <li>Scan 200 DPI grayscale if source is phone photo.</li>
            <li>Recommended compress — verify IDs readable at zoom.</li>
            <li>Upload in portal session before timeout.</li>
            </ol>
            
            <h2>ImmiAccount bundle discipline</h2>
            <p>Merge related pages only when checklist allows — otherwise per-document upload. Police certificates — Less compression preserves stamps.</p>
            <h2>UK comparison</h2>
            <p><a href="/guides/compress-pdf-ukvi">UKVI compress</a> · Schengen: <a href="/guides/compress-pdf-schengen-visa">Schengen</a>.</p>
            
            <div class="rp-mid-cta alert alert-primary my-4"><strong>Fit ImmiAccount cap</strong> <a href="/pdf/compress" class="alert-link fw-semibold">Compress PDF →</a></div>
            
            <h2>Compression levels</h2>
            <p><strong>Less:</strong> signatures and stamps. <strong>Recommended:</strong> default. <strong>Extreme:</strong> last resort — verify legibility.</p>
            <h2>Pre-upload checklist</h2>
            <ol>
            <li><a href="/pdf-size-checker">PDF size checker</a> preset</li>
            <li>Rotate scans upright</li>
            <li>One compress pass after merge</li>
            <li>Keep master until upload succeeds</li>
            </ol>
            <h2>Email variants</h2>
            <p><a href="/guides/compress-pdf-for-gmail">Gmail</a> · <a href="/guides/compress-pdf-for-outlook">Outlook</a> · <a href="/guides/compress-pdf-for-whatsapp">WhatsApp</a>.</p>
            <h2>Immigration cross-links</h2>
            <p><a href="/guides/compress-pdf-for-visa-application">Visa application</a> · <a href="/guides/compress-pdf-schengen-visa">Schengen</a> · <a href="/guides/compress-pdf-digilocker">DigiLocker</a>.</p>
            <h2>Industry guides</h2>
            <p><a href="/guides/compress-pdf-lawyers">Lawyers</a> · <a href="/guides/compress-pdf-accountants">Accountants</a> · <a href="/guides/compress-pdf-efiling">E-filing</a>.</p>
            
            
            <h2>Ghostscript levels recap</h2>
            <p><strong>Less:</strong> legal scans and signatures. <strong>Recommended:</strong> email and portals. <strong>Extreme:</strong> last resort — verify text at 100% zoom.</p>
            <h2>Size checker</h2>
            <p><a href="/pdf-size-checker">PDF size checker</a> presets before/after compress — Gmail 20 MB, portal 5 MB.</p>
            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Compress now</strong> <a href="/pdf/compress" class="alert-link fw-semibold">Compress PDF →</a></div>
            
            
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
            
            
            <h2>Operational deep dive — ImmiAccount</h2>
            <p>Ghostscript compression re-encodes embedded images while vector text usually stays sharp. Phone photos and 600 DPI scans dominate file size — scan at 200–300 DPI grayscale for text proofs before compress saves more than Extreme on blurry source.</p>
            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> Compress PDF workflow — ImmiAccount</figcaption></figure>
            <h2>Double compression trap</h2>
            <p>Compress → merge → compress again softens text twice — <a href="/guides/compress-before-merge-pdf">merge/compress order guide</a>.</p>
            <h2>Portal rejection decode</h2>
            <p><strong>Too large:</strong> compress or <a href="/guides/split-pdf-for-email">split</a>. <strong>Unreadable:</strong> re-scan. <strong>Password:</strong> <a href="/guides/unlock-pdf">unlock</a> first.</p>
            <h2>Research</h2>
            <p><a href="/research/pdf-compression-benchmark">PDF compression benchmark</a> · <a href="/research/attachment-size-limits">Attachment size limits</a>.</p>
            <h2>Free tier</h2>
            <p>Three uses/day — high volume <a href="/Subscription/Plans">plans</a>.</p>
            <h2>Related compression guides</h2>
            <p>Portal compress: <a href="/guides/compress-pdf-gst-portal">GST portal</a> · <a href="/guides/compress-pdf-schengen-visa">Schengen</a> · <a href="/guides/compress-pdf-for-government-forms">government forms</a>.</p>
            <h2>Related Word conversion guides</h2>
            <p>After Word edit re-export: <a href="/guides/pdf-to-word-keep-formatting">keep formatting</a> — then compress for email.</p>
            
            
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
            
            
            <h2>Industry cross-links</h2>
            <p>Lawyers: <a href="/guides/compress-pdf-lawyers">compress for lawyers</a> · Realtors: <a href="/guides/compress-pdf-realtors">realtors</a> · Healthcare: <a href="/guides/compress-pdf-healthcare">healthcare</a> · Accountants: <a href="/guides/compress-pdf-accountants">accountants</a>.</p>

            <h2>Merge and OCR chain</h2>
            <p>OCR'd scans are larger — <a href="/guides/ocr-pdf">OCR PDF</a> then compress. Multi-file: <a href="/guides/merge-pdf-online">merge</a> then <a href="/guides/compress-before-merge-pdf">compress decision</a>.</p>
            
            
            <h2>Failure messages</h2>
            <p><strong>Too large:</strong> compress or split. <strong>Invalid PDF:</strong> re-export source. <strong>Unreadable:</strong> re-scan don't only compress blur.</p>
            <h2>Archive discipline</h2>
            <p>Keep uncompressed master until upload or send succeeds — derivatives are disposable.</p>
            <h2>Compare tools</h2>
            <p><a href="/compare/smallpdf-alternative">Smallpdf</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/adobe-alternative">Adobe</a>.</p>
            
            
            <h2>Device sync workflows</h2>
            <p>Compress on desktop — save to cloud — open on mobile for portal upload — same file hash verify across devices.</p>
            <h2>Antivirus false positives</h2>
            <p>Rare corporate AV blocks download — whitelist ratpdf.com — retry Edge if Chrome extension interferes.</p>
            <h2>Colour stamp preservation</h2>
            <p>Immigration stamps — Less not Extreme — verify red ink visible after compress on portal preview.</p>
            <h2>Wi-Fi vs cellular</h2>
            <p>Large upload on train — may timeout — finish compress download on Wi-Fi before switching to mobile data for portal.</p>
            <h2>Filename discipline</h2>
            <p><code>Passport-Compressed-2026.pdf</code> not <code>document(1).pdf</code> — immigration officers match checklist labels.</p>
            
            
            <h2>Quarterly tool check</h2>
            <p>Portal caps change — re-read upload widget each filing season — compress level that worked last year may need Less this year if portal tightens legibility checks.</p>
            <h2>Handoff to split</h2>
            <p>If still over cap after Less — <a href="/guides/split-pdf-for-email">split for email</a> before giving up on digital submission.</p>
            <h2>Batch naming for accountants</h2>
            <p><code>Client-YYYY-MM-invoice-compressed.pdf</code> — batch compress folder sorts chronologically in AP import.</p>
            <h2>Merge-then-compress SOP</h2>
            <p>Month-end board pack: merge in agenda order → single compress → one email attachment — log final MB in board portal.</p>
            
            
            <h2>Tool chain map</h2>
            <p>OCR → compress → merge → split — pick order by portal rules. See <a href="/guides/compress-before-merge-pdf">compress vs merge</a> and <a href="/guides/pdf-to-word-vs-pdf-to-text">Word vs Text</a>.</p>
            <h2>Upgrade volume</h2>
            <p>Migration and month-end batches: <a href="/Subscription/Plans">subscription plans</a>.</p>
            
            
            <h2>Related compress guides</h2>
            <ul>
            <li><a href="/guides/compress-pdf-guide">Compress PDF guide</a></li>
            <li><a href="/guides/compress-before-merge-pdf">Compress before/after merge</a></li>
            <li><a href="/guides/batch-compress-pdf">Batch compress PDF</a></li>
            <li><a href="/guides/compress-pdf-made-it-larger">Compress made it larger</a></li>
            </ul>
            <p>Research: <a href="/research/attachment-size-limits">Attachment size limits</a> · <a href="/research/pdf-compression-benchmark">PDF compression benchmark</a></p>
            
            
            <h2>Related guides</h2>
            <p>Platform-specific compression (Mac, Windows, mobile), portal upload limits, PDF to Text export, and split-for-email guides round out the compression workflow.</p>
            
            
            <h2>Post-action checklist</h2>
            <ol><li>Output file opens in viewer</li><li>Text selects if required</li><li>Size under portal/email preset</li><li>Master archived</li><li>Correct tool used for next step (text vs Word vs OCR)</li></ol>
            <p>Bookmark the <a href="/guides/pdf-tools">PDF tools guide</a> and <a href="/compare">compare tools</a> for team onboarding — consistent tool choice reduces wrong-output support tickets.</p>
            <p>Re-run size checker after every derivative step — compress, split, or text export — before deleting the previous version from your working folder.</p>
            
            <p class="mt-4"><a href="/pdf/compress" class="btn btn-primary">Compress PDF free</a> · <a href="/Subscription/Plans">Upgrade</a></p>
            """;

        private const string CompressPdfImmigrationCanada = """
            <h2>Compress PDF for IRCC Canada — immigration upload fix</h2>
            <p>Shrink PDFs for <strong>IRCC / GCKey</strong> uploads — typical cap ~4 MB per document. RatPDF <a href="/pdf/compress">Compress PDF</a> with Ghostscript.</p>
            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> IRCC / GCKey upload success after compress</figcaption></figure>
            <h2>Real example: Work permit support letter compressed for upload</h2>
            <ol>
            <li>Scan 200 DPI grayscale if source is phone photo.</li>
            <li>Recommended compress — verify IDs readable at zoom.</li>
            <li>Upload in portal session before timeout.</li>
            </ol>
            
            <h2>IRCC upload hygiene</h2>
            <p>GCKey applications — filename English only — PDF not password locked. Merge employment letters then compress once if one slot.</p>
            <h2>Proof of funds</h2>
            <p>Bank statements — digital download may need no compress; scans need Recommended.</p>
            
            <div class="rp-mid-cta alert alert-primary my-4"><strong>Fit IRCC / GCKey cap</strong> <a href="/pdf/compress" class="alert-link fw-semibold">Compress PDF →</a></div>
            
            <h2>Compression levels</h2>
            <p><strong>Less:</strong> signatures and stamps. <strong>Recommended:</strong> default. <strong>Extreme:</strong> last resort — verify legibility.</p>
            <h2>Pre-upload checklist</h2>
            <ol>
            <li><a href="/pdf-size-checker">PDF size checker</a> preset</li>
            <li>Rotate scans upright</li>
            <li>One compress pass after merge</li>
            <li>Keep master until upload succeeds</li>
            </ol>
            <h2>Email variants</h2>
            <p><a href="/guides/compress-pdf-for-gmail">Gmail</a> · <a href="/guides/compress-pdf-for-outlook">Outlook</a> · <a href="/guides/compress-pdf-for-whatsapp">WhatsApp</a>.</p>
            <h2>Immigration cross-links</h2>
            <p><a href="/guides/compress-pdf-for-visa-application">Visa application</a> · <a href="/guides/compress-pdf-schengen-visa">Schengen</a> · <a href="/guides/compress-pdf-digilocker">DigiLocker</a>.</p>
            <h2>Industry guides</h2>
            <p><a href="/guides/compress-pdf-lawyers">Lawyers</a> · <a href="/guides/compress-pdf-accountants">Accountants</a> · <a href="/guides/compress-pdf-efiling">E-filing</a>.</p>
            
            
            <h2>Ghostscript levels recap</h2>
            <p><strong>Less:</strong> legal scans and signatures. <strong>Recommended:</strong> email and portals. <strong>Extreme:</strong> last resort — verify text at 100% zoom.</p>
            <h2>Size checker</h2>
            <p><a href="/pdf-size-checker">PDF size checker</a> presets before/after compress — Gmail 20 MB, portal 5 MB.</p>
            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Compress now</strong> <a href="/pdf/compress" class="alert-link fw-semibold">Compress PDF →</a></div>
            
            
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
            
            
            <h2>Operational deep dive — IRCC / GCKey</h2>
            <p>Ghostscript compression re-encodes embedded images while vector text usually stays sharp. Phone photos and 600 DPI scans dominate file size — scan at 200–300 DPI grayscale for text proofs before compress saves more than Extreme on blurry source.</p>
            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> Compress PDF workflow — IRCC / GCKey</figcaption></figure>
            <h2>Double compression trap</h2>
            <p>Compress → merge → compress again softens text twice — <a href="/guides/compress-before-merge-pdf">merge/compress order guide</a>.</p>
            <h2>Portal rejection decode</h2>
            <p><strong>Too large:</strong> compress or <a href="/guides/split-pdf-for-email">split</a>. <strong>Unreadable:</strong> re-scan. <strong>Password:</strong> <a href="/guides/unlock-pdf">unlock</a> first.</p>
            <h2>Research</h2>
            <p><a href="/research/pdf-compression-benchmark">PDF compression benchmark</a> · <a href="/research/attachment-size-limits">Attachment size limits</a>.</p>
            <h2>Free tier</h2>
            <p>Three uses/day — high volume <a href="/Subscription/Plans">plans</a>.</p>
            <h2>Related compression guides</h2>
            <p>Portal compress: <a href="/guides/compress-pdf-gst-portal">GST portal</a> · <a href="/guides/compress-pdf-schengen-visa">Schengen</a> · <a href="/guides/compress-pdf-for-government-forms">government forms</a>.</p>
            <h2>Related Word conversion guides</h2>
            <p>After Word edit re-export: <a href="/guides/pdf-to-word-keep-formatting">keep formatting</a> — then compress for email.</p>
            
            
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
            
            
            <h2>Industry cross-links</h2>
            <p>Lawyers: <a href="/guides/compress-pdf-lawyers">compress for lawyers</a> · Realtors: <a href="/guides/compress-pdf-realtors">realtors</a> · Healthcare: <a href="/guides/compress-pdf-healthcare">healthcare</a> · Accountants: <a href="/guides/compress-pdf-accountants">accountants</a>.</p>

            <h2>Merge and OCR chain</h2>
            <p>OCR'd scans are larger — <a href="/guides/ocr-pdf">OCR PDF</a> then compress. Multi-file: <a href="/guides/merge-pdf-online">merge</a> then <a href="/guides/compress-before-merge-pdf">compress decision</a>.</p>
            
            
            <h2>Failure messages</h2>
            <p><strong>Too large:</strong> compress or split. <strong>Invalid PDF:</strong> re-export source. <strong>Unreadable:</strong> re-scan don't only compress blur.</p>
            <h2>Archive discipline</h2>
            <p>Keep uncompressed master until upload or send succeeds — derivatives are disposable.</p>
            <h2>Compare tools</h2>
            <p><a href="/compare/smallpdf-alternative">Smallpdf</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/adobe-alternative">Adobe</a>.</p>
            
            
            <h2>Device sync workflows</h2>
            <p>Compress on desktop — save to cloud — open on mobile for portal upload — same file hash verify across devices.</p>
            <h2>Antivirus false positives</h2>
            <p>Rare corporate AV blocks download — whitelist ratpdf.com — retry Edge if Chrome extension interferes.</p>
            <h2>Colour stamp preservation</h2>
            <p>Immigration stamps — Less not Extreme — verify red ink visible after compress on portal preview.</p>
            <h2>Wi-Fi vs cellular</h2>
            <p>Large upload on train — may timeout — finish compress download on Wi-Fi before switching to mobile data for portal.</p>
            <h2>Filename discipline</h2>
            <p><code>Passport-Compressed-2026.pdf</code> not <code>document(1).pdf</code> — immigration officers match checklist labels.</p>
            
            
            <h2>Quarterly tool check</h2>
            <p>Portal caps change — re-read upload widget each filing season — compress level that worked last year may need Less this year if portal tightens legibility checks.</p>
            <h2>Handoff to split</h2>
            <p>If still over cap after Less — <a href="/guides/split-pdf-for-email">split for email</a> before giving up on digital submission.</p>
            <h2>Batch naming for accountants</h2>
            <p><code>Client-YYYY-MM-invoice-compressed.pdf</code> — batch compress folder sorts chronologically in AP import.</p>
            <h2>Merge-then-compress SOP</h2>
            <p>Month-end board pack: merge in agenda order → single compress → one email attachment — log final MB in board portal.</p>
            
            
            <h2>Tool chain map</h2>
            <p>OCR → compress → merge → split — pick order by portal rules. See <a href="/guides/compress-before-merge-pdf">compress vs merge</a> and <a href="/guides/pdf-to-word-vs-pdf-to-text">Word vs Text</a>.</p>
            <h2>Upgrade volume</h2>
            <p>Migration and month-end batches: <a href="/Subscription/Plans">subscription plans</a>.</p>
            
            
            <h2>Related compress guides</h2>
            <ul>
            <li><a href="/guides/compress-pdf-guide">Compress PDF guide</a></li>
            <li><a href="/guides/compress-before-merge-pdf">Compress before/after merge</a></li>
            <li><a href="/guides/batch-compress-pdf">Batch compress PDF</a></li>
            <li><a href="/guides/compress-pdf-made-it-larger">Compress made it larger</a></li>
            </ul>
            <p>Research: <a href="/research/attachment-size-limits">Attachment size limits</a> · <a href="/research/pdf-compression-benchmark">PDF compression benchmark</a></p>
            
            
            <h2>Related guides</h2>
            <p>Platform-specific compression (Mac, Windows, mobile), portal upload limits, PDF to Text export, and split-for-email guides round out the compression workflow.</p>
            
            
            <h2>Post-action checklist</h2>
            <ol><li>Output file opens in viewer</li><li>Text selects if required</li><li>Size under portal/email preset</li><li>Master archived</li><li>Correct tool used for next step (text vs Word vs OCR)</li></ol>
            <p>Bookmark the <a href="/guides/pdf-tools">PDF tools guide</a> and <a href="/compare">compare tools</a> for team onboarding — consistent tool choice reduces wrong-output support tickets.</p>
            <p>Re-run size checker after every derivative step — compress, split, or text export — before deleting the previous version from your working folder.</p>
            
            <p class="mt-4"><a href="/pdf/compress" class="btn btn-primary">Compress PDF free</a> · <a href="/Subscription/Plans">Upgrade</a></p>
            """;

        private const string CompressPdfMadeItLarger = """
            <h2>Compress PDF made it larger — why size increased &amp; what to do</h2>
            <p>Troubleshooting and batch workflow for compress cluster — avoid wasted passes and wrong tool order.</p>
            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> Compress PDF made it larger — why size increased &amp; what to do</figcaption></figure>
            
            <h2>Why compression sometimes increases size</h2>
            <p>Already-optimised JPEGs, tiny text-only PDFs, and corrupted files may grow when Ghostscript re-wraps objects. Compression is not magic — it re-encodes images, not invent compression on minimal files.</p>
            <h2>Real example: 200 KB digital invoice</h2>
            <p>Recommended pass → 240 KB — stop compressing; file was already optimal. Use as-is or split if portal still rejects.</p>
            <h2>What to do instead</h2>
            <ol><li>Try Less not Extreme</li><li><a href="/guides/split-pdf">Split PDF</a> if over cap</li><li>Re-scan at lower DPI if scan-heavy</li><li>Merge then one compress — <a href="/guides/combine-then-compress-pdf">combine then compress</a></li></ol>
            
            <div class="rp-mid-cta alert alert-primary my-4"><strong>Open primary tool</strong> <a href="/pdf/compress" class="alert-link fw-semibold">Compress PDF →</a></div>
            
            <h2>Compression levels</h2>
            <p><strong>Less:</strong> signatures and stamps. <strong>Recommended:</strong> default. <strong>Extreme:</strong> last resort — verify legibility.</p>
            <h2>Pre-upload checklist</h2>
            <ol>
            <li><a href="/pdf-size-checker">PDF size checker</a> preset</li>
            <li>Rotate scans upright</li>
            <li>One compress pass after merge</li>
            <li>Keep master until upload succeeds</li>
            </ol>
            <h2>Email variants</h2>
            <p><a href="/guides/compress-pdf-for-gmail">Gmail</a> · <a href="/guides/compress-pdf-for-outlook">Outlook</a> · <a href="/guides/compress-pdf-for-whatsapp">WhatsApp</a>.</p>
            <h2>Immigration cross-links</h2>
            <p><a href="/guides/compress-pdf-for-visa-application">Visa application</a> · <a href="/guides/compress-pdf-schengen-visa">Schengen</a> · <a href="/guides/compress-pdf-digilocker">DigiLocker</a>.</p>
            <h2>Industry guides</h2>
            <p><a href="/guides/compress-pdf-lawyers">Lawyers</a> · <a href="/guides/compress-pdf-accountants">Accountants</a> · <a href="/guides/compress-pdf-efiling">E-filing</a>.</p>
            
            
            <h2>Ghostscript levels recap</h2>
            <p><strong>Less:</strong> legal scans and signatures. <strong>Recommended:</strong> email and portals. <strong>Extreme:</strong> last resort — verify text at 100% zoom.</p>
            <h2>Size checker</h2>
            <p><a href="/pdf-size-checker">PDF size checker</a> presets before/after compress — Gmail 20 MB, portal 5 MB.</p>
            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Compress now</strong> <a href="/pdf/compress" class="alert-link fw-semibold">Compress PDF →</a></div>
            
            
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
            
            
            <h2>Operational deep dive — compress-pdf-made-it-larger</h2>
            <p>Ghostscript compression re-encodes embedded images while vector text usually stays sharp. Phone photos and 600 DPI scans dominate file size — scan at 200–300 DPI grayscale for text proofs before compress saves more than Extreme on blurry source.</p>
            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> Compress PDF workflow — compress-pdf-made-it-larger</figcaption></figure>
            <h2>Double compression trap</h2>
            <p>Compress → merge → compress again softens text twice — <a href="/guides/compress-before-merge-pdf">merge/compress order guide</a>.</p>
            <h2>Portal rejection decode</h2>
            <p><strong>Too large:</strong> compress or <a href="/guides/split-pdf-for-email">split</a>. <strong>Unreadable:</strong> re-scan. <strong>Password:</strong> <a href="/guides/unlock-pdf">unlock</a> first.</p>
            <h2>Research</h2>
            <p><a href="/research/pdf-compression-benchmark">PDF compression benchmark</a> · <a href="/research/attachment-size-limits">Attachment size limits</a>.</p>
            <h2>Free tier</h2>
            <p>Three uses/day — high volume <a href="/Subscription/Plans">plans</a>.</p>
            <h2>Related compression guides</h2>
            <p>Portal compress: <a href="/guides/compress-pdf-gst-portal">GST portal</a> · <a href="/guides/compress-pdf-schengen-visa">Schengen</a> · <a href="/guides/compress-pdf-for-government-forms">government forms</a>.</p>
            <h2>Related Word conversion guides</h2>
            <p>After Word edit re-export: <a href="/guides/pdf-to-word-keep-formatting">keep formatting</a> — then compress for email.</p>
            
            
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
            
            
            <h2>Industry cross-links</h2>
            <p>Lawyers: <a href="/guides/compress-pdf-lawyers">compress for lawyers</a> · Realtors: <a href="/guides/compress-pdf-realtors">realtors</a> · Healthcare: <a href="/guides/compress-pdf-healthcare">healthcare</a> · Accountants: <a href="/guides/compress-pdf-accountants">accountants</a>.</p>

            <h2>Merge and OCR chain</h2>
            <p>OCR'd scans are larger — <a href="/guides/ocr-pdf">OCR PDF</a> then compress. Multi-file: <a href="/guides/merge-pdf-online">merge</a> then <a href="/guides/compress-before-merge-pdf">compress decision</a>.</p>
            
            
            <h2>Failure messages</h2>
            <p><strong>Too large:</strong> compress or split. <strong>Invalid PDF:</strong> re-export source. <strong>Unreadable:</strong> re-scan don't only compress blur.</p>
            <h2>Archive discipline</h2>
            <p>Keep uncompressed master until upload or send succeeds — derivatives are disposable.</p>
            <h2>Compare tools</h2>
            <p><a href="/compare/smallpdf-alternative">Smallpdf</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/adobe-alternative">Adobe</a>.</p>
            
            
            <h2>Device sync workflows</h2>
            <p>Compress on desktop — save to cloud — open on mobile for portal upload — same file hash verify across devices.</p>
            <h2>Antivirus false positives</h2>
            <p>Rare corporate AV blocks download — whitelist ratpdf.com — retry Edge if Chrome extension interferes.</p>
            <h2>Colour stamp preservation</h2>
            <p>Immigration stamps — Less not Extreme — verify red ink visible after compress on portal preview.</p>
            <h2>Wi-Fi vs cellular</h2>
            <p>Large upload on train — may timeout — finish compress download on Wi-Fi before switching to mobile data for portal.</p>
            <h2>Filename discipline</h2>
            <p><code>Passport-Compressed-2026.pdf</code> not <code>document(1).pdf</code> — immigration officers match checklist labels.</p>
            
            
            <h2>Quarterly tool check</h2>
            <p>Portal caps change — re-read upload widget each filing season — compress level that worked last year may need Less this year if portal tightens legibility checks.</p>
            <h2>Handoff to split</h2>
            <p>If still over cap after Less — <a href="/guides/split-pdf-for-email">split for email</a> before giving up on digital submission.</p>
            <h2>Batch naming for accountants</h2>
            <p><code>Client-YYYY-MM-invoice-compressed.pdf</code> — batch compress folder sorts chronologically in AP import.</p>
            <h2>Merge-then-compress SOP</h2>
            <p>Month-end board pack: merge in agenda order → single compress → one email attachment — log final MB in board portal.</p>
            
            
            <h2>Tool chain map</h2>
            <p>OCR → compress → merge → split — pick order by portal rules. See <a href="/guides/compress-before-merge-pdf">compress vs merge</a> and <a href="/guides/pdf-to-word-vs-pdf-to-text">Word vs Text</a>.</p>
            <h2>Upgrade volume</h2>
            <p>Migration and month-end batches: <a href="/Subscription/Plans">subscription plans</a>.</p>
            
            
            <h2>Related compress guides</h2>
            <ul>
            <li><a href="/guides/compress-pdf-guide">Compress PDF guide</a></li>
            <li><a href="/guides/compress-before-merge-pdf">Compress before/after merge</a></li>
            <li><a href="/guides/batch-compress-pdf">Batch compress PDF</a></li>
            <li><a href="/guides/compress-pdf-made-it-larger">Compress made it larger</a></li>
            </ul>
            <p>Research: <a href="/research/attachment-size-limits">Attachment size limits</a> · <a href="/research/pdf-compression-benchmark">PDF compression benchmark</a></p>
            
            
            <h2>Related guides</h2>
            <p>Platform-specific compression (Mac, Windows, mobile), portal upload limits, PDF to Text export, and split-for-email guides round out the compression workflow.</p>
            
            
            <h2>Post-action checklist</h2>
            <ol><li>Output file opens in viewer</li><li>Text selects if required</li><li>Size under portal/email preset</li><li>Master archived</li><li>Correct tool used for next step (text vs Word vs OCR)</li></ol>
            <p>Bookmark the <a href="/guides/pdf-tools">PDF tools guide</a> and <a href="/compare">compare tools</a> for team onboarding — consistent tool choice reduces wrong-output support tickets.</p>
            <p>Re-run size checker after every derivative step — compress, split, or text export — before deleting the previous version from your working folder.</p>
            
            <p class="mt-4"><a href="/pdf/compress" class="btn btn-primary">Compress PDF</a> · <a href="/guides/batch-compress-pdf">Batch guide</a></p>
            """;

        private const string BatchCompressPdf = """
            <h2>Batch compress PDF files — workflow for multiple documents</h2>
            <p>Troubleshooting and batch workflow for compress cluster — avoid wasted passes and wrong tool order.</p>
            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> Batch compress PDF files — workflow for multiple documents</figcaption></figure>
            
            <h2>Batch compress workflow</h2>
            <p>Month-end: 40 vendor invoices — compress each with same Recommended setting — verify GSTIN legible — attach individually. Name files <code>Vendor-Date-compressed.pdf</code>.</p>
            <h2>Merge-then-compress vs one-by-one</h2>
            <p>One email attachment slot → <a href="/guides/merge-pdf-online">merge</a> then single compress. Per-slot government portal → compress each separately.</p>
            
            <div class="rp-mid-cta alert alert-primary my-4"><strong>Open primary tool</strong> <a href="/pdf/compress" class="alert-link fw-semibold">Compress PDF →</a></div>
            
            <h2>Compression levels</h2>
            <p><strong>Less:</strong> signatures and stamps. <strong>Recommended:</strong> default. <strong>Extreme:</strong> last resort — verify legibility.</p>
            <h2>Pre-upload checklist</h2>
            <ol>
            <li><a href="/pdf-size-checker">PDF size checker</a> preset</li>
            <li>Rotate scans upright</li>
            <li>One compress pass after merge</li>
            <li>Keep master until upload succeeds</li>
            </ol>
            <h2>Email variants</h2>
            <p><a href="/guides/compress-pdf-for-gmail">Gmail</a> · <a href="/guides/compress-pdf-for-outlook">Outlook</a> · <a href="/guides/compress-pdf-for-whatsapp">WhatsApp</a>.</p>
            <h2>Immigration cross-links</h2>
            <p><a href="/guides/compress-pdf-for-visa-application">Visa application</a> · <a href="/guides/compress-pdf-schengen-visa">Schengen</a> · <a href="/guides/compress-pdf-digilocker">DigiLocker</a>.</p>
            <h2>Industry guides</h2>
            <p><a href="/guides/compress-pdf-lawyers">Lawyers</a> · <a href="/guides/compress-pdf-accountants">Accountants</a> · <a href="/guides/compress-pdf-efiling">E-filing</a>.</p>
            
            
            <h2>Ghostscript levels recap</h2>
            <p><strong>Less:</strong> legal scans and signatures. <strong>Recommended:</strong> email and portals. <strong>Extreme:</strong> last resort — verify text at 100% zoom.</p>
            <h2>Size checker</h2>
            <p><a href="/pdf-size-checker">PDF size checker</a> presets before/after compress — Gmail 20 MB, portal 5 MB.</p>
            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Compress now</strong> <a href="/pdf/compress" class="alert-link fw-semibold">Compress PDF →</a></div>
            
            
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
            
            
            <h2>Operational deep dive — batch-compress-pdf</h2>
            <p>Ghostscript compression re-encodes embedded images while vector text usually stays sharp. Phone photos and 600 DPI scans dominate file size — scan at 200–300 DPI grayscale for text proofs before compress saves more than Extreme on blurry source.</p>
            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> Compress PDF workflow — batch-compress-pdf</figcaption></figure>
            <h2>Double compression trap</h2>
            <p>Compress → merge → compress again softens text twice — <a href="/guides/compress-before-merge-pdf">merge/compress order guide</a>.</p>
            <h2>Portal rejection decode</h2>
            <p><strong>Too large:</strong> compress or <a href="/guides/split-pdf-for-email">split</a>. <strong>Unreadable:</strong> re-scan. <strong>Password:</strong> <a href="/guides/unlock-pdf">unlock</a> first.</p>
            <h2>Research</h2>
            <p><a href="/research/pdf-compression-benchmark">PDF compression benchmark</a> · <a href="/research/attachment-size-limits">Attachment size limits</a>.</p>
            <h2>Free tier</h2>
            <p>Three uses/day — high volume <a href="/Subscription/Plans">plans</a>.</p>
            <h2>Related compression guides</h2>
            <p>Portal compress: <a href="/guides/compress-pdf-gst-portal">GST portal</a> · <a href="/guides/compress-pdf-schengen-visa">Schengen</a> · <a href="/guides/compress-pdf-for-government-forms">government forms</a>.</p>
            <h2>Related Word conversion guides</h2>
            <p>After Word edit re-export: <a href="/guides/pdf-to-word-keep-formatting">keep formatting</a> — then compress for email.</p>
            
            
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
            
            
            <h2>Industry cross-links</h2>
            <p>Lawyers: <a href="/guides/compress-pdf-lawyers">compress for lawyers</a> · Realtors: <a href="/guides/compress-pdf-realtors">realtors</a> · Healthcare: <a href="/guides/compress-pdf-healthcare">healthcare</a> · Accountants: <a href="/guides/compress-pdf-accountants">accountants</a>.</p>

            <h2>Merge and OCR chain</h2>
            <p>OCR'd scans are larger — <a href="/guides/ocr-pdf">OCR PDF</a> then compress. Multi-file: <a href="/guides/merge-pdf-online">merge</a> then <a href="/guides/compress-before-merge-pdf">compress decision</a>.</p>
            
            
            <h2>Failure messages</h2>
            <p><strong>Too large:</strong> compress or split. <strong>Invalid PDF:</strong> re-export source. <strong>Unreadable:</strong> re-scan don't only compress blur.</p>
            <h2>Archive discipline</h2>
            <p>Keep uncompressed master until upload or send succeeds — derivatives are disposable.</p>
            <h2>Compare tools</h2>
            <p><a href="/compare/smallpdf-alternative">Smallpdf</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/adobe-alternative">Adobe</a>.</p>
            
            
            <h2>Device sync workflows</h2>
            <p>Compress on desktop — save to cloud — open on mobile for portal upload — same file hash verify across devices.</p>
            <h2>Antivirus false positives</h2>
            <p>Rare corporate AV blocks download — whitelist ratpdf.com — retry Edge if Chrome extension interferes.</p>
            <h2>Colour stamp preservation</h2>
            <p>Immigration stamps — Less not Extreme — verify red ink visible after compress on portal preview.</p>
            <h2>Wi-Fi vs cellular</h2>
            <p>Large upload on train — may timeout — finish compress download on Wi-Fi before switching to mobile data for portal.</p>
            <h2>Filename discipline</h2>
            <p><code>Passport-Compressed-2026.pdf</code> not <code>document(1).pdf</code> — immigration officers match checklist labels.</p>
            
            
            <h2>Quarterly tool check</h2>
            <p>Portal caps change — re-read upload widget each filing season — compress level that worked last year may need Less this year if portal tightens legibility checks.</p>
            <h2>Handoff to split</h2>
            <p>If still over cap after Less — <a href="/guides/split-pdf-for-email">split for email</a> before giving up on digital submission.</p>
            <h2>Batch naming for accountants</h2>
            <p><code>Client-YYYY-MM-invoice-compressed.pdf</code> — batch compress folder sorts chronologically in AP import.</p>
            <h2>Merge-then-compress SOP</h2>
            <p>Month-end board pack: merge in agenda order → single compress → one email attachment — log final MB in board portal.</p>
            
            
            <h2>Tool chain map</h2>
            <p>OCR → compress → merge → split — pick order by portal rules. See <a href="/guides/compress-before-merge-pdf">compress vs merge</a> and <a href="/guides/pdf-to-word-vs-pdf-to-text">Word vs Text</a>.</p>
            <h2>Upgrade volume</h2>
            <p>Migration and month-end batches: <a href="/Subscription/Plans">subscription plans</a>.</p>
            
            
            <h2>Related compress guides</h2>
            <ul>
            <li><a href="/guides/compress-pdf-guide">Compress PDF guide</a></li>
            <li><a href="/guides/compress-before-merge-pdf">Compress before/after merge</a></li>
            <li><a href="/guides/batch-compress-pdf">Batch compress PDF</a></li>
            <li><a href="/guides/compress-pdf-made-it-larger">Compress made it larger</a></li>
            </ul>
            <p>Research: <a href="/research/attachment-size-limits">Attachment size limits</a> · <a href="/research/pdf-compression-benchmark">PDF compression benchmark</a></p>
            
            
            <h2>Related guides</h2>
            <p>Platform-specific compression (Mac, Windows, mobile), portal upload limits, PDF to Text export, and split-for-email guides round out the compression workflow.</p>
            
            
            <h2>Post-action checklist</h2>
            <ol><li>Output file opens in viewer</li><li>Text selects if required</li><li>Size under portal/email preset</li><li>Master archived</li><li>Correct tool used for next step (text vs Word vs OCR)</li></ol>
            <p>Bookmark the <a href="/guides/pdf-tools">PDF tools guide</a> and <a href="/compare">compare tools</a> for team onboarding — consistent tool choice reduces wrong-output support tickets.</p>
            <p>Re-run size checker after every derivative step — compress, split, or text export — before deleting the previous version from your working folder.</p>
            
            <p class="mt-4"><a href="/pdf/compress" class="btn btn-primary">Compress PDF</a> · <a href="/guides/batch-compress-pdf">Batch guide</a></p>
            """;

        private const string CombineThenCompressPdf = """
            <h2>Combine PDF then compress — merge first, shrink once</h2>
            <p>Troubleshooting and batch workflow for compress cluster — avoid wasted passes and wrong tool order.</p>
            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> Combine PDF then compress — merge first, shrink once</figcaption></figure>
            
            <h2>Merge first, compress once</h2>
            <p>Board pack 6 files 38 MB total — <a href="/pdf/merge">Merge PDF</a> in order — one <a href="/pdf/compress">Compress PDF</a> pass — avoids double softening from compress-each-then-merge.</p>
            <h2>Decision guide</h2>
            <p>Full matrix: <a href="/guides/compress-before-merge-pdf">compress before or after merge</a>.</p>
            
            <div class="rp-mid-cta alert alert-primary my-4"><strong>Open primary tool</strong> <a href="/pdf/merge" class="alert-link fw-semibold">Merge PDF →</a></div>
            
            <h2>Compression levels</h2>
            <p><strong>Less:</strong> signatures and stamps. <strong>Recommended:</strong> default. <strong>Extreme:</strong> last resort — verify legibility.</p>
            <h2>Pre-upload checklist</h2>
            <ol>
            <li><a href="/pdf-size-checker">PDF size checker</a> preset</li>
            <li>Rotate scans upright</li>
            <li>One compress pass after merge</li>
            <li>Keep master until upload succeeds</li>
            </ol>
            <h2>Email variants</h2>
            <p><a href="/guides/compress-pdf-for-gmail">Gmail</a> · <a href="/guides/compress-pdf-for-outlook">Outlook</a> · <a href="/guides/compress-pdf-for-whatsapp">WhatsApp</a>.</p>
            <h2>Immigration cross-links</h2>
            <p><a href="/guides/compress-pdf-for-visa-application">Visa application</a> · <a href="/guides/compress-pdf-schengen-visa">Schengen</a> · <a href="/guides/compress-pdf-digilocker">DigiLocker</a>.</p>
            <h2>Industry guides</h2>
            <p><a href="/guides/compress-pdf-lawyers">Lawyers</a> · <a href="/guides/compress-pdf-accountants">Accountants</a> · <a href="/guides/compress-pdf-efiling">E-filing</a>.</p>
            
            
            <h2>Ghostscript levels recap</h2>
            <p><strong>Less:</strong> legal scans and signatures. <strong>Recommended:</strong> email and portals. <strong>Extreme:</strong> last resort — verify text at 100% zoom.</p>
            <h2>Size checker</h2>
            <p><a href="/pdf-size-checker">PDF size checker</a> presets before/after compress — Gmail 20 MB, portal 5 MB.</p>
            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Compress now</strong> <a href="/pdf/compress" class="alert-link fw-semibold">Compress PDF →</a></div>
            
            
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
            
            
            <h2>Operational deep dive — combine-then-compress-pdf</h2>
            <p>Ghostscript compression re-encodes embedded images while vector text usually stays sharp. Phone photos and 600 DPI scans dominate file size — scan at 200–300 DPI grayscale for text proofs before compress saves more than Extreme on blurry source.</p>
            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> Compress PDF workflow — combine-then-compress-pdf</figcaption></figure>
            <h2>Double compression trap</h2>
            <p>Compress → merge → compress again softens text twice — <a href="/guides/compress-before-merge-pdf">merge/compress order guide</a>.</p>
            <h2>Portal rejection decode</h2>
            <p><strong>Too large:</strong> compress or <a href="/guides/split-pdf-for-email">split</a>. <strong>Unreadable:</strong> re-scan. <strong>Password:</strong> <a href="/guides/unlock-pdf">unlock</a> first.</p>
            <h2>Research</h2>
            <p><a href="/research/pdf-compression-benchmark">PDF compression benchmark</a> · <a href="/research/attachment-size-limits">Attachment size limits</a>.</p>
            <h2>Free tier</h2>
            <p>Three uses/day — high volume <a href="/Subscription/Plans">plans</a>.</p>
            <h2>Related compression guides</h2>
            <p>Portal compress: <a href="/guides/compress-pdf-gst-portal">GST portal</a> · <a href="/guides/compress-pdf-schengen-visa">Schengen</a> · <a href="/guides/compress-pdf-for-government-forms">government forms</a>.</p>
            <h2>Related Word conversion guides</h2>
            <p>After Word edit re-export: <a href="/guides/pdf-to-word-keep-formatting">keep formatting</a> — then compress for email.</p>
            
            
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
            
            
            <h2>Industry cross-links</h2>
            <p>Lawyers: <a href="/guides/compress-pdf-lawyers">compress for lawyers</a> · Realtors: <a href="/guides/compress-pdf-realtors">realtors</a> · Healthcare: <a href="/guides/compress-pdf-healthcare">healthcare</a> · Accountants: <a href="/guides/compress-pdf-accountants">accountants</a>.</p>

            <h2>Merge and OCR chain</h2>
            <p>OCR'd scans are larger — <a href="/guides/ocr-pdf">OCR PDF</a> then compress. Multi-file: <a href="/guides/merge-pdf-online">merge</a> then <a href="/guides/compress-before-merge-pdf">compress decision</a>.</p>
            
            
            <h2>Failure messages</h2>
            <p><strong>Too large:</strong> compress or split. <strong>Invalid PDF:</strong> re-export source. <strong>Unreadable:</strong> re-scan don't only compress blur.</p>
            <h2>Archive discipline</h2>
            <p>Keep uncompressed master until upload or send succeeds — derivatives are disposable.</p>
            <h2>Compare tools</h2>
            <p><a href="/compare/smallpdf-alternative">Smallpdf</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/adobe-alternative">Adobe</a>.</p>
            
            
            <h2>Device sync workflows</h2>
            <p>Compress on desktop — save to cloud — open on mobile for portal upload — same file hash verify across devices.</p>
            <h2>Antivirus false positives</h2>
            <p>Rare corporate AV blocks download — whitelist ratpdf.com — retry Edge if Chrome extension interferes.</p>
            <h2>Colour stamp preservation</h2>
            <p>Immigration stamps — Less not Extreme — verify red ink visible after compress on portal preview.</p>
            <h2>Wi-Fi vs cellular</h2>
            <p>Large upload on train — may timeout — finish compress download on Wi-Fi before switching to mobile data for portal.</p>
            <h2>Filename discipline</h2>
            <p><code>Passport-Compressed-2026.pdf</code> not <code>document(1).pdf</code> — immigration officers match checklist labels.</p>
            
            
            <h2>Quarterly tool check</h2>
            <p>Portal caps change — re-read upload widget each filing season — compress level that worked last year may need Less this year if portal tightens legibility checks.</p>
            <h2>Handoff to split</h2>
            <p>If still over cap after Less — <a href="/guides/split-pdf-for-email">split for email</a> before giving up on digital submission.</p>
            <h2>Batch naming for accountants</h2>
            <p><code>Client-YYYY-MM-invoice-compressed.pdf</code> — batch compress folder sorts chronologically in AP import.</p>
            <h2>Merge-then-compress SOP</h2>
            <p>Month-end board pack: merge in agenda order → single compress → one email attachment — log final MB in board portal.</p>
            
            
            <h2>Tool chain map</h2>
            <p>OCR → compress → merge → split — pick order by portal rules. See <a href="/guides/compress-before-merge-pdf">compress vs merge</a> and <a href="/guides/pdf-to-word-vs-pdf-to-text">Word vs Text</a>.</p>
            <h2>Upgrade volume</h2>
            <p>Migration and month-end batches: <a href="/Subscription/Plans">subscription plans</a>.</p>
            
            
            <h2>Related compress guides</h2>
            <ul>
            <li><a href="/guides/compress-pdf-guide">Compress PDF guide</a></li>
            <li><a href="/guides/compress-before-merge-pdf">Compress before/after merge</a></li>
            <li><a href="/guides/batch-compress-pdf">Batch compress PDF</a></li>
            <li><a href="/guides/compress-pdf-made-it-larger">Compress made it larger</a></li>
            </ul>
            <p>Research: <a href="/research/attachment-size-limits">Attachment size limits</a> · <a href="/research/pdf-compression-benchmark">PDF compression benchmark</a></p>
            
            
            <h2>Related guides</h2>
            <p>Platform-specific compression (Mac, Windows, mobile), portal upload limits, PDF to Text export, and split-for-email guides round out the compression workflow.</p>
            
            
            <h2>Post-action checklist</h2>
            <ol><li>Output file opens in viewer</li><li>Text selects if required</li><li>Size under portal/email preset</li><li>Master archived</li><li>Correct tool used for next step (text vs Word vs OCR)</li></ol>
            <p>Bookmark the <a href="/guides/pdf-tools">PDF tools guide</a> and <a href="/compare">compare tools</a> for team onboarding — consistent tool choice reduces wrong-output support tickets.</p>
            <p>Re-run size checker after every derivative step — compress, split, or text export — before deleting the previous version from your working folder.</p>
            
            <p class="mt-4"><a href="/pdf/merge" class="btn btn-primary">Merge PDF</a> · <a href="/pdf/compress">Compress PDF</a></p>
            """;

        private const string PdfToTextResearch = """
            <h2>Extract text from PDF for research — papers &amp; citations</h2>
            <p>Export plain text from PDF for academic research quotes and bibliography — RatPDF <a href="/pdf/pdftotext">PDF to Text</a> in browser, no Adobe.</p>
            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> PDF to Text — academic research quotes and bibliography</figcaption></figure>
            <h2>Real example: Pull citation text from paywalled journal PDF for literature review notes</h2>
            <ol>
            <li>Test if PDF text selects — if not, OCR first.</li>
            <li>Upload to PDF to Text — download .txt.</li>
            <li>Grep, cite, or import to spreadsheet pipeline.</li>
            </ol>
            
            <h2>Digital vs scanned papers</h2>
            <p>Publisher PDF with selectable text → <a href="/pdf/pdftotext">PDF to Text</a> direct. Scanned book chapter → <a href="/pdf/ocrpdf">OCR PDF</a> then text export.</p>
            <h2>Citation hygiene</h2>
            <p>Copied quotes — verify page numbers against source — UTF-8 txt preserves most diacritics.</p>
            <h2>When Word wins</h2>
            <p>Annotated review with track changes → <a href="/guides/pdf-to-word-keep-formatting">PDF to Word</a>.</p>
            <h2>Reference managers</h2>
            <p>Zotero stores PDF — export notes to txt for qualitative coding in ATLAS.ti — link back to PDF highlight for verification.</p>
            <h2>Math and equations</h2>
            <p>LaTeX-generated PDF often exports equations as unicode — scanned math may OCR poorly — keep PDF for formula check.</p>
            
            
            <h2>Systematic review workflow</h2>
            <p>Screen titles in spreadsheet — full text export for included studies only — PRISMA flow documents count.</p>
            <h2>Preprint servers</h2>
            <p>arXiv PDF usually digital — fast export — journal final PDF may differ — cite version in notes.</p>
            
            <div class="rp-mid-cta alert alert-primary my-4"><strong>Extract text now</strong> <a href="/pdf/pdftotext" class="alert-link fw-semibold">PDF to Text →</a></div>
            
            <h2>OCR branch</h2>
            <p>Image-only PDF → <a href="/pdf/ocrpdf">OCR PDF</a> → <a href="/pdf/pdftotext">PDF to Text</a>. Decision: <a href="/guides/ocr-vs-pdf-to-text">OCR vs Text</a>.</p>
            <h2>Word vs Text</h2>
            <p>Need layout edit → <a href="/guides/pdf-to-word-vs-pdf-to-text">PDF to Word vs Text</a> · <a href="/pdf/pdftodoc">PDF to Word</a>.</p>
            <h2>Output hygiene</h2>
            <p>UTF-8 .txt — grep-friendly — delete files with PII after task. Do not email plain text bank exports unencrypted.</p>
            <h2>Developer note</h2>
            <p>Pipe .txt into Python, R, or LLM ingest — structure lost vs HTML table export — pick tool to downstream need.</p>
            
            
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
            
            
            <h2>Text extraction pipeline — academic research quotes and bibliography</h2>
            <p>Digital PDF exports text from embedded character maps. Scanned PDFs need OCR text layer first — export then pulls OCR text, not pixels.</p>
            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> PDF to Text export — academic research quotes and bibliography</figcaption></figure>
            <h2>Real workflow: grep across corpus</h2>
            <p>100 discovery PDFs → batch OCR → PDF to Text each → ripgrep privilege keyword — faster than opening each in viewer.</p>
            <h2>Second example: meta-analysis</h2>
            <p>40 journal PDFs — export abstracts to .txt — sort in spreadsheet by keyword frequency — cite from original PDF page after spot-check.</p>
            <h2>Limits</h2>
            <p>Multi-column newspaper PDF may jumble column order in .txt — manual cleanup or Word for layout-sensitive review.</p>
            <h2>Footnotes and headers</h2>
            <p>Footnotes may appear mid-paragraph in export — academic workflow keeps PDF open for page proof while .txt is note scratchpad.</p>
            <h2>Security</h2>
            <p>Transient processing — clear Downloads on shared PC — legal privilege applies to .txt same as source PDF.</p>
            <h2>Compare</h2>
            <p><a href="/compare/adobe-alternative">Adobe alternative</a> · <a href="/compare/smallpdf-alternative">Smallpdf</a> — evaluate privacy before uploading privileged PDFs.</p>
            <h2>Pillar links</h2>
            <p><a href="/guides/pdf-to-text">PDF to Text hub</a> · <a href="/guides/pdf-to-word-vs-pdf-to-text">Word vs Text</a> · <a href="/guides/ocr-vs-pdf-to-text">OCR vs Text</a>.</p>
            
            
            <h2>Output format decisions</h2>
            <p>.txt for scripts and search — DOCX for human edit — searchable PDF for archive — choose before starting batch job.</p>
            <h2>LLM ingest caution</h2>
            <p>Pasting privileged .txt into public ChatGPT may waive privilege — use enterprise AI with DPA or local models only.</p>
            <h2>Line endings</h2>
            <p>Windows Notepad vs VS Code — CRLF vs LF — downstream Python often prefers LF — normalize in editor save.</p>
            <h2>Tables in text export</h2>
            <p>Bank and invoice tables lose column alignment — expect manual delimiter fix or use Excel export path instead.</p>
            <h2>OCR language packs</h2>
            <p>Wrong OCR language garbles export — match document language on <a href="/guides/ocr-pdf">OCR PDF</a> before text step.</p>
            <h2>Research ethics</h2>
            <p>Human subjects PDFs — IRB may restrict text export off secure enclave — check protocol before export.</p>
            <h2>Quality sampling</h2>
            <p>Export 10 random PDFs — manually compare .txt to source — if error rate high fix OCR settings before batch of 500.</p>
            <h2>Retention</h2>
            <p>Delete .txt exports with PII when task ends — same policy as source PDF — do not leave on shared Downloads.</p>
            
            
            <h2>End-to-end digital PDF path</h2>
            <ol>
            <li>Confirm text selects in viewer</li>
            <li>Upload to <a href="/pdf/pdftotext">PDF to Text</a></li>
            <li>Download UTF-8 .txt</li>
            <li>Import to script, spreadsheet, or review tool</li>
            <li>Archive source PDF hash in log</li>
            </ol>
            <h2>End-to-end scanned PDF path</h2>
            <ol>
            <li>Scan 300 DPI grayscale</li>
            <li><a href="/pdf/ocrpdf">OCR PDF</a> — verify Ctrl+F</li>
            <li>PDF to Text on OCR output</li>
            <li>Spot-check amounts and names</li>
            </ol>
            <h2>When extraction returns empty</h2>
            <p>PDF is flattened image or rights-managed — request source from sender — or OCR entire document.</p>
            <h2>Compare tools</h2>
            <p><a href="/guides/pdf-to-word-vs-pdf-to-text">Word vs Text</a> · <a href="/guides/ocr-vs-pdf-to-text">OCR vs Text</a> · <a href="/guides/extract-text-without-adobe">without Adobe</a>.</p>
            
            
            <h2>Second real example: compliance audit</h2>
            <p>Auditor requests policy PDF corpus as searchable text — OCR legacy scans — export txt — grep retention keywords — findings cite page in original PDF.</p>
            <h2>Third example: journalism</h2>
            <p>FOIA PDF bundle — text export for quote extraction — attorney reads .txt draft — final story cites official PDF page scan.</p>
            <h2>Version control</h2>
            <p>Name exports <code>Contract-v3-export-2026-04-02.txt</code> — match to source PDF hash in log.</p>
            <h2>Combine with compress</h2>
            <p>Re-email extracted content inside Word doc — if DOCX huge — <a href="/guides/compress-pdf-for-email">compress</a> final PDF.</p>
            <h2>PhD thesis chapter mining</h2>
            <p>Export each chapter appendix to txt — code thematic analysis in R — spot-check 10% of codes against PDF page images for accuracy.</p>
            <h2>API boundary</h2>
            <p>RatPDF browser UI — no public text API on free tier — human upload per file for confidential docs.</p>
            
            
            <h2>Freelancer and SMB adoption</h2>
            <p>One-person firm exports client contracts to txt for clause search — no IT ticket for Acrobat — bill client for review time not software seat.</p>
            <h2>Government FOIA</h2>
            <p>Agency PDFs mix scan and digital — OCR batch then text export — redact txt derivative before publishing if contains third-party PII.</p>
            <h2>Historical newspaper PDFs</h2>
            <p>Multi-column OCR jumbles order — export still useful for keyword hit list — manual read PDF for final quote.</p>
            <h2>Medical records admin</h2>
            <p>Admin staff exports discharge summary text for coding review — PHI .txt on encrypted disk only — delete after coding session.</p>
            <h2>Patent prior art search</h2>
            <p>Export claims section to txt — grep keyword in corpus of 200 patent PDFs — attorney opens PDF only for relevant hits.</p>
            <h2>Plain-text archival</h2>
            <p>Some retention policies allow .txt at 1% size of PDF corpus — keep PDF as record copy — txt as search index only.</p>
            <h2>Upgrade prompt</h2>
            <p>Corpus migration over free daily cap — <a href="/Subscription/Plans">subscription plans</a> · Compare <a href="/compare/adobe-alternative">Adobe</a>.</p>
            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Extract text now</strong> <a href="/pdf/pdftotext" class="alert-link fw-semibold">PDF to Text →</a></div>
            
            
            <h2>Failure messages</h2>
            <p><strong>Too large:</strong> compress or split. <strong>Invalid PDF:</strong> re-export source. <strong>Unreadable:</strong> re-scan don't only compress blur.</p>
            <h2>Archive discipline</h2>
            <p>Keep uncompressed master until upload or send succeeds — derivatives are disposable.</p>
            <h2>Compare tools</h2>
            <p><a href="/compare/smallpdf-alternative">Smallpdf</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/adobe-alternative">Adobe</a>.</p>
            
            
            <h2>Device sync workflows</h2>
            <p>Compress on desktop — save to cloud — open on mobile for portal upload — same file hash verify across devices.</p>
            <h2>Antivirus false positives</h2>
            <p>Rare corporate AV blocks download — whitelist ratpdf.com — retry Edge if Chrome extension interferes.</p>
            <h2>Colour stamp preservation</h2>
            <p>Immigration stamps — Less not Extreme — verify red ink visible after compress on portal preview.</p>
            <h2>Wi-Fi vs cellular</h2>
            <p>Large upload on train — may timeout — finish compress download on Wi-Fi before switching to mobile data for portal.</p>
            <h2>Filename discipline</h2>
            <p><code>Passport-Compressed-2026.pdf</code> not <code>document(1).pdf</code> — immigration officers match checklist labels.</p>
            
            
            <h2>Quarterly tool check</h2>
            <p>Portal caps change — re-read upload widget each filing season — compress level that worked last year may need Less this year if portal tightens legibility checks.</p>
            <h2>Handoff to split</h2>
            <p>If still over cap after Less — <a href="/guides/split-pdf-for-email">split for email</a> before giving up on digital submission.</p>
            <h2>Batch naming for accountants</h2>
            <p><code>Client-YYYY-MM-invoice-compressed.pdf</code> — batch compress folder sorts chronologically in AP import.</p>
            <h2>Merge-then-compress SOP</h2>
            <p>Month-end board pack: merge in agenda order → single compress → one email attachment — log final MB in board portal.</p>
            
            
            <h2>Tool chain map</h2>
            <p>OCR → compress → merge → split — pick order by portal rules. See <a href="/guides/compress-before-merge-pdf">compress vs merge</a> and <a href="/guides/pdf-to-word-vs-pdf-to-text">Word vs Text</a>.</p>
            <h2>Upgrade volume</h2>
            <p>Migration and month-end batches: <a href="/Subscription/Plans">subscription plans</a>.</p>
            
            
            <h2>Related PDF to Text guides</h2>
            <ul>
            <li><a href="/guides/pdf-to-text">PDF to Text guide</a></li>
            <li><a href="/guides/ocr-vs-pdf-to-text">OCR vs PDF to Text</a></li>
            <li><a href="/guides/pdf-to-word-vs-pdf-to-text">PDF to Word vs Text</a></li>
            <li><a href="/guides/extract-text-without-adobe">Extract text without Adobe</a></li>
            </ul>
            <p>Compare: <a href="/compare/adobe-alternative">Adobe alternative</a></p>
            
            
            <h2>Related guides</h2>
            <p>Platform-specific compression (Mac, Windows, mobile), portal upload limits, PDF to Text export, and split-for-email guides round out the compression workflow.</p>
            
            
            <h2>Post-action checklist</h2>
            <ol><li>Output file opens in viewer</li><li>Text selects if required</li><li>Size under portal/email preset</li><li>Master archived</li><li>Correct tool used for next step (text vs Word vs OCR)</li></ol>
            <p>Bookmark the <a href="/guides/pdf-tools">PDF tools guide</a> and <a href="/compare">compare tools</a> for team onboarding — consistent tool choice reduces wrong-output support tickets.</p>
            <p>Re-run size checker after every derivative step — compress, split, or text export — before deleting the previous version from your working folder.</p>
            
            <p class="mt-4"><a href="/pdf/pdftotext" class="btn btn-primary">PDF to Text free</a> · <a href="/compare/adobe-alternative">Adobe alternative</a></p>
            """;

        private const string PdfToTextLegal = """
            <h2>Extract text from legal PDF — contracts &amp; discovery</h2>
            <p>Export plain text from PDF for e-discovery keyword search and clause grep — RatPDF <a href="/pdf/pdftotext">PDF to Text</a> in browser, no Adobe.</p>
            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> PDF to Text — e-discovery keyword search and clause grep</figcaption></figure>
            <h2>Real example: Export exhibit text for contract review without full Word conversion</h2>
            <ol>
            <li>Test if PDF text selects — if not, OCR first.</li>
            <li>Upload to PDF to Text — download .txt.</li>
            <li>Grep, cite, or import to spreadsheet pipeline.</li>
            </ol>
            
            <h2>Discovery workflow</h2>
            <p>Load txt into review platform or grep privilege terms — faster than OCR in viewer for batch. Privileged docs — redact first: <a href="/guides/pdf-redaction-permanent">permanent redaction</a>.</p>
            <h2>Scanned exhibits</h2>
            <p>OCR before text export — quality affects search hit rate.</p>
            <h2>Chain of custody</h2>
            <p>Log hash of source PDF and export date — txt derivative for counsel work product — not for court filing without review.</p>
            <h2>Contract vs correspondence</h2>
            <p>Digital signed contract exports clean — email thread PDF multi-column may jumble — Word for thread review.</p>
            
            
            <h2>Privilege log preparation</h2>
            <p>Export index terms from privilege log PDF — grep privileged doc IDs — cross-check production set.</p>
            <h2>Regulatory submission</h2>
            <p>SEC EDGAR text often available — use official .txt when duplicate of same filing.</p>
            
            <div class="rp-mid-cta alert alert-primary my-4"><strong>Extract text now</strong> <a href="/pdf/pdftotext" class="alert-link fw-semibold">PDF to Text →</a></div>
            
            <h2>OCR branch</h2>
            <p>Image-only PDF → <a href="/pdf/ocrpdf">OCR PDF</a> → <a href="/pdf/pdftotext">PDF to Text</a>. Decision: <a href="/guides/ocr-vs-pdf-to-text">OCR vs Text</a>.</p>
            <h2>Word vs Text</h2>
            <p>Need layout edit → <a href="/guides/pdf-to-word-vs-pdf-to-text">PDF to Word vs Text</a> · <a href="/pdf/pdftodoc">PDF to Word</a>.</p>
            <h2>Output hygiene</h2>
            <p>UTF-8 .txt — grep-friendly — delete files with PII after task. Do not email plain text bank exports unencrypted.</p>
            <h2>Developer note</h2>
            <p>Pipe .txt into Python, R, or LLM ingest — structure lost vs HTML table export — pick tool to downstream need.</p>
            
            
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
            
            
            <h2>Text extraction pipeline — e-discovery keyword search and clause grep</h2>
            <p>Digital PDF exports text from embedded character maps. Scanned PDFs need OCR text layer first — export then pulls OCR text, not pixels.</p>
            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> PDF to Text export — e-discovery keyword search and clause grep</figcaption></figure>
            <h2>Real workflow: grep across corpus</h2>
            <p>100 discovery PDFs → batch OCR → PDF to Text each → ripgrep privilege keyword — faster than opening each in viewer.</p>
            <h2>Second example: meta-analysis</h2>
            <p>40 journal PDFs — export abstracts to .txt — sort in spreadsheet by keyword frequency — cite from original PDF page after spot-check.</p>
            <h2>Limits</h2>
            <p>Multi-column newspaper PDF may jumble column order in .txt — manual cleanup or Word for layout-sensitive review.</p>
            <h2>Footnotes and headers</h2>
            <p>Footnotes may appear mid-paragraph in export — academic workflow keeps PDF open for page proof while .txt is note scratchpad.</p>
            <h2>Security</h2>
            <p>Transient processing — clear Downloads on shared PC — legal privilege applies to .txt same as source PDF.</p>
            <h2>Compare</h2>
            <p><a href="/compare/adobe-alternative">Adobe alternative</a> · <a href="/compare/smallpdf-alternative">Smallpdf</a> — evaluate privacy before uploading privileged PDFs.</p>
            <h2>Pillar links</h2>
            <p><a href="/guides/pdf-to-text">PDF to Text hub</a> · <a href="/guides/pdf-to-word-vs-pdf-to-text">Word vs Text</a> · <a href="/guides/ocr-vs-pdf-to-text">OCR vs Text</a>.</p>
            
            
            <h2>Output format decisions</h2>
            <p>.txt for scripts and search — DOCX for human edit — searchable PDF for archive — choose before starting batch job.</p>
            <h2>LLM ingest caution</h2>
            <p>Pasting privileged .txt into public ChatGPT may waive privilege — use enterprise AI with DPA or local models only.</p>
            <h2>Line endings</h2>
            <p>Windows Notepad vs VS Code — CRLF vs LF — downstream Python often prefers LF — normalize in editor save.</p>
            <h2>Tables in text export</h2>
            <p>Bank and invoice tables lose column alignment — expect manual delimiter fix or use Excel export path instead.</p>
            <h2>OCR language packs</h2>
            <p>Wrong OCR language garbles export — match document language on <a href="/guides/ocr-pdf">OCR PDF</a> before text step.</p>
            <h2>Research ethics</h2>
            <p>Human subjects PDFs — IRB may restrict text export off secure enclave — check protocol before export.</p>
            <h2>Quality sampling</h2>
            <p>Export 10 random PDFs — manually compare .txt to source — if error rate high fix OCR settings before batch of 500.</p>
            <h2>Retention</h2>
            <p>Delete .txt exports with PII when task ends — same policy as source PDF — do not leave on shared Downloads.</p>
            
            
            <h2>End-to-end digital PDF path</h2>
            <ol>
            <li>Confirm text selects in viewer</li>
            <li>Upload to <a href="/pdf/pdftotext">PDF to Text</a></li>
            <li>Download UTF-8 .txt</li>
            <li>Import to script, spreadsheet, or review tool</li>
            <li>Archive source PDF hash in log</li>
            </ol>
            <h2>End-to-end scanned PDF path</h2>
            <ol>
            <li>Scan 300 DPI grayscale</li>
            <li><a href="/pdf/ocrpdf">OCR PDF</a> — verify Ctrl+F</li>
            <li>PDF to Text on OCR output</li>
            <li>Spot-check amounts and names</li>
            </ol>
            <h2>When extraction returns empty</h2>
            <p>PDF is flattened image or rights-managed — request source from sender — or OCR entire document.</p>
            <h2>Compare tools</h2>
            <p><a href="/guides/pdf-to-word-vs-pdf-to-text">Word vs Text</a> · <a href="/guides/ocr-vs-pdf-to-text">OCR vs Text</a> · <a href="/guides/extract-text-without-adobe">without Adobe</a>.</p>
            
            
            <h2>Second real example: compliance audit</h2>
            <p>Auditor requests policy PDF corpus as searchable text — OCR legacy scans — export txt — grep retention keywords — findings cite page in original PDF.</p>
            <h2>Third example: journalism</h2>
            <p>FOIA PDF bundle — text export for quote extraction — attorney reads .txt draft — final story cites official PDF page scan.</p>
            <h2>Version control</h2>
            <p>Name exports <code>Contract-v3-export-2026-04-02.txt</code> — match to source PDF hash in log.</p>
            <h2>Combine with compress</h2>
            <p>Re-email extracted content inside Word doc — if DOCX huge — <a href="/guides/compress-pdf-for-email">compress</a> final PDF.</p>
            <h2>PhD thesis chapter mining</h2>
            <p>Export each chapter appendix to txt — code thematic analysis in R — spot-check 10% of codes against PDF page images for accuracy.</p>
            <h2>API boundary</h2>
            <p>RatPDF browser UI — no public text API on free tier — human upload per file for confidential docs.</p>
            
            
            <h2>Freelancer and SMB adoption</h2>
            <p>One-person firm exports client contracts to txt for clause search — no IT ticket for Acrobat — bill client for review time not software seat.</p>
            <h2>Government FOIA</h2>
            <p>Agency PDFs mix scan and digital — OCR batch then text export — redact txt derivative before publishing if contains third-party PII.</p>
            <h2>Historical newspaper PDFs</h2>
            <p>Multi-column OCR jumbles order — export still useful for keyword hit list — manual read PDF for final quote.</p>
            <h2>Medical records admin</h2>
            <p>Admin staff exports discharge summary text for coding review — PHI .txt on encrypted disk only — delete after coding session.</p>
            <h2>Patent prior art search</h2>
            <p>Export claims section to txt — grep keyword in corpus of 200 patent PDFs — attorney opens PDF only for relevant hits.</p>
            <h2>Plain-text archival</h2>
            <p>Some retention policies allow .txt at 1% size of PDF corpus — keep PDF as record copy — txt as search index only.</p>
            <h2>Upgrade prompt</h2>
            <p>Corpus migration over free daily cap — <a href="/Subscription/Plans">subscription plans</a> · Compare <a href="/compare/adobe-alternative">Adobe</a>.</p>
            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Extract text now</strong> <a href="/pdf/pdftotext" class="alert-link fw-semibold">PDF to Text →</a></div>
            
            
            <h2>Failure messages</h2>
            <p><strong>Too large:</strong> compress or split. <strong>Invalid PDF:</strong> re-export source. <strong>Unreadable:</strong> re-scan don't only compress blur.</p>
            <h2>Archive discipline</h2>
            <p>Keep uncompressed master until upload or send succeeds — derivatives are disposable.</p>
            <h2>Compare tools</h2>
            <p><a href="/compare/smallpdf-alternative">Smallpdf</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/adobe-alternative">Adobe</a>.</p>
            
            
            <h2>Device sync workflows</h2>
            <p>Compress on desktop — save to cloud — open on mobile for portal upload — same file hash verify across devices.</p>
            <h2>Antivirus false positives</h2>
            <p>Rare corporate AV blocks download — whitelist ratpdf.com — retry Edge if Chrome extension interferes.</p>
            <h2>Colour stamp preservation</h2>
            <p>Immigration stamps — Less not Extreme — verify red ink visible after compress on portal preview.</p>
            <h2>Wi-Fi vs cellular</h2>
            <p>Large upload on train — may timeout — finish compress download on Wi-Fi before switching to mobile data for portal.</p>
            <h2>Filename discipline</h2>
            <p><code>Passport-Compressed-2026.pdf</code> not <code>document(1).pdf</code> — immigration officers match checklist labels.</p>
            
            
            <h2>Quarterly tool check</h2>
            <p>Portal caps change — re-read upload widget each filing season — compress level that worked last year may need Less this year if portal tightens legibility checks.</p>
            <h2>Handoff to split</h2>
            <p>If still over cap after Less — <a href="/guides/split-pdf-for-email">split for email</a> before giving up on digital submission.</p>
            <h2>Batch naming for accountants</h2>
            <p><code>Client-YYYY-MM-invoice-compressed.pdf</code> — batch compress folder sorts chronologically in AP import.</p>
            <h2>Merge-then-compress SOP</h2>
            <p>Month-end board pack: merge in agenda order → single compress → one email attachment — log final MB in board portal.</p>
            
            
            <h2>Tool chain map</h2>
            <p>OCR → compress → merge → split — pick order by portal rules. See <a href="/guides/compress-before-merge-pdf">compress vs merge</a> and <a href="/guides/pdf-to-word-vs-pdf-to-text">Word vs Text</a>.</p>
            <h2>Upgrade volume</h2>
            <p>Migration and month-end batches: <a href="/Subscription/Plans">subscription plans</a>.</p>
            
            
            <h2>Related PDF to Text guides</h2>
            <ul>
            <li><a href="/guides/pdf-to-text">PDF to Text guide</a></li>
            <li><a href="/guides/ocr-vs-pdf-to-text">OCR vs PDF to Text</a></li>
            <li><a href="/guides/pdf-to-word-vs-pdf-to-text">PDF to Word vs Text</a></li>
            <li><a href="/guides/extract-text-without-adobe">Extract text without Adobe</a></li>
            </ul>
            <p>Compare: <a href="/compare/adobe-alternative">Adobe alternative</a></p>
            
            
            <h2>Related guides</h2>
            <p>Platform-specific compression (Mac, Windows, mobile), portal upload limits, PDF to Text export, and split-for-email guides round out the compression workflow.</p>
            
            
            <h2>Post-action checklist</h2>
            <ol><li>Output file opens in viewer</li><li>Text selects if required</li><li>Size under portal/email preset</li><li>Master archived</li><li>Correct tool used for next step (text vs Word vs OCR)</li></ol>
            <p>Bookmark the <a href="/guides/pdf-tools">PDF tools guide</a> and <a href="/compare">compare tools</a> for team onboarding — consistent tool choice reduces wrong-output support tickets.</p>
            <p>Re-run size checker after every derivative step — compress, split, or text export — before deleting the previous version from your working folder.</p>
            
            <p class="mt-4"><a href="/pdf/pdftotext" class="btn btn-primary">PDF to Text free</a> · <a href="/compare/adobe-alternative">Adobe alternative</a></p>
            """;

        private const string PdfToTextBankStatements = """
            <h2>Extract text from bank statement PDF — reconciliation scripts</h2>
            <p>Export plain text from PDF for Python/Excel parsing of transaction lines — RatPDF <a href="/pdf/pdftotext">PDF to Text</a> in browser, no Adobe.</p>
            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> PDF to Text — Python/Excel parsing of transaction lines</figcaption></figure>
            <h2>Real example: Digital HDFC statement → .txt → pandas cleanup for duplicate detection</h2>
            <ol>
            <li>Test if PDF text selects — if not, OCR first.</li>
            <li>Upload to PDF to Text — download .txt.</li>
            <li>Grep, cite, or import to spreadsheet pipeline.</li>
            </ol>
            
            <h2>Digital vs scan</h2>
            <p>Netbanking PDF export — text extraction often clean. Scanned passbook — OCR first. Structured tables — consider <a href="/guides/pdf-to-excel">PDF to Excel</a>.</p>
            <h2>PII caution</h2>
            <p>Delete local .txt after reconciliation — account numbers in plain text.</p>
            <h2>Python pipeline sketch</h2>
            <p>Read .txt — regex date lines — pandas DataFrame — match to GL — document parser version in audit log.</p>
            <h2>Mortgage broker packs</h2>
            <p>Broker needs PDF authenticity — txt for broker's internal checklist only — submit bank PDF to lender.</p>
            
            
            <h2>Duplicate transaction detection</h2>
            <p>Sort .txt lines by date amount — diff against prior month export.</p>
            <h2>Multi-currency</h2>
            <p>FX symbols may OCR wrong — verify currency code against PDF visually.</p>
            
            <div class="rp-mid-cta alert alert-primary my-4"><strong>Extract text now</strong> <a href="/pdf/pdftotext" class="alert-link fw-semibold">PDF to Text →</a></div>
            
            <h2>OCR branch</h2>
            <p>Image-only PDF → <a href="/pdf/ocrpdf">OCR PDF</a> → <a href="/pdf/pdftotext">PDF to Text</a>. Decision: <a href="/guides/ocr-vs-pdf-to-text">OCR vs Text</a>.</p>
            <h2>Word vs Text</h2>
            <p>Need layout edit → <a href="/guides/pdf-to-word-vs-pdf-to-text">PDF to Word vs Text</a> · <a href="/pdf/pdftodoc">PDF to Word</a>.</p>
            <h2>Output hygiene</h2>
            <p>UTF-8 .txt — grep-friendly — delete files with PII after task. Do not email plain text bank exports unencrypted.</p>
            <h2>Developer note</h2>
            <p>Pipe .txt into Python, R, or LLM ingest — structure lost vs HTML table export — pick tool to downstream need.</p>
            
            
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
            
            
            <h2>Text extraction pipeline — Python/Excel parsing of transaction lines</h2>
            <p>Digital PDF exports text from embedded character maps. Scanned PDFs need OCR text layer first — export then pulls OCR text, not pixels.</p>
            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> PDF to Text export — Python/Excel parsing of transaction lines</figcaption></figure>
            <h2>Real workflow: grep across corpus</h2>
            <p>100 discovery PDFs → batch OCR → PDF to Text each → ripgrep privilege keyword — faster than opening each in viewer.</p>
            <h2>Second example: meta-analysis</h2>
            <p>40 journal PDFs — export abstracts to .txt — sort in spreadsheet by keyword frequency — cite from original PDF page after spot-check.</p>
            <h2>Limits</h2>
            <p>Multi-column newspaper PDF may jumble column order in .txt — manual cleanup or Word for layout-sensitive review.</p>
            <h2>Footnotes and headers</h2>
            <p>Footnotes may appear mid-paragraph in export — academic workflow keeps PDF open for page proof while .txt is note scratchpad.</p>
            <h2>Security</h2>
            <p>Transient processing — clear Downloads on shared PC — legal privilege applies to .txt same as source PDF.</p>
            <h2>Compare</h2>
            <p><a href="/compare/adobe-alternative">Adobe alternative</a> · <a href="/compare/smallpdf-alternative">Smallpdf</a> — evaluate privacy before uploading privileged PDFs.</p>
            <h2>Pillar links</h2>
            <p><a href="/guides/pdf-to-text">PDF to Text hub</a> · <a href="/guides/pdf-to-word-vs-pdf-to-text">Word vs Text</a> · <a href="/guides/ocr-vs-pdf-to-text">OCR vs Text</a>.</p>
            
            
            <h2>Output format decisions</h2>
            <p>.txt for scripts and search — DOCX for human edit — searchable PDF for archive — choose before starting batch job.</p>
            <h2>LLM ingest caution</h2>
            <p>Pasting privileged .txt into public ChatGPT may waive privilege — use enterprise AI with DPA or local models only.</p>
            <h2>Line endings</h2>
            <p>Windows Notepad vs VS Code — CRLF vs LF — downstream Python often prefers LF — normalize in editor save.</p>
            <h2>Tables in text export</h2>
            <p>Bank and invoice tables lose column alignment — expect manual delimiter fix or use Excel export path instead.</p>
            <h2>OCR language packs</h2>
            <p>Wrong OCR language garbles export — match document language on <a href="/guides/ocr-pdf">OCR PDF</a> before text step.</p>
            <h2>Research ethics</h2>
            <p>Human subjects PDFs — IRB may restrict text export off secure enclave — check protocol before export.</p>
            <h2>Quality sampling</h2>
            <p>Export 10 random PDFs — manually compare .txt to source — if error rate high fix OCR settings before batch of 500.</p>
            <h2>Retention</h2>
            <p>Delete .txt exports with PII when task ends — same policy as source PDF — do not leave on shared Downloads.</p>
            
            
            <h2>End-to-end digital PDF path</h2>
            <ol>
            <li>Confirm text selects in viewer</li>
            <li>Upload to <a href="/pdf/pdftotext">PDF to Text</a></li>
            <li>Download UTF-8 .txt</li>
            <li>Import to script, spreadsheet, or review tool</li>
            <li>Archive source PDF hash in log</li>
            </ol>
            <h2>End-to-end scanned PDF path</h2>
            <ol>
            <li>Scan 300 DPI grayscale</li>
            <li><a href="/pdf/ocrpdf">OCR PDF</a> — verify Ctrl+F</li>
            <li>PDF to Text on OCR output</li>
            <li>Spot-check amounts and names</li>
            </ol>
            <h2>When extraction returns empty</h2>
            <p>PDF is flattened image or rights-managed — request source from sender — or OCR entire document.</p>
            <h2>Compare tools</h2>
            <p><a href="/guides/pdf-to-word-vs-pdf-to-text">Word vs Text</a> · <a href="/guides/ocr-vs-pdf-to-text">OCR vs Text</a> · <a href="/guides/extract-text-without-adobe">without Adobe</a>.</p>
            
            
            <h2>Second real example: compliance audit</h2>
            <p>Auditor requests policy PDF corpus as searchable text — OCR legacy scans — export txt — grep retention keywords — findings cite page in original PDF.</p>
            <h2>Third example: journalism</h2>
            <p>FOIA PDF bundle — text export for quote extraction — attorney reads .txt draft — final story cites official PDF page scan.</p>
            <h2>Version control</h2>
            <p>Name exports <code>Contract-v3-export-2026-04-02.txt</code> — match to source PDF hash in log.</p>
            <h2>Combine with compress</h2>
            <p>Re-email extracted content inside Word doc — if DOCX huge — <a href="/guides/compress-pdf-for-email">compress</a> final PDF.</p>
            <h2>PhD thesis chapter mining</h2>
            <p>Export each chapter appendix to txt — code thematic analysis in R — spot-check 10% of codes against PDF page images for accuracy.</p>
            <h2>API boundary</h2>
            <p>RatPDF browser UI — no public text API on free tier — human upload per file for confidential docs.</p>
            
            
            <h2>Freelancer and SMB adoption</h2>
            <p>One-person firm exports client contracts to txt for clause search — no IT ticket for Acrobat — bill client for review time not software seat.</p>
            <h2>Government FOIA</h2>
            <p>Agency PDFs mix scan and digital — OCR batch then text export — redact txt derivative before publishing if contains third-party PII.</p>
            <h2>Historical newspaper PDFs</h2>
            <p>Multi-column OCR jumbles order — export still useful for keyword hit list — manual read PDF for final quote.</p>
            <h2>Medical records admin</h2>
            <p>Admin staff exports discharge summary text for coding review — PHI .txt on encrypted disk only — delete after coding session.</p>
            <h2>Patent prior art search</h2>
            <p>Export claims section to txt — grep keyword in corpus of 200 patent PDFs — attorney opens PDF only for relevant hits.</p>
            <h2>Plain-text archival</h2>
            <p>Some retention policies allow .txt at 1% size of PDF corpus — keep PDF as record copy — txt as search index only.</p>
            <h2>Upgrade prompt</h2>
            <p>Corpus migration over free daily cap — <a href="/Subscription/Plans">subscription plans</a> · Compare <a href="/compare/adobe-alternative">Adobe</a>.</p>
            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Extract text now</strong> <a href="/pdf/pdftotext" class="alert-link fw-semibold">PDF to Text →</a></div>
            
            
            <h2>Failure messages</h2>
            <p><strong>Too large:</strong> compress or split. <strong>Invalid PDF:</strong> re-export source. <strong>Unreadable:</strong> re-scan don't only compress blur.</p>
            <h2>Archive discipline</h2>
            <p>Keep uncompressed master until upload or send succeeds — derivatives are disposable.</p>
            <h2>Compare tools</h2>
            <p><a href="/compare/smallpdf-alternative">Smallpdf</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/adobe-alternative">Adobe</a>.</p>
            
            
            <h2>Device sync workflows</h2>
            <p>Compress on desktop — save to cloud — open on mobile for portal upload — same file hash verify across devices.</p>
            <h2>Antivirus false positives</h2>
            <p>Rare corporate AV blocks download — whitelist ratpdf.com — retry Edge if Chrome extension interferes.</p>
            <h2>Colour stamp preservation</h2>
            <p>Immigration stamps — Less not Extreme — verify red ink visible after compress on portal preview.</p>
            <h2>Wi-Fi vs cellular</h2>
            <p>Large upload on train — may timeout — finish compress download on Wi-Fi before switching to mobile data for portal.</p>
            <h2>Filename discipline</h2>
            <p><code>Passport-Compressed-2026.pdf</code> not <code>document(1).pdf</code> — immigration officers match checklist labels.</p>
            
            
            <h2>Quarterly tool check</h2>
            <p>Portal caps change — re-read upload widget each filing season — compress level that worked last year may need Less this year if portal tightens legibility checks.</p>
            <h2>Handoff to split</h2>
            <p>If still over cap after Less — <a href="/guides/split-pdf-for-email">split for email</a> before giving up on digital submission.</p>
            <h2>Batch naming for accountants</h2>
            <p><code>Client-YYYY-MM-invoice-compressed.pdf</code> — batch compress folder sorts chronologically in AP import.</p>
            <h2>Merge-then-compress SOP</h2>
            <p>Month-end board pack: merge in agenda order → single compress → one email attachment — log final MB in board portal.</p>
            
            
            <h2>Tool chain map</h2>
            <p>OCR → compress → merge → split — pick order by portal rules. See <a href="/guides/compress-before-merge-pdf">compress vs merge</a> and <a href="/guides/pdf-to-word-vs-pdf-to-text">Word vs Text</a>.</p>
            <h2>Upgrade volume</h2>
            <p>Migration and month-end batches: <a href="/Subscription/Plans">subscription plans</a>.</p>
            
            
            <h2>Related PDF to Text guides</h2>
            <ul>
            <li><a href="/guides/pdf-to-text">PDF to Text guide</a></li>
            <li><a href="/guides/ocr-vs-pdf-to-text">OCR vs PDF to Text</a></li>
            <li><a href="/guides/pdf-to-word-vs-pdf-to-text">PDF to Word vs Text</a></li>
            <li><a href="/guides/extract-text-without-adobe">Extract text without Adobe</a></li>
            </ul>
            <p>Compare: <a href="/compare/adobe-alternative">Adobe alternative</a></p>
            
            
            <h2>Related guides</h2>
            <p>Platform-specific compression (Mac, Windows, mobile), portal upload limits, PDF to Text export, and split-for-email guides round out the compression workflow.</p>
            
            
            <h2>Post-action checklist</h2>
            <ol><li>Output file opens in viewer</li><li>Text selects if required</li><li>Size under portal/email preset</li><li>Master archived</li><li>Correct tool used for next step (text vs Word vs OCR)</li></ol>
            <p>Bookmark the <a href="/guides/pdf-tools">PDF tools guide</a> and <a href="/compare">compare tools</a> for team onboarding — consistent tool choice reduces wrong-output support tickets.</p>
            <p>Re-run size checker after every derivative step — compress, split, or text export — before deleting the previous version from your working folder.</p>
            
            <p class="mt-4"><a href="/pdf/pdftotext" class="btn btn-primary">PDF to Text free</a> · <a href="/compare/adobe-alternative">Adobe alternative</a></p>
            """;

        private const string ExtractTextWithoutAdobe = """
            <h2>Extract text from PDF without Adobe — free browser alternative</h2>
            <p>Export plain text from PDF for copy/export text without Acrobat Pro subscription — RatPDF <a href="/pdf/pdftotext">PDF to Text</a> in browser, no Adobe.</p>
            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> PDF to Text — copy/export text without Acrobat Pro subscription</figcaption></figure>
            <h2>Real example: Freelancer extracts client brief text from PDF on Chromebook</h2>
            <ol>
            <li>Test if PDF text selects — if not, OCR first.</li>
            <li>Upload to PDF to Text — download .txt.</li>
            <li>Grep, cite, or import to spreadsheet pipeline.</li>
            </ol>
            
            <h2>Acrobat replacement path</h2>
            <p>Digital PDF: PDF to Text. Scan: OCR PDF. Edit layout: PDF to Word. Redact: <a href="/pdf-redaction">PDF Redaction</a>.</p>
            <h2>Copy-paste trap</h2>
            <p>Viewer copy loses column order on multi-column PDF — structured export beats Ctrl+A.</p>
            <h2>Subscription cost math</h2>
            <p>Acrobat Pro annual fee vs occasional RatPDF free tier — <a href="/compare/adobe-alternative">Adobe alternative</a> for teams with 3 exports/month.</p>
            <h2>Chromebook and Linux</h2>
            <p>No Windows Acrobat install — browser tools only — same workflow on ChromeOS and Ubuntu Firefox.</p>
            
            
            <h2>Team rollout</h2>
            <p>IT blocks Acrobat — standardize RatPDF browser SOP — digital vs scan decision tree poster.</p>
            <h2>Accessibility</h2>
            <p>Exported text in Notepad for speed — not substitute for tagged accessible PDF publishing.</p>
            
            <div class="rp-mid-cta alert alert-primary my-4"><strong>Extract text now</strong> <a href="/pdf/pdftotext" class="alert-link fw-semibold">PDF to Text →</a></div>
            
            <h2>OCR branch</h2>
            <p>Image-only PDF → <a href="/pdf/ocrpdf">OCR PDF</a> → <a href="/pdf/pdftotext">PDF to Text</a>. Decision: <a href="/guides/ocr-vs-pdf-to-text">OCR vs Text</a>.</p>
            <h2>Word vs Text</h2>
            <p>Need layout edit → <a href="/guides/pdf-to-word-vs-pdf-to-text">PDF to Word vs Text</a> · <a href="/pdf/pdftodoc">PDF to Word</a>.</p>
            <h2>Output hygiene</h2>
            <p>UTF-8 .txt — grep-friendly — delete files with PII after task. Do not email plain text bank exports unencrypted.</p>
            <h2>Developer note</h2>
            <p>Pipe .txt into Python, R, or LLM ingest — structure lost vs HTML table export — pick tool to downstream need.</p>
            
            
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
            
            
            <h2>Text extraction pipeline — copy/export text without Acrobat Pro subscription</h2>
            <p>Digital PDF exports text from embedded character maps. Scanned PDFs need OCR text layer first — export then pulls OCR text, not pixels.</p>
            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> PDF to Text export — copy/export text without Acrobat Pro subscription</figcaption></figure>
            <h2>Real workflow: grep across corpus</h2>
            <p>100 discovery PDFs → batch OCR → PDF to Text each → ripgrep privilege keyword — faster than opening each in viewer.</p>
            <h2>Second example: meta-analysis</h2>
            <p>40 journal PDFs — export abstracts to .txt — sort in spreadsheet by keyword frequency — cite from original PDF page after spot-check.</p>
            <h2>Limits</h2>
            <p>Multi-column newspaper PDF may jumble column order in .txt — manual cleanup or Word for layout-sensitive review.</p>
            <h2>Footnotes and headers</h2>
            <p>Footnotes may appear mid-paragraph in export — academic workflow keeps PDF open for page proof while .txt is note scratchpad.</p>
            <h2>Security</h2>
            <p>Transient processing — clear Downloads on shared PC — legal privilege applies to .txt same as source PDF.</p>
            <h2>Compare</h2>
            <p><a href="/compare/adobe-alternative">Adobe alternative</a> · <a href="/compare/smallpdf-alternative">Smallpdf</a> — evaluate privacy before uploading privileged PDFs.</p>
            <h2>Pillar links</h2>
            <p><a href="/guides/pdf-to-text">PDF to Text hub</a> · <a href="/guides/pdf-to-word-vs-pdf-to-text">Word vs Text</a> · <a href="/guides/ocr-vs-pdf-to-text">OCR vs Text</a>.</p>
            
            
            <h2>Output format decisions</h2>
            <p>.txt for scripts and search — DOCX for human edit — searchable PDF for archive — choose before starting batch job.</p>
            <h2>LLM ingest caution</h2>
            <p>Pasting privileged .txt into public ChatGPT may waive privilege — use enterprise AI with DPA or local models only.</p>
            <h2>Line endings</h2>
            <p>Windows Notepad vs VS Code — CRLF vs LF — downstream Python often prefers LF — normalize in editor save.</p>
            <h2>Tables in text export</h2>
            <p>Bank and invoice tables lose column alignment — expect manual delimiter fix or use Excel export path instead.</p>
            <h2>OCR language packs</h2>
            <p>Wrong OCR language garbles export — match document language on <a href="/guides/ocr-pdf">OCR PDF</a> before text step.</p>
            <h2>Research ethics</h2>
            <p>Human subjects PDFs — IRB may restrict text export off secure enclave — check protocol before export.</p>
            <h2>Quality sampling</h2>
            <p>Export 10 random PDFs — manually compare .txt to source — if error rate high fix OCR settings before batch of 500.</p>
            <h2>Retention</h2>
            <p>Delete .txt exports with PII when task ends — same policy as source PDF — do not leave on shared Downloads.</p>
            
            
            <h2>End-to-end digital PDF path</h2>
            <ol>
            <li>Confirm text selects in viewer</li>
            <li>Upload to <a href="/pdf/pdftotext">PDF to Text</a></li>
            <li>Download UTF-8 .txt</li>
            <li>Import to script, spreadsheet, or review tool</li>
            <li>Archive source PDF hash in log</li>
            </ol>
            <h2>End-to-end scanned PDF path</h2>
            <ol>
            <li>Scan 300 DPI grayscale</li>
            <li><a href="/pdf/ocrpdf">OCR PDF</a> — verify Ctrl+F</li>
            <li>PDF to Text on OCR output</li>
            <li>Spot-check amounts and names</li>
            </ol>
            <h2>When extraction returns empty</h2>
            <p>PDF is flattened image or rights-managed — request source from sender — or OCR entire document.</p>
            <h2>Compare tools</h2>
            <p><a href="/guides/pdf-to-word-vs-pdf-to-text">Word vs Text</a> · <a href="/guides/ocr-vs-pdf-to-text">OCR vs Text</a> · <a href="/guides/extract-text-without-adobe">without Adobe</a>.</p>
            
            
            <h2>Second real example: compliance audit</h2>
            <p>Auditor requests policy PDF corpus as searchable text — OCR legacy scans — export txt — grep retention keywords — findings cite page in original PDF.</p>
            <h2>Third example: journalism</h2>
            <p>FOIA PDF bundle — text export for quote extraction — attorney reads .txt draft — final story cites official PDF page scan.</p>
            <h2>Version control</h2>
            <p>Name exports <code>Contract-v3-export-2026-04-02.txt</code> — match to source PDF hash in log.</p>
            <h2>Combine with compress</h2>
            <p>Re-email extracted content inside Word doc — if DOCX huge — <a href="/guides/compress-pdf-for-email">compress</a> final PDF.</p>
            <h2>PhD thesis chapter mining</h2>
            <p>Export each chapter appendix to txt — code thematic analysis in R — spot-check 10% of codes against PDF page images for accuracy.</p>
            <h2>API boundary</h2>
            <p>RatPDF browser UI — no public text API on free tier — human upload per file for confidential docs.</p>
            
            
            <h2>Freelancer and SMB adoption</h2>
            <p>One-person firm exports client contracts to txt for clause search — no IT ticket for Acrobat — bill client for review time not software seat.</p>
            <h2>Government FOIA</h2>
            <p>Agency PDFs mix scan and digital — OCR batch then text export — redact txt derivative before publishing if contains third-party PII.</p>
            <h2>Historical newspaper PDFs</h2>
            <p>Multi-column OCR jumbles order — export still useful for keyword hit list — manual read PDF for final quote.</p>
            <h2>Medical records admin</h2>
            <p>Admin staff exports discharge summary text for coding review — PHI .txt on encrypted disk only — delete after coding session.</p>
            <h2>Patent prior art search</h2>
            <p>Export claims section to txt — grep keyword in corpus of 200 patent PDFs — attorney opens PDF only for relevant hits.</p>
            <h2>Plain-text archival</h2>
            <p>Some retention policies allow .txt at 1% size of PDF corpus — keep PDF as record copy — txt as search index only.</p>
            <h2>Upgrade prompt</h2>
            <p>Corpus migration over free daily cap — <a href="/Subscription/Plans">subscription plans</a> · Compare <a href="/compare/adobe-alternative">Adobe</a>.</p>
            <div class="rp-faq-cta alert alert-secondary my-4"><strong>Extract text now</strong> <a href="/pdf/pdftotext" class="alert-link fw-semibold">PDF to Text →</a></div>
            
            
            <h2>Failure messages</h2>
            <p><strong>Too large:</strong> compress or split. <strong>Invalid PDF:</strong> re-export source. <strong>Unreadable:</strong> re-scan don't only compress blur.</p>
            <h2>Archive discipline</h2>
            <p>Keep uncompressed master until upload or send succeeds — derivatives are disposable.</p>
            <h2>Compare tools</h2>
            <p><a href="/compare/smallpdf-alternative">Smallpdf</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/adobe-alternative">Adobe</a>.</p>
            
            
            <h2>Device sync workflows</h2>
            <p>Compress on desktop — save to cloud — open on mobile for portal upload — same file hash verify across devices.</p>
            <h2>Antivirus false positives</h2>
            <p>Rare corporate AV blocks download — whitelist ratpdf.com — retry Edge if Chrome extension interferes.</p>
            <h2>Colour stamp preservation</h2>
            <p>Immigration stamps — Less not Extreme — verify red ink visible after compress on portal preview.</p>
            <h2>Wi-Fi vs cellular</h2>
            <p>Large upload on train — may timeout — finish compress download on Wi-Fi before switching to mobile data for portal.</p>
            <h2>Filename discipline</h2>
            <p><code>Passport-Compressed-2026.pdf</code> not <code>document(1).pdf</code> — immigration officers match checklist labels.</p>
            
            
            <h2>Quarterly tool check</h2>
            <p>Portal caps change — re-read upload widget each filing season — compress level that worked last year may need Less this year if portal tightens legibility checks.</p>
            <h2>Handoff to split</h2>
            <p>If still over cap after Less — <a href="/guides/split-pdf-for-email">split for email</a> before giving up on digital submission.</p>
            <h2>Batch naming for accountants</h2>
            <p><code>Client-YYYY-MM-invoice-compressed.pdf</code> — batch compress folder sorts chronologically in AP import.</p>
            <h2>Merge-then-compress SOP</h2>
            <p>Month-end board pack: merge in agenda order → single compress → one email attachment — log final MB in board portal.</p>
            
            
            <h2>Tool chain map</h2>
            <p>OCR → compress → merge → split — pick order by portal rules. See <a href="/guides/compress-before-merge-pdf">compress vs merge</a> and <a href="/guides/pdf-to-word-vs-pdf-to-text">Word vs Text</a>.</p>
            <h2>Upgrade volume</h2>
            <p>Migration and month-end batches: <a href="/Subscription/Plans">subscription plans</a>.</p>
            
            
            <h2>Related PDF to Text guides</h2>
            <ul>
            <li><a href="/guides/pdf-to-text">PDF to Text guide</a></li>
            <li><a href="/guides/ocr-vs-pdf-to-text">OCR vs PDF to Text</a></li>
            <li><a href="/guides/pdf-to-word-vs-pdf-to-text">PDF to Word vs Text</a></li>
            <li><a href="/guides/extract-text-without-adobe">Extract text without Adobe</a></li>
            </ul>
            <p>Compare: <a href="/compare/adobe-alternative">Adobe alternative</a></p>
            
            
            <h2>Related guides</h2>
            <p>Platform-specific compression (Mac, Windows, mobile), portal upload limits, PDF to Text export, and split-for-email guides round out the compression workflow.</p>
            
            
            <h2>Post-action checklist</h2>
            <ol><li>Output file opens in viewer</li><li>Text selects if required</li><li>Size under portal/email preset</li><li>Master archived</li><li>Correct tool used for next step (text vs Word vs OCR)</li></ol>
            <p>Bookmark the <a href="/guides/pdf-tools">PDF tools guide</a> and <a href="/compare">compare tools</a> for team onboarding — consistent tool choice reduces wrong-output support tickets.</p>
            <p>Re-run size checker after every derivative step — compress, split, or text export — before deleting the previous version from your working folder.</p>
            
            <p class="mt-4"><a href="/pdf/pdftotext" class="btn btn-primary">PDF to Text free</a> · <a href="/compare/adobe-alternative">Adobe alternative</a></p>
            """;

        private const string SplitPdfForEmail = """
            <h2>Split PDF for email — when attachment is too large</h2>
            <p>Divide oversized PDFs when compression is not enough — RatPDF <a href="/pdf/split">Split PDF</a> by page range.</p>
            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> Split PDF page range selector</figcaption></figure>
            <h2>Real example: 120-page discovery PDF → Part 1–3 under 20 MB each for Gmail</h2>
            <ol>
            <li>Note total pages and target MB per part.</li>
            <li>Split at logical boundaries.</li>
            <li>Label Part 1 of N — email with index in body.</li>
            </ol>
            
            <h2>When split beats compress</h2>
            <p>Legal scans where Extreme blurs footnotes — split into Part 1/2/3 with cover email listing parts. Recipient merges locally if needed.</p>
            <h2>Naming convention</h2>
            <p><code>Report-Part1-of-3.pdf</code> — AP clerks reassemble correctly.</p>
            <h2>Compress first try</h2>
            <p>Always try <a href="/guides/compress-pdf-for-email">compress for email</a> before split — one attachment preferred.</p>
            <h2>Outlook and Gmail UX</h2>
            <p>Three attachments confuse mobile recipients — numbered filenames and short index paragraph in email body reduce support calls.</p>
            <h2>Discovery to opposing counsel</h2>
            <p>Agree split index in meet-and-confer — Bates range per part — avoid duplicate Bates across parts.</p>
            
            
            <h2>Client communication template</h2>
            <p>Subject: <em>Board pack Part 1 of 3 — pages 1–35</em> — body lists parts with page ranges.</p>
            <h2>Read receipt follow-up</h2>
            <p>Confirm all parts received before meeting — resend missing part only.</p>
            <h2>Mobile recipients</h2>
            <p>Warn iPhone users to download all parts on Wi-Fi before flight — streaming preview fails offline.</p>
            
            <div class="rp-mid-cta alert alert-primary my-4"><strong>Split your PDF now</strong> <a href="/pdf/split" class="alert-link fw-semibold">Split PDF →</a></div>
            
            <h2>Merge after split?</h2>
            <p>Recipient can <a href="/guides/merge-pdf-online">merge PDF</a> parts locally — include page range in email body.</p>
            <h2>Compress before split?</h2>
            <p>Try <a href="/pdf/compress">Compress PDF</a> first — split only when quality cannot drop further.</p>
            <h2>Page range planning</h2>
            <p>Split at chapter boundaries not arbitrary page 50 — readers navigate parts logically.</p>
            <h2>Watermark and split</h2>
            <p>Draft watermarks on full PDF carry to each part — acceptable for internal review splits — remove watermark before external production.</p>
            <h2>Password on output</h2>
            <p>Password-protect each part if confidential — communicate password out-of-band not same email thread.</p>
            
            
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
            
            
            <h2>Split workflow deep dive — Split PDF for email — when attachment is too large</h2>
            <p>Splitting preserves per-page quality — unlike Extreme compress on legal scans. Trade-off: recipient manages multiple files.</p>
            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> Split PDF — Split PDF for email — when attachment is too large</figcaption></figure>
            <h2>Compress vs split decision</h2>
            <p>Try Recommended compress first — if footnotes blur at 150% zoom, revert to original and split instead.</p>
            <h2>Second example: board pack email</h2>
            <p>90 MB board PDF — compress blurs charts — split into Part 1 narrative Part 2 financials — both under 20 MB.</p>
            <h2>Password protected sources</h2>
            <p>Unlock before split — <a href="/guides/unlock-pdf">Unlock PDF</a> — encrypted files fail split queue.</p>
            <h2>Hyperlinks after split</h2>
            <p>Internal links breaking across parts — note in email "bookmarks in Part 1 only" — recipient opens full set.</p>
            <h2>Free tier</h2>
            <p>Three splits per day — board season needs <a href="/Subscription/Plans">plans</a>.</p>
            
            
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
            
            
            <h2>Failure messages</h2>
            <p><strong>Too large:</strong> compress or split. <strong>Invalid PDF:</strong> re-export source. <strong>Unreadable:</strong> re-scan don't only compress blur.</p>
            <h2>Archive discipline</h2>
            <p>Keep uncompressed master until upload or send succeeds — derivatives are disposable.</p>
            <h2>Compare tools</h2>
            <p><a href="/compare/smallpdf-alternative">Smallpdf</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/adobe-alternative">Adobe</a>.</p>
            
            
            <h2>Device sync workflows</h2>
            <p>Compress on desktop — save to cloud — open on mobile for portal upload — same file hash verify across devices.</p>
            <h2>Antivirus false positives</h2>
            <p>Rare corporate AV blocks download — whitelist ratpdf.com — retry Edge if Chrome extension interferes.</p>
            <h2>Colour stamp preservation</h2>
            <p>Immigration stamps — Less not Extreme — verify red ink visible after compress on portal preview.</p>
            <h2>Wi-Fi vs cellular</h2>
            <p>Large upload on train — may timeout — finish compress download on Wi-Fi before switching to mobile data for portal.</p>
            <h2>Filename discipline</h2>
            <p><code>Passport-Compressed-2026.pdf</code> not <code>document(1).pdf</code> — immigration officers match checklist labels.</p>
            
            
            <h2>Quarterly tool check</h2>
            <p>Portal caps change — re-read upload widget each filing season — compress level that worked last year may need Less this year if portal tightens legibility checks.</p>
            <h2>Handoff to split</h2>
            <p>If still over cap after Less — <a href="/guides/split-pdf-for-email">split for email</a> before giving up on digital submission.</p>
            <h2>Batch naming for accountants</h2>
            <p><code>Client-YYYY-MM-invoice-compressed.pdf</code> — batch compress folder sorts chronologically in AP import.</p>
            <h2>Merge-then-compress SOP</h2>
            <p>Month-end board pack: merge in agenda order → single compress → one email attachment — log final MB in board portal.</p>
            
            
            <h2>Tool chain map</h2>
            <p>OCR → compress → merge → split — pick order by portal rules. See <a href="/guides/compress-before-merge-pdf">compress vs merge</a> and <a href="/guides/pdf-to-word-vs-pdf-to-text">Word vs Text</a>.</p>
            <h2>Upgrade volume</h2>
            <p>Migration and month-end batches: <a href="/Subscription/Plans">subscription plans</a>.</p>
            
            
            <h2>Related split guides</h2>
            <ul>
            <li><a href="/guides/split-pdf">Split PDF guide</a></li>
            <li><a href="/guides/split-pdf-for-email">Split for email</a></li>
            <li><a href="/guides/split-pdf-by-size">Split by size</a></li>
            <li><a href="/guides/compress-pdf-for-email">Compress for email</a></li>
            </ul>
            <p>Research: <a href="/research/attachment-size-limits">Attachment size limits</a></p>
            
            
            <h2>Related guides</h2>
            <p>Platform-specific compression (Mac, Windows, mobile), portal upload limits, PDF to Text export, and split-for-email guides round out the compression workflow.</p>
            
            
            <h2>Post-action checklist</h2>
            <ol><li>Output file opens in viewer</li><li>Text selects if required</li><li>Size under portal/email preset</li><li>Master archived</li><li>Correct tool used for next step (text vs Word vs OCR)</li></ol>
            <p>Bookmark the <a href="/guides/pdf-tools">PDF tools guide</a> and <a href="/compare">compare tools</a> for team onboarding — consistent tool choice reduces wrong-output support tickets.</p>
            <p>Re-run size checker after every derivative step — compress, split, or text export — before deleting the previous version from your working folder.</p>
            
            <p class="mt-4"><a href="/pdf/split" class="btn btn-primary">Split PDF free</a> · <a href="/guides/compress-pdf-for-email">Try compress first</a></p>
            """;

        private const string SplitPdfBySize = """
            <h2>Split PDF by size — chunk files under MB limits</h2>
            <p>Divide oversized PDFs when compression is not enough — RatPDF <a href="/pdf/split">Split PDF</a> by page range.</p>
            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> Split PDF page range selector</figcaption></figure>
            <h2>Real example: Portal max 5 MB — split every ~40 pages until each part under cap</h2>
            <ol>
            <li>Note total pages and target MB per part.</li>
            <li>Split at logical boundaries.</li>
            <li>Label Part 1 of N — email with index in body.</li>
            </ol>
            
            <h2>Size checker driven split</h2>
            <p>Upload to <a href="/pdf-size-checker">PDF size checker</a> — note pages per MB — plan split ranges in <a href="/pdf/split">Split PDF</a> tool.</p>
            <h2>Portal multi-slot</h2>
            <p>Some portals allow 5×5 MB — split to exact cap not equal page counts.</p>
            <h2>Uneven page density</h2>
            <p>Photo-heavy pages 2 MB each text pages 50 KB — split ranges by size trial not equal 20-page chunks.</p>
            <h2>Automated iteration</h2>
            <p>Split 1–30, check size, if over cap split 1–20 and 21–30 — manual iteration until each part passes checker.</p>
            
            
            <h2>Binary search split strategy</h2>
            <p>Try 1–50 export size — if over cap try 1–40 — iterate until each part passes checker.</p>
            <h2>Portal upload order</h2>
            <p>Prepare all parts locally before starting portal session — timeouts lock mid-upload.</p>
            <h2>Document manifest</h2>
            <p>Spreadsheet column: part filename, pages, MB, upload timestamp — audit trail for government multi-slot filings.</p>
            
            <div class="rp-mid-cta alert alert-primary my-4"><strong>Split your PDF now</strong> <a href="/pdf/split" class="alert-link fw-semibold">Split PDF →</a></div>
            
            <h2>Merge after split?</h2>
            <p>Recipient can <a href="/guides/merge-pdf-online">merge PDF</a> parts locally — include page range in email body.</p>
            <h2>Compress before split?</h2>
            <p>Try <a href="/pdf/compress">Compress PDF</a> first — split only when quality cannot drop further.</p>
            <h2>Page range planning</h2>
            <p>Split at chapter boundaries not arbitrary page 50 — readers navigate parts logically.</p>
            <h2>Watermark and split</h2>
            <p>Draft watermarks on full PDF carry to each part — acceptable for internal review splits — remove watermark before external production.</p>
            <h2>Password on output</h2>
            <p>Password-protect each part if confidential — communicate password out-of-band not same email thread.</p>
            
            
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
            
            
            <h2>Split workflow deep dive — Split PDF by size — chunk files under MB limits</h2>
            <p>Splitting preserves per-page quality — unlike Extreme compress on legal scans. Trade-off: recipient manages multiple files.</p>
            <figure class="rp-screenshot-placeholder border rounded p-3 mb-4 text-muted small"><figcaption><strong>Screenshot placeholder:</strong> Split PDF — Split PDF by size — chunk files under MB limits</figcaption></figure>
            <h2>Compress vs split decision</h2>
            <p>Try Recommended compress first — if footnotes blur at 150% zoom, revert to original and split instead.</p>
            <h2>Second example: board pack email</h2>
            <p>90 MB board PDF — compress blurs charts — split into Part 1 narrative Part 2 financials — both under 20 MB.</p>
            <h2>Password protected sources</h2>
            <p>Unlock before split — <a href="/guides/unlock-pdf">Unlock PDF</a> — encrypted files fail split queue.</p>
            <h2>Hyperlinks after split</h2>
            <p>Internal links breaking across parts — note in email "bookmarks in Part 1 only" — recipient opens full set.</p>
            <h2>Free tier</h2>
            <p>Three splits per day — board season needs <a href="/Subscription/Plans">plans</a>.</p>
            
            
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
            
            
            <h2>Failure messages</h2>
            <p><strong>Too large:</strong> compress or split. <strong>Invalid PDF:</strong> re-export source. <strong>Unreadable:</strong> re-scan don't only compress blur.</p>
            <h2>Archive discipline</h2>
            <p>Keep uncompressed master until upload or send succeeds — derivatives are disposable.</p>
            <h2>Compare tools</h2>
            <p><a href="/compare/smallpdf-alternative">Smallpdf</a> · <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/adobe-alternative">Adobe</a>.</p>
            
            
            <h2>Device sync workflows</h2>
            <p>Compress on desktop — save to cloud — open on mobile for portal upload — same file hash verify across devices.</p>
            <h2>Antivirus false positives</h2>
            <p>Rare corporate AV blocks download — whitelist ratpdf.com — retry Edge if Chrome extension interferes.</p>
            <h2>Colour stamp preservation</h2>
            <p>Immigration stamps — Less not Extreme — verify red ink visible after compress on portal preview.</p>
            <h2>Wi-Fi vs cellular</h2>
            <p>Large upload on train — may timeout — finish compress download on Wi-Fi before switching to mobile data for portal.</p>
            <h2>Filename discipline</h2>
            <p><code>Passport-Compressed-2026.pdf</code> not <code>document(1).pdf</code> — immigration officers match checklist labels.</p>
            
            
            <h2>Quarterly tool check</h2>
            <p>Portal caps change — re-read upload widget each filing season — compress level that worked last year may need Less this year if portal tightens legibility checks.</p>
            <h2>Handoff to split</h2>
            <p>If still over cap after Less — <a href="/guides/split-pdf-for-email">split for email</a> before giving up on digital submission.</p>
            <h2>Batch naming for accountants</h2>
            <p><code>Client-YYYY-MM-invoice-compressed.pdf</code> — batch compress folder sorts chronologically in AP import.</p>
            <h2>Merge-then-compress SOP</h2>
            <p>Month-end board pack: merge in agenda order → single compress → one email attachment — log final MB in board portal.</p>
            
            
            <h2>Tool chain map</h2>
            <p>OCR → compress → merge → split — pick order by portal rules. See <a href="/guides/compress-before-merge-pdf">compress vs merge</a> and <a href="/guides/pdf-to-word-vs-pdf-to-text">Word vs Text</a>.</p>
            <h2>Upgrade volume</h2>
            <p>Migration and month-end batches: <a href="/Subscription/Plans">subscription plans</a>.</p>
            
            
            <h2>Related split guides</h2>
            <ul>
            <li><a href="/guides/split-pdf">Split PDF guide</a></li>
            <li><a href="/guides/split-pdf-for-email">Split for email</a></li>
            <li><a href="/guides/split-pdf-by-size">Split by size</a></li>
            <li><a href="/guides/compress-pdf-for-email">Compress for email</a></li>
            </ul>
            <p>Research: <a href="/research/attachment-size-limits">Attachment size limits</a></p>
            
            
            <h2>Related guides</h2>
            <p>Platform-specific compression (Mac, Windows, mobile), portal upload limits, PDF to Text export, and split-for-email guides round out the compression workflow.</p>
            
            
            <h2>Post-action checklist</h2>
            <ol><li>Output file opens in viewer</li><li>Text selects if required</li><li>Size under portal/email preset</li><li>Master archived</li><li>Correct tool used for next step (text vs Word vs OCR)</li></ol>
            <p>Bookmark the <a href="/guides/pdf-tools">PDF tools guide</a> and <a href="/compare">compare tools</a> for team onboarding — consistent tool choice reduces wrong-output support tickets.</p>
            <p>Re-run size checker after every derivative step — compress, split, or text export — before deleting the previous version from your working folder.</p>
            
            <p class="mt-4"><a href="/pdf/split" class="btn btn-primary">Split PDF free</a> · <a href="/guides/compress-pdf-for-email">Try compress first</a></p>
            """;

    }
}
