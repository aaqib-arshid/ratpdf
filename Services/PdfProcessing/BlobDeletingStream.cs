namespace ratpdf.Services.PdfProcessing;

/// <summary>
/// Wraps a blob read stream and deletes the blob when the stream is disposed (after download completes).
/// </summary>
public sealed class BlobDeletingStream : Stream
{
    private readonly Stream _inner;
    private readonly Func<Task> _onDisposeAsync;
    private int _disposed;

    public BlobDeletingStream(Stream inner, Func<Task> onDisposeAsync)
    {
        _inner = inner;
        _onDisposeAsync = onDisposeAsync;
    }

    public override bool CanRead => _inner.CanRead;
    public override bool CanSeek => _inner.CanSeek;
    public override bool CanWrite => _inner.CanWrite;
    public override long Length => _inner.Length;
    public override long Position
    {
        get => _inner.Position;
        set => _inner.Position = value;
    }

    public override void Flush() => _inner.Flush();
    public override int Read(byte[] buffer, int offset, int count) => _inner.Read(buffer, offset, count);
    public override long Seek(long offset, SeekOrigin origin) => _inner.Seek(offset, origin);
    public override void SetLength(long value) => _inner.SetLength(value);
    public override void Write(byte[] buffer, int offset, int count) => _inner.Write(buffer, offset, count);

    public override async Task<int> ReadAsync(
        byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        => await _inner.ReadAsync(buffer, offset, count, cancellationToken);

    public override async ValueTask<int> ReadAsync(
        Memory<byte> buffer, CancellationToken cancellationToken = default)
        => await _inner.ReadAsync(buffer, cancellationToken);

    protected override void Dispose(bool disposing)
    {
        if (disposing && Interlocked.Exchange(ref _disposed, 1) == 0)
        {
            _inner.Dispose();
            try { _onDisposeAsync().GetAwaiter().GetResult(); }
            catch { /* best effort */ }
        }

        base.Dispose(disposing);
    }

    public override async ValueTask DisposeAsync()
    {
        if (Interlocked.Exchange(ref _disposed, 1) == 0)
        {
            await _inner.DisposeAsync();
            try { await _onDisposeAsync(); }
            catch { /* best effort */ }
        }

        await base.DisposeAsync();
    }
}
