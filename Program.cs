using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ratpdf.Data.AppDBContext;
using ratpdf.Data.Entities;
using ratpdf.Models.CompressPdfSeo;
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
using System.Threading.RateLimiting;

public partial class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


        builder.Services.AddControllersWithViews();
        builder.Services.AddHttpClient();
        builder.Services.AddRateLimiter(options =>
        {
            options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(httpContext =>
            {
                var ip = httpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";

                return RateLimitPartition.GetFixedWindowLimiter(ip, _ => new FixedWindowRateLimiterOptions
                {
                    PermitLimit = 50,
                    Window = TimeSpan.FromSeconds(10),
                    QueueProcessingOrder = QueueProcessingOrder.OldestFirst,
                    QueueLimit = 0
                });
            });
            options.OnRejected = (context, cancellationToken) =>
            {
                context.HttpContext.Response.Redirect("/Error/TooManyRequests");
                return ValueTask.CompletedTask;
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
        builder.Services.AddScoped<PdfEditProcessor>();
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
        builder.Services.AddSingleton<IJobQueue, JobQueue>();
        builder.Services.AddSingleton<IJobResultStore, JobResultStore>();
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
        builder.Services.AddMemoryCache();

        builder.Services.AddHttpClient<RemoteEmbeddingService>(client =>
        {
            client.BaseAddress = new Uri("https://ai-embed-app.jollyisland-ab3b4974.canadacentral.azurecontainerapps.io/");
        });
        builder.Services.AddDbContext<RatPDFDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
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

        {
            var logger = app.Services.GetRequiredService<ILoggerFactory>().CreateLogger("PythonRuntime");
            var config = app.Services.GetRequiredService<IConfiguration>();
            var env = app.Services.GetRequiredService<IWebHostEnvironment>();
            var python = PythonRuntime.ResolveExecutable(config);
            var engineDir = PythonRuntime.GetEngineDirectory(env);
            var requirements = Path.Combine(engineDir, "requirements.txt");
            logger.LogInformation(
                "Pdf-Engine: dir={EngineDir} exists={DirExists}, requirements={ReqExists}, python={Python}",
                engineDir, Directory.Exists(engineDir), File.Exists(requirements), python);
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

        app.UseHsts();
        //}

        app.Use(async (context, next) =>
        {
            if (context.Request.ContentLength.HasValue)
            {
                const long maxBytes = ratpdf.Constants.PdfToolLimits.MaxUploadRequestBytes;

                if (context.Request.ContentLength.Value > maxBytes)
                {
                    context.Response.StatusCode = StatusCodes.Status413PayloadTooLarge;
                    context.Response.ContentType = "text/html";

                    await context.Response.WriteAsync(@"
                <html>
                    <body style='font-family:Arial; text-align:center; margin-top:50px;'>
                        <h1>File Too Large</h1>
                        <p>The uploaded file exceeds the maximum allowed size.</p>
                        <a href='/'>Go back</a>
                    </body>
                </html>
            ");
                    return;
                }
            }
            await next();
        });
        app.UseStaticFiles();
        app.UseHttpsRedirection();
        app.UseRouting();
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
}