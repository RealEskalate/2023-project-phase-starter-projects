using MediatR;
using SocialSync.Domain.Entities;

namespace SocialSync.Application.Features.Comments.Requests.Queries;
public class GetAllCommentInteractionRequest : IRequest<List<Interaction>>
{
    public required int PostId { get; set; }
}
