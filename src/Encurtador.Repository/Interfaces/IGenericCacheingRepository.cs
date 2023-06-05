namespace Encurtador.Repository.Interfaces;

public interface IGenericCacheingRepository<TEntity> where TEntity : class
{
    Task SetAsync(string key, TEntity value);
    Task<TEntity?> GetAsync(string key);
}
