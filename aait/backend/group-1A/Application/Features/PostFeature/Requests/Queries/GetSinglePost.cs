using Application.DTO.PostDTO.DTO;
using Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PostFeature.Requests.Queries
{
    public class GetSinglePostQuery : IRequest<BaseResponse<PostResponseDTO>>
    {
        public int Id { get; set; }
        public int userId { get; set; }
            

    }
}


