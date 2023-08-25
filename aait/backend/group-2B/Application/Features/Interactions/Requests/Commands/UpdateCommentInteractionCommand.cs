using MediatR;
using SocialSync.Application.Common.Responses;
using SocialSync.Application.DTOs.InteractionDTOs.CommentDTOs;


namespace SocialSync.Application.Features.Comments.Requests.Commands;
public class UpdateCommentInteractionCommand : IRequest<CommonResponse<int>>
{
    public required UpdateCommentInteractionDto UpdateCommentDto { get; set; }
}

