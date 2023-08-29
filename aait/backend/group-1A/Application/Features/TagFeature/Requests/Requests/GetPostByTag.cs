using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO.PostDTO.DTO;
using Application.Response;
using MediatR;

namespace Application.Features.TagFeature.Handlers.Requests
{
    public class GetPostByTag : IRequest<BaseResponse<List<PostResponseDTO>>>
    {
        public string TagName { get; set; }
    }
}