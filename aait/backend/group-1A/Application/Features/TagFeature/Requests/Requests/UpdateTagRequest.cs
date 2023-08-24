using MediatR;
using SocialSync.Application.DTO;

namespace SocialSync.Application.Features.Requests;

public class UpdateTagRequest : IRequest<TagResponseDto>{

    public CreateTagDto CreateTagDto {get; set;} = null!;
}