using System.Linq.Expressions;

namespace Data.Interfaces;

public interface IBaseRepository<TEntity> where TEntity : class
{
    Task<bool> AddAsync(TEntity entity);
    Task<bool> AlreadyExistsAsync(Expression<Func<TEntity, bool>> expression);
    Task<IEnumerable<TEntity>> GetAsync();
    Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression);
    Task<bool> RemoveAsync(TEntity entity);
    Task<bool> UpdateAsync(TEntity entity);
}