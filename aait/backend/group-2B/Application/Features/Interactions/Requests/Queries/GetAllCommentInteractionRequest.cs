using MediatR;
using SocialSync.Application.Common.Responses;
using SocialSync.Domain.Entities;

namespace SocialSync.Application.Features.Comments.Requests.Queries;
public class GetAllCommentInteractionRequest : IRequest<CommonResponse<List<Interaction>>>
{
    public required int PostId { get; set; }
}
