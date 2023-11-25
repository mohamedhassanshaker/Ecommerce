
using Microsoft.Extensions.Caching.Distributed;

namespace Ecommerce.Domian.Common.Interfaces
{
    public interface ICacheProvider
    {
        Task<T> GetFromCache<T>(string key) where T : class;
        Task SetCache<T>(string key, T value, DistributedCacheEntryOptions options) where T : class;
        Task SetCache<T>(string key, T value) where T : class;
        Task RemoveFromCache(string key);
    }
}