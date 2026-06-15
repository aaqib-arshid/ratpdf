using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using ratpdf.Data.AppDBContext;
using ratpdf.Data.Entities;
using ratpdf.Middleware;
using ratpdf.Models.CompressPdfSeo;
using ratpdf.Constants;
using ratpdf.Routing;
using ratpdf.Services;
using ratpdf.Services.CompressPDF;
using ratpdf.Services.HtmlSeo;
using ratpdf.Services.Invoice;
using ratpdf.Services.Invoice.Contract;
using ratpdf.Services.Invoice.Feature;
using ratpdf.Services.Invoice.Implementation;
using ratpdf.Services.JsonSeo;
using ratpdf.Services.JwtSeo;
using ratpdf.Services.PaySlip;
using ratpdf.Services.PayslipSeo;
using ratpdf.Services.RentReceipt;
using ratpdf.Services.Seo;
using System.Threading.RateLimiting;

public partial class Program
{
    private static void Main(string[] args)
    {
        if (args.Contains("--generate-compress-sitemap", StringComparer.OrdinalIgnoreCase))
        {
            var webRoot = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            var result = CompressPdfSitemapFileGenerator.Generate(webRoot);
            RobotsTxtBuilder.WriteToWwwRoot(webRoot);
            Console.WriteLine($"Generated {result.UrlCount} URLs in {result.ChunkCount} chunk(s).");
            Console.WriteLine($"Index: {result.IndexPath}");
            Console.WriteLine($"Robots: {Path.Combine(webRoot, "robots.txt")}");
            foreach (var chunk in result.ChunkFileNames)
                Console.WriteLine($"  - wwwroot/sitemaps/{chunk}");
            return;
        }

        if (args.Contains("--fix-seo-head", StringComparer.OrdinalIgnoreCase))
        {
            var root = Directory.GetCurrentDirectory();
            var viewsRoot = Path.Combine(root, "Views");
            var webRoot = Path.Combine(root, "wwwroot");
            Console.WriteLine("Fixing invoice duplicate head tags...");
            Console.WriteLine($"  {InvoiceSeoHeadFixer.FixInvoiceViews(viewsRoot)} invoice views updated.");
            Console.WriteLine("Fixing PDF tool H1 headings...");
            Console.WriteLine($"  {InvoiceSeoHeadFixer.FixPdfToolH1(viewsRoot)} PDF views updated.");
            Console.WriteLine("Fixing static sitemap URL casing...");
            Console.WriteLine($"  {InvoiceSeoHeadFixer.FixStaticSitemapCasing(webRoot)} sitemap files updated.");
            Console.WriteLine("Removing fabricated aggregateRating schema...");
            Console.WriteLine($"  {InvoiceSeoHeadFixer.RemoveFabricatedAggregateRatings(viewsRoot)} views updated.");
            Console.WriteLine("Fixing invoice hero images...");
            Console.WriteLine($"  {InvoiceSeoHeadFixer.FixInvoiceHeroImages(viewsRoot)} invoice views updated.");
            return;
        }

        if (args.Contains("--generate-vertical-sitemaps", StringComparer.OrdinalIgnoreCase))
        {
            var root = Directory.GetCurrentDirectory();
            Console.WriteLine("Generating full vertical sitemaps...");
            var result = VerticalSitemapFileGenerator.Generate(root, Path.Combine(root, "wwwroot"));
            var total = result.Files.Sum(f => f.Count);
            Console.WriteLine($"Done — {result.Files.Count} files, {total} total URLs.");
            return;
        }

        if (args.Contains("--generate-og-images", StringComparer.OrdinalIgnoreCase))
        {
            var webRoot = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            var result = OgImageGenerator.GenerateAll(webRoot);
            Console.WriteLine($"Generated {result.Count} OG PNG images in {result.OutputDirectory}");
            foreach (var file in result.Files)
                Console.WriteLine($"  - {file}");
            return;
        }

        if (args.Contains("--generate-tool-videos", StringComparer.OrdinalIgnoreCase))
        {
            var root = Directory.GetCurrentDirectory();
            var webRoot = Path.Combine(root, "wwwroot");
            var force = args.Contains("--force", StringComparer.OrdinalIgnoreCase);
            int? limit = null;
            var limitArg = args.FirstOrDefault(a => a.StartsWith("--limit=", StringComparison.OrdinalIgnoreCase));
            if (limitArg != null && int.TryParse(limitArg["--limit=".Length..], out var n))
                limit = n;
            Environment.ExitCode = ToolVideoGenerationCli.Run(root, webRoot, force, limit);
            return;
        }

        if (args.Contains("--capture-tool-screenshots", StringComparer.OrdinalIgnoreCase))
        {
            var root = Directory.GetCurrentDirectory();
            var webRoot = Path.Combine(root, "wwwroot");
            var baseUrl = args.FirstOrDefault(a => a.StartsWith("--base-url=", StringComparison.OrdinalIgnoreCase))
                ?.Split('=', 2)[1] ?? "http://localhost:5041";
            int? limit = null;
            var limitArg = args.FirstOrDefault(a => a.StartsWith("--limit=", StringComparison.OrdinalIgnoreCase));
            if (limitArg != null && int.TryParse(limitArg["--limit=".Length..], out var n))
                limit = n;
            var only = args.FirstOrDefault(a => a.StartsWith("--only=", StringComparison.OrdinalIgnoreCase))
                ?.Split('=', 2)[1];
            Environment.ExitCode = ToolVideoGenerationCli.CaptureScreenshots(root, webRoot, baseUrl, limit, only);
            return;
        }

        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddHostedService<PythonBootstrapHostedService>();
        builder.Services.AddControllersWithViews();
        builder.Services.Configure<RouteOptions>(options =>
        {
            options.LowercaseUrls = true;
            options.LowercaseQueryStrings = false;
            options.ConstraintMap.Add("compressSeo", typeof(CompressSeoSlugConstraint));
        });

        builder.Services.AddResponseCompression(options =>
        {
            options.EnableForHttps = true;
            options.Providers.Add<BrotliCompressionProvider>();
            options.Providers.Add<GzipCompressionProvider>();
            options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                ["application/xml", "text/xml", "image/svg+xml"]);
        });
        builder.Services.Configure<BrotliCompressionProviderOptions>(o => o.Level = System.IO.Compression.CompressionLevel.Fastest);
        builder.Services.Configure<GzipCompressionProviderOptions>(o => o.Level = System.IO.Compression.CompressionLevel.Fastest);

        builder.Services.AddResponseCaching();
        builder.Services.AddOutputCache(options =>
        {
            options.AddBasePolicy(b => b.NoCache());
            options.AddPolicy("SeoLanding", b => b.Expire(TimeSpan.FromHours(24)).Tag("seo"));
            options.AddPolicy("Sitemap", b => b.Expire(TimeSpan.FromHours(1)).Tag("sitemap"));
        });

        builder.Services.AddDistributedMemoryCache();
        builder.Services.AddMemoryCache();

        builder.Services.AddHttpClient();
        builder.Services.AddRateLimiter(options =>
        {
            options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(httpContext =>
            {
                var path = httpContext.Request.Path.Value ?? "";
                if (path.StartsWith("/sitemap", StringComparison.OrdinalIgnoreCase)
                    || path.StartsWith("/sitemaps/", StringComparison.OrdinalIgnoreCase)
                    || path.Equals("/robots.txt", StringComparison.OrdinalIgnoreCase))
                {
                    return RateLimitPartition.GetNoLimiter("seo-crawl");
                }

                var ua = httpContext.Request.Headers.UserAgent.ToString();
                if (IsSearchCrawler(ua))
                {
                    return RateLimitPartition.GetFixedWindowLimiter($"crawler:{ua}", _ => new FixedWindowRateLimiterOptions
                    {
                        PermitLimit = 500,
                        Window = TimeSpan.FromSeconds(10),
                        QueueProcessingOrder = QueueProcessingOrder.OldestFirst,
                        QueueLimit = 50
                    });
                }

                var ip = httpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";
                return RateLimitPartition.GetFixedWindowLimiter(ip, _ => new FixedWindowRateLimiterOptions
                {
                    PermitLimit = 50,
                    Window = TimeSpan.FromSeconds(10),
                    QueueProcessingOrder = QueueProcessingOrder.OldestFirst,
                    QueueLimit = 0
                });
            });
            options.OnRejected = async (context, cancellationToken) =>
            {
                context.HttpContext.Response.StatusCode = StatusCodes.Status429TooManyRequests;
                context.HttpContext.Response.Headers.RetryAfter = "60";
                await context.HttpContext.Response.WriteAsync("Too Many Requests", cancellationToken);
            };
        });
        builder.Services.AddScoped<PdfConversionService>();
        builder.Services.AddScoped<PdfToDocxProcessor>();
        builder.Services.AddScoped<PdfToDocxJobService>();
        builder.Services.AddScoped<PdfOfficeProcessor>();
        builder.Services.AddScoped<PdfOfficeJobService>();
        builder.Services.AddScoped<PdfTextProcessor>();
        builder.Services.AddScoped<ratpdf.Services.PdfTools.PdfToolsAccessService>();
        builder.Services.AddSingleton<IPdfEditSessionStore, PdfEditSessionStore>();
        builder.Services.AddHostedService<PdfEditSessionCleanupHostedService>();
        builder.Services.AddScoped<PdfEditProcessor>();
        builder.Services.AddScoped<PdfEditExportJobService>();
        builder.Services.AddScoped<LayoutEngineProcessor>();
        builder.Services.AddScoped<HtmlReconstructionService>();
        builder.Services.AddSingleton<PayslipPdfService>();
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddSingleton<IAllowedSlugsService, AllowedSlugsService>();
        builder.Services.AddScoped<IContentGenerator, ContentGenerator>();
        builder.Services.AddScoped<ISchemaGenerator, SchemaGenerator>();
        builder.Services.AddScoped<ICacheService, CacheService>();
        builder.Services.AddSingleton<IHtmlAllowedSlugsService, HtmlAllowedSlugsService>();
        builder.Services.AddScoped<IHtmlContentGenerator, HtmlContentGenerator>();
        builder.Services.AddSingleton<IJsonAllowedSlugsService, JsonAllowedSlugsService>();
        builder.Services.AddScoped<IJsonContentGenerator, JsonContentGenerator>();
        builder.Services.AddScoped<IPayslipAllowedSlugsService, PayslipAllowedSlugsService>();
        builder.Services.AddScoped<IPayslipContentGenerator, PayslipContentGenerator>();
        builder.Services.AddSingleton<AzureBlobService>();
        builder.Services.Configure<ratpdf.Services.PdfProcessing.PdfProcessingOptions>(
            builder.Configuration.GetSection(ratpdf.Services.PdfProcessing.PdfProcessingOptions.SectionName));
        builder.Services.AddSingleton<ratpdf.Services.PdfProcessing.PdfJobStorageService>();
        builder.Services.AddSingleton<IJobQueue, JobQueue>();
        builder.Services.AddSingleton<IJobResultStore, PersistingJobResultStore>();
        builder.Services.AddScoped<PdfPythonToolProcessor>();
        builder.Services.AddScoped<PdfExtendedToolJobService>();
        builder.Services.AddHostedService<BackgroundJobProcessor>();
        //builder.Services.Configure<FormOptions>(options =>
        //{
        //    options.MultipartBodyLengthLimit = 50 * 1024 * 1024; // 50MB
        //});
        const long maxUploadBytes = ratpdf.Constants.PdfToolLimits.MaxPremiumFileSizeBytes
            * ratpdf.Constants.PdfToolLimits.MaxBatchFiles;

        builder.Services.Configure<FormOptions>(o =>
        {
            o.MultipartBodyLengthLimit = maxUploadBytes;
        });

        builder.WebHost.ConfigureKestrel(k =>
        {
            k.Limits.MaxRequestBodySize = maxUploadBytes;
            k.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(60);
            k.Limits.RequestHeadersTimeout = TimeSpan.FromMinutes(60);
        });
        builder.Services.AddSession();
        builder.Services.AddSingleton<SitemapCacheService>();
        builder.Services.AddSingleton<CachedPdfCompressSeoService>();
        builder.Services.AddSingleton<NavigationMetadataService>();
        builder.Services.Configure<SeoIndexingOptions>(builder.Configuration.GetSection(SeoIndexingOptions.SectionName));
        builder.Services.AddSingleton<IndexNowSubmissionService>();
        builder.Services.AddHostedService<SeoIndexingHostedService>();

        builder.Services.AddHttpClient<RemoteEmbeddingService>(client =>
        {
            client.BaseAddress = new Uri("https://ai-embed-app.jollyisland-ab3b4974.canadacentral.azurecontainerapps.io/");
        });
        builder.Services.AddDbContextPool<RatPDFDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            options.EnableSensitiveDataLogging(builder.Environment.IsDevelopment());
            options.LogTo(
                Console.WriteLine,
                new[] { DbLoggerCategory.Database.Command.Name },
                LogLevel.Warning);
        });
        builder.Services.AddIdentity<User, IdentityRole<Guid>>(options =>
        {
            options.SignIn.RequireConfirmedAccount = false;
            options.Password.RequireDigit = true;
            options.Password.RequiredLength = 8;
            options.Password.RequireNonAlphanumeric = false;
            options.User.RequireUniqueEmail = true;
        })
            .AddEntityFrameworkStores<RatPDFDbContext>()
            .AddDefaultTokenProviders();
        builder.Services.AddScoped<AtsEngine>();
        builder.Services.AddSingleton<SearchConsoleService>();
        builder.Services.AddSingleton<DecayCalculatorService>();
        builder.Services.AddSingleton<GoogleOAuthService>();
        builder.Services.AddScoped<InvoicePdfService>();
        builder.Services.AddScoped<BrandingService>();
        builder.Services.AddSingleton<RentReceiptPdfService>();
        builder.Services.AddScoped<SubscriptionManager>();
        builder.Services.AddScoped<RazorpayService>();
        builder.Services.AddScoped<UsageTracker>();
        builder.Services.AddScoped<TemplateService>();
        builder.Services.AddScoped<FeatureAccessor>();
        builder.Services.AddSingleton<Organization>();
        builder.Services.AddScoped<ILogoStorageService, AzureLogoStorageService>();
        builder.Services.AddScoped<PdfCompressionService>();
        builder.Services.AddScoped<PdfConversionFileOps>();
        builder.Services.AddScoped<PdfItextToolJobService>();
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
        })
        .AddCookie()
        .AddGoogle(options =>
        {
            options.ClientId = builder.Configuration["GoogleOAuth:ClientId"];
            options.ClientSecret = builder.Configuration["GoogleOAuth:ClientSecret"];

            options.Scope.Add("https://www.googleapis.com/auth/webmasters.readonly");
            options.Scope.Add("openid");
            options.Scope.Add("profile");
            options.Scope.Add("email");

            options.SaveTokens = true;
        });
        builder.Logging.ClearProviders();
        builder.Logging.AddConsole();
        builder.Logging.AddDebug();
        var app = builder.Build();

        PdfCompressProgrammaticSeoGenerator.Initialize(
            app.Services.GetRequiredService<IWebHostEnvironment>().WebRootPath);

        {
            var logger = app.Services.GetRequiredService<ILoggerFactory>().CreateLogger("PythonRuntime");
            var config = app.Services.GetRequiredService<IConfiguration>();
            var env = app.Services.GetRequiredService<IWebHostEnvironment>();
            var python = PythonRuntime.ResolveExecutable(config, env);
            var engineDir = PythonRuntime.GetEngineDirectory(env);
            var requirements = Path.Combine(engineDir, "requirements.txt");
            var pythonVersion = PythonRuntime.ProbeVersion(python);
            var hasFitz = PythonRuntime.ProbeImport(python, "fitz");
            logger.LogInformation(
                "Pdf-Engine: dir={EngineDir} exists={DirExists}, requirements={ReqExists}, python={Python}, version={Version}, fitz={HasFitz}",
                engineDir, Directory.Exists(engineDir), File.Exists(requirements), python, pythonVersion ?? "NOT FOUND", hasFitz);

            if (pythonVersion == null || !hasFitz)
                logger.LogWarning(
                    "Python missing or PyMuPDF not installed for {Python}. On SSH run: /usr/bin/python3 -m pip install --break-system-packages PyMuPDF pytesseract && echo /usr/bin/python3 > /home/site/.python-executable",
                    python);
        }

        // In Program.cs, after app.Build()
        //var cleanupTimer = new Timer(_ =>
        //{
        //    using var scope = app.Services.CreateScope();
        //    var store = scope.ServiceProvider.GetRequiredService<IJobResultStore>();
        //    store.CleanupOldJobs(TimeSpan.FromHours(1));
        //}, null, TimeSpan.FromMinutes(30), TimeSpan.FromMinutes(30));
        app.UseRateLimiter();
        //if (!app.Environment.IsDevelopment())
        //{
        app.UseExceptionHandler("/Home/Error");

        if (!app.Environment.IsDevelopment())
            app.UseHsts();

        app.Use(async (context, next) =>
        {
            if (context.Request.ContentLength.HasValue)
            {
                const long maxBytes = ratpdf.Constants.PdfToolLimits.MaxUploadRequestBytes;
                if (context.Request.ContentLength.Value > maxBytes)
                {
                    context.Response.StatusCode = StatusCodes.Status413PayloadTooLarge;
                    context.Response.ContentType = "text/html";
                    await context.Response.WriteAsync(
                        "<html><body style='font-family:Arial;text-align:center;margin-top:50px;'>" +
                        "<h1>File Too Large</h1><p>The uploaded file exceeds the maximum allowed size.</p>" +
                        "<a href='/'>Go back</a></body></html>");
                    return;
                }
            }
            await next();
        });

        app.UseResponseCompression();
        app.UseHttpsRedirection();

        app.UseStaticFiles(new StaticFileOptions
        {
            OnPrepareResponse = ctx =>
            {
                var path = ctx.Context.Request.Path.Value ?? "";
                if (path.EndsWith("-keywords.txt", StringComparison.OrdinalIgnoreCase))
                {
                    ctx.Context.Response.StatusCode = StatusCodes.Status404NotFound;
                    ctx.Context.Response.ContentLength = 0;
                    return;
                }

                if (path.StartsWith("/lib/", StringComparison.OrdinalIgnoreCase)
                    || path.StartsWith("/css/", StringComparison.OrdinalIgnoreCase)
                    || path.EndsWith(".js", StringComparison.OrdinalIgnoreCase)
                    || path.EndsWith(".woff2", StringComparison.OrdinalIgnoreCase))
                {
                    ctx.Context.Response.Headers.CacheControl = "public,max-age=31536000,immutable";
                }
                else if (path.StartsWith("/images/", StringComparison.OrdinalIgnoreCase))
                {
                    ctx.Context.Response.Headers.CacheControl = "public,max-age=604800";
                }
            }
        });

        app.UseMiddleware<SeoUrlNormalizationMiddleware>();
        app.UseRouting();
        app.UseResponseCaching();
        app.UseOutputCache();
        app.UseSession();
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapStaticAssets();
        app.MapControllerRoute(
            name: "bulk_invoice",
            pattern: "invoice/bulk",
            defaults: new { controller = "BulkInvoice", action = "Index" });

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }

    private static bool IsSearchCrawler(string userAgent)
    {
        if (string.IsNullOrWhiteSpace(userAgent)) return false;
        return userAgent.Contains("Googlebot", StringComparison.OrdinalIgnoreCase)
            || userAgent.Contains("bingbot", StringComparison.OrdinalIgnoreCase)
            || userAgent.Contains("Slurp", StringComparison.OrdinalIgnoreCase)
            || userAgent.Contains("DuckDuckBot", StringComparison.OrdinalIgnoreCase)
            || userAgent.Contains("Baiduspider", StringComparison.OrdinalIgnoreCase)
            || userAgent.Contains("YandexBot", StringComparison.OrdinalIgnoreCase);
    }
}