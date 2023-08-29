using MediatR;
using SocialMediaApp.Application.DTOs.Follows;

namespace SocialMediaApp.Application.Features.Follows.Request.Queries;

public class GetFollowsRequest : IRequest<List<FollowDto>>
{
}