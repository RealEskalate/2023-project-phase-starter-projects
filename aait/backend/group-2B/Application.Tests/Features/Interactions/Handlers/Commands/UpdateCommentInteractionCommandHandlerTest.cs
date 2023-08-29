using AutoMapper;
using SocialSync.Application.DTOs.InteractionDTOs.CommentDTOs;
using SocialSync.Application.Features.Comments.Requests.Commands;
using SocialSync.Application.Features.Interactions.Handlers.Commands;
using SocialSync.Application.Profiles;
using SocialSync.Application.Tests.Mocks;

namespace SocialSync.Application.Tests.Features.Interactions.Handlers.Commands;

public class UpdateCommentInteractionCommandHandlerTests
{
    [Fact]
    public async Task Handle_ValidCommand_ReturnsSuccessResponseWithInteractionId()
    {
        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<InteractionMappingProfile>();
        });

        var mockMapper = mapperConfig.CreateMapper();

        var mockUnitOfWork = MockUnitOfWork.GetMockUnitOfWork();
        var handler =
                new UpdateCommentInteractionCommandHandler(mockUnitOfWork.Object, mockMapper)
            ;

        var interactionDto = new UpdateCommentInteractionDto
        {
           PostId = 2 , Body = "sfsdfsd bhjb" , Id = 2, UserId = 2
        };

        var command = new UpdateCommentInteractionCommand
        {
            UpdateCommentDto = interactionDto
        };


        var response = await handler.Handle(command, CancellationToken.None);

        Assert.NotNull(response.Value);
        Assert.True(response.IsSuccess);
    }

    [Fact]
    public async Task Handle_InValidBodyCommand_ReturnsFailureResponse()
    {
        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<InteractionMappingProfile>();
        });

        var mockMapper = mapperConfig.CreateMapper();

        var mockUnitOfWork = MockUnitOfWork.GetMockUnitOfWork();
        var handler =
                new UpdateCommentInteractionCommandHandler(mockUnitOfWork.Object, mockMapper)
            ;

        var interactionDto = new UpdateCommentInteractionDto { PostId = 1, UserId = 1, Body = "" ,  Id = 1};

        var command = new UpdateCommentInteractionCommand { UpdateCommentDto = interactionDto };

        var response = await handler.Handle(command, CancellationToken.None);

        Assert.NotNull(response);
        Assert.False(response.IsSuccess);
    }

    [Fact]
    public async Task Handle_NoUserWithProvidedIdCommand_ReturnsFailureResponse()
    {
        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<InteractionMappingProfile>();
        });

        var mockMapper = mapperConfig.CreateMapper();

        var mockUnitOfWork = MockUnitOfWork.GetMockUnitOfWork();
        var handler =
                new UpdateCommentInteractionCommandHandler(mockUnitOfWork.Object, mockMapper)
            ;

        var interactionDto = new UpdateCommentInteractionDto
        {
            PostId = 1, UserId = 10, Body = "New comment",  Id = 1
        };

        var command = new UpdateCommentInteractionCommand { UpdateCommentDto = interactionDto };


        var response = await handler.Handle(command, CancellationToken.None);

        Assert.NotNull(response);
        Assert.False(response.IsSuccess);
    }

    [Fact]
    public async Task Handle_NoPostWithProvidedIdCommand_ReturnsFailureResponse()
    {
        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<InteractionMappingProfile>();
        });

        var mockMapper = mapperConfig.CreateMapper();

        var mockUnitOfWork = MockUnitOfWork.GetMockUnitOfWork();
        var handler =
                new UpdateCommentInteractionCommandHandler(mockUnitOfWork.Object, mockMapper)
            ;

        var interactionDto = new UpdateCommentInteractionDto
        {
            PostId = 10, UserId = 1, Body = "New comment",  Id = 1
        };

        var command = new UpdateCommentInteractionCommand { UpdateCommentDto = interactionDto };


        var response = await handler.Handle(command, CancellationToken.None);

        Assert.NotNull(response);
        Assert.False(response.IsSuccess);
    }
}