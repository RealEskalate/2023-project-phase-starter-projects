using MediatR;
using SocialMediaApp.Application.DTOs.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.Features.Comments.Request.Commands
{
    public class DeleteCommentRequest : IRequest<Unit>
    {
        public Guid UserId  { get; set; }

        public Guid Id { get; set; }
    }
}
