using System.Threading.Channels;

namespace ratpdf.Services
{
    public interface IJobQueue
    {
        void Queue(Func<CancellationToken, Task> work);
        Task ProcessAsync(CancellationToken ct);
    }

    public class JobQueue : IJobQueue
    {
        private readonly Channel<Func<CancellationToken, Task>> _channel = Channel.CreateUnbounded<Func<CancellationToken, Task>>();

        public void Queue(Func<CancellationToken, Task> work)
        {
            _channel.Writer.TryWrite(work);
        }

        public async Task ProcessAsync(CancellationToken ct)
        {
            await foreach (var work in _channel.Reader.ReadAllAsync(ct))
            {
                try
                {
                    await work(ct);
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}