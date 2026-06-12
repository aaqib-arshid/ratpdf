using System.Diagnostics;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ratpdf.Services
{
    public class LayoutEngineProcessor
    {
        private readonly string _pythonScriptPath;
        private readonly string _pythonExecutable;
        private readonly ILogger<LayoutEngineProcessor> _logger;

        public LayoutEngineProcessor(
            ILogger<LayoutEngineProcessor> logger,
            IWebHostEnvironment env,
            IConfiguration configuration,
            string? pythonScriptPath = null,
            string? pythonExecutable = null)
        {
            _logger = logger;
            _pythonScriptPath = pythonScriptPath
                ?? Path.Combine(env.ContentRootPath, "Pdf-Engine", "pdf-reconstruction-engine.py");
            _pythonExecutable = pythonExecutable ?? PythonRuntime.ResolveExecutable(configuration, env);
        }

        /// <summary>
        /// Processes a PDF stream and returns the layout JSON as a string.
        /// </summary>
        /// <param name="pdfStream">The PDF file stream (will be read from the beginning).</param>
        /// <returns>The full JSON output from the Python reconstruction engine.</returns>
        public async Task<string> ExtractLayoutJsonAsync(Stream pdfStream)
        {
            if (pdfStream == null || pdfStream.Length == 0)
                throw new ArgumentException("PDF stream is empty or null.");

            if (!System.IO.File.Exists(_pythonScriptPath))
                throw new FileNotFoundException($"Python script not found at {_pythonScriptPath}");

            string tempPdfPath = null;
            try
            {
                // Save stream to temporary file
                tempPdfPath = Path.GetTempFileName() + ".pdf";
                pdfStream.Position = 0; // ensure we read from the start
                await using (var fileStream = new FileStream(tempPdfPath, FileMode.Create, FileAccess.Write))
                {
                    await pdfStream.CopyToAsync(fileStream);
                }

                var processStartInfo = PythonRuntime.CreateStartInfo(
                    _pythonExecutable,
                    $"\"{_pythonScriptPath}\" \"{tempPdfPath}\"",
                    Path.GetDirectoryName(_pythonScriptPath));

                using var process = Process.Start(processStartInfo);
                if (process == null)
                    throw new InvalidOperationException("Failed to start Python process.");

                string jsonOutput = await process.StandardOutput.ReadToEndAsync();
                string errorOutput = await process.StandardError.ReadToEndAsync();
                await process.WaitForExitAsync();

                if (process.ExitCode != 0)
                {
                    _logger?.LogError("Python script exited with code {ExitCode}: {Error}", process.ExitCode, errorOutput);
                    throw new InvalidOperationException($"Layout extraction failed: {errorOutput}");
                }

                // Optionally validate JSON (already done by script, but safe here)
                var doc = JsonDocument.Parse(jsonOutput);
                return doc.RootElement.GetRawText();
            }
            finally
            {
                // Clean up temp file
                if (tempPdfPath != null && System.IO.File.Exists(tempPdfPath))
                {
                    try { System.IO.File.Delete(tempPdfPath); } catch { /* best effort */ }
                }
            }
        }
    }
}