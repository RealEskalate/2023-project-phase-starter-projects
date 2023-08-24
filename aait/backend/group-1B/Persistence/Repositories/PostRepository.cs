using Application.Contracts.Persistence;
using Application.Features.Comments.Requests.Queries;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class PostRepository : GenericRepository<Post>, IPostRepository
{
    public PostRepository(SocialSyncDbContext context) : base(context)
    {
    }

    private List<string> GetTags(string content)
    {
        var split = content.ToLower().Split(" ");
        var query = from word in split
            where word[0].ToString() == "#"
            select word.Substring(1, word.Length - 1);

        return new HashSet<string>(query).ToList();
    }
    
    private (List<string>, List<string>) GetTagDifferences(List<string> aroge, List<string> addis)
    {
        var oldMap = new HashSet<string>(aroge);
        var newMap = new HashSet<string>(addis);

        var added = new List<string>();
        var deleted = new List<string>();

        foreach (var tag in aroge)
        {
            if (!newMap.Contains(tag))
                deleted.Add(tag);
        }

        foreach (var tag in addis)
        {
            if (!oldMap.Contains(tag))
                added.Add(tag);
        }

        return (added, deleted);
    }

    private async Task AddTagToPost(int postId, string tagName)
    {
        var tag = await _context.Tags.FirstOrDefaultAsync(t => t.TagName == tagName);
        if (tag == null)
        {
            tag = new Tag() { TagName = tagName };
            await _context.Tags.AddAsync(tag);
            await _context.SaveChangesAsync();
        }
        
        var tagId = tag.Id;
        _context.PostTags.Add(new PostTag() { PostId = postId, TagId = tagId });
        await _context.SaveChangesAsync();
    }

    private async Task DeletePostTag(int postId, string tagName)
    {
        var tag = await _context.Tags.FirstOrDefaultAsync(t => t.TagName == tagName);
        if (tag == null)
            return;

        _context.Remove(new PostTag() { PostId = postId, TagId = tag.Id });
        await _context.SaveChangesAsync();
    }

    public new async Task<Post> Add(Post item)
    {
         await _context.Posts.AddAsync(item);
         await _context.SaveChangesAsync();
         
         var tags = GetTags(item.Content);

        foreach (var tag in tags)
        {
            await AddTagToPost(item.Id, tag);
        }

        return item;
    }

    public new async Task<Post> Update(Post item)
    {
        var oldPost = await _context.Posts.FindAsync(item.Id);
        
        var oldTags = GetTags(oldPost.Content);
        var newTags = GetTags(item.Content);
        var differences = GetTagDifferences(oldTags, newTags);

        oldPost.Title = item.Title;
        oldPost.Content = item.Content;
        await _context.SaveChangesAsync();

        foreach (var addedTag in differences.Item1)
        {
            await AddTagToPost(item.Id, addedTag);
        }

        foreach (var removedTag in differences.Item2)
        {
            await DeletePostTag(item.Id, removedTag);
        }

        return item;
    }

    public async Task<List<Post>> GetByTag(string tagName)
    {
        var tag = await _context.Tags.FirstOrDefaultAsync(t => t.TagName == tagName);
        if (tag == null)
            return new List<Post>();
        
        var tagId = tag.Id;

        var query = from post in _context.Posts
            join postId in
                (from pTag in _context.PostTags 
                    where pTag.TagId == tagId 
                    select pTag.PostId)
                on post.Id equals postId
            select post;

        var posts = await query.ToListAsync();
        return posts;
    }

    public async Task<List<Post>> GetByUserId(int userId)
    {
        var posts = await _context.Posts
            .Where(post => post.UserId == userId).ToListAsync();

        return posts;
    }

    public async Task<List<Post>> GetPostsFromFollowing(int userId)
    {
        var query = from post in _context.Posts
            where (from follow in _context.Follows where follow.FollowerId == userId select follow.FolloweeId)
                .Contains(post.UserId)
            select post;

        return await query.ToListAsync();
    }
}