using System.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ratpdf.Services
{
    /// <summary>
    /// Installs Python in the background so Azure health checks pass while Miniforge downloads.
    /// </summary>
    public static class PythonBootstrap
    {
        public static volatile bool InstallInProgress;
        public static volatile bool InstallCompleted;

        public static bool IsReady(IConfiguration configuration, IWebHostEnvironment env)
            => PythonRuntime.ProbeVersion(PythonRuntime.ResolveExecutable(configuration, env)) != null;
    }

    public sealed class PythonBootstrapHostedService : IHostedService
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;
        private readonly ILogger<PythonBootstrapHostedService> _logger;

        public PythonBootstrapHostedService(
            IWebHostEnvironment env,
            IConfiguration configuration,
            ILogger<PythonBootstrapHostedService> logger)
        {
            _env = env;
            _configuration = configuration;
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            if (OperatingSystem.IsWindows())
                return Task.CompletedTask;

            if (PythonBootstrap.IsReady(_configuration, _env))
            {
                PythonBootstrap.InstallCompleted = true;
                _logger.LogInformation("Python already available");
                return Task.CompletedTask;
            }

            _ = Task.Run(() => RunInstallAsync(cancellationToken), CancellationToken.None);
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;

        private async Task RunInstallAsync(CancellationToken cancellationToken)
        {
            var script = Path.Combine(_env.ContentRootPath, "install-python.sh");
            if (!File.Exists(script))
            {
                _logger.LogWarning("install-python.sh missing — PDF conversion unavailable");
                return;
            }

            PythonBootstrap.InstallInProgress = true;
            _logger.LogInformation("Python not found — installing in background (site stays up, allow 3–5 min)...");

            try
            {
                using var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "bash",
                        Arguments = $"\"{script}\"",
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        CreateNoWindow = true,
                    },
                };

                process.OutputDataReceived += (_, e) =>
                {
                    if (!string.IsNullOrEmpty(e.Data))
                        _logger.LogInformation("{Line}", e.Data);
                };
                process.ErrorDataReceived += (_, e) =>
                {
                    if (!string.IsNullOrEmpty(e.Data))
                        _logger.LogWarning("{Line}", e.Data);
                };

                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();

                await process.WaitForExitAsync(cancellationToken);

                PythonRuntime.ResetCache();

                var python = PythonRuntime.ResolveExecutable(_configuration, _env);
                var version = PythonRuntime.ProbeVersion(python);
                PythonBootstrap.InstallCompleted = version != null;
                PythonBootstrap.InstallInProgress = false;

                if (process.ExitCode == 0 && version != null)
                    _logger.LogInformation("Python ready: {Python} ({Version})", python, version);
                else
                    _logger.LogError("Python install failed (exit={ExitCode}). Check /home/site/.python-executable", process.ExitCode);
            }
            catch (OperationCanceledException)
            {
                PythonBootstrap.InstallInProgress = false;
            }
            catch (Exception ex)
            {
                PythonBootstrap.InstallInProgress = false;
                _logger.LogError(ex, "Python bootstrap failed");
            }
        }
    }
}
