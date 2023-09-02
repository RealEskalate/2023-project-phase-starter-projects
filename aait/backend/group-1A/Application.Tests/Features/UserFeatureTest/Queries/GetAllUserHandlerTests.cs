using Application.Contracts;
using Application.DTO.UserDTO.DTO;
using Application.Features.UserFeature.Handlers.Queries;
using Application.Features.UserFeature.Requests.Queries;
using Application.Profiles;
using Application.Tests.Mocks;
using AutoMapper;
using Moq;
using Shouldly;


namespace Application.Tests.Features.UserFeatureTests.Queries
{
    public class GetAllUserHandlerTests
    {
        private readonly IMapper _mapper;
         private readonly Mock<IUnitOfWork> _mockUnitOfWork; 

        public GetAllUserHandlerTests()
        {
            _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c => 
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

        }

        [Fact]
        public async Task GetAllUserHandler_ShouldReturnAllUsers()
        {
            // Arrange
            var handler = new GetAllUserHandler(_mockUnitOfWork.Object, _mapper);
            // Act
            var result = await handler.Handle(new GetAllUsersQuery(), CancellationToken.None);

            // Assert
            // result.ShouldNotBeNull();
            result.ShouldBeOfType<List<UserResponseDTO>>();
        }
    }
}
