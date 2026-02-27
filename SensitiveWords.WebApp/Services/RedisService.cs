using Microsoft.Extensions.Caching.Distributed;
using SensitiveWords.WebApp.Interfaces;

namespace SensitiveWords.WebApp.Services
{
    /// <summary>
    /// Redis service for caching
    /// </summary>
    /// <seealso cref="SensitiveWords.WebApp.Interfaces.IRedisService" />
    public class RedisService : IRedisService
    {
        private readonly IDistributedCache _cache;

        /// <summary>
        /// Initializes a new instance of the <see cref="RedisService"/> class.
        /// </summary>
        /// <param name="cache">The cache.</param>
        public RedisService(IDistributedCache cache)
        {
            _cache = cache;
        }
        /// <summary>
        /// Sets a value asynchronous.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public async Task SetValueAsync(string key, string value)
        {
            await _cache.SetStringAsync(key, value, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(1)
            });
        }

        /// <summary>
        /// Gets a value asynchronous.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>Value associated with the key</returns>
        public async Task<string> GetValueAsync(string key)
        {
            return await _cache.GetStringAsync(key) ?? string.Empty;
        }
    }
}
