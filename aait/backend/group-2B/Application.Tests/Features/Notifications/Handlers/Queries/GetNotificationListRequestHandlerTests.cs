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
public class GetNotificationListRequestHandlerTests
{
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly IMapper _mockMapper;

    public GetNotificationListRequestHandlerTests()
    {
        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<NotificationMappingProfile>();
        });

        _mockMapper = mapperConfig.CreateMapper();
        _mockUnitOfWork = MockUnitOfWork.GetMockUnitOfWork();
    }
    [Fact]
    public async Task ValidNotificationListRetrieval()
    {
        // Arrange
        int userId = 1;
        var handler = new GetNotificationListRequestHandler(_mockUnitOfWork.Object, _mockMapper);
        var request = new GetNotificationListRequest {UserId = userId};

        // Act
        var response = await handler.Handle(request, CancellationToken.None);

        // Assert
        response.ShouldNotBeNull();
        response.ShouldBeOfType<CommonResponse<List<NotificationListDto>>>();
        response.IsSuccess.ShouldBeTrue();
    }

    [Fact]
    public async Task UserDoesnotExist()
    {
        // Arrange
        int userId = 99;

        var handler = new GetNotificationListRequestHandler(_mockUnitOfWork.Object, _mockMapper);
        var request = new GetNotificationListRequest {UserId = userId};

        // Act
        var response = await handler.Handle(request, CancellationToken.None);

        // Assert
        response.ShouldNotBeNull();
        response.ShouldBeOfType<CommonResponse<List<NotificationListDto>>>();
        response.IsSuccess.ShouldBeFalse();
        response.Message.ShouldBe("User Doesn't Exist");
    }
}

