using Application.Contracts;
using SocialSync.Domain.Entities;

namespace SocialSync.Application.Contracts;

public interface IPostTagRepository 
{
    public Task<bool> Add(PostTag entity);

    public Task<bool> Exists(PostTag entity);

    public Task<bool> Delete(PostTag entity);

}