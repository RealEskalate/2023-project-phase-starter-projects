using Application.Contracts.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class CommentRepository : GenericRepository<Comment>, ICommentRepository
{
    public CommentRepository(SocialSyncDbContext context) : base(context)
    {
    }

    public async Task<List<Comment>> GetByPostId(int postId)
    {
        var comments = await _context.Comments
            .Where(comment => comment.PostId == postId).ToListAsync();

        return comments;
    }
}