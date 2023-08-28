using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories.ReactionRespositories
{
    public class CommentReactionRepository : GenericRepository<CommentReaction>, ICommentReactionRepository
    {
        private readonly SocialMediaDbContext _dbContext;

        public CommentReactionRepository(SocialMediaDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<CommentReaction>> DisLikes(int Id)
        {
            var result = await GetCommentWithId(Id);

            return result.CommentReactions.Where(x => x.Dislike == true).ToList();
        }


        public async Task<List<CommentReaction>> Likes(int Id)
        {
            var result = await GetCommentWithId(Id);

            return result.CommentReactions.Where(x => x.Like == true).ToList();
        }



        public async Task<CommentReaction> MakeReaction(int UserId, CommentReaction entity)
        {
            var reaction = _dbContext.CommentReaction.FirstOrDefault(x => x.UserId == UserId && x.CommentId == entity.CommentId);

            if (reaction == null)
            {
                entity.UserId = UserId;
                await _dbContext.CommentReaction.AddAsync(entity);
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


        private async Task<Comment> GetCommentWithId(int id)
        {
            return await _dbContext.Comments
                    .Include(x => x.CommentReactions)
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();
        }

        public async Task<bool> Exists(int id)
        {
            var result = await _dbContext.CommentReaction.FindAsync(id);
            return result != null;
        }
    }
}