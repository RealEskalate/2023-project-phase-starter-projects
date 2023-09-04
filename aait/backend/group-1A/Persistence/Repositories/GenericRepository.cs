

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

        public async Task<T> Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            //_dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
