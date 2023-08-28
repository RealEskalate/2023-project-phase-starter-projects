using MediatR;
using SocialSync.Application.DTO;
using SocialSync.Application.Features.Requests;

namespace SocialSync.Application.Features;

public class UpdateTagRequestHandler : IRequestHandler<UpdateTagRequest, TagResponseDto>
{
    public Task<TagResponseDto> Handle(UpdateTagRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}