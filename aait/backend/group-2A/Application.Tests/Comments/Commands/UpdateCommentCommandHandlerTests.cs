using Application.Contracts.Persistance;
using Application.DTO.CommentDTO;
using Application.Features.Comment.Handlers.Commands;
using Application.Features.Comment.Requests.Commands;
using Application.Profiles;
using Application.Responses;
using Application.Tests.Mocks;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Moq;
using Shouldly;


namespace Application.Tests.Comments.Commands
{
    public class UpdateCommentCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;
        private readonly UpdateCommentCommandHandler _handler;

        public UpdateCommentCommandHandlerTests()
        {
            _mockRepo = MockUnitOfWorkRepository.GetMockUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _handler = new UpdateCommentCommandHandler(_mockRepo.Object, _mapper);
        }

   

    [Fact]
    public async Task UpdateCommentCommand_ValidData_Success()
    {
        var commentToUpdate = _mockRepo.Object.commentRepository.Get(1).Result;
        commentToUpdate.Content = "Updated Comment Content";
            var updateCommand = new UpdateCommentCommand
            {
                UpdateCommentDto = _mapper.Map<UpdateCommentDto>(commentToUpdate)
        };

        var result = await _handler.Handle(updateCommand, CancellationToken.None);

        result.ShouldNotBeNull();
        result.ShouldBeOfType<BaseCommandResponse<Unit>>();
        result.Success.ShouldBeTrue();
        result.Value.ShouldBe(Unit.Value);

        var updatedComment = await _mockRepo.Object.commentRepository.Get(commentToUpdate.Id);
        updatedComment.ShouldNotBeNull();
        updatedComment.Content.ShouldBe(commentToUpdate.Content);
    }

    [Fact]
    public async Task UpdateCommentCommand_InvalidId_Failure()
    {
        var updatedComment = new UpdateCommentDto { Id = -1, Content = "Updated Comment Content" };
        var updateCommand = new UpdateCommentCommand
        {
            UpdateCommentDto = updatedComment
        };

        var result = await _handler.Handle(updateCommand, CancellationToken.None);

        result.ShouldNotBeNull();
        result.ShouldBeOfType<BaseCommandResponse<Unit>>();
        result.Success.ShouldBeFalse();
        result.Value.ShouldBe(Unit.Value);
    }
}
}
