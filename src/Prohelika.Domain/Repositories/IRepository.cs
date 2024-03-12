using System.Linq.Expressions;
using Prohelika.Domain.Entities;

namespace Prohelika.Domain.Repositories;

public interface IRepository;

public interface ICrudRepository<TEntity, in TId> : IRepository where TEntity : Entity<TId>
{
    Task<TEntity> CreateAsync(TEntity entity);
    Task<TEntity?> GetAsync(TId id);
    Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate);
    TEntity Update(TEntity entity);
    void Delete(TEntity entity);
    
    Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);
    Task<int> CountAsync();
    
    Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);
    
    Task<int> SaveChangesAsync();
}