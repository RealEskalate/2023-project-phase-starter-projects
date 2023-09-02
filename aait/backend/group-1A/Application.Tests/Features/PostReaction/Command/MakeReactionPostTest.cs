using Application.Contracts;
using Application.DTO.Common;
using Application.Exceptions;
using Application.Features.NotificationFeaure.Requests.Commands;
using Application.Features.PostFeature.Handlers.Commands;
using Application.Features.PostFeature.Requests.Commands;
using Application.Profiles;
using Application.Response;
using Application.Tests.Mocks;
using Application.Tests.Mocs;
using AutoMapper;
using MediatR;
using Moq;
using Shouldly;

namespace Application.Tests.Features.PostReactionFeature.Commands
{
    public class CreatePostReactionCommandTest
    {            
            private readonly IMapper _mapper;
            private readonly Mock<IUnitOfWork> _mockUnitOfWork;    
            private readonly Mock<IMediator> _mediator; 
            private ReactionDTO testReaction;
            public CreatePostReactionCommandTest()
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
        public async Task Valid_PostReaction_Added()
        {
            // arrange
            _mediator.Setup(
                    x => x.Send(It.IsAny<CreateNotification>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);
            
            var mocPostReactionRepository = MockPostReactionRepository.GetPostReactionRepository().Object;
            var mockPostRepository = MockPostRepository.GetPostRepository().Object;
            var _handler = new PostReactionHandler(_mediator.Object,_mockUnitOfWork.Object,_mapper);
                         
            var result = await _handler.Handle(new PostReactionCommand() { UserId = 1,ReactionData = testReaction}, CancellationToken.None);
            result.ShouldBeOfType<BaseResponse<int>>();
        }

        [Fact]
        public async Task IValid_PostReaction_Added()
        {
            // arrange
            _mediator.Setup(
                    x => x.Send(It.IsAny<CreateNotification>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);
            
            var mocPostReactionRepository = MockPostReactionRepository.GetPostReactionRepository().Object;
            var mockPostRepository = MockPostRepository.GetPostRepository().Object;
            var _handler = new PostReactionHandler(_mediator.Object,_mockUnitOfWork.Object,_mapper);
            testReaction.ReactionType = "Like";          
            await Should.ThrowAsync<ValidationException>(async () =>
               await _handler.Handle(new PostReactionCommand() { UserId = 1,ReactionData = testReaction}, CancellationToken.None));
        }

    }
}