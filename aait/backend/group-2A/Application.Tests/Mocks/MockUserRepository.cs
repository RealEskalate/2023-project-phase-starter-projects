using Application.Contracts.Persistance;
using Domain.Entities;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Tests.Mocks
{
    public static class MockUserRepository
    {
        public static Mock<IUserRepository> GetUserRepository()
        {
            var mockUsers = new List<User>
            {
                new User { Id = 1, FullName = "User One", UserName = "user1", Email = "user1@example.com" },
                new User { Id = 2, FullName = "User Two", UserName = "user2", Email = "user2@example.com" },
                new User { Id = 3, FullName = "User Three", UserName = "user3", Email = "user3@example.com" },
            };

            var mockRepository = new Mock<IUserRepository>();

            mockRepository.Setup(repo => repo.Get(It.IsAny<int>()))
                .ReturnsAsync((int id) => mockUsers.FirstOrDefault(u => u.Id == id));

            mockRepository.Setup(repo => repo.GetAll(It.IsAny<int>(),It.IsAny<int>()))
                .ReturnsAsync(mockUsers);

            mockRepository.Setup(repo => repo.Add(It.IsAny<User>()))
                .ReturnsAsync((User user) =>
                {
                    user.Id = mockUsers.Max(u => u.Id) + 1;
                    mockUsers.Add(user);
                    MockUnitOfWorkRepository.Changes += 1;
                    return user;
                });

            mockRepository.Setup(repo => repo.Exists(It.IsAny<int>()))
                .ReturnsAsync((int id) => mockUsers.Any(u => u.Id == id));

            mockRepository.Setup(repo => repo.Update(It.IsAny<User>()))
                .Callback((User user) =>
                {
                    var existingUser = mockUsers.FirstOrDefault(u => u.Id == user.Id);
                    if (existingUser != null)
                    {
                        existingUser.FullName = user.FullName;
                        existingUser.UserName = user.UserName;
                        existingUser.Email = user.Email;
                    }
                });

            mockRepository.Setup(repo => repo.Delete(It.IsAny<User>()))
                .Callback((User user) =>
                {
                    var existingUser = mockUsers.FirstOrDefault(u => u.Id == user.Id);
                    if (existingUser != null)
                    {
                        mockUsers.Remove(existingUser);
                    }
                });

            mockRepository.Setup(repo => repo.Search(It.IsAny<string>(), It.IsAny<int>(),It.IsAny<int>()))
                .ReturnsAsync((string name, int pageNumber, int pageSize) => mockUsers
                    .Where(u => u.FullName.Contains(name) || u.UserName.Contains(name))
                    .ToList());

            mockRepository.Setup(repo => repo.GetUserByEmail(It.IsAny<string>()))
                .ReturnsAsync((string email) => mockUsers.FirstOrDefault(u => u.Email == email));

            mockRepository.Setup(repo => repo.GetUserByUserName(It.IsAny<string>()))
                .ReturnsAsync((string userName) => mockUsers.FirstOrDefault(u => u.UserName == userName));

            return mockRepository;
        }
    }
}
