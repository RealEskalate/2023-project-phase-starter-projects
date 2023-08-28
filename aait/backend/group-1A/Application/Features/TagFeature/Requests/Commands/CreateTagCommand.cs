using MediatR;
using SocialSync.Application.DTO;

namespace SocialSync.Application.Features.Requests;


public class CreateTagCommand : IRequest<TagResponseDto>
{
    public CreateTagDto CreateTagDto {get; set;} = null!;
}