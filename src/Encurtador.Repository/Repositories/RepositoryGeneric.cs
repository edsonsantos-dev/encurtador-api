using Encurtador.Repository.Context;
using Encurtador.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Encurtador.Repository.Repositories;

public class RepositoryGeneric<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly EncurtadorContext _context;
    private readonly DbSet<TEntity> _dbSet;

    protected RepositoryGeneric(EncurtadorContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }
    public virtual async Task<TEntity> AdicionarAsync(TEntity entity)
    {
        var entityPersisty = await _dbSet.AddAsync(entity);

        return entityPersisty.Entity;
    }

    public virtual async Task ExcluirAsync(TEntity entity)
    {
        _dbSet.Remove(entity);

        await SaveChangesAsync();
    }

    public virtual async Task<TEntity> ObterPorId(Guid id)
    {
        var entity = await _dbSet.FindAsync(id);

        return entity!;
    }

    public virtual async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}
