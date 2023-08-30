using Application.Contracts.Persistance;
using Application.DTO.Like;
using Application.DTO.Post;
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
    public class GetLikedPostRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;
        public GetLikedPostRequestHandlerTests()
        {
            _mockRepo = MockCommentRepository.GetCommentRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetLikedPost_ValidUserId_ReturnsLikedPosts()
        {
            var handler = new GetLikedPostRequestHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetLikedPostRequest() { Id = 1 }, CancellationToken.None);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<BaseCommandResponse<List<PostDto>>>();
            result.Success.ShouldBeTrue();
            result.Value.ShouldNotBeNull();
            result.Value.ShouldBeOfType<List<PostDto>>();
            result.Value.Count.ShouldBe(2);
        }

        [Fact]
        public async Task GetLikedPost_InvalidUserId_ReturnsEmptyList()
        {
            var handler = new GetLikedPostRequestHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetLikedPostRequest() { Id = 999 }, CancellationToken.None);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<BaseCommandResponse<List<PostDto>>>();
            result.Success.ShouldBeTrue();
            result.Value.ShouldNotBeNull();
            result.Value.ShouldBeEmpty();
        }

        [Fact]
        public async Task GetLikedPost_RepositoryError_ReturnsFailure()
        {
            _mockRepo.Setup(repo => repo.likeRepository.GetLikedPost(It.IsAny<int>())).ThrowsAsync(new Exception("Simulated error"));
            var handler = new GetLikedPostRequestHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetLikedPostRequest() { Id = 1 }, CancellationToken.None);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<BaseCommandResponse<List<PostDto>>>();
            result.Success.ShouldBeFalse();
        }
    }
}
