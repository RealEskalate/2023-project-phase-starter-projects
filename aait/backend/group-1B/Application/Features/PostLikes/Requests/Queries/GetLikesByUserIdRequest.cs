using Application.DTOs.PostLikes;
using MediatR;

namespace Application.Features.PostLikes.Requests.Queries;

public class GetLikesByUserIdRequest : IRequest<List<PostLikeContentDto>>
{
    public int UserId { get; set; }
}