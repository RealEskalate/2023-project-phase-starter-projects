using Application.Contracts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Persistence.Repositories.ReactionRepositories
{
    public class CommentReactionRepository : ICommentReactionRepository
    {
        private readonly SocialMediaDbContext _dbContext;

        public CommentReactionRepository(SocialMediaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CommentReaction>> GetReactionsForCommentAsync(int commentId)
        {
            return await _dbContext.CommentReaction
                .Where(reaction => reaction.CommentId == commentId)
                .ToListAsync();
        }

        public async Task<List<CommentReaction>> GetReactionsByUserAsync(int userId)
        {
            return await _dbContext.CommentReaction
                .Where(reaction => reaction.UserId == userId)
                .ToListAsync();
        }

        public Task<List<CommentReaction>> GetAll(Expression<Func<CommentReaction, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<CommentReaction> Add(CommentReaction entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(CommentReaction entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Exists(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CommentReaction> Update(CommentReaction entity)
        {
            throw new NotImplementedException();
        }

        // Implement other methods defined in ICommentReactionRepository
    }
}
