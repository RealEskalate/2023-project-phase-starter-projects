using Application.Contracts.Persistance;
using Domain.Entities;

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
    public Task<User> GetUserByEmail(string email){
        throw new NotImplementedException();
    }

    public Task<User> GetUserByUserName(string email){
        throw new NotImplementedException();
    }

    public Task<List<Notification>> GetNotification(int Id){
        throw new NotImplementedException();
    }
}