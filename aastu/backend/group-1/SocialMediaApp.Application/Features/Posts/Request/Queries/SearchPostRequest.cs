using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SocialMediaApp.Application.DTOs.Posts;

namespace SocialMediaApp.Application.Features.Posts.Request.Queries
{
    public class SearchPostRequest:IRequest<List<PostDto>>
    {
        public string query {get; set;} = "";
    }
}