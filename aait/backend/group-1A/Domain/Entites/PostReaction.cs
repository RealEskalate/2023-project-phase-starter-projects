using Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Entities
{
    public class PostReaction : BaseReactionEntity
    {


        public int PostId { get; set; }

        public virtual Post post {get ; set;}
        
    }
}
