using System;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICacheService
    {
        public Task<object> GetAsync(string key);
        public Task SetAsync(string key, object value, TimeSpan expirationTimeFromNow);
        // public Task RefreshAsync(string key);
        public Task RemoveAsync(string key);
    }
}