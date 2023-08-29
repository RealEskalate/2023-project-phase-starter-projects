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
    public class GetAllUserHandlerTests
    {
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly Mock<IMapper> _mockMapper;

        public GetAllUserHandlerTests()
        {
            _mockUserRepository = UserRepositoryMock.GetRepository();
            _mockMapper = new Mock<IMapper>();
        }

        [Fact]
        public async Task GetAllUserHandler_ShouldReturnAllUsers()
        {
            // Arrange
            var handler = new GetAllUserHandler(_mockUserRepository.Object, _mockMapper.Object);
            var users = await _mockUserRepository.Object.GetAllUsers();
            var expectedUsers = new List<UserResponseDTO>
            {
                new UserResponseDTO { Username = "JohnDoe89", Email = "john.doe@example.com" },
                new UserResponseDTO { Username = "JaneSmith92", Email = "jane.smith@example.com" }
            };

            _mockMapper.Setup(m => m.Map<List<UserResponseDTO>>(users)).Returns(expectedUsers);

            // Act
            var result = await handler.Handle(new GetAllUsersQuery(), new CancellationToken());

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBeOfType<List<UserResponseDTO>>();
            result.Count.ShouldBe(2);
            result[0].Username.ShouldBe("JohnDoe89");
            result[0].Email.ShouldBe("john.doe@example.com");
            result[1].Username.ShouldBe("JaneSmith92");
            result[1].Email.ShouldBe("jane.smith@example.com");
        }
    }
}
