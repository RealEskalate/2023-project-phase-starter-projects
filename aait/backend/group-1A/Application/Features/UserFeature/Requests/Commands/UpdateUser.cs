using Application.DTO.Common;
using Application.DTO.UserDTO.DTO;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserFeature.Requests.Commands
{
   public class UpdateUserCommand : IRequest<UserResponseDTO>
    {
        public int userId { get; set; }
        public UserUpdateDTO? UserUpdateData { get; set; }
    }
}
