using Application.Contracts;
using Application.DTO.CommentDTO.DTO;
using Application.Exceptions;
using Application.Features.CommentFeatures.Handlers.Commands;
using Application.Features.CommentFeatures.Requests.Commands;
using Application.Features.NotificationFeaure.Requests.Commands;
using Application.Profiles;
using Application.Response;
using Application.Tests.Mocks;
using AutoMapper;
using MediatR;
using Moq;
using Shouldly;

namespace Application.Tests.Features.CommentFeatureTest.Commands
{
    public class UpdateCommentHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;    

        private readonly Mock<IMediator> _mediator; 
        CommentUpdateDTO testComment;
        public UpdateCommentHandlerTest()
        {

            _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c => 
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper(); 
            _mediator = new Mock<IMediator>();
            
            testComment = new CommentUpdateDTO()
            {
                Content = "Test comment"
            };
        }

        [Fact]
        public async Task UpdateCommentValidTest()
        {
            _mediator.Setup(
                    x => x.Send(It.IsAny<CreateNotification>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);
            
            var  _mockRepo = MockCommentRepository.GetCommentRepository();

            var handler = new UpdateCommentHandler(_mockUnitOfWork.Object, _mapper, _mediator.Object);

            testComment.Content = "Updated comment";
            var result = await handler.Handle(new UpdateCommentCommand()
            {
             Id  = 1,
             userId = 1,
             CommentData = testComment

            }, CancellationToken.None);

            result.ShouldBeOfType<BaseResponse<CommentResponseDTO>>();
        }

        [Fact]
        public async Task UpdateCommentWithNoContentTest()
        {
            _mediator.Setup(
                    x => x.Send(It.IsAny<CreateNotification>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);
            
            var  _mockRepo = MockCommentRepository.GetCommentRepository();

            var handler = new UpdateCommentHandler(_mockUnitOfWork.Object, _mapper, _mediator.Object);

            testComment.Content = "";
            await Should.ThrowAsync<ValidationException>(async () => await handler.Handle(new UpdateCommentCommand()
            {
             Id  = 1,
             userId = 1,
             CommentData = testComment

            }, CancellationToken.None));

        }
        [Fact]
        public async Task UpdateNonExistentCommentTest()
        {
            _mediator.Setup(
                    x => x.Send(It.IsAny<CreateNotification>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);
            
            var  _mockRepo = MockCommentRepository.GetCommentRepository();

            var handler = new UpdateCommentHandler(_mockUnitOfWork.Object, _mapper, _mediator.Object);

            testComment.Content = "Updated comment";
            await Should.ThrowAsync<NotFoundException>(async () => await handler.Handle(new UpdateCommentCommand()
            {
             Id  = 100,
             userId = 1,
             CommentData = testComment

            }, CancellationToken.None));

        }
    }
}
