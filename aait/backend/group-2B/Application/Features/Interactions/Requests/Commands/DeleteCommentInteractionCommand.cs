using MediatR;
using SocialSync.Application.Common.Responses;
using SocialSync.Application.DTOs.InteractionDTOs.CommentDTOs;

namespace SocialSync.Application.Features.Interactions.Requests.Commands;
public class DeleteCommentInteractionCommand : IRequest<CommonResponse<int>>
{
    public required DeleteCommentInteractionDto DeleteCommentInteractionDto { get; set; }
}

