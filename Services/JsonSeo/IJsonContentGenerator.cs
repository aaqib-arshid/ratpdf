using DocumentFormat.OpenXml.Wordprocessing;
using iText.Commons.Json;
using Microsoft.Extensions.Caching.Memory;
using PuppeteerSharp;
using ratpdf.Models;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;

namespace ratpdf.Services.JsonSeo
{
    public interface IJsonContentGenerator
    {
        Task<JsonPageContent> GenerateAsync(string slug);
    }
    public class JsonContentGenerator : IJsonContentGenerator
    {
        private readonly IJsonAllowedSlugsService _allowedSlugs;
        private readonly IMemoryCache _cache;
        private const string ToolUrl = "https://ratpdf.com/PDF/JsonFormatter";

        public JsonContentGenerator(IJsonAllowedSlugsService allowedSlugs, IMemoryCache cache)
        {
            _allowedSlugs = allowedSlugs;
            _cache = cache;
        }

        public async Task<JsonPageContent> GenerateAsync(string slug)
        {
            var cacheKey = $"JsonPageContent_{slug}";
            if (_cache.TryGetValue(cacheKey, out JsonPageContent? cached) && cached != null)
                return cached;

            var category = GetCategory(slug);
            var friendlyName = SlugToFriendlyName(slug);

            var content = new JsonPageContent
            {
                Slug = slug,
                UpdatedAt = DateTime.UtcNow,
                RelatedSlugs = GetRelatedSlugs(slug),
                Sections = new List<ContentSection>(),
                Faqs = new List<FaqItem>()
            };

            switch (category)
            {
                case "formatter": BuildFormatterContent(content, friendlyName); break;
                case "validator": BuildValidatorContent(content, friendlyName); break;
                case "minifier": BuildMinifierContent(content, friendlyName); break;
                case "beautifier": BuildBeautifierContent(content, friendlyName); break;
                case "jsonpath": BuildJsonPathContent(content, friendlyName); break;
                case "jsonschema": BuildJsonSchemaContent(content, friendlyName); break;
                case "csharp": BuildCSharpContent(content, friendlyName); break;
                case "javascript": BuildJavaScriptContent(content, friendlyName); break;
                case "python": BuildPythonContent(content, friendlyName); break;
                case "java": BuildJavaContent(content, friendlyName); break;
                case "php": BuildPhpContent(content, friendlyName); break;
                case "linter": BuildLinterContent(content, friendlyName); break;
                case "diff": BuildDiffContent(content, friendlyName); break;
                case "convert": BuildConvertContent(content, friendlyName); break;
                case "open": BuildOpenContent(content, friendlyName, slug); break;
                default: BuildIntelligentGenericContent(content, slug, friendlyName); break;
            }

            _cache.Set(cacheKey, content, TimeSpan.FromHours(24));
            return content;
        }

        // =========================
        // CATEGORY DETECTION (ENHANCED)
        // =========================
        private string GetCategory(string slug)
        {
            var s = slug.ToLower();
            if (s.Contains("format") || s.Contains("pretty") || s.Contains("prettify")) return "formatter";
            if (s.Contains("valid") || s.Contains("lint")) return "validator";
            if (s.Contains("minify") || s.Contains("compress")) return "minifier";
            if (s.Contains("beautify")) return "beautifier";
            if (s.Contains("jsonpath")) return "jsonpath";
            if (s.Contains("schema")) return "jsonschema";
            if (s.Contains("csharp") || s.Contains("c#")) return "csharp";
            if (s.Contains("javascript") || s.Contains("js")) return "javascript";
            if (s.Contains("python") || s.Contains("py")) return "python";
            if (s.Contains("java")) return "java";
            if (s.Contains("php")) return "php";
            if (s.Contains("diff") || s.Contains("compare")) return "diff";
            if (s.Contains("convert") || s.Contains("to") || s.Contains("csv") || s.Contains("xml") || s.Contains("yaml")) return "convert";
            if (s.Contains("open") || s.Contains("ouvrir") || s.Contains("view") || s.Contains("read") || s.Contains("afficher") || s.Contains("lire")) return "open";
            return "generic";
        }

        private string SlugToFriendlyName(string slug)
        {
            var name = Regex.Replace(slug, "-", " ")
                .Replace("json", "JSON")
                .Replace("csharp", "C#")
                .Replace("c#", "C#")
                .Trim();
            var words = name.Split(' ');
            for (int i = 0; i < words.Length; i++)
                if (words[i].Length > 0)
                    words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1).ToLower();
            return string.Join(" ", words);
        }

        private List<string> GetRelatedSlugs(string currentSlug)
        {
            var all = _allowedSlugs.GetAllSlugs();
            return all.Where(s => s != currentSlug)
                      .OrderBy(_ => Random.Shared.Next())
                      .Take(5)
                      .ToList();
        }

        private string GetToolCta(string friendlyName)
        {
            return $@"
<div class='tool-cta' style='background:#e8f4f8; padding:15px; border-radius:8px; margin:20px 0; text-align:center;'>
    <a href='{ToolUrl}' target='_blank' rel='noopener' style='display:inline-block; background:#17a2b8; color:white; padding:10px 20px; text-decoration:none; border-radius:5px;'>
        🧹 Open JSON Formatter Tool
    </a>
    <p style='margin-top:10px;'>Use <strong>{friendlyName}</strong> instantly – format, validate, minify, or convert your JSON data.</p>
</div>";
        }

        // =========================
        // 1. FORMATTER (Beautify / Pretty-print)
        // =========================
        private void BuildFormatterContent(JsonPageContent content, string friendlyName)
        {
            var sb = new StringBuilder();

            // Meta
            content.MetaTitle = $"{friendlyName} – The Ultimate JSON Formatter & Beautifier Guide";
            content.MetaDescription = $"Master JSON formatting with {friendlyName}. Learn to pretty-print, indent, sort keys, and optimize JSON for readability. Includes code examples in 5+ languages.";
            content.HeadingH1 = $"{friendlyName} – Complete Guide to Clean, Readable JSON";

            // Introduction + CTA
            sb.Append(GetToolCta(friendlyName));
            sb.Append(@"
<p>JSON (JavaScript Object Notation) has become the universal standard for data exchange. But raw, minified JSON is impossible to read. <strong>JSON formatting</strong> (also called beautifying or pretty-printing) transforms compact JSON into a human-friendly structure with proper indentation, line breaks, and spacing.</p>
<p>In this comprehensive guide, you'll learn:</p>
<ul>
    <li>Why JSON formatting matters for developers and teams</li>
    <li>How to format JSON using online tools, editors, and command line</li>
    <li>Code examples in C#, Python, JavaScript, Java, and PHP</li>
    <li>Best practices for consistent JSON styling</li>
    <li>How to automate formatting in CI/CD pipelines</li>
</ul>
<p>Let's dive in.</p>");

            // Section 1: Why Format JSON?
            sb.Append(@"
<section>
    <h2>Why Format JSON? The Benefits of Pretty‑Printed JSON</h2>
    <p>When you receive a JSON response from an API or open a configuration file, it often looks like a single, long line of text. That's <strong>minified JSON</strong> – optimized for machines but terrible for humans. Formatting adds:</p>
    <ul>
        <li><strong>Readability</strong> – Indented structures are easy to scan and understand.</li>
        <li><strong>Debugging speed</strong> – Spot missing brackets or extra commas instantly.</li>
        <li><strong>Collaboration</strong> – Team members can review JSON changes without parsing mentally.</li>
        <li><strong>Documentation</strong> – Pretty‑printed JSON serves as self‑documenting data.</li>
        <li><strong>Version control</strong> – Formatted JSON produces meaningful diffs (instead of whole‑file changes).</li>
    </ul>
    <p>A typical example:</p>
    <pre><code>// Minified (hard to read)
{""name"":""John"",""age"":30,""cars"":[{""name"":""Ford"",""models"":[""Fiesta"",""Focus"",""Mustang""]}]}

// Formatted (easy to read)
{
  ""name"": ""John"",
  ""age"": 30,
  ""cars"": [
    {
      ""name"": ""Ford"",
      ""models"": [ ""Fiesta"", ""Focus"", ""Mustang"" ]
    }
  ]
}</code></pre>
    <p>The difference is night and day. With our tool, you can achieve this in one click.</p>
</section>");

            // Section 2: How to Format JSON – 5 Methods
            sb.Append(@"
<section>
    <h2>5 Ways to Format JSON (Online, IDE, CLI)</h2>
    <h3>1. Online JSON Formatter (Recommended)</h3>
    <p>Our <a href='https://ratpdf.com/PDF/JsonFormatter'>online JSON formatter</a> works entirely in your browser – no installation, no data upload. Paste your JSON, choose indentation (2 spaces, 4 spaces, or tabs), and click Format. It also validates syntax and shows errors.</p>
    
    <h3>2. Visual Studio Code (with Prettier)</h3>
    <p>VS Code has built‑in JSON formatting. Press <code>Shift+Alt+F</code> (Windows) or <code>Shift+Option+F</code> (Mac). Install the <strong>Prettier</strong> extension for more control.</p>
    <pre><code>// settings.json
{
  ""editor.defaultFormatter"": ""esbenp.prettier-vscode"",
  ""editor.formatOnSave"": true,
  ""prettier.printWidth"": 100
}</code></pre>

    <h3>3. Command Line with `jq`</h3>
    <p><code>jq</code> is a lightweight JSON processor. Install it then run:</p>
    <pre><code>cat messy.json | jq '.' > pretty.json</code></pre>

    <h3>4. Python one‑liner</h3>
    <pre><code>python -m json.tool input.json output.json</code></pre>

    <h3>5. Node.js script</h3>
    <pre><code>const fs = require('fs');
const data = JSON.parse(fs.readFileSync('input.json'));
fs.writeFileSync('output.json', JSON.stringify(data, null, 2));</code></pre>
</section>");

            // Section 3: Code Examples in Multiple Languages (detailed)
            sb.Append("""
                <section>
                    <h2>Format JSON Programmatically – Code Examples</h2>

                    <p>Here's how to pretty-print JSON in the most popular programming languages.</p>

                    <h3>C# (System.Text.Json)</h3>

                    <pre><code>using System.Text.Json;

                string minified = "{\"name\":\"John\"}";

                using JsonDocument doc = JsonDocument.Parse(minified);

                string pretty = JsonSerializer.Serialize(
                    doc.RootElement,
                    new JsonSerializerOptions
                    {
                        WriteIndented = true
                    });

                Console.WriteLine(pretty);</code></pre>

                    <h3>Python</h3>

                    <pre><code>import json

                data = json.loads('{"name":"John"}')

                pretty = json.dumps(data, indent=4)

                print(pretty)</code></pre>

                    <h3>JavaScript (Node.js or browser)</h3>

                    <pre><code>const data = JSON.parse('{"name":"John"}');

                const pretty = JSON.stringify(data, null, 2);

                console.log(pretty);</code></pre>

                    <h3>Java (Jackson)</h3>

                    <pre><code>ObjectMapper mapper = new ObjectMapper()
                    .enable(SerializationFeature.INDENT_OUTPUT);

                JsonNode tree = mapper.readTree(minifiedJson);

                String pretty = mapper.writeValueAsString(tree);</code></pre>

                    <h3>PHP</h3>

                    <pre><code>$data = json_decode($minified, true);

                $pretty = json_encode($data, JSON_PRETTY_PRINT);

                echo $pretty;</code></pre>

                    <h3>Go</h3>

                    <pre><code>var data interface{}

                json.Unmarshal([]byte(minified), &data)

                pretty, _ := json.MarshalIndent(data, "", "  ")

                fmt.Println(string(pretty))</code></pre>
                </section>
                """);

            // Section 4: Advanced Formatting Options
            sb.Append(@"
<section>
    <h2>Advanced JSON Formatting Options</h2>
    <p>Beyond basic indentation, you can also:</p>
    <ul>
        <li><strong>Sort keys alphabetically</strong> – Useful for consistent diffs and canonical JSON.</li>
        <li><strong>Remove trailing commas</strong> – Some parsers reject them, but they are not standard.</li>
        <li><strong>Escape/unescape Unicode</strong> – Convert \\uXXXX to actual characters.</li>
        <li><strong>Flatten nested objects</strong> – For CSV export or logging.</li>
        <li><strong>JSON to YAML conversion</strong> – Human‑readable alternative.</li>
    </ul>
    <p>Our online tool supports key sorting and custom indentation. For advanced transformations, combine with `jq`.</p>
</section>");

        // Section 5: Best Practices & Performance
        sb.Append(@"
<section>
    <h2>Best Practices for JSON Formatting</h2>
    <ul>
        <li><strong>Use consistent indentation across your team</strong> – Adopt 2 spaces (common in JS/Node) or 4 spaces (Python).</li>
        <li><strong>Format on save</strong> – Configure your IDE to auto‑format JSON files.</li>
        <li><strong>Never commit minified JSON to source control</strong> – Keep formatted versions for readability.</li>
        <li><strong>Minify only for production APIs</strong> – Reduce bandwidth, but keep a formatted copy for debugging.</li>
        <li><strong>Validate before formatting</strong> – Avoid errors; always ensure valid JSON first.</li>
    </ul>
    <p>For large files (>10 MB), use command‑line tools like `jq` – they are faster and memory‑efficient.</p>
</section>");

        // Section 6: Troubleshooting Common Formatting Issues
        sb.Append(@"
<section>
    <h2>Troubleshooting JSON Formatting Errors</h2>
    <p>If your JSON doesn't format correctly, check for:</p>
    <ul>
        <li><strong>Trailing commas</strong> – Not allowed in strict JSON (remove them).</li>
        <li><strong>Single quotes</strong> – JSON requires double quotes around keys and string values.</li>
        <li><strong>Missing quotes around keys</strong> – Every key must be quoted.</li>
        <li><strong>Comments</strong> – JSON doesn't support comments; strip them first.</li>
        <li><strong>Control characters</strong> – Unescaped line breaks or tabs inside strings break parsing.</li>
    </ul>
    <p>Use our <strong>JSON validator</strong> to pinpoint the exact line and character of the error.</p>
</section>");

        // FAQ (10 questions)
        var faqs = new List<FaqItem>
        {
            new() { Question = "What is the difference between JSON formatting and minification?", Answer = "Formatting adds whitespace for readability; minification removes it to save space. Both preserve data." },
            new() { Question = "Does formatting change the meaning of JSON?", Answer = "No – only whitespace is added. The logical structure and data remain identical." },
            new() { Question = "Can I format JSON directly in my browser without uploading?", Answer = "Yes – our tool processes everything client‑side. Your JSON never leaves your computer." },
            new() { Question = "What's the best indentation size for JSON?", Answer = "2 spaces is most common in JavaScript/Node ecosystems; 4 spaces in Python. Choose what your team agrees on." },
            new() { Question = "How do I format JSON in VS Code without extensions?", Answer = "Press Shift+Alt+F (Windows) or Shift+Option+F (Mac). It uses the built‑in formatter." },
            new() { Question = "Is there a command‑line tool to format JSON recursively?", Answer = "Yes – `find . -name '*.json' -exec jq '.' {} \\;` with jq." },
            new() { Question = "Does JSON formatting affect API performance?", Answer = "No – formatting happens on the client side. Servers usually send minified JSON." },
            new() { Question = "How to format JSON in Excel?", Answer = "Excel can import JSON via Power Query, but formatting inside cells is limited. Use our tool first." },
            new() { Question = "What is canonical JSON?", Answer = "A standardised formatting (no extra spaces, sorted keys) used for digital signatures." },
            new() { Question = "Can I format JSON that contains BOM (Byte Order Mark)?", Answer = "Yes – our tool automatically strips BOM characters." }
        };

        content.Sections = new List<ContentSection> { new () { Heading = "", Html = sb.ToString()
    }
};
content.CodeExampleHtml = ""; // Already embedded in sections
content.Faqs = faqs;
    }


        // =========================
        // 2. VALIDATOR / LINTER
        // =========================
        private void BuildValidatorContent(JsonPageContent content, string friendlyName)
        {
            var sb = new StringBuilder();
            content.MetaTitle = $"{friendlyName} – Complete JSON Validator & Linter Guide";
            content.MetaDescription = $"Master JSON validation with {friendlyName}. Learn to detect syntax errors, fix common mistakes, and enforce JSON standards. Includes code examples and best practices.";
            content.HeadingH1 = $"{friendlyName} – Ensure Error‑Free JSON";

            sb.Append(GetToolCta(friendlyName));
            sb.Append(@"
<p>JSON validation is the process of checking whether a given string conforms to the JSON syntax specification (RFC 7159). A single misplaced comma or missing quote can break your entire application. This guide teaches you how to validate JSON effectively, understand error messages, and fix common mistakes.</p>
<p>In this comprehensive guide:</p>
<ul>
    <li>What is JSON validation and why it matters</li>
    <li>Common JSON syntax errors with examples</li>
    <li>How to validate JSON online, in editors, and programmatically</li>
    <li>Code examples for validation in 6+ languages</li>
    <li>Integrating validation into CI/CD pipelines</li>
</ul>");

            // Section 1: Common JSON Errors
            sb.Append(@"
<section>
    <h2>The 7 Most Common JSON Syntax Errors (And How to Fix Them)</h2>
    <ul>
        <li><strong>1. Trailing commas</strong> – `{""a"":1,}` → Remove the comma after last element.</li>
        <li><strong>2. Missing quotes around keys</strong> – `{name:""John""}` → `{""name"":""John""}`.</li>
        <li><strong>3. Single quotes instead of double</strong> – `{'name':'John'}` → Use double quotes.</li>
        <li><strong>4. Unclosed brackets/braces</strong> – `{""a"":1` → Add missing `}`.</li>
        <li><strong>5. Invalid escape sequences</strong> – `""\x""` → Use valid escapes like `\n`, `\t`, `\\`.</li>
        <li><strong>6. Comments inside JSON</strong> – `// comment` → Remove comments (use separate metadata).</li>
        <li><strong>7. Control characters in strings</strong> – Unescaped newline → Replace with `\n`.</li>
    </ul>
    <p>Our validator catches all these and shows the exact line & column position.</p>
</section>");

            // Section 2: Validation Methods
            sb.Append("""
<section>
    <h2>5 Ways to Validate JSON</h2>

    <h3>1. Online JSON Validator (Fastest)</h3>

    <p>
        Use our tool: paste JSON and click "Validate".
        Instant feedback with exact error location.
    </p>

    <h3>2. VS Code</h3>

    <p>
        VS Code highlights syntax errors in real time.
        Install extensions like "Error Lens" or "Prettier"
        for better JSON formatting and debugging.
    </p>

    <h3>3. Command line with jq</h3>

    <pre><code>echo '{"invalid": }' | jq .</code></pre>

    <h3>4. Python</h3>

    <pre><code>import json

json.loads(your_json)</code></pre>

    <h3>5. JavaScript (Browser Console)</h3>

    <pre><code>JSON.parse(yourJsonString);</code></pre>
</section>
""");

            // Section 3: Code examples for validation
            sb.Append(@"
<section>
    <h2>Validate JSON Programmatically – Code Examples</h2>
    <h3>C#</h3>
    <pre><code>try { JsonDocument.Parse(json); Console.WriteLine(""Valid""); } catch (JsonException ex) { Console.WriteLine(ex.Message); }</code></pre>
    <h3>Python</h3>
    <pre><code>try: json.loads(json_string); print('Valid')
except json.JSONDecodeError as e: print(f'Error at line {e.lineno}: {e}')</code></pre>
    <h3>JavaScript</h3>
    <pre><code>try { JSON.parse(jsonString); console.log('Valid'); } catch(e) { console.error(e.message); }</code></pre>
    <h3>Java (Jackson)</h3>
    <pre><code>try { new ObjectMapper().readTree(json); System.out.println(""Valid""); } catch (JsonParseException e) { e.printStackTrace(); }</code></pre>
    <h3>PHP</h3>
    <pre><code>$data = json_decode($json); if (json_last_error() === JSON_ERROR_NONE) echo 'Valid'; else echo json_last_error_msg();</code></pre>
</section>");

            // Section 4: Advanced Validation – JSON Schema
            sb.Append(@"
<section>
    <h2>Beyond Syntax – Semantic Validation with JSON Schema</h2>
    <p>Syntax validation only checks if the JSON is well‑formed. <strong>JSON Schema</strong> validates the structure, data types, required fields, and value constraints. Example:</p>
    <pre><code>{
  ""type"": ""object"",
  ""properties"": {
    ""name"": { ""type"": ""string"" },
    ""age"": { ""type"": ""integer"", ""minimum"": 0 }
  },
  ""required"": [""name""]
}</code></pre>
    <p>Use libraries like `Ajv` (JavaScript), `jsonschema` (Python), or `NJsonSchema` (C#) to validate against a schema.</p>
</section>");

            // Section 5: Integrating validation in CI/CD
            sb.Append(@"
<section>
    <h2>Automate JSON Validation in CI/CD Pipelines</h2>
    <p>Prevent invalid JSON from reaching production:</p>
    <ul>
        <li><strong>GitHub Actions</strong> – Use `jq` to validate all JSON files in a PR.</li>
        <li><strong>GitLab CI</strong> – Add a job: `script: find . -name '*.json' -exec jq . {} \\;`.</li>
        <li><strong>Pre‑commit hooks</strong> – Run `check-json` hook.</li>
    </ul>
    <p>This saves hours of debugging broken configurations.</p>
</section>");

            // FAQ (10)
            var faqs = new List<FaqItem>
        {
            new() { Question = "What is the difference between JSON validation and linting?", Answer = "Validation checks syntax; linting also checks style (e.g., indentation, key ordering)." },
            new() { Question = "Can JSON contain comments?", Answer = "Standard JSON does not support comments. Use JSON5 or separate metadata files." },
            new() { Question = "Why does my valid JSON fail to parse?", Answer = "Possible BOM (Byte Order Mark) or encoding issues. Our tool removes BOM automatically." },
            new() { Question = "How to validate large JSON files (>100 MB)?", Answer = "Use streaming parsers (e.g., `ijson` in Python) or command‑line tools like `jq`." },
            new() { Question = "Is there a JSON validator for VS Code?", Answer = "Yes – built‑in + extensions like ''JSON Lint''." },
            new() { Question = "How do I validate JSON in a CI pipeline?", Answer = "Add `jq . file.json` to your CI script; it exits non‑zero on invalid JSON." },
            new() { Question = "What does ''Unexpected token < in JSON at position 0'' mean?", Answer = "You're parsing HTML or an error page instead of JSON. Check the endpoint." },
            new() { Question = "Does JSON validation guarantee security?", Answer = "No – but it prevents malformed data attacks. Sanitize separately." },
            new() { Question = "What is JSONL (JSON Lines)?", Answer = "Each line is a valid JSON object. Validation is per line." },
            new() { Question = "Can I validate JSON from Excel?", Answer = "Export as CSV then convert to JSON with our tool." }
        };

            content.Sections = new List<ContentSection> { new() { Heading = "", Html = sb.ToString() } };
            content.Faqs = faqs;
        }


        // =========================
        // 3. MINIFIER
        // =========================
        private void BuildMinifierContent(JsonPageContent content, string friendlyName)
        {
            content.MetaTitle = $"{friendlyName} – JSON Minifier & Compressor";
            content.MetaDescription = $"Minify JSON with {friendlyName}. Remove whitespace to reduce file size for production APIs.";
            content.HeadingH1 = $"{friendlyName} – Shrink JSON for Performance";

            content.IntroductionHtml = GetToolCta(friendlyName) + @"
<p>JSON minification removes all unnecessary whitespace and line breaks, producing a compact string. This reduces payload size, speeds up network transfer, and lowers bandwidth costs.</p>";

            content.Sections = new List<ContentSection>
        {
            new() {
                Heading = "When to minify JSON",
                Html = @"
<ul>
    <li>🚀 API responses (reduce latency)</li>
    <li>📦 Data storage (save disk space)</li>
    <li>🌐 CDN caching (smaller files = faster delivery)</li>
    <li>📱 Mobile apps (reduce data usage)</li>
</ul>"
            },
            new() {
                Heading = "Minification example",
                Html = @"
<pre><code>// Before (pretty, 150 bytes)
{
  ""name"": ""John"",
  ""age"": 30
}

// After minified (80 bytes)
{""name"":""John"",""age"":30}</code></pre>
<p>Size reduction: ~47%.</p>"
            }
        };

            content.CodeExampleHtml = @"
<h3>Minify JSON in JavaScript</h3>
<pre><code>function minifyJson(jsonString) {
    return JSON.stringify(JSON.parse(jsonString));
}</code></pre>

<h3>Minify in C#</h3>
<pre><code>string minified = JsonSerializer.Serialize(JsonDocument.Parse(prettyJson).RootElement);</code></pre>";

            content.Faqs = new List<FaqItem>
        {
            new() { Question = "Does minification affect the data?", Answer = "No – only whitespace is removed. The data remains exactly the same." },
            new() { Question = "Can I prettify minified JSON later?", Answer = "Yes – use our formatter to beautify it again." }
        };
        }

        // =========================
        // 4. BEAUTIFIER (alias)
        // =========================
        private void BuildBeautifierContent(JsonPageContent content, string friendlyName)
        {
            BuildFormatterContent(content, friendlyName);
            content.MetaTitle = content.MetaTitle.Replace("Formatter", "Beautifier");
            content.HeadingH1 = content.HeadingH1.Replace("Formatter", "Beautifier");
        }

        // =========================
        // 5. JSONPATH
        // =========================
        private void BuildJsonPathContent(JsonPageContent content, string friendlyName)
        {
            content.MetaTitle = $"{friendlyName} – JSONPath Query Language Tutorial";
            content.MetaDescription = $"Learn JSONPath syntax with {friendlyName}. Query and extract data from nested JSON structures.";
            content.HeadingH1 = $"{friendlyName} – Master JSONPath Expressions";

            content.IntroductionHtml = GetToolCta(friendlyName) + @"
<p><strong>JSONPath</strong> is a query language for JSON, similar to XPath for XML. It allows you to extract specific values from complex JSON objects using compact expressions.</p>";

            content.Sections = new List<ContentSection>
        {
            new() {
                Heading = "JSONPath Syntax Basics",
                Html = @"
<table border='1' cellpadding='8' style='border-collapse:collapse; width:100%'>
    <tr><th>Expression</th><th>Description</th></tr>
    <tr><td><code>$</code></td><td>Root object/element</td></tr>
    <tr><td><code>.property</code> or <code>['property']</code></td><td>Child operator</td></tr>
    <tr><td><code>[*]</code></td><td>Wildcard (all elements)</td></tr>
    <tr><td><code>..</code></td><td>Deep scan (recursive descent)</td></tr>
    <tr><td><code>@</code></td><td>Current node (in filters)</td></tr>
    <tr><td><code>?(@.condition)</code></td><td>Filter expression</td></tr>
</table>"
            },
            new() {
                Heading = "Practical examples",
                Html = @"
<pre><code>// Sample JSON
{
  ""store"": {
    ""book"": [
      { ""title"": ""Book A"", ""price"": 10 },
      { ""title"": ""Book B"", ""price"": 15 }
    ]
  }
}

$.store.book[*].title         // [""Book A"", ""Book B""]
$.store.book[?(@.price < 12)]  // First book only</code></pre>"
            }
        };

            content.CodeExampleHtml = @"
<h3>JSONPath in C# (using JsonPath.Net)</h3>
<pre><code>using JsonPath.Net;
using System.Text.Json;

JsonDocument doc = JsonDocument.Parse(json);
JsonPath path = new JsonPath(""$.store.book[*].title"");
List<PathResult> results = path.Evaluate(doc.RootElement);</code></pre>";

            content.Faqs = new List<FaqItem>();
        }

        // =========================
        // 6. JSON SCHEMA
        // =========================
        private void BuildJsonSchemaContent(JsonPageContent content, string friendlyName)
        {
            content.MetaTitle = $"{friendlyName} – JSON Schema Validator & Generator";
            content.MetaDescription = $"Validate JSON against a schema or generate a schema from sample data with {friendlyName}.";
            content.HeadingH1 = $"{friendlyName} – Ensure Data Quality with JSON Schema";

            content.IntroductionHtml = GetToolCta(friendlyName) + @"
<p><strong>JSON Schema</strong> is a vocabulary that allows you to annotate and validate JSON documents. It defines the expected structure, data types, and constraints.</p>";

            content.Sections = new List<ContentSection>
        {
            new() {
                Heading = "Common use cases",
                Html = @"
<ul>
    <li>API request/response validation</li>
    <li>Configuration file verification</li>
    <li>Data quality in ETL pipelines</li>
    <li>Automatic form generation</li>
</ul>"
            },
            new() {
                Heading = "Example JSON Schema",
                Html = @"
<pre><code>{
  ""$schema"": ""http://json-schema.org/draft-07/schema#"",
  ""type"": ""object"",
  ""properties"": {
    ""name"": { ""type"": ""string"" },
    ""age"": { ""type"": ""integer"", ""minimum"": 0 }
  },
  ""required"": [""name""]
}</code></pre>"
            },
            new() {
                Heading = "Generate schema from JSON",
                Html = @"
<p>Our tool can automatically generate a JSON Schema from your sample data – ideal for bootstrapping validation rules.</p>"
            }
        };

            content.CodeExampleHtml = @"
<h3>Validate against schema in C# (NJsonSchema)</h3>
<pre><code>using NJsonSchema;
using NJsonSchema.Validation;

var schema = await JsonSchema.FromJsonAsync(schemaJson);
var errors = schema.Validate(jsonData);
if (errors.Any()) Console.WriteLine($""Validation failed: {errors.Count} errors"");</code></pre>";

            content.Faqs = new List<FaqItem>();
        }

        // =========================
        // 7. C# BUILDER
        // =========================
        private void BuildCSharpContent(JsonPageContent content, string friendlyName)
        {
            content.MetaTitle = $"{friendlyName} – Format JSON in C# (System.Text.Json & Newtonsoft)";
            content.MetaDescription = $"Learn {friendlyName} using .NET. Beautify, minify, and validate JSON with code examples.";
            content.HeadingH1 = $"{friendlyName} – C# JSON Processing Guide";

            content.IntroductionHtml = GetToolCta(friendlyName) + @"
<p>C# offers two main libraries for JSON: <strong>System.Text.Json</strong> (built‑in) and <strong>Newtonsoft.Json</strong> (Json.NET). Both support formatting, validation, and manipulation.</p>";

            content.Sections = new List<ContentSection>
        {
            new() {
                Heading = "Using System.Text.Json (modern .NET)",
                Html = @"
<pre><code>using System.Text.Json;

// Pretty-print
var options = new JsonSerializerOptions { WriteIndented = true };
string prettyJson = JsonSerializer.Serialize(obj, options);

// Parse and re-serialize (minify)
using JsonDocument doc = JsonDocument.Parse(minifiedJson);
string pretty = JsonSerializer.Serialize(doc.RootElement, 
    new JsonSerializerOptions { WriteIndented = true });</code></pre>"
            },
            new() {
                Heading = "Using Newtonsoft.Json (Json.NET)",
                Html = @"
<pre><code>using Newtonsoft.Json;

// Pretty-print
string prettyJson = JsonConvert.SerializeObject(obj, Formatting.Indented);

// Minify
string minifiedJson = JsonConvert.SerializeObject(obj, Formatting.None);</code></pre>"
            },
            new() {
                Heading = "Read JSON from file",
                Html = @"
<pre><code>string jsonString = File.ReadAllText(""data.json"");
var document = JsonDocument.Parse(jsonString);
var root = document.RootElement;</code></pre>"
            }
        };

            content.Faqs = new List<FaqItem>();
        }

        // =========================
        // 8. JAVASCRIPT BUILDER
        // =========================
        private void BuildJavaScriptContent(JsonPageContent content, string friendlyName)
        {
            content.MetaTitle = $"{friendlyName} – Pretty Print JSON in JavaScript";
            content.MetaDescription = $"Format JSON in JS with {friendlyName}. Use JSON.stringify() with space parameter for readable output.";
            content.HeadingH1 = $"{friendlyName} – JavaScript JSON Formatting";

            content.IntroductionHtml = GetToolCta(friendlyName) + @"
<p>JavaScript provides a built‑in method <code>JSON.stringify()</code> that can produce pretty‑printed JSON with custom indentation.</p>";

            content.Sections = new List<ContentSection>
        {
            new() {
                Heading = "Pretty print example",
                Html = @"
<pre><code>const data = { name: ""John"", age: 30, city: ""New York"" };

// Pretty-print with 2 spaces
const prettyJson = JSON.stringify(data, null, 2);
console.log(prettyJson);
/* Output:
{
  ""name"": ""John"",
  ""age"": 30,
  ""city"": ""New York""
}
*/</code></pre>"
            },
            new() {
                Heading = "Minify (remove whitespace)",
                Html = @"
<pre><code>const minified = JSON.stringify(data);</code></pre>"
            },
            new() {
                Heading = "Read JSON from file (Node.js)",
                Html = @"
<pre><code>const fs = require('fs');
const data = JSON.parse(fs.readFileSync('data.json', 'utf8'));</code></pre>"
            }
        };

            content.Faqs = new List<FaqItem>();
        }

        // =========================
        // 9. PYTHON BUILDER
        // =========================
        private void BuildPythonContent(JsonPageContent content, string friendlyName)
        {
            content.MetaTitle = $"{friendlyName} – Pretty Print JSON in Python";
            content.MetaDescription = $"Format JSON with {friendlyName}. Use json.dumps(indent=4) for readable output in Python.";
            content.HeadingH1 = $"{friendlyName} – Python JSON Formatting";

            content.IntroductionHtml = GetToolCta(friendlyName) + @"
<p>Python's built‑in <code>json</code> module makes pretty‑printing effortless using the <code>indent</code> parameter.</p>";

            content.Sections = new List<ContentSection>
        {
            new() {
                Heading = "Pretty print from a Python object",
                Html = @"
<pre><code>import json

data = {""name"": ""John"", ""age"": 30, ""city"": ""New York""}
pretty_json = json.dumps(data, indent=4)
print(pretty_json)</code></pre>"
            },
            new() {
                Heading = "Pretty print from a JSON string",
                Html = """
<pre><code>import json

json_string = '{"name":"John","age":30}'

parsed = json.loads(json_string)

pretty = json.dumps(parsed, indent=2)

print(pretty)</code></pre>
"""
            },
            new() {
                Heading = "Read JSON from file",
                Html = @"
<pre><code>with open('data.json', 'r') as f:
    data = json.load(f)
print(data)</code></pre>"
            }
        };

            content.Faqs = new List<FaqItem>();
        }

        // =========================
        // 10. JAVA BUILDER
        // =========================
        private void BuildJavaContent(JsonPageContent content, string friendlyName)
        {
            content.MetaTitle = $"{friendlyName} – Format JSON in Java (Jackson & Gson)";
            content.MetaDescription = $"Learn {friendlyName} with Jackson and Gson libraries. Pretty‑print JSON in Java.";
            content.HeadingH1 = $"{friendlyName} – Java JSON Formatting";

            content.IntroductionHtml = GetToolCta(friendlyName) + @"
<p>Java developers use <strong>Jackson</strong> or <strong>Gson</strong> to handle JSON formatting and pretty‑printing.</p>";

            content.Sections = new List<ContentSection>
        {
            new() {
                Heading = "Jackson (pretty-print)",
                Html = @"
<pre><code>import com.fasterxml.jackson.databind.ObjectMapper;
import com.fasterxml.jackson.databind.SerializationFeature;

ObjectMapper mapper = new ObjectMapper().enable(SerializationFeature.INDENT_OUTPUT);
String prettyJson = mapper.writeValueAsString(myObject);</code></pre>"
            },
            new() {
                Heading = "Gson (pretty-print)",
                Html = @"
<pre><code>import com.google.gson.Gson;
import com.google.gson.GsonBuilder;

Gson gson = new GsonBuilder().setPrettyPrinting().create();
String prettyJson = gson.toJson(myObject);</code></pre>"
            },
            new() {
                Heading = "Read JSON from file (Jackson)",
                Html = @"
<pre><code>MyObject obj = mapper.readValue(new File(""data.json""), MyObject.class);</code></pre>"
            }
        };

            content.Faqs = new List<FaqItem>();
        }

        // =========================
        // 11. PHP BUILDER
        // =========================
        private void BuildPhpContent(JsonPageContent content, string friendlyName)
        {
            content.MetaTitle = $"{friendlyName} – Pretty Print JSON in PHP";
            content.MetaDescription = $"Format JSON with {friendlyName} using json_encode() and the JSON_PRETTY_PRINT flag.";
            content.HeadingH1 = $"{friendlyName} – PHP JSON Formatting";

            content.IntroductionHtml = GetToolCta(friendlyName) + @"
<p>PHP has built‑in support for pretty‑printing JSON via the <code>JSON_PRETTY_PRINT</code> flag.</p>";

            content.Sections = new List<ContentSection>
        {
            new() {
                Heading = "Pretty print example",
                Html = @"
<pre><code>&lt;?php
$data = [""name"" => ""John"", ""age"" => 30];
$prettyJson = json_encode($data, JSON_PRETTY_PRINT);
echo $prettyJson;
?&gt;</code></pre>"
            },
            new() {
                Heading = "Read JSON from file",
                Html = @"
<pre><code>$jsonString = file_get_contents('data.json');
$data = json_decode($jsonString, true);
print_r($data);</code></pre>"
            }
        };

            content.Faqs = new List<FaqItem>();
        }

        // =========================
        // 12. LINTER (alias)
        // =========================
        private void BuildLinterContent(JsonPageContent content, string friendlyName)
        {
            BuildValidatorContent(content, friendlyName);
            content.MetaTitle = content.MetaTitle.Replace("Validator", "Linter");
            content.HeadingH1 = content.HeadingH1.Replace("Validator", "Linter");
        }

        // =========================
        // 13. DIFF / COMPARE
        // =========================
        private void BuildDiffContent(JsonPageContent content, string friendlyName)
        {
            content.MetaTitle = $"{friendlyName} – JSON Diff & Compare Tool";
            content.MetaDescription = $"Compare two JSON objects with {friendlyName}. Find added, removed, or changed fields.";
            content.HeadingH1 = $"{friendlyName} – Compare JSON Data";

            content.IntroductionHtml = GetToolCta(friendlyName) + @"
<p>JSON diff tools highlight differences between two JSON structures – essential for debugging API changes or configuration drift.</p>";

            content.Sections = new List<ContentSection>
        {
            new() {
                Heading = "Common use cases",
                Html = @"
<ul>
    <li>API version changes (request/response comparison)</li>
    <li>Database migration validation</li>
    <li>Configuration file comparison (dev vs prod)</li>
    <li>Regression testing of JSON outputs</li>
</ul>"
            },
            new() {
                Heading = "Example diff output",
                Html = @"
<pre><code>{
  - ""oldField"": ""value"",
  + ""newField"": ""updated""
}</code></pre>
<p>Minus (-) indicates removed, plus (+) indicates added or changed.</p>"
            }
        };

            content.Faqs = new List<FaqItem>();
        }

        // =========================
        // 14. CONVERT (CSV, XML, YAML, etc.)
        // =========================
        private void BuildConvertContent(JsonPageContent content, string friendlyName)
        {
            content.MetaTitle = $"{friendlyName} – Convert JSON to CSV, XML, YAML";
            content.MetaDescription = $"Transform JSON into other formats with {friendlyName}. Download results instantly.";
            content.HeadingH1 = $"{friendlyName} – JSON Conversion Tools";

            content.IntroductionHtml = GetToolCta(friendlyName) + @"
<p>Convert JSON to CSV, XML, YAML, or other formats. Useful for data migration, reporting, and interoperability.</p>";

            content.Sections = new List<ContentSection>
        {
            new() {
                Heading = "Supported conversions",
                Html = @"
<ul>
    <li>📊 JSON to CSV (flat arrays only – best for tabular data)</li>
    <li>📄 JSON to XML (preserves nested structure)</li>
    <li>📋 JSON to YAML (human‑friendly, ideal for configs)</li>
    <li>🔤 JSON to TypeScript interfaces (generate types from sample)</li>
</ul>"
            },
            new() {
                Heading = "JSON to CSV example",
                Html = @"
<pre><code>// Input JSON array
[
  { ""name"": ""John"", ""age"": 30 },
  { ""name"": ""Jane"", ""age"": 25 }
]

// Output CSV
name,age
John,30
Jane,25</code></pre>"
            }
        };

            content.Faqs = new List<FaqItem>();
        }

        // =========================
        // 15. OPEN / VIEW JSON FILES (with French support)
        // =========================
        private void BuildOpenContent(JsonPageContent content, string friendlyName, string slug)
        {
            bool isFrench = slug.Contains("ouvrir") || slug.Contains("afficher") || slug.Contains("lire");
            content.MetaTitle = isFrench
                ? $"{friendlyName} – Comment ouvrir un fichier JSON (Windows, Mac, Linux)"
                : $"{friendlyName} – How to Open a JSON File (Windows, Mac, Linux, Online)";
            content.MetaDescription = isFrench
                ? $"Apprenez à ouvrir un fichier JSON avec {friendlyName}. Méthodes: bloc-notes, VS Code, navigateur, outils en ligne."
                : $"Learn how to open a JSON file using {friendlyName}. Methods: Notepad, VS Code, browser, online tools, and more.";
            content.HeadingH1 = isFrench
                ? $"Comment ouvrir un fichier JSON – {friendlyName}"
                : $"How to Open a JSON File – {friendlyName}";

            content.IntroductionHtml = GetToolCta(friendlyName) + (isFrench ? @"
<p>Un fichier JSON (JavaScript Object Notation) est un format léger de stockage et d'échange de données. Voici plusieurs façons simples d'ouvrir et de lire un fichier JSON sur n'importe quel système.</p>" : @"
<p>A JSON file is a lightweight data‑interchange format. Here are several easy ways to open and view a JSON file on any operating system.</p>");

            content.Sections = new List<ContentSection>
        {
            new() {
                Heading = isFrench ? "1. Ouvrir avec un éditeur de texte" : "1. Open with a Text Editor",
                Html = (isFrench ? @"
<p><strong>Windows :</strong> Clic droit → Ouvrir avec → Bloc‑notes / Notepad++ / Visual Studio Code.<br/>
<strong>Mac :</strong> Clic droit → Ouvrir avec → TextEdit (format texte brut) ou VS Code.<br/>
<strong>Linux :</strong> Utilisez <code>gedit</code>, <code>nano</code> ou <code>vim</code>.</p>
<p>Astuce : installez une extension JSON pour la coloration syntaxique (ex. Prettier, JSON Tools).</p>" : @"
<p><strong>Windows:</strong> Right‑click → Open with → Notepad / Notepad++ / Visual Studio Code.<br/>
<strong>Mac:</strong> Right‑click → Open with → TextEdit (plain text mode) or VS Code.<br/>
<strong>Linux:</strong> Use <code>gedit</code>, <code>nano</code>, or <code>vim</code>.</p>
<p>Tip: Install a JSON extension for syntax highlighting (e.g., Prettier, JSON Tools).</p>")
            },
            new() {
                Heading = isFrench ? "2. Utiliser un navigateur web" : "2. Use a Web Browser",
                Html = (isFrench ? @"
<p>Glissez‑déposez le fichier .json dans une fenêtre de Chrome, Firefox ou Edge. Le navigateur affichera le contenu brut. Pour une visualisation structurée, utilisez notre outil en ligne.</p>" : @"
<p>Drag and drop the .json file into a Chrome, Firefox, or Edge window. The browser will show raw content. For structured viewing, use our online tool above.</p>")
            },
            new() {
                Heading = isFrench ? "3. Outils en ligne (recommandé)" : "3. Online Tools (Recommended)",
                Html = GetToolCta(friendlyName) + (isFrench ? "<p>Collez votre JSON ou chargez un fichier – formatez, validez, et naviguez dans la structure.</p>" : "<p>Paste your JSON or upload a file – format, validate, and explore the structure.</p>")
            },
            new() {
                Heading = isFrench ? "4. Lire JSON avec un script (Python, Node.js)" : "4. Read JSON with a Script (Python, Node.js)",
                Html = @"
<pre><code>// Python
import json
with open('data.json') as f:
    data = json.load(f)
    print(data)

// Node.js
const fs = require('fs');
const data = JSON.parse(fs.readFileSync('data.json', 'utf8'));
console.log(data);</code></pre>"
            }
        };

            content.Faqs = new List<FaqItem>
        {
            new() { Question = isFrench ? "Puis-je ouvrir un fichier JSON avec Excel ?" : "Can I open a JSON file with Excel?", Answer = isFrench ? "Oui, Excel peut importer JSON via Données → Obtenir des données → À partir d'un fichier → JSON. Les structures imbriquées peuvent ne pas s'afficher parfaitement." : "Yes, Excel can import JSON via Data → Get Data → From File → From JSON. Nested structures may not flatten perfectly." },
            new() { Question = isFrench ? "Quel éditeur recommandez‑vous pour les gros fichiers JSON ?" : "Which editor do you recommend for large JSON files?", Answer = isFrench ? "VS Code ou Notepad++ avec des extensions JSON gèrent bien les fichiers volumineux (jusqu'à plusieurs centaines de Mo)." : "VS Code or Notepad++ with JSON extensions handle large files well (up to several hundred MB)." }
        };
        }

        // =========================
        // 16. INTELLIGENT GENERIC FALLBACK (NEVER THIN)
        // =========================
        private void BuildIntelligentGenericContent(JsonPageContent content, string slug, string friendlyName)
        {
            var keywords = slug.Replace("-", " ").Split(' ');
            var primaryTopic = keywords.FirstOrDefault(k => k.Length > 3) ?? "json";
            var detectedLanguage = DetectLanguageFromSlug(slug);
            var intent = DetectIntentFromSlug(slug);

            content.MetaTitle = $"{friendlyName} – Complete JSON Guide & Tools";
            content.MetaDescription = $"Learn about {friendlyName}: {intent.description}. Includes code examples, best practices, and online tools.";
            content.HeadingH1 = $"{friendlyName} – How to Work with JSON";

            content.IntroductionHtml = GetToolCta(friendlyName) + $@"
<p><strong>JSON (JavaScript Object Notation)</strong> is a lightweight data format used everywhere – from APIs to config files. 
This page covers <strong>{friendlyName}</strong>, a common task when dealing with JSON data.</p>
<p>Below you'll find practical examples, solutions to common problems, and links to our online tools.</p>";

            var sections = new List<ContentSection>();
            sections.Add(new ContentSection
            {
                Heading = $"What does “{friendlyName}” mean?",
                Html = $@"
<p>In the JSON ecosystem, {friendlyName.ToLower()} typically refers to:
<ul>
    <li><strong>Opening, viewing, or reading JSON files</strong> – using text editors, browsers, or specialised tools.</li>
    <li><strong>Parsing JSON data</strong> in a programming language.</li>
    <li><strong>Validating or debugging JSON</strong> when errors occur.</li>
</ul>
Depending on your exact need, the solution may vary. Our online tool above can help you immediately.</p>"
            });

            sections.Add(new ContentSection
            {
                Heading = $"Code example: working with JSON in {detectedLanguage}",
                Html = GetCodeExampleForLanguage(detectedLanguage, friendlyName)
            });

            sections.Add(new ContentSection
            {
                Heading = $"Best practices for {friendlyName}",
                Html = @"
<ul>
    <li>✅ Always validate JSON syntax before processing.</li>
    <li>✅ Use pretty‑printing during development, minify for production.</li>
    <li>✅ Never trust external JSON – sanitize and validate.</li>
    <li>✅ Use schema validation (JSON Schema) for critical data.</li>
</ul>"
            });

            if (intent.toolRelevant)
            {
                sections.Add(new ContentSection
                {
                    Heading = "Use our interactive JSON tool",
                    Html = GetToolCta(friendlyName) + "<p>No installation required – works in your browser, client‑side only.</p>"
                });
            }

            content.Sections = sections;
            content.CodeExampleHtml = GetCodeExampleForLanguage(detectedLanguage, friendlyName);
            content.Faqs = GenerateFaqsFromSlug(slug, friendlyName);
        }

        // Helpers for generic builder
        private string DetectLanguageFromSlug(string slug)
        {
            if (slug.Contains("csharp") || slug.Contains("c#")) return "C#";
            if (slug.Contains("python") || slug.Contains("py")) return "Python";
            if (slug.Contains("javascript") || slug.Contains("js")) return "JavaScript";
            if (slug.Contains("java")) return "Java";
            if (slug.Contains("php")) return "PHP";
            if (slug.Contains("go") || slug.Contains("golang")) return "Go";
            if (slug.Contains("rust")) return "Rust";
            return "JavaScript";
        }

        private (string description, bool toolRelevant) DetectIntentFromSlug(string slug)
        {
            if (slug.Contains("open") || slug.Contains("ouvrir") || slug.Contains("view") || slug.Contains("read"))
                return ("Opening and viewing JSON files", true);
            if (slug.Contains("error") || slug.Contains("invalid") || slug.Contains("parse"))
                return ("Troubleshooting JSON parsing errors", true);
            if (slug.Contains("convert") || slug.Contains("to"))
                return ("Converting JSON to other formats", true);
            if (slug.Contains("compress") || slug.Contains("minify"))
                return ("Minifying JSON for performance", true);
            return ("Practical JSON handling techniques", true);
        }

        private string GetCodeExampleForLanguage(string lang, string friendlyName)
        {
            return lang switch
            {
                "C#" => @"
<pre><code>using System.Text.Json;

// Read JSON from file
string jsonString = File.ReadAllText(""data.json"");
var document = JsonDocument.Parse(jsonString);
Console.WriteLine(document.RootElement);</code></pre>",
                "Python" => @"
<pre><code>import json

# Read JSON from file
with open('data.json', 'r') as f:
    data = json.load(f)
print(data)</code></pre>",
                "JavaScript" => @"
<pre><code>// Read JSON from file (Node.js)
const fs = require('fs');
const data = JSON.parse(fs.readFileSync('data.json', 'utf8'));
console.log(data);</code></pre>",
                "Java" => @"
<pre><code>import com.fasterxml.jackson.databind.ObjectMapper;

ObjectMapper mapper = new ObjectMapper();
JsonNode root = mapper.readTree(new File(""data.json""));
System.out.println(root.toPrettyString());</code></pre>",
                "PHP" => @"
<pre><code>&lt;?php
$jsonString = file_get_contents('data.json');
$data = json_decode($jsonString, true);
print_r($data);
?&gt;</code></pre>",
                _ => @"
<pre><code>// Example: load and parse JSON
const jsonString = '{ ""name"": ""Example"" }';
const parsed = JSON.parse(jsonString);
console.log(parsed);</code></pre>"
            };
        }

        private List<FaqItem> GenerateFaqsFromSlug(string slug, string friendlyName)
        {
            var faqs = new List<FaqItem>();
            faqs.Add(new FaqItem
            {
                Question = $"How do I get started with {friendlyName}?",
                Answer = $"Use our online JSON tool above – paste your JSON and click format/validate. For code integration, check the examples provided."
            });

            if (slug.Contains("open") || slug.Contains("ouvrir"))
            {
                faqs.Add(new FaqItem
                {
                    Question = "Can I open a JSON file in Excel?",
                    Answer = "Yes, Excel can import JSON via Data → Get Data → From File → From JSON. However, nested structures may not flatten correctly."
                });
                faqs.Add(new FaqItem
                {
                    Question = "Which text editor is best for JSON?",
                    Answer = "Visual Studio Code with the 'Prettier' or 'JSON Tools' extension is recommended. Also Notepad++, Sublime Text, or any code editor."
                });
            }
            else if (slug.Contains("error") || slug.Contains("invalid"))
            {
                faqs.Add(new FaqItem
                {
                    Question = "Why do I get 'Unexpected token' error?",
                    Answer = "Common causes: trailing commas, missing quotes around keys, or using single quotes instead of double quotes. Use our validator to pinpoint the error."
                });
            }
            else if (slug.Contains("convert"))
            {
                faqs.Add(new FaqItem
                {
                    Question = "Can I convert JSON to CSV online?",
                    Answer = "Yes, our tool supports JSON to CSV conversion for flat JSON arrays. For nested JSON, you may need to flatten first."
                });
            }

            faqs.Add(new FaqItem
            {
                Question = "Is my JSON data safe when using online tools?",
                Answer = "All processing in our tool happens client‑side (in your browser). Your JSON never leaves your device."
            });
            faqs.Add(new FaqItem
            {
                Question = "What is the maximum JSON size your tool can handle?",
                Answer = "It depends on your browser's memory. Typically, up to 10–20 MB is fine. For larger files, consider command‑line tools."
            });
            return faqs;
        }
    }
}
