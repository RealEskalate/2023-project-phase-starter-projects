using AutoMapper;
using Moq;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.DTOs.Notifications;
using SocialSync.Application.Features.Notifications.Handlers.Commands;
using SocialSync.Application.Profiles;
using SocialSync.Application.Tests.Mocks;
using SocialSyncApplication.Features.Notifications.Requests.Commands;



namespace SocialSync.Application.Tests.Features.Notifications.Handlers.Commands
{
    public class CreateNotificationCommandHandlerTests
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly IMapper _mockMapper;

        public CreateNotificationCommandHandlerTests()
        {
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<NotificationMappingProfile>();
            });

            _mockMapper = mapperConfig.CreateMapper();
            _mockUnitOfWork = MockUnitOfWork.GetMockUnitOfWork();
        }

        [Fact]
        public async Task Handle_ValidCommand_ReturnsSuccessResponseWithNotificationId()
        {
            // Arrange
            var handler = new CreateNotificationCommandHandler(_mockUnitOfWork.Object, _mockMapper);

            var notificationDto = new NotificationCreateDto
            {
                // Set necessary properties
                SenderId = 1,
                NotificationType = "Like", // Or "Follow"
                RecepientId = 2,
                PostId = 3 // Optional
            };

            var command = new CreateNotificationCommand { NotificationCreateDto = notificationDto };

            // Act
            var response = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.NotNull(response);
            Assert.True(response.IsSuccess);
        }

        [Fact]
        public async Task Handle_InValid_NotificationType()
        {
            // Arrange
            var handler = new CreateNotificationCommandHandler(_mockUnitOfWork.Object, _mockMapper);

            var notificationDto = new NotificationCreateDto
            {
                // Set invalid notification type properties
                SenderId = 1,
                NotificationType = "Comment",
                RecepientId = 2,
                PostId = 3
            };

            var command = new CreateNotificationCommand { NotificationCreateDto = notificationDto };

            // Act
            var response = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.NotNull(response);
            Assert.False(response.IsSuccess);
        }
    }
}

