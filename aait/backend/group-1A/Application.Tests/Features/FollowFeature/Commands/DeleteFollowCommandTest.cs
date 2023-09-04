using Application.Contracts;
using Application.DTO.FollowDTo;
using Application.Exceptions;
using Application.Features.FollowFeature.Handlers.Commands;
using Application.Features.FollowFeature.Requests.Commands;
using Application.Features.NotificationFeaure.Requests.Commands;
using Application.Profiles;
using Application.Response;
using Application.Tests.Mocks;
using Application.Tests.Mocs;
using AutoMapper;
using MediatR;
using Moq;
using Shouldly;

namespace Application.Tests.Features.FollowFeature.Commands
{
    public class DeleteFollowCommandTest
    {            
            private readonly IMapper _mapper;
            private readonly Mock<IUnitOfWork> _mockUnitOfWork;    

            private readonly Mock<IMediator> _mediator; 
            private readonly FollowDTO _followDTO;
            private  DeleteFollowCommandHandler _handler;
            public DeleteFollowCommandTest()
            {
                _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();
                var mapperConfig = new MapperConfiguration(c => 
                {
                    c.AddProfile<MappingProfile>();
                });
                _mapper = mapperConfig.CreateMapper(); 
                _mediator = new Mock<IMediator>();
               
                _followDTO = new FollowDTO
                {
                    FolloweeId = 3,
                    FollowerId = 1
                };
            }

        
        public async Task ValidFollowDelete()
        {
            // arrange
            _mediator.Setup(
                    x => x.Send(It.IsAny<CreateNotification>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);
            

            _handler = new DeleteFollowCommandHandler(_mediator.Object,_mapper,_mockUnitOfWork.Object);
                         
            var result = await _handler.Handle(new DeleteFollowCommand() { FollowDTO = _followDTO }, CancellationToken.None);
            result.ShouldBeOfType<BaseResponse<int>>();
        }

        
        [Fact]
        public async Task DeleteNonExistentFollow()
        {
            // arrange
            _mediator.Setup(
                    x => x.Send(It.IsAny<CreateNotification>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);
            
            _handler = new DeleteFollowCommandHandler(_mediator.Object,_mapper,_mockUnitOfWork.Object);
            _followDTO.FolloweeId = 100;

            await Should.ThrowAsync<ValidationException>(async () =>
                await _handler.Handle(new DeleteFollowCommand() { FollowDTO = _followDTO }, CancellationToken.None));
        }
    }
}