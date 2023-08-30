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
    public class DeletePostCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;
        private readonly DeletePostCommandHandler _handler;

        public DeletePostCommandHandlerTests()
        {
            _mockRepo = MockUnitOfWorkRepository.GetMockUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _handler = new DeletePostCommandHandler(_mockRepo.Object, _mapper);
        }


        [Fact]
        public async Task DeletePostCommand_ValidId_DeletesPost()
        {
            var initialPostList = await _mockRepo.Object.postRepository.GetAll();
            var initialPostCount = initialPostList.Count;

            var result = await _handler.Handle(new DeletePostCommand() { Id = 1, UserId = 2 }, CancellationToken.None);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<BaseCommandResponse<Unit>>();
            result.Success.ShouldBeTrue();
            result.Value.ShouldBe(Unit.Value);

            var updatedPostList = await _mockRepo.Object.postRepository.GetAll();
            var updatedPostCount = updatedPostList.Count;
            updatedPostCount.ShouldBe(initialPostCount - 1);
        }

        [Fact]
        public async Task DeletePostCommand_InvalidId_Failure()
        {
            var result = await _handler.Handle(new DeletePostCommand() { Id = 999, UserId = 2 }, CancellationToken.None);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<BaseCommandResponse<Unit>>();
            result.Success.ShouldBeFalse();
            result.Value.ShouldBe(Unit.Value);
        }

        [Fact]
        public async Task DeletePostCommand_UnauthorizedUser_Failure()
        {
            var result = await _handler.Handle(new DeletePostCommand() { Id = 1, UserId = 999 }, CancellationToken.None);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<BaseCommandResponse<Unit>>();
            result.Success.ShouldBeFalse();
            result.Value.ShouldBe(Unit.Value);
        }
    }
}
