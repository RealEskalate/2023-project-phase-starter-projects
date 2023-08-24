using System.Linq.Expressions;
using SocialSync.Application.Contracts;
using SocialSync.Domain.Entities;

namespace SocialSync.Persistnece.Repositories;

public class TagReposiotry : ITagRepository
{
    public Task<Tag> Add(Tag entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(Tag entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Exists(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Tag>> GetAll(Expression<Func<Tag, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public Task<Tag> Update(Tag entity)
    {
        throw new NotImplementedException();
    }
}