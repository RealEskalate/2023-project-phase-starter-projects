using Application.Contracts.Persistance;
using Domain.Entities;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Tests.Mocks
{
    public static class MockFollowRepository
    {
        public static Mock<IFollowRepository> GetFollowRepository()
        {
            var mockRepository = new Mock<IFollowRepository>();

            var mockFollows = GetMockFollow();

            mockRepository.Setup(repo => repo.GetFollowing(It.IsAny<int>(), It.IsAny<int>(),It.IsAny<int>()))
                          .ReturnsAsync((int id,int pageNumber, int pageSize) =>
                          {
                              var followedIds = mockFollows.Where(f => f.FollowerId == id).Select(f => f.FollowedId).ToList();
                              return GetMockUsers().Where(u => followedIds.Contains(u.Id)).ToList();
                          });

            mockRepository.Setup(repo => repo.GetFollower(It.IsAny<int>(),It.IsAny<int>(),It.IsAny<int>()))
                          .ReturnsAsync((int id,int pageNumber, int pageSize) =>
                          {
                              var followerIds = mockFollows.Where(f => f.FollowedId == id).Select(f => f.FollowerId).ToList();
                              return GetMockUsers().Where(u => followerIds.Contains(u.Id)).ToList();
                          });

            mockRepository.Setup(repo => repo.Follow(It.IsAny<Domain.Entities.Follow>()))
                          .Returns(Task.CompletedTask)
                          .Callback(() =>{ MockUnitOfWorkRepository.Changes += 1; });

            mockRepository.Setup(repo => repo.Unfollow(It.IsAny<Domain.Entities.Follow>()))
                          .Returns(Task.CompletedTask);

            mockRepository.Setup(repo => repo.FollowRelationshipExists(It.IsAny<int>(), It.IsAny<int>()))
              .ReturnsAsync((int followerId, int followedId) =>
              {
                  return mockFollows.Any(f => f.FollowerId == followerId && f.FollowedId == followedId);
              });

            return mockRepository;
        }

        public static List<Domain.Entities.Follow> GetMockFollow()
        {
            return new List<Domain.Entities.Follow>
            {
                new Domain.Entities.Follow { FollowerId = 1, FollowedId = 2 },
                new Domain.Entities.Follow { FollowerId = 1, FollowedId = 3 },
                new Domain.Entities.Follow { FollowerId = 2, FollowedId = 1 },
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
    }
}
