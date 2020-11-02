using Application.Settings;

namespace Application.Interfaces
{
    public interface ICacheInvalidatorPostProcessor
    {
       InvalidateCacheForQueries QueriesList { get; set; }
    }
}