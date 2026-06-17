namespace ratpdf.Content
{
    /// <summary>Extended guide bodies for P0/P1 cluster spokes (compress, invoice, merge, OCR, etc.).</summary>
    internal static class GuideBodiesExtended
    {
        public static string? Get(string slug) => slug switch
        {
            "compress-pdf-for-email" => CompressPdfForEmail,
            "compress-pdf-for-gmail" => CompressPdfForGmail,
            "compress-pdf-for-outlook" => CompressPdfForOutlook,
            "compress-pdf-for-linkedin" => CompressPdfForLinkedin,
            "invoice-generator-india" => InvoiceGeneratorIndia,
            "compress-pdf-for-indeed" => CompressPdfForIndeed,
            "compress-pdf-for-naukri" => CompressPdfForNaukri,
            "compress-pdf-for-yahoo-mail" => CompressPdfForYahooMail,
            "compress-pdf-for-protonmail" => CompressPdfForProtonmail,
            "compress-pdf-for-whatsapp" => CompressPdfForWhatsapp,
            "compress-pdf-for-job-application" => CompressPdfForJobApplication,
            "compress-pdf-for-telegram" => CompressPdfForTelegram,
            "compress-pdf-for-workday" => CompressPdfForWorkday,
            "compress-pdf-for-lms" => CompressPdfForLms,
            "compress-pdf-for-visa-application" => CompressPdfForVisaApplication,
            "invoice-generator-usa" => InvoiceGeneratorUsa,
            _ => GuideBodiesWave1.Get(slug) ?? GuideBodiesWave2.Get(slug) ?? GuideBodiesWave3.Get(slug) ?? GuideBodiesWave4.Get(slug) ?? GuideBodiesWave5.Get(slug) ?? GuideBodiesWave6.Get(slug) ?? GuideBodiesWave8.Get(slug) ?? GuideBodiesWave9.Get(slug) ?? GuideBodiesWave10.Get(slug) ?? GuideBodiesWave11.Get(slug) ?? GuideBodiesWave12.Get(slug) ?? GuideBodiesWave13.Get(slug) ?? GuideBodiesWave14.Get(slug) ?? GuideBodiesWave15.Get(slug) ?? GuideBodiesWave15B.Get(slug) ?? GuideBodiesWave16.Get(slug) ?? GuideBodiesWave16B.Get(slug) ?? GuideBodiesWave17.Get(slug) ?? GuideBodiesWave18.Get(slug) ?? GuideBodiesWave19.Get(slug) ?? GuideBodiesWave20.Get(slug) ?? GuideBodiesWave21.Get(slug) ?? GuideBodiesWave22.Get(slug) ?? GuideBodiesWave23.Get(slug) ?? GuideBodiesWave24.Get(slug) ?? GuideBodiesWave25.Get(slug) ?? GuideBodiesWave26.Get(slug) ?? GuideBodiesWave27.Get(slug) ?? GuideBodiesWave28.Get(slug) ?? GuideBodiesWave29.Get(slug) ?? GuideBodiesWave30.Get(slug) ?? GuideBodiesWave31.Get(slug) ?? GuideBodiesWave32.Get(slug) ?? GuideBodiesWave33.Get(slug) ?? GuideBodiesWave34.Get(slug) ?? GuideBodiesWave35.Get(slug) ?? GuideBodiesWave36.Get(slug) ?? GuideBodiesWave37.Get(slug) ?? GuideBodiesWave38.Get(slug) ?? GuideBodiesWave39.Get(slug) ?? GuideBodiesWave40.Get(slug) ?? GuideBodiesWave41.Get(slug) ?? GuideBodiesWave42.Get(slug) ?? GuideBodiesWave43.Get(slug) ?? GuideBodiesWave44.Get(slug) ?? GuideBodiesWave45.Get(slug) ?? GuideBodiesWave46.Get(slug) ?? GuideBodiesWave47.Get(slug) ?? GuideBodiesWave48.Get(slug) ?? GuideBodiesWave49.Get(slug) ?? GuideBodiesWave50.Get(slug) ?? GuideBodiesWave51.Get(slug) ?? GuideBodiesWave52.Get(slug) ?? GuideBodiesWave53.Get(slug) ?? GuideBodiesWave54.Get(slug) ?? GuideBodiesWave55.Get(slug) ?? GuideBodiesWave56.Get(slug) ?? GuideBodiesWave57.Get(slug) ?? GuideBodiesWave58.Get(slug) ?? GuideBodiesWave59.Get(slug) ?? GuideBodiesWave60.Get(slug) ?? GuideBodiesWave61.Get(slug) ?? GuideBodiesWave62.Get(slug) ?? GuideBodiesWave63.Get(slug) ?? GuideBodiesMedicalImageDev.Get(slug) ?? GuideBodiesGenerated.Get(slug)
        };

        private const string CompressPdfForEmail = """
            <h2>Why your PDF is too large for email</h2>
            <p>Email clients do not measure attachments the way your file explorer does. When you attach a PDF, the message is encoded (typically Base64), which adds roughly <strong>33% overhead</strong> to the raw file size. A 20 MB PDF can push the total message past a 25 MB provider cap before you account for subject lines, signatures, and HTML formatting.</p>
            <p>Corporate gateways add another layer. Many organisations enforce limits between <strong>10 MB and 20 MB</strong> even when Gmail or Outlook technically allows more. If a recipient's server rejects the message, you see a bounce like "attachment too large" or "message size exceeds maximum" — often with no indication of the exact limit.</p>
            <p>The fix is usually compression, not retyping the document. RatPDF's <a href="/pdf/compress">Compress PDF</a> tool uses <strong>Ghostscript</strong> — the same engine behind many print workflows — to re-encode embedded images and strip redundant objects while keeping text readable. This guide walks through provider limits, compression levels, and when to <a href="/guides/split-pdf-for-email">split</a> or share a link instead.</p>

            <h2>Email attachment size limits (2026 reference)</h2>
            <p>Always aim for a <strong>safety margin</strong> below the published cap. We recommend targeting <strong>under 20 MB</strong> for Gmail and Outlook, and <strong>under 10 MB</strong> when emailing law firms, banks, or government offices where gateway limits are unknown.</p>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>Provider</th><th>Published cap</th><th>Safe target for PDFs</th><th>Notes</th></tr></thead>
            <tbody>
            <tr><td>Gmail</td><td>25 MB per message</td><td>18–20 MB raw file</td><td>Encoding overhead matters; see <a href="/guides/compress-pdf-for-gmail">Gmail-specific guide</a></td></tr>
            <tr><td>Outlook / Microsoft 365</td><td>20–34 MB (admin-configurable)</td><td>15–18 MB</td><td>Default tenant limit is often 20 MB — <a href="/guides/compress-pdf-for-outlook">Outlook guide</a></td></tr>
            <tr><td>Yahoo Mail</td><td>25 MB</td><td>18–20 MB</td><td><a href="/guides/compress-pdf-for-yahoo-mail">Yahoo Mail guide</a></td></tr>
            <tr><td>Proton Mail</td><td>25 MB (paid) / 1 MB (free)</td><td>Plan-dependent</td><td><a href="/guides/compress-pdf-for-protonmail">Proton Mail guide</a></td></tr>
            <tr><td>Corporate SMTP gateways</td><td>Often 10–20 MB</td><td>8–15 MB</td><td>Ask IT if bounces persist after compression</td></tr>
            </tbody>
            </table></div>
            <p>Full source-linked table: <a href="/research/attachment-size-limits">PDF &amp; email attachment size limits (2026)</a>. Use the <a href="/pdf-size-checker">PDF size checker</a> to compare your file against a preset before you hit Send.</p>

            <h2>Step-by-step: compress a PDF for email</h2>
            <ol>
            <li><strong>Check the current size.</strong> Right-click the PDF in Explorer or Finder, or upload to the <a href="/pdf-size-checker">size checker</a> and select your email provider preset.</li>
            <li><strong>Open <a href="/pdf/compress">Compress PDF</a>.</strong> Drag the file into the upload zone. Free tier: 3 compressions per day, files up to 50 MB. Pro raises limits to 100 MB per file (and higher on merge workflows).</li>
            <li><strong>Choose Recommended compression.</strong> This is the default balance — 150 dpi images, good JPEG quality, typically 40–65% reduction on photo-heavy PDFs. Text-only digital PDFs may shrink less; that is normal.</li>
            <li><strong>Run compression and review the report.</strong> RatPDF shows original size, compressed size, and percentage saved. If still over your target, try Extreme — but verify fine print at 100% zoom first.</li>
            <li><strong>Download and re-check size.</strong> Confirm the compressed file opens correctly (page count, bookmarks, hyperlinks).</li>
            <li><strong>Attach and send.</strong> Keep the original archived locally; email the compressed copy only.</li>
            </ol>
            <p>For multi-document bundles (three contracts + exhibits), <a href="/guides/merge-pdf">merge PDFs first</a>, then compress once — see <a href="/guides/compress-before-merge-pdf">compress before or after merge</a> for ordering advice.</p>

            <h2>Choosing the right compression level</h2>
            <p>RatPDF offers three Ghostscript presets. Pick based on document type, not guesswork:</p>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>Level</th><th>Typical reduction</th><th>Best for email when…</th></tr></thead>
            <tbody>
            <tr><td><strong>Less Compression</strong></td><td>10–30%</td><td>Legal contracts, signed exhibits, or brand decks where logos must stay sharp. May not be enough alone for a 40 MB scan.</td></tr>
            <tr><td><strong>Recommended</strong> (default)</td><td>40–65%</td><td>Most email attachments: proposals, HR packs, invoices, mixed text-and-image PDFs.</td></tr>
            <tr><td><strong>Extreme Compression</strong></td><td>70–90%</td><td>Last resort when a portal or gateway still rejects the file. Verify stamps, signatures, and footnotes at full zoom.</td></tr>
            </tbody>
            </table></div>
            <p>Benchmark data by document type: <a href="/research/pdf-compression-benchmark">PDF compression benchmark</a>. Pillar guide: <a href="/guides/compress-pdf-guide">how to compress PDF online</a>.</p>
            <p><strong>Scanned PDFs</strong> (phone photos of receipts, signed forms) compress dramatically because images dominate file size — often the biggest wins for email. <strong>Digital PDFs</strong> exported from Word or InDesign may only drop 10–25% at Recommended; if still too large, the content is likely high-resolution photography — try Extreme or <a href="/guides/split-pdf-for-email">split by chapter</a>.</p>

            <h2>Compress vs split vs cloud link — decision tree</h2>
            <p>Not every oversized PDF should be squeezed harder. Use this decision path:</p>
            <ol>
            <li><strong>Is the PDF under 2× your target size?</strong> → Compress with Recommended. Done in most cases.</li>
            <li><strong>Is it a long scanned document (50+ pages) and still over limit after Recommended?</strong> → Try Extreme once. If fine print blurs, <a href="/guides/split-pdf-for-email">split into Part 1 / Part 2</a> or <a href="/guides/split-pdf-by-size">split by size</a> instead.</li>
            <li><strong>Is it a portfolio, annual report, or photo archive where quality is non-negotiable?</strong> → Compress a "review copy" for email; share the full file via cloud storage (Drive, Dropbox, OneDrive) with a link in the email body. See <a href="/guides/compress-pdf-cloud-storage">compress for cloud storage</a> for archive vs share-copy workflow.</li>
            <li><strong>Are you sending to an ATS or job portal, not email?</strong> → Caps are often 2–5 MB. Use <a href="/guides/compress-pdf-for-indeed">Indeed</a>, <a href="/guides/compress-pdf-for-linkedin">LinkedIn</a>, or <a href="/guides/compress-pdf-for-job-application">job application</a> guides — not this page alone.</li>
            </ol>
            <p>Compare strategies: <a href="/guides/compress-vs-split">compress vs split</a> · <a href="/guides/merge-vs-compress">merge vs compress</a>.</p>

            <h2>Gmail: compress and send without rejection</h2>
            <p>Gmail's published limit is <strong>25 MB per message</strong>, but encoding overhead means practical PDF attachments should stay near <strong>18–20 MB</strong>. Gmail does not offer a built-in PDF compressor — you must shrink the file before attaching.</p>
            <h3>Gmail workflow</h3>
            <ol>
            <li>Compress with Recommended on RatPDF.</li>
            <li>If Gmail still warns "file is too large," switch to Extreme or remove non-essential pages via <a href="/guides/split-pdf">Split PDF</a>.</li>
            <li>Alternatively, upload to Google Drive and use Gmail's "Insert Drive link" — the attachment limit no longer applies, but recipients need Drive access.</li>
            </ol>
            <p>Detailed walkthrough: <a href="/guides/compress-pdf-for-gmail">compress PDF for Gmail</a>. Checklist: <a href="/guides/pdf-email-attachment-checklist">PDF email attachment checklist</a>.</p>

            <h2>Outlook and Microsoft 365</h2>
            <p>Outlook desktop, Outlook on the web, and Microsoft 365 share tenant-configured limits. Default deployments often cap at <strong>20 MB</strong>; admins can raise to 34 MB. Large Attachment (OneDrive upload) bypasses the cap by sending a link — behaviour depends on your organisation's policy.</p>
            <h3>Outlook workflow</h3>
            <ol>
            <li>Target <strong>15–18 MB</strong> after compression for maximum compatibility.</li>
            <li>Compress with Recommended; verify in Outlook's attachment preview before send.</li>
            <li>If your firm uses transport rules that strip large attachments, ask IT for the gateway limit — compressing to 10 MB is a safe fallback.</li>
            </ol>
            <p>Full guide: <a href="/guides/compress-pdf-for-outlook">compress PDF for Outlook</a>.</p>

            <h2>Corporate email gateways and B2B sends</h2>
            <p>When emailing law firms, insurers, banks, or procurement teams, assume a <strong>10–15 MB</strong> ceiling unless the recipient confirms otherwise. These organisations often run Proofpoint, Mimecast, or similar filters that reject oversized messages silently or delay delivery.</p>
            <ul>
            <li><strong>Accountants and auditors:</strong> <a href="/guides/compress-pdf-accountants">compress PDF for accountants</a> — workpapers and TB exports.</li>
            <li><strong>Lawyers and paralegals:</strong> <a href="/guides/compress-pdf-lawyers">compress PDF for lawyers</a> — discovery packets and court exhibits.</li>
            <li><strong>HR and onboarding:</strong> <a href="/guides/compress-pdf-hr">compress PDF for HR</a> — policy packs and offer letters.</li>
            <li><strong>Insurance claims:</strong> <a href="/guides/compress-pdf-insurance-claims">compress PDF for insurance claims</a> — photos and adjuster reports.</li>
            </ul>
            <p>For regulated attachments, keep an uncompressed master in your DMS; email only the compressed delivery copy.</p>

            <h2>Scanned documents and phone photos</h2>
            <p>Mobile scan apps often save at 300 dpi colour even for black-and-white text. That is why a 12-page lease can weigh 25 MB. Before compression:</p>
            <ul>
            <li>Re-scan in <strong>grayscale</strong> or <strong>document mode</strong> if you control the source.</li>
            <li>Crop empty margins in the scan app — fewer pixels means smaller files.</li>
            <li>Run Recommended compression; expect 50–70% reduction on typical phone scans.</li>
            </ul>
            <p>If stamps or handwritten signatures must stay crisp, use Less compression and split if still over limit. More: <a href="/guides/compress-scanned-vs-digital-pdf">compress scanned vs digital PDF</a> · <a href="/guides/why-is-pdf-file-so-large">why is my PDF so large?</a></p>

            <h2>Troubleshooting: still too large after compression</h2>
            <ul>
            <li><strong>File grew after compression?</strong> Rare on RatPDF (output is never larger than input), but embedded fonts or malformed PDFs can behave oddly. See <a href="/guides/compress-pdf-made-it-larger">why compression made PDF larger</a>.</li>
            <li><strong>Recommended barely changed size?</strong> The PDF may be text-only with embedded fonts — try Extreme, or export a new PDF from the source application.</li>
            <li><strong>Extreme blurs fine print?</strong> Do not send a unreadable legal doc — <a href="/guides/split-pdf-for-email">split for email</a> instead.</li>
            <li><strong>Password-protected PDF?</strong> <a href="/guides/unlock-pdf">Unlock PDF</a> first; compression may fail on encrypted files.</li>
            <li><strong>Multiple PDFs in one email?</strong> Compress each file separately; attach only what the recipient needs.</li>
            </ul>

            <h2>Security and privacy when emailing PDFs</h2>
            <p>Compression does not remove sensitive data — it only reduces bytes. Before emailing financial statements, medical records, or HR files:</p>
            <ul>
            <li><strong>Password-protect</strong> confidential PDFs: <a href="/guides/password-protect-pdf">password protect PDF</a>. Share the password on a separate channel (phone or SMS).</li>
            <li><strong>Redact</strong> before send if the document contains third-party PII: <a href="/guides/pdf-redaction">PDF redaction guide</a>.</li>
            <li><strong>RatPDF processing:</strong> files are transmitted over HTTPS, processed on the server, and deleted after download — no long-term storage on free tier.</li>
            </ul>
            <p>Remote-team policy template: <a href="/blog/remote-work-pdf-security">remote work PDF security</a> · Guide: <a href="/guides/secure-pdf-workflow">secure PDF workflow</a>.</p>

            <h2>Batch compression for teams</h2>
            <p>Sending five vendor invoices to finance? Free tier allows 3 compressions per tool per day — batch the highest-priority files first, or upgrade to Pro for unlimited daily use. Workflow: <a href="/guides/batch-compress-pdf">batch compress PDF files</a>. After compressing, consider <a href="/guides/merge-pdf">merging</a> related docs into one email attachment if the combined size still fits.</p>

            <h2>Before you hit Send — checklist</h2>
            <ol>
            <li>Compressed file is under your provider's safe target (use <a href="/pdf-size-checker">size checker</a>).</li>
            <li>Page count matches the original; no blank pages inserted.</li>
            <li>Hyperlinks and bookmarks still work (click-test one or two).</li>
            <li>Signatures, stamps, and fine print readable at 100% zoom.</li>
            <li>Filename is professional: <code>Smith_Proposal_2026.pdf</code>, not <code>scan_compressed_final2.pdf</code>.</li>
            <li>Original archived; only the compressed copy is emailed.</li>
            </ol>
            <p>Printable workflow: <a href="/guides/pdf-email-attachment-checklist">PDF email attachment checklist</a>.</p>

            <h2>Related guides by destination</h2>
            <p>This page covers email-sized PDF workflows. Platform-specific steps are in the linked guides below:</p>
            <ul>
            <li><a href="/guides/compress-pdf-for-gmail">Gmail</a> · <a href="/guides/compress-pdf-for-outlook">Outlook</a> · <a href="/guides/compress-pdf-for-yahoo-mail">Yahoo Mail</a> · <a href="/guides/compress-pdf-for-protonmail">Proton Mail</a></li>
            <li><a href="/guides/compress-pdf-for-whatsapp">WhatsApp</a> · <a href="/guides/compress-pdf-for-telegram">Telegram</a> · <a href="/guides/compress-pdf-for-linkedin">LinkedIn</a></li>
            <li><a href="/guides/compress-pdf-for-indeed">Indeed</a> · <a href="/guides/compress-pdf-for-naukri">Naukri</a> · <a href="/guides/compress-pdf-for-job-application">Job applications</a></li>
            <li><a href="/guides/compress-pdf-for-lms">LMS uploads</a> · <a href="/guides/compress-pdf-efiling">E-filing</a> · <a href="/guides/compress-pdf-for-visa-application">Visa applications</a></li>
            <li><a href="/guides/compress-pdf-without-quality-loss">Compress without quality loss</a> · <a href="/guides/compress-pdf-with-images">Compress PDF with images</a></li>
            </ul>
            <p>Start compressing: <a href="/pdf/compress">Compress PDF free</a> · Guide: <a href="/compress-pdf">Compress PDF landing</a> · Compare tools: <a href="/compare">RatPDF vs alternatives</a>.</p>
            """;

        private const string CompressPdfForGmail = """
            <h2>Gmail's 25 MB attachment limit — what actually counts</h2>
            <p>Google documents Gmail's attachment cap as <strong>25 MB per message</strong> (<a href="https://support.google.com/mail/answer/6584" rel="noopener noreferrer" target="_blank">official help article</a>). In practice, three details trip up senders:</p>
            <ul>
            <li><strong>Base64 encoding overhead.</strong> Email transports attachments in encoded form, adding roughly 33% to raw file size. A 20 MB PDF can push the encoded payload close to the ceiling.</li>
            <li><strong>Total message size.</strong> Subject line, HTML body, inline images, and your signature all count toward the same message budget — not just the PDF.</li>
            <li><strong>Recipient gateway limits.</strong> Gmail may accept your send, but the recipient's corporate server can still reject delivery if their cap is 10–15 MB.</li>
            </ul>
            <p>Safe target: compress PDFs to <strong>18–20 MB</strong> before attaching in Gmail. Parent guide: <a href="/guides/compress-pdf-for-email">compress PDF for email</a>. Full limits table: <a href="/research/attachment-size-limits">attachment size limits (2026)</a>.</p>

            <h2>Why Gmail blocks your PDF</h2>
            <p>Gmail shows <strong>"Attachment too large"</strong> or refuses to attach when the file exceeds the limit. Common causes:</p>
            <ul>
            <li><strong>Phone scans at 300 dpi colour</strong> — a 15-page lease agreement can weigh 30 MB without looking "large."</li>
            <li><strong>Exported decks with full-bleed images</strong> — PowerPoint → PDF exports embed high-resolution photos per slide.</li>
            <li><strong>Multiple files in one draft</strong> — two 14 MB PDFs exceed the cap together; compress each or send separate messages.</li>
            <li><strong>Portfolio PDFs from design tools</strong> — InDesign and Canva exports prioritise print quality over email size.</li>
            </ul>
            <p>Gmail has no built-in PDF compressor. You must shrink the file externally — then attach the compressed copy. Tool: <a href="/pdf/compress">Compress PDF</a> (Ghostscript engine, three presets).</p>

            <h2>Step-by-step: compress a PDF for Gmail</h2>
            <ol>
            <li><strong>Check size.</strong> Right-click the file or use the <a href="/pdf-size-checker">PDF size checker</a> with the Gmail preset (25 MB cap).</li>
            <li><strong>Upload to <a href="/pdf/compress">Compress PDF</a>.</strong> Free tier: 3 uses per day, files up to 50 MB. Drag-and-drop works on desktop and mobile browsers.</li>
            <li><strong>Select Recommended compression.</strong> Default balance — 150 dpi images, good JPEG quality, typically 40–65% reduction on photo-heavy PDFs. Text-only exports may shrink less.</li>
            <li><strong>Review the size report.</strong> RatPDF shows original vs compressed size and percentage saved. If still over 20 MB, retry with Extreme — then verify fine print at 100% zoom.</li>
            <li><strong>Download and open the result.</strong> Confirm page count, bookmarks, and hyperlinks before attaching.</li>
            <li><strong>Attach in Gmail.</strong> Desktop: paperclip icon → Upload → select compressed file. Mobile Gmail app: same flow via Attach → Insert from Drive/Files.</li>
            </ol>
            <p>Benchmark context: <a href="/research/pdf-compression-benchmark">PDF compression benchmark</a>. Pillar: <a href="/guides/compress-pdf-guide">how to compress PDF online</a>.</p>

            <h2>Choosing compression level for Gmail</h2>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>Level</th><th>Typical reduction</th><th>Use for Gmail when…</th></tr></thead>
            <tbody>
            <tr><td><strong>Less Compression</strong></td><td>10–30%</td><td>Signed contracts, legal exhibits, or brand PDFs where logos must stay sharp. May not be enough alone for a 35 MB scan.</td></tr>
            <tr><td><strong>Recommended</strong></td><td>40–65%</td><td>Default for proposals, invoices, HR packs, and mixed text-and-image PDFs going to Gmail.</td></tr>
            <tr><td><strong>Extreme Compression</strong></td><td>70–90%</td><td>Last resort when Gmail still rejects after Recommended. Verify stamps, signatures, and footnotes before send.</td></tr>
            </tbody>
            </table></div>
            <p><strong>Scanned PDFs</strong> compress dramatically — phone photos of receipts often drop 50–70% at Recommended. <strong>Digital PDFs</strong> from Word or Google Docs may only lose 10–25%; if still too large, the source images are high-res — try Extreme or <a href="/guides/split-pdf-for-email">split for email</a>.</p>

            <h2>Google Drive workaround (when compression is not enough)</h2>
            <p>Gmail integrates with Google Drive for oversized files. When compression would blur fine print or the PDF is a non-negotiable quality archive:</p>
            <ol>
            <li>Upload the original PDF to Google Drive.</li>
            <li>In Gmail compose, click the <strong>Drive</strong> icon (not the paperclip).</li>
            <li>Select the file — Gmail inserts a share link instead of a raw attachment.</li>
            <li>Set link permissions: "Anyone with the link" for external clients, or restricted to specific emails for confidential docs.</li>
            </ol>
            <p><strong>When to prefer compression over Drive:</strong> recipients on locked-down corporate networks may block Drive links; legal and procurement teams often require direct attachments; ATS and portal uploads cannot accept Drive URLs. For everyday client email, a compressed attachment is usually faster and more reliable.</p>
            <p>Cloud archive workflow: <a href="/guides/compress-pdf-cloud-storage">compress PDF for cloud storage</a>.</p>

            <h2>Gmail on mobile (Android and iPhone)</h2>
            <p>Mobile Gmail uses the same 25 MB cap. You cannot compress inside the app — use Safari or Chrome:</p>
            <ol>
            <li>Open <a href="/pdf/compress">ratpdf.com/pdf/compress</a> in your mobile browser.</li>
            <li>Upload from Files (iOS) or Downloads (Android).</li>
            <li>Download the compressed PDF to your device.</li>
            <li>Return to Gmail → Attach → browse to the downloaded file.</li>
            </ol>
            <p>More mobile tips: <a href="/guides/compress-pdf-on-iphone">compress PDF on iPhone</a> · <a href="/guides/compress-pdf-on-android">compress PDF on Android</a>.</p>

            <h2>Compress vs split vs Drive — Gmail decision tree</h2>
            <ol>
            <li><strong>File under 2× your target (40 MB)?</strong> → Recommended compression. Works in most cases.</li>
            <li><strong>Long scanned doc still over 20 MB after Recommended?</strong> → Try Extreme once. If text blurs, <a href="/guides/split-pdf-for-email">split into Part 1 / Part 2</a>.</li>
            <li><strong>Photo portfolio where quality is mandatory?</strong> → Drive link in email body; compress a "review copy" if you also need an attachment.</li>
            <li><strong>Sending to a job portal, not Gmail?</strong> → Caps are often 2–5 MB. See <a href="/guides/compress-pdf-for-indeed">Indeed</a>, <a href="/guides/compress-pdf-for-linkedin">LinkedIn</a>, or <a href="/guides/compress-pdf-for-job-application">job application</a> guides.</li>
            </ol>
            <p>Compare: <a href="/guides/compress-vs-split">compress vs split</a> · <a href="/guides/pdf-email-attachment-checklist">PDF email attachment checklist</a>.</p>

            <h2>Common Gmail PDF scenarios</h2>
            <h3>Freelancer sending a proposal</h3>
            <p>Export from Google Docs or Word as PDF. If over 5 MB (unusual for text), run Recommended. Filename: <code>ClientName_Proposal_June2026.pdf</code>. Hub: <a href="/guides/compress-pdf-freelancers">compress PDF for freelancers</a>.</p>
            <h3>Accountant emailing workpapers</h3>
            <p>Multi-sheet Excel → PDF exports can exceed 25 MB. Compress with Recommended; if recipient is a Big Four firm, target <strong>10 MB</strong> for gateway safety. <a href="/guides/compress-pdf-accountants">Compress PDF for accountants</a>.</p>
            <h3>Teacher sharing a worksheet pack</h3>
            <p>Scan at grayscale 200 dpi before compressing — saves more than Extreme on a colour scan. <a href="/guides/compress-pdf-teachers">Compress PDF for teachers</a> · <a href="/guides/compress-pdf-for-lms">LMS uploads</a> if students submit via Canvas instead of email.</p>
            <h3>Lawyer sending discovery exhibits</h3>
            <p>Use Less compression first to preserve stamp clarity; split if still over limit. Never send unreadable exhibits — courts reject illegible filings. <a href="/guides/compress-pdf-lawyers">Compress PDF for lawyers</a> · <a href="/guides/compress-pdf-efiling">E-filing guide</a>.</p>

            <h2>Troubleshooting Gmail attachment errors</h2>
            <ul>
            <li><strong>"Attachment too large" after compression?</strong> Check total attachments in the draft — remove old forwards. Try Extreme or split.</li>
            <li><strong>Compression barely changed size?</strong> PDF may be text-only with embedded fonts. Re-export from source or try Extreme.</li>
            <li><strong>Recipient says they never got it?</strong> Your send succeeded but their gateway bounced. Re-compress to 10 MB and resend.</li>
            <li><strong>File grew after compression?</strong> Rare on RatPDF. See <a href="/guides/compress-pdf-made-it-larger">why compression made PDF larger</a>.</li>
            <li><strong>Password-protected PDF?</strong> <a href="/guides/unlock-pdf">Unlock PDF</a> before compressing.</li>
            </ul>

            <h2>Security when emailing PDFs via Gmail</h2>
            <p>Compression does not redact sensitive data. For financial statements, medical records, or HR files:</p>
            <ul>
            <li><a href="/guides/password-protect-pdf">Password-protect</a> the PDF; share the password by phone or SMS.</li>
            <li><a href="/guides/pdf-redaction">Redact</a> third-party PII before attach.</li>
            <li>RatPDF processes over HTTPS and deletes files after download — no long-term storage on free tier.</li>
            </ul>
            <p>Policy hub: <a href="/guides/secure-pdf-workflow">secure PDF workflow</a>.</p>

            <h2>Related guides</h2>
            <ul>
            <li><a href="/guides/compress-pdf-for-email">Compress PDF for email</a> (parent hub)</li>
            <li><a href="/guides/compress-pdf-for-outlook">Outlook &amp; Microsoft 365</a> · <a href="/guides/compress-pdf-for-yahoo-mail">Yahoo Mail</a> · <a href="/guides/compress-pdf-for-protonmail">Proton Mail</a></li>
            <li><a href="/guides/compress-pdf-for-whatsapp">WhatsApp</a> · <a href="/guides/compress-pdf-for-telegram">Telegram</a></li>
            <li><a href="/guides/compress-pdf-without-quality-loss">Compress without quality loss</a> · <a href="/guides/compress-pdf-with-images">Compress PDF with images</a></li>
            </ul>
            <p><a href="/pdf/compress">Compress PDF free</a> · <a href="/compress-pdf">Compress PDF hub</a> · <a href="/compare">Compare PDF tools</a></p>
            """;

        private const string CompressPdfForOutlook = """
            <h2>Outlook and Microsoft 365 attachment limits</h2>
            <p>Microsoft documents Exchange Online message size limits as configurable by tenant administrators — default deployments often allow <strong>25–34 MB</strong> per message, but many organisations enforce <strong>10–20 MB</strong> via transport rules (<a href="https://learn.microsoft.com/en-us/exchange/mail-flow/message-size-limits" rel="noopener noreferrer" target="_blank">Microsoft Docs</a>). Outlook desktop, Outlook on the web (OWA), and the mobile Outlook app all respect the same tenant policy.</p>
            <p>Unlike Gmail's consumer-stable 25 MB cap, Outlook users in enterprises frequently discover their limit only when a send fails. Safe target for B2B: <strong>10–15 MB</strong>. For personal Outlook.com accounts: <strong>15–18 MB</strong>. Parent guide: <a href="/guides/compress-pdf-for-email">compress PDF for email</a>.</p>

            <h2>Why Outlook blocks PDFs that Gmail accepts</h2>
            <p>Three scenarios explain the mismatch:</p>
            <ul>
            <li><strong>Exchange transport rules.</strong> Your IT team may cap outbound attachments at 10 MB even though Microsoft's platform allows more.</li>
            <li><strong>Recipient gateway stricter than sender.</strong> You send successfully from Outlook; the recipient's Proofpoint or Mimecast filter rejects delivery silently.</li>
            <li><strong>OneDrive auto-conversion.</strong> Outlook may replace large attachments with OneDrive links — external clients without Microsoft accounts cannot access them, making it look like "the PDF was blocked."</li>
            </ul>
            <p>Fix: compress the PDF to a size both sender and recipient gateways accept, then attach directly — do not rely on auto-generated cloud links for external recipients.</p>

            <h2>Step-by-step: compress a PDF for Outlook</h2>
            <ol>
            <li><strong>Confirm your limit.</strong> Ask IT for the Exchange transport cap, or test with the <a href="/pdf-size-checker">PDF size checker</a>. When unknown, target 10 MB.</li>
            <li><strong>Open <a href="/pdf/compress">Compress PDF</a>.</strong> Upload your file (free tier: 3/day, up to 50 MB per file).</li>
            <li><strong>Choose Recommended compression.</strong> For strict 10 MB gateways, follow with Extreme if the size report still shows over target.</li>
            <li><strong>Download and verify.</strong> Open at 100% zoom — check stamps, signatures, and table borders.</li>
            <li><strong>Attach in Outlook.</strong> Desktop: Insert → Attach File. OWA: paperclip icon. Mobile: + → Attach file.</li>
            </ol>
            <p>Limits reference: <a href="/research/attachment-size-limits">attachment size limits (2026)</a>. Benchmark: <a href="/research/pdf-compression-benchmark">PDF compression benchmark</a>.</p>

            <h2>Outlook desktop vs Outlook on the web vs mobile</h2>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>Client</th><th>Attachment behaviour</th><th>Compression tip</th></tr></thead>
            <tbody>
            <tr><td>Outlook desktop (Windows/Mac)</td><td>Respects Exchange limits; may prompt OneDrive for large files</td><td>Compress first; choose "Attach a copy" not "Upload and share link" for external recipients</td></tr>
            <tr><td>Outlook on the web (OWA)</td><td>Same tenant limits; integrates OneDrive/SharePoint</td><td>Drag compressed PDF into compose window; verify attachment icon shows file size</td></tr>
            <tr><td>Outlook mobile (iOS/Android)</td><td>Same limits; no built-in compressor</td><td>Compress in mobile browser via <a href="/pdf/compress">RatPDF</a>, then attach from Downloads</td></tr>
            </tbody>
            </table></div>
            <p>Desktop tips: <a href="/guides/compress-pdf-on-windows">compress PDF on Windows</a> · <a href="/guides/compress-pdf-on-mac">compress PDF on Mac</a>.</p>

            <h2>OneDrive and SharePoint large-attachment workflow</h2>
            <p>Microsoft 365 offers <strong>Large File Share</strong> — Outlook uploads oversized files to OneDrive and inserts a link. This works well for internal colleagues on the same tenant. For external clients:</p>
            <ul>
            <li>Links may require Microsoft login — friction for non-Microsoft recipients.</li>
            <li>Some law firms and banks block cloud links in email for security policy.</li>
            <li>Procurement portals and court e-filing systems require direct PDF upload, not links.</li>
            </ul>
            <p><strong>Default rule:</strong> compress and attach for external B2B. Use OneDrive links only when the recipient confirms they can access SharePoint/OneDrive and a compressed attachment would destroy required quality.</p>

            <h2>Compression levels for Outlook</h2>
            <p>RatPDF offers three Ghostscript presets via <a href="/pdf/compress">Compress PDF</a>:</p>
            <ul>
            <li><strong>Less Compression</strong> — 10–30% reduction; preserve legal fine print and brand logos. Use when gateway allows 20 MB+.</li>
            <li><strong>Recommended</strong> — 40–65% reduction; default for proposals, reports, and HR packs.</li>
            <li><strong>Extreme Compression</strong> — 70–90% reduction; for 10 MB corporate gateways when Recommended is insufficient.</li>
            </ul>
            <p>If Extreme blurs exhibit stamps, <a href="/guides/split-pdf-for-email">split the PDF</a> instead of sending illegible pages. More: <a href="/guides/compress-pdf-guide">compress PDF guide</a> · <a href="/guides/compress-scanned-vs-digital-pdf">scanned vs digital PDF</a>.</p>

            <h2>Corporate and industry scenarios</h2>
            <h3>HR onboarding packs</h3>
            <p>Policy PDFs, benefits summaries, and tax forms often exceed 10 MB combined. Compress each document separately before attaching to the welcome email. <a href="/guides/compress-pdf-hr">Compress PDF for HR</a>.</p>
            <h3>Legal and compliance</h3>
            <p>Target 10 MB for law-firm recipients. Use Less compression for signed exhibits; split multi-hundred-page discovery if needed. <a href="/guides/compress-pdf-lawyers">Compress PDF for lawyers</a> · <a href="/guides/compress-pdf-efiling">E-filing</a>.</p>
            <h3>Insurance claims</h3>
            <p>Photo-heavy adjuster reports compress well at Recommended. Verify policy numbers and dates at 100% zoom. <a href="/guides/compress-pdf-insurance-claims">Compress PDF for insurance claims</a>.</p>
            <h3>Accountants and auditors</h3>
            <p>Excel → PDF workpapers can be large. Compress before emailing to clients on Big Four gateways. <a href="/guides/compress-pdf-accountants">Compress PDF for accountants</a>.</p>

            <h2>Troubleshooting Outlook send failures</h2>
            <ul>
            <li><strong>"Message size exceeds fixed maximum"</strong> — Exchange transport rule hit. Compress to 10 MB or ask IT to raise limit.</li>
            <li><strong>Send succeeds but recipient reports bounce</strong> — Their gateway is stricter. Re-compress to 8–10 MB.</li>
            <li><strong>Attachment became a OneDrive link unexpectedly</strong> — Disable auto-large-file upload in Outlook settings, or explicitly choose "Attach a copy."</li>
            <li><strong>Multiple PDFs in one message</strong> — Combined size counts. Compress each file or send separate emails.</li>
            <li><strong>Encrypted PDF</strong> — <a href="/guides/unlock-pdf">Unlock</a> before compression.</li>
            </ul>

            <h2>Security for Outlook attachments</h2>
            <p>Exchange organisations often run DLP (Data Loss Prevention) scanners that flag unencrypted payroll or client data. Before sending:</p>
            <ul>
            <li><a href="/guides/password-protect-pdf">Password-protect</a> confidential PDFs.</li>
            <li><a href="/guides/pdf-redaction">Redact</a> third-party PII.</li>
            <li>Do not rely on "internal only" — misaddressed email is a top breach vector.</li>
            </ul>
            <p>Hub: <a href="/guides/secure-pdf-workflow">secure PDF workflow</a> · Blog: <a href="/blog/remote-work-pdf-security">remote work PDF security</a>.</p>

            <h2>Related guides</h2>
            <ul>
            <li><a href="/guides/compress-pdf-for-email">Compress PDF for email</a> (parent hub)</li>
            <li><a href="/guides/compress-pdf-for-gmail">Gmail</a> · <a href="/guides/compress-pdf-for-yahoo-mail">Yahoo Mail</a> · <a href="/guides/compress-pdf-for-protonmail">Proton Mail</a></li>
            <li><a href="/guides/compress-pdf-for-workday">Workday</a> · <a href="/guides/compress-pdf-for-job-application">Job applications</a></li>
            <li><a href="/guides/pdf-email-attachment-checklist">PDF email attachment checklist</a></li>
            </ul>
            <p><a href="/pdf/compress">Compress PDF free</a> · <a href="/compress-pdf">Compress PDF hub</a></p>
            """;

        private const string CompressPdfForLinkedin = """
            <h2>LinkedIn PDF upload limits — resumes, portfolios, and messaging</h2>
            <p>LinkedIn does not publish a single global attachment cap, but three upload surfaces have different practical limits:</p>
            <ul>
            <li><strong>Easy Apply resume upload</strong> — commonly <strong>2–5 MB</strong> per PDF. Exceeding this blocks the application with a generic error.</li>
            <li><strong>Featured section / profile media</strong> — portfolio PDFs and case studies; aim under <strong>5 MB</strong> for reliable upload.</li>
            <li><strong>LinkedIn messaging attachments</strong> — approximately <strong>20 MB</strong>; compress for reliability even though the cap is higher.</li>
            </ul>
            <p>Job seekers hit the Easy Apply limit most often. This guide focuses on shrinking resume and portfolio PDFs without breaking ATS text parsing. Parent: <a href="/guides/compress-pdf-for-email">compress PDF for email</a> · Guide: <a href="/guides/compress-pdf-for-job-application">compress PDF for job application</a>.</p>

            <h2>Why your resume PDF fails on LinkedIn</h2>
            <ul>
            <li><strong>Designed resume with photos and icons</strong> — Canva and Figma exports embed high-resolution graphics.</li>
            <li><strong>Multi-page portfolio attached as resume</strong> — 8-page case-study PDFs routinely exceed 2 MB.</li>
            <li><strong>Scanned paper resume</strong> — 300 dpi colour scan of two pages can weigh 5–8 MB.</li>
            <li><strong>Embedded custom fonts and vector art</strong> — beautiful in print, heavy for web upload.</li>
            </ul>
            <p>LinkedIn's applicant tracking parses <strong>selectable text</strong> from your PDF. Compression that destroys the text layer or flattens everything to blurry images hurts parsing — choose the right level.</p>

            <h2>Step-by-step: compress a resume PDF for LinkedIn</h2>
            <ol>
            <li><strong>Start with a digital PDF.</strong> Export from Word or Google Docs — not a phone photo of a printed resume. Guide: <a href="/guides/pdf-to-word-resume">PDF to Word for resume</a>.</li>
            <li><strong>Check file size.</strong> Target <strong>under 2 MB</strong> for Easy Apply. Use the <a href="/pdf-size-checker">PDF size checker</a>.</li>
            <li><strong>Open <a href="/pdf/compress">Compress PDF</a>.</strong> Upload the resume PDF.</li>
            <li><strong>Use Recommended compression.</strong> On a typical one-page vector resume, this drops 30–50% while preserving selectable text. Avoid Extreme unless still over 2 MB.</li>
            <li><strong>Verify text selects.</strong> Open the compressed PDF, highlight a paragraph — if text selects, ATS parsing should work.</li>
            <li><strong>Upload to LinkedIn Easy Apply</strong> with a clean filename: <code>FirstName_LastName_Resume.pdf</code>.</li>
            </ol>
            <p>Also see: <a href="/guides/compress-pdf-for-indeed">compress PDF for Indeed</a> · <a href="/guides/compress-pdf-for-naukri">compress PDF for Naukri</a>.</p>

            <h2>Compression levels for LinkedIn resumes</h2>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>Level</th><th>Resume impact</th><th>When to use</th></tr></thead>
            <tbody>
            <tr><td><strong>Less Compression</strong></td><td>Minimal visual change; text stays vector</td><td>Resume already under 2 MB; design-heavy CV with icons you must preserve</td></tr>
            <tr><td><strong>Recommended</strong></td><td>Moderate shrink; text usually remains selectable</td><td>Default for Easy Apply — best balance for ATS</td></tr>
            <tr><td><strong>Extreme Compression</strong></td><td>May rasterise thin fonts; parsing risk increases</td><td>Only when Recommended still exceeds 2 MB; re-verify text selection</td></tr>
            </tbody>
            </table></div>
            <p><strong>Rule:</strong> after any compression, Ctrl+F for your name and email in the PDF viewer. If search finds them, LinkedIn's parser likely can too.</p>

            <h2>Design tips before compressing</h2>
            <p>Smarter source files beat aggressive compression:</p>
            <ul>
            <li><strong>One page for Easy Apply.</strong> Move portfolio work to a separate LinkedIn Featured link or personal site.</li>
            <li><strong>Remove full-page background images.</strong> A subtle header colour is fine; full-bleed photos dominate file size.</li>
            <li><strong>Export "Minimum size" from Word</strong> when available — embeds lower-res images at source.</li>
            <li><strong>Use standard fonts</strong> (Arial, Calibri, Helvetica) — custom font embedding adds bytes.</li>
            <li><strong>Grayscale for scanned resumes</strong> — re-scan at 200 dpi grayscale instead of compressing a 300 dpi colour photo.</li>
            </ul>
            <p>Why is it large? <a href="/guides/why-is-pdf-file-so-large">Why is my PDF so large?</a></p>

            <h2>Portfolio PDFs for LinkedIn Featured section</h2>
            <p>Featured media showcases case studies, pitch decks, and certifications. Limits are more forgiving than Easy Apply, but mobile viewers appreciate smaller files:</p>
            <ol>
            <li>Export deck as PDF from PowerPoint or Google Slides.</li>
            <li>Compress with Recommended — aim under 5 MB for fast mobile preview.</li>
            <li>Upload to Featured → Add media → Link or upload.</li>
            </ol>
            <p>For image-heavy portfolios, <a href="/guides/compress-pdf-with-images">compress PDF with images</a> explains DPI trade-offs.</p>

            <h2>LinkedIn messaging attachments</h2>
            <p>When sending a PDF via LinkedIn DM (proposal, contract, portfolio):</p>
            <ul>
            <li>Target under <strong>15 MB</strong> even though ~20 MB may work — mobile recipients on slow networks benefit.</li>
            <li>Compress with Recommended; split long documents via <a href="/guides/split-pdf-for-email">split for email</a> if needed.</li>
            <li>For confidential contracts, <a href="/guides/password-protect-pdf">password-protect</a> before send.</li>
            </ul>

            <h2>Compress vs redesign vs split</h2>
            <ol>
            <li><strong>Resume over 2 MB?</strong> → Remove portfolio pages from the resume PDF first, then Recommended compression.</li>
            <li><strong>Still over 2 MB after Recommended?</strong> → Simplify design (remove background images), re-export, compress again.</li>
            <li><strong>Extreme makes text unselectable?</strong> → Re-export a simpler one-page Word version — do not submit a blurry image resume.</li>
            <li><strong>Multi-document application?</strong> → LinkedIn usually takes one resume file; merge cover letter into page 1 only if required. <a href="/guides/merge-pdf">Merge PDF</a> then compress.</li>
            </ol>

            <h2>Troubleshooting LinkedIn upload errors</h2>
            <ul>
            <li><strong>"File too large"</strong> on Easy Apply — compress to under 2 MB; verify with size checker.</li>
            <li><strong>Upload spins then fails</strong> — try a different browser; clear cache; ensure PDF is not password-protected.</li>
            <li><strong>Application submitted but no profile parse</strong> — text may be image-only. Re-export digital PDF from Word, avoid scanned resumes.</li>
            <li><strong>Special characters garbled</strong> — export with embedded fonts from Word; see <a href="/guides/pdf-to-word-resume">resume PDF guide</a>.</li>
            </ul>

            <h2>Related guides</h2>
            <ul>
            <li><a href="/guides/compress-pdf-for-job-application">Compress PDF for job application</a></li>
            <li><a href="/guides/compress-pdf-for-indeed">Indeed</a> · <a href="/guides/compress-pdf-for-naukri">Naukri</a> · <a href="/guides/compress-pdf-for-workday">Workday</a></li>
            <li><a href="/guides/compress-pdf-for-email">Compress PDF for email</a></li>
            <li><a href="/guides/compress-pdf-without-quality-loss">Compress without quality loss</a></li>
            </ul>
            <p><a href="/pdf/compress">Compress PDF free</a> · <a href="/research/attachment-size-limits">Attachment limits table</a></p>
            """;

        private const string CompressPdfForEfiling = """
            <h2>Court and government e-filing PDF size limits</h2>
            <p>Electronic filing portals reject PDFs that exceed per-document or per-envelope caps. Limits vary by jurisdiction — always verify your local rules before filing. Common ranges in U.S. federal and state systems:</p>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>System</th><th>Typical per-file cap</th><th>Notes</th></tr></thead>
            <tbody>
            <tr><td>CM/ECF (federal district/bankruptcy)</td><td><strong>35 MB</strong> per PDF (varies by court)</td><td>Some courts set lower local limits — check the court's ECF page</td></tr>
            <tr><td>PACER / appellate CM/ECF</td><td><strong>25–50 MB</strong></td><td>Appellate courts may differ from district</td></tr>
            <tr><td>State e-filing (Tyler, Odyssey, etc.)</td><td><strong>10–35 MB</strong></td><td>California, Texas, Florida, and others publish court-specific caps</td></tr>
            <tr><td>Immigration (USCIS, etc.)</td><td><strong>6–12 MB</strong> per upload</td><td>See <a href="/guides/compress-pdf-for-visa-application">visa application guide</a></td></tr>
            </tbody>
            </table></div>
            <p>Safe default: compress exhibits to <strong>under 10 MB</strong> unless your court's standing order confirms a higher cap. Research: <a href="/research/attachment-size-limits">attachment size limits</a>. Tool: <a href="/pdf/compress">Compress PDF</a>.</p>

            <h2>Why e-filing portals reject your PDF</h2>
            <ul>
            <li><strong>Scanned exhibits at 300 dpi colour</strong> — multi-page medical records or discovery productions routinely exceed 35 MB.</li>
            <li><strong>Combined envelope size</strong> — some courts limit total bytes across all attachments in one filing event, not just one file.</li>
            <li><strong>Non-searchable scans</strong> — rejection for OCR/searchability requirements, not size (fix with <a href="/pdf/ocrpdf">OCR PDF</a> first).</li>
            <li><strong>Wrong PDF version or encryption</strong> — unlock and re-save before compressing: <a href="/guides/unlock-pdf">unlock PDF</a>.</li>
            </ul>
            <p>Lawyers: <a href="/guides/compress-pdf-lawyers">compress PDF for lawyers</a> · <a href="/guides/merge-pdf-court-filing">merge PDF for court filing</a>.</p>

            <h2>OCR before or after compression?</h2>
            <p><strong>OCR first, then compress.</strong> On scanned exhibits, compression re-encodes page images at lower DPI. If you compress aggressively before OCR, Tesseract has fewer pixels to read — searchability and accuracy suffer. Correct order:</p>
            <ol>
            <li>Scan at 300 dpi, straight alignment, high contrast.</li>
            <li>Run <a href="/pdf/ocrpdf">OCR PDF</a> to add a searchable text layer.</li>
            <li>Compress with Recommended to meet the portal cap.</li>
            <li>Verify search (Ctrl+F for party names, dates, exhibit numbers) at 100% zoom.</li>
            </ol>
            <p>Digital-native PDFs (exported from Word with embedded text) skip OCR — compress directly.</p>

            <h2>Step-by-step: compress a PDF for e-filing</h2>
            <ol>
            <li><strong>Confirm the cap</strong> from your court's ECF help page or standing order.</li>
            <li><strong>Merge exhibits in index order</strong> if filing one combined PDF: <a href="/guides/merge-pdf-court-filing">merge PDF for court filing</a>.</li>
            <li><strong>OCR scanned pages</strong> before compression when searchability is required.</li>
            <li><strong>Upload to <a href="/pdf/compress">Compress PDF</a>.</strong> Start with <strong>Less Compression</strong> for exhibits with fine print, stamps, or notarised signatures. Use <strong>Recommended</strong> if still over cap.</li>
            <li><strong>Review at 100% zoom</strong> — footnotes, exhibit stamps, and page numbers must remain legible.</li>
            <li><strong>Check size</strong> with the <a href="/pdf-size-checker">PDF size checker</a>, then upload to the docket.</li>
            </ol>
            <p>Benchmark: <a href="/research/pdf-compression-benchmark">PDF compression benchmark</a>. Pillar: <a href="/guides/compress-pdf-guide">compress PDF guide</a>.</p>

            <h2>Compression levels for court exhibits</h2>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>Level</th><th>When to use for e-filing</th></tr></thead>
            <tbody>
            <tr><td><strong>Less Compression</strong></td><td>First choice for notarised affidavits, stamped orders, and fine-type exhibits when cap allows</td></tr>
            <tr><td><strong>Recommended</strong></td><td>Default when file exceeds portal cap; verify stamps after compress</td></tr>
            <tr><td><strong>Extreme Compression</strong></td><td>Only when portal still rejects and Less/Recommended insufficient — re-read every page before filing</td></tr>
            </tbody>
            </table></div>
            <p>If Extreme blurs exhibit numbers, <a href="/guides/split-pdf-by-size">split by size</a> into separate docket attachments instead of filing illegible pages.</p>

            <h2>Merge order and exhibit numbering</h2>
            <p>Courts expect exhibits in index order with visible labels (Exhibit A, B, C…). Workflow:</p>
            <ol>
            <li>Prepare each exhibit PDF — rotate, unlock, redact as needed.</li>
            <li><a href="/guides/merge-pdf-custom-order">Merge in custom order</a> matching the exhibit index.</li>
            <li>Add page numbers if required: <a href="/guides/add-page-numbers">add page numbers</a>.</li>
            <li>OCR scans, then compress if over cap.</li>
            </ol>
            <p>Do not compress individual exhibits before merging — compress once on the final combined file to avoid double lossy encoding.</p>

            <h2>Common e-filing document types</h2>
            <h3>Discovery productions</h3>
            <p>Large scan batches — OCR entire production, compress per volume if court requires split files. <a href="/guides/compress-pdf-lawyers">Lawyer compression guide</a>.</p>
            <h3>Motions with photo exhibits</h3>
            <p>Accident photos and medical imaging inflate size. Recommended compression usually preserves evidentiary detail at screen resolution.</p>
            <h3>Appellate appendices</h3>
            <p>Appellate courts may have stricter formatting rules — confirm PDF/A requirements separately from size limits.</p>
            <h3>Pro se immigration packets</h3>
            <p>USCIS uploads often need under 6 MB per file. See <a href="/guides/compress-pdf-for-visa-application">visa application compression</a>.</p>

            <h2>Troubleshooting e-filing rejections</h2>
            <ul>
            <li><strong>"Document exceeds size limit"</strong> — Re-compress with Recommended or Extreme; confirm cap from court website.</li>
            <li><strong>"Document not searchable"</strong> — Run OCR; do not rely on compression to fix this.</li>
            <li><strong>"Filing rejected after upload"</strong> — Check combined envelope size across all attachments.</li>
            <li><strong>Stamps illegible after compression</strong> — Re-file with Less compression or split exhibits.</li>
            <li><strong>Encrypted PDF</strong> — <a href="/guides/unlock-pdf">Unlock</a> and flatten forms: <a href="/guides/flatten-pdf">flatten PDF</a>.</li>
            </ul>

            <h2>Related guides</h2>
            <ul>
            <li><a href="/guides/compress-pdf-for-email">Compress PDF for email</a> · <a href="/guides/compress-pdf-for-government-forms">Government forms</a></li>
            <li><a href="/guides/merge-pdf-court-filing">Merge PDF for court filing</a> · <a href="/guides/merge-pdf-lawyers">Merge PDF for lawyers</a></li>
            <li><a href="/guides/compress-pdf-without-quality-loss">Compress without quality loss</a></li>
            <li><a href="/guides/ocr-pdf">OCR PDF guide</a></li>
            </ul>
            <p><a href="/pdf/compress">Compress PDF free</a> · <a href="/compress-pdf">Compress PDF hub</a></p>
            """;

        private const string InvoiceGeneratorIndia = """
            <h2>GST invoices for Indian freelancers and SMBs</h2>
            <p>Registered businesses in India must issue tax invoices with GST breakdowns for B2B supplies. RatPDF provides two paths:</p>
            <ul>
            <li><strong><a href="/invoice/create">Create Invoice</a></strong> — single invoices with line items, GST tax name/rate, INR currency, and instant PDF download. No signup on free tier.</li>
            <li><strong><a href="/invoice/bulk">Bulk GST Invoice Generator</a></strong> — CSV upload for full B2B fields (GSTIN, HSN/SAC, place of supply) generating up to 100 PDFs per batch on Business plan.</li>
            </ul>
            <p>Parent hub: <a href="/guides/invoice-generator-guide">invoice generator guide</a>. Validate output: <a href="/gst-invoice-checker">GST invoice checker</a>.</p>

            <h2>When you need a GST tax invoice</h2>
            <p>Under GST law, a tax invoice is required for taxable supplies above the threshold, and for all B2B transactions where the buyer claims input tax credit (ITC). Your invoice PDF should let the recipient:</p>
            <ul>
            <li>Identify supplier and recipient GSTIN (for B2B)</li>
            <li>See HSN/SAC codes for goods and services</li>
            <li>Verify taxable value, CGST/SGST or IGST split, and total</li>
            <li>Match the invoice to their GSTR-2B reconciliation</li>
            </ul>
            <p>Compliance deep-dive: <a href="/guides/gst-invoice-format-india">GST invoice format India</a> · <a href="/guides/e-invoicing-india-pdf">E-invoicing India PDF</a>.</p>

            <h2>Step-by-step: create a single GST invoice</h2>
            <ol>
            <li>Open <a href="/invoice/create">Create Invoice</a>.</li>
            <li>Enter <strong>From</strong> details — legal business name, address, GSTIN (if registered), phone, email.</li>
            <li>Enter <strong>Customer</strong> details — name, address, and GSTIN for B2B clients.</li>
            <li>Add <strong>line items</strong> — description, quantity, rate. Subtotal calculates automatically.</li>
            <li>Set <strong>Tax name</strong> to GST and choose the rate (5%, 12%, 18%, 28%, or custom).</li>
            <li>Select <strong>INR</strong> currency and add payment terms, UPI/bank details in Notes.</li>
            <li>Click <strong>Generate PDF</strong> — download and email to your client.</li>
            </ol>
            <p>For simple B2C invoices or freelancers below GST registration threshold, the main form covers tax name and rate without full HSN fields.</p>

            <h2>Step-by-step: bulk GST invoices via CSV</h2>
            <p>CA firms and businesses issuing dozens of monthly invoices should use bulk generation:</p>
            <ol>
            <li>Open <a href="/invoice/bulk">Bulk GST Invoice Generator</a> (Business plan).</li>
            <li>Download the CSV template with columns for GSTIN, HSN/SAC, place of supply, line items, and tax split.</li>
            <li>Fill one row per invoice in Excel or Google Sheets.</li>
            <li>Upload the CSV — RatPDF generates one PDF per row.</li>
            <li>Download the ZIP of all invoice PDFs.</li>
            <li>Spot-check 2–3 PDFs with the <a href="/gst-invoice-checker">GST invoice checker</a> before sending to clients.</li>
            </ol>
            <p>Detailed workflow: <a href="/guides/bulk-gst-invoice-generator">bulk GST invoice generator guide</a>.</p>

            <h2>GST fields checklist (B2B)</h2>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>Field</th><th>Single form</th><th>Bulk CSV</th></tr></thead>
            <tbody>
            <tr><td>Supplier GSTIN</td><td>Enter in From details</td><td>Column in CSV</td></tr>
            <tr><td>Recipient GSTIN</td><td>Enter in Customer details</td><td>Column in CSV</td></tr>
            <tr><td>HSN/SAC code</td><td>Notes or description (full codes in bulk)</td><td>Dedicated CSV column</td></tr>
            <tr><td>Place of supply</td><td>Notes field</td><td>CSV column (determines IGST vs CGST/SGST)</td></tr>
            <tr><td>Tax rate &amp; amount</td><td>Tax rate selector</td><td>Per-row in CSV</td></tr>
            <tr><td>Invoice number &amp; date</td><td>Auto/manual on form</td><td>CSV columns</td></tr>
            </tbody>
            </table></div>
            <p>Official reference: <a href="https://www.gst.gov.in/" rel="noopener noreferrer" target="_blank">GST Portal</a>. Always verify current circulars for e-invoice applicability thresholds.</p>

            <h2>CGST/SGST vs IGST on your invoice</h2>
            <p>Tax split depends on place of supply:</p>
            <ul>
            <li><strong>Intra-state</strong> (supplier and recipient in same state) — CGST + SGST (each half the GST rate).</li>
            <li><strong>Inter-state</strong> — IGST at the full rate.</li>
            </ul>
            <p>On the single invoice form, enter the combined GST rate; note the split in the Notes section for B2B clarity. Bulk CSV handles explicit CGST/SGST/IGST columns for automated split on the PDF.</p>

            <h2>Common scenarios</h2>
            <h3>Freelancer/consultant (registered)</h3>
            <p>Bill monthly retainers or project milestones in INR with 18% GST on most services. Add UPI ID and bank details for faster payment. <a href="/guides/invoice-for-freelancers">Invoice for freelancers</a>.</p>
            <h3>E-commerce seller</h3>
            <p>High volume → bulk CSV. Include HSN for goods. Archive PDFs for 6+ years per retention norms.</p>
            <h3>CA firm billing clients</h3>
            <p>Generate audit and compliance fee invoices in batch at month-end. <a href="/invoice/invoice-generator-ca-firms">Invoice generator for CA firms</a>.</p>
            <h3>Unregistered small supplier</h3>
            <p>Issue a bill of supply or invoice without GSTIN if below registration threshold — use tax name field accordingly and consult your CA.</p>

            <h2>After you generate the PDF</h2>
            <ul>
            <li><strong>Email to client</strong> — if over 25 MB (unusual for invoices), <a href="/guides/compress-pdf-for-gmail">compress for Gmail</a>.</li>
            <li><strong>Edit later</strong> — need to change line items? <a href="/guides/pdf-to-word-invoice">PDF to Word for invoice</a> or regenerate from source data.</li>
            <li><strong>GSTR-1 filing</strong> — invoice data must match what you report; keep PDF archive aligned with books.</li>
            <li><strong>E-invoice IRN</strong> — businesses above the e-invoicing threshold need IRN from the Invoice Registration Portal; RatPDF PDF is the human-readable copy alongside IRN QR. See <a href="/guides/e-invoicing-india-pdf">e-invoicing India PDF</a>.</li>
            </ul>

            <h2>Pro features for Indian businesses</h2>
            <p>Pro and Business plans remove watermarks, allow logo upload, and unlock bulk CSV generation. Compare: <a href="/Subscription/Plans">pricing</a> · <a href="/compare">RatPDF vs alternatives</a>.</p>

            <h2>Related guides</h2>
            <ul>
            <li><a href="/guides/invoice-generator-guide">Invoice generator guide</a></li>
            <li><a href="/guides/bulk-gst-invoice-generator">Bulk GST invoice generator</a></li>
            <li><a href="/guides/gst-invoice-format-india">GST invoice format India</a></li>
            <li><a href="/guides/recurring-invoice-generator">Recurring invoice generator</a></li>
            <li><a href="/guides/compress-gst-invoice-pdf">Compress GST invoice PDF</a></li>
            <li><a href="/guides/invoice-generator-usa">Invoice generator USA</a> (for export clients)</li>
            </ul>
            <p><a href="/invoice/create">Create GST invoice →</a> · <a href="/gst-invoice-checker">Validate GST invoice →</a></p>
            """;

        private const string CompressPdfForIndeed = """
            <h2>Indeed PDF upload limits — resumes and applications</h2>
            <p>Indeed does not publish one global file-size cap because <strong>each employer configures their own ATS</strong> on Indeed Apply and external career pages. In practice, resume PDF limits cluster around:</p>
            <ul>
            <li><strong>2–5 MB</strong> for most Indeed Apply and employer-hosted application forms</li>
            <li><strong>5–10 MB</strong> for some enterprise employers and certificate uploads</li>
            <li><strong>Stricter limits on mobile apply</strong> — failures often appear as silent spinner or generic error</li>
            </ul>
            <p>Target <strong>under 2 MB</strong> for maximum compatibility. Parent hub: <a href="/guides/compress-pdf-for-job-application">compress PDF for job application</a>. Related: <a href="/guides/compress-pdf-for-linkedin">LinkedIn</a> · <a href="/guides/compress-pdf-for-naukri">Naukri</a> · <a href="/guides/compress-pdf-for-workday">Workday</a>.</p>

            <h2>Why Indeed rejects your resume PDF</h2>
            <ul>
            <li><strong>Designed resume with graphics</strong> — Canva, Figma, or Photoshop exports embed large images.</li>
            <li><strong>Multi-page portfolio attached as resume</strong> — case studies push file size past ATS caps.</li>
            <li><strong>Scanned paper resume</strong> — 300 dpi colour scan of two pages can weigh 5–8 MB.</li>
            <li><strong>Wrong file type masked as PDF</strong> — export properly from Word or Google Docs.</li>
            </ul>
            <p>Indeed's ATS parses <strong>selectable text</strong> from your PDF. Image-only resumes fail parsing even if upload succeeds — always start with a digital export.</p>

            <h2>Step-by-step: compress a resume for Indeed</h2>
            <ol>
            <li><strong>Export a digital PDF</strong> from Microsoft Word or Google Docs — not a phone photo. Guide: <a href="/guides/pdf-to-word-resume">PDF to Word for resume</a>.</li>
            <li><strong>Check file size</strong> with the <a href="/pdf-size-checker">PDF size checker</a>. Aim under 2 MB.</li>
            <li><strong>Open <a href="/pdf/compress">Compress PDF</a></strong> and upload the resume.</li>
            <li><strong>Select Recommended compression.</strong> Typical one-page vector resumes drop 30–50% while keeping text selectable.</li>
            <li><strong>Verify text selects</strong> — highlight your name and email in any PDF viewer. If text selects, ATS parsing should work.</li>
            <li><strong>Upload on Indeed</strong> with filename <code>FirstName_LastName_Resume.pdf</code>.</li>
            </ol>

            <h2>Compression levels for Indeed / ATS</h2>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>Level</th><th>ATS impact</th><th>When to use</th></tr></thead>
            <tbody>
            <tr><td><strong>Less Compression</strong></td><td>Text stays vector; minimal parsing risk</td><td>Resume already under 2 MB</td></tr>
            <tr><td><strong>Recommended</strong></td><td>Text usually remains selectable</td><td>Default for Indeed apply — best size/quality balance</td></tr>
            <tr><td><strong>Extreme Compression</strong></td><td>May rasterise thin fonts; parsing risk rises</td><td>Only if still over cap after Recommended — re-verify text selection</td></tr>
            </tbody>
            </table></div>
            <p>After compression, Ctrl+F for your email address in the PDF. If search finds it, the ATS likely can too.</p>

            <h2>Design before compressing</h2>
            <ul>
            <li><strong>One page</strong> for Indeed Apply — move portfolio to a personal site link.</li>
            <li><strong>Remove full-page background images</strong> — they dominate file size without helping ATS.</li>
            <li><strong>Standard fonts</strong> (Arial, Calibri, Helvetica) — avoid heavy custom font embedding.</li>
            <li><strong>Grayscale re-scan</strong> at 200 dpi if you must use a paper resume — better than Extreme on a colour photo scan.</li>
            </ul>
            <p>More: <a href="/guides/why-is-pdf-file-so-large">why is my PDF so large?</a> · <a href="/guides/compress-pdf-without-quality-loss">compress without quality loss</a>.</p>

            <h2>Certificates and cover letters on Indeed</h2>
            <p>Some employers request additional PDFs (certifications, cover letters, portfolios):</p>
            <ul>
            <li>Compress each file separately — limits apply per upload field.</li>
            <li>Cover letters should stay one page, digital export, under 1 MB.</li>
            <li>Certificates from scan apps: 200 dpi grayscale, then Recommended compression.</li>
            </ul>
            <p>Emailing application materials instead? <a href="/guides/compress-pdf-for-email">compress PDF for email</a> · <a href="/guides/compress-pdf-for-gmail">Gmail</a>.</p>

            <h2>Troubleshooting Indeed upload errors</h2>
            <ul>
            <li><strong>Spinner then failure</strong> — file over employer cap; compress to under 2 MB.</li>
            <li><strong>Upload succeeds but no profile parse</strong> — resume is image-only; re-export from Word.</li>
            <li><strong>Password-protected PDF</strong> — remove protection: <a href="/guides/unlock-pdf">unlock PDF</a>.</li>
            <li><strong>Special characters garbled</strong> — embed fonts on export from Word.</li>
            </ul>

            <h2>Related guides</h2>
            <ul>
            <li><a href="/guides/compress-pdf-for-job-application">Job application hub</a></li>
            <li><a href="/guides/compress-pdf-for-linkedin">LinkedIn</a> · <a href="/guides/compress-pdf-for-naukri">Naukri</a> · <a href="/guides/compress-pdf-for-workday">Workday</a></li>
            <li><a href="/guides/compress-pdf-for-email">Compress PDF for email</a></li>
            </ul>
            <p><a href="/pdf/compress">Compress PDF free</a> · <a href="/research/attachment-size-limits">Attachment limits</a></p>
            """;

        private const string CompressPdfForNaukri = """
            <h2>Naukri resume PDF size limits</h2>
            <p>Naukri.com and most India job portals cap resume uploads around <strong>2 MB per PDF</strong>. Limits can vary by employer microsite, but targeting 2 MB avoids the most common "file too large" errors on Naukri profile upload and Quick Apply flows.</p>
            <p>Unlike email attachments (25 MB on Gmail), Indian job boards optimise for fast mobile uploads and recruiter database indexing — small, text-selectable PDFs perform best. Hub: <a href="/guides/compress-pdf-for-job-application">job application guide</a>.</p>

            <h2>Why Naukri rejects your resume PDF</h2>
            <ul>
            <li><strong>Canva or Photoshop resume designs</strong> — graphics inflate size; ATS may not parse layout.</li>
            <li><strong>Two-page resume with photo</strong> — profile pictures add 500 KB–2 MB alone.</li>
            <li><strong>Scanned resume from print shop</strong> — 300 dpi colour scans exceed 2 MB quickly.</li>
            <li><strong>Embedded custom fonts</strong> — decorative typefaces increase bytes without recruiter benefit.</li>
            </ul>
            <p>Naukri recruiters search parsed resume text. A beautiful image-only PDF uploads but ranks poorly in keyword search — export digitally from Word or Google Docs.</p>

            <h2>Step-by-step: compress resume for Naukri</h2>
            <ol>
            <li>Export PDF from Word/Google Docs with standard fonts (Arial, Calibri).</li>
            <li>Check size on the <a href="/pdf-size-checker">PDF size checker</a> — target under 2 MB.</li>
            <li>Upload to <a href="/pdf/compress">Compress PDF</a> → <strong>Recommended</strong> compression.</li>
            <li>Verify text selects (highlight your phone number and email).</li>
            <li>Upload to Naukri profile or apply flow as <code>Name_Resume.pdf</code>.</li>
            </ol>
            <p>Also applies to: Shine, Monster India, and TimesJobs — same 2 MB target. <a href="/guides/compress-pdf-for-indeed">Indeed guide</a> · <a href="/guides/compress-pdf-for-linkedin">LinkedIn guide</a>.</p>

            <h2>Indian resume format tips</h2>
            <ul>
            <li><strong>One page preferred</strong> for 0–8 years experience; two pages only if senior roles require detail.</li>
            <li><strong>Include mobile number with +91</strong> — ensure it parses as text, not image.</li>
            <li><strong>Skip photo</strong> unless employer requests — saves space and reduces bias concerns.</li>
            <li><strong>List skills as text</strong> — not icons — so Naukri keyword search matches.</li>
            </ul>

            <h2>Compression levels for Naukri</h2>
            <p>Use <strong>Recommended</strong> as default. <strong>Less</strong> if already under 2 MB and you use subtle design elements. <strong>Extreme</strong> only as last resort — re-check that name, email, and phone still select as text afterward.</p>
            <p>Scanned resumes: re-scan at 200 dpi grayscale in Adobe Scan or Microsoft Lens before compressing — often better than Extreme on a 300 dpi colour photo.</p>

            <h2>Uploading certificates on Naukri</h2>
            <p>Experience certificates and offer letters sometimes attach separately:</p>
            <ol>
            <li>Scan at 200–300 dpi grayscale.</li>
            <li>Compress with Recommended — target 500 KB–1 MB per certificate.</li>
            <li>Verify company letterhead text at 100% zoom.</li>
            </ol>

            <h2>Troubleshooting</h2>
            <ul>
            <li><strong>"File size exceeded"</strong> — compress to under 2 MB; remove photo and portfolio pages from resume PDF.</li>
            <li><strong>Profile updated but recruiter search misses skills</strong> — resume may be image-based; re-export digital PDF.</li>
            <li><strong>Upload works on desktop but fails on app</strong> — mobile may enforce stricter cap; use compressed copy from Downloads.</li>
            </ul>

            <h2>Related guides</h2>
            <ul>
            <li><a href="/guides/compress-pdf-for-job-application">Job application hub</a></li>
            <li><a href="/guides/compress-pdf-for-indeed">Indeed</a> · <a href="/guides/compress-pdf-for-linkedin">LinkedIn</a></li>
            <li><a href="/guides/pdf-to-word-resume">PDF to Word for resume</a></li>
            <li><a href="/guides/compress-pdf-for-gmail">Compress for Gmail</a> (emailing resume to HR)</li>
            </ul>
            <p><a href="/pdf/compress">Compress PDF free</a></p>
            """;

        private const string CompressPdfForYahooMail = """
            <h2>Yahoo Mail attachment size limit</h2>
            <p>Yahoo Mail allows attachments up to <strong>25 MB per email</strong> (<a href="https://help.yahoo.com/kb/SLN4556.html" rel="noopener noreferrer" target="_blank">Yahoo Help</a>). AOL Mail (Yahoo-owned) follows similar limits. As with Gmail, Base64 encoding adds ~33% overhead — aim for <strong>18–20 MB</strong> raw PDF size before attaching.</p>
            <p>Parent guide: <a href="/guides/compress-pdf-for-email">compress PDF for email</a>. Limits table: <a href="/research/attachment-size-limits">attachment size limits (2026)</a>.</p>

            <h2>Why Yahoo Mail blocks your PDF</h2>
            <ul>
            <li>Phone scans at full resolution (common for Yahoo's mobile-heavy user base)</li>
            <li>Photo-heavy newsletters or catalog PDFs saved for forwarding</li>
            <li>Multiple attachments in one draft exceeding combined message budget</li>
            <li>Forwarding a chain where earlier attachments still count toward size</li>
            </ul>
            <p>Yahoo has no built-in PDF shrink tool — compress externally with <a href="/pdf/compress">Compress PDF</a> before attach.</p>

            <h2>Step-by-step: compress PDF for Yahoo Mail</h2>
            <ol>
            <li>Check size with the <a href="/pdf-size-checker">PDF size checker</a> (Yahoo/AOL preset).</li>
            <li>Upload to <a href="/pdf/compress">Compress PDF</a> → <strong>Recommended</strong> compression.</li>
            <li>Review the size report — retry with Extreme only if still over 20 MB and fine print remains readable.</li>
            <li>Download compressed PDF; attach via Yahoo Mail paperclip icon (desktop or mobile app).</li>
            </ol>

            <h2>Yahoo Mail desktop vs mobile app</h2>
            <p><strong>Desktop browser:</strong> attach compressed file directly — fastest workflow after RatPDF compression.</p>
            <p><strong>Mobile app:</strong> compress in mobile browser first (<a href="/guides/compress-pdf-on-android">Android</a> · <a href="/guides/compress-pdf-on-iphone">iPhone</a>), save to Downloads/Files, then attach in Yahoo Mail app.</p>

            <h2>Compression level guidance</h2>
            <ul>
            <li><strong>Less</strong> — legal documents, signed forms with fine print</li>
            <li><strong>Recommended</strong> — default for proposals, invoices, reports</li>
            <li><strong>Extreme</strong> — last resort when Yahoo still rejects; verify stamps at 100% zoom</li>
            </ul>
            <p>If Extreme blurs text, <a href="/guides/split-pdf-for-email">split the PDF</a> instead.</p>

            <h2>Yahoo Mail vs Gmail / Outlook</h2>
            <p>Yahoo's 25 MB cap matches Gmail's published limit, but Yahoo users often forward large scan batches without Drive integration equivalent to Gmail's seamless large-file workflow. Compression before attach is more important on Yahoo than switching to a cloud link.</p>
            <p>Compare: <a href="/guides/compress-pdf-for-gmail">Gmail</a> · <a href="/guides/compress-pdf-for-outlook">Outlook</a> · <a href="/guides/compress-pdf-for-protonmail">Proton Mail</a>.</p>

            <h2>Troubleshooting</h2>
            <ul>
            <li><strong>Attachment too large after compression</strong> — remove other attachments from draft; try Extreme or split.</li>
            <li><strong>Send fails on mobile data</strong> — large uploads timeout; compress further or use Wi-Fi.</li>
            <li><strong>Recipient on corporate Exchange rejects</strong> — their gateway may cap at 10 MB; re-compress to 8–10 MB.</li>
            </ul>

            <h2>Related guides</h2>
            <ul>
            <li><a href="/guides/compress-pdf-for-email">Email hub</a> · <a href="/guides/pdf-email-attachment-checklist">Email attachment checklist</a></li>
            <li><a href="/guides/compress-pdf-for-gmail">Gmail</a> · <a href="/guides/compress-pdf-for-outlook">Outlook</a></li>
            </ul>
            <p><a href="/pdf/compress">Compress PDF free</a></p>
            """;

        private const string CompressPdfForProtonmail = """
            <h2>Proton Mail attachment limits</h2>
            <p>Proton Mail caps attachments at <strong>25 MB per file</strong> on paid plans (<a href="https://proton.me/support/attachment-limit" rel="noopener noreferrer" target="_blank">Proton Support</a>). Free-tier limits are lower (historically ~1 MB for some attachment types — verify your plan). Target <strong>under 20 MB</strong> on paid Proton Mail before attaching.</p>
            <p>Proton encrypts message bodies end-to-end — it does <strong>not</strong> re-compress your PDF like some webmail optimisers. You control file size before encryption. Hub: <a href="/guides/compress-pdf-for-email">compress PDF for email</a>.</p>

            <h2>Why privacy-conscious users still need compression</h2>
            <p>Proton Mail users often send sensitive documents — legal letters, medical records, financial statements. Large files cause:</p>
            <ul>
            <li>Upload timeouts on mobile networks before encryption completes</li>
            <li>Recipient Proton or non-Proton gateways rejecting oversized payloads</li>
            <li>Slow decrypt-and-download on the recipient's device</li>
            </ul>
            <p>Compress a delivery copy; keep an uncompressed master in local encrypted storage. Security hub: <a href="/guides/secure-pdf-workflow">secure PDF workflow</a>.</p>

            <h2>Step-by-step: compress PDF for Proton Mail</h2>
            <ol>
            <li>Check size with <a href="/pdf-size-checker">PDF size checker</a> (aim under 20 MB).</li>
            <li>Upload to <a href="/pdf/compress">Compress PDF</a> → <strong>Recommended</strong>.</li>
            <li>Verify readability at 100% zoom — especially for legal fine print.</li>
            <li>Optionally <a href="/guides/password-protect-pdf">password-protect</a> before attach for defence-in-depth.</li>
            <li>Attach in Proton Mail compose — lock icon confirms encryption to Proton recipients.</li>
            </ol>

            <h2>Compression and confidentiality</h2>
            <p>RatPDF processes files over HTTPS and deletes after download — it does not retain copies. For highly sensitive PDFs:</p>
            <ul>
            <li>Compress on a trusted device and network</li>
            <li><a href="/guides/pdf-redaction">Redact</a> third-party PII before send</li>
            <li>Share password for password-protected PDFs on a separate channel (Signal, phone)</li>
            </ul>
            <p>Blog: <a href="/blog/remote-work-pdf-security">remote work PDF security</a>.</p>

            <h2>Compression levels</h2>
            <ul>
            <li><strong>Less</strong> — contracts, medical records with fine type</li>
            <li><strong>Recommended</strong> — default for HR packs, invoices, reports</li>
            <li><strong>Extreme</strong> — when Proton still blocks attach; verify every page before send</li>
            </ul>
            <p>If Extreme blurs content, <a href="/guides/split-pdf-for-email">split into parts</a> with part numbers in the subject line.</p>

            <h2>Proton Mail to non-Proton recipients</h2>
            <p>Password-protected messages to Gmail or Outlook recipients use a link + password model. The PDF attachment inside still must respect size limits on the recipient's server after decryption. Target 10–15 MB when emailing law firms or banks outside Proton.</p>

            <h2>Related guides</h2>
            <ul>
            <li><a href="/guides/compress-pdf-for-email">Email hub</a></li>
            <li><a href="/guides/compress-pdf-for-gmail">Gmail</a> · <a href="/guides/compress-pdf-for-outlook">Outlook</a> · <a href="/guides/compress-pdf-for-yahoo-mail">Yahoo Mail</a></li>
            <li><a href="/guides/password-protect-pdf">Password protect PDF</a></li>
            </ul>
            <p><a href="/pdf/compress">Compress PDF free</a></p>
            """;

        private const string CompressPdfForWhatsapp = """
            <h2>WhatsApp PDF size limits</h2>
            <p>WhatsApp allows document sharing up to <strong>100 MB</strong> per file — far higher than email. So why compress?</p>
            <ul>
            <li><strong>Mobile send speed</strong> — a 40 MB PDF stalls on 4G; recipients on slow networks abandon downloads.</li>
            <li><strong>Storage on recipient phones</strong> — large files fill device storage quickly in group chats.</li>
            <li><strong>Data costs</strong> — international WhatsApp forwards on metered data add up.</li>
            <li><strong>Forwarding chains</strong> — each re-forward duplicates bytes in chat history.</li>
            </ul>
            <p>Target <strong>5–15 MB</strong> for everyday WhatsApp document sharing. Tool: <a href="/pdf/compress">Compress PDF</a>.</p>

            <h2>Document vs photo — attach correctly</h2>
            <p>WhatsApp treats attachments differently:</p>
            <ul>
            <li><strong>Document</strong> (paperclip → Document) — preserves PDF format; recipient opens in PDF viewer. <strong>Always use this for PDFs.</strong></li>
            <li><strong>Gallery / Camera</strong> — converts pages to JPEG; text becomes unselectable and blurry on zoom.</li>
            </ul>
            <p>Compress first, then attach as <strong>Document</strong> — not as images in the photo album.</p>

            <h2>Step-by-step: compress PDF for WhatsApp (mobile)</h2>
            <ol>
            <li>Open <a href="/pdf/compress">Compress PDF</a> in Chrome or Safari on your phone.</li>
            <li>Upload the PDF from Files (iOS) or Downloads (Android).</li>
            <li>Select <strong>Recommended</strong> compression.</li>
            <li>Download the compressed file to your device.</li>
            <li>In WhatsApp → Attach → <strong>Document</strong> → select the compressed PDF.</li>
            </ol>
            <p>Mobile guides: <a href="/guides/compress-pdf-on-iphone">iPhone</a> · <a href="/guides/compress-pdf-on-android">Android</a>.</p>

            <h2>Step-by-step: compress PDF for WhatsApp (desktop)</h2>
            <ol>
            <li>Compress on <a href="/pdf/compress">RatPDF</a> with Recommended.</li>
            <li>Download to your PC.</li>
            <li>WhatsApp Desktop → Attach → Document → select file.</li>
            </ol>
            <p>WhatsApp Web uses the same document attach flow.</p>

            <h2>Compression levels for WhatsApp</h2>
            <ul>
            <li><strong>Recommended</strong> — invoices, contracts, school handouts, menus (default)</li>
            <li><strong>Less</strong> — brochures with product photos you need sharp on phone screens</li>
            <li><strong>Extreme</strong> — only when you must push a very large scan through slow networks — verify text at zoom</li>
            </ul>
            <p>Benchmark: <a href="/research/pdf-compression-benchmark">PDF compression benchmark</a>.</p>

            <h2>Common WhatsApp PDF scenarios</h2>
            <h3>India: GST invoice to client</h3>
            <p>Compress before WhatsApp forward to CA or client — keeps file under 2 MB for easy phone preview. <a href="/guides/compress-gst-invoice-pdf">Compress GST invoice PDF</a>.</p>
            <h3>Real estate brochure</h3>
            <p>Photo-heavy listings — Recommended usually preserves listing photos at phone-readable quality. <a href="/guides/compress-pdf-real-estate">Real estate compression</a>.</p>
            <h3>School circular to parents</h3>
            <p>Teachers forwarding 20-page scans — compress so parents on budget phones can open instantly. <a href="/guides/compress-pdf-teachers">Teachers guide</a>.</p>
            <h3>Group chat document spam</h3>
            <p>Compress before posting to large groups — reduces everyone's storage burden and respects data limits.</p>

            <h2>WhatsApp vs Telegram</h2>
            <p>Telegram allows up to 2 GB — compression is optional there except for mobile speed. WhatsApp's practical UX limit is much lower despite the 100 MB hard cap. <a href="/guides/compress-pdf-for-telegram">Compress PDF for Telegram</a>.</p>

            <h2>Security note</h2>
            <p>WhatsApp uses end-to-end encryption for chats, but group members and forwarded chains expand exposure. For payroll, medical, or legal PDFs, consider <a href="/guides/password-protect-pdf">password protection</a> before share.</p>

            <h2>Related guides</h2>
            <ul>
            <li><a href="/guides/compress-pdf-for-email">Email hub</a> · <a href="/guides/compress-pdf-for-telegram">Telegram</a></li>
            <li><a href="/guides/compress-pdf-for-gmail">Gmail</a> (when email is better than WhatsApp)</li>
            <li><a href="/guides/compress-pdf-with-images">Compress PDF with images</a></li>
            </ul>
            <p><a href="/pdf/compress">Compress PDF free</a> · <a href="/research/attachment-size-limits">Size limits table</a></p>
            """;

        private const string CompressPdfForJobApplication = """
            <h2>Job application PDF size limits — the real numbers</h2>
            <p>Employer portals, ATS systems, and email inboxes each enforce different caps. There is no single "job application limit" — but these ranges cover most U.S., UK, EU, and India flows in 2026:</p>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>Channel</th><th>Typical cap</th><th>Safe target</th></tr></thead>
            <tbody>
            <tr><td>ATS / career page upload</td><td>2–5 MB</td><td><strong>Under 2 MB</strong></td></tr>
            <tr><td>Workday / Taleo apply</td><td>2–5 MB per file</td><td>Under 2 MB</td></tr>
            <tr><td>Email to recruiter</td><td>10–25 MB</td><td>5–10 MB</td></tr>
            <tr><td>Portfolio supplement</td><td>5–10 MB</td><td>Under 5 MB</td></tr>
            </tbody>
            </table></div>
            <p>Full reference: <a href="/research/attachment-size-limits">attachment size limits</a>. Tool: <a href="/pdf/compress">Compress PDF</a>.</p>

            <h2>Why ATS rejects or ignores your PDF</h2>
            <p>Upload failure and ATS parsing failure are different problems:</p>
            <ul>
            <li><strong>Size rejection</strong> — portal shows error or spinner; fix with compression.</li>
            <li><strong>Image-only resume</strong> — upload succeeds but keywords do not parse; fix by exporting digital PDF from Word.</li>
            <li><strong>Complex tables and columns</strong> — ATS reads left-to-right; multi-column Canva layouts scramble order.</li>
            <li><strong>Password-protected PDF</strong> — ATS cannot open; <a href="/guides/unlock-pdf">unlock</a> before upload.</li>
            </ul>
            <p>Compression fixes size — not layout. Use a simple single-column digital export first, then compress.</p>

            <h2>Step-by-step: compress resume for any job portal</h2>
            <ol>
            <li><strong>Read the apply form</strong> — note max file size if displayed (often in fine print near upload button).</li>
            <li><strong>Export digital PDF</strong> from Word or Google Docs — one page for most roles.</li>
            <li><strong>Check size</strong> on <a href="/pdf-size-checker">PDF size checker</a>.</li>
            <li><strong>Compress with Recommended</strong> on <a href="/pdf/compress">RatPDF</a>.</li>
            <li><strong>Verify text selects</strong> — highlight name, email, phone, job titles.</li>
            <li><strong>Upload with professional filename</strong> — <code>FirstName_LastName_Resume.pdf</code>.</li>
            </ol>

            <h2>Platform-specific guides</h2>
            <p>This page is the hub. Drill into portal-specific workflows:</p>
            <ul>
            <li><a href="/guides/compress-pdf-for-indeed">Indeed</a> — employer-variable caps, 2 MB target</li>
            <li><a href="/guides/compress-pdf-for-linkedin">LinkedIn</a> — Easy Apply ~2 MB</li>
            <li><a href="/guides/compress-pdf-for-naukri">Naukri</a> — India portals ~2 MB</li>
            <li><a href="/guides/compress-pdf-for-workday">Workday</a> — tenant-specific limits</li>
            </ul>

            <h2>Resume vs cover letter vs portfolio</h2>
            <p>Most portals accept <strong>one file per field</strong>. Do not merge unless the form explicitly allows a single combined PDF:</p>
            <ul>
            <li><strong>Resume</strong> — one page, under 2 MB, text-selectable. Highest priority.</li>
            <li><strong>Cover letter</strong> — separate upload field; one page, under 1 MB.</li>
            <li><strong>Portfolio</strong> — compress aggressively or link to personal site; 5–10 MB max on most portals.</li>
            </ul>
            <p>If one combined upload is required: <a href="/guides/merge-pdf">merge PDF</a> resume + cover letter, then compress once. <a href="/guides/compress-before-merge-pdf">Compress before or after merge</a>.</p>

            <h2>Compression levels for ATS safety</h2>
            <ul>
            <li><strong>Less</strong> — resume already under cap; preserve design elements</li>
            <li><strong>Recommended</strong> — default; preserves selectable text on vector PDFs</li>
            <li><strong>Extreme</strong> — last resort; always re-verify text selection and heading readability</li>
            </ul>
            <p>Guide: <a href="/guides/pdf-to-word-resume">PDF to Word for resume</a> · <a href="/guides/compress-pdf-without-quality-loss">compress without quality loss</a>.</p>

            <h2>Emailing application materials to recruiters</h2>
            <p>When HR asks you to email a resume directly:</p>
            <ol>
            <li>Compress resume to 1–2 MB (fast preview on recruiter's phone).</li>
            <li>Attach cover letter as separate PDF or paste in email body.</li>
            <li>Follow <a href="/guides/compress-pdf-for-email">email compression guide</a> if total pack exceeds provider limits.</li>
            </ol>

            <h2>India-specific notes</h2>
            <p>Government job portals (UPSC, SSC, state PSC) often cap at <strong>1–5 MB</strong> with strict per-document slots. Do not merge documents unless the notification allows it. <a href="/guides/compress-pdf-for-government-forms">Government forms compression</a> · <a href="/guides/compress-pdf-for-naukri">Naukri</a>.</p>

            <h2>Troubleshooting</h2>
            <ul>
            <li><strong>Upload error with no message</strong> — try under 2 MB; switch browser; disable password protection.</li>
            <li><strong>Application saved but recruiter sees blank fields</strong> — image resume; re-export from Word.</li>
            <li><strong>Portfolio required but too large</strong> — compress with Recommended; remove bleed pages; link to Behance/Dribbble instead.</li>
            </ul>

            <h2>Related guides</h2>
            <ul>
            <li><a href="/guides/compress-pdf-for-email">Compress PDF for email</a></li>
            <li><a href="/guides/compress-pdf-guide">compress PDF guide</a></li>
            <li><a href="/guides/compress-pdf-for-university-application">University application</a> · <a href="/guides/compress-pdf-common-app">Common App</a></li>
            </ul>
            <p><a href="/pdf/compress">Compress PDF free</a></p>
            """;

        private const string CompressPdfForTelegram = """
            <h2>Telegram PDF limits — why compress when 2 GB is allowed?</h2>
            <p>Telegram allows document uploads up to <strong>2 GB</strong> — the highest limit among mainstream messaging apps. Compression is still worthwhile because:</p>
            <ul>
            <li><strong>Mobile send and download speed</strong> — 50 MB PDFs stall on 4G; channel subscribers abandon slow downloads.</li>
            <li><strong>Bot API limits</strong> — Telegram bots often cap file handling around 50 MB regardless of client limits.</li>
            <li><strong>Channel storage and CDN costs</strong> — admins distributing ebooks or course packs benefit from smaller files.</li>
            <li><strong>Recipient phone storage</strong> — large forwards fill device space in active groups.</li>
            </ul>
            <p>Practical target: <strong>10–20 MB</strong> for mobile-friendly sharing. Tool: <a href="/pdf/compress">Compress PDF</a>.</p>

            <h2>Document attach — not photo album</h2>
            <p>In Telegram:</p>
            <ul>
            <li><strong>Attach → File</strong> — sends as document; preserves PDF format and filename.</li>
            <li><strong>Send as photo</strong> — rasterises pages; text becomes unselectable.</li>
            </ul>
            <p>Compress with RatPDF, then attach as <strong>File/Document</strong>.</p>

            <h2>Step-by-step: compress PDF for Telegram</h2>
            <ol>
            <li>Check file size — aim under 15 MB for fast mobile sends.</li>
            <li>Upload to <a href="/pdf/compress">Compress PDF</a> → <strong>Recommended</strong>.</li>
            <li>Download compressed PDF.</li>
            <li>Telegram → Attach → File → select PDF.</li>
            <li>Verify signatures and fine print at 100% zoom before forwarding to groups.</li>
            </ol>
            <p>Mobile: <a href="/guides/compress-pdf-on-android">Android</a> · <a href="/guides/compress-pdf-on-iphone">iPhone</a>.</p>

            <h2>Telegram channels and group admins</h2>
            <p>Distributing course PDFs, ebooks, or newsletter archives to thousands of subscribers:</p>
            <ul>
            <li>Batch-compress with <a href="/guides/batch-compress-pdf">batch compress workflow</a> (3 files/day free tier).</li>
            <li>Target 5–10 MB per issue — faster downloads improve completion rates.</li>
            <li>Keep uncompressed masters in cloud archive: <a href="/guides/compress-pdf-cloud-storage">cloud storage guide</a>.</li>
            </ul>

            <h2>Compression levels</h2>
            <ul>
            <li><strong>Recommended</strong> — default for ebooks, reports, invoices shared in chats</li>
            <li><strong>Less</strong> — photo portfolios and design PDFs where sharpness matters</li>
            <li><strong>Extreme</strong> — very large scans for bot uploads under 50 MB — verify readability</li>
            </ul>

            <h2>Telegram vs WhatsApp</h2>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>App</th><th>Hard cap</th><th>Practical target</th></tr></thead>
            <tbody>
            <tr><td>Telegram</td><td>2 GB</td><td>10–20 MB for mobile UX</td></tr>
            <tr><td>WhatsApp</td><td>100 MB</td><td>5–15 MB</td></tr>
            </tbody>
            </table></div>
            <p><a href="/guides/compress-pdf-for-whatsapp">Compress PDF for WhatsApp</a> · <a href="/guides/compress-pdf-for-email">Email hub</a>.</p>

            <h2>Security for sensitive PDFs in Telegram</h2>
            <p>Telegram cloud chats are not end-to-end encrypted by default (Secret Chats are). For contracts, payroll, or medical PDFs:</p>
            <ul>
            <li>Use Secret Chat for E2E (mobile only, both parties online)</li>
            <li><a href="/guides/password-protect-pdf">Password-protect</a> the PDF regardless</li>
            <li>Consider email with <a href="/guides/compress-pdf-for-protonmail">Proton Mail</a> for regulated content</li>
            </ul>

            <h2>Related guides</h2>
            <ul>
            <li><a href="/guides/compress-pdf-for-whatsapp">WhatsApp</a> · <a href="/guides/compress-pdf-for-email">Email</a></li>
            <li><a href="/guides/compress-pdf-with-images">Compress PDF with images</a></li>
            <li><a href="/guides/compress-pdf-guide">Compress PDF guide</a></li>
            </ul>
            <p><a href="/pdf/compress">Compress PDF free</a> · <a href="/research/attachment-size-limits">Size limits</a></p>
            """;

        private const string CompressPdfForWorkday = """
            <h2>Workday PDF upload limits — tenant by tenant</h2>
            <p>Workday Recruiting is used by Fortune 500 employers, universities, and hospitals — but <strong>each tenant configures its own file limits</strong>. There is no single Workday-global cap. Common ranges observed on live apply flows:</p>
            <ul>
            <li><strong>2–5 MB</strong> per resume PDF (most common on Workday Apply)</li>
            <li><strong>5–10 MB</strong> for cover letters, transcripts, or portfolio supplements</li>
            <li><strong>Separate upload field per document</strong> — resume, cover letter, and attachments are usually independent slots</li>
            </ul>
            <p>Always read the fine print on the upload widget before compressing. Hub: <a href="/guides/compress-pdf-for-job-application">job application guide</a>. Related: <a href="/guides/compress-pdf-for-indeed">Indeed</a> · <a href="/guides/compress-pdf-for-linkedin">LinkedIn</a>.</p>

            <h2>Why Workday rejects your PDF</h2>
            <ul>
            <li><strong>File over tenant max</strong> — error appears after long upload spinner.</li>
            <li><strong>Image-only resume</strong> — upload succeeds but Workday Recruiting parses zero skills; export digital PDF from Word.</li>
            <li><strong>Wrong field</strong> — portfolio PDF uploaded to resume slot with lower cap.</li>
            <li><strong>Password-protected or corrupted PDF</strong> — silent failure; <a href="/guides/unlock-pdf">unlock</a> first.</li>
            </ul>
            <p>Workday's parser expects a <strong>text layer</strong> — same ATS rule as Indeed and Taleo. Compression fixes size, not image-only exports.</p>

            <h2>Step-by-step: compress resume for Workday</h2>
            <ol>
            <li>On the Workday apply form, note each upload field's max size (hover or error text).</li>
            <li>Export resume as digital PDF from Word or Google Docs — single column, standard fonts.</li>
            <li>Check size on <a href="/pdf-size-checker">PDF size checker</a> — default target <strong>under 2 MB</strong>.</li>
            <li>Upload to <a href="/pdf/compress">Compress PDF</a> → <strong>Recommended</strong>.</li>
            <li>Verify text selects — highlight name, email, most recent job title.</li>
            <li>Upload to Workday with filename <code>LastName_FirstName_Resume.pdf</code>.</li>
            </ol>

            <h2>Multi-document Workday applications</h2>
            <p>Enterprise Workday flows often request:</p>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>Document</th><th>Typical cap</th><th>Compression tip</th></tr></thead>
            <tbody>
            <tr><td>Resume/CV</td><td>2–5 MB</td><td>One page digital PDF; Recommended compression</td></tr>
            <tr><td>Cover letter</td><td>2–5 MB</td><td>One page; often under 500 KB without compression</td></tr>
            <tr><td>Transcript</td><td>5–10 MB</td><td>University digital export; compress if scan-heavy</td></tr>
            <tr><td>Portfolio / writing sample</td><td>5–10 MB</td><td>Remove bleed pages; compress images</td></tr>
            <tr><td>DD-214 / certification scans</td><td>2–5 MB</td><td>200 dpi grayscale scan, then Recommended</td></tr>
            </tbody>
            </table></div>
            <p>Do <strong>not</strong> merge documents unless the form has a single "supporting documents" slot. <a href="/guides/merge-pdf">Merge PDF</a> only when explicitly allowed.</p>

            <h2>Compression levels for Workday ATS</h2>
            <ul>
            <li><strong>Less</strong> — resume already under cap; preserve subtle design</li>
            <li><strong>Recommended</strong> — default; preserves selectable text on vector PDFs</li>
            <li><strong>Extreme</strong> — only if tenant cap still exceeded; re-verify every heading parses via text selection</li>
            </ul>
            <p>Avoid Canva multi-column resumes — Workday reads left-to-right and scrambles column order. Simple Word template + Recommended compression outperforms designed PDFs in parsing.</p>

            <h2>Workday vs Taleo vs iCIMS</h2>
            <p>Many employers brand the portal "Workday" but the same compression rules apply to Taleo, iCIMS, and Greenhouse: <strong>2 MB resume target</strong>, digital export, text-selectable output. This guide's workflow transfers directly. <a href="/guides/compress-pdf-for-job-application">Job application hub</a>.</p>

            <h2>University and hospital Workday tenants</h2>
            <p>Academic and healthcare Workday instances often request CVs (multi-page) plus license scans:</p>
            <ul>
            <li>CV may allow 5 MB — still compress if over cap</li>
            <li>License and certification scans: 200 dpi grayscale, Recommended, verify license number at zoom</li>
            <li>Research statements: compress image-heavy PDFs before upload</li>
            </ul>

            <h2>Troubleshooting</h2>
            <ul>
            <li><strong>Spinner then nothing</strong> — file too large; compress to under 2 MB; try different browser.</li>
            <li><strong>"Invalid file type"</strong> — ensure true PDF export, not renamed .docx.</li>
            <li><strong>Application saved but profile empty</strong> — image resume; re-export from Word.</li>
            <li><strong>Mobile apply fails</strong> — compress on desktop browser first, transfer via email/cloud to phone.</li>
            </ul>

            <h2>Related guides</h2>
            <ul>
            <li><a href="/guides/compress-pdf-for-job-application">Job application hub</a></li>
            <li><a href="/guides/compress-pdf-for-indeed">Indeed</a> · <a href="/guides/compress-pdf-for-linkedin">LinkedIn</a> · <a href="/guides/compress-pdf-for-naukri">Naukri</a></li>
            <li><a href="/guides/pdf-to-word-resume">PDF to Word for resume</a></li>
            <li><a href="/guides/compress-pdf-usajobs">USAJOBS</a> (federal jobs — separate portal)</li>
            </ul>
            <p><a href="/pdf/compress">Compress PDF free</a></p>
            """;

        private const string CompressPdfForLms = """
            <h2>LMS PDF upload limits — Canvas, Blackboard, Moodle</h2>
            <p>Learning management systems cap assignment uploads at the <strong>institution level</strong> and sometimes per-assignment. Typical defaults:</p>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>Platform</th><th>Instance default</th><th>Safe target</th></tr></thead>
            <tbody>
            <tr><td>Canvas</td><td>Up to 100 MB per file</td><td>Check assignment page — instructors may set 10–25 MB</td></tr>
            <tr><td>Blackboard Learn</td><td>50–250 MB (admin-configured)</td><td>Under 10 MB for compatibility</td></tr>
            <tr><td>Moodle</td><td>50–200 MB (site setting)</td><td>Under 10–25 MB unless assignment specifies otherwise</td></tr>
            </tbody>
            </table></div>
            <p>Full table: <a href="/research/attachment-size-limits">attachment size limits</a>. Tool: <a href="/pdf/compress">Compress PDF</a>. Pillar links Canvas and Blackboard here (merged P0 URLs).</p>

            <h2>Why students hit LMS upload errors</h2>
            <ul>
            <li><strong>Instructor lowered cap</strong> — assignment says 10 MB but Canvas instance allows 100 MB.</li>
            <li><strong>Phone photo of handwritten homework</strong> — 300 dpi colour photos exceed caps quickly.</li>
            <li><strong>Combined report + appendix</strong> — merged PDF from multiple scans without compression.</li>
            <li><strong>Slow campus Wi-Fi timeout</strong> — large files fail mid-upload; smaller files succeed.</li>
            </ul>

            <h2>Step-by-step: compress PDF for LMS submission</h2>
            <ol>
            <li>Read the assignment page for the <strong>exact file size limit</strong> and accepted formats (PDF only vs PDF/DOCX).</li>
            <li>If scanning homework, use document mode at <strong>200–300 dpi grayscale</strong> before PDF export.</li>
            <li>Upload to <a href="/pdf/compress">Compress PDF</a> → <strong>Recommended</strong> for typed reports; <strong>Less</strong> for handwritten scans where clarity matters.</li>
            <li>Verify equations, handwriting, and diagrams at 100% zoom.</li>
            <li>Submit on Canvas/Blackboard/Moodle before the deadline — keep a local copy.</li>
            </ol>
            <p>Student merge workflow: <a href="/guides/merge-pdf-students">merge PDF for students</a> · <a href="/guides/compress-pdf-students">compress PDF for students</a>.</p>

            <h2>Platform-specific notes</h2>
            <h3>Canvas</h3>
            <p>Many U.S. universities run Canvas with generous instance limits, but professors routinely set <strong>5–20 MB</strong> on final papers. Check the rubric. Mobile Canvas app uploads fail more often on large files — compress before submit.</p>
            <h3>Blackboard</h3>
            <p>Older Blackboard instances at community colleges often cap at <strong>10 MB</strong>. Target 8 MB after compression for safety. Safe Assign and Turnitin still accept compressed PDFs if text is selectable.</p>
            <h3>Moodle</h3>
            <p>European and APAC institutions on Moodle — limits vary widely. If upload fails silently, compress to under 5 MB and retry.</p>

            <h2>Typed report vs handwritten scan</h2>
            <ul>
            <li><strong>Word/Google Docs export</strong> — often under cap already; compress only if over limit or for faster upload.</li>
            <li><strong>Handwritten math/science</strong> — use Less compression to preserve pencil marks; re-scan at lower DPI instead of Extreme.</li>
            <li><strong>Group project merge</strong> — <a href="/guides/merge-pdf">merge sections</a>, then one Recommended compression pass. <a href="/guides/compress-before-merge-pdf">Compress before or after merge</a>.</li>
            </ul>

            <h2>Faculty and TA distribution</h2>
            <p>Instructors uploading reading packs to LMS:</p>
            <ul>
            <li>Compress scan-heavy readings before posting — students on mobile data benefit.</li>
            <li><a href="/guides/compress-pdf-teachers">Compress PDF for teachers</a></li>
            <li>OCR scanned chapters for searchable course packs: <a href="/guides/ocr-pdf">OCR PDF</a></li>
            </ul>

            <h2>Troubleshooting</h2>
            <ul>
            <li><strong>Upload stuck at 99%</strong> — file too large for assignment cap; compress and retry.</li>
            <li><strong>Turnitin similarity report missing</strong> — usually unrelated to compression if text layer exists.</li>
            <li><strong>Professor cannot open your PDF</strong> — avoid password protection; export standard PDF from Word.</li>
            </ul>

            <h2>Related guides</h2>
            <ul>
            <li><a href="/guides/compress-pdf-for-email">Email</a> (submitting to professor via email instead)</li>
            <li><a href="/guides/compress-pdf-common-app">Common App</a> · <a href="/guides/compress-pdf-for-university-application">University application</a></li>
            <li><a href="/guides/compress-pdf-guide">Compress PDF guide</a></li>
            </ul>
            <p><a href="/pdf/compress">Compress PDF free</a></p>
            """;

        private const string CompressPdfForVisaApplication = """
            <h2>Visa application PDF size limits</h2>
            <p>Embassy, consulate, and VFS Global portals cap uploads per slot or per combined packet. Ranges by region (verify on live portal before filing):</p>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>Destination</th><th>Typical cap</th><th>Notes</th></tr></thead>
            <tbody>
            <tr><td>Schengen / VFS Global</td><td>2–5 MB per file</td><td><a href="/guides/compress-pdf-schengen-visa">Schengen guide</a></td></tr>
            <tr><td>UK (UKVI)</td><td>2–10 MB</td><td><a href="/guides/compress-pdf-ukvi">UKVI guide</a></td></tr>
            <tr><td>USCIS (online forms)</td><td>6–12 MB per upload</td><td>Form-specific</td></tr>
            <tr><td>Australia ImmiAccount</td><td>5 MB per document</td><td><a href="/guides/compress-pdf-home-affairs-australia">Home Affairs guide</a></td></tr>
            <tr><td>Canada IRCC</td><td>4 MB per file (common)</td><td><a href="/guides/compress-pdf-immigration-canada">Canada immigration guide</a></td></tr>
            <tr><td>India OCI / visa portals</td><td>1–5 MB</td><td>Per-document slots</td></tr>
            </tbody>
            </table></div>
            <p>Research: <a href="/research/attachment-size-limits">attachment size limits</a>. Tool: <a href="/pdf/compress">Compress PDF</a>.</p>

            <h2>Why visa portals reject your PDF</h2>
            <ul>
            <li><strong>Phone scans at full resolution</strong> — bank statements and passport pages exceed 5 MB each.</li>
            <li><strong>Merged packet too large</strong> — correct documents but combined over cap.</li>
            <li><strong>Blurry stamps after over-compression</strong> — bank seal illegible → manual review delay.</li>
            <li><strong>Wrong slot</strong> — combined PDF uploaded where portal expects one document per field.</li>
            </ul>

            <h2>Merge first, then compress once</h2>
            <p>When the portal accepts <strong>one combined PDF</strong>:</p>
            <ol>
            <li>Gather documents in embassy checklist order (application form, passport bio, photos, bank statements, insurance, itinerary…).</li>
            <li><a href="/guides/merge-pdf-visa-application">Merge visa documents</a> in exact sequence.</li>
            <li>Run <strong>one Recommended compression pass</strong> on the merged file — avoids double lossy encoding on individual docs.</li>
            <li>Verify passport MRZ, bank balances, and stamp clarity at 100% zoom.</li>
            </ol>
            <p>When the portal has <strong>separate upload fields</strong> — one PDF per slot, compress each to 500 KB–2 MB. <a href="/guides/compress-before-merge-pdf">Compress before or after merge</a>.</p>

            <h2>Scan settings for visa documents</h2>
            <ul>
            <li><strong>200–300 dpi grayscale</strong> for bank statements and utility bills</li>
            <li><strong>Colour only when required</strong> — passport bio page, coloured visa stickers</li>
            <li><strong>Crop margins</strong> in scan app — fewer pixels, smaller file</li>
            <li><strong>Straight alignment</strong> — skewed scans OCR poorly and re-scan waste bytes</li>
            </ul>
            <p>Bank statements: <a href="/guides/compress-bank-statement-pdf">compress bank statement PDF</a>.</p>

            <h2>Compression levels for visa uploads</h2>
            <ul>
            <li><strong>Less</strong> — bank stamps, notarised affidavits, passport pages with fine security print</li>
            <li><strong>Recommended</strong> — default for merged packs and multi-page statements</li>
            <li><strong>Extreme</strong> — only when portal still rejects; re-read every account number and date</li>
            </ul>
            <p>Keep an <strong>uncompressed original</strong> on disk for the visa interview — officers may ask to see crisp copies.</p>

            <h2>Document-specific tips</h2>
            <h3>Bank statements (3–6 months)</h3>
            <p>Digital PDF downloads from your bank are smallest. Scan only if the embassy requires stamped paper copies. Compress merged statements as one file if portal allows.</p>
            <h3>Travel insurance</h3>
            <p>Single-page certificate — usually under 1 MB without compression. Phone photo scans need Recommended pass.</p>
            <h3>Employment letter</h3>
            <p>Digital letterhead PDF from employer — rarely needs compression. Scan of signed letter: 200 dpi grayscale.</p>
            <h3>Invitation letter / sponsorship</h3>
            <p>Merge with sponsor's financial docs only if checklist groups them. Otherwise separate slots.</p>

            <h2>Troubleshooting</h2>
            <ul>
            <li><strong>Upload fails with no error</strong> — try under 2 MB; different browser; disable VPN.</li>
            <li><strong>VFS appointment system timeout</strong> — compress before upload on slow connections.</li>
            <li><strong>Officer requests clearer copy at interview</strong> — bring uncompressed originals; compressed upload copy is for portal only.</li>
            </ul>

            <h2>Related guides</h2>
            <ul>
            <li><a href="/guides/compress-pdf-schengen-visa">Schengen visa</a> · <a href="/guides/compress-pdf-ukvi">UKVI</a></li>
            <li><a href="/guides/compress-pdf-home-affairs-australia">Australia Home Affairs</a> · <a href="/guides/compress-pdf-immigration-canada">Canada IRCC</a></li>
            <li><a href="/guides/compress-pdf-for-passport-application">Passport application</a></li>
            <li><a href="/guides/compress-pdf-for-government-forms">India government forms</a></li>
            </ul>
            <p><a href="/pdf/compress">Compress PDF free</a> · <a href="/pdf-size-checker">PDF size checker</a></p>
            """;

        private const string CompressPdfForGovernmentForms = """
            <h2>India e-governance PDF upload limits</h2>
            <p>Indian government portals — Passport Seva, Income Tax e-filing, GST Portal, DigiLocker, UIDAI, state PSC sites — typically cap each upload slot at <strong>1–5 MB</strong>. Limits change with policy updates; always read the live portal before submitting.</p>
            <div class="table-responsive"><table class="table table-bordered table-sm">
            <thead class="table-light"><tr><th>Portal</th><th>Typical cap</th><th>Guide</th></tr></thead>
            <tbody>
            <tr><td>Income Tax e-filing</td><td>2–5 MB</td><td><a href="/guides/compress-pdf-incometax">Income Tax guide</a></td></tr>
            <tr><td>GST Portal (supporting docs)</td><td>~5 MB</td><td><a href="/guides/compress-pdf-gst-portal">GST Portal guide</a></td></tr>
            <tr><td>Passport Seva</td><td>1–2 MB per document</td><td><a href="/guides/compress-pdf-for-passport-application">Passport guide</a></td></tr>
            <tr><td>DigiLocker upload</td><td>1–5 MB</td><td><a href="/guides/compress-pdf-digilocker">DigiLocker guide</a></td></tr>
            <tr><td>UIDAI / Aadhaar services</td><td>1–2 MB</td><td><a href="/guides/compress-pdf-uidai">UIDAI guide</a></td></tr>
            <tr><td>IRCTC</td><td>Varies</td><td><a href="/guides/compress-pdf-irctc">IRCTC guide</a></td></tr>
            </tbody>
            </table></div>
            <p>Tool: <a href="/pdf/compress">Compress PDF</a> · Checker: <a href="/pdf-size-checker">PDF size checker</a>.</p>

            <h2>Why government portals reject your PDF</h2>
            <ul>
            <li><strong>CamScanner/phone scan at 300 dpi colour</strong> — a one-page address proof can weigh 3–8 MB.</li>
            <li><strong>Multiple pages in one slot</strong> when portal expects single-page proof.</li>
            <li><strong>Wrong PDF version or encryption</strong> — export fresh PDF; <a href="/guides/unlock-pdf">unlock</a> if password-protected.</li>
            <li><strong>Illegible text after Extreme compression</strong> — officer verification fails.</li>
            </ul>

            <h2>Step-by-step: compress PDF for government upload</h2>
            <ol>
            <li>Read the portal's per-slot size limit and accepted formats (PDF only is common).</li>
            <li>Scan at <strong>200–300 dpi grayscale</strong> in document mode unless colour is mandatory (e.g. some ID proofs).</li>
            <li>Upload to <a href="/pdf/compress">Compress PDF</a> → <strong>Recommended</strong>.</li>
            <li>Target <strong>500 KB–2 MB</strong> per document using the size checker.</li>
            <li>Verify ID numbers, seals, and signatures at 100% zoom before submit.</li>
            <li>Keep uncompressed originals for your records.</li>
            </ol>

            <h2>One PDF per slot vs merged upload</h2>
            <p>Most India portals use <strong>separate upload fields</strong> — address proof, ID proof, photograph, income certificate each get their own slot. Do not merge unless the notification explicitly allows a combined PDF.</p>
            <p>When merge is allowed (some state PSC applications): <a href="/guides/merge-pdf">merge in checklist order</a>, then compress once.</p>

            <h2>Document-specific compression targets</h2>
            <ul>
            <li><strong>PAN card scan</strong> — under 500 KB. <a href="/guides/compress-pan-card-pdf">PAN card PDF</a></li>
            <li><strong>Bank statement</strong> — under 2 MB for 6-month PDF. <a href="/guides/compress-bank-statement-pdf">Bank statement guide</a></li>
            <li><strong>GST invoice proof</strong> — under 1 MB. <a href="/guides/compress-gst-invoice-pdf">GST invoice PDF</a></li>
            <li><strong>Aadhaar e-KYC printout</strong> — under 500 KB. <a href="/guides/compress-pdf-uidai">UIDAI guide</a></li>
            </ul>

            <h2>Scan app settings (Android / iPhone)</h2>
            <ol>
            <li>Open Microsoft Lens, Adobe Scan, or similar — select <strong>Document</strong> not Whiteboard.</li>
            <li>Enable <strong>grayscale</strong> for text-heavy proofs.</li>
            <li>Crop to document edges — remove desk background.</li>
            <li>Export PDF, then compress on RatPDF if still over cap.</li>
            </ol>
            <p>Mobile: <a href="/guides/compress-pdf-on-android">Android</a> · <a href="/guides/compress-pdf-on-iphone">iPhone</a>.</p>

            <h2>Troubleshooting</h2>
            <ul>
            <li><strong>"File size exceeded"</strong> — compress to under 1 MB; re-scan at lower DPI.</li>
            <li><strong>"Invalid document"</strong> — ensure PDF not corrupted; re-export from scan app.</li>
            <li><strong>Officer requests resubmission</strong> — stamp/signature blurred; use Less compression or higher DPI re-scan.</li>
            </ul>

            <h2>Related guides</h2>
            <ul>
            <li><a href="/guides/compress-pdf-for-visa-application">Visa application</a></li>
            <li><a href="/guides/compress-pdf-digilocker">DigiLocker</a> · <a href="/guides/compress-pdf-incometax">Income Tax</a></li>
            <li><a href="/guides/compress-pdf-government">Government portals (general)</a></li>
            <li><a href="/guides/invoice-generator-india">Invoice generator India</a></li>
            </ul>
            <p><a href="/pdf/compress">Compress PDF free</a></p>
            """;

        private const string InvoiceGeneratorUsa = """
            <h2>PDF invoices for U.S. freelancers and small businesses</h2>
            <p>RatPDF's <a href="/invoice/create">Create Invoice</a> tool generates professional PDF invoices with USD currency, line items, sales tax fields, and instant download — no signup required on the free tier.</p>
            <p>Parent hub: <a href="/guides/invoice-generator-guide">invoice generator guide</a>. India GST counterpart: <a href="/guides/invoice-generator-india">invoice generator India</a>.</p>

            <h2>What a U.S. invoice PDF should include</h2>
            <p>While requirements vary by state and industry, a defensible U.S. invoice typically shows:</p>
            <ul>
            <li><strong>Seller name and address</strong> — legal business name or sole proprietor name</li>
            <li><strong>Client name and billing address</strong></li>
            <li><strong>Unique invoice number</strong> and <strong>invoice date</strong></li>
            <li><strong>Line items</strong> — description, quantity, rate, line total</li>
            <li><strong>Sales tax</strong> (if applicable) — rate and amount broken out</li>
            <li><strong>Payment terms</strong> — due date, accepted methods (ACH, check, Stripe link)</li>
            <li><strong>Total due</strong> in USD</li>
            </ul>
            <p>Tax compliance reference: <a href="/guides/irs-tax-pdf-format">IRS tax document PDF format</a>. Confirm sales tax nexus and rates with your CPA.</p>

            <h2>Step-by-step: create a U.S. invoice PDF</h2>
            <ol>
            <li>Open <a href="/invoice/create">Create Invoice</a>.</li>
            <li>Fill <strong>From</strong> — business name, address, EIN (optional in Notes), phone, email.</li>
            <li>Fill <strong>Customer</strong> — client company, billing contact, address.</li>
            <li>Set currency to <strong>USD</strong>.</li>
            <li>Add <strong>line items</strong> — e.g. "Web development — March 2026", qty 1, rate $2,500.</li>
            <li>Set <strong>tax name</strong> (e.g. "Sales Tax") and <strong>rate</strong> if your state requires collection on this sale.</li>
            <li>Add payment instructions in Notes — bank routing/account, Venmo, or "Net 30".</li>
            <li>Click <strong>Generate PDF</strong> and download.</li>
            </ol>

            <h2>Sales tax on invoices — practical notes</h2>
            <p>Sales tax depends on <strong>nexus</strong> (where you and your client are located) and <strong>product vs service</strong> classification:</p>
            <ul>
            <li><strong>SaaS and digital services</strong> — taxed in some states, exempt in others.</li>
            <li><strong>Professional services</strong> (consulting, design) — often exempt in many states but not all.</li>
            <li><strong>Physical goods</strong> — usually taxable where shipped.</li>
            </ul>
            <p>RatPDF provides tax name and rate fields — you enter the correct rate for your situation. The tool does not calculate nexus. Consult a CPA or state revenue department.</p>

            <h2>Common U.S. freelancer scenarios</h2>
            <h3>1099 contractor billing a startup</h3>
            <p>USD invoice with net-15 terms, ACH details in Notes. No sales tax if exempt professional services in your state. Archive PDF for Schedule C recordkeeping.</p>
            <h3>Agency invoicing with mixed line items</h3>
            <p>Separate line items for design (hours × rate) and reimbursable expenses. Tax only taxable lines if your CPA advises itemised tax.</p>
            <h3>Out-of-state client</h3>
            <p>Destination-based tax may apply for taxable goods; many service invoices show no sales tax when no nexus in client state. Document the exemption reason in Notes if needed.</p>
            <h3>International client paying in USD</h3>
            <p>USD currency field works; note "Prices in U.S. dollars" in Notes. For INR/EUR clients see country guides.</p>

            <h2>After you generate the PDF</h2>
            <ul>
            <li><strong>Email to client</strong> — <a href="/guides/compress-pdf-for-gmail">compress for Gmail</a> if unusually large (rare for text invoices).</li>
            <li><strong>Edit a sent invoice</strong> — regenerate with corrected invoice number; do not reuse numbers. <a href="/guides/pdf-to-word-invoice">PDF to Word for invoice</a> for minor edits.</li>
            <li><strong>Recurring billing</strong> — duplicate line items each period: <a href="/guides/recurring-invoice-generator">recurring invoice guide</a>.</li>
            <li><strong>Recordkeeping</strong> — IRS generally expects records accessible for audit; PDF archive is standard. <a href="/guides/irs-tax-pdf-format">IRS PDF format guide</a>.</li>
            </ul>

            <h2>Pro features</h2>
            <p>Pro plans remove watermarks and add logo upload. See <a href="/Subscription/Plans">pricing</a>. Compare: <a href="/compare">RatPDF vs alternatives</a>.</p>

            <h2>Related guides</h2>
            <ul>
            <li><a href="/guides/invoice-generator-guide">Invoice generator hub</a></li>
            <li><a href="/guides/invoice-for-freelancers">Invoice for freelancers</a></li>
            <li><a href="/guides/invoice-generator-uk">Invoice generator UK</a> · <a href="/guides/invoice-generator-canada">Canada</a></li>
            <li><a href="/invoice/free-invoice-no-signup">Free invoice without signup</a></li>
            </ul>
            <p><a href="/invoice/create">Create USD invoice →</a></p>
            """;
    }
}
