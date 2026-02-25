using Microsoft.AspNetCore.Http.Features;
using ratpdf.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddScoped<PdfConversionService>();
builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 50 * 1024 * 1024; // 50MB
});
builder.WebHost.ConfigureKestrel(options =>
{
    options.Limits.MaxRequestBodySize = 50 * 1024 * 1024; // 50 MB
});
var app = builder.Build();

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
app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
