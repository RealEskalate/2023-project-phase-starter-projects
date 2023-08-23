

using Application.Contracts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly SocialMediaDbContext _dbContext;

        public GenericRepository(SocialMediaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<T> Add(T entity)
        {   
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }


        public async Task<bool> Exists(int id)
        {
            var result = await _dbContext.Set<T>().FindAsync(id);
            return result != null;
        }


        public async Task<List<T>> GetAll(Expression<Func<T, bool>> predicate)
        {
            var result = await _dbContext.Set<T>()
                    .Where(predicate)
                    .ToListAsync();
            return result;
        }

        public async Task<T> Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
