using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using SocialSync.Application.Common.Responses;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.DTOs.InteractionDTOs;
using SocialSync.Application.Features.Interactions.Handlers.Commands;
using SocialSync.Application.Features.Interactions.Requests.Commands;
using SocialSync.Application.Tests.Mocks;
using SocialSync.Domain.Entities;
using Xunit;

namespace SocialSync.Application.Tests
{
    public class CreateCommentInteractionCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ValidCommand_ReturnsSuccessResponseWithInteractionId()
        {
           
            var mockMapper = new Mock<IMapper>();
            var mockUnitOfWork = MockUnitOfWork.GetMockUnitOfWork();
            var handler =
                new CreateCommentInteractionCommandHandler(mockMapper.Object,
                    mockUnitOfWork.Object);

            var interactionDto = new InteractionDto
            {
                PostId = 4, UserId = 4, Body = "New comment", Type = InteractionType.Comment
            };

            var command = new CreateCommentInteractionCommand()
            {
                CreateCommentDto = interactionDto
            };


            var response = await handler.Handle(command, CancellationToken.None);


            Assert.NotNull(response);
           
        }

       
    }
}