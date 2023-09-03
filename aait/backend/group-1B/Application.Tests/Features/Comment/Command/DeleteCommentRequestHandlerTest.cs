using Application.Common.Exceptions;
using Application.Contracts.Persistence;
using Application.Features.Comments.Handlers.Commands;
using Application.Features.Comments.Requests.Commands;
using Application.Profiles;
using Application.Tests.Mocks.Comment;
using AutoMapper;
using MediatR;
using Moq;
using Shouldly;

namespace Application.Tests.Features.Comment.Command;

public class DeleteCommentRequestHandlerTests
{
    
    private readonly Mock<ICommentRepository> _mockRepo;
    private readonly IMapper _mapper;

    public DeleteCommentRequestHandlerTests()
    {
        _mockRepo = MockCommentRepository.GetCommentRepository();
        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
    }
    
    [Fact]
    public async Task Handle_ExistingComment_DeletesComment()
    {
        var handler = new DeleteCommentRequestHandler(_mockRepo.Object, _mapper);

        var request = new DeleteCommentRequest() { Id = 1 };

        var result = await handler.Handle(request, CancellationToken.None);
        
        result.ShouldBe(Unit.Value);
        
        

    }

    [Fact]
    public async Task Handle_NonExistingComment_ThrowsNotFoundException()
    {
        var handler = new DeleteCommentRequestHandler(_mockRepo.Object, _mapper);

        var request = new DeleteCommentRequest() { Id = 5 };

        await Should.ThrowAsync<NotFoundException>(handler.Handle(request, CancellationToken.None));

    }
}