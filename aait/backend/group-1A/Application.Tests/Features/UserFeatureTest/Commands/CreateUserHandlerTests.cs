using Application.Contracts;
using Application.DTO.UserDTO.DTO;
using Application.Exceptions;
using Application.Features.UserFeature.Handlers.Commands;
using Application.Features.UserFeature.Requests.Commands;
using Application.Profiles;
using Application.Response;
using Application.Tests.Mocks;
using AutoMapper;
using Moq;
using Shouldly;

namespace Application.Tests.Features.UserFeatureTests.Commands
{
    public class CreateUserHandlerTests
    {
        private readonly IMapper _mapper;
         private readonly Mock<IUnitOfWork> _mockUnitOfWork;   

        public CreateUserHandlerTests()
        {
           _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c => 
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

        }

        [Fact]
        public async Task CreateUserHandler_ValidUserData_CreatesUserSuccessfully()
        {
            // Arrange
            var handler = new CreateUserHandler(_mapper, _mockUnitOfWork.Object);
            var validUserCommand = new CreateUserCommand
            {
                NewUserData = new UserCreateDTO
                {
                    Id = 3,
                    Username = "AliceCooper123",
                    Email = "alice.cooper@example.com",
                    Password = "AliceSecurePass123"
                }
            };
            // Act
            var response = await handler.Handle(validUserCommand, new CancellationToken());
            // Assert
            response.ShouldBeOfType<BaseResponse<string>>();
            response.ShouldNotBeNull();
            response.Success.ShouldBeTrue();
            response.Message.ShouldBe("User created successfully");
        }

        [Fact]
        public async Task CreateUserHandler_InvalidUserData_ReturnsFailureResponse()
        {
            // Arrange
            var handler = new CreateUserHandler(_mapper, _mockUnitOfWork.Object);

            var invalidUserCommand = new CreateUserCommand
            {
                NewUserData = new UserCreateDTO
                {
                    Id = 0,
                    Username = "",
                    Email = "",
                    Password = ""
                }
            };
            // Act & Assert
            var exception = await Assert.ThrowsAsync<BadRequestException>(() => handler.Handle(invalidUserCommand, new CancellationToken()));

            // Checking if the exception message is as expected
            exception.Message.ShouldBe("Unable to create a user");
        }

    }
}
