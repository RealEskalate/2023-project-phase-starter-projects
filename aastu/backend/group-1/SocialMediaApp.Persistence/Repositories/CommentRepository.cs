using Microsoft.EntityFrameworkCore;
using SocialMediaApp.Application.Persistence.Contracts;
using SocialMediaApp.Domain;

namespace SocialMediaApp.Persistence.Repositories;

public class CommentRepository : GenericRepository<Comment>, ICommentRepository
{
    private readonly SocialMediaAppDbContext _dbContext;
    public CommentRepository(SocialMediaAppDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Comment> GetCommentById(Guid commentId)
    {
        var comment = await _dbContext.Comments.FindAsync(commentId);
        return comment;
    }

    public async Task<List<Comment>> GetCommentsByPostId(Guid postId)

    {
        var comments = await _dbContext.Comments.Where(c => c.PostId == postId).ToListAsync();
        return comments;
    }
}
