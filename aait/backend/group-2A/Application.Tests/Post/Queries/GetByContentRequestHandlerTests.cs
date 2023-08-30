using Application.Contracts.Persistance;
using Application.DTO.Post;
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

        public GetByContentRequestHandlerTests()
        {
            _mockRepo = MockCommentRepository.GetCommentRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetByContent_ValidContent_ReturnsMatchingPosts()
        {
            var handler = new GetByContentRequestHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetByContenetRequest() { Contenet = "Content 2" }, CancellationToken.None);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<BaseCommandResponse<List<PostDto>>>();
            result.Value.ShouldNotBeNull();
            result.Value.ShouldBeAssignableTo<IEnumerable<PostDto>>();
            result.Value.Any(post => post.Content == "Content 2").ShouldBeTrue();
        }

        [Fact]
        public async Task GetByContent_InvalidContent_ReturnsEmptyList()
        {
            var handler = new GetByContentRequestHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetByContenetRequest() { Contenet = "NonExistentContent" }, CancellationToken.None);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<BaseCommandResponse<List<PostDto>>>();
            result.Value.ShouldNotBeNull();
            result.Value.ShouldBeEmpty();
        }

        [Fact]
        public async Task GetByContent_RepositoryError_Failure()
        {
            _mockRepo.Setup(repo => repo.postRepository.GetByContent(It.IsAny<string>())).ThrowsAsync(new Exception("Simulated error"));
            var handler = new GetByContentRequestHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetByContenetRequest() { Contenet = "Content 2" }, CancellationToken.None);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<BaseCommandResponse<List<PostDto>>>();
            result.Success.ShouldBeFalse();
            result.Value.ShouldBeEmpty();
        }
    }
}
