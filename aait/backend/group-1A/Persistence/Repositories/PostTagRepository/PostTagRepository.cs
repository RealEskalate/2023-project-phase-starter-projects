
using Persistence;
using SocialSync.Application.Contracts;
using SocialSync.Domain.Entities;

namespace SocialSync.Persistnece.Repositories;

public class PostTagRepository : IPostTagRepository
{
    private readonly SocialMediaDbContext _socialMediaDbContext;

    public PostTagRepository(SocialMediaDbContext socialMediaDbContext)
    {
        _socialMediaDbContext = socialMediaDbContext;
    }

    public Task<bool> Add(PostTag entity)
    {
        _socialMediaDbContext.PostTags.Add(entity);
        _socialMediaDbContext.SaveChanges();
        return Task.FromResult(true);
    }

    public Task<bool> Delete(PostTag entity)
    {
        _socialMediaDbContext.PostTags.Remove(entity);
        _socialMediaDbContext.SaveChanges();
        return Task.FromResult(true);
    }

    public Task<bool> Exists(PostTag entity)
    {
        var result = _socialMediaDbContext.PostTags.Where(x => x.TagId == entity.TagId && x.PostId == entity.PostId).Any();
        return Task.FromResult(result);
    }
}