using MediatR;
using SocialMediaApp.Application.DTOs.Posts;
using SocialMediaApp.Application.Responses;
using SocialMediaApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.Features.Posts.Request.Commands;

public class CreatePostsCommand: IRequest<BaseResponseClass>
{
    public CreatePostDto postDto { get; set; }
}
