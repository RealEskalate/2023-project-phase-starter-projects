using AutoMapper;
using SocialSync.Application.DTOs.InteractionDTOs.CommentDTOs;
using SocialSync.Application.Features.Interactions.Handlers.Commands;
using SocialSync.Application.Features.Interactions.Requests.Commands;
using SocialSync.Application.Profiles;
using SocialSync.Application.Tests.Mocks;

namespace SocialSync.Application.Tests.Features.Interactions.Handlers.Commands;

public class DeleteCommentInteractionCommandHandlerTest
{
    [Fact]
    public async Task
        Handle_ValidCommand_DeleteCommentInteraction_ReturnSuccessWithDeletedInteraction()
    {
        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<InteractionMappingProfile>();
        });

        var mockMapper = mapperConfig.CreateMapper();

        var mockUnitOfWork = MockUnitOfWork.GetMockUnitOfWork();
        var handler =
            new DeleteCommentInteractionCommandHandler(mockMapper,
                mockUnitOfWork.Object);

        var interactionDto = new DeleteCommentInteractionDto { PostId = 1, UserId = 1, Id = 1 };

        var command =
            new DeleteCommentInteractionCommand() { DeleteCommentInteractionDto = interactionDto };


        var response = await handler.Handle(command, CancellationToken.None);

        Assert.NotNull(response);
        Assert.True(response.IsSuccess);
    }

    [Fact]
    public async Task Handle_InValidInteractionId_DeleteCommentInteraction_ReturnFailure()
    {
        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<InteractionMappingProfile>();
        });

        var mockMapper = mapperConfig.CreateMapper();

        var mockUnitOfWork = MockUnitOfWork.GetMockUnitOfWork();
        var handler =
            new DeleteCommentInteractionCommandHandler(mockMapper,
                mockUnitOfWork.Object);

        var interactionDto = new DeleteCommentInteractionDto { PostId = 1, UserId = 1, Id = 10 };

        var command =
            new DeleteCommentInteractionCommand() { DeleteCommentInteractionDto = interactionDto };


        var response = await handler.Handle(command, CancellationToken.None);

        Assert.NotNull(response);
        Assert.False(response.IsSuccess);
    }

    [Fact]
    public async Task Handle_InValidPostId_DeleteCommentInteraction_ReturnFailure()
    {
        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<InteractionMappingProfile>();
        });

        var mockMapper = mapperConfig.CreateMapper();

        var mockUnitOfWork = MockUnitOfWork.GetMockUnitOfWork();
        var handler =
            new DeleteCommentInteractionCommandHandler(mockMapper,
                mockUnitOfWork.Object);

        var interactionDto = new DeleteCommentInteractionDto { PostId = 10, UserId = 1, Id = 1 };

        var command =
            new DeleteCommentInteractionCommand() { DeleteCommentInteractionDto = interactionDto };


        var response = await handler.Handle(command, CancellationToken.None);

        Assert.NotNull(response);
        Assert.False(response.IsSuccess);
    }

    [Fact]
    public async Task Handle_InValidUserId_DeleteCommentInteraction_ReturnFailure()
    {
        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<InteractionMappingProfile>();
        });

        var mockMapper = mapperConfig.CreateMapper();

        var mockUnitOfWork = MockUnitOfWork.GetMockUnitOfWork();
        var handler =
            new DeleteCommentInteractionCommandHandler(mockMapper,
                mockUnitOfWork.Object);

        var interactionDto = new DeleteCommentInteractionDto { PostId = 1, UserId = 10, Id = 1 };

        var command =
            new DeleteCommentInteractionCommand() { DeleteCommentInteractionDto = interactionDto };


        var response = await handler.Handle(command, CancellationToken.None);

        Assert.NotNull(response);
        Assert.False(response.IsSuccess);
    }
}