using Encurtador.Domain.Entities;
using Encurtador.Repository.Interfaces;
using Microsoft.Extensions.Caching.Distributed;

namespace Encurtador.Repository.Repositories;

public class UrlEncurtadaCacheRepository : GenericCacheingRepository<UrlEncurtada>, IUrlEncurtadaCacheRepository
{
    public UrlEncurtadaCacheRepository(IDistributedCache cache) : base(cache)
    {
    }
}
