using System.Linq.Expressions;
using Application.Contracts;
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
        _socialMediaDbContext.Tags.Add(entity);
        _socialMediaDbContext.SaveChanges();
        return Task.FromResult(entity);
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
       var result = _socialMediaDbContext.Tags.Where(x => x.Id == id).Any();
         return Task.FromResult(result);
    }


    public Task<Tag> Update(Tag entity)
    {
        _socialMediaDbContext.Tags.Update(entity);
        _socialMediaDbContext.SaveChanges();
        return Task.FromResult(entity);
    }
   public Task<List<Tag>>  GetAll(Expression<Func<Tag, bool>> predicate)
    {
        var result = _socialMediaDbContext.Tags.Where(predicate).ToList();
        return Task.FromResult(result);
    }

    Task<List<Tag>> ITagRepository.GetAll()
    {
        var result = _socialMediaDbContext.Tags.ToList();
        return Task.FromResult(result);
        
    }
}