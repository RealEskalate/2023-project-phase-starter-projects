using Application.Contracts.Persistance;
using Application.DTO.FollowDTO;
using Application.Features.Comment.Handlers.Queries;
using Application.Features.FollowFeatures.Handlers.Command;
using Application.Features.FollowFeatures.Request.Command;
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
    public class DeleteFollowCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;
        private readonly FollowDto _followDto;
        private readonly DeleteFollowCommandHandler _handler;
        public DeleteFollowCommandHandlerTests()
        {
            _mockRepo = MockUnitOfWorkRepository.GetMockUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _followDto = new FollowDto
            {
                FollowerId = 1,
                FollowedId = 3,
            };

            _mapper = mapperConfig.CreateMapper();
            _handler = new DeleteFollowCommandHandler(_mockRepo.Object, _mapper);
        }

        [Fact]
        public async Task DeleteFollowCommandTest()
        {
            var result = await _handler.Handle(new DeleteFollowCommand() { follow = _followDto }, CancellationToken.None);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<BaseCommandResponse<Unit>>();
            result.Success.ShouldBeFalse();
            result.Value.ShouldBe(Unit.Value);

        }

        [Fact]
        public async Task DeleteFollowCommand_FollowerNotFound_Failure()
        {
            _followDto.FollowerId = 999;

            var result = await _handler.Handle(new DeleteFollowCommand { follow = _followDto }, CancellationToken.None);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<BaseCommandResponse<Unit>>();
            result.Success.ShouldBeFalse();
            result.Value.ShouldBe(Unit.Value);
        }

        [Fact]
        public async Task DeleteFollowCommand_FollowedNotFound_Failure()
        {
            _followDto.FollowedId = 999;

            var result = await _handler.Handle(new DeleteFollowCommand { follow = _followDto }, CancellationToken.None);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<BaseCommandResponse<Unit>>();
            result.Success.ShouldBeFalse();
            result.Value.ShouldBe(Unit.Value);
        }

        [Fact]
        public async Task DeleteFollowCommand_NotFollowing_Failure()
        {
            _followDto.FollowerId = 1;
            _followDto.FollowedId = 3;

            var result = await _handler.Handle(new DeleteFollowCommand { follow = _followDto }, CancellationToken.None);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<BaseCommandResponse<Unit>>();
            result.Success.ShouldBeFalse();
            result.Value.ShouldBe(Unit.Value);
        }
    }
}
