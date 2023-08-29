using SocialMediaApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.Persistence.Contracts;


public interface IPostRepository:IGenericRepository<Post>

{
    Task<List<Post>> GetPosts(Guid userId);
    Task<Post> GetPostDetails(Guid userId, Guid id);
    Task<List<Post>> GetPostForNewsFeed(Guid UserId);
    Task<List<Post>> SearchPosts(string query);
}
