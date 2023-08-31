using Application.Contracts.Persistance;
using Application.DTO.Like;
using Application.DTO.UserDTO;
using Application.Features.Like.Handlers.Commands;
using Application.Features.Like.Handlers.Query;
using Application.Features.Like.Request.Queries;
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

namespace Application.Tests.Like.Queries
{
    public class GetPostLikesQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;
        private readonly GetPostLikesQueryHandler _handler;
        public GetPostLikesQueryHandlerTests()
        {
            _mockRepo = MockUnitOfWorkRepository.GetMockUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _handler = new GetPostLikesQueryHandler(_mockRepo.Object, _mapper);
        }

        [Fact]
        public async Task GetPostLikes_ValidPostId_ReturnsLikedUsers()
        {
            var result = await _handler.Handle(new GetPostLikesQuery() { Id = 1 }, CancellationToken.None);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<BaseCommandResponse<List<UserDto>>>();
            result.Success.ShouldBeTrue();
            result.Value.ShouldNotBeNull();
            result.Value.ShouldBeOfType<List<UserDto>>();
            result.Value.Count.ShouldBe(2);
        }

        [Fact]
        public async Task GetPostLikes_InvalidPostId_ReturnsEmptyList()
        {
            var result = await _handler.Handle(new GetPostLikesQuery() { Id = 999 }, CancellationToken.None);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<BaseCommandResponse<List<UserDto>>>();
            result.Success.ShouldBeFalse();
            result.Errors.ShouldNotBeNull();
            result.Value.ShouldBeNull();
        }

        [Fact]
        public async Task GetPostLikes_RepositoryError_ReturnsFailure()
        {
            _mockRepo.Setup(repo => repo.likeRepository.GetLikers(It.IsAny<int>(),It.IsAny<int>(),It.IsAny<int>())).ThrowsAsync(new Exception("Simulated error"));

            var result = await _handler.Handle(new GetPostLikesQuery() { Id = 1 }, CancellationToken.None);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<BaseCommandResponse<List<UserDto>>>();
            result.Success.ShouldBeFalse();
        }
    }
}
