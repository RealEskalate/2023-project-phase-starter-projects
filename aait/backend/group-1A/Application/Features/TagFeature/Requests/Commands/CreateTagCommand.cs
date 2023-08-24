using MediatR;
using SocialSync.Application.DTO;

namespace SocialSync.Application.Features.Requests;


public class CreateTagCommand : IRequest<TagResponseDto>
{
    public string Title { get; set; } = string.Empty;
}