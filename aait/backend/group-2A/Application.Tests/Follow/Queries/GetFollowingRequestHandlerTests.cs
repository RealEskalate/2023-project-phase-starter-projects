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
    public class GetFollowingRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;
        private readonly GetFollowingRequestHandler _handler;
        public GetFollowingRequestHandlerTests()
        {
            _mockRepo = MockUnitOfWorkRepository.GetMockUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _handler = new GetFollowingRequestHandler(_mockRepo.Object, _mapper);
        }

        [Fact]
        public async Task GetFollowing_ValidUserId_ReturnsListOfUserDto()
        {
            var request = new GetFollowingRequest { Id = 1 };

            var result = await _handler.Handle(request, CancellationToken.None);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<BaseCommandResponse<List<UserDto>>>();
            result.Success.ShouldBeTrue();
            result.Value.ShouldNotBeNull();
            result.Value.Count.ShouldBe(2);
        }

        [Fact]
        public async Task GetFollowing_InvalidUserId_ReturnsEmptyList()
        {
            var request = new GetFollowingRequest { Id = 999 };

            var result = await _handler.Handle(request, CancellationToken.None);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<BaseCommandResponse<List<UserDto>>>();
            result.Success.ShouldBeTrue();
            result.Value.ShouldNotBeNull();
            result.Value.ShouldBeEmpty();
        }

        [Fact]
        public async Task GetFollowing_RepositoryError_ReturnsFailure()
        {
            _mockRepo.Setup(repo => repo.followRepository.GetFollowing(It.IsAny<int>(),It.IsAny<int>(),It.IsAny<int>())).ThrowsAsync(new Exception("Simulated error"));
            var request = new GetFollowingRequest { Id = 1 };

            var result = await _handler.Handle(request, CancellationToken.None);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<BaseCommandResponse<List<UserDto>>>();
            result.Success.ShouldBeFalse();
            result.Value.ShouldBeNull();
        }
    }
}
