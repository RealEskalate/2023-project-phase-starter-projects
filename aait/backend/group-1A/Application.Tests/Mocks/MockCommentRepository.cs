using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Domain.Entities;
using Moq;
using Application.Contracts;

namespace Application.Tests.Mocks
{
    public static class MockCommentRepository
    {
        public static Mock<ICommentRepository> GetCommentRepository()
        {
            var comments = new List<Comment>()
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
            };

            var mockCommentRepository = new Mock<ICommentRepository>();
            mockCommentRepository.Setup(
                repo => repo.GetAll(It.IsAny<int>())
                ).ReturnsAsync((int Id) =>
                {
                    return comments.Where(c => c.UserId == Id).ToList();
                });

            mockCommentRepository.Setup(
                repo => repo.Get(It.IsAny<int>())).
                ReturnsAsync(
                    (int id) =>
                    comments.FirstOrDefault(comment => comment.Id == id));

            mockCommentRepository.Setup(
                repo => repo.Add(It.IsAny<Comment>())).
                ReturnsAsync(
                    (Comment comment) =>
                    {
                        comments.Add(comment);
                        return comment;
                    });

            mockCommentRepository.Setup(
                repo => repo.Delete(It.IsAny<Comment>())).
                ReturnsAsync(
                    (Comment comment) =>
                    {
                        comments.Remove(comment);
                        return true;
                    });

            mockCommentRepository.Setup(
                repo => repo.Update(It.IsAny<Comment>())).
                ReturnsAsync(
                    (Comment comment) =>
                    {
                        var commentToUpdate = comments.FirstOrDefault(c => c.Id == comment.Id);
                        if (commentToUpdate != null)
                        {
                            commentToUpdate.Content = comment.Content;
                        }
                        return commentToUpdate;
                    });

            mockCommentRepository.Setup(
                repo => repo.Exists(It.IsAny<int>())).
                ReturnsAsync(
                    (int id) =>
                    {
                        return comments.Any(comment => comment.Id == id);
                    });

            return mockCommentRepository;
        }
    }
}
