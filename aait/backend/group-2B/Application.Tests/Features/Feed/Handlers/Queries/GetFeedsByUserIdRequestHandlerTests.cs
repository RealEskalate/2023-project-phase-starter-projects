using AutoMapper;
using Moq;
using Shouldly;
using SocialSync.Application.Common.Responses;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.DTOs.PostDtos;
using SocialSync.Application.Features.Feed.Handlers.Queries;
using SocialSync.Application.Features.Feed.Requests.Queries;
using SocialSync.Application.Profiles;
using SocialSync.Application.Tests.Mocks;

namespace SocialSync.Application.Tests.Features.Feed.Handlers.Queries;

public class GetFeedsByUserIdRequestHandlerTests
{
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly IMapper _mockMapper;

    public GetFeedsByUserIdRequestHandlerTests()
    {
        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<NotificationMappingProfile>();
        });

        _mockMapper = mapperConfig.CreateMapper(); 
        _mockUnitOfWork = MockUnitOfWork.GetMockUnitOfWork();
    }

    [Fact]
    public async Task ValidFeedsRetrievalRequest_Returns_Success(){
        //Arrange
        int userId = 1;

        var handler = new GetFeedsByUserIdRequestHandler(_mockUnitOfWork.Object, _mockMapper);
        var request = new GetFeedsByUserIdRequest {UserID = userId};

        //Act
        var response = await handler.Handle(request, CancellationToken.None);

        //Assert
        response.ShouldNotBeNull();
        response.ShouldBeOfType<CommonResponse<List<PostDto>>>();
        response.IsSuccess.ShouldBeTrue();
    }

    [Fact]
    public async Task InvalidFeedsRetrievalRequest_Returns_Failure(){
        
        //Arrange
        int userId = 99;

        var handler = new GetFeedsByUserIdRequestHandler(_mockUnitOfWork.Object, _mockMapper);
        var request = new GetFeedsByUserIdRequest {UserID = userId };

        //Act
        var response = await handler.Handle(request, CancellationToken.None);

        //Assert
        response.ShouldNotBeNull();
        response.ShouldBeOfType<CommonResponse<List<PostDto>>>();
        response.IsSuccess.ShouldBeFalse();
    }
}
