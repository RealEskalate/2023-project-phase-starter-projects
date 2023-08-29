using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Application.Contracts;
using Domain.Entites;
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
        public new Task<List<User>> GetAll(Expression<Func<User, bool>> predicate)
        {
            throw new NotImplementedException();
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