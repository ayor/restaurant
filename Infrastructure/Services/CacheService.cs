using System;
using System.Threading.Tasks;
using Application.Interfaces;
using Microsoft.Extensions.Caching.Distributed;

namespace Infrastructure.Services
{
    public class CacheService : ICacheService
    {
        private readonly IDistributedCache _distributedCache;
        // private readonly DistributedCacheEntryOptions _option;

        public CacheService(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
            // if (_option != null)
            // {
            //     _option = new DistributedCacheEntryOptions
            //     {
            //         AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
            //     };
            // }
        }

        public async Task<string> GetAsync(string key)
        {
            return await _distributedCache.GetStringAsync(key);
        }

        public async Task SetAsync(string key, string value)
        {
            var option = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1)
            };    
            await _distributedCache.SetStringAsync(key, value, option);
        }

        public async Task RefreshAsync(string key)
        {
            await _distributedCache.RefreshAsync(key);
        }

        public async Task RemoveAsync(string key)
        {
            await _distributedCache.RemoveAsync(key);
        }
    }
}