using Application.Contracts.Persistance;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Persistance.Repository;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    private readonly SocialSyncDbContext _dbContext;

    public UserRepository(SocialSyncDbContext context) : base(context){
        _dbContext = context;
    }
    public async Task<List<User>> Search(string name, int pageNumber = 0, int pageSize = 10){
        return await _dbContext.Users
            .Where(user => user.FullName.Contains(name) || user.UserName.Contains(name))
            .Skip(pageNumber * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }
    
    public async Task<User> GetUserByEmail(string email){
        return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<User> GetUserByUserName(string Username){
        return await _dbContext.Users.FirstOrDefaultAsync(u => u.UserName == Username);
    }
    
}