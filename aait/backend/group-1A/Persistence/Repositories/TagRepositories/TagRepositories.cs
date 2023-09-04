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
        _socialMediaDbContext.Tags.Add(entity);
        _socialMediaDbContext.SaveChanges();
        return Task.FromResult(entity);   
    }


    public Task<bool> Exists(Tag entity)
    {
       var result = _socialMediaDbContext.Tags.Where(x => x.Id == entity.Id).Any();
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

    Task<List<Tag>> ITagRepository.GetAll(int userd)
    {
        var result = _socialMediaDbContext.Tags.ToList();
        return Task.FromResult(result);
    }

    Task<bool> IGenericRepository<Tag>.Delete(Tag entit)
    {
         _socialMediaDbContext.Tags.Remove(entit);
         _socialMediaDbContext.SaveChanges();

        return Task.FromResult(true);        
    }

    Task<Tag?> ITagRepository.GetTagByName(string tag)
    {
        var result = _socialMediaDbContext.Tags.Where(x => x.Title == tag).FirstOrDefault();
        return Task.FromResult(result);
    }
}