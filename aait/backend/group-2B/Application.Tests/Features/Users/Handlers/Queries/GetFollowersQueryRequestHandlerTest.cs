using Applicatin.Features.Users.Handlers.Commands;
using Application.DTOs.Common;
using Application.Features.Users.Handlers.Queries;
using Application.Features.Users.Requests.Commands;
using Application.Features.Users.Requests.Queries;
using AutoMapper;
using HRLeaveManagement.Application.Profiles;
using Moq;
using Shouldly;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.Tests.Mocks;

namespace SocialSync.Application.Tests.Features.Authentication.Handlers.Commands;

public class GetFollowersQueryRequestHandlerTest
{
    private readonly IMapper _mapper;
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly GetFollowersQueryRequestHandler _handler;
    private readonly FollowUserCommandHandler _followUserCommandHandler;

    public GetFollowersQueryRequestHandlerTest()
    {
        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<AuthenticationMappingProfile>();
        });
        _mapper = mapperConfig.CreateMapper();

        _mockUnitOfWork = MockUnitOfWork.GetMockUnitOfWork();
        _handler = new GetFollowersQueryRequestHandler(_mockUnitOfWork.Object, _mapper);
        _followUserCommandHandler = new FollowUserCommandHandler(_mapper, _mockUnitOfWork.Object);
    }

    [Fact]
    public async Task Valid_GetFollowersUserHasNoFollowers()
    {
        var result = await _handler.Handle(
            new GetFollowersQuerieRequest { Id = 1 },
            CancellationToken.None
        );

        result.ShouldBeNull();
    }

    [Fact]
    public async Task Valid_GetFollowersUserHasFollowers()
    {
        var followUnfollowDto = new FollowUnFollowDto { FollwerId = 1, FollowedId = 1 };
        await _followUserCommandHandler.Handle(
            new FollowUserCommandRequest { FollowUnfollowDto = followUnfollowDto },
            CancellationToken.None
        );

        var result = await _handler.Handle(
            new GetFollowersQuerieRequest { Id = 2 },
            CancellationToken.None
        );

        result.ShouldBeNull();
    }
}
