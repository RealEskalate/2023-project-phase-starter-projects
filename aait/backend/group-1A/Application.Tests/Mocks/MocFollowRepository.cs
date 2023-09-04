using Application.Contracts;
using Application.DTO.FollowDTo;
using Application.Tests.Features.UserFeatureTests.Mocks;
using Domain.Entites;
using Moq;

namespace Application.Tests.Mocs
{
    public static class MockFollowRepository
    {
        public static Mock<IFollowRepository> GetFollowRepository()
        {
            var Follows = new List<Follow>
            {
                new Follow
                {
                    FolloweeId = 2,
                    FollowerId = 1,
                },
                new Follow
                {
                    FolloweeId = 3,
                    FollowerId = 1,
                },
                new Follow
                {
                    FolloweeId = 1,
                    FollowerId = 2,
                },
            };



            var mockRepo = new Mock<IFollowRepository>();
            var mockUserRepo = MockUserRepository.GetUserRepository();

            mockRepo.Setup(r => r.AddFollow(It.IsAny<Follow>())).ReturnsAsync((Follow Follow) => 
            {
                Follows.Add(Follow);
                return Follow;
            });

            mockRepo.Setup(r => r.GetAll()).ReturnsAsync(() => 
            {
                return Follows;
            });
            

            mockRepo.Setup(r => r.DeleteFollow(It.IsAny<Follow>())).Callback((Follow follow) => 
            {
                foreach(var f in Follows)
                {
                    if (f.FolloweeId == follow.FolloweeId && f.FollowerId == follow.FollowerId)
                    {
                        follow = f;
                    }   
                }
                Follows.Remove(follow);
            });

            mockRepo.Setup(r => r.GetFollowedUsers(It.IsAny<int>() )).ReturnsAsync((int Id) => 
            {
                var followedUsersId = Follows.Where(f => f.FollowerId == Id).Select(f => f.FolloweeId).ToList();
                var users = followedUsersId.Select(Id => mockUserRepo.Object.Get(Id)!.Result);
                return users.ToList();
            });

            mockRepo.Setup(r => r.GetFollowers(It.IsAny<int>() )).ReturnsAsync((int Id) => 
            {
                var followersId = Follows.Where(f => f.FolloweeId == Id).Select(f => f.FollowerId).ToList();
                var users = followersId.Select(Id => mockUserRepo.Object.Get(Id)!.Result);
                return users.ToList();
            });

            mockRepo.Setup(r => r.Get(It.IsAny<FollowDTO>() )).ReturnsAsync((FollowDTO follow) => 
            {
               return Follows.Where(f => f.FolloweeId == follow.FolloweeId && f.FollowerId == follow.FollowerId).FirstOrDefault();
            });

            return mockRepo;

        }
    }
}