using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO.UserDTO.DTO;
using Application.Response;
using MediatR;

namespace Application.Features.UserFeature.Requests.Commands
{
    public class UpdatePasswordCommand : IRequest<BaseResponse<UpdatePasswordDTO>>
    {
        public int UserId {set; get;}   
        public UpdatePasswordDTO? UpdatePasswordDTO {set; get;}
    }
}