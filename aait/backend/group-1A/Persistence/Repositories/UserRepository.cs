using Application.Contracts;
using Microsoft.EntityFrameworkCore;
using SocialSync.Domain.Entities;

namespace Persistence.Repositories
{
    public class UserRepository : GenericRepository<User> ,IUserRepository
    {
        SocialMediaDbContext _socialMediaDbContext;
        public UserRepository(SocialMediaDbContext socialMediaDbContext) : base(socialMediaDbContext)
        {
            _socialMediaDbContext = socialMediaDbContext;
        }
     
        public Task<User> Get(int Id)
        {
            var user =  _socialMediaDbContext.Users.Where(u => u.Id == Id).FirstOrDefaultAsync();
            return user!;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _socialMediaDbContext.Users.ToListAsync();
        }
        public async Task<bool> Exists(int Id)
        {
            return await _socialMediaDbContext.Users.FindAsync(Id) != null;
        }

    }
}