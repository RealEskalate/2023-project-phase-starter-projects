using Application.Contracts;
using Moq;
using SocialSync.Domain.Entities;

namespace Application.Tests.Mocs
{
    public static class MockUserRepository
    {
        public static Mock<IUserRepository> GetUserRepository()
        {
            var Users = new List<User>
            {
                new User
                {
                    Id = 1
                },
                new User
                {
                Id = 2
                },
                new User
                {
                    Id = 3
                },
            };

            var mockRepo = new  Mock<IUserRepository>();

            mockRepo.Setup(r => r.Get(It.IsAny<int>())).ReturnsAsync((int Id) =>
            {
                foreach (var user in Users)
                {
                    if (user.Id == Id)
                    {
                        return user;
                    }
                }

                return null;                
            });

            mockRepo.Setup(r => r.Exists(It.IsAny<int>())).ReturnsAsync((int Id) =>
            {
                Console.WriteLine("GETS  USER MOC");
                foreach (var user in Users)
                {
                    if (user.Id == Id)
                    {
                        return true;
                    }
                }

                return false;                
            });

            return mockRepo;
        }
    }

}