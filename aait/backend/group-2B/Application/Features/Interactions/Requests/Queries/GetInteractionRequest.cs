using MediatR;
using SocialSync.Application.Common.Responses;
using SocialSync.Application.DTOs.InteractionDTOs;
using SocialSync.Domain.Entities;

namespace SocialSync.Application.Features.Comments.Requests.Queries;

public class GetInteractionRequest : IRequest<CommonResponse<InteractionDto>>
{
    public int Id { get; set; }
}