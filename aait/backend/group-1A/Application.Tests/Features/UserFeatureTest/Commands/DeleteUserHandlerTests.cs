using Application.Contracts;
using Application.Exceptions;
using Application.Features.UserFeature.Handlers.Commands;
using Application.Features.UserFeature.Requests.Commands;
using Application.Tests.Features.UserFeatureTests.Mocks;
using Moq;
using Shouldly;

namespace Application.Tests.Features.UserFeatureTests.Commands
{
    public class DeleteUserHandlerTests
    {
        private readonly Mock<IUserRepository> _mockUserRepository;
        
        public DeleteUserHandlerTests()
        {
            _mockUserRepository = UserRepositoryMock.GetRepository();
        }

        [Fact]
        public async Task DeleteUserHandler_UserExists_ReturnsSuccessResponse()
        {
            // Arrange
            var handler = new DeleteUserHandler(_mockUserRepository.Object);
            var validUserId = 1;  // Assuming 1 is an ID that exists in our mock data

            var deleteUserCommand = new DeleteUserCommand
            {
                userId = validUserId
            };

            // Act
            var response = await handler.Handle(deleteUserCommand, new CancellationToken());

            // Assert
            response.Success.ShouldBeTrue();
            response.Message.ShouldBe("User deleted successfully");
        }

        [Fact]
        public async Task DeleteUserHandler_UserDoesNotExist_ThrowsNotFoundException()
        {
            // Arrange
            var handler = new DeleteUserHandler(_mockUserRepository.Object);
            var invalidUserId = 999;  // Assuming 999 is an ID that doesn't exist in our mock data

            var deleteUserCommand = new DeleteUserCommand
            {
                userId = invalidUserId
            };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<NotFoundException>(() => handler.Handle(deleteUserCommand, new CancellationToken()));

            // Checking if the exception message is as expected
            exception.Message.ShouldBe("user is not found");
        }
    }
}
