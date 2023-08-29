using Application.DTOs.Posts;
using Domain.Entities;

namespace Application.Contracts.Persistence;

public interface ITagRepository : IGenericRepository<Tag>
{
    Task<bool> ExistsByTagName(string tagName);
    Task<Tag> GetByTagName(string tagName);
    Task AddTag(TagNameDto tagNameDto);
}