

using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;

namespace Domain.Entities
{
    public class CommentReaction : BaseReactionEntity
    {

        public int CommentId { get; set; }

        public virtual Comment Comment {get ; set;}

    }

}