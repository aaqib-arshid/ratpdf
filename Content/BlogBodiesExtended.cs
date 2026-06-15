namespace ratpdf.Content
{
    internal static class BlogBodiesExtended
    {
        public static string? Get(string slug) => slug switch
        {
            "free-vs-paid-pdf-tools-2026" => FreeVsPaid,
            "pdf-editing-mistakes" => EditingMistakes,
            "remote-work-pdf-security" => RemoteSecurity,
            "powerpoint-from-pdf-tips" => PowerPointTips,
            "html-to-pdf-developers" => HtmlDev,
            "pdf-redaction-vs-password" => RedactionVsPassword,
            "accountant-pdf-workflow" => AccountantWorkflow,
            "ilovepdf-vs-smallpdf-vs-ratpdf" => ThreeWayCompare,
            "browser-background-remover-privacy" => BrowserBgPrivacy,
            "json-formatter-api-debugging" => JsonApiDebug,
            "jwt-decoder-oauth-integration" => JwtOAuth,
            "medical-calculator-clinical-documentation" => MedicalDoc,
            _ => null
        };

        private const string FreeVsPaid = """
            <p>Free PDF tools are genuinely useful until you hit daily caps, file size walls, or watermark upsells. Here is how to decide when Pro ($8.99/mo on RatPDF) pays for itself.</p>
            <h2>Stay on free when</h2>
            <ul>
            <li>You process fewer than 3 files per tool per day</li>
            <li>Files stay under 200 MB</li>
            <li>You do not need API automation</li>
            </ul>
            <h2>Upgrade when</h2>
            <ul>
            <li>Agency or legal team shares one workflow across dozens of PDFs daily</li>
            <li>Scanned archives exceed 200 MB (Pro: 4 GB uploads)</li>
            <li>Smallpdf-style 2 tasks/day limits block your work</li>
            </ul>
            <p>Compare vendors: <a href="/compare">RatPDF vs iLovePDF vs Smallpdf</a> · Buyer guide: <a href="/guides/choose-pdf-tool">choose a PDF tool</a></p>
            """;

        private const string EditingMistakes = """
            <p>Quick PDF edits save time until they create compliance or layout problems. Avoid these five mistakes teams make with browser editors.</p>
            <h2>1. Editing scanned PDFs like digital PDFs</h2>
            <p>Scans are images — adding text overlays misaligns on zoom. OCR first, then edit or convert to Word.</p>
            <h2>2. Black boxes instead of redaction</h2>
            <p>See our <a href="/guides/pdf-redaction">redaction guide</a> — copy-paste can expose hidden text.</p>
            <h2>3. Losing the source file</h2>
            <p>Always archive the original before merge, rotate, or flatten operations.</p>
            <h2>4. Wrong tool for the job</h2>
            <p>Heavy redesign belongs in Word/InDesign; RatPDF <a href="/guides/edit-pdf">Edit PDF</a> suits markups and quick fixes.</p>
            """;

        private const string RemoteSecurity = """
            <p>Remote teams email PDF contracts, payslips, and board packs from home networks. Security is not only encryption — it is process.</p>
            <h2>Minimum viable policy</h2>
            <ol>
            <li>Password-protect payroll and HR PDFs; share passwords on SMS or phone</li>
            <li>Watermark drafts during review cycles</li>
            <li>Compress before upload but verify readability on mobile</li>
            <li>Delete local copies from Downloads after cloud archive</li>
            </ol>
            <p>Hub: <a href="/guides/secure-pdf-workflow">Secure PDF workflow</a> · Blog: <a href="/blog/secure-pdf-password-best-practices">password best practices</a></p>
            """;

        private const string PowerPointTips = """
            <p>Converting PDF decks to PowerPoint is faster than retyping slides — if you set expectations correctly.</p>
            <h2>Expect page-as-slide output</h2>
            <p>Complex PDFs often become one image per slide. That is ideal for presenting archived decks; edit text in the source file when possible.</p>
            <h2>Workflow</h2>
            <ol>
            <li><a href="/pdf/pdftoppt">PDF to PowerPoint</a></li>
            <li>Add speaker notes in PPTX</li>
            <li>Export final handout via <a href="/pdf/ppttopdf">PowerPoint to PDF</a></li>
            </ol>
            <p>Guide: <a href="/guides/pdf-to-powerpoint">PDF to PowerPoint guide</a></p>
            """;

        private const string HtmlDev = """
            <p>Developers use HTML-to-PDF for invoices, tickets, and report exports. RatPDF's <a href="/pdf/htmltopdf">HTML to PDF</a> tool complements server-side libraries when you need a quick render without deploying code.</p>
            <h2>Tips for clean output</h2>
            <ul>
            <li>Use <code>@page</code> CSS for margins and page breaks</li>
            <li>Prefer web-safe or embedded fonts</li>
            <li>Test with the same HTML you send to production — not live SPA URLs</li>
            </ul>
            <p>Guide: <a href="/guides/html-to-pdf">HTML to PDF guide</a></p>
            """;

        private const string RedactionVsPassword = """
            <p>Teams confuse redaction with password protection. They solve different problems.</p>
            <table class="table table-bordered">
            <thead><tr><th>Control</th><th>What it does</th><th>When to use</th></tr></thead>
            <tbody>
            <tr><td>Password</td><td>Encrypts file; authorized users see everything</td><td>Confidential but complete documents</td></tr>
            <tr><td>Watermark</td><td>Visual status label; no encryption</td><td>DRAFT / CONFIDENTIAL review</td></tr>
            <tr><td>Redaction</td><td>Permanently removes content</td><td>Disclosure with secrets stripped</td></tr>
            </tbody>
            </table>
            <p><a href="/guides/pdf-redaction">Redaction guide</a> · <a href="/guides/watermark-vs-password-pdf">Watermark vs password</a></p>
            """;

        private const string AccountantWorkflow = """
            <p>Month-end close generates PDF from every direction — bank feeds, client invoices, auditor requests. A repeatable PDF stack reduces rework.</p>
            <h2>Close-week checklist</h2>
            <ol>
            <li>Pull statement PDFs → <a href="/pdf/pdftoexcel">PDF to Excel</a></li>
            <li>Export management reports → <a href="/pdf/exceltopdf">Excel to PDF</a></li>
            <li>Merge board appendix → <a href="/pdf/merge">Merge PDF</a></li>
            <li>Compress for email → <a href="/guides/compress-pdf-email-limits">email limits guide</a></li>
            </ol>
            <p>Role hub: <a href="/guides/pdf-tools-for-accountants">PDF tools for accountants</a></p>
            """;

        private const string ThreeWayCompare = """
            <p>iLovePDF, Smallpdf, and RatPDF dominate "free PDF online" searches. Here is an honest three-way comparison for daily business use.</p>
            <div class="table-responsive"><table class="table table-bordered">
            <thead><tr><th></th><th>iLovePDF</th><th>Smallpdf</th><th>RatPDF</th></tr></thead>
            <tbody>
            <tr><td>Free daily use</td><td>Limited per tool</td><td>2 tasks/day total</td><td>3 uses/tool/day</td></tr>
            <tr><td>Max upload (free)</td><td>~200 MB</td><td>~5 GB (task limited)</td><td>200 MB</td></tr>
            <tr><td>Pro upload</td><td>Varies</td><td>5 GB</td><td>4 GB</td></tr>
            <tr><td>Invoice PDFs</td><td>No</td><td>No</td><td>Yes — GST/VAT</td></tr>
            <tr><td>Compare pages</td><td>Self-promo</td><td>Self-promo</td><td><a href="/compare">Full hub</a></td></tr>
            </tbody></table></div>
            <p>Deep dives: <a href="/compare/ilovepdf-alternative">iLovePDF</a> · <a href="/compare/smallpdf-alternative">Smallpdf</a> · <a href="/guides/pdf-tool-alternatives">All alternatives</a></p>
            """;

        private const string BrowserBgPrivacy = """
            <p>Most online background removers upload your photo to a cloud GPU. RatPDF's <a href="/tools/imgbackgroundremove">AI background remover</a> is different: segmentation runs in your browser with ONNX Runtime Web — your image bytes never leave your device.</p>
            <h2>Why on-device matters</h2>
            <ul>
            <li><strong>Privacy</strong> — headshots, ID scans, and unreleased product shots stay local</li>
            <li><strong>Resolution</strong> — output PNG matches original width and height</li>
            <li><strong>No queue</strong> — no server-side batch limits during peak hours</li>
            </ul>
            <h2>Trade-offs</h2>
            <p>First load downloads the model (~few MB). Processing speed depends on your CPU/GPU. Fine hair and glass edges remain challenging for any AI cutout.</p>
            <p>Guide: <a href="/guides/background-remover">Background remover guide</a> · Compress PNGs: <a href="/guides/image-compressor-guide">image compressor</a></p>
            """;

        private const string JsonApiDebug = """
            <p>Minified JSON from webhooks and REST APIs is unreadable in log viewers. A <a href="/pdf/jsonformatter">JSON formatter</a> turns one-line payloads into indented trees so you spot missing commas before production.</p>
            <h2>Debug workflow</h2>
            <ol>
            <li>Copy the raw response body from DevTools Network tab</li>
            <li>Paste into the JSON formatter and fix syntax errors</li>
            <li>Diff against last-known-good with <a href="/guides/text-comparer-guide">text comparer</a></li>
            <li>Update your integration tests with the corrected structure</li>
            </ol>
            <p>Guide: <a href="/guides/json-formatter-guide">JSON formatter guide</a> · Hub: <a href="/tools/developer">developer tools</a></p>
            """;

        private const string JwtOAuth = """
            <p>OAuth and OpenID Connect return JWT access and ID tokens. During integration you need to read claims — not trust them blindly.</p>
            <h2>Claims checklist</h2>
            <ul>
            <li><code>exp</code> — token not expired?</li>
            <li><code>iss</code> — matches your identity provider?</li>
            <li><code>aud</code> — intended for your client ID?</li>
            <li><code>scope</code> — includes required permissions?</li>
            </ul>
            <p>Use the <a href="/pdf/jwtdecoder">JWT decoder</a> to inspect payload JSON, then validate signatures server-side with the issuer's JWKS. Never paste production refresh tokens into shared machines.</p>
            <p>Guide: <a href="/guides/jwt-decoder-guide">JWT decoder guide</a></p>
            """;

        private const string MedicalDoc = """
            <p>Clinical calculators help shared decision-making when documented appropriately. RatPDF's <a href="/tools/medical">medical tools hub</a> covers BMI, eGFR, HEART, CHA₂DS₂-VASc, and Wells — all browser-based with no patient data stored.</p>
            <h2>Documentation tips</h2>
            <ul>
            <li>Record the score, date, and inputs used (e.g. creatinine value for eGFR)</li>
            <li>Note that calculators are adjuncts — not standalone diagnoses</li>
            <li>Link institutional protocols for anticoagulation or imaging pathways</li>
            </ul>
            <p>Guides: <a href="/guides/bmi-calculator-guide">BMI</a> · <a href="/guides/egfr-calculator-guide">eGFR</a> · <a href="/guides/heart-score-guide">HEART score</a></p>
            <p><em>Educational use only — not medical advice.</em></p>
            """;
    }
}
