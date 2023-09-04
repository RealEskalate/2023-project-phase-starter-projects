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
    public class CreateFollowCommandTest
    {            
            private readonly IMapper _mapper;
            private readonly Mock<IUnitOfWork> _mockUnitOfWork;    

            private readonly Mock<IMediator> _mediator; 
            private readonly FollowDTO _followDTO;
            private  CreateFollowCommandHandler _handler;
            public CreateFollowCommandTest()
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
                    FolloweeId = 1,
                    FollowerId = 3
                };
            }

        public async Task Valid_Follow_Added()
        {
            // arrange
            _mediator.Setup(
                    x => x.Send(It.IsAny<CreateNotification>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);
            
            var mocFollowRepository = MockFollowRepository.GetFollowRepository().Object;
            
            _handler = new CreateFollowCommandHandler(_mapper,_mockUnitOfWork.Object,_mediator.Object);
                         
            var result = await _handler.Handle(new CreateFollowCommand() { FollowDTO = _followDTO }, CancellationToken.None);
            result.ShouldBeOfType<BaseResponse<int>>();
        }

        [Fact]
        public async Task FollowWithIdOutOfRange()
        {
            // arrange
            _mediator.Setup(
                    x => x.Send(It.IsAny<CreateNotification>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);
            
            _handler = new CreateFollowCommandHandler(_mapper,_mockUnitOfWork.Object,_mediator.Object);
            _followDTO.FolloweeId = -1;

           await Should.ThrowAsync<ValidationException>(async () =>
                await _handler.Handle(new CreateFollowCommand() { FollowDTO = _followDTO }, CancellationToken.None));
        }

        [Fact]
        public async Task NonExistentFollowee()
        {
            // arrange
            _mediator.Setup(
                    x => x.Send(It.IsAny<CreateNotification>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);

            _handler = new CreateFollowCommandHandler(_mapper,_mockUnitOfWork.Object,_mediator.Object);
            _followDTO.FolloweeId = 100;

            await Should.ThrowAsync<ValidationException>(async () =>
                await _handler.Handle(new CreateFollowCommand() { FollowDTO = _followDTO }, CancellationToken.None));
        }

        [Fact]
        public async Task FollowAlreadyFollowedUserTest()
        {
            // arrange
            _mediator.Setup(
                    x => x.Send(It.IsAny<CreateNotification>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);

            _handler = new CreateFollowCommandHandler(_mapper,_mockUnitOfWork.Object,_mediator.Object);
            _followDTO.FolloweeId = 2;
            _followDTO.FollowerId = 1;

            await Should.ThrowAsync<ValidationException>(async () =>
                await _handler.Handle(new CreateFollowCommand() { FollowDTO = _followDTO }, CancellationToken.None));
        }
    }
}