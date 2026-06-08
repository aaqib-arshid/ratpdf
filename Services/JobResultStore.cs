using System.Collections.Concurrent;

namespace ratpdf.Services
{
    public class JobResult
    {
        public string Status { get; set; } = "Pending"; // Pending, Completed, Failed
        public string? BlobName { get; set; }
        public string? OriginalFileName { get; set; }
        public long? OriginalSize { get; set; }
        public long? CompressedSize { get; set; }
        public double? ReductionPercent { get; set; }
        public string? ErrorMessage { get; set; }
        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
    }

    public interface IJobResultStore
    {
        void CreateJob(string jobId);
        void SetCompleted(string jobId, string BlobName, long originalSize, long compressedSize, double reductionPercent);
        void SetFailed(string jobId, string error);
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

        public void CreateJob(string jobId)
        {
            _jobs[jobId] = new JobResult { Status = "Pending" };
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

        public void SetFailed(string jobId, string error)
        {
            if (_jobs.TryGetValue(jobId, out var job))
            {
                job.Status = "Failed";
                job.ErrorMessage = error;
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