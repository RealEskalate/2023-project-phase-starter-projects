using Application.Contracts.Persistence;
using Application.DTOs.Comments;
using Application.Features.Comments.Handlers.Queries;
using Application.Features.Comments.Requests.Queries;
using Application.Profiles;
using Application.Tests.Mocks.Comment;
using AutoMapper;
using Moq;
using Shouldly;

namespace Application.Tests.Features.Comment.Request;

public partial class GetAllCommentsRequestHandlerTests
{
    
    private readonly Mock<ICommentRepository> _mockRepo;
    private readonly IMapper _mapper;

    public GetAllCommentsRequestHandlerTests()
    {
        _mockRepo = MockCommentRepository.GetCommentRepository();
        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
    }
    [Fact]
    public async Task Handle_ReturnsAllComment()
    {
        // Arrange

        var request = new GetAllCommentsRequest();
        var handler = new GetAllCommentsRequestHandler(
            _mockRepo.Object,
            _mapper
        );

        // Act
        var result = await handler.Handle(request, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        result.Count.ShouldBe(3);
        
    }
}