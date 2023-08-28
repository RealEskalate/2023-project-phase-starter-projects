using System.Linq.Expressions;
using Application.Contracts;
using Application.Exceptions;
using Persistence;
using SocialSync.Application.Contracts;
using SocialSync.Domain.Entities;

namespace SocialSync.Persistnece.Repositories;

public class TagReposiotry : ITagRepository
{

    private readonly SocialMediaDbContext _socialMediaDbContext;

    public TagReposiotry(SocialMediaDbContext socialMediaDbContext)
    {
        _socialMediaDbContext = socialMediaDbContext;
    }
    public Task<Tag> Add(Tag entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(Tag entity)
    {
        //delete tag
        _socialMediaDbContext.Tags.Remove(entity);
        _socialMediaDbContext.SaveChanges();
        return Task.FromResult(true);
    }

    public Task<bool> Exists(int id)
    {
        var result = _socialMediaDbContext.Tags.Where(x => x.Title == tag).FirstOrDefault();
        return Task.FromResult(result);
    }

    public Task<List<Tag>> GetAll()
    {
        var result = _socialMediaDbContext.Tags.ToList();
        return Task.FromResult(result);
    }

    public Task<List<Tag>> GetAll(int userId)
    {
        var result = _socialMediaDbContext.Tags.ToList();
        return Task.FromResult(result);
        
    }
}