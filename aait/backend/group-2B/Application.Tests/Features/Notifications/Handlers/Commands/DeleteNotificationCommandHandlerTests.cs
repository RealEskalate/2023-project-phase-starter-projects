using Moq;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.Features.Notifications.Handlers.Commands;
using SocialSync.Application.Features.Notifications.Requests.Commands;
using SocialSync.Application.Tests.Mocks;


namespace SocialSync.Application.Tests.Features.Notifications.Handlers.Commands
{
    public class DeleteNotificationCommandHandlerTests
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;

        public DeleteNotificationCommandHandlerTests()
        {
            _mockUnitOfWork = MockUnitOfWork.GetMockUnitOfWork();
        }

        [Fact]
        public async Task Handle_ValidCommand_ReturnsSuccessResponse()
        {
            var handler = new DeleteNotificationCommandHandler(_mockUnitOfWork.Object);

            var command = new DeleteNotificationCommand { NotificationId = 1 };

            var response = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.NotNull(response);
            Assert.True(response.IsSuccess);
        }

        [Fact]
        public async Task Handle_InvalidCommand_ReturnsFailureResponse()
        {
            var handler = new DeleteNotificationCommandHandler(_mockUnitOfWork.Object);

            var command = new DeleteNotificationCommand { NotificationId = 999 };

            var response = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.NotNull(response);
            Assert.False(response.IsSuccess);
        }
    }
}

