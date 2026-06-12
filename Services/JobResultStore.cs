using System.Collections.Concurrent;

namespace ratpdf.Services
{
    public class JobResult
    {
        public string Status { get; set; } = "Pending"; // Pending, Processing, Completed, Failed
        public string JobKind { get; set; } = "compress";
        public string? BlobName { get; set; }
        public string? OriginalFileName { get; set; }
        public string? OutputFileName { get; set; }
        public string? OutputMimeType { get; set; }
        public long? OriginalSize { get; set; }
        public long? CompressedSize { get; set; }
        public double? ReductionPercent { get; set; }
        public int ProgressPercent { get; set; }
        public string? ProgressMessage { get; set; }
        public string? ErrorMessage { get; set; }
        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
    }

    public interface IJobResultStore
    {
        void CreateJob(string jobId, string jobKind = "compress");
        void SetProgress(string jobId, int percent, string? message = null);
        void SetCompleted(string jobId, string BlobName, long originalSize, long compressedSize, double reductionPercent);
        void SetFileJobCompleted(string jobId, string blobName, string mimeType, string outputFileName, long inputSize, long outputSize, string jobKind);
        void SetFailed(string jobId, string error);
        void ClearResultBlob(string jobId);
        JobResult? GetJob(string jobId);
        void CleanupOldJobs(TimeSpan maxAge);
    }

    public class JobResultStore : IJobResultStore
    {
        private readonly ConcurrentDictionary<string, JobResult> _jobs = new();
        private readonly ILogger<JobResultStore> _logger;

        public JobResultStore(ILogger<JobResultStore> logger)
        {
            _logger = logger;
        }

        public void CreateJob(string jobId, string jobKind = "compress")
        {
            _jobs[jobId] = new JobResult { Status = "Pending", JobKind = jobKind };
        }

        public void SetProgress(string jobId, int percent, string? message = null)
        {
            if (_jobs.TryGetValue(jobId, out var job))
            {
                job.Status = "Processing";
                job.ProgressPercent = Math.Clamp(percent, 0, 100);
                job.ProgressMessage = message;
                job.LastUpdated = DateTime.UtcNow;
            }
        }

        public void SetCompleted(string jobId, string blobName, long originalSize, long compressedSize, double reductionPercent)
        {
            if (_jobs.TryGetValue(jobId, out var job))
            {
                job.Status = "Completed";
                job.BlobName = blobName;
                job.OriginalSize = originalSize;
                job.CompressedSize = compressedSize;
                job.ReductionPercent = reductionPercent;
                job.LastUpdated = DateTime.UtcNow;
            }
        }

        public void SetFileJobCompleted(
            string jobId,
            string blobName,
            string mimeType,
            string outputFileName,
            long inputSize,
            long outputSize,
            string jobKind)
        {
            if (_jobs.TryGetValue(jobId, out var job))
            {
                job.Status = "Completed";
                job.JobKind = jobKind;
                job.BlobName = blobName;
                job.OutputMimeType = mimeType;
                job.OutputFileName = outputFileName;
                job.OriginalSize = inputSize;
                job.CompressedSize = outputSize;
                job.ProgressPercent = 100;
                job.ProgressMessage = "Complete";
                job.LastUpdated = DateTime.UtcNow;
            }
        }

        public void SetFailed(string jobId, string error)
        {
            if (_jobs.TryGetValue(jobId, out var job))
            {
                job.Status = "Failed";
                job.ErrorMessage = error;
                job.LastUpdated = DateTime.UtcNow;
            }
        }

        public void ClearResultBlob(string jobId)
        {
            if (_jobs.TryGetValue(jobId, out var job))
            {
                job.BlobName = null;
                job.LastUpdated = DateTime.UtcNow;
            }
        }

        public JobResult? GetJob(string jobId)
        {
            _jobs.TryGetValue(jobId, out var job);
            return job;
        }

        public void CleanupOldJobs(TimeSpan maxAge)
        {
            var cutoff = DateTime.UtcNow - maxAge;
            foreach (var kv in _jobs)
            {
                if (kv.Value.LastUpdated < cutoff && kv.Value.Status != "Pending")
                {
                    _jobs.TryRemove(kv.Key, out _);
                }
            }
        }
    }
}