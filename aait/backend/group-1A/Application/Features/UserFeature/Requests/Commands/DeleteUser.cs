using Application.Common;
using Application.DTO.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserFeature.Requests.Commands
{
    public class DeleteUserCommand : IRequest<CommonResponseDTO>
    {
         public int userId { get; set; }
    }
}
