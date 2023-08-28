using Application.DTO.Common;
using Application.DTO.PostDTO.DTO;
using Application.Response;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PostFeature.Requests.Commands
{
   public class UpdatePostCommand : IRequest<BaseResponse<PostResponseDTO>>
    {
        public int Id { get; set; }
        public int userId { get; set; }
        public PostUpdateDTO PostUpdateData { get; set; }
    }
}
