using Application.Contracts.Persistence;
using Application.DTOs.Comments;
using Application.Features.Comments.Handlers.Queries;
using Application.Features.Comments.Requests.Queries;
using Application.Profiles;
using Application.Tests.Mocks.Comment;
using AutoMapper;
using Moq;
using Shouldly;
using SocialSync.Application.Tests.Mocks;

namespace Application.Tests.Features.Comment.Request;

public partial class GetAllCommentsByPostIdRequestHandlerTests
{
    
    private readonly Mock<ICommentRepository> _mockCommentRepo;

    private readonly Mock<IPostRepository> _mockPostRepo;
    private readonly IMapper _mapper;

    public GetAllCommentsByPostIdRequestHandlerTests()
    {
        _mockCommentRepo = MockCommentRepository.GetCommentRepository();

        _mockPostRepo = MockPostRepository.GetPostRepository();
        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
    }
    [Fact]
    public async Task Handle_ReturnsAllComments()
    {
        // Arrange
        var request = new GetCommentsByPostIdRequest { PostId = 1 };

        var handler = new GetCommentsByPostIdRequestHandler(
            _mockCommentRepo.Object,
            _mockPostRepo.Object,
            _mapper
        );

        // Act
        var result = await handler.Handle(request, CancellationToken.None);

        result.ShouldBeOfType<List<CommentContentDto>>();
        result.Count.ShouldBe(2);
        
    }
}