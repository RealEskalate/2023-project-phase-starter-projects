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
        throw new NotImplementedException();
    }

    public Task<bool> Exists(int id)
    {
        throw new NotImplementedException();
    }


    public Task<Tag> Update(Tag entity)
    {
        throw new NotImplementedException();
    }
   public Task<List<Tag>>  GetAll(Expression<Func<Tag, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    Task<List<Tag>> ITagRepository.GetAll()
    {
        // var result =   _socialMediaDbContext.Tags.All();
        // return Task.FromResult()
        throw new NotImplementedException();
        
    }
}