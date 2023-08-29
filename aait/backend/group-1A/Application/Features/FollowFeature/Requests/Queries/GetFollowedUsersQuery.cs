using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Application.DTO.FollowDTo;
using Application.DTO.UserDTO.DTO;
using Application.Response;
using Domain.Entites;
using MediatR;

namespace Application.Features.FollowFeature.Requests.Queries
{
    public class GetFollowedUsersQuery : IRequest<BaseResponse<List<UserResponseDTO>>>
    {
        public int Id { get; set; }
    }
}