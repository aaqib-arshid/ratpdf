using System.Collections.Concurrent;

namespace ratpdf.Services
{
    public class PdfEditSession
    {
        public string SessionId { get; set; } = "";
        public string PdfPath { get; set; } = "";
        public string OriginalFileName { get; set; } = "";
        public string DocumentModelJson { get; set; } = "{}";
        public string AssetsDir { get; set; } = "";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

    public interface IPdfEditSessionStore
    {
        PdfEditSession Create(string pdfPath, string originalFileName, string documentModelJson);
        PdfEditSession? Get(string sessionId);
        void Remove(string sessionId);
        void Cleanup(TimeSpan maxAge);
    }

    public class PdfEditSessionStore : IPdfEditSessionStore
    {
        private readonly ConcurrentDictionary<string, PdfEditSession> _sessions = new();
        private readonly ILogger<PdfEditSessionStore> _logger;

        public PdfEditSessionStore(ILogger<PdfEditSessionStore> logger)
        {
            _logger = logger;
        }

        public PdfEditSession Create(string pdfPath, string originalFileName, string documentModelJson)
        {
            var id = Guid.NewGuid().ToString("N");
            var assetsDir = Path.Combine(Path.GetDirectoryName(pdfPath)!, id + "_assets");
            Directory.CreateDirectory(assetsDir);
            var session = new PdfEditSession
            {
                SessionId = id,
                PdfPath = pdfPath,
                OriginalFileName = originalFileName,
                DocumentModelJson = documentModelJson,
                AssetsDir = assetsDir,
            };
            _sessions[id] = session;
            return session;
        }

        public PdfEditSession? Get(string sessionId)
        {
            _sessions.TryGetValue(sessionId, out var session);
            return session;
        }

        public void Remove(string sessionId)
        {
            if (_sessions.TryRemove(sessionId, out var session))
            {
                TryDeleteFile(session.PdfPath);
                TryDeleteDirectory(session.AssetsDir);
            }
        }

        public void Cleanup(TimeSpan maxAge)
        {
            var cutoff = DateTime.UtcNow - maxAge;
            foreach (var kv in _sessions)
            {
                if (kv.Value.CreatedAt < cutoff)
                {
                    Remove(kv.Key);
                }
            }
        }

        private void TryDeleteFile(string path)
        {
            try
            {
                if (File.Exists(path))
                    File.Delete(path);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Failed to delete temp PDF {Path}", path);
            }
        }

        private void TryDeleteDirectory(string path)
        {
            if (string.IsNullOrEmpty(path) || !Directory.Exists(path))
                return;
            try
            {
                Directory.Delete(path, recursive: true);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Failed to delete session assets {Path}", path);
            }
        }
    }
}
