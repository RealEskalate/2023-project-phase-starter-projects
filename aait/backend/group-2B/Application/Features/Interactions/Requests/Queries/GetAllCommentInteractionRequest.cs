using MediatR;
using SocialSync.Application.Common.Responses;
using SocialSync.Application.DTOs.InteractionDTOs;


namespace SocialSync.Application.Features.Comments.Requests.Queries;
public class GetAllCommentInteractionRequest : IRequest<CommonResponse<List<InteractionDto>>>
{
    public required int PostId { get; set; }
}
