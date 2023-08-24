using MediatR;
using SocialSync.Domain.Entities;

namespace SocialSync.Application.Features.Comments.Requests.Queries;

public class GetInteractionRequest : IRequest<Interaction>
{
    public int Id { get; set; }
}