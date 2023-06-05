using Encurtador.Repository.Interfaces;
using Encurtador.Shared.Config;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Encurtador.Repository.Repositories;

public class GenericCacheingRepository<TEntity> : IGenericCacheingRepository<TEntity> where TEntity : class
{
    private readonly IDistributedCache _cache;
    private readonly DistributedCacheEntryOptions _options;

    public GenericCacheingRepository(IDistributedCache cache)
    {
        _cache = cache;
        _options = new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan
            .FromHours(RedisSettings.Instance.AbsoluteExpirationRelativeToNow)
        };
    }

    public async Task SetAsync(string key, TEntity value)
    {
        var model = JsonConvert.SerializeObject(value);

        await _cache.SetStringAsync(key, model, _options);
    }

    public async Task<TEntity?> GetAsync(string key)
    {
        var cache = await _cache.GetStringAsync(key);

        if (string.IsNullOrEmpty(cache))
            return null;

        var model = JsonConvert.DeserializeObject<TEntity>(cache!);

        return model;
    }
}
