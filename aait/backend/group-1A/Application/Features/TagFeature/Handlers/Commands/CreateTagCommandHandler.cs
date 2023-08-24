using MediatR;
using SocialSync.Application.DTO;
using SocialSync.Application.Features.Requests;

namespace SocialSync.Application.Features.Handlers;

public class CreateTagCommandHandler : IRequestHandler<CreateTagCommand, TagResponseDto>
{
    public Task<TagResponseDto> Handle(CreateTagCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}