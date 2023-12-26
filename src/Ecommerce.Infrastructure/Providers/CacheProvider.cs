using Ecommerce.Domian.Common.Interfaces;
using Ecommerce.Infrastructure.Common;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace Ecommerce.Infrastructure.Providers
{
    public class CacheProvider : ICacheProvider
    {
        private readonly IDistributedCache _cache;
        private readonly IOptions<RedisSettings> redisSettings;

        public CacheProvider(IDistributedCache cache, IOptions<RedisSettings> redisSettings)
        {
            _cache = cache;
            this.redisSettings = redisSettings;
        }

        public async Task<T> GetFromCache<T>(string key) where T : class
        {
            var cachedResponse = await _cache.GetStringAsync(key);
             
            return cachedResponse == null ? null : JsonSerializer.Deserialize<T>(cachedResponse);
        }

        public async Task SetCache<T>(string key, T value, DistributedCacheEntryOptions options) where T : class
        {
            var response = JsonSerializer.Serialize(value);
            await _cache.SetStringAsync(key, response, options);
        }
        public async Task SetCache<T>(string key, T value) where T : class
        {
            DistributedCacheEntryOptions options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(redisSettings.Value.MinutesToExpire)
            };
            try
            {
                var response = JsonSerializer.Serialize(value);
                await _cache.SetStringAsync(key, response, options);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task RemoveFromCache(string key)
        {
            await _cache.RemoveAsync(key);
        }
    }

}
