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
        public async Task GetCommentTest()
        {
            var handler = new GetCommentRequestHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetCommentRequest(), CancellationToken.None);

            result.ShouldBeOfType<BaseCommandResponse<CommentDto>>();

        }

    }
}
