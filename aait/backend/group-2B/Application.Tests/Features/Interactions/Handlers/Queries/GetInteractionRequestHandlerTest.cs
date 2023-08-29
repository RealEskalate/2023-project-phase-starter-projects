using AutoMapper;
using SocialSync.Application.Features.Comments.Handlers.Commands;
using SocialSync.Application.Features.Comments.Requests.Queries;
using SocialSync.Application.Profiles;
using SocialSync.Application.Tests.Mocks;


namespace SocialSync.Application.Tests.Features.Interactions.Handlers.Requests;

public class GetInteractionRequestHandlerTests
{
    [Fact]
    public async Task Handle_ValidRequest_ReturnsSuccessResponseWithInteraction()
    {
        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<InteractionMappingProfile>();
        });

        var mockMapper = mapperConfig.CreateMapper();

        var mockUnitOfWork = MockUnitOfWork.GetMockUnitOfWork();
        var handler =
            new GetInteractionRequestHandler(
                mockUnitOfWork.Object, mockMapper);


        var request = new GetInteractionRequest() { Id = 1 };


        var response = await handler.Handle(request, CancellationToken.None);

        Assert.NotNull(response);
        Assert.True(response.IsSuccess);
    }

    [Fact]
    public async Task Handle_InValidInteractionId_ReturnsFailure()
    {
        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<InteractionMappingProfile>();
        });

        var mockMapper = mapperConfig.CreateMapper();

        var mockUnitOfWork = MockUnitOfWork.GetMockUnitOfWork();
        var handler =
            new GetInteractionRequestHandler(
                mockUnitOfWork.Object, mockMapper);


        var request = new GetInteractionRequest() { Id = 10 };


        var response = await handler.Handle(request, CancellationToken.None);

        Assert.Null(response.Value);
        Assert.True(response.IsSuccess);
    }
}