using Application.Contracts;
using Application.DTO.UserDTO.DTO;
using Application.Features.UserFeature.Handlers.Queries;
using Application.Features.UserFeature.Requests.Queries;
using Application.Tests.Features.UserFeatureTests.Mocks;
using AutoMapper;
using Moq;
using Shouldly;

namespace Application.Tests.Features.UserFeatureTests.Queries
{
    public class GetSingleUserHandlerTests
    {
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly Mock<IMapper> _mockMapper;

        public GetSingleUserHandlerTests()
        {
            _mockUserRepository = UserRepositoryMock.GetRepository();
            _mockMapper = new Mock<IMapper>();
        }

        [Fact]
        public async Task GetSingleUserHandler_InvalidUserId_ThrowsException()
        {
            // Arrange
            var handler = new GetSingleUserHandler(_mockUserRepository.Object, _mockMapper.Object);

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => handler.Handle(new GetSingleUserQuery { userId = 0 }, new CancellationToken()));
        }

        [Fact]
        public async Task GetSingleUserHandler_NonExistentUser_ThrowsException()
        {
            // Arrange
            var handler = new GetSingleUserHandler(_mockUserRepository.Object, _mockMapper.Object);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => handler.Handle(new GetSingleUserQuery { userId = 9999 }, new CancellationToken()));
        }

        [Fact]
        public async Task GetSingleUserHandler_ValidUserId_ReturnsUser()
        {
            // Arrange
            var handler = new GetSingleUserHandler(_mockUserRepository.Object, _mockMapper.Object);
            var user = await _mockUserRepository.Object.Get(1);
            var expectedUser = new UserResponseDTO { Username = "JohnDoe89", Email = "john.doe@example.com" };

            _mockMapper.Setup(m => m.Map<UserResponseDTO>(user)).Returns(expectedUser);

            // Act
            var result = await handler.Handle(new GetSingleUserQuery { userId = 1 }, new CancellationToken());

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBeOfType<UserResponseDTO>();
            result.Username.ShouldBe("JohnDoe89");
            result.Email.ShouldBe("john.doe@example.com");
        }
    }
}