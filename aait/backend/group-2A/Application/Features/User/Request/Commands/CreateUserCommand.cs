using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO.Post;
using Application.DTO.UserDTO;
using Application.Model;
using Domain;
using MediatR;

namespace Application.Features.User.Request.Commands
{
    public class CreateUserCommand : IRequest<AuthResponse>
        {
            public required CreateUserDTO CreateUser { get; set; }

        }
    
}
