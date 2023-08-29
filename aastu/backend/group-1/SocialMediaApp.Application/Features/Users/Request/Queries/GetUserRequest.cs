using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SocialMediaApp.Application.DTOs.Users;

namespace SocialMediaApp.Application.Features.Users.Request.Queries
{
    public class GetUserRequest:IRequest<UserDto>
    {
      public Guid Id { get; set; }
    }
}