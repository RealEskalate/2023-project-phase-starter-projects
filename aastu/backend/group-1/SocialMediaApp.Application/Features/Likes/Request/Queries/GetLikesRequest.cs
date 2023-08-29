using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialMediaApp.Application.DTOs.Likes;

namespace SocialMediaApp.Application.Features.Likes.Request.Queries;

public class GetLikesRequest:IRequest<List<LikeDto>>
{   
    public Guid PostId { get; set; }
    

}
