using Application.Contracts.Persistance;
using Application.DTO.CommentDTO;
using Application.Features.Comment.Handlers.Queries;
using Application.Features.Comment.Requests.Queries;
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

namespace Application.Tests.Comments.Queries
{
    public class GetCommentsByPostRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;
        private readonly GetCommentsByPostIdRequestHandler _handler;

        public GetCommentsByPostRequestHandlerTests()
        {
            _mockRepo = MockUnitOfWorkRepository.GetMockUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _handler = new GetCommentsByPostIdRequestHandler(_mockRepo.Object, _mapper);
        }

        [Fact]
        public async Task GetCommentsByPostId_ValidPostId_ReturnsListOfCommentDto()
        {
            var request = new GetCommentsByPostIdRequest { PostId = 1 };

            var result = await _handler.Handle(request, CancellationToken.None);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<BaseCommandResponse<List<CommentDto>>>();
            result.Success.ShouldBeTrue();
            result.Value.ShouldNotBeNull();
            result.Value.Count.ShouldBe(3);
        }

        [Fact]
        public async Task GetCommentsByPostId_InvalidPostId_ReturnsEmptyList()
        {
            var request = new GetCommentsByPostIdRequest { PostId = 999 };

            var result = await _handler.Handle(request, CancellationToken.None);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<BaseCommandResponse<List<CommentDto>>>();
            result.Success.ShouldBeTrue();
            result.Value.ShouldNotBeNull();
            result.Value.ShouldBeEmpty();
        }

        [Fact]
        public async Task GetCommentsByPostId_RepositoryError_ReturnsFailure()
        {
            _mockRepo.Setup(repo => repo.commentRepository.GetCommentByPost(It.IsAny<int>(),It.IsAny<int>(),It.IsAny<int>())).ThrowsAsync(new Exception("Simulated error"));
            var request = new GetCommentsByPostIdRequest { PostId = 1 };

            var result = await _handler.Handle(request, CancellationToken.None);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<BaseCommandResponse<List<CommentDto>>>();
            result.Success.ShouldBeFalse();
            result.Value.ShouldBeNull();
        }

    }
}
