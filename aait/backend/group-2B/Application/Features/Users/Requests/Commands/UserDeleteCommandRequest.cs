using Application.DTOs.Users;
using MediatR;
using SocialSync.Application.Common.Responses;

namespace Application.Features.Users.Requests.Commands;

public class UserDeleteCommandRequest : IRequest<CommonResponse<int>>
{
    public required UserDeleteDto UserdeleteDto { get; set; }
}
