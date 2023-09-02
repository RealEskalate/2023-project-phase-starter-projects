using Application.Contracts;
using Application.DTO.PostDTO.DTO;
using Application.Exceptions;
using Application.Features.NotificationFeaure.Requests.Commands;
using Application.Features.PostFeature.Handlers.Commands;
using Application.Features.PostFeature.Requests.Commands;
using Application.Profiles;
using Application.Response;
using Application.Tests.Mocks;
using AutoMapper;
using MediatR;
using Moq;
using Shouldly;

namespace Application.Tests.Features.PostFeatureTest.Commands
{
    public class UpdatePostHandlerTest
    {
        private readonly IMapper _mapper;
         private readonly Mock<IUnitOfWork> _mockUnitOfWork;    

         private readonly Mock<IMediator> _mediator; 
        public UpdatePostHandlerTest()
        {
             _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c => 
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper(); 
            _mediator = new Mock<IMediator>();  
        }

        [Fact]
        public async Task UpdatePostValidTest()
        {
            _mediator.Setup(
                    x => x.Send(It.IsAny<CreateNotification>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);
            var handler = new UpdatePostHandler(_mockUnitOfWork.Object, _mapper, _mediator.Object);

            var updatedPost = new PostUpdateDTO(){
                Title = "new updated Data",
                Content = "new Updated Data content"
            };

            // act
            var result = await handler.Handle(new UpdatePostCommand(){Id = 1, userId = 1, PostUpdateData = updatedPost},CancellationToken.None);


            // assert
            result.ShouldBeOfType<BaseResponse<PostResponseDTO>>();
            
        }


        [Fact]
        public async Task UpdatePostNonExistingPostTest()
        {
            // Arrange
            _mediator.Setup(
                    x => x.Send(It.IsAny<CreateNotification>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);
            var handler = new UpdatePostHandler(_mockUnitOfWork.Object, _mapper, _mediator.Object);

            var updatedPost = new PostUpdateDTO()
            {
                Title = "new updated Data",
                Content = "new Updated Data content"
            };

            // Act & 
            await Should.ThrowAsync<NotFoundException>(async () =>
                await handler.Handle(new UpdatePostCommand(){Id = 1000, userId = 1, PostUpdateData = updatedPost},CancellationToken.None)
            );
        }


        [Fact]
        public async Task UpdatePostInvalidDataTest()
        {
            // Arrange
            _mediator.Setup(
                    x => x.Send(It.IsAny<CreateNotification>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);
            var handler = new UpdatePostHandler(_mockUnitOfWork.Object, _mapper, _mediator.Object);

            var updatedPost = new PostUpdateDTO(); // Invalid data, missing required properties

            // Act & Assert
            await Should.ThrowAsync<ValidationException>(async () =>
                await handler.Handle(new UpdatePostCommand() { Id = 1, userId = 1, PostUpdateData = updatedPost }, CancellationToken.None));
        }
    }
}