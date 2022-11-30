using Microsoft.EntityFrameworkCore;
using Sobczal.InPost.Models.Common;

namespace Sobczal.InPost.Infrastructure.Core;

public class GenericRepository<TEntity, TId> : IGenericRepository<TEntity, TId>
    where TEntity : Entity<TId>
    where TId : notnull
{
    protected readonly InPostDbContext InPostDbContext;

    public GenericRepository(InPostDbContext inPostDbContext)
    {
        InPostDbContext = inPostDbContext;
    }

    public async Task<TEntity?> GetByIdAsync(TId id)
    {
        return await InPostDbContext.Set<TEntity>().FirstOrDefaultAsync(x => x.Id.Equals(id));
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await InPostDbContext.Set<TEntity>().ToListAsync();
    }

    public Task AddAsync(TEntity entity)
    {
        InPostDbContext.Set<TEntity>().Add(entity);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(TEntity entity)
    {
        InPostDbContext.Set<TEntity>().Attach(entity);
        InPostDbContext.Entry(entity).State = EntityState.Modified;
        return Task.CompletedTask;
    }

    public Task DeleteAsync(TEntity entity)
    {
        InPostDbContext.Set<TEntity>().Remove(entity);
        return Task.CompletedTask;
    }

    public IQueryable<TEntity> Query => InPostDbContext.Set<TEntity>();
}