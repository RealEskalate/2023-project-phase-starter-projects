using MediatR;
using SocialSync.Application.DTO;

namespace SocialSync.Application.Features.Requests;

public class UpdateTagRequest : IRequest<TagResponseDto>{

    public UpdateTagDto UpdateTagDto {get; set;} = null!;
}