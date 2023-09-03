using Application.Contracts.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Persistance.Repository;

public class GenericRepository<T> : IGenericRepository<T> where T : class{
    private readonly SocialSyncDbContext _dbContext;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(SocialSyncDbContext dbContext){
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<T>();
    }

    public async Task<T> Get(int id){
        return await _dbSet.FindAsync(id);
    }

    public async Task<List<T>> GetAll(int pageNumber = 0, int pageSize = 10){
        return await _dbSet
            .Skip(pageNumber * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<T> Add(T entity){
        await _dbSet.AddAsync(entity);
        return entity;
    }

    public async Task<bool> Exists(int id){
        return await _dbSet.FindAsync(id) != null;
    }

    public async Task Update(T entity){
        _dbContext.Entry(entity).State = EntityState.Modified;
    }

    public async Task Delete(T entity){
         _dbSet.Remove(entity);
    }
}