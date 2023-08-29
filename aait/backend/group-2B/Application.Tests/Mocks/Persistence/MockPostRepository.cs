using Moq;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Domain.Entities;

namespace SocialSync.Application.Tests.Mocks;
    public class MockPostRepository
    {
        public static Mock<IPostRepository> GetPostRepository()
        {
            var posts = new List<Post>
            {
                new Post
                {
                    Id = 1,
                    UserId = 2,
                    Content = "First Post",
                    CreatedAt = DateTime.UtcNow.Date,
                    LastModified = DateTime.UtcNow.Date
                },
                new Post
                {
                    Id = 2,
                    UserId = 3,
                    Content = "Second Post #tag1",
                    CreatedAt = DateTime.UtcNow.Date,
                    LastModified = DateTime.UtcNow.Date
                },
                new Post
                {
                    Id = 3,
                    UserId = 2,
                    Content = "Third Post",
                    CreatedAt = DateTime.UtcNow.Date,
                    LastModified = DateTime.UtcNow.Date
                },
                new Post
                {
                    Id = 4,
                    UserId = 1,
                    Content = "Fourth Post #tag2",
                    CreatedAt = DateTime.UtcNow.Date,
                    LastModified = DateTime.UtcNow.Date
                }
            };

            var postRepo = new Mock<IPostRepository>();

            postRepo.Setup(repo => repo.AddAsync(It.IsAny<Post>()))
                .ReturnsAsync((Post post) =>
                {
                    post.Id = posts.Count + 1;
                    posts.Add(post);
                    return post;
                });

        postRepo.Setup(repo => repo.GetAsync(It.IsAny<int>()))
                .ReturnsAsync((int id) => posts.FirstOrDefault(p => p.Id == id));

            postRepo.Setup(repo => repo.GetAsync())
                .ReturnsAsync(posts);

            postRepo.Setup(repo => repo.UpdateAsync(It.IsAny<Post>()))
                .Callback((Post p) =>
                {
                    var existingPost = posts.FirstOrDefault(q => q.Id == p.Id);
                    if (existingPost != null)
                    {
                        existingPost.Content = p.Content;
                        existingPost.UserId = p.UserId;
                    }
                });

            postRepo.Setup(repo => repo.DeleteAsync(It.IsAny<Post>()))
                .Callback((Post q) =>
                {
                    posts.RemoveAll(p => p.Id == q.Id);
                });

            postRepo.Setup(repo => repo.GetPostsByTagsAsync(It.IsAny<List<string>>()))
                .ReturnsAsync((List<string> tags) => posts.Where(p => tags.Any(t => p.Content.Contains(t))).ToList());


            postRepo.Setup(repo => repo.GetPostsByUserIdAsync(It.IsAny<int>()))
                .ReturnsAsync((int userId) => posts.Where(p => p.UserId == userId).ToList());

            postRepo.Setup(repo => repo.ExistsAsync(It.IsAny<int>()))
                .ReturnsAsync((int id) => {
                    var post = posts.FirstOrDefault(p=> p.Id == id);
                    return post!=null;
                });


            return postRepo;
        }
    }

