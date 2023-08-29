using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SocialMediaApp.Application.DTOs.Users;

namespace SocialMediaApp.Application.Features.Users.Request.Queries
{
    public class GetUsersByNameRequest:IRequest<List<UserDto>>
    {
        public string? Name {get; set;}
    }
}