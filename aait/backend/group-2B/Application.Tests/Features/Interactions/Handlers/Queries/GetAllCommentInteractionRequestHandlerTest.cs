using AutoMapper;
using SocialSync.Application.DTOs.InteractionDTOs;
using SocialSync.Application.Features.Comments.Handlers.Commands;
using SocialSync.Application.Features.Comments.Requests.Queries;
using SocialSync.Application.Profiles;
using SocialSync.Application.Tests.Mocks;


namespace SocialSync.Application.Tests.Features.Interactions.Handlers.Requests;

public class GetAllCommentInteractionRequestHandlerTests
{
    [Fact]
    public async Task Handle_ValidRequest_ReturnsSuccessResponseWithListInteraction()
    {
        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<InteractionMappingProfile>();
        });

        var mockMapper = mapperConfig.CreateMapper();

        var mockUnitOfWork = MockUnitOfWork.GetMockUnitOfWork();
        var handler =
            new GetAllCommentInteractionRequestHandler(
                mockUnitOfWork.Object, mockMapper);


        var request = new GetAllCommentInteractionRequest { PostId = 1 };


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
            new GetAllCommentInteractionRequestHandler(
                mockUnitOfWork.Object, mockMapper);


        var request = new GetAllCommentInteractionRequest { PostId = 100 };


        var response = await handler.Handle(request, CancellationToken.None);

        Assert.Equal(new List<InteractionDto>(), response.Value);
        Assert.True(response.IsSuccess);
    }
}