using Application.DTO.UserDTO.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserFeature.Requests.Queries
{
    public class GetSingleUserQuery : IRequest<UserResponseDTO>
    {
       public int userId { get; set; }
    }
}


