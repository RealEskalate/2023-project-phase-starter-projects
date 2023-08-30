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

        public DeleteCommentCommandHandlerTests()
        {
            _mockRepo = MockCommentRepository.GetCommentRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task DeleteCommentCommand_ValidId_Success()
        {
            var handler = new DeleteCommentCommandHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new DeleteCommentCommand() { Id = 1 }, CancellationToken.None);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<BaseCommandResponse<Unit>>();
            result.Success.ShouldBeTrue();
            result.Value.ShouldBe(Unit.Value);
        }

        [Fact]
        public async Task DeleteCommentCommand_InvalidId_Failure()
        {
            var handler = new DeleteCommentCommandHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new DeleteCommentCommand() { Id = -1 }, CancellationToken.None);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<BaseCommandResponse<Unit>>();
            result.Success.ShouldBeFalse();
            result.Value.ShouldBe(Unit.Value);
        }

        [Fact]
        public async Task DeleteCommentCommand_CommentNotFound_Failure()
        {
            var handler = new DeleteCommentCommandHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new DeleteCommentCommand() { Id = 999 }, CancellationToken.None);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<BaseCommandResponse<Unit>>();
            result.Success.ShouldBeFalse();
            result.Value.ShouldBe(Unit.Value);
        }

        [Fact]
        public async Task DeleteCommentCommand_ValidId_DeletesComment()
        {
            var initialCommentList = await _mockRepo.Object.commentRepository.GetAll();
            var initialCommentCount = initialCommentList.Count;
            var handler = new DeleteCommentCommandHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new DeleteCommentCommand() { Id = 1 }, CancellationToken.None);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<BaseCommandResponse<Unit>>();
            result.Success.ShouldBeTrue();
            result.Value.ShouldBe(Unit.Value);

            var updatedCommentList = await _mockRepo.Object.commentRepository.GetAll();
            var updatedCommentCount = updatedCommentList.Count;
            updatedCommentCount.ShouldBe(initialCommentCount - 1);
        }

        [Fact]
        public async Task DeleteCommentCommand_RepositoryError_Failure()
        {
            _mockRepo.Setup(repo => repo.commentRepository.Delete(It.IsAny<Comment>())).ThrowsAsync(new Exception("Simulated error"));
            var handler = new DeleteCommentCommandHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new DeleteCommentCommand() { Id = 1 }, CancellationToken.None);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<BaseCommandResponse<Unit>>();
            result.Success.ShouldBeFalse();
            result.Value.ShouldBe(Unit.Value);
        }
    }
}
