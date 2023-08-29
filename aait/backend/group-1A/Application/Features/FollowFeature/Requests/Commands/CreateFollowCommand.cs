using MediatR;
using Application.DTO.FollowDTo;
using Application.DTO.Common;
using Application.Response;

namespace Application.Features.FollowFeature.Requests.Commands
{
    public class CreateFollowCommand : IRequest<BaseResponse<string>>
    {
        public FollowDTO? FollowDTO { get; set; } 
    }
}