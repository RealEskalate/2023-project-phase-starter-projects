using Application.Contracts.Persistance;
using Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tests.Mocks
{
    public static class MockCommentRepository
    {
        public static Mock<ICommentRepository> GetCommentRepository()
        {
            int postId = 1;
            int userId = 1;
            var mockComments = new List<Comment>
            {
                new Comment
                {
                    Id = 1,
                    Content = "Comment 1",
                    PostId = postId,
                    UserId = userId,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Comment
                {
                    Id = 2,
                    Content = "Comment 2",
                    PostId = postId,
                    UserId = userId,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Comment
                {
                    Id = 3,
                    Content = "Comment 3",
                    PostId = postId,
                    UserId = 2,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Comment
                {
                    Id = 4,
                    Content = "Comment 4",
                    PostId = 2,
                    UserId = 2,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
            };

            var mockRepository = new Mock<ICommentRepository>();

            mockRepository.Setup(repo => repo.GetCommentByPost(It.IsAny<int>(), It.IsAny<int>(),It.IsAny<int>()
                ))
                          .ReturnsAsync((int postId,int pageNumber, int pageSize) => mockComments.Where(c => c.PostId == postId).ToList());
            

            mockRepository.Setup(repo => repo.Get(It.IsAny<int>()))
                          .ReturnsAsync((int id) => mockComments.FirstOrDefault(c => c.Id == id));

            mockRepository.Setup(repo => repo.GetAll(It.IsAny<int>(),It.IsAny<int>()))
                          .ReturnsAsync((int pageNumber, int pageSize)=>mockComments);

            mockRepository.Setup(repo => repo.Add(It.IsAny<Comment>()))
                          .ReturnsAsync((Comment comment) =>
                          {
                              comment.Id = mockComments.Max(c => c.Id) + 1;
                              mockComments.Add(comment);
                              MockUnitOfWorkRepository.Changes += 1;
                              return comment;
                          });

            mockRepository.Setup(repo => repo.Exists(It.IsAny<int>()))
                          .ReturnsAsync((int id) => mockComments.Any(c => c.Id == id));

            mockRepository.Setup(repo => repo.Update(It.IsAny<Comment>()))
                          .Returns(Task.CompletedTask)
                          .Callback((Comment comment) =>
                          {
                              var existingComment = mockComments.FirstOrDefault(c => c.Id == comment.Id);
                              if (existingComment != null)
                              {
                                  existingComment.Content = comment.Content;
                                  existingComment.UpdatedAt = DateTime.Now;
                              }
                              MockUnitOfWorkRepository.Changes += 1;
                          });

            mockRepository.Setup(repo => repo.Delete(It.IsAny<Comment>()))
                          .Returns(Task.CompletedTask)
                          .Callback((Comment comment) =>
                          {
                              var existingComment = mockComments.FirstOrDefault(c => c.Id == comment.Id);
                              if (existingComment != null)
                              {
                                  mockComments.Remove(existingComment);
                              }
                              MockUnitOfWorkRepository.Changes += 1;
                          });

            return mockRepository;
        }

    }
}
