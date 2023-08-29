using Microsoft.EntityFrameworkCore;
using SocialMediaApp.Application.Persistence.Contracts;

namespace SocialMediaApp.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly SocialMediaAppDbContext _context;
    public GenericRepository(SocialMediaAppDbContext socialMediaAppDbContext)
    {
        _context = socialMediaAppDbContext;
    }
    public async Task<T> Add(T entity)
    {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> Exists(Guid id)
    {
        var entity = await  GetById(id);
        return entity != null;
    }

    public async Task<IReadOnlyList<T>> GetAll()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T> GetById(Guid id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task Update(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}
