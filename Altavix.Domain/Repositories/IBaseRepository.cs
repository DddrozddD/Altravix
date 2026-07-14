using System.Linq.Expressions;

namespace Altavix.Domain.Repositories;

public interface IBaseRepository<TEntity> where TEntity : class
{
    Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    void Add(TEntity entity);
    Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    void AddRange(IEnumerable<TEntity> entities);
    void Update(TEntity entity);
    void Remove(TEntity entity);
    IEnumerable<TEntity> All();
    bool Any(Expression<Func<TEntity, bool>> predicate);
    TEntity First(Expression<Func<TEntity, bool>> predicate);
    TEntity? FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
    IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
}
