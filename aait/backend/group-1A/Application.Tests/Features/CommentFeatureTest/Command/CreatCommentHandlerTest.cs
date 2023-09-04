using Application.DTO.CommentDTO.DTO;
using Application.Profiles;
using Application.Response;
using Application.Tests.Mocks;
using AutoMapper;
using Shouldly;
using Application.Features.CommentFeatures.Handlers.Commands;
using Application.Features.CommentFeatures.Requests.Commands;
using Application.Exceptions;
using MediatR;
using Moq;
using Application.Contracts;
using Application.Features.NotificationFeaure.Requests.Commands;

namespace Application.Tests.Features.CommentFeatureTest.Commands
{
    public class CreateCommentHandlerTest
    {
        private readonly IMapper _mapper;
         private readonly Mock<IUnitOfWork> _mockUnitOfWork;    

         private readonly Mock<IMediator> _mediator; 
        private CommentCreateDTO testComment;
        public CreateCommentHandlerTest()
        {

             _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c => 
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper(); 
            _mediator = new Mock<IMediator>(); 

            testComment = new CommentCreateDTO()
            {
                PostId = 1,
                Content = "Test comment"
            };
        }

        [Fact]
        public async Task ValidCreateCommentTest()
        {
            // arrange
            _mediator.Setup(
                    x => x.Send(It.IsAny<CreateNotification>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);
            
            var mocCommentRepository = MockCommentRepository.GetCommentRepository().Object;
            var mocPostRepository = MockPostRepository.GetPostRepository().Object;
            var handler = new CommentCreateHandler(_mockUnitOfWork.Object,_mapper,_mediator.Object );

            // act
            var result = await handler.Handle(new CommentCreateCommand() {NewCommentData = testComment,userId = 1}, CancellationToken.None);

            // assert
            result.ShouldBeOfType<BaseResponse<CommentResponseDTO>>();
        }

        [Fact]
        public async Task CreateCommentForNonExistentPostTest()
        {
            // arrange
            _mediator.Setup(
                    x => x.Send(It.IsAny<CreateNotification>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);
            
            var mocCommentRepository = MockCommentRepository.GetCommentRepository().Object;
            var mocPostRepository = MockPostRepository.GetPostRepository().Object;
            var handler = new CommentCreateHandler(_mockUnitOfWork.Object,_mapper,_mediator.Object );
            testComment.PostId = 100;

            // act and assert
            await Should.ThrowAsync<NotFoundException>(async () =>
                await handler.Handle(new CommentCreateCommand() {NewCommentData = testComment,userId = 1}, CancellationToken.None));
        }
        [Fact]
        public async Task CreateCommentWithNoContentTest()
        {
            // arrange
            _mediator.Setup(
                    x => x.Send(It.IsAny<CreateNotification>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);
            
            var mocCommentRepository = MockCommentRepository.GetCommentRepository().Object;
            var mocPostRepository = MockPostRepository.GetPostRepository().Object;
            var handler = new CommentCreateHandler(_mockUnitOfWork.Object,_mapper,_mediator.Object );
            testComment.Content = "";

            // act and arrange
            
            await Should.ThrowAsync<ValidationException>(async () =>
                await handler.Handle(new CommentCreateCommand() {NewCommentData = testComment,userId = 1}, CancellationToken.None));
        }
    }
}
