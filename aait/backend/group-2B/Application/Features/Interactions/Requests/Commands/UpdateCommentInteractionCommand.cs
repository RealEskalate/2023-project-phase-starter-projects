using MediatR;
using SocialSync.Application.DTOs.InteractionDTOs.CommentDTOs;


namespace SocialSync.Application.Features.Comments.Requests.Commands;
public class UpdateCommentInteractionCommand : IRequest<Unit>
{
    public required UpdateCommentInteractionDTO UpdateCommentDto { get; set; }
}

