using Application.Contracts.Persistance;
using Application.DTO.Like;
using Application.DTO.UserDTO;
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
        public GetPostLikesQueryHandlerTests()
        {
            _mockRepo = MockCommentRepository.GetCommentRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetPostLikes_ValidPostId_ReturnsLikedUsers()
        {
            var handler = new GetPostLikesQueryHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetPostLikesQuery() { Id = 1 }, CancellationToken.None);

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
            var handler = new GetPostLikesQueryHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetPostLikesQuery() { Id = 999 }, CancellationToken.None);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<BaseCommandResponse<List<UserDto>>>();
            result.Success.ShouldBeTrue();
            result.Value.ShouldNotBeNull();
            result.Value.ShouldBeEmpty();
        }

        [Fact]
        public async Task GetPostLikes_RepositoryError_ReturnsFailure()
        {
            _mockRepo.Setup(repo => repo.likeRepository.GetLikers(It.IsAny<int>())).ThrowsAsync(new Exception("Simulated error"));
            var handler = new GetPostLikesQueryHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetPostLikesQuery() { Id = 1 }, CancellationToken.None);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<BaseCommandResponse<List<UserDto>>>();
            result.Success.ShouldBeFalse();
        }
    }
}
