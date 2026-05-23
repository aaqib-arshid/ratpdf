using Microsoft.Extensions.Caching.Memory;
using ratpdf.Models;

namespace ratpdf.Services.HtmlSeo
{
    public interface IHtmlContentGenerator
    {
        Task<HtmlPageContent> GenerateAsync(string slug);
    }
    public class HtmlContentGenerator : IHtmlContentGenerator
    {
        private readonly IHtmlAllowedSlugsService _allowedSlugs;
        private readonly IMemoryCache _cache;
        private const string ToolUrl = "https://ratpdf.com/PDF/HtmlFormatter";

        public HtmlContentGenerator(IHtmlAllowedSlugsService allowedSlugs, IMemoryCache cache)
        {
            _allowedSlugs = allowedSlugs;
            _cache = cache;
        }

        public async Task<HtmlPageContent> GenerateAsync(string slug)
        {
            var cacheKey = $"HtmlPageContent_{slug}";
            if (_cache.TryGetValue(cacheKey, out HtmlPageContent? cached) && cached != null)
                return cached;

            var category = GetCategory(slug);
            var friendlyName = SlugToFriendlyName(slug);

            var content = new HtmlPageContent
            {
                Slug = slug,
                UpdatedAt = DateTime.UtcNow,
                RelatedSlugs = GetRelatedSlugs(slug),
                Sections = new List<ContentSection>(),
                Faqs = new List<FaqItem>()
            };

            switch (category)
            {
                case "beautify":
                    BuildBeautifyContent(content, friendlyName);
                    break;
                case "minify":
                    BuildMinifyContent(content, friendlyName);
                    break;
                case "validate":
                    BuildValidateContent(content, friendlyName);
                    break;
                case "prettify":
                    BuildPrettifyContent(content, friendlyName);
                    break;
                case "csharp":
                    BuildCSharpContent(content, friendlyName);
                    break;
                case "vscode":
                    BuildVsCodeContent(content, friendlyName);
                    break;
                default:
                    BuildGenericContent(content, slug, friendlyName);
                    break;
            }

            _cache.Set(cacheKey, content, TimeSpan.FromHours(24));
            return content;
        }

        private string GetCategory(string slug)
        {
            if (slug.Contains("beautify") || slug.Contains("pretty")) return "beautify";
            if (slug.Contains("minify") || slug.Contains("compress")) return "minify";
            if (slug.Contains("valid") || slug.Contains("lint")) return "validate";
            if (slug.Contains("prettier") || slug.Contains("prettify")) return "prettify";
            if (slug.Contains("csharp") || slug.Contains("c#")) return "csharp";
            if (slug.Contains("vscode") || slug.Contains("vs-code")) return "vscode";
            return "generic";
        }

        private string SlugToFriendlyName(string slug)
        {
            return slug.Replace("-", " ")
                       .Replace("html", "HTML")
                       .Replace("csharp", "C#")
                       .Replace("vscode", "VS Code")
                       .Trim();
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
    <a href='{ToolUrl}' target='_blank' rel='noopener' style='display:inline-block; background:#28a745; color:white; padding:10px 20px; text-decoration:none; border-radius:5px;'>
        🧹 Open HTML Formatter Tool
    </a>
    <p style='margin-top:10px;'>Use <strong>{friendlyName}</strong> instantly – beautify, minify, or validate your HTML code.</p>
</div>";
        }

        // === CONTENT BUILDERS (each with rich, unique text) ===

        private void BuildBeautifyContent(HtmlPageContent content, string friendlyName)
        {
            content.MetaTitle = $"{friendlyName} – HTML Beautifier & Formatter Online";
            content.MetaDescription = $"Format messy HTML code with proper indentation. {friendlyName} tool makes your code readable and maintainable.";
            content.HeadingH1 = $"{friendlyName} – Clean & Format HTML Instantly";

            content.IntroductionHtml = GetToolCta(friendlyName) + @"
<p>HTML beautification (or pretty‑printing) adds consistent indentation, line breaks, and spacing to raw HTML. This makes the code easier to read, debug, and maintain.</p>
<p>Our tool uses a fast, client‑side parser – your HTML never leaves your browser.</p>";

            content.Sections = new List<ContentSection>
        {
            new() {
                Heading = "Why beautify HTML?",
                Html = @"
<ul>
    <li>✅ Improves readability for teams</li>
    <li>✅ Simplifies debugging (matching tags)</li>
    <li>✅ Makes code review easier</li>
    <li>✅ Reduces cognitive load</li>
</ul>"
            },
            new() {
                Heading = "How it works",
                Html = @"
<p>The beautifier parses your HTML, builds a DOM tree, then outputs it with proper indentation (2 or 4 spaces, or tabs).</p>
<pre><code>&lt;!-- Before --&gt;
&lt;div&gt;&lt;p&gt;Hello&lt;/p&gt;&lt;/div&gt;

&lt;!-- After --&gt;
&lt;div&gt;
    &lt;p&gt;Hello&lt;/p&gt;
&lt;/div&gt;</code></pre>"
            }
        };

            content.CodeExampleHtml = @"
<h3>Beautify HTML in C# (using AngleSharp)</h3>
<pre><code>using AngleSharp.Html.Parser;
var parser = new HtmlParser();
var document = parser.ParseDocument(messyHtml);
var prettyHtml = document.DocumentElement.OuterHtml;</code></pre>";

            content.Faqs = new List<FaqItem>
        {
            new() { Question = "Does beautification change HTML behavior?", Answer = "No – only whitespace is added. The rendered output stays identical." },
            new() { Question = "Can I set custom indentation?", Answer = "Yes, our tool lets you choose spaces or tabs, and the number of spaces." }
        };
        }

        private void BuildMinifyContent(HtmlPageContent content, string friendlyName)
        {
            content.MetaTitle = $"{friendlyName} – HTML Minifier & Compressor";
            content.MetaDescription = $"Reduce HTML size by removing whitespace, comments, and unnecessary characters. Speed up your website.";
            content.HeadingH1 = $"{friendlyName} – Optimise HTML for Production";

            content.IntroductionHtml = GetToolCta(friendlyName) + @"
<p>Minification removes unnecessary characters without affecting functionality. This reduces file size, improves load times, and saves bandwidth.</p>";

            content.Sections = new List<ContentSection>
        {
            new() {
                Heading = "What minification removes",
                Html = @"
<ul>
    <li>Extra whitespace and line breaks</li>
    <li>HTML comments</li>
    <li>Optional quotes around attributes (when safe)</li>
    <li>Unused code (optional)</li>
</ul>"
            },
            new() {
                Heading = "Performance impact",
                Html = @"
<p>A typical HTML page can be reduced by 20–50%. For high‑traffic sites, this significantly reduces bandwidth costs.</p>"
            }
        };

            content.CodeExampleHtml = @"
<h3>Minify HTML in C# using WebMarkupMin</h3>
<pre><code>using WebMarkupMin.Core;
var minifier = new HtmlMinifier();
var result = minifier.Minify(originalHtml);
string minified = result.MinifiedContent;</code></pre>";

            content.Faqs = new List<FaqItem>
        {
            new() { Question = "Is minified HTML still human‑readable?", Answer = "Not really – it's designed for machines. Keep an unminified version for development." }
        };
        }

        private void BuildValidateContent(HtmlPageContent content, string friendlyName)
        {
            content.MetaTitle = $"{friendlyName} – HTML Validator & Linter";
            content.MetaDescription = $"Check your HTML for errors, unclosed tags, and accessibility issues. Improve code quality.";
            content.HeadingH1 = $"{friendlyName} – Validate HTML Syntax";

            content.IntroductionHtml = GetToolCta(friendlyName) + @"
<p>Validation ensures your HTML follows W3C standards. It catches missing closing tags, invalid attributes, and nesting errors.</p>";

            content.Sections = new List<ContentSection>
        {
            new() {
                Heading = "Common validation issues",
                Html = @"
<ul>
    <li>❌ Unclosed tags (e.g., &lt;div&gt; without &lt;/div&gt;)</li>
    <li>❌ Duplicate IDs</li>
    <li>❌ Invalid nesting (e.g., &lt;li&gt; outside &lt;ul&gt;)</li>
    <li>❌ Deprecated attributes</li>
</ul>"
            }
        };

            content.Faqs = new List<FaqItem>
        {
            new() { Question = "Do I need to validate HTML?", Answer = "Yes – valid HTML ensures consistent rendering across browsers and better SEO." }
        };
        }

        private void BuildPrettifyContent(HtmlPageContent content, string friendlyName)
        {
            BuildBeautifyContent(content, friendlyName); // similar to beautify
            content.MetaTitle = content.MetaTitle.Replace("Beautifier", "Prettifier");
        }

        private void BuildCSharpContent(HtmlPageContent content, string friendlyName)
        {
            content.MetaTitle = $"Format HTML in C# – {friendlyName} Code Examples";
            content.MetaDescription = $"How to beautify, minify, or parse HTML using C# libraries. Step‑by‑step code with AngleSharp, HtmlAgilityPack.";
            content.HeadingH1 = $"{friendlyName} – C# HTML Processing";

            content.IntroductionHtml = GetToolCta(friendlyName) + @"
<p>Process HTML programmatically in C# using popular NuGet packages. Below are examples for beautification, minification, and parsing.</p>";

            content.Sections = new List<ContentSection>
        {
            new() {
                Heading = "Using HtmlAgilityPack (parse & format)",
                Html = @"
<pre><code>using HtmlAgilityPack;
var doc = new HtmlDocument();
doc.LoadHtml(messyHtml);
var prettyHtml = doc.DocumentNode.OuterHtml;</code></pre>"
            },
            new() {
                Heading = "Using AngleSharp (more modern)",
                Html = @"
<pre><code>using AngleSharp.Html.Parser;
var parser = new HtmlParser();
var document = parser.ParseDocument(html);
var formatted = document.DocumentElement.OuterHtml;</code></pre>"
            }
        };

            content.Faqs = new List<FaqItem>();
        }

        private void BuildVsCodeContent(HtmlPageContent content, string friendlyName)
        {
            content.MetaTitle = $"HTML Formatter in VS Code – {friendlyName} Extensions";
            content.MetaDescription = $"Best VS Code extensions for formatting HTML: Prettier, Beautify, HTML CSS Support. Setup guide.";
            content.HeadingH1 = $"{friendlyName} – VS Code HTML Formatting";

            content.IntroductionHtml = GetToolCta(friendlyName) + @"
<p>VS Code has built‑in HTML formatters, but extensions give more control. Here's how to set them up.</p>";

            content.Sections = new List<ContentSection>
        {
            new() {
                Heading = "Recommended extensions",
                Html = @"
<ul>
    <li><strong>Prettier</strong> – opinionated, supports HTML/CSS/JS</li>
    <li><strong>Beautify</strong> – customisable indentation</li>
    <li><strong>HTML CSS Support</strong> – auto‑completion + formatting</li>
</ul>"
            },
            new() {
                Heading = "Setup Prettier for HTML",
                Html = @"
<pre><code>// settings.json
{
    ""editor.defaultFormatter"": ""esbenp.prettier-vscode"",
    ""editor.formatOnSave"": true,
    ""prettier.printWidth"": 100
}</code></pre>"
            }
        };

            content.Faqs = new List<FaqItem>();
        }

        private void BuildGenericContent(HtmlPageContent content, string slug, string friendlyName)
        {
            content.MetaTitle = $"{friendlyName} – HTML Formatting Guide";
            content.MetaDescription = $"Learn about {friendlyName} – tools, best practices, and code examples for HTML processing.";
            content.HeadingH1 = $"{friendlyName} – Complete Resource";

            content.IntroductionHtml = GetToolCta(friendlyName) + $@"
<p>This page covers everything about <strong>{friendlyName}</strong> in the context of HTML formatting, beautification, and validation.</p>
<p>Whether you're a beginner or an expert, you'll find useful tips and ready‑to‑use code.</p>";

            content.Sections = new List<ContentSection>
        {
            new() {
                Heading = $"Why {friendlyName} matters",
                Html = "<p>Clean, well‑formatted HTML improves maintainability, reduces debugging time, and enhances collaboration.</p>"
            },
            new() {
                Heading = "Quick example",
                Html = $@"
                <pre><code>&lt;!-- Before --&gt;
                &lt;div&gt;&lt;ul&gt;&lt;li&gt;One&lt;/li&gt;&lt;li&gt;Two&lt;/li&gt;&lt;/ul&gt;&lt;/div&gt;

                &lt;!-- After {friendlyName} --&gt;
                &lt;div&gt;
                    &lt;ul&gt;
                        &lt;li&gt;One&lt;/li&gt;
                        &lt;li&gt;Two&lt;/li&gt;
                    &lt;/ul&gt;
                &lt;/div&gt;</code></pre>"
            }
        };

            content.Faqs = new List<FaqItem>
        {
            new() { Question = "Is this tool free?", Answer = "Yes, completely free with no registration." },
            new() { Question = "Does it work offline?", Answer = "No – it runs online, but all processing is client‑side." }
        };
        }
    }
}
