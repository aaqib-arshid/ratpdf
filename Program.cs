using Microsoft.AspNetCore.Http.Features;
using ratpdf.Services;
using System.Threading.RateLimiting;

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
builder.Services.AddSingleton<ImageBackgroundAIRemovalService>();
builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 50 * 1024 * 1024; // 50MB
});
builder.WebHost.ConfigureKestrel(options =>
{
    options.Limits.MaxRequestBodySize = 50 * 1024 * 1024; // 50 MB
});
var app = builder.Build();
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

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
