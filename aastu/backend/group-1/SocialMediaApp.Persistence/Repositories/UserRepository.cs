using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
using SocialMediaApp.Application.Exceptions;
using SocialMediaApp.Application.Persistence.Contracts;
using SocialMediaApp.Domain;

namespace SocialMediaApp.Persistence.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    private readonly SocialMediaAppDbContext _dbContext;
    public UserRepository(SocialMediaAppDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public User? GetByEmail(string email)
    {
        var users = _dbContext.Users.SingleOrDefault(u => u.email == email);
        return users;
    }

    public void AddUser(User user)
    {
        _dbContext.Users.Add(user);
        _dbContext.SaveChanges();
    }

    public async Task<IReadOnlyList<User>> GetByNameAsync(string Name)
    {
        var users = await _dbContext.Users.Where(u => u.Name.Contains(Name)).ToListAsync() ?? throw new NotFoundException("${Name}", Name);
        return users;
    }

}
