using AutoMapper;
using SocialSync.Application.DTOs.InteractionDTOs;
using SocialSync.Application.DTOs.InteractionDTOs.CommentDTOs;
using SocialSync.Application.Features.Interactions.Handlers.Commands;
using SocialSync.Application.Features.Interactions.Requests.Commands;
using SocialSync.Application.Profiles;
using SocialSync.Application.Tests.Mocks;
using SocialSync.Domain.Entities;

namespace SocialSync.Application.Tests;

public class DeleteCommentInteractionCommandHandlerTest
{
    [Fact]
    public async Task Handle_DeleteCommentInteractionCommand()
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

        var interactionDto = new DeleteCommentInteractionDto { PostId = 1, UserId = 1, Id = 1};

        var command =
            new DeleteCommentInteractionCommand() { DeleteCommentInteractionDto = interactionDto };


        var response = await handler.Handle(command, CancellationToken.None);

        Assert.NotNull(response);
        Assert.True(response.IsSuccess);
    }
}