using Application.Contracts;
using Application.DTO.UserDTO.DTO;
using Microsoft.AspNetCore.Identity;
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
            int pageSize = 2;
            int pageNumber = 1;
            return await _socialMediaDbContext.Users.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        }
        public async Task<bool> Exists(int Id)
        {
            return await _socialMediaDbContext.Users.FindAsync(Id) != null;
        }
        public async Task UpdatePassword(UpdatePasswordDTO updatePasswordDTO,int UserId)
        {
            var user = await Get(UserId);
            user.Password = updatePasswordDTO.NewPassword;
            var passwordHash = new PasswordHasher<User>();
            user.Password = passwordHash.HashPassword(user, user.Password);
            _socialMediaDbContext.Entry(user).State = EntityState.Modified;
            await _socialMediaDbContext.SaveChangesAsync();
        }


        public async Task<User> UpdateUser(UserUpdateDTO userUpdateDTO,int UserId)
        {
            var user  = await Get(UserId);


            if (userUpdateDTO.Email != "" && userUpdateDTO.Email != null)
            {
                user.Email = userUpdateDTO.Email;
            }
            if (userUpdateDTO.FirstName != "" && userUpdateDTO.FirstName != null)
            {
                user.FirstName = userUpdateDTO.FirstName;
            }
            if (userUpdateDTO.LastName != "" && userUpdateDTO.LastName != null)
            {
                user.LastName = userUpdateDTO.LastName;
            }
            if (userUpdateDTO.Bio != "" && userUpdateDTO.Bio != null)
            {
                user.Bio = userUpdateDTO.Bio;
            }
            if (userUpdateDTO.Username != "" && userUpdateDTO.Username != null)
            {
                user.Username = userUpdateDTO.Username;
            }

            await Update(user);
            return user;
        }




    }
}