using Application.Common.Exceptions;
using Application.Contracts.Persistence;
using Application.Features.Comments.Handlers.Queries;
using Application.Features.Comments.Requests.Queries;
using Application.Profiles;
using Application.Tests.Mocks.Comment;
using AutoMapper;
using Moq;
using Shouldly;

namespace Application.Tests.Features.Comment.Request;

public class GetCommentRequestHandlerTests
{
    private readonly Mock<ICommentRepository> _mockRepo;

    private readonly IMapper _mapper;

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
    public async Task Handle_ValidCommentId_ReturnsComment()
    {
        // Arrange

        var handler = new GetCommentRequestHandler(
            _mockRepo.Object,
            _mapper
        );

        var request = new GetCommentRequest() {Id = 1};
        // Act
        var result = await handler.Handle(request, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        result.Id.ShouldBe(1);
        
    }

    [Fact]
    public async Task Handle_InvalidCommentId_ThrowsNotFoundException()
    {
        // Arrange
      
        var request = new GetCommentRequest { Id = 0 };

       
        var handler = new GetCommentRequestHandler(
            _mockRepo.Object,
            _mapper
        );

        // Act and Assert
        await Assert.ThrowsAsync<NotFoundException>(() => handler.Handle(request, CancellationToken.None));
    }
}