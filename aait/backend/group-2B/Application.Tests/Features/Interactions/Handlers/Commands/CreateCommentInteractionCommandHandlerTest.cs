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
using SocialSync.Application.Profiles;
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
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<InteractionMappingProfile>();
            });

            var mockMapper = mapperConfig.CreateMapper();

            var mockUnitOfWork = MockUnitOfWork.GetMockUnitOfWork();
            var handler =
                new CreateCommentInteractionCommandHandler(mockMapper,
                    mockUnitOfWork.Object);

            var interactionDto = new InteractionDto
            {
                PostId = 1, UserId = 1, Body = "New comment", Type = InteractionType.Comment
            };

            var command = new CreateCommentInteractionCommand()
            {
                CreateCommentDto = interactionDto
            };


            var response = await handler.Handle(command, CancellationToken.None);

            Assert.NotNull(response);
            Assert.True(response.IsSuccess);
        }

        [Fact]
        public async Task Handle_InValidCommand_ReturnsFailureResponse()
        {
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<InteractionMappingProfile>();
            });

            var mockMapper = mapperConfig.CreateMapper();

            var mockUnitOfWork = MockUnitOfWork.GetMockUnitOfWork();
            var handler =
                new CreateCommentInteractionCommandHandler(mockMapper,
                    mockUnitOfWork.Object);

            var interactionDto = new InteractionDto
            {
                PostId = 1, UserId = 1, Body = "", Type = InteractionType.Comment
            };

            var command = new CreateCommentInteractionCommand { CreateCommentDto = interactionDto };

            var response = await handler.Handle(command, CancellationToken.None);

            Assert.NotNull(response);
            Assert.False(response.IsSuccess);
        }

        
    }
}