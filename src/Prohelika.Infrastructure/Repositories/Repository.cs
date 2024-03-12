using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Prohelika.Domain.Entities;
using Prohelika.Domain.Repositories;
using Prohelika.Infrastructure.Data;

namespace Prohelika.Infrastructure.Repositories;

public class Repository: IRepository;

public class CrudRepository<TEntity, TId>(ApplicationDbContext context) : Repository, ICrudRepository<TEntity, TId>
    where TEntity : Entity<TId>
{
    private readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();


    public async Task<TEntity> CreateAsync(TEntity entity)
    {
       var result = await _dbSet.AddAsync(entity);
       
        return result.Entity;
        
    }

    public async Task<TEntity?> GetAsync(TId id)
    {
        var result = await _dbSet.FirstOrDefaultAsync(x => x.Id != null && x.Id.Equals(id));
        
        return result;
    }

    public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate)
    {
        var result = await _dbSet.FirstOrDefaultAsync(predicate);
        
        return result;
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        var result = await _dbSet.AsNoTracking().ToListAsync();
        
        return result;
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate)
    {
        var result = await _dbSet.AsNoTracking().Where(predicate).ToListAsync();
        
        return result;
    }

    public TEntity Update(TEntity entity)
    {
        var result = _dbSet.Update(entity);
        
        return result.Entity;
    }

    public void Delete(TEntity entity)
    {
        _dbSet.Remove(entity);
    }

    public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _dbSet.CountAsync(predicate);
    }

    public async Task<int> CountAsync()
    {
        return await _dbSet.CountAsync();
    }

    public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return _dbSet.AnyAsync(predicate);
    }

    public async Task<int> SaveChangesAsync()
    {
        return await context.SaveChangesAsync();
    }
}