using MediatR;
using SocialSync.Domain.Entities;

namespace SocialSync.Application.Features.Requests;

public class DeleteTagRequest : IRequest<Unit>{
    public Tag tag;
}