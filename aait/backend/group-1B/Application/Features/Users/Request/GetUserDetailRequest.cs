
using MediatR;
using Application.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Request
{
    public class GetUserDetailRequest : IRequest<UserDetail>
    {
        public int Id { get; set; }
    }
}
