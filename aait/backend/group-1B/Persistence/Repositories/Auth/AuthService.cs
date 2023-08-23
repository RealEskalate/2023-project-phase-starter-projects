using Application.Contracts.Auth;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.Auth
{
    public class AuthService : IAuthService
    {

        private readonly SocialSyncDbContext _context;

        public AuthService(SocialSyncDbContext context)
        {
            _context = context;
        }
        public async Task<User?> Login(string username, string password)
        {
            Console.WriteLine("enters login");
            User user = await _context.Users.FirstOrDefaultAsync<User>(user => user.Username == username);

            Console.WriteLine("user: " + user);
            if (user == null)
                return null;

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            return user;
        }

        public async Task<User> Register(User user, string password)
        {
            byte[] PasswordHash, PasswordSalt;
            CreatePasswordHash(password, out PasswordHash, out PasswordSalt);

            user.PasswordHash = PasswordHash;
            user.PasswordSalt = PasswordSalt;

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;


        }

        public async Task<bool> UserExists(string username)
        {
            if (await _context.Users.AnyAsync<User>(user => user.Username == username))
                return true;

            return false;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {

                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < computedHash.Length; i++)
                    if (computedHash[i] != passwordHash[i]) return false;

            }

            return true;
        }
    }
}
