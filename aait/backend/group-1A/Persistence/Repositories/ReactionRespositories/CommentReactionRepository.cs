using Application.Contracts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class CommentReactionRepository : GenericRepository<CommentReaction>, ICommentReactionRepository
    {
        private readonly SocialMediaDbContext _dbContext;

        public CommentReactionRepository(SocialMediaDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CommentReaction>> GetReactionsForCommentAsync(int commentId)
        {
            return await _dbContext.CommentReactions
                .Where(reaction => reaction.CommentId == commentId)
                .ToListAsync();
        }

        public async Task<List<CommentReaction>> GetReactionsByUserAsync(int userId)
        {
            return await _dbContext.CommentReactions
                .Where(reaction => reaction.UserId == userId)
                .ToListAsync();
        }

        // Implement other methods defined in ICommentReactionRepository
    }
}
