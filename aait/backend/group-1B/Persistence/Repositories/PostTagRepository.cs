using Application.Contracts.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class PostTagRepository : GenericRepository<PostTag>, IPostTagRepository
{
    public PostTagRepository(SocialSyncDbContext context) : base(context)
    {
    }

    public async Task<bool> ExistsByTagName(string tagName)
    {
        var tag = await _context.Tags.FirstOrDefaultAsync(t => t.TagName == tagName);
        return tag != null;
    }

    public async Task<int> GetTagId(string tagName)
    {
        var tag = await _context.Tags.FirstOrDefaultAsync(t => t.TagName == tagName);
        if (tag == null)
            return -1;
        return tag.Id;
    }
    
    public async Task AddTagToPost(int postId, string tagName)
    {
        var tag = await _context.Tags.FirstOrDefaultAsync(t => t.TagName == tagName);
        if (tag == null)
        {
            tag = new Tag() { TagName = tagName };
            await _context.Tags.AddAsync(tag);
            await _context.SaveChangesAsync();
        }
        
        var tagId = tag.Id;
        await Add(new PostTag() { PostId = postId, TagId = tagId });
    }
        
    public async Task DeletePostTag(int postId, string tagName)
    {
        var tag = await _context.Tags.FirstOrDefaultAsync(t => t.TagName == tagName);
        if (tag == null)
            return;

        await Delete(new PostTag() { PostId = postId, TagId = tag.Id });
    }
}