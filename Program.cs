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
        builder.Services.Configure<FormOptions>(options =>
        {
            options.MultipartBodyLengthLimit = 50 * 1024 * 1024; // 50MB
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
        builder.WebHost.ConfigureKestrel(options =>
        {
            options.Limits.MaxRequestBodySize = 50 * 1024 * 1024; // 50 MB
        });
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
        app.UseRateLimiter();
        //var browserService = app.Services.GetRequiredService<PuppeteerBrowserService>();
        //await browserService.InitializeAsync();
        //if (!app.Environment.IsDevelopment())
        //{
        app.UseExceptionHandler("/Home/Error");

        app.UseHsts();
        //}

        app.Use(async (context, next) =>
        {
            if (context.Request.ContentLength.HasValue)
            {
                const long maxBytes = 50L * 1024 * 1024; // 50 MB

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