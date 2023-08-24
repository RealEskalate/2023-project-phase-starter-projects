using Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly SocialSyncDbContext _context;

    public GenericRepository(SocialSyncDbContext context)
    {
        _context = context;
    }
    public async Task<T?> Get(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<List<T>> GetAll()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<bool> Exists(int id)
    {
        var entity = await Get(id);
        return entity != null;
    }

    public async Task<T> Add(T item)
    {
        await _context.Set<T>().AddAsync(item);
        return item;
    }

    public async Task<T> Update(T item)
    {
        _context.Entry(item).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return item;
    }

    public async Task Delete(T item)
    {
        _context.Set<T>().Remove(item);
        await _context.SaveChangesAsync();
    }
}