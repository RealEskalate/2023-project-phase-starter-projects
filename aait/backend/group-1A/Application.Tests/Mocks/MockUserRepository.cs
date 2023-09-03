using Moq;
using Application.Contracts;
using SocialSync.Domain.Entities;

namespace Application.Tests.Features.UserFeatureTests.Mocks
{
    public static class MockUserRepository
    {
        public static Mock<IUserRepository> GetUserRepository()
        {
            var mock = new Mock<IUserRepository>();
            
            // Sample data
            var users = new List<User>
            {
                new User 
                { 
                    Id = 1, 
                    FirstName = "John", 
                    LastName = "Doe", 
                    Username = "JohnDoe89",
                    Email = "john.doe@example.com", 
                    Password = "password123",
                    Bio = "A software engineer with over 5 years of experience."
                },
                new User 
                { 
                    Id = 2, 
                    FirstName = "Jane", 
                    LastName = "Smith", 
                    Username = "JaneSmith92",
                    Email = "jane.smith@example.com", 
                    Password = "securepassword",
                    Bio = "A digital marketer who loves technology."
                }
            };

            // Mock the GetAllUsers method to return the sample data
            mock.Setup(repo => repo.GetAllUsers()).ReturnsAsync(users);

            // Mock the Get method to return a user based on the ID
            mock.Setup(repo => repo.Get(It.IsAny<int>()))
                .ReturnsAsync((int id) => users.FirstOrDefault(u => u.Id == id));

            // Mock the Add method to simulate adding a user
            mock.Setup(repo => repo.Add(It.IsAny<User>())).ReturnsAsync((User user) =>
            {
                user.Id = users.Max(u => u.Id) + 1;  // Simulating ID generation
                users.Add(user);
                return user;
            });

            // Mock the Update method to simulate updating a user
            mock.Setup(repo => repo.Update(It.IsAny<User>())).ReturnsAsync((User user) =>
            {
                var existingUser = users.FirstOrDefault(u => u.Id == user.Id);
                if (existingUser == null)
                {
                    return null;
                }
                users.Remove(existingUser);
                users.Add(user);
                return user;
            });

            // Mock the Delete method to simulate deleting a user
            mock.Setup(repo => repo.Delete(It.IsAny<User>())).ReturnsAsync((User user) =>
            {
                var existingUser = users.FirstOrDefault(u => u.Id == user.Id);
                if (existingUser == null)
                {
                    return false;
                }
                users.Remove(existingUser);
                return true;
            });

            return mock;
        }
    }
}