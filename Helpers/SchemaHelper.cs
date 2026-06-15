using ratpdf.Constants;
using ratpdf.Models;
using ratpdf.Models.CompressPdfSeo;
using System.Text.Json;

namespace ratpdf.Helpers
{
    public class SchemaHelper
    {
        private static readonly JsonSerializerOptions JsonOpts = new() { DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull };

        public static string BuildGlobalSiteGraphLdJson()
        {
            var graph = new List<object>
            {
                new Dictionary<string, object>
                {
                    ["@type"] = "Organization",
                    ["@id"] = SiteEntity.OrganizationId,
                    ["name"] = SiteEntity.Name,
                    ["alternateName"] = SiteEntity.AlternateName,
                    ["url"] = SiteEntity.SiteUrl,
                    ["logo"] = new { @type = "ImageObject", url = SiteEntity.LogoUrl, width = 512, height = 512 },
                    ["description"] = SiteEntity.Description,
                    ["email"] = SiteEntity.ContactEmail,
                    ["foundingDate"] = SiteEntity.FoundingDate,
                    ["sameAs"] = SiteEntity.SameAs,
                    ["knowsAbout"] = SiteEntity.KnowsAbout,
                    ["areaServed"] = SiteEntity.AreaServed,
                    ["contactPoint"] = new[]
                    {
                        new Dictionary<string, object>
                        {
                            ["@type"] = "ContactPoint",
                            ["contactType"] = "customer support",
                            ["email"] = SiteEntity.ContactEmail,
                            ["url"] = $"{SiteEntity.SiteUrl}{SiteEntity.ContactPath}",
                            ["availableLanguage"] = new[] { "English" },
                        },
                    },
                },
                new Dictionary<string, object>
                {
                    ["@type"] = "WebSite",
                    ["@id"] = SiteEntity.WebsiteId,
                    ["name"] = SiteEntity.Name,
                    ["alternateName"] = SiteEntity.AlternateName,
                    ["url"] = SiteEntity.SiteUrl,
                    ["description"] = SiteEntity.Description,
                    ["inLanguage"] = "en",
                    ["publisher"] = new { @id = SiteEntity.OrganizationId },
                    ["about"] = new { @id = SiteEntity.OrganizationId },
                },
            };

            foreach (var author in SiteAuthors.All)
                graph.Add(BuildPersonNode(author));

            return JsonSerializer.Serialize(new { @context = "https://schema.org", @graph = graph }, JsonOpts);
        }

        private static Dictionary<string, object> BuildPersonNode(SiteAuthor author) => new()
        {
            ["@type"] = "Person",
            ["@id"] = SiteAuthors.PersonId(author.Slug),
            ["name"] = author.Name,
            ["jobTitle"] = author.JobTitle,
            ["description"] = author.Bio,
            ["url"] = SiteAuthors.ProfileUrl(author.Slug),
            ["email"] = author.Email,
            ["worksFor"] = new { @id = SiteEntity.OrganizationId },
            ["knowsAbout"] = author.KnowsAbout,
        };

        public static string BuildPersonProfileLdJson(SiteAuthor author, IReadOnlyList<(string Title, string Url)>? authoredContent = null)
        {
            var graph = new List<object>
            {
                BuildPersonNode(author),
                new Dictionary<string, object>
                {
                    ["@type"] = "ProfilePage",
                    ["@id"] = $"{SiteAuthors.ProfileUrl(author.Slug)}#profilepage",
                    ["url"] = SiteAuthors.ProfileUrl(author.Slug),
                    ["name"] = $"{author.Name} — {author.JobTitle}",
                    ["description"] = author.Bio,
                    ["mainEntity"] = new { @id = SiteAuthors.PersonId(author.Slug) },
                    ["isPartOf"] = new { @id = SiteEntity.WebsiteId },
                    ["publisher"] = new { @id = SiteEntity.OrganizationId },
                },
            };

            if (authoredContent is { Count: > 0 })
            {
                graph.Add(new
                {
                    @type = "ItemList",
                    name = $"Articles by {author.Name}",
                    itemListElement = authoredContent.Select((item, i) => new
                    {
                        @type = "ListItem",
                        position = i + 1,
                        item = new { @type = "WebPage", name = item.Title, url = item.Url },
                    }).ToList(),
                });
            }

            graph.Add(new
            {
                @type = "BreadcrumbList",
                itemListElement = new object[]
                {
                    new { @type = "ListItem", position = 1, name = "Home", item = SiteEntity.SiteUrl },
                    new { @type = "ListItem", position = 2, name = "Authors", item = $"{SiteEntity.SiteUrl}{SiteAuthors.HubPath}" },
                    new { @type = "ListItem", position = 3, name = author.Name, item = SiteAuthors.ProfileUrl(author.Slug) },
                },
            });

            return JsonSerializer.Serialize(new { @context = "https://schema.org", @graph = graph }, JsonOpts);
        }

        public static string BuildWebPageLdJson(
            string name,
            string description,
            string canonicalUrl,
            string? pageType = "WebPage",
            string[]? speakableSelectors = null)
        {
            var page = new Dictionary<string, object>
            {
                ["@type"] = pageType ?? "WebPage",
                ["@id"] = $"{canonicalUrl}#webpage",
                ["name"] = name,
                ["description"] = description,
                ["url"] = canonicalUrl,
                ["inLanguage"] = "en",
                ["isPartOf"] = new { @id = SiteEntity.WebsiteId },
                ["publisher"] = new { @id = SiteEntity.OrganizationId },
                ["about"] = new { @id = SiteEntity.OrganizationId },
            };

            if (speakableSelectors is { Length: > 0 })
            {
                page["speakable"] = new
                {
                    @type = "SpeakableSpecification",
                    cssSelector = speakableSelectors,
                };
            }

            return JsonSerializer.Serialize(new { @context = "https://schema.org", @graph = new[] { page } }, JsonOpts);
        }

        public static string BuildArticleGraphLdJson(
            string headline,
            string description,
            string canonicalUrl,
            DateTime datePublished,
            DateTime? dateModified = null,
            string articleType = "TechArticle",
            IReadOnlyList<(string Question, string Answer)>? faqs = null,
            string? authorSlug = null,
            string? reviewerSlug = null,
            DateTime? dateReviewed = null,
            IReadOnlyList<ratpdf.Models.ContentSource>? sources = null,
            IReadOnlyList<string>? howToSteps = null)
        {
            var modified = dateModified ?? dateReviewed ?? datePublished;
            var author = SiteAuthors.Get(authorSlug);
            var reviewer = SiteAuthors.Get(reviewerSlug);

            var article = new Dictionary<string, object>
            {
                ["@type"] = articleType,
                ["@id"] = $"{canonicalUrl}#article",
                ["headline"] = headline,
                ["description"] = description,
                ["datePublished"] = datePublished.ToString("yyyy-MM-dd"),
                ["dateModified"] = modified.ToString("yyyy-MM-dd"),
                ["author"] = author != null
                    ? new Dictionary<string, object>
                    {
                        ["@type"] = "Person",
                        ["@id"] = SiteAuthors.PersonId(author.Slug),
                        ["name"] = author.Name,
                        ["url"] = SiteAuthors.ProfileUrl(author.Slug),
                    }
                    : new Dictionary<string, object>
                    {
                        ["@type"] = "Organization",
                        ["@id"] = SiteEntity.OrganizationId,
                        ["name"] = SiteEntity.Name,
                    },
                ["publisher"] = new
                {
                    @type = "Organization",
                    @id = SiteEntity.OrganizationId,
                    name = SiteEntity.Name,
                    logo = new { @type = "ImageObject", url = SiteEntity.LogoUrl },
                },
                ["mainEntityOfPage"] = new { @type = "WebPage", @id = $"{canonicalUrl}#webpage" },
                ["image"] = SiteEntity.LogoUrl,
                ["inLanguage"] = "en",
                ["about"] = SiteEntity.KnowsAbout.Take(5).Select(k => new { @type = "Thing", name = k }).ToList(),
                ["speakable"] = new
                {
                    @type = "SpeakableSpecification",
                    cssSelector = new[] { ".rp-ai-summary", ".rp-article-lead", "h1" },
                },
            };

            if (reviewer != null)
            {
                article["reviewedBy"] = new Dictionary<string, object>
                {
                    ["@type"] = "Person",
                    ["@id"] = SiteAuthors.PersonId(reviewer.Slug),
                    ["name"] = reviewer.Name,
                    ["url"] = SiteAuthors.ProfileUrl(reviewer.Slug),
                };
            }

            if (dateReviewed.HasValue)
                article["lastReviewed"] = dateReviewed.Value.ToString("yyyy-MM-dd");

            if (sources is { Count: > 0 })
            {
                article["citation"] = sources.Select(s =>
                {
                    var cite = new Dictionary<string, object>
                    {
                        ["@type"] = "CreativeWork",
                        ["name"] = s.Title,
                        ["url"] = s.Url,
                    };
                    if (!string.IsNullOrEmpty(s.Publisher))
                        cite["publisher"] = new { @type = "Organization", name = s.Publisher };
                    return cite;
                }).ToList();
            }

            var graph = new List<object> { article };

            if (author != null)
                graph.Add(BuildPersonNode(author));
            if (reviewer != null && reviewer.Slug != author?.Slug)
                graph.Add(BuildPersonNode(reviewer));

            graph.Add(new Dictionary<string, object>
            {
                ["@type"] = "WebPage",
                ["@id"] = $"{canonicalUrl}#webpage",
                ["url"] = canonicalUrl,
                ["name"] = headline,
                ["description"] = description,
                ["isPartOf"] = new { @id = SiteEntity.WebsiteId },
                ["primaryImageOfPage"] = SiteEntity.LogoUrl,
            });

            if (faqs is { Count: > 0 })
            {
                graph.Add(new
                {
                    @type = "FAQPage",
                    mainEntity = faqs.Select(f => new
                    {
                        @type = "Question",
                        name = f.Question,
                        acceptedAnswer = new { @type = "Answer", text = f.Answer },
                    }).ToList(),
                });
            }

            if (howToSteps is { Count: > 0 })
            {
                graph.Add(new
                {
                    @type = "HowTo",
                    name = headline,
                    description,
                    totalTime = "PT5M",
                    step = howToSteps.Select((s, i) => new
                    {
                        @type = "HowToStep",
                        position = i + 1,
                        name = $"Step {i + 1}",
                        text = s,
                        url = $"{canonicalUrl}#step-{i + 1}",
                    }).ToList(),
                });
            }

            graph.Add(new
            {
                @type = "BreadcrumbList",
                itemListElement = new object[]
                {
                    new { @type = "ListItem", position = 1, name = "Home", item = SiteEntity.SiteUrl },
                    new { @type = "ListItem", position = 2, name = headline, item = canonicalUrl },
                },
            });

            return JsonSerializer.Serialize(new { @context = "https://schema.org", @graph = graph }, JsonOpts);
        }

        public static string BuildItemListLdJson(string name, IEnumerable<(string Name, string Url)> items)
        {
            var list = items.Select((item, i) => new
            {
                @type = "ListItem",
                position = i + 1,
                item = new
                {
                    @type = "SoftwareApplication",
                    name = item.Name,
                    url = item.Url,
                    applicationCategory = "UtilityApplication",
                    operatingSystem = "Web",
                    provider = new { @id = SiteEntity.OrganizationId },
                },
            }).ToList();

            return JsonSerializer.Serialize(new
            {
                @context = "https://schema.org",
                @type = "ItemList",
                name,
                numberOfItems = list.Count,
                itemListElement = list,
            }, JsonOpts);
        }
        public static string BuildFaqLdJson(List<ratpdf.Models.CompressPdfSeo.FaqItem> faqs)
        {
            var schema = new
            {
                @context = "https://schema.org",
                @type = "FAQPage",
                mainEntity = faqs.ConvertAll(f => new
                {
                    @type = "Question",
                    name = f.Question,
                    acceptedAnswer = new
                    {
                        @type = "Answer",
                        text = f.Answer
                    }
                })
            };
            return JsonSerializer.Serialize(schema);
        }

        public static string BuildRatingLdJson(AggregateRating rating, string productName, string canonicalUrl) =>
            BuildSoftwareApplicationLdJson(productName, canonicalUrl);

        public static string BuildSoftwareApplicationLdJson(
            string productName,
            string canonicalUrl,
            string? description = null,
            string applicationCategory = "UtilityApplication",
            string? image = null)
        {
            var schema = new Dictionary<string, object>
            {
                ["@context"] = "https://schema.org",
                ["@type"] = "SoftwareApplication",
                ["name"] = productName,
                ["applicationCategory"] = applicationCategory,
                ["operatingSystem"] = "Web",
                ["url"] = canonicalUrl,
                ["image"] = image ?? "https://ratpdf.com/images/ratpdf-logo.png",
            };
            if (!string.IsNullOrWhiteSpace(description))
                schema["description"] = description;
            return JsonSerializer.Serialize(schema);
        }
        public static string BuildBreadcrumbLdJson(List<BreadcrumbItem> breadcrumbs)
        {
            if (breadcrumbs == null || breadcrumbs.Count < 2) return null; // Breadcrumb needs at least home + current

            var items = breadcrumbs.Select((bc, index) => new
            {
                @type = "ListItem",
                position = index + 1,
                name = bc.Name,
                item = bc.Url
            }).ToList();

            var schema = new
            {
                @context = "https://schema.org",
                @type = "BreadcrumbList",
                itemListElement = items
            };
            return JsonSerializer.Serialize(schema);
        }

        public static string BuildOrganizationLdJson(Organization org)
        {
            if (org == null) return null;

            var schema = new
            {
                @context = "https://schema.org",
                @type = "Organization",
                name = org.Name,
                url = org.Url,
                logo = org.Logo,
                description = org.Description,
                email = org.Email,
                telephone = org.Telephone,
                sameAs = org.SameAs?.Split(',').Select(s => s.Trim()).ToList() ?? new List<string>()
            };
            return JsonSerializer.Serialize(schema);
        }

        public static string BuildWebSiteLdJson(WebSite site)
        {
            if (site == null) return null;

            var schema = new
            {
                @context = "https://schema.org",
                @type = "WebSite",
                name = site.Name,
                url = site.Url,
                potentialAction = !string.IsNullOrEmpty(site.PotentialActionQuery) ? new
                {
                    @type = "SearchAction",
                    target = $"{site.PotentialActionQuery}",
                    query_input = "required name='q'"
                } : null
            };
            return JsonSerializer.Serialize(schema, new JsonSerializerOptions { IgnoreNullValues = true });
        }

        public static string BuildHowToLdJson(string name, string description,
            IReadOnlyList<(string Name, string Text)> steps, string canonicalUrl)
        {
            if (steps == null || steps.Count == 0) return null;

            var schema = new
            {
                @context = "https://schema.org",
                @type = "HowTo",
                name,
                description,
                totalTime = "PT2M",
                tool = new[]
                {
                    new { @type = "HowToTool", name = "Web browser" }
                },
                step = steps.Select((s, i) => new
                {
                    @type = "HowToStep",
                    position = i + 1,
                    name = s.Name,
                    text = s.Text,
                    url = $"{canonicalUrl}#step-{i + 1}"
                }).ToList()
            };
            return JsonSerializer.Serialize(schema);
        }

        public static string BuildToolPageGraphLdJson(
            string toolName,
            string canonicalUrl,
            string description,
            IReadOnlyList<(string Name, string Text)> howToSteps,
            IReadOnlyList<(string Question, string Answer)> faqs)
        {
            var graph = new List<object>();

            var app = new Dictionary<string, object>
            {
                ["@type"] = "WebApplication",
                ["@id"] = $"{canonicalUrl}#software",
                ["name"] = toolName,
                ["applicationCategory"] = "UtilityApplication",
                ["operatingSystem"] = "Web",
                ["url"] = canonicalUrl,
                ["image"] = SiteEntity.LogoUrl,
                ["description"] = description,
                ["provider"] = new { @type = "Organization", @id = SiteEntity.OrganizationId },
                ["offers"] = new { @type = "Offer", price = "0", priceCurrency = "USD", availability = "https://schema.org/InStock" },
                ["isPartOf"] = new { @id = SiteEntity.WebsiteId },
            };
            graph.Add(app);

            if (howToSteps?.Count > 0)
            {
                graph.Add(new
                {
                    @type = "HowTo",
                    name = $"How to use {toolName}",
                    description,
                    totalTime = "PT2M",
                    step = howToSteps.Select((s, i) => new
                    {
                        @type = "HowToStep",
                        position = i + 1,
                        name = s.Name,
                        text = s.Text,
                    }).ToList(),
                });
            }

            if (faqs?.Count > 0)
            {
                graph.Add(new
                {
                    @type = "FAQPage",
                    mainEntity = faqs.Select(f => new
                    {
                        @type = "Question",
                        name = f.Question,
                        acceptedAnswer = new { @type = "Answer", text = f.Answer },
                    }).ToList(),
                });
            }

            graph.Add(new
            {
                @type = "WebPage",
                @id = $"{canonicalUrl}#webpage",
                name = toolName,
                description,
                url = canonicalUrl,
                isPartOf = new { @id = SiteEntity.WebsiteId },
                mainEntity = new { @id = $"{canonicalUrl}#software" },
                speakable = new
                {
                    @type = "SpeakableSpecification",
                    cssSelector = new[] { "h1", ".rp-ai-summary", ".text-muted" },
                },
            });

            graph.Add(new
            {
                @type = "BreadcrumbList",
                itemListElement = new object[]
                {
                    new { @type = "ListItem", position = 1, name = "Home", item = SiteEntity.SiteUrl },
                    new { @type = "ListItem", position = 2, name = "PDF Tools", item = $"{SiteEntity.SiteUrl}/guides/pdf-tools" },
                    new { @type = "ListItem", position = 3, name = toolName, item = canonicalUrl },
                },
            });

            return JsonSerializer.Serialize(new { @context = "https://schema.org", @graph = graph });
        }
    }
}

