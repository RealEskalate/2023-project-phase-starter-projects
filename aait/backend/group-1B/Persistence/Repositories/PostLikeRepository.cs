using Application.Contracts.Persistence;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class PostLikeRepository : IPostLikesRepository
    {
        public Task<PostLike> Add(PostLike like)
        {
            throw new NotImplementedException();
        }

        public Task ChangeLike(PostLike like)
        {
            throw new NotImplementedException();
        }

        public Task Delete(PostLike like)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Exists(int userId, int postId)
        {
            throw new NotImplementedException();
        }

        public Task<PostLike?> Get(int userId, int postId)
        {
            throw new NotImplementedException();
        }

        public Task<List<PostLike>> GetLikesByPostId(int postId)
        {
            throw new NotImplementedException();
        }

        public Task<List<PostLike>> GetLikesByUserId(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
