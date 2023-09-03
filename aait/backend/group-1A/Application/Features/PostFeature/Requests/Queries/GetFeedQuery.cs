using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO.PostDTO.DTO;
using Application.Response;
using MediatR;

namespace Application.Features.PostFeature.Requests.Queries
{
    public class GetFeedQuery : IRequest<BaseResponse<List<PostResponseDTO>>>
    {
        public int UserId {set;get;}
    }
}