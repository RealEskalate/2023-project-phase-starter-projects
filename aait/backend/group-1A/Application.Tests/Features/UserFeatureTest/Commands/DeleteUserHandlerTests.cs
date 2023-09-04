using Application.Contracts;
using Application.Exceptions;
using Application.Features.UserFeature.Handlers.Commands;
using Application.Features.UserFeature.Requests.Commands;
using Application.Response;
using Application.Tests.Features.UserFeatureTests.Mocks;
using Application.Tests.Mocks;
using Moq;
using Shouldly;

namespace Application.Tests.Features.UserFeatureTests.Commands
{
    public class DeleteUserHandlerTests
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;   

        public DeleteUserHandlerTests()
        {
           _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();
        }

        [Fact]
        public async Task DeleteUserHandler_UserExists_ReturnsSuccessResponse()
        {
            // Arrange
            var handler = new DeleteUserHandler(_mockUnitOfWork.Object);
            var validUserId = 1;  

            var deleteUserCommand = new DeleteUserCommand
            {
                userId = validUserId
            };

            // Act
            var response = await handler.Handle(deleteUserCommand, new CancellationToken());

            // Assert
            response.ShouldBeOfType<BaseResponse<string>>();
            response.Success.ShouldBeTrue();
            response.Message.ShouldBe("User deleted successfully");
        }

        [Fact]
        public async Task DeleteUserHandler_UserDoesNotExist_ThrowsNotFoundException()
        {
            // Arrange
            var handler = new DeleteUserHandler(_mockUnitOfWork.Object);
            var invalidUserId = 999;

            var deleteUserCommand = new DeleteUserCommand
            {
                userId = invalidUserId
            };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<NotFoundException>(() => handler.Handle(deleteUserCommand, new CancellationToken()));
            exception.Message.ShouldBe("user is not found");
        }
    }
}
