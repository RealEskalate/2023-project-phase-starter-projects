using Application.DTO.CommentReactionDTOS.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Application.Features.CommentReactionFeatures.Requests.Queries
{
    public class GetCommentReactionQuery : IRequest<CommentReactionDTO>
    {
        public int Id { get; set; }
    }
}
