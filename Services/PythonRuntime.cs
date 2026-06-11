using Microsoft.Extensions.Configuration;

namespace ratpdf.Services
{
    /// <summary>
    /// Resolves the Python executable for Pdf-Engine scripts.
    /// Linux App Service images expose <c>python3</c>, not <c>python</c>.
    /// </summary>
    public static class PythonRuntime
    {
        public static string ResolveExecutable(IConfiguration? configuration = null)
        {
            var configured = configuration?["PdfToDocx:PythonExecutable"];

            if (!string.IsNullOrWhiteSpace(configured))
            {
                // appsettings often ships "python" for Windows dev — map on Linux/Azure
                if (!OperatingSystem.IsWindows()
                    && configured.Equals("python", StringComparison.OrdinalIgnoreCase))
                {
                    return "python3";
                }

                return configured;
            }

            return OperatingSystem.IsWindows() ? "python" : "python3";
        }

        public static string GetEngineDirectory(IWebHostEnvironment env)
            => Path.Combine(env.ContentRootPath, "Pdf-Engine");
    }
}
