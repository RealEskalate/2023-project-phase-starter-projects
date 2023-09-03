using Application.Contracts.Persistance;
using Application.DTO.Post;
using Application.Features.Like.Handlers.Commands;
using Application.Features.Post.Handlers.Command;
using Application.Features.Post.Handlers.Queries;
using Application.Features.Post.Request.Commands;
using Application.Features.Post.Request.Queries;
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

namespace Application.Tests.Post.Queries
{
    public class GetByContentRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;
        private readonly GetByContentRequestHandler _handler;

        public GetByContentRequestHandlerTests()
        {
            _mockRepo = MockUnitOfWorkRepository.GetMockUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _handler = new GetByContentRequestHandler(_mockRepo.Object, _mapper);
        }

        [Fact]
        public async Task GetByContent_ValidContent_ReturnsMatchingPosts()
        {
            var result = await _handler.Handle(new GetByContenetRequest() { Contenet = "Content 2" }, CancellationToken.None);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<BaseCommandResponse<List<PostDto>>>();
            result.Value.ShouldNotBeNull();
            result.Value.ShouldBeAssignableTo<IEnumerable<PostDto>>();
            result.Value.Any(post => post.Content == "Content 2").ShouldBeTrue();
        }

        [Fact]
        public async Task GetByContent_InvalidContent_ReturnsEmptyList()
        {
            var result = await _handler.Handle(new GetByContenetRequest() { Contenet = "NonExistentContent" }, CancellationToken.None);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<BaseCommandResponse<List<PostDto>>>();
            result.Value.ShouldNotBeNull();
            result.Value.ShouldBeEmpty();
        }

        [Fact]
        public async Task GetByContent_RepositoryError_Failure()
        {
            _mockRepo.Setup(repo => repo.postRepository.GetByContent(It.IsAny<string>(), It.IsAny<int>(),It.IsAny<int>())).ThrowsAsync(new Exception("Simulated error"));

            var result = await _handler.Handle(new GetByContenetRequest() { Contenet = "Content 2" }, CancellationToken.None);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<BaseCommandResponse<List<PostDto>>>();
            result.Success.ShouldBeFalse();
            result.Value.ShouldBeNull();
        }
    }
}
