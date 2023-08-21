using Application.DTO.Common;
using Application.DTO.PostDTO.DTO;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PostFeature.Requests.Commands
{
   public class UpdatePostCommand : IRequest<PostResponseDTO>
    {
        public int Id { get; set; }
        public PostUpdateDTO PostUpdateData { get; set; }
    }
}
