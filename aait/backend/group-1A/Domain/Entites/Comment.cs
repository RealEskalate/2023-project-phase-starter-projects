using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;

namespace Domain.Entities
{
    public class Comment : BaseEntity
    {

        
        public int PostId { get; set; }

        public virtual Post post {get ; set;}
        public virtual ICollection<CommentReaction> CommentReactions { get; set; }


    }
}
