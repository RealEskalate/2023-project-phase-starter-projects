using Application.DTOS.Auth;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Request
{
    public class RegisterUserRequest : IRequest<int>
    {
        public RegisterRequestDto registerRequest { get; set; }
    }
}
