using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO.UserDTO.DTO;
using Domain.Entites;
using SocialSync.Domain.Entities;

namespace Application.Contracts
{
    public interface IUserRepository : IGenericRepository<User>
    {
        public Task<User> Get(int Id);
        public Task<List<User>> GetAllUsers();
        public Task<bool> Exists(int Id);
        public Task UpdatePassword(UpdatePasswordDTO updatePasswordDTO,int UserId);
        public Task<User> UpdateUser(UserUpdateDTO updateUserDTO,int UserId);

    }
}