namespace ratpdf.Content
{
    internal static class GuideBodiesMedicalImageDev
    {
        public static string? Get(string slug) => slug switch
        {
            "bmi-calculator-guide" => BmiCalculator,
            "egfr-calculator-guide" => EgfrCalculator,
            "heart-score-guide" => HeartScore,
            "cha2ds2-vasc-guide" => Cha2ds2Vasc,
            "wells-score-guide" => WellsScore,
            "medical-calculators-guide" => MedicalCalculatorsHub,
            "image-compressor-guide" => ImageCompressor,
            "image-resizer-guide" => ImageResizer,
            "image-format-converter-guide" => ImageFormatConverter,
            "bulk-image-compressor-guide" => BulkImageCompressor,
            "json-formatter-guide" => JsonFormatter,
            "jwt-decoder-guide" => JwtDecoder,
            "html-formatter-guide" => HtmlFormatter,
            "text-comparer-guide" => TextComparer,
            "url-encoder-guide" => UrlEncoder,
            "binary-converter-guide" => BinaryConverter,
            "dns-lookup-guide" => DnsLookup,
            "img-to-base64-guide" => ImgToBase64,
            "developer-tools-guide" => DeveloperToolsHub,
            _ => null
        };

        private const string MedicalDisclaimer =
            "<p class=\"text-muted\"><strong>Disclaimer:</strong> These calculators are educational aids only. They do not diagnose, treat, or replace licensed medical advice. Always follow local clinical protocols.</p>";

        private const string BmiCalculator = """
            <h2>What BMI measures</h2>
            <p>Body Mass Index (BMI) relates weight to height and is widely used for population-level obesity screening. It does not distinguish muscle from fat — athletes may read "overweight" despite low body fat.</p>
            <h2>How to use the calculator</h2>
            <ol>
            <li>Open the <a href="/bmi-calculator">BMI calculator</a>.</li>
            <li>Enter height (cm or ft/in) and weight (kg or lb).</li>
            <li>Read your BMI and WHO category (underweight, normal, overweight, obese).</li>
            </ol>
            <h2>When BMI is useful</h2>
            <ul>
            <li>Primary care intake and wellness screenings</li>
            <li>Patient education handouts</li>
            <li>Tracking trend over time (same scale, same time of day)</li>
            </ul>
            <p>More clinical scores: <a href="/tools/medical">medical calculators hub</a> · Long-tail: <a href="/medical-tools/bmi-calculator-for-women">BMI for women</a></p>
            """ + MedicalDisclaimer;

        private const string EgfrCalculator = """
            <h2>What eGFR estimates</h2>
            <p>Estimated glomerular filtration rate (eGFR) approximates kidney function from serum creatinine, age, sex, and (in some equations) race coefficient. It helps stage chronic kidney disease (CKD) and adjust drug dosing.</p>
            <h2>Using the eGFR calculator</h2>
            <ol>
            <li>Enter creatinine (mg/dL or µmol/L), age, and sex.</li>
            <li>Review eGFR mL/min/1.73m² and CKD stage band.</li>
            <li>Correlate with urinalysis, imaging, and trend — single values are not definitive.</li>
            </ol>
            <p><a href="/egfr-calculator">eGFR calculator →</a> · <a href="/medical-tools/egfr-calculator-ckd-staging">CKD staging guide</a></p>
            """ + MedicalDisclaimer;

        private const string HeartScore = """
            <h2>HEART score for chest pain</h2>
            <p>The HEART score stratifies major adverse cardiac events (MACE) in emergency department patients with chest pain. It supports shared decisions about observation vs early discharge — not a substitute for troponin protocols.</p>
            <h2>Components</h2>
            <ul>
            <li><strong>History</strong> — highly / moderately / slightly suspicious</li>
            <li><strong>ECG</strong> — significant ST deviation, non-specific, normal</li>
            <li><strong>Age</strong> — risk increases with age bands</li>
            <li><strong>Risk factors</strong> — hypertension, diabetes, smoking, etc.</li>
            <li><strong>Troponin</strong> — elevated vs normal at presentation</li>
            </ul>
            <p><a href="/heart-score">HEART score calculator →</a></p>
            """ + MedicalDisclaimer;

        private const string Cha2ds2Vasc = """
            <h2>CHA₂DS₂-VASc stroke risk</h2>
            <p>Used in atrial fibrillation to estimate annual stroke risk and inform anticoagulation discussions. Higher scores generally favour anticoagulation unless bleeding risk (HAS-BLED) is prohibitive.</p>
            <p>Pair with our <a href="/has-bled-score">HAS-BLED calculator</a> for bleeding risk. Browse all scores on the <a href="/tools/medical">medical tools hub</a>.</p>
            <p><a href="/cha2ds2-vasc-score">CHA₂DS₂-VASc calculator →</a></p>
            """ + MedicalDisclaimer;

        private const string WellsScore = """
            <h2>Wells criteria for DVT and PE</h2>
            <p>Wells score estimates pre-test probability of deep vein thrombosis or pulmonary embolism. Low-risk patients may proceed to D-dimer; high-risk patients need imaging per local pathway.</p>
            <h2>Clinical pearls</h2>
            <ul>
            <li>Do not use in isolation — combine with gestalt and institutional algorithms</li>
            <li>Repeat assessment if symptoms evolve</li>
            <li>Document score in notes for medico-legal clarity</li>
            </ul>
            <p><a href="/wells-score">Wells score calculator →</a></p>
            """ + MedicalDisclaimer;

        private const string MedicalCalculatorsHub = """
            <h2>Free clinical calculators in the browser</h2>
            <p>RatPDF offers evidence-based medical calculators for education and clinical documentation support: BMI, eGFR, HEART, CHA₂DS₂-VASc, Wells, GCS, MAP, HAS-BLED, Parkland formula, and NIHSS.</p>
            <h2>Popular tools</h2>
            <ul>
            <li><a href="/bmi-calculator">BMI calculator</a></li>
            <li><a href="/egfr-calculator">eGFR calculator</a></li>
            <li><a href="/heart-score">HEART score</a></li>
            <li><a href="/cha2ds2-vasc-score">CHA₂DS₂-VASc</a></li>
            <li><a href="/wells-score">Wells score (DVT/PE)</a></li>
            </ul>
            <h2>Long-tail guides</h2>
            <p>See programmatic guides like <a href="/medical-tools/bmi-calculator-for-women">BMI calculator for women</a> and <a href="/medical-tools/egfr-calculator-for-elderly">eGFR for elderly patients</a>. Editorial hub: <a href="/guides/medical-tools">medical calculator guides</a>.</p>
            """ + MedicalDisclaimer;

        private const string ImageCompressor = """
            <h2>Compress images for web and email</h2>
            <p>Large JPG and PNG files slow websites and bounce email attachments. RatPDF's <a href="/pdf/imagecompressor">image compressor</a> reduces file size while keeping acceptable visual quality for listings, blogs, and chat apps.</p>
            <h2>When to compress</h2>
            <ul>
            <li>Product photos before uploading to Shopify or marketplaces</li>
            <li>Screenshot attachments under email limits</li>
            <li>Hero images before adding to a PDF via <a href="/guides/images-to-pdf">Image to PDF</a></li>
            </ul>
            <p>Need transparent backgrounds? Use our <a href="/guides/background-remover">browser-based background remover</a> first, then compress the PNG.</p>
            """;

        private const string ImageResizer = """
            <h2>Resize images without desktop software</h2>
            <p>The <a href="/image-resizer">image resizer</a> scales JPG, PNG, and WEBP to exact pixel dimensions or percentage — useful for social crops, thumbnail grids, and CMS upload limits.</p>
            <h2>Best practices</h2>
            <ul>
            <li>Downscale for web; upscaling cannot add real detail</li>
            <li>Keep aspect ratio locked to avoid stretched logos</li>
            <li>Export PNG when you need transparency after <a href="/guides/background-remover">background removal</a></li>
            </ul>
            """;

        private const string ImageFormatConverter = """
            <h2>Convert JPG, PNG, WEBP, and more</h2>
            <p>Different platforms require different formats — favicons want PNG, some CMS tools prefer WEBP, legacy systems still expect JPG. The <a href="/image-format-converter">format converter</a> handles common conversions in the browser.</p>
            <h2>Typical workflows</h2>
            <ul>
            <li>PNG → JPG for smaller email attachments (loses transparency)</li>
            <li>JPG → PNG after cutting out a subject with the background remover</li>
            <li>WEBP → PNG for tools that do not accept WEBP yet</li>
            </ul>
            <p>Explore all image tools on <a href="/tools">all tools</a> or compress in bulk with the <a href="/guides/bulk-image-compressor-guide">bulk image compressor guide</a>.</p>
            """;

        private const string BulkImageCompressor = """
            <h2>Compress many images at once</h2>
            <p>E-commerce migrations, photo shoots, and documentation projects often mean dozens of files. The <a href="/bulk-image-compressor">bulk image compressor</a> processes multiple images in one session.</p>
            <h2>Tips</h2>
            <ul>
            <li>Sort by folder before upload for easier QA</li>
            <li>Spot-check one hero image before batch-downloading all</li>
            <li>Combine outputs into a catalogue PDF with <a href="/pdf/convertimages">Images to PDF</a></li>
            </ul>
            """;

        private const string JsonFormatter = """
            <h2>Format and validate JSON online</h2>
            <p>API responses, config files, and webhook payloads are unreadable as one line. The <a href="/pdf/jsonformatter">JSON formatter</a> pretty-prints, validates syntax, and helps you spot missing commas before production deploys.</p>
            <h2>Common use cases</h2>
            <ul>
            <li>Debug REST API responses in the browser</li>
            <li>Validate <code>appsettings.json</code> fragments before merge</li>
            <li>Compare minified vs formatted output with <a href="/guides/text-comparer-guide">text comparer</a></li>
            </ul>
            <h2>Long-tail pages</h2>
            <p>See also <a href="/json-formatter/json-formatter-online">JSON formatter online</a> and the <a href="/tools/developer">developer tools hub</a>.</p>
            """;

        private const string JwtDecoder = """
            <h2>Decode JWT tokens safely</h2>
            <p>JSON Web Tokens carry claims in a signed header.payload.signature structure. The <a href="/pdf/jwtdecoder">JWT decoder</a> parses header and payload JSON so you can inspect <code>exp</code>, <code>iss</code>, and <code>aud</code> during OAuth and API integration work.</p>
            <h2>Security note</h2>
            <p>Decoding is not verification — anyone can read Base64URL payload bytes. Never paste production secrets into shared machines. Signature validation must happen in your backend with the issuer's public key.</p>
            <p>Related: <a href="/jwt-decode/jwt-decode-online">JWT decode online</a> · <a href="/guides/json-formatter-guide">JSON formatter guide</a></p>
            """;

        private const string HtmlFormatter = """
            <h2>Beautify HTML markup</h2>
            <p>Minified templates, copied CMS fragments, and email HTML are hard to review. The <a href="/pdf/htmlformatter">HTML formatter</a> indents tags and attributes for readable diffs before you commit or hand off to a designer.</p>
            <h2>Works well with</h2>
            <ul>
            <li>Static email templates before <a href="/guides/html-to-pdf">HTML to PDF</a> export</li>
            <li>Legacy landing pages migrated to a new CMS</li>
            <li>Pairing with <a href="/guides/text-comparer-guide">text comparer</a> for regression checks</li>
            </ul>
            """;

        private const string TextComparer = """
            <h2>Compare two text blocks side by side</h2>
            <p>Config drift, contract redlines, and log snippets are easier to review with a visual diff. The <a href="/text-comparer">text comparer</a> highlights additions and removals line by line.</p>
            <h2>When to use</h2>
            <ul>
            <li>Before/after JSON pretty-print from the <a href="/guides/json-formatter-guide">JSON formatter</a></li>
            <li>Policy PDF text pasted from <a href="/pdf/pdftotext">PDF to Text</a> vs revised draft</li>
            <li>Env file changes during deployment checklists</li>
            </ul>
            """;

        private const string UrlEncoder = """
            <h2>URL encode and decode query strings</h2>
            <p>Spaces, ampersands, and Unicode in query parameters must be percent-encoded. The <a href="/url-encoder">URL encoder</a> and <a href="/url-decoder">URL decoder</a> handle <code>%20</code>, <code>+</code>, and UTF-8 safely when building OAuth redirects or analytics tags.</p>
            <h2>Example</h2>
            <p><code>hello world</code> → <code>hello%20world</code>. Always encode user-supplied values before concatenating URLs.</p>
            """;

        private const string BinaryConverter = """
            <h2>Binary ↔ decimal conversion</h2>
            <p>Networking homework, bitmask debugging, and embedded docs often need quick base conversions. Use <a href="/binary-to-decimal">binary to decimal</a> and <a href="/decimal-to-binary">decimal to binary</a> without opening a desktop calculator.</p>
            <h2>Tips</h2>
            <ul>
            <li>Verify 8-bit boundaries for IPv4 subnet masks</li>
            <li>Double-check leading zeros in hardware register docs</li>
            </ul>
            """;

        private const string DnsLookup = """
            <h2>DNS lookup for A, AAAA, MX, and TXT</h2>
            <p>Email deliverability, subdomain cutovers, and CDN migrations start with DNS. The <a href="/tools/dnslookup">DNS lookup tool</a> queries public resolvers for common record types.</p>
            <h2>Typical checks</h2>
            <ul>
            <li>MX records before migrating Google Workspace</li>
            <li>TXT for SPF, DKIM, and domain verification tokens</li>
            <li>Compare with <a href="/guides/my-ip-guide">public IP</a> when whitelisting office egress</li>
            </ul>
            """;

        private const string ImgToBase64 = """
            <h2>Image to Base64 for data URLs and APIs</h2>
            <p>Embed small icons in HTML email, JSON payloads, or CSS without hosting a separate file. The <a href="/pdf/imgtobase64">image to Base64</a> tool converts JPG/PNG to a <code>data:image/...</code> string.</p>
            <h2>Caution</h2>
            <ul>
            <li>Base64 inflates size ~33% — use only for small assets</li>
            <li>Large images belong on CDN URLs, not inline data URIs</li>
            </ul>
            """;

        private const string DeveloperToolsHub = """
            <h2>Developer utilities in one place</h2>
            <p>RatPDF's developer hub covers JSON formatting, JWT decoding, HTML beautification, text diff, URL encoding, binary conversion, DNS lookup, and Base64 image encoding — plus thousands of long-tail SEO pages for specific debugging scenarios.</p>
            <h2>Core tools</h2>
            <ul>
            <li><a href="/pdf/jsonformatter">JSON formatter</a></li>
            <li><a href="/pdf/jwtdecoder">JWT decoder</a></li>
            <li><a href="/pdf/htmlformatter">HTML formatter</a></li>
            <li><a href="/text-comparer">Text comparer</a></li>
            <li><a href="/url-encoder">URL encoder</a> / <a href="/url-decoder">decoder</a></li>
            <li><a href="/tools/dnslookup">DNS lookup</a></li>
            </ul>
            <p>PDF pipeline tools: <a href="/guides/html-to-pdf">HTML to PDF</a> · Blog: <a href="/blog/json-formatter-api-debugging">JSON formatter for API debugging</a> · Guides hub: <a href="/guides/developer-tools">developer tool guides</a></p>
            """;
    }
}
