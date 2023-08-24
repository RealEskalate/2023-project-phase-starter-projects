using MediatR;
using SocialSync.Application.Features.Requests;

namespace SocialSync.Application.Features;

public class DeleteTagRequestHandler : IRequestHandler<DeleteTagRequest, Unit>
{
    public Task<Unit> Handle(DeleteTagRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}