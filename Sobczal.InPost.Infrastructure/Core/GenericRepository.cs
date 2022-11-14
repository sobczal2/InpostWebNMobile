using Microsoft.EntityFrameworkCore;
using Sobczal.InPost.Models.Common;

namespace Sobczal.InPost.Infrastructure.Core;

public class GenericRepository<TEntity, TId> : IGenericRepository<TEntity, TId>
    where TEntity : Entity<TId>
    where TId : notnull
{
    private readonly InPostDbContext _inPostDbContext;

    public GenericRepository(InPostDbContext inPostDbContext)
    {
        _inPostDbContext = inPostDbContext;
    }

    public async Task<TEntity?> GetByIdAsync(TId id)
    {
        return await _inPostDbContext.Set<TEntity>().FirstOrDefaultAsync(x => x.Id.Equals(id));
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _inPostDbContext.Set<TEntity>().ToListAsync();
    }

    public Task AddAsync(TEntity entity)
    {
        _inPostDbContext.Set<TEntity>().Add(entity);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(TEntity entity)
    {
        _inPostDbContext.Set<TEntity>().Attach(entity);
        _inPostDbContext.Entry(entity).State = EntityState.Modified;
        return Task.CompletedTask;
    }

    public Task DeleteAsync(TEntity entity)
    {
        _inPostDbContext.Set<TEntity>().Remove(entity);
        return Task.CompletedTask;
    }
}