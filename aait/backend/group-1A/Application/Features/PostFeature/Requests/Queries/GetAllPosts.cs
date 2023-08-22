using Application.DTO.PostDTO.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PostFeature.Requests.Queries
{
    public class GetAllPostsQuery : IRequest<List<PostResponseDTO>>
    {
    }
}
