using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.Features.Likes.Request.Commands
{
    public class DeleteLikeRequest:IRequest<Unit>
    {
        public Guid LikeId { get; set; }
        public Guid UserId { get; set; }

    }
}
