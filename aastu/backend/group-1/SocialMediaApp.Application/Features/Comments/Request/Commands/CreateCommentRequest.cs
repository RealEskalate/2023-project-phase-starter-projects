using MediatR;
using SocialMediaApp.Application.DTOs.Comments;
using SocialMediaApp.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.Features.Comments.Request.Commands;

public class CreateCommentRequest : IRequest<BaseResponseClass>
{
    public CreateCommentDto? creatCommentDto { get; set; }
}
