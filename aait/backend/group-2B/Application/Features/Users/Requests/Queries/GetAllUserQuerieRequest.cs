
using Application.DTOs.Common;
using MediatR;
using SocialSync.Application.Common.Responses;

namespace Application.Features.Users.Requests.Queries;

public class GetAllUserQuerieRequest : IRequest<CommonResponse<List<UserDto>>>
{
    
}
