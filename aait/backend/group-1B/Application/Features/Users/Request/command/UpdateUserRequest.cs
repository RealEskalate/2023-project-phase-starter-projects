using Application.DTOs.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.features.Users.Request.command
{
    public class UpdateUserRequest : IRequest<Unit>
    {
        public UpdateUserDto UpdateUserDto { get; set; }
    }
}
