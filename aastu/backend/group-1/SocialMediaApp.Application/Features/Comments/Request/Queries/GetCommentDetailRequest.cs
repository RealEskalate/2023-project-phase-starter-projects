using MediatR;
using SocialMediaApp.Application.DTOs.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.Features.Comments.Request.Queries;

public class GetCommentDetailRequest : IRequest<CommentDto>
{
    public Guid Id { get; set;}
}
