using Applicatin.Features.Users.Handlers.Commands;
using Application.DTOs.Common;
using Application.Features.Users.Requests.Commands;
using AutoMapper;
using HRLeaveManagement.Application.Profiles;
using Moq;
using Shouldly;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.Tests.Mocks;

namespace SocialSync.Application.Tests.Features.Authentication.Handlers.Commands;

public class FollowUserCommandHandlerTest
{
    private readonly IMapper _mapper;
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly FollowUserCommandHandler _handler;

    public FollowUserCommandHandlerTest()
    {
        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<AuthenticationMappingProfile>();
        });
        _mapper = mapperConfig.CreateMapper();

        _mockUnitOfWork = MockUnitOfWork.GetMockUnitOfWork();
        _handler = new FollowUserCommandHandler(_mapper, _mockUnitOfWork.Object);
    }

    [Fact]
    public async Task Valid_FollowUser()
    {
        var followUnfollowDto = new FollowUnFollowDto { FollwerId = 1, FollowedId = 2 };
        var request = new FollowUserCommandRequest { FollowUnfollowDto = followUnfollowDto };

        var result = await _handler.Handle(request, CancellationToken.None);

        result.IsSuccess.ShouldBeFalse();
    }

    [Fact]
    public async Task Invalid_FollowUser()
    {
        var followUnfollowDto = new FollowUnFollowDto { FollwerId = 1, FollowedId = 2 };
        var request = new FollowUserCommandRequest { FollowUnfollowDto = followUnfollowDto };

        await _handler.Handle(request, CancellationToken.None);
        var result = await _handler.Handle(request, CancellationToken.None);

        result.IsSuccess.ShouldBeTrue();
    }
}
