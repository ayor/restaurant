using System;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICacheService
    {
        Task <string> GetAsync(string key);
        Task SetAsync(string key, string value);
        Task RefreshAsync(string key);
        Task RemoveAsync(string key);
    }
}