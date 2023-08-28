using Application.Contracts;
using SocialSync.Domain.Entities;

namespace SocialSync.Application.Contracts;

public interface ITagRepository : IGenericRepository<Tag>
{
    public Task<List<Tag>> GetAll(int userId);

    public Task<bool> Exists(Tag entity);

    public Task<Tag?> GetTagByName(string tag);
}