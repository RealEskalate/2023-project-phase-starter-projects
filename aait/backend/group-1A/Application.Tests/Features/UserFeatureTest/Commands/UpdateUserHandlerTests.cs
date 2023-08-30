using Application.Contracts;
using Application.DTO.UserDTO.DTO;
using Application.Features.UserFeature.Handlers.Commands;
using Application.Features.UserFeature.Requests.Commands;
using Application.Tests.Features.UserFeatureTests.Mocks;
using AutoMapper;
using Moq;
using SocialSync.Domain.Entities;

namespace Application.Tests.Features.UserFeatureTests.Handlers
{
    public class UpdateUserHandlerTests
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly IMapper _mapper;
        private readonly UpdateUserHandler _handler;

        public UpdateUserHandlerTests()
        {
            _userRepositoryMock = UserRepositoryMock.GetRepository();

            // Setting up Automapper for unit tests
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserUpdateDTO, User>();
                cfg.CreateMap<User, UserResponseDTO>();
            });
            _mapper = mapperConfig.CreateMapper();

            _handler = new UpdateUserHandler(_userRepositoryMock.Object, _mapper);
        }

        [Fact]
        public async Task Handle_ShouldUpdateUserSuccessfully()
        {
            var request = new UpdateUserCommand
            {
                userId = 1,
                UserUpdateData = new UserUpdateDTO
                {
                    Username = "UpdatedJohn",
                    Email = "updated.john@example.com",
                    Password = "newPassword123"
                }
            };

            var result = await _handler.Handle(request, CancellationToken.None);

            Assert.Equal("UpdatedJohn", result.Username);
            Assert.Equal("updated.john@example.com", result.Email);
        }

        [Fact]
        public async Task Handle_ShouldThrowExceptionForInvalidUserId()
        {
            var request = new UpdateUserCommand
            {
                userId = -1, 
                UserUpdateData = new UserUpdateDTO
                {
                    Username = "InvalidJohn",
                    Email = "invalid.john@example.com",
                    Password = "invalidPassword"
                }
            };

            await Assert.ThrowsAsync<Exception>(() => _handler.Handle(request, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_ShouldThrowExceptionForInvalidData()
        {
            var request = new UpdateUserCommand
            {
                userId = 1, 
                UserUpdateData = null 
            };

            await Assert.ThrowsAsync<ArgumentNullException>(() => _handler.Handle(request, CancellationToken.None));
        }

    }
}
