using Application.Contracts.Persistance;
using Application.DTO.FollowDTO;
using Application.DTO.Post;
using Application.Features.Comment.Handlers.Queries;
using Application.Features.FollowFeatures.Handlers.Command;
using Application.Features.FollowFeatures.Request.Command;
using Application.Features.Post.Handlers.Queries;
using Application.Features.Post.Request.Queries;
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

namespace Application.Tests.Follow.Commands
{
    public class CreateFollowCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;
        private readonly FollowDto _followDto;
        private readonly CreateFollowCommandHandler _handler;
        public CreateFollowCommandHandlerTests()
        {
            _mockRepo = MockUnitOfWorkRepository.GetMockUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _followDto = new FollowDto
            {
                FollowerId = 2,
                FollowedId = 3,
            };

            _mapper = mapperConfig.CreateMapper();
            _handler = new CreateFollowCommandHandler(_mockRepo.Object, _mapper);
        }

        [Fact]
        public async Task CreateFollowCommand_Success()
        {
            var result = await _handler.Handle(new CreateFollowCommand() { follow = _followDto}, CancellationToken.None);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<BaseCommandResponse<Unit>>();
            result.Errors.ShouldBeNull();
            result.Success.ShouldBeTrue();
            result.Value.ShouldBe(Unit.Value);
        }

        [Fact]
        public async Task CreateFollowCommand_FollowerNotFound_Failure()
        {
            _followDto.FollowerId = 999;
            var result = await _handler.Handle(new CreateFollowCommand { follow = _followDto }, CancellationToken.None);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<BaseCommandResponse<Unit>>();
            result.Success.ShouldBeFalse();
            result.Value.ShouldBe(Unit.Value);
        }

        [Fact]
        public async Task CreateFollowCommand_FollowedNotFound_Failure()
        {
            _followDto.FollowedId = 999;

            var result = await _handler.Handle(new CreateFollowCommand { follow = _followDto }, CancellationToken.None);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<BaseCommandResponse<Unit>>();
            result.Success.ShouldBeFalse();
            result.Value.ShouldBe(Unit.Value);
        }

        [Fact]
        public async Task CreateFollowCommand_AlreadyFollowing_Failure()
        {
            _followDto.FollowerId = 1;
            _followDto.FollowedId = 2;

            var result = await _handler.Handle(new CreateFollowCommand { follow = _followDto }, CancellationToken.None);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<BaseCommandResponse<Unit>>();
            result.Success.ShouldBeFalse();
            result.Value.ShouldBe(Unit.Value);
        }

    }
}
