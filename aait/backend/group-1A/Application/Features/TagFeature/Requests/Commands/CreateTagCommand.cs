using Application.Response;
using MediatR;
using SocialSync.Application.DTO;

namespace SocialSync.Application.Features.Requests;


public class CreateTagCommand : IRequest<BaseResponse<string>>
{
    public CreateTagDto CreateTagDto {get; set;} = null!;
}