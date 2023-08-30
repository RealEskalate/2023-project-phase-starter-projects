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
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tests.Comments.Commands
{
    public class CreateCommentCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;
        private readonly CreateCommentCommandHandler _handler;

        public CreateCommentCommandHandlerTests()
        {
            _mockRepo = MockUnitOfWorkRepository.GetMockUnitOfWork();
            

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _handler = new CreateCommentCommandHandler(_mockRepo.Object, _mapper);
        }

        [Fact]
        public async Task CreateCommentCommand_Success()
        {
            CreateCommentDto _commentDto = new CreateCommentDto
            {
                Content = "New Comment",
                PostId = 2,
                UserId = 1,
            };

            var result = await _handler.Handle(new CreateCommentCommand() { CommentDto = _commentDto }, CancellationToken.None);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<BaseCommandResponse<int>>();
            result.Success.ShouldBeTrue();
            result.Value.ShouldBeGreaterThan(0);
        }

        [Fact]
        public async Task CreateCommentCommand_InvalidDto_Failure()
        {
            var invalidDto = new CreateCommentDto();

            var result = await _handler.Handle(new CreateCommentCommand() { CommentDto = invalidDto }, CancellationToken.None);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<BaseCommandResponse<int>>();
            result.Success.ShouldBeFalse();
            result.Value.ShouldBe(0);
        }

        [Fact]
        public async Task CreateCommentCommand_InvalidPostId_Failure()
        {
            var invalidDto = new CreateCommentDto
            {
                Content = "Invalid Post Comment",
                PostId = -1,
                UserId = 1,
            };


            var result = await _handler.Handle(new CreateCommentCommand() { CommentDto = invalidDto }, CancellationToken.None);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<BaseCommandResponse<int>>();
            result.Success.ShouldBeFalse();
            result.Value.ShouldBe(0);
        }

        [Fact]
        public async Task CreateCommentCommand_InvalidUserId_Failure()
        {
            var invalidDto = new CreateCommentDto
            {
                Content = "Invalid User Comment",
                PostId = 2,
                UserId = -1,
            };


            var result = await _handler.Handle(new CreateCommentCommand() { CommentDto = invalidDto }, CancellationToken.None);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<BaseCommandResponse<int>>();
            result.Success.ShouldBeFalse();
            result.Value.ShouldBe(0);
        }
    }
}
