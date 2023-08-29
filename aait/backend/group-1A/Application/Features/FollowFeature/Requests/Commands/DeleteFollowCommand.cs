using Application.DTO.Common;
using Application.DTO.FollowDTo;
using Application.Response;
using MediatR;

namespace Application.Features.FollowFeature.Requests.Commands
{
    public class DeleteFollowCommand : IRequest<BaseResponse<int>>
    {
        public FollowDTO? FollowDTO { get; set; }
    }
}