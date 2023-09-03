using Application.Contracts.Persistance;
using Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Tests.Mocks
{
    public static class MockLikeRepository
    {
        public static Mock<ILikeRepository> GetLikeRepository()
        {
            var mockRepository = new Mock<ILikeRepository>();

            mockRepository.Setup(repo => repo.isLiked(It.IsAny<Domain.Entities.Like>()))
                          .ReturnsAsync((Domain.Entities.Like like) => GetMockLikes().Any(l => l.PostId == like.PostId && l.UserId == like.UserId));

            mockRepository.Setup(repo => repo.GetLikers(It.IsAny<int>(),It.IsAny<int>(),It.IsAny<int>()))
                          .ReturnsAsync((int id,int pageNumber, int pageSize) => GetMockUsers().Where(u => GetMockLikes().Any(l => l.PostId == id && l.UserId == u.Id)).ToList());

            mockRepository.Setup(repo => repo.LikePost(It.IsAny<Domain.Entities.Like>()))
                          .Returns(Task.CompletedTask)
                          .Callback(() => { MockUnitOfWorkRepository.Changes += 1; });

            mockRepository.Setup(repo => repo.UnlikePost(It.IsAny<Domain.Entities.Like>()))
                          .Returns(Task.CompletedTask)
                          .Callback(() => { MockUnitOfWorkRepository.Changes += 1; });


            mockRepository.Setup(repo => repo.GetLikedPost(It.IsAny<int>(),It.IsAny<int>(),It.IsAny<int>()))
                          .ReturnsAsync((int id,int pageNumber, int pageSize) => GetMockPosts().Where(p => GetMockLikes().Any(l => l.UserId == id && l.PostId == p.Id)).ToList());

            return mockRepository;
        }

        private static List<Domain.Entities.Like> GetMockLikes()
        {
            return new List<Domain.Entities.Like>
            {
                new Domain.Entities.Like { UserId = 1, PostId = 1 },
                new Domain.Entities.Like { UserId = 2, PostId = 1 },
                new Domain.Entities.Like { UserId = 1, PostId = 3 },
            };
        }

        private static List<User> GetMockUsers()
        {
            return new List<User>
            {
                new User { Id = 1, FullName = "User 1", UserName = "U1", Email = "U1@gmail.com" },
                new User { Id = 2, FullName = "User 2", UserName = "U2", Email = "U2@gmail.com" },
                new User { Id = 3, FullName = "User 3", UserName = "U3", Email = "U3@gmail.com" },
            };
        }

        private static List<Domain.Entities.Post> GetMockPosts()
        {
            return new List<Domain.Entities.Post>
            {
                new Domain.Entities.Post { Id = 1, UserId = 1, Content = "Post 1" },
                new Domain.Entities.Post { Id = 2, UserId = 2, Content = "Post 2" },
                new Domain.Entities.Post { Id = 3, UserId = 3, Content = "Post 3" },
                new Domain.Entities.Post { Id = 4, UserId = 3, Content = "Post 4" },
            };
        }
    }
}
