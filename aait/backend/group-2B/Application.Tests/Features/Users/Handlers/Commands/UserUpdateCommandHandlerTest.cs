using Application.Features.Users.Handlers.Commands;
using AutoMapper;
using HRLeaveManagement.Application.Profiles;
using Moq;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.Tests.Mocks;

namespace SocialSync.Application.Tests.Features.Authentication.Handlers.Commands;

public class UserUpdateCommandHandlerTest
{
    private readonly IMapper _mapper;
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly UserUpdateCommandHandler _handler;

    public UserUpdateCommandHandlerTest()
    {
        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<AuthenticationMappingProfile>();
        });
        _mapper = mapperConfig.CreateMapper();

        _mockUnitOfWork = MockUnitOfWork.GetMockUnitOfWork();
        _handler = new UserUpdateCommandHandler(_mockUnitOfWork.Object, _mapper);
    }

    [Fact]
    public async Task Valid_UserUpdate() { }
}
