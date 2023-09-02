using Application.Contracts;
using Application.DTO.Common;
using Application.Exceptions;
using Application.Features.CommentReactionFeature.Handlers.Commands;
using Application.Features.CommentReactionFeature.Requests.Commands;
using Application.Features.NotificationFeaure.Requests.Commands;
using Application.Profiles;
using Application.Response;
using Application.Tests.Mocks;
using Application.Tests.Mocs;
using AutoMapper;
using MediatR;
using Moq;
using Shouldly;

namespace Application.Tests.Features.CommentReactionFeature.Commands
{
    public class CreateCommentReactionCommandTest
    {            
            private readonly IMapper _mapper;
            private readonly Mock<IUnitOfWork> _mockUnitOfWork;    

            private readonly Mock<IMediator> _mediator; 
            private ReactionDTO testReaction;
            public CreateCommentReactionCommandTest()
            {

                _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();
                var mapperConfig = new MapperConfiguration(c => 
                {
                    c.AddProfile<MappingProfile>();
                });
                _mapper = mapperConfig.CreateMapper(); 
                _mediator = new Mock<IMediator>(); 
                testReaction = new ReactionDTO
                {
                    ReactedId = 1,
                    ReactionType = "like"
                };
            }

        [Fact]
        public async Task Valid_CommentReaction_Added()
        {
            // arrange
            _mediator.Setup(
                    x => x.Send(It.IsAny<CreateNotification>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);
            
            var mocCommentReactionRepository = MockCommentReactionRepository.GetCommentReactionRepository().Object;
            var mockCommentRepository = MockCommentRepository.GetCommentRepository().Object;
            var _handler = new MakeCommentReactionHandler(_mapper,_mockUnitOfWork.Object,_mediator.Object);

            // act                         
            var result = await _handler.Handle(new MakeReactionOnComment() { UserId = 1,ReactionData = testReaction}, CancellationToken.None);
            // assert
            result.ShouldBeOfType<BaseResponse<int>>();
        }

        [Fact]
        public async Task IValid_CommentReaction_Added()
        {
            // arrange
            _mediator.Setup(
                    x => x.Send(It.IsAny<CreateNotification>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);
            var mocCommentReactionRepository = MockCommentReactionRepository.GetCommentReactionRepository().Object;
            var mockCommentRepository = MockCommentRepository.GetCommentRepository().Object;
            var _handler = new MakeCommentReactionHandler(_mapper,_mockUnitOfWork.Object,_mediator.Object);
            testReaction.ReactionType = "Like";          

            // act and assert
            await Should.ThrowAsync<ValidationException>(async () =>
               await _handler.Handle(new MakeReactionOnComment() { UserId = 1,ReactionData = testReaction}, CancellationToken.None));
        }

    }
}