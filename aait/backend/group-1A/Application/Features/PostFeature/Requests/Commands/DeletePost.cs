using Application.DTO.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PostFeature.Requests.Commands
{
    public class DeletePostCommand : IRequest<CommonResponseDTO>
    {
        public int Id { get; set; }
        public int userId { get; set; }
    }
}
