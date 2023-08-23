using Moq;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Domain.Entities;

namespace SocialSync.Application.Tests.UnitTests.Mocks;

public class MockPostRepository{


    public static Mock<IPostRepository> GetRepository(){

        List<Post> posts = new List<Post>{
            new Post
                {
                    Id = 1,
                    UserId = 3,
                    Content = "First Post"
                },
                new Post
                {
                    Id = 2,
                    UserId = 5,
                    Content = "Second Post"
                },
                new Post
                {
                    Id = 3,
                    UserId = 2,
                    Content = "Third Post"
                },
                new Post
                {
                    Id = 4,
                    UserId = 1,
                    Content = "Fourth Post"
                }
        };

        var postRepo =  new Mock<IPostRepository>();
        postRepo.Setup(repo => repo.AddAsync(It.IsAny<Post>())).ReturnsAsync((Post post) => {
            post.Id = posts.Count+1;
            posts.Add(post);
            return post;
        });
        // postRepo.Setup(repo => repo.GetAsync(It.IsAny<int>())).ReturnsAsync((int Id) => posts.FirstOrDefault(p => p.Id == Id));
        
        return postRepo;
    }


}
