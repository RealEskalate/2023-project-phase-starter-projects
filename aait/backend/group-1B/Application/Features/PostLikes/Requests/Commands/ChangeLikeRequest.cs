using Application.DTOs.PostLikes;
using MediatR;

namespace Application.Features.PostLikes.Requests.Commands;

public class ChangeLikeRequest : IRequest<Unit>
{
    public ChangeLikeDto ChangeLike { get; set; }
}