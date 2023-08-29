using MediatR;
using SocialMediaApp.Application.DTOs.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.Features.Posts.Request.Queries
{
    public class GetPostsRequestByUser: IRequest<List<PostDto>>
    {
        public Guid UserId { get; set; }
    }
}
