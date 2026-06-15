using System.Diagnostics;
using Microsoft.Extensions.Configuration;
using ratpdf.Constants;

namespace ratpdf.Services
{
    /// <summary>Runs free local video generation (edge-tts + ffmpeg) — no paid API keys.</summary>
    public sealed class FreeToolVideoGenerator
    {
        private readonly string _python;
        private readonly string _engineDir;
        private readonly string _webRoot;
        private readonly string _contentRoot;

        public FreeToolVideoGenerator(IConfiguration config, IWebHostEnvironment env)
        {
            _python = PythonRuntime.ResolveExecutable(config, env);
            _engineDir = PythonRuntime.GetEngineDirectory(env);
            _webRoot = env.WebRootPath;
            _contentRoot = env.ContentRootPath;
        }

        public FreeToolVideoGenerator(string python, string engineDir, string webRoot, string contentRoot)
        {
            _python = python;
            _engineDir = engineDir;
            _webRoot = webRoot;
            _contentRoot = contentRoot;
        }

        public int GenerateAll(IEnumerable<ToolHowToVideo>? only = null, bool force = false, int? limit = null)
        {
            EnsureDependencies();

            var buildManifest = Path.Combine(_engineDir, "build_tools_manifest.py");
            if (File.Exists(buildManifest))
            {
                var buildPsi = PythonRuntime.CreateStartInfo(_python, $"\"{buildManifest}\"", _engineDir);
                buildPsi.RedirectStandardOutput = true;
                using var buildProc = Process.Start(buildPsi);
                buildProc?.WaitForExit();
            }

            var manifestPath = Path.Combine(_engineDir, "tools-manifest.json");
            if (!File.Exists(manifestPath))
                throw new FileNotFoundException("Run build_tools_manifest.py first.", manifestPath);

            var script = Path.Combine(_engineDir, "generate_tool_videos.py");
            if (!File.Exists(script))
                throw new FileNotFoundException("Video generator script not found.", script);

            var args = $"\"{script}\" --web-root \"{_webRoot}\" --manifest \"{manifestPath}\"";
            if (force) args += " --force";
            if (limit is > 0) args += $" --limit {limit.Value}";

            var psi = PythonRuntime.CreateStartInfo(_python, args, _engineDir);
            psi.RedirectStandardOutput = false;
            psi.RedirectStandardError = false;

            using var process = Process.Start(psi)
                ?? throw new InvalidOperationException("Failed to start Python video generator.");

            process.WaitForExit();
            return process.ExitCode;
        }

        /// <summary>Capture tool page screenshots via Playwright (dev server must be running).</summary>
        public int CaptureScreenshots(string baseUrl = "http://localhost:5041", int? limit = null, string? only = null)
        {
            EnsureDependencies();

            if (!PythonRuntime.ProbeImport(_python, "playwright"))
            {
                Console.WriteLine("Installing playwright…");
                RunPipInstall("playwright");
                var installPsi = PythonRuntime.CreateStartInfo(_python, "-m playwright install chromium", _engineDir);
                using var installProc = Process.Start(installPsi) ?? throw new InvalidOperationException("playwright install failed to start.");
                installProc.WaitForExit();
            }

            var buildManifest = Path.Combine(_engineDir, "build_tools_manifest.py");
            if (File.Exists(buildManifest))
            {
                var buildPsi = PythonRuntime.CreateStartInfo(_python, $"\"{buildManifest}\"", _engineDir);
                buildPsi.RedirectStandardOutput = true;
                using var buildProc = Process.Start(buildPsi);
                buildProc?.WaitForExit();
            }

            var manifestPath = Path.Combine(_engineDir, "tools-manifest.json");
            var script = Path.Combine(_engineDir, "capture_tool_screenshots.py");
            if (!File.Exists(script))
                throw new FileNotFoundException("Screenshot capture script not found.", script);

            var args = $"\"{script}\" --web-root \"{_webRoot}\" --manifest \"{manifestPath}\" --base-url \"{baseUrl}\"";
            if (limit is > 0) args += $" --limit {limit.Value}";
            if (!string.IsNullOrWhiteSpace(only)) args += $" --only \"{only}\"";

            var psi = PythonRuntime.CreateStartInfo(_python, args, _engineDir);
            using var process = Process.Start(psi) ?? throw new InvalidOperationException("Failed to start screenshot capture.");
            process.WaitForExit();
            return process.ExitCode;
        }

        private void EnsureDependencies()
        {
            PythonRuntime.EnsureAvailable(_python);

            if (!PythonRuntime.ProbeImport(_python, "edge_tts"))
            {
                Console.WriteLine("Installing edge-tts (free TTS, no API key)…");
                RunPipInstall("edge-tts");
            }

            if (FindFfmpeg() == null && !PythonRuntime.ProbeImport(_python, "imageio_ffmpeg"))
            {
                Console.WriteLine("Installing imageio-ffmpeg (bundled ffmpeg)…");
                RunPipInstall("imageio-ffmpeg");
            }

            if (FindFfmpeg() == null && !PythonRuntime.ProbeImport(_python, "imageio_ffmpeg"))
                throw new InvalidOperationException(
                    "ffmpeg is required. Install ffmpeg or allow pip install imageio-ffmpeg.");
        }

        private void RunPipInstall(string package)
        {
            var psi = PythonRuntime.CreateStartInfo(_python, $"-m pip install {package}", _engineDir);
            using var process = Process.Start(psi) ?? throw new InvalidOperationException("pip failed to start.");
            process.WaitForExit();
            if (process.ExitCode != 0)
                throw new InvalidOperationException($"pip install {package} failed.");
        }

        public static string? FindFfmpeg()
        {
            foreach (var name in new[] { "ffmpeg", "ffmpeg.exe" })
            {
                var path = RunWhich(name);
                if (path != null) return path;
            }
            return null;
        }

        private static string? RunWhich(string name)
        {
            try
            {
                var fileName = OperatingSystem.IsWindows() ? "where" : "which";
                using var process = Process.Start(new ProcessStartInfo
                {
                    FileName = fileName,
                    Arguments = name,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                });
                if (process == null) return null;
                var line = process.StandardOutput.ReadLine()?.Trim();
                process.WaitForExit(3000);
                return process.ExitCode == 0 && !string.IsNullOrWhiteSpace(line) ? line : null;
            }
            catch { return null; }
        }
    }
}
