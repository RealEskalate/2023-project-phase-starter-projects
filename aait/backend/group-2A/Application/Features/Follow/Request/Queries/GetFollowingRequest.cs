using Application.DTO.UserDTO;
using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.FollowFeatures.Request.Queries
{
    public class GetFollowingRequest : IRequest<BaseCommandResponse<List<UserDto>>>
    {
        public int Id { get; set; }
        public int PageNumber{ get; set; } = 0;
        public int PageSize{ get; set; } = 10;
    }
}
