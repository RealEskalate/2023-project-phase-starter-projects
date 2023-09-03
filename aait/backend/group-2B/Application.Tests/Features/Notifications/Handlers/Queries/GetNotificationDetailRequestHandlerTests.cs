using AutoMapper;
using Moq;
using Shouldly;
using SocialSync.Application.Common.Responses;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.DTOs.Notifications;
using SocialSync.Application.Features.Notifications.Handlers.Queries;
using SocialSync.Application.Features.Notifications.Requests.Queries;
using SocialSync.Application.Profiles;
using SocialSync.Application.Tests.Mocks;

namespace SocialSync.Application.Tests.Features.Notifications.Handlers.Queries;

public class GetNotificationDetailRequestHandlerTests
{
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly IMapper _mockMapper;

    public GetNotificationDetailRequestHandlerTests()
    {
        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<NotificationMappingProfile>();
        });

        _mockMapper = mapperConfig.CreateMapper(); 
        _mockUnitOfWork = MockUnitOfWork.GetMockUnitOfWork();
    }
    [Fact]
    public async Task ValidNotificationDetailRetrieval_Returns_Succes()
    {
        // Arrange
        int notificationId = 1;
        var handler = new GetNotificationDetailRequestHandler(_mockUnitOfWork.Object, _mockMapper);
        var request = new GetNotificationDetailRequest { Id = notificationId};

        // Act
        var response = await handler.Handle(request, CancellationToken.None);

        // Assert
        response.ShouldNotBeNull();
        response.ShouldBeOfType<CommonResponse<NotificationDto>>();
        response.IsSuccess.ShouldBeTrue();
    }

    [Fact]
    public async Task NotificationNotFound()
    {
        // Arrange
        int notificationId = 99;

        var handler = new GetNotificationDetailRequestHandler(_mockUnitOfWork.Object, _mockMapper);
        var request = new GetNotificationDetailRequest { Id = notificationId };

        // Act
        var response = await handler.Handle(request, CancellationToken.None);

        // Assert
        response.ShouldNotBeNull();
        response.ShouldBeOfType<CommonResponse<NotificationDto>>();
        response.IsSuccess.ShouldBeFalse();
        response.Message.ShouldBe("Notification Not Found");
    }
}
