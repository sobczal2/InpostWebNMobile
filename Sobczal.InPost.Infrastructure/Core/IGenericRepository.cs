namespace Sobczal.InPost.Infrastructure.Core;

public interface IGenericRepository<TEntity, in TId>
    where TEntity : class
    where TId : notnull
{
    Task<TEntity?> GetByIdAsync(TId id);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(TEntity entity);
    IQueryable<TEntity> Query { get; }
}