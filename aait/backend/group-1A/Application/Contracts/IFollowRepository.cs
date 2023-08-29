using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO.FollowDTo;
using Domain.Entites;
using SocialSync.Domain.Entities;

namespace Application.Contracts
{
    public interface IFollowRepository 
    {
        public Task<Follow>? Get(FollowDTO follow);
        public Task<List<User>> GetFollowers(int Id);
        public Task<List<User>> GetFollowedUsers(int Id);
        public Task<Follow> AddFollow(Follow follow);
        public Task DeleteFollow(Follow follow);
        public  Task<List<Follow>> GetAll();
    }
}