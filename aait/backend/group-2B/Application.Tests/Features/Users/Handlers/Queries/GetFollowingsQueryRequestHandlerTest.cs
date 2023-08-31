using Application.Features.Users.Handlers.Queries;
using AutoMapper;
using HRLeaveManagement.Application.Profiles;
using Moq;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.Tests.Mocks;

namespace SocialSync.Application.Tests.Features.Authentication.Handlers.Commands;

public class GetFollowingsQueryRequestHandler
{
    private readonly IMapper _mapper;
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly GetFollowersQueryRequestHandler _handler;

    public GetFollowingsQueryRequestHandler()
    {
        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<AuthenticationMappingProfile>();
        });
        _mapper = mapperConfig.CreateMapper();

        _mockUnitOfWork = MockUnitOfWork.GetMockUnitOfWork();
        _handler = new GetFollowersQueryRequestHandler(_mockUnitOfWork.Object, _mapper);
    }

    [Fact]
    public async Task Valid_GetFollowers() { }
}
