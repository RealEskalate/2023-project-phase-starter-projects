using Application.DTO.UserDTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.FollowFeatures.Request.Queries
{
    public class GetFollowerRequest : IRequest<List<UserDto>>
    {
        public int Id { get; set; }
    }
}
