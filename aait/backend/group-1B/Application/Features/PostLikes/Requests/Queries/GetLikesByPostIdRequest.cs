using Application.DTOs.PostLikes;
using MediatR;

namespace Application.Features.PostLikes.Requests.Queries;

public class GetLikesByPostIdRequest : IRequest<List<PostLikeContentDto>>
{
    public int PostId { get; set; }
}