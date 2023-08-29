using Application.Contracts;
using Domain.Entities;
using Moq;

namespace Application.Tests.Mocks
{
    public static class MockPostRepository
    {
        public static Mock<IPostRepository> GetPostRepository()
        {
            var posts = new List<Post>()
            {
                new Post(){
                    Id = 1,
                    Content = "post 1",
                    UserId = 1,
                    CreatedAt = DateTime.UtcNow,
                    Title = "post 1 title",
                    Comments = new List<Comment>()
                    {
                        new Comment()
                        {
                            Id = 1,
                            Content = "comment 1",
                            UserId = 1,
                            CreatedAt = DateTime.UtcNow,
                            PostId = 1
                        },
                        new Comment()
                        {
                            Id = 2,
                            Content = "comment 2",
                            UserId = 1,
                            CreatedAt = DateTime.UtcNow,
                            PostId = 1
                        }
                    }

                }
            };

            var mockPostRepository = new Mock<IPostRepository>();
            mockPostRepository.Setup(
                repo => repo.GetAll(
                    It.IsAny<int>() )
                ).ReturnsAsync((int id ) => {
                    return posts.Where( p => p.Id == id ).ToList();
                });

            mockPostRepository.Setup(
                repo => repo.Get(It.IsAny<int>())).
                ReturnsAsync((int id) =>
                    {
                        return posts.FirstOrDefault(post => post.Id == id);
                    });

            mockPostRepository.Setup(
                repo => repo.Add(It.IsAny<Post>())).
                ReturnsAsync(
                    (Post post) =>
                    {
                        posts.Add(post);
                        return post;
                    });

            mockPostRepository.Setup(
                repo => repo.Delete(It.IsAny<Post>())).
                ReturnsAsync(
                    (Post post) =>
                    {
                        posts.Remove(post);
                        return true;
                    });

            mockPostRepository.Setup(
                repo => repo.Update(It.IsAny<Post>())).
                ReturnsAsync(
                    (Post post) =>
                    {
                        var postToUpdate = posts.FirstOrDefault(post => post.Id == post.Id);
                        postToUpdate = post;
                        return postToUpdate;
                    });

            mockPostRepository.Setup(
                repo => repo.Exists(It.IsAny<int>())).
                ReturnsAsync(
                    (int id) =>
                    {
                        return posts.Any(post => post.Id == id);
                    });


            return mockPostRepository;

        }
    }
}