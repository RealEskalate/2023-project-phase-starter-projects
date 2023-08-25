using SocialSync.Application.Common.Responses;
using MediatR;
using SocialSync.Application.DTOs.InteractionDTOs;


namespace SocialSync.Application.Features.Interactions.Requests.Commands;
public class CreateCommentInteractionCommand : IRequest<BaseCommandResponse>
{
    public required InteractionDto CreateCommentDto { get; set; }
}

