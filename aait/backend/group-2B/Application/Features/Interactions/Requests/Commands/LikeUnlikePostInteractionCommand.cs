using SocialSync.Application.Responses;
using MediatR;
using SocialSync.Application.DTOs.InteractionDTOs;
using SocialSync.Domain.Entities;

namespace SocialSync.Application.Features.Interactions.Requests.Commands;

public class LikeUnlikePostInteractionCommand : IRequest<BaseCommandResponse>
{
    public required InteractionDTO LikeDto { get; set; }
}