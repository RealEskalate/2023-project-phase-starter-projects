using MediatR;
using Application.DTO.FollowDTo;
using Application.DTO.FollowDTo.Validations;
using Application.DTO.Common;
using Application.Common;

namespace Application.Features.FollowFeature.Requests.Commands
{
    public class CreateFollowCommand : IRequest<CommonResponseDTO>
    {
        public FollowDTO? FollowDTO { get; set; } 
    }
}