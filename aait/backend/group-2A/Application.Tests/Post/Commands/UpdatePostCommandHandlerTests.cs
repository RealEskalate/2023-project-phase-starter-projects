using Application.Contracts.Persistance;
using Application.DTO.Post;
using Application.Features.Like.Handlers.Commands;
using Application.Features.Post.Handlers.Command;
using Application.Features.Post.Request.Commands;
using Application.Profiles;
using Application.Responses;
using Application.Tests.Mocks;
using AutoMapper;
using MediatR;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tests.Post.Commands
{
    public class UpdatePostCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;
        private readonly UpdatePostDto _postDto;
        private readonly UpdatePostCommandHandler _handler;
        public UpdatePostCommandHandlerTests()
        {
            _mockRepo = MockUnitOfWorkRepository.GetMockUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });


            _postDto = new UpdatePostDto
            {
                Id = 2,
                UserId = 1,
                Content = "Content 7",
                Tags = new List<string> { "tag5", "tag2" },
            };

            _mapper = mapperConfig.CreateMapper();
            _handler = new UpdatePostCommandHandler(_mockRepo.Object, _mapper);
        }

        [Fact]
        public async Task UpdatePostCommand_ValidData_UpdatesPost()
        {
            var result = await _handler.Handle(new UpdatePostCommand() { UpdatedPost = _postDto }, CancellationToken.None);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<BaseCommandResponse<Unit>>();
            result.Success.ShouldBeTrue();
            result.Value.ShouldBe(Unit.Value);
        }

        [Fact]
        public async Task UpdatePostCommand_InvalidData_Failure()
        {
            var result = await _handler.Handle(new UpdatePostCommand() { UpdatedPost = null }, CancellationToken.None);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<BaseCommandResponse<Unit>>();
            result.Success.ShouldBeFalse();
            result.Value.ShouldBe(Unit.Value);
        }

        [Fact]
        public async Task UpdatePostCommand_RepositoryError_Failure()
        {
            _mockRepo.Setup(repo => repo.postRepository.Update(It.IsAny<Domain.Entities.Post>())).ThrowsAsync(new Exception("Simulated error"));

            var result = await _handler.Handle(new UpdatePostCommand() { UpdatedPost = _postDto }, CancellationToken.None);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<BaseCommandResponse<Unit>>();
            result.Success.ShouldBeFalse();
            result.Value.ShouldBe(Unit.Value);
        }
    }
}
