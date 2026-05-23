using Microsoft.Extensions.Caching.Memory;
using ratpdf.Models;

namespace ratpdf.Services.JwtSeo;

public interface IContentGenerator
{
    Task<JwtPageContent> GenerateAsync(string slug);
}

public class ContentGenerator : IContentGenerator
{
    private readonly IAllowedSlugsService _allowedSlugs;
    private readonly IMemoryCache _cache;

    private const string ToolUrl = "https://ratpdf.com/PDF/JwtDecoder";

    public ContentGenerator(IAllowedSlugsService allowedSlugs, IMemoryCache cache)
    {
        _allowedSlugs = allowedSlugs;
        _cache = cache;
    }

    public async Task<JwtPageContent> GenerateAsync(string slug)
    {
        var cacheKey = $"JwtPageContent_{slug}";

        if (_cache.TryGetValue(cacheKey, out JwtPageContent? cached) && cached != null)
            return cached;

        var category = GetCategory(slug);
        var friendlyName = SlugToFriendlyName(slug);

        var content = new JwtPageContent
        {
            Slug = slug,
            UpdatedAt = DateTime.UtcNow,
            RelatedSlugs = GetRelatedSlugs(slug),
            Sections = new List<ContentSection>(),
            Faqs = new List<FaqItem>()
        };

        switch (category)
        {
            case "decode":
                BuildDecodeContent(content, slug, friendlyName);
                break;
            case "validate":
                BuildValidateContent(content, slug, friendlyName);
                break;
            case "expired":
                BuildExpiredContent(content, slug, friendlyName);
                break;
            case "signature":
                BuildSignatureContent(content, slug, friendlyName);
                break;
            case "rs256":
                BuildRs256Content(content, slug, friendlyName);
                break;
            case "claims":
                BuildClaimsContent(content, slug, friendlyName);
                break;
            case "oauth":
                BuildOAuthContent(content, slug, friendlyName);
                break;
            case "aspnetcore":
                BuildAspNetCoreContent(content, slug, friendlyName);
                break;
            case "csharp-decode":
                BuildCSharpDecodeContent(content, slug, friendlyName);
                break;
            case "troubleshooting":
                BuildTroubleshootingContent(content, slug, friendlyName);
                break;
            case "how-it-works":
                BuildHowItWorksContent(content, slug, friendlyName);
                break;
            case "vs":
                BuildComparisonContent(content, slug, friendlyName);
                break;
            case "example":
                BuildExampleContent(content, slug, friendlyName);
                break;
            case "install":
                BuildInstallContent(content, slug, friendlyName);
                break;
            case "refresh-token":
                BuildRefreshTokenContent(content, slug, friendlyName);
                break;
            default:
                BuildDynamicGenericContent(content, slug, friendlyName);
                break;
        }

        _cache.Set(cacheKey, content, TimeSpan.FromHours(24));
        return content;
    }

    // =========================
    // ENHANCED CATEGORY DETECTION
    // =========================

    private string GetCategory(string slug)
    {
        if (slug.Contains("decode") || slug.Contains("decoder")) return "decode";
        if (slug.Contains("valid")) return "validate";
        if (slug.Contains("expired")) return "expired";
        if (slug.Contains("signature")) return "signature";
        if (slug.Contains("rs256") || slug.Contains("hs256")) return "rs256";
        if (slug.Contains("claim")) return "claims";
        if (slug.Contains("oauth")) return "oauth";
        if (slug.Contains("aspnetcore") || slug.Contains("asp.net")) return "aspnetcore";
        if (slug.Contains("csharp") || slug.Contains("c-sharp")) return "csharp-decode";
        if (slug.Contains("troubleshooting") || slug.Contains("error") || slug.Contains("fix")) return "troubleshooting";
        if (slug.Contains("how") && (slug.Contains("work") || slug.Contains("function"))) return "how-it-works";
        if (slug.Contains("vs") || slug.Contains("versus") || slug.Contains("difference")) return "vs";
        if (slug.Contains("example") || slug.Contains("sample")) return "example";
        if (slug.Contains("install") || slug.Contains("setup") || slug.Contains("utility")) return "install";
        if (slug.Contains("refresh-token") || slug.Contains("refresh token")) return "refresh-token";

        return "generic";
    }

    private string SlugToFriendlyName(string slug)
    {
        var name = slug.Replace("-", " ")
                       .Replace("jwt", "JWT")
                       .Replace("csharp", "C#")
                       .Replace("c-sharp", "C#")
                       .Replace("aspnetcore", "ASP.NET Core")
                       .Replace("next auth", "NextAuth.js")
                       .Trim();
        // Capitalize first letter of each word
        var words = name.Split(' ');
        for (int i = 0; i < words.Length; i++)
        {
            if (words[i].Length > 0)
                words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1).ToLower();
        }
        return string.Join(" ", words);
    }

    private List<string> GetRelatedSlugs(string currentSlug)
    {
        var all = _allowedSlugs.GetAllSlugs();
        return all
            .Where(s => s != currentSlug)
            .OrderBy(_ => Random.Shared.Next())
            .Take(5)
            .ToList();
    }

    private string GetToolCta(string friendlyName)
    {
        return $@"
<div class='tool-cta' style='background:#f5f5f5; padding:15px; border-radius:8px; margin:20px 0; text-align:center;'>
    <a href='{ToolUrl}' target='_blank' rel='noopener' style='display:inline-block; background:#0066cc; color:white; padding:10px 20px; text-decoration:none; border-radius:5px;'>
        🔓 Open JWT Decoder Tool
    </a>
    <p style='margin-top:10px;'>Try <strong>{friendlyName}</strong> instantly – 100% client‑side, no data leaves your browser.</p>
</div>";
    }

    // =========================
    // NEW: "HOW IT WORKS" BUILDER
    // =========================

    private void BuildHowItWorksContent(JwtPageContent content, string slug, string friendlyName)
    {
        content.MetaTitle = $"{friendlyName} – Complete Guide to JWT";
        content.MetaDescription = $"Learn how JWT (JSON Web Token) works: structure, signing, verification, and common use cases. Includes diagrams and code.";
        content.HeadingH1 = $"{friendlyName} – JSON Web Tokens Explained";

        content.IntroductionHtml = GetToolCta(friendlyName) + @"
<p><strong>JWT (JSON Web Token)</strong> is an open standard (RFC 7519) that defines a compact and self‑contained way to securely transmit information between parties as a JSON object.</p>
<p>JWTs are digitally signed, so they can be verified and trusted. They are commonly used for authentication and authorization in modern web applications.</p>";

        content.Sections = new List<ContentSection>
        {
            new() {
                Heading = "How JWT works – step by step",
                Html = @"
<ol>
    <li><strong>User logs in</strong> – credentials sent to server.</li>
    <li><strong>Server verifies</strong> credentials, creates a JWT with user claims.</li>
    <li><strong>Server signs</strong> the JWT using a secret or private key.</li>
    <li><strong>Client stores</strong> the JWT (localStorage, cookie, or memory).</li>
    <li><strong>Client sends</strong> JWT in Authorization header for subsequent requests.</li>
    <li><strong>Server validates</strong> signature and claims, then processes request.</li>
</ol>"
            },
            new() {
                Heading = "JWT structure",
                Html = @"
<p>A JWT consists of three parts separated by dots:</p>
<pre><code>xxxxx.yyyyy.zzzzz</code></pre>
<ul>
    <li><strong>Header</strong> – algorithm and token type (e.g., HS256, RS256).</li>
    <li><strong>Payload</strong> – claims (user data, expiration, issuer).</li>
    <li><strong>Signature</strong> – verifies the token hasn't been tampered with.</li>
</ul>"
            },
            new() {
                Heading = "Why use JWTs?",
                Html = @"
<ul>
    <li>✅ Stateless – no server‑side session storage.</li>
    <li>✅ Self‑contained – carries user info inside the token.</li>
    <li>✅ Cross‑platform – works with any language (C#, JavaScript, Python, etc.).</li>
    <li>✅ Scalable – perfect for microservices and distributed systems.</li>
</ul>"
            }
        };

        content.CodeExampleHtml = @"
<h3>Generate a JWT in C#</h3>
<pre><code>var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(""your-256-bit-secret""));
var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

var claims = new[] {
    new Claim(JwtRegisteredClaimNames.Sub, ""user123""),
    new Claim(JwtRegisteredClaimNames.Email, ""user@example.com""),
    new Claim(""role"", ""admin"")
};

var token = new JwtSecurityToken(
    issuer: ""https://ratpdf.com"",
    audience: ""api"",
    claims: claims,
    expires: DateTime.UtcNow.AddHours(1),
    signingCredentials: credentials
);

var jwtString = new JwtSecurityTokenHandler().WriteToken(token);</code></pre>";

        content.Faqs = new List<FaqItem>
        {
            new() { Question = "Is JWT secure?", Answer = "Yes, when properly implemented with strong secrets, HTTPS, and short expiration times." },
            new() { Question = "Can JWT be decrypted?", Answer = "JWTs are signed, not encrypted by default. Use JWE for encryption." },
            new() { Question = "Where should I store JWT on the client?", Answer = "HttpOnly cookies are safest; localStorage is vulnerable to XSS." }
        };
    }

    // =========================
    // NEW: COMPARISON (vs) BUILDER
    // =========================

    private void BuildComparisonContent(JwtPageContent content, string slug, string friendlyName)
    {
        // Extract what is being compared (e.g., "jwt-token-vs-api-key")
        var parts = slug.Split('-');
        var a = "JWT";
        var b = "API Key";
        if (parts.Contains("jwt") && parts.Contains("api"))
        {
            a = "JWT";
            b = "API Key";
        }
        else if (parts.Contains("jwt") && parts.Contains("session"))
        {
            a = "JWT";
            b = "Session";
        }
        else if (parts.Contains("oauth") && parts.Contains("jwt"))
        {
            a = "OAuth 2.0";
            b = "JWT";
        }

        content.MetaTitle = $"{a} vs {b} – Which One to Use?";
        content.MetaDescription = $"Detailed comparison between {a} and {b}. Understand differences, pros, cons, and use cases.";
        content.HeadingH1 = $"{a} vs {b} – A Complete Comparison";

        content.IntroductionHtml = GetToolCta(friendlyName) + $@"
<p>Both <strong>{a}</strong> and <strong>{b}</strong> are used for securing APIs, but they work differently. This guide explains the key differences.</p>";

        content.Sections = new List<ContentSection>
        {
            new() {
                Heading = $"What is {a}?",
                Html = a == "JWT"
                    ? "<p>JWT is a self‑contained token format that holds user claims. It is stateless and verified by signature.</p>"
                    : $"<p>{a} is an authorization framework that issues tokens (often JWTs) to clients.</p>"
            },
            new() {
                Heading = $"What is {b}?",
                Html = b == "API Key"
                    ? "<p>API keys are simple alphanumeric strings sent via headers or query parameters. They are static and often used for simple access.</p>"
                    : $"<p>{b} is a server‑side storage of user state.</p>"
            },
            new() {
                Heading = "Key differences",
                Html = $@"
<table border='1' cellpadding='8' style='border-collapse:collapse; width:100%;'>
    <tr><th>Feature</th><th>{a}</th><th>{b}</th></tr>
    <tr><td>State</td><td>Stateless</td><td>Stateful (server stores)</td></tr>
    <tr><td>Security</td><td>Signature verified</td><td>Simple string, can be leaked</td></tr>
    <tr><td>Revocation</td><td>Hard (until expiry)</td><td>Easy (delete key)</td></tr>
    <tr><td>Use case</td><td>Microservices, SPAs</td><td>Simple APIs, server‑to‑server</td></tr>
</table>"
            }
        };

        content.Faqs = new List<FaqItem>
        {
            new() { Question = $"When should I use {a} over {b}?", Answer = $"Use {a} for distributed systems and fine‑grained authorization; use {b} for simple, low‑risk integrations." }
        };
    }

    // =========================
    // NEW: EXAMPLE BUILDER
    // =========================

    private void BuildExampleContent(JwtPageContent content, string slug, string friendlyName)
    {
        content.MetaTitle = $"{friendlyName} – Real‑World Code Example";
        content.MetaDescription = $"Step‑by‑step example of implementing {friendlyName}. Includes C#, JavaScript, and Python code.";
        content.HeadingH1 = $"{friendlyName} – Practical Example";

        content.IntroductionHtml = GetToolCta(friendlyName) + "<p>Below is a working code example to help you integrate JWT in your project.</p>";

        content.Sections = new List<ContentSection>
        {
            new() {
                Heading = "Complete example",
                Html = @"
<h4>C# – Generate and validate JWT</h4>
<pre><code>// Generate
var tokenHandler = new JwtSecurityTokenHandler();
var tokenDescriptor = new SecurityTokenDescriptor
{
    Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, ""john@example.com"") }),
    Expires = DateTime.UtcNow.AddMinutes(30),
    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(""secret"")), SecurityAlgorithms.HmacSha256)
};
var token = tokenHandler.CreateToken(tokenDescriptor);
var tokenString = tokenHandler.WriteToken(token);

// Validate
var validationParameters = new TokenValidationParameters
{
    ValidateIssuerSigningKey = true,
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(""secret"")),
    ValidateIssuer = false,
    ValidateAudience = false
};
var principal = tokenHandler.ValidateToken(tokenString, validationParameters, out _);</code></pre>"
            }
        };

        content.Faqs = new List<FaqItem>();
    }

    // =========================
    // NEW: INSTALL BUILDER
    // =========================

    private void BuildInstallContent(JwtPageContent content, string slug, string friendlyName)
    {
        content.MetaTitle = $"How to Install {friendlyName} – Quick Setup Guide";
        content.MetaDescription = $"Install JWT libraries in C#, Node.js, Python, and Java. Step‑by‑step instructions with commands.";
        content.HeadingH1 = $"Install {friendlyName} – Package Manager Guide";

        content.IntroductionHtml = GetToolCta(friendlyName) + "<p>Add JWT support to your project using these package managers.</p>";

        content.Sections = new List<ContentSection>
        {
            new() {
                Heading = "Installation commands",
                Html = @"
<pre><code># .NET (C#)
dotnet add package System.IdentityModel.Tokens.Jwt

# Node.js
npm install jsonwebtoken

# Python
pip install pyjwt

# Java (Maven)
&lt;dependency&gt;
    &lt;groupId&gt;io.jsonwebtoken&lt;/groupId&gt;
    &lt;artifactId&gt;jjwt&lt;/artifactId&gt;
    &lt;version&gt;0.11.5&lt;/version&gt;
&lt;/dependency&gt;</code></pre>"
            }
        };

        content.Faqs = new List<FaqItem>();
    }

    // =========================
    // NEW: REFRESH TOKEN BUILDER
    // =========================

    private void BuildRefreshTokenContent(JwtPageContent content, string slug, string friendlyName)
    {
        content.MetaTitle = $"Refresh Token Example – JWT Rotation Pattern";
        content.MetaDescription = $"Learn how to implement refresh tokens with JWT. Secure, sliding expiration, and code examples.";
        content.HeadingH1 = $"JWT Refresh Token – Complete Implementation";

        content.IntroductionHtml = GetToolCta(friendlyName) + @"
<p>Refresh tokens allow clients to obtain new access tokens without re‑authenticating.</p>";

        content.Sections = new List<ContentSection>
        {
            new() {
                Heading = "How refresh token flow works",
                Html = @"
<ol>
    <li>User logs in → server returns access token (short‑lived) + refresh token (long‑lived).</li>
    <li>Access token expires → client sends refresh token to /refresh endpoint.</li>
    <li>Server validates refresh token, issues new access token.</li>
    <li>Refresh token can be rotated (old one invalidated after use).</li>
</ol>"
            },
            new() {
                Heading = "C# example",
                Html = @"
<pre><code>// Generate refresh token (GUID)
var refreshToken = Convert.ToBase64String(Guid.NewGuid().ToByteArray());

// Store in database (hashed) with user ID and expiration

// Endpoint to refresh
[HttpPost(""refresh"")]
public IActionResult Refresh(string refreshToken)
{
    var storedToken = _db.RefreshTokens.FirstOrDefault(rt => rt.Token == refreshToken);
    if (storedToken == null || storedToken.Expires < DateTime.UtcNow)
        return Unauthorized();

    var newAccessToken = GenerateJwtToken(storedToken.UserId);
    return Ok(new { accessToken = newAccessToken });
}</code></pre>"
            }
        };

        content.Faqs = new List<FaqItem>
        {
            new() { Question = "Should refresh tokens be stored?", Answer = "Yes – in an HTTP‑only cookie or secure database." }
        };
    }

    // =========================
    // IMPROVED GENERIC BUILDER (dynamic from slug)
    // =========================

    private void BuildDynamicGenericContent(JwtPageContent content, string slug, string friendlyName)
    {
        // Extract key terms from slug to personalize content
        var keywords = slug.Replace("-", " ").Split(' ');
        var mainTopic = keywords.Length > 2 ? string.Join(" ", keywords.Take(3)) : friendlyName;

        content.MetaTitle = $"{friendlyName} – Complete JWT Guide & Examples";
        content.MetaDescription = $"Learn everything about {friendlyName} – practical examples, best practices, and code snippets for developers.";
        content.HeadingH1 = $"{friendlyName} – Comprehensive Guide";

        content.IntroductionHtml = GetToolCta(friendlyName) + $@"
<p>This page explains <strong>{friendlyName}</strong> in the context of JSON Web Tokens (JWT). 
Whether you're debugging, implementing authentication, or just learning, you'll find relevant information here.</p>
<p>JWT is a critical component in modern API security. Understanding {friendlyName} helps you build more secure and scalable applications.</p>";

        content.Sections = new List<ContentSection>
        {
            new() {
                Heading = $"What is {friendlyName}?",
                Html = $@"
<p>{friendlyName} relates to how JSON Web Tokens are used in real‑world scenarios. 
JWTs are often employed for:</p>
<ul>
    <li>User authentication after login</li>
    <li>API authorization (Bearer tokens)</li>
    <li>Secure data exchange between services</li>
    <li>Single Sign‑On (SSO)</li>
</ul>
<p>This specific topic – {friendlyName} – addresses a common need among developers.</p>"
            },
            new() {
                Heading = "Practical example",
                Html = $@"
<pre><code>// Example relevant to {friendlyName}
using System.IdentityModel.Tokens.Jwt;

var token = ""eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."";
var handler = new JwtSecurityTokenHandler();
var jwt = handler.ReadJwtToken(token);

Console.WriteLine($""Topic: {friendlyName}"");
Console.WriteLine($""Algorithm: {{jwt.Header[""alg""]}}"");
Console.WriteLine($""User: {{jwt.Subject}}"");</code></pre>
<p>Use our interactive decoder above to test your own tokens.</p>"
            },
            new() {
                Heading = "Best practices",
                Html = @"
<ul>
    <li>Always use HTTPS to prevent token interception</li>
    <li>Keep secrets out of client‑side code</li>
    <li>Set short expiration times (15–60 minutes)</li>
    <li>Implement refresh tokens for longer sessions</li>
    <li>Validate all claims (issuer, audience, expiration)</li>
</ul>"
            },
            new() {
                Heading = "Common pitfalls",
                Html = @"
<ul>
    <li>❌ Storing JWTs in localStorage (XSS risk)</li>
    <li>❌ Not rotating secrets</li>
    <li>❌ Using weak HMAC keys</li>
    <li>❌ Ignoring expiration validation</li>
</ul>"
            }
        };

        content.CodeExampleHtml = @"
<h3>Decode and inspect any JWT</h3>
<pre><code>var handler = new JwtSecurityTokenHandler();
var jsonToken = handler.ReadJwtToken(yourToken);
var header = jsonToken.Header;
var payload = jsonToken.Payload;
var isExpired = jsonToken.ValidTo < DateTime.UtcNow;</code></pre>";

        content.Faqs = new List<FaqItem>
        {
            new() { Question = $"How do I get started with {friendlyName}?",
                    Answer = "Start by using our online decoder to inspect example tokens, then integrate the JWT library for your language (C#, Node.js, Python)." },
            new() { Question = "Is this information up to date?",
                    Answer = "Yes – JWT is an open standard (RFC 7519) that hasn't changed since 2015. Our content follows current best practices." },
            new() { Question = "Where can I find more examples?",
                    Answer = "Check the 'Related Topics' section below for other JWT guides." }
        };
    }


    private void BuildDecodeContent(JwtPageContent content, string slug, string friendlyName) { /* your existing */ }
    private void BuildValidateContent(JwtPageContent content, string slug, string friendlyName) { /* your existing */ }
    private void BuildExpiredContent(JwtPageContent content, string slug, string friendlyName) { /* your existing */ }
    private void BuildSignatureContent(JwtPageContent content, string slug, string friendlyName) { /* your existing */ }
    private void BuildRs256Content(JwtPageContent content, string slug, string friendlyName) { /* your existing */ }
    private void BuildClaimsContent(JwtPageContent content, string slug, string friendlyName) { /* your existing */ }
    private void BuildOAuthContent(JwtPageContent content, string slug, string friendlyName) { /* your existing */ }
    private void BuildAspNetCoreContent(JwtPageContent content, string slug, string friendlyName) { /* your existing */ }
    private void BuildCSharpDecodeContent(JwtPageContent content, string slug, string friendlyName) { /* your existing */ }
    private void BuildTroubleshootingContent(JwtPageContent content, string slug, string friendlyName) { /* your existing */ }
}