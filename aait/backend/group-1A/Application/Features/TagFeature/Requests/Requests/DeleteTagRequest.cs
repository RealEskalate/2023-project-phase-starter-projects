using MediatR;

namespace SocialSync.Application.Features.Requests;

public class DeleteTagRequest : IRequest<Unit>{
    public int Id {get; set;}
}