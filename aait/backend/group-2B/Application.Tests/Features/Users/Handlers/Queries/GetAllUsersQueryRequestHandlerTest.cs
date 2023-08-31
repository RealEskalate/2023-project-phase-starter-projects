using Application.Features.Users.Handlers.Queries;
using Application.Features.Users.Requests.Queries;
using AutoMapper;
using HRLeaveManagement.Application.Profiles;
using Moq;
using Shouldly;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.Tests.Mocks;

namespace SocialSync.Application.Tests.Features.Authentication.Handlers.Commands;

public class GetAllUsersQueryRequestHandlerTest
{
    private readonly IMapper _mapper;
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly GetAllUsersQueryRequestHandler _handler;

    public GetAllUsersQueryRequestHandlerTest()
    {
        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<AuthenticationMappingProfile>();
        });
        _mapper = mapperConfig.CreateMapper();

        _mockUnitOfWork = MockUnitOfWork.GetMockUnitOfWork();
        _handler = new GetAllUsersQueryRequestHandler(_mockUnitOfWork.Object, _mapper);
    }

    [Fact]
    public async Task Valid_GetAllUsers() {
        var result = await _handler.Handle(new GetAllUserQuerieRequest(), CancellationToken.None);

        result.ShouldNotBeNull();
    }
}
