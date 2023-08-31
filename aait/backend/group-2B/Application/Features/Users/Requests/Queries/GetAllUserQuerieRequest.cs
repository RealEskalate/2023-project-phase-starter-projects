using MediatR;
using SocialSync.Application.Common.Responses;
using SocialSync.Application.DTOs.Authentication;

namespace Application.Features.Users.Requests.Queries;

public class GetAllUserQuerieRequest : IRequest<CommonResponse<List<UserDto>>> { }
