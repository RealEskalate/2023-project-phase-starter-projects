using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SocialMediaApp.Application.DTOs.Users;

namespace SocialMediaApp.Application.Features.Users.Request.Queries;

public class GetUsersRequest: IRequest<List<UserDto>>
{
    
}
