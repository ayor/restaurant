using Application.Interfaces;
using Domain.Settings;
using StackExchange.Redis;

namespace Infrastructure.Services
{
    // public class CacheService : ICacheService
    // {
    //     // private IDatabase _database;
    //     // private readonly CacheSettings _cacheSettings;
    //     // // private readonly redis _cacheOptions;
    //     // public CacheService(CacheSettings cacheSettings, IDatabase database)
    //     // {
    //     //     _cacheSettings = cacheSettings;
    //     //     _database = database;
    //     //     // if (_cacheSettings != null) 
    //     //     // {
    //     //     //     _cacheSettings = new CacheSettings()
    //     //     //     {
    //     //     //         ExpirationInHours = DateTime.Now.AddHours(_cacheOptions.),
    //     //     //         // Priority = CacheItemPriority.High,
    //     //     //         ExpirationInMinutes = TimeSpan.FromMinutes(_cacheSettings.ExpirationInMinutes)
    //     //     //     };
    //     //     // }
    //     // }
    //     // public bool TryGet<T>(string cacheKey, out T value) 
    //     // {
    //     //     _database.StringGet(cacheKey);
    //     //     if (value == null) return false;
    //     //     else return true;
    //     // }
    //     //
    //     // public T Set<T>(string cacheKey, T value)
    //     // {
    //     //     return _database.HashSet();
    //     // }
    //     //
    //     // public void Remove(string cacheKey)
    //     // {
    //     //     _database.HashDelete();
    //     // }
    //     
    // }
}