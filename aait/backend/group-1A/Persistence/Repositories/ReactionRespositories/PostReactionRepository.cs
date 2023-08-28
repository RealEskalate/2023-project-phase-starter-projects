
using Application.Contracts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Persistence.Repositories
{
    public class PostReactionRepository : GenericRepository<PostReaction>, IPostReactionRepository
    {
        private readonly SocialMediaDbContext _dbContext;
        public PostReactionRepository(SocialMediaDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<PostReaction>> DisLikes(int Id)
        {
            var result = await GetPostWithId(Id);

            return result.PostReactions.Where(x => x.Dislike == true).ToList();
        }


        public async Task<List<PostReaction>> Likes(int Id)
        {
            var result = await GetPostWithId(Id);
                
            return result.PostReactions.Where(x => x.Like == true).ToList();
        }



        public async Task<PostReaction> MakeReaction(int UserId, PostReaction entity)
        {
            var reaction = _dbContext.PostReactions.FirstOrDefault(x =>  x.PostId == entity.PostId);

            if (reaction == null)
            {
                entity.UserId = UserId;
                await _dbContext.PostReactions.AddAsync(entity);
                await _dbContext.SaveChangesAsync();
                return entity;
            }
            else
            {
                reaction.Like = entity.Like;
                reaction.Dislike = entity.Dislike;
                await _dbContext.SaveChangesAsync();
                return entity;
            }
        }


        private async Task<Post> GetPostWithId(int id)
        {
            return await _dbContext.Posts
                    .Include(x => x.PostReactions)
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();
        }


        public async Task<bool> Exists(int id)
        {
            var result = await _dbContext.PostReactions.FindAsync(id);
            return result != null;
        }
    }
}
