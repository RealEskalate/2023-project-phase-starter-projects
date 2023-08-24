using MediatR;
using SocialSync.Application.DTOs.Common;
using SocialSync.Application.DTOs.InteractionDTOs.CommentDTOs;

namespace SocialSync.Application.Features.Interactions.Requests.Commands;
public class DeleteCommentInteractionCommand : IRequest<Unit>
{
    public required DeleteCommentInteractionDTO DeleteCommentInteractionDto { get; set; }
}

