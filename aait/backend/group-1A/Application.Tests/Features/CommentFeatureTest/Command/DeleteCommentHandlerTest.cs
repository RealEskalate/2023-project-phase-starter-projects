using Application.Contracts;
using Application.Exceptions;
using Application.Features.CommentFeatures.Handlers.Commands;
using Application.Features.CommentFeatures.Requests.Commands;
using Application.Features.NotificationFeaure.Requests.Commands;
using Application.Response;
using Application.Tests.Mocks;
using MediatR;
using Moq;
using Shouldly;

namespace Application.Tests.Features.CommentFeatureTest.Commands
{
    public class DeleteCommentHandlerTest
    {
         private readonly Mock<IUnitOfWork> _mockUnitOfWork;    

         private readonly Mock<IMediator> _mediator;
        public DeleteCommentHandlerTest()
        {
            _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();
            _mediator = new Mock<IMediator>();  

        }

        [Fact]
        public async Task DeleteCommentValidTest()
        {
            _mediator.Setup(
                    x => x.Send(It.IsAny<CreateNotification>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);
            
           var mocCommentRepository  = MockCommentRepository.GetCommentRepository().Object;
            var handler = new CommentDeleteHandler(_mockUnitOfWork.Object, _mediator.Object);

            var result = await handler.Handle(new CommentDeleteCommand() { Id = 1 }, CancellationToken.None);

            result.ShouldBeOfType<BaseResponse<int>>();
        }
        [Fact]
        public async Task DeleteCommentWithInValidIdTest()
        {
            _mediator.Setup(
                    x => x.Send(It.IsAny<CreateNotification>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);
            
           var mocCommentRepository  = MockCommentRepository.GetCommentRepository().Object;
            var handler = new CommentDeleteHandler(_mockUnitOfWork.Object, _mediator.Object);
                            
            await Should.ThrowAsync<NotFoundException>(async () =>
                await handler.Handle(new CommentDeleteCommand(), CancellationToken.None));
        }
    }
}
