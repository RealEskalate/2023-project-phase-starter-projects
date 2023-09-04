using Application.Contracts;
using Application.DTO.UserDTO.DTO;
using Application.Exceptions;
using Application.Features.UserFeature.Handlers.Queries;
using Application.Features.UserFeature.Requests.Queries;
using Application.Profiles;
using Application.Tests.Features.UserFeatureTests.Mocks;
using Application.Tests.Mocks;
using AutoMapper;
using Moq;
using Shouldly;

namespace Application.Tests.Features.UserFeatureTests.Queries
{
    public class GetSingleUserHandlerTests
    {
        private readonly IMapper _mapper;
         private readonly Mock<IUnitOfWork> _mockUnitOfWork;

        public GetSingleUserHandlerTests()
        {
             _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c => 
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }


        [Fact]
        public async Task GetSingleUserHandler_ValidUserId_ReturnsUser()
        {
            // Arrange
            var handler = new GetSingleUserHandler(_mockUnitOfWork.Object, _mapper);
            // Act
            var result = await handler.Handle(new GetSingleUserQuery { userId = 1 }, new CancellationToken());

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBeOfType<UserResponseDTO>();
        }


        [Fact]
        public async Task GetSingleUserHandler_InvalidUserId_ThrowsException()
        {
            // Arrange
            var handler = new GetSingleUserHandler(_mockUnitOfWork.Object, _mapper);

            // Act & Assert
            await Assert.ThrowsAsync<BadRequestException>(() => handler.Handle(new GetSingleUserQuery { userId = 0 }, new CancellationToken()));
        }

        [Fact]
        public async Task GetSingleUserHandler_NonExistentUser_ThrowsException()
        {
            // Arrange
            var handler = new GetSingleUserHandler(_mockUnitOfWork.Object, _mapper);

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() => handler.Handle(new GetSingleUserQuery { userId = 9999 }, new CancellationToken()));
        }

        
    }
}