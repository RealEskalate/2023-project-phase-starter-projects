using Application.Contracts;
using Application.DTO.UserDTO.DTO;
using Application.Exceptions;
using Application.Features.UserFeature.Handlers.Commands;
using Application.Features.UserFeature.Requests.Commands;
using Application.Profiles;
using Application.Tests.Mocks;
using AutoMapper;
using Moq;
using Shouldly;

namespace Application.Tests.Features.UserFeatureTests.Handlers
{
    public class UpdateUserHandlerTests
    {
        private readonly IMapper _mapper;
         private readonly Mock<IUnitOfWork> _mockUnitOfWork;  
        public UpdateUserHandlerTests()
        {
            _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c => 
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            
        }

        [Fact]
        public async Task Handle_ShouldUpdateUserSuccessfully()
        {
            var _handler = new UpdateUserHandler(_mockUnitOfWork.Object, _mapper);
            var UserUpdateData = new UserUpdateDTO
                {
                    Username = "UpdatedJohn",
                    Email = "updated.john@example.com",
                    Password = "newPassword123"
                
            };

            var result = await _handler.Handle(new UpdateUserCommand{userId = 1,UserUpdateData = UserUpdateData}, CancellationToken.None);
            
            result.ShouldBeOfType<UserResponseDTO>();
            Assert.Equal("UpdatedJohn", result.Username);
            Assert.Equal("updated.john@example.com", result.Email);
        }

        [Fact]
        public async Task Handle_ShouldThrowExceptionForInvalidUserId()
        {
            var _handler = new UpdateUserHandler(_mockUnitOfWork.Object, _mapper);
            var UserUpdateData = new UserUpdateDTO
                {
                    Username = "InvalidJohn",
                    Email = "invalid.john@example.com",
                    Password = "invalidPassword"
                };

            await Should.ThrowAsync<BadRequestException>(
                async () =>
                    await _handler.Handle(new UpdateUserCommand(){userId = -1, UserUpdateData = UserUpdateData}, CancellationToken.None)
                );
        }

        [Fact]
        public async Task Handle_ShouldThrowExceptionForInvalidData()
        {
            var _handler = new UpdateUserHandler(_mockUnitOfWork.Object, _mapper);
            var UserUpdateData = new UserUpdateDTO{
                Username = "",
                Email = "",
                Password = ""
            };

            await Should.ThrowAsync<ValidationException>(
                async () =>
                    await _handler.Handle(new UpdateUserCommand(){userId = 1,UserUpdateData=UserUpdateData }, CancellationToken.None));

        }

    }
}
