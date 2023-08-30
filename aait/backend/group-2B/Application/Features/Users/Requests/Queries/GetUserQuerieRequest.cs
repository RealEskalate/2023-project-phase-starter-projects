using Application.DTOs.Common;
using MediatR;
using SocialSync.Application.Common.Responses;

namespace Application.Features.Users.Requests.Queries;

public class GetUserQuerieRequest : IRequest<CommonResponse<UserDto>>
{
    public int Id {get; set;}
}
