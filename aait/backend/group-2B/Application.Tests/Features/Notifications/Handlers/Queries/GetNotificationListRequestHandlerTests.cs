using AutoMapper;
using Moq;
using Shouldly;
using SocialSync.Application.Common.Responses;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.DTOs.Notifications;
using SocialSync.Application.Features.Notifications.Handlers.Queries;
using SocialSync.Application.Features.Notifications.Requests.Queries;

namespace SocialSync.Application.Tests.Features.Notifications.Handlers.Queries;
public class GetNotificationListRequestHandlerTests
{
    [Fact]
    public async Task ValidNotificationListRetrieval()
    {
        // Arrange
        var userId = Guid.NewGuid(); // Replace with a valid user ID
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var mapperMock = new Mock<IMapper>();

        var notifications = new List<Notification>(); // Replace with your test data
        var notificationDtos = new List<NotificationListDto>(); // Replace with expected DTOs

        unitOfWorkMock.Setup(uow => uow.NotificationRepository.GetAll(userId))
            .ReturnsAsync(notifications);
        mapperMock.Setup(mapper => mapper.Map<List<NotificationListDto>>(notifications))
            .Returns(notificationDtos);

        var handler = new GetNotificationListRequestHandler(unitOfWorkMock.Object, mapperMock.Object);
        var request = new GetNotificationListRequest(userId);

        // Act
        var response = await handler.Handle(request, CancellationToken.None);

        // Assert
        response.ShouldNotBeNull();
        response.ShouldBeOfType<CommonResponse<List<NotificationListDto>>>();
        response.Success.ShouldBeTrue();
        response.Data.ShouldBe(notificationDtos);
    }

    [Fact]
    public async Task NotificationsNotFound()
    {
        // Arrange
        var userId = Guid.NewGuid(); // Replace with a valid user ID
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var mapperMock = new Mock<IMapper>();

        List<Notification> notifications = null;

        unitOfWorkMock.Setup(uow => uow.NotificationRepository.GetAll(userId))
            .ReturnsAsync(notifications);

        var handler = new GetNotificationListRequestHandler(unitOfWorkMock.Object, mapperMock.Object);
        var request = new GetNotificationListRequest(userId);

        // Act
        var response = await handler.Handle(request, CancellationToken.None);

        // Assert
        response.ShouldNotBeNull();
        response.ShouldBeOfType<CommonResponse<List<NotificationListDto>>>();
        response.Success.ShouldBeFalse();
        response.Message.ShouldBe("Notifications Not Found");
        response.Data.ShouldBeNull();
    }
}
}

