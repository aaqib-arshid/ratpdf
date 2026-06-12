using System.Diagnostics;
using Microsoft.Extensions.Configuration;

namespace ratpdf.Services
{
    /// <summary>
    /// Resolves the Python executable for Pdf-Engine scripts.
    /// On Azure Linux, Python is installed by startup.sh (apt or Miniforge under /home/site).
    /// </summary>
    public static class PythonRuntime
    {
        private static string? _cached;

        private static readonly string[] LinuxMarkerFiles =
        [
            "/home/site/.python-executable",
        ];

        private static readonly string[] LinuxCandidates =
        [
            "/usr/bin/python3",
            "/usr/local/bin/python3",
            "/home/site/miniforge3/bin/python",
            "/opt/python/3/bin/python3",
            "/usr/bin/python",
        ];

        private static readonly string[] WindowsCandidates =
        [
            "python",
            "python3",
            "py",
        ];

        public static void ResetCache() => _cached = null;

        public static string ResolveExecutable(IConfiguration? configuration = null, IWebHostEnvironment? env = null)
        {
            if (_cached != null)
                return _cached;

            var candidates = CollectCandidates(configuration, env);
            if (!OperatingSystem.IsWindows())
            {
                // Prefer a Python that actually has PyMuPDF (fitz) — manual apt/pip often lands on /usr/bin/python3
                foreach (var candidate in candidates)
                {
                    if (TryValidate(candidate, out var path) && ProbeImport(path, "fitz"))
                        return Cache(path);
                }
            }

            foreach (var candidate in candidates)
            {
                if (TryValidate(candidate, out var resolved))
                    return Cache(resolved);
            }

            return Cache(OperatingSystem.IsWindows() ? "python" : "/usr/bin/python3");
        }

        private static List<string> CollectCandidates(IConfiguration? configuration, IWebHostEnvironment? env)
        {
            var list = new List<string>();
            var seen = new HashSet<string>(StringComparer.Ordinal);

            void TryAdd(string? value)
            {
                if (string.IsNullOrWhiteSpace(value))
                    return;
                var trimmed = value.Trim();
                if (seen.Add(trimmed))
                    list.Add(trimmed);
            }

            foreach (var markerFile in GetMarkerFiles(env))
            {
                if (File.Exists(markerFile))
                    TryAdd(File.ReadAllText(markerFile).Trim());
            }

            TryAdd(Environment.GetEnvironmentVariable("PdfToDocx__PythonExecutable"));
            TryAdd(configuration?["PdfToDocx:PythonExecutable"]);

            foreach (var candidate in GetCandidates())
                TryAdd(candidate);

            if (!OperatingSystem.IsWindows() && Directory.Exists("/opt/python"))
            {
                foreach (var dir in Directory.EnumerateDirectories("/opt/python"))
                    TryAdd(Path.Combine(dir, "bin", "python3"));
            }

            var which = RunWhich(OperatingSystem.IsWindows() ? "python" : "python3") ?? RunWhich("python");
            TryAdd(which);

            return list;
        }

        public static bool ProbeImport(string executable, string module)
        {
            if (!TryValidate(executable, out var path))
                return false;

            try
            {
                using var process = Process.Start(new ProcessStartInfo
                {
                    FileName = path,
                    Arguments = $"-c \"import {module}\"",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                });

                if (process == null)
                    return false;

                process.WaitForExit(8000);
                return process.ExitCode == 0;
            }
            catch
            {
                return false;
            }
        }

        public static string GetEngineDirectory(IWebHostEnvironment env)
            => Path.Combine(env.ContentRootPath, "Pdf-Engine");

        public static void EnsureAvailable(string executable)
        {
            if (TryValidate(executable, out _))
                return;

            var hint = PythonBootstrap.InstallInProgress
                ? "Python is still installing in the background — wait 3–5 minutes and try again."
                : "Restart the app once. Python installs automatically to /home/site/miniforge3 on first boot.";

            throw new InvalidOperationException(
                $"Python executable '{executable}' was not found or is not runnable. {hint}");
        }

        public static ProcessStartInfo CreateStartInfo(
            string executable,
            string arguments,
            string? workingDirectory = null)
        {
            EnsureAvailable(executable);

            var psi = new ProcessStartInfo
            {
                FileName = executable,
                Arguments = arguments,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
            };

            if (!string.IsNullOrEmpty(workingDirectory))
            {
                if (!Directory.Exists(workingDirectory))
                    throw new DirectoryNotFoundException($"Pdf-Engine working directory not found: {workingDirectory}");

                psi.WorkingDirectory = workingDirectory;
            }

            // dotnet child processes on Azure often miss /usr/bin in PATH
            var path = Environment.GetEnvironmentVariable("PATH") ?? "";
            var standardPaths = "/usr/local/sbin:/usr/local/bin:/usr/sbin:/usr/bin:/sbin:/bin";
            if (!path.Contains("/usr/bin", StringComparison.Ordinal))
                psi.Environment["PATH"] = standardPaths + ":" + path;

            foreach (var tess in new[] { "/usr/bin/tesseract", "/usr/local/bin/tesseract" })
            {
                if (File.Exists(tess))
                {
                    psi.Environment["TESSERACT_CMD"] = tess;
                    break;
                }
            }

            foreach (var lo in new[]
                     {
                         "/usr/bin/soffice",
                         "/usr/lib/libreoffice/program/soffice",
                         "/usr/bin/libreoffice",
                     })
            {
                if (File.Exists(lo))
                {
                    psi.Environment["LIBREOFFICE_PATH"] = lo;
                    break;
                }
            }

            return psi;
        }

        public static string? ProbeVersion(string executable)
        {
            if (!TryValidate(executable, out var path))
                return null;

            try
            {
                using var process = Process.Start(new ProcessStartInfo
                {
                    FileName = path,
                    Arguments = "--version",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                });

                if (process == null)
                    return null;

                var output = process.StandardOutput.ReadToEnd().Trim();
                if (string.IsNullOrEmpty(output))
                    output = process.StandardError.ReadToEnd().Trim();

                process.WaitForExit(5000);
                return string.IsNullOrWhiteSpace(output) ? null : output;
            }
            catch
            {
                return null;
            }
        }

        private static IEnumerable<string> GetMarkerFiles(IWebHostEnvironment? env)
        {
            if (env != null)
                yield return Path.Combine(env.ContentRootPath, ".python-executable");

            foreach (var marker in LinuxMarkerFiles)
                yield return marker;
        }

        private static IEnumerable<string> GetCandidates()
            => OperatingSystem.IsWindows() ? WindowsCandidates : LinuxCandidates;

        private static bool TryValidate(string? candidate, out string resolved)
        {
            resolved = candidate?.Trim() ?? "";

            if (string.IsNullOrEmpty(resolved))
                return false;

            if (Path.IsPathRooted(resolved))
                return File.Exists(resolved);

            var fromPath = RunWhich(resolved);
            if (fromPath != null && File.Exists(fromPath))
            {
                resolved = fromPath;
                return true;
            }

            return false;
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
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                });

                if (process == null)
                    return null;

                var output = process.StandardOutput.ReadLine()?.Trim();
                process.WaitForExit(3000);

                return process.ExitCode == 0 && !string.IsNullOrWhiteSpace(output) ? output : null;
            }
            catch
            {
                return null;
            }
        }

        private static string Cache(string path) => _cached = path;
    }
}
