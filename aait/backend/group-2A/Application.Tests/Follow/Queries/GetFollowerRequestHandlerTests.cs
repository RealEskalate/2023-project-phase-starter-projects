using Application.Contracts.Persistance;
using Application.DTO.FollowDTO;
using Application.DTO.UserDTO;
using Application.Features.Comment.Handlers.Queries;
using Application.Features.FollowFeatures.Handlers.Command;
using Application.Features.FollowFeatures.Handlers.Queries;
using Application.Features.FollowFeatures.Request.Command;
using Application.Features.FollowFeatures.Request.Queries;
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

namespace Application.Tests.Follow.Queries
{
    public class GetFollowerRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;
        private readonly GetFollowerRequestHandler _handler;
        public GetFollowerRequestHandlerTests()
        {
            _mockRepo = MockUnitOfWorkRepository.GetMockUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _handler = new GetFollowerRequestHandler(_mockRepo.Object, _mapper);
        }


        [Fact]
        public async Task GetFollower_ValidUserId_ReturnsListOfUserDto()
        {
            var request = new GetFollowerRequest { Id = 2 };

            var result = await _handler.Handle(request, CancellationToken.None);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<BaseCommandResponse<List<UserDto>>>();
            result.Success.ShouldBeTrue();
            result.Value.ShouldNotBeNull();
            result.Value.Count.ShouldBe(1);
        }

        [Fact]
        public async Task GetFollower_InvalidUserId_ReturnsEmptyList()
        {
            var request = new GetFollowerRequest { Id = 999 };

            var result = await _handler.Handle(request, CancellationToken.None);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<BaseCommandResponse<List<UserDto>>>();
            result.Success.ShouldBeTrue();
            result.Value.ShouldNotBeNull();
            result.Value.ShouldBeEmpty();
        }

        [Fact]
        public async Task GetFollower_RepositoryError_ReturnsFailure()
        {
            _mockRepo.Setup(repo => repo.followRepository.GetFollower(It.IsAny<int>(),It.IsAny<int>(),It.IsAny<int>())).ThrowsAsync(new Exception("Simulated error"));
            var request = new GetFollowerRequest { Id = 2 };

            var result = await _handler.Handle(request, CancellationToken.None);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<BaseCommandResponse<List<UserDto>>>();
            result.Success.ShouldBeFalse();
            result.Value.ShouldBeNull();
        }
    }
}
