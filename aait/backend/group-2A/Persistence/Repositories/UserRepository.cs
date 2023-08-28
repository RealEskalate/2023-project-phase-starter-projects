using Application.Contracts.Persistance;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repository;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    private readonly SocialSyncDbContext _dbContext;

    public UserRepository(SocialSyncDbContext context) : base(context){
        _dbContext = context;
    }

    public Task<List<User>> SearchByFullName(string email){
        throw new NotImplementedException();
    }

    public Task<List<User>> SearchByUserName(string email){
        throw new NotImplementedException();
    }
    public async Task<User> GetUserByEmail(string email){
        return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<User> GetUserByUserName(string Username){
        return await _dbContext.Users.FirstOrDefaultAsync(u => u.UserName == Username);
    }

    public Task<List<Notification>> GetNotification(int Id){
        throw new NotImplementedException();
    }
}