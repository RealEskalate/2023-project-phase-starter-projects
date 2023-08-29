using Microsoft.AspNetCore.Identity;
using Persistence;
using SocialSync.Application.Contracts;
using SocialSync.Domain.Entities;

namespace SocialSync.Persistence.Repositories.Auth;

public class AuthRepository : IAuthRepository
{

    private readonly SocialMediaDbContext _socialMediaDbContext;
    public AuthRepository(SocialMediaDbContext socialMediaDbContext)
    {
        _socialMediaDbContext = socialMediaDbContext;
    }
    
    public Task<User> LoginUser(User user)
    {
        //check if user exists
        //check if password is correct
        //return user
        var newUser = _socialMediaDbContext.Users.FirstOrDefault(x =>  x.Email == user.Email);
        if (newUser == null)
        {
            return Task.FromResult<User>(null);
        }

        var passwordHash = new PasswordHasher<User>();
        var result = passwordHash.VerifyHashedPassword(newUser, newUser.Password, user.Password);
        if (result == PasswordVerificationResult.Failed)
        {
            return Task.FromResult<User>(null);
        }

        return Task.FromResult(newUser);
        


    }

    public Task<User> RegisterUser(User user)
    {
        //check if user exists
        //create user
        //return user
        var newUser = _socialMediaDbContext.Users.FirstOrDefault(x => x.Username == user.Username);
        if (newUser != null)
        {
            return Task.FromResult<User>(null);
        }

        var passwordHash = new PasswordHasher<User>();
        user.Password = passwordHash.HashPassword(user, user.Password);

        _socialMediaDbContext.Users.Add(user);
        _socialMediaDbContext.SaveChanges();
        return Task.FromResult(user);
    }

    public Task<bool> UserExists(string Email)
    {
        var user = _socialMediaDbContext.Users.FirstOrDefault(x => x.Email == Email);
        if (user == null)
        {
            return Task.FromResult(false);
        }
        
        return Task.FromResult(true);
    }
    
}