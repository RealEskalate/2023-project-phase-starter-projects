using Application.Contracts.Persistance;
using Application.DTO.CommentDTO;
using Application.Features.Comment.Handlers.Queries;
using Application.Features.Comment.Requests.Queries;
using Application.Profiles;
using Application.Tests.Mocks;
using AutoMapper;
using Domain.Entities;
using Moq;
using Shouldly;
using Application.Responses;


namespace Application.Tests.Comments.Queries
{
    public class GetCommentRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;

        public GetCommentRequestHandlerTests()
        {
            _mockRepo = MockCommentRepository.GetCommentRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetCommentCommand_ExistingComment_ReturnsCommentDto()
        {
            var handler = new GetCommentRequestHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetCommentRequest { commentId = 1 }, CancellationToken.None);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<BaseCommandResponse<CommentDto>>();
            result.Success.ShouldBeTrue();
            result.Value.Id.ShouldBe(1);
        }

        [Fact]
        public async Task GetCommentCommand_NonExistingComment_ReturnsFailure()
        {
            var handler = new GetCommentRequestHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetCommentRequest { commentId = 999 }, CancellationToken.None);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<BaseCommandResponse<CommentDto>>();
            result.Success.ShouldBeFalse();
            result.Value.ShouldBeNull();
        }

        [Fact]
        public async Task GetCommentCommand_RepositoryError_ReturnsFailure()
        {
            _mockRepo.Setup(repo => repo.commentRepository.Get(It.IsAny<int>())).ThrowsAsync(new Exception("Simulated error"));
            var handler = new GetCommentRequestHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetCommentRequest { commentId = 1 }, CancellationToken.None);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<BaseCommandResponse<CommentDto>>();
            result.Success.ShouldBeFalse();
            result.Value.ShouldBeNull();
        }

    }
}
