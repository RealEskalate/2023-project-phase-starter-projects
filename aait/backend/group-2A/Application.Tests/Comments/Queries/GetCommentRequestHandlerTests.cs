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
        private readonly GetCommentRequestHandler _handler;

        public GetCommentRequestHandlerTests()
        {
            _mockRepo = MockUnitOfWorkRepository.GetMockUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _handler = new GetCommentRequestHandler(_mockRepo.Object, _mapper);
        }

        [Fact]
        public async Task GetCommentCommand_ValidId_ReturnsCommentDto()
        {
            var result = await _handler.Handle(new GetCommentRequest { commentId = 1 }, CancellationToken.None);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<BaseCommandResponse<CommentDto>>();
            result.Success.ShouldBeTrue();
            result.Value.Id.ShouldBe(1);
        }

        [Fact]
        public async Task GetCommentCommand_InValidId_ReturnsFailure()
        {
            var result = await _handler.Handle(new GetCommentRequest { commentId = 999 }, CancellationToken.None);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<BaseCommandResponse<CommentDto>>();
            result.Success.ShouldBeFalse();
            result.Value.ShouldBeNull();
        }

    }
}
