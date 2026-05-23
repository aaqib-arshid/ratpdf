using Microsoft.Extensions.Caching.Memory;

namespace ratpdf.Services.JwtSeo
{
    public interface ICacheService
    {
        T? Get<T>(string key);
        T GetOrCreate<T>(string key, Func<T> factory, TimeSpan? absoluteExpiration = null);
        Task<T> GetOrCreateAsync<T>(string key, Func<Task<T>> factory, TimeSpan? absoluteExpiration = null);
        void Remove(string key);
    }

    public class CacheService : ICacheService
    {
        private readonly IMemoryCache _cache;
        public CacheService(IMemoryCache cache) => _cache = cache;

        public T? Get<T>(string key) => _cache.Get<T>(key);

        public T GetOrCreate<T>(string key, Func<T> factory, TimeSpan? absoluteExpiration = null)
        {
            if (_cache.TryGetValue(key, out T? cached) && cached != null)
                return cached;

            var value = factory();
            var options = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = absoluteExpiration ?? TimeSpan.FromHours(24)
            };
            _cache.Set(key, value, options);
            return value;
        }

        public async Task<T> GetOrCreateAsync<T>(string key, Func<Task<T>> factory, TimeSpan? absoluteExpiration = null)
        {
            if (_cache.TryGetValue(key, out T? cached) && cached != null)
                return cached;

            var value = await factory();
            var options = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = absoluteExpiration ?? TimeSpan.FromHours(24)
            };
            _cache.Set(key, value, options);
            return value;
        }

        public void Remove(string key) => _cache.Remove(key);
    }
}
