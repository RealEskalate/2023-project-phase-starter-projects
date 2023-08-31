using Application.DTOs.Users;
using Application.Features.Users.Handlers.Commands;
using Application.Features.Users.Requests.Commands;
using AutoMapper;
using HRLeaveManagement.Application.Profiles;
using Moq;
using Shouldly;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.Tests.Mocks;

namespace SocialSync.Application.Tests.Features.Authentication.Handlers.Commands;

public class UserDeleteCommandHandlerTest
{
    private readonly IMapper _mapper;
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly UserDeleteCommandHandler _handler;

    public UserDeleteCommandHandlerTest()
    {
        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<AuthenticationMappingProfile>();
        });
        _mapper = mapperConfig.CreateMapper();

        _mockUnitOfWork = MockUnitOfWork.GetMockUnitOfWork();
        _handler = new UserDeleteCommandHandler(_mockUnitOfWork.Object);
    }

    [Fact]
    public async Task Valid_DeleteUser()
    {
        var result = await _handler.Handle(
            new UserDeleteCommandRequest { UserdeleteDto = new UserDeleteDto { Owner = 1 } },
            CancellationToken.None
        );

        result.IsSuccess.ShouldBeTrue();
    }

    [Fact]
    public async Task Invalid_DeleteUser()
    {
        await _handler.Handle(
            new UserDeleteCommandRequest { UserdeleteDto = new UserDeleteDto { Owner = 2 } },
            CancellationToken.None
        );

        var result = await _handler.Handle(
            new UserDeleteCommandRequest { UserdeleteDto = new UserDeleteDto { Owner = 2 } },
            CancellationToken.None
        );

        result.IsSuccess.ShouldBeFalse();
    }
}
