using Application.Contracts.Persistance;
using Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Tests.Mocks
{
    public static class MockPostRepository
    {
        public static Mock<IPostRepository> GetPostRepository()
        {
            int userId = 1;
            var mockPosts = new List<Domain.Entities.Post>
            {
                new Domain.Entities.Post
                {
                    Id = 1,
                    UserId = 2,
                    Content = "Content 1",
                    Tags = new List<string>{"tag1", "tag2"},
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Domain.Entities.Post
                {
                    Id = 2,
                    UserId = userId,
                    Content = "Content 2",
                    Tags = new List<string>{"tag1", "tag2"},
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Domain.Entities.Post
                {
                    Id = 3,
                    UserId = userId,
                    Content = "Content 3",
                    Tags = new List<string>{"tag1", "tag2"},
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Domain.Entities.Post
                {
                    Id = 4,
                    UserId = 2,
                    Content = "Content 4",
                    Tags = new List<string>{"tag1", "tag3"},
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },

            };

            var mockRepository = new Mock<IPostRepository>();

            mockRepository.Setup(repo => repo.GetFollowingPost(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()))
                          .ReturnsAsync((int id,int pageNumber, int pageSize) => mockPosts.Where(p => p.UserId == id).ToList());

            mockRepository.Setup(repo => repo.GetUserPost(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()))
                          .ReturnsAsync((int id,int pageNumber, int pageSize) => mockPosts.Where(p => p.UserId == id).ToList());

            mockRepository.Setup(repo => repo.GetBytag(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()))
                          .ReturnsAsync((string tag,int pageNumber, int pageSize) => mockPosts.Where(p => p.Tags.Contains(tag)).ToList());

            mockRepository.Setup(repo => repo.GetByContent(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()))
                          .ReturnsAsync((string content,int pageNumber, int pageSize) => mockPosts.Where(p => p.Content.Contains(content)).ToList());

            mockRepository.Setup(repo => repo.Get(It.IsAny<int>()))
                          .ReturnsAsync((int id) => mockPosts.FirstOrDefault(p => p.Id == id));

            mockRepository.Setup(repo => repo.GetAll(It.IsAny<int>(), It.IsAny<int>()))
                          .ReturnsAsync((int pageNumber,int pageSize)=>mockPosts);

            mockRepository.Setup(repo => repo.Add(It.IsAny<Domain.Entities.Post>()))
                          .ReturnsAsync((Domain.Entities.Post post) =>
                          {
                              post.Id = mockPosts.Max(p => p.Id) + 1;
                              mockPosts.Add(post);
                              MockUnitOfWorkRepository.Changes += 1;
                              return post;
                          });

            mockRepository.Setup(repo => repo.Exists(It.IsAny<int>()))
                          .ReturnsAsync((int id) => mockPosts.Any(p => p.Id == id));

            mockRepository.Setup(repo => repo.Update(It.IsAny<Domain.Entities.Post>()))
                          .Returns(Task.CompletedTask)
                          .Callback((Domain.Entities.Post post) =>
                          {
                              var existingPost = mockPosts.FirstOrDefault(p => p.Id == post.Id);
                              if (existingPost != null)
                              {
                                  existingPost.Content = post.Content;
                                  existingPost.UpdatedAt = DateTime.Now;
                              }
                              MockUnitOfWorkRepository.Changes += 1;
                          });

            mockRepository.Setup(repo => repo.Delete(It.IsAny<Domain.Entities.Post>()))
                          .Returns(Task.CompletedTask)
                          .Callback((Domain.Entities.Post post) =>
                          {
                              var existingPost = mockPosts.FirstOrDefault(p => p.Id == post.Id);
                              if (existingPost != null)
                              {
                                  mockPosts.Remove(existingPost);
                              }
                              MockUnitOfWorkRepository.Changes += 1;
                          });

            return mockRepository;
        }
    }
}
