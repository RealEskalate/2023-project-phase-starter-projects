
using Application.Contracts;
using Application.DTO.PostDTO.DTO;
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
    public class CreatePostHandlerTest
    {
         private readonly IMapper _mapper;
         private readonly Mock<IUnitOfWork> _mockUnitOfWork;    

         private readonly Mock<IMediator> _mediator;     

         public CreatePostHandlerTest()
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
            public async Task CreatePostValidTest()
            {
               
                var handler = new CreatePostHandler(_mapper, _mockUnitOfWork.Object, _mediator.Object);

                var newPost = new PostCreateDTO()
                {
                    Title = "new Data",
                    Content = "new Data content"
                };
                _mediator.Setup(
                    x => x.Send(It.IsAny<CreateNotification>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);

                var result = await handler.Handle(new CreatePostCommand() { userId = 1, NewPostData = newPost }, CancellationToken.None);

                result.ShouldBeOfType<BaseResponse<PostResponseDTO>>();                 
            }
         
    }
}