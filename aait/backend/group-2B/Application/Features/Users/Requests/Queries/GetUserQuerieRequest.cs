using MediatR;
using SocialSync.Application.Common.Responses;
using SocialSync.Application.DTOs.Authentication;

namespace Application.Features.Users.Requests.Queries;

public class GetUserQuerieRequest : IRequest<CommonResponse<UserDto>>
{
    public int Id { get; set; }
}
