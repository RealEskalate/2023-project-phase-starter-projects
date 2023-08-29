using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Contracts
{
    public interface IPostReactionRepository : IGenericRepository<PostReaction>
    {
        public Task<List<PostReaction>> Likes(int Id);

        public Task<List<PostReaction>> DisLikes(int Id);

        public Task<PostReaction> MakeReaction(int Id, PostReaction entity);

        Task<bool> Exists(int id);
    }
}