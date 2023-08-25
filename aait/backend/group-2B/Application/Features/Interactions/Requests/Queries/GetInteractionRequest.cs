using MediatR;
using SocialSync.Application.Common.Responses;
using SocialSync.Domain.Entities;

namespace SocialSync.Application.Features.Comments.Requests.Queries;

public class GetInteractionRequest : IRequest<CommonResponse<Interaction>>
{
    public int Id { get; set; }
}