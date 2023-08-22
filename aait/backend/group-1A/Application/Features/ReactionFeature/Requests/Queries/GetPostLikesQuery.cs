using Application.DTO.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PostFeature.Requests.Queries
{
    public class GetPostLikesQuery : IRequest<List<ReactionResponseDTO>>
    {
        public int PostId { get; set; }
    }
}
