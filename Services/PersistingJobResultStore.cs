using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ratpdf.Data.AppDBContext;
using ratpdf.Data.Entities;

namespace ratpdf.Services;

/// <summary>Wraps in-memory job store and persists status to SQL for enterprise audit/scale-out.</summary>
public class PersistingJobResultStore : IJobResultStore
{
    private readonly JobResultStore _inner;
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ILogger<PersistingJobResultStore> _logger;

    public PersistingJobResultStore(
        IServiceScopeFactory scopeFactory,
        IHttpContextAccessor httpContextAccessor,
        ILogger<PersistingJobResultStore> logger,
        ILogger<JobResultStore> innerLogger)
    {
        _inner = new JobResultStore(innerLogger);
        _scopeFactory = scopeFactory;
        _httpContextAccessor = httpContextAccessor;
        _logger = logger;
    }

    public void CreateJob(string jobId, string jobKind = "compress")
    {
        _inner.CreateJob(jobId, jobKind);
        _ = PersistAsync(jobId, jobKind, "Pending");
    }

    public void SetProgress(string jobId, int percent, string? message = null)
        => _inner.SetProgress(jobId, percent, message);

    public void SetCompleted(string jobId, string blobName, long originalSize, long compressedSize, double reductionPercent)
    {
        _inner.SetCompleted(jobId, blobName, originalSize, compressedSize, reductionPercent);
        _ = PersistAsync(jobId, "compress", "Completed", blobName, originalSize, compressedSize);
    }

    public void SetFileJobCompleted(
        string jobId, string blobName, string mimeType, string outputFileName,
        long inputSize, long outputSize, string jobKind)
    {
        _inner.SetFileJobCompleted(jobId, blobName, mimeType, outputFileName, inputSize, outputSize, jobKind);
        _ = PersistAsync(jobId, jobKind, "Completed", blobName, inputSize, outputSize, outputFileName, mimeType);
    }

    public void SetFailed(string jobId, string error)
    {
        _inner.SetFailed(jobId, error);
        var job = _inner.GetJob(jobId);
        _ = PersistAsync(jobId, job?.JobKind ?? "unknown", "Failed", errorMessage: error);
    }

    public void ClearResultBlob(string jobId)
    {
        _inner.ClearResultBlob(jobId);
        _ = PersistAsync(jobId, status: "Downloaded", clearBlob: true);
    }

    public JobResult? GetJob(string jobId) => _inner.GetJob(jobId);

    public void CleanupOldJobs(TimeSpan maxAge) => _inner.CleanupOldJobs(maxAge);

    private async Task PersistAsync(
        string jobId,
        string? jobKind = null,
        string? status = null,
        string? blobName = null,
        long? inputBytes = null,
        long? outputBytes = null,
        string? outputFileName = null,
        string? mimeType = null,
        string? errorMessage = null,
        bool clearBlob = false)
    {
        try
        {
            using var scope = _scopeFactory.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<RatPDFDbContext>();
            var record = await db.PdfJobRecords.FindAsync(jobId);
            if (record == null)
            {
                record = new PdfJobRecord { JobId = jobId, CreatedUtc = DateTime.UtcNow };
                db.PdfJobRecords.Add(record);
            }

            if (jobKind != null) record.JobKind = jobKind;
            if (status != null) record.Status = status;
            if (blobName != null) record.BlobName = blobName;
            if (clearBlob) record.BlobName = null;
            if (inputBytes != null) record.InputBytes = inputBytes;
            if (outputBytes != null) record.OutputBytes = outputBytes;
            if (outputFileName != null) record.OutputFileName = outputFileName;
            if (mimeType != null) record.OutputMimeType = mimeType;
            if (errorMessage != null) record.ErrorMessage = errorMessage;

            if (record.UserId == null)
                record.UserId = await ResolveUserIdAsync(scope);

            record.UpdatedUtc = DateTime.UtcNow;
            await db.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Failed to persist PDF job {JobId}", jobId);
        }
    }

    private async Task<Guid?> ResolveUserIdAsync(IServiceScope scope)
    {
        var ctx = _httpContextAccessor.HttpContext;
        if (ctx?.User?.Identity?.IsAuthenticated != true)
            return null;
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
        var user = await userManager.GetUserAsync(ctx.User);
        return user?.Id;
    }
}
