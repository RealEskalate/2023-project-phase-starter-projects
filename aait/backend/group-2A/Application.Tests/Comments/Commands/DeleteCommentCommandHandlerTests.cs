using Application.Contracts.Persistance;
using Application.DTO.CommentDTO;
using Application.Features.Comment.Handlers.Commands;
using Application.Features.Comment.Handlers.Queries;
using Application.Features.Comment.Requests.Commands;
using Application.Features.Comment.Requests.Queries;
using Application.Profiles;
using Application.Responses;
using Application.Tests.Mocks;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tests.Comments.Commands
{
    public class DeleteCommentCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;
        private readonly DeleteCommentCommandHandler _handler;

        public DeleteCommentCommandHandlerTests()
        {
            _mockRepo = MockUnitOfWorkRepository.GetMockUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _handler = new DeleteCommentCommandHandler(_mockRepo.Object, _mapper);
        }

        [Fact]
        public async Task DeleteCommentCommand_ValidId_Success()
        {
            var result = await _handler.Handle(new DeleteCommentCommand() { Id = 1, UserId = 1}, CancellationToken.None);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<BaseCommandResponse<Unit>>();
            result.Success.ShouldBeTrue();
            result.Value.ShouldBe(Unit.Value);
        }

        [Fact]
        public async Task DeleteCommentCommand_InvalidId_Failure()
        {
            var result = await _handler.Handle(new DeleteCommentCommand() { Id = -1 }, CancellationToken.None);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<BaseCommandResponse<Unit>>();
            result.Success.ShouldBeFalse();
            result.Value.ShouldBe(Unit.Value);
        }
    }
}
