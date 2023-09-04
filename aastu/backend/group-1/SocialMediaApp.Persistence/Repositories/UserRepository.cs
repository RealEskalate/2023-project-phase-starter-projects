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

    public User EditUser(User user)
    {
        var userToEdit = _dbContext.Users.FirstOrDefault(u => u.Id == user.Id);
        if (userToEdit == null)
            throw new Exception("User not found");
        userToEdit.Name = user.Name;
        userToEdit.email = user.email;
        userToEdit.Bio = user.Bio;

        if (_dbContext.SaveChanges() == 0)
            throw new Exception("User not edited");

        return userToEdit;
    }

}
