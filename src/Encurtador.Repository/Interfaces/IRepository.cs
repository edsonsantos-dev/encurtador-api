namespace Encurtador.Repository.Interfaces;

public interface IRepository<TEntity> where TEntity : class
{
    Task<TEntity> ObterPorId(Guid id);
    Task<TEntity> CadastrarAsync(TEntity entity);
    Task ExcluirAsync(TEntity entity);
    Task<bool> SaveChangesAsync();
}
