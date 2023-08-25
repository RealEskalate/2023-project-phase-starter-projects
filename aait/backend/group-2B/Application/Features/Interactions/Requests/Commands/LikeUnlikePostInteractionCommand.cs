using SocialSync.Application.Common.Responses;
using MediatR;
using SocialSync.Application.DTOs.InteractionDTOs;
using SocialSync.Domain.Entities;

namespace SocialSync.Application.Features.Interactions.Requests.Commands;

public class LikeUnlikePostInteractionCommand : IRequest<BaseCommandResponse>
{
    public required InteractionDto LikeDto { get; set; }
}