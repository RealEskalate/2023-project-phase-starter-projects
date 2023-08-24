using Application.Contracts.Persistance;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repository;

public class CommentRepository : GenericRepository<Comment>, ICommentRepository
{
    private readonly SocialSyncDbContext _context;

    public CommentRepository(SocialSyncDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Comment>> GetCommentByPost(int postId)
    {
        return await _context.Comments
            .Where(comment => comment.PostId == postId)
            .ToListAsync();
    }

}    